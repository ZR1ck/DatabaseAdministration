using DatabaseAdministration.DataProvider;
using DatabaseAdministration.DTO;
using DatabaseAdministration.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAdministration
{
    public partial class FUsersMain : Form
    {
        private int role;
        private List<string> tempVal = new List<string>();
        private DateTime tempdate = DateTime.MinValue;
        private PhanCong tempPc = null;
        string tempstring = string.Empty;

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
                    loadDataGridViewDonVi();

                    break;
                case 3: // GIAOVU
                    tabPageTTSinhVien.Parent = null;
                    tabPageNhanSu.Parent = null;

                    loadTTCN();
                    loadDataGridViewTBSinhVien();
                    loaddataGridViewPhanCong();
                    loadDataGridViewDonVi();

                    btnUpdateSinhVien.Visible = true;
                    btnAddSV.Visible = true;

                    btnPCUpdate.Enabled = true;

                    btnDVAdd.Visible = true;
                    btnDVUpdate.Visible = true;

                    break;
                case 4: // GV
                    tabPageTTSinhVien.Parent = null;
                    tabPageNhanSu.Parent = null;

                    loadTTCN();
                    loadDataGridViewTBSinhVien();
                    loaddataGridViewPhanCong();
                    loadDataGridViewDonVi();

                    break;
                case 5: // TRGDV
                    tabPageTTSinhVien.Parent = null;
                    tabPageNhanSu.Parent = null;

                    loadTTCN();
                    loadDataGridViewTBSinhVien();
                    loaddataGridViewPhanCong();
                    loadDataGridViewDonVi();

                    btnPCAdd.Enabled = true;
                    btnPCDelete.Enabled = true;
                    btnPCUpdate.Enabled = true;

                    break;
                case 6: // TRGKHOA
                    tabPageTTSinhVien.Parent = null;
                    tabPageTTNhanSu.Parent = null;

                    loadDataGridViewTBSinhVien();
                    loadDataGridViewNhanSu();
                    loaddataGridViewPhanCong();
                    loadDataGridViewDonVi();

                    btnPCAdd.Enabled = true;
                    btnPCDelete.Enabled = true;
                    btnPCUpdate.Enabled = true;

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
            else if (selectedTab == tabPagePhanCong)
            {
                if (dataGridViewPhanCong.Rows.Count > 0)
                {
                    dataGridViewPhanCong.Focus();
                    dataGridViewPhanCong.Rows[0].Selected = true;
                    dataGridViewPhanCong_SelectionChanged(sender, null);
                }
            }
            else if (selectedTab == tabPageDonVi)
            {
                if (dataGridViewDonVi.Rows.Count > 0)
                {
                    dataGridViewDonVi.Focus();
                    dataGridViewDonVi.Rows[0].Selected = true;
                    dataGridViewDonVi_SelectionChanged(sender, null);
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
            tempVal = Util.savePrevTxtBox(new List<TextBox> { txtBoxTTCNSDT });
        }
        private void btnCancelTTCN_Click(object sender, EventArgs e)
        {
            btnAcceptTTCN.Visible = false;
            btnCancelTTCN.Visible = false;
            btnUpdateTTCN.Visible = true;
            txtBoxTTCNSDT.Enabled = false;
            Util.loadTxtBoxes(tempVal, new List<TextBox> { txtBoxTTCNSDT });
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
                loadTTCN();
            }
            else
            {
                MessageBox.Show("Failed.");
                Util.loadTxtBoxes(tempVal, new List<TextBox> { txtBoxTTCNSDT });
            }
            tempVal.Clear();
        }
        // hàm xử lí datagridview và xử lí sự kiện nút tab sinh viên
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

            tempVal = Util.savePrevTxtBox(new List<TextBox> { txtBoxMaSV, txtBoxHoTenSV, txtBoxPhaiSV,
                txtBoxDCSV, txtBoxDTSV, txtBoxMaCTSV, txtBoxMaNganhSV, txtBoxTCTLSV, txtBoxTBTLSV});
            tempdate = dateTimePickerNgSinhSV.Value;

            btnUpdateSinhVien.Visible = false;
            btnAcptUpdateSinhVien.Visible = true;
            btnCancelUpdateSinhVien.Visible = true;
            btnAddSV.Visible = false;
        }
        private void btnAcptUpdateSinhVien_Click(object sender, EventArgs e)
        {
            if (Util.hasEmptyTextBox(new List<TextBox> { txtBoxMaSV, txtBoxHoTenSV, txtBoxPhaiSV,
                txtBoxDCSV, txtBoxDTSV, txtBoxMaCTSV, txtBoxMaNganhSV, txtBoxTCTLSV, txtBoxTBTLSV }))
            {
                MessageBox.Show("Empty field.");
                return;
            }
            if (Util.hasSpecialCharacters(new List<TextBox> { txtBoxMaSV, txtBoxHoTenSV, txtBoxPhaiSV,
                txtBoxDCSV, txtBoxDTSV, txtBoxMaCTSV, txtBoxMaNganhSV, txtBoxTCTLSV, txtBoxTBTLSV }))
            {
                MessageBox.Show("Contain special character.");
                return;
            }

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
            else if (res == DatabaseProvider.NO_ROWSAFFECTED)
            {
                MessageBox.Show("NO_ROWSAFFECTED.");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }

            if (res != 0)
            {
                Util.loadTxtBoxes(tempVal, new List<TextBox> { txtBoxMaSV, txtBoxHoTenSV, txtBoxPhaiSV,
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

            Util.loadTxtBoxes(tempVal, new List<TextBox> { txtBoxMaSV, txtBoxHoTenSV, txtBoxPhaiSV,
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

            tempVal = Util.savePrevTxtBox(new List<TextBox> { txtBoxMaSV, txtBoxHoTenSV, txtBoxPhaiSV,
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
            if (Util.hasEmptyTextBox(new List<TextBox> { txtBoxMaSV, txtBoxHoTenSV, txtBoxPhaiSV,
                txtBoxDCSV, txtBoxDTSV, txtBoxMaCTSV, txtBoxMaNganhSV, txtBoxTCTLSV, txtBoxTBTLSV }))
            {
                MessageBox.Show("Empty field.");
                return;
            }
            if (Util.hasSpecialCharacters(new List<TextBox> { txtBoxMaSV, txtBoxHoTenSV, txtBoxPhaiSV,
                txtBoxDCSV, txtBoxDTSV, txtBoxMaCTSV, txtBoxMaNganhSV, txtBoxTCTLSV, txtBoxTBTLSV }))
            {
                MessageBox.Show("Contain special character.");
                return;
            }

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
                Util.loadTxtBoxes(tempVal, new List<TextBox> { txtBoxMaSV, txtBoxHoTenSV, txtBoxPhaiSV,
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
                loadTTCNSV();
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
        // hàm xử lí datagridview và xử lí sự kiện nút tab nhân sự
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

            tempVal = Util.savePrevTxtBox(new List<TextBox> { txtBoxNSMaNV, txtBoxNSHoTen, txtBoxNSPhai,
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

            tempVal = Util.savePrevTxtBox(new List<TextBox> { txtBoxNSMaNV, txtBoxNSHoTen, txtBoxNSPhai,
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
            if (Util.hasEmptyTextBox(new List<TextBox> { txtBoxNSMaNV, txtBoxNSHoTen, txtBoxNSPhai,
                txtBoxNSPhuCap, txtBoxNSDT, txtBoxNSVaiTro, txtBoxNSMaDV }))
            {
                MessageBox.Show("Empty field.");
                return;
            }
            if (Util.hasSpecialCharacters(new List<TextBox> { txtBoxNSMaNV, txtBoxNSHoTen, txtBoxNSPhai,
                txtBoxNSPhuCap, txtBoxNSDT, txtBoxNSVaiTro, txtBoxNSMaDV }))
            {
                MessageBox.Show("Contain special character.");
                return;
            }

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
            else if (res == DatabaseProvider.NO_ROWSAFFECTED)
            {
                MessageBox.Show("NO_ROWSAFFECTED.");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }

            if (res != 0)
            {
                Util.loadTxtBoxes(tempVal, new List<TextBox> { txtBoxNSMaNV, txtBoxNSHoTen, txtBoxNSPhai,
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
            if (Util.hasEmptyTextBox(new List<TextBox> { txtBoxNSMaNV, txtBoxNSHoTen, txtBoxNSPhai,
                txtBoxNSPhuCap, txtBoxNSDT, txtBoxNSVaiTro, txtBoxNSMaDV }))
            {
                MessageBox.Show("Empty field.");
                return;
            }
            if (Util.hasSpecialCharacters(new List<TextBox> { txtBoxNSMaNV, txtBoxNSHoTen, txtBoxNSPhai,
                txtBoxNSPhuCap, txtBoxNSDT, txtBoxNSVaiTro, txtBoxNSMaDV }))
            {
                MessageBox.Show("Contain special character.");
                return;
            }

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
            else if (res == DatabaseProvider.NO_ROWSAFFECTED)
            {
                MessageBox.Show("NO_ROWSAFFECTED.");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }

            if (res != 0)
            {
                Util.loadTxtBoxes(tempVal, new List<TextBox> { txtBoxNSMaNV, txtBoxNSHoTen, txtBoxNSPhai,
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

            Util.loadTxtBoxes(tempVal, new List<TextBox> { txtBoxNSMaNV, txtBoxNSHoTen, txtBoxNSPhai,
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
        // hàm xử lí datagridview và xử lí sự kiện nút tab phân công
        private void loaddataGridViewPhanCong()
        {
            dataGridViewPhanCong.DataSource = PhanCong.getDataTablePhanCong();
            dataGridViewPhanCong.ClearSelection();
            dataGridViewPhanCong.Sort(dataGridViewPhanCong.Columns["MAHP"], ListSortDirection.Ascending);
            if(dataGridViewPhanCong.Rows.Count > 0) dataGridViewPhanCong.Rows[0].Selected = true;
        }
        private void dataGridViewPhanCong_SelectionChanged(object sender, EventArgs e)
        {
            if (!dataGridViewPhanCong.Focused) { return; }
            if (dataGridViewPhanCong.Rows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewPhanCong.SelectedRows[0];
                if (selectedRow != null)
                {
                    txtBoxPCMaGV.Text = selectedRow.Cells["MAGV"].Value.ToString();
                    txtBoxPCMaHP.Text = selectedRow.Cells["MAHP"].Value.ToString();
                    txtBoxPCHocKi.Text = selectedRow.Cells["HK"].Value.ToString();
                    txtBoxPCNam.Text = selectedRow.Cells["NAM"].Value.ToString();
                    txtBoxPCMaCT.Text = selectedRow.Cells["MACT"].Value.ToString();
                }
            }
        }
        private void btnPCUpdate_Click(object sender, EventArgs e)
        {
            dataGridViewPhanCong.Enabled = false;
            txtBoxPCMaGV.Enabled = true;
            txtBoxPCMaHP.Enabled = true;
            txtBoxPCHocKi.Enabled = true;
            txtBoxPCNam.Enabled = true;
            txtBoxPCMaCT.Enabled = true;

            tempPc = new PhanCong(txtBoxPCMaGV.Text, txtBoxPCMaHP.Text, txtBoxPCHocKi.Text,
                txtBoxPCMaCT.Text, int.Parse(txtBoxPCNam.Text));
            tempVal = Util.savePrevTxtBox(new List<TextBox> { txtBoxPCMaGV, txtBoxPCMaHP, txtBoxPCHocKi,
                txtBoxPCNam, txtBoxPCMaCT});

            btnPCAcptUpdate.Visible = true;
            btnPCCancel.Visible = true;

            btnPCUpdate.Visible = false;
            btnPCAdd.Visible = false;
            btnPCDelete.Visible = false;
        }
        private void btnPCAdd_Click(object sender, EventArgs e)
        {

            dataGridViewPhanCong.Enabled = false;
            txtBoxPCMaGV.Enabled = true;
            txtBoxPCMaHP.Enabled = true;
            txtBoxPCHocKi.Enabled = true;
            txtBoxPCNam.Enabled = true;
            txtBoxPCMaCT.Enabled = true;

            tempPc = new PhanCong(txtBoxPCMaGV.Text, txtBoxPCMaHP.Text, txtBoxPCHocKi.Text,
                txtBoxPCMaCT.Text, int.Parse(txtBoxPCNam.Text));
            tempVal = Util.savePrevTxtBox(new List<TextBox> { txtBoxPCMaGV, txtBoxPCMaHP, txtBoxPCHocKi,
                txtBoxPCNam, txtBoxPCMaCT});

            txtBoxPCMaGV.Text = "";
            txtBoxPCMaHP.Text = "";
            txtBoxPCHocKi.Text = "";
            txtBoxPCNam.Text = "";
            txtBoxPCMaCT.Text = "";

            btnPCAcptAdd.Visible = true;
            btnPCCancel.Visible = true;

            btnPCUpdate.Visible = false;
            btnPCAdd.Visible = false;
            btnPCDelete.Visible = false;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Xóa Phân công đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int res = PhanCong.deletePhanCong(new PhanCong(txtBoxPCMaGV.Text, txtBoxPCMaHP.Text, txtBoxPCHocKi.Text,
                txtBoxPCMaCT.Text, int.Parse(txtBoxPCNam.Text)));
                if (res == 0)
                {
                    MessageBox.Show("Deleted.");
                    loaddataGridViewPhanCong();
                }
                else if (res == DatabaseProvider.NO_ROWSAFFECTED)
                {
                    MessageBox.Show("NO_ROWSAFFECTED.");
                }
                else
                {
                    MessageBox.Show("Something went wrong.");
                }
            }
        }
        private void btnPCAcptAdd_Click(object sender, EventArgs e)
        {
            if (Util.hasEmptyTextBox(new List<TextBox> { txtBoxPCMaGV, txtBoxPCMaHP, txtBoxPCHocKi,
                txtBoxPCNam, txtBoxPCMaCT }))
            {
                MessageBox.Show("Empty field.");
                return;
            }
            if (Util.hasSpecialCharacters(new List<TextBox> { txtBoxPCMaGV, txtBoxPCMaHP, txtBoxPCHocKi,
                txtBoxPCNam, txtBoxPCMaCT }))
            {
                MessageBox.Show("Contain special character.");
                return;
            }

            dataGridViewPhanCong.Enabled = true;
            txtBoxPCMaGV.Enabled = false;
            txtBoxPCMaHP.Enabled = false;
            txtBoxPCHocKi.Enabled = false;
            txtBoxPCNam.Enabled = false;
            txtBoxPCMaCT.Enabled = false;

            int res = PhanCong.insertPhanCong(new PhanCong(txtBoxPCMaGV.Text, txtBoxPCMaHP.Text, txtBoxPCHocKi.Text,
                txtBoxPCMaCT.Text, int.Parse(txtBoxPCNam.Text)));
            if (res == 0)
            {
                MessageBox.Show("Done.");
                loaddataGridViewPhanCong();
            }
            else if (res == DatabaseProvider.INTEGRITY_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("INTEGRITY_CONSTRAINT_VIOLATED.");

            }
            else if (res == DatabaseProvider.UNIQUE_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("UNIQUE_CONSTRAINT_VIOLATED.");
            }
            else if (res == DatabaseProvider.NO_ROWSAFFECTED)
            {
                MessageBox.Show("NO_ROWSAFFECTED.");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }

            if (res != 0)
            {
                Util.loadTxtBoxes(tempVal, new List<TextBox> { txtBoxPCMaGV, txtBoxPCMaHP, txtBoxPCHocKi,
                    txtBoxPCNam, txtBoxPCMaCT});
            }
            else
            {
                tempVal.Clear();
                tempPc = null;
            }

            btnPCAcptAdd.Visible = false;
            btnPCCancel.Visible = false;

            btnPCUpdate.Visible = true;
            btnPCAdd.Visible = true;
            btnPCDelete.Visible = true;
        }
        private void btnPCAcptUpdate_Click(object sender, EventArgs e)
        {
            if (Util.hasEmptyTextBox(new List<TextBox> { txtBoxPCMaGV, txtBoxPCMaHP, txtBoxPCHocKi,
                txtBoxPCNam, txtBoxPCMaCT }))
            {
                MessageBox.Show("Empty field.");
                return;
            }
            if (Util.hasSpecialCharacters(new List<TextBox> { txtBoxPCMaGV, txtBoxPCMaHP, txtBoxPCHocKi,
                txtBoxPCNam, txtBoxPCMaCT }))
            {
                MessageBox.Show("Contain special character.");
                return;
            }

            dataGridViewPhanCong.Enabled = true;
            txtBoxPCMaGV.Enabled = false;
            txtBoxPCMaHP.Enabled = false;
            txtBoxPCHocKi.Enabled = false;
            txtBoxPCNam.Enabled = false;
            txtBoxPCMaCT.Enabled = false;

            int res = PhanCong.updatePhanCong(new PhanCong(txtBoxPCMaGV.Text, txtBoxPCMaHP.Text, txtBoxPCHocKi.Text,
                txtBoxPCMaCT.Text, int.Parse(txtBoxPCNam.Text)), tempPc);
            if (res == 0)
            {
                MessageBox.Show("Done.");
                loaddataGridViewPhanCong();
            }
            else if (res == DatabaseProvider.INTEGRITY_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("INTEGRITY_CONSTRAINT_VIOLATED.");

            }
            else if (res == DatabaseProvider.UNIQUE_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("UNIQUE_CONSTRAINT_VIOLATED.");
            }
            else if (res == DatabaseProvider.NO_ROWSAFFECTED)
            {
                MessageBox.Show("NO_ROWSAFFECTED.");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }

            if (res != 0)
            {
                Util.loadTxtBoxes(tempVal, new List<TextBox> { txtBoxPCMaGV, txtBoxPCMaHP, txtBoxPCHocKi,
                    txtBoxPCNam, txtBoxPCMaCT});
            }
            else
            {
                tempVal.Clear();
                tempPc = null;
            }

            btnPCAcptUpdate.Visible = false;
            btnPCCancel.Visible = false;

            btnPCUpdate.Visible = true;
            btnPCAdd.Visible = true;
            btnPCDelete.Visible = true;
        }
        private void btnPCCancel_Click(object sender, EventArgs e)
        {
            dataGridViewPhanCong.Enabled = true;
            txtBoxPCMaGV.Enabled = false;
            txtBoxPCMaHP.Enabled = false;
            txtBoxPCHocKi.Enabled = false;
            txtBoxPCNam.Enabled = false;
            txtBoxPCMaCT.Enabled = false;

            Util.loadTxtBoxes(tempVal, new List<TextBox> { txtBoxPCMaGV, txtBoxPCMaHP, txtBoxPCHocKi,
                    txtBoxPCNam, txtBoxPCMaCT});
            tempVal.Clear();
            tempPc = null;

            btnPCAcptUpdate.Visible = false;
            btnPCAcptAdd.Visible = false;
            btnPCCancel.Visible = false;

            btnPCUpdate.Visible = true;
            btnPCAdd.Visible = true;
            btnPCDelete.Visible = true;

        }
        // hàm xử lí datagridview và xử lí sự kiện nút tab đơn vị
        private void loadDataGridViewDonVi()
        {
            dataGridViewDonVi.DataSource = DonVi.getDataTableDonVi();
            dataGridViewDonVi.ClearSelection();
            dataGridViewDonVi.Sort(dataGridViewDonVi.Columns["MADV"], ListSortDirection.Ascending);
            if (dataGridViewDonVi.Rows.Count > 0) dataGridViewDonVi.Rows[0].Selected = true;
        }
        private void dataGridViewDonVi_SelectionChanged(object sender, EventArgs e)
        {
            if (!dataGridViewDonVi.Focused) { return; }
            if (dataGridViewDonVi.Rows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewDonVi.SelectedRows[0];
                if (selectedRow != null)
                {
                    txtBoxDVMaDV.Text = selectedRow.Cells["MADV"].Value.ToString();
                    txtBoxDVTenDV.Text = selectedRow.Cells["TENDV"].Value.ToString();
                    txtBoxDVTrgDV.Text = selectedRow.Cells["TRGDV"].Value.ToString();
                }
            }
        }
        private void btnDVUpdate_Click(object sender, EventArgs e)
        {
            dataGridViewDonVi.Enabled = false;
            txtBoxDVMaDV.Enabled = true;
            txtBoxDVTenDV.Enabled = true;
            txtBoxDVTrgDV.Enabled = true;

            tempVal = Util.savePrevTxtBox(new List<TextBox> { txtBoxDVMaDV, txtBoxDVTenDV, txtBoxDVTrgDV});
            tempstring = txtBoxDVMaDV.Text;

            btnDVAcptUpdate.Visible = true;
            btnDVCancel.Visible = true;

            btnDVUpdate.Visible = false;
            btnDVAdd.Visible = false;
        }
        private void btnDVAdd_Click(object sender, EventArgs e)
        {
            dataGridViewDonVi.Enabled = false;
            txtBoxDVMaDV.Enabled = true;
            txtBoxDVTenDV.Enabled = true;
            txtBoxDVTrgDV.Enabled = true;

            tempVal = Util.savePrevTxtBox(new List<TextBox> { txtBoxDVMaDV, txtBoxDVTenDV, txtBoxDVTrgDV });

            txtBoxDVMaDV.Text = "";
            txtBoxDVTenDV.Text = "";
            txtBoxDVTrgDV.Text = "";

            btnDVAcptAdd.Visible = true;
            btnDVCancel.Visible = true;

            btnDVUpdate.Visible = false;
            btnDVAdd.Visible = false;
        }
        private void btnDVAcptUpdate_Click(object sender, EventArgs e)
        {
            if (Util.hasEmptyTextBox(new List<TextBox> { txtBoxDVMaDV, txtBoxDVTenDV, txtBoxDVTrgDV }))
            {
                MessageBox.Show("Empty field.");
                return;
            }
            if (Util.hasSpecialCharacters(new List<TextBox> { txtBoxDVMaDV, txtBoxDVTenDV, txtBoxDVTrgDV }))
            {
                MessageBox.Show("Contain special character.");
                return;
            }

            dataGridViewDonVi.Enabled = true;
            txtBoxDVMaDV.Enabled = false;
            txtBoxDVTenDV.Enabled = false;
            txtBoxDVTrgDV.Enabled = false;

            int res = DonVi.updateDonVi(new DonVi(txtBoxDVMaDV.Text, txtBoxDVTenDV.Text, txtBoxDVTrgDV.Text), tempstring);
            if (res == 0)
            {
                MessageBox.Show("Done.");
                loadDataGridViewDonVi();
            }
            else if (res == DatabaseProvider.INTEGRITY_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("INTEGRITY_CONSTRAINT_VIOLATED.");

            }
            else if (res == DatabaseProvider.UNIQUE_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("UNIQUE_CONSTRAINT_VIOLATED.");
            }
            else if (res == DatabaseProvider.NO_ROWSAFFECTED)
            {
                MessageBox.Show("NO_ROWSAFFECTED.");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }

            if (res != 0)
            {
                Util.loadTxtBoxes(tempVal, new List<TextBox> { txtBoxDVMaDV, txtBoxDVTenDV, txtBoxDVTrgDV });
            }
            else
            {
                tempVal.Clear();
                tempstring = string.Empty;
            }

            btnDVAcptUpdate.Visible = false;
            btnDVCancel.Visible = false;

            btnDVUpdate.Visible = true;
            btnDVAdd.Visible = true;
        }

        private void btnDVAcptAdd_Click(object sender, EventArgs e)
        {
            if (Util.hasEmptyTextBox(new List<TextBox> { txtBoxDVMaDV, txtBoxDVTenDV, txtBoxDVTrgDV }))
            {
                MessageBox.Show("Empty field.");
                return;
            }
            if (Util.hasSpecialCharacters(new List<TextBox> { txtBoxDVMaDV, txtBoxDVTenDV, txtBoxDVTrgDV }))
            {
                MessageBox.Show("Contain special character.");
                return;
            }

            dataGridViewDonVi.Enabled = true;
            txtBoxDVMaDV.Enabled = false;
            txtBoxDVTenDV.Enabled = false;
            txtBoxDVTrgDV.Enabled = false;

            int res = DonVi.insertDonVi(new DonVi(txtBoxDVMaDV.Text, txtBoxDVTenDV.Text, txtBoxDVTrgDV.Text));
            if (res == 0)
            {
                MessageBox.Show("Done.");
                loadDataGridViewDonVi();
            }
            else if (res == DatabaseProvider.INTEGRITY_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("INTEGRITY_CONSTRAINT_VIOLATED.");

            }
            else if (res == DatabaseProvider.UNIQUE_CONSTRAINT_VIOLATED)
            {
                MessageBox.Show("UNIQUE_CONSTRAINT_VIOLATED.");
            }
            else if (res == DatabaseProvider.NO_ROWSAFFECTED)
            {
                MessageBox.Show("NO_ROWSAFFECTED.");
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }

            if (res != 0)
            {
                Util.loadTxtBoxes(tempVal, new List<TextBox> { txtBoxDVMaDV, txtBoxDVTenDV, txtBoxDVTrgDV });
            }
            else
            {
                tempVal.Clear();
                tempstring = string.Empty;
            }

            btnDVAcptAdd.Visible = false;
            btnDVCancel.Visible = false;

            btnDVUpdate.Visible = true;
            btnDVAdd.Visible = true;
        }

        private void btnDVCancel_Click(object sender, EventArgs e)
        {
            dataGridViewDonVi.Enabled = true;
            txtBoxDVMaDV.Enabled = false;
            txtBoxDVTenDV.Enabled = false;
            txtBoxDVTrgDV.Enabled = false;

            Util.loadTxtBoxes(tempVal, new List<TextBox> { txtBoxDVMaDV, txtBoxDVTenDV, txtBoxDVTrgDV });
            tempVal.Clear();

            btnDVAcptUpdate.Visible = false;
            btnDVAcptAdd .Visible = false;
            btnDVCancel.Visible = false;

            btnDVUpdate.Visible = true;
            btnDVAdd.Visible = true;
        }
    }
}
