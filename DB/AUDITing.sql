--1) KICH HOAT AUDIT
ALTER SYSTEM SET audit_trail=db SCOPE=SPFILE;

--2)
-- THEO DOI HANH VI NAO DO (O DAY LA SELECT, INSERT) CUA USER CU THE (USER: SV001)
AUDIT SELECT TABLE, INSERT TABLE BY SV001 BY ACCESS;
--NOAUDIT SELECT TABLE, INSERT TABLE BY SV001;

-- THEO DOI HANH VI SELECT TREN QLDL.PHANCONG
AUDIT SELECT ON QLDL.PHANCONG BY ACCESS;
--NOAUDIT SELECT ON QLDL.PHANCONG BY ACCESS;

-- THEO DOI HANH VI INSERT TREN BANG DANGKY KHONG THANH CONG
AUDIT INSERT ON QLDL.DANGKY WHENEVER NOT SUCCESSFUL; 
--NOAUDIT INSERT ON QLDL.DANGKY WHENEVER NOT SUCCESSFUL;

-- Xoa tat ca ban ghi trong dba_audit_trail
--delete from aud$;

-- CAU 3:
-- 3A
-- Tao function de kiem tra dieu kien ROLE cua nguoi dung hien tai khong phai la GV:
CREATE OR REPLACE FUNCTION CHECK_ROLE_GIANGVIEN
RETURN PLS_INTEGER
AS
  USERROLE VARCHAR2(20);
BEGIN
    --N?u là user QLDA admin thì b? audit
    IF SYS_CONTEXT('userenv', 'SESSION_USER') = 'QLDL' THEN
        RETURN 0;
    END IF;
    
    SELECT GRANTED_ROLE INTO USERROLE FROM DBA_ROLE_PRIVS WHERE GRANTEE = '' || SYS_CONTEXT('userenv', 'SESSION_USER') || '';
    
    IF USERROLE = 'GV' THEN
        RETURN 1;
    ELSE
        RETURN 0;
    END IF;
END;

-- tao policy
/
BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema => 'QLDL', 
        object_name => 'DANGKY',
        policy_name => 'AUDIT_UPDATE_DIEM',
        audit_condition => 'CHECK_ROLE_GIANGVIEN() = 0',
        audit_column => 'DIEMTH, DIEMQT, DIEMCK, DIEMTK',
        statement_types => 'UPDATE'
    );
END;

-- Enable policy
/
begin
	dbms_fga.enable_policy(
	                      object_schema => 'QLDL',
	                      object_name   => 'DANGKY',
	                      policy_name   => 'AUDIT_UPDATE_DIEM',
	                      enable        => true
	);
end;
/
--drop FGA
--BEGIN
--       DBMS_FGA.drop_policy (object_schema      => 'QLDL',
--                             object_name        => 'DANGKY',
--                             policy_name        => 'AUDIT_UPDATE_DIEM');
--END;


begin
    dbms_fga.add_policy(
        object_schema => 'ATBM',
        object_name => 'NHANSU',
        policy_name => 'audit_nhansu',
        statement_types => 'SELECT',
        enable => true);
end;
/
-- KIEM TRA:
-- CONNECT USER NV002 VA THUC THI LENH:
--update QLDL.DANGKY
--set DIEMTH = 8
--where MASV = 'SV001' and MAGV = 'NV002' and MAHP = 'HP001' and HK = 'HK1' and NAM = 2024;
--> khong ghi nhat ky (dung)

-- CONNECT USER NV004 VA THUC THI LENH:
--update QLDL.DANGKY
--set DIEMQT = 5
--where MASV = 'SV005' and MAGV = 'NV004' and MAHP = 'HP005' and HK = 'HK3' and NAM = 2024;
--> Nhat ky se duoc ghi (dung)
-- Giai thich tinh huong: NV004 co vai tro Truong Don Vi, va TRGDV co quyen nhu vai tro GV nen co the Update duoc tren bang DANGKY
-- Khi NV004 update tren bang DANGKY thi he thong se ghi lai nhat ky do vai tro cua user nay la TRGDV, khong phai GV.
--3B
-- Tao policy cho FGA voi dieu kien la MANV khac voi user hien tai. 
BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema => 'QLDL', 
        object_name => 'NHANSU',
        policy_name => 'AUDIT_READ_NHANSU',
        audit_condition => 'MANV != SYS_CONTEXT(''USERENV'', ''SESSION_USER'')',
        audit_column => 'PHUCAP',
        statement_types => 'SELECT',
        audit_trail => DBMS_FGA.DB + DBMS_FGA.EXTENDED
    );
END;
/

-- enable policy
begin
	dbms_fga.enable_policy(
	                      object_schema => 'QLDL',
	                      object_name   => 'NHANSU',
	                      policy_name   => 'AUDIT_READ_NHANSU',
	                      enable        => true
	);
end;

-- drop fga policy
--BEGIN
--       DBMS_FGA.drop_policy (object_schema      => 'QLDL',
--                             object_name        => 'NHANSU',
--                             policy_name        => 'AUDIT_READ_NHANSU');
--END;

-- KIEM TRA:
-- CONNECT USER NV005 va thuc thi lenh;
-- select * from qldl.nhansu where MANV = 'NV005';
--> Nhat ky se KHONG duoc ghi (dung)
-- select hoten from qldl.nhansu where MANV = 'NV004';
--> Nhat ky cung se KHONG duoc ghi (dung)

-- Tiep tuc connect voi USER NV005 va thuc thi:
-- select * from qldl.nhansu where MANV = 'NV004'; (*)
--> Nhat ky se duoc ghi (dung)
-- Giai thich tinh huong: 
-- User NV005 co vai tro la Truong Khoa, vai tro nay co quyen xem khong gioi han du lieu tren CSDL. Do do NV005 co the xem tren toan bo bang NHANSU.
-- Va user nay co the xem cac dong ma khong phai cua user do. 
-- Do do nhat ky se duoc ghi neu nhu user NV005 select den truong PHUCAP cua mot nguoi dung khac, ma nhu vi du o tren la NV004.


-- LUU Y: Doi voi cac cau lenh khong the thuc hien do chinh sach rang buoc hoac khong co quyen, thi se khong duoc ghi lai doi voi fine grained audit. 

-- 4. Kiem tra doc xuat nhat ky he thong
-- Doi voi fine grained audit
-- Doc nhat ky he thong ung voi audit policy: AUDIT_UPDATE_DIEM
select * from dba_fga_audit_trail where policy_name = 'AUDIT_UPDATE_DIEM';
-- Doc nhat ky he thong ung voi audit policy: AUDIT_READ_NHANSU
select * from dba_fga_audit_trail where policy_name = 'AUDIT_READ_NHANSU';

-- Doi voi standard audit
SELECT * FROM DBA_AUDIT_TRAIL WHERE OWNER = 'QLDL' ORDER BY TIMESTAMP;
SELECT * FROM DBA_AUDIT_TRAIL WHERE USERNAME = 'SV001' ORDER BY TIMESTAMP;

