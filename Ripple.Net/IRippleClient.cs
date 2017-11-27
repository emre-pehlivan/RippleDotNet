using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RippleDotNet.Model.Accounts;
using RippleDotNet.Requests;
using RippleDotNet.Requests.Accounts;
using RippleDotNet.Requests.Transactions;
using RippleDotNet.Responses;

namespace RippleDotNet
{
    public interface IRippleClient : IDisposable
    {
        void Connect();

        void Disconnect();

        Task Ping();

        Task<AccountCurrencies> AccountCurrencies(string account);

        Task<AccountInfo> AccountInfo(string account);

        Task<Model.Transactions.RippleTransaction> Transaction(string transaction);
    }

    public class RippleClient : IRippleClient
    {
        private readonly WebSocketClient client;
        private int requestId;
        private readonly ConcurrentDictionary<int, TaskInfo> tasks;
        private readonly JsonSerializerSettings serializerSettings;

        public RippleClient(string url)
        {
            tasks = new ConcurrentDictionary<int, TaskInfo>();
            serializerSettings = new JsonSerializerSettings();
            serializerSettings.NullValueHandling = NullValueHandling.Ignore;
            serializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            
            client = WebSocketClient.Create(url);
            client.OnMessageReceived(MessageReceived);
            client.OnConnectionError(Error);
            requestId = 0;
        }

        public void Connect()
        {
            client.Connect();
            do
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            } while (client.State != WebSocketState.Open);
        }

        public void Disconnect()
        {
            client.Disconnect();
        }

        public Task Ping()
        {
            requestId++;
            RippleRequest request = new RippleRequest(requestId);
            request.Command = "ping";
            var command = JsonConvert.SerializeObject(request, serializerSettings);
            TaskCompletionSource<object> task = new TaskCompletionSource<object>();

            TaskInfo taskInfo = new TaskInfo();
            taskInfo.TaskId = requestId;
            taskInfo.TaskCompletionResult = task;
            taskInfo.Type = typeof(object);
            taskInfo.RemoveUponCompletion = true;

            tasks.TryAdd(requestId, taskInfo);
            
            client.SendMessage(command);
            return task.Task;
        }

        public Task<AccountCurrencies> AccountCurrencies(string account)
        {
            requestId++;
            AccountCurrenciesRequest request = new AccountCurrenciesRequest(requestId, account);
            var command = JsonConvert.SerializeObject(request, serializerSettings);
            TaskCompletionSource<AccountCurrencies> task = new TaskCompletionSource<AccountCurrencies>();

            TaskInfo taskInfo = new TaskInfo();
            taskInfo.TaskId = requestId;
            taskInfo.TaskCompletionResult = task;
            taskInfo.Type = typeof(AccountCurrencies);
            taskInfo.RemoveUponCompletion = true;

            tasks.TryAdd(requestId, taskInfo);

            client.SendMessage(command);
            return task.Task;
        }

        public Task<AccountInfo> AccountInfo(string account)
        {
            requestId++;
            AccountInfoRequest request = new AccountInfoRequest(requestId, account);
            var command = JsonConvert.SerializeObject(request, serializerSettings);
            TaskCompletionSource<AccountInfo> task = new TaskCompletionSource<AccountInfo>();
            
            TaskInfo taskInfo = new TaskInfo();
            taskInfo.TaskId = requestId;
            taskInfo.TaskCompletionResult = task;
            taskInfo.Type = typeof(AccountInfo);
            taskInfo.RemoveUponCompletion = true;

            tasks.TryAdd(requestId, taskInfo);

            client.SendMessage(command);
            return task.Task;
        }

        public Task<Model.Transactions.RippleTransaction> Transaction(string transaction)
        {
            requestId++;
            TransactionRequest request = new TransactionRequest(requestId, transaction);
            var command = JsonConvert.SerializeObject(request, serializerSettings);
            TaskCompletionSource<Model.Transactions.RippleTransaction> task = new TaskCompletionSource<Model.Transactions.RippleTransaction>();

            TaskInfo taskInfo = new TaskInfo();
            taskInfo.TaskId = requestId;
            taskInfo.TaskCompletionResult = task;
            taskInfo.Type = typeof(Model.Transactions.RippleTransaction);
            taskInfo.RemoveUponCompletion = true;

            tasks.TryAdd(requestId, taskInfo);

            client.SendMessage(command);
            return task.Task;
        }

        private void Error(Exception ex, WebSocketClient client)
        {
            throw new Exception(ex.Message, ex);            
        }

        private void MessageReceived(string s, WebSocketClient client)
        {
            RippleResponse response = JsonConvert.DeserializeObject<RippleResponse>(s);

            var taskInfoResult = tasks.TryGetValue(response.Id, out var taskInfo);
            if (taskInfoResult == false) return;

            if (response.Status == "success")
            {
                var deserialized = JsonConvert.DeserializeObject(response.Result.ToString(), taskInfo.Type, serializerSettings);

                var setResult = taskInfo.TaskCompletionResult.GetType().GetMethod("SetResult");
                setResult.Invoke(taskInfo.TaskCompletionResult, new[] { deserialized });

                if (taskInfo.RemoveUponCompletion)
                {
                    tasks.TryRemove(response.Id, out taskInfo);
                }
            }
            else if (response.Status == "error")
            {
                var setError = taskInfo.TaskCompletionResult.GetType().GetMethod("SetError");
                setError.Invoke(taskInfo.TaskCompletionResult, new[] { response.Error });

                tasks.TryRemove(response.Id, out taskInfo);
            }                        
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
