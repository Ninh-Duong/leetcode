# Two Sum — Complement Lookup with a Hash Map

## Idea

For each value `x`, look for `target - x`. Store previously seen values and their indices in a `Dictionary`; when the complement is present, its index and the current index form the answer. Look up the complement before storing the current value so one element cannot be used twice.

## Reusable pattern

For each item in a single pass:

1. Compute the value still needed to satisfy the condition.
2. Look up that value in a hash map of previously seen items.
3. If found, return or process the matching pair.
4. Otherwise, store the current item so a later item can match it.

## Suitable use cases

- Finding two payments whose sum matches a reconciliation target.
- Pairing records with complementary numeric values that reach a target sum.
- Finding a pair in a stream when the input is unsorted and should be scanned once.

## Limitations and complexity

- Average time: `O(n)`; hash-map lookup is average `O(1)` per item.
- Space: `O(n)` in the worst case.
- The original problem guarantees exactly one solution. For use beyond those constraints, define what happens when no pair exists; this method currently returns an empty array.
- With `int` values outside the problem's bounds, `target - nums[i]` can overflow; a generalized version may need `long`.
- If the data is already sorted and original indices are not needed, a two-pointer approach can reduce auxiliary space to `O(1)`. Sorting may lose the original order or indices.

## Search keywords

`hash map`, `Dictionary`, `complement lookup`, `one-pass`, `pair sum`, `target sum pair`
