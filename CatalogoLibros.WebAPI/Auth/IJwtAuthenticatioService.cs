using CatalogoLibros.EntidadesDeNegocio;

namespace CatalogoLibros.WebAPI.Auth
{
    public interface IJwtAuthenticatioService
    {
        string Authenticate(Usuario pUsuario);
    }
}
