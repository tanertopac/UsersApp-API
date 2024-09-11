using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Filters;
using UsersApp.Domain.Exceptions;

namespace UsersApp.API.ExceptionHandling
{
	public class GlobalExceptionFilter : IExceptionFilter
	{
        public void OnException(ExceptionContext context)
        {
            var statusCode = context.Exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Result = new ObjectResult(new
            {
                error = context.Exception.Message,
                data = context.Exception.Data
            })
            {
                StatusCode = statusCode
            };
        }
    }
}

