using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace NotificationSenderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] MessageDto messageDto)
        {

            // Zde byste spustili vaši konzolovou aplikaci a předali jí data z messageDto
            // Například:
            var message = new Message()
            {
                Topic = messageDto.Topic,
                Data = messageDto.Data,
                Notification = new Notification()
                {
                    Title = messageDto.Title,
                    Body = messageDto.Body
                }
            };

            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            Console.WriteLine("Successfully sent message: " + response);

            return Ok();
        }
    }
}
