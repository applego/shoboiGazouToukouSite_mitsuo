<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="_20170616_ver1_ウェブ構築__.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ユーザー追加</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div style=" /*background-color: lightblue;*/ display:inline-block; width: 714px;" title="ユーザーの追加">
            <ul style="display:inline; list-style:none">
                <li style="width: 658px">
                    <asp:Label ID="Label1" runat="server" Text="ユーザー名" ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="txtBox_username" runat="server" Text="" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                </li>

                <li style="width: 654px">
                    <asp:Label ID="Label2" runat="server" Text="メールアドレス" ForeColor="Black"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtBox_address" runat="server" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                </li>
                <li style="width: 653px">
                    <asp:Label ID="Label3" runat="server" Text="パスワード" ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:TextBox ID="txtBox_password" runat="server" TextMode="Password" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                </li>
            </ul>
        </div>
        <br />
        <%--<input type ="button" value="追加" onclick="adduser_con()" />
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>--%>
        
        <asp:Button ID="btn_AddUser" runat="server" OnClientClick="js_adduser()" Text="追加" onmouseover="ChangeColor('btn_AddUser','pink','hotpink')" onmouseout="RestoreColor('btn_AddUser')" BorderStyle="Solid" BorderWidth="1px" BorderColor="Black" BackColor="White"/>
        <asp:Button ID="addUserkakushi" runat="server" OnClick="addUserkakushi_Click" Width="0px" Height="0px" BorderWidth="0px" />
        <asp:Button ID="btn_UpdateUser" runat="server" OnClientClick="js_upduser()" Text="変更" onmouseover="ChangeColor('btn_UpdateUser','royalblue','lavender')" onmouseout="RestoreColor('btn_UpdateUser')" BorderStyle="Solid" BorderWidth="1px" BorderColor="Black" BackColor="White"/>
        <asp:Button ID="updUserkakushi" runat="server" OnClick="btn_UpdateUser_Click" Width="0px" Height="0px" BorderStyle="None" />
        <br /><br /><input type="button" value="管理画面に戻る" onclick="location.href = 'WebForm1.aspx'" onmouseover="this.style.background='#66cdaa'" onmouseout="this.style.background='#ffffff'" style="border:1px solid;background-color:white" />
        <div>
            <br />
            <br />
        </div>
    </form>
    <script type="text/javascript">
        //function adduser_con() {
        //    addUsercon = confirm("追加してよろしいですか?");
        //    if (!addUsercon) {
        //        return;
        //    } else{}
        //}
        var previousColor;
        function ChangeColor(id,color,color2)
        {
            previousColor = window.event.srcElement.style.color;
            window.event.srcElement.style.color = color2;

            document.getElementById(id).style.backgroundColor = color;
        }
        function RestoreColor(id)
        {
            window.event.srcElement.style.color = previousColor;
            document.getElementById(id).style.backgroundColor = '#ffffff';
        }
        function js_adduser()
        {
            tUsername = document.getElementById('txtBox_username').value;
            tAddress = document.getElementById('txtBox_address').value;
            tPassword = document.getElementById('txtBox_password').value;

            if (tUsername == "" || tAddress == "" || tPassword == "")
            {
                alert('未入力の項目があります');
                return;
                //var name = prompt("名前を入力してください");
                //document.write(name);
            }

            if (confirm('ユーザーを追加してよろしいですか?')) {
                alert('test');
                var target = document.getElementById("addUserkakushi");
                target.click();
            } else {
                return false;
            }
            

            //return false;
            //myRet = confirm('ユーザーを追加してよろしいですか?');
            //if (myRet)
            //{
                
                
            //}
            //else
            //{
            //    return;
            //}
        }
        function js_upduser()
        {
            alert('test');
            document.getElementById("updUserkakushi").click();
        }
    </script>
</body>
</html>
