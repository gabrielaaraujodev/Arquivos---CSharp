using System;
using System.Text;
using System.IO;

namespace Arquivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string lerLinha = "";
            try
            {
                StreamReader cidades = new StreamReader("C:\\Cidades\\Informações de cidades.txt", Encoding.UTF8);
                StreamWriter cidadesFiltradas = new StreamWriter("C:\\Cidades\\cidadesPequenas.txt", true, Encoding.UTF8);
                lerLinha = cidades.ReadLine();

                while (lerLinha != null)
                {
                    string[] separarArquivos = lerLinha.Split(';');

                    if (int.Parse(separarArquivos[1]) < 1000)
                    {
                        cidadesFiltradas.WriteLine(separarArquivos[0] + ";" + separarArquivos[2]);
                    }

                    lerLinha = cidades.ReadLine();
                }
                cidades.Close();
                cidadesFiltradas.Close();
                Console.WriteLine("Arquivo gravado com sucesso !");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exceção: " + ex.Message);
            }

            Console.ReadLine(); 
        }
    }
}
