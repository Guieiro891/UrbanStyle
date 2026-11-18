using Microsoft.OpenApi;
using System.Net;
using System.Text.Json;

namespace UrbanStyle.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            //Tentar seguir o fluxo normal da requisição
            await _next(context);
        }
        catch (Exception ex)
        {
            // Se der erro em qualquer lugar cai aqui
            _logger.LogError(ex, "Ocorreu um erro inesperado.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Define o retorno padrão como JSON e status 500
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        //Montando a resposta amigavel para o Cliente
        var response = new
        {
            status = context.Response.StatusCode,
            mensagem = "Ocorreu um erro interno no servidor. Tente novamente mais tarde."
        };

        var json = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(json);
    }
}