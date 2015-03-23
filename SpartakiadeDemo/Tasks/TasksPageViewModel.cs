﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Windows.UI.StartScreen;
using SpartakiadeDemo.Entities;
using SpartakiadeDemo.Navigation;

namespace SpartakiadeDemo.Tasks
{
    public class TasksPageViewModel : ObservableObject
    {
        public List<TaskViewModel> Tasks { get; set; }
        private TaskViewModel _selectedTask;
        public string ListTitle { get; set; }
        public ICommand PinToStartCommand { get; set; }

        public TasksPageViewModel(ListTarget target)
            : this(target.ListId)
        {
        }

        public TasksPageViewModel(long listId)
        {
            Tasks = (from task in Workspace.Current.Tasks.Where(x => x.ListId == listId)
                     select new TaskViewModel { Id = task.Id, Title = task.Title }).ToList();

            var list = Workspace.Current.Lists.FirstOrDefault(x => x.Id == listId);
            ListTitle = "Tasks from list " + list.Title;

            PinToStartCommand = new DelegateCommand(async () =>
            {
                var logo = new Uri("ms-appx:///Assets/Logo.png");
                var secondaryTile = new SecondaryTile(Guid.NewGuid() + "", list.Title, listId + "", logo, TileSize.Square150x150);
                secondaryTile.VisualElements.ShowNameOnSquare150x150Logo = true;
                await secondaryTile.RequestCreateAsync();
            });
        }

        public TaskViewModel SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                if (Equals(value, _selectedTask)) return;
                _selectedTask = value;
                NotifyOfPropertyChange(() => _selectedTask);

                NavigateService.Current.Navigate(new TaskTarget(_selectedTask.Id));
            }
        }
    }
}
