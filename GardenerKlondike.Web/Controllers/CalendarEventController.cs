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
    public class CalendarEventController : Controller
    {
        private ICalendarEventRepository CalendarEventRepository { get; }

        private IMapper Mapper { get; }

        public CalendarEventController()
        {
            CalendarEventRepository = new CalendarEventRepository();

            Mapper = new Mapper();
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var calendarEventViewModels = Mapper.Map(await CalendarEventRepository
                    .GetAllPersonalEventsAsync(GetCurrentUser().Email).ConfigureAwait(false));

                return View(calendarEventViewModels);
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
                var calendarEventViewModel = Mapper.Map(await CalendarEventRepository.GetAsync(id).ConfigureAwait(false));

                return View(calendarEventViewModel);
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
        public async Task<ActionResult> Create(CalendarEventViewModel calendarEventViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(calendarEventViewModel);
                }

                var currentUser = GetCurrentUser();
                calendarEventViewModel.User = currentUser.Email;

                var calendarEventEntity = Mapper.Map(calendarEventViewModel);

                CalendarEventRepository.Add(calendarEventEntity);

                await CalendarEventRepository.SaveAsync().ConfigureAwait(false);

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
                var calendarEventViewModel = Mapper.Map(await CalendarEventRepository.GetAsync(id).ConfigureAwait(false));

                return View(calendarEventViewModel);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CalendarEventViewModel calendarEventViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(calendarEventViewModel);
                }

                var calendarEventEntity = Mapper.Map(calendarEventViewModel);

                CalendarEventRepository.Update(calendarEventEntity);

                await CalendarEventRepository.SaveAsync().ConfigureAwait(false);

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
                await CalendarEventRepository.DeleteAsync(id).ConfigureAwait(false);

                await CalendarEventRepository.SaveAsync().ConfigureAwait(false);

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
