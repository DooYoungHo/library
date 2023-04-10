//using GMap.NET.MapProviders;
//using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;
using static System.Diagnostics.Process;
//using GMap.NET;
//using GMap.NET.MapProviders;
//using System.Windows.Forms;
//using GMap.NET.WindowsForms;
using System.Windows.Forms.VisualStyles;

namespace Example
{

    public partial class Setting_form : Form
    {
        public static string f_font;         // 글꼴 설정

        public static int f_size;            // 글꼴 사이즈

        public static string f_style;        // 글꼴 스타일

        public static string t_teme;         // 테마

        public static Font s;

        public static string exist_PW;      //기존 비밀번호 담는 곳

        Form1 check = new Form1();

        DataTable table = new DataTable();       // 조회 버튼 그리드뷰

        public int count;         // 중복문자 확인
        public int str_count;     // 특수문자 확인
        public int Upper_count;   // 대문자 확인
        char overlap;      // 새로 생긴 비번 담을곳
        string special_char = "\\ "; // 안되는 특수문자 설정
        string Uni_char = "!@#$%^&*(){}[]?,.<>;:`~-_=+"; // 사용 가능한 특수문자 설정

        private List<string> find_list = new List<string>(); // 메모장 돌릴 리스트
        private List<string> name_list = new List<string>(); // 이름 돌릴 리스트

        private int Uni_cnt;

        private int check_point; //현재 비번이라면 체크
        private string change_password;  // 비번 바꿀 텍스트값 저장

        private string setting_company_name;   // 환경설정 회사 이름
        private string setting_company_address;   // 환경설정 주소
        private string setting_company_ceo;      // 환경설정 대표 이름
        private string setting_company_number;    // 환경설정 번호

        private string find_name;           // 그리드뷰 이름 담을 배열
        private string find_em_number;      // 그리드뷰 사원번호 담을 배열
        private string find_department;     // 그리드뷰 부서 담을 배열
        private string find_position;       // 그리드뷰 직급 담을 배열
        private string year;               // 그리드뷰 연차 담을 배열

        private int add_count;             // 조회 카운트가 1 이상일때만




        public delegate void notice_fix(string text);
        public event notice_fix nf;



        public Setting_form()
        {
            InitializeComponent();

            admin.Focus();
            panel_off();

            admin_panel4.Visible = true;

            //admin_panel4.Visible = true;
            //Main_setting_panel.Visible = false;
            //teme_panel.Visible = false;
            //color_panel1.Visible = false;
            //Font_pannel.Visible = false;
            //Fontchange_pannel.Visible = false;
            //password_change_panel.Visible = false;
            //panel3.Visible = false;
            

            dataGridView1.Columns.Add("colname", "이름");
            dataGridView1.Columns.Add("coljob", "직업");

            font_comboBox_Init();
            font_size_Init();
            comboBox_Init();
            manager_Init();
            font_style_Init();
            
            
            

            f_font = "";
            f_size = 0;
            f_style = "";
            t_teme = "";

            label15.Text = "현재 비번 입력";


            table.Columns.Add("이름", typeof(string));
            table.Columns.Add("사번", typeof(string));
            table.Columns.Add("부서", typeof(string));
            table.Columns.Add("직급", typeof(string));
            table.Columns.Add("연차", typeof(string));

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            //setting_company_name = Form1.company_name;
            //setting_company_address = Form1.company_adderss;
            //setting_company_ceo = Form1.company_ceo;
            //setting_company_number = Form1.company_number;

            // company.Text = setting_company_name;
            // address.Text = setting_company_address;                                 텍스트박스에 뜨게 해줄지 말지
            // ceo.Text = setting_company_ceo;                          
            // direct_number.Text = setting_company_number;

            logo_checking(Logo_img());


            old_notice_txt();

            
        }


        private void old_notice_txt()
        {
            List<string> line = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            line = fi.txt_read(@"C:\\Erp_main\\Company_info\\사내공지.txt");
            string notice = "";

            foreach(var i in line)
            {
                notice += i;
            }
            set_notice_text_box.Text = notice;
        }



        private void panel_off()
        {
            //관리자설정
            Main_setting_panel.Visible = false;
            admin_panel4.Visible = false;
            //비번변경
            password_change_panel.Visible = false;
            //폰트변경
            Font_pannel.Visible = false;
            //테마변경
            teme_panel.Visible = false;
        }










        private void pw_change_Click(object sender, EventArgs e) //비번변경
        {
            panel_off();
            //admin_panel4.Visible = false;
            //Main_setting_panel.Visible = false;
            //teme_panel.Visible = true;
            //color_panel1.Visible = true;
            //Font_pannel.Visible = true;
            //Fontchange_pannel.Visible = true;
            password_change_panel.Visible = true;
            //password_change_panel.BringToFront();
        }
        
