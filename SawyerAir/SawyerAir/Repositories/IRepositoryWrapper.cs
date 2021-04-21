namespace SawyerAir.Repositories
{
    public interface IRepositoryWrapper
    {
        IClientRepository ClientRepository { get; }
        void Save();
    }
}
