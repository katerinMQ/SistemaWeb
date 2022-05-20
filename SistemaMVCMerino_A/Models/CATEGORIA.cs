namespace SistemaMVCMerino_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("CATEGORIA")]
    public partial class CATEGORIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIA()
        {
            PRODUCTO = new HashSet<PRODUCTO>();
        }

        [Key]
        public int IDCATEGORIA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Column(TypeName = "text")]
        public string DESCRIPCION { get; set; }

        [Required]
        [StringLength(1)]
        public string ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }

        //Implementar m�todos

        //M�todo Listar
        public List<CATEGORIA> Listar()
        {
            var query = new List<CATEGORIA>();
            try
            {
                using (var db = new ModeloVentas())
                {
                    query = db.CATEGORIA.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return query;
        }

        //Metodo obtener
        public CATEGORIA Obtener(int id) //Retornar objeto
        {
            var query = new CATEGORIA();
            try
            {
                using (var db = new ModeloVentas())
                {
                    query = db.CATEGORIA
                        .Where(x => x.IDCATEGORIA == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return query;
        }

        //Metodo buscar
        public List<CATEGORIA> Buscar(string criterio) //Retornar colecci�n de objetos
        {
            var query = new List<CATEGORIA>();
            try
            {
                using (var db = new ModeloVentas())
                {
                    query = db.CATEGORIA
                        .Where(x => x.IDCATEGORIA.ToString() == (criterio) ||
                                x.NOMBRE.Contains(criterio))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return query;
        }

        //Metodo guardar
        public void Guardar()
        {

            try
            {
                using (var db = new ModeloVentas())
                {
                    if (this.IDCATEGORIA > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Metodo eliminar
        public void Eliminar()
        {
            try
            {
                using (var db = new ModeloVentas())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
