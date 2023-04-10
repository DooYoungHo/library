using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class official_document : Form
    {
        List<string> company = new List<string>();
        List<string> em_ref = new List<string>();//수신참조 리스트

        public static string tema = "";
        public static string my_code = "";
        public static string try_info = "";
        public static int ok_count;

        public delegate void re_fresh();
        //public event re_fresh complet_fresh;
        public event re_fresh return_fresh;
        public event re_fresh ing_fresh;

        public delegate void label(string text);
        public event label complet_fresh;

        public string NN;
        public official_document()
        {
            InitializeComponent();
        }
        public official_document(string name, string subtitle, string person,string info,string code)
        {

            //--------------------------------------------------- 버튼 둥글게 깎기 EntryPoint 찾기 ------------------------------------------------
            // [DllImport("Gdi32.dll"), EntryPoint = "CreateRoundRectRgn")]
            //private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
            //cancel_btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, cancel_btn.Width, cancel_btn.Height, 15, 15));
            //lblCAM.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblCAM.Width, lblCAM.Height, 15, 15));
            //lblPOWER.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblPOWER.Width, lblPOWER.Height, 15, 15));
            //-------------------------------------------------------------------------------------------------------------------------------------

            //99번 줄 document_kind 함수

            //UserCheck uc = new UserCheck();

            tema = name;
            my_code = code;
            try_info = info;




            InitializeComponent();

            UserCheck check = new UserCheck();
            company = check.search_user(@"C:\\Erp_main\\Em_info\\company.txt");

            company_CEO.Text = "대표이사";

            company_name.Text = "";


            search_person_GridView.RowHeadersVisible = false;
            


            foreach ( string com in company )
            {
                try
                {
                    string ceo = com.Split('\t')[1];
                    string c_name = com.Split('\t')[0];

                    title.Text = com.Split('\t')[0] + " O O " + "신청서";
                    for (int i = 0; i < c_name.Length; i++)
                    {
                        company_name.Text += c_name[i] + " ";
                    }

                    for (int i = 0; i < ceo.Length; i++)
                    {
                        company_CEO.Text += " " + ceo[i];
                    }

                    address_label.Text = com.Split('\t')[2].ToString();
                    Phone_label.Text = com.Split('\t')[3].ToString();
                    Fax_label.Text = com.Split('\t')[4].ToString();
                    mail_label.Text = com.Split('\t')[5].ToString();
                }
                catch
                {

                }
                
            }
            subtitle_label.Text = subtitle.Substring(subtitle.IndexOf(']') + 1);

            recipient_label.Text = person;

            document_kind(name,info);
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void business_trip_Paint(object sender, PaintEventArgs e)
        {

        }
        public void document_kind(string kind,string info)                          // 종류에 맞는 공문서
        {
            UserCheck uc = new UserCheck();
            List<string> lines = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재상태.txt");
            company = uc.search_user(@"C:\\Erp_main\\Em_info\\company.txt");

            string sdate = info.Split(',')[0];
            string name = info.Split(',')[1];
            string code = info.Split(',')[2];
            

            if (kind == "휴가")                          // 휴가일때
            {
                vacation_reason_label.Location = new Point(330, 177);

                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');

                    if(arr[0]=="휴가" &&arr[1]=="팀장승인완료")
                    {
                        if(sdate == arr[4] && name==arr[2]&&code==arr[3])
                        {
                            vacation_name_label.Text = arr[2];
                            vacation_start_label.Text = arr[5];
                            vacation_kind_label.Text = arr[7];
                            vacation_reason_label.Text = arr[8];
                        }
                        
                    }
                }
                foreach (string comp in company)
                {
                    title.Text = comp.Split('\t')[0] + " 휴 가 " + "신청서";
                }
                    under_append_label.Text = @"1. 위와 같은 사유로 휴가 신청 합니다

2. 덧붙임.";
            }
            else if ( kind == "퇴사")                   // 퇴사일때
            {

                label21.Text = "신청 일자";
                label22.Text = "직급";
                vacation_reason_label.Location = new Point(330, 177);
                vacation_label.Text = @"위 사람은

다음과 같은 사유로 퇴사/사직 신청합니다";



                foreach(var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if (arr[0] == "퇴사" && arr[1] == "팀장승인완료")
                    {
                        if (sdate == arr[4] && name == arr[2] && code == arr[3])
                        {
                            vacation_name_label.Text = arr[2];
                            vacation_start_label.Text = arr[4];
                            vacation_kind_label.Text = arr[5];
                            vacation_reason_label.Text = arr[8];
                        }
                    }


                }

                foreach (string comp in company)
                {
                    title.Text = comp.Split('\t')[0] + " 퇴 사 " + "신청서";
                }
                vacation_kind_label.Location = new Point(255, 177);
                under_append_label.Text = @"1. 위와 같은 사유로 퇴사/사직 신청 합니다

2. 덧붙임.";
            }
            else if ( kind == "급여" )
            {
                vacation_label.Text = @"위 사람은

다음과 같은 사유로 급여 신청합니다";

                label21.Text = "금 액";
                label21.Location = new Point(165,115);
                vacation_kind_label.Location = new Point(260, 177);
                vacation_reason_label.Location = new Point(330, 177);


                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if (arr[0] == "급여" && arr[1] == "팀장승인완료")
                    {
                        if (sdate == arr[4] && name == arr[2] && code == arr[3])
                        {
                            string[] str = arr[6].ToString().Split(' ');
                            string total = String.Format("{0:#,0}", Convert.ToInt32(str[0]));

                            DateTime.TryParse(arr[4], out DateTime month);


                            label12.Text = "등 " + arr[5];
                            vacation_name_label.Text = arr[2];
                            vacation_start_label.Text = total + "원";
                            vacation_kind_label.Text = "급여";
                            vacation_reason_label.Text = month.Month + "월 급여";
                        }
                    }
                }
                foreach (string comp in company)
                {
                    title.Text = comp.Split('\t')[0] + " 급 여 " + "신청서";
                }
                under_append_label.Text = @"1. 위와 같은 사유로 급여 신청 합니다

2. 덧붙임.";
            }
            else if ( kind == "출장" )
            {
                vacation_label.Text = @"위 사람은

다음과 같은 사유로 출장 신청합니다";

                vacation_kind_label.Location = new Point(260, 177);
                


                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if (arr[0] == "퇴사" && arr[1] == "팀장승인완료")
                    {
                        if (sdate == arr[4] && name == arr[2] && code == arr[3])
                        {
                            vacation_name_label.Text = arr[2];
                            vacation_start_label.Text = arr[8];
                            vacation_kind_label.Text = arr[6];
                            vacation_reason_label.Text = arr[10];
                            
                        }
                    }
                }


                label22.Text = "회사명";



                foreach (string comp in company)
                {
                    title.Text = comp.Split('\t')[0] + " 출 장 " + "신청서";
                }
                under_append_label.Text = @"1. 위와 같은 사유로 출장 신청 합니다

2. 덧붙임.";
            }
            else if ( kind == "부서")
            {
                vacation_label.Text = @"위 사람은

다음과 같은 사유로 부서 변경을 신청합니다";
                label21.Text = "변경 날짜";
                label22.Text = "변경 부서";
                label22.Location = new Point(245, 115);
                vacation_kind_label.Location = new Point(250,177);
                vacation_reason_label.Location = new Point(330, 177);


                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if (arr[0].Contains("부서")  && arr[1] == "팀장승인완료")
                    {
                        if (sdate == arr[4] && name == arr[2] && code == arr[3])
                        {
                            vacation_name_label.Text = arr[2];
                            vacation_start_label.Text = arr[4];
                            vacation_kind_label.Text = arr[5];
                            vacation_reason_label.Text = "인사이동";

                        }
                    }
                }

                foreach (string comp in company)
                {
                    title.Text = comp.Split('\t')[0] + " 인사이동 " + "신청서";
                }
            }
        }
        private void cancel_btn_Click(object sender, EventArgs e)               // 취소 버튼
        {
            if (MessageBox.Show("정말 취소하시겠습니까?", "안내", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.OpenForms["official_document"].Close();
            }
        }

        private void conclude_btn_Click(object sender, EventArgs e)                 // 완료 버튼
        {

            //사장 외에 사원들은승인불가

            if(Power_cfn()==false)
            {
                MessageBox.Show("권한이 없습니다.");
                return;
            }


            if (MessageBox.Show("완료 하시겠습니까?", "안내", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

                complet_fresh(recipient_label.Text);


                string sdate = try_info.Split(',')[0];
                string name = try_info.Split(',')[1];
                string code = try_info.Split(',')[2];

                List<string> lines = new List<string>();
                List<string> ref_lines = new List<string>();

                Fill_of_text_Box fi = new Fill_of_text_Box();
                lines = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재상태.txt");
                ref_lines = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재참조.txt");
                List<string> del_line = new List<string>();
                string full_line = "";
                foreach(var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if (arr[0] == tema)
                    {
                        if(arr[2]==name &&arr[3]==code&&arr[4]==sdate)
                        {
                            del_line = arr.ToList();
                            lines.Remove(line);
                            break;
                        }
                    }
                }
                del_line[1] = "대표승인완료";
                foreach(var full in del_line)
                {
                    full_line += full + "\t";
                }
                lines.Add(full_line);

                StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Approval_info\\결재상태.txt");

                foreach(var line in lines)
                {
                    sw.WriteLine(line);
                }
                sw.Close();
                sw.Dispose();


                List<string> del_line2 = new List<string>();
                foreach (var line in ref_lines)
                {
                    string[] arr = line.Split('\t');
                    if (arr[0] == tema)
                    {
                        if (arr[2] == code && arr[3] == sdate)
                        {
                
                            ref_lines.Remove(line);
                            break;
                        }
                    }
                }


                DateTime now = DateTime.Now;


                string full_line2 = tema + "\t대표승인완료\t" + code + "\t" + now.ToString("yyyy-MM-dd") + "\t";

                foreach(var line in em_ref)
                {
                    full_line2 += line + "\t";
                }


                ref_lines.Add(full_line2);

                StreamWriter ssw = new StreamWriter(@"C:\\Erp_main\\Approval_info\\결재참조.txt");

                foreach(var line in ref_lines)
                {
                    ssw.WriteLine(line);
                }
                ssw.Close();
                ssw.Dispose();




                approval_result(tema);






                Application.OpenForms["official_document"].Close();

            }
        }
        private void return_btn_Click(object sender, EventArgs e)                  // 반려 버튼
        {
            if (Power_cfn() == false)
            {
                MessageBox.Show("권한이 없습니다.");
                return;
            }

            if (MessageBox.Show("반려 하시겠습니까?", "안내", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.OpenForms["official_document"].Close();

                return_fresh();
            }
        }
        private void transient_storage_btn_Click(object sender, EventArgs e)               // 대기중 버튼
        {
            if (Power_cfn() == false)
            {
                MessageBox.Show("권한이 없습니다.");
                return;
            }
            if (MessageBox.Show("임시저장 하시겠습니까?", "안내", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.OpenForms["official_document"].Close();

                ing_fresh();
            }
        }
        private void reference_btn_Click(object sender, EventArgs e)                 // 수신 참조 버튼
        {
            if (Power_cfn() == false)
            {
                MessageBox.Show("권한이 없습니다.");
                return;
            }
            search_person_panel.Visible = true;
            search_person_panel.Location = new Point(66, 64);
            search_text.Focus();
        }
        private void search_text_KeyDown(object sender, KeyEventArgs e)                 // 수신참조 텍스트박스
        {
            if (e.KeyCode == Keys.Enter)
            {
                
            }
        }
        private void search_person_btn_Click(object sender, EventArgs e)               // 수신참조 검색 버튼 클릭시
        {
            UserCheck uc = new UserCheck();

            company = uc.search_user(@"C:\\Erp_main\\Em_info\\Em_all_info.txt");

            search_person_GridView.Rows.Clear();

            foreach ( string item in company )
            {
                string[] arr = item.Split('\t');
                if (search_text.Text == "")
                {
                    search_person_GridView.Rows.Add(false, item.Split('\t')[3], item.Split('\t')[1], item.Split('\t')[0]);
                }
                else if (item.Split('\t')[0].ToString().Contains(search_text.Text))
                {
                    search_person_GridView.Rows.Add(false, item.Split('\t')[3], item.Split('\t')[1], item.Split('\t')[0]);
                }
            }
            search_person_GridView.RowHeadersVisible = false;
        }
        private void search_cancel_btn_Click(object sender, EventArgs e)                // 수신참조 검색 취소 버튼 클릭시
        {
            search_person_panel.Visible = false;
        }
        private void search_save_btn_Click(object sender, EventArgs e)                    // 수신참조 저장 버튼 클릭시
        {
            var row = search_person_GridView.Rows;
            List<string> list = new List<string>();

            string k;
            if (search_person_GridView.Rows.Count > 0)
            {
                for(int i = 0; i<row.Count;i++)
                {
                    if (row[i].Cells[0].Value.ToString() == "True")
                    {
                        list.Add(row[i].Cells[1].Value.ToString());
                        em_ref.Add(row[i].Cells[2].Value.ToString());
                    }
                }
            }
            k = list[0].ToString();
            int kk = list.Count - 1;
            recipient_label.Text = k + " " + "외" + " " + Convert.ToString(kk) + "명";
            search_person_panel.Visible = false;
            NN = recipient_label.Text;

            string full_line = "";
            foreach(var i in list)
            {
                full_line += i + "\t";
            }

            


        }


        private bool Power_cfn()
        {
            List<string> lines = new List<string>();
            Person_info pi = new Person_info();
            lines = pi.search_em();


            foreach(var line in lines)
            {
                string[] arr = line.Split('\t');
                if(arr[3]=="대표"||arr[3]=="사장")
                {
                    return true;
                }
            }
            return false;
        }



        private void approval_result(string tema)
        {
            List<string> lines = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재상태.txt");
            string sdate = try_info.Split(',')[0];
            string name = try_info.Split(',')[1];
            string code = try_info.Split(',')[2];
            List<string> line_check = new List<string>();

            foreach(var line in lines)
            {
                string[] arr = line.Split('\t');

                if(arr[0]==tema)
                {
                    if (arr[2] == name && arr[3] == code && arr[4] == sdate)
                    {
                        line_check = arr.ToList();
                        break;
                    }
                }
            }


            if (tema.Contains("휴가"))
            {
                vacation_funtion(line_check);
            }
            else if(tema.Contains("출장"))
            {
                business_trip_funtion(line_check);
            }
            else if(tema.Contains("급여"))
            {
                ct_money_funtion(line_check);
            }
            else if(tema.Contains("퇴사"))
            {
                del_em_funtion(try_info.Split(',')[2]);
            }
            else if(tema.Contains("부서"))
            {


                for(int i = 6; i<line_check.Count;i++)
                {
                    dp_change_funtion(line_check[i],line_check[5]);
                }
                
            }





        }









        private void vacation_Paint(object sender, PaintEventArgs e)
        {

        }



        private void del_txtfile(string path, string code)
        {
            Fill_of_text_Box fi = new Fill_of_text_Box();
            List<string> lines = new List<string>();
            lines = fi.txt_read(path);
            int cnt = lines.Count;

            while (cnt > 0)
            {
                foreach (var line in lines)
                {
                    if (line.Contains(code))
                    {
                        lines.Remove(line);
                        break;
                    }
                    else
                    {
                        cnt -= 1;
                    }
                }
            }


            StreamWriter sw = new StreamWriter(path);

            foreach (var i in lines)
            {
                sw.WriteLine(i);
            }
            sw.Close();
            sw.Dispose();
        }
        private void del_em_funtion(string code) //퇴사기능
        {
            //DataGridViewRow row = em_del_dataGridView2.SelectedRows[0];
            //string code = row.Cells[1].Value.ToString(); //사번 추출
            
            //기본 저장정보
            del_txtfile(@"C:\\Erp_main\\Em_info\\Em_id_pw.txt", code);
            del_txtfile(@"C:\\Erp_main\\Em_info\\Em_all_info.txt", code);
            del_txtfile(@"C:\\Erp_main\\Em_info\\출퇴근기록.txt", code);
            del_txtfile(@"C:\\Erp_main\\Em_info\\출장내역.txt", code);
            del_txtfile(@"C:\\Erp_main\\Em_info\\휴가내역.txt", code);
            del_txtfile(@"C:\\Erp_main\\Em_info\\권한설정.txt", code);

            //결재신청


            DirectoryInfo di = new DirectoryInfo(@"C:\\Erp_main\\Em_info\\" + code);
            di.Delete(true);   // true 넣으면 파일 존재시에도 무조건 삭제
        }
        private void dp_change_funtion(string code,string change_dp) //부서변경
        {
            

            Fill_of_text_Box fi = new Fill_of_text_Box();
            List<string> idpw = new List<string>();
            List<string> eminfo = new List<string>();
            idpw = fi.txt_read(@"C:\\Erp_main\\Em_info\\Em_id_pw.txt");
            eminfo = fi.txt_read(@"C:\\Erp_main\\Em_info\\Em_all_info.txt");


            string[] newid = new string[5];
            string[] neweminfo = new string[15];

            
            foreach (var id in idpw)
            {
                string[] ids = id.Split('\t');
                if (ids[3] == code)
                {
                    idpw.Remove(id);
                    newid = ids;
                    break;
                }
            }
            newid[2] = change_dp;
            string str = "";
            foreach (var i in newid)
            {
                str += i + '\t';
            }
            idpw.Add(str);
            StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Em_info\\Em_id_pw.txt");

            foreach (var i in idpw)
            {
                sw.WriteLine(i);
            }
            sw.Close();
            sw.Dispose();


            foreach (var i in eminfo)
            {
                string[] brr = i.Split('\t');

                if (brr[1] == code)
                {
                    eminfo.Remove(i);
                    neweminfo = brr;
                    break;

                }
            }
            neweminfo[2] = change_dp;
            string change_eminfo = "";
            foreach (var i in neweminfo)
            {
                change_eminfo += i + "\t";

            }

            eminfo.Add(change_eminfo);


            StreamWriter ssw = new StreamWriter(@"C:\\Erp_main\\Em_info\\Em_all_info.txt");

            foreach (var info in eminfo)
            {
                ssw.WriteLine(info);
            }
            ssw.Close();
            ssw.Dispose();
        }

        private void vacation_funtion(List<string> list) //휴가기록
        {
            //이름    사번  기간  기간  종류  사유
            string[] arr = new string[6];
            string line = "";
            arr[0] = list[2].ToString();
            arr[1] = list[3].ToString();
            arr[2] = list[5].ToString();
            arr[3] = list[6].ToString();
            arr[4] = list[7].ToString();
            arr[5] = list[8].ToString();

            for(int i = 0; i<arr.Length;i++)
            {
                line += arr[i] + "\t";


            }

            StreamWriter sw = File.AppendText(@"C:\\Erp_main\\Em_info\\휴가내역.txt");
            sw.WriteLine(line);
            sw.Close();
            sw.Dispose();
        }
        private void business_trip_funtion(List<string> list) //출장기록
        {
            //이름    사번  지역  회사  담당자 출발날짜    도착날짜    사유
            string[] arr = new string[8];
            string line = "";
            arr[0] = list[2].ToString();
            arr[1] = list[3].ToString();
            arr[2] = list[5].ToString();
            arr[3] = list[6].ToString();
            arr[4] = list[7].ToString();
            arr[5] = list[8].ToString();
            arr[6] = list[9].ToString();
            arr[7] = list[10].ToString();

            for(int i=0; i< arr.Length;i++)
            {
                line += arr[i] + "\t";
            }

            StreamWriter sw = File.AppendText(@"C:\\Erp_main\\Em_info\\출장내역.txt");
            sw.WriteLine(line);
            sw.Close();
            sw.Dispose();


        }

        private void ct_money_funtion(List<string> list)
        {
            string now = DateTime.Now.ToString("yyyy-MM-dd");
            string money = list[6];
            
            string line = now+"\t0\t0\t\t"+money+"\t\t";
            StreamWriter sw = File.AppendText(@"C:\\Erp_main\\Ac_info\\급여내역.txt");
            sw.WriteLine(line);
            sw.Close();
            sw.Dispose();



        }

        // string e_end =
        // 단가합계             단가합계            
        //날짜 영업수익    매출원가 매출총이익   판매관리비 영업이익    당기순이익	
        //2022-11-10	7,513,168	2,418,000		700,000		
        //2022-11-19	2,513,168	418,000		100,000		
        //2022-12-01	1,500,000	500,000		100,000		
        //2022-12-03	1,000,000	300,000		200,000		
        //2022-12-05	2,671,000	573,000		0	
        //2022-12-07	900,000	124,790		285,000		
        //2022-12-10	3,990,000	207,000		100,000		
        //2022-12-16	4,441,444	141,123		248,093			












    }
}
