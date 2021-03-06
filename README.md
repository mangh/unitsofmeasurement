### Product description

* Visual Studio project template for creating Units of Measurement C# class library.
* Units of measurement are generated from simple definitions in a text file (data model) by means of (design-time) T4 text template. See [here](https://github.com/mangh/unitsofmeasurement/wiki/Overview) for an overview of unit generation process.
* Units of measurement are generated as types (_partial structs_). Thus dimensional analysis can be performed as a syntax check at compile time. Dimensional issues are displayed in Visual Studio as syntax errors. See [this](https://github.com/mangh/unitsofmeasurement/wiki/Detecting-dimensional-issues-(example)) example.
* All fundamental dimensions are supported i.e.: _Length_, _Time_, _Mass_, _Temperature_, _ElectricCurrent_, _AmountOfSubstance_, _LuminousIntensity_ as well as _Other_ (e.g. _Money_ for currency units) and any of their combinations.
* Arithmetic (+, ++, -, --, *, /) and comparison (==, !=, <, <=, >, >=) operators to perform calculations directly on _quantities_ of unit type. See [this](https://github.com/mangh/unitsofmeasurement/wiki/Detecting-dimensional-issues-(example)) example.
* Conversions of _quantities_ to/from other (but compatible) unit types.

Go to [Wiki](https://github.com/mangh/unitsofmeasurement/wiki) pages for more information.

### How to use it?
Assuming you have already installed *UnitsOfMeasurement.VSIX* component (see [Releases](https://github.com/mangh/unitsofmeasurement/releases) page for download and installation instructions), follow this general process to create a library:

1. Create a new project of type *"Units of Measurement C# Class Library"*. 
2. Go to *Units* folder in Solution Explorer: 
  1. edit *\_definitions.txt* to specify units of measurement that you need for your solution. 
  2. (*optional*) modify _ProcessUnit_ and/or _ProcessScale_ method(s) in *\_generator.tt* to customize template text for generating units and/or scales. 
  3. right-click on *\_generator.tt*, select *"Run Custom Tool"* command (press OK on Security Warning). 
  4. (*optional*) create extension (.cs) files to extend generated unit/scale (partial) structs with additional properties, methods or operators, 
3. Go to *RuntimeLoader* folder (not available in release 1.0):
  1. (*optional*) modify _ProcessUnit_ and/or _ProcessScale_ method(s) in *Generator.tt* to customize template text for generating run-time (late) units and/or scales.
  2. right-click on *Generator.tt*, select *"Run Custom Tool"* command (press OK on Security Warning). 
4. Compile the project.
