using System;

namespace PracticeLib;

public class Utils {

    public static DateTime FromTimeStamp(decimal value) => new(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Local).Ticks 
        + (long)Math.Round(value * 1000m * TimeSpan.TicksPerMillisecond), DateTimeKind.Local);

}