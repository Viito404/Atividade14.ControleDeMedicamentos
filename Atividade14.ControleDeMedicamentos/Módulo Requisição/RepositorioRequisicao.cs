using Atividade14.ControleDeMedicamentos.Módulo_Medicamento;
using Atividade14.ControleDeMedicamentos.Utilitários;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14.ControleDeMedicamentos.Módulo_Requisição
{
     internal class RepositorioRequisicao : Repositorios
     {
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
               Console.WriteLine("| {0,-5} | {1,-20} | {2,-20} | {3,-20} | {4,-20} |", "ID", "PACIENTE", "FUNCIONÁRIO", "MEDICAMENTO", "DATA");
               Console.ResetColor();
               Console.WriteLine();

               foreach (NegocioRequisicao requisicao in dados)
               {                   
                    Console.WriteLine("| {0,-5} | {1,-20} | {2,-20} | {3,-20} | {4,-20} |", requisicao.id, requisicao.NegocioPaciente.NomePaciente, requisicao.NegocioFuncionario.NomeFuncionario, $"{requisicao.NegocioMedicamento.NomeRemedio} : {requisicao.NegocioMedicamento.QuantidadeRemedio}", requisicao.DataRequisicao);
               }

               if (pausa == 0)
                    Console.ReadLine();

               return verifica;
          }

          public override bool VerificarElementos()
          {
               if (dados.Count == 0)
               {
                    ImprimirTexto("\nNenhuma requisição em andamento!", ConsoleColor.DarkYellow, 1);
                    return false;
               }
               else
               {
                    return true;
               }
          }

          public bool DarBaixaMedicamento(int id)
          {
               bool temEstoque = false;
               foreach (NegocioRequisicao requisicao in dados)
               {
                    if (requisicao.NegocioMedicamento.id == id)
                    {
                         temEstoque = true;
                         requisicao.NegocioMedicamento.QuantidadeRemedio--;
                         return temEstoque;
                    }
                    else
                    {
                         temEstoque = false;
                    }
               }
               return temEstoque;
          }
     }
}
