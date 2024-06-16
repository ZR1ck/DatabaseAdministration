-- CS#3 ----------------------------------------------------------------------------------------------------------
grant NVCB to GIAOVU
-- XEM - THEM - CAP NHAT TREN SINHVIEN, DONVI, HOCPHAN, KHMO
GRANT SELECT, UPDATE, INSERT ON QLDL.SINHVIEN TO GIAOVU;
GRANT SELECT, UPDATE, INSERT ON QLDL.DONVI TO GIAOVU;
GRANT SELECT, UPDATE, INSERT ON QLDL.HOCPHAN TO GIAOVU;
GRANT SELECT, UPDATE, INSERT ON QLDL.KHMO TO GIAOVU;

-- XEM TREN TOAN BO PHAN CONG
GRANT SELECT ON QLDL.PHANCONG TO GIAOVU;

-- update tren bang PHANCONG lien quan den hoc phan do VAN PHONG KHOA phan cong
create or replace FUNCTION VPD_PHANCONG
    (P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
    USERROLE VARCHAR2(100);
    STRSQL VARCHAR2(2000);
BEGIN
    IF (SYS_CONTEXT('USERENV', 'ISDBA')) = 'TRUE' THEN RETURN ''; END IF;
    SELECT GRANTED_ROLE INTO USERROLE FROM DBA_ROLE_PRIVS WHERE GRANTEE = '' || SYS_CONTEXT ('USERENV', 'SESSION_USER')  || '';
    IF (USERROLE = 'GIAOVU' OR USERROLE = 'TRGKHOA') THEN
        FOR CUR IN (SELECT MAHP
                    FROM QLDL.HOCPHAN
                    WHERE MADV = (SELECT MADV FROM QLDL.DONVI WHERE TENDV = 'Van phong khoa')) 
        LOOP
            IF (STRSQL IS NOT NULL) THEN
                STRSQL := STRSQL ||''',''';
            END IF;
            STRSQL := STRSQL || CUR.MAHP;
        END LOOP;
        RETURN 'MAHP IN (''' || STRSQL || ''')';
        
    ELSIF (USERROLE = 'TRGDV') THEN
        FOR CUR IN (SELECT MAHP
                    FROM QLDL.HOCPHAN
                    WHERE MADV IN (SELECT MADV FROM QLDL.DONVI WHERE TRGDV = SYS_CONTEXT('USERENV', 'SESSION_USER'))) 
        LOOP
            IF (STRSQL IS NOT NULL) THEN
                STRSQL := STRSQL ||''',''';
            END IF;
            STRSQL := STRSQL || CUR.MAHP;
        END LOOP;
        RETURN 'MAHP IN (''' || STRSQL || ''')';
    END IF;
END;

/
BEGIN dbms_rls.add_policy 
(object_schema =>'QLDL',
object_name => 'PHANCONG',
policy_name => 'POLICY_PHANCONG',
policy_function => 'VPD_PHANCONG',
statement_types => 'UPDATE, INSERT, DELETE',
UPDATE_CHECK => true
);
END;
/

GRANT UPDATE ON QLDL.PHANCONG TO GIAOVU;

BEGIN dbms_rls.drop_policy 
(object_schema =>'QLDL',
object_name => 'PHANCONG',
policy_name => 'POLICY_PHANCONG'
);
END;
/
--DROP FUNCTION VPD_PHANCONG;


--THEM , XOA DU LIEU TREN DANGKY THEO YEU CAU CUA SINH VIEN TRONG KHOANG THOI GIAN CON
--CHO HIEU CHINH DANG KY 
create or replace FUNCTION VPD_DANGKY2 (p_schema varchar2, p_obj varchar2) -- DUNG CHO INSERT, DELETE
RETURN VARCHAR2 
AS
    USERROLE VARCHAR2(100);
    current_date DATE;
    day NUMBER;
    month NUMBER;
    year NUMBER;
    hocki VARCHAR2(10);
    result VARCHAR2(4000);
BEGIN
    IF (SYS_CONTEXT('USERENV', 'ISDBA')) = 'TRUE' THEN RETURN ''; END IF;
    SELECT GRANTED_ROLE INTO USERROLE FROM DBA_ROLE_PRIVS WHERE GRANTEE = '' || SYS_CONTEXT ('USERENV', 'SESSION_USER')  || '';
    IF (USERROLE = 'GIAOVU' OR USERROLE = 'SV') THEN 
        -- Get the current date
        SELECT SYSDATE INTO current_date FROM dual;
        SELECT
            EXTRACT(DAY FROM current_date),
            EXTRACT(MONTH FROM current_date),
            EXTRACT(YEAR from current_date)
        INTO day, month, year
        FROM dual; 
            if month = 1 or month = 6 or month = 9 then
                if day - 1 <= 14 then
                    if month = 1 then
                        hocki := 'HK1';
                    elsif month = 6 then
                        hocki := 'HK2';
                    elsif month = 9 then
                        hocki := 'HK3';
                    end if;
                    result:= 'HK = ''' || hocki || ''' and NAM = ''' || TO_CHAR(year) || '''';
                    IF (USERROLE = 'SV') THEN 
                        result := result || ' MASV = ''' || sys_context('userenv', 'session_user') || '''';
                    END IF;
                else
                    result:='1=0';
                end if;
            else
                 result:= '1=0';
            end if;
        return result;
    END IF;
    RETURN '1=0';
END;
/
BEGIN dbms_rls.add_policy 
(object_schema =>'QLDL',
object_name => 'DANGKY',
policy_name => 'POLICY_DANGKY2',
policy_function => 'VPD_DANGKY2',
statement_types => 'INSERT, DELETE',
UPDATE_CHECK => true
);
END;
/
grant SELECT, insert, delete on QLDL.DANGKY to GIAOVU;

--BEGIN dbms_rls.drop_policy 
--(object_schema =>'QLDL',
--object_name => 'DANGKY',
--policy_name => 'POLICY_DANGKY'
--);
--END;
--/
--DROP FUNCTION VPD_DANGKY2;



--CS#4 ----------------------------------------------------------------------------------------------------------
GRANT GV TO TRGDV;

-- XEM PHAN CONG CUA CAC GIANG VIEN THUOC DV MA MINH LAM TRUONG
CREATE OR REPLACE FUNCTION VPD_PHANCONG_SELECT (P_SCHEMA VARCHAR2, P_OBJ VARCHAR2) RETURN VARCHAR2
AS
    USR CHAR(5);
    USERROLE VARCHAR2(100);
    STRSQL VARCHAR2(2000);
BEGIN
    IF (SYS_CONTEXT('USERENV', 'ISDBA')) = 'TRUE' THEN RETURN ''; END IF;
    USR := SYS_CONTEXT ('USERENV', 'SESSION_USER');
    SELECT GRANTED_ROLE INTO USERROLE FROM DBA_ROLE_PRIVS WHERE GRANTEE = '' || SYS_CONTEXT ('USERENV', 'SESSION_USER')  || '';
    IF (USERROLE = 'TRGDV') THEN
        FOR CUR IN (SELECT MANV
                    FROM QLDL.NHANSU
                    WHERE MADV IN (SELECT MADV FROM QLDL.DONVI WHERE TRGDV = 'NV004')) 
        LOOP
            IF (STRSQL IS NOT NULL) THEN
                STRSQL := STRSQL ||''',''';
            END IF;
            STRSQL := STRSQL || CUR.MANV;
        END LOOP;
        RETURN 'MAGV IN (''' || STRSQL || ''')';
    ELSIF (USERROLE = 'GIAOVU' OR USERROLE = 'TRGKHOA') THEN RETURN '';
    END IF;
    RETURN '1 = 0';
END;
/
BEGIN dbms_rls.add_policy 
(object_schema =>'QLDL',
object_name => 'PHANCONG',
policy_name => 'POLICY_PHANCONG_SELECT',
policy_function => 'VPD_PHANCONG_SELECT',
statement_types => 'SELECT',
UPDATE_CHECK => true
);
END;
/
GRANT SELECT ON QLDL.PHANCONG TO TRGDV;

--BEGIN dbms_rls.drop_policy 
--(object_schema =>'QLDL',
--object_name => 'PHANCONG',
--policy_name => 'POLICY_PHANCONG_SELECT'
--);
--END;
--/
--DROP FUNCTION VPD_PHANCONG_SELECT;



-- THEM, XOA, CAP NHAT TREN PHANCONG DOI VOI CAC HOC PHAN PHU TRACH BOI DON VI MINH LAM TRG
-- XEM TRONG FUNCTION VPD_PHANCONG
GRANT UPDATE ON QLDL.PHANCONG TO TRGDV;





-- CS#5 ----------------------------------------------------------------------------------------------------------
GRANT GV TO TRGKHOA;

-- THEM, XOA, CAP NAHT TREN PHAN CONG DOI VOI CAC HOC PHAN QUAN LY BOI VAN PHONG KHOA
GRANT INSERT, DELETE, UPDATE ON QLDL.PHANCONG TO TRGKHOA;

-- XEM, THEM, XOA, CAP NHAT TREN NHANSU
GRANT INSERT, DELETE, UPDATE ON QLDL.NHANSU TO TRGKHOA;

-- DUOC XEM TOAN BO DU LIEU
GRANT SELECT ON QLDL.PHANCONG TO TRGKHOA;



-- CS#6 ----------------------------------------------------------------------------------------------------------
--SINH VIEN CHI DUOC XEM THONG TIN CUA MINH
CREATE OR REPLACE FUNCTION VPD_SV (P_SCHEMA VARCHAR2, P_OBJ VARCHAR2) RETURN VARCHAR2
AS
    USERROLE VARCHAR2(100);
BEGIN
    IF (SYS_CONTEXT('USERENV', 'ISDBA') = 'TRUE') THEN RETURN ''; END IF;
    SELECT GRANTED_ROLE INTO USERROLE FROM DBA_ROLE_PRIVS WHERE GRANTEE = '' || SYS_CONTEXT ('USERENV', 'SESSION_USER')  || '';
    
    IF (USERROLE = 'SV') THEN
        RETURN 'MASV = ''' || sys_context('userenv', 'session_user') || '''';
    ELSE
        RETURN '';
    END IF;
END;
/

BEGIN
DBMS_RLS.ADD_POLICY (
    object_schema =>'QLDL',
    object_name => 'SINHVIEN',
    policy_name => 'POLICY_SINHVIEN',
    policy_function => 'VPD_SV',
    statement_types => 'SELECT, UPDATE',
    UPDATE_CHECK => true
);
END;
/
GRANT SELECT ON QLDL.SINHVIEN TO SV;

--BEGIN
--DBMS_RLS.DROP_POLICY (
--    object_schema =>'QLDL',
--    object_name => 'SINHVIEN',
--    policy_name => 'POLICY_SINHVIEN'
--);
--END;
--/
--DROP FUNCTION VPD_SV;

-- CHINH SUA DIA CHI, SDT
GRANT UPDATE (DCHI, SDT) ON QLDL.SINHVIEN TO SV;

-- XEM HOCPHAN, KHMO CHUONG TRINH SV DANG THEO HOC
CREATE OR REPLACE VIEW QLDL.V_SV_KHMO AS
SELECT * FROM QLDL.KHMO WHERE MACT = ( SELECT MACT FROM QLDL.SINHVIEN WHERE MASV = SYS_CONTEXT('USERENV', 'SESSION_USER'));

GRANT SELECT ON QLDL.V_SV_KHMO TO SV;

CREATE OR REPLACE VIEW QLDL.V_SV_HOCPHAN AS
SELECT * FROM QLDL.HOCPHAN WHERE MAHP IN ( 
    SELECT MAHP FROM QLDL.KHMO WHERE MACT = ( 
        SELECT MACT FROM QLDL.SINHVIEN WHERE MASV = SYS_CONTEXT('USERENV', 'SESSION_USER')
    )
);

GRANT SELECT ON QLDL.V_SV_HOCPHAN TO SV;


-- THEM XOA CAC DONG DU LIEU LIEN QUAN DEN MINH TRONG DANGKY NEU THOI GIAN CON HOP LE
-- XEM VPD_DANGKY2
GRANT INSERT, DELETE ON QLDL.DANGKY TO SV; -- CHUA TEST BUON NGU QUA ROI DCM

-- XEM TAT CA THONG TIN TREN DANGKY LIEN QUAN DEN MINH
-- XEM FUNCTION VPD_DANGKY
GRANT SELECT ON QLDL.DANGKY TO SV;