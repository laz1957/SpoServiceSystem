using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon;
using MySql.Data.MySqlClient;
using SpoServiceSystem.Classes;

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
            SystemSettings ss = new SystemSettings();
            string server = ss.MySqlServerName;
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

        public DataTable getTable_AvtoIncriment(string sqlString)
        {

            DataTable? dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Number";
            dc.DataType = typeof(int);
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 1;
            dc.AutoIncrementStep = 1;
            dt.Columns.Add(dc);

            using (MySqlConnection conn = new MySqlConnection(MySqlConnectionString))
            {

                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sqlString, conn);
                    adapter.Fill(dt);
                    conn.Close();
                    dt.AcceptChanges();

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
                                  "cod_sp=@cod_sp,name_sp=@name_sp,srok_mes=@srok_mes,baza_sp=@baza_sp,id_kf=@id_kf" +
                                " WHERE id_sp=@id_sp";
            string InsertString = "INSERT INTO specialnost (cod_sp,name_sp,srok_mes,baza_sp,id_kf)" +
                                   "VALUES(@cod_sp,@name_sp,@srok_mes,@baza_sp,@id_kf)";
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
                        com.Parameters.Add("@srok_mes", MySqlDbType.Int32, 32, "srok_mes");
                        com.Parameters.Add("@baza_sp", MySqlDbType.Int32, 32, "baza_sp");
                        com.Parameters.Add("@id_kf", MySqlDbType.Int32, 32, "id_kf");
                        adapter.UpdateCommand = com;

                        com = new MySqlCommand(InsertString, conn);
                        com.Parameters.Add("@cod_sp", MySqlDbType.VarChar, 45, "cod_sp");
                        com.Parameters.Add("@name_sp", MySqlDbType.VarChar, 45, "name_sp");
                        com.Parameters.Add("@srok_mes", MySqlDbType.Int32, 32, "srok_mes");
                        com.Parameters.Add("@baza_sp", MySqlDbType.Int32, 32, "baza_sp");
                        com.Parameters.Add("@id_kf", MySqlDbType.Int32, 32, "id_kf");
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
                                  "name_kf=@name_kf,name_kurz=@name_kurz" +
                                " WHERE id_kf=@id_kf";
            string InsertString = "INSERT INTO kvalifications (name_kf,name_kurz)" +
                                   "VALUES(@id_sp,@name_kf,@name_kurz)";
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
                       // com.Parameters.Add("@id_sp", MySqlDbType.Int32, 32, "id_sp");
                        com.Parameters.Add("@name_kf", MySqlDbType.VarChar, 60, "name_kf");
                        com.Parameters.Add("@name_kurz", MySqlDbType.VarChar, 60, "name_kurz");
                        adapter.UpdateCommand = com;

                        com = new MySqlCommand(InsertString, conn);
                      //  com.Parameters.Add("@id_sp", MySqlDbType.Int32, 32, "id_sp");
                        com.Parameters.Add("@name_kf", MySqlDbType.VarChar, 60, "name_kf");
                        com.Parameters.Add("@name_kurz", MySqlDbType.VarChar, 60, "name_kurz");
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

        public int SavePrepods(DataTable dtable)
        {
            int n = -1;
            string TableName = "prepods";
            string UpdateString = "UPDATE  prepods SET " +
                                  "id_kategoria=@id_kategoria,name=@name,fam=@fam,otch=@otch" +
                                " WHERE id_prepod=@id_prepod";
            string InsertString = "INSERT INTO prepods (id_kategoria,name,fam,otch)" +
                                   "VALUES(@id_kategoria,@name,@fam,@otch)";
            string DeleteString = "DELETE FROM prepods WHERE id_prepod=@id_prepod";


            //string UpdateStr = string.Format(UpdateString, TableName);

            try
            {
                DataTable? dt = dtable.GetChanges();
                if (dt != null)
                {
                    using (MySqlConnection conn = new MySqlConnection(MySqlConnectionString))
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        MySqlCommand com = new MySqlCommand(UpdateString, conn);

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
                                  "id_uo=@id_uo,id_sp=@id_sp,id_tip=@id_tip,name_group=@name_group,count=@count,count_1=@count_1,count_2=@count_2,data=@data" +
                                " WHERE id_group=@id_group";
            string InsertString = "INSERT INTO uch_groups (id_uo,id_sp,id_tip,name_group,count,count_1,count_2,data)" +
                                   "VALUES(@id_uo,@id_sp,@id_tip,@name_group,@count,@count_1,@count_2,@data)";
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
                        MySqlCommand com = new MySqlCommand(UpdateString, conn);

                        com.Parameters.Add("@id_group", MySqlDbType.Int32, 32, "id_group");
                        com.Parameters.Add("@id_uo", MySqlDbType.Int32, 32, "id_uo");
                        com.Parameters.Add("@id_sp", MySqlDbType.Int32, 32, "id_sp");
                        com.Parameters.Add("@id_tip", MySqlDbType.Int32, 32, "id_tip");
                        com.Parameters.Add("@name_group", MySqlDbType.VarChar, 45, "name_group");
                        com.Parameters.Add("@count", MySqlDbType.Int32, 32, "count");
                        com.Parameters.Add("@count_1", MySqlDbType.Int32, 32, "count_1");
                        com.Parameters.Add("@count_2", MySqlDbType.Int32, 32, "count_2");
                        com.Parameters.Add("@data", MySqlDbType.Date, 32, "data");
                        adapter.UpdateCommand = com;

                        com = new MySqlCommand(InsertString, conn);
                        com.Parameters.Add("@id_uo", MySqlDbType.Int32, 32, "id_uo");
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
                        adapter.RowUpdating+=Adapter_RowUpdating;
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

                dtable.AcceptChanges();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return n;
        }

        private void Adapter_RowUpdating(object sender, MySqlRowUpdatingEventArgs e)
        {
            DataRow r = e.Row;
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

        public int SaveUchPlan(DataTable dtable)
        {
            int n = -1;
            string TableName = "uch_plan_groups";
            string UpdateString = "UPDATE  uch_plan_groups SET " +
                                  "id_group=@id_group,id_predmet=@id_predmet,id_prepod=@id_prepod," +
                                  "Item1=@Item1,Item2=@Item2,Item3=@Item3,Item4=@Item4,"+
                                  "Item5=@Item5,Item6=@Item6,Item7=@Item7,Item8=@Item8,"+
                                  "Item9=@Item9,Item10=@Item10,Item11=@Item11,Item12=@Item12,"+
                                  "Item13=@Item13,Item14=@Item14,Item15=@Item15,Item16=@Item16,"+
                                  "Item17=@Item17,Item18=@Item18"+
                                " WHERE id_up=@id_up";
            string InsertString = "INSERT INTO uch_plan_groups (id_group,id_predmet,id_prepod,"+
                                  "Item1,Item2,Item3,Item4,Item5,Item6,Item7,Item8,Item9,Item10,"+
                                  "Item11,Item12,Item13,Item14,Item15,Item16,Item17,Item18 )" +
                                   "VALUES(@id_group,@id_predmet,@id_prepod," +
                                   "@Item1,@Item2,@Item3,@Item4,@Item5,@Item6,@Item7,@Item8,@Item9,@Item10,"+
                                  "@Item11,@Item12,@Item13,@Item14,@Item15,@Item16,@Item17,@Item18 )";
                                   
            string DeleteString = "DELETE FROM uch_plan_groups WHERE id_up=@id_up";
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

                        com.Parameters.Add("@id_up", MySqlDbType.Int32, 32, "id_up");
                        com.Parameters.Add("@id_group", MySqlDbType.Int32, 32, "id_group");
                        com.Parameters.Add("@id_predmet", MySqlDbType.Int32, 32, "id_predmet");
                        com.Parameters.Add("@id_prepod", MySqlDbType.Int32, 32, "id_prepod");
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

                        com = new MySqlCommand(InsertString, conn);

                        com.Parameters.Add("@id_group", MySqlDbType.Int32, 32, "id_group");
                        com.Parameters.Add("@id_predmet", MySqlDbType.Int32, 32, "id_predmet");
                        com.Parameters.Add("@id_prepod", MySqlDbType.Int32, 32, "id_prepod");
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

                        com = new MySqlCommand(DeleteString, conn);
                        com.Parameters.Add("@id_up", MySqlDbType.Int32, 32, "id_up");
                        adapter.DeleteCommand = com;
                        n = adapter.Update(dt);
                        dtable.AcceptChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return n;
        }

        #endregion------------------------------------



        public int getCountRows(string TableName,int _id)
        {
            int n = 0;
            string sql= string.Empty;
            if (_id > 0) 
                sql= string.Format("select count(*) FROM {0} where id_group={1}", TableName,_id);
            else
                sql= string.Format("select count(*) FROM {0}", TableName);
            using (MySqlConnection conn = new MySqlConnection(MySqlConnectionString))
            {

                try
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    string str=command.ExecuteScalar().ToString();
                    conn.Close();
                    n= int.Parse(str);
                }
                catch (Exception e)
                {
                    n=-1;
                }

            }
            return n;
        }

        public int RunCommand(string sql)
        {
            int n = 0;
            using (MySqlConnection conn = new MySqlConnection(MySqlConnectionString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql, conn);
                n=command.ExecuteNonQuery();
                  conn.Close();
            }
            return n;
        }
        public DataView GenerateUchPlanDataView(int _idgroup)
        {
          //  DataTable dd = getTable("SELECT * FROM get_uchplan_group WHERE id_group=1");
            DataTable? dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(MySqlConnectionString))
            {

                try
                {

                    conn.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM get_uchplan_group WHERE id_group=1", conn); ;
                    command.Parameters.Add("@id0", MySqlDbType.Int64, _idgroup);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.FillError+=Adapter_FillError;
                    adapter.Fill(dt);
                    conn.Close();
                    dt.Columns.Add("Number", typeof(Int64));
                    dt.Columns.Add("Vsego1", typeof(Int64));
                    dt.Columns.Add("Vsego2", typeof(Int64));
                    dt.Columns.Add("Itogo", typeof(Int64));
                    dt.Columns["Vsego1"].Expression = "Item2+Item4";
                    dt.Columns["Vsego2"].Expression = "Item6+Item7+Item8+Item9+Item10+Item11+Item12+Item13+Item14+Item15";
                    dt.Columns["Itogo"].Expression = "Vsego2+Item16+Item17+Item18";
                    long x = 0;
                    
                    foreach (DataRow row in dt.Rows) {
                        row["Number"] = ++x;
                    }
                }
                catch (Exception e)
                {
                    return null;
                }




            }
            return dt.DefaultView;
        }

        private void Adapter_FillError(object sender, FillErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

    }


}
