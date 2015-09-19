using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;

namespace bdusstool
{
     
    public partial class main : Form
    {
        public static string vcodestr;
        public static string x;
        public static int step = 1;
        public main()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://zhizhe8.net/"); 
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.stus8.com/"); 
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void code_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user.Text == "" || pw.Text == "")
            {
                MessageBox.Show("请填写用户名和密码后再获取验证码", "获取验证码失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                step = 1;
                getcode.Enabled = false;
                getcode.Text = "请稍候";
                var xurl = new Uri("http://wappass.baidu.com/passport/login");
                var post = Encoding.UTF8.GetBytes("username=" + user.Text + "&password=" + pw.Text);
                webcore.Navigate(xurl, null, post, "User-Agent: S Phone\r\n");
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            submit.Enabled = false;
            submit.Text = "请稍候";
            if (webcore.Document.Cookie.Length <= 0)
            {
                webcore.Document.Cookie.Remove(0, webcore.Document.Cookie.Length);
            }
            webcore.Document.GetElementById("login_username").SetAttribute("value", user.Text);
            webcore.Document.GetElementById("login_loginpass").SetAttribute("value", pw.Text);
            webcore.Document.GetElementsByTagName("input")[15].SetAttribute("value", code.Text);
            webcore.Document.GetElementById("vcodeStr").SetAttribute("value", vcodestr);
            webcore.Document.GetElementsByTagName("input")[17].InvokeMember("Click");
        }

        private void webcore_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (step == 2)
            {
                var p = webcore.DocumentText;
                if (p.Contains("您输入的密码有误"))
                {
                    MessageBox.Show("您输入的密码有误\r\n若要重试，请点击获取验证码后重新输入验证码重试登录", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    step = 1;
                    submit.Text = "提交信息";
                    return;
                }
                if (p.Contains("您输入的验证码有误"))
                {
                    MessageBox.Show("您输入的验证码有误\r\n若要重试，请点击获取验证码后重新输入验证码重试登录", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    step = 1;
                    submit.Text = "提交信息";
                    return;
                }
                if (p.Contains("请您输入验证码"))
                {
                    MessageBox.Show("请您输入验证码\r\n若要重试，请点击获取验证码后重新输入验证码重试登录", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    step = 1;
                    submit.Text = "提交信息";
                    return;
                }
                if (p.Contains("请您输入密码"))
                {
                    MessageBox.Show("请您输入密码\r\n若要重试，请点击获取验证码后重新输入验证码重试登录", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    step = 1;
                    submit.Text = "提交信息";
                    return;
                }
                if (p.Contains("请填写手机/邮箱/用户名"))
                {
                    MessageBox.Show("请填写手机/邮箱/用户名\r\n若要重试，请点击获取验证码后重新输入验证码重试登录", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    step = 1;
                    submit.Text = "提交信息";
                    return;
                }
                if (p.Contains("账号格式错误"))
                {
                    MessageBox.Show("账号格式错误\r\n若要重试，请点击获取验证码后重新输入验证码重试登录", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    step = 1;
                    submit.Text = "提交信息";
                    return;
                }

                var cookie = webcore.Document.Cookie;
                Regex regex = new Regex("BDUSS=.*?; ");
                var bc = regex.Match(cookie).Value;
                bc = bc.Replace("BDUSS=", "");
                bc = bc.Replace("; ", "");
                if (bc.Length <= 0)
                {
                    step = 1;
                    MessageBox.Show("无法登录到百度\r\n若要重试，如果你开启了登录保护，请前往百度安全中心关闭它，然后请点击获取验证码后重新输入验证码重试登录", "登录百度失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    bduss.Text = bc;
                }
                step = 1;
                submit.Text = "提交信息";
                submit.Enabled = true;
            }
            else
            {
                x = Encoding.GetEncoding("UTF-8").GetString(Encoding.Default.GetBytes(webcore.DocumentText));
                Regex vcode_regex = new Regex("<img src=\".*\" alt=\"wait...\" />");
                var s = vcode_regex.Match(x).Value;
                s = s.Replace("<img src=\"", "");
                s = s.Replace("\" alt=\"wait...\" />", "");
                Regex vr_regex = new Regex("<input type=\"hidden\" id=\"vcodeStr\" name=\"vcodestr\" value=\".*\"/>");
                vcodestr = vr_regex.Match(x).Value;
                vcodestr = vcodestr.Replace("<input type=\"hidden\" id=\"vcodeStr\" name=\"vcodestr\" value=\"", "");
                vcodestr = vcodestr.Replace("\"/>", "");
                codeimg.ImageLocation = s;
                if (vcodestr.Length <= 0 || s.Length <= 0)
                {
                    code.Enabled = false;
                    code.Text = "无需验证码";
                }
                else
                {
                    code.Enabled = true;
                    code.Text = "";
                }
                step = 2;
                getcode.Enabled = true;
                getcode.Text = "获取验证码";
                submit.Enabled = true;
            }
        }
    }
}
