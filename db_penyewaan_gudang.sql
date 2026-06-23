-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 14 Jun 2026 pada 14.42
-- Versi server: 10.4.32-MariaDB
-- Versi PHP: 8.1.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_penyewaan_gudang`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `area_gudang`
--

CREATE TABLE `area_gudang` (
  `id_area` int(11) NOT NULL,
  `id_kategori` int(11) DEFAULT NULL,
  `kode_area` varchar(20) DEFAULT NULL,
  `panjang` int(11) DEFAULT NULL,
  `lebar` int(11) DEFAULT NULL,
  `harga_per_bulan` decimal(12,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `booking_barang`
--

CREATE TABLE `booking_barang` (
  `id_barang` int(11) NOT NULL,
  `id_booking` int(11) NOT NULL,
  `nama_barang` varchar(100) NOT NULL,
  `jumlah` decimal(10,2) NOT NULL,
  `satuan` varchar(20) DEFAULT NULL,
  `luas_m3` decimal(10,2) DEFAULT NULL,
  `keterangan` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `booking_barang`
--

INSERT INTO `booking_barang` (`id_barang`, `id_booking`, `nama_barang`, `jumlah`, `satuan`, `luas_m3`, `keterangan`) VALUES
(1, 4, 'laptop', 10.00, 'Box', 10.00, '1 box isi 6 pcs'),
(2, 5, 'rangka cbr250rr', 2.00, 'Pcs', 10.00, '');

-- --------------------------------------------------------

--
-- Struktur dari tabel `booking_request`
--

CREATE TABLE `booking_request` (
  `id_booking` int(11) NOT NULL,
  `id_penyewa` int(11) NOT NULL,
  `kode_gudang` int(11) NOT NULL,
  `tgl_mulai` date DEFAULT NULL,
  `durasi_bulan` int(11) DEFAULT NULL,
  `keterangan` text DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `status` varchar(20) DEFAULT 'Pending',
  `tgl_request` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `booking_request`
--

INSERT INTO `booking_request` (`id_booking`, `id_penyewa`, `kode_gudang`, `tgl_mulai`, `durasi_bulan`, `keterangan`, `created_at`, `status`, `tgl_request`) VALUES
(1, 3, 2007040101, '2026-05-09', 5, '', '2026-05-09 14:42:58', 'Kontrak Dibuat', '2026-05-09 07:40:44'),
(4, 9, 2007040148, '2026-05-12', 12, '', '2026-05-12 16:05:52', 'Kontrak Dibuat', '2026-05-12 09:05:52'),
(5, 6, 2007040111, '2026-05-12', 10, '', '2026-05-12 19:28:46', 'Kontrak Dibuat', '2026-05-12 12:28:46'),
(6, 10, 2007040145, '2026-05-16', 1, '', '2026-05-16 19:32:03', 'Kontrak Dibuat', '2026-05-16 12:32:03'),
(7, 11, 2007040107, '2026-06-13', 3, '', '2026-06-13 13:46:46', 'Kontrak Dibuat', '2026-06-13 06:46:46');

-- --------------------------------------------------------

--
-- Struktur dari tabel `detail_kontrak`
--

CREATE TABLE `detail_kontrak` (
  `id_detail` int(11) NOT NULL,
  `no_kontrak` varchar(30) NOT NULL,
  `kode_gudang` int(11) NOT NULL,
  `harga_satuan` decimal(12,2) NOT NULL,
  `durasi_bulan` int(11) NOT NULL,
  `subtotal` decimal(12,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `detail_kontrak`
--

INSERT INTO `detail_kontrak` (`id_detail`, `no_kontrak`, `kode_gudang`, `harga_satuan`, `durasi_bulan`, `subtotal`) VALUES
(1, '1', 2007040102, 125000.00, 12, 1500000.00),
(2, '2', 2007040103, 250000.00, 12, 3000000.00),
(3, '3', 2007040106, 125000.00, 12, 1500000.00),
(4, '4', 2007040109, 625000.00, 12, 7500000.00),
(5, 'KTR-20260512-001', 2007040101, 416666.67, 12, 5000000.00),
(6, 'KTR-20260512-004', 2007040148, 1000000.00, 12, 12000000.00);

-- --------------------------------------------------------

--
-- Struktur dari tabel `gudang`
--

CREATE TABLE `gudang` (
  `kode_gudang` int(11) NOT NULL,
  `id_area` int(11) DEFAULT NULL,
  `nama_gudang` varchar(30) DEFAULT NULL,
  `kategori` varchar(50) DEFAULT 'Umum',
  `area` varchar(10) DEFAULT NULL,
  `ukuran` varchar(20) DEFAULT NULL,
  `kapasitas_m3` decimal(10,2) NOT NULL DEFAULT 0.00,
  `harga_sewa` decimal(12,2) DEFAULT 0.00,
  `lokasi` varchar(50) DEFAULT NULL,
  `status` varchar(20) DEFAULT 'tersedia',
  `keterangan` text DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `gudang`
--

INSERT INTO `gudang` (`kode_gudang`, `id_area`, `nama_gudang`, `kategori`, `area`, `ukuran`, `kapasitas_m3`, `harga_sewa`, `lokasi`, `status`, `keterangan`, `created_at`, `updated_at`) VALUES
(2007040101, NULL, 'Gudang A', 'Elektronik', 'A-1', '4x4', 16.00, 1000000.00, 'Blok A', 'Terisi', 'Gudang kecil', '2026-04-23 07:53:20', '2026-05-12 09:40:38'),
(2007040102, NULL, 'Gudang A', 'Elektronik', 'A-2', '8x8', 64.00, 2000000.00, 'Blok A', 'Terisi', 'Gudang kecil', '2026-04-23 07:53:20', '2026-05-01 14:11:38'),
(2007040103, NULL, 'Gudang B', 'Bahan Pangan', 'B-1', '5x5', 25.00, 1500000.00, 'Blok B', 'Terisi', 'Gudang sedang', '2026-04-23 07:53:20', '2026-05-01 14:11:38'),
(2007040104, NULL, 'Gudang B', 'Bahan Pangan', 'B-2', '10x10', 100.00, 3000000.00, 'Blok B', 'Tersedia', 'Gudang sedang', '2026-04-23 07:53:20', '2026-05-01 14:11:39'),
(2007040105, NULL, 'Gudang C', 'Bahan Bangunan', 'C-1', '5x5', 25.00, 1500000.00, 'Blok C', 'Tersedia', 'Gudang besar', '2026-04-23 07:53:20', '2026-05-01 14:11:38'),
(2007040106, NULL, 'Gudang C', 'Bahan Bangunan', 'C-2', '8x8', 64.00, 2000000.00, 'Blok C', 'Terisi', 'Gudang besar', '2026-04-23 07:53:20', '2026-05-01 14:11:38'),
(2007040107, NULL, 'Gudang D', 'Tekstil', 'D-1', '4x4', 16.00, 1000000.00, 'Blok D', 'Terisi', 'Gudang kecil', '2026-04-23 07:53:20', '2026-06-13 06:48:19'),
(2007040108, NULL, 'Gudang D', 'Tekstil', 'D-2', '5x5', 25.00, 1500000.00, 'Blok D', 'Tersedia', 'Gudang sedang', '2026-04-23 07:53:20', '2026-05-01 14:11:38'),
(2007040109, NULL, 'Gudang E', 'Logistik & Distribusi', 'E-1', '10x10', 100.00, 3000000.00, 'Blok E', 'Terisi', 'Gudang besar', '2026-04-23 07:53:20', '2026-05-01 14:11:39'),
(2007040110, NULL, 'Gudang E', 'Peralatan & Mesin', 'E-1', '10x10', 100.00, 3000000.00, 'Blok E', 'Terisi', 'Gudang besar', '2026-04-23 07:53:20', '2026-05-01 14:11:39'),
(2007040111, NULL, 'Gudang F', 'Otomotif', 'F-1', '6x6', 36.00, 1800000.00, 'Blok F', 'Terisi', 'Gudang sparepart mobil', '2026-04-29 09:45:47', '2026-05-17 13:31:07'),
(2007040112, NULL, 'Gudang F', 'Otomotif', 'F-2', '8x8', 64.00, 2500000.00, 'Blok F', 'Tersedia', 'Bengkel & gudang', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040113, NULL, 'Gudang F', 'Otomotif', 'F-3', '10x10', 100.00, 3500000.00, 'Blok F', 'Tersedia', 'Showroom & gudang', '2026-04-29 09:45:47', '2026-05-01 14:11:39'),
(2007040114, NULL, 'Gudang G', 'Farmasi', 'G-1', '5x5', 25.00, 2000000.00, 'Blok G', 'Tersedia', 'Cold storage obat', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040115, NULL, 'Gudang G', 'Farmasi', 'G-2', '6x6', 36.00, 2500000.00, 'Blok G', 'Tersedia', 'Alat kesehatan', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040116, NULL, 'Gudang H', 'Makanan', 'H-1', '7x7', 49.00, 2200000.00, 'Blok H', 'Tersedia', 'Makanan Kemasan', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040117, NULL, 'Gudang H', 'Minuman', 'H-2', '9x9', 81.00, 3000000.00, 'Blok H', 'Tersedia', 'Minuman Kemasan', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040118, NULL, 'Gudang I', 'Kimia & Industri', 'I-1', '8x8', 64.00, 3000000.00, 'Blok I', 'Tersedia', 'Safety standard', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040119, NULL, 'Gudang I', 'Kimia & Industri', 'I-2', '10x10', 100.00, 4000000.00, 'Blok I', 'Tersedia', 'Heavy duty', '2026-04-29 09:45:47', '2026-05-01 14:11:39'),
(2007040120, NULL, 'Gudang J', 'Pertanian', 'J-1', '8x8', 64.00, 2000000.00, 'Blok J', 'Tersedia', 'Gudang pupuk', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040121, NULL, 'Gudang J', 'Pertanian', 'J-2', '10x10', 100.00, 3000000.00, 'Blok J', 'Tersedia', 'Alat pertanian', '2026-04-29 09:45:47', '2026-05-01 14:11:39'),
(2007040122, NULL, 'Gudang K', 'Kosmetik', 'K-1', '5x5', 25.00, 2000000.00, 'Blok K', 'Tersedia', 'Beauty & personal care', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040123, NULL, 'Gudang K', 'Kosmetik', 'K-2', '6x6', 36.00, 2500000.00, 'Blok K', 'Tersedia', 'Skincare & makeup', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040124, NULL, 'Gudang L', 'Packaging', 'L-1', '7x7', 49.00, 2000000.00, 'Blok L', 'Tersedia', 'Kardus, plastik, botol', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040125, NULL, 'Gudang L', 'Packaging', 'L-2', '9x9', 81.00, 2800000.00, 'Blok L', 'Tersedia', 'Industrial packaging', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040126, NULL, 'Gudang M', 'Furniture', 'M-1', '6x6', 36.00, 1800000.00, 'Blok M', 'Tersedia', 'Gudang furniture & dekorasi', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040127, NULL, 'Gudang M', 'Furniture', 'M-2', '8x8', 64.00, 2500000.00, 'Blok M', 'Tersedia', 'Gudang mebel besar', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040128, NULL, 'Gudang M', 'Furniture', 'M-3', '10x10', 100.00, 3500000.00, 'Blok M', 'Tersedia', 'Showroom furniture', '2026-04-29 09:45:47', '2026-05-01 14:11:39'),
(2007040129, NULL, 'Gudang N', 'Olahraga', 'N-1', '5x5', 25.00, 1500000.00, 'Blok N', 'Tersedia', 'Alat olahraga & fitness', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040130, NULL, 'Gudang N', 'Olahraga', 'N-2', '7x7', 49.00, 2200000.00, 'Blok N', 'Tersedia', 'Gudang sepeda & aksesoris', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040131, NULL, 'Gudang O', 'Penerbitan', 'O-1', '6x6', 36.00, 1600000.00, 'Blok O', 'Tersedia', 'Gudang buku & majalah', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040132, NULL, 'Gudang O', 'Penerbitan', 'O-2', '8x8', 64.00, 2300000.00, 'Blok O', 'Tersedia', 'Gudang buku & majalah', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040133, NULL, 'Gudang P', 'Komponen Elektronik', 'P-1', '4x4', 16.00, 1800000.00, 'Blok P', 'Tersedia', 'IC resistor capacitor', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040134, NULL, 'Gudang P', 'Komponen Elektronik', 'P-2', '7x7', 49.00, 2500000.00, 'Blok P', 'Tersedia', 'PCB & sparepart', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040135, NULL, 'Gudang P', 'Komponen Elektronik', 'P-3', '5x5', 25.00, 2000000.00, 'Blok P', 'Tersedia', 'Kabel switch panel', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040136, NULL, 'Gudang P', 'Komponen Elektronik', 'P-4', '7x7', 49.00, 3000000.00, 'Blok P', 'Tersedia', 'Industrial electrical', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040137, NULL, 'Gudang Q', 'Mainan & Hobi', 'Q-1', '5x5', 25.00, 1500000.00, 'Blok Q', 'Tersedia', 'Toys & games', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040138, NULL, 'Gudang Q', '7x7', 'Q-2', '7x7', 49.00, 2200000.00, 'Blok Q', 'Tersedia', 'Toys & games', '2026-04-29 09:45:47', '2026-05-07 15:26:55'),
(2007040139, NULL, 'Gudang R', 'Alat Kesehatan', 'R-1', '6x6', 36.00, 2500000.00, 'Blok R', 'Tersedia', 'Medical equipment', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040140, NULL, 'Gudang R', 'Alat Kesehatan', 'R-2', '8x8', 64.00, 3500000.00, 'Blok R', 'Tersedia', 'RS & klinik', '2026-04-29 09:45:47', '2026-05-01 14:11:38'),
(2007040141, NULL, 'Gudang A', '4x4', 'Blok A', '4x4', 0.00, 5000000.00, 'Blok A', 'Tersedia', '', '2026-05-07 15:25:46', '2026-05-07 15:25:46'),
(2007040143, NULL, 'test', 'Umum', NULL, '5x5', 0.00, 3000000.00, 'Q-1', 'Terisi', 'sudah disewa', '2026-05-08 06:39:39', '2026-05-08 06:39:39'),
(2007040144, NULL, 'Gudang A', 'Elektronik', NULL, '4x4', 0.00, 100000000.00, 'Blok A', 'Tersedia', 'Gudang kecil', '2026-05-08 06:44:03', '2026-05-08 06:44:03'),
(2007040145, NULL, 'Gudang A', 'Elektronik', NULL, '4x4', 0.00, 1000000.00, 'Blok A', 'Terisi', 'Gudang kecil', '2026-05-08 07:13:34', '2026-05-16 13:27:40'),
(2007040146, NULL, 'test', 'VIP', NULL, '5x5', 0.00, 3000000.00, 'Q-1', 'Terisi', 'sudah disewa', '2026-05-11 09:23:59', '2026-05-11 09:23:59'),
(2007040147, NULL, 'Gudang A', 'Elektronik', NULL, '4x4', 0.00, 1000000.00, 'Blok A', 'Tersedia', 'Gudang kecil', '2026-05-11 09:24:30', '2026-05-11 09:24:30'),
(2007040148, NULL, 'Gudang A', 'Elektronik', NULL, '4x4', 0.00, 1000000.00, 'Blok A', 'Terisi', 'Gudang kecil', '2026-05-11 09:24:42', '2026-05-12 09:06:06');

-- --------------------------------------------------------

--
-- Struktur dari tabel `isi_gudang`
--

CREATE TABLE `isi_gudang` (
  `id_isi` int(11) NOT NULL,
  `no_kontrak` varchar(20) DEFAULT NULL,
  `nama_produk` varchar(100) NOT NULL,
  `kategori_produk` varchar(50) NOT NULL,
  `jumlah` decimal(10,2) NOT NULL,
  `satuan` varchar(20) DEFAULT NULL,
  `volume_m3` decimal(10,2) NOT NULL,
  `tanggal_input` timestamp NOT NULL DEFAULT current_timestamp(),
  `keterangan` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `isi_gudang`
--

INSERT INTO `isi_gudang` (`id_isi`, `no_kontrak`, `nama_produk`, `kategori_produk`, `jumlah`, `satuan`, `volume_m3`, `tanggal_input`, `keterangan`) VALUES
(6, '1', 'kipas', 'Elektronik', 10.00, 'Pcs', 5.00, '2026-05-14 03:42:19', ''),
(7, 'KTR-20260512-004', 'Laptop', 'Elektronik', 12.00, 'Pcs', 2.00, '2026-05-15 13:22:38', '6 pcs dalam 1 box'),
(8, 'KTR-20260516-004', 'laptop', 'Elektronik', 10.00, 'Box', 10.00, '2026-05-16 13:28:26', '1 box isi 6 pcs'),
(9, 'KTR-20260517-005', 'rangka cbr250rr', 'Otomotif', 2.00, 'Pcs', 10.00, '2026-05-17 13:31:07', ''),
(10, 'KTR-20260613-007', 'semen', 'Tekstil', 10.00, 'Pcs', 10.00, '2026-06-13 06:49:40', ''),
(11, 'KTR-20260613-007', 'besi', 'Tekstil', 3.00, 'Pcs', 3.00, '2026-06-13 08:34:00', '');

-- --------------------------------------------------------

--
-- Struktur dari tabel `kategori_gudang`
--

CREATE TABLE `kategori_gudang` (
  `id_kategori` int(11) NOT NULL,
  `nama_kategori` varchar(50) DEFAULT NULL,
  `deskripsi` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `kontrak`
--

CREATE TABLE `kontrak` (
  `no_kontrak` varchar(20) NOT NULL,
  `no_kontrak_lama` varchar(30) DEFAULT NULL,
  `id_penyewa` int(11) DEFAULT NULL,
  `kode_gudang` int(11) DEFAULT NULL,
  `kategori_gudang` varchar(50) DEFAULT NULL,
  `gudang_area` varchar(10) DEFAULT NULL,
  `gudang_ukuran` varchar(20) DEFAULT NULL,
  `gudang_nama` varchar(100) DEFAULT NULL,
  `tgl_mulai` date DEFAULT NULL,
  `tgl_selesai` date DEFAULT NULL,
  `total_harga` decimal(12,2) DEFAULT NULL,
  `status` varchar(20) DEFAULT 'Aktif',
  `jenis_kontrak` enum('Baru','Perpanjangan','Tambah Gudang') DEFAULT 'Baru',
  `total_kontrak` decimal(15,2) DEFAULT 0.00,
  `sisa_bayar` decimal(15,2) DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `kontrak`
--

INSERT INTO `kontrak` (`no_kontrak`, `no_kontrak_lama`, `id_penyewa`, `kode_gudang`, `kategori_gudang`, `gudang_area`, `gudang_ukuran`, `gudang_nama`, `tgl_mulai`, `tgl_selesai`, `total_harga`, `status`, `jenis_kontrak`, `total_kontrak`, `sisa_bayar`) VALUES
('1', NULL, 1, 2007040102, 'Elektronik', 'A-2', '8x8', 'Gudang A', '2026-01-15', '2026-04-25', 1500000.00, 'Aktif', 'Baru', 0.00, 0.00),
('2', NULL, 2, 2007040103, 'Bahan Pangan', 'B-1', '5x5', 'Gudang B', '2026-02-01', '2026-05-01', 3000000.00, 'Aktif', 'Baru', 0.00, 0.00),
('3', NULL, 3, 2007040106, 'Bahan Bangunan', 'C-2', '8x8', 'Gudang C', '2026-03-01', '2026-04-28', 1500000.00, 'Diperpanjang', 'Baru', 0.00, 0.00),
('4', NULL, 4, 2007040109, 'Logistik & Distribusi', 'E-1', '10x10', 'Gudang E', '2026-01-01', '2026-06-30', 7500000.00, 'Aktif', 'Baru', 0.00, 0.00),
('KTR-20260512-001', NULL, 3, 2007040101, 'Elektronik', 'A-1', '4x4', 'Gudang A', '2026-05-09', '2026-10-09', 5000000.00, 'Aktif', 'Baru', 5000000.00, 5000000.00),
('KTR-20260512-004', NULL, 9, 2007040148, 'Elektronik', '', '4x4', 'Gudang A', '2026-05-12', '2027-05-12', 12000000.00, 'Aktif', 'Baru', 12000000.00, 12000000.00),
('KTR-20260516-004', NULL, 9, 2007040148, 'Elektronik', '', '4x4', 'Gudang A', '2026-05-12', '2027-05-12', 12000000.00, 'Aktif', 'Baru', 12000000.00, 0.00),
('KTR-20260516-006', NULL, 10, 2007040145, 'Elektronik', '', '4x4', 'Gudang A', '2026-05-16', '2026-06-16', 1000000.00, 'Diperpanjang', 'Baru', 1000000.00, 0.00),
('KTR-20260517-005', NULL, 6, 2007040111, 'Otomotif', 'F-1', '6x6', 'Gudang F', '2026-05-12', '2027-03-12', 18000000.00, 'Aktif', 'Baru', 18000000.00, 0.00),
('KTR-20260605-001', NULL, 3, 2007040101, 'Elektronik', 'A-1', '4x4', 'Gudang A', '2026-05-09', '2026-10-09', 5000000.00, 'Aktif', 'Baru', 5000000.00, 0.00),
('KTR-20260613-007', NULL, 11, 2007040107, 'Tekstil', 'D-1', '4x4', 'Gudang D', '2026-06-13', '2026-09-13', 3000000.00, 'Aktif', 'Baru', 3000000.00, 0.00),
('KTR-26-118', NULL, 10, 2007040145, NULL, NULL, NULL, NULL, '2026-12-18', '2027-06-18', 6000000.00, 'Aktif', 'Baru', 0.00, 0.00),
('KTR-26-325', NULL, 3, 2007040106, NULL, NULL, NULL, NULL, '2026-04-29', '2026-10-29', 9000000.00, 'Aktif', 'Baru', 0.00, 0.00),
('KTR-26-327', NULL, 10, 2007040145, NULL, NULL, NULL, NULL, '2026-06-17', '2026-12-17', 6000000.00, 'Diperpanjang', 'Baru', 0.00, 0.00);

-- --------------------------------------------------------

--
-- Struktur dari tabel `pembayaran`
--

CREATE TABLE `pembayaran` (
  `id_pembayaran` int(11) NOT NULL,
  `no_kontrak` varchar(20) DEFAULT NULL,
  `id_booking` int(11) DEFAULT NULL,
  `gudang_area` varchar(10) DEFAULT NULL,
  `gudang_ukuran` varchar(20) DEFAULT NULL,
  `tgl_bayar` date DEFAULT NULL,
  `nominal` decimal(12,2) NOT NULL DEFAULT 0.00,
  `denda` decimal(12,2) NOT NULL DEFAULT 0.00,
  `total_bayar` decimal(12,2) NOT NULL DEFAULT 0.00,
  `metode` varchar(50) NOT NULL DEFAULT 'Tunai',
  `keterangan` text DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `status` varchar(20) NOT NULL DEFAULT 'Pending'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `pembayaran`
--

INSERT INTO `pembayaran` (`id_pembayaran`, `no_kontrak`, `id_booking`, `gudang_area`, `gudang_ukuran`, `tgl_bayar`, `nominal`, `denda`, `total_bayar`, `metode`, `keterangan`, `created_at`, `status`) VALUES
(4, 'KTR-20260517-005', 5, NULL, NULL, '2026-05-15', 18000000.00, 0.00, 0.00, 'Tagihan', 'Menunggu Pembayaran', '2026-05-15 09:19:59', 'Pending'),
(6, 'KTR-20260512-001', NULL, NULL, NULL, '2026-05-15', 5000000.00, 0.00, 5000000.00, 'Tunai', '', '2026-05-15 13:20:29', 'Lunas'),
(7, '4', NULL, NULL, NULL, '2026-05-15', 7500000.00, 0.00, 7500000.00, 'Tunai', '', '2026-05-15 13:20:40', 'Lunas'),
(8, 'KTR-26-325', NULL, NULL, NULL, '2026-05-16', 9000000.00, 0.00, 9000000.00, 'Tunai', '', '2026-05-16 06:23:45', 'Lunas'),
(9, 'KTR-20260516-006', 6, NULL, NULL, '2026-05-16', 1000000.00, 0.00, 0.00, 'Tagihan', 'Menunggu Pembayaran', '2026-05-16 12:32:21', 'Pending'),
(10, 'KTR-20260516-006', 6, NULL, NULL, '2026-05-16', 1000000.00, 0.00, 1000000.00, 'Tunai', '', '2026-05-16 13:27:40', 'Lunas'),
(11, 'KTR-20260516-004', 4, NULL, NULL, '2026-05-16', 12000000.00, 0.00, 12000000.00, 'Tunai', '', '2026-05-16 13:28:26', 'Lunas'),
(12, '1', NULL, NULL, NULL, '2026-05-17', 1500000.00, 110000.00, 1610000.00, 'Tunai', '', '2026-05-17 13:30:42', 'Lunas'),
(13, 'KTR-20260512-004', NULL, NULL, NULL, '2026-05-17', 12000000.00, 0.00, 12000000.00, 'Tunai', '', '2026-05-17 13:30:51', 'Lunas'),
(14, 'KTR-20260517-005', 5, NULL, NULL, '2026-05-17', 18000000.00, 0.00, 18000000.00, 'Tunai', '', '2026-05-17 13:31:07', 'Lunas'),
(15, 'KTR-26-118', NULL, NULL, NULL, '2026-06-05', 6000000.00, 0.00, 6000000.00, 'Tunai', '', '2026-06-05 05:29:50', 'Lunas'),
(16, 'KTR-20260605-001', 1, NULL, NULL, '2026-06-05', 5000000.00, 0.00, 5000000.00, 'Tunai', '', '2026-06-05 05:30:26', 'Lunas'),
(17, 'KTR-20260613-007', 7, NULL, NULL, '2026-06-13', 3000000.00, 0.00, 0.00, 'Tagihan', 'Menunggu Pembayaran', '2026-06-13 06:47:25', 'Pending'),
(18, 'KTR-20260613-007', 7, NULL, NULL, '2026-06-13', 3000000.00, 0.00, 3000000.00, 'Tunai', '', '2026-06-13 06:48:19', 'Lunas');

-- --------------------------------------------------------

--
-- Struktur dari tabel `penyewa`
--

CREATE TABLE `penyewa` (
  `id_penyewa` int(11) NOT NULL,
  `jenis_penyewa` enum('perorangan','perusahaan') DEFAULT 'perorangan',
  `no_identitas` varchar(50) DEFAULT NULL,
  `nama_perusahaan` varchar(100) DEFAULT NULL,
  `npwp` varchar(20) DEFAULT NULL,
  `nama_penyewa` varchar(50) DEFAULT NULL,
  `no_hp` varchar(20) DEFAULT NULL,
  `alamat` text DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `status` enum('aktif','non-aktif') DEFAULT 'aktif'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `penyewa`
--

INSERT INTO `penyewa` (`id_penyewa`, `jenis_penyewa`, `no_identitas`, `nama_perusahaan`, `npwp`, `nama_penyewa`, `no_hp`, `alamat`, `email`, `status`) VALUES
(1, 'perorangan', NULL, NULL, NULL, 'Budi Santoso', '2147483647', 'Jl. Merdeka No. 10, Jakarta', NULL, 'aktif'),
(2, 'perorangan', NULL, NULL, NULL, 'Siti Nurhaliza', '2147483647', 'Jl. Sudirman No. 25, Bandung', NULL, 'aktif'),
(3, 'perorangan', NULL, NULL, NULL, 'CV. Jaya Abadi', '2147483647', 'Jl. Ahmad Yani No. 50, Surabaya', NULL, 'aktif'),
(4, 'perorangan', NULL, NULL, NULL, 'Ahmad Rizki', '2147483647', 'Jl. Gatot Subroto No. 15, Jakarta', NULL, 'aktif'),
(5, 'perorangan', NULL, NULL, NULL, 'PT. Maju Mundur', '2147483647', 'Jl. HR Rasuna Said No. 8, Jakarta', NULL, 'aktif'),
(6, 'perusahaan', '001', 'cv. Pratama', '001', 'Ach. Fairozi', '087883706936', 'sumenep', 'rozi01@gmail.com', 'aktif'),
(8, 'perorangan', NULL, NULL, NULL, 'Administrator', '08123456789', 'Jakarta', 'admin@admin.com', 'aktif'),
(9, 'perorangan', '1234567891111111', NULL, NULL, 'ACH. FAIROZI', '087883706936101010', 'sumenep', 'rozi@gmail.com', 'aktif'),
(10, 'perorangan', '4651225431213215', NULL, NULL, 'kgjgh', '012312243543512', 'jkhjjkbnmn', 'gdgth', 'aktif'),
(11, 'perusahaan', '123456', 'cobacoba', '654321', 'coba1', '081884561325', 'jalan 123', 'coba@gmail.com', 'aktif');

-- --------------------------------------------------------

--
-- Struktur dari tabel `riwayat_kontrak`
--

CREATE TABLE `riwayat_kontrak` (
  `id_riwayat` int(11) NOT NULL,
  `no_kontrak` varchar(30) NOT NULL,
  `aksi` varchar(50) NOT NULL,
  `tanggal_aksi` datetime DEFAULT current_timestamp(),
  `keterangan` text DEFAULT NULL,
  `id_user` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `user`
--

CREATE TABLE `user` (
  `id_user` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(25) NOT NULL,
  `role` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `user`
--

INSERT INTO `user` (`id_user`, `username`, `email`, `password`, `role`) VALUES
(123456, 'Rozi', 'rozi@gmail.com', 'rozi123', 'Admin'),
(213465, 'Administrator', 'admin@gmail.com', 'admin123', 'Admin'),
(215463, 'User Demo', 'user@gmail.com', 'user123', 'User'),
(316452, 'Staff Gudang', 'staf@gmail.com', 'staf123', 'Staf');

-- --------------------------------------------------------

--
-- Stand-in struktur untuk tampilan `v_monitor_kapasitas`
-- (Lihat di bawah untuk tampilan aktual)
--
CREATE TABLE `v_monitor_kapasitas` (
`no_kontrak` varchar(20)
,`kapasitas_total` decimal(10,2)
,`volume_terpakai` decimal(32,2)
,`sisa_kapasitas` decimal(33,2)
,`persentase_isi` decimal(38,2)
,`status_isi` varchar(8)
);

-- --------------------------------------------------------

--
-- Struktur untuk view `v_monitor_kapasitas`
--
DROP TABLE IF EXISTS `v_monitor_kapasitas`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_monitor_kapasitas`  AS SELECT `k`.`no_kontrak` AS `no_kontrak`, `g`.`kapasitas_m3` AS `kapasitas_total`, coalesce(sum(`i`.`volume_m3`),0) AS `volume_terpakai`, `g`.`kapasitas_m3`- coalesce(sum(`i`.`volume_m3`),0) AS `sisa_kapasitas`, round(coalesce(sum(`i`.`volume_m3`),0) / nullif(`g`.`kapasitas_m3`,0) * 100,2) AS `persentase_isi`, CASE WHEN coalesce(sum(`i`.`volume_m3`),0) >= `g`.`kapasitas_m3` THEN 'PENUH' WHEN coalesce(sum(`i`.`volume_m3`),0) > 0 THEN 'SEBAGIAN' ELSE 'KOSONG' END AS `status_isi` FROM ((`kontrak` `k` join `gudang` `g` on(`k`.`kode_gudang` = `g`.`kode_gudang`)) left join `isi_gudang` `i` on(`k`.`no_kontrak` = `i`.`no_kontrak`)) WHERE `k`.`status` = 'Aktif' GROUP BY `k`.`no_kontrak`, `g`.`kapasitas_m3` ;

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `area_gudang`
--
ALTER TABLE `area_gudang`
  ADD PRIMARY KEY (`id_area`),
  ADD KEY `id_kategori` (`id_kategori`);

