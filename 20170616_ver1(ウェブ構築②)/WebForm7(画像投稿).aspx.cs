using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Windows.Forms;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace _20170616_ver1_ウェブ構築__
{
    public partial class WebForm7_画像投稿_ : System.Web.UI.Page
    {
        UploadFile uf;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            uf = new UploadFile();
            string sui = Session["ログインユーザーID"].ToString();
            uf.Userid = Convert.ToInt32(sui);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            
            if (!FileUpload1.HasFile)
            {
                return;
            }
            else
            {   
                //UploadFileクラスを作って使ってみた
                uf.Userfilename = Server.HtmlEncode(FileUpload1.FileName);
                
                uf.Svrfilename = Session.SessionID.ToString() + DateTime.Now.ToString("yyyyMMddhhmmssfff") + Path.GetExtension(FileUpload1.FileName);
                uf.FileUrl = "~/temp/" + uf.Svrfilename;

                //アップロードファイルが画像かどうかチェック
                string fileExtension = Path.GetExtension(uf.FileUrl).ToLower();
                string[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for(int i = 0; i< allowedExtensions.Length; i++)
                {
                    if(fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }

                if (fileOK)
                {
                    //画像表示
                    ViewGazo(uf.FileUrl);

                    //画像保存
                    uf.FilePath = Server.MapPath("temp/") + uf.Svrfilename;
                    FileUpload1.SaveAs(uf.FilePath);

                    //imageurl session使う
                    Session.Add("userfileNeme", uf.Userfilename);
                    Session.Add("FileUrl", uf.FileUrl);

                    Button2.Visible = true;
                }
                else
                {
                    Literal1.Text = "<script type=\"text/javascript\" >alert(\"この形式のファイルはアップロードできません\");</script>";
                    //MessageBox.Show("この形式のファイルはアップロードできません");
                    return;
                }
            }
        }


        protected void Button2_Click1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("表示されている画像（みつおさん）をアップロードしてよろしいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.OK)
            {
                //imageurl session使う
                uf.Userfilename = Session["userfileNeme"].ToString();
                uf.FileUrl = Session["FileUrl"].ToString();

                //INSERTメソッド
                INSERT_Gazo(uf.Userfilename, uf.FileUrl, TextBox1.Text);
                MessageBox.Show("登録完了");
                TextBox1.Text = "";
            }
            else
            {
                return;
            }
        }

        #region■ method―――――――――――――――――――――――――――――――――――――――――――――――――――――――↓

        protected void ViewGazo(string furl)
        {
            Image1.ImageUrl = furl;
            Image1.Visible = true;
        }
        protected void INSERT_Gazo(string userfilename,string fname,string ftext)
        {
            //uf.Userid = Convert.ToInt32(Session["ログインユーザーID"]);
            uf.Username = Session["ログインユーザー名"].ToString();

            using (SqlConnection cn = new SqlConnection(Global.strCon))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO [dbo].[GazoInfo]([ユーザーID],[ユーザー名],[元ファイル名],[ファイル名],[テキスト],[投稿日時])VALUES(@ユーザーID,@ユーザー名,@元ファイル名,@ファイル名,@テキスト,@投稿日時)";
                        cmd.Parameters.Add("@ユーザーID", SqlDbType.Int).Value = uf.Userid;
                        cmd.Parameters.Add("@ユーザー名", SqlDbType.NVarChar).Value = uf.Username;
                        cmd.Parameters.Add("@元ファイル名", SqlDbType.NVarChar).Value = userfilename;
                        cmd.Parameters.Add("@ファイル名", SqlDbType.NVarChar).Value = fname;
                        cmd.Parameters.Add("@テキスト", SqlDbType.NVarChar).Value = ftext;
                        cmd.Parameters.Add("@投稿日時", SqlDbType.DateTime).Value = DateTime.Now;

                        cmd.ExecuteNonQuery();
                    }
                }
                finally { cn.Close(); }
            }
        }

        #endregion

        
    }

    public class UploadFile
    {
        private int userid;
        public int Userid { set { userid = value; }get { return userid; } }

        private string username;
        public string Username { set { username = value; } get { return username; } }

        private string userfilename;
        public string Userfilename { set { userfilename = value; } get { return userfilename; } }

        private string svrfilename;
        public string Svrfilename { set { svrfilename = value; }get { return svrfilename; } }

        private string filePath;
        public string FilePath { set { filePath = value; }get { return filePath; } }


        private string fileUrl;
        public string FileUrl { set { fileUrl = value; } get { return fileUrl; } }

    }
}

//button1_click
//ファイルアクセス 可能かどうか (アクセス不可ならtrue,可能ならfalse?)
                //IsFileLocked(uf.FileUrl);
//method
//C# で ファイルアクセス 可能かどうか を 調べる方法
//protected bool IsFileLocked(string path)
//{
//    FileStream stream = null;

//    try
//    {
//        stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
//    }
//    catch
//    {
//        return true;
//    }
//    finally
//    {
//        if(stream != null)
//        {
//            stream.Close();
//        }
//    }
//    return false;
//}