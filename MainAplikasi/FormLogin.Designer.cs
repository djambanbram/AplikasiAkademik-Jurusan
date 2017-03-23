namespace MainAplikasi
{
    partial class FormLogin
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
            this.components = new System.ComponentModel.Container();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.gridAwareTextBox1 = new Syncfusion.Windows.Forms.Grid.GridAwareTextBox();
            this.gridAwareTextBox2 = new Syncfusion.Windows.Forms.Grid.GridAwareTextBox();
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnLogin = new Syncfusion.Windows.Forms.ButtonAdv();
            this.SuspendLayout();
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(13, 18);
            this.autoLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(71, 16);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Username";
            // 
            // autoLabel2
            // 
            this.autoLabel2.Location = new System.Drawing.Point(13, 46);
            this.autoLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(68, 16);
            this.autoLabel2.TabIndex = 1;
            this.autoLabel2.Text = "Password";
            // 
            // gridAwareTextBox1
            // 
            this.gridAwareTextBox1.AutoSuggestFormula = false;
            this.gridAwareTextBox1.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.gridAwareTextBox1.EnabledBackColor = System.Drawing.SystemColors.Window;
            this.gridAwareTextBox1.Location = new System.Drawing.Point(122, 12);
            this.gridAwareTextBox1.Name = "gridAwareTextBox1";
            this.gridAwareTextBox1.Size = new System.Drawing.Size(200, 22);
            this.gridAwareTextBox1.TabIndex = 2;
            // 
            // gridAwareTextBox2
            // 
            this.gridAwareTextBox2.AutoSuggestFormula = false;
            this.gridAwareTextBox2.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.gridAwareTextBox2.EnabledBackColor = System.Drawing.SystemColors.Window;
            this.gridAwareTextBox2.Location = new System.Drawing.Point(122, 40);
            this.gridAwareTextBox2.Name = "gridAwareTextBox2";
            this.gridAwareTextBox2.PasswordChar = '*';
            this.gridAwareTextBox2.Size = new System.Drawing.Size(200, 22);
            this.gridAwareTextBox2.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(95, 28);
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(227, 68);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 28);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BeforeTouchSize = new System.Drawing.Size(95, 28);
            this.btnLogin.IsBackStageButton = false;
            this.btnLogin.Location = new System.Drawing.Point(122, 68);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(95, 28);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 104);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridAwareTextBox2);
            this.Controls.Add(this.gridAwareTextBox1);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.autoLabel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.Text = "FormLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Grid.GridAwareTextBox gridAwareTextBox1;
        private Syncfusion.Windows.Forms.Grid.GridAwareTextBox gridAwareTextBox2;
        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private Syncfusion.Windows.Forms.ButtonAdv btnLogin;
    }
}