--
-- Indeks untuk tabel `booking_barang`
--
ALTER TABLE `booking_barang`
  ADD PRIMARY KEY (`id_barang`),
  ADD KEY `id_booking` (`id_booking`);

--
-- Indeks untuk tabel `booking_request`
--
ALTER TABLE `booking_request`
  ADD PRIMARY KEY (`id_booking`),
  ADD KEY `kode_gudang` (`kode_gudang`),
  ADD KEY `fk_booking_id_penyewa` (`id_penyewa`);

--
-- Indeks untuk tabel `detail_kontrak`
--
ALTER TABLE `detail_kontrak`
  ADD PRIMARY KEY (`id_detail`),
  ADD KEY `idx_no_kontrak` (`no_kontrak`),
  ADD KEY `idx_kode_gudang` (`kode_gudang`);

--
-- Indeks untuk tabel `gudang`
--
ALTER TABLE `gudang`
  ADD PRIMARY KEY (`kode_gudang`),
  ADD KEY `idx_status` (`status`),
  ADD KEY `idx_lokasi` (`lokasi`),
  ADD KEY `id_area` (`id_area`);

--
-- Indeks untuk tabel `isi_gudang`
--
ALTER TABLE `isi_gudang`
  ADD PRIMARY KEY (`id_isi`),
  ADD KEY `fk_isi_no_kontrak` (`no_kontrak`);

