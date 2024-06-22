public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int[] res = new int[2];
        List<int> l = nums.ToList<int>();
        res[0] = l.IndexOf(target);
        res[1] = l.LastIndexOf(target);
        return res;
    }
}