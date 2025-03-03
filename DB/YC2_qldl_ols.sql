-- DROP POLICY
BEGIN
  SA_SYSDBA.DROP_POLICY('ANNOUNCEMENT_POLICY');
END;

-- B3: CREATE POLICY
BEGIN 
    SA_SYSDBA.CREATE_POLICY( 
        policy_name => 'ANNOUNCEMENT_POLICY',  
        column_name => 'LABEL_COL' 
    ); 
END; 
/

EXEC SA_SYSDBA.ENABLE_POLICY ('ANNOUNCEMENT_POLICY'); 
----> KHOI DONG LAI

-- LEVEL 
EXEC SA_COMPONENTS.CREATE_LEVEL('ANNOUNCEMENT_POLICY',20,'SV','SINH VIEN'); 
EXEC SA_COMPONENTS.CREATE_LEVEL('ANNOUNCEMENT_POLICY',40,'NV','NHAN VIEN'); 
EXEC SA_COMPONENTS.CREATE_LEVEL('ANNOUNCEMENT_POLICY',60,'GIAOVU','GIAO VU');
EXEC SA_COMPONENTS.CREATE_LEVEL('ANNOUNCEMENT_POLICY',80,'GV','GIANG VIEN'); 
EXEC SA_COMPONENTS.CREATE_LEVEL('ANNOUNCEMENT_POLICY',100,'TDV','TRUONG DON VI'); 
EXEC SA_COMPONENTS.CREATE_LEVEL('ANNOUNCEMENT_POLICY',120,'TGKH','TRUONG KHOA');

-- COMPARTMENT 
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('ANNOUNCEMENT_POLICY',100,'HTTT','HE THONG THONG TIN'); 
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('ANNOUNCEMENT_POLICY',200,'CNPM','CONG NGHE PHAN MEM');
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('ANNOUNCEMENT_POLICY',300,'KHMT','KHOA HOC MAY TINH'); 
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('ANNOUNCEMENT_POLICY',400,'CNTT','CONG NGHE THONG TIN'); 
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('ANNOUNCEMENT_POLICY',500,'TGMT','THI GIAC MAY TINH'); 
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('ANNOUNCEMENT_POLICY',600,'MMT','MANG MAY TINH'); 

 -- GROUP 
EXECUTE SA_COMPONENTS.CREATE_GROUP('ANNOUNCEMENT_POLICY',100,'CS1','CO SO 1'); 
EXECUTE SA_COMPONENTS.CREATE_GROUP('ANNOUNCEMENT_POLICY',150,'CS2','CO SO 2');

-- LABEL TUONG UNG 
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 10, 'TGKH:HTTT:CS1');
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 20, 'TDV:CNTT:CS1');
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 30, 'TDV:HTTT:CS2');
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 40, 'TDV:CNPM:CS1');
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 50, 'GV:MMT:CS1');
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 60, 'GV:HTTT:CS2');
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 70, 'GV:TGMT:CS2');
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 80, 'GIAOVU:HTTT:CS1');
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 90, 'GIAOVU:KHMT:CS2');
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 100, 'NV:HTTT:CS1');
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 110, 'NV:KHMT:CS2');
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 120, 'SV:CNPM:CS1');
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 130, 'SV:HTTT:CS2');

-- NHAN THONG BAO T2 DUOC DOC BOI SV THUOC NGANH HTTT CS1
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 140, 'SV:HTTT:CS1');
-- NHAN THONG BAO T1 DUOC DOC BOI TAT CA TRUONG DON VI
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 150, 'TDV::');
-- NHAN THONG BAO T3 DUOC DOC BOI TRUONG DON VI KHMT CS1
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 160, 'TDV:KHMT:CS1');
-- NHAN THONG BAO T4 DUOC DOC BOI TRUONG DON VI KHMT CS1 VA CS2
EXECUTE SA_LABEL_ADMIN.CREATE_LABEL('ANNOUNCEMENT_POLICY', 170, 'TDV:KHMT:');

-- B5: TAO BANG
DROP TABLE THONGBAO;
CREATE TABLE THONGBAO(
    ID INT PRIMARY KEY,
    NOIDUNG VARCHAR2(100),
    NGNHAN VARCHAR2(20),
    KHOAGUI VARCHAR2(20),
    COSO VARCHAR2(20)
);

INSERT INTO THONGBAO VALUES (1, 'Thong bao 1', 'Truong khoa', 'HTTT', 'Co so 1');
INSERT INTO THONGBAO VALUES (2, 'Thong bao 2', 'Truong don vi', 'CNTT', 'Co so 1');
INSERT INTO THONGBAO VALUES (3, 'Thong bao 3', 'Truong don vi', 'HTTT', 'Co so 2');
INSERT INTO THONGBAO VALUES (4, 'Thong bao 4', 'Truong don vi', 'CNPM', 'Co so 1');
INSERT INTO THONGBAO VALUES (5, 'Thong bao 5', 'Giao vien', 'MMT', 'Co so 1');
INSERT INTO THONGBAO VALUES (6, 'Thong bao 6', 'Giao vien', 'HTTT', 'Co so 2');
INSERT INTO THONGBAO VALUES (7, 'Thong bao 7', 'Giao vien', 'TGMT', 'Co so 2');
INSERT INTO THONGBAO VALUES (8, 'Thong bao 8', 'Giao vu', 'HTTT', 'Co so 1');
INSERT INTO THONGBAO VALUES (9, 'Thong bao 9', 'Giao vu', 'KHMT', 'Co so 2');
INSERT INTO THONGBAO VALUES (10, 'Thong bao 10', 'Nhan vien', 'HTTT', 'Co so 1');
INSERT INTO THONGBAO VALUES (11, 'Thong bao 11', 'Nhan vien', 'KHMT', 'Co so 2');
INSERT INTO THONGBAO VALUES (12, 'Thong bao 12', 'Sinh vien', 'CNPM', 'Co so 1');
INSERT INTO THONGBAO VALUES (13, 'Thong bao 13', 'Sinh vien', 'HTTT', 'Co so 2');

