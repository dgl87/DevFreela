## Protocolo HTTP
- Protocolo base para a comunicação de dados na internet, permitindo obter recursos como páginas HTML.
- Quando desenvolvemos uma API, permitindo o acesso aos seus recursos geralmente através do protocolo HTTP.
Os cabeçalhos de requisição HTTP, tanto de envio quanto de respostas, permitem o envio de informações extras.
Os cabeçalhos mais comuns são:
- Content-Length
- Content-Type
- Cache-Control
- Status

Os Status HTTP são códigos de respostas relacionados ao status de conclusão de uma requisição. Os status mais comuns são:
```diff
+ 200 ok	
+ 201 Created
+ 202 Accepted
+ 204 No Content
  400 Bad Request
  401 Unauthorized
  404 Not Found
- 500 Internal Server Error
```
Os métodos (verbos) HTTP representam ações para um dado recurso, mais comuns são:
- **GET :** uma consulta, ou ação que não altera o estado do sistema, geralmente retorna status 200.
- **POST :** criação de recursos, retornando status 201 ou 400.
- **PUT :** atualização de recurso, retornando status 204, 400 ou 404.
- **DELETE :** remoção de um recurso, retornando 204 ou 404

## O que é uma API REST?
- **REST**, abreviatura de **Representational State Transfer**, é um padrão de comunicação entre sistemas, geralmente utilizado junto ao protocolo HTTP.
- Baseado em recursos, que são representados em um caminho de acesso em uma URL.

Exemplos de URL’s seguindo o padrão REST para acesso de recursos:
- api/users/1 - GET, PUT, DELETE
- api/projects - GET, POST
- api/skills - GET, POST
- api/users/1/projects - GET, POST

## Introdução ao ASP.NET CORE
- Framework open-source, multiplataforma, leve, e de alta performance para a construção de aplicações Web modernas, prontas para a nuvem.
- Lançado em junho de 2016, e desde então tem se tornado a principal opção para desenvolvimento de projetos na plataforma .NET.
- Contém um sistema de configuração baseado em ambientes, facilitando o seu uso em plataforma de nuvem.
- Possui recurso de injeção de dependência nativo, sem a necessidade de se utilizar bibliotecas como o Ninject.

## Criando o Projeto DevFreela

### No terminal
lista as opções de template
```shell
dotnet new 
```

cria solution
```shell
dotnet new sln --name DevFreela
```

cria projeto
```shell
 dotnet new webapi --name DevFreela.API --output DevFreela.API
```

adicionar a referência do projeto para a solution
```shell
dotnet sln add ./DevFreela.API/DevFreela.API.csproj 
```

build’a projeto
```shell
dotnet build
```

restaura pacotes
```shell
dotnet restore
```

executa aplicação
```shell
dotnet run
```

## Controllers e Actions
### Controllers
São componentes que definem e agrupam um conjunto de ações (Actions)
Agrupam ações de maneira lógica, baseado no recurso a ser tratado e/ou acessado
Um Controller em uma API ASP.NET Core é uma classe que herda de ControllerBase
Uma informação importante para uma Controller é a rota base para ela, já que isso influenciará na rota de todos pontos de acesso desse Controller. Ela pode ser definida pela anotação Route

### Actions
São métodos contidos em uma classe Controller, e representam pontos de acesso em uma API
Para API’s, o tipo de retorno de uma Action geralmente é IActionResult, que é uma interface implementada pelas respostas padrão do HTTP, como o Ok, Not Found, entre outras.

## Utilizando o Swagger
- Ferramenta que simplifica o desenvolvimento de API’s, permitindo, entre outras funcionalidades, a documentar e testar API’s
- Ele consegue gerar uma interface gráfica contendo todos os pontos de acesso (endpoints) da API, permitindo realizar requisições diretamente em sua interface

## Aprofundando em Actions
O ASP.NET Core é bem flexível a respeito de definição de Actions e Rotas, além de recepção de parâmetros. Para uma requisição GET, por exemplo, geralmente você vai receber:
- Parâmetro de URL
- Query String

Já no caso de requisição POST e PUT, geralmente vão ser recebidos parâmetros através de:
- Parâmetro de URL
- Corpo da requisição

Finalmente, as requisições DELETE geralmente apenas recebem parâmetros de URL

