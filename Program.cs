﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Date
    {
        int iDay;
        int iMonth;
        int iYear;
        public int iNumDay { get; set; }
        public int Num_New_Day { get; set; }
        int new_day;
        int new_month;
        public int nat_shan;

        public Date(int Day, int Month, int Year)
        {
            this.iDay = Day;
            this.iMonth = Month;
            this.iYear = Year;
        }
        public void numDay()
        {
            DateTime data = new DateTime(this.iYear, this.iMonth, this.iDay);
            this.iNumDay = data.DayOfYear;
        }
        public int num_new_day(int iYear,int new_month,int new_day)
        {
            this.new_month = new_month;
            this.new_day = new_day;
            DateTime nat = new DateTime(this.iYear, this.new_month,this.new_day);
            this.Num_New_Day = nat.DayOfYear;
            numDay();
            nat_shan = (iNumDay - Num_New_Day) / 7;
            return (Math.Abs(nat_shan));
        }
    }
    class Program
    {
        public static int NumMonth( string NameMonth )
        {
            int a = 0;
            switch (NameMonth)
            {
                case "Январь": a = 01; break;
                case "Февраль": a = 02; break;
                case "Март": a = 03; break;
                case "Апрель": a = 04; break;
                case "Май": a = 05; break;
                case "Июнь": a = 06; break;
                case "Июль": a = 07; break;
                case "Август": a = 08; break;
                case "Сентябрь": a = 09; break;
                case "Октябрь": a = 10; break;
                case "Ноябрь": a = 11; break;
                case "Декабрь": a = 12; break;
                default: Console.WriteLine("Ошибка!Месяцы введен неправильно."); break;
            }
            return a;
        }
        static void Main(string[] args)
        {       
            int Month = 0;
            Console.Write("Введите день: ");
            int Day = int.Parse(Console.ReadLine());
            if (Day > 31 || Day < 0) Console.WriteLine("Ошибка!День введен неправильно");
            Console.Write("Введите месяц (пример: Апрель, Июль, Декабрь): ");         

            Month = NumMonth(Console.ReadLine());
            
            Console.Write("Введите год: ");
            int Year = int.Parse(Console.ReadLine());
            Date d = new Date(Day, Month, Year);
            d.numDay();
            Console.WriteLine("Номер дня с начала года : "+d.iNumDay);

            Console.Write("\r\nВвод новой даты для расчета отставания в неделях\r\nВведите день: ");
            int new_day = int.Parse(Console.ReadLine());
            if (new_day > 31 || new_day < 0) Console.WriteLine("Ошибка!День введен неправильно");
            int new_month = 0;
            Console.Write("Введите новый месяц : ");
            new_month = NumMonth(Console.ReadLine());
        
            d.num_new_day(Year, new_month, new_day);
          
            
            Console.Write("Заданный день отстоит на "+d.num_new_day(Year, new_month, new_day)+" нед.");
            Console.ReadKey();
        }
    }
}
