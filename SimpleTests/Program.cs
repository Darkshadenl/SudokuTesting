int[] numbers = new[]
{
    1,
    2,
    3,
    4,
    5,
    6,
    7,
    8,
    9
};

foreach(var n in numbers)
{
    Console.WriteLine(n % 3);
}

// 1, 1 = 1,1
// 1, 2 = 1,2
// 1, 3 = 1,0
// 2, 1 = 2, 1
// 3, 1 = 0, 1