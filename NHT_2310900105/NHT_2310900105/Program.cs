




    using Microsoft.EntityFrameworkCore;
    using NHT_2310900105.Models;

    var builder = WebApplication.CreateBuilder(args);


    // Add services to the container.
    builder.Services.AddControllersWithViews();
    var connectionString = builder.Configuration.GetConnectionString("NHT_2310900105");
    builder.Services.AddDbContext<Nht2310900105Context>(x => x.UseSqlServer(connectionString));


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/NhtHome/NhtError");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=NhtHome}/{action=NhtIndex}/{id?}");

    app.Run();
