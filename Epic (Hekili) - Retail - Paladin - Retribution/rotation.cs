using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicPaladinRetributionHekili : Rotation
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

        ///<summary>spell=316958</summary>
        private static string AshenHallow_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ashen Hallow";
                case "Deutsch": return "Ascheweihung";
                case "Español": return "Santificación cinérea";
                case "Français": return "Bénédiction cendrée";
                case "Italiano": return "Santificazione Cinerea";
                case "Português Brasileiro": return "Consagração Cinzenta";
                case "Русский": return "Пепельное освящение";
                case "한국어": return "잿빛 신성화";
                case "简体中文": return "红烬圣土";
                default: return "Ashen Hallow";
            }
        }

        ///<summary>spell=31884</summary>
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

        ///<summary>spell=335305</summary>
        private static string BarbedShackles_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Barbed Shackles";
                case "Deutsch": return "Gezackte Fesseln";
                case "Español": return "Grilletes con púas";
                case "Français": return "Entraves barbelées";
                case "Italiano": return "Manette con Barbigli";
                case "Português Brasileiro": return "Grilhões Serrilhados";
                case "Русский": return "Выщербленные кандалы";
                case "한국어": return "날카로운 족쇄";
                case "简体中文": return "尖刺镣铐";
                default: return "Barbed Shackles";
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

        ///<summary>spell=358774</summary>
        private static string BindingsOfMisery_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bindings of Misery";
                case "Deutsch": return "Bindungen des Elends";
                case "Español": return "Ataduras de miseria";
                case "Français": return "Liens de malheur";
                case "Italiano": return "Vincoli della Miseria";
                case "Português Brasileiro": return "Amarras do Sofrimento";
                case "Русский": return "Оковы скорби";
                case "한국어": return "괴로운 구속";
                case "简体中文": return "痛苦之链";
                default: return "Bindings of Misery";
            }
        }

        ///<summary>spell=184575</summary>
        private static string BladeOfJustice_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blade of Justice";
                case "Deutsch": return "Klinge der Gerechtigkeit";
                case "Español": return "Hoja de justicia";
                case "Français": return "Lame de justice";
                case "Italiano": return "Lama della Giustizia";
                case "Português Brasileiro": return "Lâmina da Justiça";
                case "Русский": return "Клинок справедливости";
                case "한국어": return "심판의 칼날";
                case "简体中文": return "公正之剑";
                default: return "Blade of Justice";
            }
        }

        ///<summary>spell=328622</summary>
        private static string BlessingOfAutumn_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blessing of Autumn";
                case "Deutsch": return "Segen des Herbstes";
                case "Español": return "Bendición de otoño";
                case "Français": return "Bénédiction de l’automne";
                case "Italiano": return "Benedizione dell'Autunno";
                case "Português Brasileiro": return "Bênção do Outono";
                case "Русский": return "Благословение осени";
                case "한국어": return "가을의 축복";
                case "简体中文": return "暮秋祝福";
                default: return "Blessing of Autumn";
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

        ///<summary>spell=328282</summary>
        private static string BlessingOfSpring_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blessing of Spring";
                case "Deutsch": return "Segen des Frühlings";
                case "Español": return "Bendición de primavera";
                case "Français": return "Bénédiction du printemps";
                case "Italiano": return "Benedizione della Primavera";
                case "Português Brasileiro": return "Bênção da Primavera";
                case "Русский": return "Благословение весны";
                case "한국어": return "봄의 축복";
                case "简体中文": return "阳春祝福";
                default: return "Blessing of Spring";
            }
        }

        ///<summary>spell=328620</summary>
        private static string BlessingOfSummer_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blessing of Summer";
                case "Deutsch": return "Segen des Sommers";
                case "Español": return "Bendición de verano";
                case "Français": return "Bénédiction de l’été";
                case "Italiano": return "Benedizione dell'Estate";
                case "Português Brasileiro": return "Bênção do Verão";
                case "Русский": return "Благословение лета";
                case "한국어": return "여름의 축복";
                case "简体中文": return "仲夏祝福";
                default: return "Blessing of Summer";
            }
        }

        ///<summary>spell=328281</summary>
        private static string BlessingOfWinter_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blessing of Winter";
                case "Deutsch": return "Segen des Winters";
                case "Español": return "Bendición de invierno";
                case "Français": return "Bénédiction de l’hiver";
                case "Italiano": return "Benedizione dell'Inverno";
                case "Português Brasileiro": return "Bênção do Inverno";
                case "Русский": return "Благословение зимы";
                case "한국어": return "겨울의 축복";
                case "简体中文": return "凛冬祝福";
                default: return "Blessing of Winter";
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

        ///<summary>spell=231895</summary>
        private static string Crusade_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Crusade";
                case "Deutsch": return "Kreuzzug";
                case "Español": return "Cruzada";
                case "Français": return "Croisade";
                case "Italiano": return "Crociata";
                case "Português Brasileiro": return "Cruzada";
                case "Русский": return "Священная война";
                case "한국어": return "성전";
                case "简体中文": return "征伐";
                default: return "Crusade";
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

        ///<summary>spell=198034</summary>
        private static string DivineHammer_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Divine Hammer";
                case "Deutsch": return "Göttlicher Hammer";
                case "Español": return "Martillo divino";
                case "Français": return "Marteau divin";
                case "Italiano": return "Martello Divino";
                case "Português Brasileiro": return "Martelo Divino";
                case "Русский": return "Божественный молот";
                case "한국어": return "천상의 망치";
                case "简体中文": return "神圣之锤";
                default: return "Divine Hammer";
            }
        }

        ///<summary>spell=498</summary>
        private static string DivineProtection_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Divine Protection";
                case "Deutsch": return "Göttlicher Schutz";
                case "Español": return "Protección divina";
                case "Français": return "Protection divine";
                case "Italiano": return "Protezione Divina";
                case "Português Brasileiro": return "Proteção Divina";
                case "Русский": return "Божественная защита";
                case "한국어": return "신의 가호";
                case "简体中文": return "圣佑术";
                default: return "Divine Protection";
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

        ///<summary>spell=53385</summary>
        private static string DivineStorm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Divine Storm";
                case "Deutsch": return "Göttlicher Sturm";
                case "Español": return "Tormenta divina";
                case "Français": return "Tempête divine";
                case "Italiano": return "Tempesta Divina";
                case "Português Brasileiro": return "Tempestade Divina";
                case "Русский": return "Божественная буря";
                case "한국어": return "천상의 폭풍";
                case "简体中文": return "神圣风暴";
                default: return "Divine Storm";
            }
        }

        ///<summary>spell=304971</summary>
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

        ///<summary>spell=343527</summary>
        private static string ExecutionSentence_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Execution Sentence";
                case "Deutsch": return "Todesurteil";
                case "Español": return "Sentencia de ejecución";
                case "Français": return "Condamnation à mort";
                case "Italiano": return "Sentenza d'Esecuzione";
                case "Português Brasileiro": return "Pena de Morte";
                case "Русский": return "Смертный приговор";
                case "한국어": return "사형 선고";
                case "简体中文": return "处决宣判";
                default: return "Execution Sentence";
            }
        }

        ///<summary>spell=383185</summary>
        private static string Exorcism_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Exorcism";
                case "Deutsch": return "Exorzismus";
                case "Español": return "Exorcismo";
                case "Français": return "Exorcisme";
                case "Italiano": return "Esorcismo";
                case "Português Brasileiro": return "Exorcismo";
                case "Русский": return "Экзорцизм";
                case "한국어": return "퇴마술";
                case "简体中文": return "驱邪术";
                default: return "Exorcism";
            }
        }

        ///<summary>spell=205191</summary>
        private static string EyeForAnEye_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Eye for an Eye";
                case "Deutsch": return "Auge um Auge";
                case "Español": return "Ojo por ojo";
                case "Français": return "Œil pour œil";
                case "Italiano": return "Occhio per Occhio";
                case "Português Brasileiro": return "Olho por Olho";
                case "Русский": return "Око за око";
                case "한국어": return "눈에는 눈";
                case "简体中文": return "以眼还眼";
                default: return "Eye for an Eye";
            }
        }

        ///<summary>spell=343721</summary>
        private static string FinalReckoning_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Final Reckoning";
                case "Deutsch": return "Letzte Abrechnung";
                case "Español": return "Juicio definitivo";
                case "Français": return "Rétorsion finale";
                case "Italiano": return "Regolamento di Conti Finale";
                case "Português Brasileiro": return "Ajuste de Contas Final";
                case "Русский": return "Последний расчет";
                case "한국어": return "최후의 집행";
                case "简体中文": return "最终清算";
                default: return "Final Reckoning";
            }
        }

        ///<summary>spell=383328</summary>
        private static string FinalVerdict_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Final Verdict";
                case "Deutsch": return "Letztes Urteil";
                case "Español": return "Veredicto final";
                case "Français": return "Verdict final";
                case "Italiano": return "Verdetto Finale";
                case "Português Brasileiro": return "Veredito Final";
                case "Русский": return "Окончательный приговор";
                case "한국어": return "최후의 선고";
                case "简体中文": return "最终审判";
                default: return "Final Verdict";
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

        ///<summary>spell=19750</summary>
        private static string FlashOfLight_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Flash of Light";
                case "Deutsch": return "Lichtblitz";
                case "Español": return "Destello de Luz";
                case "Français": return "Éclair lumineux";
                case "Italiano": return "Lampo di Luce";
                case "Português Brasileiro": return "Clarão de Luz";
                case "Русский": return "Вспышка Света";
                case "한국어": return "빛의 섬광";
                case "简体中文": return "圣光闪现";
                default: return "Flash of Light";
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

        ///<summary>spell=328180</summary>
        private static string GrippingInfection_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Gripping Infection";
                case "Deutsch": return "Packende Infektion";
                case "Español": return "Infección atenazante";
                case "Français": return "Infection enveloppante";
                case "Italiano": return "Infezione Avvinghiante";
                case "Português Brasileiro": return "Infecção Dominante";
                case "Русский": return "Цепкая инфекция";
                case "한국어": return "옭아매는 감염";
                case "简体中文": return "攫握感染";
                default: return "Gripping Infection";
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

        ///<summary>spell=215661</summary>
        private static string JusticarsVengeance_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Justicar's Vengeance";
                case "Deutsch": return "Rache des Rechtsprechers";
                case "Español": return "Venganza de justicar";
                case "Français": return "Vengeance du justicier";
                case "Italiano": return "Vendetta del Giustiziere";
                case "Português Brasileiro": return "Vingança do Justicar";
                case "Русский": return "Отмщение вершителя правосудия";
                case "한국어": return "심판관의 복수";
                case "简体中文": return "审判官复仇";
                default: return "Justicar's Vengeance";
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

        ///<summary>spell=384052</summary>
        private static string RadiantDecree_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Radiant Decree";
                case "Deutsch": return "Strahlender Erlass";
                case "Español": return "Decreto radiante";
                case "Français": return "Décret radieux";
                case "Italiano": return "Decreto Radioso";
                case "Português Brasileiro": return "Decreto Radiante";
                case "Русский": return "Светозарный указ";
                case "한국어": return "광휘의 칙령";
                case "简体中文": return "光辉敕令";
                default: return "Radiant Decree";
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

        ///<summary>spell=85804</summary>
        private static string SelflessHealer_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Selfless Healer";
                case "Deutsch": return "Selbstloser Heiler";
                case "Español": return "Sanación desinteresada";
                case "Français": return "Soigneur altruiste";
                case "Italiano": return "Guaritore Altruista";
                case "Português Brasileiro": return "Curador Abnegado";
                case "Русский": return "Самоотверженный целитель";
                case "한국어": return "관대한 치유사";
                case "简体中文": return "无私治愈";
                default: return "Selfless Healer";
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

        ///<summary>spell=184662</summary>
        private static string ShieldOfVengeance_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shield of Vengeance";
                case "Deutsch": return "Schild der Vergeltung";
                case "Español": return "Escudo de venganza";
                case "Français": return "Bouclier du vengeur";
                case "Italiano": return "Scudo della Vendetta";
                case "Português Brasileiro": return "Escudo de Vingança";
                case "Русский": return "Щит возмездия";
                case "한국어": return "복수의 방패";
                case "简体中文": return "复仇之盾";
                default: return "Shield of Vengeance";
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

        ///<summary>spell=406647</summary>
        private static string TemplarSlash_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Templar Slash";
                case "Deutsch": return "Templerschlitzer";
                case "Español": return "Tajo de templario";
                case "Français": return "Taillade du templier";
                case "Italiano": return "Fendente del Templare";
                case "Português Brasileiro": return "Talho Templário";
                case "Русский": return "Резкий удар храмовника";
                case "한국어": return "기사단의 베기";
                case "简体中文": return "圣殿骑士斩击";
                default: return "Templar Slash";
            }
        }

        ///<summary>spell=407480</summary>
        private static string TemplarStrike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Templar Strike";
                case "Deutsch": return "Templerstoß";
                case "Español": return "Golpe de templario";
                case "Français": return "Frappe du templier";
                case "Italiano": return "Assalto del Templare";
                case "Português Brasileiro": return "Golpe Templário";
                case "Русский": return "Удары храмовника";
                case "한국어": return "기사단의 공세";
                case "简体中文": return "圣殿骑士打击";
                default: return "Templar Strike";
            }
        }

        ///<summary>spell=85256</summary>
        private static string TemplarsVerdict_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Templar's Verdict";
                case "Deutsch": return "Urteil des Templers";
                case "Español": return "Veredicto del templario";
                case "Français": return "Verdict du templier";
                case "Italiano": return "Verdetto dei Templari";
                case "Português Brasileiro": return "Veredito do Templário";
                case "Русский": return "Вердикт храмовника";
                case "한국어": return "기사단의 선고";
                case "简体中文": return "圣殿骑士的裁决";
                default: return "Templar's Verdict";
            }
        }

        ///<summary>spell=328204</summary>
        private static string VanquishersHammer_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Vanquisher's Hammer";
                case "Deutsch": return "Hammer des Bezwingers";
                case "Español": return "Martillo del vencedor";
                case "Français": return "Marteau du vainqueur";
                case "Italiano": return "Martello del Dominatore";
                case "Português Brasileiro": return "Martelo do Subjugador";
                case "Русский": return "Молот покорителя";
                case "한국어": return "제압자의 망치";
                case "简体中文": return "征服者之锤";
                default: return "Vanquisher's Hammer";
            }
        }

        ///<summary>spell=255937</summary>
        private static string WakeOfAshes_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Wake of Ashes";
                case "Deutsch": return "Aschewelle";
                case "Español": return "Estela de cenizas";
                case "Français": return "Traînée de cendres";
                case "Italiano": return "Scia di Ceneri";
                case "Português Brasileiro": return "Rastro de Cinzas";
                case "Русский": return "Испепеляющий след";
                case "한국어": return "파멸의 재";
                case "简体中文": return "灰烬觉醒";
                default: return "Wake of Ashes";
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
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle", "NoCleanse", "FinalReckoning", "BlessingofFreedom", "BlessingofProtection", "BlessingofSacrifice", "DivineShield", "AshenHallow", "HammerofJustice", "BlindingLight", "Repentance", "DivineSteed", "WordofGlory", "IntercessionMO" };
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

        public string FrozenBinds()
        {
            if ((Aimsharp.CastingID("target") == 320788 || Aimsharp.CastingID("target") == 323730) && Aimsharp.CustomFunction("TargetingParty") == 5)
                return "player";

            if ((Aimsharp.CastingID("target") == 320788 || Aimsharp.CastingID("target") == 323730) && Aimsharp.CustomFunction("TargetingParty") == 1)
                return "party1";

            if ((Aimsharp.CastingID("target") == 320788 || Aimsharp.CastingID("target") == 323730) && Aimsharp.CustomFunction("TargetingParty") == 2)
                return "party2";

            if ((Aimsharp.CastingID("target") == 320788 || Aimsharp.CastingID("target") == 323730) && Aimsharp.CustomFunction("TargetingParty") == 3)
                return "party3";

            if ((Aimsharp.CastingID("target") == 320788 || Aimsharp.CastingID("target") == 323730) && Aimsharp.CustomFunction("TargetingParty") == 4)
                return "party4";

            return "NONE";
        }

        public string Carnage()
        {
            if ((Aimsharp.CastingID("target") == 356925 || Aimsharp.CastingID("target") == 356924) && Aimsharp.CustomFunction("TargetingParty") == 5)
                return "player";

            if ((Aimsharp.CastingID("target") == 356925 || Aimsharp.CastingID("target") == 356924) && Aimsharp.CustomFunction("TargetingParty") == 1)
                return "party1";

            if ((Aimsharp.CastingID("target") == 356925 || Aimsharp.CastingID("target") == 356924) && Aimsharp.CustomFunction("TargetingParty") == 2)
                return "party2";

            if ((Aimsharp.CastingID("target") == 356925 || Aimsharp.CastingID("target") == 356924) && Aimsharp.CustomFunction("TargetingParty") == 3)
                return "party3";

            if ((Aimsharp.CastingID("target") == 356925 || Aimsharp.CastingID("target") == 356924) && Aimsharp.CustomFunction("TargetingParty") == 4)
                return "party4";

            return "NONE";
        }
        #endregion

        #region CanCasts

        #endregion

        #region Debuffs
        public int UnitDebuffFreedomPriority(string unit)
        {
            if (Aimsharp.HasDebuff(GrippingInfection_SpellName(Language), unit, false))
                return Aimsharp.DebuffRemaining(GrippingInfection_SpellName(Language), unit, false);

            if (Aimsharp.HasDebuff(BarbedShackles_SpellName(Language), unit, false))
                return Aimsharp.DebuffRemaining(BarbedShackles_SpellName(Language), unit, false);

            if (Aimsharp.HasDebuff(BindingsOfMisery_SpellName(Language), unit, false) && unit == "player")
                return Aimsharp.DebuffRemaining(BindingsOfMisery_SpellName(Language), unit, false);

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
            Macros.Add("Weapon", "/use 16");

            //Healthstone
            Macros.Add("UseHealthstone", "/use " + Healthstone_SpellName(Language));

            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + Aimsharp.Latency);

            //Focus Units
            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");

            //Focus Spells
            Macros.Add("CT_FOC", "/cast [@focus] " + CleanseToxins_SpellName(Language));
            Macros.Add("FOL_FOC", "/cast [@focus] " + FlashOfLight_SpellName(Language));
            Macros.Add("WOG_FOC", "/cast [@focus] " + WordOfGlory_SpellName(Language));
            Macros.Add("LOH_FOC", "/cast [@focus] " + LayOnHands_SpellName(Language));
            Macros.Add("BOS_FOC", "/cast [@focus] " + BlessingOfSacrifice_SpellName(Language));
            Macros.Add("BOF_FOC", "/cast [@focus] " + BlessingOfFreedom_SpellName(Language));
            Macros.Add("BOP_FOC", "/cast [@focus] " + BlessingOfProtection_SpellName(Language));

            //Queues
            Macros.Add("FinalReckoningOff", "/" + FiveLetters + " FinalReckoning");
            Macros.Add("FinalReckoningC", "/cast [@cursor] " + FinalReckoning_SpellName(Language));
            Macros.Add("FinalReckoningP", "/cast [@player] " + FinalReckoning_SpellName(Language));

            Macros.Add("AshenHallowOff", "/" + FiveLetters + " AshenHallow");
            Macros.Add("AshenHallowC", "/cast [@cursor] " + AshenHallow_SpellName(Language));
            Macros.Add("AshenHallowP", "/cast [@player] " + AshenHallow_SpellName(Language));

            Macros.Add("BlessingofFreedomOff", "/" + FiveLetters + " BlessingofFreedom");
            Macros.Add("BlessingofFreedomMO", "/cast [@mouseover] " + BlessingOfFreedom_SpellName(Language));

            Macros.Add("BlessingofProtectionOff", "/" + FiveLetters + " BlessingofProtection");
            Macros.Add("BlessingofProtectionMO", "/cast [@mouseover] " + BlessingOfProtection_SpellName(Language));

            Macros.Add("BlessingofSacrificeOff", "/" + FiveLetters + " BlessingofSacrifice");
            Macros.Add("BlessingofSacrificeMO", "/cast [@mouseover] " + BlessingOfSacrifice_SpellName(Language));

            Macros.Add("DivineShieldOff", "/" + FiveLetters + " DivineShield");
            Macros.Add("DivineSteedOff", "/" + FiveLetters + " DivineSteed");
            Macros.Add("HammerofJusticeOff", "/" + FiveLetters + " HammerofJustice");
            Macros.Add("BlindingLightOff", "/" + FiveLetters + " BlindingLight");
            Macros.Add("RepentanceOff", "/" + FiveLetters + " Repentance");

            Macros.Add("RepentanceMO", "/cast [@mouseover] " + Repentance_SpellName(Language));

            Macros.Add("IntercessionMOMacro", "/cast [@mouseover] " + Intercession_SpellName(Language));
            Macros.Add("IntercessionOff", "/" + FiveLetters + " Intercession");

            Macros.Add("DivineToll", "/cast " + DivineToll_SpellName(Language));

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

            CustomFunctions.Add("CycleNotEnabled", "local cycle = 0 if Hekili.State.settings.spec.cycle == true then cycle = 1 else if Hekili.State.settings.spec.cycle == false then cycle = 2 end end return cycle");

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

            CustomFunctions.Add("TargetingParty", "local result = 0" +
            "\nif UnitExists('target') and UnitIsUnit('targettarget','party1') then result = 1 end" +
            "\nif UnitExists('target') and UnitIsUnit('targettarget','party2') then result = 2 end" +
            "\nif UnitExists('target') and UnitIsUnit('targettarget','party3') then result = 3 end" +
            "\nif UnitExists('target') and UnitIsUnit('targettarget','party4') then result = 4 end" +
            "\nif UnitExists('target') and UnitIsUnit('targettarget','player') then result = 5 end" +
            "\nreturn result");
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
            Settings.Add(new Setting("Auto Divine Shield @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Lay on Hands @ HP%", 0, 100, 20));
            Settings.Add(new Setting("Auto Shield of Vengeance @ HP%", 0, 100, 50));
            Settings.Add(new Setting("Auto Divine Protection @ HP%", 0, 100, 50));
            Settings.Add(new Setting("Auto Word of Glory @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Auto Selfless Healer @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Final Reckoning Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Ashen Hallow Cast:", m_CastingList, "Manual"));
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

            Aimsharp.PrintMessage("Epic PVE - Paladin Retribution", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/paladin/retribution/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCleanse - Disables Cleanse", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FinalReckoning - Casts Final Reckoning @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " AshenHallow - Casts Ashen Hallow @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " DivineShield - Casts Divine Shield @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BlindingLight - Casts Blinding Light @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " HammerofJustice - Casts Hammer of Justice @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " IntercessionMO - Casts Intercession @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Repentance - Casts Repentance @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " DivineSteed - Casts Divine Steed @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " WordofGlory - Enables Word of Glory as a Spender based on HP%", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BlessingofFreedom - Casts Blessing of Freedom @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BlessingofProtection - Casts Blessing of Protection @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BlessingofSacrifice - Casts Blessing of Sacrifice @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("Please apply an Aura yourself!", Color.White);

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

            #region ReinitializeLists
            m_DebuffsList = new List<string> { GrippingInfection_SpellName(Language), BarbedShackles_SpellName(Language), BindingsOfMisery_SpellName(Language), };
            m_BuffsList = new List<string> { SelflessHealer_SpellName(Language), ShieldOfVengeance_SpellName(Language), DivineSteed_SpellName(Language), };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language) };
            m_SpellBook_General = new List<string> {
                //Covenants
                DivineToll_SpellName(Language), //304971, 375576
                AshenHallow_SpellName(Language), //316958
                VanquishersHammer_SpellName(Language), //328204
                BlessingOfSummer_SpellName(Language), //328620
                BlessingOfAutumn_SpellName(Language), //328622
                BlessingOfWinter_SpellName(Language), //328281
                BlessingOfSpring_SpellName(Language), //328282

                //Interrupt
                Rebuke_SpellName(Language), //96231

                //General
                AvengingWrath_SpellName(Language), //31884, 384376
                BlessingOfFreedom_SpellName(Language), //1044
                BlessingOfProtection_SpellName(Language), //1022
                BlessingOfSacrifice_SpellName(Language), //6940
                Consecration_SpellName(Language), //26573
                CrusaderStrike_SpellName(Language), //35395
                DivineShield_SpellName(Language), //642
                DivineSteed_SpellName(Language), //190784
                FlashOfLight_SpellName(Language), //19750
                HammerOfJustice_SpellName(Language), //853
                HammerOfWrath_SpellName(Language), //24275
                Intercession_SpellName(Language), //391054
                Judgment_SpellName(Language), //20271
                LayOnHands_SpellName(Language), //633
                TemplarsVerdict_SpellName(Language), //85256
                WordOfGlory_SpellName(Language), //85673

                //Retribution
                BladeOfJustice_SpellName(Language), //184575
                BlindingLight_SpellName(Language), //115750
                CleanseToxins_SpellName(Language), //213644
                Crusade_SpellName(Language), //231895
                DivineHammer_SpellName(Language), //198034
                DivineProtection_SpellName(Language), //498
                DivineStorm_SpellName(Language), //53385
                ExecutionSentence_SpellName(Language), //343527
                Exorcism_SpellName(Language), //383185
                EyeForAnEye_SpellName(Language), //205191
                FinalReckoning_SpellName(Language), //343721
                FinalVerdict_SpellName(Language), //383328
                HolyAvenger_SpellName(Language), //105809
                JusticarsVengeance_SpellName(Language), //215661
                RadiantDecree_SpellName(Language), //384052
                Repentance_SpellName(Language), //20066
                Seraphim_SpellName(Language), //152262
                ShieldOfVengeance_SpellName(Language), //184662
                TemplarSlash_SpellName(Language), //406647
                TemplarStrike_SpellName(Language), //407480
                WakeOfAshes_SpellName(Language), //255937

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

            int DivineShieldHP = GetSlider("Auto Divine Shield @ HP%");
            int LayonHandsHP = GetSlider("Auto Lay on Hands @ HP%");
            int ShieldofVengeanceHP = GetSlider("Auto Shield of Vengeance @ HP%");
            int DivineProtectionHP = GetSlider("Auto Divine Protection @ HP%");
            int WordofGloryHP = GetSlider("Auto Word of Glory @ HP%");
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

            if (Aimsharp.IsCustomCodeOn("FinalReckoning") && Aimsharp.SpellCooldown(FinalReckoning_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("AshenHallow") && Aimsharp.SpellCooldown(AshenHallow_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                    KickValueRandom = KickValue + GetRandomNumber(200, 800);
                    KickChannelsAfterRandom = KickChannelsAfter + GetRandomNumber(200, 800);
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
            //Auto Frozen Binds Freedom
            if (FrozenBinds() != "NONE")
            {
                if (Aimsharp.CanCast(BlessingOfFreedom_SpellName(Language), FrozenBinds(), false, true) && (FrozenBinds() == "player" || Aimsharp.Range(FrozenBinds()) <= 40))
                {
                    if (!UnitFocus(FrozenBinds()))
                    {
                        Aimsharp.Cast("FOC_" + FrozenBinds(), true);
                        return true;
                    }
                    else
                    {
                        if (UnitFocus(FrozenBinds()))
                        {
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Blessing of Freedom @ " + FrozenBinds() + " - Frozen Binds", Color.Purple);
                            }
                            Aimsharp.Cast("BOF_FOC");
                            return true;
                        }
                    }
                }
            }

            //Auto Carnage Protection
            if (Carnage() != "NONE")
            {
                if (Aimsharp.CanCast(BlessingOfProtection_SpellName(Language), Carnage(), false, true) && (Carnage() == "player" || Aimsharp.Range(Carnage()) <= 40))
                {
                    if (!UnitFocus(Carnage()))
                    {
                        Aimsharp.Cast("FOC_" + Carnage(), true);
                        return true;
                    }
                    else
                    {
                        if (UnitFocus(Carnage()))
                        {
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Blessing of Protection @ " + Carnage() + " - Carnage", Color.Purple);
                            }
                            Aimsharp.Cast("BOP_FOC");
                            return true;
                        }
                    }
                }
            }

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

            #region Special Freedom
            if ((UnitDebuffFreedomPriority("player") > 0 || UnitDebuffFreedomPriority("party1") > 0 || UnitDebuffFreedomPriority("party2") > 0 || UnitDebuffFreedomPriority("party3") > 0 || UnitDebuffFreedomPriority("party4") > 0) && Aimsharp.GroupSize() <= 5)
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

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    if (Aimsharp.CanCast(BlessingOfFreedom_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && UnitDebuffFreedomPriority(unit.Key) > 0)
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
                                Aimsharp.Cast("BOF_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Blessing of Freedom @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Selfless Healer
            if (UnitBelowThreshold(GetSlider("Auto Selfless Healer @ HP%")) && Aimsharp.BuffStacks(SelflessHealer_SpellName(Language), "player", true) >= 4)
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
                    if (Aimsharp.CanCast(FlashOfLight_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && Aimsharp.Health(unit.Key) <= GetSlider("Auto Selfless Healer @ HP%"))
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
                                Aimsharp.Cast("FOL_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Flash of Light @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Word of Glory
            if (Aimsharp.IsCustomCodeOn("WordofGlory") && UnitBelowThreshold(GetSlider("Auto Word of Glory @ HP%")) && Aimsharp.CanCast(WordOfGlory_SpellName(Language), "player", false, true))
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
                    if (Aimsharp.CanCast(WordOfGlory_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && Aimsharp.Health(unit.Key) <= GetSlider("Auto Word of Glory @ HP%"))
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
                        if (Aimsharp.Health(partyunit) > 0 && Aimsharp.Range(partyunit) <= 40)
                        {
                            PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                        }
                    }
                }

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    if (Aimsharp.CanCast(LayOnHands_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && Aimsharp.Health(unit.Key) <= GetSlider("Auto Lay on Hands @ HP%"))
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

            //Auto Shield of Vengeance
            if (PlayerHP <= ShieldofVengeanceHP && Aimsharp.CanCast(ShieldOfVengeance_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Shield of Vengeance - Player HP% " + PlayerHP + " due to setting being on HP% " + ShieldofVengeanceHP, Color.Purple);
                }
                Aimsharp.Cast(ShieldOfVengeance_SpellName(Language));
                return true;
            }

            //Auto Divine Protection
            if (PlayerHP <= DivineProtectionHP && Aimsharp.CanCast(DivineProtection_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Divine Protection - Player HP% " + PlayerHP + " due to setting being on HP% " + DivineProtectionHP, Color.Purple);
                }
                Aimsharp.Cast(DivineProtection_SpellName(Language));
                return true;
            }

            #region Shield of Vengeance Sacrifice
            if (Aimsharp.HasBuff(ShieldOfVengeance_SpellName(Language), "player", true) && Aimsharp.BuffRemaining(ShieldOfVengeance_SpellName(Language), "player", true) >= 12000 && Aimsharp.SpellCooldown(BlessingOfSacrifice_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.GroupSize() <= 5)
            {
                var partysize = Aimsharp.GroupSize();
                var tank = "NONE";
                for (int i = 1; i < partysize; i++)
                {
                    var partyunit = ("party" + i);
                    if (Aimsharp.Health(partyunit) > 0 && Aimsharp.Range(partyunit) <= 40 && Aimsharp.GetSpec(partyunit) == "TANK")
                    {
                        tank = partyunit;
                    }
                }

                if (Aimsharp.CanCast(BlessingOfSacrifice_SpellName(Language), tank, true, true) && tank != "NONE")
                {
                    if (!UnitFocus(tank))
                    {
                        Aimsharp.Cast("FOC_" + tank, true);
                        return true;
                    }
                    else
                    {
                        if (UnitFocus(tank))
                        {
                            Aimsharp.Cast("BOS_FOC");
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Blessing of Sacrifice @ " + tank + " - " + Aimsharp.Health(tank), Color.Purple);
                            }
                            return true;
                        }
                    }
                }
            }
            #endregion
            #endregion

            #region Queues
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

            bool Repentance = Aimsharp.IsCustomCodeOn(Repentance_SpellName(Language));
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

            bool BlindingLight = Aimsharp.IsCustomCodeOn("BlindingLight");
            if (Aimsharp.SpellCooldown(BlindingLight_SpellName(Language)) - Aimsharp.GCD() > 2000 && BlindingLight)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blinding Light Queue", Color.Purple);
                }
                Aimsharp.Cast("BlindingLightOff");
                return true;
            }

            if (BlindingLight && Aimsharp.CanCast(BlindingLight_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blinding Light - Queue", Color.Purple);
                }
                Aimsharp.Cast(BlindingLight_SpellName(Language));
                return true;
            }

            bool DivineSteed = Aimsharp.IsCustomCodeOn("DivineSteed");
            if (DivineSteed && Aimsharp.HasBuff(DivineSteed_SpellName(Language), "player", true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Divine Steed queue toggle", Color.Purple);
                }
                Aimsharp.Cast("DivineSteedOff");
                return true;
            }

            if (DivineSteed && Aimsharp.CanCast(DivineSteed_SpellName(Language), "player", false, true) && !Aimsharp.HasBuff(DivineSteed_SpellName(Language), "player", true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Divine Steed - Queue", Color.Purple);
                }
                Aimsharp.Cast(DivineSteed_SpellName(Language));
                return true;
            }

            bool DivineShield = Aimsharp.IsCustomCodeOn("DivineShield");
            if (Aimsharp.SpellCooldown(DivineShield_SpellName(Language)) - Aimsharp.GCD() > 2000 && DivineShield)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Divine Shield Queue", Color.Purple);
                }
                Aimsharp.Cast("DivineShieldOff");
                return true;
            }

            if (DivineShield && Aimsharp.CanCast(DivineShield_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Divine Shield - Queue", Color.Purple);
                }
                Aimsharp.Cast(DivineShield_SpellName(Language));
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

            string AshenHallowCast = GetDropDown("Ashen Hallow Cast:");
            bool AshenHallow = Aimsharp.IsCustomCodeOn("AshenHallow");
            if (Aimsharp.SpellCooldown(AshenHallow_SpellName(Language)) - Aimsharp.GCD() > 2000 && AshenHallow)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Ashen Hallow Queue", Color.Purple);
                }
                Aimsharp.Cast("AshenHallowOff");
                return true;
            }

            if (AshenHallow && Aimsharp.CanCast(AshenHallow_SpellName(Language), "player", false, true) && (AshenHallowCast != "Player" || AshenHallowCast == "Player" && Aimsharp.Range("target") <= 3))
            {
                switch (AshenHallowCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(AshenHallow_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("AshenHallowC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("AshenHallowP");
                        return true;
                }
            }

            string FinalReckoningCast = GetDropDown("Final Reckoning Cast:");
            bool FinalReckoning = Aimsharp.IsCustomCodeOn("FinalReckoning");
            if (Aimsharp.SpellCooldown(FinalReckoning_SpellName(Language)) - Aimsharp.GCD() > 2000 && FinalReckoning)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Final Reckoning Queue", Color.Purple);
                }
                Aimsharp.Cast("FinalReckoningOff");
                return true;
            }

            if (FinalReckoning && Aimsharp.CanCast(FinalReckoning_SpellName(Language), "player", false, true) && (FinalReckoningCast != "Player" || FinalReckoningCast == "Player" && Aimsharp.Range("target") <= 3))
            {
                switch (FinalReckoningCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(FinalReckoning_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FinalReckoningC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FinalReckoningP");
                        return true;
                }
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
                    if (Aimsharp.Health(partyunit) > 0 && Aimsharp.Range(partyunit) <= 40)
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
                    if (Aimsharp.CanCast(CleanseToxins_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
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

            #region Auto Target
            //Hekili Cycle
            if (!NoCycle && Aimsharp.CustomFunction("CycleNotEnabled") == 1 && Aimsharp.CustomFunction("HekiliCycle") == 1 && EnemiesInMelee > 1)
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

                #endregion

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

                    if ((SpellID1 == 28730 || SpellID1 == 25046 || SpellID1 == 50613 || SpellID1 == 69179 || SpellID1 == 80483 || SpellID1 == 129597 || SpellID1 == 155145) && Aimsharp.CanCast(ArcaneTorrent_SpellName(Language), "player", true, false) && MeleeRange)
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
                    if ((SpellID1 == 304971 || SpellID1 == 375576) && Aimsharp.CanCast(DivineToll_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Divine Toll - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("DivineToll");
                        return true;
                    }

                    if (SpellID1 == 316958 && Aimsharp.CanCast(AshenHallow_SpellName(Language), "player", false, true))
                    {
                        switch (AshenHallowCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast(AshenHallow_SpellName(Language));
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("AshenHallowC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("AshenHallowP");
                                return true;
                        }
                    }

                    if (SpellID1 == 328204 && Aimsharp.CanCast(VanquishersHammer_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vanquisher's Hammer - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(VanquishersHammer_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 328620 && Aimsharp.CanCast(BlessingOfSummer_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blessing of Summer - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BlessingOfSummer_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 328622 && Aimsharp.CanCast(BlessingOfAutumn_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blessing of Autumn - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BlessingOfAutumn_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 328281 && Aimsharp.CanCast(BlessingOfWinter_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blessing of Winter - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BlessingOfWinter_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 328282 && Aimsharp.CanCast(BlessingOfSpring_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blessing of Spring - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BlessingOfSpring_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - NoGCD
                    if (SpellID1 == 96231 && Aimsharp.CanCast(Rebuke_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rebuke - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Rebuke_SpellName(Language), true);
                        return true;
                    }

                    if ((SpellID1 == 31884 || SpellID1 == 384376) && Aimsharp.CanCast(AvengingWrath_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Avenging Wrath - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AvengingWrath_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    if (SpellID1 == 642 && Aimsharp.CanCast(DivineShield_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Divine Shield - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DivineShield_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 2645 && Aimsharp.CanCast(BlessingOfFreedom_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blessing of Freedom - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BlessingOfFreedom_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 26573 && Aimsharp.CanCast(Consecration_SpellName(Language), "player", false, true) && MeleeRange && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Consecration - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Consecration_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    if (SpellID1 == 35395 && Aimsharp.CanCast(CrusaderStrike_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Crusader Strike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(CrusaderStrike_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 24275 && Aimsharp.CanCast(HammerOfWrath_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Hammer of Wrath - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(HammerOfWrath_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 20271 && Aimsharp.CanCast(Judgment_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Judgment - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Judgment_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 383185 && Aimsharp.CanCast(Exorcism_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Exorcism - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Exorcism_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Retribution Spells - Player GCD
                    if (SpellID1 == 343721 && Aimsharp.CanCast(FinalReckoning_SpellName(Language), "player", false, true) && (FinalReckoningCast != "Player" || FinalReckoningCast == "Player" && Aimsharp.Range("target") <= 3))
                    {
                        switch (FinalReckoningCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast(FinalReckoning_SpellName(Language));
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("FinalReckoningC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("FinalReckoningP");
                                return true;
                        }
                    }

                    if (SpellID1 == 231895 && Aimsharp.CanCast(Crusade_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Crusade - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Crusade_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 152262 && Aimsharp.CanCast(Seraphim_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Seraphim - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Seraphim_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 105809 && Aimsharp.CanCast(HolyAvenger_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Holy Avenger - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(HolyAvenger_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 184662 && Aimsharp.CanCast(ShieldOfVengeance_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shield of Vengeance - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ShieldOfVengeance_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 498 && Aimsharp.CanCast(DivineProtection_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Divine Protection - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DivineProtection_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 205191 && Aimsharp.CanCast(EyeForAnEye_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Eye for an Eye - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(EyeForAnEye_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 53385 && Aimsharp.CanCast(DivineStorm_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 3)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Divine Storm - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DivineStorm_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 255937 && Aimsharp.CanCast(WakeOfAshes_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wake of Ashes - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WakeOfAshes_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 384052 || SpellID1 == 255937 || SpellID1 == 383469) && Aimsharp.CanCast(RadiantDecree_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Radiant Decree - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RadiantDecree_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Retribution Spells - Target GCD
                    if (SpellID1 == 215661 && Aimsharp.CanCast(JusticarsVengeance_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Justicar's Vengeance - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(JusticarsVengeance_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 184575 && Aimsharp.CanCast(BladeOfJustice_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blade of Justice - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BladeOfJustice_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 85256 && Aimsharp.CanCast(TemplarsVerdict_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Templar's Verdict - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TemplarsVerdict_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 336872 || SpellID1 == 383328) && Aimsharp.CanCast(FinalVerdict_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Final Verdict - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FinalVerdict_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 343527 && Aimsharp.CanCast(ExecutionSentence_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Execution Sentence - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ExecutionSentence_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 407480 && Aimsharp.CanCast(TemplarStrike_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Templar Strike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TemplarStrike_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 406647 && Aimsharp.CanCast(TemplarSlash_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Templar Slash - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TemplarSlash_SpellName(Language));
                        return true;
                    }
                    if (SpellID1 == 198034 && Aimsharp.CanCast(DivineHammer_SpellName(Language), "player", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Divine Hammer - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DivineHammer_SpellName(Language));
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

            if (Aimsharp.IsCustomCodeOn("FinalReckoning") && Aimsharp.SpellCooldown(FinalReckoning_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("AshenHallow") && Aimsharp.SpellCooldown(AshenHallow_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
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

            bool Repentance = Aimsharp.IsCustomCodeOn(Repentance_SpellName(Language));
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

            bool BlindingLight = Aimsharp.IsCustomCodeOn("BlindingLight");
            if (Aimsharp.SpellCooldown(BlindingLight_SpellName(Language)) - Aimsharp.GCD() > 2000 && BlindingLight)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Blinding Light Queue", Color.Purple);
                }
                Aimsharp.Cast("BlindingLightOff");
                return true;
            }

            if (BlindingLight && Aimsharp.CanCast(BlindingLight_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blinding Light - Queue", Color.Purple);
                }
                Aimsharp.Cast(BlindingLight_SpellName(Language));
                return true;
            }

            bool DivineSteed = Aimsharp.IsCustomCodeOn("DivineSteed");
            if (DivineSteed && Aimsharp.HasBuff(DivineSteed_SpellName(Language), "player", true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Divine Steed queue toggle", Color.Purple);
                }
                Aimsharp.Cast("DivineSteedOff");
                return true;
            }

            if (DivineSteed && Aimsharp.CanCast(DivineSteed_SpellName(Language), "player", false, true) && !Aimsharp.HasBuff(DivineSteed_SpellName(Language), "player", true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Divine Steed - Queue", Color.Purple);
                }
                Aimsharp.Cast(DivineSteed_SpellName(Language));
                return true;
            }

            bool DivineShield = Aimsharp.IsCustomCodeOn("DivineShield");
            if (Aimsharp.SpellCooldown(DivineShield_SpellName(Language)) - Aimsharp.GCD() > 2000 && DivineShield)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Divine Shield Queue", Color.Purple);
                }
                Aimsharp.Cast("DivineShieldOff");
                return true;
            }

            if (DivineShield && Aimsharp.CanCast(DivineShield_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Divine Shield - Queue", Color.Purple);
                }
                Aimsharp.Cast(DivineShield_SpellName(Language));
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

            string AshenHallowCast = GetDropDown("Ashen Hallow Cast:");
            bool AshenHallow = Aimsharp.IsCustomCodeOn("AshenHallow");
            if (Aimsharp.SpellCooldown(AshenHallow_SpellName(Language)) - Aimsharp.GCD() > 2000 && AshenHallow)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Ashen Hallow Queue", Color.Purple);
                }
                Aimsharp.Cast("AshenHallowOff");
                return true;
            }

            if (AshenHallow && Aimsharp.CanCast(AshenHallow_SpellName(Language), "player", false, true) && (AshenHallowCast != "Player" || AshenHallowCast == "Player" && Aimsharp.Range("target") <= 3))
            {
                switch (AshenHallowCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(AshenHallow_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("AshenHallowC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ashen Hallow - " + AshenHallowCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("AshenHallowP");
                        return true;
                }
            }

            string FinalReckoningCast = GetDropDown("Final Reckoning Cast:");
            bool FinalReckoning = Aimsharp.IsCustomCodeOn("FinalReckoning");
            if (Aimsharp.SpellCooldown(FinalReckoning_SpellName(Language)) - Aimsharp.GCD() > 2000 && FinalReckoning)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Final Reckoning Queue", Color.Purple);
                }
                Aimsharp.Cast("FinalReckoningOff");
                return true;
            }

            if (FinalReckoning && Aimsharp.CanCast(FinalReckoning_SpellName(Language), "player", false, true) && (FinalReckoningCast != "Player" || FinalReckoningCast == "Player" && Aimsharp.Range("target") <= 3))
            {
                switch (FinalReckoningCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(FinalReckoning_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FinalReckoningC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Final Reckoning - " + FinalReckoningCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FinalReckoningP");
                        return true;
                }
            }
            #endregion

            #region Out of Combat Spells
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 10 && TargetInCombat)
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