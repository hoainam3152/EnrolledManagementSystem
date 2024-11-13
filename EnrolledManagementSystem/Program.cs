using EnrolledManagementSystem.Entities;
using EnrolledManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ManagementDbContext>(option => option.UseSqlServer(
        builder.Configuration.GetConnectionString("DB")
    ));
// Register service
builder.Services.AddScoped<LoaiDiemService>();
builder.Services.AddScoped<KhoaKhoiService>();
builder.Services.AddScoped<ToBoMonService>();
builder.Services.AddScoped<NienKhoaService>();
builder.Services.AddScoped<KhoaService>();
builder.Services.AddScoped<MonHocService>();
builder.Services.AddScoped<LopHocService>();
builder.Services.AddScoped<LoaiDiemMonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
