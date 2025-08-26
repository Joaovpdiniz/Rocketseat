using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios01
{
    internal class Concatenador
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }

        public void Concatenar()
        {
            Recepcionista recepciona = new Recepcionista();

            recepciona.InformaNome("Primeiro Nome: ");
            Nome = recepciona.Nome;

            recepciona.InformaNome("Sobre Nome: ");
            SobreNome = recepciona.Nome;

            var nomeCompleto = Nome + " " + SobreNome;

            recepciona.Recepcionar(nomeCompleto);
        }



    }

}