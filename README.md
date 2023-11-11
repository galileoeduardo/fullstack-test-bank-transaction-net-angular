# fullstack-test-bank-transaction-net-angular
Criar uma tela de extrato de conta corrente, onde eu possa listar os lançamentos da conta corrente feitos de forma avulsa ou não. Além disso, que eu também possa nessa tela, inserir, alterar, e cancelar lançamento avulsos válidos.

Install Requirements:

.NET Runtime 7.0

## How to run project:
Download project and run:
```bash
git clone https://github.com/galileoeduardo/fullstack-test-bank-transaction-net-angular.git
cd .\fullstack-test-bank-transaction-net-angular\
dotnet run --project Bank
```
Run tests:
```bash
dotnet test Bank
```

API endpoints:
Swagger:
http://localhost:5000/swagger/index.html

## API Request

`POST 'http://localhost:5000/api/Files`

`GET 'http://localhost:5000/api/Users/?q=`

## This is only setup development enviroment, don't need this for run project

Install Requirements:

.NET SDK 7.0

Entity Framework Core .NET Command-line Tools 7.0.13


If you have already installed entity framework, update to latest version:
```bash
dotnet tool update --global dotnet-ef
```

Migrations only work's in Application folder "\Api"

Run migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Reset migrations:
```bash
dotnet ef database drop
dotnet ef migrations remove
```
