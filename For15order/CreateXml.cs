/*
 * Created by SharpDevelop.
 * User: Шайманов
 * Date: 20.07.2015
 * Time: 11:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Globalization;
using System.IO;

namespace For15order
{
	/// <summary>
	/// Description of CreateXml.
	/// </summary>
	public class CreateXml
	{
		public CreateXml()
		{
			
		}
		
		public void CreateXmlFile(string filename,string year,string month,DataTable tableOMS, DataTable tableTfoms)
		{
			XDocument document = new XDocument();
			
			XElement ISP_OB = new XElement("ISP_OB");
			XElement ZGLV = new XElement("ZGLV");
			XElement SVD = new XElement("SVD");
			XElement OB_SV = new XElement("OB_SV");
			
			document.Add(ISP_OB);
			ISP_OB.Add(ZGLV);
			ISP_OB.Add(SVD);
			ISP_OB.Add(OB_SV);
			
			/// описание заголовка
			///
			XElement VERSION = new XElement("VERSION");
			XElement DATA = new XElement("DATA");
			XElement FILENAME = new XElement("FILENAME");
			VERSION.Value="1.0";
			DATA.Value=DateTime.Today.ToString("yyyy-MM-dd");
			FILENAME.Value= Path.GetFileNameWithoutExtension(filename);
			ZGLV.Add(VERSION);
			ZGLV.Add(DATA);
			ZGLV.Add(FILENAME);
			// 
			XElement CODE = new XElement("CODE");
			XElement YEAR = new XElement("YEAR");
			XElement MONTH = new XElement("MONTH");
			XElement OBLM = new XElement("OBLM");
			Random rand= new  Random();
			CODE.Value=rand.Next(325,99000000).ToString();
			YEAR.Value = year;
			MONTH.Value= month;
			OBLM.Value="1";
			SVD.Add(CODE);
			SVD.Add(YEAR);
			SVD.Add(MONTH);
			SVD.Add(OBLM);
			///  для тэга ОB_SV
			XElement N_SV = new XElement("N_SV");
			XElement MO_SV= new XElement("MO_SV");
			N_SV.Value = "1";
			MO_SV.Value = "840001";
			OB_SV.Add(N_SV);
			OB_SV.Add(MO_SV);
			/////
			// список всех профилей
			List<decimal> listPrpofil = new List<decimal>();
			// формирование списка профилей по первой таблице больных страховой компании
			IEnumerable<decimal> profillist1 = from myRow in tableOMS.AsEnumerable()
				select  myRow.Field<decimal>("PROFIL");
			
			for (var i = profillist1.GetEnumerator(); i.MoveNext();) {
				try {
					decimal x = i.Current;
					if (listPrpofil.Exists(p => p == x)) {
					} else {
						listPrpofil.Add(x);
					}
				} catch {}
			}
			
			
			// формирование списка профилей по второй таблице больных иногородних
			IEnumerable<decimal> profillist2 = from myRow in tableOMS.AsEnumerable()
				select  myRow.Field<decimal>("PROFIL");
			
			for (var i = profillist2.GetEnumerator(); i.MoveNext();) {
				try {
					decimal x = i.Current;
					if (listPrpofil.Exists(p => p == x)) {
					} else {
						listPrpofil.Add(x);
					}
				} catch {}
			}
			
			// список направлений
			String[] OtnaimList  = {"1","2","3","4","8","9","12"};
			// cписок поиска
			
			String[] FindList = {
				"IDSP=29 OR (IDSP=9 AND ED_COL=0.5) OR IDSP=11", //1
				"IDSP = 41",                            //2
				"IDSP = 30 OR (IDSP =9 AND ED_COL>0.5)",//3
				"USL_OK=2",                             //4
				"USL_OK=1",                             //8
				"USL_OK=1",                             //9
				"IDSP = 24 OR IDSP =25"};               //12
			
			
			for (int i=0;i<OtnaimList.Count();i++)
			{
				
				XElement IT_SV1 = new XElement("IT_SV");
				XElement OT_NAIM1 = new XElement("OT_NAIM");
				OT_NAIM1.Value=OtnaimList[i];
				IT_SV1.Add(OT_NAIM1);
				foreach (int profil in listPrpofil)
				{
					// поиск
					
					XElement PR_SV = new XElement("PR_SV");
					XElement PROFIL_MP = new XElement("PROFIL_MP");
					XElement R_KOL = new XElement("R_KOL");
					XElement R_S_KOL = new XElement("R_S_KOL");
					XElement R_KOL_M = new XElement("R_KOL_M");
					XElement R_S_KOL_M = new XElement("R_S_KOL_M");
					
					PR_SV.Add(PROFIL_MP);
					PR_SV.Add(R_KOL);
					PR_SV.Add(R_S_KOL);
					PR_SV.Add(R_KOL_M);
					PR_SV.Add(R_S_KOL_M);
					
					// поиск по полю IDSP
					PROFIL_MP.Value=profil.ToString();
					
					DataTable findOMS = tableOMS.Clone();
					DataRow[] find1 = tableOMS.Select(FindList[i]);
					
					foreach (DataRow x in find1) {findOMS.ImportRow(x); }

					
					DataTable findTFOMS = tableTfoms.Clone();
					DataRow[] find2= tableTfoms.Select(FindList[i]);
					foreach (DataRow x in find2) { findTFOMS.ImportRow(x);}
					
					
					if (findOMS.Rows.Count>0) {
						
						/// 
						switch (OT_NAIM1.Value) {
								
								case "8":{
									IEnumerable<int> result1 = from myRow in findOMS.AsEnumerable()
										where myRow.Field<decimal>("PROFIL") == profil
										select myRow.Field<int>("C");
									R_KOL.Value= result1.Sum().ToString(CultureInfo.CreateSpecificCulture("en-GB"));
									
									IEnumerable<decimal> result2 = from myRow in findOMS.AsEnumerable()
										where myRow.Field<decimal>("PROFIL") == profil
										select myRow.Field<decimal>("SUMP");
									R_S_KOL.Value=result2.Sum().ToString(CultureInfo.CreateSpecificCulture("en-GB"));
									break;
								}
								case "4":{
									DataRow[] arrayRows =findOMS.Select(" PROFIL="+profil+"");
									CalculatePacientDay patientDay= new CalculatePacientDay();
									R_KOL.Value=(patientDay.calculatePatientDay(arrayRows)).ToString();
									
									IEnumerable<decimal> result2 = from myRow in findOMS.AsEnumerable()
										where myRow.Field<decimal>("PROFIL") == profil
										select myRow.Field<decimal>("SUMP");
									
									R_S_KOL.Value=result2.Sum().ToString(CultureInfo.CreateSpecificCulture("en-GB"));
									break;
								}
								
								
								
								
								
							default:
								{
									IEnumerable<decimal> result1 = from myRow in findOMS.AsEnumerable()
										where myRow.Field<decimal>("PROFIL") == profil
										select myRow.Field<decimal>("SUMP");
									
									R_KOL.Value= result1.Count().ToString(CultureInfo.CreateSpecificCulture("en-GB"));
									R_S_KOL.Value=result1.Sum().ToString(CultureInfo.CreateSpecificCulture("en-GB"));
									break;
								}
								
						}
					} else {R_KOL.Value="0";
						R_S_KOL.Value="0";}
					
					//////////////////////////////////////////
					if (findTFOMS.Rows.Count>0) {
						
						switch (OT_NAIM1.Value) {
								case "8": {
									IEnumerable<int> result2 = from myRow in findTFOMS.AsEnumerable()
										where myRow.Field<decimal>("PROFIL") == profil
										select myRow.Field<int>("c");
									R_KOL_M.Value=result2.Sum().ToString(CultureInfo.CreateSpecificCulture("en-GB"));
									
									IEnumerable<decimal> result3 = from myRow in findTFOMS.AsEnumerable()
										where myRow.Field<decimal>("PROFIL") == profil
										select myRow.Field<decimal>("SUMP");
									R_S_KOL_M.Value=result3.Sum().ToString(CultureInfo.CreateSpecificCulture("en-GB"));
									break;
								}
								case "4":{
									
									DataRow[] arrayRows =findTFOMS.Select(" PROFIL="+profil+"");
					
									CalculatePacientDay patientDay= new CalculatePacientDay();
									
									
									R_KOL_M.Value=(patientDay.calculatePatientDay(arrayRows)).ToString();
									
									IEnumerable<decimal> result2 = from myRow in findTFOMS.AsEnumerable()
										where myRow.Field<decimal>("PROFIL") == profil
										select myRow.Field<decimal>("SUMP");
									R_S_KOL_M.Value=result2.Sum().ToString(CultureInfo.CreateSpecificCulture("en-GB"));
									break;
								}
								
								
								default: {
									
									IEnumerable<decimal> result2 = from myRow in findTFOMS.AsEnumerable()
										where myRow.Field<decimal>("PROFIL") == profil
										select myRow.Field<decimal>("SUMP");
									
									R_KOL_M.Value= result2.Count().ToString(CultureInfo.CreateSpecificCulture("en-GB"));
									R_S_KOL_M.Value=result2.Sum().ToString(CultureInfo.CreateSpecificCulture("en-GB"));
									break;
								}
						}
					}
					else {R_KOL_M.Value="0";
						R_S_KOL_M.Value="0";
					}
					
					
					IT_SV1.Add(PR_SV);
					
				}
				
				OB_SV.Add(IT_SV1);
				
			}
			
			
			// Теперь для записей
			DataTable[] listtable;
			listtable = new DataTable[2];
			listtable[0]=tableOMS;
			listtable[1]=tableTfoms;
			
			
			int zap = 1;
			foreach (DataTable tb in listtable)
			{
				foreach (DataRow x in tb.Rows)
				{
					XElement ZAP = new XElement("ZAP");
					XElement N_ZAP = new XElement("N_ZAP");
					XElement PACIENT= new XElement("PACIENT");
					XElement SLUCH = new XElement("SLUCH");
					
					N_ZAP.Value=zap.ToString();
					zap++;
					
					ZAP.Add(N_ZAP);
					ZAP.Add(PACIENT);
					ZAP.Add(SLUCH);
					
					
					XElement SMO_OK = new XElement("SMO_OK");
					XElement W = new XElement("W");
					XElement VZST= new XElement("VZST");
					
					PACIENT.Add(SMO_OK);
					PACIENT.Add(W);
					PACIENT.Add(VZST);
					
					
					SMO_OK.Value= ((string)x["SMO_OK"]);
					W.Value= ((decimal)x["W"]).ToString();
					TimeSpan diffentTime = (DateTime)x["DATE_1"]-(DateTime)x["DR"];
					// получаем возраст
					VZST.Value  = (Convert.ToInt32(diffentTime.TotalDays/360)).ToString();
					
					
					
					
					XElement IDCASE = new XElement("IDCASE");
					XElement USL_OK = new XElement("USL_OK");
					XElement VIDPOM = new XElement("VIDPOM");
					XElement FOR_POM = new XElement("FOR_POM");
					XElement PCEL= new XElement("PCEL");
					XElement LPU = new XElement("LPU");
					XElement PROFIL = new XElement("PROFIL");
					XElement DATE_I = new XElement("DATE_I");
					XElement SUM = new XElement("SUM");
					
					SLUCH.Add(IDCASE);
					SLUCH.Add(USL_OK);
					SLUCH.Add(VIDPOM);
					SLUCH.Add(FOR_POM);
					SLUCH.Add(LPU);
					SLUCH.Add(PROFIL);
					SLUCH.Add(DATE_I);
					SLUCH.Add(SUM);
					
					decimal usl= (decimal)x["USL_OK"];
					
					if (usl==3) {
						
						decimal idsp = (Decimal)x["IDSP"];

						if ((idsp == 29))
						{
							PCEL.Value = "2";
							FOR_POM.AddAfterSelf(PCEL);
							
						}

						if ((idsp == 42))
						{
							PCEL.Value = "2";
							FOR_POM.AddAfterSelf(PCEL);
							
						}
						
						if (idsp == 30)
						{
							PCEL.Value = "1";
							FOR_POM.AddAfterSelf(PCEL);
						}

						if (idsp == 41)
						{
							PCEL.Value = "0";
							FOR_POM.AddAfterSelf(PCEL);
						}

						if (idsp == 9)
						{
							Decimal ed = (Decimal)(x["ED_COL"]);
							double eds = Convert.ToDouble(ed);

							if (eds > 0.5) { PCEL.Value = "1";   FOR_POM.AddAfterSelf(PCEL);}
							else
							{ PCEL.Value = "2";  FOR_POM.AddAfterSelf(PCEL); }
							
						}
						
						
						if (idsp==11) {PCEL.Value = "1";  FOR_POM.AddAfterSelf(PCEL);}
						
					}
					
					IDCASE.Value = ((decimal)x["IDCASE"]).ToString();
					USL_OK.Value= ((decimal)x["USL_OK"]).ToString();
					VIDPOM.Value = ((decimal)x["VIDPOM"]).ToString();
					FOR_POM.Value =((decimal)x["FOR_POM"]).ToString();
					LPU.Value="840001";
					PROFIL.Value = ((decimal)x["PROFIL"]).ToString();
					TimeSpan PeriodHealing  = (DateTime)x["DATE_2"]-(DateTime)x["DATE_1"];
					if (PeriodHealing.Days==0) {DATE_I.Value="1";} else
					{
						if (PeriodHealing.Days>100) {DATE_I.Value = "1";} else {
							DATE_I.Value = (PeriodHealing.Days).ToString();}
					}
					SUM.Value = ((Decimal)x["SUMP"]).ToString(CultureInfo.CreateSpecificCulture("en-GB"));
					ISP_OB.Add(ZAP);
				}
			}
			
			
			
			
			
			document.Save(filename);
			
			
		}
		
	}
}
