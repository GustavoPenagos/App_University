using App_University.Data.Context;
using App_University.Model.Dtos;

namespace App_University.Data.Repository.Interface
{
    public interface IConsults
    {
        Task<(int conPago, int sinPago)> EjecutarContarStvadmr(string programCode, string termCodeEntry);
        Task<List<SarchklDao>> GetSarchklData();
    }
}
