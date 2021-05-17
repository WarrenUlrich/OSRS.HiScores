using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OSRS.HiScores
{
    public class Skill
    {
        [JsonInclude]
        public long Rank { get; init; }

        [JsonInclude]
        public long Level { get; init; }

        [JsonInclude]
        public long XP { get; init; }

        public static Skill Max => new Skill() { Rank = 1, Level = 99, XP = 200000000 };
    }
}
