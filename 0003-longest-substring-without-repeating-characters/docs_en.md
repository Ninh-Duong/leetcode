# Longest Substring Without Repeating Characters — Sliding Window with Last-Seen Index

## Idea

Keep a **window** `[left, right]` that never contains a repeated character. The `right` pointer visits each character. If `s[right]` already appears **inside the window**, jump `left` to just past its previous occurrence. After each step, the window length `right - left + 1` is a candidate answer.

The `last[128]` array stores `last index + 1` for each character; `0` means not seen yet. Storing `+1` avoids initializing the array to `-1`.

Brute force over every substring costs `O(n²)` or `O(n³)`, too slow for `n = 5·10⁴`. The sliding window scans once.

### Why `Math.Max(left, ...)` is needed

`left` **must never move backward**. A character's previous occurrence may lie outside the current window, where it no longer causes a repeat. Example `"abba"`:

| right | char | last[char] | left without Max | correct left | window |
|---|---|---|---|---|---|
| 0 | a | 0 | 0 | 0 | `a` |
| 1 | b | 0 | 0 | 0 | `ab` |
| 2 | b | 2 | 2 | 2 | `b` |
| 3 | a | 1 | **1** ❌ (`bba` repeats) | **2** | `ba` |

### Hand trace of `"abcabcbb"`

| right | char | left | window | length | best |
|---|---|---|---|---|---|
| 0 | a | 0 | `a` | 1 | 1 |
| 1 | b | 0 | `ab` | 2 | 2 |
| 2 | c | 0 | `abc` | 3 | 3 |
| 3 | a | 1 | `bca` | 3 | 3 |
| 4 | b | 2 | `cab` | 3 | 3 |
| 5 | c | 3 | `abc` | 3 | 3 |
| 6 | b | 5 | `cb` | 2 | 3 |
| 7 | b | 7 | `b` | 1 | 3 |

### Substring versus subsequence

A substring must be **contiguous**; a subsequence only keeps order. In `"pwwkew"`, `"pwke"` is a subsequence and therefore invalid. The window approach works because the answer must be contiguous.

## Reusable pattern

Variable-size sliding window for the longest contiguous range satisfying a condition:

1. Grow the window by advancing `right`.
2. If the window breaks the condition, shrink it by advancing `left`. Here `left` can jump directly because the previous position is known.
3. Update the answer while the window is valid.
4. `left` and `right` only move forward, so total time is `O(n)`.

The same frame solves: longest substring with at most `k` distinct characters, shortest subarray with sum ≥ `target`, and finding anagrams in a string.

## Suitable use cases

- **Detecting runs of distinct events**: the longest stretch of a user viewing different products in a row, or the longest playlist run without repeats.
- **Windowed rate limiting and monitoring**: counting requests in the last `N` seconds or spotting unusual frequency in logs.
- **Genome or other sequential data analysis**: finding contiguous ranges that satisfy character constraints.
- **Checking passwords or generated codes**: detecting repeated character runs.
- **LZ77-style compression**: using a sliding window over already-read data to find repeated segments.

## Limitations and complexity

- Time: `O(n)`; each character is visited once.
- Space: `O(1)` because the array has a fixed size of 128 (or `O(k)` for `k` distinct characters).
- The 128-entry array is correct only for ASCII, as the problem's constraints guarantee. For arbitrary Unicode, use `Dictionary<char, int>`; for emoji or combined characters (surrogate pairs), iterate by `Rune` or text element instead of `char`.
- Sliding window applies only when the answer is a **contiguous range** and the condition is monotonic: shrinking a valid window keeps it valid. Problems on non-contiguous subsequences usually need dynamic programming.

## Search keywords

`sliding window`, `two pointers`, `last seen index`, `longest substring`, `no repeating characters`, `distinct characters`, `substring vs subsequence`, `variable-size window`
