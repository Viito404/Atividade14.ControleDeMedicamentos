using Atividade14.ControleDeMedicamentos.Utilitários;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14.ControleDeMedicamentos.Módulo_Fornecedor
{
     internal class NegocioFornecedor : Entidade
     {
          private string nomeFornecedor, cnpjFornecedor, telefoneFornecedor, emailFornecedor, enderecoFornecedor;

          public string NomeFornecedor { get { return nomeFornecedor; } set {  nomeFornecedor = value; } }
          public string CnpjFornecedor { get { return cnpjFornecedor; } set { cnpjFornecedor = value; } }
          public string TelefoneFornecedor { get { return telefoneFornecedor;} set { telefoneFornecedor = value; } }
          public string EmailFornecedor { get { return emailFornecedor; } set {  emailFornecedor = value; } }
          public string EnderecoFornecedor { get { return enderecoFornecedor; } set { enderecoFornecedor = value; } }

          public override void Atualizar(Entidade fornecedorAtualizado)
          {
               NegocioFornecedor fornecedor = (NegocioFornecedor)fornecedorAtualizado;

               nomeFornecedor = fornecedor.nomeFornecedor;
               cnpjFornecedor = fornecedor.cnpjFornecedor;
               telefoneFornecedor = fornecedor.telefoneFornecedor;
               emailFornecedor = fornecedor.emailFornecedor;
               enderecoFornecedor = fornecedor.enderecoFornecedor;
          }
     }
}
