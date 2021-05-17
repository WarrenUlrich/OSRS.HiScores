using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace OSRS.HiScores
{
    public class PlayerScores
    {
        [JsonInclude]
        public string Name { get; init; }

        [JsonInclude]
        public Mode Mode { get; init; }

        [JsonInclude]
        public Skill Overall { get; init; }

        [JsonInclude]
        public Skill Attack { get; init; }

        [JsonInclude]
        public Skill Defence { get; init; }

        [JsonInclude]
        public Skill Strength { get; init; }

        [JsonInclude]
        public Skill Hitpoints { get; init; }

        [JsonInclude]
        public Skill Ranged { get; init; }

        [JsonInclude]
        public Skill Prayer { get; init; }

        [JsonInclude]
        public Skill Magic { get; init; }

        [JsonInclude]
        public Skill Cooking { get; init; }

        [JsonInclude]
        public Skill Woodcutting { get; init; }

        [JsonInclude]
        public Skill Fletching { get; init; }

        [JsonInclude]
        public Skill Fishing { get; init; }

        [JsonInclude]
        public Skill Firemaking { get; init; }

        [JsonInclude]
        public Skill Crafting { get; init; }

        [JsonInclude]
        public Skill Smithing { get; init; }

        [JsonInclude]
        public Skill Mining { get; init; }

        [JsonInclude]
        public Skill Herblore { get; init; }

        [JsonInclude]
        public Skill Agility { get; init; }

        [JsonInclude]
        public Skill Thieving { get; init; }

        [JsonInclude]
        public Skill Slayer { get; init; }

        [JsonInclude]
        public Skill Farming { get; init; }

        [JsonInclude]
        public Skill Runecraft { get; init; }

        [JsonInclude]
        public Skill Hunter { get; init; }

        [JsonInclude]
        public Skill Construction { get; init; }

        [JsonInclude]
        public Activity LeaguePoints { get; init; }

        [JsonInclude]
        public Activity BountyHunterHunter { get; init; }

        [JsonInclude]
        public Activity BountyHunterRogue { get; init; }

        [JsonInclude]
        public Activity ClueScrollsAll { get; init; }

        [JsonInclude]
        public Activity ClueScrollsBeginner { get; init; }

        [JsonInclude]
        public Activity ClueScrollsEasy { get; init; }

        [JsonInclude]
        public Activity ClueScrollsMedium { get; init; }

        [JsonInclude]
        public Activity ClueScrollsHard { get; init; }

        [JsonInclude]
        public Activity ClueScrollsElite { get; init; }

        [JsonInclude]
        public Activity ClueScrollsMaster { get; init; }

        [JsonInclude]
        public Activity LMS { get; init; }

        [JsonInclude]
        public Activity SoulWarsZeal { get; init; }

        [JsonInclude]
        public Activity AbyssalSire { get; init; }

        [JsonInclude]
        public Activity AlchemicalHydra { get; init; }

        [JsonInclude]
        public Activity BarrowsChests { get; init; }

        [JsonInclude]
        public Activity Bryophyta { get; init; }

        [JsonInclude]
        public Activity Callisto { get; init; }

        [JsonInclude]
        public Activity Cerberus { get; init; }

        [JsonInclude]
        public Activity ChambersOfXeric { get; init; }

        [JsonInclude]
        public Activity ChambersOfXericChallenge { get; init; }

        [JsonInclude]
        public Activity ChaosElemental { get; init; }

        [JsonInclude]
        public Activity ChaosFanatic { get; init; }

        [JsonInclude]
        public Activity CommanderZilyana { get; init; }

        [JsonInclude]
        public Activity CorporealBeast { get; init; }

        [JsonInclude]
        public Activity CrazyArchaeologist { get; init; }

        [JsonInclude]
        public Activity DagannothPrime { get; init; }

        [JsonInclude]
        public Activity DagannothRex { get; init; }

        [JsonInclude]
        public Activity DagannothSupreme { get; init; }

        [JsonInclude]
        public Activity DerangedArchaeologist { get; init; }

        [JsonInclude]
        public Activity GeneralGraardor { get; init; }

        [JsonInclude]
        public Activity GiantMole { get; init; }

        [JsonInclude]
        public Activity GrotesqueGuardians { get; init; }

        [JsonInclude]
        public Activity Hespori { get; init; }

        [JsonInclude]
        public Activity KalphiteQueen { get; init; }

        [JsonInclude]
        public Activity KingBlackDragon { get; init; }

        [JsonInclude]
        public Activity Kraken { get; init; }

        [JsonInclude]
        public Activity KreeArra { get; init; }

        [JsonInclude]
        public Activity KrilTsutsaroth { get; init; }

        [JsonInclude]
        public Activity Mimic { get; init; }

        [JsonInclude]
        public Activity Nightmare { get; init; }

        [JsonInclude]
        public Activity Obor { get; init; }

        [JsonInclude]
        public Activity Sarachnis { get; init; }

        [JsonInclude]
        public Activity Scorpia { get; init; }

        [JsonInclude]
        public Activity Skotizo { get; init; }

        [JsonInclude]
        public Activity Tempoross { get; init; }

        [JsonInclude]
        public Activity TheGauntlet { get; init; }

        [JsonInclude]
        public Activity TheCorruptedGauntlet { get; init; }

        [JsonInclude]
        public Activity TheatreOfBlood { get; init; }

        [JsonInclude]
        public Activity ThermonuclearSmokeDevil { get; init; }

        [JsonInclude]
        public Activity TzKalZuk { get; init; }

        [JsonInclude]
        public Activity TzTokJad { get; init; }

        [JsonInclude]
        public Activity Venenatis { get; init; }

        [JsonInclude]
        public Activity Vetion { get; init; }

        [JsonInclude]
        public Activity Vorkath { get; init; }

        [JsonInclude]
        public Activity Wintertodt { get; init; }

        [JsonInclude]
        public Activity Zalcano { get; init; }

        [JsonInclude]
        public Activity Zulrah { get; init; }

        public static PlayerScores Max => new PlayerScores()
        {
            Overall = Skill.Max,
            Attack = Skill.Max,
            Defence = Skill.Max,
            Strength = Skill.Max,
            Hitpoints = Skill.Max,
            Ranged = Skill.Max,
            Prayer = Skill.Max,
            Magic = Skill.Max,
            Cooking = Skill.Max,
            Woodcutting = Skill.Max,
            Fletching = Skill.Max,
            Fishing = Skill.Max,
            Firemaking = Skill.Max,
            Crafting = Skill.Max,
            Smithing = Skill.Max,
            Mining = Skill.Max,
            Herblore = Skill.Max,
            Agility = Skill.Max,
            Thieving = Skill.Max,
            Slayer = Skill.Max,
            Farming = Skill.Max,
            Runecraft = Skill.Max,
            Hunter = Skill.Max,
            Construction = Skill.Max,
            LeaguePoints  = Activity.Max,
            BountyHunterHunter = Activity.Max,
            BountyHunterRogue = Activity.Max,
            ClueScrollsAll = Activity.Max,
            ClueScrollsBeginner = Activity.Max,
            ClueScrollsEasy = Activity.Max,
            ClueScrollsMedium = Activity.Max,
            ClueScrollsHard = Activity.Max,
            ClueScrollsElite = Activity.Max,
            ClueScrollsMaster = Activity.Max,
            LMS = Activity.Max,
            SoulWarsZeal = Activity.Max,
            AbyssalSire = Activity.Max,
            AlchemicalHydra = Activity.Max,
            BarrowsChests = Activity.Max,
            Bryophyta = Activity.Max,
            Callisto = Activity.Max,
            Cerberus = Activity.Max,
            ChambersOfXeric = Activity.Max,
            ChambersOfXericChallenge = Activity.Max,
            ChaosElemental = Activity.Max,
            ChaosFanatic = Activity.Max,
            CommanderZilyana = Activity.Max,
            CorporealBeast = Activity.Max,
            CrazyArchaeologist = Activity.Max,
            DagannothPrime = Activity.Max,
            DagannothRex = Activity.Max,
            DagannothSupreme = Activity.Max,
            DerangedArchaeologist = Activity.Max,
            GeneralGraardor = Activity.Max,
            GiantMole = Activity.Max,
            GrotesqueGuardians = Activity.Max,
            Hespori = Activity.Max,
            KalphiteQueen = Activity.Max,
            KingBlackDragon = Activity.Max,
            Kraken = Activity.Max,
            KreeArra = Activity.Max,
            KrilTsutsaroth = Activity.Max,
            Mimic = Activity.Max,
            Nightmare = Activity.Max,
            Obor = Activity.Max,
            Sarachnis = Activity.Max,
            Scorpia = Activity.Max,
            Skotizo = Activity.Max,
            Tempoross = Activity.Max,
            TheGauntlet = Activity.Max,
            TheCorruptedGauntlet = Activity.Max,
            TheatreOfBlood = Activity.Max,
            ThermonuclearSmokeDevil = Activity.Max,
            TzKalZuk = Activity.Max,
            TzTokJad = Activity.Max,
            Venenatis = Activity.Max,
            Vetion = Activity.Max,
            Vorkath = Activity.Max,
            Wintertodt = Activity.Max,
            Zalcano = Activity.Max,
            Zulrah = Activity.Max
        };

        public string ToJson()
        {
            return ToJson(new JsonSerializerOptions());
        }

        public string ToJson(JsonSerializerOptions options)
        {
            return JsonSerializer.Serialize(this, options);
        }

        public static IEnumerable<PlayerScores> GetAll(int pageIndex, Mode mode = Mode.Classic, Category category = Category.Overall)
        {
            return GetAllAsync(pageIndex, mode, category).ToEnumerable();
        }

        public static async IAsyncEnumerable<PlayerScores> GetAllAsync(int pageIndex, Mode mode = Mode.Classic, Category category = Category.Overall)
        {
            var site = $"https://secure.runescape.com/m={mode.URLStub()}/{category.URLStub()}page={pageIndex}";

            using (var client = new HttpClient())
            {
                //Incapsula bypass?
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML like Gecko) Chrome/29.0.1547.76 Safari/537.36");
                using (var response = await client.GetAsync(site))
                {
                    var result = Encoding.UTF8.GetString(await response.Content.ReadAsByteArrayAsync());

                    Console.WriteLine(result);
                    var matches = Regex.Matches(result, "user1=(.*?)\"");
                    foreach(var p in matches.AsParallel()
                                            .AsOrdered()
                                            .Select(m => FindAsync(m.Groups[1].Value.Replace('�', ' '), mode)))
                    {
                        yield return await p;
                    }
                }
            }
        }

        public static PlayerScores Find(string name, Mode mode = Mode.Classic)
        {
            return FindAsync(name, mode).Result;
        }

        public async static Task<PlayerScores> FindAsync(string name, Mode mode = Mode.Classic)
        {
            using (HttpClient client = new())
            {
                using (var resp = await client.GetAsync($"https://secure.runescape.com/m={mode.URLStub()}/index_lite.ws?player={name.Replace(' ', '_')}"))
                {
                    if (!resp.IsSuccessStatusCode)
                        throw new PlayerNotFoundException(name, mode);

                    string result = await resp.Content.ReadAsStringAsync();
                    result = result.Replace("\n", " ").Replace(',', ' ');

                    var numberStrings = result.Split(' ');

                    var numbers = numberStrings.Where(s => s.Length > 0)
                                                .Select(s => long.Parse(s))
                                                .ToArray();

                    return new PlayerScores()
                    {
                        Name = name,
                        Mode = mode,
                        Overall = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.OverallRank],
                            Level = numbers[(int)ScoreIndices.OverallLevel],
                            XP = numbers[(int)ScoreIndices.OverallXP]
                        },
                        Attack = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.AttackRank],
                            Level = numbers[(int)ScoreIndices.AttackLevel],
                            XP = numbers[(int)ScoreIndices.AttackXP]
                        },
                        Defence = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.DefenceRank],
                            Level = numbers[(int)ScoreIndices.DefenceLevel],
                            XP = numbers[(int)ScoreIndices.DefenceXP]
                        },
                        Strength = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.StrengthRank],
                            Level = numbers[(int)ScoreIndices.StrengthLevel],
                            XP = numbers[(int)ScoreIndices.StrengthXP]
                        },
                        Hitpoints = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.HitpointsRank],
                            Level = numbers[(int)ScoreIndices.HitpointsLevel],
                            XP = numbers[(int)ScoreIndices.HitpointsXP]
                        },
                        Ranged = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.RangedRank],
                            Level = numbers[(int)ScoreIndices.RangedLevel],
                            XP = numbers[(int)ScoreIndices.RangedXP]
                        },
                        Prayer = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.PrayerRank],
                            Level = numbers[(int)ScoreIndices.PrayerLevel],
                            XP = numbers[(int)ScoreIndices.PrayerXP]
                        },
                        Magic = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.MagicRank],
                            Level = numbers[(int)ScoreIndices.MagicLevel],
                            XP = numbers[(int)ScoreIndices.MagicXP]
                        },
                        Cooking = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.CookingRank],
                            Level = numbers[(int)ScoreIndices.CookingLevel],
                            XP = numbers[(int)ScoreIndices.CookingXP]
                        },
                        Woodcutting = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.WoodcuttingRank],
                            Level = numbers[(int)ScoreIndices.WoodcuttingLevel],
                            XP = numbers[(int)ScoreIndices.WoodcuttingXP]
                        },
                        Fletching = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.FletchingRank],
                            Level = numbers[(int)ScoreIndices.FletchingLevel],
                            XP = numbers[(int)ScoreIndices.FletchingXP]
                        },
                        Fishing = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.FishingRank],
                            Level = numbers[(int)ScoreIndices.FishingLevel],
                            XP = numbers[(int)ScoreIndices.FishingXP]
                        },
                        Firemaking = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.FiremakingRank],
                            Level = numbers[(int)ScoreIndices.FiremakingLevel],
                            XP = numbers[(int)ScoreIndices.FiremakingXP]
                        },
                        Crafting = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.CraftingRank],
                            Level = numbers[(int)ScoreIndices.CraftingLevel],
                            XP = numbers[(int)ScoreIndices.CraftingXP]
                        },
                        Smithing = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.SmithingRank],
                            Level = numbers[(int)ScoreIndices.SmithingLevel],
                            XP = numbers[(int)ScoreIndices.SmithingXP]
                        },
                        Mining = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.MiningRank],
                            Level = numbers[(int)ScoreIndices.MiningLevel],
                            XP = numbers[(int)ScoreIndices.MiningXP]
                        },
                        Herblore = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.HerbloreRank],
                            Level = numbers[(int)ScoreIndices.HerbloreLevel],
                            XP = numbers[(int)ScoreIndices.HerbloreXP]
                        },
                        Agility = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.AgilityRank],
                            Level = numbers[(int)ScoreIndices.AgilityLevel],
                            XP = numbers[(int)ScoreIndices.AgilityXP]
                        },
                        Thieving = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.ThievingRank],
                            Level = numbers[(int)ScoreIndices.ThievingLevel],
                            XP = numbers[(int)ScoreIndices.ThievingXP]
                        },
                        Slayer = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.SlayerRank],
                            Level = numbers[(int)ScoreIndices.SlayerLevel],
                            XP = numbers[(int)ScoreIndices.SlayerXP]
                        },
                        Farming = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.FarmingRank],
                            Level = numbers[(int)ScoreIndices.FarmingLevel],
                            XP = numbers[(int)ScoreIndices.FarmingXP]
                        },
                        Runecraft = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.RunecraftRank],
                            Level = numbers[(int)ScoreIndices.RunecraftLevel],
                            XP = numbers[(int)ScoreIndices.RunecraftXP]
                        },
                        Hunter = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.HunterRank],
                            Level = numbers[(int)ScoreIndices.HunterLevel],
                            XP = numbers[(int)ScoreIndices.HunterXP]
                        },
                        Construction = new Skill()
                        {
                            Rank = numbers[(int)ScoreIndices.ConstructionRank],
                            Level = numbers[(int)ScoreIndices.ConstructionLevel],
                            XP = numbers[(int)ScoreIndices.ConstructionXP]
                        },
                        LeaguePoints = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.LeaguePointsRank],
                            Score = numbers[(int)ScoreIndices.LeaguePointsScore]
                        },
                        BountyHunterHunter = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.BountyHunterHunterRank],
                            Score = numbers[(int)ScoreIndices.BountyHunterHunterScore]
                        },
                        BountyHunterRogue = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.BountyHunterRogueRank],
                            Score = numbers[(int)ScoreIndices.BountyHunterRogueScore]
                        },
                        ClueScrollsAll = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ClueScrollsAllRank],
                            Score = numbers[(int)ScoreIndices.ClueScrollsAllScore]
                        },
                        ClueScrollsBeginner = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ClueScrollsBeginnerRank],
                            Score = numbers[(int)ScoreIndices.ClueScrollsBeginnerScore]
                        },
                        ClueScrollsEasy = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ClueScrollsEasyRank],
                            Score = numbers[(int)ScoreIndices.ClueScrollsEasyScore]
                        },
                        ClueScrollsMedium = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ClueScrollsMediumRank],
                            Score = numbers[(int)ScoreIndices.ClueScrollsMediumScore]
                        },
                        ClueScrollsHard = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ClueScrollsHardRank],
                            Score = numbers[(int)ScoreIndices.ClueScrollsHardScore]
                        },
                        ClueScrollsElite = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ClueScrollsEliteRank],
                            Score = numbers[(int)ScoreIndices.ClueScrollsEliteScore]
                        },
                        ClueScrollsMaster = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ClueScrollsMasterRank],
                            Score = numbers[(int)ScoreIndices.ClueScrollsMasterScore]
                        },
                        LMS = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.LMSRank],
                            Score = numbers[(int)ScoreIndices.LMSScore]
                        },
                        SoulWarsZeal = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.SoulWarsZealRank],
                            Score = numbers[(int)ScoreIndices.SoulWarsZealScore]
                        },
                        AbyssalSire = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.AbyssalSireRank],
                            Score = numbers[(int)ScoreIndices.AbyssalSireScore]
                        },
                        AlchemicalHydra = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.AlchemicalHydraRank],
                            Score = numbers[(int)ScoreIndices.AlchemicalHydraScore]
                        },
                        BarrowsChests = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.BarrowsChestsRank],
                            Score = numbers[(int)ScoreIndices.BarrowsChestsScore]
                        },
                        Bryophyta = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.BryophytaRank],
                            Score = numbers[(int)ScoreIndices.BryophytaScore]
                        },
                        Callisto = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.CallistoRank],
                            Score = numbers[(int)ScoreIndices.CallistoScore]
                        },
                        Cerberus = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.CerberusRank],
                            Score = numbers[(int)ScoreIndices.CerberusScore]
                        },
                        ChambersOfXeric = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ChambersOfXericRank],
                            Score = numbers[(int)ScoreIndices.ChambersOfXericScore]
                        },
                        ChambersOfXericChallenge = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ChambersOfXericChallengeRank],
                            Score = numbers[(int)ScoreIndices.ChambersOfXericChallengeScore]
                        },
                        ChaosElemental = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ChaosElementalRank],
                            Score = numbers[(int)ScoreIndices.ChaosElementalScore]
                        },
                        ChaosFanatic = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ChaosFanaticRank],
                            Score = numbers[(int)ScoreIndices.ChaosFanaticScore]
                        },
                        CommanderZilyana = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.CommanderZilyanaRank],
                            Score = numbers[(int)ScoreIndices.CommanderZilyanaScore]
                        },
                        CorporealBeast = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.CorporealBeastRank],
                            Score = numbers[(int)ScoreIndices.CorporealBeastScore]
                        },
                        CrazyArchaeologist = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.CrazyArchaeologistRank],
                            Score = numbers[(int)ScoreIndices.CrazyArchaeologistScore]
                        },
                        DagannothPrime = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.DagannothPrimeRank],
                            Score = numbers[(int)ScoreIndices.DagannothPrimeScore]
                        },
                        DagannothRex = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.DagannothRexRank],
                            Score = numbers[(int)ScoreIndices.DagannothRexScore]
                        },
                        DagannothSupreme = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.DagannothSupremeRank],
                            Score = numbers[(int)ScoreIndices.DagannothSupremeScore]
                        },
                        DerangedArchaeologist = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.DerangedArchaeologistRank],
                            Score = numbers[(int)ScoreIndices.DerangedArchaeologistScore]
                        },
                        GeneralGraardor = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.GeneralGraardorRank],
                            Score = numbers[(int)ScoreIndices.GeneralGraardorScore]
                        },
                        GiantMole = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.GiantMoleRank],
                            Score = numbers[(int)ScoreIndices.GiantMoleScore]
                        },
                        GrotesqueGuardians = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.GrotesqueGuardiansRank],
                            Score = numbers[(int)ScoreIndices.GrotesqueGuardiansScore]
                        },
                        Hespori = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.HesporiRank],
                            Score = numbers[(int)ScoreIndices.HesporiScore]
                        },
                        KalphiteQueen = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.KalphiteQueenRank],
                            Score = numbers[(int)ScoreIndices.KalphiteQueenRank]
                        },
                        KingBlackDragon = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.KingBlackDragonRank],
                            Score = numbers[(int)ScoreIndices.KingBlackDragonScore]
                        },
                        Kraken = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.KrakenRank],
                            Score = numbers[(int)ScoreIndices.KrakenScore]
                        },
                        KreeArra = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.KreeArraRank],
                            Score = numbers[(int)ScoreIndices.KreeArraScore]
                        },
                        KrilTsutsaroth = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.KrilTsutsarothRank],
                            Score = numbers[(int)ScoreIndices.KrilTsutsarothScore]
                        },
                        Mimic = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.MimicRank],
                            Score = numbers[(int)ScoreIndices.MimicScore]
                        },
                        Nightmare = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.NightmareRank],
                            Score = numbers[(int)ScoreIndices.NightmareScore]
                        },
                        Obor = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.OborRank],
                            Score = numbers[(int)ScoreIndices.OborScore]
                        },
                        Sarachnis = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.SarachnisRank],
                            Score = numbers[(int)ScoreIndices.SarachnisScore]
                        },
                        Scorpia = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ScorpiaRank],
                            Score = numbers[(int)ScoreIndices.ScorpiaScore]
                        },
                        Skotizo = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.SkotizoRank],
                            Score = numbers[(int)ScoreIndices.SkotizoScore]
                        },
                        Tempoross = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.TemporossRank],
                            Score = numbers[(int)ScoreIndices.BountyHunterHunterScore]
                        },
                        TheGauntlet = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.TheGauntletRank],
                            Score = numbers[(int)ScoreIndices.TheGauntletScore]
                        },
                        TheCorruptedGauntlet = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.TemporossScore],
                            Score = numbers[(int)ScoreIndices.BountyHunterHunterScore]
                        },
                        TheatreOfBlood = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.TheatreOfBloodRank],
                            Score = numbers[(int)ScoreIndices.TheatreOfBloodScore]
                        },
                        ThermonuclearSmokeDevil = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ThermonuclearSmokeDevilRank],
                            Score = numbers[(int)ScoreIndices.ThermonuclearSmokeDevilScore]
                        },
                        TzKalZuk = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.TzKalZukRank],
                            Score = numbers[(int)ScoreIndices.TzKalZukScore]
                        },
                        TzTokJad = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.TzTokJadRank],
                            Score = numbers[(int)ScoreIndices.TzTokJadScore]
                        },
                        Venenatis = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.VenenatisRank],
                            Score = numbers[(int)ScoreIndices.VenenatisScore]
                        },
                        Vetion = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.VetionRank],
                            Score = numbers[(int)ScoreIndices.VetionScore]
                        },
                        Vorkath = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.VorkathRank],
                            Score = numbers[(int)ScoreIndices.VorkathScore]
                        },
                        Wintertodt = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.WintertodtRank],
                            Score = numbers[(int)ScoreIndices.WintertodtScore]
                        },
                        Zalcano = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ZalcanoRank],
                            Score = numbers[(int)ScoreIndices.ZalcanoScore]
                        },
                        Zulrah = new Activity()
                        {
                            Rank = numbers[(int)ScoreIndices.ZulrahRank],
                            Score = numbers[(int)ScoreIndices.ZulrahScore]
                        }
                    };
                   
                }
            }
        }

        public static PlayerScores Find(uint rank, Mode mode = Mode.Classic)
        {
            return null;
        }
    }
}
