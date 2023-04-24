using Atividade14.ControleDeMedicamentos.Módulo_Fornecedor;
using Atividade14.ControleDeMedicamentos.Módulo_Paciente;
using Atividade14.ControleDeMedicamentos.Utilitários;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14.ControleDeMedicamentos.Módulo_Funcionário
{
     internal class ApresentacaoFuncionario : Tela
     {
          RepositorioFuncionario repositorioFuncionario = null;
          public ApresentacaoFuncionario(RepositorioFuncionario repositorioFuncionario)
          {
               this.repositorioFuncionario = repositorioFuncionario;
          }

          public void MenuFuncionario()
          {
               int autentic = 0;
               int saida = 1;
               do
               {
                    if (autentic == 0)
                    {
                         AutenticacaoFuncionario();
                         autentic++;
                    }
                    string opcaoFuncionario = GerarMenu("FUNCIONÁRIOS", ConsoleColor.Blue, 1);

                    switch (opcaoFuncionario)
                    {
                         case "0":
                              ImprimirTexto("\nSaindo de Funcionários...", ConsoleColor.Red, 1);
                              saida--;
                              break;

                         case "1":
                              CadastrarFuncionario();
                              break;

                         case "2":
                              VisualizarFuncionario();
                              break;

                         case "3":
                              AtualizarFuncionario();
                              break;

                         case "4":
                              RemoverFuncionario();
                              break;

                         default:
                              ImprimirTexto("\nInsira uma opção inválida!", ConsoleColor.Red, 1);
                              break;
                    }
               } while (saida > 0);
          }

          private void CadastrarFuncionario()
          {
               repositorioFuncionario.VerificarElementos();

               Console.Clear();
               ImprimirTexto("Cadastrando Funcionarios...\n", ConsoleColor.DarkGray, 0);

               NegocioFuncionario funcionario = ObterFuncionario();
               repositorioFuncionario.Gravar(funcionario);
               ImprimirTexto("\nCadastro Finalizado!", ConsoleColor.Green, 1);
          }

          private void VisualizarFuncionario()
          {
               bool temElementos = repositorioFuncionario.ExibirElementos("Exibindo Funcionários...\n", 0);

               if (!temElementos)
                    return;           
          }

          private void AtualizarFuncionario()
          {
               bool temElementos = repositorioFuncionario.ExibirElementos("Editando Funcionários...\n", 1);

               if (!temElementos)
                    return;

               int id = EncontrarIdFuncionario();

               NegocioFuncionario funcionario = ObterFuncionario();
               repositorioFuncionario.Editar(id, funcionario);
               ImprimirTexto("\nInformações Atualizadas!", ConsoleColor.Green, 1);
          }

          private void RemoverFuncionario()
          {
               bool temElementos = repositorioFuncionario.ExibirElementos("Removendo Funcionários...\n", 1);

               if (!temElementos)
                    return;

               int id = EncontrarIdFuncionario();
               repositorioFuncionario.Deletar(id);
               ImprimirTexto("\nInformações Apagadas!", ConsoleColor.Green, 1);
          }

          public NegocioFuncionario ObterFuncionario()
          {
               NegocioFuncionario funcionario = new NegocioFuncionario();

               Console.Write("\nEntre com o NOME do funcionário:\n> ");
               funcionario.NomeFuncionario = Console.ReadLine();

               bool idInvalido = false;

               do
               {
                    Console.Write("\nEntre com o CPF do funcionário:\n> ");
                    funcionario.CpfFuncionario = Console.ReadLine();

                    idInvalido = repositorioFuncionario.ValidarElementos(funcionario.CpfFuncionario);

                    if (idInvalido)
                         ImprimirTexto("\nCpf já registrado!", ConsoleColor.Red, 1);

               } while (idInvalido);

               Console.Write("\nEntre com o TELEFONE do funcionário:\n> ");
               funcionario.TelefoneFuncionario = Console.ReadLine();

               Console.Write("\nEntre com o EMAIL do funcionário:\n> ");
               funcionario.EmailFuncionario = Console.ReadLine();

               Console.Write("\nEntre com uma SENHA:\n> ");
               funcionario.SenhaFuncionario = Console.ReadLine();

               return funcionario;
          }

          public int EncontrarIdFuncionario()
          {
               int idFuncionario;
               bool idInvalido;

               do
               {
                    Console.Write("\nEntre com o número de ID do funcionário:\n> ");
                    idFuncionario = Convert.ToInt32(Console.ReadLine());

                    idInvalido = repositorioFuncionario.ProcurarId(idFuncionario) == null;

                    if (idInvalido)
                         ImprimirTexto("\nEntre com um número de ID válido!", ConsoleColor.Red, 1);

               } while (idInvalido);

               return idFuncionario;
          }

          public void AutenticacaoFuncionario()
          {
               bool validar;
               do
               {
                    NegocioFuncionario funcionario = new NegocioFuncionario();
                    Console.Clear();
                    Console.Write("Entre com o EMAIL do funcionário:\n> ");
                    funcionario.EmailFuncionario = Console.ReadLine();

                    Console.Write("\nEntre com a SENHA do funcionário:\n> ");
                    funcionario.SenhaFuncionario = Console.ReadLine();

                    validar = repositorioFuncionario.LogarConta(funcionario.EmailFuncionario, funcionario.SenhaFuncionario);

                    if (!validar)
                         ImprimirTexto("\nEmail ou Senha inválidos!", ConsoleColor.Red, 1);

                    Console.Clear();
               } while (!validar);
          }
     }
}