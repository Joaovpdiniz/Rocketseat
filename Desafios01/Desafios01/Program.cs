using System;

namespace Desafios01
{
    class Program
    {
        static void Main(string[] args)
        {
            Recepcionista recepciona = new Recepcionista();
            Concatenador concatenador = new Concatenador();
            Calcular calcular = new Calcular();
            Contador contador = new Contador();
            PlacaVeiculo placaVeiculo = new PlacaVeiculo();
            DataAtual dataAtual = new DataAtual();

            dataAtual.InformaData();

            //placaVeiculo.Validador();
            // contador.Contar();
            // calcular.Executar();
            // concatenador.Concatenar();
            // recepciona.InformaNome();
            // recepciona.Recepcionar();
        }
    }

}
