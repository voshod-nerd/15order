/*
 * Created by SharpDevelop.
 * User: Шайманов
 * Date: 20.07.2015
 * Time: 9:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.IO;

namespace For15order
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void FillTableClick(object sender, EventArgs e)
		{
			
		try 
			{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.FileName=textBoxNameFile.Text;
			dialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"  ;
			
			
			
			// строка соединения
			string connectstring="Data Source=192.168.0.10,1433;Network Library=DBMSSOCN;Initial Catalog=forest_mtr_2;User ID=sa;Password=19800123;";
			GetDataFromBase GetData = new GetDataFromBase(connectstring);
			
			
			string sqlcommand = "select  datediff(day,DATE_1,DATE_2) as c,* from sk_Sluch where Id_Schet_Lpu in (select ID from J_Schet_Lpu where PYear="+comboBoxYear.Text+" and PMonth="+comboBoxMonth.Text+" and plat='84001') and N_Upd=0 and profil is not null";
			DataTable tableOMS = GetData.ConnectAndGetData(sqlcommand);
			sqlcommand = "select  datediff(day,DATE_1,DATE_2) as c,* from sk_Sluch where Id_Schet_Lpu in (select ID from J_Schet_Lpu where PYear="+comboBoxYear.Text+" and PMonth="+comboBoxMonth.Text+" and plat='84')  and profil is not null";
			DataTable tableTFOMS = GetData.ConnectAndGetData(sqlcommand);
			
			// создание xml
			CreateXml create = new CreateXml();
			
			 
			if (dialog.ShowDialog() == DialogResult.OK) 
			{
			create.CreateXmlFile(dialog.FileName,comboBoxYear.Text,comboBoxMonth.Text,tableOMS,tableTFOMS);
			}
			/// отображение таблицы
			//DataGridView1.DataSource=tableTFOMS.DefaultView;;
			
			
			// просто баловство
			decimal profil = 68;
			IEnumerable<decimal> results = from myRow in tableTFOMS.AsEnumerable()
			where myRow.Field<decimal>("Profil") == profil
            	select myRow.Field<decimal>("SUMV");
          
           decimal sum= results.Sum();
		
         
			} 
			catch(Exception error) {MessageBox.Show(error.StackTrace+" ////"+error.Message);}
			
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			
			
		}
	}
}
 