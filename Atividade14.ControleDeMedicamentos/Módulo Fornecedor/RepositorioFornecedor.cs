using Atividade14.ControleDeMedicamentos.Utilitários;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14.ControleDeMedicamentos.Módulo_Fornecedor
{
     internal class RepositorioFornecedor : Repositorios
     {
          public RepositorioFornecedor repositorioFornecedor = null;

          public NegocioFornecedor Fornecedor
          {
               get => default;
               set
               {

               }
          }

          public override bool ValidarElementos(string elemento)
          {
               bool invalido = false;
               foreach (NegocioFornecedor fornecedorCNPJ in dados)
               {
                    if (fornecedorCNPJ.CnpjFornecedor == elemento)
                    {
                         invalido = true;
                         return invalido;
                    }
                    else
                    {
                         invalido = false;
                    }
               }
               return invalido;
          }

          public override bool VerificarElementos()
          {
               if (dados.Count == 0)
               {
                    ImprimirTexto("\nNenhum fornecedor cadastrado!", ConsoleColor.DarkYellow, 1);
                    return false;
               }
               else
               {
                    return true;
               }
          }

          public override bool ExibirElementos(string mensagem, int pausa)
          {
               bool verifica = true;
               verifica = VerificarElementos();

               if (!verifica)
                    return verifica;

               if(pausa == 0 || pausa == 1)
               Console.Clear();

               ImprimirTexto(mensagem, ConsoleColor.DarkGray, 0);
               Console.BackgroundColor = ConsoleColor.Blue;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0,-5} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20} |", "ID", "NOME", "CNPJ", "TELEFONE", "EMAIL", "ENDEREÇO");
               Console.ResetColor();
               Console.WriteLine();

               foreach (NegocioFornecedor fornecedor in dados)
               {
                    Console.WriteLine("| {0,-5} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20} |", fornecedor.id, fornecedor.NomeFornecedor, fornecedor.CnpjFornecedor, fornecedor.TelefoneFornecedor, fornecedor.EmailFornecedor, fornecedor.EnderecoFornecedor);
               }

               if(pausa == 0)
               Console.ReadLine();

               return verifica;
          }
     }
     }