using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class new_cpy_create : Form
    {
        public new_cpy_create()
        {
            InitializeComponent();
        }

        private static string[] cpy_all_info = new string[9];

        private static bool check = true;
        private void save_new_cpy_Click(object sender, EventArgs e)
        {
            cpy_try_panel.Visible = true;

            //코드 거래처명 대표자명 전화번호 업종 담당자명




        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {

            cpy_all_info[0] = "";
            cpy_all_info[1] = "";
            cpy_all_info[2] = "";
            cpy_all_info[3] = "";
            cpy_all_info[4] = "";
            cpy_all_info[5] = "";
            cpy_all_info[6] = "";
            cpy_all_info[7] = "";
            cpy_all_info[8] = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cpy_try_panel.Visible= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cpy_all_info[0] = cpy_code.Text;
            cpy_all_info[1] = cpy_name.Text;
            cpy_all_info[2] = cpy_leader_name.Text;
            cpy_all_info[3] = cpy_leader_phone.Text;
            cpy_all_info[4] = cpy_type.Text;
            cpy_all_info[5] = cpy_manager_name.Text;
            cpy_all_info[6] = cpy_adress.Text;
            cpy_all_info[7] = cpy_manager_phone.Text;
            cpy_all_info[8] = cpy_manager_email.Text;


            string line = "";
            foreach(var info in cpy_all_info)
            {
                line += info + "\t";
            }

            StreamWriter sw = File.AppendText(@"C:\\Erp_main\\Cpy_info\\거래처목록.txt");

            sw.WriteLine(line);
            sw.Close();
            sw.Dispose();



            cpy_try_panel.Visible = false;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
