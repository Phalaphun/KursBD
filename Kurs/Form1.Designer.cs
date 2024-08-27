using System;

namespace Kurs
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audiencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiallyResponsiblesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.citiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.querryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PropertyToRepriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrashPropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asdToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.insertBut = new System.Windows.Forms.Button();
            this.updateBut = new System.Windows.Forms.Button();
            this.detBut = new System.Windows.Forms.Button();
            this.refreshBut = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tablesToolStripMenuItem,
            this.querryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1377, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // tablesToolStripMenuItem
            // 
            this.tablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildingsToolStripMenuItem,
            this.audiencesToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.materiallyResponsiblesToolStripMenuItem,
            this.departmentsToolStripMenuItem,
            this.deansToolStripMenuItem,
            this.materialsToolStripMenuItem,
            this.citiesToolStripMenuItem,
            this.streetsToolStripMenuItem});
            this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            this.tablesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.tablesToolStripMenuItem.Text = "Таблицы";
            // 
            // buildingsToolStripMenuItem
            // 
            this.buildingsToolStripMenuItem.Name = "buildingsToolStripMenuItem";
            this.buildingsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.buildingsToolStripMenuItem.Text = "Здания";
            this.buildingsToolStripMenuItem.Click += new System.EventHandler(this.BuildingsToolStripMenuItem_Click);
            // 
            // audiencesToolStripMenuItem
            // 
            this.audiencesToolStripMenuItem.Name = "audiencesToolStripMenuItem";
            this.audiencesToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.audiencesToolStripMenuItem.Text = "Аудитории";
            this.audiencesToolStripMenuItem.Click += new System.EventHandler(this.AudiencesToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.propertiesToolStripMenuItem.Text = "Имущество";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItem_Click);
            // 
            // materiallyResponsiblesToolStripMenuItem
            // 
            this.materiallyResponsiblesToolStripMenuItem.Name = "materiallyResponsiblesToolStripMenuItem";
            this.materiallyResponsiblesToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.materiallyResponsiblesToolStripMenuItem.Text = "Материально ответственные";
            this.materiallyResponsiblesToolStripMenuItem.Click += new System.EventHandler(this.MateriallyResponsiblesToolStripMenuItem_Click);
            // 
            // departmentsToolStripMenuItem
            // 
            this.departmentsToolStripMenuItem.Name = "departmentsToolStripMenuItem";
            this.departmentsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.departmentsToolStripMenuItem.Text = "Кафедры";
            this.departmentsToolStripMenuItem.Click += new System.EventHandler(this.MepartmentsToolStripMenuItem_Click);
            // 
            // deansToolStripMenuItem
            // 
            this.deansToolStripMenuItem.Name = "deansToolStripMenuItem";
            this.deansToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.deansToolStripMenuItem.Text = "Деканаты и Директораты";
            this.deansToolStripMenuItem.Click += new System.EventHandler(this.DeansToolStripMenuItem_Click);
            // 
            // materialsToolStripMenuItem
            // 
            this.materialsToolStripMenuItem.Name = "materialsToolStripMenuItem";
            this.materialsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.materialsToolStripMenuItem.Text = "Материал";
            this.materialsToolStripMenuItem.Click += new System.EventHandler(this.MaterialsToolStripMenuItem_Click);
            // 
            // citiesToolStripMenuItem
            // 
            this.citiesToolStripMenuItem.Name = "citiesToolStripMenuItem";
            this.citiesToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.citiesToolStripMenuItem.Text = "Города";
            this.citiesToolStripMenuItem.Click += new System.EventHandler(this.CitiesToolStripMenuItem_Click);
            // 
            // streetsToolStripMenuItem
            // 
            this.streetsToolStripMenuItem.Name = "streetsToolStripMenuItem";
            this.streetsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.streetsToolStripMenuItem.Text = "Улицы";
            this.streetsToolStripMenuItem.Click += new System.EventHandler(this.StreetsToolStripMenuItem_Click);
            // 
            // querryToolStripMenuItem
            // 
            this.querryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PropertyToRepriceToolStripMenuItem,
            this.TrashPropertyToolStripMenuItem,
            this.asdToolStripMenuItem,
            this.asdToolStripMenuItem1});
            this.querryToolStripMenuItem.Name = "querryToolStripMenuItem";
            this.querryToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.querryToolStripMenuItem.Text = "Запросы";
            // 
            // PropertyToRepriceToolStripMenuItem
            // 
            this.PropertyToRepriceToolStripMenuItem.Name = "PropertyToRepriceToolStripMenuItem";
            this.PropertyToRepriceToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.PropertyToRepriceToolStripMenuItem.Text = "Имущество и их аудитории";
            this.PropertyToRepriceToolStripMenuItem.Click += new System.EventHandler(this.PropertyToRepriceToolStripMenuItem_Click);
            // 
            // TrashPropertyToolStripMenuItem
            // 
            this.TrashPropertyToolStripMenuItem.Name = "TrashPropertyToolStripMenuItem";
            this.TrashPropertyToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.TrashPropertyToolStripMenuItem.Text = "Имущество под списание";
            this.TrashPropertyToolStripMenuItem.Click += new System.EventHandler(this.TrashPropertyToolStripMenuItem_Click);
            // 
            // asdToolStripMenuItem
            // 
            this.asdToolStripMenuItem.Name = "asdToolStripMenuItem";
            this.asdToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.asdToolStripMenuItem.Text = "Имущество для переоценки";
            this.asdToolStripMenuItem.Click += new System.EventHandler(this.asdToolStripMenuItem_Click);
            // 
            // asdToolStripMenuItem1
            // 
            this.asdToolStripMenuItem1.Name = "asdToolStripMenuItem1";
            this.asdToolStripMenuItem1.Size = new System.Drawing.Size(242, 22);
            this.asdToolStripMenuItem1.Text = "Полная стоимость имущества";
            this.asdToolStripMenuItem1.Click += new System.EventHandler(this.FullCostToolStripMenuItem1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1353, 250);
            this.dataGridView1.TabIndex = 1;
            // 
            // insertBut
            // 
            this.insertBut.Location = new System.Drawing.Point(12, 324);
            this.insertBut.Name = "insertBut";
            this.insertBut.Size = new System.Drawing.Size(101, 39);
            this.insertBut.TabIndex = 2;
            this.insertBut.Text = "Вставить";
            this.insertBut.UseVisualStyleBackColor = true;
            this.insertBut.Click += new System.EventHandler(this.Button1_Click);
            // 
            // updateBut
            // 
            this.updateBut.Location = new System.Drawing.Point(240, 324);
            this.updateBut.Name = "updateBut";
            this.updateBut.Size = new System.Drawing.Size(101, 39);
            this.updateBut.TabIndex = 3;
            this.updateBut.Text = "Изменить";
            this.updateBut.UseVisualStyleBackColor = true;
            this.updateBut.Click += new System.EventHandler(this.Button2_Click);
            // 
            // detBut
            // 
            this.detBut.Location = new System.Drawing.Point(475, 324);
            this.detBut.Name = "detBut";
            this.detBut.Size = new System.Drawing.Size(101, 39);
            this.detBut.TabIndex = 4;
            this.detBut.Text = "Удалить";
            this.detBut.UseVisualStyleBackColor = true;
            this.detBut.Click += new System.EventHandler(this.Button3_Click);
            // 
            // refreshBut
            // 
            this.refreshBut.Location = new System.Drawing.Point(687, 324);
            this.refreshBut.Name = "refreshBut";
            this.refreshBut.Size = new System.Drawing.Size(101, 39);
            this.refreshBut.TabIndex = 5;
            this.refreshBut.Text = "Обновить";
            this.refreshBut.UseVisualStyleBackColor = true;
            this.refreshBut.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Pictures|*.png|Images|*jpg|Photos|*jpeg";
            this.openFileDialog1.InitialDirectory = "Environment.CurrentDirectory +\"\\images\"";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 448);
            this.Controls.Add(this.refreshBut);
            this.Controls.Add(this.detBut);
            this.Controls.Add(this.updateBut);
            this.Controls.Add(this.insertBut);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Просмотр БД";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem querryToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button insertBut;
        private System.Windows.Forms.Button updateBut;
        private System.Windows.Forms.Button detBut;
        private System.Windows.Forms.Button refreshBut;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audiencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiallyResponsiblesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem citiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PropertyToRepriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TrashPropertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asdToolStripMenuItem1;
    }
}

