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
            var topic = messageDto.Topic;
            var data = messageDto.Data;
            var title = messageDto.Title;
            var body = messageDto.Body;
            var message = new Message()
            {
                Topic = topic,
                Data = data,
                Notification = new Notification()
                {
                    Title = title,
                    Body = body
                }
            };

            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            var Allusers = MyDbContext.Instance;
            Allusers.IsseterArray();
            
            foreach (var user in Allusers.Users(topic))
            {
                var messageIOS = new Message()
                {
                    Token = user,
                    Data = data,
                    Notification = new Notification()
                    {
                        Title = title,
                        Body = body
                    }
                };
            response = await FirebaseMessaging.DefaultInstance.SendAsync(messageIOS);
            }
            
            Console.WriteLine("Successfully sent message: " + response);

            return Ok();
        }
   
       [HttpPost("NewUser")]
        public async Task<IActionResult> Get([FromBody] UserSaveDto userSaveDto )
        {
            MyDbContext.Instance.AddUser(userSaveDto.Apk, userSaveDto.Token);

            return Ok();
        }
    }
}
