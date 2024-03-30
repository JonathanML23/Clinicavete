<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ModificarCita.aspx.cs" Inherits="Clinicavete.ModificarCita" %>

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

        /* Estilos para los controles de formulario */
        .form-container {
            margin-bottom: 20px;
        }

        .form-container label {
            display: block;
            margin-bottom: 5px;
        }

        .form-container input[type="text"],
        .form-container input[type="date"],
        .form-container select,
        .form-container .btn {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }

        /* Estilos para el botón */
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
    <h1>Modificar Cita</h1>

    <asp:Label ID="lblMessage" runat="server" CssClass="message-label" ForeColor="Green" Visible="false"></asp:Label>
    <asp:Label ID="lblError" runat="server" CssClass="message-label" ForeColor="Red" Visible="false"></asp:Label>

    <div class="form-container">
        <label for="txtIDCita">ID de la cita a modificar:</label>
        <asp:TextBox ID="txtIDCita" runat="server"></asp:TextBox>
    </div>

    <div class="form-container">
        <label for="ddlMascota">Seleccione la nueva mascota:</label>
        <asp:DropDownList ID="ddlMascota" runat="server"></asp:DropDownList>
    </div>

    <div class="form-container">
        <label for="txtFecha">Seleccione la nueva fecha:</label>
        <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
    </div>

    <div class="form-container">
        <label for="txtMedico">Nombre del nuevo médico asignado:</label>
        <asp:TextBox ID="txtMedico" runat="server"></asp:TextBox>
    </div>

    <div class="form-container">
        <asp:Button ID="btnModificar" runat="server" CssClass="btn" Text="Modificar" OnClick="btnModificar_Click" />
    </div>
</asp:Content>


