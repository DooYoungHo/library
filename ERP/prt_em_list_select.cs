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
    public partial class prt_em_list_select : Form
    {



        private List<string> list= new List<string>();


        public delegate void DataPassEventHandler(List<string[]> data);
        public event DataPassEventHandler DataPassEvent;




        public prt_em_list_select(string[] str)
        {
            InitializeComponent();

            cpy_name.Text = str[0];
            prt_name.Text = str[1];
            prt_code.Text = str[2];
            prt_type.Text = str[3];




            em_rank_list(); //직급콤보박스 추가
            
        }

        private void em_rank_list()
        {
            List<string> lines = new List<string>();


            List<string>rank_list = new List<string>();
            Person_info pi = new Person_info();
            lines = pi.search_em();

            //이름,사번,부서,직급
            foreach (string line in lines) //중복없이 직급만남기기
            {
                string[] arr = line.Split('\t');
                rank_list.Add(arr[3]);
            }
            lines.Clear();
            lines = rank_list.Distinct().ToList();

            prt_rank_combo.Items.Add("전체");
            foreach(var lin in lines)
            {
                prt_rank_combo.Items.Add(lin);
            }
            


            
        }




        private void em_prt_namelist() //콤보박스에서 선택한 직급의 사원만 노출
        {
            List<string> lines = new List<string>();
            Person_info pi = new Person_info();


            List<string> members = new List<string>();
            

            Fill_of_text_Box fi = new Fill_of_text_Box();
            members= fi.txt_read(@"C:\\Erp_main\\Prt_info\\프로젝트팀원.txt");
            DateTime now = DateTime.Now;

            string state = "가능";

            lines = pi.search_em();

            for(int i = 0; i < prt_em_grid_view.Rows.Count; i++) 
            {
                prt_em_grid_view.Rows.Clear();
            }
            //이름,사번,부서,직급
            foreach(string line in lines) 
            {
                string[] arr = line.Split('\t');

                if (arr[2].Contains("개발")||arr[2].Contains("외주")) //개발부서중에서
                {
                    if(prt_rank_combo.SelectedItem == null || prt_rank_combo.SelectedItem.ToString() == "전체" || prt_rank_combo.SelectedItem.ToString() == "제작자") //전체or null을 선택했을때
                    {
                        string[] arr1 = { arr[0], arr[1], arr[3], arr[8], arr[9], state };
                        prt_em_grid_view.Rows.Add(arr1);
                    }
                    else if (prt_rank_combo.SelectedItem.ToString() == arr[3]) //선택한 직급만 
                    {
                        //이름 사번 직급,개발수준,개발스택 0 1 3 8 9
                        foreach(var m in members)
                        {
                            string[] date = m.Split('\t');

                            if (DateTime.TryParse(date[0],out DateTime sd) && (DateTime.TryParse(date[1],out DateTime ed)))
                            {

                                if(sd <= now && now<=ed) //오늘날짜가 프로젝트 진행기간 사이에 있다면
                                {
                                    if (m.Contains(arr[1])) //개발부서의 선택 직급에 있는 사원이 저 기간에 프로젝트 참여중에 있는지
                                    {//있다면
                                        state = "참여중";
                                    }
                                }
                            }
                        }
                        string[] arr1 = { arr[0], arr[1], arr[3], arr[8], arr[9],state };
                        prt_em_grid_view.Rows.Add(arr1);
                    }
                }
            }

            //em_new_name_text.Text = "";//이름     0
            //em_new_em_code_text.Text = "";//사번 1
            //em_new_dp_text.Text = "";//부서      2
            //em_new_rank_text.Text = ""; //직급   3
            //개발등급(어느정도수준인제)  8
            //개발능력(몇개가능한지) 9
        }

        private void prt_rank_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            em_prt_namelist();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            try 
            {
                var row = prt_em_grid_view.SelectedRows[0];
                //중복검사 후 추가해야됨
                for (int i = 0; i < prt_em_select_grid_view.Rows.Count; i++) //아래 그리드뷰에 선택한게 있는지에대한여부
                {       
                    if (row.Cells[1].Value != null )
                    {
                        if( prt_em_select_grid_view.Rows[i].Cells[1].Value == null)
                        {
                            continue;
                        }
                        if (row.Cells[1].Value.ToString() == prt_em_select_grid_view.Rows[i].Cells[1].Value.ToString())
                        {
                            select_info_label.Visible = true;
                            select_info_label.Text = "이미 선택한 사원입니다.";
                            return;
                        }
                    }
                    else
                    {
                        select_info_label.Visible = true;
                        select_info_label.Text = "선택한 사원이 없습니다.";
                        return;
                    }
                }
                string[] arr1 = new string[5];

                for (int i = 0; i < arr1.Length; i++)
                {
                    arr1[i] = row.Cells[i].Value.ToString();
                }
                if(arr1[4] == "참여중")
                {
                    select_info_label.Visible = true;
                    select_info_label.Text = "선택한 사원은 다른 프로젝트 진행중입니다.";
                    return;
                }
                prt_em_select_grid_view.Rows.Add(arr1);
                select_info_label.Visible = false;
            }
            catch
            {
                select_info_label.Visible = true;
                select_info_label.Text = "다시 확인해 주세요";
            }
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var row = prt_em_select_grid_view.SelectedRows[0];
                prt_em_select_grid_view.Rows.Remove(row);
            }
            catch
            {

            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {


            List<string[]> grid_list = new List<string[]>();
            

            for(int i = 0; i < prt_em_select_grid_view.Rows.Count; i ++)
            {
                string[] colmn = new string[prt_em_select_grid_view.Columns.Count];
                for(int j = 0; j < prt_em_select_grid_view.Columns.Count; j ++)
                {
                    if (prt_em_select_grid_view.Rows[i].Cells[j].Value != null)
                    {
                        colmn[j] = prt_em_select_grid_view.Rows[i].Cells[j].Value.ToString();
                    }
                }
                grid_list.Add(colmn);
            }


            grid_list.RemoveAt(grid_list.Count - 1);
            DataPassEvent(grid_list);
            this.Close();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
