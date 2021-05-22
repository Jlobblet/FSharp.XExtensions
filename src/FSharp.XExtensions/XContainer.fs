module FSharp.XExtensions.XContainer

open System.Xml.Linq

type XContainer with
    member this.Ancestors = XName.Get >> this.Ancestors
    member this.Descendants = XName.Get >> this.Ancestors
    member this.Element = XName.Get >> this.Element
    member this.Elements = XName.Get >> this.Elements
    member this.ElementsAfterSelf = XName.Get >> this.ElementsAfterSelf
    member this.ElementsBeforeSelf = XName.Get >> this.ElementsBeforeSelf
    
    