﻿using System.Security.Cryptography;
using System.Text;
using Vive.Crypto.Core;

// ReSharper disable once CheckNamespace
namespace Vive.Crypto
{
    /// <summary>
    /// HMAC_SHA1 哈希加密提供程序
    /// </summary>
    internal sealed class HMACSHA1HashingProvider : HMACHashingBase
    {
        /// <summary>
        /// 初始化一个<see cref="HMACSHA1HashingProvider"/>类型的实例
        /// </summary>
        private HMACSHA1HashingProvider() { }

        /// <summary>
        /// 获取字符串的 HMAC_SHA1 哈希值，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">密钥</param>
        /// <param name="outType">输出类型，默认为<see cref="OutType.Hex"/></param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static string Signature(string value, string key, OutType outType = OutType.Hex,
            Encoding encoding = null) => Encrypt<HMACSHA1>(value, key, encoding, outType);

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="comparison">对比的值</param>
        /// <param name="value">待加密的值</param>
        /// <param name="key">密钥</param>
        /// <param name="outType">输出类型，默认为<see cref="OutType.Hex"/></param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static bool Verify(string comparison, string value, string key, OutType outType = OutType.Hex,
            Encoding encoding = null) => comparison == Signature(value, key, outType, encoding);
    }

    /// <summary>
    ///  HMAC_SHA1 哈希加密提供程序
    /// </summary>
    internal class HMACSHA1Hashing : AbsHashingProvider
    {
        /// <summary>
        /// 初始化一个<see cref="HMACSHA1Hashing"/>类型的实例
        /// </summary>
        public HMACSHA1Hashing() : this(OutType.Hex, Encoding.UTF8)
        {
        }
        /// <summary>
        /// 初始化一个<see cref="HMACSHA1Hashing"/>类型的实例
        public HMACSHA1Hashing(OutType outType = OutType.Hex, Encoding encoding = null) : base(outType, encoding)
        {
        }

        /// <summary>
        /// 获取字符串的 HMAC_SHA1 哈希值，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">密钥</param>
        /// <param name="outType">输出类型，默认为<see cref="OutType.Hex"/></param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public override string Signature(string value, string key) => HMACSHA1HashingProvider.Signature(value, key, OutType, Encoding);

    }
}
