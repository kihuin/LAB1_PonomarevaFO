using Serilog;

string template = "{Timestamp:HH:mm:ss} | [{Level:u3}] | {Message:lj}{NewLine}{Exeption}";
Log.Logger = (ILogger)new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console(outputTemplate: template).WriteTo.File("file_.txt", outputTemplate: template).CreateLogger();
Log.Verbose("Логгер сконфигурирован");
Log.Information("Приложение запущено");

Console.WriteLine("Введите длину A:");
string sideA = Console.ReadLine();
Console.WriteLine("Введите длину B:");
string sideB = Console.ReadLine();
Console.WriteLine("Введите длину C:");
string sideC = Console.ReadLine();

CalculateTriangleTypeAndCoordinates(sideA, sideB, sideC);


 void  CalculateTriangleTypeAndCoordinates(string sideA, string sideB, string sideC)
    {
        float a, b, c;
        if (float.TryParse(sideA, out a) && float.TryParse(sideB, out b) && float.TryParse(sideC, out c))
        {
        
            if (a + b > c && a + c > b && b + c > a)
            {
            Log.Information($" Проверка неравенства треугольника a + b > c && a + c > b && b + c > a # {a+b>c} {a + c > b} {b + c > a}");

                float scaleFactor = 100f / Math.Max(Math.Max(a, b), c);
                int Ax = (int)(a * scaleFactor);
                int Ay = 0;
                int Bx = (int)(b * scaleFactor * Math.Cos(Math.Acos((c * c - b * b - a * a) / (-2 * a * b))));
                int By = (int)(b * scaleFactor * Math.Sin(Math.Asin(Math.Sqrt(1 - Math.Pow((c * c - b * b - a * a) / (-2 * a * b), 2)))));
                int Cx = 0;
                int Cy = (int)(c * scaleFactor);

            Log.Debug($" Вычисление координат точки А по x. Умножение {a} на {scaleFactor}, {a}, {scaleFactor}");
            Log.Debug($" Вычисление координат точки А по y. Умножение {a} на {scaleFactor}, {a}, {scaleFactor}");
            Log.Debug($" Вычисление координат точки B по x. Умножение {b} на {scaleFactor * Math.Sin(Math.Asin(Math.Sqrt(1 - Math.Pow((c * c - b * b - a * a) / (-2 * a * b), 2))))}, {b}, {scaleFactor * Math.Sin(Math.Asin(Math.Sqrt(1 - Math.Pow((c * c - b * b - a * a) / (-2 * a * b), 2))))}");
            Log.Debug($" Вычисление координат точки B по y. Умножение {b} на {scaleFactor * Math.Sin(Math.Asin(Math.Sqrt(1 - Math.Pow((c * c - b * b - a * a) / (-2 * a * b), 2))))}, {b}, {scaleFactor * Math.Sin(Math.Asin(Math.Sqrt(1 - Math.Pow((c * c - b * b - a * a) / (-2 * a * b), 2))))}");
            Log.Debug($" Вычисление координат точки C по x. Умножение {c} на {scaleFactor}, {c}, {scaleFactor}");
            Log.Debug($" Вычисление координат точки C по y. Умножение {c} на {scaleFactor}, {c}, {scaleFactor}");

            Console.WriteLine("Координата A:"+" "+ Ax + "," +Ay );
            Log.Information($" Значение координат точки A равно # {Ax},{Ay}");
            Console.WriteLine("Координата B:" + " " + Bx + "," +By );
            Log.Information($" Значение координат точки B равно # {Bx},{By}");
            Console.WriteLine("Координата C:" + " " + Cx + "," +Cy );
            Log.Information($" Значение координат точки C равно # {Cx},{Cy}");


            if (a == b && b == c) {
                Log.Information("Проверка на тип треугольника");
                Log.Debug($"Сравнение сторон a == b && b == c {a == b && b == c} ");
                Console.WriteLine ("Тип треугольника: равносторонний");
                Log.Information("Тип треугольника равносторонний");

            }
                
                else if (a == b || a == c || b == c) {
                Log.Information("Проверка на тип треугольника");
                Log.Debug($"Сравнение сторон a == b || a == c || b == c {a == b || a == c || b == c} ");
                Console.WriteLine ("Тип треугольника: равнобедренный");
                Log.Information("Тип треугольника равнобедренный");
            }

            else {
                Log.Information("Проверка на тип треугольника");
                Console.WriteLine ("Тип треугольника: разносторонний");
                Log.Information("Тип треугольника равзносторонний");

            }
                    

                
            }
            else
            {
            Log.Error("Ошибка вычисления треугольника");
            Log.Error("Введены числовые данные, которые не соответсвуют неравенству");
            Console.WriteLine("Координата A: -1, -1" );
            Log.Error("Ошибка вычисления координат точки A");
            Console.WriteLine("Координата B: -1, -1");
            Log.Error("Ошибка вычисления координат точки B");
            Console.WriteLine("Координата C: -1, -1");
            Log.Error("Ошибка вычисления координат точки C");

            Console.WriteLine ("Тип треугольника: не треугольник");
            Log.Error("Ошибка вычисления типа треугольника");
        }
        }
        else
        {
        Log.Error("Ошибка вычисления треугольника");
        Log.Error("Введены невалидные(нечисловые) данные");
        Console.WriteLine ("");
        Console.WriteLine("Координата A: -2, -2");
        Log.Error("Ошибка вычисления координат точки A");
        Console.WriteLine("Координата B: -2, -2");
        Log.Error("Ошибка вычисления координат точки B");
        Console.WriteLine("Координата C: -2, -2");
        Log.Error("Ошибка вычисления координат точки C");
    }
    }

