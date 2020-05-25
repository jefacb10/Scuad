namespace Scuad.Repository
{
    public interface ILoginRepository
    {
        int consultarLogin(
            string usuario,
            string senha);
    }
}