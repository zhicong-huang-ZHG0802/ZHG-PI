using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using ZHG_PI.Models;


namespace ZHG_PI.Controllers
{
    [ApiController]
    [Route("musicitems")]
    public class MusicItemController : ControllerBase
    {

        const string connectionString = "DefaultEndpointsProtocol=https;AccountName=zhgpistorage;AccountKey=Gvq4stQSvsFnHk7Rl7oohl7bzxOhh8FocHFmxTwSiOOU2aWS9U2RfeZbrIqnolUo6Qeic/1v1CqM+AStrfcKQQ==;EndpointSuffix=core.windows.net";
        const string tableName = "musicItemsTable";

        public MusicItemController(){}

        // get all music item
        [HttpGet]
        public IEnumerable<MusicItem> GetAll()
        {
            var tableClient = new TableClient(connectionString, tableName);
            var response = tableClient.Query<MusicItem>();
            return response.ToList();
        }

        // get music item by rowkey(id)
        [HttpGet("{id}")]
        public MusicItem Get(string id)
        {
            var tableClient = new TableClient(connectionString, tableName);
            var response = tableClient.GetEntity<MusicItem>("Solo", id);
            return response.Value;
        }


    }
}