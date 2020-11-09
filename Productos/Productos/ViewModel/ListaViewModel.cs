
using Productos.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms.MultiSelectListView;

namespace Productos.ViewModel
{
    public class ListaViewModel: BindableObject,INotifyPropertyChanged
    {

        ObservableCollection<Producto> _productoPush;
        ObservableCollection<Producto> _productoNormal;
        ObservableCollection<Producto> _pedidoProducto;

        public List<Producto> _pPush;
        public List<Producto> _pNormal;

        public List<Producto> _pProducto;

        public ObservableCollection<Producto> ProductoNormal
        {
            get
            {
                return _productoNormal;
            }
            set
            {
                if (_productoNormal != value)
                {
                    _productoNormal = value;
                    NotifyPropertyChanged(nameof(ProductoNormal));
                }
            }
        }
        public ObservableCollection<Producto> PedidoProducto
        {
            get
            {
                return _pedidoProducto;
            }
            set
            {
                if (_pedidoProducto != value)
                {
                    _pedidoProducto = value;
                    NotifyPropertyChanged(nameof(PedidoProducto));
                }
            }
        }
        public ObservableCollection<Producto> ProductoPush
        {
            get
            {
                return _productoPush;
            }
            set
            {
                if(_productoPush!= value)
                {
                    _productoPush = value;
                    NotifyPropertyChanged(nameof(ProductoPush));
                }
            }
        }


        private string _filter;

        public string Filter
        {
            get { return _filter; }
            set
            { 
                if(_filter != value)
                {
                    _filter = value;
                    Search();
                    NotifyPropertyChanged(nameof(Filter));
                }
            }
        }

        private bool _isVisible;

        private int _selectioMode;

        public int SelectionMod
        {
            get { return _selectioMode; }
            set
            {
                if (_selectioMode != value)
                {
                    _selectioMode = value;
                    NotifyPropertyChanged(nameof(SelectionMod));
                }
            }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (_isVisible != value)
                {
                    _isVisible = value;
                    NotifyPropertyChanged(nameof(IsVisible));
                }
            }
        }

        private bool _isVisiblePedido;

        public bool IsVisiblePedido
        {
            get { return _isVisiblePedido; }
            set
            {
                if (_isVisiblePedido != value)
                {
                    _isVisiblePedido = value;
                    NotifyPropertyChanged(nameof(IsVisiblePedido));
                }
            }
        }
   
        #region construct
        public ListaViewModel()
        {
            LoadProductoPush();
            LoadProductoNormal();
            IsVisible = false;
            IsVisiblePedido = true;
            AddToListCommand = new Command(AddToList);
            DeleteToListCommand = new Command(DeleteToList);
            SelectionMod = 1;
        }
        #endregion

        #region Command
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }
        public ICommand AddToListCommand { get; }
        public ICommand DeleteToListCommand { get; }
        #endregion

        #region methods
        public async void AddToList(object obj)
        {
            var contenido = obj as Producto;
            _pProducto.Add(contenido);
            PedidoProducto = new ObservableCollection<Producto>(_pProducto.OrderBy(p => p.Codigo));
            await App.Current.MainPage.DisplayAlert("Información", "Elemento "+ contenido.Nombre+ " Agregado correctamente", "ok");
            IsVisible = false;
            IsVisiblePedido = true;
        }
        public async void DeleteToList(object obj)
        {
            var contenido = obj as Producto;
            if(contenido.Tipo == 1)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No se puede eliminar "+contenido.Nombre, "ok");
            }
            else
            {
                _pProducto.Remove(contenido);
                await App.Current.MainPage.DisplayAlert("Error", "Elemento eliminado de la lista " + contenido.Nombre, "ok");
                PedidoProducto = new ObservableCollection<Producto>(_pProducto.OrderBy(p => p.Codigo));
            }
        }
        void Search()
        {
            IsVisible = true;
            IsVisiblePedido = false;
            if (string.IsNullOrEmpty(Filter))
            {
                IsVisible = false;
                IsVisiblePedido = true;
            }
            if (Filter.Equals("."))
            {
                ProductoNormal = new ObservableCollection<Producto>(_pNormal.OrderBy(p => p.Codigo));
            }
            else
            {
                ProductoNormal = new ObservableCollection<Producto>(_pNormal.Where
                    (c => c.Nombre.ToLower().Contains(Filter.ToLower())).OrderBy(c => c.Codigo));
            }
        }
        void LoadProductoPush()
        {
            //validaciob de conexion o busqueda en bd

            //coleccion de prueba

            _pPush = new List<Producto>();//lista 

            _pPush.Add(new Producto { id = 1, Codigo = "0001", Nombre = "Emperador", Cantidad = 1, Tipo = 1 });
            _pPush.Add(new Producto { id = 2, Codigo = "0002", Nombre = "Marias", Cantidad = 1, Tipo = 1 });
            _pPush.Add(new Producto { id = 3, Codigo = "0003", Nombre = "Doradas", Cantidad = 1, Tipo = 1 });
            _pPush.Add(new Producto { id = 4, Codigo = "0004", Nombre = "Bombitos", Cantidad = 1, Tipo = 1 });
            _pPush.Add(new Producto { id = 5, Codigo = "0005", Nombre = "Canelitas", Cantidad = 1, Tipo = 1 });
            _pPush.Add(new Producto { id = 6, Codigo = "0006", Nombre = "Chetos", Cantidad = 1, Tipo = 1 });
            var ListPoductoPush = _pPush;
            ProductoPush = new ObservableCollection<Producto>(
                ListPoductoPush.OrderBy(p =>p.Codigo));

            if(ProductoPush.Count > 0)
            {
                _pProducto = _pPush;// productos del pedido
                PedidoProducto = new ObservableCollection<Producto>(_pProducto.OrderBy(p => p.Codigo));
            }
            
        }
        void LoadProductoNormal()
        {
            //validaciob de conexion o busqueda en bd

            //coleccion de prueba

            _pNormal = new List<Producto>();//lista 

            _pNormal.Add(new Producto { id = 1, Codigo = "0007", Nombre = "EmperadorN", Cantidad = 1, Tipo = 2 });
            _pNormal.Add(new Producto { id = 2, Codigo = "0008", Nombre = "MariasN", Cantidad = 1, Tipo = 2 });
            _pNormal.Add(new Producto { id = 3, Codigo = "0009", Nombre = "DoradasN", Cantidad = 1, Tipo = 2 });
            _pNormal.Add(new Producto { id = 4, Codigo = "0010", Nombre = "BombitosN", Cantidad = 1, Tipo = 2 });
            _pNormal.Add(new Producto { id = 5, Codigo = "0011", Nombre = "CanelitaN", Cantidad = 1, Tipo = 2 });
            _pNormal.Add(new Producto { id = 6, Codigo = "0012", Nombre = "ChetoN", Cantidad = 1, Tipo = 2 });
            var ListPoductoNormal = _pNormal;
            ProductoNormal = new ObservableCollection<Producto>(
                ListPoductoNormal.OrderBy(p => p.Codigo));

        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertName));
        }


        //selection collection

    }
}
