using AutoMapper;
using DataAccessLayer.Contracts;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class FlowerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FlowerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int id)
        {
            var flowers = await _unitOfWork.Flowers.FindAll(x=>x.CategoryId==id);
            var model = _mapper.Map<List<Flower>, List<FlowerVM>>(flowers.ToList());
            return View(model);
        }
    }
}
