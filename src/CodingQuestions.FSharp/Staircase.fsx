let staircase n =
    for i in 1 .. n do
        String.replicate (n-i) " " + String.replicate i "#" |> printfn "%s"
