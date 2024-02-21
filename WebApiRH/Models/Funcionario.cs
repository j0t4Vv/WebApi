using System;
using System.Collections.Generic;

namespace WebApiRH.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Beneficios = new HashSet<Beneficio>();
            Departamentos = new HashSet<Departamento>();
            Historicos = new HashSet<Historico>();
            InverseIdGerenteNavigation = new HashSet<Funcionario>();
            Salarios = new HashSet<Salario>();
        }

        public int IdFuncionario { get; set; }
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Telefone { get; set; }
        public DateTime DataContratacao { get; set; }
        public int? IdCargo { get; set; }
        public int IdDepartamento { get; set; }
        public int? IdGerente { get; set; }

        public virtual Cargo? IdCargoNavigation { get; set; }
        public virtual Funcionario? IdGerenteNavigation { get; set; }
        public virtual ICollection<Beneficio> Beneficios { get; set; }
        public virtual ICollection<Departamento> Departamentos { get; set; }
        public virtual ICollection<Historico> Historicos { get; set; }
        public virtual ICollection<Funcionario> InverseIdGerenteNavigation { get; set; }
        public virtual ICollection<Salario> Salarios { get; set; }
    }
}
