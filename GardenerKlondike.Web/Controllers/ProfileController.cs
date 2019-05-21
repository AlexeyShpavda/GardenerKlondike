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

        private ICalendarEventRepository CalendarEventRepository { get; }

        private IMapper Mapper { get; }

        public ProfileController()
        {
            GoalRepository = new GoalRepository();

            CalendarEventRepository = new CalendarEventRepository();

            Mapper = new Mapper();
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var currentUserEmail = GetCurrentUser().Email;

                var profileViewModel = new ProfileViewModel
                {
                    GoalViewModels = Mapper.Map(await GoalRepository.GetAllPersonalGoalsAsync(currentUserEmail)
                        .ConfigureAwait(false)),

                    CalendarEventViewModels = Mapper.Map(await CalendarEventRepository
                        .GetAllPersonalEventsAsync(currentUserEmail).ConfigureAwait(false))
                };

                return View(profileViewModel);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                return View();
            }
        }

        private ApplicationUser GetCurrentUser()
        {
            return System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        }

        public async Task<JsonResult> GetEvents()
        {
            try
            {
                var events = await CalendarEventRepository.GetAllAsync().ConfigureAwait(false);

                return Json(events, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Success = false,
                    e.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
