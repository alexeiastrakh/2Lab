using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpaceWebApplication.Models
{
    public class Explorer
    {
        public Explorer()
        {
            Missions = new List<Mission>();
        }

        public int ExplorerId { get; set; }
        [Display(Name = "Дослiдник")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }

        public string Info { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }


        public ICollection<Mission> Missions { get; set; }

    }
}
