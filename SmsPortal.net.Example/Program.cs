using SmsPortal.net;

var clientId = "<insert-your-client-id-here>";
var clientSecret = "<insert-your-client-secret-here>";

var smsPortalClient = new SmsPortalClient(clientId, clientSecret);

await smsPortalClient.Send("0766542813", "Hello World");
