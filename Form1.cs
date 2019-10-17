using System;
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
        public Form1()
        {
            JitEncrypt jit = new JitEncrypt("http://dev.lystic.net/netprotect/test.php");//note this should point to your own web files (you can leave this as is to test on my own hosting)
            jit.Enable();

            InitializeComponent();

            if(TestlargeHeader())
                NetProtectTestVOID();
        }

        [MethodHash("auto-compute")]//This attribute hashes the decrypted bytes to verify they have not been modified during runtime. 
        [ClrEncrypted(EncryptionType.aes, false)]//This attribute signifies that this method is going to be encrypted
        public void NetProtectTestVOID()
        {
            this.Text = "Void test";
        }

        [ClrEncrypted(EncryptionType.aes, false)]//note that the parameters are: [Encryption Type] & [Remote Streamed] 
        public bool TestlargeHeader()
        {
            return true;
        }
    }
}
