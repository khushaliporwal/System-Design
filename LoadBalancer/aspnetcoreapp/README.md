How to setup Load Balancer using Nginx:

 
 1. Create Backend server
  -  We will create .Net core app and run on multiple ports
  - Steps:
	- dotnet new webapp --output aspnetcoreapp --no-https
	- cd aspnetcoreapp
	- dotnet run
2. Install Nginx 
- Download Nginx
- Copy files to c:\Nginx
- Run Nginx -t to check any errors
- Check error using file C:\Ngnix\Logs\errors.logs
- Configure Nginx.Conf file
- To restart Nginx 
- nginx -s reload
	
3. Start all the servers
- dotnet run --urls "http://localhost:5000;http://localhost:5062;http://localhost:5064" (change the port as required)

4. Send request from original port configured in Nginx.conf file
Result : Request will be served by different servers (Algo configured in Nginx load balancer)

![image](https://github.com/khushaliporwal/System-Design/assets/25275660/bba3d473-478c-41b1-ab6d-cd727b41fe21)

