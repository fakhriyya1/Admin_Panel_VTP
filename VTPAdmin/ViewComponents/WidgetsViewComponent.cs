using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VTPAdmin.DAL;
using VTPAdmin.ViewComponentModels;

namespace VTPAdmin.ViewComponents
{
    public class WidgetsViewComponent : ViewComponent
    {
        private readonly AppDbContext dbContext;

        public WidgetsViewComponent(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int? memberCount = await dbContext.Members.CountAsync();
            int? femaleMemberCount = await dbContext.Members.CountAsync(x => x.Gender == "Qadın");
            int? maleMemberCount = await dbContext.Members.CountAsync(x => x.Gender == "Kişi");

            WidgetModel model = new WidgetModel
            {
                MemberCount = memberCount,
                FemaleMemberCount = femaleMemberCount,
                MaleMemberCount = maleMemberCount
            };

            return View(model);
        }
    }
}
