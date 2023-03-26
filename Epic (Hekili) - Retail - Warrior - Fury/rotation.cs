using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicWarriorFuryHekili : Rotation
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

        ///<summary>spell=325886</summary>
        private static string AncientAftershock_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ancient Aftershock";
                case "Deutsch": return "Nachbeben der Ahnen";
                case "Español": return "Réplica ancestral";
                case "Français": return "Réplique des anciens";
                case "Italiano": return "Scossa d'Assestamento Antica";
                case "Português Brasileiro": return "Tremor Secundário Ancestral";
                case "Русский": return "Повторный толчок Древних";
                case "한국어": return "고대의 여진";
                case "简体中文": return "上古余震";
                default: return "Ancient Aftershock";
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

        ///<summary>spell=163249</summary>
        private static string Avatar_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Avatar";
                case "Deutsch": return "Avatar";
                case "Español": return "Avatar";
                case "Français": return "Avatar";
                case "Italiano": return "Avatar";
                case "Português Brasileiro": return "Avatar";
                case "Русский": return "Аватара";
                case "한국어": return "투신";
                case "简体中文": return "天神下凡";
                default: return "Avatar";
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

        ///<summary>spell=6673</summary>
        private static string BattleShout_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Battle Shout";
                case "Deutsch": return "Schlachtruf";
                case "Español": return "Grito de batalla";
                case "Français": return "Cri de guerre";
                case "Italiano": return "Urlo di Battaglia";
                case "Português Brasileiro": return "Brado de Batalha";
                case "Русский": return "Боевой крик";
                case "한국어": return "전투의 외침";
                case "简体中文": return "战斗怒吼";
                default: return "Battle Shout";
            }
        }

        ///<summary>spell=18499</summary>
        private static string BerserkerRage_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Berserker Rage";
                case "Deutsch": return "Berserkerwut";
                case "Español": return "Ira rabiosa";
                case "Français": return "Rage de berserker";
                case "Italiano": return "Furia del Berserker";
                case "Português Brasileiro": return "Raiva Incontrolada";
                case "Русский": return "Ярость берсерка";
                case "한국어": return "광전사의 격노";
                case "简体中文": return "狂暴之怒";
                default: return "Berserker Rage";
            }
        }

        ///<summary>spell=386196</summary>
        private static string BerserkerStance_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Berserker Stance";
                case "Deutsch": return "Berserkerhaltung";
                case "Español": return "Actitud rabiosa";
                case "Français": return "Posture berserker";
                case "Italiano": return "Postura da Berserker";
                case "Português Brasileiro": return "Postura de Berserker";
                case "Русский": return "Стойка берсерка";
                case "한국어": return "광폭 태세";
                case "简体中文": return "狂暴姿态";
                default: return "Berserker Stance";
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

        ///<summary>spell=383762</summary>
        private static string BitterImmunity_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bitter Immunity";
                case "Deutsch": return "Bittere Immunität";
                case "Español": return "Inmunidad amarga";
                case "Français": return "Immunité amère";
                case "Italiano": return "Immunità Amara";
                case "Português Brasileiro": return "Imunidade Mordaz";
                case "Русский": return "Горестная невосприимчивость";
                case "한국어": return "사기적인 면역";
                case "简体中文": return "苦痛免疫";
                default: return "Bitter Immunity";
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

        ///<summary>spell=335096</summary>
        private static string Bloodbath_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bloodbath";
                case "Deutsch": return "Blutbad";
                case "Español": return "Baño de sangre";
                case "Français": return "Bain de sang";
                case "Italiano": return "Bagno di Sangue";
                case "Português Brasileiro": return "Banho de Sangue";
                case "Русский": return "Кровавая баня";
                case "한국어": return "피범벅";
                case "简体中文": return "浴血奋战";
                default: return "Bloodbath";
            }
        }

        ///<summary>spell=23881</summary>
        private static string Bloodthirst_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bloodthirst";
                case "Deutsch": return "Blutdurst";
                case "Español": return "Sed de sangre";
                case "Français": return "Sanguinaire";
                case "Italiano": return "Sete di Sangue";
                case "Português Brasileiro": return "Sede de Sangue";
                case "Русский": return "Кровожадность";
                case "한국어": return "피의 갈증";
                case "简体中文": return "嗜血";
                default: return "Bloodthirst";
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

        ///<summary>spell=1161</summary>
        private static string ChallengingShout_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Challenging Shout";
                case "Deutsch": return "Herausforderungsruf";
                case "Español": return "Grito desafiante";
                case "Français": return "Cri de défi";
                case "Italiano": return "Urlo di Sfida";
                case "Português Brasileiro": return "Brado Desafiador";
                case "Русский": return "Вызывающий крик";
                case "한국어": return "도전의 외침";
                case "简体中文": return "挑战怒吼";
                default: return "Challenging Shout";
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
        ///<summary>spell=324143</summary>
        private static string ConquerorsBanner_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Conqueror's Banner";
                case "Deutsch": return "Banner des Eroberers";
                case "Español": return "Estandarte de conquistador";
                case "Français": return "Bannière du conquérant";
                case "Italiano": return "Stendardo del Conquistatore";
                case "Português Brasileiro": return "Estandarte do Conquistador";
                case "Русский": return "Знамя завоевателя";
                case "한국어": return "정복자의 깃발";
                case "简体中文": return "征服者战旗";
                default: return "Conqueror's Banner";
            }
        }

        ///<summary>spell=335097</summary>
        private static string CrushingBlow_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Crushing Blow";
                case "Deutsch": return "Schmetterschlag";
                case "Español": return "Golpe aplastante";
                case "Français": return "Coup écrasant";
                case "Italiano": return "Colpo Devastante";
                case "Português Brasileiro": return "Golpe Triturante";
                case "Русский": return "Сокрушающий удар";
                case "한국어": return "분쇄의 타격";
                case "简体中文": return "碎甲猛击";
                default: return "Crushing Blow";
            }
        }

        ///<summary>spell=41101</summary>
        private static string DefensiveStance_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Defensive Stance";
                case "Deutsch": return "Verteidigungshaltung";
                case "Español": return "Actitud defensiva";
                case "Français": return "Posture défensive";
                case "Italiano": return "Postura da Difesa";
                case "Português Brasileiro": return "Postura de Defesa";
                case "Русский": return "Оборонительная стойка";
                case "한국어": return "방어 태세";
                case "简体中文": return "防御姿态";
                default: return "Defensive Stance";
            }
        }

        ///<summary>spell=184364</summary>
        private static string EnragedRegeneration_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Enraged Regeneration";
                case "Deutsch": return "Wütende Regeneration";
                case "Español": return "Regeneración enfurecida";
                case "Français": return "Régénération enragée";
                case "Italiano": return "Rigenerazione Furente";
                case "Português Brasileiro": return "Regeneração Enfurecida";
                case "Русский": return "Безудержное восстановление";
                case "한국어": return "격노의 재생력";
                case "简体中文": return "狂怒回复";
                default: return "Enraged Regeneration";
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

        ///<summary>spell=163201</summary>
        private static string Execute_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Execute";
                case "Deutsch": return "Hinrichten";
                case "Español": return "Ejecutar";
                case "Français": return "Exécution";
                case "Italiano": return "Esecuzione";
                case "Português Brasileiro": return "Executar";
                case "Русский": return "Казнь";
                case "한국어": return "마무리 일격";
                case "简体中文": return "斩杀";
                default: return "Execute";
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

        ///<summary>spell=6544</summary>
        private static string HeroicLeap_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Heroic Leap";
                case "Deutsch": return "Heldenhafter Sprung";
                case "Español": return "Salto heroico";
                case "Français": return "Bond héroïque";
                case "Italiano": return "Balzo Eroico";
                case "Português Brasileiro": return "Salto Heroico";
                case "Русский": return "Героический прыжок";
                case "한국어": return "영웅의 도약";
                case "简体中文": return "英勇飞跃";
                default: return "Heroic Leap";
            }
        }

        ///<summary>spell=57755</summary>
        private static string HeroicThrow_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Heroic Throw";
                case "Deutsch": return "Heldenhafter Wurf";
                case "Español": return "Lanzamiento heroico";
                case "Français": return "Lancer héroïque";
                case "Italiano": return "Lancio Eroico";
                case "Português Brasileiro": return "Arremesso Heroico";
                case "Русский": return "Героический бросок";
                case "한국어": return "영웅의 투척";
                case "简体中文": return "英勇投掷";
                default: return "Heroic Throw";
            }
        }

        ///<summary>spell=190456</summary>
        private static string IgnorePain_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ignore Pain";
                case "Deutsch": return "Zähne zusammenbeißen";
                case "Español": return "Ignorar dolor";
                case "Français": return "Dur au mal";
                case "Italiano": return "Insensibilità";
                case "Português Brasileiro": return "Ignorar Dor";
                case "Русский": return "Стойкость к боли";
                case "한국어": return "고통 감내";
                case "简体中文": return "无视苦痛";
                default: return "Ignore Pain";
            }
        }

        ///<summary>spell=202168</summary>
        private static string ImpendingVictory_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Impending Victory";
                case "Deutsch": return "Bevorstehender Sieg";
                case "Español": return "Victoria inminente";
                case "Français": return "Victoire imminente";
                case "Italiano": return "Vittoria Imminente";
                case "Português Brasileiro": return "Vitória Iminente";
                case "Русский": return "Верная победа";
                case "한국어": return "예견된 승리";
                case "简体中文": return "胜利在望";
                default: return "Impending Victory";
            }
        }

        ///<summary>spell=3411</summary>
        private static string Intervene_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Intervene";
                case "Deutsch": return "Einschreiten";
                case "Español": return "Intervenir";
                case "Français": return "Intervention";
                case "Italiano": return "Intervento";
                case "Português Brasileiro": return "Comprar Briga";
                case "Русский": return "Вмешательство";
                case "한국어": return "가로막기";
                case "简体中文": return "援护";
                default: return "Intervene";
            }
        }

        ///<summary>spell=5246</summary>
        private static string IntimidatingShout_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Intimidating Shout";
                case "Deutsch": return "Drohruf";
                case "Español": return "Grito intimidador";
                case "Français": return "Cri d’intimidation";
                case "Italiano": return "Urlo Intimidatorio";
                case "Português Brasileiro": return "Brado Intimidador";
                case "Русский": return "Устрашающий крик";
                case "한국어": return "위협의 외침";
                case "简体中文": return "破胆怒吼";
                default: return "Intimidating Shout";
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

        ///<summary>spell=385059</summary>
        private static string OdynsFury_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Odyn's Fury";
                case "Deutsch": return "Odyns Zorn";
                case "Español": return "Furia de Odyn";
                case "Français": return "Fureur d’Odyn";
                case "Italiano": return "Furia di Odyn";
                case "Português Brasileiro": return "Fúria de Odyn";
                case "Русский": return "Ярость Одина";
                case "한국어": return "오딘의 격노";
                case "简体中文": return "奥丁之怒";
                default: return "Odyn's Fury";
            }
        }

        ///<summary>spell=315720</summary>
        private static string Onslaught_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Onslaught";
                case "Deutsch": return "Ansturm";
                case "Español": return "Irrupción";
                case "Français": return "Assaut";
                case "Italiano": return "Massacro";
                case "Português Brasileiro": return "Ofensiva";
                case "Русский": return "Натиск";
                case "한국어": return "맹공";
                case "简体中文": return "强攻";
                default: return "Onslaught";
            }
        }

        ///<summary>spell=12323</summary>
        private static string PiercingHowl_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Piercing Howl";
                case "Deutsch": return "Durchdringendes Heulen";
                case "Español": return "Aullido perforador";
                case "Français": return "Hurlement perçant";
                case "Italiano": return "Urlo Penetrante";
                case "Português Brasileiro": return "Uivo Perfurante";
                case "Русский": return "Пронзительный вой";
                case "한국어": return "날카로운 고함";
                case "简体中文": return "刺耳怒吼";
                default: return "Piercing Howl";
            }
        }

        ///<summary>spell=6552</summary>
        private static string Pummel_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Pummel";
                case "Deutsch": return "Zuschlagen";
                case "Español": return "Zurrar";
                case "Français": return "Volée de coups";
                case "Italiano": return "Pugno Diversivo";
                case "Português Brasileiro": return "Murro";
                case "Русский": return "Зуботычина";
                case "한국어": return "들이치기";
                case "简体中文": return "拳击";
                default: return "Pummel";
            }
        }

        ///<summary>spell=85288</summary>
        private static string RagingBlow_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Raging Blow";
                case "Deutsch": return "Wütender Schlag";
                case "Español": return "Arremetida enfurecida";
                case "Français": return "Coup déchaîné";
                case "Italiano": return "Colpo Furente";
                case "Português Brasileiro": return "Golpe Furioso";
                case "Русский": return "Яростный выпад";
                case "한국어": return "분노의 강타";
                case "简体中文": return "怒击";
                default: return "Raging Blow";
            }
        }

        ///<summary>spell=97462</summary>
        private static string RallyingCry_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rallying Cry";
                case "Deutsch": return "Anspornender Schrei";
                case "Español": return "Berrido de convocación";
                case "Français": return "Cri de ralliement";
                case "Italiano": return "Chiamata a Raccolta";
                case "Português Brasileiro": return "Brado de Convocação";
                case "Русский": return "Ободряющий клич";
                case "한국어": return "재집결의 함성";
                case "简体中文": return "集结呐喊";
                default: return "Rallying Cry";
            }
        }

        ///<summary>spell=184367</summary>
        private static string Rampage_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rampage";
                case "Deutsch": return "Toben";
                case "Español": return "Desenfreno";
                case "Français": return "Saccager";
                case "Italiano": return "Scatto d'Ira";
                case "Português Brasileiro": return "Alvoroço";
                case "Русский": return "Буйство";
                case "한국어": return "광란";
                case "简体中文": return "暴怒";
                default: return "Rampage";
            }
        }

        ///<summary>spell=228920</summary>
        private static string Ravager_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ravager";
                case "Deutsch": return "Verheerer";
                case "Español": return "Devastador";
                case "Français": return "Ravageur";
                case "Italiano": return "Impeto Devastatore";
                case "Português Brasileiro": return "Assolador";
                case "Русский": return "Опустошитель";
                case "한국어": return "쇠날발톱";
                case "简体中文": return "破坏者";
                default: return "Ravager";
            }
        }

        ///<summary>spell=1719</summary>
        private static string Recklessness_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Recklessness";
                case "Deutsch": return "Tollkühnheit";
                case "Español": return "Temeridad";
                case "Français": return "Témérité";
                case "Italiano": return "Avventatezza";
                case "Português Brasileiro": return "Temeridade";
                case "Русский": return "Безрассудство";
                case "한국어": return "무모한 희생";
                case "简体中文": return "鲁莽";
                default: return "Recklessness";
            }
        }

        ///<summary>spell=772</summary>
        private static string Rend_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rend";
                case "Deutsch": return "Verwunden";
                case "Español": return "Desgarrar";
                case "Français": return "Pourfendre";
                case "Italiano": return "Squartamento";
                case "Português Brasileiro": return "Dilacerar";
                case "Русский": return "Кровопускание";
                case "한국어": return "분쇄";
                case "简体中文": return "撕裂";
                default: return "Rend";
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

        ///<summary>spell=64382</summary>
        private static string ShatteringThrow_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shattering Throw";
                case "Deutsch": return "Zerschmetternder Wurf";
                case "Español": return "Lanzamiento destrozador";
                case "Français": return "Lancer fracassant";
                case "Italiano": return "Lancio Frantumante";
                case "Português Brasileiro": return "Arremesso Estilhaçante";
                case "Русский": return "Сокрушительный бросок";
                case "한국어": return "분쇄의 투척";
                case "简体中文": return "碎裂投掷";
                default: return "Shattering Throw";
            }
        }

        ///<summary>spell=46968</summary>
        private static string Shockwave_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shockwave";
                case "Deutsch": return "Schockwelle";
                case "Español": return "Ola de choque";
                case "Français": return "Onde de choc";
                case "Italiano": return "Onda d'Urto";
                case "Português Brasileiro": return "Onda de Choque";
                case "Русский": return "Ударная волна";
                case "한국어": return "충격파";
                case "简体中文": return "震荡波";
                default: return "Shockwave";
            }
        }

        ///<summary>spell=1464</summary>
        private static string Slam_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Slam";
                case "Deutsch": return "Zerschmettern";
                case "Español": return "Embate";
                case "Français": return "Heurtoir";
                case "Italiano": return "Contusione";
                case "Português Brasileiro": return "Batida";
                case "Русский": return "Мощный удар";
                case "한국어": return "격돌";
                case "简体中文": return "猛击";
                default: return "Slam";
            }
        }

        ///<summary>spell=307865</summary>
        private static string SpearOfBastion_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Spear of Bastion";
                case "Deutsch": return "Speer der Bastion";
                case "Español": return "Lanza de Bastión";
                case "Français": return "Lance du Bastion";
                case "Italiano": return "Lancia del Bastione";
                case "Português Brasileiro": return "Lança do Bastião";
                case "Русский": return "Копье Бастиона";
                case "한국어": return "보루의 창";
                case "简体中文": return "晋升堡垒之矛";
                default: return "Spear of Bastion";
            }
        }

        ///<summary>spell=23920</summary>
        private static string SpellReflection_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Spell Reflection";
                case "Deutsch": return "Zauberreflexion";
                case "Español": return "Reflejo de hechizos";
                case "Français": return "Renvoi de sort";
                case "Italiano": return "Rifletti Incantesimo";
                case "Português Brasileiro": return "Reflexão de Feitiço";
                case "Русский": return "Отражение заклинаний";
                case "한국어": return "주문 반사";
                case "简体中文": return "法术反射";
                default: return "Spell Reflection";
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

        ///<summary>spell=107570</summary>
        private static string StormBolt_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Storm Bolt";
                case "Deutsch": return "Sturmblitz";
                case "Español": return "Descarga tormentosa";
                case "Français": return "Éclair de tempête";
                case "Italiano": return "Dardo della Tempesta";
                case "Português Brasileiro": return "Seta Tempestuosa";
                case "Русский": return "Удар громовержца";
                case "한국어": return "폭풍망치";
                case "简体中文": return "风暴之锤";
                default: return "Storm Bolt";
            }
        }

        ///<summary>spell=6343</summary>
        private static string ThunderClap_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Thunder Clap";
                case "Deutsch": return "Donnerknall";
                case "Español": return "Atronar";
                case "Français": return "Coup de tonnerre";
                case "Italiano": return "Schianto del Tuono";
                case "Português Brasileiro": return "Trovoada";
                case "Русский": return "Удар грома";
                case "한국어": return "천둥벼락";
                case "简体中文": return "雷霆一击";
                default: return "Thunder Clap";
            }
        }

        ///<summary>spell=384318</summary>
        private static string ThunderousRoar_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Thunderous Roar";
                case "Deutsch": return "Donnerndes Gebrüll";
                case "Español": return "Rugido de trueno";
                case "Français": return "Rugissement vibrant";
                case "Italiano": return "Rombo di Tuono";
                case "Português Brasileiro": return "Rugido Trovejante";
                case "Русский": return "Громогласный рык";
                case "한국어": return "천둥의 포효";
                case "简体中文": return "雷鸣之吼";
                default: return "Thunderous Roar";
            }
        }

        ///<summary>spell=34428</summary>
        private static string VictoryRush_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Victory Rush";
                case "Deutsch": return "Siegesrausch";
                case "Español": return "Ataque de la victoria";
                case "Français": return "Ivresse de la victoire";
                case "Italiano": return "Frenesia di Vittoria";
                case "Português Brasileiro": return "Ímpeto da Vitória";
                case "Русский": return "Победный раж";
                case "한국어": return "연전연승";
                case "简体中文": return "乘胜追击";
                default: return "Victory Rush";
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

        ///<summary>spell=1680</summary>
        private static string Whirlwind_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Whirlwind";
                case "Deutsch": return "Wirbelwind";
                case "Español": return "Torbellino";
                case "Français": return "Tourbillon";
                case "Italiano": return "Turbine";
                case "Português Brasileiro": return "Redemoinho";
                case "Русский": return "Вихрь";
                case "한국어": return "소용돌이";
                case "简体中文": return "旋风斩";
                default: return "Whirlwind";
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

        ///<summary>spell=384110</summary>
        private static string WreckingThrow_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Wrecking Throw";
                case "Deutsch": return "Abrisswurf";
                case "Español": return "Lanzamiento demoledor";
                case "Français": return "Lancer destructeur";
                case "Italiano": return "Lancio Demolitore";
                case "Português Brasileiro": return "Arremesso Avassalador";
                case "Русский": return "Сокрушительный бросок";
                case "한국어": return "격파의 투척";
                case "简体中文": return "破裂投掷";
                default: return "Wrecking Throw";
            }
        }
        #endregion

        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle", "StormBolt", "SpearOfBastion", "QueueRavager", "HeroicLeap" };
        private List<string> m_DebuffsList;
        private List<string> m_BuffsList;
        private List<string> m_ItemsList;
        private List<string> m_SpellBook_General;
        private List<string> m_RaceList = new List<string> { "human", "dwarf", "nightelf", "gnome", "draenei", "pandaren", "orc", "scourge", "tauren", "troll", "bloodelf", "goblin", "worgen", "voidelf", "lightforgeddraenei", "highmountaintauren", "nightborne", "zandalaritroll", "magharorc", "kultiran", "darkirondwarf", "vulpera", "mechagnome" };
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
                if (Aimsharp.CustomFunction("HekiliID1") == HekiliID && Aimsharp.CanCast(SpellName, target))
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
                if (Aimsharp.CustomFunction("HekiliID1") == HekiliID && Aimsharp.CanCast(SpellName, target))
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


            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + Aimsharp.Latency);

            //Queues
            Macros.Add("SpearOfBastionOff", "/" + FiveLetters + " SpearOfBastion");
            Macros.Add("StormBoltOff", "/" + FiveLetters + " StormBolt");
            Macros.Add("QueueRavagerOff", "/" + FiveLetters + " QueueRavager");
            Macros.Add("HeroicLeapOff", "/" + FiveLetters + " HeroicLeap");
            Macros.Add("AntiMagicZoneOff", "/" + FiveLetters + " AntiMagicZone");
            Macros.Add("BlindingSleetOff", "/" + FiveLetters + " BlindingSleet");

            Macros.Add("SpearOfBastionP", "/cast [@player] " + SpearOfBastion_SpellName(Language));
            Macros.Add("SpearOfBastionC", "/cast [@cursor] " + SpearOfBastion_SpellName(Language));
            Macros.Add("RavagerP", "/cast [@player] " + Ravager_SpellName(Language));
            Macros.Add("RavagerC", "/cast [@cursor] " + Ravager_SpellName(Language));
            Macros.Add("HeroicLeapC", "/cast [@cursor] " + HeroicLeap_SpellName(Language));
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
            Settings.Add(new Setting("Battle Cry Out of Combat:", true));
            Settings.Add(new Setting("Auto Enraged Regeneration @ HP%", 0, 100, 30));
            Settings.Add(new Setting("Auto Ignore Pain @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Auto Victory Rush @ HP%", 0, 100, 70));
            Settings.Add(new Setting("Auto Bitter Immunity @ HP%", 0, 100, 35));
            Settings.Add(new Setting("Ravager Cast:", m_CastingList, "Player"));
            Settings.Add(new Setting("Spear of Bastion Cast:", m_CastingList, "Player"));
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

            Aimsharp.PrintMessage("Epic PVE - Warrior Fury", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/warrior/Fury/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " StormBolt - Casts Storm Bolt @ Target next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " HeroicLeap - Casts Heroic Leap @ Cursor next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " QueueRavager - Casts Ravager @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " SpearOfBastion - Casts Spear of Bastion @ next GCD", Color.Yellow);
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
            m_BuffsList = new List<string> { BattleShout_SpellName(Language), };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language), };
            m_SpellBook_General = new List<string> {
                AncientAftershock_SpellName(Language),
                ConquerorsBanner_SpellName(Language),

                Avatar_SpellName(Language),
                BattleShout_SpellName(Language),
                BerserkerRage_SpellName(Language),
                BerserkerStance_SpellName(Language),
                BitterImmunity_SpellName(Language),
                Ravager_SpellName(Language),
                Bloodbath_SpellName(Language),
                Bloodthirst_SpellName(Language),
                ChallengingShout_SpellName(Language),
                Charge_SpellName(Language),
                CrushingBlow_SpellName(Language),
                DefensiveStance_SpellName(Language),
                EnragedRegeneration_SpellName(Language),
                Execute_SpellName(Language),
                HeroicLeap_SpellName(Language),
                HeroicThrow_SpellName(Language),
                IgnorePain_SpellName(Language),
                ImpendingVictory_SpellName(Language),
                Intervene_SpellName(Language),
                IntimidatingShout_SpellName(Language),
                OdynsFury_SpellName(Language),
                Onslaught_SpellName(Language),
                PiercingHowl_SpellName(Language),
                Pummel_SpellName(Language),
                RagingBlow_SpellName(Language),
                RallyingCry_SpellName(Language),
                Rampage_SpellName(Language),
                Recklessness_SpellName(Language),
                ShatteringThrow_SpellName(Language),
                Slam_SpellName(Language),
                SpearOfBastion_SpellName(Language),
                SpellReflection_SpellName(Language),
                StormBolt_SpellName(Language),
                ThunderousRoar_SpellName(Language),
                VictoryRush_SpellName(Language),
                Whirlwind_SpellName(Language),
                WreckingThrow_SpellName(Language),
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

            if (Aimsharp.IsCustomCodeOn("SpearOfBastion") && Aimsharp.SpellCooldown(SpearOfBastion_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("HeroicLeap") && Aimsharp.SpellCooldown(HeroicLeap_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("QueueRavager") && Aimsharp.SpellCooldown(Ravager_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                if (Aimsharp.CanCast(Pummel_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Pummel_SpellName(Language), true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast(Pummel_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Pummel_SpellName(Language), true);
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

            //Auto Enraged Regeneration
            if (Aimsharp.CanCast(EnragedRegeneration_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Enraged Regeneration @ HP%"))
                {
                    Aimsharp.Cast(EnragedRegeneration_SpellName(Language));
                    return true;
                }
            }

            //Auto Ignore Pain
            if (Aimsharp.CanCast(IgnorePain_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Ignore Pain @ HP%"))
                {
                    Aimsharp.Cast(IgnorePain_SpellName(Language), true);
                    return true;
                }
            }

            //Auto Victory Rush
            if (Aimsharp.CanCast(VictoryRush_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Victory Rush @ HP%"))
                {
                    Aimsharp.Cast(VictoryRush_SpellName(Language), true);
                    return true;
                }
            }

            //Auto Bitter Immunity
            if (Aimsharp.CanCast(BitterImmunity_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Bitter Immunity @ HP%"))
                {
                    Aimsharp.Cast(BitterImmunity_SpellName(Language), true);
                    return true;
                }
            }
            #endregion

            #region Queues
            //Queues
            //Queue StormBolt
            bool StormBolt = Aimsharp.IsCustomCodeOn("StormBolt");
            if (Aimsharp.SpellCooldown(StormBolt_SpellName(Language)) - Aimsharp.GCD() > 2000 && StormBolt && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                Aimsharp.Cast("StormBoltOff");
                return true;
            }

            if (StormBolt && Aimsharp.CanCast(StormBolt_SpellName(Language), "target", true, true))
            {
                Aimsharp.Cast(StormBolt_SpellName(Language));
                return true;
            }

            //Queue Ravager
            bool Ravager = Aimsharp.IsCustomCodeOn("QueueRavager");
            string RavagerCast = GetDropDown("Ravager Cast:");
            if (Aimsharp.SpellCooldown(Ravager_SpellName(Language)) - Aimsharp.GCD() > 2000 && Ravager)
            {
                Aimsharp.Cast("QueueRavagerOff");
                return true;
            }

            if (Ravager && Aimsharp.CanCast(Ravager_SpellName(Language), "player", false, true))
            {
                switch (RavagerCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ravager - " + RavagerCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Ravager_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ravager - " + RavagerCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RavagerP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ravager - " + RavagerCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RavagerC");
                        return true;
                }
            }

            //Queue Heroic Leap
            bool HeroicLeap = Aimsharp.IsCustomCodeOn("HeroicLeap");
            if (Aimsharp.SpellCooldown(HeroicLeap_SpellName(Language)) - Aimsharp.GCD() > 2000 && HeroicLeap)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Heroic Leap Queue", Color.Purple);
                }
                Aimsharp.Cast("HeroicLeapOff");
                return true;
            }
            if (HeroicLeap && Aimsharp.CanCast(HeroicLeap_SpellName(Language), "player", false, true))
            {
                Aimsharp.Cast("HeroicLeapC");
                return true;
            }

            //Queue Spear of Bastion
            string SpearOfBastionCast = GetDropDown("Spear of Bastion Cast:");
            bool SpearOfBastion = Aimsharp.IsCustomCodeOn("SpearOfBastion");
            if (Aimsharp.SpellCooldown(SpearOfBastion_SpellName(Language)) - Aimsharp.GCD() > 2000 && SpearOfBastion)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Spear Of Bastion Queue", Color.Purple);
                }
                Aimsharp.Cast("SpearOfBastionOff");
                return true;
            }

            if (SpearOfBastion && Aimsharp.CanCast(SpearOfBastion_SpellName(Language), "player", false, true))
            {
                switch (SpearOfBastionCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spear Of Bastion - " + SpearOfBastionCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SpearOfBastion_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spear Of Bastion - " + SpearOfBastionCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SpearOfBastionP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spear Of Bastion - " + SpearOfBastionCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SpearOfBastionC");
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
                if (Wait <= 200)
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
                    if (SpellID1 == 312202 && Aimsharp.CanCast(ConquerorsBanner_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(ConquerorsBanner_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 311648 && Aimsharp.CanCast(AncientAftershock_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(AncientAftershock_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 324128 || SpellID1 == 376079) && Aimsharp.CanCast(SpearOfBastion_SpellName(Language), "player", false, true))
                    {
                        switch (SpearOfBastionCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Spear of Bastion - " + SpearOfBastionCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast(SpearOfBastion_SpellName(Language));
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Spear of Bastion - " + SpearOfBastionCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("SpearOfBastionP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Spear of Bastion - " + SpearOfBastionCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("SpearOfBastionC");
                                return true;
                        }
                    }
                    #endregion

                    #region General Spells - NoGCD
                    //Class Spells
                    //Instant [GCD FREE]
                    if (SpellID1 == 184364 && Aimsharp.CanCast(EnragedRegeneration_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(EnragedRegeneration_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 190456 && Aimsharp.CanCast(IgnorePain_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(IgnorePain_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 383762 && Aimsharp.CanCast(BitterImmunity_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(BitterImmunity_SpellName(Language), true);
                        return true;
                    }

                    if ((SpellID1 == 401150 || SpellID1 == 107574) && Aimsharp.CanCast(Avatar_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(Avatar_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 1719 && Aimsharp.CanCast(Recklessness_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(Recklessness_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 23920 && Aimsharp.CanCast(SpellReflection_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(SpellReflection_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 386196 && Aimsharp.CanCast(BerserkerStance_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(BerserkerStance_SpellName(Language), true);
                        return true;
                    }

                    if ((SpellID1 == 197690 || SpellID1 == 386208) && Aimsharp.CanCast(DefensiveStance_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(DefensiveStance_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 18499 && Aimsharp.CanCast(BerserkerRage_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(BerserkerRage_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region Player GCD
                    //Instant [GCD]
                    ///Player

                    if (SpellCast(6673, BattleShout_SpellName(Language), "player")) return true;
                    if (SpellID1 == 228920 && Aimsharp.CanCast(Ravager_SpellName(Language), "player", false, true))
                    {
                        switch (RavagerCast)
                        {
                            case "Manual":
                                return SpellCast(228920, Ravager_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(228920, Ravager_SpellName(Language), "player", "RavagerP");
                            case "Cursor":
                                return SpellCast(228920, Ravager_SpellName(Language), "player", "RavagerC");
                        }
                    }
                    if (SpellCast(1161, ChallengingShout_SpellName(Language), "player")) return true;
                    if (SpellCast(385059, OdynsFury_SpellName(Language), "player")) return true;
                    if (SpellCast(12323, PiercingHowl_SpellName(Language), "player")) return true;
                    if (SpellCast(97462, RallyingCry_SpellName(Language), "player")) return true;
                    if (SpellCast(46968, Shockwave_SpellName(Language), "player")) return true;
                    if (SpellCast(6343, ThunderClap_SpellName(Language), "player")) return true;
                    if (SpellCast(396719, ThunderClap_SpellName(Language), "player")) return true;
                    if (SpellCast(384318, ThunderousRoar_SpellName(Language), "player")) return true;
                    if (SpellCast(1680, Whirlwind_SpellName(Language), "player")) return true;
                    if (SpellCast(190411, Whirlwind_SpellName(Language), "player")) return true;

                    #endregion

                    #region Target GCD
                    ///Target
                    if (SpellCast(335096, Bloodbath_SpellName(Language), "target")) return true;
                    if (SpellCast(23881, Bloodthirst_SpellName(Language), "target")) return true;
                    if (SpellCast(100, Charge_SpellName(Language), "target")) return true;
                    if (SpellCast(335097, CrushingBlow_SpellName(Language), "target")) return true;
                    if (SpellCast(5308, Execute_SpellName(Language), "target")) return true;
                    if (SpellCast(163201, Execute_SpellName(Language), "target")) return true;
                    if (SpellCast(280735, Execute_SpellName(Language), "target")) return true;
                    if (SpellCast(281000, Execute_SpellName(Language), "target")) return true;
                    if (SpellCast(57755, HeroicThrow_SpellName(Language), "target")) return true;
                    if (SpellCast(202168, ImpendingVictory_SpellName(Language), "target")) return true;
                    if (SpellCast(5246, IntimidatingShout_SpellName(Language), "target")) return true;
                    if (SpellCast(315720, Onslaught_SpellName(Language), "target")) return true;
                    if (SpellCast(85288, RagingBlow_SpellName(Language), "target")) return true;
                    if (SpellCast(184367, Rampage_SpellName(Language), "target")) return true;
                    if (SpellCast(772, Rend_SpellName(Language), "target")) return true;
                    if (SpellCast(64382, ShatteringThrow_SpellName(Language), "target")) return true;
                    if (SpellCast(1464, Slam_SpellName(Language), "target")) return true;
                    if (SpellCast(107570, StormBolt_SpellName(Language), "target")) return true;
                    if (SpellCast(34428, VictoryRush_SpellName(Language), "target")) return true;
                    if (SpellCast(384110, WreckingThrow_SpellName(Language), "target")) return true;

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
            #endregion

            bool BSOOC = GetCheckBox("Battle Cry Out of Combat:");

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

            if (Aimsharp.IsCustomCodeOn("SpearOfBastion") && Aimsharp.SpellCooldown(SpearOfBastion_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("HeroicLeap") && Aimsharp.SpellCooldown(HeroicLeap_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("QueueRavager") && Aimsharp.SpellCooldown(Ravager_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            //Queues
            //Queue StormBolt
            bool StormBolt = Aimsharp.IsCustomCodeOn("StormBolt");
            if (Aimsharp.SpellCooldown(StormBolt_SpellName(Language)) - Aimsharp.GCD() > 2000 && StormBolt && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                Aimsharp.Cast("StormBoltOff");
                return true;
            }

            if (StormBolt && Aimsharp.CanCast(StormBolt_SpellName(Language), "target", true, true))
            {
                Aimsharp.Cast(StormBolt_SpellName(Language));
                return true;
            }

            //Queue Ravager
            bool Ravager = Aimsharp.IsCustomCodeOn("QueueRavager");
            string RavagerCast = GetDropDown("Ravager Cast:");
            if (Aimsharp.SpellCooldown(Ravager_SpellName(Language)) - Aimsharp.GCD() > 2000 && Ravager)
            {
                Aimsharp.Cast("QueueRavagerOff");
                return true;
            }

            if (Ravager && Aimsharp.CanCast(Ravager_SpellName(Language), "player", false, true))
            {
                switch (RavagerCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ravager - " + RavagerCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Ravager_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ravager - " + RavagerCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RavagerP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ravager - " + RavagerCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RavagerC");
                        return true;
                }
            }

            //Queue Heroic Leap
            bool HeroicLeap = Aimsharp.IsCustomCodeOn("HeroicLeap");
            if (Aimsharp.SpellCooldown(HeroicLeap_SpellName(Language)) - Aimsharp.GCD() > 2000 && HeroicLeap)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Heroic Leap Queue", Color.Purple);
                }
                Aimsharp.Cast("HeroicLeapOff");
                return true;
            }
            if (HeroicLeap && Aimsharp.CanCast(HeroicLeap_SpellName(Language), "player", false, true))
            {
                Aimsharp.Cast("HeroicLeapC");
                return true;
            }

            //Queue Spear of Bastion
            string SpearOfBastionCast = GetDropDown("Spear of Bastion Cast:");
            bool SpearOfBastion = Aimsharp.IsCustomCodeOn("SpearOfBastion");
            if (Aimsharp.SpellCooldown(SpearOfBastion_SpellName(Language)) - Aimsharp.GCD() > 2000 && SpearOfBastion)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Spear Of Bastion Queue", Color.Purple);
                }
                Aimsharp.Cast("SpearOfBastionOff");
                return true;
            }

            if (SpearOfBastion && Aimsharp.CanCast(SpearOfBastion_SpellName(Language), "player", false, true))
            {
                switch (SpearOfBastionCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spear Of Bastion - " + SpearOfBastionCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SpearOfBastion_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spear Of Bastion - " + SpearOfBastionCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SpearOfBastionP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spear Of Bastion - " + SpearOfBastionCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SpearOfBastionC");
                        return true;
                }
            }
            #endregion

            #region Out of Combat Spells
            if (BSOOC && !Aimsharp.HasBuff(BattleShout_SpellName(Language), "player", true) && !Aimsharp.HasBuff(BattleShout_SpellName(Language), "player", false)) if (SpellCast(6673, "Battle Cry", "player")) return true;
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 6 && TargetInCombat)
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