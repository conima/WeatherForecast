using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherForecast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (txtCity.Text == "")
            {
                MessageBox.Show("Please set location!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCity.Focus();
            }
            else
            {
                List<Conditions> conditions = new List<Conditions>();
                conditions = Weather.GetForecast(txtCity.Text);
                if (conditions != null)
                {
                    panel1.Controls.Clear();

                    for (int i = 1; i <= 7; i++)
                    {

                        #region Lables
                        PictureBox icon = new PictureBox();
                        Label city = new Label();
                        Label day = new Label();
                        Label condition = new Label();
                        Label temperature = new Label();
                        Label line = new Label();
                        #endregion

                        #region LableProperties
                        city.Location = new Point(50, 30);
                        city.Font = new Font("Microsoft Sans Serif", 18F);
                        city.Size = new Size(700, 30);
                        city.AutoSize = false;
                        line.AutoSize = false;
                        line.Height = 2;
                        line.BorderStyle = BorderStyle.Fixed3D;
                        line.Width = 850;
                        line.Location = new Point(10, txtCity.Top + (i * 100));
                        icon.Location = new Point(50, line.Bottom + 30);
                        icon.AutoSize = true;
                        day.Location = new Point(200, line.Bottom + 30);
                        day.AutoSize = true;
                        day.Font = new Font("Microsoft Sans Serif", 13F);
                        temperature.Location = new Point(200, line.Bottom + 60);
                        temperature.AutoSize = true;
                        temperature.Font = new Font("Microsoft Sans Serif", 18F);
                        condition.Location = new Point(50, icon.Bottom);
                        condition.AutoSize = true;
                        condition.Font = new Font("Microsoft Sans Serif", 9F);
                        #endregion

                        city.Text = conditions[i - 1].City + " , " + conditions[i - 1].Country;
                        string pic = conditions[i - 1].Var;
                        icon.Load("http://openweathermap.org/img/w/" + pic + ".png");
                        var dateTime = DateTime.Parse(conditions[i - 1].Day);
                        day.Text = String.Format("{0:dddd, dd MMMM yyyy}", dateTime);
                        double temp = Double.Parse(conditions[i - 1].TempHigh);
                        temperature.Text = Math.Round(temp).ToString() + (char)176 + "C";
                        condition.Text = conditions[i - 1].Condition;

                        #region AddControls
                        panel1.Controls.Add(city);
                        panel1.Controls.Add(line);
                        panel1.Controls.Add(icon);
                        panel1.Controls.Add(day);
                        panel1.Controls.Add(condition);
                        panel1.Controls.Add(temperature);
                        #endregion
                    }
                }
                else
                {
                    MessageBox.Show("Data not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
