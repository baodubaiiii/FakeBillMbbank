🧾 README.md — RenderBill C#
# 🧾 RenderBill C#

Dự án **RenderBill** giúp vẽ phôi hóa đơn (bill) ngân hàng bằng **C# (System.Drawing)**, chuyển đổi hoàn chỉnh từ mã PHP gốc.  
Kết quả render ra hình ảnh giống **100% giao diện hóa đơn thật** (ví dụ MBBank, BDSD, SEPay, v.v.).

---

## 📦 Tính năng

- ✅ Vẽ phôi từ ảnh nền (`phoi/bill/mb.jpg`, `phoi/mb-bdsd.jpg`)
- ✅ Chèn các icon (ngân hàng, tín hiệu, pin, Dynamics Island)
- ✅ Căn chỉnh chữ **chuẩn pixel** với hàm `canchinhphai` (chuẩn y PHP `imagettftext`)
- ✅ Hỗ trợ font `.ttf` tuỳ chỉnh (Unicode đầy đủ)
- ✅ Giữ đúng kích thước và vị trí như bản gốc PHP `imagecopyresampled`
- ✅ Xuất ra ảnh `.png` hoặc `.jpg` cực nét

---

## 🏗 Cấu trúc dự án



RenderBill/
├── phoi/
│ ├── bill/
│ │ ├── mb.jpg
│ │ └── mb-bdsd.jpg
├── icon/
│ ├── bank/
│ │ └── mbbank.png
│ ├── network/
│ │ └── dark/
│ │ └── 4g.png
│ ├── pin/
│ │ └── dark/
│ │ └── 93.png
│ └── dynamics2.png
├── fonts/
│ └── Roboto-Regular.ttf
└── RenderBill.cs


---

## 🧠 Cách hoạt động

Chương trình đọc ảnh phôi + icon, sau đó vẽ đè các phần tử như sau:

- `DrawDynamicsIsland()` → Vẽ phần **Dynamic Island** trên cùng  
- `DrawTinHieu()` → Vẽ biểu tượng **4G / WiFi / sóng**  
- `DrawPin()` → Vẽ biểu tượng **pin**  
- `canchinhphai()` → Ghi text căn phải giống PHP `imagettftext`  
- `Render()` → Hàm chính xử lý toàn bộ

---

## 🚀 Cách chạy

### 1️⃣ Chuẩn bị
- Cài .NET 6.0 hoặc mới hơn
- Tạo folder chứa đầy đủ ảnh phôi, icon và font như cấu trúc trên

### 2️⃣ Build và chạy
```bash
dotnet run


Hoặc biên dịch bằng Visual Studio / Rider, chạy hàm:

RenderBill.Render();

### 3️⃣ Kết quả

Ảnh đầu ra được lưu tại:

output_bill.png

💡 Ví dụ sử dụng
RenderBill.Render(
    "macdinh",               // kiểu chuyển: macdinh hoặc bdsd
    "mbbank",                // ngân hàng nhận
    "Nguyễn Văn A",          // tên người nhận
    "100,000,000",           // số tiền
    "26/10/2025 14:33"       // thời gian
);

📚 Các hàm chính
Hàm	Mô tả
Render()	Hàm chính để render toàn bộ bill
canchinhphai()	Căn phải text chuẩn pixel
DrawDynamicsIsland()	Vẽ phần Dynamic Island
DrawTinHieu()	Vẽ biểu tượng 4G/WiFi
DrawPin()	Vẽ pin góc phải
DrawBankIcon()	Vẽ logo ngân hàng
🖼 Ảnh minh họa
Bill MBBank	Bill BDSD

	
### 🧑‍💻 Tác giả

DuBai Bảo
Chuyển đổi & tối ưu từ bản gốc PHP → C#
Dành cho mục đích nghiên cứu, học tập, hoặc dựng demo UI ngân hàng.

### ⚖️ Giấy phép

MIT License — sử dụng tự do, giữ nguyên credit tác giả.