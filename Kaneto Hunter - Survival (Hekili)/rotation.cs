using System.Linq;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class KanetoHunterSurvivalHekili : Rotation
    {
        private static string Language = "English";

        #region SpellFunctions
        #endregion

        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "FreezingTrap", "TarTrap", "Turtle", "Intimidation", "NoInterrupts", "NoCycle", "WildSpirits", "ResonatingArrow", "BindingShot", "Flare", "FlareCursor", "TarTrapCursor", "SerpentSting", };
        private List<string> m_DebuffsList = new List<string> {  };
        private List<string> m_BuffsList = new List<string> { "Mend Pet", "Flayer's Mark", "Aspect of the Eagle", "Viper's Venom", };
        private List<string> m_BloodlustBuffsList = new List<string> { "Bloodlust", "Heroism", "Time Warp", "Primal Rage", "Drums of Rage" };
        private List<string> m_ItemsList = new List<string> {"Healthstone" };

        private List<string> m_SpellBook = new List<string> {
            //Covenants
            "Flayed Shot",
            "Death Chakram",
            "Wild Spirits",
            "Resonating Arrow",

            "Summon Steward", "Fleshcraft",

            //Interrupt
            "Muzzle", //187707

            //General
            "A Murder of Crows",
            "Arcane Shot",
            "Aspect of the Eagle", //186289
            "Aspect of the Turtle",
            "Barrage",
            "Binding Shot",
            "Butchery", //212436
            "Carve", //187708
            "Chakrams",
            "Concussive Shot", // New
            "Coordinated Assault", //360952
            "Exhilaration",
            "Flanking Strike", //269751
            "Flare",
            "Fortitude of the Bear",
            "Freezing Trap",
            "Fury of the Eagle", //203415 -- New
            "Harpoon", //190925
            "High Explosive Trap", //New
            "Hunter's Mark",
            "Intimidation",
            "Kill Command", //259489
            "Kill Shot", //320976
            "Mend Pet",
            "Mongoose Bite", //259387
            "Multi-Shot",
            "Pheromone Bomb", //270323
            "Raptor Strike", //186270
            "Sentinel Owl",
            "Serpent Sting",
            "Shrapnel Bomb", //270335
            "Spearhead", //360966
            "Steel Trap",
            "Survival of the Fittest",
            "Tar Trap",
            "Tranquilizing Shot",
            "Volatile Bomb", //271045
            "Wailing Arrow",
            "Wildfire Bomb", //259495
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
            if (Aimsharp.CanCast("Kill Shot", "target", true, true) || (Aimsharp.SpellCooldown("Kill Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && (Aimsharp.Health(unit) < 20 || Aimsharp.HasBuff("Flayer's Mark", "player", true)) && (Aimsharp.Power("player") >= 10 || Aimsharp.HasBuff("Flayer's Mark", "player", true)) && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFlayedShot(string unit)
        {
            if (Aimsharp.CanCast("Flayed Shot", unit, true, true) || (Aimsharp.SpellCooldown("Flayed Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && Aimsharp.CovenantID() == 2 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastDeathChakram(string unit)
        {
            if (Aimsharp.CanCast("Death Chakram", unit, true, true) || (Aimsharp.SpellCooldown("Death Chakram") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && Aimsharp.CovenantID() == 4 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastWildSpirits(string unit)
        {
            if (Aimsharp.CanCast("Wild Spirits", unit, false, true) || (Aimsharp.SpellCooldown("Wild Spirits") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.CovenantID() == 3 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastResonatingArrow(string unit)
        {
            if (Aimsharp.CanCast("Resonating Arrow", unit, false, true) || (Aimsharp.SpellCooldown("Resonating Arrow") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.CovenantID() == 1 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFreezingTrap(string unit)
        {
            if (Aimsharp.CanCast("Freezing Trap", unit, false, true) || (Aimsharp.SpellCooldown("Freezing Trap") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastTarTrap(string unit)
        {
            if (Aimsharp.CanCast("Tar Trap", unit, false, true) || (Aimsharp.SpellCooldown("Tar Trap") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSteelTrap(string unit)
        {
            if (Aimsharp.CanCast("Steel Trap", unit, false, true) || (Aimsharp.SpellCooldown("Steel Trap") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastMendPet(string unit)
        {
            if (Aimsharp.CanCast("Mend Pet", unit, true, true) || (Aimsharp.SpellCooldown("Mend Pet") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Health("pet") > 1 && Aimsharp.Range("pet") <= 45 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastAspectoftheTurtle(string unit)
        {
            if (Aimsharp.CanCast("Aspect of the Turtle", unit, false, true) || (Aimsharp.SpellCooldown("Aspect of the Turtle") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastBindingShot(string unit)
        {
            if (Aimsharp.CanCast("Binding Shot", unit, false, true) || (Aimsharp.SpellCooldown("Binding Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)  && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastTranquilizingShot(string unit)
        {
            if (Aimsharp.CanCast("Tranquilizing Shot", unit, true, true) || (Aimsharp.SpellCooldown("Tranquilizing Shot") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }
        private bool CanCastFleshcraft(string unit)
        {
            if (Aimsharp.CanCast("Fleshcraft", unit, false, true) || (Aimsharp.SpellCooldown("Fleshcraft") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.CovenantID() == 4 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSerpentSting(string unit)
        {
            if (Aimsharp.CanCast("Serpent Sting", unit, true, true) || (Aimsharp.SpellCooldown("Serpent Sting") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && (Aimsharp.Power("player") >= 20 || Aimsharp.HasBuff("Viper's Venom", "player", true)) && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastAMurderofCrows(string unit)
        {
            if (Aimsharp.CanCast("A Murder of Crows", unit, true, true) || (Aimsharp.SpellCooldown("A Murder of Crows") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && Aimsharp.Power("player") >= 30 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastIntimidation(string unit)
        {
            if (Aimsharp.CanCast("Intimidation", unit, true, true) || (Aimsharp.SpellCooldown("Intimidation") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Health("pet") > 1 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastKillCommand(string unit)
        {
            if (Aimsharp.CanCast("Kill Command", unit, true, true) || ((Aimsharp.SpellCooldown("Kill Command") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)  && Aimsharp.SpellCharges("Kill Command") >= 1 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)) && Aimsharp.Range(unit) <= 50 && Aimsharp.Health("pet") > 1 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastAspectoftheEagle(string unit)
        {
            if (Aimsharp.CanCast("Aspect of the Eagle", unit, false, true) || (Aimsharp.SpellCooldown("Aspect of the Eagle") <= 0 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastRaptorStrike(string unit)
        {
            if (Aimsharp.CanCast("Raptor Strike", unit, true, true)  || (Aimsharp.SpellCooldown("Raptor Strike") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && (Aimsharp.Range(unit) <= 5 || Aimsharp.HasBuff("Aspect of the Eagle", "player", true) && Aimsharp.Range(unit) <= 40) && Aimsharp.Power("player") >= 30 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastExhilaration(string unit)
        {
            if (Aimsharp.CanCast("Exhilaration", unit, false, true) || (Aimsharp.SpellCooldown("Exhilaration") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastMuzzle(string unit)
        {
            if (Aimsharp.CanCast("Muzzle", unit, true, true) || (Aimsharp.SpellCooldown("Muzzle") <= 0 && Aimsharp.Range(unit) <= 5 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastCarve(string unit)
        {
            if (Aimsharp.CanCast("Carve", unit, false, true) && Aimsharp.Range("target") <= 5 || (Aimsharp.SpellCooldown("Carve") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 5 && Aimsharp.Power("player") >= 35  && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastCoordinatedAssault(string unit)
        {
            if (Aimsharp.CanCast("Coordinated Assault", unit, false, true) || (Aimsharp.SpellCooldown("Coordinated Assault") <= 0 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastHarpoon(string unit)
        {
            if (Aimsharp.CanCast("Harpoon", unit, true, true) || (Aimsharp.SpellCooldown("Harpoon") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) >= 8 && Aimsharp.Range(unit) <= 30 && Aimsharp.Power("player") >= 30 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastWildfireBomb(string unit)
        {
            if (Aimsharp.CanCast("Wildfire Bomb", unit, true, true) || ((Aimsharp.SpellCooldown("Wildfire Bomb") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.SpellCharges("Wildfire Bomb") >= 1 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)) && Aimsharp.Range(unit) <= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastShrapnelBomb(string unit)
        {
            if (Aimsharp.CanCast("Shrapnel Bomb", unit, true, true) || ((Aimsharp.SpellCooldown("Shrapnel Bomb") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.SpellCharges("Shrapnel Bomb") >= 1 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)) && Aimsharp.Range(unit) <= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastVolatileBomb(string unit)
        {
            if (Aimsharp.CanCast("Volatile Bomb", unit, true, true) || ((Aimsharp.SpellCooldown("Volatile Bomb") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.SpellCharges("Volatile Bomb") >= 1 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)) && Aimsharp.Range(unit) <= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastPheromoneBomb(string unit)
        {
            if (Aimsharp.CanCast("Pheromone Bomb", unit, true, true) || ((Aimsharp.SpellCooldown("Pheromone Bomb") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.SpellCharges("Pheromone Bomb") >= 1 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)) && Aimsharp.Range(unit) <= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastButchery(string unit)
        {
            if (Aimsharp.CanCast("Butchery", unit, false, true) && Aimsharp.Range("target") <= 5 || ((Aimsharp.SpellCooldown("Butchery") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) || Aimsharp.SpellCharges("Butchery") >= 1 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)) && Aimsharp.Range("target") <= 5 && Aimsharp.Power("player") >= 30  && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastMongooseBite(string unit)
        {
            if (Aimsharp.CanCast("Mongoose Bite", unit, true, true) || (Aimsharp.SpellCooldown("Mongoose Bite") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && (Aimsharp.Range(unit) <= 5 || Aimsharp.HasBuff("Aspect of the Eagle", "player", true) && Aimsharp.Range(unit) <= 40) && Aimsharp.Power("player") >= 30 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFlankingStrike(string unit)
        {
            if (Aimsharp.CanCast("Flanking Strike", unit, true, true) || (Aimsharp.SpellCooldown("Flanking Strike") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 15 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastChakrams(string unit)
        {
            if (Aimsharp.CanCast("Chakrams", unit, true, true) || (Aimsharp.SpellCooldown("Chakrams") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && Aimsharp.Power("player") >= 15 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFlare(string unit)
        {
            if (Aimsharp.CanCast("Flare", unit, false, true) || (Aimsharp.SpellCooldown("Flare") - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFortitudeOfTheBear(string unit)
        {
            if (Aimsharp.CanCast(FortitudeOfTheBear_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(FortitudeOfTheBear_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSurvivaloftheFittest(string unit)
        {
            if (Aimsharp.CanCast(SurvivalOfTheFittest_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(SurvivalOfTheFittest_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }
        private bool CanCastSentinel(string unit)
        {
            if (Aimsharp.CanCast(SentinelOwl_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(SentinelOwl_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSteelTrap(string unit)
        {
            if (Aimsharp.CanCast(SteelTrap_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(SteelTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastHighExplosiveTrap(string unit)
        {
            if (Aimsharp.CanCast(HighExplosiveTrap_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(HighExplosiveTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }
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
            Macros.Add("Weapon", "/use 16");

            //Healthstone
            Macros.Add("UseHealthstone", "/use Healthstone");


            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + (Aimsharp.Latency + 100));

            Macros.Add("FreezingTrapOff", "/" + FiveLetters + " FreezingTrap");
            Macros.Add("TarTrapOff", "/" + FiveLetters + " TarTrap");
            Macros.Add("IntimidationOff", "/" + FiveLetters + " Intimidation");
            Macros.Add("WildSpiritsOff", "/" + FiveLetters + " WildSpirits");
            Macros.Add("ResonatingArrowOff", "/" + FiveLetters + " ResonatingArrow");
            Macros.Add("BindingShotOff", "/" + FiveLetters + " BindingShot");
            Macros.Add("FlareOff", "/" + FiveLetters + " Flare");
            Macros.Add("SentinelOff", "/" + FiveLetters + " Sentinel");
            Macros.Add("HighExplosiveTrapOff", "/" + FiveLetters + " HighExplosiveTrap");
            Macros.Add("SteelTrapOff", "/" + FiveLetters + " SteelTrap");

            Macros.Add("KillShotSQW", "/cqs\\n/cast Kill Shot");
            Macros.Add("TranqMO", "/cast [@mouseover] Tranquilizing Shot");
            Macros.Add("FlareC", "/cast [@cursor] Flare");
            Macros.Add("FreezingTrapP", "/cast [@player] Freezing Trap");
            Macros.Add("FreezingTrapC", "/cast [@cursor] Freezing Trap");
            Macros.Add("TarTrapP", "/cast [@player] Tar Trap");
            Macros.Add("TarTrapC", "/cast [@cursor] Tar Trap");
            Macros.Add("SentinelC", "/cast [@cursor] " + SentinelOwl_SpellName(Language));
            Macros.Add("HighExplosiveTrapC", "/cast [@cursor] " + HighExplosiveTrap_SpellName(Language));
            Macros.Add("HighExplosiveTrapP", "/cast [@player] " + HighExplosiveTrap_SpellName(Language));
            Macros.Add("SteelTrapC", "/cast [@cursor] " + SteelTrap_SpellName(Language));
            Macros.Add("SteelTrapP", "/cast [@player] " + SteelTrap_SpellName(Language));

            Macros.Add("ResonatingArrowP", "/cast [@player] Resonating Arrow");
            Macros.Add("WildSpiritsP", "/cast [@player] Wild Spirits");
            Macros.Add("ResonatingArrowC", "/cast [@cursor] Resonating Arrow");
            Macros.Add("WildSpiritsC", "/cast [@cursor] Wild Spirits");

            Macros.Add("SerpentStingMO", "/cast [@mouseover] Serpent Sting");
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

            CustomFunctions.Add("GetSpellQueueWindow", "local sqw = GetCVar(\"SpellQueueWindow\"); if sqw ~= nil then return tonumber(sqw); end return 0");

            CustomFunctions.Add("CooldownsToggleCheck", "local loading, finished = IsAddOnLoaded(\"Hekili\") if loading == true and finished == true then local cooldowns = Hekili:GetToggleState(\"cooldowns\") if cooldowns == true then return 1 else if cooldowns == false then return 2 end end end return 0");

            CustomFunctions.Add("UnitIsDead", "if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == true then return 1 end; if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == false then return 2 end; return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");

            CustomFunctions.Add("HekiliWait", "if HekiliDisplayPrimary.Recommendations[1].wait ~= nil and HekiliDisplayPrimary.Recommendations[1].wait * 1000 > 0 then return math.floor(HekiliDisplayPrimary.Recommendations[1].wait * 1000) end return 0");

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("PhialCount", "local count = GetItemCount(177278) if count ~= nil then return count end return 0");

            CustomFunctions.Add("TranqBuffCheck", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Tranquilizing Shot','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType  = UnitBuff('mouseover', y) if debuffType == '' or debuffType == 'Magic' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("VolleyMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Steady Shot','mouseover') == 1 then return 1 end; return 0");

            CustomFunctions.Add("SSCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Serpent Sting','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType,_,_,_  = UnitDebuff('mouseover', y) if name == 'Serpent Sting' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("TargetIsMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitExists('target') and UnitIsDead('target') ~= true and UnitIsUnit('mouseover', 'target') then return 1 end; return 0");

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
            Settings.Add(new Setting("Race:", m_RaceList, "dwarf"));
            Settings.Add(new Setting("Ingame World Latency:", 1, 200, 50));
            Settings.Add(new Setting(" "));
            Settings.Add(new Setting("Use Trinkets on CD, dont wait for Hekili:", false));
            Settings.Add(new Setting("Auto Healthstone @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Kicks/Interrupts"));
            Settings.Add(new Setting("Kick at milliseconds remaining", 50, 1500, 500));
            Settings.Add(new Setting("Kick channels after milliseconds", 50, 1500, 500));
            Settings.Add(new Setting("General"));
            Settings.Add(new Setting("Auto Start Combat:", true));
            Settings.Add(new Setting("Tranquilizing Shot Mouseover:", true));
            Settings.Add(new Setting("Auto Mend Pet @ HP%", 0, 100, 60));
            Settings.Add(new Setting("Auto Exhilaration @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Auto Aspect of the Turtle @ HP%", 0, 100, 20));
            Settings.Add(new Setting("Auto Fortitude of the Bear @ HP%", 0, 100, 30));
            Settings.Add(new Setting("Auto Survival of the Fittest @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Covenant Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Tar Trap Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Steel Trap Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Freezing Trap Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("High Explosive Trap Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Always Cast Flare @ Cursor during Rotation", false));
            Settings.Add(new Setting("Always Cast Tar Trap @ Cursor during Rotation", false));
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

            Aimsharp.PrintMessage("Kanetos PVE - Hunter Survival", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.Red);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.Red);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/hunter/survival/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("Pet Summon is Manual", Color.Green);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FreezingTrap - Casts Freezing Trap @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " TarTrap - Casts Tar Trap @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Flare - Casts Flare @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Intimidation - Casts Intimidation @ Target next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BindingShot - Casts Binding Shot @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " WildSpirits - Casts Wild Spirits @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " ResonatingArrow - Casts Resonating Arrow @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " SerpentSting - Enables Serpent Sting @ Mouseover spread", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FlareCursor - Toggles Flare always @ Cursor (same as Option)", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " TarTrapCursor - Toggles Tar Trap always @ Cursor (same as Option)", Color.Yellow);
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
            int CooldownsToggle = Aimsharp.CustomFunction("CooldownsToggleCheck");
            int Wait = Aimsharp.CustomFunction("HekiliWait");

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
            bool MeleeRange = Aimsharp.Range("target") <= 6;
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
             if (Aimsharp.IsCustomCodeOn("SteelTrap") && Aimsharp.SpellCooldown(SteelTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("HighExplosiveTrap") && Aimsharp.SpellCooldown(HighExplosiveTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("Sentinel") && Aimsharp.SpellCooldown(SentinelOwl_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Interrupts
            if (!NoInterrupts && (Aimsharp.UnitID("target") != 168105 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))) && (Aimsharp.UnitID("target") != 157571 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))))
            {
                if (CanCastMuzzle("target"))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValue)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Muzzle", true);
                        return true;
                    }
                }

                if (CanCastMuzzle("target"))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfter)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast("Muzzle", true);
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

             //Auto Fortitude
            if (CanCastFortitudeOfTheBear("player"))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Fortitude of the Bear @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Auto Fortitude of the Bear - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Fortitude of the Bear @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(FortitudeOfTheBear_SpellName(Language));
                    return true;
                }
            }

            //Auto Survival
            if (CanCastSurvivaloftheFittest("player"))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Survival of the Fittest @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Auto Survival of the Fittest - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Survival of the Fittest @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(SurvivalOfTheFittest_SpellName(Language));
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
                    Aimsharp.Cast("UseHealthstone");
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
            string SteelTrapCast = GetDropDown("Steel Trap Cast:");
            bool SteelTrap = Aimsharp.IsCustomCodeOn("SteelTrap");
            //Queue Steel Trap
            if (SteelTrap && Aimsharp.SpellCooldown(SteelTrap_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Steel Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("SteelTrapOff");
                return true;
            }

            if (SteelTrap && CanCastSteelTrap("player"))
            {
                switch (SteelTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SteelTrap_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SteelTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SteelTrapC");
                        return true;
                }
            }

            string HighExplosiveTrapCast = GetDropDown("High Explosive Trap Cast:");
            bool HighExplosiveTrap = Aimsharp.IsCustomCodeOn("HighExplosiveTrap");
            //Queue High Explosive Trap
            if (HighExplosiveTrap && Aimsharp.SpellCooldown(HighExplosiveTrap_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off High Explosive Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("HighExplosiveTrapOff");
                return true;
            }

            if (HighExplosiveTrap && CanCastHighExplosiveTrap("player"))
            {
                switch (HighExplosiveTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting High Explosive Trap - " + HighExplosiveTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(HighExplosiveTrap_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting High Explosive Trap - " + HighExplosiveTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("HighExplosiveTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting High Explosive Trap - " + HighExplosiveTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("HighExplosiveTrapC");
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

             //Queue Sentinel
            if (Aimsharp.IsCustomCodeOn(SentinelOwl_SpellName(Language)) && Aimsharp.SpellCooldown(SentinelOwl_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sentinel Queue", Color.Purple);
                }
                Aimsharp.Cast("SentinelOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn(SentinelOwl_SpellName(Language)) && CanCastSentinel("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Sentinel through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("SentinelC");
                return true;
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

            //Queue Intimidation
            if (Aimsharp.IsCustomCodeOn("Intimidation") && Aimsharp.SpellCooldown("Intimidation") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Intimidation Queue", Color.Purple);
                }
                Aimsharp.Cast("IntimidationOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn("Intimidation") && CanCastIntimidation("target") && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Intimidation through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Intimidation");
                return true;
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

            if (Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat && !ResonatingArrow && !WildSpirits && !Aimsharp.IsCustomCodeOn("FreezingTrap") && !Aimsharp.IsCustomCodeOn("TarTrap"))
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

                bool SerpentSting = Aimsharp.IsCustomCodeOn("SerpentSting");
                if (SerpentSting && CanCastSerpentSting("mouseover") && Aimsharp.CustomFunction("TargetIsMouseover") == 0 && Aimsharp.CustomFunction("SSCheckMouseover") == 1)
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Serpent Sting - Mouseover", Color.Purple);
                    }
                    Aimsharp.Cast("SerpentStingMO");
                    return true;
                }

                if (Wait <= 200)
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
                    if (SpellID1 == 187707 && CanCastMuzzle("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Muzzle - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Muzzle", true);
                        return true;
                    }
                    //Player - No GCD
                    if (SpellID1 == 266779 && CanCastCoordinatedAssault("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Coordinated Assault - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Coordinated Assault", true);
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

                    if ((SpellID1 == 53351 || SpellID1 == 320976) && CanCastKillShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Kill Shot w/ SQW Cancel - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("KillShotSQW");
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

                    if (SpellID1 == 186289 && CanCastAspectoftheEagle("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Aspect of the Eagle - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Aspect of the Eagle");
                        return true;
                    }
                    #endregion

                    #region Survival Spells - Target GCD
                    if ((SpellID1 == 271788 || SpellID1 == 259491) && CanCastSerpentSting("target"))
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

                    if (SpellID1 == 190925 && CanCastHarpoon("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Harpoon - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Harpoon");
                        return true;
                    }

                    if (SpellID1 == 186270 && CanCastRaptorStrike("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Raptor Strike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Raptor Strike");
                        return true;
                    }

                    if (SpellID1 == 259387 && CanCastMongooseBite("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mongoose Bite - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Mongoose Bite");
                        return true;
                    }

                    if (SpellID1 == 259489 && CanCastKillCommand("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Kill Command - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Kill Command");
                        return true;
                    }

                    if (SpellID1 == 259391 && CanCastChakrams("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Chakrams - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Chakrams");
                        return true;
                    }

                    if (SpellID1 == 259491 && CanCastSerpentSting("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Serpent Sting - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Serpent Sting");
                        return true;
                    }

                    if (SpellID1 == 259495 && CanCastWildfireBomb("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wildfire Bomb - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Wildfire Bomb");
                        return true;
                    }

                    if (SpellID1 == 270335 && CanCastShrapnelBomb("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shrapnel Bomb - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Shrapnel Bomb");
                        return true;
                    }

                    if ((SpellID1 == 270323) && CanCastPheromoneBomb("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Pheromone Bomb - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Pheromone Bomb");
                        return true;
                    }

                    if (SpellID1 == 271045 && CanCastVolatileBomb("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Volatile Bomb - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Volatile Bomb");
                        return true;
                    }

                    if (SpellID1 == 269751 && CanCastFlankingStrike("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flanking Strike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Flanking Strike");
                        return true;
                    }
                    #endregion

                    #region Survival Spells - Player GCD
                    if (SpellID1 == 187708 && CanCastCarve("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Carve - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Carve");
                        return true;
                    }

                    if (SpellID1 == 212436 && CanCastButchery("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Butchery - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Butchery");
                        return true;
                    }

                    if (SpellID1 == 162488 && CanCastSteelTrap("player") && Aimsharp.CustomFunction("VolleyMouseover") == 1)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steel Trap @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("SteelTrapC");
                        return true;
                    }
                    else if (SpellID1 == 162488 && CanCastSteelTrap("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steel Trap - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Steel Trap");
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
             if (Aimsharp.IsCustomCodeOn("SteelTrap") && Aimsharp.SpellCooldown(SteelTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("HighExplosiveTrap") && Aimsharp.SpellCooldown(HighExplosiveTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("Sentinel") && Aimsharp.SpellCooldown(SentinelOwl_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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

             //Queue Sentinel
            if (Aimsharp.IsCustomCodeOn(SentinelOwl_SpellName(Language)) && Aimsharp.SpellCooldown(SentinelOwl_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sentinel Queue", Color.Purple);
                }
                Aimsharp.Cast("SentinelOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn(SentinelOwl_SpellName(Language)) && CanCastSentinel("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Sentinel through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("SentinelC");
                return true;
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
            string SteelTrapCast = GetDropDown("Steel Trap Cast:");
            bool SteelTrap = Aimsharp.IsCustomCodeOn("SteelTrap");
            //Queue Steel Trap
            if (SteelTrap && Aimsharp.SpellCooldown(SteelTrap_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Steel Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("SteelTrapOff");
                return true;
            }

            if (SteelTrap && CanCastSteelTrap("player"))
            {
                switch (SteelTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SteelTrap_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SteelTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SteelTrapC");
                        return true;
                }
            }

            string HighExplosiveTrapCast = GetDropDown("High Explosive Trap Cast:");
            bool HighExplosiveTrap = Aimsharp.IsCustomCodeOn("HighExplosiveTrap");
            //Queue High Explosive Trap
            if (HighExplosiveTrap && Aimsharp.SpellCooldown(HighExplosiveTrap_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off High Explosive Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("HighExplosiveTrapOff");
                return true;
            }

            if (HighExplosiveTrap && CanCastHighExplosiveTrap("player"))
            {
                switch (HighExplosiveTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting High Explosive Trap - " + HighExplosiveTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(HighExplosiveTrap_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting High Explosive Trap - " + HighExplosiveTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("HighExplosiveTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting High Explosive Trap - " + HighExplosiveTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("HighExplosiveTrapC");
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

            //Queue Intimidation
            if (Aimsharp.IsCustomCodeOn("Intimidation") && Aimsharp.SpellCooldown("Intimidation") - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Intimidation Queue", Color.Purple);
                }
                Aimsharp.Cast("IntimidationOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn("Intimidation") && CanCastIntimidation("target") && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Intimidation through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("Intimidation");
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