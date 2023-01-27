using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbadv_customs
{
    public partial class Store_View : Form
    {
        List<Store> storeList = new List<Store>();

        public Store_View()
        {
            InitializeComponent();
            InitStoreComboBox();
        }

        private void storeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int storeId = int.Parse(GetComboBoxItem());
            string query = "select * from cargo " +
                "where enter_cargo = " + storeId;
            DataTable dt = DatabaseManager.GetDataTableFromQuery(query);
            dataGridView1.DataSource = dt;
        }

        string GetComboBoxItem()
        {
            string item = "";

            item = storeComboBox.SelectedItem.ToString();

            string[] itemSplited = item.Split(':', ' ');

            return itemSplited[itemSplited.Length - 1];
        }

        void InitStoreComboBox()
        {
            SetStoreList();
            for (int i = 0; i < storeList.Count; i++)
            {
                storeComboBox.Items.Add(storeList[i].storeName + " : " +
                    storeList[i].storeId);
            }
        }

        void SetStoreList()
        {
            string query = "Select * from store";
            DataTable dt = new DataTable();
            dt = DatabaseManager.GetDataTableFromQuery(query);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drow = dt.Rows[i];
                Store store = new Store(int.Parse(drow[0].ToString()),
                    drow[1].ToString());
                storeList.Add(store);
            }
        }

        class Store
        {
            public string storeName;
            public int storeId;
            public Store(int storeId, string storeName)
            {
                this.storeId = storeId;
                this.storeName = storeName;
            }
        }
    }
}
