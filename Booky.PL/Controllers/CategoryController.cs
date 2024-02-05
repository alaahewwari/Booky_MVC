using Booky.BL.Repositories;
using Booky.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booky.PL.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository;
        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
           ViewData["VDMessage"] = "Hello ViewData Message"; //old way
           ViewBag.VBMessage = "Hello ViewBag Message"; //new way
            var categories = _categoryRepository.GetAll();
            if(categories is null)
            {
                return BadRequest();//it is built in method in controller class
            }
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }//when click on create button it will call this method

        [HttpPost]
        public IActionResult Create(Category model)
        {
            if(ModelState.IsValid)
            {
                _categoryRepository.Insert(model);
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(model);
        } //when click on submit button

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category is null)
            {
                return NotFound();
            }
            return View(category);   
        }//when click on edit button 

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(model);
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(model);
        } //when click on submit button
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var category = _categoryRepository.GetById(id);
            if (category is null)
            {
                return NotFound();
            }
            return View(category);

        }//when click on edit button
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            if (category is null)
            {
                return NotFound();
            }
            _categoryRepository.Delete(category);
            return RedirectToAction("Index");
        }//when click on edit button 



    }
}