```c# 
using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
 
namespace DevFreela.API.Controllers
{
   [Route("api/projects")]
   public class ProjectsController : ControllerBase
   {
       //api/projects?query=net core
       [HttpGet]
       public IActionResult Get(string query)
       {
           //Busca todos ou filtrar
           return Ok();
       }
       //api/projects/{id}
       [HttpGet("{id}")]
       public IActionResult GetById(int id)
       {
           //Busca o projeto
           //return NotFound();
           return Ok();
       }
       //api/projects
       [HttpPost]
       public IActionResult Post([FromBody] CreateProjectModel createProjectModel)
       {
           if (createProjectModel.Title.Length < 9)
           {
               return BadRequest();
           }
           return CreatedAtAction(nameof(GetById), new { id = createProjectModel.Id }, createProjectModel);
       }
       //api/projects/{id}
       [HttpPut("{id}")]
       public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProjectModel)
       {
           if (updateProjectModel.Description.Length < 10)
           {
               return BadRequest();
           }
           //Atualizo o objeto
           return NoContent();
       }
       //api/projects/{id}
       [HttpDelete("{id}")]
       public IActionResult Delete(int id)
       {
           //return NotFound() se não existir
           //Remove
           return NoContent();
       }
   }
}
```
 
## Configurações
O ASP.NET Core permite carregar configurações de aplicação de uma série de fontes, através da interface IConfiguration, como:
- Arquivos de configuração, como o appsettings.json;
- Variáveis de Ambiente;
- Argumentos de linha de comando;
- Da nuvem Azure, como configurações de Aplicativo, e pelo Azure Key Vault.

No caso de arquivo de configuração, é possível carregar diferentes versões dele, dependendo do ambiente que é definido pela variável de ambiente ASPNETCORE_ENVIRONMENT, por exemplo:
- appsettings.Development.json;
- appsettings.Staging.json;
- appsettings.Production.json

- Uma ótima maneira de obter configurações é usar o padrão Option. 
- Já no caso de linha de comando, basta passar como simples parâmetros, como em dotnet run nome=Luis e utilizar o código Configuration.GetValue,T.(“nome_parametro”)

## Injeção de Dependência
Técnica que permite a inserção de um objeto em outro, geralmente através do construtor, criando a relação de dependência.

O método que utilizamos para adicionar configurações para o Controller é um exemplo de injeção de Dependência.

Técnica muito utilizada para melhorar a qualidade de código em refatoração, e torná-lo testável.

Cada um deles define o ciclo de vida do objeto
  - **Singleton:** uma instância por aplicação
  - **Scoped:** uma instância por requisição
  - **Transient:** uma instância por classe

## O que é uma arquitetura?
Arquitetura é a organização fundamental de um sistema, incluindo seus componentes, o relacionamento entre eles, o ambiente e os princípios em que se baseia sua construção
Geralmente representados com a descrição de uma estrutura, se utilizando também de um diagrama ou desenho
Divididas em arquiteturas distribuídas e monolíticas
Distribuídas: componentes do sistema que estão sendo executados em outros processos, geralmente em outros servidores
Monolíticas: componentes do sistema executam no mesmo processo, na mesma máquina

## Arquitetura Limpa
Também conhecida como Onion Architecture, ou Arquitetura Cebola é uma arquitetura amplamente utilizada no mercado .NET.
Tem como foco o domínio do sistema, tendo em sua essência o Domain-Driven Design.
Tem diversas variações, mas sempre tem a mesma estrutura base.

Sua estrutura é dividida em 4 camadas principais, sendo elas:
- Core (Também chamada de Domain)
- Infrastructure
- Application
- API / Interface


## Inversão de Dependência e Interfaces
### Inversão de Dependência
Princípio SOLID, referente ao Dependency Inversion
Módulo de alto nível não devem depender de módulos de baixo nível. Ambos devem depender de abstrações.
Abstrações não devem depender de detalhes. Detalhes devem depender de abstrações

```c#
public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;
        private readonly ExampleClass _exampleClass;
        public ProjectsController(IOptions<OpeningTimeOption> option, ExampleClass exampleClass)
        {
            exampleClass.Name = "Update at ProjectController";
            _option = option.Value;
        }
```

## Inversão de Dependência
Para resolver problema, as classes devem depender de interfaces, que são abstrações que representam contratos
Com isso, atendemos a ambos os itens do princípios SOLID
Também conseguimos melhorar a testabilidade da classe, pois ao escrever um teste unitário, poderemos alterar o comportamento das dependências

