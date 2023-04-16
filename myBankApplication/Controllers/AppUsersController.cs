using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.ViewModels;

namespace myBankApplication.Controllers
{

    public class AppUsersController : Controller
    {
        private readonly IBankCardRepository _bankCardRepository;
        private readonly ApplicationDbContext _context;
        private readonly IAppUsersRepository _customerRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;

        public AppUsersController(IAppUsersRepository customerRepository, IHttpContextAccessor httpContextAccessor,
            IPhotoService photoService, IBankCardRepository bankCardRepository, ApplicationDbContext context )
        {
            _customerRepository = customerRepository;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
            _bankCardRepository = bankCardRepository;
            _context = context;
        }

        //Mapper
        private void MapEditUserProfile (AppUsersModel user, EditUserProfileViewModel editUserVM, ImageUploadResult photoResult)
        {
            user.Id = editUserVM.Id;
            user.Title = editUserVM.Title;
            user.FName = editUserVM.FName;
            user.MName = editUserVM.MName;
            user.LName = editUserVM.LName;
            user.Address = editUserVM.Address;
            user.Post_Code = editUserVM.Post_Code;
            user.PhoneNumber = editUserVM.PhoneNumber;
            user.Email = editUserVM.EmailAddress;
            
            user.Profile_Picture = photoResult.Url.ToString();
           
        }


        //admin
        public async Task<IActionResult> Index(string searchString)
        {

            //var users = await _customerRepository.GetAll();
            //List<AppUsersViewModel> result = new List<AppUsersViewModel>();

            var users = from m in _context.Users
                        select m;


            if (searchString != "" && searchString != null)
            {
                users = users.Where(s => s.FName!.Contains(searchString) || s.LName.Contains(searchString)
                || s.Email.Contains(searchString));
            }

            return View(users);
        }

        //User Bank Cards
        public async Task<IActionResult> CustomerCardDetails(string id)
        {
            var userBankCards = await _customerRepository.GetAllUsersBankCards();
            var userAccounts = await _customerRepository.GetAllUsersAccounts();
            var user = await _customerRepository.GetUserById(id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                BankCards = userBankCards,
                Accounts = userAccounts,
                FName = user.FName,
                MName = user.MName,
                LName = user.LName
            };

            return View(userDetailViewModel);
        }



        //Details
        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var userAccounts = await _customerRepository.GetAllUsersAccounts();

            if (userAccounts == null)
            {
                return RedirectToAction("Index", "AppUsers");
            }
           
            var user = await _customerRepository.GetUserById(id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                Accounts = userAccounts,
                Id = user.Id,
                Title = user.Title,
                FName = user.FName,
                MName = user.MName,
                LName = user.LName,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                CountryOfBirth = user.CountryOfBirth,
                Nationality = user.Nationality,
                Income = user.Income,
                Occupation = user.Occupation,
                Address = user.Address,
                Post_Code = user.Post_Code,
                Date_Joined = user.Date_Joined,
                Email = user.Email,
                Profile_Picture = user.Profile_Picture,
                Proof_Id = user.Proof_Id
                
            };

            return View(userDetailViewModel);
        }


        //Admin

        //Details
        [HttpGet]
        public async Task<IActionResult> UserDetail(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index", "AppUsers");
            }

            var acc = await _context.Accounts.ToListAsync();
            var userAccounts = acc.Where(r => r.AppUserId == user.Id);


            if (userAccounts == null)
            {
                return RedirectToAction("Index", "AppUsers");
            }


            var userDetailViewModel = new UserDetailViewModel()
            {
                Accounts = userAccounts.ToList(),
                Id = user.Id,
                Title = user.Title,
                FName = user.FName,
                MName = user.MName,
                LName = user.LName,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                CountryOfBirth = user.CountryOfBirth,
                Nationality = user.Nationality,
                Income = user.Income,
                Occupation = user.Occupation,
                Address = user.Address,
                Post_Code = user.Post_Code,
                Date_Joined = user.Date_Joined,
                Email = user.Email,
                Profile_Picture = user.Profile_Picture,
                Proof_Id = user.Proof_Id

            };

