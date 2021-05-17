using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS.HiScores
{
    public enum Mode
    {
        Classic,
        Ironman,
        UltimateIronman,
        HardcoreIronman,
        Deadman,
        Leagues,
        Tournament
    }

    internal static class ModeExtensions
    {
        internal static string URLStub(this Mode mode)
        {
            switch(mode)
            {
                case Mode.Classic:
                    return "hiscore_oldschool";

                case Mode.Ironman:
                    return "hiscore_oldschool_ironman";

                case Mode.UltimateIronman:
                    return "hiscore_oldschool_ultimate";

                case Mode.HardcoreIronman:
                    return "hiscore_oldschool_hardcore_ironman";

                case Mode.Deadman:
                    return "hiscore_oldschool_deadman";

                case Mode.Leagues:
                    return "hiscore_oldschool_seasonal";

                default:
                    return "hiscore_oldschool";
            }
        }
    }
}
