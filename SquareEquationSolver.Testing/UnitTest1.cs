using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SquareEquationSolver.Testing
{
	[TestClass]
	public class UnitTest1
	{
		/// <summary>
		/// 3.Написать тест, который проверяет, что для уравнения x^2+1 = 0 корней нет (возвращается пустой массив)
		/// </summary>
		[TestMethod]
		public void DiscriminantLessZero()
		{
			var res = Solver.Solve(a: 1, b: 0, c: 1);

			Assert.IsTrue(res.Length == 0, "Дискрминант < 0, но корни уравнения существуют!");
		}

		/// <summary>
		/// 5.Написать тест, который проверяет, что для уравнения x^2-1 = 0 есть два корня кратности 1 (x1=1, x2=-1)
		/// </summary>
		[TestMethod]
		public void TwoSolution()
		{
			var res = Solver.Solve(a: 1, b: 0, c: -1);

			Assert.IsTrue(res.Length == 2, "Уравнение должно иметь 2 корня!");
		}

		/// <summary>
		/// 7.Написать тест, который проверяет, что для уравнения x^2+2x+1 = 0 есть один корень кратности 2 (x1= x2 = -1).
		/// </summary>
		[TestMethod]
		public void OneSolution()
		{
			var res = Solver.Solve(a: 1, b: 2, c: 1);

			Assert.IsTrue(res.Length == 1, "Уравнение должно иметь 1 корень!");
		}

		/// <summary>
		/// 9.Написать тест, который проверяет, что коэффициент a не может быть равен 0. В этом случае solve выбрасывает исключение.
		/// Примечание.Учесть, что a имеет тип double и сравнивать с 0 через == нельзя.
		/// </summary>
		[TestMethod]
		public void RateAIsZero()
		{
			Assert.ThrowsException<Exception>(() => Solver.Solve(a: 0, b: 1, c: 2), $"Проверка на 0 коэффициента \"a\" провалена");
		}

		/// <summary>
		/// 11.С учетом того, что дискриминант тоже нельзя сравнивать с 0 через знак равенства,
		///  подобрать такие коэффициенты квадратного уравнения для случая одного корня кратности два, чтобы дискриминант был отличный от нуля,
		///  но меньше заданного эпсилон. Эти коэффициенты должны заменить коэффициенты в тесте из п. 7.
		/// </summary>
		[TestMethod]
		public void DiscriminantLessEps()
		{
			var res = Solver.Solve(a: 16, b: 8.000000001, c: 1);

			Assert.IsTrue(res.Length == 1, "Eps > D. Уравнение должно иметь 1 корень!");
		}

		/// <summary>
		/// 13.Посмотреть какие еще значения могут принимать числа типа double, кроме числовых и написать тест с их использованием на все коэффициенты. solve должен выбрасывать исключение.
		/// </summary>
		[TestMethod]
		public void AbnormalCoefficient()
		{
			Assert.ThrowsException<Exception>(() => Solver.Solve(a: double.NaN, b: double.NegativeInfinity, c: double.PositiveInfinity), $"Проверка некорректные коэффициенты провалена");
		}

	}
}
