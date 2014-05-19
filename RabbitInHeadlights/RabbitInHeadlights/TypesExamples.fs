module TypesExamples


    type Vector2Data = { x: float; y: float }

    let equal = 
        let vect1 = {x = 1.0; y= 4.0}
        let vect2 = {y = 4.0; x= 1.0}
        vect1 = vect2  