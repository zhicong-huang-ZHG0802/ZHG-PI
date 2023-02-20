using Microsoft.Extensions.Azure;
using Azure.Data.Tables;
using ZHG_PI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["ZHG-PI-Connection:blob"], preferMsi: true);
    clientBuilder.AddQueueServiceClient(builder.Configuration["ZHG-PI-Connection:queue"], preferMsi: true);
});



// const string connectionString = "DefaultEndpointsProtocol=https;AccountName=zhgpistorage;AccountKey=Gvq4stQSvsFnHk7Rl7oohl7bzxOhh8FocHFmxTwSiOOU2aWS9U2RfeZbrIqnolUo6Qeic/1v1CqM+AStrfcKQQ==;EndpointSuffix=core.windows.net";
// const string tableName = "musicItemsTable";


// // Construct a new TableClient using a connection string.
// var tableClient = new TableClient(connectionString, tableName);
// // Create the table if it doesn't already exist to verify we've successfully authenticated.
// await tableClient.CreateIfNotExistsAsync();


// var tableEntities = TableEntities.allTableEntities();

// foreach (var item in tableEntities)
// {
//     // Entity doesn't exist in table, so invoking UpsertEntity will simply insert the entity.
//     await tableClient.UpsertEntityAsync(item);
// }



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
