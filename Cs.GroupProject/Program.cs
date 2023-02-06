using System;

namespace Cs.GroupProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] groups = new Group[0];
            string option;
            do
            {
                Console.WriteLine($"1.Yeni qrup yarat\n2.Qruplara bax\n3.Type deyerine gore qruplara bax\n4. Bugünədək başlamış qruplara bax\n5. son 2 ayda başlamış qruplara bax\n6. bu ayın sonunadək yeni başlayacaq olan qruplara bax\n7. Verilmiş 2 tarix aralığnda başlamış olan qruplara bax\n0.Menudan cix");
                option = Console.ReadLine();
                
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter type");
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                        {
                            Console.WriteLine($"{(byte)item} - {item}");
                        }
                        string typeStr;
                        byte byteType;
                        do
                        {
                             typeStr = Console.ReadLine();
                            byteType = byte.Parse(typeStr);
                        } while (!Enum.IsDefined(typeof(GroupType),byteType));
                        
                        GroupType groupType = (GroupType)byteType;

                        Console.WriteLine("Enter StartDate");
                        string dateStr = Console.ReadLine();

                        DateTime dateTime= Convert.ToDateTime(dateStr);
                        Console.WriteLine("Enter GroupNo");
                       string groupNo = Console.ReadLine();
                        Group group = new Group();
                        group.No = groupNo;
                        group.StartDate = dateTime;
                        group.Type = groupType;

                        
                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = group;
                        break;
                        case "2":
                        foreach (var item in groups)
                        {
                            Console.WriteLine($"{item.No}\n{item.Type}\n{item.StartDate}");
                        }
                        break;
                        case"3":
                        Console.WriteLine("Enter want to look type");
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                        {
                            Console.WriteLine($"{(byte)item} - {item}");
                        }
                        string searcType = Console.ReadLine();
                        byte byteType1 = byte.Parse(searcType);
                        GroupType groupType1 = (GroupType)byteType1;
                        foreach (var item in groups)
                        {
                            if (item.Type == groupType1)
                            {
                                Console.WriteLine($"{item.No}\n{item.Type}\n{item.StartDate}");
                            }
                        }
                        break;
                        case"4":
                        DateTime dateTime1 = new DateTime();
                        dateTime1 = DateTime.Now;
                        foreach (var item in groups)
                        {
                            if (item.StartDate<dateTime1)
                            {
                                Console.WriteLine($"{item.No}\n{item.Type}\n{item.StartDate}");

                            }
                            
                        }
                        break;
                        case"5":
                        DateTime dateTime2 = new DateTime();
                        dateTime2 = DateTime.Now;
                        dateTime2 = dateTime2.AddMonths(-2);

                        foreach (var item in groups)
                        {
                            if (item.StartDate>dateTime2 && item.StartDate<DateTime.Now)
                            {
                                Console.WriteLine($"{item.Type}\n{item.No}\n{item.StartDate}");
                            }
                        }

                        break;
                        case"6":
                        DateTime date = new DateTime();
                        date = DateTime.Now;
                        foreach (var item in groups)
                        {
                            if (date<item.StartDate && date.Month==item.StartDate.Month && date.Year == item.StartDate.Year)
                            {
                                Console.WriteLine($"{item.Type}\n{item.No}\n{item.StartDate}");
                            }
                        }
                        break;
                    case "7":
                        Console.WriteLine("1 ci tarixi daxil edin :");
                        var date1 = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("2 - ci tarixi daxil edin");
                        var date2 = Convert.ToDateTime(Console.ReadLine());
                        foreach (var item in groups)
                        {
                            if (item.StartDate > date1 && item.StartDate<date2)
                            {
                                Console.WriteLine($"{item.Type}\n{item.No}\n{item.StartDate}");
                            }
                        }
                        break;
                    case "0":
                        Console.WriteLine("Cixis edildi");
                        break;
                }
            } while (option!="0");
        }
    }
}
