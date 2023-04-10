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
    public partial class em_ct_money_check : Form
    {

        private static int point = 0;
        private static string user_code;
        public em_ct_money_check(int num,string code)
        {
            InitializeComponent();
            point= num;
            user_code = code;
            gridview_full();
        }

        // 사원,사번,지급총액,국민연금,상여금,성과금,실지급액



        //StreamWriter sw = File.AppendText(@"C:\\Erp_main\\Em_info\\월급계산서.txt");

        //// 직급별
        //// 기본급 - 기본급*0.045 = 총 월급

        //sw.WriteLine();
        //sw.Close();
        //sw.Dispose();
        private void gridview_full()
        {

            em_ct_total_money_gridview.Rows.Clear();

            
            List<string> users = new List<string>();    
            List<string> moneys = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            Person_info pi = new Person_info();


            moneys = fi.txt_read(@"C:\\Erp_main\\Em_info\\기본급설정.txt"); //직급별 기본급
            users =pi.search_em();


            //이름,사번,총지급액,국민연금,실지급액
            string[] grid = new string[5];
            if (point==1)//권한있음
            {
                foreach(var user in users)
                {
                    string[] rank= user.Split('\t');
                    //rank[3]
                    foreach(var money in moneys)
                    {
                        string[] mo = money.Split('\t');

                        if (rank[3] == mo[0])
                        {
                            grid[2] = mo[1];
                        }
                    }
                    grid[0] = rank[0];
                    grid[1] = rank[1];
                    grid[3] = tax_money(grid[2]); //4.5%
                    grid[4] = real_money(grid[2]); //실지급액
                    em_ct_total_money_gridview.Rows.Add(grid);
                }

            }
            else if(point==0)//권한없음
            {

                foreach(var user in users)
                {
                    string[] rank= user.Split('\t');

                    if (rank[1]==user_code)
                    {
                        foreach (var money in moneys)
                        {
                            string[] mo = money.Split('\t');


                            if (rank[3] == mo[0])
                            {
                                grid[2] = mo[1];
                            }
                        }

                        grid[0] = rank[0];
                        grid[1] = rank[1];
                        grid[3] = tax_money(grid[2]); //4.5%
                        grid[4] = real_money(grid[2]); //실지급액
                        em_ct_total_money_gridview.Rows.Add(grid);
                    }
                }
            }
        }


        private string tax_money(string money)
        {
            int m = Convert.ToInt32(money);
            //기본급*4.5%
            double result = m * 0.045;
           
            return Math.Round(result).ToString();
        }
        private string real_money(string money)
        {

            int m = Convert.ToInt32(money);


            //기본급 - (기본급*4.5%) = 실지급액

            double result = m - (m * 0.045);


            return Math.Round(result).ToString();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void em_ct_money_try_panel_Paint(object sender, PaintEventArgs e)
        {

        }



        private int total_money_info()
        {

            var rows = em_ct_total_money_gridview.Rows;
            int result = 0;
            for(int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Cells[4].Value != null)
                {
                    Int32.TryParse(rows[i].Cells[4].Value.ToString(), out int money);
                    result += money;
                }
                
            }

            return result;
        }


        private string name_check()
        {
            string name = "";
            List<string> lines = new List<string>();

            Person_info pi = new Person_info();

            lines = pi.search_em();

            foreach(var line in lines)
            {
                string[] arr = line.Split('\t');
                if (arr[1]==user_code)
                {
                    name= arr[0];   
                    break;
                }
            }
            return name;
        }

        private void try_panel_info()
        {

            var rows = em_ct_total_money_gridview.Rows;


            DateTime now = DateTime.Now;
            today_label.Text= now.ToString("yyyy-MM-dd");
            total_money_label.Text = total_money_info().ToString() +" 원";
            total_person_label.Text = (rows.Count-1).ToString()+" 명";

            user_name_label.Text = name_check();
            user_code_label.Text = user_code;
            reson_text_box.Focus();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try_panel_info();
            em_ct_money_try_panel.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            em_ct_money_try_panel.Visible = false;
        }

        private void em_ct_money_try_O_btn_Click(object sender, EventArgs e)
        {
            //신청자,사번,신청일,총인원,총금액

            //DateTime now = DateTime.Now;
            //today_label.Text = now.ToString("yyyy-MM-dd");
            //total_money_label.Text = total_money_info().ToString() + " 원";
            //total_person_label.Text = (rows.Count - 1).ToString() + " 명";

            //user_name_label.Text = name_check();
            //user_code_label.Text = user_code;

            string[] arr =
                {
                "급여",
                "대기중",
                user_name_label.Text,
                user_code_label.Text,
                today_label.Text,
                total_person_label.Text,
                total_money_label.Text,
                };
            string line = "";
            foreach(var a in arr)
            {
                line += a + "\t";
            }
            ApprovalCheck ac = new ApprovalCheck();            
            if (ac.approval_date("급여", user_code_label.Text, today_label.Text) == false)
            {
                MessageBox.Show("당일중복신청불가");
                return;
            }

            StreamWriter sw = File.AppendText(@"C:\\Erp_main\\Approval_info\\급여신청.txt");
            sw.WriteLine(line);
            sw.Close();
            sw.Dispose();



            em_ct_money_try_success_panel.Visible = true;
        }

        private void success_ok_btn_Click(object sender, EventArgs e)
        {
            em_ct_money_try_success_panel.Visible = false;
            em_ct_money_try_panel.Visible = false;
            this.Close();
        }
    }
}
