using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class TextParcer
{
    string[] _words;

    public TextParcer(string text, int wordSize)
    {
        var list = RegexSearch(text);
        _words = list
            .Where(x => x.Length >= wordSize)
            .Distinct()
            .ToArray();
        Array.Sort(_words); //Это намного быстрее чем list.Sort()
        return;
    }

    public string[] GetResult() => _words;

    static List<string> RegexSearch(string text)
    {
        //Убирает номера глав из списка слов
        var romanNumReg = new Regex(@"\b[XVI]+\b");

        //Выбирает слова из текста, но исключает те в которых есть символы
        //К примеру он выберет слова(символы отрежет): Alisa; --Alisa; --Alisa--; Alisa--;
        //Но проигнорирует: Alisa's; Smart-Alisa; Smart--"Alisa;
        var regex = new Regex(
                @"/(?<=^[^a-zA-Z]*)[a-zA-Z]+(?=[^a-zA-Z]*\s)|(?<=\s[^a-zA-Z]*)[a-zA-Z]+(?=[^a-zA-Z]*\s)|(?<=\s[^a-zA-Z]*)[a-zA-Z]+(?=[^a-zA-Z]*$)/g",
                RegexOptions.Compiled
            );

        var matches = regex.Matches(text);
        var list = new List<string>();

        foreach (var match in matches)
        {
            var word = match.ToString();
            if (!romanNumReg.IsMatch(word))
                list.Add(word.ToLower());
        }

        return list;
    }
}

public struct WordLink
{
    public int Index;
    public int Length;
}