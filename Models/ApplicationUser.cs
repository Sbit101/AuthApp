using Microsoft.AspNetCore.Identity;

namespace AuthApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        
        //Todo:
        //this needs a limit on the maximum value due to an array only being 
        //able to hold so much. This should also limmited to prevent bufferover flow exploits
        public byte[]? ProfilePicture { get; set; }

         public string? BackgroundStory { get; set; }
         public string? Specialties { get; set; }

        public byte[]? PictureOne { get; set; }

        //string? ChatPicGuid { get; set; } = Guid.NewGuid().ToString(); //new    
        ///public byte[]? Picture_Two { get; set; }
        ///public byte[]? Picture_Three { get; set; }
        ///public byte[]? Picture_Four { get; set; }
        /// public byte[]? Picture_One { get; set; } /// bad name


        //add social links get images:linkdnen ect
        //public string? Linkden,ig ect { get; set; }

        //add country
        //public string? Country { get; set; }

        //public string? City { get; set; }

        //add education level/profession ie student, Sysadmin
        //public string? Education { get; set; }

        //Goals:
        //public string? Goals { get; set; }





    }
}
