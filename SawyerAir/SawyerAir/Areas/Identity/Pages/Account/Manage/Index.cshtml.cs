using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SawyerAir.Models;
using SawyerAir.Services;

namespace SawyerAir.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ClientService _clientService;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ClientService clientService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _clientService = clientService;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }


        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string Surname { get; set; }

            [Required]
            [StringLength(10, ErrorMessage = "Phone number must be 10 numbers long", MinimumLength = 10)]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "Adress")]
            public string Address { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            //var userName = await _userManager.GetUserNameAsync(user);

            var id = await _userManager.GetUserIdAsync(user);
            var client = _clientService.GetClientByUserId(id);

            Input = new InputModel
            {
                
                Surname = client.Surname,
                PhoneNumber = client.PhoneNumber,
                Name = client.Name,
                Address = client.Address
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

            var id = await _userManager.GetUserIdAsync(user);
            var client = _clientService.GetClientByUserId(id);

            client.Name = Input.Name;
            client.Surname = Input.Surname;
            client.Address = Input.Address;
            client.PhoneNumber = Input.PhoneNumber;

            _clientService.UpdateClient(client);
            _clientService.Save();



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
