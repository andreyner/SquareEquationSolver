using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SquareEquationSolver.Testing
{
	[TestClass]
	public class UnitTest1
	{
		/// <summary>
		/// 3.�������� ����, ������� ���������, ��� ��� ��������� x^2+1 = 0 ������ ��� (������������ ������ ������)
		/// </summary>
		[TestMethod]
		public void DiscriminantLessZero()
		{
			var res = Solver.Solve(a: 1, b: 0, c: 1);

			Assert.IsTrue(res.Length == 0, "����������� < 0, �� ����� ��������� ����������!");
		}

		/// <summary>
		/// 5.�������� ����, ������� ���������, ��� ��� ��������� x^2-1 = 0 ���� ��� ����� ��������� 1 (x1=1, x2=-1)
		/// </summary>
		[TestMethod]
		public void TwoSolution()
		{
			var res = Solver.Solve(a: 1, b: 0, c: -1);

			Assert.IsTrue(res.Length == 2, "��������� ������ ����� 2 �����!");
		}

		/// <summary>
		/// 7.�������� ����, ������� ���������, ��� ��� ��������� x^2+2x+1 = 0 ���� ���� ������ ��������� 2 (x1= x2 = -1).
		/// </summary>
		[TestMethod]
		public void OneSolution()
		{
			var res = Solver.Solve(a: 1, b: 2, c: 1);

			Assert.IsTrue(res.Length == 1, "��������� ������ ����� 1 ������!");
		}

		/// <summary>
		/// 9.�������� ����, ������� ���������, ��� ����������� a �� ����� ���� ����� 0. � ���� ������ solve ����������� ����������.
		/// ����������.������, ��� a ����� ��� double � ���������� � 0 ����� == ������.
		/// </summary>
		[TestMethod]
		public void RateAIsZero()
		{
			Assert.ThrowsException<Exception>(() => Solver.Solve(a: 0, b: 1, c: 2), $"�������� �� 0 ������������ \"a\" ���������");
		}

		/// <summary>
		/// 11.� ������ ����, ��� ������������ ���� ������ ���������� � 0 ����� ���� ���������,
		///  ��������� ����� ������������ ����������� ��������� ��� ������ ������ ����� ��������� ���, ����� ������������ ��� �������� �� ����,
		///  �� ������ ��������� �������. ��� ������������ ������ �������� ������������ � ����� �� �. 7.
		/// </summary>
		[TestMethod]
		public void DiscriminantLessEps()
		{
			var res = Solver.Solve(a: 16, b: 8.000000001, c: 1);

			Assert.IsTrue(res.Length == 1, "Eps > D. ��������� ������ ����� 1 ������!");
		}

		/// <summary>
		/// 13.���������� ����� ��� �������� ����� ��������� ����� ���� double, ����� �������� � �������� ���� � �� �������������� �� ��� ������������. solve ������ ����������� ����������.
		/// </summary>
		[TestMethod]
		public void AbnormalCoefficient()
		{
			Assert.ThrowsException<Exception>(() => Solver.Solve(a: double.NaN, b: double.NegativeInfinity, c: double.PositiveInfinity), $"�������� ������������ ������������ ���������");
		}

	}
}
