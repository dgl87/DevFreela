using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Minha Descricao de Projeto 1", 1, 1, 10000, new DateTime(1987, 1, 1)),
                new Project("Meu projeto ASPNET Core 2", "Minha Descricao de Projeto 2", 1, 1, 20000, new DateTime(1987, 1, 1)),
                new Project("Meu projeto ASPNET Core 3", "Minha Descricao de Projeto 3", 1, 1, 30000, new DateTime(1987, 1, 1))
            };

            Users = new List<User>
            {
                new User("Douglas André", "dglandre@gmail.com", new DateTime(1987, 1, 1)),
                new User("Maria José", "maria@gmail.com", new DateTime(1959, 9, 23)),
                new User("Mauro Paiva", "mauro@gmail.com", new DateTime(1961, 12, 17)),
            };

            Skills = new List<Skill>
            {
                new Skill(".Net Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }

    }
}
