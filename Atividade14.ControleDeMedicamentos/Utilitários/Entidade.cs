using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14.ControleDeMedicamentos.Utilitários
{
     internal class Entidade
     {
          public int id;
          
          public virtual void Atualizar(Entidade elemento)
          {
               id = elemento.id;
          }
     }
}
