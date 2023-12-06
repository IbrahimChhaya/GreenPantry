﻿using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminDashboard
{
    public partial class dashboard : System.Web.UI.Page
    {
        GP_ServiceClient SR = new GP_ServiceClient();

        protected string jsonCategories;
        protected string jsonCatSales;
        protected string jsonMonthDates;
        protected string jsonMonthProfits;
        protected string jsonWeekDays;
        protected string jsonWeekProfits;
        protected void Page_Load(object sender, EventArgs e)
        {
            //int trafficNum = SR.getVisitors();
            //String display = "";
            //display = "<h5 class='card-title text-uppercase text-muted mb-0'>Total traffic</h5>";
            //display = "<span class='h2 font-weight-bold mb-0'>" + trafficNum + "</span>";
            //traffic.innerHtml = dispaly

            //decimal trafficPercent = SR.getTrafficChange();
            //if(trafficPercent > 0)
            //  trafficChange.InnerHtml = "<i class='fa fa-arrow-up'></i> 3.48%

            /*Graph data --START*/

            if(Session["LoggedInUserID"] != null)
            {
                int userID = int.Parse(Session["LoggedInUserID"].ToString());
                dynamic user = SR.getUser(userID);
                if(user.UserType == "admin")
                {
                    howdy.InnerText = "Howdy, " + user.Name;
                }
                else
                {
                    Response.Redirect("/home.aspx");
                }
            }
            else
            {
                Response.Redirect("/home.aspx");
            }

            List<string> display = new List<string>();
            List<decimal> catSales = new List<decimal>();

            dynamic categories = SR.getAllCategories();

            categories = SR.getAllCategories();
            foreach(var c in categories)
            {
                display.Add(c.Name);
                var catTotal = SR.calcCategoryTotalSales(c.ID);
                catSales.Add(catTotal);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            jsonCategories = serializer.Serialize(display);
            jsonCatSales = serializer.Serialize(catSales);


            dynamic monthDates = SR.getMonthDates(DateTime.Now);

            List<string> dates = new List<string>();

            List<decimal> salesMonthDays = new List<decimal>();
            foreach (DateTime d in monthDates)
            {
                var dayProfit = SR.calcProfitPerday(d.Date);
                salesMonthDays.Add(dayProfit);
                dates.Add(d.ToShortDateString());
            }

            jsonMonthDates = serializer.Serialize(dates);
            jsonMonthProfits = serializer.Serialize(salesMonthDays);

            dynamic weekDates = SR.getWeekDates(DateTime.Now);
            List<string> wDays = new List<string>();
            List<decimal> weekSales = new List<decimal>();

            foreach (DateTime d in weekDates)
            {
                var wDayProfit = SR.calcProfitPerday(d.Date);
                weekSales.Add(wDayProfit);
                wDays.Add(d.Date.ToShortDateString());
            }

            jsonWeekDays = serializer.Serialize(wDays);
            jsonWeekProfits = serializer.Serialize(weekSales);
            /*Graph data --END*/


            string Display = "";
            //Displaying the users perweek and the change in percentange
            double userChange = SR.percentageUserChange(DateTime.Now);
            int usrperDay = SR.getUsersPerDay(DateTime.Now);
            Display += "<div class='row'><div class='col'>";
            Display += "<h5 class='card-title text-uppercase text-muted mb-0'>New users</h5>";
            Display += "<span class='h2 font-weight-bold mb-0'>"+ usrperDay + "</span></div>";
            Display += "<div class='col-auto'>";
            Display += "<div class='icon icon-shape bg-gradient-orange text-white rounded-circle shadow'>";
            Display += "<i class='ni ni-chart-pie-35'></i></div></div></div><p class='mt-3 mb-0 text-sm'>";
            if(userChange > 0)
            { 
                Display += "<span class='text-success mr-2'><i class='fa fa-arrow-up'></i> "+ Math.Round(userChange, 2) +"%</span>";
            }
            else if(userChange < 0)
            {
                Display += "<span class='text-danger mr-2'><i class='fas fa-arrow-down text-danger mr-3'></i> " + Math.Round(userChange, 2) + "%</span>";

            }
            else
            {
                Display += "<span class='text-success mr-2'> " + Math.Round(userChange, 2) + "%</span>";
            }
            Display += "<span class='text-nowrap'>Since last week</span></p>";
            newUsr.InnerHtml = Display;

            int NumbSalesPerWeek = SR.NumsalesPerWeek(DateTime.Now);
            double percentageChange = SR.NumSaleChange(DateTime.Now);
            Display = "";
            Display += "<div class='row'>";
            Display += "<div class='col'>";
            Display += "<h5 class='card-title text-uppercase text-muted mb-0'>Sales</h5>";
            Display += "<span class='h2 font-weight-bold mb-0'>" + NumbSalesPerWeek + "</span></div>";
            Display += "<div class='col-auto'>";
            Display += "<div class='icon icon-shape bg-gradient-green text-white rounded-circle shadow'>";
            Display += "<i class='ni ni-money-coins'></i></div></div></div>";
            Display += "<p class='mt-3 mb-0 text-sm'>";
            if(percentageChange > 0)
            {
                Display += "<span class='text-success mr-2'><i class='fa fa-arrow-up'></i> " + Math.Round(percentageChange, 2) + "%</span>";
            }
            else if (percentageChange < 0)
            {
                Display += "<span class='text-danger mr-2'><i class='fa fa-arrow-down'></i> " + Math.Round(percentageChange, 2) + "%</span>";
            }
            else
            {
                Display += "<span class='text-success mr-2'> " + Math.Round(percentageChange, 2) + "%</span>";
            }
            Display += "<span class='text-nowrap'>Since last week</span></p>";
            Salesperweek.InnerHtml = Display;

            Display = "";
            // double perc = SR.percProductSales(DateTime.Now, 1);
            // int NumProducts = SR.numProductSales(DateTime.Now, 1);
            double profitperweek = SR.totalProfitPerWeek(DateTime.Now);
            double percChange = SR.percProfitPerWeek(DateTime.Now);
            Display += "<div class='row'>";
            Display += "<div class='col'>";
            Display += "<h5 class='card-title text-uppercase text-muted mb-0'>Profit</h5>";
            Display += "<span class='h2 font-weight-bold mb-0'>R" + profitperweek + "</span></div>";
            Display += "<div class='col-auto'>";
            Display += "<div class='icon icon-shape bg-gradient-info text-white rounded-circle shadow'>";
            Display += "<i class='ni ni-chart-bar-32'></i></div></div></div>";
            Display += "<p class='mt-3 mb-0 text-sm'>";
            if (percChange > 0)
            {
                Display += "<span class='text-success mr-2'><i class='fa fa-arrow-up'></i> " + Math.Round(percChange, 2) + "%</span>";
            }
            else if (percChange < 0)
            {
                Display += "<span class='text-danger mr-2'><i class='fa fa-arrow-down'></i> " + Math.Round(percChange, 2) + "%</span>";
            }
            else
            {
                Display += "<span class='text-success mr-2'> " + Math.Round(percChange, 2) + "%</span>";
            }
            Display += "<span class='text-nowrap'>Since last week</span></p>";
            productSales.InnerHtml = Display;

            Display = "";
            int weeklyTraffic = SR.trafficPerWeek(DateTime.Now);
            double percentage = SR.TrafficChange(DateTime.Now);
            Display +="<div class='row'>";
            Display +="<div class='col'><h5 class='card-title text-uppercase text-muted mb-0'>Traffic</h5>";
            Display +="<span class='h2 font-weight-bold mb-0'>" + weeklyTraffic + "</span></div>";
            Display +="<div class='col-auto'>";
            Display +="<div class='icon icon-shape bg-gradient-red text-white rounded-circle shadow'>";
            Display +="<i class='ni ni-active-40'></i></div></div></div>";
            Display +="<p class='mt-3 mb-0 text-sm'>";
            if (percentage > 0)
            {
                Display += "<span class='text-success mr-2'><i class='fa fa-arrow-up'></i> " + Math.Round(percentage, 2) + "%</span>";
            }
            else if (percentage < 0)
            {
                Display += "<span class='text-danger mr-2'><i class='fa fa-arrow-down'></i> " + Math.Round(percentage, 2) + "%</span>";
            }
            else
            {
                Display += "<span class='text-success mr-2'> " + Math.Round(percentage, 2) + "%</span>";
            }
            Display +="<span class='text-nowrap'>Since last week</span></p>";
            traffic.InnerHtml = Display;

            dynamic toppages = SR.topPages();

            Display = "";
            foreach(String s in toppages)
            {
                int singlePageTraffic = SR.singlePageTraffic(s);
                int uniquevisitor = SR.singlePageUniqueTraffic(s);
                Display += "<tr><th scope='row'>" + s+"</th>";
                Display += "<td>"+singlePageTraffic+"</td>";
                Display += "<td>"+ uniquevisitor + "</td></tr>";
                //Display += "<td><i class='fas fa-arrow-up text-success mr-3'></i></td></tr>";
            }
            pageTraffic.InnerHtml = Display;
        }
    }
}