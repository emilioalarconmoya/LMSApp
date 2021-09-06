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
using ATENEUS.CLASES.DAL;

namespace LMSApp.Backend.Controllers
{
    public class ActividadVigentesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: ActividadVigentes
        public async Task<ActionResult> Index()
        {
            //return View(await db.ActividadVigentes.ToListAsync());
            DLACTIVIDADUSUARIOList dLUSUARIO = new DLACTIVIDADUSUARIOList();
            DataTable dataTable = dLUSUARIO.SelectActividadesVigentesApp(100,0,1,-4);


            return View(dataTable.AsEnumerable().Select(x => new ActividadVigente
            {
                CodActividadUsuario = x.Field<int>("CodActividadUsuario"),
                CodActividad = x.Field<int>("CodActividad"),
                Nombre = x.Field<string>("Nombre"),
                Objetivos = x.Field<string>("Objetivos"),
                Imagen = x.Field<string>("Imagen"),
                FechaFin = x.Field<DateTime>("FechaFin"),
                FechaInicio = x.Field<DateTime>("FechaInicio"),
                CodTipo = x.Field<int>("CodTipo"),
                CodEstado = x.Field<int>("CodEstado"),
                Asistencia = x.Field<int>("Asistencia"),
                Estado = x.Field<string>("Estado"),
                Vigente = x.Field<bool>("Vigente"),
                NotaFinal = x.Field<decimal>("NotaFinal"),
                MostrarCertificado = x.Field<bool>("MostrarCertificado"),
                ComunicaSence = x.Field<bool>("ComunicaSence"),
                FlagNuevaConexion = x.Field<bool>("FlagNuevaConexion"),
                RutTutor = x.Field<int>("RutTutor"),
                CodActividadTutor = x.Field<int>("CodActividadTutor"),


            }));
        }

        // GET: ActividadVigentes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadVigente actividadVigente = await db.ActividadVigentes.FindAsync(id);
            if (actividadVigente == null)
            {
                return HttpNotFound();
            }
            return View(actividadVigente);
        }

        // GET: ActividadVigentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActividadVigentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CodActividadUsuario,CodActividad,Nombre,Objetivos,Imagen,FechaFin,FechaInicio,CodTipo,CodEstado,Asistencia,Estado,Vigente,NotaFinal,MostrarCertificado,ComunicaSence,FlagNuevaConexion,RutTutor,CodActividadTutor")] ActividadVigente actividadVigente)
        {
            if (ModelState.IsValid)
            {
                db.ActividadVigentes.Add(actividadVigente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(actividadVigente);
        }

        // GET: ActividadVigentes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadVigente actividadVigente = await db.ActividadVigentes.FindAsync(id);
            if (actividadVigente == null)
            {
                return HttpNotFound();
            }
            return View(actividadVigente);
        }

        // POST: ActividadVigentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CodActividadUsuario,CodActividad,Nombre,Objetivos,Imagen,FechaFin,FechaInicio,CodTipo,CodEstado,Asistencia,Estado,Vigente,NotaFinal,MostrarCertificado,ComunicaSence,FlagNuevaConexion,RutTutor,CodActividadTutor")] ActividadVigente actividadVigente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividadVigente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(actividadVigente);
        }

        // GET: ActividadVigentes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadVigente actividadVigente = await db.ActividadVigentes.FindAsync(id);
            if (actividadVigente == null)
            {
                return HttpNotFound();
            }
            return View(actividadVigente);
        }

        // POST: ActividadVigentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ActividadVigente actividadVigente = await db.ActividadVigentes.FindAsync(id);
            db.ActividadVigentes.Remove(actividadVigente);
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
