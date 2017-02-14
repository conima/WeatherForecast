using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast
{
    class Conditions
    {
        string city = "No Data";
        string country = "No Data";
        string day = DateTime.Now.DayOfWeek.ToString();
        string clouds = "No Data";
        string temperature = "No Data";
        string humidity = "No Data";
        string windDirection = "No Data";
        string windSpeed = "No Data";
        string high = "No Data";
        string low = "No Data";
        string var = "No data";

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public string Condition
        {
            get { return clouds; }
            set { clouds = value; }
        }

        public string Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        public string Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }

        public string WindDirection
        {
            get { return windDirection; }
            set { windDirection = value; }
        }

        public string WindSpeed
        {
            get { return windSpeed; }
            set { windSpeed = value; }
        }

        public string Day
        {
            get { return day; }
            set { day = value; }
        }

        public string TempHigh
        {
            get { return high; }
            set { high = value; }
        }

        public string TempLow
        {
            get { return low; }
            set { low = value; }
        }

        public string Var
        {
            get { return var; }
            set { var = value; }
        }
    }
}
