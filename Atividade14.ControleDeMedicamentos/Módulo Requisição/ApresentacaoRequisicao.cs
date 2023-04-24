using Atividade14.ControleDeMedicamentos.Módulo_Fornecedor;
using Atividade14.ControleDeMedicamentos.Módulo_Funcionário;
using Atividade14.ControleDeMedicamentos.Módulo_Medicamento;
using Atividade14.ControleDeMedicamentos.Módulo_Paciente;
using Atividade14.ControleDeMedicamentos.Utilitários;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14.ControleDeMedicamentos.Módulo_Requisição
{
     internal class ApresentacaoRequisicao : Tela
     {
          RepositorioRequisicao repositorioRequisicao = null;
          RepositorioFuncionario repositorioFuncionario = null;
          RepositorioPaciente repositorioPaciente = null;
          RepositorioMedicamento repositorioMedicamento = null;
          RepositorioFornecedor repositorioFornecedor = null;

          public ApresentacaoRequisicao(RepositorioRequisicao requisicao,RepositorioFuncionario funcionario, RepositorioPaciente paciente, RepositorioMedicamento medicamento, RepositorioFornecedor repositorioFornecedor)
          {
               repositorioRequisicao = requisicao;
               repositorioFuncionario = funcionario;
               repositorioPaciente = paciente;
               repositorioMedicamento = medicamento;
               this.repositorioFornecedor = repositorioFornecedor;
          }

          public void MenuRequisicao()
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

                    string opcaoMedicamento = GerarMenu("REQUISIÇÕES", ConsoleColor.Blue, 2);

                    switch (opcaoMedicamento)
                    {
                         case "0":
                              ImprimirTexto("\nSaindo de Requisições...", ConsoleColor.Red, 1);
                              saida--;
                              break;

                         case "1":
                              AbrirRequisicao();
                              break;

                         case "2":
                              VerRequisicoesAbertas();
                              break;

                         default:
                              ImprimirTexto("\nInsira uma opção inválida!", ConsoleColor.Red, 1);
                              break;
                    }
               } while (saida > 0);
          }

          private void VerRequisicoesAbertas()
          {
               bool temElementos = repositorioRequisicao.ExibirElementos("Exibindo Requisições...\n", 0);

               if (!temElementos)
                    return;
          }

          private void AbrirRequisicao()
          {
               NegocioRequisicao requisicao = FazerRequisicao();

               if (requisicao == null)
               {
                    ImprimirTexto("\nSem cadastros suficientes!", ConsoleColor.Red, 1);
                    return;
               }
               repositorioRequisicao.Gravar(requisicao);

               ImprimirTexto("\nRequisição feita!", ConsoleColor.Green, 1);
          }

          public NegocioRequisicao FazerRequisicao()
          {
               NegocioRequisicao requisicao = new NegocioRequisicao();

               Console.Write("\nEntre com a DATA da requisição:\n> ");
               requisicao.DataRequisicao = Console.ReadLine();

               ApresentacaoFuncionario funcionario = new ApresentacaoFuncionario(repositorioFuncionario);

               bool verifica = repositorioFuncionario.ExibirElementos("Exibindo Funcionários...", 1);

               if (!verifica)
                    return requisicao = null;

               int idFuncionario = funcionario.EncontrarIdFuncionario();

               requisicao.NegocioFuncionario = (NegocioFuncionario)repositorioFuncionario.ProcurarId(idFuncionario);

               ApresentacaoPaciente paciente = new ApresentacaoPaciente(repositorioPaciente, repositorioFuncionario);

               verifica = repositorioPaciente.ExibirElementos("Exibindo Pacientes...", 1);

               if (!verifica)
                    return requisicao = null;

               int idPaciente = paciente.EncontrarIdPaciente();

               requisicao.NegocioPaciente = (NegocioPaciente)repositorioPaciente.ProcurarId(idPaciente);

               ApresentacaoMedicamento medicamento = new ApresentacaoMedicamento(repositorioMedicamento, repositorioFornecedor, repositorioFuncionario);

               verifica = repositorioMedicamento.ExibirElementos("Exibindo Medicamentos...", 1);

               if (!verifica)
                    return requisicao = null;

               int idMedicamento = medicamento.EncontrarIdMedicamentos();

               repositorioRequisicao.DarBaixaMedicamento(idMedicamento);

               requisicao.NegocioMedicamento = (NegocioMedicamento)repositorioMedicamento.ProcurarId(idMedicamento);

               return requisicao;
          }
     }
}
