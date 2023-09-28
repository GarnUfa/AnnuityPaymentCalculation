﻿using AnnuityPaymentCalculation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AnnuityPaymentCalculation.Models.AnnuityPaymentModel;
using PaymentMath.Interfaces;
using AnnuityPaymentCalculation.Models.AnnuityPaymentModel.Interfaces;

namespace AnnuityPaymentCalculation.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IGetResultApplicationService<IAnnuityPaymentOutputData> _getResult;

        public PaymentController(ILogger<PaymentController> logger, IGetResultApplicationService<IAnnuityPaymentOutputData> getResult)
        {
            _logger = logger;
            _getResult = getResult;
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
            if (ModelState.IsValid)
            {
                var res  = _getResult.GetCalculationResult(basePaymentCalculate);
                return View("AnnuityCalculationResults", res);
            }
            else
            {
                return View(basePaymentCalculate);
            }
            
        }

        public IActionResult AnnuityCalculationResults(IEnumerable<IAnnuityPaymentOutputData> PaymentTable)
        {
            return View(PaymentTable);
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