using System.Linq;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class SnoogensPVEPaladinRetribution : Rotation
    {
        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle", "NoCleanse", "FinalReckoning", "BlessingofFreedom", "BlessingofProtection", "BlessingofSacrifice", "DivineShield", "AshenHallow", "HammerofJustice", "BlindingLight", "Repentance", "DivineSteed", "WordofGlory", "DoorofShadows" };
        private List<string> m_DebuffsList = new List<string> { "Gripping Infection", "Wretched Poison", "Barbed Shackles", "Bindings of Misery", };
        private List<string> m_BuffsList = new List<string> { "Selfless Healer", "Shield of Vengeance", "Divine Steed", };
        private List<string> m_BloodlustBuffsList = new List<string> { "Bloodlust", "Heroism", "Time Warp", "Primal Rage", "Drums of Rage" };
        private List<string> m_ItemsList = new List<string> { "Phial of Serenity", "Healthstone", "Spiritual Healing Potion", };

        private List<string> m_SpellBook_General = new List<string> {
            //Covenants
            "Divine Toll", //304971
            "Ashen Hallow", //316958
            "Vanquisher's Hammer", //328204
            "Blessing of Summer", //328620
            "Blessing of Autumn", //328622
            "Blessing of Winter", //328281
            "Blessing of Spring", //328282

            //Interrupt
            "Rebuke", //96231

            //General
            "Avenging Wrath", //31884
            "Blessing of Freedom", //1044
            "Blessing of Protection", //1022
            "Crusader Strike", //35395
            "Blessing of Sacrifice", //6940
            "Divine Shield", //642
            "Consecration", //26573
            "Divine Steed", //190784
            "Lay on Hands", //633
            "Flash of Light", //19750
            "Hammer of Justice", //853
            "Hammer of Wrath", //24275
            "Judgment", //20271
            "Word of Glory", //85673

            //Retribution
            "Blade of Justice", //184575
            "Cleanse Toxins", //213644
            "Shield of Vengeance", //184662
            "Divine Storm", //53385
            "Templar's Verdict", //85256
            "Final Verdict", //336872
            "Wake of Ashes", //255937

            "Execution Sentence", //343527
            "Blinding Light", //115750
            "Repentance", //20066
            "Eye for an Eye", //205191
            "Holy Avenger", //105809
            "Seraphim", //152262
            "Justicar's Vengeance", //215661
            "Crusade", //231895
            "Final Reckoning", //343721

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

        public string FrozenBinds()
        {
            if ((Aimsharp.CastingID("target") == 320788 || Aimsharp.CastingID("target") == 323730) && Aimsharp.CustomFunction("TargetingParty") == 5)
                return "player";

            if ((Aimsharp.CastingID("target") == 320788 || Aimsharp.CastingID("target") == 323730) && Aimsharp.CustomFunction("TargetingParty") == 1)
                return "party1";

            if ((Aimsharp.CastingID("target") == 320788 || Aimsharp.CastingID("target") == 323730) && Aimsharp.CustomFunction("TargetingParty") == 2)
                return "party2";

            if ((Aimsharp.CastingID("target") == 320788 || Aimsharp.CastingID("target") == 323730) && Aimsharp.CustomFunction("TargetingParty") == 3)
                return "party3";

            if ((Aimsharp.CastingID("target") == 320788 || Aimsharp.CastingID("target") == 323730) && Aimsharp.CustomFunction("TargetingParty") == 4)
                return "party4";

            return "NONE";
        }

        public string Carnage()
        {
            if ((Aimsharp.CastingID("target") == 356925 || Aimsharp.CastingID("target") == 356924) && Aimsharp.CustomFunction("TargetingParty") == 5)
                return "player";

            if ((Aimsharp.CastingID("target") == 356925 || Aimsharp.CastingID("target") == 356924) && Aimsharp.CustomFunction("TargetingParty") == 1)
                return "party1";

            if ((Aimsharp.CastingID("target") == 356925 || Aimsharp.CastingID("target") == 356924) && Aimsharp.CustomFunction("TargetingParty") == 2)
                return "party2";

            if ((Aimsharp.CastingID("target") == 356925 || Aimsharp.CastingID("target") == 356924) && Aimsharp.CustomFunction("TargetingParty") == 3)
                return "party3";

            if ((Aimsharp.CastingID("target") == 356925 || Aimsharp.CastingID("target") == 356924) && Aimsharp.CustomFunction("TargetingParty") == 4)
                return "party4";

            return "NONE";
        }
        #endregion

        #region CanCasts

        #endregion

        #region Debuffs
        public int UnitDebuffFreedomPriority(string unit)
        {
            if (Aimsharp.HasDebuff("Gripping Infection", unit, false))
                return Aimsharp.DebuffRemaining("Gripping Infection", unit, false);

            if (Aimsharp.HasDebuff("Wretched Poison", unit, false))
                return Aimsharp.DebuffRemaining("Wretched Poison", unit, false);

            if (Aimsharp.HasDebuff("Barbed Shackles", unit, false))
                return Aimsharp.DebuffRemaining("Barbed Shackles", unit, false);

            if (Aimsharp.HasDebuff("Bindings of Misery", unit, false) && unit == "player")
                return Aimsharp.DebuffRemaining("Bindings of Misery", unit, false);

            return 0;
        }
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

            //HP Pot
            Macros.Add("SpiritualHPPotion", "/use Spiritual Healing Potion");

            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + (Aimsharp.Latency + 100));

            //Focus Units
            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");

            //Focus Spells
            Macros.Add("CT_FOC", "/cast [@focus] Cleanse Toxins");
            Macros.Add("FOL_FOC", "/cast [@focus] Flash of Light");
            Macros.Add("WOG_FOC", "/cast [@focus] Word of Glory");
            Macros.Add("LOH_FOC", "/cast [@focus] Lay on Hands");
            Macros.Add("BOS_FOC", "/cast [@focus] Blessing of Sacrifice");
            Macros.Add("BOF_FOC", "/cast [@focus] Blessing of Freedom");
            Macros.Add("BOP_FOC", "/cast [@focus] Blessing of Protection");

            //Queues
            Macros.Add("FinalReckoningOff", "/" + FiveLetters + " FinalReckoning");
            Macros.Add("FinalReckoningC", "/cast [@cursor] Final Reckoning");
            Macros.Add("FinalReckoningP", "/cast [@player] Final Reckoning");

            Macros.Add("AshenHallowOff", "/" + FiveLetters + " AshenHallow");
            Macros.Add("AshenHallowC", "/cast [@cursor] Ashen Hallow");
            Macros.Add("AshenHallowP", "/cast [@player] Ashen Hallow");

            Macros.Add("BlessingofFreedomOff", "/" + FiveLetters + " BlessingofFreedom");
            Macros.Add("BlessingofFreedomMO", "/cast [@mouseover] Blessing of Freedom");

            Macros.Add("BlessingofProtectionOff", "/" + FiveLetters + " BlessingofProtection");
            Macros.Add("BlessingofProtectionMO", "/cast [@mouseover] Blessing of Protection");

            Macros.Add("BlessingofSacrificeOff", "/" + FiveLetters + " BlessingofSacrifice");
            Macros.Add("BlessingofSacrificeMO", "/cast [@mouseover] Blessing of Sacrifice");

            Macros.Add("DivineShieldOff", "/" + FiveLetters + " DivineShield");
            Macros.Add("DivineSteedOff", "/" + FiveLetters + " DivineSteed");
            Macros.Add("HammerofJusticeOff", "/" + FiveLetters + " HammerofJustice");
            Macros.Add("BlindingLightOff", "/" + FiveLetters + " BlindingLight");
            Macros.Add("RepentanceOff", "/" + FiveLetters + " Repentance");

            Macros.Add("RepentanceMO", "/cast [@mouseover] Repentance");

            Macros.Add("DivineToll", "/cast Divine Toll");

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
            CustomFunctions.Add("HekiliID1", "local loading, finished = IsAddOnLoaded(\"Hekili\") \r\nif loading == true and finished == true then \r\n    local id=Hekili_GetRecommendedAbility(\"Primary\",1)\r\n\tif id ~= nil then\r\n\t\r\n    if id<0 then \r\n\t    local spell = Hekili.Class.abilities[id]\r\n\t    if spell ~= nil and spell.item ~= nil then \r\n\t    \tid=spell.item\r\n\t\t    local topTrinketLink = GetInventoryItemLink(\"player\",13)\r\n\t\t    local bottomTrinketLink = GetInventoryItemLink(\"player\",14)\r\n\t\t    if topTrinketLink  ~= nil then\r\n                local trinketid = GetItemInfoInstant(topTrinketLink)\r\n                if trinketid ~= nil then\r\n\t\t\t        if trinketid == id then\r\n\t\t\t\t        return 1\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t\t    if bottomTrinketLink ~= nil then\r\n                local trinketid = GetItemInfoInstant(bottomTrinketLink)\r\n                if trinketid ~= nil then\r\n    \t\t\t    if trinketid == id then\r\n\t    \t\t\t    return 2\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t\t    if weaponLink ~= nil then\r\n                local weaponid = GetItemInfoInstant(weaponLink)\r\n                if weaponid ~= nil then\r\n    \t\t\t    if weaponid == id then\r\n\t    \t\t\t    return 3\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t    end \r\n    end\r\n    return id\r\nend\r\nend\r\nreturn 0");

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

            CustomFunctions.Add("DiseasePoisonCheck", "local y=0; " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"player\",i,\"RAID\"); " +
            "if type ~= nil and (type == \"Disease\" or type == \"Poison\") then y = y +1; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
            "if type ~= nil and (type == \"Disease\" or type == \"Poison\") then y = y +2; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
            "if type ~= nil and (type == \"Disease\" or type == \"Poison\") then y = y +4; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
            "if type ~= nil and (type == \"Disease\" or type == \"Poison\") then y = y +8; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
            "if type ~= nil and (type == \"Disease\" or type == \"Poison\") then y = y +16; end end " +
            "return y");

            CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
            "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
            "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
            "\nreturn foc");

            CustomFunctions.Add("TargetingParty", "local result = 0" +
            "\nif UnitExists('target') and UnitIsUnit('targettarget','party1') then result = 1 end" +
            "\nif UnitExists('target') and UnitIsUnit('targettarget','party2') then result = 2 end" +
            "\nif UnitExists('target') and UnitIsUnit('targettarget','party3') then result = 3 end" +
            "\nif UnitExists('target') and UnitIsUnit('targettarget','party4') then result = 4 end" +
            "\nif UnitExists('target') and UnitIsUnit('targettarget','player') then result = 5 end" +
            "\nreturn result");
        }
        #endregion

        public override void LoadSettings()
        {
            Settings.Add(new Setting("First 5 Letters of the Addon:", "xxxxx"));
            Settings.Add(new Setting("Race:", m_RaceList, "orc"));
            Settings.Add(new Setting("Ingame World Latency:", 1, 200, 50));
            Settings.Add(new Setting(" "));
            Settings.Add(new Setting("Use Trinkets on CD, dont wait for Hekili:", false));
            Settings.Add(new Setting("Auto Healthstone @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Auto Phial of Serenity @ HP%", 0, 100, 35));
            Settings.Add(new Setting("Auto Spiritual Potion @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Kicks/Interrupts"));
            Settings.Add(new Setting("Kick at milliseconds remaining", 50, 1500, 500));
            Settings.Add(new Setting("Kick channels after milliseconds", 50, 1500, 500));
            Settings.Add(new Setting("General"));
            Settings.Add(new Setting("Auto Start Combat:", true));
            Settings.Add(new Setting("Auto Divine Shield @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Lay on Hands @ HP%", 0, 100, 20));
            Settings.Add(new Setting("Auto Shield of Vengeance @ HP%", 0, 100, 50));
            Settings.Add(new Setting("Auto Word of Glory @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Auto Selfless Healer @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Final Reckoning Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Ashen Hallow Cast:", m_CastingList, "Manual"));
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

            Aimsharp.PrintMessage("Snoogens PVE - Paladin Retribution", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon", Color.Red);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything", Color.Brown);
            Aimsharp.PrintMessage("Hekili > Toggles > Bind \"Cooldowns\" & \"Display Mode\"", Color.Brown);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx NoCleanse - Disables Cleanse", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx FinalReckoning - Casts Final Reckoning @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx AshenHallow - Casts Ashen Hallow @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx DivineShield - Casts Divine Shield @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx BlindingLight - Casts Blinding Light @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx HammerofJustice - Casts Hammer of Justice @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx Repentance - Casts Repentance @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx DivineSteed - Casts Divine Steed @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx WordofGlory - Enables Word of Glory as a Spender based on HP%", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx BlessingofFreedom - Casts Blessing of Freedom @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx BlessingofProtection - Casts Blessing of Protection @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx BlessingofSacrifice - Casts Blessing of Sacrifice @ Mouseover next GCD", Color.Yellow);
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

            bool NoInterrupts = Aimsharp.IsCustomCodeOn("NoInterrupts");
            bool NoCycle = Aimsharp.IsCustomCodeOn("NoCycle");
            bool NoCleanse = Aimsharp.IsCustomCodeOn("NoCleanse");

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

            int DivineShieldHP = GetSlider("Auto Divine Shield @ HP%");
            int LayonHandsHP = GetSlider("Auto Lay on Hands @ HP%");
            int ShieldofVengeanceHP = GetSlider("Auto Shield of Vengeance @ HP%");
            int WordofGloryHP = GetSlider("Auto Word of Glory @ HP%");
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

            if (Aimsharp.IsCustomCodeOn("FinalReckoning") && Aimsharp.SpellCooldown("Final Reckoning") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("AshenHallow") && Aimsharp.SpellCooldown("Ashen Hallow") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                if (Aimsharp.CanCast("Rebuke", "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValue)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Rebuke", true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast("Rebuke", "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfter)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Rebuke", true);
                        return true;
                    }
                }
            }
            #endregion

            #region Auto Spells and Items
            //Auto Frozen Binds Freedom
            if (FrozenBinds() != "NONE")
            {
                if (Aimsharp.CanCast("Blessing of Freedom", FrozenBinds(), false, true) && (FrozenBinds() == "player" ||  Aimsharp.Range(FrozenBinds()) <= 40))
                {
                    if (!UnitFocus(FrozenBinds()))
                    {
                        Aimsharp.Cast("FOC_" + FrozenBinds(), true);
                        return true;
                    }
                    else
                    {
                        if (UnitFocus(FrozenBinds()))
                        {
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Blessing of Freedom @ " + FrozenBinds() + " - Frozen Binds", Color.Purple);
                            }
                            Aimsharp.Cast("BOF_FOC");
                            return true;
                        }
                    }
                }
            }

            //Auto Carnage Protection
            if (Carnage() != "NONE")
            {
                if (Aimsharp.CanCast("Blessing of Protection", Carnage(), false, true) && (Carnage() == "player" || Aimsharp.Range(Carnage()) <= 40))
                {
                    if (!UnitFocus(Carnage()))
                    {
                        Aimsharp.Cast("FOC_" + Carnage(), true);
                        return true;
                    }
                    else
                    {
                        if (UnitFocus(Carnage()))
                        {
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Blessing of Protection @ " + Carnage() + " - Carnage", Color.Purple);
                            }
                            Aimsharp.Cast("BOP_FOC");
                            return true;
                        }
                    }
                }
            }

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

            //Auto Phial of Serenity
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

            //Auto Spiritual Healing Potion
            if (Aimsharp.CanUseItem("Spiritual Healing Potion", false) && Aimsharp.ItemCooldown("Spiritual Healing Potion") == 0)
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Spiritual Potion @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Spiritual Healing Potion - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Spiritual Potion @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("SpiritualHPPotion");
                    return true;
                }
            }

            #region Special Freedom
            if ((UnitDebuffFreedomPriority("player") > 0 || UnitDebuffFreedomPriority("party1") > 0 || UnitDebuffFreedomPriority("party2") > 0 || UnitDebuffFreedomPriority("party3") > 0 || UnitDebuffFreedomPriority("party4") > 0) && Aimsharp.GroupSize() <= 5)
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

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    if (Aimsharp.CanCast("Blessing of Freedom", unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && UnitDebuffFreedomPriority(unit.Key) > 0)
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
                                Aimsharp.Cast("BOF_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Blessing of Freedom @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Selfless Healer
            if (UnitBelowThreshold(GetSlider("Auto Selfless Healer @ HP%")) && Aimsharp.BuffStacks("Selfless Healer", "player", true) >= 4)
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
                    if (Aimsharp.CanCast("Flash of Light", unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && Aimsharp.Health(unit.Key) <= GetSlider("Auto Selfless Healer @ HP%"))
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
                                Aimsharp.Cast("FOL_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Flash of Light @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Word of Glory
            if (Aimsharp.IsCustomCodeOn("WordofGlory") && UnitBelowThreshold(GetSlider("Auto Word of Glory @ HP%")) && Aimsharp.CanCast("Word of Glory", "player", false, true))
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
                    if (Aimsharp.CanCast("Word of Glory", unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && Aimsharp.Health(unit.Key) <= GetSlider("Auto Word of Glory @ HP%"))
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
                                Aimsharp.Cast("WOG_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Word of Glory @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Lay on Hands
            if (UnitBelowThreshold(GetSlider("Auto Lay on Hands @ HP%")) && Aimsharp.CanCast("Lay on Hands", "player", false, true))
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
                    if (Aimsharp.CanCast("Lay on Hands", unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && Aimsharp.Health(unit.Key) <= GetSlider("Auto Lay on Hands @ HP%"))
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
                                Aimsharp.Cast("LOH_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Lay on Hands @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            //Auto Divine Shield
            if (PlayerHP <= DivineShieldHP && Aimsharp.CanCast("Divine Shield", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Divine Shield - Player HP% " + PlayerHP + " due to setting being on HP% " + DivineShieldHP, Color.Purple);
                }
                Aimsharp.Cast("Divine Shield");
                return true;
            }

            //Auto Shield of Vengeance
            if (PlayerHP <= ShieldofVengeanceHP && Aimsharp.CanCast("Shield of Vengeance", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Shield of Vengeance - Player HP% " + PlayerHP + " due to setting being on HP% " + ShieldofVengeanceHP, Color.Purple);
                }
                Aimsharp.Cast("Shield of Vengeance");
                return true;
            }

            #region Shield of Vengeance Sacrifice
            if (Aimsharp.HasBuff("Shield of Vengeance", "player", true) && Aimsharp.BuffRemaining("Shield of Vengeance", "player", true) >= 12000 && Aimsharp.SpellCooldown("Blessing of Sacrifice") - Aimsharp.GCD() <= 0 && Aimsharp.GroupSize() <= 5)
            {
                var partysize = Aimsharp.GroupSize();
                var tank = "NONE";
                for (int i = 1; i < partysize; i++)
                {
                    var partyunit = ("party" + i);
                    if (Aimsharp.Health(partyunit) > 0 && Aimsharp.Range(partyunit) <= 40 && Aimsharp.GetSpec(partyunit) == "TANK")
                    {
                        tank = partyunit;
                    }
                }

                if (Aimsharp.CanCast("Blessing of Sacrifice", tank, true, true) && tank != "NONE")
                {
                    if (!UnitFocus(tank))
                    {
                        Aimsharp.Cast("FOC_" + tank, true);
                        return true;
                    }
                    else
                    {
                        if (UnitFocus(tank))
                        {
                            Aimsharp.Cast("BOS_FOC");
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Blessing of Sacrifice @ " + tank + " - " + Aimsharp.Health(tank), Color.Purple);
                            }
                            return true;
                        }
                    }
                }
            }
            #endregion
            #endregion

            #region Queues
            bool Repentance = Aimsharp.IsCustomCodeOn("Repentance");
            if (Aimsharp.SpellCooldown("Repentance") - Aimsharp.GCD() > 2000 && Repentance)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Repentance Queue", Color.Purple);
                }
                Aimsharp.Cast("RepentanceOff");
                return true;
            }

            if (Repentance && Aimsharp.CanCast("Repentance", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Repentance - Queue", Color.Purple);
                }
                Aimsharp.Cast("RepentanceMO");
                return true;
            }

            bool HammerofJustice = Aimsharp.IsCustomCodeOn("HammerofJustice");
            if (Aimsharp.SpellCooldown("Hammer of Justice") - Aimsharp.GCD() > 2000 && HammerofJustice)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Hammer of Justice Queue", Color.Purple);
                }
                Aimsharp.Cast("HammerofJusticeOff");
                return true;
            }

            if (HammerofJustice && Aimsharp.CanCast("Hammer of Justice", "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Hammer of Justice - Queue", Color.Purple);
                }
                Aimsharp.Cast("Hammer of Justice");
                return true;
            }

            bool BlindingLight = Aimsharp.IsCustomCodeOn("BlindingLight");
            if (Aimsharp.SpellCooldown("Blinding Light") - Aimsharp.GCD() > 2000 && BlindingLight)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blinding Light Queue", Color.Purple);
                }
                Aimsharp.Cast("BlindingLightOff");
                return true;
            }

            if (BlindingLight && Aimsharp.CanCast("Blinding Light", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blinding Light - Queue", Color.Purple);
                }
                Aimsharp.Cast("Blinding Light");
                return true;
            }

            bool DivineSteed = Aimsharp.IsCustomCodeOn("DivineSteed");
            if (DivineSteed && Aimsharp.HasBuff("Divine Steed", "player", true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Divine Steed queue toggle", Color.Purple);
                }
                Aimsharp.Cast("DivineSteedOff");
                return true;
            }

            if (DivineSteed && Aimsharp.CanCast("Divine Steed", "player", false, true) && !Aimsharp.HasBuff("Divine Steed", "player", true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Divine Steed - Queue", Color.Purple);
                }
                Aimsharp.Cast("Divine Steed");
                return true;
            }

            bool DivineShield = Aimsharp.IsCustomCodeOn("DivineShield");
            if (Aimsharp.SpellCooldown("Divine Shield") - Aimsharp.GCD() > 2000 && DivineShield)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Divine Shield Queue", Color.Purple);
                }
                Aimsharp.Cast("DivineShieldOff");
                return true;
            }

            if (DivineShield && Aimsharp.CanCast("Divine Shield", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Divine Shield - Queue", Color.Purple);
                }
                Aimsharp.Cast("Divine Shield");
                return true;
            }

            bool BlessingofSacrifice = Aimsharp.IsCustomCodeOn("BlessingofSacrifice");
            if (Aimsharp.SpellCooldown("Blessing of Sacrifice") - Aimsharp.GCD() > 2000 && BlessingofSacrifice)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blessing of Sacrifice Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofSacrificeOff");
                return true;
            }

            if (BlessingofSacrifice && Aimsharp.CanCast("Blessing of Sacrifice", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of Sacrifice - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofSacrificeMO");
                return true;
            }

            bool BlessingofProtection = Aimsharp.IsCustomCodeOn("BlessingofProtection");
            if (Aimsharp.SpellCooldown("Blessing of Protection") - Aimsharp.GCD() > 2000 && BlessingofProtection)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blessing of Protection Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofProtectionOff");
                return true;
            }

            if (BlessingofProtection && Aimsharp.CanCast("Blessing of Protection", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of Protection - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofProtectionMO");
                return true;
            }

            bool BlessingofFreedom = Aimsharp.IsCustomCodeOn("BlessingofFreedom");
            if (Aimsharp.SpellCooldown("Blessing of Freedom") - Aimsharp.GCD() > 2000 && BlessingofFreedom)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blessing of Freedom Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofFreedomOff");
                return true;
            }

            if (BlessingofFreedom && Aimsharp.CanCast("Blessing of Freedom", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of Freedom - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofFreedomMO");
                return true;
            }

            string AshenHallowCast = GetDropDown("Ashen Hallow Cast:");
            bool AshenHallow = Aimsharp.IsCustomCodeOn("AshenHallow");
            if (Aimsharp.SpellCooldown("Ashen Hallow") - Aimsharp.GCD() > 2000 && AshenHallow)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Ashen Hallow Queue", Color.Purple);
                }
                Aimsharp.Cast("AshenHallowOff");
                return true;
            }

            if (AshenHallow && Aimsharp.CanCast("Ashen Hallow", "player", false, true) && (AshenHallowCast != "Player" || AshenHallowCast == "Player" && Aimsharp.Range("target") <= 3))
            {
                switch (AshenHallowCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Ashen Hallow");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("AshenHallowC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("AshenHallowP");
                        return true;
                }
            }

            string FinalReckoningCast = GetDropDown("Final Reckoning Cast:");
            bool FinalReckoning = Aimsharp.IsCustomCodeOn("FinalReckoning");
            if (Aimsharp.SpellCooldown("Final Reckoning") - Aimsharp.GCD() > 2000 && FinalReckoning)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Final Reckoning Queue", Color.Purple);
                }
                Aimsharp.Cast("FinalReckoningOff");
                return true;
            }

            if (FinalReckoning && Aimsharp.CanCast("Final Reckoning", "player", false, true) && (FinalReckoningCast != "Player" || FinalReckoningCast == "Player" && Aimsharp.Range("target") <= 3))
            {
                switch (FinalReckoningCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Final Reckoning");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FinalReckoningC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FinalReckoningP");
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

            #region Cleanse Toxins
            if (!NoCleanse && Aimsharp.CustomFunction("DiseasePoisonCheck") > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != "Cleanse Toxins")
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

                int states = Aimsharp.CustomFunction("DiseasePoisonCheck");
                CleansePlayers target;

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast("Cleanse Toxins", unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
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
                                Aimsharp.Cast("CT_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Cleanse Toxins @ " + unit.Key + " - " + unit.Value, Color.Purple);
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

                    if ((SpellID1 == 28730 || SpellID1 == 25046 || SpellID1 == 50613 || SpellID1 == 69179 || SpellID1 == 80483 || SpellID1 == 129597 || SpellID1 == 155145) && Aimsharp.CanCast("Arcane Torrent", "player", true, false) && MeleeRange)
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
                    if (SpellID1 == 304971 && Aimsharp.CanCast("Divine Toll", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Divine Toll - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("DivineToll");
                        return true;
                    }

                    if (SpellID1 == 316958 && Aimsharp.CanCast("Ashen Hallow", "player", false, true))
                    {
                        switch (AshenHallowCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("Ashen Hallow");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("AshenHallowC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("AshenHallowP");
                                return true;
                        }
                    }

                    if (SpellID1 == 328204 && Aimsharp.CanCast("Vanquisher's Hammer", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vanquisher's Hammer - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Vanquisher's Hammer");
                        return true;
                    }

                    if (SpellID1 == 328620 && Aimsharp.CanCast("Blessing of Summer", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blessing of Summer - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Blessing of Summer");
                        return true;
                    }

                    if (SpellID1 == 328622 && Aimsharp.CanCast("Blessing of Autumn", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blessing of Autumn - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Blessing of Autumn");
                        return true;
                    }

                    if (SpellID1 == 328281 && Aimsharp.CanCast("Blessing of Winter", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blessing of Winter - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Blessing of Winter");
                        return true;
                    }

                    if (SpellID1 == 328282 && Aimsharp.CanCast("Blessing of Spring", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blessing of Spring - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Blessing of Spring");
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
                    if (SpellID1 == 96231 && Aimsharp.CanCast("Rebuke", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rebuke - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Rebuke", true);
                        return true;
                    }

                    if (SpellID1 == 31884 && Aimsharp.CanCast("Avenging Wrath", "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Avenging Wrath - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Avenging Wrath", true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    if (SpellID1 == 642 && Aimsharp.CanCast("Divine Shield", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Divine Shield - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Divine Shield");
                        return true;
                    }

                    if (SpellID1 == 2645 && Aimsharp.CanCast("Blessing of Freedom", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blessing of Freedom - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Blessing of Freedom");
                        return true;
                    }

                    if (SpellID1 == 26573 && Aimsharp.CanCast("Consecration", "player", false, true) && MeleeRange && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Consecration - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Consecration");
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    if (SpellID1 == 35395 && Aimsharp.CanCast("Crusader Strike", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Crusader Strike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Crusader Strike");
                        return true;
                    }

                    if (SpellID1 == 24275 && Aimsharp.CanCast("Hammer of Wrath", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Hammer of Wrath - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Hammer of Wrath");
                        return true;
                    }

                    if (SpellID1 == 20271 && Aimsharp.CanCast("Judgment", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Judgment - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Judgment");
                        return true;
                    }
                    #endregion

                    #region Retribution Spells - Player GCD
                    if (SpellID1 == 343721 && Aimsharp.CanCast("Final Reckoning", "player", false, true) && (FinalReckoningCast != "Player" || FinalReckoningCast == "Player" && Aimsharp.Range("target") <= 3))
                    {
                        switch (FinalReckoningCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("Final Reckoning");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("FinalReckoningC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("FinalReckoningP");
                                return true;
                        }
                    }

                    if (SpellID1 == 231895 && Aimsharp.CanCast("Crusade", "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Crusade - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Crusade");
                        return true;
                    }

                    if (SpellID1 == 152262 && Aimsharp.CanCast("Seraphim", "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Seraphim - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Seraphim");
                        return true;
                    }

                    if (SpellID1 == 105809 && Aimsharp.CanCast("Holy Avenger", "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Holy Avenger - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Holy Avenger");
                        return true;
                    }

                    if (SpellID1 == 184662 && Aimsharp.CanCast("Shield of Vengeance", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shield of Vengeance - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Shield of Vengeance");
                        return true;
                    }

                    if (SpellID1 == 205191 && Aimsharp.CanCast("Eye for an Eye", "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Eye for an Eye - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Eye for an Eye");
                        return true;
                    }

                    if (SpellID1 == 53385 && Aimsharp.CanCast("Divine Storm", "player", false, true) && Aimsharp.Range("target") <= 3)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Divine Storm - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Divine Storm");
                        return true;
                    }

                    if (SpellID1 == 255937 && Aimsharp.CanCast("Wake of Ashes", "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wake of Ashes - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Wake of Ashes");
                        return true;
                    }
                    #endregion

                    #region Retribution Spells - Target GCD
                    if (SpellID1 == 215661 && Aimsharp.CanCast("Justicar's Vengeance", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Justicar's Vengeance - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Justicar's Vengeance");
                        return true;
                    }

                    if (SpellID1 == 184575 && Aimsharp.CanCast("Blade of Justice", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blade of Justice - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Blade of Justice");
                        return true;
                    }

                    if (SpellID1 == 85256 && Aimsharp.CanCast("Templar's Verdict", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Templar's Verdict - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Templar's Verdict");
                        return true;
                    }

                    if (SpellID1 == 336872 && Aimsharp.CanCast("Final Verdict", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Final Verdict - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Final Verdict");
                        return true;
                    }

                    if (SpellID1 == 343527 && Aimsharp.CanCast("Execution Sentence", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Execution Sentence - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Execution Sentence");
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

            if (Aimsharp.IsCustomCodeOn("FinalReckoning") && Aimsharp.SpellCooldown("Final Reckoning") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("AshenHallow") && Aimsharp.SpellCooldown("Ashen Hallow") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("DoorofShadows") && Aimsharp.SpellCooldown("Door of Shadows") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            bool Repentance = Aimsharp.IsCustomCodeOn("Repentance");
            if (Aimsharp.SpellCooldown("Repentance") - Aimsharp.GCD() > 2000 && Repentance)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Repentance Queue", Color.Purple);
                }
                Aimsharp.Cast("RepentanceOff");
                return true;
            }

            if (Repentance && Aimsharp.CanCast("Repentance", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Repentance - Queue", Color.Purple);
                }
                Aimsharp.Cast("RepentanceMO");
                return true;
            }

            bool HammerofJustice = Aimsharp.IsCustomCodeOn("HammerofJustice");
            if (Aimsharp.SpellCooldown("Hammer of Justice") - Aimsharp.GCD() > 2000 && HammerofJustice)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Hammer of Justice Queue", Color.Purple);
                }
                Aimsharp.Cast("HammerofJusticeOff");
                return true;
            }

            if (HammerofJustice && Aimsharp.CanCast("Hammer of Justice", "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Hammer of Justice - Queue", Color.Purple);
                }
                Aimsharp.Cast("Hammer of Justice");
                return true;
            }

            bool BlindingLight = Aimsharp.IsCustomCodeOn("BlindingLight");
            if (Aimsharp.SpellCooldown("Blinding Light") - Aimsharp.GCD() > 2000 && BlindingLight)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blinding Light Queue", Color.Purple);
                }
                Aimsharp.Cast("BlindingLightOff");
                return true;
            }

            if (BlindingLight && Aimsharp.CanCast("Blinding Light", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blinding Light - Queue", Color.Purple);
                }
                Aimsharp.Cast("Blinding Light");
                return true;
            }

            bool DivineSteed = Aimsharp.IsCustomCodeOn("DivineSteed");
            if (DivineSteed && Aimsharp.HasBuff("Divine Steed", "player", true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Divine Steed queue toggle", Color.Purple);
                }
                Aimsharp.Cast("DivineSteedOff");
                return true;
            }

            if (DivineSteed && Aimsharp.CanCast("Divine Steed", "player", false, true) && !Aimsharp.HasBuff("Divine Steed", "player", true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Divine Steed - Queue", Color.Purple);
                }
                Aimsharp.Cast("Divine Steed");
                return true;
            }

            bool DivineShield = Aimsharp.IsCustomCodeOn("DivineShield");
            if (Aimsharp.SpellCooldown("Divine Shield") - Aimsharp.GCD() > 2000 && DivineShield)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Divine Shield Queue", Color.Purple);
                }
                Aimsharp.Cast("DivineShieldOff");
                return true;
            }

            if (DivineShield && Aimsharp.CanCast("Divine Shield", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Divine Shield - Queue", Color.Purple);
                }
                Aimsharp.Cast("Divine Shield");
                return true;
            }

            bool BlessingofSacrifice = Aimsharp.IsCustomCodeOn("BlessingofSacrifice");
            if (Aimsharp.SpellCooldown("Blessing of Sacrifice") - Aimsharp.GCD() > 2000 && BlessingofSacrifice)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blessing of Sacrifice Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofSacrificeOff");
                return true;
            }

            if (BlessingofSacrifice && Aimsharp.CanCast("Blessing of Sacrifice", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of Sacrifice - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofSacrificeMO");
                return true;
            }

            bool BlessingofProtection = Aimsharp.IsCustomCodeOn("BlessingofProtection");
            if (Aimsharp.SpellCooldown("Blessing of Protection") - Aimsharp.GCD() > 2000 && BlessingofProtection)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blessing of Protection Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofProtectionOff");
                return true;
            }

            if (BlessingofProtection && Aimsharp.CanCast("Blessing of Protection", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of Protection - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofProtectionMO");
                return true;
            }

            bool BlessingofFreedom = Aimsharp.IsCustomCodeOn("BlessingofFreedom");
            if (Aimsharp.SpellCooldown("Blessing of Freedom") - Aimsharp.GCD() > 2000 && BlessingofFreedom)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blessing of Freedom Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofFreedomOff");
                return true;
            }

            if (BlessingofFreedom && Aimsharp.CanCast("Blessing of Freedom", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of Freedom - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofFreedomMO");
                return true;
            }

            string AshenHallowCast = GetDropDown("Ashen Hallow Cast:");
            bool AshenHallow = Aimsharp.IsCustomCodeOn("AshenHallow");
            if (Aimsharp.SpellCooldown("Ashen Hallow") - Aimsharp.GCD() > 2000 && AshenHallow)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Ashen Hallow Queue", Color.Purple);
                }
                Aimsharp.Cast("AshenHallowOff");
                return true;
            }

            if (AshenHallow && Aimsharp.CanCast("Ashen Hallow", "player", false, true) && (AshenHallowCast != "Player" || AshenHallowCast == "Player" && Aimsharp.Range("target") <= 3))
            {
                switch (AshenHallowCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Ashen Hallow");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("AshenHallowC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("AshenHallowP");
                        return true;
                }
            }

            string FinalReckoningCast = GetDropDown("Final Reckoning Cast:");
            bool FinalReckoning = Aimsharp.IsCustomCodeOn("FinalReckoning");
            if (Aimsharp.SpellCooldown("Final Reckoning") - Aimsharp.GCD() > 2000 && FinalReckoning)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Final Reckoning Queue", Color.Purple);
                }
                Aimsharp.Cast("FinalReckoningOff");
                return true;
            }

            if (FinalReckoning && Aimsharp.CanCast("Final Reckoning", "player", false, true) && (FinalReckoningCast != "Player" || FinalReckoningCast == "Player" && Aimsharp.Range("target") <= 3))
            {
                switch (FinalReckoningCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Final Reckoning");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FinalReckoningC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FinalReckoningP");
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