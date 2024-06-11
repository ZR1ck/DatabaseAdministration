-- CS#1
-- NVCB XEM DU LIEU CHINH MINH, CHINH SUA SDT
CREATE OR REPLACE FUNCTION VPD_NHANSU (
    p_schema varchar2, 
    p_object varchar2
)
return varchar2
as
    userrole varchar2(100);
begin
    if sys_context('userenv','isdba') = 'true' then
        return '1 = 1';
    else 
        select GRANTED_ROLE into userrole from DBA_ROLE_PRIVS where GRANTEE = '' || SYS_CONTEXT ('USERENV', 'SESSION_USER')  || '';
        if (userrole = 'TRGKHOA') then return '';
        else
            return 'MANV = ''' || sys_context('userenv', 'session_user') || '''';
        end if;
    end if;
end;

/
BEGIN dbms_rls.add_policy 
(object_schema =>'QLDL',
object_name => 'NHANSU',
policy_name => 'POLICY_NHANSU',
policy_function => 'VPD_NHANSU',
statement_types => 'SELECT, UPDATE',
UPDATE_CHECK => true
);
END;
/

GRANT SELECT ON QLDL.NHANSU TO NVCB;
GRANT UPDATE (SDT) ON QLDL.NHANSU TO NVCB;

-- XEM THONG TIN TAT CA SINHVIEN, DONVI, HOCPHAN, KHMO
GRANT SELECT ON QLDL.SINHVIEN TO NVCB;
GRANT SELECT ON QLDL.DONVI TO NVCB;
GRANT SELECT ON QLDL.HOCPHAN TO NVCB;
GRANT SELECT ON QLDL.KHMO TO NVCB;

--BEGIN dbms_rls.drop_policy 
--(object_schema =>'QLDL',
--object_name => 'NHANSU',
--policy_name => 'VPD_NHANSU'
--);
--END;
--DROP FUNCTION VPD_NHANSU;


-- CS#2 
-- GIANG VIEN NHU MOT NGUOI DUNG CO VAI TRO NVCB
GRANT NVCB TO GV;

-- XEM NHU LIEU LIEN QUAN DEN MINH TREN PHANCONG
Create or replace view QLDL.v_GV as
Select *
From QLDL.PHANCONG
Where MAGV = SYS_CONTEXT ('userenv', 'session_user');

Grant select on QLDL.v_GV to GV;



-- XEM DU LIEU TREN DANGKY LIEN QUAN DEN CAC LOP GV DANG GIANG DAY
Create or replace view QLDL.v2_GV as
Select *
From QLDL.DANGKY
Where MAGV = SYS_CONTEXT ('userenv', 'session_user');

Grant select on QLDL.v2_GV to GV;



-- CAP NHAT CAC TRUONG LIEN QUAN DEN DIEM SO TRONG DANGKY CAC SINH VIEN CO THAM GIA LOP
-- MA GIANG VIEN DUOC PHAN CONG GIANG DAY
CREATE OR REPLACE FUNCTION VPD_DANGKY (  -- DUNG CHO SELECT, UPDATE
    p_schema varchar2, 
    p_object varchar2
)
return varchar2
as
    userrole varchar2(100);
begin
    if sys_context('userenv','isdba') = 'true' then
        return '1 = 1';
    else 
        select GRANTED_ROLE into userrole from DBA_ROLE_PRIVS where GRANTEE = '' || SYS_CONTEXT ('USERENV', 'SESSION_USER')  || '';
        if (USERROLE = 'GV') THEN
            return 'MAGV = ''' || sys_context('userenv', 'session_user') || '''';
        elsif (USERROLE = 'GIAOVU' OR USERROLE = 'TRGKHOA') THEN 
            return '';
        ELSIF (USERROLE = 'SV') THEN
            RETURN 'MASV = ''' || sys_context('userenv', 'session_user') || '''';
        end if;
    end if;
    return '1 = 0';
end;
/
BEGIN dbms_rls.add_policy 
(object_schema =>'QLDL',
object_name => 'DANGKY',
policy_name => 'POLICY_DANGKY',
policy_function => 'VPD_DANGKY',
statement_types => 'SELECT, UPDATE',
UPDATE_CHECK => true
);
END;
/

grant select on QLDL.DANGKY to GV;
Grant update(DIEMTH, DIEMQT, DIEMCK, DIEMTK) on QLDL.DANGKY to GV;


--BEGIN dbms_rls.drop_policy 
--(object_schema =>'QLDL',
--object_name => 'DANGKY',
--policy_name => 'POLICY_DANGKY'
--);
--END;

--DROP VIEW QLDL.v_GV;
--DROP VIEW QLDL.v2_GV;

SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTEE = 'SV001';







