using System.Collections.Generic;
using BE;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System;
using System.Reflection;
using System.Linq;
using System.Xml;

namespace DAL
{
    static class xmltools
    {
        public static void Addx<t>(this t a) where t : new()
        {
            pathAttribute v = a.GetType().GetCustomAttribute<pathAttribute>();
            XElement x = XElement.Load(typeof(t).GetCustomAttribute<pathAttribute>().path);
            x.Add(a.t_to_xml());
            x.Save(v.path);
        }
        public static void removex<t>(string key) where t : new()
        {
         var new_t=   Get_Allx<t>().Where(y => y.get_key() != key).ToList();
            FileStream fss;
            fss = new FileStream(typeof(t).GetCustomAttribute<pathAttribute>().path, FileMode.Create);
            fss.Flush();
            XmlSerializer xmlss = new XmlSerializer(typeof(List<t>));
            xmlss.Serialize(fss, new_t);
            fss.Close();
        }
        public static void update<t>(this t a) where t : new()
        {
            removex<t>(a.get_key());
            a.Addx();
        }
        public static t get_t<t>(string key) where t : new()
        {
            var v = Get_Allx<t>();
            return (from item in v
                    where item.get_key() == key
                    select item).FirstOrDefault();
        }
        public static IEnumerable<t> Get_Allx<t>() where t : new()
        {
            pathAttribute v = typeof(t).GetCustomAttribute<pathAttribute>();
            if (!new FileInfo(typeof(t).GetCustomAttribute<pathAttribute>().path).Exists)
            {

                FileStream fs;
                fs = new FileStream(v.path, FileMode.OpenOrCreate);
                XmlSerializer xmls = new XmlSerializer(typeof(List<t>));
                xmls.Serialize(fs, new List<t>());
                fs.Close();
                return null;
            }
            FileStream fss;
            fss = new FileStream(v.path, FileMode.OpenOrCreate);
            XmlSerializer xmlss = new XmlSerializer(typeof(List<t>));
            List<t> r = (List<t>)xmlss.Deserialize(fss);
            fss.Close();
            return r;
        }
        static string get_key<t>(this t a)
        {
            return (string)a.GetType().GetProperty(a.GetType().GetCustomAttribute<pathAttribute>().key).GetValue(a);
        }
        static XElement t_to_xml<t>(this t a)
        {
            pathAttribute v = a.GetType().GetCustomAttribute<pathAttribute>();
            XElement Root = new XElement(v.name);
            foreach (var item in a.GetType().GetProperties())
            {

                XElement x=new XElement(item.Name, item.GetValue(a));
                if (item.PropertyType == typeof(Address))
                    x = ((Address)item.GetValue(a)).t_to_xml();
                Root.Add(x);
            }
            return Root;
        }


    }
    public class Dal_imp : Idal
    {

        #region dish functions
        public void add_dish(Dish d)
        {
            if (get_dish(d.Name) == null)
                d.Addx();
            else
                throw new Exception("Dish like this is already exist");
        }
        public void remove_dish(string name)
        {
            Dish temp = xmltools.get_t<Dish>(name);
            if (temp == null)
                throw new Exception("that dish don't exist!");
            xmltools.removex<Dish>(name);
        }
        public void update_dish(Dish d)
        {
            Dish temp = get_dish(d.Name);
            if (temp == null)
                throw new Exception("That dish don't exist!");
            else
                temp = d;
        }
        public Dish get_dish(string name)
        {
            return xmltools.get_t<Dish>(name);
        }
        public IEnumerable<Dish> Get_All_Dishs(Func<Dish, bool> predicate = null)
        {
            if (predicate == null)
                return xmltools.Get_Allx<Dish>();
            return xmltools.Get_Allx<Dish>().Where(predicate);
        }
        #endregion

