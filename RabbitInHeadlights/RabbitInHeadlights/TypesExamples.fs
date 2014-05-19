module TypesExamples
  
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


// Records 
    type Vector2Data = { x: float; y: float }

    let equal = 
        let vect1 = {x = 1.0; y= 4.0}
        let vect2 = {y = 4.0; x= 1.0}
        vect1 = vect2  
