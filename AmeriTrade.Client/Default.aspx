<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AmeriTrade.Client.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlOpcao" runat="server" Visible="false">
            <asp:Label Text="Selecione a opção" runat="server" />
            &nbsp;<asp:CheckBox ID="chkGetAccounts" runat="server" Text="GetAccounts" Checked="true" OnCheckedChanged="chkGetAccounts_CheckedChanged" AutoPostBack="true" />
            &nbsp;<asp:CheckBox ID="chkGetAccount" runat="server" Text="GetAccount" Checked="false" OnCheckedChanged="chkGetAccount_CheckedChanged" AutoPostBack="true" />
            <asp:HiddenField ID="hdnGetAccounts" runat="server" Value="" />
            <asp:HiddenField ID="hdnGetAccount" runat="server" Value="" />
        </asp:Panel>
    </form>
</body>
</html>
