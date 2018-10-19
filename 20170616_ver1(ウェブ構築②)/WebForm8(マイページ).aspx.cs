using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _20170616_ver1_ウェブ構築__
{
    public partial class WebForm8_マイページ_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "javascriptmethodname", "confirm('test');", true); 

            try { lblUsername.Text = Session["ログインユーザー名"].ToString();}
            catch { lblUsername.Text = "error"; }

            lblmail.Text =Get_mailaddress();
            lblTokosu.Text = Get_Tokosu();

            List<string> Imagelist = Get_ImageList();
            SetImageTag(Imagelist);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DrowFirstRow();
            DrowUserInfo();
        }

        #region■ method―――――――――――――――――――――――――――――――――――――――――――――――――――――――↓

        //ログインユーザーのメールアドレスを返す
        protected string Get_mailaddress()
        {
            string userid = Session["ログインユーザーID"].ToString();

            using (SqlConnection cn = new SqlConnection(Global.strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT [メールアドレス] FROM [dbo].[UserInfo] WHERE [ユーザーID] =" + userid;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            string mailaddress = reader["メールアドレス"].ToString();
                            return mailaddress;
                        }
                    }
                }
                finally { cn.Close(); }
            }
        }

        //lblTokosu
        //ログインユーザーの投稿数を返す
        protected string Get_Tokosu()
        {
            string userid = Session["ログインユーザーID"].ToString();

            using (SqlConnection cn = new SqlConnection(Global.strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT (*) AS Tokosu FROM GazoInfo WHERE [ユーザーID] = "+ userid;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            string Tokosu = reader["Tokosu"].ToString();
                            return Tokosu;
                        }
                    }
                }
                finally { cn.Close(); }
            }
        }
        protected List<string> Get_ImageList()
        {
            List<string> result = new List<string>();

            string userid = Session["ログインユーザーID"].ToString();

            using (SqlConnection cn = new SqlConnection(Global.strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT [ユーザーID],[元ファイル名],[ファイル名],[テキスト],[投稿日時] FROM [dbo].[GazoInfo] WHERE [削除フラグ] = '0' AND [ユーザーID] =" + userid;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(reader["ファイル名"].ToString());
                            }
                        }
                    }
                }
                finally { cn.Close(); }
            }

            return result;
        }

        protected void SetImageTag(List<string> lstImage)
        {
            //pnlImage
            System.Web.UI.WebControls.Image img;
            for (int i = 0; i < lstImage.Count; i++)
            {
                img = new System.Web.UI.WebControls.Image();
                img.ImageUrl = lstImage[i];
                myimagelist.Controls.Add(img);
                //img.Width = 
                //img.Height =     
                img.CssClass = "clsImage";
                
            }
        }
        #region ■DrowFirstRowメソッド (投稿一覧)
        protected void DrowFirstRow()
        {
            TableRow r = new TableRow();
            TableCell c;

            c = new TableCell();
            c.Text = "画像ID";
            //c.Width = 100;
            //c.Width = c.Text.Length + 100;
            r.Cells.Add(c);

            c = new TableCell();
            c.Text = "元ファイル名";
            c.Width = c.Text.Length + 100;
            r.Cells.Add(c);

            c = new TableCell();
            c.Text = "テキスト";
            c.Width = c.Text.Length + 100;
            r.Cells.Add(c);

            c = new TableCell();
            c.Text = "投稿日時";
            c.Width = c.Text.Length + 150;
            r.Cells.Add(c);
            
            Tabletoukouitiran.Rows.Add(r);
        }
        #endregion
        #region■DrowUserInfoメソッド（DB UserInfoの内容を表示）
        protected void DrowUserInfo()
        {
            string userid = Session["ログインユーザーID"].ToString();

            using (SqlConnection cn = new SqlConnection(Global.strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT [画像ID],[元ファイル名],[テキスト],[投稿日時] FROM [GazoInfo] WHERE [ユーザーID] =" +userid;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            TableRow r;
                            TableCell c;

                            while (reader.Read())
                            {
                                r = new TableRow();
                                
                                c = new TableCell();
                                c.Text = reader["画像ID"].ToString();
                                r.Cells.Add(c);

                                c = new TableCell();
                                c.Text = reader["元ファイル名"].ToString();
                                r.Cells.Add(c);

                                c = new TableCell();
                                c.Text = reader["テキスト"].ToString();
                                r.Cells.Add(c);

                                c = new TableCell();
                                c.Text = reader["投稿日時"].ToString();
                                r.Cells.Add(c);


                                Tabletoukouitiran.Rows.Add(r);
                            }
                        }
                    }
                }
                finally { cn.Close(); }
            }
        }
        #endregion

        #endregion


    }
}