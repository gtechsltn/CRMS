# Customer Relationship Management System (CRMS)

+ .NET Framework 4.8
+ Visual Studio Enterprise 2022
+ SQL Server
+ SQL Server Management Studio (SSMS)
+ ASP.NET Web Application (C#)
+ ASP.NET MVC 5.2.9
+ AdminLTE 3.2.0
+ Bootstrap 4.6.0
+ jQuery 3.5.1
+ HTML, CSS, JavaScript
+ Google Font: Source Sans Pro
+ Font Awesome Free 5.15.4
+ DataTables 1.11.4

## GitHub
+ https://github.com/gtechsltn/CRMS/

## Google Drive
+ Master Plan: https://docs.google.com/spreadsheets/d/1Ndvh-Wn45emAR24H0duBj6JJZOoP3oUTsbyq4Be1qtY/

## AdminLTE v3.2.0
+ Download link
+ https://github.com/ColorlibHQ/AdminLTE/releases
+ Dependencies
+ https://adminlte.io/docs/3.2/dependencies.html
  + Bootstrap 4.6
  + jQuery 3.5.1
  + Popper.js 1.16.1

## Request features (TODO)
+ Favicon
+ CRUD

## DataTables
+ https://stackoverflow.com/questions/36684959/cannot-read-property-mdata-of-undefined-when-using-datatables-with-colspan

## Stored Procedure CRUD Generate
+ https://dev.to/peledzohar/t-sql-crud-procedures-auto-generator-1cl1
+ https://gist.github.com/gtechsltn/307aa55364a8813c8ae212e909bc237f

## SqlDataReader
+ https://www.akadia.com/services/dotnet_data_reader.html
+ https://dotnettutorials.net/lesson/ado-net-sqldatareader/
+ NULL column + DBNull.Value + SqlDataReader.IsDBNull(idx)
+ https://stackoverflow.com/questions/1772025/sql-data-reader-handling-null-column-values
+ https://makolyte.com/csharp-mapping-nullable-columns-with-sqldatareader/
+ https://gist.github.com/gtechsltn/cf946742191b1e90ef93468f8adbfb90

## DBNull
+ https://stackoverflow.com/questions/170186/set-a-database-value-to-null-with-a-sqlcommand-parameters
+ https://stackoverflow.com/questions/13981281/best-method-of-assigning-null-value-to-sqlparameter

## Hander Error
+ https://localhost:44368/Home/Delete
  + Đúng: https://localhost:44368/Home/Delete/1
  + Sai: https://localhost:44368/Home/Delete/0
  + Sai: https://localhost:44368/Home/Delete

+ https://localhost:44368/Home/Edit
  + Đúng: https://localhost:44368/Home/Edit/1
  + Sai: https://localhost:44368/Home/Delete/0
  + Sai: https://localhost:44368/Home/Delete

## ASP.NET MVC Razor with DateTime value
+ https://stackoverflow.com/questions/18288675/display-datetime-value-in-dd-mm-yyyy-format-in-asp-net-mvc

## Display Validation Summary in ASP.NET MVC
+ https://www.aspsnippets.com/Articles/Display-Validation-Summary-in-ASPNet-MVC.aspx
+ https://www.tutorialsteacher.com/mvc/htmlhelper-validationsummary
```
@Html.ValidationSummary(true, "", new { @class = "error" })
```
=>
```
@Html.ValidationSummary(false, "", new { @class = "error" })
```
+ https://stackoverflow.com/questions/12936604/how-to-add-modelstate-addmodelerror-message-when-model-item-is-not-binded