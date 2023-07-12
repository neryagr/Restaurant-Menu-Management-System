using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using BE;
using DAL;
namespace BL
{

    class Bl_imp : IBL
    {
        Idal dal = Dal_Factory.get_dal();//שימוש בfactory
        #region DISH
        public void add_dish(Dish d)
        {
            dal.add_dish(d);
        }
        public void remove_dish(string name)
        {
            if (Get_All_Ordered_Dishs().Any(x => x.dish_name == name))
                throw new Exception("you can`t delete dish with orders that are still avilabele");
            if (Get_All_Ordered_Dishs().ToList<Ordered_Dish>().Exists(x => x.dish_name == name))
                throw new Exception("you can`t delete dish with orders that are still avilabele");
            dal.remove_dish(name);
        }
        public void update_dish(Dish d)
        {
            if (Get_All_Ordered_Dishs().Any(x => x.dish_name == d.Name))
                throw new Exception("you can`t update dish with orders that are still avilabele");
            dal.update_dish(d);
        }
        public Dish get_dish(string name)
        {
            return dal.get_dish(name);
        }
        public IEnumerable<Dish> Get_All_Dishs(Func<Dish, bool> predicate = null)
        {
            return dal.Get_All_Dishs(predicate);
        }
        #endregion

        #region bruanch
        public void add_braunch(Braunch b)
        {
            if (b.Deliveries_Availabile <= 0)
                throw new Exception("braunch can`t exist with this number of employees");
            if (Get_All_braunches().Any(x => x.Address == b.Address) || Get_All_clients().ToList<Client>().Exists(x => x.Address == b.Address))
                throw new Exception("this address already exists");
            dal.add_braunch(b);
        }
        public void remove_braunch(string num)
        {
            if (Get_All_orders().Any(x => x.Bruanch_number == num))
                throw new Exception("you can`t delete a brunch with orders still avileable");
            dal.remove_braunch(num);
        }
        public void update_braunch(Braunch b)
        {
            if (b.Deliveries_Availabile <= 0 )
                throw new Exception("braunch can`t exist with this number of employees");
            if (Get_All_braunches().Any(x => x.Address == b.Address))
                throw new Exception("braunch with this address already exists");
            if (Get_All_orders().Any(x => x.Bruanch_number == b.Braunch_number))
                throw new Exception("you can`t update a brunch with orders still avileable");
            dal.update_braunch(b);
        }
        public Braunch get_braunch(string num)
        {
            return dal.get_braunch(num);
        }
        public IEnumerable<Braunch> Get_All_braunches(Func<Braunch, bool> predicate = null)
        {
            return dal.Get_All_braunches(predicate);
        }
        #endregion

        #region Order
        public void add_order(Order o)
        {
            Client c = get_client(o.Cl);
            Braunch b = get_braunch(o.Bruanch_number);
            if (b == null)
                throw new Exception("there is no such bruanch");
            if (c == null)
                throw new Exception("there is no such client");
            if (is_tzair(c.Age))
                throw new Exception("you are too young to order");
            if (o.Kusher_level > b.Kusher_level)
                throw new Exception("you can`t order this kosher level from braunch with a lower kosher level ");
            if (b.Opening_hour >= o.Date.Hour && b.Closing_hour <= o.Date.Hour)
                throw new Exception("you can`t order from this bruanch becuase he is close for the moment ");
            if (c.overdraft < calculate_order(o))
                throw new Exception("you dont have enough money");
            c.overdraft -= calculate_order(o);
            //if (b.Deliveries_Availabile > 1)
            //    delivery(o);
            dal.add_order(o);
        }
        public void remove_order(string num)
        {
            if (Get_All_Ordered_Dishs().Any(x => x.reservation_number == num))
                throw new Exception("you can`t delete a order  still avileable");
            dal.remove_order(num);
        }
        public void update_order(Order o)
        {
            if (Get_All_Ordered_Dishs().Any(x => x.reservation_number == o.Reservation_number))
                throw new Exception("you cant update an order after you put dishes in it");
            var c = get_client(o.Cl);
            if (c == null)
                throw new Exception("there is no such client that you can order from");
            if (is_tzair(c.Age))
                throw new Exception("you are too young to order");
            if (is_max(5000, calculate_order(o)))//סתם מספר
                throw new Exception("you are not allow to spand so much money in one order");
            if (o.Kusher_level > get_braunch(o.Bruanch_number).Kusher_level)
                throw new Exception("you can`t order this kosher level from braunch with a lower kosher level ");
            dal.update_order(o);
        }
        public Order get_order(string num)
        {
            return dal.get_order(num);
        }
        public IEnumerable<Order> Get_All_orders(Func<Order, bool> predicate = null)
        {
            return dal.Get_All_orders(predicate);
        }


