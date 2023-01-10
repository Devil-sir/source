using Microsoft.AspNetCore.Mvc;
using PaymentGatewayDemo1.Models;
using Razorpay.Api;
using System.Diagnostics;

namespace PaymentGatewayDemo1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
        [HttpPost]
        public ActionResult CreateOrder(PaymentRequest _requestData)
        {
            Random randomObj = new Random();
            string transactionId = randomObj.Next(10000000, 100000000).ToString();
            RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_JOOSF2WsbmTZTt", "Rs4ohdS6nyKOArItDFAYMUXm");
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", _requestData.Amount * 100);  // Amount will in paise
            options.Add("receipt", transactionId);
            options.Add("currency", "INR");
            options.Add("payment_capture", "0"); // 1 - automatic  , 0 - manual
            Order orderResponse = client.Order.Create(options);
            string orderId = orderResponse["id"].ToString();
            RazorPayOrder orderModel = new RazorPayOrder
            {
                OrderId = orderResponse.Attributes["id"],
                RazorPayAPIKey = "rzp_test_JOOSF2WsbmTZTt",
                Amount = _requestData.Amount * 100,
                Currency = "INR",
                Name = _requestData.Name,
                Email = _requestData.Email,
            };
            return View("PaymentPage", orderModel);
        }
        [HttpPost]
        public ActionResult Complete()
        {
            string paymentId = HttpContext.Request.Form["rzp_paymentid"].ToString();
            string orderId = HttpContext.Request.Form["rzp_orderid"].ToString();
            RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_JOOSF2WsbmTZTt", "Rs4ohdS6nyKOArItDFAYMUXm");
            Payment payment = client.Payment.Fetch(paymentId);
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", payment.Attributes["amount"]);
            Payment paymentCaptured = payment.Capture(options);
            string amt = paymentCaptured.Attributes["amount"];
            if (paymentCaptured.Attributes["status"] == "captured")
            {
                ViewBag.Message = "Paid successfully";
                ViewBag.OrderId = paymentCaptured.Attributes["id"];
                return View("Result");
            }
            else
            {
                ViewBag.Message = "Payment failed, something went wrong";
                return View("Result");
            }
        }
    }
}