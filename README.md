# SpotMyJob
SpotMyJob is a job listing platform built with **ASP.NET Core** for the backend API and **React** for the frontend. The application allows users to search for job offers, apply to jobs. It also includes roles (admin and user), so that admins can manage job applications.
## Features
- **User Registration and Authentication:** Sign-up and login functionality with cookie-based authentication..
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
