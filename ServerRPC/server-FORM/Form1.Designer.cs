namespace server_FORM
{
    partial class Form1
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
            this.tb_puertoserver = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnstart = new System.Windows.Forms.Button();
            this.btnstop = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tbcomando = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bntcommadn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_puertoserver
            // 
            this.tb_puertoserver.Location = new System.Drawing.Point(56, 9);
            this.tb_puertoserver.Name = "tb_puertoserver";
            this.tb_puertoserver.Size = new System.Drawing.Size(126, 20);
            this.tb_puertoserver.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Puerto";
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(15, 35);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(75, 23);
            this.btnstart.TabIndex = 2;
            this.btnstart.Text = "start server";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // btnstop
            // 
            this.btnstop.Location = new System.Drawing.Point(107, 35);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(75, 23);
            this.btnstop.TabIndex = 3;
            this.btnstop.Text = "stop server";
            this.btnstop.UseVisualStyleBackColor = true;
            this.btnstop.Click += new System.EventHandler(this.btnstop_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 145);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(459, 199);
            this.listBox1.TabIndex = 4;
            // 
            // tbcomando
            // 
            this.tbcomando.Location = new System.Drawing.Point(15, 86);
            this.tbcomando.Name = "tbcomando";
            this.tbcomando.Size = new System.Drawing.Size(459, 20);
            this.tbcomando.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "command line:";
            // 
            // bntcommadn
            // 
            this.bntcommadn.Location = new System.Drawing.Point(15, 112);
            this.bntcommadn.Name = "bntcommadn";
            this.bntcommadn.Size = new System.Drawing.Size(75, 23);
            this.bntcommadn.TabIndex = 7;
            this.bntcommadn.Text = "ejecutar";
            this.bntcommadn.UseVisualStyleBackColor = true;
            this.bntcommadn.Click += new System.EventHandler(this.bntcommadn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 356);
            this.Controls.Add(this.bntcommadn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbcomando);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnstop);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_puertoserver);
            this.Name = "Form1";
            this.Text = "ChatRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_puertoserver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Button btnstop;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox tbcomando;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bntcommadn;
    }
}

