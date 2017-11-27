using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class GrafoDirigido : Grafo
    {
        public GrafoDirigido(List<string> entradas)
        {
            foreach (string ent in entradas)
            {
                if (ent.Contains("#"))
                {
                    this.totalVerticesGrafo = int.Parse(ent.Substring(1, ent.Length - 1));
                }
                else
                {
                    string[] vetor = ent.Split(';');

                    Vertice vertice = vetor[0].Equals("") ? null : new Vertice(vetor[0]);
                    Vertice vertice2 = vetor[1].Equals("") ? null : new Vertice(vetor[1]);
                    double peso = vetor[2].Equals("") ? 0 : double.Parse(vetor[2]);
                    //trataento em caso de nao definir valor
                    int dir = vetor[3].Equals("") ? 0 : int.Parse(vetor[3]);
                    Aresta aresta = null;
                    if (dir == -1)
                    {
                        aresta = new Aresta(vertice2, vertice, peso);
                    }
                    else if (dir == 1)
                    {
                        aresta = new Aresta(vertice, vertice2, peso);
                    }
                    this.vertices.Add(aresta);
                }
            }
        }

        /// <summary>
        /// Retorna o grau Entrada do vertice.
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public int getGrauEntrada(string v1)
        {
            int grau = 0;
            foreach (Aresta aresta in this.vertices)
            {
                if (aresta.getFimVertice() != null && (aresta.getFimVertice().getNome().Equals(v1)))
                {
                    grau++;
                }
            }
            return grau;
        }

        /// <summary>
        /// Retorna o grau Saida do vertice.
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public int getGrauSaida(string v1)
        {
            int grau = 0;
            foreach (Aresta aresta in this.vertices)
            {
                if (aresta.getIniVertice().getNome().Equals(v1))
                {
                    grau++;
                }
            }
            return grau;
        }

        public override string setResposta(string respString)
        {
            try
            {
                int resp = int.Parse(respString);
                switch (resp)
                {
                    case 1: return this.preGetGrauEntrada();
                    case 2: return this.preGetGrauSaida();
                    case 3: return this.preHasCiclo();
                    default: return "";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao converter resposta" + e);
                return "0";
            }
        }
        //METODOS 'PRE' PARA TRATAR COMUNICACAO COM USUARIO

        private string preHasCiclo()
        {
            throw new NotImplementedException();
        }

        private string preGetGrauSaida()
        {
            Console.Clear();
            Home.getCabecalho();
            Console.WriteLine("|       Quantidade de GRAU SAIDA do vértice.           |");
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("Digite o nome do Vértice: ");
            string v1 = Console.ReadLine();
            int retorno = this.getGrauSaida(v1);
            Console.WriteLine();
            Console.WriteLine("O vértice " + v1 + " possui " + retorno + " graus de Saída");
            Console.WriteLine();
            Console.WriteLine("Pressione 0 (zero) para sair ou qualquer tecla para voltar ao MENU");
            return Console.ReadLine();
        }

        private string preGetGrauEntrada()
        {
            Console.Clear();
            Home.getCabecalho();
            Console.WriteLine("|       Quantidade de GRAU ENTRADA do vértice.           |");
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("Digite o nome do Vértice: ");
            string v1 = Console.ReadLine();
            int retorno = this.getGrauEntrada(v1);
            Console.WriteLine();
            Console.WriteLine("O vértice " + v1 + " possui " + retorno + " graus de Entrada");
            Console.WriteLine();
            Console.WriteLine("Pressione 0 (zero) para sair ou qualquer tecla para voltar ao MENU");
            return Console.ReadLine();
        }
    }
}
