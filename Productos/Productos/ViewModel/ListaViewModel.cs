using Productos.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Productos.ViewModel
{
    public class ListaViewModel
    {

        public ObservableCollection<Producto> _productoPush { get; set; }
        public ObservableCollection<Producto> _productoNormal { get; set; }

        #region construct
        public ListaViewModel()
        {
            _productoPush = new ObservableCollection<Producto>();
            _productoPush.Add(new Producto
            {
                id = 1,
                Codigo = "0001",
                Nombre = "Emperador",
                Cantidad = 1,
                Tipo = 1
                
            });
            _productoPush.Add(new Producto
            {
                id = 2,
                Codigo = "0002",
                Nombre = "Marias",
                Cantidad = 1,
                Tipo = 1
            });
            _productoPush.Add(new Producto
            {
                id = 3,
                Codigo = "0003",
                Nombre = "Doradas",
                Cantidad = 1,
                Tipo = 1
            });

            _productoNormal = new ObservableCollection<Producto>();
            _productoNormal.Add(new Producto
            {
                id = 4,
                Codigo = "0004",
                Nombre = "EmperadorN",
                Cantidad = 1,
                Tipo = 2
            });
            _productoNormal.Add(new Producto
            {
                id = 5,
                Codigo = "0005",
                Nombre = "MariasN",
                Cantidad = 1,
                Tipo = 2
            });
            _productoNormal.Add(new Producto
            {
                id = 6,
                Codigo = "0006",
                Nombre = "DoradasN",
                Cantidad = 1,
                Tipo = 2
            });
        }
        #endregion
    }
}
