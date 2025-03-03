ALTER SESSION SET "_ORACLE_SCRIPT"=TRUE;

DROP USER QLDL CASCADE;

// tao admin quan ly DU LIEU
CREATE USER QLDL IDENTIFIED BY 123;
GRANT ALL PRIVILEGES TO QLDL;

CREATE TABLE QLDL.NHANSU (
    MANV CHAR(5) PRIMARY KEY,
    HOTEN NVARCHAR2(255),
    PHAI CHAR(1),
    NGSINH DATE,
    PHUCAP INT,
    SDT VARCHAR(11),
    VAITRO NVARCHAR2(100),
    MADV VARCHAR(10)
);

CREATE TABLE QLDL.SINHVIEN(
    MASV CHAR(5)PRIMARY KEY,
    HOTEN NVARCHAR2(255),
    PHAI CHAR(1), 
    NGSINH DATE,
    DCHI NVARCHAR2(255),
    SDT VARCHAR(11),
    MACT CHAR(5),
    MANGANH VARCHAR(10),
    SOTCTL INT,
    DTBTL NUMBER(2,0) CHECK (DTBTL >= 1 AND DTBTL <= 10)
    
);

CREATE TABLE QLDL.DONVI (
    MADV VARCHAR(10)PRIMARY KEY,
    TENDV NVARCHAR2(100),
    TRGDV CHAR(5)
);

CREATE TABLE QLDL.HOCPHAN (
    MAHP CHAR(5)PRIMARY KEY,
    TENHP NVARCHAR2(100),
    SOTC INT,
    STLT INT,
    STTH INT,
    SOSVTD INT,
    MADV VARCHAR(10)
);

CREATE TABLE QLDL.KHMO (
    MAHP CHAR(5),
    HK CHAR(3),
    NAM INT,
    MACT CHAR(5),
    PRIMARY KEY (MAHP, HK, NAM, MACT)
);

CREATE TABLE QLDL.PHANCONG(
    MAGV CHAR(5),
    MAHP CHAR(5),
    HK CHAR(3),
    NAM INT,
    MACT CHAR(5),
    PRIMARY KEY (MAGV, MAHP, HK, NAM, MACT)
);

CREATE TABLE QLDL.DANGKY (
    MASV CHAR(5),
    MAGV CHAR(5),
    MAHP CHAR(5),
    HK CHAR(3),
    NAM INT,
    MACT CHAR(5),
    DIEMTH NUMBER(3,1) CHECK (DIEMTH >= 1 AND DIEMTH <= 10),
    DIEMQT NUMBER(3,1) CHECK (DIEMQT >= 1 AND DIEMQT <= 10),
    DIEMCK NUMBER(3,1) CHECK (DIEMCK >= 1 AND DIEMCK <= 10),
    DIEMTK NUMBER(3,1) CHECK (DIEMTK >= 1 AND DIEMTK <= 10),
    
    PRIMARY KEY (MASV, MAGV, MAHP, HK, NAM, MACT)
);

// TAO KHOA NGOAI
ALTER TABLE QLDL.NHANSU
ADD CONSTRAINT fk_NHANSU_DONVI FOREIGN KEY (MADV)
REFERENCES QLDL.DONVI(MADV);

ALTER TABLE QLDL.DONVI
ADD CONSTRAINT fk_DONVI_NHANSU FOREIGN KEY (TRGDV)
REFERENCES QLDL.NHANSU(MANV);

ALTER TABLE QLDL.HOCPHAN
ADD CONSTRAINT fk_HOCPHAN_DONVI FOREIGN KEY (MADV)
REFERENCES QLDL.DONVI(MADV);

ALTER TABLE QLDL.KHMO
ADD CONSTRAINT fk_KHMO_MAHP FOREIGN KEY (MAHP) 
REFERENCES QLDL.HOCPHAN(MAHP);

ALTER TABLE QLDL.PHANCONG
ADD CONSTRAINT fk_PHANCONG_KHMO FOREIGN KEY (MAHP,HK,NAM,MACT) 
REFERENCES QLDL.KHMO(MAHP,HK,NAM,MACT);

