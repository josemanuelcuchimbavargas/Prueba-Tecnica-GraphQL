Instrucciones para hacer correr el proyecto.

1. En la terminal de paquetes correr estos comandos.

Add-Migration 'Crear Database'
update-database

Nota: Esto creara una base de datos en SQL SERVER.

2. La paginación con GraphQL esta maximo 2 items por pagina.
Se puede cambiar esta limitacion en Backend/GraphQL/Query.cs Linea 27.

3. En el archivo appsettings.json cambiar el server de la conexión por el nuevo.