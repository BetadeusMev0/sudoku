
bool check_err(int[,] arr, int x, int y, int c) 
{
    bool result = false;
    int chk = c;
    int pos_x = (x) / 3;
    int pos_y = (y) / 3;
    for (int i = 0; i < 18; i++) 
    {
        if (i < 9)
        {
            if (chk == arr[x, i]) result = true;
        }
        else if (chk == arr[i - 9, y]) result = true; 
}
 
    for (int i = pos_y * 3; i < (pos_y + 1) * 3; i++)
    {
        for (int j = pos_x * 3; j < (pos_x + 1) * 3; j++)
        {
            if (chk == arr[j, i]) { result = true; }
        }
    }


    return result;
}


void output(int[,] arr) 
{
    for (int i = 0; i < 9; i++)
    {
        if (i % 3 == 0 && i != 0) Console.Write("-----------\n");
            for (int j = 0; j < 9; j++)
        {
            if ((j ) % 3 == 0 && j != 0) Console.Write("|");
            if (arr[i, j] != 0) Console.Write(arr[i, j]);
            else Console.Write(".");
        }
        Console.WriteLine();
    }
}

void rand_pull(int[,] arr) 
{
    Random rnd = new Random();
    int tmp = rnd.Next(0,16);
    for (int i = 0; i < 9; i++) 
    {
        for (int j = 0; j < 9; j++) 
        {
            tmp = rnd.Next(0,12);
            if(tmp>0 && tmp < 9 && !check_err(arr, i, j, tmp)) arr[i,j] = tmp;
        }
    }
}

int[] tr(string str) 
{
    int[] arr = new int[3];
    int j = 0;
    string tmp = "";
    str += ' ';
    for (int i = 0; i < str.Length; i++) 
    {
        if (str[i] != ' ') tmp += str[i];
        else { if (tmp != "") {
                try
                {
                    arr[j++] = Convert.ToInt32(tmp); tmp = "";
                }
                catch 
                {
                  
                }
                } }
    }

    return arr;
}

bool check_win(int[,] arr) 
{
    bool result = true;
    for (int i = 0; i < 9; i++)
        for (int j = 0; j < 9; j++) 
        {
            if (arr[i,j] == 0) result= false;
        }
    return result;
}

bool step(int[,] arr, string str) 
{
    int[] r = tr(str);
    int x = r[0]-1, y = r[1]-1, count = r[2];
    if ((x >= 0 && y >= 0)&& arr[x, y] == 0 && !check_err(arr, x, y, count)) arr[x, y] = count;
    else return false;
    return true;
}



void game() 
{
    int[,] arr = new int[9, 9];
    rand_pull(arr);
    string str;
    string tmp = "";
    bool gm = true;
    while (gm)
    {
        Console.Clear();
        Console.WriteLine("ИГРАЕМ В СУДОКУ :)");
        output(arr);
        Console.WriteLine("Введите ячейку в формате y x и значение:");
        if(tmp != "")Console.WriteLine(tmp);
        str = Console.ReadLine();
        if (!step(arr, str)) tmp = "Неудачный ход";
        else tmp = "";
        gm = !check_win(arr);
    }
    Console.WriteLine("Поздравляю с победой!");
}


game();