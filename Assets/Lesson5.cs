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
        #region ֪ʶ��һ Socket�׽��ֵ�����
        //����C#�ṩ��������������ͨ�ŵ�һ���ࣨ���������Ե���Ҳ�ж�Ӧ��Socket�ࣩ
        //������Socket
        //�����ռ䣺System.Net.Sockets

        //Socket�׽�����֧��TCP/IP����ͨ�ŵĻ���������λ
        //һ���׽��ֶ���������¹ؼ���Ϣ
        //1.������IP��ַ�Ͷ˿�
        //2.�Է�������IP��ַ�Ͷ˿�
        //3.˫��ͨ�ŵ�Э����Ϣ

        //һ��Sccket�����ʾһ�����ػ���Զ���׽�����Ϣ
        //�����Ա���Ϊһ������ͨ��
        //���ͨ��������ͻ��˺ͷ����֮��
        //���ݵķ��ͺͽ��ܾ�ͨ�����ͨ������

        //һ����������������Ϸʱ�����ǻ�ʹ��Socket�׽�����Ϊ���ǵ�ͨ�ŷ���
        //����ͨ�������ӿͻ��˺ͷ���ˣ�ͨ�������շ���Ϣ
        //����԰�������������һ�����ӣ����ڿͻ��˺ͷ����Ӧ�ó����ϣ�ͨ��������������ݽ�����Ϣ
        #endregion

        #region ֪ʶ��� Socket������
        //Socket�׽�����3�ֲ�ͬ������
        //1.���׽���
        //  ��Ҫ����ʵ��TCPͨ�ţ��ṩ���������ӡ��ɿ��ġ�����ġ������޲�������ظ������ݴ������
        //2.���ݱ��׽���
        //  ��Ҫ����ʵ��UDPͨ�ţ��ṩ�������ӵ�ͨ�ŷ������ݰ��ĳ��Ȳ��ܴ���32KB�����ṩ��ȷ�Լ�飬����֤˳�򣬿��ܳ����ط�����ʧ�����
        //3.ԭʼ�׽��֣������ã������뽲�⣩
        //  ��Ҫ����ʵ��IP���ݰ�ͨ�ţ�����ֱ�ӷ���Э��ĽϵͲ㣬�����������ͷ������ݰ�

        //ͨ��Socket�Ĺ��캯�� ���ǿ���������ͬ���͵��׽���
        //Socket s = new Socket()
        //����һ��AddressFamily ����Ѱַ ö�����ͣ�����Ѱַ����
        //  ���ã�
        //  1.InterNetwork  IPv4Ѱַ
        //  2.InterNetwork6 IPv6Ѱַ
        //  ���˽⣺
        //  1.UNIX          UNIX���ص�������ַ 
        //  2.ImpLink       ARPANETIMP��ַ
        //  3.Ipx           IPX��SPX��ַ
        //  4.Iso           ISOЭ��ĵ�ַ
        //  5.Osi           OSIЭ��ĵ�ַ
        //  7.NetBios       NetBios��ַ
        //  9.Atm           ����ATM�����ַ

        //��������SocketType �׽���ö�����ͣ�����ʹ�õ��׽�������
        //  ���ã�
        //  1.Dgram         ֧�����ݱ�����󳤶ȹ̶��������ӡ����ɿ�����Ϣ(��Ҫ����UDPͨ��)
        //  2.Stream        ֧�ֿɿ���˫�򡢻������ӵ��ֽ�������Ҫ����TCPͨ�ţ�
        //  ���˽⣺
        //  1.Raw           ֧�ֶԻ�������Э��ķ���
        //  2.Rdm           ֧�������ӡ�������Ϣ���Կɿ���ʽ���͵���Ϣ
        //  3.Seqpacket     �ṩ�����ֽ��������������ҿɿ���˫����

        //��������ProtocolType Э������ö�����ͣ������׽���ʹ�õ�ͨ��Э��
        //  ���ã�
        //  1.TCP           TCP�������Э��
        //  2.UDP           UDP�û����ݱ�Э��
        //  ���˽⣺
        //  1.IP            IP����Э��
        //  2.Icmp          Icmp������Ϣ����Э��
        //  3.Igmp          Igmp���������Э��
        //  4.Ggp           ���ص�����Э��
        //  5.IPv4          InternetЭ��汾4
        //  6.Pup           PARCͨ�����ݰ�Э��
        //  7.Idp           Internet���ݱ�Э��
        //  8.Raw           ԭʼIP���ݰ�Э��
        //  9.Ipx           Internet���ݰ�����Э��
        //  10.Spx          ˳�������Э��
        //  11.IcmpV6       ����IPv6��Internet������ϢЭ��

        //2��3�����ĳ��ô��䣺
        //       SocketType.Dgram  +  ProtocolType.Udp  = UDPЭ��ͨ�ţ����ã���Ҫѧϰ��
        //       SocketType.Stream  +  ProtocolType.Tcp  = TCPЭ��ͨ�ţ����ã���Ҫѧϰ��
        //       SocketType.Raw  +  ProtocolType.Icmp  = Internet���Ʊ���Э�飨�˽⣩
        //       SocketType.Raw  +  ProtocolType.Raw  = �򵥵�IP��ͨ�ţ��˽⣩

        //���Ǳ������յ�
        //TCP���׽���
        Socket socketTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //UDP���ݱ��׽���
        Socket socketUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        #endregion

        #region ֪ʶ���� Socket�ĳ�������
        //1.�׽��ֵ�����״̬
        if(socketTcp.Connected)
        {

        }
        //2.��ȡ�׽��ֵ�����
        print(socketTcp.SocketType);
        //3.��ȡ�׽��ֵ�Э������
        print(socketTcp.ProtocolType);
        //4.��ȡ�׽��ֵ�Ѱַ����
        print(socketTcp.AddressFamily);

        //5.�������л�ȡ׼����ȡ������������
        print(socketTcp.Available);

        //6.��ȡ����EndPoint����(ע�� ��IPEndPoint�̳�EndPoint)
        //socketTcp.LocalEndPoint as IPEndPoint

        //7.��ȡԶ��EndPoint����
        //socketTcp.RemoteEndPoint as IPEndPoint
        #endregion

        #region ֪ʶ���� Socket�ĳ��÷���
        //1.��Ҫ���ڷ����
        //  1-1:��IP�Ͷ˿�
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
        socketTcp.Bind(ipPoint);
        //  1-2:���ÿͻ������ӵ��������
        socketTcp.Listen(10);
        //  1-3:�ȴ��ͻ�������
        socketTcp.Accept();

        //2.��Ҫ���ڿͻ���
        //  1-1:����Զ�̷����
        socketTcp.Connect(IPAddress.Parse("118.12.123.11"), 8080);

        //3.�ͻ��˷���˶����õ�
        //  1-1:ͬ�����ͺͽ�������
        //  1-2:�첽���ͺͽ�������
        //  1-3:�ͷ����Ӳ��ر�Socket������Close����
        socketTcp.Shutdown(SocketShutdown.Both);
        //  1-4:�ر����ӣ��ͷ�����Socket������Դ
        socketTcp.Close();
        #endregion

        #region �ܽ�
        //��ڿ�����ֻ�Ƕ�Socket��һ���������ʶ
        //��ҪҪ�����ĸ������
        //TCP��UDP���ֳ�����ͨ�ŷ������ǻ���Socket�׽��ֵ�
        //����֮��ֻ��Ҫʹ�����еĸ��ַ������Ϳ��Խ����������Ӻ�����ͨ����
        //��ڿα������յ����ݾ����������TCP��UDP��Socket�׽���
        #endregion
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
