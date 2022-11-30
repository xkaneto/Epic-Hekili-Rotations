using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicDruidFeralHekili : Rotation
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
        ///<summary>spell=325733</summary>
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

        ///<summary>spell=2825</summary>
        private static string Bloodlust_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bloodlust";
                case "Deutsch": return "Kampfrausch";
                case "Español": return "Ansia de sangre";
                case "Français": return "Furie sanguinaire";
                case "Italiano": return "Brama di Sangue";
                case "Português Brasileiro": return "Sede de Sangue";
                case "Русский": return "Жажда крови";
                case "한국어": return "피의 욕망";
                case "简体中文": return "嗜血";
                default: return "Bloodlust";
            }
        }

        ///<summary>spell=202028</summary>
        private static string BrutalSlash_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Brutal Slash";
                case "Deutsch": return "Brutales Schlitzen";
                case "Español": return "Tajo brutal";
                case "Français": return "Entaille brutale";
                case "Italiano": return "Taglio Brutale";
                case "Português Brasileiro": return "Talho Brutal";
                case "Русский": return "Жестокий удар когтями";
                case "한국어": return "잔혹한 베기";
                case "简体中文": return "野蛮挥砍";
                default: return "Brutal Slash";
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

        ///<summary>spell=100</summary>
        private static string Charge_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Charge";
                case "Deutsch": return "Sturmangriff";
                case "Español": return "Cargar";
                case "Français": return "Charge";
                case "Italiano": return "Carica";
                case "Português Brasileiro": return "Investida";
                case "Русский": return "Рывок";
                case "한국어": return "돌진";
                case "简体中文": return "冲锋";
                default: return "Charge";
            }
        }

        ///<summary>spell=391528</summary>
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

        ///<summary>spell=1850</summary>
        private static string Dash_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dash";
                case "Deutsch": return "Spurt";
                case "Español": return "Carrerilla";
                case "Français": return "Célérité";
                case "Italiano": return "Slancio";
                case "Português Brasileiro": return "Arremetida";
                case "Русский": return "Порыв";
                case "한국어": return "질주";
                case "简体中文": return "急奔";
                default: return "Dash";
            }
        }

        ///<summary>item=102351</summary>
        private static string DrumsOfRage_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Drums of Rage";
                case "Deutsch": return "Trommeln des Zorns";
                case "Español": return "Tambores de ira";
                case "Français": return "Tambours de rage";
                case "Italiano": return "Tamburi della Rabbia";
                case "Português Brasileiro": return "Tambores da Raiva";
                case "Русский": return "Барабаны ярости";
                case "한국어": return "분노의 북";
                case "简体中文": return "暴怒之鼓";
                default: return "Drums of Rage";
            }
        }

        ///<summary>spell=326647</summary>
        private static string EmpowerBond_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Empower Bond";
                case "Deutsch": return "Verbindung ermächtigen";
                case "Español": return "Potenciar vínculo";
                case "Français": return "Renforcement de lien";
                case "Italiano": return "Vincolo Potenziato";
                case "Português Brasileiro": return "Potencializar Vínculo";
                case "Русский": return "Усиление связи";
                case "한국어": return "유대 강화";
                case "简体中文": return "增效羁绊";
                default: return "Empower Bond";
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

        ///<summary>spell=274837</summary>
        private static string FeralFrenzy_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Feral Frenzy";
                case "Deutsch": return "Wilde Raserei";
                case "Español": return "Frenesí feral";
                case "Français": return "Frénésie farouche";
                case "Italiano": return "Frenesia Ferina";
                case "Português Brasileiro": return "Frenesi Feral";
                case "Русский": return "Дикое бешенство";
                case "한국어": return "야성의 광기";
                case "简体中文": return "野性狂乱";
                default: return "Feral Frenzy";
            }
        }

        ///<summary>spell=22568</summary>
        private static string FerociousBite_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ferocious Bite";
                case "Deutsch": return "Wilder Biss";
                case "Español": return "Mordedura feroz";
                case "Français": return "Morsure féroce";
                case "Italiano": return "Morso Feroce";
                case "Português Brasileiro": return "Mordida Feroz";
                case "Русский": return "Свирепый укус";
                case "한국어": return "흉포한 이빨";
                case "简体中文": return "凶猛撕咬";
                default: return "Ferocious Bite";
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

        ///<summary>spell=32182</summary>
        private static string Heroism_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Heroism";
                case "Deutsch": return "Heldentum";
                case "Español": return "Heroísmo";
                case "Français": return "Héroïsme";
                case "Italiano": return "Eroismo";
                case "Português Brasileiro": return "Heroísmo";
                case "Русский": return "Героизм";
                case "한국어": return "영웅심";
                case "简体中文": return "英勇";
                default: return "Heroism";
            }
        }

        ///<summary>spell=102543</summary>
        private static string Incarnation_AvatarOfAshamane_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Incarnation: Avatar of Ashamane";
                case "Deutsch": return "Inkarnation: Avatar von Ashamane";
                case "Español": return "Encarnación: Avatar de Crinceniza";
                case "Français": return "Incarnation : avatar d’Ashamane";
                case "Italiano": return "Incarnazione: Avatar di Grigiomanto";
                case "Português Brasileiro": return "Encarnação: Avatar de Ashamane";
                case "Русский": return "Воплощение: аватара Пеплошкурой";
                case "한국어": return "화신: 아샤메인의 화신";
                case "简体中文": return "化身：阿莎曼之灵";
                default: return "Incarnation: Avatar of Ashamane";
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

        ///<summary>spell=22570</summary>
        private static string Maim_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Maim";
                case "Deutsch": return "Zerfleddern";
                case "Español": return "Amputar";
                case "Français": return "Estropier";
                case "Italiano": return "Menomazione";
                case "Português Brasileiro": return "Mutilar";
                case "Русский": return "Калечение";
                case "한국어": return "무력화";
                case "简体中文": return "割碎";
                default: return "Maim";
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

        ///<summary>spell=69369</summary>
        private static string PredatorySwiftness_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Predatory Swiftness";
                case "Deutsch": return "Schnelligkeit des Raubtiers";
                case "Español": return "Presteza de depredador";
                case "Français": return "Rapidité du prédateur";
                case "Italiano": return "Rapidità Predatoria";
                case "Português Brasileiro": return "Velocidade Predatória";
                case "Русский": return "Стремительность хищника";
                case "한국어": return "야생의 신속함";
                case "简体中文": return "掠食者的迅捷";
                default: return "Predatory Swiftness";
            }
        }

        ///<summary>spell=264667</summary>
        private static string PrimalRage_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Primal Rage";
                case "Deutsch": return "Urtümliche Wut";
                case "Español": return "Rabia primigenia";
                case "Français": return "Rage primordiale";
                case "Italiano": return "Rabbia Primordiale";
                case "Português Brasileiro": return "Fúria Primata";
                case "Русский": return "Исступление";
                case "한국어": return "원초적 분노";
                case "简体中文": return "原始暴怒";
                default: return "Primal Rage";
            }
        }

        ///<summary>spell=285381</summary>
        private static string PrimalWrath_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Primal Wrath";
                case "Deutsch": return "Urzorn";
                case "Español": return "Cólera primigenia";
                case "Français": return "Colère primitive";
                case "Italiano": return "Ira Primordiale";
                case "Português Brasileiro": return "Ira Primeva";
                case "Русский": return "Первобытный гнев";
                case "한국어": return "원시 분노";
                case "简体中文": return "原始之怒";
                default: return "Primal Wrath";
            }
        }

        ///<summary>spell=5215</summary>
        private static string Prowl_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Prowl";
                case "Deutsch": return "Schleichen";
                case "Español": return "Acechar";
                case "Français": return "Rôder";
                case "Italiano": return "Movimento Furtivo";
                case "Português Brasileiro": return "Espreitar";
                case "Русский": return "Крадущийся зверь";
                case "한국어": return "숨기";
                case "简体中文": return "潜行";
                default: return "Prowl";
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

        ///<summary>spell=5221</summary>
        private static string Shred_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shred";
                case "Deutsch": return "Schreddern";
                case "Español": return "Triturar";
                case "Français": return "Lambeau";
                case "Italiano": return "Artigliata";
                case "Português Brasileiro": return "Despedaçar";
                case "Русский": return "Полоснуть";
                case "한국어": return "칼날 발톱";
                case "简体中文": return "撕碎";
                default: return "Shred";
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

        ///<summary>spell=164815</summary>
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

        ///<summary>spell=106785</summary>
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

        ///<summary>spell=106830</summary>
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

        ///<summary>spell=252216</summary>
        private static string TigerDash_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Tiger Dash";
                case "Deutsch": return "Tigerspurt";
                case "Español": return "Acometida de tigre";
                case "Français": return "Célérité du tigre";
                case "Italiano": return "Scatto della Tigre";
                case "Português Brasileiro": return "Arremetida do Tigre";
                case "Русский": return "Рывок тигра";
                case "한국어": return "범의 질주";
                case "简体中文": return "猛虎冲刺";
                default: return "Tiger Dash";
            }
        }

        ///<summary>spell=5217</summary>
        private static string TigersFury_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Tiger's Fury";
                case "Deutsch": return "Tigerfuror";
                case "Español": return "Furia del tigre";
                case "Français": return "Fureur du tigre";
                case "Italiano": return "Furia della Tigre";
                case "Português Brasileiro": return "Fúria do Tigre";
                case "Русский": return "Тигриное неистовство";
                case "한국어": return "호랑이의 분노";
                case "简体中文": return "猛虎之怒";
                default: return "Tiger's Fury";
            }
        }

        ///<summary>spell=80353</summary>
        private static string TimeWarp_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Time Warp";
                case "Deutsch": return "Zeitkrümmung";
                case "Español": return "Distorsión temporal";
                case "Français": return "Distorsion temporelle";
                case "Italiano": return "Distorsione Temporale";
                case "Português Brasileiro": return "Distorção Temporal";
                case "Русский": return "Искажение времени";
                case "한국어": return "시간 왜곡";
                case "简体中文": return "时间扭曲";
                default: return "Time Warp";
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

        ///<summary>spell=102401</summary>
        private static string WildCharge_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Wild Charge";
                case "Deutsch": return "Wilde Attacke";
                case "Español": return "Carga salvaje";
                case "Français": return "Charge sauvage";
                case "Italiano": return "Carica Selvaggia";
                case "Português Brasileiro": return "Investida Selvagem";
                case "Русский": return "Стремительный рывок";
                case "한국어": return "야생의 돌진";
                case "简体中文": return "野性冲锋";
                default: return "Wild Charge";
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

        ///<summary>spell=5176</summary>
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

        string FiveLetters;

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "MightyBash", "MassEntanglement", "NoDecurse", "Maim", "NoInterrupts", "NoCycle", "Rebirth", };
        private List<string> m_DebuffsList;
        private List<string> m_BuffsList;
        private List<string> m_ItemsList;
        private List<string> m_SpellBook;

        private List<string> m_RaceList = new List<string> { "human", "dwarf", "nightelf", "gnome", "draenei", "pandaren", "orc", "scourge", "tauren", "troll", "bloodelf", "goblin", "worgen", "voidelf", "lightforgeddraenei", "highmountaintauren", "nightborne", "zandalaritroll", "magharorc", "kultiran", "darkirondwarf", "vulpera", "mechagnome" };

        private List<int> Torghast_InnerFlame = new List<int> { 258935, 258938, 329422, 329423, };

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
        public bool UnitFocus(string unit)
        {
            if (Aimsharp.CustomFunction("UnitIsFocus") == 1 && unit == "party1" || Aimsharp.CustomFunction("UnitIsFocus") == 2 && unit == "party2" || Aimsharp.CustomFunction("UnitIsFocus") == 3 && unit == "party3" || Aimsharp.CustomFunction("UnitIsFocus") == 4 && unit == "party4" || Aimsharp.CustomFunction("UnitIsFocus") == 5 && unit == "player")
                return true;

            return false;
        }

        private bool TargetAlive()
        {
            if (Aimsharp.CustomFunction("UnitIsDead") == 2)
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
            Macros.Add("Weapon", "/use 16");

            //Healthstone
            Macros.Add("UseHealthstone", "/use " + Healthstone_SpellName(Language));

            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");
            Macros.Add("RC_FOC", "/cast [@focus] " + RemoveCorruption_SpellName(Language));

            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + (Aimsharp.Latency + 100));

            //Mouseover Macros
            Macros.Add("RakeMO", "/cast [@mouseover] " + Rake_SpellName(Language));
            Macros.Add("SootheMO", "/cast [@mouseover] " + Soothe_SpellName(Language));
            Macros.Add("RebirthMO", "/cast [@mouseover] " + Rebirth_SpellName(Language));

            //Queues
            Macros.Add("MightyBashOff", "/" + FiveLetters + " MightyBash");
            Macros.Add("MassEntanglementOff", "/" + FiveLetters + " MassEntanglement");
            Macros.Add("MaimOff", "/" + FiveLetters + " Maim");
            Macros.Add("RebirthOff", "/" + FiveLetters + " Rebirth");

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
            CustomFunctions.Add("HekiliID1", "local loading, finished = IsAddOnLoaded(\"Hekili\") \r\nif loading == true and finished == true then \r\n    local id=Hekili_GetRecommendedAbility(\"Primary\",1)\r\n\tif id ~= nil then\r\n\t\r\n    if id<0 then \r\n\t    local spell = Hekili.Class.abilities[id]\r\n\t    if spell ~= nil and spell.item ~= nil then \r\n\t    \tid=spell.item\r\n\t\t    local topTrinketLink = GetInventoryItemLink(\"player\",13)\r\n\t\t    local bottomTrinketLink = GetInventoryItemLink(\"player\",14)\r\n\t\t    local weaponLink = GetInventoryItemLink(\"player\",16)\r\n\t\t    if topTrinketLink  ~= nil then\r\n                local trinketid = GetItemInfoInstant(topTrinketLink)\r\n                if trinketid ~= nil then\r\n\t\t\t        if trinketid == id then\r\n\t\t\t\t        return 1\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t\t    if bottomTrinketLink ~= nil then\r\n                local trinketid = GetItemInfoInstant(bottomTrinketLink)\r\n                if trinketid ~= nil then\r\n    \t\t\t    if trinketid == id then\r\n\t    \t\t\t    return 2\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t\t    if weaponLink ~= nil then\r\n                local weaponid = GetItemInfoInstant(weaponLink)\r\n                if weaponid ~= nil then\r\n    \t\t\t    if weaponid == id then\r\n\t    \t\t\t    return 3\r\n                    end\r\n\t\t\t    end\r\n\t\t    end\r\n\t    end \r\n    end\r\n    return id\r\nend\r\nend\r\nreturn 0");

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

            CustomFunctions.Add("PhialCount", "local count = GetItemCount(177278) if count ~= nil then return count end return 0");

            CustomFunctions.Add("GetSpellQueueWindow", "local sqw = GetCVar(\"SpellQueueWindow\"); if sqw ~= nil then return tonumber(sqw); end return 0");

            CustomFunctions.Add("RakeDebuffCheck", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Rake','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,_,_,_,source  = UnitDebuff('mouseover', y) if name == 'Rake' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("EnrageBuffCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Soothe','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType  = UnitBuff('mouseover', y) if debuffType == '' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("EnrageBuffCheckTarget", "local markcheck = 0; if UnitExists('target') and UnitIsDead('target') ~= true and UnitAffectingCombat('target') and IsSpellInRange('Soothe','target') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType  = UnitBuff('target', y) if debuffType == '' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("CooldownsToggleCheck", "local loading, finished = IsAddOnLoaded(\"Hekili\") if loading == true and finished == true then local cooldowns = Hekili:GetToggleState(\"cooldowns\") if cooldowns == true then return 1 else if cooldowns == false then return 2 end end end return 0");

            CustomFunctions.Add("UnitIsDead", "if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == true then return 1 end; if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == false then return 2 end; return 0");

            CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
                "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
                "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
                "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
                "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
                "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
                "\nreturn foc");

            CustomFunctions.Add("HekiliWait", "if HekiliDisplayPrimary.Recommendations[1].wait ~= nil and HekiliDisplayPrimary.Recommendations[1].wait * 1000 > 0 then return math.floor(HekiliDisplayPrimary.Recommendations[1].wait * 1000) end return 0");

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("TargetIsMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitExists('target') and UnitIsDead('target') ~= true and UnitIsUnit('mouseover', 'target') then return 1 end; return 0");

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
            Settings.Add(new Setting("Race:", m_RaceList, "nightelf"));
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
            Settings.Add(new Setting("Prowl Out of Combat:", true));
            Settings.Add(new Setting("Mark of the Wild Out of Combat:", true));
            Settings.Add(new Setting("Spread Rake with Mouseover:", false));
            Settings.Add(new Setting("Soothe Mouseover:", true));
            Settings.Add(new Setting("Soothe Target:", true));
            Settings.Add(new Setting("Maim Queue - Dont wait for Max CP", false));
            Settings.Add(new Setting("Auto Renewal @ HP%", 0, 100, 20));
            Settings.Add(new Setting("Auto Barkskin @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Auto Survival Instincts @ HP%", 0, 100, 35));
            Settings.Add(new Setting("Auto Regrowth @ HP%", 0, 100, 50));
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

            Aimsharp.Latency = GetSlider("Ingame World Latency:");
            Aimsharp.QuickDelay = 50;
            Aimsharp.SlowDelay = 150;

            Aimsharp.PrintMessage("Epic PVE - Druid Feral", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.Red);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.Red);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/druid/feral/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoDecurse - Disables Decurse", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " MightyBash - Casts Mighty Bash @ Target on the next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " MassEntanglement - Casts Mass Entanglement @ Target on the next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Maim - Casts Maim @ Target on the next GCD", Color.Yellow);
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
            m_DebuffsList = new List<string> { Rake_SpellName(Language), };
            m_BuffsList = new List<string> { PredatorySwiftness_SpellName(Language), Prowl_SpellName(Language), MarkOfTheWild_SpellName(Language), };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language) };
            m_SpellBook = new List<string> {
                //Covenants
                ConvokeTheSpirits_SpellName(Language),
                AdaptiveSwarm_SpellName(Language),
                EmpowerBond_SpellName(Language),
                RavenousFrenzy_SpellName(Language),

                //Interrupt
                SkullBash_SpellName(Language), //106839

                //General
                Barkskin_SpellName(Language),
                Berserk_SpellName(Language), //106951
                BrutalSlash_SpellName(Language), //202028
                CatForm_SpellName(Language),
                FeralFrenzy_SpellName(Language), //274837
                FerociousBite_SpellName(Language), //22658
                HeartOfTheWild_SpellName(Language),
                Incarnation_AvatarOfAshamane_SpellName(Language), //102543
                Maim_SpellName(Language), //22570
                MarkOfTheWild_SpellName(Language),
                MassEntanglement_SpellName(Language),
                MightyBash_SpellName(Language), //5211
                Moonfire_SpellName(Language),
                MoonkinForm_SpellName(Language),
                NaturesVigil_SpellName(Language),
                PrimalWrath_SpellName(Language), //285381
                Prowl_SpellName(Language), //5215
                Rake_SpellName(Language), //1822
                Rebirth_SpellName(Language),
                Regrowth_SpellName(Language),
                RemoveCorruption_SpellName(Language),
                Renewal_SpellName(Language),
                Rip_SpellName(Language), //1079
                Shred_SpellName(Language), //5221
                Soothe_SpellName(Language),
                Starsurge_SpellName(Language),
                Sunfire_SpellName(Language),
                SurvivalInstincts_SpellName(Language), //61336
                Swipe_SpellName(Language), //106785
                Thrash_SpellName(Language), //106830
                TigerDash_SpellName(Language), //252216
                TigersFury_SpellName(Language), //5217
                WildCharge_SpellName(Language), //102401

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
            bool Moving = Aimsharp.PlayerIsMoving();

            int CursePoisonCheck = Aimsharp.CustomFunction("CursePoisonCheck");
            int MarkDebuffMO = Aimsharp.CustomFunction("RakeDebuffCheck");
            int EnrageBuffMO = Aimsharp.CustomFunction("EnrageBuffCheckMouseover");
            int EnrageBuffTarget = Aimsharp.CustomFunction("EnrageBuffCheckTarget");
            int CooldownsToggle = Aimsharp.CustomFunction("CooldownsToggleCheck");

            bool NoDecurse = Aimsharp.IsCustomCodeOn("NoDecurse");
            bool NoInterrupts = Aimsharp.IsCustomCodeOn("NoInterrupts");
            bool NoCycle = Aimsharp.IsCustomCodeOn("NoCycle");
            bool MightyBash = Aimsharp.IsCustomCodeOn("MightyBash");
            bool MassEntanglement = Aimsharp.IsCustomCodeOn("MassEntanglement");

            bool Debug = GetCheckBox("Debug:") == true;
            bool MOMark = GetCheckBox("Spread Rake with Mouseover:") == true;
            bool MOSoothe = GetCheckBox("Soothe Mouseover:") == true;
            bool TargetSoothe = GetCheckBox("Soothe Target:") == true;
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
                if (Aimsharp.CanCast(SkullBash_SpellName(Language)))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(SkullBash_SpellName(Language), true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast(SkullBash_SpellName(Language)))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(SkullBash_SpellName(Language), true);
                        return true;
                    }
                }
            }
            #endregion

            #region Auto Spells and Items
            //Auto Healthstone
            if (Aimsharp.CanUseItem(Healthstone_SpellName(Language), false) && Aimsharp.ItemCooldown(Healthstone_SpellName(Language)) == 0)
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


            //Auto Regrowth
            if (Aimsharp.CanCast(Regrowth_SpellName(Language), "player", false, true) && Aimsharp.HasBuff(PredatorySwiftness_SpellName(Language), "player", true))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Regrowth @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Regrowth - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Regrowth @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(Regrowth_SpellName(Language));
                    return true;
                }
            }

            //Auto Renewal
            if (Aimsharp.CanCast(Renewal_SpellName(Language), "player", false, true))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Renewal @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Renewal - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Renewal @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(Renewal_SpellName(Language));
                    return true;
                }
            }

            //Auto Barkskin
            if (Aimsharp.CanCast(Barkskin_SpellName(Language), "player", false, true))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Barkskin @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Barkskin - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Barkskin @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(Barkskin_SpellName(Language));
                    return true;
                }
            }

            //Auto Survival Instincts
            if (Aimsharp.CanCast(SurvivalInstincts_SpellName(Language), "player", false, true))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Survival Instincts @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Survival Instincts - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Survival Instincts @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(SurvivalInstincts_SpellName(Language));
                    return true;
                }
            }
            #endregion

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

                int KickTimer = GetRandomNumber(200,800);

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
                                if (Debug)
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

            if (Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                #region Queues
                //Queue Mighty Bash
                if (MightyBash && Aimsharp.SpellCooldown(MightyBash_SpellName(Language)) - Aimsharp.GCD() > 2000)
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Turning Off Mighty Bash queue toggle", Color.Purple);
                    }
                    Aimsharp.Cast("MightyBashOff");
                    return true;
                }

                if (MightyBash && Aimsharp.CanCast(MightyBash_SpellName(Language), "target", true, true))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Mighty Bash through queue toggle", Color.Purple);
                    }
                    Aimsharp.Cast(MightyBash_SpellName(Language));
                    return true;
                }

                //Queue Mass Entanglement
                if (MassEntanglement && Aimsharp.SpellCooldown(MassEntanglement_SpellName(Language)) - Aimsharp.GCD() > 2000)
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Turning Off Mass Entanglement queue toggle", Color.Purple);
                    }
                    Aimsharp.Cast("MassEntanglementOff");
                    return true;
                }

                if (MassEntanglement && Aimsharp.CanCast(MassEntanglement_SpellName(Language), "target", true, true))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Mass Entanglement through queue toggle", Color.Purple);
                    }
                    Aimsharp.Cast(MassEntanglement_SpellName(Language));
                    return true;
                }

                bool Maim = Aimsharp.IsCustomCodeOn("Maim");
                //Queue Maim
                if (Maim && Aimsharp.SpellCooldown(Maim_SpellName(Language)) - Aimsharp.GCD() > 2000)
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Turning Off Maim queue toggle", Color.Purple);
                    }
                    Aimsharp.Cast("MaimOff");
                    return true;
                }

                if (Maim && Aimsharp.CanCast(Maim_SpellName(Language), "target", true, true) && (Aimsharp.PlayerSecondaryPower() >= 5 || GetCheckBox("Maim Queue - Dont wait for Max CP")))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Maim through queue toggle", Color.Purple);
                    }
                    Aimsharp.Cast(Maim_SpellName(Language));
                    return true;
                }
                //Queue Rebirth
                bool Rebirth = Aimsharp.IsCustomCodeOn("Rebirth");
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
                #endregion

                #region Mouseover Spells
                //Soothe Mouseover
                if (Aimsharp.CanCast(Soothe_SpellName(Language), "mouseover", true, true))
                {
                    if (MOSoothe && EnrageBuffMO == 3)
                    {
                        Aimsharp.Cast("SootheMO");
                        if (Debug)
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
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Soothe (Target)", Color.Purple);
                        }
                        return true;
                    }
                }

                //Rake Mouseover Spread
                if (Aimsharp.CanCast(Rake_SpellName(Language), "mouseover", true, false) && Aimsharp.HasDebuff(Rake_SpellName(Language), "target", true) && Aimsharp.CustomFunction("TargetIsMouseover") == 0)
                {
                    if (MOMark && MarkDebuffMO == 1)
                    {
                        Aimsharp.Cast("RakeMO");
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rake (Mouseover)", Color.Purple);
                        }
                        return true;
                    }
                }
                #endregion

                #region Maim Max CP
                if (Maim && !GetCheckBox("Maim Queue - Dont wait for Max CP"))
                {
                    if (Aimsharp.CanCast(Shred_SpellName(Language), "target", true, true) && Aimsharp.PlayerSecondaryPower() < 5)
                    {
                        Aimsharp.Cast(Shred_SpellName(Language));
                        return true;
                    }
                }
                #endregion

                if (Aimsharp.Range("target") <= 8 && Wait <= 200 && !Maim)
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
                    if (SpellID1 == 28880 && Aimsharp.CanCast(GiftOfTheNaaru_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Gift of the Naaru - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(GiftOfTheNaaru_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 20594 && Aimsharp.CanCast(Stoneform_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Stoneform - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Stoneform_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 20589 && Aimsharp.CanCast(EscapeArtist_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Escape Artist - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(EscapeArtist_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 59752 && Aimsharp.CanCast(WillToSurvive_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Will to Survive - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WillToSurvive_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 255647 && Aimsharp.CanCast(LightsJudgment_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Light's Judgment - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(LightsJudgment_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 265221 && Aimsharp.CanCast(Fireblood_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fireblood - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Fireblood_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 69041 && Aimsharp.CanCast(RocketBarrage_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rocket Barrage - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RocketBarrage_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 20549 && Aimsharp.CanCast(WarStomp_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting War Stomp - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WarStomp_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 7744 && Aimsharp.CanCast(WillOfTheForsaken_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Will of the Forsaken - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WillOfTheForsaken_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 260364 && Aimsharp.CanCast(ArcanePulse_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Pulse - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ArcanePulse_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 255654 && Aimsharp.CanCast(BullRush_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bull Rush - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BullRush_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 312411 && Aimsharp.CanCast(BagOfTricks_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bag of Tricks - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BagOfTricks_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 20572 || SpellID1 == 33702 || SpellID1 == 33697) && Aimsharp.CanCast(BloodFury_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blood Fury - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BloodFury_SpellName(Language));
                        return true;
                    }


                    if (SpellID1 == 26297 && Aimsharp.CanCast(Berserking_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Berserking - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Berserking_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 274738 && Aimsharp.CanCast(AncestralCall_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ancestral Call - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AncestralCall_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 28730 || SpellID1 == 25046 || SpellID1 == 50613 || SpellID1 == 69179 || SpellID1 == 80483 || SpellID1 == 129597) && Aimsharp.CanCast(ArcaneTorrent_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Torrent - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ArcaneTorrent_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 58984 && Aimsharp.CanCast(Shadowmeld_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowmeld - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Shadowmeld_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Covenants
                    ///Covenants
                    if (SpellID1 == 323764 && Aimsharp.CanCast(ConvokeTheSpirits_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Convoke the Spirits - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ConvokeTheSpirits_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 325727 && Aimsharp.CanCast(AdaptiveSwarm_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Adaptive Swarm - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AdaptiveSwarm_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 323546 && Aimsharp.CanCast(RavenousFrenzy_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ravenous Frenzy - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RavenousFrenzy_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 327139 || SpellID1 == 327022 || SpellID1 == 327148 || SpellID1 == 327071 || SpellID1 == 326647) && Aimsharp.CanCast(EmpowerBond_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Empower Bond - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(EmpowerBond_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - No GCD
                    ///Class Spells
                    //Target - No GCD
                    if (SpellID1 == 106839 && Aimsharp.CanCast(SkullBash_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Skull Bash - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SkullBash_SpellName(Language), true);
                        return true;
                    }

                    if ((SpellID1 == 343223 || SpellID1 == 106951) && Aimsharp.CanCast(Berserk_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Berserk - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Berserk_SpellName(Language), true);
                        return true;
                    }
                    if (SpellID1 == 124974 && Aimsharp.CanCast(NaturesVigil_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Nature's Vigil - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(NaturesVigil_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    //Target - GCD
                    if (SpellID1 == 1822 && Aimsharp.CanCast(Rake_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rake - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Rake_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 5521 || SpellID1 == 5221 || SpellID1 == 343232) && Aimsharp.CanCast(Shred_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shred - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Shred_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 22568 && Aimsharp.CanCast(FerociousBite_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ferocious Bite - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FerociousBite_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 1079 && Aimsharp.CanCast(Rip_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rip - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Rip_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 22570 && Aimsharp.CanCast(Maim_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Maim - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Maim_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 274837 && Aimsharp.CanCast(FeralFrenzy_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Feral Frenzy - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FeralFrenzy_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 5211 && Aimsharp.CanCast(MightyBash_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mighty Bash - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(MightyBash_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 102401 && Aimsharp.CanCast(WildCharge_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Charge - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WildCharge_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 197630 && Aimsharp.CanCast(Sunfire_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sunfire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Sunfire_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 164812 || SpellID1 == 155625 || SpellID1 == 8921) && Aimsharp.CanCast(Moonfire_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Moonfire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Moonfire_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 197626 && Aimsharp.CanCast(Starsurge_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Starsurge - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Starsurge_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    //Player - GCD
                    if (SpellID1 == 1126 && Aimsharp.CanCast(MarkOfTheWild_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mark of the Wild - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(MarkOfTheWild_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 5217 && Aimsharp.CanCast(TigersFury_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tiger's Fury- " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TigersFury_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 61336 && Aimsharp.CanCast(SurvivalInstincts_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Survival Instincts- " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SurvivalInstincts_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 108238 && Aimsharp.CanCast(Renewal_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Renewal- " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Renewal_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 106785 && Aimsharp.CanCast(Swipe_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Swipe- " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Swipe_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 106830 && Aimsharp.CanCast(Thrash_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Thrash - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Thrash_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 102543 && Aimsharp.CanCast(Incarnation_AvatarOfAshamane_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Incarnation: King of the Jungle - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Incarnation_AvatarOfAshamane_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 202028 && Aimsharp.CanCast(BrutalSlash_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Brutal Slash - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BrutalSlash_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 319454 && Aimsharp.CanCast(HeartOfTheWild_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Heart of the Wild - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(HeartOfTheWild_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 252216 && Aimsharp.CanCast(TigerDash_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tiger Dash - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TigerDash_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 5215 && Aimsharp.CanCast(Prowl_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Prowl - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Prowl_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 768 && Aimsharp.CanCast(CatForm_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cat Form - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(CatForm_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 285381 && Aimsharp.CanCast(PrimalWrath_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Primal Wrath - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(PrimalWrath_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 197625 && Aimsharp.CanCast(MoonkinForm_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Moonkin Form - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(MoonkinForm_SpellName(Language));
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
            bool Moving = Aimsharp.PlayerIsMoving();
            int PhialCount = Aimsharp.CustomFunction("PhialCount");
            bool MightyBash = Aimsharp.IsCustomCodeOn("MightyBash");
            bool MassEntanglement = Aimsharp.IsCustomCodeOn("MassEntanglement");

            bool ProwlOOC = GetCheckBox("Prowl Out of Combat:");
            bool MOTWOOC = GetCheckBox("Mark of the Wild Out of Combat:");
            bool Debug = GetCheckBox("Debug:") == true;
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
            #endregion

            #region Queues
            //Queue Mighty Bash
            if (MightyBash && Aimsharp.SpellCooldown(MightyBash_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mighty Bash queue toggle - OOC", Color.Purple);
                }
                Aimsharp.Cast("MightyBashOff");
                return true;
            }

            if (MightyBash && Aimsharp.CanCast(MightyBash_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mighty Bash through queue toggle - OOC", Color.Purple);
                }
                Aimsharp.Cast(MightyBash_SpellName(Language));
                return true;
            }

            //Queue Mass Entanglement
            if (MassEntanglement && Aimsharp.SpellCooldown(MassEntanglement_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mass Entanglement queue toggle - OOC", Color.Purple);
                }
                Aimsharp.Cast("MassEntanglementOff");
                return true;
            }

            if (MassEntanglement && Aimsharp.CanCast(MassEntanglement_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mass Entanglement through queue toggle - OOC", Color.Purple);
                }
                Aimsharp.Cast(MassEntanglement_SpellName(Language));
                return true;
            }

            bool Maim = Aimsharp.IsCustomCodeOn("Maim");
            //Queue Mighty Bash
            if (Maim && Aimsharp.SpellCooldown(Maim_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Maim queue toggle", Color.Purple);
                }
                Aimsharp.Cast("MaimOff");
                return true;
            }

            if (Maim && Aimsharp.CanCast(Maim_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Maim through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Maim_SpellName(Language));
                return true;
            }
            //Queue Rebirth
            bool Rebirth = Aimsharp.IsCustomCodeOn("Rebirth");
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
            #endregion

            #region Out of Combat Spells
            //Auto Mark of the Wild
            if (SpellID1 == 1126 && Aimsharp.CanCast(MarkOfTheWild_SpellName(Language), "player", false, true) && MOTWOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mark of the Wild (Out of Combat) - " + SpellID1, Color.Black);
                }
                Aimsharp.Cast(MarkOfTheWild_SpellName(Language));
                return true;
            }

            if (Aimsharp.CanCast(MarkOfTheWild_SpellName(Language), "player", false, true) && !Aimsharp.HasBuff(MarkOfTheWild_SpellName(Language), "player", true) && MOTWOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mark of the Wild (Out of Combat) - " + SpellID1, Color.Black);
                }
                Aimsharp.Cast(MarkOfTheWild_SpellName(Language));
                return true;
            }

            //Prowl Out of Combat
            if (SpellID1 == 5215 && Aimsharp.CanCast(Prowl_SpellName(Language), "player", false, true) && ProwlOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Prowl (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(Prowl_SpellName(Language));
                return true;
            }

            if (Aimsharp.CanCast(Prowl_SpellName(Language), "player", false, true) && !Aimsharp.HasBuff(Prowl_SpellName(Language), "player", true) && ProwlOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Prowl (Out of Combat)", Color.Purple);
                }
                Aimsharp.Cast(Prowl_SpellName(Language));
                return true;
            }
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 6)
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