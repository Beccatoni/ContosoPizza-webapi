
public class CustomHeaderMiddleware {
    private readonly RequestDelegate _next;

    public CustomHeaderMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context){
        context.Response.Headers.Add("X-Powered-By", "Contoso Pizza Middleware");
        await _next(context);
    }
}