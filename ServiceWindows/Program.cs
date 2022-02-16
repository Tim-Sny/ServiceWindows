using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ServiceWindows.Models;

namespace ServiceWindows
{
    class Program
    {

        static string FormatIntToTime(int t) => string.Format("{0:D2}:{1:D2}", (t+8*60)/60, (t+8*60)%60);

        static void Main(string[] args)
        {
            List<ServiceItem> ServiceItems = new List<ServiceItem>() {
                new ServiceItem() {Time =  5, Name = "Пятиминутная" },
                new ServiceItem() {Time =  7, Name = "Семиминутная" },
                new ServiceItem() {Time = 10, Name = "Десятитиминутная" },
                new ServiceItem() {Time = 15, Name = "Пятнадцатиминутная" }
            };

            Random rnd = new Random();
            ServiceOffice serviceOffice = new ServiceOffice();
            ServicePoint nextPoint;
            int i = 0;

            Console.WriteLine("Номер\tУслуга\t\t{0}\t\t{1}\t\t{2}",
                serviceOffice.ServicePoints[0].Name,
                serviceOffice.ServicePoints[1].Name,
                serviceOffice.ServicePoints[2].Name);

            do
            {
                // Случайная услуга
                int newVisitorService = rnd.Next(4);
                // Продолжительность услуги
                int timeOfCurrentService = ServiceItems[newVisitorService].Time;
                // Получаем окно, которое раньше освободится
                nextPoint = serviceOffice.GetNextPoint();
                // Получаем индекс окна
                int numOfNextPoint = serviceOffice.ServicePoints.IndexOf(nextPoint);
                Console.WriteLine("{0,5}\t{1,6}\t{2,15}\t{3,15}\t{4,15}", ++i, timeOfCurrentService,
                    (numOfNextPoint == 0) ? FormatIntToTime(nextPoint.ReleaseTime) : "",
                    (numOfNextPoint == 1) ? FormatIntToTime(nextPoint.ReleaseTime) : "",
                    (numOfNextPoint == 2) ? FormatIntToTime(nextPoint.ReleaseTime) : "");
                // Передаём время услуги
                nextPoint.SetServiceTime(timeOfCurrentService);
                
            } while (nextPoint.ReleaseTime < 480);

            Console.ReadLine();
        }
    }
}
