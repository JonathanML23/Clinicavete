<%@ Page Title="Inicio - Clínica Veterinaria" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="Clinicavete.inicioaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            text-align: center;
            padding: 50px;
        }
        .services {
            margin-top: 30px;
            display: flex;
            justify-content: space-around;
            flex-wrap: wrap;
        }
        .service {
            width: 300px;
            background-color: #f9f9f9;
            border-radius: 10px;
            padding: 20px;
            margin-bottom: 20px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease;
        }
        .service:hover {
            transform: scale(1.05);
        }
        .service h2 {
            color: #333;
            font-size: 24px; /* Ajustar tamaño de fuente para que sea igual que el menú */
            font-weight: bold; /* Ajustar peso de fuente para que sea igual que el menú */
        }
        .service p {
            color: #666;
            font-size: 18px; /* Ajustar tamaño de fuente para que sea igual que el menú */
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
            margin-right: 10px;
        }
        .login-button:hover {
            background-color: #0056b3;
        }
        .warning {
            background-color: #ffeb3b;
            padding: 20px;
            margin-bottom: 20px;
            border-radius: 5px;
        }
        .warning p {
            margin: 0;
            font-weight: bold;
        }
        .warning a {
            color: #333;
            text-decoration: underline;
            margin: 0 10px;
        }
        .warning a:hover {
            color: #000;
        }
        .user-box {
            position: absolute;
            top: 10px;
            right: 10px;
            background-color: #f9f9f9;
            padding: 5px 10px;
            border-radius: 5px;
            box-shadow: 0px 0px 5px rgba(0, 0, 0, 0.3);
        }
        /* Estilos para el menú de reportes */
        .menu-container {
            display: flex;
            justify-content: center; /* Centrar horizontalmente */
        }
        .menu {
            width: 300px;
            background-color: #82ccdd;
            border-radius: 10px;
            padding: 20px;
            margin-top: 20px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease;
        }
        .menu:hover {
            transform: scale(1.05);
        }
        .menu ul {
            list-style-type: none;
            padding: 0;
        }
        .menu li {
            margin-bottom: 15px;
            font-size: 18px;
            transition: transform 0.3s ease;
        }
        .menu li a {
            text-decoration: none;
            color: #fff;
            font-weight: bold;
        }
        .menu li a:hover {
            color: #007bff;
        }
        .auto-style2 {
        color: #0000FF;
    }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 style="font-size: 56px; color: #1917eb; margin-bottom: 20px;">Bienvenido a la Clínica Veterinaria</h1>
        <p style="font-size: 36px; color: #1917eb;">Donde cuidamos de tus mascotas como si fueran de la familia</p>

        <div id="warningMsg" class="warning" style="display:none;">
            <p>¿Se encuentra registrado?</p>
            <a href="Login.aspx">Sí</a>
            <a href="Registro.aspx">No</a>
        </div>

        <div class="services">
            <div class="service" style="background-color: #ff6b6b;">
                <h2 style="color: #fff;">Atención Médica</h2>
                <p style="color: #fff;">Ofrecemos servicios médicos completos para el bienestar de tu mascota, incluyendo exámenes de rutina, vacunaciones y tratamiento de enfermedades.</p>
            </div>
            <div class="service" style="background-color: #ffa94d;">
                <h2 style="color: #fff;">Cirugía</h2>
                <p style="color: #fff;">Nuestro equipo médico altamente capacitado realiza procedimientos quirúrgicos seguros y efectivos, desde esterilizaciones hasta cirugías más complejas.</p>
            </div>
            <div class="service" style="background-color: #717cd1;">
                <h2 style="color: #fff;">Emergencias</h2>
                <p style="color: #fff;">Estamos disponibles las 24 horas del día, los 7 días de la semana, para atender emergencias veterinarias y garantizar la salud y seguridad de tu mascota.</p>
            </div>
            <div class="service" style="background-color: #87cc58;">
                <h2 style="color: #fff;">Odontología</h2>
                <p style="color: #fff;">Cuidamos la salud dental de tu mascota con limpiezas profesionales, extracciones dentales y otros tratamientos para mantener una sonrisa sana.</p>
            </div>
        </div>

        <!-- Botones de Login y Registro -->
        <div style="margin-top: 20px;">
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="login-button" OnClick="btnLogin_Click" />
            <asp:Button ID="btnRegistro" runat="server" Text="Registro" CssClass="login-button" OnClick="btnRegistro_Click" />
        </div>

        <!-- Cuadro de usuario logueado -->
        <div class="user-box" id="userBox" runat="server" Visible="false">
            Usuario: <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
            <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
        </div>

        <!-- Menú de reportes -->
        <div class="menu-container">
            <div class="menu" id="menu" runat="server" Visible="false">
                <p class="auto-style2"><strong>Por favor seleccione una opción de reporte:</strong></p>
                <ul>
                    <li><a href="Reportes.aspx">REPORTE DE USUARIOS</a></li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
