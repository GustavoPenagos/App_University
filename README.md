# 🧠 Proyecto API Oracle - Backend

Este proyecto establece una conexión con bases de datos Oracle, permitiendo realizar consultas y registros de manera eficiente. La información gestionada por el backend se presenta a través de una interfaz desarrollada en Angular. Además, los endpoints pueden ser probados localmente utilizando herramientas como Postman, Bruno o similares, lo que facilita el proceso de validación y depuración.

---

## 📦 Instalación de dependencias

1. Clona el repositorio:
   ```bash
   git clone https://github.com/GustavoPenagos/App_University.git
   
8. Instalacion de SDK 8.0.413 (windows)
    - (x86): https://dotnet.microsoft.com/es-es/download/dotnet/thank-you/sdk-8.0.413-windows-x86-installer
    - (x64): https://dotnet.microsoft.com/es-es/download/dotnet/thank-you/sdk-8.0.413-windows-x64-installer

9. Instalacion de ASP.NET Core Runtime 8.0.19 (windows)
    - (x86): https://dotnet.microsoft.com/es-es/download/dotnet/thank-you/runtime-aspnetcore-8.0.19-windows-x86-installer
    - (x64): https://dotnet.microsoft.com/es-es/download/dotnet/thank-you/runtime-aspnetcore-8.0.19-windows-x64-installer

3. Instalacion de SQL developer
    - https://download.oracle.com/otn_software/java/sqldeveloper/sqldeveloper-24.3.1.347.1826-x64.zip

4. Instalacion de Oracle XE
    - https://download.oracle.com/otn-pub/otn_software/db-express/OracleXE213_Win64.zip


5. Instalacion de la libreria Oracle.EntityFrameworkCore en su version mas actaulizada desde consola o desde el administrador de paquetes - para las librerias (App_University, App_University.Data, App_University.Logic).
    Install-Package Microsoft.Extensions.Configuration -Version 9.23.90

6. Instalacion de la libreria Microsoft.EntityFrameworkCore en su version mas actaulizada desde consola o desde el administrador de paquetes - para las librerias (App_University, App_University.Data, App_University.Logic).
    Install-Package Microsoft.EntityFrameworkCore -Version 9.0.8

7. Instalacion de la libreria Microsoft.EntityFrameworkCore en su version mas actaulizada desde consola o desde el administrador de paquetes - para las librerias (App_University, App_University.Data, App_University.Logic)..
    Install-Package Microsoft.EntityFrameworkCore.SqlServe -Version 9.0.8

8. Instalacion de la libreria Microsoft.EntityFrameworkCore.Tools en su version mas actaulizada desde consola o desde el administrador de paquetes - para las librerias (App_University, App_University.Data, App_University.Logic).
    Install-Package Microsoft.EntityFrameworkCore.Tools -Version 9.0.8

9. Instalacion de la libreria Microsoft.Extensions.Configuration en su version mas actaulizada desde consola o desde el administrador de paquetes - para las librerias (App_University, App_University.Data, App_University.Logic, App_University.Transversal).
    Install-Package Microsoft.Extensions.Configuration -Version 9.0.8

10. Instalacion de la libreria Newtonsoft.Json en su version mas actaulizada desde consola o desde el administrador de paquetes - para las librerias (App_University, App_University.Data, App_University.Logic).
    Install-Package Microsoft.Extensions.Configuration -Version 13.0.13

## Configurar la conexión a Oracle

1. Crear usuario para la base de datos a crear y probar
2. Ejecucion del archivo script_tablas_admision.sql que se entrego en el examen y adjunto en el zip entregadodo, con correccion del insert.
3. Ejecucion del archivo script_stored_procedures_admision.sql que se entrego en el examen y adjunto en el zip entregadodo.
4. probar el correcto funcionamiento de los Store Procedure con archivo script_testing_sp_admisiones.sql.


## Ejecutar localmente los endpoints / Probar los endpoints con herramientas como Postman, Bruno o similares.

1. Unas vez se ejecute la aplicacion de postman, adjuntar los cURl de los puntos 2 y 3, en postman.
2. cURL (GET) (/consulta-pagos):
    curl --location 'https://localhost:7160/consulta-pagos?program=PG-SIST&term_code=202401' \
    --header 'accept: text/plain'
3. cURL (POST) (/registro-verificacion):    
    curl --location 'https://localhost:7160/registro-verificacion' \
    --header 'accept: text/plain' \
    --header 'Content-Type: application/json' \
    --data '{
    "Pidn": 1001,
    "Term_code": "202401",
    "Program": "PG-SIST",
    "Admr_code": "ACTA",
    "Recieve_date": "2025-09-25",
    "Comment": "Pago de inscripción $130.000"
    }'

    _"La url puede variar en el puerto"_
 


