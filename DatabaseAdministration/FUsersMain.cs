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
        public FUsersMain(int role)
        {
            InitializeComponent();
            this.label1.Text = role.ToString();
        }
    }
}
