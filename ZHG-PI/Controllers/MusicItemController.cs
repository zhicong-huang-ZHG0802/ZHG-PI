using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using ZHG_PI.Models;


namespace ZHG_PI.Controllers
{
    [ApiController]
    [Route("musicitems")]
    public class MusicItemController : ControllerBase
    {

        // const string connectionString = "DefaultEndpointsProtocol=https;AccountName=zhgpistorage;AccountKey=Gvq4stQSvsFnHk7Rl7oohl7bzxOhh8FocHFmxTwSiOOU2aWS9U2RfeZbrIqnolUo6Qeic/1v1CqM+AStrfcKQQ==;EndpointSuffix=core.windows.net";
        const string tableName = "musicItemsTable";
        const string storageUri = "https://zhgpistorage.table.core.windows.net/";
        const string accountName = "zhgpistorage";
        const string storageAccountKey = "Gvq4stQSvsFnHk7Rl7oohl7bzxOhh8FocHFmxTwSiOOU2aWS9U2RfeZbrIqnolUo6Qeic/1v1CqM+AStrfcKQQ==";


        // We can get TableClient in 2 ways, directly through the connectionString or through its TableServiceClient.
        // TableName is necessary to get a existing table.
        TableServiceClient serviceClient = new TableServiceClient(
            new Uri(storageUri),
            new TableSharedKeyCredential(accountName, storageAccountKey));



        public MusicItemController(){}

        // get all music item
        [HttpGet]
        public IEnumerable<MusicItem> GetAll()
        {
            // var tableClient = new TableClient(connectionString, tableName);
            var tableClient = serviceClient.GetTableClient(tableName);
            var response = tableClient.Query<MusicItem>();
            return response.ToList();
        }

        // get music item by rowkey(id)
        [HttpGet("{id}")]
        public MusicItem Get(string id)
        {
            // var tableClient = new TableClient(connectionString, tableName);
            var tableClient = serviceClient.GetTableClient(tableName);
            var response = tableClient.GetEntity<MusicItem>("Solo", id);
            return response.Value;
        }


    }
}