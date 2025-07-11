# 🧾 Sistema de Inventario - Engrama

Este proyecto es una aplicación web sencilla para la gestión de inventario, pedidos de proveedores y ventas, desarrollada bajo la metodología **Engrama**. El sistema permite registrar pedidos de productos, almacenar artículos y realizar ventas que afectan el inventario en tiempo real.

## 🚀 Características principales

- 📦 **Pedidos de proveedores:** Registrar pedidos de productos a proveedores.
- 🗃️ **Inventario:** Visualización de productos disponibles, su cantidad y estado.
- 💰 **Ventas:** Gestión de ventas que actualiza automáticamente la cantidad en inventario.
- 🖥️ **Interfaz moderna:** Basada en **Blazor PWA** con **MudBlazor** para una experiencia rápida y adaptable.

## 🧠 Metodología Engrama

Esta aplicación fue desarrollada utilizando la metodología **Engrama**, la cual facilita la creación de aplicaciones web completas, desde la base de datos hasta la interfaz de usuario.  
Se implementa la librería `EngramaCoreStandar`, que permite una comunicación eficiente:

- Entre el cliente (Blazor) y la API.
- Entre la API y la base de datos.

Engrama busca estandarizar y simplificar el desarrollo de software, permitiendo escalar aplicaciones rápidamente con una estructura limpia y mantenible.

## 🛠️ Tecnologías utilizadas

- **.NET 9** – Plataforma para API y cliente Blazor.
- **SQL Server** – Base de datos relacional.
- **Blazor WebAssembly PWA** – Aplicación cliente progresiva.
- **MudBlazor** – Librería de componentes para UI moderna.
- **EngramaCoreStandar** – Núcleo de comunicación basado en la metodología Engrama.
- **Arquitectura en capas:**
  - `Arquitectura` – Infraestructura general del sistema.
  - `Dominio` – Entidades y lógica de negocio.
  - `Servicio` – Implementación de casos de uso y lógica de aplicación.

## 🧱 Estructura del proyecto