        #endregion

        #region Ordered_Dish
        public void add_ordered_dish(Ordered_Dish a)
        {
            a.Rn_Dn = a.reservation_number + a.dish_name;
            if (!(Get_All_Dishs().Any(x => x.Name == a.dish_name)))
                throw new Exception("there is no such dish");
            if (!(Get_All_orders().Any(x => x.Reservation_number == a.reservation_number)))
                throw new Exception("there is no order like this thet you can attach dish to");
            if (get_order(a.reservation_number).Kusher_level > get_dish(a.dish_name).Kusher_level)
                throw new Exception("you can`t order dish with a lower kosher level then the kosher level on your originol order");
            if (a.number_of_dishes == 0)
                throw new Exception("you cant order 0 dishes");
            dal.add_ordered_dish(a);
        }
        public void remove_ordered_dish(string a)
        {
            dal.remove_ordered_dish(a);
        }
        public void update_ordered_dish(Ordered_Dish a)
        {
            if (!(Get_All_Dishs().Any(x => x.Name == a.dish_name)))
                throw new Exception("there is no dish like this thet you can order");
            if (!(Get_All_orders().Any(x => x.Reservation_number == a.reservation_number)))
                throw new Exception("there is no order like this thet you can attach dish to");
            if (get_order(a.reservation_number).Kusher_level > get_dish(a.dish_name).Kusher_level)
                throw new Exception("you can`t order dish with a lower kosher level then the kosher level on your original order");
            if (a.number_of_dishes == 0)
                throw new Exception("you cant order 0 dishes");
            a.Rn_Dn = a.reservation_number + a.dish_name;
            dal.update_ordered_dish(a);
        }
        public Ordered_Dish get_ordered_dish(string a)
        {
            return dal.get_ordered_dish(a);
        }
        public IEnumerable<Ordered_Dish> Get_All_Ordered_Dishs(Func<Ordered_Dish, bool> predicate = null)
        {
            return dal.Get_All_Ordered_Dishs(predicate);
        }
        #endregion

        #region Client
        public void add_client(Client c)
        {
            if (Get_All_clients().ToList<Client>().Exists(x => x.Address == c.Address) || Get_All_braunches().ToList<Braunch>().Exists(x => x.Address == c.Address))
                throw new Exception("this address already exist");
            dal.add_client(c);
        }
        public void remove_client(string c)
        {
            if (Get_All_orders().ToList<Order>().Exists(x => x.Cl == c))
                throw new Exception("you cant delate a client who made an order");
            dal.remove_client(c);
        }
        public void update_client(Client c)
        {
            if (Get_All_clients().ToList<Client>().Exists(x => x.Address == c.Address) || Get_All_braunches().ToList<Braunch>().Exists(x => x.Address == c.Address))
                throw new Exception("this address already exist");
            if (Get_All_orders().ToList<Order>().Exists(x => x.Cl == c.Credit_card))
                throw new Exception("you cant update a client who made an order");
            dal.update_client(c);
        }
        public Client get_client(string card)
        {
            return dal.get_client(card);
        }
        public IEnumerable<Client> Get_All_clients(Func<Client, bool> predicate = null)
        {
            return dal.Get_All_clients(predicate);
        }
        #endregion

        #region general

