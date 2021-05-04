using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Asynchronous_programming
{
    class Program
    {
        private static readonly int _startPost = 4;
        private static readonly int _endPost = 13;
        private static readonly string _urlRequest = "https://jsonplaceholder.typicode.com/posts/";
        private static readonly string _outputFileName = "result.txt";
        private static readonly HttpClient _client = new HttpClient();

        static async Task Main(string[] args)
        {
            var listOfPosts = new List<ResponseDto>();

            if (File.Exists(_outputFileName))
            {
                File.Delete(_outputFileName);
            }

            var tasks = new List<Task<ResponseDto>>();
            for (int i = _startPost; i <= _endPost; i++)
            {
                var task = getPost(i);
                tasks.Add(task);
            }

            // ждем завершения всех запущенных в работу задач
            await Task.WhenAll(tasks);

            //результат каждой задачи заносим в список
            tasks.ForEach(t => listOfPosts.Add(t.Result));

            //Записываем данные из списка в выходной файл
            foreach(var currentPost in listOfPosts)
            {
                var outputData = 
                    currentPost.userId.ToString() + "\n"+ 
                    currentPost.id.ToString() + "\n"+
                    currentPost.title + "\n"+
                    currentPost.body + "\n\n";

                File.AppendAllText(_outputFileName, outputData);
            }
        }

        static async Task<ResponseDto> getPost(int postId)
        {
            var httpRequest = _urlRequest + postId.ToString();
            var httpResponse = await _client.GetAsync(httpRequest);
            
            if (!httpResponse.IsSuccessStatusCode)
            {
                Console.WriteLine($"Ошибка выполнения запроса {httpRequest}");
                return default;
            }
            var bodyResponse = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDto>(bodyResponse);
            return response;
        }

    }
}
