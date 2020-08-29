# ApiRuleta

Web api net core

# Ejecución

- En la carpeta **ApiRuleta** se encuentra la solución **ApiRuleta.sln** se recomienda usar Visual Studio 2019
- Modificar la cadena de conexión `PostgreSqlDBContext` del archivo **ApiRuleta/appsettings.json**

- Ejecutar el siguiente script en su motor de base de datos **postgresql** para crear la base de datos y su respectiva tabla.

```
create database dbroulette

create table roulette(
	id_roulette bigint primary key,
	name text not null,
	status_roulette bool null,
	fhcreation timestamp not null default(Now())
)


create sequence id_roulette;
alter table  roulette alter column id_roulette set default
nextval('id_roulette'::regclass);
```