## Camada Core
Camada mais importante da Arquitetura Limpa. É nela onde o foco de desenvolvimento inicial deve estar
O Domain-Driven Design está bem caracterizado nos conceitos dessa arquitetura, por pregar a importância de se entender bem o domínio, as regras de negócio contidas nele, bem como o linguajar utilizado pelos diferentes usuários (linguagem ubíqua)

Alguns conceitos de Domain-Driven Design que utilizaremos
- Agregados: padrão que representa um conjunto de objetos do domínio que podem ser tratados como um só
- Repositórios: abstrações que representam acesso a objetos de domínio
- Linguagem Ubíqua: modelo de linguagem universal para comunicação entre desenvolvedores e analistas de negócios

**Contém os seguintes componentes:**
- **Entidades:** classes de domínio, que representam as entidades que foram modeladas a nível macro do módulo 2. Alguns exemplos são Project e User.
- **Enums:** tipo de enumeração do C#, sendo definido um conjunto de constantes nomeadas (geralmente números inteiros). Em nosso caso, usaremos para status de projeto, de usuário e de freelancer.
- **Data Access Objects (DTO):** objetos de transporte de dados, geralmente utilizados em retorno de serviços de infra-estrutura (integração com outro sistema, por exemplo), consultas com projeção de dados diferenciadas (com Dapper, por exemplo). Usaremos para o segundo exemplo.
- **Serviços de camada de domínio:** quando uma operação do domínio envolve múltiplas classes ou estados, extrapolando responsabilidades um serviço de cada de domínio é indicado. Usaremos para validação de início de projeto.
- **Interfaces (de serviços de infra-estrutura, domínio, repositórios):** utilizadas em diferentes camadas, como API, Aplicação e Infraestrutura.
- **Exceções de domínio:** exceções específicas a cenários de problema no fluxo de negócio. Elas serão tratadas via filtro de ASP.NET Core, que tratará as exceções de maneira automática. Um exemplo delas seria o de ProjectAlreadyStartedException, que indicaria uma ação de início de projeto que já foi inicializado.

## Camada Infrastructure
- Camada responsável por código de infraestrutura, como acesso a dados, conexão com serviços de computação na nuvem, integração entre sistemas, entre outros.
- Cada um desses sub-itens pode ser dividido em projetos próprios, como Persistence, Integration e CloudService

**Contém os seguintes componentes:**
- **Acesso a dados:** classes responsáveis pelo acesso a dados. No Entity Framework Core, corresponde ao contexto de dados (com DbContext) e implementação de repositórios de dados.
- **Serviços de infraestrutura:** classes responsáveis por acesso a recursos na nuvem (armazenamento de arquivos, mensageria, entre outros), integração com outros sistemas (legados, ERP, APIs de consulta, ou mesmo outras APIs da empresa), entre outros.

## Camada Application 
- Camada responsável por código de aplicação, onde as funcionalidades expostas vão estar, em forma de serviços (ou Commands e Queries, dependendo do padrão utilizado)
- Também contém os modelos de entrada e saída da aplicação, que serão utilizados diretamente na API (seja no retorno da API, ou no corpo da requisição)

**Contém os seguintes componentes:**
- **Serviços:** classes responsáveis pelas funcionalidades expostas, geralmente sendo criado um por cada entidade. Em nosso caso, pode ser criado alguns como ProjectService e UserService
- **Modelos de entrada e saída:** classes, que podem ser consideradas DTOs, responsáveis por definir as propriedades de objetos de entrada e saída dos endpoints / funcionalidades

## Camada API
- Camada responsável pelo código de interface (seja ela uma API ou a View e Controller do MVC).
- Essa camada depende de todas as outras. Nela é feita a configuração de injeção de dependência envolvendo as interfaces contidas no Core, e das implementações contidas na Infrastructure e Core.

**Contém os seguintes componentes:**
- **Controllers:** classes responsáveis por definir os pontos de acesso de API, que correspondem às Actions e suas rotas correspondentes.
- **Filters:** classes que influenciam no processomento e fluxo das requisições.
Por exemplo, usaremos um filtro no módulo de validação de APIs, e também um filtro para tratamento de exceções.

