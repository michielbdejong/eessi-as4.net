using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Eu.EDelivery.AS4.Fe.Monitor.Model
{
    [Route("api/[controller]")]
    public class MonitorController : Controller
    {
        private readonly IMonitorService monitorService;

        public MonitorController(IMonitorService monitorService)
        {
            this.monitorService = monitorService;
        }

        [HttpGet]
        [Route("exceptions")]
        public async Task<IActionResult> GetInExceptions(ExceptionFilter filter)
        {
            return new OkObjectResult(await monitorService.GetExceptions(filter));
        }

        [HttpGet]
        [Route("messages")]
        public async Task<IActionResult> GetMessages(MessageFilter filter)
        {
            return new OkObjectResult(await monitorService.GetMessages(filter));
        }

        [HttpGet]
        [Route("relatedmessages")]
        public async Task<IActionResult> GetRelatedMessages(Direction direction, string messageId)
        {
            return new OkObjectResult(await monitorService.GetRelatedMessages(direction, messageId));
        }

        [HttpGet]
        [Route("messagebody")]
        public async Task<FileStreamResult> GetMessageBody(Direction direction, string messageId)
        {
            return File(await monitorService.DownloadMessageBody(direction, messageId), "application/xml");
        }

        [HttpGet]
        [Route("exceptionbody")]
        public async Task<FileContentResult> GetExceptionBody(Direction direction, string messageId)
        {
            return File(await monitorService.DownloadExceptionBody(direction, messageId), "application/xml");
        }

        [HttpGet]
        [Route("detail")]
        public async Task<IActionResult> GetDetails(Direction direction, string messageId)
        {
            return new OkObjectResult(await monitorService.GetMessageDetails(direction, messageId));
        }
    }
}