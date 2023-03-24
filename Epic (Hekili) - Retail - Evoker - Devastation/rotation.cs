using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicEvokerDevastationHekili : Rotation
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

        private static int EmpowerStateNow = new int();

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

        ///<summary>spell=362969</summary>
        private static string AzureStrike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Azure Strike";
                case "Deutsch": return "Azurstoß";
                case "Español": return "Ataque azur";
                case "Français": return "Frappe d’azur";
                case "Italiano": return "Assalto Azzurro";
                case "Português Brasileiro": return "Ataque Lazúli";
                case "Русский": return "Лазурный удар";
                case "한국어": return "하늘빛 일격";
                case "简体中文": return "碧蓝打击";
                default: return "Azure Strike";
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

        ///<summary>spell=364342</summary>
        private static string BlessingOfTheBronze_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blessing of the Bronze";
                case "Deutsch": return "Segen der Bronzenen";
                case "Español": return "Bendición de bronce";
                case "Français": return "Bénédiction du bronze";
                case "Italiano": return "Benedizione del Bronzo";
                case "Português Brasileiro": return "Bênção do Bronze";
                case "Русский": return "Дар бронзовых драконов";
                case "한국어": return "청동용군단의 축복";
                case "简体中文": return "青铜龙的祝福";
                default: return "Blessing of the Bronze";
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

        ///<summary>spell=387168</summary>
        private static string BoonOfTheCovenants_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Boon of the Covenants";
                case "Deutsch": return "Segen der Pakte";
                case "Español": return "Favor de las curias";
                case "Français": return "Faveur des congrégations";
                case "Italiano": return "Dono delle Congreghe";
                case "Português Brasileiro": return "Dádiva dos Pactos";
                case "Русский": return "Дар ковенантов";
                case "한국어": return "성약의 단의 은혜";
                case "简体中文": return "盟约恩泽";
                default: return "Boon of the Covenants";
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

        ///<summary>spell=374251</summary>
        private static string CauterizingFlame_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Cauterizing Flame";
                case "Deutsch": return "Kauterisierende Flamme";
                case "Español": return "Llama cauterizante";
                case "Français": return "Flamme de cautérisation";
                case "Italiano": return "Fiamma Cauterizzante";
                case "Português Brasileiro": return "Chama Cauterizante";
                case "Русский": return "Прижигающее пламя";
                case "한국어": return "소작의 불길";
                case "简体中文": return "灼烧之焰";
                default: return "Cauterizing Flame";
            }
        }

        ///<summary>spell=357210</summary>
        private static string DeepBreath_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Deep Breath";
                case "Deutsch": return "Tiefer Atem";
                case "Español": return "Aliento profundo";
                case "Français": return "Souffle profond";
                case "Italiano": return "Alito del Drago";
                case "Português Brasileiro": return "Respiração Profunda";
                case "Русский": return "Глубокий вдох";
                case "한국어": return "깊은 숨결";
                case "简体中文": return "深呼吸";
                default: return "Deep Breath";
            }
        }

        ///<summary>spell=356995</summary>
        private static string Disintegrate_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Disintegrate";
                case "Deutsch": return "Desintegration";
                case "Español": return "Desintegrar";
                case "Français": return "Désintégration";
                case "Italiano": return "Disintegrazione";
                case "Português Brasileiro": return "Desintegrar";
                case "Русский": return "Дезинтеграция";
                case "한국어": return "파열";
                case "简体中文": return "裂解";
                default: return "Disintegrate";
            }
        }

        ///<summary>spell=375087</summary>
        private static string Dragonrage_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dragonrage";
                case "Deutsch": return "Drachenwut";
                case "Español": return "Ira de dragón";
                case "Français": return "Rage draconique";
                case "Italiano": return "Rabbia del Drago";
                case "Português Brasileiro": return "Raiva Dragônica";
                case "Русский": return "Ярость дракона";
                case "한국어": return "용의 분노";
                case "简体中文": return "狂龙之怒";
                default: return "Dragonrage";
            }
        }

        ///<summary>spell=355913</summary>
        private static string EmeraldBlossom_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Emerald Blossom";
                case "Deutsch": return "Smaragdblüte";
                case "Español": return "Flor esmeralda";
                case "Français": return "Arbre d’émeraude";
                case "Italiano": return "Bocciolo di Smeraldo";
                case "Português Brasileiro": return "Flor de Esmeralda";
                case "Русский": return "Изумрудный цветок";
                case "한국어": return "에메랄드 꽃";
                case "简体中文": return "翡翠之花";
                default: return "Emerald Blossom";
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

        ///<summary>spell=382411</summary>
        private static string EternitySurge_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Eternity Surge";
                case "Deutsch": return "Ewigkeitswoge";
                case "Español": return "Oleada de eternidad";
                case "Français": return "Afflux d’éternité";
                case "Italiano": return "Impeto dell'Eternità";
                case "Português Brasileiro": return "Surto da Eternidade";
                case "Русский": return "Всплеск вечности";
                case "한국어": return "영원의 쇄도";
                case "简体中文": return "永恒之涌";
                default: return "Eternity Surge";
            }
        }

        ///<summary>spell=365585</summary>
        private static string Expunge_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Expunge";
                case "Deutsch": return "Entgiften";
                case "Español": return "Expurgar";
                case "Français": return "Éliminer";
                case "Italiano": return "Espulsione";
                case "Português Brasileiro": return "Expungir";
                case "Русский": return "Нейтрализация";
                case "한국어": return "말소";
                case "简体中文": return "净除";
                default: return "Expunge";
            }
        }

        ///<summary>spell=382266</summary>
        private static string FireBreath_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fire Breath";
                case "Deutsch": return "Feueratem";
                case "Español": return "Aliento de Fuego";
                case "Français": return "Souffle de feu";
                case "Italiano": return "Soffio di Fuoco";
                case "Português Brasileiro": return "Sopro de Fogo";
                case "Русский": return "Огненное дыхание";
                case "한국어": return "불의 숨결";
                case "简体中文": return "火焰吐息";
                default: return "Fire Breath";
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

        ///<summary>spell=368847</summary>
        private static string Firestorm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Firestorm";
                case "Deutsch": return "Feuersturm";
                case "Español": return "Tormenta de Fuego";
                case "Français": return "Tempête-de-feu";
                case "Italiano": return "Tempesta di Fuoco";
                case "Português Brasileiro": return "Tempestade de Fogo";
                case "Русский": return "Огненная буря";
                case "한국어": return "화염폭풍";
                case "简体中文": return "火焰风暴";
                default: return "Firestorm";
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

        ///<summary>spell=358267</summary>
        private static string Hover_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Hover";
                case "Deutsch": return "Schweben";
                case "Español": return "Flotar";
                case "Français": return "Survoler";
                case "Italiano": return "Volo Sospeso";
                case "Português Brasileiro": return "Pairar";
                case "Русский": return "Бреющий полет";
                case "한국어": return "부양";
                case "简体中文": return "悬空";
                default: return "Hover";
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

        ///<summary>spell=358385</summary>
        private static string Landslide_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Landslide";
                case "Deutsch": return "Erdrutsch";
                case "Español": return "Derrumbamiento";
                case "Français": return "Glissement de terrain";
                case "Italiano": return "Smottamento";
                case "Português Brasileiro": return "Soterramento";
                case "Русский": return "Сель";
                case "한국어": return "산사태";
                case "简体中文": return "山崩";
                default: return "Landslide";
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

        ///<summary>spell=361469</summary>
        private static string LivingFlame_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Living Flame";
                case "Deutsch": return "Lebende Flamme";
                case "Español": return "Llama viva";
                case "Français": return "Flamme vivante";
                case "Italiano": return "Fiamma Vivente";
                case "Português Brasileiro": return "Chama Viva";
                case "Русский": return "Живой жар";
                case "한국어": return "살아있는 불꽃";
                case "简体中文": return "活化烈焰";
                default: return "Living Flame";
            }
        }

        ///<summary>spell=363916</summary>
        private static string ObsidianScales_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Obsidian Scales";
                case "Deutsch": return "Obsidianschuppen";
                case "Español": return "Escamas obsidiana";
                case "Français": return "Écailles d’obsidienne";
                case "Italiano": return "Scaglie d'Ossidiana";
                case "Português Brasileiro": return "Escamas de Obsidiana";
                case "Русский": return "Обсидиановая чешуя";
                case "한국어": return "흑요석 비늘";
                case "简体中文": return "黑曜鳞片";
                default: return "Obsidian Scales";
            }
        }

        ///<summary>spell=372048</summary>
        private static string OppressingRoar_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Oppressing Roar";
                case "Deutsch": return "Tyrannisierendes Brüllen";
                case "Español": return "Rugido opresor";
                case "Français": return "Rugissement oppressant";
                case "Italiano": return "Ruggito Opprimente";
                case "Português Brasileiro": return "Rugido Opressivo";
                case "Русский": return "Угнетающий рык";
                case "한국어": return "탄압의 포효";
                case "简体中文": return "压迫怒吼";
                default: return "Oppressing Roar";
            }
        }

        ///<summary>spell=357211</summary>
        private static string Pyre_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Pyre";
                case "Deutsch": return "Scheiterhaufen";
                case "Español": return "Pira";
                case "Français": return "Bûcher";
                case "Italiano": return "Pira";
                case "Português Brasileiro": return "Pira";
                case "Русский": return "Погребальный костер";
                case "한국어": return "기염";
                case "简体中文": return "葬火";
                default: return "Pyre";
            }
        }

        ///<summary>spell=351338</summary>
        private static string Quell_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Quell";
                case "Deutsch": return "Unterdrücken";
                case "Español": return "Sofocar";
                case "Français": return "Apaisement";
                case "Italiano": return "Sedazione";
                case "Português Brasileiro": return "Supressão";
                case "Русский": return "Подавление";
                case "한국어": return "진압";
                case "简体中文": return "镇压";
                default: return "Quell";
            }
        }

        ///<summary>spell=374348</summary>
        private static string RenewingBlaze_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Renewing Blaze";
                case "Deutsch": return "Erneuernde Flammen";
                case "Español": return "Llamarada de renovación";
                case "Français": return "Brasier de rénovation";
                case "Italiano": return "Fiammata Curativa";
                case "Português Brasileiro": return "Labareda Renovadora";
                case "Русский": return "Обновляющее пламя";
                case "한국어": return "소생의 불길";
                case "简体中文": return "新生光焰";
                default: return "Renewing Blaze";
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

        ///<summary>spell=370452</summary>
        private static string ShatteringStar_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shattering Star";
                case "Deutsch": return "Zerschmetternder Stern";
                case "Español": return "Estrella devastadora";
                case "Français": return "Étoile fracassante";
                case "Italiano": return "Stella Frantumante";
                case "Português Brasileiro": return "Estrela Estilhaçante";
                case "Русский": return "Сокрушающая звезда";
                case "한국어": return "산산이 부서지는 별";
                case "简体中文": return "碎裂星辰";
                default: return "Shattering Star";
            }
        }

        ///<summary>spell=360806</summary>
        private static string SleepWalk_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sleep Walk";
                case "Deutsch": return "Schlafwandeln";
                case "Español": return "Sonambulismo";
                case "Français": return "Somnambulisme";
                case "Italiano": return "Sonnambulismo";
                case "Português Brasileiro": return "Sonambulismo";
                case "Русский": return "Лунатизм";
                case "한국어": return "몽유병";
                case "简体中文": return "梦游";
                default: return "Sleep Walk";
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

        ///<summary>spell=368970</summary>
        private static string TailSwipe_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Tail Swipe";
                case "Deutsch": return "Schwanzfeger";
                case "Español": return "Flagelo de cola";
                case "Français": return "Claque caudale";
                case "Italiano": return "Spazzata di Coda";
                case "Português Brasileiro": return "Revés com a Cauda";
                case "Русский": return "Удар хвостом";
                case "한국어": return "꼬리 휘둘러치기";
                case "简体中文": return "扫尾";
                default: return "Tail Swipe";
            }
        }

        ///<summary>spell=374968</summary>
        private static string TimeSpiral_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Time Spiral";
                case "Deutsch": return "Zeitspirale";
                case "Español": return "Espiral temporal";
                case "Français": return "Spirale temporelle";
                case "Italiano": return "Spirale Temporale";
                case "Português Brasileiro": return "Espiral do Tempo";
                case "Русский": return "Спираль времени";
                case "한국어": return "시간의 와류";
                case "简体中文": return "时间螺旋";
                default: return "Time Spiral";
            }
        }

        ///<summary>spell=370553</summary>
        private static string TipTheScales_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Tip the Scales";
                case "Deutsch": return "Zeitdruck";
                case "Español": return "Inclinar la balanza";
                case "Français": return "Retour de bâton";
                case "Italiano": return "Ago della Bilancia";
                case "Português Brasileiro": return "Jogo Virado";
                case "Русский": return "Смещение равновесия";
                case "한국어": return "전세역전";
                case "简体中文": return "扭转天平";
                default: return "Tip the Scales";
            }
        }

        ///<summary>spell=368432</summary>
        private static string Unravel_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Unravel";
                case "Deutsch": return "Zunichte machen";
                case "Español": return "Deshacer";
                case "Français": return "Fragilisation magique";
                case "Italiano": return "Disvelamento";
                case "Português Brasileiro": return "Desvelar";
                case "Русский": return "Разрушение магии";
                case "한국어": return "해체";
                case "简体中文": return "拆解";
                default: return "Unravel";
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

        ///<summary>spell=357214</summary>
        private static string WingBuffet_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Wing Buffet";
                case "Deutsch": return "Flügelstoß";
                case "Español": return "Sacudida de alas";
                case "Français": return "Frappe des ailes";
                case "Italiano": return "Battito d'Ali";
                case "Português Brasileiro": return "Bofetada de Asa";
                case "Русский": return "Взмах крыльями";
                case "한국어": return "폭풍 날개";
                case "简体中文": return "飞翼打击";
                default: return "Wing Buffet";
            }
        }

        ///<summary>spell=374227</summary>
        private static string Zephyr_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Zephyr";
                case "Deutsch": return "Zephyr";
                case "Español": return "Céfiro";
                case "Français": return "Zéphyr";
                case "Italiano": return "Zefiro";
                case "Português Brasileiro": return "Zéfiro";
                case "Русский": return "Южный ветер";
                case "한국어": return "미풍";
                case "简体中文": return "微风";
                default: return "Zephyr";
            }
        }
        #endregion

        #region Variables
        string FiveLetters;
        #endregion

        #region Lists
        //Lists
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle", "NoExpunge", "NoCauterizingFlame", "DeepBreath", "DeepBreathCursor", "QueueLandslide", "SleepWalk", "QueueFirestorm", "FirestormCursor" };
        private List<string> m_DebuffsList;
        private List<string> m_BuffsList;
        private List<string> m_ItemsList;
        private List<string> m_SpellBook;

        private List<string> m_RaceList = new List<string> { "Dracthyr" };

        private List<string> m_CastingList = new List<string> { "Manual", "Cursor", "Player" };

        private List<int> Torghast_InnerFlame = new List<int> { 258935, 258938, 329422, 329423, };

        List<double> Stages = new List<double>
        {
            0,
            1,
            1.75,
            2.5,
            3.25,
        };

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

            //Queues
            Macros.Add("LandslideOff", "/" + FiveLetters + " QueueLandslide");
            Macros.Add("SleepWalkOff", "/" + FiveLetters + " SleepWalk");
            Macros.Add("DeepBreathOff", "/" + FiveLetters + " DeepBreath");
            Macros.Add("FirestormOff", "/" + FiveLetters + " QueueFirestorm");

            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");
            Macros.Add("Expunge_FOC", "/cast [@focus] " + Expunge_SpellName(Language));
            Macros.Add("CF_FOC", "/cast [@focus] " + CauterizingFlame_SpellName(Language));
            Macros.Add("EB_FOC", "/cast [@focus] " + EmeraldBlossom_SpellName(Language));

            Macros.Add("SleepWalkMO", "/cast [@mouseover] " + SleepWalk_SpellName(Language));
            Macros.Add("DeepBreathC", "/cast [@cursor] " + DeepBreath_SpellName(Language));
            Macros.Add("DeepBreathP", "/cast [@player] " + DeepBreath_SpellName(Language));
            Macros.Add("FirestormC", "/cast [@cursor] " + Firestorm_SpellName(Language));
            Macros.Add("FirestormP", "/cast [@player] " + Firestorm_SpellName(Language));
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

            CustomFunctions.Add("EmpowermentCheck", "local loading, finished = IsAddOnLoaded(\"Hekili\")\nif loading == true and finished == true then\n    local id,empowermentStage,_=Hekili_GetRecommendedAbility(\"Primary\",1)\n    if id ~= nil and empowermentStage ~= nil then\n        return empowermentStage\n    end\nend\nreturn 0");

            CustomFunctions.Add("DeepBreathMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Fireball','mouseover') == 1 then return 1 end; return 0");

            CustomFunctions.Add("FirestormMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Fireball','mouseover') == 1 then return 1 end; return 0");

            CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
            "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
            "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
            "\nreturn foc");

            CustomFunctions.Add("PoisonCheck", "local y=0; " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"player\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Poison\" then y = y +1; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Poison\" then y = y +2; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Poison\" then y = y +4; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Poison\" then y = y +8; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Poison\" then y = y +16; end end " +
            "return y");

            CustomFunctions.Add("CursePoisonBleedDiseaseCheck", "local y=0; " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"player\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" or type == \"Poison\" or type == \"Bleed\" or type == \"Disease\" then y = y +1; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" or type == \"Poison\" or type == \"Bleed\" or type == \"Disease\" then y = y +2; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" or type == \"Poison\" or type == \"Bleed\" or type == \"Disease\" then y = y +4; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" or type == \"Poison\" or type == \"Bleed\" or type == \"Disease\" then y = y +8; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Curse\" or type == \"Poison\" or type == \"Bleed\" or type == \"Disease\" then y = y +16; end end " +
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

            CustomFunctions.Add("GetTalentImminentDestruction", "if (IsSpellKnown(370781) or IsPlayerSpell(370781)) then return 1 else return 0 end");

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
            Settings.Add(new Setting("Race:", m_RaceList, "Dracthyr"));
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
            Settings.Add(new Setting("Blessing of the Bronze Out of Combat:", true));
            Settings.Add(new Setting("Auto Zephyr @ HP%", 0, 100, 20));
            Settings.Add(new Setting("Auto Renewing Blaze @ HP%", 0, 100, 35));
            Settings.Add(new Setting("Auto Obsidian Scales @ HP%", 0, 100, 30));
            Settings.Add(new Setting("Auto Emerald Blossom @ HP%", 0, 100, 50));
            Settings.Add(new Setting("Deep Breath Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Always Cast Deep Breath @ Cursor during Rotation", false));
            Settings.Add(new Setting("Firestorm Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Always Cast Firestorm @ Cursor during Rotation", false));
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

            Aimsharp.PrintMessage("Epic PVE - Evoker Devastation", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/evoker/devastation/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoExpunge - Disables Auto Expunge on Group/Raid Members.", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCauterizingFlame - Disables Auto Cauterizing Flame on Group/Raid Members.", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " SleepWalk - Casts Sleep Walk @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " QueueLandslide - Queue Landslide on the next GCD.", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " DeepBreath - Queue Deep Breath on the next GCD.", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " DeepBreathCursor - Always cast Deep Breath on Cursor during the Rotation.", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " QueueFirestorm - Queue Firestorm on the next GCD.", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FirestormCursor - Always cast Firestorm on Cursor during the Rotation.", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);

            Language = GetDropDown("Game Client Language");

            #region Racial Spells
            if (GetDropDown("Race:") == "f")
            {
                Spellbook.Add(TailSwipe_SpellName(Language)); //368970
                Spellbook.Add(WingBuffet_SpellName(Language)); //357214
            }
            #endregion

            #region Reinitialize Lists
            m_DebuffsList = new List<string> { SleepWalk_SpellName(Language), };
            m_BuffsList = new List<string> { BlessingOfTheBronze_SpellName(Language), };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language), };
            m_SpellBook = new List<string> {
                //INTERRUPT ON TARGET or cursor?
                Quell_SpellName(Language), //351338

                //DISPELL ON TARGET or cursor?
                CauterizingFlame_SpellName(Language), //374251
                Expunge_SpellName(Language), //365585

                //DPS
                //ON TARGET
                AzureStrike_SpellName(Language), //362969
                Disintegrate_SpellName(Language), //356995
                LivingFlame_SpellName(Language), //361469
                Unravel_SpellName(Language), //368432
                EternitySurge_SpellName(Language), //382411
                Pyre_SpellName(Language), //357211
                ShatteringStar_SpellName(Language), //370452
                //ON CURSOR
                DeepBreath_SpellName(Language), //357210
                Firestorm_SpellName(Language), //368847
                //ON PLAYER
                Dragonrage_SpellName(Language), //375087
                FireBreath_SpellName(Language), //382266

                //CC
                //ON TARGET
                SleepWalk_SpellName(Language), //360806

                //ON CURSOR
                Landslide_SpellName(Language), //358385

                //CD
                //BUFF
                //ON PLAYER
                BlessingOfTheBronze_SpellName(Language), //364342
                Hover_SpellName(Language), //358267
                OppressingRoar_SpellName(Language), //372048
                TimeSpiral_SpellName(Language), //374968
                TipTheScales_SpellName(Language), //370553
                BoonOfTheCovenants_SpellName(Language), //387168

                //DEFENSIVE
                //ON PLAYER
                ObsidianScales_SpellName(Language), //363916
                RenewingBlaze_SpellName(Language), //374348
                Zephyr_SpellName(Language), //374227

                //HEAL ON PLAYER:
                EmeraldBlossom_SpellName(Language), //355913

            };
            #endregion

            InitializeMacros();

            InitializeSpells();

            InitializeCustomLUAFunctions();
        }

        private int EmpowerState()
        {
            int EmpowerStateNew = Aimsharp.CustomFunction("EmpowermentCheck");
            if (EmpowerStateNow != EmpowerStateNew && EmpowerStateNew != 0)
            {
                EmpowerStateNow = EmpowerStateNew;
            }
            return EmpowerStateNow;
        }

        public override bool CombatTick()
        {
            #region Declarations
            int SpellID1 = Aimsharp.CustomFunction("HekiliID1");
            int CooldownsToggle = Aimsharp.CustomFunction("CooldownsToggleCheck");
            int Wait = Aimsharp.CustomFunction("HekiliWait");
            int Enemies = Aimsharp.CustomFunction("HekiliEnemies");
            int TargetingGroup = Aimsharp.CustomFunction("GroupTargets");
            int Haste = (int)Aimsharp.Haste();

            EmpowerState();

            // Calculating Empowered Cast Time
            double EmpowerCastTime;
            if (Aimsharp.HasBuff(TipTheScales_SpellName(Language), "player"))
            {
                EmpowerCastTime = 0;
            }
            else
            {
                EmpowerCastTime = (double)((1 - (0.2 * Aimsharp.CustomFunction("GetTalentImminentDestruction"))) * Stages[(EmpowerState())] * (1 - (Haste / 100)) * 1000);
            }

            bool NoInterrupts = Aimsharp.IsCustomCodeOn("NoInterrupts");
            bool NoExpunge = Aimsharp.IsCustomCodeOn("NoExpunge");
            bool NoCauterizingFlame = Aimsharp.IsCustomCodeOn("NoCauterizingFlame");
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
            if (SpellID1 == 362969 && Aimsharp.CanCast(AzureStrike_SpellName(Language), "target", true, false) && Aimsharp.CustomFunction("HekiliWait") <= 200)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Azure Strike - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(AzureStrike_SpellName(Language), true);
                return true;
            }

            if (SpellID1 == 375087 && Aimsharp.CanCast(Dragonrage_SpellName(Language), "player", false, false) && Aimsharp.CustomFunction("HekiliWait") <= 200)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Dragonrage - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(Dragonrage_SpellName(Language), true);
                return true;
            }

            if (Aimsharp.CastingID("player") == 358385 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("QueueLandslide"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Landslide Queue", Color.Purple);
                }
                Aimsharp.Cast("LandslideOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 357210 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("DeepBreath"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Deep Breath Queue", Color.Purple);
                }
                Aimsharp.Cast("DeepBreathOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 360806 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("SleepWalk"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sleep Walk Queue", Color.Purple);
                }
                Aimsharp.Cast("SleepWalkOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 368847 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("QueueFirestorm"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Firestorm Queue", Color.Purple);
                }
                Aimsharp.Cast("FirestormOff");
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

            if (Aimsharp.IsCustomCodeOn("DeepBreath") && Aimsharp.SpellCooldown(DeepBreath_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("QueueFirestorm") && Aimsharp.SpellCooldown(Firestorm_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                if (Aimsharp.CanCast(Quell_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Quell_SpellName(Language), true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast(Quell_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Quell_SpellName(Language), true);
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

            //Auto Obsidian Scales
            if (Aimsharp.CanCast(ObsidianScales_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Obsidian Scales @ HP%"))
                {
                    Aimsharp.Cast(ObsidianScales_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Obsidian Scales - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Obsidian Scales @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Renewing Blaze
            if (Aimsharp.CanCast(RenewingBlaze_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Renewing Blaze @ HP%"))
                {
                    Aimsharp.Cast(RenewingBlaze_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Renewing Blaze - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Renewing Blaze @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Emerald Blossom
            if (Aimsharp.CanCast(EmeraldBlossom_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Emerald Blossom @ HP%"))
                {
                    Aimsharp.Cast(EmeraldBlossom_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Emerald Blossom - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Emerald Blossom @ HP%"), Color.Black);
                    }
                    return true;
                }
            }

            //Auto Zephyr
            if (Aimsharp.CanCast(Zephyr_SpellName(Language), "player", false, true))
            {
                if (PlayerHP <= GetSlider("Auto Zephyr @ HP%"))
                {
                    Aimsharp.Cast(Zephyr_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Zephyr - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Zephyr @ HP%"), Color.Purple);
                    }
                    return true;
                }
            }
            #endregion

            #region Queues
            bool SleepWalk = Aimsharp.IsCustomCodeOn("SleepWalk");
            if ((Aimsharp.CastingID("player") == 360806 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && SleepWalk)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sleep Walk Queue", Color.Purple);
                }
                Aimsharp.Cast("SleepWalkOff");
                return true;
            }

            if (SleepWalk && Aimsharp.CanCast(SleepWalk_SpellName(Language), "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Sleep Walk - Queue", Color.Purple);
                }
                Aimsharp.Cast("SleepWalkMO");
                return true;
            }

            bool Landslide = Aimsharp.IsCustomCodeOn("QueueLandslide");
            if ((Aimsharp.CastingID("player") == 358385 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Landslide)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Landslide Queue", Color.Purple);
                }
                Aimsharp.Cast("LandslideOff");
                return true;
            }

            //Queue Deep Breath
            string DeepBreathCast = GetDropDown("Deep Breath Cast:");
            bool DeepBreath = Aimsharp.IsCustomCodeOn("DeepBreath");
            if ((Aimsharp.SpellCooldown(DeepBreath_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving || Aimsharp.LastCast() == DeepBreath_SpellName(Language)) && DeepBreath)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Deep Breath Queue", Color.Purple);
                }
                Aimsharp.Cast("DeepBreathOff");
                return true;
            }

            if (DeepBreath && Aimsharp.CanCast(DeepBreath_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (DeepBreathCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Deep Breath - " + DeepBreathCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(DeepBreath_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Deep Breath - " + DeepBreathCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DeepBreathP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Deep Breath - " + DeepBreathCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DeepBreathC");
                        return true;
                }
            }

            //Queue Firestorm
            string FirestormCast = GetDropDown("Firestorm Cast:");
            bool Firestorm = Aimsharp.IsCustomCodeOn("QueueFirestorm");
            if ((Aimsharp.SpellCooldown(Firestorm_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving || Aimsharp.LastCast() == Firestorm_SpellName(Language)) && Firestorm)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Firestorm Queue", Color.Purple);
                }
                Aimsharp.Cast("FirestormOff");
                return true;
            }

            if (Firestorm && Aimsharp.CanCast(Firestorm_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (FirestormCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Firestorm - " + FirestormCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Firestorm_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Firestorm - " + FirestormCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FirestormP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Firestorm - " + FirestormCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FirestormC");
                        return true;
                }
            }
            #endregion

            #region Emerald Blossom
            if (UnitBelowThreshold(GetSlider("Auto Emerald Blossom @ HP%")) && Aimsharp.CanCast(EmeraldBlossom_SpellName(Language), "player", false, true))
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
                    if (Aimsharp.CanCast(EmeraldBlossom_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && Aimsharp.Health(unit.Key) <= GetSlider("Auto Emerald Blossom @ HP%"))
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
                                Aimsharp.Cast("EB_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Emerald Blossom @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Remove Poison
            if (!NoExpunge && Aimsharp.CustomFunction("PoisonCheck") > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != Expunge_SpellName(Language))
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

                int states = Aimsharp.CustomFunction("PoisonCheck");
                CleansePlayers target;

                int KickTimer = GetRandomNumber(200, 800);

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast(Expunge_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
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
                                Aimsharp.Cast("Expunge_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Remove Poison @ " + unit.Key + " - " + unit.Value, Color.Purple);
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Remove Bleed, Poison, Disease, Curse
            if (!NoCauterizingFlame && Aimsharp.CustomFunction("CursePoisonBleedDiseaseCheck") > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != CauterizingFlame_SpellName(Language))
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

                int states = Aimsharp.CustomFunction("CursePoisonBleedDiseaseCheck");
                CleansePlayers target;

                int KickTimer = GetRandomNumber(200, 800);

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast(CauterizingFlame_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
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
                                Aimsharp.Cast("CF_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Remove Curse, Poison, Bleed or Disease @ " + unit.Key + " - " + unit.Value, Color.Purple);
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
                if (Aimsharp.Range("target") <= 40 && !Aimsharp.HasDebuff(SleepWalk_SpellName(Language), "target", true) && !Aimsharp.HasDebuff(Landslide_SpellName(Language), "target", true) && !Landslide)
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

                    if (SpellID1 == 368970 && Aimsharp.CanCast(TailSwipe_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tail Swipe - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TailSwipe_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 357214 && Aimsharp.CanCast(WingBuffet_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wing Buffet - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(WingBuffet_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Covenants
                    ///Covenants
                    if (SpellID1 == 387168 && Aimsharp.CanCast(BoonOfTheCovenants_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Boon of the Covenants - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(BoonOfTheCovenants_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - No GCD
                    ///Class Spells
                    //Target - No GCD
                    if (SpellID1 == 351338 && Aimsharp.CanCast(Quell_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Quell- " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Quell_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    //Target - GCD
                    if (SpellID1 == 356995 && Aimsharp.CanCast(Disintegrate_SpellName(Language), "target", true, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Disintegrate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Disintegrate_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 383121 && Aimsharp.CanCast(Landslide_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Landslide - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(Landslide_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 361469 && Aimsharp.CanCast(LivingFlame_SpellName(Language), "target", true, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Living Flame - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(LivingFlame_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    if (SpellID1 == 370553 && Aimsharp.CanCast(TipTheScales_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tip the Scales - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TipTheScales_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 364342 && Aimsharp.CanCast(BlessingOfTheBronze_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blessing of the Bronze - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BlessingOfTheBronze_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 358267 && Aimsharp.CanCast(Hover_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Hover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Hover_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 374968 && Aimsharp.CanCast(TimeSpiral_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Time Spiral - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(TimeSpiral_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 358385 && Aimsharp.CanCast(Landslide_SpellName(Language), "player", true, true) && !Moving)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Landslide - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Landslide_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 363916 && Aimsharp.CanCast(ObsidianScales_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Obsidian Scales - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ObsidianScales_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 372048 && Aimsharp.CanCast(OppressingRoar_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Oppressing Roar - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(OppressingRoar_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 365585 && Aimsharp.CanCast(Expunge_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Expunge - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Expunge_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 374251 && Aimsharp.CanCast(CauterizingFlame_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cauterizing Flame - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(CauterizingFlame_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Fire Spells - Player GCD
                    if (SpellID1 == 235313 && Aimsharp.CanCast(Zephyr_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Zephyr - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Zephyr_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 375087 && Aimsharp.CanCast(Dragonrage_SpellName(Language), "player", false, false))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Dragonrage - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Dragonrage_SpellName(Language), true);
                        return true;
                    }

                    if ((SpellID1 == 382266 || SpellID1 == 357208 || SpellID1 == 357209) && Aimsharp.CanCast(FireBreath_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Start casting Fire Breath - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FireBreath_SpellName(Language));
                        if (EmpowerCastTime != 0)
                        {
                            System.Threading.Thread.Sleep((int)EmpowerCastTime);
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Casting Fire Breath again for Empower State: " + EmpowerState(), Color.Purple);
                            }
                            Aimsharp.Cast(FireBreath_SpellName(Language));
                        }
                        return true;
                    }

                    if (SpellID1 == 357210 && Aimsharp.CanCast(DeepBreath_SpellName(Language), "player", false, true) && (Aimsharp.CustomFunction("DeepBreathMouseover") == 1 || GetCheckBox("Always Cast Deep Breath @ Cursor during Rotation") || Aimsharp.IsCustomCodeOn("DeepBreathCursor")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Deep Breath @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("DeepBreathC");
                        return true;
                    }
                    else if (SpellID1 == 357210 && Aimsharp.CanCast(DeepBreath_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Deep Breath - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DeepBreath_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 368847 && Aimsharp.CanCast(Firestorm_SpellName(Language), "player", false, true) && (Aimsharp.CustomFunction("FirestormMouseover") == 1 || GetCheckBox("Always Cast Firestorm @ Cursor during Rotation") || Aimsharp.IsCustomCodeOn("FirestormCursor")))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Firestorm @ Cursor due to Mouseover - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast("FirestormC");
                        return true;
                    }
                    else if (SpellID1 == 368847 && Aimsharp.CanCast(Firestorm_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Firestorm - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Firestorm_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Fire Spells - Target GCD
                    if (SpellID1 == 368432 && Aimsharp.CanCast(Unravel_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Unravel - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Unravel_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 362969 && Aimsharp.CanCast(AzureStrike_SpellName(Language), "target", true, false))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Azure Strike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AzureStrike_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 357211 && Aimsharp.CanCast(Pyre_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Pyre - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Pyre_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 382411 || SpellID1 == 359073) && Aimsharp.CanCast(EternitySurge_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Start casting Eternity Surge - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(EternitySurge_SpellName(Language));
                        if (EmpowerCastTime != 0)
                        {
                            System.Threading.Thread.Sleep((int)EmpowerCastTime);
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Casting Fire Breath again for Empower State: " + EmpowerState(), Color.Purple);
                            }
                            Aimsharp.Cast(EternitySurge_SpellName(Language));
                        }
                        return true;
                    }

                    if (SpellID1 == 370452 && Aimsharp.CanCast(ShatteringStar_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shattering Star - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ShatteringStar_SpellName(Language));
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
            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());
            bool Moving = Aimsharp.PlayerIsMoving();
            bool BOTBOOC = GetCheckBox("Blessing of the Bronze Out of Combat:");
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
            if (SpellID1 == 375087 && Aimsharp.CanCast(Dragonrage_SpellName(Language), "player", false, false) && Aimsharp.CustomFunction("HekiliWait") <= 200)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Dragonrage - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(Dragonrage_SpellName(Language), true);
                return true;
            }

            if (Aimsharp.CastingID("player") == 358385 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("QueueLandslide"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Landslide Queue", Color.Purple);
                }
                Aimsharp.Cast("LandslideOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 357210 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("DeepBreath"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Deep Breath Queue", Color.Purple);
                }
                Aimsharp.Cast("DeepBreathOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 360806 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("SleepWalk"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sleep Walk Queue", Color.Purple);
                }
                Aimsharp.Cast("SleepWalkOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 368847 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("QueueFirestorm"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Firestorm Queue", Color.Purple);
                }
                Aimsharp.Cast("FirestormOff");
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

            if (Aimsharp.IsCustomCodeOn("DeepBreath") && Aimsharp.SpellCooldown(DeepBreath_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("QueueFirestorm") && Aimsharp.SpellCooldown(Firestorm_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            bool SleepWalk = Aimsharp.IsCustomCodeOn("SleepWalk");
            if ((Aimsharp.CastingID("player") == 360806 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && SleepWalk)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Sleep Walk Queue", Color.Purple);
                }
                Aimsharp.Cast("SleepWalkOff");
                return true;
            }

            if (SleepWalk && Aimsharp.CanCast(SleepWalk_SpellName(Language), "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Sleep Walk - Queue", Color.Purple);
                }
                Aimsharp.Cast("SleepWalkMO");
                return true;
            }

            bool Landslide = Aimsharp.IsCustomCodeOn("QueueLandslide");
            if ((Aimsharp.CastingID("player") == 358385 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 || Moving) && Landslide)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Landslide Queue", Color.Purple);
                }
                Aimsharp.Cast("LandslideOff");
                return true;
            }

            //Queue Deep Breath
            string DeepBreathCast = GetDropDown("Deep Breath Cast:");
            bool DeepBreath = Aimsharp.IsCustomCodeOn("DeepBreath");
            if ((Aimsharp.SpellCooldown(DeepBreath_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving || Aimsharp.LastCast() == DeepBreath_SpellName(Language)) && DeepBreath)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Deep Breath Queue", Color.Purple);
                }
                Aimsharp.Cast("DeepBreathOff");
                return true;
            }

            if (DeepBreath && Aimsharp.CanCast(DeepBreath_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (DeepBreathCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Deep Breath - " + DeepBreathCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(DeepBreath_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Deep Breath - " + DeepBreathCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DeepBreathP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Deep Breath - " + DeepBreathCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("DeepBreathC");
                        return true;
                }
            }
            //Queue Firestorm
            string FirestormCast = GetDropDown("Firestorm Cast:");
            bool Firestorm = Aimsharp.IsCustomCodeOn("QueueFirestorm");
            if ((Aimsharp.SpellCooldown(Firestorm_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving || Aimsharp.LastCast() == Firestorm_SpellName(Language)) && Firestorm)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Firestorm Queue", Color.Purple);
                }
                Aimsharp.Cast("FirestormOff");
                return true;
            }

            if (Firestorm && Aimsharp.CanCast(Firestorm_SpellName(Language), "player", false, true) && !Moving)
            {
                switch (FirestormCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Firestorm - " + FirestormCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(Firestorm_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Firestorm - " + FirestormCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FirestormP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Firestorm - " + FirestormCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("FirestormC");
                        return true;
                }
            }
            #endregion

            #region Out of Combat Spells
            if (SpellID1 == 364342 && Aimsharp.CanCast(BlessingOfTheBronze_SpellName(Language), "player", false, true) && BOTBOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of the Bronze (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(BlessingOfTheBronze_SpellName(Language));
                return true;
            }

            if (Aimsharp.CanCast(BlessingOfTheBronze_SpellName(Language), "player", false, true) && !Aimsharp.HasBuff(BlessingOfTheBronze_SpellName(Language), "player", true) && BOTBOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Blessing of the Bronze (Out of Combat) - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(BlessingOfTheBronze_SpellName(Language));
                return true;
            }
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 40 && TargetInCombat && !Aimsharp.HasDebuff(SleepWalk_SpellName(Language), "target", true) && !Aimsharp.HasDebuff(Landslide_SpellName(Language), "target", true) && !Landslide)
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