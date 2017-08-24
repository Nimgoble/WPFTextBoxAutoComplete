using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace TestApp.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ShellViewModel()
        {
            TestItems = new ObservableCollection<string>()
            {
                "Apple",
                "Banana",
                "Carrot",
                "Dog",
                "Elderberry",
                "Fruit",
                "Grapes",
                "Honey",
                "Iron"
            };

            //TestItems2 = new ObservableCollection<string>()
            //{
            //    "Apple2",
            //    "Banana2",
            //    "Carrot2",
            //    "Dog2",
            //    "Elderberry2",
            //    "Fruit2",
            //    "Grapes2",
            //    "Honey2",
            //    "Iron2"
            //};
        }
        public ObservableCollection<string> TestItems { get; set; }
        //public ObservableCollection<string> TestItems2 { get; set; }
    }
}