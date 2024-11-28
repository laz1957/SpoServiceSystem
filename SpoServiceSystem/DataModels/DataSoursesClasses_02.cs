using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpoServiceSystem.DataModels
{
    public class PrepodFullItog 
        : INotifyPropertyChanged
    {
        int id_prepod;
        int id_uo;
        int id_kategoria;
        int itog1;
        int itog2;
        int itog;
        int fullsumma;
        string fam = "";
        string name = "";
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
        public int Itog1
        {
            get => itog1;
            set
            {
                if (itog1 != value)
                {
                    itog1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Itog2
        {
            get => itog2;
            set
            {
                if (itog2 != value)
                {
                    itog2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Itog
        {
            get => itog;
            set
            {
                if (itog != value)
                {
                    itog = value;
                    
                    OnPropertyChanged();
                }
            }
        }
        public int FullSumma
        {
            get => fullsumma;
            set
            {
                if (fullsumma != value)
                {
                    fullsumma = value;

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
                 return string.Format("{0} {1}.{2}", Fam,
                                 Name.Substring(0, 1).ToUpper(),
                                 Otch.Substring(0, 1).ToUpper());
            }
        }
    
      
      
        public PrepodFullItog()
        {
           
        }
       


        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }

    public class ListPrepodFullItog : ObservableCollection<PrepodFullItog> 
    {
        public ListPrepodFullItog() {
            Init();
        }
        void Init()
        {
            string sql = "SELECT * FROM prepods_itogi_view";
            BazaSoft bs = new BazaSoft();
            DataTable dt = bs.getTable(sql);
            foreach(DataRow row in dt.Rows)
            {
                PrepodFullItog item = new PrepodFullItog()
                {
                    Id = int.Parse(row["id_prepod"].ToString()),
                    Id_kategoria= row.IsNull("id_kategoria") ? 0 : int.Parse(row["id_kategoria"].ToString()),
                    Id_uo =row.IsNull("id_uo") ? 0: int.Parse(row["id_uo"].ToString()),
                    Fam = row["fam"].ToString(),
                    Name = row["name"].ToString(),
                    Otch = row["otch"].ToString(),
                    Itog = row.IsNull("Itog") ? 0 : int.Parse(row["Itog"].ToString()),
                    Itog1 =row.IsNull("Itog1") ? 0 : int.Parse(row["Itog1"].ToString()),
                    Itog2 =row.IsNull("Itog2") ? 0 : int.Parse(row["Itog2"].ToString()),
                    FullSumma =row.IsNull("FullSumma" ) ? 0 : int.Parse(row["FullSumma"].ToString())
                };

                this.Add(item);
            }
        }
    }


    public class PrepodPredmetItem : INotifyPropertyChanged
    {
        int id_up, id_predmet, id_prepod, id_group, id_sp, id_kf = 0;
        


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class PrepodPredmetsData
    {
        DataTable dt;
        public PrepodPredmetsData()
        {
            Init();
        }
        public PrepodPredmetsData(int idPrepod)
        {
            Init(idPrepod);
        }
        void Init()
        {
            string sql_Procedure = "GET_EMPTY_UCHPLAN";
            BazaSoft bs = new BazaSoft();
            dt=bs.getTableFromPprocedure(sql_Procedure);
            AddColumns();
        }
        void Init(int idPrepod)
        {
            //string sql_Procedure = "GET_PREDMETS_PREPOD";
            string sql_Procedure = "PREPOD_FULLDATA";
            BazaSoft bs = new BazaSoft();
            dt=bs.getTableFromPprocedure(sql_Procedure, idPrepod);
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
        public bool IsEmpty()
        {
            if(dt == null) return true;
            if (dt.Rows.Count==0) return true;
            return false;

        }

    }

    public class ItogiTable : INotifyPropertyChanged
    {
        int itogoItem1, itogoItem2, itogoItem3, itogoItem4, itogoItem5, itogoItem6,
            itogoItem7, itogoItem8, itogoItem9, itogoItem10, itogoItem11, itogoItem12,
            itogoItem13, itogoItem14, itogoItem15, itogoItem16, itogoItem17, itogoItem18,
            itogoItem19, itogoItem20, itogoItem21, itogoItem22 = 0;
        public int ItogoItem1 { get=> itogoItem1; set { itogoItem1=value; OnPropertyChanged(); } }
        public int ItogoItem2 { get => itogoItem2; set { itogoItem2=value; OnPropertyChanged(); } }
        public int ItogoItem3 { get => itogoItem3; set { itogoItem3=value; OnPropertyChanged(); } }
        public int ItogoItem4 { get => itogoItem4; set { itogoItem4=value; OnPropertyChanged(); } }
        public int ItogoItem5 { get => itogoItem5; set { itogoItem5=value; OnPropertyChanged(); } }
        public int ItogoItem6 { get => itogoItem6; set { itogoItem6=value; OnPropertyChanged(); } }
        public int ItogoItem7 { get => itogoItem7; set { itogoItem7=value; OnPropertyChanged(); } }
        public int ItogoItem8 { get => itogoItem8; set { itogoItem8=value; OnPropertyChanged(); } }
        public int ItogoItem9 { get => itogoItem9; set { itogoItem9=value; OnPropertyChanged(); } }
        public int ItogoItem10 { get => itogoItem10; set { itogoItem10=value; OnPropertyChanged(); } }
        public int ItogoItem11 { get => itogoItem11; set { itogoItem11=value; OnPropertyChanged(); } }
        public int ItogoItem12 { get => itogoItem12; set { itogoItem12=value; OnPropertyChanged(); } }
        public int ItogoItem13 { get => itogoItem13; set { itogoItem13=value; OnPropertyChanged(); } }
        public int ItogoItem14 { get => itogoItem14; set { itogoItem14=value; OnPropertyChanged(); } }
        public int ItogoItem15 { get => itogoItem15; set { itogoItem15=value; OnPropertyChanged(); } }
        public int ItogoItem16 { get => itogoItem16; set { itogoItem16=value; OnPropertyChanged(); } }
        public int ItogoItem17 { get => itogoItem17; set { itogoItem17=value; OnPropertyChanged(); } }
        public int ItogoItem18 { get => itogoItem18; set { itogoItem18=value; OnPropertyChanged(); } }
        public int ItogoItem19 { get => itogoItem19; set { itogoItem19=value; OnPropertyChanged(); } }
        public int ItogoItem20 { get => itogoItem20; set { itogoItem20=value; OnPropertyChanged(); } }
        public int ItogoItem21 { get => itogoItem21; set { itogoItem21=value; OnPropertyChanged(); } }

        public int ItogoItem22 { get => itogoItem22; set { itogoItem22=value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