INSERT INTO THONGBAO VALUES (14, 'Thong bao phat tan den sinh vien HTTT cs 1', 'Sinh vien', 'HTTT', 'Co so 1');

INSERT INTO THONGBAO VALUES (15, 'Thong bao duoc phan tan cho tat ca truong don vi', 'Truong khoa', 'HTTT', 'Co so 1');

INSERT INTO THONGBAO VALUES (16, 'Thong bao duoc phan tan truong bo mon KHMT cs 1', 'Truong don vi', 'KHMT', 'Co so 1');

INSERT INTO THONGBAO VALUES (17, 'Thong bao duoc phan tan truong bo mon KHMT cs 1 va cs 2', 'Truong don vi', 'KHMT', 'Co so 1');

SELECT * FROM THONGBAO;

-- B6: CAP NHAT LABEL VAO BANG
BEGIN 
    SA_POLICY_ADMIN.APPLY_TABLE_POLICY ( 
        POLICY_NAME => 'ANNOUNCEMENT_POLICY', 
        SCHEMA_NAME => 'QLDL_OLS', 
        TABLE_NAME => 'THONGBAO', 
        TABLE_OPTIONS => 'NO_CONTROL' 
    ); 
END;

-- B7: TAO NHAN CHO DONG
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','TGKH:HTTT:CS1') WHERE ID = 1; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','TDV:CNTT:CS1') WHERE ID = 2; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','TDV:HTTT:CS2') WHERE ID = 3; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','TDV:CNPM:CS1') WHERE ID = 4; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','GV:MMT:CS1') WHERE ID = 5; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','GV:HTTT:CS2') WHERE ID = 6; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','GV:TGMT:CS2') WHERE ID = 7; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','GIAOVU:HTTT:CS1') WHERE ID = 8; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','GIAOVU:KHMT:CS2') WHERE ID = 9; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','NV:HTTT:CS1') WHERE ID = 10; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','NV:KHMT:CS2') WHERE ID = 11; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','SV:CNPM:CS1') WHERE ID = 12; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','SV:HTTT:CS2') WHERE ID = 13; 

UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','SV:HTTT:CS1') WHERE ID = 14; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','TDV::') WHERE ID = 15; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','TDV:KHMT:CS1') WHERE ID = 16; 
UPDATE THONGBAO SET LABEL_COL = CHAR_TO_LABEL('ANNOUNCEMENT_POLICY','TDV:KHMT:') WHERE ID = 17; 

-- B8: GAN LAI POLICY
BEGIN
SA_POLICY_ADMIN.REMOVE_TABLE_POLICY(
    POLICY_NAME  => 'ANNOUNCEMENT_POLICY',
    SCHEMA_NAME  => 'QLDL_OLS',
    TABLE_NAME  => 'THONGBAO',
    DROP_COLUMN => FALSE
);
END;
/

BEGIN
SA_POLICY_ADMIN.APPLY_TABLE_POLICY(
    POLICY_NAME  => 'ANNOUNCEMENT_POLICY',
    SCHEMA_NAME  => 'QLDL_OLS',
    TABLE_NAME  => 'THONGBAO',
    TABLE_OPTIONS  => 'READ_CONTROL, WRITE_CONTROL, CHECK_CONTROL'
);
END;
/


-- B10: GAN LABEL CHO USER
-- NHAN CHO TRUONG KHOA DOC TOAN BO THONG BAO
EXECUTE SA_USER_ADMIN.SET_USER_LABELS('ANNOUNCEMENT_POLICY','USRTGKH','TGKH:HTTT,CNPM,KHMT,CNTT,TGMT,MMT:CS1,CS2');
    
-- NHAN CHO TRUONG DON VI PHU TRACH CO SO 2 DOC TOAN BO THONG BAO CHO TRUONG DON VI KHONG PHAN BIET VI TRI DIA LY
EXECUTE SA_USER_ADMIN.SET_USER_LABELS('ANNOUNCEMENT_POLICY','USRTDVCS2','TDV:HTTT,CNPM,KHMT,CNTT,TGMT,MMT:CS1,CS2');

-- NHAN CHO GIAO VU DOC TOAN BO THONG BAO CUA GIAO VU
EXECUTE SA_USER_ADMIN.SET_USER_LABELS('ANNOUNCEMENT_POLICY','USRGIAOVU','GIAOVU:HTTT,CNPM,KHMT,CNTT,TGMT,MMT:CS1,CS2'); 
    

EXECUTE SA_USER_ADMIN.SET_USER_LABELS('ANNOUNCEMENT_POLICY','USRTDVCS1','TDV:HTTT,CNPM,KHMT,CNTT,TGMT,MMT:CS1');

EXECUTE SA_USER_ADMIN.SET_USER_LABELS('ANNOUNCEMENT_POLICY','USRNV','GV:HTTT:CS1'); 
EXECUTE SA_USER_ADMIN.SET_USER_LABELS('ANNOUNCEMENT_POLICY','USRSV','SV:HTTT:CS1'); 


EXECUTE SA_USER_ADMIN.SET_USER_LABELS('ANNOUNCEMENT_POLICY','USRTDVCS1KHMT','TDV:KHMT:CS1');
EXECUTE SA_USER_ADMIN.SET_USER_LABELS('ANNOUNCEMENT_POLICY','USRTDVCS2KHMT','TDV:KHMT:CS2');
