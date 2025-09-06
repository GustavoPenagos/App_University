using App_University.Model.Dtos;
using App_University.Model.Request;
using App_University.Model.Response.Common.Wrappers;

namespace App_University.Data.Repository.Interface
{
    public interface IRegistry
    {
        Task<bool> RegisterPayment(PaymentRegisterRequest request);
    }
}
