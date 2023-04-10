namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.login_btn = new System.Windows.Forms.Button();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox_pw = new System.Windows.Forms.TextBox();
            this.label_id = new System.Windows.Forms.Label();
            this.label_pw = new System.Windows.Forms.Label();
            this.login_label_OX = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // login_btn
            // 
            this.login_btn.BackColor = System.Drawing.Color.SkyBlue;
            this.login_btn.FlatAppearance.BorderSize = 0;
            this.login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.login_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.login_btn.Location = new System.Drawing.Point(410, 300);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(200, 57);
            this.login_btn.TabIndex = 3;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // textBox_id
            // 
            this.textBox_id.BackColor = System.Drawing.Color.White;
            this.textBox_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_id.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_id.Location = new System.Drawing.Point(410, 140);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(200, 32);
            this.textBox_id.TabIndex = 4;
            this.textBox_id.TextChanged += new System.EventHandler(this.textBox_id_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(410, 267);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 1);
            this.panel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(410, 182);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 1);
            this.panel3.TabIndex = 7;
            // 
            // textBox_pw
            // 
            this.textBox_pw.BackColor = System.Drawing.Color.White;
            this.textBox_pw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_pw.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_pw.Location = new System.Drawing.Point(410, 229);
            this.textBox_pw.Name = "textBox_pw";
            this.textBox_pw.Size = new System.Drawing.Size(200, 32);
            this.textBox_pw.TabIndex = 8;
            this.textBox_pw.UseSystemPasswordChar = true;
            this.textBox_pw.TextChanged += new System.EventHandler(this.textBox_pw_TextChanged);
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.BackColor = System.Drawing.Color.White;
            this.label_id.Font = new System.Drawing.Font("휴먼편지체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_id.ForeColor = System.Drawing.Color.LightGray;
            this.label_id.Location = new System.Drawing.Point(414, 143);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(30, 24);
            this.label_id.TabIndex = 9;
            this.label_id.Text = "ID";
            // 
            // label_pw
            // 
            this.label_pw.AutoSize = true;
            this.label_pw.BackColor = System.Drawing.Color.White;
            this.label_pw.Font = new System.Drawing.Font("휴먼편지체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_pw.ForeColor = System.Drawing.Color.LightGray;
            this.label_pw.Location = new System.Drawing.Point(414, 233);
            this.label_pw.Name = "label_pw";
            this.label_pw.Size = new System.Drawing.Size(38, 24);
            this.label_pw.TabIndex = 10;
            this.label_pw.Text = "PW";
            // 
            // login_label_OX
            // 
            this.login_label_OX.BackColor = System.Drawing.Color.Transparent;
            this.login_label_OX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_label_OX.ForeColor = System.Drawing.Color.Red;
            this.login_label_OX.Location = new System.Drawing.Point(410, 373);
            this.login_label_OX.Name = "login_label_OX";
            this.login_label_OX.Size = new System.Drawing.Size(200, 16);
            this.login_label_OX.TabIndex = 12;
            this.login_label_OX.Text = "로그인 정보가 일치하지 않습니다.";
            this.login_label_OX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.login_label_OX.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(773, 49);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(313, 403);
            this.panel4.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.pw_img;
            this.panel2.Location = new System.Drawing.Point(89, 284);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 24);
            this.panel2.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.id_img;
            this.panel5.Location = new System.Drawing.Point(89, 190);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 26);
            this.panel5.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp2.Properties.Resources.erp1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 500);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.label_pw);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.textBox_pw);
            this.Controls.Add(this.login_label_OX);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.textBox_id);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox_pw;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Label label_pw;
        private System.Windows.Forms.Label login_label_OX;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

