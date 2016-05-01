﻿using UnityEngine;
using System.Collections;

namespace UnityTwine.Tests.Utils
{
	public static class TestUtils
	{
		public static void PassOrFail(bool condition, string failReason)
		{
			if (condition)
				IntegrationTest.Pass();
			else
				IntegrationTest.Fail(failReason);
		}
	}
}
