using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicHunterBeastMasteryHekili : Rotation
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
        ///<summary>spell=131894</summary>
        private static string AMurderOfCrows_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "A Murder of Crows";
                case "Deutsch": return "Die Vögel";
                case "Español": return "Bandada de cuervos";
                case "Français": return "Corbeaux hargneux";
                case "Italiano": return "Stormo di Corvi";
                case "Português Brasileiro": return "Bando de Corvos";
                case "Русский": return "Стая воронов";
                case "한국어": return "저승까마귀";
                case "简体中文": return "夺命黑鸦";
                default: return "A Murder of Crows";
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

        ///<summary>spell=185358</summary>
        private static string ArcaneShot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Arcane Shot";
                case "Deutsch": return "Arkaner Schuss";
                case "Español": return "Disparo Arcano";
                case "Français": return "Tir des Arcanes";
                case "Italiano": return "Tiro Arcano";
                case "Português Brasileiro": return "Tiro Arcano";
                case "Русский": return "Чародейский выстрел";
                case "한국어": return "신비한 사격";
                case "简体中文": return "奥术射击";
                default: return "Arcane Shot";
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

        ///<summary>spell=186265</summary>
        private static string AspectOfTheTurtle_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Aspect of the Turtle";
                case "Deutsch": return "Aspekt der Schildkröte";
                case "Español": return "Aspecto de la tortuga";
                case "Français": return "Aspect de la tortue";
                case "Italiano": return "Aspetto della Tartaruga";
                case "Português Brasileiro": return "Aspecto da Tartaruga";
                case "Русский": return "Дух черепахи";
                case "한국어": return "거북의 상";
                case "简体中文": return "灵龟守护";
                default: return "Aspect of the Turtle";
            }
        }

        ///<summary>spell=193530</summary>
        private static string AspectOfTheWild_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Aspect of the Wild";
                case "Deutsch": return "Aspekt der Wildnis";
                case "Español": return "Aspecto de lo salvaje";
                case "Français": return "Aspect de la Nature";
                case "Italiano": return "Aspetto della Selva";
                case "Português Brasileiro": return "Aspecto do Indomado";
                case "Русский": return "Дух дикой природы";
                case "한국어": return "야생의 상";
                case "简体中文": return "野性守护";
                default: return "Aspect of the Wild";
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

        ///<summary>spell=217200</summary>
        private static string BarbedShot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Barbed Shot";
                case "Deutsch": return "Stachelpfeil";
                case "Español": return "Disparo con púas";
                case "Français": return "Tir acéré";
                case "Italiano": return "Tiro Lacerante";
                case "Português Brasileiro": return "Disparo Farpado";
                case "Русский": return "Разрывающий выстрел";
                case "한국어": return "날카로운 사격";
                case "简体中文": return "倒刺射击";
                default: return "Barbed Shot";
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

        ///<summary>spell=19574</summary>
        private static string BestialWrath_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bestial Wrath";
                case "Deutsch": return "Zorn des Wildtiers";
                case "Español": return "Cólera de las bestias";
                case "Français": return "Courroux bestial";
                case "Italiano": return "Ira Bestiale";
                case "Português Brasileiro": return "Ira Bestial";
                case "Русский": return "Звериный гнев";
                case "한국어": return "야수의 격노";
                case "简体中文": return "狂野怒火";
                default: return "Bestial Wrath";
            }
        }

        ///<summary>spell=109248</summary>
        private static string BindingShot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Binding Shot";
                case "Deutsch": return "Bindender Schuss";
                case "Español": return "Disparo vinculante";
                case "Français": return "Tir de lien";
                case "Italiano": return "Tiro Vincolante";
                case "Português Brasileiro": return "Disparo Aprisionador";
                case "Русский": return "Связующий выстрел";
                case "한국어": return "구속의 사격";
                case "简体中文": return "束缚射击";
                default: return "Binding Shot";
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

        ///<summary>spell=321530</summary>
        private static string Bloodshed_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bloodshed";
                case "Deutsch": return "Blutvergießen";
                case "Español": return "Derramamiento de sangre";
                case "Français": return "Effusion de sang";
                case "Italiano": return "Carneficina";
                case "Português Brasileiro": return "Derramamento de Sangue";
                case "Русский": return "Кровопролитие";
                case "한국어": return "유혈";
                case "简体中文": return "血溅十方";
                default: return "Bloodshed";
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

        ///<summary>spell=359844</summary>
        private static string CallOfTheWild_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Call of the Wild";
                case "Deutsch": return "Ruf der Wildnis";
                case "Español": return "Llamada de lo salvaje";
                case "Français": return "Appel de la Nature";
                case "Italiano": return "Richiamo Selvaggio";
                case "Português Brasileiro": return "Chamado das Selvas";
                case "Русский": return "Зов дикой природы";
                case "한국어": return "야생의 부름";
                case "简体中文": return "荒野的召唤";
                default: return "Call of the Wild";
            }
        }

        ///<summary>spell=193455</summary>
        private static string CobraShot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Cobra Shot";
                case "Deutsch": return "Kobraschuss";
                case "Español": return "Disparo de cobra";
                case "Français": return "Tir du cobra";
                case "Italiano": return "Tiro del Cobra";
                case "Português Brasileiro": return "Disparo da Naja";
                case "Русский": return "Выстрел кобры";
                case "한국어": return "코브라 사격";
                case "简体中文": return "眼镜蛇射击";
                default: return "Cobra Shot";
            }
        }

        ///<summary>spell=147362</summary>
        private static string CounterShot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Counter Shot";
                case "Deutsch": return "Gegenschuss";
                case "Español": return "Contradisparo";
                case "Français": return "Tir de riposte";
                case "Italiano": return "Tiro di Contrasto";
                case "Português Brasileiro": return "Tiro Retaliatório";
                case "Русский": return "Встречный выстрел";
                case "한국어": return "반격의 사격";
                case "简体中文": return "反制射击";
                default: return "Counter Shot";
            }
        }

        ///<summary>spell=375891</summary>
        private static string DeathChakram_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Death Chakram";
                case "Deutsch": return "Todeschakram";
                case "Español": return "Chakram de muerte";
                case "Français": return "Chakram de mort";
                case "Italiano": return "Chakram della Morte";
                case "Português Brasileiro": return "Chakram da Morte";
                case "Русский": return "Шакрам смерти";
                case "한국어": return "죽음의 회전 표창";
                case "简体中文": return "死亡飞轮";
                default: return "Death Chakram";
            }
        }

        ///<summary>spell=120679</summary>
        private static string DireBeast_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dire Beast";
                case "Deutsch": return "Alphatier";
                case "Español": return "Bestia temible";
                case "Français": return "Bête féroce";
                case "Italiano": return "Bestia Feroce";
                case "Português Brasileiro": return "Fera Atroz";
                case "Русский": return "Ужасный зверь";
                case "한국어": return "광포한 야수";
                case "简体中文": return "凶暴野兽";
                default: return "Dire Beast";
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

        ///<summary>spell=109304</summary>
        private static string Exhilaration_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Exhilaration";
                case "Deutsch": return "Freudentaumel";
                case "Español": return "Excitación";
                case "Français": return "Enthousiasme";
                case "Italiano": return "Fuga Curativa";
                case "Português Brasileiro": return "Exaltação";
                case "Русский": return "Живость";
                case "한국어": return "활기";
                case "简体中文": return "意气风发";
                default: return "Exhilaration";
            }
        }

        ///<summary>spell=212431</summary>
        private static string ExplosiveShot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Explosive Shot";
                case "Deutsch": return "Explosivschuss";
                case "Español": return "Disparo explosivo";
                case "Français": return "Tir explosif";
                case "Italiano": return "Tiro Esplosivo";
                case "Português Brasileiro": return "Tiro Explosivo";
                case "Русский": return "Разрывной выстрел";
                case "한국어": return "폭발 사격";
                case "简体中文": return "爆炸射击";
                default: return "Explosive Shot";
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

        ///<summary>spell=1543</summary>
        private static string Flare_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Flare";
                case "Deutsch": return "Leuchtfeuer";
                case "Español": return "Bengala";
                case "Français": return "Fusée éclairante";
                case "Italiano": return "Bengala";
                case "Português Brasileiro": return "Sinalizador";
                case "Русский": return "Осветительная ракета";
                case "한국어": return "섬광";
                case "简体中文": return "照明弹";
                default: return "Flare";
            }
        }

        ///<summary>spell=324149</summary>
        private static string FlayedShot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Flayed Shot";
                case "Deutsch": return "Schinderschuss";
                case "Español": return "Disparo despellejador";
                case "Français": return "Tir écorcheur";
                case "Italiano": return "Tiro Scorticato";
                case "Português Brasileiro": return "Disparo Esfolador";
                case "Русский": return "Выстрел свежевателя";
                case "한국어": return "약탈의 사격";
                case "简体中文": return "劫掠射击";
                default: return "Flayed Shot";
            }
        }

        ///<summary>spell=324156</summary>
        private static string FlayersMark_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Flayer's Mark";
                case "Deutsch": return "Mal des Schinders";
                case "Español": return "Marca del despellejador";
                case "Français": return "Marque de l’écorcheur";
                case "Italiano": return "Marchio dello Scorticatore";
                case "Português Brasileiro": return "Marca do Esfolador";
                case "Русский": return "Метка свежевателя";
                case "한국어": return "약탈자의 징표";
                case "简体中文": return "劫掠者的标记";
                default: return "Flayer's Mark";
            }
        }


        ///<summary>spell=392956</summary>
        private static string FortitudeOfTheBear_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fortitude of the Bear";
                case "Deutsch": return "Zähigkeit des Bären";
                case "Español": return "Entereza del oso";
                case "Français": return "Robustesse de l’ours";
                case "Italiano": return "Fermezza dell'Orso";
                case "Português Brasileiro": return "Fortitude do Urso";
                case "Русский": return "Выносливость медведя";
                case "한국어": return "곰의 인내";
                case "简体中文": return "巨熊之韧";
                default: return "Fortitude of the Bear";
            }
        }

        ///<summary>spell=187650</summary>
        private static string FreezingTrap_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Freezing Trap";
                case "Deutsch": return "Eiskältefalle";
                case "Español": return "Trampa congelante";
                case "Français": return "Piège givrant";
                case "Italiano": return "Trappola Congelante";
                case "Português Brasileiro": return "Armadilha Congelante";
                case "Русский": return "Замораживающая ловушка";
                case "한국어": return "빙결 덫";
                case "简体中文": return "冰冻陷阱";
                default: return "Freezing Trap";
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

        ///<summary>spell=236776</summary>
        private static string HighExplosiveTrap_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "High Explosive Trap";
                case "Deutsch": return "Hochexplosivfalle";
                case "Español": return "Trampa sumamente explosiva";
                case "Français": return "Piège hautement explosif";
                case "Italiano": return "Trappola ad Alto Potenziale";
                case "Português Brasileiro": return "Armadilha Altamente Explosiva";
                case "Русский": return "Фугасная ловушка";
                case "한국어": return "고폭탄 덫";
                case "简体中文": return "高爆陷阱";
                default: return "High Explosive Trap";
            }
        }

        ///<summary>spell=257284</summary>
        private static string HuntersMark_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Hunter's Mark";
                case "Deutsch": return "Mal des Jägers";
                case "Español": return "Marca del cazador";
                case "Français": return "Marque du chasseur";
                case "Italiano": return "Marchio del Cacciatore";
                case "Português Brasileiro": return "Marca do Caçador";
                case "Русский": return "Метка охотника";
                case "한국어": return "사냥꾼의 징표";
                case "简体中文": return "猎人印记";
                default: return "Hunter's Mark";
            }
        }

        ///<summary>spell=19577</summary>
        private static string Intimidation_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Intimidation";
                case "Deutsch": return "Einschüchterung";
                case "Español": return "Intimidación";
                case "Français": return "Intimidation";
                case "Italiano": return "Intimidazione";
                case "Português Brasileiro": return "Intimidação";
                case "Русский": return "Устрашение";
                case "한국어": return "위협";
                case "简体中文": return "胁迫";
                default: return "Intimidation";
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

        ///<summary>spell=34026</summary>
        private static string KillCommand_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Kill Command";
                case "Deutsch": return "Tötungsbefehl";
                case "Español": return "Matar";
                case "Français": return "Ordre de tuer";
                case "Italiano": return "Ordine di Morte";
                case "Português Brasileiro": return "Comando para Matar";
                case "Русский": return "Команда \"Взять!\"";
                case "한국어": return "살상 명령";
                case "简体中文": return "杀戮命令";
                default: return "Kill Command";
            }
        }

        ///<summary>spell=320976</summary>
        private static string KillShot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Kill Shot";
                case "Deutsch": return "Tödlicher Schuss";
                case "Español": return "Disparo mortal";
                case "Français": return "Tir mortel";
                case "Italiano": return "Tiro Mortale";
                case "Português Brasileiro": return "Tiro Mortal";
                case "Русский": return "Убийственный выстрел";
                case "한국어": return "마무리 사격";
                case "简体中文": return "夺命射击";
                default: return "Kill Shot";
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

        ///<summary>spell=136</summary>
        private static string MendPet_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mend Pet";
                case "Deutsch": return "Tier heilen";
                case "Español": return "Aliviar mascota";
                case "Français": return "Guérison du familier";
                case "Italiano": return "Cura Famiglio";
                case "Português Brasileiro": return "Curar Ajudante";
                case "Русский": return "Лечение питомца";
                case "한국어": return "야수 치료";
                case "简体中文": return "治疗宠物";
                default: return "Mend Pet";
            }
        }

        ///<summary>spell=2643</summary>
        private static string Multishot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Multi-Shot";
                case "Deutsch": return "Mehrfachschuss";
                case "Español": return "Multidisparo";
                case "Français": return "Flèches multiples";
                case "Italiano": return "Tiro Multiplo";
                case "Português Brasileiro": return "Tiro Múltiplo";
                case "Русский": return "Залп";
                case "한국어": return "일제 사격";
                case "简体中文": return "多重射击";
                default: return "Multi-Shot";
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

        ///<summary>spell=308491</summary>
        private static string ResonatingArrow_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Resonating Arrow";
                case "Deutsch": return "Resonierender Pfeil";
                case "Español": return "Flecha resonante";
                case "Français": return "Flèche résonnante";
                case "Italiano": return "Freccia Risonante";
                case "Português Brasileiro": return "Flecha Ressonante";
                case "Русский": return "Резонирующая стрела";
                case "한국어": return "공명의 화살";
                case "简体中文": return "共鸣箭";
                default: return "Resonating Arrow";
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

        ///<summary>spell=388045</summary>
        private static string SentinelOwl_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sentinel Owl";
                case "Deutsch": return "Wächtereule";
                case "Español": return "Búho centinela";
                case "Français": return "Hibou sentinelle";
                case "Italiano": return "Gufo Sentinella";
                case "Português Brasileiro": return "Coruja Sentinela";
                case "Русский": return "Сова-часовой";
                case "한국어": return "파수꾼 올빼미";
                case "简体中文": return "警戒猫头鹰";
                default: return "Sentinel Owl";
            }
        }

        ///<summary>spell=271788</summary>
        private static string SerpentSting_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Serpent Sting";
                case "Deutsch": return "Schlangengift";
                case "Español": return "Picadura de serpiente";
                case "Français": return "Morsure de serpent";
                case "Italiano": return "Morso del Serpente";
                case "Português Brasileiro": return "Picada de Serpente";
                case "Русский": return "Укус змеи";
                case "한국어": return "독사 쐐기";
                case "简体中文": return "毒蛇钉刺";
                default: return "Serpent Sting";
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

        ///<summary>spell=201430</summary>
        private static string Stampede_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Stampede";
                case "Deutsch": return "Stampede";
                case "Español": return "Estampida";
                case "Français": return "Ruée";
                case "Italiano": return "Impeto";
                case "Português Brasileiro": return "Manada Furiosa";
                case "Русский": return "Звериный натиск";
                case "한국어": return "쇄도";
                case "简体中文": return "群兽奔腾";
                default: return "Stampede";
            }
        }

        ///<summary>spell=56641</summary>
        private static string SteadyShot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Steady Shot";
                case "Deutsch": return "Zuverlässiger Schuss";
                case "Español": return "Disparo firme";
                case "Français": return "Tir assuré";
                case "Italiano": return "Tiro Stabilizzato";
                case "Português Brasileiro": return "Tiro Firme";
                case "Русский": return "Верный выстрел";
                case "한국어": return "고정 사격";
                case "简体中文": return "稳固射击";
                default: return "Steady Shot";
            }
        }

        ///<summary>spell=162488</summary>
        private static string SteelTrap_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Steel Trap";
                case "Deutsch": return "Stahlfalle";
                case "Español": return "Trampa de acero";
                case "Français": return "Piège d’acier";
                case "Italiano": return "Trappola d'Acciaio";
                case "Português Brasileiro": return "Armadilha de Aço";
                case "Русский": return "Капкан";
                case "한국어": return "강철 덫";
                case "简体中文": return "精钢陷阱";
                default: return "Steel Trap";
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

        ///<summary>spell=264735</summary>
        private static string SurvivalOfTheFittest_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Survival of the Fittest";
                case "Deutsch": return "Überleben des Stärkeren";
                case "Español": return "Supervivencia del más fuerte";
                case "Français": return "Survie du plus fort";
                case "Italiano": return "Legge del Più Forte";
                case "Português Brasileiro": return "Lei da Selva";
                case "Русский": return "Выживает сильнейший";
                case "한국어": return "적자생존";
                case "简体中文": return "优胜劣汰";
                default: return "Survival of the Fittest";
            }
        }

        ///<summary>spell=187698</summary>
        private static string TarTrap_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Tar Trap";
                case "Deutsch": return "Teerfalle";
                case "Español": return "Trampa de brea";
                case "Français": return "Piège de goudron";
                case "Italiano": return "Trappola di Pece";
                case "Português Brasileiro": return "Armadilha de Piche";
                case "Русский": return "Смоляная ловушка";
                case "한국어": return "타르 덫";
                case "简体中文": return "焦油陷阱";
                default: return "Tar Trap";
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

        ///<summary>spell=19801</summary>
        private static string TranquilizingShot_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Tranquilizing Shot";
                case "Deutsch": return "Einlullender Schuss";
                case "Español": return "Disparo tranquilizante";
                case "Français": return "Tir tranquillisant";
                case "Italiano": return "Tiro Tranquillizzante";
                case "Português Brasileiro": return "Tiro Tranquilizante";
                case "Русский": return "Усмиряющий выстрел";
                case "한국어": return "평정의 사격";
                case "简体中文": return "宁神射击";
                default: return "Tranquilizing Shot";
            }
        }

        ///<summary>spell=392060</summary>
        private static string WailingArrow_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Wailing Arrow";
                case "Deutsch": return "Klagender Pfeil";
                case "Español": return "Flecha lastimera";
                case "Français": return "Flèche gémissante";
                case "Italiano": return "Freccia Funesta";
                case "Português Brasileiro": return "Seta Plangente";
                case "Русский": return "Стенающая стрела";
                case "한국어": return "울부짖는 화살";
                case "简体中文": return "哀恸箭";
                default: return "Wailing Arrow";
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

        ///<summary>spell=328231</summary>
        private static string WildSpirits_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Wild Spirits";
                case "Deutsch": return "Wilde Geister";
                case "Español": return "Espíritus salvajes";
                case "Français": return "Esprits sauvages";
                case "Italiano": return "Spiriti Selvatici";
                case "Português Brasileiro": return "Espíritos Selvagens";
                case "Русский": return "Дикие духи";
                case "한국어": return "야생 영혼";
                case "简体中文": return "野性之魂";
                default: return "Wild Spirits";
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

        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "FreezingTrap", "HighExplosiveTrap", "SteelTrap", "TarTrap", "Turtle", "Intimidation", "NoInterrupts", "NoCycle", "WildSpirits", "ResonatingArrow", "BindingShot", "Flare", "FlareCursor", "TarTrapCursor", "Sentinel" };
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
        private bool CanCastKillShot(string unit)
        {
            if (Aimsharp.CanCast(KillShot_SpellName(Language), "target", true, true) || (Aimsharp.SpellCooldown(KillShot_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && (Aimsharp.Health(unit) < 20 || Aimsharp.HasBuff(FlayersMark_SpellName(Language), "player", true)) && (Aimsharp.Power("player") >= 10 || Aimsharp.HasBuff(FlayersMark_SpellName(Language), "player", true)) && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastArcaneShot(string unit)
        {
            if (Aimsharp.CanCast(ArcaneShot_SpellName(Language), "target", true, true) || (Aimsharp.SpellCooldown(ArcaneShot_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastAMurderOfCrows(string unit)
        {
            if (Aimsharp.CanCast(AMurderOfCrows_SpellName(Language), "target", true, true) || (Aimsharp.SpellCooldown(AMurderOfCrows_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastExplosiveShot(string unit)
        {
            if (Aimsharp.CanCast(ExplosiveShot_SpellName(Language), "target", true, true) || (Aimsharp.SpellCooldown(ExplosiveShot_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSerpentSting(string unit)
        {
            if (Aimsharp.CanCast(SerpentSting_SpellName(Language), "target", true, true) || (Aimsharp.SpellCooldown(SerpentSting_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFlayedShot(string unit)
        {
            if (Aimsharp.CanCast(FlayedShot_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(FlayedShot_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastDeathChakram(string unit)
        {
            if (Aimsharp.CanCast(DeathChakram_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(DeathChakram_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastWildSpirits(string unit)
        {
            if (Aimsharp.CanCast(WildSpirits_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(WildSpirits_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastResonatingArrow(string unit)
        {
            if (Aimsharp.CanCast(ResonatingArrow_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(ResonatingArrow_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastMultiShot(string unit)
        {
            if (Aimsharp.CanCast(Multishot_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Multishot_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && Aimsharp.Power("player") >= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastBarrage(string unit)
        {
            if (Aimsharp.CanCast(Barrage_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Barrage_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && Aimsharp.Power("player") >= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastHuntersMark(string unit)
        {
            if (Aimsharp.CanCast(HuntersMark_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(HuntersMark_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && Aimsharp.Power("player") >= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFreezingTrap(string unit)
        {
            if (Aimsharp.CanCast(FreezingTrap_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(FreezingTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSteelTrap(string unit)
        {
            if (Aimsharp.CanCast(SteelTrap_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(SteelTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastHighExplosiveTrap(string unit)
        {
            if (Aimsharp.CanCast(HighExplosiveTrap_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(HighExplosiveTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastTarTrap(string unit)
        {
            if (Aimsharp.CanCast(TarTrap_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(TarTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastMendPet(string unit)
        {
            if (Aimsharp.CanCast(MendPet_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(MendPet_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Health("pet") > 1 && Aimsharp.Range("pet") <= 45 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastAspectoftheTurtle(string unit)
        {
            if (Aimsharp.CanCast(AspectOfTheTurtle_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(AspectOfTheTurtle_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }
        private bool CanCastFortitudeOfTheBear(string unit)
        {
            if (Aimsharp.CanCast(FortitudeOfTheBear_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(FortitudeOfTheBear_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSurvivaloftheFittest(string unit)
        {
            if (Aimsharp.CanCast(SurvivalOfTheFittest_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(SurvivalOfTheFittest_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastBindingShot(string unit)
        {
            if (Aimsharp.CanCast(BindingShot_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(BindingShot_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastSentinel(string unit)
        {
            if (Aimsharp.CanCast(SentinelOwl_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(SentinelOwl_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastCounterShot(string unit)
        {
            if (Aimsharp.CanCast(CounterShot_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(CounterShot_SpellName(Language)) <= 0 && Aimsharp.Range(unit) <= 40 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastExhilaration(string unit)
        {
            if (Aimsharp.CanCast(Exhilaration_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(Exhilaration_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastTranquilizingShot(string unit)
        {
            if (Aimsharp.CanCast(TranquilizingShot_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(TranquilizingShot_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastAspectoftheWild(string unit)
        {
            if (Aimsharp.CanCast(AspectOfTheWild_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(AspectOfTheWild_SpellName(Language)) <= 0 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastBarbedShot(string unit)
        {
            if (Aimsharp.CanCast(BarbedShot_SpellName(Language), "target", true, true) || ((Aimsharp.SpellCooldown(BarbedShot_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) || Aimsharp.SpellCharges(BarbedShot_SpellName(Language)) >= 1 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)) && Aimsharp.Range(unit) <= 40 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastBestialWrath(string unit)
        {
            if (Aimsharp.CanCast(BestialWrath_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(BestialWrath_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Health("pet") > 1 && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastBloodshed(string unit)
        {
            if (Aimsharp.CanCast(Bloodshed_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Bloodshed_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Health("pet") > 1 && Aimsharp.Range(unit) <= 50 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastCallOfTheWild(string unit)
        {
            if (Aimsharp.CanCast(CallOfTheWild_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(CallOfTheWild_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Health("pet") > 1 && Aimsharp.Range(unit) <= 50 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastDireBeast(string unit)
        {
            if (Aimsharp.CanCast(DireBeast_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(DireBeast_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Health("pet") > 1 && Aimsharp.Range(unit) <= 50 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastCobraShot(string unit)
        {
            if (Aimsharp.CanCast(CobraShot_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(CobraShot_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 40 && Aimsharp.Power("player") >= 35 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastIntimidation(string unit)
        {
            if (Aimsharp.CanCast(Intimidation_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Intimidation_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Health("pet") > 1 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastKillCommand(string unit)
        {
            if (Aimsharp.CanCast(KillCommand_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(KillCommand_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 50 && Aimsharp.Power("player") >= 30 && Aimsharp.Health("pet") > 1 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastFlare(string unit)
        {
            if (Aimsharp.CanCast(Flare_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(Flare_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
        }

        private bool CanCastStampede(string unit)
        {
            if (Aimsharp.CanCast(Stampede_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(Stampede_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 30 && TargetAlive() && !TorghastList.Contains(Aimsharp.GetMapID())))
                return true;

            return false;
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

            Macros.Add("TarTrapOff", "/" + FiveLetters + " TarTrap");
            Macros.Add("FreezingTrapOff", "/" + FiveLetters + " FreezingTrap");
            Macros.Add("HighExplosiveTrapOff", "/" + FiveLetters + " HighExplosiveTrap");
            Macros.Add("SteelTrapOff", "/" + FiveLetters + " SteelTrap");
            Macros.Add("IntimidationOff", "/" + FiveLetters + " Intimidation");
            Macros.Add("WildSpiritsOff", "/" + FiveLetters + " WildSpirits");
            Macros.Add("ResonatingArrowOff", "/" + FiveLetters + " ResonatingArrow");
            Macros.Add("FlareOff", "/" + FiveLetters + " Flare");
            Macros.Add("BindingShotOff", "/" + FiveLetters + " BindingShot");
            Macros.Add("SentinelOff", "/" + FiveLetters + " Sentinel");

            Macros.Add("KillShotSQW", "/cqs\\n/cast " + KillShot_SpellName(Language));
            Macros.Add("BarbedShotSQW", "/cqs\\n/cast " + BarbedShot_SpellName(Language));
            Macros.Add("TranqMO", "/cast [@mouseover] " + TranquilizingShot_SpellName(Language));
            Macros.Add("FlareC", "/cast [@cursor] " + Flare_SpellName(Language));
            Macros.Add("SentinelC", "/cast [@cursor] " + SentinelOwl_SpellName(Language));
            Macros.Add("TarTrapC", "/cast [@cursor] " + TarTrap_SpellName(Language));
            Macros.Add("TarTrapP", "/cast [@player] " + TarTrap_SpellName(Language));
            Macros.Add("FreezingTrapC", "/cast [@cursor] " + FreezingTrap_SpellName(Language));
            Macros.Add("FreezingTrapP", "/cast [@player] " + FreezingTrap_SpellName(Language));
            Macros.Add("HighExplosiveTrapC", "/cast [@cursor] " + HighExplosiveTrap_SpellName(Language));
            Macros.Add("HighExplosiveTrapP", "/cast [@player] " + HighExplosiveTrap_SpellName(Language));
            Macros.Add("SteelTrapC", "/cast [@cursor] " + SteelTrap_SpellName(Language));
            Macros.Add("SteelTrapP", "/cast [@player] " + SteelTrap_SpellName(Language));

            Macros.Add("ResonatingArrowP", "/cast [@player] " + ResonatingArrow_SpellName(Language));
            Macros.Add("WildSpiritsP", "/cast [@player] " + WildSpirits_SpellName(Language));
            Macros.Add("ResonatingArrowC", "/cast [@cursor] " + ResonatingArrow_SpellName(Language));
            Macros.Add("WildSpiritsC", "/cast [@cursor] " + WildSpirits_SpellName(Language));
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

            CustomFunctions.Add("SpiritBeastDispel", "local y=0; " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"pet\",i); " +
                    "if type ~= nil and (type == \"Disease\" or type == \"Poison\" or type == \"Magic\") then y = 1; end end " +
                "return y");

            CustomFunctions.Add("HekiliWait", "if HekiliDisplayPrimary.Recommendations[1].wait ~= nil and HekiliDisplayPrimary.Recommendations[1].wait * 1000 > 0 then return math.floor(HekiliDisplayPrimary.Recommendations[1].wait * 1000) end return 0");

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("HekiliEnemies", "if Hekili.State.active_enemies ~= nil and Hekili.State.active_enemies > 0 then return Hekili.State.active_enemies end return 0");

            CustomFunctions.Add("PhialCount", "local count = GetItemCount(177278) if count ~= nil then return count end return 0");

            CustomFunctions.Add("TranqBuffCheck", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Tranquilizing Shot','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType  = UnitBuff('mouseover', y) if debuffType == '' or debuffType == 'Magic' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("VolleyMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Steady Shot','mouseover') == 1 then return 1 end; return 0");

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
            Settings.Add(new Setting("Race:", m_RaceList, "dwarf"));
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
            Settings.Add(new Setting("Tranquilizing Shot Mouseover:", true));
            Settings.Add(new Setting("Auto Mend Pet @ HP%", 0, 100, 60));
            Settings.Add(new Setting("Auto Exhilaration @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Auto Aspect of the Turtle @ HP%", 0, 100, 20));
            Settings.Add(new Setting("Auto Fortitude of the Bear @ HP%", 0, 100, 30));
            Settings.Add(new Setting("Auto Survival of the Fittest @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Covenant Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Tar Trap Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Steel Trap Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Freezing Trap Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("High Explosive Trap Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Always Cast Flare @ Cursor during Rotation", false));
            Settings.Add(new Setting("Always Cast Tar Trap @ Cursor during Rotation", false));
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

            Aimsharp.PrintMessage("Epic PVE - Hunter Beast Mastery", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/hunter/beast-mastery/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("Pet Summon is Manual", Color.Green);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Flare - Casts Flare @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " TarTrap - Casts Tar Trap @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " SteelTrap - Casts Tar Trap @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FreezingTrap - Casts Freezing Trap @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " HighExplosiveTrap - Casts High Explosive Trap @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Intimidation - Casts Intimidation @ Target next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Sentinel - Casts Sentinel @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BindingShot - Casts Binding Shot @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " WildSpirits - Casts Wild Spirits @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " ResonatingArrow - Casts Resonating Arrow @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FlareCursor - Toggles Flare always @ Cursor (same as Option)", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " TarTrapCursor - Toggles Tar Trap always @ Cursor (same as Option)", Color.Yellow);
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
            m_DebuffsList = new List<string> { HuntersMark_SpellName(Language), };
            m_BuffsList = new List<string> { MendPet_SpellName(Language), FlayersMark_SpellName(Language), };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language) };
            m_SpellBook = new List<string> {
                //Covenants
                FlayedShot_SpellName(Language), //324149
                DeathChakram_SpellName(Language), //375891
                WildSpirits_SpellName(Language), //328231
                ResonatingArrow_SpellName(Language), //308491

                //Interrupt
                CounterShot_SpellName(Language), //147362

                //General
                AMurderOfCrows_SpellName(Language), //131894
                ArcaneShot_SpellName(Language), //185358
                AspectOfTheTurtle_SpellName(Language), //186265
                AspectOfTheWild_SpellName(Language), //193530
                BarbedShot_SpellName(Language), //217200
                Barrage_SpellName(Language), //120360
                BestialWrath_SpellName(Language), //19574
                BindingShot_SpellName(Language), //109248
                Bloodshed_SpellName(Language), //321530
                CallOfTheWild_SpellName(Language), //359844
                CobraShot_SpellName(Language), //193455
                DireBeast_SpellName(Language), //120679
                Exhilaration_SpellName(Language), //109304
                ExplosiveShot_SpellName(Language), //212431
                Flare_SpellName(Language), //1543
                FortitudeOfTheBear_SpellName(Language), //392956
                FreezingTrap_SpellName(Language), //187650
                HighExplosiveTrap_SpellName(Language), //236776
                HuntersMark_SpellName(Language), //257284
                Intimidation_SpellName(Language), //19577
                KillCommand_SpellName(Language), //34026
                KillShot_SpellName(Language), //320976
                MendPet_SpellName(Language), //136
                Multishot_SpellName(Language), //2643
                SentinelOwl_SpellName(Language), //388045
                SerpentSting_SpellName(Language), //271788
                Stampede_SpellName(Language), //201430
                SteelTrap_SpellName(Language), //162488
                SteadyShot_SpellName(Language), //56641
                SurvivalOfTheFittest_SpellName(Language), //264735
                TarTrap_SpellName(Language), //187698
                TranquilizingShot_SpellName(Language), //19801
                WailingArrow_SpellName(Language),//392060
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
            bool MOTranq = GetCheckBox("Tranquilizing Shot Mouseover:") == true;
            int TranqBuffMO = Aimsharp.CustomFunction("TranqBuffCheck");

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

            if (Aimsharp.IsCustomCodeOn("FreezingTrap") && Aimsharp.SpellCooldown(FreezingTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("SteelTrap") && Aimsharp.SpellCooldown(SteelTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("HighExplosiveTrap") && Aimsharp.SpellCooldown(HighExplosiveTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("TarTrap") && Aimsharp.SpellCooldown(TarTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("WildSpirits") && Aimsharp.SpellCooldown(WildSpirits_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("ResonatingArrow") && Aimsharp.SpellCooldown(ResonatingArrow_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("BindingShot") && Aimsharp.SpellCooldown(BindingShot_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("Sentinel") && Aimsharp.SpellCooldown(SentinelOwl_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                if (CanCastCounterShot("target"))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(CounterShot_SpellName(Language), true);
                        return true;
                    }
                }

                if (CanCastCounterShot("target"))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(CounterShot_SpellName(Language), true);
                        return true;
                    }
                }
            }
            #endregion

            #region Auto Spells and Items
            //Auto Turtle
            if (CanCastAspectoftheTurtle("player"))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Aspect of the Turtle @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Aspect of the Turtle- Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Aspect of the Turtle @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(AspectOfTheTurtle_SpellName(Language));
                    return true;
                }
            }

            //Auto Fortitude
            if (CanCastFortitudeOfTheBear("player"))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Fortitude of the Bear @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Auto Fortitude of the Bear - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Fortitude of the Bear @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(FortitudeOfTheBear_SpellName(Language));
                    return true;
                }
            }

            //Auto Survival
            if (CanCastSurvivaloftheFittest("player"))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Survival of the Fittest @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Auto Survival of the Fittest - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Survival of the Fittest @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(SurvivalOfTheFittest_SpellName(Language));
                    return true;
                }
            }

            //Auto Exhilaration
            if (CanCastExhilaration("player"))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Exhilaration @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Exhilaration - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Exhilaration @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(Exhilaration_SpellName(Language));
                    return true;
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

            //Auto Mend Pet
            if (Aimsharp.PlayerHasPet() && !Aimsharp.LineOfSighted() && Aimsharp.Health("pet") > 1 && Aimsharp.Health("pet") <= GetSlider("Auto Mend Pet @ HP%") && CanCastMendPet("pet") && !Aimsharp.HasBuff(MendPet_SpellName(Language), "pet", true) && Aimsharp.LastCast() != MendPet_SpellName(Language))
            {
                Aimsharp.Cast(MendPet_SpellName(Language));
                return true;
            }
            #endregion

            #region Queues
            //Queue Resonating Arrow
            string CovenantCast = GetDropDown("Covenant Cast:");
            bool ResonatingArrow = Aimsharp.IsCustomCodeOn("ResonatingArrow");
            if (Aimsharp.SpellCooldown(ResonatingArrow_SpellName(Language)) - Aimsharp.GCD() > 2000 && ResonatingArrow)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Resonating Arrow Queue", Color.Purple);
                }
                Aimsharp.Cast("ResonatingArrowOff");
                return true;
            }

            if (ResonatingArrow && CanCastResonatingArrow("player"))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(ResonatingArrow_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ResonatingArrowP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ResonatingArrowC");
                        return true;
                }
            }

            //Queue Wild Spirits
            bool WildSpirits = Aimsharp.IsCustomCodeOn("WildSpirits");
            if (Aimsharp.SpellCooldown(WildSpirits_SpellName(Language)) - Aimsharp.GCD() > 2000 && WildSpirits)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Wild Spirits Queue", Color.Purple);
                }
                Aimsharp.Cast("WildSpiritsOff");
                return true;
            }

            if (WildSpirits && CanCastWildSpirits("player"))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(WildSpirits_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WildSpiritsP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WildSpiritsC");
                        return true;
                }
            }

            string FreezingTrapCast = GetDropDown("Freezing Trap Cast:");
            bool FreezingTrap = Aimsharp.IsCustomCodeOn("FreezingTrap");
            //Queue Freezing Trap
            if (FreezingTrap && Aimsharp.SpellCooldown(FreezingTrap_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Freezing Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("FreezingTrapOff");
                return true;
            }

            if (FreezingTrap && CanCastFreezingTrap("player"))
            {
                switch (FreezingTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Freezing Trap - " + FreezingTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(FreezingTrap_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Freezing Trap - " + FreezingTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FreezingTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Freezing Trap - " + FreezingTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FreezingTrapC");
                        return true;
                }
            }

            string SteelTrapCast = GetDropDown("Steel Trap Cast:");
            bool SteelTrap = Aimsharp.IsCustomCodeOn("SteelTrap");
            //Queue Steel Trap
            if (SteelTrap && Aimsharp.SpellCooldown(SteelTrap_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Steel Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("SteelTrapOff");
                return true;
            }

            if (SteelTrap && CanCastSteelTrap("player"))
            {
                switch (SteelTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SteelTrap_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SteelTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SteelTrapC");
                        return true;
                }
            }

            string HighExplosiveTrapCast = GetDropDown("High Explosive Trap Cast:");
            bool HighExplosiveTrap = Aimsharp.IsCustomCodeOn("HighExplosiveTrap");
            //Queue High Explosive Trap
            if (HighExplosiveTrap && Aimsharp.SpellCooldown(HighExplosiveTrap_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off High Explosive Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("HighExplosiveTrapOff");
                return true;
            }

            if (HighExplosiveTrap && CanCastHighExplosiveTrap("player"))
            {
                switch (HighExplosiveTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting High Explosive Trap - " + HighExplosiveTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(HighExplosiveTrap_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting High Explosive Trap - " + HighExplosiveTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("HighExplosiveTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting High Explosive Trap - " + HighExplosiveTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("HighExplosiveTrapC");
                        return true;
                }
            }

            string TarTrapCast = GetDropDown("Tar Trap Cast:");
            bool TarTrap = Aimsharp.IsCustomCodeOn("TarTrap");
            //Queue Tar Trap
            if (TarTrap && Aimsharp.SpellCooldown(TarTrap_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Tar Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("TarTrapOff");
                return true;
            }

            if (TarTrap && CanCastTarTrap("player"))
            {
                switch (TarTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap - " + TarTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(TarTrap_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap - " + TarTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("TarTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap - " + TarTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("TarTrapC");
                        return true;
                }
            }

            //Queue Flare
            if (Aimsharp.IsCustomCodeOn("Flare") && Aimsharp.SpellCooldown(Flare_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flare Queue", Color.Purple);
                }
                Aimsharp.Cast("FlareOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn("Flare") && CanCastFlare("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Flare through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Flare_SpellName(Language));
                return true;
            }

            //Queue Binding Shot
            if (Aimsharp.IsCustomCodeOn("BindingShot") && Aimsharp.SpellCooldown(BindingShot_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Binding Shot Queue", Color.Purple);
                }
                Aimsharp.Cast("BindingShotOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn("BindingShot") && CanCastBindingShot("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Binding Shot through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(BindingShot_SpellName(Language));
                return true;
            }

            //Queue Sentinel
            if (Aimsharp.IsCustomCodeOn("Sentinel") && Aimsharp.SpellCooldown(SentinelOwl_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sentinel Queue", Color.Purple);
                }
                Aimsharp.Cast("SentinelOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn("Sentinel") && CanCastSentinel("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Sentinel through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("SentinelC");
                return true;
            }

            //Queue Intimidation
            if (Aimsharp.IsCustomCodeOn("Intimidation") && Aimsharp.SpellCooldown(Intimidation_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Intimidation Queue", Color.Purple);
                }
                Aimsharp.Cast("IntimidationOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn("Intimidation") && CanCastIntimidation("target") && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Intimidation through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Intimidation_SpellName(Language));
                return true;
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

            if (Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat && Wait <= 200 && !ResonatingArrow && !WildSpirits && !Aimsharp.IsCustomCodeOn("FreezingTrap") && !Aimsharp.IsCustomCodeOn("TarTrap"))
            {
                //Tranquilizing Shot Mouseover
                if (CanCastTranquilizingShot("mouseover"))
                {
                    if (MOTranq && TranqBuffMO == 3)
                    {
                        Aimsharp.Cast("TranqMO");
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tranquilizing Shot (Mouseover)", Color.Purple);
                        }
                        return true;
                    }
                }

                if (Aimsharp.Range("target") <= 42)
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
                    if (SpellID1 == 324149 && CanCastFlayedShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flayed Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FlayedShot_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 308491 && CanCastResonatingArrow("player"))
                    {
                        switch (CovenantCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast(ResonatingArrow_SpellName(Language));
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("ResonatingArrowP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("ResonatingArrowC");
                                return true;
                        }
                    }

                    if (SpellID1 == 328231 && CanCastWildSpirits("player"))
                    {
                        switch (CovenantCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast(WildSpirits_SpellName(Language));
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("WildSpiritsP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("WildSpiritsC");
                                return true;
                        }
                    }

                    if ((SpellID1 == 325028 || SpellID1 == 375891) && CanCastDeathChakram("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Death Chakram - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DeathChakram_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - No GCD
                    ///Class Spells
                    //Target - No GCD
                    if (SpellID1 == 106839 && CanCastCounterShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Counter Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(CounterShot_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    //Target - GCD
                    if (SpellID1 == 19801 && CanCastTranquilizingShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tranquilizing Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TranquilizingShot_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 53351 || SpellID1 == 320976) && CanCastKillShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Kill Shot w/ SQW Cancel - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("KillShotSQW");
                        return true;
                    }

                    if (SpellID1 == 185358 && CanCastArcaneShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Arcane Shot Cancel - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ArcaneShot_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 131894 && CanCastAMurderOfCrows("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting A Murder of Crows Cancel - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AMurderOfCrows_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 212431 && CanCastExplosiveShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Explosive Shot Cancel - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ExplosiveShot_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 271788 && CanCastSerpentSting("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Serpent Sting Cancel - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SerpentSting_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 2643 || SpellID1 == 257620) && CanCastMultiShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Multi-Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Multishot_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 355589 || SpellID1 == 392060) && Aimsharp.CanCast(WailingArrow_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wailing Arrow - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WailingArrow_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    if (SpellID1 == 1543 && CanCastFlare("player") && (Aimsharp.CustomFunction("VolleyMouseover") == 1 || GetCheckBox("Always Cast Flare @ Cursor during Rotation") || Aimsharp.IsCustomCodeOn("FlareCursor")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flare @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("FlareC");
                        return true;
                    }
                    else if (SpellID1 == 1543 && CanCastFlare("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flare - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Flare_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 187698 && CanCastTarTrap("player") && (Aimsharp.CustomFunction("VolleyMouseover") == 1 || GetCheckBox("Always Cast Tar Trap @ Cursor during Rotation") || Aimsharp.IsCustomCodeOn("TarTrapCursor")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("TarTrapC");
                        return true;
                    }
                    else if (SpellID1 == 187698 && CanCastTarTrap("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TarTrap_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 120360 && CanCastBarrage("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Barrage Cancel - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Barrage_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 257284 && CanCastHuntersMark("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Hunter's Mark Cancel - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(HuntersMark_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Beast Mastery Spells - Target GCD
                    if (SpellID1 == 321530 && CanCastBloodshed("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bloodshed - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Bloodshed_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 359844 && CanCastCallOfTheWild("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Call of the Wild - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(CallOfTheWild_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 120679 && CanCastDireBeast("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Dire Beast - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DireBeast_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 193455 && CanCastCobraShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cobra Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(CobraShot_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 217200 && CanCastBarbedShot("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Barbed Shot - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("BarbedShotSQW");
                        return true;
                    }

                    if (SpellID1 == 34026 && CanCastKillCommand("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Kill Command - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(KillCommand_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Beast Mastery Spells - Player GCD
                    if ((SpellID1 == 19574 || SpellID1 == 186254 || SpellID1 == 38371 || SpellID1 == 163257 || SpellID1 == 207033 || SpellID1 == 211183 || SpellID1 == 344572) && CanCastBestialWrath("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bestial Wrath- " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BestialWrath_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 193530 && CanCastAspectoftheWild("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Aspect of the Wild - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AspectOfTheWild_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 201430 && CanCastStampede("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Stampede - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Stampede_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 162488 && CanCastSteelTrap("player"))
                    {
                        switch (SteelTrapCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast(SteelTrap_SpellName(Language));
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("SteelTrapP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("SteelTrapC");
                                return true;
                        }
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

            if (Aimsharp.IsCustomCodeOn("FreezingTrap") && Aimsharp.SpellCooldown(FreezingTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("SteelTrap") && Aimsharp.SpellCooldown(SteelTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("HighExplosiveTrap") && Aimsharp.SpellCooldown(HighExplosiveTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("TarTrap") && Aimsharp.SpellCooldown(TarTrap_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("WildSpirits") && Aimsharp.SpellCooldown(WildSpirits_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("ResonatingArrow") && Aimsharp.SpellCooldown(ResonatingArrow_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("BindingShot") && Aimsharp.SpellCooldown(BindingShot_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("Sentinel") && Aimsharp.SpellCooldown(SentinelOwl_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            //Queue Resonating Arrow
            string CovenantCast = GetDropDown("Covenant Cast:");
            bool ResonatingArrow = Aimsharp.IsCustomCodeOn("ResonatingArrow");
            if (Aimsharp.SpellCooldown(ResonatingArrow_SpellName(Language)) - Aimsharp.GCD() > 2000 && ResonatingArrow)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Resonating Arrow Queue", Color.Purple);
                }
                Aimsharp.Cast("ResonatingArrowOff");
                return true;
            }

            if (ResonatingArrow && CanCastResonatingArrow("player"))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(ResonatingArrow_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ResonatingArrowP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Resonating Arrow - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ResonatingArrowC");
                        return true;
                }
            }

            //Queue Wild Spirits
            bool WildSpirits = Aimsharp.IsCustomCodeOn("WildSpirits");
            if (Aimsharp.SpellCooldown(WildSpirits_SpellName(Language)) - Aimsharp.GCD() > 2000 && WildSpirits)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Wild Spirits Queue", Color.Purple);
                }
                Aimsharp.Cast("WildSpiritsOff");
                return true;
            }

            if (WildSpirits && CanCastWildSpirits("player"))
            {
                switch (CovenantCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(WildSpirits_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WildSpiritsP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Spirits - " + CovenantCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WildSpiritsC");
                        return true;
                }
            }

            string FreezingTrapCast = GetDropDown("Freezing Trap Cast:");
            bool FreezingTrap = Aimsharp.IsCustomCodeOn("FreezingTrap");
            //Queue Freezing Trap
            if (FreezingTrap && Aimsharp.SpellCooldown(FreezingTrap_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Freezing Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("FreezingTrapOff");
                return true;
            }

            if (FreezingTrap && CanCastFreezingTrap("player"))
            {
                switch (FreezingTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Freezing Trap - " + FreezingTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(FreezingTrap_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Freezing Trap - " + FreezingTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FreezingTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Freezing Trap - " + FreezingTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FreezingTrapC");
                        return true;
                }
            }

            string HighExplosiveTrapCast = GetDropDown("High Explosive Trap Cast:");
            bool HighExplosiveTrap = Aimsharp.IsCustomCodeOn("HighExplosiveTrap");
            //Queue High Explosive Trap
            if (HighExplosiveTrap && Aimsharp.SpellCooldown(HighExplosiveTrap_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off High Explosive Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("HighExplosiveTrapOff");
                return true;
            }

            if (HighExplosiveTrap && CanCastHighExplosiveTrap("player"))
            {
                switch (HighExplosiveTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting High Explosive Trap - " + HighExplosiveTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(HighExplosiveTrap_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting High Explosive Trap - " + HighExplosiveTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("HighExplosiveTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting High Explosive Trap - " + HighExplosiveTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("HighExplosiveTrapC");
                        return true;
                }
            }

            string SteelTrapCast = GetDropDown("Steel Trap Cast:");
            bool SteelTrap = Aimsharp.IsCustomCodeOn("SteelTrap");
            //Queue Steel Trap
            if (SteelTrap && Aimsharp.SpellCooldown(SteelTrap_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Steel Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("SteelTrapOff");
                return true;
            }

            if (SteelTrap && CanCastSteelTrap("player"))
            {
                switch (SteelTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SteelTrap_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SteelTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Steel Trap - " + SteelTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("SteelTrapC");
                        return true;
                }
            }

            string TarTrapCast = GetDropDown("Tar Trap Cast:");
            bool TarTrap = Aimsharp.IsCustomCodeOn("TarTrap");
            //Queue Tar Trap
            if (TarTrap && Aimsharp.SpellCooldown(TarTrap_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Tar Trap Queue", Color.Purple);
                }
                Aimsharp.Cast("TarTrapOff");
                return true;
            }

            if (TarTrap && CanCastTarTrap("player"))
            {
                switch (TarTrapCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap - " + TarTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(TarTrap_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap - " + TarTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("TarTrapP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tar Trap - " + TarTrapCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("TarTrapC");
                        return true;
                }
            }

            //Queue Flare
            if (Aimsharp.IsCustomCodeOn("Flare") && Aimsharp.SpellCooldown(Flare_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flare Queue", Color.Purple);
                }
                Aimsharp.Cast("FlareOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn("Flare") && CanCastFlare("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Flare through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Flare_SpellName(Language));
                return true;
            }

            //Queue Binding Shot
            if (Aimsharp.IsCustomCodeOn("BindingShot") && Aimsharp.SpellCooldown(BindingShot_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Binding Shot Queue", Color.Purple);
                }
                Aimsharp.Cast("BindingShotOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn("BindingShot") && CanCastBindingShot("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Binding Shot through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(BindingShot_SpellName(Language));
                return true;
            }

            //Queue Binding Shot
            if (Aimsharp.IsCustomCodeOn("Sentinel") && Aimsharp.SpellCooldown(SentinelOwl_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sentinel Queue", Color.Purple);
                }
                Aimsharp.Cast("SentinelOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn("Sentinel") && CanCastSentinel("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Sentinel through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("SentinelC");
                return true;
            }

            //Queue Intimidation
            if (Aimsharp.IsCustomCodeOn("Intimidation") && Aimsharp.SpellCooldown(Intimidation_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Intimidation Queue", Color.Purple);
                }
                Aimsharp.Cast("IntimidationOff");
                return true;
            }

            if (Aimsharp.IsCustomCodeOn("Intimidation") && CanCastIntimidation("target") && Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Intimidation through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Intimidation_SpellName(Language));
                return true;
            }
            #endregion

            #region Out of Combat Spells
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 42 && TargetInCombat)
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