using PhoneStatus.helpers;
using PhoneStatus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PhoneStatus.Controllers
{
    public class FicheController : Controller
    {
        private IList<FicheModel> LoadListFiche()
        {
            IList<FicheModel> listFiche = new List<FicheModel>();
           
            return listFiche;
        }
        // GET: Fiche
        public async Task<ActionResult> Index()
        {
            IList<FicheModel> listFiches = new List<FicheModel>();
            //using (HttpClient client = new HttpClient())
            //{
            //    HttpResponseMessage response = await client.GetAsync("http://localhost:55502/api/Fiches/");
            //    if (response.IsSuccessStatusCode)
            //    {
            //        listFiches = await response.Content.ReadAsAsync<IList<FicheModel>>();
            //    }
            //}

            listFiches = await APIHelper.Get<IList<FicheModel>>("http://localhost:55502/api/Fiches/");

            listFiches = listFiches.Select(fiche => {
                fiche.status = new Status(fiche.Etat);
                return fiche;
            }).ToList();
            return View(listFiches);
        }

        // GET: Fiche/Details/5
        public ActionResult Details(int id)
        {
            return GetFicheById(id);
        }

        // GET: Fiche/Create
        public async Task<ActionResult> CreateAsync()
        {
            IEnumerable<dynamic> listClient = new List<dynamic>();
            try
            {
                listClient = await APIHelper.Get<IEnumerable<dynamic>>("http://localhost:55502/api/Clients/");
            }
            catch (HttpRequestException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                throw new HttpResponseException(resp);
            }
            
            Fiche_Create ficheToAdd = new Fiche_Create();


            ficheToAdd.ListClient = listClient
                .Select(item =>
                    new SelectListItem(){
                        Text = item.Nom + " " + item.Prenom,
                        Value = item.Id
                    });

            return View(ficheToAdd);
        }

        // POST: Fiche/Create
        [HttpPost]
        public async Task<ActionResult>CreateAsync(Fiche_Create ficheToCreate)
        {
            try
            {
                await APIHelper.CreateAsync<Fiche_Create>("http://localhost:55502/api/Fiches/", ficheToCreate);

                return RedirectToAction("index");
            }
            catch (HttpRequestException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                throw new HttpResponseException(resp);
            }
        }

        // GET: Fiche/Edit/5
        public ActionResult Edit(int id)
        {
            return GetFicheById(id);
        }

        // POST: Fiche/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fiche/Delete/5
        public ActionResult Delete(int id)
        {
            return GetFicheById(id);
        }

        // POST: Fiche/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ProgressBar(int id)
        {
            return PartialView();
        }

        private ActionResult GetFicheById(int id)
        {
            ActionResult result;
            IList<FicheModel> list = LoadListFiche();
            var fiche = list.SingleOrDefault(f => f.Id == id);
            if (fiche == null) result = new HttpNotFoundResult("fiche inexistante");
            else result = View(fiche);

            return result;
        }
    }
}
