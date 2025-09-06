using App_University.Model.Request;
using App_University.Model.Response.Common;
using App_University.Model.Response.Common.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_University.Logic.Repository.Interface
{
    public interface IPaymentRegistry
    {
        Task<Response> RegisterPayment(PaymentRegisterRequest request);
    }
}
