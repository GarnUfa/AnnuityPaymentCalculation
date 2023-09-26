using AnnuityPaymentCalculation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AnnuityPaymentCalculation.Models.AnnuityPaymentModel;

namespace AnnuityPaymentCalculation.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult CreditData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreditData(AnnuityPaymentInputData basePaymentCalculate)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }
            return View(basePaymentCalculate);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}