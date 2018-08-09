# LUSSISADTeam10Web
## 1) Installation Guide
### Configuration for Web API and Web Application
1. Restore the database (.bak) file that is located inside "Databack Backup" folder in the project solution directory. Directory (\Web API and Web APP Source Code\LUSSISADTeam10Web\Database Backup)
2. Restore the stored procedures (SPItemTrendAnalysis and SPItemUsageReport) if there are none.
3. Open LUSSISADTeam10Web solution with Visual Studio and check "connectionString" is pointing to the local database server and database inside Web.config "LUSSISADTeam10API" project.
    Use SQL Authentication to fill user id and password of the sql server (To change password of SQL server, open SQL server, go to Security > Logins > double click on 'sa', then change password.
    Fill the user id as 'sa' and then the password you set in the Web.Config of API project as follow.
    e.g.      <add name="LUSSISEntities" connectionString="metadata=res://*/Models.DBModels.LUSSISEntities.csdl|res://*/Models.DBModels.LUSSISEntities.ssdl|res://*/Models.DBModels.LUSSISEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=SA46ADTeam10;user id=sa;password=as ;multipleactiveresultsets=True;application name=EntityFramework&quot;" providerName="System.Data.EntityClient" />
4. Right click on "LUSSISADTeam10Web" and select "Multiple Startup Projects: " and choose both projects to "Start".
5. Check "apiURL" is pointing to "http://localhost:50720/api" or change whatever port the Web API project is running on. e.g. " <add key="apiURL" value="http://localhost:50720/api" />"
6. If you want to publish the solution, make sure that apiURL is pointing to the published URL of the API.

### Configuration for Android
1. Open the android source code with android studio and go to Constant.java located under "com.nusiss.team10ad.LogicUniversity.Util" package. 
2. Change WEB_VER_URL to "http://localhost:50715/" or change whatever port the Web Application is running on.  
3. Change API_BASE_URL to "http://ip_address/api", ip_address will be the IP address of the server which is running the API project.
4. Compile the solution and run it on the device or emulator.






## 2) Username and Password

- Android and Web Application share the same API. So, they have the same access.

Android Application can provide functionalities for "Clerk", "Department Representative", "Department Employee", "Temporary HOD" and "Head of Department".
But there is no access for "Supervisor" and "Manager".

Web Application can provide all functionalities for all users.

### Password

All Passwords are "password". All passwords in the database are encrypted.

### Usernames

#### Stationery Store
 - Clerk - clerk
 - Supervisor - supervisor
 - Manager - manager

#### Computer Science Department
 - Head of Department - joffery
 - Department Representative - charles
 - Employee - louis

#### Commerce Department
 - Head of Department - drogo
 - Department Representative - thomas
 - Employee - snow


## 3) System Requirements
### Tools 
- Visual Studio
- MSSQL Server
- IIS Server
- Recommended Browser : Google Chrome


## 4) Authors
- Aung Myo
- Chit Su Shine
- Htet Wai Yan
- Hsu Yee Phyo
- Khaing Myat Kyaw Soe
- Khin Yadana Phyo
- Thet Aung Zaw
- Wint Yadanar Htet
- Zin Min Htet

