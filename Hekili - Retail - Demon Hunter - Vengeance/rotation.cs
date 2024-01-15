using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicDHVengeanceHekili : Rotation
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

        #region SpellFunctions
        ///<summary>spell=28730</summary>
        private static string ArcaneTorrent_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Arcane Torrent";
                case "Deutsch": return "Arkaner Strom";
                case "Español": return "Torrente Arcano";
                case "Français": return "Torrent arcanique";
                case "Italiano": return "Torrente Arcano";
                case "Português Brasileiro": return "Torrente Arcana";
                case "Русский": return "Волшебный поток";
                case "한국어": return "비전 격류";
                case "简体中文": return "奥术洪流";
                default: return "Arcane Torrent";
            }
        }

        ///<summary>spell=320341</summary>
        private static string BulkExtraction_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bulk Extraction";
                case "Deutsch": return "Massenextraktion";
                case "Español": return "Extracción en masa";
                case "Français": return "Extraction de masse";
                case "Italiano": return "Estrazione Forzata";
                case "Português Brasileiro": return "Extração em Massa";
                case "Русский": return "Массовое извлечение";
                case "한국어": return "대량 추출";
                case "简体中文": return "噬众";
                default: return "Bulk Extraction";
            }
        }

        ///<summary>spell=179057</summary>
        private static string ChaosNova_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Chaos Nova";
                case "Deutsch": return "Chaosnova";
                case "Español": return "Nova de caos";
                case "Français": return "Nova du chaos";
                case "Italiano": return "Nova del Caos";
                case "Português Brasileiro": return "Nova do Caos";
                case "Русский": return "Кольцо Хаоса";
                case "한국어": return "혼돈의 회오리";
                case "简体中文": return "混乱新星";
                default: return "Chaos Nova";
            }
        }

        ///<summary>spell=278326</summary>
        private static string ConsumeMagic_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Consume Magic";
                case "Deutsch": return "Magie aufzehren";
                case "Español": return "Consumo de magia";
                case "Français": return "Manavore";
                case "Italiano": return "Consumo Magia";
                case "Português Brasileiro": return "Consumir Magia";
                case "Русский": return "Поглощение магии";
                case "한국어": return "마법 삼키기";
                case "简体中文": return "吞噬魔法";
                default: return "Consume Magic";
            }
        }

        ///<summary>spell=196718</summary>
        private static string Darkness_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Darkness";
                case "Deutsch": return "Dunkelheit";
                case "Español": return "Oscuridad";
                case "Français": return "Ténèbres";
                case "Italiano": return "Oscurità";
                case "Português Brasileiro": return "Trevas";
                case "Русский": return "Мрак";
                case "한국어": return "어둠";
                case "简体中文": return "黑暗";
                default: return "Darkness";
            }
        }

        ///<summary>spell=203720</summary>
        private static string DemonSpikes_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Demon Spikes";
                case "Deutsch": return "Dämonenstachel";
                case "Español": return "Púas de demonio";
                case "Français": return "Pointes démoniaques";
                case "Italiano": return "Aculei Demoniaci";
                case "Português Brasileiro": return "Espinhos Demoníacos";
                case "Русский": return "Демонические шипы";
                case "한국어": return "악마 쐐기";
                case "简体中文": return "恶魔尖刺";
                default: return "Demon Spikes";
            }
        }

        ///<summary>spell=183752</summary>
        private static string Disrupt_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Disrupt";
                case "Deutsch": return "Unterbrechen";
                case "Español": return "Interrumpir";
                case "Français": return "Ébranlement";
                case "Italiano": return "Distruzione";
                case "Português Brasileiro": return "Interromper";
                case "Русский": return "Прерывание";
                case "한국어": return "분열";
                case "简体中文": return "瓦解";
                default: return "Disrupt";
            }
        }

        ///<summary>spell=390163</summary>
        private static string ElysianDecree_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Elysian Decree";
                case "Deutsch": return "Elysischer Erlass";
                case "Español": return "Decreto elisio";
                case "Français": return "Décret élyséen";
                case "Italiano": return "Decreto Elisio";
                case "Português Brasileiro": return "Decreto Elísio";
                case "Русский": return "Элизийский декрет";
                case "한국어": return "하늘의 칙령";
                case "简体中文": return "极乐敕令";
                default: return "Elysian Decree";
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

        ///<summary>spell=232893</summary>
        private static string Felblade_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Felblade";
                case "Deutsch": return "Teufelsklinge";
                case "Español": return "Hoja mácula";
                case "Français": return "Gangrelame";
                case "Italiano": return "Vilspada";
                case "Português Brasileiro": return "Lâmina Vil";
                case "Русский": return "Клинок Скверны";
                case "한국어": return "지옥칼";
                case "简体中文": return "邪能之刃";
                default: return "Felblade";
            }
        }

        ///<summary>spell=212084</summary>
        private static string FelDevastation_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fel Devastation";
                case "Deutsch": return "Dämonische Verwüstung";
                case "Español": return "Devastación vil";
                case "Français": return "Dévastation gangrenée";
                case "Italiano": return "Vildevastazione";
                case "Português Brasileiro": return "Devastação Vil";
                case "Русский": return "Опустошение Скверной";
                case "한국어": return "지옥 황폐";
                case "简体中文": return "邪能毁灭";
                default: return "Fel Devastation";
            }
        }

        ///<summary>spell=211881</summary>
        private static string FelEruption_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fel Eruption";
                case "Deutsch": return "Teufelseruption";
                case "Español": return "Erupción vil";
                case "Français": return "Éruption gangrenée";
                case "Italiano": return "Vileruzione";
                case "Português Brasileiro": return "Erupção Vil";
                case "Русский": return "Извержение Скверны";
                case "한국어": return "지옥 분출";
                case "简体中文": return "邪能爆发";
                default: return "Fel Eruption";
            }
        }

        ///<summary>spell=204021</summary>
        private static string FieryBrand_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fiery Brand";
                case "Deutsch": return "Flammendes Brandmal";
                case "Español": return "Marca ígnea";
                case "Français": return "Marque enflammée";
                case "Italiano": return "Marchiatura Ardente";
                case "Português Brasileiro": return "Marca Ardente";
                case "Русский": return "Огненное клеймо";
                case "한국어": return "불타는 낙인";
                case "简体中文": return "烈火烙印";
                default: return "Fiery Brand";
            }
        }

        ///<summary>spell=263642</summary>
        private static string Fracture_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fracture";
                case "Deutsch": return "Fraktur";
                case "Español": return "Fractura";
                case "Français": return "Fracture";
                case "Italiano": return "Frattura";
                case "Português Brasileiro": return "Fratura";
                case "Русский": return "Разлом";
                case "한국어": return "균열";
                case "简体中文": return "破裂";
                default: return "Fracture";
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

        ///<summary>spell=258920</summary>
        private static string ImmolationAura_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Immolation Aura";
                case "Deutsch": return "Feuerbrandaura";
                case "Español": return "Aura de inmolación";
                case "Français": return "Aura d’immolation";
                case "Italiano": return "Rogo Rovente";
                case "Português Brasileiro": return "Aura de Imolação";
                case "Русский": return "Обжигающий жар";
                case "한국어": return "제물의 오라";
                case "简体中文": return "献祭光环";
                default: return "Immolation Aura";
            }
        }

        ///<summary>spell=217832</summary>
        private static string Imprison_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Imprison";
                case "Deutsch": return "Einkerkern";
                case "Español": return "Encarcelar";
                case "Français": return "Emprisonnement";
                case "Italiano": return "Imprigionamento";
                case "Português Brasileiro": return "Aprisionar";
                case "Русский": return "Пленение";
                case "한국어": return "감금";
                case "简体中文": return "禁锢";
                default: return "Imprison";
            }
        }

        ///<summary>spell=189110</summary>
        private static string InfernalStrike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Infernal Strike";
                case "Deutsch": return "Infernoeinschlag";
                case "Español": return "Golpe infernal";
                case "Français": return "Frappe infernale";
                case "Italiano": return "Assalto Infernale";
                case "Português Brasileiro": return "Golpe Infernal";
                case "Русский": return "Инфернальный удар";
                case "한국어": return "불지옥 일격";
                case "简体中文": return "地狱火撞击";
                default: return "Infernal Strike";
            }
        }

        ///<summary>spell=191427</summary>
        private static string Metamorphosis_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Metamorphosis";
                case "Deutsch": return "Metamorphose";
                case "Español": return "Metamorfosis";
                case "Français": return "Métamorphose";
                case "Italiano": return "Metamorfosi Demoniaca";
                case "Português Brasileiro": return "Metamorfose";
                case "Русский": return "Метаморфоза";
                case "한국어": return "탈태";
                case "简体中文": return "恶魔变形";
                default: return "Metamorphosis";
            }
        }

        ///<summary>spell=58984</summary>
        private static string Shadowmeld_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shadowmeld";
                case "Deutsch": return "Schattenmimik";
                case "Español": return "Fusión de las sombras";
                case "Français": return "Camouflage dans l'ombre";
                case "Italiano": return "Fondersi nelle Ombre";
                case "Português Brasileiro": return "Fusão Sombria";
                case "Русский": return "Слиться с тенью";
                case "한국어": return "그림자 숨기";
                case "简体中文": return "影遁";
                default: return "Shadowmeld";
            }
        }

        ///<summary>spell=203782</summary>
        private static string Shear_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shear";
                case "Deutsch": return "Abscheren";
                case "Español": return "Hender";
                case "Français": return "Entaille";
                case "Italiano": return "Recisione";
                case "Português Brasileiro": return "Talhar";
                case "Русский": return "Иссечение";
                case "한국어": return "절단";
                case "简体中文": return "裂魂";
                default: return "Shear";
            }
        }

        ///<summary>spell=202138</summary>
        private static string SigilOfChains_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sigil of Chains";
                case "Deutsch": return "Zeichen der Ketten";
                case "Español": return "Sigilo de cadenas";
                case "Français": return "Sigil de chaînes";
                case "Italiano": return "Sigillo delle Catene";
                case "Português Brasileiro": return "Signo dos Grilhões";
                case "Русский": return "Печать цепей";
                case "한국어": return "사슬의 인장";
                case "简体中文": return "锁链咒符";
                default: return "Sigil of Chains";
            }
        }

        ///<summary>spell=204596</summary>
        private static string SigilOfFlame_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sigil of Flame";
                case "Deutsch": return "Zeichen der Flamme";
                case "Español": return "Sigilo de llamas";
                case "Français": return "Sigil de feu";
                case "Italiano": return "Sigillo della Fiamma";
                case "Português Brasileiro": return "Signo da Chama";
                case "Русский": return "Печать огня";
                case "한국어": return "불꽃의 인장";
                case "简体中文": return "烈焰咒符";
                default: return "Sigil of Flame";
            }
        }

        ///<summary>spell=389813</summary>
        private static string SigilOfMisery_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sigil of Misery";
                case "Deutsch": return "Zeichen des Elends";
                case "Español": return "Sigilo de desgracia";
                case "Français": return "Sigil de supplice";
                case "Italiano": return "Sigillo della Miseria";
                case "Português Brasileiro": return "Signo da Aflição";
                case "Русский": return "Печать страдания";
                case "한국어": return "불행의 인장";
                case "简体中文": return "悲苦咒符";
                default: return "Sigil of Misery";
            }
        }

        ///<summary>spell=202137</summary>
        private static string SigilOfSilence_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sigil of Silence";
                case "Deutsch": return "Zeichen der Stille";
                case "Español": return "Sigilo de silencio";
                case "Français": return "Sigil de silence";
                case "Italiano": return "Sigillo del Silenzio";
                case "Português Brasileiro": return "Signo do Silêncio";
                case "Русский": return "Печать немоты";
                case "한국어": return "침묵의 인장";
                case "简体中文": return "沉默咒符";
                default: return "Sigil of Silence";
            }
        }

        ///<summary>spell=15487</summary>
        private static string Silence_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Silence";
                case "Deutsch": return "Stille";
                case "Español": return "Silencio";
                case "Français": return "Silence";
                case "Italiano": return "Silenzio";
                case "Português Brasileiro": return "Silêncio";
                case "Русский": return "Безмолвие";
                case "한국어": return "침묵";
                case "简体中文": return "沉默";
                default: return "Silence";
            }
        }

        ///<summary>spell=263648</summary>
        private static string SoulBarrier_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Soul Barrier";
                case "Deutsch": return "Seelenbarriere";
                case "Español": return "Barrera de alma";
                case "Français": return "Barrière d’âme";
                case "Italiano": return "Barriera d'Anima";
                case "Português Brasileiro": return "Barreira de Almas";
                case "Русский": return "Призрачный барьер";
                case "한국어": return "영혼 방벽";
                case "简体中文": return "灵魂壁障";
                default: return "Soul Barrier";
            }
        }

        ///<summary>spell=207407</summary>
        private static string SoulCarver_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Soul Carver";
                case "Deutsch": return "Seelenschnitzer";
                case "Español": return "Trinchador de almas";
                case "Français": return "Déchirement d’âme";
                case "Italiano": return "Intagliatore d'Anime";
                case "Português Brasileiro": return "Entalhador de Alma";
                case "Русский": return "Разрубатель душ";
                case "한국어": return "영혼 저미기";
                case "简体中文": return "灵魂切削";
                default: return "Soul Carver";
            }
        }

        ///<summary>spell=228477</summary>
        private static string SoulCleave_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Soul Cleave";
                case "Deutsch": return "Seelenspalter";
                case "Español": return "Rajar alma";
                case "Français": return "Division de l’âme";
                case "Italiano": return "Fendente d'Anima";
                case "Português Brasileiro": return "Cutilada da Alma";
                case "Русский": return "Раскалывание душ";
                case "한국어": return "영혼 베어내기";
                case "简体中文": return "灵魂裂劈";
                default: return "Soul Cleave";
            }
        }

        ///<summary>spell=247454</summary>
        private static string SpiritBomb_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Spirit Bomb";
                case "Deutsch": return "Seelenbombe";
                case "Español": return "Bomba de espíritu";
                case "Français": return "Bombe spirituelle";
                case "Italiano": return "Bomba Spirituale";
                case "Português Brasileiro": return "Bomba Espiritual";
                case "Русский": return "Взрывная душа";
                case "한국어": return "영혼 폭탄";
                case "简体中文": return "幽魂炸弹";
                default: return "Spirit Bomb";
            }
        }

        ///<summary>spell=370965</summary>
        private static string TheHunt_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "The Hunt";
                case "Deutsch": return "Die Jagd";
                case "Español": return "La caza";
                case "Français": return "La traque";
                case "Italiano": return "A Caccia";
                case "Português Brasileiro": return "A Caçada";
                case "Русский": return "Охота";
                case "한국어": return "사냥";
                case "简体中文": return "恶魔追击";
                default: return "The Hunt";
            }
        }

        ///<summary>spell=185123</summary>
        private static string ThrowGlaive_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Throw Glaive";
                case "Deutsch": return "Gleve werfen";
                case "Español": return "Lanzar guja";
                case "Français": return "Lancer de glaive";
                case "Italiano": return "Lancio Lama";
                case "Português Brasileiro": return "Arremessar Glaive";
                case "Русский": return "Бросок боевого клинка";
                case "한국어": return "글레이브 투척";
                case "简体中文": return "投掷利刃";
                default: return "Throw Glaive";
            }
        }

        ///<summary>spell=185245</summary>
        private static string Torment_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Torment";
                case "Deutsch": return "Folter";
                case "Español": return "Tormento";
                case "Français": return "Tourment";
                case "Italiano": return "Tormento";
                case "Português Brasileiro": return "Tormento";
                case "Русский": return "Мучение";
                case "한국어": return "고문";
                case "简体中文": return "折磨";
                default: return "Torment";
            }
        }

        ///<summary>spell=198793</summary>
        private static string VengefulRetreat_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Vengeful Retreat";
                case "Deutsch": return "Rachsüchtiger Rückzug";
                case "Español": return "Retirada vengativa";
                case "Français": return "Retraite vengeresse";
                case "Italiano": return "Ritiro Vendicativo";
                case "Português Brasileiro": return "Retirada Vingativa";
                case "Русский": return "Коварное отступление";
                case "한국어": return "복수의 퇴각";
                case "简体中文": return "复仇回避";
                default: return "Vengeful Retreat";
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
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle", "ChaosNova", "ImprisonMO", "QueueDarkness", "FelEruption", "SigilofMisery", "SigilofChains", "SigilofSilence", "QueueMetamorphosis", "ElysianDecree", "InfernalStrike"};
        private List<string> m_DebuffsList;
        private List<string> m_BuffsList;
        private List<string> m_ItemsList;
        private List<string> m_SpellBook_General;
        private List<string> m_RaceList = new List<string> { "nightelf", "bloodelf",};
        private List<string> m_CastingList = new List<string> { "Manual", "Cursor", "Player" };

        private List<int> Torghast_InnerFlame = new List<int> { 258935, 258938, 329422, 329423, };

        List<int> InstanceIDList = new List<int>
        {
            2291, 2287, 2290, 2289, 2284, 2285, 2286, 2293, 1663, 1664, 1665, 1666, 1667, 1668, 1669, 1674, 1675, 1676, 1677, 1678, 1679, 1680, 1683, 1684, 1685, 1686, 1687, 1692, 1693, 1694, 1695, 1697, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999, 2000, 2001, 2002, 2003, 2004, 2441, 2450,
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

        private static bool Debug;

        #region CanCasts
        private bool SpellCast(int HekiliID, string SpellName, string target, string MacroName = "")
        {
            if (MacroName == "")
            {
                if (Aimsharp.CustomFunction("HekiliID1") == HekiliID && (Aimsharp.CanCast(SpellName, target, RangeCheck, CastCheck) || Aimsharp.SpellCooldown(SpellName) - Aimsharp.GCD() <= 0 || (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") + 100) || Aimsharp.GCD() == 0))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting " + SpellName + " - " + HekiliID, Color.Purple);
                    }
                    Aimsharp.Cast(SpellName);
                    return true;
                }
            }
            if (MacroName != "")
            {
                if (Aimsharp.CustomFunction("HekiliID1") == HekiliID && (Aimsharp.CanCast(SpellName, target, RangeCheck, CastCheck) || Aimsharp.SpellCooldown(SpellName) - Aimsharp.GCD() <= 0 || (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") + 100) || Aimsharp.GCD() == 0))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Macro " + MacroName + " - " + HekiliID, Color.Purple);
                    }
                    Aimsharp.Cast(MacroName);
                    return true;
                }
            }
            return false;
        }
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
            Macros.Add("Weapon", "/use 16");

            //Healthstone
            Macros.Add("UseHealthstone", "/use " + Healthstone_SpellName(Language));
            Macros.Add("UseItem", "/use " + UsableItem);


            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + Aimsharp.Latency);

            //Queues
            Macros.Add("ChaosNovaOff", "/" + FiveLetters + " ChaosNova");
            Macros.Add("DarknessOff", "/" + FiveLetters + " QueueDarkness");
            Macros.Add("FelEruptionOff", "/" + FiveLetters + " FelEruption");

            Macros.Add("ImprisonOff", "/" + FiveLetters + " ImprisonMO");
            Macros.Add("ImprisonMO", "/cast [@mouseover] " + Imprison_SpellName(Language));

            Macros.Add("SigilofMiseryC", "/cast [@cursor] " + SigilOfMisery_SpellName(Language));
            Macros.Add("SigilofMiseryOff", "/" + FiveLetters + " SigilofMisery");
            Macros.Add("SigilofMiseryP", "/cast [@player] " + SigilOfMisery_SpellName(Language));

            Macros.Add("SigilofChainsC", "/cast [@cursor] " + SigilOfChains_SpellName(Language));
            Macros.Add("SigilofChainsOff", "/" + FiveLetters + " SigilofChains");
            Macros.Add("SigilofChainsP", "/cast [@player] " + SigilOfChains_SpellName(Language));

            Macros.Add("SigilofSilenceC", "/cast [@cursor] " + SigilOfSilence_SpellName(Language));
            Macros.Add("SigilofSilenceOff", "/" + FiveLetters + " SigilofSilence");
            Macros.Add("SigilofSilenceP", "/cast [@player] " + SigilOfSilence_SpellName(Language));

            Macros.Add("SigilofFlameP", "/cast [@player] " + SigilOfFlame_SpellName(Language));
            Macros.Add("SigilofFlameC", "/cast [@cursor] " + SigilOfFlame_SpellName(Language));

            Macros.Add("QueueMetamorphosisOff", "/" + FiveLetters + " QueueMetamorphosis");
            Macros.Add("MetamorphosisP", "/cast [@player] " + Metamorphosis_SpellName(Language));
            Macros.Add("MetamorphosisC", "/cast [@cursor] " + Metamorphosis_SpellName(Language));

            Macros.Add("ElysianDecreeP", "/cast [@player] " + ElysianDecree_SpellName(Language));
            Macros.Add("ElysianDecreeC", "/cast [@cursor] " + ElysianDecree_SpellName(Language));
            Macros.Add("ElysianDecreeOff", "/" + FiveLetters + " ElysianDecree");

            Macros.Add("InfernalStrikeP", "/cast [@player] " + InfernalStrike_SpellName(Language));
            Macros.Add("InfernalStrikeC", "/cast [@cursor] " + InfernalStrike_SpellName(Language));
            Macros.Add("InfernalStrikeOff", "/" + FiveLetters + " InfernalStrike");

        }

        private void InitializeSpells()
        {
            foreach (string Spell in m_SpellBook_General)
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

            CustomFunctions.Add("HekiliWait", "if HekiliDisplayPrimary.Recommendations[1].wait ~= nil and HekiliDisplayPrimary.Recommendations[1].wait * 1000 > 0 then return math.floor(HekiliDisplayPrimary.Recommendations[1].wait * 1000) end return 0");

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("TargetIsMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitExists('target') and UnitIsDead('target') ~= true and UnitIsUnit('mouseover', 'target') then return 1 end; return 0");

            CustomFunctions.Add("CRMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') == true and UnitIsPlayer('mouseover') == true then return 1 end; return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");
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
            Settings.Add(new Setting("Race:", m_RaceList, "bloodelf"));
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
            Settings.Add(new Setting("Auto Darkness @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Auto Demon Spikes @ HP%", 0, 100, 70));
            Settings.Add(new Setting("Sigils Cast:", m_CastingList, "Player"));
            Settings.Add(new Setting("Infernal Strike Cast:", m_CastingList, "Player"));
            Settings.Add(new Setting("Metamorphosis Cast:", m_CastingList, "Player"));
            Settings.Add(new Setting("Elysian Decree Cast:", m_CastingList, "Player"));
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

            Aimsharp.PrintMessage("Epic PVE - Demon Hunter Protection", Color.White);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything in every tab there, especially Pause !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/demon-hunter/vengeance/overview-pve-tank", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.White);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " ChaosNova - Casts Chaos Nova @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " ImprisonMO - Casts Imprison @ Mouseover", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " QueueDarkness - Casts Darkness @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FelEruption - Casts Fel Eruption @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " SigilofMisery - Casts Sigil of Misery @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " SigilofChains - Casts Sigil of Chains @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " SigilofSilence - Casts Sigil of Silence @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " QueueMetamorphosis - Casts Metamorphosis @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " ElysianDecree - Casts Elysian Decree @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " InfernalStrike - Casts Infernal Strike @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);

            Language = GetDropDown("Game Client Language");
            UsableItem = GetString("Item Use:");

            #region Racial Spells
            if (GetDropDown("Race:") == "bloodelf")
            {
                Spellbook.Add(ArcaneTorrent_SpellName(Language)); //28730, 25046, 50613, 69179, 80483, 129597
            }

            if (GetDropDown("Race:") == "nightelf")
            {
                Spellbook.Add(Shadowmeld_SpellName(Language)); //58984
            }
            #endregion

            #region Reinitialize Lists

            m_DebuffsList = new List<string> { Imprison_SpellName(Language)};
            m_BuffsList = new List<string> { };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language), UsableItem};
            m_SpellBook_General = new List<string> {
                SigilOfMisery_SpellName(Language),
                SigilOfChains_SpellName(Language),
                SigilOfSilence_SpellName(Language),
                SigilOfFlame_SpellName(Language),
                Metamorphosis_SpellName(Language),
                ElysianDecree_SpellName(Language),
                InfernalStrike_SpellName(Language),

                Disrupt_SpellName(Language),
                Darkness_SpellName(Language),
                DemonSpikes_SpellName(Language),

                ChaosNova_SpellName(Language),
                FelEruption_SpellName(Language),
                Imprison_SpellName(Language),

                ConsumeMagic_SpellName(Language),
                TheHunt_SpellName(Language),
                VengefulRetreat_SpellName(Language),

                Shear_SpellName(Language),
                SoulCleave_SpellName(Language),
                ThrowGlaive_SpellName(Language),
                Torment_SpellName(Language),
                BulkExtraction_SpellName(Language),
                ImmolationAura_SpellName(Language),
                Felblade_SpellName(Language),
                FelDevastation_SpellName(Language),
                FieryBrand_SpellName(Language),
                Fracture_SpellName(Language),
                SoulBarrier_SpellName(Language),
                SoulCarver_SpellName(Language),
                SpiritBomb_SpellName(Language),
            };
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

            Debug = GetCheckBox("Debug:") == true;
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
            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());

            if (ItemTimer.IsRunning && ItemTimer.ElapsedMilliseconds > 300000) ItemTimer.Reset();
            #endregion

            #region SpellQueueWindow
            if (Aimsharp.CustomFunction("GetSpellQueueWindow") != Aimsharp.Latency)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Setting SQW to: " + Aimsharp.Latency, Color.Purple);
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

            if (Aimsharp.IsCustomCodeOn("SigilofMisery") && Aimsharp.SpellCooldown(SigilOfMisery_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("SigilofChains") && Aimsharp.SpellCooldown(SigilOfChains_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            if (Aimsharp.IsCustomCodeOn("SigilofSilence") && Aimsharp.SpellCooldown(SigilOfSilence_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            if (Aimsharp.IsCustomCodeOn("ElysianDecree") && Aimsharp.SpellCooldown(ElysianDecree_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            if (Aimsharp.IsCustomCodeOn("InfernalStrike") && Aimsharp.SpellCooldown(InfernalStrike_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            if (Aimsharp.IsCustomCodeOn("QueueMetamorphosis") && Aimsharp.SpellCooldown(Metamorphosis_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                if (Aimsharp.CanCast(Disrupt_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Disrupt_SpellName(Language), true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast(Disrupt_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Disrupt_SpellName(Language), true);
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

            //Auto Darkness
            if (Aimsharp.CanCast(Darkness_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Darkness @ HP%"))
                {
                    Aimsharp.Cast(Darkness_SpellName(Language));
                    return true;
                }
            }

            //Auto Demon Spikes
            if (Aimsharp.CanCast(DemonSpikes_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Demon Spikes @ HP%"))
                {
                    Aimsharp.Cast(DemonSpikes_SpellName(Language));
                    return true;
                }
            }
            #endregion

            #region Queues
            //Queues
            //Queue Chaos Nova
            bool ChaosNova = Aimsharp.IsCustomCodeOn("ChaosNova");
            if (ChaosNova && Aimsharp.SpellCooldown(ChaosNova_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Chaos Nova queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ChaosNovaOff");
                return true;
            }

            if (ChaosNova && CanCastCheck(ChaosNova_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Chaos Nova through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(ChaosNova_SpellName(Language));
                return true;
            }
            //Queue Fel Eruption
            bool FelEruption = Aimsharp.IsCustomCodeOn("FelEruption");
            if (FelEruption && Aimsharp.SpellCooldown(FelEruption_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fel Eruption queue toggle", Color.Purple);
                }
                Aimsharp.Cast("FelEruptionOff");
                return true;
            }

            if (FelEruption && CanCastCheck(FelEruption_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fel Eruption through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(FelEruption_SpellName(Language));
                return true;
            }
            //Queue Darkness
            bool Darkness = Aimsharp.IsCustomCodeOn("QueueDarkness");
            if (Darkness && Aimsharp.SpellCooldown(Darkness_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Darkness queue toggle", Color.Purple);
                }
                Aimsharp.Cast("DarknessOff");
                return true;
            }

            if (Darkness && CanCastCheck(Darkness_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Darkness through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Darkness_SpellName(Language));
                return true;
            }
            //Queue Imprison
            bool Imprison = Aimsharp.IsCustomCodeOn("ImprisonMO");
            if (Imprison && Aimsharp.SpellCooldown(Imprison_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Imprison queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ImprisonOff");
                return true;
            }

            if (Imprison && CanCastCheck(Imprison_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Imprison through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ImprisonMO");
                return true;
            }
            //Queue Sigil
            string SigilsCast = GetDropDown("Sigils Cast:");
            bool SigilofMisery = Aimsharp.IsCustomCodeOn("SigilofMisery");
            if (Aimsharp.SpellCooldown(SigilOfMisery_SpellName(Language)) - Aimsharp.GCD() > 2000 && SigilofMisery)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Death and Decay Queue", Color.Purple);
                }
                Aimsharp.Cast("SigilofMiseryOff");
                return true;
            }
            if (SigilofMisery && CanCastCheck(SigilOfMisery_SpellName(Language), "player", false, true))
            {
                switch (SigilsCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Misery - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SigilOfMisery_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Misery - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofMiseryP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Misery - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofMiseryC");
                        return true;
                }
            }
            bool SigilofChains = Aimsharp.IsCustomCodeOn("SigilofChains");
            if (Aimsharp.SpellCooldown(SigilOfChains_SpellName(Language)) - Aimsharp.GCD() > 2000 && SigilofChains)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Death and Decay Queue", Color.Purple);
                }
                Aimsharp.Cast("SigilofChainsOff");
                return true;
            }
            if (SigilofChains && CanCastCheck(SigilOfChains_SpellName(Language), "player", false, true))
            {
                switch (SigilsCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Chains - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SigilOfChains_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Chains - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofChainsP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Chains - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofChainsC");
                        return true;
                }
            }
            bool SigilofSilence = Aimsharp.IsCustomCodeOn("SigilofSilence");
            if (Aimsharp.SpellCooldown(SigilOfSilence_SpellName(Language)) - Aimsharp.GCD() > 2000 && SigilofSilence)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Death and Decay Queue", Color.Purple);
                }
                Aimsharp.Cast("SigilofSilenceOff");
                return true;
            }
            if (SigilofSilence && CanCastCheck(SigilOfSilence_SpellName(Language), "player", false, true))
            {
                switch (SigilsCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Silence - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SigilOfSilence_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Silence - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofSilenceP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Silence - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofSilenceC");
                        return true;
                }
            }
            //Queue Metamorphosis
            bool Metamorphosis = Aimsharp.IsCustomCodeOn("QueueMetamorphosis");
            string MetamorphosisCast = GetDropDown("Metamorphosis Cast:");
            if (Metamorphosis && Aimsharp.SpellCooldown(Metamorphosis_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Metamorphosis queue toggle", Color.Purple);
                }
                Aimsharp.Cast("QueueMetamorphosisOff");
                return true;
            }
            if (Metamorphosis && CanCastCheck(Metamorphosis_SpellName(Language), "player", false, true))
            {
                switch (MetamorphosisCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Metamorphosis - " + MetamorphosisCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Metamorphosis_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Metamorphosis - " + MetamorphosisCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MetamorphosisP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Metamorphosis - " + MetamorphosisCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MetamorphosisC");
                        return true;
                }
            }
            //Queue Elysian Decree
            bool ElysianDecree = Aimsharp.IsCustomCodeOn("ElysianDecree");
            string ElysianDecreeCast = GetDropDown("Elysian Decree Cast:");
            if (Aimsharp.SpellCooldown(ElysianDecree_SpellName(Language)) - Aimsharp.GCD() > 2000 && ElysianDecree)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Elysian Decree Queue", Color.Purple);
                }
                Aimsharp.Cast("ElysianDecreeOff");
                return true;
            }
            if (ElysianDecree && CanCastCheck(ElysianDecree_SpellName(Language), "player", false, true))
            {
                switch (ElysianDecreeCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Elysian Decree - " + ElysianDecreeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(ElysianDecree_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Elysian Decree - " + ElysianDecreeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ElysianDecreeP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Elysian Decree - " + ElysianDecreeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ElysianDecreeC");
                        return true;
                }
            }
            //Queue Infernal Strike
            bool InfernalStrike = Aimsharp.IsCustomCodeOn("InfernalStrike");
            string InfernalStrikeCast = GetDropDown("Infernal Strike Cast:");
            if (Aimsharp.SpellCooldown(InfernalStrike_SpellName(Language)) - Aimsharp.GCD() > 2000 && InfernalStrike)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Infernal Strike Queue", Color.Purple);
                }
                Aimsharp.Cast("InfernalStrikeOff");
                return true;
            }
            if (InfernalStrike && CanCastCheck(InfernalStrike_SpellName(Language), "player", false, true))
            {
                switch (InfernalStrikeCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Infernal Strike - " + InfernalStrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(InfernalStrike_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Infernal Strike - " + InfernalStrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("InfernalStrikeP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Infernal Strike - " + InfernalStrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("InfernalStrikeC");
                        return true;
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

            if (Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat && !Aimsharp.HasDebuff(Imprison_SpellName(Language), "target", true))
            {
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

                    if (SpellID1 == 3)
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

                    if ((SpellID1 == 28730 || SpellID1 == 25046 || SpellID1 == 50613 || SpellID1 == 69179 || SpellID1 == 80483 || SpellID1 == 129597) && CanCastCheck(ArcaneTorrent_SpellName(Language), "player", true, false))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Torrent - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ArcaneTorrent_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 58984 && CanCastCheck(Shadowmeld_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowmeld - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Shadowmeld_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - NoGCD
                    //Class Spells
                    //Instant [GCD FREE]
                    //Demon Spikes
                    if (SpellID1 == 203720 && CanCastCheck(DemonSpikes_SpellName(Language), "player", false, false))
                    {
                        Aimsharp.Cast(DemonSpikes_SpellName(Language), true);
                        return true;
                    }
                    //Disrupt
                    if (SpellID1 == 183752 && CanCastCheck(Disrupt_SpellName(Language), "target", true, false))
                    {
                        Aimsharp.Cast(Disrupt_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Cursor Spells
                    //Infernal Strike
                    if (SpellID1 == 189110 && CanCastCheck(InfernalStrike_SpellName(Language), "player", false, true))
                    {
                        switch (InfernalStrikeCast)
                        {
                            case "Manual":
                                return SpellCast(189110, InfernalStrike_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(189110, InfernalStrike_SpellName(Language), "player", "InfernalStrikeP");
                            case "Cursor":
                                return SpellCast(189110, InfernalStrike_SpellName(Language), "player", "InfernalStrikeC");
                        }
                    }
                    //Metamorphosis
                    if (SpellID1 == 187827 && CanCastCheck(Metamorphosis_SpellName(Language), "player", false, true))
                    {
                        switch (MetamorphosisCast)
                        {
                            case "Manual":
                                return SpellCast(187827, Metamorphosis_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(187827, Metamorphosis_SpellName(Language), "player", "MetamorphosisP");
                            case "Cursor":
                                return SpellCast(187827, Metamorphosis_SpellName(Language), "player", "MetamorphosisC");
                        }
                    }
                    //Elysian Decree
                    if (SpellID1 == 390163 && CanCastCheck(ElysianDecree_SpellName(Language), "player", false, true))
                    {
                        switch (ElysianDecreeCast)
                        {
                            case "Manual":
                                return SpellCast(390163, ElysianDecree_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(390163, ElysianDecree_SpellName(Language), "player", "ElysianDecreeP");
                            case "Cursor":
                                return SpellCast(390163, ElysianDecree_SpellName(Language), "player", "ElysianDecreeC");
                        }
                    }
                    //Sigil of Misery
                    if (SpellID1 == 389813 && CanCastCheck(SigilOfMisery_SpellName(Language), "player", false, true))
                    {
                        switch (SigilsCast)
                        {
                            case "Manual":
                                return SpellCast(389813, SigilOfMisery_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(389813, SigilOfMisery_SpellName(Language), "player", "SigilofMiseryP");
                            case "Cursor":
                                return SpellCast(389813, SigilOfMisery_SpellName(Language), "player", "SigilofMiseryC");
                        }
                    }
                    if (SpellID1 == 202140 && CanCastCheck(SigilOfMisery_SpellName(Language), "player", false, true))
                    {
                        switch (SigilsCast)
                        {
                            case "Manual":
                                return SpellCast(202140, SigilOfMisery_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(202140, SigilOfMisery_SpellName(Language), "player", "SigilofMiseryP");
                            case "Cursor":
                                return SpellCast(202140, SigilOfMisery_SpellName(Language), "player", "SigilofMiseryC");
                        }
                    }
                    if (SpellID1 == 207685 && CanCastCheck(SigilOfMisery_SpellName(Language), "player", false, true))
                    {
                        switch (SigilsCast)
                        {
                            case "Manual":
                                return SpellCast(207685, SigilOfMisery_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(207685, SigilOfMisery_SpellName(Language), "player", "SigilofMiseryP");
                            case "Cursor":
                                return SpellCast(207685, SigilOfMisery_SpellName(Language), "player", "SigilofMiseryC");
                        }
                    }
                    //Sigil of Chains
                    if (SpellID1 == 202138 && CanCastCheck(SigilOfChains_SpellName(Language), "player", false, true))
                    {
                        switch (SigilsCast)
                        {
                            case "Manual":
                                return SpellCast(202138, SigilOfChains_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(202138, SigilOfChains_SpellName(Language), "player", "SigilofChainsP");
                            case "Cursor":
                                return SpellCast(202138, SigilOfChains_SpellName(Language), "player", "SigilofChainsC");
                        }
                    }
                    if (SpellID1 == 207665 && CanCastCheck(SigilOfChains_SpellName(Language), "player", false, true))
                    {
                        switch (SigilsCast)
                        {
                            case "Manual":
                                return SpellCast(207665, SigilOfChains_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(207665, SigilOfChains_SpellName(Language), "player", "SigilofChainsP");
                            case "Cursor":
                                return SpellCast(207665, SigilOfChains_SpellName(Language), "player", "SigilofChainsC");
                        }
                    }
                    if (SpellID1 == 389807 && CanCastCheck(SigilOfChains_SpellName(Language), "player", false, true))
                    {
                        switch (SigilsCast)
                        {
                            case "Manual":
                                return SpellCast(389807, SigilOfChains_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(389807, SigilOfChains_SpellName(Language), "player", "SigilofChainsP");
                            case "Cursor":
                                return SpellCast(389807, SigilOfChains_SpellName(Language), "player", "SigilofChainsC");
                        }
                    }
                    //Sigil of Silence
                    if (SpellID1 == 202137 && CanCastCheck(SigilOfSilence_SpellName(Language), "player", false, true))
                    {
                        switch (SigilsCast)
                        {
                            case "Manual":
                                return SpellCast(202137, SigilOfSilence_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(202137, SigilOfSilence_SpellName(Language), "player", "SigilofSilenceP");
                            case "Cursor":
                                return SpellCast(202137, SigilOfSilence_SpellName(Language), "player", "SigilofSilenceC");
                        }
                    }
                    if (SpellID1 == 207682 && CanCastCheck(SigilOfSilence_SpellName(Language), "player", false, true))
                    {
                        switch (SigilsCast)
                        {
                            case "Manual":
                                return SpellCast(207682, SigilOfSilence_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(207682, SigilOfSilence_SpellName(Language), "player", "SigilofSilenceP");
                            case "Cursor":
                                return SpellCast(207682, SigilOfSilence_SpellName(Language), "player", "SigilofSilenceC");
                        }
                    }
                    if (SpellID1 == 389809 && CanCastCheck(SigilOfSilence_SpellName(Language), "player", false, true))
                    {
                        switch (SigilsCast)
                        {
                            case "Manual":
                                return SpellCast(389809, SigilOfSilence_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(389809, SigilOfSilence_SpellName(Language), "player", "SigilofSilenceP");
                            case "Cursor":
                                return SpellCast(389809, SigilOfSilence_SpellName(Language), "player", "SigilofSilenceC");
                        }
                    }
                    //Sigil of Flame
                    if (SpellID1 == 204596 && CanCastCheck(SigilOfFlame_SpellName(Language), "player", false, true))
                    {
                        switch (SigilsCast)
                        {
                            case "Manual":
                                return SpellCast(204596, SigilOfFlame_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(204596, SigilOfFlame_SpellName(Language), "player", "SigilofFlameP");
                            case "Cursor":
                                return SpellCast(204596, SigilOfFlame_SpellName(Language), "player", "SigilofFlameC");
                        }
                    }
                    if (SpellID1 == 204513 && CanCastCheck(SigilOfFlame_SpellName(Language), "player", false, true))
                    {
                        switch (SigilsCast)
                        {
                            case "Manual":
                                return SpellCast(204513, SigilOfFlame_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(204513, SigilOfFlame_SpellName(Language), "player", "SigilofFlameP");
                            case "Cursor":
                                return SpellCast(204513, SigilOfFlame_SpellName(Language), "player", "SigilofFlameC");
                        }
                    }
                    if (SpellID1 == 389810 && CanCastCheck(SigilOfFlame_SpellName(Language), "player", false, true))
                    {
                        switch (SigilsCast)
                        {
                            case "Manual":
                                return SpellCast(389810, SigilOfFlame_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(389810, SigilOfFlame_SpellName(Language), "player", "SigilofFlameP");
                            case "Cursor":
                                return SpellCast(389810, SigilOfFlame_SpellName(Language), "player", "SigilofFlameC");
                        }
                    }
                    #endregion

                    #region Demon Hunter General Spells
                    //Instant [GCD]
                    ///Player
                    if (SpellCast(179057, ChaosNova_SpellName(Language), "player")) return true;
                    if (SpellCast(278326, ConsumeMagic_SpellName(Language), "target")) return true;
                    if (SpellCast(196718, Darkness_SpellName(Language), "player")) return true;
                    if (SpellCast(258920, ImmolationAura_SpellName(Language), "player")) return true;
                    if (SpellCast(217832, Imprison_SpellName(Language), "target")) return true;
                    if (SpellCast(370965, TheHunt_SpellName(Language), "target")) return true;
                    if (SpellCast(198793, VengefulRetreat_SpellName(Language), "player")) return true;
                    #endregion

                    #region Vengeance Spells
                    if (SpellCast(203782, Shear_SpellName(Language), "target")) return true;
                    if (SpellCast(228477, SoulCleave_SpellName(Language), "target")) return true;
                    if (SpellCast(204157, ThrowGlaive_SpellName(Language), "player")) return true;
                    if (SpellCast(185245, Torment_SpellName(Language), "player")) return true;
                    if (SpellCast(320341, BulkExtraction_SpellName(Language), "target")) return true;
                    if (SpellCast(232893, Felblade_SpellName(Language), "target")) return true;
                    if (SpellCast(212084, FelDevastation_SpellName(Language), "player")) return true;
                    if (SpellCast(204021, FieryBrand_SpellName(Language), "target")) return true;
                    if (SpellCast(263642, Fracture_SpellName(Language), "target")) return true;
                    if (SpellCast(263648, SoulBarrier_SpellName(Language), "target")) return true;
                    if (SpellCast(207407, SoulCarver_SpellName(Language), "target")) return true;
                    if (SpellCast(247454, SpiritBomb_SpellName(Language), "target")) return true;
                    #endregion
                }

            }
            return false;
        }

        public override bool OutOfCombatTick()
        {
            #region Declarations
            int SpellID1 = Aimsharp.CustomFunction("HekiliID1");
            bool Debug = true; ;
            bool Moving = Aimsharp.PlayerIsMoving();
            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());

            if (HSTimer.IsRunning) HSTimer.Reset();
            if (ItemTimer.IsRunning && ItemTimer.ElapsedMilliseconds > 300000) ItemTimer.Reset();
            #endregion

            #region SpellQueueWindow
            if (Aimsharp.CustomFunction("GetSpellQueueWindow") != Aimsharp.Latency)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Setting SQW to: " + Aimsharp.Latency, Color.Purple);
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
            //Queues
            //Queues
            //Queue Chaos Nova
            bool ChaosNova = Aimsharp.IsCustomCodeOn("ChaosNova");
            if (ChaosNova && Aimsharp.SpellCooldown(ChaosNova_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Chaos Nova queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ChaosNovaOff");
                return true;
            }

            if (ChaosNova && CanCastCheck(ChaosNova_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Chaos Nova through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(ChaosNova_SpellName(Language));
                return true;
            }
            //Queue Fel Eruption
            bool FelEruption = Aimsharp.IsCustomCodeOn("FelEruption");
            if (FelEruption && Aimsharp.SpellCooldown(FelEruption_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fel Eruption queue toggle", Color.Purple);
                }
                Aimsharp.Cast("FelEruptionOff");
                return true;
            }

            if (FelEruption && CanCastCheck(FelEruption_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fel Eruption through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(FelEruption_SpellName(Language));
                return true;
            }
            //Queue Darkness
            bool Darkness = Aimsharp.IsCustomCodeOn("QueueDarkness");
            if (Darkness && Aimsharp.SpellCooldown(Darkness_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Darkness queue toggle", Color.Purple);
                }
                Aimsharp.Cast("DarknessOff");
                return true;
            }

            if (Darkness && CanCastCheck(Darkness_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Darkness through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Darkness_SpellName(Language));
                return true;
            }
            //Queue Imprison
            bool Imprison = Aimsharp.IsCustomCodeOn("ImprisonMO");
            if (Imprison && Aimsharp.SpellCooldown(Imprison_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Imprison queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ImprisonOff");
                return true;
            }

            if (Imprison && CanCastCheck(Imprison_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Imprison through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ImprisonMO");
                return true;
            }
            //Queue Sigil
            string SigilsCast = GetDropDown("Sigils Cast:");
            bool SigilofMisery = Aimsharp.IsCustomCodeOn("SigilofMisery");
            if (Aimsharp.SpellCooldown(SigilOfMisery_SpellName(Language)) - Aimsharp.GCD() > 2000 && SigilofMisery)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Death and Decay Queue", Color.Purple);
                }
                Aimsharp.Cast("SigilofMiseryOff");
                return true;
            }
            if (SigilofMisery && CanCastCheck(SigilOfMisery_SpellName(Language), "player", false, true))
            {
                switch (SigilsCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Misery - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SigilOfMisery_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Misery - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofMiseryP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Misery - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofMiseryC");
                        return true;
                }
            }
            bool SigilofChains = Aimsharp.IsCustomCodeOn("SigilofChains");
            if (Aimsharp.SpellCooldown(SigilOfChains_SpellName(Language)) - Aimsharp.GCD() > 2000 && SigilofChains)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Death and Decay Queue", Color.Purple);
                }
                Aimsharp.Cast("SigilofChainsOff");
                return true;
            }
            if (SigilofChains && CanCastCheck(SigilOfChains_SpellName(Language), "player", false, true))
            {
                switch (SigilsCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Chains - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SigilOfChains_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Chains - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofChainsP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Chains - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofChainsC");
                        return true;
                }
            }
            bool SigilofSilence = Aimsharp.IsCustomCodeOn("SigilofSilence");
            if (Aimsharp.SpellCooldown(SigilOfSilence_SpellName(Language)) - Aimsharp.GCD() > 2000 && SigilofSilence)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Death and Decay Queue", Color.Purple);
                }
                Aimsharp.Cast("SigilofSilenceOff");
                return true;
            }
            if (SigilofSilence && CanCastCheck(SigilOfSilence_SpellName(Language), "player", false, true))
            {
                switch (SigilsCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Silence - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SigilOfSilence_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Silence - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofSilenceP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Silence - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofSilenceC");
                        return true;
                }
            }
            //Queue Metamorphosis
            bool Metamorphosis = Aimsharp.IsCustomCodeOn("QueueMetamorphosis");
            string MetamorphosisCast = GetDropDown("Metamorphosis Cast:");
            if (Metamorphosis && Aimsharp.SpellCooldown(Metamorphosis_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Metamorphosis queue toggle", Color.Purple);
                }
                Aimsharp.Cast("QueueMetamorphosisOff");
                return true;
            }
            if (Metamorphosis && CanCastCheck(Metamorphosis_SpellName(Language), "player", false, true))
            {
                switch (MetamorphosisCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Metamorphosis - " + MetamorphosisCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Metamorphosis_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Metamorphosis - " + MetamorphosisCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MetamorphosisP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Metamorphosis - " + MetamorphosisCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MetamorphosisC");
                        return true;
                }
            }
            //Queue Elysian Decree
            bool ElysianDecree = Aimsharp.IsCustomCodeOn("ElysianDecree");
            string ElysianDecreeCast = GetDropDown("Elysian Decree Cast:");
            if (Aimsharp.SpellCooldown(ElysianDecree_SpellName(Language)) - Aimsharp.GCD() > 2000 && ElysianDecree)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Elysian Decree Queue", Color.Purple);
                }
                Aimsharp.Cast("ElysianDecreeOff");
                return true;
            }
            if (ElysianDecree && CanCastCheck(ElysianDecree_SpellName(Language), "player", false, true))
            {
                switch (ElysianDecreeCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Elysian Decree - " + ElysianDecreeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(ElysianDecree_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Elysian Decree - " + ElysianDecreeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ElysianDecreeP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Elysian Decree - " + ElysianDecreeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ElysianDecreeC");
                        return true;
                }
            }
            //Queue Infernal Strike
            bool InfernalStrike = Aimsharp.IsCustomCodeOn("InfernalStrike");
            string InfernalStrikeCast = GetDropDown("Infernal Strike Cast:");
            if (Aimsharp.SpellCooldown(InfernalStrike_SpellName(Language)) - Aimsharp.GCD() > 2000 && InfernalStrike)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Infernal Strike Queue", Color.Purple);
                }
                Aimsharp.Cast("InfernalStrikeOff");
                return true;
            }
            if (InfernalStrike && CanCastCheck(InfernalStrike_SpellName(Language), "player", false, true))
            {
                switch (InfernalStrikeCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Infernal Strike - " + InfernalStrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(InfernalStrike_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Infernal Strike - " + InfernalStrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("InfernalStrikeP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Infernal Strike - " + InfernalStrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("InfernalStrikeC");
                        return true;
                }
            }
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive()&& TargetInCombat)
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