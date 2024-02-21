using System;
using System.Collections.Generic;

namespace WebApiRH.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Gerentes = new HashSet<Gerente>();
        }

        public int IdDepartamento { get; set; }
        public string Nome { get; set; } = null!;
        public int? IdGerente { get; set; }

        public virtual Funcionario? IdGerenteNavigation { get; set; }
        public virtual ICollection<Gerente> Gerentes { get; set; }
    }
}
