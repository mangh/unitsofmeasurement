### Product description
* Visual Studio project template for creating Units of Measurement C# class library. 
* Units of measurement generated from design-time T4 text template according to simple definitions in a text file (data model). You specify (in the text file) what units are required, their naming, underlying value type (_float_, _double_ or _decimal_) as well as conversion and arithmetic (operator) relationships between units. Text template generating units can be modified so the functionality of target library can be easily fit to your needs. 
* Units of measurement generated as types (_partial structs_). Thus, dimensional analysis can be performed as a syntax check at compile time (dimensional issues displayed in Visual Studio as syntax errors). See the example below. 
* Units of measurement for any of the fundamental dimension i.e.: _Length_, _Time_, _Mass_, _Temperature_, _ElectricCurrent_, _AmountOfSubstance_, _LuminousIntensity_ as well as _Other_ (e.g. _Money_ for currency units) and any of their combinations. 
Arithmetic (+, ++, -, --, *, /) and comparison (==, !=, <, <=, >, >=) operators to perform calculations directly on quantities of unit type. See the example below. 
* Conversions of _quantities_ to/from other (but compatible) unit types.

See [Documentation](https://github.com/mangh/unitsofmeasurement/wiki/Documentation) page for more information.

### How to use it?
Assuming you have already installed `UnitsOfMeasurement.vsix` component (see [Releases](https://github.com/mangh/unitsofmeasurement/releases) page for download and installation instructions), follow this general process to create a library:

1. create a new project of type *"Units of Measurement C# Class Library"*, 
2. go to *Units* folder in Solution Explorer, 
3. edit `_definitions.txt` to specify units of measurement that you need for your solution, 
4. (*optional*) modify `_generator.tt` T4 text template to fit unit and/or scale template text to your needs, 
5. right-click on `_generator.tt`, select *"Run Custom Tool"* command (press OK on Security Warning). 
6. (*optional*) create some extension (.cs) files to extend generated unit/scale (partial) structs with additional properties, methods or operators, 
7. compile the project.

### Example: detecting dimensional issues
Look at the following code sample (taken from [Demo/ProjectileRange](https://github.com/mangh/unitsofmeasurement/blob/master/Demo/ProjectileRange/Program.cs) application):
```C#
double g = 9.80665; // the gravitational acceleration
double v = 715.0;   // the velocity at which the projectile is launched (AK-47)
double h = 0.0;     // the initial height of the projectile
double angle = degrees * Math.PI / 180.0;	// the angle at which the projectile is launched

// the time it takes for the projectile to finish its trajectory:
double tmax = (v * Math.Sin(angle) + Math.Sqrt((v * Math.Sin(angle)) * (v * Math.Sin(angle)) + 2.0 * g * h));
```
It is hard to see that the expression for `tmax` is wrong: it expects to get _time_ on the left side but the right side calculates _velocity_ instead (it should be further divided by the acceleration `g` to be correct, but that was missed somehow). The expression is syntactically correct, compiles without errors, so it might be handed over to production with the problem unnoticed! 

Now look at the following example. This time, units of measurement are explicitly used as types of the variables (previously used as plain numbers):
```C#
var g = (Meter_Sec2)9.80665; // the gravitational acceleration
var v = (Meter_Sec)715.0;    // the velocity at which the projectile is launched (AK-47)
var h = (Meter)0.0;          // the initial height of the projectile
var angle = (Radian)degrees; // the angle at which the projectile is launched

// the time it takes for the projectile to finish its trajectory:
Second tmax = (v * UMath.Sin(angle) + UMath.Sqrt((v * UMath.Sin(angle)) * (v * UMath.Sin(angle)) + 2.0 * g * h));

```
This time the compiler displays _"Cannot implicitly convert type 'Demo.UnitsOfMeasurement.Meter_Sec' to 'Demo.UnitsOfMeasurement.Second'"_ error message, underlines erroneous statement and stops building with this kind of errors left unresolved.

As you can see, C# strong type checking is not strong enough to detect dimensional inconsistencies, but it can be strengthened by unit of measurement types. Note also that the code with units of measurement applied looks very much like the code based on plain numbers. This may ease switching from one approach (with units) to another (plain numbers).
