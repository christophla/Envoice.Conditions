### Envoice 

# Conditions [![Build status](https://ci.appveyor.com/api/projects/status/09c4fnv2ov54vpwm?svg=true)](https://ci.appveyor.com/project/christophla/conditions)

Conditions is a dotnet 2.0 class library that helps developers write pre- and postcondition validations in a fluent manner. Writing these validations is easy and it improves the readability and maintainability of code.

## Supported Platforms
* .NET 2.0

## Installation

Installation is done via MyGet:

    dotnet add package Envoice.Conditions --version 1.0.0-rc1 --source https://www.myget.org/F/envoice/api/v3/index.json


## Usage

```csharp
public ICollection GetData(Nullable<int> id, string xml, IEnumerable<int> col)
{
    // Check all preconditions:
    Condition.Requires(id, "id")
        .IsNotNull()          // throws ArgumentNullException on failure
        .IsInRange(1, 999)    // ArgumentOutOfRangeException on failure
        .IsNotEqualTo(128);   // throws ArgumentException on failure

    Condition.Requires(xml, "xml")
        .StartsWith("<data>") // throws ArgumentException on failure
        .EndsWith("</data>") // throws ArgumentException on failure
        .Evaluate(xml.Contains("abc") || xml.Contains("cba")); // arg ex

    Condition.Requires(col, "col")
        .IsNotNull()          // throws ArgumentNullException on failure
        .IsEmpty()            // throws ArgumentException on failure
        .Evaluate(c => c.Contains(id.Value) || c.Contains(0)); // arg ex

    // Do some work

    // Example: Call a method that should not return null
    object result = BuildResults(xml, col);

    // Check all postconditions:
    Condition.Ensures(result, "result")
        .IsOfType(typeof(ICollection)); // throws PostconditionException on failure

    return (ICollection)result;
}
    
public static int[] Multiply(int[] left, int[] right)
{
    Condition.Requires(left, "left").IsNotNull();
    
    // You can add an optional description to each check
    Condition.Requires(right, "right")
        .IsNotNull()
        .HasLength(left.Length, "left and right should have the same length");
    
    // Do multiplication
}
```
    
A particular validation is executed immediately when it's method is called, and therefore all checks are executed in the order in which they are written:

## C# 6
C# 6 compiler provides easier way for accessing extension methods. With `using static Condition;` you have no longer to prefix `Requried` and `Ensures` methods with name of `Condition` static class. 

For example:

```csharp
namespace Foo
{
    using static Condition; 
    
    public class Bar
    {
        public void Buzz(object arg)
        {
            Required(arg).IsNotNull();
        }
    }    
}
```

You can add C#6 features to your project by installing [Microsoft.Net.Compilers](https://www.nuget.org/packages/Microsoft.Net.Compilers/) nuget.

## With thanks to
* <a href="http://www.cuttingedge.it/">S. van Deursen</a> who is the original author of "<a href="https://conditions.codeplex.com/">CuttingEdge.Conditions</a>" from which this project was forked from.
