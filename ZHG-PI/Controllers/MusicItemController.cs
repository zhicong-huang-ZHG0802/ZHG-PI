using Azure.Data.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ZHG_PI.Models;

namespace ZHG_PI.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("musicitems")]
    public class MusicItemController : ControllerBase
    {
        private readonly ILogger<MusicItemController> _logger;

        private readonly TableServiceClient _tableServiceClient;

        public MusicItemController(ILogger<MusicItemController> logger, TableServiceClient tableServiceClient)
        {
            _tableServiceClient = tableServiceClient;
            _logger = logger;
        }

        // get all music item
        [HttpGet]
        public IEnumerable<MusicItem> GetAll()
        {
            var tableClient = _tableServiceClient.GetTableClient("StudentTable");
            var response = tableClient.Query<MusicItem>();
            return response.ToList();
        }
    }
}