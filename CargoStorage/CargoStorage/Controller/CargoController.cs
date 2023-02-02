using CargoStorage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoStorage.Controller
{
    internal class CargoController
    {
        List<String> menuList = new List<String>()
        {
            "1 - добавить груз",
            "2 - показать список",
            "3 - фильтровать список",
            "4 - отгрузить груз",
            "0 - выход"
        };

        UserView view = new UserView();
        CargoHouseService service = new CargoHouseService();

        public void Run()
        {
            int menu = view.ShowMenu(menuList);
            while(menu> 0)
            {
                switch (menu)
                {
                    case 1:
                        int count = view.GetIntValue("Кол-во грузов: ");
                        service.AddCargo(count);
                        break;

                    case 2:
                        view.PrintCargoList(service.GetCargoList());
                        break; 

                    case 3:
                        String name = view.GetStringValue("Название для поиска:");
                        view.PrintCargoList(service.GetCargoList(name));
                        break;
                    case 4:
                        int id = view.GetIntValue("код груза: ");
                        service.CargoShipment(id, DateTime.Now.Date);
                        break;
                }

                menu = view.ShowMenu(menuList);
            }

        }

    }
}
