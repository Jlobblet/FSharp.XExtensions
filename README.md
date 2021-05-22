# FSharp.XExtensions

I got fed up of having to write `XName.Get` so I wrote this library.
This library gives all of the classes in the `System.Xml.Linq` namespace overloads for methods that take `XName`s to take `string`s instead.

### Why?

In C#, `string`s are allowed to be implicitly converted into `XName`s.
```c#
public XAttribute Foobar(XElement element) => element.Attribute("attr" /* implict conversion*/);
```
This is not the case in F#, making code that deals with XML quite non-ergonomic at times.
```f#
let Foobar (element: XElement) = element.Attribute "attr" // Compile error
```
The overloads help compensate for this.
```f#
open FSharp.XExtensions
let Foobar (element: XElement) = element.Attribute "attr" // Hoorah!
```

## NuGet

https://www.nuget.org/packages/FSharp.XExtensions/1.0.0

## Contributing

Pull requests welcome!

## License

Creative Commons Zero v1.0 Universal. Go nuts.
