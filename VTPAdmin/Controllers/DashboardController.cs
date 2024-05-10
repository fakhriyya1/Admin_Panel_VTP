using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VTPAdmin.DAL;
using VTPAdmin.Repositories.Abstraction;

namespace VTPAdmin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly AppDbContext dbContext;

        public DashboardController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var events = dbContext.Events.Where(e => e.EventDate > DateTime.Now && !e.IsDeleted).OrderBy(x => x.EventDate).Take(3).ToList();
            return View(events);
        }

        public IActionResult GenderDistribution()
        {
            var maleCount = dbContext.Members.Where(m => m.Gender == "Kişi").Count();
            var femaleCount = dbContext.Members.Where(m => m.Gender == "Qadın").Count();

            return Json(new { male = maleCount, female = femaleCount });
        }

        public IActionResult UniversityMemberCount()
        {
            var universityCounts = dbContext.Members
                .GroupBy(m => m.StudiedAt)
                .Select(g => new { University = g.Key, MemberCount = g.Count() })
                .ToList();

            return Json(universityCounts);
        }

        public IActionResult AgeMemberCount()
        {
            var ageCounts = dbContext.Members
                .GroupBy(m => m.Age)
                .OrderBy(g => g.Key)
                .Select(g => new { Age = g.Key, MemberCount = g.Count() })
                .ToList();

            return Json(ageCounts);
        }
    }
}
