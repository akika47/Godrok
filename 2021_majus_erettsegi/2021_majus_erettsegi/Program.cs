
List<int> melysegek = File.ReadAllLines("melyseg.txt").Select(int.Parse).ToList();

Console.WriteLine("1. feladat");
Console.WriteLine($"A fájl adatainak száma: {melysegek.Count}");

Console.WriteLine("2. feladat");
Console.Write("Adjon meg egy távolságértéket: ");
int hely = int.Parse(Console.ReadLine());
Console.WriteLine($"Ezen a helyen a felszín {melysegek[hely - 1]} méter mélyen van.");

Console.WriteLine("3. feladat");
int érintetlen = melysegek.Count(mért => mért == 0);
Console.WriteLine($"Az érintetlen terület aránya {100.0 * érintetlen / melysegek.Count:0.00}%.");

using (StreamWriter kimenet = new StreamWriter("godrok.txt"))
{
    int előző = 0;
    List<string> egysor = new List<string>();

    foreach (int érték in melysegek)
    {
        if (érték > 0)
        {
            egysor.Add(érték.ToString());
        }

        if (érték == 0 && előző > 0)
        {
            kimenet.WriteLine(string.Join(" ", egysor));
            egysor.Clear();
        }

        előző = érték;
    }
}

Console.WriteLine("5. feladat");
Console.WriteLine($"A gödrök száma: {File.ReadAllLines("godrok.txt").Length}");

Console.WriteLine("6. feladat");
if (melysegek[hely - 1] > 0)
{
    Console.WriteLine("a)");
    int poz = hely - 1;
    while (melysegek[poz] > 0)
    {
        poz--;
    }
    int kezdő = poz + 2;
    poz = hely;
    while (melysegek[poz] > 0)
    {
        poz++;
    }
    int záró = poz;
    Console.WriteLine($"A gödör kezdete: {kezdő} méter, a gödör vége: {záró} méter.");

    Console.WriteLine("b)");
    int mélypont = 0;
    poz = kezdő;
    while (melysegek[poz] >= melysegek[poz - 1] && poz <= záró)
    {
        poz++;
    }
    while (melysegek[poz] <= melysegek[poz - 1] && poz <= záró)
    {
        poz++;
    }
    if (poz > záró)
    {
        Console.WriteLine("Folyamatosan mélyül.");
    }
    else
    {
        Console.WriteLine("Nem mélyül folyamatosan.");
    }

    Console.WriteLine("c)");
    Console.WriteLine($"A legnagyobb mélysége {melysegek.GetRange(kezdő - 1, záró - kezdő + 1).Max()} méter.");

    Console.WriteLine("d)");
    double térfogat = 10 * melysegek.GetRange(kezdő - 1, záró - kezdő + 1).Sum();
    Console.WriteLine($"A térfogata {térfogat} m^3.");

    Console.WriteLine("e)");
    double biztonságos = térfogat - 10 * (záró - kezdő + 1);
    Console.WriteLine($"A vízmennyiség {biztonságos} m^3.");
}
else
{
    Console.WriteLine("Az adott helyen nincs gödör.");
}