        private void Font_Click(object sender, EventArgs e)  //글꼴 버튼
        {
            panel_off();
            //admin_panel4.Visible = false;
            //Main_setting_panel.Visible = false;
            //teme_panel.Visible = true;
            
            Font_pannel.Visible = true;
            //Fontchange_pannel.Visible = true;
            //password_change_panel.Visible = false;
            //Font_pannel.BringToFront();
        }

        private void theme_Click(object sender, EventArgs e) // 테마 버튼
        {
            panel_off();
            //admin_panel4.Visible = true;
            //Main_setting_panel.Visible = false;
            teme_panel.Visible = true;
            //color_panel1.Visible = true;
            //Font_pannel.Visible = false;
            //Fontchange_pannel.Visible = false;
            //password_change_panel.Visible = false;
            //teme_panel.BringToFront();
        }
        private void admin_Click(object sender, EventArgs e) // 관리자 설정 버튼
        {
            panel_off();
            admin_panel4.Visible = true; //관리자비밀번호
            //Main_setting_panel.Visible = false;
            //teme_panel.Visible = false;
            //color_panel1.Visible = false;
            //Font_pannel.Visible = false;
            //Fontchange_pannel.Visible = false;
            //password_change_panel.Visible = false;
            //admin_panel4.BringToFront();
            
            
        }





        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void admin_Login_Click(object sender, EventArgs e)
        {
            if (PassWord.Text == "1234")
            {
                panel_off();

                Main_setting_panel.Visible = true;
                admin_panel4.Visible = false;
                
                
                
                //Main_setting_panel.BringToFront();
            }
        }
        private void admin_panel4_Paint(object sender, PaintEventArgs e) // 관리자설정 패널
        {

        }

        private void teme_panel_Paint(object sender, PaintEventArgs e) // 테마설정 패널
        {

        }
        private void Font_pannel_Paint(object sender, PaintEventArgs e) // 폰트 패널
        {

        }
        private void Fontchange_pannel_Paint(object sender, PaintEventArgs e)  // 폰트 변경 패널
        {

        }
        private void panel3_Paint(object sender, PaintEventArgs e)                      // 환경설정 -> 권한부여 페널
        {

        }
        private void Main_setting_Paint(object sender, PaintEventArgs e)                // 환경설정 - 메인설정 변경 패널
        {

        }

