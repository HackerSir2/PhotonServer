using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CsharpMysql
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReadDatabase();
            //Delete();
            //ReadUserCount();
            //ExecuteScalar();
            //ReadDatabase();
            Console.WriteLine(VertifyUser("Mark", "1234"));
            Console.WriteLine(VertifyUser("Mary", "1234"));
            Console.WriteLine(VertifyUser("Mary", "dflkg"));
            //Delete();

            Console.ReadKey();
        }

        /// <summary>
        /// 查询
        /// </summary>
        static void ReadDatabase()
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=jk38f8j9";
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                string sql = "select *from goods";
                MySqlCommand comd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = comd.ExecuteReader();
                //reader.Read();

                while (reader.Read())
                {
                    //Console.WriteLine(reader[0].ToString() + "  " + reader[1].ToString() + "  " + reader[2].ToString() + "  " + reader[3].ToString() + "  " + reader[4].ToString() + " " + reader[5]);
                    //Console.WriteLine(reader.GetInt32(0)+"  "+reader.GetString(1)/*+"  "+reader.GetString(2)+"  "+reader.GetString(3)+"  "+reader.GetString(4)+"  "+reader.GetString(5)*/);

                    Console.WriteLine(reader.GetInt32("idgoods")+"  "+reader.GetString("namegoods")/*+"  "+reader.GetString("stype")+"  "+reader.GetString("hp")+"  "+reader.GetString("damage")+"  "+reader.GetString("Time")*/);
                }
                //Console.WriteLine($"已经建立连接");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 登入验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        static bool VertifyUser(string username,string password)
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=jk38f8j9";
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                //string sql = "select *from users where username='" + username + "'and password='" + password + "'";
                string sql = "select *from users where username=@para1 and password=@para2";
                MySqlCommand comd = new MySqlCommand(sql, conn);
                comd.Parameters.AddWithValue("para1",username);
                comd.Parameters.AddWithValue("para2",password);

                MySqlDataReader reader = comd.ExecuteReader();

                
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
             
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// 插入
        /// </summary>
        static void Delete()
        {
            string connector = "server=127.0.0.1;port=3306;database =mygamedb;user=root;password=jk38f8j9";
            MySqlConnection conn = new MySqlConnection(connector);

            try
            {
                conn.Open();
                string sql = "insert into role(nameRole,typeRole,userId) values('天外飞仙','法师',5)";
                string sql2 = "insert into goods(idgoods,namegoods,stype,hp,damage,Time) values(7,'鞋子','装备','50','20','" + DateTime.Now + "')";
                string sql3 = "update goods set Time='" + DateTime.Now + "'where idgoods='6'";
                string sql4 = "update goods set namegoods='战斧',stype='武器',hp='120',damage='60',Time='" + DateTime.Now + "' where idgoods='4'";
                string sql5 = "delete from goods where idgoods='4'";
                string sql6 = "insert into goods(idgoods,namegoods,stype,hp,damage,Time) values(4,'战斧','武器','30','60','" + DateTime.Now + "')";
                MySqlCommand command = new MySqlCommand(sql4, conn);

                int count = command.ExecuteNonQuery();
                Console.WriteLine(count);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        static void ReadUserCount()
        {
            string connector = "server=127.0.0.1;port=3306;database =mygamedb;user=root;password=jk38f8j9";
            MySqlConnection conn = new MySqlConnection(connector);
            try
            {
                conn.Open();
                string sql = "select count(*)from goods";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read(); //返回一个bool值，表示是否读取完
                int count = Convert.ToInt32(reader[0].ToString());
                Console.WriteLine(count);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }

        }

        static void ExecuteScalar()
        {
            string connector = "server=127.0.0.1;port=3306;database =mygamedb;user=root;password=jk38f8j9";
            MySqlConnection conn = new MySqlConnection(connector);
            try
            {
                conn.Open();
                string sql = "select count(*)from goods";
                MySqlCommand command = new MySqlCommand(sql, conn);
                //MySqlDataReader reader = command.ExecuteReader();
                //reader.Read(); //是否读取完
                Object reader = command.ExecuteScalar();
                int count = Convert.ToInt32(reader.ToString());
                Console.WriteLine(count);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
