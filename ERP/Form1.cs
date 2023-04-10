using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        
        
        public string get_id;
        public string get_pw;


        public static string user_name;
        public static string user_emcode;
        public static string user_dp;


        public string[] info = new string[3];

        private List<string> check_list = new List<string>();



        Folder_info folder_Info = new Folder_info();

        public Form1()
        {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox_id;
            folder_Info.folder_check();
            folder_Info.text_file_check();

            //pictureBox1.Load(@"C:\\Erp_main\\erp1.jpeg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }



        private void textBox_id_TextChanged(object sender, EventArgs e)
        {
            login_label_OX.Visible = false;
            if (textBox_id.Text.Length >= 1)
            {
                label_id.Visible = false;
            }
            else
            {
                label_id.Visible = true;
            }


            get_id = textBox_id.Text;
        }

        private void textBox_pw_TextChanged(object sender, EventArgs e)
        {
            login_label_OX.Visible = false;
            if (textBox_pw.Text.Length >= 1)
            {
                label_pw.Visible = false;
            }
            else
            {
                label_pw.Visible = true;
            }

            get_pw = textBox_pw.Text;
        }

        private void login_btn_Click(object sender, EventArgs e)
        {

            if (get_id == "111" && get_pw == "111") //마스터계정
            {
                UserCheck master = new UserCheck();
                master.Master_login();

                login_label_OX.Visible = true;
                login_label_OX.Text = "로그인 성공";
                user_name = "이한영";
                user_emcode = "Master_code";
                user_dp = "개발";
                loginput();
                this.Visible = false;
                Form2 f2 = new Form2();
                f2.loginform += self_call;
                f2.Show();
                return;
            }

            UserCheck uc = new UserCheck();
            check_list = uc.search_user(@"C:\\Erp_main\\Em_info\\Em_id_pw.txt");
            

            foreach(string item in check_list) //check_list는 한줄,한줄,한줄
            {
                try
                {
                    var id = item.Split('\t')[0];
                    var pw = item.Split('\t')[1];
                    
                    if (id == get_id && pw == get_pw)
                    {

                        user_name = item.Split('\t')[2].ToString();
                        user_emcode = item.Split('\t')[3].ToString();
                        user_dp = item.Split('\t')[4].ToString();
                        login_label_OX.Visible = true;
                        login_label_OX.Text = "로그인 성공";
                        loginput();
                        this.Visible = false;
                        Form2 f2 = new Form2();
                        f2.loginform += self_call;

                        f2.Show();
                        return;
                    }
                }
                catch
                {
                   
                }
            }
            login_label_OX.Visible = true;
            login_label_OX.Text = "로그인 정보가 일치하지 않습니다.";
         
        }


        private List<string> logdayCheck()
        {
            string line;
            List<string> lines = new List<string>();
            StreamReader sr = new StreamReader(@"C:\\Erp_main\\Em_info\\출퇴근기록.txt");
            while((line = sr.ReadLine())!=null)
            {
                lines.Add(line);
            }

            sr.Close();  
            sr.Dispose();
            return lines;
        }


        private void loginput()
        {

            string[] arr = new string[10];
            List<string> lines = new List<string>();
            DateTime dt = DateTime.Now;

            DateTime nt;

            lines = logdayCheck();
            try
            {
                foreach (string line in lines)
                {
                    if (line.Contains(user_emcode))
                    {


                        nt = Convert.ToDateTime(line.Split('\t')[3]);

                        if ((nt.Year.ToString() + nt.Month.ToString() + nt.Day.ToString()) == (dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString()))
                        {
                            //로그인기록상 오늘날짜와 같은날이 있다면(동일 다중 접속이라면

                            return; //기록할필요X
                        }
                    }
                }
            }
            catch
            {

            }

            


            string today_log = user_name + "\t" + user_emcode + "\t" + user_dp+"\t"+dt;
            //이름,사번 , dt
            StreamWriter sw = File.AppendText(@"C:\\Erp_main\\Em_info\\출퇴근기록.txt");
            sw.WriteLine(today_log); //사번,오늘날짜,현재시간, 퇴근시간, 총근무시간, 근로일수
            sw.Close();
            sw.Dispose();

            prt_end_log_check();
        }

        private void self_call()
        {
            this.Visible = true;
        }


        private void prt_end_log_check() //매출이 발생했는지에대한 검색 및 기록
        {
            List<string> prt_re= new List<string>();
            List<string> prt_af= new List<string>();
            List<string> ct_money = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            prt_re = fi.txt_read(@"C:\\Erp_main\\Prt_info\\프로젝트예약.txt");
            prt_af = fi.txt_read(@"C:\\Erp_main\\Prt_info\\사후관리내역.txt");
            ct_money = fi.txt_read(@"C:\\Erp_main\\Ac_info\\급여내역.txt");

            
            DateTime now = DateTime.Now;
            List<string> end_money = new List<string>();
            List<string> after_money = new List<string>();
            //날짜 영업수익    매출원가 매출총이익   판매관리비 영업이익    당기순이익	

            foreach (var re in prt_re) //마감기록에 한해서
            {
                string[] arr = re.Split('\t');

                if (DateTime.TryParse(arr[5], out DateTime end))
                {
                    if (end < now) //마감기록중
                    {

                        int a1 = Convert.ToInt32(arr[6]);
                        
                        string e_end =arr[5] +'\t'+((a1*1.5)%10).ToString() +"\t" + arr[6]+"\t\t0\t\t";
                        end_money.Add(e_end);
                    }
                }
            }
            foreach(var re in prt_af)
            {
                string[] brr = re.Split('\t');
                if (DateTime.TryParse(brr[5], out DateTime end))
                {
                    if (end < now) //마감기록중
                    {
                        int b1 = Convert.ToInt32(brr[6]);
                        string a_end =brr[5] +'\t'+((b1*1.5)%10).ToString() +'\t' + brr[6]+ "\t\t0\t\t";
                        end_money.Add(a_end);
                    }
                }
            }

            List<string> pal = new List<string>();
            pal= fi.txt_read(@"C:\\Erp_main\\Ac_info\\profit_and_loss.txt");
            List<string> sales = new List<string>();
            foreach(string s in pal)
            {
                string[] ss= s.Split('\t');
                foreach(var ed in end_money)
                {
                    if(ss[0] == ed.Split('\t')[0]) //이미 기록된 날짜면 패스
                    {
                        continue;
                    }
                    else
                    {
                        sales.Add(ed); //없는 날짜의 경우에 취합
                    }
                }
            }


            List<string> total_sales = new List<string>();  

            foreach(var i in pal)
            {
                total_sales.Add(i);
            }
            foreach(var s in sales)
            {
                total_sales.Add(s);
            }

            StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Ac_info\\profit_and_loss.txt");
            foreach(var total in total_sales)
            {
                sw.WriteLine(total);
            }

            foreach(var money in ct_money)
            {
                sw.WriteLine(money);
            }

            sw.Close();
            sw.Dispose();




        }
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














        private Color f_color = ColorTranslator.FromHtml("#d7d2cc");
        private Color s_color = ColorTranslator.FromHtml("#304352");
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush br = new LinearGradientBrush(this.ClientRectangle, f_color, s_color, 45, false);
            e.Graphics.FillRectangle(br, this.ClientRectangle);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }


    class Folder_info
    {

        private static string mainfolder_path = @"C:\\Erp_main"; //main폴더
        private static string em_info_path = @"\\Em_info"; //인사
        private static string prt_info_path = @"\\Prt_info"; //외주
        private static string ac_info_path = @"\\Ac_info"; //회계
        private static string cpy_info_path = @"\\Cpy_info"; //거래처
        private static string approval_info_path = @"\\Approval_info"; //결재관리
        private static string company_info_path = @"\\Company_info"; //환경설정 회사정보
        private static string py_info_path = @"\\Py_info";

        private static List<string> all_folder = new List<string>()
        {
            em_info_path,prt_info_path,ac_info_path,cpy_info_path,approval_info_path,company_info_path,py_info_path
        };
        
        private static string em_id_pw_text = @"\\Em_id_pw.txt";
        private static string em_all_info_text = @"\\Em_all_info.txt";
        private static string em_log_info_text = @"\\출퇴근기록.txt";
        private static string em_money_info_text = @"\\월급계산서.txt";
        private static string em_business_info_text = @"\\출장내역.txt";
        private static string em_vacation_info_text = @"\\휴가내역.txt";
        private static string power_check_text = @"\\권한설정.txt";
        private static string default_money_text = @"\\기본급설정.txt";
        private static string company_info_text = @"\\company.txt";
        private static List<string> all_Em_txt = new List<string>()
        {
            em_id_pw_text, em_all_info_text,em_log_info_text,em_business_info_text,em_money_info_text,em_vacation_info_text,power_check_text,
            default_money_text,company_info_text
        };

        private static string prt_info = @"\\프로젝트예약.txt";
        private static string prt_teams = @"\\프로젝트팀원.txt";
        private static string prt_as_info = @"\\사후관리내역.txt";
        private static string prt_as_teams = @"\\사후관리팀원.txt";

        private static List<string> all_Prt_txt = new List<string>()
        {
            prt_info,prt_teams,prt_as_info,prt_as_teams
        };

        private static string company_info = @"\\사내공지.txt";
        private static string company_logo = @"\\logo_Image";
        private static List<string> all_Company_txt= new List<string>()
        {
            company_info,company_logo
        };

        private static string cpy_info = @"\\거래처목록.txt";
        private static List<string> all_Cpy_txt = new List<string>()
        {
            cpy_info
        };


        private static string approval_state = @"\\결재상태.txt";
        private static string approval_ref = @"\\결재참조.txt";
        

        private static List<string> all_Approval_txt = new List<string>()
        {
            approval_state,approval_ref
            
        };

        private static string account_info = @"\\profit_and_loss.txt";
        private static string money_info = @"\\급여내역.txt";

        private static List<string> all_AC_txt = new List<string>()
        {
            account_info,money_info
        };


        private static string py_info = @"\\all_py.txt";

        private static List<string> all_Py_txt = new List<string>()
        {
            py_info
        };



        private static string text_path;





        public void folder_check()
        {


            foreach (var foldername in all_folder)
            {
                DirectoryInfo di = new DirectoryInfo(mainfolder_path + foldername);
                if (di.Exists == false) //폴더가 없으면
                {

                    di.Create();

                }
            }
            

        }   

        public void text_file_check()
        {
            foreach(var folder in all_folder)
            {
                if(folder.Contains(em_info_path))//인사폴더의 경우
                {
                    foreach (var text in all_Em_txt) //인사관련 DB 에 접근
                    {
                        text_path = mainfolder_path + @"\\Em_info" + text;

                        if (File.Exists(text_path) == false)
                        {
                            StreamWriter sw = new StreamWriter(text_path);

                            sw.WriteLine("");
                            sw.Close();
                            sw.Dispose();
                            //File.Create(text_path);
                        }
                    }
                }
                else if(folder.Contains(prt_info_path)) //프로젝트 폴더의 경우
                {
                    foreach(var text in all_Prt_txt)
                    {
                        text_path = mainfolder_path + @"\\Prt_info" + text;

                        if(File.Exists(text_path) == false)
                        {
                            StreamWriter sw = new StreamWriter(text_path);
                            sw.Write("");
                            sw.Close();
                            sw.Dispose();
                        }

                    }
                }
                else if(folder.Contains(cpy_info_path))
                {
                    foreach(var text in all_Cpy_txt)
                    {
                        text_path = mainfolder_path + @"\\Cpy_info" + text;
                        if(File.Exists(text_path)==false)
                        {
                            StreamWriter sw = new StreamWriter(text_path);
                            sw.Write("");
                            sw.Close();
                            sw.Dispose();
                        }
                    }
                }
                else if(folder.Contains(ac_info_path))
                {
                    foreach(var text in all_AC_txt)
                    {
                        text_path = mainfolder_path + @"\\Ac_info" + text;
                        if(File.Exists(text_path)==false)
                        {
                            StreamWriter sw = new StreamWriter(text_path);
                            sw.Write("");
                            sw.Close();
                            sw.Dispose();
                        }
                    }
                }


                else if(folder.Contains(company_info_path))
                {
                    foreach(var text in all_Company_txt)
                    {
                        text_path = mainfolder_path + @"\\Company_info" + text;
                        if(text_path.Contains("logo"))
                        {
                            DirectoryInfo di = new DirectoryInfo(text_path);
                            if (di.Exists==false)
                            {
                                di.Create();
                            }
                            

                        }
                        else if(File.Exists(text_path) == false)
                        {
                            StreamWriter sw = new StreamWriter(text_path);
                            sw.Write("");
                            sw.Close();
                            sw.Dispose();
                        }
                    }
                }

                else if(folder.Contains(approval_info_path))//결재관리폴더
                {
                    foreach(var text in all_Approval_txt)
                    {
                        text_path = mainfolder_path + @"\\Approval_info" + text;
                        if(File.Exists(text_path)==false)
                        {
                            StreamWriter sw = new StreamWriter(text_path);
                            sw.Write("");
                            sw.Close();
                            sw.Dispose();
                        }
                    }
                }
                else if (folder.Contains(py_info_path))//결재폼내부 폴더
                {
                    foreach (var text in all_Py_txt)
                    {
                        text_path = mainfolder_path + @"\\Py_info" + text;
                        if (File.Exists(text_path) == false)
                        {
                            StreamWriter sw = new StreamWriter(text_path);
                            sw.Write("");
                            sw.Close();
                            sw.Dispose();
                        }
                    }
                }
            }
           
        }
    }

    class UserCheck
    {
        private string line;
        
        public List<string> search_user(string path)
        {
            
            List<string> list = new List<string>();
            StreamReader sr = new StreamReader(path);

            while ((line = sr.ReadLine()) != null)
            {
                list.Add(line);
            }
            sr.Close();
            sr.Dispose();
            return list;
        }


        public void Master_login()
        {

            DirectoryInfo di = new DirectoryInfo(@"C:\\Erp_main\\Em_info\\Master_code");
            if (di.Exists == false) //마스터계정의 최초로그인시
            {
                di.Create();

                StreamWriter write_memo = new StreamWriter(di.FullName + @"\\Master_code_memo.txt"); //메모장생성
                write_memo.WriteLine("help me");
                write_memo.Close();
                write_memo.Dispose();

                //id ,pw ,이름, 사번 부서
                StreamWriter fa = new StreamWriter(@"C:\\Erp_main\\Em_info\\Em_id_pw.txt"); //계정정보생성
                fa.WriteLine("111\t111\t이한영\ttMarster_code\t개발");
                fa.Close();
                fa.Dispose();


                StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Em_info\\Em_all_info.txt");
                //이름,사번,부서,직급,연차,나이,전화번호,이메일,주민번호,주소,결혼정보,계약종류
                sw.WriteLine("이한영\tMaster_code\t제작부서\t제작자직급\t0\t000-0000-0000\taaa@aaa.com\t000000-0000000\t한국어딘가\tX\t제작자\ttrue"); //정보 생성
                sw.Close();
                sw.Dispose();


                StreamWriter power = new StreamWriter(@"C:\\Erp_main\\Em_info\\권한설정.txt"); //마스터 계정권한부여
                power.WriteLine("Master_code\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1");
                power.Close();
                power.Dispose();
            }
        }





    }


}


