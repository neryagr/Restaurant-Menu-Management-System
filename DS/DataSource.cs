using System.Collections.Generic;
using BE;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System;
using System.Reflection;
using System.Linq;

namespace DS
{
    

    public static class DataSource
    {
        
        public static List<Dish> DishList { get; set; }
       
        public static List<Order> OrderList { get; set; }
        
        public static List<Braunch> BraunchList { get; set; }
        
        public static List<Client> ClientList { get; set; }
       
        public static List<Ordered_Dish> OrderedDishList { get; set; }
        public static void close()
        {
            FileStream fs;
            fs = new FileStream(@"dishes.xml", FileMode.OpenOrCreate);
            XmlSerializer xmls = new XmlSerializer(DishList.GetType());
            xmls.Serialize(fs, DishList);
            fs.Close();
            fs = new FileStream(@"orders.xml", FileMode.OpenOrCreate);
            xmls = new XmlSerializer(OrderList.GetType());
            xmls.Serialize(fs, OrderList);
            fs.Close();
            fs = new FileStream(@"braunches.xml", FileMode.OpenOrCreate);
            xmls = new XmlSerializer(BraunchList.GetType());
            xmls.Serialize(fs, BraunchList);
            fs.Close();
            fs = new FileStream(@"clients.xml", FileMode.OpenOrCreate);
            xmls = new XmlSerializer(ClientList.GetType());
            xmls.Serialize(fs, ClientList);
            fs.Close();
            fs = new FileStream(@"ordereddish.xml", FileMode.OpenOrCreate);
            xmls = new XmlSerializer(OrderedDishList.GetType());
            xmls.Serialize(fs, OrderedDishList);
            fs.Close();
        }
        public static void open()
        {
            try
            {

                FileStream fs;
                fs = new FileStream(@"clients.xml", FileMode.OpenOrCreate);
                XmlSerializer xmls = new XmlSerializer(typeof(List<Client>));
                ClientList = (List<Client>)xmls.Deserialize(fs);
                fs.Close();

                fs = new FileStream(@"orders.xml", FileMode.OpenOrCreate);
                xmls = new XmlSerializer(typeof(List<Order>));
                OrderList = (List<Order>)xmls.Deserialize(fs);
                fs.Close();
                fs = new FileStream(@"braunches.xml", FileMode.OpenOrCreate);
                xmls = new XmlSerializer(typeof(List<Braunch>));
                BraunchList = (List<Braunch>)xmls.Deserialize(fs);
                fs.Close();

                fs = new FileStream(@"ordereddish.xml", FileMode.OpenOrCreate);
                xmls = new XmlSerializer(typeof(List<Ordered_Dish>));
                OrderedDishList = (List<Ordered_Dish>)xmls.Deserialize(fs);
                fs.Close();
                fs = new FileStream(@"Dishes.xml", FileMode.OpenOrCreate);
                xmls = new XmlSerializer(typeof(List<Dish>));
                DishList = (List<Dish>)xmls.Deserialize(fs);
                fs.Close();
            }
            catch (Exception ex)
            {

            }
        }
        public static void Addx<t>(this t a)
        {
            pathAttribute v =a.GetType().GetCustomAttribute<pathAttribute>();
            a.t_to_xml().Save(v.path);  
        }
        public static void removex<t>(this t a)
        {
            XElement x = a.t_to_xml();
            x.Remove();
            x.Save(a.GetType().GetCustomAttribute<pathAttribute>().path);
        }
        public static void update<t>(this t a)
        {
            XElement x = (from item in a.Get_Allx()
                          where item.get_key() == a.get_key()
                          select item).FirstOrDefault().t_to_xml();
            x.removex();
            a.Addx();
        }
        static string get_key<t>(this t a )
        {
            return (string)a.GetType().GetProperty(a.GetType().GetCustomAttribute<pathAttribute>().key).GetValue(a);
        }
        static XElement t_to_xml<t>(this t a)
        {
            pathAttribute v = a.GetType().GetCustomAttribute<pathAttribute>();
            XElement Root = new XElement(v.name);
            foreach (var item in a.GetType().GetProperties())
            {
                XElement x = new XElement(item.Name, item.GetValue(a));
                Root.Add(x);
            }
            return Root;
        }
        public static IEnumerable<t> Get_Allx<t>(this t a)
        {
            FileStream fs;
            fs = new FileStream(a.GetType().GetCustomAttribute<pathAttribute>().path, FileMode.OpenOrCreate);
            XmlSerializer xmls = new XmlSerializer(typeof(List<t>));
            return (List<t>)xmls.Deserialize(fs);
        }
    }
}
    

