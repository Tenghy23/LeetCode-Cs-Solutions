public class Solution {
    public int[] SearchRange(int[] nums, int target) {
       int left = binarySearch(nums, target, true);
       int right = binarySearch(nums, target, false);

        if (left <= right && left != -1 && right != -1){
        return new int[] {left, right};
       }else {
        return new int[] {-1,-1};
       }

    } 

    static int binarySearch(int[] nums, int target, bool findLow){
         int low = 0, high = nums.Length - 1, index = -1;

        while(low<=high){
            int mid = low + (high - low) / 2;
            if(nums[mid] == target){ index = mid;
            if(findLow){
                high = mid - 1;
                } else {
                    low = mid + 1;
                }
                }else if(nums[mid] < target) {
                    low = mid + 1;
                }else{
                    high = mid - 1;
                }
        }
        return index;

    }
}