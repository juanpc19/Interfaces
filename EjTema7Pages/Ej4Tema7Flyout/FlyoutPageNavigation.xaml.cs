using Ej4Tema7Flyout.Views.MenuFlyout;

namespace Ej4Tema7Flyout
{
    //esta es la principal, contendra el FlyoutMenuPage en el lateral izq(en nuestro caso pero se podria cambiar disposicion)
    //y cambiara su contenido segun que pag selecciones
    public partial class FlyoutPageNavigation : FlyoutPage
    {
        

        public FlyoutPageNavigation()
        {
            InitializeComponent();
             //agrego metodo al cambiar vista de coleccion, es decir al ir a otra pagina de las que estan dentro de FlyoutMenuPage
            flyoutPage.collectionView.SelectionChanged += OnSelectionChanged;

        }
        //el metodo se encargara de cambiar el contenido/pagina que se visualizara
        void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;

            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                if (!((IFlyoutPageController)this).ShouldShowSplitMode)
                    IsPresented = false;
            }
        }


    }
}