        private void teme_combo_SelectedIndexChanged(object sender, EventArgs e) // 테마설정 콤보박스
        {
            foreach(string item in teme_combo.Items)
           {
                if (teme_combo.SelectedItem.ToString() == item)
                {
                    color_panel1.BackColor = Color.FromName(item);
                    t_teme = item;
                }
            }
        }
        System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));           // 폰트형 변환
        private void font_combobox_SelectedIndexChanged(object sender, EventArgs e) // 글꼴 콤보박스
        {
            for (int i = 0; i < font_combobox.Items.Count; i++)
            {
                if (font_combobox.SelectedItem.ToString() == font_combobox.Items[i].ToString())
                {
                    if (f_size > 0)
                    {
                        Fontchange_pannel.Font = new Font(font_combobox.Items[i].ToString(), Convert.ToInt32(FontSize.SelectedItem.ToString()));
                        textBox1.Text = font_combobox.Items[i].ToString();
                        f_font = font_combobox.Items[i].ToString();
                    }
                    else
                    {
                        Fontchange_pannel.Font = new Font(font_combobox.Items[i].ToString(), 10);
                        textBox1.Text = font_combobox.Items[i].ToString();
                        f_font = font_combobox.Items[i].ToString();
                    }
                }
            }
        }
        private void FontSize_SelectedIndexChanged(object sender, EventArgs e)     // 폰트 크기
        {
            Fontchange_pannel.Font = new Font(f_font, Convert.ToInt32(FontSize.Text.ToString()));
            f_size = Convert.ToInt32(FontSize.Text.ToString());
        }
        private void FontStyle_SelectedIndexChanged_1(object sender, EventArgs e)      // 폰트 스타일
        {
            if (Font_Style.SelectedItem.ToString() == "굵게")
            {
                Fontchange_pannel.Font = new Font(f_font, Convert.ToInt32(FontSize.Text.ToString()),FontStyle.Bold);
            }
            else if (Font_Style.SelectedItem.ToString() == "기울임꼴")
            {
                Fontchange_pannel.Font = new Font(f_font, Convert.ToInt32(FontSize.Text.ToString()), FontStyle.Italic);
            }
            else if (Font_Style.SelectedItem.ToString() == "보통")
            {
                Fontchange_pannel.Font = new Font(f_font, Convert.ToInt32(FontSize.Text.ToString()), FontStyle.Regular);
            }
            else if (Font_Style.SelectedItem.ToString() == "가운데 밑줄")
            {
                Fontchange_pannel.Font = new Font(f_font, Convert.ToInt32(FontSize.Text.ToString()), FontStyle.Strikeout);
            }
            else
            {
                Fontchange_pannel.Font = new Font(f_font, Convert.ToInt32(FontSize.Text.ToString()), FontStyle.Underline);
            }
        }
        private void comboBox_Init()                              // 테마 색상 함수
        {
            teme_combo.Items.Add("Black");
            teme_combo.Items.Add("White");
            teme_combo.Items.Add("Gray");
            teme_combo.Items.Add("Red");
            teme_combo.Items.Add("Yellow");
            teme_combo.Items.Add("Green");
            teme_combo.Items.Add("Blue");
            teme_combo.Items.Add("Cyan");
            // teme_combo.index = 기본값으로 나오게끔
        }
        private void font_size_Init()
        {

            for(int i=2;i<17;i+=2)
            {
                FontSize.Items.Add(i);
            }

            //FontSize.Items.Add(2);
            //FontSize.Items.Add(4);
            //FontSize.Items.Add(6);
            //FontSize.Items.Add(8);
            //FontSize.Items.Add(10);
            //FontSize.Items.Add(12);
            //FontSize.Items.Add(14);
            //FontSize.Items.Add(16);



            FontSize.Items.Add(20);
            FontSize.Items.Add(24);
            FontSize.Items.Add(28);
            FontSize.Items.Add(32);
            FontSize.Items.Add(40);
            FontSize.SelectedIndex = 4;
        }
        private void font_style_Init()
        {
            Font_Style.Items.Add("굵게");
            Font_Style.Items.Add("기울임꼴");
            Font_Style.Items.Add("보통");
            Font_Style.Items.Add("가운데 밑줄");
            Font_Style.Items.Add("밑줄");
            Font_Style.SelectedIndex = 2;
        }
        private void manager_Init()
        {
            manager.Items.Add("대표이사");
            manager.Items.Add("이사");
            manager.Items.Add("부장");
            manager.Items.Add("팀장");
            manager.Items.Add("사원");
        }
        private void font_comboBox_Init()                             // 글꼴 함수
        {
            List<string> fonts = new List<string>();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                font_combobox.Items.Add(font.Name);
            }
            font_combobox.SelectedIndex = 0;
        }

        private void color_panel1_Paint(object sender, PaintEventArgs e) // 테마설정 컬러 보여주는 패널
        {

        }
        private void password_change_Paint(object sender, PaintEventArgs e)    // 비밀번호 변경 보여주는 패널
        {

        }
        private void label9_Click(object sender, EventArgs e)   //현재 비밀번호
        {

        }
        private void pw_text_TextChanged(object sender, EventArgs e) // 기본 비밀번호 치는 텍스트
        {
            if (pw_text.Text.Length == 0)
            {
                label15.Text = "현재 비번 입력";
            }
            else if (pw_text.Text.Length >= 1)
            {
                label15.ForeColor = Color.Red;
                label15.Text = "현재 비번 아님";
                if (pw_text.Text == exist_PW)
                {
                    label15.ForeColor = Color.Green;
                    label15.Text = "현재 비번 일치";
                }
            }
        }
        private void changepw_text_TextChanged(object sender, EventArgs e)     // 바꿀 비밀번호 치는 텍스트
        {
            if (changepw_text.Text.Length == 0)
            {
                label16.ForeColor = Color.Red;
                label16.Text = "";
            }
            else if (changepw_text.Text.Length < 6)
            {
                label16.ForeColor = Color.Red;
                label16.Text = "길이부족";
            }
            else
            {
                foreach (char item in changepw_text.Text)
                {
                    bool ok = Char.IsUpper(item);                                  // 대문자 확인
                    if (ok == true)
                    {
                        Upper_count += 1;
                    }
                    foreach (char item2 in special_char)                              // 안되는 특수문자 확인
                    {
                        if (item == item2)
                        {
                            str_count += 1;
                        }
                    }
                    foreach (char item3 in Uni_char)                                // 되는 특수문자 확인
                    {
                        if (item == item3)
                        {
                            Uni_cnt += 1;
                        }
                    }
                    if (str_count >= 1)
                    {
                        label16.ForeColor = Color.Red;
                        label16.Text = "올바르지 않은 양식";
                    }
                    else if (Upper_count >= 1 & Uni_cnt >= 1)
                    {
                        label16.ForeColor = Color.Green;
                        label16.Text = "변경이 가능합니다";
                    }
                }
            }
            try
            {
                for (int i = 0; i < changepw_text.Text.Length; i++)            // 중복 확인
                {
                    if (i + 2 < changepw_text.Text.Length)
                    {
                        if (changepw_text.Text[i] == changepw_text.Text[i + 1])
                        {
                            if (changepw_text.Text[i] == changepw_text.Text[i + 2])
                            {
                                label16.ForeColor = Color.Red;
                                label16.Text = "중복문자 존재";
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch
            {
                MessageBox.Show("뭐가문제");
            }
            if (changepw_text.Text == exist_PW)
            {
                label16.ForeColor = Color.Red;
                label16.Text = "현재비번";
            }
            Upper_count = 0;
            str_count = 0;
            change_password = changepw_text.Text;
        }
        private void reconfirmpw_text_TextChanged(object sender, EventArgs e)     // 재확인 비밀번호 치는 텍스트
        {
            if (changepw_text.Text == reconfirmpw_text.Text)
            {
                label17.ForeColor = Color.Green;
                label17.Text = "비밀번호 정보가 일치합니다.";
            }
            else
            {
                label17.ForeColor = Color.Red;
                label17.Text = "비밀번호 정보가 불일치합니다.";
            }
        }
        private void pwchange_ok_Click(object sender, EventArgs e)            // 비번 변경 버튼
        {
            DialogResult PW = MessageBox.Show("정말 바꾸시겠습니까?", "안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (PW == DialogResult.OK)
            {
                if (pw_text.Text.Length == 0 | changepw_text.Text.Length == 0 | reconfirmpw_text.Text.Length == 0 | changepw_text.ReadOnly == false)
                {
                    if (pw_text.Text.Length == 0)
                    {
                        MessageBox.Show("빈 칸이 있습니다", "안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        pw_text.Focus();
                    }
                    else if (changepw_text.Text.Length == 0)
                    {
                        MessageBox.Show("빈 칸이 있습니다", "안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        changepw_text.Focus();
                    }
                    else if (reconfirmpw_text.Text.Length == 0)
                    {
                        MessageBox.Show("빈 칸이 있습니다", "안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        reconfirmpw_text.Focus();
                    }
                }
                if (label15.ForeColor == Color.Red | label16.ForeColor == Color.Red | label17.ForeColor == Color.Red | changepw_text.ReadOnly == false)
                {
                    if (label15.ForeColor == Color.Red)
                    {
                        MessageBox.Show("올바르지 않은 접근입니다 !", "경고", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        pw_text.Focus();
                    }
                    else if (label16.ForeColor == Color.Red)
                    {
                        MessageBox.Show("올바르지 않은 접근입니다 !", "경고", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        changepw_text.Focus();
                    }
                    else if (label17.ForeColor == Color.Red)
                    {
                        MessageBox.Show("올바르지 않은 접근입니다 !", "경고", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        reconfirmpw_text.Focus();
                    }
                    else
                    {
                        MessageBox.Show("변경확인 버튼을 눌러주세요", "안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        password_checking.Focus();
                    }
                }
                else
                {
                    string txt = File.ReadAllText(@"C:\\Erp_main\\Em_info\\Em_id_pw.txt");
                    txt = txt.Replace(exist_PW, change_password);
                    File.WriteAllText(@"C:\\Erp_main\\Em_info\\Em_id_pw.txt", txt);
                    MessageBox.Show("변경이 완료되었습니다!");
                    this.Close();
                    Form2 f2 = new Form2();            // 폼 2
                    f2.Close();
                    Form1 f1 = new Form1();
                    f1.Visible = true;
                    pw_text.Clear();
                    changepw_text.Clear();
                    reconfirmpw_text.Clear();
                    label15.Text = "";
                    label16.Text = "";
                    label17.Text = "";
                }
            }
        }

        private void changepw_no_Click(object sender, EventArgs e)               // 비번 변경 취소 버튼
        {
            DialogResult nochange = MessageBox.Show("정말 취소하시겠습니까?","안내",MessageBoxButtons.OKCancel,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            if (nochange == DialogResult.OK)
            {
                changepw_text.ReadOnly = false;
                pw_text.Clear();
                changepw_text.Clear();
                reconfirmpw_text.Clear();
                label15.Text = "";
                label16.Text = "";
                label17.Text = "";
            }
        }
        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)           // 현재 비밀번호 옆 문구
        {
            
        }

        private void label16_Click(object sender, EventArgs e)             // 바꿀 비밀번호 옆 문구
        {

        }

        private void changepw_text_Leave(object sender, EventArgs e)
        {
            if (changepw_text.Text.Length == 0)
            {
                label16.Text = "";
            }
        }
        private void password_checking_Click(object sender, EventArgs e)        // 비밀번호가 현재 존재하는지 체크
        {
            UserCheck uc = new UserCheck();
            find_list = uc.search_user(@"C:\\Erp_main\\Em_info\\Em_id_pw.txt");
            try
            {
                foreach (string item in find_list)
                {
                    var pw = item.Split('\t')[1];
                    if (change_password == pw)
                    {
                        check_point += 1;
                    }
                }
                if (check_point >= 1 | label16.ForeColor == Color.Red)               // 중복 비밀번호가 있다면
                {
                    DialogResult nochange = MessageBox.Show("이미 존재합니다!", "경고", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (nochange == DialogResult.OK)
                    {
                        changepw_text.Clear();
                        changepw_text.Focus();
                        check_point = 0;
                    }
                }
                else                                                                   // 중복 비밀번호가 없다면
                {
                    DialogResult nochange = MessageBox.Show("사용 가능합니다!", "안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (nochange == DialogResult.OK)
                    {
                        changepw_text.ReadOnly = true;
                        reconfirmpw_text.Focus();
                    }
                }

            }
            catch
            {

            }
            
        }









        private void sub_panel_off()
        {
            power_gift_panel.Visible = false;
            my_cpy_set_panel.Visible = false;
            set_manage_money_panel.Visible = false;
        }


        private void Authorization_Click(object sender, EventArgs e)           // 권한부여 버튼
        {
            panel_off();
            sub_panel_off();
            Main_setting_panel.Visible = true;
            power_gift_panel.Visible = true; //권한부여창
            //set_manage_money_panel.Visible = false;
            //my_cpy_set_panel.Visible = false;
        }
        private void Main_Click(object sender, EventArgs e)                      // 메인설정 버튼
        {
            panel_off();
            sub_panel_off();
            Main_setting_panel.Visible = true;
            my_cpy_set_panel.Visible = true; //회사 설정창
            //power_gift_panel.Visible = false;
            //set_manage_money_panel.Visible = false;
            //Main_setting_panel.BringToFront();
        }
        private void Money_Click(object sender, EventArgs e)                         // 급여관리 버튼
        {
            panel_off();
            sub_panel_off();
            Main_setting_panel.Visible = true;
            set_manage_money_panel.Visible = true; //급여관리창
            //power_gift_panel.Visible = false;
            //my_cpy_set_panel.Visible=false; 

            rank_combo_item();
        }







        private void rank_combo_item() //존재하는 직급만 남기기
        {
            List<string> lines = new List<string>();    
            set_rank_combo.Items.Clear();
            List<string> rank_list= new List<string>();
            Person_info pi = new Person_info();
            lines = pi.search_em();

            foreach(var line in lines)
            {
                string[] arr = line.Split('\t');
                rank_list.Add(arr[3]);
            }


            string[] ranks = rank_list.Distinct().ToArray();

            foreach (var rank in ranks)
            {
                set_rank_combo.Items.Add(rank);
            }

        }





        private void label18_Click(object sender, EventArgs e)                         // 로고변경 라벨
        {

        }
        private void label23_Click(object sender, EventArgs e)                           // 담당자 변경 라벨
        {

        }
        private void label20_Click(object sender, EventArgs e)                            // 회사명 변경 라벨
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)             // 폼 만질수 있는 담당자 변경
        {

        }
        private void button1_Click(object sender, EventArgs e)                 // 파일 폴더 확인버튼
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)                    // 폴더 경로 열어주기
        {
            try
            {
                logo.Visible = true;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Select Image";
                openFileDialog.Filter = "( *.bmp; *.jpg; *.png; *.jpeg) | *.BMP; *.JPG; *.PNG; *.JPEG";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = openFileDialog.FileName;
                }
                Image image = Image.FromFile(openFileDialog.FileName);

                logo.Image = image;

                openFileDialog.Dispose();
            }
            catch
            {

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)                  // 경로 보여주는 텍스트
        {

        }

        private void company_TextChanged(object sender, EventArgs e)                   // 회사명 변경 텍스트
        {

        }
        private void address_TextChanged(object sender, EventArgs e)                   // 주소 변경 텍스트
        {

        }

        private void ceo_TextChanged(object sender, EventArgs e)                        // 대표이사 변경 텍스트
        {

        }

        private void direct_number_TextChanged(object sender, EventArgs e)                // 대표번호 변경 텍스트
        {

        }
        public static bool Resize_img_file(string imgfilepath,in int newWidth,in int newHeight, in bool keepSizeRatio = true)    // 이미지 사이즈 변환
        {
            try
            {
                byte[] bytearr = File.ReadAllBytes(imgfilepath);

                using (var stream = new System.IO.MemoryStream(bytearr))
                {
                    Bitmap bit = new Bitmap(stream);

                    int applyWidth = newWidth;
                    int applyHeight = newHeight;

                    if(keepSizeRatio)
                    {
                        double percentW = 0;
                        double percentY = 0;
                        double targetpercent = 0;

                        percentW = (double)newWidth / bit.Width;
                        percentY = (double)newHeight / bit.Height;

                        if (percentW < percentY)
                        {
                            targetpercent = percentW;
                        }
                        else
                        {
                            targetpercent = percentY;
                        }

                        applyWidth = (int)(bit.Width * targetpercent);
                        applyHeight = (int)(bit.Height * targetpercent);

                        if (applyWidth > newWidth)
                        {
                            applyWidth = newWidth;
                        }
                        if (applyHeight > newHeight)
                        {
                            applyHeight = newHeight;
                        }
                    }
                    bit = Resize_img(bit, applyWidth, applyHeight);
                    bit.Save(imgfilepath);
                    bit.Dispose();
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }


        public static Bitmap Resize_img(Image img,int width, int height)                           // 이미지 가져오기
        {
            var destict = new Rectangle(0,0,width,height);
            var destImage = new Bitmap(width,height);

            destImage.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using(var g = Graphics.FromImage(destImage))
            {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapmod = new ImageAttributes())
                {
                    wrapmod.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(img,destict,0,0,img.Width,img.Height,GraphicsUnit.Pixel,wrapmod);
                }
            }
            return destImage;
        }
        public static List<string> Logo_img()                           // 로고 이미지 제목 리스트에 담기
        {
            string folderName = @"C:\\Erp_main\\Company_info\\logo_Image";
            List<string> logo = new List<string>();
            DirectoryInfo di = new DirectoryInfo(folderName);

            foreach (FileInfo fi in di.GetFiles())
            {
                logo.Add(fi.Name);
            }
            return logo;
        }
        public void logo_checking(List<string> logo)                     // 알맞은 규격으로 이미지 자르기
        {
            string name;
            string property;
            try
            {
                foreach (string l in logo)
                {
                    name = l.Split('.')[0].ToString();
                    property = l.Split('.')[1].ToString();

                    if ( property == "jpg" | property == "JPEG")
                    {
                        Resize_img_file(@"C:\\Erp_main\\Company_info\\logo_Image\\" + name + ".jpg", 200, 40);
                    }
                    else if( property == "png" | property == "PNG" )
                    {
                        Resize_img_file(@"C:\\Erp_main\\Company_info\\logo_Image\\" + name + ".png", 200, 40);
                    }
                    else if ( property == "jpeg" | property == "JPEG" )
                    {
                        Resize_img_file(@"C:\\Erp_main\\Company_info\\logo_Image\\" + name + ".jpeg", 200, 40);
                    }
                    else if ( property == "bmp" | property == "BMP")
                    {
                        Resize_img_file(@"C:\\Erp_main\\Company_info\\logo_Image\\" + name + ".bmp", 200, 40);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)                      // 회사 정보 변경 클릭 저장버튼
        {
            DialogResult company_change = MessageBox.Show("정말 변경하시겠습니까?", "안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (company_change == DialogResult.OK)
            {
                try
                {

                    string line = company.Text + "\t" + ceo.Text + "\t" + address.Text + "\t" + direct_number.Text + "\t" + pax_num.Text + "\t" + email_num.Text;
                    StreamWriter ssw = new StreamWriter(@"C:\\Erp_main\\Em_info\\company.txt");
                    ssw.WriteLine(line);
                    ssw.Close();
                    ssw.Dispose();

                    StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Company_info\\사내공지.txt");
                    sw.WriteLine(set_notice_text_box.Text);
                    sw.Close();
                    sw.Dispose();
                    MessageBox.Show("변경이 완료되었습니다!");
                }
                catch
                {

                }
                
            }




            nf(set_notice_text_box.Text);
        }


        







        private void button4_Click(object sender, EventArgs e)                  // 회사 정보 취소 클릭
        {
            DialogResult company_change = MessageBox.Show("정말 취소하시겠습니까?", "안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (company_change == DialogResult.OK)
            {
                company.Clear();
                address.Clear();
                ceo.Clear();
                direct_number.Clear();
                textBox2.Clear();
                logo.Visible= false;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)                     // 판넬
        {

        }
        private void logo_Click(object sender, EventArgs e)                          // 로고 예시
        {

        }
        private void button2_Click(object sender, EventArgs e)                          // 사원 권한부여 등록버튼
        {
            try
            {

                
                //사번,관리자,사원조회,신규등록,퇴사,급여관리,출퇴근관리,휴가,출장,부서변경,//진행현황,예약  ,변경/수정,사후관리,마감기록,//매출,손익분석//,거래처조회,신규등록
                //0     1      // 2       3       4         5     6          7   8     9       //  10     11       12      13         14    //   15     16    //   17       18
                //Master_code	1//1	1	1	1	1	1	1	1 //   1   1  1  1   1	// 1   1   //1   1
                //  사번        1// 2   3   4   5   6   7   8   9 //  10  11  12  13 14  //15  16  //17  18
                
                string select_code= dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                string power_line = select_code+"\t";

                for(int i = 0;i<power_checkedListBox_master.Items.Count;i++)
                {
                    if(power_checkedListBox_master.GetItemChecked(i))
                    {

                        power_line += "1\t";
                    }
                    else
                    {

                        power_line += "0\t";
                    }
                }
                for(int i = 0; i<power_checkedListBox_em.Items.Count; i++) 
                {
                    if(power_checkedListBox_em.GetItemChecked(i))
                    {
                        power_line += "1\t";
                    }
                    else
                    {
                        power_line += "0\t";
                    }
                }
                for(int i = 0; i<power_checkedListBox_prt.Items.Count; i++) 
                {
                
                    if(power_checkedListBox_prt.GetItemChecked(i))
                    {
                        power_line += "1\t";
                    }
                    else
                    {
                        power_line += "0\t";
                    }
                }

                for(int i = 0;i<power_checkedListBox_ac.Items.Count;i++)
                {
                    if(power_checkedListBox_ac.GetItemChecked(i))
                    {
                        power_line += "1\t";
                    }
                    else
                    {
                        power_line += "0\t";
                    }
                }

                for(int i = 0; i<power_checkedListBox_cpy.Items.Count;i++)
                {
                    if(power_checkedListBox_cpy.GetItemChecked(i))
                    {
                        power_line += "1\t";
                    }
                }

                Fill_of_text_Box fi = new Fill_of_text_Box();
                List<string> lines = new List<string>();
                lines= fi.txt_read(@"C:\\Erp_main\\Em_info\\권한설정.txt");
                
                foreach(var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if (arr[0]==select_code)
                    {
                        lines.Remove(line);
                        break;
                    }
                }
                lines.Add(power_line);
                StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Em_info\\권한설정.txt");
                foreach(var i in lines)
                {
                    sw.WriteLine(i);
                }
                sw.Close();
                sw.Dispose();

            }
            catch (Exception ex)
            {
             
            }
        }

        
        private void employee_number_SelectedIndexChanged(object sender, EventArgs e)                             // 사번 조회
        {

        }
        private void panel4_Paint(object sender, PaintEventArgs e)                  // 권한부여 판넬
        {

        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e) //구분 /combobox2의 리스트를 변경해라
        {
            comboBox2.Items.Clear();

            if(comboBox1.SelectedItem.ToString() == "전체")
            {
                dataGridView3.Rows.Clear();
                List<string> list = new List<string>();
                Person_info pi = new Person_info();
                list = pi.search_em();
                foreach (var i in list)
                {
                    string[] arr = i.Split('\t');        
                    string[] grid = { arr[1], arr[0] };
                    dataGridView3.Rows.Add(grid);
                    
                }

            }
            else if(comboBox1.SelectedItem.ToString() == "부서")
            {
                combo_box_list(2);
            }
            else if(comboBox1.SelectedItem.ToString() == "직급")
            {
                combo_box_list(3);
            }
            else if(comboBox1.SelectedItem.ToString() == "사번")
            {
                combo_box_list(1);
            }
        }

        private void combo_box_list(int num)
        {
            List<string> list = new List<string>();
            List<string> names = new List<string>();
            List<string> singles = new List<string>();
            Person_info pi = new Person_info();
            list = pi.search_em();

            foreach(var i in list)
            {
                string[] arr = i.Split('\t');

                names.Add(arr[num]);
            }

            singles = names.Distinct().ToList();

            foreach(var single in singles)
            {
                comboBox2.Items.Add(single);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            List<string> list = new List<string>();
            Person_info pi = new Person_info();
            list = pi.search_em();


            foreach(var i in list)
            {
                string[] arr = i.Split('\t');
                
                if(i.Contains(comboBox2.SelectedItem.ToString()))
                {
                    string[] grid = { arr[1], arr[0] };
                    dataGridView3.Rows.Add(grid);
                }
            }


        }







        private void checkBox_master_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_master.Checked == true)
            {
                all_true_check(power_checkedListBox_master);
            }
            else if(checkBox_master.Checked==false)
            {
                all_false_check(power_checkedListBox_master);
            }
        }
        private void checkBox_em_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_em.Checked == true)
            {
                all_true_check(power_checkedListBox_em);
            }
            else if(checkBox_em.Checked == false)
            {
                all_false_check(power_checkedListBox_em);
            }
        }

        private void checkBox_prt_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_prt.Checked == true)
            {
                all_true_check(power_checkedListBox_prt);
            }
            else if(checkBox_prt.Checked == false)
            {
                all_false_check(power_checkedListBox_prt);
            }
        }
        private void checkBox_ac_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_ac.Checked == true)
            {
                all_true_check(power_checkedListBox_ac);
            }
            else if(checkBox_ac.Checked == false)
            {
                all_false_check(power_checkedListBox_ac);
            }
        }
        private void checkBox_cpy_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_cpy.Checked == true)
            {
                all_true_check(power_checkedListBox_cpy);
            }
            else if(checkBox_cpy.Checked == false)
            {
                all_false_check(power_checkedListBox_cpy);
            }
        }

        private void all_true_check(CheckedListBox cb)
        {
            for(int i = 0;  i<cb.Items.Count; i++) 
            {
            
                cb.SetItemCheckState(i,CheckState.Checked);
            }
        }
        private void all_false_check(CheckedListBox cb)
        {
            for(int i = 0; i <cb.Items.Count;i++)
            {
                cb.SetItemCheckState(i, CheckState.Unchecked);
            }
        }


        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var select = dataGridView3.SelectedRows[0].Cells[0].Value.ToString(); //사번

                List<string> lines = new List<string>();
                Fill_of_text_Box fi = new Fill_of_text_Box();
                lines = fi.txt_read(@"C:\\Erp_main\\Em_info\\권한설정.txt");
                //사번,관리자,사원조회,신규등록,퇴사,급여관리,출퇴근관리,휴가,출장,부서변경,//진행현황,예약  ,변경/수정,사후관리,마감기록,//매출,손익분석//,거래처조회,신규등록
                //0     1       2       3       4         5     6          7   8     9       //  10     11       12      13         14    //   15     16    //   17       18
                //Master_code	1	1	1	1	1	1	1	1	1 //   1   1  1  1   1	// 1   1   //1   1
                //  사번        1   2   3   4   5   6   7   8   9 //  10  11  12  13 14  //15  16  //17  18
                //사번    0   1   0   0   1   1   1   1   0   1   1   0   1   1   0   0   1   0

                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');
                    string[] master = { arr[1] };
                    string[] em = new string[8];
                    string[] prt = new string[5];
                    string[] ac = { arr[15], arr[16] };
                    string[] cpy = { arr[17], arr[18] };

                    for (int i = 0; i < em.Length; i++)
                    {
                        em[i] = arr[i + 2];
                    }
                    for (int i = 0; i < prt.Length; i++)
                    {
                        prt[i] = arr[i + 10];
                    }
                    if (arr[0] == select)
                    {
                        //해당사람의 권한을 가져와 선택상태로 만든다

                        power_check(power_checkedListBox_master, master);
                        power_check(power_checkedListBox_em, em);
                        power_check(power_checkedListBox_prt, prt);
                        power_check(power_checkedListBox_ac, ac);
                        power_check(power_checkedListBox_cpy, cpy);


                        //1 환경설정
                        //2~9 인사
                        //10~14 외주
                        //15,16 회계
                        //17,18 거래처

                    }
                }
            }
            catch
            {

            }

        }



        private void power_check(CheckedListBox cb, string[]arr)
        {

            for(int i = 0; i < cb.Items.Count;i++)
            {
                if (arr[i]=="1")
                {
                    cb.SetItemCheckState(i, CheckState.Checked);
                }
                else if (arr[i]=="0")
                {
                    cb.SetItemCheckState(i, CheckState.Unchecked);
                }
            }



        }

        private void set_rank_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            set_money_gridview.Rows.Clear();
            string rank = set_rank_combo.SelectedItem.ToString();

            List<string> moneys = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            moneys = fi.txt_read(@"C:\\Erp_main\\Em_info\\기본급설정.txt");


            foreach(var money in moneys)
            {
                string[] arr = money.Split('\t');
                if(arr[0]==rank)
                {
                    now_default_money_label.Text = arr[1];
                }
            }


            


            List<string> lines = new List<string>();
            Person_info pi = new Person_info();
            lines = pi.search_em();

            foreach(var line in lines)
            {
                string[] arr = line.Split('\t');
                if (arr[3]==rank)
                {
                    //사번 이름 부서 직급
                    string[] names = { arr[1], arr[0], arr[2], arr[3] };
                    set_money_gridview.Rows.Add(names);
                }
            
            
            }






        }

        private void set_default_money_save_btn_Click(object sender, EventArgs e)
        {
            //직급별 기본급 변경 및 저장
            List<string> lines = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Em_info\\기본급설정.txt");
            string rank = set_rank_combo.SelectedItem.ToString();


            string result = rank +"\t"+set_money_text_box.Text;

            foreach(var line in lines)
            {
                string[] arr = line.Split('\t');
                if(rank == arr[0])
                {
                    lines.Remove(line);
                    break;
                }
            }
            lines.Add(result);
            StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Em_info\\기본급설정.txt");
            foreach(var i in lines)
            {
                sw.WriteLine(i);
            }
            sw.Close();
            sw.Dispose();

            set_money_OK_panel.Visible = true;



        }

        private void cal_btn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");

        }

        private void set_money_text_box_TextChanged(object sender, EventArgs e)
        {

            string txt = set_money_text_box.Text;


            foreach(var t in txt)
            {
                if (Char.IsDigit(t) == false)
                {
                    set_money_text_box.Text = "";
                    input_info_label.Text = "숫자만 입력하세요";
                    input_info_label.Visible = true;
                }
                else
                {
                    input_info_label.Visible=false;
                }
            }





        }

        private void set_money_OK_btn_Click(object sender, EventArgs e)
        {
            set_money_OK_panel.Visible = false;
        }
    }



   






   



}