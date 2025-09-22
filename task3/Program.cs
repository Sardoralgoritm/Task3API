using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);
int Lcm(int a, int b) => (a * b) / Gcd(a, b);

app.MapGet("/{email}", (HttpContext context, string email) =>
{
    var query = context.Request.Query;
    if (!query.ContainsKey("x") || !query.ContainsKey("y"))
        return Results.Text("NaN");

    if (!int.TryParse(query["x"], out var x) || !int.TryParse(query["y"], out var y))
        return Results.Text("NaN");

    if (x <= 0 || y <= 0)
        return Results.Text("NaN");

    var lcm = Lcm(x, y);
    return Results.Text(lcm.ToString());
});

app.Run();
