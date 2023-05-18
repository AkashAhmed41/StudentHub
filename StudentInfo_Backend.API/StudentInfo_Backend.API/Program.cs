using StudentInfo_Backend.API.Database;
using StudentInfo_Backend.API.NewFolder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentInfoDatabase, StudentInfoDatabase>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
