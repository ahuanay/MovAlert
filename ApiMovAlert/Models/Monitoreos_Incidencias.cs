namespace ApiMovAlert.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Monitoreos_Incidencias
    {
        [Key]
        public int IdMonitoreoIncidencia { get; set; }

        public int? IdMonitoreo { get; set; }

        public int? IdIncidencia { get; set; }

        public int? IdRequisitoriado { get; set; }

        public DateTime? FechaHora { get; set; }

        public virtual Incidencias Incidencias { get; set; }

        public virtual Monitoreos Monitoreos { get; set; }

        public virtual Requisitoriados Requisitoriados { get; set; }
    }
}
