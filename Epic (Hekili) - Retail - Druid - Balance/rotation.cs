using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicDruidBalanceHekili : Rotation
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
        ///<summary>spell=325733</summary>
        private static string AdaptiveSwarm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Adaptive Swarm";
                case "Deutsch": return "Adaptiver Schwarm";
                case "Español": return "Enjambre adaptable";
                case "Français": return "Essaim adaptatif";
                case "Italiano": return "Sciame Adattivo";
                case "Português Brasileiro": return "Enxame Adaptável";
                case "Русский": return "Адаптивный рой";
                case "한국어": return "적응의 무리";
                case "简体中文": return "激变蜂群";
                default: return "Adaptive Swarm";
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

        ///<summary>spell=202359</summary>
        private static string AstralCommunion_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Astral Communion";
                case "Deutsch": return "Astrale Vereinigung";
                case "Español": return "Comunión astral";
                case "Français": return "Communion astrale";
                case "Italiano": return "Comunione Astrale";
                case "Português Brasileiro": return "Comunhão Astral";
                case "Русский": return "Астральное единение";
                case "한국어": return "천공의 교감";
                case "简体中文": return "沟通星界";
                default: return "Astral Communion";
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

        ///<summary>spell=22812</summary>
        private static string Barkskin_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Barkskin";
                case "Deutsch": return "Baumrinde";
                case "Español": return "Piel de corteza";
                case "Français": return "Ecorce";
                case "Italiano": return "Pelledura";
                case "Português Brasileiro": return "Pele de Árvore";
                case "Русский": return "Дубовая кожа";
                case "한국어": return "나무 껍질";
                case "简体中文": return "树皮术";
                default: return "Barkskin";
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

        ///<summary>spell=5487</summary>
        private static string BearForm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bear Form";
                case "Deutsch": return "Bärengestalt";
                case "Español": return "Forma de oso";
                case "Français": return "Forme d'ours";
                case "Italiano": return "Forma d'Orso";
                case "Português Brasileiro": return "Forma de Urso";
                case "Русский": return "Облик медведя";
                case "한국어": return "곰 변신";
                case "简体中文": return "熊形态";
                default: return "Bear Form";
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

        ///<summary>spell=768</summary>
        private static string CatForm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Cat Form";
                case "Deutsch": return "Katzengestalt";
                case "Español": return "Forma felina";
                case "Français": return "Forme de félin";
                case "Italiano": return "Forma Felina";
                case "Português Brasileiro": return "Forma de Felino";
                case "Русский": return "Облик кошки";
                case "한국어": return "표범 변신";
                case "简体中文": return "猎豹形态";
                default: return "Cat Form";
            }
        }

        ///<summary>spell=383410</summary>
        private static string CelestialAlignment_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Celestial Alignment";
                case "Deutsch": return "Himmlische Ausrichtung";
                case "Español": return "Alineación celestial";
                case "Français": return "Alignement céleste";
                case "Italiano": return "Allineamento Celeste";
                case "Português Brasileiro": return "Alinhamento Celestial";
                case "Русский": return "Парад планет";
                case "한국어": return "천체의 정렬";
                case "简体中文": return "超凡之盟";
                default: return "Celestial Alignment";
            }
        }

        ///<summary>spell=391528</summary>
        private static string ConvokeTheSpirits_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Convoke the Spirits";
                case "Deutsch": return "Konvokation der Geister";
                case "Español": return "Convocar a los espíritus";
                case "Français": return "Convoquer les esprits";
                case "Italiano": return "Convocazione degli Spiriti";
                case "Português Brasileiro": return "Convocar Espíritos";
                case "Русский": return "Созыв духов";
                case "한국어": return "영혼 소집";
                case "简体中文": return "万灵之召";
                default: return "Convoke the Spirits";
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

        ///<summary>spell=33786</summary>
        private static string Cyclone_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Cyclone";
                case "Deutsch": return "Wirbelsturm";
                case "Español": return "Ciclón";
                case "Français": return "Cyclone";
                case "Italiano": return "Ciclone";
                case "Português Brasileiro": return "Ciclone";
                case "Русский": return "Смерч";
                case "한국어": return "회오리바람";
                case "简体中文": return "旋风";
                default: return "Cyclone";
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

        ///<summary>spell=326647</summary>
        private static string EmpowerBond_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Empower Bond";
                case "Deutsch": return "Verbindung ermächtigen";
                case "Español": return "Potenciar vínculo";
                case "Français": return "Renforcement de lien";
                case "Italiano": return "Vincolo Potenziato";
                case "Português Brasileiro": return "Potencializar Vínculo";
                case "Русский": return "Усиление связи";
                case "한국어": return "유대 강화";
                case "简体中文": return "增效羁绊";
                default: return "Empower Bond";
            }
        }

        ///<summary>spell=339</summary>
        private static string EntanglingRoots_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Entangling Roots";
                case "Deutsch": return "Wucherwurzeln";
                case "Español": return "Raíces enredadoras";
                case "Français": return "Sarments";
                case "Italiano": return "Radici Avvolgenti";
                case "Português Brasileiro": return "Raízes Enredantes";
                case "Русский": return "Гнев деревьев";
                case "한국어": return "휘감는 뿌리";
                case "简体中文": return "纠缠根须";
                default: return "Entangling Roots";
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

        ///<summary>spell=205644</summary>
        private static string ForceOfNature_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Force of Nature";
                case "Deutsch": return "Naturgewalt";
                case "Español": return "Fuerza de la Naturaleza";
                case "Français": return "Force de la nature";
                case "Italiano": return "Force of Nature";
                case "Português Brasileiro": return "Força da Natureza";
                case "Русский": return "Сила природы";
                case "한국어": return "자연의 군대";
                case "简体中文": return "自然之力";
                default: return "Force of Nature";
            }
        }

        ///<summary>spell=335077</summary>
        private static string Frenzy_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Frenzy";
                case "Deutsch": return "Raserei";
                case "Español": return "Frenesí";
                case "Français": return "Frénésie";
                case "Italiano": return "Frenesia";
                case "Português Brasileiro": return "Frenesi";
                case "Русский": return "Бешенство";
                case "한국어": return "광기";
                case "简体中文": return "狂乱";
                default: return "Frenzy";
            }
        }

        ///<summary>spell=274283</summary>
        private static string FullMoon_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Full Moon";
                case "Deutsch": return "Vollmond";
                case "Español": return "Luna llena";
                case "Français": return "Pleine lune";
                case "Italiano": return "Luna Piena";
                case "Português Brasileiro": return "Lua Cheia";
                case "Русский": return "Полная луна";
                case "한국어": return "보름달";
                case "简体中文": return "满月";
                default: return "Full Moon";
            }
        }

        ///<summary>spell=202770</summary>
        private static string FuryOfElune_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fury of Elune";
                case "Deutsch": return "Zorn der Elune";
                case "Español": return "Furia de Elune";
                case "Français": return "Fureur d’Élune";
                case "Italiano": return "Furia di Elune";
                case "Português Brasileiro": return "Fúria de Eluna";
                case "Русский": return "Ярость Элуны";
                case "한국어": return "엘룬의 분노";
                case "简体中文": return "艾露恩之怒";
                default: return "Fury of Elune";
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

        ///<summary>spell=274282</summary>
        private static string HalfMoon_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Half Moon";
                case "Deutsch": return "Halbmond";
                case "Español": return "Medialuna";
                case "Français": return "Demi-lune";
                case "Italiano": return "Mezza Luna";
                case "Português Brasileiro": return "Meia-lua";
                case "Русский": return "Полумесяц";
                case "한국어": return "반달";
                case "简体中文": return "半月";
                default: return "Half Moon";
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

        ///<summary>spell=319454</summary>
        private static string HeartOfTheWild_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Heart of the Wild";
                case "Deutsch": return "Herz der Wildnis";
                case "Español": return "Corazón de lo Salvaje";
                case "Français": return "Cœur de fauve";
                case "Italiano": return "Cuore Selvaggio";
                case "Português Brasileiro": return "Coração das Selvas";
                case "Русский": return "Сердце дикой природы";
                case "한국어": return "야생의 정수";
                case "简体中文": return "野性之心";
                default: return "Heart of the Wild";
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

        ///<summary>spell=2637</summary>
        private static string Hibernate_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Hibernate";
                case "Deutsch": return "Überwintern";
                case "Español": return "Hibernar";
                case "Français": return "Hibernation";
                case "Italiano": return "Letargo";
                case "Português Brasileiro": return "Hibernar";
                case "Русский": return "Спячка";
                case "한국어": return "겨울잠";
                case "简体中文": return "休眠";
                default: return "Hibernate";
            }
        }

        ///<summary>spell=102560</summary>
        private static string Incarnation_ChosenOfElune_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Incarnation: Chosen of Elune";
                case "Deutsch": return "Inkarnation: Erwählter der Elune";
                case "Español": return "Encarnación: Elegido de Elune";
                case "Français": return "Incarnation : Appelé d’Élune";
                case "Italiano": return "Incarnazione: Prescelto di Elune";
                case "Português Brasileiro": return "Encarnação: Escolhido de Eluna";
                case "Русский": return "Воплощение: избранный Элуны";
                case "한국어": return "화신: 엘룬의 선택";
                case "简体中文": return "化身：艾露恩之眷";
                default: return "Incarnation: Chosen of Elune";
            }
        }

        ///<summary>spell=29166</summary>
        private static string Innervate_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Innervate";
                case "Deutsch": return "Anregen";
                case "Español": return "Estimular";
                case "Français": return "Innervation";
                case "Italiano": return "Innervazione";
                case "Português Brasileiro": return "Avivar";
                case "Русский": return "Озарение";
                case "한국어": return "정신 자극";
                case "简体中文": return "激活";
                default: return "Innervate";
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

        ///<summary>spell=1126</summary>
        private static string MarkOfTheWild_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mark of the Wild";
                case "Deutsch": return "Mal der Wildnis";
                case "Español": return "Marca de lo Salvaje";
                case "Français": return "Marque du fauve";
                case "Italiano": return "Marchio Selvaggio";
                case "Português Brasileiro": return "Marca do Indomado";
                case "Русский": return "Знак дикой природы";
                case "한국어": return "야생의 징표";
                case "简体中文": return "野性印记";
                default: return "Mark of the Wild";
            }
        }

        ///<summary>spell=102359</summary>
        private static string MassEntanglement_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mass Entanglement";
                case "Deutsch": return "Massenumschlingung";
                case "Español": return "Enredo masivo";
                case "Français": return "Enchevêtrement de masse";
                case "Italiano": return "Intrappolamento di Massa";
                case "Português Brasileiro": return "Embaraço em Massa";
                case "Русский": return "Массовое оплетение";
                case "한국어": return "대규모 휘감기";
                case "简体中文": return "群体缠绕";
                default: return "Mass Entanglement";
            }
        }

        ///<summary>spell=5211</summary>
        private static string MightyBash_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mighty Bash";
                case "Deutsch": return "Mächtiger Hieb";
                case "Español": return "Azote poderoso";
                case "Français": return "Rossée puissante";
                case "Italiano": return "Urto Vigoroso";
                case "Português Brasileiro": return "Trombada Poderosa";
                case "Русский": return "Мощное оглушение";
                case "한국어": return "거센 강타";
                case "简体中文": return "蛮力猛击";
                default: return "Mighty Bash";
            }
        }

        ///<summary>spell=8921</summary>
        private static string Moonfire_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Moonfire";
                case "Deutsch": return "Mondfeuer";
                case "Español": return "Fuego lunar";
                case "Français": return "Éclat lunaire";
                case "Italiano": return "Fuoco Lunare";
                case "Português Brasileiro": return "Fogo Lunar";
                case "Русский": return "Лунный огонь";
                case "한국어": return "달빛섬광";
                case "简体中文": return "月火术";
                default: return "Moonfire";
            }
        }

        ///<summary>spell=24858</summary>
        private static string MoonkinForm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Moonkin Form";
                case "Deutsch": return "Mondkingestalt";
                case "Español": return "Forma de lechúcico lunar";
                case "Français": return "Forme de sélénien";
                case "Italiano": return "Forma di Lunagufo";
                case "Português Brasileiro": return "Forma de Luniscante";
                case "Русский": return "Облик лунного совуха";
                case "한국어": return "달빛야수 변신";
                case "简体中文": return "枭兽形态";
                default: return "Moonkin Form";
            }
        }

        ///<summary>spell=210053</summary>
        private static string MountForm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mount Form";
                case "Deutsch": return "Reittiergestalt";
                case "Español": return "Forma de montura";
                case "Français": return "Forme de monture";
                case "Italiano": return "Forma di Cavalcatura";
                case "Português Brasileiro": return "Forma de Montaria";
                case "Русский": return "Облик ездового животного";
                case "한국어": return "탈것 변신";
                case "简体中文": return "坐骑形态";
                default: return "Mount Form";
            }
        }

        ///<summary>spell=124974</summary>
        private static string NaturesVigil_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Nature's Vigil";
                case "Deutsch": return "Wache der Natur";
                case "Español": return "Vigilia de la Naturaleza";
                case "Français": return "Veille de la nature";
                case "Italiano": return "Veglia della Natura";
                case "Português Brasileiro": return "Vigília da Natureza";
                case "Русский": return "Природная чуткость";
                case "한국어": return "자연의 경계";
                case "简体中文": return "自然的守护";
                default: return "Nature's Vigil";
            }
        }

        ///<summary>spell=274281</summary>
        private static string NewMoon_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "New Moon";
                case "Deutsch": return "Neumond";
                case "Español": return "Luna nueva";
                case "Français": return "Nouvelle lune";
                case "Italiano": return "Luna Nuova";
                case "Português Brasileiro": return "Lua Nova";
                case "Русский": return "Новолуние";
                case "한국어": return "초승달";
                case "简体中文": return "新月";
                default: return "New Moon";
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

        ///<summary>spell=323546</summary>
        private static string RavenousFrenzy_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ravenous Frenzy";
                case "Deutsch": return "Unersättliche Raserei";
                case "Español": return "Frenesí voraz";
                case "Français": return "Frénésie vorace";
                case "Italiano": return "Frenesia Vorace";
                case "Português Brasileiro": return "Frenesi Voraz";
                case "Русский": return "Прожорливое бешенство";
                case "한국어": return "굶주린 광란";
                case "简体中文": return "饕餮狂乱";
                default: return "Ravenous Frenzy";
            }
        }

        ///<summary>spell=20484</summary>
        private static string Rebirth_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rebirth";
                case "Deutsch": return "Wiedergeburt";
                case "Español": return "Renacer";
                case "Français": return "Renaissance";
                case "Italiano": return "Pronto Ritorno";
                case "Português Brasileiro": return "Renascimento";
                case "Русский": return "Возрождение";
                case "한국어": return "환생";
                case "简体中文": return "复生";
                default: return "Rebirth";
            }
        }

        ///<summary>spell=8936</summary>
        private static string Regrowth_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Regrowth";
                case "Deutsch": return "Nachwachsen";
                case "Español": return "Recrecimiento";
                case "Français": return "Rétablissement";
                case "Italiano": return "Ricrescita";
                case "Português Brasileiro": return "Recrescimento";
                case "Русский": return "Восстановление";
                case "한국어": return "재생";
                case "简体中文": return "愈合";
                default: return "Regrowth";
            }
        }

        ///<summary>spell=2782</summary>
        private static string RemoveCorruption_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Remove Corruption";
                case "Deutsch": return "Verderbnis entfernen";
                case "Español": return "Eliminar corrupción";
                case "Français": return "Délivrance de la corruption";
                case "Italiano": return "Rimozione Corruzione";
                case "Português Brasileiro": return "Remover Corrupção";
                case "Русский": return "Снятие порчи";
                case "한국어": return "해제";
                case "简体中文": return "清除腐蚀";
                default: return "Remove Corruption";
            }
        }

        ///<summary>spell=108238</summary>
        private static string Renewal_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Renewal";
                case "Deutsch": return "Erneuerung";
                case "Español": return "Renovación";
                case "Français": return "Renouveau";
                case "Italiano": return "Rinnovo Istantaneo";
                case "Português Brasileiro": return "Renovação";
                case "Русский": return "Обновление";
                case "한국어": return "소생";
                case "简体中文": return "甘霖";
                default: return "Renewal";
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

        ///<summary>spell=106839</summary>
        private static string SkullBash_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Skull Bash";
                case "Deutsch": return "Schädelstoß";
                case "Español": return "Testarazo";
                case "Français": return "Coup de crâne";
                case "Italiano": return "Craniata";
                case "Português Brasileiro": return "Esmagar Crânio";
                case "Русский": return "Лобовая атака";
                case "한국어": return "두개골 강타";
                case "简体中文": return "迎头痛击";
                default: return "Skull Bash";
            }
        }

        ///<summary>spell=81261</summary>
        private static string SolarBeam_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Solar Beam";
                case "Deutsch": return "Sonnenstrahl";
                case "Español": return "Rayo solar";
                case "Français": return "Rayon solaire";
                case "Italiano": return "Fascio Solare";
                case "Português Brasileiro": return "Raio Solar";
                case "Русский": return "Столп солнечного света";
                case "한국어": return "태양 광선";
                case "简体中文": return "日光术";
                default: return "Solar Beam";
            }
        }

        ///<summary>spell=2908</summary>
        private static string Soothe_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Soothe";
                case "Deutsch": return "Besänftigen";
                case "Español": return "Calmar";
                case "Français": return "Apaiser";
                case "Italiano": return "Pacificazione";
                case "Português Brasileiro": return "Confortar";
                case "Русский": return "Умиротворение";
                case "한국어": return "달래기";
                case "简体中文": return "安抚";
                default: return "Soothe";
            }
        }

        ///<summary>spell=191034</summary>
        private static string Starfall_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Starfall";
                case "Deutsch": return "Sternenregen";
                case "Español": return "Lluvia de estrellas";
                case "Français": return "Météores";
                case "Italiano": return "Pioggia di Stelle";
                case "Português Brasileiro": return "Chuva Estelar";
                case "Русский": return "Звездопад";
                case "한국어": return "별똥별";
                case "简体中文": return "星辰坠落";
                default: return "Starfall";
            }
        }

        ///<summary>spell=197628</summary>
        private static string Starfire_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Starfire";
                case "Deutsch": return "Sternenfeuer";
                case "Español": return "Fuego estelar";
                case "Français": return "Feu stellaire";
                case "Italiano": return "Fuoco Stellare";
                case "Português Brasileiro": return "Fogo Estelar";
                case "Русский": return "Звездный огонь";
                case "한국어": return "별빛섬광";
                case "简体中文": return "星火术";
                default: return "Starfire";
            }
        }

        ///<summary>spell=78674</summary>
        private static string Starsurge_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Starsurge";
                case "Deutsch": return "Sternensog";
                case "Español": return "Oleada de estrellas";
                case "Français": return "Éruption stellaire";
                case "Italiano": return "Cometa Arcana";
                case "Português Brasileiro": return "Surto Estelar";
                case "Русский": return "Звездный поток";
                case "한국어": return "별빛쇄도";
                case "简体中文": return "星涌术";
                default: return "Starsurge";
            }
        }

        ///<summary>spell=202347</summary>
        private static string StellarFlare_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Stellar Flare";
                case "Deutsch": return "Sterneneruption";
                case "Español": return "Centella estelar";
                case "Français": return "Flamboiement stellaire";
                case "Italiano": return "Bengala Stellare";
                case "Português Brasileiro": return "Chama Estelar";
                case "Русский": return "Звездная вспышка";
                case "한국어": return "항성의 섬광";
                case "简体中文": return "星辰耀斑";
                default: return "Stellar Flare";
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

        ///<summary>spell=164815</summary>
        private static string Sunfire_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sunfire";
                case "Deutsch": return "Sonnenfeuer";
                case "Español": return "Fuego solar";
                case "Français": return "Éclat solaire";
                case "Italiano": return "Fuoco Solare";
                case "Português Brasileiro": return "Fogo Solar";
                case "Русский": return "Солнечный огонь";
                case "한국어": return "태양섬광";
                case "简体中文": return "阳炎术";
                default: return "Sunfire";
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

        ///<summary>spell=783</summary>
        private static string TravelForm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Travel Form";
                case "Deutsch": return "Reisegestalt";
                case "Español": return "Forma de viaje";
                case "Français": return "Forme de voyage";
                case "Italiano": return "Forma Celere";
                case "Português Brasileiro": return "Forma de Viagem";
                case "Русский": return "Походный облик";
                case "한국어": return "날쌘 동물 변신";
                case "简体中文": return "旅行形态";
                default: return "Travel Form";
            }
        }


        ///<summary>spell=61391</summary>
        private static string Typhoon_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Typhoon";
                case "Deutsch": return "Taifun";
                case "Español": return "Tifón";
                case "Français": return "Typhon";
                case "Italiano": return "Tifone";
                case "Português Brasileiro": return "Tufão";
                case "Русский": return "Тайфун";
                case "한국어": return "태풍";
                case "简体中文": return "台风";
                default: return "Typhoon";
            }
        }

        ///<summary>spell=102793</summary>
        private static string UrsolsVortex_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ursol's Vortex";
                case "Deutsch": return "Ursols Vortex";
                case "Español": return "Vórtice de Ursol";
                case "Français": return "Vortex d’Ursol";
                case "Italiano": return "Vortice di Ursol";
                case "Português Brasileiro": return "Vórtice de Ursol";
                case "Русский": return "Вихрь Урсола";
                case "한국어": return "우르솔의 회오리";
                case "简体中文": return "乌索尔旋风";
                default: return "Ursol's Vortex";
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

        ///<summary>spell=202425</summary>
        private static string WarriorOfElune_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Warrior of Elune";
                case "Deutsch": return "Krieger der Elune";
                case "Español": return "Guerrero de Elune";
                case "Français": return "Guerrier d’Elune";
                case "Italiano": return "Guerriero di Elune";
                case "Português Brasileiro": return "Guerreiro de Eluna";
                case "Русский": return "Воин Элуны";
                case "한국어": return "엘룬의 전사";
                case "简体中文": return "艾露恩的战士";
                default: return "Warrior of Elune";
            }
        }

        ///<summary>spell=88747</summary>
        private static string WildMushroom_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Wild Mushroom";
                case "Deutsch": return "Wildpilz";
                case "Español": return "Champiñón salvaje";
                case "Français": return "Champignon sauvage";
                case "Italiano": return "Fungo Selvaggio";
                case "Português Brasileiro": return "Cogumelo Selvagem";
                case "Русский": return "Дикий гриб";
                case "한국어": return "야생 버섯";
                case "简体中文": return "野性蘑菇";
                default: return "Wild Mushroom";
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
        private List<string> m_IngameCommandsList = new List<string> { "NoDecurse", "NoCycle", "SolarBeam", "MightyBash", "MassEntanglement", "ForceofNature", "UrsolsVortex", "Typhoon", "Rebirth", "Innervate", "Hibernate", "Cyclone", "EntanglingRoots", "Regrowth", };
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

            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");
            Macros.Add("RC_FOC", "/cast [@focus] " + RemoveCorruption_SpellName(Language));

            //Mouseover Macros
            Macros.Add("SootheMO", "/cast [@mouseover] " + Soothe_SpellName(Language));
            Macros.Add("RebirthMO", "/cast [@mouseover] " + Rebirth_SpellName(Language));
            Macros.Add("InnervateMO", "/cast [@mouseover] " + Innervate_SpellName(Language));
            Macros.Add("HibernateMO", "/cast [@mouseover] " + Hibernate_SpellName(Language));
            Macros.Add("CycloneMO", "/cast [@mouseover] " + Cyclone_SpellName(Language));
            Macros.Add("EntanglingRootsMO", "/cast [@mouseover] " + EntanglingRoots_SpellName(Language));

            Macros.Add("ForceofNatureP", "/cast [@player] " + ForceOfNature_SpellName(Language));
            Macros.Add("ForceofNatureC", "/cast [@cursor] " + ForceOfNature_SpellName(Language));
            Macros.Add("UrsolsVortexP", "/cast [@player] " + UrsolsVortex_SpellName(Language));
            Macros.Add("UrsolsVortexC", "/cast [@cursor] " + UrsolsVortex_SpellName(Language));
            Macros.Add("CelestialAlignmentP", "/cast [@player] " + CelestialAlignment_SpellName(Language));
            Macros.Add("CelestialAlignmentC", "/cast [@cursor] " + CelestialAlignment_SpellName(Language));

            //Queues
            Macros.Add("MightyBashOff", "/" + FiveLetters + " MightyBash");
            Macros.Add("MassEntanglementOff", "/" + FiveLetters + " MassEntanglement");
            Macros.Add("SolarBeamOff", "/" + FiveLetters + " SolarBeam");
            Macros.Add("RebirthOff", "/" + FiveLetters + " Rebirth");
            Macros.Add("InnervateOff", "/" + FiveLetters + " Innervate");
            Macros.Add("HibernateOff", "/" + FiveLetters + " Hibernate");
            Macros.Add("CycloneOff", "/" + FiveLetters + " Cyclone");
            Macros.Add("TyphoonOff", "/" + FiveLetters + " Typhoon");
            Macros.Add("ForceofNatureOff", "/" + FiveLetters + " ForceofNature");
            Macros.Add("EntanglingRootsOff", "/" + FiveLetters + " EntanglingRoots");
            Macros.Add("UrsolsVortexOff", "/" + FiveLetters + " UrsolsVortex");
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

            CustomFunctions.Add("EnrageBuffCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Soothe','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType  = UnitBuff('mouseover', y) if debuffType == '' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("EnrageBuffCheckTarget", "local markcheck = 0; if UnitExists('target') and UnitIsDead('target') ~= true and UnitAffectingCombat('target') and IsSpellInRange('Soothe','target') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType  = UnitBuff('target', y) if debuffType == '' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
            "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
            "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
            "\nreturn foc");

            CustomFunctions.Add("CursePoisonCheck", "local y=0; " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"player\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +1; end end " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +2; end end " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +4; end end " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +8; end end " +
                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
                "if type ~= nil and type == \"Curse\" or type == \"Poison\" then y = y +16; end end " +
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
            Settings.Add(new Setting("Race:", m_RaceList, "nightelf"));
            Settings.Add(new Setting("Ingame World Latency:", 1, 200, 50));
            Settings.Add(new Setting(" "));
            Settings.Add(new Setting("Use Trinkets on CD, dont wait for Hekili:", false));
            Settings.Add(new Setting("Auto Healthstone @ HP%", 0, 100, 25));
            Settings.Add(new Setting("General"));
            Settings.Add(new Setting("Auto Start Combat:", true));
            Settings.Add(new Setting("Mark of the Wild Out of Combat:", true));
            Settings.Add(new Setting("Soothe Mouseover:", true));
            Settings.Add(new Setting("Soothe Target:", true));
            Settings.Add(new Setting("Auto Renewal @ HP%", 0, 100, 20));
            Settings.Add(new Setting("Auto Barkskin @ HP%", 0, 100, 40));
            Settings.Add(new Setting("Ursol's Vortex Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Force of Nature Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Celestial Alignment with Orbital Strike cast:", m_CastingList, "Manual"));
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

            Aimsharp.PrintMessage("Epic PVE - Druid Balance", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/beta/guide/classes/druid/balance/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoDecurse - Disables Decurse", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " MightyBash - Casts Mighty Bash @ Target next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " MassEntanglement - Casts Mass Entanglement @ Target next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " SolarBeam - Casts Solar Beam @ Target next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " ForceofNature - Casts Force of Nature @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " UrsolsVortex - Casts Ursol's Vortex @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Typhoon - Casts Typhoon @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Rebirth - Casts Rebirth @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Innervate - Casts Innervate @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Hibernate - Casts Hibernate @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Cyclone - Casts Cyclone @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " EntanglingRoots - Casts Entangling Roots @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Regrowth - Casts Regrowth until turned Off", Color.Yellow);
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
            m_BuffsList = new List<string> { BearForm_SpellName(Language), CatForm_SpellName(Language), MarkOfTheWild_SpellName(Language), MountForm_SpellName(Language), TravelForm_SpellName(Language),};
            m_ItemsList = new List<string> { Healthstone_SpellName(Language), };
            m_SpellBook = new List<string> {
                //Covenants
                ConvokeTheSpirits_SpellName(Language), //323764
                AdaptiveSwarm_SpellName(Language), //325727
                EmpowerBond_SpellName(Language), //326647
                RavenousFrenzy_SpellName(Language), //323546

                //Interrupt
                SkullBash_SpellName(Language), //106839
                SolarBeam_SpellName(Language), //78675

                //General
                Barkskin_SpellName(Language), //22812
                BearForm_SpellName(Language), //5487
                CatForm_SpellName(Language), //768
                Cyclone_SpellName(Language), //33786
                EntanglingRoots_SpellName(Language), //339
                HeartOfTheWild_SpellName(Language), //319454
                Hibernate_SpellName(Language), //2637
                Innervate_SpellName(Language), //29166
                MarkOfTheWild_SpellName(Language), //1126
                MassEntanglement_SpellName(Language), //102359
                MightyBash_SpellName(Language), //5211
                Moonfire_SpellName(Language), //8921
                NaturesVigil_SpellName(Language), //124974
                Rebirth_SpellName(Language), //20484
                Regrowth_SpellName(Language), //8936
                RemoveCorruption_SpellName(Language), //2782
                Renewal_SpellName(Language), //108238
                Soothe_SpellName(Language), //2908
                Starfire_SpellName(Language), //194153
                Sunfire_SpellName(Language), //93402
                Typhoon_SpellName(Language), //132469
                Wrath_SpellName(Language), //190984

                //Balance
                AstralCommunion_SpellName(Language), //202359
                CelestialAlignment_SpellName(Language), //194223
                ForceOfNature_SpellName(Language), //205636
                FuryOfElune_SpellName(Language), //202770
                Incarnation_ChosenOfElune_SpellName(Language), //102560
                MoonkinForm_SpellName(Language), //24858
                Starfall_SpellName(Language), //191034
                Starsurge_SpellName(Language), //78674
                StellarFlare_SpellName(Language), //202347
                UrsolsVortex_SpellName(Language), //102793
                WarriorOfElune_SpellName(Language), //202425
                WildMushroom_SpellName(Language), //88747
                NewMoon_SpellName(Language), //274281
                HalfMoon_SpellName(Language), //274282
                FullMoon_SpellName(Language), //274283
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

            int CursePoisonCheck = Aimsharp.CustomFunction("CursePoisonCheck");
            int EnrageBuffMO = Aimsharp.CustomFunction("EnrageBuffCheckMouseover");
            int EnrageBuffTarget = Aimsharp.CustomFunction("EnrageBuffCheckTarget");

            bool NoDecurse = Aimsharp.IsCustomCodeOn("NoDecurse");
            bool NoCycle = Aimsharp.IsCustomCodeOn("NoCycle");

            bool MOSoothe = GetCheckBox("Soothe Mouseover:") == true;
            bool TargetSoothe = GetCheckBox("Soothe Target:") == true;

            bool Debug = GetCheckBox("Debug:") == true;
            bool UseTrinketsCD = GetCheckBox("Use Trinkets on CD, dont wait for Hekili:") == true;

            bool Enemy = Aimsharp.TargetIsEnemy();
            int EnemiesInMelee = Aimsharp.EnemiesInMelee();
            bool Moving = Aimsharp.PlayerIsMoving();
            int PlayerHP = Aimsharp.Health("player");

            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());
            #endregion

            if (Aimsharp.IsChanneling("player")) return false;

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
            if (Aimsharp.CastingID("player") == 2637 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Hibernate"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Hibernate Queue", Color.Purple);
                }
                Aimsharp.Cast("HibernateOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 33786 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Cyclone"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Cyclone Queue", Color.Purple);
                }
                Aimsharp.Cast("CycloneOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 339 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("EntanglingRoots"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Entangling Roots Queue", Color.Purple);
                }
                Aimsharp.Cast("EntanglingRootsOff");
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

            if (Aimsharp.HasBuff(BearForm_SpellName(Language), "player", true) || Aimsharp.HasBuff(CatForm_SpellName(Language), "player", true) || Aimsharp.HasBuff(MountForm_SpellName(Language), "player", true) || Aimsharp.HasBuff(TravelForm_SpellName(Language), "player", true))
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("UrsolsVortex") && Aimsharp.SpellCooldown(UrsolsVortex_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("ForceofNature") && Aimsharp.SpellCooldown(ForceOfNature_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Interrupts
            bool SolarBeam = Aimsharp.IsCustomCodeOn("SolarBeam");
            //Queue Solar Beam
            if (SolarBeam && Aimsharp.SpellCooldown(SolarBeam_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Solar Beam queue toggle", Color.Purple);
                }
                Aimsharp.Cast("SolarBeamOff");
                return true;
            }

            if (SolarBeam && Aimsharp.CanCast(SolarBeam_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Solar Beam through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(SolarBeam_SpellName(Language));
                return true;
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


            //Auto Renewal
            if (Aimsharp.CanCast(Renewal_SpellName(Language), "player", false, true))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Renewal @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Renewal - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Renewal @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(Renewal_SpellName(Language));
                    return true;
                }
            }

            //Auto Barkskin
            if (Aimsharp.CanCast(Barkskin_SpellName(Language), "player", false, true))
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Barkskin @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Barkskin - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Barkskin @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(Barkskin_SpellName(Language));
                    return true;
                }
            }
            #endregion

            #region Queues
            //Queue Rebirth
            bool Rebirth = Aimsharp.IsCustomCodeOn("Rebirth");
            if (Aimsharp.SpellCooldown(Rebirth_SpellName(Language)) - Aimsharp.GCD() > 2000 && Rebirth)
            {
                Aimsharp.Cast("RebirthOff");
                return true;
            }

            if (Rebirth && Aimsharp.CanCast(Rebirth_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("RebirthMO");
                return true;
            }

            //Queue Hibernate
            bool Hibernate = Aimsharp.IsCustomCodeOn("Hibernate");
            if (Aimsharp.SpellCooldown(Hibernate_SpellName(Language)) - Aimsharp.GCD() > 2000 && Hibernate)
            {
                Aimsharp.Cast("HibernateOff");
                return true;
            }

            if (Hibernate && Aimsharp.CanCast(Hibernate_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("HibernateMO");
                return true;
            }

            //Queue Cyclone
            bool Cyclone = Aimsharp.IsCustomCodeOn("Cyclone");
            if (Aimsharp.SpellCooldown(Cyclone_SpellName(Language)) - Aimsharp.GCD() > 2000 && Cyclone)
            {
                Aimsharp.Cast("CycloneOff");
                return true;
            }

            if (Cyclone && Aimsharp.CanCast(Cyclone_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("CycloneMO");
                return true;
            }

            //Queue Entangling Roots
            bool EntanglingRoots = Aimsharp.IsCustomCodeOn("EntanglingRoots");
            if (Aimsharp.SpellCooldown(EntanglingRoots_SpellName(Language)) - Aimsharp.GCD() > 2000 && EntanglingRoots)
            {
                Aimsharp.Cast("EntanglingRootsOff");
                return true;
            }

            if (EntanglingRoots && Aimsharp.CanCast(EntanglingRoots_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("EntanglingRootsMO");
                return true;
            }

            //Queue Innervate
            bool Innervate = Aimsharp.IsCustomCodeOn("Innervate");
            if (Aimsharp.SpellCooldown(Innervate_SpellName(Language)) - Aimsharp.GCD() > 2000 && Innervate)
            {
                Aimsharp.Cast("InnervateOff");
                return true;
            }

            if (Innervate && Aimsharp.CanCast(Innervate_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("InnervateMO");
                return true;
            }

            bool Typhoon = Aimsharp.IsCustomCodeOn("Typhoon");
            //Queue Typhoon
            if (Typhoon && Aimsharp.SpellCooldown(Typhoon_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Typhoon queue toggle", Color.Purple);
                }
                Aimsharp.Cast("TyphoonOff");
                return true;
            }

            if (Typhoon && Aimsharp.CanCast(Typhoon_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Typhoon through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Typhoon_SpellName(Language));
                return true;
            }

            bool MightyBash = Aimsharp.IsCustomCodeOn("MightyBash");
            //Queue Mighty Bash
            if (MightyBash && Aimsharp.SpellCooldown(MightyBash_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mighty Bash queue toggle", Color.Purple);
                }
                Aimsharp.Cast("MightyBashOff");
                return true;
            }

            if (MightyBash && Aimsharp.CanCast(MightyBash_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mighty Bash through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(MightyBash_SpellName(Language));
                return true;
            }

            bool MassEntanglement = Aimsharp.IsCustomCodeOn("MassEntanglement");
            //Queue Mass Entanglement
            if (MassEntanglement && Aimsharp.SpellCooldown(MassEntanglement_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mass Entanglement queue toggle", Color.Purple);
                }
                Aimsharp.Cast("MassEntanglementOff");
                return true;
            }

            if (MassEntanglement && Aimsharp.CanCast(MassEntanglement_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mass Entanglement through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(MassEntanglement_SpellName(Language));
                return true;
            }

            //Queue Force of Nature
            string ForceofNatureCast = GetDropDown("Force of Nature Cast:");
            bool ForceofNature = Aimsharp.IsCustomCodeOn("ForceofNature");
            if (Aimsharp.SpellCooldown(ForceOfNature_SpellName(Language)) - Aimsharp.GCD() > 2000 && ForceofNature)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Force of Nature Queue", Color.Purple);
                }
                Aimsharp.Cast("ForceofNatureOff");
                return true;
            }

            if (ForceofNature && Aimsharp.CanCast(ForceOfNature_SpellName(Language), "player", false, true))
            {
                switch (ForceofNatureCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Force of Nature - " + ForceofNatureCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(ForceOfNature_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Force of Nature - " + ForceofNatureCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ForceofNatureP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Force of Nature - " + ForceofNatureCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ForceofNatureC");
                        return true;
                }
            }

            //Queue Ursol's Vortex
            string UrsolsVortexCast = GetDropDown("Ursol's Vortex Cast:");
            bool UrsolsVortex = Aimsharp.IsCustomCodeOn("UrsolsVortex");
            if (Aimsharp.SpellCooldown(UrsolsVortex_SpellName(Language)) - Aimsharp.GCD() > 2000 && UrsolsVortex)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Ursol's Vortex Queue", Color.Purple);
                }
                Aimsharp.Cast("UrsolsVortexOff");
                return true;
            }

            if (UrsolsVortex && Aimsharp.CanCast(UrsolsVortex_SpellName(Language), "player", false, true))
            {
                switch (UrsolsVortexCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ursol's Vortex - " + UrsolsVortexCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(UrsolsVortex_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ursol's Vortex - " + UrsolsVortexCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("UrsolsVortexP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ursol's Vortex - " + UrsolsVortexCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("UrsolsVortexC");
                        return true;
                }
            }
            bool Regrowth = Aimsharp.IsCustomCodeOn("Regrowth");
            if (Regrowth && Aimsharp.CanCast(Regrowth_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Spamming Regrowth through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Regrowth_SpellName(Language));
                return true;
            }
            #endregion

            #region Remove Corruption
            if (!NoDecurse && CursePoisonCheck > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != RemoveCorruption_SpellName(Language))
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

                int states = Aimsharp.CustomFunction("CursePoisonCheck");
                CleansePlayers target;

                int KickTimer = GetRandomNumber(200,800);

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast(RemoveCorruption_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
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
                                    Aimsharp.PrintMessage("Remove Corruption @ " + unit.Key + " - " + unit.Value, Color.Purple);
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

            if (Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat && !Regrowth)
            {
                if (Wait <= 200)
                {
                    #region Mouseover Spells
                    //Soothe Mouseover
                    if (Aimsharp.CanCast(Soothe_SpellName(Language), "mouseover", true, true))
                    {
                        if (MOSoothe && EnrageBuffMO == 3)
                        {
                            Aimsharp.Cast("SootheMO");
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Casting Soothe (Mouseover)", Color.Purple);
                            }
                            return true;
                        }
                    }

                    //Soothe Target
                    if (Aimsharp.CanCast(Soothe_SpellName(Language), "target", true, true))
                    {
                        if (TargetSoothe && EnrageBuffTarget == 3)
                        {
                            Aimsharp.Cast(Soothe_SpellName(Language));
                            if (Debug)
                            {
                                Aimsharp.PrintMessage("Casting Soothe (Target)", Color.Purple);
                            }
                            return true;
                        }
                    }
                    #endregion

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
                    if ((SpellID1 == 323764 || SpellID1 == 391528) && Aimsharp.CanCast(ConvokeTheSpirits_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Convoke the Spirits - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ConvokeTheSpirits_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 325727 || SpellID1 == 391888) && Aimsharp.CanCast(AdaptiveSwarm_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Adaptive Swarm - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AdaptiveSwarm_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 323546 && Aimsharp.CanCast(RavenousFrenzy_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ravenous Frenzy - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RavenousFrenzy_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 327139 || SpellID1 == 327022 || SpellID1 == 327148 || SpellID1 == 327071 || SpellID1 == 326647) && Aimsharp.CanCast(EmpowerBond_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Empower Bond - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(EmpowerBond_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - No GCD
                    ///Class Spells
                    //Target - No GCD
                    if (SpellID1 == 78675 && Aimsharp.CanCast(SolarBeam_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Solar Beam - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SolarBeam_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 106839 && Aimsharp.CanCast(SkullBash_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Skull Bash - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SkullBash_SpellName(Language), true);
                        return true;
                    }

                    string CelestialAlignmentCast = GetDropDown("Celestial Alignment with Orbital Strike cast:");
                    if ((SpellID1 == 194223 || SpellID1 == 390381 || SpellID1 == 383410) && Aimsharp.CanCast(CelestialAlignment_SpellName(Language), "player", false, true))
                    {
                        switch (CelestialAlignmentCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Celestial Alignment - " + CelestialAlignmentCast, Color.Purple);
                                }
                                Aimsharp.Cast(CelestialAlignment_SpellName(Language));
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Celestial Alignment - " + CelestialAlignmentCast, Color.Purple);
                                }
                                Aimsharp.Cast("CelestialAlignmentP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Celestial Alignment - " + CelestialAlignmentCast, Color.Purple);
                                }
                                Aimsharp.Cast("CelestialAlignmentC");
                                return true;
                        }
                    }

                    if (SpellID1 == 124974 && Aimsharp.CanCast(NaturesVigil_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Nature's Vigil - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(NaturesVigil_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 202359 && Aimsharp.CanCast(AstralCommunion_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Astral Communion - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AstralCommunion_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 102560 && Aimsharp.CanCast(Incarnation_ChosenOfElune_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Incarnation: Chosen of Elune - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Incarnation_ChosenOfElune_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    //Target - GCD
                    if (SpellID1 == 8921 && Aimsharp.CanCast(Moonfire_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Moonfire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Moonfire_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 190984 && Aimsharp.CanCast(Wrath_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wrath - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Wrath_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 2908 && Aimsharp.CanCast(Soothe_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Soothe - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Soothe_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    if (SpellID1 == 1126 && Aimsharp.CanCast(MarkOfTheWild_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mark of the Wild - " + SpellID1, Color.Black);
                        }
                        Aimsharp.Cast(MarkOfTheWild_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 5487 && Aimsharp.CanCast(BearForm_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bear Form - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BearForm_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 768 && Aimsharp.CanCast(CatForm_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Cat Form - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(CatForm_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 22812 && Aimsharp.CanCast(Barkskin_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Barkskin - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Barkskin_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Balance - Target GCD

                    if (SpellID1 == 194153 && Aimsharp.CanCast(Starfire_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Starfire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Starfire_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 78674 && Aimsharp.CanCast(Starsurge_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Starsurge - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Starsurge_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 93402 && Aimsharp.CanCast(Sunfire_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Sunfire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Sunfire_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 202347 && Aimsharp.CanCast(StellarFlare_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Stellar Flare - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(StellarFlare_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 202770 && Aimsharp.CanCast(FuryOfElune_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fury of Elune - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FuryOfElune_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 274281 && Aimsharp.CanCast(NewMoon_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting New Moon - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(NewMoon_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 274282 && Aimsharp.CanCast(HalfMoon_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Half Moon - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(HalfMoon_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 274283  && Aimsharp.CanCast(FullMoon_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Full Moon - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FullMoon_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 88747 && Aimsharp.CanCast(WildMushroom_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Wild Mushroom - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WildMushroom_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Balance - Player GCD
                    if (SpellID1 == 205636 && Aimsharp.CanCast(ForceOfNature_SpellName(Language), "player", false, true))
                    {
                        switch (ForceofNatureCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Force of Nature - " + ForceofNatureCast, Color.Purple);
                                }
                                Aimsharp.Cast(ForceOfNature_SpellName(Language));
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Force of Nature - " + ForceofNatureCast, Color.Purple);
                                }
                                Aimsharp.Cast("ForceofNatureP");
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Force of Nature - " + ForceofNatureCast, Color.Purple);
                                }
                                Aimsharp.Cast("ForceofNatureC");
                                return true;
                        }
                    }

                    if (SpellID1 == 24858 && Aimsharp.CanCast(MoonkinForm_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Moonkin Form - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(MoonkinForm_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 191034 && Aimsharp.CanCast(Starfall_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Starfall - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Starfall_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 202425 && Aimsharp.CanCast(WarriorOfElune_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Warrior of Elune - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WarriorOfElune_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 319454 && Aimsharp.CanCast(HeartOfTheWild_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Heart of the Wild - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(HeartOfTheWild_SpellName(Language));
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
            bool MOTWOOC = GetCheckBox("Mark of the Wild Out of Combat:");
            #endregion

            if (Aimsharp.IsChanneling("player")) return false;

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
            if (Aimsharp.CastingID("player") == 2637 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Hibernate"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Hibernate Queue", Color.Purple);
                }
                Aimsharp.Cast("HibernateOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 33786 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("Cyclone"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Cyclone Queue", Color.Purple);
                }
                Aimsharp.Cast("CycloneOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 339 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("EntanglingRoots"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Entangling Roots Queue", Color.Purple);
                }
                Aimsharp.Cast("EntanglingRootsOff");
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

            if (Aimsharp.IsCustomCodeOn("UrsolsVortex") && Aimsharp.SpellCooldown(UrsolsVortex_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("ForceofNature") && Aimsharp.SpellCooldown(ForceOfNature_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            //Queue Rebirth
            bool Rebirth = Aimsharp.IsCustomCodeOn("Rebirth");
            if (Aimsharp.SpellCooldown(Rebirth_SpellName(Language)) - Aimsharp.GCD() > 2000 && Rebirth)
            {
                Aimsharp.Cast("RebirthOff");
                return true;
            }

            if (Rebirth && Aimsharp.CanCast(Rebirth_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("RebirthMO");
                return true;
            }

            //Queue Hibernate
            bool Hibernate = Aimsharp.IsCustomCodeOn("Hibernate");
            if (Aimsharp.SpellCooldown(Hibernate_SpellName(Language)) - Aimsharp.GCD() > 2000 && Hibernate)
            {
                Aimsharp.Cast("HibernateOff");
                return true;
            }

            if (Hibernate && Aimsharp.CanCast(Hibernate_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("HibernateMO");
                return true;
            }

            //Queue Cyclone
            bool Cyclone = Aimsharp.IsCustomCodeOn("Cyclone");
            if (Aimsharp.SpellCooldown(Cyclone_SpellName(Language)) - Aimsharp.GCD() > 2000 && Cyclone)
            {
                Aimsharp.Cast("CycloneOff");
                return true;
            }

            if (Cyclone && Aimsharp.CanCast(Cyclone_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("CycloneMO");
                return true;
            }

            //Queue Entangling Roots
            bool EntanglingRoots = Aimsharp.IsCustomCodeOn("EntanglingRoots");
            if (Aimsharp.SpellCooldown(EntanglingRoots_SpellName(Language)) - Aimsharp.GCD() > 2000 && EntanglingRoots)
            {
                Aimsharp.Cast("EntanglingRootsOff");
                return true;
            }

            if (EntanglingRoots && Aimsharp.CanCast(EntanglingRoots_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("EntanglingRootsMO");
                return true;
            }

            //Queue Innervate
            bool Innervate = Aimsharp.IsCustomCodeOn("Innervate");
            if (Aimsharp.SpellCooldown(Innervate_SpellName(Language)) - Aimsharp.GCD() > 2000 && Innervate)
            {
                Aimsharp.Cast("InnervateOff");
                return true;
            }

            if (Innervate && Aimsharp.CanCast(Innervate_SpellName(Language), "mouseover", true, true))
            {
                Aimsharp.Cast("InnervateMO");
                return true;
            }

            bool Typhoon = Aimsharp.IsCustomCodeOn("Typhoon");
            //Queue Typhoon
            if (Typhoon && Aimsharp.SpellCooldown(Typhoon_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Typhoon queue toggle", Color.Purple);
                }
                Aimsharp.Cast("TyphoonOff");
                return true;
            }

            if (Typhoon && Aimsharp.CanCast(Typhoon_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Typhoon through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Typhoon_SpellName(Language));
                return true;
            }

            bool MightyBash = Aimsharp.IsCustomCodeOn("MightyBash");
            //Queue Mighty Bash
            if (MightyBash && Aimsharp.SpellCooldown(MightyBash_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mighty Bash queue toggle", Color.Purple);
                }
                Aimsharp.Cast("MightyBashOff");
                return true;
            }

            if (MightyBash && Aimsharp.CanCast(MightyBash_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mighty Bash through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(MightyBash_SpellName(Language));
                return true;
            }

            bool MassEntanglement = Aimsharp.IsCustomCodeOn("MassEntanglement");
            //Queue Mass Entanglement
            if (MassEntanglement && Aimsharp.SpellCooldown(MassEntanglement_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mass Entanglement queue toggle", Color.Purple);
                }
                Aimsharp.Cast("MassEntanglementOff");
                return true;
            }

            if (MassEntanglement && Aimsharp.CanCast(MassEntanglement_SpellName(Language), "target", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mass Entanglement through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(MassEntanglement_SpellName(Language));
                return true;
            }

            //Queue Force of Nature
            string ForceofNatureCast = GetDropDown("Force of Nature Cast:");
            bool ForceofNature = Aimsharp.IsCustomCodeOn("ForceofNature");
            if (Aimsharp.SpellCooldown(ForceOfNature_SpellName(Language)) - Aimsharp.GCD() > 2000 && ForceofNature)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Force of Nature Queue", Color.Purple);
                }
                Aimsharp.Cast("ForceofNatureOff");
                return true;
            }

            if (ForceofNature && Aimsharp.CanCast(ForceOfNature_SpellName(Language), "player", false, true))
            {
                switch (ForceofNatureCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Force of Nature - " + ForceofNatureCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(ForceOfNature_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Force of Nature - " + ForceofNatureCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ForceofNatureP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Force of Nature - " + ForceofNatureCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ForceofNatureC");
                        return true;
                }
            }

            //Queue Ursol's Vortex
            string UrsolsVortexCast = GetDropDown("Ursol's Vortex Cast:");
            bool UrsolsVortex = Aimsharp.IsCustomCodeOn("UrsolsVortex");
            if (Aimsharp.SpellCooldown(UrsolsVortex_SpellName(Language)) - Aimsharp.GCD() > 2000 && UrsolsVortex)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Ursol's Vortex Queue", Color.Purple);
                }
                Aimsharp.Cast("UrsolsVortexOff");
                return true;
            }

            if (UrsolsVortex && Aimsharp.CanCast(UrsolsVortex_SpellName(Language), "player", false, true))
            {
                switch (UrsolsVortexCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ursol's Vortex - " + UrsolsVortexCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(UrsolsVortex_SpellName(Language));
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ursol's Vortex - " + UrsolsVortexCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("UrsolsVortexP");
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ursol's Vortex - " + UrsolsVortexCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("UrsolsVortexC");
                        return true;
                }
            }

            bool Regrowth = Aimsharp.IsCustomCodeOn("Regrowth");
            if (Regrowth && Aimsharp.CanCast(Regrowth_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Spamming Regrowth through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Regrowth_SpellName(Language));
                return true;
            }
            #endregion

            #region Out of Combat Spells
            //Auto Mark of the Wild
            if (SpellID1 == 1126 && Aimsharp.CanCast(MarkOfTheWild_SpellName(Language), "player", false, true) && MOTWOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mark of the Wild (Out of Combat) - " + SpellID1, Color.Black);
                }
                Aimsharp.Cast(MarkOfTheWild_SpellName(Language));
                return true;
            }

            if (Aimsharp.CanCast(MarkOfTheWild_SpellName(Language), "player", false, true) && !Aimsharp.HasBuff(MarkOfTheWild_SpellName(Language), "player", true) && MOTWOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mark of the Wild (Out of Combat) - " + SpellID1, Color.Black);
                }
                Aimsharp.Cast(MarkOfTheWild_SpellName(Language));
                return true;
            }
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 45 && TargetInCombat)
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