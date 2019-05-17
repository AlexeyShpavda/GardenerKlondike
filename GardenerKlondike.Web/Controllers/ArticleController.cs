using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GardenerKlondike.DAL.Contracts.Repositories;
using GardenerKlondike.DAL.Repositories;
using GardenerKlondike.Web.Interfaces.Support.Adapter;
using GardenerKlondike.Web.Models;
using GardenerKlondike.Web.Support.Adapter;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace GardenerKlondike.Web.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private IArticleRepository ArticleRepository { get; }

        private IMapper Mapper{ get; }

        public ArticleController()
        {
            ArticleRepository = new ArticleRepository();

            Mapper = new Mapper();
        }

        // GET: Article
        public ActionResult Index()
        {
            var articleViewModels = Mapper.Map(ArticleRepository.GetAll());

            return View(articleViewModels);
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        public async Task<ActionResult> Create(ArticleViewModel articleViewModel)
        {
            try
            {
                var currentUser = GetCurrentUser();

                articleViewModel.Author = currentUser.Email;

                var articleEntity = Mapper.Map(articleViewModel);

                ArticleRepository.Add(articleEntity);

                await ArticleRepository.SaveAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Article/Edit/5
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

        // GET: Article/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await ArticleRepository.DeleteAsync(id).ConfigureAwait(false);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;

                return RedirectToAction("Index");
            }
        }

        private ApplicationUser GetCurrentUser()
        {
            return System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        }
    }
}
