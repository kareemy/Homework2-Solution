## Your Name: Kareem Dana - Homework 2 Solution

# CIDM 3312 Homework 2 - Entity Framework Core Part 1
Create a C# app using Entity Framework Core that will store patient records for the West Texas
Sanatorium. Your app should meet the following requirements:

1. Start by cloning this assignment repository into VS Code.
2. The app should be a console app with Entity Framework Core using a SQLite database.
3. Create a model to store the patient’s first name, last name, age, gender, admittance date, and whether or not they have had an examination with the doctor. Use the appropriate data types.
4. User should be able to **add** a new patient along with all the information from step 2 to the database. Put this functionality in a separate method that you call.
5. User should be able to **list** all patients. This should print out every patient and their information to the console. Use a separate method.
6. User should be able to **update** a patient record and change any of their information from step 2. Use a separate method.
7. User should be able to **remove** a patient from the database. Use a separate method.
8. You do not need to validate user input...yet.
9. The following patient records should already be stored in the database at the start:

  | First Name  | Last Name   | Age | Gender | Admit Date | Had Exam? |
  | ----------- | ----------- | --- | ------ | ---------- | --------- |
  | Roxie       | Hart        | 34  | F      | 5/28/1924  | Y         |
  | Grace       | Bertrand    | 24  | F      | 1/15/1939  | Y         |
  | Harold      | Hill        | 52  | M      | 7/1/1943   | N         |
  | Herman      | Dietrich    | 47  | M      | 9/12/1936  | Y         |

10. Please remember to comment your code. Add small, one line comments explaining each task. Add more detailed comments to highlight new things you learned and challenges you encountered and how you overcame them.

## Useful Entity Framework Core Tutorials
- https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite
- https://docs.microsoft.com/en-us/ef/core/saving/basic

We will create the database with `db.Database.EnsureCreated()` instead of migrations. Migrations will be introduced later.

## Submit your assignment
1. Save your program and run it. At the terminal prompt, type `dotnet run`.
2. Edit `README.md` and put your name at the top.
3. Push your changes to GitHub:
    - Click the source control icon in VS Code
    - Type in a commit message
    - Click the checkbox icon to commit. (Click yes on the message box to stage your commit)
    - Click the 3 dots icon (...) for more actions and click Push.
4. Or you can push your changes to GitHub using the Terminal:
    ```
    git add -A
    git commit -m "Your commit message"
    git push
    git status
    ```
4. Verify that your changes are on GitHub.
6. Congratulations! Your assignment is complete.