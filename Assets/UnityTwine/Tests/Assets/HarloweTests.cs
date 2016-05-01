﻿/*
------------------------------------------------
Generated by UnityTwine 0.0.0.0 on 4/27/2016 12:08:32 PM
https://github.com/daterre/UnityTwine

Original file: HarloweTests.html
Story format: Harlowe
------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTwine;
using ITwineThread = System.Collections.Generic.IEnumerable<UnityTwine.TwineOutput>;
using parameters = System.Collections.Generic.Dictionary<string, object>;
using UnityTwine.StoryFormats.Harlowe;

public partial class @HarloweTests: UnityTwine.StoryFormats.Harlowe.HarloweStory
{
	#region Variables
	// ---------------

	public class VarDefs: TwineRuntimeVars
	{
		public VarDefs()
		{
			VarDef("strictTest", () => this.@strictTest, val => this.@strictTest = val);
			VarDef("str", () => this.@str, val => this.@str = val);
			VarDef("b", () => this.@b, val => this.@b = val);
			VarDef("b2", () => this.@b2, val => this.@b2 = val);
			VarDef("int", () => this.@int, val => this.@int = val);
			VarDef("dec", () => this.@dec, val => this.@dec = val);
			VarDef("naked", () => this.@naked, val => this.@naked = val);
			VarDef("red", () => this.@red, val => this.@red = val);
			VarDef("setTest", () => this.@setTest, val => this.@setTest = val);
			VarDef("putTest", () => this.@putTest, val => this.@putTest = val);
			VarDef("a", () => this.@a, val => this.@a = val);
			VarDef("ar", () => this.@ar, val => this.@ar = val);
			VarDef("dst", () => this.@dst, val => this.@dst = val);
			VarDef("map", () => this.@map, val => this.@map = val);
		}

		public TwineVar @strictTest;
		public TwineVar @str;
		public TwineVar @b;
		public TwineVar @b2;
		public TwineVar @int;
		public TwineVar @dec;
		public TwineVar @naked;
		public TwineVar @red;
		public TwineVar @setTest;
		public TwineVar @putTest;
		public TwineVar @a;
		public TwineVar @ar;
		public TwineVar @dst;
		public TwineVar @map;
	}

	public new VarDefs Vars
	{
		get { return (VarDefs) base.Vars; }
	}

	// ---------------
	#endregion

	#region Initialization
	// ---------------

	public readonly UnityTwineTestMacros macros1;
	public readonly UnityTwine.StoryFormats.Harlowe.HarloweRuntimeMacros macros2;

	@HarloweTests()
	{
		base.Vars = new VarDefs() { Story = this, StrictMode = true };

		macros1 = new UnityTwineTestMacros() { Story = this };
		macros2 = new UnityTwine.StoryFormats.Harlowe.HarloweRuntimeMacros() { Story = this };
	}
	
	void Awake() {
		base.Init();
		passage1_Init();
		passage2_Init();
		passage3_Init();
		passage4_Init();
		passage5_Init();
		passage6_Init();
		passage7_Init();
		passage8_Init();
		passage9_Init();
		passage10_Init();
		passage11_Init();
		passage12_Init();
		passage13_Init();
		passage14_Init();
		passage15_Init();
		passage16_Init();
		passage17_Init();
		passage18_Init();
	}

	// ---------------
	#endregion

	// .............
	// #1: Result

	void passage1_Init()
	{
		this.Passages["Result"] = new TwinePassage("Result", new string[]{  }, passage1_Main);
	}

	#line 1 "Result"
	ITwineThread passage1_Main()
	{
		yield return text("Yay! This is the end of the test.");
		yield break;
	}


	// .............
	// #2: Vars_StrictMode

	void passage2_Init()
	{
		this.Passages["Vars_StrictMode"] = new TwinePassage("Vars_StrictMode", new string[]{  }, passage2_Main);
	}

	#line 1 "Vars_StrictMode"
	ITwineThread passage2_Main()
	{
		Vars.strictTest  = "string value";
		yield return lineBreak();
		Vars.strictTest  = 12.5;
		yield return lineBreak();
		yield break;
	}


	// .............
	// #3: Vars_Type_String

	void passage3_Init()
	{
		this.Passages["Vars_Type_String"] = new TwinePassage("Vars_Type_String", new string[]{  }, passage3_Main);
	}

	#line 1 "Vars_Type_String"
	ITwineThread passage3_Main()
	{
		Vars.str  = "A";
		macros1.assert(Vars.str == "A", "equality (left)");
		macros1.assert("A" == Vars.str, "equality (right)");
		macros1.assert(Vars.str != "ABC", "inequality (left)");
		macros1.assert("ABC" != Vars.str, "inequality (right)");
		Vars.str  = Vars.str + "B";
		macros1.assert(Vars.str == "AB", "join operator (left)");
		Vars.str  = "C" + Vars.str;
		macros1.assert(Vars.str == "CAB", "join operator (right)");
		macros1.assert(Vars.str .Contains("CA"), "contains literal");
		macros1.assert(Vars.str["1st"] == "C", "position fwd");
		macros1.assert(Vars.str["2ndlast"] == "A", "position bkwd");
		macros1.assert(Vars.str[(3)] == "B", "numeric index fwd");
		macros1.assert(Vars.str[(-1)] == "A", "numeric index bkwd");
		macros1.assert(Vars.str[macros2.a(1,3)] == "CB", "index array (substring)");
		macros1.assert(Vars.str["length"] == 3, "length");
		macros1.assert(v("Fear") .Contains(("e" + "ar")), "contains expression");
		macros1.assert(v("ugh") .ContainedBy("Through"), "contained by");
		macros1.assert(v("YO")["1st"] == "Y", "position fwd");
		macros1.assert(v("YO")["last"] == "O", "position bkwd");
		macros1.assert(v("PS")[(2)] == "S", "numeric index");
		macros1.assert(v("1st").AsMemberOf[("YO")] == "Y", "reverse position fwd");
		macros1.assert(v("last").AsMemberOf[("YO")] == "O", "reverse position bkwd");
		macros1.assert( v(2) .AsMemberOf[("PS")] == "S", "numeric index");
		macros1.assert(macros2.substring("cheese", 2, 4) == "hee", "macro substring");
		macros1.assert(macros2.text(4*80) == "320", "text macro");
		macros1.pass();
		yield break;
	}


	// .............
	// #4: Vars_Type_Bool

	void passage4_Init()
	{
		this.Passages["Vars_Type_Bool"] = new TwinePassage("Vars_Type_Bool", new string[]{  }, passage4_Main);
	}

	#line 1 "Vars_Type_Bool"
	ITwineThread passage4_Main()
	{
		Vars.b  = true;
		macros1.assert(Vars.b, "evaluate");
		macros1.assert(Vars.b == true, "equality (left)");
		macros1.assert(true == Vars.b, "equality (right)");
		macros1.assert(Vars.b != false, "inequality (left)");
		macros1.assert(false != Vars.b, "inequality (right)");
		macros1.assert(Vars.b && true, "and operator");
		macros1.assert(false || Vars.b, "or operator");
		macros1.assert(! (Vars.b == false), "not operator");
		Vars.b2  = Vars.b && true || false;
		macros1.assert(Vars.b2, "assignment");
		macros1.assert((4 > 2) && ((1 == 0) || Vars.b2) && (67*1+1) == 68, "nesting");
		macros1.pass();
		yield break;
	}


	// .............
	// #5: Vars_Type_Number

	void passage5_Init()
	{
		this.Passages["Vars_Type_Number"] = new TwinePassage("Vars_Type_Number", new string[]{  }, passage5_Main);
	}

	#line 1 "Vars_Type_Number"
	ITwineThread passage5_Main()
	{
		Vars.@int  = 2;
		macros1.assert(2 + Vars.@int == 4, "int addition (right)");
		macros1.assert(Vars.@int + 2 == 4, "int addition (left)");
		macros1.assert(3 - Vars.@int == 1, "int substraction (right)");
		macros1.assert(Vars.@int - 3 == -1, "int substraction (left)");
		macros1.assert(5 * Vars.@int == 10, "int multiplication (right)");
		macros1.assert(Vars.@int * 5 == 10, "int multiplication (left)");
		macros1.assert(2 / Vars.@int == 1, "int division (right)");
		macros1.assert(Vars.@int / 2 == 1, "int division (left)");
		macros1.assert(5 % Vars.@int == 1, "int modulo (right)");
		macros1.assert(Vars.@int % 2 == 0, "int modulo (left)");
		macros1.assert(3 > Vars.@int, "int greater than (right)");
		macros1.assert(Vars.@int > 1, "int greater than (left)");
		macros1.assert(2 >= Vars.@int, "int greater than or equal (right)");
		macros1.assert(Vars.@int >= 2, "int greater than or equal (left)");
		macros1.assert(1 < Vars.@int, "int less than (right)");
		macros1.assert(Vars.@int < 3, "int less than (left)");
		macros1.assert(1 <= Vars.@int, "int less than or equal (right)");
		macros1.assert(Vars.@int <= 3, "int less than or equal (left)");
		Vars.dec  = 2.1;
		macros1.assert(macros2.round(2 + Vars.dec, 1) == 4.1, "decimal addition (right)");
		macros1.assert(macros2.round(Vars.dec + 2, 1) == 4.1, "decimal addition (left)");
		macros1.assert(macros2.round(3 - Vars.dec, 1) == 0.9, "decimal substraction (right)");
		macros1.assert(macros2.round(Vars.dec - 3, 1) == -0.9, "decimal substraction (left)");
		macros1.assert(macros2.round(5 * Vars.dec, 1) == 10.5, "decimal multiplication (right)");
		macros1.assert(macros2.round(Vars.dec * 5, 1) == 10.5, "decimal multiplication (left)");
		macros1.assert(macros2.round(4 / Vars.dec, 1) < 2, "decimal division (right)");
		macros1.assert(macros2.round(Vars.dec / 2, 2) == 1.05, "decimal division (left)");
		macros1.assert(macros2.round(5 % Vars.dec, 1) == 0.8, "decimal modulo (right)");
		macros1.assert(macros2.round(Vars.dec % 2, 1) == 0.1, "decimal modulo (left)");
		macros1.assert(3 > Vars.dec, "decimal greater than (right)");
		macros1.assert(Vars.dec > 2, "decimal greater than (left)");
		macros1.assert(3 >= Vars.dec, "decimal greater than or equal (right)");
		macros1.assert(Vars.dec >= 2, "decimal greater than or equal (left)");
		macros1.assert(2 < Vars.dec, "decimal less than (right)");
		macros1.assert(Vars.dec < 3, "decimal less than (left)");
		macros1.assert(2 <= Vars.dec, "decimal less than or equal (right)");
		macros1.assert(Vars.dec <= 3, "decimal less than or equal (left)");
		macros1.assert(macros2.ceil(3.1) == 4, "macro: ceil");
		macros1.assert(macros2.floor(-3.1) == -4, "macro: floor");
		macros1.assert(macros2.num("2"+"5") == 25, "macro: num");
		macros1.assert(macros2.number("2"+"5") == 25, "macro: number");
		macros1.assert(macros2.random(1,6) .ContainedBy(macros2.range(1,6)), "macro: random");
		macros1.pass();
		yield break;
	}


	// .............
	// #6: Markup_Context_Styles

	void passage6_Init()
	{
		this.Passages["Markup_Context_Styles"] = new TwinePassage("Markup_Context_Styles", new string[]{  }, passage6_Main);
	}

	#line 1 "Markup_Context_Styles"
	ITwineThread passage6_Main()
	{
		using (Context.Apply("italic", true)) {
			yield return text("italic");
			macros1.assertContext("italic", true);
		}
		macros1.assertContext("italic", false);
		using (Context.Apply("bold", true)) {
			yield return text("bold");
			macros1.assertContext("bold", true);
		}
		macros1.assertContext("bold", false);
		using (Context.Apply("del", true)) {
			yield return text("strikeout");
			macros1.assertContext("del", true);
		}
		macros1.assertContext("del", false);
		using (Context.Apply("em", true)) {
			yield return text("emphasis");
			macros1.assertContext("em", true);
		}
		macros1.assertContext("em", false);
		using (Context.Apply("strong", true)) {
			yield return text("strong");
			macros1.assertContext("strong", true);
		}
		macros1.assertContext("strong", false);
		using (Context.Apply("sup", true)) {
			yield return text("superscript");
			macros1.assertContext("sup", true);
		}
		macros1.assertContext("sup", false);
		using (Context.Apply("bulleted", 1)) {
			yield return text("Bulleted item ");
			macros1.assertContext("bulleted", 1);
		}
		macros1.assertContext("bulleted", false);
		using (Context.Apply("bulleted", 2)) {
			yield return text("Indented bulleted item ");
			macros1.assertContext("bulleted", 2);
		}
		macros1.assertContext("bulleted", false);
		using (Context.Apply("bulleted", 3)) {
			yield return text("Indented bulleted ite3 ");
			macros1.assertContext("bulleted", 3);
		}
		macros1.assertContext("bulleted", false);
		using (Context.Apply("numbered", 1)) {
			yield return text("Numbered item ");
			macros1.assertContext("numbered", 1);
		}
		using (Context.Apply("numbered", 1)) {
			yield return text("Numbered item 2 ");
			macros1.assertContext("numbered", 1);
		}
		using (Context.Apply("numbered", 2)) {
			yield return text("Indented numbered item ");
			macros1.assertContext("numbered", 2);
		}
		macros1.assertContext("numbered", false);
		using (Context.Apply("heading", 1)) {
			yield return text("Level 1 heading  ");
			macros1.assertContext("heading", 1);
		}
		macros1.assertContext("heading", false);
		using (Context.Apply("heading", 3)) {
			yield return text("Level 3 heading  ");
			macros1.assertContext("heading", 3);
		}
		macros1.assertContext("heading", false);
		using (Context.Apply("heading", 6)) {
			yield return text("Level 6 heading  ");
			macros1.assertContext("heading", 6);
		}
		macros1.assertContext("heading", false);
		macros1.pass();
		yield break;
	}


	// .............
	// #7: Markup_HTML

	void passage7_Init()
	{
		this.Passages["Markup_HTML"] = new TwinePassage("Markup_HTML", new string[]{ "NoException", }, passage7_Main);
	}

	#line 1 "Markup_HTML"
	ITwineThread passage7_Main()
	{
		yield return text("raw HTML");
		yield return lineBreak();
		macros1.pass();
		yield break;
	}


	// .............
	// #8: Markup_Verbatim

	void passage8_Init()
	{
		this.Passages["Markup_Verbatim"] = new TwinePassage("Markup_Verbatim", new string[]{  }, passage8_Main);
	}

	#line 1 "Markup_Verbatim"
	ITwineThread passage8_Main()
	{
		yield return text("(print: \"verbatim1\")");
		yield return lineBreak();
		macros1.assertText("(print: \"verbatim1\")", "verbatim");
		yield return lineBreak();
		yield return text("(print: \"verbatim2\")");
		macros1.assertText("(print: \"verbatim2\")", "verbatim");
		yield return lineBreak();
		yield return text("(print: \"verbatim3\")");
		macros1.assertText("(print: \"verbatim3\")", "verbatim");
		yield return lineBreak();
		macros1.pass();
		yield break;
	}


	// .............
	// #9: Markup_Unsupported

	void passage9_Init()
	{
		this.Passages["Markup_Unsupported"] = new TwinePassage("Markup_Unsupported", new string[]{  }, passage9_Main);
	}

	#line 1 "Markup_Unsupported"
	ITwineThread passage9_Main()
	{
		yield return text("This is right-aligned");
		yield return lineBreak();
		yield return text("This is centered");
		yield return lineBreak();
		yield return text("This is justified");
		yield return lineBreak();
		yield return text("This is left-aligned (undoes the above)");
		yield return lineBreak();
		yield return text("This has margins 3/4 left, 1/4 right");
		yield return lineBreak();
		yield return lineBreak();
		macros1.pass();
		yield break;
	}


	// .............
	// #10: Markup_LineBreaks

	void passage10_Init()
	{
		this.Passages["Markup_LineBreaks"] = new TwinePassage("Markup_LineBreaks", new string[]{  }, passage10_Main);
	}

	#line 1 "Markup_LineBreaks"
	ITwineThread passage10_Main()
	{
		yield return text("This line");
		yield return text("and this line");
		yield return text("and this line, are actually just one line.");
		macros1.assertNoOutput(typeof(UnityTwine.TwineLineBreak));
		yield return lineBreak();
		macros1.pass();
		yield break;
	}


	// .............
	// #11: Markup_NakedVar

	void passage11_Init()
	{
		this.Passages["Markup_NakedVar"] = new TwinePassage("Markup_NakedVar", new string[]{  }, passage11_Main);
	}

	#line 1 "Markup_NakedVar"
	ITwineThread passage11_Main()
	{
		Vars.naked  = "I can see your butt :)";
		yield return lineBreak();
		yield return lineBreak();
		yield return text(Vars.naked);
		yield return lineBreak();
		yield return lineBreak();
		macros1.assertText("I can see your butt :)", "naked var");
		yield return lineBreak();
		macros1.pass();
		yield break;
	}


	// .............
	// #12: Markup_Context_Hooks

	void passage12_Init()
	{
		this.Passages["Markup_Context_Hooks"] = new TwinePassage("Markup_Context_Hooks", new string[]{  }, passage12_Main);
	}

	#line 1 "Markup_Context_Hooks"
	ITwineThread passage12_Main()
	{
		using (Context.Apply(HarloweContextOptions.Hook, "c1")) {
			yield return text("ballroom");
			macros1.assertContext("hook", "c1");
		}
		yield return lineBreak();
		using (Context.Apply(HarloweContextOptions.Hook, "c2")) {
			yield return text("bright red");
			macros1.assertContext("hook", "c2");
		}
		yield return lineBreak();
		macros1.pass();
		yield break;
	}


	// .............
	// #13: Vars_It

	void passage13_Init()
	{
		this.Passages["Vars_It"] = new TwinePassage("Vars_It", new string[]{  }, passage13_Main);
	}

	#line 1 "Vars_It"
	ITwineThread passage13_Main()
	{
		Vars.red  = "eg";
		Vars.red  = Vars.red + "g";
		macros1.assert(Vars.red == "egg" && Vars.red["length"] == 3, "it/its");
		macros1.pass();
		yield break;
	}


	// .............
	// #14: Macros_SetPutMove

	void passage14_Init()
	{
		this.Passages["Macros_SetPutMove"] = new TwinePassage("Macros_SetPutMove", new string[]{  }, passage14_Main);
	}

	#line 1 "Macros_SetPutMove"
	ITwineThread passage14_Main()
	{
		Vars.setTest  = 32.1;
		macros1.assert(Vars.setTest == 32.1, "set");
		Vars.putTest = v(45) ;
		macros1.assert(Vars.putTest == 45, "put");
		macros1.pass();
		Vars.a  = macros2.a(111,macros2.a("cheese","bread"),3);
		macros1.assert(Vars.a["length"] == 2, "move from array");
		macros1.assert(Vars.b == 111, "move from array");
		macros1.pass();
		yield break;
	}


	// .............
	// #15: Vars_Type_Array

	void passage15_Init()
	{
		this.Passages["Vars_Type_Array"] = new TwinePassage("Vars_Type_Array", new string[]{  }, passage15_Main);
	}

	#line default
	ITwineThread passage15_Main()
	{
		Vars.ar  = macros2.a("red","blue","green");
		macros1.assert(Vars.ar == macros2.a("red","blue","green"), "equality");
		macros1.assert(macros2.a("red","blue","green") == Vars.ar, "equality (right)");
		macros1.assert(Vars.ar != macros2.a(9,1,2), "equality (left)");
		macros1.assert(Vars.ar .Contains("green"), "contains");
		macros1.assert(v("green") .ContainedBy(Vars.ar), "contained by");
		macros1.assert(Vars.ar["1st"] == "red", "position (named)");
		macros1.assert(Vars.ar[(2+1)] == "green", "position (expression)");
		macros1.assert(Vars.ar["last"] == "green", "position (last)");
		macros1.assert(Vars.ar["3rdlast"] == "red", "position (number from last)");
		macros1.assert(Vars.ar[macros2.a(1,3)] == macros2.a("red","green"), "position array");
		macros1.assert(macros2.a(1,2) + macros2.a(1,2) == macros2.a(1,2,1,2), "join");
		macros1.assert(macros2.a(1,1,2,3,4,5) - macros2.a(1,2) == macros2.a(3,4,5), "subtract");
		macros1.assert(macros2.a(0, (HarloweSpread)macros2.a(1,2,3,4), 5) == macros2.a(0,1,2,3,4,5), "spread");
		Vars.ar["1st"]  = "yellow";
		macros1.assert(v("yellow") == Vars.ar["1st"], "set position");
		Vars.ar["2nd"] = v("brown") ;
		macros1.assert(v("brown") == Vars.ar[(2)], "put position");
		macros1.assert(macros2.count(macros2.a(5,6,5,5,8), 5) == 3, "macro: count");
		macros1.assert(macros2.range(1,14) == macros2.a(1,2,3,4,5,6,7,8,9,10,11,12,13,14) && macros2.range(2,-2) == macros2.a(-2,-1,0,1,2), "macro: range");
		macros1.assert(macros2.rotated(1, "A","B","C","D") == macros2.a("D","A","B","C") && macros2.rotated(-2, "A","B","C","D") == macros2.a("C","D","A","B"), "macro: rotated");
		macros1.assert(macros2.shuffled(1,3,4,5)["length"] == 4, "macro: shuffled");
		macros1.assert(macros2.sorted("9", "1", "Z", "a", "é") == macros2.a("1","9","a","é", "Z"), "macro: sorted");
		macros1.assert(macros2.subarray(macros2.range(21,25), 3, 5) == macros2.a(23, 24, 25), "macro: subarray");
		macros1.pass();
		yield break;
	}


	// .............
	// #16: Vars_Type_Dataset

	void passage16_Init()
	{
		this.Passages["Vars_Type_Dataset"] = new TwinePassage("Vars_Type_Dataset", new string[]{  }, passage16_Main);
	}

	#line 1 "Vars_Type_Dataset"
	ITwineThread passage16_Main()
	{
		Vars.dst  = macros2.dataset("red","blue","green");
		macros1.assert(Vars.dst["length"] == 3, "length");
		macros1.assert(Vars.dst == macros2.dataset("red","blue","green"), "equality");
		macros1.assert(Vars.dst != macros2.dataset(9,1,2), "inequality");
		macros1.assert(Vars.dst .Contains("green"), "contains");
		macros1.assert(v("green") .ContainedBy(Vars.dst), "contained by");
		macros1.assert(macros2.dataset(1,2) + macros2.dataset(1,2) == macros2.dataset(1,2), "join");
		macros1.assert(macros2.dataset(1,2,3,4,5) - macros2.dataset(1,2) == macros2.dataset(5,4,3), "subtract");
		macros1.assert(macros2.dataset(0, (HarloweSpread)macros2.a(1,2,3,4,4,4,4), 5) == macros2.dataset(0,1,2,3,4,5), "spread");
		macros1.pass();
		yield break;
	}


	// .............
	// #17: Vars_Type_Datamap

	void passage17_Init()
	{
		this.Passages["Vars_Type_Datamap"] = new TwinePassage("Vars_Type_Datamap", new string[]{  }, passage17_Main);
	}

	#line 1 "Vars_Type_Datamap"
	ITwineThread passage17_Main()
	{
		Vars.map  = macros2.datamap("juice","orange", "vessel","glass");
		macros1.assert(Vars.map == macros2.datamap("juice","orange", "vessel","glass"), "equality");
		macros1.assert(Vars.map != macros2.datamap("juice","apple", "vessel","snifter"), "inequality");
		macros1.assert(Vars.map["juice"] == "orange", "get member (name)");
		macros1.assert(Vars.map[("ve"+"ssel")] == "glass", "get member (expression)");
		Vars.map[("juice")]  = "strawberry";
		macros1.assert(Vars.map["juice"] == "strawberry", "set member (expression)");
		Vars.map["vessel"] = v("bottle") ;
		macros1.assert(Vars.map[macros2.a("juice","vessel")] == macros2.a("strawberry","bottle"), "get member (subarray)");
		macros1.assert(macros2.datamap("a",1,"b",2)-macros2.a("a") == macros2.datamap("b",2), "remove keys (subtraction)");
		macros1.assert(macros2.datanames(Vars.map) == macros2.a("juice", "vessel"), "macro: datanames");
		macros1.assert(macros2.datavalues(Vars.map) == macros2.a("strawberry","bottle"), "macro: datavalues");
		macros1.pass();
		yield break;
	}


	// .............
	// #18: Markup_Links

	void passage18_Init()
	{
		this.Passages["Markup_Links"] = new TwinePassage("Markup_Links", new string[]{  }, passage18_Main);
	}

	#line default
	ITwineThread passage18_Main()
	{
		yield return link("Result", "Result", null, contextInfo(HarloweContextOptions.LinkType, "linkgoto"));
		macros1.assertLink("Result", "Result", "Link without text");
		yield return link("Link classic", "Result", null, contextInfo(HarloweContextOptions.LinkType, "linkgoto"));
		macros1.assertLink("Link classic", "Result");
		yield return link("Link right", "Result", null, contextInfo(HarloweContextOptions.LinkType, "linkgoto"));
		macros1.assertLink("Link right", "Result");
		yield return link("Link left", "Result", null, contextInfo(HarloweContextOptions.LinkType, "linkgoto"));
		macros1.assertLink("Link left", "Result");
		yield return link("Link-goto macro", "Result", null, contextInfo(HarloweContextOptions.LinkType, "linkgoto"));
		macros1.assertLink("Link-goto macro", "Result");
		yield return link("Link macro", null, passage18_Fragment_0, contextInfo(HarloweContextOptions.LinkType, "link"));
		macros1.assertLink("Link macro", null);
		macros1.pass();
		yield break;
	}

	#line 1 "Markup_Links#frag#0"
	ITwineThread passage18_Fragment_0()
	{
		yield break;
	}

}