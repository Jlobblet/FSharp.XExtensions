module FSharp.XExtensions.XNode

open System.Xml.Linq

type XNode with
    member this.Ancestors = XName.Get >> this.Ancestors
    member this.ElementsAfterSelf = XName.Get >> this.ElementsAfterSelf
    member this.ElementsBeforeSelf = XName.Get >> this.ElementsBeforeSelf
