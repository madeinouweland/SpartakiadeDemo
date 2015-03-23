using System;
using SolidNavigation.Sdk;
using SpartakiadeDemo.Details;
using SpartakiadeDemo.Tasks;

namespace SpartakiadeDemo.Navigation
{
    // lists/{listId}
    public class ListTarget : NavigationTarget
    {
        public ListTarget(long listId)
        {
            ListId = listId;
        }

        public long ListId { get; private set; }

    }

    // tasks/{taskId}
    public class TaskTarget : NavigationTarget
    {
        public TaskTarget(long taskId)
        {
            TaskId = taskId;
        }

        public long TaskId { get; set; }

    }

    // tasks/{taskId}/comments/{commentId
    public class CommentTarget : NavigationTarget
    {
        public CommentTarget(long taskId, long commentId)
        {
            TaskId = taskId;
            CommentId = commentId;
        }

        public long TaskId { get; set; }

        public long CommentId { get; set; }

    }
}