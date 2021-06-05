using System.Threading.Tasks;
using Dotnet5.RazorPage.EF.CRUD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dotnet5.RazorPage.EF.CRUD.Pages.Gadgets
{
    public class CreateGadgetModel : PageModel
    {
        [BindProperty]
        public Data.Entities.Gadgets NewGadget { get; set; }
        private readonly MyWorldDbContext _myWorldDbContext;
        public CreateGadgetModel(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        public IActionResult OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _myWorldDbContext.Gadgets.Add(NewGadget);
            await _myWorldDbContext.SaveChangesAsync();
            return Redirect("all-gadgets");
        }
    }
}