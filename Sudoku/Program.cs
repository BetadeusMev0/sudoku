int s = 0;
int x = Convert.ToInt32(Console.ReadLine());
int y = Convert.ToInt32(Console.ReadLine());

if (x == y) s = find_number_of_path(x, y);
else s = GG(x, y);

Console.WriteLine("\n" + s);




int G(int size_i, int size_j)
{
    int result = 0;
    result = fact(size_j);
    int res = fact(size_i);
    res *= fact(size_j - size_i);
    result = result / res;

    return result;
}

int GG(int size_i, int size_j)
{
    int j = 0;
    int tmp = size_j;
    for (int i = 2; i < size_i; i++, j++) ;
    tmp = size_j + j;
    return G(size_i - 1, tmp);
}

int fact(int num)
{
    int result = 1;
    for (int i = 1; i <= num; i++)
    {
        result *= i;
    }
    return result;
}

int find_number_of_path(int x, int y)
{
    int result = 0;
    int tmp = y;
    int i = 1;
    for (int j = 3; j < tmp; j++) if (j + 1 == tmp) y += j - 1; ;
    tmp = 0;
    try
    {
        while (true)
        {
            i++;
            tmp = G(i, y);
            if (tmp > result) result = tmp;
            else break;
        }
    }
    catch
    {
        return result;
    }
    finally
    {

    }
    return result;
}