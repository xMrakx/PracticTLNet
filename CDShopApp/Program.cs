using CDShopApp.Models;
using CDShopApp.Repositories;

const string connectionString = @"Data Source=DESKTOP-5JTDQEF;Initial Catalog=CDShop;Pooling=true;Integrated Security=SSPI;TrustServerCertificate=True";

ICDRepository cDRepository = new RawSqlCDRepository(connectionString);
IWorkerRepository workerRepository = new RawSqlWorkerRepository(connectionString);
IPurchaseRepository purchaseRepository = new RawSqlPurchaseRepository(connectionString);
CD cd;
Worker worker;
Purchase purchase;
int i;

PrintCommands();

while (true)
{
    Console.WriteLine("Введите команду:");
    string command = Console.ReadLine();

    switch (command)
    {
        case "help":
            PrintCommands();
            break;

        case "get-cds":
            IReadOnlyList<CD> cDs = cDRepository.GetAll();
            if (cDs.Count == 0)
            {
                Console.WriteLine("Диски не найдены");
                break;
            }
            Console.WriteLine();
            Console.WriteLine("Результат:");
            WriteCDList(cDs);
            break;

        case "get-cds-by":
            IReadOnlyList<CD> cDsByAtribute = GetCDByAtribute();
            if (cDsByAtribute.Count == 0)
            {
                Console.WriteLine("Диски по заданному атрибуту не найдены");
                break;
            }
            Console.WriteLine();
            Console.WriteLine("Результат:");
            WriteCDList(cDsByAtribute);
            break;

        case "get-workers":
            IReadOnlyList<Worker> workers = workerRepository.GetAll();
            if (workers.Count == 0)
            {
                Console.WriteLine("Работники не найдены не найдены");
                break;
            }
            Console.WriteLine();
            Console.WriteLine("Результат:");
            WriteWorkerList(workers);
            break;

        case "get-workers-by":
            IReadOnlyList<Worker> workersByAtribute = GetWorkersByAtribute();
            Console.WriteLine();
            Console.WriteLine("Результат:");
            WriteWorkerList(workersByAtribute);
            break;

        case "get-purchases":
            IReadOnlyList<Purchase> purchases = purchaseRepository.GetAll();
            if (purchases.Count == 0)
            {
                Console.WriteLine("Покупки не найдены");
                break;
            }
            Console.WriteLine();
            Console.WriteLine("Результат:");
            WritePurchaselist(purchases);
            break;

        case "get-purchases-by":
            IReadOnlyList<Purchase> purchasesByAtribute = GetPurchaseByAtribute();
            if (purchasesByAtribute.Count == 0)
            {
                Console.WriteLine("Покупки не найдены");
                break;
            }
            Console.WriteLine();
            Console.WriteLine("Результат:");
            WritePurchaselist(purchasesByAtribute);
            break;

        case "update-cd":
            Console.WriteLine("Введите Id диска");
            cd = null;
            while (true)
            {
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Неверно введен Id");
                    continue;
                }
                break;
            }

            cd = cDRepository.GetById(i);
            if (cd == null)
            {
                Console.WriteLine("Диск с данным id не найден");
                break;
            }

            Console.WriteLine("Введите новую цену");
            while (true)
            {
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Неверно введена цена");
                    continue;
                }
                break;
            }
            cd.UpdatePrice(i);
            cDRepository.Update(cd);
            Console.WriteLine("Цена оновлена");
            break;

        case "update-worker":
            Console.WriteLine("Введите Id работника");
            worker = null;
            while (true)
            {
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Неверно введен Id");
                    continue;
                }
                break;
            }

            worker = workerRepository.GetById(i);
            if (worker == null)
            {
                Console.WriteLine("Работник с данным id не найден");
                break;
            }

            Console.WriteLine("Введите новое имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите новую фамилию");
            string surname = Console.ReadLine();
            string phoneNumber;

            while (true)
            {
                Console.WriteLine("Введите новый номер телефона");
                phoneNumber = Console.ReadLine();
                if (phoneNumber[0] != '+' || phoneNumber.Length != 12)
                {
                    Console.WriteLine("Неверно введен номер телефона");
                    continue;
                }
                break;
            }
            
            worker.UpdateAll(name, surname, phoneNumber);
            workerRepository.Update(worker);
            Console.WriteLine("Работник обновлен");
            break;

        case "delete-cd":
            Console.WriteLine("Введите Id диска");
            cd = null;
            while (true)
            {
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Неверно введен Id");
                    continue;
                }
                break;
            }

            cd = cDRepository.GetById(i);
            if (cd == null)
            {
                Console.WriteLine("Диск с данным id не найден");
                break;
            }

            cDRepository.Delete(cd);
            Console.WriteLine("Диск удален");
            break;

        case "delete-worker":
            Console.WriteLine("Введите Id работника");
            worker = null;
            while (true)
            {
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Неверно введен Id");
                    continue;
                }
                break;
            }

            worker = workerRepository.GetById(i);
            if (worker == null)
            {
                Console.WriteLine("Работник с данным id не найден");
                break;
            }
            workerRepository.Delete(worker);
            Console.WriteLine("Работник удален");
            break;

        case "delete-purchase":
            Console.WriteLine("Введите Id покупки");
            purchase = null;
            while (true)
            {
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Неверно введен Id");
                    continue;
                }
                break;
            }

            purchase = purchaseRepository.GetById(i);
            if (purchase == null)
            {
                Console.WriteLine("Покупка с данным id не найдена");
                break;
            }
            purchaseRepository.Delete(purchase);
            Console.WriteLine("Покупка удалена");
            break;

        case "count-cd-purchases":
            ICDPurchaseCountRequest request = new CDPurchaseCountRequest(connectionString);
            IReadOnlyList<CDPurchaseCount> reqs = request.GetAll();
            if (reqs.Count() == 0)
            {
                Console.WriteLine("Продажи не найдены");
                break;
            }
            foreach(CDPurchaseCount p in reqs )
            {
                Console.WriteLine($"{p.Name} - количество продаж: {p.Count}");
            }
            break;

        case "exit":
            return 0;

        default:
            Console.WriteLine("Неверная команда");
            break;
    }
}


