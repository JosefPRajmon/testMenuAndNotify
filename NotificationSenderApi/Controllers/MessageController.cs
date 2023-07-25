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


            var topic = messageDto.Topic;
            var data = messageDto.Data;
            var title = messageDto.Title;
            var body = messageDto.Body;


            string response = "";
            var Allusers = MyDbContext.Instance;
            Allusers.IsseterArray();
            if (Allusers.Users(topic).Count>0)
            {

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
            }else
            {
                return BadRequest();
            }
        }
   
       [HttpPost("NewUser")]
        public async Task<IActionResult> Get([FromBody] UserSaveDto userSaveDto )
        {
            MyDbContext.Instance.AddUser(userSaveDto.Apk, userSaveDto.Token);

            return Ok();
        }
    }
}
