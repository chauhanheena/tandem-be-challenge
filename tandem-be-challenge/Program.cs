using AutoMapper;
using tandem_be_challenge.Configs.CosmosDB;
using tandem_be_challenge.Mapper;
using tandem_be_challenge.Repositories;
using tandem_be_challenge.Repositories.Impl;
using tandem_be_challenge.Services;
using tandem_be_challenge.Services.impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection with cosmos DB.
builder.Services.AddSingleton<CosmosConfigService>(InitializeCosmosClientInstanceAsync(builder.Configuration.GetSection("CosmosDb"))
    .GetAwaiter().GetResult());

// For Mapper.
builder.Services.AddAutoMapper(typeof(Program));
var mapperConfig = new MapperConfiguration(mc => {
    mc.AddProfile(new UserProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Injecting repository and service dependency
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();


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

app.Run();

async Task<CosmosConfigService> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
{
    string databaseName = configurationSection.GetSection("DatabaseName").Value;
    string containerName = configurationSection.GetSection("ContainerName").Value;
    string account = configurationSection.GetSection("Account").Value;
    string key = configurationSection.GetSection("Key").Value;

    Microsoft.Azure.Cosmos.CosmosClient client = new Microsoft.Azure.Cosmos.CosmosClient(account, key);
    CosmosConfigService cosmosDbService = new CosmosConfigService(client, databaseName, containerName);

    Microsoft.Azure.Cosmos.DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
    await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

    return cosmosDbService;
}