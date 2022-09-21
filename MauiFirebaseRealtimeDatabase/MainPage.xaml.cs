using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;

namespace MauiFirebaseRealtimeDatabase;

public partial class MainPage : ContentPage
{
    FirebaseClient firebaseClient = new FirebaseClient(baseUrl: "https://mauifirebasedemo-2540e-default-rtdb.asia-southeast1.firebasedatabase.app/");

    public ObservableCollection<TodoItem> TodoItems { get; set; } = new ObservableCollection<TodoItem>();

    public MainPage()
	{
		InitializeComponent();

        BindingContext = this;

        var collection = firebaseClient
            .Child("Todo")
            .AsObservable<TodoItem>()
            .Subscribe((item) =>
            {
                if (item.Object != null)
                {
                    TodoItems.Add(new TodoItem
                    {
                        Title = item.Object.Title,
                    });
                }
            });
    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
        firebaseClient.Child("Todo").PostAsync(new TodoItem
        {
            Title = TitleEntry.Text,
        });

        TitleEntry.Text = string.Empty;
    }
}

