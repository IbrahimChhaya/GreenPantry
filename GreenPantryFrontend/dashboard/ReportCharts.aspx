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
              <div class="chart">
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
                  <h5 class="h3 mb-0" id="sales-chart-label">Best Performing Products</h5>
                </div>
                <div class="col">
                  <ul class="nav nav-pills justify-content-end">
                    <li class="nav-item mr-2 mr-md-0">
                        <a OnClick="monthlySalesChart()" href="#" class="nav-link py-2 px-3 active"  data-toggle="tab">
                            <span class="d-none d-md-block">Month</span>
                            <span class="d-md-none">M</span>
                        </a>
                    </li>
                    <li class="nav-item">
                      <a OnClick="weeklySalesChart()" href="#" class="nav-link py-2 px-3"  data-toggle="tab">
                        <span class="d-none d-md-block">Week</span>
                        <span class="d-md-none">W</span>
                      </a>
                    </li>
                  </ul>
                </div>

              </div>
            </div>
            <div class="card-body">
              <!-- Chart -->
              <div class="chart" id="sales-chart-parent">
                <!-- Chart wrapper -->
                <canvas id="chart-sales" class="chart-canvas"></canvas>
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
            monthlySalesChart();
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

        <%--Sales Chart --%>
        function monthlySalesChart() {
            $('#sales-chart-label').html("Current Month's Sales")
            salesChart(<%= jsonMonthDates%>, <%= jsonMonthSales%>)
        }

        function weeklySalesChart() {
            $('#sales-chart-label').html("Current Week's Sales")
            salesChart(<%= jsonWeekDays %>, <%= jsonWeekSales %>)
        }

        function salesChart(chartLabels, chartData) {
            $('#chart-sales').remove(); //remove canvas (delete altogether)
            //create a new canvas
            $('#sales-chart-parent').append('<canvas id="chart-sales" class="chart-canvas"></canvas>');

            //get canvas context
            var ctx = document.getElementById('chart-sales').getContext("2d");

            //draw chart
            var myChart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: chartLabels,
                    datasets: [{
                        label: 'Sales',
                        data: chartData,
                    }]
                },
                options: {
                    scales: {
                        xAxes: [{
                            type: 'category',
                            labels: chartLabels,
                            ticks: {
                                callback: function (value, index, values) {
                                    return value.slice(8, 10);
                                }
                            }
                        }],
                        yAxes: [{
                            ticks: {
                                beginAtZero: true,

                                callback: function (value) {
                                    return 'R' + value;
                                }
                            }
                        }]
                    },
                    tooltips: {
                        callbacks: {
                            label: function (item, data) {
                                var label = data.datasets[item.datasetIndex].label || '';
                                var yLabel = item.yLabel;
                                var content = '';

                                content += 'R' + yLabel;
                                return content;
                            }
                        }
                    }
                }
            });

        }

    </script>
</asp:Content>
