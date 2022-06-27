using System;
using System.Text.RegularExpressions;


namespace Financeira_Herenaça_Polimorfismo
{
    public static class Validacoes
    {
        public static string InputContratante()
        {
            Console.WriteLine("Qual o nome do contratante?");
            var inptContratante = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(inptContratante))
            {
                Console.WriteLine("Entrada incorreta, tente novamente");
                return InputContratante();
            }
            else
                return inptContratante;
        }

        public static int InputPrazo()
        {
            Console.WriteLine("Qual o prazo do contrato em meses?");
            var inPrazo = Console.ReadLine();
            var correctPrazo = int.TryParse(inPrazo, out var inptPrazo);
            if (correctPrazo && inptPrazo > 0)
            {
                return inptPrazo;
            }
            else
            {
                Console.WriteLine("Informação incorreta, tente informar o prazo novamente");
                return InputPrazo();
            }
        }

        public static decimal InputValor()
        {
            Console.WriteLine("Qual o valor do contrato?");
            var inValor = Console.ReadLine();
            var correctValor = decimal.TryParse(inValor, out var inptValor);
            if (correctValor && inptValor > 0)
            {
                return inptValor;
            }
            else
            {
                Console.WriteLine("Informação incorreta, tente informar o valor novamente");
                return InputValor();
            }
        }

        public static bool DigitsValidCnpj(string cnpj)
        {
            int[] mult1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digit;
            string cnpjTemporario;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14 || cnpj == "00000000000000")
                return false;
            cnpjTemporario = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(cnpjTemporario[i].ToString()) * mult1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digit = resto.ToString();
            cnpjTemporario = cnpjTemporario + digit;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(cnpjTemporario[i].ToString()) * mult2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digit = digit + resto.ToString();
            return cnpj.EndsWith(digit);
        }

        public static string InputCnpj()
        {
            Console.WriteLine("Qual o CNPJ da empresa contratante?");
            var inptCnpj = Console.ReadLine();
            string pattern = @"(^\d{2}\d{3}\d{3}\d{4}\d{2}$)|(^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$)";
            var correctCnpj = Regex.IsMatch(inptCnpj, pattern);
            if (!String.IsNullOrWhiteSpace(inptCnpj))
            {
                var isCNPJ = DigitsValidCnpj(inptCnpj);
                if (isCNPJ && correctCnpj)
                {
                    return inptCnpj;
                }
                else
                {
                    Console.WriteLine("Informação incorreta, tente informar o CNPJ novamente");
                    return InputCnpj();
                }
            }
            else
            {
                Console.WriteLine("Informação incorreta, tente informar o CNPJ novamente");
                return InputCnpj();
            }

        }

        public static string InputCadastroEstadual()
        {
            Console.WriteLine("Qual o cadastro estadual da empresa contratante?(Ex. 000.000.000)");
            var inptCadastroEstadual = Console.ReadLine();
            string pattern = @"(^\d{3}\.\d{3}\.\d{3}$)|(^\d{3}\d{3}\d{3}$)";
            var correctCadastroEstadual = Regex.IsMatch(inptCadastroEstadual, pattern);
            if (!String.IsNullOrWhiteSpace(inptCadastroEstadual) && correctCadastroEstadual)
            {
                return inptCadastroEstadual;
            }
            else
            {
                Console.WriteLine("Informação incorreta, tente informar o cadastro estadual novamente");
                return InputCadastroEstadual();
            }
        }

        public static bool DigitsValidCpf(string cpf)
        {
            int[] mul1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string CpfTemporario;
            string digit;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11 || cpf == "00000000000" || cpf == "12345678909")
                return false;
            CpfTemporario = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(CpfTemporario[i].ToString()) * mul1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digit = resto.ToString();
            CpfTemporario = CpfTemporario + digit;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(CpfTemporario[i].ToString()) * mult2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digit = digit + resto.ToString();
            return cpf.EndsWith(digit);
        }

        public static string InputCpf()
        {
            Console.WriteLine("Qual o CPF do contratante?");
            var inptCpf = Console.ReadLine();
            string pattern = @"(^\d{3}\.\d{3}\.\d{3}\-\d{2}$)|(^\d{3}\d{3}\d{3}\d{2}$)";
            var correctCpf = Regex.IsMatch(inptCpf, pattern);
            if (!String.IsNullOrWhiteSpace(inptCpf))
            {
                var isCpf = DigitsValidCpf(inptCpf);
                if (isCpf && correctCpf)
                {
                    return inptCpf;
                }
                else
                {
                    Console.WriteLine("Informação incorreta, tente informar o CPF novamente");
                    return InputCpf();
                }
            }
            else
            {
                Console.WriteLine("Informação incorreta, tente informar o CPF novamente");
                return InputCpf();
            }

        }

        public static DateTime InputDataNascimento()
        {
            Console.WriteLine("Qual a data de nascimento do contratante?");
            var inData = Console.ReadLine();
            var correcctData = DateTime.TryParse(inData, out var inptData);
            if (correcctData && inptData.Year < (DateTime.Now.Year - 15) && inptData.Year > (DateTime.Now.Year - 120))
            {
                return inptData;
            }
            else
            {
                Console.WriteLine("Entrada inválida ou contratante menor de 16 anos, tente novamnete");
                return InputDataNascimento();
            }
        }

    }
}


