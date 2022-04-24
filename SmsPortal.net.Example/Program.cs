using SmsPortal.net;

var clientId = "<insert-your-client-id-here>";
var clientSecret = "<insert-your-client-secret-here>";

var smsPortalClient = new SmsPortalClient(clientId, clientSecret);

var mobileNumber = "0766542813";

await smsPortalClient.SendMessage(new Message(mobileNumber, "Hello World"));
