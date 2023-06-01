using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SemesterWebProject.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int userId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required, Please Enter Your Name")]
        public string userName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required, Please Enter Your Email")]
        [UniqueEmail(ErrorMessage = "Email already exists")]
        public string userEmail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required, Please Enter Your Password")]
        public string userPass { get; set; }
    }

    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = new ImageSaverContext(); // Replace 'YourDbContext' with your actual DbContext class name
            var usersWithEmail = dbContext.users.Where(u => u.userEmail == value.ToString()).ToList();

            if (usersWithEmail.Count > 0)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
