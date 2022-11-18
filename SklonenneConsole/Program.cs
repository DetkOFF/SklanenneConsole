// See https://aka.ms/new-console-template for more information

using System;
using System.Text;
using System.Web;


const string galosn = "аоуыэіеёюя";
const string smiagGalosn = "іеёюя";
const string zacw = "шжчрц";
const string ostSogl= "бвгдзйклмнпстўфх";
string word, osnova, res = "";

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

int rod = 0; //0 - z; 1 - m; 2 - n

while (true)
{
    
    Console.WriteLine("слова: ");
    word = Console.ReadLine();
    osnova = word;
    
    //opredelenie roda
    if (galosn.IndexOf(osnova[^1]) == -1)
    {
        Console.WriteLine("Жаночага роду? (1/0): ");
        rod = (Console.ReadLine() == "1")? 0: 1;
    }
    else
    {
        if (osnova[^1] == 'я' || osnova[^1] == 'а')
            rod = 0;
        else
            rod = 2;
    }
    
    //niaki rod (2 skl)
    if (rod == 2)
    {
        while (galosn.IndexOf(osnova[^1]) != -1)
        {
            osnova = osnova.Remove(osnova.Length - 1);
            if (osnova == null)
                throw new IndexOutOfRangeException();
        }

        res = osnova;
        if (res[^1] == 'й' || res[^1] == 'ь')
            res = res.Remove(res.Length - 1);
        else if (res[^1] == 'т')
            res = res.Remove(osnova.Length - 1) + 'ц';
        res = osnova + "|е|";

    }
    //muzczynski rod (2 skl)
    else if (rod == 1)
    {
        res = osnova;
        var lastLit = osnova[^1];
        
        if (lastLit == 'к')
            res += "|у|";
        
        else if (lastLit == 'г')
            res = osnova + "|у| або " + osnova.Remove(osnova.Length - 1) + "|зе|\n" +
                  "https://" + "slounik.org/search?dict=&search=" +HttpUtility.UrlEncode(word);
    
        else if (lastLit == 'х')
            res = osnova + "|у| або " + osnova.Remove(osnova.Length - 1) + "|се|\n" +
                  "https://" + "slounik.org/search?dict=&search=" +HttpUtility.UrlEncode(word);
        else
        {
            Console.WriteLine("Асабовае (1/0)?: ");
            bool asabowy = (Console.ReadLine() == "1");
            if (lastLit == 'ь')
                res = osnova.Remove(osnova.Length - 1) + (asabowy ? "|ю|" : "|і|");
        
            else if (zacw.IndexOf(osnova[^1]) != -1)
                res += asabowy ? "|у|" : "|ы|";

            else
            {
                if (res[^1] == 'й' || res[^1] == 'ь')
                    res = res.Remove(osnova.Length - 1);
                else if (res[^1] == 'т')
                    res = res.Remove(osnova.Length - 1) + 'ц';
                res += "|е|";
            } 
        }
        
        
    }
    //zanoczy rod (3 skl)
    else if (galosn.IndexOf(osnova[^1]) == -1)
    {
        res = osnova;
        var lastLit = osnova[^1];
        if (zacw.IndexOf(lastLit) != -1)
            res += "|ы|";
        else
        {
            if (res[^1] == 'й' || res[^1] == 'ь')
                res = res.Remove(osnova.Length - 1);
            else if (res[^1] == 'т')
                res = res.Remove(osnova.Length - 1) + 'ц';
            res += "|і|";
        }
        
    }
    //zanoczy rod (1 skl)
    else
    {
        bool myagk = osnova[^1] == 'я';
        
        osnova = osnova.Remove(osnova.Length - 1);
        res = osnova ?? throw new IndexOutOfRangeException();
        
        var lastLit = osnova[^1];

        if (zacw.IndexOf(lastLit) != -1)
            res += "|ы|";
        
        else if (myagk)
            res += "|і|";
        
        else if (lastLit == 'г')
            res =  osnova.Remove(osnova.Length - 1) + "з|е|";
    
        else if (lastLit == 'х')
            res = osnova.Remove(osnova.Length - 1) + "с|е|";
        
        else if (lastLit == 'к')
            res = osnova.Remove(osnova.Length - 1) + "ц|ы| або " + osnova.Remove(osnova.Length - 1) + "ц|Э|\n" +
            "https://slounik.org/search?dict=&search=" +HttpUtility.UrlEncode(word);
            
        else
        {
            if (res[^1] == 'й' || res[^1] == 'ь')
                res = res.Remove(osnova.Length - 1);
            else if (res[^1] == 'т')
                res = res.Remove(osnova.Length - 1) + 'ц';
            res += "|е|";
        }

    }
    Console.WriteLine("у Месным склоне: ");
    Console.WriteLine("аб " + res + "\n----------------------\n");
}
