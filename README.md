
🎂 🍰 🍪 
**Pierre' Bakery**



A C# MVC application for a bakery with user authentication and many to many database relationships.8/16/19. 
*By Maryana Antonyuk*

**Description**

C# MVC application with user authentication and a many-to-many relationship. Here are the features  in the application:

1. The application should have user authentication. A user should be able to log in and log out. Only logged in users should have create, update and delete functionality. All users should be able to have read functionality.
2. Many-to-many relationship between Treats and Flavors. A treat can have many flavors (such as sweet, savory, spicy, or creamy) and a flavor can have many treats. For instance, the "sweet" flavor could include chocolate croissants, cheesecake, and so on.
3. A user should be able to navigate to a splash page that lists all treats and flavors. Users should be able to click on an individual treat or flavor to see all the treats/flavors that belong to it.
![Screenshot](bakery.png)


****Setup/Installation****

**Requirements**

To run this program, you have to have IDE, ex VisualStudio (I used Rider(JetBrainer)) or Terminal.



1. Clone this repository:

2.Open the App Settings file (appsettings.json) and ensure that the MySQL username and password match your MySQL credentials.

3.Log onto MySQL:

$ mysql -u USERNAME -p PASSWORD
4.Navigate to the production folder 

5.Restore dependencies, update your local database, and run the application

$ dotnet restore
$ dotnet ef database update
$ dotnet run
6.On a Web browser (Chrome recommended), navigate to http://localhost:5000


You will have access to all files. Enjoy!

**Known Bugs**

No known bugs.

**Technologies Used**
C#
.NET

**Support and contact details.**

Email me amaryana@gmail.com with any questions, comments, or concerns.

**License**

This software is licensed under the MIT license.

_Copyright (c) 2019 Maryana Antonyuk_
