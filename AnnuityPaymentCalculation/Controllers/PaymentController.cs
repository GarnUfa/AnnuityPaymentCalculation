using AnnuityPaymentCalculation.Models.AnnuityPaymentModel;
using AnnuityPaymentCalculation.Models.AnnuityPaymentModel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PaymentMath.Interfaces;

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

        public IActionResult CreditData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreditData(AnnuityPaymentInputData basePaymentCalculate)
        {
            if (ModelState.IsValid)
            {
                basePaymentCalculate.PayType = AnnuityPayType.Standard;
                var result = _getResult.GetCalculationResult(basePaymentCalculate);
                return View("AnnuityCalculationResults", result);
            }
            else
            {
                return View(basePaymentCalculate);
            }

        }

        public IActionResult AdvancedCreditData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdvancedCreditData(AnnuityPaymentInputData advancedPaymentCalculate)
        {
            if (ModelState.IsValid)
            {
                ViewBag.CreditTerm = advancedPaymentCalculate.LoanTerm;
                advancedPaymentCalculate.PayType = AnnuityPayType.Advanced;
                var result = _getResult.GetCalculationResult(advancedPaymentCalculate);
                return View("AnnuityCalculationResults", result);
            }
            else
            {
                return View(advancedPaymentCalculate);
            }
        }

        public IActionResult AnnuityCalculationResults(IEnumerable<IAnnuityPaymentOutputData> PaymentTable)
        {
            return View(PaymentTable);
        }

    }
}