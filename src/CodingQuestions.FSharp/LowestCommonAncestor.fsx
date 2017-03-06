type Tree<'T> = {
    Value: 'T
    Left: Tree<'T> option
    Right: Tree<'T> option }

let rec lowestCommonAncestor root p q =
    match root with
    | None -> None
    | Some(value) -> 
        if value.Value = p || value.Value = q then Some(value)
        else
            let left = lowestCommonAncestor value.Left p q
            let right = lowestCommonAncestor value.Right p q

            if left.IsSome && right.IsSome then Some(value)
            elif left.IsSome then left
            else right

let printResult tree =
    match tree with
    | None -> printfn "None"
    | Some(value) -> printfn "LCA: %i" value.Value
let tree = {
    Value = 10
    Left = Some {
        Value = 7
        Left = Some {
            Value = 4
            Left = Some {  
                Value = 2
                Left = None
                Right = None
            }
            Right = None
        }
        Right = Some {
            Value = 8
            Left = None
            Right = None
        }
    }
    Right = Some {
        Value = 30
        Left = Some {  
            Value = 16
            Left = None
            Right = None
        }
        Right = None
    }
}

lowestCommonAncestor (Some(tree)) 91 91 |> printResult
