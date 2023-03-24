using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpichamanElementalHekili : Rotation
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

        ///<summary>spell=108281</summary>
        private static string AncestralGuidance_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ancestral Guidance";
                case "Deutsch": return "Führung der Ahnen";
                case "Español": return "Guía ancestral";
                case "Français": return "Soutien ancestral";
                case "Italiano": return "Guida Ancestrale";
                case "Português Brasileiro": return "Conselho dos Ancestrais";
                case "Русский": return "Наставления предков";
                case "한국어": return "고대의 인도";
                case "简体中文": return "先祖指引";
                default: return "Ancestral Guidance";
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

        ///<summary>spell=114050</summary>
        private static string Ascendance_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ascendance";
                case "Deutsch": return "Aszendenz";
                case "Español": return "Ascensión";
                case "Français": return "Ascendance";
                case "Italiano": return "Ascesa";
                case "Português Brasileiro": return "Ascendência";
                case "Русский": return "Перерождение";
                case "한국어": return "승천";
                case "简体中文": return "升腾";
                default: return "Ascendance";
            }
        }

        ///<summary>spell=108271</summary>
        private static string AstralShift_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Astral Shift";
                case "Deutsch": return "Astralverschiebung";
                case "Español": return "Cambio astral";
                case "Français": return "Transfert astral";
                case "Italiano": return "Sentiero Astrale";
                case "Português Brasileiro": return "Transição Astral";
                case "Русский": return "Астральный сдвиг";
                case "한국어": return "영혼 이동";
                case "简体中文": return "星界转移";
                default: return "Astral Shift";
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

        ///<summary>spell=192058</summary>
        private static string CapacitorTotem_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Capacitor Totem";
                case "Deutsch": return "Totem der Energiespeicherung";
                case "Español": return "Tótem capacitador";
                case "Français": return "Totem condensateur";
                case "Italiano": return "Totem della Condensazione Elettrica";
                case "Português Brasileiro": return "Totem Capacitor";
                case "Русский": return "Тотем конденсации";
                case "한국어": return "축전 토템";
                case "简体中文": return "电能图腾";
                default: return "Capacitor Totem";
            }
        }

        ///<summary>spell=320674</summary>
        private static string ChainHarvest_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Chain Harvest";
                case "Deutsch": return "Kettenernte";
                case "Español": return "Cosecha en cadena";
                case "Français": return "Moisson en chaîne";
                case "Italiano": return "Raccolto a Catena";
                case "Português Brasileiro": return "Ceifa Encadeada";
                case "Русский": return "Цепная жатва";
                case "한국어": return "연쇄 수확";
                case "简体中文": return "收割链";
                default: return "Chain Harvest";
            }
        }

        ///<summary>spell=188443</summary>
        private static string ChainLightning_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Chain Lightning";
                case "Deutsch": return "Kettenblitzschlag";
                case "Español": return "Cadena de relámpagos";
                case "Français": return "Chaîne d’éclairs";
                case "Italiano": return "Catena di Fulmini";
                case "Português Brasileiro": return "Cadeia de Raios";
                case "Русский": return "Цепная молния";
                case "한국어": return "연쇄 번개";
                case "简体中文": return "闪电链";
                default: return "Chain Lightning";
            }
        }

        ///<summary>spell=51886</summary>
        private static string CleanseSpirit_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Cleanse Spirit";
                case "Deutsch": return "Geistläuterung";
                case "Español": return "Limpiar espíritu";
                case "Français": return "Purifier l'esprit";
                case "Italiano": return "Purificazione dello Spirito";
                case "Português Brasileiro": return "Purificar Espírito";
                case "Русский": return "Очищение духа";
                case "한국어": return "영혼 정화";
                case "简体中文": return "净化灵魂";
                default: return "Cleanse Spirit";
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

        ///<summary>spell=198103</summary>
        private static string EarthElemental_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Earth Elemental";
                case "Deutsch": return "Erdelementar";
                case "Español": return "Elemental de Tierra";
                case "Français": return "Élémentaire de terre";
                case "Italiano": return "Elementale della Terra";
                case "Português Brasileiro": return "Elemental da Terra";
                case "Русский": return "Элементаль земли";
                case "한국어": return "대지의 정령";
                case "简体中文": return "土元素";
                default: return "Earth Elemental";
            }
        }

        ///<summary>spell=8042</summary>
        private static string EarthShock_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Earth Shock";
                case "Deutsch": return "Erdschock";
                case "Español": return "Choque de tierra";
                case "Français": return "Horion de terre";
                case "Italiano": return "Folgore della Terra";
                case "Português Brasileiro": return "Choque Terreno";
                case "Русский": return "Земной шок";
                case "한국어": return "대지 충격";
                case "简体中文": return "大地震击";
                default: return "Earth Shock";
            }
        }

        ///<summary>spell=2484</summary>
        private static string EarthbindTotem_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Earthbind Totem";
                case "Deutsch": return "Totem der Erdbindung";
                case "Español": return "Tótem Nexo Terrestre";
                case "Français": return "Totem de lien terrestre";
                case "Italiano": return "Totem del Vincolo Terrestre";
                case "Português Brasileiro": return "Totem de Prisão Terrena";
                case "Русский": return "Тотем оков земли";
                case "한국어": return "속박의 토템";
                case "简体中文": return "地缚图腾";
                default: return "Earthbind Totem";
            }
        }

        ///<summary>spell=61882</summary>
        private static string Earthquake_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Earthquake";
                case "Deutsch": return "Erdbeben";
                case "Español": return "Terremoto";
                case "Français": return "Séisme";
                case "Italiano": return "Terremoto";
                case "Português Brasileiro": return "Terremoto";
                case "Русский": return "Землетрясение";
                case "한국어": return "지진";
                case "简体中文": return "地震术";
                default: return "Earthquake";
            }
        }

        ///<summary>spell=320125</summary>
        private static string EchoingShock_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Echoing Shock";
                case "Deutsch": return "Widerhallender Schock";
                case "Español": return "Descarga resonante";
                case "Français": return "Écho électrique";
                case "Italiano": return "Folgore Echeggiante";
                case "Português Brasileiro": return "Choque Ecoante";
                case "Русский": return "Вторящий шок";
                case "한국어": return "메아리치는 충격";
                case "简体中文": return "回响震击";
                default: return "Echoing Shock";
            }
        }

        ///<summary>spell=117014</summary>
        private static string ElementalBlast_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Elemental Blast";
                case "Deutsch": return "Elementarschlag";
                case "Español": return "Explosión elemental";
                case "Français": return "Explosion élémentaire";
                case "Italiano": return "Detonazione Elementale";
                case "Português Brasileiro": return "Impacto Elemental";
                case "Русский": return "Удар духов стихий";
                case "한국어": return "정기 작렬";
                case "简体中文": return "元素冲击";
                default: return "Elemental Blast";
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

        ///<summary>spell=328923</summary>
        private static string FaeTransfusion_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fae Transfusion";
                case "Deutsch": return "Faetransfusion";
                case "Español": return "Transfusión de sílfide";
                case "Français": return "Transfusion faërique";
                case "Italiano": return "Trasfusione dei Silfi";
                case "Português Brasileiro": return "Transfusão Feéria";
                case "Русский": return "Волшебное переливание";
                case "한국어": return "페이 수혈";
                case "简体中文": return "法夜输灵";
                default: return "Fae Transfusion";
            }
        }

        ///<summary>spell=198067</summary>
        private static string FireElemental_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fire Elemental";
                case "Deutsch": return "Feuerelementar";
                case "Español": return "Elemental de Fuego";
                case "Français": return "Élémentaire de feu";
                case "Italiano": return "Elementale del Fuoco";
                case "Português Brasileiro": return "Elemental do Fogo";
                case "Русский": return "Элементаль огня";
                case "한국어": return "불의 정령";
                case "简体中文": return "火元素";
                default: return "Fire Elemental";
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

        ///<summary>spell=188389</summary>
        private static string FlameShock_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Flame Shock";
                case "Deutsch": return "Flammenschock";
                case "Español": return "Choque de llamas";
                case "Français": return "Horion de flammes";
                case "Italiano": return "Folgore del Fuoco";
                case "Português Brasileiro": return "Choque Flamejante";
                case "Русский": return "Огненный шок";
                case "한국어": return "화염 충격";
                case "简体中文": return "烈焰震击";
                default: return "Flame Shock";
            }
        }

        ///<summary>spell=318038</summary>
        private static string FlametongueWeapon_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Flametongue Weapon";
                case "Deutsch": return "Waffe der Flammenzunge";
                case "Español": return "Arma Lengua de Fuego";
                case "Français": return "Arme langue de feu";
                case "Italiano": return "Arma della Lingua di Fuoco";
                case "Português Brasileiro": return "Arma de Labaredas";
                case "Русский": return "Оружие языка пламени";
                case "한국어": return "불꽃혓바닥 무기";
                case "简体中文": return "火舌武器";
                default: return "Flametongue Weapon";
            }
        }

        ///<summary>spell=196840</summary>
        private static string FrostShock_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Frost Shock";
                case "Deutsch": return "Frostschock";
                case "Español": return "Choque de Escarcha";
                case "Français": return "Horion de givre";
                case "Italiano": return "Folgore del Gelo";
                case "Português Brasileiro": return "Choque Gélido";
                case "Русский": return "Ледяной шок";
                case "한국어": return "냉기 충격";
                case "简体中文": return "冰霜震击";
                default: return "Frost Shock";
            }
        }

        ///<summary>spell=2645</summary>
        private static string GhostWolf_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ghost Wolf";
                case "Deutsch": return "Geisterwolf";
                case "Español": return "Lobo fantasmal";
                case "Français": return "Loup fantôme";
                case "Italiano": return "Lupo Spettrale";
                case "Português Brasileiro": return "Lobo Fantasma";
                case "Русский": return "Призрачный волк";
                case "한국어": return "늑대 정령";
                case "简体中文": return "幽魂之狼";
                default: return "Ghost Wolf";
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

        ///<summary>spell=378773</summary>
        private static string GreaterPurge_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Greater Purge";
                case "Deutsch": return "Großes Reinigen";
                case "Español": return "Purgar superior";
                case "Français": return "Purge supérieure";
                case "Italiano": return "Epurazione Superiore";
                case "Português Brasileiro": return "Expurgo Maior";
                case "Русский": return "Великое очищение";
                case "한국어": return "상급 정화";
                case "简体中文": return "强效净化术";
                default: return "Greater Purge";
            }
        }

        ///<summary>spell=5394</summary>
        private static string HealingStreamTotem_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Healing Stream Totem";
                case "Deutsch": return "Totem des heilenden Flusses";
                case "Español": return "Tótem Corriente de sanación";
                case "Français": return "Totem guérisseur";
                case "Italiano": return "Totem del Flusso Vitale";
                case "Português Brasileiro": return "Totem de Torrente Curativa";
                case "Русский": return "Тотем исцеляющего потока";
                case "한국어": return "치유의 토템";
                case "简体中文": return "治疗之泉图腾";
                default: return "Healing Stream Totem";
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

        ///<summary>spell=51514</summary>
        private static string Hex_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Hex";
                case "Deutsch": return "Verhexen";
                case "Español": return "Maleficio";
                case "Français": return "Maléfice";
                case "Italiano": return "Maleficio";
                case "Português Brasileiro": return "Bagata";
                case "Русский": return "Сглаз";
                case "한국어": return "사술";
                case "简体中文": return "妖术";
                default: return "Hex";
            }
        }

        ///<summary>spell=210714</summary>
        private static string Icefury_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Icefury";
                case "Deutsch": return "Eisfuror";
                case "Español": return "Hielofuria";
                case "Français": return "Furie-de-glace";
                case "Italiano": return "Furiagelida";
                case "Português Brasileiro": return "Algifúria";
                case "Русский": return "Ледяная ярость";
                case "한국어": return "얼음격노";
                case "简体中文": return "冰怒";
                default: return "Icefury";
            }
        }

        ///<summary>spell=114074</summary>
        private static string LavaBeam_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Lava Beam";
                case "Deutsch": return "Lavastrahl";
                case "Español": return "Haz de lava";
                case "Français": return "Faisceau de lave";
                case "Italiano": return "Catena di Lava";
                case "Português Brasileiro": return "Feixe de Lava";
                case "Русский": return "Поток лавы";
                case "한국어": return "용암 광선";
                case "简体中文": return "熔岩弹射";
                default: return "Lava Beam";
            }
        }

        ///<summary>spell=51505</summary>
        private static string LavaBurst_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Lava Burst";
                case "Deutsch": return "Lavaeruption";
                case "Español": return "Ráfaga de lava";
                case "Français": return "Explosion de lave";
                case "Italiano": return "Getto di Lava";
                case "Português Brasileiro": return "Estouro de Lava";
                case "Русский": return "Выброс лавы";
                case "한국어": return "용암 폭발";
                case "简体中文": return "熔岩爆裂";
                default: return "Lava Burst";
            }
        }

        ///<summary>spell=188196</summary>
        private static string LightningBolt_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Lightning Bolt";
                case "Deutsch": return "Blitzschlag";
                case "Español": return "Descarga de relámpagos";
                case "Français": return "Éclair";
                case "Italiano": return "Dardo Fulminante";
                case "Português Brasileiro": return "Raio";
                case "Русский": return "Молния";
                case "한국어": return "번개 화살";
                case "简体中文": return "闪电箭";
                default: return "Lightning Bolt";
            }
        }

        ///<summary>spell=305483</summary>
        private static string LightningLasso_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Lightning Lasso";
                case "Deutsch": return "Blitzschlaglasso";
                case "Español": return "Lazo de relámpagos";
                case "Français": return "Lasso de foudre";
                case "Italiano": return "Lazo Fulminante";
                case "Português Brasileiro": return "Laço de Raio";
                case "Русский": return "Молния-лассо";
                case "한국어": return "번개 올가미";
                case "简体中文": return "闪电磁索";
                default: return "Lightning Lasso";
            }
        }

        ///<summary>spell=192106</summary>
        private static string LightningShield_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Lightning Shield";
                case "Deutsch": return "Blitzschlagschild";
                case "Español": return "Escudo de relámpagos";
                case "Français": return "Bouclier de foudre";
                case "Italiano": return "Scudo di Fulmini";
                case "Português Brasileiro": return "Escudo de Raios";
                case "Русский": return "Щит молний";
                case "한국어": return "번개 보호막";
                case "简体中文": return "闪电之盾";
                default: return "Lightning Shield";
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

        ///<summary>spell=192222</summary>
        private static string LiquidMagmaTotem_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Liquid Magma Totem";
                case "Deutsch": return "Totem des flüssigen Magmas";
                case "Español": return "Tótem de Magma líquido";
                case "Français": return "Totem de magma liquide";
                case "Italiano": return "Totem del Magma Liquido";
                case "Português Brasileiro": return "Totem de Magma Líquido";
                case "Русский": return "Тотем жидкой магмы";
                case "한국어": return "마그마 토템";
                case "简体中文": return "岩浆图腾";
                default: return "Liquid Magma Totem";
            }
        }

        ///<summary>spell=117588</summary>
        private static string Meteor_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Meteor";
                case "Deutsch": return "Meteor";
                case "Español": return "Meteoro";
                case "Français": return "Météore";
                case "Italiano": return "Meteora";
                case "Português Brasileiro": return "Meteoro";
                case "Русский": return "Метеорит";
                case "한국어": return "유성";
                case "简体中文": return "流星";
                default: return "Meteor";
            }
        }

        ///<summary>spell=378081</summary>
        private static string NaturesSwiftness_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Nature's Swiftness";
                case "Deutsch": return "Schnelligkeit der Natur";
                case "Español": return "Presteza de la Naturaleza";
                case "Français": return "Rapidité de la nature";
                case "Italiano": return "Rapidità della Natura";
                case "Português Brasileiro": return "Rapidez da Natureza";
                case "Русский": return "Природная стремительность";
                case "한국어": return "자연의 신속함";
                case "简体中文": return "自然迅捷";
                default: return "Nature's Swiftness";
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

        ///<summary>spell=73899</summary>
        private static string PrimalStrike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Primal Strike";
                case "Deutsch": return "Urtümlicher Schlag";
                case "Español": return "Golpe primigenio";
                case "Français": return "Frappe primordiale";
                case "Italiano": return "Assalto Primordiale";
                case "Português Brasileiro": return "Golpe Primevo";
                case "Русский": return "Стихийный удар";
                case "한국어": return "원시의 일격";
                case "简体中文": return "根源打击";
                default: return "Primal Strike";
            }
        }

        ///<summary>spell=326059</summary>
        private static string PrimordialWave_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Primordial Wave";
                case "Deutsch": return "Urzeitliche Welle";
                case "Español": return "Oleada primigenia";
                case "Français": return "Vague primordiale";
                case "Italiano": return "Ondata Primordiale";
                case "Português Brasileiro": return "Onda Primordial";
                case "Русский": return "Первозданная волна";
                case "한국어": return "태고의 파도";
                case "简体中文": return "始源之潮";
                default: return "Primordial Wave";
            }
        }

        ///<summary>spell=370</summary>
        private static string Purge_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Purge";
                case "Deutsch": return "Reinigen";
                case "Español": return "Purgar";
                case "Français": return "Purge";
                case "Italiano": return "Epurazione";
                case "Português Brasileiro": return "Expurgar";
                case "Русский": return "Развеивание магии";
                case "한국어": return "정화";
                case "简体中文": return "净化术";
                default: return "Purge";
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

        ///<summary>spell=79206</summary>
        private static string SpiritwalkersGrace_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Spiritwalker's Grace";
                case "Deutsch": return "Gunst des Geistwandlers";
                case "Español": return "Gracia del caminaespíritus";
                case "Français": return "Grâce du marcheur des esprits";
                case "Italiano": return "Grazia dello Spiritista";
                case "Português Brasileiro": return "Graça do Andarilho Espiritual";
                case "Русский": return "Благосклонность предков";
                case "한국어": return "영혼나그네의 은총";
                case "简体中文": return "灵魂行者的恩赐";
                default: return "Spiritwalker's Grace";
            }
        }

        ///<summary>spell=342243</summary>
        private static string StaticDischarge_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Static Discharge";
                case "Deutsch": return "Statische Entladung";
                case "Español": return "Descarga estática";
                case "Français": return "Décharge statique";
                case "Italiano": return "Scarica Statica";
                case "Português Brasileiro": return "Descarga Estática";
                case "Русский": return "Статический разряд";
                case "한국어": return "전하 방출";
                case "简体中文": return "静电释放";
                default: return "Static Discharge";
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

        ///<summary>spell=192249</summary>
        private static string StormElemental_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Storm Elemental";
                case "Deutsch": return "Sturmelementar";
                case "Español": return "Elemental de tormenta";
                case "Français": return "Élémentaire de tempête";
                case "Italiano": return "Elementale della Tempesta";
                case "Português Brasileiro": return "Elemental da Tempestade";
                case "Русский": return "Элементаль бури";
                case "한국어": return "폭풍의 정령";
                case "简体中文": return "风暴元素";
                default: return "Storm Elemental";
            }
        }

        ///<summary>spell=191634</summary>
        private static string Stormkeeper_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Stormkeeper";
                case "Deutsch": return "Sturmhüter";
                case "Español": return "Guardia de la Tormenta";
                case "Français": return "Gardien des tempêtes";
                case "Italiano": return "Custode della Tempesta";
                case "Português Brasileiro": return "Guardião da Tempestade";
                case "Русский": return "Хранитель бурь";
                case "한국어": return "폭풍수호자";
                case "简体中文": return "风暴守护者";
                default: return "Stormkeeper";
            }
        }

        ///<summary>spell=157375</summary>
        private static string Tempest_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Tempest";
                case "Deutsch": return "Sturmgewitter";
                case "Español": return "Tempestad";
                case "Français": return "Tempête";
                case "Italiano": return "Tempesta";
                case "Português Brasileiro": return "Tormenta";
                case "Русский": return "Буря";
                case "한국어": return "폭풍";
                case "简体中文": return "狂风怒号";
                default: return "Tempest";
            }
        }

        ///<summary>spell=51490</summary>
        private static string Thunderstorm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Thunderstorm";
                case "Deutsch": return "Gewitter";
                case "Español": return "Tormenta de truenos";
                case "Français": return "Orage";
                case "Italiano": return "Esplosione Tonante";
                case "Português Brasileiro": return "Tempestade Relampejante";
                case "Русский": return "Гром и молния";
                case "한국어": return "천둥폭풍";
                case "简体中文": return "雷霆风暴";
                default: return "Thunderstorm";
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

        ///<summary>spell=8143</summary>
        private static string TremorTotem_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Tremor Totem";
                case "Deutsch": return "Totem des Erdstoßes";
                case "Español": return "Tótem de tremor";
                case "Français": return "Totem de séisme";
                case "Italiano": return "Totem del Tremore";
                case "Português Brasileiro": return "Totem Sísmico";
                case "Русский": return "Тотем трепета";
                case "한국어": return "진동의 토템";
                case "简体中文": return "战栗图腾";
                default: return "Tremor Totem";
            }
        }

        ///<summary>spell=324386</summary>
        private static string VesperTotem_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Vesper Totem";
                case "Deutsch": return "Vespertotem";
                case "Español": return "Tótem de campana de vísperas";
                case "Français": return "Totem carillonneur";
                case "Italiano": return "Totem del Vespro";
                case "Português Brasileiro": return "Totem de Véspera";
                case "Русский": return "Тотем вечернего колокола";
                case "한국어": return "만과 토템";
                case "简体中文": return "暮钟图腾";
                default: return "Vesper Totem";
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

        ///<summary>spell=192077</summary>
        private static string WindRushTotem_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Wind Rush Totem";
                case "Deutsch": return "Totem des Windsturms";
                case "Español": return "Tótem de Carga de viento";
                case "Français": return "Totem de bouffée de vent";
                case "Italiano": return "Totem del Soffio di Vento";
                case "Português Brasileiro": return "Totem de Rajada de Vento";
                case "Русский": return "Тотем ветряного порыва";
                case "한국어": return "바람 질주 토템";
                case "简体中文": return "狂风图腾";
                default: return "Wind Rush Totem";
            }
        }

        ///<summary>spell=57994</summary>
        private static string WindShear_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Wind Shear";
                case "Deutsch": return "Windstoß";
                case "Español": return "Corte de viento";
                case "Français": return "Cisaille de vent";
                case "Italiano": return "Raffica di Vento";
                case "Português Brasileiro": return "Rajada de Vento";
                case "Русский": return "Пронизывающий ветер";
                case "한국어": return "날카로운 바람";
                case "简体中文": return "风剪";
                default: return "Wind Shear";
            }
        }

        ///<summary>spell=33757</summary>
        private static string WindfuryWeapon_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Windfury Weapon";
                case "Deutsch": return "Waffe des Windzorns";
                case "Español": return "Arma Viento furioso";
                case "Français": return "Arme Furie-des-vents";
                case "Italiano": return "Arma della Furia del Vento";
                case "Português Brasileiro": return "Arma de Fúria dos Ventos";
                case "Русский": return "Оружие неистовства ветра";
                case "한국어": return "질풍의 무기";
                case "简体中文": return "风怒武器";
                default: return "Windfury Weapon";
            }
        }
        #endregion
        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle", "NoDecurse", "EarthbindTotem", "WindRushTotem", "CapacitorTotem", "TremorTotem", "Hex", "EarthElemental", "FireElemental", "VesperTotem", "FaeTransfusion", "LiquidMagmaTotem", "Earthquake", "Thunderstorm"};
        private List<string> m_DebuffsList;
        private List<string> m_BuffsList;
        private List<string> m_ItemsList;
        private List<string> m_SpellBook_General;

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

            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");
            Macros.Add("CS_FOC", "/cast [@focus] " + CleanseSpirit_SpellName(Language));

            //Queues
            Macros.Add("EarthbindTotemOff", "/" + FiveLetters + " EarthbindTotem");
            Macros.Add("EarthbindTotemC", "/cast [@cursor] " + EarthbindTotem_SpellName(Language));
            Macros.Add("EarthbindTotemP", "/cast [@player] " + EarthbindTotem_SpellName(Language));

            Macros.Add("CapacitorTotemOff", "/" + FiveLetters + " CapacitorTotem");
            Macros.Add("CapacitorTotemC", "/cast [@cursor] " + CapacitorTotem_SpellName(Language));
            Macros.Add("CapacitorTotemP", "/cast [@player] " + CapacitorTotem_SpellName(Language));

            Macros.Add("WindRushTotemOff", "/" + FiveLetters + " WindRushTotem");
            Macros.Add("WindRushTotemC", "/cast [@cursor] " + WindRushTotem_SpellName(Language));
            Macros.Add("WindRushTotemP", "/cast [@player] " + WindRushTotem_SpellName(Language));

            Macros.Add("LiquidMagmaTotemOff", "/" + FiveLetters + " LiquidMagmaTotem");
            Macros.Add("LiquidMagmaTotemC", "/cast [@cursor] " + LiquidMagmaTotem_SpellName(Language));
            Macros.Add("LiquidMagmaTotemP", "/cast [@player] " + LiquidMagmaTotem_SpellName(Language));

            Macros.Add("EarthquakeOff", "/" + FiveLetters + " Earthquake");
            Macros.Add("EarthquakeC", "/cast [@cursor] " + Earthquake_SpellName(Language));
            Macros.Add("EarthquakeP", "/cast [@player] " + Earthquake_SpellName(Language));

            Macros.Add("VesperTotemOff", "/" + FiveLetters + " VesperTotem");
            Macros.Add("VesperTotemC", "/cast [@cursor] " + VesperTotem_SpellName(Language));
            Macros.Add("VesperTotemP", "/cast [@player] " + VesperTotem_SpellName(Language));

            Macros.Add("FaeTransfusionOff", "/" + FiveLetters + " FaeTransfusion");
            Macros.Add("FaeTransfusionC", "/cast [@cursor] " + FaeTransfusion_SpellName(Language));
            Macros.Add("FaeTransfusionP", "/cast [@player] " + FaeTransfusion_SpellName(Language));

            Macros.Add("HexOff", "/" + FiveLetters + " Hex");
            Macros.Add("HexMO", "/cast [@mouseover] " + Hex_SpellName(Language));

            Macros.Add("EarthElementalOff", "/" + FiveLetters + " EarthElemental");
            Macros.Add("FireElementalOff", "/" + FiveLetters + " FireElemental");
            Macros.Add("TremorTotemOff", "/" + FiveLetters + " TremorTotem");
            Macros.Add("ThunderstormOff", "/" + FiveLetters + " Thunderstorm");

            Macros.Add("PurgeMO", "/cast [@mouseover] " + Purge_SpellName(Language));

            Macros.Add("MacroMeteor", "/cast " + Meteor_SpellName(Language));
            Macros.Add("MacroTempest", "/cast " + Tempest_SpellName(Language));
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

            CustomFunctions.Add("HekiliEnemies", "if Hekili.State.active_enemies ~= nil and Hekili.State.active_enemies > 0 then return Hekili.State.active_enemies end return 0");

            CustomFunctions.Add("TargetIsMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitExists('target') and UnitIsDead('target') ~= true and UnitIsUnit('mouseover', 'target') then return 1 end; return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");

            CustomFunctions.Add("CycleNotEnabled", "local cycle = 0 if Hekili.State.settings.spec.cycle == true then cycle = 1 else if Hekili.State.settings.spec.cycle == false then cycle = 2 end end return cycle");

            CustomFunctions.Add("CurseCheck", "local y=0; " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"player\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" then y = y +1; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" then y = y +2; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" then y = y +4; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" then y = y +8; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" then y = y +16; end end " +
            "return y");

            CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
            "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
            "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
            "\nreturn foc");

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

            CustomFunctions.Add("PurgeCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Purge','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType,_,_,_  = UnitAura('mouseover', y, 'RAID') if debuffType == 'Magic' then markcheck = markcheck + 2 end end return markcheck end return 0");

            //CustomFunctions.Add("PurgeCheckTarget", "local markcheck = 0; if UnitExists('target') and UnitIsDead('target') ~= true and UnitAffectingCombat('target') and IsSpellInRange('Purge','target') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType,_,_,_  = UnitAura('target', y, 'RAID') if debuffType == 'Magic' then markcheck = markcheck + 2 end end return markcheck end return 0");

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
            Settings.Add(new Setting("Weapon Imbue Out of Combat:", true));
            Settings.Add(new Setting("Lightning Shield Out of Combat:", true));
            //Settings.Add(new Setting("Auto Purge Target:", true));
            Settings.Add(new Setting("Auto Purge Mouseover:", true));
            Settings.Add(new Setting("Auto Astral Shift @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Auto Ancestral Guidance @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Auto Healing Stream Totem @ HP%", 0, 100, 50));
            Settings.Add(new Setting("Earthquake Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Totem Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Covenant Cast:", m_CastingList, "Manual"));
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

            Aimsharp.PrintMessage("Epic PVE - Shaman Elemental", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/shaman/elemental/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoDecurse - Disables Decurse", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Hex - Casts Hex @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Thunderstorm - Casts Thunderstorm @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Earthquake - Casts Earthquake @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " EarthbindTotem - Casts Earthbind Totem @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " CapacitorTotem - Casts Capacitor Totem @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " WindRushTotem - Casts Wind Rush Totem @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " TremorTotem - Casts Tremor Totem @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FireElemental - Casts Fire Elemental @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " EarthElemental - Casts Earth Elemental @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " VesperTotem - Casts Vesper Totem @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FaeTransfusion - Casts Fae Transfusion @ next GCD", Color.Yellow);
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
            m_DebuffsList = new List<string> { };
            m_BuffsList = new List<string> { };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language) };
            m_SpellBook_General = new List<string> {
                //Covenants
                VesperTotem_SpellName(Language), //324386
                FaeTransfusion_SpellName(Language), //328923
                ChainHarvest_SpellName(Language), //320674
                PrimordialWave_SpellName(Language), //326059

                //Interrupt
                WindShear_SpellName(Language), //57994

                //General
                AstralShift_SpellName(Language), //108271
                CapacitorTotem_SpellName(Language), //192058
                ChainLightning_SpellName(Language), //188443
                EarthElemental_SpellName(Language), //198103
                EarthbindTotem_SpellName(Language), //2484
                FlameShock_SpellName(Language), //188389
                FlametongueWeapon_SpellName(Language), //318038
                FrostShock_SpellName(Language), //196840
                GhostWolf_SpellName(Language), //2645
                GreaterPurge_SpellName(Language), //378773
                HealingStreamTotem_SpellName(Language), //5394
                Hex_SpellName(Language), //51514
                LightningBolt_SpellName(Language), //188196
                LightningLasso_SpellName(Language),
                LightningShield_SpellName(Language), //192106
                NaturesSwiftness_SpellName(Language),
                PrimalStrike_SpellName(Language), //73899
                Purge_SpellName(Language), //370
                TremorTotem_SpellName(Language), //8143

                //Elemental
                AncestralGuidance_SpellName(Language), //108281
                Ascendance_SpellName(Language), //114050
                CleanseSpirit_SpellName(Language), //51886
                EarthShock_SpellName(Language), //8042
                Earthquake_SpellName(Language), //61882
                EchoingShock_SpellName(Language), //320125
                ElementalBlast_SpellName(Language), //117014
                FireElemental_SpellName(Language), //198067
                Icefury_SpellName(Language), //210714
                LavaBeam_SpellName(Language), //114074
                LavaBurst_SpellName(Language), //51505
                LiquidMagmaTotem_SpellName(Language), //192222
                Meteor_SpellName(Language), //117588
                SpiritwalkersGrace_SpellName(Language), //79206
                StaticDischarge_SpellName(Language), //342243
                StormElemental_SpellName(Language), //192249
                Stormkeeper_SpellName(Language), //191634
                Tempest_SpellName(Language), //157375
                Thunderstorm_SpellName(Language), //51490
                WindRushTotem_SpellName(Language), //192077

            };
            #endregion

            Totems.Add(HealingStreamTotem_SpellName(Language));

            InitializeMacros();

            InitializeSpells();

            InitializeCustomLUAFunctions();
        }

        public override bool CombatTick()
        {
            #region Declarations
            int SpellID1 = Aimsharp.CustomFunction("HekiliID1");
            int Wait = Aimsharp.CustomFunction("HekiliWait");
            int Enemies = Aimsharp.CustomFunction("HekiliEnemies");
            int TargetingGroup = Aimsharp.CustomFunction("GroupTargets");

            bool NoInterrupts = Aimsharp.IsCustomCodeOn("NoInterrupts");
            bool NoCycle = Aimsharp.IsCustomCodeOn("NoCycle");
            bool NoDecurse = Aimsharp.IsCustomCodeOn("NoDecurse");

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
            bool MeleeRange = Aimsharp.Range("target") <= 3;
            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());

            int AstralShiftHP = GetSlider("Auto Astral Shift @ HP%");
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

            #region Above Pause Checks
            if (Aimsharp.CastingID("player") == 51514 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Hex"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Hex Queue", Color.Purple);
                }
                Aimsharp.Cast("HexOff");
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

            if (Aimsharp.IsCustomCodeOn("EarthbindTotem") && Aimsharp.SpellCooldown(EarthbindTotem_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("CapacitorTotem") && Aimsharp.SpellCooldown(CapacitorTotem_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("WindRushTotem") && Aimsharp.SpellCooldown(WindRushTotem_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("LiquidMagmaTotem") && Aimsharp.SpellCooldown(LiquidMagmaTotem_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("Earthquake") && Aimsharp.SpellCooldown(Earthquake_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("VesperTotem") && Aimsharp.SpellCooldown(VesperTotem_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("FaeTransfusion") && Aimsharp.SpellCooldown(FaeTransfusion_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                if (Aimsharp.CanCast(WindShear_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(WindShear_SpellName(Language), true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast(WindShear_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(WindShear_SpellName(Language), true);
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

            //Auto Astral Shift
            if (PlayerHP <= AstralShiftHP && Aimsharp.CanCast(AstralShift_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Astral Shift - Player HP% " + PlayerHP + " due to setting being on HP% " + AstralShiftHP, Color.Purple);
                }
                Aimsharp.Cast(AstralShift_SpellName(Language), true);
                return true;
            }

            //Auto Ancestral Guidance
            if (UnitBelowThreshold(GetSlider("Auto Ancestral Guidance @ HP%")))
            {
                PartyDict.Clear();
                PartyDict.Add("player", Aimsharp.Health("player"));

                var partysize = Aimsharp.GroupSize();
                if (partysize <= 5)
                {
                    for (int i = 1; i < partysize; i++)
                    {
                        var partyunit = ("party" + i);
                        if (Aimsharp.Health(partyunit) > 0 && Aimsharp.Range(partyunit) <= 40)
                        {
                            PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                        }
                    }
                }

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    if (Aimsharp.CanCast(AncestralGuidance_SpellName(Language), "player", false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && Aimsharp.Health(unit.Key) <= GetSlider("Auto Ancestral Guidance @ HP%"))
                    {
                        Aimsharp.Cast(AncestralGuidance_SpellName(Language));
                        return true;
                    }
                }
            }

            //Auto Purge Mouseover
            if (Aimsharp.CanCast(Purge_SpellName(Language), "mouseover", true, true))
            {
                if (GetCheckBox("Auto Purge Mouseover:") && Aimsharp.CustomFunction("PurgeCheckMouseover") == 3)
                {
                    Aimsharp.Cast("PurgeMO");
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Purge on Mouseover", Color.Purple);
                    }
                    return true;
                }
            }
            #endregion

            #region Queues
            bool Thunderstorm = Aimsharp.IsCustomCodeOn("Thunderstorm");
            if (Aimsharp.SpellCooldown(Thunderstorm_SpellName(Language)) - Aimsharp.GCD() > 2000 && Thunderstorm)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Thunderstorm Queue", Color.Purple);
                }
                Aimsharp.Cast("ThunderstormOff");
                return true;
            }

            if (Thunderstorm && Aimsharp.CanCast(Thunderstorm_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Thunderstorm - Queue", Color.Purple);
                }
                Aimsharp.Cast(Thunderstorm_SpellName(Language));
                return true;
            }

            bool TremorTotem = Aimsharp.IsCustomCodeOn("TremorTotem");
            if (Aimsharp.SpellCooldown(TremorTotem_SpellName(Language)) - Aimsharp.GCD() > 2000 && TremorTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Tremor Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("TremorTotemOff");
                return true;
            }

            if (TremorTotem && Aimsharp.CanCast(TremorTotem_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Tremor Totem - Queue", Color.Purple);
                }
                Aimsharp.Cast(TremorTotem_SpellName(Language));
                return true;
            }

            bool FireElemental = Aimsharp.IsCustomCodeOn("FireElemental");
            if (Aimsharp.SpellCooldown(FireElemental_SpellName(Language)) - Aimsharp.GCD() > 2000 && FireElemental)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fire Elemental Queue", Color.Purple);
                }
                Aimsharp.Cast("FireElementalOff");
                return true;
            }

            if (FireElemental && Aimsharp.CanCast(FireElemental_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fire Elemental - Queue", Color.Purple);
                }
                Aimsharp.Cast(FireElemental_SpellName(Language));
                return true;
            }

            bool EarthElemental = Aimsharp.IsCustomCodeOn("EarthElemental");
            if (Aimsharp.SpellCooldown(EarthElemental_SpellName(Language)) - Aimsharp.GCD() > 2000 && EarthElemental)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Earth Elemental Queue", Color.Purple);
                }
                Aimsharp.Cast("EarthElementalOff");
                return true;
            }

            if (EarthElemental && Aimsharp.CanCast(EarthElemental_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Earth Elemental - Queue", Color.Purple);
                }
                Aimsharp.Cast(EarthElemental_SpellName(Language));
                return true;
            }

            bool Hex = Aimsharp.IsCustomCodeOn("Hex");
            if ((Aimsharp.SpellCooldown(Hex_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && Hex)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Hex Queue", Color.Purple);
                }
                Aimsharp.Cast("HexOff");
                return true;
            }

            if (Hex && Aimsharp.CanCast(Hex_SpellName(Language), "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Hex - Queue", Color.Purple);
                }
                Aimsharp.Cast("HexMO");
                return true;
            }

            string CovenantCast = GetDropDown("Covenant Cast:");
            bool VesperTotem = Aimsharp.IsCustomCodeOn("VesperTotem");
            if (Aimsharp.SpellCooldown(VesperTotem_SpellName(Language)) - Aimsharp.GCD() > 2000 && VesperTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Vesper Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("VesperTotemOff");
                return true;
            }

            if (VesperTotem && Aimsharp.CanCast(VesperTotem_SpellName(Language), "player", false, true))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(VesperTotem_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("VesperTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("VesperTotemP");
                        return true;
                }
            }

            bool FaeTransfusion = Aimsharp.IsCustomCodeOn("FaeTransfusion");
            if (Aimsharp.SpellCooldown(FaeTransfusion_SpellName(Language)) - Aimsharp.GCD() > 2000 && FaeTransfusion)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fae Transfusion Queue", Color.Purple);
                }
                Aimsharp.Cast("FaeTransfusionOff");
                return true;
            }

            if (FaeTransfusion && Aimsharp.CanCast(FaeTransfusion_SpellName(Language), "player", false, true))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(FaeTransfusion_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FaeTransfusionC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FaeTransfusionP");
                        return true;
                }
            }

            string TotemCast = GetDropDown("Totem Cast:");
            bool EarthbindTotem = Aimsharp.IsCustomCodeOn("EarthbindTotem");
            if (Aimsharp.SpellCooldown(EarthbindTotem_SpellName(Language)) - Aimsharp.GCD() > 2000 && EarthbindTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Earthbind Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("EarthbindTotemOff");
                return true;
            }

            if (EarthbindTotem && Aimsharp.CanCast(EarthbindTotem_SpellName(Language), "player", false, true))
            {
                switch (TotemCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthbind Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(EarthbindTotem_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthbind Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("EarthbindTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthbind Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("EarthbindTotemP");
                        return true;
                }
            }

            bool CapacitorTotem = Aimsharp.IsCustomCodeOn("CapacitorTotem");
            if (Aimsharp.SpellCooldown(CapacitorTotem_SpellName(Language)) - Aimsharp.GCD() > 2000 && CapacitorTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Capacitor Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("CapacitorTotemOff");
                return true;
            }

            if (CapacitorTotem && Aimsharp.CanCast(CapacitorTotem_SpellName(Language), "player", false, true))
            {
                switch (TotemCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Capacitor Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(CapacitorTotem_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Capacitor Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CapacitorTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Capacitor Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CapacitorTotemP");
                        return true;
                }
            }

            bool WindRushTotem = Aimsharp.IsCustomCodeOn("WindRushTotem");
            if (Aimsharp.SpellCooldown(WindRushTotem_SpellName(Language)) - Aimsharp.GCD() > 2000 && WindRushTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Wind Rush Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("WindRushTotemOff");
                return true;
            }

            if (WindRushTotem && Aimsharp.CanCast(WindRushTotem_SpellName(Language), "player", false, true))
            {
                switch (TotemCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wind Rush Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(WindRushTotem_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wind Rush Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WindRushTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wind Rush Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WindRushTotemP");
                        return true;
                }
            }

            bool LiquidMagmaTotem = Aimsharp.IsCustomCodeOn("LiquidMagmaTotem");
            if (Aimsharp.SpellCooldown(LiquidMagmaTotem_SpellName(Language)) - Aimsharp.GCD() > 2000 && LiquidMagmaTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Liquid Magma Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("LiquidMagmaTotemOff");
                return true;
            }

            if (LiquidMagmaTotem && Aimsharp.CanCast(LiquidMagmaTotem_SpellName(Language), "player", false, true))
            {
                switch (TotemCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Liquid Magma Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(LiquidMagmaTotem_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Liquid Magma Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("LiquidMagmaTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Liquid Magma Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("LiquidMagmaTotemP");
                        return true;
                }
            }

            string EarthquakeCast = GetDropDown("Earthquake Cast:");
            bool Earthquake = Aimsharp.IsCustomCodeOn("Earthquake");
            if ((Aimsharp.SpellCooldown(Earthquake_SpellName(Language)) - Aimsharp.GCD() > 2000 || Aimsharp.LastCast() == Earthquake_SpellName(Language)) && Earthquake)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Earthquake Queue", Color.Purple);
                }
                Aimsharp.Cast("EarthquakeOff");
                return true;
            }

            if (Earthquake && Aimsharp.CanCast(Earthquake_SpellName(Language), "player", false, true))
            {
                switch (EarthquakeCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthquake - " + EarthquakeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Earthquake_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthquake - " + EarthquakeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("EarthquakeC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthquake - " + EarthquakeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("EarthquakeP");
                        return true;
                }
            }
            #endregion

            #region Healing Totem
            if (UnitBelowThreshold(GetSlider("Auto Healing Stream Totem @ HP%")) && Aimsharp.TotemRemaining(HealingStreamTotem_SpellName(Language)) <= 0)
            {
                PartyDict.Clear();
                PartyDict.Add("player", Aimsharp.Health("player"));

                var partysize = Aimsharp.GroupSize();
                if (partysize <= 5)
                {
                    for (int i = 1; i < partysize; i++)
                    {
                        var partyunit = ("party" + i);
                        if (Aimsharp.Health(partyunit) > 0 && Aimsharp.Range(partyunit) <= 40)
                        {
                            PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                        }
                    }
                }

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    if (Aimsharp.CanCast(HealingStreamTotem_SpellName(Language), "player", false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && Aimsharp.Health(unit.Key) <= GetSlider("Auto Healing Stream Totem @ HP%"))
                    {
                        Aimsharp.Cast(HealingStreamTotem_SpellName(Language));
                        return true;
                    }
                }
            }
            #endregion

            #region Remove Curse
            if (!NoDecurse && Aimsharp.CustomFunction("CurseCheck") > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != CleanseSpirit_SpellName(Language))
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

                int states = Aimsharp.CustomFunction("CurseCheck");
                CleansePlayers target;

                int KickTimer = GetRandomNumber(200, 800);

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast(CleanseSpirit_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
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
                                Aimsharp.Cast("CS_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Cleanse Spirit @ " + unit.Key + " - " + unit.Value, Color.Purple);
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
            if (!NoCycle && Aimsharp.CustomFunction("CycleNotEnabled") == 1 && Aimsharp.CustomFunction("HekiliCycle") == 1 && Enemies > 1)
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

            if (Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                #region Mouseover Spells

                #endregion

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
                    #endregion

                    #region Racials
                    //Racials
                    if (SpellID1 == 28880 && Aimsharp.CanCast(GiftOfTheNaaru_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Gift of the Naaru - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(GiftOfTheNaaru_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 20594 && Aimsharp.CanCast(Stoneform_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Stoneform - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Stoneform_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 20589 && Aimsharp.CanCast(EscapeArtist_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Escape Artist - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(EscapeArtist_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 59752 && Aimsharp.CanCast(WillToSurvive_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Will to Survive - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WillToSurvive_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 255647 && Aimsharp.CanCast(LightsJudgment_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Light's Judgment - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(LightsJudgment_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 265221 && Aimsharp.CanCast(Fireblood_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fireblood - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Fireblood_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 69041 && Aimsharp.CanCast(RocketBarrage_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rocket Barrage - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RocketBarrage_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 20549 && Aimsharp.CanCast(WarStomp_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting War Stomp - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WarStomp_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 7744 && Aimsharp.CanCast(WillOfTheForsaken_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Will of the Forsaken - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WillOfTheForsaken_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 260364 && Aimsharp.CanCast(ArcanePulse_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Pulse - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ArcanePulse_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 255654 && Aimsharp.CanCast(BullRush_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bull Rush - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BullRush_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 312411 && Aimsharp.CanCast(BagOfTricks_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bag of Tricks - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BagOfTricks_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 20572 || SpellID1 == 33702 || SpellID1 == 33697) && Aimsharp.CanCast(BloodFury_SpellName(Language), "player", true, true))
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
                    if (SpellID1 == 324386 && Aimsharp.CanCast(VesperTotem_SpellName(Language), "player", false, true))
                    {
                        switch (CovenantCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast(VesperTotem_SpellName(Language));
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("VesperTotemC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("VesperTotemP");
                                return true;
                        }
                    }

                    if (SpellID1 == 328923 && Aimsharp.CanCast(FaeTransfusion_SpellName(Language), "player", false, true))
                    {
                        switch (CovenantCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast(FaeTransfusion_SpellName(Language));
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("FaeTransfusionC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("FaeTransfusionP");
                                return true;
                        }
                    }

                    if (SpellID1 == 320674 && Aimsharp.CanCast(ChainHarvest_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Chain Harvest - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ChainHarvest_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 326059 || SpellID1 == 375982 || SpellID1 == 375983 || SpellID1 == 375984 || SpellID1 == 375985 || SpellID1 == 375986) && Aimsharp.CanCast(PrimordialWave_SpellName(Language), "target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Primordial Wave - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(PrimordialWave_SpellName(Language));
                        return true;
                    }

                    #endregion

                    #region General Spells - NoGCD
                    //Class Spells
                    //Instant [GCD FREE]
                    if (SpellID1 == 1766 && Aimsharp.CanCast(WindShear_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wind Shear - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WindShear_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 378081 && Aimsharp.CanCast(NaturesSwiftness_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Nature's Swiftness - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(NaturesSwiftness_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    if (SpellID1 == 198103 && Aimsharp.CanCast(EarthElemental_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earth Elemental - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(EarthElemental_SpellName(Language));
                        return true;
                    }


                    if (SpellID1 == 51886 && Aimsharp.CanCast(CleanseSpirit_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cleanse Spirit - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(CleanseSpirit_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 370 && Aimsharp.CanCast(Purge_SpellName(Language), "target", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting  Purge - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Purge_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 378773 && Aimsharp.CanCast(GreaterPurge_SpellName(Language), "target", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Greater Purge - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(GreaterPurge_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 2645 && Aimsharp.CanCast(GhostWolf_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ghost Wolf - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(GhostWolf_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 318038 && Aimsharp.CanCast(FlametongueWeapon_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flametongue Weapon - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FlametongueWeapon_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 192106 && Aimsharp.CanCast(LightningShield_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Lightning Shield - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(LightningShield_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 108271 && Aimsharp.CanCast(AstralShift_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Astral Shift - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AstralShift_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    if (SpellID1 == 188443 && Aimsharp.CanCast(ChainLightning_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Chain Lightning - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ChainLightning_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 196840 && Aimsharp.CanCast(FrostShock_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Frost Shock - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FrostShock_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 188196 && Aimsharp.CanCast(LightningBolt_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Lightning Bolt - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(LightningBolt_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 305483 && Aimsharp.CanCast(LightningLasso_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Lightning Lasso - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(LightningLasso_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 73899 && Aimsharp.CanCast(PrimalStrike_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Primal Strike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(PrimalStrike_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 188389 && Aimsharp.CanCast(FlameShock_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flame Shock - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FlameShock_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Elemental Spells - Player GCD
                    if (SpellID1 == 108281 && Aimsharp.CanCast(AncestralGuidance_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ancestral Guidance - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AncestralGuidance_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 192222 && Aimsharp.CanCast(LiquidMagmaTotem_SpellName(Language), "player", false, true))
                    {
                        switch (TotemCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Liquid Magma Totem - " + TotemCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast(LiquidMagmaTotem_SpellName(Language));
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Liquid Magma Totem - " + TotemCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("LiquidMagmaTotemC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting LiquidMagmaTotem - " + TotemCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("LiquidMagmaTotemP");
                                return true;
                        }
                    }

                    if (SpellID1 == 192249 && Aimsharp.CanCast(StormElemental_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Storm Elemental - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(StormElemental_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 342243 && Aimsharp.CanCast(StaticDischarge_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Static Discharge - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(StaticDischarge_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 79206 && Aimsharp.CanCast(SpiritwalkersGrace_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spiritwalker's Grace - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SpiritwalkersGrace_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 198067 && Aimsharp.CanCast(FireElemental_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fire Elemental - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FireElemental_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 61882 && Aimsharp.CanCast(Earthquake_SpellName(Language), "player", false, true))
                    {
                        switch (EarthquakeCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Earthquake - " + EarthquakeCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast(Earthquake_SpellName(Language));
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Earthquake - " + EarthquakeCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("EarthquakeC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Earthquake - " + EarthquakeCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("EarthquakeP");
                                return true;
                        }
                    }

                    if (SpellID1 == 51490 && Aimsharp.CanCast(Thunderstorm_SpellName(Language), "player", false, true) && EnemiesInMelee > 0)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Thunderstorm - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Thunderstorm_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 114050 && Aimsharp.CanCast(Ascendance_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ascendance - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Ascendance_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 191634 && Aimsharp.CanCast(Stormkeeper_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Stormkeeper - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Stormkeeper_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Elemental Spells - Target GCD
                    if (SpellID1 == 157375 && Aimsharp.CanCast(Tempest_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tempest - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("MacroTempest");
                        return true;
                    }

                    if (SpellID1 == 117588 && Aimsharp.CanCast(Meteor_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Meteor - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("MacroMeteor");
                        return true;
                    }

                    if (SpellID1 == 210714 && Aimsharp.CanCast(Icefury_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Icefury - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Icefury_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 320125 && Aimsharp.CanCast(EchoingShock_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Echoing Shock - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(EchoingShock_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 51505 && Aimsharp.CanCast(LavaBurst_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Lava Burst - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(LavaBurst_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 114074 && Aimsharp.CanCast(LavaBeam_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Lava Beam - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(LavaBeam_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 8042 && Aimsharp.CanCast(EarthShock_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earth Shock - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(EarthShock_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 117014 && Aimsharp.CanCast(ElementalBlast_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Elemental Blast - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ElementalBlast_SpellName(Language));
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
            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());
            bool ImbueWeaponOOC = GetCheckBox("Weapon Imbue Out of Combat:");
            bool LightningShieldOOC = GetCheckBox("Lightning Shield Out of Combat:");
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

            #region Above Pause Checks
            if (Aimsharp.CastingID("player") == 51514 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Hex"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Hex Queue", Color.Purple);
                }
                Aimsharp.Cast("HexOff");
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

            if (Aimsharp.IsCustomCodeOn("EarthbindTotem") && Aimsharp.SpellCooldown(EarthbindTotem_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("CapacitorTotem") && Aimsharp.SpellCooldown(CapacitorTotem_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("WindRushTotem") && Aimsharp.SpellCooldown(WindRushTotem_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("VesperTotem") && Aimsharp.SpellCooldown(VesperTotem_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("FaeTransfusion") && Aimsharp.SpellCooldown(FaeTransfusion_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            bool TremorTotem = Aimsharp.IsCustomCodeOn("TremorTotem");
            if (Aimsharp.SpellCooldown(TremorTotem_SpellName(Language)) - Aimsharp.GCD() > 2000 && TremorTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Tremor Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("TremorTotemOff");
                return true;
            }

            if (TremorTotem && Aimsharp.CanCast(TremorTotem_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Tremor Totem - Queue", Color.Purple);
                }
                Aimsharp.Cast(TremorTotem_SpellName(Language));
                return true;
            }

            bool EarthElemental = Aimsharp.IsCustomCodeOn("EarthElemental");
            if (Aimsharp.SpellCooldown(EarthElemental_SpellName(Language)) - Aimsharp.GCD() > 2000 && EarthElemental)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Earth Elemental Queue", Color.Purple);
                }
                Aimsharp.Cast("EarthElementalOff");
                return true;
            }

            if (EarthElemental && Aimsharp.CanCast(EarthElemental_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Earth Elemental - Queue", Color.Purple);
                }
                Aimsharp.Cast(EarthElemental_SpellName(Language));
                return true;
            }

            bool Hex = Aimsharp.IsCustomCodeOn("Hex");
            if ((Aimsharp.SpellCooldown(Hex_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && Hex)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Hex Queue", Color.Purple);
                }
                Aimsharp.Cast("HexOff");
                return true;
            }

            if (Hex && Aimsharp.CanCast(Hex_SpellName(Language), "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Hex - Queue", Color.Purple);
                }
                Aimsharp.Cast("HexMO");
                return true;
            }

            string CovenantCast = GetDropDown("Covenant Cast:");
            bool VesperTotem = Aimsharp.IsCustomCodeOn("VesperTotem");
            if (Aimsharp.SpellCooldown(VesperTotem_SpellName(Language)) - Aimsharp.GCD() > 2000 && VesperTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Vesper Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("VesperTotemOff");
                return true;
            }

            if (VesperTotem && Aimsharp.CanCast(VesperTotem_SpellName(Language), "player", false, true))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(VesperTotem_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("VesperTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vesper Totem - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("VesperTotemP");
                        return true;
                }
            }

            bool FaeTransfusion = Aimsharp.IsCustomCodeOn("FaeTransfusion");
            if (Aimsharp.SpellCooldown(FaeTransfusion_SpellName(Language)) - Aimsharp.GCD() > 2000 && FaeTransfusion)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fae Transfusion Queue", Color.Purple);
                }
                Aimsharp.Cast("FaeTransfusionOff");
                return true;
            }

            if (FaeTransfusion && Aimsharp.CanCast(FaeTransfusion_SpellName(Language), "player", false, true))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(FaeTransfusion_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FaeTransfusionC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fae Transfusion - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FaeTransfusionP");
                        return true;
                }
            }

            string TotemCast = GetDropDown("Totem Cast:");
            bool EarthbindTotem = Aimsharp.IsCustomCodeOn("EarthbindTotem");
            if (Aimsharp.SpellCooldown(EarthbindTotem_SpellName(Language)) - Aimsharp.GCD() > 2000 && EarthbindTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Earthbind Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("EarthbindTotemOff");
                return true;
            }

            if (EarthbindTotem && Aimsharp.CanCast(EarthbindTotem_SpellName(Language), "player", false, true))
            {
                switch (TotemCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthbind Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(EarthbindTotem_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthbind Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("EarthbindTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Earthbind Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("EarthbindTotemP");
                        return true;
                }
            }

            bool CapacitorTotem = Aimsharp.IsCustomCodeOn("CapacitorTotem");
            if (Aimsharp.SpellCooldown(CapacitorTotem_SpellName(Language)) - Aimsharp.GCD() > 2000 && CapacitorTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Capacitor Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("CapacitorTotemOff");
                return true;
            }

            if (CapacitorTotem && Aimsharp.CanCast(CapacitorTotem_SpellName(Language), "player", false, true))
            {
                switch (TotemCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Capacitor Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(CapacitorTotem_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Capacitor Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CapacitorTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Capacitor Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CapacitorTotemP");
                        return true;
                }
            }

            bool WindRushTotem = Aimsharp.IsCustomCodeOn("WindRushTotem");
            if (Aimsharp.SpellCooldown(WindRushTotem_SpellName(Language)) - Aimsharp.GCD() > 2000 && WindRushTotem)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Wind Rush Totem Queue", Color.Purple);
                }
                Aimsharp.Cast("WindRushTotemOff");
                return true;
            }

            if (WindRushTotem && Aimsharp.CanCast(WindRushTotem_SpellName(Language), "player", false, true))
            {
                switch (TotemCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wind Rush Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(WindRushTotem_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wind Rush Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WindRushTotemC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wind Rush Totem - " + TotemCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WindRushTotemP");
                        return true;
                }
            }
            #endregion

            #region Out of Combat Spells
            if (SpellID1 == 318038 && Aimsharp.CanCast(FlametongueWeapon_SpellName(Language), "player", false, true) && ImbueWeaponOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Flametongue Weapon - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(FlametongueWeapon_SpellName(Language));
                return true;
            }

            if (SpellID1 == 33757 && Aimsharp.CanCast(WindfuryWeapon_SpellName(Language), "player", false, true) && ImbueWeaponOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Windfury Weapon - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(WindfuryWeapon_SpellName(Language));
                return true;
            }

            if (SpellID1 == 192106 && Aimsharp.CanCast(LightningShield_SpellName(Language), "player", false, true) && LightningShieldOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Lightning Shield - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(LightningShield_SpellName(Language));
                return true;
            }
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 40 && TargetInCombat)
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