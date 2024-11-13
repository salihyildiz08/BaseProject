using System.Security.Claims;
using WebUI.Helper;

namespace WebUI.MiddleWare
{
    public class CustomAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Cookies["AuthToken"];
            if (!string.IsNullOrEmpty(token))
            {
                var userInfo = JwtHelper.GetUserInfoFromToken(token);
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userInfo.UserId),
                new Claim(ClaimTypes.Name, userInfo.Name),
                new Claim(ClaimTypes.Surname, userInfo.Surname)
            };
                var identity = new ClaimsIdentity(claims, "Custom");
                context.User = new ClaimsPrincipal(identity);

                context.Items["UserId"] = userInfo.UserId;
                context.Items["Name"] = userInfo.Name;
                context.Items["Surname"] = userInfo.Surname;
            }
            await _next(context);
        }
    }
}
