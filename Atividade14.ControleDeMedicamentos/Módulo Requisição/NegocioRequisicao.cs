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
     internal class NegocioRequisicao : Entidade
     {
          private string dataRequisicao;
          
          private NegocioFuncionario negocioFuncionario;
          private NegocioPaciente negocioPaciente;
          private NegocioMedicamento negocioMedicamento;

          public NegocioFuncionario NegocioFuncionario { get { return negocioFuncionario; } set { negocioFuncionario = value; } }
          public NegocioPaciente NegocioPaciente { get { return negocioPaciente; } set { negocioPaciente = value; } }
          public NegocioMedicamento NegocioMedicamento { get { return negocioMedicamento; } set { negocioMedicamento = value; } }

          public string DataRequisicao { get { return dataRequisicao; } set { dataRequisicao = value; } }

     }
}
