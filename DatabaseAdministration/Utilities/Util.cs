using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAdministration.Utilities
{
    internal class Util
    {
        // kiểm tra mảng textbox tồn tại rỗng
        public static bool hasEmptyTextBox(List<TextBox> textBoxes)
        {
            foreach (TextBox textbox in textBoxes)
            {
                if (string.IsNullOrEmpty(textbox.Text)) return true;
            }
            return false;
        }
        // kiểm tra kí tự đặc biệt
        public static bool hasSpecialCharacters(List<TextBox> textBoxes)
        {
            string pattern = @"[~`!@#$%^&*()_\-+={}[\]|\\:;""'<>,.?/]";
            Regex regex = new Regex(pattern);

            foreach (TextBox textbox in textBoxes)
            {
                if (regex.IsMatch(textbox.Text))
                {
                    return true;
                }
            }
            return false;
        }
        // hàm lưu lại giá trị textbox 
        public static List<string> savePrevTxtBox(List<TextBox> txtboxes)
        {
            List<string> res = new List<string>();
            for (int i = 0; i < txtboxes.Count; i++)
            {
                res.Add(txtboxes[i].Text);
            }
            return res;
        }
        // hàm gán giá trị vào textbox
        public static void loadTxtBoxes(List<string> s, List<TextBox> output)
        {
            for (int i = 0; i < s.Count; i++)
            {
                output[i].Text = s[i];
            }
        }
    }
}
