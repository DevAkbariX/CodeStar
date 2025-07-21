using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class MasterResume
    {
        public long Id { get; set; }
        public long FK_MasterID { get; set; }
        public string Title { get; set; }         
        public string Description { get; set; }    
        public string StartDate { get; set; }    
        public string EndDate { get; set; }

        public Master Master { get; set; }
    }
}
