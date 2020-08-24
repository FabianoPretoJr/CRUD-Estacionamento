using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Estacionamento.BLL
{
    public class Veiculo
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _placa;
        public string Placa
        {
            get { return _placa; }
            set { _placa = value; }
        }

        private string _fabricante;
        public string Fabricante
        {
            get { return _fabricante; }
            set { _fabricante = value; }
        }

        private string _modelo;

        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }
    }
}