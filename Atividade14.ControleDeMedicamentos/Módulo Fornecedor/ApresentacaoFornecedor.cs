using Atividade14.ControleDeMedicamentos.Módulo_Funcionário;
using Atividade14.ControleDeMedicamentos.Utilitários;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14.ControleDeMedicamentos.Módulo_Fornecedor
{
     internal class ApresentacaoFornecedor : Tela
     {
          RepositorioFornecedor repositorioFornecedor = null;
          RepositorioFuncionario repositorioFuncionario = null;
          public ApresentacaoFornecedor(RepositorioFornecedor repositorioFornecedor, RepositorioFuncionario repositorioFuncionario)
          {
               this.repositorioFornecedor = repositorioFornecedor;
               this.repositorioFuncionario = repositorioFuncionario;
          }

          public void MenuFornecedor()
          {
               int saida = 1;
               int autentic = 0;
               do
               {
                    if (autentic == 0)
                    {
                         ApresentacaoFuncionario funcionario = new ApresentacaoFuncionario(repositorioFuncionario);
                         funcionario.AutenticacaoFuncionario();
                         autentic++;
                    }
                    string opcaoFornecedor = GerarMenu("FORNECEDORES", ConsoleColor.Blue, 1);

                    switch (opcaoFornecedor)
                    {
                         case "0":
                              ImprimirTexto("\nSaindo de Fornecedores...", ConsoleColor.Red, 1);
                              saida--;
                              break;

                         case "1":
                              CadastrarFornecedor();
                              break;

                         case "2":
                              VisualizarFornecedor();
                              break;

                         case "3":
                              AtualizarFornecedor();
                              break;

                         case "4":
                              RemoverFornecedor();
                              break;

                         default:
                              ImprimirTexto("\nInsira uma opção inválida!", ConsoleColor.Red, 1);
                              break;
                    }
               } while (saida > 0);
          }

          private void CadastrarFornecedor()
          {
               Console.Clear();

               ImprimirTexto("Cadastrando Fornecedores...", ConsoleColor.DarkGray, 0);

               NegocioFornecedor fornecedor = ObterFornecedor();
               repositorioFornecedor.Gravar(fornecedor);

               ImprimirTexto("\nCadastro Finalizado!", ConsoleColor.Green, 1);
          }

          private void VisualizarFornecedor()
          {
               Console.Clear();

               bool temElementos = repositorioFornecedor.ExibirElementos("Exibindo Fornecedores...\n", 0);

               if (!temElementos)
                    return;
          }

          private void AtualizarFornecedor()
          {
               Console.Clear();

               bool temElementos = repositorioFornecedor.ExibirElementos("Editando Fornecedores...\n", 1);

               if (!temElementos)
                    return;

               int id = EncontrarIdFornecedor();

               NegocioFornecedor fornecedor = ObterFornecedor();
               repositorioFornecedor.Editar(id, fornecedor);

               ImprimirTexto("\nInformações Atualizadas!", ConsoleColor.Green, 1);
          }

          private void RemoverFornecedor()
          {
               Console.Clear();

               bool temElementos = repositorioFornecedor.ExibirElementos("Removendo Fornecedores...\n", 1);

               if (!temElementos)
                    return;

               int id = EncontrarIdFornecedor();

               repositorioFornecedor.Deletar(id);

               ImprimirTexto("\nInformações Apagadas!", ConsoleColor.Green, 1);
          }
    
          public NegocioFornecedor ObterFornecedor()
          {
               NegocioFornecedor fornecedor = new NegocioFornecedor();

               Console.Write("\nEntre com o NOME do fornecedor:\n> ");
               fornecedor.NomeFornecedor = Console.ReadLine();

               bool idInvalido = false;

               do
               {
                    Console.Write("\nEntre com o CNPJ do fornecedor:\n> ");
                    fornecedor.CnpjFornecedor = Console.ReadLine();

                    idInvalido = repositorioFornecedor.ValidarElementos(fornecedor.CnpjFornecedor);

                    if (idInvalido)                  
                         ImprimirTexto("\nCnpj já registrado!", ConsoleColor.Red, 1);

               }while(idInvalido);

               Console.Write("\nEntre com o TELEFONE do fornecedor:\n> ");
               fornecedor.TelefoneFornecedor = Console.ReadLine();

               Console.Write("\nEntre com o EMAIL do fornecedor:\n> ");
               fornecedor.EmailFornecedor = Console.ReadLine();

               Console.Write("\nEntre com o ENDEREÇO do fornecedor:\n> ");
               fornecedor.EnderecoFornecedor = Console.ReadLine();

               return fornecedor;
          }

          public int EncontrarIdFornecedor()
          {
               int idFornecedor;
               bool idInvalido;

               do
               {
                    Console.Write("\nEntre com o número de ID do fornecedor:\n> ");
                    idFornecedor = Convert.ToInt32(Console.ReadLine());

                    idInvalido = repositorioFornecedor.ProcurarId(idFornecedor) == null;

                    if (idInvalido)
                         ImprimirTexto("\nEntre com um número de ID válido!", ConsoleColor.Red, 1);

               } while (idInvalido);

               return idFornecedor;
          }
     }
}
