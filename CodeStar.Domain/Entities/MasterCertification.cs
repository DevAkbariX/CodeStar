using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Domain.Entities
{
    public class MasterCertification
    {
        public long Id { get; set; }
        public long FK_MasterId { get; set; }
        public string CertificateName { get; set; }
        public string Issuer { get; set; }     
        public DateTime DateReceived { get; set; }  
        public DateTime? ExpiryDate { get; set; } 

        public Master Master { get; set; }
    }
}
