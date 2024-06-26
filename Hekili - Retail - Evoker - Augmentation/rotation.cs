﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicEvokerAugmentationHekili : Rotation
    {
        //Random Number
        private static readonly Random getrandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
        private static string Language = "English";

        private static int EmpowerStateNow = new int();

        #region SpellFunctions
        ///<summary>npc=204773</summary>
        private static string AfflictedSoul_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Afflicted Soul";
                case "Deutsch": return "Befallene Seele";
                case "Español": return "Alma afligida";
                case "Français": return "Âme affligée";
                case "Italiano": return "Anima Afflitta";
                case "Português Brasileiro": return "Alma Aflita";
                case "Русский": return "Изнемогающая душа";
                case "한국어": return "괴로워하는 영혼";
                case "简体中文": return "Afflicted Soul";
                default: return "Afflicted Soul";
            }
        }

        ///<summary>spell=362969</summary>
        private static string AzureStrike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Azure Strike";
                case "Deutsch": return "Azurstoß";
                case "Español": return "Ataque azur";
                case "Français": return "Frappe d’azur";
                case "Italiano": return "Assalto Azzurro";
                case "Português Brasileiro": return "Ataque Lazúli";
                case "Русский": return "Лазурный удар";
                case "한국어": return "하늘빛 일격";
                case "简体中文": return "碧蓝打击";
                default: return "Azure Strike";
            }
        }

        ///<summary>spell=364342</summary>
        private static string BlessingOfTheBronze_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blessing of the Bronze";
                case "Deutsch": return "Segen der Bronzenen";
                case "Español": return "Bendición de bronce";
                case "Français": return "Bénédiction du bronze";
                case "Italiano": return "Benedizione del Bronzo";
                case "Português Brasileiro": return "Bênção do Bronze";
                case "Русский": return "Дар бронзовых драконов";
                case "한국어": return "청동용군단의 축복";
                case "简体中文": return "青铜龙的祝福";
                default: return "Blessing of the Bronze";
            }
        }

        ///<summary>spell=360827</summary>
        private static string BlisteringScales_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blistering Scales";
                case "Deutsch": return "Sengende Schuppen";
                case "Español": return "Escamas virulentas";
                case "Français": return "Écailles torrides";
                case "Italiano": return "Scaglie Roventi";
                case "Português Brasileiro": return "Escamas Virulentas";
                case "Русский": return "Вздувшаяся чешуя";
                case "한국어": return "끓어오르는 비늘";
                case "简体中文": return "炽火龙鳞";
                default: return "Blistering Scales";
            }
        }

        ///<summary>spell=387168</summary>
        private static string BoonOfTheCovenants_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Boon of the Covenants";
                case "Deutsch": return "Segen der Pakte";
                case "Español": return "Favor de las curias";
                case "Français": return "Faveur des congrégations";
                case "Italiano": return "Dono delle Congreghe";
                case "Português Brasileiro": return "Dádiva dos Pactos";
                case "Русский": return "Дар ковенантов";
                case "한국어": return "성약의 단의 은혜";
                case "简体中文": return "盟约恩泽";
                default: return "Boon of the Covenants";
            }
        }

        ///<summary>spell=403631</summary>
        private static string BreathOfEons_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Breath of Eons";
                case "Deutsch": return "Atem der Äonen";
                case "Español": return "Aliento de los eones";
                case "Français": return "Souffle des présages";
                case "Italiano": return "Soffio degli Eoni";
                case "Português Brasileiro": return "Sopro Eônico";
                case "Русский": return "Дыхание эпох";
                case "한국어": return "영겁의 숨결";
                case "简体中文": return "亘古吐息";
                default: return "Breath of Eons";
            }
        }

        ///<summary>spell=374251</summary>
        private static string CauterizingFlame_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Cauterizing Flame";
                case "Deutsch": return "Kauterisierende Flamme";
                case "Español": return "Llama cauterizante";
                case "Français": return "Flamme de cautérisation";
                case "Italiano": return "Fiamma Cauterizzante";
                case "Português Brasileiro": return "Chama Cauterizante";
                case "Русский": return "Прижигающее пламя";
                case "한국어": return "소작의 불길";
                case "简体中文": return "灼烧之焰";
                default: return "Cauterizing Flame";
            }
        }

        ///<summary>spell=356995</summary>
        private static string Disintegrate_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Disintegrate";
                case "Deutsch": return "Desintegration";
                case "Español": return "Desintegrar";
                case "Français": return "Désintégration";
                case "Italiano": return "Disintegrazione";
                case "Português Brasileiro": return "Desintegrar";
                case "Русский": return "Дезинтеграция";
                case "한국어": return "파열";
                case "简体中文": return "裂解";
                default: return "Disintegrate";
            }
        }

        ///<summary>spell=395152</summary>
        private static string EbonMight_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ebon Might";
                case "Deutsch": return "Schwarzmacht";
                case "Español": return "Poderío de ébano";
                case "Français": return "Puissance d’ébène";
                case "Italiano": return "Vigore d'Ebano";
                case "Português Brasileiro": return "Poder de Ébano";
                case "Русский": return "Черная мощь";
                case "한국어": return "칠흑의 힘";
                case "简体中文": return "黑檀之力";
                default: return "Ebon Might";
            }
        }

        ///<summary>spell=355913</summary>
        private static string EmeraldBlossom_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Emerald Blossom";
                case "Deutsch": return "Smaragdblüte";
                case "Español": return "Flor esmeralda";
                case "Français": return "Arbre d’émeraude";
                case "Italiano": return "Bocciolo di Smeraldo";
                case "Português Brasileiro": return "Flor de Esmeralda";
                case "Русский": return "Изумрудный цветок";
                case "한국어": return "에메랄드 꽃";
                case "简体中文": return "翡翠之花";
                default: return "Emerald Blossom";
            }
        }

        ///<summary>spell=395160</summary>
        private static string Eruption_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Eruption";
                case "Deutsch": return "Eruption";
                case "Español": return "Erupción";
                case "Français": return "Eruption";
                case "Italiano": return "Eruzione";
                case "Português Brasileiro": return "Erupção";
                case "Русский": return "Извержение";
                case "한국어": return "분출";
                case "简体中文": return "喷发";
                default: return "Eruption";
            }
        }

        ///<summary>spell=365585</summary>
        private static string Expunge_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Expunge";
                case "Deutsch": return "Entgiften";
                case "Español": return "Expurgar";
                case "Français": return "Éliminer";
                case "Italiano": return "Espulsione";
                case "Português Brasileiro": return "Expungir";
                case "Русский": return "Нейтрализация";
                case "한국어": return "말소";
                case "简体中文": return "净除";
                default: return "Expunge";
            }
        }

        ///<summary>spell=382266</summary>
        private static string FireBreath_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fire Breath";
                case "Deutsch": return "Feueratem";
                case "Español": return "Aliento de Fuego";
                case "Français": return "Souffle de feu";
                case "Italiano": return "Soffio di Fuoco";
                case "Português Brasileiro": return "Sopro de Fogo";
                case "Русский": return "Огненное дыхание";
                case "한국어": return "불의 숨결";
                case "简体中文": return "火焰吐息";
                default: return "Fire Breath";
            }
        }

        ///<summary>item=5512</summary>
        private static string Healthstone_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Healthstone";
                case "Deutsch": return "Gesundheitsstein";
                case "Español": return "Piedra de salud";
                case "Français": return "Pierre de soins";
                case "Italiano": return "Pietra della Salute";
                case "Português Brasileiro": return "Pedra de Vida";
                case "Русский": return "Камень здоровья";
                case "한국어": return "생명석";
                case "简体中文": return "治疗石";
                default: return "Healthstone";
            }
        }

        ///<summary>spell=358267</summary>
        private static string Hover_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Hover";
                case "Deutsch": return "Schweben";
                case "Español": return "Flotar";
                case "Français": return "Survoler";
                case "Italiano": return "Volo Sospeso";
                case "Português Brasileiro": return "Pairar";
                case "Русский": return "Бреющий полет";
                case "한국어": return "부양";
                case "简体中文": return "悬空";
                default: return "Hover";
            }
        }

        ///<summary>npc=204560</summary>
        private static string IncorporealBeing_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Incorporeal Being";
                case "Deutsch": return "Körperloses Wesen";
                case "Español": return "Ser incorpóreo";
                case "Français": return "Être immatériel";
                case "Italiano": return "Essere Incorporeo";
                case "Português Brasileiro": return "Ser Incorpóreo";
                case "Русский": return "Бестелесный дух";
                case "한국어": return "무형의 존재";
                case "简体中文": return "Incorporeal Being";
                default: return "Incorporeal Being";
            }
        }

        ///<summary>spell=358385</summary>
        private static string Landslide_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Landslide";
                case "Deutsch": return "Erdrutsch";
                case "Español": return "Derrumbamiento";
                case "Français": return "Glissement de terrain";
                case "Italiano": return "Smottamento";
                case "Português Brasileiro": return "Soterramento";
                case "Русский": return "Сель";
                case "한국어": return "산사태";
                case "简体中文": return "山崩";
                default: return "Landslide";
            }
        }

        ///<summary>spell=361469</summary>
        private static string LivingFlame_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Living Flame";
                case "Deutsch": return "Lebende Flamme";
                case "Español": return "Llama viva";
                case "Français": return "Flamme vivante";
                case "Italiano": return "Fiamma Vivente";
                case "Português Brasileiro": return "Chama Viva";
                case "Русский": return "Живой жар";
                case "한국어": return "살아있는 불꽃";
                case "简体中文": return "活化烈焰";
                default: return "Living Flame";
            }
        }

        ///<summary>spell=363916</summary>
        private static string ObsidianScales_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Obsidian Scales";
                case "Deutsch": return "Obsidianschuppen";
                case "Español": return "Escamas obsidiana";
                case "Français": return "Écailles d’obsidienne";
                case "Italiano": return "Scaglie d'Ossidiana";
                case "Português Brasileiro": return "Escamas de Obsidiana";
                case "Русский": return "Обсидиановая чешуя";
                case "한국어": return "흑요석 비늘";
                case "简体中文": return "黑曜鳞片";
                default: return "Obsidian Scales";
            }
        }

        ///<summary>spell=372048</summary>
        private static string OppressingRoar_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Oppressing Roar";
                case "Deutsch": return "Tyrannisierendes Brüllen";
                case "Español": return "Rugido opresor";
                case "Français": return "Rugissement oppressant";
                case "Italiano": return "Ruggito Opprimente";
                case "Português Brasileiro": return "Rugido Opressivo";
                case "Русский": return "Угнетающий рык";
                case "한국어": return "탄압의 포효";
                case "简体中文": return "压迫怒吼";
                default: return "Oppressing Roar";
            }
        }

        ///<summary>spell=409311</summary>
        private static string Prescience_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Prescience";
                case "Deutsch": return "Voraussicht";
                case "Español": return "Presciencia";
                case "Français": return "Prescience";
                case "Italiano": return "Prescienza";
                case "Português Brasileiro": return "Presciência";
                case "Русский": return "Предвидение";
                case "한국어": return "예지";
                case "简体中文": return "先知先觉";
                default: return "Prescience";
            }
        }

        ///<summary>spell=357211</summary>
        private static string Pyre_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Pyre";
                case "Deutsch": return "Scheiterhaufen";
                case "Español": return "Pira";
                case "Français": return "Bûcher";
                case "Italiano": return "Pira";
                case "Português Brasileiro": return "Pira";
                case "Русский": return "Погребальный костер";
                case "한국어": return "기염";
                case "简体中文": return "葬火";
                default: return "Pyre";
            }
        }

        ///<summary>spell=351338</summary>
        private static string Quell_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Quell";
                case "Deutsch": return "Unterdrücken";
                case "Español": return "Sofocar";
                case "Français": return "Apaisement";
                case "Italiano": return "Sedazione";
                case "Português Brasileiro": return "Supressão";
                case "Русский": return "Подавление";
                case "한국어": return "진압";
                case "简体中文": return "镇压";
                default: return "Quell";
            }
        }

        ///<summary>spell=374348</summary>
        private static string RenewingBlaze_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Renewing Blaze";
                case "Deutsch": return "Erneuernde Flammen";
                case "Español": return "Llamarada de renovación";
                case "Français": return "Brasier de rénovation";
                case "Italiano": return "Fiammata Curativa";
                case "Português Brasileiro": return "Labareda Renovadora";
                case "Русский": return "Обновляющее пламя";
                case "한국어": return "소생의 불길";
                case "简体中文": return "新生光焰";
                default: return "Renewing Blaze";
            }
        }

        ///<summary>spell=360806</summary>
        private static string SleepWalk_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sleep Walk";
                case "Deutsch": return "Schlafwandeln";
                case "Español": return "Sonambulismo";
                case "Français": return "Somnambulisme";
                case "Italiano": return "Sonnambulismo";
                case "Português Brasileiro": return "Sonambulismo";
                case "Русский": return "Лунатизм";
                case "한국어": return "몽유병";
                case "简体中文": return "梦游";
                default: return "Sleep Walk";
            }
        }

        ///<summary>spell=213771</summary>
        private static string Swipe_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Swipe";
                case "Deutsch": return "Prankenhieb";
                case "Español": return "Flagelo";
                case "Français": return "Balayage";
                case "Italiano": return "Spazzata";
                case "Português Brasileiro": return "Patada";
                case "Русский": return "Размах";
                case "한국어": return "휘둘러치기";
                case "简体中文": return "横扫";
                default: return "Swipe";
            }
        }

        ///<summary>spell=368970</summary>
        private static string TailSwipe_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Tail Swipe";
                case "Deutsch": return "Schwanzfeger";
                case "Español": return "Flagelo de cola";
                case "Français": return "Claque caudale";
                case "Italiano": return "Spazzata di Coda";
                case "Português Brasileiro": return "Revés com a Cauda";
                case "Русский": return "Удар хвостом";
                case "한국어": return "꼬리 휘둘러치기";
                case "简体中文": return "扫尾";
                default: return "Tail Swipe";
            }
        }

        ///<summary>spell=404977</summary>
        private static string TimeSkip_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Time Skip";
                case "Deutsch": return "Zeitsprung";
                case "Español": return "Salto temporal";
                case "Français": return "Bond temporel";
                case "Italiano": return "Salto Temporale";
                case "Português Brasileiro": return "Salto temporal";
                case "Русский": return "Пропустить время";
                case "한국어": return "시간 건너뛰기";
                case "简体中文": return "时间跳跃";
                default: return "Time Skip";
            }
        }

        ///<summary>spell=374968</summary>
        private static string TimeSpiral_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Time Spiral";
                case "Deutsch": return "Zeitspirale";
                case "Español": return "Espiral temporal";
                case "Français": return "Spirale temporelle";
                case "Italiano": return "Spirale Temporale";
                case "Português Brasileiro": return "Espiral do Tempo";
                case "Русский": return "Спираль времени";
                case "한국어": return "시간의 와류";
                case "简体中文": return "时间螺旋";
                default: return "Time Spiral";
            }
        }

        ///<summary>spell=370553</summary>
        private static string TipTheScales_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Tip the Scales";
                case "Deutsch": return "Zeitdruck";
                case "Español": return "Inclinar la balanza";
                case "Français": return "Retour de bâton";
                case "Italiano": return "Ago della Bilancia";
                case "Português Brasileiro": return "Jogo Virado";
                case "Русский": return "Смещение равновесия";
                case "한국어": return "전세역전";
                case "简体中文": return "扭转天平";
                default: return "Tip the Scales";
            }
        }

        ///<summary>spell=368432</summary>
        private static string Unravel_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Unravel";
                case "Deutsch": return "Zunichte machen";
                case "Español": return "Deshacer";
                case "Français": return "Fragilisation magique";
                case "Italiano": return "Disvelamento";
                case "Português Brasileiro": return "Desvelar";
                case "Русский": return "Разрушение магии";
                case "한국어": return "해체";
                case "简体中文": return "拆解";
                default: return "Unravel";
            }
        }

        ///<summary>spell=408092</summary>
        private static string Upheaval_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Upheaval";
                case "Deutsch": return "Emporstoßen";
                case "Español": return "Agitación";
                case "Français": return "Soulèvement";
                case "Italiano": return "Sollevazione Terrestre";
                case "Português Brasileiro": return "Revolta";
                case "Русский": return "Дрожь земли";
                case "한국어": return "지각 변동";
                case "简体中文": return "地壳激变";
                default: return "Upheaval";
            }
        }

        ///<summary>spell=360995</summary>
        private static string VerdantEmbrace_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Verdant Embrace";
                case "Deutsch": return "Tiefgrüne Umarmung";
                case "Español": return "Abrazo verde";
                case "Français": return "Étreinte verdoyante";
                case "Italiano": return "Abbraccio Lussureggiante";
                case "Português Brasileiro": return "Abraço Verdejante";
                case "Русский": return "Живительные объятия";
                case "한국어": return "신록의 품";
                case "简体中文": return "青翠之拥";
                default: return "Verdant Embrace";
            }
        }

        ///<summary>spell=357214</summary>
        private static string WingBuffet_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Wing Buffet";
                case "Deutsch": return "Flügelstoß";
                case "Español": return "Sacudida de alas";
                case "Français": return "Frappe des ailes";
                case "Italiano": return "Battito d'Ali";
                case "Português Brasileiro": return "Bofetada de Asa";
                case "Русский": return "Взмах крыльями";
                case "한국어": return "폭풍 날개";
                case "简体中文": return "飞翼打击";
                default: return "Wing Buffet";
            }
        }

        ///<summary>spell=374227</summary>
        private static string Zephyr_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Zephyr";
                case "Deutsch": return "Zephyr";
                case "Español": return "Céfiro";
                case "Français": return "Zéphyr";
                case "Italiano": return "Zefiro";
                case "Português Brasileiro": return "Zéfiro";
                case "Русский": return "Южный ветер";
                case "한국어": return "미풍";
                case "简体中文": return "微风";
                default: return "Zephyr";
            }
        }
        #endregion

        #region Variables
        string FiveLetters;
        string UsableItem;
        Stopwatch HSTimer = new Stopwatch();
        Stopwatch ItemTimer = new Stopwatch();
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle", "NoExpunge", "NoCauterizingFlame", "QueueLandslide", "SleepWalk", "BreathOfEons", "BreathofEonsCursor" };
        private List<string> m_DebuffsList;
        private List<string> m_BuffsList;
        private List<string> m_ItemsList;
        private List<string> m_SpellBook;

        private List<string> m_RaceList = new List<string> { "Dracthyr" };

        private List<string> m_CastingList = new List<string> { "Manual", "Cursor" };

        private List<int> Torghast_InnerFlame = new List<int> { 258935, 258938, 329422, 329423, };

        List<double> Stages = new List<double>
        {
            0,
            1000,
            1750,
            2500,
            3250,
        };

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

        public string AllyName1;
        public string AllyName2;
        public string AllyName3;
        public string AllyName4;

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
        private bool CanCastCheck(string SpellName, string target, bool RangeCheck = true, bool CastCheck = true)
        {
            if (Aimsharp.CanCast(SpellName, target, RangeCheck, CastCheck) || Aimsharp.SpellCooldown(SpellName) - Aimsharp.GCD() <= 0 || (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") + 100) || Aimsharp.GCD() == 0)
            {
                return true;
            }
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
            Macros.Add("UseWeapon", "/use 16");

            //Healthstone
            Macros.Add("UseHealthstone", "/use " + Healthstone_SpellName(Language));
            Macros.Add("UseItem", "/use " + UsableItem);


            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + (Aimsharp.Latency + 100));

            //Queues
            Macros.Add("LandslideOff", "/" + FiveLetters + " QueueLandslide");
            Macros.Add("SleepWalkOff", "/" + FiveLetters + " SleepWalk");
            Macros.Add("BreathofEonsOff", "/" + FiveLetters + " BreathOfEons");

            Macros.Add("FOC_player", "/focus player");
            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");

            for (int i = 1; i <= 40; i++)
            {
                Macros.Add("FOC_raid" + i, "/focus raid" + i);
            }

            Macros.Add("Expunge_FOC", "/cast [@focus] " + Expunge_SpellName(Language));
            Macros.Add("CF_FOC", "/cast [@focus] " + CauterizingFlame_SpellName(Language));
            Macros.Add("EB_FOC", "/cast [@focus] " + EmeraldBlossom_SpellName(Language));

            Macros.Add("SleepWalkMO", "/cast [@mouseover,exists] " + SleepWalk_SpellName(Language));
            Macros.Add("ExpungeMO", "/cast [@mouseover,exists] " + Expunge_SpellName(Language));
            Macros.Add("CauterizingFlameMO", "/cast [@mouseover,exists] " + CauterizingFlame_SpellName(Language));
            Macros.Add("BlisteringScalesFocus", "/cast [@focus] " + BlisteringScales_SpellName(Language));
            Macros.Add("BreathofEonsC", "/cast [@cursor] " + "" + BreathOfEons_SpellName(Language));
            Macros.Add("LandslideC", "/cast [@cursor] " + Landslide_SpellName(Language));

            Macros.Add("PrescienceFocus", "/cast [@focus] " + Prescience_SpellName(Language));

        }

        private void InitializeSpells()
        {
            foreach (string Spell in m_SpellBook)
                Spellbook.Add(Spell);

            foreach (string Buff in m_BuffsList)
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
            CustomFunctions.Add("HekiliID1", "local loading, finished = IsAddOnLoaded(\"Hekili\")\nif loading == true and finished == true then\n\tlocal id=Hekili.DisplayPool.Primary.Recommendations[1].actionID\n\tif id ~= nil then\n\t\tif id<0 then\n\t\t\tlocal spell = Hekili.Class.abilities[id]\n\t\t\tif spell ~= nil and spell.item ~= nil then\n\t\t\t\tid=spell.item\n\t\t\t\tlocal topTrinketLink = GetInventoryItemLink(\"player\",13)\n\t\t\t\tlocal bottomTrinketLink = GetInventoryItemLink(\"player\",14)\n\t\t\t\tlocal weaponLink = GetInventoryItemLink(\"player\",16)\n\t\t\t\tif topTrinketLink  ~= nil then\n\t\t\t\t\tlocal trinketid = GetItemInfoInstant(topTrinketLink)\n\t\t\t\t\tif trinketid ~= nil then\n\t\t\t\t\t\tif trinketid == id then\n\t\t\t\t\t\t\treturn 1\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif bottomTrinketLink ~= nil then\n\t\t\t\t\tlocal trinketid = GetItemInfoInstant(bottomTrinketLink)\n\t\t\t\t\tif trinketid ~= nil then\n\t\t\t\t\t\tif trinketid == id then\n\t\t\t\t\t\t\treturn 2\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif weaponLink ~= nil then\n\t\t\t\t\tlocal weaponid = GetItemInfoInstant(weaponLink)\n\t\t\t\t\tif weaponid ~= nil then\n\t\t\t\t\t\tif weaponid == id then\n\t\t\t\t\t\t\treturn 3\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\tend\n\t\tend\n\t\treturn id\n\tend\nend\nreturn 0");

            CustomFunctions.Add("GetSpellQueueWindow", "local sqw = GetCVar(\"SpellQueueWindow\"); if sqw ~= nil then return tonumber(sqw); end return 0");

            CustomFunctions.Add("CooldownsToggleCheck", "local loading, finished = IsAddOnLoaded(\"Hekili\") if loading == true and finished == true then local cooldowns = Hekili:GetToggleState(\"cooldowns\") if cooldowns == true then return 1 else if cooldowns == false then return 2 end end end return 0");

            CustomFunctions.Add("UnitIsDead", "if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == true then return 1 end; if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == false then return 2 end; return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");

            CustomFunctions.Add("HekiliWait", "if HekiliDisplayPrimary.Recommendations[1].wait ~= nil and HekiliDisplayPrimary.Recommendations[1].wait * 1000 > 0 then return math.floor(HekiliDisplayPrimary.Recommendations[1].wait * 1000) end return 0");

            CustomFunctions.Add("HekiliDelay", "if Hekili.DisplayPool.Primary.Buttons[ 1 ].ExactTime ~= nil and (Hekili.DisplayPool.Primary.Buttons[ 1 ].ExactTime - GetTime())* 1000 > 0 then return math.floor((Hekili.DisplayPool.Primary.Buttons[ 1 ].ExactTime - GetTime())*1000) end return 0");

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("HekiliEnemies", "if Hekili.State.active_enemies ~= nil and Hekili.State.active_enemies > 0 then return Hekili.State.active_enemies end return 0");

            CustomFunctions.Add("EmpowermentCheck", "local loading, finished = IsAddOnLoaded(\"Hekili\")\nif loading == true and finished == true then\n    local id,empowermentStage,_=Hekili_GetRecommendedAbility(\"Primary\",1)\n    if id ~= nil and empowermentStage ~= nil and empowermentStage > 0 then\n        return empowermentStage\n    end\nend\nreturn 0");

            CustomFunctions.Add("BoEMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Breath of Eons','mouseover') == 1 then return 1 end; return 0");

            CustomFunctions.Add("MouseoverCheck", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') then return 1 end; return 0");

            CustomFunctions.Add("AllyPrescienceBuffWithName", "\nlocal out = 0;\nlocal numGroupMembers = GetNumGroupMembers();\nlocal Ally1 = \"" + AllyName1 + "\";\nlocal Ally2 = \"" + AllyName2 + "\";\nlocal Ally3 = \"" + AllyName3 + "\";\nlocal Ally4 = \"" + AllyName4 + "\";\n\nif numGroupMembers > 0 and numGroupMembers < 6 then\n\tfor p = 1, numGroupMembers do\n\t\tlocal partymember = 'party' .. p\n\t\tlocal SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)\n\t\tlocal role = UnitGroupRolesAssigned(partymember)\n\t\tlocal hasPrescienceBuff = false;\n\t\tif UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 then\n\t\t\tif UnitName(partymember) == Ally1 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(partymember) == Ally2 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(partymember) == Ally3 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(partymember) == Ally4 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif role == \"DAMAGER\" then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\tend\n\t\tend\n\tend\n\treturn out;\nelseif numGroupMembers > 5 then\n\tfor r = 1, numGroupMembers do\n\t\tlocal raidmember = 'raid' .. r\n\t\tlocal SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", raidmember)\n\t\tlocal role = UnitGroupRolesAssigned(raidmember)\n\t\tlocal hasPrescienceBuff = false;\n\t\tlocal hasCDBuff = false;\n\t\tif UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange == 1 then\n\t\t\tif UnitName(raidmember) == Ally1 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = r;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(raidmember) == Ally2 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = r;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(raidmember) == Ally3 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = r;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(raidmember) == Ally4 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = r;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\tend\n\t\tend\n\tend\n\treturn out;\nend\nreturn out;");

            CustomFunctions.Add("BlisteringCheck", "local out = 0;\nlocal numGroupMembers = GetNumGroupMembers();\nif numGroupMembers > 0 and numGroupMembers < 6 then\n\tfor p = 1, numGroupMembers do\n\t\tlocal partymember = 'party' .. p\n\t\tlocal SpellinRange = IsSpellInRange(\"" + BlisteringScales_SpellName(Language) + "\", partymember)\n\t\tlocal role = UnitGroupRolesAssigned(partymember)\n\t\tif UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 and role == \"TANK\" then\n\t\t\tlocal hasBlistering = false\n\t\t\tfor i = 1, 25 do\n\t\t\t\tlocal name, _, stacks, _, _, _, _, _, _, buffid = UnitAura(partymember, i)\n\t\t\t\tif buffid == 360827 and stacks > 2 then\n\t\t\t\t\thasBlistering = true\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\tend\n\t\t\tif not hasBlistering then\n\t\t\t\tout = p\n\t\t\t\tbreak\n\t\t\tend\n\t\tend\n\tend\nelseif numGroupMembers > 5 then\n\tfor r = 1, numGroupMembers do\n\t\tlocal raidmember = 'raid' .. r\n\t\tlocal SpellinRange = IsSpellInRange(\"" + BlisteringScales_SpellName(Language) + "\", raidmember)\n\t\tlocal role = UnitGroupRolesAssigned(raidmember)\n\t\tif UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange == 1 and role == \"TANK\" then\n\t\t\tlocal hasBlistering = false\n\t\t\tfor i = 1, 25 do\n\t\t\t\tlocal name, _, stacks, _, _, _, _, _, _, buffid = UnitAura(raidmember, i)\n\t\t\t\tif buffid == 360827 and stacks > 2 then\n\t\t\t\t\thasBlistering = true\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\tend\n\t\t\tif not hasBlistering then\n\t\t\t\tout = r\n\t\t\t\tbreak\n\t\t\tend\n\t\tend\n\tend\nend\nreturn out;");

            CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
            "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
            "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
            "\nreturn foc");

            CustomFunctions.Add("PoisonCheck", "local y=0; " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"player\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Poison\" then y = y +1; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Poison\" then y = y +2; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Poison\" then y = y +4; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Poison\" then y = y +8; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Poison\" then y = y +16; end end " +
            "return y");

            CustomFunctions.Add("CursePoisonBleedDiseaseCheck", "local y=0; " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"player\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" or type == \"Poison\" or type == \"Bleed\" or type == \"Disease\" then y = y +1; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" or type == \"Poison\" or type == \"Bleed\" or type == \"Disease\" then y = y +2; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" or type == \"Poison\" or type == \"Bleed\" or type == \"Disease\" then y = y +4; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" or type == \"Poison\" or type == \"Bleed\" or type == \"Disease\" then y = y +8; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" or type == \"Poison\" or type == \"Bleed\" or type == \"Disease\" then y = y +16; end end " +
            "return y");

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
                            "for r = 1, GetNumGroupMembers() do local raidmember = 'raid'..r " +
                                "if UnitIsUnit(unit..'target', raidmember) then UnitTargeted = r end " +
                            "end " +
                        "end " +
                        "if UnitIsUnit(unit..'target', 'player') then UnitTargeted = 5 end " +
                    "else UnitTargeted = 0 " +
                    "end " +
                "end " +
            "end " +
            "return UnitTargeted");

            CustomFunctions.Add("CheckforAffixNPC", "if UnitExists(\"mouseover\") and not UnitIsPlayer(\"mouseover\") then\nlocal UnitName = UnitName(\"mouseover\")\nif UnitName == \"" + AfflictedSoul_SpellName(Language) + "\" then\n\treturn 1\nend\nif UnitName == \"" + IncorporealBeing_SpellName(Language) + "\" then\n\treturn 2\nend\nend\nreturn 0");

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
            Settings.Add(new Setting("Race:", m_RaceList, "Dracthyr"));
            Settings.Add(new Setting("Ingame World Latency:", 1, 200, 50));
            Settings.Add(new Setting(" "));
            Settings.Add(new Setting("Use Trinkets on CD, dont wait for Hekili:", false));
            Settings.Add(new Setting("Auto Healthstone @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Item Use:", ""));
            Settings.Add(new Setting("Auto Item @ HP%", 0, 100, 35));
            Settings.Add(new Setting("Kicks/Interrupts"));
            Settings.Add(new Setting("Randomize Kicks:", false));
            Settings.Add(new Setting("Kick at milliseconds remaining", 50, 1500, 500));
            Settings.Add(new Setting("Kick channels after milliseconds", 50, 1500, 500));
            Settings.Add(new Setting("General"));
            Settings.Add(new Setting("Auto Start Combat:", true));
            Settings.Add(new Setting("Blessing of the Bronze Out of Combat:", true));
            Settings.Add(new Setting("Auto Zephyr @ HP%", 0, 100, 20));
            Settings.Add(new Setting("Auto Renewing Blaze @ HP%", 0, 100, 60));
            Settings.Add(new Setting("Auto Obsidian Scales @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Auto Emerald Blossom @ HP%", 0, 100, 75));
            Settings.Add(new Setting("Auto Verdant Embrace @ HP%", 0, 100, 70));
            Settings.Add(new Setting("Breath of Eons Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Always Cast Breath of Eons @ Cursor during Rotation", false));
            Settings.Add(new Setting("Prescience Targets: "));
            Settings.Add(new Setting("Ally Name 1: ", ""));
            Settings.Add(new Setting("Ally Name 2: ", ""));
            Settings.Add(new Setting("Ally Name 3: ", ""));
            Settings.Add(new Setting("Ally Name 4: ", ""));
            Settings.Add(new Setting("    "));

        }

        public override void Initialize()
        {
            #region Get Addon Name
            if (Aimsharp.GetAddonName().Length >= 5)
            {
                FiveLetters = Aimsharp.GetAddonName().Substring(0, 5).ToLower();
            }
            #endregion

            Aimsharp.Latency = GetSlider("Ingame World Latency:");
            Aimsharp.QuickDelay = 50;
            Aimsharp.SlowDelay = 150;

            Aimsharp.PrintMessage("Epic PVE - Evoker Augmentation", Color.White);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything in every tab there, especially Pause !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/evoker/devastation/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.White);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoExpunge - Disables Auto Expunge on Group/Raid Members.", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCauterizingFlame - Disables Auto Cauterizing Flame on Group/Raid Members.", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " SleepWalk - Casts Sleep Walk @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " QueueLandslide - Queue Landslide on the next GCD.", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BreathOfEons - Queue Breath of Eons on the next GCD.", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BreathofEonsCursor - Always cast Breath of Eons on Cursor during the Rotation.", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);

            Language = GetDropDown("Game Client Language");
            UsableItem = GetString("Item Use:");
            AllyName1 = GetString("Ally Name 1: ");
            AllyName2 = GetString("Ally Name 2: ");
            AllyName3 = GetString("Ally Name 3: ");
            AllyName4 = GetString("Ally Name 4: ");

            #region Racial Spells
            if (GetDropDown("Race:") == "Dracthyr")
            {
                Spellbook.Add(TailSwipe_SpellName(Language)); //368970
                Spellbook.Add(WingBuffet_SpellName(Language)); //357214
            }
            #endregion

            #region Reinitialize Lists
            m_DebuffsList = new List<string> { SleepWalk_SpellName(Language), };
            m_BuffsList = new List<string> { BlessingOfTheBronze_SpellName(Language), TipTheScales_SpellName(Language), Hover_SpellName(Language), Prescience_SpellName(Language) };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language), UsableItem };
            m_SpellBook = new List<string> {
                //Utility
                EbonMight_SpellName(Language), //395152 (on player)
                BlisteringScales_SpellName(Language), //360827 (on player)
                Prescience_SpellName(Language), //409311 (on player)
                "Spatial Paradox", //406732 (on player)
                TimeSkip_SpellName(Language), //404977 (on player)

                //INTERRUPT ON TARGET or cursor?
                Quell_SpellName(Language), //351338

                //DISPELL ON TARGET or cursor?
                CauterizingFlame_SpellName(Language), //374251
                Expunge_SpellName(Language), //365585

                //DPS
                //ON TARGET
                AzureStrike_SpellName(Language), //362969
                Disintegrate_SpellName(Language), //356995
                LivingFlame_SpellName(Language), //361469
                Unravel_SpellName(Language), //368432
                Eruption_SpellName(Language), //395160
                Upheaval_SpellName(Language), //396286,408092

                //ON CURSOR
                BreathOfEons_SpellName(Language), //403631
                //ON PLAYER
                FireBreath_SpellName(Language), //382266

                //CC
                //ON TARGET
                SleepWalk_SpellName(Language), //360806

                //ON CURSOR
                Landslide_SpellName(Language), //358385

                //CD
                //BUFF
                //ON PLAYER
                BlessingOfTheBronze_SpellName(Language), //364342
                Hover_SpellName(Language), //358267
                OppressingRoar_SpellName(Language), //372048
                TimeSpiral_SpellName(Language), //374968
                TipTheScales_SpellName(Language), //370553
                BoonOfTheCovenants_SpellName(Language), //387168

                //DEFENSIVE
                //ON PLAYER
                ObsidianScales_SpellName(Language), //363916
                RenewingBlaze_SpellName(Language), //374348
                VerdantEmbrace_SpellName(Language), //360995
                Zephyr_SpellName(Language), //374227

                //HEAL ON PLAYER:
                EmeraldBlossom_SpellName(Language), //355913

            };
            #endregion

            InitializeMacros();

            InitializeSpells();

            InitializeCustomLUAFunctions();
        }

        public override bool CombatTick()
        {
            if (Aimsharp.CastingID("player") == 404977) return false;

            #region Declarations
            int SpellID1 = Aimsharp.CustomFunction("HekiliID1");
            int CooldownsToggle = Aimsharp.CustomFunction("CooldownsToggleCheck");
            int Wait = Aimsharp.CustomFunction("HekiliWait");
            int Enemies = Aimsharp.CustomFunction("HekiliEnemies");
            int TargetingGroup = Aimsharp.CustomFunction("GroupTargets");
            float Haste = Aimsharp.Haste();
            int AllyNumber = Aimsharp.CustomFunction("AllyPrescienceBuffWithName");
            int TankNumber = Aimsharp.CustomFunction("BlisteringCheck");

            bool NoInterrupts = Aimsharp.IsCustomCodeOn("NoInterrupts");
            bool NoExpunge = Aimsharp.IsCustomCodeOn("NoExpunge");
            bool NoCauterizingFlame = Aimsharp.IsCustomCodeOn("NoCauterizingFlame");
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

            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());

            int EmpowermentStage = Aimsharp.GetEmpowerStage();
            int EmpowerTo = Aimsharp.CustomFunction("EmpowermentCheck");

            if (ItemTimer.IsRunning && ItemTimer.ElapsedMilliseconds > 300000) ItemTimer.Reset();
            #endregion

            #region SpellQueueWindow
            if (Aimsharp.CustomFunction("GetSpellQueueWindow") != (Aimsharp.Latency + 100))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Setting SQW to: " + Aimsharp.Latency, Color.Purple);
                }
                Aimsharp.Cast("SetSpellQueueCvar");
            }
            #endregion

            #region Prescience
            //Prescience Logic
            if (Aimsharp.CanCast(Prescience_SpellName(Language), "player") && Aimsharp.GroupSize() > 0 && AllyNumber > 0)
            {
                //Focus Custom Ally
                if (Aimsharp.GroupSize() > 0 && Aimsharp.GroupSize() < 6)
                {
                    Aimsharp.Cast("FOC_party" + AllyNumber, true);
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Focusing Partymember - " + AllyNumber + " for Prescience!", Color.DarkGreen);
                    }
                }
                if (Aimsharp.GroupSize() > 5)
                {
                    Aimsharp.Cast("FOC_raid" + AllyNumber, true);
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Focusing Raidmember - " + AllyNumber + " for Prescience!", Color.DarkGreen);
                    }
                }
                System.Threading.Thread.Sleep(100);
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Prescience on Focus " + AllyNumber, Color.LightGreen);
                }
                Aimsharp.Cast("PrescienceFocus", true);
            }

            if (SpellID1 == 409311 && Aimsharp.CanCast(Prescience_SpellName(Language), "player") && AllyNumber == 0)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Prescience - " + SpellID1 + " because the focus function returned 0.", Color.LightGreen);
                }
                Aimsharp.Cast(Prescience_SpellName(Language), true);
                return true;
            }
            #endregion

            #region Above Pause Logic
            if (Aimsharp.CustomFunction("CheckforAffixNPC") == 1)
            {
                if (CanCastCheck(Expunge_SpellName(Language), "player"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Detected Afflicted NPC, casting Expunge", Color.Purple);
                    }
                    Aimsharp.Cast("ExpungeMO", true);
                    return true;
                }
                if (CanCastCheck(CauterizingFlame_SpellName(Language), "player"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Detected Afflicted NPC, casting Cauterizing Flame", Color.Purple);
                    }
                    Aimsharp.Cast("CauterizingFlameMO", true);
                    return true;
                }
            }

            if (Aimsharp.CustomFunction("CheckforAffixNPC") == 2)
            {
                if (CanCastCheck(SleepWalk_SpellName(Language), "player"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Detected Incorporeal NPC, casting Sleep Walk", Color.Purple);
                    }
                    Aimsharp.Cast("SleepWalkMO", true);
                    return true;
                }
            }

            if ((Aimsharp.CastingID("player") == 396286 || Aimsharp.CastingID("player") == 408092) && Aimsharp.CustomFunction("HekiliDelay") <= 100)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Upheaval again for Empower State: " + EmpowerTo, Color.Yellow);
                }
                Aimsharp.Cast(Upheaval_SpellName(Language));
            }


            if ((Aimsharp.CastingID("player") == 382266 || Aimsharp.CastingID("player") == 357208 || Aimsharp.CastingID("player") == 357209) && Aimsharp.CustomFunction("HekiliDelay") <= 100)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fire Breath again for Empower State: " + EmpowerTo, Color.Yellow);
                }
                Aimsharp.Cast(FireBreath_SpellName(Language));
                return true;
            }

            if (SpellID1 == 395152 && CanCastCheck(EbonMight_SpellName(Language), "player", false, true) && Aimsharp.CustomFunction("HekiliWait") <= 200)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Ebon Might - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(EbonMight_SpellName(Language), true);
                return true;
            }


            if (SpellID1 == 404977 && CanCastCheck(TimeSkip_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Time Skip - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(TimeSkip_SpellName(Language), true);
                return true;
            }

            if (SpellID1 == 370553 && CanCastCheck(TipTheScales_SpellName(Language), "player", false, true) && Aimsharp.CustomFunction("HekiliWait") <= 200)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Tip the Scales - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(TipTheScales_SpellName(Language), true);
                return true;
            }
            #endregion

            #region Turning Queues off
            if (Aimsharp.CastingID("player") == 358385 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("QueueLandslide"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Landslide Queue", Color.Purple);
                }
                Aimsharp.Cast("LandslideOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 360806 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("SleepWalk"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sleep Walk Queue", Color.Purple);
                }
                Aimsharp.Cast("SleepWalkOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 403631 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("BreathOfEons"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Breath of Eons Queue", Color.Purple);
                }
                Aimsharp.Cast("BreathofEonsOff");
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

            if (Aimsharp.IsCustomCodeOn("BreathOfEons") && Aimsharp.SpellCooldown(BreathOfEons_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("QueueLandslide") && Aimsharp.SpellCooldown(Landslide_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Interrupts
            if (!NoInterrupts && (Aimsharp.UnitID("target") != 168105 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))) && (Aimsharp.UnitID("target") != 157571 || Torghast_InnerFlame.Contains(Aimsharp.CastingID("target"))))
            {
                int KickValueRandom;
                int KickChannelsAfterRandom;
                if (GetCheckBox("Randomize Kicks:"))
                {
                    KickValueRandom = KickValue + GetRandomNumber(200, 500);
                    KickChannelsAfterRandom = KickChannelsAfter + GetRandomNumber(200, 500);
                }
                else
                {
                    KickValueRandom = KickValue;
                    KickChannelsAfterRandom = KickChannelsAfter;
                }
                if (CanCastCheck(Quell_SpellName(Language), "target", false, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Quell_SpellName(Language), true);
                        return true;
                    }
                }

                if (CanCastCheck(Quell_SpellName(Language), "target", false, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Quell_SpellName(Language), true);
                        return true;
                    }
                }
            }
            #endregion

            #region Auto Spells and Items
            //Auto Healthstone
            if (Aimsharp.CanUseItem(Healthstone_SpellName(Language), false) && Aimsharp.ItemCooldown(Healthstone_SpellName(Language)) == 0 && !HSTimer.IsRunning)
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Healthstone @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Healthstone - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Healthstone @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("UseHealthstone");
                    HSTimer.Start();
                    return true;
                }
            }
            //Auto Item Use
            if (Aimsharp.CanUseItem(UsableItem, false) && Aimsharp.ItemCooldown(UsableItem) == 0 && !ItemTimer.IsRunning)
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Item @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using " + UsableItem + " - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Item @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast("UseItem");
                    ItemTimer.Start();
                    return true;
                }
            }

            //Auto Obsidian Scales
            if (Aimsharp.CanCast(ObsidianScales_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Obsidian Scales @ HP%"))
                {
                    Aimsharp.Cast(ObsidianScales_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Obsidian Scales - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Obsidian Scales @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Renewing Blaze
            if (Aimsharp.CanCast(RenewingBlaze_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Renewing Blaze @ HP%"))
                {
                    Aimsharp.Cast(RenewingBlaze_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Renewing Blaze - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Renewing Blaze @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Emerald Blossom
            if (Aimsharp.CanCast(EmeraldBlossom_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Emerald Blossom @ HP%"))
                {
                    Aimsharp.Cast(EmeraldBlossom_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Emerald Blossom - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Emerald Blossom @ HP%"), Color.Black);
                    }
                    return true;
                }
            }

            //Auto Verdant Embrace
            if (Aimsharp.CanCast(VerdantEmbrace_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Verdant Embrace @ HP%"))
                {
                    Aimsharp.Cast(VerdantEmbrace_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Verdant Embrace - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Verdant Embrace @ HP%"), Color.Black);
                    }
                    return true;
                }
            }

            //Auto Zephyr
            if (Aimsharp.CanCast(Zephyr_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Zephyr @ HP%"))
                {
                    Aimsharp.Cast(Zephyr_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Zephyr - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Zephyr @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }
            #endregion

            #region Queues
            bool SleepWalk = Aimsharp.IsCustomCodeOn("SleepWalk");
            if ((Aimsharp.CastingID("player") == 360806 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && SleepWalk)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sleep Walk Queue", Color.Purple);
                }
                Aimsharp.Cast("SleepWalkOff");
                return true;
            }

            if (SleepWalk && CanCastCheck(SleepWalk_SpellName(Language), "mouseover", false, true) && (!Moving || Aimsharp.HasBuff(Hover_SpellName(Language), "player")))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Sleep Walk - Queue", Color.Purple);
                }
                Aimsharp.Cast("SleepWalkMO");
                return true;
            }

            bool Landslide = Aimsharp.IsCustomCodeOn("QueueLandslide");
            if ((Aimsharp.CastingID("player") == 358385 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Landslide)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Landslide Queue", Color.Purple);
                }
                Aimsharp.Cast("LandslideOff");
                return true;
            }

            //Queue Breath of Eons
            string BreathofEonsCast = GetDropDown("Breath of Eons Cast:");
            bool BreathofEons = Aimsharp.IsCustomCodeOn("BreathOfEons");
            if ((Aimsharp.SpellCooldown(BreathOfEons_SpellName(Language)) - Aimsharp.GCD() > 2000 || Aimsharp.LastCast() == BreathOfEons_SpellName(Language)) && BreathofEons)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Breath of Eons Queue", Color.Purple);
                }
                Aimsharp.Cast("BreathofEonsOff");
                return true;
            }

            if (BreathofEons && CanCastCheck(BreathOfEons_SpellName(Language), "player", false, true))
            {
                switch (BreathofEonsCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Breath of Eons - " + BreathofEonsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(BreathOfEons_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Breath of Eons - " + BreathofEonsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("BreathofEonsC");
                        return true;
                }
            }

            //Queue Landslide
            bool LandslideQueue = Aimsharp.IsCustomCodeOn("QueueLandslide");
            if ((Aimsharp.SpellCooldown(Landslide_SpellName(Language)) - Aimsharp.GCD() > 2000 || Aimsharp.LastCast() == Landslide_SpellName(Language)) && LandslideQueue)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Landslide Queue", Color.Purple);
                }
                Aimsharp.Cast("LandslideOff");
                return true;
            }
            if (LandslideQueue && CanCastCheck(Landslide_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Landslide - Queue", Color.Purple);
                }
                Aimsharp.Cast("LandslideC");
                return true;
            }
            #endregion

            #region Emerald Blossom
            if (UnitBelowThreshold(GetSlider("Auto Emerald Blossom @ HP%")) && Aimsharp.CanCast(EmeraldBlossom_SpellName(Language), "player", false, true))
            {
                PartyDict.Clear();
                PartyDict.Add("player", Aimsharp.Health("player"));

                var partysize = Aimsharp.GroupSize();
                if (partysize <= 5)
                {
                    for (int i = 1; i < partysize; i++)
                    {
                        var partyunit = ("party" + i);
                        if (Aimsharp.Health(partyunit) > 0 && Aimsharp.SpellInRange(EmeraldBlossom_SpellName(Language), partyunit))
                        {
                            PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                        }
                    }
                }

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    if (Aimsharp.CanCast(EmeraldBlossom_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.SpellInRange(EmeraldBlossom_SpellName(Language), unit.Key)) && Aimsharp.Health(unit.Key) <= GetSlider("Auto Emerald Blossom @ HP%"))
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
                                Aimsharp.Cast("EB_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Emerald Blossom @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Remove Poison
            if (!NoExpunge && Aimsharp.CustomFunction("PoisonCheck") > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != Expunge_SpellName(Language))
            {
                PartyDict.Clear();
                PartyDict.Add("player", Aimsharp.Health("player"));

                var partysize = Aimsharp.GroupSize();
                if (Aimsharp.GroupSize() <= 5)
                {
                    for (int i = 1; i < partysize; i++)
                    {
                        var partyunit = ("party" + i);
                        if (Aimsharp.Health(partyunit) > 0 && Aimsharp.SpellInRange(Expunge_SpellName(Language), partyunit))
                        {
                            PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                        }
                    }
                }
                if (Aimsharp.GroupSize() > 5)
                {
                    for (int i = 1; i < partysize; i++)
                    {
                        var partyunit = ("raid" + i);
                        if (Aimsharp.Health(partyunit) > 0 && Aimsharp.SpellInRange(Expunge_SpellName(Language), partyunit))
                        {
                            PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                        }
                    }
                }

                int states = Aimsharp.CustomFunction("PoisonCheck");
                CleansePlayers target;

                int KickTimer = GetRandomNumber(200, 800);

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast(Expunge_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.SpellInRange(EmeraldBlossom_SpellName(Language), unit.Key)) && isUnitCleansable(target, states))
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
                                System.Threading.Thread.Sleep(KickTimer);
                                Aimsharp.Cast("Expunge_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Remove Poison @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Remove Bleed, Poison, Disease, Curse
            if (!NoCauterizingFlame && Aimsharp.CustomFunction("CursePoisonBleedDiseaseCheck") > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != CauterizingFlame_SpellName(Language))
            {
                PartyDict.Clear();
                PartyDict.Add("player", Aimsharp.Health("player"));

                var partysize = Aimsharp.GroupSize();
                if (Aimsharp.GroupSize() <= 5)
                {
                    for (int i = 1; i < partysize; i++)
                    {
                        var partyunit = ("party" + i);
                        if (Aimsharp.Health(partyunit) > 0 && Aimsharp.SpellInRange(Expunge_SpellName(Language), partyunit))
                        {
                            PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                        }
                    }
                }
                if (Aimsharp.GroupSize() > 5)
                {
                    for (int i = 1; i < partysize; i++)
                    {
                        var partyunit = ("raid" + i);
                        if (Aimsharp.Health(partyunit) > 0 && Aimsharp.SpellInRange(Expunge_SpellName(Language), partyunit))
                        {
                            PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                        }
                    }
                }

                int states = Aimsharp.CustomFunction("CursePoisonBleedDiseaseCheck");
                CleansePlayers target;

                int KickTimer = GetRandomNumber(200, 800);

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast(CauterizingFlame_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.SpellInRange(EmeraldBlossom_SpellName(Language), unit.Key)) && isUnitCleansable(target, states))
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
                                System.Threading.Thread.Sleep(KickTimer);
                                Aimsharp.Cast("CF_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Remove Curse, Poison, Bleed or Disease @ " + unit.Key + " - " + unit.Value, Color.Purple);
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

            if (Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat && Wait <= 200)
            {
                if (!Aimsharp.HasDebuff(SleepWalk_SpellName(Language), "target", true) && !Aimsharp.HasDebuff(Landslide_SpellName(Language), "target", true) && !Landslide)
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
                    if (SpellID1 == 3)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Using Weapon", Color.Purple);
                        }
                        Aimsharp.Cast("UseWeapon");
                        return true;
                    }
                    #endregion

                    #region Racials

                    if (SpellID1 == 368970 && CanCastCheck(TailSwipe_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tail Swipe - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TailSwipe_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 357214 && CanCastCheck(WingBuffet_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wing Buffet - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(WingBuffet_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Covenants
                    ///Covenants
                    if (SpellID1 == 387168 && CanCastCheck(BoonOfTheCovenants_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Boon of the Covenants - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(BoonOfTheCovenants_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - No GCD
                    ///Class Spells
                    //Target - No GCD
                    if (SpellID1 == 351338 && CanCastCheck(Quell_SpellName(Language), "target", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Quell- " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Quell_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    //Target - GCD
                    if (SpellID1 == 356995 && CanCastCheck(Disintegrate_SpellName(Language), "target", false, true) && (!Moving || Aimsharp.HasBuff(Hover_SpellName(Language), "player")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Disintegrate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Disintegrate_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 383121 && CanCastCheck(Landslide_SpellName(Language), "target", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Landslide - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(Landslide_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 361469 && CanCastCheck(LivingFlame_SpellName(Language), "target", false, true) && (!Moving || Aimsharp.HasBuff(Hover_SpellName(Language), "player")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Living Flame - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(LivingFlame_SpellName(Language));
                        return true;
                    }
                    if (SpellID1 == 406732 && CanCastCheck("Spatial Paradox", "player", false))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spatial Paradox - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("Spatial Paradox", true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    if (SpellID1 == 370553 && CanCastCheck(TipTheScales_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tip the Scales - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TipTheScales_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 364342 && CanCastCheck(BlessingOfTheBronze_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blessing of the Bronze - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BlessingOfTheBronze_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 358267 && CanCastCheck(Hover_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Hover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Hover_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 374968 && CanCastCheck(TimeSpiral_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Time Spiral - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(TimeSpiral_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 358385 && CanCastCheck(Landslide_SpellName(Language), "player", false, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Landslide - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Landslide_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 363916 && CanCastCheck(ObsidianScales_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Obsidian Scales - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ObsidianScales_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 372048 && CanCastCheck(OppressingRoar_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Oppressing Roar - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(OppressingRoar_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 365585 && CanCastCheck(Expunge_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Expunge - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Expunge_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 374251 && CanCastCheck(CauterizingFlame_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cauterizing Flame - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(CauterizingFlame_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Fire Spells - Player GCD
                    if (SpellID1 == 235313 && CanCastCheck(Zephyr_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Zephyr - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Zephyr_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 395152 && CanCastCheck(EbonMight_SpellName(Language), "player", false, false))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ebon Might - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(EbonMight_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 360827 && CanCastCheck(BlisteringScales_SpellName(Language), "player", false, false))
                    {
                        if (Aimsharp.GroupSize() > 0)
                        {
                            if (Aimsharp.GroupSize() < 6)
                            {
                                Aimsharp.Cast("FOC_party" + TankNumber, true);
                                Aimsharp.PrintMessage("Focusing Tank " + TankNumber, Color.DarkGreen);
                            }
                            if (Aimsharp.GroupSize() > 5)
                            {
                                Aimsharp.Cast("FOC_raid" + TankNumber, true);
                                Aimsharp.PrintMessage("Focusing Tank " + TankNumber, Color.DarkGreen);
                            }
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Casting Blistering Scales - " + SpellID1 + " on Focus " + TankNumber, Color.LightGreen);
                            }
                            Aimsharp.Cast("BlisteringScalesFocus", true);
                        }
                        else
                        {
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Casting Blistering Scales - " + SpellID1, Color.LightGreen);
                            }
                            Aimsharp.Cast(BlisteringScales_SpellName(Language));
                            return true;
                        }
                        return true;
                    }

                    if (SpellID1 == 404977 && CanCastCheck(TimeSkip_SpellName(Language), "player", false, false))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Time Skip - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TimeSkip_SpellName(Language), true);
                        return true;
                    }

                    if ((SpellID1 == 382266 || SpellID1 == 357208 || SpellID1 == 357209) && Aimsharp.CanCast(FireBreath_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Start casting Fire Breath - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FireBreath_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 403631 && CanCastCheck(BreathOfEons_SpellName(Language), "player", false, true) && (Aimsharp.CustomFunction("BoEMouseover") == 1 || GetCheckBox("Always Cast Breath of Eons @ Cursor during Rotation") || Aimsharp.IsCustomCodeOn("BreathofEonsCursor")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Breath of Eons @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("BreathofEonsC");
                        return true;
                    }
                    else if (SpellID1 == 403631 && CanCastCheck(BreathOfEons_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Breath of Eons - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BreathOfEons_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Fire Spells - Target GCD
                    if (SpellID1 == 368432 && CanCastCheck(Unravel_SpellName(Language), "target", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Unravel - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Unravel_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 362969 && CanCastCheck(AzureStrike_SpellName(Language), "target", true, false))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Azure Strike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AzureStrike_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 357211 && CanCastCheck(Pyre_SpellName(Language), "target", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Pyre - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Pyre_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 396286 || SpellID1 == 408092) && Aimsharp.CanCast(Upheaval_SpellName(Language), "target", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Start casting Upheaval - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Upheaval_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 395160 && CanCastCheck(Eruption_SpellName(Language), "target", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Eruption - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Eruption_SpellName(Language));
                        return true;
                    }
                    if (SpellID1 == 360995 && CanCastCheck(VerdantEmbrace_SpellName(Language), "target", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Verdant Embrace - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(VerdantEmbrace_SpellName(Language));
                        return true;
                    }
                    if (SpellID1 == 355913 && CanCastCheck(EmeraldBlossom_SpellName(Language), "player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Emerald Blossom - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(EmeraldBlossom_SpellName(Language));
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
            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());
            bool Moving = Aimsharp.PlayerIsMoving();
            bool BOTBOOC = GetCheckBox("Blessing of the Bronze Out of Combat:");

            if (HSTimer.IsRunning) HSTimer.Reset();
            if (ItemTimer.IsRunning && ItemTimer.ElapsedMilliseconds > 300000) ItemTimer.Reset();
            #endregion

            #region SpellQueueWindow
            if (Aimsharp.CustomFunction("GetSpellQueueWindow") != (Aimsharp.Latency + 100))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Setting SQW to: " + Aimsharp.Latency, Color.Purple);
                }
                Aimsharp.Cast("SetSpellQueueCvar");
            }
            #endregion

            #region Above Pause Logic
            if (Aimsharp.CustomFunction("CheckforAffixNPC") == 1)
            {
                if (CanCastCheck(Expunge_SpellName(Language), "player"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Detected Rotation for Afflicted NPC, casting Expunge", Color.Purple);
                    }
                    Aimsharp.Cast("ExpungeMO", true);
                    return true;
                }
                if (CanCastCheck(CauterizingFlame_SpellName(Language), "player"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Detected Rotation for Afflicted NPC, casting Cauterizing Flame", Color.Purple);
                    }
                    Aimsharp.Cast("CauterizingFlameMO", true);
                    return true;
                }
            }

            if (Aimsharp.CustomFunction("CheckforAffixNPC") == 2)
            {
                if (CanCastCheck(SleepWalk_SpellName(Language), "player"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Detected Rotation for Incorporeal NPC, casting Sleep Walk", Color.Purple);
                    }
                    Aimsharp.Cast("SleepWalkMO", true);
                    return true;
                }
            }
            #endregion
            #region Turning Queues off
            if (Aimsharp.CastingID("player") == 358385 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("QueueLandslide"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Landslide Queue", Color.Purple);
                }
                Aimsharp.Cast("LandslideOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 360806 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("SleepWalk"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sleep Walk Queue", Color.Purple);
                }
                Aimsharp.Cast("SleepWalkOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 403631 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("BreathOfEons"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Breath of Eons Queue", Color.Purple);
                }
                Aimsharp.Cast("BreathofEonsOff");
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

            if (Aimsharp.IsCustomCodeOn("BreathOfEons") && Aimsharp.SpellCooldown(BreathOfEons_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("QueueLandslide") && Aimsharp.SpellCooldown(Landslide_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            bool SleepWalk = Aimsharp.IsCustomCodeOn("SleepWalk");
            if ((Aimsharp.CastingID("player") == 360806 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && SleepWalk)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sleep Walk Queue", Color.Purple);
                }
                Aimsharp.Cast("SleepWalkOff");
                return true;
            }

            if (SleepWalk && CanCastCheck(SleepWalk_SpellName(Language), "mouseover", false, true) && (!Moving || Aimsharp.HasBuff(Hover_SpellName(Language), "player")))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Sleep Walk - Queue", Color.Purple);
                }
                Aimsharp.Cast("SleepWalkMO");
                return true;
            }

            bool Landslide = Aimsharp.IsCustomCodeOn("QueueLandslide");
            if ((Aimsharp.CastingID("player") == 358385 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Landslide)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Landslide Queue", Color.Purple);
                }
                Aimsharp.Cast("LandslideOff");
                return true;
            }

            //Queue Breath of Eons
            string BreathofEonsCast = GetDropDown("Breath of Eons Cast:");
            bool BreathofEons = Aimsharp.IsCustomCodeOn("BreathOfEons");
            if ((Aimsharp.SpellCooldown(BreathOfEons_SpellName(Language)) - Aimsharp.GCD() > 2000 || Aimsharp.LastCast() == BreathOfEons_SpellName(Language)) && BreathofEons)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Breath of Eons Queue", Color.Purple);
                }
                Aimsharp.Cast("BreathofEonsOff");
                return true;
            }

            if (BreathofEons && CanCastCheck(BreathOfEons_SpellName(Language), "player", false, true))
            {
                switch (BreathofEonsCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Breath of Eons - " + BreathofEonsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(BreathOfEons_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Breath of Eons - " + BreathofEonsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("BreathofEonsC");
                        return true;
                }
            }
            //Queue Landslide
            bool LandslideQueue = Aimsharp.IsCustomCodeOn("QueueLandslide");
            if ((Aimsharp.SpellCooldown(Landslide_SpellName(Language)) - Aimsharp.GCD() > 2000 || Aimsharp.LastCast() == Landslide_SpellName(Language)) && LandslideQueue)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Landslide Queue", Color.Purple);
                }
                Aimsharp.Cast("LandslideOff");
                return true;
            }
            if (LandslideQueue && CanCastCheck(Landslide_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Landslide - Queue", Color.Purple);
                }
                Aimsharp.Cast("LandslideC");
                return true;
            }
            #endregion

            #region Out of Combat Spells
            if (SpellID1 == 364342 && CanCastCheck(BlessingOfTheBronze_SpellName(Language), "player", false, true) && !Aimsharp.HasBuff(BlessingOfTheBronze_SpellName(Language), "player", true) && !Aimsharp.HasBuff(BlessingOfTheBronze_SpellName(Language), "player", false) && BOTBOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of the Bronze (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(BlessingOfTheBronze_SpellName(Language));
                return true;
            }

            if (CanCastCheck(BlessingOfTheBronze_SpellName(Language), "player", false, true) && !Aimsharp.HasBuff(BlessingOfTheBronze_SpellName(Language), "player", true) && !Aimsharp.HasBuff(BlessingOfTheBronze_SpellName(Language), "player", false) && BOTBOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of the Bronze (Out of Combat)", Color.Purple);
                }
                Aimsharp.Cast(BlessingOfTheBronze_SpellName(Language));
                return true;
            }
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat && !Aimsharp.HasDebuff(SleepWalk_SpellName(Language), "target", true) && !Aimsharp.HasDebuff(Landslide_SpellName(Language), "target", true) && !Landslide)
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