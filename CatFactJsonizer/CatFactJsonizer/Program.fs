// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

//give facts a Guid 
//have person interact to give discoverer and time found tags.

open System
open System.IO
open Newtonsoft.Json

type CatFact = { discoverer: string; date: DateTime; guid: Guid; fact: string }


let readData = 
    File.ReadAllLines(@"C:\github\better-cat-facts\catfactsdata\catfacts.txt")

let AskUserForDiscovererName (fact : string) = 
    Console.WriteLine("Who discovered this?")
    Console.WriteLine(fact)
    Console.ReadLine()

let AskUserForDiscoveryDate fact =
    Console.WriteLine("When was this fact discovered?")
    Console.ReadLine()
    

let GetAllDataForCatFact fact = 
    let discoverer = AskUserForDiscovererName fact
    let date = AskUserForDiscoveryDate fact
    let guid = Guid.NewGuid()
    
    { discoverer = discoverer; date = DateTime.Parse(date); guid = guid; fact = fact }

[<EntryPoint>]
let main argv = 
    let stuff = readData 
                |> Array.toList
                |> List.map GetAllDataForCatFact
    
    let moreStuff = JsonConvert.SerializeObject(stuff)
    
    Console.WriteLine(moreStuff)

    File.WriteAllText("C:/github/better-cat-facts/catfactsdata/updatedCatFactsData.txt", moreStuff)

    Console.ReadLine()
    0 // return an integer exit code

    //one function to loop through facts and assign guid, date and name