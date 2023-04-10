using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace WindowsFormsApp2
{
    public partial class request_Form : Form //일반 신청서
    {
        private List<string> data_list = new List<string>();
        private List<string> pay_list = new List<string>();
        private List<string> depart_list = new List<string>();
        private List<string> business_list = new List<string>();
        private List<string> retire_list = new List<string>();
        private List<string> vacation_list = new List<string>();

        private string person_number;
        private string request_date;
        private string count_people;
        

        public List<string> people_number_list = new List<string>();             // 사원번호 담을 리스트
        public string applicant;                                            // 신청자 이름 담을 문자
        public request_Form(string kind, string number,string date)
        {
            InitializeComponent();

            request_Form_Init(kind, number,date);

            chamjo_search_Gridview.RowHeadersVisible = false;
        }

        private void request_panel_off()
        {

            vacation_panel.Visible = false;
            pay_panel.Visible = false;
            department_panel.Visible = false;
            business_panel.Visible = false;
            retire_panel.Visible = false;
            chamjo_panel.Visible = false;
            sign_panel.Visible = false;


        }


        private void request_Form_Init(string kind,string number,string date) //종류,사번,신청일
        {


            List<string> lines = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재상태.txt");


            person_number = number;
            request_date = date;

            if (kind == "휴가")                                // 휴가 판넬
            {
                request_panel_off();
                vacation_panel.Visible = true;
                vacation_panel.Location = new Point(12, 11);

                request_name_label.Text = ""; //신청인

                //휴가	상태	이름	사번	신청일	휴가출발기간		휴가도착기간		유형	사유
                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if(arr[0]=="휴가")
                    {
                        if(arr[3]==number && arr[4]==date)
                        {
                            string name = "";
                            for(int i = 0; i <arr[2].Length;i++)
                            {
                                name += arr[2][i] + " ";
                            }
                            request_name_label.Text = name.TrimEnd();
                            //"yyyy-MM-DD"
                            Date_label.Text = arr[4].Split('-')[0]+ "년 "+ arr[4].Split('-')[1]+ "월 "+ arr[4].Split('-')[2]+ "일"; //신청일
                            vacation_how_date_label.Text = arr[5]; //출발
                            vacation_how_date_label2.Text = arr[6]; //도착
                            request_name2_label.Text = arr[2]; //신청자이름
                            vacation_person_number_label.Text = arr[3];
                            reason_label.Text = arr[8];

                            break;
                        }
                    }
                }
            }
            else if (kind == "퇴사")                                // 퇴사 판넬
            {
                request_panel_off();
                retire_panel.Visible = true;
                retire_panel.Location = new Point(12, 11);

                retire_name2_label.Text = "";


                foreach(var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if (arr[0] == "퇴사")
                    {
                        if (arr[3] == number && arr[4] == date)
                        {

                            string name = "";
                            for (int i = 0; i < arr[2].Length; i++)
                            {
                                name += arr[2][i] + " ";
                            }
                            retire_name2_label.Text = name.TrimEnd();
                            retire_name_label.Text = arr[2];
                            retire_date_label.Text = arr[4].Split('-')[0] + "년 " + arr[4].Split('-')[1] + "월 " + arr[4].Split('-')[2] + "일"; //신청일

                            retire_person_number_label.Text = arr[3];
                            retire_dp_label.Text = arr[5];
                            retire_position_label.Text = arr[6];
                            retire_how_date_label.Text = arr[7];

                            retire_reason_label.Text = arr[8];

                            break;
                        }
                    }
                }

            }
            else if (kind == "출장")                                    // 출장 판넬
            {




                request_panel_off();
                business_panel.Visible = true;
                business_panel.Location = new Point(12, 11);

                business_name2_label.Text = "";
                damdang_name_label.Text = "";
                foreach(var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if(arr[0]=="출장")
                    {
                        if (arr[3] == number && arr[4] == date)
                        {

                            string name = "";
                            for (int i = 0; i < arr[2].Length; i++)
                            {
                                name += arr[2][i] + " ";
                            }
                            business_name_label.Text = name.TrimEnd();
                            business_name2_label.Text = name.TrimEnd();

                            string name2 = "";
                            for (int i = 0; i < arr[7].Length; i++)
                            {
                                name2 += arr[7][i] + " ";
                            }
                            damdang_name_label.Text = name2.TrimEnd();
                            damdang_number_label.Text = arr[11];
                            buisness_date_label.Text = arr[4].Split('-')[0] + "년 " + arr[4].Split('-')[1] + "월 " + arr[4].Split('-')[2] + "일"; //신청일
                            business_start_label.Text = arr[8].Split('-')[0] + "년 " + arr[8].Split('-')[1] + "월 " + arr[8].Split('-')[2] + "일"; //출장시작
                            business_end_label.Text = arr[9].Split('-')[0] + "년 " + arr[9].Split('-')[1] + "월 " + arr[9].Split('-')[2] + "일"; //도착날짜
                            business_person_number_label.Text = arr[3];
                            business_area_label.Text = arr[5];
                            business_company_label.Text = arr[6];
                            business_reason_label.Text = arr[10];


                            break;

                        }
                    }


                }


            }
            else if (kind == "부서")                          // 부서 판넬
            {

                request_panel_off();
                department_panel.Visible = true;
                department_panel.Location = new Point(12, 11);

                depart_name2_label.Text = "";

                int people_count = 0;
                foreach(var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if (arr[0] == "부서")
                    {
                        if (arr[3] == number && arr[4] == date)
                        {
                            string name = "";
                            for (int i = 0; i < arr[2].Length; i++)
                            {
                                name += arr[2][i] + " ";
                            }
                            depart_name2_label.Text = name.TrimEnd();
                            
                            for (int i =6; i <arr.Length;i++)
                            {
                                people_count += 1;
                            }

                            depart_date_label.Text = arr[4].Split('-')[0] + "년 " + arr[4].Split('-')[1] + "월 " + arr[4].Split('-')[2] + "일"; //신청일


                            depart_name_label.Text = arr[2]+" " + "외" + " " + Convert.ToString(people_count) + "명";
                            depart_person_number_label.Text = arr[2];
                            depart_depart_label.Text = arr[5];
                        }
                    }
                }
            }
            else if (kind == "급여")                                   // 급여 판넬
            {

                request_panel_off();
                
                pay_panel.Visible = true;
                pay_panel.Location = new Point(12, 11);
                pay_name2_label.Text = "";
                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');


                    if (arr[0] == "급여")
                    {
                        if (arr[3] == number && arr[4] == date)
                        {
                            string name = "";
                            for (int i = 0; i < arr[2].Length; i++)
                            {
                                name += arr[2][i] + " ";
                            }

                            pay_name2_label.Text = name.TrimEnd();


                            pay_date_label.Text = arr[4].Split('-')[0] + "년 " + arr[4].Split('-')[1] + "월 " + arr[4].Split('-')[2] + "일"; //신청일
                            pay_name_label.Text= arr[2] + "등" + " " + arr[5];
                            string p = arr[6].Substring(0, arr[6].Length - 1);
                            pay_how_many_label.Text = String.Format("{0:#,0}", Convert.ToInt32(p)) + "원";

                        }
                    }
                }
            }
        }

        private void business_cancel_btn_Click(object sender, EventArgs e)       // 출장 취소 버튼
        {
            this.Close();
        }

        private void business_ok_btn_Click(object sender, EventArgs e)          // 츨장 승인 버튼
        {
            chamjo_panel.Visible = true;
            chamjo_text.Focus();
            chamjo_panel.BringToFront();
            chamjo_search_Gridview.Rows.Clear();
            
            List<string> list = new List<string>();
            Person_info pi = new Person_info();
            list = pi.search_em();
            foreach(var li in list)
            {
                string[] em = li.Split('\t');
                chamjo_search_Gridview.Rows.Add(false, em[3].ToString(), em[1].ToString(), em[0].ToString());

            }
        }


        private void chamjo_ok_btn_Click(object sender, EventArgs e)          // 참조 승인 버튼
        {
            try
            {
                people_number_list.Clear();
                var row = chamjo_search_Gridview.Rows;
                List<string> list = new List<string>();
                string m;

                if (chamjo_search_Gridview.Rows.Count > 0)
                {
                    for (int i = 0; i < row.Count; i++)
                    {
                        if (row[i].Cells[0].Value.ToString() == "True")
                        {
                            list.Add(row[i].Cells[3].Value.ToString());

                            people_number_list.Add(row[i].Cells[2].Value.ToString());             // 기본적인 사원번호 담은 리스트
                        }
                    }
                }
                m = list[0].ToString();
                int mm = list.Count - 1;
                count_people = m + " 외 " + Convert.ToInt32(mm) + "명";

                chamjo_panel.Visible = false;
                sign_panel.Visible = true;
                sign_panel.BringToFront();
                name_sign_textbox.Focus();
                timer1.Start();
            }
            catch
            {
                MessageBox.Show("1명 이상 선택해주세요","경고",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private void chamjo_cancel_btn_Click(object sender, EventArgs e)        // 참조 취소 버튼
        {
            chamjo_panel.Visible = false;
        }
        private void chamjo_search_btn_Click(object sender, EventArgs e)               // 참조 버튼 눌렀을 시
        {
            UserCheck uc = new UserCheck();
            data_list = uc.search_user(@"C:\\Erp_main\\Em_info\\Em_all_info.txt");

            chamjo_search_Gridview.Rows.Clear();

            foreach ( string data in data_list )
            {
                if (chamjo_text.Text != null)
                {
                    if (data.Contains(chamjo_text.Text))
                    {
                        chamjo_search_Gridview.Rows.Add(false, data.Split('\t')[3].ToString(), data.Split('\t')[1].ToString(), data.Split('\t')[0].ToString());
                    }
                }
            }
        }
        private int cnt = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            cnt += 1;
            if (cnt > 5)
            {
                timer1.Stop();
                if (name_sign_textbox.Text.Length >= 1)
                {
                    cnt = 0;
                    check_title(person_number, request_date);
                    name_sign_textbox.Text = "";
                    sign_panel.Visible = false;
                    this.Close();
                }
                else
                {
                    cnt = 0;
                    name_sign_textbox.Text = "";
                    sign_panel.Visible = false;
                }
            }
        }




        private void team_leader_check(string tema,string number, string date)
        {
            List<string> lines = new List<string>();
            DateTime now = DateTime.Now;
            List<string> del_line = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재상태.txt");
            string full_line = "";
            foreach (var line in lines)
            {
                string[] arr = line.Split('\t');
                try
                {
                    if (arr[0] == tema)
                    {
                        if (arr[3] == number && arr[4] == date)
                        {
                            
                            del_line = arr.ToList();
                            lines.Remove(line);
                            break;
                        }
                    }
                }
                catch
                {

                }
                
            }
            
            del_line[1] = "팀장승인완료";

            foreach (var full in del_line)
            {
                full_line += full + "\t";

            }

            lines.Add(full_line);


            StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Approval_info\\결재상태.txt");

            foreach (var line in lines)
            {
                sw.WriteLine(line);
            }
            sw.Close();
            sw.Dispose();

            string numbers = tema+"\t팀장승인\t" + number + "\t" + date + "\t" + now.ToString("yyyy-MM-dd")+"\t";
            foreach (var people in people_number_list)
            {
                numbers += people + "\t";
            }



            StreamWriter ssw = File.AppendText(@"C:\\Erp_main\\Approval_info\\결재참조.txt");
            ssw.WriteLine(numbers);
            ssw.Close();
            ssw.Dispose();




        }



        private void check_title(string number, string date)
        {
            UserCheck ud = new UserCheck();

            //request_form
  

            DateTime now = DateTime.Now;
            
            if(business_panel.Visible == true)
            {
                team_leader_check("출장", number, date);
            }
            else if(retire_panel.Visible == true)
            {
                team_leader_check("퇴사", number, date);

            }
            else if(vacation_panel.Visible == true)
            {
                team_leader_check("휴가", number, date);
            }
            else if(pay_panel.Visible == true)
            {
                team_leader_check("급여", number, date);
            }
            else if(department_panel.Visible == true)
            {
                team_leader_check("부서변경", number, date);
            }


            //------------------------------------------------------------------------------------------------------------------


            //372번줄 check_title =>
            //조건문 마다
            //string line = "";
            //StreamWriter sw2 = File.AppendText(@"C:\\Erp_main\\Py_info\\all_py.txt");

            //sw2.WriteLine(full_line);

            //sw2.Close();
            //sw2.Dispose();



            if (business_panel.Visible == true)                // 출장신청
            {
                DateTime dateTime = DateTime.Now;

                string full_line = "안읽음\t[출장]출장 신청입니다.\t담당자\t" + count_people + "\t" + dateTime.ToString("yyyy/MM/dd") + "\t대기중\t"+business_name_label.Text+","+business_person_number_label.Text+"\t";

                StreamWriter sw2 = File.AppendText(@"C:\\Erp_main\\Py_info\\all_py.txt");
                sw2.WriteLine(full_line);

                sw2.Close();
                sw2.Dispose();






            }
            else if(retire_panel.Visible == true)                   // 퇴사 신청
            {
                
                string line = "";
                DateTime dateTime = DateTime.Now;


                string full_line = "안읽음\t[퇴사]퇴사 신청입니다.\t담당자\t" + count_people + "\t" + dateTime.ToString("yyyy/MM/dd") + "\t대기중\t"+retire_name_label.Text+","+retire_person_number_label.Text+"\t";

                StreamWriter sw2 = File.AppendText(@"C:\\Erp_main\\Py_info\\all_py.txt");

                sw2.WriteLine(full_line);

                sw2.Close();
                sw2.Dispose();







            }
            else if(vacation_panel.Visible == true)             // 휴가 신청
            {

                DateTime dateTime = DateTime.Now;
                string full_line = "안읽음\t[휴가]휴가 신청입니다.\t담당자\t" + count_people + "\t" + dateTime.ToString("yyyy/MM/dd") + "\t대기중\t"+request_name2_label.Text+","+vacation_person_number_label.Text+"\t";

                StreamWriter sw2 = File.AppendText(@"C:\\Erp_main\\Py_info\\all_py.txt");

                sw2.WriteLine(full_line);

                sw2.Close();
                sw2.Dispose();

            }
            else if (pay_panel.Visible == true)                            // 급여
            {
                DateTime dateTime = DateTime.Now;
                string full_line = "안읽음\t[급여]급여 신청입니다.\t담당자\t" + count_people + "\t" + dateTime.ToString("yyyy/MM/dd") + "\t대기중\t"+pay_name_label.Text+","+pay_person_number_label.Text+"\t";

                StreamWriter sw2 = File.AppendText(@"C:\\Erp_main\\Py_info\\all_py.txt");

                sw2.WriteLine(full_line);

                sw2.Close();
                sw2.Dispose();





            }
            else if (department_panel.Visible == true)                                  // 부서변경
            {


                DateTime dateTime = DateTime.Now;



                string full_line = "안읽음\t[부서변경]인사이동 신청입니다.\t담당자\t" + count_people + "\t" + dateTime.ToString("yyyy/MM/dd") + "\t대기중\t"+depart_name_label.Text+","+depart_person_number_label.Text+"\t";

                StreamWriter sw2 = File.AppendText(@"C:\\Erp_main\\Py_info\\all_py.txt");

                sw2.WriteLine(full_line);

                sw2.Close();
                sw2.Dispose();

            }
        }


    }
}
