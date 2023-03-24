using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using AimsharpWow.API;

namespace AimsharpWow.Modules
{
    public class EpicMonkWindwalkerHekili : Rotation
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

        ///<summary>spell=116768</summary>
        private static string BlackoutKicki_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blackout Kick!";
                case "Deutsch": return "Blackout-Tritt!";
                case "Español": return "¡Patada oscura!";
                case "Français": return "Frappe du voile noir !";
                case "Italiano": return "Calcio dell'Oscuramento!";
                case "Português Brasileiro": return "Chute Blecaute!";
                case "Русский": return "Нокаутирующий удар!";
                case "한국어": return "후려차기!";
                case "简体中文": return "幻灭踢！";
                default: return "Blackout Kick!";
            }
        }

        ///<summary>spell=2094</summary>
        private static string Blind_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Blind";
                case "Deutsch": return "Blenden";
                case "Español": return "Ceguera";
                case "Français": return "Cécité";
                case "Italiano": return "Accecamento";
                case "Português Brasileiro": return "Cegar";
                case "Русский": return "Ослепление";
                case "한국어": return "실명";
                case "简体中文": return "致盲";
                default: return "Blind";
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

        ///<summary>spell=115008</summary>
        private static string ChiTorpedo_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Chi Torpedo";
                case "Deutsch": return "Chitorpedo";
                case "Español": return "Torpedo de chi";
                case "Français": return "Torpille de chi";
                case "Italiano": return "Dardo del Chi";
                case "Português Brasileiro": return "Torpedo de Chi";
                case "Русский": return "Ци-полет";
                case "한국어": return "기공탄";
                case "简体中文": return "真气突";
                default: return "Chi Torpedo";
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

        ///<summary>spell=325201</summary>
        private static string DanceOfChiji_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Dance of Chi-Ji";
                case "Deutsch": return "Chi-Jis Tanz";
                case "Español": return "Danza de Chi-Ji";
                case "Français": return "Danse de Chi Ji";
                case "Italiano": return "Danza di Chi-Ji";
                case "Português Brasileiro": return "Dança de Chi-Ji";
                case "Русский": return "Танец Чи-Цзи";
                case "한국어": return "츠지의 춤";
                case "简体中文": return "赤精之舞";
                default: return "Dance of Chi-Ji";
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

        ///<summary>spell=116095</summary>
        private static string Disable_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Disable";
                case "Deutsch": return "Lähmen";
                case "Español": return "Incapacitar";
                case "Français": return "Handicap";
                case "Italiano": return "Inabilitazione";
                case "Português Brasileiro": return "Desativar";
                case "Русский": return "Вывести из строя";
                case "한국어": return "결박";
                case "简体中文": return "金刚震";
                default: return "Disable";
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

        ///<summary>spell=388193</summary>
        private static string FaelineStomp_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Faeline Stomp";
                case "Deutsch": return "Faelinienstampfen";
                case "Español": return "Pisotón de silfelino";
                case "Français": return "Piétinement de ligne faë";
                case "Italiano": return "Urto di Silfaglia";
                case "Português Brasileiro": return "Pisão Feelino";
                case "Русский": return "Волшебная линия";
                case "한국어": return "페이 지맥 울리기";
                case "简体中文": return "妖魂踏";
                default: return "Faeline Stomp";
            }
        }

        ///<summary>spell=326860</summary>
        private static string FallenOrder_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fallen Order";
                case "Deutsch": return "Gefallener Orden";
                case "Español": return "Orden caída";
                case "Français": return "Ordre des défunts";
                case "Italiano": return "Ordine Caduto";
                case "Português Brasileiro": return "Ordem Decaída";
                case "Русский": return "Павший орден";
                case "한국어": return "망자의 연맹";
                case "简体中文": return "陨落僧众";
                default: return "Fallen Order";
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

        ///<summary>spell=113656</summary>
        private static string FistsOfFury_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Fists of Fury";
                case "Deutsch": return "Furorfäuste";
                case "Español": return "Puños de furia";
                case "Français": return "Poings de fureur";
                case "Italiano": return "Pugni della Furia";
                case "Português Brasileiro": return "Punhos da Fúria";
                case "Русский": return "Неистовые кулаки";
                case "한국어": return "분노의 주먹";
                case "简体中文": return "怒雷破";
                default: return "Fists of Fury";
            }
        }
        ///<summary>spell=101545</summary>
        private static string FlyingSerpentKick_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Flying Serpent Kick";
                case "Deutsch": return "Fliegender Schlangentritt";
                case "Español": return "Patada del dragón volador";
                case "Français": return "Coup du serpent volant";
                case "Italiano": return "Calcio Volante della Serpe";
                case "Português Brasileiro": return "Chute Voador da Serpente";
                case "Русский": return "Удар летящего змея";
                case "한국어": return "비룡차기";
                case "简体中文": return "翔龙在天";
                default: return "Flying Serpent Kick";
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

        ///<summary>spell=123904</summary>
        private static string InvokeXuenTheWhiteTiger_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Invoke Xuen, the White Tiger";
                case "Deutsch": return "Xuen den Weißen Tiger beschwören";
                case "Español": return "Invocar a Xuen, el Tigre Blanco";
                case "Français": return "Invocation de Xuen, le Tigre blanc";
                case "Italiano": return "Invocazione: Xuen, la Tigre Bianca";
                case "Português Brasileiro": return "Evocar Xuen, o Tigre Branco";
                case "Русский": return "Призыв Сюэня, Белого Тигра";
                case "한국어": return "백호 쉬엔의 원령";
                case "简体中文": return "白虎下凡";
                default: return "Invoke Xuen, the White Tiger";
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

        ///<summary>spell=6770</summary>
        private static string Sap_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Sap";
                case "Deutsch": return "Kopfnuss";
                case "Español": return "Porrazo";
                case "Français": return "Assommer";
                case "Italiano": return "Tramortimento";
                case "Português Brasileiro": return "Aturdir";
                case "Русский": return "Ошеломление";
                case "한국어": return "혼절시키기";
                case "简体中文": return "闷棍";
                default: return "Sap";
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

        ///<summary>spell=137639</summary>
        private static string StormEarthAndFire_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Storm, Earth, and Fire";
                case "Deutsch": return "Sturm, Erde und Feuer";
                case "Español": return "Tormenta, Tierra y Fuego";
                case "Français": return "Tempête, Terre et Feu";
                case "Italiano": return "Tempesta, Terra e Fuoco";
                case "Português Brasileiro": return "Tempestade, Terra e Fogo";
                case "Русский": return "Буря, земля и огонь";
                case "한국어": return "폭풍과 대지와 불";
                case "简体中文": return "风火雷电";
                default: return "Storm, Earth, and Fire";
            }
        }

        ///<summary>spell=221771</summary>
        private static string StormEarthAndFire_Fixate_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Storm, Earth, and Fire: Fixate";
                case "Deutsch": return "Sturm, Erde und Feuer: Fixieren";
                case "Español": return "Tormenta, Tierra y Fuego: Fijar";
                case "Français": return "Fixation de Tempête, Terre et Feu";
                case "Italiano": return "Tempesta, Terra e Fuoco: Ossessione";
                case "Português Brasileiro": return "Tempestade, Terra e Fogo: Fixar";
                case "Русский": return "Буря, земля и огонь: сосредоточение внимания";
                case "한국어": return "폭풍과 대지와 불: 시선 고정";
                case "简体中文": return "风火雷电：锁定";
                default: return "Storm, Earth, and Fire: Fixate";
            }
        }

        ///<summary>spell=392983</summary>
        private static string StrikeOfTheWindlord_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Strike of the Windlord";
                case "Deutsch": return "Schlag des Windlords";
                case "Español": return "Golpe del Señor del Viento";
                case "Français": return "Frappe du seigneur des Vents";
                case "Italiano": return "Assalto del Signore del Vento";
                case "Português Brasileiro": return "Golpe do Senhor dos Ventos";
                case "Русский": return "Удар Владыки Ветра";
                case "한국어": return "바람의 군주의 일격";
                case "简体中文": return "风领主之击";
                default: return "Strike of the Windlord";
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
                case "Français": return "Invocation de statue du Tigre blanc";
                case "Italiano": return "Evocazione: Statua di Tigre Bianca";
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

        ///<summary>spell=116841</summary>
        private static string TigersLust_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Tiger's Lust";
                case "Deutsch": return "Tigerrausch";
                case "Español": return "Deseo del tigre";
                case "Français": return "Soif du tigre";
                case "Italiano": return "Brama della Tigre";
                case "Português Brasileiro": return "Luxúria do Tigre";
                case "Русский": return "Тигриное рвение";
                case "한국어": return "범의 욕망";
                case "简体中文": return "迅如猛虎";
                default: return "Tiger's Lust";
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

        ///<summary>spell=115080</summary>
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

        ///<summary>spell=116670</summary>
        private static string Vivify_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Vivify";
                case "Deutsch": return "Beleben";
                case "Español": return "Vivificar";
                case "Français": return "Vivifier";
                case "Italiano": return "Vivificazione";
                case "Português Brasileiro": return "Vivificar";
                case "Русский": return "Оживить";
                case "한국어": return "생기 충전";
                case "简体中文": return "活血术";
                default: return "Vivify";
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

        ///<summary>spell=152175</summary>
        private static string WhirlingDragonPunch_SpellName(string Language = "English")
        {
            switch (Language)
            {
                case "English": return "Whirling Dragon Punch";
                case "Deutsch": return "Wirbelnder Drachenschlag";
                case "Español": return "Puñetazo giratorio del dragón";
                case "Français": return "Coup de poing du dragon tourbillonnant";
                case "Italiano": return "Pugno Rotante del Drago";
                case "Português Brasileiro": return "Soco Giratório do Dragão";
                case "Русский": return "Удар крутящегося дракона";
                case "한국어": return "소용돌이 용의 주먹";
                case "简体中文": return "升龙霸";
                default: return "Whirling Dragon Punch";
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
        private List<string> m_IngameCommandsList = new List<string> { "RingofPeace", "Paralysis", "LegSweep", "Vivify", "FlyingSerpentKick", "Transcendence", "Transfer", "NoDetox", "BonedustBrew", "NoInterrupts", "NoCycle", "WhiteTigerStatue" };
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
        #endregion

        #region Misc Checks
        private bool TargetAlive()
        {
            if (Aimsharp.CustomFunction("UnitIsDead") == 2)
                return true;

            return false;
        }

        public bool UnitFocus(string unit)
        {
            if (Aimsharp.CustomFunction("UnitIsFocus") == 1 && unit == "party1" || Aimsharp.CustomFunction("UnitIsFocus") == 2 && unit == "party2" || Aimsharp.CustomFunction("UnitIsFocus") == 3 && unit == "party3" || Aimsharp.CustomFunction("UnitIsFocus") == 4 && unit == "party4" || Aimsharp.CustomFunction("UnitIsFocus") == 5 && unit == "player")
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

        public Dictionary<string, int> PartyDict = new Dictionary<string, int>() { };
        #endregion

        #region CanCasts
        private bool CanCastTouchofDeath(string unit)
        {
            if (Aimsharp.CanCast(TouchOfDeath_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(TouchOfDeath_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Health(unit) < 15 && Aimsharp.Range(unit) <= 5 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastTigerPalm(string unit)
        {
            if (Aimsharp.CanCast(TigerPalm_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(TigerPalm_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 5 && Aimsharp.Power("player") >= 50 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastFistsofFury(string unit)
        {
            if (Aimsharp.CanCast(FistsOfFury_SpellName(Language), unit, false, true) && Aimsharp.Range("target") <= 6 || (Aimsharp.SpellCooldown(FistsOfFury_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 6 && (Aimsharp.PlayerSecondaryPower() >= 2 || Aimsharp.HasBuff(Serenity_SpellName(Language), "player", true) || Aimsharp.CustomFunction("WoORSK") > 0 && Aimsharp.PlayerSecondaryPower() >= 2) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastStrikeOfTheWindlord(string unit)
        {
            if (Aimsharp.CanCast(StrikeOfTheWindlord_SpellName(Language), unit, false, true) && Aimsharp.Range("target") <= 6 || (Aimsharp.SpellCooldown(StrikeOfTheWindlord_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 6 && (Aimsharp.PlayerSecondaryPower() >= 2 || Aimsharp.HasBuff(Serenity_SpellName(Language), "player", true))))
                return true;

            return false;
        }

        private bool CanCastRisingSunKick(string unit)
        {
            if (Aimsharp.CanCast(RisingSunKick_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(RisingSunKick_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 5 && (Aimsharp.PlayerSecondaryPower() >= 2 || Aimsharp.HasBuff(Serenity_SpellName(Language), "player", true) || Aimsharp.CustomFunction("WoORSK") > 0 && Aimsharp.PlayerSecondaryPower() >= 1) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastWhirlingDragonPunch(string unit)
        {
            if (Aimsharp.CanCast(WhirlingDragonPunch_SpellName(Language), unit, false, true) && Aimsharp.Range("target") <= 6 || (Aimsharp.SpellCooldown(WhirlingDragonPunch_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 6 && Aimsharp.HasBuff(WhirlingDragonPunch_SpellName(Language), "player", true) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastStormEarthandFire(string unit)
        {
            if (Aimsharp.CanCast(StormEarthAndFire_SpellName(Language), unit, false, true) && Aimsharp.Range("target") <= 8 || ((Aimsharp.SpellCooldown(StormEarthAndFire_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) || Aimsharp.SpellCharges(StormEarthAndFire_SpellName(Language)) >= 1 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)) && Aimsharp.Range("target") <= 8  && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastSerenity(string unit)
        {
            if (Aimsharp.CanCast(Serenity_SpellName(Language), unit, false, true) && Aimsharp.Range("target") <= 8  || (Aimsharp.SpellCooldown(Serenity_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 8 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastWeaponsofOrder(string unit)
        {
            if (Aimsharp.CanCast(WeaponsOfOrder_SpellName(Language), unit, false, true) && Aimsharp.Range("target") <= 8 || (Aimsharp.SpellCooldown(WeaponsOfOrder_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 8 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastFallenOrder(string unit)
        {
            if (Aimsharp.CanCast(FallenOrder_SpellName(Language), unit, false, true) && Aimsharp.Range("target") <= 8 || (Aimsharp.SpellCooldown(FallenOrder_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 8 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastParalysis(string unit)
        {
            if (Aimsharp.CanCast(Paralysis_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Paralysis_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 20 && Aimsharp.Power("player") >= 20 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastRingofPeace(string unit)
        {
            if (Aimsharp.CanCast(RingOfPeace_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(RingOfPeace_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)))
                return true;

            return false;
        }

        private bool CanCastFortifyingBrew(string unit)
        {
            if (Aimsharp.CanCast(FortifyingBrew_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(FortifyingBrew_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)))
                return true;

            return false;
        }

        private bool CanCastTouchofKarma(string unit)
        {
            if (Aimsharp.CanCast(TouchOfKarma_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(TouchOfKarma_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastSpearHandStrike(string unit)
        {
            if (Aimsharp.CanCast(SpearHandStrike_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(SpearHandStrike_SpellName(Language)) <= 0 && Aimsharp.Range(unit) <= 5 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastLegSweep(string unit)
        {
            if (Aimsharp.CanCast(LegSweep_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(LegSweep_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)))
                return true;

            return false;
        }

        private bool CanCastDiffuseMagic(string unit)
        {
            if (Aimsharp.CanCast(DiffuseMagic_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(DiffuseMagic_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)))
                return true;

            return false;
        }

        private bool CanCastDampenHarm(string unit)
        {
            if (Aimsharp.CanCast(DampenHarm_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(DampenHarm_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0)))
                return true;

            return false;
        }

        private bool CanCastDetox(string unit)
        {
            if (Aimsharp.CanCast(Detox_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Detox_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && (Aimsharp.Range(unit) <= 40 || unit == "player") && Aimsharp.Power("player") >= 20))
                return true;

            return false;
        }

        private bool CanCastTigersLust(string unit)
        {
            if (Aimsharp.CanCast(TigersLust_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(TigersLust_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && (Aimsharp.Range(unit) <= 20 || unit == "player")))
                return true;

            return false;
        }

        private bool CanCastFlyingSerpentKick(string unit)
        {
            if (Aimsharp.CanCast(FlyingSerpentKick_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(FlyingSerpentKick_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastInvokeXuentheWhiteTiger(string unit)
        {
            if (Aimsharp.CanCast(InvokeXuenTheWhiteTiger_SpellName(Language), unit, false, true) && Aimsharp.Range("target") <= 8 || (Aimsharp.SpellCooldown(InvokeXuenTheWhiteTiger_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 8 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastSpinningCraneKick(string unit)
        {
            if (Aimsharp.CanCast(SpinningCraneKick_SpellName(Language), unit, false, true) && Aimsharp.Range("target") <= 6 || (Aimsharp.SpellCooldown(SpinningCraneKick_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 6 && (Aimsharp.PlayerSecondaryPower() >= 2 || Aimsharp.HasBuff(Serenity_SpellName(Language), "player", true) || Aimsharp.HasBuff(DanceOfChiji_SpellName(Language), "player", true) || Aimsharp.CustomFunction("WoORSK") > 0 && Aimsharp.PlayerSecondaryPower() >= 1) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastBlackoutKick(string unit)
        {
            if (Aimsharp.CanCast(BlackoutKick_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(BlackoutKick_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 5 && (Aimsharp.PlayerSecondaryPower() >= 1 || Aimsharp.HasBuff(Serenity_SpellName(Language), "player", true) || Aimsharp.HasBuff(BlackoutKicki_SpellName(Language), "player", true) || Aimsharp.CustomFunction("WoORSK") > 0 && Aimsharp.PlayerSecondaryPower() >= 0) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastDisable(string unit)
        {
            if (Aimsharp.CanCast(Disable_SpellName(Language), unit, true, true) || (Aimsharp.SpellCooldown(Disable_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range(unit) <= 5 && Aimsharp.Power() >= 15 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastExpelHarm(string unit)
        {
            if (Aimsharp.CanCast(ExpelHarm_SpellName(Language), unit, false, true) && Aimsharp.Range("target") <= 8 || (Aimsharp.SpellCooldown(ExpelHarm_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 8 && Aimsharp.Power() >= 15 && TargetAlive()))
                return true;

            return false;
        }
        private bool CanCastFaelineStomp(string unit)
        {
            if (Aimsharp.CanCast(FaelineStomp_SpellName(Language), unit, false, true) && Aimsharp.Range("target") <= 8 || (Aimsharp.SpellCooldown(FaelineStomp_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 8 && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastBonedustBrew(string unit)
        {
            if (Aimsharp.CanCast(BonedustBrew_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(BonedustBrew_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastWhiteTigerStatue(string unit)
        {
            if (Aimsharp.CanCast(SummonWhiteTigerStatue_SpellName(Language), unit, false, true) || (Aimsharp.SpellCooldown(SummonWhiteTigerStatue_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastChiBurst(string unit)
        {
            if (Aimsharp.CanCast(ChiBurst_SpellName(Language), unit, false, true) && Aimsharp.Range("target") <= 40 || (Aimsharp.SpellCooldown(ChiBurst_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 40  && TargetAlive()))
                return true;

            return false;
        }

        private bool CanCastChiWave(string unit)
        {
            if (Aimsharp.CanCast(ChiWave_SpellName(Language), unit, true, true) && Aimsharp.Range("target") <= 25 || (Aimsharp.SpellCooldown(ChiWave_SpellName(Language)) - Aimsharp.GCD() <= 0 && (Aimsharp.GCD() > 0 && Aimsharp.GCD() < Aimsharp.CustomFunction("GetSpellQueueWindow") || Aimsharp.GCD() == 0) && Aimsharp.Range("target") <= 25 && TargetAlive()))
                return true;

            return false;
        }
        #endregion

        #region Debuffs
        private int UnitDebuffSap(string unit)
        {
            if (Aimsharp.HasDebuff(Sap_SpellName(Language), unit, true))
                return Aimsharp.DebuffRemaining(Sap_SpellName(Language), unit, true);
            if (Aimsharp.HasDebuff(Sap_SpellName(Language), unit, false))
                return Aimsharp.DebuffRemaining(Sap_SpellName(Language), unit, false);

            return 0;
        }

        private int UnitDebuffBlind(string unit)
        {
            if (Aimsharp.HasDebuff(Blind_SpellName(Language), unit, true))
                return Aimsharp.DebuffRemaining(Blind_SpellName(Language), unit, true);
            if (Aimsharp.HasDebuff(Blind_SpellName(Language), unit, false))
                return Aimsharp.DebuffRemaining(Blind_SpellName(Language), unit, false);

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

            //Paralysis
            Macros.Add("ParalysisOff", "/" + FiveLetters + " Paralysis");

            //Leg Sweep
            Macros.Add("LegSweepOff", "/" + FiveLetters + " LegSweep");

            //Flying Serpent Kick
            Macros.Add("FlyingSerpentKickOff", "/" + FiveLetters + " FlyingSerpentKick");

            //Transcendence
            Macros.Add("TranscendenceOff", "/" + FiveLetters + " Transcendence");

            //Transcendence: Transfer
            Macros.Add("TransferOff", "/" + FiveLetters + " Transfer");

            //Detox
            Macros.Add("FOC_party1", "/focus party1");
            Macros.Add("FOC_party2", "/focus party2");
            Macros.Add("FOC_party3", "/focus party3");
            Macros.Add("FOC_party4", "/focus party4");
            Macros.Add("FOC_player", "/focus player");
            Macros.Add("DX_FOC", "/cast [@focus] " + Detox_SpellName(Language));


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

            CustomFunctions.Add("MarkDebuffCheck", "local markcheck = 0; if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitAffectingCombat('mouseover') and IsSpellInRange('Rising Sun Kick','mouseover') == 1 then markcheck = markcheck +1  for y = 1, 40 do local name,_,_,_,_,_,source  = UnitDebuff('mouseover', y) if name == 'Mark of the Crane' then markcheck = markcheck + 2 end end return markcheck end return 0");

            CustomFunctions.Add("HekiliWait", "if HekiliDisplayPrimary.Recommendations[1].wait ~= nil and HekiliDisplayPrimary.Recommendations[1].wait * 1000 > 0 then return math.floor(HekiliDisplayPrimary.Recommendations[1].wait * 1000) end return 0");

            CustomFunctions.Add("HekiliCycle", "if HekiliDisplayPrimary.Recommendations[1].indicator ~= nil and HekiliDisplayPrimary.Recommendations[1].indicator == 'cycle' then return 1 end return 0");

            CustomFunctions.Add("TargetIsMouseover", "if UnitExists('mouseover') and UnitIsDead('mouseover') ~= true and UnitExists('target') and UnitIsDead('target') ~= true and UnitIsUnit('mouseover', 'target') then return 1 end; return 0");

            CustomFunctions.Add("IsTargeting", "if SpellIsTargeting()\r\n then return 1\r\n end\r\n return 0");

            CustomFunctions.Add("IsRMBDown", "local MBD = 0 local isDown = IsMouseButtonDown(\"RightButton\") if isDown == true then MBD = 1 end return MBD");

            CustomFunctions.Add("WoORSK", "for i=1,40 do local _,_,_,_,_,duration,_,_,_,s=UnitAura('player',i);if s==311054 then return (duration - GetTime());end end if s~=311054 then return 0 end");

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
            Settings.Add(new Setting("Kicks/Interrupts"));
            Settings.Add(new Setting("Randomize Kicks:", false));
            Settings.Add(new Setting("Kick at milliseconds remaining", 50, 1500, 500));
            Settings.Add(new Setting("Kick channels after milliseconds", 50, 1500, 500));
            Settings.Add(new Setting("General"));
            Settings.Add(new Setting("Auto Start Combat:", true));
            Settings.Add(new Setting("Auto Slow/Cancel Flying Serpent Kick:", true));
            Settings.Add(new Setting("Reflect Boss Debuff using Diffuse Magic:", true));
            //Settings.Add(new Setting("Spread Mark of the Crane with Mouseover:", false));
            Settings.Add(new Setting("Auto Dampen Harm @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Diffuse Magic @ HP%", 0, 100, 15));
            Settings.Add(new Setting("Auto Fortifying Brew @ HP%", 0, 100, 30));
            Settings.Add(new Setting("Ring of Peace Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Bonedust Brew Cast:", m_CastingList, "Manual"));
            Settings.Add(new Setting("Summon White Tiger Statue Cast:", m_CastingList, "Manual"));
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

            Aimsharp.PrintMessage("Epic PVE - Monk Windwalker", Color.Yellow);
            Aimsharp.PrintMessage("This rotation requires the Hekili Addon !", Color.White);
            Aimsharp.PrintMessage("Hekili > Toggles > Unbind everything !", Color.White);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- Talents -", Color.White);
            Aimsharp.PrintMessage("Wowhead: https://www.wowhead.com/guide/classes/monk/windwalker/overview-pve-dps", Color.Yellow);
            Aimsharp.PrintMessage("-----", Color.Black);
            Aimsharp.PrintMessage("- General -", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoInterrupts - Disables Interrupts", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoCycle - Disables Target Cycle", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " NoDetox - Disables Detox", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Paralysis - Casts Paralysis @ Target on the next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " BonedustBrew - Casts Bonedust Brew @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " LegSweep - Casts Leg Sweep @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " FlyingSerpentKick - Casts Flying Serpent Kick @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Transcendence - Casts Transcendence @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Transfer - Casts Transfer @ next GCD", Color.Yellow);
            Aimsharp.PrintMessage("/" + FiveLetters + " Vivify - Casts Vivify until turned Off", Color.Yellow);
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
            m_DebuffsList = new List<string> { Paralysis_SpellName(Language), };
            m_BuffsList = new List<string> { BlackoutKicki_SpellName(Language), WeaponsOfOrder_SpellName(Language), StormEarthAndFire_SpellName(Language), WhirlingDragonPunch_SpellName(Language), Serenity_SpellName(Language), DanceOfChiji_SpellName(Language), };
            m_ItemsList = new List<string> { Healthstone_SpellName(Language) };
            m_SpellBook_General = new List<string> {
                //Covenants
                WeaponsOfOrder_SpellName(Language), //310454
                FallenOrder_SpellName(Language), //326860
                FaelineStomp_SpellName(Language), //388193
                BonedustBrew_SpellName(Language), //386276

                //Interrupt
                SpearHandStrike_SpellName(Language), //116705

                //General Monk
                BlackoutKick_SpellName(Language), //100784
                ChiBurst_SpellName(Language), //123986
                ChiTorpedo_SpellName(Language), //115008
                ChiWave_SpellName(Language), //115098
                CracklingJadeLightning_SpellName(Language), //117952
                DampenHarm_SpellName(Language), //122278
                Detox_SpellName(Language), //218164
                DiffuseMagic_SpellName(Language), //122783
                ExpelHarm_SpellName(Language), //322101
                FistsOfFury_SpellName(Language), //113656
                FlyingSerpentKick_SpellName(Language), //101545
                FortifyingBrew_SpellName(Language), //388917
                InvokeXuenTheWhiteTiger_SpellName(Language), //123904
                LegSweep_SpellName(Language), //119381
                Paralysis_SpellName(Language), //115078
                RingOfPeace_SpellName(Language), //116844
                RisingSunKick_SpellName(Language), //107428
                RushingJadeWind_SpellName(Language), //116847
                Serenity_SpellName(Language), //152173
                SpinningCraneKick_SpellName(Language), //101546
                StormEarthAndFire_Fixate_SpellName(Language), //221771
                StormEarthAndFire_SpellName(Language), //137639
                StrikeOfTheWindlord_SpellName(Language), //392983 -- New
                SummonWhiteTigerStatue_SpellName(Language), //388686 -- New
                TigerPalm_SpellName(Language), //100780
                TigersLust_SpellName(Language), //116841
                TouchOfDeath_SpellName(Language), //115080
                TouchOfKarma_SpellName(Language), //122470
                Transcendence_Transfer_SpellName(Language), //119996
                Transcendence_SpellName(Language), //101643
                Vivify_SpellName(Language), //116670
                WhirlingDragonPunch_SpellName(Language), //152175

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

            int DiseasePoisonCheck = Aimsharp.CustomFunction("DiseasePoisonCheck");
            int MarkDebuffMO = Aimsharp.CustomFunction("MarkDebuffCheck");
            //bool MOMark = GetCheckBox("Spread Mark with Mouseover:") == true;
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

            #region Above Pause Functions
            //Auto Slow Flying Serpent Kick
            if (GetCheckBox("Auto Slow/Cancel Flying Serpent Kick:"))
            {
                if (CanCastFlyingSerpentKick("player") && Aimsharp.LastCast() == FlyingSerpentKick_SpellName(Language) && Aimsharp.Range("target") <= 8)
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Flying Serpent Kick Slow", Color.Purple);
                    }
                    Aimsharp.Cast(FlyingSerpentKick_SpellName(Language), true);
                    return true;
                }
            }

            //Cast during Spinning Crane Kick
            if (Aimsharp.CastingID("player") == 101546)
            {
                //Hekili Cycle
                if (Aimsharp.CustomFunction("HekiliCycle") == 1 && EnemiesInMelee > 1)
                {
                    System.Threading.Thread.Sleep(50);
                    Aimsharp.Cast("TargetEnemy");
                    System.Threading.Thread.Sleep(50);
                    return true;
                }

                //Auto Target
                if ((!Enemy || Enemy && !TargetAlive() || Enemy && !TargetInCombat) && EnemiesInMelee > 0)
                {
                    System.Threading.Thread.Sleep(50);
                    Aimsharp.Cast("TargetEnemy");
                    System.Threading.Thread.Sleep(50);
                    return true;
                }

                if (SpellID1 == 100780 && CanCastTigerPalm("target"))
                {
                    Aimsharp.Cast(TigerPalm_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Tiger Palm (Target) - " + SpellID1, Color.Purple);
                    }
                    return true;
                }

                if ((SpellID1 == 100784 || SpellID1 == 205523) && CanCastBlackoutKick("target"))
                {
                    Aimsharp.Cast(BlackoutKick_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Blackout Kick (Target) - " + SpellID1, Color.Purple);
                    }
                    return true;
                }

                if (SpellID1 == 322109 && CanCastTouchofDeath("target"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Touch of Death - " + SpellID1, Color.Purple);
                    }
                    Aimsharp.Cast(TouchOfDeath_SpellName(Language));
                    return true;
                }

                if (SpellID1 == 107428 && CanCastRisingSunKick("target"))
                {
                    Aimsharp.Cast(RisingSunKick_SpellName(Language));
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Casting Rising Sun Kick (Target) - " + SpellID1, Color.Purple);
                    }
                    return true;
                }
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
                if (CanCastSpearHandStrike("target"))
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

                if (CanCastSpearHandStrike("target"))
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

            //Auto Fortifying Brew
            if (CanCastFortifyingBrew("player") == true)
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Fortifying Brew @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Fortifying Brew - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Fortifying Brew @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(FortifyingBrew_SpellName(Language));
                    return true;
                }
            }

            //Auto Diffuse Magic
            if (CanCastDiffuseMagic("player") == true)
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Diffuse Magic @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Diffuse Magic - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Diffuse Magic @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(DiffuseMagic_SpellName(Language));
                    return true;
                }
            }

            //Auto Dampen Harm
            if (CanCastDampenHarm("player") == true)
            {
                if (Aimsharp.Health("player") <= GetSlider("Auto Dampen Harm @ HP%"))
                {
                    if (Debug)
                    {
                        Aimsharp.PrintMessage("Using Dampen Harm - Player HP% " + Aimsharp.Health("player") + " due to setting being on HP% " + GetSlider("Auto Dampen Harm @ HP%"), Color.Purple);
                    }
                    Aimsharp.Cast(DampenHarm_SpellName(Language));
                    return true;
                }
            }

            #endregion

            #region Queues
            //Queues
            bool FlyingSerpentKick = Aimsharp.IsCustomCodeOn("FlyingSerpentKick");
            if ((Aimsharp.SpellCooldown(FlyingSerpentKick_SpellName(Language)) > 2000 || Aimsharp.LastCast() == FlyingSerpentKick_SpellName(Language)) && FlyingSerpentKick)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flying Serpent Kick queue toggle", Color.Purple);
                }
                Aimsharp.Cast("FlyingSerpentKickOff");
                return true;
            }

            if (FlyingSerpentKick && CanCastFlyingSerpentKick("player") == true)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Flying Serpent Kick through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(FlyingSerpentKick_SpellName(Language));
                return true;
            }

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

            if (RingofPeace && CanCastRingofPeace("player"))
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

            if (BonedustBrew && CanCastBonedustBrew("player") && (BonedustBrewCast == "Player" && Aimsharp.Range("target") <= 5 || BonedustBrewCast != "Player"))
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

            if (WhiteTigerStatue && CanCastWhiteTigerStatue("player") && (WhiteTigerStatueCast == "Player" && Aimsharp.Range("target") <= 5 || WhiteTigerStatueCast != "Player"))
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

            bool Transcendence = Aimsharp.IsCustomCodeOn("Transcendence");
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

            bool Paralysis = Aimsharp.IsCustomCodeOn("Paralysis");
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

            if (Paralysis && CanCastParalysis("target"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Paralysis through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Paralysis_SpellName(Language));
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

            if (LegSweep && CanCastLegSweep("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Leg Sweep through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(LegSweep_SpellName(Language));
                return true;
            }

            bool Vivify = Aimsharp.IsCustomCodeOn("Vivify");
            //Queue Vivify Spam
            if (Vivify && (Aimsharp.CanCast(Vivify_SpellName(Language), "player", false, true) || Aimsharp.CanCast(Vivify_SpellName(Language), "target", true, true)) && !Aimsharp.PlayerIsMoving())
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Vivify due to toggle being On", Color.Purple);
                }
                Aimsharp.Cast(Vivify_SpellName(Language));
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
                    if (Aimsharp.Health(partyunit) > 0 && Aimsharp.Range(partyunit) <= 40)
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
                    if (CanCastDetox(unit.Key) && (unit.Key == "player" || Aimsharp.Range(unit.Key) <= 40) && isUnitCleansable(target, states))
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
                    if ((SpellID1 == 310454 || SpellID1 == 387184) && CanCastWeaponsofOrder("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Weapons of Order - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WeaponsOfOrder_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 326860 && CanCastFallenOrder("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fallen Order - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FallenOrder_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 327104 || SpellID1 == 388193) && CanCastFaelineStomp("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Faeline Stomp - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FaelineStomp_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 325216 || SpellID1 == 386276) && CanCastBonedustBrew("player") && ((BonedustBrewCast == "Player" && Aimsharp.Range("target") <= 5) || BonedustBrewCast != "Player"))
                    {
                        switch (BonedustBrewCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast(BonedustBrew_SpellName(Language));
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " -" + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("BonedustBrewC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Bonedust Brew - " + BonedustBrewCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("BonedustBrewP");
                                return true;
                        }
                    }
                    #endregion

                    #region General Spells - NoGCD
                    //Class Spells
                    //Instant [GCD FREE]
                    if (SpellID1 == 116705 && CanCastSpearHandStrike("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spear Hand Strike - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SpearHandStrike_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 137639 && CanCastStormEarthandFire("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Storm, Earth, and Fire - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(StormEarthAndFire_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 221771 && Aimsharp.CanCast(StormEarthAndFire_Fixate_SpellName(Language), "target", true, true))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Storm, Earth, and Fire: Fixate - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(StormEarthAndFire_Fixate_SpellName(Language), true);
                        return true;
                    }

                    if (SpellID1 == 152173 && CanCastSerenity("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Serenity - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Serenity_SpellName(Language), true);
                        return true;
                    }
                    #endregion

                    #region General Spells - Player GCD
                    //General Monk
                    //Instant [GCD]
                    ///Player
                    if (SpellID1 == 388686 && CanCastWhiteTigerStatue("player") && ((WhiteTigerStatueCast == "Player" && Aimsharp.Range("target") <= 5) || WhiteTigerStatueCast != "Player"))
                    {
                        switch (WhiteTigerStatueCast)
                        {
                            case "Manual":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Summon White Tiger Statue - " + WhiteTigerStatueCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast(SummonWhiteTigerStatue_SpellName(Language));
                                return true;
                            case "Cursor":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Summon White Tiger Statue - " + WhiteTigerStatueCast + " -" + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("WhiteTigerStatueC");
                                return true;
                            case "Player":
                                if (Debug)
                                {
                                    Aimsharp.PrintMessage("Casting Summon White Tiger Statue - " + WhiteTigerStatueCast + " - " + SpellID1, Color.Purple);
                                }
                                Aimsharp.Cast("WhiteTigerStatueP");
                                return true;
                        }
                    }
                    if (SpellID1 == 322101 && CanCastExpelHarm("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Expel Harm - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ExpelHarm_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 218164 && CanCastDetox("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Detox - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Detox_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 123986 && CanCastChiBurst("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Chi Burst - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ChiBurst_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 116847 && Aimsharp.CanCast(RushingJadeWind_SpellName(Language), "player", true, false))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rushing Jade Wind - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(RushingJadeWind_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 201318 || SpellID1 == 115203 || SpellID1 == 388917) && CanCastFortifyingBrew("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fortifying Brew - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FortifyingBrew_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 123904 && CanCastInvokeXuentheWhiteTiger("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Invoke Xuen, the White Tiger - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(InvokeXuenTheWhiteTiger_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 113656 && CanCastFistsofFury("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Fists of Fury - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FistsOfFury_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 392983 && CanCastStrikeOfTheWindlord("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Strike of the Windlord - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(StrikeOfTheWindlord_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 101545 && CanCastFlyingSerpentKick("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Flying Serpent Kick - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(FlyingSerpentKick_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 152175 && CanCastWhirlingDragonPunch("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Whirling Dragon Punch - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(WhirlingDragonPunch_SpellName(Language));
                        return true;
                    }
                    #endregion

                    #region General Spells - Target GCD
                    ///Target
                    if (SpellID1 == 115078 && CanCastParalysis("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Paralysis - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Paralysis_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 101546 || SpellID1 == 322729) && CanCastSpinningCraneKick("player"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Spinning Crane Kick - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(SpinningCraneKick_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 100780 && CanCastTigerPalm("target"))
                    {
                        Aimsharp.Cast(TigerPalm_SpellName(Language));
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Tiger Palm (Target) - " + SpellID1, Color.Purple);
                        }
                        return true;
                    }

                    if ((SpellID1 == 100784 || SpellID1 == 205523) && CanCastBlackoutKick("target"))
                    {
                        Aimsharp.Cast(BlackoutKick_SpellName(Language));
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Blackout Kick (Target) - " + SpellID1, Color.Purple);
                        }
                        return true;
                    }

                    if (SpellID1 == 322109 && CanCastTouchofDeath("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Touch of Death - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TouchOfDeath_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 115098 && CanCastChiWave("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Chi Wave - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(ChiWave_SpellName(Language));
                        return true;
                    }

                    if ((SpellID1 == 125174 || SpellID1 == 122470) && CanCastTouchofKarma("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Touch of Karma - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(TouchOfKarma_SpellName(Language));
                        return true;
                    }

                    if (SpellID1 == 107428 && CanCastRisingSunKick("target"))
                    {
                        Aimsharp.Cast(RisingSunKick_SpellName(Language));
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Rising Sun Kick (Target) - " + SpellID1, Color.Purple);
                        }
                        return true;
                    }


                    if (SpellID1 == 116095 && CanCastDisable("target"))
                    {
                        if (Debug)
                        {
                            Aimsharp.PrintMessage("Casting Disable - " + SpellID1, Color.Purple);
                        }
                        Aimsharp.Cast(Disable_SpellName(Language));
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

            if (Aimsharp.IsCustomCodeOn("RingofPeace") && Aimsharp.SpellCooldown(RingOfPeace_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }

            if (Aimsharp.IsCustomCodeOn("BonedustBrew") && Aimsharp.SpellCooldown(BonedustBrew_SpellName(Language)) - Aimsharp.GCD() <= 0 && Aimsharp.CustomFunction("IsRMBDown") == 1)
            {
                return false;
            }
            #endregion

            #region Queues
            //Queues
            bool FlyingSerpentKick = Aimsharp.IsCustomCodeOn("FlyingSerpentKick");
            if ((Aimsharp.SpellCooldown(FlyingSerpentKick_SpellName(Language)) > 2000 || Aimsharp.LastCast() == FlyingSerpentKick_SpellName(Language)) && FlyingSerpentKick)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Turning Off Flying Serpent Kick queue toggle", Color.Purple);
                }
                Aimsharp.Cast("FlyingSerpentKickOff");
                return true;
            }

            if (FlyingSerpentKick && CanCastFlyingSerpentKick("player") == true)
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Flying Serpent Kick through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(FlyingSerpentKick_SpellName(Language));
                return true;
            }

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

            if (RingofPeace && CanCastRingofPeace("player"))
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

            if (BonedustBrew && CanCastBonedustBrew("player") && (BonedustBrewCast == "Player" && Aimsharp.Range("target") <= 5 || BonedustBrewCast != "Player"))
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

            if (WhiteTigerStatue && CanCastWhiteTigerStatue("player") && (WhiteTigerStatueCast == "Player" && Aimsharp.Range("target") <= 5 || WhiteTigerStatueCast != "Player"))
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

            bool Transcendence = Aimsharp.IsCustomCodeOn("Transcendence");
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

            bool Paralysis = Aimsharp.IsCustomCodeOn("Paralysis");
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

            if (Paralysis && CanCastParalysis("target"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Paralysis through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(Paralysis_SpellName(Language));
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

            if (LegSweep && CanCastLegSweep("player"))
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Leg Sweep through queue toggle", Color.Purple);
                }
                Aimsharp.Cast(LegSweep_SpellName(Language));
                return true;
            }

            bool Vivify = Aimsharp.IsCustomCodeOn("Vivify");
            //Queue Vivify Spam
            if (Vivify && (Aimsharp.CanCast(Vivify_SpellName(Language), "player", false, true) || Aimsharp.CanCast(Vivify_SpellName(Language), "target", true, true)) && !Aimsharp.PlayerIsMoving())
            {
                if (Debug)
                {
                    Aimsharp.PrintMessage("Casting Vivify due to toggle being On", Color.Purple);
                }
                Aimsharp.Cast(Vivify_SpellName(Language));
                return true;
            }
            #endregion

            #region Out of Combat Spells
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