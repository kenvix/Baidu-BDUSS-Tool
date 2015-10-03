using System;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.IO;

namespace bdusstool
{

    public partial class main : Form
    {
        string vcodestr;
        int gottenVerifyCode = -1;
        public main()
        {
            InitializeComponent();
            Text += version.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        #region 界面上的链接
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            Process.Start("http://zhizhe8.net/"); 
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.stus8.com/"); 
        }
        #endregion

        #region 用户点击获取验证码按钮
        private void getVerifyCode()
        {
            if (string.IsNullOrEmpty(user.Text) || string.IsNullOrEmpty(pw.Text))
            {
                MessageBox.Show("请填写用户名和密码后再获取验证码", "获取验证码失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var xurl = new Uri("http://wappass.baidu.com/passport/login");
                var post = Encoding.UTF8.GetBytes("username=" + user.Text + "&password=" + pw.Text);
                WebClient wc = new WebClient();
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                wc.Headers.Add("User-Agent", "X Phone");
                wc.UploadDataCompleted += Wc_UploadDataCompleted;
                wc.UploadDataAsync(xurl, post);
            }
        }
        #endregion

        #region 当获取到验证码时
        private void Wc_UploadDataCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            var x = Encoding.GetEncoding("UTF-8").GetString(e.Result);
            Regex vcode_regex = new Regex("<img src=\".*\" alt=\"wait...\" />");
            var s = vcode_regex.Match(x).Value;
            s = s.Replace("<img src=\"", "");
            s = s.Replace("\" alt=\"wait...\" />", "");
            Regex vr_regex = new Regex("<input type=\"hidden\" id=\"vcodeStr\" name=\"vcodestr\" value=\".*\"/>");
            vcodestr = vr_regex.Match(x).Value;
            vcodestr = vcodestr.Replace("<input type=\"hidden\" id=\"vcodeStr\" name=\"vcodestr\" value=\"", "");
            vcodestr = vcodestr.Replace("\"/>", "");
            codeimg.ImageLocation = s;
            gottenVerifyCode++;
            if (vcodestr.Length <= 0 && s.Length <= 0 && gottenVerifyCode > 3)
            {
                code.Enabled = false;
                code.Text = "无需验证码";
            }
            else if(vcodestr.Length <= 0 && s.Length <= 0 &&  gottenVerifyCode < 3)
            {
                getVerifyCode();
                return;
            }
            else
            {
                code.Enabled = true;
                code.Text = "";
            }
        }
        #endregion

        #region 用户点击提交按钮
        private void submit_Click(object sender, EventArgs e)
        {
            submitInfo();
        }

