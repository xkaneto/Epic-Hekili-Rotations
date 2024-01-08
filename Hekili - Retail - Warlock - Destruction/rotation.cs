﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicWarlockDestructionHekili : Rotation
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
        ///<summary>spell=328774</summary>
        private static string AmplifyCurse_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Amplify Curse";
                case "Deutsch": return "Fluch verstärken";
                case "Español": return "Amplificar maldición";
                case "Français": return "Malédiction amplifiée";
                case "Italiano": return "Amplificazione Maledizione";
                case "Português Brasileiro": return "Amplificar Maldição";
                case "Русский": return "Усиление проклятия";
                case "한국어": return "저주 증폭";
                case "简体中文": return "诅咒增幅";
                default: return "Amplify Curse";
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

        ///<summary>spell=710</summary>
        private static string Banish_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Banish";
                case "Deutsch": return "Verbannen";
                case "Español": return "Desterrar";
                case "Français": return "Bannir";
                case "Italiano": return "Esilio";
                case "Português Brasileiro": return "Banir";
                case "Русский": return "Изгнание";
                case "한국어": return "추방";
                case "简体中文": return "放逐术";
                default: return "Banish";
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

        ///<summary>spell=152108</summary>
        private static string Cataclysm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Cataclysm";
                case "Deutsch": return "Kataklysmus";
                case "Español": return "Cataclismo";
                case "Français": return "Cataclysme";
                case "Italiano": return "Cataclisma";
                case "Português Brasileiro": return "Cataclismo";
                case "Русский": return "Катаклизм";
                case "한국어": return "대재앙";
                case "简体中文": return "大灾变";
                default: return "Cataclysm";
            }
        }

        ///<summary>spell=196447</summary>
        private static string ChannelDemonfire_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Channel Demonfire";
                case "Deutsch": return "Dämonenfeuer kanalisieren";
                case "Español": return "Canalizar fuego demoníaco";
                case "Français": return "Canalisation de feu démoniaque";
                case "Italiano": return "Canalizzazione Fuoco Demoniaco";
                case "Português Brasileiro": return "Canalizar Fogo Demoníaco";
                case "Русский": return "Направленный демонический огонь";
                case "한국어": return "악마불 집중";
                case "简体中文": return "引导恶魔之火";
                default: return "Channel Demonfire";
            }
        }

        ///<summary>spell=116858</summary>
        private static string ChaosBolt_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Chaos Bolt";
                case "Deutsch": return "Chaosblitz";
                case "Español": return "Descarga de caos";
                case "Français": return "Trait du chaos";
                case "Italiano": return "Dardo del Caos";
                case "Português Brasileiro": return "Seta do Caos";
                case "Русский": return "Стрела Хаоса";
                case "한국어": return "혼돈의 화살";
                case "简体中文": return "混乱之箭";
                default: return "Chaos Bolt";
            }
        }

        ///<summary>spell=17962</summary>
        private static string Conflagrate_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Conflagrate";
                case "Deutsch": return "Feuersbrunst";
                case "Español": return "Conflagrar";
                case "Français": return "Conflagration";
                case "Italiano": return "Conflagrazione";
                case "Português Brasileiro": return "Conflagrar";
                case "Русский": return "Поджигание";
                case "한국어": return "점화";
                case "简体中文": return "燃烧";
                default: return "Conflagrate";
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

        ///<summary>spell=334275</summary>
        private static string CurseOfExhaustion_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Curse of Exhaustion";
                case "Deutsch": return "Fluch der Erschöpfung";
                case "Español": return "Maldición de agotamiento";
                case "Français": return "Malédiction d’épuisement";
                case "Italiano": return "Maledizione dello Sfinimento";
                case "Português Brasileiro": return "Maldição da Exaustão";
                case "Русский": return "Проклятие изнеможения";
                case "한국어": return "피로의 저주";
                case "简体中文": return "疲劳诅咒";
                default: return "Curse of Exhaustion";
            }
        }

        ///<summary>spell=199890</summary>
        private static string CurseOfTongues_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Curse of Tongues";
                case "Deutsch": return "Fluch der Sprachen";
                case "Español": return "Maldición de las lenguas";
                case "Français": return "Malédiction des langages";
                case "Italiano": return "Maledizione delle Lingue";
                case "Português Brasileiro": return "Maldição de Línguas";
                case "Русский": return "Проклятие косноязычия";
                case "한국어": return "언어의 저주";
                case "简体中文": return "语言诅咒";
                default: return "Curse of Tongues";
            }
        }

        ///<summary>spell=702</summary>
        private static string CurseOfWeakness_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Curse of Weakness";
                case "Deutsch": return "Fluch der Schwäche";
                case "Español": return "Maldición de debilidad";
                case "Français": return "Malédiction de faiblesse";
                case "Italiano": return "Maledizione della Debolezza";
                case "Português Brasileiro": return "Maldição da Fraqueza";
                case "Русский": return "Проклятие слабости";
                case "한국어": return "무력화 저주";
                case "简体中文": return "虚弱诅咒";
                default: return "Curse of Weakness";
            }
        }

        ///<summary>spell=108416</summary>
        private static string DarkPact_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dark Pact";
                case "Deutsch": return "Dunkler Pakt";
                case "Español": return "Pacto oscuro";
                case "Français": return "Sombre pacte";
                case "Italiano": return "Patto Oscuro";
                case "Português Brasileiro": return "Pacto Sombrio";
                case "Русский": return "Темный пакт";
                case "한국어": return "어둠의 서약";
                case "简体中文": return "黑暗契约";
                default: return "Dark Pact";
            }
        }

        ///<summary>spell=113858</summary>
        private static string DarkSoul_Instability_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dark Soul: Instability";
                case "Deutsch": return "Finstere Seele: Instabilität";
                case "Español": return "Alma oscura: Inestabilidad";
                case "Français": return "Âme sombre : Instabilité";
                case "Italiano": return "Anima Oscura: Instabilità";
                case "Português Brasileiro": return "Alma Negra: Instabilidade";
                case "Русский": return "Черная душа: нестабильность";
                case "한국어": return "악마의 영혼: 불안정";
                case "简体中文": return "黑暗灵魂：动荡";
                default: return "Dark Soul: Instability";
            }
        }

        ///<summary>spell=325289</summary>
        private static string DecimatingBolt_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Decimating Bolt";
                case "Deutsch": return "Dezimierungsblitz";
                case "Español": return "Descarga exterminadora";
                case "Français": return "Trait de décimation";
                case "Italiano": return "Dardo della Decimazione";
                case "Português Brasileiro": return "Seta Dizimadora";
                case "Русский": return "Стрела опустошения";
                case "한국어": return "학살의 화살";
                case "简体中文": return "屠戮箭";
                default: return "Decimating Bolt";
            }
        }

        ///<summary>spell=48018</summary>
        private static string DemonicCircle_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Demonic Circle";
                case "Deutsch": return "Dämonischer Zirkel";
                case "Español": return "Círculo demoníaco";
                case "Français": return "Cercle démoniaque";
                case "Italiano": return "Circolo Demoniaco";
                case "Português Brasileiro": return "Círculo Demoníaco";
                case "Русский": return "Демонический круг";
                case "한국어": return "악마의 마법진";
                case "简体中文": return "恶魔法阵";
                default: return "Demonic Circle";
            }
        }

        ///<summary>spell=48020</summary>
        private static string DemonicCircle_Teleport_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Demonic Circle: Teleport";
                case "Deutsch": return "Dämonischer Zirkel: Teleportieren";
                case "Español": return "Círculo demoníaco: Teletransporte";
                case "Français": return "Cercle démoniaque - Téléportation";
                case "Italiano": return "Teletrasporto: Circolo Demoniaco";
                case "Português Brasileiro": return "Círculo Demoníaco: Teleporte";
                case "Русский": return "Демонический круг: телепортация";
                case "한국어": return "악마의 마법진: 순간이동";
                case "简体中文": return "恶魔法阵：传送";
                default: return "Demonic Circle: Teleport";
            }
        }

        ///<summary>spell=111771</summary>
        private static string DemonicGateway_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Demonic Gateway";
                case "Deutsch": return "Dämonisches Tor";
                case "Español": return "Portal demoníaco";
                case "Français": return "Porte des démons";
                case "Italiano": return "Varco Demoniaco";
                case "Português Brasileiro": return "Portal Demoníaco";
                case "Русский": return "Демонические врата";
                case "한국어": return "악마의 관문";
                case "简体中文": return "恶魔传送门";
                default: return "Demonic Gateway";
            }
        }

        ///<summary>spell=19505</summary>
        private static string DevourMagic_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Devour Magic";
                case "Deutsch": return "Magie verschlingen";
                case "Español": return "Devorar magia";
                case "Français": return "Dévorer la magie";
                case "Italiano": return "Divora Magie";
                case "Português Brasileiro": return "Devorar Magia";
                case "Русский": return "Пожирание магии";
                case "한국어": return "마법 삼키기";
                case "简体中文": return "吞噬魔法";
                default: return "Devour Magic";
            }
        }

        ///<summary>spell=387976</summary>
        private static string DimensionalRift_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dimensional Rift";
                case "Deutsch": return "Dimensionsriss";
                case "Español": return "Falla dimensional";
                case "Français": return "Faille dimensionnelle";
                case "Italiano": return "Fenditura Dimensionale";
                case "Português Brasileiro": return "Fenda Dimensional";
                case "Русский": return "Пространственный разлом";
                case "한국어": return "차원의 균열";
                case "简体中文": return "次元裂隙";
                default: return "Dimensional Rift";
            }
        }

        ///<summary>spell=234153</summary>
        private static string DrainLife_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Drain Life";
                case "Deutsch": return "Blutsauger";
                case "Español": return "Drenar vida";
                case "Français": return "Drain de vie";
                case "Italiano": return "Risucchio di Vita";
                case "Português Brasileiro": return "Drenar Vida";
                case "Русский": return "Похищение жизни";
                case "한국어": return "생명력 흡수";
                case "简体中文": return "吸取生命";
                default: return "Drain Life";
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

        ///<summary>spell=5782</summary>
        private static string Fear_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fear";
                case "Deutsch": return "Furcht";
                case "Español": return "Miedo";
                case "Français": return "Peur";
                case "Italiano": return "Paura";
                case "Português Brasileiro": return "Medo";
                case "Русский": return "Страх";
                case "한국어": return "공포";
                case "简体中文": return "恐惧";
                default: return "Fear";
            }
        }

        ///<summary>spell=333889</summary>
        private static string FelDomination_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fel Domination";
                case "Deutsch": return "Teufelsbeherrschung";
                case "Español": return "Dominación vil";
                case "Français": return "Domination gangrenée";
                case "Italiano": return "Vildominio";
                case "Português Brasileiro": return "Dominância Vil";
                case "Русский": return "Власть Скверны";
                case "한국어": return "지옥 지배";
                case "简体中文": return "邪能统御";
                default: return "Fel Domination";
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

        ///<summary>spell=108503</summary>
        private static string GrimoireOfSacrifice_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Grimoire of Sacrifice";
                case "Deutsch": return "Grimoire der Opferung";
                case "Español": return "Grimorio de sacrificio";
                case "Français": return "Grimoire de sacrifice";
                case "Italiano": return "Rito del Sacrificio";
                case "Português Brasileiro": return "Grimório de Sacrificar";
                case "Русский": return "Гримуар жертвоприношения";
                case "한국어": return "흑마법서: 희생";
                case "简体中文": return "牺牲魔典";
                default: return "Grimoire of Sacrifice";
            }
        }

        ///<summary>spell=80240</summary>
        private static string Havoc_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Havoc";
                case "Deutsch": return "Verwüstung";
                case "Español": return "Estragos";
                case "Français": return "Tumulte";
                case "Italiano": return "Calamità";
                case "Português Brasileiro": return "Devastação";
                case "Русский": return "Хаос";
                case "한국어": return "대혼란";
                case "简体中文": return "浩劫";
                default: return "Havoc";
            }
        }

        ///<summary>spell=755</summary>
        private static string HealthFunnel_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Health Funnel";
                case "Deutsch": return "Lebenslinie";
                case "Español": return "Cauce de salud";
                case "Français": return "Captation de vie";
                case "Italiano": return "Trasfusione Vitale";
                case "Português Brasileiro": return "Funil de Vida";
                case "Русский": return "Канал здоровья";
                case "한국어": return "생명력 집중";
                case "简体中文": return "生命通道";
                default: return "Health Funnel";
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

        ///<summary>spell=5484</summary>
        private static string HowlOfTerror_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Howl of Terror";
                case "Deutsch": return "Schreckensgeheul";
                case "Español": return "Aullido de terror";
                case "Français": return "Hurlement de terreur";
                case "Italiano": return "Grido Terrorizzante";
                case "Português Brasileiro": return "Uivo do Terror";
                case "Русский": return "Вой ужаса";
                case "한국어": return "공포의 울부짖음";
                case "简体中文": return "恐惧嚎叫";
                default: return "Howl of Terror";
            }
        }

        ///<summary>spell=348</summary>
        private static string Immolate_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Immolate";
                case "Deutsch": return "Feuerbrand";
                case "Español": return "Inmolar";
                case "Français": return "Immolation";
                case "Italiano": return "Immolazione";
                case "Português Brasileiro": return "Imolação";
                case "Русский": return "Жертвенный огонь";
                case "한국어": return "제물";
                case "简体中文": return "献祭";
                default: return "Immolate";
            }
        }

        ///<summary>spell=321792</summary>
        private static string ImpendingCatastrophe_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Impending Catastrophe";
                case "Deutsch": return "Drohende Katastrophe";
                case "Español": return "Catástrofe inminente";
                case "Français": return "Catastrophe imminente";
                case "Italiano": return "Catastrofe Imminente";
                case "Português Brasileiro": return "Catástrofe Iminente";
                case "Русский": return "Неотвратимая катастрофа";
                case "한국어": return "다가오는 대재앙";
                case "简体中文": return "灾祸降临";
                default: return "Impending Catastrophe";
            }
        }

        ///<summary>spell=29722</summary>
        private static string Incinerate_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Incinerate";
                case "Deutsch": return "Verbrennen";
                case "Español": return "Incinerar";
                case "Français": return "Incinérer";
                case "Italiano": return "Incenerimento";
                case "Português Brasileiro": return "Incinerar";
                case "Русский": return "Испепеление";
                case "한국어": return "소각";
                case "简体中文": return "烧尽";
                default: return "Incinerate";
            }
        }

        ///<summary>spell=386344</summary>
        private static string InquisitorsGaze_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Inquisitor's Gaze";
                case "Deutsch": return "Blick des Inquisitors";
                case "Español": return "Mirada del inquisidor";
                case "Français": return "Regard de l’inquisitrice";
                case "Italiano": return "Sguardo dell'Inquisitore";
                case "Português Brasileiro": return "Olhar do Inquisidor";
                case "Русский": return "Взгляд инквизитора";
                case "한국어": return "심문관의 시선";
                case "简体中文": return "审判官的凝视";
                default: return "Inquisitor's Gaze";
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

        ///<summary>spell=6789</summary>
        private static string MortalCoil_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mortal Coil";
                case "Deutsch": return "Weltliche Ängste";
                case "Español": return "Espiral mortal";
                case "Français": return "Voile de mort";
                case "Italiano": return "Spira Letale";
                case "Português Brasileiro": return "Espiral da Morte";
                case "Русский": return "Лик тлена";
                case "한국어": return "필멸의 고리";
                case "简体中文": return "死亡缠绕";
                default: return "Mortal Coil";
            }
        }

        ///<summary>spell=42223</summary>
        private static string RainOfFire_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rain of Fire";
                case "Deutsch": return "Feuerregen";
                case "Español": return "Lluvia de Fuego";
                case "Français": return "Pluie de feu";
                case "Italiano": return "Pioggia di Fuoco";
                case "Português Brasileiro": return "Chuva de Fogo";
                case "Русский": return "Огненный ливень";
                case "한국어": return "불의 비";
                case "简体中文": return "火焰之雨";
                default: return "Rain of Fire";
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

        ///<summary>spell=312321</summary>
        private static string ScouringTithe_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Scouring Tithe";
                case "Deutsch": return "Geißelnder Obolus";
                case "Español": return "Diezmo asolador";
                case "Français": return "Dîme spoliatrice";
                case "Italiano": return "Obolo";
                case "Português Brasileiro": return "Dízimo Expurgante";
                case "Русский": return "Очищающее пожертвование";
                case "한국어": return "헌금 갈취";
                case "简体中文": return "碎魂奉纳";
                default: return "Scouring Tithe";
            }
        }

        ///<summary>spell=6358</summary>
        private static string Seduction_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Seduction";
                case "Deutsch": return "Verführung";
                case "Español": return "Seducción";
                case "Français": return "Séduction";
                case "Italiano": return "Seduzione";
                case "Português Brasileiro": return "Sedução";
                case "Русский": return "Соблазн";
                case "한국어": return "유혹";
                case "简体中文": return "诱惑";
                default: return "Seduction";
            }
        }

        ///<summary>spell=686</summary>
        private static string ShadowBolt_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shadow Bolt";
                case "Deutsch": return "Schattenblitz";
                case "Español": return "Descarga de las Sombras";
                case "Français": return "Trait de l'ombre";
                case "Italiano": return "Dardo d'Ombra";
                case "Português Brasileiro": return "Seta Sombria";
                case "Русский": return "Стрела Тьмы";
                case "한국어": return "어둠의 화살";
                case "简体中文": return "暗影箭";
                default: return "Shadow Bolt";
            }
        }

        ///<summary>spell=17877</summary>
        private static string Shadowburn_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shadowburn";
                case "Deutsch": return "Schattenbrand";
                case "Español": return "Quemadura de las Sombras";
                case "Français": return "Brûlure de l’ombre";
                case "Italiano": return "Combustione dell'Ombra";
                case "Português Brasileiro": return "Sombra Ardente";
                case "Русский": return "Ожог Тьмы";
                case "한국어": return "어둠의 연소";
                case "简体中文": return "暗影灼烧";
                default: return "Shadowburn";
            }
        }

        ///<summary>spell=30283</summary>
        private static string Shadowfury_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shadowfury";
                case "Deutsch": return "Schattenfuror";
                case "Español": return "Furia de las Sombras";
                case "Français": return "Furie de l’ombre";
                case "Italiano": return "Furia dell'Ombra";
                case "Português Brasileiro": return "Fúria Sombria";
                case "Русский": return "Неистовство Тьмы";
                case "한국어": return "어둠의 격노";
                case "简体中文": return "暗影之怒";
                default: return "Shadowfury";
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

        ///<summary>spell=89808</summary>
        private static string SingeMagic_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Singe Magic";
                case "Deutsch": return "Magie versengen";
                case "Español": return "Magia de carbonización";
                case "Français": return "Brûle-magie";
                case "Italiano": return "Consuma Magie";
                case "Português Brasileiro": return "Chamusco Mágico";
                case "Русский": return "Опаляющая магия";
                case "한국어": return "마법 태우기";
                case "简体中文": return "烧灼驱魔";
                default: return "Singe Magic";
            }
        }

        ///<summary>spell=6353</summary>
        private static string SoulFire_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Soul Fire";
                case "Deutsch": return "Seelenfeuer";
                case "Español": return "Fuego de alma";
                case "Français": return "Feu de l’âme";
                case "Italiano": return "Fuoco dell'Anima";
                case "Português Brasileiro": return "Fogo d'Alma";
                case "Русский": return "Ожог души";
                case "한국어": return "영혼의 불꽃";
                case "简体中文": return "灵魂之火";
                default: return "Soul Fire";
            }
        }

        ///<summary>spell=325640</summary>
        private static string SoulRot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Soul Rot";
                case "Deutsch": return "Seelenfäule";
                case "Español": return "Putrefacción de alma";
                case "Français": return "Pourriture d’âme";
                case "Italiano": return "Putrefazione d'Anima";
                case "Português Brasileiro": return "Apodrecimento d'Alma";
                case "Русский": return "Гниение души";
                case "한국어": return "영혼 부식";
                case "简体中文": return "灵魂腐化";
                default: return "Soul Rot";
            }
        }

        ///<summary>spell=385899</summary>
        private static string Soulburn_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Soulburn";
                case "Deutsch": return "Seelenbrand";
                case "Español": return "Quemar alma";
                case "Français": return "Brûlure d’âme";
                case "Italiano": return "Consumo d'Anima";
                case "Português Brasileiro": return "Queimadura Anímica";
                case "Русский": return "Горящая душа";
                case "한국어": return "영혼 불사르기";
                case "简体中文": return "灵魂燃烧";
                default: return "Soulburn";
            }
        }

        ///<summary>spell=119910</summary>
        private static string SpellLock_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Spell Lock";
                case "Deutsch": return "Zaubersperre";
                case "Español": return "Bloqueo de hechizo";
                case "Français": return "Verrou magique";
                case "Italiano": return "Blocca Incantesimo";
                case "Português Brasileiro": return "Bloquear Feitiço";
                case "Русский": return "Запрет чар";
                case "한국어": return "주문 잠금";
                case "简体中文": return "法术封锁";
                default: return "Spell Lock";
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

        ///<summary>spell=1122</summary>
        private static string SummonInfernal_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Summon Infernal";
                case "Deutsch": return "Höllenbestie beschwören";
                case "Español": return "Invocar infernal";
                case "Français": return "Invocation : infernal";
                case "Italiano": return "Evocazione: Infernale";
                case "Português Brasileiro": return "Evocar Infernal";
                case "Русский": return "Призыв инфернала";
                case "한국어": return "지옥불정령 소환";
                case "简体中文": return "召唤地狱火";
                default: return "Summon Infernal";
            }
        }

        ///<summary>spell=386244</summary>
        private static string SummonSoulkeeper_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Summon Soulkeeper";
                case "Deutsch": return "Seelenbewahrer beschwören";
                case "Español": return "Invocar guardián de almas";
                case "Français": return "Invocation de gardien d’âmes";
                case "Italiano": return "Evocazione: Custode delle Anime";
                case "Português Brasileiro": return "Evocar Porta-almas";
                case "Русский": return "Призыв хранителя душ";
                case "한국어": return "영혼지킴이 소환";
                case "简体中文": return "召唤护魂者";
                default: return "Summon Soulkeeper";
            }
        }

        ///<summary>spell=104773</summary>
        private static string UnendingResolve_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Unending Resolve";
                case "Deutsch": return "Erbarmungslose Entschlossenheit";
                case "Español": return "Resolución inagotable";
                case "Français": return "Résolution interminable";
                case "Italiano": return "Determinazione Assoluta";
                case "Português Brasileiro": return "Determinação Interminável";
                case "Русский": return "Твердая решимость";
                case "한국어": return "영원한 결의";
                case "简体中文": return "不灭决心";
                default: return "Unending Resolve";
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
        string UsableItem;
        Stopwatch HSTimer = new Stopwatch();
        Stopwatch ItemTimer = new Stopwatch();
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoDecurse", "NoCycle", "Banish", "Fear", "Shadowfury", "RainofFire", "HowlofTerror", "MortalCoil", "RainofFireCursor", "SummonInfernal", "Cataclysm", "CataclysmCursor" };
        private List<string> m_DebuffsList;
        private List<string> m_BuffsList;
        private List<string> m_ItemsList;
        private List<string> m_SpellBook;

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

        List<int> SpecialSpellIDs = new List<int> { 348, 80240, };
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
        private bool CanCastCheck(string SpellName, string target, bool RangeCheck = true, bool CastCheck = true)
        {
            if (Aimsharp.CanCast(SpellName, target, RangeCheck, CastCheck) || Aimsharp.SpellCooldown(SpellName) - Aimsharp.GCD() <= 0 || (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow")) || Aimsharp.GCD() == 0)
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

            //Healthstone
            Macros.Add("UseHealthstone", "/use " + Healthstone_SpellName(Language));
            Macros.Add("UseItem", "/use " + UsableItem);

            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + (Aimsharp.Latency + 100));

            //Queues
            Macros.Add("BanishOff", "/" + FiveLetters + " Banish");
            Macros.Add("FearOff", "/" + FiveLetters + " Fear");
            Macros.Add("ShadowfuryOff", "/" + FiveLetters + " Shadowfury");
            Macros.Add("RainofFireOff", "/" + FiveLetters + " RainofFire");
            Macros.Add("HowlofTerrorOff", "/" + FiveLetters + " HowlofTerror");
            Macros.Add("MortalCoilOff", "/" + FiveLetters + " MortalCoil");
            Macros.Add("SummonInfernalOff", "/" + FiveLetters + " SummonInfernal");
            Macros.Add("CataclysmOff", "/" + FiveLetters + " Cataclysm");

            Macros.Add("BanishMO", "/cast [@mouseover,exists] " + Banish_SpellName(Language));
            Macros.Add("FearMO", "/cast [@mouseover,exists] " + Fear_SpellName(Language));
            Macros.Add("HavocMO", "/cast [@mouseover,exists] " + Havoc_SpellName(Language));
            Macros.Add("ImmolateMO", "/cast [@mouseover,exists] " + Immolate_SpellName(Language));
            Macros.Add("ShadowfuryC", "/cast [@cursor] " + Shadowfury_SpellName(Language));
            Macros.Add("ShadowfuryP", "/cast [@player] " + Shadowfury_SpellName(Language));
            Macros.Add("RainofFireC", "/cast [@cursor] " + RainOfFire_SpellName(Language));
            Macros.Add("RainofFireP", "/cast [@player] " + RainOfFire_SpellName(Language));
            Macros.Add("SummonInfernalC", "/cast [@cursor] " + SummonInfernal_SpellName(Language));
            Macros.Add("SummonInfernalP", "/cast [@player] " + SummonInfernal_SpellName(Language));
            Macros.Add("CataclysmC", "/cast [@cursor] " + Cataclysm_SpellName(Language));
            Macros.Add("CataclysmP", "/cast [@player] " + Cataclysm_SpellName(Language));
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

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("HekiliEnemies", "if Hekili.State.active_enemies ~= nil and Hekili.State.active_enemies > 0 then return Hekili.State.active_enemies end return 0");

            CustomFunctions.Add("PhialCount", "local count = GetItemCount(177278) if count ~= nil then return count end return 0");

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

            CustomFunctions.Add("RainofFireMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Immolate','mouseover') == 1 then return 1 end; return 0");
            CustomFunctions.Add("RainofFireMouseoverNC", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and IsSpellInRange('Immolate','mouseover') == 1 then return 1 end; return 0");

            CustomFunctions.Add("CycleNotEnabled", "local cycle = 0 if Hekili.State.settings.spec.cycle == true then cycle = 1 else if Hekili.State.settings.spec.cycle == false then cycle = 2 end end return cycle");

        }
        #endregion

        public override void LoadSettings()
        {
            Settings.Add(new Setting("Misc"));
            Settings.Add(new Setting("Leveling/Questing:", false));
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
            Settings.Add(new Setting("Auto Dark Pact @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Drain Life @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Auto Health Funnel @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Unending Resolve @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Shadowfury Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Summon Infernal Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Cataclysm Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Always Cast Cataclysm @ Cursor during Rotation", false));
            Settings.Add(new Setting("Rain of Fire Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Always Cast Rain of Fire @ Cursor during Rotation", false));
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

            Aimsharp.PrintMessage("Epic PVE - Warlock Destruction", Color.White);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything in every tab there, especially Pause !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/warlock/destruction/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("You will need to summon your primary Demon yourself!", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.White);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Fear - Casts Fear @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Banish - Casts Banish @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " HowlofTerror - Casts Howl of Terror @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " MortalCoil - Casts Mortal Coil @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Shadowfury - Casts Shadowfury @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " SummonInfernal - Casts Summon Infernal @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Cataclysm - Casts Cataclysm @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " CataclysmCursor - Toggles Rain of Fire always @ Cursor (same as Option)", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " RainofFire - Casts Rain of Fire @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " RainofFireCursor - Toggles Rain of Fire always @ Cursor (same as Option)", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);

            Language = GetDropDown("Game Client Language");
            UsableItem = GetString("Item Use:");

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
            m_DebuffsList = new List<string> { Banish_SpellName(Language), Fear_SpellName(Language), Immolate_SpellName(Language), Havoc_SpellName(Language), };
            m_BuffsList = new List<string> { };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language), UsableItem};
            m_SpellBook = new List<string> {
                //Covenants
                ScouringTithe_SpellName(Language), //312321
                ImpendingCatastrophe_SpellName(Language), //321792
                SoulRot_SpellName(Language), //325640
                DecimatingBolt_SpellName(Language), //325289

                //Interrupt
                SpellLock_SpellName(Language), //119910

                //General
                AmplifyCurse_SpellName(Language), //328774
                Banish_SpellName(Language), //710
                Corruption_SpellName(Language), //172
                CurseOfExhaustion_SpellName(Language), //334275
                CurseOfTongues_SpellName(Language), //1714
                CurseOfWeakness_SpellName(Language), //702
                DarkPact_SpellName(Language), //108416
                DemonicCircle_Teleport_SpellName(Language), //48020
                DemonicCircle_SpellName(Language), //48018
                DemonicGateway_SpellName(Language), //111771
                DrainLife_SpellName(Language), //234153
                Fear_SpellName(Language), //5782
                FelDomination_SpellName(Language), //333889
                HealthFunnel_SpellName(Language), //755
                HowlOfTerror_SpellName(Language), //5484
                InquisitorsGaze_SpellName(Language), //386344
                MortalCoil_SpellName(Language), //6789
                ShadowBolt_SpellName(Language), //686
                Shadowfury_SpellName(Language), //30283
                Soulburn_SpellName(Language), //385899
                SummonSoulkeeper_SpellName(Language), //386244
                UnendingResolve_SpellName(Language), //104773

                //Pet
                DevourMagic_SpellName(Language), //19505
                Seduction_SpellName(Language), //6358
                SingeMagic_SpellName(Language), //89808

                //Destruction
                Cataclysm_SpellName(Language), //152108 - place
                ChannelDemonfire_SpellName(Language), //196447
                ChaosBolt_SpellName(Language), //116858
                Conflagrate_SpellName(Language), //17962
                DarkSoul_Instability_SpellName(Language), //113858
                DimensionalRift_SpellName(Language), //387976
                GrimoireOfSacrifice_SpellName(Language), //108503
                Havoc_SpellName(Language), //80240
                Immolate_SpellName(Language), //348
                Incinerate_SpellName(Language), //29722
                RainOfFire_SpellName(Language), //5740,42223
                Shadowburn_SpellName(Language), //17877
                SoulFire_SpellName(Language), //6353
                SummonInfernal_SpellName(Language), //1122 - place
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
            int CooldownsToggle = Aimsharp.CustomFunction("CooldownsToggleCheck");
            int Wait = Aimsharp.CustomFunction("HekiliWait");
            int Enemies = Aimsharp.CustomFunction("HekiliEnemies");
            int TargetingGroup = Aimsharp.CustomFunction("GroupTargets");

            bool NoInterrupts = Aimsharp.IsCustomCodeOn("NoInterrupts");
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
            int PetHP = Aimsharp.Health("pet");

            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());

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
            if (Aimsharp.CastingID("player") == 710 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Banish"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Banish Queue", Color.Purple);
                }
                Aimsharp.Cast("BanishOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 5782 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Fear"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fear Queue", Color.Purple);
                }
                Aimsharp.Cast("FearOff");
                return true;
            }

            //Auto Shadowburn (Leveling/Questing)
            bool Leveling = GetCheckBox("Leveling/Questing:");
            if (Leveling && CanCastCheck(Shadowburn_SpellName(Language), "target", true, false) && Aimsharp.Health("target") <= 20 && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                if (Aimsharp.CastingID("player") > 0)
                {
                    Aimsharp.StopCasting();
                }
                Aimsharp.Cast(Shadowburn_SpellName(Language));
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

            if (Aimsharp.IsCustomCodeOn("Shadowfury") && Aimsharp.SpellCooldown(Shadowfury_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("RainofFire") && Aimsharp.SpellCooldown(RainOfFire_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("Cataclysm") && Aimsharp.SpellCooldown(Cataclysm_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("SummonInfernal") && Aimsharp.SpellCooldown(SummonInfernal_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                if (CanCastCheck(SpellLock_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(SpellLock_SpellName(Language), true);
                        return true;
                    }
                }

                if (CanCastCheck(SpellLock_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(SpellLock_SpellName(Language), true);
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

            //Auto Unending Resolve
            if (Aimsharp.CanCast(UnendingResolve_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Unending Resolve @ HP%"))
                {
                    Aimsharp.Cast(UnendingResolve_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Unending Resolve - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Unending Resolve @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Dark Pact
            if (Aimsharp.CanCast(DarkPact_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Dark Pact @ HP%"))
                {
                    Aimsharp.Cast(DarkPact_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Dark Pact - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Dark Pact @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Drain Life
            if (Aimsharp.CanCast(DrainLife_SpellName(Language), "target", true, true))
            {
                if (PlayerHP <= GetSlider("Auto Drain Life @ HP%"))
                {
                    Aimsharp.Cast(DrainLife_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Drain Life - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Drain Life @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Health Funnel
            if (Aimsharp.CanCast(HealthFunnel_SpellName(Language), "pet", true, true))
            {
                if (PetHP <= GetSlider("Auto Health Funnel @ HP%") && PetHP > 1)
                {
                    Aimsharp.Cast(HealthFunnel_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Health Funnel - Pet HP% " + PetHP + " due to setting being on HP% " + GetSlider("Auto Health Funnel @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }
            #endregion

            #region Queues
            bool Banish = Aimsharp.IsCustomCodeOn("Banish");
            if ((Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Banish)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Banish Queue", Color.Purple);
                }
                Aimsharp.Cast("BanishOff");
                return true;
            }

            if (Banish && CanCastCheck(Banish_SpellName(Language), "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Banish - Queue", Color.Purple);
                }
                Aimsharp.Cast("BanishMO");
                return true;
            }

            bool Fear = Aimsharp.IsCustomCodeOn("Fear");
            if ((Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Fear)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fear Queue", Color.Purple);
                }
                Aimsharp.Cast("FearOff");
                return true;
            }

            if (Fear && CanCastCheck(Fear_SpellName(Language), "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fear - Queue", Color.Purple);
                }
                Aimsharp.Cast("FearMO");
                return true;
            }

            bool MortalCoil = Aimsharp.IsCustomCodeOn("MortalCoil");
            if (Aimsharp.SpellCooldown(Shadowfury_SpellName(Language)) - Aimsharp.GCD() > 2000 && MortalCoil)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mortal Coil Queue", Color.Purple);
                }
                Aimsharp.Cast("MortalCoilOff");
                return true;
            }

            if (MortalCoil && CanCastCheck(MortalCoil_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mortal Coil - Queue", Color.Purple);
                }
                Aimsharp.Cast(MortalCoil_SpellName(Language));
                return true;
            }

            bool HowlofTerror = Aimsharp.IsCustomCodeOn("HowlofTerror");
            if (Aimsharp.SpellCooldown(Shadowfury_SpellName(Language)) - Aimsharp.GCD() > 2000 && HowlofTerror)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Howl of Terror Queue", Color.Purple);
                }
                Aimsharp.Cast("HowlofTerrorOff");
                return true;
            }

            if (HowlofTerror && CanCastCheck(HowlOfTerror_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Howl of Terror - Queue", Color.Purple);
                }
                Aimsharp.Cast(HowlOfTerror_SpellName(Language));
                return true;
            }

            //Queue Shadowfury
            string ShadowfuryCast = GetDropDown("Shadowfury Cast:");
            bool Shadowfury = Aimsharp.IsCustomCodeOn("Shadowfury");
            if ((Aimsharp.SpellCooldown(Shadowfury_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && Shadowfury)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shadowfury Queue", Color.Purple);
                }
                Aimsharp.Cast("ShadowfuryOff");
                return true;
            }

            if (Shadowfury && CanCastCheck(Shadowfury_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (ShadowfuryCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Shadowfury_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowfuryP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowfuryC");
                        return true;
                }
            }

            //Queue Rain of Fire
            string RainofFireCast = GetDropDown("Rain of Fire Cast:");
            bool RainofFire = Aimsharp.IsCustomCodeOn("RainofFire");
            if ((Aimsharp.SpellCooldown(RainOfFire_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving || Aimsharp.LastCast() == RainOfFire_SpellName(Language)) && RainofFire)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Rain of Fire Queue", Color.Purple);
                }
                Aimsharp.Cast("RainofFireOff");
                return true;
            }

            if (RainofFire && CanCastCheck(RainOfFire_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (RainofFireCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire - " + RainofFireCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(RainOfFire_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire - " + RainofFireCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RainofFireP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire - " + RainofFireCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RainofFireC");
                        return true;
                }
            }

            //Queue Summon Infernal
            string SummonInfernalCast = GetDropDown("Summon Infernal Cast:");
            bool SummonInfernal = Aimsharp.IsCustomCodeOn("SummonInfernal");
            if ((Aimsharp.SpellCooldown(SummonInfernal_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && SummonInfernal)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Summon Infernal Queue", Color.Purple);
                }
                Aimsharp.Cast("SummonInfernalOff");
                return true;
            }

            if (SummonInfernal && CanCastCheck(SummonInfernal_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (SummonInfernalCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SummonInfernal_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SummonInfernalP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SummonInfernalC");
                        return true;
                }
            }

            //Queue Cataclysm
            string CataclysmCast = GetDropDown("Cataclysm Cast:");
            bool Cataclysm = Aimsharp.IsCustomCodeOn("Cataclysm");
            if ((Aimsharp.SpellCooldown(Cataclysm_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && Cataclysm)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Cataclysm Queue", Color.Purple);
                }
                Aimsharp.Cast("CataclysmOff");
                return true;
            }

            if (Cataclysm && CanCastCheck(Cataclysm_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (CataclysmCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm - " + CataclysmCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Cataclysm_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm - " + CataclysmCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CataclysmP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm - " + CataclysmCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CataclysmC");
                        return true;
                }
            }
            #endregion

            #region Auto Target
            //Hekili Cycle
            if (!NoCycle && Aimsharp.CustomFunction("CycleNotEnabled") == 1 && Aimsharp.CustomFunction("HekiliCycle") == 1 && Enemies > 1 && (SpellID1 == 348 && Aimsharp.HasDebuff(Immolate_SpellName(Language), "target", true) || SpellID1 != 80240))
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
                if (!Aimsharp.HasDebuff(Banish_SpellName(Language), "target", true) && !Aimsharp.HasDebuff(Fear_SpellName(Language), "target", true) && !Banish && !Fear)
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
                    #endregion

                    #region Racials
                    //Racials
                    if (SpellID1 == 28880 && CanCastCheck(GiftOfTheNaaru_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Gift of the Naaru - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(GiftOfTheNaaru_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 20594 && CanCastCheck(Stoneform_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Stoneform - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Stoneform_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 20589 && CanCastCheck(EscapeArtist_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Escape Artist - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(EscapeArtist_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 59752 && CanCastCheck(WillToSurvive_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Will to Survive - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WillToSurvive_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 255647 && CanCastCheck(LightsJudgment_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Light's Judgment - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(LightsJudgment_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 265221 && CanCastCheck(Fireblood_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fireblood - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Fireblood_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 69041 && CanCastCheck(RocketBarrage_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rocket Barrage - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RocketBarrage_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 20549 && CanCastCheck(WarStomp_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting War Stomp - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WarStomp_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 7744 && CanCastCheck(WillOfTheForsaken_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Will of the Forsaken - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WillOfTheForsaken_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 260364 && CanCastCheck(ArcanePulse_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Pulse - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ArcanePulse_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 255654 && CanCastCheck(BullRush_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bull Rush - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BullRush_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 312411 && CanCastCheck(BagOfTricks_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bag of Tricks - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BagOfTricks_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 20572 || SpellID1 == 33702 || SpellID1 == 33697) && CanCastCheck(BloodFury_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blood Fury - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BloodFury_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 26297 && CanCastCheck(Berserking_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Berserking - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Berserking_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 274738 && CanCastCheck(AncestralCall_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ancestral Call - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AncestralCall_SpellName(Language));
                        return true;
                    }

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

                    #region Covenants
                    ///Covenants
                    if (SpellID1 == 312321 && CanCastCheck(ScouringTithe_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Scouring Tithe - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ScouringTithe_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 321792 && CanCastCheck(ImpendingCatastrophe_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Impending Catastrophe - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ImpendingCatastrophe_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 325640 && CanCastCheck(SoulRot_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Soul Rot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SoulRot_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 325289 && CanCastCheck(DecimatingBolt_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Decimating Bolt - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DecimatingBolt_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - No GCD
                    ///Class Spells
                    //Target - No GCD
                    if (SpellID1 == 19647 && CanCastCheck(SpellLock_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spell Lock - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SpellLock_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 386244 && CanCastCheck(SummonSoulkeeper_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Soulkeeper - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SummonSoulkeeper_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    //Target - GCD

                    if (SpellID1 == 172 && CanCastCheck(Corruption_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Corruption - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Corruption_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 5782 && CanCastCheck(Fear_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fear - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Fear_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 334275 && CanCastCheck(CurseOfExhaustion_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Curse of Exhaustion - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(CurseOfExhaustion_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 755 && CanCastCheck(HealthFunnel_SpellName(Language), "pet", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Health Funnel - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(HealthFunnel_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 702 && CanCastCheck(CurseOfWeakness_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Curse of Weakness - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(CurseOfWeakness_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 686 && CanCastCheck(ShadowBolt_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Curse of Weakness - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ShadowBolt_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 234153 && CanCastCheck(DrainLife_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Drain Life - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DrainLife_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 1714 && CanCastCheck(CurseOfTongues_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Curse of Tongues - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(CurseOfTongues_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 710 && CanCastCheck(Banish_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Banish - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Banish_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 19505 && CanCastCheck(DevourMagic_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Devour Magic - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DevourMagic_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 6358 && CanCastCheck(Seduction_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Seduction - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Seduction_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD

                    if (SpellID1 == 333889 && CanCastCheck(FelDomination_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fel Domination - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FelDomination_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 104773 && CanCastCheck(UnendingResolve_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Unending Resolve - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(UnendingResolve_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 48018 && CanCastCheck(DemonicCircle_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Demonic Circle - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DemonicCircle_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 48020 && CanCastCheck(DemonicCircle_Teleport_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Demonic Circle: Teleport - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DemonicCircle_Teleport_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 111771 && CanCastCheck(DemonicGateway_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Demonic Gateway - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DemonicGateway_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 30283 && CanCastCheck(Shadowfury_SpellName(Language), "player", false, true))
                    {
                        switch (ShadowfuryCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast(Shadowfury_SpellName(Language));
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("ShadowfuryP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("ShadowfuryC");
                                return true;
                        }
                    }

                    if (SpellID1 == 89808 && CanCastCheck(SingeMagic_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Singe Magic - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SingeMagic_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 386344 && CanCastCheck(InquisitorsGaze_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Inquisitor's Gaze - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(InquisitorsGaze_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 385899 && CanCastCheck(Soulburn_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Soulburn - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Soulburn_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 328774 && CanCastCheck(AmplifyCurse_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Amplify Curse - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AmplifyCurse_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Destruction Spells - Player GCD
                    if (SpellID1 == 196447 && CanCastCheck(ChannelDemonfire_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Channel Demonfire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ChannelDemonfire_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 387976 && CanCastCheck(DimensionalRift_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Dimensional Rift - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DimensionalRift_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 1122 && CanCastCheck(SummonInfernal_SpellName(Language), "player", false, true))
                    {
                        switch (SummonInfernalCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast(SummonInfernal_SpellName(Language));
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("SummonInfernalP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("SummonInfernalC");
                                return true;
                        }
                    }

                    if ((SpellID1 == 5740 || SpellID1 == 47723) && CanCastCheck(RainOfFire_SpellName(Language), "player", false, true) && ((Aimsharp.CustomFunction("RainofFireMouseover") == 1 || !InstanceIDList.Contains(Aimsharp.GetMapID()) && Aimsharp.CustomFunction("RainofFireMouseoverNC") == 1) || GetCheckBox("Always Cast Rain of Fire @ Cursor during Rotation") || Aimsharp.IsCustomCodeOn("RainofFireCursor")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("RainofFireC");
                        return true;
                    }
                    else if ((SpellID1 == 5740 || SpellID1 == 47723) && CanCastCheck(RainOfFire_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RainOfFire_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 152108 && CanCastCheck(Cataclysm_SpellName(Language), "player", false, true) && ((Aimsharp.CustomFunction("RainofFireMouseover") == 1 || !InstanceIDList.Contains(Aimsharp.GetMapID()) && Aimsharp.CustomFunction("RainofFireMouseoverNC") == 1) || GetCheckBox("Always Cast Cataclysm @ Cursor during Rotation") || Aimsharp.IsCustomCodeOn("CataclysmCursor")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("CataclysmC");
                        return true;
                    }
                    else if (SpellID1 == 152108 && CanCastCheck(Cataclysm_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Cataclysm_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 108416 && CanCastCheck(DarkPact_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Dark Pact - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DarkPact_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 5484 && CanCastCheck(HowlOfTerror_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Howl of Terror - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(HowlOfTerror_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 108503 && CanCastCheck(GrimoireOfSacrifice_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Grimoire of Sacrifice - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(GrimoireOfSacrifice_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 113858 && CanCastCheck(DarkSoul_Instability_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Dark Soul: Instability - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DarkSoul_Instability_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Destruction Spells - Target GCD
                    if (SpellID1 == 17877 && CanCastCheck(Shadowburn_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowburn - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Shadowburn_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 6353 && CanCastCheck(SoulFire_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Soul Fire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SoulFire_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 29722 && CanCastCheck(Incinerate_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Incinerate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Incinerate_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 348 && CanCastCheck(Immolate_SpellName(Language), "target", true, true) && Aimsharp.CustomFunction("HekiliCycle") == 0)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Immolate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Immolate_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 348 && CanCastCheck(Immolate_SpellName(Language), "mouseover", true, true) && Aimsharp.CustomFunction("HekiliCycle") == 1 && (Aimsharp.CustomFunction("RainofFireMouseover") == 1 || !InstanceIDList.Contains(Aimsharp.GetMapID()) && Aimsharp.CustomFunction("RainofFireMouseoverNC") == 1))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Immolate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("ImmolateMO");
                        return true;
                    }
                    else if (SpellID1 == 348 && CanCastCheck(Immolate_SpellName(Language), "target", true, true) && Aimsharp.CustomFunction("HekiliCycle") == 1 && Aimsharp.CustomFunction("RainofFireMouseover") == 0)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Immolate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Immolate_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 80240 && CanCastCheck(Havoc_SpellName(Language), "target", true, true) && Aimsharp.CustomFunction("HekiliCycle") == 0)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Havoc - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Havoc_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 80240 && CanCastCheck(Havoc_SpellName(Language), "mouseover", true, true) && Aimsharp.CustomFunction("HekiliCycle") == 1 && (Aimsharp.CustomFunction("RainofFireMouseover") == 1 || !InstanceIDList.Contains(Aimsharp.GetMapID()) && Aimsharp.CustomFunction("RainofFireMouseoverNC") == 1))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Havoc - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("HavocMO");
                        return true;
                    }
                    else if (SpellID1 == 80240 && CanCastCheck(Havoc_SpellName(Language), "target", true, true) && Aimsharp.CustomFunction("HekiliCycle") == 1 && Aimsharp.CustomFunction("RainofFireMouseover") == 0)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Havoc - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Havoc_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 17962 || SpellID1 == 290644 || SpellID1 == 265931 || SpellID1 == 205184 || SpellID1 == 25736) && CanCastCheck(Conflagrate_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Conflagrate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Conflagrate_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 116858 && CanCastCheck(ChaosBolt_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Chaos Bolt - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ChaosBolt_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 6789 && CanCastCheck(MortalCoil_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mortal Coil - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(MortalCoil_SpellName(Language));
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
            if (Aimsharp.CastingID("player") == 710 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Banish"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Banish Queue", Color.Purple);
                }
                Aimsharp.Cast("BanishOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 5782 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Fear"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fear Queue", Color.Purple);
                }
                Aimsharp.Cast("FearOff");
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

            if (Aimsharp.IsCustomCodeOn("Shadowfury") && Aimsharp.SpellCooldown(Shadowfury_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("RainofFire") && Aimsharp.SpellCooldown(RainOfFire_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            bool Banish = Aimsharp.IsCustomCodeOn("Banish");
            if ((Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Banish)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Banish Queue", Color.Purple);
                }
                Aimsharp.Cast("BanishOff");
                return true;
            }

            if (Banish && CanCastCheck(Banish_SpellName(Language), "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Banish - Queue", Color.Purple);
                }
                Aimsharp.Cast("BanishMO");
                return true;
            }

            bool Fear = Aimsharp.IsCustomCodeOn("Fear");
            if ((Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Fear)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Fear Queue", Color.Purple);
                }
                Aimsharp.Cast("FearOff");
                return true;
            }

            if (Fear && CanCastCheck(Fear_SpellName(Language), "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fear - Queue", Color.Purple);
                }
                Aimsharp.Cast("FearMO");
                return true;
            }

            bool MortalCoil = Aimsharp.IsCustomCodeOn("MortalCoil");
            if (Aimsharp.SpellCooldown(Shadowfury_SpellName(Language)) - Aimsharp.GCD() > 2000 && MortalCoil)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mortal Coil Queue", Color.Purple);
                }
                Aimsharp.Cast("MortalCoilOff");
                return true;
            }

            if (MortalCoil && CanCastCheck(MortalCoil_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mortal Coil - Queue", Color.Purple);
                }
                Aimsharp.Cast(MortalCoil_SpellName(Language));
                return true;
            }

            bool HowlofTerror = Aimsharp.IsCustomCodeOn("HowlofTerror");
            if (Aimsharp.SpellCooldown(Shadowfury_SpellName(Language)) - Aimsharp.GCD() > 2000 && HowlofTerror)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Howl of Terror Queue", Color.Purple);
                }
                Aimsharp.Cast("HowlofTerrorOff");
                return true;
            }

            if (HowlofTerror && CanCastCheck(HowlOfTerror_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Howl of Terror - Queue", Color.Purple);
                }
                Aimsharp.Cast(HowlOfTerror_SpellName(Language));
                return true;
            }
            //Queue Shadowfury
            string ShadowfuryCast = GetDropDown("Shadowfury Cast:");
            bool Shadowfury = Aimsharp.IsCustomCodeOn("Shadowfury");
            if ((Aimsharp.SpellCooldown(Shadowfury_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && Shadowfury)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shadowfury Queue", Color.Purple);
                }
                Aimsharp.Cast("ShadowfuryOff");
                return true;
            }

            if (Shadowfury && CanCastCheck(Shadowfury_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (ShadowfuryCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Shadowfury_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowfuryP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowfury - " + ShadowfuryCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowfuryC");
                        return true;
                }
            }

            //Queue Rain of Fire
            string RainofFireCast = GetDropDown("Rain of Fire Cast:");
            bool RainofFire = Aimsharp.IsCustomCodeOn("RainofFire");
            if ((Aimsharp.SpellCooldown(RainOfFire_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving || Aimsharp.LastCast() == RainOfFire_SpellName(Language)) && RainofFire)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Rain of Fire Queue", Color.Purple);
                }
                Aimsharp.Cast("RainofFireOff");
                return true;
            }

            if (RainofFire && CanCastCheck(RainOfFire_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (RainofFireCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire - " + RainofFireCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(RainOfFire_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire - " + RainofFireCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RainofFireP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rain of Fire - " + RainofFireCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RainofFireC");
                        return true;
                }
            }

            //Queue Summon Infernal
            string SummonInfernalCast = GetDropDown("Summon Infernal Cast:");
            bool SummonInfernal = Aimsharp.IsCustomCodeOn("SummonInfernal");
            if ((Aimsharp.SpellCooldown(SummonInfernal_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && SummonInfernal)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Summon Infernal Queue", Color.Purple);
                }
                Aimsharp.Cast("SummonInfernalOff");
                return true;
            }

            if (SummonInfernal && CanCastCheck(SummonInfernal_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (SummonInfernalCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SummonInfernal_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SummonInfernalP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Infernal - " + SummonInfernalCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SummonInfernalC");
                        return true;
                }
            }

            //Queue Cataclysm
            string CataclysmCast = GetDropDown("Cataclysm Cast:");
            bool Cataclysm = Aimsharp.IsCustomCodeOn("Cataclysm");
            if ((Aimsharp.SpellCooldown(Cataclysm_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && Cataclysm)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Cataclysm Queue", Color.Purple);
                }
                Aimsharp.Cast("CataclysmOff");
                return true;
            }

            if (Cataclysm && CanCastCheck(Cataclysm_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (CataclysmCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm - " + CataclysmCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Cataclysm_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm - " + CataclysmCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CataclysmP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cataclysm - " + CataclysmCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("CataclysmC");
                        return true;
                }
            }
            #endregion

            #region Out of Combat Spells
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat && !Aimsharp.HasDebuff(Banish_SpellName(Language), "target", true) && !Aimsharp.HasDebuff(Fear_SpellName(Language), "target", true) && !Banish && !Fear)
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