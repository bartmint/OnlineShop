using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Order()
        {
            OrderLines = new List<OrderDetail>();
        }
        public  ICollection<OrderDetail> OrderLines { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your adress")]
        [Display(Name = "Address Line 1")]
        [StringLength(70)]
        public string AdressLine { get; set; }
        [Required(ErrorMessage = "Please enter your zip code")]
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(10)]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your country")]
        [StringLength(30)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
    }
}
