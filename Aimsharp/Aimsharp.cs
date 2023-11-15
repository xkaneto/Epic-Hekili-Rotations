using System;
using System.Collections.Generic;
using System.Drawing;

/// <summary>
///API Documentation
///Aimsharp class accessed through using AimsharpWow.API;
///AoE spells can only be casted with [@cursor] or [@player] macros. See Meteor in example rotation.
///Bot uses numpad numbers and F1-F12 and '[' and ']' keys internally so do NOT bind those to anything.
///Load and start the rotation BEFORE logging in! After logging in, type /reload in chat to automatically load the bot's macros/keybinds and you are good to go. <---- IMPORTANT
///There are a few slash commands that can be used in game manually.
///Aimsharp slash commands always start with the first 5 letters of the addon name chosen, lower case.
///For example, if your addon is named DragonHunterHelper, the commands would start with "/drago"
///Currently there is:
///    "/drago toggle" - will pause and unpause the rotation in game. Use this to quickly pause and resume the bot.
///    "/drago wait #" - will pause the rotation for # of seconds and then automatically unpause, for example /drago wait 3 would pause the bot for 3 seconds
///    "/drago CUSTOM_COMMAND - will toggle a custom command on/off. The CUSTOM_COMMAND must be added during Initialize() with CustomCommands.Add("CUSTOM_COMMAND")
///                            - The command can then trigger actions in the rotation or plugin using Aimsharp.IsCustomCommandOn("CUSTOM_COMMAND")
///    "/drago CUSTOM_COMMAND # - does the same thing as above except will automatically toggle the custom command off after # seconds.
///        Check included example rotation to see a rotation that implements custom commands.
/// </summary>
namespace AimsharpWow
{
    namespace API
    {
        public class Aimsharp
        {
            public static string HWID;
            public static string AddonName = "xxxxx";
            public static int Latency;
            public static int QuickDelay;
            public static int SlowDelay;
            public static int TargetHPMax = 80000;
            public static int TargetHP = 55000;
            public static DateTime Now = DateTime.Now;
            public static string GetHWID()
            {
                return HWID;
            }
            public static string GetDateTime()
            {
                System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-DA");
                return DateTime.Now.ToString(cultureinfo);
            }

            /// <summary>
            /// Sets Debug mode, will print all attempts to Cast an ability onto the console.
            /// </summary>
            public static void DebugMode(bool debug = true)
            {

            }

            /// <summary>
            /// finds current hp value (in thousands) for either "player", "boss1", or "focus"
            /// </summary>
            /// <param name="unit">values allowed are "player", "boss1", or "focus"</param>
            /// <returns></returns>
            public static int UnitCurrentHP(string unit = "player")
            {
                return 0;
            }

            /// <summary>
            /// Returns true if player is in a party/group
            /// </summary>
            public static bool InParty()
            {
                return false;
            }

            /// <summary>
            /// Returns true if player is in a raid.
            /// </summary>
            public static bool InRaid()
            {
                return false;
            }

            /// <summary>
            /// Returns true if player has a pet.
            /// </summary>
            public static bool PlayerHasPet()
            {
                return false;
            }

            /// <summary>
            /// Returns true if player is in Line of Sight of Target.
            /// </summary>
            public static bool LineOfSighted()
            {
                return false;
            }

            /// <summary>
            /// Print's a message to the bot's console box. Should only be used in Initialize or for debugging since printing every tick can be slow.
            /// </summary>
            public static void PrintMessage(string msg, Color? color = null)
            {
                Console.WriteLine(msg);
            }

            /// <summary>
            /// Returns true if the talent on the row and column is selected.
            /// </summary>
            public static bool Talent(int Row, int Column)
            {
                return true;
            }

            /// <summary>
            /// Returns the active covenant ID. 0 if character does not have an active covenant.
            /// For example:
            ///     kyrian = 1
            ///     venthyr = 2
            ///     night fae = 3
            ///     necrolords = 4
            /// </summary>
            /// <returns></returns>
            public static int CovenantID()
            {
                return 1;
            }

