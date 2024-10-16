using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SpoServiceSystem.DataModels
{
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
        int srok_mes = 0;
        int baza_sp = 0;
        long kurs = 0;
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
        public GroupPlanInfo groupPlanInfo { get; set; }
        public Group()
        {
            id_sp = 0; name_group = string.Empty; cod_sp = string.Empty;
        }
        public Group(int _id, int _id_sp, int _idkf, string _name, string _cod, long _kurs, int _srok, int _baza, int idtip, string nametip)
        {
            id_group = _id; name_group = _name;
            id_sp=_id_sp;
            id_kf = _idkf; cod_sp=_cod;
            srok_mes = _srok; baza_sp=_baza;
            kurs= _kurs;
            id_tip=idtip; name_tip=nametip;
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
                        dr.Field<long>("kurs"),
                        dr.Field<int>("srok_mes"),
                        dr.Field<int>("baza_sp"),
                        dr.Field<int>("id_tip"),
                        dr.Field<string>("name_tip")
                          );
                    this.Add(sp);

                }


        }
    }
    public class GroupPlanInfo
    {
        public int Id_group { get; set; }
        public int Semestr1 { get; set; }
        public int Semestr2 { get; set; }
        public int Itogo { get; set; }
        public GroupPlanInfo(Group group)
        {
            BazaSoft bs = new BazaSoft();
            string sql = "select sum(Item1) as Semestr1,sum(Item2) as Semestr2 FROM uch_plan_groups where id_group="+group.Id.ToString();
            DataTable dt = bs.getTable(sql);
            if (dt.Rows.Count == 0)
            {
                Semestr1 =0; Semestr2=0; Itogo = 0;
            }
            else
            {
                if (!dt.Rows[0].IsNull("Semestr1"))
                    Semestr1= dt.Rows[0].Field<int>("Semestr1");
                else
                    Semestr1=0;
                if (!dt.Rows[0].IsNull("Semestr2"))
                    Semestr2= dt.Rows[0].Field<int>("Semestr2");
                else
                    Semestr2=0;
                Itogo= Semestr1+Semestr2;
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
    public class UchPlanGroup
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public UchPlanStatus status { get; set; }

        BazaSoft bsManager;
        public UchPlanGroup(Group group) : this(group.Id)
        {

        }
        public UchPlanGroup(int id_group)
        {
            bsManager = new BazaSoft();
            TableName="uch_plan_groups";
            Id= id_group;
            status = GetStaus();
        }
        UchPlanStatus GetStaus()
        {
           int countRows = bsManager.getCountRows(TableName, Id);
            if (countRows == 0) return UchPlanStatus.New;
            else return UchPlanStatus.Norma;
            
        }
        #endregion
    }
}
