
using TestesUnitarios.Desafio.Console.Services;

namespace TestesUnitarios.Desafio.Tests
{
	public class CalculadoraTests
	{
		readonly Calculadora _calculadora = new();

		[Theory]
		[InlineData(2, 2, 4)]
		[InlineData(-4, 2, -2)]
		[InlineData(-4, -2, -6)]
		[InlineData(6, 2, 8)]
		[InlineData(0, 2, 2)]
		[InlineData(2, 0, 2)]
		public void SomarDoisNumeros(int num1, int num2, int res)
		{
			int result = _calculadora.Somar(num1, num2);

			Assert.Equal(res, result);
		}

		[Theory]
		[InlineData(2, 2, 0)]
		[InlineData(-4, 2, -6)]
		[InlineData(-4, -2, -2)]
		[InlineData(6, 2, 4)]
		[InlineData(0, 2, -2)]
		[InlineData(2, 0, 2)]
		public void SubtrairDoisNumeros(int num1, int num2, int res)
		{
			int result = _calculadora.Subtrair(num1, num2);

			Assert.Equal(res, result);
		}

		[Theory]
		[InlineData(2, 2, 4)]
		[InlineData(-4, 2, -8)]
		[InlineData(-4, -2, 8)]
		[InlineData(6, 2, 12)]
		[InlineData(0, 2, 0)]
		[InlineData(2, 0, 0)]
		public void MultiplicarDoisNumeros(int num1, int num2, int res)
		{
			int result = _calculadora.Multiplicar(num1, num2);

			Assert.Equal(res, result);
		}

		[Theory]
		[InlineData(2, 2, 1)]
		[InlineData(-4, 2, -2)]
		[InlineData(-4, -2, 2)]
		[InlineData(6, 2, 3)]
		[InlineData(0, 2, 0)]
		[InlineData(2, 0, 0)]
		public void DividirDoisNumeros(int num1, int num2, int res)
		{
			int result = _calculadora.Dividir(num1, num2);

			if (num2 == 0) Assert.Equal(0, result);
			Assert.Equal(res, result);
		}

		[Fact]
		public void RetornaHistoricoVazio()
		{
			List<string> res = [];
			List<string> resultHistory = _calculadora.Historico();

			Assert.Equal(res, resultHistory);
		}

		[Fact]
		public void RetornaDoisHistoricos()
		{
			_calculadora.Multiplicar(2, 2);
			_calculadora.Dividir(2, 2);

			List<string> res = ["2 / 2 = 1", "2 * 2 = 4"];
			List<string> resultHistory = _calculadora.Historico();

			Assert.Equal(res, resultHistory);
		}


		[Fact]
		public void RetornaTresHistoricos()
		{
			_calculadora.Subtrair(2, 2);
			_calculadora.Multiplicar(2, 2);
			_calculadora.Dividir(2, 2);

			List<string> res = ["2 / 2 = 1", "2 * 2 = 4", "2 - 2 = 0"];
			List<string> resultHistory = _calculadora.Historico();

			Assert.Equal(res, resultHistory);
		}

		[Fact]
		public void RetornaMaximoTresHistoricos()
		{
			_calculadora.Somar(2, 2);
			_calculadora.Subtrair(2, 2);
			_calculadora.Multiplicar(2, 2);
			_calculadora.Dividir(2, 2);

			List<string> res = ["2 / 2 = 1", "2 * 2 = 4", "2 - 2 = 0"];
			List<string> resultHistory = _calculadora.Historico();

			Assert.Equal(res, resultHistory);
		}

		[Fact]
		public void RetornaHistoricoDividirZero()
		{
			_calculadora.Dividir(2, 0);
			_calculadora.Dividir(0, 2);

			List<string> res = ["0 / 2 = 0", "Atenção: divisão por 0"];
			List<string> resultHistory = _calculadora.Historico();

			Assert.Equal(res, resultHistory);
		}
	}
}