            /// <summary>
            /// returns the time since current combat first started in milliseconds.
            /// </summary>
            public static int CombatTime()
            {
                Now = DateTime.Now;
                return 1;
            }

            /// <summary>
            /// Returns the target's max HP in thousands (NOT percentage, rounds up if under 1000)
            /// </summary>
            public static int TargetMaxHP()
            {
                return TargetHPMax;
            }

            /// <summary>
            /// Returns the target's current HP in thousands (NOT percentage, rounds up if under 1000)
            /// </summary>
            /// <returns></returns>
            public static int TargetCurrentHP()
            {
                return (int)TargetHP / 1000;
            }

            /// <summary>
            /// can match for only buffs applied by the player. *note*: This IS ABLE to return the number of stacks for Buffs that stack separately, like Barbed Shot focus regen buff.
            /// </summary>
            /// <param name="BuffName">BuffName must be initialized in the rotation/plugin's Initialize() method with Buffs.Add. For Example: <c>Buffs.Add("Blessing of Protection")</c>;</param>
            /// <param name="unit">implemented for "player", "target", "focus", "pet", "arena1-3", "party1-4", "raid1-40", "boss1-4"</param>
            /// <param name="ByPlayer"></param>
            /// <returns>the number of stacks of a buff a unit has. 0 if unit does not have the buff</returns>
            public static int BuffStacks(string BuffName, string unit = "player", bool ByPlayer = true)
            {
                return 0;
            }

            /// <summary>
            /// Tries to cast the specified spell from Spellbook or macro from the Macro list. QuickDelay can be used for the bot to spam the key faster instead of waiting for the normal key delay.
            /// Spells must be initialized in the rotation/plugin's Initialize() method with Spellbook.Add. For Example: Spellbook.Add("Fists of Fury");
            /// Macros must be initialized in the rotation/plugin's Initialize() method with Macros.Add. For Example: Macros.Add("interrupt 1","/counterspell [@arena1]");
            /// </summary>
            /// <param name="SpellName"></param>
            /// <param name="unit">implemented for player, target, focus, pet, arena1-3, party1-4, raid1-40, boss1-4</param>
            /// <param name="CheckRange"></param>
            /// <param name="CheckCasting"></param>
            public static void Cast(string Name, bool QuickDelay = false)
            {
                Console.WriteLine(" --- CAST (" + DateTime.Now.ToString() + "): " + Name);
                return;
            }

            /// <summary>
            ///  returns the integer value of a defined custom WoW API lua function.  Can return up to 7 digits maximum (9999999)
            ///  Custom functions can be defined by using CustomFunction.Add("FunctionName","WoW API LUA Function defintion") in Initialize();
            ///  For example: <c>CustomFunction.Add("My Character Level", "return UnitLevel('player')");</c>
            ///  will add a custom wow lua function that can be retrieved with <c>CustomFunction("My Character Level")</c> and returns the character's in game level.
            ///  Custom functions can only return an integer up to 7 digits.
            /// </summary>
            /// <param name="CustomFunctionName"></param>
            public static int CustomFunction(string CustomFunctionName)
            {
                return 0;
            }

            /// <summary>
            /// returns the number of enemies near the target's range. (includes the target)
            /// </summary>
            public static int EnemiesNearTarget()
            {
                return 0;
            }

            /// <summary>
            /// Returns player's max power (max energy, max rage etc..)
            /// </summary>
            public static int PlayerMaxPower()
            {
                return 0;
            }

            /// <summary>
            /// returns true if the equipped trinket is ready to be used.
            /// </summary>
            /// <param name="slot">0 for top slot and 1 for bottom slot.</param>
            public static bool CanUseTrinket(int slot)
            {
                return true;
            }

            /// <summary>
            /// returns the diminishing returns level of a CC category, 0 is not DR and 3 is immuned
            /// </summary>
            /// <param name="unit">unit: arena1,arena2,arena3</param>
            /// <param name="category">category: Roots, Stuns, Silences, Knockbacks, Incapacitates, Disorients</param>
            /// <returns></returns>
            public static int EnemyDR(string unit, string category)
            {
                return 0;
            }

