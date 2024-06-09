using System.ComponentModel.DataAnnotations;

namespace DataValidations.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Emial { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(UserModel), "ValidateAge")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Highest Education is required")]
        public string HighestEducation { get; set; }
                                                          
        
        public string EngineeringBranch { get; set; }

        public static ValidationResult ValidateAge(DateTime dateOfBirth, ValidationContext context)
        {
            var age = DateTime.Now.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Now.AddYears(-age)) age--;
            return age >= 18 ? ValidationResult.Success : new ValidationResult("Age must be 18 or older");
        }



    }
}
