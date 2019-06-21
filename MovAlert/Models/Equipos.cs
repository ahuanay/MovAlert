namespace MovAlert.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Equipos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipos()
        {
            Monitoreos = new HashSet<Monitoreos>();
        }

        [Key, StringLength(6), Display(Name ="Serie Equipo")]
        public string IdEquipo { get; set; }

        [Required, StringLength(8), Display(Name ="DNI")]
        public string IdCliente { get; set; }

        public virtual Clientes Clientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Monitoreos> Monitoreos { get; set; }
    }
}
