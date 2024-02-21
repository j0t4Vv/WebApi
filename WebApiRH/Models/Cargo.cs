using System;
using System.Collections.Generic;

namespace WebApiRH.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            Funcionarios = new HashSet<Funcionario>();
            Gerentes = new HashSet<Gerente>();
            Historicos = new HashSet<Historico>();
        }

        public int IdCargo { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
        public virtual ICollection<Gerente> Gerentes { get; set; }
        public virtual ICollection<Historico> Historicos { get; set; }
    }
}
