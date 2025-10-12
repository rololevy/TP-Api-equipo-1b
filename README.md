# API Catálogo de Productos

API REST desarrollada en ASP.NET Web API (.NET Framework 4.8) para la gestión de un catálogo de productos.

## ? Funcionalidades Implementadas

- **Listar Productos**: `GET /api/Articulo` - Devuelve todos los productos con marca, categoría e imágenes
- **Crear Producto**: `POST /api/Articulo` - Crear nuevo producto usando DTO

## ??? Tecnologías

- ASP.NET Web API (.NET Framework 4.8)
- SQL Server Express
- Arquitectura en capas (Dominio, Servicios, DataManager)

## ?? Endpoints

### GET /api/Articulo
Retorna lista completa de artículos con:
- Datos del producto (código, nombre, descripción, precio)
- Información de marca y categoría
- URLs de todas las imágenes

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
Crear nuevo artículo enviando JSON:

**Ejemplo de request:**
```json
{
    "codigo": "PROD001",
    "nombre": "Producto ejemplo",
    "descripcion": "Descripción del producto",
    "precio": 999.99,
    "idMarca": 1,
    "idCategoria": 1,
    "imagenUrl": "https://ejemplo.com/imagen.jpg"
}
```

**Ejemplo de respuesta exitosa:**
```json
{
    "mensaje": "Artículo creado exitosamente",
    "codigo": "PROD001"
}
```

## ??? Base de Datos

La aplicación utiliza SQL Server Express con la base de datos `CATALOGO_P3_DB`.

### Tablas principales:
- `ARTICULOS` - Productos del catálogo
- `MARCAS` - Marcas disponibles
- `CATEGORIAS` - Categorías de productos
- `IMAGENES` - URLs de imágenes de productos

## ?? Cómo ejecutar

1. Clonar el repositorio
2. Restaurar la base de datos `CATALOGO_P3_DB` en SQL Server Express
3. Ejecutar el script de creación de datos (incluye datos de prueba)
4. Establecer `ApiWinForms` como proyecto de inicio
5. Ejecutar con F5 en Visual Studio

## ?? Validaciones

El DTO incluye validaciones para:
- Código obligatorio (máximo 50 caracteres)
- Nombre obligatorio (máximo 50 caracteres)
- Descripción (máximo 150 caracteres)
- Precio mayor a 0
- Marca y categoría deben existir en la base de datos

## ?? Arquitectura

El proyecto reutiliza la arquitectura existente:
- **Dominio**: Entidades de negocio
- **Servicios**: Lógica de negocio
- **DataManager**: Acceso a datos
- **ApiWinForms**: Controladores Web API

## ?? Equipo

Trabajo práctico desarrollado por el Equipo 1B.