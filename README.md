### Product description

* Visual Studio project template for creating Units of Measurement C# class library.
* Units of measurement are generated from simple definitions in a text file according to T4 text templates. See [here](https://github.com/mangh/unitsofmeasurement/wiki/Overview) for an overview of unit generation process.
* Units of measurement are generated as types (_partial structs_). Thus dimensional analysis can be performed as a syntax check at compile time. Dimensional issues are displayed in Visual Studio as syntax errors. See [this](https://github.com/mangh/unitsofmeasurement/wiki/Detecting-dimensional-issues-(example)) example.
* All fundamental dimensions are supported i.e.: _Length_, _Time_, _Mass_, _Temperature_, _ElectricCurrent_, _AmountOfSubstance_, _LuminousIntensity_ as well as _Other_ (e.g. _Money_ for currency units) and any of their combinations.
* Arithmetic (+, ++, -, --, *, /) and comparison (==, !=, <, <=, >, >=) operators to perform calculations directly on _quantities_ of unit type. See [this](https://github.com/mangh/unitsofmeasurement/wiki/Detecting-dimensional-issues-(example)) example.
* Conversions of _quantities_ to/from other (but compatible) unit types.

Go to [Wiki](https://github.com/mangh/unitsofmeasurement/wiki) pages for more information.
<p style="font-weight: bold; color: brown; border: 1px solid brown; margin: auto; padding: 20px;">NOTE: There is a <i>dotnet</i> release for <i>.NET Core / Standard</i> available in the <a href="https://github.com/mangh/Metrology">Metrology</a> repository!</p>

### How to use it?
Assuming you have already installed *UnitsOfMeasurement.VSIX* component (see [Releases](https://github.com/mangh/unitsofmeasurement/releases) page for download and installation instructions), follow this general process to create a library:

1. Create a new project of type *"Units of Measurement C# Class Library"*. 
2. Go to *Units* folder in Solution Explorer:
    - edit *\_definitions.txt* to specify units of measurement that you need for your solution. 
    - (*optional*) modify _\_unit.t4_ and/or _\_scale.t4_ files to customize templates for generating units and/or scales. 
    - right-click on *\_generator.tt*, select *"Run Custom Tool"* command (press OK on Security Warning). 
    - (*optional*) create extension (.cs) files to extend generated unit/scale (partial) structs with additional properties, methods or operators, 
7. Go to *RuntimeLoader* folder (not available in release 1.0):
    - right-click on *Generator.tt*, select *"Run Custom Tool"* command (press OK on Security Warning). 
4. Compile the project.
