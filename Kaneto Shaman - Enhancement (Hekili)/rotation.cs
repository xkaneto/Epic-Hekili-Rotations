using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class KanetoShamanEnhancementHekili : Rotation
    {
        private static string Language = "English";

        #region SpellFunctions
        #endregion

        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle", "NoDecurse", "EarthbindTotem", "WindRushTotem", "CapacitorTotem", "TremorTotem", "Hex", "EarthElemental", "VesperTotem", "FaeTransfusion", "DoorofShadows" };
        private List<string> m_DebuffsList = new List<string> { };
        private List<string> m_BuffsList = new List<string> { "Maelstrom Weapon", };
        private List<string> m_BloodlustBuffsList = new List<string> { "Bloodlust", "Heroism", "Time Warp", "Primal Rage", "Drums of Rage" };
        private List<string> m_ItemsList = new List<string> { "Healthstone" };

        private List<string> m_SpellBook_General = new List<string> {
            //Covenants
            "Vesper Totem", //324386
            "Fae Transfusion", //328923
            "Chain Harvest", //320674
            "Primordial Wave", //326059

            //Interrupt
            "Wind Shear", //57994

            //General
            "Earthbind Totem", //2484
            "Lightning Shield", //192106
            "Flame Shock", //188389
            "Primal Strike", //73899
            "Flametongue Weapon", //318038
            "Ghost Wolf", //2645
            "Healing Surge", //8004
            "Lightning Bolt", //188196
            "Frost Shock", //196840
            "Chain Heal", //1064
            "Earth Elemental", //198103
            "Capacitor Totem", //192058
            "Purge", //370
            "Chain Lightning", //188443
            "Hex", //51514
            "Healing Stream Totem", //5394
            "Astral Shift", //108271
            "Tremor Totem", //8143
            "Heroism", //32182
            "Bloodlust", //2825

            //Enhancement
            "Windfury Weapon", //33757
            "Lava Lash", //60103
            "Feral Spirit", //51533
            "Cleanse Spirit", //51886
            "Crash Lightning", //187874
            "Stormstrike", //17364
            "Spirit Walk", //58875
            "Windfury Totem", //8512
            "Elemental Blast", //117014
            "Ice Strike", //342240
            "Earth Shield", //974
            "Fire Nova", //333974
            "Feral Lunge", //196884
            "Wind Rush Totem", //192077
            "Stormkeeper", //320137
            "Sundering", //197214
            "Earthen Spike", //188089
            "Ascendance", //114051
            "Windstrike", //115356

            "Fleshcraft", "Summon Steward", "Door of Shadows",

        };

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

        public bool UnitBelowThreshold(int check)
        {
            if (Aimsharp.Health("player") > 0 && Aimsharp.Health("player") <= check ||
                Aimsharp.Health("party1") > 0 && Aimsharp.Health("party1") <= check ||
                Aimsharp.Health("party2") > 0 && Aimsharp.Health("party2") <= check ||
                Aimsharp.Health("party3") > 0 && Aimsharp.Health("party3") <= check ||
                Aimsharp.Health("party4") > 0 && Aimsharp.Health("party4") <= check)
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
            Macros.Add("Healthstone", "/use Healthstone");

            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + (Aimsharp.Latency + 100));

            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");
            Macros.Add("CS_FOC", "/cast [@focus] Cleanse Spirit");
            Macros.Add("HS_FOC", "/cast [@focus] Healing Surge");

            //Queues
            Macros.Add("EarthbindTotemOff", "/" + FiveLetters + " EarthbindTotem");
            Macros.Add("EarthbindTotemC", "/cast [@cursor] Earthbind Totem");
            Macros.Add("EarthbindTotemP", "/cast [@player] Earthbind Totem");

            Macros.Add("CapacitorTotemOff", "/" + FiveLetters + " CapacitorTotem");
            Macros.Add("CapacitorTotemC", "/cast [@cursor] Capacitor Totem");
            Macros.Add("CapacitorTotemP", "/cast [@player] Capacitor Totem");

            Macros.Add("WindRushTotemOff", "/" + FiveLetters + " WindRushTotem");
            Macros.Add("WindRushTotemC", "/cast [@cursor] Wind Rush Totem");
            Macros.Add("WindRushTotemP", "/cast [@player] Wind Rush Totem");

            Macros.Add("VesperTotemOff", "/" + FiveLetters + " VesperTotem");
            Macros.Add("VesperTotemC", "/cast [@cursor] Vesper Totem");
            Macros.Add("VesperTotemP", "/cast [@player] Vesper Totem");

            Macros.Add("FaeTransfusionOff", "/" + FiveLetters + " FaeTransfusion");
            Macros.Add("FaeTransfusionC", "/cast [@cursor] Fae Transfusion");
            Macros.Add("FaeTransfusionP", "/cast [@player] Fae Transfusion");

            Macros.Add("HexOff", "/" + FiveLetters + " Hex");
            Macros.Add("HexMO", "/cast [@mouseover] Hex");

            Macros.Add("EarthElementalOff", "/" + FiveLetters + " EarthElemental");
            Macros.Add("TremorTotemOff", "/" + FiveLetters + " TremorTotem");

            Macros.Add("PurgeMO", "/cast [@mouseover] Purge");

        }

        private void InitializeSpells()
        {
            foreach (string Spell in m_SpellBook_General)
                Spellbook.Add(Spell);

            foreach (string Buff in m_BuffsList)
                Buffs.Add(Buff);

            foreach (string Buff in m_BloodlustBuffsList)
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
            CustomFunctions.Add("HekiliID1", "local loading, finished = IsAddOnLoaded(\"Hekili\") \r\nif loading == true and finished == true then \r\n    local id=Hekili_GetRecommendedAbility(\"Primary\",1)\r\n\tif id ~= nil then\r\n\t\r\n    if id<0 then \r\n\t    local spell = Hekili.Class.abilities[id]\r\n\t    if spell ~= nil and spell.item ~= nil then \r\n\t    \tid=spell.item\r\n\t\t    local topTrinketLink = GetInventoryItemLink(\"player\",13)\r\n\t\t    local bottomTrinketLink = GetInventoryItemLink(\"player\",14)\r\n\t\t    if topTrinketLink  ~= nil then\r\n                local trinketid = GetItemInfoInstant(topTrinketLink)\r\n                if trinketid ~= nil then\r\n\t\t\t        if trinketid == id then\r\n\t\t\t\t        return 1\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t\t    if bottomTrinketLink ~= nil then\r\n                local trinketid = GetItemInfoInstant(bottomTrinketLink)\r\n                if trinketid ~= nil then\r\n    \t\t\t    if trinketid == id then\r\n\t    \t\t\t    return 2\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t    end \r\n    end\r\n    return id\r\nend\r\nend\r\nreturn 0");

            CustomFunctions.Add("PhialCount", "local count = GetItemCount(177278) if count ~= nil then return count end return 0");

            CustomFunctions.Add("GetSpellQueueWindow", "local sqw = GetCVar(\"SpellQueueWindow\"); if sqw ~= nil then return tonumber(sqw); end return 0");

            CustomFunctions.Add("CooldownsToggleCheck", "local loading, finished = IsAddOnLoaded(\"Hekili\") if loading == true and finished == true then local cooldowns = Hekili:GetToggleState(\"cooldowns\") if cooldowns == true then return 1 else if cooldowns == false then return 2 end end end return 0");

            CustomFunctions.Add("UnitIsDead", "if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == true then return 1 end; if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == false then return 2 end; return 0");

            CustomFunctions.Add("HekiliWait", "if HekiliDisplayPrimary.Recommendations[1].wait ~= nil and HekiliDisplayPrimary.Recommendations[1].wait * 1000 > 0 then return math.floor(HekiliDisplayPrimary.Recommendations[1].wait * 1000) end return 0");

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("TargetIsMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitExists('target') and UnitIsDead('target') ~= true and UnitIsUnit('mouseover', 'target') then return 1 end; return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");

            CustomFunctions.Add("CycleNotEnabled", "local cycle = 0 if Hekili.State.settings.spec.cycle == true then cycle = 1 else if Hekili.State.settings.spec.cycle == false then cycle = 2 end end return cycle");

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

            CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
            "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
            "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
            "\nreturn foc");

            CustomFunctions.Add("PurgeCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Purge','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType,_,_,_  = UnitBuff('mouseover', y) if debuffType == 'Magic' then markcheck = markcheck + 2 end end return markcheck end return 0");

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
            Settings.Add(new Setting("Race:", m_RaceList, "orc"));
            Settings.Add(new Setting("Ingame World Latency:", 1, 200, 50));
            Settings.Add(new Setting(" "));
            Settings.Add(new Setting("Use Trinkets on CD, dont wait for Hekili:", false));
            Settings.Add(new Setting("Auto Healthstone @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Auto Phial of Serenity @ HP%", 0, 100, 35));
            Settings.Add(new Setting("Kicks/Interrupts"));
            Settings.Add(new Setting("Kick at milliseconds remaining", 50, 1500, 500));
            Settings.Add(new Setting("Kick channels after milliseconds", 50, 1500, 500));
            Settings.Add(new Setting("General"));
            Settings.Add(new Setting("Auto Start Combat:", true));
            Settings.Add(new Setting("Weapon Imbue Out of Combat:", true));
            Settings.Add(new Setting("Lightning Shield Out of Combat:", true));
            //Settings.Add(new Setting("Auto Purge Target:", true));
            Settings.Add(new Setting("Auto Purge Mouseover:", true));
            Settings.Add(new Setting("Auto Astral Shift @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Auto Healing Surge @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Auto Healing Stream Totem @ HP%", 0, 100, 50));
            Settings.Add(new Setting("Totem Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Covenant Cast:", m_CastingList, "Manual"));
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
            Aimsharp.SlowDelay = 75;

            Aimsharp.PrintMessage("Kanetos PVE - Shaman Enhancement", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.Red);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.Red);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/shaman/enhancement/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoDecurse - Disables Decurse", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Hex - Casts Hex @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " EarthbindTotem - Casts Earthbind Totem @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " CapacitorTotem - Casts Capacitor Totem @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " WindRushTotem - Casts Wind Rush Totem @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " TremorTotem - Casts Tremor Totem @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " EarthElemental - Casts Earth Elemental @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " VesperTotem - Casts Vesper Totem @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FaeTransfusion - Casts Fae Transfusion @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " DoorofShadows - Casts Door of Shadows @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);

            Language = GetDropDown("Game Client Language");

            #region Racial Spells
            if (GetDropDown("Race:") == "draenei")
            {
                Spellbook.Add("Gift of the Naaru"); //28880
            }

            if (GetDropDown("Race:") == "dwarf")
            {
                Spellbook.Add("Stoneform"); //20594
            }

            if (GetDropDown("Race:") == "gnome")
            {
                Spellbook.Add("Escape Artist"); //20589
            }

            if (GetDropDown("Race:") == "human")
            {
                Spellbook.Add("Will to Survive"); //59752
            }

            if (GetDropDown("Race:") == "lightforgeddraenei")
            {
                Spellbook.Add("Light's Judgment"); //255647
            }

            if (GetDropDown("Race:") == "darkirondwarf")
            {
                Spellbook.Add("Fireblood"); //265221
            }

            if (GetDropDown("Race:") == "goblin")
            {
                Spellbook.Add("Rocket Barrage"); //69041
            }

            if (GetDropDown("Race:") == "tauren")
            {
                Spellbook.Add("War Stomp"); //20549
            }

            if (GetDropDown("Race:") == "troll")
            {
                Spellbook.Add("Berserking"); //26297
            }

            if (GetDropDown("Race:") == "scourge")
            {
                Spellbook.Add("Will of the Forsaken"); //7744
            }

            if (GetDropDown("Race:") == "nightborne")
            {
                Spellbook.Add("Arcane Pulse"); //260364
            }

            if (GetDropDown("Race:") == "highmountaintauren")
            {
                Spellbook.Add("Bull Rush"); //255654
            }

            if (GetDropDown("Race:") == "magharorc")
            {
                Spellbook.Add("Ancestral Call"); //274738
            }

            if (GetDropDown("Race:") == "vulpera")
            {
                Spellbook.Add("Bag of Tricks"); //312411
            }

            if (GetDropDown("Race:") == "orc")
            {
                Spellbook.Add("Blood Fury"); //20572, 33702, 33697
            }

            if (GetDropDown("Race:") == "bloodelf")
            {
                Spellbook.Add("Arcane Torrent"); //28730, 25046, 50613, 69179, 80483, 129597
            }

            if (GetDropDown("Race:") == "nightelf")
            {
                Spellbook.Add("Shadowmeld"); //58984
            }
            #endregion

            Totems.Add("Healing Stream Totem");

            InitializeMacros();

            InitializeSpells();

            InitializeCustomLUAFunctions();
        }

        public override bool CombatTick()
        {
            #region Declarations
            int SpellID1 = Aimsharp.CustomFunction("HekiliID1");
            int Wait = Aimsharp.CustomFunction("HekiliWait");

            bool NoInterrupts = Aimsharp.IsCustomCodeOn("NoInterrupts");
            bool NoCycle = Aimsharp.IsCustomCodeOn("NoCycle");
            bool NoDecurse = Aimsharp.IsCustomCodeOn("NoDecurse");

            bool Debug = GetCheckBox("Debug:") == true;
            bool UseTrinketsCD = GetCheckBox("Use Trinkets on CD, dont wait for Hekili:") == true;
            int CooldownsToggle = Aimsharp.CustomFunction("CooldownsToggleCheck");

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
            bool MeleeRange = Aimsharp.Range("target") <= 3;
            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());

            int AstralShiftHP = GetSlider("Auto Astral Shift @ HP%");
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

            #region Above Pause Checks
            if (Aimsharp.CastingID("player") == 51514 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Hex"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Hex Queue", Color.Purple);
                }
                Aimsharp.Cast("HexOff");
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

            if (Aimsharp.IsCustomCodeOn("EarthbindTotem") && Aimsharp.SpellCooldown("Earthbind Totem") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("CapacitorTotem") && Aimsharp.SpellCooldown("Capacitor Totem") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("WindRushTotem") && Aimsharp.SpellCooldown("Wind Rush Totem") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("VesperTotem") && Aimsharp.SpellCooldown("Vesper Totem") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("FaeTransfusion") && Aimsharp.SpellCooldown("Fae Transfusion") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("DoorofShadows") && Aimsharp.SpellCooldown("Door of Shadows") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Interrupts
            if (!NoInterrupts && (Aimsharp.UnitID("target") != 168105 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))) && (Aimsharp.UnitID("target") != 157571 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))))
            {
                if (Aimsharp.CanCast("Wind Shear", "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValue)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Wind Shear", true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast("Wind Shear", "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfter)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Wind Shear", true);
                        return true;
                    }
                }
            }
            #endregion

            #region Auto Spells and Items
            //Auto Healthstone
            if (Aimsharp.CanUseItem("Healthstone", false) && Aimsharp.ItemCooldown("Healthstone") == 0)
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Healthstone @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Healthstone - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Healthstone @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("Healthstone");
                    return true;
                }
            }

            //Auto Astral Shift
            if (PlayerHP <= AstralShiftHP && Aimsharp.CanCast("Astral Shift", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Astral Shift - Player HP% " + PlayerHP + " due to setting being on HP% " + AstralShiftHP, Color.Purple);
                }
                Aimsharp.Cast("Astral Shift", true);
                return true;
            }

            //Auto Purge Mouseover
            if (Aimsharp.CanCast("Purge", "mouseover", true, true))
            {
                if (GetCheckBox("Auto Purge Mouseover:") && Aimsharp.CustomFunction("PurgeCheckMouseover") == 3)
                {
                    Aimsharp.Cast("PurgeMO");
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Purge on Mouseover", Color.Purple);
                    }
                    return true;
                }
            }

            #region Maelstrom Healing Surge
            if (UnitBelowThreshold(GetSlider("Auto Healing Surge @ HP%")) && Aimsharp.BuffStacks("Maelstrom Weapon", "player", true) >= 5)
            {
                PartyDict.Clear();
                PartyDict.Add("player", Aimsharp.Health("player"));

                var partysize = Aimsharp.GroupSize();
                if (partysize <= 5)
                {
                    for (int i = 1; i < partysize; i++)
                    {
                        var partyunit = ("party" + i);
                        if (Aimsharp.Health(partyunit) > 0 && Aimsharp.Range(partyunit) <= 40)
                        {
                            PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                        }
                    }
                }

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    if (Aimsharp.CanCast("Healing Surge", unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && Aimsharp.Health(unit.Key) <= GetSlider("Auto Healing Surge @ HP%"))
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
                                Aimsharp.Cast("HS_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Healing Surge @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Healing Totem
            if (UnitBelowThreshold(GetSlider("Auto Healing Stream Totem @ HP%")) && Aimsharp.TotemRemaining("Healing Stream Totem") <= 0)
            {
                PartyDict.Clear();
                PartyDict.Add("player", Aimsharp.Health("player"));

                var partysize = Aimsharp.GroupSize();
                if (partysize <= 5)
                {
                    for (int i = 1; i < partysize; i++)
                    {
                        var partyunit = ("party" + i);
                        if (Aimsharp.Health(partyunit) > 0 && Aimsharp.Range(partyunit) <= 40)
                        {
                            PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                        }
                    }
                }

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    if (Aimsharp.CanCast("Healing Stream Totem", "player", false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && Aimsharp.Health(unit.Key) <= GetSlider("Auto Healing Stream Totem @ HP%"))
                    {
                        Aimsharp.Cast("Healing Stream Totem");
                        return true;
                    }
                }
            }
            #endregion
            #endregion

            #region Queues
            bool TremorTotem = Aimsharp.IsCustomCodeOn("TremorTotem");
            if (Aimsharp.SpellCooldown("Tremor Totem") - Aimsharp.GCD() > 2000 && TremorTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Tremor Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("TremorTotemOff");
                return true;
            }

            if (TremorTotem && Aimsharp.CanCast("Tremor Totem", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Tremor Totem - Queue", Color.Purple);
                }
                Aimsharp.Cast("Tremor Totem");
                return true;
            }

            bool EarthElemental = Aimsharp.IsCustomCodeOn("EarthElemental");
            if (Aimsharp.SpellCooldown("Earth Elemental") - Aimsharp.GCD() > 2000 && EarthElemental)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Earth Elemental Queue", Color.Purple);
                }
                Aimsharp.Cast("EarthElementalOff");
                return true;
            }

            if (EarthElemental && Aimsharp.CanCast("Earth Elemental", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Earth Elemental - Queue", Color.Purple);
                }
                Aimsharp.Cast("Earth Elemental");
                return true;
            }

            bool Hex = Aimsharp.IsCustomCodeOn("Hex");
            if ((Aimsharp.SpellCooldown("Hex") - Aimsharp.GCD() > 2000 || Moving) && Hex)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Hex Queue", Color.Purple);
                }
                Aimsharp.Cast("HexOff");
                return true;
            }

            if (Hex && Aimsharp.CanCast("Hex", "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Hex - Queue", Color.Purple);
                }
                Aimsharp.Cast("HexMO");
                return true;
            }

            string CovenantCast = GetDropDown("Covenant Cast:");
            bool VesperTotem = Aimsharp.IsCustomCodeOn("VesperTotem");
            if (Aimsharp.SpellCooldown("Vesper Totem") - Aimsharp.GCD() > 2000 && VesperTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Vesper Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("VesperTotemOff");
                return true;
            }

            if (VesperTotem && Aimsharp.CanCast("Vesper Totem", "player", false, true))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Vesper Totem");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("VesperTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("VesperTotemP");
                        return true;
                }
            }

            bool FaeTransfusion = Aimsharp.IsCustomCodeOn("FaeTransfusion");
            if (Aimsharp.SpellCooldown("Fae Transfusion") - Aimsharp.GCD() > 2000 && FaeTransfusion)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fae Transfusion Queue", Color.Purple);
                }
                Aimsharp.Cast("FaeTransfusionOff");
                return true;
            }

            if (FaeTransfusion && Aimsharp.CanCast("Fae Transfusion", "player", false, true))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Fae Transfusion");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FaeTransfusionC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FaeTransfusionP");
                        return true;
                }
            }

            string TotemCast = GetDropDown("Totem Cast:");
            bool EarthbindTotem = Aimsharp.IsCustomCodeOn("EarthbindTotem");
            if (Aimsharp.SpellCooldown("Earthbind Totem") - Aimsharp.GCD() > 2000 && EarthbindTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Earthbind Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("EarthbindTotemOff");
                return true;
            }

            if (EarthbindTotem && Aimsharp.CanCast("Earthbind Totem", "player", false, true))
            {
                switch (TotemCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthbind Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Earthbind Totem");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthbind Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("EarthbindTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthbind Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("EarthbindTotemP");
                        return true;
                }
            }

            bool CapacitorTotem = Aimsharp.IsCustomCodeOn("CapacitorTotem");
            if (Aimsharp.SpellCooldown("Capacitor Totem") - Aimsharp.GCD() > 2000 && CapacitorTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Capacitor Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("CapacitorTotemOff");
                return true;
            }

            if (CapacitorTotem && Aimsharp.CanCast("Capacitor Totem", "player", false, true))
            {
                switch (TotemCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Capacitor Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Capacitor Totem");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Capacitor Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CapacitorTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Capacitor Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CapacitorTotemP");
                        return true;
                }
            }

            bool WindRushTotem = Aimsharp.IsCustomCodeOn("WindRushTotem");
            if (Aimsharp.SpellCooldown("Wind Rush Totem") - Aimsharp.GCD() > 2000 && WindRushTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Wind Rush Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("WindRushTotemOff");
                return true;
            }

            if (WindRushTotem && Aimsharp.CanCast("Wind Rush Totem", "player", false, true))
            {
                switch (TotemCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wind Rush Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Wind Rush Totem");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wind Rush Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WindRushTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wind Rush Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WindRushTotemP");
                        return true;
                }
            }

            bool DoorofShadows = Aimsharp.IsCustomCodeOn("DoorofShadows");
            if ((Aimsharp.SpellCooldown("Door of Shadows") - Aimsharp.GCD() > 2000 || Moving) && DoorofShadows)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Door of Shadows Queue", Color.Purple);
                }
                Aimsharp.Cast("DoorofShadowsOff");
                return true;
            }

            if (DoorofShadows && Aimsharp.CanCast("Door of Shadows", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Door of Shadows - Queue", Color.Purple);
                }
                Aimsharp.Cast("Door of Shadows");
                return true;
            }
            #endregion

            #region Remove Curse
            if (!NoDecurse && Aimsharp.CustomFunction("CurseCheck") > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != "Cleanse Spirit")
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

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast("Cleanse Spirit", unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
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
                                Aimsharp.Cast("CS_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Cleanse Spirit @ " + unit.Key + " - " + unit.Value, Color.Purple);
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
            if (!NoCycle && Aimsharp.CustomFunction("CycleNotEnabled") == 1 && Aimsharp.CustomFunction("HekiliCycle") == 1 && EnemiesInMelee > 1)
            {
                System.Threading.Thread.Sleep(50);
                Aimsharp.Cast("TargetEnemy");
                System.Threading.Thread.Sleep(50);
                return true;
            }

            //Auto Target
            if (!NoCycle && (!Enemy || Enemy && !TargetAlive() || Enemy && !TargetInCombat) && EnemiesInMelee > 0)
            {
                System.Threading.Thread.Sleep(50);
                Aimsharp.Cast("TargetEnemy");
                System.Threading.Thread.Sleep(50);
                return true;
            }
            #endregion

            if (Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                #region Mouseover Spells

                #endregion

                if (Wait <= 200)
                {
                    #region Trinkets
                    //Trinkets
                    if (CooldownsToggle == 1 && UseTrinketsCD && Aimsharp.CanUseTrinket(0) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Using Top Trinket on Cooldown", Color.Purple);
                        }
                        Aimsharp.Cast("TopTrinket");
                        return true;
                    }

                    if (CooldownsToggle == 2 && UseTrinketsCD && Aimsharp.CanUseTrinket(1) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Using Bot Trinket on Cooldown", Color.Purple);
                        }
                        Aimsharp.Cast("BotTrinket");
                        return true;
                    }

                    if (SpellID1 == 1 && Aimsharp.CanUseTrinket(0) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Using Top Trinket", Color.Purple);
                        }
                        Aimsharp.Cast("TopTrinket");
                        return true;
                    }

                    if (SpellID1 == 2 && Aimsharp.CanUseTrinket(1) && MeleeRange)
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
                    if (SpellID1 == 28880 && Aimsharp.CanCast("Gift of the Naaru", "player", true, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Gift of the Naaru - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Gift of the Naaru");
                        return true;
                    }

                    if (SpellID1 == 20594 && Aimsharp.CanCast("Stoneform", "player", true, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Stoneform - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Stoneform");
                        return true;
                    }

                    if (SpellID1 == 20589 && Aimsharp.CanCast("Escape Artist", "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Escape Artist - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Escape Artist");
                        return true;
                    }

                    if (SpellID1 == 59752 && Aimsharp.CanCast("Will to Survive", "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Will to Survive - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Will to Survive");
                        return true;
                    }

                    if (SpellID1 == 255647 && Aimsharp.CanCast("Light's Judgment", "player", true, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Light's Judgment - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Light's Judgment");
                        return true;
                    }

                    if (SpellID1 == 265221 && Aimsharp.CanCast("Fireblood", "player", true, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fireblood - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Fireblood");
                        return true;
                    }

                    if (SpellID1 == 69041 && Aimsharp.CanCast("Rocket Barrage", "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rocket Barrage - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Rocket Barrage");
                        return true;
                    }

                    if (SpellID1 == 20549 && Aimsharp.CanCast("War Stomp", "player", true, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting War Stomp - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("War Stomp");
                        return true;
                    }

                    if (SpellID1 == 7744 && Aimsharp.CanCast("Will of the Forsaken", "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Will of the Forsaken - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Will of the Forsaken");
                        return true;
                    }

                    if (SpellID1 == 260364 && Aimsharp.CanCast("Arcane Pulse", "player", true, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Pulse - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Arcane Pulse");
                        return true;
                    }

                    if (SpellID1 == 255654 && Aimsharp.CanCast("Bull Rush", "player", true, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bull Rush - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Bull Rush");
                        return true;
                    }

                    if (SpellID1 == 312411 && Aimsharp.CanCast("Bag of Tricks", "player", true, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bag of Tricks - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Bag of Tricks");
                        return true;
                    }

                    if ((SpellID1 == 20572 || SpellID1 == 33702 || SpellID1 == 33697) && Aimsharp.CanCast("Blood Fury", "player", true, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blood Fury - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Blood Fury");
                        return true;
                    }

                    if (SpellID1 == 26297 && Aimsharp.CanCast("Berserking", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Berserking - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Berserking");
                        return true;
                    }

                    if (SpellID1 == 274738 && Aimsharp.CanCast("Ancestral Call", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ancestral Call - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Ancestral Call");
                        return true;
                    }

                    if ((SpellID1 == 28730 || SpellID1 == 25046 || SpellID1 == 50613 || SpellID1 == 69179 || SpellID1 == 80483 || SpellID1 == 129597) && Aimsharp.CanCast("Arcane Torrent", "player", true, false) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Torrent - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Arcane Torrent");
                        return true;
                    }

                    if (SpellID1 == 58984 && Aimsharp.CanCast("Shadowmeld", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowmeld - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Shadowmeld");
                        return true;
                    }
                    #endregion

                    #region Covenants
                    //Covenants
                    if (SpellID1 == 324386 && Aimsharp.CanCast("Vesper Totem", "player", false, true) && MeleeRange)
                    {
                        switch (CovenantCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("Vesper Totem");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("VesperTotemC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("VesperTotemP");
                                return true;
                        }
                    }

                    if (SpellID1 == 328923 && Aimsharp.CanCast("Fae Transfusion", "player", false, true) && MeleeRange)
                    {
                        switch (CovenantCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("Fae Transfusion");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("FaeTransfusionC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("FaeTransfusionP");
                                return true;
                        }
                    }

                    if (SpellID1 == 320674 && Aimsharp.CanCast("Chain Harvest", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Chain Harvest - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Chain Harvest");
                        return true;
                    }

                    if (SpellID1 == 326059 && Aimsharp.CanCast("Primordial Wave", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Primordial Wave - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Primordial Wave");
                        return true;
                    }

                    if (SpellID1 == 324631 && Aimsharp.CanCast("Fleshcraft", "player", false, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fleshcraft - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Fleshcraft");
                        return true;
                    }
                    #endregion

                    #region General Spells - NoGCD
                    //Class Spells
                    //Instant [GCD FREE]
                    if (SpellID1 == 1766 && Aimsharp.CanCast("Wind Shear", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wind Shear - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Wind Shear", true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    if (SpellID1 == 198103 && Aimsharp.CanCast("Earth Elemental", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earth Elemental - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Earth Elemental");
                        return true;
                    }

                    if (SpellID1 == 33757 && Aimsharp.CanCast("Windfury Weapon", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Windfury Weapon - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Windfury Weapon");
                        return true;
                    }

                    if (SpellID1 == 2645 && Aimsharp.CanCast("Ghost Wolf", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ghost Wolf - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Ghost Wolf");
                        return true;
                    }

                    if (SpellID1 == 318038 && Aimsharp.CanCast("Flametongue Weapon", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flametongue Weapon - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Flametongue Weapon");
                        return true;
                    }

                    if (SpellID1 == 192106 && Aimsharp.CanCast("Lightning Shield", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Lightning Shield - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Lightning Shield");
                        return true;
                    }

                    if (SpellID1 == 108271 && Aimsharp.CanCast("Astral Shift", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Astral Shift - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Astral Shift");
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    if (SpellID1 == 188443 && Aimsharp.CanCast("Chain Lightning", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Chain Lightning - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Chain Lightning");
                        return true;
                    }

                    if (SpellID1 == 196840 && Aimsharp.CanCast("Frost Shock", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Frost Shock - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Frost Shock");
                        return true;
                    }

                    if (SpellID1 == 188196 && Aimsharp.CanCast("Lightning Bolt", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Lightning Bolt - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Lightning Bolt");
                        return true;
                    }

                    if (SpellID1 == 73899 && Aimsharp.CanCast("Primal Strike", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Primal Strike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Primal Strike");
                        return true;
                    }

                    if (SpellID1 == 188389 && Aimsharp.CanCast("Flame Shock", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flame Shock - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Flame Shock");
                        return true;
                    }
                    #endregion

                    #region Enhancement Spells - Player GCD
                    if (SpellID1 == 114051 && Aimsharp.CanCast("Ascendance", "player", false, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ascendance - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Ascendance");
                        return true;
                    }

                    if (SpellID1 == 197214 && Aimsharp.CanCast("Sundering", "player", false, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sundering - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Sundering");
                        return true;
                    }

                    if (SpellID1 == 333974 && Aimsharp.CanCast("Fire Nova", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fire Nova - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Fire Nova");
                        return true;
                    }

                    if (SpellID1 == 320137 && Aimsharp.CanCast("Stormkeeper", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Stormkeeper - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Stormkeeper");
                        return true;
                    }

                    if (SpellID1 == 8512 && Aimsharp.CanCast("Windfury Totem", "player", false, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Windfury Totem - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Windfury Totem");
                        return true;
                    }

                    if (SpellID1 == 51533 && Aimsharp.CanCast("Feral Spirit", "player", false, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Feral Spirit - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Feral Spirit");
                        return true;
                    }

                    if (SpellID1 == 187874 && Aimsharp.CanCast("Crash Lightning", "player", false, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Crash Lightning - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Crash Lightning");
                        return true;
                    }
                    #endregion

                    #region Enhancement Spells - Target GCD
                    if (SpellID1 == 115356 && Aimsharp.CanCast("Windstrike", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Windstrike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Windstrike");
                        return true;
                    }

                    if (SpellID1 == 342240 && Aimsharp.CanCast("Ice Strike", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ice Strike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Ice Strike");
                        return true;
                    }

                    if (SpellID1 == 117014 && Aimsharp.CanCast("Elemental Blast", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Elemental Blast - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Elemental Blast");
                        return true;
                    }

                    if (SpellID1 == 188089 && Aimsharp.CanCast("Earthen Spike", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthen Spike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Earthen Spike");
                        return true;
                    }

                    if (SpellID1 == 196884 && Aimsharp.CanCast("Feral Lunge", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Feral Lunge - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Feral Lunge");
                        return true;
                    }

                    if (SpellID1 == 17364 && Aimsharp.CanCast("Stormstrike", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Stormstrike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Stormstrike");
                        return true;
                    }

                    if (SpellID1 == 60103 && Aimsharp.CanCast("Lava Lash", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Lava Lash - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Lava Lash");
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
            int PhialCount = Aimsharp.CustomFunction("PhialCount");
            bool Debug = GetCheckBox("Debug:") == true;
            bool Moving = Aimsharp.PlayerIsMoving();
            bool Enemy = Aimsharp.TargetIsEnemy();
            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());
            bool ImbueWeaponOOC = GetCheckBox("Weapon Imbue Out of Combat:");
            bool LightningShieldOOC = GetCheckBox("Lightning Shield Out of Combat:");
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

            #region Above Pause Checks
            if (Aimsharp.CastingID("player") == 51514 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Hex"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Hex Queue", Color.Purple);
                }
                Aimsharp.Cast("HexOff");
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

            if (Aimsharp.IsCustomCodeOn("EarthbindTotem") && Aimsharp.SpellCooldown("Earthbind Totem") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("CapacitorTotem") && Aimsharp.SpellCooldown("Capacitor Totem") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("WindRushTotem") && Aimsharp.SpellCooldown("Wind Rush Totem") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("VesperTotem") && Aimsharp.SpellCooldown("Vesper Totem") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("FaeTransfusion") && Aimsharp.SpellCooldown("Fae Transfusion") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("DoorofShadows") && Aimsharp.SpellCooldown("Door of Shadows") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            bool TremorTotem = Aimsharp.IsCustomCodeOn("TremorTotem");
            if (Aimsharp.SpellCooldown("Tremor Totem") - Aimsharp.GCD() > 2000 && TremorTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Tremor Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("TremorTotemOff");
                return true;
            }

            if (TremorTotem && Aimsharp.CanCast("Tremor Totem", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Tremor Totem - Queue", Color.Purple);
                }
                Aimsharp.Cast("Tremor Totem");
                return true;
            }

            bool EarthElemental = Aimsharp.IsCustomCodeOn("EarthElemental");
            if (Aimsharp.SpellCooldown("Earth Elemental") - Aimsharp.GCD() > 2000 && EarthElemental)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Earth Elemental Queue", Color.Purple);
                }
                Aimsharp.Cast("EarthElementalOff");
                return true;
            }

            if (EarthElemental && Aimsharp.CanCast("Earth Elemental", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Earth Elemental - Queue", Color.Purple);
                }
                Aimsharp.Cast("Earth Elemental");
                return true;
            }

            bool Hex = Aimsharp.IsCustomCodeOn("Hex");
            if ((Aimsharp.SpellCooldown("Hex") - Aimsharp.GCD() > 2000 || Moving) && Hex)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Hex Queue", Color.Purple);
                }
                Aimsharp.Cast("HexOff");
                return true;
            }

            if (Hex && Aimsharp.CanCast("Hex", "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Hex - Queue", Color.Purple);
                }
                Aimsharp.Cast("HexMO");
                return true;
            }

            string CovenantCast = GetDropDown("Covenant Cast:");
            bool VesperTotem = Aimsharp.IsCustomCodeOn("VesperTotem");
            if (Aimsharp.SpellCooldown("Vesper Totem") - Aimsharp.GCD() > 2000 && VesperTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Vesper Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("VesperTotemOff");
                return true;
            }

            if (VesperTotem && Aimsharp.CanCast("Vesper Totem", "player", false, true))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Vesper Totem");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("VesperTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("VesperTotemP");
                        return true;
                }
            }

            bool FaeTransfusion = Aimsharp.IsCustomCodeOn("FaeTransfusion");
            if (Aimsharp.SpellCooldown("Fae Transfusion") - Aimsharp.GCD() > 2000 && FaeTransfusion)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fae Transfusion Queue", Color.Purple);
                }
                Aimsharp.Cast("FaeTransfusionOff");
                return true;
            }

            if (FaeTransfusion && Aimsharp.CanCast("Fae Transfusion", "player", false, true))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Fae Transfusion");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FaeTransfusionC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FaeTransfusionP");
                        return true;
                }
            }

            string TotemCast = GetDropDown("Totem Cast:");
            bool EarthbindTotem = Aimsharp.IsCustomCodeOn("EarthbindTotem");
            if (Aimsharp.SpellCooldown("Earthbind Totem") - Aimsharp.GCD() > 2000 && EarthbindTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Earthbind Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("EarthbindTotemOff");
                return true;
            }

            if (EarthbindTotem && Aimsharp.CanCast("Earthbind Totem", "player", false, true))
            {
                switch (TotemCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthbind Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Earthbind Totem");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthbind Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("EarthbindTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthbind Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("EarthbindTotemP");
                        return true;
                }
            }

            bool CapacitorTotem = Aimsharp.IsCustomCodeOn("CapacitorTotem");
            if (Aimsharp.SpellCooldown("Capacitor Totem") - Aimsharp.GCD() > 2000 && CapacitorTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Capacitor Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("CapacitorTotemOff");
                return true;
            }

            if (CapacitorTotem && Aimsharp.CanCast("Capacitor Totem", "player", false, true))
            {
                switch (TotemCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Capacitor Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Capacitor Totem");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Capacitor Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CapacitorTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Capacitor Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CapacitorTotemP");
                        return true;
                }
            }

            bool WindRushTotem = Aimsharp.IsCustomCodeOn("WindRushTotem");
            if (Aimsharp.SpellCooldown("Wind Rush Totem") - Aimsharp.GCD() > 2000 && WindRushTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Wind Rush Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("WindRushTotemOff");
                return true;
            }

            if (WindRushTotem && Aimsharp.CanCast("Wind Rush Totem", "player", false, true))
            {
                switch (TotemCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wind Rush Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Wind Rush Totem");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wind Rush Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WindRushTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wind Rush Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WindRushTotemP");
                        return true;
                }
            }

            bool DoorofShadows = Aimsharp.IsCustomCodeOn("DoorofShadows");
            if ((Aimsharp.SpellCooldown("Door of Shadows") - Aimsharp.GCD() > 2000 || Moving) && DoorofShadows)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Door of Shadows Queue", Color.Purple);
                }
                Aimsharp.Cast("DoorofShadowsOff");
                return true;
            }

            if (DoorofShadows && Aimsharp.CanCast("Door of Shadows", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Door of Shadows - Queue", Color.Purple);
                }
                Aimsharp.Cast("Door of Shadows");
                return true;
            }
            #endregion

            #region Out of Combat Spells
            if (SpellID1 == 318038 && Aimsharp.CanCast("Flametongue Weapon", "player", false, true) && ImbueWeaponOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Flametongue Weapon - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Flametongue Weapon");
                return true;
            }

            if (SpellID1 == 33757 && Aimsharp.CanCast("Windfury Weapon", "player", false, true) && ImbueWeaponOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Windfury Weapon - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Windfury Weapon");
                return true;
            }

            if (SpellID1 == 192106 && Aimsharp.CanCast("Lightning Shield", "player", false, true) && LightningShieldOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Lightning Shield - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Lightning Shield");
                return true;
            }

            //Auto Fleshcraft
            if (SpellID1 == 324631 && Aimsharp.CanCast("Fleshcraft", "player", false, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fleshcraft - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Fleshcraft");
                return true;
            }

            //Auto Call Steward
            if (PhialCount <= 0 && Aimsharp.CanCast("Summon Steward", "player") && !Aimsharp.HasBuff("Stealth", "player", true) && Aimsharp.GetMapID() != 2286 && Aimsharp.GetMapID() != 1666 && Aimsharp.GetMapID() != 1667 && Aimsharp.GetMapID() != 1668 && Aimsharp.CastingID("player") == 0)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Summon Steward due to Phial Count being: " + PhialCount, Color.Purple);
                }
                Aimsharp.Cast("Summon Steward");
                return true;
            }
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 10 && TargetInCombat)
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