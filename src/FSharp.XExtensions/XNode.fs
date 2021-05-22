namespace FSharp.XExtensions

open System.Xml.Linq

[<AutoOpen>]
module XNode =
    type XNode with
        member this.Ancestors name = name |> XName.Get |> this.Ancestors
        member this.ElementsAfterSelf name = name |> XName.Get |> this.ElementsAfterSelf
        member this.ElementsBeforeSelf name = name |> XName.Get |> this.ElementsBeforeSelf
