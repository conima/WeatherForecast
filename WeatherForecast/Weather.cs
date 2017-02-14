using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace WeatherForecast
{
    class Weather
    {
        /// <summary>
        /// The function that gets the forecast for the next seven days.
        /// </summary>
        /// <param name="location">City or ZIP code</param>
        /// <returns></returns>
        public static List<Conditions> GetForecast(string location)
        {
            try
            {
                List<Conditions> conditions = new List<Conditions>();

                XmlDocument xmlConditions = new XmlDocument();
                xmlConditions.Load(string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&mode=xml&units=metric&cnt=7&APPID=61904743ddaada5e99c1a79aa9ddd748", location));

                if (xmlConditions.SelectSingleNode("weatherdata/forecast/problem_cause") != null)
                {
                    conditions = null;
                }
                else
                {
                    foreach (XmlNode node in xmlConditions.SelectNodes("/weatherdata/forecast/time"))
                    {
                        Conditions condition = new Conditions();
                        condition.City = xmlConditions.SelectSingleNode("/weatherdata/location/name").InnerText;
                        condition.Country = xmlConditions.SelectSingleNode("/weatherdata/location/country").InnerText;
                        condition.Condition = node.SelectSingleNode("clouds").Attributes["value"].InnerText;
                        condition.Var = node.SelectSingleNode("symbol").Attributes["var"].InnerText;
                        condition.TempHigh = node.SelectSingleNode("temperature").Attributes["max"].InnerText;
                        condition.TempLow = node.SelectSingleNode("temperature").Attributes["min"].InnerText;
                        condition.Day = node.Attributes["day"].InnerText;
                        conditions.Add(condition);
                    }
                }

                return conditions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Probably this location doesn't exist ... \n Or, check your Internet connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
