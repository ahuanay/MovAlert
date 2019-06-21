namespace MovAlert.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Empleados
    {
        [Key, StringLength(8), Display(Name ="DNI")]
        public string IdEmpleado { get; set; }

        [Required, StringLength(50)]
        public string Apellido { get; set; }

        [Required, StringLength(50)]
        public string Nombre { get; set; }

        [Required, StringLength(9), Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required, StringLength(50), Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required, StringLength(50), Display(Name = "Contraseña"), DataType(DataType.Password)]
        public string UserPass { get; set; }

        [DataType(DataType.Upload)]
        public byte[] Avatar { get; set; }
    }
}
