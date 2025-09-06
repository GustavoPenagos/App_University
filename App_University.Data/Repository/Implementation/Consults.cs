using App_University.Data.Context;
using App_University.Data.Repository.Interface;
using App_University.Model.Dtos;
using App_University.Transversal.Util;
using App_University.Transversal.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace App_University.Data.Repository.Implementation
{
    public class Consults(ModelContext context) : IConsults
    {
        private readonly ModelContext _context = context;

        /// <summary>
        /// Executes the stored procedure <c>contar_stvadmr</c> to count the number of records  with and without payment
        /// based on the specified program code and term code.
        /// </summary>
        /// <remarks>This method establishes a connection to an Oracle database, executes the stored
        /// procedure  <c>contar_stvadmr</c>, and retrieves the output parameters <c>p_con_pago</c> and
        /// <c>p_sin_pago</c>. Ensure that the database connection string is correctly configured in the application's
        /// context.</remarks>
        /// <param name="programCode">The program code used as an input parameter for the stored procedure. to
        /// indicate no filtering by program code.</param>
        /// <param name="termCodeEntry">The term code used as an input parameter for the stored procedure. to
        /// indicate no filtering by term code.</param>
        /// <returns>A tuple containing two integers: <c>conPago</c> (count of records with payment) and <c>sinPago</c> (count of records with no payment)
        public async Task<(int conPago, int sinPago)> EjecutarContarStvadmr(string programCode, string termCodeEntry)
        {
            var paramProgramCode = new OracleParameter("p_program_code", programCode);
            var paramTermCode = new OracleParameter("p_term_code_entry", termCodeEntry);

            var paramConPago = new OracleParameter("p_con_pago", OracleDbType.Int32)
            {
                Direction = ParameterDirection.Output
            };
            var paramSinPago = new OracleParameter("p_sin_pago", OracleDbType.Int32)
            {
                Direction = ParameterDirection.Output
            };

            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                        "BEGIN contar_stvadmr(" +
                            ":p_program_code," +
                            ":p_term_code_entry," +
                            ":p_con_pago," +
                            ":p_sin_pago" +
                            "); " +
                        "END;",
                        paramProgramCode, paramTermCode, paramConPago, paramSinPago
                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            var conPagoStr = paramConPago.Value?.ToString() ?? "0";
            var sinPagoStr = paramSinPago.Value?.ToString() ?? "0";
            return (conPagoStr.StringToAny<int>(), sinPagoStr.StringToAny<int>());
        }

        public async Task<List<SarchklDao>> GetSarchklData()
        {
            try
            {
                var sarchklData = await (from kl in _context.Sarchkls
                                    select (new SarchklDao
                                    {
                                        pidm = kl.SarchklPidm,
                                        term_code = kl.SarchklTermCodeEntry,
                                        program = kl.SarchklApplNo,
                                        admr_code = kl.SarchklAdmrCode,
                                        receive_date = kl.SarchklReceiveDate.HasValue ? kl.SarchklReceiveDate.Value : null,
                                        comment = kl.SarchklComment
                                    })).OrderByDescending(i => i.receive_date).ToListAsync();
                
                return [.. sarchklData.DistinctBy(i => i.pidm)];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