ALTER TABLE QLDL.PHANCONG
ADD CONSTRAINT fk_PHANCONG_MAGV FOREIGN KEY (MAGV) 
REFERENCES QLDL.NHANSU(MANV);

ALTER TABLE QLDL.DANGKY
ADD CONSTRAINT fk_DANGKY_MAGV FOREIGN KEY (MASV) 
REFERENCES QLDL.SINHVIEN(MASV);

ALTER TABLE QLDL.DANGKY
ADD CONSTRAINT fk_DANGKY_NHANSU FOREIGN KEY (MAGV) 
REFERENCES QLDL.NHANSU(MANV);

ALTER TABLE QLDL.DANGKY
ADD CONSTRAINT fk_DANGKY_KHMO FOREIGN KEY (MAHP, HK, NAM, MACT) 
REFERENCES QLDL.KHMO(MAHP, HK, NAM, MACT);


// INSERT DATA
-- Insert du lieu vao bang DONVI
INSERT INTO QLDL.DONVI VALUES ('DV001', N'Van phong khoa', NULL);
INSERT INTO QLDL.DONVI VALUES ('DV002', N'Bo mon HTTT', NULL);
INSERT INTO QLDL.DONVI VALUES ('DV003', N'Bo mon CNPM', NULL);
INSERT INTO QLDL.DONVI VALUES ('DV004', N'Bo mon KHMT', NULL);
INSERT INTO QLDL.DONVI VALUES ('DV005', N'Bo mon CNTT', NULL);
INSERT INTO QLDL.DONVI VALUES ('DV006', N'Bo mon TGMT', NULL);
INSERT INTO QLDL.DONVI VALUES ('DV007', N'Bo mon MMT', NULL);

