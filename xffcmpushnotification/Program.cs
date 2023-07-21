using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

/*List<string> allUsers = new List<string>()
{
    "d7vmhQHHTiWeeur3gEeI5x:APA91bHMFzBkJcilknN5OG4B8c0q0kPGFQG492R4jASwAUleAgIA7QrAqyXyoYXp1XXYHvjgk8ZryIdXTRQPThFfZjPOVK26JqqUaYfiQi1FpeczZLvv0ZCIKQPctDMOqH4Tdj0DScaP",
};*/
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("C:\\Users\\J.Rajmon\\source\\repos\\testMenu\\xffcmpushnotification\\private_key.json"),
});

//var registrationToken = "";
/*foreach (var user in allUsers)
{*/
    var message = new Message()
    {
        //Token = registrationToken,
        Topic = "general",
        //Token = user,
        Data = new Dictionary<string, string>()
        {
            { "myData", "850" },
            { "time", "2:45" },
        },
        Notification = new Notification()
        {

            Title = "Hello World",
            Body = "This is a notification from Firebase Cloud Messaging!"
        }
    };

    string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
    Console.WriteLine("Successfully sent message: " + response);
//}