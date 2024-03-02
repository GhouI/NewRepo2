using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BasicSkin.Data;
using BasicSkin.Data.Flags;
using BasicSkin.Models;

namespace BasicSkin.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryModel CategoryModel { get; set; }

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Item.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // Getting the flags and turning them into string
        public IActionResult GetCategories()
        {
            var categories = Enum.GetValues(typeof(Category))
                                 .Cast<Category>()
                                 .Select(c => new SelectListItem
                                 {
                                     Value = ((int)c).ToString(),
                                     Text = c.ToString()
                                 })
                                 .ToList();
            CategoryModel.ListOfCategories = categories;

            return View(CategoryModel);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            CategoryModel = new CategoryModel(); // Initialize CategoryModel
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Change the action name from CreateItem to Create
        public async Task<IActionResult> Create([Bind("ItemId,Name,Description,Category,Price,Quantity,ImageURL")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.ItemId = Guid.NewGuid();
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }


        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // ... (other actions) ...

        private bool ItemExists(Guid id)
        {
            return _context.Item.Any(e => e.ItemId == id);
        }
    }
}