-- Insert du lieu vao bang NHANSU
-- NVCB
INSERT INTO QLDL.NHANSU  VALUES ('NV001', N'Nguyen Van A', 'M', TO_DATE('1980-01-01', 'YYYY-MM-DD'), 1000, '0901123456', N'Nhan vien co ban', 'DV001');
INSERT INTO QLDL.NHANSU  VALUES ('NV002', N'Tran Thi B', 'F', TO_DATE('1985-02-02', 'YYYY-MM-DD'), 2000, '0901234567', N'Nhan vien co ban', 'DV002');
INSERT INTO QLDL.NHANSU  VALUES ('NV003', N'Le Van C', 'M', TO_DATE('1990-03-03', 'YYYY-MM-DD'), 1500, '0901345678', N'Nhan vien co ban', 'DV003');
INSERT INTO QLDL.NHANSU  VALUES ('NV004', N'Pham Thi D', 'F', TO_DATE('1983-04-04', 'YYYY-MM-DD'), 2500, '0901456789', N'TNhan vien co ban', 'DV004');
INSERT INTO QLDL.NHANSU  VALUES ('NV005', N'Hoang Ven E', 'M', TO_DATE('1975-05-05', 'YYYY-MM-DD'), 3000, '0901567890', N'Nhan vien co ban', 'DV005');
INSERT INTO QLDL.NHANSU  VALUES ('NV006', N'Nguyen Van F', 'M', TO_DATE('1980-01-01', 'YYYY-MM-DD'), 1000, '0901123456', N'Nhan vien co ban', 'DV006');
INSERT INTO QLDL.NHANSU  VALUES ('NV007', N'Tran Thi G', 'F', TO_DATE('1985-02-02', 'YYYY-MM-DD'), 2000, '0901234567', N'Nhan vien co ban', 'DV007');
INSERT INTO QLDL.NHANSU  VALUES ('NV008', N'Le Van H', 'M', TO_DATE('1990-03-03', 'YYYY-MM-DD'), 1500, '0901345678', N'Nhan vien co ban', 'DV001');
INSERT INTO QLDL.NHANSU  VALUES ('NV009', N'Pham Thi I', 'F', TO_DATE('1983-04-04', 'YYYY-MM-DD'), 2500, '0901456789', N'Nhan vien co ban', 'DV002');
INSERT INTO QLDL.NHANSU  VALUES ('NV010', N'Hoang Ven J', 'M', TO_DATE('1975-05-05', 'YYYY-MM-DD'), 3000, '0901567890', N'Nhan vien co ban', 'DV003');
-- GV
INSERT INTO QLDL.NHANSU  VALUES ('GV001', N'Nguyen Van K', 'M', TO_DATE('1980-01-01', 'YYYY-MM-DD'), 1000, '0901123456', N'Giang vien', 'DV001');
INSERT INTO QLDL.NHANSU  VALUES ('GV002', N'Tran Thi L', 'F', TO_DATE('1985-02-02', 'YYYY-MM-DD'), 2000, '0901234567', N'Giang vien', 'DV002');
INSERT INTO QLDL.NHANSU  VALUES ('GV003', N'Le Van M', 'M', TO_DATE('1990-03-03', 'YYYY-MM-DD'), 1500, '0901345678', N'Giang vien', 'DV003');
INSERT INTO QLDL.NHANSU  VALUES ('GV004', N'Pham Thi N', 'F', TO_DATE('1983-04-04', 'YYYY-MM-DD'), 2500, '0901456789', N'Giang vien', 'DV004');
INSERT INTO QLDL.NHANSU  VALUES ('GV005', N'Hoang Ven O', 'M', TO_DATE('1975-05-05', 'YYYY-MM-DD'), 3000, '0901567890', N'Giang vien', 'DV005');
INSERT INTO QLDL.NHANSU  VALUES ('GV006', N'Nguyen Van P', 'M', TO_DATE('1980-01-01', 'YYYY-MM-DD'), 1000, '0901123456', N'Giang vien', 'DV006');
INSERT INTO QLDL.NHANSU  VALUES ('GV007', N'Tran Thi Q', 'F', TO_DATE('1985-02-02', 'YYYY-MM-DD'), 2000, '0901234567', N'Giang vien', 'DV007');
INSERT INTO QLDL.NHANSU  VALUES ('GV008', N'Le Van R', 'M', TO_DATE('1990-03-03', 'YYYY-MM-DD'), 1500, '0901345678', N'Giang vien', 'DV001');
INSERT INTO QLDL.NHANSU  VALUES ('GV009', N'Pham Thi S', 'F', TO_DATE('1983-04-04', 'YYYY-MM-DD'), 2500, '0901456789', N'Giang vien', 'DV002');
INSERT INTO QLDL.NHANSU  VALUES ('GV010', N'Hoang Ven T', 'M', TO_DATE('1975-05-05', 'YYYY-MM-DD'), 3000, '0901567890', N'Giang vien', 'DV003');
-- GIAOVU
INSERT INTO QLDL.NHANSU  VALUES ('GVU01', N'Nguyen Van U', 'M', TO_DATE('1980-01-01', 'YYYY-MM-DD'), 1000, '0901123456', N'Giao vu', 'DV001');
INSERT INTO QLDL.NHANSU  VALUES ('GVU02', N'Tran Thi V', 'F', TO_DATE('1985-02-02', 'YYYY-MM-DD'), 2000, '0901234567', N'Giao vu', 'DV002');
INSERT INTO QLDL.NHANSU  VALUES ('GVU03', N'Le Van W', 'M', TO_DATE('1990-03-03', 'YYYY-MM-DD'), 1500, '0901345678', N'Giao vu', 'DV003');
INSERT INTO QLDL.NHANSU  VALUES ('GVU04', N'Pham Thi S', 'F', TO_DATE('1983-04-04', 'YYYY-MM-DD'), 2500, '0901456789', N'Giao vu', 'DV004');
INSERT INTO QLDL.NHANSU  VALUES ('GVU05', N'Hoang Ven Y', 'M', TO_DATE('1975-05-05', 'YYYY-MM-DD'), 3000, '0901567890', N'Giao vu', 'DV005');
INSERT INTO QLDL.NHANSU  VALUES ('GVU06', N'Nguyen Van Z', 'M', TO_DATE('1980-01-01', 'YYYY-MM-DD'), 1000, '0901123456', N'Giao vu', 'DV006');
INSERT INTO QLDL.NHANSU  VALUES ('GVU07', N'Tran Thi A', 'F', TO_DATE('1985-02-02', 'YYYY-MM-DD'), 2000, '0901234567', N'Giao vu', 'DV007');
INSERT INTO QLDL.NHANSU  VALUES ('GVU08', N'Le Van B', 'M', TO_DATE('1990-03-03', 'YYYY-MM-DD'), 1500, '0901345678', N'Giao vu', 'DV001');
INSERT INTO QLDL.NHANSU  VALUES ('GVU09', N'Pham Thi C', 'F', TO_DATE('1983-04-04', 'YYYY-MM-DD'), 2500, '0901456789', N'Giao vu', 'DV002');
INSERT INTO QLDL.NHANSU  VALUES ('GVU10', N'Hoang Ven D', 'M', TO_DATE('1975-05-05', 'YYYY-MM-DD'), 3000, '0901567890', N'Giao vu', 'DV003');
-- TRUONG DON VI
INSERT INTO QLDL.NHANSU  VALUES ('TDV01', N'Nguyen Van E', 'M', TO_DATE('1980-01-01', 'YYYY-MM-DD'), 1000, '0901123456', N'Truong don vi', 'DV002');
INSERT INTO QLDL.NHANSU  VALUES ('TDV02', N'Tran Thi F', 'F', TO_DATE('1985-02-02', 'YYYY-MM-DD'), 2000, '0901234567', N'Truong don vi', 'DV003');
INSERT INTO QLDL.NHANSU  VALUES ('TDV03', N'Le Van G', 'M', TO_DATE('1990-03-03', 'YYYY-MM-DD'), 1500, '0901345678', N'Truong don vi', 'DV004');
INSERT INTO QLDL.NHANSU  VALUES ('TDV04', N'Pham Thi H', 'F', TO_DATE('1983-04-04', 'YYYY-MM-DD'), 2500, '0901456789', N'Truong don vi', 'DV005');
INSERT INTO QLDL.NHANSU  VALUES ('TDV05', N'Hoang Ven I', 'M', TO_DATE('1975-05-05', 'YYYY-MM-DD'), 3000, '0901567890', N'Truong don vi', 'DV006');
INSERT INTO QLDL.NHANSU  VALUES ('TDV06', N'Nguyen Van J', 'M', TO_DATE('1980-01-01', 'YYYY-MM-DD'), 1000, '0901123456', N'Truong don vi', 'DV001');
-- TRUONG KHOA 
INSERT INTO QLDL.NHANSU  VALUES ('TK001', N'Hoang Ven O', 'M', TO_DATE('1975-05-05', 'YYYY-MM-DD'), 3000, '0901567890', N'Truong khoa', 'DV001');
-- Cap nhat TRGDV trong bang DONVI
UPDATE QLDL.DONVI SET TRGDV = 'TK001' WHERE MADV = 'DV001';
UPDATE QLDL.DONVI SET TRGDV = 'TDV01' WHERE MADV = 'DV002';
UPDATE QLDL.DONVI SET TRGDV = 'TDV02' WHERE MADV = 'DV003';
UPDATE QLDL.DONVI SET TRGDV = 'TDV03' WHERE MADV = 'DV004';
UPDATE QLDL.DONVI SET TRGDV = 'TDV04' WHERE MADV = 'DV005';
UPDATE QLDL.DONVI SET TRGDV = 'TDV05' WHERE MADV = 'DV006';
UPDATE QLDL.DONVI SET TRGDV = 'TDV06' WHERE MADV = 'DV007';

