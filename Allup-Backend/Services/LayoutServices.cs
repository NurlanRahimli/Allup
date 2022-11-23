using Allup_Backend.DAL;
using Allup_Backend.Interfaces;
using Allup_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allup_Backend.Services
{
    public class LayoutServices : ILayoutServices
    {
        private readonly AppDbContext _context;
        
        public LayoutServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.Include(c => c.Children).Where(c => c.IsDeleted == false && c.IsMain == true).ToListAsync();
        }

        public async Task<Dictionary<string,string>> GetSettingAsync()
        {
            return await _context.Settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);
        }
    }
}
