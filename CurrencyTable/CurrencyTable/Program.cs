var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpLogging();
app.UseRouting();
app.UseStaticFiles();
app.MapControllers();

app.Run();
