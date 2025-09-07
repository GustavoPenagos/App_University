using App_University.Logic.Repository.Interface;
using App_University.Model.Dtos.Enums;
using App_University.Model.Request;
using App_University.Model.Response.Common.Wrappers;
using App_University.Transversal.Message;
using App_University.Transversal.MessageResponse;
using App_University.Transversal.Utils.Util;
using Microsoft.AspNetCore.Mvc;

namespace App_University.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultController(IPaymentConsult consults, IPaymentRegistry registry) : ControllerBase
    {
        private readonly IPaymentConsult _consults = consults;
        private readonly IPaymentRegistry _registry = registry;
        private readonly ResponseStructure _responseStructure = new ResponseStructure();

        [HttpGet("/consulta-pagos")]
        public async Task<Response> ConsultaPagos(string program, string term_code)
        {
            if (!program.IsValidRequest() || !term_code.IsValidRequest())
                return _responseStructure.MessageResponse(EstadoConsulta.Error, MesssagesResponse.InvalidInput);
            return await _consults.SaradapConsult(program, term_code);
        }

        [HttpPost("/registro-verificacion")]
        public async Task<Response> RegistroVerificacion([FromBody] PaymentRegisterRequest request)
        {
            if (!request.IsValidDataRequest())
                return _responseStructure.MessageResponse(EstadoConsulta.Error, MesssagesResponse.InvalidInput);
            return await _registry.RegisterPayment(request);
            
        }
    }
}
