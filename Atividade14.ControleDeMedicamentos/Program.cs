using Atividade14.ControleDeMedicamentos.Módulo_Fornecedor;
using Atividade14.ControleDeMedicamentos.Módulo_Funcionário;
using Atividade14.ControleDeMedicamentos.Módulo_Medicamento;
using Atividade14.ControleDeMedicamentos.Módulo_Paciente;
using Atividade14.ControleDeMedicamentos.Módulo_Requisição;
using Atividade14.ControleDeMedicamentos.Utilitários;

namespace Atividade14.ControleDeMedicamentos
{
     internal class Program
     {
          static void Main(string[] args)
          {
               Tela outros = new Tela();
               RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
               ApresentacaoFuncionario exibicaoFuncionario = new ApresentacaoFuncionario(repositorioFuncionario);

               RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
               ApresentacaoFornecedor exibicaoFornecedor = new ApresentacaoFornecedor(repositorioFornecedor, repositorioFuncionario);

               RepositorioPaciente repositorioPaciente = new RepositorioPaciente();
               ApresentacaoPaciente exibicaoPaciente = new ApresentacaoPaciente(repositorioPaciente, repositorioFuncionario);


               RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
               ApresentacaoMedicamento exibicaoMedicamento = new ApresentacaoMedicamento(repositorioMedicamento, repositorioFornecedor, repositorioFuncionario);


               RepositorioRequisicao repositorioRequisicao = new RepositorioRequisicao();
               ApresentacaoRequisicao exibicaoRequisicao = new ApresentacaoRequisicao(repositorioRequisicao, repositorioFuncionario, repositorioPaciente, repositorioMedicamento, repositorioFornecedor);
               repositorioFuncionario.CadastrarAdmin();
               while (true)
               {                 
                    string opcao = outros.GerarMenu("CLUBE DA LEITURA", ConsoleColor.Cyan, 0);

                    if (opcao == "0")
                    {
                         outros.ImprimirTexto("\nSaindo do Programa...", ConsoleColor.Red, 1);
                         break;
                    }

                    else if (opcao == "1")
                    {
                         exibicaoFornecedor.MenuFornecedor();
                    }

                    else if (opcao == "2")
                    {
                         exibicaoPaciente.MenuPaciente();
                    }

                    else if (opcao == "3")
                    {
                         exibicaoFuncionario.MenuFuncionario();
                    }

                    else if (opcao == "4")
                    {
                         exibicaoMedicamento.MenuMedicamento();
                    }

                    else if(opcao == "5")
                    {
                         exibicaoRequisicao.MenuRequisicao();
                    }

                    else if (opcao == "6")
                    {
            
                    }

                    else
                    {
                         outros.ImprimirTexto("\nEscolha uma opção válida!", ConsoleColor.Red, 1);
                         continue;
                    }
               }
          }
     }
}