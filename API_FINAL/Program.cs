using API_FINAL.Models;
using API_FINAL.Controllers;
using Microsoft.EntityFrameworkCore;
using API_FINAL.Repository;
using API_FINAL.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Xml;

using API_FINAL.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Trainee2")));

builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<ITokenService, TokenService>();
// For  JWT Token 


var key = Encoding.ASCII.GetBytes("QIZbmy/CGpUdnE8wGed+3rP/NF42Ap6W");
builder.Services.AddJWT(key);

builder.Services.AddSwaggerGen(opt =>
{
   
  //  opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "new",
        Description = "TTTTT",
    });

    var location = Assembly.GetEntryAssembly().Location;
    string xmlComments = Path.Combine(Path.GetDirectoryName(location), Path.GetFileNameWithoutExtension(location) + ".xml");



    if (File.Exists(xmlComments))
       opt.IncludeXmlComments(xmlComments);
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
       In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        //  BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
          new OpenApiSecurityScheme
           {
               Reference = new OpenApiReference
               {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
               },
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
           new List<string>()
       }
    });
});







var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwaggerUI();
   
}

app.UseHttpsRedirection();




app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwagger();

 app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/V1/swagger.json", "API FINAL API");
}); 
app.Run();
