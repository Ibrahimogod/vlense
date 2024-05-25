using System.Text.Json.Serialization;

namespace VlensePOC.Modes;

[JsonConverter(typeof(JsonStringEnumConverter<StepType>))]
public enum StepType
{
    Unknown,
    Front,
    Back
}