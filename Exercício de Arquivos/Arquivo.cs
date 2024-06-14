using System;
using System.Text;
using System.IO;


namespace Exercício_de_Arquivos
{
    internal class Program
    {
        static int ContabilizaLinhas ()
        {
            int cont = 0;
            try
            {
                string lerLinha = "";         
                StreamReader arquivo = new StreamReader("lista_atp_10_arquivos.txt", Encoding.UTF8);
                lerLinha = arquivo.ReadLine();

                while (lerLinha != null)
                {
                    cont++;
                    lerLinha = arquivo.ReadLine();
                }

                arquivo.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return cont;
        }

        static string[] NomesDosEstudantes(int numeroDeLinhas)
        {
            string[] nomes = new string[numeroDeLinhas];

            try
            {
                string lerLinha = "";
                int cont = 0;
                StreamReader arquivo = new StreamReader("lista_atp_10_arquivos.txt", Encoding.UTF8);
                lerLinha = arquivo.ReadLine();

                
                while (lerLinha != null)
                {
                    string[] filtrarNomes = lerLinha.Split(' ');
                    nomes[cont] = filtrarNomes[1];
                    cont++;
                    lerLinha = arquivo.ReadLine();
                }
                arquivo.Close();

            }
            catch (Exception ex) 
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return nomes;
        }

        static double[] MediaDosAlunos(int numeroDeLinhas)
        {
            double[] medias = new double[numeroDeLinhas];

            try
            {
                string lerLinha = "";
                StreamReader arquivo = new StreamReader("lista_atp_10_arquivos.txt", Encoding.UTF8);
                lerLinha = arquivo.ReadLine();
                double media;
                int cont = 0;

                while (lerLinha != null)
                {
                    string[] filtrarMedias = lerLinha.Split(' ');
                    media = (double.Parse(filtrarMedias[2]) + double.Parse(filtrarMedias[3]) + double.Parse(filtrarMedias[4])) / 3;
                    medias[cont] = Math.Round(media,1);
                    cont++;
                    lerLinha = arquivo.ReadLine();
                }

                arquivo.Close();
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return medias;
        }

        static void NomesEhMediasMaiores60 (string[] nomesDosEstudantes, double[] medias)
        {
            try
            {
                StreamWriter arquivo = new StreamWriter("nomesEhMedias.txt", false, Encoding.UTF8);

                for (int i = 0; i < nomesDosEstudantes.Length; i++)
                {
                    if (medias[i] >= 60)
                    {
                        arquivo.WriteLine(nomesDosEstudantes[i] + " " + medias[i]);
                    }
                }

                arquivo.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        static void NomesEhMediasMenores60 (string[] nomesDosEstudantes, double[] medias)
        {
            try
            {
                StreamWriter arquivo = new StreamWriter("nomesEhMediasMenores60.txt", false, Encoding.UTF8);

                for (int i = 0; i < nomesDosEstudantes.Length; i++)
                {
                    if (medias[i] < 60)
                    {
                        arquivo.WriteLine(nomesDosEstudantes[i] + " " + medias[i]);
                    }
                }

                arquivo.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        static void MediasEmOrdemDecrescente(string[] nomesDosEstudantes, double[] medias)
        {
           
        }

        static double MaiorNota(int numeroDeLinhas)
        {
            double result = double.MinValue;

            try
            {
                StreamReader arquivo = new StreamReader("lista_atp_10_arquivos.txt", Encoding.UTF8);
                string lerLinha = "";
                lerLinha = arquivo.ReadLine();

                string[] compararNotas = new string[numeroDeLinhas];

                while (lerLinha != null)
                {
                    compararNotas = lerLinha.Split(' ');

                    double maior = Math.Max(double.Parse(compararNotas[2]), double.Parse(compararNotas[3]));
                    maior = Math.Max(maior, double.Parse(compararNotas[4]));

                    if(maior > result)
                    {
                        result = maior;
                    }

                    lerLinha = arquivo.ReadLine();
                }
                
                arquivo.Close();
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Exception: " + ex.Message);
            }


            return result;
        }

        static void PritarNomeEhMedia(string[] nomesDosEstudantes, double[] medias)
        {
            for (int i = 0;i < medias.Length; i++)
            {
                Console.WriteLine($"Nome: {nomesDosEstudantes[i]}\nMédia: {medias[i]}");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"A quantidade de linhas que tem no documento é: {ContabilizaLinhas()}");
            string[] nomesDosEstudantes = NomesDosEstudantes(ContabilizaLinhas());
            double[] medias = MediaDosAlunos(ContabilizaLinhas());
            NomesEhMediasMaiores60(nomesDosEstudantes, medias);
            NomesEhMediasMenores60(nomesDosEstudantes, medias);
            MediasEmOrdemDecrescente(nomesDosEstudantes, medias);
            PritarNomeEhMedia(nomesDosEstudantes, medias);

            Console.ReadLine();
        }
    }
}
