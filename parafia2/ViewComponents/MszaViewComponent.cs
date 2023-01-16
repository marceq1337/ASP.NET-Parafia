using Microsoft.AspNetCore.Mvc;
using parafia2.Models.DataLayer;

namespace parafia2.ViewComponents
{
    public class MszaViewComponent : ViewComponent
    {
        private readonly ParafiaContext _context;


        public MszaViewComponent(ParafiaContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var allMsze = _context.Mszes.Count();
            ViewData["liczba"] = allMsze;
            return View();
        }
    }
}
