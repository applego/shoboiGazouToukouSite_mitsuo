using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace _20170616_ver1_ウェブ構築__
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // アプリケーションのスタートアップで実行するコードです
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static readonly string strCon = "Data Source=Y-TSUNESHIGE;Initial Catalog=FireTrain2;Integrated Security=True"; //;User ID=y-tsuneshige;Password=mnnef10132
        
        public string getValueGazoInfo()
        {
            return "";
        }
    }
}