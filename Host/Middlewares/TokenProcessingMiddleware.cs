using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace Host.Middlewares
{
    public class TokenProcessingMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenProcessingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(token);
                var userId = jsonToken.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value;

                context.Items["userId"] = userId;
            }

            await _next(context);
        }
    }
}