            /// <summary>
            /// Sends the space key to make character jump.
            /// </summary>
            public static void Jump()
            {

            }

            /// <summary>
            /// returns true if target is a boss unit (boss1, boss2, or boss3).
            /// </summary>
            public static bool TargetIsBoss()
            {
                return false;
            }


            /// <summary>
            /// returns true if target is the unit.
            /// </summary>
            /// <param name="unit">units that can be checked: focus, boss1-4, arena1-3, party1-4, player, raid1-40</param>
            /// <returns></returns>
            public static bool TargetIsUnit(string unit)
            {
                return false;
            }


            /// <summary>
            /// Returns the cooldown remaining of an ability in milliseconds, including any GCD or interrupted time.
            /// Spell must be initialized in the rotation/plugin's <c>Initialize()</c> method with <c>Spellbook.Add</c>.
            /// For Example: <example><c>Spellbook.Add("Fists of Fury")</c></example>;
            /// </summary>
            /// <param name="Spell">Spellname in current WoW-lanugage</param>
            public static int SpellCooldown(string Spell)
            {
                return 1;
            }

            /// <summary>
            /// Returns true if the spell or macro can be cast on the unit.
            /// Optional parameters to check different units, range, and if player is casting.
            /// Spell must be initialized in the rotation/plugin's Initialize() method with Spellbook.Add. For Example: Spellbook.Add("Fists of Fury").
            /// </summary>
            /// <param name="SpellName"></param>
            /// <param name="unit">implemented for player, target, focus, pet, arena1-3, party1-4, raid1-40, boss1-4, mouseover</param>
            /// <param name="CheckRange"></param>
            /// <param name="CheckCasting"></param>
            public static bool CanCast(string SpellName, string unit = "target", bool CheckRange = true, bool CheckCasting = false)
            {
                if (SpellName == "Tollkühnheit")
                {
                    return false;
                }
                return true;
            }

            /// <summary>
            /// Returns unit's health percentage, rounds up if under 1%, 0 for dead or non-existing units
            /// </summary>
            /// <param name="unit">implemented for "player", "target", "focus", "pet", "party1-4", "raid1-40", "arena1-3", "boss1-4"</param>
            /// <returns></returns>
            public static int Health(string unit = "player")
            {
                return 85;
            }

            /// <summary>
            /// Returns true if item is ready to be used.
            /// Item must be initialized in rotation/plugin's Initialize() method with Items.Add. For Example: Items.Add("Hyperthread Wristwraps");
            /// </summary>
            public static bool CanUseItem(string ItemName, bool CheckIfEquipped = true)
            {
                return true;
            }

            /// <summary>
            /// Returns the item's cooldown remaining in milliseconds.
            /// Item must be initialized in rotation/plugin's Initialize() method with Items.Add. For Example: Items.Add("Hyperthread Wristwraps");
            /// </summary>
            public static int ItemCooldown(string ItemName)
            {
                return 85;
            }

            /// <summary>
            /// Returns true if the item is equipped.
            /// Item must be initialized in rotation/plugin's Initialize() method with Items.Add. For Example: Items.Add("Hyperthread Wristwraps");
            /// </summary>
            public static bool IsEquipped(string ItemName)
            {
                return true;
            }

            /// <summary>
            /// returns true if unit has the buff. can match for only buffs applied by the player and also types "magic", "disease", "poison", "curse", "enrage", "physical"
            /// </summary>
            /// <param name="BuffName">BuffName must be initialized in the rotation/plugin's Initialize() method with Buffs.Add. For Example: Buffs.Add("Blessing of Protection");</param>
            /// <param name="unit">The target, that is being checked. Implemented for "player", "target", "focus", "pet", "arena1-3", "party1-4", "raid1-40", "boss1-4"</param>
            /// <param name="ByPlayer">Is the player the origin of the Debuf?</param>
            /// <param name="type"></param>
            /// <returns></returns>
            public static bool HasBuff(string BuffName, string unit = "player", bool ByPlayer = true, string type = "")
            {
                return false;
            }

