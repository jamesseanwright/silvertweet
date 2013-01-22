using System;
using System.Json;
using System.Runtime.Serialization;

namespace DiggSample
{
    [DataContractAttribute]
    public class APIResponse
    {
        public JsonArray results { get; set; }
    }
}
