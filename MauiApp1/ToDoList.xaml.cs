using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;


namespace MauiApp1;

public partial class ToDoList : ContentPage
{
    List<TaskItem> tasks;
    public ToDoList()
    {
        InitializeComponent();

        
        tasks = new List<TaskItem>()
            {
                new TaskItem { TaskName = "Sýnavlar Okunacak" },
                new TaskItem { TaskName = "Quizler Okunacak" },
                new TaskItem { TaskName = "Deneme Düzeltildi" }
            };

        
        ToDoListView.ItemsSource = tasks;
    }

    
    private void AddNewItemButton_Clicked(object sender, EventArgs e)
    {
        tasks.Add(new TaskItem { TaskName = "Yeni Görev" });
        ToDoListView.ItemsSource = null;
        ToDoListView.ItemsSource = tasks;
    }


    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        
        await DisplayAlert("Bilgi", "Dosya baþarýyla kaydedildi.", "OK");
    }


    public class TaskItem
    {
        public string TaskName { get; set; }
        public bool IsCompleted { get; set; }
    }
    private async void EditItem_Tapped(object sender, EventArgs e)
    {
        var image = (Image)sender;
        var task = (TaskItem)image.BindingContext;

        
        string newTaskName = await DisplayPromptAsync("Düzenleme", "Yeni görev adý:", initialValue: task.TaskName);

       
        if (!string.IsNullOrEmpty(newTaskName))
        {
            task.TaskName = newTaskName;
            ToDoListView.ItemsSource = null;
            ToDoListView.ItemsSource = tasks;
        }
    }
    private async void DeleteItem_Tapped(object sender, EventArgs e)
    {
        var image = (Image)sender;
        var task = (TaskItem)image.BindingContext;

        bool answer = await DisplayAlert("Silme Ýþlemi", "Bu görevi silmek istediðinize emin misiniz?", "Evet", "Hayýr");

       
        if (answer)
        {
            tasks.Remove(task);
            ToDoListView.ItemsSource = null;
            ToDoListView.ItemsSource = tasks;
        }
    }
}
