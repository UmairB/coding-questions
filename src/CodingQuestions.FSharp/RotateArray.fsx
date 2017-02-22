let rotateArray arr n =
    let reduced = n % Array.length arr // handles case when n is greater than length of array
    //printfn "reduced: %i" reduced
    let cutPoint = if reduced <= 0 then reduced + arr.Length else reduced // handle case if cutpoint is less than or equal to 0
    //printfn "cutPoint: %i" cutPoint
    Array.append arr.[cutPoint..] arr.[..(cutPoint-1)]
