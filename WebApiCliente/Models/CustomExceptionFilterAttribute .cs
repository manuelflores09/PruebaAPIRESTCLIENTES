using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Diagnostics;


namespace WebApiCliente.Models
{
    public class InvalidEmailFormatException : Exception
    {
        public InvalidEmailFormatException(string message) : base(message)
        {
        }
    }

    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Trace.TraceError($"Excepción: {context.Exception.Message}");

            HttpStatusCode status;
            string message;

            if (context.Exception is InvalidEmailFormatException)
            {
                status = HttpStatusCode.BadRequest;
                message = context.Exception.Message;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                status = HttpStatusCode.Unauthorized;
                message = "Acceso no autorizado";
            }
            else if (context.Exception is ArgumentException)
            {
                status = HttpStatusCode.BadRequest;
                message = "Argumento no válido";
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = "Ocurrió un error interno en el servidor.";
            }

            context.Response = new HttpResponseMessage(status)
            {
                Content = new StringContent(message),
                ReasonPhrase = message
            };

            // Llamada a la implementación base para permitir que otros filtros y la lógica predeterminada continúen
            base.OnException(context);
        }
    }
}
