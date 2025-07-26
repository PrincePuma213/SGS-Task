using TestWpfApp.Models;

namespace TestWpfApp.Data
{
    public class MoqRepo: IDataProvider
    {
        public List<City> GetCities()
        {
            return _cities;
        }

        public List<Workshop> GetWorkshopsByCity(int cityId)
        {
            return _workshops.Where(w => w.CityId == cityId).ToList();
        }

        public List<Employee> GetEmployeesByWorkshop(int workshopId)
        {
            return _employees.Where(e => e.WorkshopId == workshopId).ToList();
        }

        public List<Brigade> GetBrigades()
        {
            return _brigades;
        }

    
        private List<City> _cities = new List<City>
        {
            new City { Id = 1, Name = "Москва" },
            new City { Id = 2, Name = "Санкт-Петербург" },
            new City { Id = 3, Name = "Екатеринбург" }
        };

        private List<Workshop> _workshops = new List<Workshop>
        {
            new Workshop { Id = 1, Name = "Цех 1", CityId = 1 },
            new Workshop { Id = 2, Name = "Цех 2", CityId = 1 },
            new Workshop { Id = 3, Name = "Цех 3", CityId = 1 },
            new Workshop { Id = 4, Name = "Цех 4", CityId = 2 },
            new Workshop { Id = 5, Name = "Цех 5", CityId = 2 },
            new Workshop { Id = 6, Name = "Цех 6", CityId = 2 },
            new Workshop { Id = 7, Name = "Цех 7", CityId = 3 },
            new Workshop { Id = 8, Name = "Цех 8", CityId = 3 },
            new Workshop { Id = 9, Name = "Цех 9", CityId = 3 }
        };

        private List<Brigade> _brigades = new List<Brigade>
        {
            new Brigade { Id = 1, Name = "Бригада А" },
            new Brigade { Id = 2, Name = "Бригада Б" },
            new Brigade { Id = 3, Name = "Бригада В" },
            new Brigade { Id = 4, Name = "Бригада Г" },
            new Brigade { Id = 5, Name = "Бригада Д" },
            new Brigade { Id = 6, Name = "Бригада Е" },
            new Brigade { Id = 7, Name = "Бригада Ж" },
            new Brigade { Id = 8, Name = "Бригада З" },
            new Brigade { Id = 9, Name = "Бригада И" },
        };

        private List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, FullName = "Иванов И.И.", WorkshopId = 1},
            new Employee { Id = 2, FullName = "Петров П.П.", WorkshopId = 1},
            new Employee { Id = 3, FullName = "Сидоров С.С.", WorkshopId = 1},
            new Employee { Id = 4, FullName = "Кузнецов К.К.", WorkshopId = 1},

            new Employee { Id = 5, FullName = "Попов А.А.", WorkshopId = 2},
            new Employee { Id = 6, FullName = "Смирнов В.В.", WorkshopId = 2},
            new Employee { Id = 7, FullName = "Орлов О.О.", WorkshopId = 2},
            new Employee { Id = 8, FullName = "Васильев В.В.", WorkshopId = 2},

            new Employee { Id = 9, FullName = "Морозов М.М.", WorkshopId = 3},
            new Employee { Id = 10, FullName = "Григорьев Г.Г.", WorkshopId = 3},
            new Employee { Id = 11, FullName = "Федоров Ф.Ф.", WorkshopId = 3},
            new Employee { Id = 12, FullName = "Алексеев А.А.", WorkshopId = 3},

            new Employee { Id = 13, FullName = "Егоров Е.Е.", WorkshopId = 4},
            new Employee { Id = 14, FullName = "Титов Т.Т.", WorkshopId = 4},
            new Employee { Id = 15, FullName = "Захаров З.З.", WorkshopId = 4},
            new Employee { Id = 16, FullName = "Белов Б.Б.", WorkshopId = 4},

            new Employee { Id = 17, FullName = "Комаров К.К.", WorkshopId = 5},
            new Employee { Id = 18, FullName = "Медведев М.М.", WorkshopId = 5},
            new Employee { Id = 19, FullName = "Денисов Д.Д.", WorkshopId = 5},
            new Employee { Id = 20, FullName = "Гусев Г.Г.", WorkshopId = 5},

            new Employee { Id = 21, FullName = "Киселев К.К.", WorkshopId = 6},
            new Employee { Id = 22, FullName = "Макаров М.М.", WorkshopId = 6},
            new Employee { Id = 23, FullName = "Сорокин С.С.", WorkshopId = 6},
            new Employee { Id = 24, FullName = "Тарасов Т.Т.", WorkshopId = 6},

            new Employee { Id = 25, FullName = "Баранов Б.Б.", WorkshopId = 7},
            new Employee { Id = 26, FullName = "Щукин Щ.Щ.", WorkshopId = 7},
            new Employee { Id = 27, FullName = "Никитин Н.Н.", WorkshopId = 7},
            new Employee { Id = 28, FullName = "Шестаков Ш.Ш.", WorkshopId = 7},

            new Employee { Id = 29, FullName = "Фролов Ф.Ф.", WorkshopId = 8},
            new Employee { Id = 30, FullName = "Савельев С.С.", WorkshopId = 8},
            new Employee { Id = 31, FullName = "Чернов Ч.Ч.", WorkshopId = 8},
            new Employee { Id = 32, FullName = "Абрамов А.А.", WorkshopId = 8},

            new Employee { Id = 33, FullName = "Воробьев В.В.", WorkshopId = 9},
            new Employee { Id = 34, FullName = "Голубев Г.Г.", WorkshopId = 9},
            new Employee { Id = 35, FullName = "Селезнев С.С.", WorkshopId = 9},
            new Employee { Id = 36, FullName = "Давыдов Д.Д.", WorkshopId = 9}
        };        
    }
}
