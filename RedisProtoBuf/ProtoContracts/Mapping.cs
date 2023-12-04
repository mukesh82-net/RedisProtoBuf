using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace ConsoleApp3.ProtoContracts
{

    [ProtoContract]
    public class Mapping
    {
        [ProtoMember(1)] public string country { get; set; }
        [ProtoMember(2)] public string region { get; set; }
        [ProtoMember(3)] public string city { get; set; }
        [ProtoMember(4)] public List<string> highTlds { get; set; }
        [ProtoMember(5)] public List<string> medTlds { get; set; }
        [ProtoMember(6)] public List<string> lowTlds { get; set; }
    }


}
