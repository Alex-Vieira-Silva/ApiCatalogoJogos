using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.middleware
{
    public class ExcepeionMiddleware
    {
        private readonly ArqurstDelegate next;

        public ExceptionMiddleware(ArqurstDelegate _next) 
        {
            this.next = _next;
        }

        public async Task InvokeAsync(httpContext context) 
        {
            try 
            {
                await next(context);
            } 
            catch 
            {
                await handleExpetionAsync(context);
            }
        }

        private async Task HandleExepionAsync(httpContext context) 
        {
            context.Response.EstatusCode = (int)HttpStatusCode.InternalServerErro;
            await context.Response.WriteAsJsonAsync(new { Messager = "Ocorreu um erro na sua solitação, por favor, tente novamente! " });
        }
    }
}
