using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios01
{
    internal class Recepcionista
    {
        public string Nome { get; set; }

        public void InformaNome(string tipo)
        {
            do
            {
                Console.WriteLine("Informe o seu primeiro nome: ");
                Nome = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(Nome))
                {
                    return;
                }
                Console.WriteLine("É necessário informar um nome válido. Tente novamente:");
            } while (string.IsNullOrWhiteSpace(Nome));
        }
        public void Recepcionar(string nome)
        {
            Console.WriteLine($"Olá, {nome}! Seja muito bem - vindo!");
        }
    }


}