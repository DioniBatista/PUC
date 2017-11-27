using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class LerArquivo
    {
        public static List<string> carregar()
        {
            //cria uma lista para armazenar os dados encontrados no documento
            List<string> dados = new List<string>();
            // indica qual o caminho do documento usei caminho padrão: \bin\Debug
            string filePath = "Arquivo.txt";
            //declara uma variável para receber linha por linha do doc
            string linha;
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while ((linha = reader.ReadLine()) != null)
                    {
                        dados.Add(linha);
                    }
                    return dados;
                }
            }
            else
            {
                //caso não encontre nenhum registro da a mensagem abaixo
                Console.WriteLine("Nenhum registro encontrado!");
                return null;
            }
        }
    }
}
