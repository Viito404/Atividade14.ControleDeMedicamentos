using Atividade14.ControleDeMedicamentos.Módulo_Fornecedor;
using Atividade14.ControleDeMedicamentos.Módulo_Funcionário;
using Atividade14.ControleDeMedicamentos.Utilitários;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14.ControleDeMedicamentos.Módulo_Medicamento
{
     internal class RepositorioMedicamento : Repositorios
     {
          int quantidadeRemedio = 1;

          public RepositorioFornecedor repositorioFornecedor = null;
          public RepositorioFuncionario repositorioFuncionario = null;
          public NegocioMedicamento Funcionario
          {
               get => default;
               set
               {

               }
          }

          public override bool ValidarElementos(string remedio)
          {
               bool temEstoque = false;
               foreach (NegocioMedicamento medicamento in dados)
               {
                    if (medicamento.NomeRemedio == remedio)
                    {
                         temEstoque = true;
                         medicamento.QuantidadeRemedio++;
                         return temEstoque;
                    }
                    else
                    {
                         temEstoque = false;
                    }
               }
               return temEstoque;
          }

          public override bool VerificarElementos()
          {
               if (dados.Count == 0)
               {
                    ImprimirTexto("\nNenhum medicamento cadastrado!", ConsoleColor.DarkYellow, 1);
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

               if (pausa == 0 || pausa == 1)
                    Console.Clear();

               ImprimirTexto(mensagem, ConsoleColor.DarkGray, 0);
               Console.BackgroundColor = ConsoleColor.Blue;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0,-5} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20} |", "ID", "NOME", "DESCRIÇÃO", "QUANTIDADE", "FORNECEDOR", "FEEDBACK");
               Console.ResetColor();
               Console.WriteLine();

               foreach (NegocioMedicamento medicamento in dados)
               {
                    medicamento.VerificarQuantidade();
                    Console.WriteLine("| {0,-5} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20} |", medicamento.id, medicamento.NomeRemedio, medicamento.DescricaoRemedio, medicamento.QuantidadeRemedio, medicamento.Fornecedor.NomeFornecedor, medicamento.FeedbackRemedio);
               }

               if (pausa == 0)
                    Console.ReadLine();

               return verifica;
          }
     }
}
