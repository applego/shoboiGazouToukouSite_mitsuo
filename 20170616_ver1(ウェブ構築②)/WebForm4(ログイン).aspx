<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4(ログイン).aspx.cs" Inherits="_20170616_ver1_ウェブ構築__.WebForm4_ログイン_" %>
<%--<link href="StyleSheet1(ログイン).css" rel="stylesheet" type="text/css" />--%>
<link href="StyleSheet2(ログイン自作1).css" rel="stylesheet" type="text/css" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<script src="//Scripts/jquery-1.10.2.min.js"></script>--%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ログイン画面</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Times Square</h1>
        <input type="text" runat="server" id="logintxt_mailaddress" placeholder="MailAddress" autocomplete="off" />
        <input type="password" runat="server" id="logintxt_password" placeholder="Password" />
        <asp:Button ID="btn_Login" runat="server" OnClick="btn_Login_Click" CssClass="btnlogin" Text="Login" />
    </form>
    <div>
    </div>
   
</body>
</html>
