using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OSRS.HiScores.Tracker
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : UserControl
    {
        public static SearchPage Instance { get; private set; }

        public SearchPage()
        {
            InitializeComponent();
            this.DataContext = this;

            ModeSelector.Instance.ModeChanged += async (_, _) =>
            {
                await this.DisplayPlayer();
            };

            SearchPage.Instance = this;
        }

        public string PlayerName { get; set; }

        private static Dictionary<string, BitmapImage> CategoryIconCache { get; set; } = new();

        private static BitmapImage GetCategoryIcon(string name)
        {
            if(CategoryIconCache.TryGetValue(name, out var image))
            {
                return image;
            }
            else
            {
                image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream($"OSRS.HiScores.Tracker.OSRSIcons.{name}.png");
                image.EndInit();
                CategoryIconCache.Add(name, image);
                return image;
            }
        }

        public async Task DisplayPlayer()
        {
            if (this.PlayerName == null || this.PlayerName.Length < 1)
                return;

            this.SkillTable.Columns.Clear();
            this.ActivityTable.Columns.Clear();
            this.BusyIndicator.IsBusy = true;

            PlayerScores playerScores;
            try
            {
                playerScores = await PlayerScores.FindAsync(this.PlayerName, ModeSelector.Instance.CurrentMode);
            }
            catch(PlayerNotFoundException e)
            {
                this.BusyIndicator.IsBusy = false;
                return;
            }
            catch(HttpRequestException e)
            {
                this.BusyIndicator.IsBusy = false;
                return;
            }
            
            await DisplayPlayer(playerScores);
        }

        public async Task DisplayPlayer(PlayerScores playerScores)
        {
            this.SkillTable.Columns.Clear();
            this.ActivityTable.Columns.Clear();
            this.BusyIndicator.IsBusy = true;

            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("attack_icon"),
                Skill = playerScores.Attack
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("defence_icon"),
                Skill = playerScores.Defence
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("strength_icon"),
                Skill = playerScores.Strength
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("hitpoints_icon"),
                Skill = playerScores.Hitpoints
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("ranged_icon"),
                Skill = playerScores.Ranged
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("prayer_icon"),
                Skill = playerScores.Prayer
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("magic_icon"),
                Skill = playerScores.Magic
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("cooking_icon"),
                Skill = playerScores.Cooking
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("woodcutting_icon"),
                Skill = playerScores.Woodcutting,
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("fletching_icon"),
                Skill = playerScores.Fletching
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("fishing_icon"),
                Skill = playerScores.Fishing
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("firemaking_icon"),
                Skill = playerScores.Firemaking
            });//
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("crafting_icon"),
                Skill = playerScores.Crafting
            });
            this.SkillTable.Columns?.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("smithing_icon"),
                Skill = playerScores.Smithing
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("mining_icon"),
                Skill = playerScores.Mining
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("herblore_icon"),
                Skill = playerScores.Herblore
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("agility_icon"),
                Skill = playerScores.Agility
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("thieving_icon"),
                Skill = playerScores.Thieving
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("slayer_icon"),
                Skill = playerScores.Slayer
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("farming_icon"),
                Skill = playerScores.Farming
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("runecraft_icon"),
                Skill = playerScores.Runecraft
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("hunter_icon"),
                Skill = playerScores.Hunter
            });
            this.SkillTable.Columns.Add(new SkillColumn()
            {
                Icon = GetCategoryIcon("construction_icon"),
                Skill = playerScores.Construction
            });

            //Activies
            if (playerScores.LeaguePoints?.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("leaguepoints_icon"),
                    Activity = playerScores.LeaguePoints
                });

            if (playerScores.BountyHunterHunter.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("bountyhunterhunter_icon"),
                    Activity = playerScores.BountyHunterHunter
                });

            if (playerScores.BountyHunterRogue.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("bountyhunterrogue_icon"),
                    Activity = playerScores.BountyHunterRogue
                });

            if (playerScores.ClueScrollsAll.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("cluescrollsall_icon"),
                    Activity = playerScores.ClueScrollsAll
                });

            if (playerScores.ClueScrollsBeginner.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("cluescrollsbeginner_icon"),
                    Activity = playerScores.ClueScrollsBeginner
                });

            if (playerScores.ClueScrollsEasy.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("cluescrollseasy_icon"),
                    Activity = playerScores.ClueScrollsEasy
                });

            if (playerScores.ClueScrollsMedium.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("cluescrollsmedium_icon"),
                    Activity = playerScores.ClueScrollsMedium
                });

            if (playerScores.ClueScrollsHard.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("cluescrollshard_icon"),
                    Activity = playerScores.ClueScrollsHard
                });

            if (playerScores.ClueScrollsElite.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("cluescrollselite_icon"),
                    Activity = playerScores.ClueScrollsElite
                });

            if (playerScores.ClueScrollsMaster.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("cluescrollsmaster_icon"),
                    Activity = playerScores.ClueScrollsMaster
                });

            if (playerScores.LMS.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("lms_icon"),
                    Activity = playerScores.LMS
                });

            if (playerScores.SoulWarsZeal.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("soulwarszeal_icon"),
                    Activity = playerScores.SoulWarsZeal
                });

            if (playerScores.AbyssalSire.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("abyssalsire_icon"),
                    Activity = playerScores.AbyssalSire
                });

            if (playerScores.AlchemicalHydra.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("alchemicalhydra_icon"),
                    Activity = playerScores.AlchemicalHydra
                });

            if (playerScores.BarrowsChests.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("barrowschests_icon"),
                    Activity = playerScores.BarrowsChests
                });

            if (playerScores.Bryophyta.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("bryophyta_icon"),
                    Activity = playerScores.Bryophyta
                });

            if (playerScores.Callisto.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("callisto_icon"),
                    Activity = playerScores.Callisto
                });

            if (playerScores.Cerberus.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("cerberus_icon"),
                    Activity = playerScores.Cerberus
                });

            if (playerScores.ChambersOfXeric.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("cox_icon"),
                    Activity = playerScores.ChambersOfXeric
                });

            if (playerScores.ClueScrollsMedium.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("cox_challenge_icon"),
                    Activity = playerScores.ClueScrollsMedium
                });

            if (playerScores.ClueScrollsMedium.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("chaoselemental_icon"),
                    Activity = playerScores.ClueScrollsMedium
                });

            if (playerScores.ChaosFanatic.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("chaosfanatic_icon"),
                    Activity = playerScores.ChaosFanatic
                });

            if (playerScores.CommanderZilyana.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("commanderzilyana_icon"),
                    Activity = playerScores.CommanderZilyana
                });

            if (playerScores.CorporealBeast.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("corporealbeast_icon"),
                    Activity = playerScores.CorporealBeast
                });

            if (playerScores.CrazyArchaeologist.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("crazyarchaeologist_icon"),
                    Activity = playerScores.CrazyArchaeologist
                });

            if (playerScores.DagannothPrime.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("dagannothprime_icon"),
                    Activity = playerScores.DagannothPrime
                });

            if (playerScores.DagannothRex.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("dagannothrex_icon"),
                    Activity = playerScores.DagannothRex
                });

            if (playerScores.DagannothSupreme.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("dagannothsupreme_icon"),
                    Activity = playerScores.DagannothSupreme
                });

            if (playerScores.DerangedArchaeologist.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("derangedarchaeologist_icon"),
                    Activity = playerScores.DerangedArchaeologist
                });

            if (playerScores.GeneralGraardor.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("generalgraardor_icon"),
                    Activity = playerScores.GeneralGraardor
                });

            if (playerScores.GiantMole.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("giantmole_icon"),
                    Activity = playerScores.GiantMole
                });

            if (playerScores.GrotesqueGuardians.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("grotesqueguardians_icon"),
                    Activity = playerScores.GrotesqueGuardians
                });

            if (playerScores.Hespori.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("hespori_icon"),
                    Activity = playerScores.Hespori
                });

            if (playerScores.KalphiteQueen.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("kalphitequeen_icon"),
                    Activity = playerScores.KalphiteQueen
                });

            if (playerScores.KingBlackDragon.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("kingblackdragon_icon"),
                    Activity = playerScores.KingBlackDragon
                });

            if (playerScores.Kraken.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("kraken_icon"),
                    Activity = playerScores.Kraken
                });

            if (playerScores.KreeArra.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("kreearra_icon"),
                    Activity = playerScores.KreeArra
                });

            if (playerScores.KrilTsutsaroth.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("kriltsutsaroth_icon"),
                    Activity = playerScores.KrilTsutsaroth
                });

            if (playerScores.Mimic.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("mimic_icon"),
                    Activity = playerScores.Mimic
                });

            if (playerScores.Nightmare.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("nightmare_icon"),
                    Activity = playerScores.Nightmare
                });

            if (playerScores.Obor.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("obor_icon"),
                    Activity = playerScores.Obor
                });

            if (playerScores.Sarachnis.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("sarachnis_icon"),
                    Activity = playerScores.Sarachnis
                });

            if (playerScores.Scorpia.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("scorpia_icon"),
                    Activity = playerScores.Scorpia
                });

            if (playerScores.Skotizo.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("skotizo_icon"),
                    Activity = playerScores.Skotizo
                });

            if (playerScores.Tempoross.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("tempoross_icon"),
                    Activity = playerScores.Tempoross
                });

            if (playerScores.TheGauntlet.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("thegauntlet_icon"),
                    Activity = playerScores.TheGauntlet
                });

            if (playerScores.TheCorruptedGauntlet.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("thecorruptedgauntlet_icon"),
                    Activity = playerScores.TheCorruptedGauntlet
                });

            if (playerScores.GeneralGraardor.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("generalgraardor_icon"),
                    Activity = playerScores.GeneralGraardor
                });

            if (playerScores.TheatreOfBlood.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("theatreofblood_icon"),
                    Activity = playerScores.TheatreOfBlood
                });

            if (playerScores.ThermonuclearSmokeDevil.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("smokedevil_icon"),
                    Activity = playerScores.ThermonuclearSmokeDevil
                });

            if (playerScores.TzKalZuk.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("tzkalzuk_icon"),
                    Activity = playerScores.TzKalZuk
                });

            if (playerScores.TzTokJad.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("tztokjad_icon"),
                    Activity = playerScores.TzTokJad
                });

            if (playerScores.Venenatis.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("venenatis_icon"),
                    Activity = playerScores.Venenatis
                });

            if (playerScores.Vetion.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("vetion_icon"),
                    Activity = playerScores.Vetion
                });

            if (playerScores.Vorkath.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("vorkath_icon"),
                    Activity = playerScores.Vorkath
                });

            if (playerScores.Wintertodt.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("wintertodt_icon"),
                    Activity = playerScores.Wintertodt
                });

            if (playerScores.Zalcano.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("zalcano_icon"),
                    Activity = playerScores.Zalcano
                });

            if (playerScores.Zulrah.Rank > 0)
                this.ActivityTable.Columns.Add(new ActivityColumn()
                {
                    Icon = GetCategoryIcon("zulrah_icon"),
                    Activity = playerScores.Zulrah
                });

            this.BusyIndicator.IsBusy = false;
        }
        private async void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            await this.DisplayPlayer();
        }
    }
}
