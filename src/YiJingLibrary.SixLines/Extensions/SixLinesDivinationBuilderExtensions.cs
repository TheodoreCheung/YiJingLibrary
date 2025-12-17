using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YiJingLibrary.Core;
using YiJingLibrary.ChineseLunarCalendar;

namespace YiJingLibrary.SixLines.Extensions;

/// <summary>
/// 六爻盘构建器扩展类。
/// </summary>
public static class SixLinesDivinationBuilderExtensions
{
    extension(SixLinesDivination sixLinesDivination)
    {
        /// <summary>
        /// 为本、变卦计算世、应所在爻位。
        /// </summary>
        /// <returns></returns>
        public SixLinesDivination CalculateLinePosition()
        {
            CalculateLinePosition(sixLinesDivination.Original);

            if (sixLinesDivination.Changed is not null)
                CalculateLinePosition(sixLinesDivination.Changed);

            return sixLinesDivination;
        }

        /// <summary>
        /// 为本、变卦所有爻配干支。
        /// </summary>
        /// <returns></returns>
        public SixLinesDivination AssignStemBranch()
        {
            AssignStemBranch(sixLinesDivination.Original);

            if (sixLinesDivination.Changed is not null)
                AssignStemBranch(sixLinesDivination.Changed);

            return sixLinesDivination;
        }

        /// <summary>
        /// 为本、变卦所有爻配六亲。
        /// </summary>
        /// <returns></returns>
        public SixLinesDivination AssignSixKins()
        {
            AssignSixKins(sixLinesDivination.Original, sixLinesDivination.Original.FivePhase);

            if (sixLinesDivination.Changed is not null)
                AssignSixKins(sixLinesDivination.Changed, sixLinesDivination.Original.FivePhase);

            return sixLinesDivination;
        }

        /// <summary>
        /// 找本卦伏神（如有）。
        /// </summary>
        /// <returns></returns>
        public SixLinesDivination FindHiddenSpirit()
        {
            FindHiddenSpirit(sixLinesDivination.Original);

            return sixLinesDivination;
        }

        /// <summary>
        /// 为本卦所有爻配六神。
        /// </summary>
        /// <returns></returns>
        public SixLinesDivination AssignSixSpirits()
        {
            AssignSixSpirits(sixLinesDivination.Original, sixLinesDivination.InquiryTime.Lunar);

            return sixLinesDivination;
        }

        /// <summary>
        /// 绑四象。
        /// </summary>
        /// <returns></returns>
        public SixLinesDivination AssignFourSymbols()
        {
            if (sixLinesDivination.Changed is null)
                return sixLinesDivination;

            AssignFourSymbols(sixLinesDivination.Original, sixLinesDivination.Changed);

            return sixLinesDivination;
        }

        /// <summary>
        /// 绑神煞。
        /// </summary>
        /// <returns></returns>
        public SixLinesDivination AssignSpiritsAndMalignities()
        {
            AssignSpiritAndMalignity(sixLinesDivination);
            
            return sixLinesDivination;
        }