            return View(userDetailViewModel);
        }







        public async Task<IActionResult> Balance(string id)
        {

            var userAccounts = await _customerRepository.GetAllUsersAccounts();
            var userTransactions = await _customerRepository.GetAllUsersTransactions();
            var userBankCards = await _customerRepository.GetAllUsersBankCards();
            var userCheques = await _customerRepository.GetAllUsersCheques();

            var user = await _customerRepository.GetUserById(id);
            if (user == null)
            {
                return View("Error");
            }

            //Total Incoming
            var appUsersViewModel = new AppUsersViewModel()


            {
                Accounts = userAccounts,
                BankCards = userBankCards,
                Transactions = userTransactions,
                DepositCheque = userCheques,

                Title = user.Title,
                LName = user.LName,
                FName = user.FName,
                MName= user.MName,
                Email = user.Email,
                Nationality = user.Nationality,
                Profile_Picture = user.Profile_Picture,
            };

            return View(appUsersViewModel);
        }






        //Edit Profile
        [HttpGet]
        public async Task<IActionResult> EditUserProfile(string id)
        {
            //var user = await _customerRepository.GetUserById(id);
            //if (user == null) return View("Error");
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index", "AppUsers");
            }
            var editUserProfilVM = new EditUserProfileViewModel()
            {
                Id = user.Id,
                Title = user.Title,
                FName = user.FName,
                MName = user.MName,
                LName = user.LName,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Post_Code = user.Post_Code,
                EmailAddress = user.Email,
                Profile_PictureURL = user.Profile_Picture,
                

            };
            return View(editUserProfilVM); 
        }

        [HttpPost]

        public async Task<IActionResult> EditUserProfile (EditUserProfileViewModel editProfileVM)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditUserProfile", editProfileVM);
            }

            var user = await _customerRepository.GetUserByIdNoTracking(editProfileVM.Id);

            if (user.Profile_Picture == "" || user.Profile_Picture == null)
            {
                var photoResult = await _photoService.AddPhotoAsync(editProfileVM.Image);

                MapEditUserProfile(user, editProfileVM, photoResult);

                _customerRepository.Update(user);
                return RedirectToAction("Detail", "AppUsers");
            }

            else
            {
                try
                {
                    await _photoService.DeletePhotoAsync(user.Profile_Picture);
                }

                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Delete photo was unsuccessfull");
                    return View(editProfileVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(editProfileVM.Image);

                MapEditUserProfile(user, editProfileVM, photoResult);

                _customerRepository.Update(user);
                return RedirectToAction("Detail", "AppUsers");
            }
        }


        //Edit Profile
        [HttpGet]
        public async Task<IActionResult> EditCardPin(string id)
        {
            var user = await _customerRepository.GetUserById(id);
            var userBankCards = await _customerRepository.GetAllUsersBankCards();
            var bankcard = userBankCards.Where(a => a.AppUserId == user.Id).FirstOrDefault();
            if (user == null) return View("Error");
            var EditCardPin = new CardChangePinViewModel()
            {
                AppUserId = user.Id,
                CardPin = bankcard.CardPin,
                ContaclessLimit = bankcard.ContaclessLimit,
                //ConfrimPin = bankcard.CardPin,


            };
            return View(EditCardPin);
        }

        [HttpPost]

        public async Task<IActionResult> EditCardPin(CardChangePinViewModel cardpinVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditUserProfile", cardpinVM);
            }

            //var user = await _customerRepository.GetUserByIdNoTracking(cardpinVM.AppUserId);
            var user = await _customerRepository.GetUserById(cardpinVM.AppUserId);
            var userBankCards = await _customerRepository.GetAllUsersBankCards();
            var bankcard = userBankCards.Where(a => a.AppUserId == user.Id).FirstOrDefault();

            if (bankcard != null)
            {
                bankcard.ContaclessLimit = cardpinVM.ContaclessLimit;
                bankcard.CardPin = cardpinVM.CardPin;

            };

            _bankCardRepository.Update(bankcard);
            return RedirectToAction("CustomerCardDetails", "AppUsers");
            }

        [HttpGet]
        public async Task<IActionResult> DeleteCustomerProfile(string id)
        {
            var userDetails = await _customerRepository.GetUserById(id);
            if (userDetails == null) return View("Error");
            return View(userDetails);

        }


        [HttpPost, ActionName("DeleteCustomerProfile")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            var userDetails = await _customerRepository.GetUserById(id);
            if (userDetails == null) return View("Error");

            _customerRepository.Delete(userDetails);
            return RedirectToAction("Index", "Home");
        }




        public IActionResult AppUserPayment()
        {
            return isUserAuthenticated();
        }

        public IActionResult AppUserTransaction()
        {
            return isUserAuthenticated();
        }

        public IActionResult AppUserDepositCash()
        {
            return isUserAuthenticated();
        }
        
        
        public IActionResult AppUserCard()
        {
            return isUserAuthenticated();
        }
        public IActionResult AppUserDetail()
        {
            return isUserAuthenticated();
        }

        // Check if the user is authenicated 
        public IActionResult isUserAuthenticated()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "UserAuthentication");
            return View();
        }
    }
}
