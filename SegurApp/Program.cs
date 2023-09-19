using Microsoft.EntityFrameworkCore;
using SegurApp.Infraestructure;
using SegurApp.Repository;
using SegurApp.Repository.Interfaces;
using SegurApp.Services;
using SegurApp.Services.Hubs;
using SegurApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR().AddHubOptions<SendMessageHub>(options =>
{
    options.EnableDetailedErrors = true; // Otras opciones que puedas necesitar
    options.ClientTimeoutInterval = TimeSpan.FromMinutes(30);
}); ;


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Inyecciones

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();
builder.Services.AddTransient<IMessageUserRepository, MessageUsersRepository>();
builder.Services.AddTransient<IMessageUserService, MessageUserService>();

//CORS

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        builder =>
//        {
//            builder.WithOrigins("http://localhost:8081", "http://localhost:5554")
//                   .AllowAnyMethod()
//                   .AllowAnyHeader()
//                   .AllowCredentials();
//        });
//});

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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

app.MapHub<SendMessageHub>("/sendMessageHub");

//app.UseCors("AllowAll");


app.Run();