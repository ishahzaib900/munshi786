using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Munshi786.Models
{
    public class Property
    {
        public Nullable<int> id { get; set; }

        [Required]
        [Display(Name ="Area")]
        public string area { get; set; }
        [Required]
        [Display(Name ="Building")]
        public string building { get; set; }
        [Required]
        [Display(Name = "Contract Start")]
        public DateTime contract_start_date { get; set; }
        [Required]
        [Display(Name = "Contract End")]
        public DateTime contract_end_date { get; set; }
        [Required]
        [Display(Name = "Rent")]
        public decimal rent { get; set; }
        [Required]
        [Display(Name = "Deposite")]
        public decimal deposite { get; set; }
        [Required]
        [Display(Name = "Commission")]
        public decimal commission { get; set; }
        public int no_beds { get; set; }
        public int no_cheques { get; set; }
        [Required]
        public string appartment_no { get; set; }
        [Required]
        public string dewa_no { get; set; }
        public string du_no { get; set; }
        public string empower_no { get; set; }
        public string file { get; set; }
        public DateTime created_date { get; set; }
        public int created_by { get; set; }
        public int owner_id { get; set; }
        public int status { get; set; }
        [NotMapped]
        public int contract_renew { get; set; }
    }

}