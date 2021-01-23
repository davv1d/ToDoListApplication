using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ToDoListApplication.Model.Tests
{
    [TestClass()]
    public class TaskServiceTests
    {
        [TestMethod()]
        public void Save_Task_Should_Save()
        {
            //Given
            var mockSet = new Mock<DbSet<Task>>();
            var mockContext = new Mock<TaskDbContext>();
            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);
            var service = new TaskService(mockContext.Object);
            var task = new Task() { TaskId = 0, Title = "test 1", Description = "test 1", ScheduledDate = DateTime.Now };

            //When
            var result = service.SaveTask(task);

            //Then
            mockSet.Verify(m => m.Add(It.IsAny<Task>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void Delete_Task_Should_Delete_Task()
        {
            //Given
            var task = new Task() { TaskId = 0, Title = "test 1", Description = "test 1", ScheduledDate = DateTime.Now };
            List<Task> tasks = new List<Task> { task };
            var mockSet = GetMockDbSet(tasks);
            var mockContext = new Mock<TaskDbContext>();
            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);
            var service = new TaskService(mockContext.Object);

            //When
            var result = service.DeleteTask(task.TaskId);

            //Then
            Assert.IsFalse(result.IsFailure());
            mockSet.Verify(m => m.Remove(It.IsAny<Task>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void Delete_Task_Not_Found_Task()
        {
            //Given
            List<Task> tasks = new List<Task>();
            var mockSet = GetMockDbSet(tasks);
            var mockContext = new Mock<TaskDbContext>();
            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);
            var service = new TaskService(mockContext.Object);

            //When
            var result = service.DeleteTask(0);

            //Then
            Assert.IsTrue(result.IsFailure());
            mockSet.Verify(m => m.Remove(It.IsAny<Task>()), Times.Never());
            mockContext.Verify(m => m.SaveChanges(), Times.Never());
        }


        [TestMethod()]
        public void Update_Task_Not_Found_Task()
        {
            //Given   
            var task = new Task() { TaskId = 0, Title = "test 1", Description = "test 1", ScheduledDate = DateTime.Now };
            List<Task> tasks = new List<Task>();
            var mockSet = GetMockDbSet(tasks);
            var mockContext = new Mock<TaskDbContext>();
            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);
            var service = new TaskService(mockContext.Object);

            //When
            var result = service.UpdateTask(task);

            //Then
            Assert.IsTrue(result.IsFailure());
            mockSet.Verify(m => m.Remove(It.IsAny<Task>()), Times.Never());
            mockContext.Verify(m => m.SaveChanges(), Times.Never());
        }

        [TestMethod()]
        public void Update_Task_Should_Update_Task()
        {
            //Given   
            var task = new Task() { TaskId = 1, Title = "test 1", Description = "test 1", ScheduledDate = DateTime.Now };
            List<Task> tasks = new List<Task> { task };
            var mockSet = GetMockDbSet(tasks);
            var mockContext = new Mock<TaskDbContext>();
            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);
            var service = new TaskService(mockContext.Object);

            //When
            var result = service.UpdateTask(task);

            //Then
            Assert.IsFalse(result.IsFailure());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void Get_Task_By_Date_Should_Return_Tasks()
        {
            //Given
            var date = DateTime.Now;
            var task1 = new Task() { TaskId = 1, Title = "test 1", Description = "test 1", ScheduledDate = date };
            var task2 = new Task() { TaskId = 2, Title = "test 2", Description = "test 2", ScheduledDate = date.AddDays(2) };
            var task3 = new Task() { TaskId = 3, Title = "test 3", Description = "test 3", ScheduledDate = date };
            var task4 = new Task() { TaskId = 4, Title = "test 4", Description = "test 4", ScheduledDate = date };
            List<Task> tasks = new List<Task> { task1, task2, task3, task4 };
            var mockSet = GetMockDbSet(tasks);
            var mockContext = new Mock<TaskDbContext>();
            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);
            var service = new TaskService(mockContext.Object);

            //When
            var result = service.GetTasksByDate(date);

            //Then
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod()]
        public void Get_Task_By_Date_Should_Return_Empty_List()
        {
            //Given
            var date = DateTime.Now;
            var task1 = new Task() { TaskId = 1, Title = "test 1", Description = "test 1", ScheduledDate = date };
            var task2 = new Task() { TaskId = 2, Title = "test 2", Description = "test 2", ScheduledDate = date.AddDays(2) };
            var task3 = new Task() { TaskId = 3, Title = "test 3", Description = "test 3", ScheduledDate = date };
            var task4 = new Task() { TaskId = 4, Title = "test 4", Description = "test 4", ScheduledDate = date };
            List<Task> tasks = new List<Task> { task1, task2, task3, task4 };
            var mockSet = GetMockDbSet(tasks);
            var mockContext = new Mock<TaskDbContext>();
            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);
            var service = new TaskService(mockContext.Object);

            //When
            var result = service.GetTasksByDate(date.AddDays(1));

            //Then
            Assert.AreEqual(0, result.Count);
        }


        private Mock<DbSet<Task>> GetMockDbSet(ICollection<Task> entities)
        {
            var mockSet = new Mock<DbSet<Task>>();
            mockSet.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(entities.AsQueryable().Provider);
            mockSet.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(entities.AsQueryable().Expression);
            mockSet.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(entities.AsQueryable().ElementType);
            mockSet.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(entities.AsQueryable().GetEnumerator());
            mockSet.Setup(m => m.Add(It.IsAny<Task>())).Callback<Task>(entities.Add);
            return mockSet;
        }
    }
}