void PrintCommands()
{
    Console.WriteLine("Доступные команды:");
    Console.WriteLine("help - Вывести список доступных команд");
    Console.WriteLine("get-cds - Получить список всех дисков");
    Console.WriteLine("get-cds-by - получить диск(и) по доступным атрибутам (id, name, artist, release_date, price)");
    Console.WriteLine("get-workers - Получить список всех работников");
    Console.WriteLine("get-workers-by - Получить работника(ов) по доступным атрибутам (id, name, surname, birthday, phone_number)");
    Console.WriteLine("get-purchases - Получить список всех покупок");
    Console.WriteLine("get-purchases-by - Получить покупку(и) по доступным атрибутам (id, date)");
    Console.WriteLine("update-cd - Обновить цену диска");
    Console.WriteLine("update-worker - Обновить следующие атрибуты работника (name, surname, phone_number)");
    Console.WriteLine("delete-cd - Удалить диска по id");
    Console.WriteLine("delete-worker - Удалить работника по id");
    Console.WriteLine("delete-purchase - Удалить покупки по id");
    Console.WriteLine("count-cd-purchases - Выводит количество продаж дисков");
    Console.WriteLine("exit - Выход");
    Console.WriteLine();
}

void WriteCDList(IReadOnlyList<CD> cDs)
{
    foreach (CD c in cDs)
    {
        Console.WriteLine($"Id: {c.Id}");
        Console.WriteLine($"Name: {c.Name}");
        Console.WriteLine($"Artist: {c.Artist}");
        Console.WriteLine($"Release date: {c.ReleaseDate}");
        Console.WriteLine($"Price: {c.Price}");
        Console.WriteLine();
    }
}

