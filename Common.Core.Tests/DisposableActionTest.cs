using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests
{
	[TestClass]
	public class DisposableActionTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Null_Action_Throws_ArgumentNullException()
		{
			var action = new DisposableAction(null);
		}

		[TestMethod]
		public void Action_Is_Executed_Within_Dispose()
		{
			int x = 5;

			using (new DisposableAction(() => x = 0)) {
				// Rien à faire
			}

			Assert.AreEqual(x, 0);
		}

		[TestMethod]
		public void Action_Is_Executed_Whatever_Is_Done_Before_Dispose()
		{
			int x = 5;
			x = 10;

			using (new DisposableAction(() => x = 0)) {
				x = 42;
			}

			Assert.AreEqual(x, 0);
		}

		[TestMethod]
		public void Action_Is_Executed_With_Explicite_Call_To_Dispose()
		{
			int x = 5;
			var action = new DisposableAction(() => x = 0);
			action.Dispose();

			Assert.AreEqual(x, 0);
		}

		[TestMethod]
		public void Action_Is_Not_Executed_Before_Dispose()
		{
			int x = 5;

			using (new DisposableAction(() => x = 0)) {
				Assert.AreNotEqual(x, 0);
			}

            Assert.AreEqual(x, 0);
		}
	}
}