--
-- Indeks untuk tabel `kategori_gudang`
--
ALTER TABLE `kategori_gudang`
  ADD PRIMARY KEY (`id_kategori`);

--
-- Indeks untuk tabel `kontrak`
--
ALTER TABLE `kontrak`
  ADD PRIMARY KEY (`no_kontrak`),
  ADD KEY `idx_penyewa` (`id_penyewa`),
  ADD KEY `idx_gudang` (`kode_gudang`),
  ADD KEY `idx_status` (`status`);

--
-- Indeks untuk tabel `pembayaran`
--
ALTER TABLE `pembayaran`
  ADD PRIMARY KEY (`id_pembayaran`),
  ADD KEY `fk_bayar_no_kontrak` (`no_kontrak`);

--
-- Indeks untuk tabel `penyewa`
--
ALTER TABLE `penyewa`
  ADD PRIMARY KEY (`id_penyewa`);

--
-- Indeks untuk tabel `riwayat_kontrak`
--
ALTER TABLE `riwayat_kontrak`
  ADD PRIMARY KEY (`id_riwayat`),
  ADD KEY `fk_riwayat_no_kontrak` (`no_kontrak`),
  ADD KEY `fk_riwayat_id_user` (`id_user`);

--
-- Indeks untuk tabel `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id_user`),
  ADD UNIQUE KEY `username` (`email`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `area_gudang`
--
ALTER TABLE `area_gudang`
  MODIFY `id_area` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `booking_barang`
--
ALTER TABLE `booking_barang`
  MODIFY `id_barang` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT untuk tabel `booking_request`
--
ALTER TABLE `booking_request`
  MODIFY `id_booking` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT untuk tabel `detail_kontrak`
--
ALTER TABLE `detail_kontrak`
  MODIFY `id_detail` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT untuk tabel `gudang`
--
ALTER TABLE `gudang`
  MODIFY `kode_gudang` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2007040149;

--
-- AUTO_INCREMENT untuk tabel `isi_gudang`
--
ALTER TABLE `isi_gudang`
  MODIFY `id_isi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT untuk tabel `kategori_gudang`
--
ALTER TABLE `kategori_gudang`
  MODIFY `id_kategori` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `pembayaran`
--
ALTER TABLE `pembayaran`
  MODIFY `id_pembayaran` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT untuk tabel `penyewa`
--
ALTER TABLE `penyewa`
  MODIFY `id_penyewa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT untuk tabel `riwayat_kontrak`
--
ALTER TABLE `riwayat_kontrak`
  MODIFY `id_riwayat` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `user`
--
ALTER TABLE `user`
  MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=316453;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `area_gudang`
--
ALTER TABLE `area_gudang`
  ADD CONSTRAINT `area_gudang_ibfk_1` FOREIGN KEY (`id_kategori`) REFERENCES `kategori_gudang` (`id_kategori`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `booking_barang`
--
ALTER TABLE `booking_barang`
  ADD CONSTRAINT `booking_barang_ibfk_1` FOREIGN KEY (`id_booking`) REFERENCES `booking_request` (`id_booking`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `booking_request`
--
ALTER TABLE `booking_request`
  ADD CONSTRAINT `booking_request_ibfk_1` FOREIGN KEY (`id_penyewa`) REFERENCES `penyewa` (`id_penyewa`),
  ADD CONSTRAINT `booking_request_ibfk_2` FOREIGN KEY (`kode_gudang`) REFERENCES `gudang` (`kode_gudang`),
  ADD CONSTRAINT `fk_booking_id_penyewa` FOREIGN KEY (`id_penyewa`) REFERENCES `penyewa` (`id_penyewa`) ON UPDATE CASCADE;

--
-- Ketidakleluasaan untuk tabel `detail_kontrak`
--
ALTER TABLE `detail_kontrak`
  ADD CONSTRAINT `fk_detail_gudang` FOREIGN KEY (`kode_gudang`) REFERENCES `gudang` (`kode_gudang`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_detail_kontrak` FOREIGN KEY (`no_kontrak`) REFERENCES `kontrak` (`no_kontrak`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ketidakleluasaan untuk tabel `gudang`
--
ALTER TABLE `gudang`
  ADD CONSTRAINT `gudang_ibfk_1` FOREIGN KEY (`id_area`) REFERENCES `area_gudang` (`id_area`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `isi_gudang`
--
ALTER TABLE `isi_gudang`
  ADD CONSTRAINT `fk_isi_gudang_kontrak` FOREIGN KEY (`no_kontrak`) REFERENCES `kontrak` (`no_kontrak`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_isi_no_kontrak` FOREIGN KEY (`no_kontrak`) REFERENCES `kontrak` (`no_kontrak`) ON UPDATE CASCADE;

--
-- Ketidakleluasaan untuk tabel `kontrak`
--
ALTER TABLE `kontrak`
  ADD CONSTRAINT `fk_kontrak_id_penyewa` FOREIGN KEY (`id_penyewa`) REFERENCES `penyewa` (`id_penyewa`) ON UPDATE CASCADE,
  ADD CONSTRAINT `kontrak_ibfk_1` FOREIGN KEY (`id_penyewa`) REFERENCES `penyewa` (`id_penyewa`),
  ADD CONSTRAINT `kontrak_ibfk_2` FOREIGN KEY (`kode_gudang`) REFERENCES `gudang` (`kode_gudang`);

--
-- Ketidakleluasaan untuk tabel `pembayaran`
--
ALTER TABLE `pembayaran`
  ADD CONSTRAINT `fk_bayar_no_kontrak` FOREIGN KEY (`no_kontrak`) REFERENCES `kontrak` (`no_kontrak`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_pembayaran_kontrak` FOREIGN KEY (`no_kontrak`) REFERENCES `kontrak` (`no_kontrak`);

--
-- Ketidakleluasaan untuk tabel `riwayat_kontrak`
--
ALTER TABLE `riwayat_kontrak`
  ADD CONSTRAINT `fk_riwayat_id_user` FOREIGN KEY (`id_user`) REFERENCES `user` (`id_user`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_riwayat_kontrak_kontrak` FOREIGN KEY (`no_kontrak`) REFERENCES `kontrak` (`no_kontrak`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_riwayat_no_kontrak` FOREIGN KEY (`no_kontrak`) REFERENCES `kontrak` (`no_kontrak`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_riwayat_user` FOREIGN KEY (`id_user`) REFERENCES `user` (`id_user`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
