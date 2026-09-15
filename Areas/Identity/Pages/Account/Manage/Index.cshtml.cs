// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AuthApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthApp.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>

            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Username")] // is email
            public string Username { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Profile Picture")]
            public byte[] ProfilePicture { get; set; }

            //new hair app: 
            // Hair app: needs new properties:
            [Display(Name = "Background Story")]
            public string BackgroundStory { get; set; }

            [Display(Name = "Specialties")]
            public string Specialties { get; set; }

            //fagoatniboius Pic One:
            [Display(Name = "Picture One")]
            public byte[] Picture_One { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //extended
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var profilePicture = user.ProfilePicture;
            var backgroundStory = user.BackgroundStory;
            var specialties = user.Specialties;
           // var picture_One = user.Picture_One;

            Username = userName;


            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                //new extended
                Username = userName,
                FirstName = firstName,
                LastName = lastName,
                ProfilePicture = profilePicture,
                BackgroundStory = backgroundStory,
                Specialties = specialties,
                //pic one yo n
               // Picture_One = picture_One,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            //added extended:
            var firstName = user.FirstName;
            var lastName = user.LastName;
           
            if (Input.FirstName != firstName)
            {
                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.LastName != lastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }

            //1 HARIR big new:

            if (user.BackgroundStory != Input.BackgroundStory)
            {
                user.BackgroundStory = Input.BackgroundStory;
                await _userManager.UpdateAsync(user);
            }

            //1 HARIR SpecialITY
            if (user.Specialties != Input.Specialties)
            {
                user.Specialties = Input.Specialties;
                await _userManager.UpdateAsync(user);
            }



            //extended profile pic 
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();

                ///set max size of file bytes to 2mb if greater redirect with status msg
                var file_len = file.Length;
                if (file_len > 2097152)
                {
                    StatusMessage = "Your profile picture must be less that 2 MB";
                    return RedirectToPage();

                }
                ///set max size of file bytes to 2mb if less proceed  
                if (file_len < 2097152)
                {
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        user.ProfilePicture = dataStream.ToArray();
                    }
                    await _userManager.UpdateAsync(user);
                }

            }


            //picture 1
           // if (Request.Form.Files.Count > 0)
           // {
            //    IFormFile file2 = Request.Form.Files.LastOrDefault();
                     // IFormFile file2 = Request.Form.Files[1];

                ///set max size of file bytes to 2mb if greater redirect with status msg
               // var file_len2 = file2.Length;
               // if (file_len2 > 2097152)
               // {
               //     StatusMessage = "Your profile picture must be less that 2 MB";
               //     return RedirectToPage();

              //  }
                ///set max size of file bytes to 2mb if less proceed  
              //  if (file_len2 < 2097152)
               // {
              //      using (var dataStream2 = new MemoryStream())
              //      {
              //          await file2.CopyToAsync(dataStream2);
              //          user.ProfilePicture = dataStream2.ToArray();
              //      }
              //      await _userManager.UpdateAsync(user);
                //}

           // }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }



    }
}
