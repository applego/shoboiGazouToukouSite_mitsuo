<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm6(Menuサンプル).aspx.cs" Inherits="_20170616_ver1_ウェブ構築__.WebForm6_Menuサンプル_" %>

<link href="StyleSheet６.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <header role="banner">
            <div class="header__avatar">
                <p id="Clock1" style="display: block"></p>
                <br>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LabelUserName" runat="server" Text="Label" CssClass="labUserName"></asp:Label>
                <br />
                <asp:Button ID="redirect" runat="server" OnClick="redirect_Click" Text="更新"  CssClass="btn_redirect" />
            </div>
        </header>

        <nav role="navigation">
            <ul class="menu__list">
                <li class="menu__item">
                    <button class="menu__link"  onclick="location.href='WebForm8(マイページ).aspx'; return false;">MY PAGE</button>
                </li>
                <li class="menu__item">
                    <button class="menu__link" onclick="window.open('WebForm7(画像投稿).aspx','','width=500,height=450')">UPLOAD</button>
                </li>
                <li class="menu__item">
                    <button class="menu__link"  onclick="logout()<%--location.href='WebForm4(ログイン).aspx'--%>; return false;">Log out</button><asp:Button ID="kakushilogout" runat="server"  CssClass="kakushi" OnClick="kakushilogout_Click" />
                </li>
            </ul>
        </nav>

        <asp:HiddenField runat="server" ID="hf" Value="0" />

        <footer>
           
        </footer>

        <asp:Panel id="pnlImageBox" runat="server"></asp:Panel>
            <%--<div class="panel-heading" id="pnlheader" runat="server">
            </div>
            <div runat="server" id="pnlImage">
            </div>
            <div class="panel-footer" id="pnlfooter" runat="server">
            </div>--%>
        

      
    </form>
    <script type="text/javascript">
        <!--

    // Initalize page
    setup();

    // Reset button
    $('.reset').click(function () {
        $('.menu__item').removeClass('menu__item--current');
        $('.header__avatar').removeClass('drop');
        $('.reset').blur();
        setup();
    });

    function setup() {
        $('.menu__item').first().addClass('menu__item--current')
        $('.header__avatar').addClass('drop');
    };

    // Menu fx on click 
    $('.menu__link').click(function () {

        // Menu button current selection
        $('.menu__item').removeClass('menu__item--current');
        $(this).parent().addClass('menu__item--current');

        // addClass will put back and trigger animation, so we remove it first
        $('.header__avatar').removeClass('drop');

        // Trigger spin, wait for animation to finish and remove class.
        $('.header__avatar').addClass('spin').delay(400).queue(function (next) {
            $(this).removeClass('spin');
            next();
        });

    });
       //--></script>

    <script type="text/javascript">
        setInterval('showClock1()', 1000);
        function showClock1() {
            var DWs = new Array('Sun.', 'Mon.', 'Tue.', 'Wed.', 'Thu.', 'Fri.', 'Sat.');
            var Now = new Date();
            var YY = Now.getYear();
            if (YY < 2000) { YY += 1900; }
            var MM = set0(Now.getMonth() + 1);
            var DD = set0(Now.getDate());
            var DW = DWs[Now.getDay()];
            var hh = set0(Now.getHours());
            var mm = set0(Now.getMinutes());
            var ss = set0(Now.getSeconds());
            var RTime1 = ' ' + YY + '.' + MM + '.' + DD + ' ' + DW + ' ' + hh + ':' + mm + ':' + ss + ' ';
            document.getElementById("Clock1").innerHTML = RTime1;
        }
        function set0(num) {
            var ret;
            if (num < 10) { ret = "0" + num; }
            else { ret = num; }
            return ret;
        }

        //function sethidden_userId(userid) {
        //    document.getElementById("hf").value = userid;
        //    var str = document.getElementById("hf").value;
        //    document.getElementById("p1").innerHTML = str;

        var parameterLang = decodeURIComponent(location.search.match(/lang=(.*?)(&|$)/)[1]);
        document.getElementById("hf").value = parameterLang;
        var str = document.getElementById("hf").value;
        document.getElementById("p1").innerHTML = str;

        function logout()
        {
            document.getElementById('kakushilogout').click();
        }
    </script>
</body>
</html>
