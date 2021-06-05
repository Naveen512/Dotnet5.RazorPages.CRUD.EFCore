using System.Linq;
using System.Threading.Tasks;
using Dotnet5.RazorPage.EF.CRUD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.RazorPage.EF.CRUD.Pages.Gadgets
{
    public class EditGadgetModel : PageModel
    {
        [BindProperty]
        public Data.Entities.Gadgets GadgetToUpdate { get; set; }

        private readonly MyWorldDbContext _myWorldDbContext;
        public EditGadgetModel(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            GadgetToUpdate = await _myWorldDbContext.Gadgets.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (GadgetToUpdate == null)
            {
                return Redirect("~/all-gadgets");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _myWorldDbContext.Attach(GadgetToUpdate).State = EntityState.Modified;
            await _myWorldDbContext.SaveChangesAsync();
            return Redirect("~/all-gadgets");
        }
    }
}