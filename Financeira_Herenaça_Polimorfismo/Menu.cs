using System;

namespace Financeira_Herenaça_Polimorfismo
{
    public static class Menu
    {
        

        public static void MenuIniciar()
        {           
            PessoaFisica fisica = new PessoaFisica();
            PessoaJuridica juridica = new PessoaJuridica();

            var selectCategory = false;
            while (!selectCategory)
            {
                Console.Clear();
                Console.WriteLine("Que tipo de contrato será cadastrado\nDigite:\n1-Pessoa fisica\n2-Pessoa jurídica\n5-Sair");
                var inputCategory = Console.ReadLine();
                switch (inputCategory)
                {
                    case "1":
                        fisica.cadastro();
                        fisica.ExibirInfo();
                        Console.WriteLine("Aperte qualquer tecla para continuar");
                        Console.ReadLine();
                        break;
                    case "2":
                        juridica.cadastro();
                        juridica.ExibirInfo();
                        Console.WriteLine("Aperte qualquer tecla para continuar");
                        Console.ReadLine();
                        break;
                        case"5":
                        Console.WriteLine("Aperte qualquer tecla para sair");
                        Console.ReadLine();
                        selectCategory = true;
                        break;
                    default:
                        Console.WriteLine("Entrada incorreta, tente novamente");
                        break;
                }
            }
        }

    }
}
