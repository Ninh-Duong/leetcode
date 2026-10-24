# Add Two Numbers — Digit-by-Digit Addition with Carry on Linked Lists

## Idea

The digits are stored in reverse order, so the first node is the ones place, which matches the right-to-left order of addition by hand. Walk both lists together; at each step, `sum = carry + a + b`, write `sum % 10` to a new node, and keep `carry = sum / 10` for the next step. When one list ends, treat its digit as `0`. The loop continues while `carry` is nonzero so the final carry is not lost, as in `5 + 5 = 10`. A `dummy` head node avoids special-casing the first node.

Do not convert the lists to `int` or `long` and add them: a list may have up to 100 digits, far beyond those types' limits.

### Why reverse order makes the problem easy

The solution does not reverse anything; the problem already gives the digits in reverse order. That order helps because two constraints line up:

1. **Addition must go from the ones place upward**, because the carry flows only from lower places to higher places. You cannot compute the hundreds place before knowing whether the tens place carries.
2. **A singly linked list only moves forward** through `next` and cannot step back.

| Storing 342 | List | Head node is | Can add immediately? |
|---|---|---|---|
| Reversed (this problem) | `2 → 4 → 3` | ones place | Yes, add while walking |
| Forward (LeetCode 445) | `3 → 4 → 2` | hundreds place | No, the last node must be processed first, but the list cannot move backward |

```
l1:  2 → 4 → 3      (ones → tens → hundreds)
l2:  5 → 6 → 4
     ↓   ↓   ↓
     7   0   8      carry: 0 → 1 → 0
```

If digits are stored most significant first, bring the ones place to the front in one of two ways: reverse the lists, add as in this problem, then reverse the result; or push the digits onto stacks so they come out in reverse order.

Big-integer libraries such as `BigInteger` also usually store numbers **little-endian**, with the low part first, because addition and multiplication both start from the low part. When a carry makes the number longer, the new digit is appended at the end without shifting the existing elements.

## Reusable pattern

Add two digit sequences with a carry:

1. Start at the least significant digit with `carry = 0`.
2. At each step, add the current digit from each side (`0` if that side has ended) plus `carry`.
3. Write `sum % base` to the result and set `carry = sum / base`.
4. Stop when both sequences have ended and `carry == 0`.

The `dummy` head technique applies to any problem that builds a linked list incrementally.

## Suitable use cases

- Implementing big integers, as libraries such as `System.Numerics.BigInteger` add "limbs" in base `2^32`.
- Adding money or measurements of arbitrary precision stored as digit arrays when rounding is not allowed.
- Cryptographic operations such as RSA, which work on integers thousands of bits long.
- Multi-place counters such as clocks (seconds rolling into minutes), odometers, or version-number increments.
- Checksums and binary addition (`base = 2`), such as simulating a hardware adder.

## Limitations and complexity

- Time: `O(max(m, n))`, where `m` and `n` are the list lengths.
- Space: `O(max(m, n))` for the result list; auxiliary space beyond the result is `O(1)`.
- The solution relies on digits being stored in reverse order. If they are stored most significant first (LeetCode 445), reverse the lists or use stacks before adding.
- Handles only non-negative numbers; subtraction or negative values need borrow logic and sign handling.
- In production, prefer the standard library's `BigInteger` over a custom implementation. One node per digit is also memory-heavy; real libraries pack many digits into each array element.

## Search keywords

`linked list`, `carry`, `big integer`, `arbitrary precision`, `dummy head`, `elementary addition`, `digit-by-digit`, `add numbers as lists`
