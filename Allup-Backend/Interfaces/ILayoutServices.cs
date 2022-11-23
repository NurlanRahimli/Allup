using Allup_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allup_Backend.Interfaces
{
    public interface ILayoutServices
    {
        Task<Dictionary<string, string>> GetSettingAsync();
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
