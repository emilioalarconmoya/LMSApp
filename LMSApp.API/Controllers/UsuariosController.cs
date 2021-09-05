using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LMSApp.Common.Models;
using LMSApp.Domain.Models;
using System.Data.SqlClient;
using ATENEUS.CLASES.DAL;

namespace LMSApp.API.Controllers
{
    public class UsuariosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Usuarios
        public IQueryable<Usuario> GetUsuarios()
        {
            //return db.Usuarios;
            //return db.Database.SqlQuery<Usuario>("exec proc_select_USUARIO_all_app @cod_empresa", new SqlParameter("@cod_empresa", 1)).AsQueryable();
            DLUSUARIOList dLUSUARIO = new DLUSUARIOList();
            DataTable dataTable = dLUSUARIO.GetUsuariosApp(1);

            var importdata = from row in dataTable.AsEnumerable()
                             select new Usuario()
                             {
                                RutUsuario = row.Field<int>("RutUsuario"),
                                CodEmpresa = row.Field<int>("CodEmpresa"),
                                Nombres = row.Field<string>("Nombres"),
                                Apellidos = row.Field<string>("Apellidos"),
                                Password = row.Field<string>("Password"),
                                Email = row.Field<string>("Email"),
                                FechaCaducidad = row.Field<DateTime>("FechaCaducidad"),
                                FechaCreacion = row.Field<DateTime>("FechaCreacion"),
                                Bloqueado = row.Field<bool>("Bloqueado"),
                                ClaveSence = row.Field<string>("ClaveSence"),
                                Profesion = row.Field<string>("Profesion"),
                                Direccion = row.Field<string>("Direccion"),
                                Comuna = row.Field<string>("Comuna"),
                                Dni = row.Field<string>("Dni"),
                                Fono = row.Field<string>("Fono"),


                             } ;

            return importdata.AsQueryable();

            //return data;

            //var importdata = from x in dataTable.AsEnumerable()select new Usuario()
            //{
            //    RutUsuario = x.Field<int>("RutUsuario"),
            //    CodEmpresa = x.Field<int>("CodEmpresa"),
            //    Nombres = x.Field<string>("Nombres"),
            //    Apellidos = x.Field<string>("Apellidos"),
            //    Password = x.Field<string>("Password"),
            //    Email = x.Field<string>("Email"),
            //    FechaCaducidad = x.Field<DateTime>("FechaCaducidad"),
            //    FechaCreacion = x.Field<DateTime>("FechaCreacion"),
            //    Bloqueado = x.Field<bool>("Bloqueado"),
            //    ClaveSence = x.Field<string>("ClaveSence"),
            //    Profesion = x.Field<string>("Profesion"),
            //    Direccion = x.Field<string>("Direccion"),
            //    Comuna = x.Field<string>("Comuna"),
            //    Dni = x.Field<string>("Dni"),
            //    Fono = x.Field<string>("Fono"),


            //};

            //return importdata as IQueryable<Usuario>;


        }

       

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> GetUsuario(int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.RutUsuario)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Usuarios
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(usuario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usuario.RutUsuario }, usuario);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> DeleteUsuario(int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuario);
            await db.SaveChangesAsync();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuarios.Count(e => e.RutUsuario == id) > 0;
        }
    }
}