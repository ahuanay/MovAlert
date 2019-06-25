namespace MovAlert.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Requisitoriados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Requisitoriados()
        {
            Monitoreos_Incidencias = new HashSet<Monitoreos_Incidencias>();
        }

        [Key, Display(Name = "Id Requisitoriado")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRequisitoriado { get; set; }

        [StringLength(250), Display(Name = "Url de la Imagen")]
        public string UrlImg { get; set; }

        [Display(Name = "Activo")]
        public bool Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Monitoreos_Incidencias> Monitoreos_Incidencias { get; set; }
    }
}
