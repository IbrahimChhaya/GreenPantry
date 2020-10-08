<%@ Page Title="" Language="C#" MasterPageFile="~/dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="ReportCharts.aspx.cs" Inherits="GreenPantryFrontend.dashboard.ReportCharts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content" id="panel">
  
    <!-- Header -->
    <div class="header bg-primary pb-6">
      <div class="container-fluid">
        <div class="header-body">
          <div class="row align-items-center py-4">
            <div class="col-lg-6 col-7">
              <h6 class="h2 text-white d-inline-block mb-0">Dashboard</h6>
            </div>
            <div class="col-lg-6 col-5 text-right">
                <h4 class="text-white">Howdy, Ubaid!</h4>
            </div>  
          </div>

          <!-- Card stats -->
          <div class="row">
          </div>
        </div>
      </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
      <div class="row">
        <div class="col-xl-8">
          <div class="card">
            <div class="card-header bg-transparent">
              <div class="row align-items-center">
                <div class="col">
                  <h6 class="text-muted text-uppercase ls-1 mb-1">Overview</h6>
                  <h5 class="h3 mb-0">Best Performing Products</h5>
                </div>
              </div>
            </div>
            <div class="card-body">
              <!-- Chart -->
              <div class="chart" id="sales-chart-parent">
                <!-- Chart wrapper -->
                <canvas id="topProducts" class="chart-canvas"></canvas>
              </div>
            </div>
          </div>
        </div>
        <div class="col-xl-4">
          <div class="card">
            <div class="card-header bg-transparent">
              <div class="row align-items-center">
                <div class="col">
                  <h6 class="text-uppercase text-muted ls-1 mb-1">Performance</h6>
                  <h5 class="h3 mb-0">Devices</h5>
                </div>
              </div>
            </div>
            <div class="card-body">
              <!-- Chart -->
              <div class="chart">
                <canvas id="ReportsGraphs" class="chart-canvas"></canvas>
              </div>
            </div>
          </div>
        </div>
      </div>

             <div class="row">
        <div class="col-xl-8">
          <div class="card">
            <div class="card-header bg-transparent">
              <div class="row align-items-center">
                <div class="col">
                  <h6 class="text-muted text-uppercase ls-1 mb-1">Overview</h6>
                  <h5 class="h3 mb-0">Best Performing Products</h5>
                </div>
              </div>
            </div>
            <div class="card-body">
              <!-- Chart -->
              <div class="chart">
                <!-- Chart wrapper -->
                <canvas id="Graph1" class="chart-canvas"></canvas>
              </div>
            </div>
          </div>
        </div>
        <div class="col-xl-4">
          <div class="card">
            <div class="card-header bg-transparent">
              <div class="row align-items-center">
                <div class="col">
                  <h6 class="text-uppercase text-muted ls-1 mb-1">Performance</h6>
                  <h5 class="h3 mb-0">Devices</h5>
                </div>
              </div>
            </div>
            <div class="card-body">
              <!-- Chart -->
              <div class="chart">
                <canvas id="Graph2" class="chart-canvas"></canvas>
              </div>
            </div>
          </div>
        </div>
      </div>
      </div>
    </div>
<!--</div>-->
    <script>
        document.addEventListener("DOMContentLoaded", function (e) {
            deviceChart();
            TopproductChart();
        })
        function deviceChart() {
            var ctx = document.getElementById('ReportsGraphs').getContext('2d')
            var myDoughnutChart = new Chart(ctx, {
                type: 'pie',
                data: {
                    labels:
                        <%=catName%>,

                    datasets: [{
                        backgroundColor: ["#0074D9", "#FF4136", "#2ECC40", "#FF851B", "#7FDBFF", "#B10DC9", "#FFDC00", "#001f3f", "#39CCCC"],

                        label : "Test",
                        data: <%=catChart%>,
                    }]
                },
                options: {

                   
                },
                 
            })
        }

        //Top product chart--------------------------------------------------
        function TopproductChart() {
            var ctx = document.getElementById('topProducts').getContext('2d')
            var myDoughnutChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels:
                        <%=prodName%>,

                    datasets: [{
                        barThickness:'100',
                        //backgroundColor: ["#0074D9"],

                        label : "Units Sold",
                        data: <%=prodChart%>,
                    }]
                },
                options: {
                    scales: {
                        xAxes: [{
                            type: 'category',
                            labels: <%=prodName %>,
                            ticks: {
                                callback: function (value, index, values) {
                                    return value.slice(0, 5);
                                }
                            }
                        }],

                        yAxes: [{
                            ticks: {
                                callback: function (value) {
                                    return  value;
                                }
                            }
                        }]
                    },

                },

            })
        }

    </script>
</asp:Content>
