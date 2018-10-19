<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3(変更).aspx.cs" Inherits="_20170616_ver1_ウェブ構築__.WebForm3_変更_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ユーザー変更</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div style=" /*background-color: lightblue;*/ display:inline-block; width: 479px;" title="ユーザーの変更">
            <ul style="display:inline; list-style:none">
                <li style="width: 472px">
                    <asp:Label ID="Label21" runat="server" Text="ユーザー名" ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtBox_username" runat="server"></asp:TextBox>
                </li>

                <li style="width: 469px">
                    <asp:Label ID="Label22" runat="server" Text="メールアドレス" ForeColor="Black"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtBox_address" runat="server"></asp:TextBox>
                </li>
                <li style="width: 475px">
                    <asp:Label ID="Label23" runat="server" Text="パスワード" ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtBox_password" runat="server"></asp:TextBox>
                </li>
            </ul>
        </div>
        <br />
        <%--<input type ="button" value="追加" onclick="adduser_con()" />
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>--%>
        
        <asp:Button ID="btn_UpdateUser" runat="server" OnClick="btn_UpdateUser_Click" Text="変更" /><br /><br /><input type="button" value="管理画面に戻る" onclick="location.href ='WebForm1.aspx'" />   <%--ID="btn_back" runat="server" OnClick="btn_back_Click" Text="管理画面に戻る" />--%>
        
        <br />
    </form>
</body>
</html>
