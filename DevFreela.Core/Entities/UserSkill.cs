using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public  class UserSkill : BaseEntity
    {
        public UserSkill(int idUser, int idSkill)
        {
            IdUser = idUser;
            IdSkill = idSkill;
        }

        public int IdUser { get; set; }
        public int IdSkill { get; set; }
        public Skill Skills { get; set; }
    }
}
