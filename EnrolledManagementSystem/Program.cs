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
builder.Services.AddScoped<GiangVienService>();
builder.Services.AddScoped<PhanCongGiangDayService>();
builder.Services.AddScoped<HocVienService>();
builder.Services.AddScoped<DangKyService>();
builder.Services.AddScoped<LoaiHocPhiService>();
builder.Services.AddScoped<PhieuThuHocPhiService>();
builder.Services.AddScoped<DiemService>();
builder.Services.AddScoped<ChucVuService>();
builder.Services.AddScoped<NhanVienService>();
builder.Services.AddScoped<PhieuLuongService>();
builder.Services.AddScoped<VaiTroService>();
builder.Services.AddScoped<QuyenNguoiDungService>();
builder.Services.AddScoped<PhanQuyenService>();
builder.Services.AddScoped<NguoiDungService>();
builder.Services.AddScoped<LichNghiService>();

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
