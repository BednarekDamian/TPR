using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

namespace Model
{
    public abstract class Change : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void WhenPropertyChanged([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}