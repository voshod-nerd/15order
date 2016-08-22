/*
 * Created by SharpDevelop.
 * User: соколов
 * Date: 16.08.2016
 * Time: 17:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;

namespace For15order
{
	/// <summary>
	/// Description of CalculatePacientDay.
	/// </summary>
	public class CalculatePacientDay
	{
		public CalculatePacientDay()
		{
			
		}
		
		
		
		
		public int calculatePatientDay(DataRow[] rows)
		{
			int patientDay=0;
			foreach (DataRow row in rows) {
				
				try {
					DateTime begin=(DateTime)row["DATE_1"];
					DateTime end =(DateTime)row["DATE_2"];
					int days=calculateDayBetweenDates(begin,end);
					patientDay=patientDay+days;
				} catch (Exception error) { patientDay=patientDay+0; }
				
			}
			return patientDay;
			
		}
		
		
		
		
		
		private int calculateDayBetweenDates(DateTime begin,DateTime end) {
			int countPatientDay=1;
			do {
				
				begin=begin.AddDays(1);
				if ((begin.DayOfWeek==DayOfWeek.Saturday)|| (begin.DayOfWeek==DayOfWeek.Sunday)) {}
				else countPatientDay++;
			} while(!(begin.CompareTo(end)==0));
			return countPatientDay;
		}
		
	}
}
