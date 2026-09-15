using InventoryByawAstha.BLL.Exceptions.RootException;
using System.Net;
using System.Security.Claims;
using System.Text.Json;

namespace InventoryByawAstha.Web.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<GlobalExceptionMiddleware> logger;
        public GlobalExceptionMiddleware(RequestDelegate next,ILogger<GlobalExceptionMiddleware> logger) {
            this.next = next;
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
        
            try
            {
                
                await next(context);
            }
            catch (Exception ex)
            {

                LogException(context, ex);
                await HandleExceptionAsync(context, ex);
            }
        }
        private void LogException(HttpContext context, Exception ex) {
            string UserId = "Anonymous";
            var userClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userClaim != null) {
                UserId = userClaim.Value;
            }
            if (ex is AppException) {
                logger.
                LogWarning(ex,"ApplicationException occured.UserId:{UserId},Method:{Method},Path:{Path}",
                UserId,context.Request.Method,context.Request.Path);
            }
            else
            {
                logger.
                LogError(ex, "Unhandled Exception occured.UserId:{UserId},Method:{Method},Path:{Path}"
                ,UserId,context.Request.Method,context.Request.Path);
            }
            
         }
       private async Task HandleExceptionAsync(HttpContext context,Exception ex) {

            context.Response.ContentType = "application/json";
            int statusCode;
            string message;
            string errorCode;
            if (ex is AppException appException)
            {
                statusCode = appException.statusCode;
                message = appException.Message;
                errorCode = appException.errorCode;

            }
            else {
                statusCode = (int)HttpStatusCode.InternalServerError;
                message = "Something Went Wrong";
                errorCode = "INTERNAL_SERVER_ERROR";
            
            }
            context.Response.StatusCode = statusCode;
            var response = new { 
            success=false,
            statusCode,
            message,
            errorCode
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            
         }    
    }     
}       
       
        
        
        
        
       

    


        