using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmsPortal.net.Tests
{
    [TestClass]
    public class SmsPortalClientTests
    {
        [TestMethod]
        public void Send()
        {
            var smsPortalClient = new SmsPortalClient("fdfa1e6e-915f-413b-9d0a-701bea46d1cd", "<client-secret>");

            smsPortalClient.Send("0766542813", "Hello World").GetAwaiter().GetResult();
        }

        [TestMethod]
        public void GetBalance()
        {
            var smsPortalClient = new SmsPortalClient("fdfa1e6e-915f-413b-9d0a-701bea46d1cd", "<client-secret>");

            var balance = smsPortalClient.GetBalance().GetAwaiter().GetResult();
        }
    }
}