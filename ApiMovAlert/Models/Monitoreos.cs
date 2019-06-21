namespace ApiMovAlert.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Monitoreos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Monitoreos()
        {
            Monitoreos_Incidencias = new HashSet<Monitoreos_Incidencias>();
        }

        [Key]
        public int IdMonitoreo { get; set; }

        [Required]
        [StringLength(6)]
        public string IdEquipo { get; set; }

        public bool Conectividad { get; set; }

        public bool Peligro { get; set; }

        public virtual Equipos Equipos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Monitoreos_Incidencias> Monitoreos_Incidencias { get; set; }
    }
}
