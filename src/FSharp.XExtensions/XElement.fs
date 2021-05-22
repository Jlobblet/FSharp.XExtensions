namespace FSharp.XExtensions

open System
open System.Xml.Linq

[<AutoOpen>]
module XElement =
    type XElement with
        // Factory methods since can't extend with new constructors
        member this.Create name = name |> XName.Get |> XElement
        member this.Create(name, content: Object) = XElement(XName.Get name, content)
        member this.Create(name, [<ParamArray>] content) = XElement(XName.Get name, content)
        // Methods
        member this.Ancestors name = name |> XName.Get |> this.Ancestors
        member this.AncestorsAndSelf name = name |> XName.Get |> this.Ancestors
        member this.Attribute name = name |> XName.Get |> this.Attribute
        member this.Attributes name = name |> XName.Get |> this.Attributes
        member this.Descendants name = name |> XName.Get |> this.Descendants
        member this.DescendantsAndSelf name = name |> XName.Get |> this.DescendantsAndSelf
        member this.Element name = name |> XName.Get |> this.Element
        member this.Elements name = name |> XName.Get |> this.Elements
        member this.ElementsAfterSelf name = name |> XName.Get |> this.ElementsAfterSelf
        member this.ElementsBeforeSelf name = name |> XName.Get |> this.ElementsBeforeSelf
        member this.SetAttributeValue(name, value) = this.SetAttributeValue(XName.Get name, value)
        member this.SetElementValue(name, value) = this.SetElementValue(XName.Get name, value)
