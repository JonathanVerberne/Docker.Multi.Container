using Web.Application.Persistence;
using Web.Application.Persistence.Data;
using Microsoft.EntityFrameworkCore;

// ------ References ------
// https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-6.0&tabs=visual-studio
// https://docs.docker.com/get-started/07_multi_container/
// --- End Of References ---

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
Console.WriteLine("db conn is..." + connectionString);

if (connectionString != null)
{
    builder.Services.AddEntityFrameworkNpgsql().AddDbContext<SchoolContext>(options =>
        options.UseNpgsql(connectionString));
}
else
{
    // read from appsettings.json
    builder.Services.AddEntityFrameworkNpgsql().AddDbContext<SchoolContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DbContext")));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<SchoolContext>();
        context.Database.EnsureCreated();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error scaffolding db..." + ex.ToString());
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
