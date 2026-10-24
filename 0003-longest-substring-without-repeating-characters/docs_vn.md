# Longest Substring Without Repeating Characters — Cửa sổ trượt với vị trí xuất hiện gần nhất

## Ý tưởng

Giữ một **cửa sổ** `[left, right]` luôn không có ký tự lặp. Con trỏ `right` duyệt từng ký tự. Nếu ký tự `s[right]` đã xuất hiện **bên trong cửa sổ**, nhảy `left` tới ngay sau lần xuất hiện trước của nó. Sau mỗi bước, độ dài cửa sổ `right - left + 1` là một ứng viên cho đáp án.

Mảng `last[128]` lưu `vị trí xuất hiện gần nhất + 1` của mỗi ký tự; giá trị `0` nghĩa là chưa gặp. Lưu `+1` để không cần khởi tạo mảng bằng `-1`.

Cách vét cạn thử mọi chuỗi con mất `O(n²)` hoặc `O(n³)`, quá chậm với `n = 5·10⁴`. Cửa sổ trượt chỉ duyệt một lượt.

### Vì sao cần `Math.Max(left, ...)`?

`left` **không bao giờ được lùi lại**. Lần xuất hiện trước của một ký tự có thể nằm ngoài cửa sổ hiện tại, khi đó nó không còn gây lặp. Ví dụ `"abba"`:

| right | ký tự | last[ký tự] | left nếu không dùng Max | left đúng | cửa sổ |
|---|---|---|---|---|---|
| 0 | a | 0 | 0 | 0 | `a` |
| 1 | b | 0 | 0 | 0 | `ab` |
| 2 | b | 2 | 2 | 2 | `b` |
| 3 | a | 1 | **1** ❌ (`bba` có lặp) | **2** | `ba` |

### Chạy tay ví dụ `"abcabcbb"`

| right | ký tự | left | cửa sổ | độ dài | best |
|---|---|---|---|---|---|
| 0 | a | 0 | `a` | 1 | 1 |
| 1 | b | 0 | `ab` | 2 | 2 |
| 2 | c | 0 | `abc` | 3 | 3 |
| 3 | a | 1 | `bca` | 3 | 3 |
| 4 | b | 2 | `cab` | 3 | 3 |
| 5 | c | 3 | `abc` | 3 | 3 |
| 6 | b | 5 | `cb` | 2 | 3 |
| 7 | b | 7 | `b` | 1 | 3 |

### Chuỗi con khác dãy con

Chuỗi con (substring) phải **liên tiếp**; dãy con (subsequence) chỉ cần giữ thứ tự. Với `"pwwkew"`, `"pwke"` là dãy con nên không hợp lệ. Vì đáp án phải liên tiếp nên mới dùng được cửa sổ.

## Mẫu có thể tái sử dụng

Cửa sổ trượt có độ dài thay đổi, tìm đoạn liên tiếp dài nhất thỏa điều kiện:

1. Mở rộng cửa sổ bằng cách tăng `right`.
2. Nếu cửa sổ vi phạm điều kiện, thu hẹp bằng cách tăng `left`. Ở bài này có thể nhảy thẳng nhờ biết vị trí xuất hiện trước.
3. Cập nhật đáp án khi cửa sổ hợp lệ.
4. `left` và `right` chỉ tiến, không lùi, nên tổng thời gian là `O(n)`.

Cùng khung này giải các bài: chuỗi con dài nhất có tối đa `k` ký tự khác nhau, mảng con ngắn nhất có tổng ≥ `target`, tìm anagram trong chuỗi.

## Use case phù hợp

- **Phát hiện chuỗi sự kiện không trùng**: khoảng dài nhất người dùng xem các sản phẩm khác nhau liên tiếp, hoặc đoạn playlist dài nhất không lặp bài.
- **Rate limiting và giám sát theo cửa sổ**: đếm request trong `N` giây gần nhất, phát hiện tần suất bất thường trong log.
- **Phân tích chuỗi gen hoặc dữ liệu tuần tự**: tìm đoạn liên tiếp thỏa ràng buộc về ký tự.
- **Kiểm tra mật khẩu hoặc mã sinh ra**: phát hiện đoạn ký tự lặp.
- **Nén dữ liệu kiểu LZ77**: dùng cửa sổ trượt trên dữ liệu đã đọc để tìm đoạn lặp.

## Giới hạn và độ phức tạp

- Thời gian: `O(n)`, mỗi ký tự được duyệt đúng một lần.
- Bộ nhớ: `O(1)` vì mảng có kích thước cố định 128 (hoặc `O(k)` với `k` là số ký tự khác nhau).
- Mảng 128 chỉ đúng với ký tự ASCII như ràng buộc của đề. Với Unicode bất kỳ, dùng `Dictionary<char, int>`; với emoji hoặc ký tự ghép (surrogate pair), cần duyệt theo `Rune` hoặc text element thay vì `char`.
- Cửa sổ trượt chỉ áp dụng khi đáp án là một **đoạn liên tiếp** và điều kiện có tính đơn điệu: thu hẹp một cửa sổ hợp lệ thì vẫn hợp lệ. Bài về dãy con không liên tiếp thường cần quy hoạch động.

## Từ khóa tìm kiếm

`sliding window`, `cửa sổ trượt`, `two pointers`, `hai con trỏ`, `last seen index`, `longest substring`, `chuỗi con dài nhất`, `không lặp ký tự`, `substring vs subsequence`