-- Insert du lieu vao bang SINHVIEN
INSERT INTO QLDL.SINHVIEN VALUES ('SV001', N'Nguyen Thi A', 'F', TO_DATE('2000-01-01', 'YYYY-MM-DD'), N'Ha Noi', '0901123123', 'CT001', 'NG001', 120, 8.5);
INSERT INTO QLDL.SINHVIEN VALUES ('SV002', N'Tran Van B', 'M', TO_DATE('2000-02-02', 'YYYY-MM-DD'), N'Ho Chi Minh', '0901232234', 'CT002', 'NG002', 130, 7.8);
INSERT INTO QLDL.SINHVIEN VALUES ('SV003', N'Pham Van C', 'M', TO_DATE('2000-03-03', 'YYYY-MM-DD'), N'Da Nang', '0901343234', 'CT001', 'NG003', 110, 9.2);
INSERT INTO QLDL.SINHVIEN VALUES ('SV004', N'Le Thi D', 'F', TO_DATE('2000-04-04', 'YYYY-MM-DD'), N'Can Tho', '0901454345', 'CT001', 'NG004', 115, 6.9);
INSERT INTO QLDL.SINHVIEN VALUES ('SV005', N'Vo Van E', 'M', TO_DATE('2000-05-05', 'YYYY-MM-DD'), N'Hai Phong', '0901565456', 'CT002', 'NG005', 140, 7.3);
INSERT INTO QLDL.SINHVIEN VALUES ('SV006', N'Nguyen Thi F', 'F', TO_DATE('2000-01-01', 'YYYY-MM-DD'), N'Ha Noi', '0901123123', 'CT002', 'NG001', 120, 8.5);
INSERT INTO QLDL.SINHVIEN VALUES ('SV007', N'Tran Van G', 'M', TO_DATE('2000-02-02', 'YYYY-MM-DD'), N'Ho Chi Minh', '0901232234', 'CT001', 'NG002', 130, 7.8);
INSERT INTO QLDL.SINHVIEN VALUES ('SV008', N'Pham Van H', 'M', TO_DATE('2000-03-03', 'YYYY-MM-DD'), N'Da Nang', '0901343234', 'CT002', 'NG003', 110, 9.2);
INSERT INTO QLDL.SINHVIEN VALUES ('SV009', N'Le Thi I', 'F', TO_DATE('2000-04-04', 'YYYY-MM-DD'), N'Can Tho', '0901454345', 'CT001', 'NG004', 115, 6.9);
INSERT INTO QLDL.SINHVIEN VALUES ('SV010', N'Vo Van J', 'M', TO_DATE('2000-05-05', 'YYYY-MM-DD'), N'Hai Phong', '0901565456', 'CT001', 'NG005', 140, 7.3);

