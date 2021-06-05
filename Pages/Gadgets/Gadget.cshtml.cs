using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet5.RazorPage.EF.CRUD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.RazorPage.EF.CRUD.Pages.Gadgets
{
    public class GadgetModel : PageModel
    {
        public List<Data.Entities.Gadgets> AllGadgets = new List<Data.Entities.Gadgets>();

        private readonly MyWorldDbContext _myWorldDbContext;
        public GadgetModel(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        public async Task OnGetAsync()
        {
            AllGadgets = await _myWorldDbContext.Gadgets.OrderByDescending(_ => _.Id).ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var currentGadget = await _myWorldDbContext.Gadgets.FindAsync(id);
            if (currentGadget != null)
            {
                _myWorldDbContext.Gadgets.Remove(currentGadget);
                await _myWorldDbContext.SaveChangesAsync();
            }
            return Redirect("~/all-gadgets");
        }
    }
}