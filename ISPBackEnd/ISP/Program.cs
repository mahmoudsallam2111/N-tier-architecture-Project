using Ecommerce.API.MiddleWare;
using FluentValidation.AspNetCore;
using Hangfire;
using ISP.API.RedisterDependancies;
using ISP.BL;
using ISP.BL.Services.UserPermissionsService;
using ISP.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region default

builder.Services.AddControllers()
      .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<CentralWriteValidation>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region HangFire confg
builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("connction_string")));
builder.Services.AddHangfireServer();

#endregion

#region Configure CORS
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader();

}));

#endregion

#region Database configuration

var connetionstring = builder.Configuration.GetConnectionString("connction_string");

builder.Services.AddDbContext<ISPContext>(
    options => options.UseSqlServer(connetionstring));

#endregion

#region IdentityRole Services

builder.Services
    .AddIdentity<User, Role>(options =>
    {
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 4;
        options.User.RequireUniqueEmail = true;
    })

    .AddEntityFrameworkStores<ISPContext>()
    .AddDefaultTokenProviders();




builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.Zero;
});

#endregion


#region Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region Authentication 

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Cool";
    options.DefaultChallengeScheme = "Cool";
})
.AddJwtBearer("Cool", options =>
{
    var secretKeyString = builder.Configuration.GetValue<string>("SecretKey");
    var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
    var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = secretKey,
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

#endregion


#region Repos
builder.Services.AddRepositories();
#endregion


#region Services
builder.Services.AddServices();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandlingMiddleware();
}

app.UseCors("MyPolicy");
 
app.UseHttpsRedirection();
app.UseHangfireDashboard("/dash");


app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

RecurringJob.AddOrUpdate<IBillService>("MyJob", s=>s.BillGenerationSP() , "35 18 * * *");

app.Run();



