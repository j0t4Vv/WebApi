using System;
using System.Collections.Generic;

namespace WebApiRH.Models
{
    public partial class Salario
    {
        public int IdSalario { get; set; }
        public int? IdFuncionario { get; set; }
        public decimal Salario1 { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }

        public virtual Funcionario? IdFuncionarioNavigation { get; set; }
    }
}