-- Insert du lieu vao bang HOCPHAN
INSERT INTO QLDL.HOCPHAN VALUES ('HP001', N'Vi tich phan', 3, 30, 15, 50, 'DV005');
INSERT INTO QLDL.HOCPHAN VALUES ('HP002', N'Lap Trinh C', 4, 45, 20, 60, 'DV005');
INSERT INTO QLDL.HOCPHAN VALUES ('HP003', N'Co So Du Lieu', 3, 30, 15, 55, 'DV002');
INSERT INTO QLDL.HOCPHAN VALUES ('HP004', N'Mang May Tinh', 4, 40, 20, 45, 'DV007');
INSERT INTO QLDL.HOCPHAN VALUES ('HP005', N'He Dieu Hanh', 3, 35, 20, 40, 'DV002');
INSERT INTO QLDL.HOCPHAN VALUES ('HP006', N'Lap trinh JAVA', 3, 30, 15, 50, 'DV003');
INSERT INTO QLDL.HOCPHAN VALUES ('HP007', N'ATBM HTTT', 4, 45, 20, 60, 'DV002');
INSERT INTO QLDL.HOCPHAN VALUES ('HP008', N'Lap trinh Web', 3, 30, 15, 55, 'DV003');
INSERT INTO QLDL.HOCPHAN VALUES ('HP009', N'Tri tue nhan tao', 4, 40, 20, 45, 'DV004');
INSERT INTO QLDL.HOCPHAN VALUES ('HP010', N'Toan Cao Cap', 3, 35, 20, 40, 'DV004');