        /// <summary>
        /// 京房六十四卦定世应。
        /// 世爻定位口诀：八卦之首世六当，一二三四五递上。游魂四位归魂三，此法万古不能忘。
        /// 应爻定位口诀：初世四应，二世五应，三世六应，四世初应，五世二应，六世三应。
        /// </summary>
        /// <param name="hexagram"></param>
        private static void CalculateLinePosition(Hexagram hexagram)
        {
            // 本宫卦
            if (hexagram.IsPalace())
            {
                hexagram[6].Position = Position.Worldly;
                hexagram[3].Position = Position.Corresponding;
                return;
            }

            // 游魂卦
            if (hexagram.IsWanderingSoul())
            {
                hexagram[4].Position = Position.Worldly;
                hexagram[1].Position = Position.Corresponding;
                return;
            }

            // 归魂卦
            if (hexagram.IsReturningSoul())
            {
                hexagram[3].Position = Position.Worldly;
                hexagram[6].Position = Position.Corresponding;
                return;
            }

            // hexagram.Palace为八卦，只有3个爻，先将其转换为八纯卦
            var palace = hexagram.Palace.ToHexagramValue();

            // i从初爻开始到五爻，对爻取反，看取反后的卦是否与<see cref="hexagram"/>相同，相同则i为世位
            for (var i = 0; i < 6; i++)
            {
                if (i is 3) continue;

                palace ^= (byte)(1 << i);
                if (palace != hexagram) continue;

                var worldly = (byte)(i > 3 ? i : i + 1);
                hexagram[worldly].Position = Position.Worldly;

                var corresponding = (byte)(worldly >= 4 ? worldly - 2 : worldly + 2);
                hexagram[corresponding].Position = Position.Corresponding;

                return;
            }
        }

