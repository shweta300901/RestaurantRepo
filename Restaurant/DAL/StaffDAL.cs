using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StaffDAL : IStaffDAL<staff>
    {
        public bool SaveMember(staff memb)
        {
            try
            {
                using (RestaurantDBEntities1 dbContext = new RestaurantDBEntities1())
                {
                   
                        dbContext.staffs.Add(memb);
                        dbContext.SaveChanges();
                        return true;
                    

                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteMember(int id)
        {
            try
            {
                using (RestaurantDBEntities1 dbContext = new RestaurantDBEntities1())
                {
                    var memberToDelete = dbContext.staffs.Where(members => members.id == id).FirstOrDefault();
                    dbContext.staffs.Remove(memberToDelete);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateMember(staff memb)
        {
            try
            {
                using (RestaurantDBEntities1 dbContext = new RestaurantDBEntities1())
                {
                    var existingMember = dbContext.staffs.Where(members => members.id == memb.id).FirstOrDefault();
                    existingMember.id = memb.id;
                    existingMember.code = memb.code;
                    existingMember.firstname = memb.firstname;
                    existingMember.lastname = memb.lastname;
                    existingMember.doj = memb.doj;
                    existingMember.salary = memb.salary;
                    existingMember.address = memb.address;
                    existingMember.fathername = memb.fathername;
                    existingMember.aadharno = memb.aadharno;
                    existingMember.accountno = memb.accountno;
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public staff GetMember(int id)
        {
            try
            {
                using (RestaurantDBEntities1 dbContext = new RestaurantDBEntities1())
                {
                    var memberById = dbContext.staffs.Where(members => members.id == id).FirstOrDefault();
                    return memberById;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<staff> GetMembers()
        {
            try
            {
                using (RestaurantDBEntities1 dbContext = new RestaurantDBEntities1())
                {
                    var allMember = dbContext.staffs.ToList();
                    return allMember;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
