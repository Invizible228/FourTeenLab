using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMp
{
    public class Car : INotifyPropertyChanged
    {
        private string _model;
        private int _maxSpeed;
        private decimal _price;
        private string _category;
        private decimal _Discount { get; set; }
        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }
        public int MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
            set
            {
                _maxSpeed = value;
                OnPropertyChanged("MaxSpeed");
            }
        }
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged("Category");
            }
        }
        public decimal Discount
        {
            get { return _Discount; }
            set
            {
                _Discount = value;
                OnPropertyChanged("Discount");
                OnPropertyChanged("DiscountPrice");
                OnPropertyChanged("HasDiscount");
            }
        }
        public bool HasDiscount
        {
            get { return Discount > 0;  }
        }
        public int DiscountPrice
        {
            get
            {
                return Convert.ToInt32(Price * (1 - (Discount/100)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
