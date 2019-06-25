﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string user = username.Value;
        string pass = userpwd.Value;
        string sql = "select * from jz_manager where username='" + user + "'";
        DataTable dt = DAL.SQLHelper.GetDtBySql(sql);
        if (dt.Rows.Count > 0)
        {
            string A = md5(pass, 32);
            if (dt.Rows[0]["password"].ToString() == A)
            {
                Session["userName"] = user;
                if (dt.Rows[0]["number"].ToString() == "0")
                {
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('用户名或密码错误，请重新输入!')</script>");

            }
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('用户名或密码错误，请重新输入!')</script>");
        }
    }


    /// <summary>
    /// 16位MD5加密
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public static string MD5Encrypt16(string password)
    {
        var md5 = new MD5CryptoServiceProvider();
        string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(password)), 4, 8);
        t2 = t2.Replace("-", "");
        return t2;
    }

    /// <summary>
    /// 32位MD5加密
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public static string MD5Encrypt32(string password)
    {
        string cl = password;
        string pwd = "";
        MD5 md5 = MD5.Create(); //实例化一个md5对像
        // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
        byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
        // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
        for (int i = 0; i < s.Length; i++)
        {
            // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
            pwd = pwd + s[i].ToString("X2");
        }
        return pwd;
    }

    /// <summary>
    /// 加密用户密码
    /// </summary>
    /// <param name="password">密码</param>
    /// <param name="codeLength">加密位数</param>
    /// <returns>加密密码</returns>
    public static string md5(string password, int codeLength)
    {
        if (!string.IsNullOrEmpty(password))
        {
            // 16位MD5加密（取32位加密的9~25字符）  
            if (codeLength == 16)
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5").ToLower().Substring(8, 16);
            }

            // 32位加密
            if (codeLength == 32)
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5").ToLower();
            }
        }
        return string.Empty;
    }
}