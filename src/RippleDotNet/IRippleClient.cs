using System;
using System.Collections.Concurrent;
using System.Dynamic;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RippleDotNet.Exceptions;
using RippleDotNet.Model.Accounts;
using RippleDotNet.Model.Transactions;
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

        Task<AccountCurrencies> AccountCurrencies(AccountCurrenciesRequest request);

        Task<AccountChannels> AccountChannels(string account);

        Task<AccountChannels> AccountChannels(AccountChannelsRequest request);

        Task<AccountInfo> AccountInfo(string account);

        Task<AccountInfo> AccountInfo(AccountInfoRequest request);

        Task<AccountLines> AccountLines(string account);

        Task<AccountLines> AccountLines(AccountLinesRequest request);

        Task<AccountOffers> AccountOffers(string account);

        Task<AccountOffers> AccountOffers(AccountOffersRequest request);

        Task<AccountObjects> AccountObjects(string account);

        Task<AccountObjects> AccountObjects(AccountObjectsRequest request);

        Task<AccountTransactions> AccountTransactions(string account);

        Task<AccountTransactions> AccountTransactions(AccountTransactionsRequest request);

        Task<NoRippleCheck> NoRippleCheck(string account);

        Task<NoRippleCheck> NoRippleCheck(NoRippleCheckRequest request);

        Task<BaseTransaction> Transaction(string transaction);

        Task<BaseTransaction> Transaction(TransactionRequest request);

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
            return AccountCurrencies(request);
        }

        public Task<AccountCurrencies> AccountCurrencies(AccountCurrenciesRequest request)
        {
            var command = JsonConvert.SerializeObject(request, serializerSettings);
            TaskCompletionSource<AccountCurrencies> task = new TaskCompletionSource<AccountCurrencies>();

            TaskInfo taskInfo = new TaskInfo();
            taskInfo.TaskId = request.Id;
            taskInfo.TaskCompletionResult = task;
            taskInfo.Type = typeof(AccountCurrencies);
            taskInfo.RemoveUponCompletion = true;

            tasks.TryAdd(request.Id, taskInfo);

            client.SendMessage(command);
            return task.Task;
        }

        public Task<AccountChannels> AccountChannels(string account)
        {
            requestId++;
            AccountChannelsRequest request = new AccountChannelsRequest(requestId, account);
            return AccountChannels(request);
        }

        public Task<AccountChannels> AccountChannels(AccountChannelsRequest request)
        {
            var command = JsonConvert.SerializeObject(request, serializerSettings);
            TaskCompletionSource<AccountChannels> task = new TaskCompletionSource<AccountChannels>();

            TaskInfo taskInfo = new TaskInfo();
            taskInfo.TaskId = request.Id;
            taskInfo.TaskCompletionResult = task;
            taskInfo.Type = typeof(AccountChannels);
            taskInfo.RemoveUponCompletion = true;

            tasks.TryAdd(request.Id, taskInfo);

            client.SendMessage(command);
            return task.Task;
        }

        public Task<AccountInfo> AccountInfo(string account)
        {
            requestId++;
            AccountInfoRequest request = new AccountInfoRequest(requestId, account);
            return AccountInfo(request);
        }

        public Task<AccountInfo> AccountInfo(AccountInfoRequest request)
        {
            var command = JsonConvert.SerializeObject(request, serializerSettings);
            TaskCompletionSource<AccountInfo> task = new TaskCompletionSource<AccountInfo>();

            TaskInfo taskInfo = new TaskInfo();
            taskInfo.TaskId = request.Id;
            taskInfo.TaskCompletionResult = task;
            taskInfo.Type = typeof(AccountInfo);
            taskInfo.RemoveUponCompletion = true;

            tasks.TryAdd(request.Id, taskInfo);

            client.SendMessage(command);
            return task.Task;
        }

        public Task<AccountLines> AccountLines(string account)
        {
            requestId++;
            AccountLinesRequest request = new AccountLinesRequest(requestId, account);
            return AccountLines(request);
        }

        public Task<AccountLines> AccountLines(AccountLinesRequest request)
        {
            var command = JsonConvert.SerializeObject(request, serializerSettings);
            TaskCompletionSource<AccountLines> task = new TaskCompletionSource<AccountLines>();

            TaskInfo taskInfo = new TaskInfo();
            taskInfo.TaskId = request.Id;
            taskInfo.TaskCompletionResult = task;
            taskInfo.Type = typeof(AccountLines);
            taskInfo.RemoveUponCompletion = true;

            tasks.TryAdd(request.Id, taskInfo);

            client.SendMessage(command);
            return task.Task;
        }

        public Task<AccountOffers> AccountOffers(string account)
        {
            requestId++;
            AccountOffersRequest request = new AccountOffersRequest(requestId, account);
            return AccountOffers(request);
        }

        public Task<AccountOffers> AccountOffers(AccountOffersRequest request)
        {
            var command = JsonConvert.SerializeObject(request, serializerSettings);
            TaskCompletionSource<AccountOffers> task = new TaskCompletionSource<AccountOffers>();

            TaskInfo taskInfo = new TaskInfo();
            taskInfo.TaskId = request.Id;
            taskInfo.TaskCompletionResult = task;
            taskInfo.Type = typeof(AccountOffers);
            taskInfo.RemoveUponCompletion = true;

            tasks.TryAdd(request.Id, taskInfo);

            client.SendMessage(command);
            return task.Task;
        }

        public Task<AccountObjects> AccountObjects(string account)
        {
            requestId++;
            AccountObjectsRequest request = new AccountObjectsRequest(requestId, account);
            return AccountObjects(request);
        }

        public Task<AccountObjects> AccountObjects(AccountObjectsRequest request)
        {
            var command = JsonConvert.SerializeObject(request, serializerSettings);
            TaskCompletionSource<AccountObjects> task = new TaskCompletionSource<AccountObjects>();

            TaskInfo taskInfo = new TaskInfo();
            taskInfo.TaskId = request.Id;
            taskInfo.TaskCompletionResult = task;
            taskInfo.Type = typeof(AccountObjects);
            taskInfo.RemoveUponCompletion = true;

            tasks.TryAdd(request.Id, taskInfo);

            client.SendMessage(command);
            return task.Task;
        }

        public Task<AccountTransactions> AccountTransactions(string account)
        {
            requestId++;
            AccountTransactionsRequest request = new AccountTransactionsRequest(requestId, account);
            return AccountTransactions(request);
        }

        public Task<AccountTransactions> AccountTransactions(AccountTransactionsRequest request)
        {
            var command = JsonConvert.SerializeObject(request, serializerSettings);
            TaskCompletionSource<AccountTransactions> task = new TaskCompletionSource<AccountTransactions>();

            TaskInfo taskInfo = new TaskInfo();
            taskInfo.TaskId = request.Id;
            taskInfo.TaskCompletionResult = task;
            taskInfo.Type = typeof(AccountTransactions);
            taskInfo.RemoveUponCompletion = true;

            tasks.TryAdd(request.Id, taskInfo);

            client.SendMessage(command);
            return task.Task;
        }

        public Task<NoRippleCheck> NoRippleCheck(string account)
        {
            requestId++;
            NoRippleCheckRequest request = new NoRippleCheckRequest(requestId, account);
            return NoRippleCheck(request);
        }

        public Task<NoRippleCheck> NoRippleCheck(NoRippleCheckRequest request)
        {
            var command = JsonConvert.SerializeObject(request, serializerSettings);
            TaskCompletionSource<NoRippleCheck> task = new TaskCompletionSource<NoRippleCheck>();

            TaskInfo taskInfo = new TaskInfo();
            taskInfo.TaskId = request.Id;
            taskInfo.TaskCompletionResult = task;
            taskInfo.Type = typeof(NoRippleCheck);
            taskInfo.RemoveUponCompletion = true;

            tasks.TryAdd(request.Id, taskInfo);

            client.SendMessage(command);
            return task.Task;
        }

        public Task<BaseTransaction> Transaction(string transaction)
        {
            requestId++;
            TransactionRequest request = new TransactionRequest(requestId, transaction);
            return Transaction(request);
        }

        public Task<BaseTransaction> Transaction(TransactionRequest request)
        {
            var command = JsonConvert.SerializeObject(request, serializerSettings);
            TaskCompletionSource<BaseTransaction> task = new TaskCompletionSource<BaseTransaction>();

            TaskInfo taskInfo = new TaskInfo();
            taskInfo.TaskId = requestId;
            taskInfo.TaskCompletionResult = task;
            taskInfo.Type = typeof(BaseTransaction);
            taskInfo.RemoveUponCompletion = true;

            tasks.TryAdd(request.Id, taskInfo);

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
            if (taskInfoResult == false) throw new Exception("Task not found");

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
                var setException = taskInfo.TaskCompletionResult.GetType().GetMethod("SetException", new Type[]{typeof(Exception)}, null);

                RippleException exception = new RippleException(response.Error);
                setException.Invoke(taskInfo.TaskCompletionResult, new[] { exception });

                tasks.TryRemove(response.Id, out taskInfo);
            }                        
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
