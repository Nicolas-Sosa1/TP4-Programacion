<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3.aspx.cs" Inherits="TP4_Grupo18_Porgramcion.Ejercicio3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Seleccionar Tema:&nbsp;
            <asp:DropDownList ID="ddlTemas" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:LinkButton ID="lbVerLibros" runat="server">Ver libros</asp:LinkButton>
        </div>
    </form>
</body>
</html>
