using BubbleBrunch.Services.Breakfast;

var builder = WebApplication.CreateBuilder(args); // builder variable is used to add dependency injection
                                                  // and configuration
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IbreakfastServices , BreakfastServices>();
}

var app = builder.Build(); // app variable is used for creating app pipeline
{
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
}
