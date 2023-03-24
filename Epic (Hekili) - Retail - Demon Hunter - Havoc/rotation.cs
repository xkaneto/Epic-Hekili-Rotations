using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicDemonHunterHavocHekili : Rotation
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

        ///<summary>spell=201427</summary>
        private static string Annihilation_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Annihilation";
                case "Deutsch": return "Vernichtung";
                case "Español": return "Aniquilación";
                case "Français": return "Annihiler";
                case "Italiano": return "Annientamento";
                case "Português Brasileiro": return "Aniquilação";
                case "Русский": return "Аннигиляция";
                case "한국어": return "파멸";
                case "简体中文": return "毁灭";
                default: return "Annihilation";
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

        ///<summary>spell=188499</summary>
        private static string BladeDance_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blade Dance";
                case "Deutsch": return "Klingentanz";
                case "Español": return "Danza de hojas";
                case "Français": return "Danse des lames";
                case "Italiano": return "Lame Danzanti";
                case "Português Brasileiro": return "Dança de Lâminas";
                case "Русский": return "Танец клинков";
                case "한국어": return "칼춤";
                case "简体中文": return "刃舞";
                default: return "Blade Dance";
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

        ///<summary>spell=198589</summary>
        private static string Blur_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blur";
                case "Deutsch": return "Verschwimmen";
                case "Español": return "Disiparse";
                case "Français": return "Voile corrompu";
                case "Italiano": return "Offuscamento";
                case "Português Brasileiro": return "Borrão";
                case "Русский": return "Затуманивание";
                case "한국어": return "흐릿해지기";
                case "简体中文": return "疾影";
                default: return "Blur";
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

        ///<summary>spell=162794</summary>
        private static string ChaosStrike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Chaos Strike";
                case "Deutsch": return "Chaosstoß";
                case "Español": return "Golpe de caos";
                case "Français": return "Frappe du chaos";
                case "Italiano": return "Assalto del Caos";
                case "Português Brasileiro": return "Golpe do Caos";
                case "Русский": return "Удар Хаоса";
                case "한국어": return "혼돈의 일격";
                case "简体中文": return "混乱打击";
                default: return "Chaos Strike";
            }
        }

        ///<summary>spell=390152</summary>
        private static string CollectiveAnguish_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Collective Anguish";
                case "Deutsch": return "Kollektive Qual";
                case "Español": return "Angustia colectiva";
                case "Français": return "Angoisse collective";
                case "Italiano": return "Angoscia Collettiva";
                case "Português Brasileiro": return "Angústia Coletiva";
                case "Русский": return "Всеобщая тоска";
                case "한국어": return "집단 고뇌";
                case "简体中文": return "聚凝痛楚";
                default: return "Collective Anguish";
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

        ///<summary>spell=210152</summary>
        private static string DeathSweep_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Death Sweep";
                case "Deutsch": return "Todesfeger";
                case "Español": return "Barrido mortal";
                case "Français": return "Balayage mortel";
                case "Italiano": return "Spazzata della Morte";
                case "Português Brasileiro": return "Varredura Mortal";
                case "Русский": return "Смертоносный взмах";
                case "한국어": return "죽음의 휩쓸기";
                case "简体中文": return "死亡横扫";
                default: return "Death Sweep";
            }
        }

        ///<summary>spell=162243</summary>
        private static string DemonsBite_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Demon's Bite";
                case "Deutsch": return "Dämonenbiss";
                case "Español": return "Mordedura de demonio";
                case "Français": return "Morsure du démon";
                case "Italiano": return "Morso del Demone";
                case "Português Brasileiro": return "Mordida do Demônio";
                case "Русский": return "Укус демона";
                case "한국어": return "악마의 이빨";
                case "简体中文": return "恶魔之咬";
                default: return "Demon's Bite";
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

        ///<summary>spell=258860</summary>
        private static string EssenceBreak_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Essence Break";
                case "Deutsch": return "Essenzbruch";
                case "Español": return "Rotura de esencia";
                case "Français": return "Dégradation d’essence";
                case "Italiano": return "Rottura Essenza";
                case "Português Brasileiro": return "Quebrar Essência";
                case "Русский": return "Разрыв сущности";
                case "한국어": return "정수 파쇄";
                case "简体中文": return "精华破碎";
                default: return "Essence Break";
            }
        }

        ///<summary>spell=198013</summary>
        private static string EyeBeam_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Eye Beam";
                case "Deutsch": return "Augenstrahl";
                case "Español": return "Haz ocular";
                case "Français": return "Rayon accablant";
                case "Italiano": return "Raggio Oculare";
                case "Português Brasileiro": return "Raio Ocular";
                case "Русский": return "Пронзающий взгляд";
                case "한국어": return "안광";
                case "简体中文": return "眼棱";
                default: return "Eye Beam";
            }
        }

        ///<summary>spell=258925</summary>
        private static string FelBarrage_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fel Barrage";
                case "Deutsch": return "Teufelsbeschuss";
                case "Español": return "Tromba vil";
                case "Français": return "Barrage gangrené";
                case "Italiano": return "Vilraffica";
                case "Português Brasileiro": return "Salva Vil";
                case "Русский": return "Обстрел Скверны";
                case "한국어": return "지옥 포화";
                case "简体中文": return "邪能弹幕";
                default: return "Fel Barrage";
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

        ///<summary>spell=195072</summary>
        private static string FelRush_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fel Rush";
                case "Deutsch": return "Teufelsrausch";
                case "Español": return "Carga vil";
                case "Français": return "Ruée fulgurante";
                case "Italiano": return "Vilscatto";
                case "Português Brasileiro": return "Impulso Vil";
                case "Русский": return "Рывок Скверны";
                case "한국어": return "지옥 돌진";
                case "简体中文": return "邪能冲撞";
                default: return "Fel Rush";
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


        ///<summary>spell=329554</summary>
        private static string FodderToTheFlame_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fodder to the Flame";
                case "Deutsch": return "Futter für die Flamme";
                case "Español": return "Pasto de las llamas";
                case "Français": return "Offrande aux flammes";
                case "Italiano": return "Carne alla Fiamma";
                case "Português Brasileiro": return "Avivar as Chamas";
                case "Русский": return "Подпитка для пламени";
                case "한국어": return "불길의 양식";
                case "简体中文": return "燃焰饲魂";
                default: return "Fodder to the Flame";
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

        ///<summary>spell=342817</summary>
        private static string GlaiveTempest_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Glaive Tempest";
                case "Deutsch": return "Glevenorkan";
                case "Español": return "Tormenta de gujas";
                case "Français": return "Tempête de glaives";
                case "Italiano": return "Tempesta di Lame";
                case "Português Brasileiro": return "Tormenta de Glaive";
                case "Русский": return "Буря клинков";
                case "한국어": return "글레이브의 폭풍";
                case "简体中文": return "战刃风暴";
                default: return "Glaive Tempest";
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

        ///<summary>spell=196555</summary>
        private static string Netherwalk_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Netherwalk";
                case "Deutsch": return "Netherwandeln";
                case "Español": return "Camino abisal";
                case "Français": return "Marche du Néant";
                case "Italiano": return "Calcafatuo";
                case "Português Brasileiro": return "Andar no Éter";
                case "Русский": return "Путь Пустоты";
                case "한국어": return "황천걸음";
                case "简体中文": return "虚空行走";
                default: return "Netherwalk";
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

        ///<summary>spell=207684</summary>
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

        ///<summary>spell=317009</summary>
        private static string SinfulBrand_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sinful Brand";
                case "Deutsch": return "Sündhaftes Brandzeichen";
                case "Español": return "Marca pecaminosa";
                case "Français": return "Marque immorale";
                case "Italiano": return "Marchio Peccaminoso";
                case "Português Brasileiro": return "Marca Pecaminosa";
                case "Русский": return "Клеймо греха";
                case "한국어": return "죄악의 낙인";
                case "简体中文": return "罪孽烙印";
                default: return "Sinful Brand";
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
        #endregion

        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle", "NoMovement", "ChaosNova", "Imprison", "Darkness", "FelEruption", "FelRush", "Felblade", "SigilofFlame", "SigilofMisery" };
        private List<string> m_DebuffsList;
        private List<string> m_BuffsList;
        private List<string> m_ItemsList;
        private List<string> m_SpellBook_General;
        private List<string> m_RaceList = new List<string> { "nightelf", "bloodelf" };
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

            //Healthstone
            Macros.Add("UseHealthstone", "/use " + Healthstone_SpellName(Language));


            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + Aimsharp.Latency);

            Macros.Add("MetamorphosisP", "/cast [@player] " + Metamorphosis_SpellName(Language));
            Macros.Add("SigilofFlameP", "/cast [@player] " + SigilOfFlame_SpellName(Language));
            Macros.Add("SigilofFlameC", "/cast [@cursor] " + SigilOfFlame_SpellName(Language));
            Macros.Add("SigilofMiseryP", "/cast [@player] " + SigilOfMisery_SpellName(Language));
            Macros.Add("SigilofMiseryC", "/cast [@cursor] " + SigilOfMisery_SpellName(Language));
            Macros.Add("ElysianDecreeP", "/cast [@player] " + ElysianDecree_SpellName(Language));
            Macros.Add("ElysianDecreeC", "/cast [@cursor] " + ElysianDecree_SpellName(Language));

            Macros.Add("SigilofFlameOff", "/" + FiveLetters + " SigilofFlame");
            Macros.Add("SigilofMiseryOff", "/" + FiveLetters + " SigilofMisery");
            Macros.Add("ChaosNovaOff", "/" + FiveLetters + " ChaosNova");
            Macros.Add("ImprisonOff", "/" + FiveLetters + " Imprison");
            Macros.Add("DarknessOff", "/" + FiveLetters + " Darkness");
            Macros.Add("FelEruptionOff", "/" + FiveLetters + " FelEruption");
            Macros.Add("FelRushOff", "/" + FiveLetters + " FelRush");
            Macros.Add("FelbladeOff", "/" + FiveLetters + " Felblade");

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

            CustomFunctions.Add("PhialCount", "local count = GetItemCount(177278) if count ~= nil then return count end return 0");

            CustomFunctions.Add("GetSpellQueueWindow", "local sqw = GetCVar(\"SpellQueueWindow\"); if sqw ~= nil then return tonumber(sqw); end return 0");

            CustomFunctions.Add("CooldownsToggleCheck", "local loading, finished = IsAddOnLoaded(\"Hekili\") if loading == true and finished == true then local cooldowns = Hekili:GetToggleState(\"cooldowns\") if cooldowns == true then return 1 else if cooldowns == false then return 2 end end end return 0");

            CustomFunctions.Add("UnitIsDead", "if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == true then return 1 end; if UnitIsDead(\"target\") ~= nil and UnitIsDead(\"target\") == false then return 2 end; return 0");

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
            Settings.Add(new Setting("Race:", m_RaceList, "bloodelf"));
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
            Settings.Add(new Setting("Suggest but don't cast Movement Based Abilities:", false));
            Settings.Add(new Setting("Auto Darkness @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Auto Blur @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Netherwalk @ HP%", 0, 100, 5));
            Settings.Add(new Setting("Sigils Cast:", m_CastingList, "Player"));
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

            Aimsharp.PrintMessage("Epic PVE - Demon Hunter Havoc", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/demon-hunter/havoc/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " ChaosNova - Casts Chaos Nova @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FelEruption - Casts Fel Eruption @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Darkness - Casts Darkness @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Imprison - Casts Imprison @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FelRush - Casts Fel Rush @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Felblade - Casts Felblade @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " SigilofFlame - Casts Sigil of Flame @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " SigilofMisery - Casts Sigil of Misery @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);

            Language = GetDropDown("Game Client Language");

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
            m_DebuffsList = new List<string> { Imprison_SpellName(Language), };
            m_BuffsList = new List<string> { Netherwalk_SpellName(Language), };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language) };
            m_SpellBook_General = new List<string> {
                //Covenants
                ElysianDecree_SpellName(Language), //390163
                FodderToTheFlame_SpellName(Language), //329554
                TheHunt_SpellName(Language), //370965
                SinfulBrand_SpellName(Language), //317009

                //Interrupt
                Disrupt_SpellName(Language), //183752

                //General
                Annihilation_SpellName(Language), //201427
                BladeDance_SpellName(Language), //188499
                Blur_SpellName(Language), //198589
                ChaosNova_SpellName(Language), //179057
                ChaosStrike_SpellName(Language), //162794
                CollectiveAnguish_SpellName(Language), //390152
                ConsumeMagic_SpellName(Language), //278326
                Darkness_SpellName(Language), //196718
                DeathSweep_SpellName(Language), //210152
                DemonsBite_SpellName(Language), //162243
                EssenceBreak_SpellName(Language), //258860
                EyeBeam_SpellName(Language), //198013
                FelBarrage_SpellName(Language), //258925
                FelEruption_SpellName(Language), //211881
                FelRush_SpellName(Language), //195072
                Felblade_SpellName(Language), //232893
                GlaiveTempest_SpellName(Language), //342817
                ImmolationAura_SpellName(Language), //258920
                Imprison_SpellName(Language), //217832
                Metamorphosis_SpellName(Language), //191427
                Netherwalk_SpellName(Language), //196555
                SigilOfFlame_SpellName(Language), //204596
                SigilOfMisery_SpellName(Language), //207684
                ThrowGlaive_SpellName(Language), //185123
                Torment_SpellName(Language), //185245
                VengefulRetreat_SpellName(Language), //198793
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

            if (Aimsharp.IsCustomCodeOn("SigilofFlame") && Aimsharp.SpellCooldown(SigilOfFlame_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("SigilofMisery") && Aimsharp.SpellCooldown(SigilOfMisery_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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

            //Auto Darkness
            if (Aimsharp.CanCast(Darkness_SpellName(Language), "player", false, true) && !Aimsharp.HasBuff(Netherwalk_SpellName(Language), "player", true))
            {
                if (PlayerHP <= GetSlider("Auto Darkness @ HP%"))
                {
                    Aimsharp.Cast(Darkness_SpellName(Language));
                    return true;
                }
            }

            //Auto Blur
            if (Aimsharp.CanCast(Blur_SpellName(Language), "player", false, true) && !Aimsharp.HasBuff(Netherwalk_SpellName(Language), "player", true))
            {
                if (PlayerHP <= GetSlider("Auto Blur @ HP%"))
                {
                    Aimsharp.Cast(Blur_SpellName(Language));
                    return true;
                }
            }

            //Auto Netherwalk
            if (Aimsharp.CanCast(Netherwalk_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Netherwalk @ HP%"))
                {
                    Aimsharp.Cast(Netherwalk_SpellName(Language));
                    return true;
                }
            }
            #endregion

            #region Queues
            //Queues
            bool FelRush = Aimsharp.IsCustomCodeOn("FelRush");
            //Queue Fel Rush
            if (FelRush && (Aimsharp.SpellCooldown(FelRush_SpellName(Language)) - Aimsharp.GCD() > 1000 && Aimsharp.SpellCharges(FelRush_SpellName(Language)) == 0 || Aimsharp.RechargeTime(FelRush_SpellName(Language)) > 9500 && Aimsharp.SpellCharges(FelRush_SpellName(Language)) == 1))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fel Rush queue toggle", Color.Purple);
                }
                Aimsharp.Cast("FelRushOff");
                return true;
            }

            if (FelRush && Aimsharp.CanCast(FelRush_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fel Rush through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(FelRush_SpellName(Language));
                return true;
            }

            bool Felblade = Aimsharp.IsCustomCodeOn("Felblade");
            //Queue Felblade
            if (Felblade && Aimsharp.SpellCooldown(Felblade_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Felblade queue toggle", Color.Purple);
                }
                Aimsharp.Cast("FelbladeOff");
                return true;
            }

            if (Felblade && Aimsharp.CanCast(Felblade_SpellName(Language), "target", true, true) && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Felblade through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Felblade_SpellName(Language));
                return true;
            }

            bool ChaosNova = Aimsharp.IsCustomCodeOn("ChaosNova");
            //Queue Chaos Nova
            if (ChaosNova && Aimsharp.SpellCooldown(ChaosNova_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Chaos Nova queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ChaosNovaOff");
                return true;
            }

            if (ChaosNova && Aimsharp.CanCast(ChaosNova_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Chaos Nova through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(ChaosNova_SpellName(Language));
                return true;
            }

            bool FelEruption = Aimsharp.IsCustomCodeOn("FelEruption");
            //Queue Fel Eruption
            if (FelEruption && Aimsharp.SpellCooldown(FelEruption_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fel Eruption queue toggle", Color.Purple);
                }
                Aimsharp.Cast("FelEruptionOff");
                return true;
            }

            if (FelEruption && Aimsharp.CanCast(FelEruption_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fel Eruption through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(FelEruption_SpellName(Language));
                return true;
            }

            bool Darkness = Aimsharp.IsCustomCodeOn("Darkness");
            //Queue Darkness
            if (Darkness && Aimsharp.SpellCooldown(Darkness_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Darkness queue toggle", Color.Purple);
                }
                Aimsharp.Cast("DarknessOff");
                return true;
            }

            if (Darkness && Aimsharp.CanCast(Darkness_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Darkness through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Darkness_SpellName(Language));
                return true;
            }

            bool Imprison = Aimsharp.IsCustomCodeOn("Imprison");
            //Queue Imprison
            if (Imprison && Aimsharp.SpellCooldown(Imprison_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Imprison queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ImprisonOff");
                return true;
            }

            if (Imprison && Aimsharp.CanCast(Imprison_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Imprison through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Imprison_SpellName(Language));
                return true;
            }

            //Queue Sigil
            string SigilsCast = GetDropDown("Sigils Cast:");
            string ElysianDecreeCast = GetDropDown("Elysian Decree Cast:");
            bool SigilofFlame = Aimsharp.IsCustomCodeOn("SigilofFlame");
            bool SigilofMisery = Aimsharp.IsCustomCodeOn("SigilofMisery");
            if (Aimsharp.SpellCooldown(SigilOfFlame_SpellName(Language)) - Aimsharp.GCD() > 2000 && SigilofFlame)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sigil of Flame Queue", Color.Purple);
                }
                Aimsharp.Cast("SigilofFlameOff");
                return true;
            }
            if (SigilofFlame && Aimsharp.CanCast(SigilOfFlame_SpellName(Language), "player", false, true))
            {
                switch (SigilsCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Flame - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SigilOfFlame_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Flame - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofFlameP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Flame - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofFlameC");
                        return true;
                }
            }
            if (Aimsharp.SpellCooldown(SigilOfMisery_SpellName(Language)) - Aimsharp.GCD() > 2000 && SigilofMisery)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Death and Decay Queue", Color.Purple);
                }
                Aimsharp.Cast("SigilofMiseryOff");
                return true;
            }
            if (SigilofMisery && Aimsharp.CanCast(SigilOfMisery_SpellName(Language), "player", false, true))
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
                if (Wait <= 200 && !Aimsharp.HasDebuff(Imprison_SpellName(Language), "target", true) && !Imprison && !Felblade && !FelRush)
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
                    if ((SpellID1 == 28730 || SpellID1 == 25046 || SpellID1 == 50613 || SpellID1 == 69179 || SpellID1 == 80483 || SpellID1 == 129597) && Aimsharp.CanCast(ArcaneTorrent_SpellName(Language), "player", true, false) && MeleeRange)
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
                    //Covenants
                    if ((SpellID1 == 306830 || SpellID1 == 390163) && Aimsharp.CanCast(ElysianDecree_SpellName(Language), "player", false, true))
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

                    if (SpellID1 == 329554 && Aimsharp.CanCast(FodderToTheFlame_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fodder to the Flame - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FodderToTheFlame_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 323639 || SpellID1 == 370965) && Aimsharp.CanCast(TheHunt_SpellName(Language), "target", true, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting The Hunt - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TheHunt_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 317009 && Aimsharp.CanCast(SinfulBrand_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sinful Brand - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SinfulBrand_SpellName(Language));
                        return true;
                    }

                    #endregion

                    #region General Spells - NoGCD
                    //Class Spells
                    //Instant [GCD FREE]
                    if (SpellID1 == 6552 && Aimsharp.CanCast(Disrupt_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(Disrupt_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    //Instant [GCD]
                    ///Player

                    if (SpellID1 == 204596 && Aimsharp.CanCast(SigilOfFlame_SpellName(Language), "player", false, true))
                    {
                        switch (SigilsCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Sigil of Flame - " + SigilsCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast(SigilOfFlame_SpellName(Language));
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Sigil of Flame - " + SigilsCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("SigilofFlameP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Sigil of Flame - " + SigilsCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("SigilofFlameC");
                                return true;
                        }
                    }

                    if (SpellID1 == 207684 && Aimsharp.CanCast(SigilOfMisery_SpellName(Language), "player", false, true))
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

                    if (SpellID1 == 258920 && Aimsharp.CanCast(ImmolationAura_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 8)
                    {
                        Aimsharp.Cast(ImmolationAura_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 191427 && Aimsharp.CanCast(Metamorphosis_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast("MetamorphosisP");
                        return true;
                    }

                    if (SpellID1 == 198793 && Aimsharp.CanCast(VengefulRetreat_SpellName(Language), "player", false, true) && !Moving && !GetCheckBox("Suggest but don't cast Movement Based Abilities:"))
                    {
                        Aimsharp.Cast(VengefulRetreat_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 196555 && Aimsharp.CanCast(Netherwalk_SpellName(Language), "player", false, true) && !Moving && !GetCheckBox("Suggest but don't cast Movement Based Abilities:"))
                    {
                        Aimsharp.Cast(Netherwalk_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 196718 && Aimsharp.CanCast(Darkness_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(Darkness_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 185245 && Aimsharp.CanCast(Torment_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(Torment_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 198589 && Aimsharp.CanCast(Blur_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(Blur_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 195072 && Aimsharp.CanCast(FelRush_SpellName(Language), "player", false, true) && !Moving && !GetCheckBox("Suggest but don't cast Movement Based Abilities:"))
                    {
                        Aimsharp.Cast(FelRush_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 179057 && Aimsharp.CanCast(ChaosNova_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(ChaosNova_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 198013 && Aimsharp.CanCast(EyeBeam_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5 && !Moving)
                    {
                        Aimsharp.Cast(EyeBeam_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 342817 && Aimsharp.CanCast(GlaiveTempest_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(GlaiveTempest_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 390152 && Aimsharp.CanCast(CollectiveAnguish_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(CollectiveAnguish_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 258860 && Aimsharp.CanCast(EssenceBreak_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(EssenceBreak_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 258925 && Aimsharp.CanCast(FelBarrage_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(FelBarrage_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    ///Target
                    if (SpellID1 == 278326 && Aimsharp.CanCast(ConsumeMagic_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(ConsumeMagic_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 210152 && Aimsharp.CanCast(DeathSweep_SpellName(Language), "target", true, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(DeathSweep_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 201427 && Aimsharp.CanCast(Annihilation_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(Annihilation_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 162243 && Aimsharp.CanCast(DemonsBite_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(DemonsBite_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 162794 && Aimsharp.CanCast(ChaosStrike_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(ChaosStrike_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 188499 && Aimsharp.CanCast(BladeDance_SpellName(Language), "target", true, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(BladeDance_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 232893 && Aimsharp.CanCast(Felblade_SpellName(Language), "target", true, true) && !GetCheckBox("Suggest but don't cast Movement Based Abilities:"))
                    {
                        Aimsharp.Cast(Felblade_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 211881 && Aimsharp.CanCast(FelEruption_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(FelEruption_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 185123 && Aimsharp.CanCast(ThrowGlaive_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(ThrowGlaive_SpellName(Language));
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

            if (Aimsharp.IsCustomCodeOn("SigilofFlame") && Aimsharp.SpellCooldown(SigilOfFlame_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("SigilofMisery") && Aimsharp.SpellCooldown(SigilOfMisery_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            //Queues
            bool FelRush = Aimsharp.IsCustomCodeOn("FelRush");
            //Queue Fel Rush
            if (FelRush && (Aimsharp.SpellCooldown(FelRush_SpellName(Language)) - Aimsharp.GCD() > 1000 && Aimsharp.SpellCharges(FelRush_SpellName(Language)) == 0 || Aimsharp.RechargeTime(FelRush_SpellName(Language)) > 9500 && Aimsharp.SpellCharges(FelRush_SpellName(Language)) == 1))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fel Rush queue toggle", Color.Purple);
                }
                Aimsharp.Cast("FelRushOff");
                return true;
            }

            if (FelRush && Aimsharp.CanCast(FelRush_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fel Rush through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(FelRush_SpellName(Language));
                return true;
            }

            bool Felblade = Aimsharp.IsCustomCodeOn("Felblade");
            //Queue Felblade
            if (Felblade && Aimsharp.SpellCooldown(Felblade_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Felblade queue toggle", Color.Purple);
                }
                Aimsharp.Cast("FelbladeOff");
                return true;
            }

            if (Felblade && Aimsharp.CanCast(Felblade_SpellName(Language), "target", true, true) && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Felblade through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Felblade_SpellName(Language));
                return true;
            }

            bool ChaosNova = Aimsharp.IsCustomCodeOn("ChaosNova");
            //Queue Chaos Nova
            if (ChaosNova && Aimsharp.SpellCooldown(ChaosNova_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Chaos Nova queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ChaosNovaOff");
                return true;
            }

            if (ChaosNova && Aimsharp.CanCast(ChaosNova_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Chaos Nova through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(ChaosNova_SpellName(Language));
                return true;
            }

            bool FelEruption = Aimsharp.IsCustomCodeOn("FelEruption");
            //Queue Fel Eruption
            if (FelEruption && Aimsharp.SpellCooldown(FelEruption_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fel Eruption queue toggle", Color.Purple);
                }
                Aimsharp.Cast("FelEruptionOff");
                return true;
            }

            if (FelEruption && Aimsharp.CanCast(FelEruption_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fel Eruption through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(FelEruption_SpellName(Language));
                return true;
            }

            bool Darkness = Aimsharp.IsCustomCodeOn("Darkness");
            //Queue Darkness
            if (Darkness && Aimsharp.SpellCooldown(Darkness_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Darkness queue toggle", Color.Purple);
                }
                Aimsharp.Cast("DarknessOff");
                return true;
            }

            if (Darkness && Aimsharp.CanCast(Darkness_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Darkness through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Darkness_SpellName(Language));
                return true;
            }

            bool Imprison = Aimsharp.IsCustomCodeOn("Imprison");
            //Queue Imprison
            if (Imprison && Aimsharp.SpellCooldown(Imprison_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Imprison queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ImprisonOff");
                return true;
            }

            if (Imprison && Aimsharp.CanCast(Imprison_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Imprison through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Imprison_SpellName(Language));
                return true;
            }

            //Queue Sigil
            string SigilsCast = GetDropDown("Sigils Cast:");
            bool SigilofFlame = Aimsharp.IsCustomCodeOn("SigilofFlame");
            bool SigilofMisery = Aimsharp.IsCustomCodeOn("SigilofMisery");
            if (Aimsharp.SpellCooldown(SigilOfFlame_SpellName(Language)) - Aimsharp.GCD() > 2000 && SigilofFlame)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sigil of Flame Queue", Color.Purple);
                }
                Aimsharp.Cast("SigilofFlameOff");
                return true;
            }
            if (SigilofFlame && Aimsharp.CanCast(SigilOfFlame_SpellName(Language), "player", false, true))
            {
                switch (SigilsCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Flame - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SigilOfFlame_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Flame - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofFlameP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sigil of Flame - " + SigilsCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SigilofFlameC");
                        return true;
                }
            }
            if (Aimsharp.SpellCooldown(SigilOfMisery_SpellName(Language)) - Aimsharp.GCD() > 2000 && SigilofMisery)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sigil of Misery Queue", Color.Purple);
                }
                Aimsharp.Cast("SigilofMiseryOff");
                return true;
            }
            if (SigilofMisery && Aimsharp.CanCast(SigilOfMisery_SpellName(Language), "player", false, true))
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
            #endregion

            #region Out of Combat Spells
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 6 && TargetInCombat && !Imprison && !Aimsharp.HasBuff(Imprison_SpellName(Language), "player", true))
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