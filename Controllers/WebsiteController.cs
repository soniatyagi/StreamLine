using Microsoft.AspNetCore.Mvc;
using StreamLineServices.Models;
using System.Net.Mail;
using System.Net;
using NToastNotify;
using System.Reflection;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace StreamLineServices.Controllers
{
    public class WebsiteController : Controller
    {
        private readonly ILogger<WebsiteController> _logger;
        private readonly INotyfService _notyf;

        public WebsiteController(INotyfService notyf, ILogger<WebsiteController> logger)
        {
            _notyf = notyf;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Navbar = "Home";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Navbar = "Pages";
            return View();
        }

        public IActionResult Terms()
        {
            ViewBag.Navbar = "Pages";
            return View();
        }

        public IActionResult ErrorPage()
        {
            return View();
        }

        public IActionResult Blog()
        {
            ViewBag.Navbar = "Blog";
            return View();
        }

        public IActionResult BlogSingle()
        {
            ViewBag.Navbar = "Blog";
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Navbar = "Contact";
            return View();
        }

        public IActionResult Faq()
        {
            ViewBag.Navbar = "Pages";
            return View();
        }

        public IActionResult Movies()
        {
            ViewBag.Navbar = "Pages";
            return View();
        }

        public IActionResult Services()
        {
            ViewBag.Navbar = "Services";
            return View();
        }

        public IActionResult Shop()
        {
            ViewBag.Navbar = "Shop";
            return View();
        }

        public IActionResult ShopCart()
        {
            ViewBag.Navbar = "Shop";
            return View();
        }

        public IActionResult ShopCheckout()
        {
            ViewBag.Navbar = "Shop";
            return View();
        }

        public IActionResult ServicesSingle()
        {
            ViewBag.Navbar = "Services";
            return View();
        }

        public IActionResult ShopSingle()
        {
            ViewBag.Navbar = "Shop";
            return View();
        }

        public IActionResult Team()
        {
            ViewBag.Navbar = "Pages";
            return View();
        }

        public IActionResult ComingSoon()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(SendEmail user)
        {
            try
            {
                // Send the OTP via Email
                using (MailMessage mm = new MailMessage("s20293507@gmail.com", "sonia.tyagi.0609@gmail.com"))
                {
                    string senderEmail = "s20293507@gmail.com";
                    string senderPassword = "ybjtcvlwnboehvnk";

                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    // Set the properties of the email message.
                    mm.Subject = user.Name;
                    mm.Body = $"Name: {user.Name}\nEmail: {user.Email}\nMobile: {user.Mobile}\nMessage: {user.Message}";
                    mm.IsBodyHtml = false; // You can set this to true if your message body is HTML.

                    // Send the email.
                    smtpClient.Send(mm);
                }

                _notyf.Success("Message noted. We will get back to you soon.");
                user.Name = string.Empty;
                user.Email = string.Empty;
                user.Mobile = string.Empty;
                user.Message = string.Empty;

                return View("Contact", user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View("Contact");
        }
    }
}
