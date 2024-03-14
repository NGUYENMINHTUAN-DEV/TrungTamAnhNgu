USE [ANHNGU]
GO
/****** Object:  Table [dbo].[ChiTietPhieuThu]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuThu](
	[MaPhieuThu] [char](10) NOT NULL,
	[MaKhoaHoc] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuThu] ASC,
	[MaKhoaHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DangKyKhoaHoc]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangKyKhoaHoc](
	[MaDangKy] [char](10) NOT NULL,
	[MaHocVien] [char](10) NULL,
	[NgayDangKy] [date] NULL,
	[DaThanhToan] [bit] NULL,
	[HinhThucThanhToan] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDangKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DangKyKhoaHoc_KhoaHoc]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangKyKhoaHoc_KhoaHoc](
	[MaDangKy] [char](10) NOT NULL,
	[MaKhoaHoc] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDangKy] ASC,
	[MaKhoaHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiemDanh]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemDanh](
	[IDDiemDanh] [char](10) NOT NULL,
	[MaHocVien] [char](10) NULL,
	[MaLopHoc] [char](10) NULL,
	[NgayDiemDanh] [date] NULL,
	[TrangThaiDiemDanh] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDDiemDanh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiemThi]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemThi](
	[MaHocVien] [char](10) NOT NULL,
	[MaToChucThi] [char](10) NOT NULL,
	[Diem] [real] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHocVien] ASC,
	[MaToChucThi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiangVien]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiangVien](
	[MaGiangVien] [char](10) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](277) NULL,
	[SoDienThoai] [nvarchar](17) NULL,
	[Email] [nvarchar](277) NULL,
	[MaTaiKhoan] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGiangVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocVien]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocVien](
	[MaHocVien] [char](10) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](277) NULL,
	[SoDienThoai] [nvarchar](17) NULL,
	[Email] [nvarchar](277) NULL,
	[MaTaiKhoan] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHocVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoaHoc]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoaHoc](
	[MaKhoaHoc] [char](10) NOT NULL,
	[TenKhoaHoc] [nvarchar](100) NULL,
	[MoTa] [nvarchar](277) NULL,
	[HocPhi] [float] NULL,
	[ThoiGianBatDau] [date] NULL,
	[ThoiGianKetThuc] [date] NULL,
	[SoLuongHocVien] [int] NULL,
	[DiaDiemHoc] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhoaHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopHoc]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHoc](
	[MaLopHoc] [char](10) NOT NULL,
	[TenLop] [nvarchar](100) NULL,
	[MaKhoaHoc] [char](10) NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[SoLuongHocVienHienTai] [int] NULL,
	[SoLuongHocVienToiDa] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLopHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [char](10) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](277) NULL,
	[SoDienThoai] [nvarchar](17) NULL,
	[Email] [nvarchar](277) NULL,
	[MaTaiKhoan] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhatTaiLieu]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhatTaiLieu](
	[IDPhatTaiLieu] [char](10) NOT NULL,
	[MaHocVien] [char](10) NULL,
	[MaTaiLieu] [char](10) NULL,
	[NgayPhatTaiLieu] [datetime] NULL,
	[SoLuongPhat] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPhatTaiLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuThu]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuThu](
	[MaPhieuThu] [char](10) NOT NULL,
	[MaHocVien] [char](10) NULL,
	[NgayLap] [date] NULL,
	[TongTien] [float] NULL,
	[MaNhanVien] [char](10) NULL,
	[TrangThai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongHoc]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongHoc](
	[MaPhongHoc] [char](10) NOT NULL,
	[TenPhongHoc] [nvarchar](100) NULL,
	[SoLuongToiDa] [int] NULL,
	[SoLuongDaDangKy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhongHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuyenTruyCap]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuyenTruyCap](
	[MaQuyenTruyCap] [char](10) NOT NULL,
	[TenQuyenTruyCap] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQuyenTruyCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTaiKhoan] [char](10) NOT NULL,
	[TenDangNhap] [nvarchar](70) NULL,
	[MatKhau] [nvarchar](277) NULL,
	[MaQuyenTruyCap] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiLieu]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiLieu](
	[MaTaiLieu] [char](10) NOT NULL,
	[TenTaiLieu] [nvarchar](100) NULL,
	[MaKhoaHoc] [char](10) NULL,
	[SoLuongTaiLieu] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTaiLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThoiKhoaBieu]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThoiKhoaBieu](
	[IDThoiKhoaBieu] [char](10) NOT NULL,
	[MaGiangVien] [char](10) NULL,
	[MaPhongHoc] [char](10) NULL,
	[MaLopHoc] [char](10) NULL,
	[Thu] [int] NULL,
	[TietBatDau] [int] NULL,
	[TietKetThuc] [int] NULL,
	[DiaDiem] [nvarchar](100) NULL,
	[CaHoc] [nvarchar](10) NULL,
	[NgayHoc] [date] NULL,
	[LoaiLich] [nvarchar](20) NULL,
	[NgayThi] [date] NULL,
	[MaToChucThi] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDThoiKhoaBieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ToChucThi]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToChucThi](
	[MaToChucThi] [char](10) NOT NULL,
	[TenToChucThi] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaToChucThi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ToChucThi_LOP]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToChucThi_LOP](
	[MaToChucThi] [char](10) NOT NULL,
	[MaLopHoc] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaToChucThi] ASC,
	[MaLopHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XepLopHocVien]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XepLopHocVien](
	[IDXepLop] [char](10) NOT NULL,
	[MaLopHoc] [char](10) NULL,
	[MaHocVien] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDXepLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietPhieuThu] ([MaPhieuThu], [MaKhoaHoc]) VALUES (N'PT001     ', N'KH001     ')
INSERT [dbo].[ChiTietPhieuThu] ([MaPhieuThu], [MaKhoaHoc]) VALUES (N'PT001     ', N'KH002     ')
INSERT [dbo].[ChiTietPhieuThu] ([MaPhieuThu], [MaKhoaHoc]) VALUES (N'PT003     ', N'KH002     ')
INSERT [dbo].[ChiTietPhieuThu] ([MaPhieuThu], [MaKhoaHoc]) VALUES (N'PT004     ', N'KH003     ')
INSERT [dbo].[ChiTietPhieuThu] ([MaPhieuThu], [MaKhoaHoc]) VALUES (N'PT005     ', N'KH004     ')
INSERT [dbo].[ChiTietPhieuThu] ([MaPhieuThu], [MaKhoaHoc]) VALUES (N'PT006     ', N'KH005     ')
INSERT [dbo].[ChiTietPhieuThu] ([MaPhieuThu], [MaKhoaHoc]) VALUES (N'PT007     ', N'KH005     ')
INSERT [dbo].[ChiTietPhieuThu] ([MaPhieuThu], [MaKhoaHoc]) VALUES (N'PT008     ', N'KH006     ')
INSERT [dbo].[ChiTietPhieuThu] ([MaPhieuThu], [MaKhoaHoc]) VALUES (N'PT009     ', N'KH007     ')
INSERT [dbo].[ChiTietPhieuThu] ([MaPhieuThu], [MaKhoaHoc]) VALUES (N'PT010     ', N'KH008     ')
GO
INSERT [dbo].[DangKyKhoaHoc] ([MaDangKy], [MaHocVien], [NgayDangKy], [DaThanhToan], [HinhThucThanhToan]) VALUES (N'DK001     ', N'HV001     ', CAST(N'2023-01-16' AS Date), 1, N'Tiền mặt')
INSERT [dbo].[DangKyKhoaHoc] ([MaDangKy], [MaHocVien], [NgayDangKy], [DaThanhToan], [HinhThucThanhToan]) VALUES (N'DK002     ', N'HV002     ', CAST(N'2023-01-17' AS Date), 0, NULL)
INSERT [dbo].[DangKyKhoaHoc] ([MaDangKy], [MaHocVien], [NgayDangKy], [DaThanhToan], [HinhThucThanhToan]) VALUES (N'DK003     ', N'HV003     ', CAST(N'2023-02-02' AS Date), 1, N'Chuyển khoản')
INSERT [dbo].[DangKyKhoaHoc] ([MaDangKy], [MaHocVien], [NgayDangKy], [DaThanhToan], [HinhThucThanhToan]) VALUES (N'DK004     ', N'HV004     ', CAST(N'2023-03-11' AS Date), 0, NULL)
INSERT [dbo].[DangKyKhoaHoc] ([MaDangKy], [MaHocVien], [NgayDangKy], [DaThanhToan], [HinhThucThanhToan]) VALUES (N'DK005     ', N'HV005     ', CAST(N'2023-04-06' AS Date), 1, N'Tiền mặt')
INSERT [dbo].[DangKyKhoaHoc] ([MaDangKy], [MaHocVien], [NgayDangKy], [DaThanhToan], [HinhThucThanhToan]) VALUES (N'DK006     ', N'HV006     ', CAST(N'2023-05-21' AS Date), 0, NULL)
INSERT [dbo].[DangKyKhoaHoc] ([MaDangKy], [MaHocVien], [NgayDangKy], [DaThanhToan], [HinhThucThanhToan]) VALUES (N'DK007     ', N'HV007     ', CAST(N'2023-05-21' AS Date), 1, N'Chuyển khoản')
INSERT [dbo].[DangKyKhoaHoc] ([MaDangKy], [MaHocVien], [NgayDangKy], [DaThanhToan], [HinhThucThanhToan]) VALUES (N'DK008     ', N'HV008     ', CAST(N'2023-06-16' AS Date), 0, NULL)
INSERT [dbo].[DangKyKhoaHoc] ([MaDangKy], [MaHocVien], [NgayDangKy], [DaThanhToan], [HinhThucThanhToan]) VALUES (N'DK009     ', N'HV009     ', CAST(N'2023-07-02' AS Date), 1, N'Tiền mặt')
INSERT [dbo].[DangKyKhoaHoc] ([MaDangKy], [MaHocVien], [NgayDangKy], [DaThanhToan], [HinhThucThanhToan]) VALUES (N'DK010     ', N'HV010     ', CAST(N'2023-08-11' AS Date), 0, NULL)
GO
INSERT [dbo].[DangKyKhoaHoc_KhoaHoc] ([MaDangKy], [MaKhoaHoc]) VALUES (N'DK001     ', N'KH001     ')
INSERT [dbo].[DangKyKhoaHoc_KhoaHoc] ([MaDangKy], [MaKhoaHoc]) VALUES (N'DK001     ', N'KH002     ')
INSERT [dbo].[DangKyKhoaHoc_KhoaHoc] ([MaDangKy], [MaKhoaHoc]) VALUES (N'DK003     ', N'KH002     ')
INSERT [dbo].[DangKyKhoaHoc_KhoaHoc] ([MaDangKy], [MaKhoaHoc]) VALUES (N'DK004     ', N'KH003     ')
INSERT [dbo].[DangKyKhoaHoc_KhoaHoc] ([MaDangKy], [MaKhoaHoc]) VALUES (N'DK005     ', N'KH004     ')
INSERT [dbo].[DangKyKhoaHoc_KhoaHoc] ([MaDangKy], [MaKhoaHoc]) VALUES (N'DK006     ', N'KH005     ')
INSERT [dbo].[DangKyKhoaHoc_KhoaHoc] ([MaDangKy], [MaKhoaHoc]) VALUES (N'DK007     ', N'KH005     ')
INSERT [dbo].[DangKyKhoaHoc_KhoaHoc] ([MaDangKy], [MaKhoaHoc]) VALUES (N'DK008     ', N'KH006     ')
INSERT [dbo].[DangKyKhoaHoc_KhoaHoc] ([MaDangKy], [MaKhoaHoc]) VALUES (N'DK009     ', N'KH007     ')
INSERT [dbo].[DangKyKhoaHoc_KhoaHoc] ([MaDangKy], [MaKhoaHoc]) VALUES (N'DK010     ', N'KH008     ')
GO
INSERT [dbo].[DiemDanh] ([IDDiemDanh], [MaHocVien], [MaLopHoc], [NgayDiemDanh], [TrangThaiDiemDanh]) VALUES (N'DD001     ', N'HV001     ', N'LH001     ', CAST(N'2023-01-20' AS Date), N'Đã điểm danh')
INSERT [dbo].[DiemDanh] ([IDDiemDanh], [MaHocVien], [MaLopHoc], [NgayDiemDanh], [TrangThaiDiemDanh]) VALUES (N'DD002     ', N'HV002     ', N'LH001     ', CAST(N'2023-01-20' AS Date), N'Vắng')
INSERT [dbo].[DiemDanh] ([IDDiemDanh], [MaHocVien], [MaLopHoc], [NgayDiemDanh], [TrangThaiDiemDanh]) VALUES (N'DD003     ', N'HV003     ', N'LH002     ', CAST(N'2023-02-05' AS Date), N'Vắng')
INSERT [dbo].[DiemDanh] ([IDDiemDanh], [MaHocVien], [MaLopHoc], [NgayDiemDanh], [TrangThaiDiemDanh]) VALUES (N'DD004     ', N'HV004     ', N'LH003     ', CAST(N'2023-03-15' AS Date), N'Đã điểm danh')
INSERT [dbo].[DiemDanh] ([IDDiemDanh], [MaHocVien], [MaLopHoc], [NgayDiemDanh], [TrangThaiDiemDanh]) VALUES (N'DD005     ', N'HV005     ', N'LH004     ', CAST(N'2023-04-10' AS Date), N'Vắng')
INSERT [dbo].[DiemDanh] ([IDDiemDanh], [MaHocVien], [MaLopHoc], [NgayDiemDanh], [TrangThaiDiemDanh]) VALUES (N'DD006     ', N'HV006     ', N'LH005     ', CAST(N'2023-05-25' AS Date), N'Đã điểm danh')
INSERT [dbo].[DiemDanh] ([IDDiemDanh], [MaHocVien], [MaLopHoc], [NgayDiemDanh], [TrangThaiDiemDanh]) VALUES (N'DD007     ', N'HV007     ', N'LH006     ', CAST(N'2023-05-25' AS Date), N'Đã điểm danh')
INSERT [dbo].[DiemDanh] ([IDDiemDanh], [MaHocVien], [MaLopHoc], [NgayDiemDanh], [TrangThaiDiemDanh]) VALUES (N'DD008     ', N'HV008     ', N'LH007     ', CAST(N'2023-06-20' AS Date), N'Vắng')
INSERT [dbo].[DiemDanh] ([IDDiemDanh], [MaHocVien], [MaLopHoc], [NgayDiemDanh], [TrangThaiDiemDanh]) VALUES (N'DD009     ', N'HV009     ', N'LH008     ', CAST(N'2023-07-05' AS Date), N'Đã điểm danh')
INSERT [dbo].[DiemDanh] ([IDDiemDanh], [MaHocVien], [MaLopHoc], [NgayDiemDanh], [TrangThaiDiemDanh]) VALUES (N'DD010     ', N'HV010     ', N'LH009     ', CAST(N'2023-08-15' AS Date), N'Vắng')
GO
INSERT [dbo].[DiemThi] ([MaHocVien], [MaToChucThi], [Diem]) VALUES (N'HV001     ', N'TC01      ', NULL)
INSERT [dbo].[DiemThi] ([MaHocVien], [MaToChucThi], [Diem]) VALUES (N'HV002     ', N'TC01      ', 2)
INSERT [dbo].[DiemThi] ([MaHocVien], [MaToChucThi], [Diem]) VALUES (N'HV003     ', N'TC01      ', 3)
GO
INSERT [dbo].[GiangVien] ([MaGiangVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'GV001     ', N'Nguyễn Thị Hương', CAST(N'1985-03-15' AS Date), N'Nữ', N'123 Đường ABC', N'0123456789', N'huongnt@email.com', N'TK002     ')
INSERT [dbo].[GiangVien] ([MaGiangVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'GV002     ', N'Trần Văn Anh', CAST(N'1980-08-20' AS Date), N'Nam', N'456 Đường XYZ', N'0987654321', N'anhtran@email.com', N'TK003     ')
INSERT [dbo].[GiangVien] ([MaGiangVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'GV003     ', N'Lê Thị Mai', CAST(N'1988-12-10' AS Date), N'Nữ', N'789 Đường XYZ', N'0123456789', N'maile@email.com', N'TK004     ')
INSERT [dbo].[GiangVien] ([MaGiangVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'GV004     ', N'Phạm Văn Tâm', CAST(N'1975-06-25' AS Date), N'Nam', N'321 Đường XYZ', N'0123456789', N'tampham@email.com', N'TK005     ')
INSERT [dbo].[GiangVien] ([MaGiangVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'GV005     ', N'Bùi Thị Hà', CAST(N'1983-05-10' AS Date), N'Nữ', N'654 Đường ABC', N'0987654321', N'habui@email.com', N'TK006     ')
INSERT [dbo].[GiangVien] ([MaGiangVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'GV006     ', N'Mai Văn Hùng', CAST(N'1987-11-20' AS Date), N'Nam', N'987 Đường XYZ', N'0123456789', N'hungmai@email.com', N'TK007     ')
INSERT [dbo].[GiangVien] ([MaGiangVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'GV007     ', N'Nguyễn Thị Lan', CAST(N'1990-04-01' AS Date), N'Nữ', N'159 Đường ABC', N'0987654321', N'lannguyen@email.com', N'TK008     ')
INSERT [dbo].[GiangVien] ([MaGiangVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'GV008     ', N'Lê Văn Đức', CAST(N'1978-09-18' AS Date), N'Nam', N'753 Đường XYZ', N'0123456789', N'ducle@email.com', N'TK009     ')
INSERT [dbo].[GiangVien] ([MaGiangVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'GV009     ', N'Dỗ Thị Hương', CAST(N'1982-02-15' AS Date), N'Nữ', N'246 Đường XYZ', N'0123456789', N'huongdo@email.com', N'TK010     ')
INSERT [dbo].[GiangVien] ([MaGiangVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'GV010     ', N'Trần Văn Hải', CAST(N'1970-12-30' AS Date), N'Nam', N'852 Đường ABC', N'0987654321', N'haitran@email.com', N'TK021     ')
GO
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV001     ', N'Phạm Thị Hương', CAST(N'1995-02-20' AS Date), N'Nữ', N'456 Đường ABC', N'0123456789', N'huongpt@email.com', N'TK011     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV002     ', N'Nguyễn Minh Anh', CAST(N'1998-11-10' AS Date), N'Nam', N'789 Đường XYZ', N'0987654321', N'anhnm@email.com', N'TK012     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV003     ', N'Lê Thị Hoa', CAST(N'1992-06-25' AS Date), N'Nữ', N'123 Đường XYZ', N'0123456789', N'hoalthi@email.com', N'TK013     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV004     ', N'Bùi Văn Tâm', CAST(N'1980-03-10' AS Date), N'Nam', N'654 Đường ABC', N'0987654321', N'tampham@email.com', N'TK014     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV005     ', N'Phạm Văn Anh', CAST(N'1995-12-20' AS Date), N'Nam', N'987 Đường XYZ', N'0123456789', N'anhpham@email.com', N'TK015     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV006     ', N'Trần Thị Lan', CAST(N'1987-09-18' AS Date), N'Nữ', N'159 Đường ABC', N'0987654321', N'lantran@email.com', N'TK016     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV007     ', N'Nguyễn Văn Hùng', CAST(N'1983-07-02' AS Date), N'Nam', N'753 Đường XYZ', N'0123456789', N'hunghnguyen@email.com', N'TK017     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV008     ', N'Dỗ Thị Nga', CAST(N'1993-04-15' AS Date), N'Nữ', N'246 Đường XYZ', N'0123456789', N'ngado@email.com', N'TK018     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV009     ', N'Mai Văn Hùng', CAST(N'1998-11-30' AS Date), N'Nam', N'852 Đường ABC', N'0987654321', N'hungmai@email.com', N'TK019     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV010     ', N'Lê Thị Lan', CAST(N'1990-06-15' AS Date), N'Nữ', N'111 Đường XYZ', N'0123456789', N'lanle@email.com', N'TK020     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV011     ', N'Trần Thị Bích', CAST(N'1996-05-15' AS Date), N'Nữ', N'123 Đường ABC', N'0123456789', N'bichtran@email.com', N'TK031     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV012     ', N'Nguyễn Văn Dũng', CAST(N'1998-09-20' AS Date), N'Nam', N'456 Đường XYZ', N'0987654321', N'dungnguyen@email.com', N'TK032     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV013     ', N'Lê Thị Mỹ', CAST(N'1992-12-10' AS Date), N'Nữ', N'789 Đường XYZ', N'0123456789', N'myle@email.com', N'TK033     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV014     ', N'Phạm Văn Hòa', CAST(N'1980-06-25' AS Date), N'Nam', N'321 Đường XYZ', N'0123456789', N'hoapham@email.com', N'TK034     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV015     ', N'Bùi Thị Thu', CAST(N'1995-03-10' AS Date), N'Nữ', N'654 Đường ABC', N'0987654321', N'thubui@email.com', N'TK035     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV016     ', N'Mai Văn Tuấn', CAST(N'1987-12-20' AS Date), N'Nam', N'987 Đường XYZ', N'0123456789', N'tuanmai@email.com', N'TK036     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV017     ', N'Nguyễn Thị Thuận', CAST(N'1990-09-18' AS Date), N'Nữ', N'159 Đường ABC', N'0987654321', N'thuannguyen@email.com', N'TK037     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV018     ', N'Dỗ Văn Luân', CAST(N'1983-07-02' AS Date), N'Nam', N'753 Đường XYZ', N'0123456789', N'luando@email.com', N'TK038     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV019     ', N'Mai Thị Hương', CAST(N'1993-04-15' AS Date), N'Nữ', N'246 Đường XYZ', N'0123456789', N'huongmai@email.com', N'TK039     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV020     ', N'Trần Văn Trung', CAST(N'1998-11-30' AS Date), N'Nam', N'852 Đường ABC', N'0987654321', N'trungtran@email.com', N'TK040     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV021     ', N'Nguyễn Thị Thảo', CAST(N'1996-09-08' AS Date), N'Nữ', N'123 Đường ABC', N'0123456789', N'thao.nguyen@email.com', N'TK041     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV022     ', N'Lê Thị Hà', CAST(N'1990-05-17' AS Date), N'Nữ', N'456 Đường XYZ', N'0987654321', N'hale@email.com', N'TK042     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV023     ', N'Phạm Văn Khôi', CAST(N'1987-02-22' AS Date), N'Nam', N'789 Đường XYZ', N'0123456789', N'khoipham@email.com', N'TK043     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV024     ', N'Trần Thị Lan', CAST(N'1983-10-28' AS Date), N'Nữ', N'654 Đường ABC', N'0987654321', N'lantran@email.com', N'TK044     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV025     ', N'Bùi Văn Thanh', CAST(N'1994-12-15' AS Date), N'Nam', N'987 Đường XYZ', N'0123456789', N'thanhbui@email.com', N'TK045     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV026     ', N'Mai Thị Tuyết', CAST(N'1988-07-03' AS Date), N'Nữ', N'159 Đường ABC', N'0987654321', N'tuyetmai@email.com', N'TK046     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV027     ', N'Nguyễn Văn Quý', CAST(N'1991-04-20' AS Date), N'Nam', N'753 Đường XYZ', N'0123456789', N'quynguyen@email.com', N'TK047     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV028     ', N'Dỗ Thị Hà', CAST(N'1995-11-10' AS Date), N'Nữ', N'246 Đường XYZ', N'0123456789', N'hatha@email.com', N'TK048     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV029     ', N'Mai Thị Lý', CAST(N'1990-06-30' AS Date), N'Nam', N'852 Đường ABC', N'0987654321', N'lymai@email.com', N'TK049     ')
INSERT [dbo].[HocVien] ([MaHocVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'HV030     ', N'Trần Văn Hiếu', CAST(N'1993-03-11' AS Date), N'Nữ', N'111 Đường XYZ', N'0123456789', N'hieutran@email.com', N'TK050     ')
GO
INSERT [dbo].[KhoaHoc] ([MaKhoaHoc], [TenKhoaHoc], [MoTa], [HocPhi], [ThoiGianBatDau], [ThoiGianKetThuc], [SoLuongHocVien], [DiaDiemHoc]) VALUES (N'KH001     ', N'Tiếng Anh cơ bản', N'Học tiếng Anh từ con số 0', 1500000, CAST(N'2023-01-15' AS Date), CAST(N'2023-06-30' AS Date), 30, N'123 Đường ABC')
INSERT [dbo].[KhoaHoc] ([MaKhoaHoc], [TenKhoaHoc], [MoTa], [HocPhi], [ThoiGianBatDau], [ThoiGianKetThuc], [SoLuongHocVien], [DiaDiemHoc]) VALUES (N'KH002     ', N'Tiếng Anh nâng cao', N'Học tiếng Anh cho người đã biết một chút', 2000000, CAST(N'2023-02-01' AS Date), CAST(N'2023-07-15' AS Date), 25, N'456 Đường XYZ')
INSERT [dbo].[KhoaHoc] ([MaKhoaHoc], [TenKhoaHoc], [MoTa], [HocPhi], [ThoiGianBatDau], [ThoiGianKetThuc], [SoLuongHocVien], [DiaDiemHoc]) VALUES (N'KH003     ', N'Tiếng Anh C1', N'Học tiếng Anh C1', 1800000, CAST(N'2023-03-10' AS Date), CAST(N'2023-08-25' AS Date), 20, N'789 Đường XYZ')
INSERT [dbo].[KhoaHoc] ([MaKhoaHoc], [TenKhoaHoc], [MoTa], [HocPhi], [ThoiGianBatDau], [ThoiGianKetThuc], [SoLuongHocVien], [DiaDiemHoc]) VALUES (N'KH004     ', N'Tiếng Anh B1', N'Học tiếng Anh B1', 2500000, CAST(N'2023-04-05' AS Date), CAST(N'2023-09-10' AS Date), 15, N'321 Đường XYZ')
INSERT [dbo].[KhoaHoc] ([MaKhoaHoc], [TenKhoaHoc], [MoTa], [HocPhi], [ThoiGianBatDau], [ThoiGianKetThuc], [SoLuongHocVien], [DiaDiemHoc]) VALUES (N'KH005     ', N'Tiếng Anh sinh viên', N'Ôn tập các công thức của sinh viên', 2200000, CAST(N'2023-05-20' AS Date), CAST(N'2023-10-31' AS Date), 18, N'654 Đường ABC')
INSERT [dbo].[KhoaHoc] ([MaKhoaHoc], [TenKhoaHoc], [MoTa], [HocPhi], [ThoiGianBatDau], [ThoiGianKetThuc], [SoLuongHocVien], [DiaDiemHoc]) VALUES (N'KH006     ', N'Tiếng Anh tiểu học', N'Học tiếng Anh cho trẻ 6-8 tuổi', 2300000, CAST(N'2023-06-15' AS Date), CAST(N'2023-11-20' AS Date), 22, N'987 Đường XYZ')
INSERT [dbo].[KhoaHoc] ([MaKhoaHoc], [TenKhoaHoc], [MoTa], [HocPhi], [ThoiGianBatDau], [ThoiGianKetThuc], [SoLuongHocVien], [DiaDiemHoc]) VALUES (N'KH007     ', N'Tiếng Anh cho người mới bắt đầu', N'Học tiếng Anh người mới', 2800000, CAST(N'2023-07-01' AS Date), CAST(N'2023-12-15' AS Date), 25, N'159 Đường ABC')
INSERT [dbo].[KhoaHoc] ([MaKhoaHoc], [TenKhoaHoc], [MoTa], [HocPhi], [ThoiGianBatDau], [ThoiGianKetThuc], [SoLuongHocVien], [DiaDiemHoc]) VALUES (N'KH008     ', N'Tiếng Anh cấp tốc', N'Học tiếng Anh nhanh chóng', 2600000, CAST(N'2023-08-10' AS Date), CAST(N'2024-01-25' AS Date), 20, N'753 Đường XYZ')
INSERT [dbo].[KhoaHoc] ([MaKhoaHoc], [TenKhoaHoc], [MoTa], [HocPhi], [ThoiGianBatDau], [ThoiGianKetThuc], [SoLuongHocVien], [DiaDiemHoc]) VALUES (N'KH009     ', N'Thực hành tiếng Anh', N'Học tiếng Anh qua các hoạt động thực tế', 2000000, CAST(N'2023-09-05' AS Date), CAST(N'2024-02-10' AS Date), 15, N'246 Đường XYZ')
INSERT [dbo].[KhoaHoc] ([MaKhoaHoc], [TenKhoaHoc], [MoTa], [HocPhi], [ThoiGianBatDau], [ThoiGianKetThuc], [SoLuongHocVien], [DiaDiemHoc]) VALUES (N'KH010     ', N'Tiếng Anh người bản xứ', N'Học tiếng anh hiệu quả', 2400000, CAST(N'2023-10-20' AS Date), CAST(N'2024-03-31' AS Date), 30, N'852 Đường ABC')
GO
INSERT [dbo].[LopHoc] ([MaLopHoc], [TenLop], [MaKhoaHoc], [NgayBatDau], [NgayKetThuc], [SoLuongHocVienHienTai], [SoLuongHocVienToiDa]) VALUES (N'LH001     ', N'Lớp 1A', N'KH001     ', CAST(N'2023-01-16' AS Date), CAST(N'2023-06-30' AS Date), 1, 20)
INSERT [dbo].[LopHoc] ([MaLopHoc], [TenLop], [MaKhoaHoc], [NgayBatDau], [NgayKetThuc], [SoLuongHocVienHienTai], [SoLuongHocVienToiDa]) VALUES (N'LH002     ', N'Lớp 2B', N'KH001     ', CAST(N'2023-01-17' AS Date), CAST(N'2023-06-30' AS Date), 1, 20)
INSERT [dbo].[LopHoc] ([MaLopHoc], [TenLop], [MaKhoaHoc], [NgayBatDau], [NgayKetThuc], [SoLuongHocVienHienTai], [SoLuongHocVienToiDa]) VALUES (N'LH003     ', N'Lớp 3C', N'KH002     ', CAST(N'2023-02-02' AS Date), CAST(N'2023-07-15' AS Date), 1, 20)
INSERT [dbo].[LopHoc] ([MaLopHoc], [TenLop], [MaKhoaHoc], [NgayBatDau], [NgayKetThuc], [SoLuongHocVienHienTai], [SoLuongHocVienToiDa]) VALUES (N'LH004     ', N'Lớp 4D', N'KH003     ', CAST(N'2023-03-11' AS Date), CAST(N'2023-08-25' AS Date), 1, 20)
INSERT [dbo].[LopHoc] ([MaLopHoc], [TenLop], [MaKhoaHoc], [NgayBatDau], [NgayKetThuc], [SoLuongHocVienHienTai], [SoLuongHocVienToiDa]) VALUES (N'LH005     ', N'Lớp 5E', N'KH004     ', CAST(N'2023-04-06' AS Date), CAST(N'2023-09-10' AS Date), 1, 20)
INSERT [dbo].[LopHoc] ([MaLopHoc], [TenLop], [MaKhoaHoc], [NgayBatDau], [NgayKetThuc], [SoLuongHocVienHienTai], [SoLuongHocVienToiDa]) VALUES (N'LH006     ', N'Lớp 6F', N'KH005     ', CAST(N'2023-05-21' AS Date), CAST(N'2023-10-31' AS Date), 1, 20)
INSERT [dbo].[LopHoc] ([MaLopHoc], [TenLop], [MaKhoaHoc], [NgayBatDau], [NgayKetThuc], [SoLuongHocVienHienTai], [SoLuongHocVienToiDa]) VALUES (N'LH007     ', N'Lớp 7G', N'KH005     ', CAST(N'2023-05-21' AS Date), CAST(N'2023-10-31' AS Date), 1, 20)
INSERT [dbo].[LopHoc] ([MaLopHoc], [TenLop], [MaKhoaHoc], [NgayBatDau], [NgayKetThuc], [SoLuongHocVienHienTai], [SoLuongHocVienToiDa]) VALUES (N'LH008     ', N'Lớp 8H', N'KH006     ', CAST(N'2023-06-16' AS Date), CAST(N'2023-11-20' AS Date), 1, 20)
INSERT [dbo].[LopHoc] ([MaLopHoc], [TenLop], [MaKhoaHoc], [NgayBatDau], [NgayKetThuc], [SoLuongHocVienHienTai], [SoLuongHocVienToiDa]) VALUES (N'LH009     ', N'Lớp 9I', N'KH007     ', CAST(N'2023-07-02' AS Date), CAST(N'2023-12-15' AS Date), 1, 20)
INSERT [dbo].[LopHoc] ([MaLopHoc], [TenLop], [MaKhoaHoc], [NgayBatDau], [NgayKetThuc], [SoLuongHocVienHienTai], [SoLuongHocVienToiDa]) VALUES (N'LH010     ', N'Lớp 10J', N'KH008     ', CAST(N'2023-08-11' AS Date), CAST(N'2024-01-25' AS Date), 1, 20)
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'NV001     ', N'Nguyễn Minh Tuấn', CAST(N'2001-03-20' AS Date), N'Nam', N'123 Đường ABC', N'0123456789', N'minhtuan203@email.com', N'TK001     ')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'NV002     ', N'Trần Thị Mai', CAST(N'1985-05-15' AS Date), N'Nữ', N'456 Đường XYZ', N'0987654321', N'maithi@email.com', N'TK022     ')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'NV003     ', N'Lê Văn Nam', CAST(N'1988-08-08' AS Date), N'Nam', N'789 Đường XYZ', N'0123456789', N'namlv@email.com', N'TK023     ')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'NV004     ', N'Huỳnh Thị Hương', CAST(N'1992-06-25' AS Date), N'Nữ', N'321 Đường XYZ', N'0123456789', N'huonght@email.com', N'TK024     ')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'NV005     ', N'Phạm Văn Tâm', CAST(N'1980-03-10' AS Date), N'Nam', N'654 Đường ABC', N'0987654321', N'tampham@email.com', N'TK025     ')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'NV006     ', N'Bùi Thị Hoa', CAST(N'1995-12-20' AS Date), N'Nữ', N'987 Đường XYZ', N'0123456789', N'hoabui@email.com', N'TK026     ')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'NV007     ', N'Nguyễn Văn Anh', CAST(N'1987-09-18' AS Date), N'Nam', N'159 Đường ABC', N'0987654321', N'anhnguyen@email.com', N'TK027     ')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'NV008     ', N'Lê Thị Nga', CAST(N'1983-07-02' AS Date), N'Nữ', N'753 Đường XYZ', N'0123456789', N'ngale@email.com', N'TK028     ')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'NV009     ', N'Đỗ Văn Hùng', CAST(N'1993-04-15' AS Date), N'Nam', N'246 Đường XYZ', N'0123456789', N'hungdo@email.com', N'TK029     ')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email], [MaTaiKhoan]) VALUES (N'NV010     ', N'Mai Thị Lan', CAST(N'1998-11-30' AS Date), N'Nữ', N'852 Đường ABC', N'0987654321', N'lanmai@email.com', N'TK030     ')
GO
INSERT [dbo].[PhatTaiLieu] ([IDPhatTaiLieu], [MaHocVien], [MaTaiLieu], [NgayPhatTaiLieu], [SoLuongPhat]) VALUES (N'PTL001    ', N'HV001     ', N'TL001     ', CAST(N'2023-01-20T10:30:00.000' AS DateTime), 1)
INSERT [dbo].[PhatTaiLieu] ([IDPhatTaiLieu], [MaHocVien], [MaTaiLieu], [NgayPhatTaiLieu], [SoLuongPhat]) VALUES (N'PTL002    ', N'HV002     ', N'TL002     ', CAST(N'2023-01-20T11:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhatTaiLieu] ([IDPhatTaiLieu], [MaHocVien], [MaTaiLieu], [NgayPhatTaiLieu], [SoLuongPhat]) VALUES (N'PTL003    ', N'HV003     ', N'TL003     ', CAST(N'2023-02-05T12:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhatTaiLieu] ([IDPhatTaiLieu], [MaHocVien], [MaTaiLieu], [NgayPhatTaiLieu], [SoLuongPhat]) VALUES (N'PTL004    ', N'HV004     ', N'TL004     ', CAST(N'2023-03-15T14:30:00.000' AS DateTime), 1)
INSERT [dbo].[PhatTaiLieu] ([IDPhatTaiLieu], [MaHocVien], [MaTaiLieu], [NgayPhatTaiLieu], [SoLuongPhat]) VALUES (N'PTL005    ', N'HV005     ', N'TL005     ', CAST(N'2023-04-10T15:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhatTaiLieu] ([IDPhatTaiLieu], [MaHocVien], [MaTaiLieu], [NgayPhatTaiLieu], [SoLuongPhat]) VALUES (N'PTL006    ', N'HV006     ', N'TL006     ', CAST(N'2023-05-25T16:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhatTaiLieu] ([IDPhatTaiLieu], [MaHocVien], [MaTaiLieu], [NgayPhatTaiLieu], [SoLuongPhat]) VALUES (N'PTL007    ', N'HV007     ', N'TL007     ', CAST(N'2023-05-25T16:30:00.000' AS DateTime), 1)
INSERT [dbo].[PhatTaiLieu] ([IDPhatTaiLieu], [MaHocVien], [MaTaiLieu], [NgayPhatTaiLieu], [SoLuongPhat]) VALUES (N'PTL008    ', N'HV008     ', N'TL008     ', CAST(N'2023-06-20T17:15:00.000' AS DateTime), 1)
INSERT [dbo].[PhatTaiLieu] ([IDPhatTaiLieu], [MaHocVien], [MaTaiLieu], [NgayPhatTaiLieu], [SoLuongPhat]) VALUES (N'PTL009    ', N'HV009     ', N'TL009     ', CAST(N'2023-07-05T18:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhatTaiLieu] ([IDPhatTaiLieu], [MaHocVien], [MaTaiLieu], [NgayPhatTaiLieu], [SoLuongPhat]) VALUES (N'PTL010    ', N'HV010     ', N'TL010     ', CAST(N'2023-08-15T19:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaHocVien], [NgayLap], [TongTien], [MaNhanVien], [TrangThai]) VALUES (N'PT001     ', N'HV001     ', CAST(N'2023-01-20' AS Date), 1500000, N'NV001     ', N'Đã thanh toán')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaHocVien], [NgayLap], [TongTien], [MaNhanVien], [TrangThai]) VALUES (N'PT002     ', N'HV002     ', CAST(N'2023-02-05' AS Date), 2000000, N'NV002     ', N'Chưa thanh toán')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaHocVien], [NgayLap], [TongTien], [MaNhanVien], [TrangThai]) VALUES (N'PT003     ', N'HV003     ', CAST(N'2023-03-15' AS Date), 1800000, N'NV003     ', N'Đã thanh toán')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaHocVien], [NgayLap], [TongTien], [MaNhanVien], [TrangThai]) VALUES (N'PT004     ', N'HV004     ', CAST(N'2023-04-10' AS Date), 2500000, N'NV004     ', N'Chưa thanh toán')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaHocVien], [NgayLap], [TongTien], [MaNhanVien], [TrangThai]) VALUES (N'PT005     ', N'HV005     ', CAST(N'2023-05-25' AS Date), 2200000, N'NV005     ', N'Đã thanh toán')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaHocVien], [NgayLap], [TongTien], [MaNhanVien], [TrangThai]) VALUES (N'PT006     ', N'HV006     ', CAST(N'2023-06-20' AS Date), 2300000, N'NV006     ', N'Chưa thanh toán')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaHocVien], [NgayLap], [TongTien], [MaNhanVien], [TrangThai]) VALUES (N'PT007     ', N'HV007     ', CAST(N'2023-07-05' AS Date), 2800000, N'NV007     ', N'Đã thanh toán')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaHocVien], [NgayLap], [TongTien], [MaNhanVien], [TrangThai]) VALUES (N'PT008     ', N'HV008     ', CAST(N'2023-08-15' AS Date), 2600000, N'NV008     ', N'Chưa thanh toán')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaHocVien], [NgayLap], [TongTien], [MaNhanVien], [TrangThai]) VALUES (N'PT009     ', N'HV009     ', CAST(N'2023-09-10' AS Date), 2000000, N'NV009     ', N'Đã thanh toán')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaHocVien], [NgayLap], [TongTien], [MaNhanVien], [TrangThai]) VALUES (N'PT010     ', N'HV010     ', CAST(N'2023-10-25' AS Date), 2400000, N'NV010     ', N'Chưa thanh toán')
GO
INSERT [dbo].[PhongHoc] ([MaPhongHoc], [TenPhongHoc], [SoLuongToiDa], [SoLuongDaDangKy]) VALUES (N'PH001     ', N'Phòng A1', 30, 15)
INSERT [dbo].[PhongHoc] ([MaPhongHoc], [TenPhongHoc], [SoLuongToiDa], [SoLuongDaDangKy]) VALUES (N'PH002     ', N'Phòng B2', 25, 10)
INSERT [dbo].[PhongHoc] ([MaPhongHoc], [TenPhongHoc], [SoLuongToiDa], [SoLuongDaDangKy]) VALUES (N'PH003     ', N'Phòng C3', 20, 18)
INSERT [dbo].[PhongHoc] ([MaPhongHoc], [TenPhongHoc], [SoLuongToiDa], [SoLuongDaDangKy]) VALUES (N'PH004     ', N'Phòng D4', 35, 25)
INSERT [dbo].[PhongHoc] ([MaPhongHoc], [TenPhongHoc], [SoLuongToiDa], [SoLuongDaDangKy]) VALUES (N'PH005     ', N'Phòng E5', 40, 30)
INSERT [dbo].[PhongHoc] ([MaPhongHoc], [TenPhongHoc], [SoLuongToiDa], [SoLuongDaDangKy]) VALUES (N'PH006     ', N'Phòng F6', 15, 8)
INSERT [dbo].[PhongHoc] ([MaPhongHoc], [TenPhongHoc], [SoLuongToiDa], [SoLuongDaDangKy]) VALUES (N'PH007     ', N'Phòng G7', 28, 20)
INSERT [dbo].[PhongHoc] ([MaPhongHoc], [TenPhongHoc], [SoLuongToiDa], [SoLuongDaDangKy]) VALUES (N'PH008     ', N'Phòng H8', 22, 15)
INSERT [dbo].[PhongHoc] ([MaPhongHoc], [TenPhongHoc], [SoLuongToiDa], [SoLuongDaDangKy]) VALUES (N'PH009     ', N'Phòng I9', 18, 12)
INSERT [dbo].[PhongHoc] ([MaPhongHoc], [TenPhongHoc], [SoLuongToiDa], [SoLuongDaDangKy]) VALUES (N'PH010     ', N'Phòng J10', 33, 28)
GO
INSERT [dbo].[QuyenTruyCap] ([MaQuyenTruyCap], [TenQuyenTruyCap]) VALUES (N'QT002     ', N'Giảng viên')
INSERT [dbo].[QuyenTruyCap] ([MaQuyenTruyCap], [TenQuyenTruyCap]) VALUES (N'QT003     ', N'Học viên')
INSERT [dbo].[QuyenTruyCap] ([MaQuyenTruyCap], [TenQuyenTruyCap]) VALUES (N'QT004     ', N'Nhân viên văn phòng')
INSERT [dbo].[QuyenTruyCap] ([MaQuyenTruyCap], [TenQuyenTruyCap]) VALUES (N'QT001     ', N'Quản trị hệ thống')
GO
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK001     ', N'admin01', N'hashed_password', N'QT001     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK002     ', N'giangvien02', N'hashed_password', N'QT002     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK003     ', N'giangvien03', N'hashed_password', N'QT002     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK004     ', N'giangvien04', N'hashed_password', N'QT002     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK005     ', N'giangvien05', N'hashed_password', N'QT002     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK006     ', N'giangvien06', N'hashed_password', N'QT002     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK007     ', N'giangvien07', N'hashed_password', N'QT002     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK008     ', N'giangvien08', N'hashed_password', N'QT002     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK009     ', N'giangvien09', N'hashed_password', N'QT002     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK010     ', N'giangvien10', N'hashed_password', N'QT002     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK011     ', N'hocvien02', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK012     ', N'hocvien03', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK013     ', N'hocvien04', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK014     ', N'hocvien05', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK015     ', N'hocvien06', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK016     ', N'hocvien07', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK017     ', N'hocvien08', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK018     ', N'hocvien09', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK019     ', N'hocvien10', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK020     ', N'hocvien11', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK021     ', N'giangvien01', N'hashed_password', N'QT002     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK022     ', N'nhanvien02', N'hashed_password', N'QT004     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK023     ', N'nhanvien03', N'hashed_password', N'QT004     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK024     ', N'nhanvien04', N'hashed_password', N'QT004     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK025     ', N'nhanvien05', N'hashed_password', N'QT004     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK026     ', N'nhanvien06', N'hashed_password', N'QT004     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK027     ', N'nhanvien07', N'hashed_password', N'QT004     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK028     ', N'nhanvien08', N'hashed_password', N'QT004     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK029     ', N'nhanvien09', N'hashed_password', N'QT004     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK030     ', N'nhanvien10', N'hashed_password', N'QT004     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK031     ', N'hocvien32', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK032     ', N'hocvien33', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK033     ', N'hocvien34', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK034     ', N'hocvien35', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK035     ', N'hocvien36', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK036     ', N'hocvien37', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK037     ', N'hocvien38', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK038     ', N'hocvien39', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK039     ', N'hocvien40', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK040     ', N'hocvien41', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK041     ', N'hocvien42', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK042     ', N'hocvien43', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK043     ', N'hocvien44', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK044     ', N'hocvien45', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK045     ', N'hocvien46', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK046     ', N'hocvien47', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK047     ', N'hocvien48', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK048     ', N'hocvien49', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK049     ', N'hocvien50', N'hashed_password', N'QT003     ')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [MaQuyenTruyCap]) VALUES (N'TK050     ', N'hocvien51', N'hashed_password', N'QT003     ')
GO
INSERT [dbo].[TaiLieu] ([MaTaiLieu], [TenTaiLieu], [MaKhoaHoc], [SoLuongTaiLieu]) VALUES (N'TL001     ', N'Tài liệu Lớp 1A', N'KH001     ', 10)
INSERT [dbo].[TaiLieu] ([MaTaiLieu], [TenTaiLieu], [MaKhoaHoc], [SoLuongTaiLieu]) VALUES (N'TL002     ', N'Tài liệu Lớp 2B', N'KH001     ', 8)
INSERT [dbo].[TaiLieu] ([MaTaiLieu], [TenTaiLieu], [MaKhoaHoc], [SoLuongTaiLieu]) VALUES (N'TL003     ', N'Tài liệu Lớp 3C', N'KH002     ', 12)
INSERT [dbo].[TaiLieu] ([MaTaiLieu], [TenTaiLieu], [MaKhoaHoc], [SoLuongTaiLieu]) VALUES (N'TL004     ', N'Tài liệu Lớp 4D', N'KH003     ', 6)
INSERT [dbo].[TaiLieu] ([MaTaiLieu], [TenTaiLieu], [MaKhoaHoc], [SoLuongTaiLieu]) VALUES (N'TL005     ', N'Tài liệu Lớp 5E', N'KH004     ', 15)
INSERT [dbo].[TaiLieu] ([MaTaiLieu], [TenTaiLieu], [MaKhoaHoc], [SoLuongTaiLieu]) VALUES (N'TL006     ', N'Tài liệu Lớp 6F', N'KH005     ', 10)
INSERT [dbo].[TaiLieu] ([MaTaiLieu], [TenTaiLieu], [MaKhoaHoc], [SoLuongTaiLieu]) VALUES (N'TL007     ', N'Tài liệu Lớp 7G', N'KH005     ', 8)
INSERT [dbo].[TaiLieu] ([MaTaiLieu], [TenTaiLieu], [MaKhoaHoc], [SoLuongTaiLieu]) VALUES (N'TL008     ', N'Tài liệu Lớp 8H', N'KH006     ', 5)
INSERT [dbo].[TaiLieu] ([MaTaiLieu], [TenTaiLieu], [MaKhoaHoc], [SoLuongTaiLieu]) VALUES (N'TL009     ', N'Tài liệu Lớp 9I', N'KH007     ', 12)
INSERT [dbo].[TaiLieu] ([MaTaiLieu], [TenTaiLieu], [MaKhoaHoc], [SoLuongTaiLieu]) VALUES (N'TL010     ', N'Tài liệu Lớp 10J', N'KH008     ', 10)
GO
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB001    ', N'GV001     ', N'PH001     ', N'LH001     ', 2, 1, 5, N'Phòng A1', N'Sáng', CAST(N'2023-01-16' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB002    ', N'GV002     ', N'PH002     ', N'LH002     ', 4, 6, 12, N'Phòng A2', N'Chiều', NULL, N'Thi', CAST(N'2023-01-16' AS Date), N'TC01      ')
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB003    ', N'GV003     ', N'PH003     ', N'LH003     ', 3, 13, 18, N'Phòng B1', N'Tối', CAST(N'2023-01-17' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB004    ', N'GV004     ', N'PH004     ', N'LH004     ', 5, 6, 12, N'Phòng B2', N'Chiều', NULL, N'Thi', CAST(N'2023-01-17' AS Date), N'TC01      ')
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB005    ', N'GV005     ', N'PH005     ', N'LH005     ', 4, 1, 5, N'Phòng C1', N'Sáng', CAST(N'2023-01-18' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB006    ', N'GV006     ', N'PH006     ', N'LH006     ', 2, 13, 18, N'Phòng C2', N'Tối', CAST(N'2023-01-18' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB007    ', N'GV007     ', N'PH007     ', N'LH007     ', 3, 6, 12, N'Phòng D1', N'Chiều', NULL, N'Thi', CAST(N'2023-01-19' AS Date), N'TC01      ')
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB008    ', N'GV008     ', N'PH008     ', N'LH008     ', 5, 13, 18, N'Phòng D2', N'Tối', CAST(N'2023-01-19' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB009    ', N'GV009     ', N'PH009     ', N'LH009     ', 2, 1, 5, N'Phòng E1', N'Sáng', CAST(N'2023-01-20' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB010    ', N'GV010     ', N'PH010     ', N'LH010     ', 4, 6, 12, N'Phòng E2', N'Chiều', NULL, N'Thi', CAST(N'2023-01-20' AS Date), N'TC01      ')
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB011    ', N'GV001     ', N'PH001     ', N'LH001     ', 2, 1, 3, N'Phòng A1', N'Sáng', CAST(N'2023-01-16' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB012    ', N'GV001     ', N'PH002     ', N'LH002     ', 4, 6, 9, N'Phòng A2', N'Chiều', CAST(N'2023-01-16' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB013    ', N'GV001     ', N'PH003     ', N'LH003     ', 3, 13, 16, N'Phòng B1', N'Tối', CAST(N'2023-01-17' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB014    ', N'GV001     ', N'PH004     ', N'LH004     ', 5, 10, 12, N'Phòng B2', N'Chiều', CAST(N'2023-01-17' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB015    ', N'GV001     ', N'PH005     ', N'LH005     ', 4, 1, 3, N'Phòng C1', N'Sáng', CAST(N'2023-01-18' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB016    ', N'GV002     ', N'PH006     ', N'LH006     ', 2, 1, 3, N'Phòng C2', N'Sáng', CAST(N'2023-01-18' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB017    ', N'GV002     ', N'PH007     ', N'LH007     ', 3, 6, 9, N'Phòng D1', N'Chiều', CAST(N'2023-01-19' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB018    ', N'GV002     ', N'PH008     ', N'LH008     ', 5, 10, 12, N'Phòng D2', N'Chiều', CAST(N'2023-01-19' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB019    ', N'GV002     ', N'PH009     ', N'LH009     ', 2, 13, 16, N'Phòng E1', N'Tối', CAST(N'2023-01-20' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB020    ', N'GV002     ', N'PH010     ', N'LH010     ', 4, 6, 9, N'Phòng E2', N'Chiều', CAST(N'2023-01-20' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB021    ', N'GV003     ', N'PH001     ', N'LH003     ', 3, 1, 3, N'Phòng A1', N'Sáng', CAST(N'2023-01-16' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB022    ', N'GV003     ', N'PH002     ', N'LH005     ', 4, 6, 9, N'Phòng A2', N'Chiều', CAST(N'2023-01-17' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB023    ', N'GV003     ', N'PH003     ', N'LH007     ', 5, 13, 16, N'Phòng B1', N'Tối', CAST(N'2023-01-18' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB024    ', N'GV003     ', N'PH004     ', N'LH009     ', 2, 1, 3, N'Phòng B2', N'Sáng', CAST(N'2023-01-19' AS Date), N'Học', NULL, NULL)
INSERT [dbo].[ThoiKhoaBieu] ([IDThoiKhoaBieu], [MaGiangVien], [MaPhongHoc], [MaLopHoc], [Thu], [TietBatDau], [TietKetThuc], [DiaDiem], [CaHoc], [NgayHoc], [LoaiLich], [NgayThi], [MaToChucThi]) VALUES (N'TKB025    ', N'GV003     ', N'PH005     ', N'LH010     ', 3, 6, 9, N'Phòng C1', N'Chiều', CAST(N'2023-01-20' AS Date), N'Học', NULL, NULL)
GO
INSERT [dbo].[ToChucThi] ([MaToChucThi], [TenToChucThi]) VALUES (N'TC01      ', N'Thi cuối kỳ toiec')
GO
INSERT [dbo].[ToChucThi_LOP] ([MaToChucThi], [MaLopHoc]) VALUES (N'TC01      ', N'LH001     ')
INSERT [dbo].[ToChucThi_LOP] ([MaToChucThi], [MaLopHoc]) VALUES (N'TC01      ', N'LH002     ')
INSERT [dbo].[ToChucThi_LOP] ([MaToChucThi], [MaLopHoc]) VALUES (N'TC01      ', N'LH003     ')
GO
INSERT [dbo].[XepLopHocVien] ([IDXepLop], [MaLopHoc], [MaHocVien]) VALUES (N'XL01      ', N'LH001     ', N'HV001     ')
INSERT [dbo].[XepLopHocVien] ([IDXepLop], [MaLopHoc], [MaHocVien]) VALUES (N'XL010     ', N'LH009     ', N'HV010     ')
INSERT [dbo].[XepLopHocVien] ([IDXepLop], [MaLopHoc], [MaHocVien]) VALUES (N'XL02      ', N'LH001     ', N'HV002     ')
INSERT [dbo].[XepLopHocVien] ([IDXepLop], [MaLopHoc], [MaHocVien]) VALUES (N'XL03      ', N'LH002     ', N'HV003     ')
INSERT [dbo].[XepLopHocVien] ([IDXepLop], [MaLopHoc], [MaHocVien]) VALUES (N'XL04      ', N'LH003     ', N'HV004     ')
INSERT [dbo].[XepLopHocVien] ([IDXepLop], [MaLopHoc], [MaHocVien]) VALUES (N'XL05      ', N'LH004     ', N'HV005     ')
INSERT [dbo].[XepLopHocVien] ([IDXepLop], [MaLopHoc], [MaHocVien]) VALUES (N'XL06      ', N'LH005     ', N'HV006     ')
INSERT [dbo].[XepLopHocVien] ([IDXepLop], [MaLopHoc], [MaHocVien]) VALUES (N'XL07      ', N'LH006     ', N'HV007     ')
INSERT [dbo].[XepLopHocVien] ([IDXepLop], [MaLopHoc], [MaHocVien]) VALUES (N'XL08      ', N'LH007     ', N'HV008     ')
INSERT [dbo].[XepLopHocVien] ([IDXepLop], [MaLopHoc], [MaHocVien]) VALUES (N'XL09      ', N'LH008     ', N'HV009     ')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__GiangVie__AD7C6528C9A26E7D]    Script Date: 19/12/2023 12:51:39 SA ******/
ALTER TABLE [dbo].[GiangVien] ADD UNIQUE NONCLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__HocVien__AD7C65286C8C823C]    Script Date: 19/12/2023 12:51:39 SA ******/
ALTER TABLE [dbo].[HocVien] ADD UNIQUE NONCLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__AD7C6528843D19C7]    Script Date: 19/12/2023 12:51:39 SA ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__QuyenTru__4D84C327F62D6ABA]    Script Date: 19/12/2023 12:51:39 SA ******/
ALTER TABLE [dbo].[QuyenTruyCap] ADD UNIQUE NONCLUSTERED 
(
	[TenQuyenTruyCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TaiKhoan__55F68FC09889A9EF]    Script Date: 19/12/2023 12:51:39 SA ******/
ALTER TABLE [dbo].[TaiKhoan] ADD UNIQUE NONCLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietPhieuThu]  WITH CHECK ADD FOREIGN KEY([MaKhoaHoc])
REFERENCES [dbo].[KhoaHoc] ([MaKhoaHoc])
GO
ALTER TABLE [dbo].[ChiTietPhieuThu]  WITH CHECK ADD FOREIGN KEY([MaPhieuThu])
REFERENCES [dbo].[PhieuThu] ([MaPhieuThu])
GO
ALTER TABLE [dbo].[DangKyKhoaHoc]  WITH CHECK ADD FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HocVien] ([MaHocVien])
GO
ALTER TABLE [dbo].[DangKyKhoaHoc_KhoaHoc]  WITH CHECK ADD FOREIGN KEY([MaDangKy])
REFERENCES [dbo].[DangKyKhoaHoc] ([MaDangKy])
GO
ALTER TABLE [dbo].[DangKyKhoaHoc_KhoaHoc]  WITH CHECK ADD FOREIGN KEY([MaKhoaHoc])
REFERENCES [dbo].[KhoaHoc] ([MaKhoaHoc])
GO
ALTER TABLE [dbo].[DiemDanh]  WITH CHECK ADD FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HocVien] ([MaHocVien])
GO
ALTER TABLE [dbo].[DiemDanh]  WITH CHECK ADD FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
ALTER TABLE [dbo].[DiemThi]  WITH CHECK ADD FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HocVien] ([MaHocVien])
GO
ALTER TABLE [dbo].[DiemThi]  WITH CHECK ADD FOREIGN KEY([MaToChucThi])
REFERENCES [dbo].[ToChucThi] ([MaToChucThi])
GO
ALTER TABLE [dbo].[GiangVien]  WITH CHECK ADD FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([MaTaiKhoan])
GO
ALTER TABLE [dbo].[HocVien]  WITH CHECK ADD FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([MaTaiKhoan])
GO
ALTER TABLE [dbo].[LopHoc]  WITH CHECK ADD FOREIGN KEY([MaKhoaHoc])
REFERENCES [dbo].[KhoaHoc] ([MaKhoaHoc])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([MaTaiKhoan])
GO
ALTER TABLE [dbo].[PhatTaiLieu]  WITH CHECK ADD FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HocVien] ([MaHocVien])
GO
ALTER TABLE [dbo].[PhatTaiLieu]  WITH CHECK ADD FOREIGN KEY([MaTaiLieu])
REFERENCES [dbo].[TaiLieu] ([MaTaiLieu])
GO
ALTER TABLE [dbo].[PhieuThu]  WITH CHECK ADD FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HocVien] ([MaHocVien])
GO
ALTER TABLE [dbo].[PhieuThu]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_QuyenTruyCap_TaiKhoan] FOREIGN KEY([MaQuyenTruyCap])
REFERENCES [dbo].[QuyenTruyCap] ([MaQuyenTruyCap])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_QuyenTruyCap_TaiKhoan]
GO
ALTER TABLE [dbo].[TaiLieu]  WITH CHECK ADD FOREIGN KEY([MaKhoaHoc])
REFERENCES [dbo].[KhoaHoc] ([MaKhoaHoc])
GO
ALTER TABLE [dbo].[ThoiKhoaBieu]  WITH CHECK ADD  CONSTRAINT [FK_ThoiKhoaBieu_GiangVien] FOREIGN KEY([MaGiangVien])
REFERENCES [dbo].[GiangVien] ([MaGiangVien])
GO
ALTER TABLE [dbo].[ThoiKhoaBieu] CHECK CONSTRAINT [FK_ThoiKhoaBieu_GiangVien]
GO
ALTER TABLE [dbo].[ThoiKhoaBieu]  WITH CHECK ADD  CONSTRAINT [FK_ThoiKhoaBieu_KyThiCuoiKy] FOREIGN KEY([MaToChucThi])
REFERENCES [dbo].[ToChucThi] ([MaToChucThi])
GO
ALTER TABLE [dbo].[ThoiKhoaBieu] CHECK CONSTRAINT [FK_ThoiKhoaBieu_KyThiCuoiKy]
GO
ALTER TABLE [dbo].[ThoiKhoaBieu]  WITH CHECK ADD  CONSTRAINT [FK_ThoiKhoaBieu_Lop] FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
ALTER TABLE [dbo].[ThoiKhoaBieu] CHECK CONSTRAINT [FK_ThoiKhoaBieu_Lop]
GO
ALTER TABLE [dbo].[ThoiKhoaBieu]  WITH CHECK ADD  CONSTRAINT [FK_ThoiKhoaBieu_PhongHoc] FOREIGN KEY([MaPhongHoc])
REFERENCES [dbo].[PhongHoc] ([MaPhongHoc])
GO
ALTER TABLE [dbo].[ThoiKhoaBieu] CHECK CONSTRAINT [FK_ThoiKhoaBieu_PhongHoc]
GO
ALTER TABLE [dbo].[ToChucThi_LOP]  WITH CHECK ADD FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
ALTER TABLE [dbo].[ToChucThi_LOP]  WITH CHECK ADD FOREIGN KEY([MaToChucThi])
REFERENCES [dbo].[ToChucThi] ([MaToChucThi])
GO
ALTER TABLE [dbo].[XepLopHocVien]  WITH CHECK ADD FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HocVien] ([MaHocVien])
GO
ALTER TABLE [dbo].[XepLopHocVien]  WITH CHECK ADD FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
/****** Object:  Trigger [dbo].[Trg_AfterInsertPhatTaiLieu]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[Trg_AfterInsertPhatTaiLieu]
ON [dbo].[PhatTaiLieu]
AFTER INSERT
AS
BEGIN
    -- Cập nhật số lượng tài liệu trong bảng TaiLieu sau khi có phát tài liệu mới cho học viên
    UPDATE TaiLieu
    SET SoLuongTaiLieu = SoLuongTaiLieu - i.SoLuongPhat
    FROM TaiLieu t
    INNER JOIN inserted i ON t.MaTaiLieu = i.MaTaiLieu;
END;




GO
ALTER TABLE [dbo].[PhatTaiLieu] ENABLE TRIGGER [Trg_AfterInsertPhatTaiLieu]
GO
/****** Object:  Trigger [dbo].[trg_AfterUpdate_PhieuThu]    Script Date: 19/12/2023 12:51:39 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   TRIGGER [dbo].[trg_AfterUpdate_PhieuThu]
ON [dbo].[PhieuThu]
AFTER UPDATE
AS
BEGIN
    IF UPDATE(TrangThai)
    BEGIN
        DECLARE @MaPhieuThu CHAR(10)
        DECLARE @MaHocVien CHAR(10)
        DECLARE @NgayPhatTaiLieu DATETIME = GETDATE()

        SELECT @MaPhieuThu = i.MaPhieuThu,
               @MaHocVien = p.MaHocVien
        FROM inserted i
        JOIN PhieuThu p ON i.MaPhieuThu = p.MaPhieuThu
        WHERE i.TrangThai = N'Đã thanh toán'

        IF @MaPhieuThu IS NOT NULL
        BEGIN
            -- Lấy danh sách khóa học mà học viên đã đăng ký
            DECLARE @DanhSachKhoaHoc TABLE (MaTaiLieu CHAR(10))

            INSERT INTO @DanhSachKhoaHoc (MaTaiLieu)
            SELECT tl.MaTaiLieu
            FROM DangKyKhoaHoc dk
            JOIN DangKyKhoaHoc_KhoaHoc dkkh ON dk.MaDangKy = dkkh.MaDangKy
            JOIN TaiLieu tl ON dkkh.MaKhoaHoc = tl.MaKhoaHoc
            WHERE dk.MaHocVien = @MaHocVien

            -- Lặp qua danh sách các khóa học và phát tài liệu tương ứng
            DECLARE @MaTaiLieuTemp CHAR(10)

            DECLARE cur CURSOR FOR
            SELECT MaTaiLieu FROM @DanhSachKhoaHoc

            OPEN cur
            FETCH NEXT FROM cur INTO @MaTaiLieuTemp

            WHILE @@FETCH_STATUS = 0
            BEGIN
                IF NOT EXISTS (SELECT 1 FROM PhatTaiLieu WHERE MaHocVien = @MaHocVien AND MaTaiLieu = @MaTaiLieuTemp)
                BEGIN
                    DECLARE @IDPhatTaiLieu CHAR(10)
                    SET @IDPhatTaiLieu = 'PTL' + LEFT(CAST(@MaHocVien AS VARCHAR(7)), 3) + RIGHT(CAST(ABS(CHECKSUM(NEWID())) % 10000 AS VARCHAR(5)), 4)

                    INSERT INTO PhatTaiLieu (IDPhatTaiLieu, MaHocVien, MaTaiLieu, NgayPhatTaiLieu, SoLuongPhat)
                    VALUES (@IDPhatTaiLieu, @MaHocVien, @MaTaiLieuTemp, @NgayPhatTaiLieu, 1)
                END

                FETCH NEXT FROM cur INTO @MaTaiLieuTemp
            END

            CLOSE cur
            DEALLOCATE cur
        END
    END
END

GO
ALTER TABLE [dbo].[PhieuThu] ENABLE TRIGGER [trg_AfterUpdate_PhieuThu]
GO
