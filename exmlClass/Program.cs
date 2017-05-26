using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace exmlClass
{
    public class Program
    {
        static void Main(string[] args)
        {

            exmlClass.Product g = new exmlClass.Product();




            try
            {
                StringBuilder sb = new StringBuilder();

                string line;
                //List<ArmProd> list = new List<ArmProd>();
                var file = new StreamReader(@"C:\Armtek.txt");
                while ((line = file.ReadLine()) != null)
                {
                    sb.Append(line);
                    //exeption
                }

                //FileNotFoundException 

                file.Close();

                var splitStr = sb.ToString().Replace("{", "").Replace("},", "}").Split('}');

                List<Product> products = new List<Product>();

                //try
                foreach (var item in splitStr)
                {
                    //try
                    var itemRs = item.Replace("',", ",").Split(',');

                    Product product = getProductPropertis(itemRs);

                    products.Add(product);
                }

            }
            catch (Exception ex)
            {

            }
            Console.ReadKey();
        }

        static Product getProductPropertis(string[] itemRs)
        {
            Product product = new Product();
            try
            {
                foreach (var itemR in itemRs)
                {

                   
                    #region
                    var res = itemR.Split(':');

                    if (res.Length < 2)
                    {
                        throw new Exception("Баланс = 0");

                    }

                    string key="";
                    
                   // = res[0].Replace("'", "");
                    var value = res[1].Replace("'", "");

                    #region
                    switch (key)
                    {
                        case "PIN":
                            product.PIN = value;
                            break;
                        case "BRAND":
                            product.BRAND = value;
                            break;
                        case "NAME":
                            product.NAME = value;
                            break;
                        case "ARTID":
                            product.ARTID = value;
                            break;
                        case "PARNR":
                            product.PARNR = value;
                            break;
                        case "KEYZAK":
                            product.KEYZAK = value;
                            break;
                        case "RVALUE":
                            product.RVALUE = value;
                            break;
                        case "RDPRF":
                            product.RDPRF = value;
                            break;
                        case "MINBM":
                            product.MINBM = value;
                            break;
                        case "VENSL":
                            product.VENSL = value;
                            break;
                        case "PRICE":
                            product.PRICE = value;
                            break;
                        case "WAERS":
                            product.WAERS = value;
                            break;
                    }
                    #endregion

                    #endregion
                }
                return product;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("ERRR" + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRR" + ex.Message);
                return null;
            } 
        }

        static void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static void Gray()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

    }
}
