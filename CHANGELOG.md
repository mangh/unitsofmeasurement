### Release 2.1 Build 2021.05.06.1151

###### Going to VS 2019

* VSIX Release 2.1 developed with (and for) VS 2019; installer available at [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=MarekAniola.UnitsOfMeasurement-18451).

###### Bugs removed

* Fixed a bug in _Man.UnitsOfMeasurement.Parser_ that could make it hang in an infinite loop trying to unravel certain (not necessarily weird) relationships between units.

###### Modified templates: _Units/\_generator.tt_ and _RuntimeLoader/Generator.tt_

* unit and scale templates moved to external files (_\_unit.t4_ and _\_scale.t4_ correspondingly) to be used in generators as T4 include files.

* newer C# syntax used in templates (though not the latest one that requires _Roslyn_ compiler). _RuntimeLoader_ still uses the old _csc_ compiler that does not accept the latest syntax (that is possible to employ _Roslyn_ in _RuntimeLoader_ but the number and size of NuGet packages required for this is overwhelming and makes me skeptical about this approach).

* static _properties_ have been replaced by _constants_ or static readonly _fields_:
```C#
    public static readonly Dimension Sense = ...;
    public const int Family = ...;
    public static readonly SymbolCollection Symbol = ...;
    public static readonly Unit<double> Proxy = ...;
    public const double Factor = ...;

    // except Factor for monetary units (only):
    public static decimal Factor { get; set; }

    // and Format that remains gettable/settable property for all units:
    public static string Format { get; set; }
```

* new method to format value types (_float_, _double_, _decimal_) into a string with a unit tag prepended/appended:
```C#
    // for units:
    static string String(<valuetype> q, string format, IFormatProvider fp)
    // and scales:
    static string String(<valuetype> q, string format, IFormatProvider fp)

    // For example:
    //    Meter.String(123.45) -> "123.45 m"
    //    Fahrenheit.String(123.45) -> "123.45 deg.F"
```
* _Unit/\_dimensional_analysis.include_: C# file created (while generating units/scales) to facilitate a transition from calculations based on measured quantities to (faster) calculations on plain numbers. The transition is intended to be performed within the same source code (possibly) supplemented with conditional statements. Alas, C# does not support include-files functionality! Shit happens! So, if you decide to make use of the generated file you have to include it "by hand". Take a look at [BulletMeasured.cs](https://github.com/mangh/unitsofmeasurement/blob/master/Demo/Bullet/BulletMeasured.cs) sample to see how the transition can be made.

* _Unit/Math.cs_ (static file, independent of generators): could provide basic math expressions on measured quantities (e.g. `Sin(Radian)`, `Cos(Radian)` etc.). Initially empty (provides nothing): it is up to you to decide its content.

###### Modified Demo apps

