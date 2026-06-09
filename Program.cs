using System.Numerics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseExceptionHandler(exceptionHandlerApp
    => exceptionHandlerApp.Run(async context
        => await Results.Problem()
                     .ExecuteAsync(context)));
app.MapGet("/sheralijuraliyev3_gmail_com", (string? x, string? y) =>
{
    if (x == null || y == null)
        return Results.Text("NaN", "text/plain");
    if (!BigInteger.TryParse(x, out BigInteger number1) || !BigInteger.TryParse(y, out BigInteger number2))
        return Results.Text("NaN", "text/plain");
    if (number1 < 1 || number2 < 1)
        return Results.Text("NaN", "text/plain");
    return Results.Text(LCM(number1, number2).ToString(), "text/plain");
});
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
BigInteger LCM(BigInteger a, BigInteger b)
{
    return (a / BigInteger.GreatestCommonDivisor(a, b)) * b;
}