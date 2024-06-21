﻿using DatabaseAdministration.DataProvider;
using DatabaseAdministration.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAdministration
{
    public partial class FUsersMain : Form
    {
        private int role;
        private List<string> tempVal = new List<string>();
        private DateTime tempdate = DateTime.MinValue;

        public FUsersMain(int role)
        {
            InitializeComponent();
            this.role = role;
            switch (role)
            {
                case 1: // SV
                    tabPageTTNhanSu.Parent = null;
                    tabPageSinhVien.Parent = null;
                    tabPageDonVi.Parent = null;
                    tabPageNhanSu.Parent = null;
                    tabPagePhanCong.Parent = null;

                    loadTTCNSV();
                    break;
                case 2: // NVCB
                    tabPageTTSinhVien.Parent = null;
                    tabPagePhanCong.Parent = null;
                    tabPageNhanSu.Parent = null;
                    tabPageDangKy.Parent = null;

                    loadTTCN();
                    loadDataGridViewTBSinhVien();

                    break;
                case 3: // GIAOVU
                    tabPageTTSinhVien.Parent = null;
                    tabPageNhanSu.Parent = null;

                    loadTTCN();
                    loadDataGridViewTBSinhVien();

                    btnUpdateSinhVien.Visible = true;
                    btnAddSV.Visible = true;

                    break;
                case 4: // GV
                    tabPageTTSinhVien.Parent = null;
                    tabPageNhanSu.Parent = null;

                    loadTTCN();
                    loadDataGridViewTBSinhVien();

                    break;
                case 5: // TRGDV
                    tabPageTTSinhVien.Parent = null;
                    tabPageNhanSu.Parent = null;

                    loadTTCN();
                    loadDataGridViewTBSinhVien();

                    break;
                case 6: // TRGKHOA
                    tabPageTTSinhVien.Parent = null;
                    tabPageTTNhanSu.Parent = null;

                    loadDataGridViewTBSinhVien();
                    loadDataGridViewNhanSu();
                    break;
            }
        }

        // Sự kiện dổi tab
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage selectedTab = tabControl.SelectedTab;

            if (selectedTab == tabPageSinhVien)
            {
                if (dataGridViewTBSinhVien.Rows.Count > 0)
                {
                    dataGridViewTBSinhVien.Focus();
                    dataGridViewTBSinhVien.Rows[0].Selected = true;
                    dataGridViewTBSinhVien_SelectionChanged(sender, null);
                }
            }
            else if (selectedTab == tabPageNhanSu)
            {
                if (dataGridViewNhanSu.Rows.Count > 0)
                {
                    dataGridViewNhanSu.Focus();
                    dataGridViewNhanSu.Rows[0].Selected = true;
                    dataGridViewNhanSu_SelectionChanged(sender, null);
                }
            }
        }
        // hàm lấy thông tin cá nhân của người dùng hiện tại
        private bool loadTTCN()
        {
            NhanSu ttcn = NhanSu.getCurrentNhanSu();
            if (ttcn != null)
            {
                txtBoxTTCNMaNV.Text = ttcn.maNV;
                txtBoxTTCNHoTen.Text = ttcn.hoten;
                txtBoxTTCNPhai.Text = ttcn.phai;
                txtBoxTTCNNgSinh.Text = ttcn.ngaySinh;
                txtBoxTTCNPhuCap.Text = ttcn.phuCap.ToString();
                txtBoxTTCNSDT.Text = ttcn.SDT;
                txtBoxTTCNVaiTro.Text = ttcn.vaiTro;
                txtBoxTTCNMaDV.Text = ttcn.maDV;
                return true;
            }
            else return false;
        }
        // các hàm xử lí sự kiện click button ở tab thông tin cá nhân
        private void btnUpdateTTCN_Click(object sender, EventArgs e)
        {
            btnAcceptTTCN.Visible = true;
            btnCancelTTCN.Visible = true;
            btnUpdateTTCN.Visible = false;
            txtBoxTTCNSDT.Enabled = true;
            tempVal = savePrevTxtBox(new List<TextBox> { txtBoxTTCNSDT });
        }
        private void btnCancelTTCN_Click(object sender, EventArgs e)
        {
            btnAcceptTTCN.Visible = false;
            btnCancelTTCN.Visible = false;
            btnUpdateTTCN.Visible = true;
            txtBoxTTCNSDT.Enabled = false;
            loadTxtBoxes(tempVal, new List<TextBox> { txtBoxTTCNSDT });
            tempVal.Clear();
        }
        private void btnAcceptTTCN_Click(object sender, EventArgs e)
        {
            txtBoxTTCNSDT.Enabled = false;
            btnAcceptTTCN.Visible = false;
            btnCancelTTCN.Visible = false;
            btnUpdateTTCN.Visible = true;

            if (NhanSu.updateSDT(txtBoxTTCNSDT.Text))
            {
                MessageBox.Show("Done.");
            }
            else
            {
                MessageBox.Show("Failed.");
                loadTxtBoxes(tempVal, new List<TextBox> { txtBoxTTCNSDT });
            }
            tempVal.Clear();
        }
        // hàm xử lí datagridview tab sinh viên
        private void loadDataGridViewTBSinhVien()
        {
            dataGridViewTBSinhVien.DataSource = SinhVien.getDataTableSinhVien();
            dataGridViewTBSinhVien.ClearSelection();
            dataGridViewTBSinhVien.Sort(dataGridViewTBSinhVien.Columns["MASV"], ListSortDirection.Ascending);
        }
        private void dataGridViewTBSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (!dataGridViewTBSinhVien.Focused) { return ; }
            if (dataGridViewTBSinhVien.Rows.Count > 0 )
            {
                DataGridViewRow selectedRow = dataGridViewTBSinhVien.SelectedRows[0];
                if (selectedRow != null)
                {
                    txtBoxMaSV.Text = selectedRow.Cells["MASV"].Value.ToString();
                    txtBoxHoTenSV.Text = selectedRow.Cells["HOTEN"].Value.ToString();
                    DateTime ngSinh = Convert.ToDateTime(selectedRow.Cells["NGSINH"].Value);
                    dateTimePickerNgSinhSV.Value = ngSinh;
                    txtBoxPhaiSV.Text = selectedRow.Cells["PHAI"].Value.ToString();
                    txtBoxDCSV.Text = selectedRow.Cells["DCHI"].Value.ToString();
                    txtBoxDTSV.Text = selectedRow.Cells["SDT"].Value.ToString();
                    txtBoxMaCTSV.Text = selectedRow.Cells["MACT"].Value.ToString();
                    txtBoxMaNganhSV.Text = selectedRow.Cells["MANGANH"].Value.ToString();
                    txtBoxTCTLSV.Text = selectedRow.Cells["SOTCTL"].Value.ToString();
                    txtBoxTBTLSV.Text = selectedRow.Cells["DTBTL"].Value.ToString();
                }
            }
        }
        // các hàm xử lí sự kiện nút trong tab sinh viên
        private void btnUpdateSinhVien_Click(object sender, EventArgs e)
        {
            dataGridViewTBSinhVien.Enabled = false;
            txtBoxMaSV.Enabled = true;
            txtBoxHoTenSV.Enabled = true;
            txtBoxPhaiSV.Enabled = true;
            dateTimePickerNgSinhSV.Enabled = true;
            txtBoxDCSV.Enabled = true;
            txtBoxDTSV.Enabled = true;
            txtBoxMaCTSV.Enabled = true;
            txtBoxMaNganhSV.Enabled = true;
            txtBoxTCTLSV.Enabled = true;
            txtBoxTBTLSV.Enabled = true;

            tempVal = savePrevTxtBox(new List<TextBox> { txtBoxMaSV, txtBoxHoTenSV, txtBoxPhaiSV,
                txtBoxDCSV, txtBoxDTSV, txtBoxMaCTSV, txtBoxMaNganhSV, txtBoxTCTLSV, txtBoxTBTLSV});
            tempdate = dateTimePickerNgSinhSV.Value;

            btnUpdateSinhVien.Visible = false;
            btnAcptUpdateSinhVien.Visible = true;
            btnCancelUpdateSinhVien.Visible = true;
            btnAddSV.Visible = false;
        }
        private void btnAcptUpdateSinhVien_Click(object sender, EventArgs e)
        {
            dataGridViewTBSinhVien.Enabled = true;
            txtBoxMaSV.Enabled = false;
            txtBoxHoTenSV.Enabled = false;
            txtBoxPhaiSV.Enabled = false;
            dateTimePickerNgSinhSV.Enabled = false;
            txtBoxDCSV.Enabled = false;
            txtBoxDTSV.Enabled = false;
            txtBoxMaCTSV.Enabled = false;
            txtBoxMaNganhSV.Enabled = false;
            txtBoxTCTLSV.Enabled = false;
            txtBoxTBTLSV.Enabled = false;

            int res = SinhVien.updateSV(new SinhVien(txtBoxMaSV.Text, txtBoxHoTenSV.Text, txtBoxPhaiSV.Text,
                dateTimePickerNgSinhSV.Value.ToString("dd-MM-yyyy"), txtBoxDCSV.Text, txtBoxDTSV.Text, txtBoxMaCTSV.Text, txtBoxMaNganhSV.Text,
                int.Parse(txtBoxTCTLSV.Text), double.Parse(txtBoxTBTLSV.Text)));
            if (res == 0)
            {
                MessageBox.Show("Done.");
            }
            else if (res == DatabaseProvider.INTEGRITY_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("INTEGRITY_CONSTRAINT_VIOLATED.");

            }
            else if (res == DatabaseProvider.UNIQUE_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("UNIQUE_CONSTRAINT_VIOLATED.");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }

            if (res != 0)
            {
                loadTxtBoxes(tempVal, new List<TextBox> { txtBoxMaSV, txtBoxHoTenSV, txtBoxPhaiSV,
                txtBoxDCSV, txtBoxDTSV, txtBoxMaCTSV, txtBoxMaNganhSV, txtBoxTCTLSV, txtBoxTBTLSV });
                dateTimePickerNgSinhSV.Value = tempdate;
            }
            else
            {
                tempdate = DateTime.MinValue;
                tempVal.Clear();
            }


            btnUpdateSinhVien.Visible = true;
            btnAcptUpdateSinhVien.Visible = false;
            btnCancelUpdateSinhVien.Visible = false;
            btnAddSV.Visible = true;
        }
        private void btnCancelUpdateSinhVien_Click(object sender, EventArgs e)
        {
            dataGridViewTBSinhVien.Enabled = true;
            txtBoxMaSV.Enabled = false;
            txtBoxHoTenSV.Enabled = false;
            txtBoxPhaiSV.Enabled = false;
            dateTimePickerNgSinhSV.Enabled = false;
            txtBoxDCSV.Enabled = false;  
            txtBoxDTSV.Enabled = false;
            txtBoxMaCTSV.Enabled = false;
            txtBoxMaNganhSV.Enabled = false;
            txtBoxTCTLSV.Enabled = false;
            txtBoxTBTLSV.Enabled = false;

            loadTxtBoxes(tempVal, new List<TextBox> { txtBoxMaSV, txtBoxHoTenSV, txtBoxPhaiSV,
                txtBoxDCSV, txtBoxDTSV, txtBoxMaCTSV, txtBoxMaNganhSV, txtBoxTCTLSV, txtBoxTBTLSV });
            dateTimePickerNgSinhSV.Value = tempdate;
            tempdate = DateTime.MinValue;
            tempVal.Clear(); 

            btnUpdateSinhVien.Visible = true;
            btnAcptUpdateSinhVien.Visible = false;
            btnCancelUpdateSinhVien.Visible = false;
            btnAddSV.Visible = true;
        }
        private void btnAddSV_Click(object sender, EventArgs e)
        {
            dataGridViewTBSinhVien.Enabled = false;
            txtBoxMaSV.Enabled = true;
            txtBoxHoTenSV.Enabled = true;
            txtBoxPhaiSV.Enabled = true;
            dateTimePickerNgSinhSV.Enabled = true;
            txtBoxDCSV.Enabled = true;
            txtBoxDTSV.Enabled = true;
            txtBoxMaCTSV.Enabled = true;
            txtBoxMaNganhSV.Enabled = true;
            txtBoxTCTLSV.Enabled = true;
            txtBoxTBTLSV.Enabled = true;

            tempVal = savePrevTxtBox(new List<TextBox> { txtBoxMaSV, txtBoxHoTenSV, txtBoxPhaiSV,
                txtBoxDCSV, txtBoxDTSV, txtBoxMaCTSV, txtBoxMaNganhSV, txtBoxTCTLSV, txtBoxTBTLSV});
            tempdate = dateTimePickerNgSinhSV.Value;

            txtBoxMaSV.Text = "";
            txtBoxHoTenSV.Text = "";
            txtBoxPhaiSV.Text = "";
            dateTimePickerNgSinhSV.Text = "";
            txtBoxDCSV.Text = "";
            txtBoxDTSV.Text = "";
            txtBoxMaCTSV.Text = "";
            txtBoxMaNganhSV.Text = "";
            txtBoxTCTLSV.Text = "";
            txtBoxTBTLSV.Text = "";
            dateTimePickerNgSinhSV.Value = DateTime.Now;

            btnAddSV.Visible = false;
            btnAcptAdd.Visible = true;
            btnCancelUpdateSinhVien.Visible = true;
            btnUpdateSinhVien.Visible = false;
        }
        private void btnAcptAdd_Click(object sender, EventArgs e)
        {
            dataGridViewTBSinhVien.Enabled = true;
            txtBoxMaSV.Enabled = false;
            txtBoxHoTenSV.Enabled = false;
            txtBoxPhaiSV.Enabled = false;
            dateTimePickerNgSinhSV.Enabled = false;
            txtBoxDCSV.Enabled = false;
            txtBoxDTSV.Enabled = false;
            txtBoxMaCTSV.Enabled = false;
            txtBoxMaNganhSV.Enabled = false;
            txtBoxTCTLSV.Enabled = false;
            txtBoxTBTLSV.Enabled = false;

            int res = SinhVien.insertSV(new SinhVien(txtBoxMaSV.Text, txtBoxHoTenSV.Text, txtBoxPhaiSV.Text,
                dateTimePickerNgSinhSV.Value.ToString("dd-MM-yyyy"), txtBoxDCSV.Text, txtBoxDTSV.Text, txtBoxMaCTSV.Text, txtBoxMaNganhSV.Text,
                int.Parse(txtBoxTCTLSV.Text), double.Parse(txtBoxTBTLSV.Text)));
            if (res == 0)
            {
                MessageBox.Show("Done.");
                loadDataGridViewTBSinhVien();
            }
            else if (res == DatabaseProvider.INTEGRITY_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("INTEGRITY_CONSTRAINT_VIOLATED.");

            }
            else if (res == DatabaseProvider.UNIQUE_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("UNIQUE_CONSTRAINT_VIOLATED.");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }

            if (res != 0)
            {
                loadTxtBoxes(tempVal, new List<TextBox> { txtBoxMaSV, txtBoxHoTenSV, txtBoxPhaiSV,
                txtBoxDCSV, txtBoxDTSV, txtBoxMaCTSV, txtBoxMaNganhSV, txtBoxTCTLSV, txtBoxTBTLSV });
                dateTimePickerNgSinhSV.Value = tempdate;
            }
            else
            {
                tempdate = DateTime.MinValue;
                tempVal.Clear();
            }


            btnUpdateSinhVien.Visible = true;
            btnAcptAdd.Visible = false;
            btnCancelUpdateSinhVien.Visible = false;
            btnAddSV.Visible = true;
        }
        // hàm lấy thông tin cá nhân của sinh viên hiện tại
        private bool loadTTCNSV()
        {
            SinhVien ttcn = SinhVien.getCurrentSV();
            if (ttcn != null)
            {
                txtBoxTTCNSVMaSV.Text = ttcn.maSV;
                txtBoxTTCNSVHoten.Text = ttcn.hoTen;
                txtBoxTTCNSVPhai.Text = ttcn.phai;
                txtBoxTTCNSVNgaySinh.Text = ttcn.ngaySinh;
                txtBoxTTCNSVSoDT.Text = ttcn.DT;
                txtBoxTTCNSVMaCT.Text = ttcn.maCT;
                txtBoxTTCNSVMaNganh.Text = ttcn.maNganh;
                txtBoxTTCNSVSoTCTL.Text = ttcn.soTCTL.ToString();
                txtBoxTTCNSVDiemTBTL.Text = ttcn.diemTBTL.ToString();
                txtBoxTTCNSVDiachi.Text = ttcn.diaChi;
                return true;
            }
            else return false;
        }
        private void btnTTCNSVAcpt_Click(object sender, EventArgs e)
        {
            btnTTCNSVAcpt.Visible = false;
            btnTTCNSVCancel.Visible = false;
            btnTTCNSVUpdate.Visible = true;
            txtBoxTTCNSVSoDT.Enabled = false;
            txtBoxTTCNSVDiachi.Enabled = false;
            tempVal.Clear();
            if (SinhVien.svUpdateTTCN(txtBoxTTCNSVSoDT.Text, txtBoxTTCNSVDiachi.Text))
            {
                MessageBox.Show("Done.");
            }
            else
            {
                MessageBox.Show("Failed.");
            }
        }
        private void btnTTCNSVUpdate_Click(object sender, EventArgs e)
        {
            btnTTCNSVAcpt.Visible = true;
            btnTTCNSVCancel.Visible = true;
            btnTTCNSVUpdate.Visible = false;
            txtBoxTTCNSVSoDT.Enabled = true;
            txtBoxTTCNSVDiachi.Enabled = true;
            tempVal.Add(txtBoxTTCNSVSoDT.Text);
            tempVal.Add(txtBoxTTCNSVDiachi.Text);
        }
        private void btnTTCNSVCancel_Click(object sender, EventArgs e)
        {
            btnTTCNSVAcpt.Visible = false;
            btnTTCNSVCancel.Visible = false;
            btnTTCNSVUpdate.Visible = true;
            txtBoxTTCNSVSoDT.Enabled = false;
            txtBoxTTCNSVDiachi.Enabled = false;
            txtBoxTTCNSVSoDT.Text = tempVal[0];
            txtBoxTTCNSVDiachi.Text = tempVal[1];
            tempVal.Clear();
        }
        private List<string> savePrevTxtBox(List<TextBox> txtboxes)
        {
            List<string> res = new List<string>();
            for (int i = 0; i < txtboxes.Count; i++)
            {
                res.Add(txtboxes[i].Text);
            }
            return res;
        }
        private void loadTxtBoxes(List<string> s, List<TextBox> output)
        {
            for (int i = 0; i < s.Count; i++)
            {
                output[i].Text = s[i];
            }
        }
        private void loadDataGridViewNhanSu()
        {
            dataGridViewNhanSu.DataSource = NhanSu.getDataTableNhanSu();
            dataGridViewNhanSu.ClearSelection();
            dataGridViewNhanSu.Sort(dataGridViewNhanSu.Columns["MANV"], ListSortDirection.Ascending);
            dataGridViewNhanSu.Rows[0].Selected = true;
        }
        private void dataGridViewNhanSu_SelectionChanged(object sender, EventArgs e)
        {
            if (!dataGridViewNhanSu.Focused) { return; }
            if (dataGridViewNhanSu.Rows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewNhanSu.SelectedRows[0];
                if (selectedRow != null)
                {
                    txtBoxNSMaNV.Text = selectedRow.Cells["MANV"].Value.ToString();
                    txtBoxNSHoTen.Text = selectedRow.Cells["HOTEN"].Value.ToString();
                    DateTime ngSinh = Convert.ToDateTime(selectedRow.Cells["NGSINH"].Value);
                    dateTimePickerNSNgSinh.Value = ngSinh;
                    txtBoxNSPhai.Text = selectedRow.Cells["PHAI"].Value.ToString();
                    txtBoxNSPhuCap.Text = selectedRow.Cells["PHUCAP"].Value.ToString();
                    txtBoxNSDT.Text = selectedRow.Cells["SDT"].Value.ToString();
                    txtBoxNSVaiTro.Text = selectedRow.Cells["VAITRO"].Value.ToString();
                    txtBoxNSMaDV.Text = selectedRow.Cells["MADV"].Value.ToString();
                }
            }
        }

        private void btnNSUpdate_Click(object sender, EventArgs e)
        {
            dataGridViewNhanSu.Enabled = false;
            txtBoxNSMaNV.Enabled = true;
            txtBoxNSHoTen.Enabled = true;
            txtBoxNSPhai.Enabled = true;
            dateTimePickerNSNgSinh.Enabled = true;
            txtBoxNSPhuCap.Enabled = true;
            txtBoxNSDT.Enabled = true;
            txtBoxNSVaiTro.Enabled = true;
            txtBoxNSMaDV.Enabled = true;

            tempVal = savePrevTxtBox(new List<TextBox> { txtBoxNSMaNV, txtBoxNSHoTen, txtBoxNSPhai,
                txtBoxNSPhuCap, txtBoxNSDT, txtBoxNSVaiTro, txtBoxNSMaDV});
            tempdate = dateTimePickerNSNgSinh.Value;

            btnNSUpdate.Visible = false;
            btnNSAdd.Visible = false;
            btnNSDelete.Visible = false;
            btnNSAcptUpdate.Visible = true;
            btnNSCancel.Visible = true;
        }

        private void btnNSAdd_Click(object sender, EventArgs e)
        {
            dataGridViewNhanSu.Enabled = false;
            txtBoxNSMaNV.Enabled = true;
            txtBoxNSHoTen.Enabled = true;
            txtBoxNSPhai.Enabled = true;
            dateTimePickerNSNgSinh.Enabled = true;
            txtBoxNSPhuCap.Enabled = true;
            txtBoxNSDT.Enabled = true;
            txtBoxNSVaiTro.Enabled = true;
            txtBoxNSMaDV.Enabled = true;

            tempVal = savePrevTxtBox(new List<TextBox> { txtBoxNSMaNV, txtBoxNSHoTen, txtBoxNSPhai,
                txtBoxNSPhuCap, txtBoxNSDT, txtBoxNSVaiTro, txtBoxNSMaDV});
            tempdate = dateTimePickerNSNgSinh.Value;

            txtBoxNSMaNV.Text = "";
            txtBoxNSHoTen.Text = "";
            txtBoxNSPhai.Text = "";
            dateTimePickerNSNgSinh.Text = "";
            txtBoxNSPhuCap.Text = "";
            txtBoxNSDT.Text = "";
            txtBoxNSVaiTro.Text = "";
            txtBoxNSMaDV.Text = "";

            btnNSUpdate.Visible = false;
            btnNSAdd.Visible = false;
            btnNSDelete.Visible = false;
            btnNSAcptAdd.Visible = true;
            btnNSCancel.Visible = true;
        }

        private void btnNSDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Xóa nhân viên {txtBoxNSMaNV.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (NhanSu.deleteNhanSu(txtBoxNSMaNV.Text))
                {
                    MessageBox.Show("Deleted.");
                }
                else
                {
                    MessageBox.Show("Something went wrong.");
                }
            }
            loadDataGridViewNhanSu();
        }

        private void btnNSAcptAdd_Click(object sender, EventArgs e)
        {
            dataGridViewNhanSu.Enabled = true;
            txtBoxNSMaNV.Enabled = false;
            txtBoxNSHoTen.Enabled = false;
            txtBoxNSPhai.Enabled = false;
            dateTimePickerNSNgSinh.Enabled = false;
            txtBoxNSPhuCap.Enabled = false;
            txtBoxNSDT.Enabled = false;
            txtBoxNSVaiTro.Enabled = false;
            txtBoxNSMaDV.Enabled = false;

            int res = NhanSu.insertNhanSu(new NhanSu(txtBoxNSMaNV.Text, txtBoxNSHoTen.Text, txtBoxNSPhai.Text,
                dateTimePickerNSNgSinh.Value.ToString("dd-MM-yyyy"), txtBoxNSDT.Text, txtBoxNSVaiTro.Text, txtBoxNSMaDV.Text,
                int.Parse(txtBoxNSPhuCap.Text)));
            if (res == 0)
            {
                MessageBox.Show("Done.");
                loadDataGridViewNhanSu();
            }
            else if (res == DatabaseProvider.INTEGRITY_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("INTEGRITY_CONSTRAINT_VIOLATED.");

            }
            else if (res == DatabaseProvider.UNIQUE_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("UNIQUE_CONSTRAINT_VIOLATED.");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }

            if (res != 0)
            {
                loadTxtBoxes(tempVal, new List<TextBox> { txtBoxNSMaNV, txtBoxNSHoTen, txtBoxNSPhai,
                txtBoxNSPhuCap, txtBoxNSDT, txtBoxNSVaiTro, txtBoxNSMaDV });
            }
            else
            {
                tempdate = DateTime.MinValue;
                tempVal.Clear();
            }


            btnNSUpdate.Visible = true;
            btnNSAdd.Visible = true;
            btnNSDelete.Visible = true;
            btnNSAcptUpdate.Visible = false;
            btnNSCancel.Visible = false;
            btnNSAcptUpdate.Visible = false;
            btnNSAcptAdd.Visible = false;

        }

        private void btnNSAcptUpdate_Click(object sender, EventArgs e)
        {
            dataGridViewNhanSu.Enabled = true;
            txtBoxNSMaNV.Enabled = false;
            txtBoxNSHoTen.Enabled = false;
            txtBoxNSPhai.Enabled = false;
            dateTimePickerNSNgSinh.Enabled = false;
            txtBoxNSPhuCap.Enabled = false;
            txtBoxNSDT.Enabled = false;
            txtBoxNSVaiTro.Enabled = false;
            txtBoxNSMaDV.Enabled = false;

            int res = NhanSu.updateNhanSu(new NhanSu(txtBoxNSMaNV.Text, txtBoxNSHoTen.Text, txtBoxNSPhai.Text,
                dateTimePickerNSNgSinh.Value.ToString("dd-MM-yyyy"), txtBoxNSDT.Text, txtBoxNSVaiTro.Text, txtBoxNSMaDV.Text,
                int.Parse(txtBoxNSPhuCap.Text)));
            if (res == 0)
            {
                MessageBox.Show("Done.");
            }
            else if (res == DatabaseProvider.INTEGRITY_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("INTEGRITY_CONSTRAINT_VIOLATED.");

            }
            else if (res == DatabaseProvider.UNIQUE_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("UNIQUE_CONSTRAINT_VIOLATED.");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }

            if (res != 0)
            {
                loadTxtBoxes(tempVal, new List<TextBox> { txtBoxNSMaNV, txtBoxNSHoTen, txtBoxNSPhai,
                txtBoxNSPhuCap, txtBoxNSDT, txtBoxNSVaiTro, txtBoxNSMaDV });
            }
            else
            {
                tempdate = DateTime.MinValue;
                tempVal.Clear();
            }


            btnNSUpdate.Visible = true;
            btnNSAdd.Visible = true;
            btnNSDelete.Visible = true;
            btnNSAcptUpdate.Visible = false;
            btnNSCancel.Visible = false;
            btnNSAcptUpdate.Visible = false;
            btnNSAcptAdd.Visible = false;
        }

        private void btnNSCancel_Click(object sender, EventArgs e)
        {
            dataGridViewNhanSu.Enabled = true;
            txtBoxNSMaNV.Enabled = false;
            txtBoxNSHoTen.Enabled = false;
            txtBoxNSPhai.Enabled = false;
            dateTimePickerNSNgSinh.Enabled = false;
            txtBoxNSPhuCap.Enabled = false;
            txtBoxNSDT.Enabled = false;
            txtBoxNSVaiTro.Enabled = false;
            txtBoxNSMaDV.Enabled = false;

            loadTxtBoxes(tempVal, new List<TextBox> { txtBoxNSMaNV, txtBoxNSHoTen, txtBoxNSPhai,
                txtBoxNSPhuCap, txtBoxNSDT, txtBoxNSVaiTro, txtBoxNSMaDV });

            dateTimePickerNSNgSinh.Value = tempdate;
            tempdate = DateTime.MinValue;
            tempVal.Clear();

            btnNSUpdate.Visible = true;
            btnNSAdd.Visible = true;
            btnNSDelete.Visible = true;
            btnNSAcptUpdate.Visible = false;
            btnNSCancel.Visible = false;
            btnNSAcptUpdate.Visible = false;
            btnNSAcptAdd.Visible = false;
        }
    }
}
