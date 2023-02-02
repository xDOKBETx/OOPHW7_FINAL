using CargoStorage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoStorage.Services
{
    public class CargoService: ICargoService
    {
        private static int cargo_id = 0;

        private String[] names = new String[]
        {
            "Мазут",
            "Кирпич",
            "Пиломатериал",
            "Керосин",
            "Нефть",
            "Бензин"
        };


        private String[] units = new string[]
        {
            "тонна",
            "метр куб."
        };

        public Cargo GenerateCargo()
        {
            Random random = new Random();

            Cargo cargo = new Cargo(
                ++cargo_id, 
                names[random.Next(names.Length)],
                DateTime.Now.AddDays(-random.Next(30)),
                random.NextDouble()*20,
                random.NextDouble()*10,
                units[random.Next(units.Length)]
            );

            return cargo;
        }
    }
}
