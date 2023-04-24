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
     internal class ApresentacaoMedicamento : Tela
     {
          public RepositorioMedicamento repositorioMedicamento = null;
          public RepositorioFornecedor repositorioFornecedor = null;
          public RepositorioFuncionario repositorioFuncionario = null;

          public ApresentacaoMedicamento(RepositorioMedicamento medicamento, RepositorioFornecedor fornecedor, RepositorioFuncionario funcionario)
          {
               repositorioMedicamento = medicamento;
               repositorioFornecedor = fornecedor;
               repositorioFuncionario = funcionario;
          }

          public void MenuMedicamento()
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

                    string opcaoMedicamento = GerarMenu("MEDICAMENTOS", ConsoleColor.Blue, 1);

                    switch (opcaoMedicamento)
                    {
                         case "0":
                              ImprimirTexto("\nSaindo de Medicamentos...", ConsoleColor.Red, 1);
                              saida--;
                              break;

                         case "1":
                              CadastrarMedicamento();
                              break;

                         case "2":
                              VisualizarMedicamento();
                              break;

                         case "3":
                              AtualizarMedicamento();
                              break;

                         case "4":
                              RemoverMedicamento();
                              break;

                         default:
                              ImprimirTexto("\nInsira uma opção inválida!", ConsoleColor.Red, 1);
                              break;
                    }
               } while (saida > 0);
          }

          private void CadastrarMedicamento()
          {
               Console.Clear();

               ImprimirTexto("Cadastrando Medicamentos...\n", ConsoleColor.DarkGray, 0);

               NegocioMedicamento medicamento = ObterMedicamento();

               if (medicamento == null)
               {
                    ImprimirTexto("\nQuantidade Atualizada!", ConsoleColor.Green, 1);
                    return;
               }

               repositorioMedicamento.Gravar(medicamento);
               ImprimirTexto("\nCadastro Finalizado!", ConsoleColor.Green, 1);
          }

          private void VisualizarMedicamento()
          {
               bool temElementos = repositorioMedicamento.ExibirElementos("Exibindo Medicamentos...\n", 0);

               if (!temElementos)
                    return;
          }

          private void RemoverMedicamento()
          {
               bool temElementos = repositorioMedicamento.ExibirElementos("Removendo Medicamentos...\n", 0);

               if (!temElementos)
                    return;


               int id = EncontrarIdMedicamentos();

               repositorioMedicamento.Deletar(id);

               ImprimirTexto("\nInformações Apagadas!", ConsoleColor.Green, 1);
          }

          public int EncontrarIdMedicamentos()
          {
               int idMedicamento;
               bool idInvalido;

               do
               {
                    Console.Write("\nEntre com o número de ID do medicamento:\n> ");
                    idMedicamento = Convert.ToInt32(Console.ReadLine());

                    idInvalido = repositorioMedicamento.ProcurarId(idMedicamento) == null;

                    if (idInvalido)
                         ImprimirTexto("\nEntre com um número de ID válido!", ConsoleColor.Red, 1);

               } while (idInvalido);

               return idMedicamento;
          }

          private void AtualizarMedicamento()
          {
               Console.Clear();

               bool temElementos = repositorioMedicamento.ExibirElementos("Editando Medicamentos...\n", 1);

               if (!temElementos)
                    return;

               int id = EncontrarIdMedicamentos();

               NegocioMedicamento medicamento = ObterMedicamento();

               if (medicamento == null)
                    return;

               repositorioMedicamento.Editar(id, medicamento);

               ImprimirTexto("\nInformações Atualizadas!", ConsoleColor.Green, 1);
          }

          public NegocioMedicamento ObterMedicamento()
          {
               NegocioMedicamento medicamento = new NegocioMedicamento();

               Console.Write("\nEntre com o NOME do medicamento:\n> ");
               medicamento.NomeRemedio = Console.ReadLine();

               bool temEstoque = repositorioMedicamento.ValidarElementos(medicamento.NomeRemedio);

               if (temEstoque)
                    return medicamento = null;


               Console.Write("\nEntre com a DESCRIÇÃO do medicamento:\n> ");
               medicamento.DescricaoRemedio = Console.ReadLine();

               ApresentacaoFornecedor fornecedor = new ApresentacaoFornecedor(repositorioFornecedor, repositorioFuncionario);

               bool verifica = repositorioFornecedor.ExibirElementos("\nExibindo Fornecedores...", 1);

               if (!verifica)
                    return medicamento = null;

               int idFornecedor = fornecedor.EncontrarIdFornecedor();
               medicamento.Fornecedor = (NegocioFornecedor)repositorioFornecedor.ProcurarId(idFornecedor);

               return medicamento;
          }
     }
}