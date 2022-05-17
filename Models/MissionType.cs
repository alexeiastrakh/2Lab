using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceWebApplication.Models
{
    public class MissionType
    {
        public int MissionTypeId { get; set; }

        public int MissionId { get; set; }

        public int TypeId { get; set; }


        public virtual Type Type { get; set; }
        public virtual Mission Mission { get; set; }
        


        }
}
