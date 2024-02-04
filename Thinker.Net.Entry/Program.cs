var builder = WebApplication.CreateBuilder(args);

// Configure the autofac instead of the default container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(bld =>
    {
        bld.RegisterModule<AutofacModuleRegister>();
       
    })
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        hostingContext.Configuration.ConfigureApplication();
    });
builder.ConfigureApplication();

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        // Ignore loop references and do not serialize.
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        // Set time format
        options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
    });

builder.Services.AddSingleton(new AppSettings(builder.Configuration));

builder.Services.AddSqlSugarSetup();

builder.Services.AddRegisterOptions();



builder.Services.AddEndpointsApiExplorer();
// Configure the swagger service.
builder.Services.AddSwaggerGenEx();


// Configure the auto mapper 
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

var app = builder.Build();

app.ConfigureApplication();
app.UseApplicationSetup();

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

