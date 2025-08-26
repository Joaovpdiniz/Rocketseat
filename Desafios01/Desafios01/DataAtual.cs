using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios01
{
    internal class DataAtual
    {
        public DateTime DataAgora { get; set; }

        public void InformaData()
        {
            DataAgora = DateTime.Now;
            var formato = SelecionaFormato();
            switch (formato)
            {
                case 1:
                    Console.WriteLine(DataAgora.ToString());
                    break;
                case 2:
                    Console.WriteLine(DataAgora.ToString("dd/MM/yyyy"));
                    break;
                case 3:
                    Console.WriteLine(DataAgora.ToString("HH:mm"));
                    break;
                case 4:
                    Console.WriteLine(DataAgora.ToString("dd 'de' MMMM 'de' yyyy"));
                    break;
            }
        }



        public int SelecionaFormato()
        {
            Console.WriteLine("Selecione o formato de data desejado:");
            Console.WriteLine("1 - Formato completo");
            Console.WriteLine("2 - Apenas Data (dd/MM/yyyy)");
            Console.WriteLine("3 - Apenas Hora (24h)");
            Console.WriteLine("4 - Data com mês por extenso");

            var tipoFormato = 0;
            tipoFormato = int.Parse(Console.ReadLine());

            return tipoFormato;
        }
    }
}
