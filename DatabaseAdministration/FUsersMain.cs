using DatabaseAdministration.DataProvider;
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

                    loadDataGridViewTBSinhVien();
                    break;
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
        // Sự kiện dổi tab
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage selectedTab = tabControl.SelectedTab;

            if (selectedTab == tabPageSinhVien) {
                if (dataGridViewTBSinhVien.Rows.Count > 0)
                {
                    bool r = dataGridViewTBSinhVien.Focus();
                    dataGridViewTBSinhVien.Rows[0].Selected = true;
                    dataGridViewTBSinhVien_SelectionChanged(sender, null);
                }
            }
        }


    }
}
