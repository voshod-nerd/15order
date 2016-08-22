/*
 * Created by SharpDevelop.
 * User: Шайманов
 * Date: 20.07.2015
 * Time: 9:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace For15order
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.FillTable = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxYear = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxMonth = new System.Windows.Forms.ComboBox();
			this.textBoxNameFile = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.CreateXMLVolume = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// FillTable
			// 
			this.FillTable.Location = new System.Drawing.Point(7, 160);
			this.FillTable.Name = "FillTable";
			this.FillTable.Size = new System.Drawing.Size(121, 37);
			this.FillTable.TabIndex = 1;
			this.FillTable.Text = "Сформировать XML";
			this.FillTable.UseVisualStyleBackColor = true;
			this.FillTable.Click += new System.EventHandler(this.FillTableClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Год";
			// 
			// comboBoxYear
			// 
			this.comboBoxYear.FormattingEnabled = true;
			this.comboBoxYear.Items.AddRange(new object[] {
									"2015",
									"2016",
									"2017",
									"2018",
									"2019",
									"2020"});
			this.comboBoxYear.Location = new System.Drawing.Point(7, 51);
			this.comboBoxYear.Name = "comboBoxYear";
			this.comboBoxYear.Size = new System.Drawing.Size(121, 21);
			this.comboBoxYear.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 85);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Месяц";
			// 
			// comboBoxMonth
			// 
			this.comboBoxMonth.FormattingEnabled = true;
			this.comboBoxMonth.Items.AddRange(new object[] {
									"1",
									"2",
									"3",
									"4",
									"5",
									"6",
									"7",
									"8",
									"9",
									"10",
									"11",
									"12"});
			this.comboBoxMonth.Location = new System.Drawing.Point(7, 121);
			this.comboBoxMonth.Name = "comboBoxMonth";
			this.comboBoxMonth.Size = new System.Drawing.Size(121, 21);
			this.comboBoxMonth.TabIndex = 7;
			// 
			// textBoxNameFile
			// 
			this.textBoxNameFile.Location = new System.Drawing.Point(153, 52);
			this.textBoxNameFile.Name = "textBoxNameFile";
			this.textBoxNameFile.Size = new System.Drawing.Size(131, 20);
			this.textBoxNameFile.TabIndex = 9;
			this.textBoxNameFile.Text = "OR84150001";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(153, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "Название файла";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(550, 316);
			this.tabControl1.TabIndex = 11;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.comboBoxYear);
			this.tabPage1.Controls.Add(this.textBoxNameFile);
			this.tabPage1.Controls.Add(this.FillTable);
			this.tabPage1.Controls.Add(this.comboBoxMonth);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(542, 290);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "По оказанной медицинской помощи";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.textBox1);
			this.tabPage2.Controls.Add(this.CreateXMLVolume);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(542, 290);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Файл со сведениям об утвержденных обьемах";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(7, 34);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(122, 20);
			this.textBox1.TabIndex = 2;
			// 
			// CreateXMLVolume
			// 
			this.CreateXMLVolume.Location = new System.Drawing.Point(7, 70);
			this.CreateXMLVolume.Name = "CreateXMLVolume";
			this.CreateXMLVolume.Size = new System.Drawing.Size(122, 28);
			this.CreateXMLVolume.TabIndex = 1;
			this.CreateXMLVolume.Text = "Сформировать";
			this.CreateXMLVolume.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(7, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "Имя файла";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(574, 352);
			this.Controls.Add(this.tabControl1);
			this.Name = "MainForm";
			this.Text = "По приказу №15";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button CreateXMLVolume;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxNameFile;
		private System.Windows.Forms.ComboBox comboBoxMonth;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxYear;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button FillTable;
	}
}
