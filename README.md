# 🚚 Mini Core Logística - Andrade

![.NET Core](https://img.shields.io/badge/.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white)
![Supabase](https://img.shields.io/badge/Supabase-3ECF8E?style=for-the-badge&logo=supabase&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)
![Render](https://img.shields.io/badge/Render-46E3B7?style=for-the-badge&logo=render&logoColor=white)

## Framework Utilizado

**.NET Core MVC (C#)** con **Entity Framework Core** y Base de Datos remota en **Supabase (PostgreSQL)**.

| Tecnología | Versión |
|---|---|
| .NET SDK | 10.0 |
| ASP.NET Core MVC | 10.0 |
| Entity Framework Core | 10.0.0 |
| Npgsql (PostgreSQL) | 10.0.0 |
| Base de Datos | Supabase (PostgreSQL) |
| Contenedor | Docker |
| Despliegue | Render |

---

## Descripción del Proyecto

Aplicación web funcional optimizada para el **cálculo automatizado del costo total de envíos por repartidor** basado en métricas logísticas regionales (**peso × tarifa por zona**) dentro de un rango de fechas configurable.

### Funcionalidades principales:

- ✅ Filtrado de envíos por rango de fechas (Fecha Inicio / Fecha Fin)
- ✅ Cálculo automático del costo total: `peso_kg × tarifa_por_kg` por zona
- ✅ Agrupación de resultados por repartidor con totales consolidados
- ✅ Visualización de repartidores sin envíos en el rango seleccionado
- ✅ Interfaz responsiva con Bootstrap y tablas estilizadas
- ✅ Persistencia de datos con Entity Framework Core (Code-First) + Migraciones
- ✅ Datos semilla (Seed Data) precargados para demostración inmediata

### Regla de Negocio:

> Para cada repartidor dentro de un rango de fechas, el **costo total** generado es la suma de `(peso_kg × tarifa_por_kg de su zona respectiva)` de todos los envíos realizados en dicho periodo.

---

## Estructura del Proyecto

```
MinicoreLogisticaAndrade/
├── Controllers/
│   ├── HomeController.cs
│   ├── EnviosController.cs
│   └── LogisticaController.cs      # Controlador principal
├── Data/
│   └── ApplicationDbContext.cs      # DbContext con Fluent API y Seed Data
├── Migrations/                      # Migraciones de EF Core
├── Models/
│   ├── Repartidor.cs
│   ├── Zonas.cs
│   ├── Envios.cs
│   └── ErrorViewModel.cs
├── ViewModels/
│   └── ReporteLogisticaViewModel.cs # ViewModel del reporte
├── Views/
│   ├── Logistica/
│   │   └── Index.cshtml             # Vista principal del reporte
│   └── Shared/
│       └── _Layout.cshtml
├── wwwroot/                         # Archivos estáticos (CSS, JS, Bootstrap)
├── Program.cs                       # Punto de entrada y configuración DI
├── appsettings.json                 # Cadena de conexión Supabase
├── Dockerfile                       # Configuración Docker para Render
└── MinicoreLogisticaAndrade.csproj
```

---

## Instrucciones de Ejecución Local

### Prerrequisitos

- [.NET SDK 10.0](https://dotnet.microsoft.com/download) o superior instalado
- Conexión a Internet (para acceder a la base de datos en Supabase)

### Pasos

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/edjam006/minicore-logistica-andrade.git
   cd minicore-logistica-andrade
   ```

2. **Restaurar dependencias NuGet:**
   ```bash
   dotnet restore
   ```

3. **Compilar el proyecto:**
   ```bash
   dotnet build
   ```

4. **Ejecutar la aplicación:**
   ```bash
   dotnet run
   ```

5. **Abrir en el navegador:**
   ```
   https://localhost:5001
   ```
   La aplicación cargará directamente el **Panel de Costos de Distribución** con el rango de fechas por defecto (Mayo 2025).

### Ejecución con Docker (opcional)

```bash
docker build -t minicore-logistica .
docker run -p 8080:8080 minicore-logistica
```

Acceder en: `http://localhost:8080`

---

## Datos de Prueba Precargados (Seed Data)

### Zonas
| ID | Zona | Tarifa/kg |
|---|---|---|
| 1 | Norte | $1.50 |
| 2 | Sur | $2.00 |
| 3 | Centro | $1.25 |

### Repartidores
| ID | Nombre | Email |
|---|---|---|
| 1 | Andrés | andres@logistica.com |
| 2 | Camila | camila@logistica.com |
| 3 | Luis | luis@logistica.com |

### Envíos
| ID | Repartidor | Zona | Peso (kg) | Fecha |
|---|---|---|---|---|
| 1 | Andrés | Norte | 10 | 2025-05-05 |
| 2 | Andrés | Norte | 22 | 2025-05-12 |
| 3 | Camila | Sur | 18 | 2025-05-10 |
| 4 | Andrés | Centro | 15 | 2025-06-01 |

---

## Entregables Universitarios

### 🎥 Video Explicativo
> 📌 **Link al Video (YouTube):** [https://youtu.be/W5JGotmUIJE?feature=shared](https://youtu.be/W5JGotmUIJE?feature=shared)

### 🌐 Proyecto Desplegado en Producción
> 📌 **Link en Render:** [https://minicore-logistica-andrade.onrender.com](https://minicore-logistica-andrade.onrender.com)

### 📧 Correo Institucional
> 📌 **Email:** eduardo.andrade@udla.edu.ec

---

## Autor

**Nombre:** Andrade  
**Universidad:** UDLA - Universidad de las Américas  
**Materia:** Desarrollo de Software  
**GitHub:** [edjam006](https://github.com/edjam006)

---

> _Proyecto desarrollado como parte del Mini Core de Logística - 2025_
