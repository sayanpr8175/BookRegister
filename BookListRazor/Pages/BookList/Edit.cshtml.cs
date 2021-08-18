using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {

        private ApplicationDbContext _db;


        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }


        [BindProperty]
        public Book B { get; set; }


        public async Task OnGet(int id)
        {
            B = await _db.Books.FindAsync(id);

        }


        public async Task<IActionResult> OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                Book BookFromDb = await _db.Books.FindAsync(B.Id);
                BookFromDb.Name = B.Name;
                BookFromDb.ISBN = B.ISBN;
                BookFromDb.Author = B.Author;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");

            }
            
                return RedirectToPage();
           

        }


    }
}
