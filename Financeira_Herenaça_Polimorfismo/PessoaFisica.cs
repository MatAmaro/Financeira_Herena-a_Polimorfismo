using System;

namespace Financeira_Herenaça_Polimorfismo
{
    public class PessoaFisica : Contrato
    {
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int Idade { get { return CalculaIdade(); } }

        public int Adicional { get { return CalculaAdicional(Idade); } }

        public int CalculaIdade()
        {
            if (DataNascimento.Month > DateTime.Now.Month)
            {
                return (DateTime.Now.Year - DataNascimento.Year) - 1;
            }
            else
            {
                if (DataNascimento.Month < DateTime.Now.Month)
                {
                    return (DateTime.Now.Year - DataNascimento.Year);
                }
                else
                {
                    if (DataNascimento.Day < DateTime.Now.Day)
                    {
                        return (DateTime.Now.Year - DataNascimento.Year);
                    }
                    else
                    {
                        return (DateTime.Now.Year - DataNascimento.Year) - 1;
                    }
                }
            }
        }

        public int CalculaAdicional(int idade)
        {
            int adicional;
            switch (idade)
            {
                case <= 30:
                    adicional = 1;
                    break;
                case <= 40:
                    adicional = 2;
                    break;
                case <= 50:
                    adicional = 3;
                    break;
                case > 50:
                    adicional = 4;
                    break;
            }
            return adicional;
        }

        public override decimal CalculaPrestação()
        {
            var prestacao = (Valor / Prazo) + Adicional;
            return prestacao;

        }

        public override void cadastro()
        {
            base.cadastro();
            Cpf = Validacoes.InputCpf();
            DataNascimento = Validacoes.InputDataNascimento();
        }

        public override void ExibirInfo()
        {           
            base.ExibirInfo();
            Console.WriteLine($"Idade do contratante:{Idade} anos");
            Console.WriteLine($"Cpf:{Cpf}");
        }
    }
}
