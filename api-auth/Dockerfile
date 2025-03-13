# Define a imagem do SDK do .NET 8.0 para compilar a aplica��o.
# A fase � nomeada como "build" para refer�ncia nas etapas posteriores.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Documenta as portas que a aplica��o utilizar�.
# O EXPOSE n�o exp�e as portas para o host, apenas documenta quais portas o cont�iner usar�.
# O mapeamento de portas � feito com o comando "docker run -p".
EXPOSE 7136
EXPOSE 8080

# Define o diret�rio de trabalho dentro do cont�iner como /App.
# Todos os comandos subsequentes (COPY, RUN, etc.) ser�o executados neste diret�rio.
WORKDIR /App

# Copia todos os arquivos do contexto de build (diret�rio atual no host) para o diret�rio de trabalho /App no cont�iner.
COPY . ./

# Restaura as depend�ncias do projeto usando o comando "dotnet restore".
RUN dotnet restore

# Publica a aplica��o em uma pasta chamada "out" dentro do diret�rio /App.
RUN dotnet publish -o out

# Define uma nova fase usando uma imagem menor (runtime do .NET 8.0) para rodar a aplica��o.
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Define o diret�rio de trabalho como /App na nova fase.
WORKDIR /App

# Copia os arquivos publicados da fase "build" (pasta /App/out) para o diret�rio de trabalho atual (/App).
COPY --from=build /App/out .

# Define o comando principal que ser� executado quando o cont�iner for iniciado.
# Neste caso, a aplica��o ser� iniciada com o comando "dotnet FinanSmart.Api.dll".
ENTRYPOINT ["dotnet", "api-auth.dll"]