using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BLL
{
    public class StaffBLL
    {
        StaffDAL StaffDAL = new StaffDAL();

        public bool AddMember(staff memb)
        {
            return StaffDAL.SaveMember(memb);
        }

        public bool RemoveMember(int id)
        {
            return StaffDAL.DeleteMember(id);
        }

        public bool EditMember(staff memb)
        {
            return StaffDAL.UpdateMember(memb);
        }

        public staff GetMemberById(int id)
        {
            return StaffDAL.GetMember(id);
        }

        public List<staff> GetAllMember()
        {
            return StaffDAL.GetMembers();
        }
    }
}

