using System;
using System.Collections.Generic;

class program
{
    static void Main(string[] args)
    {
        int score = 0;
        Console.Write("Masukan Jumlah Inputan :");
        int JumlahInputan = Convert.ToInt32(Console.ReadLine());

        int[] angka = new int[JumlahInputan];

        for (int i = 0; i < JumlahInputan; i++)
        {
            angka[i] = Convert.ToInt32(Console.ReadLine());
            
        }

        for (int j = 0; j <JumlahInputan; j++)
        {
            if (angka[j] == 8)
            {
                score += 5;
            }
            else
            {
                if (angka[j] % 2 == 0)
                {
                    score += 1;
                }
                else
                {
                    score += 3;
                }
            }
        }

        Console.WriteLine(score);
    }
}