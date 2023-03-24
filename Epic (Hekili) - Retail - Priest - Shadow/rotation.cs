using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicPriestShadowHekili : Rotation
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

        ///<summary>spell=325283</summary>
        private static string AscendedBlast_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ascended Blast";
                case "Deutsch": return "Woge des Aufstiegs";
                case "Español": return "Explosión ascendida";
                case "Français": return "Déflagration d’ascension";
                case "Italiano": return "Detonazione Ascesa";
                case "Português Brasileiro": return "Impacto Ascendido";
                case "Русский": return "Взрыв перерождения";
                case "한국어": return "승천의 작렬";
                case "简体中文": return "晋升冲击";
                default: return "Ascended Blast";
            }
        }

        ///<summary>spell=325020</summary>
        private static string AscendedNova_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ascended Nova";
                case "Deutsch": return "Nova des Aufstiegs";
                case "Español": return "Nova ascendida";
                case "Français": return "Nova transcendée";
                case "Italiano": return "Nova Ascesa";
                case "Português Brasileiro": return "Nova Ascendida";
                case "Русский": return "Кольцо перерождения";
                case "한국어": return "승천의 회오리";
                case "简体中文": return "晋升新星";
                default: return "Ascended Nova";
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

        ///<summary>spell=325013</summary>
        private static string BoonOfTheAscended_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Boon of the Ascended";
                case "Deutsch": return "Segen der Aufgestiegenen";
                case "Español": return "Bendición de los Ascendidos";
                case "Français": return "Faveur des transcendés";
                case "Italiano": return "Dono degli Ascesi";
                case "Português Brasileiro": return "Dom dos Ascendidos";
                case "Русский": return "Благословение перерожденных";
                case "한국어": return "승천자의 은혜";
                case "简体中文": return "晋升者之赐";
                default: return "Boon of the Ascended";
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

        ///<summary>spell=341374</summary>
        private static string Damnation_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Damnation";
                case "Deutsch": return "Bezichtigung";
                case "Español": return "Condenación";
                case "Français": return "Damnation";
                case "Italiano": return "Dannazione";
                case "Português Brasileiro": return "Danação";
                case "Русский": return "Проклятие";
                case "한국어": return "아비규환";
                case "简体中文": return "咒罚";
                default: return "Damnation";
            }
        }

        ///<summary>spell=391109</summary>
        private static string DarkAscension_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dark Ascension";
                case "Deutsch": return "Dunkler Aufstieg";
                case "Español": return "Ascensión oscura";
                case "Français": return "Sombre ascension";
                case "Italiano": return "Ascensione Oscura";
                case "Português Brasileiro": return "Ascensão Sombria";
                case "Русский": return "Темное вознесение";
                case "한국어": return "어둠의 승천";
                case "简体中文": return "黑暗升华";
                default: return "Dark Ascension";
            }
        }

        ///<summary>spell=341207</summary>
        private static string DarkThought_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dark Thought";
                case "Deutsch": return "Dunkler Gedanke";
                case "Español": return "Pensamiento oscuro";
                case "Français": return "Sombre pensée";
                case "Italiano": return "Pensiero Oscuro";
                case "Português Brasileiro": return "Pensamento Sombrio";
                case "Русский": return "Темная мысль";
                case "한국어": return "어둠의 생각";
                case "简体中文": return "黑暗思维";
                default: return "Dark Thought";
            }
        }

        ///<summary>spell=263346</summary>
        private static string DarkVoid_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dark Void";
                case "Deutsch": return "Dunkle Leere";
                case "Español": return "Vacío oscuro";
                case "Français": return "Vide sombre";
                case "Italiano": return "Vuoto Oscuro";
                case "Português Brasileiro": return "Caos Sombrio";
                case "Русский": return "Темная Бездна";
                case "한국어": return "암흑 공허";
                case "简体中文": return "幽暗虚无";
                default: return "Dark Void";
            }
        }

        ///<summary>spell=19236</summary>
        private static string DesperatePrayer_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Desperate Prayer";
                case "Deutsch": return "Verzweifeltes Gebet";
                case "Español": return "Rezo desesperado";
                case "Français": return "Prière du désespoir";
                case "Italiano": return "Preghiera Disperata";
                case "Português Brasileiro": return "Prece Desesperada";
                case "Русский": return "Молитва отчаяния";
                case "한국어": return "구원의 기도";
                case "简体中文": return "绝望祷言";
                default: return "Desperate Prayer";
            }
        }

        ///<summary>spell=335467</summary>
        private static string DevouringPlague_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Devouring Plague";
                case "Deutsch": return "Verschlingende Seuche";
                case "Español": return "Peste devoradora";
                case "Français": return "Peste dévorante";
                case "Italiano": return "Piaga Divoratrice";
                case "Português Brasileiro": return "Peste Devoradora";
                case "Русский": return "Всепожирающая чума";
                case "한국어": return "파멸의 역병";
                case "简体中文": return "噬灵疫病";
                default: return "Devouring Plague";
            }
        }

        ///<summary>spell=528</summary>
        private static string DispelMagic_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dispel Magic";
                case "Deutsch": return "Magiebannung";
                case "Español": return "Disipar magia";
                case "Français": return "Dissipation de la magie";
                case "Italiano": return "Dissoluzione Magica";
                case "Português Brasileiro": return "Dissipar Magia";
                case "Русский": return "Рассеивание заклинаний";
                case "한국어": return "마법 무효화";
                case "简体中文": return "驱散魔法";
                default: return "Dispel Magic";
            }
        }

        ///<summary>spell=47585</summary>
        private static string Dispersion_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dispersion";
                case "Deutsch": return "Dispersion";
                case "Español": return "Dispersión";
                case "Français": return "Dispersion";
                case "Italiano": return "Dispersione";
                case "Português Brasileiro": return "Dispersão";
                case "Русский": return "Слияние с Тьмой";
                case "한국어": return "분산";
                case "简体中文": return "消散";
                default: return "Dispersion";
            }
        }

        ///<summary>spell=122121</summary>
        private static string DivineStar_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Divine Star";
                case "Deutsch": return "Göttlicher Stern";
                case "Español": return "Estrella divina";
                case "Français": return "Étoile divine";
                case "Italiano": return "Stella Divina";
                case "Português Brasileiro": return "Estrela Divina";
                case "Русский": return "Божественная звезда";
                case "한국어": return "천상의 별";
                case "简体中文": return "神圣之星";
                default: return "Divine Star";
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

        ///<summary>spell=327661</summary>
        private static string FaeGuardians_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fae Guardians";
                case "Deutsch": return "Faewächter";
                case "Español": return "Sílfides guardianas";
                case "Français": return "Gardiens faë";
                case "Italiano": return "Guardiani Silfi";
                case "Português Brasileiro": return "Guardiões Feérios";
                case "Русский": return "Волшебные стражи";
                case "한국어": return "페이 수호자";
                case "简体中文": return "法夜守护者";
                default: return "Fae Guardians";
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

        ///<summary>spell=120644</summary>
        private static string Halo_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Halo";
                case "Deutsch": return "Strahlenkranz";
                case "Español": return "Halo";
                case "Français": return "Halo";
                case "Italiano": return "Aureola";
                case "Português Brasileiro": return "Halo";
                case "Русский": return "Сияние";
                case "한국어": return "후광";
                case "简体中文": return "光晕";
                default: return "Halo";
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

        ///<summary>spell=73325</summary>
        private static string LeapOfFaith_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Leap of Faith";
                case "Deutsch": return "Glaubenssprung";
                case "Español": return "Salto de fe";
                case "Français": return "Saut de foi";
                case "Italiano": return "Balzo della Fede";
                case "Português Brasileiro": return "Salto da Fé";
                case "Русский": return "Духовное рвение";
                case "한국어": return "신의의 도약";
                case "简体中文": return "信仰飞跃";
                default: return "Leap of Faith";
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

        ///<summary>spell=32375</summary>
        private static string MassDispel_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mass Dispel";
                case "Deutsch": return "Massenbannung";
                case "Español": return "Disipación en masa";
                case "Français": return "Dissipation de masse";
                case "Italiano": return "Dissoluzione di Massa";
                case "Português Brasileiro": return "Dissipação em Massa";
                case "Русский": return "Массовое рассеивание";
                case "한국어": return "대규모 무효화";
                case "简体中文": return "群体驱散";
                default: return "Mass Dispel";
            }
        }

        ///<summary>spell=8092</summary>
        private static string MindBlast_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mind Blast";
                case "Deutsch": return "Gedankenschlag";
                case "Español": return "Explosión mental";
                case "Français": return "Attaque mentale";
                case "Italiano": return "Detonazione Mentale";
                case "Português Brasileiro": return "Impacto Mental";
                case "Русский": return "Взрыв разума";
                case "한국어": return "정신 분열";
                case "简体中文": return "心灵震爆";
                default: return "Mind Blast";
            }
        }

        ///<summary>spell=205369</summary>
        private static string MindBomb_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mind Bomb";
                case "Deutsch": return "Gedankenbombe";
                case "Español": return "Bomba mental";
                case "Français": return "Explosion mentale";
                case "Italiano": return "Bomba Mentale";
                case "Português Brasileiro": return "Bomba Psíquica";
                case "Русский": return "Мыслебомба";
                case "한국어": return "정신 폭탄";
                case "简体中文": return "心灵炸弹";
                default: return "Mind Bomb";
            }
        }

        ///<summary>spell=605</summary>
        private static string MindControl_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mind Control";
                case "Deutsch": return "Gedankenkontrolle";
                case "Español": return "Control mental";
                case "Français": return "Contrôle mental";
                case "Italiano": return "Controllo Mentale";
                case "Português Brasileiro": return "Controle Mental";
                case "Русский": return "Контроль над разумом";
                case "한국어": return "정신 지배";
                case "简体中文": return "精神控制";
                default: return "Mind Control";
            }
        }

        ///<summary>spell=15407</summary>
        private static string MindFlay_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mind Flay";
                case "Deutsch": return "Gedankenschinden";
                case "Español": return "Tortura mental";
                case "Français": return "Fouet mental";
                case "Italiano": return "Flagello Mentale";
                case "Português Brasileiro": return "Açoite Mental";
                case "Русский": return "Пытка разума";
                case "한국어": return "정신의 채찍";
                case "简体中文": return "精神鞭笞";
                default: return "Mind Flay";
            }
        }

        ///<summary>spell=391403</summary>
        private static string MindFlay_Insanity_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mind Flay: Insanity";
                case "Deutsch": return "Gedankenschinden: Wahnsinn";
                case "Español": return "Tortura mental: demencia";
                case "Français": return "Fouet mental : insanité";
                case "Italiano": return "Flagello Mentale: Pazzia";
                case "Português Brasileiro": return "Açoite Mental: Insanidade";
                case "Русский": return "Пытка разума: безумие";
                case "한국어": return "정신의 채찍: 광기";
                case "简体中文": return "精神鞭笞：狂";
                default: return "Mind Flay: Insanity";
            }
        }

        ///<summary>spell=48045</summary>
        private static string MindSear_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mind Sear";
                case "Deutsch": return "Gedankenexplosion";
                case "Español": return "Abrasamiento mental";
                case "Français": return "Incandescence mentale";
                case "Italiano": return "Risonanza Mentale";
                case "Português Brasileiro": return "Calcinação Mental";
                case "Русский": return "Иссушение разума";
                case "한국어": return "정신 불태우기";
                case "简体中文": return "精神灼烧";
                default: return "Mind Sear";
            }
        }

        ///<summary>spell=73510</summary>
        private static string MindSpike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mind Spike";
                case "Deutsch": return "Gedankenstachel";
                case "Español": return "Púa mental";
                case "Français": return "Pointe mentale";
                case "Italiano": return "Aculeo Mentale";
                case "Português Brasileiro": return "Aguilhão Mental";
                case "Русский": return "Пронзание разума";
                case "한국어": return "정신의 쐐기";
                case "简体中文": return "心灵尖刺";
                default: return "Mind Spike";
            }
        }

        ///<summary>spell=200174</summary>
        private static string Mindbender_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mindbender";
                case "Deutsch": return "Geistbeuger";
                case "Español": return "Dominamentes";
                case "Français": return "Torve-esprit";
                case "Italiano": return "Plagiamente";
                case "Português Brasileiro": return "Dobramentes";
                case "Русский": return "Подчинитель разума";
                case "한국어": return "환각의 마귀";
                case "简体中文": return "摧心魔";
                default: return "Mindbender";
            }
        }

        ///<summary>spell=323673</summary>
        private static string Mindgames_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Mindgames";
                case "Deutsch": return "Gedankenspiele";
                case "Español": return "Juegos mentales";
                case "Français": return "Jeux d’esprit";
                case "Italiano": return "Giochi Mentali";
                case "Português Brasileiro": return "Jogos Mentais";
                case "Русский": return "Игры разума";
                case "한국어": return "정신 조작";
                case "简体中文": return "控心术";
                default: return "Mindgames";
            }
        }

        ///<summary>spell=10060</summary>
        private static string PowerInfusion_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Power Infusion";
                case "Deutsch": return "Seele der Macht";
                case "Español": return "Infusión de poder";
                case "Français": return "Infusion de puissance";
                case "Italiano": return "Infusione di Potere";
                case "Português Brasileiro": return "Infusão de Poder";
                case "Русский": return "Придание сил";
                case "한국어": return "마력 주입";
                case "简体中文": return "能量灌注";
                default: return "Power Infusion";
            }
        }

        ///<summary>spell=21562</summary>
        private static string PowerWord_Fortitude_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Power Word: Fortitude";
                case "Deutsch": return "Machtwort: Seelenstärke";
                case "Español": return "Palabra de poder: entereza";
                case "Français": return "Mot de pouvoir : Robustesse";
                case "Italiano": return "Parola del Potere: Fermezza";
                case "Português Brasileiro": return "Palavra de Poder: Fortitude";
                case "Русский": return "Слово силы: Стойкость";
                case "한국어": return "신의 권능: 인내";
                case "简体中文": return "真言术：韧";
                default: return "Power Word: Fortitude";
            }
        }

        ///<summary>spell=17</summary>
        private static string PowerWord_Shield_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Power Word: Shield";
                case "Deutsch": return "Machtwort: Schild";
                case "Español": return "Palabra de poder: escudo";
                case "Français": return "Mot de pouvoir : Bouclier";
                case "Italiano": return "Parola del Potere: Scudo";
                case "Português Brasileiro": return "Palavra de Poder: Escudo";
                case "Русский": return "Слово силы: Щит";
                case "한국어": return "신의 권능: 보호막";
                case "简体中文": return "真言术：盾";
                default: return "Power Word: Shield";
            }
        }

        ///<summary>spell=64044</summary>
        private static string PsychicHorror_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Psychic Horror";
                case "Deutsch": return "Psychisches Entsetzen";
                case "Español": return "Horror psíquico";
                case "Français": return "Horreur psychique";
                case "Italiano": return "Orrore Psichico";
                case "Português Brasileiro": return "Terror Psíquico";
                case "Русский": return "Глубинный ужас";
                case "한국어": return "정신적 두려움";
                case "简体中文": return "心灵惊骇";
                default: return "Psychic Horror";
            }
        }

        ///<summary>spell=8122</summary>
        private static string PsychicScream_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Psychic Scream";
                case "Deutsch": return "Psychischer Schrei";
                case "Español": return "Alarido psíquico";
                case "Français": return "Cri psychique";
                case "Italiano": return "Urlo Psichico";
                case "Português Brasileiro": return "Grito Psíquico";
                case "Русский": return "Ментальный крик";
                case "한국어": return "영혼의 절규";
                case "简体中文": return "心灵尖啸";
                default: return "Psychic Scream";
            }
        }

        ///<summary>spell=213634</summary>
        private static string PurifyDisease_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Purify Disease";
                case "Deutsch": return "Krankheit läutern";
                case "Español": return "Purificar enfermedad";
                case "Français": return "Purifier la maladie";
                case "Italiano": return "Purificazione Malattia";
                case "Português Brasileiro": return "Purificar Doença";
                case "Русский": return "Очищение от болезни";
                case "한국어": return "질병 정화";
                case "简体中文": return "净化疾病";
                default: return "Purify Disease";
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

        ///<summary>spell=341385</summary>
        private static string SearingNightmare_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Searing Nightmare";
                case "Deutsch": return "Sengender Alptraum";
                case "Español": return "Pesadilla abrasadora";
                case "Français": return "Cauchemar brûlant";
                case "Italiano": return "Incubo Rovente";
                case "Português Brasileiro": return "Pesadelo Calcinante";
                case "Русский": return "Иссушающий кошмар";
                case "한국어": return "불타는 악몽";
                case "简体中文": return "灼烧梦魇";
                default: return "Searing Nightmare";
            }
        }

        ///<summary>spell=9484</summary>
        private static string ShackleUndead_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shackle Undead";
                case "Deutsch": return "Untote fesseln";
                case "Español": return "Encadenar no-muerto";
                case "Français": return "Entraves des Morts-vivants";
                case "Italiano": return "Incatena Non Morto";
                case "Português Brasileiro": return "Agrilhoar Morto-vivo";
                case "Русский": return "Сковывание нежити";
                case "한국어": return "언데드 속박";
                case "简体中文": return "束缚亡灵";
                default: return "Shackle Undead";
            }
        }

        ///<summary>spell=205385</summary>
        private static string ShadowCrash_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shadow Crash";
                case "Deutsch": return "Schattengeschoss";
                case "Español": return "Fragor de las Sombras";
                case "Français": return "Déferlante d’ombre";
                case "Italiano": return "Schianto d'Ombra";
                case "Português Brasileiro": return "Colisão de Sombras";
                case "Русский": return "Темное сокрушение";
                case "한국어": return "어둠 붕괴";
                case "简体中文": return "暗影冲撞";
                default: return "Shadow Crash";
            }
        }

        ///<summary>spell=299268</summary>
        private static string ShadowMend_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shadow Mend";
                case "Deutsch": return "Schattenheilung";
                case "Español": return "Alivio de las Sombras";
                case "Français": return "Guérison de l’ombre";
                case "Italiano": return "Cura d'Ombra";
                case "Português Brasileiro": return "Recomposição Sombria";
                case "Русский": return "Темное восстановление";
                case "한국어": return "어둠의 치유";
                case "简体中文": return "暗影愈合";
                default: return "Shadow Mend";
            }
        }

        ///<summary>spell=32379</summary>
        private static string ShadowWord_Death_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shadow Word: Death";
                case "Deutsch": return "Schattenwort: Tod";
                case "Español": return "Palabra de las Sombras: muerte";
                case "Français": return "Mot de l’ombre : Mort";
                case "Italiano": return "Parola d'Ombra: Morte";
                case "Português Brasileiro": return "Palavra Sombria: Morte";
                case "Русский": return "Слово Тьмы: Смерть";
                case "한국어": return "어둠의 권능: 죽음";
                case "简体中文": return "暗言术：灭";
                default: return "Shadow Word: Death";
            }
        }

        ///<summary>spell=589</summary>
        private static string ShadowWord_Pain_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shadow Word: Pain";
                case "Deutsch": return "Schattenwort: Schmerz";
                case "Español": return "Palabra de las Sombras: dolor";
                case "Français": return "Mot de l’ombre : Douleur";
                case "Italiano": return "Parola d'Ombra: Dolore";
                case "Português Brasileiro": return "Palavra Sombria: Dor";
                case "Русский": return "Слово Тьмы: Боль";
                case "한국어": return "어둠의 권능: 고통";
                case "简体中文": return "暗言术：痛";
                default: return "Shadow Word: Pain";
            }
        }

        ///<summary>spell=34433</summary>
        private static string Shadowfiend_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shadowfiend";
                case "Deutsch": return "Schattengeist";
                case "Español": return "Maligno de las Sombras";
                case "Français": return "Ombrefiel";
                case "Italiano": return "Spirito d'Ombra";
                case "Português Brasileiro": return "Demônio das Sombras";
                case "Русский": return "Исчадие Тьмы";
                case "한국어": return "어둠의 마귀";
                case "简体中文": return "暗影魔";
                default: return "Shadowfiend";
            }
        }

        ///<summary>spell=232698</summary>
        private static string Shadowform_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Shadowform";
                case "Deutsch": return "Schattengestalt";
                case "Español": return "Forma de las Sombras";
                case "Français": return "Forme d'Ombre";
                case "Italiano": return "Forma d'Ombra";
                case "Português Brasileiro": return "Forma de Sombra";
                case "Русский": return "Облик Тьмы";
                case "한국어": return "어둠의 형상";
                case "简体中文": return "暗影形态";
                default: return "Shadowform";
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

        ///<summary>spell=15487</summary>
        private static string Silence_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Silence";
                case "Deutsch": return "Stille";
                case "Español": return "Silencio";
                case "Français": return "Silence";
                case "Italiano": return "Silenzio";
                case "Português Brasileiro": return "Silêncio";
                case "Русский": return "Безмолвие";
                case "한국어": return "침묵";
                case "简体中文": return "沉默";
                default: return "Silence";
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

        ///<summary>spell=324724</summary>
        private static string UnholyNova_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Unholy Nova";
                case "Deutsch": return "Unheilige Nova";
                case "Español": return "Nova profana";
                case "Français": return "Nova impie";
                case "Italiano": return "Nova Empia";
                case "Português Brasileiro": return "Nova Profana";
                case "Русский": return "Нечестивое кольцо";
                case "한국어": return "부정한 폭발";
                case "简体中文": return "邪恶新星";
                default: return "Unholy Nova";
            }
        }

        ///<summary>spell=15286</summary>
        private static string VampiricEmbrace_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Vampiric Embrace";
                case "Deutsch": return "Vampirumarmung";
                case "Español": return "Abrazo vampírico";
                case "Français": return "Étreinte vampirique";
                case "Italiano": return "Abbraccio Vampirico";
                case "Português Brasileiro": return "Abraço Vampírico";
                case "Русский": return "Объятия вампира";
                case "한국어": return "흡혈의 선물";
                case "简体中文": return "吸血鬼的拥抱";
                default: return "Vampiric Embrace";
            }
        }

        ///<summary>spell=34914</summary>
        private static string VampiricTouch_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Vampiric Touch";
                case "Deutsch": return "Vampirberührung";
                case "Español": return "Toque vampírico";
                case "Français": return "Toucher vampirique";
                case "Italiano": return "Tocco Vampirico";
                case "Português Brasileiro": return "Toque Vampírico";
                case "Русский": return "Прикосновение вампира";
                case "한국어": return "흡혈의 손길";
                case "简体中文": return "吸血鬼之触";
                default: return "Vampiric Touch";
            }
        }

        ///<summary>spell=205448</summary>
        private static string VoidBolt_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Void Bolt";
                case "Deutsch": return "Leerenblitz";
                case "Español": return "Descarga del Vacío";
                case "Français": return "Éclair de Vide";
                case "Italiano": return "Dardo del Vuoto";
                case "Português Brasileiro": return "Seta Caótica";
                case "Русский": return "Стрела Бездны";
                case "한국어": return "공허의 화살";
                case "简体中文": return "虚空箭";
                default: return "Void Bolt";
            }
        }

        ///<summary>spell=228260</summary>
        private static string VoidEruption_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Void Eruption";
                case "Deutsch": return "Leereneruption";
                case "Español": return "Erupción del Vacío";
                case "Français": return "Éruption du Vide";
                case "Italiano": return "Eruzione del Vuoto";
                case "Português Brasileiro": return "Erupção do Caos";
                case "Русский": return "Извержение Бездны";
                case "한국어": return "공허 방출";
                case "简体中文": return "虚空爆发";
                default: return "Void Eruption";
            }
        }

        ///<summary>spell=263165</summary>
        private static string VoidTorrent_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Void Torrent";
                case "Deutsch": return "Leerenstrom";
                case "Español": return "Torrente del Vacío";
                case "Français": return "Torrent du Vide";
                case "Italiano": return "Torrente del Vuoto";
                case "Português Brasileiro": return "Torrente do Caos";
                case "Русский": return "Поток Бездны";
                case "한국어": return "공허의 격류";
                case "简体中文": return "虚空洪流";
                default: return "Void Torrent";
            }
        }

        ///<summary>spell=194249</summary>
        private static string Voidform_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Voidform";
                case "Deutsch": return "Leerengestalt";
                case "Español": return "Forma del Vacío";
                case "Français": return "Forme du Vide";
                case "Italiano": return "Forma del Vuoto";
                case "Português Brasileiro": return "Forma do Caos";
                case "Русский": return "Облик Бездны";
                case "한국어": return "공허의 형상";
                case "简体中文": return "虚空形态";
                default: return "Voidform";
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
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle", "NoPurify", "ShadowCrash", "MindControl", "LeapofFaith", "ShackleUndead", "PowerInfusion", "MindBomb", "PsychicHorror", "PsychicScream", "MassDispel", "VampiricTouch", "ShadowWordPain", "BodyandSoul", };
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
            Macros.Add("PD_FOC", "/cast [@focus] " + PurifyDisease_SpellName(Language));

            //Queues
            Macros.Add("ShadowCrashOff", "/" + FiveLetters + " ShadowCrash");
            Macros.Add("ShadowCrashC", "/cast [@cursor] " + ShadowCrash_SpellName(Language));
            Macros.Add("ShadowCrashP", "/cast [@player] " + ShadowCrash_SpellName(Language));

            Macros.Add("MassDispelOff", "/" + FiveLetters + " MassDispel");
            Macros.Add("MassDispelC", "/cast [@cursor] " + MassDispel_SpellName(Language));
            Macros.Add("MassDispelP", "/cast [@player] " + MassDispel_SpellName(Language));

            Macros.Add("MindControlOff", "/" + FiveLetters + " MindControl");
            Macros.Add("MindControlMO", "/cast [@mouseover] " + MindControl_SpellName(Language));

            Macros.Add("LeapofFaithOff", "/" + FiveLetters + " LeapofFaith");
            Macros.Add("LeapofFaithMO", "/cast [@mouseover] " + LeapOfFaith_SpellName(Language));

            Macros.Add("ShackleUndeadOff", "/" + FiveLetters + " ShackleUndead");
            Macros.Add("ShackleUndeadMO", "/cast [@mouseover] " + ShackleUndead_SpellName(Language));

            Macros.Add("PowerInfusionOff", "/" + FiveLetters + " PowerInfusion");
            Macros.Add("PowerInfusionMO", "/cast [@mouseover] " + PowerInfusion_SpellName(Language));

            Macros.Add("MindBombOff", "/" + FiveLetters + " MindBomb");
            Macros.Add("MindBombMO", "/cast [@mouseover] " + MindBomb_SpellName(Language));

            Macros.Add("PsychicHorrorOff", "/" + FiveLetters + " PsychicHorror");
            Macros.Add("PsychicHorrorMO", "/cast [@mouseover] " + PsychicHorror_SpellName(Language));

            Macros.Add("PsychicScreamOff", "/" + FiveLetters + " PsychicScream");

            Macros.Add("DispelMagicMO", "/cast [@mouseover] " + DispelMagic_SpellName(Language));
            Macros.Add("ShadowWordPainMO", "/cast [@mouseover] " + ShadowWord_Pain_SpellName(Language));
            Macros.Add("VampiricTouchMO", "/cast [@mouseover] " + VampiricTouch_SpellName(Language));

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

            CustomFunctions.Add("HekiliEnemies", "if Hekili.State.active_enemies ~= nil and Hekili.State.active_enemies > 0 then return Hekili.State.active_enemies end return 0");

            CustomFunctions.Add("TargetIsMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitExists('target') and UnitIsDead('target') ~= true and UnitIsUnit('mouseover', 'target') then return 1 end; return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");

            CustomFunctions.Add("CycleNotEnabled", "local cycle = 0 if Hekili.State.settings.spec.cycle == true then cycle = 1 else if Hekili.State.settings.spec.cycle == false then cycle = 2 end end return cycle");

            CustomFunctions.Add("DiseaseCheck", "local y=0; " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"player\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Disease\" then y = y +1; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Disease\" then y = y +2; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Disease\" then y = y +4; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Disease\" then y = y +8; end end " +
            "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
            "if type ~= nil and type == \"Disease\" then y = y +16; end end " +
            "return y");

            CustomFunctions.Add("UnitIsFocus", "local foc=0; " +
            "\nif UnitExists('focus') and UnitIsUnit('party1','focus') then foc = 1; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party2','focus') then foc = 2; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party3','focus') then foc = 3; end" +
            "\nif UnitExists('focus') and UnitIsUnit('party4','focus') then foc = 4; end" +
            "\nif UnitExists('focus') and UnitIsUnit('player','focus') then foc = 5; end" +
            "\nreturn foc");

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

            CustomFunctions.Add("DispelMagicCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Dispel Magic','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType,_,_,_  = UnitBuff('mouseover', y) if debuffType == 'Magic' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("SWPCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Shadow Word: Pain','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType,_,_,_  = UnitDebuff('mouseover', y) if name == 'Shadow Word: Pain' then markcheck = markcheck + 2 end end return markcheck end return 0");
            CustomFunctions.Add("VTCheckMouseover", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Vampiric Touch','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,debuffType,_,_,_  = UnitDebuff('mouseover', y) if name == 'Vampiric Touch' then markcheck = markcheck + 2 end end return markcheck end return 0");
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
            Settings.Add(new Setting("Race:", m_RaceList, "gnome"));
            Settings.Add(new Setting("Ingame World Latency:", 1, 200, 50));
            Settings.Add(new Setting(" "));
            Settings.Add(new Setting("Use Trinkets on CD, dont wait for Hekili:", false));
            Settings.Add(new Setting("Auto Healthstone @ HP%", 0, 100, 25));
            Settings.Add(new Setting("Auto Phial of Serenity @ HP%", 0, 100, 35));
            Settings.Add(new Setting("Kicks/Interrupts"));
            Settings.Add(new Setting("Randomize Kicks:", false));
            Settings.Add(new Setting("Kick at milliseconds remaining", 50, 1500, 500));
            Settings.Add(new Setting("Kick channels after milliseconds", 50, 1500, 500));
            Settings.Add(new Setting("General"));
            Settings.Add(new Setting("Auto Start Combat:", true));
            Settings.Add(new Setting("Shadowform Out of Combat:", true));
            Settings.Add(new Setting("Fortitude Out of Combat:", true));
            Settings.Add(new Setting("Auto Dispel Magic Mouseover:", true));
            Settings.Add(new Setting("Auto Desperate Prayer @ HP%", 0, 100, 30));
            Settings.Add(new Setting("Auto Dispersion @ HP%", 0, 100, 10));
            Settings.Add(new Setting("Shadow Crash Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Mass Dispel Cast:", m_CastingList, "Manual"));
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

            Aimsharp.PrintMessage("Epic PVE - Priest Shadow", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/priest/shadow/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoPurify - Disables Purify Disease", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " MindControl - Casts Mind Control @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " LeapofFaith - Casts Leap of Faith @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " ShackleUndead - Casts Shackle Undead @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " PowerInfusion - Casts Power Infusion @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " ShadowWordPain - Enables Shadow Word: Pain @ Mouseover spread", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " VampiricTouch - Enables Vampiric Touch @ Mouseover spread", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " MindBomb - Casts Mind Bomb @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " PsychicHorror - Casts Psychic Horror @ Mouseover next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " ShadowCrash - Casts Shadow Crash @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " PsychicScream - Casts Psychic Scream @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " MassDispel - Casts Mass Dispel @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BodyandSoul - Casts Power Word: Shield when moving for the speed increase", Color.Yellow);
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

            #region ReinitializeLists
            m_DebuffsList = new List<string> { "Weakened Soul", };
            m_BuffsList = new List<string> { DarkThought_SpellName(Language), };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language) };
            m_SpellBook_General = new List<string> {
                //Covenants
                BoonOfTheAscended_SpellName(Language), //325013
                AscendedNova_SpellName(Language), //325020
                AscendedBlast_SpellName(Language), //325283
                UnholyNova_SpellName(Language), //324724
                FaeGuardians_SpellName(Language), //327661
                Mindgames_SpellName(Language), //323673

                //Interrupt
                Silence_SpellName(Language), //15487

                //General
                DesperatePrayer_SpellName(Language), //19236
                DispelMagic_SpellName(Language), //528
                DivineStar_SpellName(Language), //122121
                Halo_SpellName(Language), //120644
                LeapOfFaith_SpellName(Language), //73325 - queue MO
                MassDispel_SpellName(Language), //32375 - queue Cast
                MindBlast_SpellName(Language), //8092
                MindControl_SpellName(Language), //605 - queue MO
                PowerInfusion_SpellName(Language), //10060 - queue MO
                PowerWord_Fortitude_SpellName(Language), //21562
                PowerWord_Shield_SpellName(Language), //17
                PsychicScream_SpellName(Language), //8122 - queue
                ShackleUndead_SpellName(Language), //9484 - queue MO
                ShadowWord_Death_SpellName(Language), //32379
                ShadowWord_Pain_SpellName(Language), //589

                //Shadow
                Damnation_SpellName(Language), //341374
                DarkAscension_SpellName(Language), //391109
                DarkVoid_SpellName(Language), //263346
                DevouringPlague_SpellName(Language), //335467
                Dispersion_SpellName(Language), //47585 - option
                MindBomb_SpellName(Language), //205369 - queue mo
                MindFlay_SpellName(Language), //15407
                MindFlay_Insanity_SpellName(Language), //391403
                MindSear_SpellName(Language), //48045
                MindSpike_SpellName(Language), //73510
                Mindbender_SpellName(Language), //200174
                PsychicHorror_SpellName(Language), //64044 - queue mo
                PurifyDisease_SpellName(Language), //213634
                SearingNightmare_SpellName(Language), //341385
                ShadowCrash_SpellName(Language), //205385 - Cast
                ShadowMend_SpellName(Language), //299268
                Shadowfiend_SpellName(Language), //34433
                Shadowform_SpellName(Language), //232698
                VampiricEmbrace_SpellName(Language), //15286
                VampiricTouch_SpellName(Language), //34914
                VoidBolt_SpellName(Language), //205448
                VoidEruption_SpellName(Language), //228260
                VoidTorrent_SpellName(Language), //263165
                Voidform_SpellName(Language), //194249
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
            int Enemies = Aimsharp.CustomFunction("HekiliEnemies");
            int TargetingGroup = Aimsharp.CustomFunction("GroupTargets");

            bool NoInterrupts = Aimsharp.IsCustomCodeOn("NoInterrupts");
            bool NoCycle = Aimsharp.IsCustomCodeOn("NoCycle");
            bool NoPurify = Aimsharp.IsCustomCodeOn("NoPurify");

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

            int DesperatePrayerHP = GetSlider("Auto Desperate Prayer @ HP%");
            int DispersionHP = GetSlider("Auto Dispersion @ HP%");
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
            if (SpellID1 == 341385 && Aimsharp.CanCast(SearingNightmare_SpellName(Language), "player", false, false) && Wait <= 200)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Searing Nightmare - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(SearingNightmare_SpellName(Language));
                return true;
            }

            if (SpellID1 == 8092 && Aimsharp.CanCast(MindBlast_SpellName(Language), "target", true, false) && Aimsharp.HasBuff(DarkThought_SpellName(Language), "player", true) && Wait <= 200)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mind Blast - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(MindBlast_SpellName(Language));
                return true;
            }

            if (Aimsharp.CastingID("player") == 605 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("MindControl"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mind Control Queue", Color.Purple);
                }
                Aimsharp.Cast("MindControlOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 9484 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("ShackleUndead"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shackle Undead Queue", Color.Purple);
                }
                Aimsharp.Cast("ShackleUndeadOff");
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

            if (Aimsharp.IsCustomCodeOn("ShadowCrash") && Aimsharp.SpellCooldown(ShadowCrash_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("MassDispel") && Aimsharp.SpellCooldown(MassDispel_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                if (Aimsharp.CanCast(Silence_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Silence_SpellName(Language), true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast(Silence_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(Silence_SpellName(Language), true);
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


            //Auto Desperate Prayer
            if (PlayerHP <= DesperatePrayerHP && Aimsharp.CanCast(DesperatePrayer_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Desperate Prayer - Player HP% " + PlayerHP + " due to setting being on HP% " + DesperatePrayerHP, Color.Purple);
                }
                Aimsharp.Cast(DesperatePrayer_SpellName(Language), true);
                return true;
            }

            //Auto Dispersion
            if (PlayerHP <= DispersionHP && Aimsharp.CanCast(Dispersion_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Dispersion - Player HP% " + PlayerHP + " due to setting being on HP% " + DispersionHP, Color.Purple);
                }
                Aimsharp.Cast(Dispersion_SpellName(Language), true);
                return true;
            }

            //Auto Dispel Magic Mouseover
            if (Aimsharp.CanCast(DispelMagic_SpellName(Language), "mouseover", true, true))
            {
                if (GetCheckBox("Auto Dispel Magic Mouseover:") && Aimsharp.CustomFunction("DispelMagicCheckMouseover") == 3)
                {
                    Aimsharp.Cast("DispelMagicMO");
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Dispel Magic on Mouseover", Color.Purple);
                    }
                    return true;
                }
            }

            //Auto Body and Soul PWS
            bool BodyandSoul = Aimsharp.IsCustomCodeOn("BodyandSoul");
            if (BodyandSoul && Aimsharp.CanCast(PowerWord_Shield_SpellName(Language), "player", false, true) && !Aimsharp.HasDebuff("Weakened Soul", "player", true) && !Aimsharp.HasDebuff("Weakened Soul", "player", false) && Moving)
            {
                Aimsharp.Cast(PowerWord_Shield_SpellName(Language));
                return true;
            }
            #endregion

            #region Queues
            bool PsychicScream = Aimsharp.IsCustomCodeOn("PsychicScream");
            if (Aimsharp.SpellCooldown(PsychicScream_SpellName(Language)) - Aimsharp.GCD() > 2000 && PsychicScream)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Psychic Scream Queue", Color.Purple);
                }
                Aimsharp.Cast("PsychicScreamOff");
                return true;
            }

            if (PsychicScream && Aimsharp.CanCast(PsychicScream_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Psychic Scream - Queue", Color.Purple);
                }
                Aimsharp.Cast(PsychicScream_SpellName(Language));
                return true;
            }

            bool PsychicHorror = Aimsharp.IsCustomCodeOn("PsychicHorror");
            if (Aimsharp.SpellCooldown(PsychicHorror_SpellName(Language)) - Aimsharp.GCD() > 2000 && PsychicHorror)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Psychic Horror Queue", Color.Purple);
                }
                Aimsharp.Cast("PsychicHorrorOff");
                return true;
            }

            if (PsychicHorror && Aimsharp.CanCast(PsychicHorror_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Psychic Horror - Queue", Color.Purple);
                }
                Aimsharp.Cast("PsychicHorrorMO");
                return true;
            }

            bool MindBomb = Aimsharp.IsCustomCodeOn("MindBomb");
            if (Aimsharp.SpellCooldown(MindBomb_SpellName(Language)) - Aimsharp.GCD() > 2000 && MindBomb)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mind Bomb Queue", Color.Purple);
                }
                Aimsharp.Cast("MindBombOff");
                return true;
            }

            if (MindBomb && Aimsharp.CanCast(MindBomb_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mind Bomb - Queue", Color.Purple);
                }
                Aimsharp.Cast("MindBombMO");
                return true;
            }

            bool ShackleUndead = Aimsharp.IsCustomCodeOn("ShackleUndead");
            if (Aimsharp.SpellCooldown(ShackleUndead_SpellName(Language)) - Aimsharp.GCD() > 2000 && ShackleUndead)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shackle Undead Queue", Color.Purple);
                }
                Aimsharp.Cast("ShackleUndeadOff");
                return true;
            }

            if (ShackleUndead && Aimsharp.CanCast(ShackleUndead_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Shackle Undead - Queue", Color.Purple);
                }
                Aimsharp.Cast("ShackleUndeadMO");
                return true;
            }

            bool PowerInfusion = Aimsharp.IsCustomCodeOn("PowerInfusion");
            if (Aimsharp.SpellCooldown(PowerInfusion_SpellName(Language)) - Aimsharp.GCD() > 2000 && PowerInfusion)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Power Infusion Queue", Color.Purple);
                }
                Aimsharp.Cast("PowerInfusionOff");
                return true;
            }

            if (PowerInfusion && Aimsharp.CanCast(PowerInfusion_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Power Infusion - Queue", Color.Purple);
                }
                Aimsharp.Cast("PowerInfusionMO");
                return true;
            }

            bool LeapofFaith = Aimsharp.IsCustomCodeOn("LeapofFaith");
            if (Aimsharp.SpellCooldown(LeapOfFaith_SpellName(Language)) - Aimsharp.GCD() > 2000 && LeapofFaith)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Leap of Faith Queue", Color.Purple);
                }
                Aimsharp.Cast("LeapofFaithOff");
                return true;
            }

            if (LeapofFaith && Aimsharp.CanCast(LeapOfFaith_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Leap of Faith - Queue", Color.Purple);
                }
                Aimsharp.Cast("LeapofFaithMO");
                return true;
            }

            bool MindControl = Aimsharp.IsCustomCodeOn("MindControl");
            if ((Aimsharp.SpellCooldown(MindControl_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && MindControl)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mind Control Queue", Color.Purple);
                }
                Aimsharp.Cast("MindControlOff");
                return true;
            }

            if (MindControl && Aimsharp.CanCast(MindControl_SpellName(Language), "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mind Control - Queue", Color.Purple);
                }
                Aimsharp.Cast("MindControlMO");
                return true;
            }

            string MassDispelCast = GetDropDown("Mass Dispel Cast:");
            bool MassDispel = Aimsharp.IsCustomCodeOn("MassDispel");
            if (Aimsharp.SpellCooldown(MassDispel_SpellName(Language)) - Aimsharp.GCD() > 2000 && MassDispel)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mass Dispel Queue", Color.Purple);
                }
                Aimsharp.Cast("MassDispelOff");
                return true;
            }

            if (MassDispel && Aimsharp.CanCast(MassDispel_SpellName(Language), "player", false, true))
            {
                switch (MassDispelCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mass Dispel - " + MassDispelCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(MassDispel_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mass Dispel - " + MassDispelCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MassDispelC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mass Dispel - " + MassDispelCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MassDispelP");
                        return true;
                }
            }

            string ShadowCrashCast = GetDropDown("Shadow Crash Cast:");
            bool ShadowCrash = Aimsharp.IsCustomCodeOn("ShadowCrash");
            if (Aimsharp.SpellCooldown(ShadowCrash_SpellName(Language)) - Aimsharp.GCD() > 2000 && ShadowCrash)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shadow Crash Queue", Color.Purple);
                }
                Aimsharp.Cast("ShadowCrashOff");
                return true;
            }

            if (ShadowCrash && Aimsharp.CanCast(ShadowCrash_SpellName(Language), "player", false, true))
            {
                switch (ShadowCrashCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(ShadowCrash_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowCrashC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowCrashP");
                        return true;
                }
            }

            bool ShadowWordPain = Aimsharp.IsCustomCodeOn("ShadowWordPain");
            if (ShadowWordPain && Aimsharp.CanCast(ShadowWord_Pain_SpellName(Language), "mouseover", true, true) && Aimsharp.CustomFunction("TargetIsMouseover") == 0 && Aimsharp.CustomFunction("SWPCheckMouseover") == 1)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Shadow Word: Pain - Mouseover", Color.Purple);
                }
                Aimsharp.Cast("ShadowWordPainMO");
                return true;
            }

            bool VampiricTouch = Aimsharp.IsCustomCodeOn("VampiricTouch");
            if (VampiricTouch && Aimsharp.CanCast(VampiricTouch_SpellName(Language), "mouseover", true, true) && Aimsharp.CustomFunction("TargetIsMouseover") == 0 && Aimsharp.CustomFunction("VTCheckMouseover") == 1)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Vampiric Touch - Mouseover", Color.Purple);
                }
                Aimsharp.Cast("VampiricTouchMO");
                return true;
            }
            #endregion

            #region Purify Disease
            if (!NoPurify && Aimsharp.CustomFunction("DiseaseCheck") > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != PurifyDisease_SpellName(Language))
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

                int states = Aimsharp.CustomFunction("DiseaseCheck");
                CleansePlayers target;

                int KickTimer = GetRandomNumber(200, 800);

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast(PurifyDisease_SpellName(Language), unit.Key, false, true) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
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
                                Aimsharp.Cast("PD_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Purify Disease @ " + unit.Key + " - " + unit.Value, Color.Purple);
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
            if (!NoCycle && Aimsharp.CustomFunction("CycleNotEnabled") == 1 && Aimsharp.CustomFunction("HekiliCycle") == 1 && Enemies > 1)
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

            if (Aimsharp.TargetIsEnemy() && TargetAlive() && TargetInCombat)
            {
                #region Mouseover Spells

                #endregion

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
                    if (SpellID1 == 325013 && Aimsharp.CanCast(BoonOfTheAscended_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Boon of the Ascended - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(BoonOfTheAscended_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 325020 && Aimsharp.CanCast(AscendedNova_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ascended Nova - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AscendedNova_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 325283 && Aimsharp.CanCast(AscendedBlast_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ascended Blast - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(AscendedBlast_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 324724 && Aimsharp.CanCast(UnholyNova_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Unholy Nova - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(UnholyNova_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 327661 && Aimsharp.CanCast(FaeGuardians_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fae Guardians - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FaeGuardians_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 323673 || SpellID1 == 375901) && Aimsharp.CanCast(Mindgames_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mindgames - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Mindgames_SpellName(Language));
                        return true;
                    }

                    #endregion

                    #region General Spells - NoGCD
                    //Class Spells
                    //Instant [GCD FREE]
                    if (SpellID1 == 15487 && Aimsharp.CanCast(Silence_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Silence - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Silence_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    if (SpellID1 == 10060 && Aimsharp.CanCast(PowerInfusion_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Power Infusion - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(PowerInfusion_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 19236 && Aimsharp.CanCast(DesperatePrayer_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Desperate Prayer - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DesperatePrayer_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 17 && Aimsharp.CanCast(PowerWord_Shield_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Power Word: Shield - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(PowerWord_Shield_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 21562 && Aimsharp.CanCast(PowerWord_Fortitude_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Power Word: Fortitude - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(PowerWord_Fortitude_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    if (SpellID1 == 589 && Aimsharp.CanCast(ShadowWord_Pain_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Word: Pain - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ShadowWord_Pain_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 32379 && Aimsharp.CanCast(ShadowWord_Death_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Word: Death - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ShadowWord_Death_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 73510 && Aimsharp.CanCast(MindSpike_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mind Spike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(MindSpike_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 8092 && Aimsharp.CanCast(MindBlast_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mind Blast - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(MindBlast_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 528 && Aimsharp.CanCast(DispelMagic_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Dispel Magic - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DispelMagic_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Shadow Spells - Player GCD
                    if (SpellID1 == 205385 && Aimsharp.CanCast(ShadowCrash_SpellName(Language), "player", false, true))
                    {
                        switch (ShadowCrashCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast(ShadowCrash_SpellName(Language));
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("ShadowCrashC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                                }
                                Aimsharp.Cast("ShadowCrashP");
                                return true;
                        }
                    }

                    if (SpellID1 == 15286 && Aimsharp.CanCast(VampiricEmbrace_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vampiric Embrace - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(VampiricEmbrace_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 232698 && Aimsharp.CanCast(Shadowform_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowform - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Shadowform_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 194249 && Aimsharp.CanCast(Voidform_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Voidform - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Voidform_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 391109 && Aimsharp.CanCast(DarkAscension_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Dark Ascension - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DarkAscension_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 263346 && Aimsharp.CanCast(DarkVoid_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Dark Void - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DarkVoid_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 186263 && Aimsharp.CanCast(ShadowMend_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Mend - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ShadowMend_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 213634 && Aimsharp.CanCast(PurifyDisease_SpellName(Language), "player", false, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Purify Disease - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(PurifyDisease_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 122121 || SpellID1 == 110744) && Aimsharp.CanCast(DivineStar_SpellName(Language), "player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Divine Star - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DivineStar_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 120644 || SpellID1 == 120517) && Aimsharp.CanCast(Halo_SpellName(Language), "player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Halo - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Halo_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region Shadow Spells - Target GCD

                    if (SpellID1 == 263165 && Aimsharp.CanCast(VoidTorrent_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Void Torrent - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(VoidTorrent_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 200174 && Aimsharp.CanCast(Mindbender_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mindbender - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Mindbender_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 341374 && Aimsharp.CanCast(Damnation_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Damnation - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Damnation_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 341385 && Aimsharp.CanCast(SearingNightmare_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Searing Nightmare - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SearingNightmare_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 205448 && Aimsharp.CanCast(VoidBolt_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Void Bolt - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(VoidBolt_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 228260 && Aimsharp.CanCast(VoidEruption_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Void Eruption - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(VoidEruption_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 34914 && Aimsharp.CanCast(VampiricTouch_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Vampiric Touch - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(VampiricTouch_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 48045 && Aimsharp.CanCast(MindSear_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mind Sear - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(MindSear_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 34433 && Aimsharp.CanCast(Shadowfiend_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadowfiend - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Shadowfiend_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 15407 && Aimsharp.CanCast(MindFlay_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mind Flay - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(MindFlay_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 391403 && Aimsharp.CanCast(MindFlay_Insanity_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mind Flay: Insanity - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(MindFlay_Insanity_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 335467 && Aimsharp.CanCast(DevouringPlague_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Devouring Plague - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(DevouringPlague_SpellName(Language));
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
            bool ShadowformOOC = GetCheckBox("Shadowform Out of Combat:");
            bool FortitudeOOC = GetCheckBox("Fortitude Out of Combat:");
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
            if (SpellID1 == 341385 && Aimsharp.CanCast(SearingNightmare_SpellName(Language), "target", true, false))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Searing Nightmare - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(SearingNightmare_SpellName(Language));
                return true;
            }

            if (Aimsharp.CastingID("player") == 605 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("MindControl"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mind Control Queue", Color.Purple);
                }
                Aimsharp.Cast("MindControlOff");
                return true;
            }

            if (Aimsharp.CastingID("player") == 9484 && Aimsharp.CastingRemaining("player") > 0 && Aimsharp.CastingRemaining("player") <= 400 && Aimsharp.IsCustomCodeOn("ShackleUndead"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shackle Undead Queue", Color.Purple);
                }
                Aimsharp.Cast("ShackleUndeadOff");
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

            if (Aimsharp.IsCustomCodeOn("ShadowCrash") && Aimsharp.SpellCooldown(ShadowCrash_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("MassDispel") && Aimsharp.SpellCooldown(MassDispel_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            bool PsychicScream = Aimsharp.IsCustomCodeOn("PsychicScream");
            if (Aimsharp.SpellCooldown(PsychicScream_SpellName(Language)) - Aimsharp.GCD() > 2000 && PsychicScream)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Psychic Scream Queue", Color.Purple);
                }
                Aimsharp.Cast("PsychicScreamOff");
                return true;
            }

            if (PsychicScream && Aimsharp.CanCast(PsychicScream_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Psychic Scream - Queue", Color.Purple);
                }
                Aimsharp.Cast(PsychicScream_SpellName(Language));
                return true;
            }

            bool PsychicHorror = Aimsharp.IsCustomCodeOn("PsychicHorror");
            if (Aimsharp.SpellCooldown(PsychicHorror_SpellName(Language)) - Aimsharp.GCD() > 2000 && PsychicHorror)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Psychic Horror Queue", Color.Purple);
                }
                Aimsharp.Cast("PsychicHorrorOff");
                return true;
            }

            if (PsychicHorror && Aimsharp.CanCast(PsychicHorror_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Psychic Horror - Queue", Color.Purple);
                }
                Aimsharp.Cast("PsychicHorrorMO");
                return true;
            }

            bool MindBomb = Aimsharp.IsCustomCodeOn("MindBomb");
            if (Aimsharp.SpellCooldown(MindBomb_SpellName(Language)) - Aimsharp.GCD() > 2000 && MindBomb)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mind Bomb Queue", Color.Purple);
                }
                Aimsharp.Cast("MindBombOff");
                return true;
            }

            if (MindBomb && Aimsharp.CanCast(MindBomb_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mind Bomb - Queue", Color.Purple);
                }
                Aimsharp.Cast("MindBombMO");
                return true;
            }

            bool ShackleUndead = Aimsharp.IsCustomCodeOn("ShackleUndead");
            if (Aimsharp.SpellCooldown(ShackleUndead_SpellName(Language)) - Aimsharp.GCD() > 2000 && ShackleUndead)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shackle Undead Queue", Color.Purple);
                }
                Aimsharp.Cast("ShackleUndeadOff");
                return true;
            }

            if (ShackleUndead && Aimsharp.CanCast(ShackleUndead_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Shackle Undead - Queue", Color.Purple);
                }
                Aimsharp.Cast("ShackleUndeadMO");
                return true;
            }

            bool PowerInfusion = Aimsharp.IsCustomCodeOn("PowerInfusion");
            if (Aimsharp.SpellCooldown(PowerInfusion_SpellName(Language)) - Aimsharp.GCD() > 2000 && PowerInfusion)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Power Infusion Queue", Color.Purple);
                }
                Aimsharp.Cast("PowerInfusionOff");
                return true;
            }

            if (PowerInfusion && Aimsharp.CanCast(PowerInfusion_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Power Infusion - Queue", Color.Purple);
                }
                Aimsharp.Cast("PowerInfusionMO");
                return true;
            }

            bool LeapofFaith = Aimsharp.IsCustomCodeOn("LeapofFaith");
            if (Aimsharp.SpellCooldown(LeapOfFaith_SpellName(Language)) - Aimsharp.GCD() > 2000 && LeapofFaith)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Leap of Faith Queue", Color.Purple);
                }
                Aimsharp.Cast("LeapofFaithOff");
                return true;
            }

            if (LeapofFaith && Aimsharp.CanCast(LeapOfFaith_SpellName(Language), "mouseover", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Leap of Faith - Queue", Color.Purple);
                }
                Aimsharp.Cast("LeapofFaithMO");
                return true;
            }

            bool MindControl = Aimsharp.IsCustomCodeOn("MindControl");
            if ((Aimsharp.SpellCooldown(MindControl_SpellName(Language)) - Aimsharp.GCD() > 2000 || Moving) && MindControl)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mind Control Queue", Color.Purple);
                }
                Aimsharp.Cast("MindControlOff");
                return true;
            }

            if (MindControl && Aimsharp.CanCast(MindControl_SpellName(Language), "mouseover", true, true) && !Moving)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Mind Control - Queue", Color.Purple);
                }
                Aimsharp.Cast("MindControlMO");
                return true;
            }

            string MassDispelCast = GetDropDown("Mass Dispel Cast:");
            bool MassDispel = Aimsharp.IsCustomCodeOn("MassDispel");
            if (Aimsharp.SpellCooldown(MassDispel_SpellName(Language)) - Aimsharp.GCD() > 2000 && MassDispel)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Mass Dispel Queue", Color.Purple);
                }
                Aimsharp.Cast("MassDispelOff");
                return true;
            }

            if (MassDispel && Aimsharp.CanCast(MassDispel_SpellName(Language), "player", false, true))
            {
                switch (MassDispelCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mass Dispel - " + MassDispelCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(MassDispel_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mass Dispel - " + MassDispelCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MassDispelC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Mass Dispel - " + MassDispelCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("MassDispelP");
                        return true;
                }
            }

            string ShadowCrashCast = GetDropDown("Shadow Crash Cast:");
            bool ShadowCrash = Aimsharp.IsCustomCodeOn("ShadowCrash");
            if (Aimsharp.SpellCooldown(ShadowCrash_SpellName(Language)) - Aimsharp.GCD() > 2000 && ShadowCrash)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Shadow Crash Queue", Color.Purple);
                }
                Aimsharp.Cast("ShadowCrashOff");
                return true;
            }

            if (ShadowCrash && Aimsharp.CanCast(ShadowCrash_SpellName(Language), "player", false, true))
            {
                switch (ShadowCrashCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(ShadowCrash_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowCrashC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Shadow Crash - " + ShadowCrashCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("ShadowCrashP");
                        return true;
                }
            }
            #endregion

            #region Out of Combat Spells
            if (SpellID1 == 21562 && Aimsharp.CanCast(PowerWord_Fortitude_SpellName(Language), "player", false, true) && FortitudeOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Power Word: Fortitude - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(PowerWord_Fortitude_SpellName(Language));
                return true;
            }

            if (SpellID1 == 232698 && Aimsharp.CanCast(Shadowform_SpellName(Language), "player", false, true) && ShadowformOOC)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Shadowform - " + SpellID1, Color.Purple);
                }
                Aimsharp.Cast(Shadowform_SpellName(Language));
                return true;
            }

            //Auto Body and Soul PWS
            bool BodyandSoul = Aimsharp.IsCustomCodeOn("BodyandSoul");
            if (BodyandSoul && Aimsharp.CanCast(PowerWord_Shield_SpellName(Language), "player", false, true) && !Aimsharp.HasDebuff("Weakened Soul", "player", true) && !Aimsharp.HasDebuff("Weakened Soul", "player", false) && Moving)
            {
                Aimsharp.Cast(PowerWord_Shield_SpellName(Language));
                return true;
            }
            #endregion

            #region Auto Combat
            //Auto Combat
            if (GetCheckBox("Auto Start Combat:") == true && Aimsharp.TargetIsEnemy() && TargetAlive() && Aimsharp.Range("target") <= 40 && TargetInCombat)
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