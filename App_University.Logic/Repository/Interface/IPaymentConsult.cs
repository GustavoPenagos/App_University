using App_University.Model.Response.Common.Wrappers;

namespace App_University.Logic.Repository.Interface
{
    public interface IPaymentConsult
    {
        Task<Response> SaradapConsult(string program, string term_code);
    }
}
