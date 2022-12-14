using Study_Crud.Models;
using Microsoft.EntityFrameworkCore;
using Study_Crud.Models.Entity;
using System.Reflection;
using Study_Crud.Models.Interface;
using Study_Crud.Models.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connections = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<DataDbContext>(options =>
   options.UseSqlServer(connections));

 builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

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
