﻿using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace App.Modules.Core.Infrastructure.ServiceAgents.Implementations.Scanii
{

    public class ScaniiResult
    {
        public long ContentLength;

        public DateTime? CreationDate = null;
        public List<string> Findings = new List<string>();
        public Dictionary<string, string> Metadata = new Dictionary<string, string>();

        public string RawResponse;

        [DeserializeAs(Name = "id")]
        public string Id { get; set; }

        [DeserializeAs(Name = "checksum")]
        public string CheckSum { get; set; }

        [DeserializeAs(Name = "content_type")]
        public string ContentType { get; set; }

        public override string ToString()
        {
            return
                $"RawResponse: {this.RawResponse}, ContentLength: {this.ContentLength}, Findings: {this.Findings}, CreationDate: {this.CreationDate}, Metadata: {this.Metadata}, Id: {this.Id}, CheckSum: {this.CheckSum}, ContentType: {this.ContentType}";
        }
    }
}