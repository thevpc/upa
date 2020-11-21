using System;
using System.IO;
using System.Net;

/**
 * SPECIFIC
 */

namespace Net.TheVpc.Upa.Types
{
    public class URL
    {
        private readonly String url;

        public URL(String url)
        {
            this.url = url;
        }

        public override String ToString()
        {
            return url;
        }

        public Stream OpenStream()
        {
            switch (GetProtocol())
            {
                case "http":
                    {
                        return WebRequest.Create(url).GetResponse().GetResponseStream();
                    }
                case "file":
                    {
                        String localPath = url.Substring("file://".Length).Replace("/", "\\");
                        return new FileStream(localPath, FileMode.Open);
                    }
            }
            return null;
        }

        public String GetPath()
        {
            switch (GetProtocol())
            {
                case "http":
                    {
                        String s = url.Substring("http://".Length);
                        int i = s.IndexOf('/');
                        if (i <0)
                        {
                            return null;
                        }
                        return s.Substring(i);
                    }
                case "file":
                    {
                        return url.Substring("file://".Length);
                    }
            }
            return null;
        }

        public String GetProtocol()
        {
            if (url.ToLower().StartsWith("http://"))
            {
                return "http";
            }
            if (url.ToLower().StartsWith("file://"))
            {
                return "file";
            }
            throw new Exception("Unsupported URL Protocol");
        }
    }
}