        /// <summary>
        /// 配干支。
        /// 
        /// 乾内甲子外壬午，坎内戊寅外戊申；
        /// 震内庚子外庚午，艮内丙辰外丙戌；
        /// 坤内乙未外癸丑，巽内辛丑外辛未；
        /// 离内己卯外己酉，兑内丁巳外丁亥。
        /// </summary>
        /// <param name="hexagram"></param>
        private static void AssignStemBranch(Hexagram hexagram)
        {
            // 内卦
            if (hexagram.Lower.Equals(Trigram.Qian))
            {
                hexagram[1].StemBranch = new StemBranch(HeavenlyStem.Jia, EarthlyBranch.Zi);
                hexagram[2].StemBranch = new StemBranch(HeavenlyStem.Jia, EarthlyBranch.Yin);
                hexagram[3].StemBranch = new StemBranch(HeavenlyStem.Jia, EarthlyBranch.Chen);
            }

            if (hexagram.Lower.Equals(Trigram.Zhen))
            {
                hexagram[1].StemBranch = new StemBranch(HeavenlyStem.Geng, EarthlyBranch.Zi);
                hexagram[2].StemBranch = new StemBranch(HeavenlyStem.Geng, EarthlyBranch.Yin);
                hexagram[3].StemBranch = new StemBranch(HeavenlyStem.Geng, EarthlyBranch.Chen);
            }

            if (hexagram.Lower.Equals(Trigram.Kan))
            {
                hexagram[1].StemBranch = new StemBranch(HeavenlyStem.Wu, EarthlyBranch.Yin);
                hexagram[2].StemBranch = new StemBranch(HeavenlyStem.Wu, EarthlyBranch.Chen);
                hexagram[3].StemBranch = new StemBranch(HeavenlyStem.Wu, EarthlyBranch.Wu);
            }

            if (hexagram.Lower.Equals(Trigram.Gen))
            {
                hexagram[1].StemBranch = new StemBranch(HeavenlyStem.Bing, EarthlyBranch.Chen);
                hexagram[2].StemBranch = new StemBranch(HeavenlyStem.Bing, EarthlyBranch.Wu);
                hexagram[3].StemBranch = new StemBranch(HeavenlyStem.Bing, EarthlyBranch.Shen);
            }

            if (hexagram.Lower.Equals(Trigram.Kun))
            {
                hexagram[1].StemBranch = new StemBranch(HeavenlyStem.Yi, EarthlyBranch.Wei);
                hexagram[2].StemBranch = new StemBranch(HeavenlyStem.Yi, EarthlyBranch.Si);
                hexagram[3].StemBranch = new StemBranch(HeavenlyStem.Yi, EarthlyBranch.Mao);
            }

            if (hexagram.Lower.Equals(Trigram.Xun))
            {
                hexagram[1].StemBranch = new StemBranch(HeavenlyStem.Xin, EarthlyBranch.Chou);
                hexagram[2].StemBranch = new StemBranch(HeavenlyStem.Xin, EarthlyBranch.Hai);
                hexagram[3].StemBranch = new StemBranch(HeavenlyStem.Xin, EarthlyBranch.You);
            }

            if (hexagram.Lower.Equals(Trigram.Li))
            {
                hexagram[1].StemBranch = new StemBranch(HeavenlyStem.Ji, EarthlyBranch.Mao);
                hexagram[2].StemBranch = new StemBranch(HeavenlyStem.Ji, EarthlyBranch.Chou);
                hexagram[3].StemBranch = new StemBranch(HeavenlyStem.Ji, EarthlyBranch.Hai);
            }

            if (hexagram.Lower.Equals(Trigram.Dui))
            {
                hexagram[1].StemBranch = new StemBranch(HeavenlyStem.Ding, EarthlyBranch.Si);
                hexagram[2].StemBranch = new StemBranch(HeavenlyStem.Ding, EarthlyBranch.Mao);
                hexagram[3].StemBranch = new StemBranch(HeavenlyStem.Ding, EarthlyBranch.Chou);
            }

            // 外卦
            if (hexagram.Upper.Equals(Trigram.Qian))
            {
                hexagram[4].StemBranch = new StemBranch(HeavenlyStem.Ren, EarthlyBranch.Wu);
                hexagram[5].StemBranch = new StemBranch(HeavenlyStem.Ren, EarthlyBranch.Shen);
                hexagram[6].StemBranch = new StemBranch(HeavenlyStem.Ren, EarthlyBranch.Xu);
            }

            if (hexagram.Upper.Equals(Trigram.Zhen))
            {
                hexagram[4].StemBranch = new StemBranch(HeavenlyStem.Geng, EarthlyBranch.Wu);
                hexagram[5].StemBranch = new StemBranch(HeavenlyStem.Geng, EarthlyBranch.Shen);
                hexagram[6].StemBranch = new StemBranch(HeavenlyStem.Geng, EarthlyBranch.Xu);
            }

            if (hexagram.Upper.Equals(Trigram.Kan))
            {
                hexagram[4].StemBranch = new StemBranch(HeavenlyStem.Wu, EarthlyBranch.Shen);
                hexagram[5].StemBranch = new StemBranch(HeavenlyStem.Wu, EarthlyBranch.Xu);
                hexagram[6].StemBranch = new StemBranch(HeavenlyStem.Wu, EarthlyBranch.Zi);
            }

            if (hexagram.Upper.Equals(Trigram.Gen))
            {
                hexagram[4].StemBranch = new StemBranch(HeavenlyStem.Bing, EarthlyBranch.Xu);
                hexagram[5].StemBranch = new StemBranch(HeavenlyStem.Bing, EarthlyBranch.Zi);
                hexagram[6].StemBranch = new StemBranch(HeavenlyStem.Bing, EarthlyBranch.Yin);
            }

            if (hexagram.Upper.Equals(Trigram.Kun))
            {
                hexagram[4].StemBranch = new StemBranch(HeavenlyStem.Gui, EarthlyBranch.Chou);
                hexagram[5].StemBranch = new StemBranch(HeavenlyStem.Gui, EarthlyBranch.Hai);
                hexagram[6].StemBranch = new StemBranch(HeavenlyStem.Gui, EarthlyBranch.You);
            }

            if (hexagram.Upper.Equals(Trigram.Xun))
            {
                hexagram[4].StemBranch = new StemBranch(HeavenlyStem.Xin, EarthlyBranch.Wei);
                hexagram[5].StemBranch = new StemBranch(HeavenlyStem.Xin, EarthlyBranch.Si);
                hexagram[6].StemBranch = new StemBranch(HeavenlyStem.Xin, EarthlyBranch.Mao);
            }

            if (hexagram.Upper.Equals(Trigram.Li))
            {
                hexagram[4].StemBranch = new StemBranch(HeavenlyStem.Ji, EarthlyBranch.You);
                hexagram[5].StemBranch = new StemBranch(HeavenlyStem.Ji, EarthlyBranch.Wei);
                hexagram[6].StemBranch = new StemBranch(HeavenlyStem.Ji, EarthlyBranch.Si);
            }

            if (hexagram.Upper.Equals(Trigram.Dui))
            {
                hexagram[4].StemBranch = new StemBranch(HeavenlyStem.Ding, EarthlyBranch.Hai);
                hexagram[5].StemBranch = new StemBranch(HeavenlyStem.Ding, EarthlyBranch.You);
                hexagram[6].StemBranch = new StemBranch(HeavenlyStem.Ding, EarthlyBranch.Wei);
            }
        }

