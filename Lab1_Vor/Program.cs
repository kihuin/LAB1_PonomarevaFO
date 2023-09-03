// See https://aka.ms/new-console-template for more information
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
               
                float scaleFactor = 100f / Math.Max(Math.Max(a, b), c);
                int Ax = (int)(a * scaleFactor);
                int Ay = 0;
                int Bx = (int)(b * scaleFactor * Math.Cos(Math.Acos((c * c - b * b - a * a) / (-2 * a * b))));
                int By = (int)(b * scaleFactor * Math.Sin(Math.Asin(Math.Sqrt(1 - Math.Pow((c * c - b * b - a * a) / (-2 * a * b), 2)))));
                int Cx = 0;
                int Cy = (int)(c * scaleFactor);
                Console.WriteLine("Координата A:"+" "+ Ax + "," +Ay );
                Console.WriteLine("Координата B:" + " " + Bx + "," +By );
                Console.WriteLine("Координата C:" + " " + Cx + "," +Cy );

               
                if (a == b && b == c)
                    Console.WriteLine ("Тип треугольника: равносторонний");
                else if (a == b || a == c || b == c)
                    Console.WriteLine ("Тип треугольника: равнобедренный");
                else
                    Console.WriteLine ("Тип треугольника: разносторонний");

                
            }
            else
            {
            Console.WriteLine("Координата A: -1, -1" );
            Console.WriteLine("Координата B: -1, -1");
            Console.WriteLine("Координата C: -1, -1");

            Console.WriteLine ("Тип треугольника: не треугольник");
            }
        }
        else
        {
           
        Console.WriteLine ("");
        Console.WriteLine("Координата A: -2, -2");
        Console.WriteLine("Координата B: -2, -2");
        Console.WriteLine("Координата C: -2, -2");
    }
    }

