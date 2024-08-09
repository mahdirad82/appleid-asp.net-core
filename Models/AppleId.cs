using System.ComponentModel.DataAnnotations;
using AppleAccounts.Data.Enums;

namespace AppleAccounts.Models
{
    public class AppleId
    {
        [Key]
        [Display(Name = "ID")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Apple ID")]
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Not a valid Email!")]
        public string? Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required!")]
        [StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "Minimum length of password is 8 chars!")]
        public string? Password { get; set; }

        [Display(Name = "Birth day")]
        public DateOnly BirthDay { get; set; }

        [Display(Name = "What is the first name of your best friend in highschool?")]
        [Required(ErrorMessage = "Security Question is required!")]
        public string? QuestionOne { get; set; }

        [Display(Name = "What's your dream job?")]
        [Required(ErrorMessage = "Security Question is required!")]
        public string? QuestionTwo { get; set; }

        [Display(Name = "In what city did your parents meet?")]
        [Required(ErrorMessage = "Security Question is required!")]
        public string? QuestionThree { get; set; }

        [Display(Name = "Apple ID Status")]
        [Required]
        public AppleIdStatus Status { get; set; }

        public bool Expired { get; set; } = false;
    }
}