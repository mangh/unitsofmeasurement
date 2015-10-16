The following describes alternative (replaceable) generators that you may use
to generate units of measurement structures:

_generator-singlefile.tt

    Generates all unit/scale structures into a single .cs file (plus summary
    report in a separate .txt file).

    Under VS2015 it performs much better than multiple-files-generator (below).
    Class-view subitems attached (in Solution Explorer) to the generated .cs
    file allows to navigate between unit/scale classes (the functionality not
    available under VS2010).
    
    Attached by default to newly created projects under the name of _generator.tt.

_generator-multiplefiles.tt

    Generates multiple .cs files, one for each unit/scale (plus summary report
    in a separate .txt file).
    
    It might be useful under VS2010 which is not attaching class-view subitems
    to the generated .cs files. Under later VS releases, in particular VS2015,
    it may take much more time to generate the files (tens of seconds under
    VS2015 versus less than a second under VS2010).

USAGE:

    1. Unpack the .zip archive into Units folder. 
    
    2. Exclude (or delete) current generator from the project:
    
       > right-click on current generator,
       > Exclude From Project (or Delete).
        
    3. Attach one of the above generators to the project:
    
       > right-click on Units folder,
       > Add,
       > Existing Item,
       > select generator .tt file,
       > Add.
       