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
            tempVal.Add(txtBoxTTCNSDT.Text);
        }

        private void btnCancelTTCN_Click(object sender, EventArgs e)
        {
            btnAcceptTTCN.Visible = false;
            btnCancelTTCN.Visible = false;
            btnUpdateTTCN.Visible = true;
            txtBoxTTCNSDT.Enabled = false;
            txtBoxTTCNSDT.Text = tempVal[0];
            tempVal.Clear();
        }

        private void btnAcceptTTCN_Click(object sender, EventArgs e)
        {
            txtBoxTTCNSDT.Enabled = false;
            btnAcceptTTCN.Visible = false;
            btnCancelTTCN.Visible = false;
            btnUpdateTTCN.Visible = true;
            tempVal.Clear();
            if (NhanSu.updateSDT(txtBoxTTCNSDT.Text))
            {
                MessageBox.Show("Done.");
            }
            else
            {
                MessageBox.Show("Failed.");
            }
        }
        // hàm xử lí datagridview tab sinh viên
        private void loadDataGridViewTBSinhVien()
        {
            dataGridViewTBSinhVien.DataSource = SinhVien.getDataTableSinhVien();
            dataGridViewTBSinhVien.ClearSelection();
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
                    txtBoxNgSinhSV.Text = ngSinh.ToString("dd/MM/yyyy");
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
    }
}
