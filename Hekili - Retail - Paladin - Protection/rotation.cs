using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicPaladinProtectionHekili : Rotation
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

        ///<summary>spell=31850</summary>
        private static string ArdentDefender_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ardent Defender";
                case "Deutsch": return "Unermüdlicher Verteidiger";
                case "Español": return "Defensor candente";
                case "Français": return "Ardent défenseur";
                case "Italiano": return "Fervido Difensore";
                case "Português Brasileiro": return "Defensor Ardente";
                case "Русский": return "Ревностный защитник";
                case "한국어": return "헌신적인 수호자";
                case "简体中文": return "炽热防御者";
                default: return "Ardent Defender";
            }
        }

        ///<summary>spell=231665</summary>
        private static string AvengersShield_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Avenger's Shield";
                case "Deutsch": return "Schild des Rächers";
                case "Español": return "Escudo de vengador";
                case "Français": return "Bouclier du vengeur";
                case "Italiano": return "Scudo del Vendicatore";
                case "Português Brasileiro": return "Escudo do Vingador";
                case "Русский": return "Щит мстителя";
                case "한국어": return "응징의 방패";
                case "简体中文": return "复仇者之盾";
                default: return "Avenger's Shield";
            }
        }

        ///<summary>spell=384376</summary>
        private static string AvengingWrath_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Avenging Wrath";
                case "Deutsch": return "Zornige Vergeltung";
                case "Español": return "Cólera vengativa";
                case "Français": return "Courroux vengeur";
                case "Italiano": return "Ira Vendicatrice";
                case "Português Brasileiro": return "Ira Vingativa";
                case "Русский": return "Гнев карателя";
                case "한국어": return "응징의 격노";
                case "简体中文": return "复仇之怒";
                default: return "Avenging Wrath";
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

        ///<summary>spell=378974</summary>
        private static string BastionOfLight_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bastion of Light";
                case "Deutsch": return "Bastion des Lichts";
                case "Español": return "Bastión de Luz";
                case "Français": return "Bastion de lumière";
                case "Italiano": return "Scudo Bastione della Luce";
                case "Português Brasileiro": return "Bastião da Luz";
                case "Русский": return "Бастион Света";
                case "한국어": return "빛의 수호 방패";
                case "简体中文": return "圣光壁垒";
                default: return "Bastion of Light";
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

        ///<summary>spell=204019</summary>
        private static string BlessedHammer_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blessed Hammer";
                case "Deutsch": return "Gesegneter Hammer";
                case "Español": return "Martillo bendito";
                case "Français": return "Marteau béni";
                case "Italiano": return "Martello Benedetto";
                case "Português Brasileiro": return "Martelo Abençoado";
                case "Русский": return "Благословенный молот";
                case "한국어": return "축복받은 망치";
                case "简体中文": return "祝福之锤";
                default: return "Blessed Hammer";
            }
        }

        ///<summary>spell=1044</summary>
        private static string BlessingOfFreedom_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blessing of Freedom";
                case "Deutsch": return "Segen der Freiheit";
                case "Español": return "Bendición de libertad";
                case "Français": return "Bénédiction de liberté";
                case "Italiano": return "Benedizione della Libertà";
                case "Português Brasileiro": return "Bênção da Liberdade";
                case "Русский": return "Благословенная свобода";
                case "한국어": return "자유의 축복";
                case "简体中文": return "自由祝福";
                default: return "Blessing of Freedom";
            }
        }

        ///<summary>spell=1022</summary>
        private static string BlessingOfProtection_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blessing of Protection";
                case "Deutsch": return "Segen des Schutzes";
                case "Español": return "Bendición de protección";
                case "Français": return "Bénédiction de protection";
                case "Italiano": return "Benedizione della Protezione";
                case "Português Brasileiro": return "Bênção de Proteção";
                case "Русский": return "Благословение защиты";
                case "한국어": return "보호의 축복";
                case "简体中文": return "保护祝福";
                default: return "Blessing of Protection";
            }
        }

        ///<summary>spell=6940</summary>
        private static string BlessingOfSacrifice_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blessing of Sacrifice";
                case "Deutsch": return "Segen der Aufopferung";
                case "Español": return "Bendición de sacrificio";
                case "Français": return "Bénédiction de sacrifice";
                case "Italiano": return "Benedizione del Sacrificio";
                case "Português Brasileiro": return "Bênção do Sacrifício";
                case "Русский": return "Жертвенное благословение";
                case "한국어": return "희생의 축복";
                case "简体中文": return "牺牲祝福";
                default: return "Blessing of Sacrifice";
            }
        }

        ///<summary>spell=115750</summary>
        private static string BlindingLight_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blinding Light";
                case "Deutsch": return "Blendendes Licht";
                case "Español": return "Luz cegadora";
                case "Français": return "Lumière aveuglante";
                case "Italiano": return "Luce Accecante";
                case "Português Brasileiro": return "Luz Ofuscante";
                case "Русский": return "Слепящий свет";
                case "한국어": return "눈부신 빛";
                case "简体中文": return "盲目之光";
                default: return "Blinding Light";
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

        ///<summary>spell=213644</summary>
        private static string CleanseToxins_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Cleanse Toxins";
                case "Deutsch": return "Toxine läutern";
                case "Español": return "Limpiar toxinas";
                case "Français": return "Purification des toxines";
                case "Italiano": return "Purificazione dalle Tossine";
                case "Português Brasileiro": return "Purificar Toxinas";
                case "Русский": return "Очищение от токсинов";
                case "한국어": return "독소 정화";
                case "简体中文": return "清毒术";
                default: return "Cleanse Toxins";
            }
        }

        ///<summary>spell=26573</summary>
        private static string Consecration_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Consecration";
                case "Deutsch": return "Weihe";
                case "Español": return "Consagración";
                case "Français": return "Consécration";
                case "Italiano": return "Consacrazione";
                case "Português Brasileiro": return "Consagração";
                case "Русский": return "Освящение";
                case "한국어": return "신성화";
                case "简体中文": return "奉献";
                default: return "Consecration";
            }
        }

        ///<summary>spell=328557</summary>
        private static string CrusaderAura_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Crusader Aura";
                case "Deutsch": return "Aura des Kreuzfahrers";
                case "Español": return "Aura de cruzado";
                case "Français": return "Aura de croisé";
                case "Italiano": return "Aura del Crociato";
                case "Português Brasileiro": return "Aura do Cruzado";
                case "Русский": return "Аура рыцаря";
                case "한국어": return "성전사 오라";
                case "简体中文": return "十字军光环";
                default: return "Crusader Aura";
            }
        }

        ///<summary>spell=35395</summary>
        private static string CrusaderStrike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Crusader Strike";
                case "Deutsch": return "Kreuzfahrerstoß";
                case "Español": return "Golpe de cruzado";
                case "Français": return "Frappe du croisé";
                case "Italiano": return "Assalto del Crociato";
                case "Português Brasileiro": return "Golpe do Cruzado";
                case "Русский": return "Удар воина Света";
                case "한국어": return "성전사의 일격";
                case "简体中文": return "十字军打击";
                default: return "Crusader Strike";
            }
        }

        ///<summary>spell=465</summary>
        private static string DevotionAura_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Devotion Aura";
                case "Deutsch": return "Aura der Hingabe";
                case "Español": return "Aura de devoción";
                case "Français": return "Aura de dévotion";
                case "Italiano": return "Aura della Devozione";
                case "Português Brasileiro": return "Aura de Devoção";
                case "Русский": return "Аура благочестия";
                case "한국어": return "헌신의 오라";
                case "简体中文": return "虔诚光环";
                default: return "Devotion Aura";
            }
        }

        ///<summary>spell=642</summary>
        private static string DivineShield_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Divine Shield";
                case "Deutsch": return "Gottesschild";
                case "Español": return "Escudo divino";
                case "Français": return "Bouclier divin";
                case "Italiano": return "Scudo Divino";
                case "Português Brasileiro": return "Escudo Divino";
                case "Русский": return "Божественный щит";
                case "한국어": return "천상의 보호막";
                case "简体中文": return "圣盾术";
                default: return "Divine Shield";
            }
        }

        ///<summary>spell=190784</summary>
        private static string DivineSteed_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Divine Steed";
                case "Deutsch": return "Göttliches Ross";
                case "Español": return "Corcel divino";
                case "Français": return "Palefroi divin";
                case "Italiano": return "Destriero Divino";
                case "Português Brasileiro": return "Corcel Divino";
                case "Русский": return "Божественный скакун";
                case "한국어": return "천상의 군마";
                case "简体中文": return "神圣马驹";
                default: return "Divine Steed";
            }
        }

        ///<summary>spell=375576</summary>
        private static string DivineToll_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Divine Toll";
                case "Deutsch": return "Göttlicher Glockenschlag";
                case "Español": return "Estrago divino";
                case "Français": return "Glas divin";
                case "Italiano": return "Rintocco Divino";
                case "Português Brasileiro": return "Preço Divino";
                case "Русский": return "Божественный благовест";
                case "한국어": return "천상의 종";
                case "简体中文": return "圣洁鸣钟";
                default: return "Divine Toll";
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

        ///<summary>spell=387174</summary>
        private static string EyeOfTyr_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Eye of Tyr";
                case "Deutsch": return "Auge von Tyr";
                case "Español": return "Ojo de Tyr";
                case "Français": return "Œil de Tyr";
                case "Italiano": return "Occhio di Tyr";
                case "Português Brasileiro": return "Olho de Tyr";
                case "Русский": return "Око Тира";
                case "한국어": return "티르의 눈";
                case "简体中文": return "提尔之眼";
                default: return "Eye of Tyr";
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

        ///<summary>spell=86659</summary>
        private static string GuardianOfAncientKings_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Guardian of Ancient Kings";
                case "Deutsch": return "Wächter der Uralten Könige";
                case "Español": return "Guardián de los antiguos reyes";
                case "Français": return "Gardien des anciens rois";
                case "Italiano": return "Guardiano dei Re Antichi";
                case "Português Brasileiro": return "Guardião dos Reis Antigos";
                case "Русский": return "Защитник древних королей";
                case "한국어": return "고대 왕의 수호자";
                case "简体中文": return "远古列王守卫";
                default: return "Guardian of Ancient Kings";
            }
        }

        ///<summary>spell=853</summary>
        private static string HammerOfJustice_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Hammer of Justice";
                case "Deutsch": return "Hammer der Gerechtigkeit";
                case "Español": return "Martillo de Justicia";
                case "Français": return "Marteau de la justice";
                case "Italiano": return "Martello della Giustizia";
                case "Português Brasileiro": return "Martelo da Justiça";
                case "Русский": return "Молот правосудия";
                case "한국어": return "심판의 망치";
                case "简体中文": return "制裁之锤";
                default: return "Hammer of Justice";
            }
        }

        ///<summary>spell=317854</summary>
        private static string HammerOfTheRighteous_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Hammer of the Righteous";
                case "Deutsch": return "Hammer der Rechtschaffenen";
                case "Español": return "Martillo del honrado";
                case "Français": return "Marteau du vertueux";
                case "Italiano": return "Martello del Virtuoso";
                case "Português Brasileiro": return "Martelo do Íntegro";
                case "Русский": return "Молот праведника";
                case "한국어": return "정의의 망치";
                case "简体中文": return "正义之锤";
                default: return "Hammer of the Righteous";
            }
        }

        ///<summary>spell=24275</summary>
        private static string HammerOfWrath_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Hammer of Wrath";
                case "Deutsch": return "Hammer des Zorns";
                case "Español": return "Martillo de cólera";
                case "Français": return "Marteau de courroux";
                case "Italiano": return "Martello dell'Ira";
                case "Português Brasileiro": return "Martelo da Ira";
                case "Русский": return "Молот гнева";
                case "한국어": return "천벌의 망치";
                case "简体中文": return "愤怒之锤";
                default: return "Hammer of Wrath";
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

        ///<summary>spell=105809</summary>
        private static string HolyAvenger_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Holy Avenger";
                case "Deutsch": return "Heiliger Rächer";
                case "Español": return "Vengador sagrado";
                case "Français": return "Vengeur sacré";
                case "Italiano": return "Vendicatore Sacro";
                case "Português Brasileiro": return "Vingador Sagrado";
                case "Русский": return "Святой каратель";
                case "한국어": return "신성한 복수자";
                case "简体中文": return "神圣复仇者";
                default: return "Holy Avenger";
            }
        }

        ///<summary>spell=391054</summary>
        private static string Intercession_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Intercession";
                case "Deutsch": return "Fürbitte";
                case "Español": return "Intercesión";
                case "Français": return "Intercession";
                case "Italiano": return "Intercessione";
                case "Português Brasileiro": return "Intercessão";
                case "Русский": return "Заступничество";
                case "한국어": return "중재";
                case "简体中文": return "代祷";
                default: return "Intercession";
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

        ///<summary>spell=633</summary>
        private static string LayOnHands_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Lay on Hands";
                case "Deutsch": return "Handauflegung";
                case "Español": return "Imposición de manos";
                case "Français": return "Imposition des mains";
                case "Italiano": return "Mano Celestiale";
                case "Português Brasileiro": return "Impor as Mãos";
                case "Русский": return "Возложение рук";
                case "한국어": return "신의 축복";
                case "简体中文": return "圣疗术";
                default: return "Lay on Hands";
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

        ///<summary>spell=327193</summary>
        private static string MomentOfGlory_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Moment of Glory";
                case "Deutsch": return "Ruhmreicher Moment";
                case "Español": return "Momento de gloria";
                case "Français": return "Moment de gloire";
                case "Italiano": return "Momento di Gloria";
                case "Português Brasileiro": return "Momento de Glória";
                case "Русский": return "Минута славы";
                case "한국어": return "영광의 순간";
                case "简体中文": return "光荣时刻";
                default: return "Moment of Glory";
            }
        }

        ///<summary>spell=96231</summary>
        private static string Rebuke_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rebuke";
                case "Deutsch": return "Zurechtweisung";
                case "Español": return "Reprimenda";
                case "Français": return "Réprimandes";
                case "Italiano": return "Predica";
                case "Português Brasileiro": return "Repreensão";
                case "Русский": return "Укор";
                case "한국어": return "비난";
                case "简体中文": return "责难";
                default: return "Rebuke";
            }
        }

        ///<summary>spell=20066</summary>
        private static string Repentance_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Repentance";
                case "Deutsch": return "Buße";
                case "Español": return "Arrepentimiento";
                case "Français": return "Repentir";
                case "Italiano": return "Penitenza";
                case "Português Brasileiro": return "Contrição";
                case "Русский": return "Покаяние";
                case "한국어": return "참회";
                case "简体中文": return "忏悔";
                default: return "Repentance";
            }
        }

        ///<summary>spell=183435</summary>
        private static string RetributionAura_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Retribution Aura";
                case "Deutsch": return "Aura der Vergeltung";
                case "Español": return "Aura de reprensión";
                case "Français": return "Aura de vindicte";
                case "Italiano": return "Aura del Castigo";
                case "Português Brasileiro": return "Aura da Retribuição";
                case "Русский": return "Аура воздаяния";
                case "한국어": return "응보의 오라";
                case "简体中文": return "惩戒光环";
                default: return "Retribution Aura";
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

        ///<summary>spell= 389539</summary>
        private static string Sentinel_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sentinel";
                case "Deutsch": return "Schildwache";
                case "Español": return "Centinela";
                case "Français": return "Sentinelle";
                case "Italiano": return "Sentinella";
                case "Português Brasileiro": return "Sentinela";
                case "Русский": return "Часовой";
                case "한국어": return "파수꾼";
                case "简体中文": return "戒卫";
                default: return "Sentinel";
            }
        }

        ///<summary>spell=152262</summary>
        private static string Seraphim_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Seraphim";
                case "Deutsch": return "Seraphim";
                case "Español": return "Serafín";
                case "Français": return "Séraphin";
                case "Italiano": return "Serafino";
                case "Português Brasileiro": return "Serafim";
                case "Русский": return "Серафим";
                case "한국어": return "고위 천사";
                case "简体中文": return "炽天使";
                default: return "Seraphim";
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

        ///<summary>spell=53600</summary>
        private static string ShieldOfTheRighteous_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shield of the Righteous";
                case "Deutsch": return "Schild der Rechtschaffenen";
                case "Español": return "Escudo del honrado";
                case "Français": return "Bouclier du vertueux";
                case "Italiano": return "Scudo del Virtuoso";
                case "Português Brasileiro": return "Escudo do Íntegro";
                case "Русский": return "Щит праведника";
                case "한국어": return "정의의 방패";
                case "简体中文": return "正义盾击";
                default: return "Shield of the Righteous";
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

        ///<summary>spell=10326</summary>
        private static string TurnEvil_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Turn Evil";
                case "Deutsch": return "Böses vertreiben";
                case "Español": return "Ahuyentar el mal";
                case "Français": return "Renvoi du mal";
                case "Italiano": return "Repulsione del Male";
                case "Português Brasileiro": return "Esconjurar o Mal";
                case "Русский": return "Изгнание зла";
                case "한국어": return "악령 퇴치";
                case "简体中文": return "超度邪恶";
                default: return "Turn Evil";
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

        ///<summary>spell=85673</summary>
        private static string WordOfGlory_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Word of Glory";
                case "Deutsch": return "Wort der Herrlichkeit";
                case "Español": return "Palabra de gloria";
                case "Français": return "Mot de gloire";
                case "Italiano": return "Parola di Gloria";
                case "Português Brasileiro": return "Palavra de Glória";
                case "Русский": return "Торжество";
                case "한국어": return "영광의 서약";
                case "简体中文": return "荣耀圣令";
                default: return "Word of Glory";
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

        #region Variables
        string FiveLetters;
        string UsableItem;
        Stopwatch HSTimer = new Stopwatch();
        Stopwatch ItemTimer = new Stopwatch();

        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle", "HammerofJustice","NoCleanse", "IntercessionMO", "BlessingofFreedom", "BlessingofProtection", "BlessingofSacrifice","RepentanceMO", "WordofGloryParty", "TurnEvilMO" };
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
        public Dictionary<string, int> PartyDict = new Dictionary<string, int>() { };
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

            //Focus Units
            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");

            //Focus
            Macros.Add("CT_FOC", "/cast [@focus] " + CleanseToxins_SpellName(Language));
            Macros.Add("WOG_FOC", "/cast [@focus] " + WordOfGlory_SpellName(Language));
            Macros.Add("LOH_FOC", "/cast [@focus] " + LayOnHands_SpellName(Language));

            //Queues
            Macros.Add("BlessingofFreedomOff", "/" + FiveLetters + " BlessingofFreedom");
            Macros.Add("BlessingofFreedomMO", "/cast [@mouseover,exists] " + BlessingOfFreedom_SpellName(Language));

            Macros.Add("BlessingofProtectionOff", "/" + FiveLetters + " BlessingofProtection");
            Macros.Add("BlessingofProtectionMO", "/cast [@mouseover,exists] " + BlessingOfProtection_SpellName(Language));

            Macros.Add("BlessingofSacrificeOff", "/" + FiveLetters + " BlessingofSacrifice");
            Macros.Add("BlessingofSacrificeMO", "/cast [@mouseover,exists] " + BlessingOfSacrifice_SpellName(Language));

            Macros.Add("RepentanceOff", "/" + FiveLetters + " RepentanceMO");
            Macros.Add("RepentanceMO", "/cast [@mouseover,exists] " + Repentance_SpellName(Language));

            Macros.Add("TurnEvilOff", "/" + FiveLetters + " TurnEvilMO");
            Macros.Add("TurnEvilMO", "/cast [@mouseover,exists] " + TurnEvil_SpellName(Language));

            Macros.Add("IntercessionMOMacro", "/cast [@mouseover,exists] " + Intercession_SpellName(Language));
            Macros.Add("IntercessionOff", "/" + FiveLetters + " IntercessionMO");

            Macros.Add("HammerofJusticeOff", "/" + FiveLetters + " HammerofJustice");
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

            CustomFunctions.Add("DiseasePoisonCheck", "local y=0; " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"player\",i,\"RAID\"); " +
            "if type ~= nil and (type == \"Disease\" or type == \"Poison\") then y = y +1; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
            "if type ~= nil and (type == \"Disease\" or type == \"Poison\") then y = y +2; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
            "if type ~= nil and (type == \"Disease\" or type == \"Poison\") then y = y +4; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
            "if type ~= nil and (type == \"Disease\" or type == \"Poison\") then y = y +8; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
            "if type ~= nil and (type == \"Disease\" or type == \"Poison\") then y = y +16; end end " +
            "return y");

            CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
            "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
            "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
            "\nreturn foc");
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
            Settings.Add(new Setting("Item Use:", ""));
            Settings.Add(new Setting("Auto Item @ HP%", 0, 100, 35));
            Settings.Add(new Setting("Kicks/Interrupts"));
            Settings.Add(new Setting("Randomize Kicks:", false));
            Settings.Add(new Setting("Kick at milliseconds remaining", 50, 1500, 500));
            Settings.Add(new Setting("Kick channels after milliseconds", 50, 1500, 500));
            Settings.Add(new Setting("General"));
            Settings.Add(new Setting("Auto Start Combat:", true));
            Settings.Add(new Setting("Auto Divine Shield @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Ardent Defender @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Auto Guardian of Ancient Kings @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Auto Lay on Hands @ HP%", 0, 100, 20));
            Settings.Add(new Setting("Auto Word of Glory @ HP%", 0, 100, 50));
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

            Aimsharp.PrintMessage("Epic PVE - Paladin Protection", Color.White);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything in every tab there, especially Pause !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/paladin/protection/overview-pve-tank", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.White);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCleanse - Disables Cleanse", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " HammerofJustice - Casts Hammer of Justice @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " IntercessionMO - Casts Intercession @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " RepentanceMO - Casts Repentance @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " TurnEvilMO - Casts Turn Evil @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " WordofGloryParty - Enables Word of Glory as a Spender based on Party Member HP%", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BlessingofFreedom - Casts Blessing of Freedom @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BlessingofProtection - Casts Blessing of Protection @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BlessingofSacrifice - Casts Blessing of Sacrifice @ Mouseover next GCD", Color.Yellow);
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

            m_DebuffsList = new List<string> { };
            m_BuffsList = new List<string> { BattleShout_SpellName(Language), };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language), UsableItem};
            m_SpellBook_General = new List<string> {
                ShieldOfTheRighteous_SpellName(Language),
                AvengingWrath_SpellName(Language),
                GuardianOfAncientKings_SpellName(Language),
                ArdentDefender_SpellName(Language),
                MomentOfGlory_SpellName(Language),
                Rebuke_SpellName(Language),
                BastionOfLight_SpellName(Language),
                Sentinel_SpellName(Language),

                BlessingOfFreedom_SpellName(Language),
                BlessingOfProtection_SpellName(Language),
                BlessingOfSacrifice_SpellName(Language),
                Consecration_SpellName(Language),
                CrusaderStrike_SpellName(Language),
                CleanseToxins_SpellName(Language),
                DivineShield_SpellName(Language),
                DivineSteed_SpellName(Language),
                HammerOfJustice_SpellName(Language),
                "Hand of Reckoning",
                Judgment_SpellName(Language),
                WordOfGlory_SpellName(Language),
                BlindingLight_SpellName(Language),
                HammerOfWrath_SpellName(Language),
                HolyAvenger_SpellName(Language),
                LayOnHands_SpellName(Language),
                Seraphim_SpellName(Language),
                Repentance_SpellName(Language),
                TurnEvil_SpellName(Language),

                DevotionAura_SpellName(Language),
                RetributionAura_SpellName(Language),
                CrusaderAura_SpellName(Language),
                "Concentration Aura",

                AvengersShield_SpellName(Language),
                BlessedHammer_SpellName(Language),
                DivineToll_SpellName(Language),
                EyeOfTyr_SpellName(Language),
                HammerOfTheRighteous_SpellName(Language),
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
            bool NoCleanse = Aimsharp.IsCustomCodeOn("NoCleanse");

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

            int DivineShieldHP = GetSlider("Auto Divine Shield @ HP%");
            int LayonHandsHP = GetSlider("Auto Lay on Hands @ HP%");
            int ArdentDefenderHP = GetSlider("Auto Ardent Defender @ HP%");
            int GuardianofAncientKingsHP = GetSlider("Auto Guardian of Ancient Kings @ HP%");

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
                if (Aimsharp.CanCast(Rebuke_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Rebuke_SpellName(Language), true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast(Rebuke_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Rebuke_SpellName(Language), true);
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

            #region Word of Glory
            if (Aimsharp.IsCustomCodeOn("WordofGloryParty") && UnitBelowThreshold(GetSlider("Auto Word of Glory @ HP%")) && Aimsharp.CanCast(WordOfGlory_SpellName(Language), "player", false, true))
            {
                PartyDict.Clear();
                PartyDict.Add("player", Aimsharp.Health("player"));

                var partysize = Aimsharp.GroupSize();
                if (partysize <= 5)
                {
                    for (int i = 1; i < partysize; i++)
                    {
                        var partyunit = ("party" + i);
                        if (Aimsharp.Health(partyunit) > 0 && Aimsharp.SpellInRange(WordOfGlory_SpellName(Language),partyunit))
                        {
                            PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                        }
                    }
                }

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    if (Aimsharp.CanCast(WordOfGlory_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.SpellInRange(WordOfGlory_SpellName(Language),unit.Key)) && Aimsharp.Health(unit.Key) <= GetSlider("Auto Word of Glory @ HP%"))
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
                                Aimsharp.Cast("WOG_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Word of Glory @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Lay on Hands
            if (UnitBelowThreshold(GetSlider("Auto Lay on Hands @ HP%")) && Aimsharp.CanCast(LayOnHands_SpellName(Language), "player", false, true))
            {
                PartyDict.Clear();
                PartyDict.Add("player", Aimsharp.Health("player"));

                var partysize = Aimsharp.GroupSize();
                if (partysize <= 5)
                {
                    for (int i = 1; i < partysize; i++)
                    {
                        var partyunit = ("party" + i);
                        if (Aimsharp.Health(partyunit) > 0 && Aimsharp.SpellInRange(LayOnHands_SpellName(Language),partyunit))
                        {
                            PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                        }
                    }
                }

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    if (Aimsharp.CanCast(LayOnHands_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.SpellInRange(LayOnHands_SpellName(Language),unit.Key)) && Aimsharp.Health(unit.Key) <= GetSlider("Auto Lay on Hands @ HP%"))
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
                                Aimsharp.Cast("LOH_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Lay on Hands @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            //Auto Divine Shield
            if (PlayerHP <= DivineShieldHP && Aimsharp.CanCast(DivineShield_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Divine Shield - Player HP% " + PlayerHP + " due to setting being on HP% " + DivineShieldHP, Color.Purple);
                }
                Aimsharp.Cast(DivineShield_SpellName(Language));
                return true;
            }

            //Auto Ardent Defender
            if (PlayerHP <= ArdentDefenderHP && Aimsharp.CanCast(ArdentDefender_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Ardent Defender - Player HP% " + PlayerHP + " due to setting being on HP% " + ArdentDefenderHP, Color.Purple);
                }
                Aimsharp.Cast(ArdentDefender_SpellName(Language));
                return true;
            }

            //Auto Guardian of Ancient Kings
            if (PlayerHP <= GuardianofAncientKingsHP && Aimsharp.CanCast(GuardianOfAncientKings_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Guardian of Ancient Kings - Player HP% " + PlayerHP + " due to setting being on HP% " + GuardianofAncientKingsHP, Color.Purple);
                }
                Aimsharp.Cast(GuardianOfAncientKings_SpellName(Language));
                return true;
            }
            #endregion

            #region Cleanse Toxins
            if (!NoCleanse && Aimsharp.CustomFunction("DiseasePoisonCheck") > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != CleanseToxins_SpellName(Language))
            {
                PartyDict.Clear();
                PartyDict.Add("player", Aimsharp.Health("player"));

                var partysize = Aimsharp.GroupSize();
                for (int i = 1; i < partysize; i++)
                {
                    var partyunit = ("party" + i);
                    if (Aimsharp.Health(partyunit) > 0 && Aimsharp.SpellInRange(CleanseToxins_SpellName(Language),partyunit))
                    {
                        PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                    }
                }

                int states = Aimsharp.CustomFunction("DiseasePoisonCheck");
                CleansePlayers target;

                int KickTimer = GetRandomNumber(200, 800);

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast(CleanseToxins_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.SpellInRange(CleanseToxins_SpellName(Language),unit.Key)) && isUnitCleansable(target, states))
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
                                Aimsharp.Cast("CT_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Cleanse Toxins @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Queues
            //Queues
            bool Intercession = Aimsharp.IsCustomCodeOn("IntercessionMO");
            if (Aimsharp.SpellCooldown(Intercession_SpellName(Language)) - Aimsharp.GCD() > 2000 && Intercession)
            {
                Aimsharp.Cast("IntercessionOff");
                return true;
            }

            if (Intercession && Aimsharp.CanCast(Intercession_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("IntercessionMOMacro");
                return true;
            }

            bool Repentance = Aimsharp.IsCustomCodeOn("RepentanceMO");
            if (Aimsharp.SpellCooldown(Repentance_SpellName(Language)) - Aimsharp.GCD() > 2000 && Repentance)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Repentance Queue", Color.Purple);
                }
                Aimsharp.Cast("RepentanceOff");
                return true;
            }

            if (Repentance && Aimsharp.CanCast(Repentance_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Repentance - Queue", Color.Purple);
                }
                Aimsharp.Cast("RepentanceMO");
                return true;
            }

            bool TurnEvil = Aimsharp.IsCustomCodeOn("TurnEvilMO");
            if (Aimsharp.SpellCooldown(TurnEvil_SpellName(Language)) - Aimsharp.GCD() > 2000 && TurnEvil)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Turn Evil Queue", Color.Purple);
                }
                Aimsharp.Cast("TurnEvilOff");
                return true;
            }
            if (TurnEvil && Aimsharp.CanCast(TurnEvil_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Turn Evil - Queue", Color.Purple);
                }
                Aimsharp.Cast("TurnEvilMO");
                return true;
            }

            bool HammerofJustice = Aimsharp.IsCustomCodeOn("HammerofJustice");
            if (Aimsharp.SpellCooldown(HammerOfJustice_SpellName(Language)) - Aimsharp.GCD() > 2000 && HammerofJustice)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Hammer of Justice Queue", Color.Purple);
                }
                Aimsharp.Cast("HammerofJusticeOff");
                return true;
            }

            if (HammerofJustice && Aimsharp.CanCast(HammerOfJustice_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Hammer of Justice - Queue", Color.Purple);
                }
                Aimsharp.Cast(HammerOfJustice_SpellName(Language));
                return true;
            }
            bool BlessingofSacrifice = Aimsharp.IsCustomCodeOn("BlessingofSacrifice");
            if (Aimsharp.SpellCooldown(BlessingOfSacrifice_SpellName(Language)) - Aimsharp.GCD() > 2000 && BlessingofSacrifice)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blessing of Sacrifice Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofSacrificeOff");
                return true;
            }

            if (BlessingofSacrifice && Aimsharp.CanCast(BlessingOfSacrifice_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of Sacrifice - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofSacrificeMO");
                return true;
            }

            bool BlessingofProtection = Aimsharp.IsCustomCodeOn("BlessingofProtection");
            if (Aimsharp.SpellCooldown(BlessingOfProtection_SpellName(Language)) - Aimsharp.GCD() > 2000 && BlessingofProtection)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blessing of Protection Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofProtectionOff");
                return true;
            }

            if (BlessingofProtection && Aimsharp.CanCast(BlessingOfProtection_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of Protection - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofProtectionMO");
                return true;
            }

            bool BlessingofFreedom = Aimsharp.IsCustomCodeOn("BlessingofFreedom");
            if (Aimsharp.SpellCooldown(BlessingOfFreedom_SpellName(Language)) - Aimsharp.GCD() > 2000 && BlessingofFreedom)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blessing of Freedom Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofFreedomOff");
                return true;
            }

            if (BlessingofFreedom && Aimsharp.CanCast(BlessingOfFreedom_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of Freedom - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofFreedomMO");
                return true;
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

                    if ((SpellID1 == 28730 || SpellID1 == 25046 || SpellID1 == 50613 || SpellID1 == 69179 || SpellID1 == 80483 || SpellID1 == 129597) && Aimsharp.CanCast(ArcaneTorrent_SpellName(Language), "player", true, false))
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

                    #region General Spells - NoGCD
                    //Class Spells
                    //Instant [GCD FREE]
                    //Shield of the Righteous
                    if (SpellID1 == 53600 && Aimsharp.CanCast(ShieldOfTheRighteous_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(ShieldOfTheRighteous_SpellName(Language), true);
                        return true;
                    }
                    //Avenging Wrath
                    if (SpellID1 == 31884 && Aimsharp.CanCast(AvengingWrath_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(AvengingWrath_SpellName(Language), true);
                        return true;
                    }
                    //Guardian of Ancient Kings
                    if ((SpellID1 == 190456 || SpellID1 == 86659) && Aimsharp.CanCast(GuardianOfAncientKings_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(GuardianOfAncientKings_SpellName(Language), true);
                        return true;
                    }
                    //Ardent Defender
                    if (SpellID1 == 31850 && Aimsharp.CanCast(ArdentDefender_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(ArdentDefender_SpellName(Language), true);
                        return true;
                    }
                    //Moment of Glory
                    if (SpellID1 == 327193 && Aimsharp.CanCast(MomentOfGlory_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(MomentOfGlory_SpellName(Language), true);
                        return true;
                    }
                    //Rebuke
                    if (SpellID1 == 96231 && Aimsharp.CanCast(Rebuke_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(Rebuke_SpellName(Language), true);
                        return true;
                    }
                    //Bastion of Light
                    if (SpellID1 == 204035 && Aimsharp.CanCast(BastionOfLight_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(BastionOfLight_SpellName(Language), true);
                        return true;
                    }
                    //Sentinel
                    if (SpellID1 == 389539 && Aimsharp.CanCast(Sentinel_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(Sentinel_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region Paladin General Spells
                    if (SpellCast(1044, BlessingOfFreedom_SpellName(Language), "player")) return true;
                    if (SpellCast(1022, BlessingOfProtection_SpellName(Language), "player")) return true;
                    if (SpellCast(6940, BlessingOfSacrifice_SpellName(Language), "player")) return true;
                    if (SpellCast(26573, Consecration_SpellName(Language), "player")) return true;
                    if (SpellCast(35395, CrusaderStrike_SpellName(Language), "target")) return true;
                    if (SpellCast(213644, CleanseToxins_SpellName(Language), "player")) return true;
                    if (SpellCast(642, DivineShield_SpellName(Language), "player")) return true;
                    if (SpellCast(190784, DivineSteed_SpellName(Language), "player")) return true;
                    if (SpellCast(853, HammerOfJustice_SpellName(Language), "target")) return true;
                    if (SpellCast(62124, "Hand of Reckoning", "target")) return true;
                    if (SpellCast(20271, Judgment_SpellName(Language), "target")) return true;
                    if (SpellCast(275779, Judgment_SpellName(Language), "target")) return true;
                    if (SpellCast(85673, WordOfGlory_SpellName(Language), "player")) return true;
                    if (SpellCast(115750, BlindingLight_SpellName(Language), "player")) return true;
                    if (SpellCast(24275, HammerOfWrath_SpellName(Language), "target")) return true;
                    if (SpellCast(105809, HolyAvenger_SpellName(Language), "target")) return true;
                    if (SpellCast(633, LayOnHands_SpellName(Language), "player")) return true;
                    if (SpellCast(152262, Seraphim_SpellName(Language), "player")) return true;
                    if (SpellCast(20066, Repentance_SpellName(Language), "target")) return true;
                    if (SpellCast(10326, TurnEvil_SpellName(Language), "target")) return true;

                    //Aura
                    if (SpellCast(465, DevotionAura_SpellName(Language), "player")) return true;
                    if (SpellCast(183425, RetributionAura_SpellName(Language), "player")) return true;
                    if (SpellCast(32223, CrusaderAura_SpellName(Language), "player")) return true;
                    if (SpellCast(317920, "Concentration Aura", "player")) return true;
                    #endregion

                    #region Paladin Protection Spells
                    if (SpellCast(31935, AvengersShield_SpellName(Language), "target")) return true;
                    if (SpellCast(204019, BlessedHammer_SpellName(Language), "target")) return true;
                    if (SpellCast(375576, DivineToll_SpellName(Language), "target")) return true;
                    if (SpellCast(387174, EyeOfTyr_SpellName(Language), "player")) return true;
                    if (SpellCast(53595, HammerOfTheRighteous_SpellName(Language), "target")) return true;
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

            if (HSTimer.IsRunning) HSTimer.Reset();
            if (ItemTimer.IsRunning && ItemTimer.ElapsedMilliseconds > 300000) ItemTimer.Reset();

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
            bool Intercession = Aimsharp.IsCustomCodeOn("IntercessionMO");
            if (Aimsharp.SpellCooldown(Intercession_SpellName(Language)) - Aimsharp.GCD() > 2000 && Intercession)
            {
                Aimsharp.Cast("IntercessionOff");
                return true;
            }

            if (Intercession && Aimsharp.CanCast(Intercession_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("IntercessionMOMacro");
                return true;
            }

            bool Repentance = Aimsharp.IsCustomCodeOn("RepentanceMO");
            if (Aimsharp.SpellCooldown(Repentance_SpellName(Language)) - Aimsharp.GCD() > 2000 && Repentance)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Repentance Queue", Color.Purple);
                }
                Aimsharp.Cast("RepentanceOff");
                return true;
            }

            if (Repentance && Aimsharp.CanCast(Repentance_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Repentance - Queue", Color.Purple);
                }
                Aimsharp.Cast("RepentanceMO");
                return true;
            }

            bool TurnEvil = Aimsharp.IsCustomCodeOn("TurnEvilMO");
            if (Aimsharp.SpellCooldown(TurnEvil_SpellName(Language)) - Aimsharp.GCD() > 2000 && TurnEvil)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Turn Evil Queue", Color.Purple);
                }
                Aimsharp.Cast("TurnEvilOff");
                return true;
            }
            if (TurnEvil && Aimsharp.CanCast(TurnEvil_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Turn Evil - Queue", Color.Purple);
                }
                Aimsharp.Cast("TurnEvilMO");
                return true;
            }

            bool HammerofJustice = Aimsharp.IsCustomCodeOn("HammerofJustice");
            if (Aimsharp.SpellCooldown(HammerOfJustice_SpellName(Language)) - Aimsharp.GCD() > 2000 && HammerofJustice)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Hammer of Justice Queue", Color.Purple);
                }
                Aimsharp.Cast("HammerofJusticeOff");
                return true;
            }

            if (HammerofJustice && Aimsharp.CanCast(HammerOfJustice_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Hammer of Justice - Queue", Color.Purple);
                }
                Aimsharp.Cast(HammerOfJustice_SpellName(Language));
                return true;
            }
            bool BlessingofSacrifice = Aimsharp.IsCustomCodeOn("BlessingofSacrifice");
            if (Aimsharp.SpellCooldown(BlessingOfSacrifice_SpellName(Language)) - Aimsharp.GCD() > 2000 && BlessingofSacrifice)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blessing of Sacrifice Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofSacrificeOff");
                return true;
            }

            if (BlessingofSacrifice && Aimsharp.CanCast(BlessingOfSacrifice_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of Sacrifice - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofSacrificeMO");
                return true;
            }

            bool BlessingofProtection = Aimsharp.IsCustomCodeOn("BlessingofProtection");
            if (Aimsharp.SpellCooldown(BlessingOfProtection_SpellName(Language)) - Aimsharp.GCD() > 2000 && BlessingofProtection)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blessing of Protection Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofProtectionOff");
                return true;
            }

            if (BlessingofProtection && Aimsharp.CanCast(BlessingOfProtection_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of Protection - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofProtectionMO");
                return true;
            }

            bool BlessingofFreedom = Aimsharp.IsCustomCodeOn("BlessingofFreedom");
            if (Aimsharp.SpellCooldown(BlessingOfFreedom_SpellName(Language)) - Aimsharp.GCD() > 2000 && BlessingofFreedom)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blessing of Freedom Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofFreedomOff");
                return true;
            }

            if (BlessingofFreedom && Aimsharp.CanCast(BlessingOfFreedom_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of Freedom - Queue", Color.Purple);
                }
                Aimsharp.Cast("BlessingofFreedomMO");
                return true;
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