            /// <summary>
            /// exactly same as HasBuff except for debuffs. see above
            /// </summary>
            /// <param name="BuffName">BuffName must be initialized in the rotation/plugin's Initialize() method with Buffs.Add. For Example: Buffs.Add("Blessing of Protection");</param>
            /// <param name="unit">The target, that is being checked. Implemented for "player", "target", "focus", "pet", "arena1-3", "party1-4", "raid1-40", "boss1-4"</param>
            /// <param name="ByPlayer">Is the player the origin of the Debuf?</param>
            /// <param name="type"></param>
            /// <returns></returns>
            public static bool HasDebuff(string BuffName, string unit = "player", bool ByPlayer = true, string type = "")
            {
                return false;
            }

            /// <summary>
            /// returns the WoW spellid the unit is currently casting or channeling.
            /// </summary>
            /// <param name="unit">implemented for "player","target","focus","pet","arena1-3","party1-4","boss1-4"</param>
            /// <returns></returns>
            public static int CastingID(string unit = "target")
            {
                return -1;
            }

            /// <summary>
            /// returns the remaining duration in milliseconds of a buff on a unit.
            /// </summary>
            /// <param name="BuffName">BuffName must be initialized in the rotation/plugin's Initialize() method with Buffs.Add. For Example: Buffs.Add("Blessing of Protection");</param>
            /// <param name="unit">implemented for "player", "target", "focus", "pet", "arena1-3", "party1-4", "raid1-40", "boss1-4"</param>
            /// <param name="ByPlayer"></param>
            /// <param name="type"></param>
            /// <returns></returns>
            public static int BuffRemaining(string BuffName, string unit = "player", bool ByPlayer = true, string type = "")
            {
                return 7;
            }

            /// <summary>
            /// returns the remaining duration in milliseconds of a debuff on a unit.
            /// </summary>
            /// <param name="DebuffName">DebuffName must be initialized in the rotation/plugin's Initialize() method with debuffs.Add</param>
            /// <param name="unit">implemented for "player", "target", "focus", "pet", "arena1-3", "party1-4", "raid1-40", "boss1-4"</param>
            /// <param name="ByPlayer"></param>
            /// <param name="type"></param>
            /// <returns></returns>
            public static int DebuffRemaining(string DebuffName, string unit = "player", bool ByPlayer = true, string type = "")
            {
                return 7;
            }

            /// <summary>
            /// Returns true if player is PvP enabled.
            /// </summary>
            public static bool PlayerIsPvP()
            {
                return true;
            }

            /// <summary>
            /// returns the number of stacks of a buff a unit has. 0 if unit does not have the buff. can match for only buffs applied by the player.
            /// </summary>
            /// <param name="DebuffName">DebuffName must be initialized in the rotation/plugin's Initialize() method with debuffs.Add.</param>
            /// <param name="unit">implemented for "player", "target", "focus", "pet", "arena1-3", "party1-4", "raid1-40", "boss1-4"</param>
            /// <param name="ByPlayer"></param>
            /// <returns></returns>
            public static int DebuffStacks(string DebuffName, string unit = "target", bool ByPlayer = true)
            {
                return 2;
            }

            /// <summary>
            /// stops the current cast or channel
            /// </summary>
            public static void StopCasting()
            {
                return;
            }

            /// <summary>
            /// Returns the number of current charges of an ability that has charges.  Always 0 if ability does not use charges. Spell must be initialized in the rotation/plugin's Initialize() method with Spellbook.Add. For Example: Spellbook.Add("Fists of Fury");
            /// </summary>
            /// <param name="Spell"></param>
            /// <returns></returns>
            public static int SpellCharges(string Spell)
            {
                return 0;
            }

            /// <summary>
            /// Spell must be initialized in the rotation/plugin's Initialize() method with Spellbook.Add. For Example: Spellbook.Add("Fists of Fury");
            /// </summary>
            /// <param name="Spell">Returns the maximum number of charges an ability can have.  Always 0 if ability does not use charges.</param>
            /// <returns></returns>
            public static int MaxCharges(string Spell)
            {
                return 0;
            }

