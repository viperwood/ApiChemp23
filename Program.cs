var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors(x =>
{
    x.AddPolicy(name:"MyPolit", polit =>
    {
        polit.WithOrigins("http://localhost:5277", "https://localhost:5277").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger(); 
app.UseSwaggerUI();

app.MapControllers();
app.UseAuthentication();
app.UseCors("MyPolit");
app.UseHttpsRedirection();

app.Run();