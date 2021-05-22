namespace FSharp.XExtensions

open System.Xml.Linq

[<AutoOpen>]
module XContainer =
    type XContainer with
        member this.Ancestors name = name |> XName.Get |> this.Ancestors
        member this.Descendants name = name |> XName.Get |> this.Ancestors
        member this.Element name = name |> XName.Get |> this.Element
        member this.Elements name = name |> XName.Get |> this.Elements
        member this.ElementsAfterSelf name = name |> XName.Get |> this.ElementsAfterSelf
        member this.ElementsBeforeSelf name = name |> XName.Get |> this.ElementsBeforeSelf
    
    