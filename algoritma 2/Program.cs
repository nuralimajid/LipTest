class algoritma2
{
    static void Main(string[] args)
    {
        Console.Write("Input angka : ");
        int input = Convert.ToInt32(Console.ReadLine());

        // jawaban a

        Console.WriteLine("Jawaban A.");
        for (int i = 1; i <= input; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("");
        }
        Console.WriteLine("");

        //Jawaban B 
        Console.WriteLine("Jawaban B.");
        for (int i = 1; i <= input; i++)
        {
            for (int j = i; j >= 1; j--)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        //Jawaban C
        Console.WriteLine("Jawaban C");
        for (int i = 1; i <= input; i++)
        {
            Console.Write(i + " ");
            if (i > 1)
            {
                for (int j = 2; j <= i; j++)
                {
                    Console.Write((i + j - 1) + " ");
                }
            }
            Console.WriteLine();
        }

        for (int i = input - 1; i >= 1; i--)
        {
            Console.Write(i + " ");
            if (i > 1)
            {
                for (int j = 2; j <= i; j++)
                {
                    Console.Write((i + j - 1) + " ");
                }
            }
            Console.WriteLine();
        }

        Console.WriteLine("Jawaban D");
        int[,] matrix = new int[input, input];
        int value = 1;
        for (int layer = 0; layer < (input + 1) / 2; layer++)
        {
            for (int i = layer; i < input - layer; i++)
            {
                matrix[layer, i] = value++;
            }

            for (int i = layer + 1; i < input - layer; i++)
            {
                matrix[i, input - layer - 1] = value++;
            }
            for (int i = input - layer - 2; i >= layer; i--)
            {
                matrix[input - layer - 1, i] = value++;
            }
            for (int i = input - layer - 2; i > layer; i--)
            {
                matrix[i, layer] = value++;
            }
        }

        for (int i = 0; i < input; i++)
        {
            for (int j = 0; j < input; j++)
            {
                Console.Write(matrix[i, j] + "");
            }
            Console.WriteLine();
        }
    }
}