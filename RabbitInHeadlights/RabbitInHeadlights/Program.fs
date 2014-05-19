// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

 // value
let answer = 42

//immutable
//let answer = "everything"

//define a fn
let add x y = y+x

// add type
//let split phrase =
let split (phrase:string) =
    phrase.Split ' '
    
printfn "%A" (split "Something something something, dark side!" )


// lists

let firstHundred = [0..100]
let doubled = List.map (fun x -> x * 2) firstHundred


// And adding pipes


let sumar =  firstHundred
            |> List.map( fun x-> x * 2)
            |> List.sum


// Units of Measure

[<Measure>]
type Miles

[<Measure>]
type Hour

let distance = 10<Miles>
let distance2 = 10<Miles>
let distanceSum = 
     distance + distance2
    
let time = 5<Hour>

let velocity = distanceSum / time


//Option types
let num = Some 1
let notnum = None

match num with 
| None -> printfn "num is None"
| Some x -> printfn "num is %i" x



// Tuples

let personInfo = "Tayla", 45454545

let myFunction =
    let name, number = personInfo
    printfn "name is %s, number %i" name number
    printfn "Name is %s, number %i --" (fst personInfo) (snd personInfo)


//more type inference with tuples
open System.Collections.Concurrent

let convert =
    let collection = new BlockingCollection<int>() 
    collection.Add 4
    collection.TryTake()





// Discriminated unions


type Weapon = string
type Move = string
type Behaviour = string
type Character =
    | Player of Move * Weapon
    | NPC of Behaviour
    | Scenery

let jiro = Player("Throw", "Katana")
let tree = Scenery
let mempoWarrior = NPC("Chase")   






[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
   
   
   