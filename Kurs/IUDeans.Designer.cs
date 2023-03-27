namespace Kurs
{
    partial class IUDeans
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
            this.clearBut = new System.Windows.Forms.Button();
            this.exitBut = new System.Windows.Forms.Button();
            this.insertBut = new System.Windows.Forms.Button();
            this.updateBut = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.idBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // clearBut
            // 
            this.clearBut.Location = new System.Drawing.Point(46, 166);
            this.clearBut.Name = "clearBut";
            this.clearBut.Size = new System.Drawing.Size(94, 39);
            this.clearBut.TabIndex = 28;
            this.clearBut.Text = "Clear";
            this.clearBut.UseVisualStyleBackColor = true;
            this.clearBut.Click += new System.EventHandler(this.clearBut_Click);
            // 
            // exitBut
            // 
            this.exitBut.Location = new System.Drawing.Point(146, 211);
            this.exitBut.Name = "exitBut";
            this.exitBut.Size = new System.Drawing.Size(108, 45);
            this.exitBut.TabIndex = 27;
            this.exitBut.Text = "Exit";
            this.exitBut.UseVisualStyleBackColor = true;
            this.exitBut.Click += new System.EventHandler(this.exitBut_Click);
            // 
            // insertBut
            // 
            this.insertBut.Location = new System.Drawing.Point(146, 166);
            this.insertBut.Name = "insertBut";
            this.insertBut.Size = new System.Drawing.Size(108, 39);
            this.insertBut.TabIndex = 26;
            this.insertBut.Text = "Insert";
            this.insertBut.UseVisualStyleBackColor = true;
            this.insertBut.Click += new System.EventHandler(this.insertBut_Click);
            // 
            // updateBut
            // 
            this.updateBut.Location = new System.Drawing.Point(146, 118);
            this.updateBut.Name = "updateBut";
            this.updateBut.Size = new System.Drawing.Size(108, 42);
            this.updateBut.TabIndex = 25;
            this.updateBut.Text = "Update";
            this.updateBut.UseVisualStyleBackColor = true;
            this.updateBut.Click += new System.EventHandler(this.updateBut_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "ID";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(118, 69);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(159, 20);
            this.nameBox.TabIndex = 21;
            // 
            // idBox
            // 
            this.idBox.Enabled = false;
            this.idBox.Location = new System.Drawing.Point(118, 36);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(159, 20);
            this.idBox.TabIndex = 19;
            // 
            // IUDeans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 333);
            this.Controls.Add(this.clearBut);
            this.Controls.Add(this.exitBut);
            this.Controls.Add(this.insertBut);
            this.Controls.Add(this.updateBut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.idBox);
            this.Name = "IUDeans";
            this.Text = "IUDeans";
            this.Load += new System.EventHandler(this.IUDeans_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clearBut;
        private System.Windows.Forms.Button exitBut;
        private System.Windows.Forms.Button insertBut;
        private System.Windows.Forms.Button updateBut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox idBox;
    }
}