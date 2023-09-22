using Serilog;

string template = "{Timestamp:yyyy-MM-dd HH:mm:ss} | [{Level:u3}] | {Message:lj}{NewLine}{Exeption}";
Log.Logger = (ILogger)new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console(outputTemplate: template).WriteTo.File("file_.txt", outputTemplate: template).CreateLogger();
Log.Verbose("Логгер сконфигурирован");
Log.Information("Приложение запущено");

CalculateTriangleTypeAndCoordinates("2", "2", "3,7");



(string, List<(int, int)>) CalculateTriangleTypeAndCoordinates(string sideA, string sideB, string sideC)
{
    float a, b, c;
    if (float.TryParse(sideA, out a) && float.TryParse(sideB, out b) && float.TryParse(sideC, out c))
    {

        if (a + b > c && a + c > b && b + c > a)
        {
            int Ax, Ay, Bx, By, Cx, Cy;

            CoordinatesTriangle(sideA, sideB, sideC, a, b, c, out Ax, out Ay, out Bx, out By, out Cx, out Cy);

            return ((string, List<(int, int)>))TypeTriangle(sideA, sideB, sideC, a, b, c, Ax, Ay, Bx, By, Cx, Cy);


        }
        else
        {

            Log.Error($"Ошибка проверки неравенства треугольника, стороны '{sideA}', '{sideB}', '{sideC}' и ошибка вычисления координат '{(-1, -1)}', '{(-1, -1)}', '{(-1, -1)}' ");
            return ("Тип треугольника: не треугольник", new List<(int, int)> { (-1, -1), (-1, -1), (-1, -1) });
        }
    }
    else
    {
        Log.Error($"Ошибка вычисления треугольника, стороны: '{sideA}', '{sideB}', '{sideC}' и ошибка вычисления координат {(-2, -2)},{(-2, -2)}, {(-2, -2)}");
        return ("", new List<(int, int)> { (-2, -2), (-2, -2), (-2, -2) });
    }

    static object TypeTriangle(string sideA, string sideB, string sideC, float a, float b, float c, int Ax, int Ay, int Bx, int By, int Cx, int Cy)
    {
        if (a == b && b == c)
        {

            Log.Debug($" Тип треугольника со сторонами {sideA}, {sideB}, {sideC}: равносторонний ");
            Log.Debug($"Координаты {Ax},{Ay}| {Bx},{By}| {Cx},{Cy}");
            return ("Тип треугольника: Равносторонний", new List<(int, int)> { (Ax, Ay), (Bx, By), (Cx, Cy) });



        }

        else if (a == b || a == c || b == c)
        {
            Log.Debug($"Тип треугольника со сторонами {sideA}, {sideB}, {sideC}: Равнобедренный");
            Log.Debug($"Координаты {Ax},{Ay}| {Bx},{By}| {Cx},{Cy}");

            return ("Тип треугольника: Равнобедренный", new List<(int, int)> { (Ax, Ay), (Bx, By), (Cx, Cy) });
        }

        else
        {
            Log.Information($"Тип треугольника со сторонами {sideA}, {sideB}, {sideC}: Разносторонний");
            Log.Debug($"Координаты {Ax},{Ay}| {Bx},{By}| {Cx},{Cy}");

            return ("Тип треугольника: Разносторонний", new List<(int, int)> { (Ax, Ay), (Bx, By), (Cx, Cy) });

        }
    }
}

static void CoordinatesTriangle(string sideA, string sideB, string sideC, float a, float b, float c, out int Ax, out int Ay, out int Bx, out int By, out int Cx, out int Cy)
{
    Log.Information($" Проверка неравенства треугольника. Точки {sideA}. {sideB}. {sideC}.  {a + b > c} {a + c > b} {b + c > a}");

    float scaleFactor = 100f / Math.Max(Math.Max(a, b), c);
    Ax = (int)(a * scaleFactor);
    Ay = 0;
    Bx = (int)(b * scaleFactor * Math.Cos(Math.Acos((c * c - b * b - a * a) / (-2 * a * b))));
    By = (int)(b * scaleFactor * Math.Sin(Math.Asin(Math.Sqrt(1 - Math.Pow((c * c - b * b - a * a) / (-2 * a * b), 2)))));
    Cx = 0;
    Cy = (int)(c * scaleFactor);
    int minX = Math.Min(Ax, Math.Min(Bx, Cx));
    int minY = Math.Min(Ay, Math.Min(By, Cy));
    if (minX < 0)
    {
        Ax += -minX;
        Bx += -minX;
        Cx += -minX;
    }
    if (minY < 0)
    {
        Ay += -minY;
        By += -minY;
        Cy += -minY;
    }
    int maxX = Math.Max(Ax, Math.Max(Bx, Cx));
    int maxY = Math.Max(Ay, Math.Max(By, Cy));
    if (maxX > 100)
    {
        Ax -= maxX - 100;
        Bx -= maxX - 100;
        Cx -= maxX - 100;
    }
    if (maxY > 100)
    {
        Ay -= maxY - 100;
        By -= maxY - 100;
        Cy -= maxY - 100;
    }


    Log.Information($" Вычисление координат точек {sideA}, {sideB},{sideC}");
}