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
    public class SqlControllerTestCaseReadAllLong : DbTestFixture
    {
        private SqlController sut;
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

            sut = new SqlController(ConnectionString);
            sut.StartLog(new CoreBase());
            testHelpers = new TestHelpers();
            sut.SettingUpdate(Settings.fileLocationPicture, path + @"\output\dataFolder\picture\");
            sut.SettingUpdate(Settings.fileLocationPdf, path + @"\output\dataFolder\pdf\");
            sut.SettingUpdate(Settings.fileLocationJasper, path + @"\output\dataFolder\reports\");
        }



        [Test]
        public void SQL_PostCase_CaseReadAll()
        {


            // Arrance
            #region Arrance
            #region Template1
            DateTime cl1_Ca = DateTime.Now;
            DateTime cl1_Ua = DateTime.Now;
            check_lists cl1 = testHelpers.CreateTemplate(cl1_Ca, cl1_Ua, "A", "D", "CheckList", "Template1FolderName", 1, 1);

            #endregion

            #region SubTemplate1
            check_lists cl2 = testHelpers.CreateSubTemplate("A.1", "D.1", "CheckList", 1, 1, cl1);


            #endregion

            #region Fields
            #region field1


            fields f1 = testHelpers.CreateField(1, "barcode", cl2, "e2f4fb", "custom", null, "", "Comment field description",
                5, 1, DbContext.field_types.Where(x => x.field_type == "picture").First(), 0, 0, 1, 0, "Comment field", 1, 55, "55", "0", 0, 0, null, 1, 0,
                0, 0, "", 49);

            #endregion

            #region field2


            fields f2 = testHelpers.CreateField(1, "barcode", cl2, "f5eafa", "custom", null, "", "showPDf Description",
                45, 1, DbContext.field_types.Where(x => x.field_type == "comment").First(), 0, 1, 0, 0,
                "ShowPdf", 0, 5, "5", "0", 0, 0, null, 0, 0, 0, 0, "", 9);


            #endregion

            #region field3

            fields f3 = testHelpers.CreateField(0, "barcode", cl2, "f0f8db", "custom", 3, "", "Number Field Description",
                83, 0, DbContext.field_types.Where(x => x.field_type == "picture").First(), 0, 0, 1, 0,
                "Numberfield", 1, 8, "4865", "0", 0, 1, null, 1, 0, 0, 0, "", 1);


            #endregion

            #region field4


            fields f4 = testHelpers.CreateField(1, "barcode", cl2, "fff6df", "custom", null, "", "date Description",
                84, 0, DbContext.field_types.Where(x => x.field_type == "picture").First(), 0, 0, 1, 0,
                "Date", 1, 666, "41153", "0", 0, 1, null, 0, 1, 0, 0, "", 1);


            #endregion

            #region field5

            fields f5 = testHelpers.CreateField(0, "barcode", cl2, "ffe4e4", "custom", null, "", "picture Description",
                85, 0, DbContext.field_types.Where(x => x.field_type == "comment").First(), 1, 0, 1, 0,
                "Picture", 1, 69, "69", "1", 0, 1, null, 0, 1, 0, 0, "", 1);


            #endregion
            #endregion

            #region Worker

            workers worker = testHelpers.CreateWorker("aa@tak.dk", "Arne", "Jensen", 21);

            #endregion

            #region site
            sites site = testHelpers.CreateSite("SiteName", 88);

            #endregion

            #region units
            units unit = testHelpers.CreateUnit(48, 49, site, 348);

            #endregion

            #region site_workers
            site_workers site_workers = testHelpers.CreateSiteWorker(55, site, worker);

            #endregion

            #region cases
            #region cases created
            #region Case1

            DateTime c1_ca = DateTime.Now.AddDays(-9);
            DateTime c1_da = DateTime.Now.AddDays(-8).AddHours(-12);
            DateTime c1_ua = DateTime.Now.AddDays(-8);

            cases aCase1 = testHelpers.CreateCase("case1UId", cl1, c1_ca, "custom1",
                c1_da, worker, "microtingCheckUId1", "microtingUId1",
               site, 1, "caseType1", unit, c1_ua, 1, worker, Constants.WorkflowStates.Created);

            #endregion

            #region Case2

            DateTime c2_ca = DateTime.Now.AddDays(-7);
            DateTime c2_da = DateTime.Now.AddDays(-6).AddHours(-12);
            DateTime c2_ua = DateTime.Now.AddDays(-6);
            cases aCase2 = testHelpers.CreateCase("case2UId", cl1, c2_ca, "custom2",
             c2_da, worker, "microtingCheck2UId", "microting2UId",
               site, 10, "caseType2", unit, c2_ua, 1, worker, Constants.WorkflowStates.Created);
            #endregion

            #region Case3
            DateTime c3_ca = DateTime.Now.AddDays(-10);
            DateTime c3_da = DateTime.Now.AddDays(-9).AddHours(-12);
            DateTime c3_ua = DateTime.Now.AddDays(-9);

            cases aCase3 = testHelpers.CreateCase("case3UId", cl1, c3_ca, "custom3",
              c3_da, worker, "microtingCheck3UId", "microtin3gUId",
               site, 15, "caseType3", unit, c3_ua, 1, worker, Constants.WorkflowStates.Created);
            #endregion

            #region Case4
            DateTime c4_ca = DateTime.Now.AddDays(-8);
            DateTime c4_da = DateTime.Now.AddDays(-7).AddHours(-12);
            DateTime c4_ua = DateTime.Now.AddDays(-7);

            cases aCase4 = testHelpers.CreateCase("case4UId", cl1, c4_ca, "custom4",
                c4_da, worker, "microtingCheck4UId", "microting4UId",
               site, 100, "caseType4", unit, c4_ua, 1, worker, Constants.WorkflowStates.Created);
            #endregion
            #endregion

            #region cases removed

            #region Case1Removed

            DateTime c1Removed_ca = DateTime.Now.AddDays(-9);
            DateTime c1Removed_da = DateTime.Now.AddDays(-8).AddHours(-12);
            DateTime c1Removed_ua = DateTime.Now.AddDays(-8);

            cases aCase1Removed = testHelpers.CreateCase("case1UId", cl1, c1Removed_ca, "custom1",
                c1Removed_da, worker, "microtingCheckUId1", "microtingUId1",
               site, 1, "caseType1", unit, c1Removed_ua, 1, worker, Constants.WorkflowStates.Removed);

            #endregion

            #region Case2Removed

            DateTime c2Removed_ca = DateTime.Now.AddDays(-7);
            DateTime c2Removed_da = DateTime.Now.AddDays(-6).AddHours(-12);
            DateTime c2Removed_ua = DateTime.Now.AddDays(-6);
            cases aCase2Removed = testHelpers.CreateCase("case2UId", cl1, c2Removed_ca, "custom2",
             c2Removed_da, worker, "microtingCheck2UId", "microting2UId",
               site, 10, "caseType2", unit, c2Removed_ua, 1, worker, Constants.WorkflowStates.Removed);
            #endregion

            #region Case3Removed
            DateTime c3Removed_ca = DateTime.Now.AddDays(-10);
            DateTime c3Removed_da = DateTime.Now.AddDays(-9).AddHours(-12);
            DateTime c3Removed_ua = DateTime.Now.AddDays(-9);

            cases aCase3Removed = testHelpers.CreateCase("case3UId", cl1, c3Removed_ca, "custom3",
              c3Removed_da, worker, "microtingCheck3UId", "microtin3gUId",
               site, 15, "caseType3", unit, c3Removed_ua, 1, worker, Constants.WorkflowStates.Removed);
            #endregion

            #region Case4Removed
            DateTime c4Removed_ca = DateTime.Now.AddDays(-8);
            DateTime c4Removed_da = DateTime.Now.AddDays(-7).AddHours(-12);
            DateTime c4Removed_ua = DateTime.Now.AddDays(-7);

            cases aCase4Removed = testHelpers.CreateCase("case4UId", cl1, c4Removed_ca, "custom4",
                c4Removed_da, worker, "microtingCheck4UId", "microting4UId",
               site, 100, "caseType4", unit, c4Removed_ua, 1, worker, Constants.WorkflowStates.Removed);
            #endregion

            #endregion

            #region cases Retracted

            #region Case1Retracted

            DateTime c1Retracted_ca = DateTime.Now.AddDays(-9);
            DateTime c1Retracted_da = DateTime.Now.AddDays(-8).AddHours(-12);
            DateTime c1Retracted_ua = DateTime.Now.AddDays(-8);

            cases aCase1Retracted = testHelpers.CreateCase("case1UId", cl1, c1Retracted_ca, "custom1",
                c1Retracted_da, worker, "microtingCheckUId1", "microtingUId1",
               site, 1, "caseType1", unit, c1Retracted_ua, 1, worker, Constants.WorkflowStates.Retracted);

            #endregion

            #region Case2Retracted

            DateTime c2Retracted_ca = DateTime.Now.AddDays(-7);
            DateTime c2Retracted_da = DateTime.Now.AddDays(-6).AddHours(-12);
            DateTime c2Retracted_ua = DateTime.Now.AddDays(-6);

            cases aCase2Retracted = testHelpers.CreateCase("case2UId", cl1, c2Retracted_ca, "custom2",
             c2Retracted_da, worker, "microtingCheck2UId", "microting2UId",
               site, 10, "caseType2", unit, c2Retracted_ua, 1, worker, Constants.WorkflowStates.Retracted);
            #endregion

            #region Case3Retracted
            DateTime c3Retracted_ca = DateTime.Now.AddDays(-10);
            DateTime c3Retracted_da = DateTime.Now.AddDays(-9).AddHours(-12);
            DateTime c3Retracted_ua = DateTime.Now.AddDays(-9);

            cases aCase3Retracted = testHelpers.CreateCase("case3UId", cl1, c3Retracted_ca, "custom3",
              c3Retracted_da, worker, "microtingCheck3UId", "microtin3gUId",
               site, 15, "caseType3", unit, c3Retracted_ua, 1, worker, Constants.WorkflowStates.Retracted);
            #endregion

            #region Case4Retracted
            DateTime c4Retracted_ca = DateTime.Now.AddDays(-8);
            DateTime c4Retracted_da = DateTime.Now.AddDays(-7).AddHours(-12);
            DateTime c4Retracted_ua = DateTime.Now.AddDays(-7);

            cases aCase4Retracted = testHelpers.CreateCase("case4UId", cl1, c4Retracted_ca, "custom4",
                c4Retracted_da, worker, "microtingCheck4UId", "microting4UId",
               site, 100, "caseType4", unit, c4Retracted_ua, 1, worker, Constants.WorkflowStates.Retracted);
            #endregion

            #endregion 


            #endregion

            #endregion
            // Act
            #region sorting by WorkflowState created

            #region Default sorting

            #region Default sorting ascending
            // Default sorting ascending
            //List<Case> caseListCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.Status);
            List<Case> caseListUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region Default sorting descending
            //Default sorting descending
            //List<Case> caseListDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.Status);
            List<Case> caseListDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region Default sorting ascending, with DateTime
            // Default sorting ascending, with DateTime
            //List<Case> caseListDtCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseDtListFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseDtListFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseDtListFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseDtListFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseDtListFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseDtListFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseDtListFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseDtListFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseDtListFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseDtListFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseDtListSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.Status);
            List<Case> caseListDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region Default sorting descending, with DateTime
            //Default sorting descending, with DateTime
            //List<Case> caseListDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.Status);
            List<Case> caseListDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion

            #region case sorting

            #region aCase sorting ascending
            #region aCase1 sorting ascendng
            //List<Case> caseListC1SortCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC1SortDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC1SortFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC1SortFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC1SortFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC1SortFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC1SortFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC1SortFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC1SortFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC1SortFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC1SortFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC1SortFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC1SortSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC1SortStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListC1SortUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC1SortWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase2 sorting ascendng
            //List<Case> caseListC2SortCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC2SortDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC2SortFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC2SortFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC2SortFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC2SortFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC2SortFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC2SortFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC2SortFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC2SortFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC2SortFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC2SortFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC2SortSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC2SortStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListC2SortUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC2SortWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase3 sorting ascendng
            //List<Case> caseListC3SortCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC3SortDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC3SortFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC3SortFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC3SortFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC3SortFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC3SortFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC3SortFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC3SortFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC3SortFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC3SortFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC3SortFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC3SortSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC3SortStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListC3SortUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC3SortWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase4 sorting ascendng
            //List<Case> caseListC4SortCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC4SortDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC4SortFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC4SortFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC4SortFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC4SortFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC4SortFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC4SortFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC4SortFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC4SortFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC4SortFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC4SortFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC4SortSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC4SortStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListC4SortUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC4SortWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion

            #region aCase sorting Descending
            #region aCase1 sorting Descending
            //List<Case> caseListC1SortDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC1SortDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC1SortDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC1SortDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC1SortDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC1SortDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC1SortDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC1SortDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC1SortDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC1SortDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC1SortDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC1SortDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC1SortDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC1SortDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListC1SortDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC1SortDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase2 sorting Descending
            //List<Case> caseListC2SortDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC2SortDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC2SortDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC2SortDescendingDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC2SortDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC2SortDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC2SortDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC2SortDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC2SortDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC2SortDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC2SortDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC2SortDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC2SortDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC2SortDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListC2SortDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC2SortDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase3 sorting Descending
            //List<Case> caseListC3SortDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC3SortDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC3SortDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC3SortDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC3SortDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC3SortDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC3SortDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC3SortDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC3SortDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC3SortDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC3SortDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC3SortDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC3SortDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC3SortDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListC3SortDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC3SortDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase4 sorting Descending
            //List<Case> caseListC4SortDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC4SortDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC4SortDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC4SortDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC4SortDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC4SortDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC4SortDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC4SortDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC4SortDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC4SortDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC4SortDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC4SortDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC4SortDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC4SortDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "0004", true, Constants.CaseSortParameters.Status);
            List<Case> caseListC4SortDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC4SortDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion

            #region aCase sorting ascending w. Dt
            #region aCase1 sorting ascendng w. Dt
            //List<Case> caseListC1SortDtCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC1SortDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC1SortDtFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC1SortDtFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC1SortDtFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC1SortDtFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC1SortDtFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC1SortDtFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC1SortDtFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC1SortDtFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC1SortDtFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC1SortDtFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC1SortDtSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC1SortDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListC1SortDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC1SortDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase2 sorting ascendng w. Dt
            //List<Case> caseListC2SortDtCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC2SortDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC2SortDtFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC2SortDtFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC2SortDtFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC2SortDtFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC2SortDtFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC2SortDtFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC2SortDtFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC2SortDtFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC2SortDtFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC2SortDtFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC2SortDtSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC2SortDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListC2SortDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC2SortDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase3 sorting ascendng w. Dt
            //List<Case> caseListC3SortDtCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC3SortDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC3SortDtFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC3SortDtFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC3SortDtFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC3SortDtFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC3SortDtFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC3SortDtFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC3SortDtFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC3SortDtFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC3SortDtFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC3SortDtFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC3SortDtSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC3SortDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListC3SortDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC3SortDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase4 sorting ascendng w. Dt
            //List<Case> caseListC4SortDtCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC4SortDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC4SortDtFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC4SortDtFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC4SortDtFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC4SortDtFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC4SortDtFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC4SortDtFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC4SortDtFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC4SortDtFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC4SortDtFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC4SortDtFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC4SortDtSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC4SortDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListC4SortDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC4SortDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion

            #region aCase sorting Descending w. Dt
            #region aCase1 sorting Descending w. Dt
            //List<Case> caseListC1SortDtDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC1SortDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC1SortDtDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC1SortDtDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC1SortDtDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC1SortDtDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC1SortDtDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC1SortDtDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC1SortDtDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC1SortDtDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC1SortDtDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC1SortDtDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC1SortvDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC1SortDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListC1SortDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC1SortDtDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "1", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase2 sorting Descending w. Dt
            //List<Case> caseListC2SortDtDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC2SortDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC2SortDtDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC2SortDtDescendingDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC2SortDtDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC2SortDtDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC2SortDtDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC2SortDtDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC2SortDtDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC2SortDtDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC2SortDtDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC2SortDtDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC2SortDtDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC2SortDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListC2SortDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC2SortDtDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Created, "2", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase3 sorting Descending w. Dt
            //List<Case> caseListC3SortDtDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC3SortDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC3SortDtDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC3SortDtDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC3SortDtDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC3SortDtDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC3SortDtDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC3SortDtDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC3SortDtDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC3SortDtDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC3SortDtDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC3SortDtDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC3SortDtDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC3SortDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListC3SortDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC3SortDtDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "3", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase4 sorting Descending w. Dt
            //List<Case> caseListC4SortDtDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListC4SortDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListC4SortDtDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC4SortDtDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListC4SortDtDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListC4SortDtDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListC4SortDtDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListC4SortDtDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListC4SortDtDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListC4SortDtDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListC4SortDtDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListC4SortDtDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC4SortDtDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListC4SortDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListC4SortDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListC4SortDtDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Created, "4", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion

            #endregion
            #endregion

            #region sorting by WorkflowState removed

            #region Default sorting

            #region Default sorting ascending
            // Default sorting ascending
            //List<Case> caseListRemovedCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseLisrtRemovedFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseLisrtRemovedFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseLisrtRemovedFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseLisrtRemovedFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseLisrtRemovedFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseLisrtRemovedFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseLisrtRemovedFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseLisrtRemovedFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseLisrtRemovedFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseLisrtRemovedFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region Default sorting descending
            //Default sorting descending
            //List<Case> caseListRemovedDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region Default sorting ascending, with DateTime
            // Default sorting ascending, with DateTime
            //List<Case> caseListRemovedDtCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseDtListRemovedFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseDtListRemovedFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseDtListRemovedFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseDtListRemovedFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseDtListRemovedFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseDtListRemovedFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseDtListRemovedFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseDtListRemovedFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseDtListRemovedFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseDtListRemovedFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseDtListRemovedSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region Default sorting descending, with DateTime
            //Default sorting descending, with DateTime
            //List<Case> caseListRemovedDtDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedDtDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedDtDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedDtDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedDtDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedDtDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedDtDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedDtDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedDtDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedDtDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedDtDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedDtDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedDtDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion

            #region case sorting

            #region aCase sorting ascending
            #region aCase1 sorting ascendng
            //List<Case> caseListRemovedC1SortCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC1SortDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC1SortFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedC1SortFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC1SortFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC1SortFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC1SortFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC1SortFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC1SortFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC1SortFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC1SortFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC1SortFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedC1SortSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC1SortStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC1SortUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC1SortWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase2 sorting ascendng
            //List<Case> caseListRemovedC2SortCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC2SortDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC2SortFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedC2SortFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC2SortFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC2SortFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC2SortFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC2SortFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC2SortFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC2SortFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC2SortFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC2SortFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedC2SortSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC2SortStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC2SortUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC2SortWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase3 sorting ascendng
            //List<Case> caseListRemovedC3SortCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC3SortDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC3SortFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedC3SortFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC3SortFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC3SortFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC3SortFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC3SortFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC3SortFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC3SortFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC3SortFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC3SortFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedC3SortSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC3SortStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC3SortUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC3SortWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase4 sorting ascendng
            //List<Case> caseListRemovedC4SortCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC4SortDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC4SortFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedC4SortFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC4SortFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC4SortFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC4SortFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC4SortFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC4SortFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC4SortFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC4SortFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC4SortFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC4SortSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC4SortStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC4SortUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC4SortWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion

            #region aCase sorting Descending
            #region aCase1 sorting Descending
            //List<Case> caseListRemovedC1SortDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC1SortDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC1SortDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedC1SortDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC1SortDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC1SortDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC1SortDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC1SortDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC1SortDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC1SortDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC1SortDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC1SortDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedC1SortDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC1SortDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC1SortDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC1SortDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase2 sorting Descending
            //List<Case> caseListRemovedC2SortDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC2SortDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC2SortDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC2SortDescendingDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC2SortDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC2SortDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC2SortDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC2SortDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC2SortDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC2SortDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC2SortDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC2SortDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedC2SortDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC2SortDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC2SortDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC2SortDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase3 sorting Descending
            //List<Case> caseListRemovedC3SortDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC3SortDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC3SortDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedC3SortDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC3SortDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC3SortDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC3SortDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC3SortDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC3SortDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC3SortDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC3SortDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC3SortDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC3SortDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC3SortDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC3SortDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC3SortDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase4 sorting Descending
            //List<Case> caseListRemovedC4SortDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC4SortDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC4SortDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedC4SortDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC4SortDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC4SortDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC4SortDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC4SortDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC4SortDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC4SortDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC4SortDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC4SortDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC4SortDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC4SortDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC4SortDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC4SortDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion

            #region aCase sorting ascending w. Dt
            #region aCase1 sorting ascendng w. Dt
            //List<Case> caseListRemovedC1SortDtCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC1SortDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC1SortDtFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedC1SortDtFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC1SortDtFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC1SortDtFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC1SortDtFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC1SortDtFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC1SortDtFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC1SortDtFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC1SortDtFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC1SortDtFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedC1SortDtSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC1SortDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC1SortDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC1SortDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase2 sorting ascendng w. Dt
            //List<Case> caseListRemovedC2SortDtCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC2SortDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC2SortDtFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedC2SortDtFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC2SortDtFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC2SortDtFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC2SortDtFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC2SortDtFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC2SortDtFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC2SortDtFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC2SortDtFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC2SortDtFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedC2SortDtSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC2SortDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC2SortDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC2SortDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase3 sorting ascendng w. Dt
            //List<Case> caseListRemovedC3SortDtCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC3SortDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC3SortDtFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedC3SortDtFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC3SortDtFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC3SortDtFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC3SortDtFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC3SortDtFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC3SortDtFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC3SortDtFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC3SortDtFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC3SortDtFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedC3SortDtSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC3SortDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC3SortDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC3SortDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase4 sorting ascendng w. Dt
            //List<Case> caseListRemovedC4SortDtCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC4SortDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC4SortDtFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedC4SortDtFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC4SortDtFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC4SortDtFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC4SortDtFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC4SortDtFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC4SortDtFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC4SortDtFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC4SortDtFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC4SortDtFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedC4SortDtSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC4SortDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC4SortDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC4SortDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion

            #region aCase sorting Descending w. Dt
            #region aCase1 sorting Descending w. Dt
            //List<Case> caseListRemovedC1SortDtDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC1SortDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC1SortDtDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedC1SortDtDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC1SortDtDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC1SortDtDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC1SortDtDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC1SortDtDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC1SortDtDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC1SortDtDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC1SortDtDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC1SortDtDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedC1SortvDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC1SortDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC1SortDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC1SortDtDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "1", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase2 sorting Descending w. Dt
            //List<Case> caseListRemovedC2SortDtDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC2SortDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC2SortDtDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC2SortDtDescendingDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC2SortDtDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC2SortDtDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC2SortDtDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC2SortDtDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC2SortDtDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC2SortDtDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC2SortDtDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC2SortDtDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedC2SortDtDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC2SortDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC2SortDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC2SortDtDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Removed, "2", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase3 sorting Descending w. Dt
            //List<Case> caseListRemovedC3SortDtDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC3SortDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC3SortDtDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedC3SortDtDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC3SortDtDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC3SortDtDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC3SortDtDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC3SortDtDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC3SortDtDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC3SortDtDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC3SortDtDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC3SortDtDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC3SortDtDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC3SortDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC3SortDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC3SortDtDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "3", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase4 sorting Descending w. Dt
            //List<Case> caseListRemovedC4SortDtDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRemovedC4SortDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRemovedC4SortDtDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRemovedC4SortDtDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRemovedC4SortDtDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRemovedC4SortDtDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRemovedC4SortDtDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRemovedC4SortDtDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRemovedC4SortDtDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRemovedC4SortDtDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRemovedC4SortDtDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRemovedC4SortDtDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRemovedC4SortDtDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRemovedC4SortDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRemovedC4SortDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRemovedC4SortDtDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Removed, "4", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion

            #endregion

            #endregion

            #region sorting by WorkflowState Retracted

            #region Default sorting
            #region Default sorting ascending
            // Default sorting ascending
            //List<Case> caseListRetractedCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseLisrtRetractedFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseLisrtRetractedFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseLisrtRetractedFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseLisrtRetractedFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseLisrtRetractedFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseLisrtRetractedFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseLisrtRetractedFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseLisrtRetractedFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseLisrtRetractedFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseLisrtRetractedFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRetractedSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRetractedWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region Default sorting descending
            //Default sorting descending
            //List<Case> caseListRetractedDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRetractedDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRetractedDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRetractedDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRetractedDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRetractedDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRetractedDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRetractedDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRetractedDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRetractedDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRetractedDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRetractedDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRetractedDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.WorkerName);
            #endregion


            #region Default sorting ascending, with DateTime
            // Default sorting ascending, with DateTime
            //List<Case> caseDtListRetractedDtCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseDtListRetractedFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseDtListRetractedFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseDtListRetractedFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseDtListRetractedFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseDtListRetractedFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseDtListRetractedFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseDtListRetractedFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseDtListRetractedFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseDtListRetractedFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseDtListRetractedFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseDtListRemovedSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseDtListRetractedDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region Default sorting descending, with DateTime
            //Default sorting descending, with DateTime
            //List<Case> caseDtListRetractedDtDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseDtListRetractedDtDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseDtListRetractedDtDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseDtListRetractedDtDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseDtListRetractedDtDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseDtListRetractedDtDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseDtListRetractedDtDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseDtListRetractedDtDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseDtListRetractedDtDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseDtListRetractedDtDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseDtListRetractedDtDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseDtListRetractedDtDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseDtListRetractedDtDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion

            #region case sorting

            #region aCase sorting ascending
            #region aCase1 sorting ascendng
            //List<Case> caseListRetractedC1SortCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC1SortDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "10000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRetractedC1SortFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRetractedC1SortFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRetractedC1SortFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRetractedC1SortFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRetractedC1SortFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRetractedC1SortFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRetractedC1SortFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRetractedC1SortFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRetractedC1SortFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRetractedC1SortFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRetractedC1SortSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC1SortStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC1SortUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRetractedC1SortWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase2 sorting ascendng
            //List<Case> caseListRetractedC2SortCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC2SortDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRetractedC2SortFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRetractedC2SortFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRetractedC2SortFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRetractedC2SortFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRetractedC2SortFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRetractedC2SortFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRetractedC2SortFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRetractedC2SortFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRetractedC2SortFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRetractedC2SortFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRetractedC2SortSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC2SortStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC2SortUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRetractedC2SortWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase3 sorting ascendng
            //List<Case> caseListRetractedC3SortCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC3SortDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRetractedC3SortFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRetractedC3SortFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRetractedC3SortFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRetractedC3SortFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRetractedC3SortFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRetractedC3SortFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRetractedC3SortFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRetractedC3SortFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRetractedC3SortFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRetractedC3SortFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRetractedC3SortSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC3SortStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC3SortUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRetractedC3SortWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase4 sorting ascendng
            //List<Case> caseListRetractedC4SortCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC4SortDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRetractedC4SortFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRetractedC4SortFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRetractedC4SortFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRetractedC4SortFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRetractedC4SortFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRetractedC4SortFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRetractedC4SortFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRetractedC4SortFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRetractedC4SortFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRetractedC4SortFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC4SortSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC4SortStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC4SortUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRetractedC4SortWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion

            #region aCase sorting Descending
            #region aCase1 sorting Descending
            //List<Case> caseListRetractedC1SortDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC1SortDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRetractedC1SortDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRetractedC1SortDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRetractedC1SortDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRetractedC1SortDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRetractedC1SortDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRetractedC1SortDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRetractedC1SortDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRetractedC1SortDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRetractedC1SortDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRetractedC1SortDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRetractedC1SortDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC1SortDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC1SortDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRetractedC1SortDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase2 sorting Descending
            //List<Case> caseListRetractedC2SortDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC2SortDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRetractedC2SortDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC2SortDescendingDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRetractedC2SortDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRetractedC2SortDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRetractedC2SortDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRetractedC2SortDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRetractedC2SortDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRetractedC2SortDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRetractedC2SortDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRetractedC2SortDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListRetractedC2SortDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC2SortDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC2SortDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRetractedC2SortDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase3 sorting Descending
            //List<Case> caseListRetractedC3SortDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC3SortDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRetractedC3SortDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRetractedC3SortDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRetractedC3SortDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRetractedC3SortDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRetractedC3SortDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRetractedC3SortDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRetractedC3SortDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRetractedC3SortDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRetractedC3SortDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRetractedC3SortDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC3SortDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC3SortDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC3SortDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRetractedC3SortDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase4 sorting Descending
            //List<Case> caseListRetractedC4SortDescendingCreatedAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC4SortDescendingDoneAt = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseListRetractedC4SortDescendingFieldValue1 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListRetractedC4SortDescendingFieldValue2 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseListRetractedC4SortDescendingFieldValue3 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseListRetractedC4SortDescendingFieldValue4 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseListRetractedC4SortDescendingFieldValue5 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseListRetractedC4SortDescendingFieldValue6 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseListRetractedC4SortDescendingFieldValue7 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseListRetractedC4SortDescendingFieldValue8 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseListRetractedC4SortDescendingFieldValue9 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseListRetractedC4SortDescendingFieldValue10 = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC4SortDescendingSiteName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC4SortDescendingStatus = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC4SortDescendingUnitId = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseListRetractedC4SortDescendingWorkerName = sut.CaseReadAll(cl1.id, null, null, Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion

            #region aCase sorting ascending w. Dt
            #region aCase1 sorting ascendng w. Dt
            //List<Case> caseDtListRetractedC1SortDtCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC1SortDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseDtListRetractedC1SortDtFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseDtListRetractedC1SortDtFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseDtListRetractedC1SortDtFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseDtListRetractedC1SortDtFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseDtListRetractedC1SortDtFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseDtListRetractedC1SortDtFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseDtListRetractedC1SortDtFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseDtListRetractedC1SortDtFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseDtListRetractedC1SortDtFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseDtListRetractedC1SortDtFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseDtListRetractedC1SortDtSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC1SortDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC1SortDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseDtListRetractedC1SortDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase2 sorting ascendng w. Dt
            //List<Case> caseDtListRetractedC2SortDtCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC2SortDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseDtListRetractedC2SortDtFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseDtListRetractedC2SortDtFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseDtListRetractedC2SortDtFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseDtListRetractedC2SortDtFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseDtListRetractedC2SortDtFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseDtListRetractedC2SortDtFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseDtListRetractedC2SortDtFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseDtListRetractedC2SortDtFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseDtListRetractedC2SortDtFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseDtListRetractedC2SortDtFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseDtListRetractedC2SortDtSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC2SortDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC2SortDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseDtListRetractedC2SortDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase3 sorting ascendng w. Dt
            //List<Case> caseDtListRetractedC3SortDtCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC3SortDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseDtListRetractedC3SortDtFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseDtListRetractedC3SortDtFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseDtListRetractedC3SortDtFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseDtListRetractedC3SortDtFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseDtListRetractedC3SortDtFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseDtListRetractedC3SortDtFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseDtListRetractedC3SortDtFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseDtListRetractedC3SortDtFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseDtListRetractedC3SortDtFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseDtListRetractedC3SortDtFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseDtListRetractedC3SortDtSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC3SortDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC3SortDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseDtListRetractedC3SortDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase4 sorting ascendng w. Dt
            //List<Case> caseDtListRetractedC4SortDtCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC4SortDtDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4000", false, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseDtListRetractedC4SortDtFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseDtListRetractedC4SortDtFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseDtListRetractedC4SortDtFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseDtListRetractedC4SortDtFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseDtListRetractedC4SortDtFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseDtListRetractedC4SortDtFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseDtListRetractedC4SortDtFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseDtListRetractedC4SortDtFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseDtListRetractedC4SortDtFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseDtListRetractedC4SortDtFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseDtListRetractedC4SortDtSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC4SortDtStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4000", false, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC4SortDtUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4000", false, Constants.CaseSortParameters.UnitId);
            //List<Case> caseDtListRetractedC4SortDtWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", false, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion

            #region aCase sorting Descending w. Dt
            #region aCase1 sorting Descending w. Dt
            //List<Case> caseDtListRetractedC1SortDtDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC1SortDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseDtListRetractedC1SortDtDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseDtListRetractedC1SortDtDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseDtListRetractedC1SortDtDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseDtListRetractedC1SortDtDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseDtListRetractedC1SortDtDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseDtListRetractedC1SortDtDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseDtListRetractedC1SortDtDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseDtListRetractedC1SortDtDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseDtListRetractedC1SortDtDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseDtListRetractedC1SortDtDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseDtListRetractedC1SortvDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC1SortDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC1SortDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseDtListRetractedC1SortDtDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "1", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase2 sorting Descending w. Dt
            //List<Case> caseDtListRetractedC2SortDtDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC2SortDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseDtListRetractedC2SortDtDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseListC2SortDtDescendingDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseDtListRetractedC2SortDtDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseDtListRetractedC2SortDtDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseDtListRetractedC2SortDtDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseDtListRetractedC2SortDtDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseDtListRetractedC2SortDtDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseDtListRetractedC2SortDtDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseDtListRetractedC2SortDtDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseDtListRetractedC2SortDtDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseDtListRetractedC2SortDtDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC2SortDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC2SortDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseDtListRetractedC2SortDtDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), Constants.WorkflowStates.Retracted, "2", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase3 sorting Descending w. Dt
            //List<Case> caseDtListRetractedC3SortDtDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC3SortDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseDtListRetractedC3SortDtDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseDtListRetractedC3SortDtDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseDtListRetractedC3SortDtDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseDtListRetractedC3SortDtDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseDtListRetractedC3SortDtDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseDtListRetractedC3SortDtDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseDtListRetractedC3SortDtDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseDtListRetractedC3SortDtDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseDtListRetractedC3SortDtDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseDtListRetractedC3SortDtDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseListC3SortDtDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC3SortDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC3SortDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseDtListRetractedC3SortDtDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "3", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #region aCase4 sorting Descending w. Dt
            //List<Case> caseDtListRetractedC4SortDtDescendingCreatedAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.CreatedAt);
            List<Case> caseListRetractedC4SortDtDescendingDoneAt = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4000", true, Constants.CaseSortParameters.DoneAt);
            //List<Case> caseDtListRetractedC4SortDtDescendingFieldValue1 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue1);
            //List<Case> caseDtListRetractedC4SortDtDescendingFieldValue2 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue2);
            //List<Case> caseDtListRetractedC4SortDtDescendingFieldValue3 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue3);
            //List<Case> caseDtListRetractedC4SortDtDescendingFieldValue4 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue4);
            //List<Case> caseDtListRetractedC4SortDtDescendingFieldValue5 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue5);
            //List<Case> caseDtListRetractedC4SortDtDescendingFieldValue6 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue6);
            //List<Case> caseDtListRetractedC4SortDtDescendingFieldValue7 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue7);
            //List<Case> caseDtListRetractedC4SortDtDescendingFieldValue8 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue8);
            //List<Case> caseDtListRetractedC4SortDtDescendingFieldValue9 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue9);
            //List<Case> caseDtListRetractedC4SortDtDescendingFieldValue10 = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.FieldValue10);
            //List<Case> caseDtListRetractedC4SortDtDescendingSiteName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.SiteName);
            List<Case> caseListRetractedC4SortDtDescendingStatus = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4000", true, Constants.CaseSortParameters.Status);
            List<Case> caseListRetractedC4SortDtDescendingUnitId = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4000", true, Constants.CaseSortParameters.UnitId);
            //List<Case> caseDtListRetractedC4SortDtDescendingWorkerName = sut.CaseReadAll(cl1.id, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-6), Constants.WorkflowStates.Retracted, "4", true, Constants.CaseSortParameters.WorkerName);
            #endregion

            #endregion


            #endregion
            #endregion

            // Assert
            #region sort by WorkflowState Created
            #region Def Sort
            #region Def Sort Asc
            #region caseListDoneAt Def Sort Asc
            #region caseListDoneAt aCase1
            Assert.NotNull(caseListDoneAt);
            Assert.AreEqual(4, caseListDoneAt.Count);
            Assert.AreEqual(aCase1.type, caseListDoneAt[1].CaseType);
            Assert.AreEqual(aCase1.case_uid, caseListDoneAt[1].CaseUId);
            Assert.AreEqual(aCase1.microting_check_uid, caseListDoneAt[1].CheckUIid);
            Assert.AreEqual(c1_ca.ToString(), caseListDoneAt[1].CreatedAt.ToString());
            Assert.AreEqual(aCase1.custom, caseListDoneAt[1].Custom);
            Assert.AreEqual(c1_da.ToString(), caseListDoneAt[1].DoneAt.ToString());
            Assert.AreEqual(aCase1.id, caseListDoneAt[1].Id);
            Assert.AreEqual(aCase1.microting_uid, caseListDoneAt[1].MicrotingUId);
            Assert.AreEqual(aCase1.site.microting_uid, caseListDoneAt[1].SiteId);
            Assert.AreEqual(aCase1.site.name, caseListDoneAt[1].SiteName);
            Assert.AreEqual(aCase1.status, caseListDoneAt[1].Status);
            Assert.AreEqual(cl1.id, caseListDoneAt[1].TemplatId);
            Assert.AreEqual(aCase1.unit.microting_uid, caseListDoneAt[1].UnitId);
            Assert.AreEqual(c1_ua.ToString(), caseListDoneAt[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase1.version, caseListDoneAt[1].Version);
            Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListDoneAt[1].WorkerName);
            Assert.AreEqual(aCase1.workflow_state, caseListDoneAt[1].WorkflowState);
            #endregion

            #region caseListDoneAt aCase2
            Assert.AreEqual(aCase2.type, caseListDoneAt[3].CaseType);
            Assert.AreEqual(aCase2.case_uid, caseListDoneAt[3].CaseUId);
            Assert.AreEqual(aCase2.microting_check_uid, caseListDoneAt[3].CheckUIid);
            Assert.AreEqual(c2_ca.ToString(), caseListDoneAt[3].CreatedAt.ToString());
            Assert.AreEqual(aCase2.custom, caseListDoneAt[3].Custom);
            Assert.AreEqual(c2_da.ToString(), caseListDoneAt[3].DoneAt.ToString());
            Assert.AreEqual(aCase2.id, caseListDoneAt[3].Id);
            Assert.AreEqual(aCase2.microting_uid, caseListDoneAt[3].MicrotingUId);
            Assert.AreEqual(aCase2.site.microting_uid, caseListDoneAt[3].SiteId);
            Assert.AreEqual(aCase2.site.name, caseListDoneAt[3].SiteName);
            Assert.AreEqual(aCase2.status, caseListDoneAt[3].Status);
            Assert.AreEqual(cl1.id, caseListDoneAt[3].TemplatId);
            Assert.AreEqual(aCase2.unit.microting_uid, caseListDoneAt[3].UnitId);
            Assert.AreEqual(c2_ua.ToString(), caseListDoneAt[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase2.version, caseListDoneAt[3].Version);
            Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListDoneAt[3].WorkerName);
            Assert.AreEqual(aCase2.workflow_state, caseListDoneAt[3].WorkflowState);
            #endregion

            #region caseListDoneAt aCase3
            Assert.AreEqual(aCase3.type, caseListDoneAt[0].CaseType);
            Assert.AreEqual(aCase3.case_uid, caseListDoneAt[0].CaseUId);
            Assert.AreEqual(aCase3.microting_check_uid, caseListDoneAt[0].CheckUIid);
            Assert.AreEqual(c3_ca.ToString(), caseListDoneAt[0].CreatedAt.ToString());
            Assert.AreEqual(aCase3.custom, caseListDoneAt[0].Custom);
            Assert.AreEqual(c3_da.ToString(), caseListDoneAt[0].DoneAt.ToString());
            Assert.AreEqual(aCase3.id, caseListDoneAt[0].Id);
            Assert.AreEqual(aCase3.microting_uid, caseListDoneAt[0].MicrotingUId);
            Assert.AreEqual(aCase3.site.microting_uid, caseListDoneAt[0].SiteId);
            Assert.AreEqual(aCase3.site.name, caseListDoneAt[0].SiteName);
            Assert.AreEqual(aCase3.status, caseListDoneAt[0].Status);
            Assert.AreEqual(cl1.id, caseListDoneAt[0].TemplatId);
            Assert.AreEqual(aCase3.unit.microting_uid, caseListDoneAt[0].UnitId);
            Assert.AreEqual(c3_ua.ToString(), caseListDoneAt[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase3.version, caseListDoneAt[0].Version);
            Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListDoneAt[0].WorkerName);
            Assert.AreEqual(aCase3.workflow_state, caseListDoneAt[0].WorkflowState);
            #endregion

            #region caseListDoneAt aCase4
            Assert.AreEqual(aCase4.type, caseListDoneAt[2].CaseType);
            Assert.AreEqual(aCase4.case_uid, caseListDoneAt[2].CaseUId);
            Assert.AreEqual(aCase4.microting_check_uid, caseListDoneAt[2].CheckUIid);
            Assert.AreEqual(c4_ca.ToString(), caseListDoneAt[2].CreatedAt.ToString());
            Assert.AreEqual(aCase4.custom, caseListDoneAt[2].Custom);
            Assert.AreEqual(c4_da.ToString(), caseListDoneAt[2].DoneAt.ToString());
            Assert.AreEqual(aCase4.id, caseListDoneAt[2].Id);
            Assert.AreEqual(aCase4.microting_uid, caseListDoneAt[2].MicrotingUId);
            Assert.AreEqual(aCase4.site.microting_uid, caseListDoneAt[2].SiteId);
            Assert.AreEqual(aCase4.site.name, caseListDoneAt[2].SiteName);
            Assert.AreEqual(aCase4.status, caseListDoneAt[2].Status);
            Assert.AreEqual(cl1.id, caseListDoneAt[2].TemplatId);
            Assert.AreEqual(aCase4.unit.microting_uid, caseListDoneAt[2].UnitId);
            Assert.AreEqual(c4_ua.ToString(), caseListDoneAt[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase4.version, caseListDoneAt[2].Version);
            Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListDoneAt[2].WorkerName);
            Assert.AreEqual(aCase4.workflow_state, caseListDoneAt[2].WorkflowState);
            #endregion

            #endregion

            #region caseListStatus Def Sort Asc

            #region caseListStatus aCase1

            Assert.NotNull(caseListStatus);
            Assert.AreEqual(4, caseListStatus.Count);
            Assert.AreEqual(aCase1.type, caseListStatus[0].CaseType);
            Assert.AreEqual(aCase1.case_uid, caseListStatus[0].CaseUId);
            Assert.AreEqual(aCase1.microting_check_uid, caseListStatus[0].CheckUIid);
            Assert.AreEqual(c1_ca.ToString(), caseListStatus[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1.custom, caseListStatus[0].Custom);
            Assert.AreEqual(c1_da.ToString(), caseListStatus[0].DoneAt.ToString());
            Assert.AreEqual(aCase1.id, caseListStatus[0].Id);
            Assert.AreEqual(aCase1.microting_uid, caseListStatus[0].MicrotingUId);
            Assert.AreEqual(aCase1.site.microting_uid, caseListStatus[0].SiteId);
            Assert.AreEqual(aCase1.site.name, caseListStatus[0].SiteName);
            Assert.AreEqual(aCase1.status, caseListStatus[0].Status);
            Assert.AreEqual(aCase1.check_list_id, caseListStatus[0].TemplatId);
            Assert.AreEqual(aCase1.unit.microting_uid, caseListStatus[0].UnitId);
            Assert.AreEqual(c1_ua.ToString(), caseListStatus[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1.version, caseListStatus[0].Version);
            Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListStatus[0].WorkerName);
            Assert.AreEqual(aCase1.workflow_state, caseListStatus[0].WorkflowState);

            #endregion

            #region caseListStatus aCase2

            Assert.AreEqual(aCase2.type, caseListStatus[1].CaseType);
            Assert.AreEqual(aCase2.case_uid, caseListStatus[1].CaseUId);
            Assert.AreEqual(aCase2.microting_check_uid, caseListStatus[1].CheckUIid);
            Assert.AreEqual(c2_ca.ToString(), caseListStatus[1].CreatedAt.ToString());
            Assert.AreEqual(aCase2.custom, caseListStatus[1].Custom);
            Assert.AreEqual(c2_da.ToString(), caseListStatus[1].DoneAt.ToString());
            Assert.AreEqual(aCase2.id, caseListStatus[1].Id);
            Assert.AreEqual(aCase2.microting_uid, caseListStatus[1].MicrotingUId);
            Assert.AreEqual(aCase2.site.microting_uid, caseListStatus[1].SiteId);
            Assert.AreEqual(aCase2.site.name, caseListStatus[1].SiteName);
            Assert.AreEqual(aCase2.status, caseListStatus[1].Status);
            Assert.AreEqual(aCase2.check_list_id, caseListStatus[1].TemplatId);
            Assert.AreEqual(aCase2.unit.microting_uid, caseListStatus[1].UnitId);
            Assert.AreEqual(c2_ua.ToString(), caseListStatus[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase2.version, caseListStatus[1].Version);
            Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListStatus[1].WorkerName);
            Assert.AreEqual(aCase2.workflow_state, caseListStatus[1].WorkflowState);

            #endregion

            #region caseListStatus aCase3

            Assert.AreEqual(aCase3.type, caseListStatus[2].CaseType);
            Assert.AreEqual(aCase3.case_uid, caseListStatus[2].CaseUId);
            Assert.AreEqual(aCase3.microting_check_uid, caseListStatus[2].CheckUIid);
            Assert.AreEqual(c3_ca.ToString(), caseListStatus[2].CreatedAt.ToString());
            Assert.AreEqual(aCase3.custom, caseListStatus[2].Custom);
            Assert.AreEqual(c3_da.ToString(), caseListStatus[2].DoneAt.ToString());
            Assert.AreEqual(aCase3.id, caseListStatus[2].Id);
            Assert.AreEqual(aCase3.microting_uid, caseListStatus[2].MicrotingUId);
            Assert.AreEqual(aCase3.site.microting_uid, caseListStatus[2].SiteId);
            Assert.AreEqual(aCase3.site.name, caseListStatus[2].SiteName);
            Assert.AreEqual(aCase3.status, caseListStatus[2].Status);
            Assert.AreEqual(aCase3.check_list_id, caseListStatus[2].TemplatId);
            Assert.AreEqual(aCase3.unit.microting_uid, caseListStatus[2].UnitId);
            Assert.AreEqual(c3_ua.ToString(), caseListStatus[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase3.version, caseListStatus[2].Version);
            Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListStatus[2].WorkerName);
            Assert.AreEqual(aCase3.workflow_state, caseListStatus[2].WorkflowState);

            #endregion

            #region caseListStatus aCase4

            Assert.AreEqual(aCase4.type, caseListStatus[3].CaseType);
            Assert.AreEqual(aCase4.case_uid, caseListStatus[3].CaseUId);
            Assert.AreEqual(aCase4.microting_check_uid, caseListStatus[3].CheckUIid);
            Assert.AreEqual(c4_ca.ToString(), caseListStatus[3].CreatedAt.ToString());
            Assert.AreEqual(aCase4.custom, caseListStatus[3].Custom);
            Assert.AreEqual(c4_da.ToString(), caseListStatus[3].DoneAt.ToString());
            Assert.AreEqual(aCase4.id, caseListStatus[3].Id);
            Assert.AreEqual(aCase4.microting_uid, caseListStatus[3].MicrotingUId);
            Assert.AreEqual(aCase4.site.microting_uid, caseListStatus[3].SiteId);
            Assert.AreEqual(aCase4.site.name, caseListStatus[3].SiteName);
            Assert.AreEqual(aCase4.status, caseListStatus[3].Status);
            Assert.AreEqual(aCase4.check_list_id, caseListStatus[3].TemplatId);
            Assert.AreEqual(aCase4.unit.microting_uid, caseListStatus[3].UnitId);
            Assert.AreEqual(c4_ua.ToString(), caseListStatus[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase4.version, caseListStatus[3].Version);
            Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListStatus[3].WorkerName);
            Assert.AreEqual(aCase4.workflow_state, caseListStatus[3].WorkflowState);

            #endregion

            #endregion

            #region caseListUnitId Def Sort Asc

            #region caseListUnitId aCase1
            Assert.NotNull(caseListUnitId);
            Assert.AreEqual(4, caseListUnitId.Count);
            Assert.AreEqual(aCase1.type, caseListUnitId[0].CaseType);
            Assert.AreEqual(aCase1.case_uid, caseListUnitId[0].CaseUId);
            Assert.AreEqual(aCase1.microting_check_uid, caseListUnitId[0].CheckUIid);
            Assert.AreEqual(c1_ca.ToString(), caseListUnitId[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1.custom, caseListUnitId[0].Custom);
            Assert.AreEqual(c1_da.ToString(), caseListUnitId[0].DoneAt.ToString());
            Assert.AreEqual(aCase1.id, caseListUnitId[0].Id);
            Assert.AreEqual(aCase1.microting_uid, caseListUnitId[0].MicrotingUId);
            Assert.AreEqual(aCase1.site.microting_uid, caseListUnitId[0].SiteId);
            Assert.AreEqual(aCase1.site.name, caseListUnitId[0].SiteName);
            Assert.AreEqual(aCase1.status, caseListUnitId[0].Status);
            Assert.AreEqual(aCase1.check_list_id, caseListUnitId[0].TemplatId);
            Assert.AreEqual(aCase1.unit.microting_uid, caseListUnitId[0].UnitId);
            Assert.AreEqual(c1_ua.ToString(), caseListUnitId[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1.version, caseListUnitId[0].Version);
            Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListUnitId[0].WorkerName);
            Assert.AreEqual(aCase1.workflow_state, caseListUnitId[0].WorkflowState);

            #endregion

            #region caseListUnitId aCase2
            Assert.AreEqual(aCase2.type, caseListUnitId[1].CaseType);
            Assert.AreEqual(aCase2.case_uid, caseListUnitId[1].CaseUId);
            Assert.AreEqual(aCase2.microting_check_uid, caseListUnitId[1].CheckUIid);
            Assert.AreEqual(c2_ca.ToString(), caseListUnitId[1].CreatedAt.ToString());
            Assert.AreEqual(aCase2.custom, caseListUnitId[1].Custom);
            Assert.AreEqual(c2_da.ToString(), caseListUnitId[1].DoneAt.ToString());
            Assert.AreEqual(aCase2.id, caseListUnitId[1].Id);
            Assert.AreEqual(aCase2.microting_uid, caseListUnitId[1].MicrotingUId);
            Assert.AreEqual(aCase2.site.microting_uid, caseListUnitId[1].SiteId);
            Assert.AreEqual(aCase2.site.name, caseListUnitId[1].SiteName);
            Assert.AreEqual(aCase2.status, caseListUnitId[1].Status);
            Assert.AreEqual(aCase2.check_list_id, caseListUnitId[1].TemplatId);
            Assert.AreEqual(aCase2.unit.microting_uid, caseListUnitId[1].UnitId);
            Assert.AreEqual(c2_ua.ToString(), caseListUnitId[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase2.version, caseListUnitId[1].Version);
            Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListUnitId[1].WorkerName);
            Assert.AreEqual(aCase2.workflow_state, caseListUnitId[1].WorkflowState);

            #endregion

            #region caseListUnitId aCase3
            Assert.AreEqual(aCase3.type, caseListUnitId[2].CaseType);
            Assert.AreEqual(aCase3.case_uid, caseListUnitId[2].CaseUId);
            Assert.AreEqual(aCase3.microting_check_uid, caseListUnitId[2].CheckUIid);
            Assert.AreEqual(c3_ca.ToString(), caseListUnitId[2].CreatedAt.ToString());
            Assert.AreEqual(aCase3.custom, caseListUnitId[2].Custom);
            Assert.AreEqual(c3_da.ToString(), caseListUnitId[2].DoneAt.ToString());
            Assert.AreEqual(aCase3.id, caseListUnitId[2].Id);
            Assert.AreEqual(aCase3.microting_uid, caseListUnitId[2].MicrotingUId);
            Assert.AreEqual(aCase3.site.microting_uid, caseListUnitId[2].SiteId);
            Assert.AreEqual(aCase3.site.name, caseListUnitId[2].SiteName);
            Assert.AreEqual(aCase3.status, caseListUnitId[2].Status);
            Assert.AreEqual(aCase3.check_list_id, caseListUnitId[2].TemplatId);
            Assert.AreEqual(aCase3.unit.microting_uid, caseListUnitId[2].UnitId);
            Assert.AreEqual(c3_ua.ToString(), caseListUnitId[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase3.version, caseListUnitId[2].Version);
            Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListUnitId[2].WorkerName);
            Assert.AreEqual(aCase3.workflow_state, caseListUnitId[2].WorkflowState);

            #endregion

            #region caseListUnitId aCase4
            Assert.AreEqual(aCase4.type, caseListUnitId[3].CaseType);
            Assert.AreEqual(aCase4.case_uid, caseListUnitId[3].CaseUId);
            Assert.AreEqual(aCase4.microting_check_uid, caseListUnitId[3].CheckUIid);
            Assert.AreEqual(c4_ca.ToString(), caseListUnitId[3].CreatedAt.ToString());
            Assert.AreEqual(aCase4.custom, caseListUnitId[3].Custom);
            Assert.AreEqual(c4_da.ToString(), caseListUnitId[3].DoneAt.ToString());
            Assert.AreEqual(aCase4.id, caseListUnitId[3].Id);
            Assert.AreEqual(aCase4.microting_uid, caseListUnitId[3].MicrotingUId);
            Assert.AreEqual(aCase4.site.microting_uid, caseListUnitId[3].SiteId);
            Assert.AreEqual(aCase4.site.name, caseListUnitId[3].SiteName);
            Assert.AreEqual(aCase4.status, caseListUnitId[3].Status);
            Assert.AreEqual(aCase4.check_list_id, caseListUnitId[3].TemplatId);
            Assert.AreEqual(aCase4.unit.microting_uid, caseListUnitId[3].UnitId);
            Assert.AreEqual(c4_ua.ToString(), caseListUnitId[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase4.version, caseListUnitId[3].Version);
            Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListUnitId[3].WorkerName);
            Assert.AreEqual(aCase4.workflow_state, caseListUnitId[3].WorkflowState);

            #endregion

            #endregion

            #endregion

            #region Def Sort Des

            #region caseListDescendingDoneAt Def Sort Des
            #region caseListDescendingDoneAt aCase1
            Assert.NotNull(caseListDescendingDoneAt);
            Assert.AreEqual(4, caseListDescendingDoneAt.Count);
            Assert.AreEqual(aCase1.type, caseListDescendingDoneAt[2].CaseType);
            Assert.AreEqual(aCase1.case_uid, caseListDescendingDoneAt[2].CaseUId);
            Assert.AreEqual(aCase1.microting_check_uid, caseListDescendingDoneAt[2].CheckUIid);
            Assert.AreEqual(c1_ca.ToString(), caseListDescendingDoneAt[2].CreatedAt.ToString());
            Assert.AreEqual(aCase1.custom, caseListDescendingDoneAt[2].Custom);
            Assert.AreEqual(c1_da.ToString(), caseListDescendingDoneAt[2].DoneAt.ToString());
            Assert.AreEqual(aCase1.id, caseListDescendingDoneAt[2].Id);
            Assert.AreEqual(aCase1.microting_uid, caseListDescendingDoneAt[2].MicrotingUId);
            Assert.AreEqual(aCase1.site.microting_uid, caseListDescendingDoneAt[2].SiteId);
            Assert.AreEqual(aCase1.site.name, caseListDescendingDoneAt[2].SiteName);
            Assert.AreEqual(aCase1.status, caseListDescendingDoneAt[2].Status);
            Assert.AreEqual(cl1.id, caseListDescendingDoneAt[2].TemplatId);
            Assert.AreEqual(aCase1.unit.microting_uid, caseListDescendingDoneAt[2].UnitId);
            Assert.AreEqual(c1_ua.ToString(), caseListDescendingDoneAt[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase1.version, caseListDescendingDoneAt[2].Version);
            Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListDescendingDoneAt[2].WorkerName);
            Assert.AreEqual(aCase1.workflow_state, caseListDescendingDoneAt[2].WorkflowState);
            #endregion

            #region caseListDescendingDoneAt aCase2
            Assert.AreEqual(aCase2.type, caseListDescendingDoneAt[0].CaseType);
            Assert.AreEqual(aCase2.case_uid, caseListDescendingDoneAt[0].CaseUId);
            Assert.AreEqual(aCase2.microting_check_uid, caseListDescendingDoneAt[0].CheckUIid);
            Assert.AreEqual(c2_ca.ToString(), caseListDescendingDoneAt[0].CreatedAt.ToString());
            Assert.AreEqual(aCase2.custom, caseListDescendingDoneAt[0].Custom);
            Assert.AreEqual(c2_da.ToString(), caseListDescendingDoneAt[0].DoneAt.ToString());
            Assert.AreEqual(aCase2.id, caseListDescendingDoneAt[0].Id);
            Assert.AreEqual(aCase2.microting_uid, caseListDescendingDoneAt[0].MicrotingUId);
            Assert.AreEqual(aCase2.site.microting_uid, caseListDescendingDoneAt[0].SiteId);
            Assert.AreEqual(aCase2.site.name, caseListDescendingDoneAt[0].SiteName);
            Assert.AreEqual(aCase2.status, caseListDescendingDoneAt[0].Status);
            Assert.AreEqual(cl1.id, caseListDescendingDoneAt[0].TemplatId);
            Assert.AreEqual(aCase2.unit.microting_uid, caseListDescendingDoneAt[0].UnitId);
            Assert.AreEqual(c2_ua.ToString(), caseListDescendingDoneAt[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase2.version, caseListDescendingDoneAt[0].Version);
            Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListDescendingDoneAt[0].WorkerName);
            Assert.AreEqual(aCase2.workflow_state, caseListDescendingDoneAt[0].WorkflowState);
            #endregion

            #region caseListDescendingDoneAt aCase3
            Assert.AreEqual(aCase3.type, caseListDescendingDoneAt[3].CaseType);
            Assert.AreEqual(aCase3.case_uid, caseListDescendingDoneAt[3].CaseUId);
            Assert.AreEqual(aCase3.microting_check_uid, caseListDescendingDoneAt[3].CheckUIid);
            Assert.AreEqual(c3_ca.ToString(), caseListDescendingDoneAt[3].CreatedAt.ToString());
            Assert.AreEqual(aCase3.custom, caseListDescendingDoneAt[3].Custom);
            Assert.AreEqual(c3_da.ToString(), caseListDescendingDoneAt[3].DoneAt.ToString());
            Assert.AreEqual(aCase3.id, caseListDescendingDoneAt[3].Id);
            Assert.AreEqual(aCase3.microting_uid, caseListDescendingDoneAt[3].MicrotingUId);
            Assert.AreEqual(aCase3.site.microting_uid, caseListDescendingDoneAt[3].SiteId);
            Assert.AreEqual(aCase3.site.name, caseListDescendingDoneAt[3].SiteName);
            Assert.AreEqual(aCase3.status, caseListDescendingDoneAt[3].Status);
            Assert.AreEqual(cl1.id, caseListDescendingDoneAt[3].TemplatId);
            Assert.AreEqual(aCase3.unit.microting_uid, caseListDescendingDoneAt[3].UnitId);
            Assert.AreEqual(c3_ua.ToString(), caseListDescendingDoneAt[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase3.version, caseListDescendingDoneAt[3].Version);
            Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListDescendingDoneAt[3].WorkerName);
            Assert.AreEqual(aCase3.workflow_state, caseListDescendingDoneAt[3].WorkflowState);
            #endregion

            #region caseListDescendingDoneAt aCase4
            Assert.AreEqual(aCase4.type, caseListDescendingDoneAt[1].CaseType);
            Assert.AreEqual(aCase4.case_uid, caseListDescendingDoneAt[1].CaseUId);
            Assert.AreEqual(aCase4.microting_check_uid, caseListDescendingDoneAt[1].CheckUIid);
            Assert.AreEqual(c4_ca.ToString(), caseListDescendingDoneAt[1].CreatedAt.ToString());
            Assert.AreEqual(aCase4.custom, caseListDescendingDoneAt[1].Custom);
            Assert.AreEqual(c4_da.ToString(), caseListDescendingDoneAt[1].DoneAt.ToString());
            Assert.AreEqual(aCase4.id, caseListDescendingDoneAt[1].Id);
            Assert.AreEqual(aCase4.microting_uid, caseListDescendingDoneAt[1].MicrotingUId);
            Assert.AreEqual(aCase4.site.microting_uid, caseListDescendingDoneAt[1].SiteId);
            Assert.AreEqual(aCase4.site.name, caseListDescendingDoneAt[1].SiteName);
            Assert.AreEqual(aCase4.status, caseListDescendingDoneAt[1].Status);
            Assert.AreEqual(cl1.id, caseListDescendingDoneAt[1].TemplatId);
            Assert.AreEqual(aCase4.unit.microting_uid, caseListDescendingDoneAt[1].UnitId);
            Assert.AreEqual(c4_ua.ToString(), caseListDescendingDoneAt[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase4.version, caseListDescendingDoneAt[1].Version);
            Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListDescendingDoneAt[1].WorkerName);
            Assert.AreEqual(aCase4.workflow_state, caseListDescendingDoneAt[1].WorkflowState);
            #endregion

            #endregion

            #region caseListDescendingStatus Def Sort Des

            #region caseListDescendingStatus aCase1

            Assert.NotNull(caseListDescendingStatus);
            Assert.AreEqual(4, caseListDescendingStatus.Count);
            Assert.AreEqual(aCase1.type, caseListDescendingStatus[3].CaseType);
            Assert.AreEqual(aCase1.case_uid, caseListDescendingStatus[3].CaseUId);
            Assert.AreEqual(aCase1.microting_check_uid, caseListDescendingStatus[3].CheckUIid);
            Assert.AreEqual(c1_ca.ToString(), caseListDescendingStatus[3].CreatedAt.ToString());
            Assert.AreEqual(aCase1.custom, caseListDescendingStatus[3].Custom);
            Assert.AreEqual(c1_da.ToString(), caseListDescendingStatus[3].DoneAt.ToString());
            Assert.AreEqual(aCase1.id, caseListDescendingStatus[3].Id);
            Assert.AreEqual(aCase1.microting_uid, caseListDescendingStatus[3].MicrotingUId);
            Assert.AreEqual(aCase1.site.microting_uid, caseListDescendingStatus[3].SiteId);
            Assert.AreEqual(aCase1.site.name, caseListDescendingStatus[3].SiteName);
            Assert.AreEqual(aCase1.status, caseListDescendingStatus[3].Status);
            Assert.AreEqual(aCase1.check_list_id, caseListDescendingStatus[3].TemplatId);
            Assert.AreEqual(aCase1.unit.microting_uid, caseListDescendingStatus[3].UnitId);
            Assert.AreEqual(c1_ua.ToString(), caseListDescendingStatus[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase1.version, caseListDescendingStatus[3].Version);
            Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListDescendingStatus[3].WorkerName);
            Assert.AreEqual(aCase1.workflow_state, caseListDescendingStatus[3].WorkflowState);

            #endregion

            #region caseListDescendingStatus aCase2

            Assert.AreEqual(aCase2.type, caseListDescendingStatus[2].CaseType);
            Assert.AreEqual(aCase2.case_uid, caseListDescendingStatus[2].CaseUId);
            Assert.AreEqual(aCase2.microting_check_uid, caseListDescendingStatus[2].CheckUIid);
            Assert.AreEqual(c2_ca.ToString(), caseListDescendingStatus[2].CreatedAt.ToString());
            Assert.AreEqual(aCase2.custom, caseListDescendingStatus[2].Custom);
            Assert.AreEqual(c2_da.ToString(), caseListDescendingStatus[2].DoneAt.ToString());
            Assert.AreEqual(aCase2.id, caseListDescendingStatus[2].Id);
            Assert.AreEqual(aCase2.microting_uid, caseListDescendingStatus[2].MicrotingUId);
            Assert.AreEqual(aCase2.site.microting_uid, caseListDescendingStatus[2].SiteId);
            Assert.AreEqual(aCase2.site.name, caseListDescendingStatus[2].SiteName);
            Assert.AreEqual(aCase2.status, caseListDescendingStatus[2].Status);
            Assert.AreEqual(aCase2.check_list_id, caseListDescendingStatus[2].TemplatId);
            Assert.AreEqual(aCase2.unit.microting_uid, caseListDescendingStatus[2].UnitId);
            Assert.AreEqual(c2_ua.ToString(), caseListDescendingStatus[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase2.version, caseListDescendingStatus[2].Version);
            Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListDescendingStatus[2].WorkerName);
            Assert.AreEqual(aCase2.workflow_state, caseListDescendingStatus[2].WorkflowState);

            #endregion

            #region caseListDescendingStatus aCase3

            Assert.AreEqual(aCase3.type, caseListDescendingStatus[1].CaseType);
            Assert.AreEqual(aCase3.case_uid, caseListDescendingStatus[1].CaseUId);
            Assert.AreEqual(aCase3.microting_check_uid, caseListDescendingStatus[1].CheckUIid);
            Assert.AreEqual(c3_ca.ToString(), caseListDescendingStatus[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3.custom, caseListDescendingStatus[1].Custom);
            Assert.AreEqual(c3_da.ToString(), caseListDescendingStatus[1].DoneAt.ToString());
            Assert.AreEqual(aCase3.id, caseListDescendingStatus[1].Id);
            Assert.AreEqual(aCase3.microting_uid, caseListDescendingStatus[1].MicrotingUId);
            Assert.AreEqual(aCase3.site.microting_uid, caseListDescendingStatus[1].SiteId);
            Assert.AreEqual(aCase3.site.name, caseListDescendingStatus[1].SiteName);
            Assert.AreEqual(aCase3.status, caseListDescendingStatus[1].Status);
            Assert.AreEqual(aCase3.check_list_id, caseListDescendingStatus[1].TemplatId);
            Assert.AreEqual(aCase3.unit.microting_uid, caseListDescendingStatus[1].UnitId);
            Assert.AreEqual(c3_ua.ToString(), caseListDescendingStatus[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3.version, caseListDescendingStatus[1].Version);
            Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListDescendingStatus[1].WorkerName);
            Assert.AreEqual(aCase3.workflow_state, caseListDescendingStatus[1].WorkflowState);

            #endregion

            #region caseListDescendingStatus aCase4

            Assert.AreEqual(aCase4.type, caseListDescendingStatus[0].CaseType);
            Assert.AreEqual(aCase4.case_uid, caseListDescendingStatus[0].CaseUId);
            Assert.AreEqual(aCase4.microting_check_uid, caseListDescendingStatus[0].CheckUIid);
            Assert.AreEqual(c4_ca.ToString(), caseListDescendingStatus[0].CreatedAt.ToString());
            Assert.AreEqual(aCase4.custom, caseListDescendingStatus[0].Custom);
            Assert.AreEqual(c4_da.ToString(), caseListDescendingStatus[0].DoneAt.ToString());
            Assert.AreEqual(aCase4.id, caseListDescendingStatus[0].Id);
            Assert.AreEqual(aCase4.microting_uid, caseListDescendingStatus[0].MicrotingUId);
            Assert.AreEqual(aCase4.site.microting_uid, caseListDescendingStatus[0].SiteId);
            Assert.AreEqual(aCase4.site.name, caseListDescendingStatus[0].SiteName);
            Assert.AreEqual(aCase4.status, caseListDescendingStatus[0].Status);
            Assert.AreEqual(aCase4.check_list_id, caseListDescendingStatus[0].TemplatId);
            Assert.AreEqual(aCase4.unit.microting_uid, caseListDescendingStatus[0].UnitId);
            Assert.AreEqual(c4_ua.ToString(), caseListDescendingStatus[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase4.version, caseListDescendingStatus[0].Version);
            Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListDescendingStatus[0].WorkerName);
            Assert.AreEqual(aCase4.workflow_state, caseListDescendingStatus[0].WorkflowState);

            #endregion

            #endregion

            #region caseListDescendingUnitId Def Sort Des

            #region caseListDescendingUnitId aCase1
            Assert.NotNull(caseListDescendingUnitId);
            Assert.AreEqual(4, caseListDescendingUnitId.Count);
            Assert.AreEqual(aCase1.type, caseListDescendingUnitId[3].CaseType);
            Assert.AreEqual(aCase1.case_uid, caseListDescendingUnitId[3].CaseUId);
            Assert.AreEqual(aCase1.microting_check_uid, caseListDescendingUnitId[3].CheckUIid);
            Assert.AreEqual(c1_ca.ToString(), caseListDescendingUnitId[3].CreatedAt.ToString());
            Assert.AreEqual(aCase1.custom, caseListDescendingUnitId[3].Custom);
            Assert.AreEqual(c1_da.ToString(), caseListDescendingUnitId[3].DoneAt.ToString());
            Assert.AreEqual(aCase1.id, caseListDescendingUnitId[3].Id);
            Assert.AreEqual(aCase1.microting_uid, caseListDescendingUnitId[3].MicrotingUId);
            Assert.AreEqual(aCase1.site.microting_uid, caseListDescendingUnitId[3].SiteId);
            Assert.AreEqual(aCase1.site.name, caseListDescendingUnitId[3].SiteName);
            Assert.AreEqual(aCase1.status, caseListDescendingUnitId[3].Status);
            Assert.AreEqual(aCase1.check_list_id, caseListDescendingUnitId[3].TemplatId);
            Assert.AreEqual(aCase1.unit.microting_uid, caseListDescendingUnitId[3].UnitId);
            Assert.AreEqual(c1_ua.ToString(), caseListDescendingUnitId[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase1.version, caseListDescendingUnitId[3].Version);
            Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListDescendingUnitId[3].WorkerName);
            Assert.AreEqual(aCase1.workflow_state, caseListDescendingUnitId[3].WorkflowState);

            #endregion

            #region caseListDescendingUnitId aCase2
            Assert.AreEqual(aCase2.type, caseListDescendingUnitId[2].CaseType);
            Assert.AreEqual(aCase2.case_uid, caseListDescendingUnitId[2].CaseUId);
            Assert.AreEqual(aCase2.microting_check_uid, caseListDescendingUnitId[2].CheckUIid);
            Assert.AreEqual(c2_ca.ToString(), caseListDescendingUnitId[2].CreatedAt.ToString());
            Assert.AreEqual(aCase2.custom, caseListDescendingUnitId[2].Custom);
            Assert.AreEqual(c2_da.ToString(), caseListDescendingUnitId[2].DoneAt.ToString());
            Assert.AreEqual(aCase2.id, caseListDescendingUnitId[2].Id);
            Assert.AreEqual(aCase2.microting_uid, caseListDescendingUnitId[2].MicrotingUId);
            Assert.AreEqual(aCase2.site.microting_uid, caseListDescendingUnitId[2].SiteId);
            Assert.AreEqual(aCase2.site.name, caseListDescendingUnitId[2].SiteName);
            Assert.AreEqual(aCase2.status, caseListDescendingUnitId[2].Status);
            Assert.AreEqual(aCase2.check_list_id, caseListDescendingUnitId[2].TemplatId);
            Assert.AreEqual(aCase2.unit.microting_uid, caseListDescendingUnitId[2].UnitId);
            Assert.AreEqual(c2_ua.ToString(), caseListDescendingUnitId[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase2.version, caseListDescendingUnitId[2].Version);
            Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListDescendingUnitId[2].WorkerName);
            Assert.AreEqual(aCase2.workflow_state, caseListDescendingUnitId[2].WorkflowState);

            #endregion

            #region caseListDescendingUnitId aCase3
            Assert.AreEqual(aCase3.type, caseListDescendingUnitId[1].CaseType);
            Assert.AreEqual(aCase3.case_uid, caseListDescendingUnitId[1].CaseUId);
            Assert.AreEqual(aCase3.microting_check_uid, caseListDescendingUnitId[1].CheckUIid);
            Assert.AreEqual(c3_ca.ToString(), caseListDescendingUnitId[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3.custom, caseListDescendingUnitId[1].Custom);
            Assert.AreEqual(c3_da.ToString(), caseListDescendingUnitId[1].DoneAt.ToString());
            Assert.AreEqual(aCase3.id, caseListDescendingUnitId[1].Id);
            Assert.AreEqual(aCase3.microting_uid, caseListDescendingUnitId[1].MicrotingUId);
            Assert.AreEqual(aCase3.site.microting_uid, caseListDescendingUnitId[1].SiteId);
            Assert.AreEqual(aCase3.site.name, caseListDescendingUnitId[1].SiteName);
            Assert.AreEqual(aCase3.status, caseListDescendingUnitId[1].Status);
            Assert.AreEqual(aCase3.check_list_id, caseListDescendingUnitId[1].TemplatId);
            Assert.AreEqual(aCase3.unit.microting_uid, caseListDescendingUnitId[1].UnitId);
            Assert.AreEqual(c3_ua.ToString(), caseListDescendingUnitId[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3.version, caseListDescendingUnitId[1].Version);
            Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListDescendingUnitId[1].WorkerName);
            Assert.AreEqual(aCase3.workflow_state, caseListDescendingUnitId[1].WorkflowState);

            #endregion

            #region caseListDescendingUnitId aCase4
            Assert.AreEqual(aCase4.type, caseListDescendingUnitId[0].CaseType);
            Assert.AreEqual(aCase4.case_uid, caseListDescendingUnitId[0].CaseUId);
            Assert.AreEqual(aCase4.microting_check_uid, caseListDescendingUnitId[0].CheckUIid);
            Assert.AreEqual(c4_ca.ToString(), caseListDescendingUnitId[0].CreatedAt.ToString());
            Assert.AreEqual(aCase4.custom, caseListDescendingUnitId[0].Custom);
            Assert.AreEqual(c4_da.ToString(), caseListDescendingUnitId[0].DoneAt.ToString());
            Assert.AreEqual(aCase4.id, caseListDescendingUnitId[0].Id);
            Assert.AreEqual(aCase4.microting_uid, caseListDescendingUnitId[0].MicrotingUId);
            Assert.AreEqual(aCase4.site.microting_uid, caseListDescendingUnitId[0].SiteId);
            Assert.AreEqual(aCase4.site.name, caseListDescendingUnitId[0].SiteName);
            Assert.AreEqual(aCase4.status, caseListDescendingUnitId[0].Status);
            Assert.AreEqual(aCase4.check_list_id, caseListDescendingUnitId[0].TemplatId);
            Assert.AreEqual(aCase4.unit.microting_uid, caseListDescendingUnitId[0].UnitId);
            Assert.AreEqual(c4_ua.ToString(), caseListDescendingUnitId[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase4.version, caseListDescendingUnitId[0].Version);
            Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListDescendingUnitId[0].WorkerName);
            Assert.AreEqual(aCase4.workflow_state, caseListDescendingUnitId[0].WorkflowState);

            #endregion

            #endregion

            #endregion

            #region Def Sort Asc w. DateTime


            #region caseListDtDoneAt Def Sort Asc w. DateTime
            #region caseListDtDoneAt aCase1
            Assert.NotNull(caseListDtDoneAt);
            Assert.AreEqual(2, caseListDtDoneAt.Count);
            Assert.AreEqual(aCase1.type, caseListDtDoneAt[1].CaseType);
            Assert.AreEqual(aCase1.case_uid, caseListDtDoneAt[1].CaseUId);
            Assert.AreEqual(aCase1.microting_check_uid, caseListDtDoneAt[1].CheckUIid);
            Assert.AreEqual(c1_ca.ToString(), caseListDtDoneAt[1].CreatedAt.ToString());
            Assert.AreEqual(aCase1.custom, caseListDtDoneAt[1].Custom);
            Assert.AreEqual(c1_da.ToString(), caseListDtDoneAt[1].DoneAt.ToString());
            Assert.AreEqual(aCase1.id, caseListDtDoneAt[1].Id);
            Assert.AreEqual(aCase1.microting_uid, caseListDtDoneAt[1].MicrotingUId);
            Assert.AreEqual(aCase1.site.microting_uid, caseListDtDoneAt[1].SiteId);
            Assert.AreEqual(aCase1.site.name, caseListDtDoneAt[1].SiteName);
            Assert.AreEqual(aCase1.status, caseListDtDoneAt[1].Status);
            Assert.AreEqual(cl1.id, caseListDtDoneAt[1].TemplatId);
            Assert.AreEqual(aCase1.unit.microting_uid, caseListDtDoneAt[1].UnitId);
            Assert.AreEqual(c1_ua.ToString(), caseListDtDoneAt[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase1.version, caseListDtDoneAt[1].Version);
            Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListDtDoneAt[1].WorkerName);
            Assert.AreEqual(aCase1.workflow_state, caseListDtDoneAt[1].WorkflowState);
            #endregion

            #region caseListDtDoneAt aCase3
            Assert.AreEqual(aCase3.type, caseListDtDoneAt[0].CaseType);
            Assert.AreEqual(aCase3.case_uid, caseListDtDoneAt[0].CaseUId);
            Assert.AreEqual(aCase3.microting_check_uid, caseListDtDoneAt[0].CheckUIid);
            Assert.AreEqual(c3_ca.ToString(), caseListDtDoneAt[0].CreatedAt.ToString());
            Assert.AreEqual(aCase3.custom, caseListDtDoneAt[0].Custom);
            Assert.AreEqual(c3_da.ToString(), caseListDtDoneAt[0].DoneAt.ToString());
            Assert.AreEqual(aCase3.id, caseListDtDoneAt[0].Id);
            Assert.AreEqual(aCase3.microting_uid, caseListDtDoneAt[0].MicrotingUId);
            Assert.AreEqual(aCase3.site.microting_uid, caseListDtDoneAt[0].SiteId);
            Assert.AreEqual(aCase3.site.name, caseListDtDoneAt[0].SiteName);
            Assert.AreEqual(aCase3.status, caseListDtDoneAt[0].Status);
            Assert.AreEqual(cl1.id, caseListDtDoneAt[0].TemplatId);
            Assert.AreEqual(aCase3.unit.microting_uid, caseListDtDoneAt[0].UnitId);
            Assert.AreEqual(c3_ua.ToString(), caseListDtDoneAt[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase3.version, caseListDtDoneAt[0].Version);
            Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListDtDoneAt[0].WorkerName);
            Assert.AreEqual(aCase3.workflow_state, caseListDtDoneAt[0].WorkflowState);
            #endregion


            #endregion

            #region caseListDtStatus Def Sort Asc w. DateTime

            #region caseListDtStatus aCase1

            Assert.NotNull(caseListDtStatus);
            Assert.AreEqual(2, caseListDtStatus.Count);
            Assert.AreEqual(aCase1.type, caseListDtStatus[0].CaseType);
            Assert.AreEqual(aCase1.case_uid, caseListDtStatus[0].CaseUId);
            Assert.AreEqual(aCase1.microting_check_uid, caseListDtStatus[0].CheckUIid);
            Assert.AreEqual(c1_ca.ToString(), caseListDtStatus[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1.custom, caseListDtStatus[0].Custom);
            Assert.AreEqual(c1_da.ToString(), caseListDtStatus[0].DoneAt.ToString());
            Assert.AreEqual(aCase1.id, caseListDtStatus[0].Id);
            Assert.AreEqual(aCase1.microting_uid, caseListDtStatus[0].MicrotingUId);
            Assert.AreEqual(aCase1.site.microting_uid, caseListDtStatus[0].SiteId);
            Assert.AreEqual(aCase1.site.name, caseListDtStatus[0].SiteName);
            Assert.AreEqual(aCase1.status, caseListDtStatus[0].Status);
            Assert.AreEqual(aCase1.check_list_id, caseListDtStatus[0].TemplatId);
            Assert.AreEqual(aCase1.unit.microting_uid, caseListDtStatus[0].UnitId);
            Assert.AreEqual(c1_ua.ToString(), caseListDtStatus[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1.version, caseListDtStatus[0].Version);
            Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListDtStatus[0].WorkerName);
            Assert.AreEqual(aCase1.workflow_state, caseListDtStatus[0].WorkflowState);

            #endregion

            #region caseListDtStatus aCase3

            Assert.AreEqual(aCase3.type, caseListDtStatus[1].CaseType);
            Assert.AreEqual(aCase3.case_uid, caseListDtStatus[1].CaseUId);
            Assert.AreEqual(aCase3.microting_check_uid, caseListDtStatus[1].CheckUIid);
            Assert.AreEqual(c3_ca.ToString(), caseListDtStatus[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3.custom, caseListDtStatus[1].Custom);
            Assert.AreEqual(c3_da.ToString(), caseListDtStatus[1].DoneAt.ToString());
            Assert.AreEqual(aCase3.id, caseListDtStatus[1].Id);
            Assert.AreEqual(aCase3.microting_uid, caseListDtStatus[1].MicrotingUId);
            Assert.AreEqual(aCase3.site.microting_uid, caseListDtStatus[1].SiteId);
            Assert.AreEqual(aCase3.site.name, caseListDtStatus[1].SiteName);
            Assert.AreEqual(aCase3.status, caseListDtStatus[1].Status);
            Assert.AreEqual(aCase3.check_list_id, caseListDtStatus[1].TemplatId);
            Assert.AreEqual(aCase3.unit.microting_uid, caseListDtStatus[1].UnitId);
            Assert.AreEqual(c3_ua.ToString(), caseListDtStatus[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3.version, caseListDtStatus[1].Version);
            Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListDtStatus[1].WorkerName);
            Assert.AreEqual(aCase3.workflow_state, caseListDtStatus[1].WorkflowState);

            #endregion

            #endregion

            #region caseListDtUnitId Def Sort Asc w. DateTime

            #region caseListDtUnitId aCase1

            Assert.NotNull(caseListDtUnitId);
            Assert.AreEqual(2, caseListDtUnitId.Count);
            Assert.AreEqual(aCase1.type, caseListDtUnitId[0].CaseType);
            Assert.AreEqual(aCase1.case_uid, caseListDtUnitId[0].CaseUId);
            Assert.AreEqual(aCase1.microting_check_uid, caseListDtUnitId[0].CheckUIid);
            Assert.AreEqual(c1_ca.ToString(), caseListDtUnitId[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1.custom, caseListDtUnitId[0].Custom);
            Assert.AreEqual(c1_da.ToString(), caseListDtUnitId[0].DoneAt.ToString());
            Assert.AreEqual(aCase1.id, caseListDtUnitId[0].Id);
            Assert.AreEqual(aCase1.microting_uid, caseListDtUnitId[0].MicrotingUId);
            Assert.AreEqual(aCase1.site.microting_uid, caseListDtUnitId[0].SiteId);
            Assert.AreEqual(aCase1.site.name, caseListDtUnitId[0].SiteName);
            Assert.AreEqual(aCase1.status, caseListDtUnitId[0].Status);
            Assert.AreEqual(aCase1.check_list_id, caseListDtUnitId[0].TemplatId);
            Assert.AreEqual(aCase1.unit.microting_uid, caseListDtUnitId[0].UnitId);
            Assert.AreEqual(c1_ua.ToString(), caseListDtUnitId[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1.version, caseListDtUnitId[0].Version);
            Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListDtUnitId[0].WorkerName);
            Assert.AreEqual(aCase1.workflow_state, caseListDtUnitId[0].WorkflowState);

            #endregion

            #region caseListDtUnitId aCase3

            Assert.AreEqual(aCase3.type, caseListDtUnitId[1].CaseType);
            Assert.AreEqual(aCase3.case_uid, caseListDtUnitId[1].CaseUId);
            Assert.AreEqual(aCase3.microting_check_uid, caseListDtUnitId[1].CheckUIid);
            Assert.AreEqual(c3_ca.ToString(), caseListDtUnitId[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3.custom, caseListDtUnitId[1].Custom);
            Assert.AreEqual(c3_da.ToString(), caseListDtUnitId[1].DoneAt.ToString());
            Assert.AreEqual(aCase3.id, caseListDtUnitId[1].Id);
            Assert.AreEqual(aCase3.microting_uid, caseListDtUnitId[1].MicrotingUId);
            Assert.AreEqual(aCase3.site.microting_uid, caseListDtUnitId[1].SiteId);
            Assert.AreEqual(aCase3.site.name, caseListDtUnitId[1].SiteName);
            Assert.AreEqual(aCase3.status, caseListDtUnitId[1].Status);
            Assert.AreEqual(aCase3.check_list_id, caseListDtUnitId[1].TemplatId);
            Assert.AreEqual(aCase3.unit.microting_uid, caseListDtUnitId[1].UnitId);
            Assert.AreEqual(c3_ua.ToString(), caseListDtUnitId[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3.version, caseListDtUnitId[1].Version);
            Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListDtUnitId[1].WorkerName);
            Assert.AreEqual(aCase3.workflow_state, caseListDtUnitId[1].WorkflowState);

            #endregion



            #endregion

            #endregion

            #region Def Sort Des w. DateTime
            #region caseListDtDescendingDoneAt Def Sort Des


            #region caseListDtDescendingDoneAt aCase1
            Assert.NotNull(caseListDtDescendingDoneAt);
            Assert.AreEqual(2, caseListDtDescendingDoneAt.Count);
            Assert.AreEqual(aCase1.type, caseListDtDescendingDoneAt[0].CaseType);
            Assert.AreEqual(aCase1.case_uid, caseListDtDescendingDoneAt[0].CaseUId);
            Assert.AreEqual(aCase1.microting_check_uid, caseListDtDescendingDoneAt[0].CheckUIid);
            Assert.AreEqual(c1_ca.ToString(), caseListDtDescendingDoneAt[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1.custom, caseListDtDescendingDoneAt[0].Custom);
            Assert.AreEqual(c1_da.ToString(), caseListDtDescendingDoneAt[0].DoneAt.ToString());
            Assert.AreEqual(aCase1.id, caseListDtDescendingDoneAt[0].Id);
            Assert.AreEqual(aCase1.microting_uid, caseListDtDescendingDoneAt[0].MicrotingUId);
            Assert.AreEqual(aCase1.site.microting_uid, caseListDtDescendingDoneAt[0].SiteId);
            Assert.AreEqual(aCase1.site.name, caseListDtDescendingDoneAt[0].SiteName);
            Assert.AreEqual(aCase1.status, caseListDtDescendingDoneAt[0].Status);
            Assert.AreEqual(cl1.id, caseListDtDescendingDoneAt[0].TemplatId);
            Assert.AreEqual(aCase1.unit.microting_uid, caseListDtDescendingDoneAt[0].UnitId);
            Assert.AreEqual(c1_ua.ToString(), caseListDtDescendingDoneAt[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1.version, caseListDtDescendingDoneAt[0].Version);
            Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListDtDescendingDoneAt[0].WorkerName);
            Assert.AreEqual(aCase1.workflow_state, caseListDtDescendingDoneAt[0].WorkflowState);
            #endregion

            #region caseListDtDescendingDoneAt aCase4

            Assert.AreEqual(aCase3.type, caseListDtDescendingDoneAt[1].CaseType);
            Assert.AreEqual(aCase3.case_uid, caseListDtDescendingDoneAt[1].CaseUId);
            Assert.AreEqual(aCase3.microting_check_uid, caseListDtDescendingDoneAt[1].CheckUIid);
            Assert.AreEqual(c3_ca.ToString(), caseListDtDescendingDoneAt[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3.custom, caseListDtDescendingDoneAt[1].Custom);
            Assert.AreEqual(c3_da.ToString(), caseListDtDescendingDoneAt[1].DoneAt.ToString());
            Assert.AreEqual(aCase3.id, caseListDtDescendingDoneAt[1].Id);
            Assert.AreEqual(aCase3.microting_uid, caseListDtDescendingDoneAt[1].MicrotingUId);
            Assert.AreEqual(aCase3.site.microting_uid, caseListDtDescendingDoneAt[1].SiteId);
            Assert.AreEqual(aCase3.site.name, caseListDtDescendingDoneAt[1].SiteName);
            Assert.AreEqual(aCase3.status, caseListDtDescendingDoneAt[1].Status);
            Assert.AreEqual(cl1.id, caseListDtDescendingDoneAt[1].TemplatId);
            Assert.AreEqual(aCase3.unit.microting_uid, caseListDtDescendingDoneAt[1].UnitId);
            Assert.AreEqual(c3_ua.ToString(), caseListDtDescendingDoneAt[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3.version, caseListDtDescendingDoneAt[1].Version);
            Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListDtDescendingDoneAt[1].WorkerName);
            Assert.AreEqual(aCase3.workflow_state, caseListDtDescendingDoneAt[1].WorkflowState);
            #endregion

            #endregion

            #region caseListDtDescendingStatus Def Sort Des



            #region caseListDtDescendingStatus aCase1
            Assert.NotNull(caseListDtDescendingStatus);
            Assert.AreEqual(2, caseListDtDescendingStatus.Count);
            Assert.AreEqual(aCase1.type, caseListDtDescendingStatus[1].CaseType);
            Assert.AreEqual(aCase1.case_uid, caseListDtDescendingStatus[1].CaseUId);
            Assert.AreEqual(aCase1.microting_check_uid, caseListDtDescendingStatus[1].CheckUIid);
            Assert.AreEqual(c1_ca.ToString(), caseListDtDescendingStatus[1].CreatedAt.ToString());
            Assert.AreEqual(aCase1.custom, caseListDtDescendingStatus[1].Custom);
            Assert.AreEqual(c1_da.ToString(), caseListDtDescendingStatus[1].DoneAt.ToString());
            Assert.AreEqual(aCase1.id, caseListDtDescendingStatus[1].Id);
            Assert.AreEqual(aCase1.microting_uid, caseListDtDescendingStatus[1].MicrotingUId);
            Assert.AreEqual(aCase1.site.microting_uid, caseListDtDescendingStatus[1].SiteId);
            Assert.AreEqual(aCase1.site.name, caseListDtDescendingStatus[1].SiteName);
            Assert.AreEqual(aCase1.status, caseListDtDescendingStatus[1].Status);
            Assert.AreEqual(aCase1.check_list_id, caseListDtDescendingStatus[1].TemplatId);
            Assert.AreEqual(aCase1.unit.microting_uid, caseListDtDescendingStatus[1].UnitId);
            Assert.AreEqual(c1_ua.ToString(), caseListDtDescendingStatus[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase1.version, caseListDtDescendingStatus[1].Version);
            Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListDtDescendingStatus[1].WorkerName);
            Assert.AreEqual(aCase1.workflow_state, caseListDtDescendingStatus[1].WorkflowState);

            #endregion

            #region caseListDtDescendingStatus aCase3

            Assert.AreEqual(aCase3.type, caseListDtDescendingStatus[0].CaseType);
            Assert.AreEqual(aCase3.case_uid, caseListDtDescendingStatus[0].CaseUId);
            Assert.AreEqual(aCase3.microting_check_uid, caseListDtDescendingStatus[0].CheckUIid);
            Assert.AreEqual(c3_ca.ToString(), caseListDtDescendingStatus[0].CreatedAt.ToString());
            Assert.AreEqual(aCase3.custom, caseListDtDescendingStatus[0].Custom);
            Assert.AreEqual(c3_da.ToString(), caseListDtDescendingStatus[0].DoneAt.ToString());
            Assert.AreEqual(aCase3.id, caseListDtDescendingStatus[0].Id);
            Assert.AreEqual(aCase3.microting_uid, caseListDtDescendingStatus[0].MicrotingUId);
            Assert.AreEqual(aCase3.site.microting_uid, caseListDtDescendingStatus[0].SiteId);
            Assert.AreEqual(aCase3.site.name, caseListDtDescendingStatus[0].SiteName);
            Assert.AreEqual(aCase3.status, caseListDtDescendingStatus[0].Status);
            Assert.AreEqual(aCase3.check_list_id, caseListDtDescendingStatus[0].TemplatId);
            Assert.AreEqual(aCase3.unit.microting_uid, caseListDtDescendingStatus[0].UnitId);
            Assert.AreEqual(c3_ua.ToString(), caseListDtDescendingStatus[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase3.version, caseListDtDescendingStatus[0].Version);
            Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListDtDescendingStatus[0].WorkerName);
            Assert.AreEqual(aCase3.workflow_state, caseListDtDescendingStatus[0].WorkflowState);

            #endregion

            #endregion

            #region caseListDtDescendingUnitId Def Sort Des

            #region caseListDtDescendingUnitId aCase3
            Assert.NotNull(caseListDtDescendingUnitId);
            Assert.AreEqual(2, caseListDtDescendingUnitId.Count);

            Assert.AreEqual(aCase1.type, caseListDtDescendingUnitId[1].CaseType);
            Assert.AreEqual(aCase1.case_uid, caseListDtDescendingUnitId[1].CaseUId);
            Assert.AreEqual(aCase1.microting_check_uid, caseListDtDescendingUnitId[1].CheckUIid);
            Assert.AreEqual(c1_ca.ToString(), caseListDtDescendingUnitId[1].CreatedAt.ToString());
            Assert.AreEqual(aCase1.custom, caseListDtDescendingUnitId[1].Custom);
            Assert.AreEqual(c1_da.ToString(), caseListDtDescendingUnitId[1].DoneAt.ToString());
            Assert.AreEqual(aCase1.id, caseListDtDescendingUnitId[1].Id);
            Assert.AreEqual(aCase1.microting_uid, caseListDtDescendingUnitId[1].MicrotingUId);
            Assert.AreEqual(aCase1.site.microting_uid, caseListDtDescendingUnitId[1].SiteId);
            Assert.AreEqual(aCase1.site.name, caseListDtDescendingUnitId[1].SiteName);
            Assert.AreEqual(aCase1.status, caseListDtDescendingUnitId[1].Status);
            Assert.AreEqual(aCase1.check_list_id, caseListDtDescendingUnitId[1].TemplatId);
            Assert.AreEqual(aCase1.unit.microting_uid, caseListDtDescendingUnitId[1].UnitId);
            Assert.AreEqual(c1_ua.ToString(), caseListDtDescendingUnitId[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase1.version, caseListDtDescendingUnitId[1].Version);
            Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListDtDescendingUnitId[1].WorkerName);
            Assert.AreEqual(aCase1.workflow_state, caseListDtDescendingUnitId[1].WorkflowState);

            #endregion

            #region caseListDtDescendingUnitId aCase3
            Assert.AreEqual(aCase3.type, caseListDtDescendingUnitId[0].CaseType);
            Assert.AreEqual(aCase3.case_uid, caseListDtDescendingUnitId[0].CaseUId);
            Assert.AreEqual(aCase3.microting_check_uid, caseListDtDescendingUnitId[0].CheckUIid);
            Assert.AreEqual(c3_ca.ToString(), caseListDtDescendingUnitId[0].CreatedAt.ToString());
            Assert.AreEqual(aCase3.custom, caseListDtDescendingUnitId[0].Custom);
            Assert.AreEqual(c3_da.ToString(), caseListDtDescendingUnitId[0].DoneAt.ToString());
            Assert.AreEqual(aCase3.id, caseListDtDescendingUnitId[0].Id);
            Assert.AreEqual(aCase3.microting_uid, caseListDtDescendingUnitId[0].MicrotingUId);
            Assert.AreEqual(aCase3.site.microting_uid, caseListDtDescendingUnitId[0].SiteId);
            Assert.AreEqual(aCase3.site.name, caseListDtDescendingUnitId[0].SiteName);
            Assert.AreEqual(aCase3.status, caseListDtDescendingUnitId[0].Status);
            Assert.AreEqual(aCase3.check_list_id, caseListDtDescendingUnitId[0].TemplatId);
            Assert.AreEqual(aCase3.unit.microting_uid, caseListDtDescendingUnitId[0].UnitId);
            Assert.AreEqual(c3_ua.ToString(), caseListDtDescendingUnitId[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase3.version, caseListDtDescendingUnitId[0].Version);
            Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListDtDescendingUnitId[0].WorkerName);
            Assert.AreEqual(aCase3.workflow_state, caseListDtDescendingUnitId[0].WorkflowState);

            #endregion

            #endregion

            #endregion
            #endregion

            #region Case Sort

            #region aCase Sort Asc

            #region aCase1 sort asc

            #region caseListC1DoneAt aCase1
            Assert.NotNull(caseListC1SortDoneAt);
            Assert.AreEqual(0, caseListC1SortDoneAt.Count);
            //Assert.AreEqual(aCase1.type, caseListC1SortDoneAt[0].CaseType);
            //Assert.AreEqual(aCase1.case_uid, caseListC1SortDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase1.microting_check_uid, caseListC1SortDoneAt[0].CheckUIid);
            //Assert.AreEqual(c1_ca.ToString(), caseListC1SortDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1.custom, caseListC1SortDoneAt[0].Custom);
            //Assert.AreEqual(c1_da.ToString(), caseListC1SortDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1.id, caseListC1SortDoneAt[0].Id);
            //Assert.AreEqual(aCase1.microting_uid, caseListC1SortDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase1.site.microting_uid, caseListC1SortDoneAt[0].SiteId);
            //Assert.AreEqual(aCase1.site.name, caseListC1SortDoneAt[0].SiteName);
            //Assert.AreEqual(aCase1.status, caseListC1SortDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListC1SortDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase1.unit.id, caseListC1SortDoneAt[0].UnitId);
            //Assert.AreEqual(c1_ua.ToString(), caseListC1SortDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1.version, caseListC1SortDoneAt[0].Version);
            //Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListC1SortDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase1.workflow_state, caseListC1SortDoneAt[0].WorkflowState);
            #endregion

            #region caseListC1SortStatus aCase1
            Assert.NotNull(caseListC1SortStatus);
            Assert.AreEqual(0, caseListC1SortStatus.Count);
            //Assert.AreEqual(aCase1.type, caseListC1SortStatus[0].CaseType);
            //Assert.AreEqual(aCase1.case_uid, caseListC1SortStatus[0].CaseUId);
            //Assert.AreEqual(aCase1.microting_check_uid, caseListC1SortStatus[0].CheckUIid);
            //Assert.AreEqual(c1_ca.ToString(), caseListC1SortStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1.custom, caseListC1SortStatus[0].Custom);
            //Assert.AreEqual(c1_da.ToString(), caseListC1SortStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1.id, caseListC1SortStatus[0].Id);
            //Assert.AreEqual(aCase1.microting_uid, caseListC1SortStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase1.site.microting_uid, caseListC1SortStatus[0].SiteId);
            //Assert.AreEqual(aCase1.site.name, caseListC1SortStatus[0].SiteName);
            //Assert.AreEqual(aCase1.status, caseListC1SortStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListC1SortStatus[0].TemplatId);
            //Assert.AreEqual(aCase1.unit.id, caseListC1SortStatus[0].UnitId);
            //Assert.AreEqual(c1_ua.ToString(), caseListC1SortStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1.version, caseListC1SortStatus[0].Version);
            //Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListC1SortStatus[0].WorkerName);
            //Assert.AreEqual(aCase1.workflow_state, caseListC1SortStatus[0].WorkflowState);
            #endregion

            #region caseListC1SortUnitId

            Assert.NotNull(caseListC1SortUnitId);
            Assert.AreEqual(0, caseListC1SortUnitId.Count);
            //Assert.AreEqual(aCase1.type, caseListC1SortUnitId[0].CaseType);
            //Assert.AreEqual(aCase1.case_uid, caseListC1SortUnitId[0].CaseUId);
            //Assert.AreEqual(aCase1.microting_check_uid, caseListC1SortUnitId[0].CheckUIid);
            //Assert.AreEqual(c1_ca.ToString(), caseListC1SortUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1.custom, caseListC1SortUnitId[0].Custom);
            //Assert.AreEqual(c1_da.ToString(), caseListC1SortUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1.id, caseListC1SortUnitId[0].Id);
            //Assert.AreEqual(aCase1.microting_uid, caseListC1SortUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase1.site.microting_uid, caseListC1SortUnitId[0].SiteId);
            //Assert.AreEqual(aCase1.site.name, caseListC1SortUnitId[0].SiteName);
            //Assert.AreEqual(aCase1.status, caseListC1SortUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListC1SortUnitId[0].TemplatId);
            //Assert.AreEqual(aCase1.unit.id, caseListC1SortUnitId[0].UnitId);
            //Assert.AreEqual(c1_ua.ToString(), caseListC1SortUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1.version, caseListC1SortUnitId[0].Version);
            //Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListC1SortUnitId[0].WorkerName);
            //Assert.AreEqual(aCase1.workflow_state, caseListC1SortUnitId[0].WorkflowState);

            #endregion



            #endregion

            #region aCase2 sort asc

            #region caseListC2DoneAt aCase2
            Assert.NotNull(caseListC2SortDoneAt);
            Assert.AreEqual(0, caseListC2SortDoneAt.Count);
            //Assert.AreEqual(aCase2.type, caseListC2SortDoneAt[0].CaseType);
            //Assert.AreEqual(aCase2.case_uid, caseListC2SortDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase2.microting_check_uid, caseListC2SortDoneAt[0].CheckUIid);
            //Assert.AreEqual(c2_ca.ToString(), caseListC2SortDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2.custom, caseListC2SortDoneAt[0].Custom);
            //Assert.AreEqual(c2_da.ToString(), caseListC2SortDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2.id, caseListC2SortDoneAt[0].Id);
            //Assert.AreEqual(aCase2.microting_uid, caseListC2SortDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase2.site.microting_uid, caseListC2SortDoneAt[0].SiteId);
            //Assert.AreEqual(aCase2.site.name, caseListC2SortDoneAt[0].SiteName);
            //Assert.AreEqual(aCase2.status, caseListC2SortDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListC2SortDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase2.unit.id, caseListC2SortDoneAt[0].UnitId);
            //Assert.AreEqual(c2_ua.ToString(), caseListC2SortDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2.version, caseListC2SortDoneAt[0].Version);
            //Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListC2SortDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase2.workflow_state, caseListC2SortDoneAt[0].WorkflowState);
            #endregion

            #region caseListC2SortStatus aCase2
            Assert.NotNull(caseListC2SortStatus);
            Assert.AreEqual(0, caseListC2SortStatus.Count);
            //Assert.AreEqual(aCase2.type, caseListC2SortStatus[0].CaseType);
            //Assert.AreEqual(aCase2.case_uid, caseListC2SortStatus[0].CaseUId);
            //Assert.AreEqual(aCase2.microting_check_uid, caseListC2SortStatus[0].CheckUIid);
            //Assert.AreEqual(c2_ca.ToString(), caseListC2SortStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2.custom, caseListC2SortStatus[0].Custom);
            //Assert.AreEqual(c2_da.ToString(), caseListC2SortStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2.id, caseListC2SortStatus[0].Id);
            //Assert.AreEqual(aCase2.microting_uid, caseListC2SortStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase2.site.microting_uid, caseListC2SortStatus[0].SiteId);
            //Assert.AreEqual(aCase2.site.name, caseListC2SortStatus[0].SiteName);
            //Assert.AreEqual(aCase2.status, caseListC2SortStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListC2SortStatus[0].TemplatId);
            //Assert.AreEqual(aCase2.unit.id, caseListC2SortStatus[0].UnitId);
            //Assert.AreEqual(c2_ua.ToString(), caseListC2SortStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2.version, caseListC2SortStatus[0].Version);
            //Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListC2SortStatus[0].WorkerName);
            //Assert.AreEqual(aCase2.workflow_state, caseListC2SortStatus[0].WorkflowState);
            #endregion

            #region caseListC2SortUnitId aCase2
            Assert.NotNull(caseListC2SortUnitId);
            Assert.AreEqual(0, caseListC2SortUnitId.Count);
            //Assert.AreEqual(aCase2.type, caseListC2SortUnitId[0].CaseType);
            //Assert.AreEqual(aCase2.case_uid, caseListC2SortUnitId[0].CaseUId);
            //Assert.AreEqual(aCase2.microting_check_uid, caseListC2SortUnitId[0].CheckUIid);
            //Assert.AreEqual(c2_ca.ToString(), caseListC2SortUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2.custom, caseListC2SortUnitId[0].Custom);
            //Assert.AreEqual(c2_da.ToString(), caseListC2SortUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2.id, caseListC2SortUnitId[0].Id);
            //Assert.AreEqual(aCase2.microting_uid, caseListC2SortUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase2.site.microting_uid, caseListC2SortUnitId[0].SiteId);
            //Assert.AreEqual(aCase2.site.name, caseListC2SortUnitId[0].SiteName);
            //Assert.AreEqual(aCase2.status, caseListC2SortUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListC2SortUnitId[0].TemplatId);
            //Assert.AreEqual(aCase2.unit.id, caseListC2SortUnitId[0].UnitId);
            //Assert.AreEqual(c2_ua.ToString(), caseListC2SortUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2.version, caseListC2SortUnitId[0].Version);
            //Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListC2SortUnitId[0].WorkerName);
            //Assert.AreEqual(aCase2.workflow_state, caseListC2SortUnitId[0].WorkflowState);
            #endregion

            #endregion

            #region aCase3 sort asc

            #region caseListC3DoneAt aCase3
            Assert.NotNull(caseListC3SortDoneAt);
            Assert.AreEqual(0, caseListC3SortDoneAt.Count);
            //Assert.AreEqual(aCase3.type, caseListC3SortDoneAt[0].CaseType);
            //Assert.AreEqual(aCase3.case_uid, caseListC3SortDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase3.microting_check_uid, caseListC3SortDoneAt[0].CheckUIid);
            //Assert.AreEqual(c3_ca.ToString(), caseListC3SortDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3.custom, caseListC3SortDoneAt[0].Custom);
            //Assert.AreEqual(c3_da.ToString(), caseListC3SortDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3.id, caseListC3SortDoneAt[0].Id);
            //Assert.AreEqual(aCase3.microting_uid, caseListC3SortDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase3.site.microting_uid, caseListC3SortDoneAt[0].SiteId);
            //Assert.AreEqual(aCase3.site.name, caseListC3SortDoneAt[0].SiteName);
            //Assert.AreEqual(aCase3.status, caseListC3SortDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListC3SortDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase3.unit.id, caseListC3SortDoneAt[0].UnitId);
            //Assert.AreEqual(c3_ua.ToString(), caseListC3SortDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3.version, caseListC3SortDoneAt[0].Version);
            //Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListC3SortDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase3.workflow_state, caseListC3SortDoneAt[0].WorkflowState);
            #endregion

            #region caseListC3status aCase3
            Assert.NotNull(caseListC3SortStatus);
            Assert.AreEqual(0, caseListC3SortStatus.Count);
            //Assert.AreEqual(aCase3.type, caseListC3SortStatus[0].CaseType);
            //Assert.AreEqual(aCase3.case_uid, caseListC3SortStatus[0].CaseUId);
            //Assert.AreEqual(aCase3.microting_check_uid, caseListC3SortStatus[0].CheckUIid);
            //Assert.AreEqual(c3_ca.ToString(), caseListC3SortStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3.custom, caseListC3SortStatus[0].Custom);
            //Assert.AreEqual(c3_da.ToString(), caseListC3SortStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3.id, caseListC3SortStatus[0].Id);
            //Assert.AreEqual(aCase3.microting_uid, caseListC3SortStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase3.site.microting_uid, caseListC3SortStatus[0].SiteId);
            //Assert.AreEqual(aCase3.site.name, caseListC3SortStatus[0].SiteName);
            //Assert.AreEqual(aCase3.status, caseListC3SortStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListC3SortStatus[0].TemplatId);
            //Assert.AreEqual(aCase3.unit.id, caseListC3SortStatus[0].UnitId);
            //Assert.AreEqual(c3_ua.ToString(), caseListC3SortStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3.version, caseListC3SortStatus[0].Version);
            //Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListC3SortStatus[0].WorkerName);
            //Assert.AreEqual(aCase3.workflow_state, caseListC3SortStatus[0].WorkflowState);
            #endregion

            #region caseListC3UnitId aCase3
            Assert.NotNull(caseListC3SortUnitId);
            Assert.AreEqual(0, caseListC3SortUnitId.Count);
            //Assert.AreEqual(aCase3.type, caseListC3SortUnitId[0].CaseType);
            //Assert.AreEqual(aCase3.case_uid, caseListC3SortUnitId[0].CaseUId);
            //Assert.AreEqual(aCase3.microting_check_uid, caseListC3SortUnitId[0].CheckUIid);
            //Assert.AreEqual(c3_ca.ToString(), caseListC3SortUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3.custom, caseListC3SortUnitId[0].Custom);
            //Assert.AreEqual(c3_da.ToString(), caseListC3SortUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3.id, caseListC3SortUnitId[0].Id);
            //Assert.AreEqual(aCase3.microting_uid, caseListC3SortUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase3.site.microting_uid, caseListC3SortUnitId[0].SiteId);
            //Assert.AreEqual(aCase3.site.name, caseListC3SortUnitId[0].SiteName);
            //Assert.AreEqual(aCase3.status, caseListC3SortUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListC3SortUnitId[0].TemplatId);
            //Assert.AreEqual(aCase3.unit.id, caseListC3SortUnitId[0].UnitId);
            //Assert.AreEqual(c3_ua.ToString(), caseListC3SortUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3.version, caseListC3SortUnitId[0].Version);
            //Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListC3SortUnitId[0].WorkerName);
            //Assert.AreEqual(aCase3.workflow_state, caseListC3SortUnitId[0].WorkflowState);
            #endregion



            #endregion

            #region aCase4 sort asc

            #region caseListC4SortDoneAt aCase4
            Assert.NotNull(caseListC4SortDoneAt);
            Assert.AreEqual(0, caseListC4SortDoneAt.Count);
            //Assert.AreEqual(aCase4.type, caseListC4SortDoneAt[0].CaseType);
            //Assert.AreEqual(aCase4.case_uid, caseListC4SortDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase4.microting_check_uid, caseListC4SortDoneAt[0].CheckUIid);
            //Assert.AreEqual(c4_ca.ToString(), caseListC4SortDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4.custom, caseListC4SortDoneAt[0].Custom);
            //Assert.AreEqual(c4_da.ToString(), caseListC4SortDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4.id, caseListC4SortDoneAt[0].Id);
            //Assert.AreEqual(aCase4.microting_uid, caseListC4SortDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase4.site.microting_uid, caseListC4SortDoneAt[0].SiteId);
            //Assert.AreEqual(aCase4.site.name, caseListC4SortDoneAt[0].SiteName);
            //Assert.AreEqual(aCase4.status, caseListC4SortDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListC4SortDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase4.unit.id, caseListC4SortDoneAt[0].UnitId);
            //Assert.AreEqual(c4_ua.ToString(), caseListC4SortDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4.version, caseListC4SortDoneAt[0].Version);
            //Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListC4SortDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase4.workflow_state, caseListC4SortDoneAt[0].WorkflowState);
            #endregion

            #region caseListC4SortStatus aCase4
            Assert.NotNull(caseListC1SortDoneAt);
            Assert.AreEqual(0, caseListC1SortDoneAt.Count);
            //Assert.AreEqual(aCase4.type, caseListC1SortDoneAt[0].CaseType);
            //Assert.AreEqual(aCase4.case_uid, caseListC1SortDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase4.microting_check_uid, caseListC1SortDoneAt[0].CheckUIid);
            //Assert.AreEqual(c4_ca.ToString(), caseListC1SortDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4.custom, caseListC1SortDoneAt[0].Custom);
            //Assert.AreEqual(c4_da.ToString(), caseListC1SortDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4.id, caseListC1SortDoneAt[0].Id);
            //Assert.AreEqual(aCase4.microting_uid, caseListC1SortDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase4.site.microting_uid, caseListC1SortDoneAt[0].SiteId);
            //Assert.AreEqual(aCase4.site.name, caseListC1SortDoneAt[0].SiteName);
            //Assert.AreEqual(aCase4.status, caseListC1SortDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListC1SortDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase4.unit.id, caseListC1SortDoneAt[0].UnitId);
            //Assert.AreEqual(c4_ua.ToString(), caseListC1SortDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4.version, caseListC1SortDoneAt[0].Version);
            //Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListC1SortDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase4.workflow_state, caseListC1SortDoneAt[0].WorkflowState);
            #endregion

            #region caseListC4SortUnitId aCase4

            Assert.NotNull(caseListC4SortDoneAt);
            Assert.AreEqual(0, caseListC4SortDoneAt.Count);
            //Assert.AreEqual(aCase4.type, caseListC4SortDoneAt[0].CaseType);
            //Assert.AreEqual(aCase4.case_uid, caseListC4SortDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase4.microting_check_uid, caseListC4SortDoneAt[0].CheckUIid);
            //Assert.AreEqual(c4_ca.ToString(), caseListC4SortDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4.custom, caseListC4SortDoneAt[0].Custom);
            //Assert.AreEqual(c4_da.ToString(), caseListC4SortDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4.id, caseListC4SortDoneAt[0].Id);
            //Assert.AreEqual(aCase4.microting_uid, caseListC4SortDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase4.site.microting_uid, caseListC4SortDoneAt[0].SiteId);
            //Assert.AreEqual(aCase4.site.name, caseListC4SortDoneAt[0].SiteName);
            //Assert.AreEqual(aCase4.status, caseListC4SortDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListC4SortDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase4.unit.id, caseListC4SortDoneAt[0].UnitId);
            //Assert.AreEqual(c4_ua.ToString(), caseListC4SortDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4.version, caseListC4SortDoneAt[0].Version);
            //Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListC4SortDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase4.workflow_state, caseListC4SortDoneAt[0].WorkflowState);

            #endregion



            #endregion

            #endregion

            #region aCase Sort Des

            #region aCase1 Sort Des

            #region caseListC1SortDescendingDoneAt aCase1

            Assert.NotNull(caseListC1SortDescendingDoneAt);
            Assert.AreEqual(0, caseListC1SortDescendingDoneAt.Count);
            //Assert.AreEqual(aCase1.type, caseListC1SortDescendingDoneAt[1].CaseType);
            //Assert.AreEqual(aCase1.case_uid, caseListC1SortDescendingDoneAt[1].CaseUId);
            //Assert.AreEqual(aCase1.microting_check_uid, caseListC1SortDescendingDoneAt[1].CheckUIid);
            //Assert.AreEqual(c1_ca.ToString(), caseListC1SortDescendingDoneAt[1].CreatedAt.ToString());
            //Assert.AreEqual(aCase1.custom, caseListC1SortDescendingDoneAt[1].Custom);
            //Assert.AreEqual(c1_da.ToString(), caseListC1SortDescendingDoneAt[1].DoneAt.ToString());
            //Assert.AreEqual(aCase1.id, caseListC1SortDescendingDoneAt[1].Id);
            //Assert.AreEqual(aCase1.microting_uid, caseListC1SortDescendingDoneAt[1].MicrotingUId);
            //Assert.AreEqual(aCase1.site.microting_uid, caseListC1SortDescendingDoneAt[1].SiteId);
            //Assert.AreEqual(aCase1.site.name, caseListC1SortDescendingDoneAt[1].SiteName);
            //Assert.AreEqual(aCase1.status, caseListC1SortDescendingDoneAt[1].Status);
            //Assert.AreEqual(aCase1.check_list_id, caseListC1SortDescendingDoneAt[1].TemplatId);
            //Assert.AreEqual(aCase1.unit.microting_uid, caseListC1SortDescendingDoneAt[1].UnitId);
            //Assert.AreEqual(c1_ua.ToString(), caseListC1SortDescendingDoneAt[1].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1.version, caseListC1SortDescendingDoneAt[1].Version);
            //Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListC1SortDescendingDoneAt[1].WorkerName);
            //Assert.AreEqual(aCase1.workflow_state, caseListC1SortDescendingDoneAt[1].WorkflowState);

            #endregion

            #region caseListC1SortDescendingStatus aCase1

            Assert.NotNull(caseListC1SortDescendingStatus);
            Assert.AreEqual(0, caseListC1SortDescendingStatus.Count);
            //Assert.AreEqual(aCase1.type, caseListC1SortDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase1.case_uid, caseListC1SortDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase1.microting_check_uid, caseListC1SortDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c1_ca.ToString(), caseListC1SortDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1.custom, caseListC1SortDescendingStatus[0].Custom);
            //Assert.AreEqual(c1_da.ToString(), caseListC1SortDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1.id, caseListC1SortDescendingStatus[0].Id);
            //Assert.AreEqual(aCase1.microting_uid, caseListC1SortDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase1.site.microting_uid, caseListC1SortDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase1.site.name, caseListC1SortDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase1.status, caseListC1SortDescendingStatus[0].Status);
            //Assert.AreEqual(aCase1.check_list_id, caseListC1SortDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase1.unit.microting_uid, caseListC1SortDescendingStatus[0].UnitId);
            //Assert.AreEqual(c1_ua.ToString(), caseListC1SortDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1.version, caseListC1SortDescendingStatus[0].Version);
            //Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListC1SortDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase1.workflow_state, caseListC1SortDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListC1SortDescendingUnitId aCase1

            Assert.NotNull(caseListC1SortDescendingUnitId);
            Assert.AreEqual(0, caseListC1SortDescendingUnitId.Count);
            //Assert.AreEqual(aCase1.type, caseListC1SortDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase1.case_uid, caseListC1SortDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase1.microting_check_uid, caseListC1SortDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c1_ca.ToString(), caseListC1SortDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1.custom, caseListC1SortDescendingUnitId[0].Custom);
            //Assert.AreEqual(c1_da.ToString(), caseListC1SortDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1.id, caseListC1SortDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase1.microting_uid, caseListC1SortDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase1.site.microting_uid, caseListC1SortDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase1.site.name, caseListC1SortDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase1.status, caseListC1SortDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase1.check_list_id, caseListC1SortDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase1.unit.microting_uid, caseListC1SortDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c1_ua.ToString(), caseListC1SortDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1.version, caseListC1SortDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListC1SortDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase1.workflow_state, caseListC1SortDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase2 Sort Des
            #region caseListC2SortDescendingDoneAt aCase2

            Assert.NotNull(caseListC2SortDescendingDoneAt);
            Assert.AreEqual(0, caseListC2SortDescendingDoneAt.Count);
            //Assert.AreEqual(aCase2.type, caseListC2SortDescendingDoneAt[3].CaseType);
            //Assert.AreEqual(aCase2.case_uid, caseListC2SortDescendingDoneAt[3].CaseUId);
            //Assert.AreEqual(aCase2.microting_check_uid, caseListC2SortDescendingDoneAt[3].CheckUIid);
            //Assert.AreEqual(c2_ca.ToString(), caseListC2SortDescendingDoneAt[3].CreatedAt.ToString());
            //Assert.AreEqual(aCase2.custom, caseListC2SortDescendingDoneAt[3].Custom);
            //Assert.AreEqual(c2_da.ToString(), caseListC2SortDescendingDoneAt[3].DoneAt.ToString());
            //Assert.AreEqual(aCase2.id, caseListC2SortDescendingDoneAt[3].Id);
            //Assert.AreEqual(aCase2.microting_uid, caseListC2SortDescendingDoneAt[3].MicrotingUId);
            //Assert.AreEqual(aCase2.site.microting_uid, caseListC2SortDescendingDoneAt[3].SiteId);
            //Assert.AreEqual(aCase2.site.name, caseListC2SortDescendingDoneAt[3].SiteName);
            //Assert.AreEqual(aCase2.status, caseListC2SortDescendingDoneAt[3].Status);
            //Assert.AreEqual(aCase2.check_list_id, caseListC2SortDescendingDoneAt[3].TemplatId);
            //Assert.AreEqual(aCase2.unit.microting_uid, caseListC2SortDescendingDoneAt[3].UnitId);
            //Assert.AreEqual(c2_ua.ToString(), caseListC2SortDescendingDoneAt[3].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2.version, caseListC2SortDescendingDoneAt[3].Version);
            //Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListC2SortDescendingDoneAt[3].WorkerName);
            //Assert.AreEqual(aCase2.workflow_state, caseListC2SortDescendingDoneAt[3].WorkflowState);

            #endregion

            #region caseListC2SortDescendingStatus aCase2

            Assert.NotNull(caseListC2SortDescendingStatus);
            Assert.AreEqual(0, caseListC2SortDescendingStatus.Count);
            //Assert.AreEqual(aCase2.type, caseListC2SortDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase2.case_uid, caseListC2SortDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase2.microting_check_uid, caseListC2SortDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c2_ca.ToString(), caseListC2SortDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2.custom, caseListC2SortDescendingStatus[0].Custom);
            //Assert.AreEqual(c2_da.ToString(), caseListC2SortDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2.id, caseListC2SortDescendingStatus[0].Id);
            //Assert.AreEqual(aCase2.microting_uid, caseListC2SortDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase2.site.microting_uid, caseListC2SortDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase2.site.name, caseListC2SortDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase2.status, caseListC2SortDescendingStatus[0].Status);
            //Assert.AreEqual(aCase2.check_list_id, caseListC2SortDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase2.unit.microting_uid, caseListC2SortDescendingStatus[0].UnitId);
            //Assert.AreEqual(c2_ua.ToString(), caseListC2SortDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2.version, caseListC2SortDescendingStatus[0].Version);
            //Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListC2SortDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase2.workflow_state, caseListC2SortDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListC2SortDescendingUnitId aCase2

            Assert.NotNull(caseListC2SortDescendingUnitId);
            Assert.AreEqual(0, caseListC2SortDescendingUnitId.Count);
            //Assert.AreEqual(aCase2.type, caseListC2SortDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase2.case_uid, caseListC2SortDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase2.microting_check_uid, caseListC2SortDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c2_ca.ToString(), caseListC2SortDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2.custom, caseListC2SortDescendingUnitId[0].Custom);
            //Assert.AreEqual(c2_da.ToString(), caseListC2SortDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2.id, caseListC2SortDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase2.microting_uid, caseListC2SortDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase2.site.microting_uid, caseListC2SortDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase2.site.name, caseListC2SortDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase2.status, caseListC2SortDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase2.check_list_id, caseListC2SortDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase2.unit.microting_uid, caseListC2SortDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c2_ua.ToString(), caseListC2SortDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2.version, caseListC2SortDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListC2SortDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase2.workflow_state, caseListC2SortDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase3 Sort Des
            #region caseListC3SortDescendingDoneAt aCase3

            Assert.NotNull(caseListC3SortDescendingDoneAt);
            Assert.AreEqual(0, caseListC3SortDescendingDoneAt.Count);
            //Assert.AreEqual(aCase3.type, caseListC3SortDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase3.case_uid, caseListC3SortDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase3.microting_check_uid, caseListC3SortDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c3_ca.ToString(), caseListC3SortDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3.custom, caseListC3SortDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c3_da.ToString(), caseListC3SortDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3.id, caseListC3SortDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase3.microting_uid, caseListC3SortDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase3.site.microting_uid, caseListC3SortDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase3.site.name, caseListC3SortDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase3.status, caseListC3SortDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase3.check_list_id, caseListC3SortDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase3.unit.microting_uid, caseListC3SortDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c3_ua.ToString(), caseListC3SortDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3.version, caseListC3SortDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListC3SortDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase3.workflow_state, caseListC3SortDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListC3SortDescendingStatus aCase3

            Assert.NotNull(caseListC3SortDescendingStatus);
            Assert.AreEqual(0, caseListC3SortDescendingStatus.Count);
            //Assert.AreEqual(aCase3.type, caseListC3SortDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase3.case_uid, caseListC3SortDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase3.microting_check_uid, caseListC3SortDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c3_ca.ToString(), caseListC3SortDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3.custom, caseListC3SortDescendingStatus[0].Custom);
            //Assert.AreEqual(c3_da.ToString(), caseListC3SortDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3.id, caseListC3SortDescendingStatus[0].Id);
            //Assert.AreEqual(aCase3.microting_uid, caseListC3SortDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase3.site.microting_uid, caseListC3SortDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase3.site.name, caseListC3SortDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase3.status, caseListC3SortDescendingStatus[0].Status);
            //Assert.AreEqual(aCase3.check_list_id, caseListC3SortDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase3.unit.microting_uid, caseListC3SortDescendingStatus[0].UnitId);
            //Assert.AreEqual(c3_ua.ToString(), caseListC3SortDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3.version, caseListC3SortDescendingStatus[0].Version);
            //Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListC3SortDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase3.workflow_state, caseListC3SortDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListC3SortDescendingUnitId aCase3

            Assert.NotNull(caseListC3SortDescendingUnitId);
            Assert.AreEqual(0, caseListC3SortDescendingUnitId.Count);
            //Assert.AreEqual(aCase3.type, caseListC3SortDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase3.case_uid, caseListC3SortDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase3.microting_check_uid, caseListC3SortDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c3_ca.ToString(), caseListC3SortDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3.custom, caseListC3SortDescendingUnitId[0].Custom);
            //Assert.AreEqual(c3_da.ToString(), caseListC3SortDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3.id, caseListC3SortDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase3.microting_uid, caseListC3SortDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase3.site.microting_uid, caseListC3SortDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase3.site.name, caseListC3SortDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase3.status, caseListC3SortDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase3.check_list_id, caseListC3SortDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase3.unit.microting_uid, caseListC3SortDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c3_ua.ToString(), caseListC3SortDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3.version, caseListC3SortDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListC3SortDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase3.workflow_state, caseListC3SortDescendingUnitId[0].WorkflowState);

            #endregion

            #endregion

            #region aCase4 Sort Des
            #region caseListC4SortDescendingDoneAt aCase4

            Assert.NotNull(caseListC4SortDescendingDoneAt);
            Assert.AreEqual(0, caseListC4SortDescendingDoneAt.Count);
            //Assert.AreEqual(aCase4.type, caseListC4SortDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase4.case_uid, caseListC4SortDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase4.microting_check_uid, caseListC4SortDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c4_ca.ToString(), caseListC4SortDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4.custom, caseListC4SortDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c4_da.ToString(), caseListC4SortDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4.id, caseListC4SortDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase4.microting_uid, caseListC4SortDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase4.site.microting_uid, caseListC4SortDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase4.site.name, caseListC4SortDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase4.status, caseListC4SortDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase4.check_list_id, caseListC4SortDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase4.unit.microting_uid, caseListC4SortDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c4_ua.ToString(), caseListC4SortDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4.version, caseListC4SortDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListC4SortDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase4.workflow_state, caseListC4SortDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListC4SortDescendingStatus aCase4

            Assert.NotNull(caseListC4SortDescendingStatus);
            Assert.AreEqual(0, caseListC4SortDescendingStatus.Count);
            //Assert.AreEqual(aCase4.type, caseListC4SortDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase4.case_uid, caseListC4SortDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase4.microting_check_uid, caseListC4SortDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c4_ca.ToString(), caseListC4SortDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4.custom, caseListC4SortDescendingStatus[0].Custom);
            //Assert.AreEqual(c4_da.ToString(), caseListC4SortDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4.id, caseListC4SortDescendingStatus[0].Id);
            //Assert.AreEqual(aCase4.microting_uid, caseListC4SortDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase4.site.microting_uid, caseListC4SortDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase4.site.name, caseListC4SortDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase4.status, caseListC4SortDescendingStatus[0].Status);
            //Assert.AreEqual(aCase4.check_list_id, caseListC4SortDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase4.unit.microting_uid, caseListC4SortDescendingStatus[0].UnitId);
            //Assert.AreEqual(c4_ua.ToString(), caseListC4SortDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4.version, caseListC4SortDescendingStatus[0].Version);
            //Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListC4SortDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase4.workflow_state, caseListC4SortDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListC4SortDescendingUnitId aCase4

            Assert.NotNull(caseListC4SortDescendingUnitId);
            Assert.AreEqual(0, caseListC4SortDescendingUnitId.Count);
            //Assert.AreEqual(aCase4.type, caseListC4SortDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase4.case_uid, caseListC4SortDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase4.microting_check_uid, caseListC4SortDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c4_ca.ToString(), caseListC4SortDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4.custom, caseListC4SortDescendingUnitId[0].Custom);
            //Assert.AreEqual(c4_da.ToString(), caseListC4SortDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4.id, caseListC4SortDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase4.microting_uid, caseListC4SortDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase4.site.microting_uid, caseListC4SortDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase4.site.name, caseListC4SortDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase4.status, caseListC4SortDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase4.check_list_id, caseListC4SortDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase4.unit.microting_uid, caseListC4SortDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c4_ua.ToString(), caseListC4SortDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4.version, caseListC4SortDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListC4SortDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase4.workflow_state, caseListC4SortDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion
            #endregion

            #region aCase Sort Asc w. DateTime

            #region aCase1 sort asc w. DateTime

            #region caseListC1SortDtDoneAt aCase1
            Assert.NotNull(caseListC1SortDtDoneAt);
            Assert.AreEqual(0, caseListC1SortDtDoneAt.Count);
            //Assert.AreEqual(aCase1.type, caseListC1SortDtDoneAt[0].CaseType);
            //Assert.AreEqual(aCase1.case_uid, caseListC1SortDtDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase1.microting_check_uid, caseListC1SortDtDoneAt[0].CheckUIid);
            //Assert.AreEqual(c1_ca.ToString(), caseListC1SortDtDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1.custom, caseListC1SortDtDoneAt[0].Custom);
            //Assert.AreEqual(c1_da.ToString(), caseListC1SortDtDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1.id, caseListC1SortDtDoneAt[0].Id);
            //Assert.AreEqual(aCase1.microting_uid, caseListC1SortDtDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase1.site.microting_uid, caseListC1SortDtDoneAt[0].SiteId);
            //Assert.AreEqual(aCase1.site.name, caseListC1SortDtDoneAt[0].SiteName);
            //Assert.AreEqual(aCase1.status, caseListC1SortDtDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListC1SortDtDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase1.unit.id, caseListC1SortDtDoneAt[0].UnitId);
            //Assert.AreEqual(c1_ua.ToString(), caseListC1SortDtDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1.version, caseListC1SortDtDoneAt[0].Version);
            //Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListC1SortDtDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase1.workflow_state, caseListC1SortDtDoneAt[0].WorkflowState);
            #endregion

            #region caseListC1SortDtStatus aCase1
            Assert.NotNull(caseListC1SortDtStatus);
            Assert.AreEqual(0, caseListC1SortDtStatus.Count);
            //Assert.AreEqual(aCase1.type, caseListC1SortDtStatus[0].CaseType);
            //Assert.AreEqual(aCase1.case_uid, caseListC1SortDtStatus[0].CaseUId);
            //Assert.AreEqual(aCase1.microting_check_uid, caseListC1SortDtStatus[0].CheckUIid);
            //Assert.AreEqual(c1_ca.ToString(), caseListC1SortDtStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1.custom, caseListC1SortDtStatus[0].Custom);
            //Assert.AreEqual(c1_da.ToString(), caseListC1SortDtStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1.id, caseListC1SortDtStatus[0].Id);
            //Assert.AreEqual(aCase1.microting_uid, caseListC1SortDtStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase1.site.microting_uid, caseListC1SortDtStatus[0].SiteId);
            //Assert.AreEqual(aCase1.site.name, caseListC1SortDtStatus[0].SiteName);
            //Assert.AreEqual(aCase1.status, caseListC1SortDtStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListC1SortDtStatus[0].TemplatId);
            //Assert.AreEqual(aCase1.unit.id, caseListC1SortDtStatus[0].UnitId);
            //Assert.AreEqual(c1_ua.ToString(), caseListC1SortDtStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1.version, caseListC1SortDtStatus[0].Version);
            //Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListC1SortDtStatus[0].WorkerName);
            //Assert.AreEqual(aCase1.workflow_state, caseListC1SortDtStatus[0].WorkflowState);
            #endregion

            #region caseListC1SortDtUnitId aCase1
            Assert.NotNull(caseListC1SortDtUnitId);
            Assert.AreEqual(0, caseListC1SortDtUnitId.Count);
            //Assert.AreEqual(aCase1.type, caseListC1SortDtUnitId[0].CaseType);
            //Assert.AreEqual(aCase1.case_uid, caseListC1SortDtUnitId[0].CaseUId);
            //Assert.AreEqual(aCase1.microting_check_uid, caseListC1SortDtUnitId[0].CheckUIid);
            //Assert.AreEqual(c1_ca.ToString(), caseListC1SortDtUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1.custom, caseListC1SortDtUnitId[0].Custom);
            //Assert.AreEqual(c1_da.ToString(), caseListC1SortDtUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1.id, caseListC1SortDtUnitId[0].Id);
            //Assert.AreEqual(aCase1.microting_uid, caseListC1SortDtUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase1.site.microting_uid, caseListC1SortDtUnitId[0].SiteId);
            //Assert.AreEqual(aCase1.site.name, caseListC1SortDtUnitId[0].SiteName);
            //Assert.AreEqual(aCase1.status, caseListC1SortDtUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListC1SortDtUnitId[0].TemplatId);
            //Assert.AreEqual(aCase1.unit.id, caseListC1SortDtUnitId[0].UnitId);
            //Assert.AreEqual(c1_ua.ToString(), caseListC1SortDtUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1.version, caseListC1SortDtUnitId[0].Version);
            //Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListC1SortDtUnitId[0].WorkerName);
            //Assert.AreEqual(aCase1.workflow_state, caseListC1SortDtUnitId[0].WorkflowState);
            #endregion

            #endregion

            #region aCase2 sort asc w. DateTime

            #region caseListC2SortDtDoneAt aCase2
            Assert.NotNull(caseListC2SortDtDoneAt);
            Assert.AreEqual(0, caseListC2SortDtDoneAt.Count);
            //Assert.AreEqual(aCase2.type, caseListC2SortDtDoneAt[0].CaseType);
            //Assert.AreEqual(aCase2.case_uid, caseListC2SortDtDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase2.microting_check_uid, caseListC2SortDtDoneAt[0].CheckUIid);
            //Assert.AreEqual(c2_ca.ToString(), caseListC2SortDtDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2.custom, caseListC2SortDtDoneAt[0].Custom);
            //Assert.AreEqual(c2_da.ToString(), caseListC2SortDtDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2.id, caseListC2SortDtDoneAt[0].Id);
            //Assert.AreEqual(aCase2.microting_uid, caseListC2SortDtDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase2.site.microting_uid, caseListC2SortDtDoneAt[0].SiteId);
            //Assert.AreEqual(aCase2.site.name, caseListC2SortDtDoneAt[0].SiteName);
            //Assert.AreEqual(aCase2.status, caseListC2SortDtDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListC2SortDtDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase2.unit.id, caseListC2SortDtDoneAt[0].UnitId);
            //Assert.AreEqual(c2_ua.ToString(), caseListC2SortDtDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2.version, caseListC2SortDtDoneAt[0].Version);
            //Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListC2SortDtDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase2.workflow_state, caseListC2SortDtDoneAt[0].WorkflowState);
            #endregion

            #region caseListC2SortDtStatus aCase2
            Assert.NotNull(caseListC2SortDtStatus);
            Assert.AreEqual(0, caseListC2SortDtStatus.Count);
            //Assert.AreEqual(aCase2.type, caseListC2SortDtStatus[0].CaseType);
            //Assert.AreEqual(aCase2.case_uid, caseListC2SortDtStatus[0].CaseUId);
            //Assert.AreEqual(aCase2.microting_check_uid, caseListC2SortDtStatus[0].CheckUIid);
            //Assert.AreEqual(c2_ca.ToString(), caseListC2SortDtStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2.custom, caseListC2SortDtStatus[0].Custom);
            //Assert.AreEqual(c2_da.ToString(), caseListC2SortDtStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2.id, caseListC2SortDtStatus[0].Id);
            //Assert.AreEqual(aCase2.microting_uid, caseListC2SortDtStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase2.site.microting_uid, caseListC2SortDtStatus[0].SiteId);
            //Assert.AreEqual(aCase2.site.name, caseListC2SortDtStatus[0].SiteName);
            //Assert.AreEqual(aCase2.status, caseListC2SortDtStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListC2SortDtStatus[0].TemplatId);
            //Assert.AreEqual(aCase2.unit.id, caseListC2SortDtStatus[0].UnitId);
            //Assert.AreEqual(c2_ua.ToString(), caseListC2SortDtStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2.version, caseListC2SortDtStatus[0].Version);
            //Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListC2SortDtStatus[0].WorkerName);
            //Assert.AreEqual(aCase2.workflow_state, caseListC2SortDtStatus[0].WorkflowState);
            #endregion

            #region caseListC2SortDtUnitId aCase2
            Assert.NotNull(caseListC2SortDtUnitId);
            Assert.AreEqual(0, caseListC2SortDtUnitId.Count);
            //Assert.AreEqual(aCase2.type, caseListC2SortDtUnitId[0].CaseType);
            //Assert.AreEqual(aCase2.case_uid, caseListC2SortDtUnitId[0].CaseUId);
            //Assert.AreEqual(aCase2.microting_check_uid, caseListC2SortDtUnitId[0].CheckUIid);
            //Assert.AreEqual(c2_ca.ToString(), caseListC2SortDtUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2.custom, caseListC2SortDtUnitId[0].Custom);
            //Assert.AreEqual(c2_da.ToString(), caseListC2SortDtUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2.id, caseListC2SortDtUnitId[0].Id);
            //Assert.AreEqual(aCase2.microting_uid, caseListC2SortDtUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase2.site.microting_uid, caseListC2SortDtUnitId[0].SiteId);
            //Assert.AreEqual(aCase2.site.name, caseListC2SortDtUnitId[0].SiteName);
            //Assert.AreEqual(aCase2.status, caseListC2SortDtUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListC2SortDtUnitId[0].TemplatId);
            //Assert.AreEqual(aCase2.unit.id, caseListC2SortDtUnitId[0].UnitId);
            //Assert.AreEqual(c2_ua.ToString(), caseListC2SortDtUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2.version, caseListC2SortDtUnitId[0].Version);
            //Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListC2SortDtUnitId[0].WorkerName);
            //Assert.AreEqual(aCase2.workflow_state, caseListC2SortDtUnitId[0].WorkflowState);
            #endregion

            #endregion

            #region aCase3 sort asc w. DateTime

            #region caseListC3SortDtDoneAt aCase3
            Assert.NotNull(caseListC3SortDtDoneAt);
            Assert.AreEqual(0, caseListC3SortDtDoneAt.Count);
            //Assert.AreEqual(aCase3.type, caseListC3SortDtDoneAt[0].CaseType);
            //Assert.AreEqual(aCase3.case_uid, caseListC3SortDtDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase3.microting_check_uid, caseListC3SortDtDoneAt[0].CheckUIid);
            //Assert.AreEqual(c3_ca.ToString(), caseListC3SortDtDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3.custom, caseListC3SortDtDoneAt[0].Custom);
            //Assert.AreEqual(c3_da.ToString(), caseListC3SortDtDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3.id, caseListC3SortDtDoneAt[0].Id);
            //Assert.AreEqual(aCase3.microting_uid, caseListC3SortDtDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase3.site.microting_uid, caseListC3SortDtDoneAt[0].SiteId);
            //Assert.AreEqual(aCase3.site.name, caseListC3SortDtDoneAt[0].SiteName);
            //Assert.AreEqual(aCase3.status, caseListC3SortDtDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListC3SortDtDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase3.unit.id, caseListC3SortDtDoneAt[0].UnitId);
            //Assert.AreEqual(c3_ua.ToString(), caseListC3SortDtDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3.version, caseListC3SortDtDoneAt[0].Version);
            //Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListC3SortDtDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase3.workflow_state, caseListC3SortDtDoneAt[0].WorkflowState);
            #endregion

            #region caseListC3SortDtStatus aCase3
            Assert.NotNull(caseListC3SortDtStatus);
            Assert.AreEqual(0, caseListC3SortDtStatus.Count);
            //Assert.AreEqual(aCase3.type, caseListC3SortDtStatus[0].CaseType);
            //Assert.AreEqual(aCase3.case_uid, caseListC3SortDtStatus[0].CaseUId);
            //Assert.AreEqual(aCase3.microting_check_uid, caseListC3SortDtStatus[0].CheckUIid);
            //Assert.AreEqual(c3_ca.ToString(), caseListC3SortDtStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3.custom, caseListC3SortDtStatus[0].Custom);
            //Assert.AreEqual(c3_da.ToString(), caseListC3SortDtStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3.id, caseListC3SortDtStatus[0].Id);
            //Assert.AreEqual(aCase3.microting_uid, caseListC3SortDtStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase3.site.microting_uid, caseListC3SortDtStatus[0].SiteId);
            //Assert.AreEqual(aCase3.site.name, caseListC3SortDtStatus[0].SiteName);
            //Assert.AreEqual(aCase3.status, caseListC3SortDtStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListC3SortDtStatus[0].TemplatId);
            //Assert.AreEqual(aCase3.unit.id, caseListC3SortDtStatus[0].UnitId);
            //Assert.AreEqual(c3_ua.ToString(), caseListC3SortDtStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3.version, caseListC3SortDtStatus[0].Version);
            //Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListC3SortDtStatus[0].WorkerName);
            //Assert.AreEqual(aCase3.workflow_state, caseListC3SortDtStatus[0].WorkflowState);
            #endregion

            #region caseListC3SortDtUnitId aCase3
            Assert.NotNull(caseListC3SortDtUnitId);
            Assert.AreEqual(0, caseListC3SortDtUnitId.Count);
            //Assert.AreEqual(aCase3.type, caseListC3SortDtUnitId[0].CaseType);
            //Assert.AreEqual(aCase3.case_uid, caseListC3SortDtUnitId[0].CaseUId);
            //Assert.AreEqual(aCase3.microting_check_uid, caseListC3SortDtUnitId[0].CheckUIid);
            //Assert.AreEqual(c3_ca.ToString(), caseListC3SortDtUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3.custom, caseListC3SortDtUnitId[0].Custom);
            //Assert.AreEqual(c3_da.ToString(), caseListC3SortDtUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3.id, caseListC3SortDtUnitId[0].Id);
            //Assert.AreEqual(aCase3.microting_uid, caseListC3SortDtUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase3.site.microting_uid, caseListC3SortDtUnitId[0].SiteId);
            //Assert.AreEqual(aCase3.site.name, caseListC3SortDtUnitId[0].SiteName);
            //Assert.AreEqual(aCase3.status, caseListC3SortDtUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListC3SortDtUnitId[0].TemplatId);
            //Assert.AreEqual(aCase3.unit.id, caseListC3SortDtUnitId[0].UnitId);
            //Assert.AreEqual(c3_ua.ToString(), caseListC3SortDtUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3.version, caseListC3SortDtUnitId[0].Version);
            //Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListC3SortDtUnitId[0].WorkerName);
            //Assert.AreEqual(aCase3.workflow_state, caseListC3SortDtUnitId[0].WorkflowState);
            #endregion


            #endregion

            #region aCase4 sort asc w. DateTime

            #region caseListC4SortDtDoneAt aCase4
            Assert.NotNull(caseListC4SortDtDoneAt);
            Assert.AreEqual(0, caseListC4SortDtDoneAt.Count);
            //Assert.AreEqual(aCase4.type, caseListC4SortDtDoneAt[0].CaseType);
            //Assert.AreEqual(aCase4.case_uid, caseListC4SortDtDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase4.microting_check_uid, caseListC4SortDtDoneAt[0].CheckUIid);
            //Assert.AreEqual(c4_ca.ToString(), caseListC4SortDtDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4.custom, caseListC4SortDtDoneAt[0].Custom);
            //Assert.AreEqual(c4_da.ToString(), caseListC4SortDtDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4.id, caseListC4SortDtDoneAt[0].Id);
            //Assert.AreEqual(aCase4.microting_uid, caseListC4SortDtDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase4.site.microting_uid, caseListC4SortDtDoneAt[0].SiteId);
            //Assert.AreEqual(aCase4.site.name, caseListC4SortDtDoneAt[0].SiteName);
            //Assert.AreEqual(aCase4.status, caseListC4SortDtDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListC4SortDtDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase4.unit.id, caseListC4SortDtDoneAt[0].UnitId);
            //Assert.AreEqual(c4_ua.ToString(), caseListC4SortDtDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4.version, caseListC4SortDtDoneAt[0].Version);
            //Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListC4SortDtDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase4.workflow_state, caseListC4SortDtDoneAt[0].WorkflowState);
            #endregion

            #region caseListC4SortDtStatus aCase4
            Assert.NotNull(caseListC4SortDtStatus);
            Assert.AreEqual(0, caseListC4SortDtStatus.Count);
            //Assert.AreEqual(aCase4.type, caseListC4SortDtStatus[0].CaseType);
            //Assert.AreEqual(aCase4.case_uid, caseListC4SortDtStatus[0].CaseUId);
            //Assert.AreEqual(aCase4.microting_check_uid, caseListC4SortDtStatus[0].CheckUIid);
            //Assert.AreEqual(c4_ca.ToString(), caseListC4SortDtStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4.custom, caseListC4SortDtStatus[0].Custom);
            //Assert.AreEqual(c4_da.ToString(), caseListC4SortDtStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4.id, caseListC4SortDtStatus[0].Id);
            //Assert.AreEqual(aCase4.microting_uid, caseListC4SortDtStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase4.site.microting_uid, caseListC4SortDtStatus[0].SiteId);
            //Assert.AreEqual(aCase4.site.name, caseListC4SortDtStatus[0].SiteName);
            //Assert.AreEqual(aCase4.status, caseListC4SortDtStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListC4SortDtStatus[0].TemplatId);
            //Assert.AreEqual(aCase4.unit.id, caseListC4SortDtStatus[0].UnitId);
            //Assert.AreEqual(c4_ua.ToString(), caseListC4SortDtStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4.version, caseListC4SortDtStatus[0].Version);
            //Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListC4SortDtStatus[0].WorkerName);
            //Assert.AreEqual(aCase4.workflow_state, caseListC4SortDtStatus[0].WorkflowState);
            #endregion

            #region caseListC4SortDtUnitId aCase4
            Assert.NotNull(caseListC4SortDtUnitId);
            Assert.AreEqual(0, caseListC4SortDtUnitId.Count);
            //Assert.AreEqual(aCase4.type, caseListC4SortDtUnitId[0].CaseType);
            //Assert.AreEqual(aCase4.case_uid, caseListC4SortDtUnitId[0].CaseUId);
            //Assert.AreEqual(aCase4.microting_check_uid, caseListC4SortDtUnitId[0].CheckUIid);
            //Assert.AreEqual(c4_ca.ToString(), caseListC4SortDtUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4.custom, caseListC4SortDtUnitId[0].Custom);
            //Assert.AreEqual(c4_da.ToString(), caseListC4SortDtUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4.id, caseListC4SortDtUnitId[0].Id);
            //Assert.AreEqual(aCase4.microting_uid, caseListC4SortDtUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase4.site.microting_uid, caseListC4SortDtUnitId[0].SiteId);
            //Assert.AreEqual(aCase4.site.name, caseListC4SortDtUnitId[0].SiteName);
            //Assert.AreEqual(aCase4.status, caseListC4SortDtUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListC4SortDtUnitId[0].TemplatId);
            //Assert.AreEqual(aCase4.unit.id, caseListC4SortDtUnitId[0].UnitId);
            //Assert.AreEqual(c4_ua.ToString(), caseListC4SortDtUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4.version, caseListC4SortDtUnitId[0].Version);
            //Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListC4SortDtUnitId[0].WorkerName);
            //Assert.AreEqual(aCase4.workflow_state, caseListC4SortDtUnitId[0].WorkflowState);
            #endregion



            #endregion

            #endregion

            #region aCase Sort Des w. DateTime
            #region aCase1 Sort Des w. DateTime
            #region caseListC1SortDtDescendingDoneAt aCase1

            Assert.NotNull(caseListC1SortDtDescendingDoneAt);
            Assert.AreEqual(0, caseListC1SortDtDescendingDoneAt.Count);
            //Assert.AreEqual(aCase1.type, caseListC1SortDtDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase1.case_uid, caseListC1SortDtDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase1.microting_check_uid, caseListC1SortDtDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c1_ca.ToString(), caseListC1SortDtDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1.custom, caseListC1SortDtDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c1_da.ToString(), caseListC1SortDtDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1.id, caseListC1SortDtDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase1.microting_uid, caseListC1SortDtDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase1.site.microting_uid, caseListC1SortDtDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase1.site.name, caseListC1SortDtDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase1.status, caseListC1SortDtDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase1.check_list_id, caseListC1SortDtDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase1.unit.microting_uid, caseListC1SortDtDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c1_ua.ToString(), caseListC1SortDtDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1.version, caseListC1SortDtDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListC1SortDtDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase1.workflow_state, caseListC1SortDtDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListC1SortDtDescendingStatus aCase1

            Assert.NotNull(caseListC1SortDtDescendingStatus);
            Assert.AreEqual(0, caseListC1SortDtDescendingStatus.Count);
            //Assert.AreEqual(aCase1.type, caseListC1SortDtDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase1.case_uid, caseListC1SortDtDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase1.microting_check_uid, caseListC1SortDtDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c1_ca.ToString(), caseListC1SortDtDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1.custom, caseListC1SortDtDescendingStatus[0].Custom);
            //Assert.AreEqual(c1_da.ToString(), caseListC1SortDtDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1.id, caseListC1SortDtDescendingStatus[0].Id);
            //Assert.AreEqual(aCase1.microting_uid, caseListC1SortDtDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase1.site.microting_uid, caseListC1SortDtDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase1.site.name, caseListC1SortDtDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase1.status, caseListC1SortDtDescendingStatus[0].Status);
            //Assert.AreEqual(aCase1.check_list_id, caseListC1SortDtDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase1.unit.microting_uid, caseListC1SortDtDescendingStatus[0].UnitId);
            //Assert.AreEqual(c1_ua.ToString(), caseListC1SortDtDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1.version, caseListC1SortDtDescendingStatus[0].Version);
            //Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListC1SortDtDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase1.workflow_state, caseListC1SortDtDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListC1SortDtDescendingUnitId aCase1

            Assert.NotNull(caseListC1SortDtDescendingUnitId);
            Assert.AreEqual(0, caseListC1SortDtDescendingUnitId.Count);
            //Assert.AreEqual(aCase1.type, caseListC1SortDtDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase1.case_uid, caseListC1SortDtDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase1.microting_check_uid, caseListC1SortDtDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c1_ca.ToString(), caseListC1SortDtDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1.custom, caseListC1SortDtDescendingUnitId[0].Custom);
            //Assert.AreEqual(c1_da.ToString(), caseListC1SortDtDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1.id, caseListC1SortDtDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase1.microting_uid, caseListC1SortDtDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase1.site.microting_uid, caseListC1SortDtDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase1.site.name, caseListC1SortDtDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase1.status, caseListC1SortDtDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase1.check_list_id, caseListC1SortDtDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase1.unit.microting_uid, caseListC1SortDtDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c1_ua.ToString(), caseListC1SortDtDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1.version, caseListC1SortDtDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase1.worker.first_name + " " + aCase1.worker.last_name, caseListC1SortDtDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase1.workflow_state, caseListC1SortDtDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase2 Sort Des w. DateTime
            #region caseListC2SortDtDescendingDoneAt aCase2

            Assert.NotNull(caseListC2SortDtDescendingDoneAt);
            Assert.AreEqual(0, caseListC2SortDtDescendingDoneAt.Count);
            //Assert.AreEqual(aCase2.type, caseListC2SortDtDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase2.case_uid, caseListC2SortDtDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase2.microting_check_uid, caseListC2SortDtDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c2_ca.ToString(), caseListC2SortDtDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2.custom, caseListC2SortDtDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c2_da.ToString(), caseListC2SortDtDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2.id, caseListC2SortDtDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase2.microting_uid, caseListC2SortDtDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase2.site.microting_uid, caseListC2SortDtDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase2.site.name, caseListC2SortDtDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase2.status, caseListC2SortDtDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase2.check_list_id, caseListC2SortDtDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase2.unit.microting_uid, caseListC2SortDtDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c2_ua.ToString(), caseListC2SortDtDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2.version, caseListC2SortDtDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListC2SortDtDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase2.workflow_state, caseListC2SortDtDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListC2SortDtDescendingStatus aCase2

            Assert.NotNull(caseListC2SortDtDescendingStatus);
            Assert.AreEqual(0, caseListC2SortDtDescendingStatus.Count);
            //Assert.AreEqual(aCase2.type, caseListC2SortDtDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase2.case_uid, caseListC2SortDtDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase2.microting_check_uid, caseListC2SortDtDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c2_ca.ToString(), caseListC2SortDtDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2.custom, caseListC2SortDtDescendingStatus[0].Custom);
            //Assert.AreEqual(c2_da.ToString(), caseListC2SortDtDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2.id, caseListC2SortDtDescendingStatus[0].Id);
            //Assert.AreEqual(aCase2.microting_uid, caseListC2SortDtDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase2.site.microting_uid, caseListC2SortDtDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase2.site.name, caseListC2SortDtDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase2.status, caseListC2SortDtDescendingStatus[0].Status);
            //Assert.AreEqual(aCase2.check_list_id, caseListC2SortDtDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase2.unit.microting_uid, caseListC2SortDtDescendingStatus[0].UnitId);
            //Assert.AreEqual(c2_ua.ToString(), caseListC2SortDtDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2.version, caseListC2SortDtDescendingStatus[0].Version);
            //Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListC2SortDtDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase2.workflow_state, caseListC2SortDtDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListC2SortDtDescendingUnitId aCase2

            Assert.NotNull(caseListC2SortDtDescendingUnitId);
            Assert.AreEqual(0, caseListC2SortDtDescendingUnitId.Count);
            //Assert.AreEqual(aCase2.type, caseListC2SortDtDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase2.case_uid, caseListC2SortDtDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase2.microting_check_uid, caseListC2SortDtDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c2_ca.ToString(), caseListC2SortDtDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2.custom, caseListC2SortDtDescendingUnitId[0].Custom);
            //Assert.AreEqual(c2_da.ToString(), caseListC2SortDtDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2.id, caseListC2SortDtDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase2.microting_uid, caseListC2SortDtDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase2.site.microting_uid, caseListC2SortDtDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase2.site.name, caseListC2SortDtDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase2.status, caseListC2SortDtDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase2.check_list_id, caseListC2SortDtDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase2.unit.microting_uid, caseListC2SortDtDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c2_ua.ToString(), caseListC2SortDtDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2.version, caseListC2SortDtDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase2.worker.first_name + " " + aCase2.worker.last_name, caseListC2SortDtDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase2.workflow_state, caseListC2SortDtDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase3 Sort Des w. DateTime
            #region caseListC3SortDtDescendingDoneAt aCase3

            Assert.NotNull(caseListC3SortDtDescendingDoneAt);
            Assert.AreEqual(0, caseListC3SortDtDescendingDoneAt.Count);
            //Assert.AreEqual(aCase3.type, caseListC3SortDtDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase3.case_uid, caseListC3SortDtDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase3.microting_check_uid, caseListC3SortDtDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c3_ca.ToString(), caseListC3SortDtDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3.custom, caseListC3SortDtDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c3_da.ToString(), caseListC3SortDtDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3.id, caseListC3SortDtDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase3.microting_uid, caseListC3SortDtDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase3.site.microting_uid, caseListC3SortDtDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase3.site.name, caseListC3SortDtDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase3.status, caseListC3SortDtDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase3.check_list_id, caseListC3SortDtDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase3.unit.microting_uid, caseListC3SortDtDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c3_ua.ToString(), caseListC3SortDtDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3.version, caseListC3SortDtDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListC3SortDtDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase3.workflow_state, caseListC3SortDtDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListC3SortDtDescendingStatus aCase3

            Assert.NotNull(caseListC3SortDtDescendingStatus);
            Assert.AreEqual(0, caseListC3SortDtDescendingStatus.Count);
            //Assert.AreEqual(aCase3.type, caseListC3SortDtDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase3.case_uid, caseListC3SortDtDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase3.microting_check_uid, caseListC3SortDtDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c3_ca.ToString(), caseListC3SortDtDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3.custom, caseListC3SortDtDescendingStatus[0].Custom);
            //Assert.AreEqual(c3_da.ToString(), caseListC3SortDtDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3.id, caseListC3SortDtDescendingStatus[0].Id);
            //Assert.AreEqual(aCase3.microting_uid, caseListC3SortDtDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase3.site.microting_uid, caseListC3SortDtDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase3.site.name, caseListC3SortDtDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase3.status, caseListC3SortDtDescendingStatus[0].Status);
            //Assert.AreEqual(aCase3.check_list_id, caseListC3SortDtDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase3.unit.microting_uid, caseListC3SortDtDescendingStatus[0].UnitId);
            //Assert.AreEqual(c3_ua.ToString(), caseListC3SortDtDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3.version, caseListC3SortDtDescendingStatus[0].Version);
            //Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListC3SortDtDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase3.workflow_state, caseListC3SortDtDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListC3SortDtDescendingUnitId aCase3

            Assert.NotNull(caseListC3SortDtDescendingUnitId);
            Assert.AreEqual(0, caseListC3SortDtDescendingUnitId.Count);
            //Assert.AreEqual(aCase3.type, caseListC3SortDtDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase3.case_uid, caseListC3SortDtDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase3.microting_check_uid, caseListC3SortDtDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c3_ca.ToString(), caseListC3SortDtDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3.custom, caseListC3SortDtDescendingUnitId[0].Custom);
            //Assert.AreEqual(c3_da.ToString(), caseListC3SortDtDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3.id, caseListC3SortDtDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase3.microting_uid, caseListC3SortDtDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase3.site.microting_uid, caseListC3SortDtDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase3.site.name, caseListC3SortDtDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase3.status, caseListC3SortDtDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase3.check_list_id, caseListC3SortDtDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase3.unit.microting_uid, caseListC3SortDtDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c3_ua.ToString(), caseListC3SortDtDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3.version, caseListC3SortDtDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase3.worker.first_name + " " + aCase3.worker.last_name, caseListC3SortDtDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase3.workflow_state, caseListC3SortDtDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase4 Sort Des w. DateTime
            #region caseListC4SortDtDescendingDoneAt aCase4

            Assert.NotNull(caseListC4SortDtDescendingDoneAt);
            Assert.AreEqual(0, caseListC4SortDtDescendingDoneAt.Count);
            //Assert.AreEqual(aCase4.type, caseListC4SortDtDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase4.case_uid, caseListC4SortDtDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase4.microting_check_uid, caseListC4SortDtDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c4_ca.ToString(), caseListC4SortDtDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4.custom, caseListC4SortDtDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c4_da.ToString(), caseListC4SortDtDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4.id, caseListC4SortDtDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase4.microting_uid, caseListC4SortDtDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase4.site.microting_uid, caseListC4SortDtDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase4.site.name, caseListC4SortDtDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase4.status, caseListC4SortDtDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase4.check_list_id, caseListC4SortDtDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase4.unit.microting_uid, caseListC4SortDtDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c4_ua.ToString(), caseListC4SortDtDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4.version, caseListC4SortDtDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListC4SortDtDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase4.workflow_state, caseListC4SortDtDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListC4SortDtDescendingStatus aCase4

            Assert.NotNull(caseListC4SortDtDescendingStatus);
            Assert.AreEqual(0, caseListC4SortDtDescendingStatus.Count);
            //Assert.AreEqual(aCase4.type, caseListC4SortDtDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase4.case_uid, caseListC4SortDtDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase4.microting_check_uid, caseListC4SortDtDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c4_ca.ToString(), caseListC4SortDtDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4.custom, caseListC4SortDtDescendingStatus[0].Custom);
            //Assert.AreEqual(c4_da.ToString(), caseListC4SortDtDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4.id, caseListC4SortDtDescendingStatus[0].Id);
            //Assert.AreEqual(aCase4.microting_uid, caseListC4SortDtDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase4.site.microting_uid, caseListC4SortDtDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase4.site.name, caseListC4SortDtDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase4.status, caseListC4SortDtDescendingStatus[0].Status);
            //Assert.AreEqual(aCase4.check_list_id, caseListC4SortDtDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase4.unit.microting_uid, caseListC4SortDtDescendingStatus[0].UnitId);
            //Assert.AreEqual(c4_ua.ToString(), caseListC4SortDtDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4.version, caseListC4SortDtDescendingStatus[0].Version);
            //Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListC4SortDtDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase4.workflow_state, caseListC4SortDtDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListC4SortDtDescendingUnitId aCase4

            Assert.NotNull(caseListC4SortDtDescendingUnitId);
            Assert.AreEqual(0, caseListC4SortDtDescendingUnitId.Count);
            //Assert.AreEqual(aCase4.type, caseListC4SortDtDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase4.case_uid, caseListC4SortDtDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase4.microting_check_uid, caseListC4SortDtDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c4_ca.ToString(), caseListC4SortDtDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4.custom, caseListC4SortDtDescendingUnitId[0].Custom);
            //Assert.AreEqual(c4_da.ToString(), caseListC4SortDtDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4.id, caseListC4SortDtDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase4.microting_uid, caseListC4SortDtDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase4.site.microting_uid, caseListC4SortDtDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase4.site.name, caseListC4SortDtDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase4.status, caseListC4SortDtDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase4.check_list_id, caseListC4SortDtDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase4.unit.microting_uid, caseListC4SortDtDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c4_ua.ToString(), caseListC4SortDtDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4.version, caseListC4SortDtDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase4.worker.first_name + " " + aCase4.worker.last_name, caseListC4SortDtDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase4.workflow_state, caseListC4SortDtDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #endregion

            #endregion

            #endregion

            #region sort by WorkflowState removed

            #region Def Sort
            #region Def Sort Asc
            #region caseListRemovedDoneAt Def Sort Asc
            #region caseListRemovedDoneAt aCase1Removed
            Assert.NotNull(caseListRemovedDoneAt);
            Assert.AreEqual(4, caseListRemovedDoneAt.Count);
            Assert.AreEqual(aCase1Removed.type, caseListRemovedDoneAt[1].CaseType);
            Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedDoneAt[1].CaseUId);
            Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedDoneAt[1].CheckUIid);
            Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedDoneAt[1].CreatedAt.ToString());
            Assert.AreEqual(aCase1Removed.custom, caseListRemovedDoneAt[1].Custom);
            Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedDoneAt[1].DoneAt.ToString());
            Assert.AreEqual(aCase1Removed.id, caseListRemovedDoneAt[1].Id);
            Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedDoneAt[1].MicrotingUId);
            Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedDoneAt[1].SiteId);
            Assert.AreEqual(aCase1Removed.site.name, caseListRemovedDoneAt[1].SiteName);
            Assert.AreEqual(aCase1Removed.status, caseListRemovedDoneAt[1].Status);
            Assert.AreEqual(cl1.id, caseListRemovedDoneAt[1].TemplatId);
            Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedDoneAt[1].UnitId);
            Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedDoneAt[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Removed.version, caseListRemovedDoneAt[1].Version);
            Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedDoneAt[1].WorkerName);
            Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedDoneAt[1].WorkflowState);
            #endregion

            #region caseListRemovedDoneAt aCase2Removed
            Assert.AreEqual(aCase2Removed.type, caseListRemovedDoneAt[3].CaseType);
            Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedDoneAt[3].CaseUId);
            Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedDoneAt[3].CheckUIid);
            Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedDoneAt[3].CreatedAt.ToString());
            Assert.AreEqual(aCase2Removed.custom, caseListRemovedDoneAt[3].Custom);
            Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedDoneAt[3].DoneAt.ToString());
            Assert.AreEqual(aCase2Removed.id, caseListRemovedDoneAt[3].Id);
            Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedDoneAt[3].MicrotingUId);
            Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedDoneAt[3].SiteId);
            Assert.AreEqual(aCase2Removed.site.name, caseListRemovedDoneAt[3].SiteName);
            Assert.AreEqual(aCase2Removed.status, caseListRemovedDoneAt[3].Status);
            Assert.AreEqual(cl1.id, caseListRemovedDoneAt[3].TemplatId);
            Assert.AreEqual(aCase2Removed.unit.microting_uid, caseListRemovedDoneAt[3].UnitId);
            Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedDoneAt[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase2Removed.version, caseListRemovedDoneAt[3].Version);
            Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedDoneAt[3].WorkerName);
            Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedDoneAt[3].WorkflowState);
            #endregion

            #region caseListRemovedDoneAt aCase3Removed
            Assert.AreEqual(aCase3Removed.type, caseListRemovedDoneAt[0].CaseType);
            Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedDoneAt[0].CaseUId);
            Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedDoneAt[0].CheckUIid);
            Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedDoneAt[0].CreatedAt.ToString());
            Assert.AreEqual(aCase3Removed.custom, caseListRemovedDoneAt[0].Custom);
            Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedDoneAt[0].DoneAt.ToString());
            Assert.AreEqual(aCase3Removed.id, caseListRemovedDoneAt[0].Id);
            Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedDoneAt[0].MicrotingUId);
            Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedDoneAt[0].SiteId);
            Assert.AreEqual(aCase3Removed.site.name, caseListRemovedDoneAt[0].SiteName);
            Assert.AreEqual(aCase3Removed.status, caseListRemovedDoneAt[0].Status);
            Assert.AreEqual(cl1.id, caseListRemovedDoneAt[0].TemplatId);
            Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedDoneAt[0].UnitId);
            Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedDoneAt[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Removed.version, caseListRemovedDoneAt[0].Version);
            Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedDoneAt[0].WorkerName);
            Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedDoneAt[0].WorkflowState);
            #endregion

            #region caseListRemovedDoneAt aCase4Removed
            Assert.AreEqual(aCase4Removed.type, caseListRemovedDoneAt[2].CaseType);
            Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedDoneAt[2].CaseUId);
            Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedDoneAt[2].CheckUIid);
            Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedDoneAt[2].CreatedAt.ToString());
            Assert.AreEqual(aCase4Removed.custom, caseListRemovedDoneAt[2].Custom);
            Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedDoneAt[2].DoneAt.ToString());
            Assert.AreEqual(aCase4Removed.id, caseListRemovedDoneAt[2].Id);
            Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedDoneAt[2].MicrotingUId);
            Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedDoneAt[2].SiteId);
            Assert.AreEqual(aCase4Removed.site.name, caseListRemovedDoneAt[2].SiteName);
            Assert.AreEqual(aCase4Removed.status, caseListRemovedDoneAt[2].Status);
            Assert.AreEqual(cl1.id, caseListRemovedDoneAt[2].TemplatId);
            Assert.AreEqual(aCase4Removed.unit.microting_uid, caseListRemovedDoneAt[2].UnitId);
            Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedDoneAt[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase4Removed.version, caseListRemovedDoneAt[2].Version);
            Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedDoneAt[2].WorkerName);
            Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedDoneAt[2].WorkflowState);
            #endregion

            #endregion

            #region caseListRemovedStatus Def Sort Asc

            #region caseListRemovedStatus aCase1Removed

            Assert.NotNull(caseListRemovedStatus);
            Assert.AreEqual(4, caseListRemovedStatus.Count);
            Assert.AreEqual(aCase1Removed.type, caseListRemovedStatus[0].CaseType);
            Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedStatus[0].CaseUId);
            Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedStatus[0].CheckUIid);
            Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedStatus[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1Removed.custom, caseListRemovedStatus[0].Custom);
            Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedStatus[0].DoneAt.ToString());
            Assert.AreEqual(aCase1Removed.id, caseListRemovedStatus[0].Id);
            Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedStatus[0].MicrotingUId);
            Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedStatus[0].SiteId);
            Assert.AreEqual(aCase1Removed.site.name, caseListRemovedStatus[0].SiteName);
            Assert.AreEqual(aCase1Removed.status, caseListRemovedStatus[0].Status);
            Assert.AreEqual(aCase1Removed.check_list_id, caseListRemovedStatus[0].TemplatId);
            Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedStatus[0].UnitId);
            Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedStatus[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Removed.version, caseListRemovedStatus[0].Version);
            Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedStatus[0].WorkerName);
            Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedStatus[0].WorkflowState);

            #endregion

            #region caseListRemovedStatus aCase2Removed

            Assert.AreEqual(aCase2Removed.type, caseListRemovedStatus[1].CaseType);
            Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedStatus[1].CaseUId);
            Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedStatus[1].CheckUIid);
            Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedStatus[1].CreatedAt.ToString());
            Assert.AreEqual(aCase2Removed.custom, caseListRemovedStatus[1].Custom);
            Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedStatus[1].DoneAt.ToString());
            Assert.AreEqual(aCase2Removed.id, caseListRemovedStatus[1].Id);
            Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedStatus[1].MicrotingUId);
            Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedStatus[1].SiteId);
            Assert.AreEqual(aCase2Removed.site.name, caseListRemovedStatus[1].SiteName);
            Assert.AreEqual(aCase2Removed.status, caseListRemovedStatus[1].Status);
            Assert.AreEqual(aCase2Removed.check_list_id, caseListRemovedStatus[1].TemplatId);
            Assert.AreEqual(aCase2Removed.unit.microting_uid, caseListRemovedStatus[1].UnitId);
            Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedStatus[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase2Removed.version, caseListRemovedStatus[1].Version);
            Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedStatus[1].WorkerName);
            Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedStatus[1].WorkflowState);

            #endregion

            #region caseListRemovedStatus aCase3Removed

            Assert.AreEqual(aCase3Removed.type, caseListRemovedStatus[2].CaseType);
            Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedStatus[2].CaseUId);
            Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedStatus[2].CheckUIid);
            Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedStatus[2].CreatedAt.ToString());
            Assert.AreEqual(aCase3Removed.custom, caseListRemovedStatus[2].Custom);
            Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedStatus[2].DoneAt.ToString());
            Assert.AreEqual(aCase3Removed.id, caseListRemovedStatus[2].Id);
            Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedStatus[2].MicrotingUId);
            Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedStatus[2].SiteId);
            Assert.AreEqual(aCase3Removed.site.name, caseListRemovedStatus[2].SiteName);
            Assert.AreEqual(aCase3Removed.status, caseListRemovedStatus[2].Status);
            Assert.AreEqual(aCase3Removed.check_list_id, caseListRemovedStatus[2].TemplatId);
            Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedStatus[2].UnitId);
            Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedStatus[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Removed.version, caseListRemovedStatus[2].Version);
            Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedStatus[2].WorkerName);
            Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedStatus[2].WorkflowState);

            #endregion

            #region caseListRemovedStatus aCase4Removed

            Assert.AreEqual(aCase4Removed.type, caseListRemovedStatus[3].CaseType);
            Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedStatus[3].CaseUId);
            Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedStatus[3].CheckUIid);
            Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedStatus[3].CreatedAt.ToString());
            Assert.AreEqual(aCase4Removed.custom, caseListRemovedStatus[3].Custom);
            Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedStatus[3].DoneAt.ToString());
            Assert.AreEqual(aCase4Removed.id, caseListRemovedStatus[3].Id);
            Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedStatus[3].MicrotingUId);
            Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedStatus[3].SiteId);
            Assert.AreEqual(aCase4Removed.site.name, caseListRemovedStatus[3].SiteName);
            Assert.AreEqual(aCase4Removed.status, caseListRemovedStatus[3].Status);
            Assert.AreEqual(aCase4Removed.check_list_id, caseListRemovedStatus[3].TemplatId);
            Assert.AreEqual(aCase4Removed.unit.microting_uid, caseListRemovedStatus[3].UnitId);
            Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedStatus[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase4Removed.version, caseListRemovedStatus[3].Version);
            Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedStatus[3].WorkerName);
            Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedStatus[3].WorkflowState);

            #endregion

            #endregion

            #region caseListRemovedUnitId Def Sort Asc

            #region caseListRemovedUnitId aCase1Removed
            Assert.NotNull(caseListRemovedUnitId);
            Assert.AreEqual(4, caseListRemovedUnitId.Count);
            Assert.AreEqual(aCase1Removed.type, caseListRemovedUnitId[0].CaseType);
            Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedUnitId[0].CaseUId);
            Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedUnitId[0].CheckUIid);
            Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedUnitId[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1Removed.custom, caseListRemovedUnitId[0].Custom);
            Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedUnitId[0].DoneAt.ToString());
            Assert.AreEqual(aCase1Removed.id, caseListRemovedUnitId[0].Id);
            Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedUnitId[0].MicrotingUId);
            Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedUnitId[0].SiteId);
            Assert.AreEqual(aCase1Removed.site.name, caseListRemovedUnitId[0].SiteName);
            Assert.AreEqual(aCase1Removed.status, caseListRemovedUnitId[0].Status);
            Assert.AreEqual(aCase1Removed.check_list_id, caseListRemovedUnitId[0].TemplatId);
            Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedUnitId[0].UnitId);
            Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedUnitId[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Removed.version, caseListRemovedUnitId[0].Version);
            Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedUnitId[0].WorkerName);
            Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedUnitId[0].WorkflowState);

            #endregion

            #region caseListRemovedUnitId aCase2Removed
            Assert.AreEqual(aCase2Removed.type, caseListRemovedUnitId[1].CaseType);
            Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedUnitId[1].CaseUId);
            Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedUnitId[1].CheckUIid);
            Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedUnitId[1].CreatedAt.ToString());
            Assert.AreEqual(aCase2Removed.custom, caseListRemovedUnitId[1].Custom);
            Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedUnitId[1].DoneAt.ToString());
            Assert.AreEqual(aCase2Removed.id, caseListRemovedUnitId[1].Id);
            Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedUnitId[1].MicrotingUId);
            Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedUnitId[1].SiteId);
            Assert.AreEqual(aCase2Removed.site.name, caseListRemovedUnitId[1].SiteName);
            Assert.AreEqual(aCase2Removed.status, caseListRemovedUnitId[1].Status);
            Assert.AreEqual(aCase2Removed.check_list_id, caseListRemovedUnitId[1].TemplatId);
            Assert.AreEqual(aCase2Removed.unit.microting_uid, caseListRemovedUnitId[1].UnitId);
            Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedUnitId[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase2Removed.version, caseListRemovedUnitId[1].Version);
            Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedUnitId[1].WorkerName);
            Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedUnitId[1].WorkflowState);

            #endregion

            #region caseListRemovedUnitId aCase3Removed
            Assert.AreEqual(aCase3Removed.type, caseListRemovedUnitId[2].CaseType);
            Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedUnitId[2].CaseUId);
            Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedUnitId[2].CheckUIid);
            Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedUnitId[2].CreatedAt.ToString());
            Assert.AreEqual(aCase3Removed.custom, caseListRemovedUnitId[2].Custom);
            Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedUnitId[2].DoneAt.ToString());
            Assert.AreEqual(aCase3Removed.id, caseListRemovedUnitId[2].Id);
            Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedUnitId[2].MicrotingUId);
            Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedUnitId[2].SiteId);
            Assert.AreEqual(aCase3Removed.site.name, caseListRemovedUnitId[2].SiteName);
            Assert.AreEqual(aCase3Removed.status, caseListRemovedUnitId[2].Status);
            Assert.AreEqual(aCase3Removed.check_list_id, caseListRemovedUnitId[2].TemplatId);
            Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedUnitId[2].UnitId);
            Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedUnitId[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Removed.version, caseListRemovedUnitId[2].Version);
            Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedUnitId[2].WorkerName);
            Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedUnitId[2].WorkflowState);

            #endregion

            #region caseListRemovedUnitId aCase4Removed
            Assert.AreEqual(aCase4Removed.type, caseListRemovedUnitId[3].CaseType);
            Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedUnitId[3].CaseUId);
            Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedUnitId[3].CheckUIid);
            Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedUnitId[3].CreatedAt.ToString());
            Assert.AreEqual(aCase4Removed.custom, caseListRemovedUnitId[3].Custom);
            Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedUnitId[3].DoneAt.ToString());
            Assert.AreEqual(aCase4Removed.id, caseListRemovedUnitId[3].Id);
            Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedUnitId[3].MicrotingUId);
            Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedUnitId[3].SiteId);
            Assert.AreEqual(aCase4Removed.site.name, caseListRemovedUnitId[3].SiteName);
            Assert.AreEqual(aCase4Removed.status, caseListRemovedUnitId[3].Status);
            Assert.AreEqual(aCase4Removed.check_list_id, caseListRemovedUnitId[3].TemplatId);
            Assert.AreEqual(aCase4Removed.unit.microting_uid, caseListRemovedUnitId[3].UnitId);
            Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedUnitId[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase4Removed.version, caseListRemovedUnitId[3].Version);
            Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedUnitId[3].WorkerName);
            Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedUnitId[3].WorkflowState);

            #endregion

            #endregion

            #endregion

            #region Def Sort Des
            #region caseListRemovedDescendingDoneAt Def Sort Des
            #region caseListRemovedDescendingDoneAt aCase1Removed
            Assert.NotNull(caseListRemovedDescendingDoneAt);
            Assert.AreEqual(4, caseListRemovedDescendingDoneAt.Count);
            Assert.AreEqual(aCase1Removed.type, caseListRemovedDescendingDoneAt[2].CaseType);
            Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedDescendingDoneAt[2].CaseUId);
            Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedDescendingDoneAt[2].CheckUIid);
            Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedDescendingDoneAt[2].CreatedAt.ToString());
            Assert.AreEqual(aCase1Removed.custom, caseListRemovedDescendingDoneAt[2].Custom);
            Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedDescendingDoneAt[2].DoneAt.ToString());
            Assert.AreEqual(aCase1Removed.id, caseListRemovedDescendingDoneAt[2].Id);
            Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedDescendingDoneAt[2].MicrotingUId);
            Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedDescendingDoneAt[2].SiteId);
            Assert.AreEqual(aCase1Removed.site.name, caseListRemovedDescendingDoneAt[2].SiteName);
            Assert.AreEqual(aCase1Removed.status, caseListRemovedDescendingDoneAt[2].Status);
            Assert.AreEqual(cl1.id, caseListRemovedDescendingDoneAt[2].TemplatId);
            Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedDescendingDoneAt[2].UnitId);
            Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedDescendingDoneAt[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Removed.version, caseListRemovedDescendingDoneAt[2].Version);
            Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedDescendingDoneAt[2].WorkerName);
            Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedDescendingDoneAt[2].WorkflowState);
            #endregion

            #region caseListRemovedDescendingDoneAt aCase2Removed
            Assert.AreEqual(aCase2Removed.type, caseListRemovedDescendingDoneAt[0].CaseType);
            Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedDescendingDoneAt[0].CaseUId);
            Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedDescendingDoneAt[0].CheckUIid);
            Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedDescendingDoneAt[0].CreatedAt.ToString());
            Assert.AreEqual(aCase2Removed.custom, caseListRemovedDescendingDoneAt[0].Custom);
            Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedDescendingDoneAt[0].DoneAt.ToString());
            Assert.AreEqual(aCase2Removed.id, caseListRemovedDescendingDoneAt[0].Id);
            Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedDescendingDoneAt[0].MicrotingUId);
            Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedDescendingDoneAt[0].SiteId);
            Assert.AreEqual(aCase2Removed.site.name, caseListRemovedDescendingDoneAt[0].SiteName);
            Assert.AreEqual(aCase2Removed.status, caseListRemovedDescendingDoneAt[0].Status);
            Assert.AreEqual(cl1.id, caseListRemovedDescendingDoneAt[0].TemplatId);
            Assert.AreEqual(aCase2Removed.unit.microting_uid, caseListRemovedDescendingDoneAt[0].UnitId);
            Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedDescendingDoneAt[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase2Removed.version, caseListRemovedDescendingDoneAt[0].Version);
            Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedDescendingDoneAt[0].WorkerName);
            Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedDescendingDoneAt[0].WorkflowState);
            #endregion

            #region caseListRemovedDescendingDoneAt aCase3Removed
            Assert.AreEqual(aCase3Removed.type, caseListRemovedDescendingDoneAt[3].CaseType);
            Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedDescendingDoneAt[3].CaseUId);
            Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedDescendingDoneAt[3].CheckUIid);
            Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedDescendingDoneAt[3].CreatedAt.ToString());
            Assert.AreEqual(aCase3Removed.custom, caseListRemovedDescendingDoneAt[3].Custom);
            Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedDescendingDoneAt[3].DoneAt.ToString());
            Assert.AreEqual(aCase3Removed.id, caseListRemovedDescendingDoneAt[3].Id);
            Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedDescendingDoneAt[3].MicrotingUId);
            Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedDescendingDoneAt[3].SiteId);
            Assert.AreEqual(aCase3Removed.site.name, caseListRemovedDescendingDoneAt[3].SiteName);
            Assert.AreEqual(aCase3Removed.status, caseListRemovedDescendingDoneAt[3].Status);
            Assert.AreEqual(cl1.id, caseListRemovedDescendingDoneAt[3].TemplatId);
            Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedDescendingDoneAt[3].UnitId);
            Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedDescendingDoneAt[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Removed.version, caseListRemovedDescendingDoneAt[3].Version);
            Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedDescendingDoneAt[3].WorkerName);
            Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedDescendingDoneAt[3].WorkflowState);
            #endregion

            #region caseListRemovedDescendingDoneAt aCase4Removed
            Assert.AreEqual(aCase4Removed.type, caseListRemovedDescendingDoneAt[1].CaseType);
            Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedDescendingDoneAt[1].CaseUId);
            Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedDescendingDoneAt[1].CheckUIid);
            Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedDescendingDoneAt[1].CreatedAt.ToString());
            Assert.AreEqual(aCase4Removed.custom, caseListRemovedDescendingDoneAt[1].Custom);
            Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedDescendingDoneAt[1].DoneAt.ToString());
            Assert.AreEqual(aCase4Removed.id, caseListRemovedDescendingDoneAt[1].Id);
            Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedDescendingDoneAt[1].MicrotingUId);
            Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedDescendingDoneAt[1].SiteId);
            Assert.AreEqual(aCase4Removed.site.name, caseListRemovedDescendingDoneAt[1].SiteName);
            Assert.AreEqual(aCase4Removed.status, caseListRemovedDescendingDoneAt[1].Status);
            Assert.AreEqual(cl1.id, caseListRemovedDescendingDoneAt[1].TemplatId);
            Assert.AreEqual(aCase4Removed.unit.microting_uid, caseListRemovedDescendingDoneAt[1].UnitId);
            Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedDescendingDoneAt[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase4Removed.version, caseListRemovedDescendingDoneAt[1].Version);
            Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedDescendingDoneAt[1].WorkerName);
            Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedDescendingDoneAt[1].WorkflowState);
            #endregion

            #endregion

            #region caseListRemovedDescendingStatus Def Sort Des

            #region caseListRemovedDescendingStatus aCase1Removed

            Assert.NotNull(caseListRemovedDescendingStatus);
            Assert.AreEqual(4, caseListRemovedDescendingStatus.Count);
            Assert.AreEqual(aCase1Removed.type, caseListRemovedDescendingStatus[3].CaseType);
            Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedDescendingStatus[3].CaseUId);
            Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedDescendingStatus[3].CheckUIid);
            Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedDescendingStatus[3].CreatedAt.ToString());
            Assert.AreEqual(aCase1Removed.custom, caseListRemovedDescendingStatus[3].Custom);
            Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedDescendingStatus[3].DoneAt.ToString());
            Assert.AreEqual(aCase1Removed.id, caseListRemovedDescendingStatus[3].Id);
            Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedDescendingStatus[3].MicrotingUId);
            Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedDescendingStatus[3].SiteId);
            Assert.AreEqual(aCase1Removed.site.name, caseListRemovedDescendingStatus[3].SiteName);
            Assert.AreEqual(aCase1Removed.status, caseListRemovedDescendingStatus[3].Status);
            Assert.AreEqual(aCase1Removed.check_list_id, caseListRemovedDescendingStatus[3].TemplatId);
            Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedDescendingStatus[3].UnitId);
            Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedDescendingStatus[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Removed.version, caseListRemovedDescendingStatus[3].Version);
            Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedDescendingStatus[3].WorkerName);
            Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedDescendingStatus[3].WorkflowState);

            #endregion

            #region caseListRemovedDescendingStatus aCase2Removed

            Assert.AreEqual(aCase2Removed.type, caseListRemovedDescendingStatus[2].CaseType);
            Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedDescendingStatus[2].CaseUId);
            Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedDescendingStatus[2].CheckUIid);
            Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedDescendingStatus[2].CreatedAt.ToString());
            Assert.AreEqual(aCase2Removed.custom, caseListRemovedDescendingStatus[2].Custom);
            Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedDescendingStatus[2].DoneAt.ToString());
            Assert.AreEqual(aCase2Removed.id, caseListRemovedDescendingStatus[2].Id);
            Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedDescendingStatus[2].MicrotingUId);
            Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedDescendingStatus[2].SiteId);
            Assert.AreEqual(aCase2Removed.site.name, caseListRemovedDescendingStatus[2].SiteName);
            Assert.AreEqual(aCase2Removed.status, caseListRemovedDescendingStatus[2].Status);
            Assert.AreEqual(aCase2Removed.check_list_id, caseListRemovedDescendingStatus[2].TemplatId);
            Assert.AreEqual(aCase2Removed.unit.microting_uid, caseListRemovedDescendingStatus[2].UnitId);
            Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedDescendingStatus[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase2Removed.version, caseListRemovedDescendingStatus[2].Version);
            Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedDescendingStatus[2].WorkerName);
            Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedDescendingStatus[2].WorkflowState);

            #endregion

            #region caseListRemovedDescendingStatus aCase3Removed

            Assert.AreEqual(aCase3Removed.type, caseListRemovedDescendingStatus[1].CaseType);
            Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedDescendingStatus[1].CaseUId);
            Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedDescendingStatus[1].CheckUIid);
            Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedDescendingStatus[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3Removed.custom, caseListRemovedDescendingStatus[1].Custom);
            Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedDescendingStatus[1].DoneAt.ToString());
            Assert.AreEqual(aCase3Removed.id, caseListRemovedDescendingStatus[1].Id);
            Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedDescendingStatus[1].MicrotingUId);
            Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedDescendingStatus[1].SiteId);
            Assert.AreEqual(aCase3Removed.site.name, caseListRemovedDescendingStatus[1].SiteName);
            Assert.AreEqual(aCase3Removed.status, caseListRemovedDescendingStatus[1].Status);
            Assert.AreEqual(aCase3Removed.check_list_id, caseListRemovedDescendingStatus[1].TemplatId);
            Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedDescendingStatus[1].UnitId);
            Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedDescendingStatus[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Removed.version, caseListRemovedDescendingStatus[1].Version);
            Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedDescendingStatus[1].WorkerName);
            Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedDescendingStatus[1].WorkflowState);

            #endregion

            #region caseListRemovedDescendingStatus aCase4Removed

            Assert.AreEqual(aCase4Removed.type, caseListRemovedDescendingStatus[0].CaseType);
            Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedDescendingStatus[0].CaseUId);
            Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedDescendingStatus[0].CheckUIid);
            Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedDescendingStatus[0].CreatedAt.ToString());
            Assert.AreEqual(aCase4Removed.custom, caseListRemovedDescendingStatus[0].Custom);
            Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedDescendingStatus[0].DoneAt.ToString());
            Assert.AreEqual(aCase4Removed.id, caseListRemovedDescendingStatus[0].Id);
            Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedDescendingStatus[0].MicrotingUId);
            Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedDescendingStatus[0].SiteId);
            Assert.AreEqual(aCase4Removed.site.name, caseListRemovedDescendingStatus[0].SiteName);
            Assert.AreEqual(aCase4Removed.status, caseListRemovedDescendingStatus[0].Status);
            Assert.AreEqual(aCase4Removed.check_list_id, caseListRemovedDescendingStatus[0].TemplatId);
            Assert.AreEqual(aCase4Removed.unit.microting_uid, caseListRemovedDescendingStatus[0].UnitId);
            Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedDescendingStatus[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase4Removed.version, caseListRemovedDescendingStatus[0].Version);
            Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedDescendingStatus[0].WorkerName);
            Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedDescendingStatus[0].WorkflowState);

            #endregion

            #endregion

            #region caseListRemovedDescendingUnitId Def Sort Des

            #region caseListRemovedDescendingUnitId aCase1Removed
            Assert.NotNull(caseListRemovedDescendingUnitId);
            Assert.AreEqual(4, caseListRemovedDescendingUnitId.Count);
            Assert.AreEqual(aCase1Removed.type, caseListRemovedDescendingUnitId[3].CaseType);
            Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedDescendingUnitId[3].CaseUId);
            Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedDescendingUnitId[3].CheckUIid);
            Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedDescendingUnitId[3].CreatedAt.ToString());
            Assert.AreEqual(aCase1Removed.custom, caseListRemovedDescendingUnitId[3].Custom);
            Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedDescendingUnitId[3].DoneAt.ToString());
            Assert.AreEqual(aCase1Removed.id, caseListRemovedDescendingUnitId[3].Id);
            Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedDescendingUnitId[3].MicrotingUId);
            Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedDescendingUnitId[3].SiteId);
            Assert.AreEqual(aCase1Removed.site.name, caseListRemovedDescendingUnitId[3].SiteName);
            Assert.AreEqual(aCase1Removed.status, caseListRemovedDescendingUnitId[3].Status);
            Assert.AreEqual(aCase1Removed.check_list_id, caseListRemovedDescendingUnitId[3].TemplatId);
            Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedDescendingUnitId[3].UnitId);
            Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedDescendingUnitId[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Removed.version, caseListRemovedDescendingUnitId[3].Version);
            Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedDescendingUnitId[3].WorkerName);
            Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedDescendingUnitId[3].WorkflowState);

            #endregion

            #region caseListRemovedDescendingUnitId aCase2Removed
            Assert.AreEqual(aCase2Removed.type, caseListRemovedDescendingUnitId[2].CaseType);
            Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedDescendingUnitId[2].CaseUId);
            Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedDescendingUnitId[2].CheckUIid);
            Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedDescendingUnitId[2].CreatedAt.ToString());
            Assert.AreEqual(aCase2Removed.custom, caseListRemovedDescendingUnitId[2].Custom);
            Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedDescendingUnitId[2].DoneAt.ToString());
            Assert.AreEqual(aCase2Removed.id, caseListRemovedDescendingUnitId[2].Id);
            Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedDescendingUnitId[2].MicrotingUId);
            Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedDescendingUnitId[2].SiteId);
            Assert.AreEqual(aCase2Removed.site.name, caseListRemovedDescendingUnitId[2].SiteName);
            Assert.AreEqual(aCase2Removed.status, caseListRemovedDescendingUnitId[2].Status);
            Assert.AreEqual(aCase2Removed.check_list_id, caseListRemovedDescendingUnitId[2].TemplatId);
            Assert.AreEqual(aCase2Removed.unit.microting_uid, caseListRemovedDescendingUnitId[2].UnitId);
            Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedDescendingUnitId[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase2Removed.version, caseListRemovedDescendingUnitId[2].Version);
            Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedDescendingUnitId[2].WorkerName);
            Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedDescendingUnitId[2].WorkflowState);

            #endregion

            #region caseListRemovedDescendingUnitId aCase3Removed
            Assert.AreEqual(aCase3Removed.type, caseListRemovedDescendingUnitId[1].CaseType);
            Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedDescendingUnitId[1].CaseUId);
            Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedDescendingUnitId[1].CheckUIid);
            Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedDescendingUnitId[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3Removed.custom, caseListRemovedDescendingUnitId[1].Custom);
            Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedDescendingUnitId[1].DoneAt.ToString());
            Assert.AreEqual(aCase3Removed.id, caseListRemovedDescendingUnitId[1].Id);
            Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedDescendingUnitId[1].MicrotingUId);
            Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedDescendingUnitId[1].SiteId);
            Assert.AreEqual(aCase3Removed.site.name, caseListRemovedDescendingUnitId[1].SiteName);
            Assert.AreEqual(aCase3Removed.status, caseListRemovedDescendingUnitId[1].Status);
            Assert.AreEqual(aCase3Removed.check_list_id, caseListRemovedDescendingUnitId[1].TemplatId);
            Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedDescendingUnitId[1].UnitId);
            Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedDescendingUnitId[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Removed.version, caseListRemovedDescendingUnitId[1].Version);
            Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedDescendingUnitId[1].WorkerName);
            Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedDescendingUnitId[1].WorkflowState);

            #endregion

            #region caseListRemovedDescendingUnitId aCase4Removed
            Assert.AreEqual(aCase4Removed.type, caseListRemovedDescendingUnitId[0].CaseType);
            Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedDescendingUnitId[0].CaseUId);
            Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedDescendingUnitId[0].CheckUIid);
            Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedDescendingUnitId[0].CreatedAt.ToString());
            Assert.AreEqual(aCase4Removed.custom, caseListRemovedDescendingUnitId[0].Custom);
            Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedDescendingUnitId[0].DoneAt.ToString());
            Assert.AreEqual(aCase4Removed.id, caseListRemovedDescendingUnitId[0].Id);
            Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedDescendingUnitId[0].MicrotingUId);
            Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedDescendingUnitId[0].SiteId);
            Assert.AreEqual(aCase4Removed.site.name, caseListRemovedDescendingUnitId[0].SiteName);
            Assert.AreEqual(aCase4Removed.status, caseListRemovedDescendingUnitId[0].Status);
            Assert.AreEqual(aCase4Removed.check_list_id, caseListRemovedDescendingUnitId[0].TemplatId);
            Assert.AreEqual(aCase4Removed.unit.microting_uid, caseListRemovedDescendingUnitId[0].UnitId);
            Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedDescendingUnitId[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase4Removed.version, caseListRemovedDescendingUnitId[0].Version);
            Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedDescendingUnitId[0].WorkerName);
            Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedDescendingUnitId[0].WorkflowState);

            #endregion

            #endregion

            #endregion

            #region Def Sort Asc w. DateTime


            #region caseListRemovedDtDoneAt Def Sort Asc w. DateTime
            #region caseListRemovedDtDoneAt aCase1Removed
            Assert.NotNull(caseListRemovedDtDoneAt);
            Assert.AreEqual(2, caseListRemovedDtDoneAt.Count);
            Assert.AreEqual(aCase1Removed.type, caseListRemovedDtDoneAt[1].CaseType);
            Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedDtDoneAt[1].CaseUId);
            Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedDtDoneAt[1].CheckUIid);
            Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedDtDoneAt[1].CreatedAt.ToString());
            Assert.AreEqual(aCase1Removed.custom, caseListRemovedDtDoneAt[1].Custom);
            Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedDtDoneAt[1].DoneAt.ToString());
            Assert.AreEqual(aCase1Removed.id, caseListRemovedDtDoneAt[1].Id);
            Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedDtDoneAt[1].MicrotingUId);
            Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedDtDoneAt[1].SiteId);
            Assert.AreEqual(aCase1Removed.site.name, caseListRemovedDtDoneAt[1].SiteName);
            Assert.AreEqual(aCase1Removed.status, caseListRemovedDtDoneAt[1].Status);
            Assert.AreEqual(cl1.id, caseListRemovedDtDoneAt[1].TemplatId);
            Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedDtDoneAt[1].UnitId);
            Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedDtDoneAt[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Removed.version, caseListRemovedDtDoneAt[1].Version);
            Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedDtDoneAt[1].WorkerName);
            Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedDtDoneAt[1].WorkflowState);
            #endregion

            #region caseListRemovedDtDoneAt aCase3Removed
            Assert.AreEqual(aCase3Removed.type, caseListRemovedDtDoneAt[0].CaseType);
            Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedDtDoneAt[0].CaseUId);
            Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedDtDoneAt[0].CheckUIid);
            Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedDtDoneAt[0].CreatedAt.ToString());
            Assert.AreEqual(aCase3Removed.custom, caseListRemovedDtDoneAt[0].Custom);
            Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedDtDoneAt[0].DoneAt.ToString());
            Assert.AreEqual(aCase3Removed.id, caseListRemovedDtDoneAt[0].Id);
            Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedDtDoneAt[0].MicrotingUId);
            Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedDtDoneAt[0].SiteId);
            Assert.AreEqual(aCase3Removed.site.name, caseListRemovedDtDoneAt[0].SiteName);
            Assert.AreEqual(aCase3Removed.status, caseListRemovedDtDoneAt[0].Status);
            Assert.AreEqual(cl1.id, caseListRemovedDtDoneAt[0].TemplatId);
            Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedDtDoneAt[0].UnitId);
            Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedDtDoneAt[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Removed.version, caseListRemovedDtDoneAt[0].Version);
            Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedDtDoneAt[0].WorkerName);
            Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedDtDoneAt[0].WorkflowState);
            #endregion


            #endregion

            #region caseListRemovedDtStatus Def Sort Asc w. DateTime

            #region caseListRemovedDtStatus aCase1Removed

            Assert.NotNull(caseListRemovedDtStatus);
            Assert.AreEqual(2, caseListRemovedDtStatus.Count);
            Assert.AreEqual(aCase1Removed.type, caseListRemovedDtStatus[0].CaseType);
            Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedDtStatus[0].CaseUId);
            Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedDtStatus[0].CheckUIid);
            Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedDtStatus[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1Removed.custom, caseListRemovedDtStatus[0].Custom);
            Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedDtStatus[0].DoneAt.ToString());
            Assert.AreEqual(aCase1Removed.id, caseListRemovedDtStatus[0].Id);
            Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedDtStatus[0].MicrotingUId);
            Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedDtStatus[0].SiteId);
            Assert.AreEqual(aCase1Removed.site.name, caseListRemovedDtStatus[0].SiteName);
            Assert.AreEqual(aCase1Removed.status, caseListRemovedDtStatus[0].Status);
            Assert.AreEqual(aCase1Removed.check_list_id, caseListRemovedDtStatus[0].TemplatId);
            Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedDtStatus[0].UnitId);
            Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedDtStatus[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Removed.version, caseListRemovedDtStatus[0].Version);
            Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedDtStatus[0].WorkerName);
            Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedDtStatus[0].WorkflowState);

            #endregion

            #region caseListRemovedDtStatus aCase3Removed

            Assert.AreEqual(aCase3Removed.type, caseListRemovedDtStatus[1].CaseType);
            Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedDtStatus[1].CaseUId);
            Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedDtStatus[1].CheckUIid);
            Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedDtStatus[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3Removed.custom, caseListRemovedDtStatus[1].Custom);
            Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedDtStatus[1].DoneAt.ToString());
            Assert.AreEqual(aCase3Removed.id, caseListRemovedDtStatus[1].Id);
            Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedDtStatus[1].MicrotingUId);
            Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedDtStatus[1].SiteId);
            Assert.AreEqual(aCase3Removed.site.name, caseListRemovedDtStatus[1].SiteName);
            Assert.AreEqual(aCase3Removed.status, caseListRemovedDtStatus[1].Status);
            Assert.AreEqual(aCase3Removed.check_list_id, caseListRemovedDtStatus[1].TemplatId);
            Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedDtStatus[1].UnitId);
            Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedDtStatus[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Removed.version, caseListRemovedDtStatus[1].Version);
            Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedDtStatus[1].WorkerName);
            Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedDtStatus[1].WorkflowState);

            #endregion



            #endregion

            #region caseListRemovedDtUnitId Def Sort Asc w. DateTime

            #region caseListRemovedDtUnitId aCase1Removed

            Assert.NotNull(caseListRemovedDtUnitId);
            Assert.AreEqual(2, caseListRemovedDtUnitId.Count);
            Assert.AreEqual(aCase1Removed.type, caseListRemovedDtUnitId[0].CaseType);
            Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedDtUnitId[0].CaseUId);
            Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedDtUnitId[0].CheckUIid);
            Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedDtUnitId[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1Removed.custom, caseListRemovedDtUnitId[0].Custom);
            Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedDtUnitId[0].DoneAt.ToString());
            Assert.AreEqual(aCase1Removed.id, caseListRemovedDtUnitId[0].Id);
            Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedDtUnitId[0].MicrotingUId);
            Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedDtUnitId[0].SiteId);
            Assert.AreEqual(aCase1Removed.site.name, caseListRemovedDtUnitId[0].SiteName);
            Assert.AreEqual(aCase1Removed.status, caseListRemovedDtUnitId[0].Status);
            Assert.AreEqual(aCase1Removed.check_list_id, caseListRemovedDtUnitId[0].TemplatId);
            Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedDtUnitId[0].UnitId);
            Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedDtUnitId[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Removed.version, caseListRemovedDtUnitId[0].Version);
            Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedDtUnitId[0].WorkerName);
            Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedDtUnitId[0].WorkflowState);

            #endregion



            #region caseListRemovedDtUnitId aCase3Removed

            Assert.AreEqual(aCase3Removed.type, caseListRemovedDtUnitId[1].CaseType);
            Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedDtUnitId[1].CaseUId);
            Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedDtUnitId[1].CheckUIid);
            Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedDtUnitId[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3Removed.custom, caseListRemovedDtUnitId[1].Custom);
            Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedDtUnitId[1].DoneAt.ToString());
            Assert.AreEqual(aCase3Removed.id, caseListRemovedDtUnitId[1].Id);
            Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedDtUnitId[1].MicrotingUId);
            Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedDtUnitId[1].SiteId);
            Assert.AreEqual(aCase3Removed.site.name, caseListRemovedDtUnitId[1].SiteName);
            Assert.AreEqual(aCase3Removed.status, caseListRemovedDtUnitId[1].Status);
            Assert.AreEqual(aCase3Removed.check_list_id, caseListRemovedDtUnitId[1].TemplatId);
            Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedDtUnitId[1].UnitId);
            Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedDtUnitId[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Removed.version, caseListRemovedDtUnitId[1].Version);
            Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedDtUnitId[1].WorkerName);
            Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedDtUnitId[1].WorkflowState);

            #endregion



            #endregion

            #endregion

            #region Def Sort Des w. DateTime
            #region caseListRemovedDtDescendingDoneAt Def Sort Des
            #region caseListRemovedDtDescendingDoneAt aCase1Removed

            Assert.NotNull(caseListRemovedDtDescendingDoneAt);
            Assert.AreEqual(2, caseListRemovedDtDescendingDoneAt.Count);
            Assert.AreEqual(aCase1Removed.type, caseListRemovedDtDescendingDoneAt[0].CaseType);
            Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedDtDescendingDoneAt[0].CaseUId);
            Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedDtDescendingDoneAt[0].CheckUIid);
            Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedDtDescendingDoneAt[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1Removed.custom, caseListRemovedDtDescendingDoneAt[0].Custom);
            Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedDtDescendingDoneAt[0].DoneAt.ToString());
            Assert.AreEqual(aCase1Removed.id, caseListRemovedDtDescendingDoneAt[0].Id);
            Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedDtDescendingDoneAt[0].MicrotingUId);
            Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedDtDescendingDoneAt[0].SiteId);
            Assert.AreEqual(aCase1Removed.site.name, caseListRemovedDtDescendingDoneAt[0].SiteName);
            Assert.AreEqual(aCase1Removed.status, caseListRemovedDtDescendingDoneAt[0].Status);
            Assert.AreEqual(cl1.id, caseListRemovedDtDescendingDoneAt[0].TemplatId);
            Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedDtDescendingDoneAt[0].UnitId);
            Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedDtDescendingDoneAt[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Removed.version, caseListRemovedDtDescendingDoneAt[0].Version);
            Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedDtDescendingDoneAt[0].WorkerName);
            Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedDtDescendingDoneAt[0].WorkflowState);
            #endregion

            #region caseListRemovedDtDescendingDoneAt aCase3Removed

            Assert.AreEqual(aCase3Removed.type, caseListRemovedDtDescendingDoneAt[1].CaseType);
            Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedDtDescendingDoneAt[1].CaseUId);
            Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedDtDescendingDoneAt[1].CheckUIid);
            Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedDtDescendingDoneAt[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3Removed.custom, caseListRemovedDtDescendingDoneAt[1].Custom);
            Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedDtDescendingDoneAt[1].DoneAt.ToString());
            Assert.AreEqual(aCase3Removed.id, caseListRemovedDtDescendingDoneAt[1].Id);
            Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedDtDescendingDoneAt[1].MicrotingUId);
            Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedDtDescendingDoneAt[1].SiteId);
            Assert.AreEqual(aCase3Removed.site.name, caseListRemovedDtDescendingDoneAt[1].SiteName);
            Assert.AreEqual(aCase3Removed.status, caseListRemovedDtDescendingDoneAt[1].Status);
            Assert.AreEqual(cl1.id, caseListRemovedDtDescendingDoneAt[1].TemplatId);
            Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedDtDescendingDoneAt[1].UnitId);
            Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedDtDescendingDoneAt[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Removed.version, caseListRemovedDtDescendingDoneAt[1].Version);
            Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedDtDescendingDoneAt[1].WorkerName);
            Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedDtDescendingDoneAt[1].WorkflowState);
            #endregion

            #endregion

            #region caseListRemovedDtDescendingStatus Def Sort Des

            #region caseListRemovedDtDescendingStatus aCase1Removed

            Assert.NotNull(caseListRemovedDtDescendingStatus);
            Assert.AreEqual(2, caseListRemovedDtDescendingStatus.Count);
            Assert.AreEqual(aCase1Removed.type, caseListRemovedDtDescendingStatus[1].CaseType);
            Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedDtDescendingStatus[1].CaseUId);
            Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedDtDescendingStatus[1].CheckUIid);
            Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedDtDescendingStatus[1].CreatedAt.ToString());
            Assert.AreEqual(aCase1Removed.custom, caseListRemovedDtDescendingStatus[1].Custom);
            Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedDtDescendingStatus[1].DoneAt.ToString());
            Assert.AreEqual(aCase1Removed.id, caseListRemovedDtDescendingStatus[1].Id);
            Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedDtDescendingStatus[1].MicrotingUId);
            Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedDtDescendingStatus[1].SiteId);
            Assert.AreEqual(aCase1Removed.site.name, caseListRemovedDtDescendingStatus[1].SiteName);
            Assert.AreEqual(aCase1Removed.status, caseListRemovedDtDescendingStatus[1].Status);
            Assert.AreEqual(aCase1Removed.check_list_id, caseListRemovedDtDescendingStatus[1].TemplatId);
            Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedDtDescendingStatus[1].UnitId);
            Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedDtDescendingStatus[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Removed.version, caseListRemovedDtDescendingStatus[1].Version);
            Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedDtDescendingStatus[1].WorkerName);
            Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedDtDescendingStatus[1].WorkflowState);

            #endregion



            #region caseListRemovedDtDescendingStatus aCase3Removed

            Assert.AreEqual(aCase3Removed.type, caseListRemovedDtDescendingStatus[0].CaseType);
            Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedDtDescendingStatus[0].CaseUId);
            Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedDtDescendingStatus[0].CheckUIid);
            Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedDtDescendingStatus[0].CreatedAt.ToString());
            Assert.AreEqual(aCase3Removed.custom, caseListRemovedDtDescendingStatus[0].Custom);
            Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedDtDescendingStatus[0].DoneAt.ToString());
            Assert.AreEqual(aCase3Removed.id, caseListRemovedDtDescendingStatus[0].Id);
            Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedDtDescendingStatus[0].MicrotingUId);
            Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedDtDescendingStatus[0].SiteId);
            Assert.AreEqual(aCase3Removed.site.name, caseListRemovedDtDescendingStatus[0].SiteName);
            Assert.AreEqual(aCase3Removed.status, caseListRemovedDtDescendingStatus[0].Status);
            Assert.AreEqual(aCase3Removed.check_list_id, caseListRemovedDtDescendingStatus[0].TemplatId);
            Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedDtDescendingStatus[0].UnitId);
            Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedDtDescendingStatus[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Removed.version, caseListRemovedDtDescendingStatus[0].Version);
            Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedDtDescendingStatus[0].WorkerName);
            Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedDtDescendingStatus[0].WorkflowState);

            #endregion



            #endregion

            #region caseListRemovedDtDescendingUnitId Def Sort Des

            #region caseListRemovedDtDescendingUnitId aCase1Removed
            Assert.NotNull(caseListRemovedDtDescendingUnitId);
            Assert.AreEqual(2, caseListRemovedDtDescendingUnitId.Count);

            Assert.AreEqual(aCase1Removed.type, caseListRemovedDtDescendingUnitId[1].CaseType);
            Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedDtDescendingUnitId[1].CaseUId);
            Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedDtDescendingUnitId[1].CheckUIid);
            Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedDtDescendingUnitId[1].CreatedAt.ToString());
            Assert.AreEqual(aCase1Removed.custom, caseListRemovedDtDescendingUnitId[1].Custom);
            Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedDtDescendingUnitId[1].DoneAt.ToString());
            Assert.AreEqual(aCase1Removed.id, caseListRemovedDtDescendingUnitId[1].Id);
            Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedDtDescendingUnitId[1].MicrotingUId);
            Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedDtDescendingUnitId[1].SiteId);
            Assert.AreEqual(aCase1Removed.site.name, caseListRemovedDtDescendingUnitId[1].SiteName);
            Assert.AreEqual(aCase1Removed.status, caseListRemovedDtDescendingUnitId[1].Status);
            Assert.AreEqual(aCase1Removed.check_list_id, caseListRemovedDtDescendingUnitId[1].TemplatId);
            Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedDtDescendingUnitId[1].UnitId);
            Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedDtDescendingUnitId[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Removed.version, caseListRemovedDtDescendingUnitId[1].Version);
            Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedDtDescendingUnitId[1].WorkerName);
            Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedDtDescendingUnitId[1].WorkflowState);

            #endregion



            #region caseListRemovedDtDescendingUnitId aCase3Removed
            Assert.AreEqual(aCase3Removed.type, caseListRemovedDtDescendingUnitId[0].CaseType);
            Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedDtDescendingUnitId[0].CaseUId);
            Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedDtDescendingUnitId[0].CheckUIid);
            Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedDtDescendingUnitId[0].CreatedAt.ToString());
            Assert.AreEqual(aCase3Removed.custom, caseListRemovedDtDescendingUnitId[0].Custom);
            Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedDtDescendingUnitId[0].DoneAt.ToString());
            Assert.AreEqual(aCase3Removed.id, caseListRemovedDtDescendingUnitId[0].Id);
            Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedDtDescendingUnitId[0].MicrotingUId);
            Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedDtDescendingUnitId[0].SiteId);
            Assert.AreEqual(aCase3Removed.site.name, caseListRemovedDtDescendingUnitId[0].SiteName);
            Assert.AreEqual(aCase3Removed.status, caseListRemovedDtDescendingUnitId[0].Status);
            Assert.AreEqual(aCase3Removed.check_list_id, caseListRemovedDtDescendingUnitId[0].TemplatId);
            Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedDtDescendingUnitId[0].UnitId);
            Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedDtDescendingUnitId[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Removed.version, caseListRemovedDtDescendingUnitId[0].Version);
            Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedDtDescendingUnitId[0].WorkerName);
            Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedDtDescendingUnitId[0].WorkflowState);

            #endregion



            #endregion

            #endregion

            #endregion

            #region Case Sort 

            #region aCase Sort Asc

            #region aCase1Removed sort asc

            #region caseListC1DoneAt aCase1Removed
            Assert.NotNull(caseListRemovedC1SortDoneAt);
            Assert.AreEqual(0, caseListRemovedC1SortDoneAt.Count);
            //Assert.AreEqual(aCase1Removed.type, caseListRemovedC1SortDoneAt[0].CaseType);
            //Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedC1SortDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedC1SortDoneAt[0].CheckUIid);
            //Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedC1SortDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.custom, caseListRemovedC1SortDoneAt[0].Custom);
            //Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedC1SortDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Removed.id, caseListRemovedC1SortDoneAt[0].Id);
            //Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedC1SortDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedC1SortDoneAt[0].SiteId);
            //Assert.AreEqual(aCase1Removed.site.name, caseListRemovedC1SortDoneAt[0].SiteName);
            //Assert.AreEqual(aCase1Removed.status, caseListRemovedC1SortDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC1SortDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase1Removed.unit.id, caseListRemovedC1SortDoneAt[0].UnitId);
            //Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedC1SortDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.version, caseListRemovedC1SortDoneAt[0].Version);
            //Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedC1SortDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedC1SortDoneAt[0].WorkflowState);
            #endregion

            #region caseListRemovedC1SortStatus aCase1Removed
            Assert.NotNull(caseListRemovedC1SortStatus);
            Assert.AreEqual(0, caseListRemovedC1SortStatus.Count);
            //Assert.AreEqual(aCase1Removed.type, caseListRemovedC1SortStatus[0].CaseType);
            //Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedC1SortStatus[0].CaseUId);
            //Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedC1SortStatus[0].CheckUIid);
            //Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedC1SortStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.custom, caseListRemovedC1SortStatus[0].Custom);
            //Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedC1SortStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Removed.id, caseListRemovedC1SortStatus[0].Id);
            //Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedC1SortStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedC1SortStatus[0].SiteId);
            //Assert.AreEqual(aCase1Removed.site.name, caseListRemovedC1SortStatus[0].SiteName);
            //Assert.AreEqual(aCase1Removed.status, caseListRemovedC1SortStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC1SortStatus[0].TemplatId);
            //Assert.AreEqual(aCase1Removed.unit.id, caseListRemovedC1SortStatus[0].UnitId);
            //Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedC1SortStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.version, caseListRemovedC1SortStatus[0].Version);
            //Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedC1SortStatus[0].WorkerName);
            //Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedC1SortStatus[0].WorkflowState);
            #endregion

            #region caseListRemovedC1SortUnitId

            Assert.NotNull(caseListRemovedC1SortUnitId);
            Assert.AreEqual(0, caseListRemovedC1SortUnitId.Count);
            //Assert.AreEqual(aCase1Removed.type, caseListRemovedC1SortUnitId[0].CaseType);
            //Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedC1SortUnitId[0].CaseUId);
            //Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedC1SortUnitId[0].CheckUIid);
            //Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedC1SortUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.custom, caseListRemovedC1SortUnitId[0].Custom);
            //Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedC1SortUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Removed.id, caseListRemovedC1SortUnitId[0].Id);
            //Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedC1SortUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedC1SortUnitId[0].SiteId);
            //Assert.AreEqual(aCase1Removed.site.name, caseListRemovedC1SortUnitId[0].SiteName);
            //Assert.AreEqual(aCase1Removed.status, caseListRemovedC1SortUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC1SortUnitId[0].TemplatId);
            //Assert.AreEqual(aCase1Removed.unit.id, caseListRemovedC1SortUnitId[0].UnitId);
            //Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedC1SortUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.version, caseListRemovedC1SortUnitId[0].Version);
            //Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedC1SortUnitId[0].WorkerName);
            //Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedC1SortUnitId[0].WorkflowState);

            #endregion



            #endregion

            #region aCase2Removed sort asc

            #region caseListC2DoneAt aCase2Removed
            Assert.NotNull(caseListRemovedC2SortDoneAt);
            Assert.AreEqual(0, caseListRemovedC2SortDoneAt.Count);
            //Assert.AreEqual(aCase2Removed.type, caseListRemovedC2SortDoneAt[0].CaseType);
            //Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedC2SortDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedC2SortDoneAt[0].CheckUIid);
            //Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedC2SortDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.custom, caseListRemovedC2SortDoneAt[0].Custom);
            //Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedC2SortDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Removed.id, caseListRemovedC2SortDoneAt[0].Id);
            //Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedC2SortDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedC2SortDoneAt[0].SiteId);
            //Assert.AreEqual(aCase2Removed.site.name, caseListRemovedC2SortDoneAt[0].SiteName);
            //Assert.AreEqual(aCase2Removed.status, caseListRemovedC2SortDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC2SortDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase2Removed.unit.id, caseListRemovedC2SortDoneAt[0].UnitId);
            //Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedC2SortDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.version, caseListRemovedC2SortDoneAt[0].Version);
            //Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedC2SortDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedC2SortDoneAt[0].WorkflowState);
            #endregion

            #region caseListRemovedC2SortStatus aCase2Removed
            Assert.NotNull(caseListRemovedC2SortStatus);
            Assert.AreEqual(0, caseListRemovedC2SortStatus.Count);
            //Assert.AreEqual(aCase2Removed.type, caseListRemovedC2SortStatus[0].CaseType);
            //Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedC2SortStatus[0].CaseUId);
            //Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedC2SortStatus[0].CheckUIid);
            //Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedC2SortStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.custom, caseListRemovedC2SortStatus[0].Custom);
            //Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedC2SortStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Removed.id, caseListRemovedC2SortStatus[0].Id);
            //Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedC2SortStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedC2SortStatus[0].SiteId);
            //Assert.AreEqual(aCase2Removed.site.name, caseListRemovedC2SortStatus[0].SiteName);
            //Assert.AreEqual(aCase2Removed.status, caseListRemovedC2SortStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC2SortStatus[0].TemplatId);
            //Assert.AreEqual(aCase2Removed.unit.id, caseListRemovedC2SortStatus[0].UnitId);
            //Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedC2SortStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.version, caseListRemovedC2SortStatus[0].Version);
            //Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedC2SortStatus[0].WorkerName);
            //Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedC2SortStatus[0].WorkflowState);
            #endregion

            #region caseListRemovedC2SortUnitId aCase2Removed
            Assert.NotNull(caseListRemovedC2SortUnitId);
            Assert.AreEqual(0, caseListRemovedC2SortUnitId.Count);
            //Assert.AreEqual(aCase2Removed.type, caseListRemovedC2SortUnitId[0].CaseType);
            //Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedC2SortUnitId[0].CaseUId);
            //Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedC2SortUnitId[0].CheckUIid);
            //Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedC2SortUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.custom, caseListRemovedC2SortUnitId[0].Custom);
            //Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedC2SortUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Removed.id, caseListRemovedC2SortUnitId[0].Id);
            //Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedC2SortUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedC2SortUnitId[0].SiteId);
            //Assert.AreEqual(aCase2Removed.site.name, caseListRemovedC2SortUnitId[0].SiteName);
            //Assert.AreEqual(aCase2Removed.status, caseListRemovedC2SortUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC2SortUnitId[0].TemplatId);
            //Assert.AreEqual(aCase2Removed.unit.id, caseListRemovedC2SortUnitId[0].UnitId);
            //Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedC2SortUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.version, caseListRemovedC2SortUnitId[0].Version);
            //Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedC2SortUnitId[0].WorkerName);
            //Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedC2SortUnitId[0].WorkflowState);
            #endregion

            #endregion

            #region aCase3Removed sort asc

            #region caseListC3DoneAt aCase3Removed
            Assert.NotNull(caseListRemovedC3SortDoneAt);
            Assert.AreEqual(0, caseListRemovedC3SortDoneAt.Count);
            //Assert.AreEqual(aCase3Removed.type, caseListRemovedC3SortDoneAt[0].CaseType);
            //Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedC3SortDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedC3SortDoneAt[0].CheckUIid);
            //Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedC3SortDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.custom, caseListRemovedC3SortDoneAt[0].Custom);
            //Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedC3SortDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Removed.id, caseListRemovedC3SortDoneAt[0].Id);
            //Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedC3SortDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedC3SortDoneAt[0].SiteId);
            //Assert.AreEqual(aCase3Removed.site.name, caseListRemovedC3SortDoneAt[0].SiteName);
            //Assert.AreEqual(aCase3Removed.status, caseListRemovedC3SortDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC3SortDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase3Removed.unit.id, caseListRemovedC3SortDoneAt[0].UnitId);
            //Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedC3SortDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.version, caseListRemovedC3SortDoneAt[0].Version);
            //Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedC3SortDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedC3SortDoneAt[0].WorkflowState);
            #endregion

            #region caseListC3status aCase3Removed
            Assert.NotNull(caseListRemovedC3SortStatus);
            Assert.AreEqual(0, caseListRemovedC3SortStatus.Count);
            //Assert.AreEqual(aCase3Removed.type, caseListRemovedC3SortStatus[0].CaseType);
            //Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedC3SortStatus[0].CaseUId);
            //Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedC3SortStatus[0].CheckUIid);
            //Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedC3SortStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.custom, caseListRemovedC3SortStatus[0].Custom);
            //Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedC3SortStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Removed.id, caseListRemovedC3SortStatus[0].Id);
            //Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedC3SortStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedC3SortStatus[0].SiteId);
            //Assert.AreEqual(aCase3Removed.site.name, caseListRemovedC3SortStatus[0].SiteName);
            //Assert.AreEqual(aCase3Removed.status, caseListRemovedC3SortStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC3SortStatus[0].TemplatId);
            //Assert.AreEqual(aCase3Removed.unit.id, caseListRemovedC3SortStatus[0].UnitId);
            //Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedC3SortStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.version, caseListRemovedC3SortStatus[0].Version);
            //Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedC3SortStatus[0].WorkerName);
            //Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedC3SortStatus[0].WorkflowState);
            #endregion

            #region caseListC3UnitId aCase3Removed
            Assert.NotNull(caseListRemovedC3SortUnitId);
            Assert.AreEqual(0, caseListRemovedC3SortUnitId.Count);
            //Assert.AreEqual(aCase3Removed.type, caseListRemovedC3SortUnitId[0].CaseType);
            //Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedC3SortUnitId[0].CaseUId);
            //Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedC3SortUnitId[0].CheckUIid);
            //Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedC3SortUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.custom, caseListRemovedC3SortUnitId[0].Custom);
            //Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedC3SortUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Removed.id, caseListRemovedC3SortUnitId[0].Id);
            //Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedC3SortUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedC3SortUnitId[0].SiteId);
            //Assert.AreEqual(aCase3Removed.site.name, caseListRemovedC3SortUnitId[0].SiteName);
            //Assert.AreEqual(aCase3Removed.status, caseListRemovedC3SortUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC3SortUnitId[0].TemplatId);
            //Assert.AreEqual(aCase3Removed.unit.id, caseListRemovedC3SortUnitId[0].UnitId);
            //Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedC3SortUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.version, caseListRemovedC3SortUnitId[0].Version);
            //Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedC3SortUnitId[0].WorkerName);
            //Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedC3SortUnitId[0].WorkflowState);
            #endregion



            #endregion

            #region aCase4Removed sort asc


            #region caseListRemovedC4SortDoneAt aCase4Removed
            Assert.NotNull(caseListRemovedC4SortDoneAt);
            Assert.AreEqual(0, caseListRemovedC4SortDoneAt.Count);
            //Assert.AreEqual(aCase4Removed.type, caseListRemovedC4SortDoneAt[0].CaseType);
            //Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedC4SortDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedC4SortDoneAt[0].CheckUIid);
            //Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedC4SortDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.custom, caseListRemovedC4SortDoneAt[0].Custom);
            //Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedC4SortDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Removed.id, caseListRemovedC4SortDoneAt[0].Id);
            //Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedC4SortDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedC4SortDoneAt[0].SiteId);
            //Assert.AreEqual(aCase4Removed.site.name, caseListRemovedC4SortDoneAt[0].SiteName);
            //Assert.AreEqual(aCase4Removed.status, caseListRemovedC4SortDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC4SortDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase4Removed.unit.id, caseListRemovedC4SortDoneAt[0].UnitId);
            //Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedC4SortDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.version, caseListRemovedC4SortDoneAt[0].Version);
            //Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedC4SortDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedC4SortDoneAt[0].WorkflowState);
            #endregion

            #region caseListRemovedC4SortStatus aCase4Removed
            Assert.NotNull(caseListRemovedC4SortStatus);
            Assert.AreEqual(0, caseListRemovedC4SortStatus.Count);
            //Assert.AreEqual(aCase4Removed.type, caseListRemovedC4SortStatus[0].CaseType);
            //Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedC4SortStatus[0].CaseUId);
            //Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedC4SortStatus[0].CheckUIid);
            //Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedC4SortStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.custom, caseListRemovedC4SortStatus[0].Custom);
            //Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedC4SortStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Removed.id, caseListRemovedC4SortStatus[0].Id);
            //Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedC4SortStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedC4SortStatus[0].SiteId);
            //Assert.AreEqual(aCase4Removed.site.name, caseListRemovedC4SortStatus[0].SiteName);
            //Assert.AreEqual(aCase4Removed.status, caseListRemovedC4SortStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC4SortStatus[0].TemplatId);
            //Assert.AreEqual(aCase4Removed.unit.id, caseListRemovedC4SortStatus[0].UnitId);
            //Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedC4SortStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.version, caseListRemovedC4SortStatus[0].Version);
            //Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedC4SortStatus[0].WorkerName);
            //Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedC4SortStatus[0].WorkflowState);
            #endregion

            #region caseListRemovedC4SortUnitId aCase4Removed

            Assert.NotNull(caseListRemovedC4SortUnitId);
            Assert.AreEqual(0, caseListRemovedC4SortUnitId.Count);
            //Assert.AreEqual(aCase4Removed.type, caseListRemovedC4SortUnitId[0].CaseType);
            //Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedC4SortUnitId[0].CaseUId);
            //Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedC4SortUnitId[0].CheckUIid);
            //Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedC4SortUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.custom, caseListRemovedC4SortUnitId[0].Custom);
            //Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedC4SortUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Removed.id, caseListRemovedC4SortUnitId[0].Id);
            //Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedC4SortUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedC4SortUnitId[0].SiteId);
            //Assert.AreEqual(aCase4Removed.site.name, caseListRemovedC4SortUnitId[0].SiteName);
            //Assert.AreEqual(aCase4Removed.status, caseListRemovedC4SortUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC4SortUnitId[0].TemplatId);
            //Assert.AreEqual(aCase4Removed.unit.id, caseListRemovedC4SortUnitId[0].UnitId);
            //Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedC4SortUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.version, caseListRemovedC4SortUnitId[0].Version);
            //Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedC4SortUnitId[0].WorkerName);
            //Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedC4SortUnitId[0].WorkflowState);

            #endregion

            #endregion

            #endregion

            #region aCase Sort Des

            #region aCase1Removed Sort Des
            #region caseListRemovedC1SortDescendingDoneAt aCase1Removed

            Assert.NotNull(caseListRemovedC1SortDescendingDoneAt);
            Assert.AreEqual(0, caseListRemovedC1SortDescendingDoneAt.Count);
            //Assert.AreEqual(aCase1Removed.type, caseListRemovedC1SortDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedC1SortDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedC1SortDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedC1SortDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.custom, caseListRemovedC1SortDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedC1SortDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Removed.id, caseListRemovedC1SortDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedC1SortDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedC1SortDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase1Removed.site.name, caseListRemovedC1SortDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase1Removed.status, caseListRemovedC1SortDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase1Removed.check_list_id, caseListRemovedC1SortDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedC1SortDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedC1SortDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.version, caseListRemovedC1SortDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedC1SortDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedC1SortDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRemovedC1SortDescendingStatus aCase1Removed

            Assert.NotNull(caseListRemovedC1SortDescendingStatus);
            Assert.AreEqual(0, caseListRemovedC1SortDescendingStatus.Count);
            //Assert.AreEqual(aCase1Removed.type, caseListRemovedC1SortDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedC1SortDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedC1SortDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedC1SortDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.custom, caseListRemovedC1SortDescendingStatus[0].Custom);
            //Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedC1SortDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Removed.id, caseListRemovedC1SortDescendingStatus[0].Id);
            //Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedC1SortDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedC1SortDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase1Removed.site.name, caseListRemovedC1SortDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase1Removed.status, caseListRemovedC1SortDescendingStatus[0].Status);
            //Assert.AreEqual(aCase1Removed.check_list_id, caseListRemovedC1SortDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedC1SortDescendingStatus[0].UnitId);
            //Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedC1SortDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.version, caseListRemovedC1SortDescendingStatus[0].Version);
            //Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedC1SortDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedC1SortDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRemovedC1SortDescendingUnitId aCase1Removed

            Assert.NotNull(caseListRemovedC1SortDescendingUnitId);
            Assert.AreEqual(0, caseListRemovedC1SortDescendingUnitId.Count);
            //Assert.AreEqual(aCase1Removed.type, caseListRemovedC1SortDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedC1SortDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedC1SortDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedC1SortDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.custom, caseListRemovedC1SortDescendingUnitId[0].Custom);
            //Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedC1SortDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Removed.id, caseListRemovedC1SortDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedC1SortDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedC1SortDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase1Removed.site.name, caseListRemovedC1SortDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase1Removed.status, caseListRemovedC1SortDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase1Removed.check_list_id, caseListRemovedC1SortDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedC1SortDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedC1SortDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.version, caseListRemovedC1SortDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedC1SortDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedC1SortDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase2Removed Sort Des
            #region caseListRemovedC2SortDescendingDoneAt aCase2Removed

            Assert.NotNull(caseListRemovedC2SortDescendingDoneAt);
            Assert.AreEqual(0, caseListRemovedC2SortDescendingDoneAt.Count);
            //Assert.AreEqual(aCase2Removed.type, caseListRemovedC2SortDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedC2SortDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedC2SortDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedC2SortDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.custom, caseListRemovedC2SortDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedC2SortDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Removed.id, caseListRemovedC2SortDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedC2SortDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedC2SortDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase2Removed.site.name, caseListRemovedC2SortDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase2Removed.status, caseListRemovedC2SortDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase2Removed.check_list_id, caseListRemovedC2SortDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase2Removed.unit.microting_uid, caseListRemovedC2SortDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedC2SortDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.version, caseListRemovedC2SortDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedC2SortDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedC2SortDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRemovedC2SortDescendingStatus aCase2Removed

            Assert.NotNull(caseListRemovedC2SortDescendingStatus);
            Assert.AreEqual(0, caseListRemovedC2SortDescendingStatus.Count);
            //Assert.AreEqual(aCase2Removed.type, caseListRemovedC2SortDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedC2SortDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedC2SortDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedC2SortDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.custom, caseListRemovedC2SortDescendingStatus[0].Custom);
            //Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedC2SortDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Removed.id, caseListRemovedC2SortDescendingStatus[0].Id);
            //Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedC2SortDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedC2SortDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase2Removed.site.name, caseListRemovedC2SortDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase2Removed.status, caseListRemovedC2SortDescendingStatus[0].Status);
            //Assert.AreEqual(aCase2Removed.check_list_id, caseListRemovedC2SortDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase2Removed.unit.microting_uid, caseListRemovedC2SortDescendingStatus[0].UnitId);
            //Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedC2SortDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.version, caseListRemovedC2SortDescendingStatus[0].Version);
            //Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedC2SortDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedC2SortDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRemovedC2SortDescendingUnitId aCase2Removed

            Assert.NotNull(caseListRemovedC2SortDescendingUnitId);
            Assert.AreEqual(0, caseListRemovedC2SortDescendingUnitId.Count);
            //Assert.AreEqual(aCase2Removed.type, caseListRemovedC2SortDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedC2SortDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedC2SortDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedC2SortDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.custom, caseListRemovedC2SortDescendingUnitId[0].Custom);
            //Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedC2SortDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Removed.id, caseListRemovedC2SortDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedC2SortDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedC2SortDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase2Removed.site.name, caseListRemovedC2SortDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase2Removed.status, caseListRemovedC2SortDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase2Removed.check_list_id, caseListRemovedC2SortDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase2Removed.unit.microting_uid, caseListRemovedC2SortDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedC2SortDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.version, caseListRemovedC2SortDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedC2SortDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedC2SortDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase3Removed Sort Des
            #region caseListRemovedC3SortDescendingDoneAt aCase3Removed

            Assert.NotNull(caseListRemovedC3SortDescendingDoneAt);
            Assert.AreEqual(0, caseListRemovedC3SortDescendingDoneAt.Count);
            //Assert.AreEqual(aCase3Removed.type, caseListRemovedC3SortDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedC3SortDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedC3SortDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedC3SortDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.custom, caseListRemovedC3SortDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedC3SortDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Removed.id, caseListRemovedC3SortDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedC3SortDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedC3SortDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase3Removed.site.name, caseListRemovedC3SortDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase3Removed.status, caseListRemovedC3SortDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase3Removed.check_list_id, caseListRemovedC3SortDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedC3SortDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedC3SortDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.version, caseListRemovedC3SortDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedC3SortDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedC3SortDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRemovedC3SortDescendingStatus aCase3Removed

            Assert.NotNull(caseListRemovedC3SortDescendingStatus);
            Assert.AreEqual(0, caseListRemovedC3SortDescendingStatus.Count);
            //Assert.AreEqual(aCase3Removed.type, caseListRemovedC3SortDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedC3SortDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedC3SortDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedC3SortDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.custom, caseListRemovedC3SortDescendingStatus[0].Custom);
            //Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedC3SortDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Removed.id, caseListRemovedC3SortDescendingStatus[0].Id);
            //Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedC3SortDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedC3SortDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase3Removed.site.name, caseListRemovedC3SortDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase3Removed.status, caseListRemovedC3SortDescendingStatus[0].Status);
            //Assert.AreEqual(aCase3Removed.check_list_id, caseListRemovedC3SortDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedC3SortDescendingStatus[0].UnitId);
            //Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedC3SortDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.version, caseListRemovedC3SortDescendingStatus[0].Version);
            //Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedC3SortDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedC3SortDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRemovedC3SortDescendingUnitId aCase3Removed

            Assert.NotNull(caseListRemovedC3SortDescendingUnitId);
            Assert.AreEqual(0, caseListRemovedC3SortDescendingUnitId.Count);
            //Assert.AreEqual(aCase3Removed.type, caseListRemovedC3SortDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedC3SortDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedC3SortDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedC3SortDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.custom, caseListRemovedC3SortDescendingUnitId[0].Custom);
            //Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedC3SortDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Removed.id, caseListRemovedC3SortDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedC3SortDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedC3SortDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase3Removed.site.name, caseListRemovedC3SortDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase3Removed.status, caseListRemovedC3SortDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase3Removed.check_list_id, caseListRemovedC3SortDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedC3SortDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedC3SortDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.version, caseListRemovedC3SortDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedC3SortDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedC3SortDescendingUnitId[0].WorkflowState);

            #endregion

            #endregion

            #region aCase4Removed Sort Des
            #region caseListRemovedC4SortDescendingDoneAt aCase4Removed

            Assert.NotNull(caseListRemovedC4SortDescendingDoneAt);
            Assert.AreEqual(0, caseListRemovedC4SortDescendingDoneAt.Count);
            //Assert.AreEqual(aCase4Removed.type, caseListRemovedC4SortDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedC4SortDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedC4SortDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedC4SortDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.custom, caseListRemovedC4SortDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedC4SortDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Removed.id, caseListRemovedC4SortDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedC4SortDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedC4SortDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase4Removed.site.name, caseListRemovedC4SortDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase4Removed.status, caseListRemovedC4SortDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase4Removed.check_list_id, caseListRemovedC4SortDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase4Removed.unit.microting_uid, caseListRemovedC4SortDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedC4SortDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.version, caseListRemovedC4SortDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedC4SortDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedC4SortDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRemovedC4SortDescendingStatus aCase4Removed

            Assert.NotNull(caseListRemovedC4SortDescendingStatus);
            Assert.AreEqual(0, caseListRemovedC4SortDescendingStatus.Count);
            //Assert.AreEqual(aCase4Removed.type, caseListRemovedC4SortDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedC4SortDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedC4SortDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedC4SortDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.custom, caseListRemovedC4SortDescendingStatus[0].Custom);
            //Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedC4SortDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Removed.id, caseListRemovedC4SortDescendingStatus[0].Id);
            //Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedC4SortDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedC4SortDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase4Removed.site.name, caseListRemovedC4SortDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase4Removed.status, caseListRemovedC4SortDescendingStatus[0].Status);
            //Assert.AreEqual(aCase4Removed.check_list_id, caseListRemovedC4SortDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase4Removed.unit.microting_uid, caseListRemovedC4SortDescendingStatus[0].UnitId);
            //Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedC4SortDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.version, caseListRemovedC4SortDescendingStatus[0].Version);
            //Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedC4SortDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedC4SortDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRemovedC4SortDescendingUnitId aCase4Removed

            Assert.NotNull(caseListRemovedC4SortDescendingUnitId);
            Assert.AreEqual(0, caseListRemovedC4SortDescendingUnitId.Count);
            //Assert.AreEqual(aCase4Removed.type, caseListRemovedC4SortDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedC4SortDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedC4SortDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedC4SortDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.custom, caseListRemovedC4SortDescendingUnitId[0].Custom);
            //Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedC4SortDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Removed.id, caseListRemovedC4SortDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedC4SortDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedC4SortDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase4Removed.site.name, caseListRemovedC4SortDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase4Removed.status, caseListRemovedC4SortDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase4Removed.check_list_id, caseListRemovedC4SortDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase4Removed.unit.microting_uid, caseListRemovedC4SortDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedC4SortDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.version, caseListRemovedC4SortDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedC4SortDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedC4SortDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion
            #endregion

            #region aCase Sort Asc w. DateTime

            #region aCase1Removed sort asc w. DateTime

            #region caseListRemovedC1SortDtDoneAt aCase1Removed
            Assert.NotNull(caseListRemovedC1SortDtDoneAt);
            Assert.AreEqual(0, caseListRemovedC1SortDtDoneAt.Count);
            //Assert.AreEqual(aCase1Removed.type, caseListRemovedC1SortDtDoneAt[0].CaseType);
            //Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedC1SortDtDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedC1SortDtDoneAt[0].CheckUIid);
            //Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedC1SortDtDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.custom, caseListRemovedC1SortDtDoneAt[0].Custom);
            //Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedC1SortDtDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Removed.id, caseListRemovedC1SortDtDoneAt[0].Id);
            //Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedC1SortDtDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedC1SortDtDoneAt[0].SiteId);
            //Assert.AreEqual(aCase1Removed.site.name, caseListRemovedC1SortDtDoneAt[0].SiteName);
            //Assert.AreEqual(aCase1Removed.status, caseListRemovedC1SortDtDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC1SortDtDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase1Removed.unit.id, caseListRemovedC1SortDtDoneAt[0].UnitId);
            //Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedC1SortDtDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.version, caseListRemovedC1SortDtDoneAt[0].Version);
            //Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedC1SortDtDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedC1SortDtDoneAt[0].WorkflowState);
            #endregion

            #region caseListRemovedC1SortDtStatus aCase1Removed
            Assert.NotNull(caseListRemovedC1SortDtStatus);
            Assert.AreEqual(0, caseListRemovedC1SortDtStatus.Count);
            //Assert.AreEqual(aCase1Removed.type, caseListRemovedC1SortDtStatus[0].CaseType);
            //Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedC1SortDtStatus[0].CaseUId);
            //Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedC1SortDtStatus[0].CheckUIid);
            //Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedC1SortDtStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.custom, caseListRemovedC1SortDtStatus[0].Custom);
            //Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedC1SortDtStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Removed.id, caseListRemovedC1SortDtStatus[0].Id);
            //Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedC1SortDtStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedC1SortDtStatus[0].SiteId);
            //Assert.AreEqual(aCase1Removed.site.name, caseListRemovedC1SortDtStatus[0].SiteName);
            //Assert.AreEqual(aCase1Removed.status, caseListRemovedC1SortDtStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC1SortDtStatus[0].TemplatId);
            //Assert.AreEqual(aCase1Removed.unit.id, caseListRemovedC1SortDtStatus[0].UnitId);
            //Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedC1SortDtStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.version, caseListRemovedC1SortDtStatus[0].Version);
            //Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedC1SortDtStatus[0].WorkerName);
            //Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedC1SortDtStatus[0].WorkflowState);
            #endregion

            #region caseListRemovedC1SortDtUnitId aCase1Removed
            Assert.NotNull(caseListRemovedC1SortDtUnitId);
            Assert.AreEqual(0, caseListRemovedC1SortDtUnitId.Count);
            //Assert.AreEqual(aCase1Removed.type, caseListRemovedC1SortDtUnitId[0].CaseType);
            //Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedC1SortDtUnitId[0].CaseUId);
            //Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedC1SortDtUnitId[0].CheckUIid);
            //Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedC1SortDtUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.custom, caseListRemovedC1SortDtUnitId[0].Custom);
            //Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedC1SortDtUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Removed.id, caseListRemovedC1SortDtUnitId[0].Id);
            //Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedC1SortDtUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedC1SortDtUnitId[0].SiteId);
            //Assert.AreEqual(aCase1Removed.site.name, caseListRemovedC1SortDtUnitId[0].SiteName);
            //Assert.AreEqual(aCase1Removed.status, caseListRemovedC1SortDtUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC1SortDtUnitId[0].TemplatId);
            //Assert.AreEqual(aCase1Removed.unit.id, caseListRemovedC1SortDtUnitId[0].UnitId);
            //Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedC1SortDtUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.version, caseListRemovedC1SortDtUnitId[0].Version);
            //Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedC1SortDtUnitId[0].WorkerName);
            //Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedC1SortDtUnitId[0].WorkflowState);
            #endregion



            #endregion

            #region aCase2Removed sort asc w. DateTime

            #region caseListRemovedC2SortDtDoneAt aCase2Removed
            Assert.NotNull(caseListRemovedC2SortDtDoneAt);
            Assert.AreEqual(0, caseListRemovedC2SortDtDoneAt.Count);
            //Assert.AreEqual(aCase2Removed.type, caseListRemovedC2SortDtDoneAt[0].CaseType);
            //Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedC2SortDtDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedC2SortDtDoneAt[0].CheckUIid);
            //Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedC2SortDtDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.custom, caseListRemovedC2SortDtDoneAt[0].Custom);
            //Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedC2SortDtDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Removed.id, caseListRemovedC2SortDtDoneAt[0].Id);
            //Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedC2SortDtDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedC2SortDtDoneAt[0].SiteId);
            //Assert.AreEqual(aCase2Removed.site.name, caseListRemovedC2SortDtDoneAt[0].SiteName);
            //Assert.AreEqual(aCase2Removed.status, caseListRemovedC2SortDtDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC2SortDtDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase2Removed.unit.id, caseListRemovedC2SortDtDoneAt[0].UnitId);
            //Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedC2SortDtDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.version, caseListRemovedC2SortDtDoneAt[0].Version);
            //Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedC2SortDtDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedC2SortDtDoneAt[0].WorkflowState);
            #endregion

            #region caseListRemovedC2SortDtStatus aCase2Removed
            Assert.NotNull(caseListRemovedC2SortDtStatus);
            Assert.AreEqual(0, caseListRemovedC2SortDtStatus.Count);
            //Assert.AreEqual(aCase2Removed.type, caseListRemovedC2SortDtStatus[0].CaseType);
            //Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedC2SortDtStatus[0].CaseUId);
            //Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedC2SortDtStatus[0].CheckUIid);
            //Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedC2SortDtStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.custom, caseListRemovedC2SortDtStatus[0].Custom);
            //Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedC2SortDtStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Removed.id, caseListRemovedC2SortDtStatus[0].Id);
            //Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedC2SortDtStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedC2SortDtStatus[0].SiteId);
            //Assert.AreEqual(aCase2Removed.site.name, caseListRemovedC2SortDtStatus[0].SiteName);
            //Assert.AreEqual(aCase2Removed.status, caseListRemovedC2SortDtStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC2SortDtStatus[0].TemplatId);
            //Assert.AreEqual(aCase2Removed.unit.id, caseListRemovedC2SortDtStatus[0].UnitId);
            //Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedC2SortDtStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.version, caseListRemovedC2SortDtStatus[0].Version);
            //Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedC2SortDtStatus[0].WorkerName);
            //Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedC2SortDtStatus[0].WorkflowState);
            #endregion

            #region caseListRemovedC2SortDtUnitId aCase2Removed
            Assert.NotNull(caseListRemovedC2SortDtUnitId);
            Assert.AreEqual(0, caseListRemovedC2SortDtUnitId.Count);
            //Assert.AreEqual(aCase2Removed.type, caseListRemovedC2SortDtUnitId[0].CaseType);
            //Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedC2SortDtUnitId[0].CaseUId);
            //Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedC2SortDtUnitId[0].CheckUIid);
            //Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedC2SortDtUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.custom, caseListRemovedC2SortDtUnitId[0].Custom);
            //Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedC2SortDtUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Removed.id, caseListRemovedC2SortDtUnitId[0].Id);
            //Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedC2SortDtUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedC2SortDtUnitId[0].SiteId);
            //Assert.AreEqual(aCase2Removed.site.name, caseListRemovedC2SortDtUnitId[0].SiteName);
            //Assert.AreEqual(aCase2Removed.status, caseListRemovedC2SortDtUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC2SortDtUnitId[0].TemplatId);
            //Assert.AreEqual(aCase2Removed.unit.id, caseListRemovedC2SortDtUnitId[0].UnitId);
            //Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedC2SortDtUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.version, caseListRemovedC2SortDtUnitId[0].Version);
            //Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedC2SortDtUnitId[0].WorkerName);
            //Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedC2SortDtUnitId[0].WorkflowState);
            #endregion

            #endregion

            #region aCase3Removed sort asc w. DateTime

            #region caseListRemovedC3SortDtDoneAt aCase3Removed
            Assert.NotNull(caseListRemovedC3SortDtDoneAt);
            Assert.AreEqual(0, caseListRemovedC3SortDtDoneAt.Count);
            //Assert.AreEqual(aCase3Removed.type, caseListRemovedC3SortDtDoneAt[0].CaseType);
            //Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedC3SortDtDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedC3SortDtDoneAt[0].CheckUIid);
            //Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedC3SortDtDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.custom, caseListRemovedC3SortDtDoneAt[0].Custom);
            //Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedC3SortDtDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Removed.id, caseListRemovedC3SortDtDoneAt[0].Id);
            //Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedC3SortDtDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedC3SortDtDoneAt[0].SiteId);
            //Assert.AreEqual(aCase3Removed.site.name, caseListRemovedC3SortDtDoneAt[0].SiteName);
            //Assert.AreEqual(aCase3Removed.status, caseListRemovedC3SortDtDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC3SortDtDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase3Removed.unit.id, caseListRemovedC3SortDtDoneAt[0].UnitId);
            //Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedC3SortDtDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.version, caseListRemovedC3SortDtDoneAt[0].Version);
            //Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedC3SortDtDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedC3SortDtDoneAt[0].WorkflowState);
            #endregion

            #region caseListRemovedC3SortDtStatus aCase3Removed
            Assert.NotNull(caseListRemovedC3SortDtStatus);
            Assert.AreEqual(0, caseListRemovedC3SortDtStatus.Count);
            //Assert.AreEqual(aCase3Removed.type, caseListRemovedC3SortDtStatus[0].CaseType);
            //Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedC3SortDtStatus[0].CaseUId);
            //Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedC3SortDtStatus[0].CheckUIid);
            //Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedC3SortDtStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.custom, caseListRemovedC3SortDtStatus[0].Custom);
            //Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedC3SortDtStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Removed.id, caseListRemovedC3SortDtStatus[0].Id);
            //Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedC3SortDtStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedC3SortDtStatus[0].SiteId);
            //Assert.AreEqual(aCase3Removed.site.name, caseListRemovedC3SortDtStatus[0].SiteName);
            //Assert.AreEqual(aCase3Removed.status, caseListRemovedC3SortDtStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC3SortDtStatus[0].TemplatId);
            //Assert.AreEqual(aCase3Removed.unit.id, caseListRemovedC3SortDtStatus[0].UnitId);
            //Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedC3SortDtStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.version, caseListRemovedC3SortDtStatus[0].Version);
            //Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedC3SortDtStatus[0].WorkerName);
            //Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedC3SortDtStatus[0].WorkflowState);
            #endregion

            #region caseListRemovedC3SortDtUnitId aCase3Removed
            Assert.NotNull(caseListRemovedC3SortDtUnitId);
            Assert.AreEqual(0, caseListRemovedC3SortDtUnitId.Count);
            //Assert.AreEqual(aCase3Removed.type, caseListRemovedC3SortDtUnitId[0].CaseType);
            //Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedC3SortDtUnitId[0].CaseUId);
            //Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedC3SortDtUnitId[0].CheckUIid);
            //Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedC3SortDtUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.custom, caseListRemovedC3SortDtUnitId[0].Custom);
            //Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedC3SortDtUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Removed.id, caseListRemovedC3SortDtUnitId[0].Id);
            //Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedC3SortDtUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedC3SortDtUnitId[0].SiteId);
            //Assert.AreEqual(aCase3Removed.site.name, caseListRemovedC3SortDtUnitId[0].SiteName);
            //Assert.AreEqual(aCase3Removed.status, caseListRemovedC3SortDtUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC3SortDtUnitId[0].TemplatId);
            //Assert.AreEqual(aCase3Removed.unit.id, caseListRemovedC3SortDtUnitId[0].UnitId);
            //Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedC3SortDtUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.version, caseListRemovedC3SortDtUnitId[0].Version);
            //Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedC3SortDtUnitId[0].WorkerName);
            //Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedC3SortDtUnitId[0].WorkflowState);
            #endregion


            #endregion

            #region aCase4Removed sort asc w. DateTime

            #region caseListRemovedC4SortDtDoneAt aCase4Removed
            Assert.NotNull(caseListRemovedC4SortDtDoneAt);
            Assert.AreEqual(0, caseListRemovedC4SortDtDoneAt.Count);
            //Assert.AreEqual(aCase4Removed.type, caseListRemovedC4SortDtDoneAt[0].CaseType);
            //Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedC4SortDtDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedC4SortDtDoneAt[0].CheckUIid);
            //Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedC4SortDtDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.custom, caseListRemovedC4SortDtDoneAt[0].Custom);
            //Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedC4SortDtDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Removed.id, caseListRemovedC4SortDtDoneAt[0].Id);
            //Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedC4SortDtDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedC4SortDtDoneAt[0].SiteId);
            //Assert.AreEqual(aCase4Removed.site.name, caseListRemovedC4SortDtDoneAt[0].SiteName);
            //Assert.AreEqual(aCase4Removed.status, caseListRemovedC4SortDtDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC4SortDtDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase4Removed.unit.id, caseListRemovedC4SortDtDoneAt[0].UnitId);
            //Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedC4SortDtDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.version, caseListRemovedC4SortDtDoneAt[0].Version);
            //Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedC4SortDtDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedC4SortDtDoneAt[0].WorkflowState);
            #endregion

            #region caseListRemovedC4SortDtStatus aCase4Removed
            Assert.NotNull(caseListRemovedC4SortDtStatus);
            Assert.AreEqual(0, caseListRemovedC4SortDtStatus.Count);
            //Assert.AreEqual(aCase4Removed.type, caseListRemovedC4SortDtStatus[0].CaseType);
            //Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedC4SortDtStatus[0].CaseUId);
            //Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedC4SortDtStatus[0].CheckUIid);
            //Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedC4SortDtStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.custom, caseListRemovedC4SortDtStatus[0].Custom);
            //Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedC4SortDtStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Removed.id, caseListRemovedC4SortDtStatus[0].Id);
            //Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedC4SortDtStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedC4SortDtStatus[0].SiteId);
            //Assert.AreEqual(aCase4Removed.site.name, caseListRemovedC4SortDtStatus[0].SiteName);
            //Assert.AreEqual(aCase4Removed.status, caseListRemovedC4SortDtStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC4SortDtStatus[0].TemplatId);
            //Assert.AreEqual(aCase4Removed.unit.id, caseListRemovedC4SortDtStatus[0].UnitId);
            //Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedC4SortDtStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.version, caseListRemovedC4SortDtStatus[0].Version);
            //Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedC4SortDtStatus[0].WorkerName);
            //Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedC4SortDtStatus[0].WorkflowState);
            #endregion

            #region caseListRemovedC4SortDtUnitId aCase4Removed
            Assert.NotNull(caseListRemovedC4SortDtUnitId);
            Assert.AreEqual(0, caseListRemovedC4SortDtUnitId.Count);
            //Assert.AreEqual(aCase4Removed.type, caseListRemovedC4SortDtUnitId[0].CaseType);
            //Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedC4SortDtUnitId[0].CaseUId);
            //Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedC4SortDtUnitId[0].CheckUIid);
            //Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedC4SortDtUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.custom, caseListRemovedC4SortDtUnitId[0].Custom);
            //Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedC4SortDtUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Removed.id, caseListRemovedC4SortDtUnitId[0].Id);
            //Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedC4SortDtUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedC4SortDtUnitId[0].SiteId);
            //Assert.AreEqual(aCase4Removed.site.name, caseListRemovedC4SortDtUnitId[0].SiteName);
            //Assert.AreEqual(aCase4Removed.status, caseListRemovedC4SortDtUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRemovedC4SortDtUnitId[0].TemplatId);
            //Assert.AreEqual(aCase4Removed.unit.id, caseListRemovedC4SortDtUnitId[0].UnitId);
            //Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedC4SortDtUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.version, caseListRemovedC4SortDtUnitId[0].Version);
            //Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedC4SortDtUnitId[0].WorkerName);
            //Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedC4SortDtUnitId[0].WorkflowState);
            #endregion



            #endregion

            #endregion

            #region aCase Sort Des w. DateTime
            #region aCase1Removed Sort Des w. DateTime
            #region caseListRemovedC1SortDtDescendingDoneAt aCase1Removed

            Assert.NotNull(caseListRemovedC1SortDtDescendingDoneAt);
            Assert.AreEqual(0, caseListRemovedC1SortDtDescendingDoneAt.Count);
            //Assert.AreEqual(aCase1Removed.type, caseListRemovedC1SortDtDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedC1SortDtDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedC1SortDtDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedC1SortDtDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.custom, caseListRemovedC1SortDtDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedC1SortDtDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Removed.id, caseListRemovedC1SortDtDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedC1SortDtDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedC1SortDtDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase1Removed.site.name, caseListRemovedC1SortDtDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase1Removed.status, caseListRemovedC1SortDtDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase1Removed.check_list_id, caseListRemovedC1SortDtDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedC1SortDtDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedC1SortDtDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.version, caseListRemovedC1SortDtDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedC1SortDtDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedC1SortDtDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRemovedC1SortDtDescendingStatus aCase1Removed

            Assert.NotNull(caseListRemovedC1SortDtDescendingStatus);
            Assert.AreEqual(0, caseListRemovedC1SortDtDescendingStatus.Count);
            //Assert.AreEqual(aCase1Removed.type, caseListRemovedC1SortDtDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedC1SortDtDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedC1SortDtDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedC1SortDtDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.custom, caseListRemovedC1SortDtDescendingStatus[0].Custom);
            //Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedC1SortDtDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Removed.id, caseListRemovedC1SortDtDescendingStatus[0].Id);
            //Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedC1SortDtDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedC1SortDtDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase1Removed.site.name, caseListRemovedC1SortDtDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase1Removed.status, caseListRemovedC1SortDtDescendingStatus[0].Status);
            //Assert.AreEqual(aCase1Removed.check_list_id, caseListRemovedC1SortDtDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedC1SortDtDescendingStatus[0].UnitId);
            //Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedC1SortDtDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.version, caseListRemovedC1SortDtDescendingStatus[0].Version);
            //Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedC1SortDtDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedC1SortDtDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRemovedC1SortDtDescendingUnitId aCase1Removed

            Assert.NotNull(caseListRemovedC1SortDtDescendingUnitId);
            Assert.AreEqual(0, caseListRemovedC1SortDtDescendingUnitId.Count);
            //Assert.AreEqual(aCase1Removed.type, caseListRemovedC1SortDtDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase1Removed.case_uid, caseListRemovedC1SortDtDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase1Removed.microting_check_uid, caseListRemovedC1SortDtDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c1Removed_ca.ToString(), caseListRemovedC1SortDtDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.custom, caseListRemovedC1SortDtDescendingUnitId[0].Custom);
            //Assert.AreEqual(c1Removed_da.ToString(), caseListRemovedC1SortDtDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Removed.id, caseListRemovedC1SortDtDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase1Removed.microting_uid, caseListRemovedC1SortDtDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase1Removed.site.microting_uid, caseListRemovedC1SortDtDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase1Removed.site.name, caseListRemovedC1SortDtDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase1Removed.status, caseListRemovedC1SortDtDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase1Removed.check_list_id, caseListRemovedC1SortDtDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase1Removed.unit.microting_uid, caseListRemovedC1SortDtDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c1Removed_ua.ToString(), caseListRemovedC1SortDtDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Removed.version, caseListRemovedC1SortDtDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase1Removed.worker.first_name + " " + aCase1Removed.worker.last_name, caseListRemovedC1SortDtDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase1Removed.workflow_state, caseListRemovedC1SortDtDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase2Removed Sort Des w. DateTime
            #region caseListRemovedC2SortDtDescendingDoneAt aCase2Removed

            Assert.NotNull(caseListRemovedC2SortDtDescendingDoneAt);
            Assert.AreEqual(0, caseListRemovedC2SortDtDescendingDoneAt.Count);
            //Assert.AreEqual(aCase2Removed.type, caseListRemovedC2SortDtDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedC2SortDtDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedC2SortDtDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedC2SortDtDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.custom, caseListRemovedC2SortDtDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedC2SortDtDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Removed.id, caseListRemovedC2SortDtDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedC2SortDtDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedC2SortDtDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase2Removed.site.name, caseListRemovedC2SortDtDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase2Removed.status, caseListRemovedC2SortDtDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase2Removed.check_list_id, caseListRemovedC2SortDtDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase2Removed.unit.microting_uid, caseListRemovedC2SortDtDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedC2SortDtDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.version, caseListRemovedC2SortDtDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedC2SortDtDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedC2SortDtDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRemovedC2SortDtDescendingStatus aCase2Removed

            Assert.NotNull(caseListRemovedC2SortDtDescendingStatus);
            Assert.AreEqual(0, caseListRemovedC2SortDtDescendingStatus.Count);
            //Assert.AreEqual(aCase2Removed.type, caseListRemovedC2SortDtDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedC2SortDtDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedC2SortDtDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedC2SortDtDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.custom, caseListRemovedC2SortDtDescendingStatus[0].Custom);
            //Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedC2SortDtDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Removed.id, caseListRemovedC2SortDtDescendingStatus[0].Id);
            //Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedC2SortDtDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedC2SortDtDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase2Removed.site.name, caseListRemovedC2SortDtDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase2Removed.status, caseListRemovedC2SortDtDescendingStatus[0].Status);
            //Assert.AreEqual(aCase2Removed.check_list_id, caseListRemovedC2SortDtDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase2Removed.unit.microting_uid, caseListRemovedC2SortDtDescendingStatus[0].UnitId);
            //Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedC2SortDtDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.version, caseListRemovedC2SortDtDescendingStatus[0].Version);
            //Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedC2SortDtDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedC2SortDtDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRemovedC2SortDtDescendingUnitId aCase2Removed

            Assert.NotNull(caseListRemovedC2SortDtDescendingUnitId);
            Assert.AreEqual(0, caseListRemovedC2SortDtDescendingUnitId.Count);
            //Assert.AreEqual(aCase2Removed.type, caseListRemovedC2SortDtDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase2Removed.case_uid, caseListRemovedC2SortDtDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase2Removed.microting_check_uid, caseListRemovedC2SortDtDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c2Removed_ca.ToString(), caseListRemovedC2SortDtDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.custom, caseListRemovedC2SortDtDescendingUnitId[0].Custom);
            //Assert.AreEqual(c2Removed_da.ToString(), caseListRemovedC2SortDtDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Removed.id, caseListRemovedC2SortDtDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase2Removed.microting_uid, caseListRemovedC2SortDtDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase2Removed.site.microting_uid, caseListRemovedC2SortDtDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase2Removed.site.name, caseListRemovedC2SortDtDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase2Removed.status, caseListRemovedC2SortDtDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase2Removed.check_list_id, caseListRemovedC2SortDtDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase2Removed.unit.microting_uid, caseListRemovedC2SortDtDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c2Removed_ua.ToString(), caseListRemovedC2SortDtDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Removed.version, caseListRemovedC2SortDtDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase2Removed.worker.first_name + " " + aCase2Removed.worker.last_name, caseListRemovedC2SortDtDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase2Removed.workflow_state, caseListRemovedC2SortDtDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase3Removed Sort Des w. DateTime
            #region caseListRemovedC3SortDtDescendingDoneAt aCase3Removed

            Assert.NotNull(caseListRemovedC3SortDtDescendingDoneAt);
            Assert.AreEqual(0, caseListRemovedC3SortDtDescendingDoneAt.Count);
            //Assert.AreEqual(aCase3Removed.type, caseListRemovedC3SortDtDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedC3SortDtDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedC3SortDtDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedC3SortDtDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.custom, caseListRemovedC3SortDtDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedC3SortDtDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Removed.id, caseListRemovedC3SortDtDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedC3SortDtDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedC3SortDtDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase3Removed.site.name, caseListRemovedC3SortDtDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase3Removed.status, caseListRemovedC3SortDtDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase3Removed.check_list_id, caseListRemovedC3SortDtDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedC3SortDtDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedC3SortDtDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.version, caseListRemovedC3SortDtDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedC3SortDtDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedC3SortDtDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRemovedC3SortDtDescendingStatus aCase3Removed

            Assert.NotNull(caseListRemovedC3SortDtDescendingStatus);
            Assert.AreEqual(0, caseListRemovedC3SortDtDescendingStatus.Count);
            //Assert.AreEqual(aCase3Removed.type, caseListRemovedC3SortDtDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedC3SortDtDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedC3SortDtDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedC3SortDtDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.custom, caseListRemovedC3SortDtDescendingStatus[0].Custom);
            //Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedC3SortDtDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Removed.id, caseListRemovedC3SortDtDescendingStatus[0].Id);
            //Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedC3SortDtDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedC3SortDtDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase3Removed.site.name, caseListRemovedC3SortDtDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase3Removed.status, caseListRemovedC3SortDtDescendingStatus[0].Status);
            //Assert.AreEqual(aCase3Removed.check_list_id, caseListRemovedC3SortDtDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedC3SortDtDescendingStatus[0].UnitId);
            //Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedC3SortDtDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.version, caseListRemovedC3SortDtDescendingStatus[0].Version);
            //Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedC3SortDtDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedC3SortDtDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRemovedC3SortDtDescendingUnitId aCase3Removed

            Assert.NotNull(caseListRemovedC3SortDtDescendingUnitId);
            Assert.AreEqual(0, caseListRemovedC3SortDtDescendingUnitId.Count);
            //Assert.AreEqual(aCase3Removed.type, caseListRemovedC3SortDtDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase3Removed.case_uid, caseListRemovedC3SortDtDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase3Removed.microting_check_uid, caseListRemovedC3SortDtDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c3Removed_ca.ToString(), caseListRemovedC3SortDtDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.custom, caseListRemovedC3SortDtDescendingUnitId[0].Custom);
            //Assert.AreEqual(c3Removed_da.ToString(), caseListRemovedC3SortDtDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Removed.id, caseListRemovedC3SortDtDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase3Removed.microting_uid, caseListRemovedC3SortDtDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase3Removed.site.microting_uid, caseListRemovedC3SortDtDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase3Removed.site.name, caseListRemovedC3SortDtDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase3Removed.status, caseListRemovedC3SortDtDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase3Removed.check_list_id, caseListRemovedC3SortDtDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase3Removed.unit.microting_uid, caseListRemovedC3SortDtDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c3Removed_ua.ToString(), caseListRemovedC3SortDtDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Removed.version, caseListRemovedC3SortDtDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase3Removed.worker.first_name + " " + aCase3Removed.worker.last_name, caseListRemovedC3SortDtDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase3Removed.workflow_state, caseListRemovedC3SortDtDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase4Removed Sort Des w. DateTime
            #region caseListRemovedC4SortDtDescendingDoneAt aCase4Removed

            Assert.NotNull(caseListRemovedC4SortDtDescendingDoneAt);
            Assert.AreEqual(0, caseListRemovedC4SortDtDescendingDoneAt.Count);
            //Assert.AreEqual(aCase4Removed.type, caseListRemovedC4SortDtDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedC4SortDtDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedC4SortDtDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedC4SortDtDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.custom, caseListRemovedC4SortDtDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedC4SortDtDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Removed.id, caseListRemovedC4SortDtDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedC4SortDtDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedC4SortDtDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase4Removed.site.name, caseListRemovedC4SortDtDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase4Removed.status, caseListRemovedC4SortDtDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase4Removed.check_list_id, caseListRemovedC4SortDtDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase4Removed.unit.microting_uid, caseListRemovedC4SortDtDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedC4SortDtDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.version, caseListRemovedC4SortDtDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedC4SortDtDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedC4SortDtDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRemovedC4SortDtDescendingStatus aCase4Removed

            Assert.NotNull(caseListRemovedC4SortDtDescendingStatus);
            Assert.AreEqual(0, caseListRemovedC4SortDtDescendingStatus.Count);
            //Assert.AreEqual(aCase4Removed.type, caseListRemovedC4SortDtDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedC4SortDtDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedC4SortDtDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedC4SortDtDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.custom, caseListRemovedC4SortDtDescendingStatus[0].Custom);
            //Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedC4SortDtDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Removed.id, caseListRemovedC4SortDtDescendingStatus[0].Id);
            //Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedC4SortDtDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedC4SortDtDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase4Removed.site.name, caseListRemovedC4SortDtDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase4Removed.status, caseListRemovedC4SortDtDescendingStatus[0].Status);
            //Assert.AreEqual(aCase4Removed.check_list_id, caseListRemovedC4SortDtDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase4Removed.unit.microting_uid, caseListRemovedC4SortDtDescendingStatus[0].UnitId);
            //Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedC4SortDtDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.version, caseListRemovedC4SortDtDescendingStatus[0].Version);
            //Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedC4SortDtDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedC4SortDtDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRemovedC4SortDtDescendingUnitId aCase4Removed

            Assert.NotNull(caseListRemovedC4SortDtDescendingUnitId);
            Assert.AreEqual(0, caseListRemovedC4SortDtDescendingUnitId.Count);
            //Assert.AreEqual(aCase4Removed.type, caseListRemovedC4SortDtDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase4Removed.case_uid, caseListRemovedC4SortDtDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase4Removed.microting_check_uid, caseListRemovedC4SortDtDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c4Removed_ca.ToString(), caseListRemovedC4SortDtDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.custom, caseListRemovedC4SortDtDescendingUnitId[0].Custom);
            //Assert.AreEqual(c4Removed_da.ToString(), caseListRemovedC4SortDtDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Removed.id, caseListRemovedC4SortDtDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase4Removed.microting_uid, caseListRemovedC4SortDtDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase4Removed.site.microting_uid, caseListRemovedC4SortDtDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase4Removed.site.name, caseListRemovedC4SortDtDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase4Removed.status, caseListRemovedC4SortDtDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase4Removed.check_list_id, caseListRemovedC4SortDtDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase4Removed.unit.microting_uid, caseListRemovedC4SortDtDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c4Removed_ua.ToString(), caseListRemovedC4SortDtDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Removed.version, caseListRemovedC4SortDtDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase4Removed.worker.first_name + " " + aCase4Removed.worker.last_name, caseListRemovedC4SortDtDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase4Removed.workflow_state, caseListRemovedC4SortDtDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #endregion

            #endregion

            #endregion

            #region sort by WorkflowState Retracted

            #region Def Sort
            #region Def Sort Asc
            #region caseListRetractedDoneAt Def Sort Asc
            #region caseListRetractedDoneAt aCase1Retracted
            Assert.NotNull(caseListRetractedDoneAt);
            Assert.AreEqual(4, caseListRetractedDoneAt.Count);
            Assert.AreEqual(aCase1Retracted.type, caseListRetractedDoneAt[1].CaseType);
            Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedDoneAt[1].CaseUId);
            Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedDoneAt[1].CheckUIid);
            Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedDoneAt[1].CreatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.custom, caseListRetractedDoneAt[1].Custom);
            Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedDoneAt[1].DoneAt.ToString());
            Assert.AreEqual(aCase1Retracted.id, caseListRetractedDoneAt[1].Id);
            Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedDoneAt[1].MicrotingUId);
            Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedDoneAt[1].SiteId);
            Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedDoneAt[1].SiteName);
            Assert.AreEqual(aCase1Retracted.status, caseListRetractedDoneAt[1].Status);
            Assert.AreEqual(cl1.id, caseListRetractedDoneAt[1].TemplatId);
            Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedDoneAt[1].UnitId);
            Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedDoneAt[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.version, caseListRetractedDoneAt[1].Version);
            Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedDoneAt[1].WorkerName);
            Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedDoneAt[1].WorkflowState);
            #endregion

            #region caseListRetractedDoneAt aCase2Retracted
            Assert.AreEqual(aCase2Retracted.type, caseListRetractedDoneAt[3].CaseType);
            Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedDoneAt[3].CaseUId);
            Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedDoneAt[3].CheckUIid);
            Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedDoneAt[3].CreatedAt.ToString());
            Assert.AreEqual(aCase2Retracted.custom, caseListRetractedDoneAt[3].Custom);
            Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedDoneAt[3].DoneAt.ToString());
            Assert.AreEqual(aCase2Retracted.id, caseListRetractedDoneAt[3].Id);
            Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedDoneAt[3].MicrotingUId);
            Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedDoneAt[3].SiteId);
            Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedDoneAt[3].SiteName);
            Assert.AreEqual(aCase2Retracted.status, caseListRetractedDoneAt[3].Status);
            Assert.AreEqual(cl1.id, caseListRetractedDoneAt[3].TemplatId);
            Assert.AreEqual(aCase2Retracted.unit.microting_uid, caseListRetractedDoneAt[3].UnitId);
            Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedDoneAt[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase2Retracted.version, caseListRetractedDoneAt[3].Version);
            Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedDoneAt[3].WorkerName);
            Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedDoneAt[3].WorkflowState);
            #endregion

            #region caseListRetractedDoneAt aCase3Retracted
            Assert.AreEqual(aCase3Retracted.type, caseListRetractedDoneAt[0].CaseType);
            Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedDoneAt[0].CaseUId);
            Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedDoneAt[0].CheckUIid);
            Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedDoneAt[0].CreatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.custom, caseListRetractedDoneAt[0].Custom);
            Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedDoneAt[0].DoneAt.ToString());
            Assert.AreEqual(aCase3Retracted.id, caseListRetractedDoneAt[0].Id);
            Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedDoneAt[0].MicrotingUId);
            Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedDoneAt[0].SiteId);
            Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedDoneAt[0].SiteName);
            Assert.AreEqual(aCase3Retracted.status, caseListRetractedDoneAt[0].Status);
            Assert.AreEqual(cl1.id, caseListRetractedDoneAt[0].TemplatId);
            Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedDoneAt[0].UnitId);
            Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedDoneAt[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.version, caseListRetractedDoneAt[0].Version);
            Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedDoneAt[0].WorkerName);
            Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedDoneAt[0].WorkflowState);
            #endregion

            #region caseListRetractedDoneAt aCase4Retracted
            Assert.AreEqual(aCase4Retracted.type, caseListRetractedDoneAt[2].CaseType);
            Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedDoneAt[2].CaseUId);
            Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedDoneAt[2].CheckUIid);
            Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedDoneAt[2].CreatedAt.ToString());
            Assert.AreEqual(aCase4Retracted.custom, caseListRetractedDoneAt[2].Custom);
            Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedDoneAt[2].DoneAt.ToString());
            Assert.AreEqual(aCase4Retracted.id, caseListRetractedDoneAt[2].Id);
            Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedDoneAt[2].MicrotingUId);
            Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedDoneAt[2].SiteId);
            Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedDoneAt[2].SiteName);
            Assert.AreEqual(aCase4Retracted.status, caseListRetractedDoneAt[2].Status);
            Assert.AreEqual(cl1.id, caseListRetractedDoneAt[2].TemplatId);
            Assert.AreEqual(aCase4Retracted.unit.microting_uid, caseListRetractedDoneAt[2].UnitId);
            Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedDoneAt[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase4Retracted.version, caseListRetractedDoneAt[2].Version);
            Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedDoneAt[2].WorkerName);
            Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedDoneAt[2].WorkflowState);
            #endregion

            #endregion

            #region caseListRetractedStatus Def Sort Asc

            #region caseListRetractedStatus aCase1Retracted

            Assert.NotNull(caseListRetractedStatus);
            Assert.AreEqual(4, caseListRetractedStatus.Count);
            Assert.AreEqual(aCase1Retracted.type, caseListRetractedStatus[0].CaseType);
            Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedStatus[0].CaseUId);
            Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedStatus[0].CheckUIid);
            Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedStatus[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.custom, caseListRetractedStatus[0].Custom);
            Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedStatus[0].DoneAt.ToString());
            Assert.AreEqual(aCase1Retracted.id, caseListRetractedStatus[0].Id);
            Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedStatus[0].MicrotingUId);
            Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedStatus[0].SiteId);
            Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedStatus[0].SiteName);
            Assert.AreEqual(aCase1Retracted.status, caseListRetractedStatus[0].Status);
            Assert.AreEqual(aCase1Retracted.check_list_id, caseListRetractedStatus[0].TemplatId);
            Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedStatus[0].UnitId);
            Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedStatus[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.version, caseListRetractedStatus[0].Version);
            Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedStatus[0].WorkerName);
            Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedStatus[0].WorkflowState);

            #endregion

            #region caseListRetractedStatus aCase2Retracted

            Assert.AreEqual(aCase2Retracted.type, caseListRetractedStatus[1].CaseType);
            Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedStatus[1].CaseUId);
            Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedStatus[1].CheckUIid);
            Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedStatus[1].CreatedAt.ToString());
            Assert.AreEqual(aCase2Retracted.custom, caseListRetractedStatus[1].Custom);
            Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedStatus[1].DoneAt.ToString());
            Assert.AreEqual(aCase2Retracted.id, caseListRetractedStatus[1].Id);
            Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedStatus[1].MicrotingUId);
            Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedStatus[1].SiteId);
            Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedStatus[1].SiteName);
            Assert.AreEqual(aCase2Retracted.status, caseListRetractedStatus[1].Status);
            Assert.AreEqual(aCase2Retracted.check_list_id, caseListRetractedStatus[1].TemplatId);
            Assert.AreEqual(aCase2Retracted.unit.microting_uid, caseListRetractedStatus[1].UnitId);
            Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedStatus[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase2Retracted.version, caseListRetractedStatus[1].Version);
            Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedStatus[1].WorkerName);
            Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedStatus[1].WorkflowState);

            #endregion

            #region caseListRetractedStatus aCase3Retracted

            Assert.AreEqual(aCase3Retracted.type, caseListRetractedStatus[2].CaseType);
            Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedStatus[2].CaseUId);
            Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedStatus[2].CheckUIid);
            Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedStatus[2].CreatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.custom, caseListRetractedStatus[2].Custom);
            Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedStatus[2].DoneAt.ToString());
            Assert.AreEqual(aCase3Retracted.id, caseListRetractedStatus[2].Id);
            Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedStatus[2].MicrotingUId);
            Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedStatus[2].SiteId);
            Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedStatus[2].SiteName);
            Assert.AreEqual(aCase3Retracted.status, caseListRetractedStatus[2].Status);
            Assert.AreEqual(aCase3Retracted.check_list_id, caseListRetractedStatus[2].TemplatId);
            Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedStatus[2].UnitId);
            Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedStatus[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.version, caseListRetractedStatus[2].Version);
            Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedStatus[2].WorkerName);
            Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedStatus[2].WorkflowState);

            #endregion

            #region caseListRetractedStatus aCase4Retracted

            Assert.AreEqual(aCase4Retracted.type, caseListRetractedStatus[3].CaseType);
            Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedStatus[3].CaseUId);
            Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedStatus[3].CheckUIid);
            Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedStatus[3].CreatedAt.ToString());
            Assert.AreEqual(aCase4Retracted.custom, caseListRetractedStatus[3].Custom);
            Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedStatus[3].DoneAt.ToString());
            Assert.AreEqual(aCase4Retracted.id, caseListRetractedStatus[3].Id);
            Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedStatus[3].MicrotingUId);
            Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedStatus[3].SiteId);
            Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedStatus[3].SiteName);
            Assert.AreEqual(aCase4Retracted.status, caseListRetractedStatus[3].Status);
            Assert.AreEqual(aCase4Retracted.check_list_id, caseListRetractedStatus[3].TemplatId);
            Assert.AreEqual(aCase4Retracted.unit.microting_uid, caseListRetractedStatus[3].UnitId);
            Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedStatus[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase4Retracted.version, caseListRetractedStatus[3].Version);
            Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedStatus[3].WorkerName);
            Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedStatus[3].WorkflowState);

            #endregion

            #endregion

            #region caseListRetractedUnitId Def Sort Asc

            #region caseListRetractedUnitId aCase1Retracted
            Assert.NotNull(caseListRetractedUnitId);
            Assert.AreEqual(4, caseListRetractedUnitId.Count);
            Assert.AreEqual(aCase1Retracted.type, caseListRetractedUnitId[0].CaseType);
            Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedUnitId[0].CaseUId);
            Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedUnitId[0].CheckUIid);
            Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedUnitId[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.custom, caseListRetractedUnitId[0].Custom);
            Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedUnitId[0].DoneAt.ToString());
            Assert.AreEqual(aCase1Retracted.id, caseListRetractedUnitId[0].Id);
            Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedUnitId[0].MicrotingUId);
            Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedUnitId[0].SiteId);
            Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedUnitId[0].SiteName);
            Assert.AreEqual(aCase1Retracted.status, caseListRetractedUnitId[0].Status);
            Assert.AreEqual(aCase1Retracted.check_list_id, caseListRetractedUnitId[0].TemplatId);
            Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedUnitId[0].UnitId);
            Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedUnitId[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.version, caseListRetractedUnitId[0].Version);
            Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedUnitId[0].WorkerName);
            Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedUnitId[0].WorkflowState);

            #endregion

            #region caseListRetractedUnitId aCase2Retracted
            Assert.AreEqual(aCase2Retracted.type, caseListRetractedUnitId[1].CaseType);
            Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedUnitId[1].CaseUId);
            Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedUnitId[1].CheckUIid);
            Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedUnitId[1].CreatedAt.ToString());
            Assert.AreEqual(aCase2Retracted.custom, caseListRetractedUnitId[1].Custom);
            Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedUnitId[1].DoneAt.ToString());
            Assert.AreEqual(aCase2Retracted.id, caseListRetractedUnitId[1].Id);
            Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedUnitId[1].MicrotingUId);
            Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedUnitId[1].SiteId);
            Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedUnitId[1].SiteName);
            Assert.AreEqual(aCase2Retracted.status, caseListRetractedUnitId[1].Status);
            Assert.AreEqual(aCase2Retracted.check_list_id, caseListRetractedUnitId[1].TemplatId);
            Assert.AreEqual(aCase2Retracted.unit.microting_uid, caseListRetractedUnitId[1].UnitId);
            Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedUnitId[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase2Retracted.version, caseListRetractedUnitId[1].Version);
            Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedUnitId[1].WorkerName);
            Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedUnitId[1].WorkflowState);

            #endregion

            #region caseListRetractedUnitId aCase3Retracted
            Assert.AreEqual(aCase3Retracted.type, caseListRetractedUnitId[2].CaseType);
            Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedUnitId[2].CaseUId);
            Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedUnitId[2].CheckUIid);
            Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedUnitId[2].CreatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.custom, caseListRetractedUnitId[2].Custom);
            Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedUnitId[2].DoneAt.ToString());
            Assert.AreEqual(aCase3Retracted.id, caseListRetractedUnitId[2].Id);
            Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedUnitId[2].MicrotingUId);
            Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedUnitId[2].SiteId);
            Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedUnitId[2].SiteName);
            Assert.AreEqual(aCase3Retracted.status, caseListRetractedUnitId[2].Status);
            Assert.AreEqual(aCase3Retracted.check_list_id, caseListRetractedUnitId[2].TemplatId);
            Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedUnitId[2].UnitId);
            Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedUnitId[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.version, caseListRetractedUnitId[2].Version);
            Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedUnitId[2].WorkerName);
            Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedUnitId[2].WorkflowState);

            #endregion

            #region caseListRetractedUnitId aCase4Retracted
            Assert.AreEqual(aCase4Retracted.type, caseListRetractedUnitId[3].CaseType);
            Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedUnitId[3].CaseUId);
            Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedUnitId[3].CheckUIid);
            Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedUnitId[3].CreatedAt.ToString());
            Assert.AreEqual(aCase4Retracted.custom, caseListRetractedUnitId[3].Custom);
            Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedUnitId[3].DoneAt.ToString());
            Assert.AreEqual(aCase4Retracted.id, caseListRetractedUnitId[3].Id);
            Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedUnitId[3].MicrotingUId);
            Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedUnitId[3].SiteId);
            Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedUnitId[3].SiteName);
            Assert.AreEqual(aCase4Retracted.status, caseListRetractedUnitId[3].Status);
            Assert.AreEqual(aCase4Retracted.check_list_id, caseListRetractedUnitId[3].TemplatId);
            Assert.AreEqual(aCase4Retracted.unit.microting_uid, caseListRetractedUnitId[3].UnitId);
            Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedUnitId[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase4Retracted.version, caseListRetractedUnitId[3].Version);
            Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedUnitId[3].WorkerName);
            Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedUnitId[3].WorkflowState);

            #endregion

            #endregion

            #endregion

            #region Def Sort Des
            #region caseListRetractedDescendingDoneAt Def Sort Des
            #region caseListRetractedDescendingDoneAt aCase1Retracted
            Assert.NotNull(caseListRetractedDescendingDoneAt);
            Assert.AreEqual(4, caseListRetractedDescendingDoneAt.Count);
            Assert.AreEqual(aCase1Retracted.type, caseListRetractedDescendingDoneAt[2].CaseType);
            Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedDescendingDoneAt[2].CaseUId);
            Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedDescendingDoneAt[2].CheckUIid);
            Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedDescendingDoneAt[2].CreatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.custom, caseListRetractedDescendingDoneAt[2].Custom);
            Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedDescendingDoneAt[2].DoneAt.ToString());
            Assert.AreEqual(aCase1Retracted.id, caseListRetractedDescendingDoneAt[2].Id);
            Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedDescendingDoneAt[2].MicrotingUId);
            Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedDescendingDoneAt[2].SiteId);
            Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedDescendingDoneAt[2].SiteName);
            Assert.AreEqual(aCase1Retracted.status, caseListRetractedDescendingDoneAt[2].Status);
            Assert.AreEqual(cl1.id, caseListRetractedDescendingDoneAt[2].TemplatId);
            Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedDescendingDoneAt[2].UnitId);
            Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedDescendingDoneAt[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.version, caseListRetractedDescendingDoneAt[2].Version);
            Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedDescendingDoneAt[2].WorkerName);
            Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedDescendingDoneAt[2].WorkflowState);
            #endregion

            #region caseListRetractedDescendingDoneAt aCase2Retracted
            Assert.AreEqual(aCase2Retracted.type, caseListRetractedDescendingDoneAt[0].CaseType);
            Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedDescendingDoneAt[0].CaseUId);
            Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedDescendingDoneAt[0].CheckUIid);
            Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedDescendingDoneAt[0].CreatedAt.ToString());
            Assert.AreEqual(aCase2Retracted.custom, caseListRetractedDescendingDoneAt[0].Custom);
            Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedDescendingDoneAt[0].DoneAt.ToString());
            Assert.AreEqual(aCase2Retracted.id, caseListRetractedDescendingDoneAt[0].Id);
            Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedDescendingDoneAt[0].MicrotingUId);
            Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedDescendingDoneAt[0].SiteId);
            Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedDescendingDoneAt[0].SiteName);
            Assert.AreEqual(aCase2Retracted.status, caseListRetractedDescendingDoneAt[0].Status);
            Assert.AreEqual(cl1.id, caseListRetractedDescendingDoneAt[0].TemplatId);
            Assert.AreEqual(aCase2Retracted.unit.microting_uid, caseListRetractedDescendingDoneAt[0].UnitId);
            Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedDescendingDoneAt[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase2Retracted.version, caseListRetractedDescendingDoneAt[0].Version);
            Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedDescendingDoneAt[0].WorkerName);
            Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedDescendingDoneAt[0].WorkflowState);
            #endregion

            #region caseListRetractedDescendingDoneAt aCase3Retracted
            Assert.AreEqual(aCase3Retracted.type, caseListRetractedDescendingDoneAt[3].CaseType);
            Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedDescendingDoneAt[3].CaseUId);
            Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedDescendingDoneAt[3].CheckUIid);
            Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedDescendingDoneAt[3].CreatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.custom, caseListRetractedDescendingDoneAt[3].Custom);
            Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedDescendingDoneAt[3].DoneAt.ToString());
            Assert.AreEqual(aCase3Retracted.id, caseListRetractedDescendingDoneAt[3].Id);
            Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedDescendingDoneAt[3].MicrotingUId);
            Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedDescendingDoneAt[3].SiteId);
            Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedDescendingDoneAt[3].SiteName);
            Assert.AreEqual(aCase3Retracted.status, caseListRetractedDescendingDoneAt[3].Status);
            Assert.AreEqual(cl1.id, caseListRetractedDescendingDoneAt[3].TemplatId);
            Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedDescendingDoneAt[3].UnitId);
            Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedDescendingDoneAt[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.version, caseListRetractedDescendingDoneAt[3].Version);
            Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedDescendingDoneAt[3].WorkerName);
            Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedDescendingDoneAt[3].WorkflowState);
            #endregion

            #region caseListRetractedDescendingDoneAt aCase4Retracted
            Assert.AreEqual(aCase4Retracted.type, caseListRetractedDescendingDoneAt[1].CaseType);
            Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedDescendingDoneAt[1].CaseUId);
            Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedDescendingDoneAt[1].CheckUIid);
            Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedDescendingDoneAt[1].CreatedAt.ToString());
            Assert.AreEqual(aCase4Retracted.custom, caseListRetractedDescendingDoneAt[1].Custom);
            Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedDescendingDoneAt[1].DoneAt.ToString());
            Assert.AreEqual(aCase4Retracted.id, caseListRetractedDescendingDoneAt[1].Id);
            Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedDescendingDoneAt[1].MicrotingUId);
            Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedDescendingDoneAt[1].SiteId);
            Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedDescendingDoneAt[1].SiteName);
            Assert.AreEqual(aCase4Retracted.status, caseListRetractedDescendingDoneAt[1].Status);
            Assert.AreEqual(cl1.id, caseListRetractedDescendingDoneAt[1].TemplatId);
            Assert.AreEqual(aCase4Retracted.unit.microting_uid, caseListRetractedDescendingDoneAt[1].UnitId);
            Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedDescendingDoneAt[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase4Retracted.version, caseListRetractedDescendingDoneAt[1].Version);
            Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedDescendingDoneAt[1].WorkerName);
            Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedDescendingDoneAt[1].WorkflowState);
            #endregion


            #endregion

            #region caseListRetractedDescendingStatus Def Sort Des

            #region caseListRetractedDescendingStatus aCase1Retracted

            Assert.NotNull(caseListRetractedDescendingStatus);
            Assert.AreEqual(4, caseListRetractedDescendingStatus.Count);
            Assert.AreEqual(aCase1Retracted.type, caseListRetractedDescendingStatus[3].CaseType);
            Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedDescendingStatus[3].CaseUId);
            Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedDescendingStatus[3].CheckUIid);
            Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedDescendingStatus[3].CreatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.custom, caseListRetractedDescendingStatus[3].Custom);
            Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedDescendingStatus[3].DoneAt.ToString());
            Assert.AreEqual(aCase1Retracted.id, caseListRetractedDescendingStatus[3].Id);
            Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedDescendingStatus[3].MicrotingUId);
            Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedDescendingStatus[3].SiteId);
            Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedDescendingStatus[3].SiteName);
            Assert.AreEqual(aCase1Retracted.status, caseListRetractedDescendingStatus[3].Status);
            Assert.AreEqual(aCase1Retracted.check_list_id, caseListRetractedDescendingStatus[3].TemplatId);
            Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedDescendingStatus[3].UnitId);
            Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedDescendingStatus[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.version, caseListRetractedDescendingStatus[3].Version);
            Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedDescendingStatus[3].WorkerName);
            Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedDescendingStatus[3].WorkflowState);

            #endregion

            #region caseListRetractedDescendingStatus aCase2Retracted

            Assert.AreEqual(aCase2Retracted.type, caseListRetractedDescendingStatus[2].CaseType);
            Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedDescendingStatus[2].CaseUId);
            Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedDescendingStatus[2].CheckUIid);
            Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedDescendingStatus[2].CreatedAt.ToString());
            Assert.AreEqual(aCase2Retracted.custom, caseListRetractedDescendingStatus[2].Custom);
            Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedDescendingStatus[2].DoneAt.ToString());
            Assert.AreEqual(aCase2Retracted.id, caseListRetractedDescendingStatus[2].Id);
            Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedDescendingStatus[2].MicrotingUId);
            Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedDescendingStatus[2].SiteId);
            Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedDescendingStatus[2].SiteName);
            Assert.AreEqual(aCase2Retracted.status, caseListRetractedDescendingStatus[2].Status);
            Assert.AreEqual(aCase2Retracted.check_list_id, caseListRetractedDescendingStatus[2].TemplatId);
            Assert.AreEqual(aCase2Retracted.unit.microting_uid, caseListRetractedDescendingStatus[2].UnitId);
            Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedDescendingStatus[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase2Retracted.version, caseListRetractedDescendingStatus[2].Version);
            Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedDescendingStatus[2].WorkerName);
            Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedDescendingStatus[2].WorkflowState);

            #endregion

            #region caseListRetractedDescendingStatus aCase3Retracted

            Assert.AreEqual(aCase3Retracted.type, caseListRetractedDescendingStatus[1].CaseType);
            Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedDescendingStatus[1].CaseUId);
            Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedDescendingStatus[1].CheckUIid);
            Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedDescendingStatus[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.custom, caseListRetractedDescendingStatus[1].Custom);
            Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedDescendingStatus[1].DoneAt.ToString());
            Assert.AreEqual(aCase3Retracted.id, caseListRetractedDescendingStatus[1].Id);
            Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedDescendingStatus[1].MicrotingUId);
            Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedDescendingStatus[1].SiteId);
            Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedDescendingStatus[1].SiteName);
            Assert.AreEqual(aCase3Retracted.status, caseListRetractedDescendingStatus[1].Status);
            Assert.AreEqual(aCase3Retracted.check_list_id, caseListRetractedDescendingStatus[1].TemplatId);
            Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedDescendingStatus[1].UnitId);
            Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedDescendingStatus[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.version, caseListRetractedDescendingStatus[1].Version);
            Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedDescendingStatus[1].WorkerName);
            Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedDescendingStatus[1].WorkflowState);

            #endregion

            #region caseListRetractedDescendingStatus aCase4Retracted

            Assert.AreEqual(aCase4Retracted.type, caseListRetractedDescendingStatus[0].CaseType);
            Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedDescendingStatus[0].CaseUId);
            Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedDescendingStatus[0].CheckUIid);
            Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedDescendingStatus[0].CreatedAt.ToString());
            Assert.AreEqual(aCase4Retracted.custom, caseListRetractedDescendingStatus[0].Custom);
            Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedDescendingStatus[0].DoneAt.ToString());
            Assert.AreEqual(aCase4Retracted.id, caseListRetractedDescendingStatus[0].Id);
            Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedDescendingStatus[0].MicrotingUId);
            Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedDescendingStatus[0].SiteId);
            Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedDescendingStatus[0].SiteName);
            Assert.AreEqual(aCase4Retracted.status, caseListRetractedDescendingStatus[0].Status);
            Assert.AreEqual(aCase4Retracted.check_list_id, caseListRetractedDescendingStatus[0].TemplatId);
            Assert.AreEqual(aCase4Retracted.unit.microting_uid, caseListRetractedDescendingStatus[0].UnitId);
            Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedDescendingStatus[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase4Retracted.version, caseListRetractedDescendingStatus[0].Version);
            Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedDescendingStatus[0].WorkerName);
            Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedDescendingStatus[0].WorkflowState);

            #endregion

            #endregion

            #region caseListRetractedDescendingUnitId Def Sort Des

            #region caseListRetractedDescendingUnitId aCase1Retracted
            Assert.NotNull(caseListRetractedDescendingUnitId);
            Assert.AreEqual(4, caseListRetractedDescendingUnitId.Count);
            Assert.AreEqual(aCase1Retracted.type, caseListRetractedDescendingUnitId[3].CaseType);
            Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedDescendingUnitId[3].CaseUId);
            Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedDescendingUnitId[3].CheckUIid);
            Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedDescendingUnitId[3].CreatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.custom, caseListRetractedDescendingUnitId[3].Custom);
            Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedDescendingUnitId[3].DoneAt.ToString());
            Assert.AreEqual(aCase1Retracted.id, caseListRetractedDescendingUnitId[3].Id);
            Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedDescendingUnitId[3].MicrotingUId);
            Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedDescendingUnitId[3].SiteId);
            Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedDescendingUnitId[3].SiteName);
            Assert.AreEqual(aCase1Retracted.status, caseListRetractedDescendingUnitId[3].Status);
            Assert.AreEqual(aCase1Retracted.check_list_id, caseListRetractedDescendingUnitId[3].TemplatId);
            Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedDescendingUnitId[3].UnitId);
            Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedDescendingUnitId[3].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.version, caseListRetractedDescendingUnitId[3].Version);
            Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedDescendingUnitId[3].WorkerName);
            Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedDescendingUnitId[3].WorkflowState);

            #endregion

            #region caseListRetractedDescendingUnitId aCase2Retracted
            Assert.AreEqual(aCase2Retracted.type, caseListRetractedDescendingUnitId[2].CaseType);
            Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedDescendingUnitId[2].CaseUId);
            Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedDescendingUnitId[2].CheckUIid);
            Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedDescendingUnitId[2].CreatedAt.ToString());
            Assert.AreEqual(aCase2Retracted.custom, caseListRetractedDescendingUnitId[2].Custom);
            Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedDescendingUnitId[2].DoneAt.ToString());
            Assert.AreEqual(aCase2Retracted.id, caseListRetractedDescendingUnitId[2].Id);
            Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedDescendingUnitId[2].MicrotingUId);
            Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedDescendingUnitId[2].SiteId);
            Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedDescendingUnitId[2].SiteName);
            Assert.AreEqual(aCase2Retracted.status, caseListRetractedDescendingUnitId[2].Status);
            Assert.AreEqual(aCase2Retracted.check_list_id, caseListRetractedDescendingUnitId[2].TemplatId);
            Assert.AreEqual(aCase2Retracted.unit.microting_uid, caseListRetractedDescendingUnitId[2].UnitId);
            Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedDescendingUnitId[2].UpdatedAt.ToString());
            Assert.AreEqual(aCase2Retracted.version, caseListRetractedDescendingUnitId[2].Version);
            Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedDescendingUnitId[2].WorkerName);
            Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedDescendingUnitId[2].WorkflowState);

            #endregion

            #region caseListRetractedDescendingUnitId aCase3Retracted
            Assert.AreEqual(aCase3Retracted.type, caseListRetractedDescendingUnitId[1].CaseType);
            Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedDescendingUnitId[1].CaseUId);
            Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedDescendingUnitId[1].CheckUIid);
            Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedDescendingUnitId[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.custom, caseListRetractedDescendingUnitId[1].Custom);
            Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedDescendingUnitId[1].DoneAt.ToString());
            Assert.AreEqual(aCase3Retracted.id, caseListRetractedDescendingUnitId[1].Id);
            Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedDescendingUnitId[1].MicrotingUId);
            Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedDescendingUnitId[1].SiteId);
            Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedDescendingUnitId[1].SiteName);
            Assert.AreEqual(aCase3Retracted.status, caseListRetractedDescendingUnitId[1].Status);
            Assert.AreEqual(aCase3Retracted.check_list_id, caseListRetractedDescendingUnitId[1].TemplatId);
            Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedDescendingUnitId[1].UnitId);
            Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedDescendingUnitId[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.version, caseListRetractedDescendingUnitId[1].Version);
            Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedDescendingUnitId[1].WorkerName);
            Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedDescendingUnitId[1].WorkflowState);

            #endregion

            #region caseListRetractedDescendingUnitId aCase4Retracted
            Assert.AreEqual(aCase4Retracted.type, caseListRetractedDescendingUnitId[0].CaseType);
            Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedDescendingUnitId[0].CaseUId);
            Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedDescendingUnitId[0].CheckUIid);
            Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedDescendingUnitId[0].CreatedAt.ToString());
            Assert.AreEqual(aCase4Retracted.custom, caseListRetractedDescendingUnitId[0].Custom);
            Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedDescendingUnitId[0].DoneAt.ToString());
            Assert.AreEqual(aCase4Retracted.id, caseListRetractedDescendingUnitId[0].Id);
            Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedDescendingUnitId[0].MicrotingUId);
            Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedDescendingUnitId[0].SiteId);
            Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedDescendingUnitId[0].SiteName);
            Assert.AreEqual(aCase4Retracted.status, caseListRetractedDescendingUnitId[0].Status);
            Assert.AreEqual(aCase4Retracted.check_list_id, caseListRetractedDescendingUnitId[0].TemplatId);
            Assert.AreEqual(aCase4Retracted.unit.microting_uid, caseListRetractedDescendingUnitId[0].UnitId);
            Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedDescendingUnitId[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase4Retracted.version, caseListRetractedDescendingUnitId[0].Version);
            Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedDescendingUnitId[0].WorkerName);
            Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedDescendingUnitId[0].WorkflowState);

            #endregion

            #endregion

            #endregion

            #region Def Sort Asc w. DateTime


            #region caseListRetractedDtDoneAt Def Sort Asc w. DateTime
            #region caseListRetractedDtDoneAt aCase1Retracted
            Assert.NotNull(caseListRetractedDtDoneAt);
            Assert.AreEqual(2, caseListRetractedDtDoneAt.Count);
            Assert.AreEqual(aCase1Retracted.type, caseListRetractedDtDoneAt[1].CaseType);
            Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedDtDoneAt[1].CaseUId);
            Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedDtDoneAt[1].CheckUIid);
            Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedDtDoneAt[1].CreatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.custom, caseListRetractedDtDoneAt[1].Custom);
            Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedDtDoneAt[1].DoneAt.ToString());
            Assert.AreEqual(aCase1Retracted.id, caseListRetractedDtDoneAt[1].Id);
            Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedDtDoneAt[1].MicrotingUId);
            Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedDtDoneAt[1].SiteId);
            Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedDtDoneAt[1].SiteName);
            Assert.AreEqual(aCase1Retracted.status, caseListRetractedDtDoneAt[1].Status);
            Assert.AreEqual(cl1.id, caseListRetractedDtDoneAt[1].TemplatId);
            Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedDtDoneAt[1].UnitId);
            Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedDtDoneAt[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.version, caseListRetractedDtDoneAt[1].Version);
            Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedDtDoneAt[1].WorkerName);
            Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedDtDoneAt[1].WorkflowState);
            #endregion

            #region caseListRetractedDtDoneAt aCase3Retracted
            Assert.AreEqual(aCase3Retracted.type, caseListRetractedDtDoneAt[0].CaseType);
            Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedDtDoneAt[0].CaseUId);
            Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedDtDoneAt[0].CheckUIid);
            Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedDtDoneAt[0].CreatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.custom, caseListRetractedDtDoneAt[0].Custom);
            Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedDtDoneAt[0].DoneAt.ToString());
            Assert.AreEqual(aCase3Retracted.id, caseListRetractedDtDoneAt[0].Id);
            Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedDtDoneAt[0].MicrotingUId);
            Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedDtDoneAt[0].SiteId);
            Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedDtDoneAt[0].SiteName);
            Assert.AreEqual(aCase3Retracted.status, caseListRetractedDtDoneAt[0].Status);
            Assert.AreEqual(cl1.id, caseListRetractedDtDoneAt[0].TemplatId);
            Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedDtDoneAt[0].UnitId);
            Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedDtDoneAt[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.version, caseListRetractedDtDoneAt[0].Version);
            Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedDtDoneAt[0].WorkerName);
            Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedDtDoneAt[0].WorkflowState);
            #endregion

            #endregion

            #region caseListRetractedDtStatus Def Sort Asc w. DateTime

            #region caseListRetractedDtStatus aCase1Retracted

            Assert.NotNull(caseListRetractedDtStatus);
            Assert.AreEqual(2, caseListRetractedDtStatus.Count);
            Assert.AreEqual(aCase1Retracted.type, caseListRetractedDtStatus[0].CaseType);
            Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedDtStatus[0].CaseUId);
            Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedDtStatus[0].CheckUIid);
            Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedDtStatus[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.custom, caseListRetractedDtStatus[0].Custom);
            Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedDtStatus[0].DoneAt.ToString());
            Assert.AreEqual(aCase1Retracted.id, caseListRetractedDtStatus[0].Id);
            Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedDtStatus[0].MicrotingUId);
            Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedDtStatus[0].SiteId);
            Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedDtStatus[0].SiteName);
            Assert.AreEqual(aCase1Retracted.status, caseListRetractedDtStatus[0].Status);
            Assert.AreEqual(aCase1Retracted.check_list_id, caseListRetractedDtStatus[0].TemplatId);
            Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedDtStatus[0].UnitId);
            Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedDtStatus[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.version, caseListRetractedDtStatus[0].Version);
            Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedDtStatus[0].WorkerName);
            Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedDtStatus[0].WorkflowState);

            #endregion



            #region caseListRetractedDtStatus aCase3Retracted

            Assert.AreEqual(aCase3Retracted.type, caseListRetractedDtStatus[1].CaseType);
            Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedDtStatus[1].CaseUId);
            Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedDtStatus[1].CheckUIid);
            Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedDtStatus[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.custom, caseListRetractedDtStatus[1].Custom);
            Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedDtStatus[1].DoneAt.ToString());
            Assert.AreEqual(aCase3Retracted.id, caseListRetractedDtStatus[1].Id);
            Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedDtStatus[1].MicrotingUId);
            Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedDtStatus[1].SiteId);
            Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedDtStatus[1].SiteName);
            Assert.AreEqual(aCase3Retracted.status, caseListRetractedDtStatus[1].Status);
            Assert.AreEqual(aCase3Retracted.check_list_id, caseListRetractedDtStatus[1].TemplatId);
            Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedDtStatus[1].UnitId);
            Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedDtStatus[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.version, caseListRetractedDtStatus[1].Version);
            Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedDtStatus[1].WorkerName);
            Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedDtStatus[1].WorkflowState);

            #endregion



            #endregion

            #region caseListRetractedDtUnitId Def Sort Asc w. DateTime

            #region caseListRetractedDtUnitId aCase1Retracted

            Assert.NotNull(caseListRetractedDtUnitId);
            Assert.AreEqual(2, caseListRetractedDtUnitId.Count);
            Assert.AreEqual(aCase1Retracted.type, caseListRetractedDtUnitId[0].CaseType);
            Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedDtUnitId[0].CaseUId);
            Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedDtUnitId[0].CheckUIid);
            Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedDtUnitId[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.custom, caseListRetractedDtUnitId[0].Custom);
            Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedDtUnitId[0].DoneAt.ToString());
            Assert.AreEqual(aCase1Retracted.id, caseListRetractedDtUnitId[0].Id);
            Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedDtUnitId[0].MicrotingUId);
            Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedDtUnitId[0].SiteId);
            Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedDtUnitId[0].SiteName);
            Assert.AreEqual(aCase1Retracted.status, caseListRetractedDtUnitId[0].Status);
            Assert.AreEqual(aCase1Retracted.check_list_id, caseListRetractedDtUnitId[0].TemplatId);
            Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedDtUnitId[0].UnitId);
            Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedDtUnitId[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.version, caseListRetractedDtUnitId[0].Version);
            Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedDtUnitId[0].WorkerName);
            Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedDtUnitId[0].WorkflowState);

            #endregion



            #region caseListRetractedDtUnitId aCase3Retracted

            Assert.AreEqual(aCase3Retracted.type, caseListRetractedDtUnitId[1].CaseType);
            Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedDtUnitId[1].CaseUId);
            Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedDtUnitId[1].CheckUIid);
            Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedDtUnitId[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.custom, caseListRetractedDtUnitId[1].Custom);
            Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedDtUnitId[1].DoneAt.ToString());
            Assert.AreEqual(aCase3Retracted.id, caseListRetractedDtUnitId[1].Id);
            Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedDtUnitId[1].MicrotingUId);
            Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedDtUnitId[1].SiteId);
            Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedDtUnitId[1].SiteName);
            Assert.AreEqual(aCase3Retracted.status, caseListRetractedDtUnitId[1].Status);
            Assert.AreEqual(aCase3Retracted.check_list_id, caseListRetractedDtUnitId[1].TemplatId);
            Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedDtUnitId[1].UnitId);
            Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedDtUnitId[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.version, caseListRetractedDtUnitId[1].Version);
            Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedDtUnitId[1].WorkerName);
            Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedDtUnitId[1].WorkflowState);

            #endregion



            #endregion

            #endregion

            #region Def Sort Des w. DateTime
            #region caseListRetractedDtDescendingDoneAt Def Sort Des
            #region caseListRetractedDtDescendingDoneAt aCase1Retracted

            Assert.NotNull(caseListRetractedDtDescendingDoneAt);
            Assert.AreEqual(2, caseListRetractedDtDescendingDoneAt.Count);
            Assert.AreEqual(aCase1Retracted.type, caseListRetractedDtDescendingDoneAt[0].CaseType);
            Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedDtDescendingDoneAt[0].CaseUId);
            Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedDtDescendingDoneAt[0].CheckUIid);
            Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedDtDescendingDoneAt[0].CreatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.custom, caseListRetractedDtDescendingDoneAt[0].Custom);
            Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedDtDescendingDoneAt[0].DoneAt.ToString());
            Assert.AreEqual(aCase1Retracted.id, caseListRetractedDtDescendingDoneAt[0].Id);
            Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedDtDescendingDoneAt[0].MicrotingUId);
            Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedDtDescendingDoneAt[0].SiteId);
            Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedDtDescendingDoneAt[0].SiteName);
            Assert.AreEqual(aCase1Retracted.status, caseListRetractedDtDescendingDoneAt[0].Status);
            Assert.AreEqual(cl1.id, caseListRetractedDtDescendingDoneAt[0].TemplatId);
            Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedDtDescendingDoneAt[0].UnitId);
            Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedDtDescendingDoneAt[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.version, caseListRetractedDtDescendingDoneAt[0].Version);
            Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedDtDescendingDoneAt[0].WorkerName);
            Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedDtDescendingDoneAt[0].WorkflowState);
            #endregion

            #region caseListRetractedDtDescendingDoneAt aCase3Retracted

            Assert.AreEqual(aCase3Retracted.type, caseListRetractedDtDescendingDoneAt[1].CaseType);
            Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedDtDescendingDoneAt[1].CaseUId);
            Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedDtDescendingDoneAt[1].CheckUIid);
            Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedDtDescendingDoneAt[1].CreatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.custom, caseListRetractedDtDescendingDoneAt[1].Custom);
            Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedDtDescendingDoneAt[1].DoneAt.ToString());
            Assert.AreEqual(aCase3Retracted.id, caseListRetractedDtDescendingDoneAt[1].Id);
            Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedDtDescendingDoneAt[1].MicrotingUId);
            Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedDtDescendingDoneAt[1].SiteId);
            Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedDtDescendingDoneAt[1].SiteName);
            Assert.AreEqual(aCase3Retracted.status, caseListRetractedDtDescendingDoneAt[1].Status);
            Assert.AreEqual(cl1.id, caseListRetractedDtDescendingDoneAt[1].TemplatId);
            Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedDtDescendingDoneAt[1].UnitId);
            Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedDtDescendingDoneAt[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.version, caseListRetractedDtDescendingDoneAt[1].Version);
            Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedDtDescendingDoneAt[1].WorkerName);
            Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedDtDescendingDoneAt[1].WorkflowState);
            #endregion

            #endregion

            #region caseListRetractedDtDescendingStatus Def Sort Des

            #region caseListRetractedDtDescendingStatus aCase1Retracted

            Assert.NotNull(caseListRetractedDtDescendingStatus);
            Assert.AreEqual(2, caseListRetractedDtDescendingStatus.Count);
            Assert.AreEqual(aCase3Retracted.type, caseListRetractedDtDescendingStatus[0].CaseType);
            Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedDtDescendingStatus[0].CaseUId);
            Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedDtDescendingStatus[0].CheckUIid);
            Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedDtDescendingStatus[0].CreatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.custom, caseListRetractedDtDescendingStatus[0].Custom);
            Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedDtDescendingStatus[0].DoneAt.ToString());
            Assert.AreEqual(aCase3Retracted.id, caseListRetractedDtDescendingStatus[0].Id);
            Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedDtDescendingStatus[0].MicrotingUId);
            Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedDtDescendingStatus[0].SiteId);
            Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedDtDescendingStatus[0].SiteName);
            Assert.AreEqual(aCase3Retracted.status, caseListRetractedDtDescendingStatus[0].Status);
            Assert.AreEqual(aCase3Retracted.check_list_id, caseListRetractedDtDescendingStatus[0].TemplatId);
            Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedDtDescendingStatus[0].UnitId);
            Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedDtDescendingStatus[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.version, caseListRetractedDtDescendingStatus[0].Version);
            Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedDtDescendingStatus[0].WorkerName);
            Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedDtDescendingStatus[0].WorkflowState);
            #endregion

            #region caseListRetractedDtDescendingStatus aCase3Retracted

            Assert.AreEqual(aCase1Retracted.type, caseListRetractedDtDescendingStatus[1].CaseType);
            Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedDtDescendingStatus[1].CaseUId);
            Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedDtDescendingStatus[1].CheckUIid);
            Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedDtDescendingStatus[1].CreatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.custom, caseListRetractedDtDescendingStatus[1].Custom);
            Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedDtDescendingStatus[1].DoneAt.ToString());
            Assert.AreEqual(aCase1Retracted.id, caseListRetractedDtDescendingStatus[1].Id);
            Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedDtDescendingStatus[1].MicrotingUId);
            Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedDtDescendingStatus[1].SiteId);
            Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedDtDescendingStatus[1].SiteName);
            Assert.AreEqual(aCase1Retracted.status, caseListRetractedDtDescendingStatus[1].Status);
            Assert.AreEqual(aCase1Retracted.check_list_id, caseListRetractedDtDescendingStatus[1].TemplatId);
            Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedDtDescendingStatus[1].UnitId);
            Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedDtDescendingStatus[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.version, caseListRetractedDtDescendingStatus[1].Version);
            Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedDtDescendingStatus[1].WorkerName);
            Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedDtDescendingStatus[1].WorkflowState);

            #endregion


            #endregion

            #region caseListRetractedDtDescendingUnitId Def Sort Des

            #region caseListRetractedDtDescendingUnitId aCase1Retracted
            Assert.NotNull(caseListRetractedDtDescendingUnitId);
            Assert.AreEqual(2, caseListRetractedDtDescendingUnitId.Count);

            Assert.AreEqual(aCase3Retracted.type, caseListRetractedDtDescendingUnitId[0].CaseType);
            Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedDtDescendingUnitId[0].CaseUId);
            Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedDtDescendingUnitId[0].CheckUIid);
            Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedDtDescendingUnitId[0].CreatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.custom, caseListRetractedDtDescendingUnitId[0].Custom);
            Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedDtDescendingUnitId[0].DoneAt.ToString());
            Assert.AreEqual(aCase3Retracted.id, caseListRetractedDtDescendingUnitId[0].Id);
            Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedDtDescendingUnitId[0].MicrotingUId);
            Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedDtDescendingUnitId[0].SiteId);
            Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedDtDescendingUnitId[0].SiteName);
            Assert.AreEqual(aCase3Retracted.status, caseListRetractedDtDescendingUnitId[0].Status);
            Assert.AreEqual(aCase3Retracted.check_list_id, caseListRetractedDtDescendingUnitId[0].TemplatId);
            Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedDtDescendingUnitId[0].UnitId);
            Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedDtDescendingUnitId[0].UpdatedAt.ToString());
            Assert.AreEqual(aCase3Retracted.version, caseListRetractedDtDescendingUnitId[0].Version);
            Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedDtDescendingUnitId[0].WorkerName);
            Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedDtDescendingUnitId[0].WorkflowState);

            #endregion

            #region caseListRetractedDtDescendingUnitId aCase3Retracted
            Assert.AreEqual(aCase1Retracted.type, caseListRetractedDtDescendingUnitId[1].CaseType);
            Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedDtDescendingUnitId[1].CaseUId);
            Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedDtDescendingUnitId[1].CheckUIid);
            Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedDtDescendingUnitId[1].CreatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.custom, caseListRetractedDtDescendingUnitId[1].Custom);
            Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedDtDescendingUnitId[1].DoneAt.ToString());
            Assert.AreEqual(aCase1Retracted.id, caseListRetractedDtDescendingUnitId[1].Id);
            Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedDtDescendingUnitId[1].MicrotingUId);
            Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedDtDescendingUnitId[1].SiteId);
            Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedDtDescendingUnitId[1].SiteName);
            Assert.AreEqual(aCase1Retracted.status, caseListRetractedDtDescendingUnitId[1].Status);
            Assert.AreEqual(aCase1Retracted.check_list_id, caseListRetractedDtDescendingUnitId[1].TemplatId);
            Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedDtDescendingUnitId[1].UnitId);
            Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedDtDescendingUnitId[1].UpdatedAt.ToString());
            Assert.AreEqual(aCase1Retracted.version, caseListRetractedDtDescendingUnitId[1].Version);
            Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedDtDescendingUnitId[1].WorkerName);
            Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedDtDescendingUnitId[1].WorkflowState);

            #endregion

            #endregion

            #endregion

            #endregion

            #region Case Sort 

            #region aCase Sort Asc

            #region aCase1Retracted sort asc

            #region caseListC1DoneAt aCase1Retracted
            Assert.NotNull(caseListRetractedC1SortDoneAt);
            Assert.AreEqual(0, caseListRetractedC1SortDoneAt.Count);
            //Assert.AreEqual(aCase1Retracted.type, caseListRetractedC1SortDoneAt[0].CaseType);
            //Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedC1SortDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedC1SortDoneAt[0].CheckUIid);
            //Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedC1SortDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.custom, caseListRetractedC1SortDoneAt[0].Custom);
            //Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedC1SortDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Retracted.id, caseListRetractedC1SortDoneAt[0].Id);
            //Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedC1SortDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedC1SortDoneAt[0].SiteId);
            //Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedC1SortDoneAt[0].SiteName);
            //Assert.AreEqual(aCase1Retracted.status, caseListRetractedC1SortDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC1SortDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase1Retracted.unit.id, caseListRetractedC1SortDoneAt[0].UnitId);
            //Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedC1SortDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.version, caseListRetractedC1SortDoneAt[0].Version);
            //Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedC1SortDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedC1SortDoneAt[0].WorkflowState);
            #endregion

            #region caseListRetractedC1SortStatus aCase1Retracted
            Assert.NotNull(caseListRetractedC1SortStatus);
            Assert.AreEqual(0, caseListRetractedC1SortStatus.Count);
            //Assert.AreEqual(aCase1Retracted.type, caseListRetractedC1SortStatus[0].CaseType);
            //Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedC1SortStatus[0].CaseUId);
            //Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedC1SortStatus[0].CheckUIid);
            //Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedC1SortStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.custom, caseListRetractedC1SortStatus[0].Custom);
            //Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedC1SortStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Retracted.id, caseListRetractedC1SortStatus[0].Id);
            //Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedC1SortStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedC1SortStatus[0].SiteId);
            //Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedC1SortStatus[0].SiteName);
            //Assert.AreEqual(aCase1Retracted.status, caseListRetractedC1SortStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC1SortStatus[0].TemplatId);
            //Assert.AreEqual(aCase1Retracted.unit.id, caseListRetractedC1SortStatus[0].UnitId);
            //Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedC1SortStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.version, caseListRetractedC1SortStatus[0].Version);
            //Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedC1SortStatus[0].WorkerName);
            //Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedC1SortStatus[0].WorkflowState);
            #endregion

            #region caseListRetractedC1SortUnitId

            Assert.NotNull(caseListRetractedC1SortUnitId);
            Assert.AreEqual(0, caseListRetractedC1SortUnitId.Count);
            //Assert.AreEqual(aCase1Retracted.type, caseListRetractedC1SortUnitId[0].CaseType);
            //Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedC1SortUnitId[0].CaseUId);
            //Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedC1SortUnitId[0].CheckUIid);
            //Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedC1SortUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.custom, caseListRetractedC1SortUnitId[0].Custom);
            //Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedC1SortUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Retracted.id, caseListRetractedC1SortUnitId[0].Id);
            //Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedC1SortUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedC1SortUnitId[0].SiteId);
            //Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedC1SortUnitId[0].SiteName);
            //Assert.AreEqual(aCase1Retracted.status, caseListRetractedC1SortUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC1SortUnitId[0].TemplatId);
            //Assert.AreEqual(aCase1Retracted.unit.id, caseListRetractedC1SortUnitId[0].UnitId);
            //Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedC1SortUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.version, caseListRetractedC1SortUnitId[0].Version);
            //Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedC1SortUnitId[0].WorkerName);
            //Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedC1SortUnitId[0].WorkflowState);

            #endregion

            #endregion

            #region aCase2Retracted sort asc

            #region caseListC2DoneAt aCase2Retracted
            Assert.NotNull(caseListRetractedC2SortDoneAt);
            Assert.AreEqual(0, caseListRetractedC2SortDoneAt.Count);
            //Assert.AreEqual(aCase2Retracted.type, caseListRetractedC2SortDoneAt[0].CaseType);
            //Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedC2SortDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedC2SortDoneAt[0].CheckUIid);
            //Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedC2SortDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.custom, caseListRetractedC2SortDoneAt[0].Custom);
            //Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedC2SortDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Retracted.id, caseListRetractedC2SortDoneAt[0].Id);
            //Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedC2SortDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedC2SortDoneAt[0].SiteId);
            //Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedC2SortDoneAt[0].SiteName);
            //Assert.AreEqual(aCase2Retracted.status, caseListRetractedC2SortDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC2SortDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase2Retracted.unit.id, caseListRetractedC2SortDoneAt[0].UnitId);
            //Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedC2SortDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.version, caseListRetractedC2SortDoneAt[0].Version);
            //Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedC2SortDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedC2SortDoneAt[0].WorkflowState);
            #endregion

            #region caseListRetractedC2SortStatus aCase2Retracted
            Assert.NotNull(caseListRetractedC2SortStatus);
            Assert.AreEqual(0, caseListRetractedC2SortStatus.Count);
            //Assert.AreEqual(aCase2Retracted.type, caseListRetractedC2SortStatus[0].CaseType);
            //Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedC2SortStatus[0].CaseUId);
            //Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedC2SortStatus[0].CheckUIid);
            //Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedC2SortStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.custom, caseListRetractedC2SortStatus[0].Custom);
            //Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedC2SortStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Retracted.id, caseListRetractedC2SortStatus[0].Id);
            //Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedC2SortStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedC2SortStatus[0].SiteId);
            //Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedC2SortStatus[0].SiteName);
            //Assert.AreEqual(aCase2Retracted.status, caseListRetractedC2SortStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC2SortStatus[0].TemplatId);
            //Assert.AreEqual(aCase2Retracted.unit.id, caseListRetractedC2SortStatus[0].UnitId);
            //Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedC2SortStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.version, caseListRetractedC2SortStatus[0].Version);
            //Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedC2SortStatus[0].WorkerName);
            //Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedC2SortStatus[0].WorkflowState);
            #endregion

            #region caseListRetractedC2SortUnitId aCase2Retracted
            Assert.NotNull(caseListRetractedC2SortUnitId);
            Assert.AreEqual(0, caseListRetractedC2SortUnitId.Count);
            //Assert.AreEqual(aCase2Retracted.type, caseListRetractedC2SortUnitId[0].CaseType);
            //Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedC2SortUnitId[0].CaseUId);
            //Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedC2SortUnitId[0].CheckUIid);
            //Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedC2SortUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.custom, caseListRetractedC2SortUnitId[0].Custom);
            //Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedC2SortUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Retracted.id, caseListRetractedC2SortUnitId[0].Id);
            //Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedC2SortUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedC2SortUnitId[0].SiteId);
            //Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedC2SortUnitId[0].SiteName);
            //Assert.AreEqual(aCase2Retracted.status, caseListRetractedC2SortUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC2SortUnitId[0].TemplatId);
            //Assert.AreEqual(aCase2Retracted.unit.id, caseListRetractedC2SortUnitId[0].UnitId);
            //Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedC2SortUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.version, caseListRetractedC2SortUnitId[0].Version);
            //Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedC2SortUnitId[0].WorkerName);
            //Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedC2SortUnitId[0].WorkflowState);
            #endregion

            #endregion

            #region aCase3Retracted sort asc

            #region caseListC3DoneAt aCase3Retracted
            Assert.NotNull(caseListRetractedC3SortDoneAt);
            Assert.AreEqual(0, caseListRetractedC3SortDoneAt.Count);
            //Assert.AreEqual(aCase3Retracted.type, caseListRetractedC3SortDoneAt[0].CaseType);
            //Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedC3SortDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedC3SortDoneAt[0].CheckUIid);
            //Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedC3SortDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.custom, caseListRetractedC3SortDoneAt[0].Custom);
            //Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedC3SortDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Retracted.id, caseListRetractedC3SortDoneAt[0].Id);
            //Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedC3SortDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedC3SortDoneAt[0].SiteId);
            //Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedC3SortDoneAt[0].SiteName);
            //Assert.AreEqual(aCase3Retracted.status, caseListRetractedC3SortDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC3SortDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase3Retracted.unit.id, caseListRetractedC3SortDoneAt[0].UnitId);
            //Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedC3SortDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.version, caseListRetractedC3SortDoneAt[0].Version);
            //Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedC3SortDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedC3SortDoneAt[0].WorkflowState);
            #endregion

            #region caseListC3status aCase3Retracted
            Assert.NotNull(caseListRetractedC3SortStatus);
            Assert.AreEqual(0, caseListRetractedC3SortStatus.Count);
            //Assert.AreEqual(aCase3Retracted.type, caseListRetractedC3SortStatus[0].CaseType);
            //Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedC3SortStatus[0].CaseUId);
            //Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedC3SortStatus[0].CheckUIid);
            //Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedC3SortStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.custom, caseListRetractedC3SortStatus[0].Custom);
            //Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedC3SortStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Retracted.id, caseListRetractedC3SortStatus[0].Id);
            //Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedC3SortStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedC3SortStatus[0].SiteId);
            //Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedC3SortStatus[0].SiteName);
            //Assert.AreEqual(aCase3Retracted.status, caseListRetractedC3SortStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC3SortStatus[0].TemplatId);
            //Assert.AreEqual(aCase3Retracted.unit.id, caseListRetractedC3SortStatus[0].UnitId);
            //Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedC3SortStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.version, caseListRetractedC3SortStatus[0].Version);
            //Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedC3SortStatus[0].WorkerName);
            //Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedC3SortStatus[0].WorkflowState);
            #endregion

            #region caseListC3UnitId aCase3Retracted
            Assert.NotNull(caseListRetractedC3SortUnitId);
            Assert.AreEqual(0, caseListRetractedC3SortUnitId.Count);
            //Assert.AreEqual(aCase3Retracted.type, caseListRetractedC3SortUnitId[0].CaseType);
            //Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedC3SortUnitId[0].CaseUId);
            //Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedC3SortUnitId[0].CheckUIid);
            //Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedC3SortUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.custom, caseListRetractedC3SortUnitId[0].Custom);
            //Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedC3SortUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Retracted.id, caseListRetractedC3SortUnitId[0].Id);
            //Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedC3SortUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedC3SortUnitId[0].SiteId);
            //Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedC3SortUnitId[0].SiteName);
            //Assert.AreEqual(aCase3Retracted.status, caseListRetractedC3SortUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC3SortUnitId[0].TemplatId);
            //Assert.AreEqual(aCase3Retracted.unit.id, caseListRetractedC3SortUnitId[0].UnitId);
            //Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedC3SortUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.version, caseListRetractedC3SortUnitId[0].Version);
            //Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedC3SortUnitId[0].WorkerName);
            //Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedC3SortUnitId[0].WorkflowState);
            #endregion

            #endregion

            #region aCase4Retracted sort asc

            #region caseListRetractedC4SortDoneAt aCase4Retracted
            Assert.NotNull(caseListRetractedC4SortDoneAt);
            Assert.AreEqual(0, caseListRetractedC4SortDoneAt.Count);
            //Assert.AreEqual(aCase4Retracted.type, caseListRetractedC4SortDoneAt[0].CaseType);
            //Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedC4SortDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedC4SortDoneAt[0].CheckUIid);
            //Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedC4SortDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.custom, caseListRetractedC4SortDoneAt[0].Custom);
            //Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedC4SortDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Retracted.id, caseListRetractedC4SortDoneAt[0].Id);
            //Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedC4SortDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedC4SortDoneAt[0].SiteId);
            //Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedC4SortDoneAt[0].SiteName);
            //Assert.AreEqual(aCase4Retracted.status, caseListRetractedC4SortDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC4SortDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase4Retracted.unit.id, caseListRetractedC4SortDoneAt[0].UnitId);
            //Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedC4SortDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.version, caseListRetractedC4SortDoneAt[0].Version);
            //Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedC4SortDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedC4SortDoneAt[0].WorkflowState);
            #endregion

            #region caseListRetractedC4SortStatus aCase4Retracted
            Assert.NotNull(caseListRetractedC4SortStatus);
            Assert.AreEqual(0, caseListRetractedC4SortStatus.Count);
            //Assert.AreEqual(aCase4Retracted.type, caseListRetractedC4SortStatus[0].CaseType);
            //Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedC4SortStatus[0].CaseUId);
            //Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedC4SortStatus[0].CheckUIid);
            //Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedC4SortStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.custom, caseListRetractedC4SortStatus[0].Custom);
            //Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedC4SortStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Retracted.id, caseListRetractedC4SortStatus[0].Id);
            //Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedC4SortStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedC4SortStatus[0].SiteId);
            //Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedC4SortStatus[0].SiteName);
            //Assert.AreEqual(aCase4Retracted.status, caseListRetractedC4SortStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC4SortStatus[0].TemplatId);
            //Assert.AreEqual(aCase4Retracted.unit.id, caseListRetractedC4SortStatus[0].UnitId);
            //Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedC4SortStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.version, caseListRetractedC4SortStatus[0].Version);
            //Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedC4SortStatus[0].WorkerName);
            //Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedC4SortStatus[0].WorkflowState);
            #endregion

            #region caseListRetractedC4SortUnitId aCase4Retracted

            Assert.NotNull(caseListRetractedC4SortUnitId);
            Assert.AreEqual(0, caseListRetractedC4SortUnitId.Count);
            //Assert.AreEqual(aCase4Retracted.type, caseListRetractedC4SortUnitId[0].CaseType);
            //Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedC4SortUnitId[0].CaseUId);
            //Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedC4SortUnitId[0].CheckUIid);
            //Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedC4SortUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.custom, caseListRetractedC4SortUnitId[0].Custom);
            //Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedC4SortUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Retracted.id, caseListRetractedC4SortUnitId[0].Id);
            //Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedC4SortUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedC4SortUnitId[0].SiteId);
            //Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedC4SortUnitId[0].SiteName);
            //Assert.AreEqual(aCase4Retracted.status, caseListRetractedC4SortUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC4SortUnitId[0].TemplatId);
            //Assert.AreEqual(aCase4Retracted.unit.id, caseListRetractedC4SortUnitId[0].UnitId);
            //Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedC4SortUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.version, caseListRetractedC4SortUnitId[0].Version);
            //Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedC4SortUnitId[0].WorkerName);
            //Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedC4SortUnitId[0].WorkflowState);

            #endregion

            #endregion

            #endregion

            #region aCase Sort Des

            #region aCase1Retracted Sort Des
            #region caseListRetractedC1SortDescendingDoneAt aCase1Retracted

            Assert.NotNull(caseListRetractedC1SortDescendingDoneAt);
            Assert.AreEqual(0, caseListRetractedC1SortDescendingDoneAt.Count);
            //Assert.AreEqual(aCase1Retracted.type, caseListRetractedC1SortDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedC1SortDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedC1SortDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedC1SortDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.custom, caseListRetractedC1SortDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedC1SortDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Retracted.id, caseListRetractedC1SortDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedC1SortDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedC1SortDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedC1SortDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase1Retracted.status, caseListRetractedC1SortDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase1Retracted.check_list_id, caseListRetractedC1SortDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedC1SortDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedC1SortDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.version, caseListRetractedC1SortDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedC1SortDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedC1SortDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRetractedC1SortDescendingStatus aCase1Retracted

            Assert.NotNull(caseListRetractedC1SortDescendingStatus);
            Assert.AreEqual(0, caseListRetractedC1SortDescendingStatus.Count);
            //Assert.AreEqual(aCase1Retracted.type, caseListRetractedC1SortDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedC1SortDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedC1SortDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedC1SortDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.custom, caseListRetractedC1SortDescendingStatus[0].Custom);
            //Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedC1SortDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Retracted.id, caseListRetractedC1SortDescendingStatus[0].Id);
            //Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedC1SortDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedC1SortDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedC1SortDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase1Retracted.status, caseListRetractedC1SortDescendingStatus[0].Status);
            //Assert.AreEqual(aCase1Retracted.check_list_id, caseListRetractedC1SortDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedC1SortDescendingStatus[0].UnitId);
            //Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedC1SortDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.version, caseListRetractedC1SortDescendingStatus[0].Version);
            //Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedC1SortDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedC1SortDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRetractedC1SortDescendingUnitId aCase1Retracted

            Assert.NotNull(caseListRetractedC1SortDescendingUnitId);
            Assert.AreEqual(0, caseListRetractedC1SortDescendingUnitId.Count);
            //Assert.AreEqual(aCase1Retracted.type, caseListRetractedC1SortDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedC1SortDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedC1SortDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedC1SortDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.custom, caseListRetractedC1SortDescendingUnitId[0].Custom);
            //Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedC1SortDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Retracted.id, caseListRetractedC1SortDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedC1SortDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedC1SortDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedC1SortDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase1Retracted.status, caseListRetractedC1SortDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase1Retracted.check_list_id, caseListRetractedC1SortDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedC1SortDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedC1SortDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.version, caseListRetractedC1SortDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedC1SortDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedC1SortDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase2Retracted Sort Des
            #region caseListRetractedC2SortDescendingDoneAt aCase2Retracted

            Assert.NotNull(caseListRetractedC2SortDescendingDoneAt);
            Assert.AreEqual(0, caseListRetractedC2SortDescendingDoneAt.Count);
            //Assert.AreEqual(aCase2Retracted.type, caseListRetractedC2SortDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedC2SortDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedC2SortDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedC2SortDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.custom, caseListRetractedC2SortDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedC2SortDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Retracted.id, caseListRetractedC2SortDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedC2SortDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedC2SortDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedC2SortDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase2Retracted.status, caseListRetractedC2SortDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase2Retracted.check_list_id, caseListRetractedC2SortDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase2Retracted.unit.microting_uid, caseListRetractedC2SortDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedC2SortDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.version, caseListRetractedC2SortDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedC2SortDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedC2SortDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRetractedC2SortDescendingStatus aCase2Retracted

            Assert.NotNull(caseListRetractedC2SortDescendingStatus);
            Assert.AreEqual(0, caseListRetractedC2SortDescendingStatus.Count);
            //Assert.AreEqual(aCase2Retracted.type, caseListRetractedC2SortDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedC2SortDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedC2SortDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedC2SortDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.custom, caseListRetractedC2SortDescendingStatus[0].Custom);
            //Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedC2SortDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Retracted.id, caseListRetractedC2SortDescendingStatus[0].Id);
            //Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedC2SortDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedC2SortDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedC2SortDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase2Retracted.status, caseListRetractedC2SortDescendingStatus[0].Status);
            //Assert.AreEqual(aCase2Retracted.check_list_id, caseListRetractedC2SortDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase2Retracted.unit.microting_uid, caseListRetractedC2SortDescendingStatus[0].UnitId);
            //Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedC2SortDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.version, caseListRetractedC2SortDescendingStatus[0].Version);
            //Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedC2SortDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedC2SortDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRetractedC2SortDescendingUnitId aCase2Retracted

            Assert.NotNull(caseListRetractedC2SortDescendingUnitId);
            Assert.AreEqual(0, caseListRetractedC2SortDescendingUnitId.Count);
            //Assert.AreEqual(aCase2Retracted.type, caseListRetractedC2SortDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedC2SortDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedC2SortDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedC2SortDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.custom, caseListRetractedC2SortDescendingUnitId[0].Custom);
            //Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedC2SortDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Retracted.id, caseListRetractedC2SortDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedC2SortDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedC2SortDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedC2SortDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase2Retracted.status, caseListRetractedC2SortDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase2Retracted.check_list_id, caseListRetractedC2SortDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase2Retracted.unit.microting_uid, caseListRetractedC2SortDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedC2SortDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.version, caseListRetractedC2SortDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedC2SortDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedC2SortDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase3Retracted Sort Des
            #region caseListRetractedC3SortDescendingDoneAt aCase3Retracted

            Assert.NotNull(caseListRetractedC3SortDescendingDoneAt);
            Assert.AreEqual(0, caseListRetractedC3SortDescendingDoneAt.Count);
            //Assert.AreEqual(aCase3Retracted.type, caseListRetractedC3SortDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedC3SortDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedC3SortDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedC3SortDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.custom, caseListRetractedC3SortDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedC3SortDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Retracted.id, caseListRetractedC3SortDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedC3SortDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedC3SortDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedC3SortDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase3Retracted.status, caseListRetractedC3SortDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase3Retracted.check_list_id, caseListRetractedC3SortDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedC3SortDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedC3SortDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.version, caseListRetractedC3SortDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedC3SortDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedC3SortDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRetractedC3SortDescendingStatus aCase3Retracted

            Assert.NotNull(caseListRetractedC3SortDescendingStatus);
            Assert.AreEqual(0, caseListRetractedC3SortDescendingStatus.Count);
            //Assert.AreEqual(aCase3Retracted.type, caseListRetractedC3SortDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedC3SortDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedC3SortDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedC3SortDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.custom, caseListRetractedC3SortDescendingStatus[0].Custom);
            //Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedC3SortDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Retracted.id, caseListRetractedC3SortDescendingStatus[0].Id);
            //Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedC3SortDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedC3SortDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedC3SortDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase3Retracted.status, caseListRetractedC3SortDescendingStatus[0].Status);
            //Assert.AreEqual(aCase3Retracted.check_list_id, caseListRetractedC3SortDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedC3SortDescendingStatus[0].UnitId);
            //Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedC3SortDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.version, caseListRetractedC3SortDescendingStatus[0].Version);
            //Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedC3SortDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedC3SortDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRetractedC3SortDescendingUnitId aCase3Retracted

            Assert.NotNull(caseListRetractedC3SortDescendingUnitId);
            Assert.AreEqual(0, caseListRetractedC3SortDescendingUnitId.Count);
            //Assert.AreEqual(aCase3Retracted.type, caseListRetractedC3SortDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedC3SortDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedC3SortDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedC3SortDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.custom, caseListRetractedC3SortDescendingUnitId[0].Custom);
            //Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedC3SortDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Retracted.id, caseListRetractedC3SortDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedC3SortDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedC3SortDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedC3SortDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase3Retracted.status, caseListRetractedC3SortDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase3Retracted.check_list_id, caseListRetractedC3SortDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedC3SortDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedC3SortDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.version, caseListRetractedC3SortDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedC3SortDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedC3SortDescendingUnitId[0].WorkflowState);

            #endregion

            #endregion

            #region aCase4Retracted Sort Des
            #region caseListRetractedC4SortDescendingDoneAt aCase4Retracted

            Assert.NotNull(caseListRetractedC4SortDescendingDoneAt);
            Assert.AreEqual(0, caseListRetractedC4SortDescendingDoneAt.Count);
            //Assert.AreEqual(aCase4Retracted.type, caseListRetractedC4SortDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedC4SortDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedC4SortDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedC4SortDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.custom, caseListRetractedC4SortDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedC4SortDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Retracted.id, caseListRetractedC4SortDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedC4SortDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedC4SortDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedC4SortDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase4Retracted.status, caseListRetractedC4SortDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase4Retracted.check_list_id, caseListRetractedC4SortDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase4Retracted.unit.microting_uid, caseListRetractedC4SortDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedC4SortDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.version, caseListRetractedC4SortDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedC4SortDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedC4SortDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRetractedC4SortDescendingStatus aCase4Retracted

            Assert.NotNull(caseListRetractedC4SortDescendingStatus);
            Assert.AreEqual(0, caseListRetractedC4SortDescendingStatus.Count);
            //Assert.AreEqual(aCase4Retracted.type, caseListRetractedC4SortDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedC4SortDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedC4SortDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedC4SortDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.custom, caseListRetractedC4SortDescendingStatus[0].Custom);
            //Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedC4SortDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Retracted.id, caseListRetractedC4SortDescendingStatus[0].Id);
            //Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedC4SortDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedC4SortDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedC4SortDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase4Retracted.status, caseListRetractedC4SortDescendingStatus[0].Status);
            //Assert.AreEqual(aCase4Retracted.check_list_id, caseListRetractedC4SortDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase4Retracted.unit.microting_uid, caseListRetractedC4SortDescendingStatus[0].UnitId);
            //Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedC4SortDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.version, caseListRetractedC4SortDescendingStatus[0].Version);
            //Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedC4SortDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedC4SortDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRetractedC4SortDescendingUnitId aCase4Retracted

            Assert.NotNull(caseListRetractedC4SortDescendingUnitId);
            Assert.AreEqual(0, caseListRetractedC4SortDescendingUnitId.Count);
            //Assert.AreEqual(aCase4Retracted.type, caseListRetractedC4SortDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedC4SortDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedC4SortDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedC4SortDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.custom, caseListRetractedC4SortDescendingUnitId[0].Custom);
            //Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedC4SortDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Retracted.id, caseListRetractedC4SortDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedC4SortDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedC4SortDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedC4SortDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase4Retracted.status, caseListRetractedC4SortDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase4Retracted.check_list_id, caseListRetractedC4SortDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase4Retracted.unit.microting_uid, caseListRetractedC4SortDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedC4SortDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.version, caseListRetractedC4SortDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedC4SortDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedC4SortDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion
            #endregion

            #region aCase Sort Asc w. DateTime

            #region aCase1Retracted sort asc w. DateTime

            #region caseListRetractedC1SortDtDoneAt aCase1Retracted
            Assert.NotNull(caseListRetractedC1SortDtDoneAt);
            Assert.AreEqual(0, caseListRetractedC1SortDtDoneAt.Count);
            //Assert.AreEqual(aCase1Retracted.type, caseListRetractedC1SortDtDoneAt[0].CaseType);
            //Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedC1SortDtDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedC1SortDtDoneAt[0].CheckUIid);
            //Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedC1SortDtDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.custom, caseListRetractedC1SortDtDoneAt[0].Custom);
            //Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedC1SortDtDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Retracted.id, caseListRetractedC1SortDtDoneAt[0].Id);
            //Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedC1SortDtDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedC1SortDtDoneAt[0].SiteId);
            //Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedC1SortDtDoneAt[0].SiteName);
            //Assert.AreEqual(aCase1Retracted.status, caseListRetractedC1SortDtDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC1SortDtDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase1Retracted.unit.id, caseListRetractedC1SortDtDoneAt[0].UnitId);
            //Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedC1SortDtDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.version, caseListRetractedC1SortDtDoneAt[0].Version);
            //Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedC1SortDtDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedC1SortDtDoneAt[0].WorkflowState);
            #endregion

            #region caseListRetractedC1SortDtStatus aCase1Retracted
            Assert.NotNull(caseListRetractedC1SortDtStatus);
            Assert.AreEqual(0, caseListRetractedC1SortDtStatus.Count);
            //Assert.AreEqual(aCase1Retracted.type, caseListRetractedC1SortDtStatus[0].CaseType);
            //Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedC1SortDtStatus[0].CaseUId);
            //Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedC1SortDtStatus[0].CheckUIid);
            //Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedC1SortDtStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.custom, caseListRetractedC1SortDtStatus[0].Custom);
            //Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedC1SortDtStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Retracted.id, caseListRetractedC1SortDtStatus[0].Id);
            //Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedC1SortDtStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedC1SortDtStatus[0].SiteId);
            //Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedC1SortDtStatus[0].SiteName);
            //Assert.AreEqual(aCase1Retracted.status, caseListRetractedC1SortDtStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC1SortDtStatus[0].TemplatId);
            //Assert.AreEqual(aCase1Retracted.unit.id, caseListRetractedC1SortDtStatus[0].UnitId);
            //Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedC1SortDtStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.version, caseListRetractedC1SortDtStatus[0].Version);
            //Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedC1SortDtStatus[0].WorkerName);
            //Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedC1SortDtStatus[0].WorkflowState);
            #endregion

            #region caseListRetractedC1SortDtUnitId aCase1Retracted
            Assert.NotNull(caseListRetractedC1SortDtUnitId);
            Assert.AreEqual(0, caseListRetractedC1SortDtUnitId.Count);
            //Assert.AreEqual(aCase1Retracted.type, caseListRetractedC1SortDtUnitId[0].CaseType);
            //Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedC1SortDtUnitId[0].CaseUId);
            //Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedC1SortDtUnitId[0].CheckUIid);
            //Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedC1SortDtUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.custom, caseListRetractedC1SortDtUnitId[0].Custom);
            //Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedC1SortDtUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Retracted.id, caseListRetractedC1SortDtUnitId[0].Id);
            //Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedC1SortDtUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedC1SortDtUnitId[0].SiteId);
            //Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedC1SortDtUnitId[0].SiteName);
            //Assert.AreEqual(aCase1Retracted.status, caseListRetractedC1SortDtUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC1SortDtUnitId[0].TemplatId);
            //Assert.AreEqual(aCase1Retracted.unit.id, caseListRetractedC1SortDtUnitId[0].UnitId);
            //Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedC1SortDtUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.version, caseListRetractedC1SortDtUnitId[0].Version);
            //Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedC1SortDtUnitId[0].WorkerName);
            //Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedC1SortDtUnitId[0].WorkflowState);
            #endregion

            #endregion

            #region aCase2Retracted sort asc w. DateTime

            #region caseListRetractedC2SortDtDoneAt aCase2Retracted
            Assert.NotNull(caseListRetractedC2SortDtDoneAt);
            Assert.AreEqual(0, caseListRetractedC2SortDtDoneAt.Count);
            //Assert.AreEqual(aCase2Retracted.type, caseListRetractedC2SortDtDoneAt[0].CaseType);
            //Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedC2SortDtDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedC2SortDtDoneAt[0].CheckUIid);
            //Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedC2SortDtDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.custom, caseListRetractedC2SortDtDoneAt[0].Custom);
            //Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedC2SortDtDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Retracted.id, caseListRetractedC2SortDtDoneAt[0].Id);
            //Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedC2SortDtDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedC2SortDtDoneAt[0].SiteId);
            //Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedC2SortDtDoneAt[0].SiteName);
            //Assert.AreEqual(aCase2Retracted.status, caseListRetractedC2SortDtDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC2SortDtDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase2Retracted.unit.id, caseListRetractedC2SortDtDoneAt[0].UnitId);
            //Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedC2SortDtDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.version, caseListRetractedC2SortDtDoneAt[0].Version);
            //Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedC2SortDtDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedC2SortDtDoneAt[0].WorkflowState);
            #endregion

            #region caseListRetractedC2SortDtStatus aCase2Retracted
            Assert.NotNull(caseListRetractedC2SortDtStatus);
            Assert.AreEqual(0, caseListRetractedC2SortDtStatus.Count);
            //Assert.AreEqual(aCase2Retracted.type, caseListRetractedC2SortDtStatus[0].CaseType);
            //Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedC2SortDtStatus[0].CaseUId);
            //Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedC2SortDtStatus[0].CheckUIid);
            //Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedC2SortDtStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.custom, caseListRetractedC2SortDtStatus[0].Custom);
            //Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedC2SortDtStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Retracted.id, caseListRetractedC2SortDtStatus[0].Id);
            //Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedC2SortDtStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedC2SortDtStatus[0].SiteId);
            //Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedC2SortDtStatus[0].SiteName);
            //Assert.AreEqual(aCase2Retracted.status, caseListRetractedC2SortDtStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC2SortDtStatus[0].TemplatId);
            //Assert.AreEqual(aCase2Retracted.unit.id, caseListRetractedC2SortDtStatus[0].UnitId);
            //Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedC2SortDtStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.version, caseListRetractedC2SortDtStatus[0].Version);
            //Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedC2SortDtStatus[0].WorkerName);
            //Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedC2SortDtStatus[0].WorkflowState);
            #endregion

            #region caseListRetractedC2SortDtUnitId aCase2Retracted
            Assert.NotNull(caseListRetractedC2SortDtUnitId);
            Assert.AreEqual(0, caseListRetractedC2SortDtUnitId.Count);
            //Assert.AreEqual(aCase2Retracted.type, caseListRetractedC2SortDtUnitId[0].CaseType);
            //Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedC2SortDtUnitId[0].CaseUId);
            //Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedC2SortDtUnitId[0].CheckUIid);
            //Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedC2SortDtUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.custom, caseListRetractedC2SortDtUnitId[0].Custom);
            //Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedC2SortDtUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Retracted.id, caseListRetractedC2SortDtUnitId[0].Id);
            //Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedC2SortDtUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedC2SortDtUnitId[0].SiteId);
            //Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedC2SortDtUnitId[0].SiteName);
            //Assert.AreEqual(aCase2Retracted.status, caseListRetractedC2SortDtUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC2SortDtUnitId[0].TemplatId);
            //Assert.AreEqual(aCase2Retracted.unit.id, caseListRetractedC2SortDtUnitId[0].UnitId);
            //Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedC2SortDtUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.version, caseListRetractedC2SortDtUnitId[0].Version);
            //Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedC2SortDtUnitId[0].WorkerName);
            //Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedC2SortDtUnitId[0].WorkflowState);
            #endregion

            #endregion

            #region aCase3Retracted sort asc w. DateTime

            #region caseListRetractedC3SortDtDoneAt aCase3Retracted
            Assert.NotNull(caseListRetractedC3SortDtDoneAt);
            Assert.AreEqual(0, caseListRetractedC3SortDtDoneAt.Count);
            //Assert.AreEqual(aCase3Retracted.type, caseListRetractedC3SortDtDoneAt[0].CaseType);
            //Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedC3SortDtDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedC3SortDtDoneAt[0].CheckUIid);
            //Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedC3SortDtDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.custom, caseListRetractedC3SortDtDoneAt[0].Custom);
            //Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedC3SortDtDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Retracted.id, caseListRetractedC3SortDtDoneAt[0].Id);
            //Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedC3SortDtDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedC3SortDtDoneAt[0].SiteId);
            //Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedC3SortDtDoneAt[0].SiteName);
            //Assert.AreEqual(aCase3Retracted.status, caseListRetractedC3SortDtDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC3SortDtDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase3Retracted.unit.id, caseListRetractedC3SortDtDoneAt[0].UnitId);
            //Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedC3SortDtDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.version, caseListRetractedC3SortDtDoneAt[0].Version);
            //Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedC3SortDtDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedC3SortDtDoneAt[0].WorkflowState);
            #endregion

            #region caseListRetractedC3SortDtStatus aCase3Retracted
            Assert.NotNull(caseListRetractedC3SortDtStatus);
            Assert.AreEqual(0, caseListRetractedC3SortDtStatus.Count);
            //Assert.AreEqual(aCase3Retracted.type, caseListRetractedC3SortDtStatus[0].CaseType);
            //Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedC3SortDtStatus[0].CaseUId);
            //Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedC3SortDtStatus[0].CheckUIid);
            //Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedC3SortDtStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.custom, caseListRetractedC3SortDtStatus[0].Custom);
            //Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedC3SortDtStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Retracted.id, caseListRetractedC3SortDtStatus[0].Id);
            //Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedC3SortDtStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedC3SortDtStatus[0].SiteId);
            //Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedC3SortDtStatus[0].SiteName);
            //Assert.AreEqual(aCase3Retracted.status, caseListRetractedC3SortDtStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC3SortDtStatus[0].TemplatId);
            //Assert.AreEqual(aCase3Retracted.unit.id, caseListRetractedC3SortDtStatus[0].UnitId);
            //Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedC3SortDtStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.version, caseListRetractedC3SortDtStatus[0].Version);
            //Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedC3SortDtStatus[0].WorkerName);
            //Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedC3SortDtStatus[0].WorkflowState);
            #endregion

            #region caseListRetractedC3SortDtUnitId aCase3Retracted
            Assert.NotNull(caseListRetractedC3SortDtUnitId);
            Assert.AreEqual(0, caseListRetractedC3SortDtUnitId.Count);
            //Assert.AreEqual(aCase3Retracted.type, caseListRetractedC3SortDtUnitId[0].CaseType);
            //Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedC3SortDtUnitId[0].CaseUId);
            //Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedC3SortDtUnitId[0].CheckUIid);
            //Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedC3SortDtUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.custom, caseListRetractedC3SortDtUnitId[0].Custom);
            //Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedC3SortDtUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Retracted.id, caseListRetractedC3SortDtUnitId[0].Id);
            //Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedC3SortDtUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedC3SortDtUnitId[0].SiteId);
            //Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedC3SortDtUnitId[0].SiteName);
            //Assert.AreEqual(aCase3Retracted.status, caseListRetractedC3SortDtUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC3SortDtUnitId[0].TemplatId);
            //Assert.AreEqual(aCase3Retracted.unit.id, caseListRetractedC3SortDtUnitId[0].UnitId);
            //Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedC3SortDtUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.version, caseListRetractedC3SortDtUnitId[0].Version);
            //Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedC3SortDtUnitId[0].WorkerName);
            //Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedC3SortDtUnitId[0].WorkflowState);
            #endregion

            #endregion

            #region aCase4Retracted sort asc w. DateTime

            #region caseListRetractedC4SortDtDoneAt aCase4Retracted
            Assert.NotNull(caseListRetractedC4SortDtDoneAt);
            Assert.AreEqual(0, caseListRetractedC4SortDtDoneAt.Count);
            //Assert.AreEqual(aCase4Retracted.type, caseListRetractedC4SortDtDoneAt[0].CaseType);
            //Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedC4SortDtDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedC4SortDtDoneAt[0].CheckUIid);
            //Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedC4SortDtDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.custom, caseListRetractedC4SortDtDoneAt[0].Custom);
            //Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedC4SortDtDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Retracted.id, caseListRetractedC4SortDtDoneAt[0].Id);
            //Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedC4SortDtDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedC4SortDtDoneAt[0].SiteId);
            //Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedC4SortDtDoneAt[0].SiteName);
            //Assert.AreEqual(aCase4Retracted.status, caseListRetractedC4SortDtDoneAt[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC4SortDtDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase4Retracted.unit.id, caseListRetractedC4SortDtDoneAt[0].UnitId);
            //Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedC4SortDtDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.version, caseListRetractedC4SortDtDoneAt[0].Version);
            //Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedC4SortDtDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedC4SortDtDoneAt[0].WorkflowState);
            #endregion

            #region caseListRetractedC4SortDtStatus aCase4Retracted
            Assert.NotNull(caseListRetractedC4SortDtStatus);
            Assert.AreEqual(0, caseListRetractedC4SortDtStatus.Count);
            //Assert.AreEqual(aCase4Retracted.type, caseListRetractedC4SortDtStatus[0].CaseType);
            //Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedC4SortDtStatus[0].CaseUId);
            //Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedC4SortDtStatus[0].CheckUIid);
            //Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedC4SortDtStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.custom, caseListRetractedC4SortDtStatus[0].Custom);
            //Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedC4SortDtStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Retracted.id, caseListRetractedC4SortDtStatus[0].Id);
            //Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedC4SortDtStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedC4SortDtStatus[0].SiteId);
            //Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedC4SortDtStatus[0].SiteName);
            //Assert.AreEqual(aCase4Retracted.status, caseListRetractedC4SortDtStatus[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC4SortDtStatus[0].TemplatId);
            //Assert.AreEqual(aCase4Retracted.unit.id, caseListRetractedC4SortDtStatus[0].UnitId);
            //Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedC4SortDtStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.version, caseListRetractedC4SortDtStatus[0].Version);
            //Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedC4SortDtStatus[0].WorkerName);
            //Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedC4SortDtStatus[0].WorkflowState);
            #endregion

            #region caseListRetractedC4SortDtUnitId aCase4Retracted
            Assert.NotNull(caseListRetractedC4SortDtUnitId);
            Assert.AreEqual(0, caseListRetractedC4SortDtUnitId.Count);
            //Assert.AreEqual(aCase4Retracted.type, caseListRetractedC4SortDtUnitId[0].CaseType);
            //Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedC4SortDtUnitId[0].CaseUId);
            //Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedC4SortDtUnitId[0].CheckUIid);
            //Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedC4SortDtUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.custom, caseListRetractedC4SortDtUnitId[0].Custom);
            //Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedC4SortDtUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Retracted.id, caseListRetractedC4SortDtUnitId[0].Id);
            //Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedC4SortDtUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedC4SortDtUnitId[0].SiteId);
            //Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedC4SortDtUnitId[0].SiteName);
            //Assert.AreEqual(aCase4Retracted.status, caseListRetractedC4SortDtUnitId[0].Status);
            //Assert.AreEqual(cl1.id, caseListRetractedC4SortDtUnitId[0].TemplatId);
            //Assert.AreEqual(aCase4Retracted.unit.id, caseListRetractedC4SortDtUnitId[0].UnitId);
            //Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedC4SortDtUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.version, caseListRetractedC4SortDtUnitId[0].Version);
            //Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedC4SortDtUnitId[0].WorkerName);
            //Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedC4SortDtUnitId[0].WorkflowState);
            #endregion

            #endregion

            #endregion

            #region aCase Sort Des w. DateTime
            #region aCase1Retracted Sort Des w. DateTime
            #region caseListRetractedC1SortDtDescendingDoneAt aCase1Retracted

            Assert.NotNull(caseListRetractedC1SortDtDescendingDoneAt);
            Assert.AreEqual(0, caseListRetractedC1SortDtDescendingDoneAt.Count);
            //Assert.AreEqual(aCase1Retracted.type, caseListRetractedC1SortDtDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedC1SortDtDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedC1SortDtDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedC1SortDtDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.custom, caseListRetractedC1SortDtDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedC1SortDtDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Retracted.id, caseListRetractedC1SortDtDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedC1SortDtDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedC1SortDtDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedC1SortDtDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase1Retracted.status, caseListRetractedC1SortDtDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase1Retracted.check_list_id, caseListRetractedC1SortDtDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedC1SortDtDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedC1SortDtDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.version, caseListRetractedC1SortDtDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedC1SortDtDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedC1SortDtDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRetractedC1SortDtDescendingStatus aCase1Retracted

            Assert.NotNull(caseListRetractedC1SortDtDescendingStatus);
            Assert.AreEqual(0, caseListRetractedC1SortDtDescendingStatus.Count);
            //Assert.AreEqual(aCase1Retracted.type, caseListRetractedC1SortDtDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedC1SortDtDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedC1SortDtDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedC1SortDtDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.custom, caseListRetractedC1SortDtDescendingStatus[0].Custom);
            //Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedC1SortDtDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Retracted.id, caseListRetractedC1SortDtDescendingStatus[0].Id);
            //Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedC1SortDtDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedC1SortDtDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedC1SortDtDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase1Retracted.status, caseListRetractedC1SortDtDescendingStatus[0].Status);
            //Assert.AreEqual(aCase1Retracted.check_list_id, caseListRetractedC1SortDtDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedC1SortDtDescendingStatus[0].UnitId);
            //Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedC1SortDtDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.version, caseListRetractedC1SortDtDescendingStatus[0].Version);
            //Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedC1SortDtDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedC1SortDtDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRetractedC1SortDtDescendingUnitId aCase1Retracted

            Assert.NotNull(caseListRetractedC1SortDtDescendingUnitId);
            Assert.AreEqual(0, caseListRetractedC1SortDtDescendingUnitId.Count);
            //Assert.AreEqual(aCase1Retracted.type, caseListRetractedC1SortDtDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase1Retracted.case_uid, caseListRetractedC1SortDtDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase1Retracted.microting_check_uid, caseListRetractedC1SortDtDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c1Retracted_ca.ToString(), caseListRetractedC1SortDtDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.custom, caseListRetractedC1SortDtDescendingUnitId[0].Custom);
            //Assert.AreEqual(c1Retracted_da.ToString(), caseListRetractedC1SortDtDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase1Retracted.id, caseListRetractedC1SortDtDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase1Retracted.microting_uid, caseListRetractedC1SortDtDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase1Retracted.site.microting_uid, caseListRetractedC1SortDtDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase1Retracted.site.name, caseListRetractedC1SortDtDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase1Retracted.status, caseListRetractedC1SortDtDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase1Retracted.check_list_id, caseListRetractedC1SortDtDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase1Retracted.unit.microting_uid, caseListRetractedC1SortDtDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c1Retracted_ua.ToString(), caseListRetractedC1SortDtDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase1Retracted.version, caseListRetractedC1SortDtDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase1Retracted.worker.first_name + " " + aCase1Retracted.worker.last_name, caseListRetractedC1SortDtDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase1Retracted.workflow_state, caseListRetractedC1SortDtDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase2Retracted Sort Des w. DateTime
            #region caseListRetractedC2SortDtDescendingDoneAt aCase2Retracted

            Assert.NotNull(caseListRetractedC2SortDtDescendingDoneAt);
            Assert.AreEqual(0, caseListRetractedC2SortDtDescendingDoneAt.Count);
            //Assert.AreEqual(aCase2Retracted.type, caseListRetractedC2SortDtDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedC2SortDtDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedC2SortDtDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedC2SortDtDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.custom, caseListRetractedC2SortDtDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedC2SortDtDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Retracted.id, caseListRetractedC2SortDtDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedC2SortDtDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedC2SortDtDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedC2SortDtDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase2Retracted.status, caseListRetractedC2SortDtDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase2Retracted.check_list_id, caseListRetractedC2SortDtDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase2Retracted.unit.microting_uid, caseListRetractedC2SortDtDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedC2SortDtDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.version, caseListRetractedC2SortDtDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedC2SortDtDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedC2SortDtDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRetractedC2SortDtDescendingStatus aCase2Retracted

            Assert.NotNull(caseListRetractedC2SortDtDescendingStatus);
            Assert.AreEqual(0, caseListRetractedC2SortDtDescendingStatus.Count);
            //Assert.AreEqual(aCase2Retracted.type, caseListRetractedC2SortDtDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedC2SortDtDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedC2SortDtDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedC2SortDtDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.custom, caseListRetractedC2SortDtDescendingStatus[0].Custom);
            //Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedC2SortDtDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Retracted.id, caseListRetractedC2SortDtDescendingStatus[0].Id);
            //Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedC2SortDtDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedC2SortDtDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedC2SortDtDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase2Retracted.status, caseListRetractedC2SortDtDescendingStatus[0].Status);
            //Assert.AreEqual(aCase2Retracted.check_list_id, caseListRetractedC2SortDtDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase2Retracted.unit.microting_uid, caseListRetractedC2SortDtDescendingStatus[0].UnitId);
            //Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedC2SortDtDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.version, caseListRetractedC2SortDtDescendingStatus[0].Version);
            //Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedC2SortDtDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedC2SortDtDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRetractedC2SortDtDescendingUnitId aCase2Retracted

            Assert.NotNull(caseListRetractedC2SortDtDescendingUnitId);
            Assert.AreEqual(0, caseListRetractedC2SortDtDescendingUnitId.Count);
            //Assert.AreEqual(aCase2Retracted.type, caseListRetractedC2SortDtDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase2Retracted.case_uid, caseListRetractedC2SortDtDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase2Retracted.microting_check_uid, caseListRetractedC2SortDtDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c2Retracted_ca.ToString(), caseListRetractedC2SortDtDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.custom, caseListRetractedC2SortDtDescendingUnitId[0].Custom);
            //Assert.AreEqual(c2Retracted_da.ToString(), caseListRetractedC2SortDtDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase2Retracted.id, caseListRetractedC2SortDtDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase2Retracted.microting_uid, caseListRetractedC2SortDtDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase2Retracted.site.microting_uid, caseListRetractedC2SortDtDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase2Retracted.site.name, caseListRetractedC2SortDtDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase2Retracted.status, caseListRetractedC2SortDtDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase2Retracted.check_list_id, caseListRetractedC2SortDtDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase2Retracted.unit.microting_uid, caseListRetractedC2SortDtDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c2Retracted_ua.ToString(), caseListRetractedC2SortDtDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase2Retracted.version, caseListRetractedC2SortDtDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase2Retracted.worker.first_name + " " + aCase2Retracted.worker.last_name, caseListRetractedC2SortDtDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase2Retracted.workflow_state, caseListRetractedC2SortDtDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase3Retracted Sort Des w. DateTime
            #region caseListRetractedC3SortDtDescendingDoneAt aCase3Retracted

            Assert.NotNull(caseListRetractedC3SortDtDescendingDoneAt);
            Assert.AreEqual(0, caseListRetractedC3SortDtDescendingDoneAt.Count);
            //Assert.AreEqual(aCase3Retracted.type, caseListRetractedC3SortDtDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedC3SortDtDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedC3SortDtDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedC3SortDtDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.custom, caseListRetractedC3SortDtDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedC3SortDtDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Retracted.id, caseListRetractedC3SortDtDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedC3SortDtDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedC3SortDtDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedC3SortDtDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase3Retracted.status, caseListRetractedC3SortDtDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase3Retracted.check_list_id, caseListRetractedC3SortDtDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedC3SortDtDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedC3SortDtDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.version, caseListRetractedC3SortDtDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedC3SortDtDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedC3SortDtDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRetractedC3SortDtDescendingStatus aCase3Retracted

            Assert.NotNull(caseListRetractedC3SortDtDescendingStatus);
            Assert.AreEqual(0, caseListRetractedC3SortDtDescendingStatus.Count);
            //Assert.AreEqual(aCase3Retracted.type, caseListRetractedC3SortDtDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedC3SortDtDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedC3SortDtDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedC3SortDtDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.custom, caseListRetractedC3SortDtDescendingStatus[0].Custom);
            //Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedC3SortDtDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Retracted.id, caseListRetractedC3SortDtDescendingStatus[0].Id);
            //Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedC3SortDtDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedC3SortDtDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedC3SortDtDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase3Retracted.status, caseListRetractedC3SortDtDescendingStatus[0].Status);
            //Assert.AreEqual(aCase3Retracted.check_list_id, caseListRetractedC3SortDtDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedC3SortDtDescendingStatus[0].UnitId);
            //Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedC3SortDtDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.version, caseListRetractedC3SortDtDescendingStatus[0].Version);
            //Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedC3SortDtDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedC3SortDtDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRetractedC3SortDtDescendingUnitId aCase3Retracted

            Assert.NotNull(caseListRetractedC3SortDtDescendingUnitId);
            Assert.AreEqual(0, caseListRetractedC3SortDtDescendingUnitId.Count);
            //Assert.AreEqual(aCase3Retracted.type, caseListRetractedC3SortDtDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase3Retracted.case_uid, caseListRetractedC3SortDtDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase3Retracted.microting_check_uid, caseListRetractedC3SortDtDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c3Retracted_ca.ToString(), caseListRetractedC3SortDtDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.custom, caseListRetractedC3SortDtDescendingUnitId[0].Custom);
            //Assert.AreEqual(c3Retracted_da.ToString(), caseListRetractedC3SortDtDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase3Retracted.id, caseListRetractedC3SortDtDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase3Retracted.microting_uid, caseListRetractedC3SortDtDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase3Retracted.site.microting_uid, caseListRetractedC3SortDtDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase3Retracted.site.name, caseListRetractedC3SortDtDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase3Retracted.status, caseListRetractedC3SortDtDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase3Retracted.check_list_id, caseListRetractedC3SortDtDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase3Retracted.unit.microting_uid, caseListRetractedC3SortDtDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c3Retracted_ua.ToString(), caseListRetractedC3SortDtDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase3Retracted.version, caseListRetractedC3SortDtDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase3Retracted.worker.first_name + " " + aCase3Retracted.worker.last_name, caseListRetractedC3SortDtDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase3Retracted.workflow_state, caseListRetractedC3SortDtDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #region aCase4Retracted Sort Des w. DateTime
            #region caseListRetractedC4SortDtDescendingDoneAt aCase4Retracted

            Assert.NotNull(caseListRetractedC4SortDtDescendingDoneAt);
            Assert.AreEqual(0, caseListRetractedC4SortDtDescendingDoneAt.Count);
            //Assert.AreEqual(aCase4Retracted.type, caseListRetractedC4SortDtDescendingDoneAt[0].CaseType);
            //Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedC4SortDtDescendingDoneAt[0].CaseUId);
            //Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedC4SortDtDescendingDoneAt[0].CheckUIid);
            //Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedC4SortDtDescendingDoneAt[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.custom, caseListRetractedC4SortDtDescendingDoneAt[0].Custom);
            //Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedC4SortDtDescendingDoneAt[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Retracted.id, caseListRetractedC4SortDtDescendingDoneAt[0].Id);
            //Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedC4SortDtDescendingDoneAt[0].MicrotingUId);
            //Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedC4SortDtDescendingDoneAt[0].SiteId);
            //Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedC4SortDtDescendingDoneAt[0].SiteName);
            //Assert.AreEqual(aCase4Retracted.status, caseListRetractedC4SortDtDescendingDoneAt[0].Status);
            //Assert.AreEqual(aCase4Retracted.check_list_id, caseListRetractedC4SortDtDescendingDoneAt[0].TemplatId);
            //Assert.AreEqual(aCase4Retracted.unit.microting_uid, caseListRetractedC4SortDtDescendingDoneAt[0].UnitId);
            //Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedC4SortDtDescendingDoneAt[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.version, caseListRetractedC4SortDtDescendingDoneAt[0].Version);
            //Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedC4SortDtDescendingDoneAt[0].WorkerName);
            //Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedC4SortDtDescendingDoneAt[0].WorkflowState);

            #endregion

            #region caseListRetractedC4SortDtDescendingStatus aCase4Retracted

            Assert.NotNull(caseListRetractedC4SortDtDescendingStatus);
            Assert.AreEqual(0, caseListRetractedC4SortDtDescendingStatus.Count);
            //Assert.AreEqual(aCase4Retracted.type, caseListRetractedC4SortDtDescendingStatus[0].CaseType);
            //Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedC4SortDtDescendingStatus[0].CaseUId);
            //Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedC4SortDtDescendingStatus[0].CheckUIid);
            //Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedC4SortDtDescendingStatus[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.custom, caseListRetractedC4SortDtDescendingStatus[0].Custom);
            //Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedC4SortDtDescendingStatus[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Retracted.id, caseListRetractedC4SortDtDescendingStatus[0].Id);
            //Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedC4SortDtDescendingStatus[0].MicrotingUId);
            //Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedC4SortDtDescendingStatus[0].SiteId);
            //Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedC4SortDtDescendingStatus[0].SiteName);
            //Assert.AreEqual(aCase4Retracted.status, caseListRetractedC4SortDtDescendingStatus[0].Status);
            //Assert.AreEqual(aCase4Retracted.check_list_id, caseListRetractedC4SortDtDescendingStatus[0].TemplatId);
            //Assert.AreEqual(aCase4Retracted.unit.microting_uid, caseListRetractedC4SortDtDescendingStatus[0].UnitId);
            //Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedC4SortDtDescendingStatus[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.version, caseListRetractedC4SortDtDescendingStatus[0].Version);
            //Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedC4SortDtDescendingStatus[0].WorkerName);
            //Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedC4SortDtDescendingStatus[0].WorkflowState);

            #endregion

            #region caseListRetractedC4SortDtDescendingUnitId aCase4Retracted

            Assert.NotNull(caseListRetractedC4SortDtDescendingUnitId);
            Assert.AreEqual(0, caseListRetractedC4SortDtDescendingUnitId.Count);
            //Assert.AreEqual(aCase4Retracted.type, caseListRetractedC4SortDtDescendingUnitId[0].CaseType);
            //Assert.AreEqual(aCase4Retracted.case_uid, caseListRetractedC4SortDtDescendingUnitId[0].CaseUId);
            //Assert.AreEqual(aCase4Retracted.microting_check_uid, caseListRetractedC4SortDtDescendingUnitId[0].CheckUIid);
            //Assert.AreEqual(c4Retracted_ca.ToString(), caseListRetractedC4SortDtDescendingUnitId[0].CreatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.custom, caseListRetractedC4SortDtDescendingUnitId[0].Custom);
            //Assert.AreEqual(c4Retracted_da.ToString(), caseListRetractedC4SortDtDescendingUnitId[0].DoneAt.ToString());
            //Assert.AreEqual(aCase4Retracted.id, caseListRetractedC4SortDtDescendingUnitId[0].Id);
            //Assert.AreEqual(aCase4Retracted.microting_uid, caseListRetractedC4SortDtDescendingUnitId[0].MicrotingUId);
            //Assert.AreEqual(aCase4Retracted.site.microting_uid, caseListRetractedC4SortDtDescendingUnitId[0].SiteId);
            //Assert.AreEqual(aCase4Retracted.site.name, caseListRetractedC4SortDtDescendingUnitId[0].SiteName);
            //Assert.AreEqual(aCase4Retracted.status, caseListRetractedC4SortDtDescendingUnitId[0].Status);
            //Assert.AreEqual(aCase4Retracted.check_list_id, caseListRetractedC4SortDtDescendingUnitId[0].TemplatId);
            //Assert.AreEqual(aCase4Retracted.unit.microting_uid, caseListRetractedC4SortDtDescendingUnitId[0].UnitId);
            //Assert.AreEqual(c4Retracted_ua.ToString(), caseListRetractedC4SortDtDescendingUnitId[0].UpdatedAt.ToString());
            //Assert.AreEqual(aCase4Retracted.version, caseListRetractedC4SortDtDescendingUnitId[0].Version);
            //Assert.AreEqual(aCase4Retracted.worker.first_name + " " + aCase4Retracted.worker.last_name, caseListRetractedC4SortDtDescendingUnitId[0].WorkerName);
            //Assert.AreEqual(aCase4Retracted.workflow_state, caseListRetractedC4SortDtDescendingUnitId[0].WorkflowState);

            #endregion
            #endregion

            #endregion

            #endregion

            #endregion


        }

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