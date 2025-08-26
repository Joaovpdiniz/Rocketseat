using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios01
{
    internal class PlacaVeiculo
    {
        public string Placa { get; set; }

        public void Validador()
        {
            RecebeValor();
            if (Placa != null && Placa.Length != 7) 
            {
                Console.WriteLine("Falso");
            }

            for (int i = 0; i < 3; i++) 
            {
                if (!char.IsLetter(Placa[i]))
                {
                    Console.WriteLine("Falso");
                    return;
                }
            }

            for (int i = 3; i < 7; i++) 
            {
                if (!char.IsDigit(Placa[i]))
                {
                    Console.WriteLine("Falso");
                }
            }

            Console.WriteLine("Verdadeiro");
        }

        public string RecebeValor()
        {
            Console.WriteLine("Informe o numero da placa do veiculo: ");
            return Placa = Console.ReadLine().ToUpper();
        }
    }
}