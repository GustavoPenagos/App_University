namespace App_University.Transversal.Message
{
    public static class MesssagesResponse
    {
        public const string SuccessR = "Registro actualizado exitosamente.";
        public const string Success = "Consulta realizada exitosamente.";
        public const string Error = "Código admisión inválido o aspirante sin aplicación activa";
        public const string NotFound = "The requested resource was not found.";
        public const string InvalidInput = "The input provided is invalid.";
        public const string Unauthorized = "You do not have permission to perform this action.";
        public const string Conflict = "A conflict occurred with the current state of the resource.";
        public const string Created = "The resource was created successfully.";
        public const string Updated = "The resource was updated successfully.";
        public const string Deleted = "The resource was deleted successfully.";
        public const string BadRequest = "The request could not be understood or was missing required parameters.";
        public const string InternalServerError = "An internal server error occurred. Please try again later.";
    }
}