            /// <summary>
            /// Spell must be initialized in the rotation/plugin's Initialize() method with Spellbook.Add. For Example: Spellbook.Add("Fists of Fury");
            /// </summary>
            /// <param name="Spell">Returns the time remaining for an ability to gain another charge.  Always 0 if ability does not use charges.</param>
            /// <returns></returns>
            public static int RechargeTime(string Spell)
            {
                return 0;
            }

            /// <summary>
            /// Spell must be initialized in the rotation/plugin's Initialize() method with Spellbook.Add. For Example: Spellbook.Add("Fists of Fury");
            /// </summary>
            /// <param name="Spell"></param>
            /// <returns>Returns false if the spell is active (Stealth, Shadowmeld, Presence of Mind, etc) and the cooldown will begin as soon as the spell is used/cancelled; otherwise true.</returns>
            public static bool SpellEnabled(string Spell)
            {
                return true;
            }

            /// <summary>
            /// Returns true if Unit is in range of ability; otherwise false.
            /// Spell must be initialized in the rotation/plugin's Initialize() method with Spellbook.Add. For Example: Spellbook.Add("Fists of Fury");
            /// <param name="Spell"> implemented for target, focus, pet, arena1-3, party1-4, raid1-40, boss1-4 </param>
            /// </summary>
            public static bool SpellInRange(string Spell, string Unit)
            {
                return true;
            }

            /// <summary>
            /// Returns the range to the unit.
            /// </summary>
            /// <param name="unit">implemented for "target", "focus", "pet", "party1-4", "raid1-40", "arena1-3", "boss1-4"</param>
            /// <returns></returns>
            public static int Range(string unit = "target")
            {
                return 6;
            }

            /// <summary>
            /// Returns the current uiMapID for the player. See: https://wow.gamepedia.com/UiMapID
            /// </summary>
            public static int GetMapID()
            {
                return 1;
            }

            /// <summary>
            /// Returns true if target is hostile to player.
            /// </summary>
            public static bool TargetIsEnemy()
            {
                return true;
            }

            /// <summary>
            /// returns the remaining time in milliseconds of the player's current active global cooldown
            /// </summary>
            public static int GCD()
            {
                return 1;
            }

            /// <summary>
            /// Returns true if player is moving.
            /// </summary>
            public static bool PlayerIsMoving()
            {
                return false;
            }

            /// <summary>
            /// returns the player's haste percentage
            /// </summary>
            public static float Haste()
            {
                return 39.23652F;
            }

            /// <summary>
            /// Returns unit's power (rage, energy etc.)
            /// </summary>
            /// <param name="unit">implemented for "player", "target", "focus", "pet", "party1-4", "raid1-40", "arena1-3"</param>
            public static int Power(string unit = "player")
            {
                return 76;
            }

            /// <summary>
            /// Returns the name of the last successfully casted ability by "player" if it is in the bot's Spellbook.
            /// Spell must be initialized in the rotation/plugin's Initialize() method with Spellbook.Add. For Example: Spellbook.Add("Fists of Fury");
            /// </summary>
            public static string LastCast()
            {
                return "";
            }
            /// <summary>
            /// Returns the name of the spec of the unit: "TANK", "DAMAGE", "HEALER".
            /// <param name="unit">implemented for "player","target","focus","pet","arena1-3","party1-4","boss1-4"</param>
            /// </summary>
            public static string GetSpec(string unit = "player")
            {
                return "";
            }

            /// <summary>
            /// returns true if unit is currently channeling
            /// </summary>
            /// <param name="unit">implemented for "player","target","focus","pet","arena1-3","party1-4","boss1-4"</param>
            /// <returns></returns>
            public static bool IsChanneling(string unit = "target")
            {
                return false;
            }

            /// <summary></summary>
            /// <param name="unit">implemented for "player", "target", "focus", "pet", "party1-4", "raid1-40", "arena1-3"</param>
            /// <returns>Returns <c>true</c> if unit is in combat.</returns>
            public static bool InCombat(string unit = "player")
            {
                return true;
            }

