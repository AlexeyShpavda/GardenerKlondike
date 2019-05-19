using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using GardenerKlondike.DAL.Contracts.Repositories;
using GardenerKlondike.DAL.Repositories;
using GardenerKlondike.Web.Interfaces.Support.Adapter;
using GardenerKlondike.Web.Support.Adapter;

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
                var goalViewModels = Mapper.Map(await GoalRepository.GetAllAsync().ConfigureAwait(false));

                ViewBag.events = Mapper.Map(await CalendarEventRepository.GetAllAsync().ConfigureAwait(false));

                return View(goalViewModels);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                return View();
            }
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
