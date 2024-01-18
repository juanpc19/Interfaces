using System.ComponentModel;


namespace MauiSignalR.ViewModels.Utilidades
{
    public abstract class clsVMBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //le falta [CallMembername] sin eso nombre propiedad siempre escrito
        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
