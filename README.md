# HighScorePlayerAPI

 ## Dotnet EF commands
 
dotnet tool install --global dotnet-ef

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet ef migrations add InitialCreate

dotnet ef database update

## Dotnet EF fluen API 
Alguns exemplos de uso do ModelBuilder incluem:

    Configuração de relacionamentos entre entidades (por exemplo, um-para-um, um-para-muitos, muitos-para-muitos).
    Especificação de chaves primárias e chaves estrangeiras.
    Definição de índices para melhorar o desempenho das consultas.
    Configuração de propriedades de entidades, como tipo de dados, tamanho máximo, restrições de nulo e assim por diante.
    Especificação de comportamentos de exclusão em cascata e atualização em cascata.
    E muitos outros aspectos relacionados à modelagem de dados no EF Core.

## mapear
Quando você cria uma classe de entidade em seu aplicativo .NET Core, ela representa um conceito no seu modelo de domínio. Por exemplo, você pode ter uma classe Produto que representa os produtos em uma loja online. No entanto, para armazenar esses produtos em um banco de dados relacional, é necessário mapeá-los para tabelas e colunas.
