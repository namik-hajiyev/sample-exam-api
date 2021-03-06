using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SampleExam.Common;
using SampleExam.Infrastructure.Validation;

namespace SampleExam.Infrastructure.Errors
{
    public static class ExceptionHandler
    {
        public static Task HandleException(HttpContext context)
        {
            var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
            var exception = errorFeature.Error;

            var problemDetails = new ApiProblemDetails()
            {
                Title = "An unexpected error occurred!",
                Status = 500,
                Detail = exception.Message
            };

            string responceText = string.Empty;

            switch (exception)
            {
                case RestException re:
                    problemDetails.Title = re.Title;
                    problemDetails.Detail = re.Detail;
                    problemDetails.Status = (int)re.Code;
                    problemDetails.Errors.Add("Error", new Error[] { re.Error });
                    foreach (var item in re.Extensions ?? new Dictionary<string, object>())
                    {
                        problemDetails.Extensions.Add(item);
                    }

                    context.Response.StatusCode = (int)re.Code;
                    responceText = JsonConvert.SerializeObject(problemDetails);
                    break;
                case ValidationException ve:
                    var serializer = (IValidationFailuresSerializer)context.RequestServices.GetService(typeof(IValidationFailuresSerializer));
                    responceText = serializer.Serialize(ve.Errors);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    responceText = JsonConvert.SerializeObject(problemDetails);
                    break;
            }

            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(responceText);
        }
    }
}