            /// <summary>
            /// Returns true if player is mounted.
            /// </summary>
            public static bool PlayerIsMounted()
            {
                return false;
            }

            /// <summary>
            /// Returns player's level.
            /// </summary>
            public static int GetPlayerLevel()
            {
                return 70;
            }
            /// <summary>
            /// Returns the number of players including the player in the current group or raid. Returns 0 if not in a group or raid
            /// </summary>
            /// <returns></returns>
            public static int GroupSize()
            {
                return 0;
            }

            /// <summary>
            /// Returns the number of hostile enemies in melee range
            /// </summary>
            public static int EnemiesInMelee()
            {
                return 1;
            }


            public static bool IsCustomCodeOn(string Name)
            {
                return false;
            }

            /// <summary>
            /// returns the unit ID from UnitGUID()
            /// </summary>
            /// <param name="unit">works for target, focus, boss1-4</param>
            /// <returns></returns>
            public static int UnitID(string unit = "target")
            {
                return 1;
            }

            /// <summary>
            /// returns an estimate of the number of group or raid members near the target
            /// </summary>
            public static int AlliesNearTarget()
            {
                return 0;
            }

            /// <summary>
            /// returns a string with the current loaded addon's name
            /// </summary>
            public static string GetAddonName()
            {
                return "";
            }


            /// <summary>
            /// returns player's X coordinate map position as a 6 digit integer (.002300 = 2300)
            /// </summary>
            public static int GetPlayerPositionX()
            {
                return 0;
            }

            /// <summary>
            /// returns player's Y coordinate map position as a 6 digit integer (.002300 = 2300)
            /// </summary>
            public static int GetPlayerPositionY()
            {
                return 0;
            }

            /// <summary>
            /// returns player's facing direction in radians (1.43492 = 143492)
            /// </summary>
            public static int GetPlayerFacing()
            {
                return 0;
            }


            /// <summary>
            /// returns true if unit is currently interruptable
            /// </summary>
            /// <param name="unit">implemented for "player","target","focus","pet","arena1-3","party1-4","boss1-4"</param>
            /// <returns></returns>
            public static bool IsInterruptable(string unit = "target")
            {
                return false;
            }

            /// <summary>
            /// returns the remaining time in milliseconds of the unit's current spell cast or channel.
            /// </summary>
            /// <param name="unit">implemented for "player","target","focus","pet","arena1-3","party1-4","boss1-4"</param>
            /// <returns></returns>
            public static int CastingRemaining(string unit = "target")
            {
                return 15;
            }

            /// <summary>
            /// Returns the remaining time in milliseconds of the unit's current spell cast or channel.
            /// </summary>
            /// <param name="unit">implemented for "player","target","focus","pet","arena1-3","party1-4","boss1-4"</param>
            /// <returns></returns>
            public static int TotemRemaining(string unit = "totem")
            {
                return 15;
            }

            /// <summary>
            /// returns the elapsed time in milliseconds of the unit's current spell cast or channel.
            /// </summary>
            /// <param name="unit">implemented for "player","target","focus","pet","arena1-3","party1-4","boss1-4"</param>
            public static int CastingElapsed(string unit = "target")
            {
                return 2;
            }

            /// <summary>
            /// Returns player's current secondary power (how many combo points, chi, etc..)
            /// For Warlocks, will return a two digit integer, for example 43 = 4.3 soul shards.
            /// </summary>
            public static int PlayerSecondaryPower()
            {
                return 43;
            }
            /// <summary>
            /// Returns player's current empower stage.
            /// </summary>
            public static int GetEmpowerStage()
            {
                return 1;
            }
        }
    }

    public class Rotation
    {
        public struct Setting
        {
            public Setting(string Name, List<string> List, string Default)
            {

            }
            public Setting(string Name)
            {

            }
            public Setting(string Name, string Value)
            {

            }
            public Setting(string Name, bool Value)
            {

            }
            public Setting(string Name, int min, int max, int Default)
            {

            }
        }
        public static class Macros
        {
            public static void Add(string Name, string Default)
            {
                return;
            }
        }
        public static class Spellbook
        {
            public static void Add(string Name)
            {
                return;
            }
        }

