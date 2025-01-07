<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CRUDProyecto.Inicio" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Bibliotecas Musicales  - Iniciar sesión</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* Fondo con imagen */
        body {
            background: url('https://i.pinimg.com/originals/75/09/69/7509691b00f6922373f96208c6a295a4.jpg') no-repeat center center fixed;
            background-size: cover;
            height: 100vh;
            font-family: 'Arial', sans-serif;
            color: #fff;
        }

        /* Filtro de color  */
        .overlay {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.5); /* Sombra oscura sobre la imagen */
        }

        /* Estilo del contenedor del formulario */
        .card {
            border-radius: 15px;
            box-shadow: 0px 10px 25px rgba(0, 0, 0, 0.2);
            background: rgba(255, 255, 255, 0.8);
        }

        .card-body {
            padding: 2rem;
        }

        .form-label {
            font-weight: bold;
        }

        /* Estilo para los Label dentro de la card */
        .card .form-label {
            color: darkblue; /* Color negro */
        }

        .btn-primary {
            background-color: #007bff;
            border-color: #007bff;
            transition: background-color 0.3s ease;
        }

        .btn-primary:hover {
            background-color: #0056b3;
            border-color: #004085;
        }

        .container {
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            position: relative;
            flex-direction: column;
        }

        /* Ajuste de márgenes para reducir el espacio entre los elementos */
        .content-header {
            text-align: center;
            font-family: 'Georgia', serif;
            margin-bottom: 0;  /* Reducir el espacio entre este y el formulario */
        }

        .content-header h1 {
            margin-bottom: 0;  /* Reducir margen del título */
        }

        .content-header p {
            margin-bottom: 0;  /* Reducir margen del párrafo */
        }

        .mt-5 {
            margin-top: 3rem;
        }

        .mb-3 input {
            border-radius: 8px;
            box-shadow: inset 0px 0px 5px rgba(0, 0, 0, 0.1);
        }

        .mb-3 input:focus {
            border-color: #007bff;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
        }

        .alert {
            font-size: 0.9rem;
            padding: 10px;
            margin-top: 10px;
            display: none;
        }

        .text-center {
            font-family: 'Georgia', serif;
            color: snow;
        }

        .art-description {
            font-size: 1.2rem;
            color: mediumaquamarine;
            margin-bottom: 1rem;
        }

        .art-title {
            font-size: 2rem;
            font-weight: bold;
            color: mediumturquoise;
        }
    </style>
</head>
<body>

    <div class="overlay"></div> <!-- Superposición oscura sobre el fondo -->

    <form id="formLogin" runat="server">
        <div class="container">
            <!-- Información sobre la galería de arte -->
            <div class="content-header">
                <h1 class="art-title">Biblioteca Musical </h1>
                <p> ............................................................................................................................................................................................................................................................................................................................</p>
                <p class="art-description">&nbsp;</p>
                <p class="art-description">Todo el problema puede expresarse simplemente preguntando: La música, ¿tiene un significado? Mi respuesta sería 'Sí'. Y ¿Puedes expresar en unas cuantas palabras, cuál es el significado? Mi respuesta a eso, sería 'No'.</p>
            </div>

            <!-- Formulario de inicio de sesión -->
            <div class="col-md-4">
                <h2 class="text-center mt-5 mb-4">&nbsp;Iniciar sesión</h2>


                <div class="card">
                    <div class="card-body">
                        <div class="mb-3">
                            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su usuario"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ingrese su contraseña"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" CssClass="btn btn-primary w-100" />
                        </div>

                        <div class="alert alert-danger" id="alertMensaje" runat="server">
                            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                        </div>

                        <!-- Enlace para registrarse -->
                        <div class="text-center mt-3">
                            <a href="Registrarse.aspx" class="btn btn-link" style="color: #007bff;">¿No tienes cuenta? Regístrate aquí</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
