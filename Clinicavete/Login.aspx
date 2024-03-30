<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Clinicavete.Login" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Iniciar Sesión - Clínica Veterinaria</title>
    <style>
        /* Estilos modernos y profesionales */
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
        }
        .container {
            max-width: 400px;
            margin: 0 auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }
        .form-group {
            margin-bottom: 20px;
        }
        label {
            font-weight: bold;
        }
        input[type="text"],
        input[type="password"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
        }
        .login-button {
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            padding: 10px 20px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            margin-top: 20px;
        }
        .login-button:hover {
            background-color: #0056b3;
        }
        .user-box {
            display: none;
            margin-top: 20px;
        }
        .register-button {
            background-color: #28a745;
            color: white;
            border: none;
            border-radius: 5px;
            padding: 10px 20px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            margin-top: 20px;
        }
        .register-button:hover {
            background-color: #218838;
        }
        .auto-style1 {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #28a745;
            color: white;
            border-radius: 5px;
            padding: 10px 20px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            margin-top: 0px;
            margin-left: 277px;
        }
    </style>
</head>
<body>
    <form id="loginForm" runat="server">
        <div class="container">
            <div class="login-form">
                <h2>Iniciar Sesión</h2>
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                <div>
                    <label for="txtUsername">Usuario:</label>
                    <asp:TextBox ID="txtUsername" runat="server" />
                </div>
                <div>
                    <label for="txtPassword">Contraseña:</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                </div>
                <div>
                    <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="login-button" OnClick="btnLogin_Click" />
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="auto-style1" OnClick="btnRegistrar_Click" Width="133px" title="Haz clic aquí para registrarte" />
                </div>
                <div class="user-box" runat="server" id="userBox">
                    Usuario: <span id="lblUsuario" runat="server"></span>
                    <br />
                    <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
                </div>
                <div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
