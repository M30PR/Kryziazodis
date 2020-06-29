using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.IO;

public class Generator : MonoBehaviour
{
    public TextAsset textFile;
    Galvosukis[,] crossword = new Galvosukis[9, 9];
    List<Galvosukis> list = new List<Galvosukis>();
    int ri;
    int rj;
    void Kryžiažodis(List<Galvosukis> list)
    {
        System.Random rnd = new System.Random();
        int rng = rnd.Next(1, 2);
        Padėti(0, rng, 1);//Padedame pirmą žodį
        int m = Rasti(rng, 0, 1, 0, 1, 0);
        Padėti(m, 0, 2);
        int sk = Find(0);
        int k = Rasti(sk - 1, sk - 2, sk - 1, 0, 1, 0);
        Padėti(k, 0, 2);
    }
    int Rasti(int rng, int i1, int j1, int x, int y, int sk)
    {
        char x1 = list[sk].zodis[i1];
        char y1 = list[sk].zodis[j1];
        int n = list.Count;
        int m = 0;
        for (int i = 16; i < n; i++)
        {
            if (list[i].zodis[x] == x1)
            {
                ri = rng;
                rj = x;
                return m = i;
            }
            if (list[i].zodis[x] == y1)
            {
                ri = rng;
                rj = y;
                return m = i;
            }
            if (list[i].zodis[y] == x1)
            {
                ri = rng - 1;
                rj = x;
                return m = i;
            }
            if (list[i].zodis[y] == y1)
            {
                ri = rng;
                rj = y - 1;
                return m = i;
            }
        }
        return m;
    }
    int Find(int sk)
    {
        return list[sk].zodis.Length;
    }
    void Padėti(int sk, int rngsk, int kelintas)
    {
        if (kelintas == 1)
        {
            string pirmas = list[sk].zodis;
            int sk1 = 0;
            foreach (char item in pirmas)
            {
                Galvosukis gal = new Galvosukis(item.ToString(), list[sk].uzduotis, list[sk].hint);
                crossword[sk1, rngsk] = gal;
                sk1++;
            }
        }
        if (kelintas == 2)
        {
            string antras = list[sk].zodis;
            foreach (char item in antras)
            {
                crossword[ri, rj] = new Galvosukis(item.ToString(), list[sk].uzduotis, list[sk].hint);
                rj++;
            }

        }
    }
    void Reading(List<Galvosukis> list)
    {
        //string file = textFile.text;
        string file = @"C:\Users\laury\Desktop\Galvosukis.txt";
        //string[] words = phrase.Split(';');
        using (TextReader sr = File.OpenText(file))
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
    public Galvosukis[,] Gazinti()
    {
        Reading(list);
        Kryžiažodis(list);
        return crossword;
    }
}
