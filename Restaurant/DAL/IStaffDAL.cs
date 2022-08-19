using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
namespace DAL
{
    public interface IStaffDAL<staff>
    {
        bool SaveMember(staff memb);

        bool DeleteMember(int id);

        bool UpdateMember(staff memb);

        staff GetMember(int id);

        List<staff> GetMembers();
    }
}
