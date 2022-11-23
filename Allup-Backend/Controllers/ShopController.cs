﻿using Allup_Backend.DAL;
using Allup_Backend.Models;
using Allup_Backend.ViewModels.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allup_Backend.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Search(int? id,string search)
        {
            IEnumerable<ProductListVM> products = await _context.Products.Where(
               p => id != null ? p.CategoryId == id : true &&
               p.Title.ToLower().Contains(search.ToLower()) ||
               p.Brand.Name.ToLower().Contains(search.ToLower()))
                .OrderByDescending(p=>p.Id)
                .Take(3)
               .Select(x=> new ProductListVM
               {
                   Id = x.Id,
                   Title = x.Title,
                   Image = x.MainImage
               }).ToListAsync();





            //List<ProductListVM> productListVMs = new List<ProductListVM>();

            


            //if (id != null)
            //{
            //    products = await _context.Products.Where(p => p.CategoryId == id
            //    && p.Title.ToLower().Contains(search.ToLower())
            //    || p.Brand.Name.ToLower().Contains(search.ToLower())).ToListAsync();
            //}
            //else
            //{
            //    products = await _context.Products.Where(p =>
            //    p.Title.ToLower().Contains(search.ToLower()) || 
            //    p.Brand.Name.ToLower().Contains(search.ToLower())).ToListAsync();                   
            //}

            return PartialView("_SearchPartial", products);
        } 
    }
}
