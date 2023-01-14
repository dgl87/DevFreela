namespace DevFreela.Core.Entities
{
    public class UserSkill : BaseEntity
    {
        public UserSkill(int id, int idSkill)
        {
            Id = id;
            IdSkill = idSkill;
        }
        public int Id { get; private set; }
        public int IdSkill { get; private set; }
    }
}
