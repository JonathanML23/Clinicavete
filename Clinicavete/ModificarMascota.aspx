<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ModificarMascota.aspx.cs" Inherits="Clinicavete.ModificarMascota" %>
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
            background-color: #007bff;
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
            background-color: #0056b3;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Modificar Mascota</h1>

    <asp:Label ID="lblMensaje" runat="server" CssClass="message-label" ForeColor="Green" Visible="false"></asp:Label>
    <asp:Label ID="lblError" runat="server" CssClass="message-label" ForeColor="Red" Visible="false"></asp:Label>

    <div class="form-container">
        <asp:TextBox ID="txtIDMascota" runat="server" placeholder="ID Mascota"></asp:TextBox>
        <asp:TextBox ID="txtNombreMascota" runat="server" placeholder="Nombre Mascota"></asp:TextBox>
        <asp:TextBox ID="txtTipoMascota" runat="server" placeholder="Tipo Mascota"></asp:TextBox>
        <asp:TextBox ID="txtComidaFavorita" runat="server" placeholder="Comida Favorita"></asp:TextBox>
        <asp:Button ID="btnModificar" runat="server" CssClass="btn" Text="Modificar" OnClick="btnModificar_Click" />
    </div>

</asp:Content>

