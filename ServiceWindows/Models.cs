using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWindows
{
    class Models
    {
        // Услуга
        public class ServiceItem
        {
            public int Time { get; set; }
            public string Name { get; set; }
        }

        // Окно обслуживания
        public class ServicePoint
        {
            public string Name { get; set; }
            public int ReleaseTime { get; set; } = 0; // Ближайшее свободное время

            public void SetServiceTime(int t) 
            {
                ReleaseTime += t;
            }
        }

        // Офис
        public class ServiceOffice
        {
            public List<ServicePoint> ServicePoints;

            public ServicePoint GetNextPoint() => ServicePoints.OrderBy(a => a.ReleaseTime).First();
            
            public ServiceOffice()
            {
                ServicePoints = new List<ServicePoint>();
                ServicePoints.Add(new ServicePoint() { Name = "Окно №1" });
                ServicePoints.Add(new ServicePoint() { Name = "Окно №2" });
                ServicePoints.Add(new ServicePoint() { Name = "Окно №3" });
            }
        }
    }
}
