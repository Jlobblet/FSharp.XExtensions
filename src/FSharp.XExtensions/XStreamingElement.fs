namespace FSharp.XExtensions

open System
open System.Xml.Linq

[<AutoOpen>]
module XStreamingElement =
    type XStreamingElement with
        // Factory methods since can't extend with new constructors
        member this.Create name = name |> XName.Get |> XStreamingElement
        member this.Create(name, content: Object) = XStreamingElement(XName.Get name, content)
        member this.Create(name, [<ParamArray>] content) = XStreamingElement(XName.Get name, content)
