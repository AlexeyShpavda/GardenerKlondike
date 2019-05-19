using System;
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
    public class ProfileController : Controller
    {
        private IGoalRepository GoalRepository { get; }

        private IMapper Mapper { get; }

        public ProfileController()
        {
            GoalRepository = new GoalRepository();

            Mapper = new Mapper();
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var goalViewModels = Mapper.Map(await GoalRepository.GetAllAsync().ConfigureAwait(false));

                return View(goalViewModels);
            }
            catch (Exception e)
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
                var goalViewModel = Mapper.Map(await GoalRepository.GetAsync(id).ConfigureAwait(false));

                return View(goalViewModel);
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
        public async Task<ActionResult> Create(GoalViewModel goalViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(goalViewModel);
                }

                var currentUser = GetCurrentUser();
                goalViewModel.User = currentUser.Email;

                var goalEntity = Mapper.Map(goalViewModel);

                GoalRepository.Add(goalEntity);

                await GoalRepository.SaveAsync().ConfigureAwait(false);

                return RedirectToAction("Index");
            }
            catch (Exception e)
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
                var goalViewModel = Mapper.Map(await GoalRepository.GetAsync(id).ConfigureAwait(false));

                return View(goalViewModel);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(GoalViewModel goalViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(goalViewModel);
                }

                var goalEntity = Mapper.Map(goalViewModel);

                GoalRepository.Update(goalEntity);

                await GoalRepository.SaveAsync().ConfigureAwait(false);

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
                await GoalRepository.DeleteAsync(id).ConfigureAwait(false);

                await GoalRepository.SaveAsync().ConfigureAwait(false);

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