# Persistência de Dados
## O que significa Persistência de Dados?
- Persistir é o processo de armazenar dados de maneira a que, mesmo após a interrução do serviço de armazenamento ou do processo que o armazenou, o dado ainda existe
- Dados persistidos devem ser estáticos (a não ser que sejam alterados explicitamente), recuperáveis mesmo após falhas e são importantes ao negócio

## Exemplos de fontes de dados persistentes
- Banco de dados relacionais e não relacionais, como SQL Server, PostgreeSQL, MySQL, Nei4j, MongoDB, etc
- Arquivos em disco, por exemplo em logs de dados
- Containers / Buckets de dados, como no Amazon S3, Azure Storage, Google Cloud Storage

## O que é ORM?
- **Object-Relational Mapper**, representa ferramentas utilizadas para agilizar e simplificar operações que envolvem persistência de dados ou acesso a eles
- Funcionam como uma ponte do **modelo orientado a objetos,** baseado em classes e propriedades e representados geralmente como JSON, para os **modelos relacionais** baseados em tabelas e colunas

No caso do .NET, antigamente precisava-se utilizar o ADO.NET, que é um conjunto de namespaces do .NET e suas classes e métodos para acesso a dados.
Porém, ele não oferece uma alternativa ágil e simplificada, sendo bastante passivo de erros de escrita de nomes de colunas, entre outros problemas.
Diante disso, surgiram os primeiros ORMs, se destacando o **Entity Framework** e o **LINQ-to-SQL**

As ORMs foram se atualizando, oferecendo uma experiência mais flexível, permitindo tanto utilizar simplificações de acesso a tabelas, quanto a utilizar expressões SQL diretamente.

# Entity Framework Core
- É a ORM mais utilizada para desennvolvimento em .NET, sendo multiplataforma open-source, e mantida pela Microsoft
- É madura, tendo sido evoluída junto ao .NET Core, e com performance e funcionalidades sendo melhoradas a cada versão
- Os pacotes a serem utilizados são **Microsoft.EntityFrameworkCore.SqlServer** e **Microsoft.Entity.FrameworkCore.Tolls**

- Tem suporte a diferentes bancos de dados como SQL Server, SQLite, PostgreeSQL, MySQL, CosmosDB, etc

**Pricipais conceitos**
- DbContext
- DbSet
- Migrations

## DbContext
- Representa o banco de dados, que em bancos de dados relacionais é composto por tabelas, procedimentos armazenados, views, gatilhos entre outros
- É composto por propriedades de tipo DbSet's
- Esta classe deve ser herdada, e geralmente se utiliza o nome da aplicação + DbContext para nomear. Em nosso caso, poderia ser **DevFreelaDbContext**

## DbSet
- Representa uma tabela de um banco de dados, sendo utilizado de maneira tipada, como DbSet<T>. O T seria uma entidade do domínio, que estaria sendo representada como uma tabela no banco de dados
- Exemplos de DbSet que usaremos são **DbSet<Project>, DbSet<User> e DbSet<Skill>**

## Migration
- Classe que representa alterações do modelo de dados da aplicações que devem ser replicados no banco de dados
- Utilizados na abordagem **Code-First**, onde o primeiro escrevemos o código, adicionamos as entidades como DbSet, configuramos corretamente, e então geramos a Migration
- Devem ser executadas **a cada alteração** no modelo de daods, já que qualquer diferença entre o modelo da aplicação e do banco de daods resultará em erro

Em sistemas reais existem diversas maneiras de se trabalhar com elas, como:
- Geradas e executadas diretamente no banco de dados alvo
- Geradas, mas tanto em formato tradicional quanto em script SQL. O script SQL que representa a mudança deverá fazer parte do versionamento do código, e também ser enviado para o setor de Infra-estrutura, através de um chamado para executar as alterações
- Scripts SQL gerados, versionadas, mas com mudança aplicada via aplicação terceira, commo o Flyway
  
  # Configurando o ambiente
- Idealmente, instalar o SQL Express e o SQL Management Studio
- Para sistemas que não sejam Windows, uma alternativa interessante ao SQL Management Studio é o Azure Data Studio
- Instalar as ferramentas do EF Tools globalmente **dotnet tool install --global dotnet-ef**

# Configurando as Entidades
Existem diversas configurações que podem ser feitas em relação a DbSet, feitas a partir do objeto de tipo **ModelBuilder.** Por exemplo:
- Tabelas mapeadas a partir das entidades
- Colunas mapeadas a partir das propriedades

