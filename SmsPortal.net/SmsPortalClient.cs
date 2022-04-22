using SmsPortal.net.Models;
using SmsPortal.net.Requests;
using SmsPortal.net.Responses;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SmsPortal.net
{
    public class SmsPortalClient : IDisposable
    {
        private AuthenticationResponse? _authenticationResponse;

        private DateTime? _authenticationResponseExpiryDate;

        private readonly string _clientId;

        private readonly string _clientSecret;

        private readonly HttpClient _httpClient = new HttpClient();

        public SmsPortalClient(string clientId, string clientSecret)
        {
            _clientId = clientId;

            _clientSecret = clientSecret;

            _httpClient.BaseAddress = new Uri("https://rest.smsportal.com");

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private protected async Task<AuthenticationResponse> Authentication()
        {
            if (_authenticationResponse != null && _authenticationResponseExpiryDate != null && _authenticationResponseExpiryDate.Value.Subtract(DateTime.UtcNow).TotalSeconds > 10)
            {
                return _authenticationResponse;
            }

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "/v2/authentication");

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", $"{Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"))}");

            var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            var json = await httpResponseMessage.Content.ReadAsStringAsync();

            var authenticationResponse = JsonSerializer.Deserialize<AuthenticationResponse>(json);

            if (authenticationResponse == null)
            {
                throw new Exception();
            }

            _authenticationResponseExpiryDate = DateTime.UtcNow.AddMinutes(authenticationResponse.ExpiresInMinutes);

            return authenticationResponse;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<double> GetBalance()
        {
            if (_authenticationResponse == null)
            {
                _authenticationResponse = await Authentication();
            }

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "/v2/balance");

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", _authenticationResponse.Token);

            var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            var json = await httpResponseMessage.Content.ReadAsStringAsync();

            var balanceResponse = JsonSerializer.Deserialize<BalanceResponse>(json);

            if (balanceResponse == null)
            {
                throw new Exception();
            }

            return balanceResponse.Balance;
        }

        private protected async Task BulkMessages(BulkMessagesRequest bulkMessagesRequest)
        {
            if (_authenticationResponse == null)
            {
                _authenticationResponse = await Authentication();
            }

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "/v2/bulkmessages");

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", _authenticationResponse.Token);

            httpRequestMessage.Content = new StringContent(JsonSerializer.Serialize(bulkMessagesRequest), Encoding.UTF8, "application/json");

            var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            // var json = await httpResponseMessage.Content.ReadAsStringAsync();
        }

        protected string SanitizeMobileNumber(string mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber))
            {
                throw new ArgumentNullException(nameof(mobileNumber));
            }

            mobileNumber = mobileNumber.Replace(" ", "")
                                        .Replace("-", "")
                                        .Replace("(", "")
                                        .Replace(")", "");

            if (mobileNumber.StartsWith("0027"))
            {
                mobileNumber = mobileNumber.Substring(2);
            }

            if (mobileNumber.StartsWith("0"))
            {
                mobileNumber = $"27{mobileNumber.Substring(1)}";
            }

            return mobileNumber;
        }

        public async Task Send(string destination, string content)
        {
            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new ArgumentNullException(nameof(destination));
            }

            var bulkMessagesRequest = new BulkMessagesRequest
            {
                Messages = new List<Message>
                {
                    new Message
                    {
                        Content = content,
                        CustomerId = null,
                        Destination = SanitizeMobileNumber(destination),
                        LandingPageVariables = null,
                    }
                },
                SendOptions = null,
            };

            await BulkMessages(bulkMessagesRequest);
        }
    }
}