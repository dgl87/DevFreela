namespace DevFreela.Core.Entities
{
    public class UserSkill : BaseEntity
    {
        public UserSkill(int id, int idSkill)
        {
            IdUser = id;
            IdSkill = idSkill;
        }
        public int IdUser { get; private set; }
        public int IdSkill { get; private set; }
    }
}
