To create the L14_GoodFriends

NOTE: If you have already created and migrated to the Azure database, skip to step 7
1. Create a SQL database in Azure as described in the pdf Lesson13
2. Make sure the connection strings
        "SQLServer-goodfriendsefc-docker-sysadmin"
        "SQLServer-goodfriendsefc-docker-gstusr": 
        "SQLServer-goodfriendsefc-docker-usr": 
        "SQLServer-goodfriendsefc-docker-supusr":
   are all set to the same database connection string given by Azure     

3. Set "DbSetActiveIdx": 1 in appsettings.json DbContext project AND AppGoodFriendsWebApi 

4. From Azure Data Studio connect to the database
   Use connection string from user secrets:
   connection string corresponding to key
   "SQLServer-goodfriendsefc-docker-sysadmin"

5. With Terminal in folder .scripts 
   macOs run: ./database-rebuild-all.sh
   Windows run: .\database-rebuild-all.ps1
   Ensure no errors from build, migration or database update

6. Use Azure Data Studio to execute SQL script DbContext/SqlScripts/initDatabase.sql

-----------------

7. Create a Azure Key Vault as described in the pdf Lesson14

8. Open a terminal in folder .scripts and run ./azkv-update.sh
   Your key vault is now updated to the latest .NET user-secrets

9. Run AppGoodFriendsWebApi with or without debugger
   Without debugger: Open a Terminal in folder AppGoodFriendsWebApi run: 
   dotnet run -lp https 

   open url: https://localhost:7066/swagger

10. Use endpoint Admin/Info to verify secretSource. The response should read
{
  "appEnvironment": "Development",
  "dbConnection": "SQLServer-goodfriendsefc-azure-sysadmin",
  "secretSource": "Azure Keyvault secret: goodfriends"
}

11. Use endpoint Guest/LoginUser to login with below credentials
{
  "userNameOrEmail": "superuser1",
  "password": "superuser1"
}

12. The response from endpoint Guest/LoginUser includes an encryptedToken.
   Copy and paste the token (the string without "" - corresponding to <The token> below)
   "encryptedToken": "<The token>"
   into Swagger Authorize.  

13. Use endpoint Admin/Seed to seed the database, Admin/RemoveSeed to remove the seed
   Verify database seed with endpoint Guest/Info, 

14. All endpoints on Controllers Addresses, Friends, Pets, Quotes are executable for superuser1




