namespace App_University.Model.Response.Common.Wrappers
{
    public class Response
    {
        public MsgRsHdr? MsgRsHdr { get; set; }
        public Body? Body { get; set; }
    }
    public class Body
    {
        public object? Result { get; set; }
    }
    public class MsgRsHdr
    {
        public dynamic? Status { get; set; }
        public object? Message { get; set; }
    }
}
