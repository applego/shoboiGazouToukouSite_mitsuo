<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm7(画像投稿).aspx.cs" Inherits="_20170616_ver1_ウェブ構築__.WebForm7_画像投稿_" %>

<link href="StyleSheet7.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>画像投稿</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div>
                <asp:Image ID="Image1" runat="server"  Height="254px" Visible="False" />
                <br />
                <asp:FileUpload ID="FileUpload1" runat="server" Width="250px" BackColor="#FF428D" ForeColor="Black" Font-Size="X-Small"/>
                <br />
                <asp:TextBox ID="TextBox1" runat="server" Width="250px"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" Text="View" OnClick="Button1_Click" />
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <&#8594;>
                <asp:Button ID="Button2" runat="server" Text="UPLOAD" OnClick="Button2_Click1" Visible="False" />
                <%--<div id="output"></div>--%>
            </div>
        </div>
        <asp:HiddenField runat="server" ID="hf" Value="0" />
    </form>
    <script type="text/javascript">
        //function displayFileurl(fileurl) {
        //    document.getElementById('havingFile').innerHTML = fileurl; 
        //    }
        function sethidden_userId(userid) {
            document.getElementById("hf").value = userid;
            var str = document.getElementById("hf").value;
        }
    </script>


</body>
</html>
