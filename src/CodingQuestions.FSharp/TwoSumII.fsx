(*
    Similar to Two Sum, except that the input array is already sorted in ascending order. 
*)

let twoSum (numbers:int[]) target =
    let rec bsearch key left right =
        if (left >= right) then
            -1
        else
            let m = (left + right) / 2
            if numbers.[m] = key then
                m
            elif (numbers.[m] < key) then
                bsearch key (m + 1) right
            else
                bsearch key (m + 1) right

    seq {
        for i in [0..numbers.Length - 1] do
            let j = bsearch (target - numbers.[i]) (i + 1) (numbers.Length - 1)
            if not (j = -1) then
                yield [| i + 1; j + 1 |]
    }