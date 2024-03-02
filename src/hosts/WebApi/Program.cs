using Application.Configurations;
using Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AdicionarInfraestrutura();
builder.Services.AdicionarAplicacao();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1"));

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapGet("/", async context =>
{
    context.Response.Redirect("/swagger");
    await context.Response.CompleteAsync();
});

app.MapControllers();
app.Run();