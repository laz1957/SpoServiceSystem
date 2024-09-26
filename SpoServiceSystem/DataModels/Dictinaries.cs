using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
        public TipUchList() { }

    }
}
