<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3-B.aspx.cs" Inherits="TP4_Grupo18_Porgramcion.Ejercicio3_B" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Listado de libros:<br />
            <br />
            <asp:GridView ID="gvLibros" runat="server">
            </asp:GridView>
            <br />
            <asp:LinkButton ID="lbConsultar" runat="server">Consultar otro tema</asp:LinkButton>
            <br />
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
