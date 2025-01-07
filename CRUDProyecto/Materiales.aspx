<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Materiales.aspx.cs" Inherits="CRUDProyecto.Materiales" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <title>Materiales - Biblioteca Musical</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container mt-4">
        <h2>Gestión de Materiales</h2>
        
        <!-- Botón para crear nuevo material -->
        <a href="AgregarMaterial.aspx" class="btn btn-primary mb-3">Crear Nuevo Material</a>

        <!-- Tabla para mostrar los materiales -->
        <div class="card">
            <div class="card-header">
                Lista de Materiales
            </div>
            <div class="card-body">
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Título</th>
                            <th>Tipo</th>
                            <th>Autor</th>
                            <th>Fecha Publicación</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody id="materialesTable">
                        <!-- Aquí se mostrarán los materiales dinámicamente desde el código-behind -->
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <!-- Script para gestionar los botones de eliminar y editar -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        // Función para eliminar un material
        function eliminarMaterial(id) {
            if (confirm('¿Estás seguro de que quieres eliminar este material?')) {
                // Llamar al servidor para eliminar el material (puedes hacer una petición AJAX aquí)
                window.location.href = 'EliminarMaterial.aspx?id=' + id; // Redirigir a la página de eliminar material con el ID
            }
        }

        // Función para editar un material
        function editarMaterial(id) {
            window.location.href = 'EditarMaterial.aspx?id=' + id; // Redirigir a la página de editar material con el ID
        }
    </script>
</body>
</html>
