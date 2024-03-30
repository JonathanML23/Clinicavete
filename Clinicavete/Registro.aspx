<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Clinicavete.Registro" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registro de Usuario - Clínica Veterinaria</title>
    <style>
        /* Estilos para mejorar la apariencia del formulario de registro */
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            margin: 0;
            padding: 0;
        }
        .container {
            width: 100%;
            max-width: 400px;
            margin: 100px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h2 {
            text-align: center;
            margin-bottom: 20px;
        }
        .form-group {
            margin-bottom: 20px;
        }
        label {
            display: block;
            font-weight: bold;
        }
        input[type="text"],
        input[type="password"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
            box-sizing: border-box;
        }
        input[type="submit"],
        input[type="button"] {
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }
        input[type="submit"]:hover,
        input[type="button"]:hover {
            background-color: #0056b3;
        }
        .error-message {
            color: red;
            font-weight: bold;
            text-align: center;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <div class="container">
        <h2>Registro de Usuario</h2>
        <asp:Label ID="lblError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        <form id="registerForm" runat="server">
            <div class="form-group">
                <label for="username">Usuario:</label>
                <input type="text" id="username" name="username" runat="server" required>
            </div>
            <div class="form-group">
                <label for="password">Contraseña:</label>
                <input type="password" id="password" name="password" runat="server" required>
            </div>
            <div class="form-group">
                <input type="submit" value="Registrar" runat="server">
            </div>
            <div class="form-group">
                <input type="button" value="Salir" onclick="location.href='Inicio.aspx';">
            </div>
        </form>
    </div>
</body>
</html>