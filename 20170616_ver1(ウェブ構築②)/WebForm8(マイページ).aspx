<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm8(マイページ).aspx.cs" Inherits="_20170616_ver1_ウェブ構築__.WebForm8_マイページ_" %>
<link href="StyleSheet８.css" rel="stylesheet" type="text/css" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p style="margin:0;">ユーザー名<asp:Label runat="server" ID="lblUsername" BackColor="#0A0845" ForeColor="WhiteSmoke" Text="username" CssClass="csslblusername" ></asp:Label></p>
            <p style="margin:0;">メールアドレス<asp:Label runat="server" ID="lblmail" BackColor="#0A0845" ForeColor="WhiteSmoke" Text="mailaddress" CssClass="csslblusername"></asp:Label></p>
            <br>
            <p style="margin:0;">投稿数<asp:Label runat="server" ID="lblTokosu" BackColor="#0A0845" ForeColor="WhiteSmoke" Text="tokosu" CssClass="csslblusername"></asp:Label></p>
            <input type="button" value="ホームに戻る" onclick="location.href = 'WebForm6(Menuサンプル).aspx'" onmouseover="this.style.background='#66cdaa'" onmouseout="this.style.background='#ffffff'"  style="width:95px; margin-left:auto" />
            <asp:Button ID="Button1" runat="server" Text="投稿一覧" CssClass="cssbotton" OnClick="Button1_Click" />
            <br>
            <asp:Table ID="Tabletoukouitiran" runat="server" CssClass="csstable"></asp:Table>
            <div id="toukouitiran" runat="server"></div>
        </div>

        <div runat="server" id="myimagelist">

        </div>
    </form>
</body>
</html>
