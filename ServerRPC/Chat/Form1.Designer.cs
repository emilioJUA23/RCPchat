namespace Chat
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnexecute = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbcomando_s = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tb_client_port = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rtb_Output = new System.Windows.Forms.RichTextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_client_subscribe = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbnick = new System.Windows.Forms.TextBox();
            this.tbmessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbcomando = new System.Windows.Forms.TextBox();
            this.tb_server_tcp_chan = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnexecute);
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.tbcomando_s);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.tb_client_port);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtb_Output);
            this.splitContainer1.Panel2.Controls.Add(this.button6);
            this.splitContainer1.Panel2.Controls.Add(this.button5);
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.btn_client_subscribe);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.tbnick);
            this.splitContainer1.Panel2.Controls.Add(this.tbmessage);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.tbcomando);
            this.splitContainer1.Panel2.Controls.Add(this.tb_server_tcp_chan);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Size = new System.Drawing.Size(1003, 563);
            this.splitContainer1.SplitterDistance = 333;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnexecute
            // 
            this.btnexecute.BackColor = System.Drawing.Color.Transparent;
            this.btnexecute.Location = new System.Drawing.Point(255, 77);
            this.btnexecute.Name = "btnexecute";
            this.btnexecute.Size = new System.Drawing.Size(75, 23);
            this.btnexecute.TabIndex = 17;
            this.btnexecute.Text = "execute";
            this.btnexecute.UseVisualStyleBackColor = false;
            this.btnexecute.Click += new System.EventHandler(this.btnexecute_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 116);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(307, 433);
            this.listBox1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "command line";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "puerto de instancia:";
            // 
            // tbcomando_s
            // 
            this.tbcomando_s.Location = new System.Drawing.Point(15, 79);
            this.tbcomando_s.Name = "tbcomando_s";
            this.tbcomando_s.Size = new System.Drawing.Size(234, 20);
            this.tbcomando_s.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(255, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "stop server";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tb_client_port
            // 
            this.tb_client_port.Location = new System.Drawing.Point(15, 25);
            this.tb_client_port.Name = "tb_client_port";
            this.tb_client_port.Size = new System.Drawing.Size(153, 20);
            this.tb_client_port.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "start server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtb_Output
            // 
            this.rtb_Output.Location = new System.Drawing.Point(38, 194);
            this.rtb_Output.Name = "rtb_Output";
            this.rtb_Output.Size = new System.Drawing.Size(449, 355);
            this.rtb_Output.TabIndex = 21;
            this.rtb_Output.Text = "";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(493, 164);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 20;
            this.button6.Text = "send";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(493, 124);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 19;
            this.button5.Text = "execute";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(369, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 23);
            this.button4.TabIndex = 18;
            this.button4.Text = "leave the chat";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_client_subscribe
            // 
            this.btn_client_subscribe.Location = new System.Drawing.Point(185, 38);
            this.btn_client_subscribe.Name = "btn_client_subscribe";
            this.btn_client_subscribe.Size = new System.Drawing.Size(97, 23);
            this.btn_client_subscribe.TabIndex = 17;
            this.btn_client_subscribe.Text = "registrar ususario";
            this.btn_client_subscribe.UseVisualStyleBackColor = true;
            this.btn_client_subscribe.Click += new System.EventHandler(this.btn_client_subscribe_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "nickname";
            // 
            // tbnick
            // 
            this.tbnick.Location = new System.Drawing.Point(38, 39);
            this.tbnick.Name = "tbnick";
            this.tbnick.Size = new System.Drawing.Size(141, 20);
            this.tbnick.TabIndex = 13;
            // 
            // tbmessage
            // 
            this.tbmessage.Location = new System.Drawing.Point(38, 167);
            this.tbmessage.Name = "tbmessage";
            this.tbmessage.Size = new System.Drawing.Size(449, 20);
            this.tbmessage.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "command line";
            // 
            // tbcomando
            // 
            this.tbcomando.Location = new System.Drawing.Point(38, 126);
            this.tbcomando.Name = "tbcomando";
            this.tbcomando.Size = new System.Drawing.Size(449, 20);
            this.tbcomando.TabIndex = 10;
            // 
            // tb_server_tcp_chan
            // 
            this.tb_server_tcp_chan.Location = new System.Drawing.Point(38, 65);
            this.tb_server_tcp_chan.Name = "tb_server_tcp_chan";
            this.tb_server_tcp_chan.Size = new System.Drawing.Size(244, 20);
            this.tb_server_tcp_chan.TabIndex = 9;
            this.tb_server_tcp_chan.Text = "localhost:8080";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(288, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "join chat!";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 563);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "chat_service";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbcomando_s;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox tb_server_tcp_chan;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbmessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbcomando;
        private System.Windows.Forms.Button btn_client_subscribe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_client_port;
        private System.Windows.Forms.TextBox tbnick;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnexecute;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox rtb_Output;
    }
}

