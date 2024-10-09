using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SpoServiceSystem.DataModels
{
    public class BazaSoft
    {
        string shablonStrConnection = "Server={0};Database={1};Uid={2};Pwd={3};";
        string MySqlServerName = "localhost";
        string MySqlDataBaze = "KAIT20";
        string MySqlPassword = "ski150357";
        string MySqlUserName = "root";
        string TableName;
        public string BazaSoft_Parameter {  get; set; }
        public string MySqlConnectionString { 
            get {
                return string.Format(shablonStrConnection, MySqlServerName, MySqlDataBaze, MySqlUserName, MySqlPassword);
            }
        }


        public BazaSoft() {
            /*
           DataTable dt = new DataTable();
            dt.Columns.Add("ID2", typeof(Int32));
            dt.Columns.Add("ID1", typeof(Int32));
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns["ID"].Expression = "ID2+ID1";
            */

        }

        public DataView getDataTableView(string _TableName)
        {
            TableName = _TableName;
             DataTable dataTable = getDataTable(TableName);
            return dataTable.AsDataView();
         }
        public DataView getSourceComboBox(string _TableName)
        {
            TableName = _TableName;
            DataTable dataTable = getDataTable(TableName);
            return dataTable.DefaultView;
        }
        public  DataTable getDataTable(string _TableName)
        {
            TableName =_TableName;
            DataTable dt;
            string sql = string.Format("SELECT * FROM {0}", TableName);
            dt = getTable(sql);
            return dt;
        }
        public  DataTable getTable(string sqlString)
        {
            
            DataTable? dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(MySqlConnectionString))
            {

                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sqlString, conn);
                    adapter.Fill(dt);
                    conn.Close();

                }
                catch (Exception e)
                {
                    dt = null;
                }

            }

            return dt;
        }

        public int SaveSpecialnost(DataTable dtable)
        {
            int n = -1;
            string TableName = "specialnost";
            string UpdateString = "UPDATE  specialnost SET " +
                                  "cod_sp=@cod_spn,name_sp=@name_sp,srok_mes=@srok_mes,baza_sp=@baza_sp" +
                                " WHERE id_sp=@id_sp";
            string InsertString = "INSERT INTO specialnost (cod_sp,name_sp,srok_mes,baza_sp)" +
                                   "VALUES(@cod_sp,@name_sp,@srok_mes,@baza_sp)";
            string DeleteString = "DELETE FROM specialnost WHERE id_sp=@id_sp";


            string UpdateStr = string.Format(UpdateString, TableName);
            
            try
            {
                DataTable? dt = dtable.GetChanges();
                if (dt != null)
                {
                    using (MySqlConnection conn = new MySqlConnection(MySqlConnectionString))
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        MySqlCommand com = new MySqlCommand(UpdateStr, conn);

                        com.Parameters.Add("@id_sp", MySqlDbType.Int32, 32, "id_sp");
                        com.Parameters.Add("@cod_sp", MySqlDbType.VarChar, 45, "cod_sp");
                        com.Parameters.Add("@name_sp", MySqlDbType.VarChar, 45, "name_sp");
                        com.Parameters.Add("@srok_mes", MySqlDbType.Int32, 32, "rok_mes");
                        com.Parameters.Add("@baza_sp", MySqlDbType.Int32, 32, "baza_sp");
                        adapter.UpdateCommand = com;

                        com = new MySqlCommand(InsertString, conn);
                        com.Parameters.Add("@cod_sp", MySqlDbType.VarChar, 45, "cod_sp");
                        com.Parameters.Add("@name_sp", MySqlDbType.VarChar, 45, "name_sp");
                        com.Parameters.Add("@srok_mes", MySqlDbType.Int32, 32, "rok_mes");
                        com.Parameters.Add("@baza_sp", MySqlDbType.Int32, 32, "baza_sp");
                        adapter.InsertCommand = com;

                        com = new MySqlCommand(DeleteString, conn);
                        com.Parameters.Add("@id_sp", MySqlDbType.Int32, 32, "id_sp");
                        adapter.DeleteCommand = com;

                        n = adapter.Update(dt);

                    }
                }


            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }



            return n;
        }

        public int SaveKvalifications(DataTable dtable)
        {
            int n = -1;
            string TableName = "kvalifications";
            string UpdateString = "UPDATE  kvalifications SET " +
                                  "id_sp=@id_sp,name_kf=@name_kf" +
                                " WHERE id_kf=@id_kf";
            string InsertString = "INSERT INTO kvalifications (id_sp,name_kf)" +
                                   "VALUES(@id_sp,@name_kf)";
            string DeleteString = "DELETE FROM kvalifications WHERE id_kf=@id_kf";


            string UpdateStr = string.Format(UpdateString, TableName);

            try
            {
                DataTable? dt = dtable.GetChanges();
                if (dt != null)
                {
                    using (MySqlConnection conn = new MySqlConnection(MySqlConnectionString))
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        MySqlCommand com = new MySqlCommand(UpdateStr, conn);

                        com.Parameters.Add("@id_kf", MySqlDbType.Int32, 32, "id_kf");
                        com.Parameters.Add("@id_sp", MySqlDbType.Int32, 32, "id_sp");
                        com.Parameters.Add("@name_kf", MySqlDbType.VarChar, 60, "name_kf");
                       
                        adapter.UpdateCommand = com;

                        com = new MySqlCommand(InsertString, conn);
                        com.Parameters.Add("@id_sp", MySqlDbType.Int32, 32, "id_sp");
                        com.Parameters.Add("@name_kf", MySqlDbType.VarChar, 60, "name_kf");
                        adapter.InsertCommand = com;

                        com = new MySqlCommand(DeleteString, conn);
                        com.Parameters.Add("@id_kf", MySqlDbType.Int32, 32, "id_kf");
                        adapter.DeleteCommand = com;

                        n = adapter.Update(dt);
                        conn.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }



            return n;
        }

        public int SavePtrpods(DataTable dtable)
        {
            int n = -1;
            string TableName = "prepods";
            string UpdateString = "UPDATE  prepods SET " +
                                  "id_kategoria=@id_kategoria,name=@name,fam=@fam,otch=@otch" +
                                " WHERE id_prepod=@id_prepod";
            string InsertString = "INSERT INTO prepods (id_kategoria,name,fam,otch)" +
                                   "VALUES(@id_kategoria,@name,@fam,@otch)";
            string DeleteString = "DELETE FROM prepods WHERE id_prepod=@id_prepod";


            string UpdateStr = string.Format(UpdateString, TableName);

            try
            {
                DataTable? dt = dtable.GetChanges();
                if (dt != null)
                {
                    using (MySqlConnection conn = new MySqlConnection(MySqlConnectionString))
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        MySqlCommand com = new MySqlCommand(UpdateStr, conn);

                        com.Parameters.Add("@id_prepod", MySqlDbType.Int32, 32, "id_prepod");
                        com.Parameters.Add("@id_kategoria", MySqlDbType.Int32, 32, "id_kategoria");
                        com.Parameters.Add("@name", MySqlDbType.VarChar, 45, "name");
                        com.Parameters.Add("@fam", MySqlDbType.VarChar, 45, "fam");
                        com.Parameters.Add("@otch", MySqlDbType.VarChar, 45, "otch");
                       
                        adapter.UpdateCommand = com;

                        com = new MySqlCommand(InsertString, conn);
                        com.Parameters.Add("@id_kategoria", MySqlDbType.Int32, 32, "id_kategoria");
                        com.Parameters.Add("@name", MySqlDbType.VarChar, 45, "name");
                        com.Parameters.Add("@fam", MySqlDbType.VarChar, 45, "fam");
                        com.Parameters.Add("@otch", MySqlDbType.VarChar, 45, "otch");
                        adapter.InsertCommand = com;

                        com = new MySqlCommand(DeleteString, conn);
                        com.Parameters.Add("@id_prepod", MySqlDbType.Int32, 32, "id_sp");
                        adapter.DeleteCommand = com;

                        n = adapter.Update(dt);

                    }
                }


            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return n;
        }

        public int SaveGroups(DataTable dtable)
        {
            int n = -1;
            string TableName = "uch_groups";
            string UpdateString = "UPDATE  uch_groups SET " +
                                  "id_sp=@id_sp,id_tip=@id_tip,name_group=@name_group,count=@count,count_1=@count_1,count_2=@count_2,data=@data" +
                                " WHERE id_group=@id_group";
            string InsertString = "INSERT INTO uch_groups (id_sp,id_tip,name_group,count,count_1,count_2,data)" +
                                   "VALUES(@id_sp,@id_tip,@name_group,@count,@count_1,@count_2,@data)";
            string DeleteString = "DELETE FROM uch_groups WHERE id_group=@id_group";


            string UpdateStr = string.Format(UpdateString, TableName);

            try
            {
                DataTable? dt = dtable.GetChanges();
                if (dt != null)
                {
                    using (MySqlConnection conn = new MySqlConnection(MySqlConnectionString))
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        MySqlCommand com = new MySqlCommand(UpdateStr, conn);

                        com.Parameters.Add("@id_group", MySqlDbType.Int32, 32, "id_prepod");
                        com.Parameters.Add("@id_sp", MySqlDbType.Int32, 32, "id_sp");
                        com.Parameters.Add("@id_tip", MySqlDbType.Int32, 32, "id_tip");
                        com.Parameters.Add("@name_group", MySqlDbType.VarChar, 45, "name_group");
                        com.Parameters.Add("@count", MySqlDbType.Int32, 32, "count");
                        com.Parameters.Add("@count_1", MySqlDbType.Int32, 32, "count_1");
                        com.Parameters.Add("@count_2", MySqlDbType.Int32, 32, "count_2");
                        com.Parameters.Add("@data", MySqlDbType.Date, 32, "data");
                        adapter.UpdateCommand = com;

                        com = new MySqlCommand(InsertString, conn);
                        com.Parameters.Add("@id_sp", MySqlDbType.Int32, 32, "id_sp");
                        com.Parameters.Add("@id_tip", MySqlDbType.Int32, 32, "id_tip");
                        com.Parameters.Add("@name_group", MySqlDbType.VarChar, 45, "name_group");
                        com.Parameters.Add("@count", MySqlDbType.Int32, 32, "count");
                        com.Parameters.Add("@count_1", MySqlDbType.Int32, 32, "count_1");
                        com.Parameters.Add("@count_2", MySqlDbType.Int32, 32, "count_2");
                        com.Parameters.Add("@data", MySqlDbType.Date, 32, "data");
                        adapter.InsertCommand = com;

                        com = new MySqlCommand(DeleteString, conn);
                        com.Parameters.Add("@id_group", MySqlDbType.Int32, 32, "id_group");
                        adapter.DeleteCommand = com;

                        n = adapter.Update(dt);

                    }
                }


            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return n;
        }

        public int SavePredmets(DataTable dtable)
        {
            int n = -1;
            string TableName = "predmets";
            string UpdateString = "UPDATE  predmets SET " +
                                  "id_sp=@id_sp,kurs=@kurs,name_pr=@name_pr,index_pr=@index_pr" +
                                " WHERE id_pr=@id_pr";
            string InsertString = "INSERT INTO predmets (id_sp,kurs,name_pr,index_pr)" +
                                   "VALUES(@id_sp,@kurs,@name_pr,@index_pr)";
            string DeleteString = "DELETE FROM predmets WHERE id_pr=@id_pr";


            string UpdateStr = string.Format(UpdateString, TableName);

            try
            {
                DataTable? dt = dtable.GetChanges();
                if (dt != null)
                {
                    using (MySqlConnection conn = new MySqlConnection(MySqlConnectionString))
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        MySqlCommand com = new MySqlCommand(UpdateStr, conn);

                        com.Parameters.Add("@id_pr", MySqlDbType.Int32, 32, "id_pr");
                        com.Parameters.Add("@id_sp", MySqlDbType.Int32, 32, "id_sp");
                        com.Parameters.Add("@kurs", MySqlDbType.Int32, 32, "kurs");
                        com.Parameters.Add("@name_pr", MySqlDbType.VarChar, 45, "name_pr");
                        com.Parameters.Add("@index_pr", MySqlDbType.VarChar, 45, "index_pr");
                       
                        adapter.UpdateCommand = com;

                        com = new MySqlCommand(InsertString, conn);
                        com.Parameters.Add("@id_sp", MySqlDbType.Int32, 32, "id_sp");
                        com.Parameters.Add("@kurs", MySqlDbType.Int32, 32, "kurs");
                        com.Parameters.Add("@name_pr", MySqlDbType.VarChar, 45, "name_pr");
                        com.Parameters.Add("@index_pr", MySqlDbType.VarChar, 45, "index_pr");
                        adapter.InsertCommand = com;

                        com = new MySqlCommand(DeleteString, conn);
                        com.Parameters.Add("@id_pr", MySqlDbType.Int32, 32, "id_pr");
                        adapter.DeleteCommand = com;

                        n = adapter.Update(dt);

                    }
                }


            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return n;
        }

        public int SaveUchOtdelenies(DataTable dtable)
        {
            int n = -1;
            string TableName = "uch_otdelenie";
            string UpdateString = "UPDATE  uch_otdelenie SET " +
                                  "name_uo=@name_uo,comment_uo=@comment_uo" +
                                " WHERE id_uo=@id_uo";
            string InsertString = "INSERT INTO uch_otdelenie (name_uo,comment_uo)" +
                                   "VALUES(@name_uo,@comment_uo)";
            string DeleteString = "DELETE FROM uch_otdelenie WHERE id_uo=@id_uo";


            string UpdateStr = string.Format(UpdateString, TableName);

            try
            {
                DataTable? dt = dtable.GetChanges();
                if (dt != null)
                {
                    using (MySqlConnection conn = new MySqlConnection(MySqlConnectionString))
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        MySqlCommand com = new MySqlCommand(UpdateStr, conn);

                        com.Parameters.Add("@id_uo", MySqlDbType.Int32, 32, "id_uo");
                        com.Parameters.Add("@name_uo", MySqlDbType.VarChar, 45, "name_uo");
                        com.Parameters.Add("@comment_uo", MySqlDbType.VarChar, 45, "comment_uo");
                        adapter.UpdateCommand = com;

                        com = new MySqlCommand(InsertString, conn);

                        com.Parameters.Add("@name_uo", MySqlDbType.VarChar, 45, "name_uo");
                        com.Parameters.Add("@comment_uo", MySqlDbType.VarChar, 45, "comment_uo");
                        adapter.InsertCommand = com;

                        com = new MySqlCommand(DeleteString, conn);
                        com.Parameters.Add("@id_uo", MySqlDbType.Int32, 32, "id_uo");
                        adapter.DeleteCommand = com;

                        n = adapter.Update(dt);

                    }
                }


            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return n;
        }

        #region --------------- Учебный план ------------
          
        public DataView GetUchPlanDataView(int _idgroup)
        {
            
            DataTable? dt = new DataTable();
            
            using (MySqlConnection conn = new MySqlConnection(MySqlConnectionString))
            {

                try
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM uch_plan_groups WHERE id_group=@id", conn); ;
                    command.Parameters.Add("@id", MySqlDbType.VarChar, _idgroup);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(dt);
                    conn.Close();
                    dt.Columns.Add("Number", typeof(Int32));
                    dt.Columns.Add("Index", typeof(string));
                    dt.Columns.Add("Vsego1", typeof(Int32));
                    dt.Columns.Add("Vsego2", typeof(Int32));
                    dt.Columns.Add("Itogo", typeof(Int32));
                    dt.Columns["Vsego1"].Expression = "Item2+Item4";
                    dt.Columns["Vsego2"].Expression = "Item6+Item7+Item8+Item9+Item10+Item11+Item12+Item13+Item14+Item15";
                    dt.Columns["Itogo"].Expression = "Vsego2+Item16+Item17+Item18";
                }
                catch (Exception e)
                {
                    return null;
                }
                



            }
            return dt.DefaultView;
        }

        #endregion------------------------------------



    }


}
