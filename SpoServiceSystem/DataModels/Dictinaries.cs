using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace SpoServiceSystem.DataModels
{
    public class TipUch : INotifyPropertyChanged
    {
        int id;
        string name = "";
        public int Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
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
        public TipUch() {
            id = 0; name = string.Empty;
        }
        public TipUch(int _id, string _name)
        {
            id = _id; name = _name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }

    public class TipUchList:ObservableCollection<TipUch>
    {
        public TipUchList() { 
            Add(new TipUch(1,"Иван"));
            Add(new TipUch(2, "Сергей"));
            Add(new TipUch(3, "Петр"));
            Add(new TipUch(4, "Игнат"));
            Add(new TipUch(5, "Семен"));
        }

    }


    public class Special
    {
        int Id { get; set; }
        public string Name { get; set; }
        public string Cod { get; set; }

        int Srok { get; set; }
        int Basa { get; set; }
    }

    public class Kategoria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
    public class Kantgories : List<Kategoria>
    {
        public Kantgories()
        {
            Add(new Kategoria() { Id=1, Name="Высшая" });
            Add(new Kategoria() { Id=2, Name="Первая" });
            Add(new Kategoria() { Id=3, Name="Вторая" });
            Add(new Kategoria() { Id=4, Name="Нет категории" });
        }
    }

    public class Kurs
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Kurses : List<Kurs>
    {
        public Kurses()
        {
            Add(new Kurs() { Id=1, Name="Первый" });
            Add(new Kurs() { Id=2, Name="Второй" });
            Add(new Kurs() { Id=3, Name="Третий" });
            Add(new Kurs() { Id=4, Name="Четвертый" });
        }
    }
    public class Predmet:INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int id_sp { get; set; }
        public string Index { get; set; }
        public Kurs Name { get; set; }

        int item1;
        public int Item1
        {
            get { return item1; }
            set { item1=value; OnPropertyChanged(); }
        }
        int item2 ;
        public int Item2 { get { return item2; }
                          set { item2=value; OnPropertyChanged(); } }
        int item3;
        public int Item3
        {
            get { return item3; }
            set { item3=value; OnPropertyChanged(); }
        }
        int item4;
        public int Item4
        {
            get { return item4; }
            set { item4=value; OnPropertyChanged(); }
        }
        int item5;
        public int Item5
        {
            get { return item5; }
            set { item5=value; OnPropertyChanged(); }
        }

        int item6;
        public int Item6
        {
            get { return item6; }
            set { item6=value; OnPropertyChanged(); }
        }
        int item7;
        public int Item7
        {
            get { return item7; }
            set { item7=value; OnPropertyChanged(); }
        }
        int item8;
        public int Item8
        {
            get { return item8; }
            set { item8=value; OnPropertyChanged(); }
        }
        int item9;
        public int Item9
        {
            get { return item9; }
            set { item9=value; OnPropertyChanged(); }
        }
        int item10;
        public int Item10
        {
            get { return item10; }
            set { item10=value; OnPropertyChanged(); }
        }
        int item11;
        int item12;
        public int Item11
        {
            get { return item11; }
            set { item11=value; OnPropertyChanged(); }
        }
        public int Item12
        {
            get { return item12; }
            set { item12=value; OnPropertyChanged(); }
        }
        int item13;
        public int Item13
        {
            get { return item13; }
            set { item13=value; OnPropertyChanged(); }
        }
        int item14;
        public int Item14
        {
            get { return item14; }
            set { item14=value; OnPropertyChanged(); }
        }
        int item15;
        public int Item15
        {
            get { return item15; }
            set { item15=value; OnPropertyChanged(); }
        }
        int item16;
        public int Item16
        {
            get { return item16; }
            set { item16=value; OnPropertyChanged(); }
        }
        int item17;

        public int Item17
        {
            get { return item17; }
            set { item17=value; OnPropertyChanged(); }
        }
        int item18;
        public int Item18
        {
            get { return item18; }
            set { item18=value; OnPropertyChanged(); }
        }
        public int Vsego1 { get { return Item2+Item4; } }
        public int Vsego2 { get { return Item6+Item7+Item8+Item9+Item10+Item11+Item12+Item13+Item14+Item15; } }
        public int Itogo { get { return Vsego2+Item16+Item17+Item18; } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
    public class Prepmets : ObservableCollection<Predmet>
    {
        public Prepmets()
        {
            Add(new Predmet() { Id=1, Index="MDX", Name=new Kurs() { Id=1, Name="Первый" } , Item1=0, Item2=18, Item3=0, Item4=18, Item5=0,
                                Item6=22,Item7=14,Item8=0, Item9=0, Item10=0, Item11=0, Item12=0, Item13=0,
                Item14=0,
                Item15=0,
                Item16=0,
                Item17=0,
                Item18=0
            });
            Add(new Predmet()
            {
                Id=1,
                Index="WWW",
                Name=new Kurs() { Id=1, Name="Второй" },
                Item1=0,
                Item2=18,
                Item3=0,
                Item4=18,
                Item5=0,
                Item6=22,
                Item7=14,
                Item8=0,
                Item9=0,
                Item10=0,
                Item11=0,
                Item12=0,
                Item13=0,
                Item14=0,
                Item15=0,
                Item16=0,
                Item17=0,
                Item18=0
            });
           
           
        }
    }


}
