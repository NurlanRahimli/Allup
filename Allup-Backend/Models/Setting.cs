using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Allup_Backend.Models
{
    public class Setting : BaseEntity
    {
        [StringLength(2500)]
        public string Key { get; set; }
        [StringLength(2500)]

        public string Value { get; set; }

    }
}
