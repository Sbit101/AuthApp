using System.ComponentModel.DataAnnotations;

namespace AuthApp.Models
{
    public class WelcomeForm
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Company Email")]
        public string CompanyEmail { get; set; }

        //[Required]
        //[Phone]
        [Display(Name = "Company Phone Number")]
        public double? CompanyPhoneNumber { get; set; } //was uint

        [Display(Name = "Company Name")]
        [Required]
        [StringLength(255)]
        public string CompanyName { get; set; }

        [Display(Name = "Country")]
        [Required]
        [StringLength(255)]
        public string Country { get; set; }

        [Display(Name = "City")]
        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Display(Name = "Expected Shipment Ammount in Kilograms")]
        public int? ExpectedShipmentKg { get; set; }

        [Display(Name = "Message")]
        [Required]
        [StringLength(5000)]
        public string Message { get; set; }

        public DateTime DatePosted { get; set; }

    }
}
