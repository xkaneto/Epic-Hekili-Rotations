using System.Linq;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class SnoogensPVEWarlockDestruction : Rotation
    {
        Random Timer;

        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoDecurse", "NoCycle", "DoorofShadows", "Banish", "Fear", "Shadowfury", "RainofFire", "HowlofTerror", "MortalCoil", "RainofFireCursor", "SummonInfernal", "Cataclysm", "CataclysmCursor" };
        private List<string> m_DebuffsList = new List<string> { "Banish", "Fear", "Immolate", "Havoc", };
        private List<string> m_BuffsList = new List<string> {  };
        private List<string> m_BloodlustBuffsList = new List<string> { "Bloodlust", "Heroism", "Time Warp", "Primal Rage", "Drums of Rage" };
        private List<string> m_ItemsList = new List<string> { "Phial of Serenity", "Healthstone", };

        private List<string> m_SpellBook = new List<string> {
            //Covenants
            "Scouring Tithe", //312321
            "Impending Catastrophe", //321792
            "Soul Rot", //325640
            "Decimating Bolt", //325289

            //Interrupt
            "Spell Lock", //119910

            //General
            //"Command Demon", //119898
            "Corruption", //172
            "Fear", //5782
            //"Create Healthstone", //6201
            "Fel Domination", //333889
            "Curse of Exhaustion", //334275
            "Health Funnel", //755
            "Curse of Weakness", //702
            "Shadow Bolt", //686
            "Drain Life", //234153
            //"Subjugate Demon", //1098
            "Summon Imp", //688
            "Summon Voidwalker", //697
            "Summon Felhunter", //691
            "Summon Succubus", //712
            "Summon Felguard", //30146
            "Unending Resolve", //104773
            "Soulstone", //20707
            "Curse of Tongues", //1714
            "Demonic Circle", //48018
            "Demonic Circle: Teleport", //48020
            "Banish", //710
            "Demonic Gateway", //111771
            "Shadowfury", //30283

            //Pet
            "Devour Magic", //19505
            "Singe Magic", //89808
            "Seduction", //6358

            //Destruction
            "Chaos Bolt", //116858
            "Conflagrate", //17962
            "Havoc", //80240
            "Immolate", //348
            "Incinerate", //29722
            "Rain of Fire", //5740
            "Summon Infernal", //1122 - place

            "Soul Fire", //6353
            "Shadowburn", //17877
            "Cataclysm", //152108 - place
            "Grimoire of Sacrifice", //108503
            "Channel Demonfire", //196447
            "Dark Soul: Instability", //113858

            "Burning Rush", //111400
            "Dark Pact", //108416
            "Mortal Coil", //6789
            "Howl of Terror", //5484

            "Summon Steward", "Fleshcraft", "Door of Shadows"

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

        List<int> SpecialSpellIDs = new List<int> { 348, 80240, };
        #endregion

        #region Misc Checks
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

            //Healthstone
            Macros.Add("Healthstone", "/use Healthstone");

            //Phial
            Macros.Add("PhialofSerenity", "/use Phial of Serenity");

            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + (Aimsharp.Latency + 100));

            //Queues
            Macros.Add("BanishOff", "/" + FiveLetters + " Banish");
            Macros.Add("FearOff", "/" + FiveLetters + " Fear");
            Macros.Add("ShadowfuryOff", "/" + FiveLetters + " Shadowfury");
            Macros.Add("RainofFireOff", "/" + FiveLetters + " RainofFire");
            Macros.Add("HowlofTerrorOff", "/" + FiveLetters + " HowlofTerror");
            Macros.Add("MortalCoilOff", "/" + FiveLetters + " MortalCoil");
            Macros.Add("SummonInfernalOff", "/" + FiveLetters + " SummonInfernal");
            Macros.Add("CataclysmOff", "/" + FiveLetters + " Cataclysm");

            Macros.Add("BanishMO", "/cast [@mouseover] Banish");
            Macros.Add("FearMO", "/cast [@mouseover] Fear");
            Macros.Add("HavocMO", "/cast [@mouseover] Havoc");
            Macros.Add("ImmolateMO", "/cast [@mouseover] Immolate");
            Macros.Add("ShadowfuryC", "/cast [@cursor] Shadowfury");
            Macros.Add("ShadowfuryP", "/cast [@player] Shadowfury");
            Macros.Add("RainofFireC", "/cast [@cursor] Rain of Fire");
            Macros.Add("RainofFireP", "/cast [@player] Rain of Fire");
            Macros.Add("SummonInfernalC", "/cast [@cursor] Summon Infernal");
            Macros.Add("SummonInfernalP", "/cast [@player] Summon Infernal");
            Macros.Add("CataclysmC", "/cast [@cursor] Cataclysm");
            Macros.Add("CataclysmP", "/cast [@player] Cataclysm");
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

            CustomFunctions.Add("RainofFireMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Immolate','mouseover') == 1 then return 1 end; return 0");
            CustomFunctions.Add("RainofFireMouseoverNC", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and IsSpellInRange('Immolate','mouseover') == 1 then return 1 end; return 0");

            CustomFunctions.Add("CycleNotEnabled", "local cycle = 0 if Hekili.State.settings.spec.cycle == true then cycle = 1 else if Hekili.State.settings.spec.cycle == false then cycle = 2 end end return cycle");

        }
        #endregion

        public override void LoadSettings()
        {
            Settings.Add(new Setting("First 5 Letters of the Addon:", "xxxxx"));
            Settings.Add(new Setting("Race:", m_RaceList, "bloodelf"));
            Settings.Add(new Setting("Ingame World Latency:", 1, 200, 50));
            Settings.Add(new Setting(" "));
            Settings.Add(new Setting("Use Trinkets on CD, dont wait for Hekili:", false));
            Settings.Add(new Setting("Auto Healthstone @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Auto Phial of Serenity @ HP%", 0, 100, 35));
            Settings.Add(new Setting("Kicks/Interrupts"));
            Settings.Add(new Setting("Randomize Kicks:", false));
            Settings.Add(new Setting("Kick at milliseconds remaining", 50, 1500, 500));
            Settings.Add(new Setting("Kick channels after milliseconds", 50, 1500, 500));
            Settings.Add(new Setting("General"));
            Settings.Add(new Setting("Auto Start Combat:", true));
            Settings.Add(new Setting("Summon Demon Out of Combat:", true));
            Settings.Add(new Setting("Auto Unending Resolve @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Auto Dark Pact @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Drain Life @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Auto Health Funnel @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Shadowfury Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Summon Infernal Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Cataclysm Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Always Cast Cataclysm @ Cursor during Rotation", false));
            Settings.Add(new Setting("Rain of Fire Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Always Cast Rain of Fire @ Cursor during Rotation", false));
            Settings.Add(new Setting("Misc"));
            Settings.Add(new Setting("Leveling/Questing:", false));
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

            Aimsharp.PrintMessage("Snoogens PVE - Warlock Destruction", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon", Color.Red);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything", Color.Brown);
            Aimsharp.PrintMessage("Hekili > Toggles > Bind \"Cooldowns\" & \"Display Mode\"", Color.Brown);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx Fear - Casts Fear @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx Banish - Casts Banish @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx HowlofTerror - Casts Howl of Terror @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx MortalCoil - Casts Mortal Coil @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx Shadowfury - Casts Shadowfury @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx SummonInfernal - Casts Summon Infernal @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx Cataclysm - Casts Cataclysm @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx CataclysmCursor - Toggles Rain of Fire always @ Cursor (same as Option)", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx RainofFire - Casts Rain of Fire @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx RainofFireCursor - Toggles Rain of Fire always @ Cursor (same as Option)", Color.Yellow);
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
            int CooldownsToggle = Aimsharp.CustomFunction("CooldownsToggleCheck");
            int Wait = Aimsharp.CustomFunction("HekiliWait");
            int Enemies = Aimsharp.CustomFunction("HekiliEnemies");
            int TargetingGroup = Aimsharp.CustomFunction("GroupTargets");

            bool NoInterrupts= Aimsharp.IsCustomCodeOn("NoInterrupts");
            bool NoCycle = Aimsharp.IsCustomCodeOn("NoCycle");

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
            int PetHP = Aimsharp.Health("pet");

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
            if (Aimsharp.CastingID("player") == 710 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Banish"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Banish Queue", Color.Purple);
                }
                Aimsharp.Cast("BanishOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 5782 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Fear"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fear Queue", Color.Purple);
                }
                Aimsharp.Cast("FearOff");
                return true;
            }

            //Auto Shadowburn (Leveling/Questing)
            bool Leveling = GetCheckBox("Leveling/Questing:");
            if (Leveling && Aimsharp.CanCast("Shadowburn", "target", true, false) && Aimsharp.Health("target") <= 20 && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                if (Aimsharp.CastingID("player") > 0)
                {
                    Aimsharp.StopCasting();
                }
                Aimsharp.Cast("Shadowburn");
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

            if (Aimsharp.IsCustomCodeOn("DoorofShadows") && Aimsharp.SpellCooldown("Door of Shadows") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("Shadowfury") && Aimsharp.SpellCooldown("Shadowfury") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("RainofFire") && Aimsharp.SpellCooldown("Rain of Fire") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("Cataclysm") && Aimsharp.SpellCooldown("Cataclysm") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("SummonInfernal") && Aimsharp.SpellCooldown("Summon Infernal") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Interrupts
            if (!NoInterrupts && (Aimsharp.UnitID("target") != 168105 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))) && (Aimsharp.UnitID("target") != 157571 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))))
            {
                if (GetCheckBox("Randomize Kicks:"))
                {
                    KickValue = KickValue + Timer.Next(200,800);
                    KickChannelsAfter = KickChannelsAfter + Timer.Next(200,800);
                }
                if (Aimsharp.CanCast("Spell Lock", "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValue)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Spell Lock", true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast("Spell Lock", "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfter)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Spell Lock", true);
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

            //Auto Unending Resolve
            if (Aimsharp.CanCast("Unending Resolve", "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Unending Resolve @ HP%"))
                {
                    Aimsharp.Cast("Unending Resolve");
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Unending Resolve - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Unending Resolve @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Dark Pact
            if (Aimsharp.CanCast("Dark Pact", "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Dark Pact @ HP%"))
                {
                    Aimsharp.Cast("Dark Pact");
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Dark Pact - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Dark Pact @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Drain Life
            if (Aimsharp.CanCast("Drain Life", "target", true, true))
            {
                if (PlayerHP <= GetSlider("Auto Drain Life @ HP%"))
                {
                    Aimsharp.Cast("Drain Life");
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Drain Life - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Drain Life @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Health Funnel
            if (Aimsharp.CanCast("Health Funnel", "pet", true, true))
            {
                if (PetHP <= GetSlider("Auto Health Funnel @ HP%") && PetHP > 1)
                {
                    Aimsharp.Cast("Health Funnel");
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Health Funnel - Pet HP% " + PetHP + " due to setting being on HP% " + GetSlider("Auto Health Funnel @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }
            #endregion

            #region Queues
            bool Banish = Aimsharp.IsCustomCodeOn("Banish");
            if ((Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Banish)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Banish Queue", Color.Purple);
                }
                Aimsharp.Cast("BanishOff");
                return true;
            }

            if (Banish && Aimsharp.CanCast("Banish", "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Banish - Queue", Color.Purple);
                }
                Aimsharp.Cast("BanishMO");
                return true;
            }

            bool Fear = Aimsharp.IsCustomCodeOn("Fear");
            if ((Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Fear)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fear Queue", Color.Purple);
                }
                Aimsharp.Cast("FearOff");
                return true;
            }

            if (Fear && Aimsharp.CanCast("Fear", "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fear - Queue", Color.Purple);
                }
                Aimsharp.Cast("FearMO");
                return true;
            }

            bool MortalCoil = Aimsharp.IsCustomCodeOn("MortalCoil");
            if (Aimsharp.SpellCooldown("Shadowfury") - Aimsharp.GCD() > 2000 && MortalCoil)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mortal Coil Queue", Color.Purple);
                }
                Aimsharp.Cast("MortalCoilOff");
                return true;
            }

            if (MortalCoil && Aimsharp.CanCast("Mortal Coil", "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mortal Coil - Queue", Color.Purple);
                }
                Aimsharp.Cast("Mortal Coil");
                return true;
            }

            bool HowlofTerror = Aimsharp.IsCustomCodeOn("HowlofTerror");
            if (Aimsharp.SpellCooldown("Shadowfury") - Aimsharp.GCD() > 2000 && HowlofTerror)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Howl of Terror Queue", Color.Purple);
                }
                Aimsharp.Cast("HowlofTerrorOff");
                return true;
            }

            if (HowlofTerror && Aimsharp.CanCast("Howl of Terror", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Howl of Terror - Queue", Color.Purple);
                }
                Aimsharp.Cast("Howl of Terror");
                return true;
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

            //Queue Shadowfury
            string ShadowfuryCast = GetDropDown("Shadowfury Cast:");
            bool Shadowfury = Aimsharp.IsCustomCodeOn("Shadowfury");
            if ((Aimsharp.SpellCooldown("Shadowfury") - Aimsharp.GCD() > 2000 || Moving) && Shadowfury)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shadowfury Queue", Color.Purple);
                }
                Aimsharp.Cast("ShadowfuryOff");
                return true;
            }

            if (Shadowfury && Aimsharp.CanCast("Shadowfury", "player", false, true) && !Moving)
            {
                switch (ShadowfuryCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Shadowfury");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowfuryP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowfuryC");
                        return true;
                }
            }

            //Queue Rain of Fire
            string RainofFireCast = GetDropDown("Rain of Fire Cast:");
            bool RainofFire = Aimsharp.IsCustomCodeOn("RainofFire");
            if ((Aimsharp.SpellCooldown("Rain of Fire") - Aimsharp.GCD() > 2000 || Moving || Aimsharp.LastCast() == "Rain of Fire") && RainofFire)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Rain of Fire Queue", Color.Purple);
                }
                Aimsharp.Cast("RainofFireOff");
                return true;
            }

            if (RainofFire && Aimsharp.CanCast("Rain of Fire", "player", false, true) && !Moving)
            {
                switch (RainofFireCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire - " + RainofFireCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Rain of Fire");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire - " + RainofFireCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RainofFireP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire - " + RainofFireCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RainofFireC");
                        return true;
                }
            }

            //Queue Summon Infernal
            string SummonInfernalCast = GetDropDown("Summon Infernal Cast:");
            bool SummonInfernal = Aimsharp.IsCustomCodeOn("SummonInfernal");
            if ((Aimsharp.SpellCooldown("Summon Infernal") - Aimsharp.GCD() > 2000 || Moving) && SummonInfernal)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Summon Infernal Queue", Color.Purple);
                }
                Aimsharp.Cast("SummonInfernalOff");
                return true;
            }

            if (SummonInfernal && Aimsharp.CanCast("Summon Infernal", "player", false, true) && !Moving)
            {
                switch (SummonInfernalCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Summon Infernal");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SummonInfernalP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SummonInfernalC");
                        return true;
                }
            }

            //Queue Cataclysm
            string CataclysmCast = GetDropDown("Cataclysm Cast:");
            bool Cataclysm = Aimsharp.IsCustomCodeOn("Cataclysm");
            if ((Aimsharp.SpellCooldown("Cataclysm") - Aimsharp.GCD() > 2000 || Moving) && Cataclysm)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Cataclysm Queue", Color.Purple);
                }
                Aimsharp.Cast("CataclysmOff");
                return true;
            }

            if (Cataclysm && Aimsharp.CanCast("Cataclysm", "player", false, true) && !Moving)
            {
                switch (CataclysmCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm - " + CataclysmCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Cataclysm");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm - " + CataclysmCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CataclysmP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm - " + CataclysmCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CataclysmC");
                        return true;
                }
            }
            #endregion

            #region Auto Target
            //Hekili Cycle
            if (!NoCycle && Aimsharp.CustomFunction("CycleNotEnabled") == 1 && Aimsharp.CustomFunction("HekiliCycle") == 1 && Enemies > 1 && (SpellID1 == 348 && Aimsharp.HasDebuff("Immolate", "target", true) || SpellID1 != 80240))
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
                if (Aimsharp.Range("target") <= 40 && !Aimsharp.HasDebuff("Banish", "target", true) && !Aimsharp.HasDebuff("Fear", "target", true) && !Banish && !Fear)
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
                    if (SpellID1 == 28880 && Aimsharp.CanCast("Gift of the Naaru", "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Gift of the Naaru - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Gift of the Naaru");
                        return true;
                    }

                    if (SpellID1 == 20594 && Aimsharp.CanCast("Stoneform", "player", true, true))
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

                    if (SpellID1 == 255647 && Aimsharp.CanCast("Light's Judgment", "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Light's Judgment - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Light's Judgment");
                        return true;
                    }

                    if (SpellID1 == 265221 && Aimsharp.CanCast("Fireblood", "player", true, true))
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

                    if (SpellID1 == 20549 && Aimsharp.CanCast("War Stomp", "player", true, true))
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

                    if (SpellID1 == 260364 && Aimsharp.CanCast("Arcane Pulse", "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Pulse - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Arcane Pulse");
                        return true;
                    }

                    if (SpellID1 == 255654 && Aimsharp.CanCast("Bull Rush", "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bull Rush - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Bull Rush");
                        return true;
                    }

                    if (SpellID1 == 312411 && Aimsharp.CanCast("Bag of Tricks", "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bag of Tricks - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Bag of Tricks");
                        return true;
                    }

                    if ((SpellID1 == 20572 || SpellID1 == 33702 || SpellID1 == 33697) && Aimsharp.CanCast("Blood Fury", "player", true, true))
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

                    if ((SpellID1 == 28730 || SpellID1 == 25046 || SpellID1 == 50613 || SpellID1 == 69179 || SpellID1 == 80483 || SpellID1 == 129597) && Aimsharp.CanCast("Arcane Torrent", "player", true, false))
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
                    if (SpellID1 == 312321 && Aimsharp.CanCast("Scouring Tithe", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Scouring Tithe - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Scouring Tithe");
                        return true;
                    }

                    if (SpellID1 == 321792 && Aimsharp.CanCast("Impending Catastrophe", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Impending Catastrophe - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Impending Catastrophe");
                        return true;
                    }

                    if (SpellID1 == 325640 && Aimsharp.CanCast("Soul Rot", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Soul Rot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Soul Rot");
                        return true;
                    }

                    if (SpellID1 == 325289 && Aimsharp.CanCast("Decimating Bolt", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Decimating Bolt - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Decimating Bolt");
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
                    if (SpellID1 == 19647 && Aimsharp.CanCast("Spell Lock", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spell Lock - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Spell Lock", true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    //Target - GCD
                    /*
                    if (SpellID1 == 119898 && Aimsharp.CanCast("Command Demon", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Command Demon - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Command Demon");
                        return true;
                    }
                    */

                    if (SpellID1 == 172 && Aimsharp.CanCast("Corruption", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Corruption - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Corruption");
                        return true;
                    }

                    if (SpellID1 == 5782 && Aimsharp.CanCast("Fear", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fear - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Fear");
                        return true;
                    }

                    if (SpellID1 == 334275 && Aimsharp.CanCast("Curse of Exhaustion", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Curse of Exhaustion - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Curse of Exhaustion");
                        return true;
                    }

                    if (SpellID1 == 755 && Aimsharp.CanCast("Health Funnel", "pet", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Health Funnel - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Health Funnel");
                        return true;
                    }

                    if (SpellID1 == 702 && Aimsharp.CanCast("Curse of Weakness", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Curse of Weakness - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Curse of Weakness");
                        return true;
                    }

                    if (SpellID1 == 686 && Aimsharp.CanCast("Shadow Bolt", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Curse of Weakness - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Shadow Bolt");
                        return true;
                    }

                    if (SpellID1 == 234153 && Aimsharp.CanCast("Drain Life", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Drain Life - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Drain Life");
                        return true;
                    }

                    /*
                    if (SpellID1 == 1098 && Aimsharp.CanCast("Subjugate Demon", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Subjugate Demon - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Subjugate Demon");
                        return true;
                    }
                    */

                    if (SpellID1 == 1714 && Aimsharp.CanCast("Curse of Tongues", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Curse of Tongues - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Curse of Tongues");
                        return true;
                    }

                    if (SpellID1 == 710 && Aimsharp.CanCast("Banish", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Banish - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Banish");
                        return true;
                    }

                    if (SpellID1 == 19505 && Aimsharp.CanCast("Devour Magic", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Devour Magic - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Devour Magic");
                        return true;
                    }

                    if (SpellID1 == 6358 && Aimsharp.CanCast("Seduction", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Seduction - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Seduction");
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    /*
                    if (SpellID1 == 6201 && Aimsharp.CanCast("Create Healthstone", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Create Healthstone - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Create Healthstone");
                        return true;
                    }
                    */

                    if (SpellID1 == 333889 && Aimsharp.CanCast("Fel Domination", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fel Domination - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Fel Domination");
                        return true;
                    }

                    if (SpellID1 == 688 && Aimsharp.CanCast("Summon Imp", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Imp - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Summon Imp");
                        return true;
                    }

                    if (SpellID1 == 697 && Aimsharp.CanCast("Summon Voidwalker", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Voidwalker - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Summon Voidwalker");
                        return true;
                    }

                    if (SpellID1 == 691 && Aimsharp.CanCast("Summon Felhunter", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Felhunter - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Summon Felhunter");
                        return true;
                    }

                    if (SpellID1 == 712 && Aimsharp.CanCast("Summon Succubus", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Succubus - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Summon Succubus");
                        return true;
                    }

                    if (SpellID1 == 30146 && Aimsharp.CanCast("Summon Felguard", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Felguard - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Summon Felguard");
                        return true;
                    }

                    if (SpellID1 == 104773 && Aimsharp.CanCast("Unending Resolve", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Unending Resolve - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Unending Resolve");
                        return true;
                    }

                    if (SpellID1 == 20707 && Aimsharp.CanCast("Soulstone", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Soulstone - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Soulstone");
                        return true;
                    }

                    if (SpellID1 == 48018 && Aimsharp.CanCast("Demonic Circle", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Demonic Circle - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Demonic Circle");
                        return true;
                    }

                    if (SpellID1 == 48020 && Aimsharp.CanCast("Demonic Circle: Teleport", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Demonic Circle: Teleport - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Demonic Circle: Teleport");
                        return true;
                    }

                    if (SpellID1 == 111771 && Aimsharp.CanCast("Demonic Gateway", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Demonic Gateway - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Demonic Gateway");
                        return true;
                    }

                    if (SpellID1 == 30283 && Aimsharp.CanCast("Shadowfury", "player", false, true))
                    {
                        switch (ShadowfuryCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("Shadowfury");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("ShadowfuryP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("ShadowfuryC");
                                return true;
                        }
                    }

                    if (SpellID1 == 89808 && Aimsharp.CanCast("Singe Magic", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Singe Magic - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Singe Magic");
                        return true;
                    }
                    #endregion

                    #region Destruction Spells - Player GCD
                    if (SpellID1 == 196447 && Aimsharp.CanCast("Channel Demonfire", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Channel Demonfire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Channel Demonfire");
                        return true;
                    }

                    if (SpellID1 == 1122 && Aimsharp.CanCast("Summon Infernal", "player", false, true))
                    {
                        switch (SummonInfernalCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("Summon Infernal");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("SummonInfernalP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("SummonInfernalC");
                                return true;
                        }
                    }

                    if (SpellID1 == 5740 && Aimsharp.CanCast("Rain of Fire", "player", false, true) && ((Aimsharp.CustomFunction("RainofFireMouseover") == 1 || !InstanceIDList.Contains(Aimsharp.GetMapID()) && Aimsharp.CustomFunction("RainofFireMouseoverNC") == 1) || GetCheckBox("Always Cast Rain of Fire @ Cursor during Rotation") || Aimsharp.IsCustomCodeOn("RainofFireCursor")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("RainofFireC");
                        return true;
                    }
                    else if (SpellID1 == 5740 && Aimsharp.CanCast("Rain of Fire", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Rain of Fire");
                        return true;
                    }

                    if (SpellID1 == 152108 && Aimsharp.CanCast("Cataclysm", "player", false, true) && ((Aimsharp.CustomFunction("RainofFireMouseover") == 1 || !InstanceIDList.Contains(Aimsharp.GetMapID()) && Aimsharp.CustomFunction("RainofFireMouseoverNC") == 1) || GetCheckBox("Always Cast Cataclysm @ Cursor during Rotation") || Aimsharp.IsCustomCodeOn("CataclysmCursor")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("CataclysmC");
                        return true;
                    }
                    else if (SpellID1 == 152108 && Aimsharp.CanCast("Cataclysm", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Cataclysm");
                        return true;
                    }

                    if (SpellID1 == 111400 && Aimsharp.CanCast("Burning Rush", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Burning Rush - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Burning Rush");
                        return true;
                    }

                    if (SpellID1 == 108416 && Aimsharp.CanCast("Dark Pact", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Dark Pact - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Dark Pact");
                        return true;
                    }

                    if (SpellID1 == 5484 && Aimsharp.CanCast("Howl of Terror", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Howl of Terror - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Howl of Terror");
                        return true;
                    }

                    if (SpellID1 == 108503 && Aimsharp.CanCast("Grimoire of Sacrifice", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Grimoire of Sacrifice - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Grimoire of Sacrifice");
                        return true;
                    }

                    if (SpellID1 == 113858 && Aimsharp.CanCast("Dark Soul: Instability", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Dark Soul: Instability - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Dark Soul: Instability");
                        return true;
                    }
                    #endregion

                    #region Destruction Spells - Target GCD
                    if (SpellID1 == 17877 && Aimsharp.CanCast("Shadowburn", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowburn - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Shadowburn");
                        return true;
                    }

                    if (SpellID1 == 6353 && Aimsharp.CanCast("Soul Fire", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Soul Fire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Soul Fire");
                        return true;
                    }

                    if (SpellID1 == 29722 && Aimsharp.CanCast("Incinerate", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Incinerate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Incinerate");
                        return true;
                    }

                    if (SpellID1 == 348 && Aimsharp.CanCast("Immolate", "target", true, true) && Aimsharp.CustomFunction("HekiliCycle") == 0)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Immolate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Immolate");
                        return true;
                    }

                    if (SpellID1 == 348 && Aimsharp.CanCast("Immolate", "mouseover", true, true) && Aimsharp.CustomFunction("HekiliCycle") == 1 && (Aimsharp.CustomFunction("RainofFireMouseover") == 1 || !InstanceIDList.Contains(Aimsharp.GetMapID()) && Aimsharp.CustomFunction("RainofFireMouseoverNC") == 1))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Immolate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("ImmolateMO");
                        return true;
                    }
                    else if (SpellID1 == 348 && Aimsharp.CanCast("Immolate", "target", true, true) && Aimsharp.CustomFunction("HekiliCycle") == 1 && Aimsharp.CustomFunction("RainofFireMouseover") == 0)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Immolate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Immolate");
                        return true;
                    }

                    if (SpellID1 == 80240 && Aimsharp.CanCast("Havoc", "target", true, true) && Aimsharp.CustomFunction("HekiliCycle") == 0)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Havoc - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Havoc");
                        return true;
                    }

                    if (SpellID1 == 80240 && Aimsharp.CanCast("Havoc", "mouseover", true, true) && Aimsharp.CustomFunction("HekiliCycle") == 1 && (Aimsharp.CustomFunction("RainofFireMouseover") == 1 || !InstanceIDList.Contains(Aimsharp.GetMapID()) && Aimsharp.CustomFunction("RainofFireMouseoverNC") == 1))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Havoc - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("HavocMO");
                        return true;
                    }
                    else if (SpellID1 == 80240 && Aimsharp.CanCast("Havoc", "target", true, true) && Aimsharp.CustomFunction("HekiliCycle") == 1 && Aimsharp.CustomFunction("RainofFireMouseover") == 0)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Havoc - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Havoc");
                        return true;
                    }

                    if (SpellID1 == 17962 && Aimsharp.CanCast("Conflagrate", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Conflagrate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Conflagrate");
                        return true;
                    }

                    if (SpellID1 == 116858 && Aimsharp.CanCast("Chaos Bolt", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Chaos Bolt - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Chaos Bolt");
                        return true;
                    }

                    if (SpellID1 == 6789 && Aimsharp.CanCast("Mortal Coil", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mortal Coil - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Mortal Coil");
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
            bool SummonDemonOOC = GetCheckBox("Summon Demon Out of Combat:");
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
            if (Aimsharp.CastingID("player") == 710 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Banish"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Banish Queue", Color.Purple);
                }
                Aimsharp.Cast("BanishOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 5782 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Fear"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fear Queue", Color.Purple);
                }
                Aimsharp.Cast("FearOff");
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

            if (Aimsharp.IsCustomCodeOn("DoorofShadows") && Aimsharp.SpellCooldown("Door of Shadows") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("Shadowfury") && Aimsharp.SpellCooldown("Shadowfury") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("RainofFire") && Aimsharp.SpellCooldown("Rain of Fire") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            bool Banish = Aimsharp.IsCustomCodeOn("Banish");
            if ((Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Banish)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Banish Queue", Color.Purple);
                }
                Aimsharp.Cast("BanishOff");
                return true;
            }

            if (Banish && Aimsharp.CanCast("Banish", "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Banish - Queue", Color.Purple);
                }
                Aimsharp.Cast("BanishMO");
                return true;
            }

            bool Fear = Aimsharp.IsCustomCodeOn("Fear");
            if ((Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Fear)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fear Queue", Color.Purple);
                }
                Aimsharp.Cast("FearOff");
                return true;
            }

            if (Fear && Aimsharp.CanCast("Fear", "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fear - Queue", Color.Purple);
                }
                Aimsharp.Cast("FearMO");
                return true;
            }

            bool MortalCoil = Aimsharp.IsCustomCodeOn("MortalCoil");
            if (Aimsharp.SpellCooldown("Shadowfury") - Aimsharp.GCD() > 2000 && MortalCoil)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mortal Coil Queue", Color.Purple);
                }
                Aimsharp.Cast("MortalCoilOff");
                return true;
            }

            if (MortalCoil && Aimsharp.CanCast("Mortal Coil", "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mortal Coil - Queue", Color.Purple);
                }
                Aimsharp.Cast("Mortal Coil");
                return true;
            }

            bool HowlofTerror = Aimsharp.IsCustomCodeOn("HowlofTerror");
            if (Aimsharp.SpellCooldown("Shadowfury") - Aimsharp.GCD() > 2000 && HowlofTerror)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Howl of Terror Queue", Color.Purple);
                }
                Aimsharp.Cast("HowlofTerrorOff");
                return true;
            }

            if (HowlofTerror && Aimsharp.CanCast("Howl of Terror", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Howl of Terror - Queue", Color.Purple);
                }
                Aimsharp.Cast("Howl of Terror");
                return true;
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

            //Queue Shadowfury
            string ShadowfuryCast = GetDropDown("Shadowfury Cast:");
            bool Shadowfury = Aimsharp.IsCustomCodeOn("Shadowfury");
            if ((Aimsharp.SpellCooldown("Shadowfury") - Aimsharp.GCD() > 2000 || Moving) && Shadowfury)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shadowfury Queue", Color.Purple);
                }
                Aimsharp.Cast("ShadowfuryOff");
                return true;
            }

            if (Shadowfury && Aimsharp.CanCast("Shadowfury", "player", false, true) && !Moving)
            {
                switch (ShadowfuryCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Shadowfury");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowfuryP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowfuryC");
                        return true;
                }
            }

            //Queue Rain of Fire
            string RainofFireCast = GetDropDown("Rain of Fire Cast:");
            bool RainofFire = Aimsharp.IsCustomCodeOn("RainofFire");
            if ((Aimsharp.SpellCooldown("Rain of Fire") - Aimsharp.GCD() > 2000 || Moving || Aimsharp.LastCast() == "Rain of Fire") && RainofFire)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Rain of Fire Queue", Color.Purple);
                }
                Aimsharp.Cast("RainofFireOff");
                return true;
            }

            if (RainofFire && Aimsharp.CanCast("Rain of Fire", "player", false, true) && !Moving)
            {
                switch (RainofFireCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire - " + RainofFireCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Rain of Fire");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire - " + RainofFireCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RainofFireP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire - " + RainofFireCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RainofFireC");
                        return true;
                }
            }

            //Queue Summon Infernal
            string SummonInfernalCast = GetDropDown("Summon Infernal Cast:");
            bool SummonInfernal = Aimsharp.IsCustomCodeOn("SummonInfernal");
            if ((Aimsharp.SpellCooldown("Summon Infernal") - Aimsharp.GCD() > 2000 || Moving) && SummonInfernal)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Summon Infernal Queue", Color.Purple);
                }
                Aimsharp.Cast("SummonInfernalOff");
                return true;
            }

            if (SummonInfernal && Aimsharp.CanCast("Summon Infernal", "player", false, true) && !Moving)
            {
                switch (SummonInfernalCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Summon Infernal");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SummonInfernalP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SummonInfernalC");
                        return true;
                }
            }

            //Queue Cataclysm
            string CataclysmCast = GetDropDown("Cataclysm Cast:");
            bool Cataclysm = Aimsharp.IsCustomCodeOn("Cataclysm");
            if ((Aimsharp.SpellCooldown("Cataclysm") - Aimsharp.GCD() > 2000 || Moving) && Cataclysm)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Cataclysm Queue", Color.Purple);
                }
                Aimsharp.Cast("CataclysmOff");
                return true;
            }

            if (Cataclysm && Aimsharp.CanCast("Cataclysm", "player", false, true) && !Moving)
            {
                switch (CataclysmCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm - " + CataclysmCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Cataclysm");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm - " + CataclysmCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CataclysmP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm - " + CataclysmCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CataclysmC");
                        return true;
                }
            }
            #endregion

            #region Out of Combat Spells
            //Summon Demon
            if (SpellID1 == 688 && Aimsharp.CanCast("Summon Imp", "player", false, true) && SummonDemonOOC && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Summon Imp - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Summon Imp");
                return true;
            }

            if (SpellID1 == 697 && Aimsharp.CanCast("Summon Voidwalker", "player", false, true) && SummonDemonOOC && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Summon Voidwalker - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Summon Voidwalker");
                return true;
            }

            if (SpellID1 == 691 && Aimsharp.CanCast("Summon Felhunter", "player", false, true) && SummonDemonOOC && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Summon Felhunter - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Summon Felhunter");
                return true;
            }

            if (SpellID1 == 712 && Aimsharp.CanCast("Summon Succubus", "player", false, true) && SummonDemonOOC && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Summon Succubus - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Summon Succubus");
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

            //Auto Call Steward
            if (PhialCount <= 0 && Aimsharp.CanCast("Summon Steward", "player") && Aimsharp.GetMapID() != 2286 && Aimsharp.GetMapID() != 1666 && Aimsharp.GetMapID() != 1667 && Aimsharp.GetMapID() != 1668 && Aimsharp.CastingID("player") == 0)
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
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 40 && TargetInCombat && !Aimsharp.HasDebuff("Banish", "target", true) && !Aimsharp.HasDebuff("Fear", "target", true) && !Banish && !Fear)
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