namespace RecruitR.Customers.Commands.UpdateSkill
{
    public class UpdateSkillRequest
    {
        public string Name { get; set; }
        public uint Proficiency { get; set; }
        public decimal Experience { get; set; }
    }
}