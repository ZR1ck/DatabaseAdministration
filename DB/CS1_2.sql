-- CS#1

Create or replace view QLDL.v_NhanVien as
Select *
From QLDL.NHANSU;
--Where MANV = SYS_CONTEXT ('userenv', 'session_user');

Create or replace view QLDL.v2_NhanVien as
Select SDT
From QLDL.NHANSU
Where MANV = SYS_CONTEXT ('userenv', 'session_user');

Grant select on QLDL.NHANSU to NVCB;
Grant update(SDT) on QLDL.NHANSU to NVCB;
Grant select on QLDL.SINHVIEN to NVCB;
Grant select on QLDL.DONVI to NVCB;
Grant select on QLDL.HOCPHAN to NVCB;
Grant select on QLDL.KHMO to NVCB;

CREATE OR REPLACE FUNCTION select_nhansu (
    p_schema varchar2, 
    p_object varchar2
)
return varchar2
as
begin
    if sys_context('userenv','isdba') = 'true' then
        return '1 = 1';
    else 
        return 'MANV = ''' || sys_context('userenv', 'session_user') || '''';
    end if;
end;

/
BEGIN dbms_rls.add_policy 
(object_schema =>'QLDL',
object_name => 'NHANSU',
policy_name => 'POLICY_SELECT_NHANSU',
policy_function => 'select_nhansu',
statement_types => 'SELECT, UPDATE',
UPDATE_CHECK => true
);
END;
/

--BEGIN dbms_rls.drop_policy 
--(object_schema =>'QLDL',
--object_name => 'NHANSU',
--policy_name => 'POLICY_SELECT_NHANSU'
--);
--END;

        
-- CS#2 

Create or replace view QLDL.v_GV as
Select *
From QLDL.PHANCONG
Where MAGV = SYS_CONTEXT ('userenv', 'session_user');

Create or replace view QLDL.v2_GV as
Select *
From QLDL.DANGKY
Where MAGV = SYS_CONTEXT ('userenv', 'session_user');

CREATE OR REPLACE FUNCTION update_giangvien_dangki (
    p_schema varchar2, 
    p_object varchar2
)
return varchar2
as
begin
    if sys_context('userenv','isdba') = 'true' then
        return '1 = 1';
    else 
        return 'MAGV = ''' || sys_context('userenv', 'session_user') || '''';
    end if;
end;

BEGIN dbms_rls.add_policy 
(object_schema =>'QLDL',
object_name => 'DANGKY',
policy_name => 'POLICY_UPDATE_DANGKI',
policy_function => 'update_giangvien_dangki',
statement_types => 'SELECT, UPDATE',
UPDATE_CHECK => true
);
END;

--BEGIN dbms_rls.drop_policy 
--(object_schema =>'QLDL',
--object_name => 'DANGKY',
--policy_name => 'POLICY_UPDATE_DANGKI'
--);
--END;


Grant NVCB to GV;
Grant select on QLDL.v_GV to GV;
Grant select on QLDL.v2_GV to GV;
grant select on QLDL.DANGKY to GV;
Grant update(DIEMTH, DIEMQT, DIEMCK, DIEMTK) on QLDL.DANGKY to GV;









