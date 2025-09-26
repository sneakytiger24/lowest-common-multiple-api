var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

static long CalculateLCM(long x, long y)
{
    long max = Math.Max(x, y);
    long lcm = max;

    while (true)
    {
        if (lcm % x == 0 && lcm % y == 0)
        {
            return lcm;
        }
        lcm += max;
    }
}

static bool IsNaturalNumber(int number)
{
    return number >= 0;
}

app.MapGet("/yernur_sabyrzhanov_gmail_com", (string? x, string? y) =>
{
    int ExtractNumber(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return -1;
        value = value.Trim();
        if (value.StartsWith("{") && value.EndsWith("}"))
        {
            value = value.Substring(1, value.Length - 2);
        }
        return int.TryParse(value, out int result) ? result : -1;
    }

    int xVal = ExtractNumber(x);
    int yVal = ExtractNumber(y);

    if (!IsNaturalNumber(xVal) || !IsNaturalNumber(yVal))
    {
        return "NaN";
    }

    if (xVal == 0 || yVal == 0)
    {
        return "0";
    }

    try
    {
        long lcm = CalculateLCM(xVal, yVal);
        return lcm.ToString();
    }
    catch
    {
        return "NaN";
    }
});

app.Run();
