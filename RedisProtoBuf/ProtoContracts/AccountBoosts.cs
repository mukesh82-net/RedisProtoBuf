using ProtoBuf;

namespace ConsoleApp3.ProtoContracts
{
    [ProtoContract]
    public class AccountBoosts
    {
        [ProtoMember(1)] public string account { get; set; }
        [ProtoMember(2)] public Boosts boosts { get; set; }
        [ProtoMember(3)] public List<Mapping> mapping { get; set; }
    }


}
