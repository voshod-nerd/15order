/*
 * Created by SharpDevelop.
 * User: Шайманов
 * Date: 20.07.2015
 * Time: 10:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.SqlClient;

namespace For15order
{
	/// <summary>
	/// Description of GetDataFromBase.
	/// </summary>
	public class GetDataFromBase
	{
		private string ConnectionString;
		
		public GetDataFromBase(string ConnectString )
		{
			this.ConnectionString=ConnectString;
			
		}
		
		
		public DataTable ConnectAndGetData(string sql) 
		{
			SqlConnection connect = new SqlConnection();
			connect.ConnectionString=ConnectionString;
			DataTable exportTable = new DataTable();
			
			try {
				SqlDataAdapter adapter = new SqlDataAdapter(sql,connect);
				connect.Open();
				DataSet  dataset = new DataSet();
				adapter.Fill(dataset);
				exportTable= dataset.Tables[0];
				connect.Close();
			}
			catch (Exception e) {  connect.Close(); throw e;}
		return exportTable;
		
		
		}
		
	}
}
