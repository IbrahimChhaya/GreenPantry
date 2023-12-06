<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reports.aspx.cs" Inherits="AdminDashboard.reports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <canvas id ="ReportsGraphs">
                

            </canvas>
        </div>
        <asp:Button OnClientClick="deviceChart()" runat="server" id="dumbass"/> 
    </form>

    <script>
        document.addEventListener("DOMContentLoaded", function (e) {
            deviceChart();
        })
        function deviceChart() {
            var ctx = document.getElementById('ReportsGraphs').getContext("2d")
            var myDoughnutChart = new Chart(ctx, {
                type: 'doughnut',
                data: <%=catChart%> ,
                options: options
            });
        }
        

    </script>
</body>
</html>
