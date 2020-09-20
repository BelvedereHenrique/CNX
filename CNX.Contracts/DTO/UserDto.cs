using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CNX.Contracts.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Hometown { get; set; }

        public List<NoteDto> Notes { get; set; }

        public List<string> ValidateFields()
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(this.Email))
                errors.Add("Invalid E-mail");

            if(string.IsNullOrEmpty(this.Name))
                errors.Add("Invalid Nome");

            if(string.IsNullOrEmpty(this.Password))
                errors.Add("Invalid password");

            if (string.IsNullOrEmpty(this.Hometown))
                errors.Add("Invalid Hometown");

            return errors;
        }
    }
}
