using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicMageFireHekili : Rotation
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
        ///<summary>spell=342245</summary>
        private static string AlterTime_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Alter Time";
                case "Deutsch": return "Zeitverschiebung";
                case "Español": return "Alterar el tiempo";
                case "Français": return "Altérer le temps";
                case "Italiano": return "Alterazione Temporale";
                case "Português Brasileiro": return "Alterar Tempo";
                case "Русский": return "Манипуляции со временем";
                case "한국어": return "시간 돌리기";
                case "简体中文": return "操控时间";
                default: return "Alter Time";
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

        ///<summary>spell=1449</summary>
        private static string ArcaneExplosion_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Arcane Explosion";
                case "Deutsch": return "Arkane Explosion";
                case "Español": return "Deflagración Arcana";
                case "Français": return "Explosion des Arcanes";
                case "Italiano": return "Esplosione Arcana";
                case "Português Brasileiro": return "Explosão Arcana";
                case "Русский": return "Чародейский взрыв";
                case "한국어": return "신비한 폭발";
                case "简体中文": return "魔爆术";
                default: return "Arcane Explosion";
            }
        }

        ///<summary>spell=1459</summary>
        private static string ArcaneIntellect_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Arcane Intellect";
                case "Deutsch": return "Arkane Intelligenz";
                case "Español": return "Intelecto Arcano";
                case "Français": return "Intelligence des Arcanes";
                case "Italiano": return "Intelletto Arcano";
                case "Português Brasileiro": return "Intelecto Arcano";
                case "Русский": return "Чародейский интеллект";
                case "한국어": return "신비한 지능";
                case "简体中文": return "奥术智慧";
                default: return "Arcane Intellect";
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

        ///<summary>spell=157981</summary>
        private static string BlastWave_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blast Wave";
                case "Deutsch": return "Druckwelle";
                case "Español": return "Ola explosiva";
                case "Français": return "Vague explosive";
                case "Italiano": return "Ondata di Fuoco";
                case "Português Brasileiro": return "Onda de Impacto";
                case "Русский": return "Взрывная волна";
                case "한국어": return "화염 폭풍";
                case "简体中文": return "冲击波";
                default: return "Blast Wave";
            }
        }

        ///<summary>spell=235313</summary>
        private static string BlazingBarrier_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blazing Barrier";
                case "Deutsch": return "Lodernde Barriere";
                case "Español": return "Barrera llameante";
                case "Français": return "Barrière flamboyante";
                case "Italiano": return "Barriera Fiammeggiante";
                case "Português Brasileiro": return "Barreira Fulgurante";
                case "Русский": return "Пылающая преграда";
                case "한국어": return "이글거리는 방벽";
                case "简体中文": return "烈焰护体";
                default: return "Blazing Barrier";
            }
        }

        ///<summary>spell=1953</summary>
        private static string Blink_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blink";
                case "Deutsch": return "Blinzeln";
                case "Español": return "Traslación";
                case "Français": return "Transfert";
                case "Italiano": return "Traslazione";
                case "Português Brasileiro": return "Lampejo";
                case "Русский": return "Скачок";
                case "한국어": return "점멸";
                case "简体中文": return "闪现术";
                default: return "Blink";
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

        ///<summary>spell=190319</summary>
        private static string Combustion_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Combustion";
                case "Deutsch": return "Einäschern";
                case "Español": return "Combustión";
                case "Français": return "Combustion";
                case "Italiano": return "Combustione";
                case "Português Brasileiro": return "Combustão";
                case "Русский": return "Возгорание";
                case "한국어": return "발화";
                case "简体中文": return "燃烧";
                default: return "Combustion";
            }
        }

        ///<summary>spell=120</summary>
        private static string ConeOfCold_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Cone of Cold";
                case "Deutsch": return "Kältekegel";
                case "Español": return "Cono de frío";
                case "Français": return "Cône de froid";
                case "Italiano": return "Cono di Freddo";
                case "Português Brasileiro": return "Cone de Frio";
                case "Русский": return "Конус холода";
                case "한국어": return "냉기 돌풍";
                case "简体中文": return "冰锥术";
                default: return "Cone of Cold";
            }
        }

        ///<summary>spell=2139</summary>
        private static string Counterspell_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Counterspell";
                case "Deutsch": return "Gegenzauber";
                case "Español": return "Contrahechizo";
                case "Français": return "Contresort";
                case "Italiano": return "Controincantesimo";
                case "Português Brasileiro": return "Contrafeitiço";
                case "Русский": return "Антимагия";
                case "한국어": return "마법 차단";
                case "简体中文": return "法术反制";
                default: return "Counterspell";
            }
        }

        ///<summary>spell=324220</summary>
        private static string Deathborne_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Deathborne";
                case "Deutsch": return "Todesgeboren";
                case "Español": return "Llevado por la muerte";
                case "Français": return "Portemort";
                case "Italiano": return "Stirpe della Morte";
                case "Português Brasileiro": return "Mortraz";
                case "Русский": return "Дитя смерти";
                case "한국어": return "죽음의 혈통";
                case "简体中文": return "死神之躯";
                default: return "Deathborne";
            }
        }

        ///<summary>spell=389713</summary>
        private static string Displacement_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Displacement";
                case "Deutsch": return "Verzerrung";
                case "Español": return "Desplazamiento";
                case "Français": return "Déplacement";
                case "Italiano": return "Dislocazione";
                case "Português Brasileiro": return "Deslocamento";
                case "Русский": return "Перемещение";
                case "한국어": return "변위";
                case "简体中文": return "闪回";
                default: return "Displacement";
            }
        }

        ///<summary>spell=31661</summary>
        private static string DragonsBreath_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dragon's Breath";
                case "Deutsch": return "Drachenodem";
                case "Español": return "Aliento de dragón";
                case "Français": return "Souffle du dragon";
                case "Italiano": return "Soffio del Drago";
                case "Português Brasileiro": return "Sopro do Dragão";
                case "Русский": return "Дыхание дракона";
                case "한국어": return "용의 숨결";
                case "简体中文": return "龙息术";
                default: return "Dragon's Breath";
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

        ///<summary>spell=12051</summary>
        private static string Evocation_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Evocation";
                case "Deutsch": return "Hervorrufung";
                case "Español": return "Evocación";
                case "Français": return "Evocation";
                case "Italiano": return "Evocazione";
                case "Português Brasileiro": return "Evocação";
                case "Русский": return "Прилив сил";
                case "한국어": return "환기";
                case "简体中文": return "唤醒";
                default: return "Evocation";
            }
        }

        ///<summary>spell=108853</summary>
        private static string FireBlast_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fire Blast";
                case "Deutsch": return "Feuerschlag";
                case "Español": return "Explosión de Fuego";
                case "Français": return "Trait de feu";
                case "Italiano": return "Detonazione di Fuoco";
                case "Português Brasileiro": return "Impacto de Fogo";
                case "Русский": return "Огненный взрыв";
                case "한국어": return "화염 작렬";
                case "简体中文": return "火焰冲击";
                default: return "Fire Blast";
            }
        }

        ///<summary>spell=133</summary>
        private static string Fireball_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fireball";
                case "Deutsch": return "Feuerball";
                case "Español": return "Bola de Fuego";
                case "Français": return "Boule de feu";
                case "Italiano": return "Palla di Fuoco";
                case "Português Brasileiro": return "Bola de Fogo";
                case "Русский": return "Огненный шар";
                case "한국어": return "화염구";
                case "简体中文": return "火球术";
                default: return "Fireball";
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

        ///<summary>spell=2120</summary>
        private static string Flamestrike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Flamestrike";
                case "Deutsch": return "Flammenstoß";
                case "Español": return "Fogonazo";
                case "Français": return "Choc de flammes";
                case "Italiano": return "Colonna di Fuoco";
                case "Português Brasileiro": return "Golpe Flamejante";
                case "Русский": return "Огненный столб";
                case "한국어": return "불기둥";
                case "简体中文": return "烈焰风暴";
                default: return "Flamestrike";
            }
        }

        ///<summary>spell=321358</summary>
        private static string FocusMagic_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Focus Magic";
                case "Deutsch": return "Magie fokussieren";
                case "Español": return "Enfocar magia";
                case "Français": return "Focalisation magique";
                case "Italiano": return "Magia Concentrata";
                case "Português Brasileiro": return "Concentrar Magia";
                case "Русский": return "Сосредоточение магии";
                case "한국어": return "마법 집중점";
                case "简体中文": return "专注魔法";
                default: return "Focus Magic";
            }
        }

        ///<summary>spell=122</summary>
        private static string FrostNova_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Frost Nova";
                case "Deutsch": return "Frostnova";
                case "Español": return "Nova de Escarcha";
                case "Français": return "Nova de givre";
                case "Italiano": return "Esplosione Gelida";
                case "Português Brasileiro": return "Nova Congelante";
                case "Русский": return "Кольцо льда";
                case "한국어": return "얼음 회오리";
                case "简体中文": return "冰霜新星";
                default: return "Frost Nova";
            }
        }

        ///<summary>spell=116</summary>
        private static string Frostbolt_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Frostbolt";
                case "Deutsch": return "Frostblitz";
                case "Español": return "Descarga de Escarcha";
                case "Français": return "Éclair de givre";
                case "Italiano": return "Dardo di Gelo";
                case "Português Brasileiro": return "Seta de Gelo";
                case "Русский": return "Ледяная стрела";
                case "한국어": return "얼음 화살";
                case "简体中文": return "寒冰箭";
                default: return "Frostbolt";
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

        ///<summary>spell=110959</summary>
        private static string GreaterInvisibility_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Greater Invisibility";
                case "Deutsch": return "Große Unsichtbarkeit";
                case "Español": return "Invisibilidad superior";
                case "Français": return "Invisibilité supérieure";
                case "Italiano": return "Invisibilità Superiore";
                case "Português Brasileiro": return "Invisibilidade Maior";
                case "Русский": return "Великая невидимость";
                case "한국어": return "상급 투명화";
                case "简体中文": return "强化隐形术";
                default: return "Greater Invisibility";
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

        ///<summary>spell=45438</summary>
        private static string IceBlock_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ice Block";
                case "Deutsch": return "Eisblock";
                case "Español": return "Bloque de hielo";
                case "Français": return "Bloc de glace";
                case "Italiano": return "Blocco di Ghiaccio";
                case "Português Brasileiro": return "Bloco de Gelo";
                case "Русский": return "Ледяная глыба";
                case "한국어": return "얼음 방패";
                case "简体中文": return "寒冰屏障";
                default: return "Ice Block";
            }
        }

        ///<summary>spell=108839</summary>
        private static string IceFloes_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ice Floes";
                case "Deutsch": return "Eisschollen";
                case "Español": return "Témpanos de hielo";
                case "Français": return "Iceberg";
                case "Italiano": return "Cuore di Ghiaccio";
                case "Português Brasileiro": return "Banquisas";
                case "Русский": return "Плавучая льдина";
                case "한국어": return "얼음발";
                case "简体中文": return "浮冰";
                default: return "Ice Floes";
            }
        }

        ///<summary>spell=157997</summary>
        private static string IceNova_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ice Nova";
                case "Deutsch": return "Eisnova";
                case "Español": return "Nova de hielo";
                case "Français": return "Nova de glace";
                case "Italiano": return "Esplosione di Ghiaccio";
                case "Português Brasileiro": return "Nova de Gelo";
                case "Русский": return "Кольцо обледенения";
                case "한국어": return "서리 회오리";
                case "简体中文": return "寒冰新星";
                default: return "Ice Nova";
            }
        }

        ///<summary>spell=66</summary>
        private static string Invisibility_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Invisibility";
                case "Deutsch": return "Unsichtbarkeit";
                case "Español": return "Invisibilidad";
                case "Français": return "Invisibilité";
                case "Italiano": return "Invisibilità";
                case "Português Brasileiro": return "Invisibilidade";
                case "Русский": return "Невидимость";
                case "한국어": return "투명화";
                case "简体中文": return "隐形术";
                default: return "Invisibility";
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

        ///<summary>spell=44457</summary>
        private static string LivingBomb_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Living Bomb";
                case "Deutsch": return "Lebende Bombe";
                case "Español": return "Bomba viva";
                case "Français": return "Bombe vivante";
                case "Italiano": return "Bomba Vivente";
                case "Português Brasileiro": return "Bomba Viva";
                case "Русский": return "Живая бомба";
                case "한국어": return "살아있는 폭탄";
                case "简体中文": return "活动炸弹";
                default: return "Living Bomb";
            }
        }

        ///<summary>spell=383121</summary>
        private static string MassPolymorph_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mass Polymorph";
                case "Deutsch": return "Massenverwandlung";
                case "Español": return "Polimorfia en masa";
                case "Français": return "Métamorphose de masse";
                case "Italiano": return "Metamorfosi di Massa";
                case "Português Brasileiro": return "Polimorfia em Massa";
                case "Русский": return "Массовое превращение";
                case "한국어": return "대규모 변이";
                case "简体中文": return "群体变形";
                default: return "Mass Polymorph";
            }
        }

        ///<summary>spell=153561</summary>
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
                case "Русский": return "Метеор";
                case "한국어": return "유성";
                case "简体中文": return "流星";
                default: return "Meteor";
            }
        }

        ///<summary>spell=55342</summary>
        private static string MirrorImage_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mirror Image";
                case "Deutsch": return "Spiegelbild";
                case "Español": return "Reflejo exacto";
                case "Français": return "Image miroir";
                case "Italiano": return "Immagine Speculare";
                case "Português Brasileiro": return "Imagem Espelhada";
                case "Русский": return "Зеркальное изображение";
                case "한국어": return "환영 복제";
                case "简体中文": return "镜像";
                default: return "Mirror Image";
            }
        }

        ///<summary>spell=314793</summary>
        private static string MirrorsOfTorment_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mirrors of Torment";
                case "Deutsch": return "Spiegel der Qual";
                case "Español": return "Espejos de tormento";
                case "Français": return "Miroirs de tourment";
                case "Italiano": return "Specchi del Tormento";
                case "Português Brasileiro": return "Espelhos do Tormento";
                case "Русский": return "Истязающие зеркала";
                case "한국어": return "고문의 거울";
                case "简体中文": return "折磨之镜";
                default: return "Mirrors of Torment";
            }
        }

        ///<summary>spell=257541</summary>
        private static string PhoenixFlames_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Phoenix Flames";
                case "Deutsch": return "Phönixflammen";
                case "Español": return "Llamas de fénix";
                case "Français": return "Flammes de phénix";
                case "Italiano": return "Fiamme della Fenice";
                case "Português Brasileiro": return "Chamas da Fênix";
                case "Русский": return "Пламя феникса";
                case "한국어": return "불사조의 불길";
                case "简体中文": return "不死鸟之焰";
                default: return "Phoenix Flames";
            }
        }

        ///<summary>spell=118</summary>
        private static string Polymorph_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Polymorph";
                case "Deutsch": return "Verwandlung";
                case "Español": return "Polimorfia";
                case "Français": return "Métamorphose";
                case "Italiano": return "Metamorfosi";
                case "Português Brasileiro": return "Polimorfia";
                case "Русский": return "Превращение";
                case "한국어": return "변이";
                case "简体中文": return "变形术";
                default: return "Polymorph";
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

        ///<summary>spell=11366</summary>
        private static string Pyroblast_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Pyroblast";
                case "Deutsch": return "Pyroschlag";
                case "Español": return "Piroexplosión";
                case "Français": return "Explosion pyrotechnique";
                case "Italiano": return "Pirosfera";
                case "Português Brasileiro": return "Ignimpacto";
                case "Русский": return "Огненная глыба";
                case "한국어": return "불덩이 작렬";
                case "简体中文": return "炎爆术";
                default: return "Pyroblast";
            }
        }

        ///<summary>spell=307443</summary>
        private static string RadiantSpark_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Radiant Spark";
                case "Deutsch": return "Strahlender Funke";
                case "Español": return "Chispa radiante";
                case "Français": return "Étincelle radieuse";
                case "Italiano": return "Scintilla Radiante";
                case "Português Brasileiro": return "Fagulha Radiante";
                case "Русский": return "Сияющая искра";
                case "한국어": return "빛나는 불꽃";
                case "简体中文": return "璀璨火花";
                default: return "Radiant Spark";
            }
        }

        ///<summary>spell=475</summary>
        private static string RemoveCurse_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Remove Curse";
                case "Deutsch": return "Fluch aufheben";
                case "Español": return "Eliminar maldición";
                case "Français": return "Délivrance de la malédiction";
                case "Italiano": return "Rimozione Maledizione";
                case "Português Brasileiro": return "Remover Maldição";
                case "Русский": return "Снятие проклятия";
                case "한국어": return "저주 해제";
                case "简体中文": return "解除诅咒";
                default: return "Remove Curse";
            }
        }

        ///<summary>spell=113724</summary>
        private static string RingOfFrost_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ring of Frost";
                case "Deutsch": return "Ring des Frosts";
                case "Español": return "Anillo de Escarcha";
                case "Français": return "Anneau de givre";
                case "Italiano": return "Anello di Ghiaccio";
                case "Português Brasileiro": return "Anel Gélido";
                case "Русский": return "Кольцо мороза";
                case "한국어": return "서리 고리";
                case "简体中文": return "冰霜之环";
                default: return "Ring of Frost";
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

        ///<summary>spell=116011</summary>
        private static string RuneOfPower_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rune of Power";
                case "Deutsch": return "Rune der Kraft";
                case "Español": return "Runa de poder";
                case "Français": return "Rune de puissance";
                case "Italiano": return "Runa del Potere";
                case "Português Brasileiro": return "Runa de Poder";
                case "Русский": return "Руна мощи";
                case "한국어": return "마력의 룬";
                case "简体中文": return "能量符文";
                default: return "Rune of Power";
            }
        }

        ///<summary>spell=2948</summary>
        private static string Scorch_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Scorch";
                case "Deutsch": return "Versengen";
                case "Español": return "Agostar";
                case "Français": return "Brûlure";
                case "Italiano": return "Bruciatura";
                case "Português Brasileiro": return "Calcinar";
                case "Русский": return "Ожог";
                case "한국어": return "불태우기";
                case "简体中文": return "灼烧";
                default: return "Scorch";
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

        ///<summary>spell=382440</summary>
        private static string ShiftingPower_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shifting Power";
                case "Deutsch": return "Machtverschiebung";
                case "Español": return "Poder cambiante";
                case "Français": return "Puissance fluctuante";
                case "Italiano": return "Potere Mutevole";
                case "Português Brasileiro": return "Poder Cambiante";
                case "Русский": return "Переходящая сила";
                case "한국어": return "힘의 전환";
                case "简体中文": return "变易幻能";
                default: return "Shifting Power";
            }
        }

        ///<summary>spell=130</summary>
        private static string SlowFall_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Slow Fall";
                case "Deutsch": return "Langsamer Fall";
                case "Español": return "Caída lenta";
                case "Français": return "Chute lente";
                case "Italiano": return "Caduta Lenta";
                case "Português Brasileiro": return "Queda Lenta";
                case "Русский": return "Замедленное падение";
                case "한국어": return "저속 낙하";
                case "简体中文": return "缓落术";
                default: return "Slow Fall";
            }
        }

        ///<summary>spell=30449</summary>
        private static string Spellsteal_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Spellsteal";
                case "Deutsch": return "Zauberraub";
                case "Español": return "Robar hechizo";
                case "Français": return "Vol de sort";
                case "Italiano": return "Ruba Incantesimo";
                case "Português Brasileiro": return "Roubar Feitiço";
                case "Русский": return "Чарокрад";
                case "한국어": return "마법 훔치기";
                case "简体中文": return "法术吸取";
                default: return "Spellsteal";
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
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoDecurse", "NoCycle", "Polymorph", "RingofFrost", "Flamestrike", "Meteor", "ArcaneExplosion", "FlamestrikeCursor", "NoSpellsteal" };
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

            //Queues
            Macros.Add("PolymorphOff", "/" + FiveLetters + " Polymorph");
            Macros.Add("RingofFrostOff", "/" + FiveLetters + " RingofFrost");
            Macros.Add("FlamestrikeOff", "/" + FiveLetters + " Flamestrike");
            Macros.Add("MeteorOff", "/" + FiveLetters + " Meteor");

            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");
            Macros.Add("RC_FOC", "/cast [@focus] " + RemoveCurse_SpellName(Language));

            Macros.Add("PolymorphMO", "/cast [@mouseover] " + Polymorph_SpellName(Language));
            Macros.Add("SpellstealMO", "/cast [@mouseover] " + Spellsteal_SpellName(Language));
            Macros.Add("RingofFrostC", "/cast [@cursor] RingofFrost");
            Macros.Add("FlamestrikeC", "/cast [@cursor] " + Flamestrike_SpellName(Language));
            Macros.Add("MeteorC", "/cast [@cursor] " + Meteor_SpellName(Language));
            Macros.Add("RingofFrostP", "/cast [@player] RingofFrost");
            Macros.Add("FlamestrikeP", "/cast [@player] " + Flamestrike_SpellName(Language));
            Macros.Add("MeteorP", "/cast [@player] " + Meteor_SpellName(Language));
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

            CustomFunctions.Add("FlamestrikeMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Fireball','mouseover') == 1 then return 1 end; return 0");

            CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
            "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
            "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
            "\nreturn foc");

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

            CustomFunctions.Add("SpellstealCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Spellsteal','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType,_,_,_,isStealable  = UnitAura('mouseover', y) if debuffType == 'Magic' and isStealable == true then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("SpellstealCheckTarget", "local markcheck = 0; if UnitExists('target') and UnitIsDead('target') ~= true and UnitAffectingCombat('target') and IsSpellInRange('Spellsteal','target') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType,_,_,_,isStealable  = UnitAura('target', y) if debuffType == 'Magic' and isStealable == true then markcheck = markcheck + 2 end end return markcheck end return 0");

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
            Settings.Add(new Setting("Arcane Intellect Out of Combat:", true));
            Settings.Add(new Setting("Auto Spellsteal Target:", true));
            Settings.Add(new Setting("Auto Spellsteal Mouseover:", true));
            Settings.Add(new Setting("Don't Spellsteal during Combustion:", true));
            Settings.Add(new Setting("Auto Ice Block @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Auto Alter Time @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Blazing Barrier @ HP%", 0, 100, 90));
            Settings.Add(new Setting("Auto Greater Invisibility @ HP%", 0, 100, 35));
            Settings.Add(new Setting("Ring of Frost Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Meteor Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Flamestrike Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Always Cast Flamestrike @ Cursor during Rotation", false));
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

            Aimsharp.PrintMessage("Epic PVE - Mage Fire", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/de/guide/classes/mage/fire/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoDecurse - Disables Decurse", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoSpellsteal - Disables Spellsteal", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Polymorph - Casts Polymorph @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " ArcaneExplosion - Spams Arcane Explosion until turned Off", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " RingofFrost - Casts Ring of Frost @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Flamestrike - Casts Flamestrike @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Meteor - Casts Meteor @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FlamestrikeCursor - Toggles Flamestrike always @ Cursor (same as Option)", Color.Yellow);
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
            m_DebuffsList = new List<string> { Polymorph_SpellName(Language), };
            m_BuffsList = new List<string> { ArcaneIntellect_SpellName(Language), ShiftingPower_SpellName(Language), Combustion_SpellName(Language) };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language), };
            m_SpellBook = new List<string> {
                //Covenants
                RadiantSpark_SpellName(Language), //307443
                Deathborne_SpellName(Language), //324220
                ShiftingPower_SpellName(Language), //314791, 382440
                MirrorsOfTorment_SpellName(Language), //314793

                //Interrupt
                Counterspell_SpellName(Language), //2139

                //General Mage
                AlterTime_SpellName(Language), //342245
                ArcaneExplosion_SpellName(Language), //1449
                ArcaneIntellect_SpellName(Language), //1459
                BlazingBarrier_SpellName(Language), //235313
                BlastWave_SpellName(Language), //157981
                Blink_SpellName(Language), //1953 or 212653
                ConeOfCold_SpellName(Language), //120
                Displacement_SpellName(Language), //389713
                DragonsBreath_SpellName(Language), //31661
                Fireball_SpellName(Language), //133
                FireBlast_SpellName(Language), //108853
                FrostNova_SpellName(Language), //122
                Frostbolt_SpellName(Language), //116
                GreaterInvisibility_SpellName(Language), //110959
                IceBlock_SpellName(Language), //45438
                IceFloes_SpellName(Language), //108839
                IceNova_SpellName(Language), //157997
                Invisibility_SpellName(Language), //66
                MassPolymorph_SpellName(Language), //383121
                Meteor_SpellName(Language), //153561
                MirrorImage_SpellName(Language), //55342
                Polymorph_SpellName(Language), //118
                RemoveCurse_SpellName(Language), //475
                RingOfFrost_SpellName(Language), //113724
                RuneOfPower_SpellName(Language), //116011
                SlowFall_SpellName(Language), //130
                Spellsteal_SpellName(Language), //30449
                TimeWarp_SpellName(Language), //80353

                //Fire Mage
                Combustion_SpellName(Language), //190319
                Flamestrike_SpellName(Language), //2120
                FocusMagic_SpellName(Language), //321358
                LivingBomb_SpellName(Language), //44457
                PhoenixFlames_SpellName(Language), //257541
                Pyroblast_SpellName(Language), //11366
                Scorch_SpellName(Language), //2948
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
            bool NoDecurse = Aimsharp.IsCustomCodeOn("NoDecurse");
            bool NoCycle = Aimsharp.IsCustomCodeOn("NoCycle");
            bool NoSpellsteal = Aimsharp.IsCustomCodeOn("NoSpellsteal");

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

            #region Above Pause Logic
            if (SpellID1 == 108853 && Aimsharp.CanCast(FireBlast_SpellName(Language), "target", true, false) && Aimsharp.CustomFunction("HekiliWait") <= 200)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fire Blast - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(FireBlast_SpellName(Language), true);
                return true;
            }

            if (SpellID1 == 190319 && Aimsharp.CanCast(Combustion_SpellName(Language), "player", false, false) && Aimsharp.CustomFunction("HekiliWait") <= 200)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Combustion - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(Combustion_SpellName(Language), true);
                return true;
            }

            //Cancel Evocation
            if (Aimsharp.HasBuff(Evocation_SpellName(Language), "player", true) && Aimsharp.Power("player") == 100)
            {
                Aimsharp.StopCasting();
                return true;
            }

            if (Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Polymorph"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Polymorph Queue", Color.Purple);
                }
                Aimsharp.Cast("PolymorphOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 2120 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Flamestrike"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flamestrike Queue", Color.Purple);
                }
                Aimsharp.Cast("FlamestrikeOff");
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

            if (Aimsharp.IsCustomCodeOn("RingofFrost") && Aimsharp.SpellCooldown(RingOfFrost_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("Flamestrike") && Aimsharp.SpellCooldown(Flamestrike_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("Meteor") && Aimsharp.SpellCooldown(Meteor_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                if (Aimsharp.CanCast(Counterspell_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Counterspell_SpellName(Language), true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast(Counterspell_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Counterspell_SpellName(Language), true);
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

            //Auto Ice Block
            if (Aimsharp.CanCast(IceBlock_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Ice Block @ HP%"))
                {
                    Aimsharp.Cast(IceBlock_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Ice Block - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Ice Block @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Alter Time
            if (Aimsharp.CanCast(AlterTime_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Alter Time @ HP%"))
                {
                    Aimsharp.Cast(AlterTime_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Alter Time - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Alter Time @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Greater Invisibility
            if (Aimsharp.CanCast(GreaterInvisibility_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Greater Invisibility @ HP%"))
                {
                    Aimsharp.Cast(GreaterInvisibility_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Greater Invisibility - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Greater Invisibility @ HP%"), Color.Black);
                    }
                    return true;
                }
            }

            //Auto Blazing Barrier
            if (Aimsharp.CanCast(BlazingBarrier_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Blazing Barrier @ HP%"))
                {
                    Aimsharp.Cast(BlazingBarrier_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Blazing Barrier - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Blazing Barrier @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Spellsteal Mouseover
            if (!NoSpellsteal && Aimsharp.CanCast(Spellsteal_SpellName(Language), "mouseover", true, true) && (!GetCheckBox("Don't Spellsteal during Combustion:") || GetCheckBox("Don't Spellsteal during Combustion:") && !Aimsharp.HasBuff(Combustion_SpellName(Language), "player", true)))
            {
                if (GetCheckBox("Auto Spellsteal Mouseover:") && Aimsharp.CustomFunction("SpellstealCheckMouseover") == 3)
                {
                    Aimsharp.Cast("SpellstealMO");
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Spellsteal on Mouseover", Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Spellsteal Target
            if (!NoSpellsteal && Aimsharp.CanCast(Spellsteal_SpellName(Language), "target", true, true) && (!GetCheckBox("Don't Spellsteal during Combustion:") || GetCheckBox("Don't Spellsteal during Combustion:") && !Aimsharp.HasBuff(Combustion_SpellName(Language), "player", true)))
            {
                if (GetCheckBox("Auto Spellsteal Target:") && Aimsharp.CustomFunction("SpellstealCheckTarget") == 3)
                {
                    Aimsharp.Cast(Spellsteal_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Spellsteal on Target", Color.Purple);
                    }
                    return true;
                }
            }
            #endregion

            #region Queues
            bool Polymorph = Aimsharp.IsCustomCodeOn("Polymorph");
            if ((Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Polymorph)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Polymorph Queue", Color.Purple);
                }
                Aimsharp.Cast("PolymorphOff");
                return true;
            }

            if (Polymorph && Aimsharp.CanCast(Polymorph_SpellName(Language), "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Polymorph - Queue", Color.Purple);
                }
                Aimsharp.Cast("PolymorphMO");
                return true;
            }

            bool ArcaneExplosion = Aimsharp.IsCustomCodeOn("ArcaneExplosion");
            if (ArcaneExplosion && Aimsharp.CanCast(ArcaneExplosion_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Arcane Explosion - Queue", Color.Purple);
                }
                Aimsharp.Cast(ArcaneExplosion_SpellName(Language));
                return true;
            }

            //Queue Ring of Frost
            string RingofFrostCast = GetDropDown("Ring of Frost Cast:");
            bool RingofFrost = Aimsharp.IsCustomCodeOn("RingofFrost");
            if ((Aimsharp.SpellCooldown(RingOfFrost_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && RingofFrost)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Ring of Frost Queue", Color.Purple);
                }
                Aimsharp.Cast("RingofFrostOff");
                return true;
            }

            if (RingofFrost && Aimsharp.CanCast(RingOfFrost_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (RingofFrostCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Frost - " + RingofFrostCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(RingOfFrost_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Frost - " + RingofFrostCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofFrostP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Frost - " + RingofFrostCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofFrostC");
                        return true;
                }
            }

            //Queue Meteor
            string MeteorCast = GetDropDown("Meteor Cast:");
            bool Meteor = Aimsharp.IsCustomCodeOn("Meteor");
            if ((Aimsharp.SpellCooldown(Meteor_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && Meteor)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Meteor Queue", Color.Purple);
                }
                Aimsharp.Cast("MeteorOff");
                return true;
            }

            if (Meteor && Aimsharp.CanCast(Meteor_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (MeteorCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Meteor_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MeteorP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MeteorC");
                        return true;
                }
            }

            //Queue Flamestrike
            string FlamestrikeCast = GetDropDown("Flamestrike Cast:");
            bool Flamestrike = Aimsharp.IsCustomCodeOn("Flamestrike");
            if ((Aimsharp.SpellCooldown(Flamestrike_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving || Aimsharp.LastCast() == Flamestrike_SpellName(Language)) && Flamestrike)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flamestrike Queue", Color.Purple);
                }
                Aimsharp.Cast("FlamestrikeOff");
                return true;
            }

            if (Flamestrike && Aimsharp.CanCast(Flamestrike_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (FlamestrikeCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike - " + FlamestrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Flamestrike_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike - " + FlamestrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FlamestrikeP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike - " + FlamestrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FlamestrikeC");
                        return true;
                }
            }
            #endregion

            #region Remove Curse
            if (!NoDecurse && Aimsharp.CustomFunction("CurseCheck") > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != RemoveCurse_SpellName(Language))
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

                int KickTimer = GetRandomNumber(200,800);

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast(RemoveCurse_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
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
                                    Aimsharp.PrintMessage("Remove Curse @ " + unit.Key + " - " + unit.Value, Color.Purple);
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
            if (!NoCycle && Aimsharp.CustomFunction("HekiliCycle") == 1 && Enemies > 1)
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
                if (Aimsharp.Range("target") <= 40 && !Aimsharp.HasDebuff(Polymorph_SpellName(Language), "target", true) && !Polymorph && !ArcaneExplosion)
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

                    #region Covenants
                    ///Covenants
                    if ((SpellID1 == 307443 || SpellID1 == 376103) && Aimsharp.CanCast(RadiantSpark_SpellName(Language), "target", true, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Radiant Spark - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RadiantSpark_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 324220 && Aimsharp.CanCast(Deathborne_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Deathborne - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Deathborne_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 314791 || SpellID1 == 382440) && Aimsharp.CanCast(ShiftingPower_SpellName(Language), "player", false, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shifting Power - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ShiftingPower_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 314793 && Aimsharp.CanCast(MirrorsOfTorment_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mirrors of Torment - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(MirrorsOfTorment_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - No GCD
                    ///Class Spells
                    //Target - No GCD
                    if (SpellID1 == 2139 && Aimsharp.CanCast(Counterspell_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Counterspell- " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Counterspell_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    //Target - GCD
                    if (SpellID1 == 116 && Aimsharp.CanCast(Frostbolt_SpellName(Language), "target", true, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Frostbolt - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Frostbolt_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 118 && Aimsharp.CanCast(Polymorph_SpellName(Language), "target", true, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Polymorph - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Polymorph_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 383121 && Aimsharp.CanCast(MassPolymorph_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mass Polymorph - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(MassPolymorph_SpellName(Language));
                        return true;
                    }

                    if (!NoSpellsteal && SpellID1 == 30449 && Aimsharp.CanCast(Spellsteal_SpellName(Language), "target", true, true) && (!GetCheckBox("Don't Spellsteal during Combustion:") || GetCheckBox("Don't Spellsteal during Combustion:") && !Aimsharp.HasBuff(Combustion_SpellName(Language), "player", true)))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spellsteal - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Spellsteal_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    if (SpellID1 == 1449 && Aimsharp.CanCast(ArcaneExplosion_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Explosion - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ArcaneExplosion_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 1459 && Aimsharp.CanCast(ArcaneIntellect_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Intellect - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ArcaneIntellect_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 1953 || SpellID1 == 212653) && Aimsharp.CanCast(Blink_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blink - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Blink_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 120 && Aimsharp.CanCast(ConeOfCold_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cone of Cold - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(ConeOfCold_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 389713 && Aimsharp.CanCast(Displacement_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Displacement - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(Displacement_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 321358 && Aimsharp.CanCast(FocusMagic_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Focus Magic - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FocusMagic_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 122 && Aimsharp.CanCast(FrostNova_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Frost Nova - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FrostNova_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 66 && Aimsharp.CanCast(Invisibility_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Invisibility - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(Invisibility_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 45438 && Aimsharp.CanCast(IceBlock_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ice Block - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(IceBlock_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 108839 && Aimsharp.CanCast(IceFloes_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ice Floes - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(IceFloes_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 157997 && Aimsharp.CanCast(IceNova_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ice Nova - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(IceNova_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 55342 && Aimsharp.CanCast(MirrorImage_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mirror Image - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(MirrorImage_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 475 && Aimsharp.CanCast(RemoveCurse_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Remove Curse - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RemoveCurse_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 113724 && Aimsharp.CanCast(RingOfFrost_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Frost - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RingOfFrost_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 116011 && Aimsharp.CanCast(RuneOfPower_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rune of Power - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RuneOfPower_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 130 && Aimsharp.CanCast(SlowFall_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Slow Fall - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SlowFall_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 80353 && Aimsharp.CanCast(TimeWarp_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Time Warp - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TimeWarp_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Fire Spells - Player GCD
                    if (SpellID1 == 235313 && Aimsharp.CanCast(BlazingBarrier_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blazing Barrier - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BlazingBarrier_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 190319 && Aimsharp.CanCast(Combustion_SpellName(Language), "player", false, false))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Combustion - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Combustion_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 31661 && Aimsharp.CanCast(DragonsBreath_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Dragon's Breath - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DragonsBreath_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 157981 && Aimsharp.CanCast(BlastWave_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blast Wave - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BlastWave_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 2120 && Aimsharp.CanCast(Flamestrike_SpellName(Language), "player", false, true) && (Aimsharp.CustomFunction("FlamestrikeMouseover") == 1 || GetCheckBox("Always Cast Flamestrike @ Cursor during Rotation") || Aimsharp.IsCustomCodeOn("FlamestrikeCursor")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("FlamestrikeC");
                        return true;
                    }
                    else if (SpellID1 == 2120 && Aimsharp.CanCast(Flamestrike_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Flamestrike_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 153561 && Aimsharp.CanCast(Meteor_SpellName(Language), "player", false, true))
                    {
                        switch (MeteorCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast(Meteor_SpellName(Language));
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("MeteorP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("MeteorC");
                                return true;
                        }
                    }
                    #endregion

                    #region Fire Spells - Target GCD
                    if (SpellID1 == 44457 && Aimsharp.CanCast(LivingBomb_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Living Bomb - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(LivingBomb_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 108853 && Aimsharp.CanCast(FireBlast_SpellName(Language), "target", true, false))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fire Blast - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FireBlast_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 257541 && Aimsharp.CanCast(PhoenixFlames_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Phoenix Flames - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(PhoenixFlames_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 11366 && Aimsharp.CanCast(Pyroblast_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Pyroblast - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Pyroblast_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 2948 && Aimsharp.CanCast(Scorch_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Scorch - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Scorch_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 133 && Aimsharp.CanCast(Fireball_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fireball - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Fireball_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 321358 && Aimsharp.CanCast(FocusMagic_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Focus Magic - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FocusMagic_SpellName(Language));
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
            bool AIOOC = GetCheckBox("Arcane Intellect Out of Combat:");
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

            #region Above Pause Logic
            if (Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Polymorph"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Polymorph Queue", Color.Purple);
                }
                Aimsharp.Cast("PolymorphOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 2120 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Flamestrike"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flamestrike Queue", Color.Purple);
                }
                Aimsharp.Cast("FlamestrikeOff");
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
            if (Aimsharp.IsCustomCodeOn("RingofFrost") && Aimsharp.SpellCooldown(RingOfFrost_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("Flamestrike") && Aimsharp.SpellCooldown(Flamestrike_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("Meteor") && Aimsharp.SpellCooldown(Meteor_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            bool Polymorph = Aimsharp.IsCustomCodeOn("Polymorph");
            if ((Aimsharp.CastingID("player") == 118 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Polymorph)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Polymorph Queue", Color.Purple);
                }
                Aimsharp.Cast("PolymorphOff");
                return true;
            }

            if (Polymorph && Aimsharp.CanCast(Polymorph_SpellName(Language), "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Polymorph - Queue", Color.Purple);
                }
                Aimsharp.Cast("PolymorphMO");
                return true;
            }

            bool ArcaneExplosion = Aimsharp.IsCustomCodeOn("ArcaneExplosion");
            if (ArcaneExplosion && Aimsharp.CanCast(ArcaneExplosion_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Arcane Explosion - Queue", Color.Purple);
                }
                Aimsharp.Cast(ArcaneExplosion_SpellName(Language));
                return true;
            }
            //Queue Ring of Frost
            string RingofFrostCast = GetDropDown("Ring of Frost Cast:");
            bool RingofFrost = Aimsharp.IsCustomCodeOn("RingofFrost");
            if ((Aimsharp.SpellCooldown(RingOfFrost_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && RingofFrost)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Ring of Frost Queue", Color.Purple);
                }
                Aimsharp.Cast("RingofFrostOff");
                return true;
            }

            if (RingofFrost && Aimsharp.CanCast(RingOfFrost_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (RingofFrostCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Frost - " + RingofFrostCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(RingOfFrost_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Frost - " + RingofFrostCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofFrostP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Frost - " + RingofFrostCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofFrostC");
                        return true;
                }
            }

            //Queue Meteor
            string MeteorCast = GetDropDown("Meteor Cast:");
            bool Meteor = Aimsharp.IsCustomCodeOn("Meteor");
            if ((Aimsharp.SpellCooldown(Meteor_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && Meteor)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Meteor Queue", Color.Purple);
                }
                Aimsharp.Cast("MeteorOff");
                return true;
            }

            if (Meteor && Aimsharp.CanCast(Meteor_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (MeteorCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Meteor_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MeteorP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Meteor - " + MeteorCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MeteorC");
                        return true;
                }
            }

            //Queue Flamestrike
            string FlamestrikeCast = GetDropDown("Flamestrike Cast:");
            bool Flamestrike = Aimsharp.IsCustomCodeOn("Flamestrike");
            if ((Aimsharp.SpellCooldown(Flamestrike_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving || Aimsharp.LastCast() == Flamestrike_SpellName(Language)) && Flamestrike)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flamestrike Queue", Color.Purple);
                }
                Aimsharp.Cast("FlamestrikeOff");
                return true;
            }

            if (Flamestrike && Aimsharp.CanCast(Flamestrike_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (FlamestrikeCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike - " + FlamestrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Flamestrike_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike - " + FlamestrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FlamestrikeP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flamestrike - " + FlamestrikeCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FlamestrikeC");
                        return true;
                }
            }
            #endregion

            #region Out of Combat Spells
            if (SpellID1 == 1459 && Aimsharp.CanCast(ArcaneIntellect_SpellName(Language), "player", false, true) && AIOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Arcane Intellect (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(ArcaneIntellect_SpellName(Language));
                return true;
            }

            if (Aimsharp.CanCast(ArcaneIntellect_SpellName(Language), "player", false, true) && !Aimsharp.HasBuff(ArcaneIntellect_SpellName(Language), "player", true) && AIOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Arcane Intellect (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(ArcaneIntellect_SpellName(Language));
                return true;
            }
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 40 && TargetInCombat && !Aimsharp.HasDebuff(Polymorph_SpellName(Language), "target", true) && !Polymorph)
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