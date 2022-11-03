using System.Linq;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class KanetoMonkWindwalkerHekili : Rotation
    {
        private static string Language = "English";

        #region SpellFunctions
        #endregion

        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "RingofPeace", "Paralysis", "LegSweep", "Vivify", "FlyingSerpentKick", "Transcendence", "Transfer", "NoDetox", "BonedustBrew", "NoInterrupts", "NoCycle", };
        private List<string> m_DebuffsList = new List<string> { "Paralysis", "Phantasmal Parasite", "Dark Lance", "Lost Confidence", "Mark of the Crane", "Blackout Kick!", };
        private List<string> m_BuffsList = new List<string> { "Weapons of Order", "Storm, Earth, and Fire", "Whirling Dragon Punch", "Serenity", "Dance of Chi-Ji", };
        private List<string> m_BloodlustBuffsList = new List<string> { "Bloodlust", "Heroism", "Time Warp", "Primal Rage", "Drums of Rage" };
        private List<string> m_ItemsList = new List<string> { "Healthstone" };

        private List<string> m_SpellBook_General = new List<string> {
            //Covenants
            "Weapons of Order",
            "Fallen Order",
            "Faeline Stomp",
            "Bonedust Brew",
            "Summon Steward",
            "Fleshcraft",
            //Interrupt
            "Spear Hand Strike",

            //General Monk
            "Paralysis",
            "Spinning Crane Kick",
            "Vivify",
            "Fortifying Brew",
            "Tiger Palm",
            "Chi Torpedo",
            "Dampen Harm",
            "Roll",
            "Leg Sweep",
            "Blackout Kick",
            "Touch of Death",
            "Transcendence",
            "Transcendence: Transfer",
            "Rushing Jade Wind",
            "Ring of Peace",
            "Expel Harm",
            "Crackling Jade Lightning",
            "Detox",
            "Provoke",
            "Chi Wave",
            "Chi Burst",
            "Tiger's Lust",
            "Fist of the White Tiger",
            "Rising Sun Kick",
            "Touch of Karma",
            "Invoke Xuen, the White Tiger",
            "Storm, Earth, and Fire",
            "Storm, Earth, and Fire: Fixate",
            "Fists of Fury",
            "Flying Serpent Kick",
            "Fist of the White Tiger",
            "Energizing Elixir",
            "Diffuse Magic",
            "Whirling Dragon Punch",
            "Serenity",

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

        public bool UnitFocus(string unit)
        {
            if (Aimsharp.CustomFunction("UnitIsFocus") == 1 && unit == "party1" || Aimsharp.CustomFunction("UnitIsFocus") == 2 && unit == "party2" || Aimsharp.CustomFunction("UnitIsFocus") == 3 && unit == "party3" || Aimsharp.CustomFunction("UnitIsFocus") == 4 && unit == "party4" || Aimsharp.CustomFunction("UnitIsFocus") == 5 && unit == "player")
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

        public Dictionary<string, int> PartyDict = new Dictionary<string, int>() { };
        #endregion

        #region CanCasts
        private bool CanCastTouchofDeath(string unit)
        {
            if (Aimsharp.CanCast("Touch of Death", unit, true, true) || (Aimsharp.SpellCooldown("Touch of Death") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Health(unit) < 15 && Aimsharp.Range(unit) <= 5 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastTigerPalm(string unit)
        {
            if (Aimsharp.CanCast("Tiger Palm", unit, true, true) || (Aimsharp.SpellCooldown("Tiger Palm") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 5 && Aimsharp.Power("player") >= 50 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastFistsofFury(string unit)
        {
            if (Aimsharp.CanCast("Fists of Fury", unit, false, true) && Aimsharp.Range("target") <= 6 || (Aimsharp.SpellCooldown("Fists of Fury") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 6 && (Aimsharp.PlayerSecondaryPower() >= 3 || Aimsharp.HasBuff("Serenity", "player", true) || Aimsharp.CustomFunction("WoORSK") > 0 && Aimsharp.PlayerSecondaryPower() >= 2) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastRisingSunKick(string unit)
        {
            if (Aimsharp.CanCast("Rising Sun Kick", unit, true, true) || (Aimsharp.SpellCooldown("Rising Sun Kick") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 5 && (Aimsharp.PlayerSecondaryPower() >= 2 || Aimsharp.HasBuff("Serenity", "player", true) || Aimsharp.CustomFunction("WoORSK") > 0 && Aimsharp.PlayerSecondaryPower() >= 1) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastWhirlingDragonPunch(string unit)
        {
            if (Aimsharp.CanCast("Whirling Dragon Punch", unit, false, true) && Aimsharp.Range("target") <= 6 || (Aimsharp.SpellCooldown("Whirling Dragon Punch") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 6 && Aimsharp.HasBuff("Whirling Dragon Punch", "player", true) && Aimsharp.Talent(7, 2) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastStormEarthandFire(string unit)
        {
            if (Aimsharp.CanCast("Storm, Earth, and Fire", unit, false, true) && Aimsharp.Range("target") <= 8 && !Aimsharp.Talent(7, 3) || ((Aimsharp.SpellCooldown("Storm, Earth, and Fire") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) || Aimsharp.SpellCharges("Storm, Earth, and Fire") >= 1 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)) && Aimsharp.Range("target") <= 8 && !Aimsharp.Talent(7, 3) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastSerenity(string unit)
        {
            if (Aimsharp.CanCast("Serenity", unit, false, true) && Aimsharp.Range("target") <= 8 && Aimsharp.Talent(7, 3) || (Aimsharp.SpellCooldown("Serenity") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 8 && Aimsharp.Talent(7, 3) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastWeaponsofOrder(string unit)
        {
            if (Aimsharp.CanCast("Weapons of Order", unit, false, true) && Aimsharp.Range("target") <= 8 || (Aimsharp.SpellCooldown("Weapons of Order") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 8 && Aimsharp.CovenantID() == 1 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastFallenOrder(string unit)
        {
            if (Aimsharp.CanCast("Fallen Order", unit, false, true) && Aimsharp.Range("target") <= 8 || (Aimsharp.SpellCooldown("Fallen Order") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 8 && Aimsharp.CovenantID() == 2 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastParalysis(string unit)
        {
            if (Aimsharp.CanCast("Paralysis", unit, true, true) || (Aimsharp.SpellCooldown("Paralysis") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 20 && Aimsharp.Power("player") >= 20 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastRingofPeace(string unit)
        {
            if (Aimsharp.CanCast("Ring of Peace", unit, false, true) || (Aimsharp.SpellCooldown("Ring of Peace") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Talent(4, 3)))
                return true;

            return false;
        }

        private bool CanCastFortifyingBrew(string unit)
        {
            if (Aimsharp.CanCast("Fortifying Brew", unit, false, true) || (Aimsharp.SpellCooldown("Fortifying Brew") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)))
                return true;

            return false;
        }

        private bool CanCastTouchofKarma(string unit)
        {
            if (Aimsharp.CanCast("Touch of Karma", unit, true, true) || (Aimsharp.SpellCooldown("Touch of Karma") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastSpearHandStrike(string unit)
        {
            if (Aimsharp.CanCast("Spear Hand Strike", unit, true, true) || (Aimsharp.SpellCooldown("Spear Hand Strike") <= 0 && Aimsharp.Range(unit) <= 5 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastLegSweep(string unit)
        {
            if (Aimsharp.CanCast("Leg Sweep", unit, false, true) || (Aimsharp.SpellCooldown("Leg Sweep") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)))
                return true;

            return false;
        }

        private bool CanCastDiffuseMagic(string unit)
        {
            if (Aimsharp.CanCast("Diffuse Magic", unit, false, true) || (Aimsharp.SpellCooldown("Diffuse Magic") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Talent(5, 2)))
                return true;

            return false;
        }

        private bool CanCastDampenHarm(string unit)
        {
            if (Aimsharp.CanCast("Dampen Harm", unit, false, true) || (Aimsharp.SpellCooldown("Dampen Harm") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Talent(5, 3)))
                return true;

            return false;
        }

        private bool CanCastDetox(string unit)
        {
            if (Aimsharp.CanCast("Detox", unit, true, true) || (Aimsharp.SpellCooldown("Detox") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && (Aimsharp.Range(unit) <= 40 || unit == "player") && Aimsharp.Power("player") >= 20))
                return true;

            return false;
        }

        private bool CanCastTigersLust(string unit)
        {
            if (Aimsharp.CanCast("Tiger's Lust", unit, true, true) || (Aimsharp.SpellCooldown("Tiger's Lust") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && (Aimsharp.Range(unit) <= 20 || unit == "player") && Aimsharp.Talent(2, 3)))
                return true;

            return false;
        }

        private bool CanCastFlyingSerpentKick(string unit)
        {
            if (Aimsharp.CanCast("Flying Serpent Kick", unit, false, true) || (Aimsharp.SpellCooldown("Flying Serpent Kick") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastInvokeXuentheWhiteTiger(string unit)
        {
            if (Aimsharp.CanCast("Invoke Xuen, the White Tiger", unit, false, true) && Aimsharp.Range("target") <= 8 || (Aimsharp.SpellCooldown("Invoke Xuen, the White Tiger") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 8 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastSpinningCraneKick(string unit)
        {
            if (Aimsharp.CanCast("Spinning Crane Kick", unit, false, true) && Aimsharp.Range("target") <= 6 || (Aimsharp.SpellCooldown("Spinning Crane Kick") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 6 && (Aimsharp.PlayerSecondaryPower() >= 2 || Aimsharp.HasBuff("Serenity", "player", true) || Aimsharp.HasBuff("Dance of Chi-Ji", "player", true) || Aimsharp.CustomFunction("WoORSK") > 0 && Aimsharp.PlayerSecondaryPower() >= 1) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastBlackoutKick(string unit)
        {
            if (Aimsharp.CanCast("Blackout Kick", unit, true, true) || (Aimsharp.SpellCooldown("Blackout Kick") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 5 && (Aimsharp.PlayerSecondaryPower() >= 1 || Aimsharp.HasBuff("Serenity", "player", true) || Aimsharp.HasBuff("Blackout Kick!", "player", true) || Aimsharp.CustomFunction("WoORSK") > 0 && Aimsharp.PlayerSecondaryPower() >= 0) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastDisable(string unit)
        {
            if (Aimsharp.CanCast("Disable", unit, true, true) || (Aimsharp.SpellCooldown("Disable") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 5 && Aimsharp.Power() >= 15 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastExpelHarm(string unit)
        {
            if (Aimsharp.CanCast("Expel Harm", unit, false, true) && Aimsharp.Range("target") <= 8 || (Aimsharp.SpellCooldown("Expel Harm") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 8 && Aimsharp.Power() >= 15 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastFistoftheWhiteTiger(string unit)
        {
            if (Aimsharp.CanCast("Fist of the White Tiger", unit, true, true) || (Aimsharp.SpellCooldown("Fist of the White Tiger") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 5 && Aimsharp.Power() >= 40 && Aimsharp.Talent(3, 2) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastFaelineStomp(string unit)
        {
            if (Aimsharp.CanCast("Faeline Stomp", unit, false, true) && Aimsharp.Range("target") <= 8 || (Aimsharp.SpellCooldown("Faeline Stomp") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 8 && Aimsharp.CovenantID() == 3 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastBonedustBrew(string unit)
        {
            if (Aimsharp.CanCast("Bonedust Brew", unit, false, true) || (Aimsharp.SpellCooldown("Bonedust Brew") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.CovenantID() == 4 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastChiBurst(string unit)
        {
            if (Aimsharp.CanCast("Chi Burst", unit, false, true) && Aimsharp.Range("target") <= 40 || (Aimsharp.SpellCooldown("Chi Burst") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 40 && Aimsharp.Talent(1, 3) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastChiWave(string unit)
        {
            if (Aimsharp.CanCast("Chi Wave", unit, true, true) && Aimsharp.Range("target") <= 25 || (Aimsharp.SpellCooldown("Chi Wave") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 25 && Aimsharp.Talent(1, 2) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastEnergizingElixir(string unit)
        {
            if (Aimsharp.CanCast("Energizing Elixir", unit, false, true) && Aimsharp.Range("target") <= 8 || (Aimsharp.SpellCooldown("Energizing Elixir") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 8 && Aimsharp.Talent(3, 3) && TargetAlive()))
                return true;

            return false;
        }
        #endregion

        #region Debuffs
        private int UnitDebuffSap(string unit)
        {
            if (Aimsharp.HasDebuff("Sap", unit, true))
                return Aimsharp.DebuffRemaining("Sap", unit, true);
            if (Aimsharp.HasDebuff("Sap", unit, false))
                return Aimsharp.DebuffRemaining("Sap", unit, false);

            return 0;
        }

        private int UnitDebuffBlind(string unit)
        {
            if (Aimsharp.HasDebuff("Blind", unit, true))
                return Aimsharp.DebuffRemaining("Blind", unit, true);
            if (Aimsharp.HasDebuff("Blind", unit, false))
                return Aimsharp.DebuffRemaining("Blind", unit, false);

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


            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + (Aimsharp.Latency + 100));

            //Ring of Peace @ Cursor
            Macros.Add("RingofPeaceC", "/cast [@cursor] Ring of Peace");
            Macros.Add("RingofPeaceP", "/cast [@player] Ring of Peace");
            Macros.Add("RingofPeaceOff", "/" + FiveLetters + " RingofPeace");

            //Bonedust Brew @ Cursor
            Macros.Add("BonedustBrewC", "/cast [@cursor] Bonedust Brew");
            Macros.Add("BonedustBrewP", "/cast [@player] Bonedust Brew");
            Macros.Add("BonedustBrewOff", "/" + FiveLetters + " BonedustBrew");

            //Paralysis
            Macros.Add("ParalysisOff", "/" + FiveLetters + " Paralysis");

            //Leg Sweep
            Macros.Add("LegSweepOff", "/" + FiveLetters + " LegSweep");

            //Flying Serpent Kick
            Macros.Add("FlyingSerpentKickOff", "/" + FiveLetters + " FlyingSerpentKick");

            //Transcendence
            Macros.Add("TranscendenceOff", "/" + FiveLetters + " Transcendence");

            //Transcendence: Transfer
            Macros.Add("TransferOff", "/" + FiveLetters + " Transfer");

            //Detox
            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");
            Macros.Add("DX_FOC", "/cast [@focus] Detox");


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
            CustomFunctions.Add("HekiliID1", "local loading, finished = IsAddOnLoaded(\"Hekili\") \r\nif loading == true and finished == true then \r\n    local id=Hekili_GetRecommendedAbility(\"Primary\",1)\r\n\tif id ~= nil then\r\n\t\r\n    if id<0 then \r\n\t    local spell = Hekili.Class.abilities[id]\r\n\t    if spell ~= nil and spell.item ~= nil then \r\n\t    \tid=spell.item\r\n\t\t    local topTrinketLink = GetInventoryItemLink(\"player\",13)\r\n\t\t    local bottomTrinketLink = GetInventoryItemLink(\"player\",14)\r\n\t\t    local weaponLink = GetInventoryItemLink(\"player\",16)\r\n\t\t    if topTrinketLink  ~= nil then\r\n                local trinketid = GetItemInfoInstant(topTrinketLink)\r\n                if trinketid ~= nil then\r\n\t\t\t        if trinketid == id then\r\n\t\t\t\t        return 1\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t\t    if bottomTrinketLink ~= nil then\r\n                local trinketid = GetItemInfoInstant(bottomTrinketLink)\r\n                if trinketid ~= nil then\r\n    \t\t\t    if trinketid == id then\r\n\t    \t\t\t    return 2\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t\t    if weaponLink ~= nil then\r\n                local weaponid = GetItemInfoInstant(weaponLink)\r\n                if weaponid ~= nil then\r\n    \t\t\t    if weaponid == id then\r\n\t    \t\t\t    return 3\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t    end \r\n    end\r\n    return id\r\nend\r\nend\r\nreturn 0");

            CustomFunctions.Add("PhialCount", "local count = GetItemCount(177278) if count ~= nil then return count end return 0");

            CustomFunctions.Add("GetSpellQueueWindow", "local sqw = GetCVar(\"SpellQueueWindow\"); if sqw ~= nil then return tonumber(sqw); end return 0");

            CustomFunctions.Add("CooldownsToggleCheck", "local loading, finished = IsAddOnLoaded(\"Hekili\") if loading == true and finished == true then local cooldowns = Hekili:GetToggleState(\"cooldowns\") if cooldowns == true then return 1 else if cooldowns == false then return 2 end end end return 0");

            CustomFunctions.Add("UnitIsDead", "if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == true then return 1 end; if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == false then return 2 end; return 0");

            CustomFunctions.Add("MarkDebuffCheck", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Rising Sun Kick','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,_,_,_,source  = UnitDebuff('mouseover', y) if name == 'Mark of the Crane' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("HekiliWait", "if HekiliDisplayPrimary.Recommendations[1].wait ~= nil and HekiliDisplayPrimary.Recommendations[1].wait * 1000 > 0 then return math.floor(HekiliDisplayPrimary.Recommendations[1].wait * 1000) end return 0");

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("TargetIsMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitExists('target') and UnitIsDead('target') ~= true and UnitIsUnit('mouseover', 'target') then return 1 end; return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");

            CustomFunctions.Add("WoORSK", "for i=1,40 do local _,_,_,_,_,duration,_,_,_,s=UnitAura('player',i);if s==311054 then return (duration - GetTime());end end if s~=311054 then return 0 end");

            CustomFunctions.Add("DiseasePoisonCheck", "local y=0; " +
                                "for i=1,25 do local name,_,_,type=UnitDebuff(\"player\",i,\"RAID\"); " +
                                "if type ~= nil and type == \"Disease\" or type == \"Poison\" then y = y +1; end end " +
                                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
                                "if type ~= nil and type == \"Disease\" or type == \"Poison\" then y = y +2; end end " +
                                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
                                "if type ~= nil and type == \"Disease\" or type == \"Poison\" then y = y +4; end end " +
                                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
                                "if type ~= nil and type == \"Disease\" or type == \"Poison\" then y = y +8; end end " +
                                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
                                "if type ~= nil and type == \"Disease\" or type == \"Poison\" then y = y +16; end end " +
                                "return y");

            CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
                                "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
                                "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
                                "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
                                "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
                                "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
                                "\nreturn foc");
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
            Settings.Add(new Setting("Kicks/Interrupts"));
            Settings.Add(new Setting("Kick at milliseconds remaining", 50, 1500, 500));
            Settings.Add(new Setting("Kick channels after milliseconds", 50, 1500, 500));
            Settings.Add(new Setting("General"));
            Settings.Add(new Setting("Auto Start Combat:", true));
            Settings.Add(new Setting("Auto Slow/Cancel Flying Serpent Kick:", true));
            Settings.Add(new Setting("Reflect Boss Debuff using Diffuse Magic:", true));
            //Settings.Add(new Setting("Spread Mark of the Crane with Mouseover:", false));
            Settings.Add(new Setting("Auto Dampen Harm @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Diffuse Magic @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Fortifying Brew @ HP%", 0, 100, 30));
            Settings.Add(new Setting("Ring of Peace Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Bonedust Brew Cast:", m_CastingList, "Manual"));
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

            Aimsharp.PrintMessage("Kaneto PVE - Monk Windwalker", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.Red);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.Red);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/monk/windwalker/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoDetox - Disables Detox", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Paralysis - Casts Paralysis @ Target on the next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BonedustBrew - Casts Bonedust Brew @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " LegSweep - Casts Leg Sweep @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FlyingSerpentKick - Casts Flying Serpent Kick @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Transcendence - Casts Transcendence @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Transfer - Casts Transfer @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Vivify - Casts Vivify until turned Off", Color.Yellow);
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
            bool MeleeRange = Aimsharp.Range("target") <= 6;
            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());

            int DiseasePoisonCheck = Aimsharp.CustomFunction("DiseasePoisonCheck");
            int MarkDebuffMO = Aimsharp.CustomFunction("MarkDebuffCheck");
            //bool MOMark = GetCheckBox("Spread Mark with Mouseover:") == true;
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

            #region Above Pause Functions
            //Auto Slow Flying Serpent Kick
            if (GetCheckBox("Auto Slow/Cancel Flying Serpent Kick:"))
            {
                if (CanCastFlyingSerpentKick("player") && Aimsharp.LastCast() == "Flying Serpent Kick" && Aimsharp.Range("target") <= 8)
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Flying Serpent Kick Slow", Color.Purple);
                    }
                    Aimsharp.Cast("Flying Serpent Kick", true);
                    return true;
                }
            }

            //Cast during Spinning Crane Kick
            if (Aimsharp.CastingID("player") == 101546)
            {
                //Hekili Cycle
                if (Aimsharp.CustomFunction("HekiliCycle") == 1 && EnemiesInMelee > 1)
                {
                    System.Threading.Thread.Sleep(50);
                    Aimsharp.Cast("TargetEnemy");
                    System.Threading.Thread.Sleep(50);
                    return true;
                }

                //Auto Target
                if ((!Enemy || Enemy && !TargetAlive() || Enemy && !TargetInCombat) && EnemiesInMelee > 0)
                {
                    System.Threading.Thread.Sleep(50);
                    Aimsharp.Cast("TargetEnemy");
                    System.Threading.Thread.Sleep(50);
                    return true;
                }

                if (SpellID1 == 100780 && CanCastTigerPalm("target"))
                {
                    Aimsharp.Cast("Tiger Palm");
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Tiger Palm (Target) - " + SpellID1, Color.Purple);
                    }
                    return true;
                }

                if ((SpellID1 == 100784 || SpellID1 == 205523) && CanCastBlackoutKick("target"))
                {
                    Aimsharp.Cast("Blackout Kick");
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Blackout Kick (Target) - " + SpellID1, Color.Purple);
                    }
                    return true;
                }

                if (SpellID1 == 322109 && CanCastTouchofDeath("target"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Touch of Death - " + SpellID1, Color.Purple);
                    }
                    Aimsharp.Cast("Touch of Death");
                    return true;
                }

                if (SpellID1 == 107428 && CanCastRisingSunKick("target"))
                {
                    Aimsharp.Cast("Rising Sun Kick");
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Rising Sun Kick (Target) - " + SpellID1, Color.Purple);
                    }
                    return true;
                }

                if (SpellID1 == 261947 && CanCastFistoftheWhiteTiger("target"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Fist of the White Tiger - " + SpellID1, Color.Purple);
                    }
                    Aimsharp.Cast("Fist of the White Tiger");
                    return true;
                }
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

            if (Aimsharp.IsCustomCodeOn("RingofPeace") && Aimsharp.SpellCooldown("Ring of Peace") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("BonedustBrew") && Aimsharp.SpellCooldown("Bonedust Brew") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Interrupts
            if (!NoInterrupts && (Aimsharp.UnitID("target") != 168105 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))) && (Aimsharp.UnitID("target") != 157571 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))))
            {
                if (CanCastSpearHandStrike("target"))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValue)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Spear Hand Strike", true);
                        return true;
                    }
                }

                if (CanCastSpearHandStrike("target"))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfter)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Spear Hand Strike", true);
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

            //Auto Fortifying Brew
            if (CanCastFortifyingBrew("player") == true)
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Fortifying Brew @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Fortifying Brew - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Fortifying Brew @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("Fortifying Brew");
                    return true;
                }
            }

            //Auto Diffuse Magic
            if (CanCastDiffuseMagic("player") == true)
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Diffuse Magic @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Diffuse Magic - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Diffuse Magic @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("Diffuse Magic");
                    return true;
                }
            }

            //Auto Fortifying Brew
            if (CanCastDampenHarm("player") == true)
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Dampen Harm @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Dampen Harm - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Dampen Harm @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("Dampen Harm");
                    return true;
                }
            }

            #endregion

            #region Queues
            //Queues
            bool FlyingSerpentKick = Aimsharp.IsCustomCodeOn("FlyingSerpentKick");
            if ((Aimsharp.SpellCooldown("Flying Serpent Kick") > 2000 || Aimsharp.LastCast() == "Flying Serpent Kick") && FlyingSerpentKick)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flying Serpent Kick queue toggle", Color.Purple);
                }
                Aimsharp.Cast("FlyingSerpentKickOff");
                return true;
            }

            if (FlyingSerpentKick && CanCastFlyingSerpentKick("player") == true)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Flying Serpent Kick through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Flying Serpent Kick");
                return true;
            }

            string RingofPeaceCast = GetDropDown("Ring of Peace Cast:");
            bool RingofPeace = Aimsharp.IsCustomCodeOn("RingofPeace");
            if (Aimsharp.SpellCooldown("Ring of Peace") - Aimsharp.GCD() > 2000 && RingofPeace)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Ring of Peace Queue", Color.Purple);
                }
                Aimsharp.Cast("RingofPeaceOff");
                return true;
            }

            if (RingofPeace && CanCastRingofPeace("player"))
            {
                switch (RingofPeaceCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Peace - " + RingofPeaceCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Ring of Peace");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Peace - " + RingofPeaceCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofPeaceC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Peace - " + RingofPeaceCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofPeaceP");
                        return true;
                }
            }

            string BonedustBrewCast = GetDropDown("Bonedust Brew Cast:");
            bool BonedustBrew = Aimsharp.IsCustomCodeOn("BonedustBrew");
            if (Aimsharp.SpellCooldown("Bonedust Brew") - Aimsharp.GCD() > 2000 && BonedustBrew)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Bonedust Brew Queue", Color.Purple);
                }
                Aimsharp.Cast("BonedustBrewOff");
                return true;
            }

            if (BonedustBrew && CanCastBonedustBrew("player") && (BonedustBrewCast == "Player" && Aimsharp.Range("target") <= 5 || BonedustBrewCast != "Player"))
            {
                switch (BonedustBrewCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Bonedust Brew");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("BonedustBrewC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("BonedustBrewP");
                        return true;
                }
            }

            bool Transcendence = Aimsharp.IsCustomCodeOn("Transcendence");
            //Queue Transcendence
            if (Aimsharp.SpellCooldown("Transcendence") - Aimsharp.GCD() > 2000 && Transcendence)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Transcendence queue toggle", Color.Purple);
                }
                Aimsharp.Cast("TranscendenceOff");
                return true;
            }

            if (Transcendence && Aimsharp.CanCast("Transcendence", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Transcendence through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Transcendence");
                return true;
            }

            bool Transfer = Aimsharp.IsCustomCodeOn("Transfer");
            //Queue Transfer
            if (Aimsharp.SpellCooldown("Transfer") - Aimsharp.GCD() > 2000 && Transfer)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Transfer queue toggle", Color.Purple);
                }
                Aimsharp.Cast("TransferOff");
                return true;
            }

            if (Transfer && Aimsharp.CanCast("Transfer", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Transfer through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Transcendence: Transfer");
                return true;
            }

            bool Paralysis = Aimsharp.IsCustomCodeOn("Paralysis");
            //Queue Paralysis
            if (Paralysis && Aimsharp.SpellCooldown("Paralysis") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Paralysis queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ParalysisOff");
                return true;
            }

            if (Paralysis && CanCastParalysis("target"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Paralysis through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Paralysis");
                return true;
            }

            bool LegSweep = Aimsharp.IsCustomCodeOn("LegSweep");
            //Queue Leg Sweep
            if (LegSweep && Aimsharp.SpellCooldown("Leg Sweep") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Leg Sweep queue toggle", Color.Purple);
                }
                Aimsharp.Cast("LegSweepOff");
                return true;
            }

            if (LegSweep && CanCastLegSweep("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Leg Sweep through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Leg Sweep");
                return true;
            }

            bool Vivify = Aimsharp.IsCustomCodeOn("Vivify");
            //Queue Vivify Spam
            if (Vivify && (Aimsharp.CanCast("Vivify", "player", false, true) || Aimsharp.CanCast("Vivify", "target", true, true)) && !Aimsharp.PlayerIsMoving())
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Vivify due to toggle being On", Color.Purple);
                }
                Aimsharp.Cast("Vivify");
                return true;
            }
            #endregion

            #region Detox
            bool NoDetox = Aimsharp.IsCustomCodeOn("NoDetox");
            if (!NoDetox && DiseasePoisonCheck > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != "Detox")
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
                    if (CanCastDetox(unit.Key) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
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
                                Aimsharp.Cast("DX_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Detox @ " + unit.Key + " - " + unit.Value, Color.Purple);
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
                    if (SpellID1 == 310454 && CanCastWeaponsofOrder("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Weapons of Order - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Weapons of Order");
                        return true;
                    }

                    if (SpellID1 == 326860 && CanCastFallenOrder("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fallen Order - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Fallen Order");
                        return true;
                    }

                    if (SpellID1 == 327104 && CanCastFaelineStomp("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Faeline Stomp - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Faeline Stomp");
                        return true;
                    }

                    if (SpellID1 == 325216 && CanCastBonedustBrew("player") && (BonedustBrewCast == "Player" && Aimsharp.Range("target") <= 5 || BonedustBrewCast != "Player"))
                    {
                        switch (BonedustBrewCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("Bonedust Brew");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " -"  + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("BonedustBrewC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("BonedustBrewP");
                                return true;
                        }
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
                    if (SpellID1 == 116705 && CanCastSpearHandStrike("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spear Hand Strike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Spear Hand Strike", true);
                        return true;
                    }

                    if (SpellID1 == 137639 && CanCastStormEarthandFire("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Storm, Earth, and Fire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Storm, Earth, and Fire", true);
                        return true;
                    }

                    if (SpellID1 == 221771 && Aimsharp.CanCast("Storm, Earth, and Fire: Fixate", "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Storm, Earth, and Fire: Fixate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Storm, Earth, and Fire: Fixate", true);
                        return true;
                    }

                    if (SpellID1 == 115288 && CanCastEnergizingElixir("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Energizing Elixir - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Energizing Elixir", true);
                        return true;
                    }

                    if (SpellID1 == 152173 && CanCastSerenity("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Serenity - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Serenity", true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    //General Monk
                    //Instant [GCD]
                    ///Player
                    if (SpellID1 == 322101 && CanCastExpelHarm("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Expel Harm - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Expel Harm");
                        return true;
                    }

                    if (SpellID1 == 218164 && CanCastDetox("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Detox - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Detox");
                        return true;
                    }

                    if (SpellID1 == 123986 && CanCastChiBurst("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Chi Burst - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Chi Burst");
                        return true;
                    }

                    if (SpellID1 == 116847 && Aimsharp.CanCast("Rushing Jade Wind", "player", true, false))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rushing Jade Wind - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Rushing Jade Wind");
                        return true;
                    }

                    if ((SpellID1 == 201318 || SpellID1 == 115203) && CanCastFortifyingBrew("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fortifying Brew - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Fortifying Brew");
                        return true;
                    }

                    if (SpellID1 == 123904 && CanCastInvokeXuentheWhiteTiger("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Invoke Xuen, the White Tiger - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Invoke Xuen, the White Tiger");
                        return true;
                    }

                    if (SpellID1 == 113656 && CanCastFistsofFury("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fists of Fury - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Fists of Fury");
                        return true;
                    }

                    if (SpellID1 == 101545 && CanCastFlyingSerpentKick("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flying Serpent Kick - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Flying Serpent Kick");
                        return true;
                    }

                    if (SpellID1 == 152175 && CanCastWhirlingDragonPunch("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Whirling Dragon Punch - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Whirling Dragon Punch");
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    ///Target
                    if (SpellID1 == 115078 && CanCastParalysis("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Paralysis - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Paralysis");
                        return true;
                    }

                    if ((SpellID1 == 101546 || SpellID1 == 322729) && CanCastSpinningCraneKick("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spinning Crane Kick - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Spinning Crane Kick");
                        return true;
                    }

                    if (SpellID1 == 100780 && CanCastTigerPalm("target"))
                    {
                        Aimsharp.Cast("Tiger Palm");
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tiger Palm (Target) - " + SpellID1, Color.Purple);
                        }
                        return true;
                    }

                    if ((SpellID1 == 100784 || SpellID1 == 205523) && CanCastBlackoutKick("target"))
                    {
                        Aimsharp.Cast("Blackout Kick");
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blackout Kick (Target) - " + SpellID1, Color.Purple);
                        }
                        return true;
                    }

                    if (SpellID1 == 322109 && CanCastTouchofDeath("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Touch of Death - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Touch of Death");
                        return true;
                    }

                    if (SpellID1 == 115098 && CanCastChiWave("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Chi Wave - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Chi Wave");
                        return true;
                    }

                    if ((SpellID1 == 125174 || SpellID1 == 122470) && CanCastTouchofKarma("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Touch of Karma - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Touch of Karma");
                        return true;
                    }

                    if (SpellID1 == 107428 && CanCastRisingSunKick("target"))
                    {
                        Aimsharp.Cast("Rising Sun Kick");
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rising Sun Kick (Target) - " + SpellID1, Color.Purple);
                        }
                        return true;
                    }

                    if (SpellID1 == 261947 && CanCastFistoftheWhiteTiger("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fist of the White Tiger - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Fist of the White Tiger");
                        return true;
                    }

                    if (SpellID1 == 116095 && CanCastDisable("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Disable - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Disable");
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

            if (Aimsharp.IsCustomCodeOn("RingofPeace") && Aimsharp.SpellCooldown("Ring of Peace") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("BonedustBrew") && Aimsharp.SpellCooldown("Bonedust Brew") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            //Queues
            bool FlyingSerpentKick = Aimsharp.IsCustomCodeOn("FlyingSerpentKick");
            if ((Aimsharp.SpellCooldown("Flying Serpent Kick") > 2000 || Aimsharp.LastCast() == "Flying Serpent Kick") && FlyingSerpentKick)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flying Serpent Kick queue toggle", Color.Purple);
                }
                Aimsharp.Cast("FlyingSerpentKickOff");
                return true;
            }

            if (FlyingSerpentKick && CanCastFlyingSerpentKick("player") == true)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Flying Serpent Kick through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Flying Serpent Kick");
                return true;
            }

            string RingofPeaceCast = GetDropDown("Ring of Peace Cast:");
            bool RingofPeace = Aimsharp.IsCustomCodeOn("RingofPeace");
            if (Aimsharp.SpellCooldown("Ring of Peace") - Aimsharp.GCD() > 2000 && RingofPeace)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Ring of Peace Queue", Color.Purple);
                }
                Aimsharp.Cast("RingofPeaceOff");
                return true;
            }

            if (RingofPeace && CanCastRingofPeace("player"))
            {
                switch (RingofPeaceCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Peace - " + RingofPeaceCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Ring of Peace");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Peace - " + RingofPeaceCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofPeaceC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Peace - " + RingofPeaceCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofPeaceP");
                        return true;
                }
            }

            string BonedustBrewCast = GetDropDown("Bonedust Brew Cast:");
            bool BonedustBrew = Aimsharp.IsCustomCodeOn("BonedustBrew");
            if (Aimsharp.SpellCooldown("Bonedust Brew") - Aimsharp.GCD() > 2000 && BonedustBrew)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Bonedust Brew Queue", Color.Purple);
                }
                Aimsharp.Cast("BonedustBrewOff");
                return true;
            }

            if (BonedustBrew && CanCastBonedustBrew("player") && (BonedustBrewCast == "Player" && Aimsharp.Range("target") <= 5 || BonedustBrewCast != "Player"))
            {
                switch (BonedustBrewCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Bonedust Brew");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("BonedustBrewC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("BonedustBrewP");
                        return true;
                }
            }

            bool Transcendence = Aimsharp.IsCustomCodeOn("Transcendence");
            //Queue Transcendence
            if (Aimsharp.SpellCooldown("Transcendence") - Aimsharp.GCD() > 2000 && Transcendence)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Transcendence queue toggle", Color.Purple);
                }
                Aimsharp.Cast("TranscendenceOff");
                return true;
            }

            if (Transcendence && Aimsharp.CanCast("Transcendence", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Transcendence through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Transcendence");
                return true;
            }

            bool Transfer = Aimsharp.IsCustomCodeOn("Transfer");
            //Queue Transfer
            if (Aimsharp.SpellCooldown("Transfer") - Aimsharp.GCD() > 2000 && Transfer)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Transfer queue toggle", Color.Purple);
                }
                Aimsharp.Cast("TransferOff");
                return true;
            }

            if (Transfer && Aimsharp.CanCast("Transfer", "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Transfer through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Transcendence: Transfer");
                return true;
            }

            bool Paralysis = Aimsharp.IsCustomCodeOn("Paralysis");
            //Queue Paralysis
            if (Paralysis && Aimsharp.SpellCooldown("Paralysis") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Paralysis queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ParalysisOff");
                return true;
            }

            if (Paralysis && CanCastParalysis("target"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Paralysis through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Paralysis");
                return true;
            }

            bool LegSweep = Aimsharp.IsCustomCodeOn("LegSweep");
            //Queue Leg Sweep
            if (LegSweep && Aimsharp.SpellCooldown("Leg Sweep") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Leg Sweep queue toggle", Color.Purple);
                }
                Aimsharp.Cast("LegSweepOff");
                return true;
            }

            if (LegSweep && CanCastLegSweep("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Leg Sweep through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Leg Sweep");
                return true;
            }

            bool Vivify = Aimsharp.IsCustomCodeOn("Vivify");
            //Queue Vivify Spam
            if (Vivify && (Aimsharp.CanCast("Vivify", "player", false, true) || Aimsharp.CanCast("Vivify", "target", true, true)) && !Aimsharp.PlayerIsMoving())
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Vivify due to toggle being On", Color.Purple);
                }
                Aimsharp.Cast("Vivify");
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
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 6 && TargetInCombat)
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