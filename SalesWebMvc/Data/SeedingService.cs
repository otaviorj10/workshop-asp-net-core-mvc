using System;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecords.Any())
            {
                return; // banco de dado ja foi populado
            }

            Department d1 = new Department(1,"computers");
            Department d2 = new Department(2,"electronics");
            Department d3 = new Department(3,"fashion");
            Department d4 = new Department(4,"books");

            Seller s1 = new Seller(1,"bob brown ,","bob@gmail.com",new DateTime(1998,4,21),1000.00,d1);
            Seller s2 = new Seller(2,"maria green ,","maria@gmail.com",new DateTime(1968,4,21),1000.00,d2);
            Seller s3 = new Seller(3,"alex grey ,","alex@gmail.com",new DateTime(1979,6,21),1000.00,d3);
            Seller s4 = new Seller(4,"martha red ,","martha@gmail.com",new DateTime(1993,1,15),1000.00,d1);
            Seller s5 = new Seller(5,"donald blue ,","donald@gmail.com",new DateTime(1969,10,21),1000.00,d2);
            Seller s6 = new Seller(6,"alex pink ,","alex@gmail.com",new DateTime(1997,6,28),1000.00,d3);

            SalesRecord r1 = new SalesRecord(2,new DateTime(2018,09,25),11000.0,SaleStatus.Billed,s1);
            SalesRecord r2 = new SalesRecord(1,new DateTime(2016,06,22),11085.0,SaleStatus.Billed,s2);
            _context.Department.AddRange(d1,d2,d3,d4);
            _context.Seller.AddRange(s1,s2,s3,s4,s5,s6);
            _context.SalesRecords.AddRange(r1,r2);
            _context.SaveChanges();
        }
    }
}
