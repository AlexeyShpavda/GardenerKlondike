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

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var articleViewModels = Mapper.Map(await ArticleRepository.GetAllAsync().ConfigureAwait(false));

                return View(articleViewModels);
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;

                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var articleViewModel = Mapper.Map(await ArticleRepository.GetAsync(id).ConfigureAwait(false));

                return View(articleViewModel);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                return View();
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ArticleViewModel articleViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(articleViewModel);
                }

                var currentUser = GetCurrentUser();
                articleViewModel.Author = currentUser.Email;

                var articleEntity = Mapper.Map(articleViewModel);

                ArticleRepository.Add(articleEntity);

                await ArticleRepository.SaveAsync().ConfigureAwait(false);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;

                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var articleViewModel = Mapper.Map(await ArticleRepository.GetAsync(id).ConfigureAwait(false));

                return View(articleViewModel);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ArticleViewModel articleViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(articleViewModel);
                }

                var articleEntity = Mapper.Map(articleViewModel);

                ArticleRepository.Update(articleEntity);

                await ArticleRepository.SaveAsync().ConfigureAwait(false);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await ArticleRepository.DeleteAsync(id).ConfigureAwait(false);

                await ArticleRepository.SaveAsync().ConfigureAwait(false);

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
