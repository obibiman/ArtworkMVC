using StructureMap;

namespace Artist.DAO.IoCRegistry
{
    public class RegisterProject
    {
        public RegisterProject()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new ProjectRegistry()));
        }
    }
}