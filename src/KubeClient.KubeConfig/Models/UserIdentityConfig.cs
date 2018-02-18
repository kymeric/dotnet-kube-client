﻿using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using YamlDotNet.Serialization;

namespace KubeClient.KubeConfig.Models
{
    /// <summary>
    ///     User identity configuration for a Kubernetes client.
    /// </summary>
    public class UserIdentityConfig
    {
        /// <summary>
        ///     A Base64-encoded string containing the access token to use (will be placed in the "Authorization" header).
        /// </summary>
        [YamlMember(Alias = "token")]
        public string Token { get; set; }

        /// <summary>
        ///     A file containing the PEM-encoded client certificate to use.
        /// </summary>
        [YamlMember(Alias = "client-certificate")]
        public string ClientCertificateFile { get; set; }

        /// <summary>
        ///     A file containing the PEM-encoded private key associated with the client certificate to use.
        /// </summary>
        [YamlMember(Alias = "client-key")]
        public string ClientKeyFile { get; set; }

        /// <summary>
        ///     The client certificate to use (Base64-encoded bytes representing a PEM block).
        /// </summary>
        [YamlMember(Alias = "client-certificate-data")]
        public string ClientCertificateData { get; set; }

        /// <summary>
        ///     The private key to use (Base64-encoded bytes representing a PEM block).
        /// </summary>
        [YamlMember(Alias = "client-key-data")]
        public string ClientKeyData { get; set; }

        /// <summary>
        ///     Get the user's client certificate (if configured).
        /// </summary>
        /// <returns>
        ///     The certificate (with private key), as an <see cref="X509Certificate2"/>, if configured; otherwise, <c>null</c>.
        /// </returns>
        public X509Certificate2 GetClientCertificate()
        {
            string certificatePem, keyPem;
            if (!String.IsNullOrWhiteSpace(ClientCertificateFile) && !String.IsNullOrWhiteSpace(ClientKeyFile))
            {
                certificatePem = File.ReadAllText(ClientCertificateFile);
                keyPem = File.ReadAllText(ClientKeyFile);
            }
            else if (!String.IsNullOrWhiteSpace(ClientCertificateData) && !String.IsNullOrWhiteSpace(ClientKeyData))
            {
                certificatePem = Encoding.ASCII.GetString(
                    Convert.FromBase64String(ClientCertificateData)
                );
                keyPem = Encoding.ASCII.GetString(
                    Convert.FromBase64String(ClientKeyData)
                );
            }
            else
                return null;

            string pemPassword = Guid.NewGuid().ToString("N"); // AF: Not cryptographically-secure, but honestly in this context who cares?
            byte[] pfxData = CryptoHelper.BuildPfx(certificatePem, keyPem, pemPassword);

            return new X509Certificate2(pfxData, pemPassword);
        }
    }
}