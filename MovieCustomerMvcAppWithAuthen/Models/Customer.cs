using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerMvcAppWithAuthen.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Customer Name is Mandatory")]
        [StringLength(40,ErrorMessage ="Customer Name cannot exceed 40 characters")]
        public string  Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name="Membership Type")]
        public int MembershipTypeId { get; set; }
        [Display(Name ="Date Of Birth")]
        [Min18YrsIfMember]
        public DateTime? BirthDate { get; set; }
    }
}