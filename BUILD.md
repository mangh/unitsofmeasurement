# How to build the solution

1. Clone the solution e.g.:
	```
	git config --system core.autocrlf true
	-- or --
	git config --global core.autocrlf true

	git clone https://github.com/mangh/unitsofmeasurement.git
	```

2. Open UnitsOfMeasurement.sln in Visual Studio: 

	_DO NOT BUILD THE SOLUTION! AT THE MOMENT THE BUILD WILL FAIL! THE SOLUTION MUST BE CONFIGURED FIRST AND THAN IT CAN BE BUILT GRADUALLY, STEP BY STEP_.
	
3. Unload `VisualStudioExtension/ProjectTemplate` project: there are template parameters of the form `$whatever$` - seen as invalid C# variables - embedded in project files, that make project build to always fail and in turn prevent any build for the entire solution.

3. Decide what versions of components to use:

	* `.NET Framework` version e.g. .NET Framework 4.7.2, 
	* `Microsoft.VisualStudio.TemplateWizardInterface` version

4. Build `VisualStudioExtension/Parser` project (it provides for a parser library DLL required by the other projects):

	* set target .NET framework release e.g.:
	```
	Parser project / Properties / Application / Target Framework: .NET Framework 4.7.2
	```
	* sign project assembly (with whatever strong name key file) e.g.:
	```
	Parser project / Properties / Signing / Sign the assembly: ON
	Parser project / Properties / Signing / Choose strong name key file: keyfile.pfx
	```
	* build the project.

5. Build `Demo/UnitsOfMeasurement` project (it provides for a sample units of measurement library DLL required by the other projects in Demo folder and - the most important - it is a sort of an instance of the target project template that we want to build):

	* set the same target .NET framework release as above e.g.:
	```
	UnitsOfMeasurement project / Properties / Application / Target Framework: .NET Framework 4.7.2
	```
	* saving the above change automatically starts (two) templates being part of the project; click OK (twice) to run the templates
	* make any changes that you need in the source code (regarding functionality, templates, etc.) 
	* build the project.

6. Build the remaining projects in the Demo folder. For each project:

	* set the same target .NET framework release e.g.:
	```
	project / Properties / Application / Target Framework: .NET Framework 4.7.2
	```
	* build the project.

7. Build `VisualStudioExtension/TemplateWizard` project:

	* set target .NET framework release e.g.:
	```
	TemplateWizard project / Properties / Application / Target Framework: .NET Framework 4.7.2
	```
	* sign project assembly (with whatever strong name key file) e.g.:
	```
	TemplateWizard project / Properties / Signing / Sign the assembly: ON
	TemplateWizard project / Properties / Signing / Choose strong name key file: keyfile.pfx
	```
	* build the project.

8. Run unit tests in `Demo/UnitsOfMeasurement.Test` to see whether the sample units library `Demo/UnitsOfMeasurement` - which is also an instance for the target project template - works correctly.

9. Create project template:
	* transfer (mostly manually) changes (if any) made to files of `Demo/UnitsofMeasurement` project to the corresponding files of the target `VisualStudioExtension/ProjectTemplate` project.
	* export updated `VisualStudioExtension/ProjectTemplate` project as a project template i.e.:
		* reload the project
		* execute command "Export template..." from menu Project
		* unload the project again right after exporting
	* copy the template exported to file `C:/Users/<USER>/Documents/Visual Studio NNNN/My Exported Templates/UnitsOfMeasurement.zip` back to the solution i.e. to `VisualStudioExtension/VSIX/ProjectTemplates` folder.
	
10. Build VSIX extension:
	* complete the exported template with the information necessary for running `TemplateWizard`:
		* unzip the `UnitsOfMeasurement.zip` file
		* add `<WizardExtension>` node to `MyTemplate.vstemplate` file as in the following excerpt (do not forget to replace _Version_ and _PublicKeyToken_ sample values below with values suitable for your solution):
		``` xml
		<VSTemplate>
			<TemplateContent>
			...
			</TemplateContent>
			<WizardExtension>
				<Assembly>Man.UnitsOfMeasurement.TemplateWizard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=e39293613f96e2c4</Assembly>
				<FullClassName>Man.UnitsOfMeasurement.TemplateWizard</FullClassName>
			</WizardExtension>  
		</VSTemplate>
		```
		* zip it all back to the same `UnitsOfMeasurement.zip` template
	* set target .NET framework release e.g.:
	```
	VSIX project / Properties / Application / Target Framework: .NET Framework 4.7.2
	```
	* build `VisualStudioExtension/VSIX` project.
