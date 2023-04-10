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
    public partial class Business_trip : Form
    {



        
        public Business_trip(string name, string code)
        {
            InitializeComponent();
            today_tb.Text = DateTime.Now.ToString();


            name_tb.Text = name;
            code_tb.Text = code;    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private bool trip_dateCheck()
        {


            DateTime.TryParse(before_date_label.Text, out DateTime before);
            DateTime.TryParse(after_date_label.Text, out DateTime after);


            List<string> lines = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재상태.txt");


            foreach (var line in lines)
            {



                string[] arr = line.Split('\t');


                if (arr[0] == "출장")
                {
                    if (arr[3] == code_tb.Text)
                    {
                        DateTime.TryParse(arr[8], out DateTime be);
                        DateTime.TryParse(arr[9], out DateTime af);

                        if (before <= be || after <= af)
                        {
                            MessageBox.Show("신청내역내 해당 기간이 포함되어있습니다");
                            return false;
                        }
                    }

                }

            }

            return true;

        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (trip_dateCheck() == false)
            {
                return;
            }
            string textValue="";
            if (text_Check(before_date_label.Text, after_date_label.Text) == false) //양식확인
            {
                return;
            }

            string[] arr =
            {
                "출장",
                "대기중",
                name_tb.Text, //0
                code_tb.Text, //1 
                today_tb.Text, //2
                trip_space.Text, //3
                trip_name.Text, //4 
                manager_name.Text, //5
                before_date_label.Text, //6
                after_date_label.Text, //7
                trip_reason.Text, //8
                manager_p_num.Text, //9
                manager_e_mail.Text, //10

            };
            foreach(var a in arr)
            {
                textValue += a + "\t";
            }

            ApprovalCheck ac = new ApprovalCheck();

            if (ac.approval_date("출장신청.txt", code_tb.Text,today_tb.Text) == false)
            {
                MessageBox.Show("당일중복신청불가");
                return;
            }

            //이름,사번,출장지,회사명,담당자명,출발날짜,도착날짜,사유,담당자 폰번호,담당자 이메일

            StreamWriter sw = File.AppendText(@"C:\\Erp_main\\Approval_info\\출장신청.txt");
            sw.WriteLine(textValue.Substring(0,textValue.Length-1));
            sw.Close();
            sw.Dispose();


            ok_panel.Visible = true;
           
        }

        private void today_tb_TextChanged(object sender, EventArgs e)
        {
            today_tb.Text = DateTime.Now.ToString();
        }






        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            ok_panel.Visible = false;
        }





        private bool text_Check(string sd, string ed)
        {
            



            StreamReader sr = new StreamReader(@"C:\\Erp_main\\Em_info\\Em_all_info.txt");
            string line;

            while((line = sr.ReadLine())!=null)
            {
                string[] arr = line.Split('\t');
                if(line.Contains(code_tb.Text))
                {
                    if(arr[1] == code_tb.Text)
                    {
                        //사번일치
                        if (arr[0] == name_tb.Text)
                        {
                            //이름일치

                            if(DateTime.TryParse(sd, out DateTime ss) && DateTime.TryParse(ed, out DateTime ee)) //유효한 날짜 형식
                            {
                                if(ss<ee) //유효한 날짜 기간
                                {
                                    Phone_number_check pc = new Phone_number_check();
                                    if(pc.p_number_trust_check(manager_p_num.Text)) //전화번호 양식확인
                                    {

                                        check_label.Visible = false;
                                        return true;

                                    }
                                }
                            }
                        }
                    }
                }
            }
            check_label.ForeColor = Color.Red;
            check_label.Text = "양식 재 확인";
            check_label.Visible = true;
            return false;





        }
        private bool check1 = true;
        private bool check2 = true;
        private void beforedate_btn_Click(object sender, EventArgs e)
        {
            if(check1)
            {
                before_calendar.Visible = true;
                check1= false;
            }
            else
            {
                before_calendar.Visible = false;
                check1 = true;
            }

        }

        private void after_date_btn_Click(object sender, EventArgs e)
        {
            if (check2)
            {
                after_calendar.Visible = true;
                check2 = false;
            }
            else
            {
                after_calendar.Visible = false;
                check2 = true;
            }
        }

        private void before_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            before_date_label.Text = before_calendar.SelectionStart.ToString("yyyy-MM-dd"); 
        }

        private void after_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            after_date_label.Text = after_calendar.SelectionStart.ToString("yyyy-MM-dd");
        }
    }

    class Phone_number_check
    {
        public bool p_number_trust_check(string num)
        {

            int bar = 0;
            int cnt = 0;
            int trust = 0;
            bool check = false;

            if (num.Contains("010-"))
            {
                trust += 1;
            }
            else
            {
                return false;
            }
            foreach (var n in num)
            {

                if (n == '-')
                {
                    bar += 1;
                }
                if (Char.IsDigit(n))
                {
                    cnt += 1;
                }
            }
            if (bar == 2 && cnt == 11 && num.Length == 13) // - 가 2개 번호가 11개
            {
                trust += 1;
            }


            if (trust == 2)
            {
                check = true;
            }



            return check;





        }
    }

    
}
