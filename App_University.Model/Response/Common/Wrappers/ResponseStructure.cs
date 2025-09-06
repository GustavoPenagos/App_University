using App_University.Model.Dtos.Enums;
using App_University.Model.Response.Common.Wrappers;

namespace App_University.Transversal.MessageResponse
{
    public class ResponseStructure
    {
        private Response _response = new ();

        public Response MessageResponse(EstadoConsulta status, string message, object? body = null)
        {
            if(status == EstadoConsulta.Error)
            {
                _response = new Response()
                {
                    MsgRsHdr = new MsgRsHdr()
                    {
                        Status = EstadoConsulta.Error.ToString(),
                        Message = message,
                    },
                    Body = null
                };
            }
            else
            {
                _response = new Response()
                {
                    MsgRsHdr = new MsgRsHdr()
                    {
                        Status = status.ToString(),
                        Message = message,
                    },
                    Body = new Body()
                    {
                        Result = body
                    }
                };
            }
            return _response;
        }
    }
}
