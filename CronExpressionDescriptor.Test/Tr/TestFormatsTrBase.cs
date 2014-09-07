using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.Tr
{
    [TestClass]
    public abstract class TestFormatsTrBase : TestFormatBase
    {
        public TestFormatsTrBase(FormatsTypeEnum formatsType)
            : base("tr", formatsType)
        {
        }

        protected override string GetExpectedEveryMinute()
        {
            return "Her dakika";
        }

        protected override string GetExpectedEvery1Minute()
        {
            return "Her dakika";
        }

        protected override string GetExpectedEveryHour()
        {
            return "Her saat";
        }

        protected override string GetExpectedTimeOfDayCertainDaysOfWeek()
        {
            return "Saat |T0|, Pazartesi ile Cuma arasında";
        }

        protected override string GetExpectedEverySecond()
        {
            return "Her saniye";
        }

        protected override string GetExpectedEvery45Seconds()
        {
            return "Her |S0| saniyede bir";
        }

        protected override string GetExpectedEvery5Seconds()
        {
            return "Her |S0| saniyede bir";
        }

        protected override string GetExpectedEvery5Minutes()
        {
            return "Her |M0| dakikada bir";
        }
        
        protected override string GetExpectedEvery10Minutes()
        {
            return "Her |M0| dakikada bir";
        }

        protected override string GetExpectedEvery5MinutesOnTheSecond()
        {
            return "Her |M0| dakikada bir";
        }

        protected override string GetExpectedWeekdaysAtTime()
        {
            return "Saat |T0|, Pazartesi ile Cuma arasında";
        }

        protected override string GetExpectedDailyAtTime()
        {
            return "Saat |T0|";
        }

        protected override string GetExpectedMinuteSpan()
        {
            return "Saat |T0| ve |T1| arasındaki her dakika";
        }

        protected override string GetExpectedOneMonthOnly()
        {
            return "Her dakika, sadece Mart için";
        }

        protected override string GetExpectedTwoMonthsOnly()
        {
            return "Her dakika, sadece Mart ve Haziran için";
        }

        protected override string GetExpectedTwoTimesEachAfternoon()
        {
            return "Saat |T0| ve |T1|";
        }

        protected override string GetExpectedThreeTimesDaily()
        {
            return "Saat |T0|, |T1| ve |T2|";
        }

        protected override string GetExpectedOnceAWeek()
        {
            return "Saat |T0|, sadece Pazartesi günü";
        }

        protected override string GetExpectedDayOfMonth()
        {
            return "Saat |T0|, ayın |D0|. günü";
        }

        protected override string GetExpectedMonthName()
        {
            return "Saat |T0|, sadece Ocak için";
        }

        protected override string GetExpectedDayOfMonthWithQuestionMark()
        {
            return "Saat |T0|, sadece Ocak için";
        }

        protected override string GetExpectedMonthNameRange2()
        {
            return "Saat |T0|, Ocak ile Şubat arasında";
        }

        protected override string GetExpectedMonthNameRange3()
        {
            return "Saat |T0|, Ocak ile Mart arasında";
        }

        protected override string GetExpectedDayOfWeekName()
        {
            return "Saat |T0|, sadece Pazar günü";
        }

        protected override string GetExpectedDayOfWeekRange()
        {
            return "Her |M0| dakikada bir, saat |T0|, Pazartesi ile Cuma arasında";
        }

        protected override string GetExpectedDayOfWeekOnceInMonth()
        {
            return "Her dakika, ayın üçüncü Pazartesi günü";
        }

        protected override string GetExpectedLastDayOfTheWeekOfTheMonth()
        {
            return "Her dakika, ayın son Perşembe günü";
        }

        protected override string GetExpectedLastDayOfTheMonth()
        {
            return "Her |M0| dakikada bir, ayın son günü, sadece Ocak için";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth()
        {
            return "Her dakika, ayın son iş günü";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth2()
        {
            return "Her dakika, ayın son iş günü";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth()
        {
            return "Her dakika, ayın ilk iş günü";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth2()
        {
            return "Her dakika, ayın ilk iş günü";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth()
        {
            return "Her dakika, ayın |D0|. günü sonrasındaki ilk iş günü";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth2()
        {
            return "Her dakika, ayın |D0|. günü sonrasındaki ilk iş günü";
        }

        protected override string GetExpectedTimeOfDayWithSeconds()
        {
            return "Saat |T0|";
        }

        protected override string GetExpectedSecondIntervals()
        {
            return "Dakikaların |S0|. ve |S1|. saniyeleri arası";
        }

        protected override string GetExpectedSecondMinutesHoursIntervals()
        {
            return "Dakikaların |S0|. ve |S1|. saniyeleri arası, saatlerin |M0|. ve |M1|. dakikaları arası, |T0| ile |T1| arasında";
        }

        protected override string GetExpectedEvery5MinutesAt30Seconds()
        {
            return "Dakikaların |S0|. saniyesinde, her |M0| dakikada bir";
        }

        protected override string GetExpectedMinutesPastTheHourRange()
        {
            return "Saatlerin |M0|. dakikasında, |T0| ile |T1| arasında, sadece Çarşamba ve Cuma günü";
        }

        protected override string GetExpectedSecondsPastTheMinuteInterval()
        {
            return "Dakikaların |S0|. saniyesinde, her |M0| dakikada bir";
        }

        protected override string GetExpectedBetweenWithInterval()
        {
            return "Her |M0| dakikada bir, saatlerin |M1|. ve |M2|. dakikaları arası, saat |T0|, |T1|, ve |T2|, ayın |D0|. ve |D1|. günleri arası, Ocak ile Haziran arasında";
        }

        protected override string GetExpectedRecurringFirstOfMonth()
        {
            return "Saat |T0|";
        }

        protected override string GetExpectedMinutesPastTheHour()
        {
            return "Saatlerin |M0|. dakikasında";
        }

        protected override string GetExpectedOneYearOnlyWithSeconds()
        {
            return "Her saniye, sadece |Y0| için";
        }

        protected override string GetExpectedOneYearOnlyWithoutSeconds()
        {
            return "Her dakika, sadece |Y0| için";
        }

        protected override string GetExpectedTwoYearsOnly()
        {
            return "Her dakika, sadece |Y0| ve |Y1| için";
        }

        protected override string GetExpectedYearRange2()
        {
            return "Saat |T0|, Ocak ile Şubat arasında, |Y0| ile |Y1| arasında";
        }

        protected override string GetExpectedYearRange3()
        {
            return "Saat |T0|, Ocak ile Mart arasında, |Y0| ile |Y1| arasında";
        }

        protected override string GetExpectedHourRange()
        {
            return "Her |M0| dakikada bir, |T0| ile |T1| arasında, ayın |D0| ve |D1|. günü";
        }

        protected override string GetExpectedDayOfWeekModifier()
        {
            return "Saat |T0|, ayın ikinci Pazar günü";
        }

        protected override string GetExpectedDayOfWeekModifierWithSundayStartOne()
        {
            return "Saat |T0|, ayın ikinci Pazar günü";
        }

        protected override string GetExpectedHourRangeWithEveryPortion()
        {
            return null;
        }

        protected override string GetExpectedHourRangeWithTrailingZeroWithEveryPortion()
        {
            return null;
        }
    }
}