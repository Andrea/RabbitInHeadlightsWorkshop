module TypeProviderExample

//Type providers
#if INTERACTIVE

#r "PresentationFramework.dll"
#r "System.Xaml"
#r @"..\packages\FSharp.Data.2.0.8\lib\portable-net40+sl5+wp8+win8\FSharp.Data.dll"
 
#endif
open System
open FSharp.Data
open System.IO
 
 [<Literal>]
let path = @"..\..\IrelandProgrammingLanguages.csv"
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
 
 