-- Insert du lieu vao bang KHMO
INSERT INTO QLDL.KHMO VALUES ('HP001', 'HK1', 2024, 'CT001');
INSERT INTO QLDL.KHMO VALUES ('HP001', 'HK1', 2024, 'CT002');
INSERT INTO QLDL.KHMO VALUES ('HP001', 'HK2', 2024, 'CT001');
INSERT INTO QLDL.KHMO VALUES ('HP002', 'HK1', 2024, 'CT001');
INSERT INTO QLDL.KHMO VALUES ('HP002', 'HK1', 2024, 'CT002');
INSERT INTO QLDL.KHMO VALUES ('HP003', 'HK2', 2024, 'CT002');
INSERT INTO QLDL.KHMO VALUES ('HP003', 'HK2', 2024, 'CT001');
INSERT INTO QLDL.KHMO VALUES ('HP004', 'HK2', 2024, 'CT001');
INSERT INTO QLDL.KHMO VALUES ('HP005', 'HK3', 2024, 'CT002');
INSERT INTO QLDL.KHMO VALUES ('HP006', 'HK1', 2024, 'CT001');
INSERT INTO QLDL.KHMO VALUES ('HP006', 'HK2', 2024, 'CT002');
INSERT INTO QLDL.KHMO VALUES ('HP006', 'HK2', 2024, 'CT001');
INSERT INTO QLDL.KHMO VALUES ('HP007', 'HK2', 2024, 'CT002');
INSERT INTO QLDL.KHMO VALUES ('HP008', 'HK3', 2024, 'CT002');
INSERT INTO QLDL.KHMO VALUES ('HP009', 'HK1', 2024, 'CT001');
INSERT INTO QLDL.KHMO VALUES ('HP010', 'HK2', 2024, 'CT001');

-- Insert du lieu vao bang PHANCONG
INSERT INTO QLDL.PHANCONG VALUES ('TDV04', 'HP001', 'HK1', 2024, 'CT001');
INSERT INTO QLDL.PHANCONG VALUES ('GV005', 'HP001', 'HK1', 2024, 'CT002');
INSERT INTO QLDL.PHANCONG VALUES ('GV005', 'HP001', 'HK2', 2024, 'CT001');
INSERT INTO QLDL.PHANCONG VALUES ('TDV04', 'HP002', 'HK1', 2024, 'CT001');
INSERT INTO QLDL.PHANCONG VALUES ('GV005', 'HP002', 'HK1', 2024, 'CT002');
INSERT INTO QLDL.PHANCONG VALUES ('GV002', 'HP003', 'HK2', 2024, 'CT002');
INSERT INTO QLDL.PHANCONG VALUES ('GV009', 'HP003', 'HK2', 2024, 'CT001');
INSERT INTO QLDL.PHANCONG VALUES ('GV007', 'HP004', 'HK2', 2024, 'CT001');
INSERT INTO QLDL.PHANCONG VALUES ('TDV01', 'HP005', 'HK3', 2024, 'CT002');
INSERT INTO QLDL.PHANCONG VALUES ('TDV02', 'HP006', 'HK1', 2024, 'CT001');
INSERT INTO QLDL.PHANCONG VALUES ('GV010', 'HP006', 'HK2', 2024, 'CT002');
INSERT INTO QLDL.PHANCONG VALUES ('GV003', 'HP006', 'HK2', 2024, 'CT001');
INSERT INTO QLDL.PHANCONG VALUES ('GV002', 'HP007', 'HK2', 2024, 'CT002');
INSERT INTO QLDL.PHANCONG VALUES ('GV010', 'HP008', 'HK3', 2024, 'CT002');
INSERT INTO QLDL.PHANCONG VALUES ('GV004', 'HP009', 'HK1', 2024, 'CT001');
INSERT INTO QLDL.PHANCONG VALUES ('GV004', 'HP010', 'HK2', 2024, 'CT001');

-- Insert du lieu vao bang DANGKY
INSERT INTO QLDL.DANGKY VALUES ('SV001', 'TDV04', 'HP001', 'HK1', 2024, 'CT001', 8, 7.5, 8, 7.8);
INSERT INTO QLDL.DANGKY VALUES ('SV001', 'TDV04', 'HP002', 'HK1', 2024, 'CT001', 8, 7.5, 8, 7.8);
INSERT INTO QLDL.DANGKY VALUES ('SV001', 'GV007', 'HP004', 'HK2', 2024, 'CT001', 8, 7.5, 8, 7.8);

