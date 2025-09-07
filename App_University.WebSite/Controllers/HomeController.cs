using App_University.Model.Dtos;
using App_University.Model.Request;
using App_University.Model.Response.Common;
using App_University.Model.Response.Common.Wrappers;
using App_University.Transversal.Util;
using App_University.WebSite.Models;
using App_University.WebSite.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace App_University.WebSite.Controllers
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

        public IActionResult Registry()
        {
            return View();
        }

        public async Task<IActionResult> InsertPayment(PaymentRegisterRequest request)
        {
            Response? msg = new();
            List<SarchklDao>? sarchklDaos = [];
            try
            {
                var url = $"{"UrlAPI:UniversityApi".GetFromAppSettings<string>()}{"UrlAPI:Registro".GetFromAppSettings<string>()}";
                using var httpClient = new HttpClient();
                var T = JsonConvert.SerializeObject(request);
                var response = await httpClient.PostAsync(url, 
                    new StringContent(
                        JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    msg = JsonConvert.DeserializeObject<Response?>(await response.Content.ReadAsStringAsync());
                    sarchklDaos = JsonConvert.DeserializeObject<List<SarchklDao>>(JsonConvert.SerializeObject(msg?.Body?.Result));
                }
                _logger.LogInformation(msg?.MsgRsHdr?.Message?.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Registry");
                ViewBag.error = msg?.MsgRsHdr?.Message?.ToString();
                return View("Registry", ViewBag.error);
            }

            return View("Registry", sarchklDaos);
        }

        public async Task<ActionResult> ConsultPayment(ConsultRequest consult)
        {
            Response? msg = new ();
            List<PaymentConsultResponse>? paymentConsultResponse = new ();
            try
            {
                var urlapi = $"{"UrlAPI:UniversityApi".GetFromAppSettings<string>()}{"UrlAPI:Consulta".GetFromAppSettings<string>()}";
                var components = $"?program={consult.Program}&term_code={consult.Term_code}";
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync($"{urlapi}{components}");

                if (response.IsSuccessStatusCode)
                {
                    msg = JsonConvert.DeserializeObject<Response?>(await response.Content.ReadAsStringAsync());
                    paymentConsultResponse = JsonConvert.DeserializeObject<List<PaymentConsultResponse>>(JsonConvert.SerializeObject(msg?.Body?.Result));

                    return View("Index", paymentConsultResponse);
                }
                _logger.LogInformation(msg?.MsgRsHdr?.Message?.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ConsultaPagos");
                ViewBag.error = msg?.MsgRsHdr?.Message?.ToString();
                return View("Index", ViewBag.error);
            }
            return View("Index", msg);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
