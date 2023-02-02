using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoStorage.Data
{
    /**
     * Абстрактный класс груз 
     * <E> - тип величины измерения  
     */
    public abstract class ACargo
    {
        // наименование груза
        private string name = string.Empty;
        // дата приемки на хранение
        private DateTime start;
        // окончание срока хранения
        private DateTime? end = null;
        // стоимость хранения за сутки
        private double price = 0;
        // единица измерения груза
        private double count;
        // наименование ед. изм.
        private string unitName;

        public string Name { get { return name; } set { name = value; } }
        public DateTime Start { get => start; set => start = value; }
        public DateTime? End { 
            get => end;
            set { 
                if (value != null)
                {
                    if(value >= start)    // старт хранения не может быть больше окончания
                    {
                        end = value;
                    }
                }
            }
        }

        public double Price { 
            get { return price;  }
            set { 
                if (value >=0) {        // цена не может быть отрицательной
                    price = value;
                }
            }
        }

        public double Count { get => count; set => count = value; }

        public double Cost
        {
            get
            {
                if (end != null) {
                    return (double)((DateTime)end - start).TotalDays * price;
                }
                return 0;
            }
        }

        public string UnitName { get => unitName; set => unitName = value; }

        public override string? ToString()
        {
            StringBuilder builder = new StringBuilder("[")
             .Append(Name)
             .Append(", ")
             .Append(Start.ToString("dd.MM.yyyy"))
             .Append(" - ");

            if (End == null)
            {
                builder.Append("*");
            }
            else
            {
                builder.Append(((DateTime)End).ToString("dd.MM.yyyy"));
            }


            builder.Append(", ")
                .Append(Cost.ToString())
                .Append(", ")
                .Append(count.ToString())
                .Append(" ").Append(unitName)
                .Append("]");

            return builder.ToString();

        }
    }
}
