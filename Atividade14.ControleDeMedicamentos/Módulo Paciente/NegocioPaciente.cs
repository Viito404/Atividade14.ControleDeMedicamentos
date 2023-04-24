using Atividade14.ControleDeMedicamentos.Módulo_Fornecedor;
using Atividade14.ControleDeMedicamentos.Utilitários;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14.ControleDeMedicamentos.Módulo_Paciente
{
     internal class NegocioPaciente : Entidade
     {
          private string nomePaciente, cpfPaciente, enderecoPaciente, telefonePaciente;

          public string NomePaciente { get { return nomePaciente; } set {  nomePaciente = value; } }
          public string CpfPaciente { get { return cpfPaciente; } set { cpfPaciente = value; } }
          public string EnderecoPaciente { get { return enderecoPaciente; } set { enderecoPaciente = value; } }      
          public string TelefonePaciente { get { return telefonePaciente; } set { telefonePaciente = value; } }

          public override void Atualizar(Entidade pacienteAtualizado)
          {
               NegocioPaciente paciente = (NegocioPaciente)pacienteAtualizado;

               nomePaciente = paciente.nomePaciente;
               cpfPaciente = paciente.cpfPaciente;
               enderecoPaciente = paciente.enderecoPaciente;
               telefonePaciente = paciente.telefonePaciente;
          }
     }
}