Método **OnModelCreating,** dentro da classe que herda do **DbContext**

```c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
	modelBuilder.Entity<T>()...
}
```

## Configurando as Entidades
Para tabelas, deve-se acessar a propriedade **Entity<T>** do **ModelBuilder,** e as configurações mais comuns são:
- **ToTable:** define o nome da tabela do banco de dados
- **HasKey:** define a chave primária
* **HasData:** define um conjunto de dados iniciais
- **Property:** permite configurar as propriedades

Para propriedades, deve-se acessar a propriedade **Property,** reccebendo a propriedade via expressão lambda
- **HasMaxLength:** tamanho máximo
- **HasColumName:** nome da coluna da tabela
- **IsRequired:** define a obrigatoriedade de valor
- **HasDefaultValueSql:** define um valor padrão inicial usando uma expressão SQL

## Configurando relacionamentos
O fluxo para configurar um relacionamento geralmente é o seguinte:
- Criar a propriedade que representa chave estrangeira
- Criar propriedade de navegação
- Configurar o relacionamento entre as entidades utilizando os métodos _HasMany_, _WhiteOne_, _HasOne_
- Configurar chave estrangeira com _HasForeignKey_

## Refatorando as configurações 
É bem comum encontrar classes DbContext lotadas de configurações, já que o tamanho escala com a quantidade de entidades / tabelas e propriedades configuradas.
É possível criar classes que implementem _IEntityTypeConfiguration<T>_, onde T é a classe a ser configurada, e migrar o código para ela
Todas as classes de configuração podem então ser adicionadas de uma vez através do código a seguir
```c#
protected override void OnModelCreating(ModelBuilder builder)
{
	builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
```

## Gerando e aplicando Migrations
Gerar e aplicar Migrations é bem simples, porém uma pequena configuração deve ser feita no projeto API, para que possa ser realizada
- Adicionar a cadeia de conexão do banco de dados utilizado no arquivo **_appsettings.json_**
```c#
"ConnectionStrings": {
	"DevFreelaCs": "Server=localhost\\SQLEXPRESS; Database=DevFreela;Trusted_Connection=True;"
}
```

- Adicionar a seguinte linha de código no método _ConfigureServices_ da classe **_Startup_*
```c#
"services.AddDbContext<DevFreelaDbContext>(
	options => options.UseSqlServer(Configuration.GetConnectionString("DevFreelaCs")));
}
```

## Configurando as Entidades
Feito isso, basta executar os dois comandos seguintes, na pasta do projeto **Persistence**
- _donet ef migrations add NomeMigration -s
	../DevFreela.API/DevFreela.API.csproj -o
	../Persistence/Migrations_
- _dotnet ef database update -seguinte
	../DevFreela.API/DevFreela.API.csproj_
  
## EF Core em Memória
Em algumas situações, a disponibilidade de um servidor SQL Server para o desenvolvimento de um projeto pode ser restrita, ou mesmo inexistente em início de projetos, por exemplo

Isso pode ocorrer devido a burocracia no fornecimento de um servidor, problemas de indisponibilidade devido a instabilidade, entre outras situações.

Em situações do tipo, o suporte a banco de dados em memória do Entity Framework Core pode literalmente salvar projetos

Com o código a seguir, você não precisa mais se preocupar em aplicar migrations, e avançar o projeto mesmo sem BD
```c#
services.AddDbContext<DevFreelaDbContext>(options => options.UseInMemoryDatabase("DevFreela"));
```

- Lembrar de instalar o pacote
**Microsoft.EntityFrameworkCore.InMemory**

## Dapper ORM
### Dapper ORM
ORM mais performática e simples que o EF Core, de fácil adoção em um projeto que já utiliza o EF Core ou outros métodos de acessos a dados
- Apresenta métodos de extensão ao IDbConnection (no caso de SQL Server, SqlConnection)
- É flexível, utilizando consultas SQL diretamente, permitindo uso de INSERT, DELETE, UPDATE, Procedimentos Armazenados, entre outros.

Entre os métodos de extensão oferecidos, os mais utilizados são:
- **Execute / ExecuteAsync:** recebe uma cadeia de caracteres com o comando a ser executado, e retorna a quantidade de registros afetados
- ```Query<T> / QueryAsync<T>```: recebe uma cadeia de caracteres com o comando a ser executado e retorna a saída como objeto de tipo T
