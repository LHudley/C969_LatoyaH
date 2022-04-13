using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace C969_LatoyaH
{
    public partial class CustomerRecords : Form
    {
        private Form MainControl;
         
        public CustomerRecords(Form main)
        {
            InitializeComponent();
            RecordsdataGridView1.DataSource = MainForm.CustLt;
            MainControl = main;
            GetTime();
            
            
        }

        private void CustomerRecords_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> countryDicNm = MainForm.countryDict.ToDictionary(dic => dic.Key, dic => dic.Value.CountryName);
            comboBoxCountry.DataSource = new BindingSource(countryDicNm, null);
            comboBoxCountry.DisplayMember = "Value";
            comboBoxCountry.ValueMember = "Key";
            comboBoxCountry.SelectedItem = null;
            Dictionary<int, string> cityDicNm = MainForm.cityDict.ToDictionary(dic => dic.Key, dic => dic.Value.CityName);
            comboBoxCountry.DataSource = new BindingSource(cityDicNm, null);
            comboBoxCity.DisplayMember = "Value";
            comboBoxCity.ValueMember = "Key";
            comboBoxCity.SelectedItem = null;
        }

        private void emptyFields()
        {
            txtId.Text = "";
            txtCusAdd1.Text = "";
            txtCusAdd2.Text = "";
            txtCusName.Text = "";
            txtCusPhone.Text = "";
            txtCusZip.Text = "";
            comboBoxCity.Text = "";
            comboBoxCountry.Text = "";
        }
       
        private void ActiveSect(bool active)
        {
            txtCusName.Enabled = active;
            txtCusAdd1.Enabled = active;

            txtCusAdd2.Enabled = active;
            comboBoxCity.Enabled = active;
            txtCusZip.Enabled = active;

            comboBoxCountry.Enabled = active;

            txtCusPhone.Enabled = active;
            btnRcAdd.Visible = !active;
            btnRcUpdate.Visible = !active;
            btnRcDelete.Visible = !active;
            btnSave.Visible = active;
            btnCancel.Visible = active;
            RecordsdataGridView1.Enabled = !active;
            
        }
        private void GetTime()
        {

            labelTime.Text = $"Logged in on {DateTime.Now.ToUniversalTime()}";

        }
        
       

        private void btnRcAdd_Click(object sender, EventArgs e)
        {
            RecordsdataGridView1.ClearSelection();
            emptyFields();
            //lambda to grab list of cities
            Dictionary<int, string> ctNmDict = MainForm.cityDict.ToDictionary(dict => dict.Key, dict => dict.Value.CityName);
            comboBoxCity.DataSource = new BindingSource(ctNmDict, null);
            comboBoxCity.DisplayMember = "Value";
            comboBoxCity.ValueMember = "Key";
            comboBoxCity.SelectedItem = null;
            ActiveSect(true);


         

        }


        private void btnRcUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecordsdataGridView1.SelectedRows.Count < 1)
                {
                    throw new ApplicationException("Select a customer to update");
                }
                ActiveSect(true);
                var selCountry = Convert.ToInt32(comboBoxCountry.SelectedValue);
                var nwCty = MainForm.cityDict.Where(dict => dict.Value.CountryId == selCountry).ToDictionary(dict => dict.Key, dict => dict.Value.CityName);
                comboBoxCity.DataSource = new BindingSource(nwCty, null);
                comboBoxCity.DisplayMember = "Value";
                comboBoxCity.ValueMember = "Key";
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "There was an issue updating customer", MessageBoxButtons.OK);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "There was an error", MessageBoxButtons.OK);
            }
        

        
           

        }
        
        private void btnRcDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecordsdataGridView1.SelectedRows.Count < 1)
                {
                    throw new ApplicationException("Who would you like to delet?");
                }
                DialogResult confirmation = MessageBox.Show("Sure you want to delete? ", "Confirmed", MessageBoxButtons.YesNo);

                if (confirmation == DialogResult.Yes)
                {
                    var selRow = RecordsdataGridView1.SelectedRows[0];
                    int selcustomerId = Convert.ToInt32(selRow.Cells[0].Value);
                    bool schAppt = false;

                    foreach (var a in MainForm.ApptLt) { if (a.CustomerId == selcustomerId) { schAppt = true; } }
                    if (schAppt) { throw new ApplicationException("Dont remove customer with appointment"); }
                    Customer selCust = MainForm.CustLt.Where(c => c.CustomerId == selcustomerId).Single();
                    DataContext.DeleteaCustomer(selCust);
                    emptyFields();
                    //DataContext.ActivityLogs(user,"Customer deleted id " + customerId);
                }
                else
                {
                    RecordsdataGridView1.ClearSelection();
                    emptyFields();
                }
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "There was an issue deleting customer", MessageBoxButtons.OK);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "There was an error", MessageBoxButtons.OK);
            }
        }


        /// <summary>
        /// //////////////////////////Navigation to other forms///////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAppt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RecordsdataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCusName.Text = RecordsdataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtCusAdd1.Text = RecordsdataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtCusAdd2.Text = RecordsdataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBoxCity.Text = RecordsdataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtCusZip.Text = RecordsdataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBoxCountry.Text = RecordsdataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtCusPhone.Text = RecordsdataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        

        private void CustomerRecords_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainControl.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ToolTip ttip = new ToolTip();

                if (string.IsNullOrWhiteSpace(txtCusName.Text))
                {
                    ttip.Show("Customer name is required ", txtCusName);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCusAdd1.Text))
                {
                    ttip.Show("Address is required", txtCusAdd1);
                    return;
                }
                if (string.IsNullOrWhiteSpace(comboBoxCity.Text))
                {
                    ttip.Show("City is required ", comboBoxCity);
                    return;
                }
                if (string.IsNullOrWhiteSpace(comboBoxCountry.Text))
                {
                    ttip.Show("Country is required", comboBoxCountry);
                    return;
                }
                string customerName = txtCusName.Text;
                string address1 = txtCusAdd1.Text;
                string address2 = txtCusAdd2.Text;
                string postalCode = txtCusZip.Text;
                string phone = txtCusPhone.Text;
                int cityId = Convert.ToInt32(comboBoxCity.SelectedValue);
                int cusId;
                if (txtId.Text == "")
                {
                    int adrsId = DataContext.AddAddress(address1, address2, cityId, postalCode, phone, MainForm.LgdUsr.UserName);
                    cusId = DataContext.AddaCustomer(customerName, adrsId, MainForm.LgdUsr.UserName);
                    txtId.Text = cusId.ToString();
                }
                else
                {
                    cusId = Convert.ToInt32(txtId.Text);
                    Customer curCus = MainForm.CustLt.Where(ct => ct.CustomerId == cusId).Single();
                    Address addss = MainForm.addDict[curCus.AddressId];
                    DataContext.UpdateaCustomer(curCus, customerName, MainForm.LgdUsr.UserName);
                    DataContext.UpdateaAddress(addss, address1, address2, cityId, postalCode, phone, MainForm.LgdUsr.UserName);

                }
                ActiveSect(false);
                RecordsdataGridView1.Rows.Cast<DataGridViewRow>().Where(row => Convert.ToInt32(row.Cells[0].Value) == cusId).Single().Selected = true;

            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "There was an issue  saving user", MessageBoxButtons.OK);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "There was an error", MessageBoxButtons.OK);
            }
           

        }

        private void comboBoxCity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxCountry.Text == "") { var seCTKy = comboBoxCity.SelectedValue; int selCountry = MainForm.cityDict[Convert.ToInt32(seCTKy)].CountryId;
                comboBoxCountry.Text = MainForm.countryDict[selCountry].CountryName;
            }
                    
        }

        private void comboBoxCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selCountry = Convert.ToInt32(comboBoxCountry.SelectedValue);
            var nwCyDic = MainForm.cityDict.Where(dict => dict.Value.CountryId == selCountry).ToDictionary(dict => dict.Key, dict => dict.Value.CityName);
            comboBoxCity.DataSource = new BindingSource(nwCyDic, null) ;
            comboBoxCity.DisplayMember = "Value";
            comboBoxCity.ValueMember = "Key";
            comboBoxCity.SelectedItem = null;




        }

        private void RecordsdataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selRw = RecordsdataGridView1.SelectedRows[0];
            int selCusId = Convert.ToInt32(selRw.Cells[0].Value);
            Customer selCus = MainForm.CustLt.Where(cus => cus.CustomerId == selCusId).Single();
            int selAddId = Convert.ToInt32(selCus.AddressId);
            int selcyId = MainForm.addDict[selAddId].CityId;
            int selcounId = MainForm.cityDict[selcyId].CountryId;
            txtCusName.Text = selCus.CustomerName;
            txtId.Text = selCus.CustomerId.ToString();
            txtCusAdd1.Text = MainForm.addDict[selAddId].Address1;
            txtCusAdd2.Text = MainForm.addDict[selAddId].Address2;
            txtCusZip.Text = MainForm.addDict[selAddId].PostalCode;
            txtCusPhone.Text = MainForm.addDict[selAddId].Phone;
            comboBoxCity.Text = MainForm.cityDict[selcyId].CityName;
            comboBoxCountry.Text = MainForm.countryDict[selcounId].CountryName;




        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RecordsdataGridView1.ClearSelection();
            emptyFields();
            ActiveSect(false);
        }

        private void RecordsdataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            formatGrid();
        }

        private void formatGrid()
        {
            var dgView = RecordsdataGridView1;
            dgView.AutoResizeColumns();
            dgView.RowHeadersVisible = false;
            dgView.ReadOnly = true;
            dgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgView.MultiSelect = false;
            dgView.ClearSelection();
        }
    }
    
}
