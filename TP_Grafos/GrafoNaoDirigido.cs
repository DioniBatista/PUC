using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class GrafoNaoDirigido : Grafo
    {
        public GrafoNaoDirigido(List<string> entradas)
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
                    Aresta aresta = new Aresta(vertice, vertice2, peso);
                    this.vertices.Add(aresta);
                }
            }
        }
        /// <summary>
        /// Valida se vertices sao adjacentes.
        /// Vertices adjacente eh quando ha um vertice conectado a outro.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public bool isAdjacente(string v1, string v2)
        {
            foreach(Aresta aresta in this.vertices){
                if(aresta.getIniVertice().getNome().Equals(v1) && aresta.getFimVertice().getNome().Equals(v2)){
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Retorna o grau do vertice.
        /// Quantas "conexos" ele possui.
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public int getGrau(string v1)
        {
            int grau = 0;
            foreach (Aresta aresta in this.vertices)
            {
                if (aresta.getFimVertice() != null && (aresta.getIniVertice().getNome().Equals(v1) || aresta.getFimVertice().getNome().Equals(v1)))
                {
                    grau++;
                }
            }
            return grau;
        }
        /// <summary>
        /// retorna se vertice eh isolado.
        /// Quando possui grau igual a 0, nao conectado a outros vertices.
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public bool isIsolado(string v1)
        {
            return getGrau(v1) == 0 ? true : false;
        }
        /// <summary>
        /// Retorna se vertice eh pendente.
        /// Quanto possui grau igual a 1 e eh uma folha(ultimo da arvore)
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public bool isPendente(string v1)
        {
            foreach (Aresta aresta in this.vertices)
            {
                if ((!aresta.getIniVertice().getNome().Equals(v1) && aresta.getFimVertice().getNome().Equals(v1)) 
                    && getGrau(v1) == 1)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Retorna se grafo eh regular.
        /// Todos vertices contendo mesmo valor de grau.
        /// </summary>
        /// <returns></returns>
        public bool isRegular()
        {
            int grauDefault = 0;
            foreach (Aresta aresta in this.vertices)
            {
                if(grauDefault == 0){
                  grauDefault = getGrau(aresta.getIniVertice().getNome());
                }
                else if (grauDefault != getGrau(aresta.getIniVertice().getNome()))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Retorna se grafo é completo
        /// Quando os graus sao iguais e todos vertices
        /// sao interligados entre si
        /// </summary>
        /// <returns></returns>
        public bool isCompleto()
        {
            //n(n-1)/2
            double maxVertice = (this.totalVerticesGrafo*(this.totalVerticesGrafo - 1))/2;
            double totalAresta = getTotalAresta();
            //maximo de vertices iguais e numero de grau iguais
            return (maxVertice == totalAresta) && isRegular(); 
        }
        /// <summary>
        /// Retorna se Grafo é conexo
        /// Quando em cada par de vertices há um caminho
        /// </summary>
        /// <returns></returns>
        public bool isConexo()
        {
            foreach (Aresta aresta in this.vertices)
            {
                if (aresta.getIniVertice() == null || aresta.getFimVertice() == null)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Retorna se Grafo é Euleriano
        /// Qunaod o grau dos vertices é par e grafo é conexo
        /// </summary>
        /// <returns></returns>
        public bool isEuleriano()
        {
            foreach (Aresta aresta in this.vertices)
            {
                int grau1 = this.getGrau(aresta.getIniVertice().getNome());
                int grau2 = -1;
                if(aresta.getFimVertice() != null){
                    grau2 = this.getGrau(aresta.getFimVertice().getNome());
                }
                
                if(!(isPar(grau1) && (grau2 != -1 && isPar(grau2)))){
                    return false;
                }
            }
            return true && this.isConexo();
        }
        /// <summary>
        /// Retorna se grafo é Unicursal
        /// Se possui 2 vertices com grau impar
        /// </summary>
        /// <returns></returns>
        public bool isUnicursal()
        {
            int cont = 0;
            List<string> verticesValidados = new List<string>();
            foreach (Aresta aresta in this.vertices)
            {
                int grau1 = this.getGrau(aresta.getIniVertice().getNome());
                int grau2 = 0;
                if (aresta.getFimVertice() != null)
                {
                    grau2 = this.getGrau(aresta.getFimVertice().getNome());
                }

                if (!isPar(grau1) && !verticesValidados.Contains(aresta.getIniVertice().getNome()))
                {
                    cont++;
                    verticesValidados.Add(aresta.getIniVertice().getNome());
                }
                if (!isPar(grau2) && !verticesValidados.Contains(aresta.getFimVertice().getNome()))
                {
                    cont++;
                    verticesValidados.Add(aresta.getFimVertice().getNome());
                }
            }
            return cont == 2;
        }
        /// <summary>
        /// Retorna se grafo é complementar
        /// </summary>
        /// <returns></returns>
        public double isComplementar()
        {
            //(n(n-1)/2) - aresta
            double maxVertice = (this.totalVerticesGrafo * (this.totalVerticesGrafo - 1)) / 2;
            double totalAresta = getTotalAresta();
            //retorna qtidade faltante para ser grafo completo
            return maxVertice - totalAresta; ;
        }

        public bool isPar(int num){
            return (num % 2) == 0;
        }
        public double getTotalAresta()
        {
            double total = 0;
            foreach(Aresta a in this.vertices)
            {
                if (a.getIniVertice() != null && a.getFimVertice() != null)
                {
                    total++;
                }
            }
            return total;
        }
        public override string setResposta(string respString)
        {
            try
            {
                int resp = int.Parse(respString);
                switch (resp)
                {
                    case 1: return this.preIsAdjacente();
                    case 2: return this.preGetGrau();
                    case 3: return this.preIsIsolado();
                    case 4: return this.preIsPendente();
                    case 5: return this.preIsRegular();
                    case 6: return this.preIsCompleto();
                    case 7: return this.preIsConexo();
                    case 8: return this.preIsEuleriano();
                    case 9: return this.preIsUnicursal();
                    case 10: return this.preComplementar();
                     /*case 11: this.preGetCutVertices();
                         break;*/
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

        private void preGetCutVertices()
        {
            throw new NotImplementedException();
        }

        private string preComplementar()
        {
            Console.Clear();
            Home.getCabecalho();
            Console.WriteLine("|       Verifica o Grafo é Complementar.           |");
            Console.WriteLine("+------------------------------------------------+");
            double retorno = this.isComplementar();
            Console.WriteLine();
            Console.WriteLine(retorno != 0 ? "Para ser Completo deve-se adicionar um subgrafo COMPLEMENTAR com "+retorno+" arestas" : "O grafo " + this.toString() + " não necessita de COMPLEMENTO!");
            Console.WriteLine();
            Console.WriteLine("Pressione 0 (zero) para sair ou qualquer tecla para voltar ao MENU");
            return Console.ReadLine();
        }

        private string preIsUnicursal()
        {
            Console.Clear();
            Home.getCabecalho();
            Console.WriteLine("|       Verifica o Grafo é Unicursal.           |");
            Console.WriteLine("+------------------------------------------------+");
            bool retorno = this.isUnicursal();
            Console.WriteLine();
            Console.WriteLine(retorno ? "O grafo " + this.toString() + " é Unicursal! " : "O grafo " + this.toString() + " não é Unicursal!");
            Console.WriteLine();
            Console.WriteLine("Pressione 0 (zero) para sair ou qualquer tecla para voltar ao MENU");
            return Console.ReadLine();
        }

        private string preIsEuleriano()
        {
            Console.Clear();
            Home.getCabecalho();
            Console.WriteLine("|       Verifica o Grafo é Euleriano.           |");
            Console.WriteLine("+------------------------------------------------+");
            bool retorno = this.isEuleriano();
            Console.WriteLine();
            Console.WriteLine(retorno ? "O grafo " + this.toString() + " é Euleriano! " : "O grafo " + this.toString() + " não é Euleriano!");
            Console.WriteLine();
            Console.WriteLine("Pressione 0 (zero) para sair ou qualquer tecla para voltar ao MENU");
            return Console.ReadLine();
        }

        private string preIsConexo()
        {
            Console.Clear();
            Home.getCabecalho();
            Console.WriteLine("|       Verifica o Grafo é Conexo.           |");
            Console.WriteLine("+------------------------------------------------+");
            bool retorno = this.isConexo();
            Console.WriteLine();
            Console.WriteLine(retorno ? "O grafo " + this.toString() + " é Conexo! " : "O grafo " + this.toString() + " não é Conexo!");
            Console.WriteLine();
            Console.WriteLine("Pressione 0 (zero) para sair ou qualquer tecla para voltar ao MENU");
            return Console.ReadLine();
        }

        private string preIsCompleto()
        {
            Console.Clear();
            Home.getCabecalho();
            Console.WriteLine("|       Verifica o Grafo é Completo.           |");
            Console.WriteLine("+------------------------------------------------+");
            bool retorno = this.isCompleto();
            Console.WriteLine();
            Console.WriteLine(retorno ? "O grafo " + this.toString() + " é Completo! " : "O grafo " + this.toString() + " não é Completo!");
            Console.WriteLine();
            Console.WriteLine("Pressione 0 (zero) para sair ou qualquer tecla para voltar ao MENU");
            return Console.ReadLine();
        }

        private string preIsRegular()
        {
            Console.Clear();
            Home.getCabecalho();
            Console.WriteLine("|       Verifica se o grafo é Regular.           |");
            Console.WriteLine("+------------------------------------------------+");
            bool retorno = this.isRegular();
            Console.WriteLine();
            Console.WriteLine(retorno ? "O grafo " + this.toString() + " é Regular! " : "O grafo " + this.toString() + " não é Regular!");
            Console.WriteLine();
            Console.WriteLine("Pressione 0 (zero) para sair ou qualquer tecla para voltar ao MENU");
            return Console.ReadLine();
        }

        private string preIsPendente()
        {
            Console.Clear();
            Home.getCabecalho();
            Console.WriteLine("|       Verifica se vértice é Pendente.           |");
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("Digite o nome do Vértice: ");
            string v1 = Console.ReadLine();
            bool retorno = this.isPendente(v1);
            Console.WriteLine();
            Console.WriteLine(retorno ? "O vértice " + v1 + " é pendente! " : "O vértice " + v1 + " não é pendente!");
            Console.WriteLine();
            Console.WriteLine("Pressione 0 (zero) para sair ou qualquer tecla para voltar ao MENU");
            return Console.ReadLine();
        }

        private string preIsIsolado()
        {
            Console.Clear();
            Home.getCabecalho();
            Console.WriteLine("|       Verifica se vértice é Isolado.           |");
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("Digite o nome do Vértice: ");
            string v1 = Console.ReadLine();
            bool retorno = this.isIsolado(v1);
            Console.WriteLine();
            Console.WriteLine(retorno ? "O vértice " + v1 + " é isolado! " : "O vértice " + v1 + " não é isolado!");
            Console.WriteLine();
            Console.WriteLine("Pressione 0 (zero) para sair ou qualquer tecla para voltar ao MENU");
            return Console.ReadLine();
        }

        private string preGetGrau()
        {
            Console.Clear();
            Home.getCabecalho();
            Console.WriteLine("|       Quantidade de GRAU do vértice.           |");
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("Digite o nome do Vértice: ");
            string v1 = Console.ReadLine();
            int retorno = this.getGrau(v1);
            Console.WriteLine();
            Console.WriteLine("O vértice " + v1 + " possui " + retorno + " graus");
            Console.WriteLine();
            Console.WriteLine("Pressione 0 (zero) para sair ou qualquer tecla para voltar ao MENU");
            return Console.ReadLine();

        }

        private string preIsAdjacente()
        {
            Console.Clear();
            Home.getCabecalho();
            Console.WriteLine("|       Validar se Vertice são ADJACENTES        |");
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("Digite o nome do 1° Vértice: ");
            string v1 = Console.ReadLine();
            Console.WriteLine("Digite o nome do 2° Vértice: ");
            string v2 = Console.ReadLine();

            bool retorno = this.isAdjacente(v1,v2);
            Console.WriteLine();
            Console.WriteLine(retorno ? "   Os vértices " + v1 + " e " + v2 + " são adjacentes!" : 
                "Os vértices " + v1 + " e " + v2 + " não são adjacentes!");
            Console.WriteLine();
            Console.WriteLine("Pressione 0 (zero) para sair ou qualquer tecla para voltar ao MENU");
            return Console.ReadLine();
        }
    }
}
