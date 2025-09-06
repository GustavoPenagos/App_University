using App_University.Data.Repository.Interface;
using App_University.Logic.Repository.Interface;
using App_University.Model.Dtos.Enums;
using App_University.Model.Request;
using App_University.Model.Response.Common.Wrappers;
using App_University.Transversal.Message;
using App_University.Transversal.MessageResponse;

namespace App_University.Logic.Repository.Implementation
{
    public class PaymentRegister(IRegistry registry, IConsults consults) : IPaymentRegistry
    {  
        private readonly IRegistry _registry = registry;
        private readonly IConsults _consult = consults;
        private readonly ResponseStructure _responseStructure = new();

        public async Task<Response> RegisterPayment(PaymentRegisterRequest request)
        {
            try
            {
                var result = await _registry.RegisterPayment(request);
                if (result)
                {
                    var sarchklData = await _consult.GetSarchklData();
                    if (sarchklData != null || sarchklData?.Count > 0)
                        return _responseStructure.MessageResponse(EstadoConsulta.Success, 
                            MesssagesResponse.SuccessR, sarchklData);
                }
                return _responseStructure.MessageResponse(EstadoConsulta.Error, MesssagesResponse.Error);
            }
            catch (Exception)
            {
                return _responseStructure.MessageResponse(EstadoConsulta.Error, MesssagesResponse.Error);
            }
        }
    }
}
