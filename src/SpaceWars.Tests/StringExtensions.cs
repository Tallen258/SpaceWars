using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars.Tests;

public static class StringExtensions
{
    public static bool IsNotNullOrWhitespace(this string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }
}
