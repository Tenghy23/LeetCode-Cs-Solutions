public class Solution {
    public string[] ReorderLogFiles(string[] logs)
    {
        var tp = logs.Select(o =>
            (o.Split(' ')[0],
            o.Substring(o.IndexOf(' ') + 1))
            );
        var letSorted = tp.Where(t => t.Item2.All(c => !char.IsDigit(c)));
        var set1 = letSorted.Any() ? letSorted.OrderBy(x => x.Item2).ThenBy(x => x.Item1) : letSorted;

        var set2 = tp.Where(t => t.Item2.Any(c => char.IsDigit(c)));

        var combined = set1.Concat(set2);
        return combined.Select(x => $"{x.Item1} {x.Item2}").ToArray();
    }
}