module FSharp.XExtensions.XStreamingElement

open System
open System.Xml.Linq

type XStreamingElement with
    // Factory methods since can't extend with new constructors
    member this.Create = XName.Get >> XStreamingElement
    member this.Create(name, content: Object) = XStreamingElement(XName.Get name, content)
    member this.Create(name, [<ParamArray>] content) = XStreamingElement(XName.Get name, content)