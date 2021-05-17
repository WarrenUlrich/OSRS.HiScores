using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS.HiScores
{
    public enum Category
    {
        Overall,
        Attack,
        Defence,
        Strength,
        Hitpoints,
        Ranged,
        Prayer,
        Magic,
        Cooking,
        Woodcutting,
        Fletching,
        Fishing,
        Firemaking,
        Crafting,
        Smithing,
        Mining,
        Herblore,
        Agility,
        Thieving,
        Slayer,
        Farming,
        Runecraft,
        Hunter,
        Construction,
        LeaguePoints,
        BountyHunterHunter,
        BountyHunterRogue,
        ClueScrollsAll,
        ClueScrollsBeginner,
        ClueScrollsEasy,
        ClueScrollsMedium,
        ClueScrollsHard,
        ClueScrollsElite,
        ClueScrollsMaster,
        LMS,
        SoulWarsZeal,
        AbyssalSire,
        AlchemicalHydra,
        BarrowsChests,
        Bryophyta,
        Callisto,
        Cerberus,
        ChambersOfXeric,
        ChambersOfXericChallenge,
        ChaosElemental,
        ChaosFanatic,
        CommanderZilyana,
        CorporealBeast,
        CrazyArchaeologist,
        DagannothPrime,
        DagannothRex,
        DagannothSupreme,
        DerangedArchaeologist,
        GeneralGraardor,
        GiantMole,
        GrotesqueGuardians,
        Hespori,
        KalphiteQueen,
        KingBlackDragon,
        Kraken,
        KreeArra,
        KrilTsutsaroth,
        Mimic,
        Nightmare,
        Obor,
        Sarachnis,
        Scorpia,
        Skotizo,
        Tempoross,
        TheGauntlet,
        TheCorruptedGauntlet,
        TheatreOfBlood,
        ThermonuclearSmokeDevil,
        TzKalZuk,
        TzTokJad,
        Venenatis,
        Vetion,
        Vorkath,
        Wintertodt,
        Zalcano,
        Zulrah
    }

    internal static class CategoryExtensions
    {
        internal static string URLStub(this Category category)
        {
            if (category <= Category.Construction)
                return $"overall?table={ (int)category}&";
            else
                return $"overall?category_type=1&table={(int)(category - Category.LeaguePoints)}&";
        }
    }
}
