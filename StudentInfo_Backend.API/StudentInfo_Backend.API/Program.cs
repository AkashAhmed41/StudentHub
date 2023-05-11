
using StudentInfo_Backend.API;
using StudentInfo_Backend.API.Database;
using StudentInfo_Backend.API.NewFolder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentInfoDatabase, StudentInfoDatabase>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestValidatorMiddleware>();

// app.UseMiddleware<SampleMiddleware>();

// app.UseSampleMiddleware();

// app.Use(async (context, next) =>
// {
//     app.Logger.LogInformation("Inside the middleware!");
//     var start = DateTime.UtcNow;
//     await next.Invoke(context);
//     app.Logger.LogInformation($"Request {context.Request.Path}: {(DateTime.UtcNow - start).TotalMilliseconds}");
// });

// app.Use((HttpContext context, Func<Task> next) =>
// {
//     app.Logger.LogInformation("Terminating the Request!");
//     return Task.CompletedTask;
// });

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
