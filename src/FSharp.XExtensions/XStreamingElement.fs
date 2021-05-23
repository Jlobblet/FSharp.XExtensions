namespace FSharp.XExtensions

open System
open System.Xml.Linq

[<AutoOpen>]
module XStreamingElement =
    type XStreamingElement with
        // Factory methods since can't extend with new constructors
        static member Create name = name |> XName.Get |> XStreamingElement
        static member Create(name, content: Object) = XStreamingElement(XName.Get name, content)
        static member Create(name, [<ParamArray>] content) = XStreamingElement(XName.Get name, content)
