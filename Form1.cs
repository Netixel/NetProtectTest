﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetProtect;

namespace NetProtectTest
{
    public partial class Form1 : Form
    {
        
        class User
        {
            public bool isAuthenticated = false;
            public string DownloadKey() { return "";  }
        }
        User user;



        public Form1()
        {
            if(user.isAuthenticated)
            {
                string key = user.DownloadKey();
                JitEncrypt jit = new JitEncrypt("http://your.website.net/netprotect/api.php");
                jit.SetDecryptionKey(key);
                jit.Enable();
            }

            InitializeComponent();

            if(TestlargeHeader())
                NetProtectTestVOID();
        }





        [MethodHash("auto-compute")]//Method hash protection
        [ClrEncrypted(EncryptionType.aes, false)]//AES Enmcryption flag
        public void NetProtectTestVOID()
        {
            this.Text = "Void test";
        }

        [ClrEncrypted(EncryptionType.aes, false)]//[Encryption Type], [Remote Streamed] 
        public bool TestlargeHeader()
        {
            return true;
        }
    }
}
