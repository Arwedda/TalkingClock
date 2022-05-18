using TalkingClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Linq;

namespace TalkingClockTests
{
    [TestClass]
    public class TalkingClockTests
    {
        private string[] _sampleResults =
        {
            "00:00 Twelve o'clock",
            "01:01 One past one",
            "02:02 Two past two",
            "03:03 Three past three",
            "04:04 Four past four",
            "05:05 Five past five",
            "06:06 Six past six",
            "07:07 Seven past seven",
            "08:08 Eight past eight",
            "09:09 Nine past nine",
            "10:10 Ten past ten",
            "11:11 Eleven past eleven",
            "12:12 Twelve past twelve",
            "13:13 Thirteen past one",
            "14:14 Fourteen past two",
            "15:15 Quarter past three",
            "16:16 Sixteen past four",
            "17:17 Seventeen past five",
            "18:18 Eighteen past six",
            "19:19 Nineteen past seven",
            "20:20 Twenty past eight",
            "21:21 Twenty-one past nine",
            "22:22 Twenty-two past ten",
            "23:23 Twenty-three past eleven"
        };

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {

        }

        [TestMethod]
        public void ValidMinutesTest()
        {
            List<bool> shouldBeFalse = new();
            List<bool> shouldBeTrue = new();
            for (int i = 0; i < 60; i++)
            {
                shouldBeTrue.Add(i.ValidMinutes());
            }

            shouldBeFalse.Add((-1).ValidMinutes());
            shouldBeFalse.Add(60.ValidMinutes());
            shouldBeFalse.Add(1337.ValidMinutes());

            foreach (var test in shouldBeTrue)
            {
                Assert.IsTrue(test);
            }

            foreach (var test in shouldBeFalse)
            {
                Assert.IsFalse(test);
            }
        }

        [TestMethod]
        public void ValidHoursTest()
        {
            List<bool> shouldBeFalse = new();
            List<bool> shouldBeTrue = new();
            for (int i = 0; i < 24; i++)
            {
                shouldBeTrue.Add(i.ValidHours());
            }

            shouldBeFalse.Add((-1).ValidHours());
            shouldBeFalse.Add(24.ValidHours());
            shouldBeFalse.Add(1337.ValidHours());

            foreach (var test in shouldBeTrue)
            {
                Assert.IsTrue(test);
            }

            foreach (var test in shouldBeFalse)
            {
                Assert.IsFalse(test);
            }
        }

        [TestMethod]
        public void ToHumanFriendlyTimeTest()
        {
            for (int hour = 0; hour < 24; hour++)
            {
                for (int minute = 0; minute < 60; minute++)
                {
                    var result = new DateTime(1, 1, 1, hour, minute, 0).ToHumanFriendlyTime();

                    if (minute == 0)
                    {
                        Assert.IsTrue(result.EndsWith("o'clock"));
                    }
                    else if (minute <= 30)
                    {
                        if (hour == 0)
                        {
                            Assert.IsTrue(result.Contains("twelve"));
                        }

                        Assert.IsTrue(result.Contains("past"));
                    }
                    else
                    {
                        if (hour == 6)
                        {
                            Assert.IsTrue(result.Contains("seven"));
                        }

                        Assert.IsTrue(result.Contains("to"));
                    }

                    if (hour == minute)
                    {
                        Assert.IsTrue(_sampleResults.Contains(result));
                    }
                }
            }
        }
    }
}
