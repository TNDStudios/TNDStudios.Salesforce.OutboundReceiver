﻿using System;
using Microsoft.AspNetCore.Mvc;
using TNDStudios.Salesforce.OutboundReceiver.Objects;
using TNDStudios.Tools.Soap.Objects;

namespace TNDStudios.Salesforce.OutboundReceiver.Api.Salesforce.Test.V1
{
    /// <summary>
    /// Controller to manage Salesforce outbound notifications
    /// </summary>
    [ApiVersion("0.9", Deprecated = true)]
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{api-version:apiVersion}/salesforce/test")]
    public class SalesforceTestController : Controller
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SalesforceTestController()
        {
        }
        
        /// <summary>
        /// Provide an endpoint to recieve a soap notification message
        /// in a structure that recognises notifications from Salesforce
        /// </summary>
        /// <param name="message">The translated Soap request as an object</param>
        /// <returns>A success or failure response</returns>
        [Consumes(@"application/soap+xml", otherContentTypes: @"text/xml")]
        [HttpPost]
        public Boolean Post([FromBody]SoapMessage<SalesforceNotificationsBody<TestSalesforceObject>> message)
        {
            TestSalesforceObject sfObject = message.Envelope.Body.Notifications.Items[0].SalesforceObject;
            String email = sfObject.Get<String>("Email");
            String email2 = (String)sfObject.Get(typeof(String), "Email");

            return true;
        }
    }
}