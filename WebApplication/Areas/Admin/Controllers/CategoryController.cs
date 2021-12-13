using AutoMapper;
using DataAccessLayer.Common;
using DataAccessLayer.Contracts;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _unitOfWork.Categories.FindAll();
            var categoryVMs = _mapper.Map<List<Category>, List<CategoryVM>>(categories.ToList());
            return View(categoryVMs);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(CategoryVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var category = _mapper.Map<Category>(model);

                await _unitOfWork.Categories.Create(category);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            var isExists = await _unitOfWork.Categories.isExists(x => x.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var category = await _unitOfWork.Categories.Find(x => x.Id == id);
            var model = _mapper.Map<CategoryVM>(category);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(CategoryVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var category = _mapper.Map<Category>(model);
                _unitOfWork.Categories.Update(category);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var category = await _unitOfWork.Categories.Find(expression: q => q.Id == id);
                if (category == null)
                {
                    return NotFound();
                }
                _unitOfWork.Categories.Delete(category);
                await _unitOfWork.Save();
            }
            catch
            {
            }
            return RedirectToAction(nameof(Index));
        }
    }
}