using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Account_profit_and_loss : Form
    {
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
        public Account_profit_and_loss()
        {
            InitializeComponent();
        }
// ------------------------------------------------------- 손익계산 패널 ---------------------------------------------------------------------
        private void Account_sales_Load(object sender, EventArgs e)
        {
            try
            {
                sales_dataGridview.Rows.Clear();
                profit_and_loss_GridView.Rows.Clear();

                ac_start_calender.Visible = false;
                ac_end_calender.Visible = false;
                acc_init();
                sales_start_calender.Visible = false;
                sales_end_calender.Visible = false;
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

                            string[] arr100 = { arr[0], arr[1], arr[2], change_num, arr[4], change_num2, n4, arr[7], arr[8] };

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
            sales_list = ud.search_user(@"C:\\Erp_main\\Prt_info\\프로젝트예약.txt");

            foreach (string sales in sales_list)                                 // 그리드뷰에 담기
            {
                string d = DateTime.Now.ToString("yyyy/MM/dd");

                if (sales.Split('\t')[5].ToString().Length <= 4)
                {
                    continue;
                }
                else if (DateTime.Compare(Convert.ToDateTime(d), Convert.ToDateTime(sales.Split('\t')[5].ToString())) >= 1)
                {
                    sales_dataGridview.Rows.Add(sales.Split('\t')[0], sales.Split('\t')[1], sales.Split('\t')[2], sales.Split('\t')[3], sales.Split('\t')[5], sales.Split('\t')[6]);

                    sales_sum += Convert.ToUInt32(sales.Split('\t')[6].ToString().Replace(",", ""));

                    total2 = String.Format("{0:#,0}", sales_sum);
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








//----------------------------------------------------------------------------------------------------------------------------------------------
        private void ac_start_btn_Click(object sender, EventArgs e)            // 회계 손익계산 캘린더 앞에 클릭
        {

            ac_start_calender.Visible = true;
            ac_end_calender.Visible = false;
        }
        private void ac_end_btn_Click(object sender, EventArgs e)              // 회계 손익계산 캘린더 뒤에 클릭
        {
            ac_start_calender.Visible = false;
            ac_end_calender.Visible = true;
        }
        private void ac_start_calender_DateChanged(object sender, DateRangeEventArgs e)          // 회계 손익분석 캘린더 값 선택
        {
            before_label.Text = ac_start_calender.SelectionStart.ToString().Substring(0,10);
        }
        private void ac_end_calender_DateChanged(object sender, DateRangeEventArgs e)            // 회계 손익분석 캘린더 값 선택
        {
            after_label.Text = ac_end_calender.SelectionEnd.ToString().Substring(0,10);
        }
        private void ac_profit_and_loss_panel_MouseClick(object sender, MouseEventArgs e)       // 회계 손익계산 판넬 클릭할 시
        {
            ac_start_calender.Visible = false;
            ac_end_calender.Visible = false;
        }
//---------------------------------------------회계 손익계산 열머리 추가 ----------------------------------------------------------
        private void acc_init()
        {
            profit_and_loss_GridView.Columns.Add("Column1", "날짜");
            profit_and_loss_GridView.Columns.Add("Column2", @"영업
수익");
            profit_and_loss_GridView.Columns.Add("Column3", @"매출
원가");
            profit_and_loss_GridView.Columns.Add("Column4", @"매출
총
이익");
            profit_and_loss_GridView.Columns.Add("Column5", @"판매
관리비");
            profit_and_loss_GridView.Columns.Add("Column6", @"영업
이익");
            profit_and_loss_GridView.Columns.Add("Column9", @"당기
순
이익");
            profit_and_loss_GridView.Columns.Add("Column7", @"영업
외
수익");
            profit_and_loss_GridView.Columns.Add("Column8", @"영업
외
비용");
        }
//---------------------------------------------회계 손익계산 캘린더---------------------------------------------------------------------
        private void ac_search_btn_Click(object sender, EventArgs e)                      // 회계 -손익계산 캘린더 검색 버튼
        {
            try
            {
                profit_sum = 0;

                UserCheck uc = new UserCheck();
                accounts_list = uc.search_user(@"C:\\Erp_main\\Ac_info\\profit_and_loss.txt");

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

                                        string[] arr100 = { arr[0], arr[1], arr[2], change_num, arr[4], change_num2, n4, arr[7], arr[8] };

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
//---------------------------------------------- 회계 매출 관련 ---------------------------------------------------------------------------------
        private void sales_start_calender_DateChanged(object sender, DateRangeEventArgs e)         // 회계 매출 캘린더
        {
            sales_start_label.Text = sales_start_calender.SelectionStart.ToString().Substring(0, 10);
        }

        private void sales_end_calender_DateChanged(object sender, DateRangeEventArgs e)              // 회계 매출 캘린더
        {
            sales_end_label.Text = sales_end_calender.SelectionStart.ToString().Substring (0, 10);
        }

        private void sales_search_btn_Click(object sender, EventArgs e)                  // 회계 매출 - 조회 캘린더
        {
            try
            {
                sales_sum = 0;

                sales_dataGridview.Rows.Clear();

                UserCheck ud = new UserCheck();
                sales_list = ud.search_user(@"C:\\Erp_main\\Prt_info\\사후관리내역.txt");
                sales_list = ud.search_user(@"C:\\Erp_main\\Prt_info\\프로젝트예약.txt");

                foreach (string item in sales_list)
                {

                    string s_num = sales_start_label.Text.Replace("-", "");
                    string s_num2 = sales_end_label.Text.Replace("-", "");

                    int sales_num = Convert.ToInt32(s_num);
                    int sales_num2 = Convert.ToInt32(s_num2);

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
                MessageBox.Show("형식에 알맞게 입력해주세요!","경고",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
            }
        }











        private void button3_Click(object sender, EventArgs e)                 // 회계 매출 - 시작 날자 캘린더 버튼
        {
            sales_start_calender.Visible = true;
            sales_end_calender.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)                 // 회계 매출 - 끝 날자 캘린더 버튼
        {
            sales_start_calender.Visible = false;
            sales_end_calender.Visible = true;
        }
        private void sales_panel_MouseClick(object sender, MouseEventArgs e)             // 회계 매출 판넬
        {
            sales_start_calender.Visible = false;
            sales_end_calender.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //sales_panel.Visible = false;
            //ac_profit_and_loss_panel.Visible = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //sales_panel.Visible = true;
            //ac_profit_and_loss_panel.Visible = false;
        }
        private void sales_panel_Paint(object sender, PaintEventArgs e)
        {
        }
        private void sales_dataGridview_CellClick(object sender, DataGridViewCellEventArgs e)
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


    }
}
