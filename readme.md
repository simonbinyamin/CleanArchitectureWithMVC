# Install the project for Windows

## Clone the the project 
```
git clone https://github.com/simonbinyamin/CleanArchitectureWithMVC.git
```

### Compiles and reloads for development
```
open mediatR.sln and select MVC as startup project in Visual studio
```

### other things you might need
```
sql server management studio
```

# Install the project for Linux

## Clone the the project 
```
git clone https://github.com/simonbinyamin/CleanArchitectureWithMVC.git
```
## Install .NET5 
##Install SQL Server Express

```
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
```

```
sudo add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/20.04/mssql-server-2019.list)"
```

```
sudo apt-get update
sudo apt-get install -y mssql-server
```

```
sudo /opt/mssql/bin/mssql-conf setup
```
```
systemctl status mssql-server --no-pager
```