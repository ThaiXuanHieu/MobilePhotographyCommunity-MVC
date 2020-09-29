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
![home](https://user-images.githubusercontent.com/48479522/94520391-66331980-0256-11eb-853c-8b3297ad6b8a.png)
3. Category
![category](https://user-images.githubusercontent.com/48479522/94520395-68957380-0256-11eb-8a3e-226a6407fccb.png)
4. Challenge
![challenge](https://user-images.githubusercontent.com/48479522/94520403-6af7cd80-0256-11eb-9e08-2d5d3debcae4.png)
5. User Profile
![user-profile](https://user-images.githubusercontent.com/48479522/94520406-6cc19100-0256-11eb-8488-2074a55de09a.png)
