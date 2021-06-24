# Cộng đồng nhiếp ảnh di động
## Install
1. Open file MobilePhotographyCommunity.sln
2. Right click the project MobilePhotographyCommunity.Data, choose Set as StartUp Project
3. Change ConnectionString(data source and user) in 2 file App.Config in project MobilePhotographyCommunity.Data and Web.config in project MobilePhotographyCommunity.Web
```
<connectionStrings>
    <add name="MPCDbContext" connectionString="data source=DESKTOP-1KR28HP;initial catalog=MobilePhotographyCommunity;user id=sa;password=123456;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
</connectionStrings>
```
4. Choose Tools -> NuGet Package Manager -> Package Manager Console
5. Select Default Project become MobilePhotographyCommunity.Data
6. Type ``` Update-Database``` and press Enter
7. Press F5 to Run

## Pages

1. Login & Register
![login-register](https://user-images.githubusercontent.com/48479522/94520344-4dc2ff00-0256-11eb-87e4-ab320daf10df.png)
2. Home
![home](https://user-images.githubusercontent.com/48479522/123201698-67d7f800-d4dd-11eb-9d6e-82314ce68d80.png)
3. Category
![category](https://user-images.githubusercontent.com/48479522/123201700-69a1bb80-d4dd-11eb-81e2-7f492c9668b4.png)
4. User Profile
![profile](https://user-images.githubusercontent.com/48479522/123201704-6b6b7f00-d4dd-11eb-8340-03f1391f3c00.png)
