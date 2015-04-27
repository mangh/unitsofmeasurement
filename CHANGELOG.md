### Release 1.1 Build 2015.04.22.1652

###### RuntimeLoader created

* RuntimeLoader functionality to load (late) units and scales from a definition text file at runtime.
* RuntimeUnits sample application as a RuntimeLoader demo.

###### VSIX for VS Express editions abandoned

* As of VS Community edition it does not make sense to support VS Express editions.

###### IQuantity and ILevel interfaces simplified

* Static properties of unit (Sense, Family, Factor, Format, Symbol) and scale (Offset, Format) are no longer dragged behind each of their instances (as properties of quantities and levels).
* These properties are still available via proxy types: Unit\<T\> and Scale\<T\> i.e. via reflection, which is slow but this impacts only the performance of the "generic" conversion method "From".
* You can safely restore previous functionality (by restoring the interfaces and properties in unit and scale templates).

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

###### Unit and Scale types implement IFormattable.

* Units/scales ToString methods rearranged to conform to IFormattable interface.

###### Family id initialized in T4 template. 

* Family is no longer initialized by the parser. That is set within \_generator.tt template (being under user control).

###### More precise ToStrings().

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
