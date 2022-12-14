using BlazorApp1.Shared.DTO;
using BlazorApp1.Shared.ResponseModels;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Pages.Users
{
    public partial class UserListProcess:ComponentBase
    {
        [Inject]
        public HttpClient Client { get; set; }

        protected List<UserDTO> userList = new List<UserDTO>();


        protected async override Task OnInitializedAsync()
        {
            await LoadList();

        }

        protected async Task LoadList()
        {
            var serviceResponse = await Client.GetFromJsonAsync<ServiceResponse<List<UserDTO>>>("api/User/Users");

            if (serviceResponse.Success)
                userList = serviceResponse.Value;
        }

    }
}
