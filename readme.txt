ADVANCED ADVANCED FIND


INTRODUCTION:
---------------------------------
A find dialog that allows OR based searches.


REQUIREMENTS:
---------------------------------
- Vault Workgroup/Professional 2017 


TO USE:
---------------------------------
Run the install and start Vault Explorer.  There will be a new command titled "Advanced Advanced Find" under the Tools menu.  Run the command to launch the "Advanced Advanced Find" dialog.

Start out by selecting which thing you want to search for.  "File" and "Folder" are the only options for Vault Workgroup.  "Item", "Change Order" and "Custom Object" options are available in Vault Professional.

Next set up the search conditions in the same way as the Advanced tab in the regular Find dialog.  The only thing new is the Rule option.  A "Must" rule is the default behavior, it results in AND behavior for the search condition.  A "May" rule results in OR behavior for the search condition.  

Once you have all your criteria, run the "Find Now" command to see the results.

Results can be saved and loaded.  

Double-clicking on a result object will close the dialog and cause Vault Explorer to navigate to that object.


NOTES:
---------------------------------
- A single May conidtion will be ignored.  There needs to be at least 2 May conditions to get OR behavior.
- The order of the search conditions does not matter.  The server will group all May coniditions together with OR behavior.  That result will then be grouped with all Must statements with AND behavior. 


RELEASE NOTES:
---------------------------------
5.0.1.0 - Update for Vault 2017.  Corrected references to 2017 versions and upgraded .NET version to 4.6

4.0.1.0 - Update for Vault 2014.  Added Save and Load buttons.  Results display in a Vault Grid control.  Double-clicking on a result navigates Vault Explorer to that object.

3.0.1.0 - Update for Vault 2013.  Added support for Folder and Custom Object searches.

1.0.1.0 - Initial Release