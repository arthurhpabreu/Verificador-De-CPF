using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificadorCPF
{
	class Program
	{
		public static bool Valida(string cpf)

		{

			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

			string tempCpf;

			string digito;

			int soma;

			int resto;

			cpf = cpf.Trim();

			cpf = cpf.Replace(".", "").Replace("-", "");

			if (cpf.Length != 11)

				return false;

			tempCpf = cpf.Substring(0, 9);

			soma = 0;

			for (int i = 0; i < 9; i++)

				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

			resto = soma % 11;

			if (resto < 2)

				resto = 0;

			else

				resto = 11 - resto;

			digito = resto.ToString();

			tempCpf = tempCpf + digito;

			soma = 0;

			for (int i = 0; i < 10; i++)

				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

			resto = soma % 11;

			if (resto < 2)

				resto = 0;

			else

				resto = 11 - resto;

			digito = digito + resto.ToString();

			return cpf.EndsWith(digito);

		}
		static void Main(string[] args)
		{
			Console.WriteLine("Entre com o CPF(XXX.XXX.XXX-XX:");
			string cpf = Console.ReadLine();
			if (Valida(cpf) == true)
			{
				Console.WriteLine("CPF válido");
			}
			else
			{
				Console.WriteLine("CPF inválido");
			}
			Console.WriteLine("aperte ENTER para sair");
			Console.ReadKey();
			
		}
	}
}
