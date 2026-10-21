# AI Agent Instructions

## Repository purpose

This repository is a collection of LeetCode solutions in C#, with notes about reusable problem-solving patterns and their real-world applications. Prefer correct, readable, minimal solutions. Avoid frameworks, dependencies, or speculative scaffolding unless requested.

## Problem structure

Keep each problem in its own folder:

```text
<four-digit-problem-number>-<kebab-case-slug>/
├── Solution.cs
├── docs_vn.md
└── docs_en.md
```

Example: `0001-two-sum/`. Keep solutions in LeetCode submission format and preserve the method signature required by the problem.

## Adding or changing a problem

- Read the problem and the relevant files before editing; change only the problem in scope.
- Every new problem folder must contain `Solution.cs`, `docs_vn.md`, and `docs_en.md`.
- The two docs must have matching structure and equivalent content, with these sections:
  1. Idea
  2. Reusable pattern
  3. Suitable use cases
  4. Limitations and complexity
  5. Search keywords
- Document applicability, constraints, complexity, and meaningful trade-offs. Include alternatives only when they help readers choose a solution for a real use case.
- Write docs so an agent can search by concept or use case and evaluate whether a pattern fits. Do not claim an algorithm is universally optimal when that depends on the data or constraints.
- Do not add a central index, project scaffolding, or test infrastructure unless requested.

## Handling future requests

- For a LeetCode solution request, follow the folder convention and update both language docs.
- For a feature request, search existing solutions and docs, explain which pattern may apply and its limitations, then adapt it to the feature. Do not copy a LeetCode solution unchanged when it does not fit.
- Prefer the smallest useful change. Keep code explicit, prefer the standard library, and avoid abstractions for a single use case.
- Do not modify unrelated problems while working on one problem.

## Verification

- The repository currently has no build or test configuration. Do not create build or test infrastructure unasked; state clearly when compilation or tests could not be verified.
- When the user requests verification, use existing tools where appropriate and report exactly what was run.
- Before finishing, check the file structure, consistency between the two docs, and the scope of the changes.
