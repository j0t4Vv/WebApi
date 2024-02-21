using System;
using System.Collections.Generic;

namespace WebApiRH.Models
{
    public partial class Gerente
    {
        public int IdGerente { get; set; }
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public int? IdCargo { get; set; }
        public int? IdDepartamento { get; set; }

        public virtual Cargo? IdCargoNavigation { get; set; }
        public virtual Departamento? IdDepartamentoNavigation { get; set; }
    }
}
