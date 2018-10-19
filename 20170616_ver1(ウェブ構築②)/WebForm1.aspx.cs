using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace _20170616_ver1_ウェブ構築__
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DrowUserInfo();
        }

        protected void btn_go_adduser_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx?para=add");
        }
    
        
        //削除処理
        protected void btn_Kakushi_Click(object sender, EventArgs e)
        {
            //Literal1.Text = "<script type=\"text/javascript\" >window.onload=myconfirm(\"alsdfad\");</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "confirm('ユーザーを削除してよろしいですか？');", true);

            //string cScript = "alert('ClientScript');";
            //string sScript = "alert('StartupScript');";

            //ClientScript.RegisterClientScriptBlock(this.GetType(), "key3", cScript, true);
            //ClientScript.RegisterStartupScript(this.GetType(), "key4", sScript, true);

                string userid = hf.Value;
                DeleteUserInfo(userid);
                Response.Redirect("WebForm1.aspx");
         
        }
        

        #region■ method―――――――――――――――――――――――――――――――――――――――――――――――――――――――↓
        

        #region ■DrowFirstRowメソッド
        protected void DrowFirstRow()
        {
            TableRow r = new TableRow();
            TableCell c;

            c = new TableCell();
            c.Text = "ユーザーID";
            r.Cells.Add(c);

            c = new TableCell();
            c.Text = "ユーザー名";
            r.Cells.Add(c);

            c = new TableCell();
            c.Text = "パスワード";
            r.Cells.Add(c);

            c = new TableCell();
            c.Text = "メールアドレス";
            r.Cells.Add(c);

            c = new TableCell();
            c.Text = "投稿数";
            r.Cells.Add(c);

            c = new TableCell();
            c.Text = "登録日時";
            r.Cells.Add(c);

            c = new TableCell();
            c.Text = "削除フラグ";
            r.Cells.Add(c);

            c = new TableCell();
            c.Text = "削除日時";
            r.Cells.Add(c);

            c = new TableCell();
            c.Text = "変更";
            r.Cells.Add(c);

            c = new TableCell();
            c.Text = "削除";
            r.Cells.Add(c);

            r.BackColor = Color.Aquamarine;
            tbl_UserInfo.Rows.Add(r);
        }
        #endregion
        #region■DrowUserInfoメソッド（DB UserInfoの内容を表示）
        protected void DrowUserInfo()
        {
            DrowFirstRow(); //DrowFirstRow()

            using (SqlConnection cn = new SqlConnection(Global.strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT [ユーザーID],[ユーザー名],[パスワード],[メールアドレス],[投稿数],[登録日時],[削除フラグ],[削除日時] FROM [UserInfo]";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            TableRow r;
                            TableCell c;

                            while (reader.Read())
                            {
                                r = new TableRow();
                                c = new TableCell();
                                c.Text = reader["ユーザーID"].ToString();
                                r.Cells.Add(c);

                                c = new TableCell();
                                c.Text = reader["ユーザー名"].ToString();
                                r.Cells.Add(c);

                                c = new TableCell();
                                c.Text = reader["パスワード"].ToString();
                                r.Cells.Add(c);

                                c = new TableCell();
                                c.Text = reader["メールアドレス"].ToString();
                                r.Cells.Add(c);

                                c = new TableCell();
                                c.Text = reader["投稿数"].ToString();
                                r.Cells.Add(c);

                                c = new TableCell();
                                c.Text = reader["登録日時"].ToString();
                                r.Cells.Add(c);

                                c = new TableCell();
                                c.Text = reader["削除フラグ"].ToString();
                                c.BackColor = ChangeColumnColor(c.Text); //ChangeColumnColor()メソッド
                                r.Cells.Add(c);

                                c = new TableCell();
                                c.Text = reader["削除日時"].ToString();
                                r.Cells.Add(c);

                                c = new TableCell();
                                string userid = reader["ユーザーID"].ToString();
                                c.Text = "<button type=\"button\" onclick=\"location.href='WebForm2.aspx?userId="+ userid + "&para=update'\"  style=\"background-color:#fffafa;\" onmouseover=\"this.style.background='#87ceeb'\" onmouseout=\"this.style.background='#fffafa'\">変更</button>";
                                r.Cells.Add(c);

                                //aspボタンコントロール追加 
                                //c = new TableCell();
                                //var b = new System.Web.UI.WebControls.Button();
                                ////b.OnClientClick = "'sethidden_userId(" + userId + ")'";
                                //b.OnClientClick = "\"btn_Kakushi_Click(" + userId + ");\"";
                                //b.CssClass = "b_delete";
                                ////b.Style.Add("background-color", "#fffafa");
                                //b.Attributes.Add("onmouseover", "");
                                ////b.Click += 
                                //c.Controls.Add(b);
                                //r.Cells.Add(c);

                                c = new TableCell();
                                string userId = reader["ユーザーID"].ToString();
                                c.Text = "<button type=\"button\" BorderColor=\"Black\" onclick=\"onDelete_Click(" + userId + ")\"  style=\"background-color:#fffafa;\" onmouseover=\"this.style.background='#ff0000'\" onmouseout=\"this.style.background='#fffafa'\">削除</button>";
                                r.Cells.Add(c);

                                tbl_UserInfo.Rows.Add(r);
                            }
                        }
                    }
                }
                finally { cn.Close(); }
            }
        }
        #endregion

        

        #region■DeleteUserInfoメソッド
        protected void DeleteUserInfo(string userId)
        {
            using (SqlConnection cn = new SqlConnection(Global.strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        //cmd.CommandText = "DELETE FROM [dbo].[UserInfo] WHERE ([ユーザーID]　= "+ userId +")";
                        cmd.CommandText = "UPDATE [dbo].[UserInfo] SET [削除フラグ] = '1',[削除日時] = @削除日時 WHERE[ユーザーID] ='" + userId+ "'";
                        cmd.Parameters.Add("@削除日時", SqlDbType.DateTime).Value = DateTime.Now;

                        cmd.ExecuteNonQuery();
                    }
                }
                finally { cn.Close(); }
            }
        }
        #endregion

        #region■削除フラグ列がTrueだったら色を変えるメソッド
        protected Color ChangeColumnColor(string c_text)
        {
            if (c_text == "True")
            {
                return Color.Gainsboro;
            }
            else
            {
                return Color.White;
            }

        }
        #endregion

        

        #endregion■method
    }



    public class User
    {
        public int id { get; set; } = 0;
        public string name { get; set; } = "";
        public string password { get; set; }

        protected int _abc;
        public int Abc
        {
            get
            {
                return _abc * 100;
            }
            set
            {
                _abc = value * 100;
            }
        }

        public User()
        {
            id = 0;

        }
    }

    class test
    {
        test()
        {
            User u = new User();
            u.name = "testuser";
        }
    }

}