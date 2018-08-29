using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }      // its a navigation type, to navigate from Customer to its MembershipType
        public byte MembershipTypeId { get; set; }              // Entity Framework recognizes this attribute as FK and apply it in database as FK.

        public DateTime? Birthdate { get; set; }
    }
}