using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicMonkBrewmasterHekili : Rotation
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

        ///<summary>spell=115399</summary>
        private static string BlackOxBrew_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Black Ox Brew";
                case "Deutsch": return "Schwarzochsengebräu";
                case "Español": return "Brebaje del Buey Negro";
                case "Français": return "Breuvage du Buffle noir";
                case "Italiano": return "Birra dello Yak Nero";
                case "Português Brasileiro": return "Cerveja do Boi Negro";
                case "Русский": return "Отвар Черного Быка";
                case "한국어": return "흑우주";
                case "简体中文": return "玄牛酒";
                default: return "Black Ox Brew";
            }
        }

        ///<summary>spell=100784</summary>
        private static string BlackoutKick_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blackout Kick";
                case "Deutsch": return "Blackout-Tritt";
                case "Español": return "Patada oscura";
                case "Français": return "Frappe du voile noir";
                case "Italiano": return "Calcio dell'Oscuramento";
                case "Português Brasileiro": return "Chute Blecaute";
                case "Русский": return "Нокаутирующий удар";
                case "한국어": return "후려차기";
                case "简体中文": return "幻灭踢";
                default: return "Blackout Kick";
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

        ///<summary>spell=386276</summary>
        private static string BonedustBrew_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Bonedust Brew";
                case "Deutsch": return "Knochenstaubgebräu";
                case "Español": return "Brebaje de polvohueso";
                case "Français": return "Breuvage poussière-d’os";
                case "Italiano": return "Birra di Polvere d'Ossa";
                case "Português Brasileiro": return "Cerveja Pó de Osso";
                case "Русский": return "Отвар из костяной пыли";
                case "한국어": return "골분주";
                case "简体中文": return "骨尘酒";
                default: return "Bonedust Brew";
            }
        }

        ///<summary>spell=115181</summary>
        private static string BreathOfFire_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Breath of Fire";
                case "Deutsch": return "Feuerodem";
                case "Español": return "Aliento de Fuego";
                case "Français": return "Souffle de feu";
                case "Italiano": return "Soffio di Fuoco";
                case "Português Brasileiro": return "Bafo de Onça";
                case "Русский": return "Пламенное дыхание";
                case "한국어": return "불의 숨결";
                case "简体中文": return "火焰之息";
                default: return "Breath of Fire";
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

        ///<summary>spell=322507</summary>
        private static string CelestialBrew_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Celestial Brew";
                case "Deutsch": return "Himmlisches Gebräu";
                case "Español": return "Brebaje celestial";
                case "Français": return "Breuvage céleste";
                case "Italiano": return "Birra Celestiale";
                case "Português Brasileiro": return "Cerveja Celestial";
                case "Русский": return "Божественный отвар";
                case "한국어": return "천신주";
                case "简体中文": return "天神酒";
                default: return "Celestial Brew";
            }
        }

        ///<summary>spell=123986</summary>
        private static string ChiBurst_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Chi Burst";
                case "Deutsch": return "Chistoß";
                case "Español": return "Ráfaga de chi";
                case "Français": return "Explosion de chi";
                case "Italiano": return "Scarica del Chi";
                case "Português Brasileiro": return "Estouro de Chi";
                case "Русский": return "Выброс ци";
                case "한국어": return "기의 파동";
                case "简体中文": return "真气爆裂";
                default: return "Chi Burst";
            }
        }

        ///<summary>spell=115098</summary>
        private static string ChiWave_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Chi Wave";
                case "Deutsch": return "Chiwelle";
                case "Español": return "Ola de chi";
                case "Français": return "Onde de chi";
                case "Italiano": return "Ondata del Chi";
                case "Português Brasileiro": return "Onda de Chi";
                case "Русский": return "Волна ци";
                case "한국어": return "기의 물결";
                case "简体中文": return "真气波";
                default: return "Chi Wave";
            }
        }

        ///<summary>spell=324312</summary>
        private static string Clash_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Clash";
                case "Deutsch": return "Aufprall";
                case "Español": return "Colisión";
                case "Français": return "Fracas";
                case "Italiano": return "Scontro";
                case "Português Brasileiro": return "Colisão";
                case "Русский": return "Столкновение";
                case "한국어": return "충돌";
                case "简体中文": return "对冲";
                default: return "Clash";
            }
        }

        ///<summary>spell=117952</summary>
        private static string CracklingJadeLightning_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Crackling Jade Lightning";
                case "Deutsch": return "Knisternder Jadeblitz";
                case "Español": return "Relámpago crepitante de jade";
                case "Français": return "Éclair de jade crépitant";
                case "Italiano": return "Fulmine di Giada Crepitante";
                case "Português Brasileiro": return "Raio Jade Crepitante";
                case "Русский": return "Сверкающая нефритовая молния";
                case "한국어": return "짜릿한 비취 번개";
                case "简体中文": return "碎玉闪电";
                default: return "Crackling Jade Lightning";
            }
        }

        ///<summary>spell=122278</summary>
        private static string DampenHarm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dampen Harm";
                case "Deutsch": return "Schaden dämpfen";
                case "Español": return "Mitigar daño";
                case "Français": return "Atténuation du mal";
                case "Italiano": return "Diminuzione del Dolore";
                case "Português Brasileiro": return "Atenuar Ferimento";
                case "Русский": return "Смягчение удара";
                case "한국어": return "해악 감퇴";
                case "简体中文": return "躯不坏";
                default: return "Dampen Harm";
            }
        }

        ///<summary>spell=218164</summary>
        private static string Detox_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Detox";
                case "Deutsch": return "Entgiftung";
                case "Español": return "Depuración";
                case "Français": return "Détoxification";
                case "Italiano": return "Disintossicazione";
                case "Português Brasileiro": return "Desintoxicação";
                case "Русский": return "Детоксикация";
                case "한국어": return "해독";
                case "简体中文": return "清创生血";
                default: return "Detox";
            }
        }

        ///<summary>spell=122783</summary>
        private static string DiffuseMagic_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Diffuse Magic";
                case "Deutsch": return "Magiediffusion";
                case "Español": return "Difuminar magia";
                case "Français": return "Diffusion de la magie";
                case "Italiano": return "Dispersione della Magia";
                case "Português Brasileiro": return "Magia Difusa";
                case "Русский": return "Распыление магии";
                case "한국어": return "마법 해소";
                case "简体中文": return "散魔功";
                default: return "Diffuse Magic";
            }
        }

        ///<summary>spell=115288</summary>
        private static string EnergizingElixir_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Energizing Elixir";
                case "Deutsch": return "Energetisierendes Elixier";
                case "Español": return "Elixir tonificante";
                case "Français": return "Élixir énergisant";
                case "Italiano": return "Elisir Energizzante";
                case "Português Brasileiro": return "Elixir Energizante";
                case "Русский": return "Будоражащий отвар";
                case "한국어": return "기력 회복의 비약";
                case "简体中文": return "豪能酒";
                default: return "Energizing Elixir";
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

        ///<summary>spell=322101</summary>
        private static string ExpelHarm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Expel Harm";
                case "Deutsch": return "Schadensumleitung";
                case "Español": return "Expulsar daño";
                case "Français": return "Extraction du mal";
                case "Italiano": return "Espulsione del Dolore";
                case "Português Brasileiro": return "Expelir o Mal";
                case "Русский": return "Устранение вреда";
                case "한국어": return "해악 축출";
                case "简体中文": return "移花接木";
                default: return "Expel Harm";
            }
        }

        ///<summary>spell=325153</summary>
        private static string ExplodingKeg_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Exploding Keg";
                case "Deutsch": return "Explodierendes Fässchen";
                case "Español": return "Barril detonante";
                case "Français": return "Tonneau explosif";
                case "Italiano": return "Barile d'Esplosivo";
                case "Português Brasileiro": return "Barril Explosivo";
                case "Русский": return "Взрывной бочонок";
                case "한국어": return "폭발하는 맥주통";
                case "简体中文": return "爆炸酒桶";
                default: return "Exploding Keg";
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

        ///<summary>spell=388917</summary>
        private static string FortifyingBrew_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fortifying Brew";
                case "Deutsch": return "Stärkendes Gebräu";
                case "Español": return "Brebaje reconstituyente";
                case "Français": return "Boisson fortifiante";
                case "Italiano": return "Birra Fortificante";
                case "Português Brasileiro": return "Cerveja Fortificante";
                case "Русский": return "Укрепляющий отвар";
                case "한국어": return "강화주";
                case "简体中文": return "壮胆酒";
                default: return "Fortifying Brew";
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

        ///<summary>spell=122281</summary>
        private static string HealingElixir_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Healing Elixir";
                case "Deutsch": return "Heilendes Elixier";
                case "Español": return "Elixir de sanación";
                case "Français": return "Élixir de soins";
                case "Italiano": return "Elisir Curativo";
                case "Português Brasileiro": return "Elixir Curativo";
                case "Русский": return "Целебный эликсир";
                case "한국어": return "치유의 비약";
                case "简体中文": return "金创药";
                default: return "Healing Elixir";
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

        ///<summary>spell=132578</summary>
        private static string InvokeNiuzaoTheBlackOx_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Invoke Niuzao, the Black Ox";
                case "Deutsch": return "Niuzao den Schwarzen Ochsen beschwören";
                case "Español": return "Invocar a Niuzao, el Buey Negro";
                case "Français": return "Invocation de Niuzao, le Buffle noir";
                case "Italiano": return "Invocazione: Niuzao, lo Yak Nero";
                case "Português Brasileiro": return "Evocar Niuzao, o Boi Negro";
                case "Русский": return "Призыв Нюцзао, Черного Быка";
                case "한국어": return "흑우 니우짜오의 원령";
                case "简体中文": return "玄牛下凡";
                default: return "Invoke Niuzao, the Black Ox";
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

        ///<summary>spell=121253</summary>
        private static string KegSmash_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Keg Smash";
                case "Deutsch": return "Fasshieb";
                case "Español": return "Embate con barril";
                case "Français": return "Fracasse-tonneau";
                case "Italiano": return "Lancio del Barile";
                case "Português Brasileiro": return "Pancada de Barril";
                case "Русский": return "Удар бочонком";
                case "한국어": return "맥주통 휘두르기";
                case "简体中文": return "醉酿投";
                default: return "Keg Smash";
            }
        }

        ///<summary>spell=1766</summary>
        private static string Kick_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Kick";
                case "Deutsch": return "Tritt";
                case "Español": return "Patada";
                case "Français": return "Coup de pied";
                case "Italiano": return "Calcio";
                case "Português Brasileiro": return "Chute";
                case "Русский": return "Пинок";
                case "한국어": return "발차기";
                case "简体中文": return "脚踢";
                default: return "Kick";
            }
        }

        ///<summary>spell=119381</summary>
        private static string LegSweep_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Leg Sweep";
                case "Deutsch": return "Fußfeger";
                case "Español": return "Barrido de pierna";
                case "Français": return "Balayement de jambe";
                case "Italiano": return "Calcio a Spazzata";
                case "Português Brasileiro": return "Rasteira";
                case "Русский": return "Круговой удар ногой";
                case "한국어": return "팽이 차기";
                case "简体中文": return "扫堂腿";
                default: return "Leg Sweep";
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

        ///<summary>spell=115078</summary>
        private static string Paralysis_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Paralysis";
                case "Deutsch": return "Paralyse";
                case "Español": return "Parálisis";
                case "Français": return "Paralysie";
                case "Italiano": return "Paralisi";
                case "Português Brasileiro": return "Paralisia";
                case "Русский": return "Паралич";
                case "한국어": return "마비";
                case "简体中文": return "分筋错骨";
                default: return "Paralysis";
            }
        }

        ///<summary>spell=115546</summary>
        private static string Provoke_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Provoke";
                case "Deutsch": return "Provokation";
                case "Español": return "Burla";
                case "Français": return "Persiflage";
                case "Italiano": return "Istigazione";
                case "Português Brasileiro": return "Provocar";
                case "Русский": return "Вызов";
                case "한국어": return "조롱";
                case "简体中文": return "嚎镇八方";
                default: return "Provoke";
            }
        }

        ///<summary>spell=119582</summary>
        private static string PurifyingBrew_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Purifying Brew";
                case "Deutsch": return "Reinigendes Gebräu";
                case "Español": return "Brebaje purificador";
                case "Français": return "Infusion purificatrice";
                case "Italiano": return "Birra Purificatrice";
                case "Português Brasileiro": return "Cerveja Purificante";
                case "Русский": return "Очищающий отвар";
                case "한국어": return "정화주";
                case "简体中文": return "活血酒";
                default: return "Purifying Brew";
            }
        }

        ///<summary>spell=116844</summary>
        private static string RingOfPeace_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Ring of Peace";
                case "Deutsch": return "Ring des Friedens";
                case "Español": return "Anillo de paz";
                case "Français": return "Anneau de paix";
                case "Italiano": return "Circolo di Pace";
                case "Português Brasileiro": return "Anel da Paz";
                case "Русский": return "Круг мира";
                case "한국어": return "평화의 고리";
                case "简体中文": return "平心之环";
                default: return "Ring of Peace";
            }
        }

        ///<summary>spell=107428</summary>
        private static string RisingSunKick_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rising Sun Kick";
                case "Deutsch": return "Tritt der aufgehenden Sonne";
                case "Español": return "Patada del sol naciente";
                case "Français": return "Coup de pied du soleil levant";
                case "Italiano": return "Calcio del Sole Nascente";
                case "Português Brasileiro": return "Chute do Sol Nascente";
                case "Русский": return "Удар восходящего солнца";
                case "한국어": return "해오름차기";
                case "简体中文": return "旭日东升踢";
                default: return "Rising Sun Kick";
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

        ///<summary>spell=116847</summary>
        private static string RushingJadeWind_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Rushing Jade Wind";
                case "Deutsch": return "Rauschender Jadewind";
                case "Español": return "Viento de jade impetuoso";
                case "Français": return "Vent de jade fulgurant";
                case "Italiano": return "Tornado di Giada";
                case "Português Brasileiro": return "Vento Impetuoso de Jade";
                case "Русский": return "Порыв нефритового ветра";
                case "한국어": return "비취 돌풍";
                case "简体中文": return "碧玉疾风";
                default: return "Rushing Jade Wind";
            }
        }

        ///<summary>spell=152173</summary>
        private static string Serenity_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Serenity";
                case "Deutsch": return "Gleichmut";
                case "Español": return "Serenidad";
                case "Français": return "Sérénité";
                case "Italiano": return "Serenità";
                case "Português Brasileiro": return "Serenidade";
                case "Русский": return "Безмятежность";
                case "한국어": return "평안";
                case "简体中文": return "屏气凝神";
                default: return "Serenity";
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

        ///<summary>spell=116705</summary>
        private static string SpearHandStrike_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Spear Hand Strike";
                case "Deutsch": return "Speerhandstoß";
                case "Español": return "Golpe de mano de lanza";
                case "Français": return "Pique de main";
                case "Italiano": return "Compressione Tracheale";
                case "Português Brasileiro": return "Golpe Mão de Lança";
                case "Русский": return "Рука-копье";
                case "한국어": return "손날 찌르기";
                case "简体中文": return "切喉手";
                default: return "Spear Hand Strike";
            }
        }

        ///<summary>spell=101546</summary>
        private static string SpinningCraneKick_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Spinning Crane Kick";
                case "Deutsch": return "Wirbelnder Kranichtritt";
                case "Español": return "Patada giratoria de la grulla";
                case "Français": return "Coup tournoyant de la grue";
                case "Italiano": return "Calcio Rotante della Gru";
                case "Português Brasileiro": return "Chute Giratório da Garça";
                case "Русский": return "Танцующий журавль";
                case "한국어": return "회전 학다리차기";
                case "简体中文": return "神鹤引项踢";
                default: return "Spinning Crane Kick";
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

        ///<summary>spell=115315 </summary>
        private static string SummonBlackOxStatue_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Summon Black Ox Statue";
                case "Deutsch": return "Statue des Schwarzen Ochsen beschwören";
                case "Español": return "Invocar estatua del Buey Negro";
                case "Français": return "Invocation d’une statue du Buffle noir";
                case "Italiano": return "Evocazione: Statua dello Yak Nero";
                case "Português Brasileiro": return "Evocar Estátua do Boi Negro";
                case "Русский": return "Призыв статуи Черного Быка";
                case "한국어": return "흑우 조각상 소환";
                case "简体中文": return "召唤玄牛雕像";
                default: return "Summon Black Ox Statue";
            }
        }

        ///<summary>spell=388686</summary>
        private static string SummonWhiteTigerStatue_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Summon White Tiger Statue";
                case "Deutsch": return "Weiße Tigerstatue beschwören";
                case "Español": return "Invocar estatua del Tigre Blanco";
                case "Français": return "Invocation de statue de tigre blanc";
                case "Italiano": return "Evocazione: Statua della Tigre Bianca";
                case "Português Brasileiro": return "Evocar Estátua do Tigre Branco";
                case "Русский": return "Призыв статуи белого тигра";
                case "한국어": return "백호 조각상 소환";
                case "简体中文": return "召唤白虎雕像";
                default: return "Summon White Tiger Statue";
            }
        }

        ///<summary>spell=100780</summary>
        private static string TigerPalm_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Tiger Palm";
                case "Deutsch": return "Tigerklaue";
                case "Español": return "Palma del tigre";
                case "Français": return "Paume du tigre";
                case "Italiano": return "Palmo della Tigre";
                case "Português Brasileiro": return "Palma do Tigre";
                case "Русский": return "Лапа тигра";
                case "한국어": return "범의 장풍";
                case "简体中文": return "猛虎掌";
                default: return "Tiger Palm";
            }
        }

        ///<summary>spell=322109</summary>
        private static string TouchOfDeath_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Touch of Death";
                case "Deutsch": return "Berührung des Todes";
                case "Español": return "Toque de la muerte";
                case "Français": return "Toucher mortel";
                case "Italiano": return "Tocco della Morte";
                case "Português Brasileiro": return "Toque da Morte";
                case "Русский": return "Смертельное касание";
                case "한국어": return "절명의 손길";
                case "简体中文": return "轮回之触";
                default: return "Touch of Death";
            }
        }

        ///<summary>spell=122470</summary>
        private static string TouchOfKarma_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Touch of Karma";
                case "Deutsch": return "Karmaberührung";
                case "Español": return "Toque de karma";
                case "Français": return "Toucher du karma";
                case "Italiano": return "Tocco del Karma";
                case "Português Brasileiro": return "Toque do Karma";
                case "Русский": return "Закон кармы";
                case "한국어": return "업보의 손아귀";
                case "简体中文": return "业报之触";
                default: return "Touch of Karma";
            }
        }

        ///<summary>spell=101643</summary>
        private static string Transcendence_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Transcendence";
                case "Deutsch": return "Transzendenz";
                case "Español": return "Transcendencia";
                case "Français": return "Transcendance";
                case "Italiano": return "Trascendenza";
                case "Português Brasileiro": return "Transcendência";
                case "Русский": return "Трансцендентность";
                case "한국어": return "해탈";
                case "简体中文": return "魂体双分";
                default: return "Transcendence";
            }
        }

        ///<summary>spell=119996</summary>
        private static string Transcendence_Transfer_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Transcendence: Transfer";
                case "Deutsch": return "Transzendenz: Transfer";
                case "Español": return "Transcendencia: Transferencia";
                case "Français": return "Transcendance : Transfert";
                case "Italiano": return "Trascendenza: Trasferimento";
                case "Português Brasileiro": return "Transcendência: Transferência";
                case "Русский": return "Трансцендентность: перенос";
                case "한국어": return "해탈: 전환";
                case "简体中文": return "魂体双分：转移";
                default: return "Transcendence: Transfer";
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

        ///<summary>spell=310454</summary>
        private static string WeaponsOfOrder_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Weapons of Order";
                case "Deutsch": return "Waffen der Ordnung";
                case "Español": return "Armas de orden";
                case "Français": return "Armes de l’Ordre";
                case "Italiano": return "Armi dell'Ordine";
                case "Português Brasileiro": return "Armas de Ordem";
                case "Русский": return "Оружие ордена";
                case "한국어": return "질서의 무기";
                case "简体中文": return "精序兵戈";
                default: return "Weapons of Order";
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

        ///<summary>spell=115176</summary>
        private static string ZenMeditation_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Zen Meditation";
                case "Deutsch": return "Zenmeditation";
                case "Español": return "Meditación zen";
                case "Français": return "Méditation zen";
                case "Italiano": return "Meditazione Zen";
                case "Português Brasileiro": return "Meditação Zen";
                case "Русский": return "Дзен-медитация";
                case "한국어": return "명상";
                case "简体中文": return "禅悟冥想";
                default: return "Zen Meditation";
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
        private List<string> m_IngameCommandsList = new List<string> { "NoInterrupts", "NoCycle","NoDetox", "RingofPeace", Paralysis_SpellName(Language), "LegSweep", Transcendence_SpellName(Language), "Transfer", "BonedustBrew", "WhiteTigerStatue", "BlackOxStatue" };
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
                if (Aimsharp.CustomFunction("HekiliID1") == HekiliID && (Aimsharp.CanCast(SpellName, target) || Aimsharp.SpellCooldown(SpellName) - Aimsharp.GCD() <= 0 || (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow")) || Aimsharp.GCD() == 0))
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
                if (Aimsharp.CustomFunction("HekiliID1") == HekiliID && (Aimsharp.CanCast(SpellName, target) || Aimsharp.SpellCooldown(SpellName) - Aimsharp.GCD() <= 0 || (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow")) || Aimsharp.GCD() == 0))
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
            Macros.Add("DX_FOC", "/cast [@focus] " + Detox_SpellName(Language));

            //Ring of Peace @ Cursor
            Macros.Add("RingofPeaceC", "/cast [@cursor] " + RingOfPeace_SpellName(Language));
            Macros.Add("RingofPeaceP", "/cast [@player] " + RingOfPeace_SpellName(Language));
            Macros.Add("RingofPeaceOff", "/" + FiveLetters + " RingofPeace");

            //Bonedust Brew @ Cursor
            Macros.Add("BonedustBrewC", "/cast [@cursor] " + BonedustBrew_SpellName(Language));
            Macros.Add("BonedustBrewP", "/cast [@player] " + BonedustBrew_SpellName(Language));
            Macros.Add("BonedustBrewOff", "/" + FiveLetters + " BonedustBrew");

            //Summon White Tiger Statue @ Cursor
            Macros.Add("WhiteTigerStatueC", "/cast [@cursor] " + SummonWhiteTigerStatue_SpellName(Language));
            Macros.Add("WhiteTigerStatueP", "/cast [@player] " + SummonWhiteTigerStatue_SpellName(Language));
            Macros.Add("WhiteTigerStatueOff", "/" + FiveLetters + " WhiteTigerStatue");

            //Summon Black Ox Statue @ Cursor
            Macros.Add("BlackOxStatueC", "/cast [@cursor] " + SummonBlackOxStatue_SpellName(Language));
            Macros.Add("BlackOxStatueP", "/cast [@player] " + SummonBlackOxStatue_SpellName(Language));
            Macros.Add("BlackOxStatueOff", "/" + FiveLetters + " BlackOxStatue");

            //Paralysis
            Macros.Add("ParalysisOff", "/" + FiveLetters + " Paralysis");
            Macros.Add("ParalysisMO", "/cast [@mouseover] " + Paralysis_SpellName(Language));

            //Leg Sweep
            Macros.Add("LegSweepOff", "/" + FiveLetters + " LegSweep");

            //Transcendence
            Macros.Add("TranscendenceOff", "/" + FiveLetters + " Transcendence");

            //Transcendence: Transfer
            Macros.Add("TransferOff", "/" + FiveLetters + " Transfer");
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
                                "if type ~= nil and type == \"Disease\" or type == \"Poison\" then y = y +1; end end " +
                                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party1\",i,\"RAID\"); " +
                                "if type ~= nil and type == \"Disease\" or type == \"Poison\" then y = y +2; end end " +
                                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party2\",i,\"RAID\"); " +
                                "if type ~= nil and type == \"Disease\" or type == \"Poison\" then y = y +4; end end " +
                                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party3\",i,\"RAID\"); " +
                                "if type ~= nil and type == \"Disease\" or type == \"Poison\" then y = y +8; end end " +
                                "for i=1,25 do local name,_,_,type=UnitDebuff(\"party4\",i,\"RAID\"); " +
                                "if type ~= nil and type == \"Disease\" or type == \"Poison\" then y = y +16; end end " +
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
            Settings.Add(new Setting("Auto Dampen Harm @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Diffuse Magic @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Fortifying Brew @ HP%", 0, 100, 30));
            Settings.Add(new Setting("Ring of Peace Cast:", m_CastingList, "Cursor"));
            Settings.Add(new Setting("Exploding Keg Cast:", m_CastingList, "Cursor"));
            Settings.Add(new Setting("Bonedust Brew Cast:", m_CastingList, "Cursor"));
            Settings.Add(new Setting("Summon White Tiger Statue Cast:", m_CastingList, "Cursor"));
            Settings.Add(new Setting("Summon Black Ox Statue Cast:", m_CastingList, "Cursor"));
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

            Aimsharp.PrintMessage("Epic PVE - Monk Brewmaster", Color.White);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything in every tab there, especially Pause !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/monk/brewmaster/overview-pve-tank", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.White);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoDetox - Disables Detox", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Paralysis - Casts Paralysis @ Mouseover on the next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BonedustBrew - Casts Bonedust Brew @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " RingofPeace - Casts Ring of Peace @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " LegSweep - Casts Leg Sweep @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Transcendence - Casts Transcendence @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Transfer - Casts Transfer @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " WhiteTigerStatue - Casts White Tiger Statue @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BlackOxStatue - Casts Black Ox Statue @ next GCD", Color.Yellow);
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
            m_BuffsList = new List<string> { };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language), UsableItem};
            m_SpellBook_General = new List<string> {
                RingOfPeace_SpellName(Language),
                BonedustBrew_SpellName(Language),
                SummonWhiteTigerStatue_SpellName(Language),
                SummonBlackOxStatue_SpellName(Language),
                SpearHandStrike_SpellName(Language),

                DampenHarm_SpellName(Language),
                DiffuseMagic_SpellName(Language),
                FortifyingBrew_SpellName(Language),
                Detox_SpellName(Language),

                Transcendence_SpellName(Language),
                Transcendence_Transfer_SpellName(Language),
                Paralysis_SpellName(Language),
                LegSweep_SpellName(Language),
                TouchOfKarma_SpellName(Language),
                ZenMeditation_SpellName(Language),
                PurifyingBrew_SpellName(Language),
                Serenity_SpellName(Language),

                ExplodingKeg_SpellName(Language),
                CracklingJadeLightning_SpellName(Language),
                ExpelHarm_SpellName(Language),
                Provoke_SpellName(Language),
                RisingSunKick_SpellName(Language),
                TigerPalm_SpellName(Language),
                TouchOfDeath_SpellName(Language),
                ChiBurst_SpellName(Language),
                ChiWave_SpellName(Language),
                RushingJadeWind_SpellName(Language),

                BlackoutKick_SpellName(Language),
                BreathOfFire_SpellName(Language),
                Clash_SpellName(Language),
                InvokeNiuzaoTheBlackOx_SpellName(Language),
                KegSmash_SpellName(Language),
                SpinningCraneKick_SpellName(Language),
                WeaponsOfOrder_SpellName(Language),

                CelestialBrew_SpellName(Language),
                FortifyingBrew_SpellName(Language),
                HealingElixir_SpellName(Language),
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
            bool TargetInCombat = Aimsharp.InCombat("target") || SpecialUnitList.Contains(Aimsharp.UnitID("target")) || !InstanceIDList.Contains(Aimsharp.GetMapID());

            int DiseasePoisonCheck = Aimsharp.CustomFunction("DiseasePoisonCheck");

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

            if (Aimsharp.IsCustomCodeOn("RingofPeace") && Aimsharp.SpellCooldown(RingOfPeace_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("BonedustBrew") && Aimsharp.SpellCooldown(BonedustBrew_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("WhiteTigerStatue") && Aimsharp.SpellCooldown(SummonWhiteTigerStatue_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            if (Aimsharp.IsCustomCodeOn("BlackOxStatue") && Aimsharp.SpellCooldown(SummonBlackOxStatue_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
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
                if (Aimsharp.CanCast(SpearHandStrike_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && !IsChanneling && CastingRemaining < KickValueRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Casting ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(SpearHandStrike_SpellName(Language), true);
                        return true;
                    }
                }

                if (Aimsharp.CanCast(SpearHandStrike_SpellName(Language), "target", true, true))
                {
                    if (IsInterruptable && IsChanneling && CastingElapsed > KickChannelsAfterRandom)
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Target Channeling ID: " + Aimsharp.CastingID("target") + ", Interrupting", Color.Purple);
                        }
                        Aimsharp.Cast(SpearHandStrike_SpellName(Language), true);
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

            //Auto Dampen Harm
            if (PlayerHP <= GetSlider("Auto Dampen Harm @ HP%") && Aimsharp.CanCast(DampenHarm_SpellName(Language), "player", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Dampen Harm - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Dampen Harm @ HP%"), Color.Purple);
                }
                Aimsharp.Cast(DampenHarm_SpellName(Language));
                return true;
            }

            //Auto Diffuse Magic
            if (PlayerHP <= GetSlider("Auto Diffuse Magic @ HP%") && Aimsharp.CanCast(DiffuseMagic_SpellName(Language), "player", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Diffuse Magic - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Diffuse Magic @ HP%"), Color.Purple);
                }
                Aimsharp.Cast(DiffuseMagic_SpellName(Language));
                return true;
            }

            //Auto Fortifying Brew
            if (PlayerHP <= GetSlider("Auto Fortifying Brew @ HP%") && Aimsharp.CanCast(FortifyingBrew_SpellName(Language), "player", true, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Fortifying Brew - Player HP% " + PlayerHP + " due to setting being on HP% " + GetSlider("Auto Fortifying Brew @ HP%"), Color.Purple);
                }
                Aimsharp.Cast(FortifyingBrew_SpellName(Language));
                return true;
            }
            #endregion

            #region Detox
            bool NoDetox = Aimsharp.IsCustomCodeOn("NoDetox");
            if (!NoDetox && DiseasePoisonCheck > 0 && Aimsharp.GroupSize() <= 5 && Aimsharp.LastCast() != Detox_SpellName(Language))
            {
                PartyDict.Clear();
                PartyDict.Add("player", Aimsharp.Health("player"));

                var partysize = Aimsharp.GroupSize();
                for (int i = 1; i < partysize; i++)
                {
                    var partyunit = ("party" + i);
                    if (Aimsharp.Health(partyunit) > 0 && Aimsharp.SpellInRange(Detox_SpellName(Language),partyunit))
                    {
                        PartyDict.Add(partyunit, Aimsharp.Health(partyunit));
                    }
                }

                int states = Aimsharp.CustomFunction("DiseasePoisonCheck");
                CleansePlayers target;

                int KickTimer = GetRandomNumber(200,800);

                foreach (var unit in PartyDict.OrderBy(unit => unit.Value))
                {
                    Enum.TryParse(unit.Key, out target);
                    if (Aimsharp.CanCast(Detox_SpellName(Language),unit.Key) && (unit.Key == "player" || Aimsharp.SpellInRange(Detox_SpellName(Language),unit.Key)) && isUnitCleansable(target, states))
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
                                Aimsharp.Cast("DX_FOC");
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Detox @ " + unit.Key + " - " + unit.Value, Color.Purple);
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
            string RingofPeaceCast = GetDropDown("Ring of Peace Cast:");
            bool RingofPeace = Aimsharp.IsCustomCodeOn("RingofPeace");
            if (Aimsharp.SpellCooldown(RingOfPeace_SpellName(Language)) - Aimsharp.GCD() > 2000 && RingofPeace)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Ring of Peace Queue", Color.Purple);
                }
                Aimsharp.Cast("RingofPeaceOff");
                return true;
            }

            if (RingofPeace && Aimsharp.CanCast(RingOfPeace_SpellName(Language),"player"))
            {
                switch (RingofPeaceCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Peace - " + RingofPeaceCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(RingOfPeace_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Peace - " + RingofPeaceCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofPeaceC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Peace - " + RingofPeaceCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofPeaceP");
                        return true;
                }
            }

            string BonedustBrewCast = GetDropDown("Bonedust Brew Cast:");
            bool BonedustBrew = Aimsharp.IsCustomCodeOn("BonedustBrew");
            if (Aimsharp.SpellCooldown(BonedustBrew_SpellName(Language)) - Aimsharp.GCD() > 2000 && BonedustBrew)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Bonedust Brew Queue", Color.Purple);
                }
                Aimsharp.Cast("BonedustBrewOff");
                return true;
            }

            if (BonedustBrew && Aimsharp.CanCast(BonedustBrew_SpellName(Language),"player") && (BonedustBrewCast == "Player"  || BonedustBrewCast != "Player"))
            {
                switch (BonedustBrewCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(BonedustBrew_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("BonedustBrewC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("BonedustBrewP");
                        return true;
                }
            }

            string WhiteTigerStatueCast = GetDropDown("Summon White Tiger Statue Cast:");
            bool WhiteTigerStatue = Aimsharp.IsCustomCodeOn("WhiteTigerStatue");
            if (Aimsharp.SpellCooldown(SummonWhiteTigerStatue_SpellName(Language)) - Aimsharp.GCD() > 2000 && WhiteTigerStatue)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Summon White Tiger Statue Queue", Color.Purple);
                }
                Aimsharp.Cast("WhiteTigerStatueOff");
                return true;
            }

            if (WhiteTigerStatue && Aimsharp.CanCast(SummonWhiteTigerStatue_SpellName(Language),"player") && (WhiteTigerStatueCast == "Player" || WhiteTigerStatueCast != "Player"))
            {
                switch (WhiteTigerStatueCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon White Tiger Statue - " + WhiteTigerStatueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SummonWhiteTigerStatue_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon White Tiger Statue - " + WhiteTigerStatueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WhiteTigerStatueC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon White Tiger Statue - " + WhiteTigerStatueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WhiteTigerStatueP");
                        return true;
                }
            }

            string BlackOxStatueCast = GetDropDown("Summon Black Ox Statue Cast:");
            bool BlackOxStatue = Aimsharp.IsCustomCodeOn("BlackOxStatue");
            if (Aimsharp.SpellCooldown(SummonBlackOxStatue_SpellName(Language)) - Aimsharp.GCD() > 2000 && BlackOxStatue)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Summon Black Ox Statue Queue", Color.Purple);
                }
                Aimsharp.Cast("BlackOxStatueOff");
                return true;
            }
            if (BlackOxStatue && Aimsharp.CanCast(SummonBlackOxStatue_SpellName(Language),"player") && (BlackOxStatueCast == "Player" || BlackOxStatueCast != "Player"))
            {
                switch (BlackOxStatueCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Black Ox Statue - " + BlackOxStatueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SummonBlackOxStatue_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Black Ox Statue - " + BlackOxStatueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("BlackOxStatueC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Black Ox Statue - " + BlackOxStatueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("BlackOxStatueP");
                        return true;
                }
            }

            bool Transcendence = Aimsharp.IsCustomCodeOn(Transcendence_SpellName(Language));
            //Queue Transcendence
            if (Aimsharp.SpellCooldown(Transcendence_SpellName(Language)) - Aimsharp.GCD() > 2000 && Transcendence)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Transcendence queue toggle", Color.Purple);
                }
                Aimsharp.Cast("TranscendenceOff");
                return true;
            }

            if (Transcendence && Aimsharp.CanCast(Transcendence_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Transcendence through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Transcendence_SpellName(Language));
                return true;
            }

            bool Transfer = Aimsharp.IsCustomCodeOn("Transfer");
            //Queue Transfer
            if (Aimsharp.SpellCooldown(Transcendence_Transfer_SpellName(Language)) - Aimsharp.GCD() > 2000 && Transfer)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Transfer queue toggle", Color.Purple);
                }
                Aimsharp.Cast("TransferOff");
                return true;
            }

            if (Transfer && Aimsharp.CanCast(Transcendence_Transfer_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Transfer through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Transcendence_Transfer_SpellName(Language));
                return true;
            }

            bool Paralysis = Aimsharp.IsCustomCodeOn(Paralysis_SpellName(Language));
            //Queue Paralysis
            if (Paralysis && Aimsharp.SpellCooldown(Paralysis_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Paralysis queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ParalysisOff");
                return true;
            }

            if (Paralysis && Aimsharp.CanCast(Paralysis_SpellName(Language),"target"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Paralysis through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ParalysisMO");
                return true;
            }

            bool LegSweep = Aimsharp.IsCustomCodeOn("LegSweep");
            //Queue Leg Sweep
            if (LegSweep && Aimsharp.SpellCooldown(LegSweep_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Leg Sweep queue toggle", Color.Purple);
                }
                Aimsharp.Cast("LegSweepOff");
                return true;
            }

            if (LegSweep && Aimsharp.CanCast(LegSweep_SpellName(Language),"player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Leg Sweep through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(LegSweep_SpellName(Language));
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
                    //Spear Hand Strike
                    if (SpellID1 == 96231 && Aimsharp.CanCast(SpearHandStrike_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(SpearHandStrike_SpellName(Language), true);
                        return true;
                    }

                    //Diffuse Magic
                    if (SpellID1 == 122783 && Aimsharp.CanCast(DiffuseMagic_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(DiffuseMagic_SpellName(Language), true);
                        return true;
                    }

                    //Touch of Karma
                    if (SpellID1 == 122470 && Aimsharp.CanCast(TouchOfKarma_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(TouchOfKarma_SpellName(Language), true);
                        return true;
                    }

                    //Zen Meditation
                    if (SpellID1 == 115176 && Aimsharp.CanCast(ZenMeditation_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(ZenMeditation_SpellName(Language), true);
                        return true;
                    }

                    //Purifying Brew
                    if (SpellID1 == 119582 && Aimsharp.CanCast(PurifyingBrew_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(PurifyingBrew_SpellName(Language), true);
                        return true;
                    }

                    //Serenity
                    if (SpellID1 == 152173 && Aimsharp.CanCast(Serenity_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(Serenity_SpellName(Language), true);
                        return true;
                    }

                    //Dampen Harm
                    if (SpellID1 == 122278 && Aimsharp.CanCast(DampenHarm_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(DampenHarm_SpellName(Language), true);
                        return true;
                    }

                    //Black Ox Brew
                    if (SpellID1 == 115399 && Aimsharp.CanCast(BlackOxBrew_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(BlackOxBrew_SpellName(Language), true);
                        return true;
                    }

                    //Energizing Elixir
                    if (SpellID1 == 115288 && Aimsharp.CanCast(EnergizingElixir_SpellName(Language), "player", false, true))
                    {
                        Aimsharp.Cast(EnergizingElixir_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region Cursor Spells
                    //Bonedust Brew
                    if (SpellID1 == 386276 && Aimsharp.CanCast(BonedustBrew_SpellName(Language), "player", false, true))
                    {
                        switch (BonedustBrewCast)
                        {
                            case "Manual":
                                return SpellCast(386276, BonedustBrew_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(386276, BonedustBrew_SpellName(Language), "player", "BonedustBrewP");
                            case "Cursor":
                                return SpellCast(386276, BonedustBrew_SpellName(Language), "player", "BonedustBrewC");
                        }
                    }
                    //Exploding Keg
                    string ExplodingKegCast = GetDropDown("Exploding Keg Cast:");
                    if (SpellID1 == 325153 && Aimsharp.CanCast(ExplodingKeg_SpellName(Language), "player", false, true))
                    {
                        switch (ExplodingKegCast)
                        {
                            case "Manual":
                                return SpellCast(325153, ExplodingKeg_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(325153, ExplodingKeg_SpellName(Language), "player", "ExplodingKegP");
                            case "Cursor":
                                return SpellCast(325153, ExplodingKeg_SpellName(Language), "player", "ExplodingKegC");
                        }
                    }
                    //Summon White Tiger Statue
                    if (SpellID1 == 388686 && Aimsharp.CanCast(SummonWhiteTigerStatue_SpellName(Language), "player", false, true))
                    {
                        switch (WhiteTigerStatueCast)
                        {
                            case "Manual":
                                return SpellCast(388686, SummonWhiteTigerStatue_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(388686, SummonWhiteTigerStatue_SpellName(Language), "player", "WhiteTigerStatueP");
                            case "Cursor":
                                return SpellCast(388686, SummonWhiteTigerStatue_SpellName(Language), "player", "WhiteTigerStatueC");
                        }
                    }
                    //Summon Black Ox Statue
                    if (SpellID1 == 115315 && Aimsharp.CanCast(SummonBlackOxStatue_SpellName(Language), "player", false, true))
                    {
                        switch (BlackOxStatueCast)
                        {
                            case "Manual":
                                return SpellCast(115315, SummonBlackOxStatue_SpellName(Language), "player");
                            case "Player":
                                return SpellCast(115315, SummonBlackOxStatue_SpellName(Language), "player", "SummonBlackOxStatueP");
                            case "Cursor":
                                return SpellCast(115315, SummonBlackOxStatue_SpellName(Language), "player", "SummonBlackOxStatueC");
                        }
                    }
                    #endregion

                    #region Monk General Spells
                    if (SpellCast(117952, CracklingJadeLightning_SpellName(Language), "player")) return true;
                    if (SpellCast(322101, ExpelHarm_SpellName(Language), "player")) return true;
                    if (SpellCast(119381, LegSweep_SpellName(Language), "player")) return true;
                    if (SpellCast(115546, Provoke_SpellName(Language), "target")) return true;
                    if (SpellCast(107428, RisingSunKick_SpellName(Language), "target")) return true;
                    if (SpellCast(100780, TigerPalm_SpellName(Language), "target")) return true;
                    if (SpellCast(322109, TouchOfDeath_SpellName(Language), "target")) return true;
                    if (SpellCast(123986, ChiBurst_SpellName(Language), "player")) return true;
                    if (SpellCast(115098, ChiWave_SpellName(Language), "player")) return true;
                    if (SpellCast(116847, RushingJadeWind_SpellName(Language), "player")) return true;
                    #endregion

                    #region Monk Brewmaster Spells
                    if (SpellCast(205523, BlackoutKick_SpellName(Language), "target")) return true;
                    if (SpellCast(115181, BreathOfFire_SpellName(Language), "player")) return true;
                    if (SpellCast(324312, Clash_SpellName(Language), "target")) return true;
                    if (SpellCast(132578, InvokeNiuzaoTheBlackOx_SpellName(Language), "player")) return true;
                    if (SpellCast(121253, KegSmash_SpellName(Language), "target")) return true;
                    if (SpellCast(322729, SpinningCraneKick_SpellName(Language), "player")) return true;
                    if (SpellCast(387184, WeaponsOfOrder_SpellName(Language), "player")) return true;

                    if (SpellCast(322507, CelestialBrew_SpellName(Language), "player")) return true;
                    if (SpellCast(115203, FortifyingBrew_SpellName(Language), "player")) return true;
                    if (SpellCast(122281, HealingElixir_SpellName(Language), "player")) return true;
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

            if (Aimsharp.IsCustomCodeOn("RingofPeace") && Aimsharp.SpellCooldown(RingOfPeace_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("BonedustBrew") && Aimsharp.SpellCooldown(BonedustBrew_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("WhiteTigerStatue") && Aimsharp.SpellCooldown(SummonWhiteTigerStatue_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            if (Aimsharp.IsCustomCodeOn("BlackOxStatue") && Aimsharp.SpellCooldown(SummonBlackOxStatue_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            //Queues

            string RingofPeaceCast = GetDropDown("Ring of Peace Cast:");
            bool RingofPeace = Aimsharp.IsCustomCodeOn("RingofPeace");
            if (Aimsharp.SpellCooldown(RingOfPeace_SpellName(Language)) - Aimsharp.GCD() > 2000 && RingofPeace)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Ring of Peace Queue", Color.Purple);
                }
                Aimsharp.Cast("RingofPeaceOff");
                return true;
            }

            if (RingofPeace && Aimsharp.CanCast(RingOfPeace_SpellName(Language),"player"))
            {
                switch (RingofPeaceCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Peace - " + RingofPeaceCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(RingOfPeace_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Peace - " + RingofPeaceCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofPeaceC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Ring of Peace - " + RingofPeaceCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("RingofPeaceP");
                        return true;
                }
            }

            string BonedustBrewCast = GetDropDown("Bonedust Brew Cast:");
            bool BonedustBrew = Aimsharp.IsCustomCodeOn("BonedustBrew");
            if (Aimsharp.SpellCooldown(BonedustBrew_SpellName(Language)) - Aimsharp.GCD() > 2000 && BonedustBrew)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Bonedust Brew Queue", Color.Purple);
                }
                Aimsharp.Cast("BonedustBrewOff");
                return true;
            }

            if (BonedustBrew && Aimsharp.CanCast(BonedustBrew_SpellName(Language),"player") && (BonedustBrewCast == "Player"  || BonedustBrewCast != "Player"))
            {
                switch (BonedustBrewCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(BonedustBrew_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("BonedustBrewC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("BonedustBrewP");
                        return true;
                }
            }

            string WhiteTigerStatueCast = GetDropDown("Summon White Tiger Statue Cast:");
            bool WhiteTigerStatue = Aimsharp.IsCustomCodeOn("WhiteTigerStatue");
            if (Aimsharp.SpellCooldown(SummonWhiteTigerStatue_SpellName(Language)) - Aimsharp.GCD() > 2000 && WhiteTigerStatue)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Summon White Tiger Statue Queue", Color.Purple);
                }
                Aimsharp.Cast("WhiteTigerStatueOff");
                return true;
            }

            if (WhiteTigerStatue && Aimsharp.CanCast(SummonWhiteTigerStatue_SpellName(Language),"player") && (WhiteTigerStatueCast == "Player" || WhiteTigerStatueCast != "Player"))
            {
                switch (WhiteTigerStatueCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon White Tiger Statue - " + WhiteTigerStatueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SummonWhiteTigerStatue_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon White Tiger Statue - " + WhiteTigerStatueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WhiteTigerStatueC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon White Tiger Statue - " + WhiteTigerStatueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("WhiteTigerStatueP");
                        return true;
                }
            }
            string BlackOxStatueCast = GetDropDown("Summon Black Ox Statue Cast:");
            bool BlackOxStatue = Aimsharp.IsCustomCodeOn("BlackOxStatue");
            if (Aimsharp.SpellCooldown(SummonBlackOxStatue_SpellName(Language)) - Aimsharp.GCD() > 2000 && BlackOxStatue)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Summon Black Ox Statue Queue", Color.Purple);
                }
                Aimsharp.Cast("BlackOxStatueOff");
                return true;
            }
            if (BlackOxStatue && Aimsharp.CanCast(SummonBlackOxStatue_SpellName(Language),"player") && (BlackOxStatueCast == "Player" || BlackOxStatueCast != "Player"))
            {
                switch (BlackOxStatueCast)
                {
                    case "Manual":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Black Ox Statue - " + BlackOxStatueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast(SummonBlackOxStatue_SpellName(Language));
                        return true;
                    case "Cursor":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Black Ox Statue - " + BlackOxStatueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("BlackOxStatueC");
                        return true;
                    case "Player":
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Summon Black Ox Statue - " + BlackOxStatueCast + " - Queue", Color.Purple);
                        }
                        Aimsharp.Cast("BlackOxStatueP");
                        return true;
                }
            }

            bool Transcendence = Aimsharp.IsCustomCodeOn(Transcendence_SpellName(Language));
            //Queue Transcendence
            if (Aimsharp.SpellCooldown(Transcendence_SpellName(Language)) - Aimsharp.GCD() > 2000 && Transcendence)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Transcendence queue toggle", Color.Purple);
                }
                Aimsharp.Cast("TranscendenceOff");
                return true;
            }

            if (Transcendence && Aimsharp.CanCast(Transcendence_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Transcendence through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Transcendence_SpellName(Language));
                return true;
            }

            bool Transfer = Aimsharp.IsCustomCodeOn("Transfer");
            //Queue Transfer
            if (Aimsharp.SpellCooldown(Transcendence_Transfer_SpellName(Language)) - Aimsharp.GCD() > 2000 && Transfer)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Transfer queue toggle", Color.Purple);
                }
                Aimsharp.Cast("TransferOff");
                return true;
            }

            if (Transfer && Aimsharp.CanCast(Transcendence_Transfer_SpellName(Language), "player", false, true))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Transfer through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Transcendence_Transfer_SpellName(Language));
                return true;
            }

            bool Paralysis = Aimsharp.IsCustomCodeOn(Paralysis_SpellName(Language));
            //Queue Paralysis
            if (Paralysis && Aimsharp.SpellCooldown(Paralysis_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Paralysis queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ParalysisOff");
                return true;
            }

            if (Paralysis && Aimsharp.CanCast(Paralysis_SpellName(Language),"target"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Paralysis through queue toggle", Color.Purple);
                }
                Aimsharp.Cast("ParalysisMO");
                return true;
            }

            bool LegSweep = Aimsharp.IsCustomCodeOn("LegSweep");
            //Queue Leg Sweep
            if (LegSweep && Aimsharp.SpellCooldown(LegSweep_SpellName(Language)) - Aimsharp.GCD() > 2000)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Leg Sweep queue toggle", Color.Purple);
                }
                Aimsharp.Cast("LegSweepOff");
                return true;
            }

            if (LegSweep && Aimsharp.CanCast(LegSweep_SpellName(Language),"player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Leg Sweep through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(LegSweep_SpellName(Language));
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