using CRM.Db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CrmDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}"
);

app.MapControllerRoute(
    name: "get_widgets",
    pattern: "api/{controller=Home}/{action=GetWidgets}"
);

app.MapControllerRoute(
    name: "get_widget_list",
    pattern: "api/{controller=Home}/{action=GetWidgetList}"
);

app.MapControllerRoute(
    name: "take_task",
    pattern: "api/{controller=Tasks}/{action=TakeTask}"
);

app.MapControllerRoute(
    name: "stop_task",
    pattern: "api/{controller=Tasks}/{action=StopTask}"
);

app.MapControllerRoute(
    name: "login",
    pattern: "api/{controller=Login}/{action=Login}"
);

app.MapControllerRoute(
    name: "admin_data",
    pattern: "api/{controller=Admin}/{action=GetAdminData}"
);

app.MapControllerRoute(
    name: "admin_create_user",
    pattern: "api/{controller=Admin}/{action=CreateUser}"
);

app.MapControllerRoute(
    name: "admin_create_task",
    pattern: "api/{controller=Admin}/{action=CreateTask}"
);

app.MapControllerRoute(
    name: "admin_create_work_day",
    pattern: "api/{controller=Admin}/{action=CreateWorkDay}"
);

app.Run();
