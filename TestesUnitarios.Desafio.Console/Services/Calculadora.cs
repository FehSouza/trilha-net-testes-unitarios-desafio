namespace TestesUnitarios.Desafio.Console.Services
{
	public class Calculadora
	{
		private readonly List<string> history;

		public Calculadora()
		{
			history = [];
		}

		public int Somar(int num1, int num2)
		{
			int res = num1 + num2;
			history.Insert(0, $"{num1} + {num2} = {res}");
			return res;
		}

		public int Subtrair(int num1, int num2)
		{
			int res = num1 - num2;
			history.Insert(0, $"{num1} - {num2} = {res}");
			return res;
		}

		public int Multiplicar(int num1, int num2)
		{
			int res = num1 * num2;
			history.Insert(0, $"{num1} * {num2} = {res}");
			return res;
		}

		public int Dividir(int num1, int num2)
		{
			if (num2 == 0)
			{
				history.Insert(0, "Atenção: divisão por 0");
				return 0;
			}

			int res = num1 / num2;
			history.Insert(0, $"{num1} / {num2} = {res}");
			return res;

		}

		public List<string> Historico()
		{
			int countList = history.Count;
			int lastItem = countList <= 3 ? countList : 3;

			return history.GetRange(0, lastItem);
		}
	}
}