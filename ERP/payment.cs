using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    public partial class payment : Form
    {
        private List<string> data_list = new List<string>();

        private List<string> pay_list = new List<string>();
        private List<string> depart_list = new List<string>();
        private List<string> business_list = new List<string>();
        private List<string> retire_list = new List<string>();
        private List<string> vacation_list = new List<string>();

        private string btn_name;

        public delegate void Reception();

        public event Reception rec;


        private static string my_code;



        public payment(string code)
        {

            InitializeComponent();
            my_code = code;
        }



        //결재관리 신청현황 진행중 반려 완료
        //status = 신청현황
        //gird = 전체

        // 결재관리탭은 인사팀장이 승인한것만 나온다 , 진행중,반려,완료  - > 최종승인문서가



        //payment = 기본 게시판
        //request = 인사팀장이 승인을 요청할 문서
        //official = 사장이 승인할 문서


        // 1. 일반사원
        //status = 내가한 신청 - 승인불가지만 신청서는 나타남
        //gird = 조건없이 모든 사원에 대한 결재자체를출력 수신참조가 있다면 문서 출력

        // 2. 인사팀장
        //status = 모든 신청현황 - 클릭하면 신청서
        //gird = 조건없이 모든 사원에 대한 결재자체를출력 수신참조가 있다면 문서 출력

        // 3. 사장||대표
        // status => 인사팀장이 신청한 신청서출력
        // gird 클릭가능 + 최종승인

        //사원        팀장      사장
        //신청        완료      올py


        private int myCheck()
        {
            List<string> lines = new List<string>();
            Person_info pi = new Person_info();
            lines = pi.search_em();

            foreach(var line in lines)
            {
                string[] arr = line.Split('\t');
                if (arr[1] == my_code)
                {

                    if (arr[3].Contains("대표") || arr[3].Contains("사장"))
                    {
                        return 3;
                    }

                    if (arr[2].Contains("인사") && arr[3].Contains("팀장"))
                    {

                        return 2;
                    }
                }
            }
            return 1;
        }
        private void Form3_Load(object sender, EventArgs e)
        {

            try
            {
                pay_list.Clear();
                depart_list.Clear();
                business_list.Clear();
                retire_list.Clear();
                vacation_list.Clear();

                status_Gridview.Rows.Clear();




                Girdview1.BringToFront();
                division.BringToFront();

                start_Date.CustomFormat = "yyyy-MM-dd";
                start_Date.Format = DateTimePickerFormat.Custom;
                start_Date.Value = new DateTime(int.Parse(DateTime.Now.ToString("yyyy")), int.Parse(DateTime.Now.ToString("MM")), 1);  // 시작날짜는 매 달 1일로 설정

                End_Date.CustomFormat = "yyyy-MM-dd";
                End_Date.Format = DateTimePickerFormat.Custom;

                division_init();     // 구분 콤보박스
            }
            catch (Exception ex) 
            {
                //MessageBox.Show(ex.Message);
            }


            List<string> lines = new List<string>();

            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재상태.txt");

            int rank = myCheck();
            string[] grid = new string[6];
            if(rank == 2)//인사팀장
            {
                //제목 신청자 사번 신청일 상태 비고
                foreach(var line in lines)
                {
                    try
                    {
                        string[] arr = line.Split('\t');
                        if (arr[1] == "대기중")
                        {
                            grid[0] = "[" + arr[0] + "]" + arr[0] + " 신청입니다.";
                            grid[1] = arr[2];
                            grid[2] = arr[3];
                            grid[3] = arr[4];
                            grid[4] = arr[1];
                            grid[5] = "";
                            status_Gridview.Rows.Add(grid);
                        }
                    }
                    catch
                    {

                    }
                    
                }
            }
            else if(rank==1) //일반사원
            {
                foreach(var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if(arr[3]==my_code) //본인사번과 동일한(내가 한 신청들에 한해서
                    {

                        grid[0] = "[" + arr[0] + "]" + arr[0] + " 신청입니다.";
                        grid[1] = arr[2];
                        grid[2] = arr[3];
                        grid[3] = arr[4];
                        grid[4] = arr[1];
                        grid[5] = "본인";
                        status_Gridview.Rows.Add(grid);
                    }
                }
            }
            else if(rank==3) //사장or대표 최종승인자
            {
                foreach(var line in lines)
                {
                    string[] arr = line.Split('\t');
                    if(arr[1]=="팀장승인완료")
                    {
                        grid[0] = "[" + arr[0] + "]" + arr[0] + " 신청입니다.";
                        grid[1] = arr[2];
                        grid[2] = arr[3];
                        grid[3] = arr[4];
                        grid[4] = arr[1];
                        grid[5] = "승인신청";
                        status_Gridview.Rows.Add(grid);
                    }
                }
            }

            


            List<string> approval_ref = new List<string>();
            approval_ref = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재참조.txt");
            foreach (var re in approval_ref)
            {
                string[] arr = re.Split('\t');
                for (int i = 5; i < arr.Length; i++)
                {
                    //유형 신청일 상태 비고

                    if (arr[i] == my_code) //본인이 참조에 있다면
                    {
                        foreach(var line in lines)
                        {
                            string[] li = line.Split('\t');

                            if(arr[0] == li[0] && arr[2]==li[3]&&arr[3]==li[4])//유형,신청자사번,신청일 일치시
                            {

                                grid[0] = "[" + arr[0] + "]" + arr[0] + " 신청입니다.";
                                grid[1] = li[2];
                                grid[2] = li[3];
                                grid[3] = li[4];
                                grid[4] = li[1];
                                grid[5] = "수신참조";
                                status_Gridview.Rows.Add(grid);
                                break;
                            }
                        }
                        break;
                    }
                }
            }


            type_combo_init();
            payment_panel.Focus();
        }

        private void payment_panel_Paint(object sender, PaintEventArgs e)           // 결재관리 판넬
        {

        }

        private void button1_Click(object sender, EventArgs e)        // 결재관리 버튼
        {
            Girdview1.BringToFront();
            division.BringToFront();

            search.Visible = true;
            search_button.Visible = true;

            btn_name = button1.Text;

            UserCheck uc = new UserCheck();
            data_list = uc.search_user(@"C:\\Erp_main\\Py_info\\all_py.txt");

            Girdview1.Rows.Clear();
            foreach (string data in data_list)
            {
                Girdview1.Rows.Add(data.Split('\t'));
            }
            Girdview1.RowHeadersVisible = false;
            Girdview1.CurrentCell = null;
        }

        private void button4_Click(object sender, EventArgs e)           // 신청현황 버튼
        {
            status_Gridview.BringToFront();
            search.Visible = false;
            search_button.Visible = false;
        }
        private void button5_Click(object sender, EventArgs e)           // 진행중 버튼
        {
            Girdview1.BringToFront();
            division.BringToFront();
            btn_name = button5.Text;

            search.Visible = true;
            search_button.Visible = true;

            UserCheck uc = new UserCheck();
            data_list = uc.search_user(@"C:\\Erp_main\\Py_info\\all_py.txt");

            Girdview1.Rows.Clear();
            foreach (string data in data_list)
            {
                try
                {
                    if (data.Split('\t')[5].ToString() == "진행중")
                    {
                        Girdview1.Rows.Add(data.Split('\t'));
                    }
                }
                catch
                {

                }
                
            }
            Girdview1.RowHeadersVisible = false;
            Girdview1.CurrentCell = null;
        }
        private void button6_Click(object sender, EventArgs e)            // 반려 버튼
        {
            Girdview1.BringToFront();
            division.BringToFront();

            btn_name = button6.Text;

            search.Visible = true;
            search_button.Visible = true;

            UserCheck uc = new UserCheck();
            data_list = uc.search_user(@"C:\\Erp_main\\Py_info\\all_py.txt");

            Girdview1.Rows.Clear();
            foreach (string data in data_list)
            {
                try
                {
                    if (data.Split('\t')[5].ToString() == "반려")
                    {
                        Girdview1.Rows.Add(data.Split('\t'));
                    }
                }
                catch
                {

                }
                
            }
            Girdview1.RowHeadersVisible = false;
            Girdview1.CurrentCell = null;
        }
        private void button7_Click(object sender, EventArgs e)             // 완료 버튼
        {
            Girdview1.BringToFront();
            division.BringToFront();

            btn_name = button7.Text.ToString().Substring(0,2);

            search.Visible = true;
            search_button.Visible = true;

            UserCheck uc = new UserCheck();
            data_list = uc.search_user(@"C:\\Erp_main\\Py_info\\all_py.txt");

            Girdview1.Rows.Clear();
            foreach (string data in data_list)
            {
                try
                {
                    if (data.Split('\t')[5].ToString() == "완료")
                    {
                        Girdview1.Rows.Add(data.Split('\t'));
                    }
                }
                catch
                {

                }
                
            }
            Girdview1.RowHeadersVisible = false;
            Girdview1.CurrentCell = null;
        }

        private void division_init()               //        읽음, 안읽음 구분 콤보박스
        {
            division.Items.Clear();
            division.Items.Add("전체");
            division.Items.Add("읽음");
            division.Items.Add("안읽음");

            division.SelectedIndex = 0;
        }
        private void type_combo_init()                 //        [카테고리] 구분 콤보박스
        {
            UserCheck uc = new UserCheck();
            data_list = uc.search_user(@"C:\\Erp_main\\Py_info\\all_py.txt");



            type_search_combo.Items.Add("구분");
            foreach (string data in data_list)
            {
                try
                {
                    string catergori1 = data.Split('\t')[1].ToString().Substring(1, 2);

                    if (type_search_combo.Items.Contains(catergori1))
                    {
                        continue;
                    }
                    else
                    {
                        type_search_combo.Items.Add(catergori1);
                    }
                }
                catch
                {

                }
                
            }
            type_search_combo.SelectedIndex = 0;
        }
        private void division_SelectedIndexChanged(object sender, EventArgs e)                   // 구분 콤보박스
        {
            try
            {
                UserCheck uc = new UserCheck();
                data_list = uc.search_user(@"C:\\Erp_main\\Py_info\\all_py.txt");
                if (division.SelectedItem.ToString() == "전체")                          // 전체에 대한 콤보박스
                {
                    Girdview1.Rows.Clear();
                    foreach (string name in data_list)
                    {
                        if (btn_name == null || btn_name == "결재관리")
                        {
                            Girdview1.Rows.Add(name.Split('\t'));
                            //Girdview1.RowsDefaultCellStyle.ForeColor = Color.Black;
                        }
                        else if (name.Split('\t')[5].ToString().Contains(btn_name))
                        {
                            Girdview1.Rows.Add(name.Split('\t'));
                        }
                    }
                    Girdview1.RowHeadersVisible = false;
                    Girdview1.CurrentCell = null;
                }
                else if (division.SelectedItem.ToString() == "읽음")                          // 읽음에 대한 콤보박스
                {
                    Girdview1.Rows.Clear();

                    foreach (string name in data_list)
                    {
                        if (btn_name == null)
                        {
                            if (name.Split('\t')[0] == "읽음")
                            {
                                Girdview1.Rows.Add(name.Split('\t'));
                            }    
                        }
                        else if (name.Split('\t')[5].ToString().Contains(btn_name) && name.Split('\t')[0] == "읽음" || btn_name == "결재관리" && name.Split('\t')[0] == "읽음")
                        {
                            Girdview1.Rows.Add(name.Split('\t'));
                        }
                    }
                    Girdview1.RowHeadersVisible = false;
                    Girdview1.CurrentCell = null;
                }
                else if ( division.SelectedItem.ToString() == "안읽음" )
                {
                    Girdview1.Rows.Clear();

                    foreach (string name in data_list)
                    {
                        if (btn_name == null)
                        {
                            if (name.Split('\t')[0] == "안읽음")
                            {
                                Girdview1.Rows.Add(name.Split('\t'));
                            }
                        }
                        else if (btn_name == "결재관리" && name.Split('\t')[0] == "안읽음")
                        {
                            Girdview1.Rows.Add(name.Split('\t'));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void search_button_Click(object sender, EventArgs e)                        // 버튼 클릭시
        {
            try
            {

                DateTime dt = start_Date.Value;
                string date = dt.ToString().Substring(0, 10);
                int real_date = Convert.ToInt32(date.Replace("-", ""));          // 시작날짜 담기 ex) 20221201

                DateTime dt2 = End_Date.Value;
                string date2 = dt2.ToString().Substring(0, 10);
                int real_date2 = Convert.ToInt32(date2.Replace("-", ""));          // 마지막 날짜 담기 ex) 20221231


                UserCheck uc = new UserCheck();
                data_list = uc.search_user(@"C:\\Erp_main\\Py_info\\all_py.txt");

                if (search.Text != null)                          // 빈칸이 없을 시
                {
                    Girdview1.Rows.Clear();

                    foreach (string name in data_list)        // 결재관리 판넬
                    {
                        try
                        {
                            int check = Convert.ToInt32(name.Split('\t')[4].ToString().Replace("-", ""));
                            if (real_date <= check && check <= real_date2)
                            {
                                if (btn_name == null || btn_name == "결재관리")
                                {
                                    if (type_search_combo.SelectedItem.ToString() == "구분")
                                    {
                                        if (name.Split('\t')[1].ToString().Contains(search.Text))
                                        {
                                            if (btn_name == null || btn_name == "결재관리")
                                            {
                                                Girdview1.Rows.Add(name.Split('\t'));
                                            }
                                            else if (name.Split('\t')[5].ToString().Contains(btn_name))
                                            {
                                                Girdview1.Rows.Add(name.Split('\t'));
                                            }
                                        }
                                    }
                                    else if (name.Split('\t')[1].ToString().Contains(type_search_combo.SelectedItem.ToString()))
                                    {
                                        if (name.Split('\t')[1].ToString().Contains(search.Text))
                                        {
                                            if (btn_name == null || btn_name == "결재관리")
                                            {
                                                Girdview1.Rows.Add(name.Split('\t'));
                                            }
                                            else if (name.Split('\t')[5].ToString().Contains(btn_name))
                                            {
                                                Girdview1.Rows.Add(name.Split('\t'));
                                            }
                                        }
                                    }
                                }
                                else if (name.Split('\t')[5].ToString().Contains(btn_name))
                                {
                                    if (type_search_combo.SelectedItem.ToString() == "구분")
                                    {
                                        if (name.Split('\t')[1].ToString().Contains(search.Text))
                                        {
                                            if (btn_name == null || btn_name == "결재관리")
                                            {
                                                Girdview1.Rows.Add(name.Split('\t'));
                                            }
                                            else if (name.Split('\t')[5].ToString().Contains(btn_name))
                                            {
                                                Girdview1.Rows.Add(name.Split('\t'));
                                            }
                                        }
                                    }
                                    else if (name.Split('\t')[1].ToString().Contains(type_search_combo.SelectedItem.ToString()))
                                    {
                                        if (name.Split('\t')[1].ToString().Contains(search.Text))
                                        {
                                            if (btn_name == null || btn_name == "결재관리")
                                            {
                                                Girdview1.Rows.Add(name.Split('\t'));
                                            }
                                            else if (name.Split('\t')[5].ToString().Contains(btn_name))
                                            {
                                                Girdview1.Rows.Add(name.Split('\t'));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {

                        }
                           
                    }
                }
                else
                {
                    Girdview1.Rows.Clear();

                    foreach (string name in data_list)
                    {
                        Girdview1.Rows.Add(name.Split('\t'));
                    }
                }
                Girdview1.RowHeadersVisible = false;
                Girdview1.CurrentCell = null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private async void Girdview1_CellClick(object sender, DataGridViewCellEventArgs e)               // 결재 게시판에서 제목 클릭 시
        {
            try
            {

                if (ref_check() == false)
                {
                    MessageBox.Show("접근권한이 없습니다.");
                    return;
                }

                UserCheck uc = new UserCheck();
                data_list = uc.search_user(@"C:\\Erp_main\\Py_info\\all_py.txt");

                DataGridViewRow row = Girdview1.SelectedRows[0];
                string r = row.Cells[0].Value.ToString();                 // 선택된 행의 0번째 열 값

                string[] arr = new string[8];

                string name = "";
                string subtitle = "";
                string person = "";

                name = Girdview1.Rows[e.RowIndex].Cells[1].Value.ToString().Substring(1, 2);
                subtitle = Girdview1.Rows[e.RowIndex].Cells[1].Value.ToString();
                person = Girdview1.Rows[e.RowIndex].Cells[3].Value.ToString();

                string info = row.Cells[4].Value.ToString()+","+row.Cells[6].Value.ToString();
                //날짜,이름,사번


                if (name == "출장")                                                      // 선택한 행의 앞 두글자가 출장일 경우
                {
                    if (r == "안읽음")
                    {
                        row.Cells[0].Value = "읽음";
                        for (int i = 0; i < data_list.Count; i++)
                        {
                            arr = data_list[i].Split('\t');

                            if (Girdview1.Rows[e.RowIndex].Cells[1].Value.ToString() == arr[1])
                            {
                                if (arr[0] == "안읽음")
                                {
                                    arr[0] = "읽음";
                                    data_list.RemoveAt(i);

                                    string line = "";

                                    for (int j = 0; j < arr.Length; j++)
                                    {
                                        line += arr[j] + "\t";
                                    }

                                    data_list.Add(line);

                                    StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Py_info\\all_py.txt");
                                    foreach (var kk in data_list)
                                    {
                                        sw.WriteLine(kk.ToString());
                                    }
                                    sw.Close();
                                    sw.Dispose();

                                    break;
                                }
                            }
                        }
                    }
                    //name = "출장"or"부서"
                    //subtitle = 
                    official_document ofd = new official_document(name, subtitle, person,info,my_code);
                    ofd.complet_fresh += grid_full; //파일에서 읽어서 뿌리기를
                    ofd.return_fresh += return_grid;
                    ofd.ing_fresh += ing_grid;
                    ofd.Show();

                }
                else if (name == "휴가")                                               // 선택한 행의 앞 두글자가 휴가일 경우
                {

                    
                    if (r == "안읽음")
                    {
                        row.Cells[0].Value = "읽음";
                        for (int i = 0; i < data_list.Count; i++)
                        {
                            arr = data_list[i].Split('\t');

                            if (Girdview1.Rows[e.RowIndex].Cells[1].Value.ToString() == arr[1])
                            {
                                
                                if (arr[0] == "안읽음")
                                {
                                    arr[0] = "읽음";
                                    
                                    data_list.RemoveAt(i);
                                    
                                    string line = "";
                                    
                                    for (int j = 0; j < arr.Length; j++)
                                    {
                                        line += arr[j] + "\t";
                                    }

                                    data_list.Add(line);
                                    
                                    StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Py_info\\all_py.txt");
                                    foreach (var kk in data_list)
                                    {
                                        sw.WriteLine(kk.ToString());
                                    }
                                    sw.Close();
                                    sw.Dispose();
                                        
                                    break;
                                }
                            }
                        }
                    }
                    official_document ofd = new official_document(name, subtitle, person,info, my_code);
                    ofd.complet_fresh += grid_full;
                    ofd.return_fresh += return_grid;
                    ofd.ing_fresh += ing_grid;
                    ofd.Show();
                }
                else if (name == "급여")                                               // 선택한 행의 앞 두글자가 급여일 경우
                {
                    if (r == "안읽음")
                    {
                        row.Cells[0].Value = "읽음";
                        for (int i = 0; i < data_list.Count; i++)
                        {
                            arr = data_list[i].Split('\t');

                            if (Girdview1.Rows[e.RowIndex].Cells[1].Value.ToString() == arr[1])
                            {
                                if (arr[0] == "안읽음")
                                {
                                    arr[0] = "읽음";
                                    data_list.RemoveAt(i);

                                    string line = "";

                                    for (int j = 0; j < arr.Length; j++)
                                    {
                                        line += arr[j] + "\t";
                                    }

                                    data_list.Add(line);

                                    StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Py_info\\all_py.txt");
                                    foreach (var kk in data_list)
                                    {
                                        sw.WriteLine(kk.ToString());
                                    }
                                    sw.Close();
                                    sw.Dispose();

                                    break;
                                }
                            }
                        }
                    }
                    official_document ofd = new official_document(name, subtitle, person,info, my_code);
                    ofd.complet_fresh += grid_full;
                    ofd.return_fresh += return_grid;
                    ofd.ing_fresh += ing_grid;
                    ofd.Show();
                }
                else if (name == "퇴사")                                               // 선택한 행의 앞 두글자가 은퇴일 경우
                {
                    if (r == "안읽음")
                    {
                        row.Cells[0].Value = "읽음";
                        for (int i = 0; i < data_list.Count; i++)
                        {
                            arr = data_list[i].Split('\t');

                            if (Girdview1.Rows[e.RowIndex].Cells[1].Value.ToString() == arr[1])
                            {
                                if (arr[0] == "안읽음")
                                {
                                    arr[0] = "읽음";
                                    data_list.RemoveAt(i);

                                    string line = "";

                                    for (int j = 0; j < arr.Length; j++)
                                    {
                                        line += arr[j] + "\t";
                                    }

                                    data_list.Add(line);

                                    StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Py_info\\all_py.txt");
                                    foreach (var kk in data_list)
                                    {
                                        sw.WriteLine(kk.ToString());
                                    }
                                    sw.Close();
                                    sw.Dispose();

                                    break;
                                }
                            }
                        }
                    }
                    official_document ofd = new official_document(name, subtitle, person,info, my_code);
                    ofd.complet_fresh += grid_full;
                    ofd.return_fresh += return_grid;
                    ofd.ing_fresh += ing_grid;
                    ofd.Show();
                }
                else if (name == "부서")                                               // 선택한 행의 앞 두글자가 부서일 경우
                {
                    if (r == "안읽음")
                    {
                        row.Cells[0].Value = "읽음";
                        for (int i = 0; i < data_list.Count; i++)
                        {
                            arr = data_list[i].Split('\t');

                            if (Girdview1.Rows[e.RowIndex].Cells[1].Value.ToString() == arr[1])
                            {
                                if (arr[0] == "안읽음")
                                {
                                    arr[0] = "읽음";
                                    data_list.RemoveAt(i);

                                    string line = "";

                                    for (int j = 0; j < arr.Length; j++)
                                    {
                                        line += arr[j] + "\t";
                                    }

                                    data_list.Add(line);

                                    StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Py_info\\all_py.txt");
                                    foreach (var kk in data_list)
                                    {
                                        sw.WriteLine(kk.ToString());
                                    }
                                    sw.Close();
                                    sw.Dispose();

                                    break;
                                }
                            }
                        }
                    }
                    official_document ofd = new official_document(name, subtitle, person,info, my_code);
                    ofd.complet_fresh += grid_full;
                    ofd.return_fresh += return_grid;
                    ofd.ing_fresh += ing_grid;
                    ofd.Show();
                }
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void start_Date_ValueChanged(object sender, EventArgs e)                         // 시작날짜
        {

        }
        private void End_Date_ValueChanged(object sender, EventArgs e)                           // 끝날짜
        {

        }

        private void datetime_button_Click(object sender, EventArgs e)                         // 날짜 검색
        {
            try
            {
                DateTime dt = start_Date.Value;
                string date = dt.ToString().Substring(0, 10);
                int real_date = Convert.ToInt32(date.Replace("-", ""));          // 시작날짜 담기 ex) 20221201

                DateTime dt2 = End_Date.Value;
                string date2 = dt2.ToString().Substring(0, 10);
                int real_date2 = Convert.ToInt32(date2.Replace("-", ""));          // 마지막 날짜 담기 ex) 20221231




                List<string> lines = new List<string>();
                Fill_of_text_Box fi = new Fill_of_text_Box();
                lines= fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재상태.txt");

                Girdview1.Rows.Clear();
                status_Gridview.Rows.Clear();

                int rank = myCheck();

                if(rank==2)
                {

                    foreach (var line in lines)
                    {
                        try
                        {
                            string[] arr = line.Split('\t');
                            string[] grid = new string[6];
                            //제목    신청자 사번  신청일 상태  비고
                            DateTime.TryParse(arr[4], out DateTime day);
                            if (arr[1] == "대기중")
                            {
                                if (dt <= day && day <= dt2)
                                {
                                    grid[0] = "[" + arr[0] + "]" + arr[0] + " 신청입니다.";
                                    grid[1] = arr[2];
                                    grid[2] = arr[3];
                                    grid[3] = arr[4];
                                    grid[4] = arr[1];
                                    grid[5] = "";
                                    status_Gridview.Rows.Add(grid);
                                }
                            }
                        }
                        catch
                        {

                        }
                           
                    }
                }
                else if(rank==1)
                {

                    foreach (var line in lines)
                    {
                        try
                        {
                            string[] arr = line.Split('\t');
                            string[] grid = new string[6];
                            //제목    신청자 사번  신청일 상태  비고
                            DateTime.TryParse(arr[4], out DateTime day);
                            if (arr[3] == my_code)
                            {
                                if (dt <= day && day <= dt2)
                                {
                                    grid[0] = "[" + arr[0] + "]" + arr[0] + " 신청입니다.";
                                    grid[1] = arr[2];
                                    grid[2] = arr[3];
                                    grid[3] = arr[4];
                                    grid[4] = arr[1];
                                    grid[5] = "본인";
                                    status_Gridview.Rows.Add(grid);
                                }
                            }
                        }
                        catch
                        {

                        }
                        
                    }





                }
                else if(rank==3)
                {

                    foreach (var line in lines)
                    {
                        try
                        {
                            string[] arr = line.Split('\t');
                            string[] grid = new string[6];
                            //제목    신청자 사번  신청일 상태  비고
                            DateTime.TryParse(arr[4], out DateTime day);
                            if (arr[1] == "팀장승인완료")
                            {
                                if (dt <= day && day <= dt2)
                                {
                                    grid[0] = "[" + arr[0] + "]" + arr[0] + " 신청입니다.";
                                    grid[1] = arr[2];
                                    grid[2] = arr[3];
                                    grid[3] = arr[4];
                                    grid[4] = arr[1];
                                    grid[5] = "승인신청";
                                    status_Gridview.Rows.Add(grid);
                                }
                            }
                        }
                        catch
                        {

                        }
                        
                    }
                }








                List<string> approval_ref = new List<string>();

                approval_ref = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재참조.txt");
                foreach (var re in approval_ref)
                {
                    try
                    {
                        string[] brr = re.Split('\t');
                        for (int i = 5; i < brr.Length; i++)
                        {
                            //유형 신청일 상태 비고

                            if (brr[i] == my_code) //본인이 참조에 있다면
                            {

                                foreach (var line in lines)
                                {
                                    try
                                    {
                                        string[] li = line.Split('\t');
                                        string[] grid = new string[6];
                                        if (brr[0] == li[0] && brr[2] == li[3] && brr[3] == li[4])
                                        {
                                            DateTime.TryParse(li[4], out DateTime day);
                                            if (dt <= day && day <= dt2)
                                            {
                                                grid[0] = "[" + li[0] + "]" + li[0] + " 신청입니다.";
                                                grid[1] = li[2];
                                                grid[2] = li[3];
                                                grid[3] = li[4];
                                                grid[4] = li[1];
                                                grid[5] = "수신참조";
                                                status_Gridview.Rows.Add(grid);


                                                break;

                                            }
                                        }
                                    }
                                    catch
                                    {

                                    }
                                    
                                }
                                break;
                            }
                        }
                    }
                    catch
                    {

                    }
                    
                }


                int r_num = 1;
                foreach (DataGridViewRow row in status_Gridview.Rows)                    // 앞에 순번 붙이기
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
                    status_Gridview.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                }




                foreach (string data in data_list)                    // 결재관리판넬
                {
                    try
                    {
                        int check = Convert.ToInt32(data.Split('\t')[4].ToString().Replace("-", ""));
                        if (real_date <= check && check <= real_date2)
                        {
                            if (btn_name == null || btn_name == "결재관리")
                            {
                                if (type_search_combo.SelectedItem.ToString() == "구분")
                                {
                                    Girdview1.Rows.Add(data.Split('\t'));
                                }
                                if (data.Split('\t')[1].ToString().Contains(type_search_combo.SelectedItem.ToString()))
                                {
                                    Girdview1.Rows.Add(data.Split('\t'));
                                }
                            }
                            else if (data.Split('\t')[5].ToString().Contains(btn_name))
                            {
                                if (type_search_combo.SelectedItem.ToString() == "구분")
                                {
                                    Girdview1.Rows.Add(data.Split('\t'));
                                }
                                if (data.Split('\t')[1].ToString().Contains(type_search_combo.SelectedItem.ToString()))
                                {
                                    Girdview1.Rows.Add(data.Split('\t'));
                                }
                            }
                        }
                    }
                    catch
                    {

                    }
                    
                }
                Girdview1.CurrentCell = null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void label3_Click(object sender, EventArgs e)                          // 게시판 - 성명 라벨 클릭시
        {
        }

        private void Girdview1_CellContentClick(object sender, DataGridViewCellEventArgs e) // 결재관리 게시판
        {

        }
        private void grid_full(string text)                          // 완료에 대한 대리자             (결재관리에 있는 그리드뷰 얘를 파일에서 읽어서 쭉 뿌리는 코드)
        {
            //한번 클리어
            
            DataGridViewRow row = Girdview1.SelectedRows[0];
            //MessageBox.Show(text);

            row.Cells[5].Value = "완료";
            row.Cells[3].Value = text;

            UserCheck uc = new UserCheck();
            data_list = uc.search_user(@"C:\\Erp_main\\Py_info\\all_py.txt");

            string[] arr = new string[8];

            for (int i = 0; i < data_list.Count; i++)
            {
                arr = data_list[i].Split('\t');
                if (row.Cells[1].Value.ToString() == arr[1])
                {
                    arr[3] = text;

                    arr[5] = "완료";

                    data_list.RemoveAt(i);

                    string line = "";

                    for (int j = 0; j < arr.Length; j++)
                    {
                        line += arr[j] + "\t";
                    }
                    data_list.Add(line);

                    StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Py_info\\all_py.txt");
                    foreach (var kk in data_list)
                    {
                        sw.WriteLine(kk.ToString());
                    }
                    sw.Close();
                    sw.Dispose();





                    break;
                }
            }
        }
        private void return_grid()                                           // 반려에 대한 대리자
        {
            DataGridViewRow row = Girdview1.SelectedRows[0];

            row.Cells[5].Value = "반려";

            UserCheck uc = new UserCheck();
            data_list = uc.search_user(@"C:\\Erp_main\\Py_info\\all_py.txt");

            string[] arr = new string[8];

            for (int i = 0; i < data_list.Count; i++)
            {
                arr = data_list[i].Split('\t');
                if (row.Cells[1].Value.ToString() == arr[1])
                {
                    arr[5] = "반려";

                    data_list.RemoveAt(i);

                    string line = "";

                    for (int j = 0; j < arr.Length; j++)
                    {
                        line += arr[j] + "\t";
                    }
                    data_list.Add(line);

                    StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Py_info\\all_py.txt");
                    foreach (var kk in data_list)
                    {
                        sw.WriteLine(kk.ToString());
                    }
                    sw.Close();
                    sw.Dispose();

                    break;
                }
            }
        }
        private void ing_grid()                                   // 진행중에 대한 대리자
        {
            DataGridViewRow row = Girdview1.SelectedRows[0];

            row.Cells[5].Value = "진행중";

            UserCheck uc = new UserCheck();
            data_list = uc.search_user(@"C:\\Erp_main\\Py_info\\all_py.txt");

            string[] arr = new string[8];

            for (int i = 0; i < data_list.Count; i++)
            {
                arr = data_list[i].Split('\t');
                if (row.Cells[1].Value.ToString() == arr[1])
                {
                    arr[5] = "진행중";

                    data_list.RemoveAt(i);

                    string line = "";

                    for (int j = 0; j < arr.Length; j++)
                    {
                        line += arr[j] + "\t";
                    }
                    data_list.Add(line);

                    StreamWriter sw = new StreamWriter(@"C:\\Erp_main\\Py_info\\all_py.txt");
                    foreach (var kk in data_list)
                    {
                        sw.WriteLine(kk.ToString());
                    }
                    sw.Close();
                    sw.Dispose();

                    break;
                }
            }
        }






        private void type_search_combo_SelectedIndexChanged(object sender, EventArgs e)                 // 종류 구분 콤보박스
        {
            UserCheck ud = new UserCheck();
            data_list = ud.search_user(@"C:\\Erp_main\\Py_info\\all_py.txt");
            status_Gridview.Rows.Clear();
            Girdview1.Rows.Clear();


            string type = type_search_combo.SelectedItem.ToString();


            foreach (string data in data_list)
            {
                try
                {
                    if (data.Split('\t')[1].ToString().Contains(type))
                    {
                        Girdview1.Rows.Add(data.Split('\t'));
                    }
                    else if (type == "구분")
                    {
                        Girdview1.Rows.Add(data.Split('\t'));
                    }
                }
                catch
                {

                }
                
            }

            List<string> lines = new List<string>();

            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재상태.txt");

            int rank = myCheck();

            if (rank == 2)
            {

                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');
                    string[] grid = new string[6];
                    //제목    신청자 사번  신청일 상태  비고

                    try
                    {
                        DateTime.TryParse(arr[4], out DateTime day);
                        if (arr[1] == "대기중")
                        {
                            if (arr[0].Contains(type))
                            {
                                grid[0] = "[" + arr[0] + "]" + arr[0] + " 신청입니다.";
                                grid[1] = arr[2];
                                grid[2] = arr[3];
                                grid[3] = arr[4];
                                grid[4] = arr[1];
                                grid[5] = "";
                                status_Gridview.Rows.Add(grid);
                            }
                        }
                    }
                    catch
                    {

                    }

                }
            }
            else if (rank == 1)
            {
                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');
                    string[] grid = new string[6];
                    //제목    신청자 사번  신청일 상태  비고
                    DateTime.TryParse(arr[4], out DateTime day);
                    if (arr[3] == my_code)
                    {
                        if (arr[0].Contains(type))
                        {
                            grid[0] = "[" + arr[0] + "]" + arr[0] + " 신청입니다.";
                            grid[1] = arr[2];
                            grid[2] = arr[3];
                            grid[3] = arr[4];
                            grid[4] = arr[1];
                            grid[5] = "본인";
                            status_Gridview.Rows.Add(grid);
                        }
                    }
                }
            }
            else if (rank == 3)
            {

                foreach (var line in lines)
                {
                    string[] arr = line.Split('\t');
                    string[] grid = new string[6];
                    //제목    신청자 사번  신청일 상태  비고
                    DateTime.TryParse(arr[4], out DateTime day);
                    if (arr[1] == "팀장승인완료")
                    {
                        if (arr[0].Contains(type))
                        {
                            grid[0] = "[" + arr[0] + "]" + arr[0] + " 신청입니다.";
                            grid[1] = arr[2];
                            grid[2] = arr[3];
                            grid[3] = arr[4];
                            grid[4] = arr[1];
                            grid[5] = "승인신청";
                            status_Gridview.Rows.Add(grid);
                        }
                    }
                }
            }



            List<string> approval_ref = new List<string>();
            approval_ref = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재참조.txt");
            foreach (var re in approval_ref)
            {
                string[] arr = re.Split('\t');
                if(arr[0].Contains(type))
                {
                    for (int i = 5; i < arr.Length; i++)
                    {
                        //유형 신청일 상태 비고

                        if (arr[i] == my_code) //본인이 참조에 있다면
                        {
                            foreach (var line in lines)
                            {
                                string[] li = line.Split('\t');
                                string[] grid = new string[6];

                                if (arr[0] == li[0] && arr[2] == li[3] && arr[3] == li[4])//유형,신청자사번,신청일 일치시
                                {

                                    grid[0] = "[" + arr[0] + "]" + arr[0] + " 신청입니다.";
                                    grid[1] = li[2];
                                    grid[2] = li[3];
                                    grid[3] = li[4];
                                    grid[4] = li[1];
                                    grid[5] = "수신참조";
                                    status_Gridview.Rows.Add(grid);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }

            int r_num = 1;
            foreach (DataGridViewRow row in status_Gridview.Rows)                    // 앞에 순번 붙이기
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
                status_Gridview.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            }
        }

        private bool ref_check()
        {
            List<string> lines = new List<string>();
            Fill_of_text_Box fi = new Fill_of_text_Box();
            lines = fi.txt_read(@"C:\\Erp_main\\Approval_info\\결재참조.txt");

            foreach(var line in lines)
            {
                string[] arr = line.Split('\t');
                for(int i = 4; i <arr.Length;i++)
                {
                    if(arr[i] == my_code)
                    {

                        return true;

                    }
                }
            }
            return false;
        }



        private void status_Gridview_CellContentClick(object sender, DataGridViewCellEventArgs e)                      // 신청현황 셀 클릭시
        {
            DataGridViewRow row = status_Gridview.SelectedRows[0];

            string name = row.Cells[0].Value.ToString().Substring(1, 2);
            string number = row.Cells[2].Value.ToString();
            string date = row.Cells[3].Value.ToString();



            // 1. 일반사원
            //status = 내가한 신청 - 승인불가지만 신청서는 나타남
            //gird = 조건없이 모든 사원에 대한 결재자체를출력 수신참조가 있다면 문서 출력

            // 2. 인사팀장
            //status = 모든 신청현황 - 클릭하면 신청서
            //gird = 조건없이 모든 사원에 대한 결재자체를출력 수신참조가 있다면 문서 출력

            // 3. 사장||대표
            // status => 인사팀장이 신청한 신청서출력
            // gird 클릭가능 + 최종승인


            int rank = myCheck();


            if(rank == 2)//인사팀장
            {
                if(row.Cells[4].Value.ToString()=="대기중")
                {
                    request_Form r_f = new request_Form(name, number, date);
                    r_f.Show();
                }
            }
            else if(rank==3)//대표,사장
            {

            }
            else if(rank==1)
            {



                request_Form rf = new request_Form(name, number, date);
                rf.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
