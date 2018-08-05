using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Models.APIModels;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;

namespace LUSSISADTeam10Web.Utilities
{
    public static class Utility
    {

        public static bool SendPurchaseOrdersPDF(SupplierModel sup, PurchaseOrderModel po)
        {
            var fromAddress = new MailAddress("logicuniversity10@gmail.com");

            var toAddress = new MailAddress(sup.SupEmail); 
            const string fromPassword = "Needcoffee315";
            string subject = "Purchase Order - Logic University";
            string body = "Dear " + sup.ContactName + ", Please find the attached file to refer the purchase order from our university";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            try
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    var table = "";
                    var total = 0.00;
                    foreach (PurchaseOrderDetailModel podm in po.podms)
                    {
                        var amount = podm.Qty * podm.Price;
                        table +=
                            "<tr>" +
                            "<td>" + podm.ItemDescription + "</td>" +
                            "<td>" + podm.CategoryName + "</td>" +
                            "<td>" + podm.UOM + "</td>" +
                            "<td>S$ " + podm.Price + "</td>" +
                            "<td>" + podm.Qty + "</td>" +
                            "<td>S$ " + amount + "</td>" +
                            "</tr>";
                        total += amount ?? default(double);
                    }

                    var head = "<html><head><style>table {border-collapse: collapse;}table, th, td { border: 1px solid black;} </style></head><body>";
                    var htmlbody = "<div style='width: 100%; height: 50px;'>" +
                                        "<p align='center' style='font-size: 25px;'>" +
                                        "Logic University" +
                                        "</p>" +
                                        "<p align='center' style='font-size: 25px;'>" +
                                        "Stationary Purchase order" +
                                        "</p>" +
                                    "</div>" +
                                    "<div style='width:100%'>" +
                                            "<p align='right' > PO-" + po.PoId + "</p>" +
                                            "<p align='right' >" + DateTime.Today.ToShortDateString() + "</p>" +
                                    "</div>" +
                                     "<div>" +
                                       "<div width=50%>" +
                                           "<p align='left' >"
                                                + sup.ContactName
                                           + "</p>" +
                                           "<p align='left' >"
                                                + sup.SupName
                                           + "</p>" +
                                           "<p align='left'>"
                                                + sup.SupEmail
                                           + "</p>" +
                                           "<p align='left'>"
                                                 + sup.SupPhone
                                           + "</p>" +
                                       "</div>" +
                                     "</div>" +
                                     "<div style='width:100%; height:50px; float:clear;'></div>" +
                                        "<table style='width:100%;'cellpadding = '10' cellspacing = '10'>" +
                                            "<tr>" +
                                                "<th>Item</th>" +
                                                "<th>Category</th>" +
                                                "<th>UOM</th>" +
                                                "<th>Price</th>" +
                                                "<th>Qty</th>" +
                                                "<th>Amount</th>" +
                                            "</tr>" + table 
                                            + "<tr><td> </td><td></td><td></td><td></td><td>Total</td><td>S$ " + total+ "</td></tr>";
                    var tablebody = "</table>";
                       
                    var tablefooter = "<div style='width:100%; height:100px; float:clear;'></div>";
                    var end = "</body></html>";

                    var whole = head + htmlbody + tablebody + tablefooter + end;

                  var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(whole, PdfSharp.PageSize.A4);
                    var ms = new MemoryStream();
                    pdf.Save(ms, false);
                    ms.Position = 0;
                    ContentType ct = new ContentType(MediaTypeNames.Application.Pdf);
                    Attachment attach = new Attachment(ms, ct);
                    attach.ContentDisposition.FileName = DateTime.Today.ToShortDateString() + "_PurchaseOrder.pdf";
                    message.Attachments.Add(attach);

                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return true;

        }

        public static string GetRelativeTime(DateTime input)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.Now.Ticks - input.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "a minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "an hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return "yesterday";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }

        }

    }
}