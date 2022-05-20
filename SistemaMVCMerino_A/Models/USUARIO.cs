namespace SistemaMVCMerino_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [Key]
        public int IDUSUARIO { get; set; }

        public int IDEMPLEADO { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(250)]
        public string CLAVE { get; set; }

        [Required]
        [StringLength(15)]
        public string NIVEL { get; set; }

        [Required]
        [StringLength(250)]
        public string AVATAR { get; set; }

        public int? ESTADO { get; set; }

        public virtual EMPLEADO EMPLEADO { get; set; }

        //Implementar m�todos

        //M�todo Listar
        public List<USUARIO> Listar()
        {
            var query = new List<USUARIO>();
            try
            {
                using (var db = new ModeloVentas())
                {
                    query = db.USUARIO.Include("EMPLEADO").ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return query;
        }

        //Metodo obtener
        public USUARIO Obtener(int id) //Retornar objeto
        {
            var query = new USUARIO();
            try
            {
                using (var db = new ModeloVentas())
                {
                    query = db.USUARIO.Include("EMPLEADO")
                        .Where(x => x.IDUSUARIO == id)
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
        public List<USUARIO> Buscar(string criterio) //Retornar colecci�n de objetos
        {
            var query = new List<USUARIO>();
            try
            {
                using (var db = new ModeloVentas())
                {
                    query = db.USUARIO.Include("EMPLEADO").ToList()
                        .Where(x => x.IDUSUARIO.ToString() == (criterio) ||
                                x.NOMBRE.Contains(criterio) ||
                                x.EMPLEADO.APELLIDO.Contains(criterio))
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
                    if (this.IDUSUARIO > 0)
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

        //Metodo acceder
        public ResponseModel Acceder(string Usuario, string Password)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new ModeloVentas())
                {
                    Password = HashHelper.MD5(Password);

                    var usuario = db.USUARIO.Where(x => x.NOMBRE == Usuario)
                                            .Where(x => x.CLAVE == Password)
                                            .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(IDUSUARIO.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario y/o Password incorrectos...");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return rm;
        }
    }
}
