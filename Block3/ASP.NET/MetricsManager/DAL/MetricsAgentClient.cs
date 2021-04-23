using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using MetricsManager.Requests;
using MetricsManager.Responses;
using NLog.Web;
using System.IO;

namespace MetricsManager.DAL
{
    public class MetricsAgentClient : IMetricsAgentClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MetricsAgentClient> _logger;

        public MetricsAgentClient(HttpClient httpClient, ILogger<MetricsAgentClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public AllCpuMetricsApiResponse GetAllCpuMetrics(GetAllCpuMetricsApiRequest request)
        {
            var fromParameter = request.FromTime.ToString("O");
            var toParameter = request.ToTime.ToString("O");
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{request.ClientBaseAddress}/api/metrics/cpu/from/{fromParameter}/to/{toParameter}");
            try
            {

                _logger.LogInformation($"Запрос к агенту:{request.ClientBaseAddress} get CPU meric from:{request.FromTime} to:{request.ToTime}");
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                var seralizerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.DeserializeAsync<AllCpuMetricsApiResponse>(responseStream, seralizerOptions).Result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public AllHddMetricsApiResponse GetAllHddMetrics(GetAllHddMetricsApiRequest request)
        {
            var fromParameter = request.FromTime.ToString("O");
            var toParameter = request.ToTime.ToString("O");
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{request.ClientBaseAddress}/api/metrics/hdd/from/{fromParameter}/to/{toParameter}");
            try
            {

                _logger.LogInformation($"Запрос к агенту:{request.ClientBaseAddress} get hdd meric from:{request.FromTime} to:{request.ToTime}");
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                var seralizerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.DeserializeAsync<AllHddMetricsApiResponse>(responseStream, seralizerOptions).Result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public AllNetworkMetricsApiResponse GetAllNetworkMetrics(GetAllNetworkMetricsApiRequest request)
        {
            var fromParameter = request.FromTime.ToString("O");
            var toParameter = request.ToTime.ToString("O");
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{request.ClientBaseAddress}/api/metrics/network/from/{fromParameter}/to/{toParameter}");
            try
            {

                _logger.LogInformation($"Запрос к агенту:{request.ClientBaseAddress} get network meric from:{request.FromTime} to:{request.ToTime}");
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                var seralizerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.DeserializeAsync<AllNetworkMetricsApiResponse>(responseStream, seralizerOptions).Result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public AllDotNetMetricsApiResponse GetAllDotNetMetrics(GetAllDotNetMetricsApiRequest request)
        {
            var fromParameter = request.FromTime.ToString("O");
            var toParameter = request.ToTime.ToString("O");
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{request.ClientBaseAddress}/api/metrics/dotnet/from/{fromParameter}/to/{toParameter}");
            try
            {

                _logger.LogInformation($"Запрос к агенту:{request.ClientBaseAddress} get dotnet meric from:{request.FromTime} to:{request.ToTime}");
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                var seralizerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.DeserializeAsync<AllDotNetMetricsApiResponse>(responseStream, seralizerOptions).Result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public AllRamMetricsApiResponse GetAllRamMetrics(GetAllRamMetricsApiRequest request)
        {
            var fromParameter = request.FromTime.ToString("O");
            var toParameter = request.ToTime.ToString("O");
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{request.ClientBaseAddress}/api/metrics/ram/from/{fromParameter}/to/{toParameter}");
            try
            {

                _logger.LogInformation($"Запрос к агенту:{request.ClientBaseAddress} get ram meric from:{request.FromTime} to:{request.ToTime}");
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                var seralizerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.DeserializeAsync<AllRamMetricsApiResponse>(responseStream, seralizerOptions).Result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }


    }
}
