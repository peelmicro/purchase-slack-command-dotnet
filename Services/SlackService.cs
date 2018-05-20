using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PurchaseSlackCommandDotNet.Models;

namespace PurchaseSlackCommandDotNet.Services 
{
    public class SlackService : ISlackService
        {
        HttpClient HttpClient {get; set;} 
        public SlackService(string token) {
            HttpClient = new HttpClient {
            BaseAddress = new Uri("https://slack.com")
            };
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<SlackChatPostMessageResponse> SendDirectMessage(string users, string message
            , List<SlackAttachment> attachments = null) {
            var conversationOpenRequest = new SlackConversationOpenRequest { 
                Users = users 
            };
            var response = await HttpClient.PostAsJsonAsync(
                "api/conversations.open",  
                conversationOpenRequest);
            response.EnsureSuccessStatusCode();
            var conversationOpenResponse = await response.Content.ReadAsAsync<SlackConversationOpenResponse>();
            var chatPostMessageRequest = new SlackChatPostMessageRequest {
                Channel = conversationOpenResponse.Channel.Id,
                Text = message,
                Attachments = attachments
            };
            response = await HttpClient.PostAsJsonAsync(
                "api/chat.postMessage",
                chatPostMessageRequest
            );
            response.EnsureSuccessStatusCode();
            var chatPostMessageResponse = await response.Content.ReadAsAsync<SlackChatPostMessageResponse>();            
            return chatPostMessageResponse;
        }
    }
}