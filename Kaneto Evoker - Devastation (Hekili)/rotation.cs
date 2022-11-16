using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class KanetoEvokerDevastationHekili : Rotation
    {
        //Random Number
        private static readonly Random getrandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
        private static string Language = "English";

        #region SpellFunctions
        #endregion

        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle", };
        private List<string> m_DebuffsList;
        private List<string> m_BuffsList;
        private List<string> m_ItemsList;
        private List<string> m_SpellBook;

        private List<string> m_RaceList = new List<string> { "human", "dwarf", "nightelf", "gnome", "draenei", "pandaren", "orc", "scourge", "tauren", "troll", "bloodelf", "goblin", "worgen", "voidelf", "lightforgeddraenei", "highmountaintauren", "nightborne", "zandalaritroll", "magharorc", "kultiran", "darkirondwarf", "vulpera", "mechagnome" };

        private List<string> m_CastingList = new List<string> { "Manual", "Cursor", "Player" };

        private List<int> Torghast_InnerFlame = new List<int> { 258935, 258938, 329422, 329423, };

        List<int> InstanceIDList = new List<int>
        {
            2291,
            2287,
            2290,
            2289,
            2284,
            2285,
            2286,
            2293,
            1663,
            1664,
            1665,
            1666,
            1667,
            1668,
            1669,
            1674,
            1675,
            1676,
            1677,
            1678,
            1679,
            1680,
            1683,
            1684,
            1685,
            1686,
            1687,
            1692,
            1693,
            1694,
            1695,
            1697,
            1989,
            1990,
            1991,
            1992,
            1993,
            1994,
            1995,
            1996,
            1997,
            1998,
            1999,
            2000,
            2001,
            2002,
            2003,
            2004,
            2441,
            2450
        };

        List<int> TorghastList = new List<int> { 1618 - 1641, 1645, 1705, 1712, 1716, 1720, 1721, 1736, 1749, 1751 - 1754, 1756 - 1812, 1833 - 1911, 1913, 1914, 1920, 1921, 1962 - 1969, 1974 - 1988, 2010 - 2012, 2019 };

        List<int> SpecialUnitList = new List<int> { 176581, 176920, 178008, 168326, 168969, 175861, };

        public Dictionary<string, int> PartyDict = new Dictionary<string, int>() { };
        #endregion

        #region Misc Checks
        private bool TargetAlive()
        {
            if (Aimsharp.CustomFunction("UnitIsDead") == 2)
                return true;

            return false;
        }

        public enum CleansePlayers
        {
            player = 1,
            party1 = 2,
            party2 = 4,
            party3 = 8,
            party4 = 16,
        }

        private bool isUnitCleansable(CleansePlayers unit, int states)
        {
            if ((states & (int)unit) == (int)unit)
            {
                return true;
            }
            return false;
        }

        public bool UnitFocus(string unit)
        {
            if (Aimsharp.CustomFunction("UnitIsFocus") == 1 && unit == "party1" || Aimsharp.CustomFunction("UnitIsFocus") == 2 && unit == "party2" || Aimsharp.CustomFunction("UnitIsFocus") == 3 && unit == "party3" || Aimsharp.CustomFunction("UnitIsFocus") == 4 && unit == "party4" || Aimsharp.CustomFunction("UnitIsFocus") == 5 && unit == "player")
                return true;

            return false;
        }
        #endregion

        #region CanCasts

        #endregion

        #region Debuffs

        #endregion

        #region Buffs

        #endregion

        #region Initializations

        private void InitializeMacros()
        {
            //Auto Target
            Macros.Add("TargetEnemy", "/targetenemy");

            //Trinket
            Macros.Add("TopTrinket", "/use 13");
            Macros.Add("BotTrinket", "/use 14");

            //Healthstone
            Macros.Add("UseHealthstone", "/use " + Healthstone_SpellName(Language));


            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + (Aimsharp.Latency + 100));

            //Queues
            Macros.Add("PolymorphOff", "/" + FiveLetters + " Polymorph");
            Macros.Add("RingofFrostOff", "/" + FiveLetters + " RingofFrost");
            Macros.Add("FlamestrikeOff", "/" + FiveLetters + " Flamestrike");
            Macros.Add("MeteorOff", "/" + FiveLetters + " Meteor");
            Macros.Add("DoorofShadowsOff", "/" + FiveLetters + " DoorofShadows");

            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");
            Macros.Add("RC_FOC", "/cast [@focus] " + RemoveCurse_SpellName(Language));

            Macros.Add("PolymorphMO", "/cast [@mouseover] " + Polymorph_SpellName(Language));
            Macros.Add("SpellstealMO", "/cast [@mouseover] " + Spellsteal_SpellName(Language));
            Macros.Add("RingofFrostC", "/cast [@cursor] RingofFrost");
            Macros.Add("FlamestrikeC", "/cast [@cursor] " + Flamestrike_SpellName(Language));
            Macros.Add("MeteorC", "/cast [@cursor] " + Meteor_SpellName(Language));
            Macros.Add("RingofFrostP", "/cast [@player] RingofFrost");
            Macros.Add("FlamestrikeP", "/cast [@player] " + Flamestrike_SpellName(Language));
            Macros.Add("MeteorP", "/cast [@player] " + Meteor_SpellName(Language));
        }

        private void InitializeSpells()
        {
            foreach (string Spell in m_SpellBook)
                Spellbook.Add(Spell);

            foreach (string Buff in m_BuffsList)
                Buffs.Add(Buff);

            foreach (string Debuff in m_DebuffsList)
                Debuffs.Add(Debuff);

            foreach (string Item in m_ItemsList)
                Items.Add(Item);

            foreach (string MacroCommand in m_IngameCommandsList)
                CustomCommands.Add(MacroCommand);
        }

        private void InitializeCustomLUAFunctions()
        {
            CustomFunctions.Add("HekiliID1", "local loading, finished = IsAddOnLoaded(\"Hekili\") \r\nif loading == true and finished == true then \r\n    local id=Hekili_GetRecommendedAbility(\"Primary\",1)\r\n\tif id ~= nil then\r\n\t\r\n    if id<0 then \r\n\t if id == -101 then return 999999 end local spell = Hekili.Class.abilities[id]\r\n\t    if spell ~= nil and spell.item ~= nil then \r\n\t    \tid=spell.item\r\n\t\t    local topTrinketLink = GetInventoryItemLink(\"player\",13)\r\n\t\t    local bottomTrinketLink = GetInventoryItemLink(\"player\",14)\r\n\t\t    if topTrinketLink  ~= nil then\r\n                local trinketid = GetItemInfoInstant(topTrinketLink)\r\n                if trinketid ~= nil then\r\n\t\t\t        if trinketid == id then\r\n\t\t\t\t        return 1\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t\t    if bottomTrinketLink ~= nil then\r\n                local trinketid = GetItemInfoInstant(bottomTrinketLink)\r\n                if trinketid ~= nil then\r\n    \t\t\t    if trinketid == id then\r\n\t    \t\t\t    return 2\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t    end \r\n    end\r\n    return id\r\nend\r\nend\r\nreturn 0");

            CustomFunctions.Add("GetSpellQueueWindow", "local sqw = GetCVar(\"SpellQueueWindow\"); if sqw ~= nil then return tonumber(sqw); end return 0");

            CustomFunctions.Add("CooldownsToggleCheck", "local loading, finished = IsAddOnLoaded(\"Hekili\") if loading == true and finished == true then local cooldowns = Hekili:GetToggleState(\"cooldowns\") if cooldowns == true then return 1 else if cooldowns == false then return 2 end end end return 0");

            CustomFunctions.Add("UnitIsDead", "if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == true then return 1 end; if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == false then return 2 end; return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");

            CustomFunctions.Add("HekiliWait", "if HekiliDisplayPrimary.Recommendations[1].wait ~= nil and HekiliDisplayPrimary.Recommendations[1].wait * 1000 > 0 then return math.floor(HekiliDisplayPrimary.Recommendations[1].wait * 1000) end return 0");

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("HekiliEnemies", "if Hekili.State.active_enemies ~= nil and Hekili.State.active_enemies > 0 then return Hekili.State.active_enemies end return 0");

            CustomFunctions.Add("PhialCount", "local count = GetItemCount(177278) if count ~= nil then return count end return 0");

            CustomFunctions.Add("FlamestrikeMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Fireball','mouseover') == 1 then return 1 end; return 0");

            CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
            "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
            "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
            "\nreturn foc");

            CustomFunctions.Add("CurseCheck", "local y=0; " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"player\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" then y = y +1; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" then y = y +2; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" then y = y +4; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" then y = y +8; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" then y = y +16; end end " +
            "return y");

            CustomFunctions.Add("GroupTargets",
            "local UnitTargeted = 0 " +
            "for i = 1, 20 do local unit = 'nameplate'..i " +
                "if UnitExists(unit) then " +
                    "if UnitCanAttack('player', unit) then " +
                        "if GetNumGroupMembers() < 6 then " +
                            "for p = 1, 4 do local partymember = 'party'..p " +
                                "if UnitIsUnit(unit..'target', partymember) then UnitTargeted = p end " +
                            "end " +
                        "end " +
                        "if GetNumGroupMembers() > 5 then " +
                            "for r = 1, 40 do local raidmember = 'raid'..r " +
                                "if UnitIsUnit(unit..'target', raidmember) then UnitTargeted = r end " +
                            "end " +
                        "end " +
                        "if UnitIsUnit(unit..'target', 'player') then UnitTargeted = 5 end " +
                    "else UnitTargeted = 0 " +
                    "end " +
                "end " +
            "end " +
            "return UnitTargeted");

            CustomFunctions.Add("SpellstealCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Spellsteal','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType,_,_,_,isStealable  = UnitAura('mouseover', y) if debuffType == 'Magic' and isStealable == true then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("SpellstealCheckTarget", "local markcheck = 0; if UnitExists('target') and UnitIsDead('target') ~= true and UnitAffectingCombat('target') and IsSpellInRange('Spellsteal','target') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType,_,_,_,isStealable  = UnitAura('target', y) if debuffType == 'Magic' and isStealable == true then markcheck = markcheck + 2 end end return markcheck end return 0");

        }
        #endregion

        public override void LoadSettings()
        {
            Settings.Add(new Setting("Misc"));
            Settings.Add(new Setting("Debug:", false));
            Settings.Add(new Setting("Game Client Language", new List<string>()
            {
                "English",
                "Deutsch",
                "Español",
                "Français",
                "Italiano",
                "Português Brasileiro",
                "Русский",
                "한국어",
                "简体中文"
            }, "English"));
            Settings.Add(new Setting(""));
            Settings.Add(new Setting("Race:", m_RaceList, "bloodelf"));
            Settings.Add(new Setting("Ingame World Latency:", 1, 200, 50));
            Settings.Add(new Setting(" "));
            Settings.Add(new Setting("Use Trinkets on CD, dont wait for Hekili:", false));
            Settings.Add(new Setting("Auto Healthstone @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Kicks/Interrupts"));
            Settings.Add(new Setting("Randomize Kicks:", false));
            Settings.Add(new Setting("Kick at milliseconds remaining", 50, 1500, 500));
            Settings.Add(new Setting("Kick channels after milliseconds", 50, 1500, 500));
            Settings.Add(new Setting("General"));
            Settings.Add(new Setting("Auto Start Combat:", true));
            Settings.Add(new Setting("Arcane Intellect Out of Combat:", true));
            Settings.Add(new Setting("Auto Spellsteal Target:", true));
            Settings.Add(new Setting("Auto Spellsteal Mouseover:", true));
            Settings.Add(new Setting("Don't Spellsteal during Combustion:", true));
            Settings.Add(new Setting("Auto Ice Block @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Auto Alter Time @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Blazing Barrier @ HP%", 0, 100, 90));
            Settings.Add(new Setting("Auto Greater Invisibility @ HP%", 0, 100, 35));
            Settings.Add(new Setting("Ring of Frost Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Meteor Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Flamestrike Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Always Cast Flamestrike @ Cursor during Rotation", false));
            Settings.Add(new Setting("    "));

        }

        public override void Initialize()
        {
            #region Get Addon Name
            if (Aimsharp.GetAddonName().Length >= 5)
            {
                FiveLetters = Aimsharp.GetAddonName().Substring(0, 5);
            }
            #endregion

            if (GetCheckBox("Debug:") == true)
            {
                Aimsharp.DebugMode();
            }


            Aimsharp.Latency = GetSlider("Ingame World Latency:");
            Aimsharp.QuickDelay = 50;
            Aimsharp.SlowDelay = 150;

            Aimsharp.PrintMessage("Kanetos PVE - Evoker Devastation", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.Red);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.Brown);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/evoker/devastation/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);

            Language = GetDropDown("Game Client Language");

            #region Racial Spells
            if (GetDropDown("Race:") == "draenei")
            {
                Spellbook.Add(GiftOfTheNaaru_SpellName(Language)); //28880
            }

            if (GetDropDown("Race:") == "dwarf")
            {
                Spellbook.Add(Stoneform_SpellName(Language)); //20594
            }

            if (GetDropDown("Race:") == "gnome")
            {
                Spellbook.Add(EscapeArtist_SpellName(Language)); //20589
            }

            if (GetDropDown("Race:") == "human")
            {
                Spellbook.Add(WillToSurvive_SpellName(Language)); //59752
            }

            if (GetDropDown("Race:") == "lightforgeddraenei")
            {
                Spellbook.Add(LightsJudgment_SpellName(Language)); //255647
            }

            if (GetDropDown("Race:") == "darkirondwarf")
            {
                Spellbook.Add(Fireblood_SpellName(Language)); //265221
            }

            if (GetDropDown("Race:") == "goblin")
            {
                Spellbook.Add(RocketBarrage_SpellName(Language)); //69041
            }

            if (GetDropDown("Race:") == "tauren")
            {
                Spellbook.Add(WarStomp_SpellName(Language)); //20549
            }

            if (GetDropDown("Race:") == "troll")
            {
                Spellbook.Add(Berserking_SpellName(Language)); //26297
            }

            if (GetDropDown("Race:") == "scourge")
            {
                Spellbook.Add(WillOfTheForsaken_SpellName(Language)); //7744
            }

            if (GetDropDown("Race:") == "nightborne")
            {
                Spellbook.Add(ArcanePulse_SpellName(Language)); //260364
            }

            if (GetDropDown("Race:") == "highmountaintauren")
            {
                Spellbook.Add(BullRush_SpellName(Language)); //255654
            }

            if (GetDropDown("Race:") == "magharorc")
            {
                Spellbook.Add(AncestralCall_SpellName(Language)); //274738
            }

            if (GetDropDown("Race:") == "vulpera")
            {
                Spellbook.Add(BagOfTricks_SpellName(Language)); //312411
            }

            if (GetDropDown("Race:") == "orc")
            {
                Spellbook.Add(BloodFury_SpellName(Language)); //20572, 33702, 33697
            }

            if (GetDropDown("Race:") == "bloodelf")
            {
                Spellbook.Add(ArcaneTorrent_SpellName(Language)); //28730, 25046, 50613, 69179, 80483, 129597
            }

            if (GetDropDown("Race:") == "nightelf")
            {
                Spellbook.Add(Shadowmeld_SpellName(Language)); //58984
            }
            #endregion

            #region Reinitialize Lists
            m_DebuffsList = new List<string> {  };
            m_BuffsList = new List<string> { };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language), };
            m_SpellBook = new List<string> {
                AzureStrike_SpellName(Language), //362969
                BlessingoftheBronze_SpellName(Language), //364342
                CauterizingFlame_SpellName(Language), //374251
                DeepBreath_SpellName(Language), //357210
                Disintegrate_SpellName(Language), //356995
                Dragonrage_SpellName(Language), //375087
                EmeraldBlossom_SpellName(Language), //355913
                EternitySurge_SpellName(Language), //382411
                Expunge_SpellName(Language), //365585
                FireBreath_SpellName(Language), //382266
                Firestorm_SpellName(Language), //368847
                Hover_SpellName(Language), //358267
                Landslide_SpellName(Language), //358385
                LivingFlame_SpellName(Language), //361469
                ObsidianRoar_SpellName(Language), //372048
                ObsidianScales_SpellName(Language), //363916
                Pyre_SpellName(Language), //357211
                Quell_SpellName(Language), //351338
                RenewingBlaze_SpellName(Language), //374348
                ShatteringStar_SpellName(Language), //370452
                SleepWalk_SpellName(Language), //360806
                TailSwipe_SpellName(Language), //368970
                TimeSpiral_SpellName(Language), //374968
                TiptheScales_SpellName(Language), //370553
                Unravel_SpellName(Language), //368432
                WingBuffet_SpellName(Language), //357214
                Zephyr_SpellName(Language), //374227

            };
            #endregion

            InitializeMacros();

            InitializeSpells();

            InitializeCustomLUAFunctions();
        }

        public override bool CombatTick()
        {
            #region Declarations
            int SpellID1 = Aimsharp.CustomFunction("HekiliID1");
            int CooldownsToggle = Aimsharp.CustomFunction("CooldownsToggleCheck");
            int Wait = Aimsharp.CustomFunction("HekiliWait");
            int Enemies = Aimsharp.CustomFunction("HekiliEnemies");
            int TargetingGroup = Aimsharp.CustomFunction("GroupTargets");

            bool NoInterrupts = Aimsharp.IsCustomCodeOn("NoInterrupts");
            bool NoDecurse = Aimsharp.IsCustomCodeOn("NoDecurse");
            bool NoCycle = Aimsharp.IsCustomCodeOn("NoCycle");
            bool NoSpellsteal = Aimsharp.IsCustomCodeOn("NoSpellsteal");

            bool Debug = GetCheckBox("Debug:") == true;
            bool UseTrinketsCD = GetCheckBox("Use Trinkets on CD, dont wait for Hekili:") == true;

            bool IsInterruptable = Aimsharp.IsInterruptable("target");
            int CastingRemaining = Aimsharp.CastingRemaining("target");
            int CastingElapsed = Aimsharp.CastingElapsed("target");
            bool IsChanneling = Aimsharp.IsChanneling("target");
            int KickValue = GetSlider("Kick at milliseconds remaining");
            int KickChannelsAfter = GetSlider("Kick channels after milliseconds");

            bool Enemy = Aimsharp.TargetIsEnemy();
            int EnemiesInMelee = Aimsharp.EnemiesInMelee();
            bool Moving = Aimsharp.PlayerIsMoving();
            int PlayerHP = Aimsharp.Health("player");

            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());
            #endregion

            #region SpellQueueWindow
            if (Aimsharp.CustomFunction("GetSpellQueueWindow") != (Aimsharp.Latency + 100))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Setting SQW to: " + (Aimsharp.Latency + 100), Color.Purple);
                }
                Aimsharp.Cast("SetSpellQueueCvar");
            }
            #endregion

            #region Above Pause Logic
            if (SpellID1 == 108853 && Aimsharp.CanCast(FireBlast_SpellName(Language), "target", true, false) && Aimsharp.CustomFunction("HekiliWait") <= 200)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fire Blast - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(FireBlast_SpellName(Language), true);
                return true;
            }

            if (SpellID1 == 190319 && Aimsharp.CanCast(Combustion_SpellName(Language), "player", false, false) && Aimsharp.CustomFunction("HekiliWait") <= 200)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Combustion - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(Combustion_SpellName(Language), true);
                return true;
            }

            //Cancel Evocation
            if (Aimsharp.HasBuff(Evocation_SpellName(Language), "player", true) && Aimsharp.Power("player") == 100)
            {
                Aimsharp.StopCasting();
                return true;
            }

            if (Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn(Polymorph_SpellName(Language)))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Polymorph Queue", Color.Purple);
                }
                Aimsharp.Cast("PolymorphOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 2120 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn(Flamestrike_SpellName(Language)))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flamestrike Queue", Color.Purple);
                }
                Aimsharp.Cast("FlamestrikeOff");
                return true;
            }
            #endregion

            #region Pause Checks
            if (Aimsharp.CastingID("player") > 0 || Aimsharp.IsChanneling("player"))
            {
                return false;
            }

            if (Aimsharp.CustomFunction("IsTargeting") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("DoorofShadows") && Aimsharp.SpellCooldown(DoorOfShadows_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("RingofFrost") && Aimsharp.SpellCooldown(RingOfFrost_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn(Flamestrike_SpellName(Language)) && Aimsharp.SpellCooldown(Flamestrike_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn(Meteor_SpellName(Language)) && Aimsharp.SpellCooldown(Meteor_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Interrupts
            if (!NoInterrupts && (Aimsharp.UnitID("target") != 168105 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))) && (Aimsharp.UnitID("target") != 157571 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))))
            {
                int KickValueRandom;
                int KickChannelsAfterRandom;
                if (GetCheckBox("Randomize Kicks:"))
                {
                    KickValueRandom = KickValue + GetRandomNumber(200, 500);
                    KickChannelsAfterRandom = KickChannelsAfter + GetRandomNumber(200, 500);
                }
                else
                {
                    KickValueRandom = KickValue;
                    KickChannelsAfterRandom = KickChannelsAfter;
                }
                if (Aimsharp.CanCast(Counterspell_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Counterspell_SpellName(Language), true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast(Counterspell_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Counterspell_SpellName(Language), true);
                        return true;
                    }
                }
            }
            #endregion

            #region Auto Spells and Items
            //Auto Healthstone
            if (Aimsharp.CanUseItem(Healthstone_SpellName(Language), false) && Aimsharp.ItemCooldown(Healthstone_SpellName(Language)) == 0)
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Healthstone @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Healthstone - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Healthstone @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("UseHealthstone");
                    return true;
                }
            }

            //Auto Ice Block
            if (Aimsharp.CanCast(IceBlock_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Ice Block @ HP%"))
                {
                    Aimsharp.Cast(IceBlock_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Ice Block - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Ice Block @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Alter Time
            if (Aimsharp.CanCast(AlterTime_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Alter Time @ HP%"))
                {
                    Aimsharp.Cast(AlterTime_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Alter Time - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Alter Time @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Greater Invisibility
            if (Aimsharp.CanCast(GreaterInvisibility_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Greater Invisibility @ HP%"))
                {
                    Aimsharp.Cast(GreaterInvisibility_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Greater Invisibility - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Greater Invisibility @ HP%"), Color.Black);
                    }
                    return true;
                }
            }

            //Auto Blazing Barrier
            if (Aimsharp.CanCast(BlazingBarrier_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Blazing Barrier @ HP%"))
                {
                    Aimsharp.Cast(BlazingBarrier_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Blazing Barrier - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Blazing Barrier @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Spellsteal Mouseover
            if (!NoSpellsteal && Aimsharp.CanCast(Spellsteal_SpellName(Language), "mouseover", true, true) && (!GetCheckBox("Don't Spellsteal during Combustion:") || GetCheckBox("Don't Spellsteal during Combustion:") && !Aimsharp.HasBuff(Combustion_SpellName(Language), "player", true)))
            {
                if (GetCheckBox("Auto Spellsteal Mouseover:") && Aimsharp.CustomFunction("SpellstealCheckMouseover") == 3)
                {
                    Aimsharp.Cast("SpellstealMO");
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Spellsteal on Mouseover", Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Spellsteal Target
            if (!NoSpellsteal && Aimsharp.CanCast(Spellsteal_SpellName(Language), "target", true, true) && (!GetCheckBox("Don't Spellsteal during Combustion:") || GetCheckBox("Don't Spellsteal during Combustion:") && !Aimsharp.HasBuff(Combustion_SpellName(Language), "player", true)))
            {
                if (GetCheckBox("Auto Spellsteal Target:") && Aimsharp.CustomFunction("SpellstealCheckTarget") == 3)
                {
                    Aimsharp.Cast(Spellsteal_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Spellsteal on Target", Color.Purple);
                    }
                    return true;
                }
            }
            #endregion

            #region Queues
            bool Polymorph = Aimsharp.IsCustomCodeOn(Polymorph_SpellName(Language));
            if ((Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Polymorph)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Polymorph Queue", Color.Purple);
                }
                Aimsharp.Cast("PolymorphOff");
                return true;
            }

            if (Polymorph && Aimsharp.CanCast(Polymorph_SpellName(Language), "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Polymorph - Queue", Color.Purple);
                }
                Aimsharp.Cast("PolymorphMO");
                return true;
            }

            bool ArcaneExplosion = Aimsharp.IsCustomCodeOn("ArcaneExplosion");
            if (ArcaneExplosion && Aimsharp.CanCast(ArcaneExplosion_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Arcane Explosion - Queue", Color.Purple);
                }
                Aimsharp.Cast(ArcaneExplosion_SpellName(Language));
                return true;
            }

            bool DoorofShadows = Aimsharp.IsCustomCodeOn("DoorofShadows");
            if ((Aimsharp.SpellCooldown(DoorOfShadows_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && DoorofShadows)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Door of Shadows Queue", Color.Purple);
                }
                Aimsharp.Cast("DoorofShadowsOff");
                return true;
            }

            if (DoorofShadows && Aimsharp.CanCast(DoorOfShadows_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Door of Shadows - Queue", Color.Purple);
                }
                Aimsharp.Cast(DoorOfShadows_SpellName(Language));
                return true;
            }

            //Queue Ring of Frost
            string RingofFrostCast = GetDropDown("Ring of Frost Cast:");
            bool RingofFrost = Aimsharp.IsCustomCodeOn("RingofFrost");
            if ((Aimsharp.SpellCooldown(RingOfFrost_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && RingofFrost)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Ring of Frost Queue", Color.Purple);
                }
                Aimsharp.Cast("RingofFrostOff");
                return true;
            }

            if (RingofFrost && Aimsharp.CanCast(RingOfFrost_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (RingofFrostCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Frost - " + RingofFrostCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(RingOfFrost_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Frost - " + RingofFrostCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofFrostP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Frost - " + RingofFrostCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofFrostC");
                        return true;
                }
            }

            //Queue Meteor
            string MeteorCast = GetDropDown("Meteor Cast:");
            bool Meteor = Aimsharp.IsCustomCodeOn(Meteor_SpellName(Language));
            if ((Aimsharp.SpellCooldown(Meteor_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && Meteor)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Meteor Queue", Color.Purple);
                }
                Aimsharp.Cast("MeteorOff");
                return true;
            }

            if (Meteor && Aimsharp.CanCast(Meteor_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (MeteorCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Meteor_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MeteorP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MeteorC");
                        return true;
                }
            }

            //Queue Flamestrike
            string FlamestrikeCast = GetDropDown("Flamestrike Cast:");
            bool Flamestrike = Aimsharp.IsCustomCodeOn(Flamestrike_SpellName(Language));
            if ((Aimsharp.SpellCooldown(Flamestrike_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving || Aimsharp.LastCast() == Flamestrike_SpellName(Language)) && Flamestrike)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flamestrike Queue", Color.Purple);
                }
                Aimsharp.Cast("FlamestrikeOff");
                return true;
            }

            if (Flamestrike && Aimsharp.CanCast(Flamestrike_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (FlamestrikeCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike - " + FlamestrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Flamestrike_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike - " + FlamestrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FlamestrikeP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike - " + FlamestrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FlamestrikeC");
                        return true;
                }
            }
            #endregion

            #region Remove Curse
            if (!NoDecurse && Aimsharp.CustomFunction("CurseCheck") > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != RemoveCurse_SpellName(Language))
            {
                PartyDict.Clear();
                PartyDict.Add("player", Aimsharp.Health("player"));

                var partysize = Aimsharp.GroupSize();
                for (int i = 1; i < partysize; i++)
                {
                    var partyunit = ("party" + i);
                    if (Aimsharp.Health(partyunit) > 0 && Aimsharp.Range(partyunit) <= 40)
                    {
                        PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                    }
                }

                int states = Aimsharp.CustomFunction("CurseCheck");
                CleansePlayers target;

                int KickTimer = GetRandomNumber(200,800);

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast(RemoveCurse_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
                    {
                        if (!UnitFocus(unit.Key))
                        {
                            Aimsharp.Cast("FOC_" + unit.Key, true);
                            return true;
                        }
                        else
                        {
                            if (UnitFocus(unit.Key))
                            {
                                System.Threading.Thread.Sleep(KickTimer);
                                Aimsharp.Cast("RC_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Remove Curse @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Auto Target
            //Hekili Cycle
            if (!NoCycle && Aimsharp.CustomFunction("HekiliCycle") == 1 && Enemies > 1)
            {
                System.Threading.Thread.Sleep(50);
                Aimsharp.Cast("TargetEnemy");
                System.Threading.Thread.Sleep(50);
                return true;
            }

            //Auto Target
            if (!NoCycle && (!Enemy || Enemy && !TargetAlive() || Enemy && !TargetInCombat) && (EnemiesInMelee > 0 || TargetingGroup > 0))
            {
                System.Threading.Thread.Sleep(50);
                Aimsharp.Cast("TargetEnemy");
                System.Threading.Thread.Sleep(50);
                return true;
            }
            #endregion

            if (Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat && Wait <= 200)
            {
                if (Aimsharp.Range("target") <= 40 && !Aimsharp.HasDebuff(Polymorph_SpellName(Language), "target", true) && !Polymorph && !ArcaneExplosion)
                {
                    #region Trinkets
                    if (CooldownsToggle == 1 && UseTrinketsCD && Aimsharp.CanUseTrinket(0))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Using Top Trinket on Cooldown", Color.Purple);
                        }
                        Aimsharp.Cast("TopTrinket");
                        return true;
                    }

                    if (CooldownsToggle == 2 && UseTrinketsCD && Aimsharp.CanUseTrinket(1))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Using Bot Trinket on Cooldown", Color.Purple);
                        }
                        Aimsharp.Cast("BotTrinket");
                        return true;
                    }

                    if (SpellID1 == 1 && Aimsharp.CanUseTrinket(0))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Using Top Trinket", Color.Purple);
                        }
                        Aimsharp.Cast("TopTrinket");
                        return true;
                    }

                    if (SpellID1 == 2 && Aimsharp.CanUseTrinket(1))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Using Bot Trinket", Color.Purple);
                        }
                        Aimsharp.Cast("BotTrinket");
                        return true;
                    }
                    #endregion

                    #region Racials
                    //Racials
                    if (SpellID1 == 28880 && Aimsharp.CanCast(GiftOfTheNaaru_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Gift of the Naaru - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(GiftOfTheNaaru_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 20594 && Aimsharp.CanCast(Stoneform_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Stoneform - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Stoneform_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 20589 && Aimsharp.CanCast(EscapeArtist_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Escape Artist - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(EscapeArtist_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 59752 && Aimsharp.CanCast(WillToSurvive_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Will to Survive - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WillToSurvive_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 255647 && Aimsharp.CanCast(LightsJudgment_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Light's Judgment - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(LightsJudgment_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 265221 && Aimsharp.CanCast(Fireblood_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fireblood - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Fireblood_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 69041 && Aimsharp.CanCast(RocketBarrage_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rocket Barrage - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RocketBarrage_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 20549 && Aimsharp.CanCast(WarStomp_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting War Stomp - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WarStomp_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 7744 && Aimsharp.CanCast(WillOfTheForsaken_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Will of the Forsaken - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WillOfTheForsaken_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 260364 && Aimsharp.CanCast(ArcanePulse_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Pulse - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ArcanePulse_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 255654 && Aimsharp.CanCast(BullRush_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bull Rush - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BullRush_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 312411 && Aimsharp.CanCast(BagOfTricks_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bag of Tricks - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BagOfTricks_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 20572 || SpellID1 == 33702 || SpellID1 == 33697) && Aimsharp.CanCast(BloodFury_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blood Fury - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BloodFury_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 26297 && Aimsharp.CanCast(Berserking_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Berserking - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Berserking_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 274738 && Aimsharp.CanCast(AncestralCall_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ancestral Call - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AncestralCall_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 28730 || SpellID1 == 25046 || SpellID1 == 50613 || SpellID1 == 69179 || SpellID1 == 80483 || SpellID1 == 129597) && Aimsharp.CanCast(ArcaneTorrent_SpellName(Language), "player", true, false))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Torrent - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ArcaneTorrent_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 58984 && Aimsharp.CanCast(Shadowmeld_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowmeld - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Shadowmeld_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Covenants
                    ///Covenants
                    if (SpellID1 == 307443 && Aimsharp.CanCast(RadiantSpark_SpellName(Language), "target", true, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Radiant Spark - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RadiantSpark_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 324220 && Aimsharp.CanCast(Deathborne_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Deathborne - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Deathborne_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 314791 || SpellID1 == 382440) && Aimsharp.CanCast(ShiftingPower_SpellName(Language), "player", false, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shifting Power - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ShiftingPower_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 314793 && Aimsharp.CanCast(MirrorsOfTorment_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mirrors of Torment - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(MirrorsOfTorment_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 324631 && Aimsharp.CanCast(Fleshcraft_SpellName(Language), "player", false, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fleshcraft - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Fleshcraft_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - No GCD
                    ///Class Spells
                    //Target - No GCD
                    if (SpellID1 == 2139 && Aimsharp.CanCast(Counterspell_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Counterspell- " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Counterspell_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    //Target - GCD
                    if (SpellID1 == 116 && Aimsharp.CanCast(Frostbolt_SpellName(Language), "target", true, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Frostbolt - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Frostbolt_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 118 && Aimsharp.CanCast(Polymorph_SpellName(Language), "target", true, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Polymorph - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Polymorph_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 383121 && Aimsharp.CanCast(MassPolymorph_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mass Polymorph - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(MassPolymorph_SpellName(Language));
                        return true;
                    }

                    if (!NoSpellsteal && SpellID1 == 30449 && Aimsharp.CanCast(Spellsteal_SpellName(Language), "target", true, true) && (!GetCheckBox("Don't Spellsteal during Combustion:") || GetCheckBox("Don't Spellsteal during Combustion:") && !Aimsharp.HasBuff(Combustion_SpellName(Language), "player", true)))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spellsteal - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Spellsteal_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    if (SpellID1 == 1449 && Aimsharp.CanCast(ArcaneExplosion_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Explosion - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ArcaneExplosion_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 1459 && Aimsharp.CanCast(ArcaneIntellect_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Intellect - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ArcaneIntellect_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 1953 || SpellID1 == 212653) && Aimsharp.CanCast(Blink_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blink - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Blink_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 120 && Aimsharp.CanCast(ConeOfCold_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cone of Cold - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(ConeOfCold_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 389713 && Aimsharp.CanCast(Displacement_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Displacement - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(Displacement_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 321358 && Aimsharp.CanCast(FocusMagic_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Focus Magic - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FocusMagic_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 122 && Aimsharp.CanCast(FrostNova_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Frost Nova - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FrostNova_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 66 && Aimsharp.CanCast(Invisibility_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Invisibility - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(Invisibility_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 45438 && Aimsharp.CanCast(IceBlock_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ice Block - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(IceBlock_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 108839 && Aimsharp.CanCast(IceFloes_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ice Floes - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(IceFloes_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 157997 && Aimsharp.CanCast(IceNova_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ice Nova - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(IceNova_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 55342 && Aimsharp.CanCast(MirrorImage_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mirror Image - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(MirrorImage_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 475 && Aimsharp.CanCast(RemoveCurse_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Remove Curse - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RemoveCurse_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 113724 && Aimsharp.CanCast(RingOfFrost_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Frost - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RingOfFrost_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 116011 && Aimsharp.CanCast(RuneOfPower_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rune of Power - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RuneOfPower_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 130 && Aimsharp.CanCast(SlowFall_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Slow Fall - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SlowFall_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 80353 && Aimsharp.CanCast(TimeWarp_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Time Warp - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TimeWarp_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Fire Spells - Player GCD
                    if (SpellID1 == 235313 && Aimsharp.CanCast(BlazingBarrier_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blazing Barrier - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BlazingBarrier_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 190319 && Aimsharp.CanCast(Combustion_SpellName(Language), "player", false, false))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Combustion - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Combustion_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 31661 && Aimsharp.CanCast(DragonsBreath_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Dragon's Breath - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DragonsBreath_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 157981 && Aimsharp.CanCast(BlastWave_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blast Wave - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BlastWave_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 2120 && Aimsharp.CanCast(Flamestrike_SpellName(Language), "player", false, true) && (Aimsharp.CustomFunction("FlamestrikeMouseover") == 1 || GetCheckBox("Always Cast Flamestrike @ Cursor during Rotation") || Aimsharp.IsCustomCodeOn("FlamestrikeCursor")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("FlamestrikeC");
                        return true;
                    }
                    else if (SpellID1 == 2120 && Aimsharp.CanCast(Flamestrike_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Flamestrike_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 153561 && Aimsharp.CanCast(Meteor_SpellName(Language), "player", false, true))
                    {
                        switch (MeteorCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast(Meteor_SpellName(Language));
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("MeteorP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("MeteorC");
                                return true;
                        }
                    }
                    #endregion

                    #region Fire Spells - Target GCD
                    if (SpellID1 == 44457 && Aimsharp.CanCast(LivingBomb_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Living Bomb - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(LivingBomb_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 108853 && Aimsharp.CanCast(FireBlast_SpellName(Language), "target", true, false))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fire Blast - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FireBlast_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 257541 && Aimsharp.CanCast(PhoenixFlames_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Phoenix Flames - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(PhoenixFlames_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 11366 && Aimsharp.CanCast(Pyroblast_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Pyroblast - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Pyroblast_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 2948 && Aimsharp.CanCast(Scorch_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Scorch - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Scorch_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 133 && Aimsharp.CanCast(Fireball_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fireball - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Fireball_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 321358 && Aimsharp.CanCast(FocusMagic_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Focus Magic - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FocusMagic_SpellName(Language));
                        return true;
                    }
                    #endregion
                }
            }
            return false;
        }

        public override bool OutOfCombatTick()
        {
            #region Declarations
            int SpellID1 = Aimsharp.CustomFunction("HekiliID1");

            bool Debug = GetCheckBox("Debug:") == true;
            int PhialCount = Aimsharp.CustomFunction("PhialCount");
            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());
            bool Moving = Aimsharp.PlayerIsMoving();
            bool AIOOC = GetCheckBox("Arcane Intellect Out of Combat:");
            #endregion

            #region SpellQueueWindow
            if (Aimsharp.CustomFunction("GetSpellQueueWindow") != (Aimsharp.Latency + 100))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Setting SQW to: " + (Aimsharp.Latency + 100), Color.Purple);
                }
                Aimsharp.Cast("SetSpellQueueCvar");
            }
            #endregion

            #region Above Pause Logic
            if (Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn(Polymorph_SpellName(Language)))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Polymorph Queue", Color.Purple);
                }
                Aimsharp.Cast("PolymorphOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 2120 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn(Flamestrike_SpellName(Language)))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flamestrike Queue", Color.Purple);
                }
                Aimsharp.Cast("FlamestrikeOff");
                return true;
            }
            #endregion

            #region Pause Checks
            if (Aimsharp.CastingID("player") > 0 || Aimsharp.IsChanneling("player"))
            {
                return false;
            }

            if (Aimsharp.CustomFunction("IsTargeting") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("DoorofShadows") && Aimsharp.SpellCooldown(DoorOfShadows_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("RingofFrost") && Aimsharp.SpellCooldown(RingOfFrost_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn(Flamestrike_SpellName(Language)) && Aimsharp.SpellCooldown(Flamestrike_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn(Meteor_SpellName(Language)) && Aimsharp.SpellCooldown(Meteor_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            bool Polymorph = Aimsharp.IsCustomCodeOn(Polymorph_SpellName(Language));
            if ((Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Polymorph)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Polymorph Queue", Color.Purple);
                }
                Aimsharp.Cast("PolymorphOff");
                return true;
            }

            if (Polymorph && Aimsharp.CanCast(Polymorph_SpellName(Language), "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Polymorph - Queue", Color.Purple);
                }
                Aimsharp.Cast("PolymorphMO");
                return true;
            }

            bool ArcaneExplosion = Aimsharp.IsCustomCodeOn("ArcaneExplosion");
            if (ArcaneExplosion && Aimsharp.CanCast(ArcaneExplosion_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Arcane Explosion - Queue", Color.Purple);
                }
                Aimsharp.Cast(ArcaneExplosion_SpellName(Language));
                return true;
            }

            bool DoorofShadows = Aimsharp.IsCustomCodeOn("DoorofShadows");
            if ((Aimsharp.SpellCooldown(DoorOfShadows_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && DoorofShadows)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Door of Shadows Queue", Color.Purple);
                }
                Aimsharp.Cast("DoorofShadowsOff");
                return true;
            }

            if (DoorofShadows && Aimsharp.CanCast(DoorOfShadows_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Door of Shadows - Queue", Color.Purple);
                }
                Aimsharp.Cast(DoorOfShadows_SpellName(Language));
                return true;
            }

            //Queue Ring of Frost
            string RingofFrostCast = GetDropDown("Ring of Frost Cast:");
            bool RingofFrost = Aimsharp.IsCustomCodeOn("RingofFrost");
            if ((Aimsharp.SpellCooldown(RingOfFrost_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && RingofFrost)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Ring of Frost Queue", Color.Purple);
                }
                Aimsharp.Cast("RingofFrostOff");
                return true;
            }

            if (RingofFrost && Aimsharp.CanCast(RingOfFrost_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (RingofFrostCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Frost - " + RingofFrostCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(RingOfFrost_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Frost - " + RingofFrostCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofFrostP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Frost - " + RingofFrostCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofFrostC");
                        return true;
                }
            }

            //Queue Meteor
            string MeteorCast = GetDropDown("Meteor Cast:");
            bool Meteor = Aimsharp.IsCustomCodeOn(Meteor_SpellName(Language));
            if ((Aimsharp.SpellCooldown(Meteor_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && Meteor)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Meteor Queue", Color.Purple);
                }
                Aimsharp.Cast("MeteorOff");
                return true;
            }

            if (Meteor && Aimsharp.CanCast(Meteor_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (MeteorCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Meteor_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MeteorP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MeteorC");
                        return true;
                }
            }

            //Queue Flamestrike
            string FlamestrikeCast = GetDropDown("Flamestrike Cast:");
            bool Flamestrike = Aimsharp.IsCustomCodeOn(Flamestrike_SpellName(Language));
            if ((Aimsharp.SpellCooldown(Flamestrike_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving || Aimsharp.LastCast() == Flamestrike_SpellName(Language)) && Flamestrike)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flamestrike Queue", Color.Purple);
                }
                Aimsharp.Cast("FlamestrikeOff");
                return true;
            }

            if (Flamestrike && Aimsharp.CanCast(Flamestrike_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (FlamestrikeCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike - " + FlamestrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Flamestrike_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike - " + FlamestrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FlamestrikeP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike - " + FlamestrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FlamestrikeC");
                        return true;
                }
            }
            #endregion

            #region Out of Combat Spells
            if (SpellID1 == 1459 && Aimsharp.CanCast(ArcaneIntellect_SpellName(Language), "player", false, true) && AIOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Arcane Intellect (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(ArcaneIntellect_SpellName(Language));
                return true;
            }

            if (Aimsharp.CanCast(ArcaneIntellect_SpellName(Language), "player", false, true) && !Aimsharp.HasBuff(ArcaneIntellect_SpellName(Language), "player", true) && AIOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Arcane Intellect (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(ArcaneIntellect_SpellName(Language));
                return true;
            }

            if (SpellID1 == 324631 && Aimsharp.CanCast(Fleshcraft_SpellName(Language), "player", false, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fleshcraft - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(Fleshcraft_SpellName(Language));
                return true;
            }

            //Auto Call Steward
            if (PhialCount <= 0 && Aimsharp.CanCast(SummonSteward_SpellName(Language), "player") && Aimsharp.GetMapID() != 2286 && Aimsharp.GetMapID() != 1666 && Aimsharp.GetMapID() != 1667 && Aimsharp.GetMapID() != 1668 && Aimsharp.CastingID("player") == 0)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Summon Steward due to Phial Count being: " + PhialCount, Color.Purple);
                }
                Aimsharp.Cast(SummonSteward_SpellName(Language));
                return true;
            }
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 40 && TargetInCombat && !Aimsharp.HasDebuff(Polymorph_SpellName(Language), "target", true) && !Polymorph)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Starting Combat from Out of Combat", Color.Purple);
                }
                return CombatTick();
            }
            #endregion

            return false;
        }

    }
}