         float calculate_order(Order o)
        {
            float sum = 0;
            var v = dal.Get_All_Ordered_Dishs(x => x.reservation_number == o.Reservation_number);

            foreach (var item in v)
            {
                var dishs = from Dish d in Get_All_Dishs()
                            where d.Name == item.dish_name
                            select d.Price;
                foreach (var d in dishs)
                {
                    sum += d * item.number_of_dishes;
                }
            }
            return sum;
        }
        /// <summary>
        /// מחשב מחיר של הזמנה מסוימת
        /// </summary>
        /// <param name="order_name"></param>
        /// <returns></returns>
        public float calculate_order(string order_name)
        {
            return calculate_order(get_order(order_name));
        }
         IEnumerable<IGrouping<string, float>> profit_by_dish()
        {
            var v = from item in dal.Get_All_Ordered_Dishs()
                    group item.number_of_dishes by item.dish_name;
            var g = from item1 in v
                    group item1.Sum() * get_dish(item1.Key).Price by item1.Key;
            return g;
        }
        IEnumerable<IGrouping<int, float>> profit_by_time(choise c)
        {

            var v = from item in dal.Get_All_orders()
                    group this.calculate_order(item) by item.Date.Day;
            switch (c)
            {
                case choise.DayOfMonth:
                    v = from item in dal.Get_All_orders()
                        group calculate_order(item) by item.Date.Day;
                    break;
                case choise.year:
                    v = from item in dal.Get_All_orders()
                        group calculate_order(item) by item.Date.Year;
                    break;

                case choise.hour:
                    v = from item in dal.Get_All_orders()
                        group calculate_order(item) by item.Date.Hour;

                    break;
                case choise.Month:
                    v = from item in dal.Get_All_orders()
                        group calculate_order(item) by item.Date.Month;
                    break;
            }
            return v;
        }
         IEnumerable<IGrouping<string, float>> profit_by_location()
        {
            var v = from item in dal.Get_All_orders()
                    group calculate_order(item) by item.Bruanch_number;
            var g = from item in v
                    group item.Sum() by item.Key;
            return g;
        }
         IEnumerable<IGrouping<string, float>> profit_by_client()
        {
            var v = from item in dal.Get_All_orders()
                    group calculate_order(item) by item.Cl;
            var g = from item in v
                    group item.Sum() by item.Key;
            return g;
        }
        bool is_max(float max_money, float money)
        {
            if (money > max_money)
                return true;
            return false;
        }
         bool is_tzair(int my_age)
        {
            if (my_age < 18)
                return true;
            return false;
        }
         bool is_taref(kosher_level kosher_level, kosher_level my)
        {
            if (my > kosher_level)
                return true;
            return false;
        } 
       /// <summary>
       /// מחשב את הזמן הכי רווחי
       /// </summary>
       /// <param name="c"> בחירה לפי איזה יחידת זמן החישוב יתבצע</param>
       /// <returns></returns>
        public string most_profitable_time(choise c)
        {
            return c.ToString() + ": " + profit_by_time(c).Max(x => x.Key) +"\nprofit: "+ profit_by_time(c).Max(x => x.FirstOrDefault()); 
        }
        /// <summary>
        /// מחשב את המנה הכי רווחית
        /// </summary>
        /// <returns></returns>
        public Dish most_profitable_dish()
        {
            return Get_All_Dishs(x => get_profit_dish(x.Name) == profit_by_dish().Max(y => y.First())).FirstOrDefault();
        }
        /// <summary>
        /// מחשב את הסניף הכי רווחי
        /// </summary>
        /// <returns></returns>
        public Braunch most_profitable_bruanch()
        {
          return Get_All_braunches(x=>get_profit_bruanch(x.Braunch_number)==profit_by_location().Max(y => y.First())).FirstOrDefault();
        }
        /// <summary>
        /// מחשב את הלקוח הכי רווחי(בזבזן)י
        /// </summary>
        /// <returns></returns>
        public Client most_profitable_client()
        {
            return Get_All_clients(x => get_profit_client(x.Credit_card) == profit_by_client().Max(y => y.First())).FirstOrDefault();
        }
        /// <summary>
        /// מחשב רווח לפי סניף ספציפי
        /// </summary>
        /// <param name="bruanch_number"> המספר של הסיף הספציפי</param>
        /// <returns></returns>
        public float get_profit_bruanch(string bruanch_number)
        {
            return profit_by_location().FirstOrDefault(x => x.Key == bruanch_number) == null ? 0 : profit_by_location().FirstOrDefault(x => x.Key == bruanch_number).First();
        }
        /// <summary>
        /// מחשב רווח לפי מנה ספציפית
        /// </summary>
        /// <param name="dish">המספר של המנה</param>
        /// <returns></returns>
        public float get_profit_dish(string dish)
        {
            return profit_by_dish().FirstOrDefault(x => x.Key == dish)== null ? 0 : profit_by_dish().FirstOrDefault(x => x.Key == dish).First();

        }
        /// <summary>
        /// מחשב רווח לפי לקוח ספציפי
        /// </summary>
        /// <param name="card">המספר של הלקוח</param>
        /// <returns></returns>
        public float get_profit_client(string card)
        {
            return profit_by_client().FirstOrDefault(x => x.Key == card)==null ? 0 : profit_by_client().FirstOrDefault(x => x.Key == card).First();
        }
        #endregion
        public void open()
        {
            dal.open();
        }
    }
}

