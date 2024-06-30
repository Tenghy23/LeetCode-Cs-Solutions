public class Solution
{
    private sealed class LogStringComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return 1;
            }

            if (y == null)
            {
                return -1;
            }
            var xSpan = x.AsSpan();
            var ySpan = y.AsSpan();

            var xSpaceIndex = xSpan.IndexOf(' ');
            var ySpaceIndex = ySpan.IndexOf(' ');

            var xValue = xSpan.Slice(xSpaceIndex + 1);
            var yValue = ySpan.Slice(ySpaceIndex + 1);

            int compareOrdinal = xValue.CompareTo(yValue, StringComparison.Ordinal);
            if (compareOrdinal == 0)
            {
                var xId = xSpan.Slice(0, xSpaceIndex);
                var yId = ySpan.Slice(0, ySpaceIndex);
                compareOrdinal = xId.CompareTo(yId, StringComparison.Ordinal);
            }

            return compareOrdinal;
        }
    }

    public string[] ReorderLogFiles(string[] logs)
    {
        string[] result = new string[logs.Length];
        List<byte> digitsIndexes = new();

        byte currentPointer = 0;
        for (byte index = 0; index < logs.Length; index++)
        {
            var log = logs[index];
            var spaceIndex = log.IndexOf(' ');
            if (char.IsDigit(log[spaceIndex + 1]))
            {
                digitsIndexes.Add(index);
            }
            else
            {
                result[currentPointer++] = log;
            }
        }

        Array.Sort(result, new LogStringComparer());

        foreach (var digitsIndex in digitsIndexes)
        {
            result[currentPointer++] = logs[digitsIndex];
        }

        return result;
    }
}