        public static class Totems
        {
            public static void Add(string Name)
            {
                return;
            }
        }
        public static class Buffs
        {
            public static void Add(string Name)
            {
                return;
            }
        }
        public static class Debuffs
        {
            public static void Add(string Name)
            {
                return;
            }
        }
        public static class CustomCommands
        {
            public static void Add(string Name)
            {
                return;
            }
        }
        public static class CustomFunctions
        {
            /// <summary>
            /// Defines custom WoW API lua function. Must be called in Initialize().
            /// </summary>
            /// <param name="FunctionName">FunctionName</param>
            /// <param name="Function">WoW API lua function</param>
            public static void Add(string FunctionName, string Function)
            {
                return;
            }
        }
        public static List<Setting> Settings = new List<Setting>();

        /// <summary>
        /// Use to retrieve the string value of a DropDown setting. See example rotation in Rotations folder.
        /// </summary>
        /// <param name="SettingName"></param>
        public string GetDropDown(string SettingName)
        {
            if (SettingName == "Game Client Language")
            {
                return "Deutsch";
            }
            return "";
        }

        /// <summary>
        /// Use to retrieve the string value of a String setting.  See example in Rotations folder.
        /// </summary>
        /// <param name="SettingName"></param>
        public string GetString(string SettingName)
        {
            return "";
        }

        /// <summary>
        /// Use to retrieve the bool value of a checkbox setting. See example rotation in Rotations folder.
        /// </summary>
        /// <param name="SettingName"></param>
        public bool GetCheckBox(string SettingName)
        {
            return true;
        }

        /// <summary>
        /// Use to retrieve the int value of a slider setting. See example rotation in Rotations folder.
        /// </summary>
        /// <param name="SettingName"></param>
        virtual public int GetSlider(string SettingName)
        {
            return 2;
        }

        /// <summary>
        /// Override this to use user adjustable settings for your rotation. See example rotation in Rotations folder
        /// * Settings.Add(new Setting("Is a mage",true)); //adds a checkbox setting named "Is a mage" that returns a bool initialized to true (checked)
        /// * Settings.Add(new Setting("Mana %", 1, 100, 75)); //adds a integer slider setting named "Mana %" that returns an int. Minimum slider value 1, maximum value 100, initialized to 75.
        /// * Settings.Add(new Setting("Race", new List<string>(new string[] { "human", "orc", "nightelf" }), "orc")); //adds a dropdown menu setting named "Race" with 3 options: human, orc, nightelf initialized to orc.
        /// * Settings.Add(new Setting("Custom Potion", "potion name")); //adds a custom text box setting where the user can input a string
        /// * Settings.Add(new Setting("Label Name")); //adds a Label to your settings page (only visual, doesn't do anything)
        /// </summary>
        virtual public void LoadSettings()
        {

        }
        public static List<string> Items = new List<string>();

        /// <summary>
        /// All rotations and plugins MUST override Initialize().
        /// Initialize() is used to add spells/auras to the rotation.
        /// Can be used to print welcome messages, initialize variables depending on settings, etc.. See example rotation in Rotations folder.
        /// </summary>
        virtual public void Initialize()
        {

        }

        /// <summary>
        /// Override this to perform actions in combat.  Each tick uses the same scan of the game state.
        /// If an action is performed that changes the game state, it is recommended to return true to immediately go to the next tick, updating the game state scan.
        /// See example rotation in Rotations folder.
        /// </summary>
        virtual public bool CombatTick()
        {
            return true;
        }

        /// <summary>
        /// Same as CombatTick() but executes only when out of combat
        /// </summary>
        virtual public bool OutOfCombatTick()
        {
            return true;
        }

        /// <summary>
        /// Same as CombatTick() but executes only when mounted
        /// </summary>
        virtual public bool MountedTick()
        {
            return true;
        }

        /// <summary>
        /// Unkown function
        /// </summary>
        virtual public void CleanUp()
        {

        }
    }

}

