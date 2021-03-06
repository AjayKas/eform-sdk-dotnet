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
    public class CoreTesteForm : DbTestFixture
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

        #region template
        
        [Test]
        public void Core_Template_TemplateItemReadAll_DoesReturnSortedTemplates()
        {
            // Arrance
            #region Tags

            string tagName1 = "TagFor1CL";
            tags tag1 = new tags();
            tag1.name = tagName1;
            tag1.workflow_state = Constants.WorkflowStates.Created;

            DbContext.tags.Add(tag1);
            DbContext.SaveChanges();

            string tagName2 = "TagFor2CLs";
            tags tag2 = new tags();
            tag2.name = tagName2;
            tag2.workflow_state = Constants.WorkflowStates.Created;

            DbContext.tags.Add(tag2);
            DbContext.SaveChanges();

            string tagName3 = "Tag3";
            tags tag3 = new tags();
            tag3.name = tagName3;
            tag3.workflow_state = Constants.WorkflowStates.Created;

            DbContext.tags.Add(tag3);
            DbContext.SaveChanges();

            string tagName4 = "Tag4";
            tags tag4 = new tags();
            tag4.name = tagName4;
            tag4.workflow_state = Constants.WorkflowStates.Created;

            DbContext.tags.Add(tag4);
            DbContext.SaveChanges();

            #endregion

            #region Template1
            check_lists cl1 = new check_lists();
            cl1.created_at = DateTime.Now;
            cl1.updated_at = DateTime.Now;
            cl1.label = "A";
            cl1.description = "D";
            cl1.workflow_state = Constants.WorkflowStates.Created;
            cl1.case_type = "CheckList";
            cl1.folder_name = "Template1FolderName";
            cl1.display_index = 1;
            cl1.repeated = 1;
            

            DbContext.check_lists.Add(cl1);
            DbContext.SaveChanges();
            Thread.Sleep(1000);
            #endregion

            #region Template2
            check_lists cl2 = new check_lists();
            cl2.created_at = DateTime.Now;
            cl2.updated_at = DateTime.Now;
            cl2.label = "B";
            cl2.description = "C";
            cl2.workflow_state = Constants.WorkflowStates.Removed;
            cl2.case_type = "CheckList";
            cl2.folder_name = "Template1FolderName";
            cl2.display_index = 1;
            cl2.repeated = 1;

            DbContext.check_lists.Add(cl2);
            DbContext.SaveChanges();
            Thread.Sleep(1000);
            #endregion

            #region Template3
            check_lists cl3 = new check_lists();
            cl3.created_at = DateTime.Now;
            cl3.updated_at = DateTime.Now;
            cl3.label = "D";
            cl3.description = "B";
            cl3.workflow_state = Constants.WorkflowStates.Created;
            cl3.case_type = "CheckList";
            cl3.folder_name = "Template1FolderName";
            cl3.display_index = 1;
            cl3.repeated = 1;

            DbContext.check_lists.Add(cl3);
            DbContext.SaveChanges();
            Thread.Sleep(1000);
            #endregion

            #region Template4
            check_lists cl4 = new check_lists();
            cl4.created_at = DateTime.Now;
            cl4.updated_at = DateTime.Now;
            cl4.label = "C";
            cl4.description = "A";
            cl4.workflow_state = Constants.WorkflowStates.Created;
            cl4.case_type = "CheckList";
            cl4.folder_name = "Template1FolderName";
            cl4.display_index = 1;
            cl4.repeated = 1;

            DbContext.check_lists.Add(cl4);
            DbContext.SaveChanges();
            #endregion

            #region assigning Tags
            List<int> tagIds1 = new List<int>();
            List<int> tagIds2 = new List<int>();
            List<int> tagIds3 = new List<int>();
            List<int> tagIds4 = new List<int>();



            tagIds1.Add(tag1.id);
            tagIds2.Add(tag2.id);
            tagIds3.Add(tag3.id);
            tagIds4.Add(tag3.id);
            tagIds4.Add(tag4.id);

            sut.TemplateSetTags(cl1.id, tagIds1);
            sut.TemplateSetTags(cl2.id, tagIds2);
            sut.TemplateSetTags(cl3.id, tagIds2);
            sut.TemplateSetTags(cl4.id, tagIds4);

            #endregion

            // Act
            List<int> emptyList = new List<int>();

            // Default sorting including removed
            List<Template_Dto> templateListId = sut.TemplateItemReadAll(true, Constants.WorkflowStates.Created, "", false, "", emptyList);
            List<Template_Dto> templateListLabel = sut.TemplateItemReadAll(true, Constants.WorkflowStates.Created, "", false, Constants.eFormSortParameters.Label, emptyList);
            List<Template_Dto> templateListDescription = sut.TemplateItemReadAll(true, Constants.WorkflowStates.Created, "", false, Constants.eFormSortParameters.Description, emptyList);
            List<Template_Dto> templateListCreatedAt = sut.TemplateItemReadAll(true, Constants.WorkflowStates.Created, "", false, Constants.eFormSortParameters.CreatedAt, emptyList);
            List<Template_Dto> templateListTag = sut.TemplateItemReadAll(true, Constants.WorkflowStates.Created, "", false, Constants.eFormSortParameters.Tags, emptyList);
            List<Template_Dto> templateListSpecificTag = sut.TemplateItemReadAll(true, Constants.WorkflowStates.Created, "", false, Constants.eFormSortParameters.Tags, tagIds2);


            // Descending including removed
            List<Template_Dto> templateListDescengingId = sut.TemplateItemReadAll(true, Constants.WorkflowStates.Created, "", true, "", emptyList);
            List<Template_Dto> templateListDescengingLabel = sut.TemplateItemReadAll(true, Constants.WorkflowStates.Created, "", true, Constants.eFormSortParameters.Label, emptyList);
            List<Template_Dto> templateListDescengingDescription = sut.TemplateItemReadAll(true, Constants.WorkflowStates.Created, "", true, Constants.eFormSortParameters.Description, emptyList);
            List<Template_Dto> templateListDescengingCreatedAt = sut.TemplateItemReadAll(true, Constants.WorkflowStates.Created, "", true, Constants.eFormSortParameters.CreatedAt, emptyList);
            List<Template_Dto> templateListDescendingTag = sut.TemplateItemReadAll(true, Constants.WorkflowStates.Created, "", true, Constants.eFormSortParameters.Tags, emptyList);
            List<Template_Dto> templateListDescendingSpecificTag = sut.TemplateItemReadAll(true, Constants.WorkflowStates.Created, "", true, Constants.eFormSortParameters.Tags, tagIds2);

            // Default sorting excluding removed
            List<Template_Dto> templateListIdNr = sut.TemplateItemReadAll(false, Constants.WorkflowStates.Created, "", false, "", emptyList);
            List<Template_Dto> templateListLabelNr = sut.TemplateItemReadAll(false, Constants.WorkflowStates.Created, "", false, Constants.eFormSortParameters.Label, emptyList);
            List<Template_Dto> templateListDescriptionNr = sut.TemplateItemReadAll(false, Constants.WorkflowStates.Created, "", false, Constants.eFormSortParameters.Description, emptyList);
            List<Template_Dto> templateListCreatedAtNr = sut.TemplateItemReadAll(false, Constants.WorkflowStates.Created, "", false, Constants.eFormSortParameters.CreatedAt, emptyList);
            List<Template_Dto> templateListTagNr = sut.TemplateItemReadAll(false, Constants.WorkflowStates.Created, "", false, Constants.eFormSortParameters.Tags, emptyList);
            List<Template_Dto> templateListSpecificTagNr = sut.TemplateItemReadAll(false, Constants.WorkflowStates.Created, "", false, Constants.eFormSortParameters.Tags, tagIds2);

            // Descending excluding removed
            List<Template_Dto> templateListDescengingIdNr = sut.TemplateItemReadAll(false, Constants.WorkflowStates.Created, "", true, "", emptyList);
            List<Template_Dto> templateListDescengingLabelNr = sut.TemplateItemReadAll(false, Constants.WorkflowStates.Created, "", true, Constants.eFormSortParameters.Label, emptyList);
            List<Template_Dto> templateListDescengingDescriptionNr = sut.TemplateItemReadAll(false, Constants.WorkflowStates.Created, "", true, Constants.eFormSortParameters.Description, emptyList);
            List<Template_Dto> templateListDescengingCreatedAtNr = sut.TemplateItemReadAll(false, Constants.WorkflowStates.Created, "", true, Constants.eFormSortParameters.CreatedAt, emptyList);
            List<Template_Dto> templateListDescendingTagNr = sut.TemplateItemReadAll(false, Constants.WorkflowStates.Created, "", true, Constants.eFormSortParameters.Tags, emptyList);
            List<Template_Dto> templateListDescendingSpecificTagNr = sut.TemplateItemReadAll(false, Constants.WorkflowStates.Created, "", true, Constants.eFormSortParameters.Tags, tagIds2);

            // Assert

            #region include removed
            // Default sorting including removed 
            // Id
            Assert.NotNull(templateListId);
            Assert.AreEqual(4, templateListId.Count());
            Assert.AreEqual("A", templateListId[0].Label);
            Assert.AreEqual("B", templateListId[1].Label);
            Assert.AreEqual("D", templateListId[2].Label);
            Assert.AreEqual("C", templateListId[3].Label);
            Assert.AreEqual(1, templateListId[0].Tags.Count());
            Assert.AreEqual(1, templateListId[1].Tags.Count());
            Assert.AreEqual(1, templateListId[2].Tags.Count());
            Assert.AreEqual(2, templateListId[3].Tags.Count());

            // Default sorting including removed 
            // Label
            Assert.NotNull(templateListLabel);
            Assert.AreEqual(4, templateListLabel.Count());
            Assert.AreEqual("A", templateListLabel[0].Label);
            Assert.AreEqual("B", templateListLabel[1].Label);
            Assert.AreEqual("C", templateListLabel[2].Label);
            Assert.AreEqual("D", templateListLabel[3].Label);
            Assert.AreEqual(1, templateListLabel[0].Tags.Count());
            Assert.AreEqual(1, templateListLabel[1].Tags.Count());
            Assert.AreEqual(2, templateListLabel[2].Tags.Count());
            Assert.AreEqual(1, templateListLabel[3].Tags.Count());

            // Default sorting including removed 
            // Description
            Assert.NotNull(templateListDescription);
            Assert.AreEqual(4, templateListDescription.Count());
            Assert.AreEqual("C", templateListDescription[0].Label);
            Assert.AreEqual("D", templateListDescription[1].Label);
            Assert.AreEqual("B", templateListDescription[2].Label);
            Assert.AreEqual("A", templateListDescription[3].Label);
            Assert.AreEqual(2, templateListDescription[0].Tags.Count());
            Assert.AreEqual(1, templateListDescription[1].Tags.Count());
            Assert.AreEqual(1, templateListDescription[2].Tags.Count());
            Assert.AreEqual(1, templateListDescription[3].Tags.Count());

            // Default sorting including removed 
            // Created At
            Assert.NotNull(templateListCreatedAt);
            Assert.AreEqual(4, templateListCreatedAt.Count());
            Assert.AreEqual("A", templateListCreatedAt[0].Label);
            Assert.AreEqual("B", templateListCreatedAt[1].Label);
            Assert.AreEqual("D", templateListCreatedAt[2].Label);
            Assert.AreEqual("C", templateListCreatedAt[3].Label);
            Assert.AreEqual(1, templateListCreatedAt[0].Tags.Count());
            Assert.AreEqual(1, templateListCreatedAt[1].Tags.Count());
            Assert.AreEqual(1, templateListCreatedAt[2].Tags.Count());
            Assert.AreEqual(2, templateListCreatedAt[3].Tags.Count());

            // Default sorting including removed
            // Tag
            Assert.NotNull(templateListTag);
            Assert.AreEqual(4, templateListTag.Count());
            Assert.AreEqual("A", templateListTag[0].Label);
            Assert.AreEqual("B", templateListTag[1].Label);
            Assert.AreEqual("D", templateListTag[2].Label);
            Assert.AreEqual("C", templateListTag[3].Label);
            Assert.AreEqual(1, templateListTag[0].Tags.Count());
            Assert.AreEqual(1, templateListTag[1].Tags.Count());
            Assert.AreEqual(1, templateListTag[2].Tags.Count());
            Assert.AreEqual(2, templateListTag[3].Tags.Count());
            Assert.AreEqual("TagFor1CL", templateListTag[0].Tags[0].Value);
            Assert.AreEqual("TagFor2CLs", templateListTag[1].Tags[0].Value);
            Assert.AreEqual("TagFor2CLs", templateListTag[2].Tags[0].Value);
            Assert.AreEqual("Tag3", templateListTag[3].Tags[0].Value);
            Assert.AreEqual("Tag4", templateListTag[3].Tags[1].Value);

            // Default sorting including removed
            // Tagid 
            Assert.NotNull(templateListSpecificTag);
            Assert.AreEqual(2, templateListSpecificTag.Count());
            Assert.AreEqual("B", templateListSpecificTag[0].Label);
            Assert.AreEqual("D", templateListSpecificTag[1].Label);
            Assert.AreEqual(1, templateListSpecificTag[0].Tags.Count());
            Assert.AreEqual(1, templateListSpecificTag[1].Tags.Count());
            Assert.AreEqual("TagFor2CLs", templateListSpecificTag[0].Tags[0].Value);
            Assert.AreEqual("TagFor2CLs", templateListSpecificTag[1].Tags[0].Value);

            // Descending sorting including removed 
            // Id
            Assert.NotNull(templateListDescengingId);
            Assert.AreEqual(4, templateListDescengingId.Count());
            Assert.AreEqual("C", templateListDescengingId[0].Label);
            Assert.AreEqual("D", templateListDescengingId[1].Label);
            Assert.AreEqual("B", templateListDescengingId[2].Label);
            Assert.AreEqual("A", templateListDescengingId[3].Label);
            Assert.AreEqual(2, templateListDescengingId[0].Tags.Count());
            Assert.AreEqual(1, templateListDescengingId[1].Tags.Count());
            Assert.AreEqual(1, templateListDescengingId[2].Tags.Count());
            Assert.AreEqual(1, templateListDescengingId[3].Tags.Count());

            // Descending sorting including removed 
            // Label
            Assert.NotNull(templateListDescengingLabel);
            Assert.AreEqual(4, templateListDescengingLabel.Count());
            Assert.AreEqual("D", templateListDescengingLabel[0].Label);
            Assert.AreEqual("C", templateListDescengingLabel[1].Label);
            Assert.AreEqual("B", templateListDescengingLabel[2].Label);
            Assert.AreEqual("A", templateListDescengingLabel[3].Label);
            Assert.AreEqual(1, templateListDescengingLabel[0].Tags.Count());
            Assert.AreEqual(2, templateListDescengingLabel[1].Tags.Count());
            Assert.AreEqual(1, templateListDescengingLabel[2].Tags.Count());
            Assert.AreEqual(1, templateListDescengingLabel[3].Tags.Count());

            // Descending sorting including removed 
            // Description
            Assert.NotNull(templateListDescengingDescription);
            Assert.AreEqual(4, templateListDescengingDescription.Count());
            Assert.AreEqual("A", templateListDescengingDescription[0].Label);
            Assert.AreEqual("B", templateListDescengingDescription[1].Label);
            Assert.AreEqual("D", templateListDescengingDescription[2].Label);
            Assert.AreEqual("C", templateListDescengingDescription[3].Label);
            Assert.AreEqual(1, templateListDescengingDescription[0].Tags.Count());
            Assert.AreEqual(1, templateListDescengingDescription[1].Tags.Count());
            Assert.AreEqual(1, templateListDescengingDescription[2].Tags.Count());
            Assert.AreEqual(2, templateListDescengingDescription[3].Tags.Count());

            // Descending sorting including removed 
            // Created At
            Assert.NotNull(templateListDescengingCreatedAt);
            Assert.AreEqual(4, templateListDescengingCreatedAt.Count());
            Assert.AreEqual("C", templateListDescengingCreatedAt[0].Label);
            Assert.AreEqual("D", templateListDescengingCreatedAt[1].Label);
            Assert.AreEqual("B", templateListDescengingCreatedAt[2].Label);
            Assert.AreEqual("A", templateListDescengingCreatedAt[3].Label);
            Assert.AreEqual(2, templateListDescengingCreatedAt[0].Tags.Count());
            Assert.AreEqual(1, templateListDescengingCreatedAt[1].Tags.Count());
            Assert.AreEqual(1, templateListDescengingCreatedAt[2].Tags.Count());
            Assert.AreEqual(1, templateListDescengingCreatedAt[3].Tags.Count());

            // Descending sorting including removed
            // Tag
            Assert.NotNull(templateListTag);
            Assert.AreEqual(4, templateListTag.Count());
            Assert.AreEqual("C", templateListDescendingTag[0].Label);
            Assert.AreEqual("D", templateListDescendingTag[1].Label);
            Assert.AreEqual("B", templateListDescendingTag[2].Label);
            Assert.AreEqual("A", templateListDescendingTag[3].Label);
            Assert.AreEqual(2, templateListDescendingTag[0].Tags.Count());
            Assert.AreEqual(1, templateListDescendingTag[1].Tags.Count());
            Assert.AreEqual(1, templateListDescendingTag[2].Tags.Count());
            Assert.AreEqual(1, templateListDescendingTag[3].Tags.Count());
            Assert.AreEqual("Tag3", templateListDescendingTag[0].Tags[0].Value);
            Assert.AreEqual("Tag4", templateListDescendingTag[0].Tags[1].Value);
            Assert.AreEqual("TagFor2CLs", templateListDescendingTag[1].Tags[0].Value);
            Assert.AreEqual("TagFor2CLs", templateListDescendingTag[2].Tags[0].Value);
            Assert.AreEqual("TagFor1CL", templateListDescendingTag[3].Tags[0].Value);

            // Descending sorting including removed
            // Tagid 
            Assert.NotNull(templateListDescendingSpecificTag);
            Assert.AreEqual(2, templateListDescendingSpecificTag.Count());
            Assert.AreEqual("D", templateListDescendingSpecificTag[0].Label);
            Assert.AreEqual("B", templateListDescendingSpecificTag[1].Label);
            Assert.AreEqual(1, templateListDescendingSpecificTag[0].Tags.Count());
            Assert.AreEqual(1, templateListDescendingSpecificTag[1].Tags.Count());
            Assert.AreEqual("TagFor2CLs", templateListDescendingSpecificTag[0].Tags[0].Value);
            Assert.AreEqual("TagFor2CLs", templateListDescendingSpecificTag[1].Tags[0].Value);
            #endregion

            #region Exclude removed
            // Default sorting excluding removed 
            // Id
            Assert.NotNull(templateListIdNr);
            Assert.AreEqual(3, templateListIdNr.Count());
            Assert.AreEqual("A", templateListIdNr[0].Label);
            Assert.AreEqual("D", templateListIdNr[1].Label);
            Assert.AreEqual("C", templateListIdNr[2].Label);
            Assert.AreEqual(1, templateListIdNr[0].Tags.Count());
            Assert.AreEqual(1, templateListIdNr[1].Tags.Count());
            Assert.AreEqual(2, templateListIdNr[2].Tags.Count());

            // Default sorting excluding removed 
            // Label
            Assert.NotNull(templateListLabelNr);
            Assert.AreEqual(3, templateListLabelNr.Count());
            Assert.AreEqual("A", templateListLabelNr[0].Label);
            Assert.AreEqual("C", templateListLabelNr[1].Label);
            Assert.AreEqual("D", templateListLabelNr[2].Label);
            Assert.AreEqual(1, templateListLabelNr[0].Tags.Count());
            Assert.AreEqual(2, templateListLabelNr[1].Tags.Count());
            Assert.AreEqual(1, templateListLabelNr[2].Tags.Count());

            // Default sorting excluding removed 
            // Description
            Assert.NotNull(templateListDescriptionNr);
            Assert.AreEqual(3, templateListDescriptionNr.Count());
            Assert.AreEqual("C", templateListDescriptionNr[0].Label);
            Assert.AreEqual("D", templateListDescriptionNr[1].Label);
            Assert.AreEqual("A", templateListDescriptionNr[2].Label);
            Assert.AreEqual(2, templateListDescriptionNr[0].Tags.Count());
            Assert.AreEqual(1, templateListDescriptionNr[1].Tags.Count());
            Assert.AreEqual(1, templateListDescriptionNr[2].Tags.Count());

            // Default sorting excluding removed 
            // Created At
            Assert.NotNull(templateListCreatedAtNr);
            Assert.AreEqual(3, templateListCreatedAtNr.Count());
            Assert.AreEqual("A", templateListCreatedAtNr[0].Label);
            Assert.AreEqual("D", templateListCreatedAtNr[1].Label);
            Assert.AreEqual("C", templateListCreatedAtNr[2].Label);
            Assert.AreEqual(1, templateListCreatedAtNr[0].Tags.Count());
            Assert.AreEqual(1, templateListCreatedAtNr[1].Tags.Count());
            Assert.AreEqual(2, templateListCreatedAtNr[2].Tags.Count());

            // Default sorting excluding removed
            // Tag
            Assert.NotNull(templateListTag);
            Assert.AreEqual(4, templateListTag.Count());
            Assert.AreEqual("A", templateListTagNr[0].Label);
            Assert.AreEqual("D", templateListTagNr[1].Label);
            Assert.AreEqual("C", templateListTagNr[2].Label);
            Assert.AreEqual(1, templateListTagNr[0].Tags.Count());
            Assert.AreEqual(1, templateListTagNr[1].Tags.Count());
            Assert.AreEqual(2, templateListTagNr[2].Tags.Count());
            Assert.AreEqual("TagFor1CL", templateListTagNr[0].Tags[0].Value);
            Assert.AreEqual("TagFor2CLs", templateListTagNr[1].Tags[0].Value);
            Assert.AreEqual("Tag3", templateListTagNr[2].Tags[0].Value);
            Assert.AreEqual("Tag4", templateListTagNr[2].Tags[1].Value);

            // Default sorting excluding removed
            // Tagid 
            Assert.NotNull(templateListSpecificTagNr);
            Assert.AreEqual(1, templateListSpecificTagNr.Count());
            Assert.AreEqual("D", templateListSpecificTagNr[0].Label);
            Assert.AreEqual(1, templateListSpecificTagNr[0].Tags.Count());
            Assert.AreEqual("TagFor2CLs", templateListSpecificTagNr[0].Tags[0].Value);

            // Descending sorting excluding removed 
            // Id
            Assert.NotNull(templateListDescengingIdNr);
            Assert.AreEqual(3, templateListDescengingIdNr.Count());
            Assert.AreEqual("C", templateListDescengingIdNr[0].Label);
            Assert.AreEqual("D", templateListDescengingIdNr[1].Label);
            Assert.AreEqual("A", templateListDescengingIdNr[2].Label);
            Assert.AreEqual(2, templateListDescengingIdNr[0].Tags.Count());
            Assert.AreEqual(1, templateListDescengingIdNr[1].Tags.Count());
            Assert.AreEqual(1, templateListDescengingIdNr[2].Tags.Count());

            // Descending sorting excluding removed 
            // Label
            Assert.NotNull(templateListDescengingLabelNr);
            Assert.AreEqual(3, templateListDescengingLabelNr.Count());
            Assert.AreEqual("D", templateListDescengingLabelNr[0].Label);
            Assert.AreEqual("C", templateListDescengingLabelNr[1].Label);
            Assert.AreEqual("A", templateListDescengingLabelNr[2].Label);
            Assert.AreEqual(1, templateListDescengingLabelNr[0].Tags.Count());
            Assert.AreEqual(2, templateListDescengingLabelNr[1].Tags.Count());
            Assert.AreEqual(1, templateListDescengingLabelNr[2].Tags.Count());

            // Descending sorting excluding removed 
            // Description
            Assert.NotNull(templateListDescengingDescriptionNr);
            Assert.AreEqual(3, templateListDescengingDescriptionNr.Count());
            Assert.AreEqual("A", templateListDescengingDescriptionNr[0].Label);
            Assert.AreEqual("D", templateListDescengingDescriptionNr[1].Label);
            Assert.AreEqual("C", templateListDescengingDescriptionNr[2].Label);
            Assert.AreEqual(1, templateListDescengingDescriptionNr[0].Tags.Count());
            Assert.AreEqual(1, templateListDescengingDescriptionNr[1].Tags.Count());
            Assert.AreEqual(2, templateListDescengingDescriptionNr[2].Tags.Count());

            // Descending sorting excluding removed 
            // Created At
            Assert.NotNull(templateListDescengingCreatedAtNr);
            Assert.AreEqual(3, templateListDescengingCreatedAtNr.Count());
            Assert.AreEqual("C", templateListDescengingCreatedAtNr[0].Label);
            Assert.AreEqual("D", templateListDescengingCreatedAtNr[1].Label);
            Assert.AreEqual("A", templateListDescengingCreatedAtNr[2].Label);
            Assert.AreEqual(2, templateListDescengingCreatedAtNr[0].Tags.Count());
            Assert.AreEqual(1, templateListDescengingCreatedAtNr[1].Tags.Count());
            Assert.AreEqual(1, templateListDescengingCreatedAtNr[2].Tags.Count());

            // Descending sorting excluding removed
            // Tag
            Assert.NotNull(templateListTag);
            Assert.AreEqual(4, templateListTag.Count());
            Assert.AreEqual("C", templateListDescendingTagNr[0].Label);
            Assert.AreEqual("D", templateListDescendingTagNr[1].Label);
            Assert.AreEqual("A", templateListDescendingTagNr[2].Label);
            Assert.AreEqual(2, templateListDescendingTagNr[0].Tags.Count());
            Assert.AreEqual(1, templateListDescendingTagNr[1].Tags.Count());
            Assert.AreEqual(1, templateListDescendingTagNr[2].Tags.Count());
            Assert.AreEqual("Tag3", templateListDescendingTagNr[0].Tags[0].Value);
            Assert.AreEqual("Tag4", templateListDescendingTagNr[0].Tags[1].Value);
            Assert.AreEqual("TagFor2CLs", templateListDescendingTagNr[1].Tags[0].Value);
            Assert.AreEqual("TagFor1CL", templateListDescendingTagNr[2].Tags[0].Value);

            // Descending sorting excluding removed
            // Tagid 
            Assert.NotNull(templateListDescendingSpecificTagNr);
            Assert.AreEqual(1, templateListDescendingSpecificTagNr.Count());
            Assert.AreEqual("D", templateListDescendingSpecificTagNr[0].Label);
            Assert.AreEqual(1, templateListDescendingSpecificTagNr[0].Tags.Count());
            Assert.AreEqual("TagFor2CLs", templateListDescendingSpecificTagNr[0].Tags[0].Value);

            #endregion

        }
        [Test]
        public void Core_Template_TemplateValidation_ReturnsErrorLst()
        {
            //Arrance
            CoreElement CElement = new CoreElement();
            //CElement.ElementList = new List<Element>();

            DateTime startDt = DateTime.Now;
            DateTime endDt = DateTime.Now;
            MainElement main = new MainElement(1, "label1", 4, "folderWithList", 1, startDt,
                endDt, "Swahili", false, true, false, true, "type1", "MessageTitle",
                "MessageBody", false, CElement.ElementList);
            //Act
            var match = sut.TemplateValidation(main);
            //Assert
            Assert.NotNull(match);
            Assert.AreEqual(match.Count(), 0);
        }
        [Test]
        public void Core_Template_TemplateUploadData_ReturnsmainElement()
        {
            //Arrance
            CoreElement CElement = new CoreElement();
            //CElement.ElementList = new List<Element>();

            DateTime startDt = DateTime.Now;
            DateTime endDt = DateTime.Now;
            MainElement main = new MainElement(1, "label1", 0, "folderWithList", 1, startDt,
                endDt, "Swahili", false, true, true, true, "type1", "MessageTitle",
                "MessageBody", false, CElement.ElementList);
            //Act
            var match = sut.TemplateUploadData(main);
            //Assert
            #region Assert
            Assert.NotNull(match);
            Assert.AreEqual(match.CaseType, main.CaseType);
            Assert.AreEqual(match.CheckListFolderName, main.CheckListFolderName);
            Assert.AreEqual(match.DisplayOrder, main.DisplayOrder);
            Assert.AreEqual(match.DownloadEntities, main.DownloadEntities);
            Assert.AreEqual(match.ElementList, main.ElementList);
            Assert.AreEqual(match.EndDate, main.EndDate);
            Assert.AreEqual(match.EndDateString, main.EndDateString);
            Assert.AreEqual(match.FastNavigation, main.FastNavigation);
            Assert.AreEqual(match.Id, main.Id);
            Assert.AreEqual(match.Label, main.Label);
            Assert.AreEqual(match.Language, main.Language);
            Assert.AreEqual(match.ManualSync, main.ManualSync);
            Assert.AreEqual(match.MicrotingUId, main.MicrotingUId);
            Assert.AreEqual(match.MultiApproval, main.MultiApproval);
            Assert.AreEqual(match.PushMessageBody, main.PushMessageBody);
            Assert.AreEqual(match.PushMessageTitle, main.PushMessageTitle);
            Assert.AreEqual(match.Repeated, main.Repeated);
            Assert.AreEqual(match.StartDate, main.StartDate);
            Assert.AreEqual(match.StartDateString, main.StartDateString);
            Assert.AreEqual(match, main);
            #endregion
        }
        [Test]
        public void Core_Template_TemplateCreate_CreatesTemplate()
        {

            //Arrance
            CoreElement CElement = new CoreElement();
            //CElement.ElementList = new List<Element>();

            DateTime startDt = DateTime.Now;
            DateTime endDt = DateTime.Now;
            MainElement main = new MainElement(1, "label1", 0, "folderWithList", 1, startDt,
                endDt, "Swahili", false, true, true, true, "type1", "MessageTitle",
                "MessageBody", false, CElement.ElementList);
            //Act
            var match = sut.TemplateCreate(main);
            //Assert

            Assert.NotNull(match);
            Assert.AreEqual(match, main.Id);

        }
        [Test]
        public void Core_Template_TemplateRead_ReturnsTemplate()
        {
            //Arrance
            #region Tempalte

            DateTime cl1_ca = DateTime.Now;
            DateTime cl1_ua = DateTime.Now;
            check_lists cl1 = testHelpers.CreateTemplate(cl1_ca, cl1_ua, "A", "D", "CheckList", "Template1FolderName", 1, 1);

            #endregion

            //Act
            var match = sut.TemplateRead(cl1.id);

            //Assert
            Assert.NotNull(match);
            Assert.AreEqual(match.Id, cl1.id);
            Assert.AreEqual(match.CaseType, cl1.case_type);
            Assert.AreEqual(match.FastNavigation, false);
            Assert.AreEqual(match.Label, cl1.label);
            Assert.AreEqual(match.ManualSync, false);
            Assert.AreEqual(match.MultiApproval, false);
            Assert.AreEqual(match.Repeated, cl1.repeated);


        }

        [Test]
        public void Core_Template_TemplateDelete_SetsWorkflowStateToRemoved()
        {
            //Arrance
            #region Tempalte1

            DateTime cl1_ca = DateTime.Now;
            DateTime cl1_ua = DateTime.Now;
            check_lists cl1 = testHelpers.CreateTemplate(cl1_ca, cl1_ua, "A", "D", "CheckList", "Template1FolderName", 1, 1);

            #endregion
            #region Tempalte2

            DateTime cl2_ca = DateTime.Now;
            DateTime cl2_ua = DateTime.Now;
            check_lists cl2 = testHelpers.CreateTemplate(cl2_ca, cl2_ua, "A", "D", "CheckList", "Template1FolderName", 1, 1);

            #endregion
            #region Tempalte3

            DateTime cl3_ca = DateTime.Now;
            DateTime cl3_ua = DateTime.Now;
            check_lists cl3 = testHelpers.CreateTemplate(cl3_ca, cl3_ua, "A", "D", "CheckList", "Template1FolderName", 1, 1);

            #endregion
            #region Tempalte4

            DateTime cl4_ca = DateTime.Now;
            DateTime cl4_ua = DateTime.Now;
            check_lists cl4 = testHelpers.CreateTemplate(cl4_ca, cl4_ua, "A", "D", "CheckList", "Template1FolderName", 1, 1);

            #endregion
            //Act
            var deleteTemplate1 = sut.TemplateDelete(cl1.id);
            var deleteTemplate2 = sut.TemplateDelete(cl2.id);
            var deleteTemplate3 = sut.TemplateDelete(cl3.id);
            var deleteTemplate4 = sut.TemplateDelete(cl4.id);
            //Assert
            Assert.NotNull(deleteTemplate1);
            Assert.NotNull(deleteTemplate2);
            Assert.NotNull(deleteTemplate3);
            Assert.NotNull(deleteTemplate4);
            Assert.True(deleteTemplate1);
            Assert.True(deleteTemplate2);
            Assert.True(deleteTemplate3);
            Assert.True(deleteTemplate4);

        }
        [Test]
        public void Core_Template_TemplateItemRead_ReadsTemplateItems()
        {
            // Arrance
            #region Templates

            #region template1
            DateTime cl1_ca = DateTime.Now;
            DateTime cl1_ua = DateTime.Now;
            check_lists Template1 = testHelpers.CreateTemplate(cl1_ca, cl1_ua, "Label1", "Description1",
                "CaseType1", "FolderWithTemplate", 1, 0);

            #endregion

            #region template2
            DateTime cl2_ca = DateTime.Now;
            DateTime cl2_ua = DateTime.Now;
            check_lists Template2 = testHelpers.CreateTemplate(cl2_ca, cl2_ua, "Label2", "Description2",
                "CaseType2", "FolderWithTemplate", 0, 1);

            #endregion

            #region template3
            DateTime cl3_ca = DateTime.Now;
            DateTime cl3_ua = DateTime.Now;
            check_lists Template3 = testHelpers.CreateTemplate(cl3_ca, cl3_ua, "Label3", "Description3",
                "CaseType3", "FolderWithTemplate", 1, 1);

            #endregion

            #region template4
            DateTime cl4_ca = DateTime.Now;
            DateTime cl4_ua = DateTime.Now;
            check_lists Template4 = testHelpers.CreateTemplate(cl4_ca, cl4_ua, "Label4", "Description4",
                "CaseType4", "FolderWithTemplate", 0, 0);

            #endregion

            #endregion

            #region SubTemplates

            #region subTemplate1

            check_lists subTemplate1 = testHelpers.CreateSubTemplate("SubLabel1", "SubDescription1",
                "CaseType1", 1, 0, Template1);

            #endregion

            #region subTemplate2

            check_lists subTemplate2 = testHelpers.CreateSubTemplate("SubLabel2", "SubDescription2",
                "CaseType2", 0, 1, Template2);

            #endregion

            #region subTemplate3

            check_lists subTemplate3 = testHelpers.CreateSubTemplate("SubLabel3", "SubDescription3",
                "CaseType3", 1, 1, Template3);

            #endregion

            #region subTemplate4

            check_lists subTemplate4 = testHelpers.CreateSubTemplate("SubLabel4", "SubDescription4",
                "CaseType4", 0, 0, Template4);

            #endregion

            #endregion

            #region Fields

            #region Field1

            fields Field1 = testHelpers.CreateField(1, "barcode", subTemplate1, "e2f4fb", "custom", null, "", "Comment field description",
                5, 1, DbContext.field_types.Where(x => x.field_type == "picture").First(), 0, 0, 1, 0, "Comment field", 1, 55, "55", "0", 0, 0, null, 1, 0,
                0, 0, "", 49);

            #endregion

            #region Field2

            fields Field2 = testHelpers.CreateField(1, "barcode", subTemplate1, "f5eafa", "custom", null, "", "showPDf Description",
                45, 1, DbContext.field_types.Where(x => x.field_type == "comment").First(), 0, 1, 0, 0,
                "ShowPdf", 0, 5, "5", "0", 0, 0, null, 0, 0, 0, 0, "", 9);

            #endregion

            #region Field3

            fields Field3 = testHelpers.CreateField(0, "barcode", subTemplate2, "f0f8db", "custom", 3, "", "Number Field Description",
                83, 0, DbContext.field_types.Where(x => x.field_type == "picture").First(), 0, 0, 1, 0,
                "Numberfield", 1, 8, "4865", "0", 0, 1, null, 1, 0, 0, 0, "", 1);


            #endregion

            #region Field4

            fields Field4 = testHelpers.CreateField(1, "barcode", subTemplate2, "fff6df", "custom", null, "", "date Description",
                84, 0, DbContext.field_types.Where(x => x.field_type == "picture").First(), 0, 0, 1, 0,
                "Date", 1, 666, "41153", "0", 0, 1, null, 0, 1, 0, 0, "", 1);


            #endregion

            #region Field5

            fields Field5 = testHelpers.CreateField(0, "barcode", subTemplate2, "ffe4e4", "custom", null, "", "picture Description",
                85, 0, DbContext.field_types.Where(x => x.field_type == "comment").First(), 1, 0, 1, 0,
                "Picture", 1, 69, "69", "1", 0, 1, null, 0, 1, 0, 0, "", 1);


            #endregion

            #region Field6

            fields Field6 = testHelpers.CreateField(0, "barcode", subTemplate3, "ffe4e4", "custom", null, "", "picture Description",
                86, 0, DbContext.field_types.Where(x => x.field_type == "comment").First(), 1, 0, 1, 0,
                "Picture", 1, 69, "69", "1", 0, 1, null, 0, 1, 0, 0, "", 1);


            #endregion

            #region Field7

            fields Field7 = testHelpers.CreateField(0, "barcode", subTemplate3, "ffe4e4", "custom", null, "", "picture Description",
                87, 0, DbContext.field_types.Where(x => x.field_type == "comment").First(), 1, 0, 1, 0,
                "Picture", 1, 69, "69", "1", 0, 1, null, 0, 1, 0, 0, "", 1);


            #endregion

            #region Field8

            fields Field8 = testHelpers.CreateField(0, "barcode", subTemplate4, "ffe4e4", "custom", null, "", "picture Description",
                88, 0, DbContext.field_types.Where(x => x.field_type == "comment").First(), 1, 0, 1, 0,
                "Picture", 1, 69, "69", "1", 0, 1, null, 0, 1, 0, 0, "", 1);


            #endregion

            #region Field9

            fields Field9 = testHelpers.CreateField(0, "barcode", subTemplate4, "ffe4e4", "custom", null, "", "picture Description",
                89, 0, DbContext.field_types.Where(x => x.field_type == "comment").First(), 1, 0, 1, 0,
                "Picture", 1, 69, "69", "1", 0, 1, null, 0, 1, 0, 0, "", 1);


            #endregion

            #region Field10

            fields Field10 = testHelpers.CreateField(0, "barcode", subTemplate4, "ffe4e4", "custom", null, "", "picture Description",
                90, 0, DbContext.field_types.Where(x => x.field_type == "comment").First(), 1, 0, 1, 0,
                "Picture", 1, 69, "69", "1", 0, 1, null, 0, 1, 0, 0, "", 1);


            #endregion


            #endregion

            #region Tag

            //tags tag = testHelpers.CreateTag("Tag1", Constants.WorkflowStates.Created, 1);

            #endregion
            // Act

            var match1 = sut.TemplateItemRead(Template1.id);
            var match2 = sut.TemplateItemRead(Template2.id);
            var match3 = sut.TemplateItemRead(Template3.id);
            var match4 = sut.TemplateItemRead(Template4.id);


            // Assert
            #region template1
            Assert.NotNull(match1);
            Assert.AreEqual(match1.Description, "Description1");
            Assert.AreEqual(match1.Label, "Label1");
            Assert.AreEqual(match1.CreatedAt.ToString(), Template1.created_at.ToString());
            Assert.AreEqual(match1.FolderName, "FolderWithTemplate");
            Assert.AreEqual(match1.Id, Template1.id);
            Assert.AreEqual(match1.UpdatedAt.ToString(), Template1.updated_at.ToString());
            #endregion

            #region template2
            Assert.NotNull(match1);
            Assert.AreEqual(match2.Description, "Description2");
            Assert.AreEqual(match2.Label, "Label2");
            Assert.AreEqual(match2.CreatedAt.ToString(), Template2.created_at.ToString());
            Assert.AreEqual(match2.FolderName, "FolderWithTemplate");
            Assert.AreEqual(match2.Id, Template2.id);
            Assert.AreEqual(match2.UpdatedAt.ToString(), Template2.updated_at.ToString());
            #endregion

            #region template3
            Assert.NotNull(match1);
            Assert.AreEqual(match3.Description, "Description3");
            Assert.AreEqual(match3.Label, "Label3");
            Assert.AreEqual(match3.CreatedAt.ToString(), Template3.created_at.ToString());
            Assert.AreEqual(match3.FolderName, "FolderWithTemplate");
            Assert.AreEqual(match3.Id, Template3.id);
            Assert.AreEqual(match3.UpdatedAt.ToString(), Template3.updated_at.ToString());
            #endregion

            #region template4
            Assert.NotNull(match1);
            Assert.AreEqual(match4.Description, "Description4");
            Assert.AreEqual(match4.Label, "Label4");
            Assert.AreEqual(match4.CreatedAt.ToString(), Template4.created_at.ToString());
            Assert.AreEqual(match4.FolderName, "FolderWithTemplate");
            Assert.AreEqual(match4.Id, Template4.id);
            Assert.AreEqual(match4.UpdatedAt.ToString(), Template4.updated_at.ToString());
            #endregion
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