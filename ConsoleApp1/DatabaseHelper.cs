using Db4objects.Db4o;
using MidTerm2016;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Databasehelper
    {
        public Databasehelper() { }
        public static IObjectContainer OpenDb(string FileName)
        {
            IObjectContainer db = Db4oEmbedded.OpenFile(FileName);
            return db;
        }
        public static void InputEmployees(IObjectContainer db)
        {
            int n = 2;
            while (n >= 0)
            {
                Console.Write("Nhập Id:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Nhâp vào tên:");
                string ten = Console.ReadLine();
                Console.WriteLine("Nhập vào Skill:");
                string skill = Console.ReadLine();
                Console.WriteLine("Nhập vào Company:");
                string Compa = Console.ReadLine();
                Console.WriteLine("Nhập vào Lương:");
                double luong = double.Parse(Console.ReadLine());
                IObjectSet re = db.QueryByExample(typeof(Company));
                int soluong = re.Count;
                int dem = 0;

                //Kiểm tra tên công ty đã tồn tại chưa
                foreach (Company item in re)
                {
                    if (String.Compare(item.CompanyName, Compa) == 0)
                    {
                        dem++;
                        if (dem > 0)
                        {
                            //Nếu rồi
                            Employee pi = new Employee(id, ten, skill, luong,null, item);
                            db.Store(pi);

                        }


                    }

                }
                //Nếu chưa
                if (dem == 0)
                {
                    Company pp = new Company(Compa);
                    Employee p = new Employee(id, ten, skill, luong,null, pp);
                    db.Store(p);

                }
                n--;
            }
        }



        public static void ListResult(IObjectSet result)
        {


            Console.WriteLine("Danh sach cac nhan vien:", result.Count);
            foreach (Employee item in result)
            {
                Console.WriteLine(item.FullName + ' ' + item.Skill + ' ' + item.HomeBase + ' ' + item.Salary);
            }
        }
        public static void RetrieveAll(IObjectContainer db)
        {


            IObjectSet result = db.QueryByExample(new Employee(0, null, null, 0,null, null));
            ListResult(result);

        }

        public static void RetrieveCompany(IObjectContainer db, double sal)
        {
            int[] dem = new int[100];

            Employee pi = new Employee(0, null, null, 0, null,null);
            IObjectSet ru = db.QueryByExample(typeof(Company));
            IObjectSet result = db.QueryByExample(typeof(Employee));
            Console.WriteLine("Danh sách các công ty thỏa điều kiện:");
            int n = -1;
            foreach (Company i in ru)
            {
                n += 1;
                dem[n] = 0;
                int tmp = 0; int tmt = 0; string chuoi = "";
                foreach (Employee item in result)
                {
                    if (String.Compare(i.CompanyName, item.HomeBase.CompanyName) == 0)
                    {
                        dem[n]++;
                        if (dem[n] >= 2)
                        {
                            //Kiểm tra lương công ty có lớn hơn 500 ko nếu co 1 trong so nhung nhan vien co luong nho hon<500 thi ko thoa
                            if (item.Salary < sal)
                            {
                                tmp++;
                            }
    
                            else
                            {
                                tmt++;
                            }

                            }


                        }

                    }
                    if (dem[n] >= 2 && tmp == 0 && tmt > 0)
                    {
                        chuoi += i;

                        Console.WriteLine(chuoi);
                    }

                }

                Console.ReadLine();
            }

        }
    }




    

