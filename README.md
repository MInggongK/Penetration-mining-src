# 渗透测试漏洞挖掘src集成版

一款集成了H3C,致远，泛微，万户，帆软，海康威视，金蝶云星空，畅捷通，Struts等多个RCE的漏洞利用工具 

程序采用C#开发,首次使用请安装依赖： NET6.0 声明：仅用于授权测试，用户滥用造成的一切后果和作者无关 请遵守法律法规！

目前已完成工具部分RCE功能，由于各种原因，目前项目尚未完善，感兴趣的朋友可以下载项目源码，手动添加其他功能

H3C iMC 存在远程命令执行漏洞（RCE +批量RCE）

致远log4j2远程代码执行漏洞（RCE+MSF反弹）

致远一键检测（RCE+利用）

泛微一键漏洞检测（RCE+利用）

海康威视CVE-2021-36260 (RCE+批量RCE）

海康威视 fastjson反序列化漏洞（RCE+批量检测）

海康威视 IVMS任意文件上传漏洞（RCE getshell)

海康威视isecure center 综合安防管理平台文件上传漏洞

致远OA wpsAssistServlet 任意文件上传漏洞(getshell+批量检测)

金蝶云星空反序列化漏洞(RCE）

畅捷通T+任意文件上传(CNVD-2022-60632 )

泛微 E-Office文件上传漏洞（CVE-2023-2523)

万户OA fileUpload.controller 任意文件上传漏洞

Struts+RCE

界面：

![image](https://github.com/MInggongK/Penetration-mining-src/blob/main/%E6%B8%97%E9%80%8F%E6%B5%8B%E8%AF%95%E6%BC%8F%E6%B4%9E%E6%8C%96%E6%8E%98src%E9%9B%86%E6%88%90%E7%89%88/dsf.png)

![image](https://github.com/MInggongK/Penetration-mining-src/blob/main/%E6%B8%97%E9%80%8F%E6%B5%8B%E8%AF%95%E6%BC%8F%E6%B4%9E%E6%8C%96%E6%8E%98src%E9%9B%86%E6%88%90%E7%89%88/sda.png)

部分功能RCE执行效果：

海康威视 IVMS任意文件上传漏洞（RCE getshell)

![image](https://github.com/MInggongK/Penetration-mining-src/blob/main/%E6%B8%97%E9%80%8F%E6%B5%8B%E8%AF%95%E6%BC%8F%E6%B4%9E%E6%8C%96%E6%8E%98src%E9%9B%86%E6%88%90%E7%89%88/fdg.png)

![image](https://github.com/MInggongK/Penetration-mining-src/blob/main/%E6%B8%97%E9%80%8F%E6%B5%8B%E8%AF%95%E6%BC%8F%E6%B4%9E%E6%8C%96%E6%8E%98src%E9%9B%86%E6%88%90%E7%89%88/dsfsd.png)

畅捷通T+任意文件上传(CNVD-2022-60632 ) 任意文件上传漏洞
内置预编译文件，工具将自动上传，可以一键getshell

![image](https://github.com/MInggongK/Penetration-mining-src/blob/main/%E6%B8%97%E9%80%8F%E6%B5%8B%E8%AF%95%E6%BC%8F%E6%B4%9E%E6%8C%96%E6%8E%98src%E9%9B%86%E6%88%90%E7%89%88/gjhg.png)





