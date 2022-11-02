using System.Linq;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class SnoogensPVEDruidFeral : Rotation
    {
        string FiveLetters;

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "MightyBash", "MassEntanglement", "NoDecurse", "Maim", "NoInterrupts", "NoCycle", "Rebirth", };
        private List<string> m_DebuffsList = new List<string> { "Rake", };
        private List<string> m_BuffsList = new List<string> { "Predatory Swiftness", "Prowl", };
        private List<string> m_BloodlustBuffsList = new List<string> { "Bloodlust", "Heroism", "Time Warp", "Primal Rage", "Drums of Rage" };
        private List<string> m_ItemsList = new List<string> { "Phial of Serenity", "Healthstone" };

        private List<string> m_SpellBook = new List<string> {
            //Covenants
            "Convoke the Spirits", "Adaptive Swarm", "Empower Bond", "Ravenous Frenzy",

            //Interrupt
            "Skull Bash",

            //General
            "Rake", "Shred", "Savage Roar", "Ferocious Bite", "Rip", "Tiger's Fury", "Berserk", "Rebirth",
            "Survival Instincts", "Maim", "Renewal", "Mass Entanglement", "Swipe", "Thrash", "Incarnation: King of the Jungle", "Brutal Slash",
            "Feral Frenzy", "Heart of the Wild", "Remove Corruption", "Summon Steward", "Mighty Bash", "Wild Charge", "Tiger Dash", "Prowl",
            "Cat Form", "Primal Wrath", "Moonkin Form", "Sunfire", "Barkskin", "Regrowth", "Starsurge", "Moonfire", "Fleshcraft", "Soothe",

        };

        private List<string> m_RaceList = new List<string> { "human", "dwarf", "nightelf", "gnome", "draenei", "pandaren", "orc", "scourge", "tauren", "troll", "bloodelf", "goblin", "worgen", "voidelf", "lightforgeddraenei", "highmountaintauren", "nightborne", "zandalaritroll", "magharorc", "kultiran", "darkirondwarf", "vulpera", "mechagnome" };

        private List<int> Torghast_InnerFlame = new List<int> { 258935, 258938, 329422, 329423, };

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

        public Dictionary<string, int> PartyDict = new Dictionary<string, int>() { };

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
        #endregion

        #region Misc Checks
        public bool UnitFocus(string unit)
        {
            if (Aimsharp.CustomFunction("UnitIsFocus") == 1 && unit == "party1" || Aimsharp.CustomFunction("UnitIsFocus") == 2 && unit == "party2" || Aimsharp.CustomFunction("UnitIsFocus") == 3 && unit == "party3" || Aimsharp.CustomFunction("UnitIsFocus") == 4 && unit == "party4" || Aimsharp.CustomFunction("UnitIsFocus") == 5 && unit == "player")
                return true;

            return false;
        }

        private bool TargetAlive()
        {
            if (Aimsharp.CustomFunction("UnitIsDead") == 2)
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
        private void InitializeSettings()
        {
            FiveLetters = GetString("First 5 Letters of the Addon:");
        }

        private void InitializeMacros()
        {
            //Auto Target
            Macros.Add("TargetEnemy", "/targetenemy");

            //Trinket
            Macros.Add("TopTrinket", "/use 13");
            Macros.Add("BotTrinket", "/use 14");
            Macros.Add("Weapon", "/use 16");

            //Healthstone
            Macros.Add("Healthstone", "/use Healthstone");

            //Phial
            Macros.Add("PhialofSerenity", "/use Phial of Serenity");

            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");
            Macros.Add("RC_FOC", "/cast [@focus] Remove Corruption");

            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + (Aimsharp.Latency + 100));

            //Mouseover Macros
            Macros.Add("RakeMO", "/cast [@mouseover] Rake");
            Macros.Add("SootheMO", "/cast [@mouseover] Soothe");
            Macros.Add("RebirthMO", "/cast [@mouseover] Rebirth");

            //Queues
            Macros.Add("MightyBashOff", "/" + FiveLetters + " MightyBash");
            Macros.Add("MassEntanglementOff", "/" + FiveLetters + " MassEntanglement");
            Macros.Add("MaimOff", "/" + FiveLetters + " Maim");
            Macros.Add("RebirthOff", "/" + FiveLetters + " Rebirth");

        }

        private void InitializeSpells()
        {
            foreach (string Spell in m_SpellBook)
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
            CustomFunctions.Add("HekiliID1", "local loading, finished = IsAddOnLoaded(\"Hekili\") \r\nif loading == true and finished == true then \r\n    local id=Hekili_GetRecommendedAbility(\"Primary\",1)\r\n\tif id ~= nil then\r\n\t\r\n    if id<0 then \r\n\t    local spell = Hekili.Class.abilities[id]\r\n\t    if spell ~= nil and spell.item ~= nil then \r\n\t    \tid=spell.item\r\n\t\t    local topTrinketLink = GetInventoryItemLink(\"player\",13)\r\n\t\t    local bottomTrinketLink = GetInventoryItemLink(\"player\",14)\r\n\t\t    local weaponLink = GetInventoryItemLink(\"player\",16)\r\n\t\t    if topTrinketLink  ~= nil then\r\n                local trinketid = GetItemInfoInstant(topTrinketLink)\r\n                if trinketid ~= nil then\r\n\t\t\t        if trinketid == id then\r\n\t\t\t\t        return 1\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t\t    if bottomTrinketLink ~= nil then\r\n                local trinketid = GetItemInfoInstant(bottomTrinketLink)\r\n                if trinketid ~= nil then\r\n    \t\t\t    if trinketid == id then\r\n\t    \t\t\t    return 2\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t\t    if weaponLink ~= nil then\r\n                local weaponid = GetItemInfoInstant(weaponLink)\r\n                if weaponid ~= nil then\r\n    \t\t\t    if weaponid == id then\r\n\t    \t\t\t    return 3\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t    end \r\n    end\r\n    return id\r\nend\r\nend\r\nreturn 0");

            CustomFunctions.Add("CursePoisonCheck", "local y=0; " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"player\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +1; end end " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +2; end end " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +4; end end " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +8; end end " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +16; end end " +
                "return y");

            CustomFunctions.Add("PhialCount", "local count = GetItemCount(177278) if count ~= nil then return count end return 0");

            CustomFunctions.Add("GetSpellQueueWindow", "local sqw = GetCVar(\"SpellQueueWindow\"); if sqw ~= nil then return tonumber(sqw); end return 0");

            CustomFunctions.Add("RakeDebuffCheck", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Rake','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,_,_,_,source  = UnitDebuff('mouseover', y) if name == 'Rake' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("EnrageBuffCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Soothe','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType  = UnitBuff('mouseover', y) if debuffType == '' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("EnrageBuffCheckTarget", "local markcheck = 0; if UnitExists('target') and UnitIsDead('target') ~= true and UnitAffectingCombat('target') and IsSpellInRange('Soothe','target') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType  = UnitBuff('target', y) if debuffType == '' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("CooldownsToggleCheck", "local loading, finished = IsAddOnLoaded(\"Hekili\") if loading == true and finished == true then local cooldowns = Hekili:GetToggleState(\"cooldowns\") if cooldowns == true then return 1 else if cooldowns == false then return 2 end end end return 0");
            
            CustomFunctions.Add("UnitIsDead", "if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == true then return 1 end; if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == false then return 2 end; return 0");

            CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
                "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
                "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
                "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
                "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
                "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
                "\nreturn foc");

            CustomFunctions.Add("HekiliWait", "if HekiliDisplayPrimary.Recommendations[1].wait ~= nil and HekiliDisplayPrimary.Recommendations[1].wait * 1000 > 0 then return math.floor(HekiliDisplayPrimary.Recommendations[1].wait * 1000) end return 0");

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("TargetIsMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitExists('target') and UnitIsDead('target') ~= true and UnitIsUnit('mouseover', 'target') then return 1 end; return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");

        }
        #endregion

        public override void LoadSettings()
        {
            Settings.Add(new Setting("First 5 Letters of the Addon:", "xxxxx"));
            Settings.Add(new Setting("Race:", m_RaceList, "nightelf"));
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
            Settings.Add(new Setting("Prowl Out of Combat:", true));
            Settings.Add(new Setting("Spread Rake with Mouseover:", false));
            Settings.Add(new Setting("Soothe Mouseover:", true));
            Settings.Add(new Setting("Soothe Target:", true));
            Settings.Add(new Setting("Maim Queue - Dont wait for Max CP", false));
            Settings.Add(new Setting("Auto Renewal @ HP%", 0, 100, 20));
            Settings.Add(new Setting("Auto Barkskin @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Auto Survival Instincts @ HP%", 0, 100, 35));
            Settings.Add(new Setting("Auto Regrowth @ HP%", 0, 100, 50));
            Settings.Add(new Setting("Misc"));
            Settings.Add(new Setting("Debug:", false));

        }

        public override void Initialize()
        {

            if (GetCheckBox("Debug:") == true)
            {
                Aimsharp.DebugMode();
            }

            Aimsharp.Latency = GetSlider("Ingame World Latency:");
            Aimsharp.QuickDelay = 150;
            Aimsharp.SlowDelay = 350;

            Aimsharp.PrintMessage("Snoogens PVE - Druid Feral", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon", Color.Red);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything", Color.Brown);
            Aimsharp.PrintMessage("Hekili > Toggles > Bind \"Cooldowns\" & \"Display Mode\"", Color.Brown);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx NoDecurse - Disables Decurse", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx MightyBash - Casts Mighty Bash @ Target on the next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx MassEntanglement - Casts Mass Entanglement @ Target on the next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx Maim - Casts Maim @ Target on the next GCD", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);

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

            InitializeSettings();

            InitializeMacros();

            InitializeSpells();

            InitializeCustomLUAFunctions();
        }

        public override bool CombatTick()
        {
            #region Declarations
            int SpellID1 = Aimsharp.CustomFunction("HekiliID1");
            int Wait = Aimsharp.CustomFunction("HekiliWait");
            bool Moving = Aimsharp.PlayerIsMoving();

            int CursePoisonCheck = Aimsharp.CustomFunction("CursePoisonCheck");
            int MarkDebuffMO = Aimsharp.CustomFunction("RakeDebuffCheck");
            int EnrageBuffMO = Aimsharp.CustomFunction("EnrageBuffCheckMouseover");
            int EnrageBuffTarget = Aimsharp.CustomFunction("EnrageBuffCheckTarget");
            int CooldownsToggle = Aimsharp.CustomFunction("CooldownsToggleCheck");

            bool NoDecurse = Aimsharp.IsCustomCodeOn("NoDecurse");
            bool NoInterrupts = Aimsharp.IsCustomCodeOn("NoInterrupts");
            bool NoCycle = Aimsharp.IsCustomCodeOn("NoCycle");
            bool MightyBash = Aimsharp.IsCustomCodeOn("MightyBash");
            bool MassEntanglement = Aimsharp.IsCustomCodeOn("MassEntanglement");

            bool Debug = GetCheckBox("Debug:") == true;
            bool MOMark = GetCheckBox("Spread Rake with Mouseover:") == true;
            bool MOSoothe = GetCheckBox("Soothe Mouseover:") == true;
            bool TargetSoothe = GetCheckBox("Soothe Target:") == true;
            bool UseTrinketsCD = GetCheckBox("Use Trinkets on CD, dont wait for Hekili:") == true;

            bool IsInterruptable = Aimsharp.IsInterruptable("target");
            int CastingRemaining = Aimsharp.CastingRemaining("target");
            int CastingElapsed = Aimsharp.CastingElapsed("target");
            bool IsChanneling = Aimsharp.IsChanneling("target");
            int KickValue = GetSlider("Kick at milliseconds remaining");
            int KickChannelsAfter = GetSlider("Kick channels after milliseconds");

            bool Enemy = Aimsharp.TargetIsEnemy();
            int EnemiesInMelee = Aimsharp.EnemiesInMelee();
            bool MeleeRange = Aimsharp.Range("target") <= 6;

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

            #region Pause Checks
            if (Aimsharp.CastingID("player") > 0 || Aimsharp.IsChanneling("player"))
            {
                return false;
            }

            if (Aimsharp.CustomFunction("IsTargeting") == 1)
            {
                return false;
            }
            #endregion

            #region Interrupts
            if (!NoInterrupts && (Aimsharp.UnitID("target") != 168105 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))) && (Aimsharp.UnitID("target") != 157571 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))))
            {
                if (Aimsharp.CanCast("Skull Bash"))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValue)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Skull Bash", true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast("Skull Bash"))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfter)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Skull Bash", true);
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

            //Phial of Serenity
            if (Aimsharp.CanUseItem("Phial of Serenity", false) && Aimsharp.ItemCooldown("Phial of Serenity") == 0)
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Phial of Serenity @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Phial of Serenity - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Phial of Serenity @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("PhialofSerenity");
                    return true;
                }
            }

            //Auto Regrowth
            if (Aimsharp.CanCast("Regrowth", "player", false, true) && Aimsharp.HasBuff("Predatory Swiftness", "player", true))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Regrowth @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Regrowth - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Regrowth @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("Regrowth");
                    return true;
                }
            }

            //Auto Renewal
            if (Aimsharp.CanCast("Renewal", "player", false, true))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Renewal @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Renewal - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Renewal @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("Renewal");
                    return true;
                }
            }

            //Auto Barkskin
            if (Aimsharp.CanCast("Barkskin", "player", false, true))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Barkskin @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Barkskin - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Barkskin @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("Barkskin");
                    return true;
                }
            }

            //Auto Survival Instincts
            if (Aimsharp.CanCast("Survival Instincts", "player", false, true))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Survival Instincts @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Survival Instincts - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Survival Instincts @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("Survival Instincts");
                    return true;
                }
            }
            #endregion

            #region Remove Corruption
            if (!NoDecurse && CursePoisonCheck > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != "Remove Corruption")
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

                int states = Aimsharp.CustomFunction("CursePoisonCheck");
                CleansePlayers target;

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast("Remove Corruption", unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
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
                                Aimsharp.Cast("RC_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Remove Corruption @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Auto Target
            //Auto Target
            //Hekili Cycle
            if (!NoCycle && Aimsharp.CustomFunction("HekiliCycle") == 1 && EnemiesInMelee > 1)
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
                #region Queues
                //Queue Mighty Bash
                if (MightyBash && Aimsharp.SpellCooldown("Mighty Bash") - Aimsharp.GCD() > 2000)
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Turning Off Mighty Bash queue toggle", Color.Purple);
                    }
                    Aimsharp.Cast("MightyBashOff");
                    return true;
                }

                if (MightyBash && Aimsharp.CanCast("Mighty Bash", "target", true, true))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Mighty Bash through queue toggle", Color.Purple);
                    }
                    Aimsharp.Cast("Mighty Bash");
                    return true;
                }

                //Queue Mass Entanglement
                if (MassEntanglement && Aimsharp.SpellCooldown("Mass Entanglement") - Aimsharp.GCD() > 2000)
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Turning Off Mass Entanglement queue toggle", Color.Purple);
                    }
                    Aimsharp.Cast("MassEntanglementOff");
                    return true;
                }

                if (MassEntanglement && Aimsharp.CanCast("Mass Entanglement", "target", true, true))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Mass Entanglement through queue toggle", Color.Purple);
                    }
                    Aimsharp.Cast("Mass Entanglement");
                    return true;
                }

                bool Maim = Aimsharp.IsCustomCodeOn("Maim");
                //Queue Maim
                if (Maim && Aimsharp.SpellCooldown("Maim") - Aimsharp.GCD() > 2000)
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Turning Off Maim queue toggle", Color.Purple);
                    }
                    Aimsharp.Cast("MaimOff");
                    return true;
                }

                if (Maim && Aimsharp.CanCast("Maim", "target", true, true) && (Aimsharp.PlayerSecondaryPower() >= 5 || GetCheckBox("Maim Queue - Dont wait for Max CP")))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Maim through queue toggle", Color.Purple);
                    }
                    Aimsharp.Cast("Maim");
                    return true;
                }
                #endregion

                #region Mouseover Spells
                //Soothe Mouseover
                if (Aimsharp.CanCast("Soothe", "mouseover", true, true))
                {
                    if (MOSoothe && EnrageBuffMO == 3)
                    {
                        Aimsharp.Cast("SootheMO");
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Soothe (Mouseover)", Color.Purple);
                        }
                        return true;
                    }
                }

                //Soothe Target
                if (Aimsharp.CanCast("Soothe", "target", true, true))
                {
                    if (TargetSoothe && EnrageBuffTarget == 3)
                    {
                        Aimsharp.Cast("Soothe");
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Soothe (Target)", Color.Purple);
                        }
                        return true;
                    }
                }

                //Rake Mouseover Spread
                if (Aimsharp.CanCast("Rake", "mouseover", true, false) && Aimsharp.HasDebuff("Rake", "target", true) && Aimsharp.CustomFunction("TargetIsMouseover") == 0)
                {
                    if (MOMark && MarkDebuffMO == 1)
                    {
                        Aimsharp.Cast("RakeMO");
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rake (Mouseover)", Color.Purple);
                        }
                        return true;
                    }
                }
                #endregion

                #region Maim Max CP
                if (Maim && !GetCheckBox("Maim Queue - Dont wait for Max CP"))
                {
                    if (Aimsharp.CanCast("Shred", "target", true, true) && Aimsharp.PlayerSecondaryPower() < 5)
                    {
                        Aimsharp.Cast("Shred");
                        return true;
                    }
                }
                #endregion

                if (Aimsharp.Range("target") <= 8 && Wait <= 200 && !Maim)
                {
                    #region Trinkets
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

                    if (SpellID1 == 3 && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Using Weapon", Color.Purple);
                        }
                        Aimsharp.Cast("Weapon");
                        return true;
                    }
                    #endregion

                    #region Racials
                    if (SpellID1 == 28880 && Aimsharp.CanCast("Gift of the Naaru", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Gift of the Naaru - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Gift of the Naaru");
                        return true;
                    }

                    if (SpellID1 == 20594 && Aimsharp.CanCast("Stoneform", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Stoneform - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Stoneform");
                        return true;
                    }

                    if (SpellID1 == 20589 && Aimsharp.CanCast("Escape Artist", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Escape Artist - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Escape Artist");
                        return true;
                    }

                    if (SpellID1 == 59752 && Aimsharp.CanCast("Will to Survive", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Will to Survive - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Will to Survive");
                        return true;
                    }

                    if (SpellID1 == 255647 && Aimsharp.CanCast("Light's Judgment", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Light's Judgment - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Light's Judgment");
                        return true;
                    }

                    if (SpellID1 == 265221 && Aimsharp.CanCast("Fireblood", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fireblood - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Fireblood");
                        return true;
                    }

                    if (SpellID1 == 69041 && Aimsharp.CanCast("Rocket Barrage", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rocket Barrage - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Rocket Barrage");
                        return true;
                    }

                    if (SpellID1 == 20549 && Aimsharp.CanCast("War Stomp", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting War Stomp - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("War Stomp");
                        return true;
                    }

                    if (SpellID1 == 7744 && Aimsharp.CanCast("Will of the Forsaken", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Will of the Forsaken - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Will of the Forsaken");
                        return true;
                    }

                    if (SpellID1 == 260364 && Aimsharp.CanCast("Arcane Pulse", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Pulse - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Arcane Pulse");
                        return true;
                    }

                    if (SpellID1 == 255654 && Aimsharp.CanCast("Bull Rush", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bull Rush - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Bull Rush");
                        return true;
                    }

                    if (SpellID1 == 312411 && Aimsharp.CanCast("Bag of Tricks", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bag of Tricks - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Bag of Tricks");
                        return true;
                    }

                    if ((SpellID1 == 20572 || SpellID1 == 33702 || SpellID1 == 33697) && Aimsharp.CanCast("Blood Fury", "player", false, true))
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

                    if ((SpellID1 == 28730 || SpellID1 == 25046 || SpellID1 == 50613 || SpellID1 == 69179 || SpellID1 == 80483 || SpellID1 == 129597) && Aimsharp.CanCast("Arcane Torrent", "player", false, true))
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
                    ///Covenants
                    if (SpellID1 == 323764 && Aimsharp.CanCast("Convoke the Spirits", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Convoke the Spirits - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Convoke the Spirits");
                        return true;
                    }

                    if (SpellID1 == 325727 && Aimsharp.CanCast("Adaptive Swarm", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Adaptive Swarm - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Adaptive Swarm");
                        return true;
                    }

                    if (SpellID1 == 323546 && Aimsharp.CanCast("Ravenous Frenzy", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ravenous Frenzy - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Ravenous Frenzy");
                        return true;
                    }

                    if ((SpellID1 == 327139 || SpellID1 == 327022 || SpellID1 == 327148 || SpellID1 == 327071 || SpellID1 == 326647) && Aimsharp.CanCast("Empower Bond", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Empower Bond - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Empower Bond");
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

                    #region General Spells - No GCD
                    ///Class Spells
                    //Target - No GCD
                    if (SpellID1 == 106839 && Aimsharp.CanCast("Skull Bash", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Skull Bash - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Skull Bash", true);
                        return true;
                    }

                    if ((SpellID1 == 343223 || SpellID1 == 106951) && Aimsharp.CanCast("Berserk", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Berserk - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Berserk", true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    //Target - GCD
                    if (SpellID1 == 1822 && Aimsharp.CanCast("Rake", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rake - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Rake");
                        return true;
                    }
                  
                    if ((SpellID1 == 5521 || SpellID1 == 5221 || SpellID1 == 343232) && Aimsharp.CanCast("Shred", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shred - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Shred");
                        return true;
                    }

                    if (SpellID1 == 22568 && Aimsharp.CanCast("Ferocious Bite", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ferocious Bite - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Ferocious Bite");
                        return true;
                    }

                    if (SpellID1 == 1079 && Aimsharp.CanCast("Rip", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rip - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Rip");
                        return true;
                    }

                    if (SpellID1 == 22570 && Aimsharp.CanCast("Maim", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Maim - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Maim");
                        return true;
                    }

                    if (SpellID1 == 274837 && Aimsharp.CanCast("Feral Frenzy", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Feral Frenzy - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Feral Frenzy");
                        return true;
                    }

                    if (SpellID1 == 5211 && Aimsharp.CanCast("Mighty Bash", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mighty Bash - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Mighty Bash");
                        return true;
                    }

                    if (SpellID1 == 102401 && Aimsharp.CanCast("Wild Charge", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Charge - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Wild Charge");
                        return true;
                    }

                    if (SpellID1 == 197630 && Aimsharp.CanCast("Sunfire", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sunfire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Sunfire");
                        return true;
                    }

                    if ((SpellID1 == 164812 || SpellID1 == 155625 || SpellID1 == 8921) && Aimsharp.CanCast("Moonfire", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Moonfire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Moonfire");
                        return true;
                    }

                    if (SpellID1 == 197626 && Aimsharp.CanCast("Starsurge", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Starsurge - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Starsurge");
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    //Player - GCD
                    if (SpellID1 == 52610 && Aimsharp.CanCast("Savage Roar", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Savage Roar - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Savage Roar");
                        return true;
                    }

                    if (SpellID1 == 5217 && Aimsharp.CanCast("Tiger's Fury", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tiger's Fury- " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Tiger's Fury");
                        return true;
                    }

                    if (SpellID1 == 61336 && Aimsharp.CanCast("Survival Instincts", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Survival Instincts- " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Survival Instincts");
                        return true;
                    }

                    if (SpellID1 == 108238 && Aimsharp.CanCast("Renewal", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Renewal- " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Renewal");
                        return true;
                    }

                    if (SpellID1 == 106785 && Aimsharp.CanCast("Swipe", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Swipe- " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Swipe");
                        return true;
                    }

                    if (SpellID1 == 106830 && Aimsharp.CanCast("Thrash", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Thrash - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Thrash");
                        return true;
                    }

                    if (SpellID1 == 102543 && Aimsharp.CanCast("Incarnation: King of the Jungle", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Incarnation: King of the Jungle - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Incarnation: King of the Jungle");
                        return true;
                    }

                    if (SpellID1 == 202028 && Aimsharp.CanCast("Brutal Slash", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Brutal Slash - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Brutal Slash");
                        return true;
                    }

                    if (SpellID1 == 319454 && Aimsharp.CanCast("Heart of the Wild", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Heart of the Wild - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Heart of the Wild");
                        return true;
                    }

                    if (SpellID1 == 252216 && Aimsharp.CanCast("Tiger Dash", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tiger Dash - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Tiger Dash");
                        return true;
                    }

                    if (SpellID1 == 5215 && Aimsharp.CanCast("Prowl", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Prowl - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Prowl");
                        return true;
                    }

                    if (SpellID1 == 768 && Aimsharp.CanCast("Cat Form", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cat Form - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Cat Form");
                        return true;
                    }

                    if (SpellID1 == 285381 && Aimsharp.CanCast("Primal Wrath", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Primal Wrath - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Primal Wrath");
                        return true;
                    }

                    if (SpellID1 == 197625 && Aimsharp.CanCast("Moonkin Form", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Moonkin Form - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Moonkin Form");
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
            bool Moving = Aimsharp.PlayerIsMoving();
            int PhialCount = Aimsharp.CustomFunction("PhialCount");
            bool MightyBash = Aimsharp.IsCustomCodeOn("MightyBash");
            bool MassEntanglement = Aimsharp.IsCustomCodeOn("MassEntanglement");

            bool ProwlOOC = GetCheckBox("Prowl Out of Combat:");
            bool Debug = GetCheckBox("Debug:") == true;
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

            #region Pause Checks
            if (Aimsharp.CastingID("player") > 0 || Aimsharp.IsChanneling("player"))
            {
                return false;
            }

            if (Aimsharp.CustomFunction("IsTargeting") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            //Queue Mighty Bash
            if (MightyBash && Aimsharp.SpellCooldown("Mighty Bash") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mighty Bash queue toggle - OOC", Color.Purple);
                }
                Aimsharp.Cast("MightyBashOff");
                return true;
            }

            if (MightyBash && Aimsharp.CanCast("Mighty Bash", "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mighty Bash through queue toggle - OOC", Color.Purple);
                }
                Aimsharp.Cast("Mighty Bash");
                return true;
            }

            //Queue Mass Entanglement
            if (MassEntanglement && Aimsharp.SpellCooldown("Mass Entanglement") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mass Entanglement queue toggle - OOC", Color.Purple);
                }
                Aimsharp.Cast("MassEntanglementOff");
                return true;
            }

            if (MassEntanglement && Aimsharp.CanCast("Mass Entanglement", "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mass Entanglement through queue toggle - OOC", Color.Purple);
                }
                Aimsharp.Cast("Mass Entanglement");
                return true;
            }

            bool Maim = Aimsharp.IsCustomCodeOn("Maim");
            //Queue Mighty Bash
            if (Maim && Aimsharp.SpellCooldown("Maim") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Maim queue toggle", Color.Purple);
                }
                Aimsharp.Cast("MaimOff");
                return true;
            }

            if (Maim && Aimsharp.CanCast("Maim", "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Maim through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Maim");
                return true;
            }
            #endregion

            #region Out of Combat Spells
            //Auto Fleshcraft
            if (SpellID1 == 324631 && Aimsharp.CanCast("Fleshcraft", "player", false, true) && !Moving && !Aimsharp.HasBuff("Prowl", "player", true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fleshcraft - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Fleshcraft");
                return true;
            }

            //Prowl Out of Combat
            if (SpellID1 == 5215 && Aimsharp.CanCast("Prowl", "player", false, true) && ProwlOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Prowl (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Prowl");
                return true;
            }

            if (Aimsharp.CanCast("Prowl", "player", false, true) && !Aimsharp.HasBuff("Prowl", "player", true) && ProwlOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Prowl (Out of Combat)", Color.Purple);
                }
                Aimsharp.Cast("Prowl");
                return true;
            }

            //Auto Call Steward
            if (PhialCount <= 0 && Aimsharp.CanCast("Summon Steward", "player", false, true) && !Aimsharp.HasBuff("Prowl", "player", true) && Aimsharp.GetMapID() != 2286 && Aimsharp.GetMapID() != 1666 && Aimsharp.GetMapID() != 1667 && Aimsharp.GetMapID() != 1668 && Aimsharp.CastingID("player") == 0)
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
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 6)
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