# Introduction 
This tool is to help in converting localization data of AD B2C from Excel/CSV to Xml

# Getting Started
The first part is currently implemented, ie, Excel/CSV to Xml file.  

# Build and Test  
The sample input excel (updated) is pushed along with the repo, please follow the same column names and format.  
Also, Do feel free to add more language columns to the end.  

### About Localized collections  and Localized strings

1. All rows meant for a Localized String should have the ResourceType column value as **LocalizedString**.  
    The columns TargetCollection and ItemValue can be left empty. 

2. A row should be present with valid column value for Resource, ElementType, ElementId, TargetCollection and ResourceType as **Collection** or **LocalizedCollections**  
    This row specifies **LocalizedCollections** node in xml.  
    The language specific columns, StringId, and ItemValue columns can be left empty.
3. The LocalizedCollection elements can be represented as follow up column with same resourceId and ElementId and ResourceType as **CollectionValues** or  **LocalizedCollection**  
    This row specifies **LocalizedCollection** node in xml. This row does not have to be immediately after the parent collection row.  
    The columns ElementType, TargetCollection, StringId can be left empty.