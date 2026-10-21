# Two Sum — Tra cứu phần bù bằng hash map

## Ý tưởng

Khi duyệt từng giá trị `x`, cần tìm `target - x`. Lưu các giá trị đã gặp cùng chỉ số của chúng trong `Dictionary`; nếu phần bù đã có trong dictionary thì tìm được cặp chỉ số. Tra cứu trước khi lưu giá trị hiện tại để một phần tử không bị dùng hai lần.

## Mẫu có thể tái sử dụng

Với mỗi phần tử trong một lượt duyệt:

1. Tính giá trị còn thiếu để hoàn thành điều kiện.
2. Tra giá trị còn thiếu trong hash map của các phần tử đã thấy.
3. Nếu tìm thấy, trả về hoặc xử lý cặp tương ứng.
4. Nếu chưa, lưu phần tử hiện tại để các phần tử sau có thể ghép với nó.

## Use case phù hợp

- Tìm hai khoản tiền có tổng bằng một ngưỡng cần đối soát.
- Ghép hai bản ghi có giá trị số bổ sung cho nhau để đạt một tổng mục tiêu.
- Tìm một cặp trong luồng dữ liệu khi cần duyệt một lượt và dữ liệu chưa được sắp xếp.

## Giới hạn và độ phức tạp

- Thời gian trung bình: `O(n)`; tra cứu hash map trung bình `O(1)` cho mỗi phần tử.
- Bộ nhớ: `O(n)` trong trường hợp xấu nhất.
- Bài gốc bảo đảm có đúng một lời giải. Nếu dùng ngoài ràng buộc đó, cần quy định rõ hành vi khi không tìm được cặp; hàm hiện trả về mảng rỗng.
- Với dữ liệu `int` vượt ngoài giới hạn của đề, phép tính `target - nums[i]` có thể tràn số; bài toán tổng quát có thể cần dùng `long`.
- Nếu dữ liệu đã sắp xếp và không cần giữ chỉ số ban đầu, hai con trỏ có thể giảm bộ nhớ phụ xuống `O(1)`. Việc sắp xếp có thể làm mất thứ tự hoặc chỉ số gốc.

## Từ khóa tìm kiếm

`hash map`, `Dictionary`, `complement lookup`, `one-pass`, `pair sum`, `tìm cặp tổng mục tiêu`
