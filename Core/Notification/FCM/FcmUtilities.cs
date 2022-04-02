using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Notification.FCM
{
    public static class FcmUtilities
    {
        public static bool NotifyAsync(string to, string title, string body)
        {
            try
            {
                // Get the server key from FCM console
                var serverKey = string.Format("key={0}", "AAAAe8MIQGA:APA91bGx5b-Ocpcq_k7Lk1yCltbI7hsjFN1x0KhJondCo7JL9PUgbZ8tA6KtB8o_OZE9ZanlBlSg5aQBDO5NeuBietmVcakSmq8cncLs95kBO13USoit1GdnwmfDk8-bGrJmdD3aRpSa");

                // Get the sender id from FCM console
                var senderId = string.Format("id={0}", "531553075296");

                var data = new
                {
                    to, // Recipient device token
                    notification = new { title, body }
                };

                // Using Newtonsoft.Json
                var jsonBody = JsonConvert.SerializeObject(data);

                using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send"))
                {
                    httpRequest.Headers.TryAddWithoutValidation("Authorization", serverKey);
                    httpRequest.Headers.TryAddWithoutValidation("Sender", senderId);
                    httpRequest.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    using (var httpClient = new HttpClient())
                    {
                        var result = httpClient.SendAsync(httpRequest);
                        result.Wait();

                        if (result.Result.IsSuccessStatusCode)
                        {
                            return true;
                        }
                        else
                        {
                            // Use result.StatusCode to handle failure
                            // Your custom error handler here
                            Console.WriteLine($"Error sending notification. Status Code: {result.Result.StatusCode}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown in Notify Service: {ex}");
            }

            return false;
        }
    }
}
