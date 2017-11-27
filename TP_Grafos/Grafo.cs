using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class Grafo
    {
        protected List<Aresta> vertices = new List<Aresta>();
        protected int totalVerticesGrafo = 0;

        public Grafo() { }

        /// <summary>
        /// Metodo Imprime grafo
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            string retorno = "";
            foreach (Aresta a in this.vertices)
            {
                retorno += " | " + a.getIniVertice().getNome() + " -> " + (a.getFimVertice() == null ? "" : a.getFimVertice().getNome());
            }
            return retorno;
        }

        public virtual string setResposta(string respString)
        {
            return respString;
        }
    }
}
