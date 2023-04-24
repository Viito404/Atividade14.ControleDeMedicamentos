using Atividade14.ControleDeMedicamentos.Módulo_Fornecedor;
using Atividade14.ControleDeMedicamentos.Utilitários;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14.ControleDeMedicamentos.Módulo_Funcionário
{
     internal class NegocioFuncionario : Entidade
     {
          private string nomeFuncionario, cpfFuncionario, telefoneFuncionario, emailFuncionario, senhaFuncionario;

          public string NomeFuncionario { get { return nomeFuncionario; } set { nomeFuncionario = value;} }
          public string CpfFuncionario { get { return cpfFuncionario; } set {  cpfFuncionario = value; } }
          public string TelefoneFuncionario { get { return telefoneFuncionario; } set {  telefoneFuncionario = value;} }
          public string EmailFuncionario { get { return emailFuncionario; } set {  emailFuncionario = value; } }
          public string SenhaFuncionario { get { return senhaFuncionario;} set {  senhaFuncionario = value; } }

          public override void Atualizar(Entidade funcionarioAtualizado)
          {
               NegocioFuncionario funcionario = (NegocioFuncionario)funcionarioAtualizado;

               nomeFuncionario = funcionario.nomeFuncionario;
               cpfFuncionario = funcionario.cpfFuncionario;
               telefoneFuncionario = funcionario.telefoneFuncionario;
               emailFuncionario = funcionario.emailFuncionario;
               senhaFuncionario = funcionario.senhaFuncionario;
          }
     }
}
