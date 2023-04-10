namespace WindowsFormsApp2
{
    partial class new_id_pw_create
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pw_check_info = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.id_overlap_btn = new System.Windows.Forms.Button();
            this.id_info = new System.Windows.Forms.Label();
            this.pw_info = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pw_text_box = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.id_text_box = new System.Windows.Forms.TextBox();
            this.pw_check_text_box = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.new_user_dp = new System.Windows.Forms.Label();
            this.name_label1 = new System.Windows.Forms.Label();
            this.new_user_code = new System.Windows.Forms.Label();
            this.new_user_name = new System.Windows.Forms.Label();
            this.dp_label3 = new System.Windows.Forms.Label();
            this.code_label2 = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pw_check_info);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.id_overlap_btn);
            this.panel1.Controls.Add(this.id_info);
            this.panel1.Controls.Add(this.pw_info);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(19, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 312);
            this.panel1.TabIndex = 13;
            // 
            // pw_check_info
            // 
            this.pw_check_info.AutoSize = true;
            this.pw_check_info.Font = new System.Drawing.Font("휴먼매직체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pw_check_info.Location = new System.Drawing.Point(689, 240);
            this.pw_check_info.Name = "pw_check_info";
            this.pw_check_info.Size = new System.Drawing.Size(73, 21);
            this.pw_check_info.TabIndex = 16;
            this.pw_check_info.Text = "일치여부";
            this.pw_check_info.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(449, 367);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 24);
            this.label9.TabIndex = 12;
            this.label9.Text = "label9";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // id_overlap_btn
            // 
            this.id_overlap_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.id_overlap_btn.Font = new System.Drawing.Font("휴먼매직체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.id_overlap_btn.Location = new System.Drawing.Point(693, 86);
            this.id_overlap_btn.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.id_overlap_btn.Name = "id_overlap_btn";
            this.id_overlap_btn.Size = new System.Drawing.Size(94, 35);
            this.id_overlap_btn.TabIndex = 15;
            this.id_overlap_btn.Text = "중복확인";
            this.id_overlap_btn.UseVisualStyleBackColor = true;
            this.id_overlap_btn.Click += new System.EventHandler(this.id_overlap_btn_Click);
            // 
            // id_info
            // 
            this.id_info.AutoSize = true;
            this.id_info.Font = new System.Drawing.Font("휴먼매직체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.id_info.Location = new System.Drawing.Point(795, 93);
            this.id_info.Name = "id_info";
            this.id_info.Size = new System.Drawing.Size(74, 21);
            this.id_info.TabIndex = 12;
            this.id_info.Text = "중복결과";
            this.id_info.Visible = false;
            // 
            // pw_info
            // 
            this.pw_info.AutoSize = true;
            this.pw_info.Font = new System.Drawing.Font("휴먼매직체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pw_info.Location = new System.Drawing.Point(689, 145);
            this.pw_info.Name = "pw_info";
            this.pw_info.Size = new System.Drawing.Size(74, 21);
            this.pw_info.TabIndex = 11;
            this.pw_info.Text = "보안성 :";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.72464F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.27536F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.pw_text_box, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.id_text_box, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pw_check_text_box, 1, 2);
            this.tableLayoutPanel2.Font = new System.Drawing.Font("휴먼매직체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(316, 83);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.18421F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.81579F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(361, 188);
            this.tableLayoutPanel2.TabIndex = 10;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 36);
            this.label1.TabIndex = 14;
            this.label1.Text = "PW";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pw_text_box
            // 
            this.pw_text_box.BackColor = System.Drawing.Color.SlateGray;
            this.pw_text_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pw_text_box.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.pw_text_box.Location = new System.Drawing.Point(95, 58);
            this.pw_text_box.MaxLength = 16;
            this.pw_text_box.Name = "pw_text_box";
            this.pw_text_box.Size = new System.Drawing.Size(260, 25);
            this.pw_text_box.TabIndex = 11;
            this.pw_text_box.TextChanged += new System.EventHandler(this.pw_text_box_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(3, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 23);
            this.label8.TabIndex = 9;
            this.label8.Text = "PW";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "ID";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // id_text_box
            // 
            this.id_text_box.BackColor = System.Drawing.Color.SlateGray;
            this.id_text_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.id_text_box.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.id_text_box.Location = new System.Drawing.Point(95, 3);
            this.id_text_box.Name = "id_text_box";
            this.id_text_box.Size = new System.Drawing.Size(263, 25);
            this.id_text_box.TabIndex = 10;
            // 
            // pw_check_text_box
            // 
            this.pw_check_text_box.BackColor = System.Drawing.Color.SlateGray;
            this.pw_check_text_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pw_check_text_box.Dock = System.Windows.Forms.DockStyle.Left;
            this.pw_check_text_box.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.pw_check_text_box.Location = new System.Drawing.Point(95, 155);
            this.pw_check_text_box.MaxLength = 16;
            this.pw_check_text_box.Name = "pw_check_text_box";
            this.pw_check_text_box.Size = new System.Drawing.Size(260, 25);
            this.pw_check_text_box.TabIndex = 13;
            this.pw_check_text_box.TextChanged += new System.EventHandler(this.pw_check_text_box_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.20588F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.79412F));
            this.tableLayoutPanel1.Controls.Add(this.new_user_dp, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.name_label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.new_user_code, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.new_user_name, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dp_label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.code_label2, 0, 1);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("휴먼매직체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 83);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(272, 166);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // new_user_dp
            // 
            this.new_user_dp.AutoSize = true;
            this.new_user_dp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.new_user_dp.Location = new System.Drawing.Point(82, 109);
            this.new_user_dp.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.new_user_dp.Name = "new_user_dp";
            this.new_user_dp.Size = new System.Drawing.Size(182, 56);
            this.new_user_dp.TabIndex = 6;
            this.new_user_dp.Text = "부서";
            this.new_user_dp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name_label1
            // 
            this.name_label1.AutoSize = true;
            this.name_label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name_label1.Location = new System.Drawing.Point(8, 1);
            this.name_label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.name_label1.Name = "name_label1";
            this.name_label1.Size = new System.Drawing.Size(59, 53);
            this.name_label1.TabIndex = 1;
            this.name_label1.Text = "이름";
            this.name_label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.name_label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // new_user_code
            // 
            this.new_user_code.AutoSize = true;
            this.new_user_code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.new_user_code.Location = new System.Drawing.Point(82, 55);
            this.new_user_code.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.new_user_code.Name = "new_user_code";
            this.new_user_code.Size = new System.Drawing.Size(182, 53);
            this.new_user_code.TabIndex = 5;
            this.new_user_code.Text = "사번";
            this.new_user_code.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // new_user_name
            // 
            this.new_user_name.AutoSize = true;
            this.new_user_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.new_user_name.Location = new System.Drawing.Point(82, 1);
            this.new_user_name.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.new_user_name.Name = "new_user_name";
            this.new_user_name.Size = new System.Drawing.Size(182, 53);
            this.new_user_name.TabIndex = 4;
            this.new_user_name.Text = "이름";
            this.new_user_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dp_label3
            // 
            this.dp_label3.AutoSize = true;
            this.dp_label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dp_label3.Location = new System.Drawing.Point(8, 109);
            this.dp_label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.dp_label3.Name = "dp_label3";
            this.dp_label3.Size = new System.Drawing.Size(59, 56);
            this.dp_label3.TabIndex = 3;
            this.dp_label3.Text = "부서";
            this.dp_label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dp_label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // code_label2
            // 
            this.code_label2.AutoSize = true;
            this.code_label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.code_label2.Location = new System.Drawing.Point(8, 55);
            this.code_label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.code_label2.Name = "code_label2";
            this.code_label2.Size = new System.Drawing.Size(59, 53);
            this.code_label2.TabIndex = 2;
            this.code_label2.Text = "사번";
            this.code_label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.code_label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.Transparent;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("휴먼매직체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cancel_btn.Location = new System.Drawing.Point(425, 378);
            this.cancel_btn.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 40);
            this.cancel_btn.TabIndex = 11;
            this.cancel_btn.Text = "취소";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.Transparent;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("휴먼매직체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.save_btn.Location = new System.Drawing.Point(325, 378);
            this.save_btn.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 40);
            this.save_btn.TabIndex = 0;
            this.save_btn.Text = "저장";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.cancel_btn);
            this.panel2.Controls.Add(this.save_btn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1041, 432);
            this.panel2.TabIndex = 14;
            // 
            // new_id_pw_create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 432);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("HY견고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "new_id_pw_create";
            this.Text = "new_id_pw_create";
            this.Load += new System.EventHandler(this.new_id_pw_create_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label name_label1;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Label dp_label3;
        private System.Windows.Forms.Label code_label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label new_user_dp;
        private System.Windows.Forms.Label new_user_code;
        private System.Windows.Forms.Label new_user_name;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button id_overlap_btn;
        private System.Windows.Forms.Label id_info;
        private System.Windows.Forms.Label pw_info;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TextBox pw_text_box;
        private System.Windows.Forms.TextBox id_text_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pw_check_text_box;
        private System.Windows.Forms.Label pw_check_info;
        private System.Windows.Forms.Panel panel2;
    }
}