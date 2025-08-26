using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios01
{
    internal class Contador
    {
        public string Palavra { get; set; }
        public void Contar()
        {
            Console.WriteLine("Digite uma ou mais palavras: ");
            Palavra = Console.ReadLine();

            Console.WriteLine($"A palavra {Palavra} possui {ContaCaracteres(Palavra)} caracteres.");
        }

        public int ContaCaracteres(string palavra)
        {
            var count = 0;
            foreach (var x in palavra)
            {
                if (x != ' ')
                {
                    count++;
                }
            }
            return count;
        }
    }
}