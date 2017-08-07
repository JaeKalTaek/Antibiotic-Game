To update the database, follow this guide :

1. Open the "Database.xlsx" file

/!\ Never modify the third sheet : "Formulas (don't touch)". /!\
/!\ Don't modify any formula in the second sheet : "Excel to xml", just copy and paste lines /!\

2. Update the database in the "Main excel" sheet.
   Be sure to respect the format. Each cell must be filled, use "X" if the info is not possible.
   
3. In the second sheet : "Excel to xml", scroll down and make sure the last line has an Antibiotic value of "0".
   If not, copy any line and paste it in the last lines until there is one with an Antibiotic value of "0".
   (Make sure there is no empty line except at the bottom of the document)

4. In the "Développeur" tab of Excel, click on "Export" and save the file in the AntibioticGameApp/Assets/Resources folder, replacing the old Database.xml file.