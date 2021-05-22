module FSharp.XExtensions.XElement

open System
open System.Xml.Linq

type XElement with
    // Factory methods since can't extend with new constructors
    member this.Create = XName.Get >> XElement
    member this.Create(name, content: Object) = XElement(XName.Get name, content)
    member this.Create(name, [<ParamArray>] content) = XElement(XName.Get name, content)
    // Methods
    member this.Ancestors = XName.Get >> this.Ancestors
    member this.AncestorsAndSelf = XName.Get >> this.Ancestors
    member this.Attribute = XName.Get >> this.Attribute
    member this.Attributes = XName.Get >> this.Attributes
    member this.Descendants = XName.Get >> this.Descendants
    member this.DescendantsAndSelf = XName.Get >> this.DescendantsAndSelf
    member this.Element = XName.Get >> this.Element
    member this.Elements = XName.Get >> this.Elements
    member this.ElementsAfterSelf = XName.Get >> this.ElementsAfterSelf
    member this.ElementsBeforeSelf = XName.Get >> this.ElementsBeforeSelf
    member this.SetAttributeValue(name, value) = this.SetAttributeValue(XName.Get name, value)
    member this.SetElementValue(name, value) = this.SetElementValue(XName.Get name, value)
    