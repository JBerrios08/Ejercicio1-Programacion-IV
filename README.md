# Ejercicio1

## Configuración de credenciales

La cadena de conexión definida en `App.config` utiliza claves de marcador de posición y las credenciales reales se cargan en tiempo de ejecución desde variables de entorno. Antes de ejecutar la aplicación, defina las siguientes variables:

- `DB_SERVER`: servidor de la base de datos
- `DB_NAME`: nombre de la base de datos
- `DB_USER`: usuario de la base de datos
- `DB_PASSWORD`: contraseña del usuario

### Ejemplo

**Windows (PowerShell)**

```powershell
$env:DB_SERVER="localhost"
$env:DB_NAME="restaurante"
$env:DB_USER="usuario_db"
$env:DB_PASSWORD="tu_password"
```

**Linux/macOS (bash)**

```bash
export DB_SERVER=localhost
export DB_NAME=restaurante
export DB_USER=usuario_db
export DB_PASSWORD=tu_password
```

Configure estas variables con los valores apropiados para su entorno antes de iniciar la aplicación.