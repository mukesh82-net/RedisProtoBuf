using ProtoBuf;

namespace ConsoleApp3.ProtoContracts
{
    [ProtoContract]
    public class Medium
    {
        [ProtoMember(1)] public double minStart { get; set; }
        [ProtoMember(2)] public double multiplier { get; set; }
    }


}
