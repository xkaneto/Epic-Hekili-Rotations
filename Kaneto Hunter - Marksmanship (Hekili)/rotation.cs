using System.Linq;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class SnoogensPVEHunterMarksmanship : Rotation
    {
        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "FreezingTrap", "TarTrap", "Turtle", "Intimidation", "NoInterrupts", "NoCycle", "WildSpirits", "ResonatingArrow", "BindingShot", "Flare", "FlareCursor", "TarTrapCursor", "VolleyCursor", };
        private List<string> m_DebuffsList = new List<string> {  };
        private List<string> m_BuffsList = new List<string> { "Mend Pet", "Flayer's Mark", "Double Tap", "Lock and Load", };
        private List<string> m_BloodlustBuffsList = new List<string> { "Bloodlust", "Heroism", "Time Warp", "Primal Rage", "Drums of Rage" };
        private List<string> m_ItemsList = new List<string> { "Phial of Serenity", "Healthstone" };

        private List<string> m_SpellBook = new List<string> {
            //Covenants
            "Flayed Shot", "Death Chakram", "Wild Spirits", "Resonating Arrow",

            //Interrupt
            "Counter Shot",

            //General
            "A Murder of Crows", "Multi-Shot", "Double Tap", "Explosive Shot", "Volley",
            "Kill Shot", "Bite", "Arcane Shot", "Barrage", "Serpent Sting", "Chimaera Shot",
            "Hunter's Mark", "Tranquilizing Shot", "Exhilaration", "Mend Pet", "Trueshot", "Aimed Shot",
            "Rapid Fire", "Bursting Shot", "Steady Shot", "Wailing Arrow", "Flare",

            "Freezing Trap", "Tar Trap", "Aspect of the Turtle", "Binding Shot",


            "Summon Steward", "Fleshcraft",

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
        private bool CanCastKillShot(string unit)
        {
            if (Aimsharp.CanCast("Kill Shot", "target", true, true) || (Aimsharp.SpellCooldown("Kill Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 43 && (Aimsharp.Health(unit) < 20 || Aimsharp.HasBuff("Flayer's Mark", "player", true)) && (Aimsharp.Power("player") >= 10 || Aimsharp.HasBuff("Flayer's Mark", "player", true)) && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFlayedShot(string unit)
        {
            if (Aimsharp.CanCast("Flayed Shot", unit, true, true) || (Aimsharp.SpellCooldown("Flayed Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 43 && Aimsharp.CovenantID() == 2 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastDeathChakram(string unit)
        {
            if (Aimsharp.CanCast("Death Chakram", unit, true, true) || (Aimsharp.SpellCooldown("Death Chakram") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 43 && Aimsharp.CovenantID() == 4 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastWildSpirits(string unit)
        {
            if (Aimsharp.CanCast("Wild Spirits", unit, false, true) || (Aimsharp.SpellCooldown("Wild Spirits") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.CovenantID() == 3 && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastResonatingArrow(string unit)
        {
            if (Aimsharp.CanCast("Resonating Arrow", unit, false, true) || (Aimsharp.SpellCooldown("Resonating Arrow") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.CovenantID() == 1 && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastMultiShot(string unit)
        {
            if (Aimsharp.CanCast("Multi-Shot", unit, true, true) || (Aimsharp.SpellCooldown("Multi-Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && Aimsharp.Power("player") >= 40 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFreezingTrap(string unit)
        {
            if (Aimsharp.CanCast("Freezing Trap", unit, false, true) || (Aimsharp.SpellCooldown("Freezing Trap") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastTarTrap(string unit)
        {
            if (Aimsharp.CanCast("Tar Trap", unit, false, true) || (Aimsharp.SpellCooldown("Tar Trap") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastMendPet(string unit)
        {
            if (Aimsharp.CanCast("Mend Pet", unit, true, true) || (Aimsharp.SpellCooldown("Mend Pet") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Health("pet") > 1 && Aimsharp.Range("pet") <= 45 && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastAspectoftheTurtle(string unit)
        {
            if (Aimsharp.CanCast("Aspect of the Turtle", unit, false, true) || (Aimsharp.SpellCooldown("Aspect of the Turtle") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastBindingShot(string unit)
        {
            if (Aimsharp.CanCast("Binding Shot", unit, false, true) || (Aimsharp.SpellCooldown("Binding Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Talent(5, 3) && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastCounterShot(string unit)
        {
            if (Aimsharp.CanCast("Counter Shot", unit, true, true) || (Aimsharp.SpellCooldown("Counter Shot") <= 0 && Aimsharp.Range(unit) <= 40 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastExhilaration(string unit)
        {
            if (Aimsharp.CanCast("Exhilaration", unit, false, true) || (Aimsharp.SpellCooldown("Exhilaration") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastTranquilizingShot(string unit)
        {
            if (Aimsharp.CanCast("Tranquilizing Shot", unit, true, true) || (Aimsharp.SpellCooldown("Tranquilizing Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 43 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }
        private bool CanCastFleshcraft(string unit)
        {
            if (Aimsharp.CanCast("Fleshcraft", unit, false, true) || (Aimsharp.SpellCooldown("Fleshcraft") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.CovenantID() == 4 && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastTrueshot(string unit)
        {
            if (Aimsharp.CanCast("Trueshot", unit, false, true) || (Aimsharp.SpellCooldown("Trueshot") <= 0 && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastExplosiveShot(string unit)
        {
            if (Aimsharp.CanCast("Explosive Shot", unit, true, true) || (Aimsharp.SpellCooldown("Explosive Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 43 && Aimsharp.Power("player") >= 20 && Aimsharp.Talent(2,3) && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSerpentSting(string unit)
        {
            if (Aimsharp.CanCast("Serpent Sting", unit, true, true) || (Aimsharp.SpellCooldown("Serpent Sting") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 43 && Aimsharp.Power("player") >= 10 && Aimsharp.Talent(1, 2) && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastAMurderofCrows(string unit)
        {
            if (Aimsharp.CanCast("A Murder of Crows", unit, true, true) || (Aimsharp.SpellCooldown("A Murder of Crows") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 43 && Aimsharp.Power("player") >= 20 && Aimsharp.Talent(1, 3) && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastChimaeraShot(string unit)
        {
            if (Aimsharp.CanCast("Chimaera Shot", unit, true, true) || (Aimsharp.SpellCooldown("Chimaera Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 43 && Aimsharp.Power("player") >= 20 && Aimsharp.Talent(4, 3) && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastAimedShot(string unit)
        {
            if (Aimsharp.CanCast("Aimed Shot", unit, true, true) || ((Aimsharp.SpellCooldown("Aimed Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) || Aimsharp.SpellCharges("Aimed Shot") >= 1 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)) && Aimsharp.Range(unit) <= 43 && (Aimsharp.Power("player") >= 35 || Aimsharp.HasBuff("Lock and Load", "player", true)) && (!Aimsharp.PlayerIsMoving() || Aimsharp.HasBuff("Lock and Load", "player", true)) && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastRapidFire(string unit)
        {
            if (Aimsharp.CanCast("Rapid Fire", unit, true, true) || (Aimsharp.SpellCooldown("Rapid Fire") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 43 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSteadyShot(string unit)
        {
            if (Aimsharp.CanCast("Steady Shot", unit, true, true) || (Aimsharp.SpellCooldown("Steady Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 43 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastArcaneShot(string unit)
        {
            if (Aimsharp.CanCast("Arcane Shot", unit, true, true) || (Aimsharp.SpellCooldown("Arcane Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 43 && Aimsharp.Power("player") >= 20 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastDoubleTap(string unit)
        {
            if (Aimsharp.CanCast("Double Tap", unit, false, true) || (Aimsharp.SpellCooldown("Double Tap") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Talent(6, 3) && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastVolley(string unit)
        {
            if (Aimsharp.CanCast("Volley", unit, false, true) || (Aimsharp.SpellCooldown("Volley") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && (Aimsharp.Range(unit) <= 43 || unit == "player") && Aimsharp.Talent(7, 3) && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastBarrage(string unit)
        {
            if (Aimsharp.CanCast("Barrage", unit, false, true) || (Aimsharp.SpellCooldown("Barrage") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 43 && Aimsharp.Power("player") >= 30 && Aimsharp.Talent(2, 2) && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastBurstingShot(string unit)
        {
            if (Aimsharp.CanCast("Bursting Shot", unit, false, true) || (Aimsharp.SpellCooldown("Bursting Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFlare(string unit)
        {
            if (Aimsharp.CanCast("Flare", unit, false, true) || (Aimsharp.SpellCooldown("Flare") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }
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

            Macros.Add("FreezingTrapOff", "/" + FiveLetters + " FreezingTrap");
            Macros.Add("TarTrapOff", "/" + FiveLetters + " TarTrap");
            Macros.Add("WildSpiritsOff", "/" + FiveLetters + " WildSpirits");
            Macros.Add("ResonatingArrowOff", "/" + FiveLetters + " ResonatingArrow");
            Macros.Add("BindingShotOff", "/" + FiveLetters + " BindingShot");
            Macros.Add("FlareOff", "/" + FiveLetters + " Flare");

            Macros.Add("KillShotSQW", "/cqs\\n/cast Kill Shot");
            Macros.Add("TranqMO", "/cast [@mouseover] Tranquilizing Shot");
            Macros.Add("VolleyC", "/cast [@cursor] Volley");
            Macros.Add("FlareC", "/cast [@cursor] Flare");
            Macros.Add("TarTrapC", "/cast [@cursor] Tar Trap");
            Macros.Add("FreezingTrapC", "/cast [@cursor] Freezing Trap");
            Macros.Add("TarTrapP", "/cast [@player] Tar Trap");
            Macros.Add("FreezingTrapP", "/cast [@player] Freezing Trap");

            Macros.Add("ResonatingArrowP", "/cast [@player] Resonating Arrow");
            Macros.Add("WildSpiritsP", "/cast [@player] Wild Spirits");
            Macros.Add("ResonatingArrowC", "/cast [@cursor] Resonating Arrow");
            Macros.Add("WildSpiritsC", "/cast [@cursor] Wild Spirits");

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
            CustomFunctions.Add("HekiliID1", "local loading, finished = IsAddOnLoaded(\"Hekili\") \r\nif loading == true and finished == true then \r\n    local id=Hekili_GetRecommendedAbility(\"Primary\",1)\r\n\tif id ~= nil then\r\n\t\r\n    if id<0 then \r\n\t    local spell = Hekili.Class.abilities[id]\r\n\t    if spell ~= nil and spell.item ~= nil then \r\n\t    \tid=spell.item\r\n\t\t    local topTrinketLink = GetInventoryItemLink(\"player\",13)\r\n\t\t    local bottomTrinketLink = GetInventoryItemLink(\"player\",14)\r\n\t\t    if topTrinketLink  ~= nil then\r\n                local trinketid = GetItemInfoInstant(topTrinketLink)\r\n                if trinketid ~= nil then\r\n\t\t\t        if trinketid == id then\r\n\t\t\t\t        return 1\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t\t    if bottomTrinketLink ~= nil then\r\n                local trinketid = GetItemInfoInstant(bottomTrinketLink)\r\n                if trinketid ~= nil then\r\n    \t\t\t    if trinketid == id then\r\n\t    \t\t\t    return 2\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t    end \r\n    end\r\n    return id\r\nend\r\nend\r\nreturn 0");

            CustomFunctions.Add("GetSpellQueueWindow", "local sqw = GetCVar(\"SpellQueueWindow\"); if sqw ~= nil then return tonumber(sqw); end return 0");

            CustomFunctions.Add("CooldownsToggleCheck", "local loading, finished = IsAddOnLoaded(\"Hekili\") if loading == true and finished == true then local cooldowns = Hekili:GetToggleState(\"cooldowns\") if cooldowns == true then return 1 else if cooldowns == false then return 2 end end end return 0");
            
            CustomFunctions.Add("UnitIsDead", "if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == true then return 1 end; if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == false then return 2 end; return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");

            CustomFunctions.Add("HekiliWait", "if HekiliDisplayPrimary.Recommendations[1].wait ~= nil and HekiliDisplayPrimary.Recommendations[1].wait * 1000 > 0 then return math.floor(HekiliDisplayPrimary.Recommendations[1].wait * 1000) end return 0");

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("HekiliEnemies", "if Hekili.State.active_enemies ~= nil and Hekili.State.active_enemies > 0 then return Hekili.State.active_enemies end return 0");

            CustomFunctions.Add("PhialCount", "local count = GetItemCount(177278) if count ~= nil then return count end return 0");

            CustomFunctions.Add("TranqBuffCheck", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Tranquilizing Shot','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType  = UnitBuff('mouseover', y) if debuffType == '' or debuffType == 'Magic' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("VolleyMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Steady Shot','mouseover') == 1 then return 1 end; return 0");

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

        }
        #endregion

        public override void LoadSettings()
        {
            Settings.Add(new Setting("First 5 Letters of the Addon:", "xxxxx"));
            Settings.Add(new Setting("Race:", m_RaceList, "dwarf"));
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
            Settings.Add(new Setting("Tranquilizing Shot Mouseover:", true));
            Settings.Add(new Setting("Auto Aspect of the Turtle @ HP%", 0, 100, 20));
            Settings.Add(new Setting("Auto Exhilaration @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Auto Mend Pet @ HP%", 0, 100, 60));
            Settings.Add(new Setting("Covenant Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Freezing Trap Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Tar Trap Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Always Cast Volley @ Cursor during Rotation", false));
            Settings.Add(new Setting("Always Cast Flare @ Cursor during Rotation", false));
            Settings.Add(new Setting("Always Cast Tar Trap @ Cursor during Rotation", false));
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

            Aimsharp.PrintMessage("Snoogens PVE - Hunter Marksmanship", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon", Color.Red);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything", Color.Brown);
            Aimsharp.PrintMessage("Hekili > Toggles > Bind \"Cooldowns\" & \"Display Mode\"", Color.Brown);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("Pet Summon is Manual", Color.Green);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx FreezingTrap - Casts Freezing Trap @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx TarTrap - Casts Tar Trap @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx Flare - Casts Flare @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx BindingShot - Casts Binding Shot @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx WildSpirits - Casts Wild Spirits @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx ResonatingArrow - Casts Resonating Arrow @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx VolleyCursor - Toggles Volley always @ Cursor (same as Option)", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx FlareCursor - Toggles Flare always @ Cursor (same as Option)", Color.Yellow);
            Aimsharp.PrintMessage("/xxxxx TarTrapCursor - Toggles Tar Trap always @ Cursor (same as Option)", Color.Yellow);
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
            bool MOTranq = GetCheckBox("Tranquilizing Shot Mouseover:") == true;
            int TranqBuffMO = Aimsharp.CustomFunction("TranqBuffCheck");

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

            if (Aimsharp.IsCustomCodeOn("FreezingTrap") && Aimsharp.SpellCooldown("Freezing Trap") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("TarTrap") && Aimsharp.SpellCooldown("Tar Trap") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("WildSpirits") && Aimsharp.SpellCooldown("Wild Spirits") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("ResonatingArrow") && Aimsharp.SpellCooldown("Resonating Arrow") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("BindingShot") && Aimsharp.SpellCooldown("Binding Shot") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Interrupts
            if (!NoInterrupts && (Aimsharp.UnitID("target") != 168105 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))) && (Aimsharp.UnitID("target") != 157571 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))))
            {
                if (CanCastCounterShot("target"))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValue)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Counter Shot", true);
                        return true;
                    }
                }

                if (CanCastCounterShot("target"))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfter)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Counter Shot", true);
                        return true;
                    }
                }
            }
            #endregion

            #region Auto Spells and Items
            //Auto Turtle
            if (CanCastAspectoftheTurtle("player"))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Aspect of the Turtle @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Aspect of the Turtle- Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Aspect of the Turtle @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("Aspect of the Turtle");
                    return true;
                }
            }

            //Auto Exhilaration
            if (CanCastExhilaration("player"))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Exhilaration @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Exhilaration - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Exhilaration @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("Exhilaration");
                    return true;
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

            //Auto Mend Pet
            if (Aimsharp.PlayerHasPet() && !Aimsharp.LineOfSighted() && Aimsharp.Health("pet") > 1 && Aimsharp.Health("pet") <= GetSlider("Auto Mend Pet @ HP%") && CanCastMendPet("pet") && !Aimsharp.HasBuff("Mend Pet", "pet", true) && Aimsharp.LastCast() != "Mend Pet")
            {
                Aimsharp.Cast("Mend Pet");
                return true;
            }
            #endregion

            #region Queues
            //Queue Resonating Arrow
            string CovenantCast = GetDropDown("Covenant Cast:");
            bool ResonatingArrow = Aimsharp.IsCustomCodeOn("ResonatingArrow");
            if (Aimsharp.SpellCooldown("Resonating Arrow") - Aimsharp.GCD() > 2000 && ResonatingArrow)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Resonating Arrow Queue", Color.Purple);
                }
                Aimsharp.Cast("ResonatingArrowOff");
                return true;
            }

            if (ResonatingArrow && CanCastResonatingArrow("player"))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Resonating Arrow");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ResonatingArrowP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ResonatingArrowC");
                        return true;
                }
            }

            //Queue Wild Spirits
            bool WildSpirits = Aimsharp.IsCustomCodeOn("WildSpirits");
            if (Aimsharp.SpellCooldown("Wild Spirits") - Aimsharp.GCD() > 2000 && WildSpirits)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Wild Spirits Queue", Color.Purple);
                }
                Aimsharp.Cast("WildSpiritsOff");
                return true;
            }

            if (WildSpirits && CanCastWildSpirits("player"))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Wild Spirits");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WildSpiritsP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WildSpiritsC");
                        return true;
                }
            }

            string FreezingTrapCast = GetDropDown("Freezing Trap Cast:");
            bool FreezingTrap = Aimsharp.IsCustomCodeOn("FreezingTrap");
            //Queue Freezing Trap
            if (FreezingTrap && Aimsharp.SpellCooldown("Freezing Trap") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Freezing Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("FreezingTrapOff");
                return true;
            }

            if (FreezingTrap && CanCastFreezingTrap("player"))
            {
                switch (FreezingTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Freezing Trap - " + FreezingTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Freezing Trap");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Freezing Trap - " + FreezingTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FreezingTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Freezing Trap - " + FreezingTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FreezingTrapC");
                        return true;
                }
            }

            string TarTrapCast = GetDropDown("Tar Trap Cast:");
            bool TarTrap = Aimsharp.IsCustomCodeOn("TarTrap");
            //Queue Tar Trap
            if (TarTrap && Aimsharp.SpellCooldown("Tar Trap") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Tar Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("TarTrapOff");
                return true;
            }

            if (TarTrap && CanCastTarTrap("player"))
            {
                switch (TarTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap - " + TarTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Tar Trap");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap - " + TarTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("TarTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap - " + TarTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("TarTrapC");
                        return true;
                }
            }

            //Queue Flare
            if (Aimsharp.IsCustomCodeOn("Flare") && Aimsharp.SpellCooldown("Flare") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flare Queue", Color.Purple);
                }
                Aimsharp.Cast("FlareOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn("Flare") && CanCastFlare("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Flare through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Flare");
                return true;
            }

            //Queue Binding Shot
            if (Aimsharp.IsCustomCodeOn("BindingShot") && Aimsharp.SpellCooldown("Binding Shot") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Binding Shot Queue", Color.Purple);
                }
                Aimsharp.Cast("BindingShotOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn("BindingShot") && CanCastBindingShot("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Binding Shot through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Binding Shot");
                return true;
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

            if (Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat && Wait <= 200 && !ResonatingArrow && !WildSpirits && !Aimsharp.IsCustomCodeOn("FreezingTrap") && !Aimsharp.IsCustomCodeOn("TarTrap"))
            {
                //Tranquilizing Shot Mouseover
                if (CanCastTranquilizingShot("mouseover"))
                {
                    if (MOTranq && TranqBuffMO == 3)
                    {
                        Aimsharp.Cast("TranqMO");
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tranquilizing Shot (Mouseover)", Color.Purple);
                        }
                        return true;
                    }
                }

                if (Aimsharp.Range("target") <= 43)
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
                    if (SpellID1 == 324149 && CanCastFlayedShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flayed Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Flayed Shot");
                        return true;
                    }

                    if (SpellID1 == 308491 && CanCastResonatingArrow("player"))
                    {
                        switch (CovenantCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("Resonating Arrow");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("ResonatingArrowP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("ResonatingArrowC");
                                return true;
                        }
                    }

                    if (SpellID1 == 328231 && CanCastWildSpirits("player"))
                    {
                        switch (CovenantCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("Wild Spirits");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("WildSpiritsP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("WildSpiritsC");
                                return true;
                        }
                    }

                    if (SpellID1 == 325028 && CanCastDeathChakram("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Death Chakram - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Death Chakram");
                        return true;
                    }

                    if (SpellID1 == 324631 && CanCastFleshcraft("player") && !Moving)
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
                    if (SpellID1 == 106839 && CanCastCounterShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Counter Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Counter Shot", true);
                        return true;
                    }
                    //Player - No GCD
                    if (SpellID1 == 288613 && CanCastTrueshot("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Trueshot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Trueshot", true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    //Target - GCD
                    if (SpellID1 == 19801 && CanCastTranquilizingShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tranquilizing Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Tranquilizing Shot");
                        return true;
                    }

                    if (SpellID1 == 53351 && CanCastKillShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Kill Shot w/ SQW Cancel - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("KillShotSQW");
                        return true;
                    }

                    if ((SpellID1 == 2643 || SpellID1 == 257620) && CanCastMultiShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Multi-Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Multi-Shot");
                        return true;
                    }

                    if (SpellID1 == 355589 && Aimsharp.CanCast("Wailing Arrow", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wailing Arrow - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Wailing Arrow");
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    if (SpellID1 == 1543 && CanCastFlare("player") && (Aimsharp.CustomFunction("VolleyMouseover") == 1 || GetCheckBox("Always Cast Flare @ Cursor during Rotation") || Aimsharp.IsCustomCodeOn("FlareCursor")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flare @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("FlareC");
                        return true;
                    }
                    else if (SpellID1 == 1543 && CanCastFlare("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flare - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Flare");
                        return true;
                    }

                    if (SpellID1 == 187698 && CanCastTarTrap("player") && (Aimsharp.CustomFunction("VolleyMouseover") == 1 || GetCheckBox("Always Cast Tar Trap @ Cursor during Rotation") || Aimsharp.IsCustomCodeOn("TarTrapCursor")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("TarTrapC");
                        return true;
                    }
                    else if (SpellID1 == 187698 && CanCastTarTrap("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Tar Trap");
                        return true;
                    }
                    #endregion

                    #region Marksmanship Spells - Target GCD
                    if (SpellID1 == 212431 && CanCastExplosiveShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Explosive Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Explosive Shot");
                        return true;
                    }

                    if (SpellID1 == 271788 && CanCastSerpentSting("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Serpent Sting - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Serpent Sting");
                        return true;
                    }

                    if (SpellID1 == 131894 && CanCastAMurderofCrows("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting A Murder of Crows - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("A Murder of Crows");
                        return true;
                    }

                    if (SpellID1 == 342049 && CanCastChimaeraShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Chimaera Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Chimaera Shot");
                        return true;
                    }

                    if (SpellID1 == 19434 && CanCastAimedShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Aimed Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Aimed Shot");
                        return true;
                    }

                    if (SpellID1 == 257044 && CanCastRapidFire("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rapid Fire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Rapid Fire");
                        return true;
                    }

                    if (SpellID1 == 56641 && CanCastSteadyShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steady Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Steady Shot");
                        return true;
                    }

                    if (SpellID1 == 185358 && CanCastArcaneShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Arcane Shot");
                        return true;
                    }
                    #endregion

                    #region Marksmanship Spells - Player GCD
                    if (SpellID1 == 260402 && CanCastDoubleTap("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Double Tap - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Double Tap");
                        return true;
                    }

                    if (SpellID1 == 260243 && CanCastVolley("player") && (Aimsharp.CustomFunction("VolleyMouseover") == 1 || GetCheckBox("Always Cast Volley @ Cursor during Rotation") || Aimsharp.IsCustomCodeOn("VolleyCursor")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Volley @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("VolleyC");
                        return true;
                    }
                    else if (SpellID1 == 260243 && CanCastVolley("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Volley - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Volley");
                        return true;
                    }

                    if (SpellID1 == 120360 && CanCastBarrage("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Barrage - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Barrage");
                        return true;
                    }

                    if (SpellID1 == 185387 && CanCastBurstingShot("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bursting Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Bursting Shot");
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

            if (Aimsharp.IsCustomCodeOn("FreezingTrap") && Aimsharp.SpellCooldown("Freezing Trap") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("TarTrap") && Aimsharp.SpellCooldown("Tar Trap") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("WildSpirits") && Aimsharp.SpellCooldown("Wild Spirits") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("ResonatingArrow") && Aimsharp.SpellCooldown("Resonating Arrow") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("BindingShot") && Aimsharp.SpellCooldown("Binding Shot") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            //Queue Resonating Arrow
            string CovenantCast = GetDropDown("Covenant Cast:");
            bool ResonatingArrow = Aimsharp.IsCustomCodeOn("ResonatingArrow");
            if (Aimsharp.SpellCooldown("Resonating Arrow") - Aimsharp.GCD() > 2000 && ResonatingArrow)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Resonating Arrow Queue", Color.Purple);
                }
                Aimsharp.Cast("ResonatingArrowOff");
                return true;
            }

            if (ResonatingArrow && CanCastResonatingArrow("player"))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Resonating Arrow");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ResonatingArrowP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ResonatingArrowC");
                        return true;
                }
            }

            //Queue Wild Spirits
            bool WildSpirits = Aimsharp.IsCustomCodeOn("WildSpirits");
            if (Aimsharp.SpellCooldown("Wild Spirits") - Aimsharp.GCD() > 2000 && WildSpirits)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Wild Spirits Queue", Color.Purple);
                }
                Aimsharp.Cast("WildSpiritsOff");
                return true;
            }

            if (WildSpirits && CanCastWildSpirits("player"))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Wild Spirits");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WildSpiritsP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WildSpiritsC");
                        return true;
                }
            }

            string FreezingTrapCast = GetDropDown("Freezing Trap Cast:");
            bool FreezingTrap = Aimsharp.IsCustomCodeOn("FreezingTrap");
            //Queue Freezing Trap
            if (FreezingTrap && Aimsharp.SpellCooldown("Freezing Trap") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Freezing Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("FreezingTrapOff");
                return true;
            }

            if (FreezingTrap && CanCastFreezingTrap("player"))
            {
                switch (FreezingTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Freezing Trap - " + FreezingTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Freezing Trap");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Freezing Trap - " + FreezingTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FreezingTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Freezing Trap - " + FreezingTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FreezingTrapC");
                        return true;
                }
            }

            string TarTrapCast = GetDropDown("Tar Trap Cast:");
            bool TarTrap = Aimsharp.IsCustomCodeOn("TarTrap");
            //Queue Tar Trap
            if (TarTrap && Aimsharp.SpellCooldown("Tar Trap") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Tar Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("TarTrapOff");
                return true;
            }

            if (TarTrap && CanCastTarTrap("player"))
            {
                switch (TarTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap - " + TarTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Tar Trap");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap - " + TarTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("TarTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap - " + TarTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("TarTrapC");
                        return true;
                }
            }

            //Queue Flare
            if (Aimsharp.IsCustomCodeOn("Flare") && Aimsharp.SpellCooldown("Flare") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flare Queue", Color.Purple);
                }
                Aimsharp.Cast("FlareOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn("Flare") && CanCastFlare("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Flare through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Flare");
                return true;
            }

            //Queue Binding Shot
            if (Aimsharp.IsCustomCodeOn("BindingShot") && Aimsharp.SpellCooldown("Binding Shot") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Binding Shot Queue", Color.Purple);
                }
                Aimsharp.Cast("BindingShotOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn("BindingShot") && CanCastBindingShot("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Binding Shot through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Binding Shot");
                return true;
            }
            #endregion

            #region Out of Combat Spells
            if (SpellID1 == 324631 && CanCastFleshcraft("player") && !Moving)
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
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 43 && TargetInCombat)
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