using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DatabaseAdministration
{
    public partial class EditUsernameForm : Form
    {
        public EditUsernameForm()
        {
            InitializeComponent();
        }

        // Thuộc tính để lưu trữ tên người dùng cũ
        public string Username { get; private set; }

        public EditUsernameForm(string currentUsername, string type)
        {
            InitializeComponent();

            // Gán tên người dùng hiện tại vào TextBox
            textBox1.Text = currentUsername;
            label2.Text = $"New {type}:";
            label1.Text = $"Modify {type} name";

            // Lưu trữ tên người dùng hiện tại
            Username = currentUsername;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy tên mới từ TextBox và gán nó cho thuộc tính Username
            Username = textBox1.Text;

            // Đóng form với kết quả là DialogResult.OK
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Không thay đổi tên người dùng và đóng form với kết quả là DialogResult.Cancel
            DialogResult = DialogResult.Cancel;
        }
    }
}