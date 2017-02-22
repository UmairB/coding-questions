(*
    Given an array of integers, find two numbers such that they add up to a specific target number. 
    The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. 
    Please note that your returned answers (both index1 and index2) are not zero-based.
*)

open System.Collections.Generic

/// Brute force approach, is O(n^2)
let twoSum (numbers:int[]) (target) =
    seq {
        for i in [0..numbers.Length - 1] do
            for j in [i+1..numbers.Length - 1] do
                let x_i = numbers.[i]
                let x_j = numbers.[j]

                if (x_i + x_j = target) then
                    yield [| i + 1; j + 1 |]
    }
    //|> Seq.tryHead
    
/// Dictionary/map approach, O(n)
let twoSum2 (numbers:int[]) (target) =
    seq {
        let map = Dictionary<int, int>()
        for i in [0..numbers.Length - 1] do
            let value = numbers.[i]
            let x = target - value
            
            if map.ContainsKey x then
                yield [| map.[x] + 1; i + 1 |]
            
            if not (map.ContainsKey value) then
                map.Add(value, i)
    } |> Seq.tryHead

let x = [| 1; 1; 3; 4; 5; |]
twoSum x 6
twoSum2 x 6