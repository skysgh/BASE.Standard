// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Reflection;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace App.Modules.Core.Infrastructure.ServiceAgents.Implementations.Scanii
{
    public class ScaniiClient
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly RestClient client;


        public ScaniiClient(
            IDiagnosticsTracingService diagnosticsTracingService, string key, string secret,
            string baseUri = "https://api.scanii.com/v2.1")
        {
            BaseUri = baseUri;

            if (string.IsNullOrWhiteSpace(BaseUri))
            {
                BaseUri = "https://api.scanii.com/v2.1";
            }

            _diagnosticsTracingService = diagnosticsTracingService;

            client = new RestClient(BaseUri)
            {
                Authenticator = new HttpBasicAuthenticator(key, secret),
                UserAgent = "scanii-csharp/v" + Assembly.GetExecutingAssembly().GetName().Version
            };


            Log("Running in debug mode " + Assembly.GetExecutingAssembly().GetName());
            Log("Base URI: " + BaseUri);
        }

        public string BaseUri { get; }


        public bool Ping()
        {
            var req = new RestRequest("/ping}") {RequestFormat = DataFormat.Json};
            var resp = client.Get(req);

            Log("content " + resp.Content);
            Log("status code " + resp.StatusCode);

            if (resp.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }

            return true;
        }


        public ScaniiResult Process(byte[] bytes, string fileName, string contentMimeType,
            Dictionary<string, string> metadata = null)
        {
            if (metadata == null)
            {
                metadata = new Dictionary<string, string>();
            }

            var restRequest = new RestRequest("files") {RequestFormat = DataFormat.Json};

            // adding payload
            restRequest.AddFileBytes("file", bytes, fileName, contentMimeType);

            //restRequest.AddFile("file", path);

            foreach (KeyValuePair<string, string> keyValuePair in metadata)
            {
                Log("medata item " + keyValuePair);
                restRequest.AddParameter($"metadata[{keyValuePair.Key}]", keyValuePair.Value);
            }

            var restResponse = client.Post(restRequest);
            Log("content " + restResponse.Content);
            Log("status code " + restResponse.StatusCode);

            if (restResponse.StatusCode != HttpStatusCode.Created)
            {
                throw new ScaniiException(
                    $"Invalid HTTP response status: {restResponse.StatusCode} message: {restResponse.Content}");
            }

            Log("response: " + restResponse.Content);
            var json = restResponse.Content;

            var result =
                JsonConvert.DeserializeObject<ScaniiResult>(json);

            return result;
        }

        public string Retrieve(string id)
        {
            Contract.Requires(id != null);
            Log($"loading id: {id}");

            var req = new RestRequest("/files/{id}") {RequestFormat = DataFormat.Json};
            req.AddUrlSegment("id", id);
            var resp = client.Get(req);

            Log("content " + resp.Content);
            Log("status code " + resp.StatusCode);

            if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new ScaniiException($"Invalid HTTP response status: {resp.StatusCode} message: {resp.Content}");
            }

            Log("response: " + resp.Content);
            return resp.Content;
        }


        private void Log(string message)
        {
            _diagnosticsTracingService.Trace(TraceLevel.Verbose, "ScaniiClient: " + message);
        }
    }
}