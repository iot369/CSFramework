using System.Security.Cryptography;
using System.IO;
using System.Text;
using System;


/// <summary>
/// 字符串加密组件
/// </summary>
public static class Encrypt
{
    #region "定义加密字串变量"
    private static SymmetricAlgorithm mCSP = new DESCryptoServiceProvider();  //声明对称算法变量
    private const string CIV = "Mi9l/+7Zujhy12se6Yjy111A";  //初始化向量
    private const string CKEY = "jkHuIy9D/9i="; //密钥（常量）
    #endregion

    /// <summary>
    /// 解密字符串
    /// </summary>
    /// <param name="Value">要解密的字符串</param>
    /// <returns>string</returns>
    public static string DecryptString(string Value)
    {
        ICryptoTransform ct; //定义基本的加密转换运算
        MemoryStream ms; //定义内存流
        CryptoStream cs; //定义将数据流链接到加密转换的流
        byte[] byt;

        ct = mCSP.CreateDecryptor(Convert.FromBase64String(CKEY), Convert.FromBase64String(CIV)); //用指定的密钥和初始化向量创建对称数据解密标准
        byt = Convert.FromBase64String(Value); //将Value(Base 64)字符转换成字节数组

        ms = new MemoryStream();
        cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
        cs.Write(byt, 0, byt.Length);
        cs.FlushFinalBlock();
        cs.Close();

        return Encoding.UTF8.GetString(ms.ToArray()); //将字节数组中的所有字符解码为一个字符串
    }
}
