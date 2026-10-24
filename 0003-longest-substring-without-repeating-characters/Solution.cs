using System;

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        // last[c] = (last index of c) + 1; 0 means not seen yet. ASCII covers the problem's charset.
        var last = new int[128];
        int best = 0, left = 0;
        for (int right = 0; right < s.Length; right++) {
            left = Math.Max(left, last[s[right]]);
            best = Math.Max(best, right - left + 1);
            last[s[right]] = right + 1;
        }
        return best;
    }
}
