﻿namespace Client_form
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
            this.btnleave = new System.Windows.Forms.Button();
            this.btn_client_subscribe = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_client_port = new System.Windows.Forms.TextBox();
            this.tbnick = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tb_server_tcp_chan = new System.Windows.Forms.TextBox();
            this.btnjoin = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnleave
            // 
            this.btnleave.Location = new System.Drawing.Point(579, 67);
            this.btnleave.Name = "btnleave";
            this.btnleave.Size = new System.Drawing.Size(75, 34);
            this.btnleave.TabIndex = 30;
            this.btnleave.Text = "leave the chat";
            this.btnleave.UseVisualStyleBackColor = true;
            this.btnleave.Click += new System.EventHandler(this.btnleave_Click);
            // 
            // btn_client_subscribe
            // 
            this.btn_client_subscribe.Location = new System.Drawing.Point(355, 24);
            this.btn_client_subscribe.Name = "btn_client_subscribe";
            this.btn_client_subscribe.Size = new System.Drawing.Size(97, 23);
            this.btn_client_subscribe.TabIndex = 29;
            this.btn_client_subscribe.Text = "registrar ususario";
            this.btn_client_subscribe.UseVisualStyleBackColor = true;
            this.btn_client_subscribe.Click += new System.EventHandler(this.btn_client_subscribe_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "puerto cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "nickname";
            // 
            // tb_client_port
            // 
            this.tb_client_port.Location = new System.Drawing.Point(178, 27);
            this.tb_client_port.Name = "tb_client_port";
            this.tb_client_port.Size = new System.Drawing.Size(150, 20);
            this.tb_client_port.TabIndex = 26;
            // 
            // tbnick
            // 
            this.tbnick.Location = new System.Drawing.Point(12, 27);
            this.tbnick.Name = "tbnick";
            this.tbnick.Size = new System.Drawing.Size(141, 20);
            this.tbnick.TabIndex = 25;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(12, 155);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(601, 20);
            this.textBox5.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "command line";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 114);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(601, 20);
            this.textBox4.TabIndex = 22;
            // 
            // tb_server_tcp_chan
            // 
            this.tb_server_tcp_chan.Location = new System.Drawing.Point(12, 53);
            this.tb_server_tcp_chan.Name = "tb_server_tcp_chan";
            this.tb_server_tcp_chan.Size = new System.Drawing.Size(561, 20);
            this.tb_server_tcp_chan.TabIndex = 21;
            this.tb_server_tcp_chan.Text = "tcp://localhost:8080/chat";
            // 
            // btnjoin
            // 
            this.btnjoin.Location = new System.Drawing.Point(579, 38);
            this.btnjoin.Name = "btnjoin";
            this.btnjoin.Size = new System.Drawing.Size(75, 23);
            this.btnjoin.TabIndex = 20;
            this.btnjoin.Text = "join chat!";
            this.btnjoin.UseVisualStyleBackColor = true;
            this.btnjoin.Click += new System.EventHandler(this.btnjoin_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(12, 193);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(601, 355);
            this.listBox2.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 560);
            this.Controls.Add(this.btnleave);
            this.Controls.Add(this.btn_client_subscribe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_client_port);
            this.Controls.Add(this.tbnick);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.tb_server_tcp_chan);
            this.Controls.Add(this.btnjoin);
            this.Controls.Add(this.listBox2);
            this.Name = "Form1";
            this.Text = "Chat_client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnleave;
        private System.Windows.Forms.Button btn_client_subscribe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_client_port;
        private System.Windows.Forms.TextBox tbnick;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox tb_server_tcp_chan;
        private System.Windows.Forms.Button btnjoin;
        private System.Windows.Forms.ListBox listBox2;
    }
}

