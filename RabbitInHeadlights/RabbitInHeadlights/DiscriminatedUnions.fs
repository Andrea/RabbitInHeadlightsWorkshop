module FirstSteps

// value
let answer = 42

//immutable
//let answer = "everything"

//define a fn
let add x y = y + x

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

let mapAndSum = List.map(fun x-> x * 2) >> List.sum


mapAndSum firstHundred |> ignore


module UnitOfMeasure =
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

module DiscriminatedUnion =

//Option types
    let num = Some 1
    let notnum = None

    match num with 
    | None -> printfn "num is None"
    | Some x -> printfn "num is %i" x

// DU
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