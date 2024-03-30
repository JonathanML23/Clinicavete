<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="reportes.aspx.cs" Inherits="Clinicavete.reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilos CSS para dar formato moderno y profesional */
        .container {
            margin: auto;
            width: 50%;
            padding: 20px;
            background-color: #f2f2f2;
            border-radius: 10px;
            box-shadow: 0px 0px 10px 0px rgba(0,0,0,0.1);
        }
        .title {
            text-align: center;
            margin-bottom: 20px;
            font-size: 24px;
        }
        .button {
            display: block;
            margin: 0 auto;
            padding: 10px 20px;
            background-color: #4CAF50;
            color: white;
            text-align: center;
            text-decoration: none;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s;
        }
        .button:hover {
            background-color: #45a049;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="title">Menú de Reportes de Usuarios</h1>
        <asp:DropDownList ID="ComboBoxReportes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ComboBoxReportes_SelectedIndexChanged">
            <asp:ListItem Text="-- Selecciona un reporte --" Value="" />
            <asp:ListItem Text="Reporte de Usuarios Registrados" Value="UsuariosRegistrados" />
            <asp:ListItem Text="Reporte de Usuarios Activos/Inactivos" Value="UsuariosActivosInactivos" />
            <asp:ListItem Text="Reporte de Usuarios por Fecha de Registro" Value="UsuariosPorFechaRegistro" />
            <asp:ListItem Text="Todos los Usuarios" Value="TodosUsuarios" />
        </asp:DropDownList>
        <br />
        <asp:GridView ID="GridViewReporte" runat="server" Visible="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
             <div class="container">
        </div>
        <asp:Button ID="ButtonSalir" runat="server" CssClass="button" Text="Salir" OnClick="ButtonSalir_Click" />
    </div>
</asp:Content>
