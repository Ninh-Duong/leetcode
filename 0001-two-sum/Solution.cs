using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var seen = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) {
            int diff = target - nums[i];
            if (seen.TryGetValue(diff, out int index)) {
                return [index, i];
            }
            seen[nums[i]] = i;
        }
        return [];
    }
}
