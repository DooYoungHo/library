using Example;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace WindowsFormsApp2
{

    public partial class Form2 : Form
    {


        public delegate void logform();
        public event logform loginform;


        Timer em2_timer = new Timer();
        Timer notice_timer = new Timer();
        Timer approval_check = new Timer();

        panel_slide_timer pt = new panel_slide_timer();
        

        public Form2()
        {
            InitializeComponent();
            today_text_box.Text = DateTime.Now.ToString();



            if (Form1.user_emcode.Contains("개발") || Form1.user_emcode.Contains("Master")) //개발
            {
                timer2.Start();
            }
            else if (Form1.user_emcode.Contains("인사")) //인사
            {
                timer1.Start();
            }
            else if (Form1.user_emcode.Contains("회계")) //회계
            {
                timer3.Start();
            }
            notice_timer_set();
            copytimerset();
            aplarm_panel_timer_set();
            approval_timer_set();
        }

        private const int main_panel_size_width = 278;
        private const int main_panel_size_height = 184;
        private const int slide_speed = 80; //100
        private const int max_width = 380;
        private const int max_height = 737;
        //카테고리별 위치정보
        // 0,0
        // 0,184
        // 0,368
        // 0,552
        private bool check = true;
        private bool p1_check = true;
        private bool p2_check = true;
        private bool p3_check = true;
        private bool p4_check = true;
        private bool check1 = true;
        private bool check2 = true;
        private bool check3 = true;
        private bool check4 = true;


        private static List<string> text_list = new List<string>();


        public static string[] em_all_info;
        private string user_code_number;








        List<string> accounts_list = new List<string>();
        List<string> sales_list = new List<string>();
        List<string> sales2_list = new List<string>();

        // List<string> sales_list2 = new List<string>();

        private string n1;      // 회계 - 손익 계산식 변수
        private string n2;      // 회계 - 손익 계산식 변수
        private string n3;      // 회계 - 손익 계산식 변수
        private string n4;      // 회계 - 손익 계산식 변수
        private string total;      // 회계 - 손익 계산식 변수
        private int profit3;      // 회계 - 손익 계산식 변수
        private int profit5;      // 회계 - 손익 계산식 변수
        private double profit_sum = 0;    // 손익계산 이익 합계

        //-----------------------------------------------------------------------------
        private double sales_sum = 0;       // 회계 - 매출 계산식 변수
        private string total2;       // 회계 - 매출 계산식 변수





        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Start();
            def_set(main_em_panel1);
            def_all_sub_panels();
        }
        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {

            timer2.Start();
            def_set(main_prt_panel2);
            def_all_sub_panels();

        }
        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {

            timer3.Start();
            def_set(main_ac_panel3);
            def_all_sub_panels();

        }
        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            timer4.Start();
            def_set(main_cpy_panel4);
            def_all_sub_panels();


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check1 == true)//꺼내서 열기
            {
                em_btn1.Visible = true;
                if (p1_check == true) //오른쪽으로 밀고
                {
                    main_em_panel1.Left += slide_speed;
                    if (main_em_panel1.Left >= main_em_panel1.Width)
                    {
                        main_em_panel1.Left = main_em_panel1.Width;
                        main_em_panel1.Width = max_width;
                        p1_check = false;
                    }
                }
                else if (p1_check == false) //아래로 펼친다
                {
                    main_em_panel1.Height += slide_speed;
                    if (main_em_panel1.Height >= max_height)
                    {
                        main_em_panel1.Height = max_height;
                        check1 = false;
                        p1_check = true;
                        timer1.Stop();
                    }
                }
            }
            else if (check1 == false)//닫기
            {
                
                if (p1_check == true) //접어올리고
                {
                    main_em_panel1.Height -= slide_speed;
                    if (main_em_panel1.Height <= main_panel_size_height)
                    {
                        main_em_panel1.Height = main_panel_size_height;
                        p1_check = false;
                    }
                }
                else
                {
                    em_btn1.Visible = false;
                    main_em_panel1.Left -= slide_speed; //안으로 넣기
                    if (main_em_panel1.Left <= 0)
                    {
                        main_em_panel1.Left = 0;
                        main_em_panel1.Width = main_panel_size_width;
                        check1 = true;
                        p1_check = true;
                        timer1.Stop();
                    }
                }
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if (check2 == true) //꺼내서 열기
            {
                prt_btn1.Visible = true;
                prt_btn2.Visible = true;
                if (p2_check == true)
                {
                    main_prt_panel2.Left += slide_speed;
                    if (main_prt_panel2.Left >= main_prt_panel2.Width)
                    {
                        main_prt_panel2.Left = main_prt_panel2.Width;
                        main_prt_panel2.Width = max_width;
                        p2_check = false;
                    }
                }
                else
                {
                    main_prt_panel2.Top -= slide_speed;
                    if (main_prt_panel2.Top <= 0)
                    {
                        main_prt_panel2.Top = 0;
                        main_prt_panel2.Height += slide_speed;

                        if (main_prt_panel2.Height >= max_height)
                        {
                            main_prt_panel2.Height = max_height;
                            check2 = false;
                            p2_check = true;
                            timer2.Stop();
                        }

                    }
                }
            }
            else
            {
                if (p2_check == true)
                {
                    main_prt_panel2.Height -= slide_speed;


                    if (main_prt_panel2.Height <= main_panel_size_height * 2)
                    {
                        main_prt_panel2.Top += slide_speed;
                        if (main_prt_panel2.Top >= main_panel_size_height)
                        {
                            main_prt_panel2.Top = main_panel_size_height;
                            p2_check = false;
                        }

                    }
                }
                else
                {
                    main_prt_panel2.Left -= slide_speed;
                    if (main_prt_panel2.Left <= 0)
                    {
                        prt_btn2.Visible = false;
                        prt_btn1.Visible = false;
                        main_prt_panel2.Left = 0;
                        main_prt_panel2.Width = main_panel_size_width;
                        main_prt_panel2.Height = main_panel_size_height;
                        check2 = true;
                        p2_check = true;
                        
                        timer2.Stop();

                    }
                }
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (check3)
            {
                if (p3_check)
                {
                    ac_sales_btn.Visible = true;
                    main_ac_panel3.Left += slide_speed;
                    if (main_ac_panel3.Left >= main_ac_panel3.Width)
                    {
                        main_ac_panel3.Left = main_ac_panel3.Width;
                        main_ac_panel3.Width = max_width;
                        p3_check = false;
                    }
                }
                else
                {
                    main_ac_panel3.Top -= slide_speed;
                    if (main_ac_panel3.Top <= 0)
                    {
                        main_ac_panel3.Top = 0;
                        main_ac_panel3.Height += slide_speed;
                        if (main_ac_panel3.Height >= max_height)
                        {
                            main_ac_panel3.Height = max_height;
                            check3 = false;
                            p3_check = true;
                            timer3.Stop();
                        }
                    }

                }

            }
            else
            {
                if (p3_check == true)
                {
                    main_ac_panel3.Top += slide_speed;

                    if (main_ac_panel3.Top >= main_panel_size_height * 2)
                    {
                        main_ac_panel3.Top = main_panel_size_height * 2;
                        main_ac_panel3.Height = main_panel_size_height;
                        p3_check = false;
                    }
                }
                else
                {
                    ac_sales_btn.Visible = false;
                    main_ac_panel3.Left -= slide_speed;
                    if (main_ac_panel3.Left <= 0)
                    {
                        main_ac_panel3.Left = 0;
                        main_ac_panel3.Width = main_panel_size_width;

                        check3 = true;
                        p3_check = true;
                        timer3.Stop();

                    }
                }
            }
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (check4)
            {
                if (p4_check)
                {
                    main_cpy_search_btn.Visible=true;
                    main_cpy_panel4.Left += slide_speed;
                    if (main_cpy_panel4.Left >= main_cpy_panel4.Width)
                    {
                        main_cpy_panel4.Left = main_cpy_panel4.Width;
                        main_cpy_panel4.Width = max_width;
                        p4_check = false;
                    }
                }
                else
                {
                    main_cpy_panel4.Top -= slide_speed;
                    main_cpy_panel4.Height += slide_speed;
                    if (main_cpy_panel4.Top <= 0)
                    {
                        main_cpy_panel4.Top = 0;
                        if (main_cpy_panel4.Height >= max_height)
                        {
                            main_cpy_panel4.Height = max_height;
                            check4 = false;
                            p4_check = true;
                            timer4.Stop();
                        }
                    }
                }
            }
            else
            {
                if (p4_check == true)
                {
                    main_cpy_panel4.Top += slide_speed;

                    if (main_cpy_panel4.Top >= main_panel_size_height * 3)
                    {
                        main_cpy_panel4.Top = main_panel_size_height * 3;
                        main_cpy_panel4.Height = main_panel_size_height;
                        p4_check = false;
                    }
                }
                else
                {
                    main_cpy_search_btn.Visible = false;
                    main_cpy_panel4.Left -= slide_speed;
                    if (main_cpy_panel4.Left <= 0)
                    {
                        main_cpy_panel4.Left = 0;
                        main_cpy_panel4.Width = main_panel_size_width;
                        check4 = true;
                        p4_check = true;
                        timer4.Stop();

                    }
                }
            }
        }

        // 0,0
        // 0,184
        // 0,368
        // 0,552


        private void main_tema_default_set(Control panel, int locationTop) //열린패널닫기
        {
            if (panel.Left != 0) //펼쳐진 상태라면 
            {   //원래자리로 돌아가라
                panel.Left = 0;
                panel.Top = locationTop;
                panel.Height = main_panel_size_height;
                panel.Width = main_panel_size_width;


                if (panel == main_em_panel1)
                {
                    check1 = true; //다시 펼칠 수 있게 변경
                    em_btn1.Visible = false;
                }
                else if (panel == main_prt_panel2)
                {
                    check2 = true;
                    prt_btn2.Visible = false;
                    prt_btn1.Visible = false;
                }
                else if (panel == main_ac_panel3)
                {
                    check3 = true;
                    ac_sales_btn.Visible = false;
                }
                else if (panel == main_cpy_panel4)
                {
                    check4 = true;
                    main_cpy_search_btn.Visible = false;
                }
                def_all_sub_panels();
            }
        }
        private void def_set(Control panel) //열린상태를 제외하고 닫을 패널 찾기
        {

            if (panel == main_em_panel1)
            {
                main_tema_default_set(main_prt_panel2, 184);
                main_tema_default_set(main_ac_panel3, 368);
                main_tema_default_set(main_cpy_panel4, 552);
            }
            else if (panel == main_prt_panel2)
            {
                main_tema_default_set(main_em_panel1, 0);
                main_tema_default_set(main_ac_panel3, 368);
                main_tema_default_set(main_cpy_panel4, 552);
            }
            else if (panel == main_ac_panel3)
            {
                main_tema_default_set(main_em_panel1, 0);
                main_tema_default_set(main_prt_panel2, 184);
                main_tema_default_set(main_cpy_panel4, 552);
            }
            else if (panel == main_cpy_panel4)
            {
                main_tema_default_set(main_em_panel1, 0);
                main_tema_default_set(main_prt_panel2, 184);
                main_tema_default_set(main_ac_panel3, 368);
            }
        }
        private void button3_Click(object sender, EventArgs e) //폼닫기 버튼
        {
            loginform(); //로그인창 visible =true;
            this.Close();
            
        }


        public void timer_set(EventHandler e) //생성한 타이머 객체 설정
        {
            em2_timer.Dispose();
            em2_timer.Interval = 1;
            em2_timer.Tick += e;
            em2_timer.Start();
        }



        private void label10_MouseClick(object sender, MouseEventArgs e) //인사-사원관리
        {
            move_control_sub_panel(em_btn1);
            timer_set(em1_timer_Tick);
        }



        private void em1_timer_Tick(object sender, EventArgs e)
        {

            if (check)
            {
                if (pt.time_interval_open(em_btn1, em_panel1, slide_speed))
                {
                    check = false;
                    em2_timer.Stop();
                    em2_timer.Tick -= em1_timer_Tick;
                }
            }
            else
            {
                if (pt.panel_close(em_btn1, em_panel1, slide_speed))
                {
                    check = true;
                    em2_timer.Stop();
                    em2_timer.Tick -= em1_timer_Tick;
                }
            }





        }
        private void label12_MouseClick(object sender, MouseEventArgs e) //인사-근태관리
        {
            move_control_sub_panel(em_btn2);
            timer_set(em2_timer_Tick);
        }
        private void em2_timer_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                if (pt.time_interval_open(em_btn2, em_panel2, slide_speed))
                {
                    check = false;
                    em2_timer.Stop();
                    em2_timer.Tick -= em2_timer_Tick;
                }
            }
            else
            {
                if (pt.panel_close(em_btn2, em_panel2, slide_speed))
                {
                    check = true;
                    em2_timer.Stop();
                    em2_timer.Tick -= em2_timer_Tick;
                }
            }
        }

        private void label11_MouseClick(object sender, MouseEventArgs e) //부서관리
        {
            move_control_sub_panel(em_btn3);
            timer_set(em3_timer_Tick);
        }
        private void em3_timer_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                if (pt.time_interval_open(em_btn3, em_panel3, slide_speed))
                {
                    check = false;
                    em2_timer.Stop();
                    em2_timer.Tick -= em3_timer_Tick;
                }
            }
            else
            {
                if (pt.panel_close(em_btn3, em_panel3, slide_speed))
                {
                    check = true;
                    em2_timer.Stop();
                    em2_timer.Tick -= em3_timer_Tick;
                }
            }
        }


        private void def_sub_set(Control sp, Control ssp) // sp = main_panel안에 있는 작은 패널, ssp = 더 작은 패널
        {
            if (ssp.Height != 0) //펼쳐져 있다면
            {
                ssp.Height = 0;
                sp.Left = 15;
                check = true;
            }
        }

        private void def_all_sub_panels()
        {
            def_em_sub_panels();
            def_prt_sub_panels();

        }


        private void def_em_sub_panels()
        {
            def_sub_set(em_btn1, em_panel1);
            def_sub_set(em_btn2, em_panel2);
            def_sub_set(em_btn3, em_panel3);
        }
        private void def_prt_sub_panels()
        {
            def_sub_set(prt_btn1, prt_panel1);
            def_sub_set(prt_btn2, prt_panel2);
            def_sub_set(prt_btn3, prt_panel3);
            def_sub_set(prt_btn4, prt_panel4);
            def_sub_set(prt_btn5, prt_panel5);

        }

        private void move_control_sub_panel(Control sp)
        {
            if (sp == em_btn1)
            {
                def_sub_set(em_btn2, em_panel2);
                def_sub_set(em_btn3, em_panel3);
            }
            else if (sp == em_btn2)
            {
                def_sub_set(em_btn1, em_panel1);
                def_sub_set(em_btn3, em_panel3);
            }
            else if (sp == em_btn3)
            {
                def_sub_set(em_btn1, em_panel1);
                def_sub_set(em_btn2, em_panel2);
            }
            else if (sp == prt_btn1)
            {
                def_sub_set(prt_btn2, prt_panel2);
                def_sub_set(prt_btn3, prt_panel3);
                def_sub_set(prt_btn4, prt_panel4);
                def_sub_set(prt_btn5, prt_panel5);
            }
            else if (sp == prt_btn2)
            {
                def_sub_set(prt_btn1, prt_panel1);
                def_sub_set(prt_btn3, prt_panel3);
                def_sub_set(prt_btn4, prt_panel4);
                def_sub_set(prt_btn5, prt_panel5);
            }
            else if (sp == prt_btn3)
            {
                def_sub_set(prt_btn2, prt_panel2);
                def_sub_set(prt_btn1, prt_panel1);
                def_sub_set(prt_btn4, prt_panel4);
                def_sub_set(prt_btn5, prt_panel5);
            }
            else if (sp == prt_btn4)
            {
                def_sub_set(prt_btn2, prt_panel2);
                def_sub_set(prt_btn3, prt_panel3);
                def_sub_set(prt_btn1, prt_panel1);
                def_sub_set(prt_btn5, prt_panel5);
            }
            else if (sp == prt_btn5)
            {
                def_sub_set(prt_btn2, prt_panel2);
                def_sub_set(prt_btn3, prt_panel3);
                def_sub_set(prt_btn4, prt_panel4);
                def_sub_set(prt_btn1, prt_panel1);
            }
        }

        private void prt_btn1_MouseClick(object sender, MouseEventArgs e)
        {
            move_control_sub_panel(prt_btn1);
            timer_set(prt1_timer_Tick);
        }

        private void prt1_timer_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                if (pt.time_interval_open(prt_btn1, prt_panel1, slide_speed))
                {
                    check = false;
                    em2_timer.Stop();
                    em2_timer.Tick -= prt1_timer_Tick;
                }
            }
            else
            {
                if (pt.panel_close(prt_btn1, prt_panel1, slide_speed))
                {
                    check = true;
                    em2_timer.Stop();
                    em2_timer.Tick -= prt1_timer_Tick;
                }
            }
        }

        private void prt_btn2_Click(object sender, EventArgs e)
        {
            move_control_sub_panel(prt_btn2);
            timer_set(prt2_timer_Tick);
        }

        private void prt2_timer_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                if (pt.time_interval_open(prt_btn2, prt_panel2, slide_speed))
                {
                    check = false;
                    em2_timer.Stop();
                    em2_timer.Tick -= prt2_timer_Tick;
                }
            }
            else
            {
                if (pt.panel_close(prt_btn2, prt_panel2, slide_speed))
                {
                    check = true;
                    em2_timer.Stop();
                    em2_timer.Tick -= prt2_timer_Tick;
                }
            }
        }

        private void prt_btn3_Click(object sender, EventArgs e)
        {
            move_control_sub_panel(prt_btn3);
            timer_set(prt3_timer_Tick);
        }
        private void prt3_timer_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                if (pt.time_interval_open(prt_btn3, prt_panel3, slide_speed))
                {
                    check = false;
                    em2_timer.Stop();
                    em2_timer.Tick -= prt3_timer_Tick;
                }
            }
            else
            {
                if (pt.panel_close(prt_btn3, prt_panel3, slide_speed))
                {
                    check = true;
                    em2_timer.Stop();
                    em2_timer.Tick -= prt3_timer_Tick;
                }
            }
        }

        private void prt_btn4_Click(object sender, EventArgs e)
        {
            move_control_sub_panel(prt_btn4);
            timer_set(prt4_timer_Tick);
        }
        private void prt4_timer_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                if (pt.time_interval_open(prt_btn4, prt_panel4, slide_speed))
                {
                    check = false;
                    em2_timer.Stop();
                    em2_timer.Tick -= prt4_timer_Tick;
                }
            }
            else
            {
                if (pt.panel_close(prt_btn4, prt_panel4, slide_speed))
                {
                    check = true;
                    em2_timer.Stop();
                    em2_timer.Tick -= prt4_timer_Tick;
                }
            }

        }
        private void prt_btn5_Click(object sender, EventArgs e)
        {
            move_control_sub_panel(prt_btn5);
            timer_set(prt5_timer_Tick);
        }

        private void prt5_timer_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                if (pt.time_interval_open(prt_btn5, prt_panel5, slide_speed))
                {
                    check = false;
                    em2_timer.Stop();
                    em2_timer.Tick -= prt5_timer_Tick;
                }
            }
            else
            {
                if (pt.panel_close(prt_btn5, prt_panel5, slide_speed))
                {
                    check = true;
                    em2_timer.Stop();
                    em2_timer.Tick -= prt5_timer_Tick;
                }
            }
        }

        private void today_text_box_TextChanged(object sender, EventArgs e)
        {
            today_text_box.Text = DateTime.Now.ToString();
        }
        private void label7_Click(object sender, EventArgs e)
        {
            today_text_box.Text = DateTime.Now.ToString();
        }
        private void Memo_box_TextChanged(object sender, EventArgs e)
        {
            if (text_check == false)
            {
                Fill_of_text_Box text = new Fill_of_text_Box();
                text.txt_write(@"C:\\Erp_main\\Em_info\\" + user_code_number + @"\\" + user_code_number + "_memo.txt", Memo_box.Text);
            }
        }
        private bool text_check = true;
        private void Form2_Load(object sender, EventArgs e)
        {

            


            Fill_of_text_Box em_info = new Fill_of_text_Box();
            em_all_info = em_info.em_info_fill();
            //로그인한 유저의 정보
            main_name_text_box.Text = em_all_info[0];
            main_em_code_text_box.Text = em_all_info[1];

            user_code_number = em_all_info[1];

            main_dp_text_box.Text = em_all_info[2];
            main_rank_text_box.Text = em_all_info[3];
            main_year_cnt_text_box.Text = em_all_info[4];
            try
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(@"C:\\Erp_main\\Em_info\\" + em_all_info[1] + @"\\" + em_all_info[1] + "사진.jpg");
            }
            catch
            {
                pictureBox1.Image = Properties.Resources.error_profile;
                pictureBox1.ErrorImage = Properties.Resources.error_profile;
            }
            
            if (text_check)
            {
                Fill_of_text_Box memo = new Fill_of_text_Box();
                memo.text_fill(@"C:\\Erp_main\\Em_info\\" + em_all_info[1] + @"\\" + em_all_info[1] + "_memo.txt", Memo_box);
                text_check = false;
            }


            StreamReader sr = new StreamReader(@"C:\\Erp_main\\Company_info\\사내공지.txt");
            string notice = sr.ReadLine();
            sr.Close();
            sr.Dispose();
            if(notice == "" || notice == "\n" || notice == null)
            {
                main_notice_label.Text = "사내공지입니다.";
            }
            else
            {

                main_notice_label.Text = notice;
            }
            main_grid_approval_info();




        }
        
        private void notice_timer_set()
        {

            notice_timer.Dispose();

            notice_timer.Interval = 10;
            notice_timer.Tick += notice_timer_Tick;
            notice_timer.Start();
        }
        private void notice_timer_Tick(object sender, EventArgs e)
        {

            main_notice_label.Left -= 1;
            if (main_notice_label.Left <= -50)
            {
                main_notice_label.Left = 488;
            }
        }



        private void notice_text_change(string text)
        {
            main_notice_label.Text = text;
        }

        private void main_name_text_box_TextChanged(object sender, EventArgs e)
        {

        }
        private void em_btn1_Click(object sender, EventArgs e)
        {

            move_control_sub_panel(em_btn1);
            timer_set(em1_timer_Tick);
        }
        private void home_btn_Click(object sender, EventArgs e)
        {
            //main_home_panel.BringToFront();

            sub_main_panel.Visible = false;
            sub_main_panel.Top = -5000;
            sub_main_panel.Left = -5000;
            this.Size = new Size(1270,730);
        }

        private void Sub_main_panel_call()
        {
            main_ap_dataGridView.SendToBack();
            this.Size = new Size(1200, 630);
            sub_main_panel.Visible = true;
            sub_main_panel.Top = 0;
            sub_main_panel.Left = 0;
            
            
        }




        private void em_sub_panel()
        {

            no_power_panel.Visible = false; //권한 없음 패널


            em_submain_panel.Visible = false; //인사 서브 패널
            //--------------------------------------------------------사원관리
            em_search_panel.Visible = false; //조회
            em_sub_newperson_panel.Visible = false; //등록
            em_del_panel.Visible = false; //퇴사
            del_em_cfm.Visible = false; //퇴사 확인패널
            //-----------------------------------------------------근태관리
            em_ctmanage_panel.Visible = false; //근태관리 패널
            em_ct_1.Visible = false; //출퇴근조회
            em_ct_2.Visible = false; //급여관리
            em_vacation_panel.Visible = false; //휴가
            business_trip_panel.Visible = false;//출장 조회

            em_dp_change_panel.Visible = false; //부서변경
        }
        private void prt_sub_panel() //프로젝트 
        {
            //프로젝트 패널
            prt_sub_main_panel.Visible = false; //프로젝트 

            prt_reservation_panel.Visible = false;  // 예약
            prt_ing_panel.Visible = false;          //진행중인 프로젝트
            prt_end_log_panel.Visible = false;      //마감기록
            prt_change_panel.Visible = false;       //프로젝트 변경 및 수정

            prt_as_sub_panel.Visible = false;       //프로젝트 사후관리
            prt_as_update_panel.Visible = false;        //사후관리 - 접수등록
            prt_as_ing_panel.Visible = false;           //사후관리 - 미처리현황
            prt_as_after_panel.Visible = false;         //사후관리 - 월간 처리현황

        }

        private void ac_sub_panel_frame() //회계패널
        {
            ac_sub_panel.Visible = false;
            sales_panel.Visible = false;
            ac_profit_and_loss_panel.Visible = false;
        }
        private void cpy_sub_panel()//거래처패널
        {
            cpy_sub_main_panel.Visible = false; //거래처 조회 등록 패널
        }

        private void sub_sub_panel() //서브 내부패널 끄기
        {
            em_sub_panel();
            prt_sub_panel();
            ac_sub_panel_frame();
            cpy_sub_panel();
            
            
        }
        //=================================권한에 관한 인덱스번호

        //0     1      // 2       3       4         5     6          7   8     9       //  10     11       12      13         14    //   15     16    //   17       18
        //Master_code	1//1	1	1	1	1	1	1	1 //   1   1  1  1   1	// 1   1   //1   1
        //  사번        1//      2        3     4       5          6      7   8       9 //      10     11        12        13      14      //15     16          //17        18
        //  사번     ,관리자,사원조회,신규등록,퇴사,급여관리,출퇴근관리,휴가,출장,부서변경,//진행현황,예약  ,변경//수정,사후관리,마감기록,//매출,손익분석//,거래처조회,신규등록
        // =======================================================================================버튼 창 이동=============
        private void new_join_btn_Click(object sender, EventArgs e) //사원조회
        {
            if(power_check(2)==false)
            {
                no_power_panel.Visible = true;
                return;
            }
            label4.Text = "인 사 관 리";
            Sub_main_panel_call(); //불러오고
            sub_sub_panel(); //전부 다 끄고
            em_submain_panel.Visible = true;
            em_search_panel.Visible = true; //조회패널만 킨다  
        }
        private void em_mi_btn1_Click(object sender, EventArgs e)
        {
            label4.Text = "인 사 관 리";
            sub_sub_panel(); //전부 다 끄고
            em_submain_panel.Visible = true;
            if (power_check(2) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            em_search_panel.Visible = true; //조회패널만 킨다
        }
        private void button28_Click(object sender, EventArgs e) //서브패널 상단 조회버튼
        {
            label4.Text = "인 사 관 리";
            if (power_check(2) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            em_submain_panel.Visible = true;
            em_search_panel.Visible = true;

        }
        private void button29_Click(object sender, EventArgs e)//서브패널 상단 신규등록버튼
        {
            label4.Text = "인 사 관 리";
            if (power_check(3) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            em_submain_panel.Visible = true;
            em_sub_newperson_panel.Visible = true;

        }
        private void em_emmanage_new_regist_Click(object sender, EventArgs e) //사원 신규등록
        {
            label4.Text = "인 사 관 리";
            if (power_check(3) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            em_submain_panel.Visible = true;
            em_sub_newperson_panel.Visible = true;
        }
        private void del_em_btn_go_Click(object sender, EventArgs e) //퇴사버튼 클릭
        {
            label4.Text = "인 사 관 리";
            if (power_check(4) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            em_submain_panel.Visible = true;
            em_del_panel.Visible = true;
        }
        private void button31_Click(object sender, EventArgs e) //서브패널 상단 퇴사버튼
        {
            label4.Text = "인 사 관 리";
            if (power_check(4) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            em_submain_panel.Visible = true;
            em_del_panel.Visible = true;
            em_datagridview_show();
        }
        private void em_datagridview_show()
        {
            List<string> list = new List<string>();
            Person_info pi = new Person_info();
            list = pi.search_em();

            
            
            em_del_dataGridView2.Rows.Clear();
            

            foreach (var l in list)
            {
                em_del_dataGridView2.Rows.Add(l.Split('\t'));
            }
        }
        private void em_btn2_Click(object sender, EventArgs e) //근태관리 패널
        {

        }
        private void money_manage_btn_Click(object sender, EventArgs e) //근태-급여관리
        {
            label4.Text = "인 사 관 리";
            Sub_main_panel_call();
            sub_sub_panel();
            em_ctmanage_panel.Visible = true;
            em_ct_2.Visible = true;
        }
        private void ct_info_btn_Click(object sender, EventArgs e) //출퇴근 기록조회
        {
            label4.Text = "인 사 관 리";
            if (power_check(6) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            em_submain_panel.Visible = true;
            em_ctmanage_panel.Visible = true;
            em_ct_1.Visible = true; //출퇴근조회
        }
        private void em_mini_btn2_Click(object sender, EventArgs e) //근태관리패널
        {
            label4.Text = "인 사 관 리";
            Sub_main_panel_call();
            sub_sub_panel();
            em_ctmanage_panel.Visible = true;
            if (power_check(6) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            em_ct_1.Visible = true;//출퇴근조회
            
        }
        private void em_ct1_btn_Click(object sender, EventArgs e)
        {
            label4.Text = "인 사 관 리";
            if (power_check(6) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            em_ctmanage_panel.Visible = true;
            em_ct_1.Visible = true; //출퇴근조회
            
        }
        private void em_ct2_btn_Click(object sender, EventArgs e) //메인 - 사원 - 근태 - 급여관리
        {
            label4.Text = "인 사 관 리";
            if (power_check(5) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            em_ctmanage_panel.Visible = true;
            em_ct_2.Visible = true;
        }
        private void Business_trip_btn_Click(object sender, EventArgs e) //메인 - 사원 - 근태 - 출장
        {
            label4.Text = "인 사 관 리";
            if (power_check(8) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            em_ctmanage_panel.Visible = true;
            business_trip_panel.Visible = true;
        }
        private void em_ct4_btn_Click(object sender, EventArgs e) //서브 - 상단 출장버튼
        {
            label4.Text = "인 사 관 리";
            if (power_check(8) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            em_ctmanage_panel.Visible = true;
            business_trip_panel.Visible = true;

        }
        private void em_vacation_btn_Click(object sender, EventArgs e)
        {
            label4.Text = "인 사 관 리";
            if (power_check(7) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            em_ctmanage_panel.Visible = true;
            em_vacation_panel.Visible = true;
        }
        private void em_ct3_btn_Click(object sender, EventArgs e) //근태 상단 휴가 버튼
        {
            label4.Text = "인 사 관 리";
            if (power_check(7) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            em_ctmanage_panel.Visible = true;
            em_vacation_panel.Visible = true;

        }
        private void em_dp_change_btn_Click(object sender, EventArgs e) //메인 - 부서 변경
        {
            label4.Text = "인 사 관 리";
            if (power_check(9) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            em_dp_change_panel.Visible = true;
            em_dp_change_combo();
        }
        private void em_mini_btn3_Click(object sender, EventArgs e) //좌측 부서 변경
        {
            label4.Text = "인 사 관 리";
            if (power_check(9) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            em_dp_change_combo();
            em_dp_change_panel.Visible = true;
        }
        private void prt_ing_btn_Click(object sender, EventArgs e) //프로젝트 진행현황 버튼
        {
            label4.Text = "외       주";
            if (power_check(10) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();

            prt_sub_main_panel.Visible = true;
            prt_ing_panel.Visible = true;
            prt_ing_grid_show();
        }
        private void prt_mini_btn1_Click(object sender, EventArgs e)
        {
            label4.Text = "외       주";
            if (power_check(10) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            prt_sub_main_panel.Visible = true;
            prt_ing_panel.Visible = true;
            prt_ing_grid_show();
        }
        private void prt_end_log_btn_Click(object sender, EventArgs e) //마감기록 버튼
        {
            label4.Text = "외       주";
            if (power_check(14) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            prt_sub_main_panel.Visible = true;
            prt_end_log_panel.Visible = true;
        }
        private void prt_mini_btn5_Click(object sender, EventArgs e)
        {
            label4.Text = "외       주";
            if (power_check(14) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            prt_sub_main_panel.Visible = true;
            prt_end_log_panel.Visible = true;
        }
        private void prt_change_btn_Click(object sender, EventArgs e) //프로젝트 변경 버튼 클릭
        {
            label4.Text = "외       주";
            if (power_check(12) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            prt_sub_main_panel.Visible = true;
            prt_change_panel.Visible = true;
        }
        private void prt_mini_btn3_Click(object sender, EventArgs e) //프로젝트 서브 좌측 변경및 수정
        {
            label4.Text = "외       주";
            if (power_check(12) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            prt_sub_main_panel.Visible = true;
            prt_change_panel.Visible = true;
        }
        private void prt_as_update_btn_Click(object sender, EventArgs e) //프로젝트 - 메인 사후관리 접수
        {
            label4.Text = "외       주";
            if (power_check(13) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            prt_as_sub_panel.Visible = true;
            prt_as_update_panel.Visible = true;
        }
        private void prt_mini_btn4_Click(object sender, EventArgs e) //프로젝트 서브 좌측 사후관리 접수
        {
            label4.Text = "외       주";
            if (power_check(13) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            prt_as_sub_panel.Visible = true;
            prt_as_update_panel.Visible = true;
        }
        private void prt_as_update_upbtn_Click(object sender, EventArgs e) //프로젝트 -상단 사후관리 접수
        {
            label4.Text = "외       주";
            if (power_check(13) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            prt_as_sub_panel.Visible = true;
            prt_as_update_panel.Visible = true;
        }
        private void prt_as_ing_btn_Click(object sender, EventArgs e) //프로젝트 - 사후관리 - 미처리현황
        {
            label4.Text = "외       주";
            if (power_check(13) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            prt_as_sub_panel.Visible = true;
            prt_as_ing_panel.Visible = true;
        }
        private void prt_as_after_upbtn_Click(object sender, EventArgs e) //사후관리 월간 처리현황
        {
            label4.Text = "외       주";
            if (power_check(13) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            prt_as_sub_panel.Visible = true;
            prt_as_after_panel.Visible = true;
        }

        private void prt_as_after_gobtn_Click(object sender, EventArgs e) //메인 사후관리 - 월간처리현황
        {
            label4.Text = "외       주";
            if (power_check(13) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            prt_as_sub_panel.Visible = true;
            prt_as_after_panel.Visible = true;
        }

        private void prt_as_ing_upbtn_Click(object sender, EventArgs e) //사후관리상단 미처리현황
        {
            label4.Text = "외       주";
            if (power_check(13) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            prt_as_sub_panel.Visible = true;
            prt_as_ing_panel.Visible = true;
        }


        
        //매출
        private void ac_sales_btn_Click(object sender, EventArgs e) //메인 - 매출
        {
            label4.Text = "회       계";
            if (power_check(15) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            ac_sub_panel.Visible = true;
            sales_panel.Visible = true;
            ac_panel_on();

        }
        private void ac_mini_btn1_Click(object sender, EventArgs e) //서브 좌측 매출
        {
            label4.Text = "회       계";
            if (power_check(15) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            ac_sub_panel.Visible = true;
            sales_panel.Visible = true;
            ac_panel_on();
        }
        private void ac_profit_btn_Click(object sender, EventArgs e) //메인 - 손익분석
        {
            label4.Text = "회       계";
            if (power_check(16) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            ac_sub_panel.Visible = true;
            ac_profit_and_loss_panel.Visible = true;
            ac_panel_on();
        }



        private void ac_mini_btn2_Click(object sender, EventArgs e) //서브 좌측 손익분석
        {
            label4.Text = "회       계";
            if (power_check(16) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            ac_sub_panel.Visible = true;
            ac_profit_and_loss_panel.Visible = true;
            ac_panel_on();
        }




        private void main_cpy_search_btn_Click(object sender, EventArgs e) //메인 - 거래처 조회
        {
            
            label4.Text = "거  래   처";
            if (power_check(17) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            cpy_sub_main_panel.Visible = true;
        }
        private void main_cpy_new_btn_Click(object sender, EventArgs e) //메인-거래처등록
        {
            label4.Text = "거  래   처";
            if (power_check(18) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            cpy_sub_main_panel.Visible = true;
        }
        private void cpy_mini_btn1_Click(object sender, EventArgs e)
        {

            sub_sub_panel();
            cpy_sub_main_panel.Visible = true;
        }



        private void prt_reservation_btn_Click(object sender, EventArgs e)
        {

            if (power_check(11) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            prt_sub_main_panel.Visible = true;
            prt_reservation_panel.Visible = true;
            Cpy_names(); //콤보박스에 여태 등록됐던 거래처들 목록 생성
            //prt_cpy_name_combobox.Items.Add()
        }

        private void prt_change_ok_btn_Click(object sender, EventArgs e) //예약패널 다시 출력
        {
            if (power_check(11) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            Sub_main_panel_call();
            sub_sub_panel();
            prt_sub_main_panel.Visible = true;
            prt_reservation_panel.Visible = true;
            Cpy_names(); //콤보박스에 여태 등록됐던 거래처들 목록 생성
        }


        private void prt_mini_btn2_Click(object sender, EventArgs e) //서브-좌측프로젝트 신규예약
        {
                        if (power_check(11) == false)
            {
                no_power_panel.Visible = true;
                return;
            }
            sub_sub_panel();
            Cpy_names();
            prt_sub_main_panel.Visible = true;
            prt_reservation_panel.Visible = true;
        }


        private void Cpy_names()
        {

            prt_cpy_name_combobox.Items.Clear();
            List<string> cpy_names = new List<string>();
            Fill_of_text_Box fb = new Fill_of_text_Box();
            cpy_names = fb.txt_read(@"C:\\Erp_main\\Cpy_info\\거래처목록.txt");
            foreach (var names in cpy_names)
            {
                try
                {
                    prt_cpy_name_combobox.Items.Add(names.Split('\t')[1]);
                }
                catch
                {
                    continue;
                }
                
            }
        }

        private void cpy_new_cre_btn_Click(object sender, EventArgs e) //거래처 - 등록버튼
        {
            new_cpy_create nc = new new_cpy_create();
            nc.Show();
        }







        Timer mini_btn_timer = new Timer();

        private void mini_btn_timer_set(EventHandler e)
        {
            mini_btn_timer.Dispose();
            mini_btn_timer.Interval = 1;
            mini_btn_timer.Tick += e;
            mini_btn_timer.Start();
        }
        private bool mini_check = true;
        private void left_mini_btn_em_Click(object sender, EventArgs e) //좌측 버튼 인사
        {
            mini_panel_def(left_mini_btn_em);
            mini_btn_timer_set(mini_em_Tick);
        }

        private void mini_em_Tick(object sender, EventArgs e)
        {
            if (mini_check)
            {
                if (pt.mini_panel_open_btn(left_mini_btn_em, left_mini_panel_em, slide_speed))
                {
                    mini_check = false;
                    mini_btn_timer.Stop();
                    mini_btn_timer.Tick -= mini_em_Tick;
                }
            }
            else
            {
                if (pt.mini_panel_close_btn(left_mini_btn_em, left_mini_panel_em, slide_speed))
                {
                    mini_check = true;
                    mini_btn_timer.Stop();
                    mini_btn_timer.Tick -= mini_em_Tick;
                }
            }
        }
        private void left_mini_btn_prt_Click(object sender, EventArgs e) //좌측 버튼 외주
        {
            mini_panel_def(left_mini_btn_prt);
            mini_btn_timer_set(mini_prt_Tick);
        }
        private void mini_prt_Tick(object sender, EventArgs e)
        {
            if (mini_check)
            {
                if (pt.mini_panel_open_btn(left_mini_btn_prt, left_mini_panel_prt, slide_speed))
                {
                    mini_check = false;
                    mini_btn_timer.Stop();
                    mini_btn_timer.Tick -= mini_prt_Tick;
                }
            }
            else
            {
                if (pt.mini_panel_close_btn(left_mini_btn_prt, left_mini_panel_prt, slide_speed))
                {
                    mini_check = true;
                    mini_btn_timer.Stop();
                    mini_btn_timer.Tick -= mini_prt_Tick;
                }
            }

        }
        private void left_mini_btn_ac_Click(object sender, EventArgs e)
        {
            mini_panel_def(left_mini_btn_ac);
            mini_btn_timer_set(mini_ac_Tick);
        }
        private void mini_ac_Tick(object sender, EventArgs e)
        {
            if (mini_check)
            {
                if (pt.mini_panel_open_btn(left_mini_btn_ac, left_mini_panel_ac, slide_speed))
                {
                    mini_check = false;
                    mini_btn_timer.Stop();
                    mini_btn_timer.Tick -= mini_ac_Tick;
                }
            }
            else
            {
                if (pt.mini_panel_close_btn(left_mini_btn_ac, left_mini_panel_ac, slide_speed))
                {
                    mini_check = true;
                    mini_btn_timer.Stop();
                    mini_btn_timer.Tick -= mini_ac_Tick;
                }
            }
        }
        private void left_mini_btn_cpy_Click(object sender, EventArgs e)
        {
            mini_panel_def(left_mini_btn_cpy);
            mini_btn_timer_set(mini_cpy_Tick);
        }
        private void mini_cpy_Tick(object sender, EventArgs e)
        {
            if (mini_check)
            {
                if (pt.mini_panel_open_btn(left_mini_btn_cpy, left_mini_panel_cpy, slide_speed))
                {
                    mini_check = false;
                    mini_btn_timer.Stop();
                    mini_btn_timer.Tick -= mini_cpy_Tick;
                }
            }
            else
            {
                if (pt.mini_panel_close_btn(left_mini_btn_cpy, left_mini_panel_cpy, slide_speed))
                {
                    mini_check = true;
                    mini_btn_timer.Stop();
                    mini_btn_timer.Tick -= mini_cpy_Tick;
                }
            }
        }



        private void mini_panel_def(Control btn)
        {
            if (btn == left_mini_btn_em) //클릭이 인사라면
            {
                mini_panel_reset(left_mini_panel_prt); //조건을 만족할때 접어라
                mini_panel_reset(left_mini_panel_ac);
                mini_panel_reset(left_mini_panel_cpy);
            }
            else if (btn == left_mini_btn_prt)
            {
                mini_panel_reset(left_mini_panel_em);
                mini_panel_reset(left_mini_panel_ac);
                mini_panel_reset(left_mini_panel_cpy);
            }
            else if (btn == left_mini_btn_ac)
            {
                mini_panel_reset(left_mini_panel_em);
                mini_panel_reset(left_mini_panel_prt);
                mini_panel_reset(left_mini_panel_cpy);
            }
            else if (btn == left_mini_btn_cpy)
            {
                mini_panel_reset(left_mini_panel_em);
                mini_panel_reset(left_mini_panel_prt);
                mini_panel_reset(left_mini_panel_ac);

            }


        }
        private void mini_panel_reset(Control pn)
        {
            if (pn.Height != 0) //펼쳐져있다면
            {
                pn.Width = 0;
                pn.Height = 0;
                mini_check = true;
            }

        }




        private string img_name;
        private string record_name;
        private void em_record_up_Click(object sender, EventArgs e) //사진 등록버튼
        {
            em_new_img_dialog.ShowDialog();
        }
        private void em_new_img_dialog_FileOk(object sender, CancelEventArgs e)
        {

            em_new_img_text.Text = em_new_img_dialog.FileName.ToString();
            img_name = em_new_img_dialog.SafeFileName;
        }

        private void button36_Click(object sender, EventArgs e) //이력서 양식 등록버튼
        {
            em_new_record_dialog.ShowDialog();
        }
        private void em_new_record_dialog_FileOk(object sender, CancelEventArgs e)
        {
            em_new_record_text.Text = em_new_record_dialog.FileName.ToString();

            record_name = em_new_record_dialog.SafeFileName;
        }


        private void new_em_info_save_btn_Click(object sender, EventArgs e)
        {



            //em_new_name_text.Text = "";//이름     0
            //em_new_em_code_text.Text = "";//사번 1
            //em_new_dp_text.Text = "";//부서      2
            //em_new_rank_text.Text = ""; //직급   3
            //                          1   연차   4
            //em_new_age_text.Text = "";//나이 5
            //em_new_p_number_text.Text = "";//전화번호 6
            //em_new_email_text.Text = ""; //이메일 7
            //개발등급(어느정도수준인제)  8
            //개발능력(몇개가능한지) 9
            //em_new_r_number_text.Text = "";//주민번호 10
            //em_new_adress_text.Text = ""; //주소 11



            //결혼정보 12
            //계약종류13
            //사진14
            //이력서파일15



            //중간의 1은 연차
            //string[] save_info_arr =
            //{
            //        em_new_name_text.Text, //0
            //        em_new_em_code_text.Text, //1
            //        em_new_dp_text.Text, //2 
            //        em_new_rank_text.Text, //3
            //        "1", //4
            //        em_new_age_text.Text, //5
            //        em_new_p_number_text.Text, //6
            //        em_new_email_text.Text, //7
            //        prt_rank.Text, //8
            //        prt_ablilty.Text, //9
            //        em_new_r_number_text.Text,//10
            //        em_new_adress_text.Text, //11
            //        em_new_merry_check_text.Text, //12
            //        em_new_contract_text.Text, //13
            //        "false", //14

            //        em_new_img_text.Text, //사진경로 15
            //        em_new_record_text.Text, //이력서 경로 16
                    
            //    };
            //new_id_pw_create nip = new new_id_pw_create(save_info_arr);
            //nip.Show();


            //위에 날리고 아래 주석 풀면 된다

            if (user_new_info_check()) //양식을 알맞게썼다면
            {
                string[] save_info_arr =
              {
                    em_new_name_text.Text, em_new_em_code_text.Text, em_new_dp_text.Text, em_new_rank_text.Text,"1", em_new_age_text.Text,em_new_p_number_text.Text,
                     em_new_email_text.Text,prt_rank.Text,prt_ablilty.Text,
                    em_new_r_number_text.Text, em_new_adress_text.Text, em_new_merry_check_text.Text,
                    em_new_contract_text.Text,img_name,record_name
                };
                new_id_pw_create nip = new new_id_pw_create(save_info_arr);
                nip.Show();
            }

        } //신규등록
        private bool user_new_info_check() //가입 양식 기입정보 체크
        {

            bool text_info_check = true;
            if (Int32.TryParse(em_new_age_text.Text, out int age) == false) //나이 확인
            {
                MessageBox.Show("나이를 확인해주세요");
                text_info_check = false;
            }
            else //변환성공한경우 > int형 숫자로 이루어짐
            {
                if (age >= 100)
                {
                    MessageBox.Show("나이를 확인해주세요");
                    text_info_check = false;
                }
            }
            if (em_new_email_text.Text.Contains("@") == false || em_new_email_text.Text.Contains(".com") == false) //이메일 양식확인
            {
                MessageBox.Show("이메일 양식을 확인하세요");
                text_info_check = false;
            }
            if (em_new_record_text.Text == null || em_new_record_text.Text == "")
            {
                MessageBox.Show("이력서 양식이 없습니다.");
                text_info_check = false;
            }
            if (em_new_img_text.Text == null || em_new_img_text.Text == "")
            {
                MessageBox.Show("이미지 양식이 없습니다");
                text_info_check = false;
            }
            if (em_new_r_number_text.Text.Length < 14)
            {
                MessageBox.Show("주민번호를 확인해주세요");
                text_info_check = false;
            }

            
            Phone_number_check pc = new Phone_number_check();
            if (pc.p_number_trust_check(em_new_p_number_text.Text))
            {

            }
            else
            {
                MessageBox.Show("전화번호를 다시 확인해주세요");
                text_info_check = false;
            }
            return text_info_check;



        }




        private void em_dp_change_combo() //존재하는 부서
        {
            em_dp_select_combo_box.Items.Clear();
            em_dp_change_result_combo_box.Items.Clear();
            List<string> lines = new List<string>();
            List<string> dp_list= new List<string>();
            Person_info pi = new Person_info();
            lines = pi.search_em();

            foreach(var line in lines)
            {
                string[] arr = line.Split('\t');
                dp_list.Add(arr[2]);
            }
            string[] dp = dp_list.Distinct().ToArray();
            em_dp_select_combo_box.Items.Add("전체");
            foreach(var d in dp)
            {
                em_dp_select_combo_box.Items.Add(d);
                em_dp_change_result_combo_box.Items.Add(d);

            }


        }






        private void main_home_panel_Paint(object sender, PaintEventArgs e)
        {















        }
        private void main_em_panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void main_prt_panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void main_ac_panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void main_cpy_panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        //------------------------------------------------------------------------ 사원조회

        private void name_search_btn1_Click(object sender, EventArgs e)
        {
            //em_search_gridview
            em_search_gridview.Rows.Clear();
            List<string> lines = new List<string>();
            Person_info pi = new Person_info();
            lines = pi.search_em();
            if(em_search_name_text_box != null)
            {
                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if (arr[0].Contains(em_search_name_text_box.Text))
                    {
                        em_search_gridview.Rows.Add(arr);
                    }
                }
            }
            else
            {
                foreach(var li in lines)
                {
                    em_search_gridview.Rows.Add(li.Split('\t'));
                }
            }
            
        }
        private void code_search_btn2_Click(object sender, EventArgs e)
        {
            em_search_gridview.Rows.Clear();
            List<string> lines = new List<string>();
            Person_info pi = new Person_info();
            lines = pi.search_em();
            if (em_search_code_text_box != null)
            {
                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if (arr[1].Contains(em_search_code_text_box.Text))
                    {
                        em_search_gridview.Rows.Add(arr);
                    }
                }
            }
            else
            {
                foreach (var li in lines)
                {
                    em_search_gridview.Rows.Add(li.Split('\t'));
                }
            }



        }
        private void search_dp_btn3_Click(object sender, EventArgs e)
        {
            em_search_gridview.Rows.Clear();
            List<string> lines = new List<string>();
            Person_info pi = new Person_info();
            lines = pi.search_em();
            if (em_search_dp_text_box != null)
            {
                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if (arr[2].Contains(em_search_dp_text_box.Text))
                    {
                        em_search_gridview.Rows.Add(arr);
                    }
                }
            }
            else
            {
                foreach (var li in lines)
                {
                    em_search_gridview.Rows.Add(li.Split('\t'));
                }
            }

        }
        Timer copystate= new Timer();

        private void copytimerset()
        {
            copystate.Interval = 100;
            copystate.Tick += cpystate_Tick;

        }
        private int num = 1;
        private void cpystate_Tick(object sender, EventArgs e)
        {
            num += 1;
            if(num>20)
            {
                num = 0;
                em_search_copy_label.Visible= false;
                copystate.Stop();
            }
        }


        private void em_search_gridview_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.em_search_gridview.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                Clipboard.SetDataObject(this.em_search_gridview.GetClipboardContent());
            }
            copystate.Start();
            em_search_copy_label.Visible = true;
        }



        

        private void cpy_sub_main_panel_Move(object sender, EventArgs e)
        {

        }
        private void button32_Click(object sender, EventArgs e)
        {
            List<string> cpy_list = new List<string>();
            string search = cpy_search_text_box.Text;
            Fill_of_text_Box fb = new Fill_of_text_Box();
            cpy_list = fb.txt_read(@"C:\\Erp_main\\Cpy_info\\거래처목록.txt");

        
            cpy_search_dataGridView1.Rows.Clear();
            
            if (search.Length > 0 || search != null)
            {
                foreach (string line in cpy_list)
                {
                    if (line.Contains(search))
                    {
                        cpy_search_dataGridView1.Rows.Add(line.Split('\t'));
                    }
                }
            }
            else
            {
                foreach (string s in cpy_list)
                {

                    cpy_search_dataGridView1.Rows.Add(s.Split('\t'));

                }
            }




        }
        // ---------------------------------------------------------------------------퇴사
        private void em_search_btn_Click(object sender, EventArgs e)
        {


            string code = del_user_code_text_box.Text;
            string dp = del_user_dp_text_box.Text;
            string name = del_user_name_text_box.Text;
            if (name == "")
            {
                name = @"\\!@#$!@$#%";
            }
            if (code == "")
            {
                code = "%@#$^%$#$!@$%";
            }
            if (dp == "")
            {
                dp = "!@#%!^%&^$#%^$#";
            }

            List<string> list = new List<string>();
            Person_info pi = new Person_info();
            list = pi.search_em();


            for (int i = 0; i < list.Count; i++)
            {
                em_del_dataGridView2.Rows.Clear();
            }




            foreach (var l in list)
            {

                if (l.Contains(name))
                {
                    //del_user_dp_text_box.Text = "이름일치";
                    if (l.Contains(code))
                    {
                        if (l.Contains(dp))
                        {
                            em_del_dataGridView2.Rows.Add(l.Split('\t'));
                            continue;
                        }
                        else
                        {
                            em_del_dataGridView2.Rows.Add(l.Split('\t'));
                        }

                    }
                    else
                    {
                        em_del_dataGridView2.Rows.Add(l.Split('\t'));
                    }

                }
                else if (l.Contains(code))
                {
                    if (l.Contains(dp))
                    {
                        em_del_dataGridView2.Rows.Add(l.Split('\t'));
                        continue;
                    }
                    else
                    {
                        em_del_dataGridView2.Rows.Add(l.Split('\t'));
                    }
                }
                else if (l.Contains(dp))
                {
                    em_del_dataGridView2.Rows.Add(l.Split('\t'));
                    continue;
                }




            }
        }
        private void em_del_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var select = em_del_dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                List<string> lines = new List<string>();
                DateTime now = DateTime.Now;

                Person_info pi = new Person_info();
                lines = pi.search_em();
                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if (arr[1] == select)
                    {
                        em_del_try_name_label.Text = arr[0];
                        em_del_try_code_label.Text = arr[1];
                        em_del_try_dp_label.Text = arr[2];
                        em_del_try_rank_label.Text = arr[3];
                        em_del_try_yc_label.Text = arr[4];
                        em_del_try_today_label.Text = now.ToString("yyyy-MM-dd");
                        break;
                    }
                }

                del_em_cfm.Visible = true;
            }
            catch
            {

            }
            

        }
        private void del_X_btn_Click(object sender, EventArgs e)
        {
            del_em_cfm.Visible = false;
        }
        private void del_ok_btn_Click(object sender, EventArgs e)
        {
            //이름 사번 신청일 부서 직급 연차 사유
            string[] del_arr =
                {   
                    "퇴사",
                    "대기중",
                    em_del_try_name_label.Text,
                    em_del_try_code_label.Text,
                    em_del_try_today_label.Text,
                    em_del_try_dp_label.Text,
                    em_del_try_rank_label.Text,
                    em_del_try_yc_label.Text,
                    em_del_try_reason_text_box.Text,
                };

            string line = "";


            foreach(var del in del_arr)
            {
                line += del + "\t";
            }
            ApprovalCheck ac = new ApprovalCheck();
            if(ac.approval_date("퇴사",em_del_try_code_label.Text, em_del_try_today_label.Text)==false)
            {
                MessageBox.Show("당일중복신청불가");
                return;
            }

            StreamWriter sw = File.AppendText(@"C:\\Erp_main\\Approval_info\\결재상태.txt");

            sw.WriteLine(line);
            sw.Close();
            sw.Dispose();

            //DataGridViewRow row = em_del_dataGridView2.SelectedRows[0];
            //string code = row.Cells[1].Value.ToString(); //사번 추출
            //Person_info pi = new Person_info();
            //List<string> list = new List<string>();
            //list = pi.search_em();
            //foreach (var l in list)
            //{
            //    if (l.Contains(code))
            //    {
            //        list.Remove(l);
            //        break;
            //    }
            //}
            //Person_info pw = new Person_info();
            //pw.write_em_info(list);
            //DirectoryInfo di = new DirectoryInfo(@"C:\\Erp_main\\Em_info\\" + code);
            //di.Delete(true);   // true 넣으면 파일 존재시에도 무조건 삭제

            del_em_cfm.Visible = false;
        }




        private bool em_ctct_check1 = true;
        private bool em_ctct_check2 = true;
        private void em_ct_ct_be_btn_Click(object sender, EventArgs e)
        {
            if (em_ctct_check1)
            {
                em_ct_ct_be_calendar.Visible = true;
                em_ctct_check1 = false;
            }
            else
            {
                em_ct_ct_be_calendar.Visible = false;
                em_ctct_check1 = true;
            }
        }

        private void em_ct_ct_after_btn_Click(object sender, EventArgs e)
        {
            if (em_ctct_check2)
            {
                em_ct_ct_after_calendar.Visible = true;
                em_ctct_check2 = false;
            }
            else
            {
                em_ct_ct_after_calendar.Visible = false;
                em_ctct_check2 = true;
            }
        }

        private void em_ct_ct_be_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            em_ct_ct_before_date_label.Text = em_ct_ct_be_calendar.SelectionStart.ToString();
        }

        private void em_ct_ct_after_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            em_ct_ct_after_label.Text = em_ct_ct_after_calendar.SelectionStart.ToString();
        }





        private void ct_search_btn_Click(object sender, EventArgs e) //출퇴근기록조회 버튼
        {
            List<string> lines = new List<string>();
            List<string> logs = new List<string>();
            Person_info pi = new Person_info();
            lines = pi.login_log();

            Fill_of_text_Box fi = new Fill_of_text_Box();
            logs = fi.txt_read(@"C:\\Erp_main\\Em_info\\출퇴근기록.txt");
            
            
            ct_log_dataGridView2.Rows.Clear();

            //-----------------------------------------------------------------------------------검색에 대한 이야기
            if(em_ct_ct_before_date_label != null &&em_ct_ct_after_label!= null) //기간이 있다면
            {
                DateTime.TryParse(em_ct_ct_before_date_label.Text, out DateTime start);
                DateTime.TryParse(em_ct_ct_after_label.Text, out DateTime end);
                logs.RemoveAt(0);
                foreach (var log in logs)
                {
                    string[] arr = log.Split('\t');
                    

                    
                    if(arr.Length <= 4) //퇴근기록이 없는상황
                    {
                        continue;
                    }
                    else
                    {
                        
                    }
                    string[] line = { arr[0], arr[1], arr[3], arr[4], arr[5] };

                    DateTime.TryParse(arr[3], out DateTime work);

                    if (start <= work && work <= end)
                    {
                        try
                        {
                            if (em_ct_ct_data_combobox.SelectedItem.ToString() == "이름")
                            {

                                if (arr[0].Contains(em_ct_ct_combo_box.SelectedItem.ToString())) //이름이 검색에 있다면
                                {
                                    ct_log_dataGridView2.Rows.Add(line);
                                }
                            }
                            else if (em_ct_ct_data_combobox.SelectedItem.ToString() == "사번")
                            {

                                if (arr[1].Contains(em_ct_ct_combo_box.SelectedItem.ToString()))
                                {
                                    ct_log_dataGridView2.Rows.Add(line);
                                }
                            }
                            else if (em_ct_ct_data_combobox.SelectedItem.ToString() == "부서")
                            {
                                if (arr[2].Contains(em_ct_ct_combo_box.SelectedItem.ToString()))
                                {
                                    ct_log_dataGridView2.Rows.Add(line);
                                }
                            }
                        }
                        catch
                        {
                            ct_log_dataGridView2.Rows.Add(line);
                        }
                    }
                }
            }
            else
            {
                foreach(var lo in logs)
                {
                    string[] arr1 = lo.Split('\t');
                    ct_log_dataGridView2.Rows.Add(arr1);
                   
                }
            }






            
        }














        private bool power_check(int num) //접근권한의 여부
        {
            List<string> lines = new List<string>();
            PowerCheck pc = new PowerCheck();
            lines = pc.read_power();
            //사번,관리자,사원조회,신규등록,퇴사,급여관리,출퇴근관리,휴가,출장,부서변경,//진행현황,예약  ,변경/수정,사후관리,마감기록,//매출,손익분석//,거래처조회,신규등록
            //0     1      // 2       3       4         5     6          7   8     9       //  10     11       12      13         14    //   15     16    //   17       18
            //Master_code	1//1	1	1	1	1	1	1	1 //   1   1  1  1   1	// 1   1   //1   1
            //  사번        1// 2   3   4   5   6   7   8   9 //  10  11  12  13 14  //15  16  //17  18
            foreach (var line in lines)
            {
                string[] arr = line.Split('\t');

                if (arr[0] == em_all_info[1])
                {

                    if (arr[num] == "1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            return false;

        }




        private void button4_Click(object sender, EventArgs e)
        {
            Person_info pi = new Person_info();
            DateTime dt = DateTime.Now;
            pi.Off_work_time(main_em_code_text_box.Text, dt);
        }
        private void em_m_money_re_btn_Click(object sender, EventArgs e) //급여관리-기록확정-새로고침
        {
            em_m_money_grid_view.Rows.Clear();
            int days = lastday(); //이번달의 평일만 있는 날짜(공휴일 미고려)
            List<string> code_list = new List<string>();
            List<string> lines = new List<string>();
            int month = DateTime.Now.Month;
            Person_info pi = new Person_info();
            code_list = pi.search_em();

            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Em_info\\출퇴근기록.txt");
            //lines.RemoveAt(0);
            string name;

            float total_time = 0f;
            int none_work_cnt = 0;
            int full_work_cnt = 0;
            string[] names = new string[5];

            foreach (string line1 in code_list) //전체 사원 사번에 대해 가져올 리스트
            {
                string[] ln = line1.Split('\t');
                name = ln[1]; //name = 사번

                foreach (string line2 in lines) //출퇴근 기록
                {
                    string[] ln2 = line2.Split('\t');
                    try
                    {
                        if (DateTime.TryParse(ln2[4], out DateTime mon))
                        {
                            if (mon.Month == month) //이번달에 한해
                            {

                                //사번,관리자,사원조회,신규등록,퇴사,급여관리,출퇴근관리,휴가,출장,부서변경,//진행현황,예약  ,변경/수정,사후관리,마감기록,//매출,손익분석//,거래처조회,신규등록
                                //0     1      // 2       3       4     5        6        7   8     9       //  10     11       12      13         14    //   15     16    //   17       18
                                //Master_code	1//1	1	1	1	1	1	1	1 //   1   1  1  1   1	// 1   1   //1   1
                                //  사번        1// 2   3   4   5   6   7   8   9 //  10  11  12  13 14  //15  16  //17  18

                                if (power_check(5) == false)//권한없음
                                {
                                    //내기록만 보여줘야함

                                    if (ln2[1] == em_all_info[1])//내기록에 한해서만
                                    {
                                        
                                        if (float.TryParse(ln2[ln2.Length - 2], out float day) && ln2[ln2.Length-1]=="1") //퇴근기록에 대해서
                                        {
                                            
                                            
                                            if (day == 0)
                                            {
                                                none_work_cnt += 1;
                                            }
                                            if (day >= 8)
                                            {
                                                full_work_cnt += 1;
                                            }
                                            total_time += day;

                                            //names[0] = ln[0]; //이름
                                            //names[1] = name; //사번
                                            //names[2] = none_work_cnt.ToString();//결근횟수
                                            //names[3] = total_time.ToString(); //총 근로시간
                                            //names[4] = full_work_cnt.ToString(); //총 근로 일수
                                            //em_m_money_grid_view.Rows.Add(names);
                                        }
                                        else
                                        {

                                        }
                                    }
                                }
                                else
                                {
                                    if (name == ln2[1]) //동일한 사번에 한해
                                    {
                                        if (float.TryParse(ln2[ln2.Length - 2], out float day) && ln2[ln2.Length - 1] == "1") //총근로시간인덱스가 int변환이 가능한 총 근로시간일때 //근로시간 8시간당 하루
                                        {
                                            if (day == 0)
                                            {
                                                none_work_cnt += 1;
                                            }
                                            if (day >= 8)
                                            {
                                                full_work_cnt += 1;
                                            }
                                            total_time += day;
                                        }
                                        else
                                        {

                                        }
                                    }
                                }
                            }
                        }
                        else //변환이 안되는 퇴근기록이 없는경우
                        {
                            none_work_cnt += 1;
                        }
                    }
                    catch
                    {

                    }
                    
                }
                if(power_check(5)==false) //타인조회기능이 없어 본인만 보여주고 break;
                {
                    names[0] = ln[0]; //이름
                    names[1] = name; //사번
                    names[2] = none_work_cnt.ToString();//결근횟수
                    names[3] = total_time.ToString(); //총 근로시간
                    names[4] = full_work_cnt.ToString(); //총 근로 일수
                    em_m_money_grid_view.Rows.Add(names);
                    break;
                }
                else
                {
                    names[0] = ln[0]; //이름
                    names[1] = name; //사번
                    names[2] = none_work_cnt.ToString();//결근횟수
                    names[3] = total_time.ToString(); //총 근로시간
                    names[4] = full_work_cnt.ToString(); //총 근로 일수
                    em_m_money_grid_view.Rows.Add(names);
                }


                



                none_work_cnt = 0;
                full_work_cnt = 0;
                total_time = 0;





            }
        }
        private void em_ct_money_confirm_btn_Click(object sender, EventArgs e)
        {
            int num = 0;
            if(power_check(5))
            {
                num = 1;
            }
            else
            {
                num = 0;
            }

            em_ct_money_check ec = new em_ct_money_check(num, em_all_info[1]);
            ec.Show();

            
        }

        private int lastday()
        {
            DateTime MonthFirstDay = DateTime.Now.AddDays(1 - DateTime.Now.Day);
            DateTime MonthLastDay = MonthFirstDay.AddMonths(1).AddDays(-1);

            int nBetweenDayCnt = 0;

            int i = 0;
            DateTime temp;
            while (true)
            {
                temp = MonthFirstDay.AddDays(i);

                if (temp.DayOfWeek != DayOfWeek.Sunday && temp.DayOfWeek != DayOfWeek.Saturday)
                {
                    nBetweenDayCnt++;
                }
                TimeSpan Between = MonthLastDay - temp;
                if (Between.Days <= 0)
                {
                    break;
                }
                i++;
            }

            return MonthLastDay.Day - nBetweenDayCnt; //이번달의 총 평일 수
        }
        private void business_tirp_try_btn_Click(object sender, EventArgs e)
        {
            Business_trip bt = new Business_trip(em_all_info[0], em_all_info[1]);
            bt.Show();
        }
        private void business_trip_now_btn_Click(object sender, EventArgs e)//출장 현황조회 버튼
        {
            Fill_of_text_Box fb = new Fill_of_text_Box();
            List<string> lines = new List<string>();
            DateTime now = DateTime.Now;


            lines = fb.txt_read(@"C:\\Erp_main\\Em_info\\출장내역.txt");
            //이름,사번,출장지,회사명,담당자명,출발날짜,도착날짜,사유,담당자 폰번호,담당자 이메일

            //그리드뷰 에는 사유까지
            try
            {
                foreach (string line in lines)
                {
                    if (Convert.ToDateTime(line.Split('\t')[5]) <= now && now <= Convert.ToDateTime(line.Split('\t')[6])) //기간이 오늘날짜 내에 들어온다면
                    {
                        business_trip_grid_view.Rows.Add(line.Split('\t'));
                    }
                }
            }
            catch
            {

            }
            
            

        }

        private void business_trip_after_btn_Click(object sender, EventArgs e) //출장내역
        {


            Fill_of_text_Box fb = new Fill_of_text_Box();
            List<string> lines = new List<string>();
            DateTime now = DateTime.Now;


            lines = fb.txt_read(@"C:\\Erp_main\\Em_info\\출장내역.txt");
            //이름,사번,출장지,회사명,담당자명,출발날짜,도착날짜,사유,담당자 폰번호,담당자 이메일
            //그리드뷰 에는 사유까지
            try
            {
                foreach (string line in lines)
                {
                    if (Convert.ToDateTime(line.Split('\t')[6]) < now) //기간이 오늘날짜보다 뒤에 있다면
                    {
                        business_trip_grid_view.Rows.Add(line.Split('\t'));
                    }
                }
            }
            catch
            {

            }
        }
        //------------------------------------------------------------------------------------------------프로젝트 예약


        private bool prt_em_tf()
        {
            List<string> lines = new List<string>();
            Person_info pi = new Person_info();
            lines = pi.search_em();

            foreach (var line in lines)
            {
                if (line.Split('\t')[2].Contains("개발") || line.Split('\t')[2].Contains("외주"))
                {

                    return true;
                }
            }

            return false;

        }
        private void button32_Click_1(object sender, EventArgs e)
        {

            if(prt_em_tf()==false)
            {
                MessageBox.Show("해당사원이 없습니다.");
                return;
            }



            string[] arr = new string[4];
            try
            {
                arr[0] = prt_cpy_name_combobox.SelectedItem.ToString();
                arr[1] = prt_name_tb.Text;
                arr[2] = prt_code_tb.Text;
                arr[3] = prt_type_tb.Text;

                prt_em_list_select ps = new prt_em_list_select(arr);
                ps.DataPassEvent += new prt_em_list_select.DataPassEventHandler(data_Recevie);
                ps.Show();
            }
            catch
            {

            }
            
        }
        private void data_Recevie(List<string[]> select)
        {
            foreach(var sel in select)
            {
                em_select_gridview.Rows.Add(sel);
            }
        }
        private void button34_Click(object sender, EventArgs e)
        {
            try
            {
                var row = em_select_gridview.SelectedRows[0];
                em_select_gridview.Rows.Remove(row);
            }
            catch
            {

            }
            
        }
        private bool prt_calendar_check1 = true;
        private bool prt_calendar_check2 = true;
        private void prt_reservation_before_date_btn_Click(object sender, EventArgs e)
        {
            if (prt_calendar_check1)
            {
                prt_reservation_before_calendar.Visible = true;
                prt_calendar_check1 = false;
            }
            else
            {
                prt_reservation_before_calendar.Visible = false;
                prt_calendar_check1 = true;
            }
        }
        private void prt_reservation_after_date_btn_Click(object sender, EventArgs e)
        {
            if (prt_calendar_check2)
            {
                prt_reservation_after_calendar.Visible = true;
                prt_calendar_check2 = false;
            }
            else
            {
                prt_reservation_after_calendar.Visible = false;
                prt_calendar_check2 = true;
            }
        }
        private void prt_reservation_panel_Click(object sender, EventArgs e)
        {

            prt_reservation_after_calendar.Visible = false;
            prt_reservation_before_calendar.Visible = false;
        }
        private void prt_reservation_before_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            prt_reservation_before_date_label.Text = prt_reservation_before_calendar.SelectionStart.ToString("yyyy-MM-dd");
        }

        private void prt_reservation_after_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            prt_reservation_after_date_label.Text = prt_reservation_after_calendar.SelectionStart.ToString("yyyy-MM-dd");
        }
        private void prt_reservation_save_btn_Click(object sender, EventArgs e)
        {

            if (prt_reservation_check() == false)
            {
                return;
            }
            prt_reservation();

            //문자뒤에 \t 

        }

        private bool prt_reservation_check()
        {

            if (Int32.TryParse(prt_money_tb.Text, out int money))
            {
                if (money < 0)
                {
                    return false;
                }
            }
            else
            {

            }
            if (em_select_gridview.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("팀원이 없습니다.");
                return false;
            }
            if (DateTime.TryParse(prt_reservation_before_date_label.Text, out DateTime bdate) && DateTime.TryParse(prt_reservation_after_date_label.Text, out DateTime adate))
            {

            }
            else
            {
                MessageBox.Show("날짜 선택을 확인해주세요");
                return false;
            }
            return false;
        }




        private void prt_reservation_cancel_btn_Click(object sender, EventArgs e)
        {
            prt_code_tb.Text = "";
            prt_name_tb.Text = "";
            prt_type_tb.Text = "";
            prt_cpy_name_combobox.Text = "";
            prt_reservation_before_date_label.Text = "";
            prt_reservation_after_date_label.Text = "";
           
            prt_money_tb.Text = "";
            prt_etc_tb.Text = "";
        }
        private void prt_reservation()
        {
            string line= "";

            try
            {
                string[] arr = new string[]
                {
                    prt_code_tb.Text, // 프로젝트 코드 0
                    prt_name_tb.Text, //프로젝트명 1
                    prt_type_tb.Text, //프로젝트 유형 2
                    prt_cpy_name_combobox.SelectedItem.ToString(), //회사명 3
                    prt_reservation_before_date_label.Text, //시작날짜 4
                    prt_reservation_after_date_label.Text, //종료날짜 5
                    //팀원들 사번//은 따로 놓자
                    prt_money_tb.Text, //금액 6
                    prt_etc_tb.Text //기타사항 한줄 7
                };

                foreach (var pi in arr)
                {
                    line += pi + "\t";
                }

                StreamWriter sw = File.AppendText(@"C:\\Erp_main\\Prt_info\\프로젝트예약.txt");
                sw.WriteLine(line);
                sw.Close();
                sw.Dispose();


                string code_list = arr[0] + "\t" + arr[4] + "\t" + arr[5] + "\t";
                List<string> members = new List<string>();
                members = Prt_teams();
                foreach (var m in members)
                {
                    code_list += m + "\t";
                }
                StreamWriter prt_members = File.AppendText(@"C:\\Erp_main\\Prt_info\\프로젝트팀원.txt");
                prt_members.WriteLine(code_list); //프로젝트 코드,시작날짜,종료날짜,참여중인 사번~~~~
                prt_members.Close();
                prt_members.Dispose();
            }
            catch
            {

            }
            
            
        }

        private List<string> Prt_teams() //프로젝트 예약에서 사원조회후 확정된 사원들의 사번 리스트
        {
            List<string> grid_list = new List<string>();


            for (int i = 0; i < em_select_gridview.Rows.Count; i++)
            {
                if (em_select_gridview.Rows[i].Cells[1].Value != null)
                {
                    grid_list.Add(em_select_gridview.Rows[i].Cells[1].Value.ToString());
                }
                
            }
            return grid_list;




        }


       


        //---------------------------------------------------------------------------------------프로젝트 현황,진행중
        private void prt_ing_grid_show()
        {
            List<string> lines = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            DateTime now = DateTime.Now;

            

            TimeSpan d_day;
            for(int i = 0; i < prt_ing_gridview.Rows.Count;i++)
            {
                prt_ing_gridview.Rows.Clear();
            }
            lines = fi.txt_read(@"C:\\Erp_main\\Prt_info\\프로젝트예약.txt");
            // 코드,프로젝트명,유형,회사명,시작날짜,종료날짜,금액,비고
            // 0        1       2       3       4       5       6   7
            foreach(var line in lines)
            {
                string[] arr = line.Split('\t');

                DateTime.TryParse(arr[4], out DateTime start);
                DateTime.TryParse(arr[5], out DateTime end);
                try
                {
                    if (start <= now && now <= end) //진행중 기간에 존재하는 프로젝트에 한해
                    {
                        List<string> list = new List<string>();
                        for (int i = 0; i < 6; i++)
                        {
                            list.Add(arr[i]);
                        }
                        list.Add(arr[7]);

                        d_day = Convert.ToDateTime(arr[5]) - Convert.ToDateTime(arr[4]);
                        int Dday = d_day.Days;
                        list.Add(Dday.ToString());
                        string[] row = list.ToArray();
                        prt_ing_gridview.Rows.Add(row);
                    }
                }
                catch
                {

                }
                
            }
        }

        private void prt_ing_gridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = prt_ing_gridview.SelectedRows[0];
                List<string> teams_lines = new List<string>();
                List<string> em_names = new List<string>();
                Fill_of_text_Box fi = new Fill_of_text_Box();
                teams_lines = fi.txt_read(@"C:\\Erp_main\\Prt_info\\프로젝트팀원.txt");
                em_names = fi.txt_read(@"C:\\Erp_main\\Em_info\\Em_all_info.txt");
                string team = "";

                foreach (var line in teams_lines)
                {
                    string[] arr = line.Split('\t');
                    try
                    {
                        if (line.Contains(row.Cells[0].Value.ToString())) //선택한 행의 프로젝트코드랑 기록속에 코드가 일치하면 해당 프로젝트의 팀원을 한줄 텍스트로
                        {
                            for (int i = 3; i < arr.Length; i++)
                            {
                                foreach (var name in em_names)
                                {
                                    string[] nc = name.Split('\t');
                                    if (arr[i] == nc[1])
                                    {
                                        team += nc[0] + ", ";
                                    }
                                }
                            }

                            prt_ing_teams.Text = team;
                            return;
                        }
                    }
                    catch
                    {

                    }
                    
                }
            }
            catch
            {

            }
            
        }
        //-------------------------------------------------------------------------------------------------프로젝트마감

        private void prt_change_ok_cancel_btn_Click(object sender, EventArgs e) //수정확인패널 취소버튼
        {
            prt_change_ok_panel.Visible = false;
        }
        private bool prt_ending_check1 = true;
        private bool prt_ending_check2 = true;
        private void prt_ending_before_btn_Click(object sender, EventArgs e)
        {
            if (prt_ending_check1)
            {
                prt_ending_before_calendar.Visible = true;
                prt_ending_check1=false;    

            }
            else
            {
                prt_ending_before_calendar.Visible = false;
                prt_ending_check1 = true;
            }

        }

        private void prt_ending_after_btn_Click(object sender, EventArgs e)
        {
            if (prt_ending_check2)
            {
                prt_ending_after_calendar.Visible = true;
                prt_ending_check2=false;
            }
            else
            {
                prt_ending_after_calendar.Visible = false;
                prt_ending_check2 = true;
            }
        }

        private void prt_ending_before_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            prt_ending_before_date_label.Text = prt_ending_before_calendar.SelectionStart.ToString();
        }

        private void prt_ending_after_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            prt_ending_after_date_label.Text = prt_ending_after_calendar.SelectionStart.ToString();
        }




        private void end_log_search_btn_Click(object sender, EventArgs e) //프로젝트 마감기록 조회버튼클릭
        {
            List<string> lines = new List<string>();
            DateTime.TryParse(prt_ending_before_date_label.Text, out DateTime start);
            DateTime.TryParse(prt_ending_after_date_label.Text, out DateTime end);

            
            
            prt_ending_log_gridview.Rows.Clear();
           

            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Prt_info\\프로젝트예약.txt");

            foreach(var line in lines)
            {
                string[] log = line.Split('\t');
                if (DateTime.TryParse(log[5], out DateTime log_date)) //기록에서 마감날짜 추출
                {
                    if(start <= log_date && log_date <= end) //선택기간이 마감날짜 이내에 있다면
                    {
                        prt_ending_log_gridview.Rows.Add(log);
                    }
                }
            }




        }
        private void prt_ending_log_gridview_CellContentClick(object sender, DataGridViewCellEventArgs e) //마감기록 셀 클릭시 팀명
        {
            var row = prt_ending_log_gridview.SelectedRows[0];
            List<string> teams_lines = new List<string>();
            List<string> em_names = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            teams_lines = fi.txt_read(@"C:\\Erp_main\\Prt_info\\프로젝트팀원.txt");
            em_names = fi.txt_read(@"C:\\Erp_main\\Em_info\\Em_all_info.txt");
            string team = "";

            foreach (var line in teams_lines)
            {
                string[] arr = line.Split('\t');

                if (line.Contains(row.Cells[0].Value.ToString())) //선택한 행의 프로젝트코드랑 기록속에 코드가 일치하면 해당 프로젝트의 팀원을 한줄 텍스트로
                {
                    for (int i = 3; i < arr.Length; i++)
                    {
                        foreach (var name in em_names)
                        {
                            string[] nc = name.Split('\t');
                            if (arr[i] == nc[1])
                            {
                                team += nc[0] + ", ";
                            }
                        }
                    }

                    end_log_teams_label.Text = team;
                    return;
                }
            }
        }
        private void prt_chagne_search_btn_Click(object sender, EventArgs e) //프로젝트 수정에서 기간조회버튼 클릭시
        {
            List<string> lines = new List<string>();
            List<string> arr = new List<string>();
            DateTime now = DateTime.Now;
            string state1 = "진행중";
            DateTime.TryParse(prt_change_before_date_label.Text, out DateTime start);
            DateTime.TryParse(prt_change_after_date_label.Text, out DateTime end);
            for (int i = 0; i < prt_change_grid_view.Rows.Count; i++)
            {
                prt_change_grid_view.Rows.Clear();
            }

            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Prt_info\\프로젝트예약.txt");

            foreach (var line in lines)
            {
                arr = line.Split('\t').ToList();
                arr.RemoveAt(arr.Count - 1);
                DateTime sd = Convert.ToDateTime(arr[4]);
                DateTime ed = Convert.ToDateTime(arr[5]);
                if (start <= sd && ed <= end) //선택기간내 해당되는 프로젝트 기록에 대해
                {
                    if (sd <= now && now <= ed)
                    {
                        state1 = "진행중";       
                    }
                    else
                    {
                        state1 = "마감";
                    }
                    arr.Add(state1);


                    string[] log = arr.ToArray();

                    
                    prt_change_grid_view.Rows.Add(log);

                }   
            }
        }

        private void prt_change_grid_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (prt_change_grid_view.SelectedRows[0].Cells[1].Value == null)
            {
                return;
            }
            var row = prt_change_grid_view.SelectedRows[0];
            List<string> select_list = new List<string>();
            if (row.Cells[prt_change_grid_view.ColumnCount-1].Value.ToString() == "진행중" )
            {
                for(int i = 0; i<prt_change_grid_view.ColumnCount;i++)
                {
                    select_list.Add(row.Cells[i].Value.ToString());
                }
                select_list.RemoveAt(select_list.Count - 1); //상태 제외

                prt_change_info(select_list);
                prt_change_ok_panel.Visible = true;
                return;
            }
            else
            {
                prt_change_fail_panel.Visible = true;
            }
        }

        private void prt_change_fail_ok_btn_Click(object sender, EventArgs e)
        {
            prt_change_fail_panel.Visible = false;

        }
        private void prt_change_info(List<string> list) //선택정보 예약 페이지에 다시 뿌리기
        {

            //list = 코드, 프로젝트명, 유형, 회사명,시작날짜,마감날짜,금액,비고
            //         0    1           2       3       4       5       6   7
            
            List<string> lines = new List<string>(); //기록받아올 리스트

            List<string> codes = new List<string>(); //프로젝트 참여 팀원사번리스트
            List<string> em_list = new List<string>();

            prt_code_tb.Text = list[0];
            prt_name_tb.Text = list[1];
            prt_type_tb.Text = list[2];
            prt_cpy_name_combobox.Text = list[3];

            prt_reservation_before_date_label.Text = list[4];
            prt_reservation_after_date_label.Text = list[5]; 

            prt_money_tb.Text = list[6];
            prt_etc_tb.Text = list[7];

            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Prt_info\\프로젝트팀원.txt");

            for(int i = 0; i<em_select_gridview.Rows.Count;i++)
            {
                em_select_gridview.Rows.Clear();
            }
            foreach(var line in lines)
            {
                string[] prt_info = line.Split('\t');
                if (prt_info[0] == list[0])
                {
                    for(int i = 3; i < prt_info.Length; i++)
                    {
                        codes.Add(prt_info[i]);
                    }
                    Person_info pi = new Person_info();
                    em_list = pi.search_em();
                    foreach(var code in codes)
                    {
                        foreach (var em in em_list)
                        {
                            string[] em_info = em.Split('\t');
                            if (em_info[1] == code) //팀원과 사원정보에 대해 사번 일치 여부
                            {
                                //0 1 3 8 9

                                string[] member = { em_info[0], em_info[1], em_info[3], em_info[8], em_info[9] };
                                em_select_gridview.Rows.Add(member);

                            }
                        }
                    }
                    return;
                }
            }
        }









        private bool prt_change_check1 = true;
        private bool prt_change_check2 = true;

        private void prt_change_before_btn_Click(object sender, EventArgs e)
        {
            if(prt_change_check1)
            {
                prt_change_before_calendar.Visible = true;
                prt_change_check1 = false;
            }
            else
            {
                prt_change_before_calendar.Visible = false;
                prt_change_check1 = true;
            }
        }

        private void prt_change_after_btn_Click(object sender, EventArgs e)
        {
            if(prt_change_check2)
            {
                prt_change_after_calendar.Visible = true;
                prt_change_check2 = false;
            }
            else
            {
                prt_change_after_calendar.Visible = false;
                prt_change_check2 = true;
            }
            
        }
        private void prt_change_panel_Click(object sender, EventArgs e)
        {
            prt_change_before_calendar.Visible = false;
            prt_change_after_calendar.Visible = false;
        }

        private void prt_change_before_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            prt_change_before_date_label.Text = prt_change_before_calendar.SelectionStart.ToString();
        }

        private void prt_change_after_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            prt_change_after_date_label.Text = prt_change_after_calendar.SelectionStart.ToString();
        }

        private bool prt_as_check = true;
        private void prt_as_update_date_btn_Click(object sender, EventArgs e)
        {
            if(prt_as_check)
            {
                prt_as_update_calendar.Visible=true;
                prt_as_check=false;
            }
            else
            {
                prt_as_update_calendar.Visible = false;
                prt_as_check = true;
            }

        }

        private void prt_as_update_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            prt_as_update_date_label.Text = prt_as_update_calendar.SelectionStart.ToString();
        }

        private void prt_as_update_search_btn_Click(object sender, EventArgs e) //사후관리 기간 검색 버튼
        {

            prt_as_update_gridview.Rows.Clear();
            
            Fill_of_text_Box fi = new Fill_of_text_Box();
            List<string> lines= new List<string>();
            lines = fi.txt_read(@"C:\\Erp_main\\Prt_info\\프로젝트예약.txt");
            DateTime now = DateTime.Now;
            string state = "";
            // 해당 프로젝트에 현재 프로젝트 진행중인 사원이 있다면 불가능 아니라면 가능
            try
            {
                if (DateTime.TryParse(prt_as_update_date_label.Text, out DateTime date))
                {
                    foreach (var line in lines)
                    {
                        string[] arr = line.Split('\t');
                        DateTime.TryParse(arr[5], out DateTime log);

                        if (date <= log && log < now) //마감기록중 조회보다 큰
                        {

                            if(prt_as_try_check(arr[0]))
                            {
                                state = "가능";
                            }
                            else
                            {
                                state = "불가능";
                            }


                            string[] prt = { arr[0], arr[1], arr[2], arr[3], arr[5], arr[7], state };
                            prt_as_update_gridview.Rows.Add(prt);
                        }
                    }
                }
                else
                {
                    foreach (var li in lines)
                    {
                        string[] arr = li.Split('\t');
                        DateTime.TryParse(arr[5], out DateTime result);

                        if (result < now)
                        {


                            if (prt_as_try_check(arr[0]))
                            {
                                state = "가능";
                            }
                            else
                            {
                                state = "불가능";
                            }


                            string[] prt = { arr[0], arr[1], arr[2], arr[3], arr[5], arr[7], state };
                            prt_as_update_gridview.Rows.Add(prt);
                            
                        }
                    }
                }
            }
            catch
            {
                foreach (var li in lines)
                {
                    string[] arr = li.Split('\t');
                    DateTime.TryParse(arr[5], out DateTime result);

                    if (result < now)
                    {
                        if (prt_as_try_check(arr[0]))
                        {
                            state = "가능";
                        }
                        else
                        {
                            state = "불가능";
                        }


                        string[] prt = { arr[0], arr[1], arr[2], arr[3], arr[5], arr[7], state };
                        prt_as_update_gridview.Rows.Add(prt);
                        
                    }
                }
            }
           
        }




        private bool prt_as_try_check(string code) //마감된 프로젝트 중에 현재 팀원이 참여 가능한지 불가능한지
        {
            Fill_of_text_Box fi = new Fill_of_text_Box();
            List<string> lines = new List<string>();
            List<string> teams = new List<string>();
            lines = fi.txt_read(@"C:\\Erp_main\\Prt_info\\프로젝트예약.txt");
            teams = fi.txt_read(@"C:\\Erp_main\\Prt_info\\프로젝트팀원.txt");
            List<string> numbers = new List<string>();
            DateTime now = DateTime.Now;
            foreach(var team in teams)
            {
                string[] arr = team.Split('\t');
                if (arr[0]==code) //
                {

                    for(int i = 3; i<arr.Length; i++)
                    {
                        numbers.Add(arr[i]); //마감기록에 있던 팀원들
                        foreach(var t in teams)
                        {
                            string[] arr1 = team.Split('\t');
                            if (DateTime.TryParse(arr1[1],out DateTime start) && DateTime.TryParse(arr[2],out DateTime end))
                            {
                                if(start<=now&&now<end)
                                {

                                    for(int j = 3; j <arr1.Length; j++)
                                    {
                                        foreach(var num in numbers)
                                        {
                                            if (arr1[j] == num)
                                            {
                                                return false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void prt_as_update_fail_btn_Click(object sender, EventArgs e)
        {
            prt_as_update_fail_panel.Visible = false;
        }

        private void prt_as_update_gridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (prt_as_update_gridview.SelectedRows[0].Cells[6].Value.ToString() == "불가능")
                {
                    prt_as_update_fail_panel.Visible = true;
                    return;
                }
                var row = prt_as_update_gridview.SelectedRows[0];
                var cell = row.Cells[0].Value.ToString();
                DateTime now = DateTime.Now;

                prt_as_up_code_txt_box.Text = row.Cells[0].Value.ToString();
                prt_as_up_name_txt_box.Text = row.Cells[1].Value.ToString();
                prt_as_up_type_txt_box.Text = row.Cells[2].Value.ToString();
                prt_as_up_cpy_comboBox.Items.Clear();
                List<string> cpy_names = new List<string>();
                List<string> teams = new List<string>();
                Fill_of_text_Box fb = new Fill_of_text_Box();

                cpy_names = fb.txt_read(@"C:\\Erp_main\\Cpy_info\\거래처목록.txt");
                teams = fb.txt_read(@"C:\\Erp_main\\Prt_info\\프로젝트팀원.txt");
                string team_list = "";
                foreach (var team in teams)
                {
                    string[] arr = team.Split('\t');
                    if (arr[0] == cell)
                    {
                        for (int i = 3; i < arr.Length; i++)
                        {
                            team_list += arr[i] + ", ";
                        }


                    }
                }

                prt_as_teams_label.Text = team_list.Substring(0, team_list.Length - 1);
                foreach (var names in cpy_names)
                {
                    prt_as_up_cpy_comboBox.Items.Add(names.Split('\t')[1]);
                }
                prt_as_up_be_date_text_box.Text = now.ToString();
                prt_as_up_etc_txt_box.Text = row.Cells[5].Value.ToString();
                prt_as_update_ok_panel.Visible = true;
            }
            catch
            {

            }


        }
        private bool prt_as_date_check = true;
        private bool prt_as_date_check2 = true;
        private void prt_as_be_btn_Click(object sender, EventArgs e)
        {
            if(prt_as_date_check)
            {

                prt_as_up_be_calendar.Visible = true;
                prt_as_date_check=false;
            }
            else
            {
                prt_as_up_be_calendar.Visible = false;
                prt_as_date_check=true;
            }
        }
        private void prt_as_after_btn_Click(object sender, EventArgs e)
        {
            if(prt_as_date_check2)
            {
                prt_as_up_after_calendar.Visible = true;
                prt_as_date_check2=false;
            }
            else
            {
                prt_as_up_after_calendar.Visible = false;
                prt_as_date_check2=true;    
            }
        }
        private void prt_as_up_be_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            prt_as_up_be_date_text_box.Text = prt_as_up_be_calendar.SelectionStart.ToString();
        }

        private void prt_as_up_after_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            prt_as_up_after_date_txt_box.Text = prt_as_up_after_calendar.SelectionStart.ToString();
        }

        private void prt_as_update_cancel_btn_Click(object sender, EventArgs e)
        {

            prt_as_update_ok_panel.Visible = false;
        }

        private void prt_as_update_save_btn_Click(object sender, EventArgs e) //저장버튼
        {

            var row = prt_as_update_gridview.SelectedRows[0];
            var cell = row.Cells[0].Value.ToString();
            List<string> lines = new List<string>();
            List<string> teams = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Prt_info\\프로젝트예약.txt");
            teams = fi.txt_read(@"C:\\Erp_main\\Prt_info\\프로젝트팀원.txt");

            foreach (var line in lines)
            {
                string[] arr = line.Split('\t');
                if (arr[0] == cell)
                {
                    lines.Remove(line);
                    break;
                }
            }
            fi.txt_writeline(@"C:\\Erp_main\\Prt_info\\프로젝트예약.txt", lines);
            foreach (var team in teams)
            {
                string[] arr1 = team.Split('\t');
                if (arr1[0] == cell)
                {
                    teams.Remove(team);
                    break;
                }
            }
            fi.txt_writeline(@"C:\\Erp_main\\Prt_info\\프로젝트팀원.txt", teams);


            string[] prt_as_line =
            {
                prt_as_up_code_txt_box.Text,
                prt_as_up_name_txt_box.Text,
                prt_as_up_type_txt_box.Text,
                prt_as_up_cpy_comboBox.SelectedItem.ToString(),
                prt_as_up_be_date_text_box.Text,
                prt_as_up_after_date_txt_box.Text,
                prt_as_update_money_txt_box.Text,
                prt_as_up_etc_txt_box.Text
            };
            string prt_as = "";



            foreach(var ass in prt_as_line)
            {
                prt_as += ass + "\t";
            }
            StreamWriter ssw = File.AppendText(@"C:\\Erp_main\\Prt_info\\사후관리내역.txt");
            ssw.WriteLine(prt_as.Substring(0,prt_as.Length-1));
            ssw.Close();
            ssw.Dispose();

            string[] prt_as_team = prt_as_teams_label.Text.Split(',');
            string prt_as_t = prt_as_up_code_txt_box.Text + "\t" + prt_as_up_be_date_text_box.Text + "\t" + prt_as_up_after_date_txt_box.Text;


            foreach (var t in prt_as_team)
            {

                prt_as_t += t + "\t";
            }
            
            StreamWriter ttw = File.AppendText(@"C:\\Erp_main\\Prt_info\\사후관리팀원.txt");

            ttw.WriteLine(prt_as_t.Substring(0,prt_as_t.Length-1));

            ttw.Close();
            ttw.Dispose();




        }

        private void prt_as_ing_search_btn_Click(object sender, EventArgs e)
        {
            prt_as_ing_gridview.Rows.Clear();
            List<string> lines = new List<string>();
            List<string> view = new List<string>();
            DateTime now = DateTime.Now;
            Fill_of_text_Box fi = new Fill_of_text_Box();
            TimeSpan date;

            lines = fi.txt_read(@"C:\\Erp_main\\Prt_info\\사후관리내역.txt");

            foreach (var line in lines)
            {
                string[] arr = line.Split('\t');

                

                DateTime.TryParse(arr[4], out DateTime start);
                DateTime.TryParse(arr[5], out DateTime end);
                if (start <= now && now < end)
                {
                    foreach (var a in arr)
                    {
                        view.Add(a);
                    }

                    date = end - now;
                    view.Add(date.Days.ToString());

                    prt_as_ing_gridview.Rows.Add(view.ToArray());
                }
            }
        }

        private void prt_as_ing_gridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                var select = prt_as_ing_gridview.SelectedRows[0].Cells[0].Value.ToString();
                List<string> teams = new List<string>();
                Fill_of_text_Box fi = new Fill_of_text_Box();
                teams = fi.txt_read(@"C:\\Erp_main\\Prt_info\\사후관리팀원.txt");
                string members = "";
                foreach (var team in teams)
                {
                    string[] arr = team.Split('\t');

                    try
                    {
                        if (arr[0] == select)
                        {
                            for (int i = 3; i < arr.Length; i++)
                            {
                                members += arr[i] + ",";

                            }
                        }
                    }
                    catch
                    {

                    }
                    
                }

                prt_as_ing_teams_label.Text = members.Substring(0, members.Length - 1);
            }
            catch
            {

            }
            
        }
        private bool prt_as_after_check = true;
        private void prt_as_after_search_btn_Click(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;
            if(prt_as_after_check)
            {
                prt_as_after_year_label.Text = year.ToString(); 
                prt_as_date_panel.Visible = true;
                prt_as_after_check = false;
            }
            else
            {
                prt_as_date_panel.Visible = false;
                prt_as_after_check=true;
            }
            
        }

        

        private void prt_as_after_date_search_btn_Click(object sender, EventArgs e)
        {

            prt_as_after_gridview.Rows.Clear();

            string month = prt_as_after_date_label.Text + "-1";
            DateTime.TryParse(month, out DateTime mon);
            
            List<string> lines = new List<string>();
            DateTime now = DateTime.Now;
            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Prt_info\\사후관리내역.txt");
            

            foreach(var line in lines)
            {
                string[] arr = line.Split('\t');
                DateTime.TryParse(arr[5], out DateTime date);
                if(date <now)
                {
                    if(mon<date)
                    {
                        prt_as_after_gridview.Rows.Add(arr);
                    }
                }
            }




           
        }

        private void prt_as_after_year_m_btn_Click(object sender, EventArgs e)
        {
            string year = prt_as_after_year_label.Text;
            int num = 0;
            Int32.TryParse(year,out int year_num);
            num = year_num - 1;
            if(num<=0)
            {
                num = 2022;
            }
            prt_as_after_year_label.Text = num.ToString();
        }

        private void prt_as_after_year_p_btn_Click(object sender, EventArgs e)
        {

            string year = prt_as_after_year_label.Text;
            int num = 0;
            Int32.TryParse(year, out int year_num);
            num = year_num + 1;
            prt_as_after_year_label.Text = num.ToString();

        }
        private void number_date(int num)
        {
            prt_as_after_date_label.Text = prt_as_after_year_label.Text + "-" + num.ToString();
        }

        private void prt_as_after_month_1_Click(object sender, EventArgs e)
        {
            number_date(1);
        }

        private void prt_as_after_month_2_Click(object sender, EventArgs e)
        {
            number_date(2);
        }

        private void prt_as_after_month_3_Click(object sender, EventArgs e)
        {
            number_date(3);
        }

        private void prt_as_after_month_4_Click(object sender, EventArgs e)
        {
            number_date(4);
        }

        private void prt_as_after_month_5_Click(object sender, EventArgs e)
        {
            number_date(5);
        }

        private void prt_as_after_month_6_Click(object sender, EventArgs e)
        {
            number_date(6);
        }

        private void prt_as_after_month_7_Click(object sender, EventArgs e)
        {
            number_date(7);
        }

        private void prt_as_after_month_8_Click(object sender, EventArgs e)
        {
            number_date(8);
        }

        private void prt_as_after_month_9_Click(object sender, EventArgs e)
        {
            number_date(9);
        }

        private void prt_as_after_month_10_Click(object sender, EventArgs e)
        {
            number_date(10);
        }

        private void prt_as_after_month_11_Click(object sender, EventArgs e)
        {
            number_date(11);
        }

        private void prt_as_after_month_12_Click(object sender, EventArgs e)
        {
            number_date(12);
        }









        private bool em_vacation_check1 = true;
        private bool em_vacation_check2 = true;
        private void em_vacation_before_btn_Click(object sender, EventArgs e)
        {
            if(em_vacation_check1)
            {
                em_vacation_before_calendar.Visible = true;
                em_vacation_check1 = false;
            }
            else
            {
                em_vacation_before_calendar.Visible = false;
                em_vacation_check1 = true;
            }
        }
        private void em_vacation_after_btn_Click(object sender, EventArgs e)
        {
            if (em_vacation_check2)
            {
                em_vacation_after_calendar.Visible = true;
                em_vacation_check2 = false;
            }
            else
            {
                em_vacation_after_calendar.Visible = false;
                em_vacation_check2 = true;
            }
        }

        private void em_vacation_before_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            em_vacation_before_label.Text = em_vacation_before_calendar.SelectionStart.ToString();  
        }

        private void em_vacation_after_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            em_vacation_after_label.Text = em_vacation_after_calendar.SelectionStart.ToString();
        }

        private void em_vacation_search_btn_Click(object sender, EventArgs e)
        {
            DateTime.TryParse(em_vacation_before_label.Text, out DateTime start);
            DateTime.TryParse(em_vacation_after_label.Text, out DateTime end);
            List<string> lines = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            //이름 사번 기간 기간 종류 사유
            lines = fi.txt_read(@"C:\\Erp_main\\Em_info\\휴가내역.txt");

            em_vacation_gridview.Rows.Clear();

            try
            {
                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');
                    DateTime.TryParse(arr[2], out var s1);
                    DateTime.TryParse(arr[3], out var s2);

                    if (start <= s1 && s2 <= end)
                    {
                        em_vacation_gridview.Rows.Add(arr);
                    }
                }
            }
            catch
            {
                foreach(var line in lines)
                {
                    string[] arr = line.Split('\t');
                    em_vacation_gridview.Rows.Add(arr);
                }
            }
           
        }

        private void em_vacation_update_btn_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            em_vacation_try_panel.Visible = true; //신청 패널 등장
            em_vacation_today_text_box.Text = now.ToString("yyyy-MM-dd");
            em_vacation_name_text_box.Text = em_all_info[0];
            em_vacation_code_text_box.Text = em_all_info[1];


        }

        private void em_vacation_try_X_btn_Click(object sender, EventArgs e)
        {
            em_vacation_try_panel.Visible = false;
        }

        private void em_vacation_dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            em_vacation_today_text_box.Text=em_vacation_dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }
        private bool em_vacation_check = true;
        private void em_vacation_picker_btn_Click(object sender, EventArgs e)
        {
            if(em_vacation_check)
            {
                em_vacation_dateTimePicker1.Visible = true;
                em_vacation_check = false;
            }
            else
            {
                em_vacation_dateTimePicker1.Visible = false;
                em_vacation_check = true;
            }
            
        }

       
        private void em_vacation_dates_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            em_vacation_before_text_box.Text = em_vacation_dates_calendar.SelectionStart.ToString("yyyy-MM-dd");
            em_vacation_after_text_box.Text = em_vacation_dates_calendar.SelectionEnd.ToString("yyyy-MM-dd");   
        }



        private bool dateCheck()
        {
            DateTime.TryParse(em_vacation_before_label.Text, out DateTime before);
            DateTime.TryParse(em_vacation_after_label.Text, out DateTime after);
            List<string> lines = new List<string>();
            //신청기간이 신청 내역에 있다면 신청불가
            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재상태.txt");
            foreach (var i in lines)
            {



                string[] drr = i.Split('\t');


                if (drr[0] == "휴가")
                {

                    if (drr[3] == em_all_info[1])
                    {
                        DateTime.TryParse(drr[5], out DateTime be);
                        DateTime.TryParse(drr[6], out DateTime af);
                        if (before <= be && after <= af)
                        {

                            MessageBox.Show("이미 신청내역에 해당 기간이 있습니다.");
                            return false;
                        }
                    }

                }

            }
            return true;

        }

        private void em_vacation_try_O_btn_Click(object sender, EventArgs e)
        {


            if (dateCheck() == false) //기간내 신청불가
            {
                return;
            }
           
            ApprovalCheck ac = new ApprovalCheck();
            if(ac.approval_date("휴가", em_vacation_code_text_box.Text,em_vacation_today_text_box.Text)==false) //당일 중복신청불가
            {
                return;
            }

            StreamWriter sw = File.AppendText(@"C:\\Erp_main\\Approval_info\\결재상태.txt");
            //이름 사번 기간 기간 종류 사유 신청일
            string[] arr =
                {
                "휴가",
                "대기중",
                em_vacation_name_text_box.Text, //0
                em_vacation_code_text_box.Text, //1
                em_vacation_today_text_box.Text, //2
                em_vacation_before_text_box.Text,//3
                em_vacation_after_text_box.Text,//4
                em_vacation_type_text_box.Text, //5
                em_vacation_reson_text_box.Text, //6
                
                };
            string line = "";
            foreach(var a in arr)
            {
                line += a + "\t";
            }
            sw.WriteLine(line.Substring(0,line.Length-1));
            sw.Close();
            sw.Dispose();
            main_grid_approval_info();
        }



        private void em_vacation_success_btn_Click(object sender, EventArgs e)
        {
            em_vacation_success_panel.Visible= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Setting_form sf = new Setting_form();
            sf.nf += notice_text_change;


            sf.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void em_dp_select_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            em_dp_change_search_grid_view.Rows.Clear();

            //사번,이름,부서,직급,연차
            List<string> lines = new List<string>();
            Person_info pi = new Person_info();
            lines = pi.search_em();
            //이름 사번 부서 직급 연차
            foreach(var line in lines)
            {
                string[] arr = line.Split('\t');
                if(em_dp_select_combo_box.SelectedItem.ToString() == "전체")
                {
                    string[] grid = { arr[1], arr[0], arr[2], arr[3], arr[4] };
                    em_dp_change_search_grid_view.Rows.Add(grid);
                }
                else if (em_dp_select_combo_box.SelectedItem.ToString() == arr[2])
                {
                    string[] grid = { arr[1], arr[0], arr[2], arr[3], arr[4] };
                    em_dp_change_search_grid_view.Rows.Add(grid);
                }
            }
        }

        private void em_dp_change_search_grid_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //em_dp_change_result_gridview
            try
            {
                var row = em_dp_change_search_grid_view.SelectedRows[0].Cells[0].Value.ToString();
                List<string> lines = new List<string>();
                Person_info pi = new Person_info();
                lines = pi.search_em();
                em_dp_change_over_check_label.Visible = false;
                for (int i = 0; i < em_dp_change_result_gridview.Rows.Count; i++)
                {
                    if (em_dp_change_result_gridview.Rows[i].Cells[1].Value != null)
                    {
                        if (row == em_dp_change_result_gridview.Rows[i].Cells[0].Value.ToString())//선택이 아래 그리드뷰에 존재한다면
                        {
                            em_dp_change_over_check_label.Visible = true;
                            return;
                        }
                    }
                }
                foreach (var line in lines)
                {
                    try
                    {
                        string[] arr = line.Split('\t');
                        if (arr[1] == row)
                        {
                            string[] grid = { arr[1], arr[0], arr[2], arr[3], arr[4] };
                            em_dp_change_result_gridview.Rows.Add(grid);
                        }
                    }
                    catch
                    {

                    }
                    
                }


            }
            catch
            {

            }
            
        }

        private void em_dp_change_try_btn_Click(object sender, EventArgs e)
        {

            em_dp_change_try_gridview.Rows.Clear();
            try
            {
                var rows = em_dp_change_result_gridview.Rows;
                List<string> list = new List<string>();
                DateTime now = DateTime.Now;

                for (int i = 0; i < rows.Count; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (rows[i].Cells[j].Value != null)
                        {
                            list.Add(rows[i].Cells[j].Value.ToString());
                        }
                    }
                    em_dp_change_try_gridview.Rows.Add(list.ToArray());
                    list.Clear();
                }
                em_dp_change_try_dp_label.Text = em_dp_change_result_combo_box.SelectedItem.ToString();
                em_dp_change_try_today_label.Text = now.ToString("yyyy-MM-dd");
                em_dp_change_try_user_name_label.Text = em_all_info[0];

                em_dp_change_try_panel.Visible = true;
            }
            catch
            {

            }
            
        }

        private void em_dp_change_try_X_btn_Click(object sender, EventArgs e)
        {
            em_dp_change_try_panel.Visible = false;
        }

        private void em_dp_change_try_O_btn_Click(object sender, EventArgs e)
        {
            
            string line = "";
            string[] arr =
                {
                    "부서",
                    "대기중",
                    em_dp_change_try_user_name_label.Text,
                    em_all_info[1],
                    em_dp_change_try_today_label.Text,
                    em_dp_change_try_dp_label.Text,
                };

            foreach(var a in arr)
            {
                line += a + "\t";
            }

            var selectrows = em_dp_change_try_gridview.Rows;








            List<string> codes=new List<string>();
            for(int i = 0; i<selectrows.Count; i++) 
            {
                try
                {
                    codes.Add(selectrows[i].Cells[1].Value.ToString());

                    if (selectrows[i].Cells[0].Value.ToString()==em_dp_change_try_dp_label.Text)
                    {
                        MessageBox.Show("같은 부서로 이동할 수 없습니다.");
                        return;
                            
                    }


                }
                catch
                {
                    continue;
                }

            }
            foreach(var code in codes)
            {
                line += code + "\t";
            }

            //같은사람이 같은 부서로 이동하는것은 막아야함
           

            ApprovalCheck ac = new ApprovalCheck();
            if (ac.approval_date("부서", em_all_info[1],em_dp_change_try_today_label.Text)==false)
            {

                MessageBox.Show("당일중복신청불가");
                return;
            }
            StreamWriter sw = File.AppendText(@"C:\\Erp_main\\Approval_info\\결재상태.txt");
            //부서변경 : 신청자, 사번, 신청일, 이동할 부서, 이동할인원의 사번1,이동할인원의 사번2 `````
            //
            sw.WriteLine(line);
            sw.Close();
            sw.Dispose();
        }






        private void ac_panel_on()
        {

            try
            {
                sales_dataGridview.Rows.Clear();
                profit_and_loss_GridView.Rows.Clear();
                chart1.Series["account_chart"].Points.Clear();
                ac_start_calender.Visible = false;
                ac_end_calender.Visible = false;
                sales_start_calender.Visible = false;
                sales_end_calender.Visible = false;
                acc_init();
                profit_sum = 0;
                sales_sum = 0;
                UserCheck uc = new UserCheck();
                accounts_list = uc.search_user(@"C:\\Erp_main\\Ac_info\\profit_and_loss.txt");
                foreach (string acc in accounts_list)
                {
                    string[] arr = acc.Split('\t');
                    if (acc.Split('\t')[0].ToString() == "날짜")
                    {
                        continue;
                    }

                    if (acc.Split('\t')[3].ToString().Length < 1)
                    {
                        n1 = acc.Split('\t')[1].ToString().Replace(",", "");
                        n2 = acc.Split('\t')[2].ToString().Replace(",", "");

                        profit3 = Convert.ToInt32(n1) - Convert.ToInt32(n2);

                        string change_num = String.Format("{0:#,0}", profit3);

                        if (acc.Split('\t')[5].ToString().Length < 1)
                        {
                            n3 = acc.Split('\t')[4].ToString().Replace(",", "");
                            profit5 = profit3 - Convert.ToInt32(n3);

                            string change_num2 = String.Format("{0:#,0}", profit5);

                            n4 = change_num2;

                            profit_sum += Convert.ToDouble(n4);

                            total = String.Format("{0:#,0}", profit_sum);

                            string[] arr100 = { arr[0], arr[1], arr[2], change_num, arr[4], change_num2, n4};

                            profit_and_loss_GridView.Rows.Add(arr100);
                        }
                    }
                    else
                    {
                        profit_and_loss_GridView.Rows.Add(acc.Split('\t'));
                    }
                }

                for (int i = 0; i < profit_and_loss_GridView.Columns.Count; i++)
                {
                    profit_and_loss_GridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // ------------------------------------------------------- 회계매출 패널 ---------------------------------------------------------------------
            UserCheck ud = new UserCheck();
            sales_list = ud.search_user(@"C:\\Erp_main\\Prt_info\\사후관리내역.txt");
            sales2_list = ud.search_user(@"C:\\Erp_main\\Prt_info\\프로젝트예약.txt");


            List<string> sale_list = new List<string>();


            foreach(var i in sales_list)
            {
                sale_list.Add(i);
            }

            foreach(var j in sales2_list)
            {
                sale_list.Add(j);
            }


            foreach (string sales in sale_list)                                 // 그리드뷰에 담기
            {
                string d = DateTime.Now.ToString("yyyy/MM/dd");
                DateTime.TryParse(sales.Split('\t')[5], out DateTime end_date);
                if (sales.Split('\t')[5].ToString().Length <= 4)
                {
                    continue;
                }
                else if (end_date<=DateTime.Now)
                {
                    try
                    {
                        sales_dataGridview.Rows.Add(sales.Split('\t')[0], sales.Split('\t')[1], sales.Split('\t')[2], sales.Split('\t')[3], sales.Split('\t')[5], sales.Split('\t')[6]);
                        sales_sum += Convert.ToUInt32(sales.Split('\t')[6].ToString().Replace(",", ""));
                        total2 = String.Format("{0:#,0}", sales_sum);
                    }
                    catch
                    {

                    }
                    
                }
            }
            money_sales_textbox.Text = total2 + " 원";
            int r_num = 1;
            foreach (DataGridViewRow row in sales_dataGridview.Rows)                    // 앞에 순번 붙이기
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                else
                {
                    row.HeaderCell.Value = r_num + " 번";
                    r_num += 1;
                }
            }
            sales_dataGridview.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            sales_dataGridview.RowHeadersVisible = true;

            // ------------------------------------------------------- 손익계산 패널 ---------------------------------------------------------------------
            profit_and_loss_GridView.RowHeadersVisible = false;                         // 손익계산 패널
            profit_and_loss_GridView.CurrentCell = null;

            profit.Text = total + "원";
            company_capital.Text = "100,000,000" + "원";

            chart1.Series["account_chart"].Points.AddXY("회사 자본", "100000000");        // 회사 자본 임의로 1억 고정으로 두었다. "100000000"
            chart1.Series["account_chart"].Points.AddXY("당기 순 이익", profit_sum);









        }

        private void ac_start_btn_Click(object sender, EventArgs e)
        {

            ac_start_calender.Visible = true;
            ac_end_calender.Visible = false;
        }

        private void ac_end_btn_Click(object sender, EventArgs e)
        {
            ac_start_calender.Visible = false;
            ac_end_calender.Visible = true;
        }

        private void ac_start_calender_DateChanged(object sender, DateRangeEventArgs e)
        {
            before_label.Text = ac_start_calender.SelectionStart.ToString().Substring(0, 10);
        }

        private void ac_end_calender_DateChanged(object sender, DateRangeEventArgs e)
        {
            after_label.Text = ac_end_calender.SelectionEnd.ToString().Substring(0, 10);
        }

        private void ac_profit_and_loss_panel_MouseClick(object sender, MouseEventArgs e)
        {
            ac_start_calender.Visible = false;
            ac_end_calender.Visible = false;
        }
        private void acc_init()
        {
            profit_and_loss_GridView.Columns.Clear();

            profit_and_loss_GridView.Columns.Add("Column1", "날짜");
            profit_and_loss_GridView.Columns.Add("Column2", @"영업
수익");
            profit_and_loss_GridView.Columns.Add("Column3", @"매출
원가");
            profit_and_loss_GridView.Columns.Add("Column4", @"매출
총 이익");
            profit_and_loss_GridView.Columns.Add("Column5", @"판매
관리비");
            profit_and_loss_GridView.Columns.Add("Column6", @"영업
이익");
            profit_and_loss_GridView.Columns.Add("Column9", @"당기
순 이익");
//            profit_and_loss_GridView.Columns.Add("Column7", @"영업
//외
//수익");
//            profit_and_loss_GridView.Columns.Add("Column8", @"영업
//외
//비용");
        }

        private void ac_search_btn_Click(object sender, EventArgs e)
        {
            try
            {






                profit_sum = 0;

                UserCheck uc = new UserCheck();
                accounts_list = uc.search_user(@"C:\\Erp_main\\Ac_info\\profit_and_loss.txt");
                //매출원가는 프로젝트 마감기록에서의 금액
                //                                      + 사후관리 마감기록에서의 금액
                //판매관리비는 급여에서 결재 승인 이후

                profit_and_loss_GridView.Rows.Clear();

                if (before_label.Text == "기간" || after_label.Text == "기간")
                {
                    return;
                }
                else
                {
                    string r_date = before_label.Text.Replace("-", "");

                    string r_date2 = after_label.Text.Replace("-", "");

                    int real_date = Convert.ToInt32(r_date);

                    int real_date2 = Convert.ToInt32(r_date2);

                    foreach (string data in accounts_list)
                    {
                        string[] arr = data.Split('\t');

                        if (data.Split('\t')[0].ToString().Replace("-", "").Length <= 3)
                        {
                            continue;
                        }
                        else
                        {
                            int date = Convert.ToInt32(data.Split('\t')[0].ToString().Replace("-", ""));
                            if (real_date <= date & date <= real_date2)
                            {
                                if (data.Split('\t')[3].ToString().Length < 1)
                                {
                                    n1 = data.Split('\t')[1].ToString().Replace(",", "");
                                    n2 = data.Split('\t')[2].ToString().Replace(",", "");

                                    profit3 = Convert.ToInt32(n1) - Convert.ToInt32(n2);

                                    string change_num = String.Format("{0:#,0}", profit3);


                                    if (data.Split('\t')[5].ToString().Length < 1)
                                    {
                                        n3 = data.Split('\t')[4].ToString().Replace(",", "");
                                        profit5 = profit3 - Convert.ToInt32(n3);

                                        string change_num2 = String.Format("{0:#,0}", profit5);

                                        n4 = change_num2;

                                        profit_sum += Convert.ToDouble(n4);

                                        total = String.Format("{0:#,0}", profit_sum);

                                        string[] arr100 = { arr[0], arr[1], arr[2], change_num, arr[4], change_num2, n4};

                                        profit_and_loss_GridView.Rows.Add(arr100);
                                    }
                                }
                                else
                                {
                                    profit_and_loss_GridView.Rows.Add(data.Split('\t'));
                                }
                            }
                        }
                    }
                    profit_and_loss_GridView.RowHeadersVisible = false;
                    profit_and_loss_GridView.CurrentCell = null;

                    profit.Text = total + "원";

                    chart1.Series["account_chart"].Points.Clear();
                    chart1.Series["account_chart"].Points.AddXY("회사 자본", "100000000");        // 회사 자본 임의로 1억 고정으로 두었다. "100000000"
                    chart1.Series["account_chart"].Points.AddXY("당기 순 이익", profit_sum);

                    for (int i = 0; i < profit_and_loss_GridView.Columns.Count; i++)
                    {
                        profit_and_loss_GridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sales_start_calender_DateChanged(object sender, DateRangeEventArgs e)
        {
            sales_start_label.Text = sales_start_calender.SelectionStart.ToString().Substring(0, 10);
        }

        private void sales_end_calender_DateChanged(object sender, DateRangeEventArgs e)
        {
            sales_end_label.Text = sales_end_calender.SelectionStart.ToString().Substring(0, 10);
        }

        private void sales_search_btn_Click(object sender, EventArgs e)
        {
            try
            {
                sales_sum = 0;

                sales_dataGridview.Rows.Clear();
                List<string> line1 = new List<string>();
                List<string> line2 = new List<string>();
                List<string> sales_list1 = new List<string>();
                UserCheck ud = new UserCheck();
                line1 = ud.search_user(@"C:\\Erp_main\\Prt_info\\사후관리내역.txt");
                line2 = ud.search_user(@"C:\\Erp_main\\Prt_info\\프로젝트예약.txt");

                foreach(var l1 in line1)
                {
                    sales_list1.Add(l1);
                }
                foreach(var l2 in line2)
                {
                    sales_list1.Add(l2); 
                }
                foreach (string item in sales_list1)
                {

                    string s_num = sales_start_label.Text.Replace("-", "");
                    string s_num2 = sales_end_label.Text.Replace("-", "");


                    //int sales_num = Convert.ToInt32(s_num);
                    //int sales_num2 = Convert.ToInt32(s_num2);


                    if (Int32.TryParse(s_num,out int sales_num) && Int32.TryParse(s_num2,out int sales_num2))
                    {

                    }
                    else
                    {
                        sales_num = 0;
                        sales_num2 = 0;
                    }

                    if (sales_start_label.Text == "기간" || sales_end_label.Text == "기간")
                    {
                        
                        sales_dataGridview.Rows.Add(item.Split('\t')[0], item.Split('\t')[1], item.Split('\t')[2], item.Split('\t')[3], item.Split('\t')[5], item.Split('\t')[6]);
                        sales_sum += Convert.ToUInt32(item.Split('\t')[6].ToString().Replace(",", ""));
                        total2 = String.Format("{0:#,0}", sales_sum);
                    }
                    else if (item.Split('\t')[5].ToString().Length <= 4)
                    {
                        continue;
                    }
                    else
                    {
                        int date_time = Convert.ToInt32(item.Split('\t')[5].ToString().Replace("-", ""));
                        if (sales_num <= date_time && date_time <= sales_num2)
                        {
                            sales_dataGridview.Rows.Add(item.Split('\t')[0], item.Split('\t')[1], item.Split('\t')[2], item.Split('\t')[3], item.Split('\t')[5], item.Split('\t')[6]);
                            sales_sum += Convert.ToUInt32(item.Split('\t')[6].ToString().Replace(",", ""));
                            total2 = String.Format("{0:#,0}", sales_sum);
                        }
                    }
                }
                money_sales_textbox.Text = total2 + " 원";
                int r_num = 1;
                foreach (DataGridViewRow row in sales_dataGridview.Rows)                    // 앞에 순번 붙이기
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }
                    else
                    {
                        row.HeaderCell.Value = r_num + " 번";
                        r_num += 1;
                    }
                }
                sales_dataGridview.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                sales_dataGridview.RowHeadersVisible = true;
            }
            catch
            {
                MessageBox.Show("형식에 알맞게 입력해주세요!", "경고", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }

        private void sales_start_btn_Click(object sender, EventArgs e)
        {
            sales_start_calender.Visible = true;
            sales_end_calender.Visible = false;
        }

        private void sales_end_btn_Click(object sender, EventArgs e)
        {
            sales_start_calender.Visible = false;
            sales_end_calender.Visible = true;
        }

        private void sales_panel_Click(object sender, EventArgs e)
        {
            sales_start_calender.Visible = false;
            sales_end_calender.Visible = false;
        }

        private void sales_dataGridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UserCheck check = new UserCheck();
            sales_list = check.search_user(@"C:\\Erp_main\\Prt_info\\사후관리내역.txt");

            string name = sales_dataGridview.Rows[e.RowIndex].Cells[0].Value.ToString();

            foreach (string item in sales_list)
            {
                //MessageBox.Show(item.Split('\t')[0].ToString());
                if (item.Split('\t')[0].ToString().Length <= 2)
                {
                    continue;
                }
                else if (name.Contains(item.Split('\t')[0].ToString()))
                {
                    sales_notetxt_label.Text = "프로젝트 사후관리 내역입니다";
                    break;
                }
                else
                {
                    sales_notetxt_label.Text = "프로젝트 마감 내역입니다";
                }
            }
        }




        private void approval_timer_set()
        {
            approval_check.Dispose();
            approval_check.Interval = 3000;
            approval_check.Tick += approval_timer_Tick;
            approval_check.Start();
        }

        static DateTime notice = new FileInfo(@"C:\\Erp_main\\Company_info\\사내공지.txt").LastWriteTime;

        static DateTime ap = new FileInfo(@"C:\\Erp_main\\Approval_info\\결재상태.txt").LastWriteTime;
        static DateTime ap_ref = new FileInfo(@"C:\\Erp_main\\Approval_info\\결재참조.txt").LastWriteTime;

        
        private string ap_name()
        {
            List<string> lines = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재상태.txt");


            return lines[lines.Count - 1].Split('\t')[0].ToString();
        }

        private void approval_timer_Tick(object sender, EventArgs e)
        {
            //일정주기로 일어나는 틱이벤트에 대해 결재신청이 들어왔는지 알림창 띄우기
            DateTime now = DateTime.Now;
            //DateTime va;
            //DateTime bu;
            //DateTime del;
            //DateTime dp;
            //DateTime mo;

            var newap = new FileInfo(@"C:\\Erp_main\\Approval_info\\결재상태.txt");
            var newap_ref = new FileInfo(@"C:\\Erp_main\\Approval_info\\결재참조.txt");
            var noti = new FileInfo(@"C:\\Erp_main\\Company_info\\사내공지.txt");

            //v_info.LastWriteTime;
            if(notice != noti.LastWriteTime)
            {
                StreamReader sr = new StreamReader(@"C:\\Erp_main\\Company_info\\사내공지.txt");
                string notice1 = sr.ReadLine();
                sr.Close();
                sr.Dispose();
                if (notice1 == "" || notice1 == "\n" || notice1 == null)
                {
                    main_notice_label.Text = "사내공지입니다.";
                }
                else
                {

                    main_notice_label.Text = notice1;
                }
            }

            if (em_all_info[2] == "인사" && em_all_info[3]=="팀장")
            {

                if(ap != newap.LastWriteTime)
                {
                    alarm_label.Text = ap_name()+" 신청";
                    alarm_panel_timer.Start();
                    ap = newap.LastWriteTime;

                }                
            }
            
            if(ap_ref != newap_ref.LastWriteTime)
            {
                alarm_label.Text = "수신참조";
                alarm_panel_timer.Start();
                ap_ref = newap_ref.LastWriteTime;
            }
        }

        Timer alarm_panel_timer = new Timer();
        int alarm_panel_cnt = 0;
        private void aplarm_panel_timer_set()
        {
            alarm_panel_timer.Dispose();
            alarm_panel_timer.Interval = 1;
            alarm_panel_timer.Tick += alarm_panel_timer_Tick;
            
        }
        private int alarm_state = 0;
        private void alarm_panel_timer_Tick(object sender, EventArgs e)
        {
            

            if(alarm_state == 0 )
            {
                alarm_panel.Top -= 5;

                if (alarm_panel.Top <= 545)
                {
                    alarm_panel.Top = 545;
                    alarm_state = 1;
                }
                
            }
            else if(alarm_state == 1)
            {
                alarm_panel_cnt += 1;

                alarm_panel.Top = 545;
                if(alarm_panel_cnt > 300)
                {
                    alarm_state = 2;
                }
            }
            else if(alarm_state == 2)
            {
                alarm_panel.Top += 5;
                if (alarm_panel.Top >= 750)
                {
                    alarm_panel.Top = 750;
                    alarm_panel_cnt = 0;
                    alarm_panel_timer.Stop();
                    main_grid_approval_info();
                }
            }
        }

        private void approval_try(List<string> list)
        {
            string[] grid = new string[4];
            string state="";
            DateTime now = DateTime.Now;

            //신청일기준 한달간 유지라면?
            foreach (var line in list)
            {
                try
                {
                    string[] arr = line.Split('\t');

                    DateTime.TryParse(arr[4], out DateTime date);



                    if(arr[1]== "대표승인완료" && date.AddMonths(1)<date) //승인완료 이후 한달이 지난 기록은 메인에서 제외
                    {
                        continue;
                    }


                    if (arr[3].Contains(em_all_info[1]))
                    {
                        grid[0] = arr[0];
                        grid[1] = arr[4];
                        grid[2] = arr[1];
                        grid[3] = "본인";
                    }
                    //유형    신청일 상태  비고
                    main_ap_dataGridView.Rows.Add(grid);
                }
                catch
                {

                }
                

            }
        }
        private void main_grid_approval_info()
        {
            DateTime now = DateTime.Now;
            List<string> approval_list = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();

            approval_list = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재상태.txt");
            main_ap_dataGridView.Rows.Clear();
            string[] grid = new string[4];
            //유형 신청일 상태 비고
            if (em_all_info[2] == "인사" && em_all_info[3] == "팀장")
            {
                foreach(var ap in approval_list)
                {
                    try
                    {
                        string[] arr = ap.Split('\t');
                        if (arr[1] == "대기중")
                        {

                            grid[0] = arr[0];
                            grid[1] = arr[4];
                            grid[2] = arr[1];
                            grid[3] = "신청자:" + arr[2];
                            main_ap_dataGridView.Rows.Add(grid);


                        }
                        if (arr[3] == em_all_info[1]) //인사팀장 본인이 신청자라면
                        {
                            approval_try(approval_list);
                        }
                    }
                    catch
                    {

                    }
                    
                }
            }
            else
            {
                approval_try(approval_list);
            }

            List<string> approval_ref = new List<string>();

            approval_ref = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재참조.txt");
            foreach(var re in approval_ref)
            {
                string[] arr = re.Split('\t');
                for(int i = 5; i <arr.Length;i++)
                {
                    //유형 신청일 상태 비고

                    if (arr[i]==em_all_info[1]) //본인이 참조에 있다면
                    {

                        grid[0] = arr[0];
                        grid[1] = arr[4];
                        grid[2] = arr[1];
                        grid[3] = "문서참조";
                        main_ap_dataGridView.Rows.Add(grid);
                        break;
                    }
                }
            }








        }







        private void no_power_btn_Click(object sender, EventArgs e)
        {
            no_power_panel.Visible = false;
        }

        private void catch_btn_Click(object sender, EventArgs e)
        {
            catch_panel.Visible = false;
        }

        private void em_img_del_Click(object sender, EventArgs e)
        {
            em_new_img_text.Text = "";
        }

        private void em_record_del_Click(object sender, EventArgs e)
        {
            em_new_record_text.Text = "";
        }


        private Point point = new Point();

        private void main_home_panel_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }
        private void main_home_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - (point.X - e.X), this.Top - (point.Y - e.Y));
            }
        }
        private void sub_main_panel_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void sub_main_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - (point.X - e.X), this.Top - (point.Y - e.Y));
            }
        }









        private void main_ap_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) //결재관리폼으로 이동
        {

            payment py = new payment(em_all_info[1]);
            py.Show();




        }

        private void alarm_btn_Click(object sender, EventArgs e)
        {

            payment py = new payment(em_all_info[1]);
            py.Show();


        }

        private void prt_end_log_panel_Click(object sender, EventArgs e)
        {
            prt_ending_before_calendar.Visible = false;
            prt_ending_after_calendar.Visible = false;
        }

        private void em_dp_change_result_gridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = em_dp_change_result_gridview.Rows;
                var select = em_dp_change_result_gridview.SelectedRows[0];
                //em_dp_change_result_gridview.Rows.Clear();

                row.Remove(select);
            }
            catch
            {

            }
        }

        //급여는 저장필요x 즉석에서 계산해서 그리드에 출력 애초에 결재신청을 위해 출력함
        //손익계산에들어가야함


        private void tema_change(string colors)
        {

            main_home_panel.BackColor = Color.FromName(colors); //메인화면 배경패널
            main_home_panel.BackColor = Color.FromName(colors); //메인화면 배경패널
            //메인화면 좌측 4개 카테고리 패널들
            main_em_panel1.BackColor = Color.FromName(colors); 
            main_prt_panel2.BackColor = Color.FromName(colors);
            main_ac_panel3.BackColor = Color.FromName(colors);
            main_cpy_panel4.BackColor = Color.FromName(colors);

            sub_main_panel.BackColor = Color.FromName(colors); //서브화면 배경 패널


            //사원관리패널
            em_submain_panel.BackColor = Color.FromName(colors);
            //      퇴사패널
            em_del_panel.BackColor = Color.FromName(colors);
            //      사원조회패널
            em_search_panel.BackColor = Color.FromName(colors);
            //      신규등록패널
            em_sub_newperson_panel.BackColor = Color.FromName(colors);

            //근태관리 패널
            em_ctmanage_panel.BackColor = Color.FromName(colors);
            //      근태-휴가조회패널
            em_vacation_panel.BackColor = Color.FromName(colors);
            //      근태 - 급여관리패널
            em_ct_2.BackColor = Color.FromName(colors);
            //      근태 - 출장현황패널
            business_trip_panel.BackColor = Color.FromName(colors);
            //      근태 - 출퇴근관리패널
            em_ct_1.BackColor = Color.FromName(colors);

            // 부서변경패널
            em_dp_change_panel.BackColor = Color.FromName(colors);



            

            //외주 배경패널
            prt_sub_main_panel.BackColor = Color.FromName(colors);
            //      외주 진행현황패널
            prt_ing_panel.BackColor = Color.FromName(colors);
            //      외주 예약패널
            prt_reservation_panel.BackColor = Color.FromName(colors);
            //      외주 마감기록패널
            prt_end_log_panel.BackColor= Color.FromName(colors);
            //      외주 변경,수정패널
            prt_change_panel.BackColor = Color.FromName(colors);

            //사후관리패널
            prt_as_sub_panel.BackColor = Color.FromName(colors);
            //      사후관리패널 상단버튼을 포함하고있는 패널
            //panel9.BackColor = Color.FromName(colors);
            //      사후관리-미처리현황패널
            prt_as_ing_panel.BackColor= Color.FromName(colors);
            //      사후관리-접수패널
            prt_as_update_panel.BackColor = Color.FromName(colors);
            //      사후관리-월간처리현황
            prt_as_after_panel.BackColor = Color.FromName(colors);



            //회계 배경패널
            ac_sub_panel.BackColor = Color.FromName(colors);
            //      회계손익분석패널
            ac_profit_and_loss_panel.BackColor = Color.FromName(colors);
            //      회계매출패널
            sales_panel.BackColor = Color.FromName(colors);

            //거래처 배경패널
            cpy_sub_main_panel.BackColor = Color.FromName(colors);

            
            


        }

        private void em_dp_change_try_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel43_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - (point.X - e.X), this.Top - (point.Y - e.Y));
            }
        }

        private void panel43_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }
    }











    class Person_info
    {
        //사원정보 저장경로
        public string em_info_path = @"C:\\Erp_main\\Em_info";
        
        
        public bool new_em(string em_code)
        {
            string new_em_info_path = em_info_path + @"\\" + em_code + @"\\" + em_code + "_memo.txt";
            DirectoryInfo new_em = new DirectoryInfo(em_info_path+ @"\\" + em_code);
            
                                    // 경로 \\ 사번폴더 \\ 사번_memo.txt
            try
            {
                if (new_em.Exists == false) //없다면
                {
                    new_em.Create(); //만들어라
                                     //폴더 만들었으니 그안의 텍스트 파일이 몇개 있어야지
                                     // Erp_main \\ Em_info \\ 사번폴더명 


                    StreamWriter sw = new StreamWriter(new_em_info_path);
                    sw.Write("");
                    sw.Close();
                    sw.Dispose();

                    return true;
                }
                else //있다면
                {
                    MessageBox.Show("이미 존재하는 정보입니다.");
                    return false;
                }
                
            }
            catch (Exception error)
            {
                

                
                //MessageBox.Show(error.Message);
                return false;
            }
        }
        
        
        static List<string> read_lines = new List<string>();


        public void new_em_txt(string[] em_all_info)
        {
            string emall = "";
            StreamWriter sw = File.AppendText(em_info_path + @"\\Em_all_info.txt");

            //foreach (var line in read_lines)
            //{
            //    sw.WriteLine(line);
            //}
              
            for (int i = 0; i < em_all_info.Length-2; i++)
            {
                emall += em_all_info[i] + "\t";
            }
            sw.WriteLine(emall);


            sw.Close();
            sw.Dispose();

            
        }


        //정보 조회 함수
        //먼저 표에 띄우기
        public List<string> search_em()
        {
            read_lines.Clear();
            string line;
            StreamReader sr = new StreamReader(em_info_path+@"\\Em_all_info.txt");

            while((line = sr.ReadLine()) != null)
            {
                read_lines.Add(line);
            }
            
            sr.Close();
            sr.Dispose();

            return read_lines;
        }
        public void write_em_info(List<string> list)
        {
            StreamWriter sw = new StreamWriter(em_info_path + @"\\em_all_info.txt");


            foreach(var i in list)
            {
                sw.WriteLine(i);
            }

            sw.Close();
            sw.Dispose();
    
        
        }
        public List<string> login_log() 
        {
            read_lines.Clear();
            string line;
            StreamReader sr = new StreamReader(@"C:\\Erp_main\\Em_info\\출퇴근기록.txt");
            while ((line = sr.ReadLine()) != null)
            {
                read_lines.Add(line);
            }

            sr.Close();
            sr.Dispose();

            return read_lines;
        }
        //퇴근및 근로시간 계산 후 추가 입력
        public void Off_work_time(string code,DateTime dt) 
        {
            
            List<string> lines = new List<string>();
            lines = login_log();
            DateTime work_time= DateTime.Now;

            string year = work_time.Year.ToString();
            string month = work_time.Month.ToString();
            string day = work_time.Day.ToString();


            TimeSpan ts= new TimeSpan();
            string user_line="";
            //이름,사번,  출근dt
            foreach (var line in lines)
            {
                string[] arr = line.Split('\t');
                if(line.Contains(code)) //로그인 이후의 상황이기때문에 무조건 사번이 존재
                {

                    DateTime.TryParse(arr[3], out DateTime off);
                    string uy = off.Year.ToString();
                    string um = off.Month.ToString();
                    string ud = off.Day.ToString();
                    
                    if (year+month+day == uy+um+ud) //오늘 출근날짜를 찾아서
                    {

                        if (arr[arr.Length-1]=="1") //이미 퇴근을 한 상황
                        {
                            return;
                        }
                        user_line = line;
                        lines.Remove(line);

                        ts = dt - off;
                        break;
                    }
                }
            }

            
            user_line += "\t"+work_time + "\t" + Math.Round(ts.TotalHours, 1).ToString()+"\t"+"1"; //근무시간은 소수점 한자리까지
            lines.Add(user_line);
            StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Em_info\\출퇴근기록.txt");
            foreach(var line in lines)
            {
                sw.WriteLine(line);
            }
            sw.Close();
            sw.Dispose();
            
            
            


        }
    }
        


    class panel_slide_timer
    {
        private int pn_left = 160;
        private int pm_heigt = 300;
        
        
        public bool time_interval_open(Control pn,Control pm,int sp)
        {
            try
            {
                pn.Left += sp;
                if (pn.Left >= 155)
                {
                    pn.Left = pn_left;
                    pm.Height += sp;
                    if (pm.Height >= pm_heigt)
                    {
                        pm.Height = pm_heigt;
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
            
        }
        public bool panel_close(Control pn,Control pm,int sp)
        {
            try
            {
                pm.Height -= sp;
                if (pm.Height <= 1)
                {
                    pm.Height = 1;
                    pn.Left -= sp;
                    if (pn.Left <= 15)
                    {
                        pn.Left = 15;
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
            
        }



        public bool mini_panel_open_btn(Control btn, Control pn, int sp)
        {
            
            try
            {
                pn.Width += sp;
                if (pn.Width >= 111)
                {
                    pn.Left = 118;
                    pn.Height += sp;
                    if (pn.Height >= 300)
                    {
                        pn.Height = 300;
                        return true;
                    }
                }




                return false;
            }
            catch
            {
                return false;
            }
            
        }
        public bool mini_panel_close_btn(Control btn, Control pn, int sp)
        {

           
            try
            {
                pn.Height -= sp;
                if (pn.Height <= 0)
                {
                    pn.Height = 0;
                    pn.Left = 0;
                    pn.Width -= sp;
                    if (pn.Width <= 0)
                    {
                        pn.Width = 1;
                        return true;
                    }

                }



                return false;
            }
            catch
            {
                return false;
            }
            
        }







    }


    class Fill_of_text_Box
    {
        static string line;
        
        static List<string> lines = new List<string>();

        private string all_text;

        public List<string> text_fill(string path,Control text_box)
        {
            StreamReader sr = new StreamReader(path);

            while((line = sr.ReadLine()) != null)
            {
               
                all_text += line+"\r\n";
                lines.Add(line);
            }
            text_box.Text=all_text;
            
            sr.Close();
            sr.Dispose();
            return lines;
        }


        public string[] em_info_fill()
        {

            StreamReader em = new StreamReader(@"C:\\Erp_main\\Em_info\\Em_all_info.txt");
            while((line= em.ReadLine()) != null)
            {
                if(line.Split('\t')[1] == Form1.user_emcode) //사번일치여부, 로그인이 성공했으니 반드시 한번은 걸림
                {
                    em.Close();
                    em.Dispose();
                    return line.Split('\t');
                }
            }
            em.Close();
            em.Dispose();
            return null;
        }



        public void txt_write(string path,string textValue)
        {
            StreamWriter sw = new StreamWriter(path);
            

            
            sw.WriteLine(textValue);

            sw.Close();
            sw.Dispose();
        }

        public void txt_writeline(string path,List<string> list)
        {
            StreamWriter sw = new StreamWriter(path);

            foreach(var i in list)
            {
                sw.WriteLine(i);
            }
            sw.Close();
            sw.Dispose();
        }

        public List<string> txt_read(string path) 
        {
            List<string> list = new List<string>();
            string line;
            StreamReader sr = new StreamReader(path);

            while((line = sr.ReadLine()) != null)
            {
                list.Add(line);
            }
            sr.Close();
            sr.Dispose();

            return list;
        
        }

    }



    class PowerCheck
    {
        public static string path = @"C:\\Erp_main\\Em_info\\권한설정.txt";


        public List<string> read_power()
        {

            string line;
            List<string> lines = new List<string>();
            StreamReader sr = new StreamReader(path);
            while((line = sr.ReadLine()) != null)
            {
                lines.Add(line);
            }


            sr.Close();
            sr.Dispose();
            return lines;
        }



    }
    class ApprovalCheck
    {
        public bool approval_date(string tema,string code ,string value)
        {
            List<string> lines = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재상태.txt");
            foreach (var line in lines)
            {
                string[] arr = line.Split('\t');

                if(arr[0]== tema)
                {
                    if (arr[1] == code)
                    {
                        DateTime.TryParse(arr[2], out DateTime date);
                        if (date.ToString("yyyy-MM-dd") == value)
                        {
                            return false;
                        }
                    }
                }

                
            }
            return true;
        }
    }


}
