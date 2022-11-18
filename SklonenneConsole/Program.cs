// See https://aka.ms/new-console-template for more information

using System;
using System.Text;
using System.Web;


const string galosn = "аоуыэіеёюя";
const string zacw = "шжчрц";
const string ostSogl= "бвгдзйклмнпстўфх";
string word, osnova, res;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;



while (true)
{
    
    Console.WriteLine("слова: ");
    word = Console.ReadLine();
    osnova = word;
    
    //2 skl
    bool muzczRod = true;
    bool asabowy;
    
    while (galosn.IndexOf(osnova[^1]) != -1)
    {
        osnova = osnova.Remove(osnova.Length - 1);
        muzczRod = false;
        if (osnova == null)
            throw new IndexOutOfRangeException();
    }
    
    
    //Console.WriteLine(osnova);
    res = osnova;
    
    
    //kali niyaki rod
    if (!muzczRod)
    {
        Console.WriteLine("у Месным склоне: ");
        res += 'е';
        Console.WriteLine(res);
        continue;
    }
    //asabovy?
    Console.WriteLine("Асабовае (1/0): ");
    asabowy = (Console.ReadLine() == "1")? true: false;
    
    Console.WriteLine("у Месным склоне: ");
    //muzczynskii rod (szmat wapadkau)
    var lastLit = osnova[^1];
    if (lastLit == 'ь')
        res = osnova.Remove(osnova.Length - 1) + (asabowy ? "|ю|" : "|і|");
    
    else if (lastLit == 'к')
        res += "|у|";
    
    else if (zacw.IndexOf(osnova[^1]) != -1)
        res += asabowy ? "|у|" : "|ы|";
    
    else if (lastLit == 'г')
        res = osnova + "|у| або " + osnova.Remove(osnova.Length - 1) + "|зе|\n" +
              "https://" + "slounik.org/search?dict=&search=" +HttpUtility.UrlEncode(word);
    
    else if (lastLit == 'х')
        res = osnova + "|у| або " + osnova.Remove(osnova.Length - 1) + "|се|\n" +
              "https://" + "slounik.org/search?dict=&search=" +HttpUtility.UrlEncode(word);
    
    else
    {
        if (res[^1] == 'й')
            res = res.Remove(osnova.Length - 1);
        else if (res[^1] == 'т')
            res = res.Remove(osnova.Length - 1) + 'ц';
        res += "|е|";
    }
        
    
    Console.WriteLine(res + "\n----------------------\n");
}



return 0;