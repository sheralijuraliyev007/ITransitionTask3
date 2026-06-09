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
    if (!long.TryParse(x, out long number1) || !long.TryParse(y, out long number2))
        return Results.Text("NaN", "text/plain");
    if (number1 < 1 || number2 < 1)
        return Results.Text("NaN", "text/plain");
    long big = number1 > number2 ? number1 : number2;
    long small = big == number1 ? number2 : number1;
    return Results.Text(LCM(big, small).ToString(), "text/plain");
});
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
long LCM(long big, long small)
{
    return (big / GDC(big, small)) * small;
}
long GDC(long big, long small)
{
    if (big == 0) return small;
    return GDC(small % big, big);
}