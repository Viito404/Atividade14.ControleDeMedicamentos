using Atividade14.ControleDeMedicamentos.Módulo_Fornecedor;
using Atividade14.ControleDeMedicamentos.Utilitários;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14.ControleDeMedicamentos.Módulo_Paciente
{
     internal class RepositorioPaciente : Repositorios
     {
          public RepositorioPaciente repositorioPaciente = null;

          public NegocioPaciente Paciente
          {
               get => default;
               set
               {

               }
          }

          public override bool ValidarElementos(string elemento)
          {
               bool invalido = false;
               foreach (NegocioPaciente pacienteCPF in dados)
               {
                    if (pacienteCPF.CpfPaciente == elemento)
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
                    ImprimirTexto("\nNenhum paciente cadastrado!", ConsoleColor.DarkYellow, 1);
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
               Console.WriteLine("| {0,-5} | {1,-20} | {2,-20} | {3,-20} | {4,-20} |", "ID", "NOME", "CPF", "ENDEREÇO", "TELEFONE");
               Console.ResetColor();
               Console.WriteLine();

               foreach (NegocioPaciente paciente in dados)
               {
                    Console.WriteLine("| {0,-5} | {1,-20} | {2,-20} | {3,-20} | {4,-20} |", paciente.id, paciente.NomePaciente, paciente.CpfPaciente, paciente.EnderecoPaciente, paciente.TelefonePaciente);
               }

               if (pausa == 0)
                    Console.ReadLine();

               return verifica;
          }
     }
}