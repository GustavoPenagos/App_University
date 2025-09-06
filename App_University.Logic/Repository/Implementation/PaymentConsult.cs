using App_University.Data.Repository.Interface;
using App_University.Logic.Repository.Interface;
using App_University.Model.Dtos.Enums;
using App_University.Model.Response.Common;
using App_University.Model.Response.Common.Wrappers;
using App_University.Transversal.MessageResponse;
namespace App_University.Logic.Repository.Implementation
{
    public class PaymentConsult(IConsults consults) : IPaymentConsult
    {
        private readonly IConsults _consults = consults;
        private readonly ResponseStructure _responseStructure = new();  

        public async Task<Response> SaradapConsult(string program, string term_code)
        {
            PaymentConsultResponse jObject = new();
            try
            {
                var (conPago, sinPago) = await _consults.EjecutarContarStvadmr(program, term_code);
                jObject = new PaymentConsultResponse
                {
                    Program = program,
                    Term_code = term_code,
                    Pagaron = conPago,
                    No_pagaron = sinPago
                };
            }
            catch (Exception ex)
            {
                return _responseStructure.MessageResponse(EstadoConsulta.Error, ex.Message);
            }
            return _responseStructure.MessageResponse(EstadoConsulta.Success, MesssagesResponse.Success, jObject);
        }
    }
}
