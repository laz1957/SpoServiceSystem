using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using SpoServiceSystem.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpoServiceSystem.DataModels
{
    public class UchebPlan : INotifyPropertyChanged
    {
        BazaSoft bsManager;
        int IdSpecialnost {  get; set; }
        int Kurs {  get; set; }
        System.Data.DataTable dt;
       
        string TableName = "uch_plan";
        string stringStatus;
        public string StringStatus
        {
            get => stringStatus;
            set
            {
                if (stringStatus != value)
                {
                    stringStatus = value;
                    OnPropertyChanged();
                }
            }
        }
        string sql_Procedure = "GET_UCH_PLAN";
        string sql_GetStatus = "SELECT COUNT(*) FROM {0} WHERE id_sp={1} AND kurs={2}";
        string DeleteString = "DELETE FROM {0} WHERE id_sp={1} AND kurs={2}";
        public UchebPlan(int idSpecialnost,int kurs)
        {
           
            IdSpecialnost = idSpecialnost;
            Kurs = kurs;
            Init();

        }
       void Init()
        {
            bsManager = new BazaSoft();
            string sql = string.Format(sql_GetStatus, TableName, IdSpecialnost, Kurs);
            int nCount = bsManager.RunCommand(sql);
            if (nCount <=0) 
                StringStatus="NEW";
            else
                StringStatus="OLD";
            dt =bsManager.getTableFromPprocedure(sql_Procedure, IdSpecialnost, Kurs);
            AddColumns();
        }
        public DataView GetPlan()
        {
            if (dt == null)
                return null;
            else
                return dt.DefaultView;

        }
        void AddColumns()
        {
            dt.Columns.Add("Vsego1", typeof(Int32));
            dt.Columns.Add("Vsego2", typeof(Int32));
            dt.Columns.Add("Itogo", typeof(Int32));
            dt.Columns["Vsego1"].Expression = "Item2+Item4";
            dt.Columns["Vsego2"].Expression = "Item6+Item7+Item8+Item9+Item10+Item11+Item12+Item13+Item14+Item15";
            dt.Columns["Itogo"].Expression = "Vsego2+Item16+Item17+Item18";

            

        }
        public int UpdateUchPlan()
        {
            int ncount = 0;
            string UpdateString = "UPDATE  uch_plan SET " +
                                              "id_sp=@id_sp,id_pr=@id_pr,kurs=@kurs," +
                                              "Item1=@Item1,Item2=@Item2,Item3=@Item3,Item4=@Item4,"+
                                              "Item5=@Item5,Item6=@Item6,Item7=@Item7,Item8=@Item8,"+
                                              "Item9=@Item9,Item10=@Item10,Item11=@Item11,Item12=@Item12,"+
                                              "Item13=@Item13,Item14=@Item14,Item15=@Item15,Item16=@Item16,"+
                                              "Item17=@Item17,Item18=@Item18"+
                                            " WHERE id_up=@id_up";
            
            try
            {
                System.Data.DataTable? dtChange = dt.GetChanges();
               
                if (dtChange != null)
                {
                   
                    using (MySqlConnection conn = new MySqlConnection(bsManager.MySqlConnectionString))
                    {
                       
                        conn.Open();

                        foreach (DataRow row in dtChange.Rows) 
                        {
                            MySqlCommand com = new MySqlCommand(UpdateString, conn);
                            com.Parameters.Add("@id_up", MySqlDbType.Int32);
                            com.Parameters["@id_up"].Value = row["id_up"];
                            com.Parameters.Add("@id_sp", MySqlDbType.Int32);
                            com.Parameters["@id_sp"].Value = row["id_sp"];
                            com.Parameters.Add("@id_pr", MySqlDbType.Int32);
                            com.Parameters["@id_pr"].Value = row["id_pr"];
                            com.Parameters.Add("@kurs", MySqlDbType.Int32);
                            com.Parameters["@kurs"].Value = row["kurs"];
                            com.Parameters.Add("@Item1", MySqlDbType.Int32);
                            com.Parameters["@Item1"].Value = row["Item1"];
                            com.Parameters.Add("@Item2", MySqlDbType.Int32);
                            com.Parameters["@Item2"].Value = row["Item2"];
                            com.Parameters.Add("@Item3", MySqlDbType.Int32);
                            com.Parameters["@Item3"].Value = row["Item3"];
                            com.Parameters.Add("@Item4", MySqlDbType.Int32);
                            com.Parameters["@Item4"].Value = row["Item4"];
                            com.Parameters.Add("@Item5", MySqlDbType.Int32);
                            com.Parameters["@Item5"].Value = row["Item5"];
                            com.Parameters.Add("@Item6", MySqlDbType.Int32);
                            com.Parameters["@Item6"].Value = row["Item6"];
                            com.Parameters.Add("@Item7", MySqlDbType.Int32);
                            com.Parameters["@Item7"].Value = row["Item7"];
                            com.Parameters.Add("@Item8", MySqlDbType.Int32);
                            com.Parameters["@Item8"].Value = row["Item8"];
                            com.Parameters.Add("@Item9", MySqlDbType.Int32);
                            com.Parameters["@Item9"].Value = row["Item9"];
                            com.Parameters.Add("@Item10", MySqlDbType.Int32);
                            com.Parameters["@Item10"].Value = row["Item10"];
                            com.Parameters.Add("@Item11", MySqlDbType.Int32);
                            com.Parameters["@Item11"].Value = row["Item11"];
                            com.Parameters.Add("@Item12", MySqlDbType.Int32);
                            com.Parameters["@Item12"].Value = row["Item12"];
                            com.Parameters.Add("@Item13", MySqlDbType.Int32);
                            com.Parameters["@Item13"].Value = row["Item13"];
                            com.Parameters.Add("@Item14", MySqlDbType.Int32);
                            com.Parameters["@Item14"].Value = row["Item14"];
                            com.Parameters.Add("@Item15", MySqlDbType.Int32);
                            com.Parameters["@Item15"].Value = row["Item15"];
                            com.Parameters.Add("@Item16", MySqlDbType.Int32);
                            com.Parameters["@Item16"].Value = row["Item16"];
                            com.Parameters.Add("@Item17", MySqlDbType.Int32);
                            com.Parameters["@Item17"].Value = row["Item17"];
                            com.Parameters.Add("@Item18", MySqlDbType.Int32);
                            com.Parameters["@Item18"].Value = row["Item18"];

                            com.ExecuteNonQuery();
                        }
                        /*
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.RowUpdated+=Adapter_RowUpdated;
                        adapter.RowUpdating+=Adapter_RowUpdating;
                        MySqlCommand com = new MySqlCommand(UpdateString, conn);
                        com.Parameters.Add("@id_up", MySqlDbType.Int32, 32, "id_up");
                        com.Parameters.Add("@id_sp", MySqlDbType.Int32, 32, "id_sp");
                        com.Parameters.Add("@id_pr", MySqlDbType.Int32, 32, "id_pr");
                        com.Parameters.Add("@kurs", MySqlDbType.Int32, 32, "kurs");
                        com.Parameters.Add("@Item1", MySqlDbType.Int32, 32, "Item1");
                        com.Parameters.Add("@Item2", MySqlDbType.Int32, 32, "Item2");
                        com.Parameters.Add("@Item3", MySqlDbType.Int32, 32, "Item3");
                        com.Parameters.Add("@Item4", MySqlDbType.Int32, 32, "Item4");
                        com.Parameters.Add("@Item5", MySqlDbType.Int32, 32, "Item5");
                        com.Parameters.Add("@Item6", MySqlDbType.Int32, 32, "Item6");
                        com.Parameters.Add("@Item7", MySqlDbType.Int32, 32, "Item7");
                        com.Parameters.Add("@Item8", MySqlDbType.Int32, 32, "Item8");
                        com.Parameters.Add("@Item9", MySqlDbType.Int32, 32, "Item9");
                        com.Parameters.Add("@Item10", MySqlDbType.Int32, 32, "Item10");
                        com.Parameters.Add("@Item11", MySqlDbType.Int32, 32, "Item11");
                        com.Parameters.Add("@Item12", MySqlDbType.Int32, 32, "Item12");
                        com.Parameters.Add("@Item13", MySqlDbType.Int32, 32, "Item13");
                        com.Parameters.Add("@Item14", MySqlDbType.Int32, 32, "Item14");
                        com.Parameters.Add("@Item15", MySqlDbType.Int32, 32, "Item15");
                        com.Parameters.Add("@Item16", MySqlDbType.Int32, 32, "Item16");
                        com.Parameters.Add("@Item17", MySqlDbType.Int32, 32, "Item17");
                        com.Parameters.Add("@Item18", MySqlDbType.Int32, 32, "Item18");
                        adapter.UpdateCommand = com;
                        ncount = adapter.Update(dtChange);
                        */
                        conn.Close();
                        this.StringStatus="SAVED";
                        dt.AcceptChanges();
                    }
                }

            }
            catch(Exception e) 
            {
                MessageBox.Show(e.Message);
            }
            return ncount;
        }

        private void Adapter_RowUpdating(object sender, MySqlRowUpdatingEventArgs e)
        {
           
        }

        private void Adapter_RowUpdated(object sender, MySqlRowUpdatedEventArgs e)
        {
            
        }

        public int AppendNewUchPlan()
        {
            int ncount = 0;
            string InsertString = "INSERT INTO uch_plan (id_sp,id_pr,kurs,"+
                                  "Item1,Item2,Item3,Item4,Item5,Item6,Item7,Item8,Item9,Item10,"+
                                  "Item11,Item12,Item13,Item14,Item15,Item16,Item17,Item18 )" +
                                   "VALUES(@id_sp,@id_pr,@kurs," +
                                   "@Item1,@Item2,@Item3,@Item4,@Item5,@Item6,@Item7,@Item8,@Item9,@Item10,"+
                                  "@Item11,@Item12,@Item13,@Item14,@Item15,@Item16,@Item17,@Item18 )";
            try
            {
                dt.AcceptChanges();
                foreach (DataRow row in dt.Rows)
                {
                    row.SetAdded();
                }
                using (MySqlConnection conn = new MySqlConnection(bsManager.MySqlConnectionString))
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    MySqlCommand com = new MySqlCommand(InsertString, conn);
                    com.Parameters.Add("@id_sp", MySqlDbType.Int32, 32, "id_sp");
                    com.Parameters.Add("@id_pr", MySqlDbType.Int32, 32, "id_pr");
                    com.Parameters.Add("@kurs", MySqlDbType.Int32, 32, "kurs");
                    com.Parameters.Add("@Item1", MySqlDbType.Int32, 32, "Item1");
                    com.Parameters.Add("@Item2", MySqlDbType.Int32, 32, "Item2");
                    com.Parameters.Add("@Item3", MySqlDbType.Int32, 32, "Item3");
                    com.Parameters.Add("@Item4", MySqlDbType.Int32, 32, "Item4");
                    com.Parameters.Add("@Item5", MySqlDbType.Int32, 32, "Item5");
                    com.Parameters.Add("@Item6", MySqlDbType.Int32, 32, "Item6");
                    com.Parameters.Add("@Item7", MySqlDbType.Int32, 32, "Item7");
                    com.Parameters.Add("@Item8", MySqlDbType.Int32, 32, "Item8");
                    com.Parameters.Add("@Item9", MySqlDbType.Int32, 32, "Item9");
                    com.Parameters.Add("@Item10", MySqlDbType.Int32, 32, "Item10");
                    com.Parameters.Add("@Item11", MySqlDbType.Int32, 32, "Item11");
                    com.Parameters.Add("@Item12", MySqlDbType.Int32, 32, "Item12");
                    com.Parameters.Add("@Item13", MySqlDbType.Int32, 32, "Item13");
                    com.Parameters.Add("@Item14", MySqlDbType.Int32, 32, "Item14");
                    com.Parameters.Add("@Item15", MySqlDbType.Int32, 32, "Item15");
                    com.Parameters.Add("@Item16", MySqlDbType.Int32, 32, "Item16");
                    com.Parameters.Add("@Item17", MySqlDbType.Int32, 32, "Item17");
                    com.Parameters.Add("@Item18", MySqlDbType.Int32, 32, "Item18");
                    adapter.InsertCommand = com;
                    ncount = adapter.Update(dt);
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (ncount > 0) stringStatus="SAVED";
            return ncount;
        }


        public void DeleteUchPlan()
        {
            string sql = string.Format(DeleteString, TableName, IdSpecialnost, Kurs);
            using (MySqlConnection conn = new MySqlConnection(bsManager.MySqlConnectionString))
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand(sql, conn);
                com.ExecuteNonQuery();
                conn.Close() ;
            }
            foreach(DataRow row in dt.Rows)
            {
                row.Delete();
            }
            dt.AcceptChanges();
            this.StringStatus="NEW";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
