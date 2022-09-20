using Firebase.Database;
using Firebase.Database.Query;

namespace MauiFirebaseRealtimeDatabase;

public partial class MainPage : ContentPage
{
    FirebaseClient firebaseClient = new FirebaseClient(baseUrl: "https://mauifirebasedemo-2540e-default-rtdb.asia-southeast1.firebasedatabase.app/");

    public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        firebaseClient.Child("Chat").PostAsync(new Chat
        {
            Message = "Hello!"
        });
    }
}

