using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        //public readonly object ProjectComments;
        public List<ProjectComment> ProjectComments { get; set; }

        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu Projeto ASPNET Core", "Minha descricao de projeto 1", 1,1,10000),
                new Project("Meu Projeto ASPNET Core", "Minha descricao de projeto 2", 1,1,20000),
                new Project("Meu Projeto ASPNET Core", "Minha descricao de projeto 3", 1,1,30000)
            };

            Users = new List<User>
            {
                new User("Samuel jason", "samuelljason@gmail.com", new DateTime(2000,05,19)),
                new User("luca jason", "samuel3ljason@gmail.com", new DateTime(2004, 05, 19)),
                new User("luli souza", "lulill@gmail.com", new DateTime(2003, 05, 19))
            };

            Skills = new List<Skill>
            {
                new Skill(".NetCore"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
