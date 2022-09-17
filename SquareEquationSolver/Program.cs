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
		const double eps = 0.0000001;

		public static double[] Solve(double a, double b, double c)
		{
			var res = new List<double>(2);
			CheckRatioA(a);
			CheckRatio(a);
			CheckRatio(b);
			CheckRatio(c);

			var D = Math.Pow(b, 2) - 4 * a * c;

			if (D.Compare(0))
			{
				res.Add(-b / (2 * a));

				return res.ToArray();
			}

			if(D.FuzzyCompareTo(0) < 0)
			{
				return res.ToArray();
			}


			res.Add((-b + Math.Sqrt(D)) / (2 * a));

			res.Add((-b - Math.Sqrt(D)) / (2 * a));

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

		public static bool Compare(this double left, double right, double eps = eps)
		{
			return Math.Abs(left - right) < eps;
		}

		public static double FuzzyCompareTo(this double left, double right, double eps = eps)
		{
			var diff = left - right;
			return Math.Abs(diff) < eps ? 0 : diff;
		}

	}
}
