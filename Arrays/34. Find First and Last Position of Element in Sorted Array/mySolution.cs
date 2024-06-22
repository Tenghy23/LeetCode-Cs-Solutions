public class Solution {
    public int[] SearchRange(int[] nums, int target) 
    {
        var found = new List<int>();
        var numsList = nums.ToList();
        foreach(var item in numsList.Select((value, i) => new { i, value })) 
        {
            if (item.value == target) found.Add(item.i);
        }
        if (found.Count() == 0) return new int[] { -1, -1 };
        return new int[] {found[0], found.Last()};
    }
}