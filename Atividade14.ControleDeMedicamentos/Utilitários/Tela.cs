using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14.ControleDeMedicamentos.Utilitários
{
     internal class Tela
     {
          public void ImprimirTexto(string mensagem, ConsoleColor cor, int num)
          {
               Console.ForegroundColor = cor;
               Console.WriteLine(mensagem);
               Console.ResetColor();

               if (num == 1)              
                    Console.ReadLine();              
          }

          public string GerarMenu(string titulo, ConsoleColor cor, int tipo)
          {
               string descricao = "";

               if (tipo == 0)
                    descricao = "\n[1] FORNECEDOR;\n[2] PACIENTE;\n[3] FUNCIONÁRIO;\n[4] MEDICAMENTOS;\n[5] REQUISIÇÕES;\n[0] SAIR.";
               else if (tipo == 1)
                    descricao = "\n[1] CRIAR;\n[2] VISUALIZAR;\n[3] ATUALIZAR;\n[4] REMOVER;\n[0] SAIR.";
               else if(tipo == 2)
                    descricao = "\n[1] FAZER REQUISIÇÃO MEDICAMENTOS;\n[2] VERIFICAR REQUISIÇÕES ABERTAS;\n[0] SAIR.";

               Console.Clear();
               Console.WriteLine($"| {titulo} |");
               Console.ForegroundColor = cor;
               Console.WriteLine(descricao);
               Console.ResetColor();
               Console.Write("\nEntre com a opção desejada:\n> ");
               string opcao = Console.ReadLine();
               return opcao;
          }
     }
}
