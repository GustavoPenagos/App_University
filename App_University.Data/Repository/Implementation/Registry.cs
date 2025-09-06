using App_University.Data.Context;
using App_University.Data.Repository.Interface;
using App_University.Model.Request;
using App_University.Transversal.Util;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace App_University.Data.Repository.Implementation
{
    public class Registry(ModelContext context) : IRegistry
    {
        private readonly ModelContext _context = context;

        // Implementation for registry methods
        public async Task<bool> RegisterPayment(PaymentRegisterRequest request)
        {
            // Implementation for registering a payment
            var pidm = new OracleParameter("p_pidm", request.Pidm);
            var termCode = new OracleParameter("p_term_code", request.Term_code);
            var program = new OracleParameter("p_program", request.Program);
            var admrCode = new OracleParameter("p_admr_code", request.Admr_code);
            var recieveDate = new OracleParameter("p_recieve_date", request.Recieve_date?.StringToAny<DateTime>());
            var comment = new OracleParameter("p_comment", request.Comment);

            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                        "BEGIN REGISTRAR_ELEMENTO_VERIFICACION(" +
                            ":p_pidm," +
                            ":p_term_code," +
                            ":p_program," +
                            ":p_admr_code," +
                            ":p_recieve_date," +
                            ":p_comment);" +
                        "END;",
                        pidm, termCode, program, admrCode, recieveDate, comment
                );
            }
            catch (Exception ex)
            {
                
                return false;
            }
            return true;
        }
    }
}
