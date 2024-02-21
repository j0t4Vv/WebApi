using System;
using System.Collections.Generic;

namespace WebApiRH.Models
{
    public partial class Historico
    {
        public int IdHistorico { get; set; }
        public int? IdFuncionario { get; set; }
        public int? IdCargo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public string? MotivoSaida { get; set; }

        public virtual Cargo? IdCargoNavigation { get; set; }
        public virtual Funcionario? IdFuncionarioNavigation { get; set; }
    }
}
