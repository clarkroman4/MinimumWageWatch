# MinimumWageWatch

Final Project for Launchcode

Overview

The project is a minimum wage tracking application for multi-site businesses. 
It allows the user to enter a single location via a webform or multiple locations via a CSV file upload (with the idea that a new 
business user would need to add all locations upon initially using the app, then add/edit/delete single locations to maintain an 
up-to-date list of locations). A separate class of authorized users (minimum wage SMEs) will be able to add minimum wage data. The
result will be a table of locations with their respective minimum wages. The application will take into account the precedent of 
jurisdictional minimum wages when displaying locations and minimum wages. Users will be able to sort and search the locations based on
city, county, state, or minimum wage. This project solves a very-real business problems for users. 
When I was a compliance analyst as Panera, we tracked the minimum wages of all locations via manual websearch and an 
Excel spreadsheet, so this provides a more sophisticated solution. My MVP/proof of concept will be isolated to California, 
as California alone has 24 city-specific minimum wages, 1 county-specific minimum wage, and a statewide minimum wage.

Features

User Creation/User Login: A user is able to create a new profile as either a Administrator 
(with location writing and minimum wage writing abilities) or a general user (with just location writing abilities). A
fter creating a user profile, a user can leave the site and login with the correct privileges.

CRUD for minimum wage - into a database with distinctions for federal, state, city and county wages.

CRUD for location - into a database with ability to edit individual locations.

CSV file upload for batch upload of locations.

Technologies

C# with ASP.NET framework; possibly Javascript for front-end manipulation


What I'll Have to Learn

AuthorizeAttributes, Routing in C#, CSV file uploads, CSV file generation

Wireframe Links:

https://drive.google.com/file/d/1p9Nb-6E40ACeLfZkZvnHVfr7nFheUIQ6/view?usp=sharing

https://drive.google.com/file/d/1rpMBjtp3ipmgk0bvVca_dM_k0CvOIP2Q/view?usp=sharing

Project Tracker

https://trello.com/b/XNtMIqmC/capstone-projectpub
