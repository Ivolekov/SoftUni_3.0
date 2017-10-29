namespace SimpleHttpServer.Models
{
    using Enums;
    using System.Collections.Generic;
    using System.Text;
    public class Header
    {
        public Header(HeaderType type)
        {
            this.Type = type;
            this.Cookies = new CookieCollection();
            this.ContentType = "text/html";
            this.OthersParameters = new Dictionary<string, string>();
        }
        public HeaderType Type { get; set; }

        public string ContentType { get; set; }

        public string ContentLenght { get; set; }

        public Dictionary<string, string> OthersParameters { get; set; }

        public CookieCollection Cookies { get; private set; }
        public string ContentLength { get; internal set; }

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();

            header.AppendLine("Content-type: " + this.ContentType);

            if (this.Cookies.Count > 0)
            {
                if (Type == HeaderType.HttpRequest)
                {
                    header.AppendLine("Cookie: " + this.Cookies.ToString());
                }
                else if (Type == HeaderType.HttpResponse)
                {
                    foreach (var cookie in this.Cookies)
                    {
                        header.AppendLine("Set-Cookie " + cookie);
                    }
                }
            }

            if (ContentLenght != null)
            {
                header.AppendLine("Content-Lenght: " + this.ContentLenght);
            }

            foreach (var parameter in OthersParameters)
            {
                header.AppendLine($"{parameter.Key}: {parameter.Value}");
            }

            header.AppendLine();
            header.AppendLine();

            return header.ToString();
        }
    }
}
