using System.Linq;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class KanetoPriestShadowHekili : Rotation
    {
        private static string Language = "English";

        #region SpellFunctions
        #endregion

        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle", "NoPurify", "ShadowCrash", "MindControl", "LeapofFaith", "ShackleUndead", "PowerInfusion", "MindBomb", "PsychicHorror", "PsychicScream", "MassDispel", "DoorofShadows", "VampiricTouch", "ShadowWordPain", "BodyandSoul", };
        private List<string> m_DebuffsList = new List<string> { "Weakened Soul", };
        private List<string> m_BuffsList = new List<string> { "Dark Thought", };
        private List<string> m_BloodlustBuffsList = new List<string> { "Bloodlust", "Heroism", "Time Warp", "Primal Rage", "Drums of Rage" };
        private List<string> m_ItemsList = new List<string> { "Healthstone" };

        private List<string> m_SpellBook_General = new List<string> {
            //Covenants
            "Boon of the Ascended", //325013
            "Ascended Nova", //325020
            "Ascended Blast", //325283
            "Unholy Nova", //324724
            "Fae Guardians", //327661
            "Mindgames", //323673

            //Interrupt
            "Silence", //15487

            //General
            "Desperate Prayer", //19236
            "Mind Control", //605 - queue MO
            "Dispel Magic", //528
            "Mind Soothe", //453
            "Leap of Faith", //73325 - queue MO
            "Power Word: Fortitude", //21562
            "Mass Dispel", //32375 - queue Cast
            "Power Word: Shield", //17
            "Mind Blast", //8092
            "Psychic Scream", //8122 - queue
            "Shackle Undead", //9484 - queue MO
            "Shadow Word: Death", //32379
            "Shadow Word: Pain", //589
            "Power Infusion", //10060 - queue MO

            //Shadow
            "Devouring Plague", //335467
            "Purify Disease", //213634
            "Dispersion", //47585 - option
            "Shadow Mend", //186263
            "Mind Flay", //15407
            "Shadowfiend", //34433
            "Mind Sear", //48045
            "Shadowform", //232698
            "Vampiric Embrace", //15286
            "Vampiric Touch", //34914
            "Void Eruption", //228260
            "Void Bolt", //205448

            "Searing Nightmare", //341385
            "Mind Bomb", //205369 - queue mo
            "Psychic Horror", //64044 - queue mo
            "Shadow Crash", //205385 - Cast
            "Damnation", //341374
            "Mindbender", //200174
            "Void Torrent", //263165
            "Surrender to Madness", //319952


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

            //Phial
            Macros.Add("PhialofSerenity", "/use Phial of Serenity");

            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + (Aimsharp.Latency + 100));

            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");
            Macros.Add("PD_FOC", "/cast [@focus] Purify Disease");

            //Queues
            Macros.Add("ShadowCrashOff", "/" + FiveLetters + " ShadowCrash");
            Macros.Add("ShadowCrashC", "/cast [@cursor] Shadow Crash");
            Macros.Add("ShadowCrashP", "/cast [@player] Shadow Crash");

            Macros.Add("MassDispelOff", "/" + FiveLetters + " MassDispel");
            Macros.Add("MassDispelC", "/cast [@cursor] Mass Dispel");
            Macros.Add("MassDispelP", "/cast [@player] Mass Dispel");

            Macros.Add("MindControlOff", "/" + FiveLetters + " MindControl");
            Macros.Add("MindControlMO", "/cast [@mouseover] Mind Control");

            Macros.Add("LeapofFaithOff", "/" + FiveLetters + " LeapofFaith");
            Macros.Add("LeapofFaithMO", "/cast [@mouseover] Leap of Faith");

            Macros.Add("ShackleUndeadOff", "/" + FiveLetters + " ShackleUndead");
            Macros.Add("ShackleUndeadMO", "/cast [@mouseover] Shackle Undead");

            Macros.Add("PowerInfusionOff", "/" + FiveLetters + " PowerInfusion");
            Macros.Add("PowerInfusionMO", "/cast [@mouseover] Power Infusion");

            Macros.Add("MindBombOff", "/" + FiveLetters + " MindBomb");
            Macros.Add("MindBombMO", "/cast [@mouseover] Mind Bomb");

            Macros.Add("PsychicHorrorOff", "/" + FiveLetters + " PsychicHorror");
            Macros.Add("PsychicHorrorMO", "/cast [@mouseover] Psychic Horror");

            Macros.Add("PsychicScreamOff", "/" + FiveLetters + " PsychicScream");

            Macros.Add("DispelMagicMO", "/cast [@mouseover] Dispel Magic");
            Macros.Add("ShadowWordPainMO", "/cast [@mouseover] Shadow Word: Pain");
            Macros.Add("VampiricTouchMO", "/cast [@mouseover] Vampiric Touch");

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

            CustomFunctions.Add("HekiliEnemies", "if Hekili.State.active_enemies ~= nil and Hekili.State.active_enemies > 0 then return Hekili.State.active_enemies end return 0");

            CustomFunctions.Add("TargetIsMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitExists('target') and UnitIsDead('target') ~= true and UnitIsUnit('mouseover', 'target') then return 1 end; return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");

            CustomFunctions.Add("CycleNotEnabled", "local cycle = 0 if Hekili.State.settings.spec.cycle == true then cycle = 1 else if Hekili.State.settings.spec.cycle == false then cycle = 2 end end return cycle");

            CustomFunctions.Add("DiseaseCheck", "local y=0; " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"player\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Disease\" then y = y +1; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Disease\" then y = y +2; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Disease\" then y = y +4; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Disease\" then y = y +8; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Disease\" then y = y +16; end end " +
            "return y");

            CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
            "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
            "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
            "\nreturn foc");

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

            CustomFunctions.Add("DispelMagicCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Dispel Magic','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType,_,_,_  = UnitBuff('mouseover', y) if debuffType == 'Magic' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("SWPCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Shadow Word: Pain','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType,_,_,_  = UnitDebuff('mouseover', y) if name == 'Shadow Word: Pain' then markcheck = markcheck + 2 end end return markcheck end return 0");
            CustomFunctions.Add("VTCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Vampiric Touch','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType,_,_,_  = UnitDebuff('mouseover', y) if name == 'Vampiric Touch' then markcheck = markcheck + 2 end end return markcheck end return 0");
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
            Settings.Add(new Setting("Race:", m_RaceList, "gnome"));
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
            Settings.Add(new Setting("Shadowform Out of Combat:", true));
            Settings.Add(new Setting("Fortitude Out of Combat:", true));
            Settings.Add(new Setting("Auto Dispel Magic Mouseover:", true));
            Settings.Add(new Setting("Auto Desperate Prayer @ HP%", 0, 100, 30));
            Settings.Add(new Setting("Auto Dispersion @ HP%", 0, 100, 10));
            Settings.Add(new Setting("Shadow Crash Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Mass Dispel Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("    "));
        }

        public override void Initialize()
        {

            if (GetCheckBox("Debug:") == true)
            {
                Aimsharp.DebugMode();
            }

            Aimsharp.Latency = GetSlider("Ingame World Latency:");
            Aimsharp.QuickDelay = 50;
            Aimsharp.SlowDelay = 75;

            Aimsharp.PrintMessage("Snoogens PVE - Priest Shadow", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon", Color.Red);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything", Color.Brown);
            Aimsharp.PrintMessage("Hekili > Toggles > Bind \"Cooldowns\" & \"Display Mode\"", Color.Brown);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx NoPurify - Disables Purify Disease", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx MindControl - Casts Mind Control @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx LeapofFaith - Casts Leap of Faith @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx ShackleUndead - Casts Shackle Undead @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx PowerInfusion - Casts Power Infusion @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx ShadowWordPain - Enables Shadow Word: Pain @ Mouseover spread", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx VampiricTouch - Enables Vampiric Touch @ Mouseover spread", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx MindBomb - Casts Mind Bomb @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx PsychicHorror - Casts Psychic Horror @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx ShadowCrash - Casts Shadow Crash @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx PsychicScream - Casts Psychic Scream @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx MassDispel - Casts Mass Dispel @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx BodyandSoul - Casts Power Word: Shield when moving for the speed increase", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx DoorofShadows - Casts Door of Shadows @ next GCD", Color.Yellow);
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

            InitializeMacros();

            InitializeSpells();

            InitializeCustomLUAFunctions();
        }

        public override bool CombatTick()
        {
            #region Declarations
            int SpellID1 = Aimsharp.CustomFunction("HekiliID1");
            int Wait = Aimsharp.CustomFunction("HekiliWait");
            int Enemies = Aimsharp.CustomFunction("HekiliEnemies");
            int TargetingGroup = Aimsharp.CustomFunction("GroupTargets");

            bool NoInterrupts = Aimsharp.IsCustomCodeOn("NoInterrupts");
            bool NoCycle = Aimsharp.IsCustomCodeOn("NoCycle");
            bool NoPurify = Aimsharp.IsCustomCodeOn("NoPurify");

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

            int DesperatePrayerHP = GetSlider("Auto Desperate Prayer @ HP%");
            int DispersionHP = GetSlider("Auto Dispersion @ HP%");
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
            if (SpellID1 == 341385 && Aimsharp.CanCast("Searing Nightmare", "player", false, false) && Wait <= 200)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Searing Nightmare - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Searing Nightmare");
                return true;
            }

            if (SpellID1 == 8092 && Aimsharp.CanCast("Mind Blast", "target", true, false) && Aimsharp.HasBuff("Dark Thought", "player", true) && Wait <= 200)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mind Blast - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Mind Blast");
                return true;
            }

            if (Aimsharp.CastingID("player") == 605 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("MindControl"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mind Control Queue", Color.Purple);
                }
                Aimsharp.Cast("MindControlOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 9484 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("ShackleUndead"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shackle Undead Queue", Color.Purple);
                }
                Aimsharp.Cast("ShackleUndeadOff");
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

            if (Aimsharp.IsCustomCodeOn("ShadowCrash") && Aimsharp.SpellCooldown("Shadow Crash") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("MassDispel") && Aimsharp.SpellCooldown("Mass Dispel") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                if (Aimsharp.CanCast("Silence", "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValue)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Silence", true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast("Silence", "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfter)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Silence", true);
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


            //Auto Desperate Prayer
            if (PlayerHP <= DesperatePrayerHP && Aimsharp.CanCast("Desperate Prayer", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Desperate Prayer - Player HP% " + PlayerHP + " due to setting being on HP% " + DesperatePrayerHP, Color.Purple);
                }
                Aimsharp.Cast("Desperate Prayer", true);
                return true;
            }

            //Auto Dispersion
            if (PlayerHP <= DispersionHP && Aimsharp.CanCast("Dispersion", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Dispersion - Player HP% " + PlayerHP + " due to setting being on HP% " + DispersionHP, Color.Purple);
                }
                Aimsharp.Cast("Dispersion", true);
                return true;
            }

            //Auto Dispel Magic Mouseover
            if (Aimsharp.CanCast("Dispel Magic", "mouseover", true, true))
            {
                if (GetCheckBox("Auto Dispel Magic Mouseover:") && Aimsharp.CustomFunction("DispelMagicCheckMouseover") == 3)
                {
                    Aimsharp.Cast("DispelMagicMO");
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Dispel Magic on Mouseover", Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Body and Soul PWS
            bool BodyandSoul = Aimsharp.IsCustomCodeOn("BodyandSoul");
            if (BodyandSoul && Aimsharp.CanCast("Power Word: Shield", "player", false, true) && !Aimsharp.HasDebuff("Weakened Soul", "player", true) && !Aimsharp.HasDebuff("Weakened Soul", "player", false) && Aimsharp.Talent(2,1) && Moving)
            {
                Aimsharp.Cast("Power Word: Shield");
                return true;
            }
            #endregion

            #region Queues
            bool PsychicScream = Aimsharp.IsCustomCodeOn("PsychicScream");
            if (Aimsharp.SpellCooldown("Psychic Scream") - Aimsharp.GCD() > 2000 && PsychicScream)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Psychic Scream Queue", Color.Purple);
                }
                Aimsharp.Cast("PsychicScreamOff");
                return true;
            }

            if (PsychicScream && Aimsharp.CanCast("Psychic Scream", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Psychic Scream - Queue", Color.Purple);
                }
                Aimsharp.Cast("Psychic Scream");
                return true;
            }

            bool PsychicHorror = Aimsharp.IsCustomCodeOn("PsychicHorror");
            if (Aimsharp.SpellCooldown("Psychic Horror") - Aimsharp.GCD() > 2000 && PsychicHorror)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Psychic Horror Queue", Color.Purple);
                }
                Aimsharp.Cast("PsychicHorrorOff");
                return true;
            }

            if (PsychicHorror && Aimsharp.CanCast("Psychic Horror", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Psychic Horror - Queue", Color.Purple);
                }
                Aimsharp.Cast("PsychicHorrorMO");
                return true;
            }

            bool MindBomb = Aimsharp.IsCustomCodeOn("MindBomb");
            if (Aimsharp.SpellCooldown("Mind Bomb") - Aimsharp.GCD() > 2000 && MindBomb)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mind Bomb Queue", Color.Purple);
                }
                Aimsharp.Cast("MindBombOff");
                return true;
            }

            if (MindBomb && Aimsharp.CanCast("Mind Bomb", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mind Bomb - Queue", Color.Purple);
                }
                Aimsharp.Cast("MindBombMO");
                return true;
            }

            bool ShackleUndead = Aimsharp.IsCustomCodeOn("ShackleUndead");
            if (Aimsharp.SpellCooldown("Shackle Undead") - Aimsharp.GCD() > 2000 && ShackleUndead)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shackle Undead Queue", Color.Purple);
                }
                Aimsharp.Cast("ShackleUndeadOff");
                return true;
            }

            if (ShackleUndead && Aimsharp.CanCast("Shackle Undead", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Shackle Undead - Queue", Color.Purple);
                }
                Aimsharp.Cast("ShackleUndeadMO");
                return true;
            }

            bool PowerInfusion = Aimsharp.IsCustomCodeOn("PowerInfusion");
            if (Aimsharp.SpellCooldown("Power Infusion") - Aimsharp.GCD() > 2000 && PowerInfusion)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Power Infusion Queue", Color.Purple);
                }
                Aimsharp.Cast("PowerInfusionOff");
                return true;
            }

            if (PowerInfusion && Aimsharp.CanCast("Power Infusion", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Power Infusion - Queue", Color.Purple);
                }
                Aimsharp.Cast("PowerInfusionMO");
                return true;
            }

            bool LeapofFaith = Aimsharp.IsCustomCodeOn("LeapofFaith");
            if (Aimsharp.SpellCooldown("Leap of Faith") - Aimsharp.GCD() > 2000 && LeapofFaith)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Leap of Faith Queue", Color.Purple);
                }
                Aimsharp.Cast("LeapofFaithOff");
                return true;
            }

            if (LeapofFaith && Aimsharp.CanCast("Leap of Faith", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Leap of Faith - Queue", Color.Purple);
                }
                Aimsharp.Cast("LeapofFaithMO");
                return true;
            }

            bool MindControl = Aimsharp.IsCustomCodeOn("MindControl");
            if ((Aimsharp.SpellCooldown("Mind Control") - Aimsharp.GCD() > 2000 || Moving) && MindControl)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mind Control Queue", Color.Purple);
                }
                Aimsharp.Cast("MindControlOff");
                return true;
            }

            if (MindControl && Aimsharp.CanCast("Mind Control", "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mind Control - Queue", Color.Purple);
                }
                Aimsharp.Cast("MindControlMO");
                return true;
            }

            string MassDispelCast = GetDropDown("Mass Dispel Cast:");
            bool MassDispel = Aimsharp.IsCustomCodeOn("MassDispel");
            if (Aimsharp.SpellCooldown("Mass Dispel") - Aimsharp.GCD() > 2000 && MassDispel)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mass Dispel Queue", Color.Purple);
                }
                Aimsharp.Cast("MassDispelOff");
                return true;
            }

            if (MassDispel && Aimsharp.CanCast("Mass Dispel", "player", false, true))
            {
                switch (MassDispelCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mass Dispel - " + MassDispelCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Mass Dispel");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mass Dispel - " + MassDispelCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MassDispelC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mass Dispel - " + MassDispelCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MassDispelP");
                        return true;
                }
            }

            string ShadowCrashCast = GetDropDown("Shadow Crash Cast:");
            bool ShadowCrash = Aimsharp.IsCustomCodeOn("ShadowCrash");
            if (Aimsharp.SpellCooldown("Shadow Crash") - Aimsharp.GCD() > 2000 && ShadowCrash)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shadow Crash Queue", Color.Purple);
                }
                Aimsharp.Cast("ShadowCrashOff");
                return true;
            }

            if (ShadowCrash && Aimsharp.CanCast("Shadow Crash", "player", false, true))
            {
                switch (ShadowCrashCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Shadow Crash");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowCrashC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowCrashP");
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

            bool ShadowWordPain = Aimsharp.IsCustomCodeOn("ShadowWordPain");
            if (ShadowWordPain && Aimsharp.CanCast("Shadow Word: Pain", "mouseover", true, true) && Aimsharp.CustomFunction("TargetIsMouseover") == 0 && Aimsharp.CustomFunction("SWPCheckMouseover") == 1)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Shadow Word: Pain - Mouseover", Color.Purple);
                }
                Aimsharp.Cast("ShadowWordPainMO");
                return true;
            }

            bool VampiricTouch = Aimsharp.IsCustomCodeOn("VampiricTouch");
            if (VampiricTouch && Aimsharp.CanCast("Vampiric Touch", "mouseover", true, true) && Aimsharp.CustomFunction("TargetIsMouseover") == 0 && Aimsharp.CustomFunction("VTCheckMouseover") == 1)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Vampiric Touch - Mouseover", Color.Purple);
                }
                Aimsharp.Cast("VampiricTouchMO");
                return true;
            }
            #endregion

            #region Purify Disease
            if (!NoPurify && Aimsharp.CustomFunction("DiseaseCheck") > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != "Purify Disease")
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

                int states = Aimsharp.CustomFunction("DiseaseCheck");
                CleansePlayers target;

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast("Purify Disease", unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
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
                                Aimsharp.Cast("PD_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Purify Disease @ " + unit.Key + " - " + unit.Value, Color.Purple);
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
            if (!NoCycle && Aimsharp.CustomFunction("CycleNotEnabled") == 1 && Aimsharp.CustomFunction("HekiliCycle") == 1 && Enemies > 1)
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

            if (Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                #region Mouseover Spells

                #endregion

                if (Wait <= 200)
                {
                    #region Trinkets
                    //Trinkets
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
                    if (SpellID1 == 325013 && Aimsharp.CanCast("Boon of the Ascended", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Boon of the Ascended - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Boon of the Ascended");
                        return true;
                    }

                    if (SpellID1 == 325020 && Aimsharp.CanCast("Ascended Nova", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ascended Nova - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Ascended Nova");
                        return true;
                    }

                    if (SpellID1 == 325283 && Aimsharp.CanCast("Ascended Blast", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ascended Blast - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Ascended Blast");
                        return true;
                    }

                    if (SpellID1 == 324724 && Aimsharp.CanCast("Unholy Nova", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Unholy Nova - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Unholy Nova");
                        return true;
                    }

                    if (SpellID1 == 327661 && Aimsharp.CanCast("Fae Guardians", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fae Guardians - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Fae Guardians");
                        return true;
                    }

                    if (SpellID1 == 323673 && Aimsharp.CanCast("Mindgames", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mindgames - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Mindgames");
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
                    if (SpellID1 == 15487 && Aimsharp.CanCast("Silence", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Silence - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Silence", true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    if (SpellID1 == 10060 && Aimsharp.CanCast("Power Infusion", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Power Infusion - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Power Infusion");
                        return true;
                    }

                    if (SpellID1 == 19236 && Aimsharp.CanCast("Desperate Prayer", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Desperate Prayer - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Desperate Prayer");
                        return true;
                    }

                    if (SpellID1 == 17 && Aimsharp.CanCast("Power Word: Shield", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Power Word: Shield - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Power Word: Shield");
                        return true;
                    }

                    if (SpellID1 == 21562 && Aimsharp.CanCast("Power Word: Fortitude", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Power Word: Fortitude - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Power Word: Fortitude");
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    if (SpellID1 == 589 && Aimsharp.CanCast("Shadow Word: Pain", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Word: Pain - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Shadow Word: Pain");
                        return true;
                    }

                    if (SpellID1 == 32379 && Aimsharp.CanCast("Shadow Word: Death", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Word: Death - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Shadow Word: Death");
                        return true;
                    }

                    if (SpellID1 == 8092 && Aimsharp.CanCast("Mind Blast", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mind Blast - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Mind Blast");
                        return true;
                    }

                    if (SpellID1 == 528 && Aimsharp.CanCast("Dispel Magic", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Dispel Magic - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Dispel Magic");
                        return true;
                    }
                    #endregion

                    #region Shadow Spells - Player GCD
                    if (SpellID1 == 205385 && Aimsharp.CanCast("Shadow Crash", "player", false, true))
                    {
                        switch (ShadowCrashCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("Shadow Crash");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("ShadowCrashC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("ShadowCrashP");
                                return true;
                        }
                    }

                    if (SpellID1 == 15286 && Aimsharp.CanCast("Vampiric Embrace", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vampiric Embrace - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Vampiric Embrace");
                        return true;
                    }

                    if (SpellID1 == 232698 && Aimsharp.CanCast("Shadowform", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowform - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Shadowform");
                        return true;
                    }

                    if (SpellID1 == 186263 && Aimsharp.CanCast("Shadow Mend", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Mend - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Shadow Mend");
                        return true;
                    }

                    if (SpellID1 == 213634 && Aimsharp.CanCast("Purify Disease", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Purify Disease - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Purify Disease");
                        return true;
                    }
                    #endregion

                    #region Shadow Spells - Target GCD
                    if (SpellID1 == 319952 && Aimsharp.CanCast("Surrender to Madness", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Surrender to Madness - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Surrender to Madness");
                        return true;
                    }

                    if (SpellID1 == 263165 && Aimsharp.CanCast("Void Torrent", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Void Torrent - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Void Torrent");
                        return true;
                    }

                    if (SpellID1 == 200174 && Aimsharp.CanCast("Mindbender", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mindbender - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Mindbender");
                        return true;
                    }

                    if (SpellID1 == 341374 && Aimsharp.CanCast("Damnation", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Damnation - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Damnation");
                        return true;
                    }

                    if (SpellID1 == 341385 && Aimsharp.CanCast("Searing Nightmare", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Searing Nightmare - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Searing Nightmare");
                        return true;
                    }

                    if (SpellID1 == 205448 && Aimsharp.CanCast("Void Bolt", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Void Bolt - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Void Bolt");
                        return true;
                    }

                    if (SpellID1 == 228260 && Aimsharp.CanCast("Void Eruption", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Void Eruption - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Void Eruption");
                        return true;
                    }

                    if (SpellID1 == 34914 && Aimsharp.CanCast("Vampiric Touch", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vampiric Touch - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Vampiric Touch");
                        return true;
                    }

                    if (SpellID1 == 48045 && Aimsharp.CanCast("Mind Sear", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mind Sear - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Mind Sear");
                        return true;
                    }

                    if (SpellID1 == 34433 && Aimsharp.CanCast("Shadowfiend", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowfiend - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Shadowfiend");
                        return true;
                    }

                    if (SpellID1 == 15407 && Aimsharp.CanCast("Mind Flay", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mind Flay - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Mind Flay");
                        return true;
                    }

                    if (SpellID1 == 335467 && Aimsharp.CanCast("Devouring Plague", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Devouring Plague - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Devouring Plague");
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
            bool ShadowformOOC = GetCheckBox("Shadowform Out of Combat:");
            bool FortitudeOOC = GetCheckBox("Fortitude Out of Combat:");
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
            if (SpellID1 == 341385 && Aimsharp.CanCast("Searing Nightmare", "target", true, false))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Searing Nightmare - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Searing Nightmare");
                return true;
            }

            if (Aimsharp.CastingID("player") == 605 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("MindControl"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mind Control Queue", Color.Purple);
                }
                Aimsharp.Cast("MindControlOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 9484 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("ShackleUndead"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shackle Undead Queue", Color.Purple);
                }
                Aimsharp.Cast("ShackleUndeadOff");
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

            if (Aimsharp.IsCustomCodeOn("ShadowCrash") && Aimsharp.SpellCooldown("Shadow Crash") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("MassDispel") && Aimsharp.SpellCooldown("Mass Dispel") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("DoorofShadows") && Aimsharp.SpellCooldown("Door of Shadows") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            bool PsychicScream = Aimsharp.IsCustomCodeOn("PsychicScream");
            if (Aimsharp.SpellCooldown("Psychic Scream") - Aimsharp.GCD() > 2000 && PsychicScream)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Psychic Scream Queue", Color.Purple);
                }
                Aimsharp.Cast("PsychicScreamOff");
                return true;
            }

            if (PsychicScream && Aimsharp.CanCast("Psychic Scream", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Psychic Scream - Queue", Color.Purple);
                }
                Aimsharp.Cast("Psychic Scream");
                return true;
            }

            bool PsychicHorror = Aimsharp.IsCustomCodeOn("PsychicHorror");
            if (Aimsharp.SpellCooldown("Psychic Horror") - Aimsharp.GCD() > 2000 && PsychicHorror)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Psychic Horror Queue", Color.Purple);
                }
                Aimsharp.Cast("PsychicHorrorOff");
                return true;
            }

            if (PsychicHorror && Aimsharp.CanCast("Psychic Horror", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Psychic Horror - Queue", Color.Purple);
                }
                Aimsharp.Cast("PsychicHorrorMO");
                return true;
            }

            bool MindBomb = Aimsharp.IsCustomCodeOn("MindBomb");
            if (Aimsharp.SpellCooldown("Mind Bomb") - Aimsharp.GCD() > 2000 && MindBomb)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mind Bomb Queue", Color.Purple);
                }
                Aimsharp.Cast("MindBombOff");
                return true;
            }

            if (MindBomb && Aimsharp.CanCast("Mind Bomb", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mind Bomb - Queue", Color.Purple);
                }
                Aimsharp.Cast("MindBombMO");
                return true;
            }

            bool ShackleUndead = Aimsharp.IsCustomCodeOn("ShackleUndead");
            if (Aimsharp.SpellCooldown("Shackle Undead") - Aimsharp.GCD() > 2000 && ShackleUndead)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shackle Undead Queue", Color.Purple);
                }
                Aimsharp.Cast("ShackleUndeadOff");
                return true;
            }

            if (ShackleUndead && Aimsharp.CanCast("Shackle Undead", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Shackle Undead - Queue", Color.Purple);
                }
                Aimsharp.Cast("ShackleUndeadMO");
                return true;
            }

            bool PowerInfusion = Aimsharp.IsCustomCodeOn("PowerInfusion");
            if (Aimsharp.SpellCooldown("Power Infusion") - Aimsharp.GCD() > 2000 && PowerInfusion)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Power Infusion Queue", Color.Purple);
                }
                Aimsharp.Cast("PowerInfusionOff");
                return true;
            }

            if (PowerInfusion && Aimsharp.CanCast("Power Infusion", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Power Infusion - Queue", Color.Purple);
                }
                Aimsharp.Cast("PowerInfusionMO");
                return true;
            }

            bool LeapofFaith = Aimsharp.IsCustomCodeOn("LeapofFaith");
            if (Aimsharp.SpellCooldown("Leap of Faith") - Aimsharp.GCD() > 2000 && LeapofFaith)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Leap of Faith Queue", Color.Purple);
                }
                Aimsharp.Cast("LeapofFaithOff");
                return true;
            }

            if (LeapofFaith && Aimsharp.CanCast("Leap of Faith", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Leap of Faith - Queue", Color.Purple);
                }
                Aimsharp.Cast("LeapofFaithMO");
                return true;
            }

            bool MindControl = Aimsharp.IsCustomCodeOn("MindControl");
            if ((Aimsharp.SpellCooldown("Mind Control") - Aimsharp.GCD() > 2000 || Moving) && MindControl)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mind Control Queue", Color.Purple);
                }
                Aimsharp.Cast("MindControlOff");
                return true;
            }

            if (MindControl && Aimsharp.CanCast("Mind Control", "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mind Control - Queue", Color.Purple);
                }
                Aimsharp.Cast("MindControlMO");
                return true;
            }

            string MassDispelCast = GetDropDown("Mass Dispel Cast:");
            bool MassDispel = Aimsharp.IsCustomCodeOn("MassDispel");
            if (Aimsharp.SpellCooldown("Mass Dispel") - Aimsharp.GCD() > 2000 && MassDispel)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mass Dispel Queue", Color.Purple);
                }
                Aimsharp.Cast("MassDispelOff");
                return true;
            }

            if (MassDispel && Aimsharp.CanCast("Mass Dispel", "player", false, true))
            {
                switch (MassDispelCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mass Dispel - " + MassDispelCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Mass Dispel");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mass Dispel - " + MassDispelCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MassDispelC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mass Dispel - " + MassDispelCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MassDispelP");
                        return true;
                }
            }

            string ShadowCrashCast = GetDropDown("Shadow Crash Cast:");
            bool ShadowCrash = Aimsharp.IsCustomCodeOn("ShadowCrash");
            if (Aimsharp.SpellCooldown("Shadow Crash") - Aimsharp.GCD() > 2000 && ShadowCrash)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shadow Crash Queue", Color.Purple);
                }
                Aimsharp.Cast("ShadowCrashOff");
                return true;
            }

            if (ShadowCrash && Aimsharp.CanCast("Shadow Crash", "player", false, true))
            {
                switch (ShadowCrashCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Shadow Crash");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowCrashC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowCrashP");
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
            if (SpellID1 == 21562 && Aimsharp.CanCast("Power Word: Fortitude", "player", false, true) && FortitudeOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Power Word: Fortitude - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Power Word: Fortitude");
                return true;
            }

            if (SpellID1 == 232698 && Aimsharp.CanCast("Shadowform", "player", false, true) && ShadowformOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Shadowform - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Shadowform");
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

            //Auto Body and Soul PWS
            bool BodyandSoul = Aimsharp.IsCustomCodeOn("BodyandSoul");
            if (BodyandSoul && Aimsharp.CanCast("Power Word: Shield", "player", false, true) && !Aimsharp.HasDebuff("Weakened Soul", "player", true) && !Aimsharp.HasDebuff("Weakened Soul", "player", false) && Aimsharp.Talent(2, 1) && Moving)
            {
                Aimsharp.Cast("Power Word: Shield");
                return true;
            }
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 40 && TargetInCombat)
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