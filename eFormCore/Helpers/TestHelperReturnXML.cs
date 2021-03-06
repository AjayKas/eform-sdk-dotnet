﻿using eFormShared;
using eFormSqlController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using eFormCore.Helpers;

namespace eFormCore.Helpers
{
    public class TestHelperReturnXML
    {

        private TestHelpers testHelpers;
        Tools t = new Tools();

        public TestHelperReturnXML()
        {        Tools t = new Tools();
            testHelpers = new TestHelpers();

        }

        #region "prep sever information for full load"
        public string CreateSiteUnitWorkersForFullLoaed(bool create)
        {
            if (create)
            {
                int id = t.GetRandomInt(6);
                string siteName = Guid.NewGuid().ToString();
                sites site = testHelpers.CreateSite(siteName, id);

                id = t.GetRandomInt(6);
                string userFirstName = Guid.NewGuid().ToString();
                string userLastName = Guid.NewGuid().ToString();
                workers worker = testHelpers.CreateWorker("sfsdfsdf23ref@invalid.com", userFirstName, userLastName, id);
                return "";
            }
            else
            {
                sites site = testHelpers.DbContext.sites.First();
                workers worker = testHelpers.DbContext.workers.First();

                int id = t.GetRandomInt(6);
                JObject result = JObject.FromObject(new JArray(new { id = id, created_at = "2018-01-12T01:01:00Z", updated_at = "2018-01-12T01:01:10Z", workflow_state = Constants.WorkflowStates.Created, person_type = "", site_id = site.microting_uid, user_id = worker.microting_uid }));
                return result.ToString();
            }
        }
        #endregion

