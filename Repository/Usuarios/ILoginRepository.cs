namespace Scuad.Repository
{
    public interface ILoginRepository
    {
        int ConsultarLogin(
            string usuario,
            string senha);
    }
}