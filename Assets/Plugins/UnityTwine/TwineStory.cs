﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnityTwine
{
    public abstract class TwineStory: MonoBehaviour
    {
        public string StartPassage = "Start";
		public MonoBehaviour HookScript = null;

		public event Action<TwineStoryState> OnStateChanged;
		public event Action<TwineOutput> OnOutput;
		//public event Action<TwineLink> OnLink;
		
		public string Text { get; private set; }
		public List<TwineLink> Links { get; private set; }
		public List<TwineOutput> Output { get; private set; }
		public Dictionary<string, string> Tags { get; private set; }
		public string CurrentPassageID { get; private set; }
		public string PreviousPassageID { get; private set; }

		protected Dictionary<string, TwinePassage> Passages { get; private set; }
		TwineStoryState _state = TwineStoryState.Idle;
		IEnumerator<TwineOutput> _passageExecutor = null;
		MethodInfo[] _passageUpdateHooks = null;
		System.Text.StringBuilder _storyText = null;
		Dictionary<string, MethodInfo> _hookCache = new Dictionary<string, MethodInfo>();

		protected void Init()
		{
			this.Output = new List<TwineOutput>();
			this.Links = new List<TwineLink>();
			this.Tags = new Dictionary<string, string>();
			this.Passages = new Dictionary<string, TwinePassage>();
			PreviousPassageID = null;
		}

		// ---------------------------------
		// State control

		public TwineStoryState State
		{
			get { return _state; }
			private set
			{
				TwineStoryState prev = _state;
				_state = value;
				if (prev != value && OnStateChanged != null)
					OnStateChanged(value);
			}
		}

		public void Begin()
		{
			GoTo(StartPassage);
		}

		public void GoTo(string passageID)
		{
			if (this.State != TwineStoryState.Idle)
			{
				throw new InvalidOperationException(
					// Paused
					this.State == TwineStoryState.Paused ?
						"The story is currently paused. Resume() must be called before advancing to a different passage." :
					// Playing
					this.State == TwineStoryState.Playing ?
						"The story cannot be advanced while a passage is playing." :
					// Complete
						"The story is complete. Reset() must be called before it can be played again."
					);
			}

			// invoke exit hooks
			InvokeHooks("Exit");

			TwinePassage passage = GetPassage(passageID);
			this.PreviousPassageID = this.CurrentPassageID;
			this.CurrentPassageID = passage.ID;

			this.Output.Clear();
			this.Links.Clear();
			this.Tags.Clear();
			_passageUpdateHooks = null;
			_storyText = new System.Text.StringBuilder();

			this.State = TwineStoryState.Playing;

			// Prepare the enumerator
			_passageExecutor = ExecutePassage(passage).GetEnumerator();

			this.Output.Add(passage);
			SendOutput(passage);

			// Story was paused, wait for it to resume
			if (this.State == TwineStoryState.Paused)
				return;
			else
				Execute();
		}

		/// <summary>
		/// While the story is playing, pauses the execution of the current passage.
		/// </summary>
		public void Pause()
		{
			if (this.State != TwineStoryState.Playing)
				throw new InvalidOperationException("Pause can only be called while a passage is playing.");

			this.State = TwineStoryState.Paused;
		}

		public void Resume()
		{
			if (this.State != TwineStoryState.Paused)
			{
				throw new InvalidOperationException(
					// Paused
					this.State == TwineStoryState.Idle ?
						"The story is currently idle. Call Begin, Advance or GoTo to play." :
					// Playing
					this.State == TwineStoryState.Playing ?
						"Resume() should be called only when the story is paused." :
					// Complete
						"The story is complete. Reset() must be called before it can be played again."
					);
			}
			Execute();
		}

		/// <summary>
		/// Resumes a story that was paused.
		/// </summary>
		void Execute()
		{
			while (_passageExecutor.MoveNext())
			{
				TwineOutput output = _passageExecutor.Current;
				this.Output.Add(output);

				if (output is TwinePassage)
				{
					// Merge tags with existing passages
					var passage = (TwinePassage)output;
					foreach (var tag in passage.Tags)
						this.Tags[tag.Key] = tag.Value;
				}
				else if (output is TwineLink)
				{
					// Add links to dedicated list
					var link = (TwineLink)output;
					this.Links.Add(link);
				}
				else if (output is TwineText)
				{
					// Add all text to the Text property for easy access
					var text = (TwineText)output;
					_storyText.AppendLine(text.String);
				}

				// Let the handlers and hooks kick in
				SendOutput(output);

				// Story was paused, wait for it to resume
				if (this.State == TwineStoryState.Paused)
					return;
			}

			_passageExecutor.Dispose();
			_passageExecutor = null;

			this.Text = _storyText.ToString();
			_storyText = null;

			this.State = this.Links.Count > 0 ?
				TwineStoryState.Idle :
				TwineStoryState.Complete;

			// Get update hooks for calling during update
			_passageUpdateHooks = GetHooks("Update", allowCoroutine: false).ToArray();

			InvokeHooks("Enter");
		}

		TwinePassage GetPassage(string passageID)
		{
			string pid = passageID;
			TwinePassage passage;
			if (!Passages.TryGetValue(pid, out passage))
				throw new Exception(String.Format("Passage '{0}' does not exist.", pid));
			return passage;
		}
			
		IEnumerable<TwineOutput> ExecutePassage(TwinePassage passage)
        {
			foreach(TwineOutput output in passage.Execute()) {
                if (output is TwineDisplay) {
                    var display = (TwineDisplay) output;
					TwinePassage displayPassage = GetPassage(display.PassageID);
					yield return displayPassage;
					foreach(TwineOutput innerOutput in ExecutePassage(displayPassage))
                        yield return innerOutput;
                }
                else
                    yield return output;
            }
        }

		void SendOutput(TwineOutput output)
		{
			if (OnOutput != null)
				OnOutput(output);
		}
		
		// ---------------------------------
		// Links

		public void Advance(TwineLink link)
		{
			if (link.Setters != null)
				link.Setters.Invoke();

			GoTo(link.PassageID);
		}

		public void Advance(int linkIndex)
		{
			Advance(this.Links[linkIndex]);
		}

		public void Advance(string linkName)
		{
			TwineLink link = this.Links
				.Where(lnk => string.Equals(lnk.Name, name, System.StringComparison.OrdinalIgnoreCase))
				.FirstOrDefault();

			if (link == null)
				throw new KeyNotFoundException(string.Format("There is no available link with the name '{0}'.", name));

			Advance(link);
		}

		// ---------------------------------
		// Hooks

		void Update()
		{
			if (_passageUpdateHooks != null)
			{
				for (int i = 0; i < _passageUpdateHooks.Length; i++)
					InvokeHookMethod(_passageUpdateHooks[i]);
			}
		}

		IEnumerable<MethodInfo> GetHooks(string hookName, bool allowCoroutine = true)
		{
			if (this.HookScript == null)
				yield break;

			foreach (TwineOutput output in this.Output)
			{
				if (!(output is TwinePassage))
					continue;

				var passage = (TwinePassage)output;
				MethodInfo hook = GetHookMethod(passage.ID + '_' + hookName, allowCoroutine);
				if (hook != null)
					yield return hook;
			}
		}

		void InvokeHooks(string hookName)
		{
			if (this.HookScript == null)
				return;

			foreach (MethodInfo hook in GetHooks(hookName))
				InvokeHookMethod(hook);
		}

		void InvokeHookMethod(MethodInfo hookMethod)
		{
			var result = hookMethod.Invoke(this.HookScript, null);
			if (result is IEnumerator)
				StartCoroutine(((IEnumerator)result));
		}

		MethodInfo GetHookMethod(string methodName, bool allowCoroutine = true)
		{
			if (this.HookScript == null)
				throw new UnassignedReferenceException("Can't hook because HookScript is not assigned.");

			MethodInfo method = null;
			if (!_hookCache.TryGetValue(methodName, out method))
			{
				method = this.HookScript.GetType().GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase);

				if (method != null)
				{
					if (allowCoroutine)
					{
						if (method.ReturnType != typeof(void) && !typeof(IEnumerator).IsAssignableFrom(method.ReturnType))
						{
							Debug.LogError(methodName + " must return void or IEnumerator in order to hook this story event.");
							method = null;
						}
					}
					else
					{
						if (method.ReturnType != typeof(void))
						{
							Debug.LogError(methodName + " must return void in order to hook to this story event.");
							method = null;
						}
					}
				}

				// Cache it even if it's null so we don't look for it again later
				_hookCache.Add(methodName, method);

				//if (method != null)
				//	Debug.Log("Hooking to " + method.Name);
			}

			return method;
		}

		// ---------------------------------
		// Variables

		public abstract TwineVar this[string name]
		{
			get;
			set;
		}

		// ---------------------------------
		// Functions

		// TODO: You plunge into the [[glowing vortex|either("12000 BC","The Future","2AM Yesterday")]].
		protected TwineVar either(params TwineVar[] vars)
		{
			return vars[UnityEngine.Random.Range(0, vars.Length)];
		}

		protected int random(int min, int max)
		{
			return UnityEngine.Random.Range(min, max + 1);
		}

		protected string passage()
		{
			return this.CurrentPassageID;
		}

		protected string previous()
		{
			return this.PreviousPassageID;
		}

		protected int visited(params string[] passageIDs)
		{
			// TODO: add passage counters
			throw new NotImplementedException();
		}

		protected int visitedTag(params string[] passageIDs)
		{
			// TODO: add tag counters
			throw new NotImplementedException();
		}

		protected int turns()
		{
			// TODO: return total link follow counter
			throw new NotImplementedException();
		}
		
		protected string[] tags()
		{
			return this.Tags.Keys.ToArray();
		}

		protected TwineVar paramater(int index)
		{
			// TODO: add parameters to passage execution
			throw new NotImplementedException();
			//return this.Paramaters[index];
		}
		
	}
}
