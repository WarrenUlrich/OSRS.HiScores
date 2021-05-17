using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OSRS.HiScores
{
    public class Activity
    {
        [JsonInclude]
        public long Rank { get; init; }

        [JsonInclude]
        public long Score { get; init; }

        public static Activity Max => new Activity() { Rank = 1, Score = 200000000 };
    }
}
