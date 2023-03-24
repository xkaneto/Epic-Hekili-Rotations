using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicDruidGuardianHekili : Rotation
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
        ///<summary>spell=325727</summary>
        private static string AdaptiveSwarm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Adaptive Swarm";
                case "Deutsch": return "Adaptiver Schwarm";
                case "Español": return "Enjambre adaptable";
                case "Français": return "Essaim adaptatif";
                case "Italiano": return "Sciame Adattivo";
                case "Português Brasileiro": return "Enxame Adaptável";
                case "Русский": return "Адаптивный рой";
                case "한국어": return "적응의 무리";
                case "简体中文": return "激变蜂群";
                default: return "Adaptive Swarm";
            }
        }

        ///<summary>spell=274738</summary>
        private static string AncestralCall_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ancestral Call";
                case "Deutsch": return "Ruf der Ahnen";
                case "Español": return "Llamada ancestral";
                case "Français": return "Appel ancestral";
                case "Italiano": return "Richiamo Ancestrale";
                case "Português Brasileiro": return "Chamado Ancestral";
                case "Русский": return "Призыв предков";
                case "한국어": return "고대의 부름";
                case "简体中文": return "先祖召唤";
                default: return "Ancestral Call";
            }
        }

        ///<summary>spell=260364</summary>
        private static string ArcanePulse_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Arcane Pulse";
                case "Deutsch": return "Arkaner Puls";
                case "Español": return "Pulso Arcano";
                case "Français": return "Impulsion arcanique";
                case "Italiano": return "Impulso Arcano";
                case "Português Brasileiro": return "Pulso Arcano";
                case "Русский": return "Чародейский импульс";
                case "한국어": return "비전 파동";
                case "简体中文": return "奥术脉冲";
                default: return "Arcane Pulse";
            }
        }

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

        ///<summary>spell=312411</summary>
        private static string BagOfTricks_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bag of Tricks";
                case "Deutsch": return "Trickkiste";
                case "Español": return "Bolsa de trucos";
                case "Français": return "Sac à malice";
                case "Italiano": return "Borsa di Trucchi";
                case "Português Brasileiro": return "Bolsa de Truques";
                case "Русский": return "Набор хитростей";
                case "한국어": return "비장의 묘수";
                case "简体中文": return "袋里乾坤";
                default: return "Bag of Tricks";
            }
        }

        ///<summary>spell=22812</summary>
        private static string Barkskin_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Barkskin";
                case "Deutsch": return "Baumrinde";
                case "Español": return "Piel de corteza";
                case "Français": return "Ecorce";
                case "Italiano": return "Pelledura";
                case "Português Brasileiro": return "Pele de Árvore";
                case "Русский": return "Дубовая кожа";
                case "한국어": return "나무 껍질";
                case "简体中文": return "树皮术";
                default: return "Barkskin";
            }
        }

        ///<summary>spell=120360</summary>
        private static string Barrage_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Barrage";
                case "Deutsch": return "Sperrfeuer";
                case "Español": return "Tromba";
                case "Français": return "Barrage";
                case "Italiano": return "Sbarramento";
                case "Português Brasileiro": return "Barragem";
                case "Русский": return "Шквал";
                case "한국어": return "탄막";
                case "简体中文": return "弹幕射击";
                default: return "Barrage";
            }
        }

        ///<summary>spell=5487</summary>
        private static string BearForm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bear Form";
                case "Deutsch": return "Bärengestalt";
                case "Español": return "Forma de oso";
                case "Français": return "Forme d'ours";
                case "Italiano": return "Forma d'Orso";
                case "Português Brasileiro": return "Forma de Urso";
                case "Русский": return "Облик медведя";
                case "한국어": return "곰 변신";
                case "简体中文": return "熊形态";
                default: return "Bear Form";
            }
        }

        ///<summary>spell=106951</summary>
        private static string Berserk_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Berserk";
                case "Deutsch": return "Berserker";
                case "Español": return "Rabia";
                case "Français": return "Berserk";
                case "Italiano": return "Berserk";
                case "Português Brasileiro": return "Berserk";
                case "Русский": return "Берсерк";
                case "한국어": return "광폭화";
                case "简体中文": return "狂暴";
                default: return "Berserk";
            }
        }

        ///<summary>spell=26297</summary>
        private static string Berserking_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Berserking";
                case "Deutsch": return "Berserker";
                case "Español": return "Rabiar";
                case "Français": return "Berserker";
                case "Italiano": return "Berserker";
                case "Português Brasileiro": return "Berserk";
                case "Русский": return "Берсерк";
                case "한국어": return "광폭화";
                case "简体中文": return "狂暴";
                default: return "Berserking";
            }
        }

        ///<summary>spell=33697</summary>
        private static string BloodFury_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blood Fury";
                case "Deutsch": return "Kochendes Blut";
                case "Español": return "Furia sangrienta";
                case "Français": return "Fureur sanguinaire";
                case "Italiano": return "Furia Sanguinaria";
                case "Português Brasileiro": return "Fúria Sangrenta";
                case "Русский": return "Кровавое неистовство";
                case "한국어": return "피의 격노";
                case "简体中文": return "血性狂怒";
                default: return "Blood Fury";
            }
        }

        ///<summary>spell=155835</summary>
        private static string BristlingFur_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bristling Fur";
                case "Deutsch": return "Gesträubtes Fell";
                case "Español": return "Pelaje erizado";
                case "Français": return "Poils hérissés";
                case "Italiano": return "Arruffamento Pelliccia";
                case "Português Brasileiro": return "Pelo Eriçado";
                case "Русский": return "Колючий мех";
                case "한국어": return "뻣뻣한 털";
                case "简体中文": return "鬃毛倒竖";
                default: return "Bristling Fur";
            }
        }

        ///<summary>spell=255654</summary>
        private static string BullRush_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bull Rush";
                case "Deutsch": return "Aufs Geweih nehmen";
                case "Español": return "Embestida astada";
                case "Français": return "Charge de taureau";
                case "Italiano": return "Scatto del Toro";
                case "Português Brasileiro": return "Investida do Touro";
                case "Русский": return "Бычий натиск";
                case "한국어": return "황소 돌진";
                case "简体中文": return "蛮牛冲撞";
                default: return "Bull Rush";
            }
        }

        ///<summary>spell=768</summary>
        private static string CatForm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Cat Form";
                case "Deutsch": return "Katzengestalt";
                case "Español": return "Forma felina";
                case "Français": return "Forme de félin";
                case "Italiano": return "Forma Felina";
                case "Português Brasileiro": return "Forma de Felino";
                case "Русский": return "Облик кошки";
                case "한국어": return "표범 변신";
                case "简体中文": return "猎豹形态";
                default: return "Cat Form";
            }
        }

        ///<summary>spell=323764</summary>
        private static string ConvokeTheSpirits_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Convoke the Spirits";
                case "Deutsch": return "Konvokation der Geister";
                case "Español": return "Convocar a los espíritus";
                case "Français": return "Convoquer les esprits";
                case "Italiano": return "Convocazione degli Spiriti";
                case "Português Brasileiro": return "Convocar Espíritos";
                case "Русский": return "Созыв духов";
                case "한국어": return "영혼 소집";
                case "简体中文": return "万灵之召";
                default: return "Convoke the Spirits";
            }
        }

        ///<summary>spell=172</summary>
        private static string Corruption_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Corruption";
                case "Deutsch": return "Verderbnis";
                case "Español": return "Corrupción";
                case "Français": return "Corruption";
                case "Italiano": return "Corruzione";
                case "Português Brasileiro": return "Corrupção";
                case "Русский": return "Порча";
                case "한국어": return "부패";
                case "简体中文": return "腐蚀术";
                default: return "Corruption";
            }
        }

        ///<summary>spell=339</summary>
        private static string EntanglingRoots_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Entangling Roots";
                case "Deutsch": return "Wucherwurzeln";
                case "Español": return "Raíces enredadoras";
                case "Français": return "Sarments";
                case "Italiano": return "Radici Avvolgenti";
                case "Português Brasileiro": return "Raízes Enredantes";
                case "Русский": return "Гнев деревьев";
                case "한국어": return "휘감는 뿌리";
                case "简体中文": return "纠缠根须";
                default: return "Entangling Roots";
            }
        }

        ///<summary>spell=20589</summary>
        private static string EscapeArtist_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Escape Artist";
                case "Deutsch": return "Entfesselungskünstler";
                case "Español": return "Artista del escape";
                case "Français": return "Maître de l’évasion";
                case "Italiano": return "Artista della Fuga";
                case "Português Brasileiro": return "Artista da Fuga";
                case "Русский": return "Мастер побега";
                case "한국어": return "탈출의 명수";
                case "简体中文": return "逃命专家";
                default: return "Escape Artist";
            }
        }

        ///<summary>spell=265221</summary>
        private static string Fireblood_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fireblood";
                case "Deutsch": return "Feuerblut";
                case "Español": return "Sangrardiente";
                case "Français": return "Sang de feu";
                case "Italiano": return "Sangue Infuocato";
                case "Português Brasileiro": return "Sangue de Fogo";
                case "Русский": return "Огненная кровь";
                case "한국어": return "불꽃피";
                case "简体中文": return "烈焰之血";
                default: return "Fireblood";
            }
        }

        ///<summary>spell=22842</summary>
        private static string FrenziedRegeneration_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Frenzied Regeneration";
                case "Deutsch": return "Rasende Regeneration";
                case "Español": return "Regeneración frenética";
                case "Français": return "Régénération frénétique";
                case "Italiano": return "Rigenerazione Furiosa";
                case "Português Brasileiro": return "Regeneração Frenética";
                case "Русский": return "Неистовое восстановление";
                case "한국어": return "광포한 재생력";
                case "简体中文": return "狂暴回复";
                default: return "Frenzied Regeneration";
            }
        }

        ///<summary>spell=335077</summary>
        private static string Frenzy_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Frenzy";
                case "Deutsch": return "Raserei";
                case "Español": return "Frenesí";
                case "Français": return "Frénésie";
                case "Italiano": return "Frenesia";
                case "Português Brasileiro": return "Frenesi";
                case "Русский": return "Бешенство";
                case "한국어": return "광기";
                case "简体中文": return "狂乱";
                default: return "Frenzy";
            }
        }

        ///<summary>spell=28880</summary>
        private static string GiftOfTheNaaru_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Gift of the Naaru";
                case "Deutsch": return "Gabe der Naaru";
                case "Español": return "Ofrenda de los naaru";
                case "Français": return "Don des Naaru";
                case "Italiano": return "Dono dei Naaru";
                case "Português Brasileiro": return "Dádiva dos Naarus";
                case "Русский": return "Дар наару";
                case "한국어": return "나루의 선물";
                case "简体中文": return "纳鲁的赐福";
                default: return "Gift of the Naaru";
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

        ///<summary>spell=319454</summary>
        private static string HeartOfTheWild_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Heart of the Wild";
                case "Deutsch": return "Herz der Wildnis";
                case "Español": return "Corazón de lo Salvaje";
                case "Français": return "Cœur de fauve";
                case "Italiano": return "Cuore Selvaggio";
                case "Português Brasileiro": return "Coração das Selvas";
                case "Русский": return "Сердце дикой природы";
                case "한국어": return "야생의 정수";
                case "简体中文": return "野性之心";
                default: return "Heart of the Wild";
            }
        }

        ///<summary>spell=2637</summary>
        private static string Hibernate_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Hibernate";
                case "Deutsch": return "Überwintern";
                case "Español": return "Hibernar";
                case "Français": return "Hibernation";
                case "Italiano": return "Letargo";
                case "Português Brasileiro": return "Hibernar";
                case "Русский": return "Спячка";
                case "한국어": return "겨울잠";
                case "简体中文": return "休眠";
                default: return "Hibernate";
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

        ///<summary>spell=99</summary>
        private static string IncapacitatingRoar_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Incapacitating Roar";
                case "Deutsch": return "Erschütterndes Gebrüll";
                case "Español": return "Rugido incapacitante";
                case "Français": return "Rugissement incapacitant";
                case "Italiano": return "Ruggito Inabilitante";
                case "Português Brasileiro": return "Rugido Incapacitante";
                case "Русский": return "Парализующий рык";
                case "한국어": return "행동 불가의 포효";
                case "简体中文": return "夺魂咆哮";
                default: return "Incapacitating Roar";
            }
        }

        ///<summary>spell=102558</summary>
        private static string Incarnation_GuardianOfUrsoc_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Incarnation: Guardian of Ursoc";
                case "Deutsch": return "Inkarnation: Wächter von Ursoc";
                case "Español": return "Encarnación: Guardián de Ursoc";
                case "Français": return "Incarnation : Gardien d’Ursoc";
                case "Italiano": return "Incarnazione: Guardiano di Ursoc";
                case "Português Brasileiro": return "Encarnação: Guardião de Ursoc";
                case "Русский": return "Воплощение: Страж Урсока";
                case "한국어": return "화신: 우르속의 수호자";
                case "简体中文": return "化身：乌索克的守护者";
                default: return "Incarnation: Guardian of Ursoc";
            }
        }

        ///<summary>spell=192081</summary>
        private static string Ironfur_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ironfur";
                case "Deutsch": return "Eisenfell";
                case "Español": return "Pelaje férreo";
                case "Français": return "Ferpoil";
                case "Italiano": return "Vello di Ferro";
                case "Português Brasileiro": return "Veloférreo";
                case "Русский": return "Железный мех";
                case "한국어": return "무쇠가죽";
                case "简体中文": return "铁鬃";
                default: return "Ironfur";
            }
        }

        ///<summary>spell=20271</summary>
        private static string Judgment_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Judgment";
                case "Deutsch": return "Richturteil";
                case "Español": return "Sentencia";
                case "Français": return "Jugement";
                case "Italiano": return "Giudizio";
                case "Português Brasileiro": return "Julgamento";
                case "Русский": return "Правосудие";
                case "한국어": return "심판";
                case "简体中文": return "审判";
                default: return "Judgment";
            }
        }

        ///<summary>spell=326434</summary>
        private static string KindredSpirits_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Kindred Spirits";
                case "Deutsch": return "Seelenverwandtschaft";
                case "Español": return "Almas gemelas";
                case "Français": return "Âmes sœurs";
                case "Italiano": return "Spiriti Affini";
                case "Português Brasileiro": return "Espíritos Afins";
                case "Русский": return "Родственные души";
                case "한국어": return "야생의 영혼";
                case "简体中文": return "志趣相投";
                default: return "Kindred Spirits";
            }
        }

        ///<summary>spell=255647</summary>
        private static string LightsJudgment_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Light's Judgment";
                case "Deutsch": return "Urteil des Lichts";
                case "Español": return "Sentencia de la Luz";
                case "Français": return "Jugement de la Lumière";
                case "Italiano": return "Giudizio della Luce";
                case "Português Brasileiro": return "Julgamento da Luz";
                case "Русский": return "Правосудие Света";
                case "한국어": return "빛의 심판";
                case "简体中文": return "圣光裁决者";
                default: return "Light's Judgment";
            }
        }

        ///<summary>spell=33917</summary>
        private static string Mangle_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mangle";
                case "Deutsch": return "Zerfleischen";
                case "Español": return "Destrozar";
                case "Français": return "Mutilation";
                case "Italiano": return "Dilaniamento";
                case "Português Brasileiro": return "Destroçar";
                case "Русский": return "Увечье";
                case "한국어": return "짓이기기";
                case "简体中文": return "裂伤";
                default: return "Mangle";
            }
        }

        ///<summary>spell=1126</summary>
        private static string MarkOfTheWild_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mark of the Wild";
                case "Deutsch": return "Mal der Wildnis";
                case "Español": return "Marca de lo Salvaje";
                case "Français": return "Marque du fauve";
                case "Italiano": return "Marchio Selvaggio";
                case "Português Brasileiro": return "Marca do Indomado";
                case "Русский": return "Знак дикой природы";
                case "한국어": return "야생의 징표";
                case "简体中文": return "野性印记";
                default: return "Mark of the Wild";
            }
        }

        ///<summary>spell=102359</summary>
        private static string MassEntanglement_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mass Entanglement";
                case "Deutsch": return "Massenumschlingung";
                case "Español": return "Enredo masivo";
                case "Français": return "Enchevêtrement de masse";
                case "Italiano": return "Intrappolamento di Massa";
                case "Português Brasileiro": return "Embaraço em Massa";
                case "Русский": return "Массовое оплетение";
                case "한국어": return "대규모 휘감기";
                case "简体中文": return "群体缠绕";
                default: return "Mass Entanglement";
            }
        }

        ///<summary>spell=6807</summary>
        private static string Maul_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Maul";
                case "Deutsch": return "Zermalmen";
                case "Español": return "Magullar";
                case "Français": return "Mutiler";
                case "Italiano": return "Zampata";
                case "Português Brasileiro": return "Espancar";
                case "Русский": return "Трепка";
                case "한국어": return "후려갈기기";
                case "简体中文": return "重殴";
                default: return "Maul";
            }
        }

        ///<summary>spell=5211</summary>
        private static string MightyBash_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mighty Bash";
                case "Deutsch": return "Mächtiger Hieb";
                case "Español": return "Azote poderoso";
                case "Français": return "Rossée puissante";
                case "Italiano": return "Urto Vigoroso";
                case "Português Brasileiro": return "Trombada Poderosa";
                case "Русский": return "Мощное оглушение";
                case "한국어": return "거센 강타";
                case "简体中文": return "蛮力猛击";
                default: return "Mighty Bash";
            }
        }

        ///<summary>spell=8921</summary>
        private static string Moonfire_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Moonfire";
                case "Deutsch": return "Mondfeuer";
                case "Español": return "Fuego lunar";
                case "Français": return "Éclat lunaire";
                case "Italiano": return "Fuoco Lunare";
                case "Português Brasileiro": return "Fogo Lunar";
                case "Русский": return "Лунный огонь";
                case "한국어": return "달빛섬광";
                case "简体中文": return "月火术";
                default: return "Moonfire";
            }
        }

        ///<summary>spell=24858</summary>
        private static string MoonkinForm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Moonkin Form";
                case "Deutsch": return "Mondkingestalt";
                case "Español": return "Forma de lechúcico lunar";
                case "Français": return "Forme de sélénien";
                case "Italiano": return "Forma di Lunagufo";
                case "Português Brasileiro": return "Forma de Luniscante";
                case "Русский": return "Облик лунного совуха";
                case "한국어": return "달빛야수 변신";
                case "简体中文": return "枭兽形态";
                default: return "Moonkin Form";
            }
        }

        ///<summary>spell=124974</summary>
        private static string NaturesVigil_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Nature's Vigil";
                case "Deutsch": return "Wache der Natur";
                case "Español": return "Vigilia de la Naturaleza";
                case "Français": return "Veille de la nature";
                case "Italiano": return "Veglia della Natura";
                case "Português Brasileiro": return "Vigília da Natureza";
                case "Русский": return "Природная чуткость";
                case "한국어": return "자연의 경계";
                case "简体中文": return "自然的守护";
                default: return "Nature's Vigil";
            }
        }

        ///<summary>spell=115078</summary>
        private static string Paralysis_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Paralysis";
                case "Deutsch": return "Paralyse";
                case "Español": return "Parálisis";
                case "Français": return "Paralysie";
                case "Italiano": return "Paralisi";
                case "Português Brasileiro": return "Paralisia";
                case "Русский": return "Паралич";
                case "한국어": return "마비";
                case "简体中文": return "分筋错骨";
                default: return "Paralysis";
            }
        }

        ///<summary>spell=80313</summary>
        private static string Pulverize_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Pulverize";
                case "Deutsch": return "Pulverisieren";
                case "Español": return "Pulverizar";
                case "Français": return "Pulvérisation";
                case "Italiano": return "Polverizzazione";
                case "Português Brasileiro": return "Pulverizar";
                case "Русский": return "Раздавить";
                case "한국어": return "파쇄";
                case "简体中文": return "粉碎";
                default: return "Pulverize";
            }
        }

        ///<summary>spell=200851</summary>
        private static string RageOfTheSleeper_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rage of the Sleeper";
                case "Deutsch": return "Zorn des Schläfers";
                case "Español": return "Ira del durmiente";
                case "Français": return "Rage du dormeur";
                case "Italiano": return "Rabbia del Dormiente";
                case "Português Brasileiro": return "Fúria do Adormecido";
                case "Русский": return "Ярость Спящего";
                case "한국어": return "잠자는 자의 분노";
                case "简体中文": return "沉睡者之怒";
                default: return "Rage of the Sleeper";
            }
        }

        ///<summary>spell=1822</summary>
        private static string Rake_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rake";
                case "Deutsch": return "Krallenhieb";
                case "Español": return "Arañazo";
                case "Français": return "Griffure";
                case "Italiano": return "Graffio";
                case "Português Brasileiro": return "Estraçalhar";
                case "Русский": return "Глубокая рана";
                case "한국어": return "갈퀴 발톱";
                case "简体中文": return "斜掠";
                default: return "Rake";
            }
        }

        ///<summary>spell=323546</summary>
        private static string RavenousFrenzy_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ravenous Frenzy";
                case "Deutsch": return "Unersättliche Raserei";
                case "Español": return "Frenesí voraz";
                case "Français": return "Frénésie vorace";
                case "Italiano": return "Frenesia Vorace";
                case "Português Brasileiro": return "Frenesi Voraz";
                case "Русский": return "Прожорливое бешенство";
                case "한국어": return "굶주린 광란";
                case "简体中文": return "饕餮狂乱";
                default: return "Ravenous Frenzy";
            }
        }

        ///<summary>spell=20484</summary>
        private static string Rebirth_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rebirth";
                case "Deutsch": return "Wiedergeburt";
                case "Español": return "Renacer";
                case "Français": return "Renaissance";
                case "Italiano": return "Pronto Ritorno";
                case "Português Brasileiro": return "Renascimento";
                case "Русский": return "Возрождение";
                case "한국어": return "환생";
                case "简体中文": return "复生";
                default: return "Rebirth";
            }
        }

        ///<summary>spell=8936</summary>
        private static string Regrowth_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Regrowth";
                case "Deutsch": return "Nachwachsen";
                case "Español": return "Recrecimiento";
                case "Français": return "Rétablissement";
                case "Italiano": return "Ricrescita";
                case "Português Brasileiro": return "Recrescimento";
                case "Русский": return "Восстановление";
                case "한국어": return "재생";
                case "简体中文": return "愈合";
                default: return "Regrowth";
            }
        }

        ///<summary>spell=774</summary>
        private static string Rejuvenation_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rejuvenation";
                case "Deutsch": return "Verjüngung";
                case "Español": return "Rejuvenecimiento";
                case "Français": return "Récupération";
                case "Italiano": return "Rinvigorimento";
                case "Português Brasileiro": return "Rejuvenescer";
                case "Русский": return "Омоложение";
                case "한국어": return "회복";
                case "简体中文": return "回春术";
                default: return "Rejuvenation";
            }
        }

        ///<summary>spell=2782</summary>
        private static string RemoveCorruption_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Remove Corruption";
                case "Deutsch": return "Verderbnis entfernen";
                case "Español": return "Eliminar corrupción";
                case "Français": return "Délivrance de la corruption";
                case "Italiano": return "Rimozione Corruzione";
                case "Português Brasileiro": return "Remover Corrupção";
                case "Русский": return "Снятие порчи";
                case "한국어": return "해제";
                case "简体中文": return "清除腐蚀";
                default: return "Remove Corruption";
            }
        }

        ///<summary>spell=108238</summary>
        private static string Renewal_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Renewal";
                case "Deutsch": return "Erneuerung";
                case "Español": return "Renovación";
                case "Français": return "Renouveau";
                case "Italiano": return "Rinnovo Istantaneo";
                case "Português Brasileiro": return "Renovação";
                case "Русский": return "Обновление";
                case "한국어": return "소생";
                case "简体中文": return "甘霖";
                default: return "Renewal";
            }
        }

        ///<summary>spell=1079</summary>
        private static string Rip_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rip";
                case "Deutsch": return "Zerfetzen";
                case "Español": return "Destripar";
                case "Français": return "Déchirure";
                case "Italiano": return "Squarcio";
                case "Português Brasileiro": return "Rasgar";
                case "Русский": return "Разорвать";
                case "한국어": return "도려내기";
                case "简体中文": return "割裂";
                default: return "Rip";
            }
        }

        ///<summary>spell=69041</summary>
        private static string RocketBarrage_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rocket Barrage";
                case "Deutsch": return "Raketenbeschuss";
                case "Español": return "Tromba de cohetes";
                case "Français": return "Barrage de fusées";
                case "Italiano": return "Raffica di Razzi";
                case "Português Brasileiro": return "Barragem de Foguetes";
                case "Русский": return "Ракетный обстрел";
                case "한국어": return "로켓 연발탄";
                case "简体中文": return "火箭弹幕";
                default: return "Rocket Barrage";
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

        ///<summary>spell=106839</summary>
        private static string SkullBash_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Skull Bash";
                case "Deutsch": return "Schädelstoß";
                case "Español": return "Testarazo";
                case "Français": return "Coup de crâne";
                case "Italiano": return "Craniata";
                case "Português Brasileiro": return "Esmagar Crânio";
                case "Русский": return "Лобовая атака";
                case "한국어": return "두개골 강타";
                case "简体中文": return "迎头痛击";
                default: return "Skull Bash";
            }
        }

        ///<summary>spell=2908</summary>
        private static string Soothe_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Soothe";
                case "Deutsch": return "Besänftigen";
                case "Español": return "Calmar";
                case "Français": return "Apaiser";
                case "Italiano": return "Pacificazione";
                case "Português Brasileiro": return "Confortar";
                case "Русский": return "Умиротворение";
                case "한국어": return "달래기";
                case "简体中文": return "安抚";
                default: return "Soothe";
            }
        }

        ///<summary>item=171267</summary>
        private static string SpiritualHealingPotion_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Spiritual Healing Potion";
                case "Deutsch": return "Spiritueller Heiltrank";
                case "Español": return "Poción de sanación espiritual";
                case "Français": return "Potion de soins spirituels";
                case "Italiano": return "Pozione di Cura Spirituale";
                case "Português Brasileiro": return "Poção de Cura Espiritual";
                case "Русский": return "Духовное зелье исцеления";
                case "한국어": return "영적인 치유 물약";
                case "简体中文": return "灵魂治疗药水";
                default: return "Spiritual Healing Potion";
            }
        }

        ///<summary>spell=106898</summary>
        private static string StampedingRoar_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Stampeding Roar";
                case "Deutsch": return "Anstachelndes Gebrüll";
                case "Español": return "Rugido de estampida";
                case "Français": return "Ruée rugissante";
                case "Italiano": return "Ruggito Impetuoso";
                case "Português Brasileiro": return "Estouro da Manada";
                case "Русский": return "Тревожный рев";
                case "한국어": return "쇄도의 포효";
                case "简体中文": return "狂奔怒吼";
                default: return "Stampeding Roar";
            }
        }

        ///<summary>spell=197628</summary>
        private static string Starfire_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Starfire";
                case "Deutsch": return "Sternenfeuer";
                case "Español": return "Fuego estelar";
                case "Français": return "Feu stellaire";
                case "Italiano": return "Fuoco Stellare";
                case "Português Brasileiro": return "Fogo Estelar";
                case "Русский": return "Звездный огонь";
                case "한국어": return "별빛섬광";
                case "简体中文": return "星火术";
                default: return "Starfire";
            }
        }

        ///<summary>spell=78674</summary>
        private static string Starsurge_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Starsurge";
                case "Deutsch": return "Sternensog";
                case "Español": return "Oleada de estrellas";
                case "Français": return "Éruption stellaire";
                case "Italiano": return "Cometa Arcana";
                case "Português Brasileiro": return "Surto Estelar";
                case "Русский": return "Звездный поток";
                case "한국어": return "별빛쇄도";
                case "简体中文": return "星涌术";
                default: return "Starsurge";
            }
        }

        ///<summary>spell=20594</summary>
        private static string Stoneform_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Stoneform";
                case "Deutsch": return "Steingestalt";
                case "Español": return "Forma de piedra";
                case "Français": return "Forme de pierre";
                case "Italiano": return "Forma di Pietra";
                case "Português Brasileiro": return "Forma de Pedra";
                case "Русский": return "Каменная форма";
                case "한국어": return "석화";
                case "简体中文": return "石像形态";
                default: return "Stoneform";
            }
        }

        ///<summary>spell=93402</summary>
        private static string Sunfire_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sunfire";
                case "Deutsch": return "Sonnenfeuer";
                case "Español": return "Fuego solar";
                case "Français": return "Éclat solaire";
                case "Italiano": return "Fuoco Solare";
                case "Português Brasileiro": return "Fogo Solar";
                case "Русский": return "Солнечный огонь";
                case "한국어": return "태양섬광";
                case "简体中文": return "阳炎术";
                default: return "Sunfire";
            }
        }

        ///<summary>spell=61336</summary>
        private static string SurvivalInstincts_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Survival Instincts";
                case "Deutsch": return "Überlebensinstinkte";
                case "Español": return "Instintos de supervivencia";
                case "Français": return "Instincts de survie";
                case "Italiano": return "Istinto di Sopravvivenza";
                case "Português Brasileiro": return "Instintos de Sobrevivência";
                case "Русский": return "Инстинкты выживания";
                case "한국어": return "생존 본능";
                case "简体中文": return "生存本能";
                default: return "Survival Instincts";
            }
        }

        ///<summary>spell=18562</summary>
        private static string Swiftmend_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Swiftmend";
                case "Deutsch": return "Rasche Heilung";
                case "Español": return "Alivio presto";
                case "Français": return "Prompte guérison";
                case "Italiano": return "Guarigione Immediata";
                case "Português Brasileiro": return "Recomposição Rápida";
                case "Русский": return "Быстрое восстановление";
                case "한국어": return "신속한 치유";
                case "简体中文": return "迅捷治愈";
                default: return "Swiftmend";
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

        ///<summary>spell=77758</summary>
        private static string Thrash_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Thrash";
                case "Deutsch": return "Hauen";
                case "Español": return "Vapulear";
                case "Français": return "Rosser";
                case "Italiano": return "Falciata";
                case "Português Brasileiro": return "Surra";
                case "Русский": return "Взбучка";
                case "한국어": return "난타";
                case "简体中文": return "痛击";
                default: return "Thrash";
            }
        }

        ///<summary>spell=61391</summary>
        private static string Typhoon_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Typhoon";
                case "Deutsch": return "Taifun";
                case "Español": return "Tifón";
                case "Français": return "Typhon";
                case "Italiano": return "Tifone";
                case "Português Brasileiro": return "Tufão";
                case "Русский": return "Тайфун";
                case "한국어": return "태풍";
                case "简体中文": return "台风";
                default: return "Typhoon";
            }
        }

        ///<summary>spell=102793</summary>
        private static string UrsolsVortex_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ursol's Vortex";
                case "Deutsch": return "Ursols Vortex";
                case "Español": return "Vórtice de Ursol";
                case "Français": return "Vortex d’Ursol";
                case "Italiano": return "Vortice di Ursol";
                case "Português Brasileiro": return "Vórtice de Ursol";
                case "Русский": return "Вихрь Урсола";
                case "한국어": return "우르솔의 회오리";
                case "简体中文": return "乌索尔旋风";
                default: return "Ursol's Vortex";
            }
        }

        ///<summary>spell=20549</summary>
        private static string WarStomp_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "War Stomp";
                case "Deutsch": return "Kriegsdonner";
                case "Español": return "Pisotón de guerra";
                case "Français": return "Choc martial";
                case "Italiano": return "Zoccolo di Guerra";
                case "Português Brasileiro": return "Pisada de Guerra";
                case "Русский": return "Громовая поступь";
                case "한국어": return "전투 발구르기";
                case "简体中文": return "战争践踏";
                default: return "War Stomp";
            }
        }

        ///<summary>spell=48438</summary>
        private static string WildGrowth_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Wild Growth";
                case "Deutsch": return "Wildwuchs";
                case "Español": return "Crecimiento salvaje";
                case "Français": return "Croissance sauvage";
                case "Italiano": return "Crescita Rigogliosa";
                case "Português Brasileiro": return "Crescimento Silvestre";
                case "Русский": return "Буйный рост";
                case "한국어": return "급속 성장";
                case "简体中文": return "野性成长";
                default: return "Wild Growth";
            }
        }

        ///<summary>spell=7744</summary>
        private static string WillOfTheForsaken_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Will of the Forsaken";
                case "Deutsch": return "Wille der Verlassenen";
                case "Español": return "Voluntad de los Renegados";
                case "Français": return "Volonté des Réprouvés";
                case "Italiano": return "Volontà dei Reietti";
                case "Português Brasileiro": return "Determinação dos Renegados";
                case "Русский": return "Воля Отрекшихся";
                case "한국어": return "포세이큰의 의지";
                case "简体中文": return "被遗忘者的意志";
                default: return "Will of the Forsaken";
            }
        }

        ///<summary>spell=59752</summary>
        private static string WillToSurvive_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Will to Survive";
                case "Deutsch": return "Überlebenswille";
                case "Español": return "Lucha por la supervivencia";
                case "Français": return "Volonté de survie";
                case "Italiano": return "Volontà di Sopravvivenza";
                case "Português Brasileiro": return "Desejo de Sobreviver";
                case "Русский": return "Воля к жизни";
                case "한국어": return "삶의 의지";
                case "简体中文": return "生存意志";
                default: return "Will to Survive";
            }
        }

        ///<summary>spell=190984</summary>
        private static string Wrath_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Wrath";
                case "Deutsch": return "Zorn";
                case "Español": return "Cólera";
                case "Français": return "Colère";
                case "Italiano": return "Ira Silvana";
                case "Português Brasileiro": return "Ira";
                case "Русский": return "Гнев";
                case "한국어": return "천벌";
                case "简体中文": return "愤怒";
                default: return "Wrath";
            }
        }
        #endregion

        bool DebugMode;
        bool EnableDefensives;

        private static string FiveLetters;
        Stopwatch HSTimer = new Stopwatch();

        private static List<string> MacroCommands = new List<string>
        {
            "IncapacitatingRoar",
            "MassEntanglement",
            "MightyBash",
            "NoCycle",
            "NoDecurse",
            "NoInterrupts",
            "QueueTyphoon",
            "RebirthMO",
            "SaveDefensiveCooldowns",
            "StampedingRoar",
            "UrsolsVortex",
        };

        private List<string> m_RaceList = new List<string> { "human", "dwarf", "nightelf", "gnome", "draenei", "pandaren", "orc", "scourge", "tauren", "troll", "bloodelf", "goblin", "worgen", "voidelf", "lightforgeddraenei", "highmountaintauren", "nightborne", "zandalaritroll", "magharorc", "kultiran", "darkirondwarf", "vulpera", "mechagnome" };
        private List<string> m_CastingList = new List<string> { "Manual", "Cursor", "Player" };

        private static List<string> BuffsList = new List<string>();

        private static List<string> DebuffsList = new List<string>();

        private static List<string> SpellsList = new List<string>();

        List<int> SpecialUnitList = new List<int> { 176581, 176920, 178008, 168326, 168969, 175861, };

        List<int> InstanceIDList = new List<int>
        {
            2291, 2287, 2290, 2289, 2284, 2285, 2286, 2293, 1663, 1664, 1665, 1666, 1667, 1668, 1669, 1674, 1675, 1676, 1677, 1678, 1679, 1680, 1683, 1684, 1685, 1686, 1687, 1692, 1693, 1694, 1695, 1697, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999, 2000, 2001, 2002, 2003, 2004, 2441, 2450
        };

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

        public Dictionary<string, int> PartyDict = new Dictionary<string, int>() { };

        private bool SpellCast(int HekiliID, string SpellName, string target, string MacroName = "")
        {
            if (MacroName == "")
            {
                if (Aimsharp.CustomFunction("HekiliID1") == HekiliID && Aimsharp.CanCast(SpellName, target))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting " + SpellName + " - " + HekiliID, Color.Purple);
                    }
                    Aimsharp.Cast(SpellName);
                    return true;
                }
            }
            if (MacroName != "")
            {
                if (Aimsharp.CustomFunction("HekiliID1") == HekiliID && Aimsharp.CanCast(SpellName, target))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Macro " + MacroName + " - " + HekiliID, Color.Purple);
                    }
                    Aimsharp.Cast(MacroName);
                    return true;
                }
            }
            return false;
        }

        private int UnitDebuffParalysis(string unit)
        {
            if (Aimsharp.HasDebuff(Paralysis_SpellName(Language), unit, true))
                return Aimsharp.DebuffRemaining(Paralysis_SpellName(Language), unit, true);
            if (Aimsharp.HasDebuff(Paralysis_SpellName(Language), unit, false))
                return Aimsharp.DebuffRemaining(Paralysis_SpellName(Language), unit, false);

            return 0;
        }

        private bool TargetAlive()
        {
            if (Aimsharp.CustomFunction("UnitIsDead") == 2)
                return true;

            return false;
        }

        private void AddCovenantSkills()
        {
            switch (Aimsharp.CovenantID())
            {
                case 1: //Kyrian
                    Spellbook.Add(KindredSpirits_SpellName(Language));
                    break;
                case 2: //Venthyr
                    Spellbook.Add(RavenousFrenzy_SpellName(Language));
                    break;
                case 3: //Night Fae
                    Spellbook.Add(ConvokeTheSpirits_SpellName(Language));
                    break;
                case 4: //Necrolord
                    Spellbook.Add(AdaptiveSwarm_SpellName(Language));
                    break;
                default:
                    Spellbook.Add(KindredSpirits_SpellName(Language));
                    Spellbook.Add(RavenousFrenzy_SpellName(Language));
                    Spellbook.Add(ConvokeTheSpirits_SpellName(Language));
                    Spellbook.Add(AdaptiveSwarm_SpellName(Language));
                    break;
            }
        }

        private bool Barkskin()
        {
            Aimsharp.Cast(Barkskin_SpellName(Language));
            return true;
        }

        private bool RageoftheSleeper()
        {
            Aimsharp.Cast(RageOfTheSleeper_SpellName(Language), true);
            return true;
        }

        private bool Ironfur()
        {
            Aimsharp.Cast(Ironfur_SpellName(Language));
            return true;
        }

        private bool Regrowth()
        {
            Aimsharp.Cast(Regrowth_SpellName(Language));
            return true;
        }

        private bool MoonfireMO()
        {
            Aimsharp.Cast("MoonFireMO");
            return true;
        }

        private bool FrenziedRegeneration()
        {
            Aimsharp.Cast(FrenziedRegeneration_SpellName(Language));
            return true;
        }

        private bool SurvivalInstincts()
        {
            Aimsharp.Cast(SurvivalInstincts_SpellName(Language), true);
            return true;
        }

        private bool Renewal()
        {
            Aimsharp.Cast(Renewal_SpellName(Language));
            return true;
        }


        private void initCustomFunctions()
        {
            CustomFunctions.Add("GetSpellQueueWindow", "local sqw = GetCVar(\"SpellQueueWindow\"); if sqw ~= nil then return tonumber(sqw); end return 0");

            CustomFunctions.Add("HekiliID1", "local loading, finished = IsAddOnLoaded(\"Hekili\")\nif loading == true and finished == true then\n\tlocal id=Hekili.DisplayPool.Primary.Recommendations[1].actionID\n\tif id ~= nil then\n\t\tif id<0 then\n\t\t\tlocal spell = Hekili.Class.abilities[id]\n\t\t\tif spell ~= nil and spell.item ~= nil then\n\t\t\t\tid=spell.item\n\t\t\t\tlocal topTrinketLink = GetInventoryItemLink(\"player\",13)\n\t\t\t\tlocal bottomTrinketLink = GetInventoryItemLink(\"player\",14)\n\t\t\t\tlocal weaponLink = GetInventoryItemLink(\"player\",16)\n\t\t\t\tif topTrinketLink  ~= nil then\n\t\t\t\t\tlocal trinketid = GetItemInfoInstant(topTrinketLink)\n\t\t\t\t\tif trinketid ~= nil then\n\t\t\t\t\t\tif trinketid == id then\n\t\t\t\t\t\t\treturn 1\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif bottomTrinketLink ~= nil then\n\t\t\t\t\tlocal trinketid = GetItemInfoInstant(bottomTrinketLink)\n\t\t\t\t\tif trinketid ~= nil then\n\t\t\t\t\t\tif trinketid == id then\n\t\t\t\t\t\t\treturn 2\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif weaponLink ~= nil then\n\t\t\t\t\tlocal weaponid = GetItemInfoInstant(weaponLink)\n\t\t\t\t\tif weaponid ~= nil then\n\t\t\t\t\t\tif weaponid == id then\n\t\t\t\t\t\t\treturn 3\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\tend\n\t\tend\n\t\treturn id\n\tend\nend\nreturn 0");

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("HekiliEnemies", "if Hekili.State.active_enemies ~= nil and Hekili.State.active_enemies > 0 then return Hekili.State.active_enemies end return 0");

            CustomFunctions.Add("HekiliWait", "if HekiliDisplayPrimary.Recommendations[1].wait ~= nil and HekiliDisplayPrimary.Recommendations[1].wait * 1000 > 0 then return math.floor(HekiliDisplayPrimary.Recommendations[1].wait * 1000) end return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("CursePoisonCheck", "local y=0; " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"player\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +1; end end " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +2; end end " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +4; end end " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +8; end end " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +16; end end " +
                "return y");

            CustomFunctions.Add("UnitIsDead", "if UnitIsDead(\"mouseover\") ~= nil and UnitIsDead(\"mouseover\") == true then return 1 end; if UnitIsDead(\"mouseover\") ~= nil and UnitIsDead(\"mouseover\") == false then return 2 end; return 0");

            CustomFunctions.Add("MoonfireDebuffCheck", "local moonfirecheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and IsSpellInRange('Moonfire','mouseover') == 1 then moonfirecheck = moonfirecheck +1  for y = 1, 40 do local name,_,_,_,_,_,source  = UnitDebuff('mouseover', y) if name == 'Moonfire' then moonfirecheck = moonfirecheck + 2 end end return moonfirecheck end return 0");

            CustomFunctions.Add("EnrageBuffCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Soothe','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType  = UnitBuff('mouseover', y) if debuffType == '' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("EnrageBuffCheckTarget", "local markcheck = 0; if UnitExists('target') and UnitIsDead('target') ~= true and UnitAffectingCombat('target') and IsSpellInRange('Soothe','target') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType  = UnitBuff('target', y) if debuffType == '' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("ThreatStatus", "if (UnitDetailedThreatSituation(\"player\", \"target\"))\nthen\nreturn 1;\nend\nreturn 0;");

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

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");

        }

        public override void LoadSettings()
        {
            Settings.Add(new Setting("Misc"));
            Settings.Add(new Setting("Debug Mode: ", false));
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
            Settings.Add(new Setting("Ingame World Latency:", 1, 200, 50));
            Settings.Add(new Setting("General"));
            Settings.Add(new Setting("Race:", m_RaceList, "nightelf"));
            Settings.Add(new Setting("Use DPS Potion:", false));
            Settings.Add(new Setting("Potion name:", "Potion of Spectral Intellect"));
            Settings.Add(new Setting("Auto Start Combat:", true));
            Settings.Add(new Setting("Mark of the Wild Out of Combat:", true));
            Settings.Add(new Setting("Soothe Target:", true));
            Settings.Add(new Setting("Soothe Mouseover:", true));
            Settings.Add(new Setting("Vortex Cast:", m_CastingList, "Cursor"));
            Settings.Add(new Setting("Healing and Mitigation"));
            Settings.Add(new Setting("Healthstone HP %", 0, 100, 25));
            Settings.Add(new Setting("Enable Below Defensives:", false));
            Settings.Add(new Setting("Barkskin HP %", 0, 100, 85));
            Settings.Add(new Setting("Bristling Fur HP %", 0, 100, 90));
            Settings.Add(new Setting("Frenzied Regeneration HP %", 0, 100, 70));
            Settings.Add(new Setting("Ironfur HP %", 0, 100, 10));
            Settings.Add(new Setting("Renewal HP %", 0, 100, 65));
            Settings.Add(new Setting("Regrowth HP %", 0, 100, 10));
            Settings.Add(new Setting("Regrowth OOC to HP %", 0, 100, 80));
            Settings.Add(new Setting("Survival Instincts HP %", 0, 100, 45));
            Settings.Add(new Setting("Kicks/Interrupts"));
            Settings.Add(new Setting("Randomize Kicks:", false));
            Settings.Add(new Setting("Kick at milliseconds remaining", 50, 1500, 500));
            Settings.Add(new Setting("Kick channels after milliseconds", 50, 1500, 500));
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

            DebugMode = GetCheckBox("Debug Mode: ");
            EnableDefensives = GetCheckBox("Enable Below Defensives:");

            Aimsharp.PrintMessage("Epic PVE - Druid Guardian", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/de/guide/classes/druid/guardian/overview-pve-tank", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " SaveDefensiveCooldowns - Saves defensive Cooldowns", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " IncapacitatingRoar - Casts Incapacitating Roar @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " MightyBash - Casts Mighty Bash @ Target on the next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " MassEntanglement - Casts Mass Entanglement @ Target on the next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " QueueTyphoon - Casts Typhoon next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " RebirthMO - Casts Rebirth @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " StampedingRoar - Casts Stampeding Roar next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " UrsolsVortex - Casts Ursol's Vortex on Cursor @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);

            Language = GetDropDown("Game Client Language");

            #region Racial Spells
            if (GetDropDown("Race:") == "draenei")
            {
                Spellbook.Add(GiftOfTheNaaru_SpellName(Language)); //28880
            }

            if (GetDropDown("Race:") == "dwarf")
            {
                Spellbook.Add(Stoneform_SpellName(Language)); //20594
            }

            if (GetDropDown("Race:") == "gnome")
            {
                Spellbook.Add(EscapeArtist_SpellName(Language)); //20589
            }

            if (GetDropDown("Race:") == "human")
            {
                Spellbook.Add(WillToSurvive_SpellName(Language)); //59752
            }

            if (GetDropDown("Race:") == "lightforgeddraenei")
            {
                Spellbook.Add(LightsJudgment_SpellName(Language)); //255647
            }

            if (GetDropDown("Race:") == "darkirondwarf")
            {
                Spellbook.Add(Fireblood_SpellName(Language)); //265221
            }

            if (GetDropDown("Race:") == "goblin")
            {
                Spellbook.Add(RocketBarrage_SpellName(Language)); //69041
            }

            if (GetDropDown("Race:") == "tauren")
            {
                Spellbook.Add(WarStomp_SpellName(Language)); //20549
            }

            if (GetDropDown("Race:") == "troll")
            {
                Spellbook.Add(Berserking_SpellName(Language)); //26297
            }

            if (GetDropDown("Race:") == "scourge")
            {
                Spellbook.Add(WillOfTheForsaken_SpellName(Language)); //7744
            }

            if (GetDropDown("Race:") == "nightborne")
            {
                Spellbook.Add(ArcanePulse_SpellName(Language)); //260364
            }

            if (GetDropDown("Race:") == "highmountaintauren")
            {
                Spellbook.Add(BullRush_SpellName(Language)); //255654
            }

            if (GetDropDown("Race:") == "magharorc")
            {
                Spellbook.Add(AncestralCall_SpellName(Language)); //274738
            }

            if (GetDropDown("Race:") == "vulpera")
            {
                Spellbook.Add(BagOfTricks_SpellName(Language)); //312411
            }

            if (GetDropDown("Race:") == "orc")
            {
                Spellbook.Add(BloodFury_SpellName(Language)); //20572, 33702, 33697
            }

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
            BuffsList = new List<string>
            {
                Barkskin_SpellName(Language),
                BearForm_SpellName(Language),
                FrenziedRegeneration_SpellName(Language),
                Ironfur_SpellName(Language),
                MoonkinForm_SpellName(Language),
                Regrowth_SpellName(Language),
                Rejuvenation_SpellName(Language),
                Renewal_SpellName(Language),
                SurvivalInstincts_SpellName(Language),
                Swiftmend_SpellName(Language),
                WildGrowth_SpellName(Language),
            };

            DebuffsList = new List<string>
            {
                Hibernate_SpellName(Language),
                Imprison_SpellName(Language),
                Moonfire_SpellName(Language),
                Sunfire_SpellName(Language),
            };

            SpellsList = new List<string>
            {
                Barkskin_SpellName(Language),
                Berserk_SpellName(Language),
                BearForm_SpellName(Language),
                BristlingFur_SpellName(Language),
                CatForm_SpellName(Language),
                EntanglingRoots_SpellName(Language),
                FrenziedRegeneration_SpellName(Language),
                HeartOfTheWild_SpellName(Language),
                Hibernate_SpellName(Language),
                IncapacitatingRoar_SpellName(Language),
                Incarnation_GuardianOfUrsoc_SpellName(Language),
                Ironfur_SpellName(Language),
                Mangle_SpellName(Language),
                Maul_SpellName(Language),
                MarkOfTheWild_SpellName(Language),
                MightyBash_SpellName(Language),
                Moonfire_SpellName(Language),
                MoonkinForm_SpellName(Language),
                NaturesVigil_SpellName(Language),
                Pulverize_SpellName(Language),
                Rake_SpellName(Language),
                RavenousFrenzy_SpellName(Language),
                RageOfTheSleeper_SpellName(Language),
                Rebirth_SpellName(Language),
                Regrowth_SpellName(Language),
                Rejuvenation_SpellName(Language),
                RemoveCorruption_SpellName(Language),
                Renewal_SpellName(Language),
                Rip_SpellName(Language),
                SkullBash_SpellName(Language),
                Soothe_SpellName(Language),
                Sunfire_SpellName(Language),
                SurvivalInstincts_SpellName(Language),
                StampedingRoar_SpellName(Language),
                Starfire_SpellName(Language),
                Starsurge_SpellName(Language),
                Swiftmend_SpellName(Language),
                Swipe_SpellName(Language),
                Thrash_SpellName(Language),
                Typhoon_SpellName(Language),
                UrsolsVortex_SpellName(Language),
                WildGrowth_SpellName(Language),
                Wrath_SpellName(Language),
            };
            #endregion

            initCustomFunctions();
            AddCovenantSkills();

            SpellsList.ForEach(spell => Spellbook.Add(spell));
            BuffsList.ForEach(buff => Buffs.Add(buff));
            DebuffsList.ForEach(debuff => Debuffs.Add(debuff));
            MacroCommands.ForEach(macroCommand => CustomCommands.Add(macroCommand));


            Items.Add(GetString("Potion name:"));
            Items.Add(Healthstone_SpellName(Language));

            Macros.Add("MoonFireMO", "/cast [@mouseover,exists,harm,nodead] " + Moonfire_SpellName(Language));
            Macros.Add("RebirthMO", "/cast [@mouseover,help] " + Rebirth_SpellName(Language));
            Macros.Add("SootheMO", "/cast [@mouseover] " + Soothe_SpellName(Language));
            Macros.Add("VortexP", "/cast [@player] " + UrsolsVortex_SpellName(Language));
            Macros.Add("VortexC", "/cast [@cursor] " + UrsolsVortex_SpellName(Language));

            //potions
            Macros.Add("hstone", "/use " + Healthstone_SpellName(Language));
            Macros.Add("DPSPot", "/use " + GetString("Potion name:"));

            //Auto Target
            Macros.Add("TargetEnemy", "/targetenemy");

            //Trinket
            Macros.Add("TopTrinket", "/use 13");
            Macros.Add("BotTrinket", "/use 14");

            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");
            Macros.Add("RC_FOC", "/cast [@focus] " + RemoveCorruption_SpellName(Language));

            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + Aimsharp.Latency);

            Macros.Add("MightyBashOff", "/" + FiveLetters + " MightyBash");
            Macros.Add("MassEntanglementOff", "/" + FiveLetters + " MassEntanglement");
            Macros.Add("UrsolsVortexOff", "/" + FiveLetters + " UrsolsVortex");
            Macros.Add("IncapacitatingRoarOff", "/" + FiveLetters + " IncapacitatingRoar");
            Macros.Add("TyphoonOff", "/" + FiveLetters + " QueueTyphoon");
            Macros.Add("RebirthOff", "/" + FiveLetters + " Rebirth");
            Macros.Add("StampedingRoarOff", "/" + FiveLetters + " StampedingRoar");

        }

        public override bool CombatTick()
        {

            int hekiliSpell = Aimsharp.CustomFunction("HekiliID1");

            int PlayerHealth = Aimsharp.Health("player");
            bool Fighting = Aimsharp.Range("target") <= 30 && Aimsharp.TargetIsEnemy();
            string PotionName = GetString("Potion name:");
            bool UsePotion = GetCheckBox("Use DPS Potion:");
            int GCD = Aimsharp.GCD();
            bool Moving = Aimsharp.PlayerIsMoving();
            int EnemiesInMelee = Aimsharp.EnemiesInMelee();
            bool WeAreinParty = Aimsharp.InParty();
            bool MeleeRange = Aimsharp.Range("target") <= 6;

            int Enemies = Aimsharp.CustomFunction("HekiliEnemies");
            int TargetingGroup = Aimsharp.CustomFunction("GroupTargets");
            int Wait = Aimsharp.CustomFunction("HekiliWait");

            bool Enemy = Aimsharp.TargetIsEnemy();
            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());

            bool IsInterruptable = Aimsharp.IsInterruptable("target");
            int CastingRemaining = Aimsharp.CastingRemaining("target");
            int CastingElapsed = Aimsharp.CastingElapsed("target");
            bool IsChanneling = Aimsharp.IsChanneling("target");
            int KickValue = GetSlider("Kick at milliseconds remaining");
            int KickChannelsAfter = GetSlider("Kick channels after milliseconds");

            int DpsPotionCdRemaining = Aimsharp.ItemCooldown(PotionName);
            bool DpsPotionCdReady = DpsPotionCdRemaining <= 10;
            int RebirthCDRemaining = Aimsharp.SpellCooldown(Rebirth_SpellName(Language)) - GCD;
            bool RebirthCDReady = RebirthCDRemaining <= 10;

            // Custom commands
            bool SaveDefensiveCooldowns = Aimsharp.IsCustomCodeOn("SaveDefensiveCooldowns");
            bool NoInterrupts = Aimsharp.IsCustomCodeOn("NoInterrupts");
            bool NoCycle = Aimsharp.IsCustomCodeOn("NoCycle");
            bool NoDecurse = Aimsharp.IsCustomCodeOn("NoDecurse");
            bool MOSoothe = GetCheckBox("Soothe Mouseover:");
            bool TargetSoothe = GetCheckBox("Soothe Target:");

            int CursePoisonCheck = Aimsharp.CustomFunction("CursePoisonCheck");
            int EnrageBuffMO = Aimsharp.CustomFunction("EnrageBuffCheckMouseover");
            int EnrageBuffTarget = Aimsharp.CustomFunction("EnrageBuffCheckTarget");

            //DefensiveCooldowns
            int CDIronfurRemains = Aimsharp.SpellCooldown(Ironfur_SpellName(Language));
            bool CDIronfurUp = CDIronfurRemains <= 0;
            int CDBarkskinRemains = Aimsharp.SpellCooldown(Barkskin_SpellName(Language));
            bool CDBarkskinUp = CDBarkskinRemains <= 0;
            int CDRenewalRemains = Aimsharp.SpellCooldown(Renewal_SpellName(Language));
            bool CDRenewalUp = CDRenewalRemains <= 0;
            int FrenziedRegenerationCharges = Aimsharp.SpellCharges(FrenziedRegeneration_SpellName(Language));
            bool FrenziedRegenerationChargesUp = FrenziedRegenerationCharges <= 2;

            #region Pause Checks
            if (Aimsharp.CustomFunction("IsTargeting") == 1)
            {
                return false;
            }

            if (Aimsharp.CastingID("player") > 0 || Aimsharp.IsChanneling("player"))
            {
                return false;
            }
            #endregion

            if (Aimsharp.HasDebuff(Hibernate_SpellName(Language), "target", true))
            {
                return false;
            }

            //potion and healthstone
            if (PlayerHealth < GetSlider("Healthstone HP %"))
            {
                if (Aimsharp.CanUseItem(Healthstone_SpellName(Language), false))
                {
                    if (!HSTimer.IsRunning)
                    {
                        HSTimer.Restart();
                    }
                    if (HSTimer.ElapsedMilliseconds < 1500)
                    {
                        Aimsharp.Cast("hstone", true);
                        return true;
                    }
                }
            }



            //Mouseovers
            if (Aimsharp.CustomFunction("MoonfireDebuffCheck") == 1 && Aimsharp.CanCast(Moonfire_SpellName(Language), "mouseover")) return MoonfireMO();

            //Soothe Mouseover
            if (Aimsharp.CanCast(Soothe_SpellName(Language), "mouseover", true, true))
            {
                if (MOSoothe && EnrageBuffMO == 3)
                {
                    Aimsharp.Cast("SootheMO");
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Soothe (Mouseover)", Color.Purple);
                    }
                    return true;
                }
            }

            //Soothe Target
            if (Aimsharp.CanCast(Soothe_SpellName(Language), "target", true, true))
            {
                if (TargetSoothe && EnrageBuffTarget == 3)
                {
                    Aimsharp.Cast(Soothe_SpellName(Language));
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Soothe (Target)", Color.Purple);
                    }
                    return true;
                }
            }

            #region Remove Corruption
            if (!NoDecurse && CursePoisonCheck > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != RemoveCorruption_SpellName(Language))
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

                int states = Aimsharp.CustomFunction("CursePoisonCheck");
                CleansePlayers target;

                int KickTimer = GetRandomNumber(200, 800);

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast(RemoveCorruption_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
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
                                Aimsharp.Cast("RC_FOC");
                                if (DebugMode)
                                {
                                    Aimsharp.PrintMessage("Remove Corruption @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            //Auto Soothe looks like this might needs the specific ids?
            //if(AutoSoothe && Aimsharp.CanCast("Soothe", "target") && Aimsharp.CustomFunction("EnrageCheck") != 0)
            //    return Soothe();

            //potion
            if (UsePotion && Aimsharp.CanUseItem(PotionName, false) && DpsPotionCdReady)
            {
                Aimsharp.Cast("DPSPot", true);
                return true;
            }

            //Auto taunt target if in a party
            if (Aimsharp.CanCast(RageOfTheSleeper_SpellName(Language), "target") && WeAreinParty && Aimsharp.CustomFunction("ThreatStatus") == 1)
                return RageoftheSleeper();

            //Defensives
            if (Aimsharp.CanCast(Regrowth_SpellName(Language), "player") && PlayerHealth < GetSlider("Regrowth HP %") && Fighting)
                return Regrowth();

            if (EnableDefensives == true && Aimsharp.CustomFunction("ThreatStatus") == 1 && Fighting)
            {
                if (Aimsharp.CanCast(Barkskin_SpellName(Language), "player") && PlayerHealth < GetSlider("Barkskin HP %") && CDBarkskinUp)
                {
                    return Barkskin();
                }
                if (Aimsharp.CanCast(Ironfur_SpellName(Language), "player") && PlayerHealth < GetSlider("Ironfur HP %") && !SaveDefensiveCooldowns && CDIronfurUp)
                {
                    return Ironfur();
                }

                if (Aimsharp.CanCast(FrenziedRegeneration_SpellName(Language), "player") && PlayerHealth < GetSlider("Frenzied Regeneration HP %") && !SaveDefensiveCooldowns && FrenziedRegenerationChargesUp)
                {
                    return FrenziedRegeneration();
                }
                if (Aimsharp.CanCast(SurvivalInstincts_SpellName(Language), "player") && PlayerHealth < GetSlider("Survival Instincts HP %") && !SaveDefensiveCooldowns)
                {
                    return SurvivalInstincts();
                }
                if (Aimsharp.CanCast(Renewal_SpellName(Language), "player") && PlayerHealth < GetSlider("Renewal HP %") && CDRenewalUp)
                    return Renewal();

                if (Aimsharp.CanCast(BristlingFur_SpellName(Language), "player") && PlayerHealth < GetSlider("Bristling Fur HP %"))
                {
                    return Barkskin();
                }
                else if (Aimsharp.CustomFunction("ThreatStatus") == 0)
                {
                    EnableDefensives = false;
                }
            }

            //Hekili Cycle
            if (!NoCycle && Aimsharp.CustomFunction("HekiliCycle") == 1 && Enemies > 1)
            {
                System.Threading.Thread.Sleep(50);
                Aimsharp.Cast("TargetEnemy");
                System.Threading.Thread.Sleep(50);
                return true;
            }
            // Keep Enemy target
            if (!NoCycle && (!Enemy || Enemy && !TargetAlive() || Enemy && !TargetInCombat) && (EnemiesInMelee > 0 || TargetingGroup > 0))
            {
                System.Threading.Thread.Sleep(50);
                Aimsharp.Cast("TargetEnemy");
                System.Threading.Thread.Sleep(50);
                return true;
            }

            #region Queues
            //Queue Mighty Bash
            bool MightyBash = Aimsharp.IsCustomCodeOn("MightyBash");
            if (MightyBash && Aimsharp.SpellCooldown(MightyBash_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Turning Off Mighty Bash queue toggle", Color.Purple);
                }
                Aimsharp.Cast("MightyBashOff");
                return true;
            }

            if (MightyBash && Aimsharp.CanCast(MightyBash_SpellName(Language), "target", true, true))
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Casting Mighty Bash through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(MightyBash_SpellName(Language));
                return true;
            }

            //Queue Mass Entanglement
            bool MassEntanglement = Aimsharp.IsCustomCodeOn("MassEntanglement");
            if (MassEntanglement && Aimsharp.SpellCooldown(MassEntanglement_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Turning Off Mass Entanglement queue toggle", Color.Purple);
                }
                Aimsharp.Cast("MassEntanglementOff");
                return true;
            }

            if (MassEntanglement && Aimsharp.CanCast(MassEntanglement_SpellName(Language), "target", true, true))
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Casting Mass Entanglement through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(MassEntanglement_SpellName(Language));
                return true;
            }

            //Queue Typhoon
            bool Typhoon = Aimsharp.IsCustomCodeOn("QueueTyphoon");
            if (Typhoon && Aimsharp.SpellCooldown(Typhoon_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Turning Off Typhoon queue toggle", Color.Purple);
                }
                Aimsharp.Cast("TyphoonOff");
                return true;
            }

            if (Typhoon && Aimsharp.CanCast(Typhoon_SpellName(Language), "player", true, true))
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Casting Typhoon through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Typhoon_SpellName(Language));
                return true;
            }

            //Queue Incapacitating Roar
            bool IncapacitatingRoar = Aimsharp.IsCustomCodeOn("IncapacitatingRoar");
            if (IncapacitatingRoar && Aimsharp.SpellCooldown(IncapacitatingRoar_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Turning Off Incapacitating Roar queue toggle", Color.Purple);
                }
                Aimsharp.Cast("IncapacitatingRoarOff");
                return true;
            }

            if (IncapacitatingRoar && Aimsharp.CanCast(IncapacitatingRoar_SpellName(Language), "target", true, true))
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Casting Incapacitating Roar through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(IncapacitatingRoar_SpellName(Language));
                return true;
            }

            //Queue Rebirth
            bool Rebirth = Aimsharp.IsCustomCodeOn("RebirthMO");
            if (Aimsharp.SpellCooldown(Rebirth_SpellName(Language)) - Aimsharp.GCD() > 2000 && Rebirth)
            {
                Aimsharp.Cast("RebirthOff");
                return true;
            }

            if (Rebirth && Aimsharp.CanCast(Rebirth_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("RebirthMO");
                return true;
            }

            //Queue Stampeding Roar
            bool StampedingRoar = Aimsharp.IsCustomCodeOn("StampedingRoar");
            if (Aimsharp.SpellCooldown(StampedingRoar_SpellName(Language)) - Aimsharp.GCD() > 2000 && Rebirth)
            {
                Aimsharp.Cast("StampedingRoarOff");
                return true;
            }

            if (Rebirth && Aimsharp.CanCast(StampedingRoar_SpellName(Language), "player", true, true))
            {
                Aimsharp.Cast(StampedingRoar_SpellName(Language));
                return true;
            }

            //Queue Vortex
            string VortexCast = GetDropDown("Vortex Cast:");
            bool UrsolsVortex = Aimsharp.IsCustomCodeOn("UrsolsVortex");
            if (Aimsharp.SpellCooldown(UrsolsVortex_SpellName(Language)) - Aimsharp.GCD() > 2000 && UrsolsVortex)
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Turning Off Ursol's Vortex Queue", Color.Purple);
                }
                Aimsharp.Cast("UrsolsVortexOff");
                return true;
            }
            if (UrsolsVortex && Aimsharp.CanCast(UrsolsVortex_SpellName(Language), "player", false, true))
            {
                switch (VortexCast)
                {
                    case "Manual":
                        if (DebugMode)
                        {
                            Aimsharp.PrintMessage("Casting Ursol's Vortex - " + VortexCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(UrsolsVortex_SpellName(Language));
                        return true;
                    case "Player":
                        if (DebugMode)
                        {
                            Aimsharp.PrintMessage("Casting Ursol's Vortex - " + VortexCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("VortexP");
                        return true;
                    case "Cursor":
                        if (DebugMode)
                        {
                            Aimsharp.PrintMessage("Casting Ursol's Vortex - " + VortexCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("VortexC");
                        return true;
                }
            }
            #endregion

            #region Interrupts
            if (!NoInterrupts)
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
                if (Aimsharp.CanCast(SkullBash_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (DebugMode)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(SkullBash_SpellName(Language), true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast(SkullBash_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (DebugMode)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(SkullBash_SpellName(Language), true);
                        return true;
                    }
                }
            }
            #endregion

            #region Trinkets
            if (hekiliSpell == 1 && Aimsharp.CanUseTrinket(0) && MeleeRange && Wait <= 200)
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Using Top Trinket", Color.Purple);
                }
                Aimsharp.Cast("TopTrinket");
                return true;
            }

            if (hekiliSpell == 2 && Aimsharp.CanUseTrinket(1) && MeleeRange)
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Using Bot Trinket", Color.Purple);
                }
                Aimsharp.Cast("BotTrinket");
                return true;
            }
            #endregion

            //hekili
            if (hekiliSpell != 0 && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat && Wait <= 200)
            {
                #region Racials
                if (hekiliSpell == 28880 && Aimsharp.CanCast(GiftOfTheNaaru_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Gift of the Naaru - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(GiftOfTheNaaru_SpellName(Language));
                    return true;
                }

                if (hekiliSpell == 20594 && Aimsharp.CanCast(Stoneform_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Stoneform - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(Stoneform_SpellName(Language));
                    return true;
                }

                if (hekiliSpell == 20589 && Aimsharp.CanCast(EscapeArtist_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Escape Artist - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(EscapeArtist_SpellName(Language));
                    return true;
                }

                if (hekiliSpell == 59752 && Aimsharp.CanCast(WillToSurvive_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Will to Survive - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(WillToSurvive_SpellName(Language));
                    return true;
                }

                if (hekiliSpell == 255647 && Aimsharp.CanCast(LightsJudgment_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Light's Judgment - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(LightsJudgment_SpellName(Language));
                    return true;
                }

                if (hekiliSpell == 265221 && Aimsharp.CanCast(Fireblood_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Fireblood - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(Fireblood_SpellName(Language));
                    return true;
                }

                if (hekiliSpell == 69041 && Aimsharp.CanCast(RocketBarrage_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Rocket Barrage - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(RocketBarrage_SpellName(Language));
                    return true;
                }

                if (hekiliSpell == 20549 && Aimsharp.CanCast(WarStomp_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting War Stomp - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(WarStomp_SpellName(Language));
                    return true;
                }

                if (hekiliSpell == 7744 && Aimsharp.CanCast(WillOfTheForsaken_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Will of the Forsaken - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(WillOfTheForsaken_SpellName(Language));
                    return true;
                }

                if (hekiliSpell == 260364 && Aimsharp.CanCast(ArcanePulse_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Arcane Pulse - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(ArcanePulse_SpellName(Language));
                    return true;
                }

                if (hekiliSpell == 255654 && Aimsharp.CanCast(BullRush_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Bull Rush - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(BullRush_SpellName(Language));
                    return true;
                }

                if (hekiliSpell == 312411 && Aimsharp.CanCast(BagOfTricks_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Bag of Tricks - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(BagOfTricks_SpellName(Language));
                    return true;
                }

                if ((hekiliSpell == 20572 || hekiliSpell == 33702 || hekiliSpell == 33697) && Aimsharp.CanCast(BloodFury_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Blood Fury - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(BloodFury_SpellName(Language));
                    return true;
                }


                if (hekiliSpell == 26297 && Aimsharp.CanCast(Berserking_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Berserking - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(Berserking_SpellName(Language));
                    return true;
                }

                if (hekiliSpell == 274738 && Aimsharp.CanCast(AncestralCall_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Ancestral Call - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(AncestralCall_SpellName(Language));
                    return true;
                }

                if ((hekiliSpell == 28730 || hekiliSpell == 25046 || hekiliSpell == 50613 || hekiliSpell == 69179 || hekiliSpell == 80483 || hekiliSpell == 129597) && Aimsharp.CanCast(ArcaneTorrent_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Arcane Torrent - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(ArcaneTorrent_SpellName(Language));
                    return true;
                }

                if (hekiliSpell == 58984 && Aimsharp.CanCast(Shadowmeld_SpellName(Language), "player", false, true))
                {
                    if (DebugMode)
                    {
                        Aimsharp.PrintMessage("Casting Shadowmeld - " + hekiliSpell, Color.Purple);
                    }
                    Aimsharp.Cast(Shadowmeld_SpellName(Language));
                    return true;
                }
                #endregion

                #region Normal Spells
                //Barkskin
                if (SpellCast(22812, Barkskin_SpellName(Language), "player")) return true;
                //Berserk
                if (SpellCast(50334, Berserk_SpellName(Language), "player")) return true;
                //BearForm
                if (SpellCast(5487, BearForm_SpellName(Language), "player")) return true;
                //BristlingFur
                if (SpellCast(155835, BristlingFur_SpellName(Language), "player")) return true;
                //CatForm
                if (SpellCast(768, CatForm_SpellName(Language), "player")) return true;
                //EntanglingRoots
                if (SpellCast(339, EntanglingRoots_SpellName(Language), "target")) return true;
                //FrenziedRegeneration
                if (SpellCast(22842, FrenziedRegeneration_SpellName(Language), "player")) return true;
                //HeartOfTheWild
                if (SpellCast(319454, HeartOfTheWild_SpellName(Language), "player")) return true;
                //Hibernate
                if (SpellCast(2637, Hibernate_SpellName(Language), "target")) return true;
                //IncapacitatingRoar
                if (SpellCast(99, IncapacitatingRoar_SpellName(Language), "target")) return true;
                //Incarnation_GuardianOfUrsoc
                if (SpellCast(102558, Incarnation_GuardianOfUrsoc_SpellName(Language), "player")) return true;
                //Ironfur
                if (SpellCast(192081, Ironfur_SpellName(Language), "player")) return true;
                //Mangle
                if (SpellCast(33917, Mangle_SpellName(Language), "target")) return true;
                //Maul
                if (SpellCast(6807, Maul_SpellName(Language), "target")) return true;
                //MarkOfTheWild
                if (SpellCast(1126, MarkOfTheWild_SpellName(Language), "player")) return true;
                //MightyBash
                if (SpellCast(5211, MightyBash_SpellName(Language), "target")) return true;
                //Moonfire
                if (SpellCast(8921, Moonfire_SpellName(Language), "target")) return true;
                //MoonkinForm
                if (SpellCast(24858, MoonkinForm_SpellName(Language), "player")) return true;
                //NaturesVigil
                if (SpellCast(124974, NaturesVigil_SpellName(Language), "player")) return true;
                //Pulverize
                if (SpellCast(80313, Pulverize_SpellName(Language), "player")) return true;
                //Rake
                if (SpellCast(1822, Rake_SpellName(Language), "target")) return true;
                //RavenousFrenzy
                if (SpellCast(323546, RavenousFrenzy_SpellName(Language), "player")) return true;
                //RageOfTheSleeper
                if (SpellCast(200851, RageOfTheSleeper_SpellName(Language), "player")) return true;
                //Rebirth
                if (SpellCast(20484, Rebirth_SpellName(Language), "target")) return true;
                //Regrowth
                if (SpellCast(8936, Regrowth_SpellName(Language), "player")) return true;
                //Rejuvenation
                if (SpellCast(774, Rejuvenation_SpellName(Language), "player")) return true;
                //RemoveCorruption
                if (SpellCast(2782, RemoveCorruption_SpellName(Language), "player")) return true;
                //Renewal
                if (SpellCast(108238, Renewal_SpellName(Language), "player")) return true;
                //Rip
                if (SpellCast(1079, Rip_SpellName(Language), "target")) return true;
                //SkullBash
                if (SpellCast(106839, SkullBash_SpellName(Language), "target")) return true;
                //Soothe
                if (SpellCast(2908, Soothe_SpellName(Language), "target")) return true;
                //Sunfire
                if (SpellCast(93402, Sunfire_SpellName(Language), "target")) return true;
                //SurvivalInstincts
                if (SpellCast(61336, SurvivalInstincts_SpellName(Language), "player")) return true;
                //StampedingRoar
                if (SpellCast(106898, StampedingRoar_SpellName(Language), "player")) return true;
                //Starfire
                if (SpellCast(197628, Starfire_SpellName(Language), "target")) return true;
                //Starsurge
                if (SpellCast(78674, Starsurge_SpellName(Language), "target")) return true;
                //Swiftmend
                if (SpellCast(18562, Swiftmend_SpellName(Language), "player")) return true;
                //Swipe
                if (SpellCast(213771, Swipe_SpellName(Language), "player")) return true;
                //Thrash
                if (SpellCast(77758, Thrash_SpellName(Language), "player")) return true;
                //Typhoon
                if (SpellCast(132469, Typhoon_SpellName(Language), "player")) return true;
                //UrsolsVortex
                if (VortexCast == "Manual") if (SpellCast(102793, UrsolsVortex_SpellName(Language), "player")) return true;
                if (VortexCast == "Player") if (SpellCast(102793, UrsolsVortex_SpellName(Language), "player", "VortexP")) return true;
                if (VortexCast == "Cursor") if (SpellCast(102793, UrsolsVortex_SpellName(Language), "player", "VortexC")) return true;
                //WildGrowth
                if (SpellCast(48438, WildGrowth_SpellName(Language), "player")) return true;
                //Wrath
                if (SpellCast(5176, Wrath_SpellName(Language), "target")) return true;

                //Covenant Spells or Not
                if (SpellCast(326434, KindredSpirits_SpellName(Language), "player")) return true;
                if (SpellCast(323546, RavenousFrenzy_SpellName(Language), "player")) return true;
                if (SpellCast(323764, ConvokeTheSpirits_SpellName(Language), "player")) return true;
                if (SpellCast(391528, ConvokeTheSpirits_SpellName(Language), "player")) return true;
                if (SpellCast(325727, AdaptiveSwarm_SpellName(Language), "player")) return true;
                if (SpellCast(391888, AdaptiveSwarm_SpellName(Language), "player")) return true;

                #endregion
            }
            return false;
        }

        public override bool OutOfCombatTick()
        {
            bool MOTWOOC = GetCheckBox("Mark of the Wild Out of Combat:");

            #region SpellQueueWindow
            if (Aimsharp.CustomFunction("GetSpellQueueWindow") != (Aimsharp.Latency))
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Setting SQW to: " + (Aimsharp.Latency), Color.Purple);
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

            if (HSTimer.IsRunning)
            {
                HSTimer.Reset();
            }

            #region Queues
            //Queue Mighty Bash
            bool MightyBash = Aimsharp.IsCustomCodeOn("MightyBash");
            if (MightyBash && Aimsharp.SpellCooldown(MightyBash_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Turning Off Mighty Bash queue toggle", Color.Purple);
                }
                Aimsharp.Cast("MightyBashOff");
                return true;
            }

            if (MightyBash && Aimsharp.CanCast(MightyBash_SpellName(Language), "target", true, true))
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Casting Mighty Bash through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(MightyBash_SpellName(Language));
                return true;
            }

            //Queue Mass Entanglement
            bool MassEntanglement = Aimsharp.IsCustomCodeOn("MassEntanglement");
            if (MassEntanglement && Aimsharp.SpellCooldown(MassEntanglement_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Turning Off Mass Entanglement queue toggle", Color.Purple);
                }
                Aimsharp.Cast("MassEntanglementOff");
                return true;
            }

            if (MassEntanglement && Aimsharp.CanCast(MassEntanglement_SpellName(Language), "target", true, true))
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Casting Mass Entanglement through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(MassEntanglement_SpellName(Language));
                return true;
            }

            //Queue Typhoon
            bool Typhoon = Aimsharp.IsCustomCodeOn("QueueTyphoon");
            if (Typhoon && Aimsharp.SpellCooldown(Typhoon_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Turning Off Typhoon queue toggle", Color.Purple);
                }
                Aimsharp.Cast("TyphoonOff");
                return true;
            }

            if (Typhoon && Aimsharp.CanCast(Typhoon_SpellName(Language), "player", true, true))
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Casting Typhoon through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Typhoon_SpellName(Language));
                return true;
            }

            //Queue Incapacitating Roar
            bool IncapacitatingRoar = Aimsharp.IsCustomCodeOn("IncapacitatingRoar");
            if (IncapacitatingRoar && Aimsharp.SpellCooldown(IncapacitatingRoar_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Turning Off Incapacitating Roar queue toggle", Color.Purple);
                }
                Aimsharp.Cast("IncapacitatingRoarOff");
                return true;
            }

            if (IncapacitatingRoar && Aimsharp.CanCast(IncapacitatingRoar_SpellName(Language), "target", true, true))
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Casting Incapacitating Roar through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(IncapacitatingRoar_SpellName(Language));
                return true;
            }

            //Queue Rebirth
            bool Rebirth = Aimsharp.IsCustomCodeOn("RebirthMO");
            if (Aimsharp.SpellCooldown(Rebirth_SpellName(Language)) - Aimsharp.GCD() > 2000 && Rebirth)
            {
                Aimsharp.Cast("RebirthOff");
                return true;
            }

            if (Rebirth && Aimsharp.CanCast(Rebirth_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("RebirthMO");
                return true;
            }

            //Queue Stampeding Roar
            bool StampedingRoar = Aimsharp.IsCustomCodeOn("StampedingRoar");
            if (Aimsharp.SpellCooldown(StampedingRoar_SpellName(Language)) - Aimsharp.GCD() > 2000 && Rebirth)
            {
                Aimsharp.Cast("StampedingRoarOff");
                return true;
            }

            if (Rebirth && Aimsharp.CanCast(StampedingRoar_SpellName(Language), "player", true, true))
            {
                Aimsharp.Cast(StampedingRoar_SpellName(Language));
                return true;
            }

            //Queue Vortex
            string VortexCast = GetDropDown("Vortex Cast:");
            bool UrsolsVortex = Aimsharp.IsCustomCodeOn("UrsolsVortex");
            if (Aimsharp.SpellCooldown(UrsolsVortex_SpellName(Language)) - Aimsharp.GCD() > 2000 && UrsolsVortex)
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Turning Off Ursol's Vortex Queue", Color.Purple);
                }
                Aimsharp.Cast("UrsolsVortexOff");
                return true;
            }
            if (UrsolsVortex && Aimsharp.CanCast(UrsolsVortex_SpellName(Language), "player", false, true))
            {
                switch (VortexCast)
                {
                    case "Manual":
                        if (DebugMode)
                        {
                            Aimsharp.PrintMessage("Casting Ursol's Vortex - " + VortexCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(UrsolsVortex_SpellName(Language));
                        return true;
                    case "Player":
                        if (DebugMode)
                        {
                            Aimsharp.PrintMessage("Casting Ursol's Vortex - " + VortexCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("VortexP");
                        return true;
                    case "Cursor":
                        if (DebugMode)
                        {
                            Aimsharp.PrintMessage("Casting Ursol's Vortex - " + VortexCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("VortexC");
                        return true;
                }
            }
            #endregion

            //Defensives
            if (Aimsharp.CanCast(Regrowth_SpellName(Language), "player") && Aimsharp.Health("player") < GetSlider("Regrowth OOC to HP %"))
                return Regrowth();

            if (MOTWOOC && !Aimsharp.HasBuff(MarkOfTheWild_SpellName(Language), "player", true) && !Aimsharp.HasBuff(MarkOfTheWild_SpellName(Language), "player", false)) if (SpellCast(1126, MarkOfTheWild_SpellName(Language), "player")) return true;

            //Auto Combat - Special thanks to Snoogens for this one
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 6 && UnitDebuffParalysis("target") == 0)
            {
                if (DebugMode)
                {
                    Aimsharp.PrintMessage("Starting Combat from Out of Combat", Color.Purple);
                }
                return CombatTick();
            }
            return false;
        }
    }
}