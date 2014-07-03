using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityEngine;
using UnEngine;

namespace UnEngineUnitTests
{
	[TestClass]
	public class Vector2Test
	{
		[TestMethod]
		public void DotTest()
		{
			var a = new Vector2(2, 2);
			var b = new Vector2(3, 3);
			Assert.AreEqual(12, Vector2.Dot(a, b));
		}

		[TestMethod]
		public void normalizedTest()
		{
			var a = new Vector2(3, 4);
			var n = a.normalized;

			Assert.AreEqual(0.6f, n.x, 0.01f);
			Assert.AreEqual(0.8f, n.y, 0.01f);

			Assert.AreEqual(3f, a.x);
			Assert.AreEqual(4f, a.y);
		}

		[TestMethod]
		public void normalizedZeroTest()
		{
			var a = new Vector2(0, 0);
			var n = a.normalized;

			Assert.AreEqual(0, n.x);
			Assert.AreEqual(0, n.y);
		}
	}
}