        private void submitInfo()
        {
            if (gottenVerifyCode == -1)
            {
                getVerifyCode();
                return;
            }
            if (string.IsNullOrEmpty(user.Text) || string.IsNullOrEmpty(pw.Text))
            {
                MessageBox.Show("请填写用户名、密码后再获取BDUSS", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (code.Enabled && string.IsNullOrEmpty(code.Text))
            {
                MessageBox.Show("请填写验证码", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                submit.Enabled = false;
                submit.Text = "请稍候";
                string xurl = "http://wappass.baidu.com/passport/?verifycode=" + code.Text;
                string post = "username=" + user.Text +
                           "&password=" + pw.Text +
                           "&verifycode=" + code.Text +
                           "&login_save=3" +
                           "&vcodestr=" + vcodestr +
                           "&aaa=%E7%99%BB%E5%BD%95" +
                           "&login=yes" +
                           "&can_input=0" +
                           "&u=http%3A%2F%2Fm.baidu.com%2F%3Faction%3Dlogin" +
                           "&tn&tpl&ssid=000000&form=0&bd_page_type=1" +
                           "&bd_page_type=1&uid=wiaui_1316933575_9548&isPhone=isPhone";

                string cookie = "";
                string result = "";
                Thread th = new Thread(() => {
                    try
                    {
                        var wb = (HttpWebRequest)WebRequest.Create(xurl);
                        wb.Method = "POST";
                        wb.ContentType = "application/x-www-form-urlencoded";
                        wb.UserAgent = "Phone adasdasasf5e1asd";
                        wb.ContentLength = post.Length;
                        wb.CookieContainer = new CookieContainer();
                        Stream qr = wb.GetRequestStream();
                        qr.Write(Encoding.UTF8.GetBytes(post), 0, post.Length);
                        Stream ws = wb.GetResponse().GetResponseStream();
                        StreamReader wr = new StreamReader(ws);
                        result = wr.ReadToEnd();
                        cookie = wb.CookieContainer.GetCookieHeader(new Uri(xurl));
                        wr.Close();
                    }
                    catch (Exception ex)
                    {
                        error("网络请求出错：\r\n" + ex.Message, "登录百度失败");
                    }

                });
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                while (!th.Join(25))
                {
                    Application.DoEvents();
                }
                #region 检查是否成功登录
                if (result.Contains("您输入的密码有误"))
                {
                    MessageBox.Show("您输入的密码有误\r\n若要重试，请点击获取验证码后重新输入验证码重试登录", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loginBaiduFailed();
                    return;
                }
                if (result.Contains("您输入的验证码有误"))
                {
                    MessageBox.Show("您输入的验证码有误\r\n若要重试，请点击获取验证码后重新输入验证码重试登录", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loginBaiduFailed();
                    return;
                }
                if (result.Contains("请您输入验证码"))
                {
                    MessageBox.Show("请您输入验证码\r\n若要重试，请点击获取验证码后重新输入验证码重试登录", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loginBaiduFailed();
                    return;
                }
                if (result.Contains("请您输入密码"))
                {
                    MessageBox.Show("请您输入密码\r\n若要重试，请点击获取验证码后重新输入验证码重试登录", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loginBaiduFailed();
                    return;
                }
                if (result.Contains("请填写手机/邮箱/用户名"))
                {
                    MessageBox.Show("请填写手机/邮箱/用户名\r\n若要重试，请点击获取验证码后重新输入验证码重试登录", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loginBaiduFailed();
                    return;
                }
                if (result.Contains("账号格式错误"))
                {
                    MessageBox.Show("账号格式错误\r\n若要重试，请点击获取验证码后重新输入验证码重试登录", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loginBaiduFailed();
                    return;
                }
                #endregion
                Regex regex = new Regex("BDUSS=.*?; ");
                var bc = regex.Match(cookie).Value;
                bc = bc.Replace("BDUSS=", "");
                bc = bc.Replace("; ", "");
                if (bc.Length <= 0)
                {
                    MessageBox.Show("无法登录到百度\r\n若要重试，如果你开启了登录保护，请前往百度安全中心关闭它，然后请点击获取验证码后重新输入验证码重试登录", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    bduss.Text = bc;
                }
                submit.Text = "提交信息";
                submit.Enabled = true;
            }
        }

        #endregion

        #region 当提交用户信息完成后
        private void Wb_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            /*
            var p = Encoding.GetEncoding("UTF-8").GetString(e.Result);
           

            //var cookie = ;
            
            */
        }
        #endregion

        private void loginBaiduFailed()
        {
            submit.Text = "提交信息";
            submit.Enabled = true;
        }

        void error(string msg, string title = "错误")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void hidePwd_CheckedChanged(object sender, EventArgs e)
        {
            if(hidePwd.Checked)
            {
                pw.PasswordChar = '*';
            }
            else
            {
                pw.PasswordChar = new char() ;
            }
        }

        private void codeimg_Click(object sender, EventArgs e)
        {
            getVerifyCode();
        }

        private void tip_Click(object sender, EventArgs e)
        {
            getVerifyCode();
        }

        private void user_KeyDown(object sender, KeyEventArgs e)
        {
            checkKeyDown(e);
        }

        void checkKeyDown(KeyEventArgs e)
        {
            if (e.KeyValue == 13)     //检测是否按Enter键
            {
                submitInfo();
            }
        }

        private void pw_KeyDown(object sender, KeyEventArgs e)
        {
            checkKeyDown(e);
        }

        private void code_KeyDown(object sender, KeyEventArgs e)
        {
            checkKeyDown(e);
        }
    }
}
