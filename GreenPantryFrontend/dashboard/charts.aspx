<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.3/Chart.js"></script>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <title>My Chart.js Chart</title>
</head>
<body>
    
  <div class="container"  >
    <canvas id="myChart"  ></canvas>
      <canvas id="myChart2"  ></canvas>
      
 </div>

  

  <script >
          let myChart = document.getElementById('myChart').getContext('2d');

          // Global Options
          Chart.defaults.global.defaultFontFamily = 'Lato';
          Chart.defaults.global.defaultFontSize = 18;
          Chart.defaults.global.defaultFontColor = '#777';

          let catprofit = new Chart(myChart, {
              type: 'bar',// bar, horizontalBar, pie, line, doughnut, radar, polarArea

              //P
              data: {
                  labels: ['Food Pantry', 'Fresh Food', 'Frozen Food', 'Deli & Party Foods', 'Ready Meals', 'Bakery-Bread & Desserts', 'Drinks', 'Eco-Friendly Household'],
                  datasets: [{
                      label: 'Profit',
                      data: ['4500', '3200', '2500', '4200', '4215', '2300', '4800', '1000'],
                      //backgroundColor:'green',
                      backgroundColor: [
                          'rgba(255, 99, 132, 0.6)',
                          'rgba(54, 162, 235, 0.6)',
                          'rgba(255, 206, 86, 0.6)',
                          'rgba(75, 192, 192, 0.6)',
                          'rgba(153, 102, 255, 0.6)',
                          'rgba(255, 159, 64, 0.6)',
                          'rgba(255, 99, 132, 0.6)'

                      ],
                      borderWidth: 1,
                      borderColor: '#777',
                      hoverBorderWidth: 3,
                      hoverBorderColor: '#000'
                  }]
              },


              options: {
                  title: {
                      display: true,
                      text: 'Profit per each category',
                      fontSize: 25
                  },
                  legend: {
                      display: true,
                      position: 'right',
                      labels: {
                          fontColor: '#000'
                      }
                  },
                  layout: {
                      padding: {
                          left: 50,
                          right: 0,
                          bottom: 0,
                          top: 0
                      }
                  },
                  tooltips: {
                      enabled: true
                  }
              }
          });
      

      ////newusers
      //let myChart = document.getElementById('myChart2').getContext('2d');

      //// Global Options
      //Chart.defaults.global.defaultFontFamily = 'Lato';
      //Chart.defaults.global.defaultFontSize = 18;
      //Chart.defaults.global.defaultFontColor = '#777';

      //let userperday = new Chart(myChart, {
      //    type: 'bar',// bar, horizontalBar, pie, line, doughnut, radar, polarArea
      //    type: 'bar',
      //    data: {
      //        labels: ['01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30'],
      //        datasets: [{
      //            label: 'Profit',
      //            data: ['03', '02', '01', '01', '02', '01', '02', '01', '02', '02', '01', '01', '01', '01', '01', '01', '02', '01', '0', '0', '0', '0', '01', '02', '0', '01', '03', '0', '1', '2'],
      //            //backgroundColor:'green',
      //            backgroundColor: [
      //                'rgba(255, 99, 132, 0.6)',
      //                'rgba(54, 162, 235, 0.6)',
      //                'rgba(255, 206, 86, 0.6)',
      //                'rgba(75, 192, 192, 0.6)',
      //                'rgba(153, 102, 255, 0.6)',
      //                'rgba(255, 159, 64, 0.6)',
      //                'rgba(255, 99, 132, 0.6)'

      //            ],
      //            borderWidth: 1,
      //            borderColor: '#777',
      //            hoverBorderWidth: 3,
      //            hoverBorderColor: '#000'
      //        }]
      //    },


      //    options: {
      //        title: {
      //            display: true,
      //            text: 'New users per day',
      //            fontSize: 25
      //        },
      //        legend: {
      //            display: true,
      //            position: 'right',
      //            labels: {
      //                fontColor: '#000'
      //            }
      //        },
      //        layout: {
      //            padding: {
      //                left: 50,
      //                right: 0,
      //                bottom: 0,
      //                top: 0
      //            }
      //        },
      //        tooltips: {
      //            enabled: true
      //        }
      //    }
      //});

      
  </script>
        
       
</body>
</html>
