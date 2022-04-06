using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_LatoyaH
{
    public partial class DeleteAppointments : Form
    {
        public static List<KeyValuePair<string, object>> aapList;
        public DeleteAppointments()
        {
            InitializeComponent();
            populateApp();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            stdldateTimePicker1.Enabled = false;
            eddldateTimePicker2.Enabled = false;
            button3.Enabled = false;

        }

        private void populateApp()
        {
            MySqlConnection conn = new MySqlConnection(DataContext.connString);
            try
            {
                string qy = "select appointmentId from appointment";
                MySqlDataAdapter adap = new MySqlDataAdapter(qy, conn);
                conn.Open();
                DataSet ds = new DataSet();
                adap.Fill(ds, "Appoint");
                comboBox1.DisplayMember = "appointmentId";
                comboBox1.ValueMember = "appointmentId";
                comboBox1.DataSource = ds.Tables["Appoint"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue with populating the grid: " + ex);
            }
        }
        private void popFields(List<KeyValuePair<string, object>> aapList)
        {
            //Lambda to set values
            textBox1.Text = aapList.First(kvp => kvp.Key == "customerId").Value.ToString();
            textBox2.Text = aapList.First(kvp => kvp.Key == "title").Value.ToString();
            textBox3.Text = aapList.First(kvp => kvp.Key == "location").Value.ToString();
            textBox4.Text = aapList.First(kvp => kvp.Key == "type").Value.ToString();
            string start = aapList.First(kvp => kvp.Key == "start").Value.ToString();
            string end = aapList.First(kvp => kvp.Key == "end").Value.ToString();
            stdldateTimePicker1.Value = Convert.ToDateTime(start).ToLocalTime();
            eddldateTimePicker2.Value = Convert.ToDateTime(end).ToLocalTime();
            

        }
        public void stAppt(List<KeyValuePair<string, object>> list)
        {
            aapList = list;
        }
        public static List<KeyValuePair<string, object>> gtAppt()
        {
            return aapList;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataRowView datarowview = comboBox1.SelectedItem as DataRowView;
            int id = Convert.ToInt32(comboBox1.SelectedValue);
            var aapList = DataContext.apSearch(id);
            stAppt(aapList);
            if(aapList != null) { button2.Enabled = true; popFields(aapList); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Want to delete?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes) { try
                {
                    var list = gtAppt(); IDictionary<string, object> dictionary = list.ToDictionary(pair => pair.Key, pair => pair.Value);
                    DataContext.DeleteAppt(dictionary); MessageBox.Show("This appointment is deleted."); Hide(); Appointments shAppt = new Appointments(); shAppt.Closed += (c, args) => this.Close();
                    shAppt.Show();
                }
                catch (Exception ex) { MessageBox.Show("There was an error: " + ex); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
