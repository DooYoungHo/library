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
    public partial class new_id_pw_create : Form
    {


        static string[] user_all_info;
            
        public new_id_pw_create(string[] user_info)                   
        {
            InitializeComponent();
            
            new_user_name.Text = user_info[0];
            new_user_code.Text = user_info[1];
            new_user_dp.Text = user_info[2];


            user_all_info= user_info;
        }

        private void new_id_pw_create_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grandientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }





        private void pw_text_box_TextChanged(object sender, EventArgs e)
        {


            pw_security_check(); //비밀번호 유효성 검사
            

        }
        private void pw_check_text_box_TextChanged(object sender, EventArgs e)
        {
            pw_check_info.Visible = true;
            if(pw_text_box.Text == pw_check_text_box.Text)
            {
                pw_check_info.ForeColor = Color.Green;
                pw_check_info.Text = "일치";
            }
            else
            {
                pw_check_info.ForeColor = Color.Red;
                pw_check_info.Text = "불일치";
            }
        }

        public void pw_security_check()
        {
            string str = pw_text_box.Text;
            int security = 0;
            string sp_code = "!@#$%^&*()_+{}][<>?,./`~+-*";
            //무조건 영문 무조건해결

            //특문 1개이상포함 
            //6~15자
            //대문자하나이상
            //공백미포함, \불가

            //연속된 3글자만


            if(str.Length < 6)
            {
                pw_info.ForeColor = Color.Red;
                pw_info.Text = "6글자이상만 가능";
                return;
            }
            
            


            foreach (var s in str)
            {
                if (Char.IsWhiteSpace(s))
                {
                    //공백 유무
                    return;
                }
                if(str.Contains("\\"))
                {
                    // \ 사용
                    return;
                }
            }

            
            for(int i = 0; i < str.Length; i++)
            {
                if(i+2 < str.Length)
                {
                    if (str[i] == str[i + 1])
                    {

                        if (str[i + 1] == str[i + 2])
                        {
                            pw_info.ForeColor = Color.Red;
                            pw_info.Text = "연속된 3글자는 사용금지";
                            return;
                        }
                    }
                }
            }






            if (str.Length >= 6 && str.Length <= 15) //글자수 파악
            {
                security += 1;
            }
            foreach (var sp in sp_code) //특문확인
            {
                if (str.Contains(sp))
                {
                    security += 1;
                    break;
                }
            }
            foreach (var s in str) //대문자 확인
            {
                if (Char.IsUpper(s))
                {
                    security += 1;
                    break;
                }
            }


            if(security >= 3)
            {

                pw_info.ForeColor = Color.Green;
                pw_info.Text = "보안성: 높음";
            }
            else if(security ==2)
            {
                pw_info.ForeColor = Color.DarkGreen;
                pw_info.Text = "보안성 : 중간";
            }
            else if(security == 1)
            {
                pw_info.ForeColor = Color.Red;
                pw_info.Text = "보안성 : 낮음";
            }






        }

        private void id_overlap_btn_Click(object sender, EventArgs e)
        {
            string id = id_text_box.Text;
            string all_id;

            StreamReader sr = new StreamReader(@"C:\\Erp_main\\Em_info\\Em_id_pw.txt");
            while((all_id = sr.ReadLine()) != null)
            {
                if(all_id.Split('\t')[0] == id_text_box.Text)
                {
                    id_info.ForeColor= Color.Red;
                    id_info.Visible = true;
                    id_info.Text = "이미 있는 id 입니다.";
                    sr.Close();
                    sr.Dispose();
                    return;
                }
            }

            id_info.Visible = true;
            id_info.ForeColor = Color.Green;
            id_info.Text = "생성 가능한 id 입니다.";
            sr.Close();
            sr.Dispose();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static bool em_check = false;
        private void save_btn_Click(object sender, EventArgs e)
        {
            if(id_info.Text == pw_info.Text)
            {
                MessageBox.Show("ID와 PW는 같을 수 없습니다.");
                return;
            }

            if(id_info.ForeColor == Color.Green &&pw_info.ForeColor == Color.Green && pw_check_info.ForeColor == Color.Green)
            {
                //선행조건 만족시 생성
                user_create();





                MessageBox.Show("신규가입이 완료되었습니다.");
                em_check= true;
                this.Close();

                
            }
            else
            {
                MessageBox.Show("id,pw를 다시 확인해주세요");
            }
        }



        private void user_create()
        {


            //em_new_name_text.Text = "";//이름     0
            //em_new_em_code_text.Text = "";//사번 1
            //em_new_dp_text.Text = "";//부서      2
            //em_new_rank_text.Text = ""; //직급   3
            //                          1   연차   4
            //em_new_age_text.Text = "";//나이 5
            //em_new_r_number_text.Text = "";//주민번호 6     
            //em_new_p_number_text.Text = "";//전화번호 7
            //em_new_adress_text.Text = ""; //주소 8
            //em_new_email_text.Text = ""; //이메일 9
            //개발등급(어느정도수준인제)  10
            //개발능력(몇개가능한지) 11
            //결혼정보 12
            //계약종류13
            //사진14
            //이력서파일15


            Person_info new_info = new Person_info();
            if (new_info.new_em(user_all_info[1])) //폴더 생성
            {
                new_info.new_em_txt(user_all_info); //사원정보 저장
                //개인 사번 폴더 내에 이미지,이력서 파일 저장시켜야한다
                try
                {
                    File.Copy(user_all_info[15], @"c:\\Erp_main\\Em_info\\" + user_all_info[1] + @"\\" + user_all_info[1] + "사진.jpg", true);
                    File.Copy(user_all_info[16], @"C:\\Erp_main\\Em_info\\" + user_all_info[1] + @"\\" + user_all_info[1] + "이력서.txt", true);
                }
                catch
                {

                }


                StreamWriter sw = File.AppendText(@"C:\\Erp_main\\Em_info\\Em_id_pw.txt");
                sw.WriteLine(id_text_box.Text + "\t" + pw_text_box.Text + "\t" + new_user_name.Text + "\t" + new_user_code.Text + "\t" + new_user_dp.Text);
                // id, pw, 이름,사번,부서
                sw.Close();
                sw.Dispose();



                //사번,관리자,사원조회,신규등록,퇴사,급여관리,출퇴근관리,휴가,출장,부서변경,//진행현황,예약  ,변경/수정,사후관리,마감기록,//매출,손익분석//,거래처조회,신규등록
                //0     1       2       3       4         5     6          7   8     9       //  10     11       12      13         14    //   15     16    //   17       18

                StreamWriter power = File.AppendText(@"C:\\Erp_main\\Em_info\\권한설정.txt");
                power.WriteLine(new_user_code.Text + "\t" + "0\t1\t0\t0\t1\t1\t1\t1\t0\t1\t1\t0\t1\t1\t0\t0\t1\t0");
                power.Close();
                power.Dispose();
            }
            

            

        }


        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
