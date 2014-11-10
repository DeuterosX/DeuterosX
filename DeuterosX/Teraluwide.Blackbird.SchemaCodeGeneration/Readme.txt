This folder contains the tools necessary to generate serializable C# classes from the XML schemas in the Teraluwide.Blackbird.DataTypes project.

The generated code file (called DataFileSerializableClasses.cs) will be placed in this folder rather than overwrite the existing one, in order to give you a chance to compare the new file to the old one before overwriting it.

To generate a new code file, simply run the file in this folder called GenerateClasses.bat. If you have added new schemas to the project, you will need to add them to the xsd command in that file first. Xsd.exe names the initially generated C# file after the last schema in the list (there is stupidly no option for controlling the name of the generated file yourself), so if you add new schemas to the end of the list, you will need to edit the move command as well.

For ease of use, I have included xsd.exe in this folder. I have unfortunately not found a way to find the path for it automatically. The problem is that it comes from the Windows SDK, and its install path varies with the version of the SDK. Mine is in "C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools".

While Xsd.exe is absolutely fantastic, it does have some limitations. For instance, all single-type sequences in the schemas will be generated as arrays in the C# code, rather than as generic lists. Since we would much rather work with lists in the engine, I make use of an additional tool which replaces all the arrays with generic lists. The tool is called xsdcsa21.exe and I downloaded it from here: http://www.stefanbader.ch/xsdcsarr2l-exe-refactor-xsd-array-to-list/

Once you are satisfied that your newly generated code file is correct, simply copy it into the Teraluwide.Blackbird.DataTypes folder, overwriting the existing one. 

Never EVER edit the generated file by hand!

If you need to add runtime methods or properties to any new classes, make new class files for them in the project, remembering to declare them as partial classes. Also remember that any public members you add to them need to have the XmlIgnore attribute applied to them.