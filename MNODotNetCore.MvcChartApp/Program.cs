using Serilog;
using Serilog.Sinks.MSSqlServer;

String filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/MNODotNetCore.MvcChartApp.log");
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo
    .MSSqlServer(
        connectionString: "Server = RIKZIL\\SQLEXPRESS;Database=MNODotNetTraining;" +
        "User ID = sa;Password =sasa@123; TrustServerCertificate = true;",
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "Tbl_LogEvents",
            AutoCreateSqlTable = true
        })
    .WriteTo.File(filePath, rollingInterval: RollingInterval.Hour)
    .CreateLogger();



try
{

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSerilog(); // <-- Add this line

    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");


    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
