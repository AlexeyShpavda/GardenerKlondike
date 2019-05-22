using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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

        public JsonResult GetWeather()
        {
            try
            {
                const string url = "http://api.openweathermap.org/data/2.5/weather?q=Hrodna&APPID=e50efa3ae2201efcb089d47c31c071a8&units=imperial";

                var client = new WebClient();
                var content = client.DownloadString(url);
                var serializer = new JavaScriptSerializer();
                var jsonContent = serializer.Deserialize<object>(content);

                return Json(jsonContent, JsonRequestBehavior.AllowGet);
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
