# Add Two Numbers — Cộng từng chữ số có nhớ trên danh sách liên kết

## Ý tưởng

Các chữ số được lưu theo thứ tự ngược, nên node đầu tiên là hàng đơn vị, đúng với thứ tự cộng tay từ phải sang trái. Duyệt song song hai danh sách; ở mỗi bước, `sum = carry + a + b`, ghi `sum % 10` vào node mới và giữ `carry = sum / 10` cho bước sau. Danh sách nào hết thì coi chữ số của nó là `0`. Vòng lặp chạy tiếp khi `carry` còn khác `0` để không mất số nhớ cuối, ví dụ `5 + 5 = 10`. Node giả `dummy` giúp không phải xử lý riêng node đầu tiên.

Không nên đổi danh sách sang `int` hoặc `long` rồi cộng: danh sách có thể dài tới 100 chữ số, vượt xa giới hạn của các kiểu số nguyên đó.

### Vì sao thứ tự ngược giúp bài toán dễ?

Lời giải không đảo danh sách; đề đã cho sẵn chữ số theo thứ tự ngược. Thứ tự này có lợi vì hai điều kiện sau trùng nhau:

1. **Phép cộng phải đi từ hàng đơn vị lên**, vì số nhớ chỉ truyền từ hàng thấp sang hàng cao. Không thể tính hàng trăm khi chưa biết hàng chục có nhớ hay không.
2. **Danh sách liên kết đơn chỉ đi một chiều** theo `next`, không lùi lại được.

| Cách lưu số 342 | Danh sách | Node đầu là | Cộng được ngay? |
|---|---|---|---|
| Ngược (bài này) | `2 → 4 → 3` | hàng đơn vị | Có, vừa duyệt vừa cộng |
| Xuôi (LeetCode 445) | `3 → 4 → 2` | hàng trăm | Không, phải xử lý được node cuối trước nhưng không lùi lại được |

```
l1:  2 → 4 → 3      (đơn vị → chục → trăm)
l2:  5 → 6 → 4
     ↓   ↓   ↓
     7   0   8      nhớ: 0 → 1 → 0
```

Nếu số được lưu xuôi, cần đưa hàng đơn vị lên trước bằng một trong hai cách: đảo danh sách, cộng như bài này rồi đảo kết quả; hoặc đẩy chữ số vào stack để lấy ra theo thứ tự ngược.

Các thư viện số lớn như `BigInteger` cũng thường lưu theo kiểu **little-endian**, tức phần thấp đứng trước, vì cộng và nhân đều bắt đầu từ phần thấp. Khi số nhớ làm số dài thêm, chỉ cần nối thêm vào cuối mà không phải dời các phần tử.

## Mẫu có thể tái sử dụng

Cộng hai dãy chữ số với số nhớ:

1. Bắt đầu từ chữ số có trọng số thấp nhất với `carry = 0`.
2. Ở mỗi bước, cộng chữ số hiện tại của hai bên (bên nào hết thì dùng `0`) với `carry`.
3. Ghi `sum % base` vào kết quả và đặt `carry = sum / base`.
4. Dừng khi cả hai dãy đã hết và `carry == 0`.

Kỹ thuật `dummy` head có thể dùng cho mọi bài cần dựng dần một danh sách liên kết.

## Use case phù hợp

- Tự cài đặt số nguyên lớn (big integer), như cách các thư viện kiểu `System.Numerics.BigInteger` cộng các "limb" theo hệ cơ số `2^32`.
- Cộng số tiền hoặc số đo có độ chính xác tùy ý, lưu dưới dạng mảng chữ số, khi không được làm tròn.
- Các phép toán mật mã như RSA, vốn tính trên số nguyên hàng nghìn bit.
- Bộ đếm nhiều hàng như đồng hồ (giây tràn sang phút), đồng hồ đo công tơ, hoặc tăng số phiên bản.
- Mã kiểm tra và phép cộng nhị phân (`base = 2`), chẳng hạn mô phỏng bộ cộng trong phần cứng.

## Giới hạn và độ phức tạp

- Thời gian: `O(max(m, n))`, với `m`, `n` là độ dài hai danh sách.
- Bộ nhớ: `O(max(m, n))` cho danh sách kết quả; bộ nhớ phụ ngoài kết quả là `O(1)`.
- Lời giải phụ thuộc vào việc chữ số được lưu theo thứ tự ngược. Nếu lưu theo thứ tự xuôi (LeetCode 445), cần đảo danh sách hoặc dùng stack trước khi cộng.
- Chỉ xử lý số không âm; phép trừ hoặc số âm cần logic mượn (borrow) và quản lý dấu.
- Trong thực tế, nên dùng `BigInteger` có sẵn trong thư viện chuẩn thay vì tự cài. Một node cho mỗi chữ số cũng tốn bộ nhớ; thư viện thực tế lưu nhiều chữ số trong một phần tử mảng.

## Từ khóa tìm kiếm

`linked list`, `carry`, `số nhớ`, `big integer`, `cộng số lớn`, `arbitrary precision`, `dummy head`, `elementary addition`, `digit-by-digit`
