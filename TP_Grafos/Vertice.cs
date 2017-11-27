using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class Vertice
    {
        private string nome;
        private List<Aresta> adjacentes = new List<Aresta>();

        public Vertice(string n)
        {
            this.nome = n;
        }
        public string getNome()
        {
            return this.nome;
        }
    }
}
