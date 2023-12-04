using ProtoBuf;

namespace ConsoleApp3.ProtoContracts
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    [ProtoContract]
    public class Boosts
    {
        [ProtoMember(1)] public High high { get; set; }
        [ProtoMember(2)] public Medium medium { get; set; }
        [ProtoMember(3)] public Low low { get; set; }
    }


}
