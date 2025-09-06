using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_University.Model.Dtos
{
    public class SarchklDao
    {
        public int pidm { get; set; }
        public string? term_code { get; set;}
        public int program {get; set;}
        public string? admr_code { get; set;}
        public DateTime? receive_date { get; set;}
        public string? comment {get; set;}
        
    }
}
