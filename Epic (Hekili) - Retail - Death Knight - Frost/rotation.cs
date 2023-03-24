using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicDeathKnightFrostHekili : Rotation
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
        ///<summary>spell=315443</summary>
        private static string AbominationLimb_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Abomination Limb";
                case "Deutsch": return "Monströse Gliedmaße";
                case "Español": return "Extremidad abominable";
                case "Français": return "Membre abominable";
                case "Italiano": return "Arto di Abominio";
                case "Português Brasileiro": return "Membro da Abominação";
                case "Русский": return "Рука поганища";
                case "한국어": return "흉물 사지";
                case "简体中文": return "憎恶附肢";
                default: return "Abomination Limb";
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

        ///<summary>spell=48707</summary>
        private static string AntimagicShell_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Anti-Magic Shell";
                case "Deutsch": return "Antimagische Hülle";
                case "Español": return "Caparazón antimagia";
                case "Français": return "Carapace anti-magie";
                case "Italiano": return "Scudo Antimagia";
                case "Português Brasileiro": return "Carapaça Antimagia";
                case "Русский": return "Антимагический панцирь";
                case "한국어": return "대마법 보호막";
                case "简体中文": return "反魔法护罩";
                default: return "Anti-Magic Shell";
            }
        }

        ///<summary>spell=51052</summary>
        private static string AntimagicZone_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Anti-Magic Zone";
                case "Deutsch": return "Antimagisches Feld";
                case "Español": return "Zona antimagia";
                case "Français": return "Zone anti-magie";
                case "Italiano": return "Area Antimagia";
                case "Português Brasileiro": return "Zona Antimagia";
                case "Русский": return "Зона антимагии";
                case "한국어": return "대마법 지대";
                case "简体中文": return "反魔法领域";
                default: return "Anti-Magic Zone";
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

        ///<summary>spell=221562</summary>
        private static string Asphyxiate_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Asphyxiate";
                case "Deutsch": return "Ersticken";
                case "Español": return "Asfixiar";
                case "Français": return "Asphyxier";
                case "Italiano": return "Asfissia";
                case "Português Brasileiro": return "Asfixiar";
                case "Русский": return "Асфиксия";
                case "한국어": return "어둠의 질식";
                case "简体中文": return "窒息";
                default: return "Asphyxiate";
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

        ///<summary>spell=207167</summary>
        private static string BlindingSleet_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blinding Sleet";
                case "Deutsch": return "Blendender Eisregen";
                case "Español": return "Granizo cegador";
                case "Français": return "Grésil aveuglant";
                case "Italiano": return "Grandine Accecante";
                case "Português Brasileiro": return "Saraivada Cegante";
                case "Русский": return "Ослепляющая наледь";
                case "한국어": return "눈부신 진눈깨비";
                case "简体中文": return "致盲冰雨";
                default: return "Blinding Sleet";
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

        ///<summary>spell=152279</summary>
        private static string BreathOfSindragosa_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Breath of Sindragosa";
                case "Deutsch": return "Sindragosas Hauch";
                case "Español": return "Aliento de Sindragosa";
                case "Français": return "Souffle de Sindragosa";
                case "Italiano": return "Soffio di Sindragosa";
                case "Português Brasileiro": return "Sopro de Sindragosa";
                case "Русский": return "Дыхание Синдрагосы";
                case "한국어": return "신드라고사의 숨결";
                case "简体中文": return "冰龙吐息";
                default: return "Breath of Sindragosa";
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

        ///<summary>spell=45524</summary>
        private static string ChainsOfIce_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Chains of Ice";
                case "Deutsch": return "Eisketten";
                case "Español": return "Cadenas de hielo";
                case "Français": return "Chaînes de glace";
                case "Italiano": return "Catene di Ghiaccio";
                case "Português Brasileiro": return "Correntes de Gelo";
                case "Русский": return "Ледяные оковы";
                case "한국어": return "얼음 결계";
                case "简体中文": return "寒冰锁链";
                default: return "Chains of Ice";
            }
        }

        ///<summary>spell=305392</summary>
        private static string ChillStreak_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Chill Streak";
                case "Deutsch": return "Kettenunterkühlung";
                case "Español": return "Racha helada";
                case "Français": return "Séquence glaçante";
                case "Italiano": return "Serie Gelida";
                case "Português Brasileiro": return "Assalto Gélido";
                case "Русский": return "Поток холода";
                case "한국어": return "몰아치는 한기";
                case "简体中文": return "寒冰联结";
                default: return "Chill Streak";
            }
        }

        ///<summary>spell=111673</summary>
        private static string ControlUndead_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Control Undead";
                case "Deutsch": return "Untote kontrollieren";
                case "Español": return "Controlar no-muerto";
                case "Français": return "Asservir un mort-vivant";
                case "Italiano": return "Assoggetta Non Morto";
                case "Português Brasileiro": return "Controlar Morto-vivo";
                case "Русский": return "Порабощение нежити";
                case "한국어": return "언데드 지배";
                case "简体中文": return "控制亡灵";
                default: return "Control Undead";
            }
        }

        ///<summary>spell=56222</summary>
        private static string DarkCommand_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dark Command";
                case "Deutsch": return "Dunkler Befehl";
                case "Español": return "Orden oscura";
                case "Français": return "Sombre ordre";
                case "Italiano": return "Comando Oscuro";
                case "Português Brasileiro": return "Comando Sombrio";
                case "Русский": return "Темная власть";
                case "한국어": return "어둠의 명령";
                case "简体中文": return "黑暗命令";
                default: return "Dark Command";
            }
        }

        ///<summary>spell=43265</summary>
        private static string DeathAndDecay_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Death and Decay";
                case "Deutsch": return "Tod und Verfall";
                case "Español": return "Muerte y descomposición";
                case "Français": return "Mort et décomposition";
                case "Italiano": return "Morte e Distruzione";
                case "Português Brasileiro": return "Morte e Decomposição";
                case "Русский": return "Смерть и разложение";
                case "한국어": return "죽음과 부패";
                case "简体中文": return "枯萎凋零";
                default: return "Death and Decay";
            }
        }

        ///<summary>spell=47541</summary>
        private static string DeathCoil_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Death Coil";
                case "Deutsch": return "Todesmantel";
                case "Español": return "Espiral de la muerte";
                case "Français": return "Voile mortel";
                case "Italiano": return "Spira Mortale";
                case "Português Brasileiro": return "Espiral da Morte";
                case "Русский": return "Лик смерти";
                case "한국어": return "죽음의 고리";
                case "简体中文": return "凋零缠绕";
                default: return "Death Coil";
            }
        }

        ///<summary>spell=49576</summary>
        private static string DeathGrip_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Death Grip";
                case "Deutsch": return "Todesgriff";
                case "Español": return "Atracción letal";
                case "Français": return "Poigne de la mort";
                case "Italiano": return "Presa Mortale";
                case "Português Brasileiro": return "Garra da Morte";
                case "Русский": return "Хватка смерти";
                case "한국어": return "죽음의 손아귀";
                case "简体中文": return "死亡之握";
                default: return "Death Grip";
            }
        }

        ///<summary>spell=48743</summary>
        private static string DeathPact_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Death Pact";
                case "Deutsch": return "Todespakt";
                case "Español": return "Pacto de la Muerte";
                case "Français": return "Pacte mortel";
                case "Italiano": return "Patto con la Morte";
                case "Português Brasileiro": return "Pacto da Morte";
                case "Русский": return "Смертельный союз";
                case "한국어": return "죽음의 서약";
                case "简体中文": return "天灾契约";
                default: return "Death Pact";
            }
        }

        ///<summary>spell=49998</summary>
        private static string DeathStrike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Death Strike";
                case "Deutsch": return "Todesstoß";
                case "Español": return "Golpe letal";
                case "Français": return "Frappe de mort";
                case "Italiano": return "Assalto della Morte";
                case "Português Brasileiro": return "Golpe da Morte";
                case "Русский": return "Удар смерти";
                case "한국어": return "죽음의 일격";
                case "简体中文": return "灵界打击";
                default: return "Death Strike";
            }
        }

        ///<summary>spell=48265</summary>
        private static string DeathsAdvance_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Death's Advance";
                case "Deutsch": return "Unaufhaltsamer Tod";
                case "Español": return "Avance de la Muerte";
                case "Français": return "Avancée de la mort";
                case "Italiano": return "Ineluttabilità della Morte";
                case "Português Brasileiro": return "Avanço da Morte";
                case "Русский": return "Поступь смерти";
                case "한국어": return "죽음의 진군";
                case "简体中文": return "死亡脚步";
                default: return "Death's Advance";
            }
        }

        ///<summary>spell=324128</summary>
        private static string DeathsDue_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Death's Due";
                case "Deutsch": return "Recht des Todes";
                case "Español": return "Cuota de la muerte";
                case "Français": return "Dû de la mort";
                case "Italiano": return "Dovere della Morte";
                case "Português Brasileiro": return "Tributo da Morte";
                case "Русский": return "Дань смерти";
                case "한국어": return "죽음의 대가";
                case "简体中文": return "消亡之债";
                default: return "Death's Due";
            }
        }

        ///<summary>spell=152280</summary>
        private static string Defile_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Defile";
                case "Deutsch": return "Entweihen";
                case "Español": return "Profanar";
                case "Français": return "Profanation";
                case "Italiano": return "Profanazione";
                case "Português Brasileiro": return "Profanar";
                case "Русский": return "Осквернение";
                case "한국어": return "파멸";
                case "简体中文": return "亵渎";
                default: return "Defile";
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

        ///<summary>spell=47568</summary>
        private static string EmpowerRuneWeapon_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Empower Rune Weapon";
                case "Deutsch": return "Runenwaffe verstärken";
                case "Español": return "Potenciar arma de runas";
                case "Français": return "Renforcer l'arme runique";
                case "Italiano": return "Attivazione Runica";
                case "Português Brasileiro": return "Energizar Arma Rúnica";
                case "Русский": return "Усиление рунического оружия";
                case "한국어": return "룬 무기 강화";
                case "简体中文": return "符文武器增效";
                default: return "Empower Rune Weapon";
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

        ///<summary>spell=33395</summary>
        private static string Freeze_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Freeze";
                case "Deutsch": return "Eiskälte";
                case "Español": return "Congelar";
                case "Français": return "Gel";
                case "Italiano": return "Congelamento";
                case "Português Brasileiro": return "Congelamento";
                case "Русский": return "Холод";
                case "한국어": return "얼리기";
                case "简体中文": return "冰冻术";
                default: return "Freeze";
            }
        }

        ///<summary>spell=49143</summary>
        private static string FrostStrike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Frost Strike";
                case "Deutsch": return "Froststoß";
                case "Español": return "Golpe de Escarcha";
                case "Français": return "Frappe de givre";
                case "Italiano": return "Assalto del Gelo";
                case "Português Brasileiro": return "Golpe Gélido";
                case "Русский": return "Ледяной удар";
                case "한국어": return "냉기의 일격";
                case "简体中文": return "冰霜打击";
                default: return "Frost Strike";
            }
        }

        ///<summary>spell=207230</summary>
        private static string Frostscythe_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Frostscythe";
                case "Deutsch": return "Frostsichel";
                case "Español": return "Guadaña de Escarcha";
                case "Français": return "Faux de givre";
                case "Italiano": return "Falce del Signore del Gelo";
                case "Português Brasileiro": return "Foice Gélida";
                case "Русский": return "Ледяная коса";
                case "한국어": return "서리낫";
                case "简体中文": return "冰霜之镰";
                default: return "Frostscythe";
            }
        }

        ///<summary>spell=279302</summary>
        private static string FrostwyrmsFury_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Frostwyrm's Fury";
                case "Deutsch": return "Furor des Frostwyrms";
                case "Español": return "Furia de la vermis de escarcha";
                case "Français": return "Fureur du wyrm de givre";
                case "Italiano": return "Furia del Dragone del Gelo";
                case "Português Brasileiro": return "Fúria da Serpe Gélida";
                case "Русский": return "Ярость ледяного змея";
                case "한국어": return "서리고룡의 격노";
                case "简体中文": return "冰霜巨龙之怒";
                default: return "Frostwyrm's Fury";
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

        ///<summary>spell=194913</summary>
        private static string GlacialAdvance_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Glacial Advance";
                case "Deutsch": return "Unaufhaltbarer Gletscher";
                case "Español": return "Avance glacial";
                case "Français": return "Avancée glaciale";
                case "Italiano": return "Avanzata Glaciale";
                case "Português Brasileiro": return "Avanço Glacial";
                case "Русский": return "Ледяной натиск";
                case "한국어": return "빙하 진군";
                case "简体中文": return "冰川突进";
                default: return "Glacial Advance";
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

        ///<summary>spell=57330</summary>
        private static string HornOfWinter_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Horn of Winter";
                case "Deutsch": return "Horn des Winters";
                case "Español": return "Cuerno de invierno";
                case "Français": return "Cor de l’hiver";
                case "Italiano": return "Corno Invernale";
                case "Português Brasileiro": return "Berrante do Inverno";
                case "Русский": return "Зимний горн";
                case "한국어": return "겨울의 뿔피리";
                case "简体中文": return "寒冬号角";
                default: return "Horn of Winter";
            }
        }

        ///<summary>spell=49184</summary>
        private static string HowlingBlast_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Howling Blast";
                case "Deutsch": return "Heulende Böe";
                case "Español": return "Explosión aullante";
                case "Français": return "Rafale hurlante";
                case "Italiano": return "Folata Gelida";
                case "Português Brasileiro": return "Impacto Uivante";
                case "Русский": return "Воющий ветер";
                case "한국어": return "울부짖는 한파";
                case "简体中文": return "凛风冲击";
                default: return "Howling Blast";
            }
        }

        ///<summary>spell=48792</summary>
        private static string IceboundFortitude_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Icebound Fortitude";
                case "Deutsch": return "Eisige Gegenwehr";
                case "Español": return "Entereza ligada al hielo";
                case "Français": return "Robustesse glaciale";
                case "Italiano": return "Fermezza Glaciale";
                case "Português Brasileiro": return "Fortitude Congélida";
                case "Русский": return "Незыблемость льда";
                case "한국어": return "얼음같은 인내력";
                case "简体中文": return "冰封之韧";
                default: return "Icebound Fortitude";
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

        ///<summary>spell=49039</summary>
        private static string Lichborne_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Lichborne";
                case "Deutsch": return "Lichritter";
                case "Español": return "Exánime nato";
                case "Français": return "Changeliche";
                case "Italiano": return "Essenza del Lich";
                case "Português Brasileiro": return "Forma Decadente";
                case "Русский": return "Перерождение";
                case "한국어": return "리치의 혼";
                case "简体中文": return "巫妖之躯";
                default: return "Lichborne";
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

        ///<summary>spell=47528</summary>
        private static string MindFreeze_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mind Freeze";
                case "Deutsch": return "Gedankenfrost";
                case "Español": return "Helada mental";
                case "Français": return "Gel de l'esprit";
                case "Italiano": return "Gelo Mentale";
                case "Português Brasileiro": return "Congelar Mente";
                case "Русский": return "Заморозка разума";
                case "한국어": return "정신 얼리기";
                case "简体中文": return "心灵冰冻";
                default: return "Mind Freeze";
            }
        }

        ///<summary>spell=49020</summary>
        private static string Obliterate_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Obliterate";
                case "Deutsch": return "Auslöschen";
                case "Español": return "Asolar";
                case "Français": return "Anéantissement";
                case "Italiano": return "Disintegrazione";
                case "Português Brasileiro": return "Obliterar";
                case "Русский": return "Уничтожение";
                case "한국어": return "절멸";
                case "简体中文": return "湮灭";
                default: return "Obliterate";
            }
        }

        ///<summary>spell=51271</summary>
        private static string PillarOfFrost_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Pillar of Frost";
                case "Deutsch": return "Säule des Frosts";
                case "Español": return "Pilar de Escarcha";
                case "Français": return "Pilier de givre";
                case "Italiano": return "Pilastro di Ghiaccio";
                case "Português Brasileiro": return "Pilar de Gelo";
                case "Русский": return "Ледяной столп";
                case "한국어": return "얼음 기둥";
                case "简体中文": return "冰霜之柱";
                default: return "Pillar of Frost";
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

        ///<summary>spell=61999</summary>
        private static string RaiseAlly_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Raise Ally";
                case "Deutsch": return "Verbündeten erwecken";
                case "Español": return "Levantar a aliado";
                case "Français": return "Réanimation d'un allié";
                case "Italiano": return "Rianima Alleato";
                case "Português Brasileiro": return "Reviver Aliado";
                case "Русский": return "Воскрешение союзника";
                case "한국어": return "아군 되살리기";
                case "简体中文": return "复活盟友";
                default: return "Raise Ally";
            }
        }

        ///<summary>spell=46584</summary>
        private static string RaiseDead_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Raise Dead";
                case "Deutsch": return "Totenerweckung";
                case "Español": return "Levantar muerto";
                case "Français": return "Réanimation morbide";
                case "Italiano": return "Rianima Cadavere";
                case "Português Brasileiro": return "Reviver Morto";
                case "Русский": return "Воскрешение мертвых";
                case "한국어": return "시체 되살리기";
                case "简体中文": return "亡者复生";
                default: return "Raise Dead";
            }
        }

        ///<summary>spell=196770</summary>
        private static string RemorselessWinter_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Remorseless Winter";
                case "Deutsch": return "Unbarmherziger Winter";
                case "Español": return "Invierno sin remordimientos";
                case "Français": return "Hiver impitoyable";
                case "Italiano": return "Inverno Spietato";
                case "Português Brasileiro": return "Inverno Impiedoso";
                case "Русский": return "Беспощадность зимы";
                case "한국어": return "냉혹한 겨울";
                case "简体中文": return "冷酷严冬";
                default: return "Remorseless Winter";
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

        ///<summary>spell=316239</summary>
        private static string RuneStrike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rune Strike";
                case "Deutsch": return "Runenstoß";
                case "Español": return "Golpe de runa";
                case "Français": return "Frappe runique";
                case "Italiano": return "Assalto Runico";
                case "Português Brasileiro": return "Golpe Rúnico";
                case "Русский": return "Рунический удар";
                case "한국어": return "룬의 일격";
                case "简体中文": return "符文打击";
                default: return "Rune Strike";
            }
        }

        ///<summary>spell=327574</summary>
        private static string SacrificialPact_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sacrificial Pact";
                case "Deutsch": return "Opferpakt";
                case "Español": return "Sacrificio pactado";
                case "Français": return "Pacte sacrificiel";
                case "Italiano": return "Patto Sacrificale";
                case "Português Brasileiro": return "Pacto Sacrificial";
                case "Русский": return "Жертвенный договор";
                case "한국어": return "희생의 서약";
                case "简体中文": return "牺牲契约";
                default: return "Sacrificial Pact";
            }
        }

        ///<summary>spell=312202</summary>
        private static string ShackleTheUnworthy_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shackle the Unworthy";
                case "Deutsch": return "Fesseln der Unwürdigen";
                case "Español": return "Encadenar a los indignos";
                case "Français": return "Entrave d’indignité";
                case "Italiano": return "Incatenamento Immeritevoli";
                case "Português Brasileiro": return "Agrilhoar os Indignos";
                case "Русский": return "Узы недостойных";
                case "한국어": return "부덕한 자의 굴레";
                case "简体中文": return "失格者之梏";
                default: return "Shackle the Unworthy";
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

        ///<summary>spell=343294</summary>
        private static string SoulReaper_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Soul Reaper";
                case "Deutsch": return "Seelenernter";
                case "Español": return "Segador de almas";
                case "Français": return "Faucheur d’âme";
                case "Italiano": return "Mietitura dell'Anima";
                case "Português Brasileiro": return "Ceifador de Almas";
                case "Русский": return "Жнец душ";
                case "한국어": return "영혼 수확자";
                case "简体中文": return "灵魂收割";
                default: return "Soul Reaper";
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

        ///<summary>spell=311648</summary>
        private static string SwarmingMist_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Swarming Mist";
                case "Deutsch": return "Schwärmender Nebel";
                case "Español": return "Niebla enjambradora";
                case "Français": return "Brume écrasante";
                case "Italiano": return "Nebbia Sciamante";
                case "Português Brasileiro": return "Bruma Enxameante";
                case "Русский": return "Клубящийся туман";
                case "한국어": return "모여드는 안개";
                case "简体中文": return "云集之雾";
                default: return "Swarming Mist";
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

        ///<summary>spell=212552</summary>
        private static string WraithWalk_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Wraith Walk";
                case "Deutsch": return "Gespensterwanderung";
                case "Español": return "Paso espectral";
                case "Français": return "Marche spectrale";
                case "Italiano": return "Passo Spettrale";
                case "Português Brasileiro": return "Andar do Espectro";
                case "Русский": return "Блуждающий дух";
                case "한국어": return "망령 걸음";
                case "简体中文": return "幻影步";
                default: return "Wraith Walk";
            }
        }
        #endregion

        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle", "Asphyxiate", "RaiseAlly", "DeathandDecay", "DeathsDue", "AntiMagicZone", "BlindingSleet", };
        private List<string> m_DebuffsList;
        private List<string> m_BuffsList;
        private List<string> m_BloodlustBuffsList;
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
            Macros.Add("Weapon", "/use 16");

            //Healthstone
            Macros.Add("UseHealthstone", "/use " + Healthstone_SpellName(Language));


            //SpellQueueWindow
            Macros.Add("SetSpellQueueCvar", "/console SpellQueueWindow " + Aimsharp.Latency);

            //Queues
            Macros.Add("DeathandDecayOff", "/" + FiveLetters + " DeathandDecay");
            Macros.Add("RaiseAllyOff", "/" + FiveLetters + " RaiseAlly");
            Macros.Add("AsphyxiateOff", "/" + FiveLetters + " Asphyxiate");
            Macros.Add("DeathsDueOff", "/" + FiveLetters + " DeathsDue");
            Macros.Add("AntiMagicZoneOff", "/" + FiveLetters + " AntiMagicZone");
            Macros.Add("BlindingSleetOff", "/" + FiveLetters + " BlindingSleet");

            Macros.Add("RaiseAllyMO", "/cast [@mouseover] " + RaiseAlly_SpellName(Language));
            Macros.Add("DeathandDecayP", "/cast [@player] " + DeathAndDecay_SpellName(Language));
            Macros.Add("DeathandDecayC", "/cast [@cursor] " + DeathAndDecay_SpellName(Language));
            Macros.Add("DeathsDueP", "/cast [@player] " + DeathsDue_SpellName(Language));
            Macros.Add("DeathsDueC", "/cast [@cursor] " + DeathsDue_SpellName(Language));
            Macros.Add("AntiMagicZoneP", "/cast [@player] " + AntimagicZone_SpellName(Language));
            Macros.Add("AntiMagicZoneC", "/cast [@cursor] " + AntimagicZone_SpellName(Language));

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
            Settings.Add(new Setting("Auto Lichborne @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Auto Death Pact @ HP%", 0, 100, 30));
            Settings.Add(new Setting("Auto Anti-Magic Shell @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Sacrificial Pact @ HP%", 0, 100, 20));
            Settings.Add(new Setting("Auto Icebound Fortitude @ HP%", 0, 100, 30));
            Settings.Add(new Setting("Death and Decay Cast:", m_CastingList, "Player"));
            Settings.Add(new Setting("Anti-Magic Zone Cast:", m_CastingList, "Player"));
            Settings.Add(new Setting("Death's Due Cast:", m_CastingList, "Player"));
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

            Aimsharp.PrintMessage("Epic PVE - Death Knight Frost", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/death-knight/frost/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Asphyxiate - Casts Asphyxiate @ Target next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BlindingSleet - Casts Blinding Sleet @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " RaiseAlly - Casts Raise Ally @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " DeathandDecay - Casts Death and Decay @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " DeathsDue - Casts Death's Due @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " AntiMagicZone - Casts Anti-Magic Zone @ next GCD", Color.Yellow);
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
                AbominationLimb_SpellName(Language), //315443
                DeathsDue_SpellName(Language), //324128
                ShackleTheUnworthy_SpellName(Language), //312202
                SwarmingMist_SpellName(Language), //311648

                //Interrupt
                MindFreeze_SpellName(Language), //47528

                //General
                AntimagicShell_SpellName(Language), //48707
                AntimagicZone_SpellName(Language), //51052
                Asphyxiate_SpellName(Language), //221562
                BlindingSleet_SpellName(Language), //207167
                BreathOfSindragosa_SpellName(Language), //152279
                ChainsOfIce_SpellName(Language), //45524
                ChillStreak_SpellName(Language), //305392
                ControlUndead_SpellName(Language), //111673
                DarkCommand_SpellName(Language), //56222
                DeathAndDecay_SpellName(Language), //43265
                DeathCoil_SpellName(Language), //47541
                DeathGrip_SpellName(Language), //49576
                DeathPact_SpellName(Language), //48743
                DeathStrike_SpellName(Language), //49998
                DeathsAdvance_SpellName(Language), //48265
                Defile_SpellName(Language), //152280
                EmpowerRuneWeapon_SpellName(Language), //47568
                FrostStrike_SpellName(Language), //49143
                Frostscythe_SpellName(Language), //207230
                FrostwyrmsFury_SpellName(Language), //279302
                GlacialAdvance_SpellName(Language), //194913
                HornOfWinter_SpellName(Language), //57330
                HowlingBlast_SpellName(Language), //49184
                IceboundFortitude_SpellName(Language), //48792
                Lichborne_SpellName(Language), //49039
                Obliterate_SpellName(Language), //49020
                PillarOfFrost_SpellName(Language), //51271
                RaiseAlly_SpellName(Language), //61999
                RaiseDead_SpellName(Language), //46584
                RemorselessWinter_SpellName(Language), //196770
                RuneStrike_SpellName(Language), //316239
                SacrificialPact_SpellName(Language), //327574
                SoulReaper_SpellName(Language), //343294
                WraithWalk_SpellName(Language), //212552
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

            if (Aimsharp.IsCustomCodeOn("DeathandDecay") && Aimsharp.SpellCooldown(DeathAndDecay_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("DeathandDecay") && Aimsharp.SpellCooldown(Defile_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("DeathsDue") && Aimsharp.SpellCooldown(DeathsDue_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("AntiMagicZone") && Aimsharp.SpellCooldown(AntimagicZone_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                if (Aimsharp.CanCast(MindFreeze_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(MindFreeze_SpellName(Language), true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast(MindFreeze_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(MindFreeze_SpellName(Language), true);
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

            //Auto Death Pact
            if (Aimsharp.CanCast(DeathPact_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Death Pact @ HP%"))
                {
                    Aimsharp.Cast(DeathPact_SpellName(Language));
                    return true;
                }
            }

            //Auto Anti-Magic Shell
            if (Aimsharp.CanCast(AntimagicShell_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Anti-Magic Shell @ HP%"))
                {
                    Aimsharp.Cast(AntimagicShell_SpellName(Language), true);
                    return true;
                }
            }

            //Auto Lichborne
            if (Aimsharp.CanCast(Lichborne_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Lichborne @ HP%"))
                {
                    Aimsharp.Cast(Lichborne_SpellName(Language), true);
                    return true;
                }
            }

            //Auto Sacrificial Pact
            if (Aimsharp.CanCast(SacrificialPact_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Sacrificial Pact @ HP%"))
                {
                    Aimsharp.Cast(SacrificialPact_SpellName(Language), true);
                    return true;
                }
            }

            //Auto Icebound Fortitude
            if (Aimsharp.CanCast(IceboundFortitude_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Icebound Fortitude @ HP%"))
                {
                    Aimsharp.Cast(IceboundFortitude_SpellName(Language), true);
                    return true;
                }
            }
            #endregion

            #region Queues
            //Queues
            //Queue Asphyxiate
            bool Asphyxiate = Aimsharp.IsCustomCodeOn("Asphyxiate");
            if (Aimsharp.SpellCooldown(Asphyxiate_SpellName(Language)) - Aimsharp.GCD() > 2000 && Asphyxiate && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                Aimsharp.Cast("AsphyxiateOff");
                return true;
            }

            if (Asphyxiate && Aimsharp.CanCast(Asphyxiate_SpellName(Language), "target", true, true))
            {
                Aimsharp.Cast(Asphyxiate_SpellName(Language));
                return true;
            }

            //Queue Blinding Sleet
            bool BlindingSleet = Aimsharp.IsCustomCodeOn("BlindingSleet");
            if (Aimsharp.SpellCooldown(BlindingSleet_SpellName(Language)) - Aimsharp.GCD() > 2000 && BlindingSleet)
            {
                Aimsharp.Cast("BlindingSleetOff");
                return true;
            }

            if (BlindingSleet && Aimsharp.CanCast(BlindingSleet_SpellName(Language), "player", false, true))
            {
                Aimsharp.Cast(BlindingSleet_SpellName(Language));
                return true;
            }

            //Queue Raise Ally
            bool RaiseAlly = Aimsharp.IsCustomCodeOn("RaiseAlly");
            if (Aimsharp.SpellCooldown(RaiseAlly_SpellName(Language)) - Aimsharp.GCD() > 2000 && RaiseAlly)
            {
                Aimsharp.Cast("RaiseAllyOff");
                return true;
            }

            if (RaiseAlly && Aimsharp.CanCast(RaiseAlly_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("RaiseAllyMO");
                return true;
            }

            //Queue Death and Decay
            string DeathandDecayCast = GetDropDown("Death and Decay Cast:");
            bool DeathandDecay = Aimsharp.IsCustomCodeOn("DeathandDecay");
            if (Aimsharp.SpellCooldown(DeathAndDecay_SpellName(Language)) - Aimsharp.GCD() > 2000 && DeathandDecay)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Death and Decay Queue", Color.Purple);
                }
                Aimsharp.Cast("DeathandDecayOff");
                return true;
            }

            if (DeathandDecay && Aimsharp.CanCast(DeathAndDecay_SpellName(Language), "player", false, true))
            {
                switch (DeathandDecayCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Death and Decay - " + DeathandDecayCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(DeathAndDecay_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Death and Decay - " + DeathandDecayCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DeathandDecayP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Death and Decay - " + DeathandDecayCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DeathandDecayC");
                        return true;
                }
            }

            //Queue Death's Due
            string DeathsDueCast = GetDropDown("Death's Due Cast:");
            bool DeathsDue = Aimsharp.IsCustomCodeOn("DeathsDue");
            if (Aimsharp.SpellCooldown(DeathsDue_SpellName(Language)) - Aimsharp.GCD() > 2000 && DeathsDue)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Death's Due Queue", Color.Purple);
                }
                Aimsharp.Cast("DeathsDueOff");
                return true;
            }

            if (DeathsDue && Aimsharp.CanCast(DeathsDue_SpellName(Language), "player", false, true))
            {
                switch (DeathsDueCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Death's Due - " + DeathsDueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(DeathsDue_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Death's Due - " + DeathsDueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DeathsDueP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Death's Due - " + DeathsDueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DeathsDueC");
                        return true;
                }
            }

            //Queue Anti-Magic Zone
            string AntiMagicZoneCast = GetDropDown("Anti-Magic Zone Cast:");
            bool AntiMagicZone = Aimsharp.IsCustomCodeOn("AntiMagicZone");
            if (Aimsharp.SpellCooldown(AntimagicZone_SpellName(Language)) - Aimsharp.GCD() > 2000 && AntiMagicZone)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Anti-Magic Zone Queue", Color.Purple);
                }
                Aimsharp.Cast("AntiMagicZoneOff");
                return true;
            }

            if (AntiMagicZone && Aimsharp.CanCast(AntimagicZone_SpellName(Language), "player", false, true))
            {
                switch (AntiMagicZoneCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Anti-Magic Zone - " + AntiMagicZoneCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(AntimagicZone_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Anti-Magic Zone - " + AntiMagicZoneCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("AntiMagicZoneP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Anti-Magic Zone - " + AntiMagicZoneCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("AntiMagicZoneC");
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
                    if (SpellID1 == 312202 && Aimsharp.CanCast(ShackleTheUnworthy_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(ShackleTheUnworthy_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 311648 && Aimsharp.CanCast(SwarmingMist_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(SwarmingMist_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 324128 && Aimsharp.CanCast(DeathsDue_SpellName(Language), "player", false, true))
                    {
                        switch (DeathsDueCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Death's Due - " + DeathsDueCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast(DeathsDue_SpellName(Language));
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Death's Due - " + DeathsDueCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("DeathsDueP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Death's Due - " + DeathsDueCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("DeathsDueC");
                                return true;
                        }
                    }

                    if ((SpellID1 == 315443 || SpellID1 == 383269) && Aimsharp.CanCast(AbominationLimb_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(AbominationLimb_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - NoGCD
                    //Class Spells
                    //Instant [GCD FREE]
                    if (SpellID1 == 47528 && Aimsharp.CanCast(MindFreeze_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(MindFreeze_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 48707 && Aimsharp.CanCast(AntimagicShell_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(AntimagicShell_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 48792 && Aimsharp.CanCast(IceboundFortitude_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(IceboundFortitude_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 49039 && Aimsharp.CanCast(Lichborne_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(Lichborne_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 56222 && Aimsharp.CanCast(DarkCommand_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(DarkCommand_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    //Instant [GCD]
                    ///Player
                    if ((SpellID1 == 152280 || SpellID1 == 43265) && Aimsharp.CanCast(DeathAndDecay_SpellName(Language), "player", false, true))
                    {
                        switch (DeathandDecayCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Death and Decay - " + DeathandDecayCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast(DeathAndDecay_SpellName(Language));
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Death and Decay - " + DeathandDecayCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("DeathandDecayP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Death and Decay - " + DeathandDecayCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("DeathandDecayC");
                                return true;
                        }
                    }

                    if (SpellID1 == 46585 && Aimsharp.CanCast(RaiseDead_SpellName(Language), "player", false, true) && !Moving)
                    {
                        Aimsharp.Cast(RaiseDead_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 111673 && Aimsharp.CanCast(ControlUndead_SpellName(Language), "player", false, true) && !Moving)
                    {
                        Aimsharp.Cast(ControlUndead_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 327574 && Aimsharp.CanCast(SacrificialPact_SpellName(Language), "player", true, true))
                    {
                        Aimsharp.Cast(SacrificialPact_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 212552 && Aimsharp.CanCast(WraithWalk_SpellName(Language), "player", true, true))
                    {
                        Aimsharp.Cast(WraithWalk_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    ///Target
                    if (SpellID1 == 47541 && Aimsharp.CanCast(DeathCoil_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(DeathCoil_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 108194 && Aimsharp.CanCast(Asphyxiate_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(Asphyxiate_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 45524 && Aimsharp.CanCast(ChainsOfIce_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(ChainsOfIce_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 49998 && Aimsharp.CanCast(DeathStrike_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(DeathStrike_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Frost Spells - Player GCD
                    ////Player
                    if (SpellID1 == 47568 && Aimsharp.CanCast(EmpowerRuneWeapon_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(EmpowerRuneWeapon_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 305392 && Aimsharp.CanCast(ChillStreak_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(ChillStreak_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 196770 && Aimsharp.CanCast(RemorselessWinter_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(RemorselessWinter_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 279302 && Aimsharp.CanCast(FrostwyrmsFury_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(FrostwyrmsFury_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 51271 && Aimsharp.CanCast(PillarOfFrost_SpellName(Language), "player", true, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(PillarOfFrost_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 57330 && Aimsharp.CanCast(HornOfWinter_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(HornOfWinter_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 207167 && Aimsharp.CanCast(BlindingSleet_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(BlindingSleet_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 207230 && Aimsharp.CanCast(Frostscythe_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(Frostscythe_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 343294 && Aimsharp.CanCast(SoulReaper_SpellName(Language), "player", false, true) && Aimsharp.Range("target") <= 5)
                    {
                        Aimsharp.Cast(SoulReaper_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 194913 && Aimsharp.CanCast(GlacialAdvance_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(GlacialAdvance_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 152279 && Aimsharp.CanCast(BreathOfSindragosa_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(BreathOfSindragosa_SpellName(Language));
                        return true;
                    }

                    #endregion

                    #region Frost Spells - Target GCD
                    ////Target
                    if (SpellID1 == 49020 && Aimsharp.CanCast(Obliterate_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(Obliterate_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 49143 && Aimsharp.CanCast(FrostStrike_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(FrostStrike_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 49184 && Aimsharp.CanCast(HowlingBlast_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(HowlingBlast_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 316239 && Aimsharp.CanCast(RuneStrike_SpellName(Language), "target", true, true))
                    {
                        Aimsharp.Cast(RuneStrike_SpellName(Language));
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

            if (Aimsharp.IsCustomCodeOn("DeathandDecay") && Aimsharp.SpellCooldown(DeathAndDecay_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("DeathandDecay") && Aimsharp.SpellCooldown(Defile_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("DeathsDue") && Aimsharp.SpellCooldown(DeathsDue_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("AntiMagicZone") && Aimsharp.SpellCooldown(AntimagicZone_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            //Queues
            //Queue Asphyxiate
            bool Asphyxiate = Aimsharp.IsCustomCodeOn("Asphyxiate");
            if (Aimsharp.SpellCooldown(Asphyxiate_SpellName(Language)) - Aimsharp.GCD() > 2000 && Asphyxiate && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                Aimsharp.Cast("AsphyxiateOff");
                return true;
            }

            if (Asphyxiate && Aimsharp.CanCast(Asphyxiate_SpellName(Language), "target", true, true))
            {
                Aimsharp.Cast(Asphyxiate_SpellName(Language));
                return true;
            }

            //Queue Blinding Sleet
            bool BlindingSleet = Aimsharp.IsCustomCodeOn("BlindingSleet");
            if (Aimsharp.SpellCooldown(BlindingSleet_SpellName(Language)) - Aimsharp.GCD() > 2000 && BlindingSleet)
            {
                Aimsharp.Cast("BlindingSleetOff");
                return true;
            }

            if (BlindingSleet && Aimsharp.CanCast(BlindingSleet_SpellName(Language), "player", false, true))
            {
                Aimsharp.Cast(BlindingSleet_SpellName(Language));
                return true;
            }

            //Queue Raise Ally
            bool RaiseAlly = Aimsharp.IsCustomCodeOn("RaiseAlly");
            if (Aimsharp.SpellCooldown(RaiseAlly_SpellName(Language)) - Aimsharp.GCD() > 2000 && RaiseAlly)
            {
                Aimsharp.Cast("RaiseAllyOff");
                return true;
            }

            if (RaiseAlly && Aimsharp.CanCast(RaiseAlly_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("RaiseAllyMO");
                return true;
            }

            //Queue Death and Decay
            string DeathandDecayCast = GetDropDown("Death and Decay Cast:");
            bool DeathandDecay = Aimsharp.IsCustomCodeOn("DeathandDecay");
            if (Aimsharp.SpellCooldown(DeathAndDecay_SpellName(Language)) - Aimsharp.GCD() > 2000 && DeathandDecay)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Death and Decay Queue", Color.Purple);
                }
                Aimsharp.Cast("DeathandDecayOff");
                return true;
            }

            if (DeathandDecay && Aimsharp.CanCast(DeathAndDecay_SpellName(Language), "player", false, true))
            {
                switch (DeathandDecayCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Death and Decay - " + DeathandDecayCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(DeathAndDecay_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Death and Decay - " + DeathandDecayCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DeathandDecayP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Death and Decay - " + DeathandDecayCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DeathandDecayC");
                        return true;
                }
            }

            //Queue Death's Due
            string DeathsDueCast = GetDropDown("Death's Due Cast:");
            bool DeathsDue = Aimsharp.IsCustomCodeOn("DeathsDue");
            if (Aimsharp.SpellCooldown(DeathsDue_SpellName(Language)) - Aimsharp.GCD() > 2000 && DeathsDue)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Death's Due Queue", Color.Purple);
                }
                Aimsharp.Cast("DeathsDueOff");
                return true;
            }

            if (DeathsDue && Aimsharp.CanCast(DeathsDue_SpellName(Language), "player", false, true))
            {
                switch (DeathsDueCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Death's Due - " + DeathsDueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(DeathsDue_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Death's Due - " + DeathsDueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DeathsDueP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Death's Due - " + DeathsDueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DeathsDueC");
                        return true;
                }
            }

            //Queue Anti-Magic Zone
            string AntiMagicZoneCast = GetDropDown("Anti-Magic Zone Cast:");
            bool AntiMagicZone = Aimsharp.IsCustomCodeOn("AntiMagicZone");
            if (Aimsharp.SpellCooldown(AntimagicZone_SpellName(Language)) - Aimsharp.GCD() > 2000 && AntiMagicZone)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Anti-Magic Zone Queue", Color.Purple);
                }
                Aimsharp.Cast("AntiMagicZoneOff");
                return true;
            }

            if (AntiMagicZone && Aimsharp.CanCast(AntimagicZone_SpellName(Language), "player", false, true))
            {
                switch (AntiMagicZoneCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Anti-Magic Zone - " + AntiMagicZoneCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(AntimagicZone_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Anti-Magic Zone - " + AntiMagicZoneCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("AntiMagicZoneP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Anti-Magic Zone - " + AntiMagicZoneCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("AntiMagicZoneC");
                        return true;
                }
            }
            #endregion

            #region Out of Combat Spells
            if (SpellID1 == 46585 && Aimsharp.CanCast(RaiseDead_SpellName(Language), "player", false, true) && !Moving)
            {
                Aimsharp.Cast(RaiseDead_SpellName(Language));
                return true;
            }
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