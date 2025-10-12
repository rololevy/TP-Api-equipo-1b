# API Cat�logo de Productos

API REST desarrollada en ASP.NET Web API (.NET Framework 4.8) para la gesti�n de un cat�logo de productos.

## ? Funcionalidades Implementadas

- **Listar Productos**: `GET /api/Articulo` - Devuelve todos los productos con marca, categor�a e im�genes
- **Crear Producto**: `POST /api/Articulo` - Crear nuevo producto usando DTO

## ??? Tecnolog�as

- ASP.NET Web API (.NET Framework 4.8)
- SQL Server Express
- Arquitectura en capas (Dominio, Servicios, DataManager)

## ?? Endpoints

### GET /api/Articulo
Retorna lista completa de art�culos con:
- Datos del producto (c�digo, nombre, descripci�n, precio)
- Informaci�n de marca y categor�a
- URLs de todas las im�genes

**Ejemplo de respuesta:**
```json
[
  {
    "Id": 1,
    "Codigo": "S01",
    "Nombre": "Galaxy S10",
    "Descripcion": "Una canoa cara",
    "Precio": 69.99,
    "IdMarca": 1,
    "DescripcionMarca": "Samsung",
    "IdCategoria": 1,
    "DescripcionCategoria": "Celulares",
    "Imagenes": [
      "https://images.samsung.com/is/image/samsung/co-galaxy-s10-sm-g970-sm-g970fzyjcoo-frontcanaryyellow-thumb-149016542"
    ]
  }
]
```

### POST /api/Articulo
Crear nuevo art�culo enviando JSON:

**Ejemplo de request:**
```json
{
    "codigo": "PROD001",
    "nombre": "Producto ejemplo",
    "descripcion": "Descripci�n del producto",
    "precio": 999.99,
    "idMarca": 1,
    "idCategoria": 1,
    "imagenUrl": "https://ejemplo.com/imagen.jpg"
}
```

**Ejemplo de respuesta exitosa:**
```json
{
    "mensaje": "Art�culo creado exitosamente",
    "codigo": "PROD001"
}
```

## ??? Base de Datos

La aplicaci�n utiliza SQL Server Express con la base de datos `CATALOGO_P3_DB`.

### Tablas principales:
- `ARTICULOS` - Productos del cat�logo
- `MARCAS` - Marcas disponibles
- `CATEGORIAS` - Categor�as de productos
- `IMAGENES` - URLs de im�genes de productos

## ?? C�mo ejecutar

1. Clonar el repositorio
2. Restaurar la base de datos `CATALOGO_P3_DB` en SQL Server Express
3. Ejecutar el script de creaci�n de datos (incluye datos de prueba)
4. Establecer `ApiWinForms` como proyecto de inicio
5. Ejecutar con F5 en Visual Studio

## ?? Validaciones

El DTO incluye validaciones para:
- C�digo obligatorio (m�ximo 50 caracteres)
- Nombre obligatorio (m�ximo 50 caracteres)
- Descripci�n (m�ximo 150 caracteres)
- Precio mayor a 0
- Marca y categor�a deben existir en la base de datos

## ?? Arquitectura

El proyecto reutiliza la arquitectura existente:
- **Dominio**: Entidades de negocio
- **Servicios**: L�gica de negocio
- **DataManager**: Acceso a datos
- **ApiWinForms**: Controladores Web API

## ?? Equipo

Trabajo pr�ctico desarrollado por el Equipo 1B.