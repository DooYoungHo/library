namespace WindowsFormsApp2
{
    partial class payment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.payment_panel = new System.Windows.Forms.Panel();
            this.type_search_combo = new System.Windows.Forms.ComboBox();
            this.datetime_button = new System.Windows.Forms.Button();
            this.End_Date = new System.Windows.Forms.DateTimePicker();
            this.start_Date = new System.Windows.Forms.DateTimePicker();
            this.search = new System.Windows.Forms.TextBox();
            this.search_button = new System.Windows.Forms.Button();
            this.Girdview1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.division = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.request_btn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.status_Gridview = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.payment_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Girdview1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.status_Gridview)).BeginInit();
            this.SuspendLayout();
            // 
            // payment_panel
            // 
            this.payment_panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.payment_panel.Controls.Add(this.type_search_combo);
            this.payment_panel.Controls.Add(this.datetime_button);
            this.payment_panel.Controls.Add(this.End_Date);
            this.payment_panel.Controls.Add(this.start_Date);
            this.payment_panel.Controls.Add(this.search);
            this.payment_panel.Controls.Add(this.search_button);
            this.payment_panel.Location = new System.Drawing.Point(107, 126);
            this.payment_panel.Name = "payment_panel";
            this.payment_panel.Size = new System.Drawing.Size(1123, 436);
            this.payment_panel.TabIndex = 31;
            this.payment_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.payment_panel_Paint);
            // 
            // type_search_combo
            // 
            this.type_search_combo.BackColor = System.Drawing.SystemColors.Window;
            this.type_search_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type_search_combo.FormattingEnabled = true;
            this.type_search_combo.Location = new System.Drawing.Point(143, 20);
            this.type_search_combo.Name = "type_search_combo";
            this.type_search_combo.Size = new System.Drawing.Size(94, 20);
            this.type_search_combo.TabIndex = 49;
            this.type_search_combo.SelectedIndexChanged += new System.EventHandler(this.type_search_combo_SelectedIndexChanged);
            // 
            // datetime_button
            // 
            this.datetime_button.Location = new System.Drawing.Point(724, 16);
            this.datetime_button.Name = "datetime_button";
            this.datetime_button.Size = new System.Drawing.Size(43, 26);
            this.datetime_button.TabIndex = 48;
            this.datetime_button.Text = "검색";
            this.datetime_button.UseVisualStyleBackColor = true;
            this.datetime_button.Click += new System.EventHandler(this.datetime_button_Click);
            // 
            // End_Date
            // 
            this.End_Date.Location = new System.Drawing.Point(508, 20);
            this.End_Date.Name = "End_Date";
            this.End_Date.Size = new System.Drawing.Size(200, 21);
            this.End_Date.TabIndex = 47;
            this.End_Date.ValueChanged += new System.EventHandler(this.End_Date_ValueChanged);
            // 
            // start_Date
            // 
            this.start_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.start_Date.Location = new System.Drawing.Point(265, 20);
            this.start_Date.Name = "start_Date";
            this.start_Date.Size = new System.Drawing.Size(200, 21);
            this.start_Date.TabIndex = 46;
            this.start_Date.ValueChanged += new System.EventHandler(this.start_Date_ValueChanged);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(856, 20);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(100, 21);
            this.search.TabIndex = 4;
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(962, 16);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(43, 26);
            this.search_button.TabIndex = 3;
            this.search_button.Text = "검색";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // Girdview1
            // 
            this.Girdview1.AllowUserToAddRows = false;
            this.Girdview1.AllowUserToDeleteRows = false;
            this.Girdview1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Girdview1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Girdview1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Girdview1.ColumnHeadersHeight = 70;
            this.Girdview1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column7,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column8,
            this.Column6});
            this.Girdview1.Location = new System.Drawing.Point(107, 186);
            this.Girdview1.MultiSelect = false;
            this.Girdview1.Name = "Girdview1";
            this.Girdview1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Girdview1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Girdview1.RowHeadersWidth = 62;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.Girdview1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Girdview1.RowTemplate.Height = 23;
            this.Girdview1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Girdview1.Size = new System.Drawing.Size(1123, 389);
            this.Girdview1.TabIndex = 5;
            this.Girdview1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Girdview1_CellClick);
            this.Girdview1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Girdview1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "구분";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 123;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column7.HeaderText = "제목";
            this.Column7.MinimumWidth = 8;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column7.Width = 272;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.HeaderText = "성명";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 110;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.HeaderText = "수신자";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Width = 113;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "날짜";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.Width = 128;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.HeaderText = "상태";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.Width = 92;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column8.HeaderText = "비고";
            this.Column8.MinimumWidth = 8;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column8.Width = 174;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "첨부파일";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // division
            // 
            this.division.BackColor = System.Drawing.Color.White;
            this.division.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.division.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.division.Font = new System.Drawing.Font("굴림", 10F);
            this.division.FormattingEnabled = true;
            this.division.Location = new System.Drawing.Point(111, 196);
            this.division.Name = "division";
            this.division.Size = new System.Drawing.Size(71, 21);
            this.division.TabIndex = 1;
            this.division.SelectedIndexChanged += new System.EventHandler(this.division_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 52);
            this.button1.TabIndex = 32;
            this.button1.Text = "결재관리";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // request_btn
            // 
            this.request_btn.Location = new System.Drawing.Point(354, 81);
            this.request_btn.Name = "request_btn";
            this.request_btn.Size = new System.Drawing.Size(165, 52);
            this.request_btn.TabIndex = 33;
            this.request_btn.Text = "신청현황";
            this.request_btn.UseVisualStyleBackColor = true;
            this.request_btn.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(583, 81);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 52);
            this.button5.TabIndex = 34;
            this.button5.Text = "진행중";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(805, 81);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(165, 52);
            this.button6.TabIndex = 35;
            this.button6.Text = "반려";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1038, 81);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(165, 52);
            this.button7.TabIndex = 36;
            this.button7.Text = "완료 / 처리";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // status_Gridview
            // 
            this.status_Gridview.AllowUserToAddRows = false;
            this.status_Gridview.AllowUserToDeleteRows = false;
            this.status_Gridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.status_Gridview.ColumnHeadersHeight = 70;
            this.status_Gridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15});
            this.status_Gridview.Location = new System.Drawing.Point(107, 186);
            this.status_Gridview.MultiSelect = false;
            this.status_Gridview.Name = "status_Gridview";
            this.status_Gridview.ReadOnly = true;
            this.status_Gridview.RowHeadersWidth = 62;
            this.status_Gridview.RowTemplate.Height = 23;
            this.status_Gridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.status_Gridview.Size = new System.Drawing.Size(1123, 389);
            this.status_Gridview.TabIndex = 37;
            this.status_Gridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.status_Gridview_CellContentClick);
            // 
            // Column10
            // 
            this.Column10.HeaderText = "제목";
            this.Column10.MinimumWidth = 8;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "신청자";
            this.Column11.MinimumWidth = 8;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "사번";
            this.Column12.MinimumWidth = 8;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "신청일";
            this.Column13.MinimumWidth = 8;
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "상태";
            this.Column14.MinimumWidth = 8;
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "비고";
            this.Column15.MinimumWidth = 8;
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Image = global::WindowsFormsApp2.Properties.Resources.exit_btn;
            this.button2.Location = new System.Drawing.Point(1170, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 48);
            this.button2.TabIndex = 30;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 588);
            this.Controls.Add(this.Girdview1);
            this.Controls.Add(this.division);
            this.Controls.Add(this.status_Gridview);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.request_btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.payment_panel);
            this.Name = "payment";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.payment_panel.ResumeLayout(false);
            this.payment_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Girdview1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.status_Gridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel payment_panel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button request_btn;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.ComboBox division;
        private System.Windows.Forms.DataGridView Girdview1;
        private System.Windows.Forms.DateTimePicker start_Date;
        private System.Windows.Forms.DateTimePicker End_Date;
        private System.Windows.Forms.Button datetime_button;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridView status_Gridview;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.ComboBox type_search_combo;
    }
}