using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class Home
    {
        public static void getCabecalho()
        {
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("|      TRABALHO PRÁTICO - GRAFOS                 |");
            Console.WriteLine("|ARTHUR SIQUEIRA- DANILO OLIVEIRA - DIONI BATISTA|");
            Console.WriteLine("|                                                |");
            Console.WriteLine("+------------------------------------------------+");
        }
        public static void getMenuNaoDirigido()
        {
            Console.WriteLine("|           % MENU NÃO DIRIGIDO %                |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|SELECIONE A FUNÇÃO A SER EXECUTADA:             |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|1 - Validar se os Vertices são ADJACENTES.      |");
            Console.WriteLine("|2 - Quantidade de GRAU do vértice.              |");
            Console.WriteLine("|3 - Vértice é ISOLADO.                          |");
            Console.WriteLine("|4 - Vértice é PENDENTE.                         |");
            Console.WriteLine("|5 - Grafo é REGULAR.                            |");
            Console.WriteLine("|6 - Grafo é COMPLEXO.                           |");
            Console.WriteLine("|7 - Grafo é CONEXO.                             |");
            Console.WriteLine("|8 - Grafo é EULERIANO.                          |");
            Console.WriteLine("|9 - Grafo é UNICURSAL.                          |");
            Console.WriteLine("|10 - Grafo é COMPLEMENTAR.             |");
            Console.WriteLine("|11 - Quantidade cut vértices.          |");
            Console.WriteLine("+------------------------------------------------+");
        }
        public static void getMenuDirigido()
        {
            Console.WriteLine("|             % MENU DIRIGIDO %                  |");
            Console.WriteLine("|SELECIONE A FUNÇÃO A SER EXECUTADA:             |");
            Console.WriteLine("|1 - Quantidade GRAU DE ENTRADA do vértice.      |");
            Console.WriteLine("|2 - Quantidade GRAU DE SAÍDA do vértice.        |");
            Console.WriteLine("|3 - Grafo possui CICLO.                         |");
            Console.WriteLine("+------------------------------------------------+");
        }

    }
}
