module FirstSteps

// Binding to values
let answer = 42

//TODO: Change the value of *answer*, it should feel bad and painful so that you have time to think about the bad things


// what happens if you try to change answer to be a string?



// Binding to a value
let add x y = y + x

// TODO: Call add with different types of numbers, what happens?


//Types as funciton parameters
let split (phrase:string) =
    phrase.Split ' '
    
printfn "%A" (split "Something something something, dark side!" )

//TODO:How would you change the function above so that it takes two strings, make sure you call the function (it doesn't matter if the second parameter is not used


//TODO: Now change the function so that the function takes the two parameters and returns the second string (i.e. if you passed "a b" and "c d" the function should return ["c"; "d"]


// Lists

let firstHundred = [0..100]

// TODO: define an empty f# list, can you change add items after declaring it?



// List comprehensions
let doubled = List.map (fun x -> x * 2) firstHundred

//TODO: find one of the many other list comprehensions and transform the firstHundred list into something else amazing and wonderful, the (coolest and fastest) gets a prize



// Adding pipes, playing with functions
let sumar =  firstHundred
            |> List.map( fun x-> x * 2)
            |> List.sum

let mapAndSum = List.map(fun x-> x * 2) >> List.sum

printfn "%i" (mapAndSum firstHundred )

//TODO:  find the avg of all positive odd numbers smaller than 100



// Units of Measure
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

    printfn "velocity is %i" (int velocity)

//TODO: Create Miles and Kilometers Unit of measure, create a function to convert Kilometers to miles, :D





module DiscriminatedUnion =

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


    let FindPlayer character =
        match character with
        | Player (move , weapon ) -> printfn "Yes! you found the player with move %s and weappon: %s" move weapon
        | _ -> printfn "didn't find it"

    
    FindPlayer tree

//Option types
    let num = Some 1
    let notnum = None

    match num with 
    | None -> printfn "num is None"
    | Some x -> printfn "num is %i" x

//TODO: Create a function that can feed different pets.. differnt pets need different food and drink, some dont need drink. 
//      Make sure you deal with the case when there is no pets to feed