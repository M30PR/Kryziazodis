using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using UnityEngine;
using System.IO;

public class CW_Generator : MonoBehaviour
{
    static Galvosukis[,] crossword = new Galvosukis[10, 10];
    static List<Galvosukis> list = new List<Galvosukis>();
    static int ri;
    static int rj;
    static void Kryžiažodis(List<Galvosukis> list)
    {
        System.Random rnd = new System.Random();
        int rng = rnd.Next(1, 2);
        Padėti(0,rng,1);//Padedame pirmą žodį
        int m = Rasti(rng,0,1, 0,1,0);
        Padėti(m, 0, 2);
        int sk = Find(0);
        int k = Rasti(sk-1, sk-2,sk-1 ,0, 1, 0);
        Padėti(k, 0, 2);
    }
    static int Rasti(int rng,int i1,int j1,int x , int y,int sk)
    {
        char x1 = list[sk].zodis[i1];
        char y1 = list[sk].zodis[j1];
        int n = list.Count;
        int m = 0;
        for (int i = 16; i < n; i++)
        {
            if(list[i].zodis[x] == x1)
            {
                ri = rng;
                rj = x;
                return m=i;
            }
            if (list[i].zodis[x] == y1)
            {
                ri = rng;
                rj = y;
                return m=i;
            }
            if (list[i].zodis[y] == x1)
            {
                ri = rng - 1;
                rj = x;
                return m=i;
            }
            if (list[i].zodis[y] == y1)
            {
                ri = rng;
                rj = y-1;
                return m=i;
            }
        }
        return m;
    }
    static int Find(int sk)
    {
        return list[sk].zodis.Length;
    }
    static void Padėti(int sk,int rngsk,int kelintas)
    {
        if(kelintas == 1)
        {
            string pirmas = list[sk].zodis;
            int sk1 = 0;
            foreach (char item in pirmas)
            {
                crossword[sk1, rngsk] = new Galvosukis(item.ToString(), list[sk].uzduotis, list[sk].hint);
                sk1++;
            }
        }
        if(kelintas == 2)
        {
            string antras = list[sk].zodis;
            foreach (char item in antras)
            {
                crossword[ri, rj] = new Galvosukis(item.ToString(), list[sk].uzduotis, list[sk].hint);
                rj++;
            }

        }
    }
    static void Sort(List<Galvosukis> list)
    {
        object p = list.Shuffle();
        list.Sort((a, b) => b.zodis.Length.CompareTo(a.zodis.Length));
    }
    static void Reading(List<Galvosukis> list)
    {
        string file = @"C:\Users\laury\Desktop\Galvosukis.txt";
        using (StreamReader sr = new StreamReader(file))
        {
            while (sr.Peek() >= 0)
            {
                string str;
                string[] strArray;
                str = sr.ReadLine();

                strArray = str.Split(';');
                Galvosukis galvosukis = new Galvosukis();
                galvosukis.zodis = strArray[0];
                galvosukis.uzduotis = strArray[1];
                galvosukis.hint = strArray[2];

                list.Add(galvosukis);
            }
        }
    }
    static Galvosukis[,] Gazinti()
    {
        Reading(list);
        Sort(list);
        Kryžiažodis(list);
        return crossword;
    }

    static void print()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if(crossword[i,j] == null)
                {
                    Console.Write("#");
                }
                else
                Console.Write(crossword[i, j].zodis);
            }
            Console.WriteLine();
        }
    }

    private static System.Random rng = new System.Random();

    public static void Shuffle<Galvosukis>(this IList<Galvosukis> list)
    {
           int n = list.Count;
           while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Galvosukis value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    public class Galvosukis
    {
        public string zodis { get; set; }
        public string uzduotis { get; set; }
        public string hint { get; set; }

        public Galvosukis(string z,string uz,string hint1)
        {
            this.zodis = z;
            this.uzduotis = uz;
            this.hint = hint1;
        }
        public Galvosukis()
        {

        }
        
    }
}