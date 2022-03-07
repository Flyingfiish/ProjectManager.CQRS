using System.Security.Claims;

namespace ProjectManager
{
    public class CurrentUserAdapter : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpContext _httpContext;
        public CurrentUserAdapter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpContext = _httpContextAccessor.HttpContext;
        }
        public bool IsAuthenticated => _httpContext.User.Identity.IsAuthenticated;
        public string UserName => _httpContext.User.Identity.Name;
        public IEnumerable<Claim> Claims => _httpContext.User.Claims;
    }

    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }
        IEnumerable<Claim> Claims { get; }
    }
}
