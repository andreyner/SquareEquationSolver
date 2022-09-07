using System;
using System.Collections.Generic;

namespace SquareEquationSolver
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.ReadKey();
		}
	}

	public static class Solver
	{
		public static double[] Solve(double a, double b, double c)
		{
			var res = new List<double>(2);
			CheckRatioA(a);
			CheckRatio(a);
			CheckRatio(b);
			CheckRatio(c);

			return res.ToArray();

		}

		private static void CheckRatio(double ratio)
		{
			if (double.IsInfinity(ratio) || double.IsNaN(ratio))
			{
				throw new Exception($"Некорректное значение коэффициентов!");
			}
		}

		private static void CheckRatioA(double ratioA)
		{
			if (ratioA.Compare(0))
			{
				throw new Exception($"Коэффициент \"a\" равен 0!");
			}
		}
	}

	public static class DoubleExtensions
	{
		const double eps = 0.0000001;

		public static bool Compare(this double left, double right)
		{
			return Math.Abs(left - right) < eps;
		}
	}
}
