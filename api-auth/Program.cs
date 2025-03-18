using MongoDB.Driver;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//Configurando o cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7068");
                          policy.WithMethods("GET", "POST", "PUT", "DELETE");
                          policy.WithHeaders("Accept", "Content-Type", "Origin", "X-My-Header");
                      });
});

// Confirgurando o MongoDB
var configuration = builder.Configuration;
var mongoConnectionString = configuration.GetConnectionString("MongoDB");
var mongoClient = new MongoClient(mongoConnectionString);
builder.Services.AddSingleton(mongoClient);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
