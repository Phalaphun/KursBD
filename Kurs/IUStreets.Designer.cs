namespace Kurs
{
    partial class IUStreets
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
            this.idBox = new System.Windows.Forms.TextBox();
            this.addressAttributeBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.exampleBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.updateBut = new System.Windows.Forms.Button();
            this.insertBut = new System.Windows.Forms.Button();
            this.exitBut = new System.Windows.Forms.Button();
            this.clearBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // idBox
            // 
            this.idBox.Enabled = false;
            this.idBox.Location = new System.Drawing.Point(145, 54);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(155, 20);
            this.idBox.TabIndex = 0;
            // 
            // addressAttributeBox
            // 
            this.addressAttributeBox.Location = new System.Drawing.Point(145, 80);
            this.addressAttributeBox.Name = "addressAttributeBox";
            this.addressAttributeBox.Size = new System.Drawing.Size(155, 20);
            this.addressAttributeBox.TabIndex = 1;
            this.addressAttributeBox.TextChanged += new System.EventHandler(this.AddressAttributeBox_TextChanged);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(145, 130);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(155, 20);
            this.nameBox.TabIndex = 3;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // exampleBox
            // 
            this.exampleBox.Location = new System.Drawing.Point(432, 54);
            this.exampleBox.Name = "exampleBox";
            this.exampleBox.Size = new System.Drawing.Size(225, 20);
            this.exampleBox.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(145, 107);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Тип";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Вставить после?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Название";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Результат";
            // 
            // updateBut
            // 
            this.updateBut.Location = new System.Drawing.Point(328, 164);
            this.updateBut.Name = "updateBut";
            this.updateBut.Size = new System.Drawing.Size(108, 42);
            this.updateBut.TabIndex = 11;
            this.updateBut.Text = "Update";
            this.updateBut.UseVisualStyleBackColor = true;
            this.updateBut.Click += new System.EventHandler(this.updateBut_Click);
            // 
            // insertBut
            // 
            this.insertBut.Location = new System.Drawing.Point(328, 212);
            this.insertBut.Name = "insertBut";
            this.insertBut.Size = new System.Drawing.Size(108, 39);
            this.insertBut.TabIndex = 12;
            this.insertBut.Text = "Insert";
            this.insertBut.UseVisualStyleBackColor = true;
            this.insertBut.Click += new System.EventHandler(this.insertBut_Click);
            // 
            // exitBut
            // 
            this.exitBut.Location = new System.Drawing.Point(328, 257);
            this.exitBut.Name = "exitBut";
            this.exitBut.Size = new System.Drawing.Size(108, 45);
            this.exitBut.TabIndex = 13;
            this.exitBut.Text = "Exit";
            this.exitBut.UseVisualStyleBackColor = true;
            this.exitBut.Click += new System.EventHandler(this.exitBut_Click);
            // 
            // clearBut
            // 
            this.clearBut.Location = new System.Drawing.Point(228, 212);
            this.clearBut.Name = "clearBut";
            this.clearBut.Size = new System.Drawing.Size(94, 39);
            this.clearBut.TabIndex = 14;
            this.clearBut.Text = "Clear";
            this.clearBut.UseVisualStyleBackColor = true;
            this.clearBut.Click += new System.EventHandler(this.clearBut_Click);
            // 
            // IUStreets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 314);
            this.Controls.Add(this.clearBut);
            this.Controls.Add(this.exitBut);
            this.Controls.Add(this.insertBut);
            this.Controls.Add(this.updateBut);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.exampleBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.addressAttributeBox);
            this.Controls.Add(this.idBox);
            this.Name = "IUStreets";
            this.Text = "IUStreets";
            this.Load += new System.EventHandler(this.IUStreets_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.TextBox addressAttributeBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox exampleBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button updateBut;
        private System.Windows.Forms.Button insertBut;
        private System.Windows.Forms.Button exitBut;
        private System.Windows.Forms.Button clearBut;
    }
}