void WriteWorkerList(IReadOnlyList<Worker> workers)
{
    foreach (Worker w in workers)
    {
        Console.WriteLine($"Id: {w.Id}");
        Console.WriteLine($"Name: {w.Name}");
        Console.WriteLine($"Surname: {w.Surname}");
        Console.WriteLine($"Birthday: {w.Birthday}");
        Console.WriteLine($"Phone number: {w.PhoneNumber}");
        Console.WriteLine();
    }
}

void WritePurchaselist(IReadOnlyList<Purchase> purchases)
{
    foreach (Purchase p in purchases)
    {
        Console.WriteLine($"Id: {p.Id}");
        Console.WriteLine($"Id CD: {p.IdCD}");
        Console.WriteLine($"Id worker: {p.IdWorker}");
        Console.WriteLine($"Date: {p.Date}");
        Console.WriteLine();
    }
}

IReadOnlyList<CD> GetCDByAtribute()
{
    List<CD> cDs = new List<CD>();
    int i;
    while(true)
    { 
        Console.WriteLine("Введите атрибут:");
        string atribute = Console.ReadLine();
        
        switch (atribute)
        {
            case "id":
                Console.WriteLine("Введите id:");
                atribute = Console.ReadLine();
                try
                {
                    i = Convert.ToInt32(atribute);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return cDs;
                }

                cDs.Add(cDRepository.GetById(i));
                return cDs;

            case "name":
                Console.WriteLine("Введите name:");
                atribute = Console.ReadLine();
                
                cDs.Add(cDRepository.GetByName(atribute));
                return cDs;

            case "artist":
                Console.WriteLine("Введите artist:");
                atribute = Console.ReadLine();
                
                return cDRepository.GetByArtist(atribute);

            case "release_date":
                Console.WriteLine("Введите release_date:");
                atribute = Console.ReadLine();

                return cDRepository.GetByArtist(atribute);

            case "price":
                Console.WriteLine("Введите price:");
                atribute = Console.ReadLine();
                try
                {
                    i = Convert.ToInt32(atribute);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                } 

                return cDRepository.GetByPrice(i);

            default:
                Console.WriteLine("Неверный атрибут");
                break;
        }
    }
}

IReadOnlyList<Worker> GetWorkersByAtribute()
{
    List<Worker> workers = new List<Worker>();

    while (true)
    {
        Console.WriteLine("Введите атрибут:");
        string atribute = Console.ReadLine();

        switch (atribute)
        {
            case "id":
                Console.WriteLine("Введите id:");
                atribute = Console.ReadLine();
                int i;
                try
                {
                    i = Convert.ToInt32(atribute);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }

                workers.Add(workerRepository.GetById(i));
                return workers;

            case "name":
                Console.WriteLine("Введите name:");
                atribute = Console.ReadLine();

                return workerRepository.GetByName(atribute);

            case "surname":
                Console.WriteLine("Введите surname:");
                atribute = Console.ReadLine();

                return workerRepository.GetBySurname(atribute);

            case "birthday":
                Console.WriteLine("Введите birthday");
                atribute= Console.ReadLine();
                return workerRepository.GetByBirthday(atribute);

            case "phone_number":
                Console.WriteLine("Введите phone number");
                atribute = Console.ReadLine();

                workers.Add(workerRepository.GetByPhoneNumber(atribute));
                return workers;

            default:
                Console.WriteLine("Неверный атрибут");
                break;
        }
    }
}

IReadOnlyList<Purchase> GetPurchaseByAtribute()
{
    List<Purchase> purchases = new List<Purchase>();

    while (true)
    {
        Console.WriteLine("Введите атрибут:");
        string atribute = Console.ReadLine();

        switch (atribute)
        {
            case "id":
                Console.WriteLine("Введите id:");
                atribute = Console.ReadLine();
                int i;
                try
                {
                    i = Convert.ToInt32(atribute);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
                purchases.Add(purchaseRepository.GetById(i));
                return purchases;

            case "date":
                Console.WriteLine("Введите date:");
                atribute = Console.ReadLine();

                return purchaseRepository.GetByDate(atribute);

            default:
                Console.WriteLine("Неверный атрибут");
                break;
        }
    }
}