INSERT INTO QLDL.DANGKY VALUES ('SV002', 'GV005', 'HP001', 'HK1', 2024, 'CT002', 6, 6.5, 7, 6.5);
INSERT INTO QLDL.DANGKY VALUES ('SV002', 'GV002', 'HP007', 'HK2', 2024, 'CT002', 6, 6.5, 7, 6.5);
INSERT INTO QLDL.DANGKY VALUES ('SV002', 'GV010', 'HP006', 'HK2', 2024, 'CT002', 6, 6.5, 7, 6.5);

INSERT INTO QLDL.DANGKY VALUES ('SV003', 'TDV04', 'HP001', 'HK1', 2024, 'CT001', 9, 8.5, 9, 8.8);
INSERT INTO QLDL.DANGKY VALUES ('SV003', 'GV004', 'HP010', 'HK2', 2024, 'CT001', 9, 8.5, 9, 8.8);
INSERT INTO QLDL.DANGKY VALUES ('SV003', 'GV004', 'HP009', 'HK1', 2024, 'CT001', 9, 8.5, 9, 8.8);

INSERT INTO QLDL.DANGKY VALUES ('SV004', 'GV007', 'HP004', 'HK2', 2024, 'CT001', 5, 5.5, 6, 5.5);
INSERT INTO QLDL.DANGKY VALUES ('SV004', 'TDV02', 'HP006', 'HK1', 2024, 'CT001', 5, 5.5, 6, 5.5);
INSERT INTO QLDL.DANGKY VALUES ('SV004', 'GV005', 'HP001', 'HK2', 2024, 'CT001', 5, 5.5, 6, 5.5);


INSERT INTO QLDL.DANGKY VALUES ('SV005', 'GV005', 'HP002', 'HK1', 2024, 'CT002', 7, 7.5, 8, 7.5);
INSERT INTO QLDL.DANGKY VALUES ('SV005', 'TDV01', 'HP005', 'HK3', 2024, 'CT002', 7, 7.5, 8, 7.5);

INSERT INTO QLDL.DANGKY VALUES ('SV006', 'GV005', 'HP002', 'HK1', 2024, 'CT002', 8, 7.5, 8, 7.8);
INSERT INTO QLDL.DANGKY VALUES ('SV006', 'TDV01', 'HP005', 'HK3', 2024, 'CT002', 8, 7.5, 8, 7.8);

INSERT INTO QLDL.DANGKY VALUES ('SV007', 'TDV04', 'HP001', 'HK1', 2024, 'CT001', 6, 6.5, 7, 6.5);
INSERT INTO QLDL.DANGKY VALUES ('SV007', 'TDV04', 'HP002', 'HK1', 2024, 'CT001', 6, 6.5, 7, 6.5);
INSERT INTO QLDL.DANGKY VALUES ('SV007', 'GV007', 'HP004', 'HK2', 2024, 'CT001', 6, 6.5, 7, 6.5);

INSERT INTO QLDL.DANGKY VALUES ('SV008', 'GV005', 'HP002', 'HK1', 2024, 'CT002', 9, 8.5, 9, 8.8);
INSERT INTO QLDL.DANGKY VALUES ('SV008', 'TDV01', 'HP005', 'HK3', 2024, 'CT002', 9, 8.5, 9, 8.8);

INSERT INTO QLDL.DANGKY VALUES ('SV009', 'TDV04', 'HP001', 'HK1', 2024, 'CT001', 6, 6.5, 7, 6.5);
INSERT INTO QLDL.DANGKY VALUES ('SV009', 'TDV04', 'HP002', 'HK1', 2024, 'CT001', 6, 6.5, 7, 6.5);
INSERT INTO QLDL.DANGKY VALUES ('SV009', 'GV007', 'HP004', 'HK2', 2024, 'CT001', 6, 6.5, 7, 6.5);

INSERT INTO QLDL.DANGKY VALUES ('SV010', 'TDV04', 'HP001', 'HK1', 2024, 'CT001', 6, 6.5, 7, 6.5);
INSERT INTO QLDL.DANGKY VALUES ('SV010', 'TDV04', 'HP002', 'HK1', 2024, 'CT001', 6, 6.5, 7, 6.5);
INSERT INTO QLDL.DANGKY VALUES ('SV010', 'GV007', 'HP004', 'HK2', 2024, 'CT001', 6, 6.5, 7, 6.5);






