using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NumberFormat
{
    Time, Value
}

public static class NumberFormatter
{
    public static string Format(double number, NumberFormat numberFormat = NumberFormat.Time, bool completeString = false, bool mmssFormat = false, float customFontSize = 0)
    {
        switch (numberFormat)
        {
            case NumberFormat.Time:
                return FormatTime(number, completeString, mmssFormat);
            case NumberFormat.Value:
                return FormatValue((int)number, completeString, customFontSize);
            default:
                return number.ToString();
        }

    }

    static string FormatTime(double number, bool completeString = false, bool mmssFormat = false)
    {
        long secondsLeft = (long)Math.Ceiling(number);
        string res = "";
        long days = 0L;
        
        if (secondsLeft > 86400)
        {
            days = secondsLeft / 86400;
            secondsLeft -= days * 86400;
        }
        long hours = secondsLeft / 3600;
        secondsLeft -= hours * 3600;
        long minutes = secondsLeft / 60;
        secondsLeft -= minutes * 60;
        if (mmssFormat)
        {
            res += $"{minutes.ToString("D2")}:{secondsLeft.ToString("D2")}";
        }
        else
        {
            if (days > 0)
                res += completeString ? $"{days} days " : $"{days}d ";
            if (hours > 0)
                res += completeString ? $"{hours} hours " : $"{hours}h ";
            if (minutes > 0)
                res += completeString ? $"{minutes} minutes " : $"{minutes}m ";
            if (secondsLeft > 0)
                res += completeString ? $"{secondsLeft} seconds" : $"{secondsLeft}s";
        }
        return res.Trim();
    }

    static string FormatValue(long value, bool completeString = false, float customFontSize = 0)
    {
        if (value < 1000)
            return value.ToString();

        string stringValue = value.ToString();
        int stringLength = stringValue.Length;

        string shortValue = "";
        string suffix = "";

        if (value >= 1000000000000)
            suffix = completeString ? "Trillion" : "T";
        else if (value >= 1000000000)
            suffix = completeString ? "Billion" : "B";
        else if (value >= 1000000)
            suffix = completeString ? "Million" : "M";
        else if (value >= 1000)
            suffix = completeString ? "Thousand" : "K";

        if (customFontSize != 0)
            suffix = String.Format("<size={0}>" + suffix + "</size>", customFontSize);

        if ((stringLength - 1) % 3 == 0)
        {
            if (stringValue[1] == '0' && stringValue[2] == '0')
                shortValue = stringValue.Substring(0, 1);
            else if (stringValue[1] != '0' && stringValue[2] == '0')
            {
                shortValue = stringValue.Substring(0, 2);
                shortValue = shortValue.Insert(1, ".");
            }
            else
            {
                shortValue = stringValue.Substring(0, 3);
                shortValue = shortValue.Insert(1, ".");
            }
        }
        else if ((stringLength - 2) % 3 == 0)
        {
            if (stringValue[2] == '0')
                shortValue = stringValue.Substring(0, 2);
            else
            {
                shortValue = stringValue.Substring(0, 3);
                shortValue = shortValue.Insert(2, ".");
            }
        }
        else if ((stringLength - 3) % 3 == 0)
            shortValue = stringValue.Substring(0, 3);

        return shortValue + suffix;
    }
}