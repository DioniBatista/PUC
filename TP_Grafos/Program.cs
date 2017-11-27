using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class Program
    {
        public static  List<Grafo> carregaGrafos(List<string> entradas)
        {
            List<Grafo> retorno = new List<Grafo>();
            List<string> dadosGrafo = new List<string>();
            for (int i =0; i < entradas.Count; i++)
            {
                if (!entradas[i].Contains(';'))
                {
                    dadosGrafo = new List<string>();
                    int j = i+1;
                    int numVertices = int.Parse(entradas[i]) ;
                    dadosGrafo.Add("#" + numVertices);
                    while(numVertices > 0){                        
                        dadosGrafo.Add(entradas[j]);
                        j++;
                        numVertices--;
                    }
                    string[] vetor = dadosGrafo[1].Split(';');
                    if (vetor.Length == 3)
                    {
                       retorno.Add(new GrafoNaoDirigido(dadosGrafo));
                    }
                    else
                    {
                         retorno.Add(new GrafoDirigido(dadosGrafo));
                    }
                    
                    i += j-1;
                }
            }
            return retorno;
        }
        static void Main(string[] args)
        {
            List<string> dadosLidosList = LerArquivo.carregar();
            List<Grafo> grafosList = carregaGrafos(dadosLidosList);
            string resp = "";
            Grafo gd = null;
            if (grafosList[0].GetType().Equals(typeof(GrafoNaoDirigido)))
            {
               gd = (GrafoNaoDirigido)grafosList[0];
            }
            else
            {
                gd = (GrafoDirigido)grafosList[0];
            }
            do
            {
                Console.Clear();
                Home.getCabecalho();
                Home.getMenuDirigido();
                resp = gd.setResposta(Console.ReadLine());

            } while (!resp.Equals("0"));
            
        }
    }
}
