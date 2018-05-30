﻿using eFormCore;
using eFormCore.Helpers;
using eFormData;
using eFormShared;
using eFormSqlController;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace eFormSDK.Integration.Tests
{
    [TestFixture]
    public class SqlControllerTestNotification : DbTestFixture
    {
        private Core sut;
        private TestHelpers testHelpers;
        private string path;

        public override void DoSetup()
        {
            #region Setup SettingsTableContent

            SqlController sql = new SqlController(ConnectionString);
            sql.SettingUpdate(Settings.token, "abc1234567890abc1234567890abcdef");
            sql.SettingUpdate(Settings.firstRunDone, "true");
            sql.SettingUpdate(Settings.knownSitesDone, "true");
            #endregion

            sut = new Core();
            sut.HandleCaseCreated += EventCaseCreated;
            sut.HandleCaseRetrived += EventCaseRetrived;
            sut.HandleCaseCompleted += EventCaseCompleted;
            sut.HandleCaseDeleted += EventCaseDeleted;
            sut.HandleFileDownloaded += EventFileDownloaded;
            sut.HandleSiteActivated += EventSiteActivated;
            sut.StartSqlOnly(ConnectionString);
            path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            path = System.IO.Path.GetDirectoryName(path).Replace(@"file:\", "");
            sut.SetPicturePath(path + @"\output\dataFolder\picture\");
            sut.SetPdfPath(path + @"\output\dataFolder\pdf\");
            sut.SetJasperPath(path + @"\output\dataFolder\reports\");
            testHelpers = new TestHelpers();
            //sut.StartLog(new CoreBase());
        }

        #region notification
        [Test]
        public void SQL_Notification_NewNotificationCreateRetrievedForm_DoesStoreNotification()
        {
            // Arrance
            var notificationId = Guid.NewGuid().ToString();
            var microtingUId = Guid.NewGuid().ToString();

            // Act
            sut.NotificationCreate(notificationId, microtingUId, Constants.Notifications.RetrievedForm);

            // Assert
            var notification = DbContext.notifications.SingleOrDefault(x => x.notification_uid == notificationId && x.microting_uid == microtingUId);

            Assert.NotNull(notification);
            Assert.AreEqual(1, DbContext.notifications.Count());
            Assert.AreEqual(Constants.Notifications.RetrievedForm, notification.activity);
            Assert.AreEqual(Constants.WorkflowStates.Created, notification.workflow_state);
        }

        [Test]
        public void SQL_Notification_NewNotificationCreateCompletedForm_DoesStoreNotification()
        {
            // Arrance
            var notificationId = Guid.NewGuid().ToString();
            var microtingUId = Guid.NewGuid().ToString();

            // Act
            sut.NotificationCreate(notificationId, microtingUId, Constants.Notifications.Completed);

            // Assert
            var notification = DbContext.notifications.SingleOrDefault(x => x.notification_uid == notificationId && x.microting_uid == microtingUId);

            Assert.NotNull(notification);
            Assert.AreEqual(1, DbContext.notifications.Count());
            Assert.AreEqual(Constants.Notifications.Completed, notification.activity);
            Assert.AreEqual(Constants.WorkflowStates.Created, notification.workflow_state);
        }

        [Test]
        public void SQL_Notification_NotificationReadFirst_DoesReturnFirstNotification()
        {
            // Arrance
            var notificationId1 = Guid.NewGuid().ToString();
            var microtingUId1 = Guid.NewGuid().ToString();
            var notificationId2 = Guid.NewGuid().ToString();
            var microtingUId2 = Guid.NewGuid().ToString();

            // Act
            sut.NotificationCreate(notificationId1, microtingUId1, Constants.Notifications.Completed);
            sut.NotificationCreate(notificationId2, microtingUId2, Constants.Notifications.Completed);

            // Assert
            Note_Dto notification = sut.NotificationReadFirst();

            Assert.NotNull(notification);
            Assert.AreEqual(2, DbContext.notifications.Count());
            Assert.AreEqual(Constants.Notifications.Completed, notification.Activity);
            Assert.AreEqual(microtingUId1, notification.MicrotingUId);
        }

        [Test]
        public void SQL_Notification_NotificationUpdate_DoesUpdateNotification()
        {
            // Arrance
            var notificationUId = Guid.NewGuid().ToString();
            var microtingUId = Guid.NewGuid().ToString();

            // Act
            sut.NotificationCreate(notificationUId, microtingUId, Constants.Notifications.Completed);
            sut.NotificationUpdate(notificationUId, microtingUId, Constants.WorkflowStates.Processed, "", "");

            // Assert
            var notification = DbContext.notifications.SingleOrDefault(x => x.notification_uid == notificationUId && x.microting_uid == microtingUId);

            Assert.NotNull(notification);
            Assert.AreEqual(1, DbContext.notifications.Count());
            Assert.AreEqual(Constants.Notifications.Completed, notification.activity);
            Assert.AreEqual(Constants.WorkflowStates.Processed, notification.workflow_state);
        }


        [Test]
        public void SQL_Notification_Notificationcreate_isCreated()
        {
            //notifications aNote1 = new notifications();

            //aNote1.workflow_state = Constants.WorkflowStates.Created;
            //aNote1.created_at = DateTime.Now;
            //aNote1.updated_at = DateTime.Now;
            //aNote1.notification_uid = Guid.NewGuid().ToString();
            //aNote1.microting_uid = Guid.NewGuid().ToString();
            //aNote1.activity = Constants.Notifications.UnitActivate;

            //DbContext.notifications.Add(aNote1);
            //DbContext.SaveChanges();

            //Act
            sut.NotificationCreate(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Constants.Notifications.UnitActivate);
            List<notifications> notificationResult = DbContext.notifications.AsNoTracking().ToList();
            var versionedMatches = DbContext.notifications.AsNoTracking().ToList();

            //Assert

            Assert.NotNull(notificationResult);
            Assert.AreEqual(1, notificationResult.Count);
            Assert.AreEqual(Constants.Notifications.UnitActivate, notificationResult[0].activity);
            Assert.AreEqual(Constants.WorkflowStates.Created, notificationResult[0].workflow_state);
            Assert.AreEqual(Constants.WorkflowStates.Created, versionedMatches[0].workflow_state);



        }

        [Test]
        public void SQL_Notification_NotificationReadFirst_doesReadFirst()
        {
            notifications aNote1 = new notifications();

            aNote1.workflow_state = Constants.WorkflowStates.Created;
            aNote1.created_at = DateTime.Now;
            aNote1.updated_at = DateTime.Now;
            aNote1.notification_uid = "0";
            aNote1.microting_uid = "1";
            aNote1.activity = Constants.Notifications.UnitActivate;

            DbContext.notifications.Add(aNote1);
            DbContext.SaveChanges();

            //Act
            sut.NotificationReadFirst();
            List<notifications> notificationResult = DbContext.notifications.AsNoTracking().ToList();
            var versionedMatches = DbContext.notifications.AsNoTracking().ToList();


            //assert
            Assert.AreEqual(Constants.WorkflowStates.Created, notificationResult[0].workflow_state);


        }

        [Test]
        public void SQL_Notification_NotificationUpdate_doesGetUpdated()
        {
            notifications aNote1 = new notifications();

            aNote1.workflow_state = Constants.WorkflowStates.Created;
            aNote1.created_at = DateTime.Now;
            aNote1.updated_at = DateTime.Now;
            aNote1.notification_uid = "0";
            aNote1.microting_uid = "1";
            aNote1.activity = Constants.Notifications.UnitActivate;

            DbContext.notifications.Add(aNote1);
            DbContext.SaveChanges();

            //Act
            sut.NotificationUpdate(aNote1.notification_uid, aNote1.microting_uid, aNote1.workflow_state, aNote1.exception, "");
            List<notifications> notificationResult = DbContext.notifications.AsNoTracking().ToList();
            var versionedMatches = DbContext.notifications.AsNoTracking().ToList();

            //Assert

            Assert.AreEqual(aNote1.notification_uid, notificationResult[0].notification_uid);
            Assert.AreEqual(aNote1.microting_uid, notificationResult[0].microting_uid);
        }
        #endregion

        #region eventhandlers
        public void EventCaseCreated(object sender, EventArgs args)
        {
            // Does nothing for web implementation
        }

        public void EventCaseRetrived(object sender, EventArgs args)
        {
            // Does nothing for web implementation
        }

        public void EventCaseCompleted(object sender, EventArgs args)
        {
            // Does nothing for web implementation
        }

        public void EventCaseDeleted(object sender, EventArgs args)
        {
            // Does nothing for web implementation
        }

        public void EventFileDownloaded(object sender, EventArgs args)
        {
            // Does nothing for web implementation
        }

        public void EventSiteActivated(object sender, EventArgs args)
        {
            // Does nothing for web implementation
        }
        #endregion
    }

}