using Atividade14.ControleDeMedicamentos.Módulo_Fornecedor;
using Atividade14.ControleDeMedicamentos.Utilitários;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Atividade14.ControleDeMedicamentos.Módulo_Funcionário
{
     internal class RepositorioFuncionario : Repositorios
     {
          public RepositorioFuncionario repositorioFuncionario = null;

          public NegocioFuncionario Funcionario
          {
               get => default;
               set
               {

               }
          }

          public override bool ValidarElementos(string elemento)
          {
               bool invalido = false;
               foreach (NegocioFuncionario funcionario in dados)
               {
                    if (funcionario.CpfFuncionario == elemento)
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
                    ImprimirTexto("\nNenhum funcionario cadastrado!", ConsoleColor.DarkYellow, 1);
                    return false;
               }
               else
               {
                    return true;
               }
          }

          public override bool LogarConta(string email, string senha)
          {
               bool invalido = false;
               foreach (NegocioFuncionario funcionario in dados)
               {
                    if (funcionario.EmailFuncionario == email)
                    {
                         if (funcionario.SenhaFuncionario == senha)
                         {
                              invalido = true;
                              return invalido;
                         }
                    }
               }
               return invalido;
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
               Console.WriteLine("| {0,-5} | {1,-20} | {2,-20} | {3,-20} | {4,-20} |", "ID", "NOME", "CPF", "TELEFONE", "EMAIL");
               Console.ResetColor();
               Console.WriteLine();

               foreach (NegocioFuncionario funcionario in dados)
               {
                    Console.WriteLine("| {0,-5} | {1,-20} | {2,-20} | {3,-20} | {4,-20} |", funcionario.id, funcionario.NomeFuncionario, funcionario.CpfFuncionario, funcionario.TelefoneFuncionario, funcionario.EmailFuncionario);
               }

               if (pausa == 0)
                    Console.ReadLine();

               return verifica;
          }

          public override Entidade ProcurarId(int id)
          {
               Entidade informacoes = null;

               foreach (Entidade e in dados)
               {
                    if (e.id == id && id != 1)
                    {
                         informacoes = e;
                         break;
                    }
               }
               return informacoes;
          }

          public void CadastrarAdmin()
          {
               NegocioFuncionario funcionario = new NegocioFuncionario();

               funcionario.id = contadorID;
               funcionario.NomeFuncionario = "ADMIN";
               funcionario.CpfFuncionario = "000.000.000.00";
               funcionario.TelefoneFuncionario = "0000000000";
               funcionario.EmailFuncionario = "admin";
               funcionario.SenhaFuncionario = "admin";

               Gravar(funcionario);
          }

     }
}