* [_Demo/Bullet_](https://github.com/mangh/unitsofmeasurement/tree/master/Demo/Bullet): new sample application that is doing (basically) the same as [_Demo/ProjectileRange_](https://github.com/mangh/unitsofmeasurement/tree/master/Demo/ProjectileRange) but is more accurate on time measurement and thus provides more reliable benchmarks.
* [_Demo/Benchmark_](https://github.com/mangh/unitsofmeasurement/tree/master/Demo/Benchmark): now it employs [BenchmerkDotNet](https://benchmarkdotnet.org/) framework to get more accurate and reliable results.


### Release 2.0 Build 2017.03.10.1639

###### Going to VS 2017

* VSIX Release 2.0 for VS 2017 available at [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=MarekAniola.UnitsOfMeasurement-18451).

* VSIX Release 2.0 for VS 2010-2015 available at [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=MarekAniola.UnitsofMeasurement) (final release for VS 2010).

###### Unit\<T\> and Scale\<T\> proxies redesigned

* _Unit\<T\>_ and _Scale\<T\>_ proxies have been redesigned to eliminate Reflection mechanism. Now the proxies are all generated from _\_generator.tt_ template together with the corresponding units and scales. In effect, usage of Reflection has been reduced to a minimum: for compile-time units/scales it is not used at all, while for run-time (late) units it is used only to retrieve the proxies from an intermediate DLL, but never used when operating them.

###### IQuantity\<T\> and ILevel\<T\> interfaces redesigned accordingly

* _IQuantity\<T\>_ (_ILevel\<T\>_) instance provides access to the whole _Unit\<T\>_ unit proxy (_Scale\<T\>_ scale proxy) correspondingly (and not to its selected properties only as previously).

###### UnitCatalog\<T\> and ScaleCatalog\<T\> replaced by a single, static Catalog

* Single, static _Catalog_ class (for all unit and scale proxies of any type) replaces previous _Unit-_ and _Scale-Catalog\<T\>_ classes heavily using Reflection. The _Catalog_ is partially generated from _\_generator.tt_ template (to populate it with units specified in a definition text file) and is available as a whole in _Units_ solution folder at compile-time. 

* _Parser_ solution folder has replaced _Catalog_ folder. It contains just a few classes providing parsing functionality previously offered by _UnitCatalog\<T\>_ and _ScaleCatalog\<T\>_ classes. 

###### New conversion functions supporting scales & levels.

* New conversion functions to ease interpreting _quantity_ as a _level_ (or attaching _quantity_ to a _scale_). Their goal is to defer issues resulting from distinguishing _levels_ and _quantities_ to a moment when the distinction is really essential and thus, focus on _quantities_ as a basic processing entities:
```C#
    // Fahrenheit scale (for example)
    public static Fahrenheit From(IQuantity<double> q)
```
```C#
    // Scale<T> proxy
    public abstract ILevel<T> From(IQuantity<T> quantity);
```
###### Case-sensitive unit symbols

* Unit symbols handled as case-sensitive strings only. The mechanism that allowed previously to switch between case-sensitive and case-insensitive interpretation has been removed.

###### SymbolCollection.Default property

* _SymbolCollection.Default_ property introduced to avoid indexer expression _Symbol[0]_ e.g.:
```C#
    Meter.Symbol.Default	// instead of Meter.Symbol[0]
```
###### Parser changes

* Wedge product: wedge operator "^" can be applied to multiply units (only) apart from the standard star operator "\*". This allows to make a distinction between scalar (\*) and vector (^) products that create different units from the same factors, for example:
```
    unit Joule "J" = Newton * Meter;          /*energy*/
    unit NewtonMeter "N*m" = Newton ^ Meter;  /*torque*/
```
* Validating scales: scales (within a single family) must be derived from different units, otherwise they are deemed indistinguishable and rejected.

* Validating unit symbols: unit symbols must be unique. No two units can use the same (case sensitively) symbol.

* Parser diagnostics improved: more meaningfull, less misleading error messages.

### Release 1.5 Build 2017.01.23.1151

###### Performance improvements

* Extended interfaces IQuantity\<T\> and ILevel\<T\>. Now unit and scale properties (Family, Factor etc.) can be accessed directly, via IQuantity\<T\> or ILevel\<T\> interfaces, without referring to Reflection-based and performance (very) costly proxy
  types: Unit\<T\> and Scale\<T\>.

* Delegates applied in Unit\<T\> and Scale\<T\> proxies. This significantly enhance the performance of the proxy-types (previously operating via pure Reflection). Creation (constructor) of a proxy-type is still Reflection-based
  and costly but usage of (a previously created) proxy is much (hundreds of times) faster than previously.

###### Other changes

* UnitCatalog[] and ScaleCatalog[] indexers extended.

* Benchmark demo enhanced: averages calculated for all operations, all averages calculated with a standard deviation.

* .Net Framework Client Profile abandoned. Only full .Net Framework Profile is used.

* Removed redundant namespace reference in RuntimeLoader.Decompiler.


### Release 1.4 Build 2016.09.05.1130

* ```internal``` access for ```m_value``` & ```m_level``` fields in unit & scale structs. Access modifier for ```m_value``` & ```m_level``` fields changed from ```private``` to ```internal```. This allows to access these fields directly (not via ```Value``` & ```Level``` properties), and consequently, results in faster quantity arithmethic. ```Demo/Benchmark``` shows (under VS2010) that unit/plain arithmetic performance ratio decreased to about 1.3 versus 1.6 in previous version, with private fields.
* One (unified) ```_generator.tt``` template that can generate units both in a single .cs file as well as in multiple .cs files (one for each unit). Output mode depends on boolean variable ```__one_cs_file``` (declared within _generator.tt). Set: ```__one_cs_file = true;``` to generate all units in a single file (default), or: ```__one_cs_file = false;``` to generate units in separate files.
* Replaced icon & preview images for the project template & VSIX.
* Removed VSIX constraint on the ```MaxVersion``` of the .NET Framework that can be used with the library.
* ```AssemblyFileVersion``` for internal subprojects changes only when source files change (and not with every build).

### Release 1.3 Build 2015.10.16.1742

* fix #3: Unit family not recognized due to parenthesized dimensional
  expressions.
* fix #2 (again): "Run Custom Tool" performing very slow on ```_generator.tt``` under VS 2015. The generator has been modified to generate all units and scales in a single .cs file (instead of separate .cs files, one for each unit/scale). Under VS2015, it is somehow easier to recreate class-view subitems attached to a single .cs file than recreate the same class-views attached to many separate .cs files. You can restore previous functionality by replacing  ```_generator.tt``` with ```_generator-multiplefiles.tt``` from the archive   ```_alternative_generators_readme.zip``` that you can find attached to newly created projects.

### Release 1.2 Build 2015.10.01.1851

* fix #1: CSharpCodeProvider not Disposed() in RuntimeLoader.Compiler.
* fix #2: "Run Custom Tool" performing very slow under VS 2015.

### Release 1.1 Build 2015.08.14.1517

###### Visual Studio 2015 supported

* VSIX manifest (extension.vsixmanifest) extended to support VS 2015 and .NET Framework 4.6.

### Release 1.1 Build 2015.04.22.1652

###### RuntimeLoader created

* RuntimeLoader functionality to load (late) units and scales from a definition text file at runtime.
* RuntimeUnits sample application as a RuntimeLoader demo.

###### Abandoned VSIX for VS Express editions

* As of VS Community edition it does not make sense to support VS Express editions.

###### IQuantity and ILevel interfaces simplified

* Static properties of unit (Sense, Family, Factor, Format, Symbol) and scale (Offset, Format) are no longer dragged behind each of their instances (as properties of quantities and levels).
* These properties are still available via proxy types: Unit\<T\> and Scale\<T\> i.e. via reflection, which is slow but this impacts only performance of the "generic" conversion method "From".
* You can safely restore previous functionality (by restoring the interfaces and properties in unit and scale templates as it was in Release 1.0).

###### Unit test settings restored

* Test settings (previously .gitignored) now included back into the repository.

###### Catalog redesigned

* All catalog-related functionality moved to Catalog subfolder.
* UnitProxy replaced by (abstract) Measure and its subclasses: either
  Unit\<T\> or Scale\<T\> types, representing (correspondingly) unit and
  scale proxy types (T=double|decimal|float).
* UnitCatalog replaced by UnitCatalog\<T\> for cataloging Unit\<T\> proxies and parsing text input into IQuantity\<T\>.
* Added ScaleCatalog\<T\> (as twin of UnitCatalog\<T\>) for cataloging Scale\<T\> proxies and parsing text input into ILevel\<T\>.

###### Scale definition syntax extended (ScaleReferencePointAttribute)

* Scale definition syntax extended to distinguish scale families bound to different reference levels but derived from the same units. E.g. two temperature scale families: one bound to absolute zero level and the other one to water freeze point. The new syntax allows to specify the name (identifier) of the reference level, that is common to all members of the family.
* Scales defined with this new syntax receive ScaleReferencePointAttribute specifying the name of the family common reference level.

###### Unit and Scale types implement IFormattable

* Units/scales ToString methods rearranged to conform to IFormattable interface.

###### Family id initialized in T4 template

* Family is no longer initialized by the parser. That is set within \_generator.tt template (being under user control).

###### More precise ToStrings()

* Number.ToString methods of precision greater than the default (15 digits for doubles)

###### Unit and Scale type collections simplified

* UnitTypes and ScaleTypes collections (not very useful) replaced by standard List\<UnitType\> and List\<ScaleType\>.
* Superfluous namespace handling removed in UnitType and ScaleType.

###### Dimensional constants smoothed out

* The constants implemented in a better way (but functionally left unchanged).

###### Source code moved to GitHub

* Create README.md
* Copy LICENSE.txt


### Release 1.0, Build 2014.09.03.1235

###### Release 1.0 ready
