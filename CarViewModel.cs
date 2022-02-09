using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Windows;
using System.Linq;

namespace MVVMp
{
    public class CarViewModel : INotifyPropertyChanged
    {
        private Car _selectedCar;
        public ObservableCollection<Car> Cars { get; set; }
        public Car SelectedCar
        {
            get { return _selectedCar; }
            set
            {
                _selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }
        public CarViewModel()
        {
            Cars = new ObservableCollection<Car>
            {
             new Car { Model="vASS-2105", MaxSpeed=150, Price=56000, Discount = 0, Category = "Грузовик" },
             new Car { Model="LADA Priora", MaxSpeed=170, Price=560000, Discount = 50, Category = "SportCar" },
             new Car { Model="cumASS", MaxSpeed=100, Price=5600000, Discount = 75, Category = "Грузовик" },
             new Car { Model="БУГАТЕ ВИРОН", MaxSpeed=666, Price = 1000000000, Discount = 20, Category = "SportCar"}
            };
        }
        public void AddCar()
        {
            Car car = new Car();
            car.MaxSpeed = 0;
            car.Model = "Введите значение";
            car.Price = 0;
            car.Discount = 0;
            car.Category = "Введите значение";
            Cars.Insert(0, car);
            SelectedCar = car;
        }
        public void DeleteCar()
        {
            if (_selectedCar != null)
            {
                Cars.Remove(SelectedCar);
            }
        }
        public void SaveList()
        {
            var options = new JsonSerializerOptions
            {
                // убераем escape-символы
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                // делаем форматированный вывод
                WriteIndented = true
            };
            string save = JsonSerializer.Serialize(Cars, options);
            if (File.Exists("FileSaver.Json"))
            {
                File.WriteAllText("FileSaver.json", save);
                MessageBox.Show("Информация успешно записана в файл!");
            }
            else { MessageBox.Show("Файла с таким путем нет!"); }
        }
        public void RClick(string tb, int tb2)
        {
            Cars.Where(p => p.Category == tb).ToList().ForEach(p => p.Discount = tb2);
            OnPropertyChanged("Category");
        }
        public void HChanging(bool? cb, string tb, int tb2)
        {
            if (cb.Value == true)
            {
                Cars.Where(p => p.Category == tb).ToList().ForEach(p => p.Discount = tb2);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
