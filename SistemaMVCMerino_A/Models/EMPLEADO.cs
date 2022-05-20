namespace SistemaMVCMerino_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using SistemaMVCMerino_A.Models;

    [Table("EMPLEADO")]
    public partial class EMPLEADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLEADO()
        {
            USUARIO = new HashSet<USUARIO>();
        }

        [Key]
        public int IDEMPLEADO { get; set; }

        [Required]
        [StringLength(80)]
        public string DNI { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(150)]
        public string APELLIDO { get; set; }

        [Required]
        [StringLength(150)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string CELULAR { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string DIRECCION { get; set; }

        [Required]
        [StringLength(1)]
        public string ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }

        //Metodo listar
        public List<EMPLEADO> Listar() //Retornar colecci�n de objetos
        {
            var query = new List<EMPLEADO>();
            try
            {
                using (var db = new ModeloVentas())
                {
                    query = db.EMPLEADO.ToList();                 
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return query;
        }


    }
}
