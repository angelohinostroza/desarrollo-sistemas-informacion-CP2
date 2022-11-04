using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data.SqlClient;
using WebApiVentas.Modelos.Common;
using WebApiVentas.Modelos.RequestResponse;

namespace WebApiVentas.Midleware
{
    public class ErrorMidleware
    {
        private readonly RequestDelegate next;
        public ErrorMidleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
                await next(context);
            }
            catch (CustomException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (MySqlException ex) // SQL SERVER // MYSQLDATABASEXECPTIONS
            {
                CustomException exx = new CustomException("Error no controlado, base de datos", 510, ex.Number, "Data base", ex);
                await HandleExceptionAsync(context, exx);
            }
            catch (DbUpdateException ex)
            {
                var err = ex.GetBaseException() as MySqlException;
                //ex.InnerException.
                CustomException exx = new CustomException("Error no controlado", 511, err.Number, "Data base", ex);
                await HandleExceptionAsync(context, exx);
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Error no controlado", 500, 500, "", ex);
                await HandleExceptionAsync(context, exx);
            }
        }


        private static Task HandleExceptionAsync(HttpContext context, CustomException ex)
        {
            var controllerActionDescriptor = context.GetEndpoint().Metadata.GetMetadata<ControllerActionDescriptor>();
            var controllerName = controllerActionDescriptor.ControllerName;
            var actionName = controllerActionDescriptor.ActionName;


            InfoRequest info = new InfoRequest();
            info = HelperHttpContext.GetInfoRequest(context);
            ErrorResponse error = new ErrorResponse();
            //ErrorBussniess errorDominio = new ErrorBussniess();
            //error = errorDominio.Register(ex, info);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.httpCode;

            //return context.Response.WriteAsync(JsonConvert.SerializeObject(error));

            return context.Response.WriteAsJsonAsync(error);

        }
    }
}
