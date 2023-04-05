namespace mms_api.Models.Beans;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public partial class ApiResponse
{
    [JsonProperty("status")]
    public bool Status { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("data")]
    public object[] Data { get; set; }
}

public partial class ApiResponse
{
    public static ApiResponse FromJson(string json) => JsonConvert.DeserializeObject<ApiResponse>(json, Beans.Converter.Settings);
}

public static class Serialize
{
    public static string ToJson(this ApiResponse self) => JsonConvert.SerializeObject(self, Beans.Converter.Settings);
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
        {
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        },
    };
}