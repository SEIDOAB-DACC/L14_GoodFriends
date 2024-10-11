// See https://aka.ms/new-console-template for more information
using Configuration;
using Models;
using Seido.Utilities.SeedGenerator;

const string _seedSource = "./friends-seeds.json";

Console.WriteLine("AppTest");

var fn = Path.GetFullPath(_seedSource);
var _seeder = new csSeedGenerator(fn);

Console.WriteLine("\nFriends:");
var _friends = _seeder.ItemsToList<csFriend>(5);
foreach (var item in _friends)
{
    Console.WriteLine(item);
}

Console.WriteLine("\nAddresses:");
var __addresses = _seeder.ItemsToList<csAddress>(5);
foreach (var item in __addresses)
{
    Console.WriteLine(item);
}

Console.WriteLine("\nPets:");
var _pets = _seeder.ItemsToList<csPet>(5);
foreach (var item in _pets)
{
    Console.WriteLine(item);
}

Console.WriteLine("\nQuotes:");
var _quotes = _seeder.ItemsToList<csQuote>(5);
foreach (var item in _quotes)
{
    Console.WriteLine(item);
}