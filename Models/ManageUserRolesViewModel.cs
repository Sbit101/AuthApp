namespace AuthApp.Models
{
    public class ManageUserRolesViewModel
    {
        // This provides the view model for managing userroles
        // asscociated parts are  manage.html and the corresponding controller 
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}
