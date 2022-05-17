using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpaceWebApplication.Models
{
    public class Mission
    {
        public Mission()
        {
            MissionType = new List<MissionType>();
        }

        public int MissionId { get; set; }
      
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }
        [Display(Name = "Дата випуску")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public DateTime RealeseDate { get; set; }
     
        public string Info { get; set; }
       
        

     
        public int ExplorerId { get; set; }
        

      
        public virtual Explorer Explorer { get; set; }
       


        public ICollection<MissionType> MissionType { get; set; }
    }
}
