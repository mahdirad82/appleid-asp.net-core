# Installation Guide  

Follow these steps to set up the Apple ID Management System on your local machine:  

### Prerequisites  

Before you begin, ensure you have the following installed on your machine:  

- [.NET 8 SDK](https://dotnet.microsoft.com/download) (latest version)  
- [MySQL](https://dev.mysql.com/downloads/) (Community edition is fine)  
- [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) (optional, for database management)  
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.microsoft.com/)  

### Installation Steps  

1. **Clone the repository:**  

   Open your terminal and run the following command:  
   ```bash  
   git clone https://github.com/mahdirad82/appleid-asp.net-core.git  
   cd appleid-asp.net-core
   ```
   
2. **Restore dependencies**  

  Run the following command to restore the required packages:  

  ```bash  
    dotnet restore
  ```
3. **Create the database**  

  Use Entity Framework migrations to create the database:  

  ```bash  
    dotnet ef database update
  ```  
4. **Run the application**

  Start the application by running:  

  ```bash  
    dotnet run
  ```
  Open a web browser and navigate to `http://localhost:5000` or whatever port the application is running on.  
