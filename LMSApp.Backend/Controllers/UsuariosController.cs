using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMSApp.Backend.Models;
using LMSApp.Common.Models;
using System.Data.SqlClient;
using ATENEUS.CLASES.DAL;



namespace LMSApp.Backend.Controllers
{
    public class UsuariosController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Usuarios
        public async Task<ActionResult> Index(string rut)
        {
            //return View(await db.Usuarios.ToListAsync());
            DLUSUARIOList dLUSUARIO = new DLUSUARIOList();
            DataTable dataTable = dLUSUARIO.GetUsuariosApp(rut);


            return View(dataTable.AsEnumerable().Select(x => new Usuario
            {
                RutUsuario = x.Field<int>("RutUsuario"),
                CodEmpresa = x.Field<int>("CodEmpresa"),
                Nombres = x.Field<string>("Nombres"),
                Apellidos = x.Field<string>("Apellidos"),
                Password = x.Field<string>("Password"),
                Email = x.Field<string>("Email"),
                FechaCaducidad = x.Field<DateTime>("FechaCaducidad"),
                FechaCreacion = x.Field<DateTime>("FechaCreacion"),
                Bloqueado = x.Field<bool>("Bloqueado"),
                ClaveSence = x.Field<string>("ClaveSence"),
                Profesion = x.Field<string>("Profesion"),
                Direccion = x.Field<string>("Direccion"),
                Comuna = x.Field<string>("Comuna"),
                Dni = x.Field<string>("Dni"),
                Fono = x.Field<string>("Fono"),


            }));
            //return View(await db.Usuarios.ToListAsync());
            //return View(await db.Database.SqlQuery<Usuario>("exec proc_select_USUARIO_all_app @cod_empresa", new SqlParameter("@cod_empresa", 1)).ToListAsync());


        }

        // GET: Usuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UsuarioId,RutUsuario,CodEmpresa,Nombres,Apellidos,Password,Email,FechaCaducidad,FechaCreacion,Bloqueado,ClaveSence,Profesion,Direccion,Comuna,Dni,Fono")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UsuarioId,RutUsuario,CodEmpresa,Nombres,Apellidos,Password,Email,FechaCaducidad,FechaCreacion,Bloqueado,ClaveSence,Profesion,Direccion,Comuna,Dni,Fono")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);
            db.Usuarios.Remove(usuario);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
