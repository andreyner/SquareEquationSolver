using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SquareEquationSolver.Testing
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void RateAIsZero()
		{
			Solver.Solve(a: 0, 1, 2);

			Assert.Fail($"Проверка на 0 коэффициента \"a\" провалена");
		}
	}
}
