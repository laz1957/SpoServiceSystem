using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SpoServiceSystem.DataModels
{
    public class Otdelenie : INotifyPropertyChanged
    {
        int id_uo;
        string name_uo = "";
        string comment_uo = "";
        public int Id
        {
            get => id_uo;
            set
            {
                if (id_uo != value)
                {
                    id_uo = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name
        {
            get => name_uo;
            set
            {
                if (name_uo != value)
                {
                    name_uo = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Comment
        {
            get => comment_uo;
            set
            {
                if (comment_uo != value)
                {
                    comment_uo = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public Otdelenie()
        {
            id_uo = 0; name_uo = string.Empty; comment_uo = string.Empty;
        }
        public Otdelenie(int _id, string _name, string kurz)
        {
            id_uo = _id; name_uo = _name; comment_uo=kurz;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
    public class ListOtdelenie : ObservableCollection<Otdelenie>
    {
        public ListOtdelenie()
        {
            GetListOtdelenie();
        }
        public void GetListOtdelenie()
        {
            BazaSoft bs = new BazaSoft();
            string sql = "select * FROM uch_otdelenie";
            DataTable dt = bs.getTable(sql);

            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    Otdelenie sp = new Otdelenie(dr.Field<int>("id_uo"),
                                                       
                                                         dr.Field<string>("name_uo"),
                                                         dr.Field<string>("comment_uo")
                                                         );
                    this.Add(sp);

                }


        }
    }

    #region Классы Kvalification ListKvalification
    public class Kvalification : INotifyPropertyChanged
    {
        int id_sp;
        string name_sp = "";
        string name_kurz = "";
        public int Id
        {
            get => id_sp;
            set
            {
                if (id_sp != value)
                {
                    id_sp = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name
        {
            get => name_sp;
            set
            {
                if (name_sp != value)
                {
                    name_sp = value;
                    OnPropertyChanged();
                }
            }
        }
        public string NameKurz
        {
            get => name_kurz;
            set
            {
                if (name_kurz != value)
                {
                    name_kurz = value;
                    OnPropertyChanged();
                }
            }
        }
        public string FullName
        {
            get => string.Format("{0} ({1})", name_sp, name_kurz);
        }
        public Kvalification()
        {
            id_sp = 0; name_sp = string.Empty; name_kurz = string.Empty;
        }
        public Kvalification(int _id, string _name, string kurz)
        {
            id_sp = _id; name_sp = _name; name_kurz=kurz;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
    public class ListKvalification : ObservableCollection<Kvalification>
    {
        public ListKvalification()
        {
            GetListKvalification();
        }
        public void GetListKvalification()
        {
            BazaSoft bs = new BazaSoft();
            string sql = "select * FROM kvalifications";
            DataTable dt = bs.getTable(sql);

            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    Kvalification kf = new Kvalification(dr.Field<int>("id_kf"),
                                                         dr.Field<string>("name_kf"),
                                                         dr.Field<string>("name_kurz"));
                    this.Add(kf);

                }


        }
    }
    #endregion --------------------------

    #region Классы Specialnost и ListSpecialnost
    public class Specialnost : INotifyPropertyChanged
    {
        int id_sp;
        int id_kf;
        string name_sp = "";
        string cod_sp = "";
        string fullname = "";
        int srok_mes = 0;
        int baza_sp = 0;
        public int Id
        {
            get => id_sp;
            set
            {
                if (id_sp != value)
                {
                    id_sp = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Id_kf
        {
            get => id_kf;
            set
            {
                if (id_kf != value)
                {
                    id_kf = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Srok_mes
        {
            get => srok_mes;
            set
            {
                if (srok_mes != value)
                {
                    srok_mes = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Baza_sp
        {
            get => baza_sp;
            set
            {
                if (baza_sp != value)
                {
                    baza_sp = value;
                    OnPropertyChanged();
                }
            }
        }
        public string FullName
        {
            get => fullname;
        }
        public string Name
        {
            get => name_sp;
            set
            {
                if (name_sp != value)
                {
                    name_sp = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Cod_sp
        {
            get => cod_sp;
            set
            {
                if (cod_sp != value)
                {
                    cod_sp = value;
                    OnPropertyChanged();
                }
            }
        }

        public Specialnost()
        {
            id_sp = 0; name_sp = string.Empty; cod_sp = string.Empty;
        }
        public Specialnost(int _id, int _idkf, string _name, string _cod, string full, int _srok, int _baza)
        {
            id_sp = _id; name_sp = _name;
            id_kf = _idkf; cod_sp=_cod;
            srok_mes = _srok; baza_sp=_baza;
            fullname=full;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
    public class ListSpecialnost : ObservableCollection<Specialnost>
    {
        public ListSpecialnost()
        {
            GetListSpecialnost();
        }
        public void GetListSpecialnost()
        {
            BazaSoft bs = new BazaSoft();
            string sql = "select * FROM specialnost_view";
            DataTable dt = bs.getTable(sql);

            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    Specialnost sp = new Specialnost(dr.Field<int>("id_sp"),
                                                         dr.Field<int>("id_kf"),
                                                         dr.Field<string>("name_sp"),
                                                         dr.Field<string>("cod_sp"),
                                                          dr.Field<string>("fullname"),
                                                         dr.Field<int>("srok_mes"),
                                                         dr.Field<int>("baza_sp")
                                                         );
                    this.Add(sp);

                }


        }
    }
    #endregion

    #region Классы Prepod ListPrepod
    public class Prepod : INotifyPropertyChanged
    {
        int id_prepod;
        int id_kategoria;
        int id_uo;
        string name = "";
        string fam = "";
        string otch = "";
        public int Id
        {
            get => id_prepod;
            set
            {
                if (id_prepod != value)
                {
                    id_prepod = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Id_kategoria
        {
            get => id_kategoria;
            set
            {
                if (id_kategoria != value)
                {
                    id_kategoria = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Id_uo
        {
            get => id_uo;
            set
            {
                if (id_uo != value)
                {
                    id_uo = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Fam
        {
            get => fam;
            set
            {
                if (fam != value)
                {
                    fam = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Otch
        {
            get => otch;
            set
            {
                if (otch != value)
                {
                    otch = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Fio
        {
            get
            {
                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Otch))
                    return Fam;
                else
                    return string.Format("{0} {1}.{2}.",
                Fam, Name.Substring(0, 1).ToUpper(), Otch.Substring(0, 1).ToUpper());
            }
        }
        public Prepod()
        {
            
        }
        public Prepod(int _id,int _id_k, int _id_uo, string _fam, string _name, string _otch)
        {
            id_prepod = _id; id_kategoria = _id_k; id_uo = _id_uo;
            fam = _fam;name = _name; otch=_otch;
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
    public class ListPrepod : ObservableCollection<Prepod>
    {
        public ListPrepod()
        {
            GetListPrepod();
        }
        public void GetListPrepod()
        {
            BazaSoft bs = new BazaSoft();
            string sql = "select * FROM prepods";
            DataTable dt = bs.getTable(sql);
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int id_uo=0;
                        int id_prepod = int.Parse(dr["id_prepod"].ToString());
                        int id_kategoria = dr.IsNull("id_kategoria") ? 0 : int.Parse(dr["id_kategoria"].ToString());
                        if (!dr.IsNull("id_uo"))
                            id_uo = int.Parse(dr["id_uo"].ToString());
                        string fam = dr.IsNull("fam") ? "" : dr["fam"].ToString();
                        string name = dr.IsNull("name") ? "" : dr["name"].ToString();
                        string otch = dr.IsNull("otch") ? "" : dr["otch"].ToString();

                        Prepod pers = new Prepod(id_prepod, id_kategoria, id_uo, fam, name, otch);
                        /*
                        Prepod pers = new Prepod(dr.Field<int>("id_prepod"),
                                                             dr.Field<int>("id_kategoria"),
                                                             dr.Field<string>("fam"),
                                                             dr.Field<string>("name"),
                                                             dr.Field<string>("otch")
                                                             );
                        */
                        this.Add(pers);
                    }
                    catch {
                        continue;
                    }

                }


        }
    }

    #endregion --------------------------


    #region Классы Group и ListGroup и GroupPlanInfo
    public class Group : INotifyPropertyChanged
    {
        int id_group;
        int id_sp;
        int id_kf;
        int id_tip;
        string name_group = "";
        string name_tip = "";
        string cod_sp = "";
        string name_sp = "";
        int srok_mes = 0;
        int baza_sp = 0;
        long kurs = 0;
        int id_uo;
        string name_uo = "";
        int count;
        int count_1;
        int count_2;
        public int Id
        {
            get => id_group;
            set
            {
                if (id_group != value)
                {
                    id_group = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Id_sp
        {
            get => id_sp;
            set
            {
                if (id_sp != value)
                {
                    id_sp = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Id_uo
        {
            get => id_uo;
            set
            {
                if (id_uo != value)
                {
                    id_uo = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Id_kf
        {
            get => id_kf;
            set
            {
                if (id_kf != value)
                {
                    id_kf = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Srok_mes
        {
            get => srok_mes;
            set
            {
                if (srok_mes != value)
                {
                    srok_mes = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Baza_sp
        {
            get => baza_sp;
            set
            {
                if (baza_sp != value)
                {
                    baza_sp = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name_tip
        {
            get => name_tip;
        }


        public string NameGroup
        {
            get => name_group;
            set
            {
                if (name_group != value)
                {
                    name_group = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Cod_sp
        {
            get => cod_sp;
            set
            {
                if (cod_sp != value)
                {
                    cod_sp = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name_sp
        {
            get => name_sp;
            set
            {
                if (name_sp != value)
                {
                    name_sp = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name_uo
        {
            get => name_uo;
            set
            {
                if (name_uo != value)
                {
                    name_uo = value;
                    OnPropertyChanged();
                }
            }
        }
        public long Kurs
        {
            get => kurs;
            set
            {
                if (kurs != value)
                {
                    kurs = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Count
        {
            get => count;
            set
            {
                if (count != value)
                {
                    count = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Count_1
        {
            get => count_1;
            set
            {
                if (count_1 != value)
                {
                    count_1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Count_2
        {
            get => count_2;
            set
            {
                if (count_2 != value)
                {
                    count_2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public GroupPlanInfo groupPlanInfo { get; set; }
        public Group()
        {
            id_sp = 0; name_group = string.Empty; 
            cod_sp = string.Empty; name_sp = string.Empty;
        }
        public Group(int _id, int _id_sp, int _idkf, 
            string _name, string _cod, string _name_sp, 
            long _kurs, int _srok, int _baza, int idtip, 
            string nametip,int _id_uo,string _name_uo,
            int _count,int _count_1,int _count_2)
        {
            id_group = _id; name_group = _name;
            id_sp=_id_sp;
            id_kf = _idkf; cod_sp=_cod;
            name_sp=_name_sp;
            srok_mes = _srok; baza_sp=_baza;
            kurs= _kurs;
            id_tip=idtip; name_tip=nametip;
            id_uo=_id_uo; name_uo=_name_uo;
            count=_count; count_1 = _count_1;
            count_2 = _count_2;
            groupPlanInfo = new GroupPlanInfo(this);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
    public class ListGroup : ObservableCollection<Group>
    {
        public ListGroup()
        {
            GetListGroup();
        }
        public void GetListGroup()
        {
            BazaSoft bs = new BazaSoft();
            string sql = "select * FROM groups_view";
            DataTable dt = bs.getTable(sql);

            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    long x = dr.Field<long>("kurs");
                    Group sp = new Group(
                        dr.Field<int>("id_group"),
                        dr.Field<int>("id_sp"),
                        dr.Field<int>("id_kf"),
                        dr.Field<string>("name_group"),
                        dr.Field<string>("cod_sp"),
                        dr.Field<string>("name_sp"),
                        dr.Field<long>("kurs"),
                        dr.Field<int>("srok_mes"),
                        dr.Field<int>("baza_sp"),
                        dr.Field<int>("id_tip"),
                        dr.Field<string>("name_tip"),
                        int.Parse(dr["id_uo"].ToString()),
                        dr.Field<string>("name_uo"),
                        int.Parse(dr["count"].ToString()),
                        int.Parse(dr["count_1"].ToString()),
                        int.Parse(dr["count_2"].ToString())
                        );                        ;
                    this.Add(sp);

                }


        }
    }
    public class GroupPlanInfo
    {
        public int Id_group { get; set; }
        public long Semestr1 { get; set; }
        public long Semestr2 { get; set; }
        public long Itogo { get; set; }
        public long Count { get; set; }
        public GroupPlanInfo(Group group)
        {
            CalculateItogFromPlan(group);
        }
        public void CalculateItogFromPlan(Group group)
        {
            BazaSoft bs = new BazaSoft();
            string sql = "select sum(Item2) as Semestr1,sum(Item4) as Semestr2 FROM uch_plan_groups where id_group="+group.Id.ToString();
            string sql_count = "select COUNT(*) as Count FROM uch_plan_groups where id_group="+group.Id.ToString();
            DataTable dt = bs.getTable(sql);
            if (dt.Rows.Count == 0)
            {
                Semestr1 =0; Semestr2=0; Itogo = 0; Count=0;
            }
            else
            {
                if (!dt.Rows[0].IsNull("Semestr1"))
                    Semestr1=(long)dt.Rows[0].Field<decimal>("Semestr1");
                else
                    Semestr1=0;
                if (!dt.Rows[0].IsNull("Semestr2"))
                    Semestr2= (long)dt.Rows[0].Field<decimal>("Semestr2");
                else
                    Semestr2=0;
                Itogo= Semestr1+Semestr2;
                Count = bs.getCountRows("uch_plan_groups", group.Id);
            }
        }
    }
        
        #endregion

    #region Классы для работы с учебным планом
    public enum UchPlanStatus
    {
        New,
        Norma,
        Old,
        Mode
    }
    public class UchPlanGroup:INotifyPropertyChanged
    {
        string stringStatus;
        public int Id { get; set; }
        public string TableName { get; set; }

        public Group group { get; set; }
        public UchPlanStatus status { get; set; }
      
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


        BazaSoft bsManager;
        string sql_get_plan = "select uch_plan_groups.*,predmets.index_pr from uch_plan_groups "+
                               "LEFT JOIN predmets ON predmets.id_pr = id_predmet where id_group={0}";
        string sql_new_plan = "select * From get_empty_plan limit 0";
        string sql_insert_predmets = "select * From predmets where id_sp={0} and kurs={1}";
        string sql_delete_plan = "delete  From uch_plan_groups where id_group={0}";
        public UchPlanGroup(Group _group) : this(_group.Id)
        {
            group = _group;
        }
        public UchPlanGroup(int id_group)
        {
            bsManager = new BazaSoft();
            TableName="uch_plan_groups";
            Id= id_group;
            status = GetStaus();
           // sql_new_plan=string.Format(sql_new_plan, TableName);
        }
        UchPlanStatus GetStaus()
        {
           int countRows = bsManager.getCountRows(TableName, Id);
            if (countRows == 0)
            {
                StringStatus ="Новый";
                return UchPlanStatus.New;
            } 
            else
            {
                StringStatus ="Норма";
                return UchPlanStatus.Norma;
            }
            
        }
        public void DeleteUchPlan()
        {
            string sql =string.Format(sql_delete_plan,group.Id);
            int n = bsManager.RunCommand(sql);
        }
        public DataView GetUchPlan()
        {
           string sql = string.Format(sql_get_plan,group.Id);
           DataTable dt = bsManager.getTable_AvtoIncriment(sql);
         
           
            InsertInfoColumns(dt);
            dt.AcceptChanges();
            return dt.DefaultView;
        
         }
        public DataView GetNewUchPlan()
        {
            int count = 0;
            DataTable dt = bsManager.getTable(sql_new_plan);
            AddAvtoIncrementColumn(dt);
            string sql = string.Format(sql_insert_predmets, group.Id_sp, group.Kurs);
            DataTable dtSourse = bsManager.getTable(sql);
            foreach (DataRow dr in dtSourse.Rows)
            {
                DataRow rTarget = dt.NewRow();
                rTarget["id_group"] = group.Id;
                rTarget["id_predmet"]=dr["id_pr"];
                rTarget["index_pr"]=dr[3].ToString();
                rTarget["name_pr"]=dr["name_pr"].ToString();

                foreach (DataColumn colunm in dt.Columns) 
                {
                    string ColName = colunm.ColumnName;
                    if(ColName.IndexOf("Item") !=-1)
                    {
                        rTarget[ColName] =0;
                    }
                }
                dt.Rows.Add(rTarget);
            }
            InsertInfoColumns(dt);
            return dt.DefaultView;
        }
        void AddAvtoIncrementColumn(DataTable dt)
        {
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Number";
            dc.DataType = typeof(int);
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 1;
            dc.AutoIncrementStep = 1;
            dt.Columns.Add(dc);
        }
        void InsertInfoColumns(DataTable dt)
        {

            dt.Columns.Add("Vsego1", typeof(Int64));
            dt.Columns.Add("Vsego2", typeof(Int64));
            dt.Columns.Add("Itogo", typeof(Int64));
            dt.Columns["Vsego1"].Expression = "Item2+Item4";
            dt.Columns["Vsego2"].Expression = "Item6+Item7+Item8+Item9+Item10+Item11+Item12+Item13+Item14+Item15";
            dt.Columns["Itogo"].Expression = "Vsego2+Item16+Item17+Item18";
          
        }

        
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
    #endregion
}
