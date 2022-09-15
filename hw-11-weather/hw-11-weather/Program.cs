using Microsoft.VisualBasic;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;
using File = System.IO.File;
using System.Security.Principal;
using Newtonsoft.Json;
using WeatherAPI;

internal class Program
{
    private static async Task Main()
    {
        Console.WriteLine("Введите название города: ");
        string city = Console.ReadLine();
        await WeatherFromAPI.GetWeather(city);
    }
}