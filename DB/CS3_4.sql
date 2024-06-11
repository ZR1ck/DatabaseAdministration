-- CS#3
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
    IF (USERROLE = 'GIAOVU') THEN
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
    IF (USERROLE = 'GIAOVU') THEN 
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



--CS#4
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
    ELSIF (USERROLE = 'GIAOVU') THEN RETURN '';
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

