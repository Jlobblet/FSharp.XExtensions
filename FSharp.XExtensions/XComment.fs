module FSharp.XExtensions.XComment

open System.Xml.Linq

type XComment with
    member this.Ancestors = XName.Get >> this.Ancestors
    member this.ElementsAfterSelf = XName.Get >> this.ElementsAfterSelf
    member this.ElementsBeforeSelf = XName.Get >> this.ElementsBeforeSelf
    
    