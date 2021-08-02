# Introduction 
This tool is to help in converting localization data of AD B2C from Excel/CSV to XML/JSON and Vice versa

# Getting Started  
Currenty there are 4 different parts to this tool  
1. Conversion of Excel/CSV file to Xml file.  
2. Conversion of Xml file to CSV file.  
3. Conversion of Excel/CSV to JSON files.  
4. Conversion of JSON files to CSV file.  **(Not implemented)**  

# Common 


### About Localized collections  and Localized strings

* All rows meant for a Localized String should have the ResourceType column value as **LocalizedString**.  
    The columns TargetCollection and ItemValue can be left empty. 

* A row should be present with valid column value for Resource, ElementType, ElementId, TargetCollection and ResourceType as **Collection**
    This row specifies **LocalizedCollection** node in xml.  
    The language specific columns, StringId, and ItemValue columns can be left empty.
* The LocalizedCollection elements can be represented as follow up column with same resourceId, ElementId, TargetCollection and ResourceType as **CollectionValues**
    This row specifies **LocalizedCollection:Item** node in xml. This row does not have to be immediately after the parent collection row.  
    The columns ElementType and StringId can be left empty.  

### Outputs

* The output folder is always optional, if not provided, the ouptut files will be saved in the input folder. 

# 1. Conversion of Excel/CSV file to Xml file.  
* The sample input file can be found in "Sample Input Files/1_ExcelToXML.xlsx".  
* Please follow the same column names and format.  
* For adding a new language, add an extra column to the end. 
* Currently the languages should start at column number 8 and otherwise could run it to issues.
* To do -> Move the column schema to configurations to allow flexibility.


# 2. Conversion of Xml to CSV 
* The xml file should have Localization node as the root element.  

# 3. Conversion of Excel/CSV to JSON  
* The sample input file can be found in "Sample Input Files/1_ExcelToXML.xlsx".  
* **The localized collections are not converted to json files now**.  
* There should always be a default language value column in the excel along with the modified column.  
* This schema should be mapped in **ToJson section of appsettings.json**. The index refers to the column number with starting index 1.  
* If the value of modified column is empty or same as default value, the default value is to be used, but right now inorder make output files smaller, it will not be written to the json file.  
  If the value of modified column is different from default value, then it will be written to JSON file with override flag as true.  
  This behaviour can be overridden by changing the configuration ToJson:WriteOnlyModifiedValues to false.
* The Output file prefix text box refers to prefix to be added to the file. The default value can be overriden in appsettings.  
  eg: "DefaultLocalizedResources_tenant.onmicrosoft.com". Name of the ouput files would be in the format <prefix>_<resource>_<languagecode>.json  
* **Bonus** : If you would like to work without default columns, use the ToJsonWithoutSeperateColumns section from configurations in appsettings.json. Also update program.cs to use this section.  
  The output json would have override as false though.
* To do -> Move the configuration to a seperate file and allow more flexibility.  
* To do -> Improve to allow LocalizedCollections.  


# 4. Conversion of JSON files to CSV file.  
* Select multiple JSON files and get outputs in csv format.  
* The JSON file name is considered for getting resource and langauge code. Hence it **should be in the format <prefix>_<resource>_<languagecode>.json**.  
* **The localized collections are not converted from json files now**.
* To do -> Improve to allow LocalizedCollections.
* to do -> Have configuration to allow more flexibility.


#####Common To do
1. A lot of code refactor, Not efficient now.   
2. Asynchronous.  
3. Better logging : file/csv files.  
4. Proper error handling.  
