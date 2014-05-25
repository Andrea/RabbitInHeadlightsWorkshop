module TypeProviderExample

//Type providers
#if INTERACTIVE
#load "..\packages\FSharp.Charting.0.90.6\FSharp.Charting.fsx"
#r "PresentationFramework.dll"
#r "System.Xaml"
#r @"..\packages\FSharp.Data.2.0.8\lib\portable-net40+sl5+wp8+win8\FSharp.Data.dll"
System.IO.Directory.SetCurrentDirectory( __SOURCE_DIRECTORY__)
#endif
open System
open FSharp.Data
open System.IO
open FSharp.Charting

 [<Literal>]
let path = "..\..\IrelandProgrammingLanguages.csv"
type Languages = FSharp.Data.CsvProvider<path>
 
let split (text:string) =
    text.Split ','
    |> Seq.toList
    
 
let splitAndCount string  =
    let languages= split string
    float languages.Length
 
    
let listLength languages=
    List.length languages
    
let reduceLanguageCount langs count=
    count, List.fold (fun acc langCount -> if(int langCount =count) then acc + 1 else acc ) 0 langs
    
let readLanguageData =     
    
    let data = Languages.Load(new FileStream(path, FileMode.Open))
    printfn "Headers are %A" data.Headers
    printfn "Rows are %A" data.Rows
 
    printfn "Number of languages in production vs hobby"
    
    let languageCount = Seq.toList data.Rows
                        |> List.map ( fun r -> splitAndCount r.``What programming language(s) are you using in production?``)     
    let reducedCount = [for x in 1..7 -> reduceLanguageCount languageCount x]    
    printfn "Number of languges used in production count %A" reducedCount
    
    let hobbiesCount = Seq.toList data.Rows
                        |> List.map ( fun r -> splitAndCount r.``What programming language(s) are you using in your hobby/side projects?``)     
    let hobbiesReducedCount = [for x in 1..7 -> reduceLanguageCount hobbiesCount x]    
    printfn "Number of languges used in hobbies %A" hobbiesReducedCount
    reducedCount, hobbiesReducedCount
    //TODO: verify that the count of languages matches the number of results we have  


//TODO plot a graph of reduced count vs Hobbies count, I was nice and added all the dependencies you needed 

    