using BlazorApp1.Client.Utils;
using BlazorApp1.Shared.CustomExceptions;
using BlazorApp1.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Client.Pages.PageProcess
{
    public class UserListProcess : ComponentBase
    {
        [Inject]
        public HttpClient Client { get; set; }

        [Inject]
        ModalManager ModalManager { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }


        public List<UserDTO> UserList = new List<UserDTO>();


        protected async override Task OnInitializedAsync()
        {
            await LoadList();
        }


        protected void goCreateUserPage()
        {
            NavigationManager.NavigateTo("/users/add");
        }

        protected void goUpdateUserPage(int UserId)
        {
            NavigationManager.NavigateTo("/users/edit/" + UserId);
        }



        protected async Task DeleteUser(int Id)
        {
            bool confirmed = await ModalManager.ConfirmationAsync("Confirmation", "User will be deleted. Are you sure?");

            if (!confirmed) return;

            try
            {
                bool deleted = await Client.PostGetServiceResponseAsync<bool, int>("api/User/Delete", Id, true);

                await LoadList();
            }
            catch (ApiException ex)
            {
                await ModalManager.ShowMessageAsync("User Deletion Error", ex.Message);
            }
            catch (Exception ex)
            {
                await ModalManager.ShowMessageAsync("An Error", ex.Message);
            }
        }

        protected async Task LoadList()
        {
            try
            {
                UserList = await Client.GetServiceResponseAsync<List<UserDTO>>("api/User/Users", true);
            }
            catch (ApiException ex)
            {
                await ModalManager.ShowMessageAsync("Api Exception", ex.Message);
            }
            catch (Exception ex)
            {
                await ModalManager.ShowMessageAsync("Exception", ex.Message);
            }
        }

    }
}
