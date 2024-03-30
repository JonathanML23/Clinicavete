﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="reporteUser.aspx.cs" Inherits="Clinicavete.reporteUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilos para el encabezado */
        h1 {
            color: #333;
            font-size: 24px;
            margin-bottom: 20px;
        }

        /* Estilos para los subtítulos */
        h2 {
            color: #666;
            font-size: 20px;
            margin-bottom: 10px;
        }

        /* Estilos para los botones */
        .button-container {
            margin-bottom: 20px;
        }

        .button-container .btn {
            display: inline-block;
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            text-decoration: none;
            margin-right: 10px;
        }

        .button-container .btn:hover {
            background-color: #0056b3;
        }

        /* Estilos para la línea divisoria */
        hr {
            border: 1px solid #ccc;
            margin: 20px 0;
        }

        /* Estilos para la tabla */
        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            background-color: #fff;
            border: 1px solid #ccc;
            border-radius: 5px;
            overflow: hidden;
        }

        .grid-view th,
        .grid-view td {
            border: 1px solid #ccc;
            padding: 8px;
        }

        .grid-view th {
            background-color: #f2f2f2;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Menu Reporte Usuario</h1>

    <div class="button-container">
        <h2>Opciones de Usuario</h2>
        <asp:Button ID="btnAgregar" runat="server" CssClass="btn" Text="Ir a Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnModificar" runat="server" CssClass="btn" Text="Ir a Modificar" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" runat="server" CssClass="btn" Text="Ir a Eliminar" OnClick="btnEliminar_Click" />
    </div>

    <hr />

    <h2>Usuarios Registrados</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
        <Columns>
            <asp:BoundField DataField="Login_Usuario" HeaderText="Login Usuario" />
            <asp:BoundField DataField="Nombre_Usuario" HeaderText="Nombre Usuario" />
        </Columns>
    </asp:GridView>

</asp:Content>



