using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicRogueOutlawHekili : Rotation
    {
        private static string Language = "English";

        //Random Number
        private static readonly Random getrandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        #region SpellFunctions
        ///<summary>spell=13750</summary>
        private static string AdrenalineRush_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Adrenaline Rush";
                case "Deutsch": return "Adrenalinrausch";
                case "Español": return "Subidón de adrenalina";
                case "Français": return "Poussée d'adrénaline";
                case "Italiano": return "Scarica d'Adrenalina";
                case "Português Brasileiro": return "Adrenalina";
                case "Русский": return "Выброс адреналина";
                case "한국어": return "아드레날린 촉진";
                case "简体中文": return "冲动";
                default: return "Adrenaline Rush";
            }
        }

        ///<summary>spell=8676</summary>
        private static string Ambush_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ambush";
                case "Deutsch": return "Hinterhalt";
                case "Español": return "Emboscada";
                case "Français": return "Embuscade";
                case "Italiano": return "Imboscata";
                case "Português Brasileiro": return "Emboscar";
                case "Русский": return "Внезапный удар";
                case "한국어": return "매복";
                case "简体中文": return "伏击";
                default: return "Ambush";
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

        ///<summary>spell=315341</summary>
        private static string BetweenTheEyes_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Between the Eyes";
                case "Deutsch": return "Zwischen die Augen";
                case "Español": return "Entre ceja y ceja";
                case "Français": return "Entre les deux yeux";
                case "Italiano": return "In Mezzo agli Occhi";
                case "Português Brasileiro": return "No Meio da Testa";
                case "Русский": return "Промеж глаз";
                case "한국어": return "미간 적중";
                case "简体中文": return "正中眉心";
                default: return "Between the Eyes";
            }
        }

        ///<summary>spell=13877</summary>
        private static string BladeFlurry_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blade Flurry";
                case "Deutsch": return "Klingenwirbel";
                case "Español": return "Aluvión de acero";
                case "Français": return "Déluge de lames";
                case "Italiano": return "Vortice di Lame";
                case "Português Brasileiro": return "Rajada de Lâminas";
                case "Русский": return "Шквал клинков";
                case "한국어": return "폭풍의 칼날";
                case "简体中文": return "剑刃乱舞";
                default: return "Blade Flurry";
            }
        }

        ///<summary>spell=271877</summary>
        private static string BladeRush_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blade Rush";
                case "Deutsch": return "Klingenansturm";
                case "Español": return "Carga de hojas";
                case "Français": return "Volée de lames";
                case "Italiano": return "Scatto Tagliente";
                case "Português Brasileiro": return "Ímpeto da Lâmina";
                case "Русский": return "Натиск клинка";
                case "한국어": return "질풍 칼날";
                case "简体中文": return "刀锋冲刺";
                default: return "Blade Rush";
            }
        }

        ///<summary>spell=2094</summary>
        private static string Blind_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blind";
                case "Deutsch": return "Blenden";
                case "Español": return "Ceguera";
                case "Français": return "Cécité";
                case "Italiano": return "Accecamento";
                case "Português Brasileiro": return "Cegar";
                case "Русский": return "Ослепление";
                case "한국어": return "실명";
                case "简体中文": return "致盲";
                default: return "Blind";
            }
        }

        ///<summary>spell=328085</summary>
        private static string Blindside_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blindside";
                case "Deutsch": return "Wunder Punkt";
                case "Español": return "Punto ciego";
                case "Français": return "Angle mort";
                case "Italiano": return "Lato Cieco";
                case "Português Brasileiro": return "Ponto Cego";
                case "Русский": return "Слепая зона";
                case "한국어": return "사각 지대";
                case "简体中文": return "侧袭";
                default: return "Blindside";
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

        ///<summary>spell=1833</summary>
        private static string CheapShot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Cheap Shot";
                case "Deutsch": return "Fieser Trick";
                case "Español": return "Golpe bajo";
                case "Français": return "Coup bas";
                case "Italiano": return "Colpo Basso";
                case "Português Brasileiro": return "Golpe Baixo";
                case "Русский": return "Подлый трюк";
                case "한국어": return "비열한 습격";
                case "简体中文": return "偷袭";
                default: return "Cheap Shot";
            }
        }

        ///<summary>spell=31224</summary>
        private static string CloakOfShadows_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Cloak of Shadows";
                case "Deutsch": return "Mantel der Schatten";
                case "Español": return "Capa de las Sombras";
                case "Français": return "Cape d'ombre";
                case "Italiano": return "Manto d'Ombra";
                case "Português Brasileiro": return "Manto das Sombras";
                case "Русский": return "Плащ теней";
                case "한국어": return "그림자 망토";
                case "简体中文": return "暗影斗篷";
                default: return "Cloak of Shadows";
            }
        }

        ///<summary>spell=382245</summary>
        private static string ColdBlood_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Cold Blood";
                case "Deutsch": return "Kaltblütigkeit";
                case "Español": return "Sangre fría";
                case "Français": return "Sang froid";
                case "Italiano": return "Sangue Freddo";
                case "Português Brasileiro": return "Sangue Frio";
                case "Русский": return "Хладнокровие";
                case "한국어": return "냉혈";
                case "简体中文": return "冷血";
                default: return "Cold Blood";
            }
        }

        ///<summary>spell=185311</summary>
        private static string CrimsonVial_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Crimson Vial";
                case "Deutsch": return "Blutrote Phiole";
                case "Español": return "Vial carmesí";
                case "Français": return "Fiole cramoisie";
                case "Italiano": return "Fiala Cremisi";
                case "Português Brasileiro": return "Frasco Rubro";
                case "Русский": return "Алый фиал";
                case "한국어": return "진홍색 약병";
                case "简体中文": return "猩红之瓶";
                default: return "Crimson Vial";
            }
        }

        ///<summary>spell=2098</summary>
        private static string Dispatch_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dispatch";
                case "Deutsch": return "Tötung";
                case "Español": return "Despachar";
                case "Français": return "Couperet";
                case "Italiano": return "Eliminazione";
                case "Português Brasileiro": return "Liquidar";
                case "Русский": return "Устранение";
                case "한국어": return "속결";
                case "简体中文": return "斩击";
                default: return "Dispatch";
            }
        }

        ///<summary>spell=1725</summary>
        private static string Distract_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Distract";
                case "Deutsch": return "Ablenken";
                case "Español": return "Distraer";
                case "Français": return "Distraction";
                case "Italiano": return "Distrazione";
                case "Português Brasileiro": return "Distração";
                case "Русский": return "Отвлечение";
                case "한국어": return "혼란";
                case "简体中文": return "扰乱";
                default: return "Distract";
            }
        }

        ///<summary>spell=343142</summary>
        private static string Dreadblades_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dreadblades";
                case "Deutsch": return "Die Schreckensklingen";
                case "Español": return "Hojas Pérfidas";
                case "Français": return "Lames d’effroi";
                case "Italiano": return "Lame dell'Oscurità";
                case "Português Brasileiro": return "Alfanjes do Terror";
                case "Русский": return "Клинки Ужаса";
                case "한국어": return "공포의 검";
                case "简体中文": return "恐惧之刃";
                default: return "Dreadblades";
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

        ///<summary>spell=385616</summary>
        private static string EchoingReprimand_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Echoing Reprimand";
                case "Deutsch": return "Widerhallender Tadel";
                case "Español": return "Reprimenda resonante";
                case "Français": return "Réprimande retentissante";
                case "Italiano": return "Rimprovero Rimbombante";
                case "Português Brasileiro": return "Reprimenda Ecoante";
                case "Русский": return "Продолжительная отповедь";
                case "한국어": return "울려퍼지는 문책";
                case "简体中文": return "申斥回响";
                default: return "Echoing Reprimand";
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

        ///<summary>spell=5277</summary>
        private static string Evasion_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Evasion";
                case "Deutsch": return "Entrinnen";
                case "Español": return "Evasión";
                case "Français": return "Évasion";
                case "Italiano": return "Evasione";
                case "Português Brasileiro": return "Evasão";
                case "Русский": return "Ускользание";
                case "한국어": return "회피";
                case "简体中文": return "闪避";
                default: return "Evasion";
            }
        }

        ///<summary>spell=196819</summary>
        private static string Eviscerate_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Eviscerate";
                case "Deutsch": return "Ausweiden";
                case "Español": return "Eviscerar";
                case "Français": return "Eviscération";
                case "Italiano": return "Sventramento";
                case "Português Brasileiro": return "Eviscerar";
                case "Русский": return "Потрошение";
                case "한국어": return "절개";
                case "简体中文": return "刺骨";
                default: return "Eviscerate";
            }
        }

        ///<summary>spell=1966</summary>
        private static string Feint_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Feint";
                case "Deutsch": return "Finte";
                case "Español": return "Amago";
                case "Français": return "Feinte";
                case "Italiano": return "Finta";
                case "Português Brasileiro": return "Finta";
                case "Русский": return "Уловка";
                case "한국어": return "교란";
                case "简体中文": return "佯攻";
                default: return "Feint";
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

        ///<summary>spell=323654</summary>
        private static string Flagellation_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Flagellation";
                case "Deutsch": return "Geißelung";
                case "Español": return "Flagelación";
                case "Français": return "Flagellation";
                case "Italiano": return "Flagellazione";
                case "Português Brasileiro": return "Flagelação";
                case "Русский": return "Флагелляция";
                case "한국어": return "채찍질";
                case "简体中文": return "狂热鞭笞";
                default: return "Flagellation";
            }
        }

        ///<summary>spell=44614</summary>
        private static string Flurry_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Flurry";
                case "Deutsch": return "Hagel";
                case "Español": return "Aluvión";
                case "Français": return "Rafale";
                case "Italiano": return "Raffica di Colpi";
                case "Português Brasileiro": return "Ímpeto";
                case "Русский": return "Шквал";
                case "한국어": return "진눈깨비";
                case "简体中文": return "冰风暴";
                default: return "Flurry";
            }
        }

        ///<summary>spell=196937</summary>
        private static string GhostlyStrike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ghostly Strike";
                case "Deutsch": return "Geisterhafter Stoß";
                case "Español": return "Golpe fantasmal";
                case "Français": return "Frappe fantomatique";
                case "Italiano": return "Assalto Spettrale";
                case "Português Brasileiro": return "Golpe Fantasmagórico";
                case "Русский": return "Призрачный удар";
                case "한국어": return "유령의 일격";
                case "简体中文": return "鬼魅攻击";
                default: return "Ghostly Strike";
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

        ///<summary>spell=1776</summary>
        private static string Gouge_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Gouge";
                case "Deutsch": return "Solarplexus";
                case "Español": return "Gubia";
                case "Français": return "Suriner";
                case "Italiano": return "Sfregio Oculare";
                case "Português Brasileiro": return "Esfaquear";
                case "Русский": return "Парализующий удар";
                case "한국어": return "후려치기";
                case "简体中文": return "凿击";
                default: return "Gouge";
            }
        }

        ///<summary>spell=195457</summary>
        private static string GrapplingHook_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Grappling Hook";
                case "Deutsch": return "Greifhaken";
                case "Español": return "Gancho";
                case "Français": return "Grappin";
                case "Italiano": return "Rampino";
                case "Português Brasileiro": return "Gancho de Escalada";
                case "Русский": return "Абордажный крюк";
                case "한국어": return "갈고리 던지기";
                case "简体中文": return "抓钩";
                default: return "Grappling Hook";
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

        ///<summary>spell=315584</summary>
        private static string InstantPoison_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Instant Poison";
                case "Deutsch": return "Sofort wirkendes Gift";
                case "Español": return "Veneno instantáneo";
                case "Français": return "Poison instantané";
                case "Italiano": return "Veleno Istantaneo";
                case "Português Brasileiro": return "Veneno Instantâneo";
                case "Русский": return "Быстродействующий яд";
                case "한국어": return "순간 효과 독";
                case "简体中文": return "速效药膏";
                default: return "Instant Poison";
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

        ///<summary>spell=381989</summary>
        private static string KeepItRolling_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Keep It Rolling";
                case "Deutsch": return "Großer Wurf";
                case "Español": return "Suerte prolongada";
                case "Français": return "Osselets relancés";
                case "Italiano": return "Roulette Eterna";
                case "Português Brasileiro": return "Sorte Grande";
                case "Русский": return "Призовая игра";
                case "한국어": return "도박의 연속";
                case "简体中文": return "时运继延";
                default: return "Keep It Rolling";
            }
        }

        ///<summary>spell=1766</summary>
        private static string Kick_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Kick";
                case "Deutsch": return "Tritt";
                case "Español": return "Patada";
                case "Français": return "Coup de pied";
                case "Italiano": return "Calcio";
                case "Português Brasileiro": return "Chute";
                case "Русский": return "Пинок";
                case "한국어": return "발차기";
                case "简体中文": return "脚踢";
                default: return "Kick";
            }
        }

        ///<summary>spell=408</summary>
        private static string KidneyShot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Kidney Shot";
                case "Deutsch": return "Nierenhieb";
                case "Español": return "Golpe en los riñones";
                case "Français": return "Aiguillon perfide";
                case "Italiano": return "Colpo ai Reni";
                case "Português Brasileiro": return "Golpe no Rim";
                case "Русский": return "Удар по почкам";
                case "한국어": return "급소 가격";
                case "简体中文": return "肾击";
                default: return "Kidney Shot";
            }
        }

        ///<summary>spell=51690</summary>
        private static string KillingSpree_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Killing Spree";
                case "Deutsch": return "Mordlust";
                case "Español": return "Asesinato múltiple";
                case "Français": return "Série meurtrière";
                case "Italiano": return "Furia Omicida";
                case "Português Brasileiro": return "Matança";
                case "Русский": return "Череда убийств";
                case "한국어": return "광기의 학살자";
                case "简体中文": return "影舞步";
                default: return "Killing Spree";
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

        ///<summary>spell=137619</summary>
        private static string MarkedForDeath_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Marked for Death";
                case "Deutsch": return "Todesurteil";
                case "Español": return "Marcado para morir";
                case "Français": return "Désigné pour mourir";
                case "Italiano": return "Marchio della Morte";
                case "Português Brasileiro": return "Marcado para Morrer";
                case "Русский": return "Метка смерти";
                case "한국어": return "죽음의 표적";
                case "简体中文": return "死亡标记";
                default: return "Marked for Death";
            }
        }

        ///<summary>spell=5761</summary>
        private static string NumbingPoison_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Numbing Poison";
                case "Deutsch": return "Lähmendes Gift";
                case "Español": return "Veneno entumecedor";
                case "Français": return "Poison ankylosant";
                case "Italiano": return "Veleno Anestetizzante";
                case "Português Brasileiro": return "Veneno Entorpecente";
                case "Русский": return "Замедляющий яд";
                case "한국어": return "마취 독";
                case "简体中文": return "迟钝药膏";
                default: return "Numbing Poison";
            }
        }

        ///<summary>spell=185763</summary>
        private static string PistolShot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Pistol Shot";
                case "Deutsch": return "Pistolenschuss";
                case "Español": return "Disparo de pistola";
                case "Français": return "Coup de pistolet";
                case "Italiano": return "Colpo di Pistola";
                case "Português Brasileiro": return "Tiro de Pistola";
                case "Русский": return "Выстрел из пистоли";
                case "한국어": return "권총 사격";
                case "简体中文": return "手枪射击";
                default: return "Pistol Shot";
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

        ///<summary>spell=315508</summary>
        private static string RollTheBones_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Roll the Bones";
                case "Deutsch": return "Schicksalswürfel";
                case "Español": return "A suertes";
                case "Français": return "Jet d’osselets";
                case "Italiano": return "Roulette Assassina";
                case "Português Brasileiro": return "Golpe de Sorte";
                case "Русский": return "Игра в кости";
                case "한국어": return "뼈주사위";
                case "简体中文": return "命运骨骰";
                default: return "Roll the Bones";
            }
        }

        ///<summary>spell=6770</summary>
        private static string Sap_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sap";
                case "Deutsch": return "Kopfnuss";
                case "Español": return "Porrazo";
                case "Français": return "Assommer";
                case "Italiano": return "Tramortimento";
                case "Português Brasileiro": return "Aturdir";
                case "Русский": return "Ошеломление";
                case "한국어": return "혼절시키기";
                case "简体中文": return "闷棍";
                default: return "Sap";
            }
        }

        ///<summary>spell=328305</summary>
        private static string Sepsis_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sepsis";
                case "Deutsch": return "Sepsis";
                case "Español": return "Sepsis";
                case "Français": return "Septicémie";
                case "Italiano": return "Sepsi";
                case "Português Brasileiro": return "Sepse";
                case "Русский": return "Сепсис";
                case "한국어": return "피고름";
                case "简体中文": return "败血刃伤";
                default: return "Sepsis";
            }
        }

        ///<summary>spell=328547</summary>
        private static string SerratedBoneSpike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Serrated Bone Spike";
                case "Deutsch": return "Gezackter Knochenstachel";
                case "Español": return "Púa ósea dentada";
                case "Français": return "Pointe d’os dentelée";
                case "Italiano": return "Aculeo Osseo Seghettato";
                case "Português Brasileiro": return "Espigão Ósseo Serrilhado";
                case "Русский": return "Зазубренный костяной шип";
                case "한국어": return "톱니 뼈 가시";
                case "简体中文": return "锯齿骨刺";
                default: return "Serrated Bone Spike";
            }
        }

        ///<summary>spell=185313</summary>
        private static string ShadowDance_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shadow Dance";
                case "Deutsch": return "Schattentanz";
                case "Español": return "Danza de las Sombras";
                case "Français": return "Danse de l’ombre";
                case "Italiano": return "Danza dell'Ombra";
                case "Português Brasileiro": return "Dança das Sombras";
                case "Русский": return "Танец теней";
                case "한국어": return "어둠의 춤";
                case "简体中文": return "暗影之舞";
                default: return "Shadow Dance";
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

        ///<summary>spell=36554</summary>
        private static string Shadowstep_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shadowstep";
                case "Deutsch": return "Schattenschritt";
                case "Español": return "Paso de las Sombras";
                case "Français": return "Pas de l’ombre";
                case "Italiano": return "Passo nell'Ombra";
                case "Português Brasileiro": return "Passo Furtivo";
                case "Русский": return "Шаг сквозь тень";
                case "한국어": return "그림자 밟기";
                case "简体中文": return "暗影步";
                default: return "Shadowstep";
            }
        }

        ///<summary>spell=5938</summary>
        private static string Shiv_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shiv";
                case "Deutsch": return "Tückische Klinge";
                case "Español": return "Puyazo";
                case "Français": return "Kriss";
                case "Italiano": return "Stilettata";
                case "Português Brasileiro": return "Estocada";
                case "Русский": return "Отравляющий укол";
                case "한국어": return "독칼";
                case "简体中文": return "毒刃";
                default: return "Shiv";
            }
        }

        ///<summary>spell=193315</summary>
        private static string SinisterStrike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sinister Strike";
                case "Deutsch": return "Finsterer Stoß";
                case "Español": return "Golpe siniestro";
                case "Français": return "Attaque pernicieuse";
                case "Italiano": return "Assalto Funesto";
                case "Português Brasileiro": return "Golpe Sinistro";
                case "Русский": return "Коварный удар";
                case "한국어": return "사악한 일격";
                case "简体中文": return "影袭";
                default: return "Sinister Strike";
            }
        }

        ///<summary>spell=315496</summary>
        private static string SliceAndDice_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Slice and Dice";
                case "Deutsch": return "Zerhäckseln";
                case "Español": return "Hacer picadillo";
                case "Français": return "Débiter";
                case "Italiano": return "Fendenti Furiosi";
                case "Português Brasileiro": return "Retalhar";
                case "Русский": return "Мясорубка";
                case "한국어": return "난도질";
                case "简体中文": return "切割";
                default: return "Slice and Dice";
            }
        }

        ///<summary>spell=2983</summary>
        private static string Sprint_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sprint";
                case "Deutsch": return "Sprinten";
                case "Español": return "Sprint";
                case "Français": return "Sprint";
                case "Italiano": return "Scatto";
                case "Português Brasileiro": return "Disparada";
                case "Русский": return "Спринт";
                case "한국어": return "전력 질주";
                case "简体中文": return "疾跑";
                default: return "Sprint";
            }
        }

        ///<summary>spell=1784</summary>
        private static string Stealth_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Stealth";
                case "Deutsch": return "Verstohlenheit";
                case "Español": return "Sigilo";
                case "Français": return "Camouflage";
                case "Italiano": return "Furtività";
                case "Português Brasileiro": return "Furtividade";
                case "Русский": return "Незаметность";
                case "한국어": return "은신";
                case "简体中文": return "潜行";
                default: return "Stealth";
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

        ///<summary>spell=108208</summary>
        private static string Subterfuge_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Subterfuge";
                case "Deutsch": return "Trickbetrug";
                case "Español": return "Subterfugio";
                case "Français": return "Subterfuge";
                case "Italiano": return "Sotterfugio";
                case "Português Brasileiro": return "Subterfúgio";
                case "Русский": return "Увертка";
                case "한국어": return "기만";
                case "简体中文": return "诡诈";
                default: return "Subterfuge";
            }
        }

        ///<summary>spell=381623</summary>
        private static string ThistleTea_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Thistle Tea";
                case "Deutsch": return "Disteltee";
                case "Español": return "Té de cardo";
                case "Français": return "Thé de chardon";
                case "Italiano": return "Tè di Sboccialesto";
                case "Português Brasileiro": return "Chá de Cardo";
                case "Русский": return "Скорополоховый чай";
                case "한국어": return "엉겅퀴 차";
                case "简体中文": return "菊花茶";
                default: return "Thistle Tea";
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

        ///<summary>spell=1856</summary>
        private static string Vanish_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Vanish";
                case "Deutsch": return "Verschwinden";
                case "Español": return "Esfumarse";
                case "Français": return "Disparition";
                case "Italiano": return "Sparizione";
                case "Português Brasileiro": return "Sumir";
                case "Русский": return "Исчезновение";
                case "한국어": return "소멸";
                case "简体中文": return "消失";
                default: return "Vanish";
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
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "Distract", "Blind", "Sap", "KidneyShot", "NoCycle", "GrapplingHook", };
        private List<string> m_DebuffsList;
        private List<string> m_BuffsList;
        private List<string> m_ItemsList;
        private List<string> m_SpellBook_General;
        private List<string> m_SpellBook_Outlaw;

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
            if (Aimsharp.CustomFunction("GetTalentDeeperStrategem") == 1)
                return true;

            return false;
        }

        public bool canCastSpell(int hekiliSpellID, int spellID, string spellName, bool debug,
            string unit = "target", bool checkRange = true, bool checkCasting = false)
        {
            if (hekiliSpellID == spellID && Aimsharp.CanCast(spellName, unit, checkRange, checkCasting))
            {
                if (debug)
                {
                    Aimsharp.PrintMessage("Casting " + spellName + " - " + spellID, Color.Purple);
                }
                Aimsharp.Cast(spellName);
                return true;
            }
            return false;
        }
        public bool canCastSpell(int hekiliSpellID, int spellID, string spellName, bool debug, bool meleeRange,
            string unit = "target", bool checkRange = true, bool checkCasting = false)
        {
            if (hekiliSpellID == spellID && Aimsharp.CanCast(spellName, unit, checkRange, checkCasting) && meleeRange)
            {
                if (debug)
                {
                    Aimsharp.PrintMessage("Casting " + spellName + " - " + spellID, Color.Purple);
                }
                Aimsharp.Cast(spellName);
                return true;
            }
            return false;
        }

        #endregion

        #region CanCasts
        private bool CanCastSepsis(string unit)
        {
            if (Aimsharp.CanCast(Sepsis_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Sepsis_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 25 && Aimsharp.Range(unit) <= 5 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSerratedBoneSpike(string unit)
        {
            if (Aimsharp.CanCast(SerratedBoneSpike_SpellName(Language), unit, true, true) || ((Aimsharp.SpellCooldown(SerratedBoneSpike_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) || Aimsharp.SpellCharges(SerratedBoneSpike_SpellName(Language)) >= 1 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)) && Aimsharp.Power("player") >= 15 && Aimsharp.Range(unit) <= 30 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastEchoingReprimand(string unit)
        {
            if (Aimsharp.CanCast(EchoingReprimand_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(EchoingReprimand_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 10 && Aimsharp.Range(unit) <= 5 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFlagellation(string unit)
        {
            if (Aimsharp.CanCast(Flagellation_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Flagellation_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 5 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastKick(string unit)
        {
            if (Aimsharp.CanCast(Kick_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Kick_SpellName(Language)) <= 0 && Aimsharp.Range(unit) <= 5 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastEviscerate(string unit)
        {
            if (Aimsharp.CanCast(Eviscerate_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Eviscerate_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 35 && Aimsharp.PlayerSecondaryPower() >= 1 && Aimsharp.Range(unit) <= 5 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastCheapShot(string unit)
        {
            if (Aimsharp.CanCast(CheapShot_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(CheapShot_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 40 && Aimsharp.Range(unit) <= 5 && (Aimsharp.HasBuff(Stealth_SpellName(Language), "player", true) || Aimsharp.HasBuff(ShadowDance_SpellName(Language), "player", true) || Aimsharp.HasBuff(Vanish_SpellName(Language), "player", true) || Aimsharp.HasBuff(Subterfuge_SpellName(Language), "player", true)) && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastStealth(string unit)
        {
            if (Aimsharp.CanCast(Stealth_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(Stealth_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !Aimsharp.HasBuff(Stealth_SpellName(Language), "player", true) && !Aimsharp.InCombat("player") && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSprint(string unit)
        {
            if (Aimsharp.CanCast(Sprint_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(Sprint_SpellName(Language)) <= 0 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastAmbush(string unit)
        {
            if (Aimsharp.CanCast(Ambush_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Ambush_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && (Aimsharp.Power("player") >= 40 || Aimsharp.HasBuff(Blindside_SpellName(Language), "player", true)) && Aimsharp.Range(unit) <= 5 && (Aimsharp.HasBuff(Stealth_SpellName(Language), "player", true) || Aimsharp.HasBuff(ShadowDance_SpellName(Language), "player", true) || Aimsharp.HasBuff(Vanish_SpellName(Language), "player", true) || Aimsharp.HasBuff(Blindside_SpellName(Language), "player", true) || Aimsharp.HasBuff(Subterfuge_SpellName(Language), "player", true)) && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastCrimsonVial(string unit)
        {
            if (Aimsharp.CanCast(CrimsonVial_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(CrimsonVial_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 15 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSliceandDice(string unit)
        {
            if (Aimsharp.CanCast(SliceAndDice_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(SliceAndDice_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 25 && Aimsharp.PlayerSecondaryPower() >= 1 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSap(string unit)
        {
            if (Aimsharp.CanCast(Sap_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Sap_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 35 && Aimsharp.Range(unit) <= 10 && (Aimsharp.HasBuff(Stealth_SpellName(Language), "player", true) || Aimsharp.HasBuff(ShadowDance_SpellName(Language), "player", true) || Aimsharp.HasBuff(Vanish_SpellName(Language), "player", true) || Aimsharp.HasBuff(Subterfuge_SpellName(Language), "player", true)) && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastKidneyShot(string unit)
        {
            if (Aimsharp.CanCast(KidneyShot_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(KidneyShot_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 25 && Aimsharp.PlayerSecondaryPower() >= 1 && Aimsharp.Range(unit) <= 5 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastEvasion(string unit)
        {
            if (Aimsharp.CanCast(Evasion_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(Evasion_SpellName(Language)) <= 0 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastVanish(string unit)
        {
            if (Aimsharp.CanCast(Vanish_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(Vanish_SpellName(Language)) <= 0 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastDistract(string unit)
        {
            if (Aimsharp.CanCast(Distract_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(Distract_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }


        private bool CanCastShiv(string unit)
        {
            if (Aimsharp.CanCast(Shiv_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Shiv_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 20 && Aimsharp.Range(unit) <= 5 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFeint(string unit)
        {
            if (Aimsharp.CanCast(Feint_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(Feint_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Power("player") >= 30 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastBlind(string unit)
        {
            if (Aimsharp.CanCast(Blind_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Blind_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 15 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastCloakofShadows(string unit)
        {
            if (Aimsharp.CanCast(CloakOfShadows_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(CloakOfShadows_SpellName(Language)) <= 0 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastMarkedforDeath(string unit)
        {
            if (Aimsharp.CanCast(MarkedForDeath_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(MarkedForDeath_SpellName(Language)) <= 0 && Aimsharp.Range(unit) <= 30 && Aimsharp.CustomFunction("GetSpellMarkedForDeath") == 1 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastShadowstep(string unit)
        {
            if (Aimsharp.CanCast(Shadowstep_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(Shadowstep_SpellName(Language)) <= 0 && Aimsharp.Range(unit) <= 25 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }
        #endregion

        #region Debuffs
        private int UnitDebuffSap(string unit)
        {
            if (Aimsharp.HasDebuff(Sap_SpellName(Language), unit, true))
                return Aimsharp.DebuffRemaining(Sap_SpellName(Language), unit, true);
            if (Aimsharp.HasDebuff(Sap_SpellName(Language), unit, false))
                return Aimsharp.DebuffRemaining(Sap_SpellName(Language), unit, false);

            return 0;
        }

        private int UnitDebuffBlind(string unit)
        {
            if (Aimsharp.HasDebuff(Blind_SpellName(Language), unit, true))
                return Aimsharp.DebuffRemaining(Blind_SpellName(Language), unit, true);
            if (Aimsharp.HasDebuff(Blind_SpellName(Language), unit, false))
                return Aimsharp.DebuffRemaining(Blind_SpellName(Language), unit, false);

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
            Macros.Add("UseHealthstone", "/use " + Healthstone_SpellName(Language));


            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + Aimsharp.Latency);

            //Queues
            Macros.Add("DistractOff", "/" + FiveLetters + " Distract");
            Macros.Add("DistractC", "/cast [@cursor] " + Distract_SpellName(Language));
            Macros.Add("DistractP", "/cast [@player] " + Distract_SpellName(Language));
            Macros.Add("BlindOff", "/" + FiveLetters + " Blind");
            Macros.Add("SapOff", "/" + FiveLetters + " Sap");
            Macros.Add("KidneyShotOff", "/" + FiveLetters + " KidneyShot");
            Macros.Add("GrapplingHookOff", "/" + FiveLetters + " GrapplingHook");
            Macros.Add("GrapplingHookC", "/cast [@cursor] " + GrapplingHook_SpellName(Language));

            Macros.Add("BoneSpikeMO", "/cast [@mouseover] " + SerratedBoneSpike_SpellName(Language));
            Macros.Add("BlindMO", "/cast [@mouseover] " + Blind_SpellName(Language));

        }

        private void InitializeSpells()
        {
            foreach (string Spell in m_SpellBook_General)
                Spellbook.Add(Spell);

            foreach (string Spell in m_SpellBook_Outlaw)
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

            CustomFunctions.Add("BoneSpikeDebuffCheck", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Serrated Bone Spike','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,_,_,_,source  = UnitDebuff('mouseover', y) if name == 'Serrated Bone Spike' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("HekiliWait", "if HekiliDisplayPrimary.Recommendations[1].wait ~= nil and HekiliDisplayPrimary.Recommendations[1].wait * 1000 > 0 then return math.floor(HekiliDisplayPrimary.Recommendations[1].wait * 1000) end return 0");

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("TargetIsMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitExists('target') and UnitIsDead('target') ~= true and UnitIsUnit('mouseover', 'target') then return 1 end; return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");

            CustomFunctions.Add("CycleNotEnabled", "local cycle = 0 if Hekili.State.settings.spec.cycle == true then cycle = 1 else if Hekili.State.settings.spec.cycle == false then cycle = 2 end end return cycle");

            CustomFunctions.Add("GetTalentDeeperStrategem", "if (IsSpellKnown(193531) or IsPlayerSpell(193531)) then return 1 else return 0 end");

            CustomFunctions.Add("GetSpellMarkedForDeath", "if (IsSpellKnown(137619) or IsPlayerSpell(137619)) then return 1 else return 0 end");
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
            Settings.Add(new Setting("Grappling Hook Cast:", m_CastingList, "Manual"));
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

            Aimsharp.PrintMessage("Epic PVE - Rogue Outlaw (made by acer1992F)", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/rogue/outlaw/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("Poisons are Manual - apply them before Combat", Color.Green);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Blind - Casts Blind @ Mouseover on the next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Sap - Casts Sap @ Target on the next GCD, turns off Auto Combat while On", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Distract - Casts Distract @ Manual/Cursor/Player on the next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " KidneyShot - Casts Kidney Shit @ Target next GCD", Color.Yellow);
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
            m_DebuffsList = new List<string> { Sap_SpellName(Language), Blind_SpellName(Language), SerratedBoneSpike_SpellName(Language), };
            m_BuffsList = new List<string> { Stealth_SpellName(Language), Vanish_SpellName(Language), Blindside_SpellName(Language), Subterfuge_SpellName(Language), };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language) };
            m_SpellBook_General = new List<string> {
                //Covenants
                EchoingReprimand_SpellName(Language), //385616,323547
                Flagellation_SpellName(Language), //323654 , 384631
                Sepsis_SpellName(Language), //328305 , 385408
                SerratedBoneSpike_SpellName(Language), //328547 , 385424

                //Interrupt
                Kick_SpellName(Language), //1766

                //General Rogue
                Ambush_SpellName(Language), //8676
                CheapShot_SpellName(Language), //1833
                CrimsonVial_SpellName(Language), //185311
                Distract_SpellName(Language), //1725
                Eviscerate_SpellName(Language), //196819
                KidneyShot_SpellName(Language), //408
                SliceAndDice_SpellName(Language), //315496
                Sprint_SpellName(Language), //2983
                Stealth_SpellName(Language), //1784
                Vanish_SpellName(Language), //1856

                //General Talents
                Blind_SpellName(Language), //2094
                CloakOfShadows_SpellName(Language), //31224
                ColdBlood_SpellName(Language), //382245
                Evasion_SpellName(Language), //5277
                Feint_SpellName(Language), //1966
                Gouge_SpellName(Language), //1776
                MarkedForDeath_SpellName(Language), //137619
                Sap_SpellName(Language), //6770
                ShadowDance_SpellName(Language), //185313
                Shadowstep_SpellName(Language), //36554
                Shiv_SpellName(Language), //5938
                ThistleTea_SpellName(Language), //381623
            };

            m_SpellBook_Outlaw = new List<string>
            {
                //Outlaw Rogue
                AdrenalineRush_SpellName(Language), //13750
                BetweenTheEyes_SpellName(Language), //315341
                BladeFlurry_SpellName(Language), //13877
                BladeRush_SpellName(Language), //271877
                Dispatch_SpellName(Language), //2098
                Dreadblades_SpellName(Language), //343142
                GhostlyStrike_SpellName(Language), //196937
                GrapplingHook_SpellName(Language), //195457
                KeepItRolling_SpellName(Language), //381989
                KillingSpree_SpellName(Language), //51690
                PistolShot_SpellName(Language), //185763
                RollTheBones_SpellName(Language), //315508
                SinisterStrike_SpellName(Language), //193315
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

            int EvasionHP = GetSlider("Auto Evasion @ HP%");
            int CloakHP = GetSlider("Auto Cloak @ HP%");
            int VialHP = GetSlider("Auto Vial @ HP%");

            int BoneSpikeDebuffMO = Aimsharp.CustomFunction("BoneSpikeDebuffCheck");
            bool MOBoneSpike = GetCheckBox("Spread Bone Spike with Mouseover:") == true;
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

            if (Aimsharp.IsCustomCodeOn("Distract") && Aimsharp.SpellCooldown(Distract_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("GrapplingHook") && Aimsharp.SpellCooldown(GrapplingHook_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                if (CanCastKick("target"))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Kick_SpellName(Language), true);
                        return true;
                    }
                }

                if (CanCastKick("target"))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Kick_SpellName(Language), true);
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

            //Auto Evasion
            if (PlayerHP <= EvasionHP && CanCastEvasion("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Evasion - Player HP% " + PlayerHP + " due to setting being on HP% " + EvasionHP, Color.Purple);
                }
                Aimsharp.Cast(Evasion_SpellName(Language), true);
                return true;
            }

            //Auto Cloak of Shadows
            if (PlayerHP <= CloakHP && CanCastCloakofShadows("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Cloak of Shadows - Player HP% " + PlayerHP + " due to setting being on HP% " + CloakHP, Color.Purple);
                }
                Aimsharp.Cast(CloakOfShadows_SpellName(Language), true);
                return true;
            }

            //Auto Crimson Vial
            if (PlayerHP <= VialHP && CanCastCrimsonVial("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Crimson Vial - Player HP% " + PlayerHP + " due to setting being on HP% " + VialHP, Color.Purple);
                }
                Aimsharp.Cast(CrimsonVial_SpellName(Language));
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
            if (Aimsharp.SpellCooldown(Blind_SpellName(Language)) - Aimsharp.GCD() > 2000 && Blind)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blind Queue", Color.Purple);
                }
                Aimsharp.Cast("BlindOff");
                return true;
            }

            if (Blind && Aimsharp.CanCast(Blind_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blind - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlindMO");
                return true;
            }

            bool KidneyShot = Aimsharp.IsCustomCodeOn("KidneyShot");
            if (Aimsharp.SpellCooldown(KidneyShot_SpellName(Language)) - Aimsharp.GCD() > 2000 && KidneyShot)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Kidney Shot Queue", Color.Purple);
                }
                Aimsharp.Cast("KidneyShotOff");
                return true;
            }

            if (KidneyShot && Aimsharp.CanCast(KidneyShot_SpellName(Language), "target", true, true) && (Aimsharp.PlayerSecondaryPower() >= 5 && !TalentDeeperStratagem() || Aimsharp.PlayerSecondaryPower() >= 6 && TalentDeeperStratagem() || GetCheckBox("Kidney Shot Queue - Dont wait for Max CP")))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Kidney Shot - Queue", Color.Purple);
                }
                Aimsharp.Cast(KidneyShot_SpellName(Language));
                return true;
            }

            string DistractCast = GetDropDown("Distract Cast:");
            bool Distract = Aimsharp.IsCustomCodeOn("Distract");
            if (Aimsharp.SpellCooldown(Distract_SpellName(Language)) - Aimsharp.GCD() > 2000 && Distract)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Distract Queue", Color.Purple);
                }
                Aimsharp.Cast("DistractOff");
                return true;
            }

            if (Distract && Aimsharp.CanCast(Distract_SpellName(Language), "player", false, true))
            {
                switch (DistractCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Distract - " + DistractCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Distract_SpellName(Language));
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

            string GrapplingHookCast = GetDropDown("Grappling Hook Cast:");
            bool GrapplingHook = Aimsharp.IsCustomCodeOn("GrapplingHook");

            if (Aimsharp.SpellCooldown(GrapplingHook_SpellName(Language)) - Aimsharp.GCD() > 2000 && GrapplingHook)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off GrapplingHook Queue", Color.Purple);
                }
                Aimsharp.Cast("GrapplingHookOff");
                return true;
            }

            if (GrapplingHook && Aimsharp.CanCast(GrapplingHook_SpellName(Language), "player", false, true))
            {
                switch (GrapplingHookCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Grappling Hook - " + GrapplingHookCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(GrapplingHook_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Grappling Hook - " + GrapplingHookCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("GrapplingHookC");
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
                if (CanCastSerratedBoneSpike("mouseover") && Aimsharp.HasDebuff(SerratedBoneSpike_SpellName(Language), "target", true) && Aimsharp.CustomFunction("TargetIsMouseover") == 0)
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
                #endregion

                #region Kidney Shot
                if (KidneyShot && !GetCheckBox("Kidney Shot Queue - Dont wait for Max CP"))
                {
                    if ((SpellID1 == 8676 && CanCastAmbush("target")) || SpellID1 == 196819 && Aimsharp.GetPlayerLevel() < 22 && CanCastEviscerate("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ambush - " + SpellID1, Color.Purple);
                        }
                        if (Aimsharp.GetPlayerLevel() < 22) Aimsharp.Cast(Eviscerate_SpellName(Language));
                        if (Aimsharp.GetPlayerLevel() >= 22) Aimsharp.Cast(Ambush_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 193315 && Aimsharp.CanCast(SinisterStrike_SpellName(Language), "target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sinister Strike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SinisterStrike_SpellName(Language));
                        return true;
                    }

                    else
                    {
                        if (Aimsharp.CanCast(SinisterStrike_SpellName(Language), "target") && (Aimsharp.PlayerSecondaryPower() == 4 && !TalentDeeperStratagem() || TalentDeeperStratagem() && Aimsharp.PlayerSecondaryPower() == 5))
                        {
                            Aimsharp.Cast(SinisterStrike_SpellName(Language));
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Casting Sinister Strike for Kidney Shot - Combo Points: " + Aimsharp.PlayerSecondaryPower(), Color.Purple);
                            }
                            return true;
                        }

                        if (CanCastAmbush("target") && (Aimsharp.PlayerSecondaryPower() <= 3 && !TalentDeeperStratagem() || TalentDeeperStratagem() && Aimsharp.PlayerSecondaryPower() <= 4))
                        {
                            Aimsharp.Cast(Ambush_SpellName(Language));
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Casting Ambush for Kidney Shot - Combo Points: " + Aimsharp.PlayerSecondaryPower(), Color.Purple);
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
                    if (SpellID1 == 28880 && Aimsharp.CanCast(GiftOfTheNaaru_SpellName(Language), "player", true, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Gift of the Naaru - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(GiftOfTheNaaru_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 20594 && Aimsharp.CanCast(Stoneform_SpellName(Language), "player", true, true) && MeleeRange)
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

                    if (SpellID1 == 255647 && Aimsharp.CanCast(LightsJudgment_SpellName(Language), "player", true, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Light's Judgment - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(LightsJudgment_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 265221 && Aimsharp.CanCast(Fireblood_SpellName(Language), "player", true, true) && MeleeRange)
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

                    if (SpellID1 == 20549 && Aimsharp.CanCast(WarStomp_SpellName(Language), "player", true, true) && MeleeRange)
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

                    if (SpellID1 == 260364 && Aimsharp.CanCast(ArcanePulse_SpellName(Language), "player", true, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Pulse - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ArcanePulse_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 255654 && Aimsharp.CanCast(BullRush_SpellName(Language), "player", true, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bull Rush - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BullRush_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 312411 && Aimsharp.CanCast(BagOfTricks_SpellName(Language), "player", true, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bag of Tricks - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BagOfTricks_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 20572 || SpellID1 == 33702 || SpellID1 == 33697) && Aimsharp.CanCast(BloodFury_SpellName(Language), "player", true, true) && MeleeRange)
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
                    if ((SpellID1 == 323547 || SpellID1 == 385616) && CanCastEchoingReprimand("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Echoing Reprimand - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(EchoingReprimand_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 328305 || SpellID1 == 385408) && CanCastSepsis("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sepsis - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Sepsis_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 328547 || SpellID1 == 385424) && CanCastSerratedBoneSpike("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Serrated Bone Spike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SerratedBoneSpike_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 323654 || SpellID1 == 384631) && CanCastFlagellation("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flagellation - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Flagellation_SpellName(Language));
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
                        Aimsharp.Cast(Kick_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 137619 && CanCastMarkedforDeath("target") && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Marked for Death - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(MarkedForDeath_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 5277 && CanCastEvasion("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Evasion - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Evasion_SpellName(Language), true);
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
                        Aimsharp.Cast(Stealth_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 315496 && CanCastSliceandDice("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Slice and Dice - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SliceAndDice_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 185311 && CanCastCrimsonVial("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Crimson Vial - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(CrimsonVial_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 1856 && CanCastVanish("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vanish - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Vanish_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 2983 && CanCastSprint("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sprint - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Sprint_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 1966 && CanCastFeint("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Feint - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Feint_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 382245 && Aimsharp.CanCast(ColdBlood_SpellName(Language), "player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cold Blood - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ColdBlood_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 381623 && Aimsharp.CanCast(ThistleTea_SpellName(Language), "player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Thistle Tea - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ThistleTea_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 36554 && CanCastShadowstep("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowstep - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Shadowstep_SpellName(Language));
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
                        Aimsharp.Cast(Blind_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 1833 && CanCastCheapShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cheap Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(CheapShot_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 408 && CanCastKidneyShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Kidney Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(KidneyShot_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 196819 && CanCastEviscerate("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Eviscerate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Eviscerate_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 8676 && CanCastAmbush("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ambush - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Ambush_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Outlaw Spells - Player GCD
                    //Player

                    if (SpellID1 == 13877 && Aimsharp.CanCast(BladeFlurry_SpellName(Language), "player", false, true) && MeleeRange && Wait <= 200)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blade Flurry - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BladeFlurry_SpellName(Language));
                        return true;
                    }
                    if (SpellID1 == 315508 && Aimsharp.CanCast(RollTheBones_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 10)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Roll the Bones - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RollTheBones_SpellName(Language));
                        return true;
                    }
                    if (SpellID1 == 13750 && Aimsharp.CanCast(AdrenalineRush_SpellName(Language), "player", false, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Adrenaline Rush - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AdrenalineRush_SpellName(Language));
                        return true;
                    }
                    if (SpellID1 == 381989 && Aimsharp.CanCast(KeepItRolling_SpellName(Language), "player", false, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Keep It Rolling - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(KeepItRolling_SpellName(Language));
                        return true;
                    }
                    if (SpellID1 == 185313 && Aimsharp.CanCast(ShadowDance_SpellName(Language), "player", false, true) && MeleeRange)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Dance - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ShadowDance_SpellName(Language));
                        return true;
                    }
                    /*
                                        //Killing Spree
                                        canCastSpell(spellID,51690,KillingSpree_SpellName(Language),"player",false,true,MeleeRange);
                                        //Killing Spree
                                        canCastSpell(spellID,51690,KillingSpree_SpellName(Language),"player",false,true,MeleeRange);
                                        //Killing Spree
                                        canCastSpell(spellID,51690,KillingSpree_SpellName(Language),"player",false,true,MeleeRange);

                                        //Killing Spree
                                        canCastSpell(spellID,51690,KillingSpree_SpellName(Language),"player",false,true,MeleeRange);
                                        */
                    #endregion

                    #region Outlaw Spells - Target GCD
                    ////Target
                    //Echoing Reprimand
                    canCastSpell(SpellID1, 323547, EchoingReprimand_SpellName(Language), Debug, "target", true, true);
                    canCastSpell(SpellID1, 385616, EchoingReprimand_SpellName(Language), Debug, "target", true, true);
                    //Killing Spree
                    canCastSpell(SpellID1, 51690, KillingSpree_SpellName(Language), Debug, MeleeRange, "player", false, true);
                    //Adrenaline Rush
                    canCastSpell(SpellID1, 13750, AdrenalineRush_SpellName(Language), Debug, MeleeRange, "player", false, true);
                    //Sinister Strike
                    canCastSpell(SpellID1, 193315, SinisterStrike_SpellName(Language), Debug, "target", true, true);
                    //Ambush
                    canCastSpell(SpellID1, 8676, Ambush_SpellName(Language), Debug, "target", true, true);
                    //Pistol Shot
                    canCastSpell(SpellID1, 185763, PistolShot_SpellName(Language), Debug, "target", true, true);
                    //Between the Eyes
                    canCastSpell(SpellID1, 315341, BetweenTheEyes_SpellName(Language), Debug, "target", true, true);
                    //Dispatch
                    canCastSpell(SpellID1, 2098, Dispatch_SpellName(Language), Debug, "target", true, true);
                    //Gouge
                    canCastSpell(SpellID1, 1776, Gouge_SpellName(Language), Debug, "target", true, true);
                    //Ghostly Strike
                    canCastSpell(SpellID1, 196937, GhostlyStrike_SpellName(Language), Debug, "target", true, true);
                    //Dreadblades
                    canCastSpell(SpellID1, 343142, Dreadblades_SpellName(Language), Debug, "target", true, true);
                    //Blade Rush
                    canCastSpell(SpellID1, 271877, BladeRush_SpellName(Language), Debug, "target", true, true);
                    //Dismantle
                    canCastSpell(SpellID1, 207777, "Dismantle", Debug, "target", true, true);
                    //Plunder Armor
                    canCastSpell(SpellID1, 198529, "Plunder Armor", Debug, "target", true, true);

                    #endregion

                }

            }
            return false;
        }

        public override bool OutOfCombatTick()
        {
            #region Declarations
            int SpellID1 = Aimsharp.CustomFunction("HekiliID1");
            Aimsharp.PrintMessage("HekiliID => " + SpellID1, Color.Black);
            int PhialCount = Aimsharp.CustomFunction("PhialCount");
            bool Debug = GetCheckBox("Debug:");
            bool Moving = Aimsharp.PlayerIsMoving();
            bool Enemy = Aimsharp.TargetIsEnemy();
            bool SnDOOC = GetCheckBox("Slice and Dice Out of Combat:");
            bool StealthOOC = GetCheckBox("Stealth Out of Combat:");
            bool Sap = Aimsharp.IsCustomCodeOn("Sap");
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

            if (Aimsharp.IsCustomCodeOn("Distract") && Aimsharp.SpellCooldown(Distract_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("GrapplingHook") && Aimsharp.SpellCooldown(GrapplingHook_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            //Queues
            bool Blind = Aimsharp.IsCustomCodeOn("Blind");
            if (Aimsharp.SpellCooldown(Blind_SpellName(Language)) - Aimsharp.GCD() > 2000 && Blind)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blind Queue", Color.Purple);
                }
                Aimsharp.Cast("BlindOff");
                return true;
            }

            if (Blind && Aimsharp.CanCast(Blind_SpellName(Language), "mouseover", true, true))
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
            if (Aimsharp.SpellCooldown(Distract_SpellName(Language)) - Aimsharp.GCD() > 2000 && Distract)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Distract Queue", Color.Purple);
                }
                Aimsharp.Cast("DistractOff");
                return true;
            }

            if (Distract && Aimsharp.CanCast(Distract_SpellName(Language), "player", false, true))
            {
                switch (DistractCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Distract - " + DistractCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Distract_SpellName(Language));
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

            string GrapplingHookCast = GetDropDown("Grappling Hook Cast:");
            bool GrapplingHook = Aimsharp.IsCustomCodeOn("GrapplingHook");

            if (Aimsharp.SpellCooldown(GrapplingHook_SpellName(Language)) - Aimsharp.GCD() > 2000 && GrapplingHook)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off GrapplingHook Queue", Color.Purple);
                }
                Aimsharp.Cast("GrapplingHookOff");
                return true;
            }

            if (GrapplingHook && Aimsharp.CanCast(GrapplingHook_SpellName(Language), "player", false, true))
            {
                switch (GrapplingHookCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Grappling Hook - " + GrapplingHookCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(GrapplingHook_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Grappling Hook - " + GrapplingHookCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("GrapplingHookC");
                        return true;
                }
            }

            //Sap Queue
            if (Aimsharp.DebuffRemaining(Sap_SpellName(Language), "target", true) >= 59000 && Sap)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sap Queue", Color.Purple);
                }
                Aimsharp.Cast("SapOff");
                return true;
            }

            if (Sap && Aimsharp.CanCast(Sap_SpellName(Language), "target", true, true) && Enemy && TargetAlive())
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Sap (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(Sap_SpellName(Language));
                return true;
            }
            #endregion

            #region Out of Combat Spells
            //Auto Poison

            //General Rogue
            //Instant [GCD]
            ///Player
            if ((SpellID1 == 115191 || SpellID1 == 1784) && CanCastStealth("player") && StealthOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Stealth (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(Stealth_SpellName(Language));
                return true;
            }

            if (CanCastStealth("player") && !Aimsharp.HasBuff(Stealth_SpellName(Language), "player", true) && StealthOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Stealth (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(Stealth_SpellName(Language));
                return true;
            }

            if (SpellID1 == 315496 && !Aimsharp.HasBuff(SliceAndDice_SpellName(Language), "player") && CanCastSliceandDice("player") && Enemy && TargetAlive() && !Sap && SnDOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Slice and Dice (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(SliceAndDice_SpellName(Language));
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