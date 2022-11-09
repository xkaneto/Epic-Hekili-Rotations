using System.Linq;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class KanetosRogueAssassinationHekili : Rotation
    {
        Random Timer;

        private static string Language = "English";

        #region SpellFunctions
        #endregion

        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "Distract", "Blind", "Sap", "KidneyShot", "NoCycle", "FunnelAOE",};
        private List<string> m_DebuffsList = new List<string> { "Sap", "Blind", "Garrote", "Rupture", "Serrated Bone Spike", };
        private List<string> m_BuffsList = new List<string> { "Stealth", "Vanish", "Blindside", "Subterfuge",};
        private List<string> m_BloodlustBuffsList = new List<string> { "Bloodlust", "Heroism", "Time Warp", "Primal Rage", "Drums of Rage" };
        private List<string> m_ItemsList = new List<string> { "Healthstone" };

        private List<string> m_SpellBook_General = new List<string> {
            //Covenants
            "Echoing Reprimand", //385616,323547
            "Flagellation", //323654 , 384631
            "Sepsis", //328305 , 385408
            "Serrated Bone Spike", //328547 , 385424

            //Interrupt
            "Kick", //1766

            //General Rogue
            "Ambush", //8676
            "Cheap Shot", //1833
            "Crimson Vial", //185311
            "Distract", //1725
            "Eviscerate", //196819
            "Fleshcraft",
            "Instant Poison", //315584
            "Kidney Shot", //408
            "Slice and Dice", //315496
            "Sprint", //2983
            "Stealth", //1784
            "Vanish", //1856

            //General Talents
            "Blind", //2094
            "Cloak of Shadows", //31224
            "Cold Blood", //382245
            "Evasion", //5277
            "Feint", //1966
            "Gouge", //1776
            "Marked for Death", //137619
            "Numbing Poison", //5761
            "Sap", //6770
            "Shadow Dance", //185313
            "Shadowstep", //36554
            "Shiv", //5938
            "Thistle Tea", //381623
            "Tricks of the Trade", //57934
        };

        private List<string> m_SpellBook_Assassination = new List<string> {
            //Assassination Rogue
            "Crimson Tempest",
            "Envenom",
            "Exsanguinate",
            "Fan of Knives",
            "Garrote",
            "Mutilate",
            "Poisoned Knife",
            "Rupture",
            "Shadowstep",
            "Vendetta",
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

        private bool TalentDeeperStratagem()
        {
            if (Aimsharp.Talent(3, 2))
                return true;

            return false;
        }
        #endregion

        #region CanCasts
        private bool CanCastSepsis(string unit)
        {
            if (Aimsharp.CanCast("Sepsis", unit, true, true) || (Aimsharp.SpellCooldown("Sepsis") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 25 && Aimsharp.Range(unit) <= 5 && Aimsharp.CovenantID() == 3 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSerratedBoneSpike(string unit)
        {
            if (Aimsharp.CanCast("Serrated Bone Spike", unit, true, true) || ((Aimsharp.SpellCooldown("Serrated Bone Spike") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) || Aimsharp.SpellCharges("Serrated Bone Spike") >= 1 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)) && Aimsharp.Power("player") >= 15 && Aimsharp.Range(unit) <= 30 && Aimsharp.CovenantID() == 4 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastEchoingReprimand(string unit)
        {
            if (Aimsharp.CanCast("Echoing Reprimand", unit, true, true) || (Aimsharp.SpellCooldown("Echoing Reprimand") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 10 && Aimsharp.Range(unit) <= 5 && Aimsharp.CovenantID() == 1 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFlagellation(string unit)
        {
            if (Aimsharp.CanCast("Flagellation", unit, true, true) || (Aimsharp.SpellCooldown("Flagellation") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 5 && Aimsharp.CovenantID() == 2 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastKick(string unit)
        {
            if (Aimsharp.CanCast("Kick", unit, true, true) || (Aimsharp.SpellCooldown("Kick") <= 0 && Aimsharp.Range(unit) <= 5 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastEviscerate(string unit)
        {
            if (Aimsharp.CanCast("Eviscerate", unit, true, true) || (Aimsharp.SpellCooldown("Eviscerate") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 35 && Aimsharp.PlayerSecondaryPower() >= 1 && Aimsharp.Range(unit) <= 5 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastCheapShot(string unit)
        {
            if (Aimsharp.CanCast("Cheap Shot", unit, true, true) || (Aimsharp.SpellCooldown("Cheap Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 40 && Aimsharp.Range(unit) <= 5 && (Aimsharp.HasBuff("Stealth", "player", true) || Aimsharp.HasBuff("Shadow Dance", "player", true) || Aimsharp.HasBuff("Vanish", "player", true) || Aimsharp.HasBuff("Subterfuge", "player", true)) && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastStealth(string unit)
        {
            if (Aimsharp.CanCast("Stealth", unit, false, true) || (Aimsharp.SpellCooldown("Stealth") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !Aimsharp.HasBuff("Stealth", "player", true) && !Aimsharp.InCombat("player") && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSprint(string unit)
        {
            if (Aimsharp.CanCast("Sprint", unit, false, true) || (Aimsharp.SpellCooldown("Sprint") <= 0 && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastAmbush(string unit)
        {
            if (Aimsharp.CanCast("Ambush", unit, true, true) || (Aimsharp.SpellCooldown("Ambush") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && (Aimsharp.Power("player") >= 40 || Aimsharp.HasBuff("Blindside", "player", true)) && Aimsharp.Range(unit) <= 5 && (Aimsharp.HasBuff("Stealth", "player", true) || Aimsharp.HasBuff("Shadow Dance", "player", true) || Aimsharp.HasBuff("Vanish", "player", true) || Aimsharp.HasBuff("Blindside", "player", true) || Aimsharp.HasBuff("Subterfuge", "player", true)) && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastCrimsonVial(string unit)
        {
            if (Aimsharp.CanCast("Crimson Vial", unit, false, true) || (Aimsharp.SpellCooldown("Crimson Vial") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 15 && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSliceandDice(string unit)
        {
            if (Aimsharp.CanCast("Slice and Dice", unit, false, true) || (Aimsharp.SpellCooldown("Slice and Dice") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 25 && Aimsharp.PlayerSecondaryPower() >= 1 && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSap(string unit)
        {
            if (Aimsharp.CanCast("Sap", unit, true, true) || (Aimsharp.SpellCooldown("Sap") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 35 && Aimsharp.Range(unit) <= 10 && (Aimsharp.HasBuff("Stealth", "player", true) || Aimsharp.HasBuff("Shadow Dance", "player", true) || Aimsharp.HasBuff("Vanish", "player", true) || Aimsharp.HasBuff("Subterfuge", "player", true)) && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastKidneyShot(string unit)
        {
            if (Aimsharp.CanCast("Kidney Shot", unit, true, true) || (Aimsharp.SpellCooldown("Kidney Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 25 && Aimsharp.PlayerSecondaryPower() >= 1 && Aimsharp.Range(unit) <= 5 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastEvasion(string unit)
        {
            if (Aimsharp.CanCast("Evasion", unit, false, true) || (Aimsharp.SpellCooldown("Evasion") <= 0 && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastVanish(string unit)
        {
            if (Aimsharp.CanCast("Vanish", unit, false, true) || (Aimsharp.SpellCooldown("Vanish") <= 0 && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastDistract(string unit)
        {
            if (Aimsharp.CanCast("Distract", unit, false, true) || (Aimsharp.SpellCooldown("Distract") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }


        private bool CanCastShiv(string unit)
        {
            if (Aimsharp.CanCast("Shiv", unit, true, true) || (Aimsharp.SpellCooldown("Shiv") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 20 && Aimsharp.Range(unit) <= 5 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFeint(string unit)
        {
            if (Aimsharp.CanCast("Feint", unit, false, true) || (Aimsharp.SpellCooldown("Feint") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 30 && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastBlind(string unit)
        {
            if (Aimsharp.CanCast("Blind", unit, true, true) || (Aimsharp.SpellCooldown("Blind") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 15 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastCloakofShadows(string unit)
        {
            if (Aimsharp.CanCast("Cloak of Shadows", unit, false, true) || (Aimsharp.SpellCooldown("Cloak of Shadows") <= 0 && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFleshcraft(string unit)
        {
            if (Aimsharp.CanCast("Fleshcraft", unit, false, true) || (Aimsharp.SpellCooldown("Fleshcraft") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.CovenantID() == 4 && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastMarkedforDeath(string unit)
        {
            if (Aimsharp.CanCast("Marked for Death", unit, true, true) || (Aimsharp.SpellCooldown("Marked for Death") <= 0 && Aimsharp.Range(unit) <= 30 && Aimsharp.Talent(3,3) && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastMutilate(string unit)
        {
            if (Aimsharp.CanCast("Mutilate", unit, true, true) || (Aimsharp.SpellCooldown("Mutilate") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 50 && Aimsharp.Range(unit) <= 5 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastGarrote(string unit)
        {
            if (Aimsharp.CanCast("Garrote", unit, true, true) || (Aimsharp.SpellCooldown("Garrote") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 45 && Aimsharp.Range(unit) <= 5 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastRupture(string unit)
        {
            if (Aimsharp.CanCast("Rupture", unit, true, true) || (Aimsharp.SpellCooldown("Rupture") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 25 && Aimsharp.PlayerSecondaryPower() >= 1 && Aimsharp.Range(unit) <= 5 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFanofKnives(string unit)
        {
            if (Aimsharp.CanCast("Fan of Knives", unit, false, true) || (Aimsharp.SpellCooldown("Fan of Knives") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 35 && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastEnvenom(string unit)
        {
            if (Aimsharp.CanCast("Envenom", unit, true, true) || (Aimsharp.SpellCooldown("Envenom") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 35 && Aimsharp.PlayerSecondaryPower() >= 1 && Aimsharp.Range(unit) <= 5 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastPoisonedKnife(string unit)
        {
            if (Aimsharp.CanCast("Poisoned Knife", unit, true, true) || (Aimsharp.SpellCooldown("Poisoned Knife") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 40 && Aimsharp.Range(unit) <= 30 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastVendetta(string unit)
        {
            if (Aimsharp.CanCast("Vendetta", unit, true, true) || (Aimsharp.SpellCooldown("Vendetta") <= 0 && Aimsharp.Range(unit) <= 30 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastExsanguinate(string unit)
        {
            if (Aimsharp.CanCast("Exsanguinate", unit, true, true) || (Aimsharp.SpellCooldown("Exsanguinate") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 25 && Aimsharp.Range(unit) <= 5 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastCrimsonTempest(string unit)
        {
            if (Aimsharp.CanCast("Crimson Tempest", unit, false, true) || (Aimsharp.SpellCooldown("Crimson Tempest") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 35 && Aimsharp.PlayerSecondaryPower() >= 1 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastShadowstep(string unit)
        {
            if (Aimsharp.CanCast("Shadowstep", unit, false, true) || (Aimsharp.SpellCooldown("Shadowstep") <= 0 && Aimsharp.Range(unit) <= 25 && TargetAlive() && Aimsharp.GetPlayerLevel() >= 60 && !TorghastList.Contains(Aimsharp.GetMapID())))
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

        private void InitializeMacros()
        {
            //Auto Target
            Macros.Add("TargetEnemy", "/targetenemy");

            //Trinket
            Macros.Add("TopTrinket", "/use 13");
            Macros.Add("BotTrinket", "/use 14");

            //Healthstone
            Macros.Add("UseHealthstone", "/use Healthstone");

            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + (Aimsharp.Latency + 100));

            //Queues
            Macros.Add("DistractOff", "/" + FiveLetters + " Distract");
            Macros.Add("DistractC", "/cast [@cursor] Distract");
            Macros.Add("DistractP", "/cast [@player] Distract");
            Macros.Add("BlindOff", "/" + FiveLetters + " Blind");
            Macros.Add("SapOff", "/" + FiveLetters + " Sap");
            Macros.Add("KidneyShotOff", "/" + FiveLetters + " KidneyShot");

            Macros.Add("GarroteMO", "/cast [@mouseover] Garrote");
            Macros.Add("RuptureMO", "/cast [@mouseover] Rupture");
            Macros.Add("BoneSpikeMO", "/cast [@mouseover] Serrated Bone Spike");
            Macros.Add("BlindMO", "/cast [@mouseover] Blind");

            Macros.Add("FunnelOn", "/run Hekili.State.settings.spec.settings.priority_rotation = true");
            Macros.Add("FunnelOff", "/run Hekili.State.settings.spec.settings.priority_rotation = false");

        }

        private void InitializeSpells()
        {
            foreach (string Spell in m_SpellBook_General)
                Spellbook.Add(Spell);

            foreach (string Spell in m_SpellBook_Assassination)
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

            CustomFunctions.Add("GarroteDebuffCheck", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Garrote','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,_,_,_,source  = UnitDebuff('mouseover', y) if name == 'Garrote' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("RuptureDebuffCheck", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Rupture','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,_,_,_,source  = UnitDebuff('mouseover', y) if name == 'Rupture' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("BoneSpikeDebuffCheck", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Serrated Bone Spike','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,_,_,_,source  = UnitDebuff('mouseover', y) if name == 'Serrated Bone Spike' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("HekiliWait", "if HekiliDisplayPrimary.Recommendations[1].wait ~= nil and HekiliDisplayPrimary.Recommendations[1].wait * 1000 > 0 then return math.floor(HekiliDisplayPrimary.Recommendations[1].wait * 1000) end return 0");

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("TargetIsMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitExists('target') and UnitIsDead('target') ~= true and UnitIsUnit('mouseover', 'target') then return 1 end; return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");

            CustomFunctions.Add("CycleNotEnabled", "local cycle = 0 if Hekili.State.settings.spec.cycle == true then cycle = 1 else if Hekili.State.settings.spec.cycle == false then cycle = 2 end end return cycle");

            CustomFunctions.Add("FunnelAOE", "if Hekili.State.settings.spec.settings.priority_rotation == false then return 1 else if Hekili.State.settings.spec.settings.priority_rotation == true then return 2 end end return 0");
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
            Settings.Add(new Setting("Randomize Kicks:", false));
            Settings.Add(new Setting("Kick at milliseconds remaining", 50, 1500, 500));
            Settings.Add(new Setting("Kick channels after milliseconds", 50, 1500, 500));
            Settings.Add(new Setting("General"));
            Settings.Add(new Setting("Auto Start Combat:", true));
            Settings.Add(new Setting("Stealth Out of Combat:", true));
            Settings.Add(new Setting("Auto Vial @ HP%", 0, 100, 35));
            Settings.Add(new Setting("Auto Cloak @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Evasion @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Slice and Dice Out of Combat:", true));
            Settings.Add(new Setting("Spread Bone Spike with Mouseover:", false));
            Settings.Add(new Setting("Kidney Shot Queue - Dont wait for Max CP", false));
            Settings.Add(new Setting("Distract Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Assassination"));
            Settings.Add(new Setting("Spread Garrote with Mouseover:", false));
            Settings.Add(new Setting("Spread Rupture with Mouseover:", false));
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

            Aimsharp.PrintMessage("Kanetos PVE - Rogue Assassination", Color.Yellow);
             Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.Red);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.Brown);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/rogue/assassination/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("Poisons are Manual - apply them before Combat", Color.Green);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FunnelAOE - Enables Funnel AOE in Hekili", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Blind - Casts Blind @ Mouseover on the next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Sap - Casts Sap @ Target on the next GCD, turns off Auto Combat while On", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Distract - Casts Distract @ Manual/Cursor/Player on the next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " KidneyShot - Casts Kidney Shit @ Target next GCD", Color.Yellow);
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

            int EvasionHP = GetSlider("Auto Evasion @ HP%");
            int CloakHP = GetSlider("Auto Cloak @ HP%");
            int VialHP = GetSlider("Auto Vial @ HP%");

            int GarroteDebuffMO = Aimsharp.CustomFunction("GarroteDebuffCheck");
            int RuptureDebuffMO = Aimsharp.CustomFunction("RuptureDebuffCheck");
            int BoneSpikeDebuffMO = Aimsharp.CustomFunction("BoneSpikeDebuffCheck");
            bool MOGarrote = GetCheckBox("Spread Garrote with Mouseover:") == true;
            bool MORupture = GetCheckBox("Spread Rupture with Mouseover:") == true;
            bool MOBoneSpike = GetCheckBox("Spread Bone Spike with Mouseover:") == true;
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

            #region Hekili Toggles
            if (Aimsharp.CustomFunction("FunnelAOE") == 1 && Aimsharp.IsCustomCodeOn("FunnelAOE"))
            {
                Aimsharp.Cast("FunnelOn");
                return true;
            }

            if (Aimsharp.CustomFunction("FunnelAOE") == 2 && !Aimsharp.IsCustomCodeOn("FunnelAOE"))
            {
                Aimsharp.Cast("FunnelOff");
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

            if (Aimsharp.IsCustomCodeOn("Distract") && Aimsharp.SpellCooldown("Distract") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                if (CanCastKick("target"))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValue)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Kick", true);
                        return true;
                    }
                }

                if (CanCastKick("target"))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfter)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Kick", true);
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
                    Aimsharp.Cast("UseHealthstone");
                    return true;
                }
            }

            //Auto Evasion
            if(PlayerHP <= EvasionHP && CanCastEvasion("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Evasion - Player HP% " + PlayerHP + " due to setting being on HP% " + EvasionHP, Color.Purple);
                }
                Aimsharp.Cast("Evasion", true);
                return true;
            }

            //Auto Cloak of Shadows
            if (PlayerHP <= CloakHP && CanCastCloakofShadows("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Cloak of Shadows - Player HP% " + PlayerHP + " due to setting being on HP% " + CloakHP, Color.Purple);
                }
                Aimsharp.Cast("Cloak of Shadows", true);
                return true;
            }

            //Auto Crimson Vial
            if (PlayerHP <= VialHP && CanCastCrimsonVial("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Crimson Vial - Player HP% " + PlayerHP + " due to setting being on HP% " + VialHP, Color.Purple);
                }
                Aimsharp.Cast("Crimson Vial");
                return true;
            }
            #endregion

            #region Queues
            //Queues
            bool Sap = Aimsharp.IsCustomCodeOn("Sap");
            if (Sap)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sap Queue", Color.Purple);
                }
                Aimsharp.Cast("SapOff");
                return true;
            }

            bool Blind = Aimsharp.IsCustomCodeOn("Blind");
            if (Aimsharp.SpellCooldown("Blind") - Aimsharp.GCD() > 2000 && Blind)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blind Queue", Color.Purple);
                }
                Aimsharp.Cast("BlindOff");
                return true;
            }

            if (Blind && Aimsharp.CanCast("Blind", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blind - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlindMO");
                return true;
            }

            bool KidneyShot = Aimsharp.IsCustomCodeOn("KidneyShot");
            if (Aimsharp.SpellCooldown("Kidney Shot") - Aimsharp.GCD() > 2000 && KidneyShot)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Kidney Shot Queue", Color.Purple);
                }
                Aimsharp.Cast("KidneyShotOff");
                return true;
            }

            if (KidneyShot && Aimsharp.CanCast("Kidney Shot", "target", true, true) && (Aimsharp.PlayerSecondaryPower() >= 5 && !TalentDeeperStratagem() || Aimsharp.PlayerSecondaryPower() >= 6 && TalentDeeperStratagem() || GetCheckBox("Kidney Shot Queue - Dont wait for Max CP")))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Kidney Shot - Queue", Color.Purple);
                }
                Aimsharp.Cast("Kidney Shot");
                return true;
            }

            string DistractCast = GetDropDown("Distract Cast:");
            bool Distract = Aimsharp.IsCustomCodeOn("Distract");
            if (Aimsharp.SpellCooldown("Distract") - Aimsharp.GCD() > 2000 && Distract)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Distract Queue", Color.Purple);
                }
                Aimsharp.Cast("DistractOff");
                return true;
            }

            if (Distract && Aimsharp.CanCast("Distract", "player", false, true))
            {
                switch (DistractCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Distract - " + DistractCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Distract");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Distract - " + DistractCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DistractC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Distract - " + DistractCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DistractP");
                        return true;
                }
            }
            #endregion

            #region Auto Target
            //Hekili Cycle
            if (!NoCycle && Aimsharp.CustomFunction("CycleNotEnabled") == 1 && Aimsharp.CustomFunction("HekiliCycle") == 1 && EnemiesInMelee > 1 && SpellID1 != 137619)
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
                //Bone Spike Mouseover Spread
                if (CanCastSerratedBoneSpike("mouseover") && Aimsharp.HasDebuff("Serrated Bone Spike", "target", true) && Aimsharp.CustomFunction("TargetIsMouseover") == 0)
                {
                    if (MOBoneSpike && BoneSpikeDebuffMO == 1)
                    {
                        Aimsharp.Cast("BoneSpikeMO");
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bone Spike (Mouseover)", Color.Purple);
                        }
                        return true;
                    }
                }

                //Garrote Mouseover Spread
                if (CanCastGarrote("mouseover") && Aimsharp.HasDebuff("Garrote", "target", true) && (Aimsharp.PlayerSecondaryPower() < 5 && !TalentDeeperStratagem() || TalentDeeperStratagem() && Aimsharp.PlayerSecondaryPower() < 6) && Aimsharp.CustomFunction("TargetIsMouseover") == 0)
                {
                    if (MOGarrote && GarroteDebuffMO == 1)
                    {
                        Aimsharp.Cast("GarroteMO");
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Garrote (Mouseover)", Color.Purple);
                        }
                        return true;
                    }
                }

                //Rupture Mouseover Spread
                if (CanCastRupture("mouseover") && Aimsharp.HasDebuff("Rupture", "target", true) && (Aimsharp.PlayerSecondaryPower() >= 5 && !TalentDeeperStratagem() || TalentDeeperStratagem() && Aimsharp.PlayerSecondaryPower() >= 6) && Aimsharp.CustomFunction("TargetIsMouseover") == 0)
                {
                    if (MORupture && RuptureDebuffMO == 1)
                    {
                        Aimsharp.Cast("RuptureMO");
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rupture (Mouseover)", Color.Purple);
                        }
                        return true;
                    }
                }
                #endregion

                #region Kidney Shot
                if (KidneyShot && !GetCheckBox("Kidney Shot Queue - Dont wait for Max CP"))
                {
                    if (SpellID1 == 1329 && CanCastMutilate("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mutilate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Mutilate");
                        return true;
                    }

                    if (SpellID1 == 703 && CanCastGarrote("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Garrote - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Garrote");
                        return true;
                    }

                    else
                    {
                        if (CanCastGarrote("target") && (Aimsharp.PlayerSecondaryPower() == 4 && !TalentDeeperStratagem() || TalentDeeperStratagem() && Aimsharp.PlayerSecondaryPower() == 5))
                        {
                            Aimsharp.Cast("Garrote");
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Casting Garrote for Kidney Shot - Combo Points: " + Aimsharp.PlayerSecondaryPower(), Color.Purple);
                            }
                            return true;
                        }

                        if (CanCastMutilate("target") && (Aimsharp.PlayerSecondaryPower() <= 3 && !TalentDeeperStratagem() || TalentDeeperStratagem() && Aimsharp.PlayerSecondaryPower() <= 4))
                        {
                            Aimsharp.Cast("Mutilate");
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Casting Mutilate for Kidney Shot - Combo Points: " + Aimsharp.PlayerSecondaryPower(), Color.Purple);
                            }
                            return true;
                        }
                    }

                }
                #endregion

                if (UnitDebuffSap("target") == 0 && UnitDebuffBlind("target") == 0 && !KidneyShot && Wait <= 200)
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
                    if (SpellID1 == 323547 && CanCastEchoingReprimand("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Echoing Reprimand - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Echoing Reprimand");
                        return true;
                    }

                    if (SpellID1 == 328305 && CanCastSepsis("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sepsis - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Sepsis");
                        return true;
                    }

                    if (SpellID1 == 328547 && CanCastSerratedBoneSpike("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Serrated Bone Spike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Serrated Bone Spike");
                        return true;
                    }

                    if (SpellID1 == 323654 && CanCastFlagellation("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flagellation - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Flagellation");
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

                    #region General Spells - NoGCD
                    //Class Spells
                    //Instant [GCD FREE]
                    if (SpellID1 == 1766 && CanCastKick("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Kick - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Kick", true);
                        return true;
                    }

                    if (SpellID1 == 137619 && CanCastMarkedforDeath("target") && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Marked for Death - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Marked for Death", true);
                        return true;
                    }

                    if (SpellID1 == 5277 && CanCastEvasion("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Evasion - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Evasion", true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    //General Rogue
                    //Instant [GCD]
                    ///Player
                    if ((SpellID1 == 115191 || SpellID1 == 1784) && CanCastStealth("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Stealth - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Stealth");
                        return true;
                    }

                    if (SpellID1 == 315496 && CanCastSliceandDice("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Slice and Dice - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Slice and Dice");
                        return true;
                    }

                    if (SpellID1 == 185311 && CanCastCrimsonVial("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Crimson Vial - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Crimson Vial");
                        return true;
                    }

                    if (SpellID1 == 1856 && CanCastVanish("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vanish - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Vanish");
                        return true;
                    }

                    if (SpellID1 == 2983 && CanCastSprint("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sprint - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Sprint");
                        return true;
                    }

                    if (SpellID1 == 1966 && CanCastFeint("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Feint - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Feint");
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    ///Target
                    if (SpellID1 == 2094 && CanCastBlind("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blind - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Blind");
                        return true;
                    }

                    if (SpellID1 == 1833 && CanCastCheapShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cheap Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Cheap Shot");
                        return true;
                    }

                    if (SpellID1 == 408 && CanCastKidneyShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Kidney Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Kidney Shot");
                        return true;
                    }

                    if (SpellID1 == 196819 && CanCastEviscerate("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Eviscerate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Eviscerate");
                        return true;
                    }

                    if (SpellID1 == 8676 && CanCastAmbush("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ambush - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Ambush");
                        return true;
                    }
                    #endregion

                    #region Assassination Spells - Player GCD
                    //Assassination
                    ////Player

                    if (SpellID1 == 51723 && CanCastFanofKnives("player") && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fan of Knives - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Fan of Knives");
                        return true;
                    }

                    if (SpellID1 == 121411 && CanCastCrimsonTempest("player") && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Crimson Tempest - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Crimson Tempest");
                        return true;
                    }
                    #endregion

                    #region Assassination Spells - Target GCD
                    ////Target
                    if (SpellID1 == 5938 && CanCastShiv("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shiv - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Shiv");
                        return true;
                    }

                    if (SpellID1 == 1943 && CanCastRupture("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rupture - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Rupture");
                        return true;
                    }

                    if (SpellID1 == 36554 && CanCastShadowstep("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowstep - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Shadowstep");
                        return true;
                    }

                    if (SpellID1 == 1329 && CanCastMutilate("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mutilate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Mutilate");
                        return true;
                    }

                    if (SpellID1 == 703 && CanCastGarrote("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Garrote - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Garrote");
                        return true;
                    }

                    if (SpellID1 == 32645 && CanCastEnvenom("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Envenom - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Envenom");
                        return true;
                    }

                    if (SpellID1 == 185565 && CanCastPoisonedKnife("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Poisoned Knife - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Poisoned Knife");
                        return true;
                    }

                    if (SpellID1 == 79140 && CanCastVendetta("target") && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vendetta - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Vendetta");
                        return true;
                    }

                    if (SpellID1 == 200806 && CanCastExsanguinate("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Exsanguinate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Exsanguinate");
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
            bool SnDOOC = GetCheckBox("Slice and Dice Out of Combat:");
            bool StealthOOC = GetCheckBox("Stealth Out of Combat:");
            bool Sap = Aimsharp.IsCustomCodeOn("Sap");
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

            #region Hekili Toggles
            if (Aimsharp.CustomFunction("FunnelAOE") == 1 && Aimsharp.IsCustomCodeOn("FunnelAOE"))
            {
                Aimsharp.Cast("FunnelOn");
                return true;
            }

            if (Aimsharp.CustomFunction("FunnelAOE") == 2 && !Aimsharp.IsCustomCodeOn("FunnelAOE"))
            {
                Aimsharp.Cast("FunnelOff");
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

            if (Aimsharp.IsCustomCodeOn("Distract") && Aimsharp.SpellCooldown("Distract") - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            //Queues
            bool Blind = Aimsharp.IsCustomCodeOn("Blind");
            if (Aimsharp.SpellCooldown("Blind") - Aimsharp.GCD() > 2000 && Blind)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blind Queue", Color.Purple);
                }
                Aimsharp.Cast("BlindOff");
                return true;
            }

            if (Blind && Aimsharp.CanCast("Blind", "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blind - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlindMO");
                return true;
            }

            string DistractCast = GetDropDown("Distract Cast:");
            bool Distract = Aimsharp.IsCustomCodeOn("Distract");
            if (Aimsharp.SpellCooldown("Distract") - Aimsharp.GCD() > 2000 && Distract)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Distract Queue", Color.Purple);
                }
                Aimsharp.Cast("DistractOff");
                return true;
            }

            if (Distract && Aimsharp.CanCast("Distract", "player", false, true))
            {
                switch (DistractCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Distract - " + DistractCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("Distract");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Distract - " + DistractCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DistractC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Distract - " + DistractCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DistractP");
                        return true;
                }
            }

            //Sap Queue
            if (Aimsharp.DebuffRemaining("Sap", "target", true) >= 59000 && Sap)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sap Queue", Color.Purple);
                }
                Aimsharp.Cast("SapOff");
                return true;
            }

            if (Sap && Aimsharp.CanCast("Sap", "target", true, true) && Enemy && TargetAlive())
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Sap (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Sap");
                return true;
            }
            #endregion

            #region Out of Combat Spells
            //Auto Fleshcraft
            if (SpellID1 == 324631 && CanCastFleshcraft("player") && !Moving && !Aimsharp.HasBuff("Stealth", "player", true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fleshcraft - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Fleshcraft");
                return true;
            }

            //General Rogue
            //Instant [GCD]
            ///Player
            if ((SpellID1 == 115191 || SpellID1 == 1784) && CanCastStealth("player") && StealthOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Stealth (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Stealth");
                return true;
            }

            if (CanCastStealth("player") && !Aimsharp.HasBuff("Stealth", "player", true) && StealthOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Stealth (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Stealth");
                return true;
            }

            if (SpellID1 == 315496 && CanCastSliceandDice("player") && Enemy && TargetAlive() && !Sap && SnDOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Slice and Dice (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast("Slice and Dice");
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
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 6 && UnitDebuffSap("target") == 0 && UnitDebuffBlind("target") == 0 && !Sap && TargetInCombat)
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