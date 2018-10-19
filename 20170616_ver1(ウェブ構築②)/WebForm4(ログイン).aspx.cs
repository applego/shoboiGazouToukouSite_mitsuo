using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace _20170616_ver1_ウェブ構築__
{
    public partial class WebForm4_ログイン_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            if (logintxt_mailaddress.Value == "" || logintxt_password.Value == "")
            {
                MessageBox.Show("未入力の項目があります");
                return;
            }

            if (Check_Username()) //ユーザー名とパスワードが一致すればtrue ユーザー名が存在しなければfalseを返す
            {
                //ログイン成功
                string sui = Session["ログインユーザーID"].ToString();
                string sun = Session["ログインユーザー名"].ToString();
                Response.Redirect("WebForm6(Menuサンプル).aspx?userid=" + sui+"&username="+sun);
            }
            

        }

        #region■ method―――――――――――――――――――――――――――――――――――――――――――――――――――――――↓
        protected bool Check_Username()
        {
            string li_mailaddress = logintxt_mailaddress.Value;
            string li_password = logintxt_password.Value;

            using (SqlConnection cn = new SqlConnection(Global.strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT [ユーザーID],[ユーザー名],[メールアドレス],[パスワード] FROM [UserInfo] WHERE [メールアドレス] = '" + li_mailaddress + "' AND [削除フラグ] = 0";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows) //メールアドレスが存在するかチェック
                            {
                                string userid_afUserCheck = reader["ユーザーID"].ToString();
                                string username_afUserCheck = reader["ユーザー名"].ToString();
                                string useraddress_afUserCheck = reader["メールアドレス"].ToString();
                                string pass_afUserCheck = reader["パスワード"].ToString();
                                reader.Close();
                                //if(Check_Password(userid_afUserCheck,pass_afUserCheck))   //パスワードチェック
                                if (pass_afUserCheck == li_password)   //パスワードチェック
                                {
                                    Session.Add("ログインユーザーID", userid_afUserCheck);
                                    Session.Add("ログインユーザー名", username_afUserCheck);
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("正しくない（メールアドレスとパスワードが一致しません）");
                                    
                                }
                            }
                            else
                            {
                                MessageBox.Show("正しくない（入力したメールアドレスは存在しない）");
                                
                            }
            
                            //Response.Redirect("WebForm4(ログイン).aspx");
                            return false;
                        }

                    }
                }
                finally { cn.Close(); }
            }
        }
        
        #endregion
            }
}