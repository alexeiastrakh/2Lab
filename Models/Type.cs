using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpaceWebApplication.Models
{
    public class Type
    {
        public Type()
        {
            MissionType = new List<MissionType>();
        }
        public int Id { get; set; }
     
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }
    
        public string Info { get; set; }


        public ICollection<MissionType> MissionType { get; set; }
    }
}
