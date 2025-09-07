1. Página Principal (Index)
Vista principal que muestra el dashboard de la aplicación

Proporciona acceso a las funcionalidades de consulta

2. Registro de Pagos (Registry)
Vista para el registro de nuevos pagos

Formulario de captura de información de pago

3. Inserción de Pagos (InsertPayment)
Método: POST

Descripción: Registra un nuevo pago en el sistema

Parámetros: PaymentRegisterRequest request

Flujo:

Serializa el objeto request a JSON

Envía la solicitud a la API de registro

Procesa la respuesta

Retorna la vista de registro con los resultados

4. Consulta de Pagos (ConsultPayment)
Método: GET

Descripción: Consulta pagos existentes basados en criterios específicos

Parámetros: ConsultRequest consult (programa y código de período)

Flujo:

Construye la URL con parámetros de consulta

Realiza la solicitud GET a la API

Procesa y muestra los resultados en la vista principal


## Configuración y Dependencias

<PackageReference Include="Microsoft.AspNetCore.App" />
<PackageReference Include="Newtonsoft.Json" />
<PackageReference Include="Microsoft.Extensions.Logging" />

## Configuración de AppSettings
{
    "UrlAPI": {
    "UniversityApi": "https://localhost:7160/",
    "Consulta": "consulta-pagos",
    "Registro": "registro-verificacion"
    }
}

## Endpoints de la API

Endpoint de Registro
URL: {UniversityApi}/api/payments/register

Método: POST

Body: PaymentRegisterRequest en formato JSON

## Endpoint de Consulta
URL: {UniversityApi}/api/payments/consult?program={program}&term_code={term_code}

Método: GET

Parámetros:

program: Código del programa académico

term_code: Código del período académico


Características Técnicas

## Manejo de Errores
Logging de errores con ILogger

Manejo de excepciones con try-catch

Retorno de vistas de error personalizadas

## Logging
Registro de información con _logger.LogInformation()

Registro de errores con _logger.LogError()

Seguimiento de actividades del sistema

## Serialización JSON
Uso de JsonConvert para serialización/deserialización

Codificación UTF-8 para las solicitudes HTTP

## Instalación y Ejecución
Prerrequisitos
.NET 6.0 o superior

Visual Studio 2022 o Visual Studio Code

Acceso a la API University

Pasos de Instalación
Clonar el repositorio

Restaurar paquetes NuGet

Configurar las URLs de la API en appsettings.json

Compilar la solución

Ejecutar la aplicación

## Flujo de Trabajo
Usuario accede a la página principal (Index)

Puede elegir entre:

Registrar nuevo pago (Registry)

Consultar pagos existentes (ConsultPayment)

El sistema se comunica con la API externa

Procesa y muestra los resultados al usuario

## Solución de Problemas

Errores Comunes
Error de conexión con la API: Verificar configuraciones de URL

Errores de serialización: Validar formatos JSON

Problemas de CORS: Configurar adecuadamente el servidor

Logs
Revisar los logs de aplicación para diagnóstico de problemas:

Información de operaciones exitosas

Detalles de errores y excepciones