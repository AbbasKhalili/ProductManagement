using System;

namespace Shared.Core
{
    public interface ISystemClock
    {
        DateTime ReturnNow();
        DateTime ReturnTimeNow();
        DateTime ReturnDate(int year, int mon, int day);
        DateTime ReturnTime(int hour, int min = 0, int sec = 0);
        DateTime ReturnBy(int year, int mon, int day, int hour, int min = 0, int sec = 0);
    }
    public class SystemClock : ISystemClock
    {
        public DateTime ReturnNow()
        {
            return DateTime.Now;
        }

        public DateTime ReturnTimeNow()
        {
            var now = DateTime.Now;
            return new DateTime(1, 1, 1, now.Hour, now.Minute, now.Second);
        }

        public DateTime ReturnDate(int year, int mon, int day)
        {
            return new DateTime(year, mon, day);
        }

        public DateTime ReturnTime(int hour, int min = 0, int sec = 0)
        {
            return new DateTime(1, 1, 1, hour, min, sec);
        }

        public DateTime ReturnBy(int year, int mon, int day, int hour, int min = 0, int sec = 0)
        {
            return new DateTime(year, mon, day, hour, min, sec);
        }
    }
}