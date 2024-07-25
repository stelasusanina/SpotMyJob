# SpotMyJob
SpotMyJob is a job listing platform built with **ASP.NET Core** for the backend API and **React** for the frontend. The application allows users to search for job offers, apply to jobs. It also includes roles (admin and user), so that admins can manage job applications.
## Features
- **User Registration and Authentication:** Sign-up and login functionality with cookie-based authentication.
- **Job Offers:** Browse, filter and order job offers based on categories, locations, job titles and other criteria.
- **Job Applications:** Apply to job offers and track application status.
- **Admin Dashboard:** Add or delete job offers and manage application status for every job application.
- **Profile Management:** Update user profile picture.
## Installation
### Backend
1. Clone the repository.
2. Start Visual Studio and open your solution.
3. Open Package Manager Console: Go to Tools > NuGet Package Manager > Package Manager Console.
4. In the Package Manager Console, you can run the `Restore` command to restore all NuGet packages.
5. Update the connection string in appsettings.json to point to your SQL Server instance: `"DefaultConnection": "Server=your_server;Database=your_db;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false"`.
6. Apply migrations in Package Manager Console with `Update-Database`.
7. Run

### Frontend
1. Navigate to the SpotMyJobApp.Client directory: `cd SpotMyJobApp.Client`.
2. Install dependencies: `npm install`.
3. Start the React development server: `npm start`.

## Built with
- ASP.NET Core 8.0 
- Entity Framework
- ASP.NET Core Identity
- Cookie Authentication
- React.js
- MSSQL Server
- Axios
- Toastify
- Formik

## Database Seed with Initial Users
- Admin (admin@admin.com / aA123...)
- User (stela1234@gmail.com / sS123...)

## Screenshots
![Home](https://github.com/user-attachments/assets/a87f8396-33ef-473b-a336-12d4934a63e2)

![All job offers](https://github.com/user-attachments/assets/78b9d615-55a7-43da-b635-7ded6ffdc5d7)

![My profile](https://github.com/user-attachments/assets/7d7fa983-e4a4-4ab4-b429-c6f5cff3206f)

![Single job offer](https://github.com/user-attachments/assets/45b697a8-bf49-475b-a90f-bf615e3895f0)

![Admin (all applications)](https://github.com/user-attachments/assets/45721afa-0259-4ba7-a2dd-08bf1352621b)

![Admin (manage status)](https://github.com/user-attachments/assets/752e9b8c-d2d1-46a5-8ec6-dc1b74cb816a)
