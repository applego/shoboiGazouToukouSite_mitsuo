using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace _20170616_ver1_ウェブ構築__
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string para = Request.QueryString["para"];

            if (para == "add")
            {
                btn_UpdateUser.Visible = false;
            }
            else if(para == "update")
            {
                btn_AddUser.Visible = false;

                //テキストボックスの初期値をセット
                string userId = Request.QueryString["userId"];

                string preUsername = getValueUserInfo("ユーザー名",userId);   //引数　列名　ユーザーID　で指定の値を返す（UserInfoテーブル）
                txtBox_username.Text = preUsername;

                string preMailaddress = getValueUserInfo("メールアドレス", userId);
                txtBox_address.Text = preMailaddress;

                string prePassword = getValueUserInfo("パスワード", userId);
                txtBox_password.Text = prePassword;

            }
             
        }
        protected void addUserkakushi_Click(object sender, EventArgs e)
        {
            Adduserbtn();
        }
        protected void btn_UpdateUser_Click(object sender, EventArgs e)
        {
            update_userbtn();
        }

        #region■ method―――――――――――――――――――――――――――――――――――――――――――――――――――――――↓

        public string getValueUserInfo(string Cname, string userid)
        {
            using (SqlConnection cn = new SqlConnection(Global.strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT [" + Cname + "] AS Result FROM [FireTrain2].[dbo].[UserInfo] WHERE [ユーザーID] = '" + userid + "'";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            string result = reader["Result"].ToString();
                            return result;
                        }
                    }
                }
                finally { cn.Close(); }
            }
        }

        #region■Adduserbtn()メソッド　ユーザー追加の確認メッセージボックス　YESならUserInfoに追加
        protected void Adduserbtn()
        {
            if (txtBox_username.Text == "" || txtBox_address.Text == "" || txtBox_password.Text == "")
            {
                MessageBox.Show("未入力の項目があります", "エラー");
                return;
            }

            //if (IsSameAddress())
            //{
                
            //}

            if (IsValidMailAddress(txtBox_address.Text))    //アドレス形式チェック　return true or false
            {
                DialogResult result = MessageBox.Show("ユーザーを追加してよろしいですか?", "確認",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    //INSERTメソッド
                    INSERT_UserInfo();
                    MessageBox.Show("ユーザーの登録が完了しました");
                    Response.Redirect("WebForm1.aspx");
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("メールアドレスの形が正しくありません");
            }

        }
        #endregion

        #region■指定された文字列がメールアドレスとして正しい形式か検証する
        protected static bool IsValidMailAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                return false;
            }

            try
            {
                System.Net.Mail.MailAddress a =
                    new System.Net.Mail.MailAddress(address);
            }
            catch (FormatException)
            {
                //FormatExceptionがスローされた時は、正しくない
                return false;
            }

            return true;
        }
        #endregion

        #region■ユーザー名,パスワード,メールアドレス,登録日時
        protected void INSERT_UserInfo()
        {
            string username = txtBox_username.Text;
            string useraddress = txtBox_address.Text;
            string userpass = txtBox_password.Text;

            using (SqlConnection cn = new SqlConnection(Global.strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO [dbo].[UserInfo]([ユーザー名],[パスワード],[メールアドレス],[投稿数],[登録日時]) " +
                                                        "VALUES(@ユーザー名,@パスワード,@メールアドレス,@投稿数,@登録日時)";
                        cmd.Parameters.Add("@ユーザー名", SqlDbType.NVarChar).Value = username;
                        cmd.Parameters.Add("@パスワード", SqlDbType.NVarChar).Value = userpass;
                        cmd.Parameters.Add("@メールアドレス", SqlDbType.NVarChar).Value = useraddress;
                        cmd.Parameters.Add("@投稿数", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@登録日時", SqlDbType.DateTime).Value = DateTime.Now;

                        cmd.ExecuteNonQuery();
                    }
                }
                finally { cn.Close(); }
            }

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
                UpdateUserInfo(userid);  //UpdateUserInfoメソッド
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

            using (SqlConnection cn = new SqlConnection(Global.strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE [dbo].[UserInfo]SET[ユーザー名] = @ユーザー名,[パスワード] = @パスワード,[メールアドレス] = @メールアドレス WHERE [ユーザーID]　=" + userid;
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