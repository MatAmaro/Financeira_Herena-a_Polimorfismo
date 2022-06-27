using System;


namespace Financeira_Herenaça_Polimorfismo
{
    public abstract class Contrato 

    {
        public Guid IdContrato { get; } = Guid.NewGuid();
        public string Contratante { get; private set; }
        public int Prazo { get; private set; }
        public decimal Valor { get; private set; }
        public decimal ValorPrestação { get { return CalculaPrestação(); } }


        public abstract decimal CalculaPrestação();

        public virtual void cadastro()
        {
            Contratante = Validacoes.InputContratante();
            Prazo = Validacoes.InputPrazo();
            Valor = Validacoes.InputValor();
        }
        public virtual void ExibirInfo()
        {
            Console.Clear();
            Console.WriteLine($"Contratante: {Contratante}");
            Console.WriteLine($"Id do contrato: {IdContrato}");
            Console.WriteLine($"Valor do contrato: R${Valor:f2}");
            Console.WriteLine($"Prazo: {Prazo} meses");
            Console.WriteLine($"Valor da prestação: R${ValorPrestação:f2}");
        }
    }
}
