class Auto
{
    private string nom; // номер авто
    private float bak; // количество бензина в баке
    private float ras; // расход топлива на 100 км
    private int mileage; // пробег

    public void info(string nom, float bak, float ras)
    {
        this.nom = nom;
        this.bak = bak;
        this.ras = ras;
    }

    public void outinf()
    {
        Console.WriteLine("Номер авто: " + nom);
        Console.WriteLine("Количество бензина в баке: " + bak);
        Console.WriteLine("Расход топлива на 100 км: " + ras);
        Console.WriteLine("Пробег: " + mileage);
    }

    public void zapravka(int amount)
    {
        bak += amount;
        Console.WriteLine("Автомобиль заправлен.");
    }

    public void move(int distance) //езда
    {
        float rashod = (ras / 100) * distance; // Необходимое кол-во топлива на 100 км

        if (rashod <= bak)
        {
            bak -= rashod;
            mileage += distance; // при каждой добавляем кол-во пройденой дистанции, для пробега
            Console.WriteLine("Машина проехала " + distance + " км."); // при каждой заправке отмечаем кол-во пройденой дистанции
        }
        else
        {
            Console.WriteLine("Недостаточно топлива для поездки.");
            Console.WriteLine("Желаете заправиться? (Да/Нет)");
            string answer = Console.ReadLine();

            if (answer == "Да")
            {
                Console.WriteLine("Введите количество топлива для заправки:");
                int amount = int.Parse(Console.ReadLine());
                zapravka(amount);
                move(distance);
            }
        }
    }

    private int dist(int x1, int y1, int x2, int y2) // считаем дистанцию
    {
        return (int)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    public int mileag(int x1, int y1, int x2, int y2) // считаем пробег
    {
        int distance = this.dist(x1, y1, x2, y2);
        mileage += distance;
        return mileage;
    }

    public void braking() // торможение
    {
        Console.WriteLine("Автомобиль тормозит.");
    }

    public void acceleration() // разгон
    {
        Console.WriteLine("Автомобиль разгоняется.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Auto car = new Auto();

        Console.WriteLine("Введите номер авто:");
        string nom = Console.ReadLine();

        Console.WriteLine("Введите количество бензина в баке:");
        float bak = float.Parse(Console.ReadLine());

        Console.WriteLine("Введите расход топлива на 100 км:");
        float ras = float.Parse(Console.ReadLine());

        car.info(nom, bak, ras);// внесение: номер, кол-во Бенз, Расход на сотню км

        Console.WriteLine("Введите количество бензина для заправки:");
        int refuelAmount = int.Parse(Console.ReadLine());
        car.zapravka(refuelAmount);
        car.acceleration();
        Random random = new Random(); // для получения случайного расстояния

        while (true) // получаем случайное расстояние
        {
            int distance = random.Next(1, 100);
            car.move(distance);

            Console.WriteLine("Продолжить поездку? (Да/Нет)");
            string answer = Console.ReadLine();

            if (answer == "Нет") // Прерывание езды если решим закончить поезку
                break;
        }
        car.braking(); // торможение
        Console.WriteLine("Весь пробег: " + car.mileag(0, 0, 100, 100)); // Общий пробег авто        
    }
}