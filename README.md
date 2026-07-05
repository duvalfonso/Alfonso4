
# Cuarta entrega

Este proyecto está destinado como entrega a ramo Programación .Net



## Instalación

Para ejecutar el proyecto, se requiere crear una base de datos en local dentro de la carpeta App_Data con el siguiente script

```bash
CREATE TABLE [dbo].[alumnos] (
    [rut]      VARCHAR (20)   NOT NULL,
    [nombre]   VARCHAR (50)   NOT NULL,
    [nota1]    DECIMAL (3, 2) NOT NULL,
    [nota2]    DECIMAL (3, 2) NOT NULL,
    [nota3]    DECIMAL (3, 2) NOT NULL,
    [promedio] DECIMAL (3, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([rut] ASC)
);
```
    
## Acknowledgements
Readme realizado gracias a:
 - [Awesome Readme Templates](https://awesomeopensource.com/project/elangosundar/awesome-README-templates)
 - [Awesome README](https://github.com/matiassingers/awesome-readme)
 - [How to write a Good readme](https://bulldogjob.com/news/449-how-to-write-a-good-readme-for-your-github-project)


## FAQ

#### ¿Qué editor se uso?

Visual Studio Community 2022

#### ¿Qué base de datos se usó?

Microsoft SQL Server 2025 v. 17.0.4025.3

