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
        public FUsersMain(int role)
        {
            InitializeComponent();
            this.role = role;
            switch (role)
            {
                case 1: // SV
                    tabPageTTNhanSu.Parent = null;
                    tabPageTTSinhVien.Parent = null;
                    tabPageDonVi.Parent = null;
                    tabPageNhanSu.Parent = null;
                    tabPagePhanCong.Parent = null;
                    break;
                case 2: // NVCB
                    tabPageTTSinhVien.Parent = null;
                    tabPagePhanCong.Parent = null;
                    tabPageNhanSu.Parent = null;
                    tabPageDangKy.Parent = null;

                    loadTTCN();
                    break;
                case 3: // GIAOVU
                    tabPageTTSinhVien.Parent = null;
                    tabPageNhanSu.Parent = null;

                    loadTTCN();
                    break;
                case 4: // GV
                    tabPageTTSinhVien.Parent = null;
                    tabPageNhanSu.Parent = null;

                    loadTTCN();
                    break;
                case 5: // TRGDV
                    tabPageTTSinhVien.Parent = null;
                    tabPageNhanSu.Parent = null;
                    break;
                case 6: // TRGKHOA
                    tabPageTTSinhVien.Parent = null;
                    break;
            }
        }


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

        private void btnUpdateTTCN_Click(object sender, EventArgs e)
        {
            btnAcceptTTCN.Visible = true;
            btnCancelTTCN.Visible = true;
            btnUpdateTTCN.Visible = false;
            txtBoxTTCNSDT.Enabled = true;
        }

        private void btnCancelTTCN_Click(object sender, EventArgs e)
        {
            btnAcceptTTCN.Visible = false;
            btnCancelTTCN.Visible = false;
            btnUpdateTTCN.Visible = true;
            txtBoxTTCNSDT.Enabled = false;
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
            }
        }
    }
}
