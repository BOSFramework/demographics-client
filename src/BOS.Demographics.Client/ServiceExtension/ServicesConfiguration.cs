using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace BOS.Demographics.Client.ServiceExtension
{
    public static class ServicesConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="apiKey">BOS API Key generated in the BOS Console</param>
        public static void AddBOSDemographicsClient(this IServiceCollection services, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new NullReferenceException("BOS API Key must not be null or empty.");
            }

            services.AddHttpClient<IDemographicsClient, DemographicsClient>(client =>
            {
                client.BaseAddress = new Uri("https://apis.dev.bosframework.com/demographics/odata/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            });
        }
    }
}
