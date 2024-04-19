using JobPortal.Model;
using JobPortal.Repository;
using JobPortal.services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UserDetailsInsert>();
builder.Services.AddScoped<UserInsertRepository>();
builder.Services.AddScoped<GetUserDetails>();
builder.Services.AddScoped<AdminPageRepository>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddScoped<IDemo,DemoRepo>();
builder.Services.AddScoped<DemoService>();
builder.Services.AddScoped<UserTypeService>();
builder.Services.AddScoped<IUserTypeInsert,UserTypeInsert>();
builder.Services.AddScoped<ILoginRepository,LoginRepository>();
builder.Services.AddScoped<LoginService>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

var key=builder.Configuration.GetSection("Jwt : key").Get<string>();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("key")),
        ValidateIssuer = true,
        ValidateAudience = false,
    };
});


var app = builder.Build();

app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
