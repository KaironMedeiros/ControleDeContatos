namespace ControleDeContatos.Helper
{
    public interface IEmail
    {
        bool Enviar(string emaail, string assunto, string mensagem);
    }
}
