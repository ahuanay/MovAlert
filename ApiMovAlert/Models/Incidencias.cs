namespace ApiMovAlert.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Incidencias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Incidencias()
        {
            Monitoreos_Incidencias = new HashSet<Monitoreos_Incidencias>();
        }

        [Key]
        public int IdIncidencia { get; set; }

        [Required]
        [StringLength(50)]
        public string Incidencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Monitoreos_Incidencias> Monitoreos_Incidencias { get; set; }
    }
}
