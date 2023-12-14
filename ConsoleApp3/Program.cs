const int I = 9;
int[] height = new int[I] {1,8,6,2,5,4,8,3,7};

int V = 0;
int x1 = 0;
int x2 = height.Length - 1;
int y = 0;
for (int i = 0; i < height.Length / 2; i++)
{
    if (height[x1] >= height[x2]) y = height[x2];
    else y = height[x1];

    int x = (x2 - x1);

    if (V < x * y)
    {
        V = x * y;
        if (height[x2] > height[x1]) x1++;
        else x2--;
    }
}

Console.WriteLine(V);