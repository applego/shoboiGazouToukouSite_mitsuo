<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_20170616_ver1_ウェブ構築__.WebForm1" %>
<link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    


</head>
<body>
    <p id="p1"></p>
    <form id="form1" runat="server" name="form2">
        <div>
            <asp:Button ID="btn_go_adduser" runat="server" BackColor="#7DE6FF" BorderColor="Black" ForeColor="Black" OnClick="btn_go_adduser_Click" Text="ユーザーの追加" Width="117px" />
            <br />
            <asp:Table ID="tbl_UserInfo" runat="server" BackColor="White" Font-Size="Smaller" GridLines="Both">
            </asp:Table>
        </div>
        <%--<input type="hidden" name="HIDDEN" value="0" id="hidden1" />--%>
        <asp:HiddenField runat="server" ID="hf" Value="0" />
        <asp:Button ID="btn_Kakushi" runat="server"  OnClick="btn_Kakushi_Click" CssClass="btn_Kakushi"/>
        <asp:Literal ID="Literal1" runat="server"/>
        <br /><input type="button" value="ログインページへ" onclick="location.href='WebForm4(ログイン).aspx'" style="background-color:darkorange;"/>

    </form>

    <script type="text/javascript">
        <!--
        
        function onDelete_Click(userId) {
            if (!window.confirm('ユーザーを削除してよろしいですか？'))
            {
                return false;
            }
            sethidden_userId(userId);
        }
        function sethidden_userId(userid) {
            document.getElementById("hf").value = userid;
            var str = document.getElementById("hf").value;
            document.getElementById("p1").innerHTML = str;

            document.getElementById('btn_Kakushi').click();

            //window.location.href = "WebForm3(変更).aspx?userid=" + userid;
        }
        function myconfirm(message)
        {
            alert(message);
        }

    //--></script>
</body>
</html>