        #region
        public string CreateMultiPictureXMLResult(bool create)
        {
            if (create)
            {
                sites site = testHelpers.CreateSite("TestSite1", 12334);
                units unit = testHelpers.CreateUnit(20934, 234234, site, 24234);
                workers worker = testHelpers.CreateWorker("sfsdfsdf23ref@invalid.com", "John", "Doe", 2342341);
                site_workers sw = testHelpers.CreateSiteWorker(242345, site, worker);
                DateTime cl1_ca = DateTime.Now;
                DateTime cl1_ua = DateTime.Now;
                check_lists cl1 = testHelpers.CreateTemplate(cl1_ca, cl1_ua, "MultiPictureXMLResult", "MultiPictureXMLResult_Description", "", "", 0, 0);
                check_lists cl2 = testHelpers.CreateSubTemplate("Sub1", "Sub1Description", "", 0, 0, cl1);
                fields f1 = testHelpers.CreateField(0, "", cl2, Constants.FieldColors.Blue, "", null, "", "PictureDescription", 0, 0, testHelpers.DbContext.field_types.Where(x => x.field_type == "picture").First(), 0, 0, 0, 0, "Take picture", 0, 0, "", "", 0, 0, "", 0, 0, 0, 0, "", 0);
                check_list_sites cls = testHelpers.CreateCheckListSite(cl1, cl1_ca, site, cl1_ua, 0, Constants.WorkflowStates.Created, "MultiPictureTestInMultipleChecks");
                //returnXML = ;
                return "MultiPictureTestInMultipleChecks";
            }
            else
            {
                sites site = testHelpers.DbContext.sites.First();
                units unit = testHelpers.DbContext.units.First();
                workers worker = testHelpers.DbContext.workers.First();
                check_lists cl1 = testHelpers.DbContext.check_lists.ToList()[0];
                check_lists cl2 = testHelpers.DbContext.check_lists.ToList()[1];
                fields f1 = testHelpers.DbContext.fields.First();

                #region return xml
                return $@"<?xml version='1.0' encoding='UTF-8'?>
                <Response>
                    <Value type='success'>MultiPictureTestInMultipleChecks</Value>
                    <Checks>
                        <Check worker='John Doe' worker_id='{worker.microting_uid}' date='2018-04-25 14:29:21 +0200' unit_id='{unit.microting_uid}' id='7'>
                            <ElementList>
                                <Id>{cl2.id}</Id>
                                <Status>approved</Status>
                                <DataItemList>
                                    <DataItem>
                                        <Id>{f1.id}</Id>
                                        <Geolocation>
                                            <Latitude></Latitude>
                                            <Longitude></Longitude>
                                            <Altitude></Altitude>
                                            <Heading></Heading>
                                            <Accuracy></Accuracy>
                                            <Date></Date>
                                        </Geolocation>
                                        <Value></Value>
                                        <Extension>.jpeg</Extension>
                                        <URL>https://www.microting.com/wp-content/themes/Artificial-Reason-WP/img/close.png</URL>
                                    </DataItem>
                                </DataItemList>
                                <ExtraDataItemList></ExtraDataItemList>
                            </ElementList>
                        </Check>
                        <Check worker='John Doe' worker_id='{worker.microting_uid}' date='2018-04-25 14:29:52 +0200' unit_id='{unit.microting_uid}' id='12'>
                            <ElementList>
                                <Id>{cl2.id}</Id>
                                <Status>approved</Status>
                                <DataItemList>
                                    <DataItem>
                                        <Id>{f1.id}</Id>
                                        <Geolocation>
                                            <Latitude></Latitude>
                                            <Longitude></Longitude>
                                            <Altitude></Altitude>
                                            <Heading></Heading>
                                            <Accuracy></Accuracy>
                                            <Date></Date>
                                        </Geolocation>
                                        <Value></Value>
                                        <Extension>.jpeg</Extension>
                                        <URL>https://www.microting.com/wp-content/themes/Artificial-Reason-WP/img/close.png</URL>
                                    </DataItem>
                                    <DataItem>
                                        <Id>{f1.id}</Id>
                                        <Geolocation>
                                            <Latitude></Latitude>
                                            <Longitude></Longitude>
                                            <Altitude></Altitude>
                                            <Heading></Heading>
                                            <Accuracy></Accuracy>
                                            <Date></Date>
                                        </Geolocation>
                                        <Value></Value>
                                        <Extension>.jpeg</Extension>
                                        <URL>https://www.microting.com/wp-content/themes/Artificial-Reason-WP/img/close.png</URL>
                                    </DataItem>
                                </DataItemList>
                                <ExtraDataItemList></ExtraDataItemList>
                            </ElementList>
                        </Check>
                        <Check worker='John Doe' worker_id='{worker.microting_uid}' date='2018-04-25 14:39:43 +0200' unit_id='{unit.microting_uid}' id='17'>
                            <ElementList>
                                <Id>{cl2.id}</Id>
                                <Status>approved</Status>
                                <DataItemList>
                                    <DataItem>
                                        <Id>{f1.id}</Id>
                                        <Geolocation>
                                            <Latitude></Latitude>
                                            <Longitude></Longitude>
                                            <Altitude></Altitude>
                                            <Heading></Heading>
                                            <Accuracy></Accuracy>
                                            <Date></Date>
                                        </Geolocation>
                                        <Value></Value>
                                        <Extension>.jpeg</Extension>
                                        <URL>https://www.microting.com/wp-content/themes/Artificial-Reason-WP/img/close.png</URL>
                                    </DataItem>
                                    <DataItem>
                                        <Id>{f1.id}</Id>
                                        <Geolocation>
                                            <Latitude></Latitude>
                                            <Longitude></Longitude>
                                            <Altitude></Altitude>
                                            <Heading></Heading>
                                            <Accuracy></Accuracy>
                                            <Date></Date>
                                        </Geolocation>
                                        <Value></Value>
                                        <Extension>.jpeg</Extension>
                                        <URL>https://www.microting.com/wp-content/themes/Artificial-Reason-WP/img/close.png</URL>
                                    </DataItem>
                                </DataItemList>
                                <ExtraDataItemList></ExtraDataItemList>
                            </ElementList>
                        </Check>
                    </Checks>
                </Response>".Replace("'", "\"");
                #endregion
            }


        }
        #endregion
    }
}
