using System;


namespace Financeira_Herenaça_Polimorfismo
{
    public class PessoaJuridica : Contrato
    {
        public string Cnpj { get; private set; }
        public string CadastroEstadual { get; private set; }

        public override decimal CalculaPrestação()
        {
            var prestacao = (Valor / Prazo) + 3;
            return prestacao;
        }

        public override void cadastro()
        {
            base.cadastro();
            Cnpj = Validacoes.InputCnpj();
            CadastroEstadual = Validacoes.InputCadastroEstadual();
        }

        public override void ExibirInfo()
        {
            base.ExibirInfo();
            Console.WriteLine($"Cnpj:{Cnpj}");
            Console.WriteLine($"Cdastro estadual:{CadastroEstadual}");
        }
    }
}
