using App_University.Data.Repository.Implementation;
using App_University.Data.Repository.Interface;
using App_University.Logic.Repository.Implementation;
using App_University.Logic.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Context
builder.Services.AddDbContext<App_University.Data.Context.ModelContext>();

// Dependency Injection
builder.Services.AddTransient<IConsults, Consults>();
builder.Services.AddTransient<IRegistry, Registry>();
builder.Services.AddTransient<IPaymentConsult, PaymentConsult>();
builder.Services.AddTransient<IPaymentRegistry, PaymentRegister>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.DefaultModelsExpandDepth(-1));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
