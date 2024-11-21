using Mapster;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Bdp.Components.Pages
{
    public class AuthenticatedComponentBase : ComponentBase
    {
        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await GetUserDetails();
        }

        protected string? UserName { get; private set; }

        private async Task GetUserDetails()
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                return;
            }

            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            if (authState?.User?.Identity is not null && authState.User.Identity.IsAuthenticated)
            {
                UserName = authState.User.Identity.Name;
            }
        }
    }
}
