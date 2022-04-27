int[] numbers = new[]
{
    0,
    1,
    2,
    3,
    4,
    5,
    6,
    7
};

foreach(var n in numbers)
{
    Console.Write(n + " ");
    Console.WriteLine(n % 4);
}

// 1, 1 = 1,1
// 1, 2 = 1,2
// 1, 3 = 1,0
// 2, 1 = 2, 1
// 3, 1 = 0, 1