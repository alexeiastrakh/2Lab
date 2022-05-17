using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpaceWebApplication.Models
{
    public class Country
    {
        public Country()
        {
            
            Explorers = new List<Explorer>();
        }
        public int CountryId { get; set; }
        [Display(Name = "Країна")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }

       

        public ICollection<Explorer> Explorers { get; set; }

    }
}
