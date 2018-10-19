using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace _20170616_ver1_ウェブ構築__
{
    public partial class WebForm3_変更_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_UpdateUser_Click(object sender, EventArgs e)
        {
            update_userbtn();
            
        }

        #region■ method―――――――――――――――――――――――――――――――――――――――――――――――――――――――↓

        #region■　接続文字列を入手するメソッド
        public string GetConnectionString()
        {
            var builder = new SqlConnectionStringBuilder()
            {
                DataSource = "Y-TSUNESHIGE",
                InitialCatalog = "FireTrain2",
                IntegratedSecurity = true, //User ID および Password を接続文字列中に指定するか (false の場合)、現在の Windows アカウントの資格情報を認証に使用するか (true の場合) を示すブール値を取得または設定します。
                //UserID = "y-tsuneshige",
                //Password = "mnnef10132"
            };
            return builder.ToString();
        }
        #endregion
        #region■update_userbtn()メソッド　ユーザー情報変更の確認メッセージボックス　YESならUserInfoを変更
        protected void update_userbtn()
        {


            if (txtBox_username.Text == "" || txtBox_address.Text == "" || txtBox_password.Text == "")
            {
                
                MessageBox.Show("未入力の項目があります", "エラー");
                return;
            }

            DialogResult result = MessageBox.Show("変更を登録してよろしいですか?", "確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                string userid = Request.QueryString["userId"];
                UpdateUserInfo(userid);
                MessageBox.Show("変更が完了しました");
                Response.Redirect("WebForm1.aspx");
            }
            else if (result == DialogResult.No)
            {
                return;
            }

        }
        #endregion

        #region■UpdateUserInfoメソッド
        protected void UpdateUserInfo(string userid)
        {
            string username = txtBox_username.Text;
            string useraddress = txtBox_address.Text;
            string userpass = txtBox_password.Text;

            string strCon = GetConnectionString();
            using (SqlConnection cn = new SqlConnection(strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE [dbo].[UserInfo]SET[ユーザー名] = @ユーザー名,[パスワード] = @パスワード,[メールアドレス] = @メールアドレス WHERE [ユーザーID]　=" +userid;
                        cmd.Parameters.Add("@ユーザー名", SqlDbType.NVarChar).Value = username;
                        cmd.Parameters.Add("@パスワード", SqlDbType.NVarChar).Value = userpass;
                        cmd.Parameters.Add("@メールアドレス", SqlDbType.NVarChar).Value = useraddress;
                        
                        cmd.ExecuteNonQuery();
                    }
                }
                finally { cn.Close(); }
            }
        }
        #endregion

        #endregion
    }
}