        /// <summary>
        /// 配六亲。
        /// </summary>
        /// <param name="hexagram"></param>
        /// <param name="palaceFivePhase">卦宫五行</param>
        private static void AssignSixKins(Hexagram hexagram, FivePhase palaceFivePhase)
        {
            if (hexagram.Lines.Any(line => line.Attributes.Get<StemBranch>() is null))
                throw new InvalidOperationException("Cannot assign six kins before assigning stem and branch.");

            for (byte i = 1; i <= 6; i++)
            {
                // 爻五行
                var yaoFivePhases = hexagram[i].StemBranch.EarthlyBranch.FivePhase;
                // 以卦宫五行palaceFivePhases为我，依生克判断六亲
                if (palaceFivePhase.Equals(yaoFivePhases))
                    hexagram[i].SixKin = SixKin.Sibling;
                else if (palaceFivePhase.Generates(yaoFivePhases))
                    hexagram[i].SixKin = SixKin.Offspring;
                else if (palaceFivePhase.Restrains(yaoFivePhases))
                    hexagram[i].SixKin = SixKin.Wealth;
                else if (palaceFivePhase.GeneratesBy(yaoFivePhases))
                    hexagram[i].SixKin = SixKin.Parent;
                else if (palaceFivePhase.RestrainsBy(yaoFivePhases))
                    hexagram[i].SixKin = SixKin.Officer;
            }
        }

        /// <summary>
        /// 找伏神。
        /// </summary>
        /// <param name="hexagram"></param>
        private static void FindHiddenSpirit(Hexagram hexagram)
        {
            // 找出当前卦的所有六亲
            var sixKins = hexagram.Lines
                .Select(line => line.SixKin)
                .Distinct()
                .ToList();
            // 如果六亲齐全，无需找伏神
            if (sixKins.Count == 5) return;
            // 找出当前卦缺少哪些六亲
            var exceptSixKins = SixKin.All.Except(sixKins).ToList();

            // 本宫卦纳干支和六亲
            var palace = Hexagram.FromValue(hexagram.Palace.ToHexagramValue());
            AssignStemBranch(palace);
            AssignSixKins(palace, hexagram.Palace.FivePhase);

            // 从本宫卦中找出当前卦缺少六亲的所有爻
            var exceptSixKinLines = palace.Lines
                .Where(line => exceptSixKins.Contains(line.SixKin))
                .ToList();
            foreach (var line in exceptSixKinLines)
            {
                hexagram[line].HiddenSpirit = new HiddenSpirit(line.StemBranch, line.SixKin);
            }
        }

