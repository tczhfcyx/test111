using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class Lesson5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 Socket套接字的作用
        //它是C#提供给我们用于网络通信的一个类（在其它语言当中也有对应的Socket类）
        //类名：Socket
        //命名空间：System.Net.Sockets

        //Socket套接字是支持TCP/IP网络通信的基本操作单位
        //一个套接字对象包含以下关键信息
        //1.本机的IP地址和端口
        //2.对方主机的IP地址和端口
        //3.双方通信的协议信息

        //一个Sccket对象表示一个本地或者远程套接字信息
        //它可以被视为一个数据通道
        //这个通道连接与客户端和服务端之间
        //数据的发送和接受均通过这个通道进行

        //一般在制作长连接游戏时，我们会使用Socket套接字作为我们的通信方案
        //我们通过它连接客户端和服务端，通过它来收发消息
        //你可以把它抽象的想象成一根管子，插在客户端和服务端应用程序上，通过这个管子来传递交换信息
        #endregion

        #region 知识点二 Socket的类型
        //Socket套接字有3种不同的类型
        //1.流套接字
        //  主要用于实现TCP通信，提供了面向连接、可靠的、有序的、数据无差错且无重复的数据传输服务
        //2.数据报套接字
        //  主要用于实现UDP通信，提供了无连接的通信服务，数据包的长度不能大于32KB，不提供正确性检查，不保证顺序，可能出现重发、丢失等情况
        //3.原始套接字（不常用，不深入讲解）
        //  主要用于实现IP数据包通信，用于直接访问协议的较低层，常用于侦听和分析数据包

        //通过Socket的构造函数 我们可以申明不同类型的套接字
        //Socket s = new Socket()
        //参数一：AddressFamily 网络寻址 枚举类型，决定寻址方案
        //  常用：
        //  1.InterNetwork  IPv4寻址
        //  2.InterNetwork6 IPv6寻址
        //  做了解：
        //  1.UNIX          UNIX本地到主机地址 
        //  2.ImpLink       ARPANETIMP地址
        //  3.Ipx           IPX或SPX地址
        //  4.Iso           ISO协议的地址
        //  5.Osi           OSI协议的地址
        //  7.NetBios       NetBios地址
        //  9.Atm           本机ATM服务地址

        //参数二：SocketType 套接字枚举类型，决定使用的套接字类型
        //  常用：
        //  1.Dgram         支持数据报，最大长度固定的无连接、不可靠的消息(主要用于UDP通信)
        //  2.Stream        支持可靠、双向、基于连接的字节流（主要用于TCP通信）
        //  做了解：
        //  1.Raw           支持对基础传输协议的访问
        //  2.Rdm           支持无连接、面向消息、以可靠方式发送的消息
        //  3.Seqpacket     提供排序字节流的面向连接且可靠的双向传输

        //参数三：ProtocolType 协议类型枚举类型，决定套接字使用的通信协议
        //  常用：
        //  1.TCP           TCP传输控制协议
        //  2.UDP           UDP用户数据报协议
        //  做了解：
        //  1.IP            IP网际协议
        //  2.Icmp          Icmp网际消息控制协议
        //  3.Igmp          Igmp网际组管理协议
        //  4.Ggp           网关到网关协议
        //  5.IPv4          Internet协议版本4
        //  6.Pup           PARC通用数据包协议
        //  7.Idp           Internet数据报协议
        //  8.Raw           原始IP数据包协议
        //  9.Ipx           Internet数据包交换协议
        //  10.Spx          顺序包交换协议
        //  11.IcmpV6       用于IPv6的Internet控制消息协议

        //2、3参数的常用搭配：
        //       SocketType.Dgram  +  ProtocolType.Udp  = UDP协议通信（常用，主要学习）
        //       SocketType.Stream  +  ProtocolType.Tcp  = TCP协议通信（常用，主要学习）
        //       SocketType.Raw  +  ProtocolType.Icmp  = Internet控制报文协议（了解）
        //       SocketType.Raw  +  ProtocolType.Raw  = 简单的IP包通信（了解）

        //我们必须掌握的
        //TCP流套接字
        Socket socketTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //UDP数据报套接字
        Socket socketUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        #endregion

        #region 知识点三 Socket的常用属性
        //1.套接字的连接状态
        if(socketTcp.Connected)
        {

        }
        //2.获取套接字的类型
        print(socketTcp.SocketType);
        //3.获取套接字的协议类型
        print(socketTcp.ProtocolType);
        //4.获取套接字的寻址方案
        print(socketTcp.AddressFamily);

        //5.从网络中获取准备读取的数据数据量
        print(socketTcp.Available);

        //6.获取本机EndPoint对象(注意 ：IPEndPoint继承EndPoint)
        //socketTcp.LocalEndPoint as IPEndPoint

        //7.获取远程EndPoint对象
        //socketTcp.RemoteEndPoint as IPEndPoint
        #endregion

        #region 知识点四 Socket的常用方法
        //1.主要用于服务端
        //  1-1:绑定IP和端口
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
        socketTcp.Bind(ipPoint);
        //  1-2:设置客户端连接的最大数量
        socketTcp.Listen(10);
        //  1-3:等待客户端连入
        socketTcp.Accept();

        //2.主要用于客户端
        //  1-1:连接远程服务端
        socketTcp.Connect(IPAddress.Parse("118.12.123.11"), 8080);

        //3.客户端服务端都会用的
        //  1-1:同步发送和接收数据
        //  1-2:异步发送和接收数据
        //  1-3:释放连接并关闭Socket，先与Close调用
        socketTcp.Shutdown(SocketShutdown.Both);
        //  1-4:关闭连接，释放所有Socket关联资源
        socketTcp.Close();
        #endregion

        #region 总结
        //这节课我们只是对Socket有一个大体的认识
        //主要要建立的概念就是
        //TCP和UDP两种长连接通信方案都是基于Socket套接字的
        //我们之后只需要使用其中的各种方法，就可以进行网络连接和网络通信了
        //这节课必须掌握的内容就是如何声明TCP和UDP的Socket套接字
        #endregion
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
