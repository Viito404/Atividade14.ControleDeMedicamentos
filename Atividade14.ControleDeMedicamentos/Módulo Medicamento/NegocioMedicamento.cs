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
     internal class NegocioMedicamento : Entidade
     {
          private string nomeRemedio, descricaoRemedio, feedbackRemedio;
          private int quantidadeRemedio = 1;
          private NegocioFornecedor fornecedor;
          private NegocioFuncionario funcionario;

          public NegocioFornecedor Fornecedor { get { return fornecedor; } set { fornecedor = value; } }
          public NegocioFuncionario Funcionario { get { return funcionario; } set { funcionario = value; } }
          public string NomeRemedio { get { return nomeRemedio; } set { nomeRemedio = value; } }
          public string DescricaoRemedio { get { return descricaoRemedio; } set { descricaoRemedio = value; } }
          public string FeedbackRemedio { get { return feedbackRemedio; } set {  feedbackRemedio = value; } }
          public int QuantidadeRemedio { get { return quantidadeRemedio;} set {  quantidadeRemedio = value; } }

          public override void Atualizar(Entidade medicamentoAtualizado)
          {
               NegocioMedicamento medicamento = (NegocioMedicamento)medicamentoAtualizado;

               nomeRemedio = medicamento.nomeRemedio;
               descricaoRemedio = medicamento.descricaoRemedio;
               feedbackRemedio = medicamento.feedbackRemedio;
               quantidadeRemedio = medicamento.quantidadeRemedio;
               fornecedor = medicamento.fornecedor;
               funcionario = medicamento.funcionario;
          }

          public void VerificarQuantidade()
          {
               if (quantidadeRemedio >= 5)
                    feedbackRemedio = "OK";
               else if (quantidadeRemedio > 0 && quantidadeRemedio < 5)
                    feedbackRemedio = "Acabando";
               else
                    feedbackRemedio = "Em Falta";
          }
     }
}