        /// <summary>
        /// 装六神。
        /// </summary>
        /// <param name="original">主卦</param>
        /// <param name="lunarStemBranch">农历起卦日期</param>
        /// <exception cref="InvalidDataException"></exception>
        private static void AssignSixSpirits(Hexagram original, LunarStemBranch lunarStemBranch)
        {
            var sortedSixSpirits = new List<SixSpirit>
            {
                SixSpirit.AzureDragon,
                SixSpirit.VermilionBird,
                SixSpirit.HookChen,
                SixSpirit.CoiledSnake,
                SixSpirit.WhiteTiger,
                SixSpirit.BlackTortoise
            };

            int index;

            if (lunarStemBranch.Day.HeavenlyStem.Equals(HeavenlyStem.Jia) ||
                lunarStemBranch.Day.HeavenlyStem.Equals(HeavenlyStem.Yi))
            {
                index = 0;
            }
            else if (lunarStemBranch.Day.HeavenlyStem.Equals(HeavenlyStem.Bing) ||
                     lunarStemBranch.Day.HeavenlyStem.Equals(HeavenlyStem.Ding))
            {
                index = 1;
            }
            else if (lunarStemBranch.Day.HeavenlyStem.Equals(HeavenlyStem.Wu))
            {
                index = 2;
            }
            else if (lunarStemBranch.Day.HeavenlyStem.Equals(HeavenlyStem.Ji))
            {
                index = 3;
            }
            else if (lunarStemBranch.Day.HeavenlyStem.Equals(HeavenlyStem.Geng) ||
                     lunarStemBranch.Day.HeavenlyStem.Equals(HeavenlyStem.Xin))
            {
                index = 4;
            }
            else if (lunarStemBranch.Day.HeavenlyStem.Equals(HeavenlyStem.Ren) ||
                     lunarStemBranch.Day.HeavenlyStem.Equals(HeavenlyStem.Gui))
            {
                index = 5;
            }
            else
            {
                throw new InvalidDataException("Invalid lunarDate");
            }

            var sixSpirits = sortedSixSpirits[index..].Concat(sortedSixSpirits[..index]).ToArray();

            for (byte i = 0; i < 6; i++)
            {
                var yaoIndex = (byte)(i + 1);
                original[yaoIndex].SixSpirit = sixSpirits[i];
            }
        }

        /// <summary>
        /// 绑四象。
        /// </summary>
        /// <param name="original"></param>
        /// <param name="changed"></param>
        private static void AssignFourSymbols(Hexagram original, Hexagram changed)
        {
            for (byte i = 1; i <= 6; i++)
            {
                var originalYinYang = original[i].YinYang
                                      ?? throw new InvalidDataException(
                                          "Cannot assign four symbols before assigning yin-yang.");
                var changedYinYang = changed[i].YinYang
                                     ?? throw new InvalidDataException(
                                         "Cannot assign four symbols before assigning yin-yang.");

                if (originalYinYang.Equals(changedYinYang))
                {
                    original[i].FourSymbol = originalYinYang.Equals(YinYang.Yang)
                        ? FourSymbol.YoungYang
                        : FourSymbol.YoungYin;
                }
                else
                {
                    original[i].FourSymbol = originalYinYang.Equals(YinYang.Yang)
                        ? FourSymbol.OldYang
                        : FourSymbol.OldYin;
                }
            }
        }

        /// <summary>
        /// 绑神煞。
        /// </summary>
        /// <param name="divination"></param>
        private static void AssignSpiritAndMalignity(SixLinesDivination divination)
        {
            divination.SpiritAndMalignityList.AddRange([
                SpiritAndMalignity.Nobleman,
                SpiritAndMalignity.SalarySpirit,
                SpiritAndMalignity.PostHorse,
                SpiritAndMalignity.PeachBlossom,
                SpiritAndMalignity.YangBlade,
                SpiritAndMalignity.CultureFlourish,
                SpiritAndMalignity.CelestialPhysician,
                SpiritAndMalignity.RobberyMalignity,
                SpiritAndMalignity.DisasterMalignity,
                SpiritAndMalignity.GeneralsStar,
                SpiritAndMalignity.Canopy,
                SpiritAndMalignity.StarOfStrategy,
                SpiritAndMalignity.DeathSpirit,
                SpiritAndMalignity.HeavenlyJoy,
                SpiritAndMalignity.MarriageBed,
                SpiritAndMalignity.BridalChamber
            ]);
        }
    }
}