namespace WindowsFormsApp2
{
    partial class Business_trip
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
            this.ok_panel = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.after_calendar = new System.Windows.Forms.MonthCalendar();
            this.before_calendar = new System.Windows.Forms.MonthCalendar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.after_date_btn = new System.Windows.Forms.Button();
            this.after_date_label = new System.Windows.Forms.Label();
            this.check_label = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.trip_reason = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.name_tb = new System.Windows.Forms.TextBox();
            this.code_tb = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.trip_space = new System.Windows.Forms.TextBox();
            this.manager_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.manager_p_num = new System.Windows.Forms.TextBox();
            this.manager_e_mail = new System.Windows.Forms.TextBox();
            this.trip_name = new System.Windows.Forms.TextBox();
            this.today_tb = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.before_date_label = new System.Windows.Forms.Label();
            this.beforedate_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.ok_panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ok_panel);
            this.panel1.Controls.Add(this.after_calendar);
            this.panel1.Controls.Add(this.before_calendar);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.check_label);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.trip_reason);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 442);
            this.panel1.TabIndex = 0;
            // 
            // ok_panel
            // 
            this.ok_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ok_panel.Controls.Add(this.button3);
            this.ok_panel.Controls.Add(this.label17);
            this.ok_panel.Location = new System.Drawing.Point(231, 128);
            this.ok_panel.Name = "ok_panel";
            this.ok_panel.Size = new System.Drawing.Size(416, 192);
            this.ok_panel.TabIndex = 20;
            this.ok_panel.Visible = false;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("휴먼매직체", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(170, 131);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 30);
            this.button3.TabIndex = 1;
            this.button3.Text = "확인";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("휴먼매직체", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(3, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(408, 40);
            this.label17.TabIndex = 0;
            this.label17.Text = "신청이 완료되었습니다.";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // after_calendar
            // 
            this.after_calendar.Location = new System.Drawing.Point(262, 228);
            this.after_calendar.MaxSelectionCount = 1;
            this.after_calendar.Name = "after_calendar";
            this.after_calendar.TabIndex = 26;
            this.after_calendar.Visible = false;
            this.after_calendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.after_calendar_DateSelected);
            // 
            // before_calendar
            // 
            this.before_calendar.Location = new System.Drawing.Point(35, 228);
            this.before_calendar.MaxSelectionCount = 1;
            this.before_calendar.Name = "before_calendar";
            this.before_calendar.TabIndex = 25;
            this.before_calendar.Visible = false;
            this.before_calendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.before_calendar_DateSelected);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.after_date_btn);
            this.panel3.Controls.Add(this.after_date_label);
            this.panel3.Location = new System.Drawing.Point(327, 187);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(128, 37);
            this.panel3.TabIndex = 24;
            // 
            // after_date_btn
            // 
            this.after_date_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.after_date_btn.Image = global::WindowsFormsApp2.Properties.Resources.date;
            this.after_date_btn.Location = new System.Drawing.Point(85, -1);
            this.after_date_btn.Name = "after_date_btn";
            this.after_date_btn.Size = new System.Drawing.Size(41, 38);
            this.after_date_btn.TabIndex = 26;
            this.after_date_btn.UseVisualStyleBackColor = true;
            this.after_date_btn.Click += new System.EventHandler(this.after_date_btn_Click);
            // 
            // after_date_label
            // 
            this.after_date_label.AutoSize = true;
            this.after_date_label.Font = new System.Drawing.Font("휴먼매직체", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.after_date_label.Location = new System.Drawing.Point(3, 9);
            this.after_date_label.Name = "after_date_label";
            this.after_date_label.Size = new System.Drawing.Size(41, 19);
            this.after_date_label.TabIndex = 26;
            this.after_date_label.Text = "기간";
            // 
            // check_label
            // 
            this.check_label.Font = new System.Drawing.Font("휴먼매직체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.check_label.Location = new System.Drawing.Point(548, 316);
            this.check_label.Name = "check_label";
            this.check_label.Size = new System.Drawing.Size(278, 15);
            this.check_label.TabIndex = 21;
            this.check_label.Text = "양식다시확인";
            this.check_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("휴먼매직체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(66, 300);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 20);
            this.label15.TabIndex = 19;
            this.label15.Text = "사유";
            // 
            // trip_reason
            // 
            this.trip_reason.Location = new System.Drawing.Point(141, 296);
            this.trip_reason.Name = "trip_reason";
            this.trip_reason.Size = new System.Drawing.Size(284, 21);
            this.trip_reason.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(294, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "~";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("휴먼매직체", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(24, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 30);
            this.label9.TabIndex = 11;
            this.label9.Text = "출장신청 양식";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("휴먼매직체", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(461, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 30);
            this.button2.TabIndex = 10;
            this.button2.Text = "취소";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("휴먼매직체", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(350, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "결재신청";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.86902F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.13097F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.trip_space, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.manager_name, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.manager_p_num, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.manager_e_mail, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.trip_name, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.today_tb, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("굴림", 15F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(28, 79);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(798, 211);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.name_tb);
            this.panel4.Controls.Add(this.code_tb);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Location = new System.Drawing.Point(113, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(365, 44);
            this.panel4.TabIndex = 22;
            // 
            // name_tb
            // 
            this.name_tb.Location = new System.Drawing.Point(3, 9);
            this.name_tb.Name = "name_tb";
            this.name_tb.Size = new System.Drawing.Size(100, 30);
            this.name_tb.TabIndex = 8;
            // 
            // code_tb
            // 
            this.code_tb.Font = new System.Drawing.Font("굴림", 15F);
            this.code_tb.Location = new System.Drawing.Point(228, 8);
            this.code_tb.Name = "code_tb";
            this.code_tb.Size = new System.Drawing.Size(108, 30);
            this.code_tb.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.Location = new System.Drawing.Point(170, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 20);
            this.label16.TabIndex = 21;
            this.label16.Text = "사번";
            // 
            // trip_space
            // 
            this.trip_space.Location = new System.Drawing.Point(113, 152);
            this.trip_space.Name = "trip_space";
            this.trip_space.Size = new System.Drawing.Size(362, 30);
            this.trip_space.TabIndex = 14;
            // 
            // manager_name
            // 
            this.manager_name.Location = new System.Drawing.Point(626, 3);
            this.manager_name.Name = "manager_name";
            this.manager_name.Size = new System.Drawing.Size(167, 30);
            this.manager_name.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("휴먼매직체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(3, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 43);
            this.label2.TabIndex = 1;
            this.label2.Text = "신청일";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("휴먼매직체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(484, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 62);
            this.label5.TabIndex = 4;
            this.label5.Text = "출장 회사명";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("휴먼매직체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(484, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 43);
            this.label8.TabIndex = 7;
            this.label8.Text = "담당자 메일";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("휴먼매직체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(3, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 43);
            this.label3.TabIndex = 2;
            this.label3.Text = "신청기간";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("휴먼매직체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(484, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 43);
            this.label7.TabIndex = 6;
            this.label7.Text = "담당자번호";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("휴먼매직체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(3, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 62);
            this.label4.TabIndex = 3;
            this.label4.Text = "출장 지역";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("휴먼매직체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(484, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 63);
            this.label6.TabIndex = 5;
            this.label6.Text = "담당자명";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("휴먼매직체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "신청자";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // manager_p_num
            // 
            this.manager_p_num.Location = new System.Drawing.Point(626, 66);
            this.manager_p_num.Name = "manager_p_num";
            this.manager_p_num.Size = new System.Drawing.Size(167, 30);
            this.manager_p_num.TabIndex = 11;
            // 
            // manager_e_mail
            // 
            this.manager_e_mail.Location = new System.Drawing.Point(626, 109);
            this.manager_e_mail.Name = "manager_e_mail";
            this.manager_e_mail.Size = new System.Drawing.Size(167, 30);
            this.manager_e_mail.TabIndex = 13;
            // 
            // trip_name
            // 
            this.trip_name.Location = new System.Drawing.Point(626, 152);
            this.trip_name.Name = "trip_name";
            this.trip_name.Size = new System.Drawing.Size(167, 30);
            this.trip_name.TabIndex = 15;
            // 
            // today_tb
            // 
            this.today_tb.Location = new System.Drawing.Point(113, 66);
            this.today_tb.Name = "today_tb";
            this.today_tb.Size = new System.Drawing.Size(294, 30);
            this.today_tb.TabIndex = 12;
            this.today_tb.TextChanged += new System.EventHandler(this.today_tb_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.before_date_label);
            this.panel2.Controls.Add(this.beforedate_btn);
            this.panel2.Location = new System.Drawing.Point(113, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(132, 37);
            this.panel2.TabIndex = 23;
            // 
            // before_date_label
            // 
            this.before_date_label.AutoSize = true;
            this.before_date_label.Font = new System.Drawing.Font("휴먼매직체", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.before_date_label.Location = new System.Drawing.Point(4, 8);
            this.before_date_label.Name = "before_date_label";
            this.before_date_label.Size = new System.Drawing.Size(41, 19);
            this.before_date_label.TabIndex = 25;
            this.before_date_label.Text = "기간";
            // 
            // beforedate_btn
            // 
            this.beforedate_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.beforedate_btn.Image = global::WindowsFormsApp2.Properties.Resources.date;
            this.beforedate_btn.Location = new System.Drawing.Point(89, -1);
            this.beforedate_btn.Name = "beforedate_btn";
            this.beforedate_btn.Size = new System.Drawing.Size(41, 38);
            this.beforedate_btn.TabIndex = 25;
            this.beforedate_btn.UseVisualStyleBackColor = true;
            this.beforedate_btn.Click += new System.EventHandler(this.beforedate_btn_Click);
            // 
            // Business_trip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 442);
            this.Controls.Add(this.panel1);
            this.Name = "Business_trip";
            this.Text = "Business_trip";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ok_panel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox trip_space;
        private System.Windows.Forms.TextBox manager_name;
        private System.Windows.Forms.TextBox name_tb;
        private System.Windows.Forms.TextBox manager_p_num;
        private System.Windows.Forms.TextBox manager_e_mail;
        private System.Windows.Forms.TextBox trip_name;
        private System.Windows.Forms.TextBox today_tb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox trip_reason;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox code_tb;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel ok_panel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label check_label;
        private System.Windows.Forms.MonthCalendar after_calendar;
        private System.Windows.Forms.MonthCalendar before_calendar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button after_date_btn;
        private System.Windows.Forms.Label after_date_label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label before_date_label;
        private System.Windows.Forms.Button beforedate_btn;
    }
}