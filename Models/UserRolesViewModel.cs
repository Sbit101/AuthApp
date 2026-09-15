namespace AuthApp.Models
{

    //This model provides an interface between the ApplictionUser
    //and the UserRolesController displaying the user and associated roles
    //in the UserRoles/Index.cshtml and UserRoles/Manage.cshtml
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }


    public class UserChatViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string UserName { get; set; }
        //public string Email { get; set; }
        public byte[] Img { get; set; }
        public string DefaultImg { get; set; }

        public UserChatViewModel(string userId, string firstName, byte[] img, string defaultImg)
        {
            this.UserId = userId;
            this.FirstName = firstName;
            this.Img = img;
            this.DefaultImg = defaultImg;
        }

        public UserChatViewModel(string userId, string firstName, string defaultImg)
        {
            this.UserId = userId;
            this.FirstName = firstName;
            this.DefaultImg = defaultImg;
        }
    }
}
