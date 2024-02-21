using System;
using System.Collections.Generic;

namespace WebApiRH.Models
{
    public partial class Beneficio
    {
        public int IdBeneficio { get; set; }
        public string Nome { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public decimal Custo { get; set; }
        public int? IdFuncionario { get; set; }

        public virtual Funcionario? IdFuncionarioNavigation { get; set; }
    }
}