        #region braunch functions
        public void add_braunch(Braunch b)
        {
            if (get_braunch(b.Braunch_number) == null)
                b.Addx();
            else
                throw new Exception("there is already a braunch with this ");
        }
        public void remove_braunch(string num)
        {
            Braunch temp = get_braunch(num);
            if (temp == null)
                throw new Exception("that braunch don't exist!");
            if (xmltools.Get_Allx<Order>().ToList().Exists(x => x.Bruanch_number == temp.Braunch_number))
                throw new Exception("you can`t delete bruanch with orders that are still avilabele");
            xmltools.removex<Braunch>(num.ToString());
        }
        public void update_braunch(Braunch b)
        {
            Braunch temp = get_braunch(b.Braunch_number);
            if (temp == null)
                throw new Exception("That braunch don't exist!");
            b.update();
        }
        public Braunch get_braunch(string num)
        {
            return xmltools.Get_Allx<Braunch>().FirstOrDefault(x => x.Braunch_number == num);
        }
        public IEnumerable<Braunch> Get_All_braunches(Func<Braunch, bool> predicate = null)
        {
            if (predicate == null)
                return xmltools.Get_Allx<Braunch>();
            return xmltools.Get_Allx<Braunch>().Where(predicate);//LINQ שימוש בפונ מובנית של list
        }
        #endregion

        #region order functions
        public void add_order(Order o)
        {
            if (get_order(o.Reservation_number) != null)
                throw new Exception("this order already exist");
            o.Addx();
        }
        public void remove_order(string num)
        {
            Order temp = get_order(num);
            if (temp == null)
                throw new Exception("that order don't exist!");
            xmltools.removex<Order>(num);
        }
        public void update_order(Order o)
        {
            Order temp = get_order(o.Reservation_number);
            if (temp == null)
                throw new Exception("that order don't exist!");
            o.update();
        }
        public Order get_order(string num)
        {
            return xmltools.Get_Allx<Order>().FirstOrDefault(x => x.Reservation_number == num);
        }
        public IEnumerable<Order> Get_All_orders(Func<Order, bool> predicate = null)
        {
            if (predicate == null)
                return xmltools.Get_Allx<Order>();
            return xmltools.Get_Allx<Order>().Where(predicate);
        }
        #endregion

        #region ordered_dish functions
        public void add_ordered_dish(Ordered_Dish a)
        {
            if (get_ordered_dish(a.Rn_Dn) == null)
               a.Addx(); 
            else
                throw new Exception("there is already ordered dish like this");
        }
        public void remove_ordered_dish(string rn_dn)
        {
            Ordered_Dish temp = get_ordered_dish(rn_dn);
            if (temp == null)
                throw new Exception("that ordered dish don't exist!");
            else
                xmltools.removex<Ordered_Dish>(rn_dn);
        }
        public void update_ordered_dish(Ordered_Dish a)
        {

            Ordered_Dish temp = get_ordered_dish(a.Rn_Dn);
            if (temp == null)
                a.Addx();
            else
                a.update();

        }
        public Ordered_Dish get_ordered_dish(string num)
        {
            return xmltools.get_t<Ordered_Dish>(num);
        }
        public IEnumerable<Ordered_Dish> Get_All_Ordered_Dishs(Func<Ordered_Dish, bool> predicate = null)
        {
            if (predicate == null)
                return xmltools.Get_Allx<Ordered_Dish>();
            return xmltools.Get_Allx<Ordered_Dish>().Where(predicate);
        }
        #endregion

        #region client functions
        public void add_client(Client c)
        {
            if (get_client(c.Credit_card) != null)
            throw new Exception("this client already exist");
            c.Addx();
        }
        public void remove_client(string card)
        {

            Client temp = get_client(card);
            if (temp == null)
                throw new Exception("that client don't exist!");
            else
                xmltools.removex<Client>(card);
        }
        public void update_client(Client c)
        {
            Client temp = get_client(c.Credit_card);
            if (temp == null)
                throw new Exception("that client don't exist!");
            c.update();
        }
        public Client get_client(string card)
        {
            return xmltools.get_t<Client>(card);
        }
        public IEnumerable<Client> Get_All_clients(Func<Client, bool> predicate = null)
        {
            if (predicate == null)
                return xmltools.Get_Allx<Client>();
            return xmltools.Get_Allx<Client>().Where(predicate);
        }
        #endregion
        public void close()
        {

        }
        public void open()
        {
            xmltools.Get_Allx<Client>();
            xmltools.Get_Allx<Dish>();
            xmltools.Get_Allx<Braunch>();
            xmltools.Get_Allx<Order>();
            xmltools.Get_Allx<Ordered_Dish>();
        }
    }
}
