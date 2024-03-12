# CCS - Backend

Esse repositório contém o código para a API/*backend* da integração com o CCS da B3, desenvolvido com [.NETCore](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-2.2). 

# Visão Geral

Esse projeto tem como objetivo fornecer um suporte para inclusão de informações para posterior integração com o CCS, ferramenta de informação de relacionamento de clientes com Instituições Financeiras, desenvolvido pela B3.

## Requisitos

Para utilização e desenvolvimento desse projeto os seguintes requisitos são obrigatórios: 

- [Git](https://git-scm.com/) 
- [.NET Core 6.0 SDK](https://dotnet.microsoft.com/)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/vs/), [Visual Studio Code](https://code.visualstudio.com/) ou outro editor com suporte ao C# e .Net Core. 
- Postman ou Insominia para testar as requisições

## Estrutura

O projeto encontra-se estruturado da seguinte forma: 

```bash
├── src                     # Arquivos gerais que compõem o projeto/solução
│   ├── Application         # Projeto principal responsável por inicializar a API
│   ├── Domain              # Entidades e classes de domínio do projeto
│   └── Infrastructure      # Classes de infraestrutura para acessos à Banco de Dados, etc
├── test                    # Arquivos para testes do projeto  
│   └── UnitTests           # Projeto de testes unitários
└── ...                     # Demais arquivos de configuração do projeto (README.md, arquivos de solução, etc)
```

## Configuração Git (para contribuição no projeto)

Após clonar o projeto, configure seu usuário de git local para identificação das atualizações no repositório. Execute os comandos abaixo usando seus dados de acesso ao repositório:

```bash
git config --local user.name "<Nome Usuario>"
git config --local user.email "<Email>"
```

Dessa forma, as alterações enviadas para o repositório terão a marcação do seu usuário no *log* de commit. 

# Inicialização e Execução

## Configuração inicial / Instalação

### 1. Obter última versão do projeto

Você pode começar clonando a última versão do projeto na sua máquina local executando o comando: 

```shell
$ git clone -o j2tsoftware/backend -b main --single-branch \
      https://github.com/j2tsoftware/backend.git backend
$ cd backend
```

### 2. Compilar e executar

Se estiver usando Windows com a IDE do Visual Studio, simplesmente importe o projeto através do arquivo de solução (*ApiBase.sln*). As propriedades de execução da solução presentes em *Properties -> launchSettings.json* serão carregadas e habilitadas automaticamente. Escolha um dos perfis e clique no ícone para excutar o projeto. 

Caso esteja usando o Linux ou prefira executar via linha de comando, digite: 

```bash
dotnet run
```

Para o modo *watch* (semelhante a um *live reload*), digite: 

```bash
dotnet watch run
```
## Bancos de Dados - Migrations

Para atualização do banco de dados do projeto, devem ser utilizados os mecanismos de 
[Migrations](https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli) do .Net Core

Por padrão, o projeto é configurado para acessar uma base de dados local usando SQL Server; contudo, para manter
essa base ou de outros ambientes, é necessário executar comandos de criação e atualização de migrations. A estrutura configurada
encontra-se no projeto "Infrastructure". Todos os comandos devem ser executados na pasta desse projeto. Antes de executar os comandos, 
digite: 

```bash
cd src/lib/Infrastructure
```

A seguir, listamos os comandos mais utilizados: 

### Criação de migrations

```bash
dotnet ef migrations add [NomeMigrations] -o DataSources/Database/Migrations
```
O parâmetro -o deve ser usado para criar os arquivos na pasta especificada. 

### Atualização da base a partir do snapshot de contexto

```bash
dotnet ef database update
```