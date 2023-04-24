using Atividade14.ControleDeMedicamentos.Módulo_Fornecedor;
using Atividade14.ControleDeMedicamentos.Módulo_Funcionário;
using Atividade14.ControleDeMedicamentos.Utilitários;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14.ControleDeMedicamentos.Módulo_Paciente
{
     internal class ApresentacaoPaciente : Tela
     {
          RepositorioPaciente repositorioPaciente = null;
          RepositorioFuncionario repositorioFuncionario = null;
          public ApresentacaoPaciente(RepositorioPaciente repositorioPaciente, RepositorioFuncionario repositorioFuncionario)
          {
               this.repositorioPaciente = repositorioPaciente;
               this.repositorioFuncionario = repositorioFuncionario;
          }

          public void MenuPaciente()
          {
               int autentic = 0;
               int saida = 1;
               do
               {
                    if (autentic == 0)
                    {
                         ApresentacaoFuncionario funcionario = new ApresentacaoFuncionario(repositorioFuncionario);
                         funcionario.AutenticacaoFuncionario();
                         autentic++;
                    }

                    string opcaoPaciente = GerarMenu("PACIENTES", ConsoleColor.Blue, 1);

                    switch (opcaoPaciente)
                    {
                         case "0":
                              ImprimirTexto("\nSaindo de Pacientes...", ConsoleColor.Red, 1);
                              saida--;
                              break;

                         case "1":
                              CadastrarPaciente();
                              break;

                         case "2":
                              VisualizarPaciente();
                              break;

                         case "3":
                              AtualizarPaciente();
                              break;

                         case "4":
                              RemoverPaciente();
                              break;

                         default:
                              ImprimirTexto("\nInsira uma opção inválida!", ConsoleColor.Red, 1);
                              break;
                    }
               } while (saida > 0);
          }

          private void CadastrarPaciente()
          {
               Console.Clear();
               ImprimirTexto("Cadastrando Pacientes...\n", ConsoleColor.DarkGray, 0);

               NegocioPaciente paciente = ObterPaciente();
               repositorioPaciente.Gravar(paciente);
               ImprimirTexto("\nCadastro Finalizado!", ConsoleColor.Green, 1);
          }

          private void VisualizarPaciente()
          {
               bool temElementos = repositorioPaciente.ExibirElementos("Exibindo Pacientes...\n", 0);

               if (!temElementos)
                    return;
          }

          private void AtualizarPaciente()
          {
               bool temElementos = repositorioPaciente.ExibirElementos("Editando Pacientes..\n", 1);

               if (!temElementos)
                    return;

               int id = EncontrarIdPaciente();

               NegocioPaciente paciente = ObterPaciente();
               repositorioPaciente.Editar(id, paciente);
               ImprimirTexto("\nInformações Atualizadas!", ConsoleColor.Green, 1);
          }

          private void RemoverPaciente()
          {
               bool temElementos = repositorioPaciente.ExibirElementos("Removendo Pacientes..\n", 1);

               if (!temElementos)
                    return;

               int id = EncontrarIdPaciente();
               repositorioPaciente.Deletar(id);
               ImprimirTexto("\nInformações Apagadas!", ConsoleColor.Green, 1);
          }

          public NegocioPaciente ObterPaciente()
          {
               NegocioPaciente paciente = new NegocioPaciente();

               Console.Write("\nEntre com o NOME do paciente:\n> ");
               paciente.NomePaciente = Console.ReadLine();

               bool idInvalido = false;

               do
               {
                    Console.Write("\nEntre com o CPF do paciente:\n> ");
                    paciente.CpfPaciente = Console.ReadLine();

                    idInvalido = repositorioPaciente.ValidarElementos(paciente.CpfPaciente);

                    if (idInvalido)
                         ImprimirTexto("\nCpf já registrado!", ConsoleColor.Red, 1);

               } while (idInvalido);

               Console.Write("\nEntre com o ENDEREÇO do paciente:\n> ");
               paciente.EnderecoPaciente = Console.ReadLine();

               Console.Write("\nEntre com o TELEFONE do paciente:\n> ");
               paciente.TelefonePaciente = Console.ReadLine();

               return paciente;
          }

          public int EncontrarIdPaciente()
          {
               int idPaciente;
               bool idInvalido;

               do
               {
                    Console.Write("\nEntre com o número de ID do paciente que deseja atualizar:\n> ");
                    idPaciente = Convert.ToInt32(Console.ReadLine());

                    idInvalido = repositorioPaciente.ProcurarId(idPaciente) == null;

                    if (idInvalido)
                         ImprimirTexto("\nEntre com um número de ID válido!", ConsoleColor.Red, 1);

               } while (idInvalido);

               return idPaciente;
          }
     }
}