using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace _20170616_ver1_ウェブ構築__
{
    public partial class WebForm6_Menuサンプル_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string userid = Request.QueryString["userid"];
            //string username = Request.QueryString["username"];

            string userid = Session["ログインユーザーID"].ToString();
            string username = Session["ログインユーザー名"].ToString();

            //string test2 = hf.Value;
            LabelUserName.Text = username;  //ログインユーザー名表示

            List<string> Usertimelist = Get_UserTimeList();
            List<string> Imagelist = Get_ImageList();
            List<string> TextList = Get_TextList();
            SetImageTag(Usertimelist, Imagelist, TextList);
        } 

        protected void kakushilogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("WebForm4(ログイン).aspx");
        }

        #region■ method―――――――――――――――――――――――――――――――――――――――――――――――――――――――↓

        protected List<string> Get_UserTimeList()
        {
            List<string> result = new List<string>();
            
            using (SqlConnection cn = new SqlConnection(Global.strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT [ユーザーID],[ユーザー名],[元ファイル名],[ファイル名],[テキスト],[投稿日時] FROM [dbo].[GazoInfo] WHERE [削除フラグ] = '0'";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            StringBuilder sb = new StringBuilder();

                            while (reader.Read())
                            {
                                sb.Append(reader["ユーザー名"].ToString()+" ");
                                sb.Append(reader["投稿日時"]).ToString();
                                result.Add(sb.ToString());
                                sb.Clear();
                            }
                        }
                    }
                }
                finally { cn.Close(); }
            }

            return result;
        }

        protected List<string> Get_ImageList()
        {
            List<string> result = new List<string>();
            //UploadFile uf = new UploadFile();
            // uf.Userid = Convert.ToInt32(Session["ログインユーザーID"]);

            using (SqlConnection cn = new SqlConnection(Global.strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT [ユーザーID],[元ファイル名],[ファイル名],[テキスト],[投稿日時] FROM [dbo].[GazoInfo] WHERE [削除フラグ] = '0'";
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

        protected List<string> Get_TextList()
        {
            List<string> result = new List<string>();
            
            using (SqlConnection cn = new SqlConnection(Global.strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT [ユーザーID],[元ファイル名],[ファイル名],[テキスト],[投稿日時] FROM [dbo].[GazoInfo] WHERE [削除フラグ] = '0'";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(reader["テキスト"].ToString());
                            }
                        }
                    }
                }
                finally { cn.Close(); }
            }

            return result;
        }

        protected void SetImageTag(List<string> usertimeImage, List<string> lstImage,List<string> textImage)
        {
            //pnlheader,pnlImage,pnlfooter
            Image img;
            for (int i = 0; i < lstImage.Count; i++)
            {
                System.Web.UI.WebControls.Panel pnlImage = new System.Web.UI.WebControls.Panel();

                var lbl = new System.Web.UI.WebControls.Label();
                lbl.Text = usertimeImage[i];
                pnlImage.Controls.Add(lbl);
                lbl.CssClass = "clstb";

                img = new Image();
                img.ImageUrl = lstImage[i];
                pnlImage.Controls.Add(img);
                img.CssClass = "clsImage";

                var lbl2 = new System.Web.UI.WebControls.Label();
                lbl2.Text = textImage[i];
                pnlImage.Controls.Add(lbl2);
                lbl2.CssClass = "clstb2";

                pnlImage.CssClass = "panel-default";
                pnlImageBox.Controls.Add(pnlImage);
            }
        }
        #endregion

        protected void redirect_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.OriginalString);
        }
    }
}