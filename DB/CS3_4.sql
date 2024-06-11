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
create or replace FUNCTION giaovu_update_phancong
 (P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
 MA VARCHAR2(5);
 STRSQL VARCHAR2(2000);
 CURSOR CUR IS (SELECT MAHP
 FROM QLDL.HOCPHAN
 WHERE MADV = (SELECT MADV FROM QLDL.DONVI WHERE TENDV = 'Van phong khoa'));
BEGIN
 OPEN CUR;
 LOOP
 FETCH CUR INTO MA;
 EXIT WHEN CUR%NOTFOUND;
 IF (STRSQL IS NOT NULL) THEN
 STRSQL := STRSQL ||''',''';
 END IF;
 STRSQL := STRSQL || MA;
 END LOOP;
 RETURN 'MAHP IN ('''||STRSQL||''')';
END;

/
BEGIN dbms_rls.add_policy 
(object_schema =>'QLDL',
object_name => 'PHANCONG',
policy_name => 'POLICY_GIAOVU_UPDATE_PHANCONG',
policy_function => 'giaovu_update_phancong',
statement_types => 'UPDATE',
UPDATE_CHECK => true
);
END;
/

-- 
create or replace FUNCTION vpd_giaovu_dangky(p_schema varchar2, p_obj varchar2)
RETURN VARCHAR2 
AS
    current_date DATE;
    day NUMBER;
    month NUMBER;
    year NUMBER;
    hocki VARCHAR2(10);
    result VARCHAR2(4000);
BEGIN
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
END;

BEGIN dbms_rls.add_policy 
(object_schema =>'QLDL',
object_name => 'DANGKY',
policy_name => 'POLICY_GIAOVU_DANGKY',
policy_function => 'vpd_giaovu_dangky',
statement_types => 'INSERT, DELETE',
UPDATE_CHECK => true
);
END;

grant insert, delete on QLDL.DANGKY to GIAOVU;

select policy_name from all_policies