using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            List<Customer> customers = new List<Customer>();
            // Connect to MySQL->[s].
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=testa;port=3306;password=123456"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from customer", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    // Extract your data ->[s].
                    Customer customer = new Customer();
                    customer.id = Convert.ToInt32(reader["id"]);
                    customer.code = reader["code"].ToString();
                    customer.name = reader["name"].ToString();

                    customers.Add(customer);

                }
                reader.Close();
            }


                return View(customers);
        }

        public IActionResult Add()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        //For CREATE function ->[S].
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(int id, string code, string name)
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=testa;port=3306;password=123456"))
            {
            con.Open();
            var command = "insert into customer(id,code,name) values('" + id + "','" + code + "','" + name + "')";
            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
        }
            return View();
    }





        //For UPDATE function ->[S].

        public IActionResult Update(int id)
        {
            Customer customer = new Customer();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=testa;port=3306;password=123456"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from customer where id=" + id, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    customer.id = Convert.ToInt32(reader["id"]);
                    customer.code = reader["code"].ToString();
                    customer.name = reader["name"].ToString();



                }
                reader.Close();
            }
            return View(customer);
        }



        [HttpPost]
        public IActionResult Update(int id, string code, string name)
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=testa;port=3306;password=123456"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE customer SET id = '" + id + "',code = '" + code + "', name = '" + name + "' WHERE id = " +id,con);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
                return RedirectToAction("Index");
        }

        
        


        //For DELETE function ->[S].
        public ActionResult Delete(int id)
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=testa;port=3306;password=123456"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM customer WHERE id=" +id, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
                return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


