using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController( ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        List<Category> objCategoryList = _db.Categories.ToList();
        return View(objCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }
    
    
    [HttpPost]
    public IActionResult Create(Category obj){
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name","The value could not be equal to that of Display Order");
        }
        if (!ModelState.IsValid) return View();
        _db.Categories.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        Category? categoryFromDb = _db.Categories.Find(id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    [HttpPost]
    public IActionResult Edit(Category obj){
        
        if (!ModelState.IsValid) return View();
        _db.Categories.Update(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        Category? categoryFromDb = _db.Categories.Find(id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    
    [HttpPost,ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        Category? categoryToBeDeleted = _db.Categories.Find(id);
        if (categoryToBeDeleted == null)
        {
            return NotFound();
        }
        _db.Categories.Remove(categoryToBeDeleted);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}