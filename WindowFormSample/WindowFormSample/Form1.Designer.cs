namespace WindowFormSample
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
            this.solutionLbl = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.val1Txt = new System.Windows.Forms.TextBox();
            this.val2Txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eventInfoLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // solutionLbl
            // 
            this.solutionLbl.AutoSize = true;
            this.solutionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solutionLbl.Location = new System.Drawing.Point(675, 16);
            this.solutionLbl.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.solutionLbl.Name = "solutionLbl";
            this.solutionLbl.Size = new System.Drawing.Size(0, 153);
            this.solutionLbl.TabIndex = 0;
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Location = new System.Drawing.Point(120, 170);
            this.addBtn.Margin = new System.Windows.Forms.Padding(11);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(555, 62);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            this.addBtn.MouseHover += new System.EventHandler(this.mouseOverEvent);
            // 
            // val1Txt
            // 
            this.val1Txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.val1Txt.Location = new System.Drawing.Point(292, 34);
            this.val1Txt.Margin = new System.Windows.Forms.Padding(11);
            this.val1Txt.Name = "val1Txt";
            this.val1Txt.Size = new System.Drawing.Size(383, 46);
            this.val1Txt.TabIndex = 2;
            this.val1Txt.MouseHover += new System.EventHandler(this.mouseOverEvent);
            // 
            // val2Txt
            // 
            this.val2Txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.val2Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.val2Txt.Location = new System.Drawing.Point(292, 102);
            this.val2Txt.Margin = new System.Windows.Forms.Padding(11);
            this.val2Txt.Name = "val2Txt";
            this.val2Txt.Size = new System.Drawing.Size(383, 46);
            this.val2Txt.TabIndex = 3;
            this.val2Txt.MouseHover += new System.EventHandler(this.mouseOverEvent);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "Value 1:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseHover += new System.EventHandler(this.mouseOverEvent);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 46);
            this.label2.TabIndex = 5;
            this.label2.Text = "Value 2:";
            this.label2.MouseHover += new System.EventHandler(this.mouseOverEvent);
            // 
            // eventInfoLbl
            // 
            this.eventInfoLbl.AutoSize = true;
            this.eventInfoLbl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.eventInfoLbl.Location = new System.Drawing.Point(189, 269);
            this.eventInfoLbl.Name = "eventInfoLbl";
            this.eventInfoLbl.Size = new System.Drawing.Size(0, 46);
            this.eventInfoLbl.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(23F, 46F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 337);
            this.Controls.Add(this.eventInfoLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.val2Txt);
            this.Controls.Add(this.val1Txt);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.solutionLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label solutionLbl;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox val1Txt;
        private System.Windows.Forms.TextBox val2Txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label eventInfoLbl;
    }
}

