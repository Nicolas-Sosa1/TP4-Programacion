<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4_Grupo18_Porgramcion.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblDestinoInicio" runat="server" Text="DESTINO INICIO" Font-Underline="True"></asp:Label>
            <br /><br />
            PROVINCIA:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlProvinciaInicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvinciaInicio_SelectedIndexChanged"></asp:DropDownList>
            <br /><br />
            LOCALIDAD:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlLocalidadInicio" runat="server"></asp:DropDownList>
            <br /><br />
        </div>
        <asp:Label ID="lblDestinoFinal" runat="server" Font-Underline="True" Text="DESTINO FINAL"></asp:Label>
        <p>
            PROVINCIA:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlProvinciaFinal" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            LOCALIDAD:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlLocalidadFinal" runat="server">
            </asp:DropDownList>
        </p>
    </form>
</body>
</html>
