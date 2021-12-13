using AutoMapper;
using DataAccessLayer.Contracts;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Areas.Admin.Controllers
{
    public class FlowerController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FlowerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var flowers = await _unitOfWork.Flowers.FindAll();
            var model = _mapper.Map<List<Flower>, List<FlowerVM>>(flowers.ToList());
            return View(model);
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create()
        {
            IEnumerable<Category> categories = await _unitOfWork.Categories.FindAll();
            var model = new FlowerVM()
            {
                CategoryList = categories.Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.Id.ToString()
                }),
                Category = new Category()
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(FlowerVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    IEnumerable<Category> categories = await _unitOfWork.Categories.FindAll();
                    var flowerVM = new FlowerVM()
                    {
                        CategoryList = categories.Select(x => new SelectListItem
                        {
                            Text = x.CategoryName,
                            Value = x.Id.ToString()
                        }),
                        Category = new Category()
                    };
                    return View(flowerVM);
                }
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    model.Images = p1;
                }
                else
                {
                    var objfromdb = await _unitOfWork.Flowers.Find(x => x.Id == model.Id);
                    model.Images = objfromdb.Images;
                }

                var flower = _mapper.Map<Flower>(model);

                await _unitOfWork.Flowers.Create(flower);
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
            var isExists = await _unitOfWork.Flowers.isExists(x => x.Id == id);
            if (!isExists)
            {
                return NotFound();
            }

            IEnumerable<Category> categories = await _unitOfWork.Categories.FindAll();

            var flower = await _unitOfWork.Flowers.Find(x => x.Id == id);
            var model = _mapper.Map<FlowerVM>(flower);
            model.CategoryList = categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()
            });
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(FlowerVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    IEnumerable<Category> categories = await _unitOfWork.Categories.FindAll();
                    var flowerVM = new FlowerVM()
                    {
                        CategoryList = categories.Select(x => new SelectListItem
                        {
                            Text = x.CategoryName,
                            Value = x.Id.ToString()
                        }),
                        Category = new Category()
                    };
                    return View(flowerVM);
                }
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    model.Images = p1;
                }
                else
                {
                    var objfromdb = await _unitOfWork.Flowers.Find(x => x.Id == model.Id);
                    model.Images = objfromdb.Images;
                }

                var flower = _mapper.Map<Flower>(model);
                _unitOfWork.Flowers.Update(flower);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                IEnumerable<Category> categories = await _unitOfWork.Categories.FindAll();
                var flowerVM = new FlowerVM()
                {
                    CategoryList = categories.Select(x => new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.Id.ToString()
                    }),
                    Category = new Category()
                };
                return View(flowerVM);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var flower = await _unitOfWork.Flowers.Find(expression: q => q.Id == id);
                if (flower == null)
                {
                    return NotFound();
                }
                _unitOfWork.Flowers.Delete(flower);
                await _unitOfWork.Save();
            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var isExists = await _unitOfWork.Flowers.isExists(x => x.Id == id);
            if (!isExists)
            {
                return NotFound();
            }

            IEnumerable<Category> categories = await _unitOfWork.Categories.FindAll();

            var flower = await _unitOfWork.Flowers.Find(x => x.Id == id);
            var model = _mapper.Map<FlowerVM>(flower);
            model.CategoryList = categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()
            });
            return View(model);
        }
    }
}