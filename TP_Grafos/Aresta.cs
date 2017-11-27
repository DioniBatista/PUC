using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class Aresta
    {
        private double peso;
        private Vertice ini_Vertice;
        private Vertice fim_Vertice;
        private int direcao = 0;

        public Aresta(Vertice v1, Vertice v2, double peso)
        {
            this.ini_Vertice = v1;
            this.fim_Vertice = v2;
            this.peso = peso;
        }
        public Aresta(Vertice v1, Vertice v2, double peso, int direcao)
        {
            this.ini_Vertice = v1;
            this.fim_Vertice = v2;
            this.peso = peso;
            this.direcao = direcao;
        }

        public double getPeso()
        {
            return this.peso;
        }
        public Vertice getIniVertice()
        {
            return this.ini_Vertice;
        }
        public Vertice getFimVertice()
        {
            return this.fim_Vertice;
        }
    }
}
