using Atividade14.ControleDeMedicamentos.Módulo_Fornecedor;
using Atividade14.ControleDeMedicamentos.Módulo_Funcionário;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14.ControleDeMedicamentos.Utilitários
{
     internal class Repositorios : Tela
     {
          public int contadorID = 1;

          public ArrayList dados = new ArrayList();

          public void Gravar(Entidade entidade)
          {
               entidade.id = contadorID;
               dados.Add(entidade);
               ModificarContagem();
          }

          public void Deletar(int id)
          {
               Entidade informacoes = ProcurarId(id);
               dados.Remove(informacoes);
          }

          public virtual Entidade ProcurarId(int id)
          {
               Entidade informacoes = null;

               foreach (Entidade e in dados)
               {
                    if (e.id == id)
                    {
                         informacoes = e;
                         break;
                    }
               }
               return informacoes;
          }

          public void Editar(int id, Entidade novasinformacoes)
          {
               Entidade e = ProcurarId(id);

               e.Atualizar(novasinformacoes);
          }

          private void ModificarContagem()
          {
               contadorID++;
          }

          public virtual bool ValidarElementos(string elemento)
          {
               bool invalido = false;
               return invalido;
          }

          public virtual bool LogarConta(string email, string senha)
          {
               bool invalido = false;
               return invalido;
          }

          public virtual bool VerificarElementos()
          {
               if (dados.Count == 0)
               {
                    ImprimirTexto("\nNenhum elemento cadastrado!", ConsoleColor.DarkYellow, 1);
                    return true;
               }
               else
               {
                    return false;
               }
          }

          public virtual bool ExibirElementos(string mensagem, int pausa)
          {
               Console.Clear();
               ImprimirTexto(mensagem, ConsoleColor.DarkGray, 0);
               Console.BackgroundColor = ConsoleColor.Blue;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0,-5} |", "ID");
               Console.ResetColor();
               Console.WriteLine();

               foreach (Entidade e in dados)
               {
                    Console.WriteLine("| {0,-5} |", e.id);
               }

               if (pausa == 1)
                    Console.ReadLine();
               return true;
          }
     }
     }