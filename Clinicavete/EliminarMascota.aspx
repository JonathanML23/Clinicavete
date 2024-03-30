<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EliminarMascota.aspx.cs" Inherits="Clinicavete.EliminarMascota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilos para el encabezado */
        h1 {
            color: #333;
            font-size: 24px;
            margin-bottom: 20px;
        }

        /* Estilos para los mensajes */
        .message-label {
            margin-bottom: 10px;
        }

        /* Estilos para el formulario */
        .form-container {
            margin-bottom: 20px;
        }

        .form-container input[type="text"],
        .form-container .btn {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }

        .form-container .btn {
            background-color: #dc3545;
            color: #fff;
            border: none;
            cursor: pointer;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            border-radius: 5px;
            transition: background-color 0.3s ease;
        }

        .form-container .btn:hover {
            background-color: #c82333;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Eliminar Mascota</h1>

    <asp:Label ID="lblMensaje" runat="server" CssClass="message-label" ForeColor="Green" Visible="false"></asp:Label>
    <asp:Label ID="lblError" runat="server" CssClass="message-label" ForeColor="Red" Visible="false"></asp:Label>

    <div class="form-container">
        <asp:TextBox ID="txtIDMascota" runat="server" placeholder="ID Mascota"></asp:TextBox>
        <asp:Button ID="btnEliminar" runat="server" CssClass="btn" Text="Eliminar" OnClick="btnEliminar_Click" />
    </div>

</asp:Content>
