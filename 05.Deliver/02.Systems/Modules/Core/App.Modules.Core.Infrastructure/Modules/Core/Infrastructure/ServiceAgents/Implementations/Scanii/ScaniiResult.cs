// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace App.Modules.Core.Infrastructure.ServiceAgents.Implementations.Scanii
{
    public class ScaniiResult
    {
        public long ContentLength;

        public DateTimeOffset? CreationDate = null;
        public List<string> Findings = new List<string>();
        public Dictionary<string, string> Metadata = new Dictionary<string, string>();

        public string RawResponse;

        [DeserializeAs(Name = "id")] public string Id { get; set; }

        [DeserializeAs(Name = "checksum")] public string CheckSum { get; set; }

        [DeserializeAs(Name = "content_type")] public string ContentType { get; set; }

        public override string ToString()
        {
            return
                $"RawResponse: {RawResponse}, ContentLength: {ContentLength}, Findings: {Findings}, CreationDate: {CreationDate}, Metadata: {Metadata}, Id: {Id}, CheckSum: {CheckSum}, ContentType: {ContentType}";
        }
    }
}